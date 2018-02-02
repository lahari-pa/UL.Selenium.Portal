using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumUtilities;

namespace Wercs.Selenium.PortalUX.Selenium_Classes
{
    class RetailPartners : BaseObject
    {
        public const string BasePath = "//div[@id='retailPartners']";
        [FindsBy(How = How.XPath, Using = BasePath)]
        protected override IWebElement containerElement { get; set; }

        public string HeaderShowing()
        {
            return this.containerElement.FindElement(By.XPath("..//h2"), 2).Text;
        }

        public List<string> SubHeadingsShowing()
        {
            return this.containerElement.FindElements(By.XPath(".//h3"), 2).Select(x => x.Text.Trim()).ToList();
        }

	    public bool ClickRetailer(string retailer, bool exact = false)
	    {
		    // Finds all the most recent retail partners
		    var recentPartners = this.containerElement.FindElements(By.XPath(".//div[@class='most-recent']//span[@class='sr-only']"), 2);

		    if (recentPartners.Any(x => x.Text.Contains(retailer)))
		    {
				// Retailer was found in the most recent retailer portion of the screen!
			    recentPartners.FirstOrDefault(x => x.Text.Contains(retailer)).FindElement(By.XPath("../.."),2).Click();
			    return true;
		    }

			// Retailer not found in the most recent retailers portion, so checking the rest of the retailers
		    var allPartners = this.containerElement.FindElements(By.XPath(".//div[@class='all-retailers']//span[@class='sr-only']"), 2);

		    if (allPartners.Any(x => x.Text.Contains(retailer)))
		    {
				// Retailer was found in the most recent retailer portion of the screen!
			    allPartners.FirstOrDefault(x => x.Text.Contains(retailer)).FindElement(By.XPath("../.."), 2).Click();
			    return true;
		    }

			// Retailer not found!

		    return false;
	    }
    }

	class RetailParntersDetails : BaseObject
	{
		public const string BasePath = "//div[@id='retailDetails']";
		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public bool HeaderShowing(string header, bool exact = true)
		{
			var headers = this.containerElement.FindElements(By.XPath(".//h3"), 2);
			return headers.Any(x => x.Text.Contains(header));
		}

		public string GetChartLegend()
		{
			return this.containerElement.FindElement(By.XPath(".//div[@class='chart-legend']"), 2).Text;
		}

		public string GetTierInformation()
		{
			return this.containerElement.FindElement(By.XPath(".//div[contains(@data-bind,'tiersControl.tierInformation')]"), 2).Text;
		}

		public void ClickMoreInformation()
		{
			this.containerElement.FindElement(By.XPath(".//a[contains(@data-bind,'tiersControl.tierMoreInformation')]"), 2).Click();
		}

		public bool MoreInformationShowing()
		{
			var el = this.containerElement.FindElement(By.XPath(".//a[contains(@data-bind,'tiersControl.tierMoreInformation')]"), 2);
			return el != null && el.Displayed;
		}

		public void ClickProductsInScope()
		{
			this.containerElement.FindElement(By.XPath(".//a[contains(@data-bind,'tiersControl.getReport')]"), 2).Click();
		}

		public bool SetDataConsentTier(string tier, bool trueFalse)
		{
			var dataConsentRows = this.containerElement.FindElements(By.XPath(".//div[contains(@class,'data-consent')]//table//tbody//tr"), 2);
			var correctRow = dataConsentRows.FirstOrDefault(x => x.FindElement(By.XPath(".//td[1]"), 2).Text.StartsWith(tier));
			if (correctRow != null)
			{
				var checkbox = correctRow.FindElement(By.XPath(".//input[@type='checkbox']"), 2);
				var Checked = checkbox.Selected;
				if (Checked != trueFalse)
					correctRow.FindElement(By.XPath(".//label[@class='switch']"), 2).Click();
				return true;
			}
			return false;
		}

		public bool GetDataConsentTier(string tier)
		{
			var dataConsentRows = this.containerElement.FindElements(By.XPath(".//div[contains(@class,'data-consent')]//table//tbody//tr"), 2);
			var correctRow = dataConsentRows.FirstOrDefault(x => x.FindElement(By.XPath(".//td[1]"), 2).Text.StartsWith(tier));
			if (correctRow != null)
			{
				var checkbox = correctRow.FindElement(By.XPath(".//input[@type='checkbox']"), 2);
				var Checked = checkbox.Selected;
				return Checked;
			}
			return false;
		}

		public bool SaveChangesButtonShowing()
		{
			return this.containerElement.FindElement(By.XPath(".//p/a[contains(@class,'btn')]"), 2).Displayed;
		}


		public bool ClickSaveChanges()
		{
			var el = this.containerElement.FindElement(By.XPath(".//p/a[contains(@class,'btn')]"), 2);
			if (el == null)
				return false;

			try
			{
				el.Click();
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public string WarningMessage()
		{
			return this.containerElement.FindElement(By.XPath(".//div[contains(@class,'alert-warning') and contains(@data-bind,'additionalInfo')]"), 2).Text;
		}
	}

	public class DataEntryNotification : BaseObject
	{
		public const string BasePath = "//div[@id='dataEntryNotifications']";
		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public void ClickClose()
		{
			this.containerElement.FindElement(By.XPath(".//button[text()='Close']"), 2);
		}


	}
}
