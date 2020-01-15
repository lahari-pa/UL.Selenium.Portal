using System.Collections.Generic;
using System.Linq;
using UL.Automation.Selenium.BaseClasses;
using UL.Automation.Selenium.Classes;
using UL.Automation.Selenium.Extensions;
using UL.Automation.Reporting.Functions;
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

		public bool ClickFirstSupplier()
		{
			IWebElement firstSupplier = this.containerElement.FindElement(By.XPath(".//table[@id='listSupplierInfo']//tr[not(@class='jqgfirstrow')]"), 2);
			return firstSupplier.TryClick();
		}

		public bool ClickCategory(string category)
		{
			List<IWebElement> categories = this.containerElement.FindElements(By.XPath($".//li[contains(@class,'ui-state-default ui-corner-top')]"), 2).ToList();			
			
			IWebElement foundCategory = categories.First(x => x.Text == category);
			if(foundCategory==null)
			{
				Report.Info($"Did not find the category: {category}");
				return false;
			}
			Report.Info($"Found the category: {category}, attempting to click the category");
			return foundCategory.TryClick();
	
			
		}

		public IWebElement CategoryHeaders => this.containerElement.FindElement(By.XPath($".//ul[contains(@class,'ui-tabs-nav')]"), 2);

		public bool CheckCategoriesPresent()
		{
			IWebElement categoryHeaders = this.containerElement.WaitUntilElementVisible(By.XPath($"//div[@id='dialog-supplier-manager']//ul[contains(@class,'ui-tabs-nav')]"), 30);
			if(categoryHeaders==null)
			{
				return false;
			}
			return true;

		}

		public bool CategoryIsActive(string category)
		{
			List<IWebElement> categories = this.containerElement.FindElements(By.XPath($".//li[contains(@class,'ui-state-default ui-corner-top')]"), 2).ToList();
			IWebElement foundCategory = categories.First(x => x.Text == category);
			if(foundCategory.GetAttribute("class").Contains("active"))
			{
				return true;
			}
			return false;
		}


	}
}
