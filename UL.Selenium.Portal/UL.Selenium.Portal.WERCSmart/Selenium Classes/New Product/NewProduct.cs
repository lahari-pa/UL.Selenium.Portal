using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Castle.Components.DictionaryAdapter;
using Castle.Core.Internal;
using NTTQA.Selenium.BaseClasses;
using NTTQA.Selenium.Classes;
using NTTQA.Selenium.ExtensionMethods;
using NTTQA.Selenium.UniversalFunctions;
using NTTQA.Selenium.Reporting.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using NTTQA.Selenium.SpecFlow;
using System.Collections.ObjectModel;


namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product
{
	public class NewProduct : SeleniumBaseObject
	{
		protected override By ContainerElementLocator => By.XPath("//div[@id='dataentry']");

		#region web elements
		private IWebElement Header => this.containerElement.FindElement(By.XPath(".//div[@class='product-header']/h2"), 5);

		private IWebElement ProgressBar => this.containerElement.FindElement(By.XPath(".//div[@class='prog-wizard']"), 5);

		private IWebElement ErrorMessage => this.containerElement.FindElement(By.XPath(".//p[@class='form-error']//span"), 1);

		private IEnumerable<IWebElement> ErrorMessages => this.containerElement.FindElements(By.XPath(".//p[@class='form-error']//span"), 1);

		private IWebElement ContinueButton => this.containerElement.WaitUntilElementClickable(By.XPath(".//a[contains(@class,'continue-button')]"), 5);

		private IEnumerable<IWebElement> PanelHeadings => this.containerElement.FindElements(By.XPath(".//div[@id='pgroup']/div/div[starts-with(@class,'panel-heading')]//h3"), 2);

		private By ActivePanelHeadingLocator(string text) => By.XPath($@".//div[@id='pgroup']/div/div[@class='panel-heading']//h3[contains(text(),""{text}"")]");

		private IWebElement ActivePanelHeading => this.containerElement.FindElement(By.XPath(".//div[@id='pgroup']/div/div[@class='panel-heading']//h3"), 2);

		private IEnumerable<IWebElement> SectionControlLabels => this.containerElement.FindElements(By.XPath(".//label[@class='control-label']"), 1);

		private IWebElement LabelContains(string lblContains) => this.containerElement.FindElement(By.XPath($@".//label[contains(text(),""{lblContains}"")]"), 1);

		private IWebElement BoldElementContains(string bContains) => this.containerElement.FindElement(By.XPath($@".//b[contains(text(),""{bContains}"")]"), 1);
		#endregion

		#region New Product general methods

		public string PanelTitle { get; }

		public string HeaderText => this.Header?.Text;

		public string ProductId {
			get
			{
				string headText = this.HeaderText;
				if (headText.IsNullOrEmpty())
				{
					return null;
				}
				MatchCollection matches = Regex.Matches(headText, @"\(\d*\)");
				if (matches.Count == 0)
				{
					return null;
				}
				string bracketedValue = matches[matches.Count - 1].Groups[0].Value;
				return bracketedValue.Trim().Substring(1, bracketedValue.Length - 2);
			}
		}

		private string ProductName => this.HeaderText.Replace("(" + this.ProductId + ")", "").Trim();

		public List<string> ErrorMessagesText => this.ErrorMessages.Select(x => x.Text).ToList();

		public string ErrorMessageText => this.ErrorMessage?.Text;

		public List<string> GetErrorsForSection(string section)
		{
			IList<IWebElement> els = this.containerElement.FindElements(By.XPath(@".//span[(.//ancestor::p[@class='form-error']) and (.//ancestor::div[starts-with(@class, 'form-group')]//label[starts-with(text(),""" + section + @""")])]"), 2);
			return els.Count == 0 ? new List<string>() : els.Select(x => x.Text).ToList();
		}

		public string GetErrorForSection(string section)
		{
			IWebElement el = this.containerElement.FindElement(By.XPath(@".//span[(.//ancestor::p[@class='form-error']) and (.//ancestor::div[starts-with(@class, 'form-group')]//label[starts-with(text(),""" + section + @""")])]"), 2);
			return el?.Text;
		}

		public List<InputError> GetAllErrors()
		{
			string regexPattern = @"(?:optionsCaption:\s*[\'\""])(.*)[\'\""]";

			System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> errorInputs = this.containerElement.FindElements(By.XPath("//p[@class='form-error' and not(contains(@style, 'none'))]/../input|//p[@class='form-error' and not(contains(@style, 'none'))]/../select"));

			var errorsList = new List<InputError>();
			foreach (IWebElement errorInput in errorInputs)
			{
				string errorString = errorInput
					.FindElement(By.XPath("./..//p[@class='form-error' and not(contains(@style, 'none'))]"), 2)
					.GetValue();
				string dataBind = errorInput.GetAttribute("data-bind");
				Match match = Regex.Match(dataBind, regexPattern);

				string inputTitle = "";


				inputTitle = match.Groups[1].Value;

				errorsList.Add(new InputError() { ErrorMessage = errorString, Input = errorInput, InputName = inputTitle });

			}

			return errorsList;
		}

		public bool ClickContinueNoError()
		{
			try
			{
				if (this.ContinueButton == null)
				{
					return false;
				}
				if (!this.ContinueButton.TryClick())
				{
					return false;
				}
				if (!GeneralUtilities.WaitForRefreshToDisappear(this.ContinueButton) && this.ErrorMessage != null)
				{
					return false;
				}
				GeneralUtilities.Wait_for_load_finish();
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public string[] ModifiedStrings(string character)
		{
			string[] outStrings = { character + " The Product Name", "The " + character + " Product Name", "The Product Name " + character, "The " + character + " Product " + character + " Name" };
			return outStrings;
		}

		public bool ClickContinue(bool waitForLoadingBtnSpinner = true)
		{
			try
			{
				if (this.ContinueButton == null)
				{
					Report.Error("Continue button was not found");
					return false;
				}
				if (!this.ContinueButton.TryClick())
				{
					Report.Error("Failed to click the contiue button");
					return false;
				}
				if (waitForLoadingBtnSpinner)
				{
					GeneralUtilities.WaitForRefreshToDisappear(this.ContinueButton);
				}
				return GeneralUtilities.Wait_for_load_finish() && this.DismissAjaxIfDisplayed();
			}
			catch (Exception)
			{
				return false;
			}
		}

		private bool DismissAjaxIfDisplayed()
		{
			int attempt = 0;
			bool ajax = true;
			while (attempt < 10 && ajax)
			{
				Report.Info("Attempt: " + attempt);
				if (!GeneralUtilities.AjaxPopupExists())
				{
					ajax = false;
				}
				else
				{
					Report.Error("Ajax error was displayed! Clicking Close.");
					if (!GeneralUtilities.CloseAjaxPopup())
					{
						return false;
					}
					this.ContinueButton.TryClick();
					GeneralUtilities.WaitForRefreshToDisappear(this.ContinueButton);
					GeneralUtilities.Wait_for_load_finish();
					attempt++;
				}
			}
			return !ajax;
		}

		public bool WaitForSection(string sectionHeader, int secondsToWait = 60)
		{
			return this.containerElement.WaitUntilElementVisible(this.ActivePanelHeadingLocator(sectionHeader), secondsToWait) != null;
		}

		public bool ClickSection(string section)
		{
			IWebElement matchHeading = this.PanelHeadings.FirstOrDefault(x => x.Text.Contains(section));
			IWebElement sectionEl = matchHeading?.FindElement(By.XPath("./ancestor::a[position()=1]"), 1);
			return sectionEl != null && sectionEl.TryClick();
		}

		/// <summary>
		/// returns whether or not the active panel heading matches the 'PanelTitle' string for the NewProduct 'page' (step)
		/// </summary>
		public bool IsActivePanel => this.WaitForSection(PanelTitle);

		/// <summary>
		/// Waits until Tab (enum: ProductType, ProductCharacteristics...) is active in the progress bar during a timeout period
		/// Returns whether the tab is active
		/// </summary>
		public bool WaitForTab(Tab tab, int secondsToWait = 30)
		{
			string tabName = MapTabs[tab];
			return this.ProgressBar?.WaitUntilElementVisible(By.XPath($".//div[@class= 'prog-step in-progress active' and .//span[contains(text(),'{tabName}')]]"), secondsToWait) != null;
		}

		/// <summary>
		/// Clicks the Tab (enum: ProductType, ProductCharacteristics...)
		/// Returns whether the click was successful
		/// </summary>
		public bool ClickTab(Tab tab)
		{
			string tabName = MapTabs[tab];
			// if the tab is currently active, we don't need to click it
			IWebElement active = this.ProgressBar?.FindElement(By.XPath($".//div[contains(@class, 'in-progress active') and ./span[text()='{tabName}']]"), 2);
			if (active != null)
			{
				Report.Info($"Tab: {tabName} was already active");
				return true;
			}
			IWebElement tabEl = this.ProgressBar?.FindElement(By.XPath($".//div[contains(@class, 'prog-step')]//a/span[contains(text(),'{tabName}')]"), 2);
			if (tabEl == null)
			{
				return false;
			}
			Report.Info("Clicking tab: " + tabName);
			return tabEl.FindElement(By.XPath("../../a"), 5).TryClick();
		}

		public bool IsActiveTab(Tab tab)
		{
			string tabName = MapTabs[tab];
			IWebElement active = this.ProgressBar?.FindElement(By.XPath($".//div[contains(@class, 'in-progress active') and ./span[text()='{tabName}']]"), 2);
			return active != null;
		}

		public ProductInformation GetCurrentProductInformation()
		{
			return new ProductInformation { Id = this.ProductId, Name = this.ProductName };
		}

		public string TopSectionLabel()
		{
			return this.SectionControlLabels.FirstOrDefault()?.Text;
		}

		public bool SectionLogoDisplayed(string logo, int secondsToWait = 30)
		{
			return this.containerElement.WaitUntilElementVisible(By.XPath($".//div[@class='panel-heading']//h3/img[contains(@src,'{logo}')]"), secondsToWait) != null;
		}

		public string ActivePanelHeadingText()
		{
			return this.ActivePanelHeading?.Text;
		}

		public List<string> RadioButtons()
		{
			return this.containerElement.FindElements(By.XPath(".//form//input[@type='radio']/../span"), 2).Select(x => x.Text.Trim()).ToList();
		}

		public List<string> Checkboxes()
		{
			return this.containerElement.FindElements(By.XPath(".//form//input[@type='checkbox']/../span"), 2).Select(x => x.Text.Trim()).ToList();
		}

		/// <summary>
		/// Returns the text for the selected input parallel to a label matching on text with 'name'.
		/// Returns null if there is no matching label or if no input is selected
		/// </summary>
		public string SelectedInputForLabel(string lblText)
		{
			IWebElement label = this.SectionControlLabels?.FirstOrDefault(x => x.Text.Contains(lblText));
			IWebElement selectedOption = label?.FindElements(By.XPath("../..//input"), 2)?.FirstOrDefault(x => x.Selected);
			return selectedOption?.FindElement(By.XPath("../..//label/span"), 2)?.Text;
		}

		public bool ControlLabelIsDisplayed(string lblText)
		{
			return this.SectionControlLabels.Any(x => x.Text.Contains(lblText));
		}

		public string SelectedRadioForLabel(string lblText)
		{
			IWebElement label = this.SectionControlLabels?.FirstOrDefault(x => x.Text.Contains(lblText));
			IWebElement selectedOption = label?.FindElements(By.XPath("../..//input[@type='radio']"), 2)?.FirstOrDefault(x => x.Selected);
			return selectedOption?.FindElement(By.XPath("./following-sibling::span"), 2)?.Text;
		}

		public bool SelectRadioForLabel(string lblText, string optionText)
		{
			IWebElement label = this.SectionControlLabels?.FirstOrDefault(x => x.Text.Contains(lblText));
			IWebElement option = label?.FindElement(By.XPath($@"../..//input[@type='radio' and ./following-sibling::span[contains(text(), ""{optionText}"")]]"), 2);
			return option.TryClick();
		}

		public List<string> RadioButtonsForLabelSection(string lblText)
		{
			IWebElement label = SectionControlLabels.FirstOrDefault(x => x.Text.Contains(lblText));
			IList<IWebElement> radios = label.FindElements(By.XPath("./following-sibling::div//div[@class='radio']//span"), 2);
			if (radios.Count == 0)
			{
				return new List<string>();
			}
			return radios.Select(x => x.Text).ToList();
		}

		public string CheckedInputForLabel(string lblText)
		{
			IWebElement label = this.SectionControlLabels?.FirstOrDefault(x => x.Text.Contains(lblText));
			IWebElement selectedOption = label?.FindElements(By.XPath("../..//input"), 2)?.First(x => x.Checked());
			return selectedOption?.FindElement(By.XPath("./following-sibling::span"), 2)?.Text;
		}

		public List<string> AllCheckedInputsForLabel(string lblText)
		{
			IWebElement label = this.SectionControlLabels?.FirstOrDefault(x => x.Text.Contains(lblText));
			IEnumerable<IWebElement> selectedOptions = label?.FindElements(By.XPath("../..//input"), 2)?.Where(x => x.Checked());
			return selectedOptions != null ? selectedOptions.Select(x => x.FindElement(By.XPath("./following-sibling::span"), 2)?.Text).ToList() : new List<string>();
		}

		public string TextInputValueForLabel(string lblText)
		{
			IWebElement label = this.SectionControlLabels?.FirstOrDefault(x => x.Text.Contains(lblText));
			return label.FindElement(By.XPath("../following-sibling::div//input[@type ='text']"), 2)?.GetValue();
		}

		public void EnterTextToLabelnput(string lblText, string value)
		{
			IWebElement label = this.SectionControlLabels?.FirstOrDefault(x => x.Text.Contains(lblText));
			IWebElement input = label?.FindElement(By.XPath("../following-sibling::div//input[@type ='text']"), 2);
			if (input != null)
			{
				input.EnterText(value);
			}
			else
			{
				throw new Exception("Label not found as expected.");
			}
		}

		/// <summary>
		/// Returns the full text of a label element for the first match containing partial text
		/// This is used when there is no other reliable identifier for an element other than text
		/// </summary>
		public string LabelContainsFullText(string partialText) => this.LabelContains(partialText)?.Text;

		/// <summary>
		/// Returns the full text of a bold element (b) for the first match containing partial text
		/// 		/// This is used when there is no other reliable identifier for an element other than text
		/// </summary>
		public string BoldElementContainsFullText(string partialText) => this.BoldElementContains(partialText)?.Text;

		#endregion

		#region classes
		public enum Tab { ProductType, ProductCharacteristics, RecipientAndUpcDetails, ReviewAndSubmit }

		public static Dictionary<Tab, string> MapTabs = new Dictionary<Tab, string> {
			{ Tab.ProductType , "Product Type" },
			{ Tab.ProductCharacteristics , "Product Characteristics" },
			{ Tab.RecipientAndUpcDetails , "Recipient and UPC Details" },
			{ Tab.ReviewAndSubmit , "Review and Submit" }
		};
		#endregion
		public string BatteyWarning()
		{
			return this.containerElement.FindElement(By.XPath(".//div[@class='WARNING']"), 2).Text;
		}

		public string GetCurrentProduct()
		{
			return this.containerElement.FindElement(By.XPath(".//h2[@class='product-name']"), 2).Text.Trim();
		}

		//New, Copy or UPC
		public void SelectTypeOfProductToCreate(string type = "New")
		{
			IWebElement option = this.containerElement.FindElements(By.XPath(".//form//input[@type='radio']/../span"), 2)
				.FirstOrDefault(x => x.Text.Contains(type));
			if (option == null)
			{
				return;
			}

			option.Click();
		}

		public void CreateNewProductOrCopy(bool newProduct = true)
		{
			if (newProduct)
			{
				this.SelectTypeOfProductToCreate("New");
			}
			else
			{
				this.SelectTypeOfProductToCreate("Copy");
			}
		}

		//public bool RefreshContainer()
		//{
		//	this.containerElement = SeleniumBrowser.WebBrowser.FindElement(By.XPath(BasePath), 2);
		//	return this.containerElement != null;
		//}

		public bool CountryofOriginExists()
		{
			IWebElement myLabel = this.containerElement.FindElement(By.XPath(".//label[contains(text(),'Country of Origin')]"), 2);

			if (myLabel == null)
			{
				Report.Info("'Select the product's Country of Origin' Not Available");
				return false;
			}
			Report.Info("'Select the product's Country of Origin' Available");
			return true;
		}

		public bool ClickCancelButton()
		{
			try
			{
				IWebElement el = this.containerElement.FindElement(By.XPath(".//a[contains(@class,'cancel-button')]"), 2);
				if (el == null)
				{
					return false;
				}
				return el.TryClick() && GeneralUtilities.WaitForRefreshToDisappear(el) && GeneralUtilities.Wait_for_load_finish();
			}
			catch (Exception)
			{
				return false;
			}
		}

		public bool ClickSaveButton()
		{
			try
			{
				IList<IWebElement> listSaveButtons = this.containerElement.FindElements(By.XPath(".//a[contains(@class,'save-button')]"), 2);

				IWebElement el = listSaveButtons.FirstOrDefault(x => x.Displayed);
				if (el == null)
				{
					return false;
				}
				return el.TryClick() && GeneralUtilities.WaitForRefreshToDisappear(el) && GeneralUtilities.Wait_for_load_finish();
			}
			catch (Exception)
			{
				return false;
			}
		}

		public bool SaveButtonExists()
		{
			IList<IWebElement> listSaveButtons = this.containerElement.FindElements(By.XPath(".//a[contains(@class,'save-button')]"), 2);

			IWebElement el = listSaveButtons.FirstOrDefault(x => x.Displayed);

			if (el == null)
			{
				Report.Info("Save button Not Available");
				return false;
			}
			Report.Info("Save button Available");
			return true;
		}

		public List<KeyValuePair<int, string>> TableHeaders(IWebElement table)
		{
			List<KeyValuePair<int, string>> th = new EditableList<KeyValuePair<int, string>>();
			ReadOnlyCollection<IWebElement> listOfHeaders = table.FindElements(By.XPath(".//th"));
			for (int i = 0; i < listOfHeaders.Count; i++)
			{
				th.Add(new KeyValuePair<int, string>(i + 1, listOfHeaders[i].Text));
			}
			return th;
		}

		public bool ClickAddUpcButton()
		{
			IWebElement el = this.containerElement.FindElement(By.XPath(".//button[contains(@data-bind,'addNewRow')]"), 2);
			return el != null && el.TryClick();
		}

		public bool DeleteUPC(string upc)
		{
			if (upc.ToLower().Contains("saved as"))
			{
				upc = Context.GetFromContext(upc.Replace("saved as", "", StringComparison.InvariantCultureIgnoreCase).Trim()).ToString();
			}
			Report.Info("Attempting to delete: " + upc);
			IWebElement container = this.containerElement.FindElement(By.XPath(".//table[@class='table table-hover upc-table']"), 2);
			IWebElement upcmatch = container.FindElements(By.XPath(".//span[contains(@data-bind,'upc')]"), 2).FirstOrDefault(x => x.Text.Contains(upc))
							?? container.FindElements(By.XPath(".//span[contains(@data-bind,'upc')]"), 2).FirstOrDefault(x => x.GetValue().Contains(upc))
						   ?? container.FindElements(By.XPath(".//input[contains(@data-bind,'upc')]"), 2).FirstOrDefault(x => x.GetValue().Contains(upc));
			if (upcmatch != null)
			{
				if (!upcmatch.FindElement(By.XPath("./ancestor::tr[position()=1]//a[contains(text(), 'Delete')]"), 2).TryClick())
				{
					Report.Info("Failed to find delete button");
					return false;
				}
			}
			else
			{
				Report.Info("Failed to find matching row.");
				return false;
			}
			Report.Info("Successfully clicked delete button.");
			Report.Screenshot();
			var md = new ModalDialog();
			if (md.Wait_for_load(30))
			{
				Report.Screenshot();
				if (md.Click_OK())
				{
					Report.Info("Clicked OK");
					Report.Screenshot();
					return true;
				}
				return false;
			}
			return false;
		}

		public List<string> GetAllUPCs()
		{
			IWebElement container = SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//table[@class='table table-hover upc-table']"), 2);
			return container.FindElements(By.XPath(".//span[contains(@data-bind,'upc')]"), 2).Select(x => x.Text).ToList();
		}

		public List<string> GetAllUPCDestinationRetailers()
		{
			IWebElement container = this.containerElement.FindElement(By.XPath(".//table[@class='table table-hover upc-table']"), 2);
			return container.FindElements(By.XPath(".//span[contains(@data-bind,'identifier')]"), 2).Select(x => x.Text).ToList();
		}

		public bool ClickSelectAllDestinationRetailers()
		{
			return this.containerElement.FindElement(By.XPath(".//input[@id='chkAllRetailers']"), 1).TryCheck();
		}

		public bool SelectAllCertifications()
		{
			bool checkTrue = true;
			IList<IWebElement> listofCert = this.containerElement.FindElements(By.XPath(".//div[@data-bind='with: upc']//div//input"), 1);
			foreach (var item in listofCert)
			{
				//IWebElement inputbox= item.FindElement(By.XPath(".//"))
				bool clicked = item.TryClick();
				string textTitle = item.Text;
				if (!clicked)
				{
					checkTrue = false;
					Report.Info($"Failed to check the certification with title: {textTitle}");
				}
				else
				{
					Report.Info($"Successfully checked the certification with title: {textTitle}");
				}
			}



			return this.containerElement.FindElement(By.XPath(".//input[@id='chkAllRetailers']"), 1).TryCheck();
		}

		public bool UPCPackageTypeFieldExists()
		{
			try
			{
				IWebElement container = this.containerElement.FindElement(By.XPath(".//table[@class='table table-hover upc-table']"), 2);
				IWebElement packageTypeField = container.FindElement(By.XPath(".//select[contains(@data-bind,'Package Type')]"), 2);
				if (packageTypeField == null)
				{
					return false;
				}
				else
				{
					return true;
				}
			}
			catch (Exception)
			{
				return false;
			}
		}

		public string GetValidOptionForUPCPackageType()
		{
			if (!this.UPCPackageTypeFieldExists())
			{
				Report.Info("Package type field does not exist");
				Report.Screenshot();
				return null;
			}
			IWebElement container = this.containerElement.FindElement(By.XPath(".//table[@class='table table-hover upc-table']"), 2);
			IWebElement packageTypeField = container.FindElement(By.XPath(".//select[contains(@data-bind,'Package Type')]"), 2);
			var selectOptions = packageTypeField.FindElements(By.XPath(".//option")).Select(x => x.GetValue()).ToList();
			return selectOptions.FirstOrDefault(x => x != "Package Type");

		}

		public bool AddNewPackingTypeLinkExists()
		{
			IWebElement link = this.containerElement.FindElement(By.XPath("//a[contains(text(), 'Add new Packaging Type')]"), 2);
			return (link != null);
		}

		public List<string> GetAllOptionsForUPCPackageType()
		{
			if (!this.UPCPackageTypeFieldExists())
			{
				Report.Info("Package type field does not exist");
				Report.Screenshot();
				return null;
			}
			IWebElement container = this.containerElement.FindElement(By.XPath(".//table[@class='table table-hover upc-table']"), 2);
			IWebElement packageTypeField = container.FindElement(By.XPath(".//select[contains(@data-bind,'Package Type')]"), 2);
			return packageTypeField.FindElements(By.XPath(".//option")).Select(x => x.GetValue()).ToList();
		}

		public bool InputUPCNumber(string upcNumber)
		{
			IWebElement container = this.containerElement.FindElement(By.XPath(".//table[@class='table table-hover upc-table']"), 2);
			IWebElement upcNumberField = container.FindElement(By.XPath(".//label[contains(text(),'UPC Number')]/..//input"), 2);

			if (upcNumber.ToLower().Contains("saved as"))
			{
				try
				{
					string savedUPC = Context
						.GetFromContext(upcNumber.Replace("saved as", "", StringComparison.InvariantCultureIgnoreCase).Trim())
						.ToString();
					upcNumber = savedUPC;
				}
				catch (Exception e)
				{
					Report.Info("Failed to find saved item in context: " + upcNumber.Replace("saved as", "", StringComparison.InvariantCultureIgnoreCase) + e.Message);
					throw;
				}

			}
			upcNumberField.EnterText(upcNumber);
			return upcNumberField.GetValue() == upcNumber;
		}

		public bool InputUPCSize(string size)
		{
			IWebElement container = this.containerElement.FindElement(By.XPath(".//table[@class='table table-hover upc-table']"), 2);
			IList<IWebElement> textInputs = container.FindElements(By.XPath("//input[@type = 'text']"), 2);
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
			sizeField.EnterText(size);
			return sizeField.GetValue() == size;
		}

		public bool SelectContainerType(string containerType)
		{
			IWebElement container = this.containerElement.FindElement(By.XPath(".//table[@class='table table-hover upc-table']"), 2);
			IWebElement upcNumberField = container.FindElement(By.XPath(".//label[contains(text(),'UPC Number')]/..//input"), 2);

			IWebElement containsType = container.FindElement(By.XPath(".//select[contains(@data-bind,'Container Type')]"), 2);
			containsType.Select(containerType);
			return containsType.GetValue() == containerType;
		}

		public List<string> GetContainerOptions()
		{
			IWebElement container = this.containerElement.FindElement(By.XPath(".//table[@class='table table-hover upc-table']"), 2);
			IWebElement upcNumberField = container.FindElement(By.XPath(".//label[contains(text(),'UPC Number')]/..//input"), 2);

			IWebElement containsType = container.FindElement(By.XPath(".//select[contains(@data-bind,'Container Type')]"), 2);
			return containsType.FindElements(By.XPath(".//option")).Select(x => x.GetValue()).ToList();
		}

		public bool InputUpcInformation(UpcInformation info)
		{
			try
			{
				IWebElement container = this.containerElement.FindElement(By.XPath(".//table[@class='table table-hover upc-table']"), 2);
				IList<IWebElement> textInputs = container.FindElements(By.XPath("//input[@type = 'text']"), 2);
				IWebElement upcNumberField = container.FindElement(By.XPath(".//label[contains(text(),'UPC Number')]/..//input"), 2);
				IWebElement ProductNameOnlabel = container.FindElement(By.XPath(".//label[contains(text(),'Product Name on Label')]/..//input"), 2);

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


				IWebElement productNameOnlabelObj = container.FindElement(By.XPath(".//label[contains(text(),'Product Name on Label')]/.."), 2);

				string productNameDataBind=productNameOnlabelObj.GetAttribute("class");
				if(productNameDataBind!=null)
				{
					if (!productNameDataBind.Contains("form-group has-success"))
					{
						ProductNameOnlabel.EnterText("UPCName PlaceHolder");
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

							ProductNameOnlabel.EnterText(info.UPCName);
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

				//if (ProductNameOnlabel != null)
				//{
				//	if (ProductNameOnlabel.Text.IsNullOrEmpty())
				//	{
				//		ProductNameOnlabel.EnterText("UPCName PlaceHolder");
				//		Report.Failure("The UPC Name Field was empty, entered PlaceHolder text");
				//	}
				//	else
				//	{
				//		Report.Info("The Field was not empty, Checking for UPCName in the table");
				//		if (!info.UPCName.IsNullOrEmpty())
				//		{
				//			if (info.UPCName.ToLower().Contains("saved as"))
				//			{
				//				try
				//				{
				//					string savedUPC = Context
				//						.GetFromContext(info.UPCName.Replace("saved as", "", StringComparison.InvariantCultureIgnoreCase).Trim())
				//						.ToString();
				//					info.UPCName = savedUPC;
				//				}
				//				catch (Exception e)
				//				{
				//					Report.Info("Failed to find saved item in context: " + info.UPCName.Replace("saved as", "", StringComparison.InvariantCultureIgnoreCase) + e.Message);
				//					throw;
				//				}

				//			}

				//			upcNumberField.EnterText(info.UPCName);
				//		}
				//		else
				//		{
				//			Report.Info("UPC Name was not found in the table, leaving default UPC Name");
				//		}

				//	}
				//}
				//else
				//{
				//	Report.Failure("The UPC Name field was not present");
				//}
				


				if (info.ContainerType.ToLower() != "none")
				{
					IWebElement containsType = container.FindElement(By.XPath(".//select[contains(@data-bind,'Container Type')]"), 2);
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
				if (info.Dpci.Length > 0)
				{
					IWebElement dpciField = container.FindElement(By.XPath(".//input[contains(@data-bind,'value.field')]"), 2);
					dpciField.EnterText(info.Dpci);
				}
				if (info.Quantity.Length > 0)
				{
					IWebElement quantityField = container.FindElement(By.XPath(".//input[@placeholder='Quantity']"), 2);
					quantityField.EnterText(info.Quantity);
				}

				if (info.PackageType.Length > 0)
				{
					IWebElement packageField = container.FindElement(By.XPath(".//select[contains(@data-bind,'Package Type')]"), 2);
					packageField.Select(info.PackageType);
				}
				return true;
			}
			catch (Exception ex)
			{
				Report.Info(ex.Message);
				return false;
			}
		}

		public List<string> GetUPCHeaders()
		{
			IWebElement container = this.containerElement.FindElement(By.XPath(".//table[@class='table table-hover upc-table']"), 2);
			var rList = new List<string>();
			for(int i=2;i<6;i++)
			{
				if (container != null)
				{
					
					var tempList = new List<string>();
					try
					{
						tempList = container.FindElement(By.XPath($".//th[@class='col-xs-{i}']")).GetValue().Replace("\r\n", "|").Split('|').Select(x => x.Trim()).Where(x => x != "UPC Number").ToList();
						if (tempList.IsNullOrEmpty())
						{
							Report.Info("There was no header text found for that column");
						}
						else
						{
							foreach (var item in tempList)
							{
								rList.Add(item);
							}
						}
					}
					catch
					{
						Report.Info($"Column with @class='col-xs-{i}' does not exist");
					}					
					
					
				}
				else
				{
					Report.Info("The Container element was null");
				}
				
			}			

			return rList;
		}

		public bool CommentsAreaShowing()
		{
			IWebElement el = this.containerElement.FindElement(By.XPath(".//h3[text()='Comments']/../../../..//textarea"), 2);
			return el != null;
		}

		public bool InputCommentAreaText(string text, bool append = false)
		{
			try
			{
				if (!this.CommentsAreaShowing())
				{
					return false;
				}

				IWebElement el = this.containerElement.FindElement(By.XPath(".//h3[text()='Comments']/../../../..//textarea"), 2);
				if (append)
				{
					el.SendKeys(text);
				}
				else
				{
					el.EnterText(text);
				}
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public bool CommentErrorDisplayed(string expected, out string actual)
		{
			IWebElement el = this.containerElement.FindElement(By.XPath(@"//p[contains(concat(' ',normalize-space(@class),' '),'form-error')]"));
			if (el != null)
			{
				actual = el.Text;
				return actual == expected;
			}
			actual = "null";
			return false;
		}

		public bool DataAcceptanceScreenAppears()
		{
			IWebElement el = this.containerElement.FindElement(By.XPath(".//h3[text()='Data Acceptance']"), 2);
			if (el == null)
			{
				return false;
			}

			return el.Displayed;
		}

		public List<string> Get3rdPartyPageAlerts()
		{
			IList<IWebElement> el = this.containerElement.FindElements(By.XPath(".//div[@class='alert alert-info']"), 2);
			if (el.Count > 0)
			{
				return this.containerElement.FindElements(By.XPath(".//div[@class='alert alert-info']"), 2).Select(x => x.GetValue()).ToList();
			}
			return new List<string>();
		}

		public bool ThirdPartyScreenAppears()
		{
			IWebElement el = this.containerElement.FindElement(By.XPath(".//h3[text()='Formulation > 3rd Party']"), 2);
			if (el == null)
			{
				return false;
			}

			return el.Displayed;
		}

		public bool SelectYesAgreedRadio()
		{
			IWebElement el = this.containerElement.FindElement(By.XPath(".//span[contains(text(), 'Yes, Agreed')]/../input"), 2);
			if (el == null)
			{
				return false;
			}

			return el.TryClick();

		}

		public bool YesAgreedIsSelected()
		{
			IWebElement el = this.containerElement.FindElement(By.XPath(".//span[contains(text(), 'Yes, Agreed')]/../input"), 2);
			if (el == null)
			{
				return false;
			}
			return el.Selected;
		}

		public bool YesAgreedExists()
		{
			try
			{
				IWebElement el = this.containerElement.FindElement(By.XPath(".//span[contains(text(), 'Yes, Agreed')]/../input"), 2);
				if (el == null)
				{
					return false;
				}
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public bool AcceptRadioIsSelected()
		{
			IWebElement el = this.containerElement.FindElement(By.XPath(".//span[contains(text(), 'Accept')]/../input"), 2);
			if (el == null)
			{
				return false;
			}

			return el.Selected;
		}

		public bool SelectAcceptRadio()
		{
			SeleniumBrowser.ScrollToTopOfPage();
			IWebElement el = this.containerElement.FindElement(By.XPath(".//span[contains(text(), 'Accept')]/../input"), 2);
			if (el == null)
			{
				return false;
			}

			return el.TryClick();

		}

		/// <summary>
		/// 'formulation third party' screen
		/// </summary>
		public bool SelectGrantedRadio()
		{
			IWebElement el = this.containerElement.FindElement(By.XPath(".//span[contains(text(), 'Granted')]/../input"), 2);
			if (el == null)
			{
				return false;
			}

			return el.TryClick();
		}

		/// <summary>
		/// 'formulation third party' screen
		/// </summary>
		public bool GrantedRadioIsSelected()
		{
			IWebElement el = this.containerElement.FindElement(By.XPath(".//span[contains(text(), 'Granted')]/../input"), 2);
			if (el == null)
			{
				return false;
			}

			return el.Selected;
		}

		public bool FieldValueRadioIsSelected(string field, string value)
		{
			IWebElement el = this.containerElement.FindElement(By.XPath($".//label[text()='{field}']/../..//span[text()='{value}']/../input"), 2);
			if (el == null)
			{
				Report.Info($"Section {field} does not have input {value}");
				return false;
			}

			return el.Selected;
		}

		public bool SelectFieldValueRadio(string field, string value)
		{
			IWebElement el = this.containerElement.FindElement(By.XPath($".//label[text()='{field}']/../..//span[text()='{value}']/../input"), 2);
			if (el == null)
			{
				Report.Info($"Section {field} does not have input {value}");
				return false;
			}

			return el.TryClick();
		}

		public bool SelectDeclinedRadio()
		{
			IWebElement el = this.containerElement.FindElement(By.XPath(".//span[contains(text(), 'Declined')]/../input"), 2);
			if (el == null)
			{
				return false;
			}

			return el.TryClick();

		}

		public bool DeclinedRadioIsSelected()
		{
			IWebElement el = this.containerElement.FindElement(By.XPath(".//span[contains(text(), 'Declined')]/../input"), 2);
			if (el == null)
			{
				return false;
			}

			return el.Selected;
		}

		public bool ClickAcceptButton()
		{
			IWebElement el = this.containerElement.FindElement(By.XPath(".//a[text()='Accept']"), 2);
			if (el == null)
			{
				return false;
			}

			if (el.TryClick())
			{
				Delay.Seconds(1);
				Report.Info("Clicked accept button. Beginning wait for loading to finish");
				return GeneralUtilities.WaitForRefreshToDisappear(el, 120);
			}
			else
			{
				Report.Info("Failed to click accept button");
				return false;
			}
		}

		public bool AcceptButtonDisplayed()
		{
			IWebElement el = this.containerElement.FindElement(By.XPath(".//a[text()='Accept']"), 2);
			return el != null && el.Displayed;
		}

		public bool ClickSummaruButtonInDataAcceptance()
		{
			IWebElement el = this.containerElement.FindElement(By.XPath(".//a[text()='Summary']"), 30);
			if (el == null)
			{
				return false;
			}

			return el.TryClick();
		}

		// ========= Product Charactertistics Options ========= //

		public bool ProductIsRegulatedForTransport(string item)
		{
			//get
			//{
			//	var el = containerElement
			//		.FindElements(By.XPath(".//label[text()='Product is Regulated for Transport']/../following-sibling::div//input"), 2)
			//		.FirstOrDefault(x => x.Selected).FindElement(By.XPath("../span"));
			//	if (el != null)
			//	{
			//		return el.Text;
			//	}

			//	return "";
			//}
			//set
			//{
			//	var el = containerElement
			//		.FindElements(By.XPath(".//label[text()='Product is Regulated for Transport']/../following-sibling::div//span"), 2)
			//		.FirstOrDefault(x => x.Text.Contains(value)).FindElement(By.XPath("../input"));
			//	if (el != null)
			//	{
			//		el.TryClick();
			//	}
			//}

			try
			{
				IWebElement el = this.containerElement
					.FindElements(By.XPath(".//label[text()='Product is Regulated for Transport']/../following-sibling::div//span"), 2)
					.FirstOrDefault(x => x.Text == item).FindElement(By.XPath("../input"));
				if (el != null)
				{
					el.TryClick();
					return true;
				}

				return false;
			}
			catch (Exception)
			{
				return false;
			}

		}

		/// <summary>
		/// Select all modes of transport that you've classified the product for checkbox options
		/// </summary>
		public bool AllModesOfTransport(string item)
		{
			try
			{
				IWebElement el = this.containerElement
					.FindElements(By.XPath(".//label[contains(text(),'Select all modes of transport')]/../following-sibling::div//span"), 2)
					.FirstOrDefault(x => x.Text == item).FindElement(By.XPath("../input"));
				if (el != null)
				{
					el.TryClick();
					return true;
				}

				return false;
			}
			catch (Exception)
			{
				return false;
			}
		}


		/// <summary>
		/// Please select DOT Exceptions if applicable -- eg 173.120(a)(2), 173.120(a)(3)
		/// </summary>
		public bool DotExcemptionIfApplicable(string item)
		{
			try
			{
				IWebElement el = this.containerElement
					.FindElements(By.XPath(".//label[contains(text(),'Please select DOT Exceptions if applicable?')]/../following-sibling::div//span"), 2)
					.FirstOrDefault(x => x.Text == item).FindElement(By.XPath("../input"));
				if (el != null)
				{
					el.TryClick();
					return true;
				}

				return false;
			}
			catch (Exception)
			{
				return false;
			}
		}

		/// <summary>
		/// International Shipping when DOT Exemption taken radio option
		/// </summary>
		public string InternationalShippingDOTExemption {
			get
			{
				IWebElement el = this.containerElement
					.FindElements(By.XPath(".//label[text()='International Shipping when DOT Exemption taken?']/../following-sibling::div//input"), 2)
					.FirstOrDefault(x => x.Selected).FindElement(By.XPath("../span"));
				if (el != null)
				{
					return el.Text;
				}

				return "";
			}
			set
			{
				IWebElement el = this.containerElement
					.FindElements(By.XPath(".//label[text()='International Shipping when DOT Exemption taken?']/../following-sibling::div//span"), 2)
					.FirstOrDefault(x => x.Text.Contains(value)).FindElement(By.XPath("../input"));
				if (el != null)
				{
					el.TryClick();
				}
			}
		}

		public List<string> DOTExceptions {
			get
			{
				IEnumerable<IWebElement> selectedInputs = this.containerElement
					.FindElements(By.XPath(".//label[contains(text(),'Please select DOT Exceptions if applicable')]/../following-sibling::div//input"), 2)
					.Where(x => x.Selected);
				var selectedLabels = new List<string>();
				foreach (IWebElement input in selectedInputs)
				{
					selectedLabels.Add(input.FindElement(By.XPath("../span")).Text);
				}

				return selectedLabels;
			}
			set
			{
				foreach (string item in value)
				{
					IWebElement el = this.containerElement
						.FindElements(By.XPath(".//label[contains(text(),'Please select DOT Exceptions if applicable')]/../following-sibling::div//span"), 2)
						.FirstOrDefault(x => x.Text.Contains(item)).FindElement(By.XPath("../input"));
					if (el != null)
					{
						el.TryClick();
					}
				}

			}
		}

		public string OtherDOTException {
			get
			{
				IWebElement el = this.containerElement
					.FindElement(By.XPath(".//label[contains(text(),'Other DOT Exception')]/../following-sibling::div//input"), 2);
				return el.GetValue();
			}
			set
			{
				IWebElement el = this.containerElement
					.FindElement(By.XPath(".//label[contains(text(),'Other DOT Exception')]/../following-sibling::div//input"), 2);
				el.EnterText(value);
			}
		}

		public string SpecialPermitNumbers {
			get
			{
				IWebElement el = this.containerElement
					.FindElement(By.XPath(".//label[contains(text(),'Special Permit')]/../following-sibling::div//input"), 2);
				return el.GetValue();
			}
			set
			{
				IWebElement el = this.containerElement
					.FindElement(By.XPath(".//label[contains(text(),'Special Permit')]/../following-sibling::div//input"), 2);
				el.EnterText(value);
			}
		}

		public List<string> ListOfPrimaryPhysicalStates()
		{
			return this.containerElement.FindElements(By.XPath(".//label[text()='Primary Physical State']/..//following-sibling::div//label//span"), 2).Select(x => x.GetValue()).ToList();
		}

		public bool SelectSecondaryPhysicalState(string item)
		{
			try
			{
				IWebElement el = this.containerElement.FindElement(By.XPath(".//label[text()='Secondary Physical State']/..//following-sibling::div//select"), 2);
				el.Select(item);
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public string WaterSolubility {
			get
			{
				IWebElement el = this.containerElement.FindElement(By.XPath(".//label[text()='Select the best Water Solubility description']/..//following-sibling::div//select"), 2);
				return el.SelectedOption();
			}
			set
			{
				IWebElement el = this.containerElement.FindElement(By.XPath(".//label[text()='Select the best Water Solubility description']/..//following-sibling::div//select"), 2);
				el.Select(value);
			}
		}

		/// <summary>
		/// When the product has a flammable propellant, or contains ingredients with a flash point below 60⁰C then radio options
		/// </summary>
		public bool ProductHasFlammablePropellant(string item)
		{
			try
			{
				IWebElement el = this.containerElement
					.FindElements(By.XPath(".//label[contains(text(),'flammable propellant')]/../following-sibling::div//span"), 2)
					.FirstOrDefault(x => x.Text == item).FindElement(By.XPath("../input"));
				if (el != null)
				{
					el.TryClick();
					return true;
				}

				return false;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public bool SelectBestWaterSolubilityDescription(string item)
		{
			try
			{
				IWebElement el = this.containerElement.FindElement(By.XPath(".//label[text()='Select the best Water Solubility description']/..//following-sibling::div//select"), 2);
				el.Select(item);
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		/// <summary>
		/// Refer to your Product Label. From the options, select those that appear on the Label checkbox options
		/// </summary>
		public List<string> ProductLabel {
			get
			{
				IEnumerable<IWebElement> selectedInputs = this.containerElement
					.FindElements(By.XPath(".//label[contains(text(),'Refer to your Product Label')]/../following-sibling::div//input"), 2)
					.Where(x => x.Selected);
				var selectedLabels = new List<string>();
				foreach (IWebElement input in selectedInputs)
				{
					selectedLabels.Add(input.FindElement(By.XPath("../span")).Text);
				}

				return selectedLabels;
			}
			set
			{
				foreach (string item in value)
				{
					IWebElement el = this.containerElement
						.FindElements(By.XPath(".//label[contains(text(),'Refer to your Product Label')]/../following-sibling::div//span"), 2)
						.FirstOrDefault(x => x.Text.Contains(item)).FindElement(By.XPath("../input"));
					if (el != null)
					{
						el.TryClick();
					}
				}

			}
		}

		public bool SetWaterSolutionQuestion {
			set
			{
				IList<IWebElement> btns = this.containerElement.FindElements(By.XPath(".//label[contains(text(),'When mixed with an equal')]/..//following-sibling::div//input/following-sibling::span"), 2);
				IWebElement button = btns.FirstOrDefault(x => x.GetValue().Trim() == (value ? "Yes" : "No"));
				if (button == null)
				{
					return;
				}

				//var el = button.FindElement(By.XPath("./preceding-sibling::input"), 2);
				button.TryClick();
			}
		}

		public bool AddItemToKit(string product)
		{
			try
			{
				IWebElement placeholderEl = this.containerElement.FindElement(By.XPath(".//span[contains(@id, 'select2-autocomplete')]"), 2);
				placeholderEl.TryClick();
				IWebElement MatchedEntry = null;
				IWebElement inputEl = SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//input[@class='select2-search__field']"), 2);
				inputEl.EnterText(product);
				IWebElement searching = this.containerElement.FindElement(By.XPath(".//li[contains(@class,'select2-results__message')]"), 2);
				int i = 0;
				while (searching != null && i < 10)
				{
					Delay.Seconds(Delay.SpeedFactor * 1);
					i++;
					searching = this.containerElement.FindElement(By.XPath(".//li[contains(@class,'select2-results__message')]"), 2);
				}
				IList<IWebElement> Matches = this.containerElement.FindElements(By.XPath(".//li[contains(@class,'select2-results__option')]"), 2);
				IWebElement MatchingNameValue = Matches.FirstOrDefault(x => x.GetValue().Trim().ToLower() == product.Trim().ToLower());
				if (MatchingNameValue == null)
				{
					// No matching name entry was found, so we take the first one just in case we are looking for a partial match!
					MatchedEntry = Matches.FirstOrDefault();
				}
				else
				{
					MatchedEntry = MatchingNameValue;
				}

				return MatchedEntry.TryClick();
			}
			catch (Exception)
			{
				return false;
			}

		}

		// searches by name, matches by ID
		public bool AddItemToKitByNameAndID(ProductInformation product)
		{
			try
			{
				for (int j = 0; j < 5; j++)
				{
					IWebElement placeholderEl = this.containerElement.FindElement(By.XPath(".//span[contains(@id, 'select2-autocomplete')]"), 2);
					placeholderEl.TryClick();
					IWebElement MatchedEntry = null;
					IWebElement inputEl = SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//input[@class='select2-search__field']"), 2);
					inputEl.EnterText(product.Name);
					IWebElement searching = this.containerElement.FindElement(By.XPath(".//li[contains(@class,'select2-results__message')]"), 2);
					int i = 0;
					while (searching != null && i < 10)
					{
						Delay.Seconds(Delay.SpeedFactor * 1);
						i++;
						searching = this.containerElement.FindElement(By.XPath(".//li[contains(@class,'select2-results__message')]"), 2);
					}
					IList<IWebElement> Matches = SeleniumBrowser.WebBrowser.FindElements(By.XPath(".//li[contains(@class,'select2-results__option')]"), 2);
					IWebElement MatchingByID = Matches.FirstOrDefault(x => x.GetValue().Trim().ToLower().Contains(product.Id.ToLower()));
					if (MatchingByID == null)
					{
						// No matching name entry was found, so we take the first one just in case we are looking for a partial match!
						MatchedEntry = Matches.FirstOrDefault();
					}
					else
					{
						MatchedEntry = MatchingByID;
					}


					if (MatchedEntry != null)
					{
						Report.Info("Found matching search item, attempting to click");
						MatchedEntry.TryClick();
						Delay.Seconds(1);
						ReadOnlyCollection<IWebElement> listOfSelected = SeleniumBrowser.WebBrowser.FindElements(By.XPath(
							"//div[contains(text(), 'Select Existing Registrations')]/../..//table/tbody/tr//input/../..//span"));

						IWebElement matchingProduct = listOfSelected.FirstOrDefault(x => x.GetValue().Contains(product.Name));

						if (matchingProduct != null)
						{
							Report.Info("Matching product showing in table, attempting to check checkbox");
							IWebElement matchingCheckbox = matchingProduct.FindElement(By.XPath("../..//input"), 2);
							return matchingCheckbox.TryClick();
						}
					}
				}

				return false;
			}
			catch (Exception)
			{
				return false;
			}

		}

		// searches by name, matches by ID
		public bool AddItemToKitByID(ProductInformation product)
		{
			try
			{
				for (int j = 0; j < 5; j++)
				{
					IWebElement placeholderEl = this.containerElement.FindElement(By.XPath(".//span[contains(@id, 'select2-autocomplete')]"), 2);
					placeholderEl.TryClick();
					IWebElement MatchedEntry = null;
					IWebElement inputEl = SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//input[@class='select2-search__field']"), 2);
					inputEl.EnterText(product.Id);
					IWebElement searching = this.containerElement.FindElement(By.XPath(".//li[contains(@class,'select2-results__message')]"), 2);
					int i = 0;
					while (searching != null && i < 10)
					{
						Delay.Seconds(Delay.SpeedFactor * 1);
						i++;
						searching = this.containerElement.FindElement(By.XPath(".//li[contains(@class,'select2-results__message')]"), 2);
					}
					IList<IWebElement> Matches = SeleniumBrowser.WebBrowser.FindElements(By.XPath(".//li[contains(@class,'select2-results__option')]"), 2);
					IWebElement MatchingByID = Matches.FirstOrDefault(x => x.GetValue().Trim().ToLower().Contains(product.Id.ToLower()));
					if (MatchingByID == null)
					{
						// No matching name entry was found, so we take the first one just in case we are looking for a partial match!
						MatchedEntry = Matches.FirstOrDefault();
					}
					else
					{
						MatchedEntry = MatchingByID;
					}


					if (MatchedEntry != null)
					{
						Report.Info("Found matching search item, attempting to click");
						MatchedEntry.TryClick();
						Delay.Seconds(1);
						ReadOnlyCollection<IWebElement> listOfSelected = SeleniumBrowser.WebBrowser.FindElements(By.XPath(
							"//div[contains(text(), 'Select Existing Registrations')]/../..//table/tbody/tr//input/../..//span"));

						IWebElement matchingProduct = listOfSelected.FirstOrDefault(x => x.GetValue().Contains(product.Id));

						if (matchingProduct != null)
						{
							Report.Info("Matching product showing in table, attempting to check checkbox");
							IWebElement matchingCheckbox = matchingProduct.FindElement(By.XPath("../..//input"), 2);
							return matchingCheckbox.TryClick();
						}
					}
				}

				return false;
			}
			catch (Exception)
			{
				return false;
			}

		}

		internal bool CommentsAreaContains(string contents)
		{
			IWebElement commentBox = this.FindElement(By.XPath(".//h3[text()='Comments']/../../../..//textarea"));

			return contents == commentBox.Text;
		}

		internal bool CommentsCharactersRemaining(int expected, int maximum, out int remainDisplayed)
		{
			IWebElement maxCharacters = this.FindElement(By.XPath("//span[@data-bind='text: maxLength']"));
			IWebElement charactersRemain = this.FindElement(By.XPath("//span[@data-bind='text: maxLength() - field.field().length']"), 2);
			IWebElement commentBox = this.FindElement(By.XPath(".//h3[text()='Comments']/../../../..//textarea"));

			Report.IsTrue(int.TryParse(maxCharacters.Text, out int maxDisplayed),
				"Maximum Characters is displaying " + maxCharacters.Text + " which cannot be parsed into an integer",
				"The maximum allowed caharacters is able to be represented as an integer: " + maxDisplayed);
			Report.IsTrue(int.TryParse(charactersRemain.Text, out remainDisplayed),
				"Remaining Characters is displaying " + charactersRemain.Text + " which cannot be parsed into an integer",
				"The maximum allowed caharacters is able to be represented as an integer: " + remainDisplayed);

			return remainDisplayed == expected;
		}

		// ========= Add Ingredient Functions ========= //

		public bool SetFullNameOfProductForRetailer(string retailer, string name)
		{
			IWebElement el = this.containerElement.FindElement(By.XPath(".//input[@placeholder='Indicate full name of product, as sold, via this retailer (e.g. Private Label Aspirin)' and (./ancestor::td//preceding-sibling::td[contains(text(),'" + retailer + "')]) ]"), 2);
			if (el == null)
			{
				Report.Error("Could not find the Full Product Name field!");
				return false;
			}

			el.EnterText(name);
			return el.GetValue() == name;

		}

		/*===== Safety Data Sheet Authoring ====*/

		public string PersonalProtectionEquipmentRecommended {
			get
			{
				IWebElement lbl = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("Personal Protection Equipment"));

				if (lbl != null)
				{
					ReadOnlyCollection<IWebElement> listOfItems = lbl.FindElements(By.XPath("../..//input"));
					foreach (IWebElement item in listOfItems)
					{
						if (item.Selected)
						{
							string selectedText = item.FindElement(By.XPath("../..//label/span")).Text;
							Report.Info(selectedText + " is selected.");
							return selectedText;
						}
					}
				}
				else
				{
					throw new Exception("Label not found as expected.");
				}

				return "";

			}
			set
			{
				IWebElement lbl = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("Personal Protection Equipment"));

				if (lbl != null)
				{
					IWebElement thisLabel = lbl.FindElements(By.XPath("../..//input/../../label/span")).FirstOrDefault(y => y.Text.Contains(value));
					if (thisLabel != null)
					{
						IWebElement thisInput = thisLabel.FindElement(By.XPath(".//../input"));
						if (!thisInput.Selected)
						{
							thisInput.TryClick();
						}
					}
					else
					{
						throw new Exception("Label for: " + value + " could not be found");
					}
				}
				else
				{
					throw new Exception("Label personal protection equipment recommended could not be found");
				}
			}
		}

		public string AutoignitionTemperature {
			get
			{
				IWebElement lbl = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("Autoignition Temperature"));

				if (lbl != null)
				{
					IWebElement input = lbl.FindElement(By.XPath("../..//input"));
					return input.Text;
				}
				else
				{
					throw new Exception("Label not found as expected.");
				}

			}
			set
			{
				IWebElement lbl = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("Autoignition Temperature"));

				if (lbl != null)
				{
					IWebElement input = lbl.FindElement(By.XPath("../..//input"));
					input.EnterText(value);
				}
				else
				{
					throw new Exception("Label not found as expected.");
				}

			}
		}

		public string MinimumIgnitionEnergy {
			get
			{
				IWebElement lbl = SeleniumBrowser.WebBrowser.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("Ignition"));

				if (lbl != null)
				{
					IWebElement input = lbl.FindElement(By.XPath("../..//input"));
					return input.Text;
				}
				else
				{
					throw new Exception("Label not found as expected.");
				}

			}
			set
			{
				IWebElement lbl = SeleniumBrowser.WebBrowser.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("Ignition"));

				if (lbl != null)
				{
					IWebElement input = lbl.FindElement(By.XPath("../..//input"));
					input.EnterText(value);
				}
				else
				{
					throw new Exception("Label not found as expected.");
				}

			}
		}

		/// <summary>
		/// Technical Name (if applicable) text box
		/// </summary>
		public bool TechnicalName(string text)
		{
			try
			{
				IWebElement el = this.containerElement.FindElement(By.XPath(".//label[text()='Technical Name (if applicable)']/../following-sibling::div//input"), 2);

				if (el != null)
				{
					el.EnterText(text);
					return true;
				}

				return false;
			}
			catch (Exception)
			{
				return false;
			}

		}

		/// <summary>
		/// VOC content in grams ozone per gram text box
		/// </summary>
		public bool VocContentInGrams(string text)
		{
			try
			{
				IWebElement el = this.containerElement.FindElement(By.XPath(".//label[text()='VOC content in grams ozone per gram']/../following-sibling::div//input"), 2);

				if (el != null)
				{
					el.EnterText(text);
					return true;
				}

				return false;
			}
			catch (Exception)
			{
				return false;
			}

		}

		/// <summary>
		/// Proper Shipping Name dropdown
		/// </summary>
		public bool ProperShippingName(string item)
		{
			try
			{
				IWebElement el = this.containerElement.FindElement(By.XPath(".//label[text()='Proper Shipping Name']/..//following-sibling::div//select"), 2);
				el.Select(item);
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		/// <summary>
		/// Hazard Class (select) dropdown
		/// </summary>
		public bool HazardClassSelect(string item)
		{
			try
			{
				IWebElement el = this.containerElement.FindElement(By.XPath(".//label[text()='Hazard Class (select)']/..//following-sibling::div//select"), 2);
				el.Select(item);
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		/// <summary>
		/// Packing Group (select) dropdown
		/// </summary>
		public bool PackingGroupSelect(string item)
		{
			try
			{
				IWebElement el = this.containerElement.FindElement(By.XPath(".//label[text()='Packing Group (select)']/..//following-sibling::div//select"), 2);
				GeneralUtilities.Wait_for_load_finish();
				el.Select(item);
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public string Viscosity {
			get
			{
				IWebElement lbl = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("Viscosity"));

				if (lbl != null)
				{
					IWebElement input = lbl.FindElement(By.XPath("../..//input"));
					return input.Text;
				}
				else
				{
					throw new Exception("Label not found as expected.");
				}

			}
			set
			{
				IWebElement lbl = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("Viscosity"));

				if (lbl != null)
				{
					IWebElement input = lbl.FindElement(By.XPath("../..//input"));
					input.EnterText(value);
				}
				else
				{
					throw new Exception("Label not found as expected.");
				}

			}
		}

		/// <summary>
		/// Flash Point Testing Method Used radio options
		/// </summary>
		public string FlashPointTestingMethodUsed {
			get
			{
				var countries = new List<string>();
				ReadOnlyCollection<IWebElement> listOfOptions = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("Flash Point Testing Method Used"))
					.FindElements(By.XPath("../..//input"));
				foreach (IWebElement item in listOfOptions)
				{
					if (item.Selected)
					{
						return item.FindElement(By.XPath("../..//label")).Text;
					}
				}

				return "";

			}
			set
			{
				IWebElement thisLabel = this.containerElement.FindElements(By.XPath(".//label"), 2).FirstOrDefault(x => x.Text.Contains("Flash Point Testing Method Used")).FindElements(By.XPath("../..//input/../../label/span")).FirstOrDefault(y => y.Text == value);
				IWebElement optionInput = thisLabel.FindElement(By.XPath(".//../input"));
				if (!optionInput.Selected)
				{
					optionInput.Click();
				}
			}

		}

		public string OSHA {
			get => this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("OSHA")).FindElements(By.XPath("../following-sibling::div//label/input"))
					.FirstOrDefault(x => x.Selected).FindElement(By.XPath("./following-sibling::span")).Text;
			set
			{
				IWebElement selectItem = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("OSHA")).FindElements(By.XPath("../following-sibling::div//label/span"))
					.FirstOrDefault(y => y.Text.Contains(value));

				if (selectItem != null)
				{
					selectItem.FindElement(By.XPath("../input")).TryClick();
				}
			}

		}

		/// <summary>
		/// Product does not contain more than 0.05 grams of VOC per use, as defined in the California Consumer Products Regulation radio options
		/// </summary>
		public string ProductDoesNotContainGramsOfVoc {
			get
			{
				var countries = new List<string>();
				ReadOnlyCollection<IWebElement> listOfOptions = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("California Consumer Products Regulation"))
					.FindElements(By.XPath("../..//input"));
				foreach (IWebElement item in listOfOptions)
				{
					if (item.Selected)
					{
						return item.FindElement(By.XPath("../..//label")).Text;
					}
				}

				return "";

			}
			set
			{
				IWebElement thisLabel = this.containerElement.FindElements(By.XPath(".//label"), 2).FirstOrDefault(x => x.Text.Contains("California Consumer Products Regulation")).FindElements(By.XPath("../..//input/../../label/span")).FirstOrDefault(y => y.Text == value);
				IWebElement optionInput = thisLabel.FindElement(By.XPath(".//../input"));
				if (!optionInput.Selected)
				{
					optionInput.Click();
				}
			}

		}

		/// <summary>
		/// Browse and upload for Volatile Organic Compounds
		/// </summary>
		public bool ClickBrowseForVolatileOrganicCompounds()
		{
			try
			{
				IWebElement el = this.containerElement.FindElement(By.XPath("//*[@id='collapse1']/div/form/div[2]/div[2]/div[1]/div/a"), 2);
				if (el == null)
				{
					return false;
				}
				el.TryClick();
				GeneralFunctions.EnterFilename("C:\\Dependencies\\WERCSmart\\testdoc.pdf");
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public bool UploadFileForSection(string section, string pdfFilePath)
		{
			string path = "//span[contains(text(),'" + section + "')]//..//div[@class='ws-dropzone-container invalid']//a";
			IWebElement el = this.containerElement.FindElement(By.XPath(path), 2);
			Report.Info("Clicking Browse for document type: " + section);
			Report.Screenshot();
			if (el == null)
			{
				Report.Error("The browse button was not found!! - Looking for xpath: " + path);
				return false;
			}

			if (!el.TryClick())
			{
				Report.Error("Failed to click the Browse button!");
				return false;
			}
			Delay.Seconds(2);
			Report.Info("Entering file name with path: " + pdfFilePath);
			Report.IsTrue(GeneralFunctions.EnterFilename(pdfFilePath), "Failed to enter file name!", "Successfully entered file name");
			int i = 0;
			string viewPath = "//span[contains(text(),'" + section + "')]//..//span[@class='dz-uploaded-doc']//..//a";
			IWebElement viewEl = this.containerElement.WaitUntilElementVisible(By.XPath(viewPath), 10);
			return viewEl != null;
		}
		//Use this when there are multiple instances of the label type on the documents page. EG. Product label (Generic Private Label and Volatile Organic Compounds)
		public bool UploadFileForSectionAndType(string label, string section, string pdfFilePath)
		{
			//var el = containerElement.FindElement(
			//By.XPath(
			//	".//div[child::label[contains(text(),'" + section + "')]]/following-sibling::div[//span[text()='" + label + "' and not(contains(@style, 'display: none;'))]]//a[text()='Browse']"),
			//2);
			IWebElement el = this.containerElement.FindElement(
				By.XPath(
					".//div[child::label[contains(text(),'" + section + "')]]/following-sibling::div//span[text()='" + label + "' and not(contains(@style, 'display: none;'))]/..//a[text()='Browse']"),
				2);
			if (el == null)
			{
				return false;
			}

			if (!el.TryClick())
			{
				return false;
			}

			GeneralFunctions.EnterFilename(pdfFilePath);

			int i = 0;
			while (this.containerElement.FindElement(By.XPath(".//span[contains(text(),'" + section + "')]//parent::div//a[text()='Remove']"), 2) == null && i < 10)
			{
				i++;
				Delay.Seconds(Delay.SpeedFactor * 1);
			}
			return true;
		}

		public string GetDocumentTypeForSection(string section)
		{
			try
			{
				string xpath = ".//div[child::label[contains(text(),'" + section + "')]]/following-sibling::div[//span[not(contains(@style, 'display: none;'))]]/div[not(contains(@style,'display: none;'))]/span[contains(@data-bind, 'text: Description')]";
				IWebElement labelType = this.containerElement.FindElement(By.XPath(xpath));
				if (labelType == null)
				{
					return null;
				}

				return labelType.Text;
			}
			catch (NoSuchElementException)
			{
				return null;
			}
		}

		public string SectionColour(string section)
		{
			string xPath = @"//div[starts-with(@class,'form-group')]//label[starts-with(text(),""" + section + @""")]";
			IWebElement el = this.containerElement.FindElement(By.XPath(xPath), 2);
			string colour = el?.GetCssValue("color");

			return colour;
		}


		public bool VOCConcentrationQuestionHasYesAndNo()
		{
			IWebElement lbl = this.containerElement.FindElements(By.XPath(".//label"), 2)
				.FirstOrDefault(x => x.Text.Contains("VOC concentration"));

			if (lbl != null)
			{
				ReadOnlyCollection<IWebElement> inputs = lbl.FindElements(By.XPath("../..//input/../span"));
				var options = inputs.Select(x => x.GetValue()).ToList();
				return options.Contains("Yes") && options.Contains("No");
			}
			else
			{
				return false;
			}
		}

		public string VOCConcentrationError()
		{
			IWebElement lbl = this.containerElement.FindElements(By.XPath(".//label"), 2)
				.FirstOrDefault(x => x.Text.Contains("VOC concentration"));

			if (lbl != null)
			{
				try
				{
					IWebElement error = lbl.FindElement(By.XPath("../..//input/../../../p//span"));
					if (error != null)
					{
						return error.Text;
					}
					else
					{
						return null;
					}
				}
				catch (Exception)
				{
					return null;
				}

			}
			else
			{
				throw new Exception("Label not found as expected.");
			}

		}

		public List<string> DisplayedAlerts()
		{
			try
			{
				IList<IWebElement> errors = this.containerElement.FindElements(By.XPath("//div[contains(@class, 'alert')]"), 2);
				return errors.Where(x => x.Displayed).ToList().Select(x => x.GetValue()).ToList();
			}
			catch (Exception)
			{
				return null;
			}
		}

		/// <summary>
		/// Gets statement - Product does not contain more than 0.05 grams of VOC per use, as defined in the California Consumer Products Regulation, Title 17, CCR Division 3, Chapter 1.
		/// </summary>
		public string GetProductDoesNotContainGramsOfVocStatement()
		{
			return this.containerElement.FindElement(By.XPath(".//label[contains(text(),'Product does not contain more than 0.05 grams of VOC per use')]"), 2).Text;
		}

		/// <summary>
		/// Gets statement - Would you like to use the VOC percentages entered for all areas (e.g. country, state, local) for comparison?
		/// </summary>
		public string GetUseVocPercentageAllAreaStatement()
		{
			return this.containerElement.FindElement(By.XPath(".//label[contains(text(),'VOC percentages entered for all areas')]"), 2).Text;
		}

		/// <summary>
		/// Gets statement - Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the CARB
		/// </summary>
		public string GetAmountOfVocDefinedByCARBStatement()
		{
			return this.containerElement.FindElement(By.XPath(".//label[contains(text(),'excluding exempt compounds as defined by the CARB')]"), 2).Text;
		}

		/// <summary>
		/// Gets statement - Verify VOC content is below the threshold of 0.02lb/start of CARB
		/// </summary>
		public string GetVOCContentBelowThresholdOfCARBStatement()
		{
			return this.containerElement.FindElement(By.XPath(".//label[contains(text(),'start of CARB')]"), 2).Text;
		}

		/// <summary>
		/// Gets statement - Verify VOC content is below the threshold of 0.02lb/start of OTC
		/// </summary>
		public string GetVOCContentBelowThresholdOfOTCStatement()
		{
			return this.containerElement.FindElement(By.XPath(".//label[contains(text(),'start of OTC')]"), 2).Text;
		}

		/// <summary>
		/// Gets statement - Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the OTC Model Rule
		/// </summary>
		public string GetAmountOfVocByOTCRuleStatement()
		{
			return this.containerElement.FindElement(By.XPath(".//label[contains(text(),'OTC Model Rule')]"), 2).Text;
			//return el != null;
		}

		/// <summary>
		/// Gets statement - Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the OTC Model Rule
		/// </summary>
		public bool GetAmountOfVocByOTCRuleNotStatement()
		{
			IWebElement el = this.containerElement.FindElement(By.XPath(".//label[contains(text(),'OTC Model Rule')]"), 2);
			return el != null;
		}

		/// <summary>
		/// Gets statement - VOC content in grams ozone per gram
		/// </summary>
		public string GetVocContentInGramsStatement()
		{
			return this.containerElement.FindElement(By.XPath(".//label[contains(text(),'VOC content in grams ozone per gram')]"), 2).Text;
		}

		/// <summary>
		/// Gets statement Based on your selection, you have verified your product contains VOC with intended uses as follows... the CARB VOC compliance limit(s) for the intended use you identified is/are:
		/// </summary>
		public string GetCarbVocComplianceLimitStatement()
		{
			return this.containerElement.FindElement(By.XPath(".//div[contains(@data-bind,'field.field')]//b[contains(text(),'CARB VOC compliance limit')]"), 2)?.Text;
		}

		/// <summary>
		/// Gets error message for VOC content in grams ozone per gram
		/// </summary>
		public string GetErrorMessageForVocContentInGrams()
		{
			return this.containerElement.FindElement(By.XPath(".//label[text()='VOC content in grams ozone per gram']/../following-sibling::div//span"), 2).Text;
		}

		// JS - consolidated  multiple methods to fetch CARB, MVOC etc. value text into one
		/// <summary>
		/// Gets value from Volatile Organic Compound Summary page below the state table. EG. CARB, HVOC, MVOC, OTC Model Rule, VOC Grams Ozone, VOC Analysis
		/// </summary>
		public string GetValueVOCSummary(string category)
		{
			return this.containerElement.FindElement(By.XPath(".//div[contains(@data-bind,'field.field') and contains(text(),'" + category + "')]//b"), 2)?.Text;
		}

		// JS - consolidated multiple methods to fetch statement text (eg. VOC limits, restrictive VOC limit etc) into one
		/// <summary>
		/// Gets statement text from VOC Summary page
		/// </summary>
		public string GetVocSummaryStatementText(string category)
		{
			return this.containerElement.FindElement(By.XPath(".//div[contains(@data-bind,'field.field') and contains(text(),'" + category + "')]"), 2)?.Text;
		}

		/// <summary>
		/// Gets VOC content as weight percentage of total formula, minus exempt compounds, for each of the following states. statement
		/// </summary>
		public string VocWeightPercentageForEachStateStatement()
		{
			return this.containerElement.FindElement(By.XPath(".//div[contains(@data-bind,'description') and contains(text(),'weight percentage of total formula')]"), 2).Text;
		}

		public List<string> GetVOCSummaryStatements()
		{
			ReadOnlyCollection<IWebElement> statements =
				this.containerElement.FindElements(By.XPath(".//div[contains(@class, 'success') and not(.//table)]"));
			return statements.Select(x => x.GetValue().Trim()).ToList();
		}

		public List<VocLimits> GetDisplayedVocLimits()
		{

			var retList = new List<VocLimits>();
			IWebElement tableElement = this.containerElement.FindElement(By.XPath(".//div[./div[text()='Limits']]/following-sibling::table"), 2);
			if (tableElement == null)
			{
				return null;
			}
			IList<IWebElement> rows = tableElement.FindElements(By.XPath(".//tbody//tr"), 2);
			foreach (IWebElement row in rows)
			{
				string use = row.FindElement(By.XPath(".//td[1]"), 2).GetValue();
				string voccompliancelimit = row.FindElement(By.XPath(".//td[2]"), 2).GetValue();
				string regulation = row.FindElement(By.XPath(".//td[3]"), 2).GetValue();
				retList.Add(new VocLimits {
					Use = use,
					VocComplianceLimit = voccompliancelimit,
					Regulation = regulation
				});
			}
			return retList;
		}

		public List<VocLimitsWithUnits> GetDisplayedVocLimitsWithUnits()
		{

			var retList = new List<VocLimitsWithUnits>();
			IWebElement tableElement = this.containerElement.FindElement(By.XPath(".//table[@class='table table-hover table-fixed']"), 2);
			if (tableElement == null)
			{
				return null;
			}
			// James
			// Previously using static indices for each column in the table (Use | Compliance Limits | Units | Regulation)
			// but the 'units' column is sometimes ommited causing null ref exception
			IList<IWebElement> rows = tableElement.FindElements(By.XPath(".//tbody//tr"), 2);
			// Fetch the indices for each column from the headings by name.
			var columnHeadings = tableElement.FindElements(By.XPath(".//thead//th"), 2).ToList();
			int getIndex;
			getIndex = columnHeadings.IndexOf(columnHeadings.FirstOrDefault(x => x.Text == "Use"));
			// If the returned index for any column name is -1, we return a null string for that property.
			string useInd = getIndex == -1 ? null : (getIndex + 1).ToString();
			getIndex = columnHeadings.IndexOf(columnHeadings.FirstOrDefault(x => x.Text == "VOC Compliance Limit"));
			string complianceInd = getIndex == -1 ? null : (getIndex + 1).ToString();
			getIndex = columnHeadings.IndexOf(columnHeadings.FirstOrDefault(x => x.Text == "Units"));
			string unitsInd = getIndex == -1 ? null : (getIndex + 1).ToString();
			getIndex = columnHeadings.IndexOf(columnHeadings.FirstOrDefault(x => x.Text == "Regulation"));
			string regulationInd = getIndex == -1 ? null : (getIndex + 1).ToString();
			foreach (IWebElement row in rows)
			{
				string use = useInd == null ? null : row.FindElement(By.XPath(".//td[" + useInd + "]"), 2).GetValue();
				string voccompliancelimit = complianceInd == null ? null : row.FindElement(By.XPath(".//td[" + complianceInd + "]"), 2).GetValue();
				string units = unitsInd == null ? null : row.FindElement(By.XPath(".//td[" + unitsInd + "]"), 2).GetValue();
				string regulation = regulationInd == null ? null : row.FindElement(By.XPath(".//td[" + regulationInd + "]"), 2).GetValue();
				retList.Add(new VocLimitsWithUnits() { Use = use, VocComplianceLimit = voccompliancelimit, Units = units, Regulation = regulation });
			}
			return retList;
		}

		public List<VocPercentForStates> GetDisplayedVocPercentForEachState()
		{

			var retList = new List<VocPercentForStates>();
			IWebElement tableElement = this.containerElement.FindElement(By.XPath("//div[text()='VOC content as weight percentage of total formula, minus exempt compounds, for each of the following states.']//parent::div//parent::div//following-sibling::table"), 2);
			if (tableElement == null)
			{
				return null;
			}
			IList<IWebElement> rows = tableElement.FindElements(By.XPath(".//tbody//tr"), 2);
			foreach (IWebElement row in rows)
			{
				string state = row.FindElement(By.XPath(".//td[1]"), 2).GetValue();
				string regulation = row.FindElement(By.XPath(".//td[2]"), 2).GetValue();
				string vocvalue = row.FindElement(By.XPath(".//td[3]"), 2).GetValue();
				string statevocthreshold = row.FindElement(By.XPath(".//td[4]"), 2).GetValue();
				string message = row.FindElement(By.XPath(".//td[5]"), 2).GetValue();
				retList.Add(new VocPercentForStates {
					State = state,
					Regulation = regulation,
					VocValue = vocvalue,
					StateVocThreshold = statevocthreshold,
					Message = message
				});
			}

			return retList;

		}

		public string Appearance {
			get
			{
				IWebElement lbl = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("Appearance"));

				if (lbl != null)
				{
					IWebElement input = lbl.FindElement(By.XPath("../..//select"));
					return input.SelectedOption();
				}
				else
				{
					throw new Exception("Label not found as expected.");
				}

			}
			set
			{
				IWebElement lbl = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("Appearance"));

				if (lbl != null)
				{
					IWebElement input = lbl.FindElement(By.XPath("../..//select"));
					input.Select(value);
				}
				else
				{
					throw new Exception("Label not found as expected.");
				}

			}
		}

		public string Odor {
			get
			{
				IWebElement lbl = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("Odor"));

				if (lbl != null)
				{
					IWebElement input = lbl.FindElement(By.XPath("../..//select"));
					return input.SelectedOption();
				}
				else
				{
					throw new Exception("Label not found as expected.");
				}

			}
			set
			{
				IWebElement lbl = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("Odor"));

				if (lbl != null)
				{
					IWebElement input = lbl.FindElement(By.XPath("../..//select"));
					input.Select(value);
				}
				else
				{
					throw new Exception("Label not found as expected.");
				}

			}
		}

		public string OdorThreshold {
			get
			{
				IWebElement lbl = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("Odor Threshold"));

				if (lbl != null)
				{
					IWebElement input = lbl.FindElement(By.XPath("../..//select"));
					return input.SelectedOption();
				}
				else
				{
					throw new Exception("Label not found as expected.");
				}

			}
			set
			{
				IWebElement lbl = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("Odor Threshold"));

				if (lbl != null)
				{
					IWebElement input = lbl.FindElement(By.XPath("../..//select"));
					input.Select(value);
				}
				else
				{
					throw new Exception("Label not found as expected.");
				}

			}
		}

		public string PartitionCoefficient {
			get
			{
				IWebElement lbl = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("Partition Coefficient"));

				if (lbl != null)
				{
					IWebElement input = lbl.FindElement(By.XPath("../..//input"));
					return input.Text;
				}
				else
				{
					throw new Exception("Label not found as expected.");
				}

			}
			set
			{
				IWebElement lbl = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("Partition Coefficient"));

				if (lbl != null)
				{
					IWebElement input = lbl.FindElement(By.XPath("../..//input"));
					input.EnterText(value);
				}
				else
				{
					throw new Exception("Label not found as expected.");
				}

			}
		}

		public bool SetAdditionalOptionInSection(string section, string value)
		{
			// In some cases the below step will not find the correct element - rather than changing this we will create this step which exclusively looks for checkboxes!
			IWebElement el = SeleniumBrowser.WebBrowser.FindElement(By.XPath(@".//span[(.//ancestor::div[starts-with(@class,'form-group')]//label[starts-with(text(),""" + section + @""")]) and contains(text(),'" + value + @"') and not(.//parent::label[contains(@class,'btn')])]/preceding-sibling::input"), 2);
			if (el == null)
			{
				Report.Error("Could not find element");
				return false;
			}

			el.SendKeys(Keys.PageUp);
			Delay.Seconds(1);
			return el.TryClick();
		}

		public List<string> GetDisplayedSections()
		{
			var DisplayedSections = new List<string>();
			IList<IWebElement> els = this.containerElement.FindElements(By.XPath(@"//div[starts-with(@class,'form-group')]/div/label"), 2);
			DisplayedSections = els.Select(x => x.Text).ToList();
			return DisplayedSections;
		}

		public bool ClickAdoptionArticleLink()
		{
			IWebElement link = this.containerElement.FindElement(By.XPath(@"//label[@class='control-label']//a"));
			if (link != null)
			{
				return link.TryClick();
			}
			else
			{
				return false;
			}
		}

		public bool OptionExists(string section)
		{
			try
			{
				string xPath = @"(//span[(.//ancestor::div[starts-with(@class,'form-group')]//label[starts-with(text(),""" + section + @""")]) and (./preceding-sibling::input[@type='checkbox'])]/preceding-sibling::input[@type='checkbox'] | " +
							@"//span[(.//ancestor::div[starts-with(@class,'form-group')]//label[starts-with(text(),""" + section + @""")]) and (./preceding-sibling::input[@type='radio'])]/parent::label | " +
							@"//input[(.//ancestor::div[starts-with(@class,'form-group')]//label[starts-with(text(),""" + section + @""")]) and @type='text'] | " +
							@"//select[(.//ancestor::div[starts-with(@class,'form-group')]//label[starts-with(text(),""" + section + @""")])] | " +
							@"//div[@class='dropzone' and (.//ancestor::div[starts-with(@class,'form-group')]//label[starts-with(text(),""" + section + @""")])] | " +
							@"//span[(.//ancestor::div[starts-with(@class,'form-group')]//label[starts-with(text(),""" + section + @""")]) and not(.//parent::label[contains(@class,'btn')])]/preceding-sibling::input)";

				IWebElement el = this.containerElement.FindElement(By.XPath(xPath), 2);
				return el != null && el.Displayed;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public bool OptionExists(string section, string value)
		{
			string xPath = @"(//span[(.//ancestor::div[starts-with(@class,'form-group')]//label[starts-with(text(),""" + section + @""")]) and contains(text(),'" + value + "') and (./preceding-sibling::input[@type='checkbox'])]/preceding-sibling::input[@type='checkbox'] | " +
						@"//span[(.//ancestor::div[starts-with(@class,'form-group')]//label[starts-with(text(),""" + section + @""")]) and contains(text(),'" + value + "') and (./preceding-sibling::input[@type='radio'])]/parent::label | " +
						@"//input[(.//ancestor::div[starts-with(@class,'form-group')]//label[starts-with(text(),""" + section + @""")]) and @type='text'] | " +
						@"//select[(.//ancestor::div[starts-with(@class,'form-group')]//label[starts-with(text(),""" + section + @""")])] | " +
						@"//span[(.//ancestor::div[starts-with(@class,'form-group')]//label[starts-with(text(),""" + section + @""")]) and contains(text(),'" + value + "') and not(.//parent::label[contains(@class,'btn')])]/preceding-sibling::input)";

			IWebElement el = this.containerElement.FindElement(By.XPath(xPath), 2);

			if (el == null)
			{
				Report.Error("Could not find the correct input in section: " + section);
				return false;
			}

			if (el.TagName.ToLower() == "select")
			{
				return el.FindElements(By.XPath("//option")).Select(x => x.Text.Trim()).Contains(value);
			}

			return false;
		}

		public bool SectionExists(string section)
		{
			string xPath = @"(//span[(.//ancestor::div[starts-with(@class,'form-group')]//label[contains(text(),""" +
						section + @""")]) and (./preceding-sibling::input[@type='checkbox'])]/preceding-sibling::input[@type='checkbox'] | " +
						@"//span[(.//ancestor::div[starts-with(@class,'form-group')]//label[contains(text(),""" +
						section + @""")]) and (./preceding-sibling::input[@type='radio'])]/parent::label | " +
						@"//input[(.//ancestor::div[starts-with(@class,'form-group')]//label[contains(text(),""" +
						section + @""")]) and @type='text'] | " +
						@"//select[(.//ancestor::div[starts-with(@class,'form-group')]//label[contains(text(),""" +
						section + @""")])] | " +
						@"//span[(.//ancestor::div[starts-with(@class,'form-group')]//label[contains(text(),""" +
						section + @""")]) and not(.//parent::label[contains(@class,'btn')])]/preceding-sibling::input)";

			IWebElement el = this.containerElement.FindElement(By.XPath(xPath), 2);

			if (el == null)
			{
				Report.Info("Section unavailable: " + section);
				return false;
			}
			Report.Info("Section exists: " + section);
			return true;
		}

		public bool SetOptionInSectionSubSection(string section, string subSection, string value)
		{
			string xPath = $@"//div[preceding-sibling::div[./label[contains(text(),""{section}"")]]]//div[@class='form-subgroup' and preceding-sibling::div[.//span[contains(text(),'{subSection}')]]]//input[./following-sibling::span[contains(text(),'{value}')]]";
			IWebElement el = this.containerElement.FindElement(By.XPath(xPath), 10);
			if (el == null)
			{
				Report.Info($"Unable to find the input under section {section} and subsection {subSection} option {value}");
				return false;
			}
			if (el.GetAttribute("type") == "checkbox")
			{
				el.TryCheck();
				return el.Checked();
			}
			Report.Info("Method only applicable to checkbox type input");
			return false;
		}

		public bool CheckStandaloneCheckbox(string description)
		{
			IWebElement el = this.StandaloneCheckbox(description);
			return el.TryClick() && GeneralUtilities.Wait_for_load_finish();
		}

		public IWebElement StandaloneCheckbox(string description)
		{
			IWebElement el = this.containerElement.FindElement(By.XPath($@".//div[@class='checkbox' and (.//span[contains(text(),""{description}"")])]/label/input"), 2);
			if (el == null)
			{
				Report.Info($"Could not find checkbox with description: '{description}'");
				return null;
			}
			return el;
		}

		public bool SetOptionInSection(string section, string value)
		{
			string xPath = @"(//span[(.//ancestor::div[starts-with(@class,'form-group')]//label[contains(text(),""" + section + @""")]) and contains(text(),""" + value + @""") and (./preceding-sibling::input[@type='checkbox'])]/preceding-sibling::input[@type='checkbox'] | " +
						@"//span[(.//ancestor::div[starts-with(@class,'form-group')]//label[contains(text(),""" + section + @""")]) and contains(text(),""" + value + @""") and (./preceding-sibling::input[@type='radio'])]/parent::label | " +
						@"//input[(.//ancestor::div[starts-with(@class,'form-group')]//label[contains(text(),""" + section + @""")]) and @type='text'] | " +
						@"//select[(.//ancestor::div[starts-with(@class,'form-group')]//label[contains(text(),""" + section + @""")])] | " +
						@"//span[(.//ancestor::div[starts-with(@class,'form-group')]//label[contains(text(),""" + section + @""")]) and contains(text(),""" + value + @""") and not(.//parent::label[contains(@class,'btn')])]/preceding-sibling::input)";

			IWebElement el = this.containerElement.FindElement(By.XPath(xPath), 10);

			if (el == null)
			{
				Report.Error("Could not find the correct input in section: " + section);
				return false;
			}

			el.ScrollElementIntoView();
			Report.Info("Entering value of: '" + value + "' in section: '" + section + "'");
			if (el.GetAttribute("type") == "text")
			{
				el.EnterText(value);
				return el.GetValue() == value;
			}
			if (el.TagName.ToLower() == "select")
			{
				int i = 0;
				while (i < 10)
				{
					try
					{
						el.Select(value);
						return el.SelectedOption() == value;
					}
					catch (Exception)
					{
						i++;
						Delay.Seconds(1);
					}
				}

				return el.SelectedOption() == value;
			}

			try
			{
				if (el.GetAttribute("type") == "checkbox")
				{
					el.TryCheck();
					return el.Checked();
				}

			}
			catch (Exception)
			{

			}
			// don't click the label if it contains a web link
			if (el.FindElement(By.XPath("./span/a[contains(@href,'http')]"), 2) == null && el.TryClick())
			{
				Delay.Seconds(2);
				if (this.SelectedOptionsForSection(section).Contains(value))
				{
					return true;
				}
			}
			return el.FindElement(By.XPath("./input"), 10).TryClick();
		}

		public bool SelectRadio(string section, string value)
		{
			try
			{
				string xPath = @"//span[(.//ancestor::div[starts-with(@class,'form-group')]//label[contains(text(),""" + section + @""")]) and contains(text(),""" + value + @""") and (./preceding-sibling::input[@type='radio'])]";
				IWebElement el = this.containerElement.FindElement(By.XPath(xPath), 2);
				if (el != null)
				{
					return el.TryClick();
				}

				Report.Error("Could not find the correct input in section: " + section);
				return false;
			}
			catch (Exception)
			{
				return false;
			}
		}

		// NB only works fr select/option
		public bool SetOptionInSectionByValue(string section, string value, string text)
		{
			string xPath = @"//select[(.//ancestor::div[starts-with(@class,'form-group')]//label[starts-with(text(),""" + section + @""")])]";
			IWebElement el = this.containerElement.FindElement(By.XPath(xPath), 2);
			try
			{
				el.SelectByValue(value);
				Delay.Seconds(1);
				return el.SelectedOption() == text;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public bool ClickSelectForSection(string section)
		{
			return this.containerElement.FindElement(By.XPath(@".//select[(.//ancestor::div[starts-with(@class,'form-group')]//label[starts-with(text(),""" + section + @""")])]"), 2).TryClick();
		}

		public List<string> SelectedOptionsForSection(string section)
		{
			IList<IWebElement> matchingElements = this.containerElement.FindElements(By.XPath(@".//div[contains(@class,'form-group') and .//label[contains(text(),""" + section + @""")]]//*[name()='input' or name()='select']"), 2);
			if (matchingElements.Count == 0)
			{
				return new List<string>();
			}
			if (matchingElements.Count == 1 && matchingElements.FirstOrDefault().TagName.ToLower() == "select")
			{
				return new List<string> { matchingElements.FirstOrDefault().SelectedOption() };
			}

			// Assume we have 'input' tags

			if (matchingElements.FirstOrDefault().GetAttribute("type").ToLower() == "checkbox" || matchingElements.FirstOrDefault().GetAttribute("type").ToLower() == "radio")
			{
				// In this case, we should return all the selected options
				return matchingElements.Where(x => x.Checked()).Select(x => x.FindElement(By.XPath(".//following-sibling::span"), 2).Text.Trim()).ToList();
			}
			if (matchingElements.FirstOrDefault().GetAttribute("type").ToLower() == "text")
			{
				string rText = "";
				if (!matchingElements.First().Text.IsNullOrEmpty())
				{
					rText = matchingElements.First().Text;
				}
				else if (!matchingElements.First().GetValue().IsNullOrEmpty())
				{
					rText = matchingElements.First().GetValue();
				}
				return new List<string> { rText };
			}
			return null;
		}

		public bool SetAllCheckOptionsInSection(string section, bool check)
		{
			string xpath = @"//span[(.//ancestor::div[starts-with(@class,'form-group')]//label[contains(text(),""" + section + @""")])]/preceding-sibling::input";
			IList<IWebElement> els = this.containerElement.FindElements(By.XPath(xpath), 2);
			foreach (IWebElement el in els)
			{
				el.Check(check);
			}

			return true;
		}

		public string VocAnalysisDateStatement()
		{
			IWebElement vocAnalysisDateStatement =
				this.containerElement.FindElement(
					By.XPath(@"//div[contains(text(), 'VOC Analysis Date') and ancestor::div[@class='form-group has-success']]"));
			return vocAnalysisDateStatement?.Text;
		}

		public int RadioButtonCountInSection(string section)
		{
			string xpath = @"//div[./label[contains(text(), """ + section + @""")]]/following-sibling::div//div[@class='radio']";
			IList<IWebElement> radios = this.containerElement.FindElements(By.XPath(xpath), 2);
			return radios?.Count ?? 0;
		}

		public List<string> RadioButtonsInSection(string section)
		{
			string xpath = @"//div[./label[contains(text(), """ + section + @""")]]/following-sibling::div//div[@class='radio']//span";
			IList<IWebElement> radios = this.containerElement.FindElements(By.XPath(xpath), 2);
			if (radios.Count == 0)
			{
				Report.Failure("There were no radios showing in section: " + section);
				return new List<string>();
			}
			return radios.Select(x => x.Text).ToList();
		}

		// Currently deals with select (option) and input (radio)
		public List<string> GetAllOptionsForSection(string section)
		{
			Delay.Seconds(1);
			Report.Info("Beginning get all options for section.");
			var optionsText = new List<string>();
			IList<IWebElement> matchingElements = SeleniumBrowser.WebBrowser.FindElements(By.XPath(@".//div[contains(@class,'form-group') and .//label[contains(text(),""" + section + @""")]]//*[name()='input' or name()='select']"), 2);
			if (matchingElements.Count == 1 && matchingElements.FirstOrDefault().TagName.ToLower() == "select")
			{
				optionsText = matchingElements.FirstOrDefault().FindElements(By.XPath(@"./option")).Select(x => x.Text).Where(x => x != "Choose...").ToList();
				// Occasionally needs some time to refresh the options in the drop down depending on the previous selection
				for (int i = 0; i < 5; i++)
				{
					optionsText = matchingElements.FirstOrDefault().FindElements(By.XPath(@"./option")).Select(x => x.Text).Where(x => x != "Choose...").ToList();
					if (optionsText.Count > 0)
					{
						break;
					}
					Delay.Seconds(1);
				}
				return optionsText;
			}
			Report.Info("Found " + matchingElements.Count.ToString());
			optionsText = matchingElements.Select(x => x.FindElement(By.XPath(@"./following-sibling::span"), 2).Text).ToList();
			Report.Info("Returning: " + string.Join(",", optionsText));
			return optionsText;
		}

		public List<string> RegulatoryInformationLabelLinks()
		{
			var linksText = new List<string>();
			linksText = this.containerElement.FindElements(By.XPath(".//a[@class='link-publication']")).Select(x => x.Text).ToList();
			return linksText;
		}

		public bool AddDocument(string documentName, string language)
		{
			IWebElement rowContainer = this.containerElement.FindElement(By.XPath(".//span[text()='" + documentName + "']//ancestor::div[contains(@class,'document-row')]"), 2);
			if (rowContainer == null)
			{
				return false;
			}

			//rowContainer.FindElement(By.XPath(".//input[@type='search']"), 2).TryClick();
			IWebElement selectEl = rowContainer.FindElement(By.XPath(".//div[@class='add-language']//select"), 10);
			selectEl.Select(language);

			return selectEl.SelectedOption() == language;

		}

		public List<string> GetSelectedLanguagesForDocument(string documentName)
		{
			IWebElement rowContainer = this.containerElement.FindElement(By.XPath(".//span[text()='" + documentName + "']//ancestor::div[contains(@class,'document-row')]"), 2);
			int i = 0;
			while (i < 10 && rowContainer == null)
			{
				Delay.Seconds(Delay.SpeedFactor * 2);
				rowContainer = this.containerElement.FindElement(By.XPath(".//span[text()='" + documentName + "']//ancestor::div[contains(@class,'document-row')]"), 2);
			}

			if (rowContainer == null)
			{
				return null;
			}

			IList<IWebElement> el = rowContainer.FindElements(By.XPath(".//span[@class='selection']//li[not(.//input)]"), 2);

			return el.Select(x => x.GetElementText().Replace("×", "").Trim()).ToList();
		}

		//public string GetEPATableError()
		//{
		//	return containerElement.FindElement(By.XPath(@".//div[@class ='panel-heading']/following-sibling::table/following-sibling::div/p[@class='form-error']/span"), 15)?.Text;
		//}

		public bool ClickUseMyIngredients()
		{
			return this.containerElement.FindElement(By.XPath(".//button[starts-with(@data-bind,'click: openMyIngredients')]"), 2).TryClick() && GeneralUtilities.Wait_for_load_finish();
		}

		public bool EnterAdditionalRequirement(string retailerName, string valueToEnter)
		{
			ReadOnlyCollection<IWebElement> selectedRetailersNames = this.containerElement.FindElements(By.XPath(".//div[@class='grid-container']//tr[parent::tbody[@data-bind='foreach: field.field']]/td[@class='col-xs-3']"));
			IWebElement matchingRetailer = selectedRetailersNames.FirstOrDefault(x => x.GetValue().Trim().ToLower() == retailerName.ToLower());
			if (matchingRetailer == null)
			{
				Report.Info("No matching retailer was found in selected retailers: " + retailerName);
				return false;
			}

			IWebElement additionalRequirementInput = matchingRetailer.FindElement(By.XPath("..//input[@type='text']"), 2);
			if (additionalRequirementInput == null)
			{
				Report.Info("No input was found for retailer: " + retailerName);
				return false;
			}

			additionalRequirementInput.EnterText(valueToEnter);

			return additionalRequirementInput.GetValue() == valueToEnter;

		}

		public string VOCContentInGPerL()
		{
			return this.containerElement.FindElement(By.XPath(".//div[contains(@data-bind,'field.field') and starts-with(text(), 'VOC content in g/L')]/b")).Text;
		}

		public List<string> AllAdditionalStatements()
		{
			string xPath = ".//div[@data-bind='html: field.field' and parent::div[@class='col-sm-12']]";
			IList<IWebElement> statements = this.containerElement.FindElements(By.XPath(xPath), 2);
			if (statements.IsNullOrEmpty())
			{
				return new List<string>();
			}
			return statements.Select(x => x.Text.Trim()).ToList();
		}

		public List<string> AllAdditionalStatementParagraphs()
		{
			string xPath = @".//div[@data-bind='html: field.field' and parent::div[@class='col-sm-12']]/p";
			IList<IWebElement> paragraphs = this.containerElement.FindElements(By.XPath(xPath), 2);
			if (paragraphs.IsNullOrEmpty())
			{
				return new List<string>();
			}
			return paragraphs.Select(x => x.Text.Trim()).ToList();
		}

		// Click an individual checkbox by section and value. (check if unchecked, uncheck if checked). Report the checked state before and after.
		public bool ClickCheckbox(string section, string value)
		{
			string xPath = "//span[(.//ancestor::div[starts-with(@class,'form-group')]//label[starts-with(text(),'" + section + "')]) and contains(text(),'" + value + "') and (./preceding-sibling::input[@type='checkbox'])]/preceding-sibling::input[@type='checkbox']";
			IWebElement box = this.containerElement.FindElement(By.XPath(xPath), 2);
			if (box.Checked())
			{
				Report.Info(string.Format("The checkbox for section '{0}' and option '{1}' is checked. It is now being unchecked", section, value));
				return box.TryClick();
			}
			Report.Info(string.Format("The checkbox for section '{0}' and option '{1}' is unchecked. It is now being checked", section, value));
			return box.TryClick();
		}

		// If a Shared Step does not specify a compulsory field input, fetch that section name so we can select an option and continue test after reporting the fail
		public string SectionWithRequiredFieldError()
		{
			try
			{
				string xPath = "//div[.//p[@class='form-error' and .//span[contains(text(),'This is a required field.')]] and @class='form-group has-feedback has-error']//label[@class='control-label']";
				IWebElement section = this.containerElement.FindElement(By.XPath(xPath), 2);
				section.ScrollElementIntoView();
				return section.Text;
			}
			catch (Exception)
			{
				return null;
			}
		}

		public IWebElement Table()
		{
			return this.containerElement.FindElement(By.XPath(@".//div[@class ='panel-heading']/following-sibling::table"), 10);
		}

		public string TableHeading()
		{
			IWebElement heading = this.Table().FindElement(By.XPath("./preceding-sibling::div[@class='panel-heading']"), 2);
			if (heading == null)
			{
				Report.Error("Could not find EPA table header");
				return null;
			}
			return heading.Text;
		}

		public List<string> TableColumnHeadings()
		{
			IWebElement table = this.Table();
			if (table == null)
			{
				Report.Error("Table element was not visible!");
				return new List<string>();
			}
			var rList = new List<string>();
			var columnHeaders = table.FindElements(By.XPath(".//th"), 2).ToList();
			columnHeaders.ForEach(x => rList.Add(x.Text));
			return rList;
		}

		/// <summary>
		/// New Product - The Product. Return name and ID of all options under Product Line or Brand
		/// </summary>
		public List<MyBrands.Brand> AllProductLineOrBrandOptions()
		{
			var rList = new List<MyBrands.Brand>();
			IWebElement el = this.containerElement.FindElement(By.XPath(".//label[contains(text(),'Product Line')]/../following-sibling::div//select"), 2);
			if (el == null)
			{
				Report.Failure("Could not locate the Product Line or Brand option");
				return null;
			}
			var options = el.FindElements(By.XPath("./option"), 2).Where(x => x.Text != "Choose...").ToList();
			foreach (IWebElement option in options)
			{
				var brand = new MyBrands.Brand { ID = option.GetAttribute("value"), Name = option.Text };
				rList.Add(brand);
			}
			return rList;
		}

		public bool SetSubOptionInSection(string section, string subsection, string value)
		{
			string xPath = @"(//span[(.//ancestor::div[starts-with(@class,'form-group')]//label[starts-with(text(),""" + section + @""")]) and contains(text(),'" + value + "') and (./preceding-sibling::input[@type='checkbox'])]/preceding-sibling::input[@type='checkbox'] | " +
						@"//span[(.//ancestor::div[starts-with(@class,'form-group')]//label[starts-with(text(),""" + section + @""")]) and contains(text(),'" + value + "') and (./preceding-sibling::input[@type='radio'])]/parent::label | " +
						@"//input[(.//ancestor::div[starts-with(@class,'form-group')]//label[starts-with(text(),""" + section + @""")]) and @type='text'] | " +
						@"//select[(.//ancestor::div[starts-with(@class,'form-group')]//label[starts-with(text(),""" + section + @""")])] | " +
						@"//span[(.//ancestor::div[starts-with(@class,'form-group')]//label[starts-with(text(),""" + section + @""")]) and contains(text(),'" + value + "') and not(.//parent::label[contains(@class,'btn')])]/preceding-sibling::input)";

			IWebElement el = this.containerElement.FindElement(By.XPath(xPath), 2);

			if (el == null)
			{
				Report.Error("Could not find the correct input in section: " + section);
				return false;
			}
			Report.Info("Entering value of: '" + value + "' in section: '" + section + "'");

			if (el.GetAttribute("type") == "text")
			{
				el.EnterText(value);
				return el.GetValue() == value;
			}

			if (el.TagName.ToLower() == "select")
			{
				int i = 0;
				while (i < 10)
				{
					try
					{
						el.Select(value);
						return el.SelectedOption() == value;
					}
					catch (Exception)
					{
						i++;
						Delay.Seconds(1);
					}
				}

				return el.SelectedOption() == value;
			}

			if (el.GetAttribute("type") == "checkbox")
			{
				el.TryCheck(true);
				return el.Checked();
			}

			return el.TryClick();
		}

		public Alert GetAlert()
		{
			var thisAlert = new Alert();

			thisAlert.Title = this.containerElement
				.FindElement(By.XPath(".//div[contains(@class,'alert')]/p[contains(@class, 'text-danger')]/strong"))
				.Text;
			thisAlert.SubTitle = this.containerElement
				.FindElement(By.XPath(".//div[contains(@class,'alert')]/p[contains(@class, 'text-danger')]")).GetInnerText();

			thisAlert.Text = this.containerElement
				.FindElement(By.XPath(
					".//div[contains(@class,\'alert\')]/p[contains(@class, \'text-danger\')]/following-sibling::p"))
				.Text;

			thisAlert.Links = this.containerElement
				.FindElements(By.XPath(
					".//div[contains(@class,\'alert\')]/p[contains(@class, \'text-danger\')]/following-sibling::p/a"))
				.Select(x => new Mailosaur.Link() {
					Href = x.GetAttribute("href"),
					Text = x.Text
				}).ToList();

			return thisAlert;
		}

		public bool ClickAlertLink(string linkText)
		{
			return this.containerElement
				.FindElements(By.XPath(
					".//div[contains(@class,\'alert\')]/p[contains(@class, \'text-danger\')]/following-sibling::p/a"))
				.FirstOrDefault(x => x.Text == linkText).TryClick();
		}

		public void MoveToLabel(string section)
		{
			try
			{
				string xPath = @"(//label[starts-with(text(),""" + section + @""")]))";
				SeleniumBrowser.WebBrowser.FindElement(By.XPath(xPath), 2).TryClick();
			}
			catch (Exception)
			{

			}
		}

		public string FormError()
		{
			return this.containerElement.FindElement(By.XPath(".//ul[@class='form-error']/li"), 2)?.Text;
		}

		public bool SelectPackageType(string packageType)
		{
			IWebElement container = this.containerElement.FindElement(By.XPath(".//table[@class='table table-hover upc-table']"), 2);
			IWebElement upcNumberField = container.FindElement(By.XPath(".//label[contains(text(),'UPC Number')]/..//input"), 2);

			IWebElement pkgType = container.FindElement(By.XPath(".//select[contains(@data-bind,'Package Type')]"), 2);
			pkgType.Select(packageType);
			return pkgType.GetValue() == packageType;
		}

		public List<string> GetPackageOptions()
		{
			IWebElement container = this.containerElement.FindElement(By.XPath(".//table[@class='table table-hover upc-table']"), 2);
			IWebElement upcNumberField = container.FindElement(By.XPath(".//label[contains(text(),'UPC Number')]/..//input"), 2);

			IWebElement pkgType = container.FindElement(By.XPath(".//select[contains(@data-bind,'Package Type')]"), 2);
			return pkgType.FindElements(By.XPath(".//option")).Select(x => x.GetValue()).ToList();
		}

		internal void SetProductName(string productType)
		{
			IWebElement productName = this.containerElement.FindElement(By.XPath(@"//*[@id='collapse1']/div/form/div[1]/div[2]/input"));
			productName.EnterText(productType);
		}

		public bool PurchaseSummaryClickRemove(string product)
		{
			IWebElement remove = SeleniumBrowser.WebBrowser.FindElement(By.XPath(@"//table[@class='table table-hover']//tr//b[text()[contains(.,""" + product + @""")]]/following-sibling::a[contains(text(), 'Remove')]"), 2);
			return remove.TryClick();
		}

		public bool ExpandArrowforUPC(string upc)
		{
			try
			{
				if (upc.ToLower().Contains("saved as"))
				{
					upc = Context.GetFromContext(upc.Replace("saved as", "", StringComparison.InvariantCultureIgnoreCase).Trim()).ToString();
				}
				if (upc == null)
				{
					Report.Failure("Could not find UPC number in context saved as: " + upc);
					return false;
				}
				Report.Info("Attempting to click expand arrow for: " + upc);
				IWebElement container = this.containerElement.FindElement(By.XPath(".//table[@class='table table-hover upc-table']"), 2);
				IWebElement upcmatch = container.FindElements(By.XPath(".//span[contains(@data-bind,'upc')]"), 2).FirstOrDefault(x => x.Text.Contains(upc))
								?? container.FindElements(By.XPath(".//span[contains(@data-bind,'upc')]"), 2).FirstOrDefault(x => x.GetValue().Contains(upc))
							   ?? container.FindElements(By.XPath(".//input[contains(@data-bind,'upc')]"), 2).FirstOrDefault(x => x.GetValue().Contains(upc));
				if (upcmatch == null)
				{
					return false;
				}
				if (!upcmatch.FindElement(By.XPath("./ancestor::tr[position()=1]//a[@title='Expand']"), 2).TryClick())
				{
					Report.Info("Failed to find arrow");
					return false;
				}
				Report.Info("Successfully clicked expand arrow.");
				Report.Screenshot();
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}



		public bool CheckInputFieldXIsColor(string expectedColor, string fieldName)
		{
			bool fieldIsCorrectColor = false;

			Report.Info($"Looking at the input field with label {fieldName}");

			Report.Info($"Exepcted Color is: {expectedColor}");

			IWebElement inputField;
			IWebElement parentContainer;


			string expectedColorCode;


			List<IWebElement> parentContainers = this.containerElement.FindElements(By.XPath($".//div[contains(@data-bind,'visible: DocumentID().length') and .//span[contains(text(),'{fieldName}')]]"), 2).ToList();
			parentContainer = parentContainers.FirstOrDefault(x => x.Displayed);
			if (parentContainer == null)
			{
				Report.Failure("Could not find the Parent Container for the input field");
				return false;
			}

			inputField = parentContainer.FindElement(By.XPath(".//div[contains(@class,'dropzone')]"), 2);
			if (inputField == null)
			{
				Report.Failure("Could not find input field element");
				return false;
			}

			switch (expectedColor)
			{
				case "Green":
					expectedColorCode = "rgba(240, 255, 240, 1)";
					//parentContainer = this.containerElement.FindElement(By.XPath($".//div[@data-bind='visible: DocumentID().length > 0' and .//span[contains(text(),'{fieldName}')]]"), 2);
					//inputField = parentContainer.FindElement(By.XPath(".//div[@class='ws-dropzone-container']"), 2);
					break;

				case "Red":
					expectedColorCode = "rgba(255, 240, 240, 1)";
					//parentContainer = this.containerElement.FindElement(By.XPath($".//div[@data-bind='visible: DocumentID().length == 0' and .//span[contains(text(),'{fieldName}')]]"), 2);
					//inputField	= parentContainer.FindElement(By.XPath(".//div[@class='dropzone']"), 2);

					break;
				default:
					Report.Error("expectedColor must be either: 'Red' or 'Green'");
					return false;


			}

			string inputFieldColor = inputField.GetCssValue("background-color");

			if (expectedColorCode == inputFieldColor)
			{
				Report.Success($"The color of the input field was the color {expectedColor} as expected");
				fieldIsCorrectColor = true;
			}
			else
			{
				Report.Failure($"The color of the input field was not the expected color of {expectedColor}");
			}


			return fieldIsCorrectColor;

		}

		public bool FinalDomesticDistributor(string text)
		{
			try
			{
				IWebElement el = this.containerElement.FindElement(By.XPath(".//label[text()='Who is the Final Domestic Distributor (if any) of the product?']/../following-sibling::div//input"), 2);

				if (el != null)
				{
					el.EnterText(text);
					return true;
				}

				return false;
			}
			catch (Exception)
			{
				return false;
			}

		}
		public bool CompanyTollFreePhoneNumber(string text)
		{
			try
			{
				IWebElement el = this.containerElement.FindElement(By.XPath(".//label[contains(text(),'Toll-Free Phone Number')]/../following-sibling::div//input"), 2);

				if (el != null)
				{
					el.EnterText(text);
					return true;
				}

				return false;
			}
			catch (Exception)
			{
				return false;
			}

		}

		public bool CompanyWebAddress(string text)
		{
			try
			{
				IWebElement el = this.containerElement.FindElement(By.XPath(".//label[contains(text(),'Company Web Address')]/../following-sibling::div//input"), 2);

				if (el != null)
				{
					el.EnterText(text);
					return true;
				}

				return false;
			}
			catch (Exception)
			{
				return false;
			}

		}

		public string ProductGTINBrickCode {
			get
			{
				IWebElement el = this.containerElement.FindElement(By.XPath(".//label[contains(text(),'GTIN')]/..//following-sibling::div//select"), 2);
				return el.SelectedOption();
			}
			set
			{
				IWebElement el = this.containerElement.FindElement(By.XPath(".//label[contains(text(),'GTIN')]/..//following-sibling::div//select"), 2);
				el.Select(value);
			}
		}

		public bool ClickAddPartNumber()
		{
			IWebElement el = this.containerElement.FindElement(By.XPath(".//button[contains(@data-bind,'PartNumber')]"), 2);
			return el != null && el.TryClick();
		}



		public bool InputPartNumberInformation(UpcInformation info,string partNumber)
		{
			try
			{
				IWebElement container = this.containerElement.FindElement(By.XPath(".//table[@class='table table-hover upc-table']"), 2);
				IList<IWebElement> textInputs = container.FindElements(By.XPath("//input[@type = 'text']"), 2);
				IWebElement ProductNameOnlabel = container.FindElement(By.XPath(".//label[contains(text(),'Product Name on Label')]/..//input"), 2);
				IWebElement partNameTextField = container.FindElement(By.XPath(".//label[contains(text(),'Part Number')]/..//input"), 2);
				IWebElement productNameOnlabelObj = container.FindElement(By.XPath(".//label[contains(text(),'Product Name on Label')]/.."), 2);

				string productNameDataBind = productNameOnlabelObj.GetAttribute("class");
				if (productNameDataBind != null)
				{
					if (!productNameDataBind.Contains("form-group has-success"))
					{
						ProductNameOnlabel.EnterText("UPCName PlaceHolder");
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

							ProductNameOnlabel.EnterText(info.UPCName);
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

				



				if (info.ContainerType.ToLower() != "none")
				{
					IWebElement containsType = container.FindElement(By.XPath(".//select[contains(@data-bind,'Container Type')]"), 2);
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
				if (info.Dpci.Length > 0)
				{
					IWebElement dpciField = container.FindElement(By.XPath(".//input[contains(@data-bind,'value.field')]"), 2);
					dpciField.EnterText(info.Dpci);
				}
				if (info.Quantity.Length > 0)
				{
					IWebElement quantityField = container.FindElement(By.XPath(".//input[@placeholder='Quantity']"), 2);
					quantityField.EnterText(info.Quantity);
				}

				if (info.PackageType.Length > 0)
				{
					IWebElement packageField = container.FindElement(By.XPath(".//select[contains(@data-bind,'Package Type')]"), 2);
					packageField.Select(info.PackageType);
				}

				if (partNameTextField == null)
				{
					Report.Info(@"Failed to find 'Size' input in the format ""Size (.. Ounces)""");
					return false;
				}
				partNameTextField.EnterText(partNumber);
				return true;
			}
			catch (Exception ex)
			{
				Report.Info(ex.Message);
				return false;
			}
		}



	}

	public class ProductInformation
	{
		public string Name { get; set; }

		public string Id { get; set; }

		internal List<Ingredients.Ingredient> ListOfIngredients { get; set; }
	}

	public class Battery
	{
		public string BatteryType { get; set; }
		public string Manufacturer { get; set; }

		public int NumberPerPackage { get; set; }
		public int RequiredToRun { get; set; }

		public string SavedAs { get; set; }
	}

	public class UpcInformation
	{
		public string UpcNumber { get; set; } = "";
		public string ContainerType { get; set; } = "";
		public string Size { get; set; } = "";
		public string Dpci { get; set; } = "";
		public string Quantity { get; set; } = "";
		public string PackageType { get; set; } = "";
		public string UPCName { get; set; } = "";

	}

	public class VocLimits
	{
		public string Use { get; set; }
		public string VocComplianceLimit { get; set; }
		public string Regulation { get; set; }
	}

	public class VocLimitsWithUnits
	{
		public string Use { get; set; }
		public string VocComplianceLimit { get; set; }
		public string Units { get; set; }
		public string Regulation { get; set; }
	}

	public class VocPercentForStates
	{
		public string State { get; set; }
		public string Regulation { get; set; }
		public string VocValue { get; set; }
		public string StateVocThreshold { get; set; }
		public string Message { get; set; }
	}

	public class Alert
	{
		public string Title { get; set; }
		public string SubTitle { get; set; }
		public string Text { get; set; }

		public List<Mailosaur.Link> Links { get; set; }
	}

	class RegulatoryList : SeleniumBaseObject
	{
		public const string BasePath = "//div[@class='modal fade in']";
		protected override By ContainerElementLocator => By.XPath(BasePath);

		public string Heading()
		{
			return this.containerElement.FindElement(By.XPath(".//h3"), 2)?.Text;
		}

		public bool ClickClose()
		{
			return this.containerElement.FindElement(By.XPath(".//button[@class='close']"), 2).TryClick();
		}
		public class RegulatoryListItem
		{
			public string RegulatoryCode { get; set; }
			public string Classification { get; set; }
		}
		public List<RegulatoryListItem> GetRegulatoryListRows()
		{
			var rList = new List<RegulatoryListItem>();
			ReadOnlyCollection<IWebElement> rows = this.containerElement.FindElements(By.XPath(".//tbody/tr"));
			foreach (IWebElement row in rows)
			{
				rList.Add(new RegulatoryListItem {
					Classification = row.FindElement(By.XPath("./td[@class = 'col-xs-3']"), 2)?.Text,
					RegulatoryCode = row.FindElement(By.XPath("./td[@class = 'col-xs-9']"), 2)?.Text
				});
			}
			return rList;
		}
	}

	public class InputError
	{
		public string InputName { get; set; }
		public IWebElement Input { get; set; }
		public string ErrorMessage { get; set; }
	}
}
