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

		public string OrderActivePage()
		{
			IWebElement userGrid = this.ContainerElement.FindElement(By.XPath(".//div[@class='panel-footer clearfix']"), 2);
			if (userGrid == null)
			{
				return null;
			}
			IWebElement pageEl = userGrid.FindElement(By.XPath(".//li[@class='active']/span"), 2);
			if (pageEl == null)
			{
				return null;
			}
			pageEl.ScrollElementIntoView();
			return userGrid.FindElement(By.XPath(".//li[@class='active']/span"), 2).Text;
		}

		public bool OrderGridNavigation(string navOption)
		{
			bool success = false;
			int i = 0;
			while (success == false && i < 5)
			{
				Report.Info("Navigating in the order grid with action - " + navOption);
				IWebElement userGrid = this.ContainerElement.FindElement(By.XPath(".//div[@class='panel-footer clearfix']"), 2);
				if (userGrid == null)
				{
					Report.Info("Could not locate the order grid");
					return false;
				}
				IWebElement navEl = null;
				switch (navOption)
				{
					case "next":
						navEl = userGrid.FindElement(By.XPath(".//a[@class='page-link next']|//a[text()='Next']"), 2);
						break;
					case "previous":
						navEl = userGrid.FindElement(By.XPath(".//a[@class='page-link prev']|//a[text()='Prev']"), 2);
						break;
					case "...":
						navEl = userGrid.FindElement(By.XPath(".//span[@class='ellipse clickable' and parent::li]|//span[text()='...' and parent::li]"), 2);
						break;
					default:
						Report.Info("An invalid navigation option was provided. Must either be 'next' or 'previous'");
						return false;
				}
				if (navEl == null)
				{
					Report.Info("Could not locate the navigation button element");
					return false;
				}
				navEl.ScrollElementIntoView();
				if (navEl.TryClick())
				{
					Report.Info("Successfully clicked the found element");
					success = true;
				}
				else
				{
					Report.Info($"Failed to click the element on try: {i + 1}");
					i++;
				}
			}
			return success;



		}



		#endregion


	}



}
