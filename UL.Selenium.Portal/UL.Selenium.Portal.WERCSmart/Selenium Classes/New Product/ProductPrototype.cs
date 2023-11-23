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
using UL.Automation.SpecFlow.Classes;
using System.Collections.ObjectModel;
using UL.Selenium.Portal.WERCSmart.Classes;
using TechTalk.SpecFlow;
using TReVor.Api.Wrapper.Classes;
using UL.Automation.Reporting;
using UL.Automation.WebDriver.Functions;
using UL.Automation.TReVor.Classes;
using UL.Selenium.Portal.WERCSmart.Steps.New_Product;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Chrome;

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
		protected override By ContainerElementLocator => By.XPath($"//div[contains(@class,'form-group')][.//label[@class='control-label'][text()='{_label}']]");
		private IWebElement Option(string optionLabel) => this.FindElement(By.XPath($".//div[@class='radio' or @class='checkbox'][.//*[text()='{optionLabel}']]//input[@type='radio' or @type='checkbox']"), 1);
		#endregion

		#region Methods
		public ProductPrototype(string label)
		{
			Report.Info($"Attempting to get {label} group.");;
			_label = label;
		}
		#region Option Input Methods
		public bool OptionExists(string optionLabel)
		{
			Report.Info($"Attempting to confirm {optionLabel} option exists.");
			return this.Option(optionLabel) != null;
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

		#region Error Message Methods
		private IWebElement ErrorMessageGet(string errorMessage)
		{
			Report.Info($"Attempting to get '{errorMessage}' error message.");
			return this.ContainerElement.FindElement(By.XPath($".//*[@class='form-error'][.//*[contains(text(),'{errorMessage}')]]"), 1);
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
	public class SearchBoxPrototype:SeleniumBaseObject
	{
		#region Page Objects
		protected override By ContainerElementLocator => By.XPath($"//span[contains(@class,'select2-container--open')][.//input[@type='search']]");
		private IWebElement SearchInput => this.FindElement(By.XPath(".//input[@type='search']"),1);
		public List<IWebElement> SearchResultsList => this.FindElements(By.XPath(".//li[contains(@class,'select2-results')][@data-select2-id]"), 1).ToList();
		private IWebElement SearchResult(string searchText) => this.SearchResultsList.Where(x => x.Text.ToLower().Contains(searchText.ToLower())).FirstOrDefault();
		private IWebElement SearchResultAlert(string alertText) => this.FindElement(By.XPath($".//li[@role='alert'][@text()='{alertText}']"), 1);
		private IWebElement SearchResultHighlighted => this.SearchResultsList.Where(x => x.GetAttribute("class").Contains("-highlighted")).FirstOrDefault();

		#endregion

		#region Methods
		public bool SearchInputExists()
		{
			Report.Info($"Attempting to confirm search input box exists.");
			return this.SearchInput != null;
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
			return !this.SearchResultsList.IsNullOrEmpty();
		}

		public bool SearchResultExists(string searchText)
		{
			Report.Info($"Attempting to confirm '{searchText}' search result exists.");
			return this.SearchResult(searchText) != null;
		}

		public bool SearchResultClick(string searchText)
		{
			Report.Info($"Attempting to click '{searchText}' search result.");
			return this.SearchResult(searchText).TryClick();
		}

		public bool SearchResultHighlightedExists()
		{
			Report.Info($"Attempting to confirm highlighted search result exists.");
			return this.SearchResultHighlighted != null;
		}
		#endregion
	}
}
