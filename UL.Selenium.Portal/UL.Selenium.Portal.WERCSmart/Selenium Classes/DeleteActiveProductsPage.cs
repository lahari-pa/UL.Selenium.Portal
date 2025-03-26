using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using UL.Automation.Reporting.Functions;
using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Classes;
using UL.Automation.WebDriver.Extensions;
using UL.Automation.WebDriver.Functions;



namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	public class DeleteActiveOrdersPage : SeleniumBaseObject
	{

		#region Page Objects

		protected override By ContainerElementLocator => By.XPath("//div[@class='body-content']");
		IWebElement InputText(string text) => this.ContainerElement.FindElement(By.XPath($"//input[contains(@placeholder,'{text}')]"), 2);


		#endregion

		#region Page Methods

		public void EnterText(string fieldname, string text)
		{
			this.InputText(fieldname).TryClick();
			this.InputText(fieldname).ClearTextBox();
			Report.Info("Enter the value for search");
			this.InputText(fieldname).EnterText(text);
		}

		public bool ClickStatusFilter(string option)
		{
			IList<IWebElement> allFilters = this.ContainerElement.FindElements(By.XPath(".//ul[contains(@class,'status-filters')]//a"), 2);
			IWebElement requiredFilter = allFilters.FirstOrDefault(x => x.Text.Contains(option));
			return requiredFilter.TryClick() && GeneralUtilities.Wait_for_load_finish();
		}


		#endregion


	}



}
