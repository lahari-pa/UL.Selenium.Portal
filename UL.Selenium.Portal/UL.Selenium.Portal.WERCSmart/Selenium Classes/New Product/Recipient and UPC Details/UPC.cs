using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UL.Automation.WebDriver.Extensions;
using UL.Automation.Utilities.Functions;
using UL.Automation.Reporting.Functions;
using OpenQA.Selenium;
using UL.Automation.ReqnrollHelpers.Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;
using Reqnroll;
using System.IO;
using UL.Automation.WebDriver.Classes;
using UL.Automation.WebDriver.BaseClasses;
using System.Collections.ObjectModel;
using UL.Selenium.Portal.WERCSmart.Classes;
using UL.Automation.WebDriver.Shared.Classes.Configuration;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	class UPC : NewProduct
	{
		public bool ClickAddCaseUpcButton()
		{
			IWebElement el = this.ContainerElement.FindElement(By.XPath(".//button[contains(@data-bind,'addNewPackRow')]"), 2);
			if (el == null)
			{
				return false;
			}

			return el.TryClick();
		}

		public bool ClickSampleFileLink()
		{
			return this.FindElement(By.XPath("//a[@class='alert-link']"), 2).TryClick();
		}

		public string LithiumBatteyWarning()
		{
			//this.RefreshContainer();
			IWebElement el = this.ContainerElement.FindElement(By.XPath("//div[contains(text(), 'Lithium battery registrations')]"), 2);
			
			if (el == null)
			{
				return null;
			}
			return el.Text;
		}

		public bool CheckIfUPCDuplicateWarningAppears()
		{
			Report.Info("Beginning CheckIfUPCDuplicateWarningAppears");
			IWebElement UPCWarning = this.ContainerElement.FindElement(By.XPath("//i[contains(@title, 'UPC')]"), 2);
			
			if (UPCWarning == null)
			{
				return false;
			}

			if (UPCWarning == null)
			{
				Report.Info("UPCWarning returns null");
				return false;
			}
			return true;
		}

		public string MaximumLimitUpcWarning()
		{
			//this.RefreshContainer();
			IWebElement el = this.ContainerElement.FindElement(By.XPath("//p[@class='marBot-0' and contains(text(), 'maximum limit' )]"), 2);
			
			if  (el == null)
			{
				return null;
			}
			return el.Text;
		}

		public List<string> GetUPCOptions()
		{
			IWebElement container = this.ContainerElement.FindElement(By.XPath(".//table[@class='table table-hover upc-table']"), 2);
			this.WaitForContainerToBeVisible();			
			IList<IWebElement> rList = container.FindElements(By.XPath("//tbody//div[@class='form-group' or @class='form-group has-success']//input"), 2).ToList();

			return rList.Select(x => x.GetAttribute("placeholder")).ToList();			
		}

		public List<string> GetUPCbuttons()
		{
			return this.ContainerElement.FindElements(By.XPath("//button[@class='btn btn-success']"), 2).Select(x => x.GetValue()).ToList();
		}

		public bool AddCaseUpcButton()
		{
			IWebElement el = this.ContainerElement.FindElement(By.XPath(".//button[contains(@data-bind,'addNewPackRow')]"), 2);
			if (el == null)
			{
				return false;
			}

			return true;
		}


		public bool AddUpcButton()
		{
			IWebElement el = this.ContainerElement.FindElement(By.XPath(".//button[contains(@data-bind,'addNewRow')]"), 2);

			if (el == null)
			{
				return false;
			}

			return true;
		}


		public List<string> UPCProductNameError()
		{
			List<string> el = SeleniumWebDriver.CurrentDriver.FindElements(By.XPath(".//div[@class='form-group has-error']//span"), 2).Select(x => x.Text).ToList();
			return el;
		}

		public void EnterProductName(string name)
		{
			SeleniumWebDriver.CurrentDriver.FindElement(By.XPath(".//div[@class='form-group has-error']//input"), 2).EnterText(name);
		}

		public bool InputUpcCaseInformation(UpcCaseInformation info)
		{
			try
			{

				IWebElement container = this.ContainerElement.FindElement(By.XPath(".//table[@class='table table-hover upc-table']"), 2);
				IList<IWebElement> textInputs = container.FindElements(By.XPath("//input[@type = 'text']"), 2);
				IWebElement upcNumberField = container.FindElement(By.XPath(".//label[contains(text(),'UPC')]/..//input"), 2);
				IWebElement upcNameField = container.FindElement(By.XPath(".//label[contains(text(),'Product Name')]/..//input"), 2);
				
				if (container == null)
				{
					Report.Info("Container element was equal to null");
					return false;
				}

				if (textInputs == null)
				{
					Report.Info("Text Inputs element was equal to null");
					return false;
				}

				if (upcNumberField == null)
				{
					Report.Info("UPC Number field element was equal to null");
					return false;
				}

				if (upcNameField == null)
				{
					Report.Info("UPC Name Field element was equal to null");
					return false;
				}

				Delay.Seconds(0.5);
				if (info.UpcNumber.ToLower().Contains("saved as"))
				{
					try
					{
						string savedUPC = Context
							.GetFromContext(info.UpcNumber.Replace("saved as", "", StringComparison.InvariantCultureIgnoreCase).Trim())
							.ToString();
						info.UpcNumber = savedUPC;
					}
					catch (Exception e)
					{
						Report.Info("Failed to find saved item in context: " + info.UpcNumber.Replace("saved as", "", StringComparison.InvariantCultureIgnoreCase) + e.Message);
						throw;
					}

				}
				upcNumberField.EnterText(info.UpcNumber);


				//if (upcNameField.Text.IsNullOrEmpty())
				//{
				//	upcNameField.EnterText("UPCName PlaceHolder");
				//	Report.Failure("The UPC Name Field was empty, entered PlaceHolder text");
				//}
				//else
				//{
				//	Report.Info("The Field was not empty, Checking for UPCName in the table");
				//	if (!info.UPCName.IsNullOrEmpty())
				//	{
				//		if (info.UPCName.ToLower().Contains("saved as"), 2)
				//		{
				//			try
				//			{
				//				string savedUPC = Context
				//					.GetFromContext(info.UPCName.Replace("saved as", "", StringComparison.InvariantCultureIgnoreCase).Trim())
				//					.ToString();
				//				info.UPCName = savedUPC;
				//			}
				//			catch (Exception e)
				//			{
				//				Report.Info("Failed to find saved item in context: " + info.UPCName.Replace("saved as", "", StringComparison.InvariantCultureIgnoreCase) + e.Message);
				//				throw;
				//			}

				//		}

				//		upcNumberField.EnterText(info.UPCName);
				//	}
				//	else
				//	{
				//		Report.Info("UPC Name was not found in the table, leaving default UPC Name");
				//	}

				//}

				Delay.Seconds(0.5);
				IWebElement productNameOnlabelObj = container.FindElement(By.XPath(".//label[contains(text(),'Product Name on Label')]/.."), 2);
				
				if (productNameOnlabelObj == null)
				{
					return false;
				}

				string productNameDataBind = productNameOnlabelObj.GetAttribute("class");
				if (productNameDataBind != null)
				{
					if (!productNameDataBind.Contains("form-group has-success"))
					{
						upcNameField.EnterText("UPCName PlaceHolder");
						Report.Failure("The UPC Name Field was empty, entered PlaceHolder text");
					}
					else
					{
						Report.Info("The Field was not empty, Checking for UPCName in the table");
						if (!info.UPCName.IsNullOrEmpty())
						{
							if (info.UPCName.ToLower().Contains("saved as"))
							{
								try
								{
									string savedUPC = Context
										.GetFromContext(info.UPCName.Replace("saved as", "", StringComparison.InvariantCultureIgnoreCase).Trim())
										.ToString();
									info.UPCName = savedUPC;
								}
								catch (Exception e)
								{
									Report.Info("Failed to find saved item in context: " + info.UPCName.Replace("saved as", "", StringComparison.InvariantCultureIgnoreCase) + e.Message);
									throw;
								}

							}

							upcNameField.EnterText(info.UPCName);
						}
						else
						{
							Report.Info("UPC Name was not found in the table, leaving default UPC Name");
						}
					}
				}
				else
				{
					Report.Failure("The UPC Name field was not present");
				}







				Delay.Seconds(0.5);

				IWebElement containsType = container.FindElement(By.XPath(".//select[contains(@data-bind,'Container Type')]"), 2);
				
				if (containsType == null)
				{
					return false;
				}
				if (info.ContainerType == "<first>")
				{
					IWebElement firstOption = containsType.FindElement(By.XPath("./option[not(text()='Container Type')]"), 1);

					if (firstOption == null)
					{
						Report.Failure("There are no Container Types");
						return false;
					}
					else
					{
						string firstOptionStr = firstOption.Text;
						containsType.Select(firstOptionStr);
					}


				}
				else
				{
					containsType.Select(info.ContainerType);
				}

				string regex = @"(.*)\((.*)\)";
				IWebElement sizeField = (from input in textInputs
										 let match = Regex.Match(input.GetAttribute("placeholder"), regex)
										 where match.Success && match.Groups[1].Value.StartsWith("Size") && match.Groups[2].Value.Contains("Ounces")
										 select input).FirstOrDefault();
				if (sizeField == null)
				{
					Report.Info(@"Failed to find 'Size' input in the format ""Size (.. Ounces)""");
					return false;
				}
				sizeField.EnterText(info.Size);
				Delay.Seconds(0.5);
				if (info.Quantity.Length > 0)
				{
					IWebElement quantityField = container.FindElement(By.XPath(".//input[@placeholder='Quantity of Units within the Case']"), 2);
					
					if (quantityField == null)
					{
						return false;
					}
					quantityField.EnterText(info.Quantity);
				}

				if (info.IndividualUpcCasePack.ToLower().Contains("saved as"))
				{
					try
					{
						var savedUPC = Context
							.GetFromContext(info.IndividualUpcCasePack.Replace("saved as", "", StringComparison.InvariantCultureIgnoreCase).Trim())
							.ToString();
						info.IndividualUpcCasePack = savedUPC;
					}
					catch (Exception e)
					{
						Report.Info("Failed to find saved item in context: " + info.IndividualUpcCasePack.Replace("saved as", "", StringComparison.InvariantCultureIgnoreCase) + e.Message);
						throw;
					}

				}
				Delay.Seconds(0.5);
				if (info.IndividualUpcCasePack.Length > 0)
				{
					IWebElement packageField = container.FindElement(By.XPath(".//select[contains(@data-bind,'upcContained.field')]"), 2);
					
					if (packageField == null)
					{
						return false;
					}
					packageField.Select(info.IndividualUpcCasePack);
				}
				Delay.Seconds(0.5);
				if (info.TransportationOption.Length > 0)
				{
					IWebElement packageField = container.FindElement(By.XPath(".//select[contains(@data-bind,'transport.field')]"), 2);
					if (info.TransportationOption.ToLower().Contains("random"))
					{
						var packageOptions = packageField.FindElements(By.XPath(".//option"), 2).Select(x => x.GetValue()).ToList();
						var r = new Random();
						int rInt = r.Next(0, packageOptions.Count - 1);
						packageField.Select(packageOptions[rInt]);
					}
					else if (info.TransportationOption == "<first>")
					{
						var firstOption = packageField.FindElement(By.XPath("./option[not(text()='Transportation Options')]"), 1).Text;

						if (firstOption == null)
						{
							Report.Failure("There are no Transportation Options");
							return false;
						}
						else
						{
							packageField.Select(firstOption);
						}

					}

					else
					{
						packageField.Select(info.TransportationOption);
						GeneralUtilities.TrySelect(packageField, info.TransportationOption, true);
					}
				}
				return true;
			}
			catch (Exception ex)
			{
				Report.Info(ex.Message);
				return false;
			}
		}


		public List<string> UpcPageLinks()
		{
			var linksText = new List<string>();
			linksText = this.ContainerElement.FindElements(By.XPath(".//div[@class='alert alert-info']//a"), 2).Select(x => x.Text).ToList();
			return linksText;
		}

		public List<string> GetUPCErrorsForSection(string section)
		{
			string xPath = @"(.//p[(.//ancestor::p[@class='form-error']) and (.//ancestor::div[starts-with(@class, 'form-group has-error')]//label[@class='sr-only'][contains(text(),""" + section + @""")])] | " +
						@".//p[(.//ancestor::p[@class='form-error']) and (.//ancestor::div[starts-with(@class, 'form-group has-error')]//select[@class='form-control']//option[contains(text(),""" + section + @""")])])";
			IList<IWebElement> el = this.ContainerElement.FindElements(By.XPath(xPath), 10);
			return el.Count == 0 ? new List<string>() : el.Select(x => x.Text).ToList();
		}

		public bool GetUPCErrorForSection(string section, string expectedMessage, out string displayedMessage)
		{
			string xPath = @"(.//p[(.//ancestor::p[@class='form-error']) and (.//ancestor::div[starts-with(@class, 'form-group has-error')]//label[@class='sr-only'][contains(text(),""" + section + @""")])] | " +
						@".//p[(.//ancestor::p[@class='form-error']) and (.//ancestor::div[starts-with(@class, 'form-group has-error')]//select[@class='form-control']//option[contains(text(),""" + section + @""")])])";
			IWebElement el = this.ContainerElement.FindElement(By.XPath(xPath), 10);
			if (el == null)
			{
				displayedMessage = "** No error message was displayed in section " + section + " **";
				return false;
			}
			else
			{
				displayedMessage = el.Text;
				return expectedMessage == displayedMessage;
			}
		}


		public bool SelectRadio(string section, string value)
		{
			string xPath = @"//span[(.//ancestor::div[starts-with(@class,'form-group')]//label[starts-with(text(),""" + section + @""")]) and contains(text(),'" + value + "') and (./preceding-sibling::input[@type='radio'])]";
			IWebElement el = this.ContainerElement.FindElement(By.XPath(xPath), 2);
			if (el != null)
			{
				return el.TryClick();
			}
			Report.Error("Could not find the correct input in section: " + section);
			return false;
		}

		internal bool VerifySampleFile(Table table, string fileName, string savedAs)
		{
			this.GetFile(fileName, savedAs);
			var actualFile = Context.GetFromContext(savedAs);
			List<string> fileData = GetFileData(savedAs, actualFile);

			var tableData = new List<string>();
			tableData.AddRange(table.Header);
			foreach (TableRow row in table.Rows)
			{
				var vals = row.RowValuesFromContext();

				tableData.AddRange(vals.ToList());
			}

			if (tableData is null || fileData is null)
			{
				Report.Failure("Either the table is empty or the file: '" + fileName + "' is not being read.");
				return false;
			}

			for (int i = 0; i < tableData.Count; i++)
			{
				//if (tableData[i].Trim() != fileData[i].Trim())
				string t1 = tableData[i];
				string t2 = fileData[i];
				t1 = Regex.Replace(t1, @"\s+", "");
				t2 = Regex.Replace(t2, @"\s+", "");
				if (t1 != t2)
				{
					Report.Info("Error: Table Data contains: " + tableData[i] + " while File Data contains: " + fileData[i] + " in row " + i);
					return false;
				}
			}
			return true;
		}

		public List<string> GetFileData(string savedAs, object actualFile)
		{
			Report.Info("Confirm the excel file saved as " + savedAs + " can be opened and contains data");
			if (Report.IsTrue(actualFile != null, "No matching file was found for name: " + savedAs + "!", "File was found: " + actualFile.ToString()))
			{
				var ExcelUtils = new ExcelFunctions(actualFile.ToString(), "Sheet1");
				Report.Info("Found: " + ExcelUtils.Excel_GetNoRows() + " rows in the spreadsheet");
				List<string> FirstRow = ExcelUtils.Excel_GetRow(0);
				Report.Info("Header row contained: '" + string.Join("', '", FirstRow) + "'");

				var list = new List<string>();

				for (int i = 0; i < ExcelUtils.Excel_GetNoRows(); i++)
				{
					list.AddRange(ExcelUtils.Excel_GetRow(i));
				}
				Report.IsTrue(list != null, "Excel did not contain any product data!", "Excel file contained product data, as expected!");
				return list;
			}
			return null;
		}

		public void GetFile(string file, string savedAs)
		{
			Report.Info("Confirm Excel file is downloaded with name: " + file);
			
			string downloadsFolder = SeleniumWebDriver.Interface.DownloadsFolder; 
			Report.Info("Downloads folder: " + downloadsFolder);
			int counter = 0;
			while (counter <= 15)
			{
				string[] dir = Directory.GetFiles(downloadsFolder, "*" + file.Replace("<Date>", "*"), SearchOption.AllDirectories);
				if (dir.Any())
				{
					Context.AddToContext(savedAs, dir.FirstOrDefault());
					Report.Success("File with name: " + dir.FirstOrDefault() + " was found successfully!");
					Report.Info("Waited for: " + counter + " seconds");
					return;
				}
				Delay.Seconds(1);
				counter++;
			}
			Report.Failure("No file was found with name " + file);

		}

		internal bool DeleteValueInField(string field)
		{
			string str = "//input[@placeholder='" + field + "']";
			IWebElement el = this.FindElement(By.XPath(str), 2);
			bool thing = el.TryEnterText("");
			return thing;
		}

		public string GetErrorText()
		{
			string text = "";
			IWebElement foundText = this.ContainerElement.FindElement(By.XPath("//ul[@class='form-error']//li"), 2);
			if (foundText != null)
			{
				text = foundText.Text;
			}
			return text;
		}
		public bool ClickUploadUpcButton()
		{
			IWebElement el = this.ContainerElement.FindElement(By.XPath(".//div[contains(@class,'upc-dropzone')]//button"), 2);
			if (el == null)
			{
				return false;
			}

			return el.TryClick();
		}

		public class UPCNewProduct
		{
			public bool IsChecked { get; set; }
			public string UpcNumber { get; set; }
			public string ContainerType { get; set; }
			public string Size { get; set; }
			public string Retailer { get; set; }
			public bool WarningIsPresent { get; set; }


		}

		public List<UPCNewProduct> UPCsNewProduct {

			get
			{
				var listOfUPCNewProducts = new List<UPCNewProduct>();
				IWebElement ThisTable = this.ContainerElement.FindElement(By.XPath(".//table[@class='table table-hover upc-table']"), 2);
				List<KeyValuePair<int, string>> th = this.TableHeaders(ThisTable); //?
				ReadOnlyCollection<IWebElement> listOfRows = ThisTable.FindElements(By.XPath(".//tbody//tr"));
				int isCheckedIndex = th.FirstOrDefault(x => x.Value == "").Key;
				int upcNumberIndex = th.FirstOrDefault(x => x.Value.Contains("UPC")).Key;
				int retailerIndex = th.FirstOrDefault(x => x.Value.Contains("Destination Retailers")).Key;
				int warningIsPresentIndex = th.FirstOrDefault(x => x.Value.Contains("Destination Retailers")).Key;
				foreach (IWebElement thisRow in listOfRows)
				{
					bool isChecked = thisRow.FindElement(By.XPath($".//td[{isCheckedIndex.ToString()}]//input"), 2).Selected;
					string upcNumber = thisRow.FindElement(By.XPath($".//td[{upcNumberIndex.ToString()}]/span[contains(@data-bind,'upc')]"), 2).Text;
					string containerType = thisRow.FindElement(By.XPath($".//td[{upcNumberIndex.ToString()}]/span[contains(@data-bind,'type')]"), 2).Text;
					string size = thisRow.FindElement(By.XPath($".//td[{upcNumberIndex.ToString()}]/span[contains(@data-bind,'size')]"), 2).Text;
					string retailer = thisRow.FindElement(By.XPath($".//td[{retailerIndex.ToString()}]//span[@data-bind='text: identifier']"), 2).Text;
					bool warningIsPresent = thisRow.FindElement(By.XPath($".//td[{warningIsPresentIndex.ToString()}]//i[@title='This GTIN/UPC is duplicated.']"), 2).Displayed;
					listOfUPCNewProducts.Add(new UPCNewProduct() { IsChecked = isChecked, UpcNumber = upcNumber, ContainerType = containerType, Size = size, Retailer = retailer, WarningIsPresent = warningIsPresent });
				}
				return listOfUPCNewProducts;
			}


		}

		public class UPCBoxNumber
		{
			public IWebElement CheckBox { get; set; }
			public string UpcNumber { get; set; }
		}

		public List<UPCBoxNumber> UPCSelectionBoxes {

			get
			{

				var listofUPCcheckboxes = new List<UPCBoxNumber>();
				IWebElement thisTable = this.ContainerElement.FindElement(By.XPath(".//table[@class='table table-hover upc-table']"), 2);
				List<KeyValuePair<int, string>> th = this.TableHeaders(thisTable); //?
				ReadOnlyCollection<IWebElement> listOfRows = this.ContainerElement.FindElements(By.XPath(".//table[@class='table table-hover upc-table']//tbody//tr"));
				int checkboxIndex = th.FirstOrDefault(x => x.Value == "").Key;
				int upcNumberIndex = th.FirstOrDefault(x => x.Value.Contains("UPC")).Key;
				foreach (IWebElement thisRow in listOfRows)
				{
					IWebElement checkBox = thisRow.FindElement(By.XPath(".//td[" + checkboxIndex.ToString() + "]//input"), 2);
					string upcNumber = thisRow.FindElement(By.XPath(".//td[" + upcNumberIndex.ToString() + "]/span[contains(@data-bind,'upc')]"), 2).Text;
					listofUPCcheckboxes.Add(new UPCBoxNumber() { CheckBox = checkBox, UpcNumber = upcNumber });
				}
				return listofUPCcheckboxes;

			}

		}




		public bool UploadUpcButton()
		{
			IWebElement el = this.ContainerElement.FindElement(By.XPath(".//div[contains(@class,'upc-dropzone')]//button"), 2);
			if (el == null)
			{
				return false;
			}

			return true;
		}

		public IWebElement UPCButtonContainerGeneral => ContainerElement.FindElement(By.XPath("//div[@class='col-md-12 formulation-grid upc-grid']//div[contains(@class,'upc-buttons')]"), 2);
		public IWebElement UPCButtonContainerTop => ContainerElement.FindElement(By.XPath("//div[@class='col-md-12 formulation-grid upc-grid']//div[@class='upc-buttons affix-top']"), 2);
		public IWebElement UPCButtonContainerBottom => ContainerElement.FindElement(By.XPath("//div[@class='col-md-12 formulation-grid upc-grid']//div[@class='upc-buttons affix']"), 2);

		public bool ClickDeleteRowsButton()
		{
			IWebElement el = this.ContainerElement.FindElement(By.XPath(".//button[contains(@class,'danger')]"), 2);
			if (el == null)
			{
				return false;
			}

			return el.TryClick();
		}

		public string GetFirstUPCInList()
		{
			IWebElement upcEl = this.ContainerElement.FindElement(By.XPath(@"//table//td//span"), 2);
			return upcEl.Text;
		}


		public bool DeleteRetailer(string retailer)
		{
			var abbr = new RetailerAbbreviations();
			string selectedAbbr = "";
			abbr.Map.TryGetValue(retailer, out selectedAbbr);

			IWebElement container = this.ContainerElement.FindElement(By.XPath(".//table[@class='table table-hover upc-table']"), 2);
			IWebElement retailerXElem = container.FindElement(By.XPath(@"//span[contains(text(), """ + selectedAbbr + @""")]/../a"), 2);

			return retailerXElem.TryClick();
		}

		public bool EnterDPCI(string value)
		{
			IWebElement input = this.ContainerElement.FindElement(By.XPath(".//label[contains(text(), 'DPCI Number')]/following-sibling::input"), 2);
			return input.TryEnterText(value);
		}

		public bool CheckForAlertWithThisTextInUPCPage(string alertText)
		{
			IList<IWebElement> AlertMessagesWithSpanTag = this.FindElements(By.XPath(".//span[@data-bind='text: $data']"), 2);
			IList<IWebElement> AlertMessagesWithliTag = this.FindElements(By.XPath(".//li[@data-bind='visible:$.trim($data).length > 0, text: $data']"), 2);

			if (alertText == "No error")
			{
				if ((AlertMessagesWithSpanTag.Count() == 0) && (AlertMessagesWithliTag.Count() == 0))
				{
					return true;
				}
			}

			foreach (IWebElement element in AlertMessagesWithSpanTag)
			{
				if (element.Text == alertText)
				{
					return true;
				}
			}

			foreach (IWebElement element in AlertMessagesWithliTag)
			{
				if (element.Text == alertText)
				{
					return true;
				}
			}

			return false;
		}

		public bool ClickContinueButtonInUPCPage()
		{
			IWebElement ContinueButton = this.FindElement(By.XPath(".//a[@class='btn btn-success pull-right continue-button next-button']"), 2);
			return ContinueButton.TryClick();
		}

		public bool ClickYesOrNoForUPCWarningPopUp(string yesOrNoButton, string savedAs)
		{
			if (yesOrNoButton == "YES")
			{
				IList<IWebElement> ListOfRemainingAbreviatedRetailerNames = this.FindElements(By.XPath(".//span[@data-bind='text: identifier']"), 2);
				List<string> ListOfRemainingRetailerNamesInTextForm = new List<string>();

				foreach (IWebElement element in ListOfRemainingAbreviatedRetailerNames)
				{
					ListOfRemainingRetailerNamesInTextForm.Add(element.Text);
				}

				string strOfRemainingRetailerNames = string.Join(",", ListOfRemainingRetailerNamesInTextForm);
				Context.AddToContext("ListOfRemainingRetailerNamesInTextForm", strOfRemainingRetailerNames);

				string id = "";

				try
				{
					var productToSearch = (ProductGridItem)Context.GetFromContext(savedAs);
					id = productToSearch.ProductId;
				}
				catch (Exception)
				{
					//do nothing
				}

				//if we didn't get the id try a different object type
				if (id == "")
				{
					try
					{
						var productDetails = (ProductInformation)Context.GetFromContext(savedAs);
						id = productDetails.Id;
					}
					catch (Exception)
					{
						//do nothing
					}

				}

				if (id == "")
				{
					try
					{
						id = Context.GetFromContext(savedAs).ToString();
					}
					catch (Exception)
					{

					}
				}

				Context.AddToContext("ProductID", id);

				IWebElement YesButton = this.FindElement(By.XPath(".//div[@class='modal fade in']//button[@data-dismiss='modal' and text()='No']/following-sibling::button"), 2);
				return YesButton.TryClick();

			}
			else if (yesOrNoButton == "NO")
			{

				IWebElement NoButton = this.FindElement(By.XPath(".//div[@class='modal fade in']//button[@data-dismiss='modal' and text()='No']"), 2);
				return NoButton.TryClick();

			}

			return false;
		}

        public bool ClickFirstUPCTab()
        {
            //new NewProduct().WaitForTab(NewProduct.Tab.RecipientAndUpcDetails,60);
            IWebElement expandArrowLink = this.ContainerElement.FindElement(By.XPath(".//form//table[contains(@class,'upc-table')]//a[@title='Expand']"), 2);
            return expandArrowLink.TryClick();
        }

        public bool IsFirstUPCTabOpen()
        {
			//new NewProduct().WaitForTab(NewProduct.Tab.RecipientAndUpcDetails,60);
			IWebElement expandArrow = this.ContainerElement.FindElement(By.XPath(".//form//table[contains(@class,'upc-table')]//a[@title='Expand']//em"), 2);

			if (expandArrow == null)
			{
				return false;
			}
			return expandArrow.GetAttribute("class").Contains("down");
        }

        public bool CheckForErrorUnderneathIndividualUPCContainedInCasePackField()
		{
			IWebElement IndividualUPCContainerFieldError = this.FindElement(By.XPath(".//option[text()='Individual UPC contained in the Case Pack']/../following-sibling::p//span[text()='This is a required field.']"), 2);
			
			if (IndividualUPCContainerFieldError == null)
			{
				return false;
			}

			if (IndividualUPCContainerFieldError != null)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public bool ClickAddCaseUPCButton()
		{
			IWebElement AddCaseUPCButton = this.FindElement(By.XPath(".//button[text()='Add Casepack ']"), 2);

			return AddCaseUPCButton.TryClick();
		}

		public void CheckIfTextfieldsWithPlaceholdersDisplayTheError(Table table)
		{
			List<string> ListOfTextFieldsThatDisplayedTheError = new List<string>();

			foreach (TableRow row in table.Rows)
			{
				IWebElement TextField = this.FindElement(By.XPath(".//*[@placeholder='" + row["Placeholder"] + "']/..//span[text()='This is a required field.']"), 2);
				
				if (TextField == null)
				{
					ListOfTextFieldsThatDisplayedTheError.Add(row["Placeholder"]);
				}
			}

			if (ListOfTextFieldsThatDisplayedTheError.Count() > 0)
			{
				Report.Failure("The following textfields: " + ListOfTextFieldsThatDisplayedTheError.ToString() + " did not display the error messages they were supposed to.");
				return;
			}

			Report.Success("All textfields in the table displayed their proper error messages");
			return;
		}

		public bool CheckIfDropDownsWithDefaultOptionDisplayTheError(Table table)
		{
			foreach (TableRow row in table.Rows)
			{
				IWebElement TextField = this.FindElement(By.XPath(".//option[text()='" + row["Default Option"] + "']/../following-sibling::p//span[text()='This is a required field.']"), 2);
				if (TextField == null)
				{
					return false;
				}
			}

			return true;
		}

		public string GetExpandedUPC()
		{
			IWebElement upcField = this.ContainerElement.FindElement(By.XPath($".//label[contains(text(),'UPC Number')]/following-sibling::input"), 2);
			
			if (upcField == null)
			{
				return null;
			}
			return upcField.GetValue();
		}

		public string GetValueOfRetailerFieldInActiveRow(string retailerID, string field)
		{
			IWebElement retailerField = this.ContainerElement.FindElement(By.XPath($".//span[text()='{retailerID}']//..//..//label[contains(text(),'{field}')]/following-sibling::input"), 2);
			
			if (retailerField == null)
			{
				return null;
			}
			return retailerField.GetValue();
		}

		public string GetTextOfRetailerLabelInActiveRow(string retailerID, string field)
		{
			IWebElement labelText = this.ContainerElement.FindElement(By.XPath($".//span[text()='{retailerID}']//..//..//label[contains(text(),'{field}')]"),2);
			if (labelText == null)
			{
				Report.Info($"error: {field} label for retailer {retailerID} does not exist");
				return "";
			}
			else
			{
				return labelText.Text;
			}
		}


		public bool IsRequiredValueOfRetailerInActiveRow(string retailerID, string field)
		{
			IWebElement isRequiredLabel = this.ContainerElement.FindElement(By.XPath($".//span[text()='{retailerID}']//..//..//label[contains(text(),'{field}')]//..//p[@class='form-error']"), 2);
			
			if (isRequiredLabel == null)
			{
				return false;
			}
			return isRequiredLabel.Displayed;
		}

		public bool ClickCloseInPopupWithTitle(string title)
		{
			IWebElement continueButton = this.ContainerElement.FindElement(By.XPath("//h4[text()='" + title + "']/../following-sibling::div[@class='modal-footer']//button"), 2);
			return continueButton.TryClick();
		}

		public bool CheckDeleteRowsWarningPopupContainsText(string lineOne, string lineTwo)
		{

			IWebElement lineOneEl = this.ContainerElement.FindElement(By.XPath("//h4[text()='Warning!']/../..//div[@class='modal-body']//p[1]"), 2);
			IWebElement lineTwoEl = this.ContainerElement.FindElement(By.XPath("//h4[text()='Warning!']/../..//div[@class='modal-body']//p[2]"), 2);
			
			if (lineOneEl == null)
			{
				Report.Error("Could not find first p element");
				return false;
			}
			if (lineTwoEl == null)
			{
				Report.Error("Could not find second p element");
				return false;
			}
			if (lineOneEl.Text == lineOne && lineTwoEl.Text == lineTwo)
			{
				return true;
			}

			return false;
		}

		public new bool ConfirmTruckIconIsDisplayedForUPC(string savedAs)
		{
			IWebElement truckIcon = this.ContainerElement.FindElement(By.XPath("//span[@data-bind='text: upcNumber.field'][text()='" + savedAs + "']/following-sibling::i"), 2);
			if (truckIcon != null)
			{
				return true;
			}

			return false;
		}

	}

	public class DeleteRowsWarning : SeleniumBaseObject
	{
		protected override By ContainerElementLocator => By.XPath(@"//div[@class='modal-dialog modal-md']//div[@class='modal-content']");
		public IWebElement DeleteRowsWarningPopupOkButton => this.ContainerElement.FindElement(By.XPath("//button[text()='Ok']"), 2);
		public IWebElement DeleteRowsWarningPopupCancelButton => this.ContainerElement.FindElement(By.XPath("//button[text()='Cancel']"), 2);

	}


	public class MultipleUPC : SeleniumBaseObject
	{
		protected override By ContainerElementLocator => By.XPath(@"//h4[@class='modal-title' and contains(text(),'Add Multiple')]/ancestor::div[@class='modal-content']");

		public IWebElement SelectAllUpcsButton => this.ContainerElement.FindElement(By.XPath("//tr//th//input[@type='checkbox' and contains(@data-bind,'areAllRowsSelected')]"), 2);
		public IWebElement ContainsType => this.ContainerElement.FindElement(By.XPath(".//select[contains(@data-bind,'packagingChanged')]"), 2);
		public IWebElement NextButton => this.ContainerElement.FindElement(By.XPath("//button[@type='button' and text()='Next']"), 2);
		public IWebElement SelectAllRetailersButton => this.ContainerElement.FindElement(By.XPath("//tr//th//input[@type='checkbox' and contains(@data-bind,'retailers')]"), 2);
		public IWebElement SelectXRetailersButton => this.ContainerElement.FindElement(By.XPath("//tr//th//input[@type='checkbox' and contains(@data-bind,'retailers')]"), 2);
		public IWebElement FinishButton => this.ContainerElement.FindElement(By.XPath("//button[@type='button' and text()='Finish']"), 2);
		public IWebElement RetailerCheckbox(string retailer) => this.ContainerElement.FindElement(By.XPath($"//tr[td//span[text()='{retailer}']]//input"), 2);
		List<IWebElement> ListOfRows => this.ContainerElement.FindElements(By.XPath(".//tr[td//span[contains(@data-bind, 'upc')]]"),2).ToList();
		public bool RetailerExists(string retailer)
		{
			return this.RetailerCheckbox(retailer) != null;
		}
		public bool SelectRetailer(string retailer)
		{
			return this.RetailerCheckbox(retailer).TryClick();
		}
		public bool SelectedRetailer(string retailer)
		{
			return this.RetailerCheckbox(retailer).Selected;
		}
		public bool ClickSelectAllUpcsButton()
		{
			return this.SelectAllUpcsButton.TryClick();
		}
		public bool ClickNextButton()
		{
			return this.NextButton.TryClick();
		}
		public bool ClickSelectAllRetailersButton()
		{
			return this.SelectAllRetailersButton.TryClick();
		}
		public bool ClickFinishButton()
		{
			return this.FinishButton.TryClick();
		}
		public bool AllUpcCheckboxSelected()
		{
			return this.SelectAllUpcsButton.Selected;
		}
		public bool CheckRetailerValueForEachRow(string value)
		{
			bool result = true;
			if(this.ListOfRows == null)
			{
				Report.Info("Cannot find any rows in the 'Add Multiple' table");
				return false;
			}
			foreach (IWebElement element in this.ListOfRows)
			{
				IWebElement Retailer = element.FindElement(By.XPath(".//td//span[contains(@data-bind, 'clients')]"),2);
				string getRetailer = Retailer.Text;
				if (getRetailer != value)
				{
					result = false;
				}
			}
			return result;

		}

		public bool CheckAllUPCsAreSelected()
		{
			var multipleUPCModal = new MultipleUPC();
			IList<IWebElement> checkUPCBoxList = multipleUPCModal.FindElements(By.XPath("//td//input[@type='checkbox']"), 2);
			IList<IWebElement> upcList = multipleUPCModal.FindElements(By.XPath("//td//span[@data-bind='text: row.upc']"), 2);
			int i = 0;
			foreach (var item in checkUPCBoxList)
			{
				if (!item.Selected)
				{
					Report.Info("The Checkbox Next to UPC Number: " + upcList[i] + " was not checked");
					return false;
				}
				i++;
			}
			return true;
		}

		public bool CheckUPCNumberOfEachProductFromFile(string file, string savedAs)
		{
			new UPC().GetFile(file, savedAs);
			var actualFile = Context.GetFromContext(savedAs);
			List<string> fileData = new UPC().GetFileData(savedAs, actualFile);

			var multipleUPCModal = new MultipleUPC();

			if (fileData is null)
			{
				Report.Failure("either the table is empty or the file: '" + file + "' is not being read.");
				return false;
			}

			IList<IWebElement> upcList = multipleUPCModal.FindElements(By.XPath("//td//span[@data-bind='text: row.upc']"), 2);
			int i = 11;
			foreach (var item in upcList)
			{
				string UPCnumber = item.Text;
				if (UPCnumber != fileData[i].Trim())
				{
					Report.Info("error: popup contains: " + UPCnumber + "while file data contains: " + fileData[i] + " in row " + i);
					return false;
				}
				i = i + 11;
			}
			return true;
		}
		public bool CheckSizeOfEachProductFromFile(string file, string savedAs)
		{
			new UPC().GetFile(file, savedAs);
			var actualFile = Context.GetFromContext(savedAs);
			List<string> fileData = new UPC().GetFileData(savedAs, actualFile);

			var multipleUPCModal = new MultipleUPC();

			if (fileData is null)
			{
				Report.Failure("either the table is empty or the file: '" + file + "' is not being read.");
				return false;
			}

			IList<IWebElement> sizeList = multipleUPCModal.FindElements(By.XPath(".//td//span[@data-bind='text: row.size']"), 2);
			int i = 13;
			foreach (var item in sizeList)
			{
				string sizeValue = item.Text;
				if (sizeValue != fileData[i].Trim())
				{
					Report.Info("error: popup contains: " + sizeValue + "while file data contains: " + fileData[i] + " in row " + i);
					return false;
				}
				i = i + 11;
			}
			return true;
		}

		public bool CheckValueOfEachProductFromFile(string value, string file, string savedAs)
		{
			//may need fixing to adapt the offset value(currently 21)
			new UPC().GetFile(file, savedAs);
			var actualFile = Context.GetFromContext(savedAs);
			List<string> fileData = new UPC().GetFileData(savedAs, actualFile);

			var multipleUPCModal = new MultipleUPC();

			if (fileData is null)
			{
				Report.Failure("either the table is empty or the file: '" + file + "' is not being read.");
				return false;
			}

			string valueDataBindString = "";
			int offset = 0;
			switch (value.ToLower())
			{
				case "upc":
					valueDataBindString = "row.upc";
					break;

				case "size":
					valueDataBindString = "row.size";
					offset = 2;
					break;
			}

			IList<IWebElement> upcList = multipleUPCModal.FindElements(By.XPath($".//td//span[@data-bind='text: {valueDataBindString}']"), 2);
			int i = 21 + offset;
			foreach (var item in upcList)
			{
				string UPCnumber = item.Text;
				if (UPCnumber != fileData[i].Trim())
				{
					Report.Info("error: popup contains: " + UPCnumber + "while file data contains: " + fileData[i] + " in row " + i);
					return false;
				}
				i = i + 21;
			}
			return true;
		}

		public bool CheckValueOfEachRetailerProductFromFile(string value, string retailer, string file, string savedAs)
		{
			new UPC().GetFile(file, savedAs);
			object actualFile = Context.GetFromContext(savedAs);
			List<string> fileData = new UPC().GetFileData(savedAs, actualFile);

			var multipleUPCModal = new MultipleUPC();

			if (fileData is null)
			{
				Report.Failure("either the table is empty or the file: '" + file + "' is not being read.");
				return false;
			}

			string spanDataBind = "";
			int offset = 0;
			switch (value)
			{
				case "Item Number":
					spanDataBind = "text: row.getAdditionalDataValue(identifier(), 1)";
					break;
				case "Part Number":
					spanDataBind = "text: row.getAdditionalDataValue(identifier(), 0)";
					break;
				case "DPCI":
					//spanDataBind = value;
					spanDataBind = "text: row.getAdditionalDataValue(identifier(), 2)";
					break;
				case "OMSID":
					//spanDataBind = value;
					spanDataBind = "text: row.getAdditionalDataValue(identifier(), 3)";
					if (spanDataBind == null)
					{
						return false;
					}
					break;
			}
			var headerTextList = multipleUPCModal.FindElements(By.XPath($".//div[@class='col-md-8 upc-list-container']//th"), 2).Select(x => x.Text).ToList<string>();
			int retailerIndex = headerTextList.IndexOf($"{retailer}");

			if (retailerIndex == -1)
			{
				Report.Info("error: retailer not in header");
				return false;
			}

			string retailerAbbr = new RetailerAbbreviations().TryConvertToAbbreviation($"{retailer}");
			offset = fileData.FindIndex(x => x.Equals($"{retailerAbbr}: {value}"));

			//List<IWebElement> wantedCells = multipleUPCModal.FindElements(By.XPath($".//td[{retailerIndex + 1}]"), 2).ToList();

			////IList<IWebElement> valueList = multipleUPCModal.FindElements(By.XPath($".//td[{retailerIndex + 1}]"), 2);

			int q = 0;
			bool finalHeaderFound = false;
			foreach(var el in fileData)
			{
				int y = 0;
				var isNumeric = Regex.IsMatch(el, @"^\d+$");
				if (el.Length==12 && isNumeric)
				{
					finalHeaderFound = true;
					break;
				}
				q++;
			}
			if(finalHeaderFound==false)
			{
				Report.Info("Was not able to find the number of headers, could not find the first UPC number in the file data");
				return false;
			}
			IList <IWebElement> valueList = multipleUPCModal.FindElements(By.XPath($".//td[{retailerIndex + 1}]//span[@data-bind='{spanDataBind}']"), 2);
			int i = q + offset;

			if (valueList.Count == 0)
			{
				Report.Info($"error: value {value} does not exist for retailer {retailer}");
				return false;
			}

			foreach (IWebElement item in valueList)
			{
				string valueString = item.Text;
				var test = fileData[i].Trim();
				if (valueString != fileData[i].Trim())
				{
					Report.Info("error: popup contains: " + valueString + "while file data contains: " + fileData[i] + " in row " + i);
					return false;
				}
				i = i + q;
			}
			return true;
		}

		public bool CheckAllRetailersSelectedStatus()
		{
			return this.SelectAllRetailersButton.Selected;
		}

		public List<KeyValuePair<int, string>> TableHeaders(IWebElement table)
		{
			List<KeyValuePair<int, string>> th = new List<KeyValuePair<int, string>>(); //new List
			ReadOnlyCollection<IWebElement> listOfHeaders = table.FindElements(By.XPath(".//th"));
			for (int i = 0; i < listOfHeaders.Count; i++)
			{
				th.Add(new KeyValuePair<int, string>(i + 1, listOfHeaders[i].Text));
			}
			return th;
		}




		public class UPCUpload
		{
			public bool IsChecked { get; set; }
			public string UpcNumber { get; set; }
			public string ContainerType { get; set; }
			public string Size { get; set; }
			public string Retailer { get; set; }

		}
		public List<UPCUpload> UPCUploads {

			get
			{
				var listOfUPCUploads = new List<UPCUpload>();
				IWebElement thisTable = this.ContainerElement.FindElement(By.XPath(".//table[@style='overflow:auto;']"), 2);
				List<KeyValuePair<int, string>> th = this.TableHeaders(thisTable); //?
				ReadOnlyCollection<IWebElement> listOfRows = this.ContainerElement.FindElements(By.XPath(".//table[@style='overflow:auto;']//tbody//tr"));
				int isCheckedIndex = th.FirstOrDefault(x => x.Value == "").Key;
				int upcNumberIndex = th.FirstOrDefault(x => x.Value == "UPC").Key;
				int containerTypeIndex = th.FirstOrDefault(x => x.Value.Contains("Type")).Key;
				int sizeIndex = th.FirstOrDefault(x => x.Value.Contains("Size (Ounce)")).Key;
				int retailerIndex = th.FirstOrDefault(x => x.Value.Contains("Retailer")).Key;
				foreach (IWebElement thisRow in listOfRows)
				{
					bool isChecked = thisRow.FindElement(By.XPath(".//td[" + isCheckedIndex.ToString() + "]//input"), 2).Selected;
					string upcNumber = thisRow.FindElement(By.XPath(".//td[" + upcNumberIndex.ToString() + "]"), 2).Text;
					string containerType = thisRow.FindElement(By.XPath(".//td[" + containerTypeIndex.ToString() + "]"), 2).Text;
					string size = thisRow.FindElement(By.XPath(".//td[" + sizeIndex.ToString() + "]"), 2).Text;
					string retailer = thisRow.FindElement(By.XPath(".//td[" + retailerIndex.ToString() + "]"), 2).Text;
					listOfUPCUploads.Add(new UPCUpload() { IsChecked = isChecked, UpcNumber = upcNumber, ContainerType = containerType, Size = size, Retailer = retailer });
				}
				return listOfUPCUploads;
			}

		}






	}



	public class UpcCaseInformation
	{
		public string UpcNumber { get; set; } = "";
		public string ContainerType { get; set; } = "";
		public string Size { get; set; } = "";
		public string Quantity { get; set; } = "";
		public string IndividualUpcCasePack { get; set; } = "";
		public string TransportationOption { get; set; } = "";
		public string UPCName { get; set; } = "";
	}


}
