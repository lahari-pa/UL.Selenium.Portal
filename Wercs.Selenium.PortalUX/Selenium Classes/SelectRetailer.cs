using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumUtilities;
using SafewareReporting;

namespace Wercs.Selenium.PortalUX.Selenium_Classes
{
	class SelectRetailers : BaseObject
	{
		public const string BasePath = "//div[@id='select-retailers-dialog']";
		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public bool selectRetailer(string retailer)
		{
			var RetailerInput = containerElement.FindElements(By.XPath("//label/span")).Where(x => x.Text.Trim() == retailer).FirstOrDefault()
				.FindElement(By.XPath("../input"));

			if (RetailerInput != null)
			{
				RetailerInput.Click();
				Delay.Seconds(1);
				return RetailerInput.Selected;
			}
			else
			{
				Report.Error("Could not find retailer: " + retailer);
			}

			return false;
		}

		public List<string> getListOfRetailers()
		{
			return containerElement.FindElements(By.XPath("//label/span")).Select(x => x.Text).ToList();
		}

		public void clickSelectAll()
		{
			containerElement.FindElements(By.XPath("//div[@id='select-retailers-dialog']//a[contains(text(), 'Select all')]"))
				.FirstOrDefault().ClickWithScroll();
		}

		public void clickDone()
		{
			containerElement.FindElements(By.XPath("//div[@id='select-retailers-dialog']//a[contains(text(), 'Done')]"))
				.FirstOrDefault().ClickWithScroll();
		}
	}
}
