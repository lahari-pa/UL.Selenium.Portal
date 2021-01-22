using System.Collections.Generic;
using System.Linq;
using UL.Automation.Selenium.BaseClasses;
using UL.Automation.Selenium.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace UL.Selenium.Portal.ULSC.Selenium_Classes
{
	class WebElements : BaseObject
	{
		public const string BasePath = "//nav[@class='sidebar']";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		
	}
}
