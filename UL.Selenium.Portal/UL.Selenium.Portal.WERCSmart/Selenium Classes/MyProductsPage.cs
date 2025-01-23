using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UL.Automation.Reporting.Functions;
using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Extensions;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	internal class MyProductsPage : SeleniumBaseObject
	{
		#region Page Objects
		protected override By ContainerElementLocator => By.XPath("//div[@id='products-grid'][.//*[@class='ws-panel-title'][text()='My Products']]");
		private IWebElement PageInfoIcon => this.FindElement(By.XPath("//i[contains(@class,'fa-question-circle')]"), 1);
		private List<IWebElement> StatusFilterList => this.FindElements(By.XPath("//ul[contains(@class, 'status-filters')]//a"), 1).ToList();
		private IWebElement StatusFilter(string statusFilterLabel) => this.StatusFilterList.Where(x => string.Equals(x.Text, statusFilterLabel)).FirstOrDefault();
		private IWebElement LabeledButton(string buttonLabel) => this.FindElement(By.XPath($"//a[normalize-space()='{buttonLabel}']"), 1);
		private IWebElement MoreFiltersPanel => this.FindElement(By.Id("more-filters-panel"), 1);
		private IWebElement Checkbox(string checkboxLabel) => this.FindElement(By.XPath($".//label[normalize-space() = '{checkboxLabel}']//input[@type='checkbox']"), 1);
		private IWebElement LabeledDropdown(string dropdownLabel) => this.FindElement(By.XPath($"//div[contains(@class,'form-group')][.//label[@class='control-label'][normalize-space()='{dropdownLabel}']]//select"), 1);
		private List<IWebElement> LabeledDropdownOptionsList(string dropdownLabel) => this.LabeledDropdown(dropdownLabel).FindElements(By.XPath("//option"), 1).ToList();
		private IWebElement LabeledDropdownOption(string dropdownLabel, string dropdownOption) => this.LabeledDropdownOptionsList(dropdownLabel).Where(x=>x.Text.Trim() == dropdownOption).FirstOrDefault();
		#endregion

		#region Methods
		#region Page Info Icon Methods
		public bool PageInfoIconExists()
		{
			Report.Info($"Attempting to confirm page info icon exists.");
			return this.PageInfoIcon != null;
		}

		public bool PageInfoIconTextDisplayed()
		{
			Report.Info($"Attempting to confirm page info icon text is displayed.");
			return this.PageInfoIcon.GetAttribute("aria-describedby") != null;
		}
		#endregion

		#region Status Filter List Methods
		public List<string> StatusFilterListGet()
		{
			Report.Info($"Attempting to get the list of status filters.");
			List<string> output = new List<string>();
			this.StatusFilterList.ForEach(x=> output.Add(x.Text));
			return output;
		}
		public bool StatusFilterExists(string statusFilterLabel)
		{
			Report.Info($"Attempting to confirm '{statusFilterLabel}' status filter exists.");
			return this.StatusFilter(statusFilterLabel) != null;
		}

		public bool StatusFilterClick(string statusFilterLabel)
		{
			Report.Info($"Attempting to click '{statusFilterLabel}' status filter.");
			return this.StatusFilter(statusFilterLabel).TryClick();
		}

		public bool StatusFilterActive(string statusFilterLabel)
		{
			Report.Info($"Attempting to confirm '{statusFilterLabel}' status filter is active.");
			return this.StatusFilter(statusFilterLabel).GetAttribute("class").Contains("active");
		}
		#endregion

		#region Labeled Button Methods
		public bool LabeledButtonExists(string buttonLabel)
		{
			Report.Info($"Attempting to confirm '{buttonLabel}' button exits.");
			return this.LabeledButton(buttonLabel) != null;
		}

		public bool LabeledButtonClick(string buttonLabel)
		{
			Report.Info($"Attempting to click '{buttonLabel}' button.");
			return this.LabeledButton(buttonLabel).TryClick();
		}
		#endregion

		#region More Filters Panel Methods
		public bool MoreFiltersPanelExists()
		{
			Report.Info($"Attempting to confirm more filters panel exists.");
			return this.MoreFiltersPanel != null;
		}

		public bool MoreFiltersPanelExpanded()
		{
			Report.Info($"Attempting to confirm more filters panel is expanded.");
			return this.MoreFiltersPanel.GetAttribute("@aria-expanded") == "true";
		}
		#endregion

		#region Checkbox Methods
		public bool CheckboxExists(string checkboxLabel)
		{
			Report.Info($"Attempting to confirm '{checkboxLabel}' checkbox exists.");
			return this.Checkbox(checkboxLabel) != null;
		}

		public bool CheckboxClick(string checkboxLabel)
		{
			Report.Info($"Attempting to click '{checkboxLabel}' checkbox.");
			return this.Checkbox(checkboxLabel).TryClick();
		}

		public bool CheckboxChecked(string checkboxLabel)
		{
			Report.Info($"Attempting to confirm '{checkboxLabel}' checkbox is checked.");
			return this.Checkbox(checkboxLabel).Checked();		}
		#endregion

		#region Labeled Dropdown Methods
		public bool LabeledDropdownExists(string dropdownLabel)
		{
			Report.Info($"Attempting to confirm '{dropdownLabel}' labeled dropdown exists.");
			return this.LabeledDropdown(dropdownLabel) != null;
		}

		public bool LabeledDropdownClick(string dropdownLabel)
		{
			Report.Info($"Attempting to click '{dropdownLabel}' labeled dropdown.");
			return this.LabeledDropdown(dropdownLabel).TryClick();
		}

		public string LabeledDropdownValue(string dropdownLabel)
		{
			Report.Info($"Attempting to get '{dropdownLabel}' labeled dropdown value.");
			return this.LabeledDropdown(dropdownLabel).GetValue();
		}

		public List<string> LabeledDropdownOptionsListGet(string dropdownLabel)
		{
			Report.Info($"Attempting to get '{dropdownLabel}' labeled dropdown options list.");
			List<string> output = new List<string>();
			this.LabeledDropdownOptionsList(dropdownLabel).ForEach(x => output.Add(x.Text));
			return output;
		}

		public bool LabeledDropdownOptionExists(string dropdownLabel, string dropdownOption)
		{
			Report.Info($"Attempting to confirm '{dropdownLabel}' labeled dropdown contains '{dropdownOption}' option.");
			return this.LabeledDropdownOption(dropdownLabel, dropdownOption) != null;
		}

		public bool LabeledDropdownOptionClick(string dropdownLabel, string dropdownOption)
		{
			Report.Info($"Attempting to click '{dropdownLabel}' labeled dropdown '{dropdownOption}' option.");
			return this.LabeledDropdownOption(dropdownLabel, dropdownOption).TryClick();
		}
		#endregion
		#endregion
	}

	internal class TextSearch : SeleniumBaseObject
	{
		#region Class Objects
		private string _placeholderText;
		protected override By ContainerElementLocator => By.XPath($"//div[@class='search-group'][.//input[@type='text'][@placeholder='{_placeholderText}']]");
		private IWebElement TextInput => this.FindElement(By.XPath(".//input[@type='text']"), 1);
		private IWebElement SearchButton => this.FindElement(By.XPath(".//span[contains(@data-bind,'click')]"), 1);
		#endregion

		#region Class Methods
		public TextSearch(string placeholderText)
		{
			_placeholderText = placeholderText;
		}

		public bool TextInputExists()
		{
			Report.Info($"Attempting to confirm text search text input exists.");
			return this.TextInput != null;
		}

		public bool TextInputClick()
		{
			Report.Info($"Attempting to click text search text input.");
			return this.TextInput.TryClick();
		}

		public bool TextInputEnterText(string inputText)
		{
			Report.Info($"Attempting to enter '{inputText}' into text search text input.");
			return this.TextInput.TryEnterText(inputText);
		}

		public string TextInputTextGet()
		{
			Report.Info($"Attempting to get text search text.");
			return this.TextInput.GetValue();
		}

		public bool SearchButtonExists()
		{
			Report.Info($"Attempting to confirm text search search button exists.");
			return this.SearchButton != null;
		}

		public bool SearchButtonClick()
		{
			Report.Info($"Attempting to click text search search button.");
			return this.SearchButton.TryClick();
		}
		#endregion
	}
}
