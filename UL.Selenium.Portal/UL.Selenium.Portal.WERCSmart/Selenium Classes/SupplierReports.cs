using System.Collections.Generic;
using System.Linq;
using NTTQA.Selenium.BaseClasses;
using NTTQA.Selenium.Classes;
using NTTQA.Selenium.ExtensionMethods;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.ObjectModel;
using NTTQA.Selenium.Reporting.Core;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	class SupplierReports : BaseObject
	{
		public const string BasePath = "//div[contains(@class, 'main-wrapper')]";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public bool SelectReport(string report)
		{
			return this.containerElement.FindElements(By.XPath(".//div[@id='reportList']//tr/td//span"))
				.FirstOrDefault(x => x.Text == report).FindElement(By.XPath("./../../a")).TryClick();
		}

		// This gets the title of the right side frame on the page
		public string GetCurrentSubTitle()
		{
			string thing = this.containerElement.FindElement(By.XPath(".//div[@id='rptname']//h3"))?.Text;
			return thing;
		}


		// This gets the left (main) title of the page
		public string GetCurrentTitle()
		{
			return this.containerElement.FindElement(By.XPath("..//h2"))?.Text;
		}

		public string GetCurrentSubText()
		{
			return this.containerElement.FindElement(By.XPath(".//form[@id='panel']//p"))?.Text;
		}

		public bool ClickDownload()
		{
			return this.containerElement.FindElement(By.XPath("//form[@id='panel']//button")).TryClick();
		}

		public List<string> GetReportList()
		{
			return this.containerElement.FindElements(By.XPath("//div[@id='reportList']//tr/td//span")).Select(x => x.Text.Trim())
				.ToList();
		}

		//eg 1459158
		public bool SelectSpecificProduct(string searchTerm)
		{
			this.containerElement.FindElement(By.XPath(".//span[contains(@id, 'select2-autocomplete')]")).TryClick();
			Delay.Seconds(1);
			ReadOnlyCollection<IWebElement> Searches = SeleniumBrowser.WebBrowser.FindElements(By.XPath(".//input"));
			IWebElement Search = SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//input[@type='search']"));
			Search.EnterText(searchTerm);
			Delay.Seconds(1);
			IWebElement searching =
				this.containerElement.FindElement(By.XPath(".//li[contains(@class,'select2-results__message')]"), 2);
			int i = 0;
			while (searching != null && i < 10)
			{
				Delay.Seconds(Delay.SpeedFactor * 1);
				i++;
				searching = this.containerElement.FindElement(By.XPath(".//li[contains(@class,'select2-results__message')]"),
					2);
			}

			IList<IWebElement> Matches =
			SeleniumBrowser.WebBrowser.FindElements(By.XPath(".//li[contains(@class,'select2-results__option')]"), 2);

			/*
			while (Matches.FirstOrDefault().FindElement(By.XPath(".//span[@class='text-muted']"), 2) == null)
			{
				Delay.Seconds(Delay.SpeedFactor * 1);
				Matches = containerElement.FindElements(By.XPath(".//li[contains(@class,'select2-results__option')]"),
					2);
			}
			*/

			if (Matches.Count == 0)
			{
				return false;
			}

			IEnumerable<IWebElement> MatchingValues = Matches.Where(x => x.GetValue().Trim().Contains(searchTerm.Trim()));

			if (MatchingValues.Count() == 0)
			{
				return false;
			}
			else
			{
				IWebElement MatchedEntry = MatchingValues.FirstOrDefault();
				return MatchedEntry.TryClick();
			}
		}

		public bool SelectRandomProduct()
		{
			bool found = false;
			int count = 1;
			while (!found && count < 10)
			{
				Report.Info("Entering text: " + count + " into the search input");
				if (this.SelectSpecificProduct(count.ToString()))
				{
					found = true;
					return true;
				}
				count++;
			}
			Report.Info("Failed to enter text into the search input");
			return false;
		}

		public bool SelectRetailer(string retailer)
		{
			IWebElement selectionBox = this.containerElement.FindElement(By.XPath(".//select[@id='retailerProgram']"));
			selectionBox.Select(retailer);
			return selectionBox.SelectedOption() == retailer;
		}
	}
}
