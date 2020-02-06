using UL.Automation.Selenium.BaseClasses;
using UL.Automation.Selenium.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes.ChooseGoodGuide
{
	class ChooseGoodGuide_Homepage : SeleniumBaseObject
	{
		// Cannot have a more precise container element than this
		public const string BasePath = "//body";

		protected override By ContainerElementLocator => By.XPath(BasePath);

		public bool ClickGetStarted()
		{
			return this.containerElement.FindElement(By.XPath(".//a[text()='Get Started NOW']"), 2).TryClick();
		}
	}
}
