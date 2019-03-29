using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NTTQA_Automation_Classes.Base_Classes;
using NTTQA_Automation_Classes.Classes;
using NTTQA_Automation_Classes.Extension_Methods;
using NTTQA_Reporting_Module.Reporting.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;


namespace Wercs.Selenium.PortalUX.Selenium_Classes
{
	class StudioSupplierManager : BaseObject
	{
		public const string BasePath = "//div[@id='dialog-supplier-manager']";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }


		public bool EnterSearchTerm(string searchTerm)
		{
			var searchInput = containerElement.FindElement(By.XPath(".//input[@id='textSupplierSearch']"), 2);
			if (searchInput == null)
			{
				Report.Info("No search input has been found");
				return false;
			}

			return searchInput.TryEnterText(searchTerm);
		}

		public bool ClickSearchButton()
		{
			var searchButton = containerElement.FindElement(By.XPath(".//button[@id='supplierSearchButton']"), 2);
			if (searchButton == null)
			{
				Report.Info("No search input has been found");
				return false;
			}

			return searchButton.TryClick();

		}

		public bool SelectSupplierSearchTypeRadio(string radio)
		{
			var searchRadios = containerElement.FindElements(By.XPath(".//input[@type='radio']"));
			var matchingRadio =
				searchRadios.FirstOrDefault(x => x.GetValue().Trim().ToLower().Replace("-", "").Contains(radio));
			if (matchingRadio == null)
			{
				Report.Info("No matching radio has been found");
				return false;
			}

			return matchingRadio.TryClick();
		}

		public List<string> GetSupplierIDs()
		{
			List<string> suppliers = new List<string>();
			var searchTable = containerElement.FindElement(By.XPath(".//table[@id='listSupplierInfo']"), 5);
			if (searchTable == null)
			{
				Report.Info("No supplier table has been found");
				return suppliers;
			}

			var rows = searchTable.FindElements(By.XPath(".//tr[not(contains(@class, 'firstrow'))]"));

			suppliers = rows.Select(x => x.GetAttribute("id")).ToList();

			return suppliers;

		}

		public bool ClickClose()
		{
			var closeButton = containerElement.FindElement(By.XPath(".//span[contains(@class, 'close')]"),2);
			if (closeButton == null)
			{
				Report.Info("Could not find close button");
				return false;
			}

			return closeButton.TryClick();
		}

	}
}
