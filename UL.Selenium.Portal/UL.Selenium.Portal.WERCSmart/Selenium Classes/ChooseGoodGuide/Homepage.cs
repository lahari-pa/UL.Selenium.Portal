using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTTQA_Automation_Classes.Base_Classes;
using NTTQA_Automation_Classes.Extension_Methods;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Wercs.Selenium.PortalUX.Selenium_Classes.ChooseGoodGuide
{
	class ChooseGoodGuide_Homepage : BaseObject
	{
		// Cannot have a more precise container element than this
		public const string BasePath = "//body";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public bool ClickGetStarted()
		{
			return containerElement.FindElement(By.XPath(".//a[text()='Get Started NOW']"), 2).TryClick();
		}
	}
}
