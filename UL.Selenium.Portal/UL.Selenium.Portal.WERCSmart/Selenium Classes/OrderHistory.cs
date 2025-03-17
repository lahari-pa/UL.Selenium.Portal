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





		#endregion


	}



}
