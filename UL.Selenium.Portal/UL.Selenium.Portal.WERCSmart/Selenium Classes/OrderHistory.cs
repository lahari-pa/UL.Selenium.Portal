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
	public class OrderHistoryPage : SeleniumBaseObject
	{

		#region Page Objects

		protected override By ContainerElementLocator => By.XPath("//div[@class='body-content']");
		
		IWebElement Table => this.ContainerElement.FindElement(By.XPath("//div[contains(@class,'ws-panel')]//table"), 2);

		IWebElement ActionButton(string name, string action) => this.FindElement(By.XPath($".//div[contains(@class,'ws-panel')]//table//tr//td//span[contains(@data-bind,'OrderNumber')][text()='{name}']//ancestor::tr//td//a[text()='{action}']"), 2);

		IWebElement InputText(string text) => this.ContainerElement.FindElement(By.XPath($"//input[contains(@placeholder,'{text}')]"), 2);
		IWebElement ViewDetails=> this.ContainerElement.FindElement(By.XPath("//div[@data-bind='with: Details']"), 2);

		private IWebElement FilterByDropdown => this.ContainerElement.FindElement(By.XPath($".//div[contains(@class,'ws')]//div[contains(@class,'pull-right')]//select[contains(@data-bind,'status')]"), 1);
		private List<IWebElement> FilterByDropdownOptionsList => this.FilterByDropdown.FindElements(By.XPath("//option"), 1).ToList();
		private IWebElement FilterByDropdownOption(string dropdownOption) => this.FilterByDropdownOptionsList.Where(x => x.Text.Trim() == dropdownOption).FirstOrDefault();



		#endregion

		#region Page Methods

		public bool TableExists()
		{
			Report.Info("Starting looking for Table");
			return this.Table != null;
		}

		public bool ClickAction(string name, string action)
		{

			return this.ActionButton(name, action).TryClick();

		}

		public void EnterText(string fieldname, string text)
		{
			this.InputText(fieldname).TryClick();
			this.InputText(fieldname).ClearTextBox();
			Report.Info("Enter the value for search");
			this.InputText(fieldname).EnterText(text);
		}

		public bool ViewDetailsIsDisplayed()
		{
			Report.Info("Starting looking for View Details");
			return this.ViewDetails != null;
		}



		public bool FilterByDropdownExists()
		{
			Report.Info($"Attempting to confirm FilterBy exists");
			return this.FilterByDropdown != null;
		}

		public bool FilterByDropdownClick()
		{
			Report.Info($"Attempting to click FilterBy dropdown");
			return this.FilterByDropdown.TryClick();
		}


		public bool FilterByDropdownOptionExists(string dropdownOption)
		{
			Report.Info($"Attempting to confirm FilterBy dropdown contains '{dropdownOption}' option.");
			return this.FilterByDropdownOption(dropdownOption) != null;
		}

		public bool FilterByDropdownOptionClick(string dropdownOption)
		{
			Report.Info($"Attempting to click FilterBy dropdown '{dropdownOption}' option.");
			return this.FilterByDropdownOption(dropdownOption).TryClick();
		}






		#endregion


	}



}
