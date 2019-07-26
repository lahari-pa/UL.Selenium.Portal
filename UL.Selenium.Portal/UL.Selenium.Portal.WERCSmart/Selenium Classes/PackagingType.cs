using System.Collections.Generic;
using System.Linq;
using NTTQA.Selenium.BaseClasses;
using NTTQA.Selenium.Classes;
using NTTQA.Selenium.ExtensionMethods;
using NTTQA.Selenium.Reporting.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using NTTQA.Selenium.SpecFlow;
using NTTQA.Selenium.UniversalFunctions;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
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
			this.containerElement = SeleniumBrowser.WebBrowser.FindElement(By.XPath(BasePath), 2);
			return this.containerElement != null;
		}

		public bool WaitForSection(string sectionHeader, int secondsToWait = 60)
		{
			int counter = 0;
			while (counter < secondsToWait)
			{
				this.RefreshContainer();
				IWebElement addProductHeader = this.containerElement.FindElements(By.XPath(".//div[@class='panel-heading']//h3"))
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
			IWebElement el = this.AddRow();
			return el != null && el.Displayed;
		}

		public List<string> TableHeadings()
		{
			return this.containerElement.FindElements(By.XPath(".//thead//th"), 2).Select(x => x.Text).ToList();
		}

		public bool SelectOptionForField(string option, string field)
		{
			int columnIndex = this.containerElement.FindElements(By.XPath(".//thead//th")).ToList().FindIndex(x => x.Text == field) + 1;
			if (columnIndex < 1)
			{
				Report.Failure("Couldn't find column: " + field);
				return false;
			}
			string xPath = ".//tbody//td[" + columnIndex + "]/child::*";
			IWebElement el = this.containerElement.FindElement(By.XPath(xPath), 2);
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
			IWebElement header = this.containerElement.FindElement(By.XPath(".//h2"), 2);
			if (header == null)
			{
				Report.Failure("Could not locate header element contianing Packaging Type Name (ID)");
				return false;
			}
			string headerText = header.Text;
			string ID = headerText.Split('(').Last().Replace(")", "");
			string name = headerText.Replace("(" + ID + ")", "").Trim();
			Context.AddToContext("PackagingTypeID_" + savedAs, ID);
			Context.AddToContext("PackagingTypeName_" + savedAs, name);
			return true;
		}

		public bool UploadFileForSection(string section, string pdfFilePath)
		{
			return new NewProduct().UploadFileForSection(section, pdfFilePath);
		}

	}
}
