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
			return containerElement.FindElements(By.XPath("//div[@id='reportList']//tr/td//span"))
				.FirstOrDefault(x => x.Text == report).FindElement(By.XPath("./../../a")).TryClick();
		}

		public string GetCurrentTitle()
		{
			return containerElement.FindElement(By.XPath("//form[@id='panel']//h3")).Text;
		}

		public string GetCurrentSubText()
		{
			return containerElement.FindElement(By.XPath("//form[@id='panel']//p")).Text;
		}

		public bool ClickDownload()
		{
			return containerElement.FindElement(By.XPath("//form[@id='panel']//button")).TryClick();
		}


	}
}
