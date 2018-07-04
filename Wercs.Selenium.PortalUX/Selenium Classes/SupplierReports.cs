using System;
using System.Collections.Generic;
using System.Linq;
using Mailosaur;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using ResourcePool;
using SafewareReporting;
using SeleniumUtilities;


namespace Wercs.Selenium.PortalUX.Selenium_Classes
{
	class SupplierReports : BaseObject
	{
		public const string BasePath = "//div[contains(@class, 'main-wrapper')]";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public bool SelectReport(string report)
		{
			return containerElement.FindElements(By.XPath(".//div[@id='reportList']//tr/td//span"))
				.FirstOrDefault(x => x.Text == report).FindElement(By.XPath("./../../a")).TryClick();
		}

		public string GetCurrentTitle()
		{
			return containerElement.FindElement(By.XPath(".//form[@id='panel']//h3")).Text;
		}

		public string GetCurrentSubText()
		{
			return containerElement.FindElement(By.XPath(".//form[@id='panel']//p")).Text;
		}

		public bool ClickDownload()
		{
			return containerElement.FindElement(By.XPath("//form[@id='panel']//button")).TryClick();
		}

		public List<string> GetReportList()
		{
			return containerElement.FindElements(By.XPath("//div[@id='reportList']//tr/td//span")).Select(x => x.Text.Trim())
				.ToList();
		}

		//eg 1459158
		public bool SelectKitThatContainsSpecificProduct(string searchTerm)
		{
			containerElement.FindElement(By.XPath(".//span[contains(@id, 'select2-autocomplete')]")).TryClick();
			Delay.Seconds(1);
			var Searches = SeleniumBrowser.WebBrowser.FindElements(By.XPath(".//input"));
			var Search = SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//input[@type='search']"));
			Search.EnterText(searchTerm);
			Delay.Seconds(1);
			var searching =
				containerElement.FindElement(By.XPath(".//li[contains(@class,'select2-results__message')]"), 2);
			int i = 0;
			while (searching != null && i < 10)
			{
				Delay.Seconds(Delay.SpeedFactor * 1);
				i++;
				searching = containerElement.FindElement(By.XPath(".//li[contains(@class,'select2-results__message')]"),
					2);
			}

			var Matches =
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

			var MatchingValues = Matches.Where(x =>x.GetValue().Trim().Contains(searchTerm.Trim()));
			
			if (MatchingValues.Count() == 0)
			{
				return false;
			}
			else
			{
				var MatchedEntry = MatchingValues.FirstOrDefault();
				return MatchedEntry.TryClick();
			}
		}

		public bool SelectRetailer(string retailer)
		{
			var selectionBox = containerElement.FindElement(By.XPath(".//select[@id='retailerProgram']"));
			selectionBox.Select(retailer);
			return selectionBox.SelectedOption() == retailer;
		}
	}
}
