using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using Castle.Components.DictionaryAdapter;
using NTTQA_Automation_Classes.Base_Classes;
using NTTQA_Automation_Classes.Classes;
using NTTQA_Automation_Classes.Extension_Methods;
using NTTQA_Reporting_Module.Reporting.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumUtilities;

namespace Wercs.Selenium.PortalUX.Selenium_Classes
{
	class PackagingType : BaseObject
	{
		// NB same BasePath as NewProduct{} but cleaner to create a new Sel class, as we're not strictly creating a product here
		public const string BasePath = "//div[@id='dataentry']";
		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public IWebElement AddRow()
		{
			return this.containerElement.FindElement(By.XPath(".//button[@data-bind='click: addRow']"), 2);
		}
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
			return this.AddRow().TryClick();
		}

		public bool AddRowDisplayed()
		{
			var el = this.AddRow();
			return el != null && el.Displayed;
		}

		public List<string> TableHeadings()
		{
			return this.containerElement.FindElements(By.XPath(".//thead//th"), 2).Select(x => x.Text).ToList();
		}

		public bool SelectOptionForField(string option, string field)
		{
			var columnIndex = containerElement.FindElements(By.XPath(".//thead//th")).ToList().FindIndex(x => x.Text == field) + 1;
			if (columnIndex < 1)
			{
				Report.Failure("Couldn't find column: " + field);
				return false;
			}
			var xPath = ".//tbody//td[" + columnIndex + "]/child::*";
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
				return el.GetAttribute("value") == option;
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
