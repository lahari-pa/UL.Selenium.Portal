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


namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	public class AlertsPage : SeleniumBaseObject
	{

		#region Page Objects

		protected override By ContainerElementLocator => By.XPath("//div[@class='panel-body']");
		IWebElement WpsId => this.ContainerElement.FindElement(By.XPath("//input[contains(@data-bind,'wpsId')]"), 2);
		IWebElement NotificationDate => this.ContainerElement.FindElement(By.XPath("//input[contains(@data-bind,'date.field')]"), 2);
		IWebElement ProductName => this.ContainerElement.FindElement(By.XPath("//input[contains(@data-bind,'productName.field')]"), 2);

		#endregion

		#region Page Methods

		public bool WpsIdFieldExists()
		{
			Report.Info("Starting looking for Wps Id field");
			return this.WpsId != null;
		}

		public void WpsIdText(string wpsId)
		{
			this.WpsId.EnterText(wpsId);
		}

		public bool NotificationDateFieldExists()
		{
			Report.Info("Starting looking for NotificationDate field");
			return this.NotificationDate != null;
		}

		public void NotificationDateText(string date)
		{
			this.NotificationDate.EnterText(date);
		}


		public bool ProductNameFieldExists()
		{
			Report.Info("Starting looking for ProductName field");
			return this.ProductName != null;
		}

		public void ProductNameText(string productname)
		{
			this.ProductName.EnterText(productname);
		}


		#endregion



	}


}
