using Microsoft.Identity.Client;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UL.Automation.Reporting.Functions;
using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Extensions;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	class InternalInformationRevisions : SeleniumBaseObject
	{
		#region Page Objects
		protected override By ContainerElementLocator => By.XPath("//div[@id='internalInfoRevisionsGrid']");
		IWebElement SearchButton(string label) => this.ContainerElement.FindElement(By.XPath($".//div[label[contains(text(), '{label}')]]//i[@class= 'fa fa-search']"));
		IWebElement SearchInput(string label) => this.ContainerElement.FindElement(By.XPath($".//div[label[contains(text(), '{label}')]]//input"));
		IWebElement SearchBrandSelect => this.ContainerElement.FindElement(By.XPath($".//div[label[contains(text(), 'Brand')]]//select"));


		#endregion

		#region Methods
		public bool SearchButtonExists(string label)
		{
			Report.Info($"Attempting to find search button for '{label}'");
			return this.SearchButton(label) != null;
		}
		public bool SearchButtonClick(string label)
		{
			Report.Info($"Attempting to click search button for '{label}'");
			return this.SearchButton(label).TryClick();
		}
		public bool SearchInputExists(string label)
		{
			Report.Info($"Attempting to find search input for '{label}'");
			return this.SearchInput(label) != null;
		}
		public bool SearchInputEnterText(string label, string text)
		{
			Report.Info($"Attempting to enter text for '{label}'");
			return this.SearchInput(label).TryEnterText(text);
		}
		public bool SearchBrandSelectExists()
		{
			Report.Info($"Attempting to find select dropdown for 'Brand'");
			return this.SearchBrandSelect != null;
		}
		public bool SearchBrandSelectOption(string option)
		{
			Report.Info($"Attempting to select option for 'Brand'");
			this.SearchBrandSelect.Select(option);
			return this.SearchBrandSelect.SelectedOption() == option;
		}

		#endregion

	}
}
