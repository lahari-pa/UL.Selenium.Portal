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
	class DeleteActiveProducts : BaseObject
	{
		public const string BasePath = "//div[@id='delete-active-products-grid']";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

	}
}
