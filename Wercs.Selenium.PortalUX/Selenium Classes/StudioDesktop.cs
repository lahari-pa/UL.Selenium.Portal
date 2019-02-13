using System;
using System.Collections.Generic;
using System.Linq;
using NTTQA_Automation_Classes.Base_Classes;
using NTTQA_Automation_Classes.Classes;
using NTTQA_Automation_Classes.Extension_Methods;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;


namespace Wercs.Selenium.PortalUX.Selenium_Classes
{
	public class StudioDesktop : BaseObject
	{
		public const string BasePath = "//iframe[@id='dashboard']";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		//events, announcements, regulatory, technical
		public bool ClickSection(string section)
		{
			SeleniumBrowser.WebBrowser.SwitchTo().Frame("dashboard");
			return SeleniumBrowser.WebBrowser
				.FindElement(By.XPath(".//div[@id='sections-index']//li[@class='" + section.ToLower() + "']//a"))
				.TryClick();
		}


	}
}
