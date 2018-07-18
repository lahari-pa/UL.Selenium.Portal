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
	class SummaryPage : BaseObject
	{
		public const string BasePath = "//body[@class='summary']";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public List<string> ListOfButtons()
		{
			return containerElement.FindElements(By.XPath(".//button")).Select(x => x.GetValue()).ToList();
		}
	}
}
