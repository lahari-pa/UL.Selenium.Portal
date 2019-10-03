using System.Collections.Generic;
using System.Linq;
using NTTQA.Selenium.BaseClasses;
using NTTQA.Selenium.Classes;
using NTTQA.Selenium.ExtensionMethods;
using NTTQA.Selenium.Reporting.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.ObjectModel;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	class StudioSupplierManager : BaseObject
	{
		public const string BasePath = "//div[@id='dialog-supplier-manager']";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }


		public bool EnterSearchTerm(string searchTerm)
		{
			IWebElement searchInput = this.containerElement.FindElement(By.XPath(".//input[@id='textSupplierSearch']"), 2);
			if (searchInput == null)
			{
				Report.Info("No search input has been found");
				return false;
			}

			return searchInput.TryEnterText(searchTerm);
		}

		public bool ClickSearchButton()
		{
			IWebElement searchButton = this.containerElement.FindElement(By.XPath(".//button[@id='supplierSearchButton']"), 2);
			if (searchButton == null)
			{
				Report.Info("No search input has been found");
				return false;
			}

			if (searchButton.TryClick())
			{
				Delay.Seconds(5);
				return true;
			}

			return false;

		}

		public bool SelectSupplierSearchTypeRadio(string radio)
		{
			IWebElement matchingRadio = this.containerElement.FindElement(By.XPath(".//input[@type='radio'][following-sibling::text()[position()=1][contains(., '" + radio + "')]]"), 2);
			if (matchingRadio == null)
			{
				Report.Info("No matching radio has been found");
				return false;
			}

			return matchingRadio.TryCheck();
		}

		public List<string> GetSupplierIDs()
		{
			var suppliers = new List<string>();
			IWebElement searchTable = this.containerElement.FindElement(By.XPath(".//table[@id='listSupplierInfo']"), 5);
			if (searchTable == null)
			{
				Report.Info("No supplier table has been found");
				return suppliers;
			}

			ReadOnlyCollection<IWebElement> rows = searchTable.FindElements(By.XPath(".//tr[not(contains(@class, 'firstrow'))]"));

			suppliers = rows.Select(x => x.GetAttribute("id")).ToList();

			return suppliers;

		}

		public List<string> GetSupplierNames()
		{
			var suppliers = new List<string>();
			IWebElement searchTable = this.containerElement.FindElement(By.XPath(".//table[@id='listSupplierInfo']"), 5);
			if (searchTable == null)
			{
				Report.Info("No supplier table has been found");
				return suppliers;
			}

			ReadOnlyCollection<IWebElement> rows = searchTable.FindElements(By.XPath(".//tr[not(contains(@class, 'firstrow'))]//td[2]"));

			suppliers = rows.Select(x => x.GetAttribute("title")).ToList();

			return suppliers;

		}

		public bool ClickClose()
		{
			IWebElement closeButton = this.containerElement.FindElement(By.XPath("..//span[contains(@class, 'close')]"), 2);
			if (closeButton == null)
			{
				Report.Info("Could not find close button");
				return false;
			}

			return closeButton.TryClick();
		}

	}
}
