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
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product.Product_Characteristics;
using System.Drawing;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product
{
	public class PanelPrototype:SeleniumBaseObject
	{
		#region Page Objects
		private string _label;
		protected override By ContainerElementLocator => By.XPath($"//div[contains(@class,'wizard-step-panel')][.//h3[text()='{_label}']]");
		private IWebElement PanelExpandButton => this.FindElement(By.XPath(".//a[@href]"), 1);
		private IWebElement PanelButton(string buttonLabel) => this.FindElement(By.XPath($".//a[contains(@class,'btn')][text()='{buttonLabel}']"), 1);
		private IWebElement PanelDescription => this.FindElement(By.XPath(".''//div[contains(@data-bind,'html: description')]"), 1);
		#endregion

		#region Methods

		public PanelPrototype(string label)
		{
			Report.Info($"Attempting to get {label} panel.");
			_label = label;
		}
		public bool PanelExpandButtonExists()
		{
			Report.Info($"Attempting to confirm panel expand button exists.");
			return this.PanelExpandButton != null;
		}

		public bool PanelExpandButtonClick()
		{
			Report.Info($"Attempting to click panel expand button.");
			return this.PanelExpandButton.TryClick();
		}

		public bool PanelButtonExists(string buttonLabel)
		{
			Report.Info($"Attempting to confirm '{buttonLabel}' button exists.");
			return this.PanelButton(buttonLabel) != null;
		}

		public bool PanelButtonClick(string buttonLabel)
		{
			Report.Info($"Attempting to click '{buttonLabel}' button.");
			return this.PanelButton(buttonLabel).TryClick();
		}

		public bool PanelDescriptionExists()
		{
			Report.Info($"Attempting to confirm panel description exists.");
			return this.PanelDescription != null;
		}

		public string PanelDescriptionText()
		{
			Report.Info($"Attempting to get panel description text");
			return this.PanelDescription.Text;
		}
		#endregion
	}
	public class ProductPrototype: SeleniumBaseObject
	{
		#region Page Objects
		private string _label;
		protected override By ContainerElementLocator => By.XPath($@"//div[contains(@class,'form-group')][.//label[@class='control-label' or @class='sr-only'][text()=""{_label}""]]");
		private IWebElement Option(string optionLabel) => this.FindElement(By.XPath($".//div[@class='radio' or @class='checkbox' or @class='btn-group'][.//*[text()='{optionLabel}']]//input[@type='radio' or @type='checkbox']"), 1);
		private IWebElement OptionLabel(string optionLabel) => this.FindElement(By.XPath($".//div[@class='radio' or @class='checkbox' or @class='btn-group'][.//*[text()='{optionLabel}']]//label"), 1);

		#endregion

		#region Methods
		public ProductPrototype(string label)
		{
			Report.Info($"Attempting to get '{label}' group.");;
			_label = label;
		}
		#region Option Input Methods
		public bool OptionExists(string optionLabel)
		{
			Report.Info($"Attempting to confirm {optionLabel} option exists.");
			return this.Option(optionLabel) != null;
		}
		public string GetOptionColorBackground(string optionLabel)
		{
			Report.Info($"Attempting to get {optionLabel} background color.");
			return this.OptionLabel(optionLabel).GetCssValue("background-color");
		}
		public bool OptionClick(string optionLabel)
		{
			Report.Info($"Attempting to click {optionLabel} option.");
			return this.Option(optionLabel).TryClick();
		}

		public bool OptionSelected(string optionLabel)
		{
			Report.Info($"Attempting to confirm {optionLabel} radio option is selected.");
			return this.Option(optionLabel).Selected;
		}

		public bool OptionSelect(string optionLabel)
		{
			bool isSelected = this.OptionSelected(optionLabel);
			if(!isSelected)
			{
				isSelected = this.OptionClick(optionLabel);
			}
			return isSelected;
		}

		public bool OptionSetSelect(bool selected, string optionLabel)
		{
			bool isSelected = this.OptionSelected(optionLabel);
			if (isSelected != selected)
			{
				isSelected = this.OptionClick(optionLabel);
			}
			return this.OptionSelected(optionLabel) == selected;
		}
		#endregion

		#region Text Input Methods
		private IWebElement TextInputGet()
		{
			Report.Info($"Attempting to get text input.");
			return this.FindElement(By.XPath($".//input[@type='text']|.//textarea"),1);
		}

		public bool TextInputExists()
		{
			Report.Info($"Attempting to confirm text input exists.");
			var test = this.TextInputGet();
			return this.TextInputGet() != null;
		}

		public bool TextInputEnterText(string text)
		{
			Report.Info($"Attempting to enter '{text}'.");
			return this.TextInputGet().TryEnterText(text);
		}

		public string TextInputGetText()
		{
			Report.Info($"Attempting to get current text in text input.");
			return this.TextInputGet().GetValue();
		}
		#endregion
		#region Text Area Methods
		private IWebElement TextFieldGet()
		{
			Report.Info($"Attempting to get text area.");
			return this.FindElement(By.XPath($".//div[contains(@data-bind, 'field.field')]"), 1);
		}

		public bool TextFieldExists()
		{
			Report.Info($"Attempting to confirm text input exists.");
			var test = this.TextInputGet();
			return this.TextFieldGet() != null;
		}
		public string TextFieldGetText()
		{
			Report.Info($"Attempting to get current text in text input.");
			return this.TextFieldGet().GetValue();
		}
		#endregion
		#region Error Message Methods
		private IWebElement ErrorMessageGet(string errorMessage)
		{
			Report.Info($"Attempting to get '{errorMessage}' error message.");
			return this.ContainerElement.FindElement(By.XPath($".//*[@class='form-error'][.//*[contains(text(),'{errorMessage}')]] | .//*[@class='fa fa-exclamation-triangle fa-align-right text-danger'][.//*[contains(text(),'{errorMessage}')]]"), 1);
		}

		public bool ErrorMessageExists(string errorMessage)
		{
			Report.Info($"Attempting to confirm '{errorMessage}' error message exists.");
			return this.ErrorMessageGet(errorMessage) != null;
		}
		#endregion

		#region Search Input Methods
		private IWebElement SearchInputSpanGet()
		{
			Report.Info($"Attempting to get search input span.");
			return this.FindElement(By.XPath(".//span[contains(@class,'select2-container')]"),1);
		}

		public bool SearchInputSpanExists()
		{
			Report.Info($"Attempting to confirm search input span exists.");
			return this.SearchInputSpanGet() != null;
		}

		public bool SearchInputSpanClick()
		{
			Report.Info($"Attempting to click search input span.");
			return this.SearchInputSpanGet().TryClick();
		}

		public string SearchInputSpanText()
		{
			Report.Info($"Attempting to get search input span text.");
			return this.SearchInputSpanGet().Text;
		}
		#endregion

		#region Checkbox Input Methods
		private IWebElement CheckboxOptionGet(string optionLabel)
		{
			Report.Info($"Attempting to get {optionLabel} checkbox option.");
			return this.ContainerElement.FindElement(By.XPath($".//div[@class='checkbox'][.//*[text()='{optionLabel}']]//input[@type='checkbox']"), 1);
		}
		#endregion
		#endregion
	}

	public class SearchBoxResult
	{
		#region Page Objects
		private IWebElement ContainerElement { get; set; }
		public string ResultText => this.ContainerElement?.Text;
		public string ComponentName => this.ContainerElement.FindElement(By.XPath(".//span[@class='component-name']"), 1)?.Text;
		public string CASNumber => this.ContainerElement.FindElement(By.XPath(".//span[@class='text-muted']"), 1)?.Text;
		public List<string> SynonymList => this.ContainerElement.FindElements(By.XPath(".//li"), 1).Select(x => x?.Text).ToList();
		public bool Highlighted => this.ContainerElement.GetAttribute("class").Contains("-highlighted");
		public string DisplayName => this.ComponentName.IsNullOrEmpty() ? this.ResultText : this.ComponentName;
		#endregion
		#region Methods
		public SearchBoxResult(IWebElement searchBoxComponent)
		{
			this.ContainerElement = searchBoxComponent;
		}

		public bool Click()
		{
			Report.Info($"Attempting to click '{this.DisplayName}' search result.");
			return this.ContainerElement.TryClick();
		}
		#endregion
	}

	public class SearchBoxPrototype:SeleniumBaseObject
	{
		#region Page Objects
		protected override By ContainerElementLocator => By.XPath($"//span[contains(@class,'select2-container--open')][.//input[@type='search']]");
		private IWebElement SearchInput => this.FindElement(By.XPath(".//input[@type='search']"),1);
		List<SearchBoxResult> SearchResultList => this.ContainerElement.FindElements(By.XPath(".//li[contains(@class,'select2-results')][@data-select2-id]"), 1).Select(x => new SearchBoxResult(x)).ToList();
		private IWebElement SearchResultAlert(string alertText) => this.FindElement(By.XPath($".//li[@role='alert'][@text()='{alertText}']"), 1);
		private IWebElement SearchResultLoading => this.FindElement(By.XPath(".//li[.//div[@class='loading']]"), 1);
		#endregion

		#region Methods
		public bool SearchInputExists()
		{
			Report.Info($"Attempting to confirm search input box exists.");
			return this.SearchInput != null;
		}
		public bool ClearSearchTextBox()
		{
			Report.Info($"Attempting to confirm search input box exists.");
			return this.SearchInput.ClearTextBox();
		}

		public bool SearchInputClick()
		{
			Report.Info($"Attempting to click search input box.");
			return this.SearchInput.TryClick();
		}

		public bool SearchInputEnterText(string text)
		{
			Report.Info($"Attempting to enter '{text}' into search input text box");
			return this.SearchInput.TryEnterText(text);
		}

		public bool SearchResultAlertExists(string alertText)
		{
			Report.Info($"Attempting to confirm search result '{alertText}' alert exists.");
			return this.SearchResultAlert(alertText) != null;
		}

		public bool SearchResultsExists()
		{
			Report.Info($"Attempting to confirm search results exist.");
			return !this.SearchResultList.IsNullOrEmpty();
		}
		
		public bool SearchResultTextExists(string searchText)
		{
			Report.Info($"Attempting to confirm text: '{searchText}' search result exists.");
			return this.SearchResultList.Any(x => x.ResultText.Contains(searchText, StringComparison.InvariantCultureIgnoreCase));
		}

		public bool SearchComponentExists(string searchText)
		{
			Report.Info($"Attempting to confirm component name: '{searchText}' search result exists.");
			return this.SearchResultList.Any(x => x.ComponentName.Contains(searchText, StringComparison.InvariantCultureIgnoreCase));
		}

		public bool SearchCASNumberExists(string searchText)
		{
			Report.Info($"Attempting to confirm CAS number: '{searchText}' search result exists.");
			return this.SearchResultList.Any(x => x.CASNumber.Contains(searchText, StringComparison.InvariantCultureIgnoreCase));
		}

		public SearchBoxResult SearchResultTextGet(string searchText)
		{
			Report.Info($"Attempting to get text: '{searchText}' search result.");
			return this.SearchResultList.Where(x => x.ResultText.Equals(searchText, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
		}
		public SearchBoxResult SearchResultTextGetContains(string searchText)
		{
			Report.Info($"Attempting to get text: '{searchText}' search result.");
			return this.SearchResultList.Where(x => x.ResultText.Contains(searchText, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
		}
		public SearchBoxResult SearchComponentGet(string searchText)
		{
			Report.Info($"Attempting to get component name: '{searchText}' search result.");
			return this.SearchResultList.Where(x => x.ComponentName.Equals(searchText, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
		}

		public SearchBoxResult SearchCASNumberGet(string searchText)
		{
			Report.Info($"Attempting to get CAS number: '{searchText}' search result.");
			return this.SearchResultList.Where(x => x.CASNumber.Equals(searchText, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
		}

		public bool WaitForSearchResults(int waitTime = 30)
		{
			return this.SearchResultLoading.WaitForElementToBecomeStale(waitTime);
		}
		#endregion
	}
}
