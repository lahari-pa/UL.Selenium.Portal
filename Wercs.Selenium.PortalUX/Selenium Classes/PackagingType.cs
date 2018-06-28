using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using Castle.Components.DictionaryAdapter;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.PageObjects;
using ResourcePool;
using SafewareReporting;
using SeleniumUtilities;
using TechTalk.SpecFlow;

namespace Wercs.Selenium.PortalUX.Selenium_Classes
{
	class PackagingType : BaseObject
	{
		// NB same BasePath as NewProduct{} but cleaner to create a new Sel class, as we're not strictly creating a product here
		public const string BasePath = "//div[@id='dataentry']";
		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }
		public bool RefreshContainer()
		{
			containerElement = SeleniumBrowser.WebBrowser.FindElement(By.XPath(BasePath), 2);
			return containerElement != null;
		}
		public bool WaitForSection(string sectionHeader, int secondsToWait = 60)
		{
			int counter = 0;
			while (counter < secondsToWait)
			{
				RefreshContainer();
				var addProductHeader = containerElement.FindElements(By.XPath(".//div[@class='panel-heading']//h3"))
					.FirstOrDefault(x => x.Text.Contains(sectionHeader));
				if (addProductHeader != null)
				{
					return true;
				}
				Delay.Seconds(1);
				counter++;
			}
			return false;
		}
		public bool ClickAddRow()
		{
			return containerElement.FindElement(By.XPath(".//button[@data-bind='click: addRow']"), 2).TryClick();
		}

		public bool SelectOptionForField(string option, string field)
		{
			var columnNumber = containerElement.FindElements(By.XPath(".//thead//th")).ToList().FindIndex(x => x.Text == field) + 1;
			if (columnNumber < 1)
			{
				Report.Failure("Couldn't find column: " + field);
				return false;
			}
			var xPath = ".//tbody//td[" + columnNumber + "]/child::*";
			var el = containerElement.FindElement(By.XPath(xPath), 2);
			if (el.TagName == "select")
			{
				el.Select(option);
				return el.SelectedOption() == option;
			}
			if (el.TagName == "input")
			{
				el.EnterText(option);
				Delay.Seconds(1);
				return el.Text == option;
			}
			Report.Failure("Could not find element of select type or input type in the table.");
			return false;
		}
		public bool SavePackagingDetails(string savedAs)
		{
			var header = containerElement.FindElement(By.XPath(".//h2"), 2);
			if (header == null)
			{
				Report.Failure("Could not locate header element contianing Packaging Type Name (ID)");
				return false;
			}
			var headerText = header.Text;
			var ID = headerText.Split('(').Last().Replace(")", "");
			var name = headerText.Replace("(" + ID + ")", "").Trim();
			Context.AddToContext("PackagingTypeID_" + savedAs, ID);
			Context.AddToContext("PackagingTypeName_" + savedAs, name);
			return true;
		}
	}
}
