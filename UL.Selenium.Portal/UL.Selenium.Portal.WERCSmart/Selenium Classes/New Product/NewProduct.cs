using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Classes;
using UL.Automation.WebDriver.Extensions;
using UL.Automation.Utilities.Functions;
using UL.Automation.Reporting.Functions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using UL.Automation.ReqnrollHelpers.Classes;
using System.Collections.ObjectModel;
using UL.Selenium.Portal.WERCSmart.Classes;
using Reqnroll;
using TReVor.Api.Wrapper.Classes;
using UL.Automation.Reporting;
using UL.Automation.WebDriver.Functions;
using UL.Automation.TReVor.Classes;
using UL.Selenium.Portal.WERCSmart.Steps.New_Product;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Chrome;
using System.Net.NetworkInformation;


namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product
{
	public class NewProduct : SeleniumBaseObject
	{
		protected override By ContainerElementLocator => By.XPath("//body");
		IWebElement InputField(string fieldName) => this.ContainerElement.FindElement(By.XPath($".//input[@placeholder='{fieldName}']"), 2);
		IWebElement LinkElement(string linkText) => this.ContainerElement.FindElement(By.XPath($".//a[text()='{linkText}'] | .//a//span[text()='{linkText}']"), 2);
		IWebElement Button(string button) => this.ContainerElement.FindElement(By.XPath($"//button//span[text() = '{button}'] | .//a[text() = '{button}'] | //button[text() = '{button}']"), 2);
		IWebElement Table(string tableName) => this.ContainerElement.FindElement(By.XPath($"//div[div[text() = '{tableName}']]/following-sibling::table"), 2);
		IWebElement TextOnThePage(string text) => this.ContainerElement.FindElement(By.XPath($"//div//*[text() = \"{text}\"]"),2);

		public bool TextExistsOnThePage(string text)
		{
			Report.Info($"Attempting to confirm text {text} exists on the page");
			return this.TextOnThePage(text) != null;
		}
		public bool ButtonExists(string button)
		{
			return this.Button(button) != null;
		}
		public bool ButtonClick(string button)
		{
			return this.Button(button).TryClick();
		}

		public bool InputFieldExists(string fieldName)
		{
			return this.InputField(fieldName) != null;
		}
		public bool LinkElementExists(string linkText)
		{
			return this.LinkElement(linkText) != null;
		}
		public bool LinkElementClick(string linkText)
		{
			return this.LinkElement(linkText).TryClick();
		}
		public bool TableExists(string tableName)
		{
			return this.Table(tableName).Displayed;
		}

		#region web elements
		private IWebElement Header => this.ContainerElement.FindElement(By.XPath(".//div[@class='product-header']/h2"), 5);

		private IWebElement ProgressBar => this.ContainerElement.FindElement(By.XPath(".//div[@class='prog-wizard']"), 5);

		private IWebElement ErrorMessage => this.ContainerElement.FindElement(By.XPath(".//p[@class='form-error']//span"), 1);

		private IEnumerable<IWebElement> ErrorMessages => this.ContainerElement.FindElements(By.XPath(".//p[@class='form-error']//span"), 1);

		private IWebElement ContinueButton => this.ContainerElement.WaitUntilElementClickable(By.XPath(".//a[contains(@class,'continue-button')]"), 5);

		private IEnumerable<IWebElement> PanelHeadings => this.ContainerElement.FindElements(By.XPath(".//div[@id='pgroup']/div/div[starts-with(@class,'panel-heading')]//h3"), 2);

		private By ActivePanelHeadingLocator(string text) => By.XPath($@".//div[@id='pgroup']/div/div[@class='panel-heading']//h3[contains(text(),""{text}"")]");

		private IWebElement ActivePanelHeading => this.ContainerElement.FindElement(By.XPath(".//div[@id='pgroup']/div/div[@class='panel-heading']//h3"), 2);

		private IEnumerable<IWebElement> SectionControlLabels => this.ContainerElement.FindElements(By.XPath(".//label[@class='control-label']"), 1);

		private IWebElement LabelContains(string lblContains) => this.ContainerElement.FindElement(By.XPath($@".//label[contains(text(),""{lblContains}"")]"), 1);

		private IWebElement BoldElementContains(string bContains) => this.ContainerElement.FindElement(By.XPath($@".//b[contains(text(),""{bContains}"")]"), 1);

		private IWebElement TransLevelInput(string option, string transLevel) => this.ContainerElement.FindElement(By.XPath(@"//div[@id='dataentry']//span[text()='" + option + "']/../div//span[text()='" + transLevel + "']//preceding-sibling::input"), 2);

		private IWebElement Exception1 => this.ContainerElement.FindElement(By.XPath(@"//div//span[contains(text(), '173.150(g)(1)(A)')]/preceding-sibling::input"), 2);
		private IWebElement Exception2 => this.ContainerElement.FindElement(By.XPath(@"//div//span[contains(text(), '173.150(g)(1)(I)(B)')]/preceding-sibling::input"), 2);
		private IWebElement Exception3 => this.ContainerElement.FindElement(By.XPath(@"//div//span[contains(text(), '173.150(g)(1)(II)(A)')]/preceding-sibling::input"), 2);
		private IWebElement Exception4 => this.ContainerElement.FindElement(By.XPath(@"//div//span[contains(text(), '173.150(g)(1)(II)(B)')]/preceding-sibling::input"), 2);

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
			IList<IWebElement> els;
			if (section == "Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations." || section == "Product has been granted an Alternative Control Plan")
			{

				var elsFound = this.ContainerElement.FindElements(By.XPath("//ancestor::div[starts-with(@class,'form-group')]//div[@class='col-sm-4']"), 2).ToList();
				var upperEl = elsFound.First(x => x.Text.Contains(section));
				els = upperEl.FindElements(By.XPath($".//following-sibling::div[1]//p[@class='form-error']//span"), 2);

			}
			else
			{
				els = this.ContainerElement.FindElements(By.XPath(@$".//span[(.//ancestor::p[@class='form-error']) and (.//ancestor::div[starts-with(@class, 'form-group')]//label[starts-with(normalize-space(text()),'{section}')])]"), 2);
			}			
			return els.Count == 0 ? new List<string>() : els.Select(x => x.Text).ToList();
		}

		public string GetErrorForSection(string section)
		{
			IWebElement el = this.ContainerElement.FindElement(By.XPath(@".//span[(.//ancestor::p[@class='form-error']) and (.//ancestor::div[starts-with(@class, 'form-group')]//label[starts-with(text(),""" + section + @""")])]"), 2);
			return el?.Text;
		}

		public List<InputError> GetAllErrors()
		{
			string regexPattern = @"(?:optionsCaption:\s*[\'\""])(.*)[\'\""]";

			System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> errorInputs = this.ContainerElement.FindElements(By.XPath("//p[@class='form-error' and not(contains(@style, 'none'))]/../input|//p[@class='form-error' and not(contains(@style, 'none'))]/../select"));

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
			return this.ContainerElement.WaitUntilElementVisible(this.ActivePanelHeadingLocator(sectionHeader), secondsToWait) != null;
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

			if (this.ProgressBar?.WaitUntilElementVisible(By.XPath($".//div[@class= 'prog-step in-progress active' and .//span[contains(text(),'{tabName}')]]"), secondsToWait) != null)
			{
				return true;
			}
			else
			{
				return this.ProgressBar?.WaitUntilElementVisible(By.XPath($".//div[@class= 'prog-step active done' and .//span[contains(text(),'{tabName}')]]"), secondsToWait) != null;
			}

			

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
			IWebElement tabEl = this.ProgressBar?.FindElement(By.XPath($".//div[contains(@class, 'prog-step')]//span[contains(text(),'{tabName}')]"), 2);
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
			return this.ContainerElement.WaitUntilElementVisible(By.XPath($".//div[@class='panel-heading']//h3/img[contains(@src,'{logo}')]"), secondsToWait) != null;
		}

		public string ActivePanelHeadingText()
		{
			return this.ActivePanelHeading?.Text;
		}

		public List<string> RadioButtons()
		{
			return this.ContainerElement.FindElements(By.XPath(".//form//input[@type='radio']/../span"), 2).Select(x => x.Text.Trim()).ToList();
		}

		public List<string> Checkboxes()
		{
			return this.ContainerElement.FindElements(By.XPath(".//form//input[@type='checkbox']/../span"), 2).Select(x => x.Text.Trim()).ToList();
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
		public enum Tab { ProductType, ProductCharacteristics, RetailerAssociation, RecipientAndUpcDetails, ReviewAndSubmit, NDCNo }

		public static Dictionary<Tab, string> MapTabs = new Dictionary<Tab, string> {
			{ Tab.ProductType , "Product Type" },
			{ Tab.ProductCharacteristics , "Product Characteristics" },
			{ Tab.RetailerAssociation , "Retailer Association" },
			{ Tab.RecipientAndUpcDetails , "Recipient and UPC Details" },
			{ Tab.ReviewAndSubmit , "Review and Submit" }
		};
		#endregion
		
		public List<string> CheckIfRetailerLogoIsDisplayed(Table table)
		{
			var abbr = new RetailerAbbreviations();
			
			string selectedAbbr;
			List<string> retailersThatAreNotDisplayingTheirLogo = new List<string>();

			foreach (TableRow row in table.Rows)
			{
				string retailer = row["Retailer"];
				abbr.Map.TryGetValue(retailer, out selectedAbbr);
				IWebElement retailerLogo = this.ContainerElement.FindElement(By.XPath(@"//img[@src='/Wercs.SHA.MVCWebV1/Content/images/retailer-logos/" + selectedAbbr + ".png']"), 2);

				if (retailerLogo == null)
				{
					retailersThatAreNotDisplayingTheirLogo.Add(retailer);
				}

			}

			return retailersThatAreNotDisplayingTheirLogo;

		}

		public List<string> CheckIfCheckmarkImageIsDisplayedAboveRetailerLogo(Table table)
		{

			var abbr = new RetailerAbbreviations();
			string selectedAbbr;
			List<string> retailersThatDoNotDisplayACheckmarkImageAboveTheirLogo = new List<string>();

			foreach (TableRow row in table.Rows)
			{
				string retailer = row["Retailer"];
				abbr.Map.TryGetValue(retailer, out selectedAbbr);
				IWebElement checkmarkImage = this.ContainerElement.FindElement(By.XPath(@"//img[@src='/Wercs.SHA.MVCWebV1/Content/images/retailer-logos/" + selectedAbbr + ".png']/../preceding-sibling::div//span//i[@class='fa fa-check fa-3x']"), 2);

				if (checkmarkImage == null)
				{
					retailersThatDoNotDisplayACheckmarkImageAboveTheirLogo.Add(retailer);
				}

			}
			

			return retailersThatDoNotDisplayACheckmarkImageAboveTheirLogo;

		}

		public List<string> CheckIfYellowTriangleImageIsDisplayedAboveRetailerLogo(Table table)
		{

			var abbr = new RetailerAbbreviations();
			string selectedAbbr;
			List<string> retailersThatDoNotDisplayAYellowTriangleImageAboveTheirLogo = new List<string>();

			foreach (TableRow row in table.Rows)
			{

				string retailer = row["Retailer"];
				abbr.Map.TryGetValue(retailer, out selectedAbbr);
				IWebElement checkmarkImage = this.ContainerElement.FindElement(By.XPath(@"//img[@src='/Wercs.SHA.MVCWebV1/Content/images/retailer-logos/" + selectedAbbr + ".png']/../preceding-sibling::div//span//i[@class='fa fa-exclamation-triangle fa-3x']"), 2);

				if (checkmarkImage == null)
				{
					retailersThatDoNotDisplayAYellowTriangleImageAboveTheirLogo.Add(retailer);
				}

			}


			return retailersThatDoNotDisplayAYellowTriangleImageAboveTheirLogo;

		}

		public List<string> CheckIfScopeButtonIsDisplayedBeloweRetailerLogo(Table table)
		{

			var abbr = new RetailerAbbreviations();
			string selectedAbbr;
			List<string> retailersThatDoNotDisplayAScopeButtonBelowTheirLogo = new List<string>();

			foreach (TableRow row in table.Rows)
			{
				string retailer = row["Retailer"];
				abbr.Map.TryGetValue(retailer, out selectedAbbr);
			
				IWebElement scopeButton = this.ContainerElement.FindElement(By.XPath(@"//img[@src='/Wercs.SHA.MVCWebV1/Content/images/retailer-logos/" + selectedAbbr + ".png']/../following-sibling::div//button"), 2);

				if (scopeButton.Text != "Scope")
				{
					retailersThatDoNotDisplayAScopeButtonBelowTheirLogo.Add(retailer);
				}

			}

			return retailersThatDoNotDisplayAScopeButtonBelowTheirLogo;

		}

		public bool ClickScopeButtonBelowRetailerLogo(string retailer)
		{

			IWebElement scopeButton = this.ContainerElement.FindElement(By.XPath(@"//img[@src='/Wercs.SHA.MVCWebV1/Content/images/retailer-logos/" + retailer + ".png']/../following-sibling::div//button"), 2);
			return scopeButton.TryClick();

		}

		public bool CheckIfRetailerModalIsDisplayed()
		{

			IWebElement retailerModalTitel = this.ContainerElement.FindElement(By.XPath(@"//h4[text()='Information']"), 2);

			if (retailerModalTitel == null)
			{
				return false;
			}

			return true;
		}

		public bool CheckRetailerModalText(string text)
		{
			IWebElement retailerModalBody = this.ContainerElement.FindElement(By.XPath(@"//h4[text()='Information']/../following-sibling::div//p"), 2);

			if (retailerModalBody == null)
			{
				return false;
			}

			if (retailerModalBody.Text == text)
			{
				return true;
			}

			return false;

		}

		public bool CloseRetailerModal()
		{

			IWebElement closeButton = this.ContainerElement.FindElement(By.XPath(@"//h4[text()='Information']/../following-sibling::div//button[text()='Close']"), 2);
			return closeButton.TryClick();

		}

		public bool HoverOverYellowTriangleImage(string retailer)
		{
			var abbr = new RetailerAbbreviations();
			string selectedAbbr;
			abbr.Map.TryGetValue(retailer, out selectedAbbr);

			IWebElement yellowTrangleImage = this.ContainerElement.FindElement(By.XPath($@"//img[@src='/Wercs.SHA.MVCWebV1/Content/images/retailer-logos/{selectedAbbr}.png']/../preceding-sibling::div//span//i[@class='fa fa-exclamation-triangle fa-3x']"), 2);

			if (yellowTrangleImage != null)
			{
				yellowTrangleImage.Hover();
				return true;
			}

			return false;

		}

		public bool CheckIfTextDisplayedOverYellowTriangleImageMatches(string textToMatch)
		{

			IWebElement toolTipDisplayBody = this.ContainerElement.FindElement(By.XPath(@"//div[@class='tooltip fade top in']//p"), 2);

			if (toolTipDisplayBody == null)
			{
				return false;
			}

			if (toolTipDisplayBody.Text == textToMatch)
			{
				return true;
			}

			return false;
		}

		public string BatteyWarning()
		{

			IWebElement el = this.ContainerElement.FindElement(By.XPath(".//div[@class='WARNING']"), 2);

			if (el == null)
			{
				return null;
			}

			return el.Text;

		}

		public string GetCurrentProduct()
		{
			IWebElement el = this.ContainerElement.FindElement(By.XPath(".//h2[@class='product-name']"), 2);

			if (el == null)
			{
				return null;
			}

			return el.Text.Trim();
		}

		//New, Copy or UPC
		public void SelectTypeOfProductToCreate(string type = "New")
		{
			IWebElement option = this.ContainerElement.FindElements(By.XPath(".//form//input[@type='radio']/../span"), 2)
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
		//	this.ContainerElement = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath(BasePath), 2);
		//	return this.ContainerElement != null;
		//}

		public bool CountryofOriginExists()
		{
			IWebElement myLabel = this.ContainerElement.FindElement(By.XPath(".//label[contains(text(),'Country of Origin')]"), 2);

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
				IWebElement el = this.ContainerElement.FindElement(By.XPath(".//a[contains(@class,'cancel-button')]"), 2);
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
				IList<IWebElement> listSaveButtons = this.ContainerElement.FindElements(By.XPath(".//a[contains(@class,'save-button')]"), 2);

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
			IList<IWebElement> listSaveButtons = this.ContainerElement.FindElements(By.XPath(".//a[contains(@class,'save-button')]"), 2);

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
			List<KeyValuePair<int, string>> th = new List<KeyValuePair<int, string>>();
			ReadOnlyCollection<IWebElement> listOfHeaders = table.FindElements(By.XPath(".//th"));
			for (int i = 0; i < listOfHeaders.Count; i++)
			{
				th.Add(new KeyValuePair<int, string>(i + 1, listOfHeaders[i].Text));
			}
			return th;
		}

		public bool ClickAddUpcButton()
		{
			IWebElement el = this.ContainerElement.FindElement(By.XPath(".//button[contains(@data-bind,'addNewRow')]"), 2);

			if (el == null)
			{
				return false;
			}

			return el != null && el.TryClick();
		}

		public bool DeleteUPC(string upc)
		{
			if (upc.ToLower().Contains("saved as"))
			{
				upc = Context.GetFromContext(upc.Replace("saved as", "", StringComparison.InvariantCultureIgnoreCase).Trim()).ToString();
			}
			Report.Info("Attempting to delete: " + upc);
			Delay.Seconds(20);
			IWebElement container = this.ContainerElement.FindElement(By.XPath(".//table[@class='table table-hover upc-table']"), 2);
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

		public bool SelectChevronForUPC(string upc)
		{
			IWebElement chevron = this.ContainerElement.FindElement(By.XPath("//span[text()='" + upc + "']/../preceding-sibling::td/a/em[@class='fa fa-chevron-right']"), 2);
			if (chevron == null)
			{
				Report.Info("Failed to find chevron element on the page");
				return false;
			}
			bool canClick = chevron.TryClick();
			if (!canClick)
			{
				Report.Info("Failed to click the chevron for upc " + upc);
				return false;
			}
			return true;
		}

		public List<string> GetAllUPCs()
		{
			IWebElement container = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath(".//table[@class='table table-hover upc-table']"), 2);
			return container.FindElements(By.XPath(".//span[contains(@data-bind,'upc')]"), 2).Select(x => x.Text).ToList();
		}

		public List<string> GetAllUPCDestinationRetailers()
		{
			IWebElement container = this.ContainerElement.FindElement(By.XPath(".//table[@class='table table-hover upc-table']"), 2);
			return container.FindElements(By.XPath(".//span[contains(@data-bind,'identifier')]"), 2).Select(x => x.Text).ToList();
		}

		public bool ClickSelectAllDestinationRetailers()
		{
			return this.ContainerElement.FindElement(By.XPath(".//input[@id='chkAllRetailers']"), 1).TryCheck();
		}

		public bool SelectAllCertifications()
		{
			bool checkTrue = true;
			IList<IWebElement> listofCert = this.ContainerElement.FindElements(By.XPath(".//div[@data-bind='with: upc']//div//input"), 1);
			foreach (var item in listofCert)
			{
				//IWebElement inputbox= item.FindElement(By.XPath(".//"), 2)
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



			return this.ContainerElement.FindElement(By.XPath(".//input[@id='chkAllRetailers']"), 1).TryCheck();
		}

		public bool UPCPackageTypeFieldExists()
		{
			try
			{
				IWebElement container = this.ContainerElement.FindElement(By.XPath(".//table[@class='table table-hover upc-table']"), 2);
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

		public bool UPCSectionFieldsAvailable(string field)
		{
			try
			{
				IWebElement Field = this.ContainerElement.FindElement(By.XPath($".//input[@placeholder='{field}'] | .//div[@class='form-group']//label[text()='{field}'] | .//select[contains(@data-bind, '{field}')]"), 2);
				return Field != null;
			}
			catch (Exception)
			{
				return false;
			}
		}
		public string UPCSectionCheckError(string field)
		{
			IWebElement FieldError = this.ContainerElement.FindElement(By.XPath($".//input[@placeholder='{field}']/following-sibling::p | .//div[@class='form-group']//label[text()='{field}']/following-sibling::p | .//select[contains(@data-bind, '{field}')]/following-sibling::p"), 2);
			if (FieldError == null)
			{
				Report.Failure("Cannot find section");
			}

			string getError = FieldError.Text;
			return getError;
			
		}

		public string GetValidOptionForUPCPackageType()
		{
			if (!this.UPCPackageTypeFieldExists())
			{
				Report.Info("Package type field does not exist");
				Report.Screenshot();
				return null;
			}
			IWebElement container = this.ContainerElement.FindElement(By.XPath(".//table[@class='table table-hover upc-table']"), 2);
			IWebElement packageTypeField = container.FindElement(By.XPath(".//select[contains(@data-bind,'Package Type')]"), 2);
			var selectOptions = packageTypeField.FindElements(By.XPath(".//option"), 2).Select(x => x.GetValue()).ToList();
			return selectOptions.FirstOrDefault(x => x != "Package Type");

		}

		public bool AddNewPackingTypeLinkExists()
		{
			IWebElement link = this.ContainerElement.FindElement(By.XPath("//a[contains(text(), 'Add new Packaging Type')]"), 2);
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
			IWebElement container = this.ContainerElement.FindElement(By.XPath(".//table[@class='table table-hover upc-table']"), 2);
			IWebElement packageTypeField = container.FindElement(By.XPath(".//select[contains(@data-bind,'Package Type')]"), 2);
			return packageTypeField.FindElements(By.XPath(".//option"), 2).Select(x => x.GetValue()).ToList();
		}

		public bool InputUPCNumber(string upcNumber)
		{
			IWebElement container = this.ContainerElement.FindElement(By.XPath(".//table[@class='table table-hover upc-table']"), 2);
			IWebElement upcNumberField = container.FindElement(By.XPath(".//label[contains(text(),'GTIN/UPC')]/..//input"), 2);

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

		public bool InputZeroBufferUPCNumber(string upcNumber)
		{

			IWebElement container = this.ContainerElement.FindElement(By.XPath(".//table[@class='table table-hover upc-table']"), 2);

			if (container == null)
			{
				Report.Failure("Container Element is null");
				return false;
			}

			IWebElement upcNumberField = container.FindElement(By.XPath(".//label[contains(text(),'GTIN/UPC')]/..//input"), 2);

			if (upcNumberField == null)
			{
				Report.Failure("UPC Number Field Element is null");
				return false;
			}

			if (upcNumber.ToLower().Contains("saved as"))
			{
				try
				{
					string savedUPC = Context
						.GetFromContext(upcNumber.Replace("saved as", "", StringComparison.InvariantCultureIgnoreCase).Trim())
						.ToString();
					upcNumber = "0" + savedUPC;
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
		public bool InputZeroBufferUPCDuplicateNumber(string upcNumber)
		{
			IWebElement container = this.ContainerElement.FindElement(By.XPath(".//table[@class='table table-hover upc-table']"), 2);
			IWebElement upcNumberField = container.FindElement(By.XPath(".//label[contains(text(),'GTIN/UPC')]/..//input"), 2);

			if (upcNumber.ToLower().Contains("saved as"))
			{
				try
				{
					string savedUPC = Context
						.GetFromContext(upcNumber.Replace("saved as", "", StringComparison.InvariantCultureIgnoreCase).Trim())
						.ToString();
					upcNumber = "00" + savedUPC;
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
			
			IWebElement container = this.ContainerElement.FindElement(By.XPath(".//table[@class='table table-hover upc-table']"), 2);

			if (container == null)
			{
				Report.Failure("Container Element is null");
				return false;
			}

			IList<IWebElement> textInputs = container.FindElements(By.XPath("//input[@type = 'text']"), 2);

			if (textInputs == null)
			{
				Report.Failure("Text Inputs Element is null");
				return false;
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
			sizeField.EnterText(size);
			return sizeField.GetValue() == size;
		}

		public bool SelectContainerType(string containerType)
		{

			IWebElement container = this.ContainerElement.FindElement(By.XPath(".//table[@class='table table-hover upc-table']"), 2);

			if (container == null)
			{
				Report.Failure("Container Element returned null");
				return false;
			}

			IWebElement containsType = container.FindElement(By.XPath(".//select[contains(@data-bind,'Container Type')]"), 2);

			if (containsType == null)
			{
				Report.Failure("Contains Type Element returned null");
				return false;
			}

			containsType.Select(containerType);
			return containsType.GetValue() == containerType;
		}

		public List<string> GetContainerOptions()
		{

			IWebElement container = this.ContainerElement.FindElement(By.XPath(".//table[@class='table table-hover upc-table']"), 2);

			if (container == null)
			{
				Report.Failure("Container Element returned null");
				return null;
			}

			IWebElement upcNumberField = container.FindElement(By.XPath(".//label[contains(text(),'GTIN/UPC')]/..//input"), 2);
			IWebElement containsType = container.FindElement(By.XPath(".//select[contains(@data-bind,'Container Type')]"), 2);

			if (upcNumberField == null)
			{
				Report.Failure("UPC Number Field Element returned null");
				return null;
			}

			if (containsType == null)
			{
				Report.Failure("Contains Type Element returned null");
				return null;
			}

			return containsType.FindElements(By.XPath(".//option"), 2).Select(x => x.GetValue()).ToList();
		}

		public bool SelectHeight(string height)
		{

			IWebElement heightEl = this.ContainerElement.FindElement(By.XPath(".//label[text()='Height in inches (single unit)']/../following-sibling::div//select"), 2);

			if (height == null)
			{
				Report.Failure("Height Element returned null");
				return false;
			}

			heightEl.Select(height);
			return heightEl.GetValue() == height;
		}

		public List<string> GetHeightOptions()
		{

			IList<IWebElement> optionsList = this.ContainerElement.FindElements(By.XPath(".//label[text()='Height in inches (single unit)']/../following-sibling::div//select//option"), 2);
			List<string> optionsListStrings = new List<string>();
			if (optionsList.Count == 0)
			{
				Report.Failure("Options List returned null");
				return null;
			}
			else
			{
				foreach (IWebElement el in optionsList)
				{
					optionsListStrings.Add(el.Text);
				}
			}

			return optionsListStrings;
		}

		public bool InputUpcInformation(UpcInformation info)
		{
			Delay.Seconds(5);

			try
			{
				IWebElement container = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath(".//table[@class='table table-hover upc-table']"), 2);
				IList<IWebElement> textInputs = container.FindElements(By.XPath("//input[@type = 'text']"), 2);
				IWebElement upcNumberField = container.FindElement(By.XPath(".//label[contains(text(),'GTIN/UPC')]/..//input"), 2);
				IWebElement ProductNameOnlabel = container.FindElement(By.XPath(".//label[contains(text(),'Product Name on Label')]/..//input"), 2);

				if(container.IsNullOrEmpty())
				{
					Report.Info($"Container el was null");
					return false;
				}
				if(textInputs.IsNullOrEmpty()||upcNumberField.IsNullOrEmpty()||ProductNameOnlabel.IsNullOrEmpty())
				{
					Report.Info($"One of the base els was null or empty...");
					return false;
				}


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
				Report.Info($"Going to enter upc number");

				upcNumberField.EnterText(info.UpcNumber);

				Report.Info($"entered upc number...");

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



					var select = new SelectElement((IWebElement)containsType);

					if (info.ContainerType == "any")
					{
						select.SelectByIndex(1);

					}
					else
					{
						containsType.Select(info.ContainerType);
					}
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

				Report.Info("entering the size");

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
					
					if (packageField == null)
					{
						return false;
					}
					if (info.PackageType=="<First>")
					{
						var firstOption = packageField.FindElement(By.XPath("./option[not(text()='Package Type')]"), 1).Text;
						info.PackageType = firstOption;
					}
					packageField.Select(info.PackageType);
				}
		
				if (info.CapsuleCount.Length > 0)
				{
					IWebElement capsuleCountField = container.FindElement(By.XPath(".//label[contains(text(),'Capsule Count')]/..//input"), 2);
					
					if (capsuleCountField == null)
					{
						return false;
					}
					capsuleCountField.EnterText(info.CapsuleCount);
				}
				
				if (info.ItemNumber.Length > 0)
				{
					IWebElement ItemNumberField = container.FindElement(By.XPath(".//label[contains(text(),'Please enter comma separated Item Number')]//following-sibling::input"), 2);
					
					if (ItemNumberField == null)
					{
						return false;
					}
					ItemNumberField.EnterText(info.ItemNumber);
				}
				
				if (info.InternalSKU.Length > 0)
				{
					IWebElement InternalSKUNumberField = container.FindElement(By.XPath(".//label[contains(text(),'Internal SKU')]//following-sibling::input"), 2);
				
					if (InternalSKUNumberField == null)
					{
						return false;
					}
					InternalSKUNumberField.EnterText(info.InternalSKU);
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
			IWebElement container = this.ContainerElement.FindElement(By.XPath(".//table[@class='table table-hover upc-table']"), 2);
			var rList = new List<string>();
			for (int i = 2; i < 6; i++)
			{
				if (container != null)
				{

					var tempList = new List<string>();
					try
					{
						tempList = container.FindElement(By.XPath($".//th[@class='col-xs-{i}']"), 2).GetValue().Replace("\r\n", "|").Split('|').Select(x => x.Trim()).Where(x => x != "UPC Number").ToList();
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

		public void ConfirmTheDataSelectedIsVisible()
		{

			FindElement(By.XPath("//h3[text()='Transportation Details 1']")).Click();

			Delay.Seconds(5);

			IWebElement ele = FindElement(By.XPath(".//input[@placeholder='Other DOT Exception']"));
			string text = ele.GetAttribute("value");
			if (text == null)
			{
				Report.Info("No text is displayed");
			}
			else
			{
				Report.Info("Text entered is displayed : " + text);
			}
			
			IWebElement ele1 =FindElement(By.XPath(".//input[@value='TRNSEX03']"));
			if (ele1.GetAttribute("checked")!=null)
			{
				Report.Info("checkbox selected is visible");
			}
			else
			{
				Report.Info("checkbox selected is not visible");
			}
			IWebElement verifyIsSelected = FindElement(By.XPath("(//input[@type='radio'])[2]"));
			if (verifyIsSelected.GetAttribute("checked") != null)
			{
				Report.Info("'No, due to an exemption or exception' selected is visible");
			}
			else
			{
				Report.Info("'No, due to an exemption or exception' selected is not visible");
			}

		}

		public bool InputOtherDotException(string text)
		{
			IWebElement ele = this.ContainerElement.FindElement(By.XPath(".//input[@placeholder='Other DOT Exception']"), 2);
			return ele.TryEnterText(text);
		}

		public bool CommentsAreaShowing()
		{
			IWebElement el = this.ContainerElement.FindElement(By.XPath(".//h3[text()='Optional Comments']/../../../..//textarea"), 2);
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

				IWebElement el = this.ContainerElement.FindElement(By.XPath(".//h3[text()='Optional Comments']/../../../..//textarea"), 2);
				
				if (el == null)
				{
					return false;
				}
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
			IWebElement el = this.ContainerElement.FindElement(By.XPath(@"//p[contains(concat(' ',normalize-space(@class),' '),'form-error')]"), 2);
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
			IWebElement el = this.ContainerElement.FindElement(By.XPath(".//h3[text()='Data Acceptance']"), 2);
			if (el == null)
			{
				return false;
			}

			return el.Displayed;
		}
		public bool CheckDataAcceptanceProblemMessageHasAppeared(string message)
		{
			Report.Info("Beginning CheckDataAcceptanceProblemMessageHasAppeared");
			var element = this.ContainerElement.FindElement(By.XPath("//div[contains(text(), '" + message + "')]"), 1);
			if (element == null)
			{
				Report.Info("Check Data Acceptance Problem Message returns null");
				return false;
			}
			var UPCTextWarning = element.Text;

			if (UPCTextWarning == "")
			{
				Report.Info("Check Data Acceptance Problem Message returns an empty string");
				return false;
			}
			return true;
		}

		public bool CheckDataAcceptanceSelectOptionWarningIsVisible()
		{
			Report.Info("Beginning CheckDataAcceptanceSelectOptionWarningIsVisible");
			IWebElement SelectWarning = this.ContainerElement.FindElement(By.XPath("//span[contains(@data-bind, 'html: $data')]"), 1);
			if (SelectWarning == null)
			{
				Report.Info("SelectWarning returns a null");
				return false;
			}
			Report.Info("SelectWarning found!");
			return true;
		}
		public bool CheckDataAcceptanceSelectOptionWarningIsNotVisible()
		{
			Report.Info("Beginning CheckDataAcceptanceSelectOptionWarningIsNotVisible");
			IWebElement SelectWarning = this.ContainerElement.FindElement(By.XPath("//span[contains(@data-bind, 'html: $data')]"), 1);
			if (SelectWarning == null)
			{
				Report.Info("SelectWarning was not found!");
				return true;
			}
			Report.Info("SelectWarning was found!");
			return false;
		}

		public bool CheckFixAllErrorsMessageIsNotVisible()
		{
			Report.Info("Beginning CheckFixAllErrorsMessageIsNotVisible");
			var element = this.ContainerElement.FindElement(By.XPath("//div[contains(@data-bind, 'visible: $root.isAllValid() === false')]"), 1);
			if (element == null)
			{
				Report.Info("fixAllErrorsMessage returned a null value!");
				return false;
			}

			var fixAllErrorsMessage = element.Text;
			if (fixAllErrorsMessage == "")
			{
				Report.Info("fixAllErrorsMessage returned a empty value!");
				return false;
			}
			if (fixAllErrorsMessage == "visible: $root.isAllValid()")
			{
				Report.Info("fixAllErrorsMessage is visible!");
				return false;
			}
			Report.Info("fixAllErrorsMessage is not visible");
			return true;
		}

		public string GetUserEmailAddress(string accountSavedAs)
		{
			Report.Info("Beginning GetUserEmailAddress");
			TReVorTestUsers user = new TReVorTestUsers();
			user = TestUsers.GetUserSavedAs(accountSavedAs);
			string usrEmail = user.Username;
			return usrEmail;

		}
		public string CheckDataAcceptanceEmailIsPopulated()
		{
			Report.Info("Beginning CheckDataAcceptanceProblemMessageHasAppeared");
			var EmailField = this.ContainerElement.FindElement(By.XPath("//input[@id= 'email']"), 2);
			var dataBindContents = EmailField.GetValue();
			// needs work
			if (dataBindContents == "")
			{
				Report.Info("Check Data Acceptance Problem Message returns an empty string");
				return dataBindContents;
			}
			Report.Info("Check Data Acceptance Problem Message string: " + dataBindContents);
			return dataBindContents;
		}

		public bool CheckEmailAddressAgainstDataAcceptanceEmail(string usrEmail, string dataAcceptanceEmail)
		{
			if (usrEmail == dataAcceptanceEmail)
			{
				Report.Info("The user email address: " + usrEmail + " matches the email displayed in the data acceptance form: " + dataAcceptanceEmail);
				return true;
			}
			Report.Info("The user email address: " + usrEmail + " does not match the email displayed in the data acceptance form: " + dataAcceptanceEmail);
			return false;

		}


		public List<string> Get3rdPartyPageAlerts()
		{
			IList<IWebElement> el = this.ContainerElement.FindElements(By.XPath(".//div[@class='alert alert-info']"), 2);
			if (el.Count > 0)
			{
				return this.ContainerElement.FindElements(By.XPath(".//div[@class='alert alert-info']"), 2).Select(x => x.GetValue()).ToList();
			}
			return new List<string>();
		}

		public bool ThirdPartyScreenAppears()
		{
			IWebElement el = this.ContainerElement.FindElement(By.XPath(".//h3[text()='Formulation > 3rd Party']"), 2);
			if (el == null)
			{
				return false;
			}

			return el.Displayed;
		}

		public bool SelectYesAgreedRadio()
		{
			IWebElement el = this.ContainerElement.FindElement(By.XPath(".//span[contains(text(), 'Agreed')]/../input"), 2);
			if (el == null)
			{
				return false;
			}

			return el.TryClick();

		}

		public bool YesAgreedIsSelected()
		{
			IWebElement el = this.ContainerElement.FindElement(By.XPath(".//span[contains(text(), 'Agreed')]/../input"), 2);
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
				IWebElement el = this.ContainerElement.FindElement(By.XPath(".//span[contains(text(), 'Agreed')]/../input"), 2);
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
			IWebElement el = this.ContainerElement.FindElement(By.XPath(".//span[contains(text(), 'Accept')]/../input"), 2);
			if (el == null)
			{
				return false;
			}

			return el.Selected;
		}

		public bool SelectAcceptRadio()
		{
			SeleniumBrowser.ScrollToTopOfPage();
			IWebElement el = this.ContainerElement.FindElement(By.XPath(".//span[contains(text(), 'Accept')]/../input"), 2);
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
			IWebElement el = this.ContainerElement.FindElement(By.XPath(".//span[contains(text(), 'Granted')]/../input"), 2);
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
			IWebElement el = this.ContainerElement.FindElement(By.XPath(".//span[contains(text(), 'Granted')]/../input"), 2);
			if (el == null)
			{
				return false;
			}

			return el.Selected;
		}

		public bool FieldValueRadioIsSelected(string field, string value)
		{
			IWebElement el = this.ContainerElement.FindElement(By.XPath($".//label[text()='{field}']/../..//span[text()='{value}']/../input"), 2);
			if (el == null)
			{
				Report.Info($"Section {field} does not have input {value}");
				return false;
			}

			return el.Selected;
		}

		public bool SelectFieldValueRadio(string field, string value)
		{
			IWebElement el = this.ContainerElement.FindElement(By.XPath($".//label[text()='{field}']/../..//span[text()='{value}']/../input"), 2);
			if (el == null)
			{
				Report.Info($"Section {field} does not have input {value}");
				return false;
			}

			return el.TryClick();
		}

		public bool SelectDeclinedRadio()
		{
			IWebElement el = this.ContainerElement.FindElement(By.XPath(".//span[contains(text(), 'Declined')]/../input"), 2);
			if (el == null)
			{
				return false;
			}

			return el.TryClick();

		}

		public bool DeclinedRadioIsSelected()
		{
			IWebElement el = this.ContainerElement.FindElement(By.XPath(".//span[contains(text(), 'Declined')]/../input"), 2);
			if (el == null)
			{
				return false;
			}

			return el.Selected;
		}

		public bool ClickAcceptButton()
		{
			IWebElement el = this.ContainerElement.FindElement(By.XPath(".//a[text()='Accept']"), 2);
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
			IWebElement el = this.ContainerElement.FindElement(By.XPath(".//a[text()='Accept']"), 2);
			return el != null && el.Displayed;
		}

		public bool ClickSummaruButtonInDataAcceptance()
		{
			IWebElement el = this.ContainerElement.FindElement(By.XPath(".//a[text()='Summary']"), 30);
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
			//	var el = ContainerElement
			//		.FindElements(By.XPath(".//label[text()='Product is Regulated for Transport']/../following-sibling::div//input"), 2)
			//		.FirstOrDefault(x => x.Selected).FindElement(By.XPath("../span"), 2);
			//	if (el != null)
			//	{
			//		return el.Text;
			//	}

			//	return "";
			//}
			//set
			//{
			//	var el = ContainerElement
			//		.FindElements(By.XPath(".//label[text()='Product is Regulated for Transport']/../following-sibling::div//span"), 2)
			//		.FirstOrDefault(x => x.Text.Contains(value)).FindElement(By.XPath("../input"), 2);
			//	if (el != null)
			//	{
			//		el.TryClick();
			//	}
			//}

			try
			{
				IWebElement el = this.ContainerElement
					.FindElements(By.XPath(".//label[text()='Product is Regulated for Transport']/../following-sibling::div//span"), 2)
					.FirstOrDefault(x => x.Text == item).FindElement(By.XPath("../input"), 2);
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
				IWebElement el = this.ContainerElement
					.FindElements(By.XPath(".//label[contains(text(),'Select all modes of transport')]/../following-sibling::div//span"), 2)
					.FirstOrDefault(x => x.Text == item).FindElement(By.XPath("../input"), 2);
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
				IWebElement el = this.ContainerElement
					.FindElements(By.XPath(".//label[contains(text(),'Please select DOT Exceptions if applicable?')]/../following-sibling::div//span"), 2)
					.FirstOrDefault(x => x.Text == item).FindElement(By.XPath("../input"), 2);
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
				IWebElement el = this.ContainerElement
					.FindElements(By.XPath(".//label[text()='International Shipping when DOT Exemption taken?']/../following-sibling::div//input"), 2)
					.FirstOrDefault(x => x.Selected).FindElement(By.XPath("../span"), 2);
				if (el != null)
				{
					return el.Text;
				}

				return "";
			}
			set
			{
				IWebElement el = this.ContainerElement
					.FindElements(By.XPath(".//label[text()='International Shipping when DOT Exemption taken?']/../following-sibling::div//span"), 2)
					.FirstOrDefault(x => x.Text.Contains(value)).FindElement(By.XPath("../input"), 2);
				if (el != null)
				{
					el.TryClick();
				}
			}
		}

		public List<string> DOTExceptions {
			get
			{
				IEnumerable<IWebElement> selectedInputs = this.ContainerElement
					.FindElements(By.XPath(".//label[contains(text(),'Please select DOT Exceptions if applicable')]/../following-sibling::div//input"), 2)
					.Where(x => x.Selected);
				var selectedLabels = new List<string>();
				foreach (IWebElement input in selectedInputs)
				{
					selectedLabels.Add(input.FindElement(By.XPath("../span"), 2).Text);
				}

				return selectedLabels;
			}
			set
			{
				foreach (string item in value)
				{
					IWebElement el = this.ContainerElement
						.FindElements(By.XPath(".//label[contains(text(),'Please select DOT Exceptions if applicable')]/../following-sibling::div//span"), 2)
						.FirstOrDefault(x => x.Text.Contains(item)).FindElement(By.XPath("../input"), 2);
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
				IWebElement el = this.ContainerElement
					.FindElement(By.XPath(".//label[contains(text(),'Other DOT Exception')]/../following-sibling::div//input"), 2);
				return el.GetValue();
			}
			set
			{
				IWebElement el = this.ContainerElement
					.FindElement(By.XPath(".//label[contains(text(),'Other DOT Exception')]/../following-sibling::div//input"), 2);
				el.EnterText(value);
			}
		}

		public string SpecialPermitNumbers {
			get
			{
				IWebElement el = this.ContainerElement
					.FindElement(By.XPath(".//label[contains(text(),'Special Permit')]/../following-sibling::div//input"), 2);
				return el.GetValue();
			}
			set
			{
				IWebElement el = this.ContainerElement
					.FindElement(By.XPath(".//label[contains(text(),'Special Permit')]/../following-sibling::div//input"), 2);
				el.EnterText(value);
			}
		}

		public List<string> ListOfPrimaryPhysicalStates()
		{
			return this.ContainerElement.FindElements(By.XPath(".//label[text()='Primary Physical State']/..//following-sibling::div//label//span"), 2).Select(x => x.GetValue()).ToList();
		}

		public bool SelectSecondaryPhysicalState(string item)
		{
			try
			{
				IWebElement el = this.ContainerElement.FindElement(By.XPath(".//label[text()='Secondary Physical State']/..//following-sibling::div//select"), 2);
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
				IWebElement el = this.ContainerElement.FindElement(By.XPath(".//label[text()='Select the best Water Solubility description']/..//following-sibling::div//select"), 2);

				if (el == null)
				{
					return null;
				}

				return el.SelectedOption();
			}
			set
			{
				IWebElement el = this.ContainerElement.FindElement(By.XPath(".//label[text()='Select the best Water Solubility description']/..//following-sibling::div//select"), 2);

				if (el == null)
				{
					return;
				}

				el.Select(value);
			}
		}

		/// <summary>
		/// When the product has a flammable propellant, or contains ingredients with a flash point below 60⁰C then radio options
		/// </summary>
		public bool ProductHasFlammablePropellant(string item)
		{
			IWebElement el = this.ContainerElement
				.FindElements(By.XPath(".//label[contains(text(),'flammable propellant')]/../following-sibling::div//span"), 2)
				?.FirstOrDefault(x => x.Text == item).FindElement(By.XPath("../input"), 2);
			if (el != null)
			{
				el.TryClick();
				return true;
			}

			return false;
		}

		public bool SelectBestWaterSolubilityDescription(string item)
		{

			IWebElement el = this.ContainerElement.FindElement(By.XPath(".//label[text()='Select the best Water Solubility description']/..//following-sibling::div//select"), 2);

			if (el == null)
			{
				return false;
			}

			el.Select(item);
			return true;

		}

		/// <summary>
		/// Refer to your Product Label. From the options, select those that appear on the Label checkbox options
		/// </summary>
		public List<string> ProductLabel {
			get
			{
				IEnumerable<IWebElement> selectedInputs = this.ContainerElement
					.FindElements(By.XPath(".//label[contains(text(),'Refer to your Product Label')]/../following-sibling::div//input"), 2)
					.Where(x => x.Selected);
				var selectedLabels = new List<string>();
				foreach (IWebElement input in selectedInputs)
				{
					selectedLabels.Add(input.FindElement(By.XPath("../span"), 2).Text);
				}

				return selectedLabels;
			}
			set
			{
				foreach (string item in value)
				{
					IWebElement el = this.ContainerElement
						.FindElements(By.XPath(".//label[contains(text(),'Refer to your Product Label')]/../following-sibling::div//span"), 2)
						.FirstOrDefault(x => x.Text.Contains(item)).FindElement(By.XPath("../input"), 2);
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
				IList<IWebElement> btns = this.ContainerElement.FindElements(By.XPath(".//label[contains(text(),'When mixed with an equal')]/..//following-sibling::div//input/following-sibling::span"), 2);
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
				
				IWebElement placeholderEl = this.ContainerElement.FindElement(By.XPath(".//span[contains(@id, 'select2-autocomplete')]"), 2);
				IWebElement MatchedEntry = null;
				IWebElement inputEl = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath(".//input[@class='select2-search__field']"), 2);
				IWebElement searching = this.ContainerElement.FindElement(By.XPath(".//li[contains(@class,'select2-results__message')]"), 2);

				if (placeholderEl == null)
				{
					Report.Failure("Placeholder Element returned null");
					return false;
				}

				if (inputEl == null)
				{
					Report.Failure("Input Element returned null");
					return false;
				}

				if (searching == null)
				{
					Report.Failure("Searching Element returned null");
					return false;
				}

				placeholderEl.TryClick();
				inputEl.EnterText(product);

				int i = 0;
				while (searching != null && i < 10)
				{
					Delay.Seconds(Delay.SpeedFactor * 1);
					i++;
					searching = this.ContainerElement.FindElement(By.XPath(".//li[contains(@class,'select2-results__message')]"), 2);
				}
				IList<IWebElement> Matches = this.ContainerElement.FindElements(By.XPath(".//li[contains(@class,'select2-results__option')]"), 2);
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
					IWebElement placeholderEl = this.ContainerElement.FindElement(By.XPath(".//span[contains(@id, 'select2-autocomplete')]"), 2);
					placeholderEl.TryClick();
					IWebElement MatchedEntry = null;
					IWebElement inputEl = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath(".//input[@class='select2-search__field']"), 2);
					inputEl.EnterText(product.Name);
					IWebElement searching = this.ContainerElement.FindElement(By.XPath(".//li[contains(@class,'select2-results__message')]"), 2);
					int i = 0;
					while (searching != null && i < 10)
					{
						Delay.Seconds(Delay.SpeedFactor * 1);
						i++;
						searching = this.ContainerElement.FindElement(By.XPath(".//li[contains(@class,'select2-results__message')]"), 2);
					}
					IList<IWebElement> Matches = SeleniumWebDriver.CurrentDriver.FindElements(By.XPath(".//li[contains(@class,'select2-results__option')]"), 2);
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
						ReadOnlyCollection<IWebElement> listOfSelected = SeleniumWebDriver.CurrentDriver.FindElements(By.XPath(
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
					IWebElement placeholderEl = this.ContainerElement.FindElement(By.XPath(".//span[contains(@id, 'select2-autocomplete')]"), 2);
					if(placeholderEl==null)
					{
						Report.Info($"placeholderEl was null");
						return false;
					}
					Report.Info($"placeholderEl was found... Attempting to click placeholderEl");
					placeholderEl.TryClick();
					IWebElement MatchedEntry = null;
					IWebElement inputEl = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath(".//input[@class='select2-search__field']"), 2);
					if (inputEl == null)
					{
						Report.Info($"inputEl was null");
						return false;
					}
					Report.Info($"inputEl was found... Attempting to enter product id");
					Report.Info($"Entering product id: {product.Id}");
					inputEl.EnterText(product.Id);
					IWebElement searching = this.ContainerElement.FindElement(By.XPath(".//li[contains(@class,'select2-results__message')]"), 2);
					int i = 0;
					while (searching != null && i < 10)
					{
						Delay.Seconds(Delay.SpeedFactor * 1);
						i++;
						searching = this.ContainerElement.FindElement(By.XPath(".//li[contains(@class,'select2-results__message')]"), 2);
					}
					IList<IWebElement> Matches = SeleniumWebDriver.CurrentDriver.FindElements(By.XPath(".//li[contains(@class,'select2-results__option')]"), 2);
					if(Matches.IsNullOrEmpty())
					{
						Report.Info($"There was not matches found, 'Matches' was null or empty");
						
					}
					Report.Info($"Looking for matching id's");
					IWebElement MatchingByID = Matches.FirstOrDefault(x => x.GetValue().Trim().ToLower().Contains(product.Id.ToLower()));
					if (MatchingByID == null)
					{
						// No matching name entry was found, so we take the first one just in case we are looking for a partial match!
						Report.Info($"no matching name entry found, taking first match incase partial match expected.");
						MatchedEntry = Matches.FirstOrDefault();
					}
					else
					{
						Report.Info($"There was a matching name entry found. Setting 'MatchedEntry' to that value");
						MatchedEntry = MatchingByID;
					}

					Report.Info($"checking if 'MatchedEntry' is null...");


					if (MatchedEntry != null)
					{
						Report.Info("Found matching search item, attempting to click");
						MatchedEntry.TryClick();
						Delay.Seconds(1);
						Report.Info($"Looking for 'listOfSelected'...");
						ReadOnlyCollection<IWebElement> listOfSelected = SeleniumWebDriver.CurrentDriver.FindElements(By.XPath(
							"//div[contains(text(), 'Select Existing Registrations')]/../..//table/tbody/tr//input/../..//span"));
						Report.Info($"Looking for 'matchingProduct'...");

						IWebElement matchingProduct = listOfSelected.FirstOrDefault(x => x.GetValue().Contains(product.Id));
						Report.Info($"Checking if 'matchingProduct' is null");

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
			IWebElement commentBox = this.FindElement(By.XPath(".//h3[text()='Comments']/../../../..//textarea"), 2);

			if (commentBox == null)
			{
				return false;
			}

			return contents == commentBox.Text;
		}

		internal bool CommentsCharactersRemaining(int expected, int maximum, out int remainDisplayed)
		{

			IWebElement fullTextEl = this.FindElement(By.XPath("//span[contains(@data-bind,'maxLength')]"), 2);
			IWebElement commentBox = this.FindElement(By.XPath(".//h3[text()='Comments']/../../../..//textarea"), 2);


			if (fullTextEl == null || commentBox == null)
			{
				remainDisplayed = 0;
				return false;
			}

			string fullText = fullTextEl.Text;
			string[] splitFull = fullText.Split('/');

			string maxCharactersText = splitFull[1];
			string charactersRemainText = splitFull[0];

			Report.IsTrue(int.TryParse(maxCharactersText, out int maxDisplayed),
				"Maximum Characters is displaying " + maxCharactersText + " which cannot be parsed into an integer",
				"The maximum allowed caharacters is able to be represented as an integer: " + maxDisplayed);
			Report.IsTrue(int.TryParse(charactersRemainText, out remainDisplayed),
				"Remaining Characters is displaying " + charactersRemainText + " which cannot be parsed into an integer",
				"The maximum allowed caharacters is able to be represented as an integer: " + remainDisplayed);

			return remainDisplayed == expected;


		}

		// ========= Add Ingredient Functions ========= //

		public bool SetFullNameOfProductForRetailer(string retailer, string name)
		{
			IWebElement el = this.ContainerElement.FindElement(By.XPath(".//input[@placeholder='Indicate full name of product, as sold, via this retailer (e.g. Private Label Aspirin)' and (./ancestor::td//preceding-sibling::td[contains(text(),'" + retailer + "')]) ]"), 2);
			if (el == null)
			{
				Report.Failure("Could not find the Full Product Name field!");
				return false;
			}

			el.EnterText(name);
			return el.GetValue() == name;

		}

		/*===== Safety Data Sheet Authoring ====*/

		public string PersonalProtectionEquipmentRecommended {
			get
			{
				IWebElement lbl = this.ContainerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("Personal Protection Equipment"));

				if (lbl != null)
				{
					ReadOnlyCollection<IWebElement> listOfItems = lbl.FindElements(By.XPath("../..//input"));
					foreach (IWebElement item in listOfItems)
					{
						if (item.Selected)
						{
							string selectedText = item.FindElement(By.XPath("../..//label/span"), 2).Text;
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
				IWebElement lbl = this.ContainerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("Personal Protection Equipment"));

				if (lbl != null)
				{
					IWebElement thisLabel = lbl.FindElements(By.XPath("../..//input/../../label/span"), 2).FirstOrDefault(y => y.Text.Contains(value));
					if (thisLabel != null)
					{
						IWebElement thisInput = thisLabel.FindElement(By.XPath(".//../input"), 2);
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
				IWebElement lbl = this.ContainerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("Autoignition Temperature"));

				if (lbl != null)
				{
					IWebElement input = lbl.FindElement(By.XPath("../..//input"), 2);
					return input.Text;
				}
				else
				{
					throw new Exception("Label not found as expected.");
				}

			}
			set
			{
				IWebElement lbl = this.ContainerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("Autoignition Temperature"));

				if (lbl != null)
				{
					IWebElement input = lbl.FindElement(By.XPath("../..//input"), 2);
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
				IWebElement lbl;
				
				if (SeleniumWebDriver.CurrentDriver.FindElements(By.XPath(".//label"), 2) == null)
				{
					return null;
				} else
				{
					lbl = SeleniumWebDriver.CurrentDriver.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("Ignition"));
				}

				if (lbl != null)
				{
					IWebElement input = lbl.FindElement(By.XPath("../..//input"), 2);
					return input.Text;
				}
				else
				{
					throw new Exception("Label not found as expected.");
				}

			}
			set
			{
				IWebElement lbl = SeleniumWebDriver.CurrentDriver.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("Ignition"));

				if (lbl != null)
				{
					IWebElement input = lbl.FindElement(By.XPath("../..//input"), 2);
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
				IWebElement el = this.ContainerElement.FindElement(By.XPath(".//label[text()='Technical Name (if applicable)']/../following-sibling::div//input"), 2);

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
				IWebElement el = this.ContainerElement.FindElement(By.XPath(".//label[text()='VOC content in grams ozone per gram']/../following-sibling::div//input"), 2);

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
				IWebElement el = this.ContainerElement.FindElement(By.XPath(".//label[text()='Proper Shipping Name']/..//following-sibling::div//select"), 2);
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
				IWebElement el = this.ContainerElement.FindElement(By.XPath(".//label[text()='Hazard Class (select)']/..//following-sibling::div//select"), 2);
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
				IWebElement el = this.ContainerElement.FindElement(By.XPath(".//label[text()='Packing Group (select)']/..//following-sibling::div//select"), 2);
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
				IWebElement lbl = this.ContainerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("Viscosity"));

				if (lbl != null)
				{
					IWebElement input = lbl.FindElement(By.XPath("../..//input"), 2);
					return input.Text;
				}
				else
				{
					throw new Exception("Label not found as expected.");
				}

			}
			set
			{
				IWebElement lbl = this.ContainerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("Viscosity"));

				if (lbl != null)
				{
					IWebElement input = lbl.FindElement(By.XPath("../..//input"), 2);
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
				ReadOnlyCollection<IWebElement> listOfOptions = this.ContainerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("Flash Point Testing Method Used"))
					.FindElements(By.XPath("../..//input"));
				foreach (IWebElement item in listOfOptions)
				{
					if (item.Selected)
					{
						return item.FindElement(By.XPath("../..//label"), 2).Text;
					}
				}

				return "";

			}
			set
			{
				IWebElement thisLabel = this.ContainerElement.FindElements(By.XPath(".//label"), 2)?.FirstOrDefault(x => x.Text.Contains("Flash Point Testing Method Used")).FindElements(By.XPath("../..//input/../../label/span"), 2).FirstOrDefault(y => y.Text == value);
				IWebElement optionInput = thisLabel.FindElement(By.XPath(".//../input"), 2);
				if (!optionInput.Selected)
				{
					optionInput.Click();
				}
			}

		}

		public string OSHA {
			get => this.ContainerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("OSHA")).FindElements(By.XPath("../following-sibling::div//label/input"), 2)
					.FirstOrDefault(x => x.Selected).FindElement(By.XPath("./following-sibling::span"), 2).Text;
			set
			{
				IWebElement selectItem = this.ContainerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("OSHA")).FindElements(By.XPath("../following-sibling::div//label/span"), 2)
					.FirstOrDefault(y => y.Text.Contains(value));

				if (selectItem != null)
				{
					selectItem.FindElement(By.XPath("../input"), 2).TryClick();
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
				ReadOnlyCollection<IWebElement> listOfOptions = this.ContainerElement.FindElements(By.XPath(".//label"))
					.FirstOrDefault(x => x.Text.Contains("California Consumer Products Regulation"))
					.FindElements(By.XPath("../..//input"));
				foreach (IWebElement item in listOfOptions)
				{
					if (item.Selected)
					{
						return item.FindElement(By.XPath("../..//label"), 2).Text;
					}
				}

				return "";

			}
			set
			{
				IWebElement thisLabel = this.ContainerElement.FindElements(By.XPath(".//label"), 2)?.FirstOrDefault(x => x.Text.Contains("California Consumer Products Regulation")).FindElements(By.XPath("../..//input/../../label/span"), 2).FirstOrDefault(y => y.Text == value);
				IWebElement optionInput = thisLabel.FindElement(By.XPath(".//../input"), 2);
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
				IWebElement el = this.ContainerElement.FindElement(By.XPath("//*[@id='collapse1']/div/form/div[2]/div[2]/div[1]/div/a"), 2);
				if (el == null)
				{
					return false;
				}
				el.TryClick();
				UploadDialog.UploadFile("C:\\Dependencies\\WERCSmart\\testdoc.pdf");
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public bool CheckButtonExistsInSection(string section, string button)
		{
			string path = $".//span[contains(text(),'{section}')]//..//a[@data-bind[contains(.,'{button}')]] | .//span[contains(text(),'{section}')]//..//a[contains(text(), '{button}')]";
			IWebElement el = this.ContainerElement.FindElement(By.XPath(path), 2);
			Report.Info($"Checking button {button} exists for section: {section}");
			Report.Screenshot();
			return el.Displayed;
		}
		public bool ClickButton(string section, string button)
		{
			string path = $".//span[contains(text(),'{section}')]//..//a[@data-bind[contains(.,'{button}')]] | .//span[contains(text(),'{section}')]//..//a[contains(text(), '{button}')]";
			IWebElement el = this.ContainerElement.FindElement(By.XPath(path), 2);
			Report.Info($"Clicking {button} for document type: {section}");
			Report.Screenshot();
			if (el == null)
			{
				Report.Error($"The {button} button was not found!! - Looking for xpath: {path}");
				return false;
			}
			return el.TryClick() ;
		}

			public bool UploadFileForSection(string section, string pdfFilePath)
		{
			string path = "//span[contains(text(),'" + section + "')]//..//div[@class='ws-dropzone-container invalid']//a";
			IWebElement el = this.ContainerElement.FindElement(By.XPath(path), 2);
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
			Report.IsTrue(UploadDialog.UploadFile(pdfFilePath), "Failed to enter file name!", "Successfully entered file name");
			int i = 0;
			string viewPath = "//span[contains(text(),'" + section + "')]//..//span[@class='dz-uploaded-doc']//..//a";
			IWebElement viewEl = this.ContainerElement.WaitUntilElementVisible(By.XPath(viewPath), 60);
			return viewEl != null;
		}

		public bool UploadFileSection(string section, string pdfFilePath)
		{
			string path = "//label[contains(text(),'" + section + "')]/..//following-sibling::div/div/div[@class='ws-dropzone-container invalid']/a";
			IWebElement el = this.ContainerElement.FindElement(By.XPath(path), 2);
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
			Report.IsTrue(UploadDialog.UploadFile(pdfFilePath), "Failed to enter file name!", "Successfully entered file name");
			int i = 0;
			string viewPath = "//a[@class='btn btn-sm btn-primary']";
			IWebElement viewEl = this.ContainerElement.WaitUntilElementVisible(By.XPath(viewPath), 60);
			return viewEl != null;
		}

		//Use this when there are multiple instances of the label type on the documents page. EG. Product label (Generic Private Label and Volatile Organic Compounds)
		public bool UploadFileForSectionAndType(string label, string section, string pdfFilePath)
		{
			//var el = ContainerElement.FindElement(
			//By.XPath(
			//	".//div[child::label[contains(text(),'" + section + "')]]/following-sibling::div[//span[text()='" + label + "' and not(contains(@style, 'display: none;'))]]//a[text()='Browse']"),
			//2);
			
			IWebElement el = this.ContainerElement.FindElement(	By.XPath(".//div[child::label[contains(text(),'" + section + "')]]/following-sibling::div//span[text()='" + label + "' and not(contains(@style, 'display: none;'))]/..//a[text()='Browse']"),
				2);
			if (el == null)
			{
				return false;
			}

			if (!el.TryClick())
			{
				return false;
			}

			UploadDialog.UploadFile(pdfFilePath);

			int i = 0;
			while (this.ContainerElement.FindElement(By.XPath(".//span[contains(text(),'" + section + "')]//parent::div//a[text()='Remove']"), 2) == null && i < 10)
			{
				i++;
				Delay.Seconds(Delay.SpeedFactor * 1);
			}
			return true;
		}

		public bool CheckFileNameForSectionAndType(string label, string section, string pdffileName)
		{
			IWebElement el = this.ContainerElement.FindElement(By.XPath(".//div[child::label[contains(text(),'" + label + "')]]/following-sibling::div//span[text()='" + section + "' and not(contains(@style, 'display: none;'))]/..//div[@class='ws-dropzone-container']//span"), 2);

			if (el == null)
			{
				return false;
			}

			return el.Text == pdffileName;


		}

		public string GetDocumentTypeForSection(string section)
		{
			try
			{
				string xpath = ".//div[child::label[contains(text(),'" + section + "')]]/following-sibling::div[//span[not(contains(@style, 'display: none;'))]]/div[not(contains(@style,'display: none;'))]/span[contains(@data-bind, 'text: Description')]";
				IWebElement labelType = this.ContainerElement.FindElement(By.XPath(xpath));
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
			IWebElement el = this.ContainerElement.FindElement(By.XPath(xPath), 2);
			string colour = el?.GetCssValue("color");

			return colour;
		}


		public bool VOCConcentrationQuestionHasYesAndNo()
		{
			IWebElement lbl = this.ContainerElement.FindElements(By.XPath(".//label"), 2)
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
			IWebElement lbl = this.ContainerElement.FindElements(By.XPath(".//label"), 2)
				.FirstOrDefault(x => x.Text.Contains("VOC concentration"));

			if (lbl != null)
			{
				try
				{
					IWebElement error = lbl.FindElement(By.XPath("../..//input/../../../p//span"), 2);
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
				IList<IWebElement> errors = this.ContainerElement.FindElements(By.XPath("//div[contains(@class, 'alert')]"), 2);
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
			return this.ContainerElement.FindElement(By.XPath(".//label[contains(text(),'Product does not contain more than 0.05 grams of VOC per use')]"), 2).Text;
		}

		/// <summary>
		/// Gets statement - Would you like to use the VOC percentages entered for all areas (e.g. country, state, local) for comparison?
		/// </summary>
		public string GetUseVocPercentageAllAreaStatement()
		{
			return this.ContainerElement.FindElement(By.XPath(".//label[contains(text(),'VOC percentages entered for all areas')]"), 2).Text;
		}

		/// <summary>
		/// Gets statement - Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the CARB
		/// </summary>
		public string GetAmountOfVocDefinedByCARBStatement()
		{
			return this.ContainerElement.FindElement(By.XPath(".//label[contains(text(),'excluding exempt compounds as defined by the CARB')]"), 2).Text;
		}

		/// <summary>
		/// Gets statement - Verify VOC content is below the threshold of 0.02lb/start of CARB
		/// </summary>
		public string GetVOCContentBelowThresholdOfCARBStatement()
		{
			return this.ContainerElement.FindElement(By.XPath(".//label[contains(text(),'start of CARB')]"), 2).Text;
		}

		/// <summary>
		/// Gets statement - Verify VOC content is below the threshold of 0.02lb/start of OTC
		/// </summary>
		public string GetVOCContentBelowThresholdOfOTCStatement()
		{
			return this.ContainerElement.FindElement(By.XPath(".//label[contains(text(),'start of OTC')]"), 2).Text;
		}

		/// <summary>
		/// Gets statement - Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the OTC Model Rule
		/// </summary>
		public string GetAmountOfVocByOTCRuleStatement()
		{
			return this.ContainerElement.FindElement(By.XPath(".//label[contains(text(),'OTC Model Rule')]"), 2).Text;
			//return el != null;
		}

		/// <summary>
		/// Gets statement - Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the OTC Model Rule
		/// </summary>
		public bool GetAmountOfVocByOTCRuleNotStatement()
		{
			IWebElement el = this.ContainerElement.FindElement(By.XPath(".//label[contains(text(),'OTC Model Rule')]"), 2);
			return el != null;
		}

		/// <summary>
		/// Gets statement - VOC content in grams ozone per gram
		/// </summary>
		public string GetVocContentInGramsStatement()
		{
			return this.ContainerElement.FindElement(By.XPath(".//label[contains(text(),'VOC content in grams ozone per gram')]"), 2).Text;
		}

		/// <summary>
		/// Gets statement Based on your selection, you have verified your product contains VOC with intended uses as follows... the CARB VOC compliance limit(s) for the intended use you identified is/are:
		/// </summary>
		public string GetCarbVocComplianceLimitStatement()
		{
			return this.ContainerElement.FindElement(By.XPath(".//div[contains(@data-bind,'field.field')]//b[contains(text(),'CARB VOC compliance limit')]"), 2)?.Text;
		}

		/// <summary>
		/// Gets error message for VOC content in grams ozone per gram
		/// </summary>
		public string GetErrorMessageForVocContentInGrams()
		{
			return this.ContainerElement.FindElement(By.XPath(".//label[text()='VOC content in grams ozone per gram']/../following-sibling::div//span"), 2).Text;
		}

		// JS - consolidated  multiple methods to fetch CARB, MVOC etc. value text into one
		/// <summary>
		/// Gets value from Volatile Organic Compound Summary page below the state table. EG. CARB, HVOC, MVOC, OTC Model Rule, VOC Grams Ozone, VOC Analysis
		/// </summary>
		public string GetValueVOCSummary(string category)
		{
			return this.ContainerElement.FindElement(By.XPath(".//div[contains(@data-bind,'field.field') and contains(text(),'" + category + "')]//b"), 2)?.Text;
		}

		// JS - consolidated multiple methods to fetch statement text (eg. VOC limits, restrictive VOC limit etc) into one
		/// <summary>
		/// Gets statement text from VOC Summary page
		/// </summary>
		public string GetVocSummaryStatementText(string category)
		{
			return this.ContainerElement.FindElement(By.XPath(".//div[contains(@data-bind,'field.field') and contains(text(),'" + category + "')]"), 2)?.Text;
		}

		/// <summary>
		/// Gets VOC content as weight percentage of total formula, minus exempt compounds, for each of the following states. statement
		/// </summary>
		public string VocWeightPercentageForEachStateStatement()
		{
			return this.ContainerElement.FindElement(By.XPath(".//div[contains(@data-bind,'description') and contains(text(),'weight percentage of total formula')]"), 2).Text;
		}

		public List<string> GetVOCSummaryStatements()
		{
			ReadOnlyCollection<IWebElement> statements =
				this.ContainerElement.FindElements(By.XPath(".//div[contains(@class, 'success') and not(.//table)]"));
			return statements.Select(x => x.GetValue().Trim()).ToList();
		}

		public List<VocLimits> GetDisplayedVocLimits()
		{

			var retList = new List<VocLimits>();
			IWebElement tableElement = this.ContainerElement.FindElement(By.XPath(".//div[./div[text()='Limits']]/following-sibling::table"), 2);
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
			IWebElement tableElement = this.ContainerElement.FindElement(By.XPath(".//table[@class='table table-hover table-fixed']"), 2);
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
			List<string> stringList = columnHeadings.Select(x => x.Text).ToList();
			
			int currentPos;
			currentPos = 0;

			string useInd = "";
			string complianceInd = "";
			string unitsInd = "";
			string regulationInd = "";

			foreach(var thing in stringList)
			{
				switch (thing)
				{
					case "Use":
						useInd = (currentPos + 1).ToString();
						break;
					case "VOC Compliance Limit":
						complianceInd = (currentPos + 1).ToString();
						break;

					case "Units":
						unitsInd = (currentPos + 1).ToString();
						break;

					case "Regulation":
						regulationInd = (currentPos + 1).ToString();
						break;

					default:
						Report.Failure("Item must be one of 'Use', 'VOC Compliance Limit', 'Units' or 'Regulation'");
						return null;

				}

				currentPos++;
			}			


			//getIndex = columnHeadings.IndexOf(columnHeadings.FirstOrDefault(x => x.Text == "Use"), 2);	
			// If the returned index for any column name is -1, we return a null string for that property.
			//string useInd = getIndex == -1 ? null : (getIndex + 1).ToString();
			//getIndex = columnHeadings.IndexOf(columnHeadings.FirstOrDefault(x => x.Text == "VOC Compliance Limit"), 2);
			//string complianceInd = getIndex == -1 ? null : (getIndex + 1).ToString();
			//getIndex = columnHeadings.IndexOf(columnHeadings.FirstOrDefault(x => x.Text == "Units"), 2);
			//string unitsInd = getIndex == -1 ? null : (getIndex + 1).ToString();
			//getIndex = columnHeadings.IndexOf(columnHeadings.FirstOrDefault(x => x.Text == "Regulation"), 2);
			//string regulationInd = getIndex == -1 ? null : (getIndex + 1).ToString();

			foreach (IWebElement row in rows)
			{
				string use = useInd == null ? null : row.FindElement(By.XPath($".//td[{useInd}]"), 2)?.GetValue();
				string voccompliancelimit = complianceInd == null ? null : row.FindElement(By.XPath($".//td[{complianceInd}]"), 2)?.GetValue();
				string units = unitsInd == null ? null : row.FindElement(By.XPath($".//td[{unitsInd}]"), 2)?.GetValue();
				string regulation = regulationInd == null ? null : row.FindElement(By.XPath($".//td[{regulationInd}]"), 2)?.GetValue();
				retList.Add(new VocLimitsWithUnits() { Use = use, VocComplianceLimit = voccompliancelimit, Units = units, Regulation = regulation });
			}
			return retList;
		}

		public List<VocPercentForStates> GetDisplayedVocPercentForEachState()
		{

			var retList = new List<VocPercentForStates>();
			IWebElement tableElement = this.ContainerElement.FindElement(By.XPath("//div[text()='VOC content as weight percentage of total formula, minus exempt compounds, for each of the following states.']//parent::div//parent::div//following-sibling::table"), 2);
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

		public bool EnterVOCStateValue(string value)
		{
			try
			{
				IList<IWebElement> vocvalues = FindElements(By.XPath("//input[@type='text']"), 2);

				foreach (IWebElement vocvalue in vocvalues)
				{
					vocvalue.SendKeys(value);
					vocvalue.SendKeys(Keys.Tab);
				}
				return true;
			}catch(Exception e)
			{
				return false;
			}
		}

		public string Appearance {
			get
			{
				IWebElement lbl = this.ContainerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("Appearance"));

				if (lbl != null)
				{
					IWebElement input = lbl.FindElement(By.XPath("../..//select"), 2);
					return input.SelectedOption();
				}
				else
				{
					throw new Exception("Label not found as expected.");
				}

			}
			set
			{
				IWebElement lbl = this.ContainerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("Appearance"));

				if (lbl != null)
				{
					IWebElement input = lbl.FindElement(By.XPath("../..//select"), 2);
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
				IWebElement lbl = this.ContainerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("Odor"));

				if (lbl != null)
				{
					IWebElement input = lbl.FindElement(By.XPath("../..//select"), 2);
					return input.SelectedOption();
				}
				else
				{
					throw new Exception("Label not found as expected.");
				}

			}
			set
			{
				IWebElement lbl = this.ContainerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("Odor"));

				if (lbl != null)
				{
					IWebElement input = lbl.FindElement(By.XPath("../..//select"), 2);
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
				IWebElement lbl = this.ContainerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("Odor Threshold"));

				if (lbl != null)
				{
					IWebElement input = lbl.FindElement(By.XPath("../..//select"), 2);
					return input.SelectedOption();
				}
				else
				{
					throw new Exception("Label not found as expected.");
				}

			}
			set
			{
				IWebElement lbl = this.ContainerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("Odor Threshold"));

				if (lbl != null)
				{
					IWebElement input = lbl.FindElement(By.XPath("../..//select"), 2);
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
				IWebElement lbl = this.ContainerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("Partition Coefficient"));

				if (lbl != null)
				{
					IWebElement input = lbl.FindElement(By.XPath("../..//input"), 2);
					return input.Text;
				}
				else
				{
					throw new Exception("Label not found as expected.");
				}

			}
			set
			{
				IWebElement lbl = this.ContainerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("Partition Coefficient"));

				if (lbl != null)
				{
					IWebElement input = lbl.FindElement(By.XPath("../..//input"), 2);
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
			IWebElement el = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath(@".//span[(.//ancestor::div[starts-with(@class,'form-group')]//label[starts-with(text(),""" + section + @""")]) and contains(text(),'" + value + @"') and not(.//parent::label[contains(@class,'btn')])]/preceding-sibling::input"), 2);
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
			IList<IWebElement> els = this.ContainerElement.FindElements(By.XPath(".//label[@class='control-label']"), 2);
			DisplayedSections = els.Select(x => x.Text).ToList();
			return DisplayedSections;
		}

		public bool ClickAdoptionArticleLink()
		{
			IWebElement link = this.ContainerElement.FindElement(By.XPath(@"//label[@class='control-label']//a"), 2);
			if (link != null)
			{
				return link.TryClick();
			}
			else
			{
				return false;
			}
		}

		public bool CheckBoxOptionExists(string label)
		{
			IWebElement el = this.ContainerElement.FindElement(By.XPath($"//div[@class='form-subgroup']//div[@class='checkbox']//label//span[contains(text(),'{label}')]"), 2);
			return el != null;
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

				IWebElement el = this.ContainerElement.FindElement(By.XPath(xPath), 2);



				if (el == null)
				{
					string backupXPath = @"(//span[(.//ancestor::div[starts-with(@class,'form-group')]//label) and (./preceding-sibling::input[@type='checkbox'])]/preceding-sibling::input[@type='checkbox'] | " +
							@"//span[(.//ancestor::div[starts-with(@class,'form-group')]//label) and (./preceding-sibling::input[@type='radio'])]/parent::label | " +
							@"//input[(.//ancestor::div[starts-with(@class,'form-group')]//label) and @type='text'] | " +
							@"//select[(.//ancestor::div[starts-with(@class,'form-group')]//label)] | " +
							@"//div[@class='dropzone' and (.//ancestor::div[starts-with(@class,'form-group')]//label)] | " +
							@"//span[(.//ancestor::div[starts-with(@class,'form-group')]//label) and not(.//parent::label[contains(@class,'btn')])]/preceding-sibling::input)";
					List<IWebElement> backupElList = this.ContainerElement.FindElements(By.XPath(backupXPath), 2).ToList();
					List<IWebElement> labelElementsFromXpath = new List<IWebElement>();
					foreach (var thing in backupElList)
					{
						IWebElement currentLableEL = thing.FindElement(By.XPath(".//ancestor::div[starts-with(@class,'form-group')]//label"), 2);
						labelElementsFromXpath.Add(currentLableEL);
					}
					//This handles the new Line. If the devops test case does not space seperate when there is a new line the below will not match.
					//If issues arise could change below to and "or" and the replace with "" instead.
					el = labelElementsFromXpath.FirstOrDefault(x => x.Text.Replace("\r\n", " ").Contains(section));
				}
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

			IWebElement el = this.ContainerElement.FindElement(By.XPath(xPath), 2);

			if (el == null)
			{
				Report.Error("Could not find the correct input in section: " + section);
				return false;
			}

			if (el.TagName.ToLower() == "select")
			{
				return el.FindElements(By.XPath("//option"), 2).Select(x => x.Text.Trim()).Contains(value);
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

			IWebElement el = this.ContainerElement.FindElement(By.XPath(xPath), 2);

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
			IWebElement el = this.ContainerElement.FindElement(By.XPath(xPath), 10);
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

		public bool UnsetOptionInSectionSubSection(string section, string subSection, string value)
		{
			string xPath = $@"//div[preceding-sibling::div[./label[contains(text(),""{section}"")]]]//div[@class='form-subgroup' and preceding-sibling::div[.//span[contains(text(),'{subSection}')]]]//input[./following-sibling::span[contains(text(),'{value}')]]";
			IWebElement el = this.ContainerElement.FindElement(By.XPath(xPath), 10);
			if (el == null)
			{
				Report.Info($"Unable to find the input under section {section} and subsection {subSection} option {value}");
				return false;
			}
			if (el.GetAttribute("type") == "checkbox")
			{
				if (el.Checked())
				{
					el.TryClick();
					return !el.Checked();
				}
				else
				{
					Report.Info("Cannot uncheck the input as it was not checked to start");
					return false;
				}
			}
			Report.Info("Method only applicable to checkbox type input");
			return false;
		}

		public bool UnsetOptionInSection(string section, string value)
		{
			string xPath = $@"//div[preceding-sibling::div[./label[contains(text(),""{section}"")]]]//input[./following-sibling::span[contains(text(),'{value}')]]";
			IWebElement el = this.ContainerElement.FindElement(By.XPath(xPath), 10);
			if (el == null)
			{
				Report.Info($"Unable to find the input under section {section} option {value}");
				return false;
			}
			if (el.GetAttribute("type") == "checkbox")
			{
				if (el.Checked())
				{
					el.TryClick();
					return !el.Checked();
				}
				else
				{
					Report.Info("Cannot uncheck the input as it was not checked to start");
					return false;
				}
			}
			Report.Info("Method only applicable to checkbox type input");
			return false;
		}

		public bool UnselectTransportationOptions(string option)
		{
			bool pass = true;
			var transportationOptionCheckboxes = this.ContainerElement.FindElements(By.XPath(@"//span[contains(text(), '" + option + "')]/../../following-sibling::div//input"), 2).ToList();
			if (transportationOptionCheckboxes == null)
			{
				Report.Info("Failed to find parent for checkboxes!");
				pass = false;
				return pass;
			}
			foreach (IWebElement elem in transportationOptionCheckboxes)
			{
				if (elem != null && elem.Checked())
				{
					elem.TryClick();
				}
				else if (elem == null)
				{
					Report.Info("Failed to find appripropriate checkbox!");
					pass = false;
					return pass;
				}
				else
				{
					//do nothing.
				}
			}
			return pass;
		}




		public bool CheckStandaloneCheckbox(string description)
		{
			IWebElement el = this.StandaloneCheckbox(description);
			return el.TryClick() && GeneralUtilities.Wait_for_load_finish();
		}

		public IWebElement StandaloneCheckbox(string description)
		{
			IWebElement el = this.ContainerElement.FindElement(By.XPath($@".//div[@class='checkbox' and (.//span[contains(text(),'{description}')])]/label/input | .//div[span[text() = '{description}']]/input"), 2);
			IWebElement el2 = this.ContainerElement.FindElement(By.XPath($@".//input[@type='checkbox'][.//following-sibling::span[text()='{description}']]"));
			if (el == null)
			{
				if (el2 == null)
				{
					Report.Info($"Could not find checkbox with description: '{description}'");
					return null;
				}
				return el2;
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

			IWebElement el = this.ContainerElement.FindElement(By.XPath(xPath), 10);

			if(el==null)
			{
				Report.Info("The Element found from the original xpath was null");
			}

			if (section.Contains("Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations")|| section== "Product has been granted an Alternative Control Plan")
			{

				var elsFound = this.ContainerElement.FindElements(By.XPath("//ancestor::div[starts-with(@class,'form-group')]//div[@class='col-sm-4']"), 2).ToList();
				var upperEl = elsFound.First(x => x.Text.Contains(section));
				el = upperEl.FindElement(By.XPath($".//following-sibling::div[1]//label[.//span[contains(text(),'{value}')]]"), 2);

			}

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
				if(el.GetValue() == value)
				{
					return el.GetValue() == value;
				}
				else
				{
					int j = 0;
					bool textEntered = false;
					while (textEntered==false&&j<6)
					{
						Delay.Seconds(1);
						Report.Info($"Attempting to enter text, attempt: {j+2}");
						el.ClearTextBox();
						el.EnterText(value);
						textEntered = el.GetValue() == value;
						j++;
					}
					return textEntered;

				}
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
					if(el.Checked()==true)
					{
						return el.Checked();
					}
					else
					{
						int x = 0;
						bool isChecked = false;
						while(isChecked==false&&x<6)
						{
							Delay.Seconds(1);
							Report.Info($"Attempting to check box, attempt: {x + 2}");
							el.TryCheck();
							isChecked = el.Checked();
							x++;
						}
						return isChecked;
					}
				}

			}
			catch (Exception)
			{

			}
			// don't click the label if it contains a web link
			el.Scroll();
			el.ScrollElementIntoView();			
			if (el.FindElement(By.XPath("./span/a[contains(@href,'http')]"), 2) == null && el.TryClick())
			{
				Report.Info("Dont Click label if contains web link");
				Delay.Seconds(2);
				if (this.SelectedOptionsForSection(section).Contains(value))
				{
					return true;
				}
			}
			Report.Info("Trying a basic Try click on the element");
			return el.FindElement(By.XPath("./input"), 10).TryClick();
		}

		public bool SetOptionInSectionToExactlyMatch(string section, string value)
		{
			string xPath = @"(//span[(.//ancestor::div[starts-with(@class,'form-group')]//label[contains(text(),""" + section + @""")]) and text()=""" + value + @""" and (./preceding-sibling::input[@type='checkbox'])]/preceding-sibling::input[@type='checkbox'] | " +
						@"//span[(.//ancestor::div[starts-with(@class,'form-group')]//label[contains(text(),""" + section + @""")]) and text()=""" + value + @""" and (./preceding-sibling::input[@type='radio'])]/parent::label | " +
						@"//input[(.//ancestor::div[starts-with(@class,'form-group')]//label[contains(text(),""" + section + @""")]) and @type='text'] | " +
						@"//select[(.//ancestor::div[starts-with(@class,'form-group')]//label[contains(text(),""" + section + @""")])] | " +
						@"//span[(.//ancestor::div[starts-with(@class,'form-group')]//label[contains(text(),""" + section + @""")]) and text()=""" + value + @""" and not(.//parent::label[contains(@class,'btn')])]/preceding-sibling::input)";

			IWebElement el = this.ContainerElement.FindElement(By.XPath(xPath), 10);

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
				if (el.GetValue() == value)
				{
					return el.GetValue() == value;
				}
				else
				{
					int j = 0;
					bool textEntered = false;
					while (textEntered == false && j < 6)
					{
						Delay.Seconds(1);
						Report.Info($"Attempting to enter text, attempt: {j + 2}");
						el.ClearTextBox();
						el.EnterText(value);
						textEntered = el.GetValue() == value;
						j++;
					}
					return textEntered;

				}
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
					if (el.Checked() == true)
					{
						return el.Checked();
					}
					else
					{
						int x = 0;
						bool isChecked = false;
						while (isChecked == false && x < 6)
						{
							Delay.Seconds(1);
							Report.Info($"Attempting to check box, attempt: {x + 2}");
							el.TryCheck();
							isChecked = el.Checked();
							x++;
						}
						return isChecked;
					}
				}

			}
			catch (Exception)
			{

			}
			// don't click the label if it contains a web link
			if (el.FindElement(By.XPath("./span/a[contains(@href,'http')]"), 2) == null && el.TryClick())
			{
				Report.Info("Dont Click label if contains web link");
				Delay.Seconds(2);
				if (this.SelectedOptionsForSection(section).Contains(value))
				{
					return true;
				}
			}
			Report.Info("Trying a basic Try click on the element");
			return el.FindElement(By.XPath("./input"), 10).TryClick();
		}

		public bool SelectRadio(string section, string value)
		{
			try
			{
				string xPath = string.Format($"//span[(.//ancestor::div[starts-with(@class,'form-group')]//label[contains(text(),\"{section}\")]) and contains(text(),'{value}') and (./preceding-sibling::input[@type='radio'])]");
				IWebElement el;

				if (section == "Select the type of product to create" && value == "Create a New Registration")
				{
					xPath = string.Format($"//span[(.//ancestor::div[starts-with(@class,'form-group')]//label[contains(text(),'{section}')]) and text()='{value}' and (./preceding-sibling::input[@type='radio'])]");
					el = this.ContainerElement.FindElement(By.XPath(xPath), 2);

				}
				else if (section == "Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations.")
				{

					var elsFound = this.ContainerElement.FindElements(By.XPath("//ancestor::div[starts-with(@class,'form-group')]//div[@class='col-sm-4']"), 2).ToList();
					var upperEl = elsFound.First(x => x.Text.Contains(section));
					el = upperEl.FindElement(By.XPath($".//following-sibling::div[1]//label[.//span[contains(text(),'{value}')]]"), 2);

				}
				else
				{
					el = this.ContainerElement.FindElement(By.XPath(xPath), 2);
				}

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
			IWebElement el = this.ContainerElement.FindElement(By.XPath(xPath), 2);
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
			return this.ContainerElement.FindElement(By.XPath(@".//select[(.//ancestor::div[starts-with(@class,'form-group')]//label[starts-with(text(),""" + section + @""")])]"), 2).TryClick();
		}

		public List<string> SelectedOptionsForSection(string section)
		{

			IList<IWebElement> matchingElements;
			if (section == "Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations."||section == "Product has been granted an Alternative Control Plan")
			{

				var elsFound = this.ContainerElement.FindElements(By.XPath("//ancestor::div[starts-with(@class,'form-group')]//div[@class='col-sm-4']"), 2).ToList();
				var upperEl = elsFound.First(x => x.Text.Contains(section));
				matchingElements = upperEl.FindElements(By.XPath($".//following-sibling::div[1]//label//input"), 2);

			}
            else
            {
				matchingElements = this.ContainerElement.FindElements(By.XPath(@".//div[contains(@class,'form-group') and .//label[contains(text(),""" + section + @""")]]//*[name()='input' or name()='select']"), 2);
			}

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
			IList<IWebElement> els = this.ContainerElement.FindElements(By.XPath(xpath), 2);
			foreach (IWebElement el in els)
			{
				el.Check(check);
			}

			return true;
		}

		public string VocAnalysisDateStatement()
		{
			IWebElement vocAnalysisDateStatement =
				this.ContainerElement.FindElement(
					By.XPath(@"//div[contains(text(), 'VOC Analysis Date') and ancestor::div[@class='form-group has-success']]"), 2);
			return vocAnalysisDateStatement?.Text;
		}

		public int RadioButtonCountInSection(string section)
		{
			string xpath = @"//div[./label[contains(text(), """ + section + @""")]]/following-sibling::div//div[@class='radio']";
			IList<IWebElement> radios = this.ContainerElement.FindElements(By.XPath(xpath), 2);
			return radios?.Count ?? 0;
		}

		public List<string> RadioButtonsInSection(string section)
		{
			string xpath = @"//div[./label[contains(text(), """ + section + @""")]]/following-sibling::div//div[@class='radio']//span";
			IList<IWebElement> radios = this.ContainerElement.FindElements(By.XPath(xpath), 2);
			if (radios.Count == 0)
			{
				Report.Failure("There were no radios showing in section: " + section);
				return new List<string>();
			}
			return radios.Select(x => x.Text).ToList();
		}

		public List<string> CheckboxesInSection(string section)
		{
			string xpath = @"//div[./label[contains(text(), """ + section + @""")]]/following-sibling::div//div[@class='checkbox']//span";
			IList<IWebElement> checkboxes = this.ContainerElement.FindElements(By.XPath(xpath), 2);
			if (checkboxes.Count == 0)
			{
				Report.Failure("There were no checkboxes showing in section: " + section);
				return new List<string>();
			}
			return checkboxes.Select(x => x.Text).ToList();
		}

		// Currently deals with select (option) and input (radio)
		public List<string> GetAllOptionsForSection(string section)
		{
			Delay.Seconds(1);
			Report.Info("Beginning get all options for section.");
			var optionsText = new List<string>();
			IList<IWebElement> matchingElements;
			if (section == "Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations." || section == "Product has been granted an Alternative Control Plan")
			{

				var elsFound = this.ContainerElement.FindElements(By.XPath("//ancestor::div[starts-with(@class,'form-group')]//div[@class='col-sm-4']"), 2).ToList();
				var upperEl = elsFound.First(x => x.Text.Contains(section));
				matchingElements = upperEl.FindElements(By.XPath($".//following-sibling::div[1]//label//input"), 2);

			}
            else
            {
				matchingElements = SeleniumWebDriver.CurrentDriver.FindElements(By.XPath(@".//div[contains(@class,'form-group') and .//label[contains(text(),""" + section + @""")]]//*[name()='input' or name()='select']"), 2);
			}
			
			if (matchingElements.Count == 1 && matchingElements.FirstOrDefault().TagName.ToLower() == "select")
			{
				optionsText = matchingElements.FirstOrDefault().FindElements(By.XPath(@"./option"), 2).Select(x => x.Text).Where(x => x != "Choose...").ToList();
				// Occasionally needs some time to refresh the options in the drop down depending on the previous selection
				for (int i = 0; i < 5; i++)
				{
					optionsText = matchingElements.FirstOrDefault().FindElements(By.XPath(@"./option"), 2).Select(x => x.Text).Where(x => x != "Choose...").ToList();
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

		public List<string> GetAllOptionsForContainerTypeField()
		{
			var optionsText = new List<string>();
			IList<IWebElement> matchingElements = this.ContainerElement.FindElements(By.XPath(".//select[@class = 'form-control']//option"), 2).ToList();
			foreach( IWebElement element in matchingElements)
			{
				optionsText.Add(element.Text);
			}
			return optionsText;
		}

		public List<string> RegulatoryInformationLabelLinks()
		{
			var linksText = new List<string>();
			linksText = this.ContainerElement.FindElements(By.XPath(".//a[@class='link-publication']"), 2).Select(x => x.Text).ToList();
			return linksText;
		}

		public string GetRegulatoryInformation3Statement()
		{
			var statementEl = this.ContainerElement.FindElement(By.XPath(".//div[@class='col-sm-12']//div[@data-bind='html: field.field']//strong"), 2);
			return statementEl.Text;
		}

		public bool AddDocument(string documentName, string language)
		{
			IWebElement rowContainer = this.ContainerElement.FindElement(By.XPath(".//span[text()='" + documentName + "']//ancestor::div[contains(@class,'document-row')]"), 2);
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
			IWebElement rowContainer = this.ContainerElement.FindElement(By.XPath(".//span[text()='" + documentName + "']//ancestor::div[contains(@class,'document-row')]"), 2);
			int i = 0;
			while (i < 10 && rowContainer == null)
			{
				Delay.Seconds(Delay.SpeedFactor * 2);
				rowContainer = this.ContainerElement.FindElement(By.XPath(".//span[text()='" + documentName + "']//ancestor::div[contains(@class,'document-row')]"), 2);
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
		//	return ContainerElement.FindElement(By.XPath(@".//div[@class ='panel-heading']/following-sibling::table/following-sibling::div/p[@class='form-error']/span"), 15)?.Text;
		//}

		public bool ClickUseMyIngredients()
		{
			return this.ContainerElement.FindElement(By.XPath(".//button[starts-with(@data-bind,'click: openMyIngredients')]"), 2).TryClick() && GeneralUtilities.Wait_for_load_finish();
		}

		public bool EnterAdditionalRequirement(string retailerName, string valueToEnter)
		{
			ReadOnlyCollection<IWebElement> selectedRetailersNames = this.ContainerElement.FindElements(By.XPath(".//div[@class='grid-container']//tr[parent::tbody[@data-bind='foreach: field.field']]/td[@class='col-xs-3']"));
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
			return this.ContainerElement.FindElement(By.XPath(".//div[contains(@data-bind,'field.field') and starts-with(text(), 'VOC content in g/L')]/b"), 2).Text;
		}

		public List<string> AllAdditionalStatements()
		{
			string xPath = ".//div[@data-bind='html: field.field' and parent::div[@class='col-sm-12']]";
			IList<IWebElement> statements = this.ContainerElement.FindElements(By.XPath(xPath), 2);
			if (statements.IsNullOrEmpty())
			{
				return new List<string>();
			}
			return statements.Select(x => x.Text.Trim()).ToList();
		}

		public List<string> AllAdditionalStatementParagraphs()
		{
			string xPath = @".//div[@data-bind='html: field.field' and parent::div[@class='col-sm-12']]/p";
			IList<IWebElement> paragraphs = this.ContainerElement.FindElements(By.XPath(xPath), 2);
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
			IWebElement box = this.ContainerElement.FindElement(By.XPath(xPath), 2);
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
				IWebElement section = this.ContainerElement.FindElement(By.XPath(xPath), 2);
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
			return this.ContainerElement.FindElement(By.XPath(@"//div[//div[text()='Provide the EPA Registration Number']]//table"), 10);
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
			IWebElement el = this.ContainerElement.FindElement(By.XPath(".//label[contains(text(),'Product Line')]/../following-sibling::div//select"), 2);
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

			IWebElement el = this.ContainerElement.FindElement(By.XPath(xPath), 2);

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

			thisAlert.Title = this.ContainerElement
				.FindElement(By.XPath(".//div[contains(@class,'alert')]/p[contains(@class, 'text-danger')]/strong"), 2)
				.Text;
			thisAlert.SubTitle = this.ContainerElement
				.FindElement(By.XPath(".//div[contains(@class,'alert')]/p[contains(@class, 'text-danger')]"), 2).GetInnerText();

			thisAlert.Text = this.ContainerElement
				.FindElement(By.XPath(
					".//div[contains(@class,\'alert\')]/p[contains(@class, \'text-danger\')]/following-sibling::p"), 2)
				.Text;

			thisAlert.Links = this.ContainerElement
				.FindElements(By.XPath(
					".//div[contains(@class,\'alert\')]/p[contains(@class, \'text-danger\')]/following-sibling::p/a"), 2)
				.Select(x => new Mailosaur.Models.Link() {
					Href = x.GetAttribute("href"),
					Text = x.Text
				}).ToList();

			return thisAlert;
		}

		public bool ClickAlertLink(string linkText)
		{
			return this.ContainerElement
				.FindElements(By.XPath(
					".//div[contains(@class,\'alert\')]/p[contains(@class, \'text-danger\')]/following-sibling::p/a"), 2)
				.FirstOrDefault(x => x.Text == linkText).TryClick();
		}

		public void MoveToLabel(string section)
		{
			try
			{
				string xPath = @"(//label[contains(text(),""" + section + @""")]))";
				SeleniumWebDriver.CurrentDriver.FindElement(By.XPath(xPath), 2).TryClick();
			}
			catch (Exception)
			{

			}
		}

		public string FormError()
		{
			IWebElement formError = this.ContainerElement.FindElement(By.XPath(".//ul[@class='form-error']/li"), 2);
			var formErrorText = formError?.Text;
			return formErrorText;
		}

		public bool SelectPackageType(string packageType)
		{
			IWebElement container = this.ContainerElement.FindElement(By.XPath(".//table[@class='table table-hover upc-table']"), 2);
			IWebElement upcNumberField = container.FindElement(By.XPath(".//label[contains(text(),'GTIN/UPC')]/..//input"), 2);

			IWebElement pkgType = container.FindElement(By.XPath(".//select[contains(@data-bind,'Package Type')]"), 2);
			pkgType.Select(packageType);
			return pkgType.GetValue() == packageType;
		}

		public List<string> GetPackageOptions()
		{
			IWebElement container = this.ContainerElement.FindElement(By.XPath(".//table[@class='table table-hover upc-table']"), 2);
			IWebElement upcNumberField = container.FindElement(By.XPath(".//label[contains(text(),'GTIN/UPC')]/..//input"), 2);

			IWebElement pkgType = container.FindElement(By.XPath(".//select[contains(@data-bind,'Package Type')]"), 2);
			return pkgType.FindElements(By.XPath(".//option"), 2).Select(x => x.GetValue()).ToList();
		}

		internal void SetProductName(string productType)
		{
			IWebElement productName = this.ContainerElement.FindElement(By.XPath(@"//*[@id='collapse1']/div/form/div[1]/div[2]/input"), 2);
			productName.EnterText(productType);
		}

		public bool PurchaseSummaryClickRemove(string product)
		{
			//  2/6/23 S.A --> container element locator incorrect, fix at later date! 
			//IWebElement remove = this.ContainerElement.WaitUntilElementVisible(By.XPath($"//table[@class='table table-hover']//tr//b[text()[contains(.,'{product}')]]/following-sibling::a[contains(text(), 'Remove')]"), 2);

			Report.Info("locating the remove link");


			IWebElement remove = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath($"//table[@class='table table-hover']//tr//b[text()[contains(.,'{product}')]]/following-sibling::a[contains(text(), 'Remove')]"), 2);


			Report.Info("attempting to click the remove button"); 
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
				IWebElement container = this.ContainerElement.FindElement(By.XPath(".//table[@class='table table-hover upc-table']"), 2);
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

		public bool EnsureArrowIsExpandedforUPC(string upc)
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
				IWebElement container = this.ContainerElement.FindElement(By.XPath(".//table[@class='table table-hover upc-table']"), 2);
				IWebElement upcmatch = container.FindElements(By.XPath(".//span[contains(@data-bind,'upc')]"), 2).FirstOrDefault(x => x.Text.Contains(upc))
								?? container.FindElements(By.XPath(".//span[contains(@data-bind,'upc')]"), 2).FirstOrDefault(x => x.GetValue().Contains(upc))
							   ?? container.FindElements(By.XPath(".//input[contains(@data-bind,'upc')]"), 2).FirstOrDefault(x => x.GetValue().Contains(upc));
				if (upcmatch == null)
				{
					return false;
				}
				IWebElement arrowclass = upcmatch.FindElement(By.XPath("./ancestor::tr[position()=1]//a[@title='Expand']"), 2);
				IWebElement arrowclassEl = arrowclass.FindElement(By.XPath(".//em"), 2);
				if (arrowclassEl.IsNullOrEmpty())
				{
					Report.Info("Failed to find arrow");
					return false;
				}
				if (arrowclassEl.GetAttribute("class").Contains("right"))
				{
					Report.Info("The Arrow for the Upc was not expanded, now clicking the element to try and expand the UPC");
					if (arrowclass.TryClick())
					{
						Report.Info("Successfully clicked expand arrow.");
						Report.Screenshot();
						Report.IsTrue(arrowclassEl.GetAttribute("class").Contains("down"), "Failed to expand the UPC sections", "Successfully expanded the UPC Section");
					}
					else
					{
						Report.Info("Failed to click the arrow");
						return false;
					}

				}
				else
				{
					if (arrowclassEl.GetAttribute("class").Contains("down"))
					{
						Report.Info("The UPC Arrow was already expanded");
						return true;
					}
					Report.Info($"The Class was found to be: {arrowclassEl.GetAttribute("class")} and this was not one of the expected options");
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

		public bool CheckIfUPCDuplicateWarningAppears()
		{
			Report.Info("Beginning CheckIfUPCDuplicateWarningAppears");
			IWebElement UPCWarning = this.ContainerElement.FindElement(By.XPath("//i[contains(@title, 'UPC')]"), 2);
			if (UPCWarning == null)
			{
				Report.Info("UPCWarning returns null");
				return false;
			}
			Report.Info("UPCWarning found!");
			return true;
		}

		public bool CheckWarningMessageHasAppeared(string warning)
		{
			Report.Info("Beginning CheckIfUPCDuplicateWarningAppears");
			string UPCTextWarning = this.ContainerElement.FindElement(By.XPath("//p[contains(text(), '" + warning + "')]"), 2).Text;
			if (UPCTextWarning == "")
			{
				Report.Info("UPCTextWarning returns an empty string");
				return false;
			}
			return true;
		}

		public bool CheckUPCTableIsHighlightedRed()
		{
			Report.Info("Beginning CheckUPCTableIsHighlightedRed");
			var table_BG = this.ContainerElement.FindElement(By.XPath(".//table[@class='table table-hover upc-table']/child::tbody/child::tr/child::td"), 1);
			if (table_BG == null)
			{
				Report.Info("UPC Table returns a null value!");
				return false;
			}
			var B_Col = table_BG.GetCssValue("background-color");
			if (B_Col == "")
			{
				Report.Info("UPC Table returns an empty string");
				return false;
			}
			if (B_Col == "rgba(242, 222, 222, 1)")
			{
				Report.Info("UPC Table is highlighted Red!");
				return true;
			}
			return false;

		}
		public bool CheckInputFieldXIsColor(string expectedColor, string fieldName)
		{
			bool fieldIsCorrectColor = false;

			Report.Info($"Looking at the input field with label {fieldName}");

			Report.Info($"Exepcted Color is: {expectedColor}");

			IWebElement inputField;
			IWebElement parentContainer;


			string expectedColorCode;


			List<IWebElement> parentContainers = this.ContainerElement.FindElements(By.XPath($".//div[contains(@data-bind,'visible: DocumentID().length') and .//span[contains(text(),'{fieldName}')]]"), 2).ToList();
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
					//parentContainer = this.ContainerElement.FindElement(By.XPath($".//div[@data-bind='visible: DocumentID().length > 0' and .//span[contains(text(),'{fieldName}')]]"), 2);
					//inputField = parentContainer.FindElement(By.XPath(".//div[@class='ws-dropzone-container']"), 2);
					break;

				case "Red":
					expectedColorCode = "rgba(255, 240, 240, 1)";
					//parentContainer = this.ContainerElement.FindElement(By.XPath($".//div[@data-bind='visible: DocumentID().length == 0' and .//span[contains(text(),'{fieldName}')]]"), 2);
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

		public bool CheckInputFieldColor(string expectedColor, string fieldName)
		{
			bool fieldIsCorrectColor = false;

			Report.Info($"Looking at the input field with label {fieldName}");

			Report.Info($"Exepcted Color is: {expectedColor}");

			string expectedColorCode;

			switch (expectedColor)
			{
				case "Green":
					expectedColorCode = "rgba(240, 255, 240, 1)";
					//parentContainer = this.ContainerElement.FindElement(By.XPath($".//div[@data-bind='visible: DocumentID().length > 0' and .//span[contains(text(),'{fieldName}')]]"), 2);
					//inputField = parentContainer.FindElement(By.XPath(".//div[@class='ws-dropzone-container']"), 2);
					break;

				case "Red":
					expectedColorCode = "rgba(255, 240, 240, 1)";
					//parentContainer = this.ContainerElement.FindElement(By.XPath($".//div[@data-bind='visible: DocumentID().length == 0' and .//span[contains(text(),'{fieldName}')]]"), 2);
					//inputField	= parentContainer.FindElement(By.XPath(".//div[@class='dropzone']"), 2);

					break;
				default:
					Report.Error("expectedColor must be either: 'Red' or 'Green'");
					return false;
			}
			string inputFieldColor = this.InputField(fieldName).GetCssValue("background-color");

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

		public bool ClickRestoreSelectedRetailersButton()
		{
			IWebElement RestoreSelectedRetailersButton = this.ContainerElement.FindElement(By.XPath(".//a[@data-bind='click: restoreSelectedRetailers']"), 2);
			return RestoreSelectedRetailersButton.TryClick();
		}

		public bool ClickSelectAllInRemovedRetailersBox()
		{
			IWebElement SelectAllRemovedRetailersButton = this.ContainerElement.FindElement(By.XPath(".//input[@data-bind='click: checkAllRemoved; checked: allRemovedRetailersChecked']"), 2);
			return SelectAllRemovedRetailersButton.TryClick();
		}

		public bool FillInUPCData(string productUPC, string productType, string productWeight)
		{
			IWebElement UPCTextBox = this.ContainerElement.FindElement(By.XPath(".//input[@data-bind='textInput: upcNumber.field']"), 2);
			bool EnteredProductUPC = Report.IsTrue(UPCTextBox.TryEnterText(productUPC), "Failed to enter product UPC", "Successfully entered product UPC");

			IWebElement ContainerTypeTextBox = this.ContainerElement.FindElement(By.XPath(".//select[contains(@data-bind,'Container Type')]"), 2);
			ContainerTypeTextBox.Select(productType);

			IWebElement SizeTextBox = this.ContainerElement.FindElement(By.XPath(".//input[@placeholder='Size (Weight Ounces)']"), 2);
			bool EnteredProductWeight = Report.IsTrue(SizeTextBox.TryEnterText(productWeight), "Failed to enter product weight in ounces", "Successfully enter product weight in ounces");

			if (EnteredProductUPC && EnteredProductWeight)
			{
				return true;
			}

			return false;
		}
		
		
		public bool RemoveRandomRetailers()
		{


			//This currently is not fully robust. Something about the page means that when you go to select the delete button for a given retailer the tryclick fails.
			//This appears to be related to the element not being on screen, but even with a scroll into view the element is off the screen
			//The issue is moslty fixed by using a page up loop, but it appears in some cases, especially if a lot of retailers are removed, then some try clicks still fail
			//Either an alternative click or a more robust 'scrolling' solution are needed to make this work at all times.


			//RemoveRandomRetailersWithoutSameBeginningLetter
			List<IWebElement> retailerRows = this.ContainerElement.FindElements(By.XPath($"//div[@class='row']//div//span[@data-bind='text: identifier']"), 5).ToList();
			List<int> listOfAlreadyRemovedButtonIndexes = new List<int>();
			List<char> beginningLettersFound = new List<char>();
			Random random = new Random();			
			int numOfLoops = random.Next(2, retailerRows.Count - 1);
			List<string> RemovedRetailersInitials = new List<string>();

			// xpath to use //div[@class='row']//div//span[@data-bind='text: identifier']//ancestor::div[1]//following-sibling::div[a[@title='Remove']]//a[@title='Remove']//em[@class='fa fa-remove']
			bool allButtonClicked = true;
			IWebElement anchorEl = this.ContainerElement.FindElement(By.Id("txtSearch"), 2);

			Report.Info($"The random number of loops will be: {numOfLoops}");

			for (int i = 0; i <= numOfLoops; i++)
			{

				retailerRows = this.ContainerElement.FindElements(By.XPath($"//div[@class='row']//div//span[@data-bind='text: identifier']"), 5).ToList();
				int ran = random.Next(0, retailerRows.Count);

				

				if (!listOfAlreadyRemovedButtonIndexes.Contains(ran))
				{

					IWebElement chosenRow = retailerRows[ran];
					string foundRetailerInitials = chosenRow.Text;
					char firstLetter = foundRetailerInitials[0];
					Report.Info($"Initials of the retailer found was: {foundRetailerInitials}");
					Report.Info($"First letter of retailer was: {firstLetter}");
					if(!beginningLettersFound.Contains(firstLetter))
					{

						var delButtonEl = chosenRow.FindElement(By.XPath($".//ancestor::div[1]//following-sibling::div[a[@title='Remove']]//a[@title='Remove']//em[@class='fa fa-remove']"), 5);
						if(delButtonEl.IsNullOrEmpty())
						{
							Report.Info($"The Delete button element was not found");
							return false;
						}
						delButtonEl.ScrollElementIntoView();
						if(delButtonEl.TryClick())
						{
							Report.Info($"Successfully clicked the delete button for: {foundRetailerInitials}");
						}
						else
						{
							Report.Info($"Starting scrolling");
							GeneralUtilities.ScrollToBottomOfPage();
							for(int x = 0; x<6; x++)
							{
								anchorEl.SendKeys(Keys.PageUp);
								if(delButtonEl.VisibleInViewport())
								{
									Report.Info($"The delete button for the retailer was now visisble");
									
									break;
								}
							}
							Report.Info($"Going to tryclick....");
							if (!delButtonEl.TryClick())
							{
								allButtonClicked = false;
								Report.Info($"Failed to click the delete button for: {foundRetailerInitials}");
							}
							else
							{
								Report.Info($"Successfully clicked the delete button for: {foundRetailerInitials}");
							}

						}
						if(allButtonClicked==false)
						{
							Report.Info($"did not click delete for retailer after all attempts");
							return false;
						}	
						Report.Info($"Adding retailer to lists");
						beginningLettersFound.Add(firstLetter);
						RemovedRetailersInitials.Add(foundRetailerInitials);
					}
					else
					{
						Report.Info($"A retailer with that starting character was already deleted, moving on.");
					}				

				}
				else
				{
					i -= 1;
					Report.Info($"I was now: {i}");
				}
			}


			Context.AddToContext("LatestRemovedRetailers", RemovedRetailersInitials);
			return allButtonClicked;


		}

		public bool RemoveRetailers(Table table)
		{
			foreach (TableRow row in table.Rows)
			{
				string retailer = row["Retailer"];
				IWebElement deleteButton = this.ContainerElement.FindElement(By.XPath(".//span[@data-bind='text: identifier' and text()='" + retailer + "']/following-sibling::a[@title='Remove']//em[@class='fa fa-remove']"), 2);
				if (deleteButton == null)
				{
					Report.Info("Failed to find delete button for retailer " + retailer + "!");
					return false;
				}
				bool canClick = deleteButton.TryClick();
				if (!canClick)
				{
					Report.Info("Failed to click the delete button for retailer " + retailer + "!");
					return false;
				}
			}

			return true;
		}

		public bool AddRandomRetailersThatWereRemoved()
		{

			IList<IWebElement> CheckBoxes = this.ContainerElement.FindElements(By.XPath(".//ul[@aria-labelledby='ddAddRetailers']//input[@type='checkbox']"), 2);
			List<int> listOfAlreadyClickedCheckBoxIndexes = new List<int>();
			List<string> restoredRetailers = new List<string>();


			for (int i = 0; i < CheckBoxes.Count; i++)
			{
				if (CheckBoxes[i].Text.Contains("Select All"))
				{
					CheckBoxes.RemoveAt(i);
				}
			}

			Random random = new Random();
			int numOfLoops = random.Next(1, CheckBoxes.Count - 1);
			for (int i = 0; i < numOfLoops; i++)
			{
				int ran = random.Next(1, CheckBoxes.Count);
				if (!listOfAlreadyClickedCheckBoxIndexes.Contains(ran))
				{
					IWebElement CheckBox = CheckBoxes[ran];
					listOfAlreadyClickedCheckBoxIndexes.Add(ran);
					bool SelectedCheckboxForRetailer = Report.IsTrue(CheckBox.TryClick(), "Failed to select checkbox for retailer", "Successfully selected checkbox for retailer");

					if (!SelectedCheckboxForRetailer)
					{
						return false;
					}

					IWebElement textLabelEl = CheckBox.FindElement(By.XPath($".//following-sibling::a"), 2);
					string labelString = textLabelEl.Text;
					restoredRetailers.Add(labelString);


				}
				else
				{
					i -= 1;
				}
			}
			Context.AddToContext($"LastRestoredRetailers", restoredRetailers);
			return true;
		}

		public bool AddRetailersThatWereRemoved(Table table)
		{
			foreach (TableRow row in table.Rows)
			{
				string retailer = row["Retailer"];
				IWebElement elem = this.ContainerElement.FindElement(By.XPath("//a[text()='" + retailer + "']/preceding-sibling::input"), 2);
				if (elem == null)
				{
					Report.Info("Could not find the correct checkbox element on the page");
					return false;
				}
				bool canClick = elem.TryClick();
				if (canClick == false)
				{
					Report.Info("Could not click on checkbox element");
					return false;
				}
			}
			return true;
		}

		public bool SelectAllRetailersThatWereRemoved()
		{
			IWebElement RestoreRetailersButton = this.ContainerElement.FindElement(By.XPath(".//ul[@aria-labelledby='ddAddRetailers']//input[@id='chkAllRemovedRetailers']"), 2);
			return Report.IsTrue(RestoreRetailersButton.TryClick(), "Failed to click 'Restore Retailers' button", "Successfully clicked 'Restore Retailers' button");

		}

		public bool SelectAllRetailersInTable(Table table)
		{
			IWebElement DoneButton = this.ContainerElement.FindElement(By.XPath(".//a[@data-bind='click: closePopup']"), 2);
			var stepsNewProduct = new StepsNewProduct();

			foreach (TableRow row in table.Rows)
			{
				
				ReportSettings.UseSubSteps = true;
				var stepsRetailer = new Retailer();
				Report.StartStep("In the Select Retailers popup I select the retailer: " + (row["Retailer"]));
				new StepsSelectRetailers().SelectTheRetailer((row["Retailer"]));
				Report.StartStep("I enter private label as 'This Private Label'");
				stepsRetailer.EnterPrivateLabelName("This Private Label");

			}

			bool DoneButtonClicked = Report.IsTrue(DoneButton.TryClick(), "Failed to click 'Done' button", "Successfully clicked 'Done' button");
			stepsNewProduct.ClickContinue();

			return DoneButtonClicked;
		}

		public bool ClickAddRetailersButton()
		{
			IWebElement AddRetailersButton = this.ContainerElement.FindElement(By.XPath(".//a[@id='ddAddRetailers']"), 2);
			return AddRetailersButton.TryClick();
		}

		public bool CheckIfListOfRemovedRetailersAreInAlphabeticalOrder()
		{
			IList<IWebElement> RemovedRetailers = this.ContainerElement.FindElements(By.XPath(".//a[@data-bind='text: name, click: $parent.restoreRetailer.bind($parent)']"), 2);
			List<string> RemovedRetailerNames = new List<string>();
			foreach (IWebElement element in RemovedRetailers)
			{
				RemovedRetailerNames.Add(element.Text);
			}

			var expectedList = RemovedRetailerNames.OrderBy(x => x).ToList();

			return Report.IsTrue(expectedList.SequenceEqual(RemovedRetailerNames),
			"List of added retailers was not sorted as expected. Found: " + string.Join(",", RemovedRetailerNames),
			"Added retailer names are in order");

		}

		public List<string> GetListOfRemovedRetailersInPopup()
		{
			IList<IWebElement> RemovedRetailers = this.ContainerElement.FindElements(By.XPath(".//a[@data-bind='text: name, click: $parent.restoreRetailer.bind($parent)']"), 2);
			if(RemovedRetailers.IsNullOrEmpty())
			{
				Report.Info("el was null for RemovedRetailers");
				return null;
			}
			List<string> RemovedRetailerNames = new List<string>();
			foreach (IWebElement element in RemovedRetailers)
			{
				RemovedRetailerNames.Add(element.Text);
			}
			return RemovedRetailerNames;
		}

		public bool ListOfRemovedRetailersDoesNotContainListSavedAs(string savedAs)
		{
			var listOfRestored = (List<string>)Context.GetFromContext(savedAs);
			if (listOfRestored.IsNullOrEmpty())
			{
				Report.Info("el was null for listOfRestored");
				return false;
			}
			var foundRetailers = this.GetListOfRemovedRetailersInPopup();
			if (foundRetailers.IsNullOrEmpty())
			{
				Report.Info("el was null for foundRetailers");
				return false;
			}

			Report.Info($"The list of restored retailers was: {string.Join(",", listOfRestored)}");
			Report.Info($"The list of deleted retailers was: {string.Join(",", foundRetailers)}");

			if (foundRetailers.Any(x => listOfRestored.Any(y => y == x)))
			{
				Report.Info($"Restored Retailers were still found in the deleted retailers list...");
				return false;
			}
			else
			{
				Console.WriteLine("No Restored Retailers were found in the deleted retailers list");
				return true;
			}

		}

		public bool CheckAllRetailesInAddRetailersPopupAreSelected()
		{
			IList<IWebElement> RemovedRetailers = this.ContainerElement.FindElements(By.XPath(".//a[@data-bind='text: name, click: $parent.restoreRetailer.bind($parent)']"), 2);
			if (RemovedRetailers.IsNullOrEmpty())
			{
				Report.Info("el was null for RemovedRetailers");
				return false;
			}
			foreach(var item in RemovedRetailers)
			{
				if(!item.Checked())
				{
					Report.Info($"The item was not checked");
					return false;
				}	
			}
			Report.Info($"All Retailers were selected");
			return true;
		}

		public bool CheckIfListOfAddedRetailersAreInAlphabeticalOrder()
		{
			IList<IWebElement> AddedRetailers = this.ContainerElement.FindElements(By.XPath(".//span[@data-bind='text: identifier']"), 2);
			List<string> AddedRetailersNames = new List<string>();
			foreach (IWebElement element in AddedRetailers)
			{
				AddedRetailersNames.Add(element.Text);
			}

			var expectedList = AddedRetailersNames.OrderBy(x => x).ToList();

			return Report.IsTrue(expectedList.SequenceEqual(AddedRetailersNames),"List of added retailers was not sorted as expected. Found: " + string.Join(",", AddedRetailersNames),"Added retailer names are in order");
		}

		public bool CompanyTollFreePhoneNumber(string text)
		{
			try
			{
				IWebElement el = this.ContainerElement.FindElement(By.XPath(".//label[contains(text(),'Toll-Free Phone Number')]/../following-sibling::div//input"), 2);

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
				IWebElement el = this.ContainerElement.FindElement(By.XPath(".//label[contains(text(),'Company Web Address')]/../following-sibling::div//input"), 2);

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
				IWebElement el = this.ContainerElement.FindElement(By.XPath(".//label[contains(text(),'GTIN')]/..//following-sibling::div//select"), 2);
				return el.SelectedOption();
			}
			set
			{
				IWebElement el = this.ContainerElement.FindElement(By.XPath(".//label[contains(text(),'GTIN')]/..//following-sibling::div//select"), 2);
				el.Select(value);
			}
		}

		public bool ClickAddPartNumber()
		{
			IWebElement el = this.ContainerElement.FindElement(By.XPath(".//button[contains(@data-bind,'PartNumber')]"), 2);
			return el != null && el.TryClick();
		}



		public bool InputPartNumberInformation(UpcInformation info, string partNumber)
		{
			try
			{
				IWebElement container = this.ContainerElement.FindElement(By.XPath(".//table[@class='table table-hover upc-table']"), 2);
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
					
					if (packageField == null)
					{
						return false;
					}

					packageField.Select(info.PackageType);
				}

				if (partNameTextField == null)
				{
					Report.Info(@"partNameTextField was not found");
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

		public bool FinalDomesticDistributor(string text)
		{
			try
			{
				IWebElement el = this.ContainerElement.FindElement(By.XPath(".//label[text()='Who is the Final Domestic Distributor (if any) of the product?']/../following-sibling::div//input"), 2);

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

		public bool CheckForErrorInTheFollowingFieldsInTheLithiumBatteryTransportationSection(Table table)
		{
			foreach (TableRow row in table.Rows)
			{
				IWebElement field = this.ContainerElement.FindElement(By.XPath("//label[contains(text(), \"" + row["Field"] + "\")]/../following-sibling::div//span[text()='This is a required field.']"), 2);

				if (field == null)
				{
					return false;
				}
			}

			return true;
		}

		public bool CheckTransportationCatagoryXIsChecked(string catagory)
		{
			Report.Info($"Checking that the Catagory {catagory} is checked");
			IWebElement optionInput = this.ContainerElement.FindElement(By.XPath($".//span[text()='{catagory}']//preceding-sibling::input"), 2);
			return optionInput.Checked();
		}

		public bool CheckTransportationOptionXIsCheckedForCatagoryY(string catagory, string option)
		{
			Report.Info($"Checking that the option {option} is checked");
			IWebElement optionInput = this.ContainerElement.FindElement(By.XPath($".//tr//div//div[.//span[text()='{catagory}']]//div[./span[text()='{option}']//preceding-sibling::input]//input"), 2);
			return optionInput.Checked();
		}

		public bool TransportationColumnExists()
		{
			Report.Info("Checking to see if Transportation column exists");
			IWebElement transportation = this.ContainerElement.FindElement(By.XPath(@"//table//tr//th[contains(text(), 'Transportation')]"), 2);
			return transportation != null;
		}

		public bool CheckTransportationOption(string option, string transLevel)
		{
			bool pass = true;
			Report.Info("Check to ensure that " + option + " is listed as " + transLevel);
			IWebElement optionInput = this.ContainerElement.FindElement(By.XPath($".//span[text()='{option}']//preceding-sibling::input"), 2);
			if (optionInput == null || !optionInput.Checked())
			{
				pass = false;
			}
			if (this.TransLevelInput(option, transLevel) == null || !this.TransLevelInput(option, transLevel).Checked())
			{
				pass = false;
			}
			return pass;
		}

		public bool CanCheckTransportationOption(string option, string transLevel)
		{
			Report.Info("Checking if you can check level " + transLevel + " for option " + option + ".");
			IWebElement transLevelInput = this.TransLevelInput(option, transLevel);

			if (transLevelInput.Checked())
			{
				return true;
			}

			transLevelInput.TryClick();

			if (transLevelInput.Checked())
			{
				return true;
			}

			return false;
		}

		public bool ExceptionsArePresent()
		{
			if (this.Exception1 == null)
			{
				Report.Info("Could not find element for exception '173.150(g)(1)(A)'");
				return false;
			}
			if (this.Exception2 == null)
			{
				Report.Info("Could not find element for exception '173.150(g)(1)(I)(B)'");
				return false;
			}
			if (this.Exception3 == null)
			{
				Report.Info("Could not find element for exception '173.150(g)(1)(II)(A)'");
				return false;
			}
			if (this.Exception4 == null)
			{
				Report.Info("Could not find element for exception '173.150(g)(1)(II)(B)'");
				return false;
			}

			return true;
		}

		public bool CannotSelectMultipleExceptions()
		{
			this.Exception1.TryClick();
			this.Exception2.TryClick();

			if (this.Exception1.Checked())
			{
				Report.Info("User is incorrectly allowed to select more than one option");
				return false;
			}

			this.Exception3.TryClick();

			if (this.Exception1.Checked() || this.Exception2.Checked())
			{
				Report.Info("User is incorrectly allowed to select more than one option");
				return false;
			}

			this.Exception4.TryClick();

			if (this.Exception1.Checked() || this.Exception2.Checked() || this.Exception3.Checked())
			{
				Report.Info("User is incorrectly allowed to select more than one option");
				return false;
			}

			this.Exception1.TryClick();

			if (this.Exception4.Checked() || this.Exception2.Checked() || this.Exception3.Checked())
			{
				Report.Info("User is incorrectly allowed to select more than one option");
				return false;
			}

			return true;
		}

		public bool UPCTransportationCheckboxPresent(string option)
		{
			IWebElement optionInput = this.ContainerElement.FindElement(By.XPath($".//span[text()='{option}']//preceding-sibling::input"), 2);
			return optionInput != null;
		}

		public bool SelectUPCTransportationOptionAtLevel(string option, string transLevel)
		{
			return this.TransLevelInput(option, transLevel).TryClick();
		}

		public List<string> GetDataAcceptancePageAlerts()
		{
			IList<IWebElement> el = this.ContainerElement.FindElements(By.XPath(".//div[@class='alert alert-danger' and contains(@data-bind,'visible')]"), 2);
			if (el.Count > 0)
			{
				return this.ContainerElement.FindElements(By.XPath(".//div[@class='alert alert-danger' and contains(@data-bind,'visible')]"), 2).Select(x => x.GetValue()).ToList();
			}
			return new List<string>();
		}

		public bool DataAcceptanceShowsAlertX(string expectedAlert)
		{
			List<string> foundAlerts = this.GetDataAcceptancePageAlerts();
			if (foundAlerts.IsNullOrEmpty())
			{
				Report.Info("No alert messages were found");
				return false;
			}
			foreach (var msg in foundAlerts)
			{
				Report.Info($"The Error message found was: {msg.Trim()}");
				if (msg.Trim().Contains(expectedAlert))
				{
					Report.Info("The Error message found was the expected message");
					return true;
				}
			}
			Report.Info("Checked all the alerts, the expected message was not found");
			return false;
		}

		public bool CheckAlertMessageText(string displayedText)
		{
			IWebElement alertMessage = this.ContainerElement.FindElement(By.XPath("//div[@class='col-sm-12']//div[@class='alert alert-danger']"), 2);
			var displayedTextWithoutApastraphy = displayedText.Replace("'", "");
			var alertMessageTextWithoutApastraphy = displayedText.Replace("'", "");

			if (alertMessageTextWithoutApastraphy.Equals(displayedTextWithoutApastraphy))
			{
				return true;
			}

			return false;
		}

		public bool SelectRestrictUseOption(string retrictOption)
		{
			IWebElement restrictOptionCheckBox = this.ContainerElement.FindElement(By.XPath("//span[contains(text(),'" + retrictOption + "')]/preceding-sibling::input"), 2);
			return restrictOptionCheckBox.TryCheck();
		}

		public bool CheckOptionsInDropDownMenusForTheFollowingSectinons(Table table)
		{

			List<string> unexpectedOptions = new List<string>();

			foreach (TableRow row in table.Rows)
			{ 
				IList<IWebElement> options = this.ContainerElement.FindElements(By.XPath("//div[@class='col-sm-4']//label[text()='" + row["Section"] + "']/../following-sibling::div//select//option"), 2);
				string[] strArr = row["Options"].Split(',');

				var index = 0;
				var defaultOptionFound = false;
				
				foreach (var option in options)
				{
					if (option.Text.Contains("Choose"))
					{
						index = options.IndexOf(option);
						defaultOptionFound = true;
					}
				}

				if (defaultOptionFound)
				{
					options.RemoveAt(index);
				}

				if (strArr.Count() != options.Count())
				{
					Report.Failure("The amount of options expected and the amount of options found were not the same");
					return false;
				} else if (options.Count() < 1)
				{
					Report.Failure("No options were found");
					return false;
				}
				foreach (IWebElement option in options)
				{
					string optionText = option.Text;
					if (optionText != "Choose..." && optionText != "choose...")
					{
						if (!strArr.Contains(optionText))
						{
							unexpectedOptions.Add(optionText);
						}
					}
				}

			}

			if (unexpectedOptions.Count > 0)
			{
				foreach (string option in unexpectedOptions)
				{
					Report.Info("Unexpected option found: " + option);
				}
				return false;
			}

			return true;
		}

		public bool CheckForPNKSectionTitleWithText(string shouldOrShouldNot, string titleText)
		{
			IWebElement sectionTitle = this.ContainerElement.FindElement(By.XPath(@"//div[text()='" + titleText + "']"), 2);
			if (shouldOrShouldNot.ToLower() == "should")
			{
				return sectionTitle != null;
			} else
			{
				return sectionTitle == null;
			}
		}

		public bool CheckForInputFieldInSection(string sectionName)
		{
			IWebElement section = this.ContainerElement.FindElement(By.XPath(@"//label[text()='" + sectionName + "']/../following-sibling::div//input"), 2);
			return section != null;
		}

		public bool EnterTextInInputFieldInSection(string enterText, string sectionName)
		{
			IWebElement section = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath(@"//label[text()='" + sectionName + "']/../following-sibling::div//input"), 2);
			return section.TryEnterText(enterText);
		}

		public bool EnterWHMISSDSDocumentDate(string text)
		{
			try
			{
				IWebElement el = this.ContainerElement.FindElement(By.XPath(".//label[text()='WHMIS SDS Document Date']/../following-sibling::div//input"), 2);

				if (el != null)
				{
					el.EnterText(text);
					el.SendKeys(Keys.Enter);
					return el.GetAttribute("value") == text;
				}

				return false;
			}
			catch (Exception)
			{
				return false;
			}

		}

		public bool CheckRegulatoryDocumentsConfirmationBox()
		{
			var el = this.ContainerElement.FindElement(By.XPath(".//div[@class='checkbox']//input[//span[contains(text(),'I confirm I am providing the most current Safety Data Sheet (SDS), Article Information Sheet (AIS) and/or Product Label for this registration.')]]"), 2);
			bool clicked= el.TryClick();
			bool isChecked = el.Checked();
			return clicked && isChecked;
			
		}

		public bool CheckInputFieldText(string fieldName, string text) {
		
			IWebElement el = this.ContainerElement.FindElement(By.XPath("//label[text()='" + fieldName + "']/../following-sibling::div//input"), 2);
			if (el.Text == text)
			{
				return true;
			}

			return false;
		}

		public bool CheckInputFieldPlaceholder(string fieldName, string placeholder)
		{

			IWebElement el = this.ContainerElement.FindElement(By.XPath(".//label[text()='" + fieldName + "']/../following-sibling::div//input[@placeholder='" + placeholder + "']"), 2);
			if (el != null)
			{
				return true;
			}

			return false;
		}

		public bool ConfirmOptionIsCheckedInSection(string option, string section)
		{
			IWebElement optionEl = this.ContainerElement.FindElement(By.XPath("//label[text()='" + section + "']/../following-sibling::div//span[text()='" + option + "']/preceding-sibling::input"), 2);
			if (optionEl.Checked())
			{
				return true;
			}

			return false;
		}
		public bool GetTransportationOption(string option)
		{
			IWebElement transportationOption = this.ContainerElement.FindElement(By.XPath(".//span[@data-bind='text: transportToString()']"));
			string transportationValue = transportationOption.Text;
			Report.Info("Transportation Option : "+transportationValue);
			return transportationValue.Equals(option);
		}
		public bool SelectTransportationOption(string option)
		{
			IWebElement selectionBox = this.ContainerElement.FindElement(By.XPath("(.//select[@class='form-control'])[3]"), 2);
			selectionBox.Select(option);
			return selectionBox.SelectedOption() == option;
		}
		public bool ClickArrow()
		{
			IWebElement element = this.ContainerElement.FindElement(By.XPath(".//a[@title='Expand']"), 2);
			return element.TryClick();
		}
		public bool SelectCaseUPCDropDownArrowForUPC(string savedAs, string expandOrCollapse)
		{
			IWebElement optionEl;
			if (expandOrCollapse.ToLower() == "expand")
			{
				optionEl = this.ContainerElement.FindElement(By.XPath("//span[text()='" + savedAs + "']/../..//em[@class='fa fa-chevron-right']"), 2);
			}
			else
			{
				optionEl = this.ContainerElement.FindElement(By.XPath("//input[@placeholder='GTIN or UPC (include check digit)']/../../..//a[@title='Expand']"), 2);
			}
			return optionEl.TryClick();
		}

		public bool ConfirmUPCNumberIsDisplayedInUPCNumberField(string savedAs)
		{
			IWebElement optionEl = this.ContainerElement.FindElement(By.XPath("//input[@data-bind='textInput: upcNumber.field']"), 2);
			if (optionEl.Text == savedAs)
			{
				return true;
			}

			return false;
		}

		public bool ConfirmFieldExists(string field)
		{
			IList<IWebElement> fields = this.ContainerElement.FindElements(By.XPath("//div[@class='form-group has-success']"), 2);

			if (field == "UPC")
			{
				field = "upcNumber";
			}
			else if (field == "Name")
			{
				field = "name";
			}
			else if (field == "Container")
			{
				field = "type";
			}
			else if (field == "Size")
			{
				field = "size";
			}
			else if (field == "Quantity")
			{
				field = "quantity";
			}
			else if (field == "Individual UPC")
			{
				field = "upcContained";
			}
			else if (field == "Transport")
			{
				field = "transport";
			}
			else if (field == "Package")
			{
				field = "packType";
			}

			IWebElement fieldEl = this.ContainerElement.FindElement(By.XPath("//div[@data-bind=\"css: { 'has-success': " + field + ".isValid() && " + field + ".hasValue(), 'has-error': !" + field + ".isValid() }\"]"), 2);

			if (field != null)
			{
				return true;
			}

			return false;
		}

		public bool ConfirmLowerFieldIsBelowUpperField(string lowerField, string upperField)
		{
			IList<IWebElement> fields = this.ContainerElement.FindElements(By.XPath("//div[@class='form-group has-success']"), 2);

			if (lowerField == "UPC" || upperField == "UPC")
			{
				if (lowerField == "UPC")
				{
					lowerField = "upcNumber";
				}
				if (upperField == "UPC")
				{
					upperField = "upcNumber";
				}
			}
			if (lowerField == "Name" || upperField == "Name")
			{
				if (lowerField == "Name")
				{
					lowerField = "name";
				}
				if (upperField == "Name")
				{
					upperField = "name";
				}
			}
			if (lowerField == "Container" || upperField == "Container")
			{
				if (lowerField == "Container")
				{
					lowerField = "type";
				}
				if (upperField == "Container")
				{
					upperField = "type";
				}
			}
			if (lowerField == "Size" || upperField == "Size")
			{
				if (lowerField == "Size")
				{
					lowerField = "size";
				}
				if (upperField == "Size")
				{
					upperField = "size";
				}
			}
			if (lowerField == "Quantity" || upperField == "Quantity")
			{
				if (lowerField == "Quantity")
				{
					lowerField = "quantity";
				}
				if (upperField == "Quantity")
				{
					upperField = "quantity";
				}
			}
			if (lowerField == "Indvidual UPC" || upperField == "Indvidual UPC")
			{
				if (lowerField == "Indvidual UPC")
				{
					lowerField = "upcContained";
				}
				if (upperField == "Indvidual UPC")
				{
					upperField = "upcContained";
				}
			}
			if (lowerField == "Transport" || upperField == "Transport")
			{
				if (lowerField == "Transport")
				{
					lowerField = "transport";
				}
				if (upperField == "Transport")
				{
					upperField = "transport";
				}
			}
			if (lowerField == "Package" || upperField == "Package")
			{
				if (lowerField == "Package")
				{
					lowerField = "packType";
				}
				if (upperField == "Package")
				{
					upperField = "packType";
				}
			}

			IWebElement lowerFieldEl = this.ContainerElement.FindElement(By.XPath("//div[@data-bind=\"css: { 'has-success': " + lowerField + ".isValid() && " + lowerField + ".hasValue(), 'has-error': !" + lowerField + ".isValid() }\"]"), 2);
			IWebElement upperFieldEl = this.ContainerElement.FindElement(By.XPath("//div[@data-bind=\"css: { 'has-success': " + upperField + ".isValid() && " + upperField + ".hasValue(), 'has-error': !" + upperField + ".isValid() }\"]"), 2);

			if (fields.IndexOf(lowerFieldEl) > fields.IndexOf(upperFieldEl))
			{
				return true;
			}

			return false;
		}

		public bool ConfirmTruckIconIsDisplayingNextToUPC(string savedAs)
		{
			IWebElement optionEl = this.ContainerElement.FindElement(By.XPath("//span[text()='" + savedAs + "']/../..//i[@class='fa fa-truck']"), 2);
			if (optionEl != null)
			{
				return true;
			}

			return false;
		}

		public bool ConfirmCaseUPCDetailsAreCollapsedForUPC(string savedAs)
		{
			IWebElement optionEl = this.ContainerElement.FindElement(By.XPath("//span[text()='" + savedAs + "']/../..//input[@data-bind='textInput: upcNumber.field']"), 2);
			if (optionEl == null)
			{
				return true;
			}

			return false;
		}

		public bool ConfirmCaseDropDownContainsUPC(string savedAs)
		{
			IWebElement optionEl = this.ContainerElement.FindElement(By.XPath("//span[@data-bind='text: upcNumber.field'][text()='" + savedAs + "']"), 2);
			if (optionEl != null)
			{
				return true;
			}

			return false;
		}

		public bool ConfirmCaseDropDownWithUPCIsAvailableForSelection(string savedAs)
		{
			IWebElement optionEl = this.ContainerElement.FindElement(By.XPath("//span[@data-bind='text: upcNumber.field'][text()='" + savedAs + "']/../..//input"), 2);

			if (optionEl != null)
			{
				optionEl.TryCheck();
				return optionEl.Checked();
			}

			return false;
		}


		public bool ConfirmSectionIsAvailableForSelection(string sectionName)
		{
			IList<IWebElement> options = this.ContainerElement.FindElements(By.XPath("//label[text()=\"" + sectionName + "\"]/../following-sibling::div//div[@data-toggle='buttons']//input"), 2);

			if (options.Count != 2)
			{
				Report.Info("The amount of options found were not as expected");
				return false;
			}

			foreach (IWebElement el in options)
			{
				if ((el.Text.ToLower() != "no") && (el.Text.ToLower() != "yes"))
				{
					Report.Info("An option with an unexpected name was found");
					return false;
				}

				if (!el.TryClick())
				{
					Report.Info("At least one option was not clickable");
					return false;
				}

			}

			return true;
		}

		public bool CheckForOptionsInIndividualUPCField()
		{
			IList<IWebElement> options = this.ContainerElement.FindElements(By.XPath("//option[text()='Individual UPC contained in the Case Pack']/..//option"), 2);

			if (options.Count < 2)
			{
				return true;
			}

			return false;
		}

		public bool ConfirmTruckIconIsDisplayedForUPC(string savedAs)
		{
			IWebElement truckIcon = this.ContainerElement.FindElement(By.XPath("//span[@data-bind='text: upcNumber.field'][text()='" + savedAs + "']/following-sibling::i"), 2);
			if (truckIcon != null)
			{
				return true;
			}

			return false;
		}

		public bool ConfirmTierDataShowsCorrectAnswer(string answer)
		{
			IWebElement answerEl = this.ContainerElement.FindElement(By.XPath("//h3[text()='Consent to Tier 2.1, 2.2, 4.2 Data Uses']/following-sibling::p[@data-bind='html: Data']"), 2);
			if (answerEl != null)
			{
				if (answerEl.Text == answer)
				{
					return true;
				}
			}

			return false;
		}

		public bool CheckTextInForumulationBatteriesPage()
		{

			IWebElement displayedText = this.ContainerElement.FindElement(By.XPath("//div[@data-bind='html: description, attr: { class: msgClass }']"), 2);
			var foundText = displayedText.Text;

			var updatedString = foundText.Replace("\r\n\r\n", "|");

			var updatedStringFinal = updatedString.Replace("\r\n", "|");

			string[] foundStringArray = updatedStringFinal.Split('|');
			for (int i=0;i<foundStringArray.Count();i++)
			{

				if (foundStringArray[0] != "Data Use Consents")
				{
					Report.Failure("The first line in the displayed text was incorrect");
					return false;
				}
				if (foundStringArray[1] != "Direct suppliers with products containing your battery (i.e., your customers) may opt to participate in various chemical policy and product qualification programs operated by WERCSmart Recipients. Further information about these consents and data uses are provided in the Data Use Tier Disclosure section of the WERCSmart Terms of Use.")
				{
					Report.Failure("The second line in the displayed text was incorrect");
					return false;
				}
				if (foundStringArray[2] != "You have the option of allowing this battery to be included in such programs by providing the consent below. Such consent means:")
				{
					Report.Failure("The third line in the displayed text was incorrect");
					return false;
				}
				if (foundStringArray[3] != "a. That your battery data may be utilized when UL generates aggregate usage reports, chemical screening results and transparency ratios for such Direct Supplier products (Tier 2.1),")
				{
					Report.Failure("The fourth line in the displayed text was incorrect");
					return false;
				}
				if (foundStringArray[4] != "b. That the identity of ingredients in your battery (i.e., the standard chemical names or CAS Numbers) may be disclosed to your customer and the relevant WERCSmart Recipient, but only if you have marked an ingredient as publicly disclosed on the formulation page (Tier 2.2) or if applicable law requires that an ingredient be publicly disclosed, and")
				{
					Report.Failure("The fifth line in the displayed text was incorrect");
					return false;
				}
				if (foundStringArray[5] != "c. That your customer can publicly disclose the identity of ingredients in your battery, but only if you have marked an ingredient as publicly disclosed (Tier 4.2).")
				{
					Report.Failure("The sixth line in the displayed text was incorrect");
					return false;
				}
				if (foundStringArray[6] != "These consents do not authorize any disclosure of ingredient by percent weight to your customer, any retail Recipient, or the public.")
				{
					Report.Failure("The seventh line in the displayed text was incorrect");
					return false;
				}
			}
				return true;
		}

		public bool CheckTextOnThePage(string[] correctText)
		{

			List<IWebElement> displayedText = this.ContainerElement.FindElements(By.XPath("//div[@data-bind='html: description, attr: { class: msgClass }'] | //div[@data-bind='html: description']"), 2).ToList();
			bool result = true;
			foreach (IWebElement element in displayedText)
			{
				var foundText = element.Text;

				var updatedString = foundText.Replace("\r\n\r\n", "|");

				var updatedStringFinal = updatedString.Replace("\r\n", "|");

				string[] foundStringArray = updatedStringFinal.Split('|');
				if (foundStringArray.Length == correctText.Length)
				{
					for (int i = 0; i < foundStringArray.Count(); i++)
					{

						if (foundStringArray[i] != correctText[i])
						{
							Report.Failure($"The line in the displayed text was incorrect, expected text is '{correctText[i]}', but actual text is '{foundStringArray[i]}'");
							result = false;
						}

					}
				}
			}
			return result;
		}

		public void InTheRegulatoryDocumentsToProvideScreenIfTheConfirmSDSQuestionIsSeenThenGrant()
		{

			var MyStepsNewProduct = new StepsNewProduct();
			var newProdClass = new NewProduct();

			if (newProdClass.CheckBoxOptionExists("I confirm I am providing the most current Safety Data Sheet"))
			{
				Report.StartStep(@"In the regulatory documents to provide screen I tick the box next to the question: 'I confirm I am providing the most current Safety Data Sheet (SDS), Article Information Sheet (AIS) and/or Product Label for this registration'");
				MyStepsNewProduct.SelectConfirmRegulatoryDocumentsConfirmationQuestion();
			}
		}

		public bool ConfirmOptionalReportsFooterContains(string expectedText)
		{
			IWebElement footerTextEl = this.ContainerElement.FindElement(By.XPath(".//div[@data-bind='html: field.field']"), 2);
			if(footerTextEl==null)
			{
				Report.Info($"The element was null");
				return false;
			}
			var footerTextFound = footerTextEl.Text;
			return footerTextFound.Contains(expectedText);
		}

		public bool ConfirmNoResultsAreReturnedForProductType()
		{
			IWebElement topResult = this.ContainerElement.FindElement(By.XPath(@"//span[@class='select2-results']//li[1][text()='No results found']"), 2);

			if (topResult == null)
			{
				return false;
			}

			return true;

		}

		public bool ConfirmSKUFieldWasBlank()
		{
			IWebElement skuField = this.ContainerElement.FindElement(By.XPath(@"//input[@data-bind='textInput: sku.field']"), 2);
			return skuField.Text.Length == 0;
		}

		public bool ClearTextBox(string placeholderValue)
		{
			IWebElement textbox = this.ContainerElement.FindElement(By.XPath($@".//input[@type='text' and @placeholder='{placeholderValue}']")); 
			return textbox.ClearTextBox(); 
		}

		public bool ConfirmTextboxDisplayed(string placeholderValue)
		{
			IWebElement textbox = this.ContainerElement.FindElement(By.XPath($@".//input[@type='text' and @placeholder='{placeholderValue}']"));
			return textbox != null;
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
		public string CapsuleCount { get; set; } = "";
		public string Size { get; set; } = "";
		public string Dpci { get; set; } = "";
		public string Quantity { get; set; } = "";
		public string PackageType { get; set; } = "";
		public string UPCName { get; set; } = "";
		public string ItemNumber { get; set; } = "";
		public string InternalSKU { get; set; } = "";

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

		public List<Mailosaur.Models.Link> Links { get; set; }
	}

	class RegulatoryList : SeleniumBaseObject
	{
		public const string BasePath = "//div[@class='modal fade in']";
		protected override By ContainerElementLocator => By.XPath(BasePath);

		public string Heading()
		{
			return this.ContainerElement.FindElement(By.XPath(".//h3"), 2)?.Text;
		}

		public bool ClickClose()
		{
			return this.ContainerElement.FindElement(By.XPath(".//button[@class='btn btn-default']"), 2).TryClick();
		}
		public class RegulatoryListItem
		{
			public string RegulatoryCode { get; set; }
			public string Classification { get; set; }
		}
		public List<RegulatoryListItem> GetRegulatoryListRows()
		{
			var rList = new List<RegulatoryListItem>();
			ReadOnlyCollection<IWebElement> rows = this.ContainerElement.FindElements(By.XPath(".//tbody/tr"));
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
