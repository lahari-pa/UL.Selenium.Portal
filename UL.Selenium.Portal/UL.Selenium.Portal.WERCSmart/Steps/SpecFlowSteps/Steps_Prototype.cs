using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using UL.Automation.Reporting;
using UL.Automation.Reporting.Functions;
using UL.Automation.WebDriver.Classes;
using UL.Automation.WebDriver.Extensions;
using UL.Automation.SpecFlow.Classes;
using UL.Automation.TReVor.Classes;
using UL.Automation.Utilities.Functions;
using UL.Selenium.Portal.WERCSmart.Classes;
using UL.Selenium.Portal.WERCSmart.Extensions;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.GenerateIntentionallyBadData;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product.Product_Type;
using UL.Selenium.Portal.WERCSmart.Steps.New_Product.Review_and_Submit;
using UL.Automation.Utilities.Helpers;
using Mailosaur;
using ReportDetails = UL.Automation.Reporting.Classes.ReportDetails;
using System.IO;
using System.Drawing.Imaging;
using BoDi;
using System.Drawing;
using System.Reflection;
using UL.Automation.Utilities;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product.Product_Characteristics;
using System.Runtime.InteropServices;
using static UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product.PesticideDetailsState;

namespace UL.Selenium.Portal.WERCSmart.Steps
{
	[Binding, Scope(Tag = "StepsPrototype")]
	class Steps_Prototype
	{
		[StepDefinition(@"I set the radio option in section: (.*) to: (.*)")]
		public void SetRadioOptionInSectionTo(string section, string option)
		{
			Report.IsTrue(new NewProduct().SelectRadio(section, option),
				$"Failed to select radio option in section: '{section}' to option: '{option}'",
				$"Successfully set radio option: '{option}'");
		}

		[StepDefinition(@"I set the (.*) field to: (.*)")]
		[StepDefinition(@"I set the (.*) option to: (.*)")]
		public void SetTheSectionOptionTo(string section, string option)
		{
			var thisNewProduct = new NewProduct();
			if (!thisNewProduct.WaitForContainerToBeVisible(3))
			{
				Report.Failure("The new product page is not showing");
			}
			if (option.StartsWith("UPC"))
			{
				var value = Context.GetFromContext(option)?.ToString();
				if (value == null)
				{
					throw new Exception($"Could not find item in context: {option} for checking field input is correct value!");
				}
				section = section.Trim();
				value = value.Trim();
				Report.IsTrue(thisNewProduct.SetOptionInSection(section, value),
					$"Failed to set the input to {value} in section: {section}",
					$"Successfully set the input to {value} in section: {section}");
				Delay.Seconds(1);
			}
			else
			{
				section = section.Trim();
				option = option.Trim();
				Report.IsTrue(thisNewProduct.SetOptionInSection(section, option),
					$"Failed to set the input to {option} in section: {section}",
					$"Successfully set the input to {option} in section: {section}");
				Delay.Seconds(1);
			}
		}

		[StepDefinition(@"in the (.*) page, I click Continue")]
		public void GivenInPageIClickContinue(string page)
		{
			var newProduct = new NewProduct();
			if (!newProduct.WaitForContainerToBeVisible())
			{
				Report.Failure("New Product page is not loaded");
				return;
			}
			if (!page.Equals("New Product", StringComparison.InvariantCultureIgnoreCase) && !newProduct.WaitForSection(page))
			{
				Report.Error($@"The page title did not match expected! Expected ""{page}""");
			}
			Report.Info("Clicking Continue");
			Report.IsTrue(newProduct.ClickContinue(), "Failed to click continue in the new product page!", "Successfully clicked continue in the new product page");
			if (page == "The Product" && newProduct.HeaderText == "The Product")
			{
				Report.Info("The active page is still 'The Product' after clicking continue");
				Report.Info("Checking for Raw Materials Warning pop up");
				var thisModalDialog = new ModalDialog();
				if (!thisModalDialog.WaitForContainerToBeVisible() || thisModalDialog.GetTitle() != "Warning")
				{
					Report.Failure("Failed to click continue to the next page!");
					return;
				}
				Report.IsTrue(thisModalDialog.Click_OK(), "Failed to click OK in the modal", "Clicked OK in the modal");
			}
		}

		public void GivenIConfirmTheTextsDisplaysTheCorrectText(string section, string[] correctText, string condition)
		{
			var newProductPage = new NewProduct();
			if (condition == "should")
			{
				Report.IsTrue(newProductPage.CheckTextOnThePage(correctText), $"The text in the {section} page displayed the incorrect text", $"The text in the {section} page displayed the correct text");
			}
			else
			{
				Report.IsFalse(newProductPage.CheckTextOnThePage(correctText), $"The text is displayed in the {section} page, but should not", $"The text is not displayed in the {section} page, as expected");

			}
		}

		public void ClickLinkElement(string linkText)
		{
			if (Report.IsTrue(new NewProduct().LinkElementExists(linkText), $"Failed to find link element with text {linkText}", $"Successfully found link element with text {linkText}"))
			{
				Report.IsTrue(new NewProduct().LinkElementClick(linkText), $"Failed to click link element with text {linkText}", $"Successfully clicked link element with text {linkText}");
			}
		}
		public void LinkElementExists(string condition, string linkText)
		{
			if (condition == "should")
			{
				Report.Info($"Attempt to confirm link element {linkText} is displayed");
				Report.IsTrue(new NewProduct().LinkElementExists(linkText), $"Failed to find link element with text {linkText}", $"Successfully found link element with text {linkText}");
			}
			else
			{
				Report.Info($"Attempt to confirm link element {linkText} is not displayed");
				Report.IsFalse(new NewProduct().LinkElementExists(linkText), $"Failed to confirm link element with text {linkText} is not displayed", $"Successfully confirmed link element with text {linkText} is not displayed");
			}
		}

		[StepDefinition(@"I switch to tab with url: (.*)")]
		public void ConfirmNewTabOpenWithUrl(string url)
		{
			new GlobalSteps().SwitchToTheTab(url);
		}

		[StepDefinition(@"I close the tab with url: (.*)")]
		public void CloseTabWithUrl(string url)
		{
			SeleniumBrowser.CloseTabWithURL(url);
			Report.IsTrue(!SeleniumBrowser.GetTabURLs().Contains(url), "Failed to close tab with URL: " + url, "Successfully closed tab with URL: " + url);
		}
		[StepDefinition(@"I confirm the tab (should|should not) exists with url: (.*)")]
		public void NewTabShouldExists(string condition, string url)
		{
			if (condition == "should")
			{
				Report.IsTrue(SeleniumBrowser.GetTabURLs().Contains(url), $"Failed to confirm new tab exists with url {url}", $"Successfully confirmed new tab exists with url {url}");
			}
			else
			{
				Report.IsTrue(!SeleniumBrowser.GetTabURLs().Contains(url), $"Failed confirm new tab does not exist with url {url}", $"Successfully confirmed new tab does not exist with url {url}");
			}
		}
		[StepDefinition(@"I confirm that a file is produced called (.*) and save as (.*)")]
		public void ConfirmFileAppearsInDownloadsFolder(string file, string savedAs)
		{
			Report.StartStep(ReportDetails.CurrentDetails.StepCounter + " - Confirm File is downloaded with name: " + file);
			try
			{
				Delay.Seconds(10);
				Report.Info("Confirm a file is downloaded with name: " + file);
				//string downloadsFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads";
				string downloadsFolder = AutomationSettings.DownloadsFolder;

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

		[StepDefinition("I compare the PDF: (.*) to the oracle PDF: (.*)")]
		public void CompareTwoPdfFiles(string toCompare, string oracle)
		{
			Assembly studioAssembly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(x => string.Equals(x.GetName().Name, "UL.Selenium.Portal.WERCSmart"));
			// Initialize Sub-Steps
			Report.UseSubSteps = true;
			Report.StartSubStep("Setup");

			// Get embedded resource(s).
			Report.Info("Getting embedded resources...");
			string toCompareResourceFile = toCompare;
			string oracleResourceFile = $"{studioAssembly.GetName().Name}.{oracle}";

			// Define an extraction folder.
			string extractionFolder = Path.Combine(Directory.GetCurrentDirectory(), "Temp", Guid.NewGuid().ToString());
			_ = Directory.CreateDirectory(extractionFolder);
			//"C:\Users\32143\source\repos\UL.Selenium.Portal\UL.Selenium.Portal\UL.Selenium.Portal.WERCSmart\Dependencies\PDF\HR1321.pdf"
			try
			{
				// Define location to save comparison pdf to.
				string toCompareFile = Path.Combine(extractionFolder, "downloaded.pdf");
				Report.Info($"Saving comparison PDF file to: {toCompareFile}");
				FileInfo fileDownloded = new FileInfo(toCompareResourceFile);
				fileDownloded.MoveTo(toCompareFile);
				// Get from embedded resources.
				//_ = EmbeddedResourceHelpers.ExtractToFile(toCompareResourceFile, studioAssembly, toCompareFile);

				// Define location to store saved images to.
				string compareImageFolder = Path.Combine(extractionFolder, "Images", "downloadedFile");
				Report.Info($"Extracting comparison images to: {compareImageFolder}_«PageNumber».png");

				// Extract page 'images' from PDF file.
				_ = PdfHelpers.ConvertPdfToImages(toCompareFile, compareImageFolder, out List<string> comparisonOutputFiles);

				// Define location to save oracle pdf to.
				string oracleFile = Path.Combine(extractionFolder, "originalFile.pdf");
				Report.Info($"Saving oracle PDF file to: {oracleFile}");
				var extractToFile = EmbeddedResourceHelpers.ExtractToFile(oracleResourceFile, studioAssembly, oracleFile);

				FileInfo fileOriginal = new FileInfo(oracleFile);
				//fileOriginal.MoveTo(oracleFile);
				// Get from embedded resources.

				// Define location to store saved images to.
				string oracleImageFolder = Path.Combine(extractionFolder, "Images", "originalFile");
				Report.Info($"Extracting oracle images to: {oracleImageFolder}_«PageNumber».png");

				// Extract page 'images' from PDF file.
				_ = PdfHelpers.ConvertPdfToImages(oracleFile, oracleImageFolder, out List<string> oracleOutputFiles);

				// Check to see if the page count is the same for both files.
				if (oracleOutputFiles.Count != comparisonOutputFiles.Count)
				{
					Report.Failure($"Expected to find: {oracleOutputFiles.Count} images, but found: {comparisonOutputFiles.Count} instead!");
				}
				// Iterate through each page.
				int pagecount = Math.Min(oracleOutputFiles.Count, comparisonOutputFiles.Count);
				for (int i = 0; i < pagecount; i++)
				{
					Report.StartSubStep($"Checking Page: {i + 1}");

					// Define image paths for each image file.
					string oracleImagePath = oracleOutputFiles[i];
					string comparisonImagePath = comparisonOutputFiles[i];

					// Load each image file.
					Image oracleImage = Image.FromFile(oracleImagePath);
					Image comparisonImage = Image.FromFile(comparisonImagePath);
					//var result = oracleImage.CompareTo(comparisonImage, 0, false, out Image diffImage1);
					try
					{
						// Run comparison. By default, tolerance is 0% (so exact match), can be changed if required.
						if (!oracleImage.CompareTo(comparisonImage, 0, false, out Image diffImage))
						{
							// If we don't have a match, then render out the differential image.
							// The differential image will show a black pixel where there was a mismatched pixel located.

							// Define the folder to be used.
							string diffImageFolder = Path.Combine(extractionFolder, "Images", "Differentials");
							_ = Directory.CreateDirectory(diffImageFolder);

							// Save the differential image to disk.
							string diffImagePath = Path.Combine(diffImageFolder, $"Difference_{i + 1}.png");
							diffImage.Save(diffImagePath, ImageFormat.Png);

							// Report failure and add image to the report.
							Report.Failure("Page did not match!", false);

							// Report oracle image.
							Report.Info("Oracle:");
							Report.ImageFile(oracleImagePath);


							// Report comparison image.
							Report.Info("Showing:");
							Report.ImageFile(comparisonImagePath);

							// Report diff image.
							Report.Info("Difference:");
							Report.ImageFile(diffImagePath);
						}
						else
						{
							// Matched successfully.
							Report.Success("Page matched successfully!", showScreenshot: false);

							// Report oracle image.

							Report.ImageFile(oracleImagePath);

						}
					}
					catch (Exception ex)
					{
						Report.Info($"Fixable ERROR: {ex.Message}");
					}
					finally
					{
						oracleImage.Dispose();
						comparisonImage.Dispose();
					}
				}

			}
			catch (Exception ex)
			{
				Report.Failure($"ERROR: {ex.Message}");
			}
			finally
			{
				if (Directory.Exists(extractionFolder))
				{
					Directory.Delete(extractionFolder, true);
				}
			}
		}

		[StepDefinition(@"I (should|should not) see an alert with title: (.*) subtitle: (.*) Text: (.*)")]
		public void ThenIShouldSeeAnAlertWithTitleSubtitleText(string condition, string title, string subtitle, string text)
		{
			var thisNewProduct = new NewProduct();
			Alert thisAlert = thisNewProduct.GetAlert();
			if (condition == "should")
			{
				Report.IsTrue(thisAlert.Title == title, "Title is not as expected", "Warning title is displayed");
				Report.IsTrue(thisAlert.SubTitle.Contains(subtitle), $"SubTitle is not as expected. Expected {subtitle}, but got: {thisAlert.SubTitle}", "Warning subtitle is displayed");
				Report.IsTrue(thisAlert.Text == text, $"Text is not as expected. Expected {text}, but got: {thisAlert.Text}", "Warning text is displayed");
			}
			else
			{
				Report.IsFalse(thisAlert.Title == title, "Warning title is displayed, but it is not expected", "Warning title is not displayed, as expected");
				Report.IsFalse(thisAlert.SubTitle.Contains(subtitle), "SubTitle is displayed, but it is not expected.", "SubTitle is not displayed, as expected.");
				Report.IsFalse(thisAlert.Text == text, "Warning text is displayed, but it is not expected.", "Warning text is not displayed, as expected.");
			}
		}
		[StepDefinition(@"I click the browse button for section: (.*) and upload PDF: (.*)")]
		public void UploadPDFFile(string section, string pdfFile)
		{
			pdfFile = EmbeddedResourceHelpers.ExtractToFile(pdfFile, out string extractFile) ? extractFile : pdfFile;
			Report.IsTrue(new NewProduct().UploadFileForSection(section, pdfFile), $"Failed to upload PDF file: {pdfFile} for section {section}", $"Successfully uploaded PDF file: {pdfFile} for {section}");
		}
		[StepDefinition(@"I click the button (.*) for section: (.*)")]
		public void ClickButtonForSection(string section, string button)
		{
			Report.IsTrue(new NewProduct().ClickButton(section, button), $"Failed to click button {button} for section {section}", $"Successfully clicked {button} for {section}");
		}

		[StepDefinition(@"I check the button (.*) (should|should not) exists for section: (.*)")]
		public void CheckButtonExistsForSection(string section, string condition, string button)
		{
			if (condition == "should")
			{
				Report.IsTrue(new NewProduct().CheckButtonExistsInSection(section, button), $"Failed to confirm button {button} exists for section {section}", $"Successfully confirmed {button} exists for {section}");
			}
			else
			{
				Report.IsFalse(new NewProduct().CheckButtonExistsInSection(section, button), $"Failed to confirm button {button} does not exist for section {section}", $"Successfully confirmed {button} does not exist for {section}");
			}
		}
		[StepDefinition(@"In the popup with the following title: (.*) I click the (.*) button")]
		public void ThenInThePopupViewWithTheFollowingTitleIClickTheButton(string popupTitle, string buttonTitle)
		{
			Report.IsTrue(new ModalDialog().ClickTheButtonInThePopupView(popupTitle, buttonTitle), "Failed to click the " + buttonTitle + " button", "Successfully clicked the " + buttonTitle + " button");
			//Delay.Seconds(5);
			Delay.Seconds(1);
		}

		[StepDefinition(@"The alert message (should|should not) displayed with text: (.*)")]
		public void AlertMessageDisplayed(string displayed, string alert)
		{
			bool expectDisplayed = false;
			switch (displayed)
			{
				case "should":
					expectDisplayed = true;
					break;
				case "should not":
					break;
				default:
					Report.Failure("Step parameter must be either 'should' or 'should not'");
					return;
			}
			List<string> actualAlerts = new NewProduct().DisplayedAlerts();
			if (actualAlerts == null)
			{
				Report.Failure("Error fetching alert messages!");
				return;
			}
			Report.IsTrue(actualAlerts.Contains(alert) == expectDisplayed,
				$"Alert message {(expectDisplayed ? "is not" : "is")} displayed when . Expected: {alert} but got: {string.Join(",", actualAlerts)}",
				$"Message: '{alert}' is displayed as expected");
		}

		[StepDefinition(@"In the Product Includes Battery page enter value (.*) for select option (.*)")]
		public void EnterBatterySelectOption(string value, string option)
		{
			Report.IsTrue(new ProductIncludesBattery().SetSelectBatteriesOptions(option, value), $"Failed to enter {value} in {option} field", $"Succesfully entered {value} in {option} field");
		}

		[StepDefinition(@"In the Product Includes Battery page enter value (.*) for input option (.*)")]
		public void EnterBatteryInputInformation(string value, string option)
		{
			Report.IsTrue(new ProductIncludesBattery().EnterInputBatteriesOption(option, value), $"Failed to enter {value} in {option} field", $"Succesfully entered {value} in {option} field");

		}

		[StepDefinition(@"In the Product Includes Battery page enter value (.*) for search select option (.*)")]
		public void EnterBatterySearchSelectInformation(string value, string option)
		{
			Report.IsTrue(new ProductIncludesBattery().SetBatteriesSearchSelectOption(option, value), $"Failed to enter {value} in {option} field", $"Succesfully entered {value} in {option} field");
		}
		[StepDefinition(@"I click the (.*) input section in Optional Reports and Documents Available for Purchase and select (.*)")]
		public void IClickTheInputSectionAndSelect(string section, string selection)
		{
			var reports = new OptionalReports();
			Report.IsTrue(reports.SelectInputForSection(section, selection), $"Failed to select input {selection} for section {section}.",
				$"Successfully selected input {selection} for section {section}.");
		}

		[StepDefinition(@"The total for section (.*) in Optional Reports and Documents Available for Purchase should equal (.*)")]
		public void TotalForSectionShouldEqual(string section, string value)
		{
			var reports = new OptionalReports();
			Report.IsTrue(reports.CheckTotalForSection(section, value), $"Failed to find the correct value {value} for section {section}.",
				$"Successfully found correct value {value} for section {section}.");
		}

		[StepDefinition(@"I enter the following into the comments field: (.*)")]
		public void ThenIEnterTheFollowingIntoTheCommentsFieldCommentsFieldText(string text)
		{
			Report.IsTrue(new NewProduct().InputCommentAreaText(text), $"Text: {text} was not successfully inputted into the Optional Comments field!", $"Text: {text} was successfully inputted into the Optional Comments field!");
		}

		[StepDefinition(@"I should be on the (.*) Page")]
		public void GivenIShouldBeOnXPage(string page)
		{
			var newProduct = new NewProduct();
			if (newProduct.WaitForContainerToBeVisible())
			{
				Report.IsTrue(newProduct.WaitForSection(page), $"{page} is not showing when it was expected to", $"{page} is showing as expected");
				return;
			}
			Report.Failure("New product page was not visible");
			Report.Screenshot();
		}

		[StepDefinition(@"I enter the following EPA Pesticide Registration No\.: (.*)")]
		public void ThenIEnterTheFollowingEPAPesticideRegistrationNo_(string enterText)
		{
			PesticideDetailsState pesticideDetailsStateObject = new PesticideDetailsState();
			Report.IsTrue(pesticideDetailsStateObject.EnterEPAPesticideRegistrationNo(enterText), "Failed to enter EPA Pesticide Registration No.", "Successfully entered EPA Pesticide Registration No.");
		}
		[StepDefinition(@"I click button: (.*)")]
		public void ClickButton(string button)
		{
			if (Report.IsTrue(new NewProduct().ButtonExists(button),
				$"Failed to find button {button}",
				$"Successfully found button {button}"))
			{
				Report.IsTrue(new NewProduct().ButtonClick(button),
				$"Failed to click button {button}",
				$"Successfully clicked button {button}");
			}
		}
		[StepDefinition(@"In Pesticide Details - State Registration Details page I set the following data: (.*) for the following state: (.*)")]
		public void GivenISetTheFollowingDataErtForTheFollowingStateMA(string date, string state)
		{
			Report.IsTrue(new PesticideDetailsStateRegistrationRow(state).EnterDate(date), $"Failed to enter a State Expiration Date {date} for state {state}", $"Successfully entered a State Expiration Date {date} for state {state}");
		}
		[StepDefinition(@"In Pesticide Details - State Registration Details page I select status: (.*) for the following state: (.*)")]
		public void GivenISetTheFollowingStatus(string status, string state)
		{
			Report.IsTrue(new PesticideDetailsStateRegistrationRow(state).EnterStatus(status), $"Failed to select status {status} for state {state}", $"Successfully selected status {status} for state {state}");
		}
		[StepDefinition(@"In Pesticide Details - State Registration Details page I verify expiration date for state: (.*)")]
		public void VerifyDateIsPrefilled(string state)
		{
			Report.IsTrue(new PesticideDetailsStateRegistrationRow(state).DateIsPrefilled(state), $"Failed to confirm State Expiration Date for state {state} is prefilled", $"Successfully confirmed State Expiration Date for state {state} is prefilled");
		}
		[StepDefinition(@"In Pesticide Details - State Registration Details page I verify status: (.*) is selected for the following state: (.*)")]
		public void StatusIsSelectedForTheState(string status, string state)
		{
			Report.IsTrue(new PesticideDetailsStateRegistrationRow(state).SelectedStatusForState(status), $"Failed to confirm status {status} is selected for state {state}", $"Successfully confirmed status {status} is selected for state {state}");
		}
		[StepDefinition(@"In Pesticide Details - State Registration Details page I verify row color highlighting indicates item is expiring in less then (31|90) for state: (.*)")]
		public void VerifyRowColor(string days, string state)
		{
			Report.IsTrue(new PesticideDetailsStateRegistrationRow(state).ColorHighlighting( days), $"Failed to confirm row color highlighting indicates item is expiring in less then {days} for state {state}", $"Successfully confirmed row color highlighting indicates item is expiring in less then {days} for state {state}");
		}
		[StepDefinition(@"In Pesticide Details - State Registration Details page I verify check mark in Expiration Imported column (should|should not) be displayed for state: (.*)")]
		public void VerifyCheckMerk(string condition, string state)
		{
			if (condition == "should")
			{
				Report.IsTrue(new PesticideDetailsStateRegistrationRow(state).VerifyExpirationImportedMark(), $"Failed to confirm check mark in Expiration Imported column exists for state {state}", $"Successfully confirmed check mark in Expiration Imported column exists for state {state}");
			}
			else
			{
				Report.IsFalse(new PesticideDetailsStateRegistrationRow(state).VerifyExpirationImportedMark(), $"Failed to confirm check mark in Expiration Imported column doesn't exist for state {state}", $"Successfully confirmed check mark in Expiration Imported column doesn't exist for state {state}");

			}
		}
		[StepDefinition(@"In Pesticide Details - State Registration Details page I select status: (.*) for the all states with no selected status")]
		public void GivenISetTheFollowingStatusForAllStates(string status)
		{
			Report.IsTrue(new PesticideDetailsStateRegistrationTable().SelectOneStatusForAllStatesWithNoSelectedStatus(status), $"Failed to select status {status} for states with no status selected", $"Successfully selected status {status} for all states with no status selected");
		}
		[StepDefinition(@"In Pesticide Details - State Registration Details page I click 'Select All' for status: (.*) for the all states")]
		public void GivenIClickSelectAllForAllStates(string status)
		{
			Report.IsTrue(new PesticideDetailsStateRegistrationTable().ClickSelectAllForStatus(status), $"Failed to click 'Select All' for {status}", $"Successfully clicked 'Select All' for status {status}");
		}

		[StepDefinition(@"I confirm that I see the following (.*) value: (.*)")]
		public void ThenIConfirmThatISeeTheFollowingCARBValue(string category, string expectedValue)
		{
			var newProductpage = new NewProduct();
			string foundValue = newProductpage.GetValueVOCSummary(category);
			Report.IsTrue(foundValue?.Trim() == expectedValue.Trim(),
				$"value was not as expected! Expected: {expectedValue}, but found: {foundValue}!",
				$"value was showing: {expectedValue}, as expected!");
		}

		[StepDefinition(@"I confirm that I see todays VOC Analysis Date")]
		public void ThenIConfirmThatISeeTodaysVOCAnalysisDate()
		{
			string date = DateTime.Now.ToString("MM/dd/yyyy");
			var newProductpage = new NewProduct();
			string found = newProductpage.GetValueVOCSummary("VOC Analysis");

			Report.IsTrue(found.Trim() == date.Trim(),
				$"date was not as expected! Expected: {date}, but found: {found}!",
				$"statement was showing: {date}, as expected!");
		}

		[StepDefinition(@"I confirm that the (.*) table (should|should not) exists")]
		public void ThenIConfirmThatTableExists(string tableName, string condition)
		{
			var newProductpage = new NewProduct();
			if (condition == "should")
			{
				Report.IsTrue(newProductpage.TableExists(tableName), $"Failed to confirm '{tableName}' table exists", $"Successsfully confirmed '{tableName}' table exists");
			}
			else
			{
				Report.IsFalse(newProductpage.TableExists(tableName), $"Failed to confirm '{tableName}' table does not exist", $"Successsfully confirmed '{tableName}' table does not exist");
			}
		}

	}
}
