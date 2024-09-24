using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using Castle.Core.Internal;
using NUnit.Framework;
using Reqnroll;
using UL.Automation.Reporting;
using UL.Automation.Reporting.Functions;
using UL.Automation.WebDriver.Classes;
using UL.Automation.ReqnrollHelpers.Classes;
using TReVor.Integrations.Classes;
using UL.Automation.Utilities.Functions;
using UL.Selenium.Portal.RPS.Classes;
using UL.Selenium.Portal.RPS.Selenium_Classes;
using static UL.Selenium.Portal.RPS.Selenium_Classes.WidgetPage.Widget;
using System.Configuration;
using System.Collections.Specialized;
using UL.Automation.Reporting.Classes;
using UL.Automation.ReqnrollHelpers.Attributes;
using UL.Automation.WebDriver.Extensions;
using UL.Selenium.Portal.WERCSmart.Classes;

[assembly: Apartment(ApartmentState.STA)]

namespace UL.Selenium.Portal.RPS.Steps
{
	[Binding]
	public class Global_Steps
	{

		[RegexStepDefinition(@"I verify that a tab opens with url: (.*)")]
		public void GivenIVerifyANewTabOpensToTheProductSupplyChainIntelligenceWebsite(string url)
		{
			if (Report.IsTrue(SeleniumWebDriver.CurrentDriver.GetTabURLs().Contains(url), "Failed to find a tab with URL: " + url, "Successfully found a tab with URL: " + url, false, false))
			{
				var currUrl = SeleniumWebDriver.CurrentDriver.Url;
				SeleniumWebDriver.CurrentDriver.SwitchToTabWithURL(url);
				Report.Screenshot();
				SeleniumWebDriver.CurrentDriver.SwitchToTabWithURL(currUrl);
			}
		}

		[RegexStepDefinition(@"I verify that no tab opens")]
		public void CheckNotabsOpenUp()
		{
			Report.IsTrue(SeleniumWebDriver.CurrentDriver.GetTabURLs().Count == 1, "Another tab was found to be open!", "No tabs were found to be open!");
		}

		[RegexStepDefinition(@"I close the tab with url: (.*)")]
		public void CloseTabWithUrl(string url)
		{
			SeleniumWebDriver.CurrentDriver.CloseTabWithURL(url);
			Report.IsTrue(!SeleniumWebDriver.CurrentDriver.GetTabURLs().Contains(url), "Failed to close tab with URL: " + url, "Successfully closed tab with URL: " + url);
		}

		[RegexStepDefinition(@"I save TReVor test user: (.*) to Context as the active user")]
		public void SaveTrevorTestUserToContext(string savedAs)
		{
			var user = TReVorSettings.Credentials.GetCredential(savedAs);
			if (user == null)
			{
				throw new Exception("Failed to find user saved as: " + savedAs);
			}
			Context.AddToContext("ActiveUser", user);
		}

        [RegexStepDefinition(@"I navigate to the RPS landing page")]
        public void NavigateToTheLandingPage()
        {
            SeleniumWebDriver.CurrentDriver.Navigate().GoToUrl(SeleniumWebDriver.BaseTestUrl);
        }

        [RegexStepDefinition(@"I cannot change URL to access (Auditor|Drumlog) page")]
        public void AtemptToNavigatePage(string pageName)
        {
            Report.Info($"Attempting to navigate to the {pageName} page.");
            string pageUrlString = SeleniumWebDriver.CurrentDriver.Url.Replace("Onboarding", pageName);
            SeleniumWebDriver.CurrentDriver.Navigate().GoToUrl(pageUrlString);
            new Steps_Home().IVerifyPageNotFoundErrorIsDisplayed();
        }

        [RegexStepDefinition(@"I close the browser, all instances")]
        public void ICloseBrowser()
        {
            Report.Info($"Attempting to close the browser.");
            SeleniumWebDriver.CurrentDriver.Quit();
            Report.Screenshot();
        }

        [RegexStepDefinition(@"I open a new browser window")]
        public void IOpenBrowser()
        {
            Report.Info("Attempting to open a new browser window.");
            var applicationSettings = ConfigurationManager.GetSection("automationSettings") as NameValueCollection;
            switch (applicationSettings["BrowserType"])
            {
                case "Chrome":
                    SeleniumWebDriver.Interface.StartBrowser(WebDriverType.Chrome, "Default2");
                    break;
                case "Firefox":
                    SeleniumWebDriver.Interface.StartBrowser(WebDriverType.Firefox, "Default2");
                    break;
                case "MicrosoftEdge":
                    SeleniumWebDriver.Interface.StartBrowser(WebDriverType.Edge, "Default2");
                    break;
                case "IE":
                    SeleniumWebDriver.Interface.StartBrowser(WebDriverType.InternetExplorer, "Default2");
                    break;
                default:
                    SeleniumWebDriver.Interface.StartBrowser(WebDriverType.Chrome, "Default2");
                    break;
            }
            string Url = TReVorSettings.Variables.AllVariables["TestUrl"];
            SeleniumWebDriver.CurrentDriver.Navigate().GoToUrl(Url);
            Report.Screenshot();
        }

		[RegexStepDefinition(@"I confirm a new file has been downloaded with .csv format and save to context as: (.*)")]
		public void ConfirmNewFile(string savedAs)
		{
			if (!Context.Contains("Downloads"))
			{
				return;
			}
			var oldFiles = (FileInfo[])Context.GetFromContext("Downloads");
			int timer = 0;
			Delay.Seconds(10);
			while (timer < 120)
			{
				var newFiles = GeneralUtilities.GetDownloads();
				var differences = newFiles.Except(oldFiles);
				if (differences.Any())
				{
					FileInfo mostRecent = differences.OrderByDescending(x => x.LastWriteTime).Where(x=>!x.Name.EndsWith(".tmp")).FirstOrDefault();
					if (mostRecent.Name.EndsWith(".csv"))
					{
						Report.Success("New file with csv format was found in the downloads folder. File name: " + mostRecent.Name);
						Context.AddToContext(savedAs, mostRecent);
						return;
					}
					Report.Failure("No new file with format '.csv' in the downloads folder");
					return;
				}
				Delay.Seconds(1);
				timer++;
			}
			Report.Failure("There were no new files in the download folder after waiting 30 seconds");

		}

		[RegexStepDefinition(@"I save the download folder")]
		public void SaveDownloads()
		{
			FileInfo[] files = GeneralUtilities.GetDownloads();
			Context.AddToContext("Downloads", files);
		}

		[RegexStepDefinition(@"I confirm the csv file saved as: (.*) contains data")]
		public void ConfirmCsvFileContainsData(string savedAs)
		{
			if (!Context.Contains(savedAs))
			{
				Report.Failure("No object in context saved as: " + savedAs);
				return;
			}
			var contextObj = Context.GetFromContext(savedAs);
			if (contextObj.GetType() != typeof(FileInfo))
			{
				Report.Failure("Expected context object of type FileInfo!");
				return;
			}
			var fileInfo = (FileInfo)contextObj;
			if (fileInfo.Extension != ".csv")
			{
				Report.Info("Expected file with format .csv!");
				return;
			}
			using (var reader = new StreamReader(fileInfo.FullName))
			{
				int row = 0;
				while (!reader.EndOfStream)
				{
					var line = reader.ReadLine();
					var values = line.Split(',');
					if (row > 0 && values.Any())
					{
						Report.Success("The CSV file contained data!");
						return;
					}
					row++;
				}
			}
			Report.Failure("The CSV file did not contain data");
		}

        [RegexStepDefinition(@"I confirm that a new file is produced called (.*) and save as (.*)")]
        public void ConfirmFileAppearsInDownloadsFolder(string file, string savedAs)
        {
            Report.StartStep(Report.Details.StepIndex + " - Confirm File is downloaded with name: " + file);
            try
            {
                Delay.Seconds(10);
                Report.Info("Confirm a file is downloaded with name: " + file);
                string downloadsFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads";
                Report.Info("Downloads folder: " + downloadsFolder);
                string[] dir = Directory.GetFiles(downloadsFolder, "*" + file.Replace("<Date>", "*"), SearchOption.AllDirectories);
                if (Report.IsTrue(dir.Any(), "No file was found with name " + file, "File with name: " + dir.FirstOrDefault() + " was found successfully!"))
                {
                    Context.AddToContext(savedAs, dir.FirstOrDefault());
                }

			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[RegexStepDefinition(@"I open the file saved as: (.*) should see a new tabbed document with the pdf at it contains the text: (.*)")]
		public void ThenIShouldSeeANewTabbedDocumentWithThePdfContainingProductCodeSavedAsTestCase(string file, string findText)
		{
			Report.Info("Opening the file saved in context in a new chrome window");
			GeneralUtilities.OpenNewTabAndNavigateTo(file);
			var widgetPage = new WidgetPage();
			Delay.Seconds(3);
			string docURL = widgetPage.DocumentWindowOpen();
			Report.Screenshot();

			if (docURL != null)
			{
				string pdfText = widgetPage.DocumentText(docURL);
				string newTextFromPDF = GeneralUtilities.ConvertTextToNoSpaceString(pdfText);

				Report.IsTrue(newTextFromPDF.ToLower().Contains(findText.ToLower().Replace(" ", "")), "PDF does not contain: " + findText, "PDF contains " + findText);
			}
			else
			{
				Report.Error("Tabbed document has not been found as expected");
			}
		}

		[RegexStepDefinition(@"I open the file saved as: (.*) and take a screenshot")]
		public void IOpenTheFileSavedAsAndTakeAScreenShot(string file)
		{
			Report.Info("Opening the file saved in context in a new chrome window");
			GeneralUtilities.OpenNewTabAndNavigateTo(file);
			var widgetPage = new WidgetPage();
			Delay.Seconds(3);
			string docURL = widgetPage.DocumentWindowOpen();
			if (docURL != null)
			{
				Report.Screenshot();
			}
			else
			{
				Report.Error("Tabbed document has not been found as expected");
			}
		}


        [RegexStepDefinition(@"I delete the file I saved as (.*)")]
        public void DeleteFile(string savedAs)
        {
            string file = Context.GetFromContext(savedAs)?.ToString() ?? "";
            if (file.IsNullOrEmpty())
            {
                Report.Failure("Could not find file saved as: " + savedAs);
                return;
            }
            Report.Info("Deleting file: " + file);
            File.Delete(file);
        }

		[RegexStepDefinition(@"I Check that the two bitmaps saved as: (.*) and: (.*) are the same")]
		public void CheckBitmapsAreTheSame(string file1, string file2)
		{
			if (file1.ToLower().Contains("savedas"))
			{
				if (Context.Contains(file1))
				{
					file1 = (string)Context.GetFromContext(file1);
				}
				else
				{
					Report.Failure($"There was no string: {file1} in context");
					return;
				}

			}
			if (file2.ToLower().Contains("savedas"))
			{
				if (Context.Contains(file2))
				{
					file2 = (string)Context.GetFromContext(file2);
				}
				else
				{
					Report.Failure($"There was no string: {file2} in context");
					return;
				}

			}


			Bitmap bitmap2 = GeneralUtilities.CreateBitmapFromFile(file2);
			Bitmap bitmap1 = GeneralUtilities.CreateBitmapFromFile(file1);
			bool imagesAreSame = false;
			try
			{
				imagesAreSame = ImageFunctions.CompareImages(bitmap1, bitmap2, tolerancePercentage: 30);
				Report.IsTrue(imagesAreSame, "The images were not the same", "The Images were the same");
			}
			catch (Exception ex)
			{
				Report.Failure($"The images were not the same expected: {ex.Message}");
			}
		}

		[RegexStepDefinition(@"I close the window that was opened")]
		public void ThenCloseTheWindowThatOpened()
		{
			Report.StartStep(Report.Details.StepIndex + " - Closing current window");
			try
			{
				object mainWindowHandle = Context.GetFromContext("MainWindowHandle");
				if (mainWindowHandle == null)
				{
					throw new Exception("No Main Window Handle found in context!");
				}
				// if current window = main window then return
				Report.Info("Attempting to close the current window");
				SeleniumWebDriver.CurrentDriver.Close();
				Report.Info("Current window closed, switching to the MainWindowHandle");
				SeleniumWebDriver.CurrentDriver.SwitchTo().Window(mainWindowHandle.ToString());
				Report.Success("Browser window switched successfully!");
				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[RegexStepDefinition(@"I Check that the excel file saved as: (.*) contains the data saved as: (.*) for the column: (.*)")]
		public void ExcelFileContainsFollowingData(string fileSavedAs, string savedValues, string column)
		{
			string File = Context.GetFromContext(fileSavedAs)?.ToString() ?? "";
			//var lines = System.IO.File.ReadAllLines(File);
			//var values = new Dictionary<string, string>();
			//for(int i = 1; i < lines.Count(); i++)
			//{
			//    var lineValues = lines[i].Split(',');
			//    var status = Regex.Match(lineValues[0], "\"(.*)\"").Groups[1].Value.Trim();
			//    var count = Regex.Match(lineValues[1], "\"(.*)\"").Groups[1].Value.Trim();
			//    values.Add(status, count);
			//}

			//var acepCount = values.Keys;

			if (Report.IsTrue(!string.IsNullOrEmpty(File), "No matching file was found for name: " + fileSavedAs + "!", "File was found: " + File))
			{
				var ExcelUtils = new ExcelFunctions(File.ToString(), "output");
				List<string> ColumnTitles = ExcelUtils.Excel_GetRow(0);
				Report.Info("Column titles: " + string.Join(",", ColumnTitles));

				int columnIndex = 0;
				for (int j = 0; j < ColumnTitles.Count; j++)
				{
					if (ColumnTitles[j] == column)
					{
						columnIndex = j;
					}
				}
				var expectedCounts = (List<string>)Context.GetFromContext(savedValues);
				List<string> foundCounts = ExcelUtils.Excel_GetColumn(columnIndex);
				int i = 0;
				foreach (var item in foundCounts)
				{
					Report.Info($"The found count was:{item}, and the expected count was: {expectedCounts[i]}");
					if (expectedCounts[i] == column)
					{
						Report.Info("Found the column heading, movin to next value");
					}
					if (expectedCounts[i] == item)
					{
						Report.Success($"The Counts Matched");
						i++;

					}
					else
					{
						Report.Failure($"The counts did not match");
						i++;

					}
				}



			}

		}


		[RegexStepDefinition(@"I find the export csv saved as (.*) and check if the values saved as (.*) are found.")]
		public void ICheckCSVContainsValues(string fileSavedAs, string valuesSavedAs)
		{
			var savedDictionary = (Dictionary<string, string>)Context.GetFromContext(valuesSavedAs);
			string File = Context.GetFromContext(fileSavedAs)?.ToString() ?? "";
			var lines = System.IO.File.ReadAllLines(File);
			var values = new Dictionary<string, string>();
			for (int i = 0; i < lines.Count(); i++)
			{
				var lineValues = lines[i].Split(',');
				var status = Regex.Match(lineValues[0], "\"(.*)\"").Groups[1].Value.Trim();
				if (status == "")
				{
					var diffLineValues = lines[i].Split('"');
					if (diffLineValues.Count() == 1)
					{
						Report.Info("This was the headers line, moving on...");
					}
					else
					{
						status = Regex.Match(diffLineValues[1], "(.*)").Groups[1].Value.Trim();
						string count;
						if (diffLineValues[2] == ",")
						{
							count = Regex.Match(diffLineValues[3], "(.*)").Groups[1].Value.Trim();
						}
						else
						{
							count = Regex.Match(diffLineValues[2], ",(.*)").Groups[1].Value.Trim();
						}

						values.Add(status, count);
					}

				}
				else
				{
					var count = Regex.Match(lineValues[1], "(.*)").Groups[1].Value.Trim();
					if (count.Contains("\t"))
					{
						count = Regex.Match(lineValues[1], "\t(.*)\"").Groups[1].Value.Trim();


					}
					values.Add(status, count);
				}

			}

			GeneralUtilities.ConvertDictionaryToList(savedDictionary);
			GeneralUtilities.ConvertDictionaryToList(values);

			Report.Info($"The Expected values were: {string.Join(",", savedDictionary)}");
			Report.Info($"The Found values were: {string.Join(",", values)}");

			if (values.Count == savedDictionary.Count && !values.Except(savedDictionary).Any())
			{
				Report.Success("The values found in the csv matched the expected values");
				return;
			}
			else
			{
				var dif = values.Except(savedDictionary);
				Report.Info($"The differences found were: {string.Join(", ", dif)}");
				Report.Failure("The values found in the csv did not completely match the expected values");
			}





		}

		[RegexStepDefinition(@"OLD I find the Product List Pie Chart export csv saved as (.*) and check if the values saved as (.*) are found.")]
		public void ICheckProductListPieCSVContainsValuesOld(string fileSavedAs, string valuesSavedAs)
		{
			var savedItems = (ProductListItems)Context.GetFromContext(valuesSavedAs);
			string File = Context.GetFromContext(fileSavedAs)?.ToString() ?? "";
			var lines = System.IO.File.ReadAllLines(File);

			List<string> productNumbersStr = new List<string>();
			List<string> productNamesStr = new List<string>();
			List<string> supplierEmailsStr = new List<string>();
			List<string> upcNumbersStr = new List<string>();
			for (int i = 1; i < lines.Count(); i++)
			{
				var lineValues = lines[i].Split(',');
				if (lineValues.Count() < 4)
				{
					Report.Info("Moving the line on, until reach the Product values");
				}
				else
				{

					var productNumber = Regex.Match(lineValues[0], "\"(.*)\"").Groups[1].Value.Trim();
					var productName = Regex.Match(lineValues[1], "\"(.*)\"").Groups[1].Value.Trim();
					var supplierEmail = Regex.Match(lineValues[2], "\"(.*)\"").Groups[1].Value.Trim();
					var upc = Regex.Match(lineValues[3], "\"(.*)\"").Groups[1].Value.Trim();
					if (!productNumber.IsNullOrEmpty())
					{
						productNumbersStr.Add(productNumber);
					}
					if (!productName.IsNullOrEmpty())
					{
						productNamesStr.Add(productName);
					}
					if (!supplierEmail.IsNullOrEmpty())
					{
						supplierEmailsStr.Add(supplierEmail);
					}
					if (!upc.IsNullOrEmpty())
					{
						upcNumbersStr.Add(upc);
					}
				}

			}

			Report.IsTrue(productNumbersStr.Count == savedItems.ProductNumbers.Count && !productNumbersStr.Except(savedItems.ProductNumbers).Any(), "The Lists of Product Numbers did not match", "The Lists of Product numbers matched");

			Report.IsTrue(productNamesStr.Count == savedItems.ProductNames.Count && !productNamesStr.Except(savedItems.ProductNames).Any(), "The Lists of Product names did not match", "The Lists of Product Names matched");
			var diff = productNamesStr.Except(savedItems.ProductNames);

			Report.IsTrue(upcNumbersStr.Count == savedItems.ProductUPCs.Count && !upcNumbersStr.Except(savedItems.ProductUPCs).Any(), "The Lists of Product UPCs did not match", "The Lists of Product UPCs matched");





		}

		[RegexStepDefinition(@"I find the Product List Bar Graph export csv saved as (.*) and check if the values saved as (.*) are found.")]
		public void ICheckProductListBarCSVContainsValues(string fileSavedAs, string valuesSavedAs)
		{
			var savedItems = (ProductListItems)Context.GetFromContext(valuesSavedAs);
			string File = Context.GetFromContext(fileSavedAs)?.ToString() ?? "";
			var lines = System.IO.File.ReadAllLines(File);

			List<string> productNumbersStr = new List<string>();
			List<string> productNamesStr = new List<string>();
			List<string> supplierEmailsStr = new List<string>();
			List<string> upcNumbersStr = new List<string>();
			for (int i = 1; i < lines.Count(); i++)
			{
				// var newLine= lines[i].Replace(@"\", "<");
				//string test = @"\teststring";
				//string newtest= test.Replace(@"\", "<");
				//var lineValues = newLine.Split('<');
				//var lineValues = lines[i].Split('"');
				//var lineValues = lines[i].Split(',');

				string[] test = { "\",\"" };
				var lineValues = lines[i].Split(test, StringSplitOptions.None);

				if (lineValues.Count() < 4)
				{
					Report.Info("Moving the line on, until reach the Product values");
				}
				else
				{
					/*
					var productNumber = Regex.Match(lineValues[1], "(.*)").Groups[1].Value.Trim();
					var productName = Regex.Match(lineValues[3], "(.*)").Groups[1].Value.Trim();
					var supplierEmail = Regex.Match(lineValues[5], "(.*)").Groups[1].Value.Trim();
					var upc = Regex.Match(lineValues[7], "(.*)").Groups[1].Value.Trim();
					*/
					var productNumber = Regex.Match(lineValues[0], "(.*)").Groups[1].Value.Trim('"').Trim();
					var productName = Regex.Match(lineValues[1], "(.*)").Groups[1].Value.Trim('"').Trim();
					var supplierEmail = Regex.Match(lineValues[2], "(.*)").Groups[1].Value.Trim('"').Trim();
					var upc = Regex.Match(lineValues[3], "(.*)").Groups[1].Value.Trim('"').Trim();

					productName = productName.Replace("  ", " ");

					if (!productNumber.IsNullOrEmpty())
					{
						productNumbersStr.Add(productNumber);
						productNamesStr.Add(productName);
						supplierEmailsStr.Add(supplierEmail);
						upcNumbersStr.Add(upc);
					}

				}

			}

			Report.IsTrue(productNumbersStr.Count == savedItems.ProductNumbers.Count && !productNumbersStr.Except(savedItems.ProductNumbers).Any(), $"The Lists of Product Numbers did not match (expected: {productNumbersStr.Count}, saved: {savedItems.ProductNumbers.Count})", "The Lists of Product numbers matched");
			var test2 = productNamesStr.Except(savedItems.ProductNames);
			Report.IsTrue(productNamesStr.Count == savedItems.ProductNames.Count && !productNamesStr.Except(savedItems.ProductNames).Any(), $"The Lists of Product names did not match (expected: {productNamesStr.Count}, saved: {savedItems.ProductNames.Count})", "The Lists of Product Names matched");


			Report.IsTrue(supplierEmailsStr.Count == savedItems.ProductSuppliers.Count && !supplierEmailsStr.Except(savedItems.ProductSuppliers).Any(), $"The Lists of Product Suppliers did not match (expected: {supplierEmailsStr.Count}, saved: {savedItems.ProductSuppliers.Count})", "The Lists of Product suppliers matched");

			Report.IsTrue(upcNumbersStr.Count == savedItems.ProductUPCs.Count && !upcNumbersStr.Except(savedItems.ProductUPCs).Any(), $"The Lists of Product UPCs did not match (expected: {upcNumbersStr.Count}, saved: {savedItems.ProductUPCs.Count})", "The Lists of Product UPCs matched");



		}

		[RegexStepDefinition(@"I find the Product List Pie Chart export csv saved as (.*) and check if the values saved as (.*) are found.")]
		public void ICheckProductListPieCSVContainsValues(string fileSavedAs, string valuesSavedAs)
		{
			var savedItems = (ProductListItems)Context.GetFromContext(valuesSavedAs);
			string File = Context.GetFromContext(fileSavedAs)?.ToString() ?? "";
			var lines = System.IO.File.ReadAllLines(File);

			List<string> productNumbersStr = new List<string>();
			List<string> productNamesStr = new List<string>();
			List<string> supplierEmailsStr = new List<string>();
			List<string> upcNumbersStr = new List<string>();
			for (int i = 1; i < lines.Count(); i++)
			{
				// var newLine= lines[i].Replace(@"\", "<");
				//string test = @"\teststring";
				//string newtest= test.Replace(@"\", "<");
				//var lineValues = newLine.Split('<');
				//var lineValues = lines[i].Split('"');
				//var lineValues = lines[i].Split(',');
				string[] test = { "\",\"" };
				var lineValues = lines[i].Split(test, StringSplitOptions.None);

				if (lineValues.Count() < 4)
				{
					Report.Info("Moving the line on, until reach the Product values");
				}
				else
				{

					var productNumber = Regex.Match(lineValues[0], "(.*)").Groups[1].Value.Trim('"').Trim();
					var productName = Regex.Match(lineValues[1], "(.*)").Groups[1].Value.Trim('"').Trim();
					productName = productName.Replace("  ", " ");
					if (productName == "")
					{
						Report.Info("");
					}
					var supplierEmail = Regex.Match(lineValues[2], "(.*)").Groups[1].Value.Trim('"').Trim();
					var upc = Regex.Match(lineValues[3], "(.*)").Groups[1].Value.Trim('"').Trim();


					if (!productNumber.IsNullOrEmpty())
					{
						productNumbersStr.Add(productNumber);
						productNamesStr.Add(productName);
						supplierEmailsStr.Add(supplierEmail);
						upcNumbersStr.Add(upc);
					}

				}

			}

			Report.IsTrue(productNumbersStr.Count == savedItems.ProductNumbers.Count && !productNumbersStr.Except(savedItems.ProductNumbers).Any(), "The Lists of Product Numbers did not match", "The Lists of Product numbers matched");

			Report.IsTrue(productNamesStr.Count == savedItems.ProductNames.Count && !productNamesStr.Except(savedItems.ProductNames).Any(), "The Lists of Product names did not match", "The Lists of Product Names matched");
			var diff = productNamesStr.Except(savedItems.ProductNames);
			Report.IsTrue(upcNumbersStr.Count == savedItems.ProductUPCs.Count && !upcNumbersStr.Except(savedItems.ProductUPCs).Any(), "The Lists of Product UPCs did not match", "The Lists of Product UPCs matched");



		}

		[RegexStepDefinition(@"I Check that there is a new csv file downloaded and save the file path as: (.*)")]
		public void CheckNewCsvFileDownloadedAndSaveAs(string savedAs)
		{
			new Global_Steps().SaveDownloads();
			new Global_Steps().ConfirmNewFile("ExportFile");
			new Global_Steps().ConfirmCsvFileContainsData("ExportFile");
			FileInfo fileName = (FileInfo)Context.GetFromContext("ExportFile");
			string filepath = fileName.FullName;
			Context.AddToContext(savedAs, filepath);
		}


		[RegexStepDefinition(@"I check that the file saved as: (.*) contains the following column headings:")]
		public void CheckTheExcelFileContainsTheColumnHeadings(string fileSavedAs, Table table)
		{

			string File = Context.GetFromContext(fileSavedAs)?.ToString() ?? "";
			var lines = System.IO.File.ReadAllLines(File);
			var lineValues = lines[0].Split(',');
			if (lineValues[0].Contains("Status:"))
			{
				lineValues = lines[1].Split(',');
			}
			if (lineValues.Last() == " ")
			{
				lineValues = lineValues.Where(w => w != lineValues.Last()).ToArray();
			}
			for (int i = 0; i < lineValues.Length; i++)
            {
                lineValues[i]= lineValues[i].Trim('"');
				
            }
			Report.Info("Expected Headings:");
			ReqnrollReporting.Table(table);
			var headers = table.Rows.Select(x => x["Heading"]).ToList();
			Report.Info($"Expected headers were: {string.Join(", ", headers)}");
			List<string> foundHeaders = new List<string>(lineValues);
			Report.Info($"Found headers were: {string.Join(", ", foundHeaders)}");
			var differences1 = headers.Except(foundHeaders);
			var differences2 = foundHeaders.Except(headers);
			bool diffFound1 = differences1.Any();
			bool diffFound2 = differences2.Any();
			Report.IsTrue(!diffFound1 && !diffFound2, "The found and expected headers did not match", "The found and expected headers were a match!");

		}

		[RegexStepDefinition(@"I Check that the file saved as: (.*) included the following data in the column with heading: (.*)")]
		public void CheckNewCsvIncludesDataInColumn(string fileSavedAs, string heading, Table table)
		{
			string File = Context.GetFromContext(fileSavedAs)?.ToString() ?? "";
			var lines = System.IO.File.ReadAllLines(File);
			var lineValues = lines[0].Split(',');
			if (lineValues[0].Contains("Status:"))
			{
				lineValues = lines[1].Split(',');
			}
			Report.Info("Expected Values:");
			ReqnrollReporting.Table(table);
			var values = table.Rows.Select(x => x["Values"]).ToList();
			List<string> foundHeaders = new List<string>(lineValues);
			List<string> columnValues = new List<string>();
			int j = 0;
			int headerIndex = 0;
			bool foundHeader = false;
			foreach (var header in foundHeaders)
			{
				if (header == heading)
				{
					headerIndex = j;
					Report.Info("The heading was found");
					foundHeader = true;
					break;
				}
				else
				{
					j++;
				}
			}
			if (foundHeader == false)
			{
				Report.Failure("Did not find the header");
				return;
			}

			List<string> headingColumnValues = new List<string>();
			for (int i = 1; i < lines.Count(); i++)
			{
				var containedValues = lines[i].Split(',');
				var value = Regex.Match(containedValues[headerIndex], "\"(.*)\"").Groups[1].Value.Trim();
				columnValues.Add(value);
			}

			bool headersPresent = true;

			foreach (var item in values)
			{
				if (columnValues.Contains(item))
				{
					Report.Success($"The value: {item} was found in the csv file under the heading: {heading}");

				}
				else
				{
					headersPresent = false;
					Report.Failure($"The value: {item} was not found in the csv file under the heading: {heading}");
				}
			}


		}

		[RegexStepDefinition(@"I find the Supplier List export csv saved as (.*) and check if the values saved as (.*) are found.")]
		public void ICheckSupplierListCSVContainsValues(string fileSavedAs, string valuesSavedAs)
		{
			var savedItems = (SupplierListItems)Context.GetFromContext(valuesSavedAs);
			string File = Context.GetFromContext(fileSavedAs)?.ToString() ?? "";
			var lines = System.IO.File.ReadAllLines(File);
			List<string> suppliersStr = new List<string>();
			List<string> contactsStr = new List<string>();
			List<string> supplierEmailsStr = new List<string>();
			// List<string> upcNumbersStr = new List<string>();
			for (int i = 1; i < lines.Count(); i++)
			{

				string[] test = { "\",\"" };
				var lineValues = lines[i].Split(test,StringSplitOptions.None);

				if (lineValues.Count() < 4)
				{
					Report.Info("Moving the line on, until reach the Product values");
				}
				else
				{

					var supplier = Regex.Match(lineValues[0], "(.*)").Groups[1].Value.Trim('"').Trim();
					var contact = Regex.Match(lineValues[1], "(.*)").Groups[1].Value.Trim('"').Trim();
					if (contact == "")
					{
						Report.Info("");
					}
					var supplierEmail = Regex.Match(lineValues[3], "(.*)").Groups[1].Value.Trim('"');
					//var upc = Regex.Match(lineValues[7], "(.*)").Groups[1].Value.Trim();


					if (!supplier.IsNullOrEmpty())
					{
						suppliersStr.Add(supplier);
						contactsStr.Add(contact);
						supplierEmailsStr.Add(supplierEmail);
						//upcNumbersStr.Add(upc);
					}

				}

			}

			Report.IsTrue(suppliersStr.Count == savedItems.Suppliers.Count && !suppliersStr.Except(savedItems.Suppliers).Any(), "The Lists of suppliers did not match", "The Lists of suppliers matched");
			
			Report.IsTrue(contactsStr.Count == savedItems.Contacts.Count && !contactsStr.Except(savedItems.Contacts).Any(), "The Lists of contacts did not match", "The Lists of contacts matched");

			Report.IsTrue(supplierEmailsStr.Count == savedItems.Emails.Count && !supplierEmailsStr.Except(savedItems.Emails).Any(), "The Lists of emails  did not match", "The Lists of emails matched");


			// Report.IsTrue(upcNumbersStr.Count == savedItems.ProductUPCs.Count && !upcNumbersStr.Except(savedItems.ProductUPCs).Any(), "The Lists of Product UPCs did not match", "The Lists of Product UPCs matched");



		}



		//[RegexStepDefinition("For the Supplier Subscription Status Widget, I perform Chart Drill-down Export")]
		public void ForSupplierSubscriptionStatusIPerformChartDrillDownExport()
		{
			string widget = "Supplier Subscription Status";
			Report.UseSubSteps = true;
			Report.StartSubStep("I Select the First Area/Section of the Chart");
			new Steps_Home().ForWidgetISaveCurrentTitlesAndCheckThatWhenIClickSectionThatSupplierListSeen("CurrentChartTitles", "<first>");
			Report.StartSubStep("I Confirm the Supplier List Is Showing");
			new Steps_Home().WaitForAllWidgets();
			widget = "Supplier Subscription Status";
			new Steps_Home().SupplierContentDisplayedForTitle("is", widget);
			Report.StartSubStep("I confirm I see a Back button to the top right of the Widget Main Body area");
			Report.IsTrue(new Home.Widget(widget).SupplierListBackButtonDisplayed(), "The Back button was not displayed", "The back button was displayed");

			Report.StartSubStep("I click the three dots in the upper right corner of the widget: " + widget + " Then I select the Export Option and check that A file is downloaded that contains Data");
			new Steps_Home().ClickDropDownToggle(widget);
			new Steps_Home().ClickDropdownOptionWidget("Export", widget);
			new Global_Steps().SaveDownloads();
			new Global_Steps().ConfirmNewFile("ExportFile");
			new Global_Steps().ConfirmCsvFileContainsData("ExportFile");
			var fileName = (FileInfo)Context.GetFromContext("ExportFile");
			string filepath = fileName.FullName;
			Context.AddToContext("CurrentOutputCSV", filepath);

			Report.StartSubStep("I Get the current Supplier List Items, save them to context as 'CurrentSupplierListItems' and then check they match the csv export saved as 'CurrentOutputCSV'");
			var CurrentSupplierListItems = new Home.Widget(widget).GetCurrentSupplierListItems();
			Context.AddToContext("CurrentSupplierListItems", CurrentSupplierListItems);
			new Global_Steps().ICheckSupplierListCSVContainsValues("CurrentOutputCSV", "CurrentSupplierListItems");

			Report.StartSubStep($"I Delete the file saved as: CurrentOutputCSV");
			new Global_Steps().DeleteFile("CurrentOutputCSV");
			Report.StartSubStep("In the widget main body area, I click: Back");
			Report.IsTrue(new Home.Widget(widget).SupplierListBackButtonDisplayed(), "Failed to find the Products list back button", "Successfully found the Products list back button");
			Report.IsTrue(new Home.Widget(widget).ClickSupllierListBackButton(), "Failed to click the back button", "Successfully clicked the back button");
			Report.IsTrue(new Home.Widget(widget).WaitUntilGraphXIsDisplayed(), "The graph content did not appear", "The graph content was shown");



		}

		[RegexStepDefinition(@"In the URL area of the browser page, I confirm that the URL does not contain a #")]
		public void CheckURLDoesNotContainHash()
		{
			string currentUrl = SeleniumWebDriver.CurrentDriver.Url;
			Report.IsTrue(!currentUrl.Contains("#"), "The Current URL did contain a #", "The current URL did not contain a #");
		}

		[RegexStepDefinition(@"I confirm that a loading bar icon is shown")]
		public void IConfirmLoadingBarShown()
		{
			Report.IsTrue(GeneralUtilities.LoadingBarShowing(), "The loading bar was not showing", "The loading bar was shown");
		}

		[RegexStepDefinition(@"RPS Login - Base functionality for TReVor account: (.*) and do not wait for load")]
		public void Shared104950(string savedAs)
		{
			Report.UseSubSteps = true;
			Report.StartSubStep("I navigate to the landing page");
			new Global_Steps().NavigateToTheLandingPage();
			Report.StartSubStep("I confirm the Landing Page has loaded");
			new Steps_LandingPage().ConfirmLandingPageHasLoaded();
			var user = TReVorSettings.Credentials.GetCredential(savedAs);
			if (user == null)
			{
				throw new Exception("Failed to find user saved as: " + savedAs);
			}
			Report.StartSubStep("I enter the account username for: " + savedAs);
			new Steps_Login().EnterUserNameForTrevorTestUser(user);
			Report.StartSubStep("I enter the account password for: " + savedAs);
			new Steps_Login().EnterPasswordForTrevorTestUser(user);
			Report.StartSubStep("I click Log In");
			new Steps_Login().ClickLogIn();
			Context.AddToContext("ActiveUser", user);
		}

		[RegexStepDefinition(@"I switch to the window with the title: (.*)")]
		public void SwitchToWindowWithTitle(string title)
		{
			string currentHandle = SeleniumWebDriver.CurrentDriver.CurrentWindowHandle;
			Report.Info("Saving current window to context as MainWindowHandle");

			Context.AddToContext("MainWindowHandle", currentHandle);
			int i = 1;
			Report.Info("Attempting up to 10 times to find wanted tab");
			while (i < 11)
			{
				ReadOnlyCollection<string> allHandles = SeleniumWebDriver.CurrentDriver.WindowHandles;
				foreach (string handle in allHandles)
				{
					SeleniumWebDriver.CurrentDriver.SwitchTo().Window(handle);
					string currentTitle = SeleniumWebDriver.CurrentDriver.Title;
					if (currentTitle == title)
					{
						Report.Success("Tab with title was switched to");
						Report.Screenshot();
						return;
					}
				}
				Report.Info($"Did not find the tab:{title} on attempt: {i}");
				Delay.Seconds(1);
				i++;

			}

			throw new Exception("Failed to find window with title: " + title);
		}

		[RegexStepDefinition(@"I Close the browser tab with the title: (.*)")]
		public void CloseBrowserTabWithTitle(string title)
		{
			string currentHandle = SeleniumWebDriver.CurrentDriver.CurrentWindowHandle;
			Report.Info("Saving current window to context as MainWindowHandle");

			Context.AddToContext("MainWindowHandle", currentHandle);
			int i = 1;
			Report.Info("Attempting up to 10 times to find wanted tab");
			while (i < 11)
			{
				ReadOnlyCollection<string> allHandles = SeleniumWebDriver.CurrentDriver.WindowHandles;
				foreach (string handle in allHandles)
				{
					SeleniumWebDriver.CurrentDriver.SwitchTo().Window(handle);
					string currentTitle = SeleniumWebDriver.CurrentDriver.Title;
					if (currentTitle == title)
					{
						string url = SeleniumWebDriver.CurrentDriver.GetActiveTabURL();
						Report.IsTrue(SeleniumWebDriver.CurrentDriver.CloseTabWithURL(url), "Failed to close tab with url: " + url, "Closed tab with url: " + url);
						return;
					}
				}
				Report.Info($"Did not find the tab:{title} on attempt: {i}");
				Delay.Seconds(1);
				i++;

			}

			throw new Exception("Failed to find window with title: " + title);
		}

		[RegexStepDefinition(@"I generate a random UPC number and save as: (.*)")]
		public void GivenIGenerateARandomUPCNumberAndSaveAs(string savedAs)
		{
			string uPCNo = GeneralFunctions.GenerateUPCNumber();
			Context.AddToContext(savedAs, uPCNo);
			//Report.Info("Generated UPC No: " + uPCNo);
			//Delay.Seconds(2);
			Report.Info(uPCNo);
			Delay.Seconds(1);

		}

		[RegexStepDefinition(@"I generate 1000 random UPCs save them in a string array as: (.*)")]
		public void GivenIGenerate1000RandomUpcsAndSaveThemInArray(string savedAs)
		{
			string uPCNo;
			string[] stringArray = new string[1000];

			for (int i = 1; i < 1001; i++)
			{
				uPCNo = GeneralFunctions.GenerateUPCNumber();

				stringArray[i - 1] = uPCNo;


				Delay.Seconds(0.03);
			}

			Context.AddToContext(savedAs, stringArray);


			var unique1 = stringArray.Distinct().Count() == stringArray.Length;


			var unique2 = new HashSet<string>(stringArray).Count == stringArray.Length;


			var unique3 = !stringArray.Any(x => stringArray.Count(y => x == y) > 1);


			var unique4 = stringArray.All(x => stringArray.Count(y => x == y) == 1);

			if (unique1 == false || unique2 == false || unique3 == false || unique4 == false)
			{
				Report.Failure($"Not all array items are unique");

			}
			else
			{
				Report.Success($"1000 Unique UPCs were added to the array");
			}

		}


		[RegexStepDefinition(@"I generate a total of: (.*) random UPCs save them in a string array as: (.*)")]
		public void GivenIGenerateTotalXRandomUpcsAndSaveThemInArray(int upctotal, string savedAs)
		{
			string uPCNo;
			string[] stringArray = new string[upctotal];

			for (int i = 1; i < upctotal + 1; i++)
			{
				uPCNo = GeneralFunctions.GenerateUPCNumber();

				stringArray[i - 1] = uPCNo;


				Delay.Seconds(0.03);
			}

			Context.AddToContext(savedAs, stringArray);


			var unique1 = stringArray.Distinct().Count() == stringArray.Length;


			var unique2 = new HashSet<string>(stringArray).Count == stringArray.Length;


			var unique3 = !stringArray.Any(x => stringArray.Count(y => x == y) > 1);


			var unique4 = stringArray.All(x => stringArray.Count(y => x == y) == 1);

			if (unique1 == false || unique2 == false || unique3 == false || unique4 == false)
			{
				Report.Failure($"Not all array items are unique");

			}
			else
			{
				Report.Success($"{upctotal} Unique UPCs were added to the array");
			}

		}

        [RegexStepDefinition(@"I wait for (60|[1-5][0-9]?) minutes")]
        public void IWaitForMinutes(int nMinutes)
        {
            Report.Info($"Attempting to delaying for {nMinutes} minutes.");
            Delay.Seconds(60 * nMinutes);
            Report.Success($"Success, delayed for {nMinutes} minutes.");
        }

        [RegexStepDefinition(@"I refresh the web page")]
        public void IRefreshWebPage()
        {
            Report.Info("Attempting to refresh the web page.");
            SeleniumWebDriver.CurrentDriver.Navigate().Refresh();
            Report.Success("Success, refreshed the webpage.");
        }

		[RegexStepDefinition(@"I confirm the page has loaded")]
		[RegexStepDefinition(@"I confirm the page has refreshed")]

		public void IConfirmPageHasLoaded()
		{
			Report.IsTrue(new TopBar().WaitForContainerToBeVisible(), "Top bar did not load!");
			GeneralUtilities.WaitForLoadingToFinish();
			Report.IsTrue(new GridTable().WaitForContainerToBeVisible(60)," table did not load.","table successfully loaded");
			Report.Success("Success, refreshed the webpage.");
		}

	}
}
