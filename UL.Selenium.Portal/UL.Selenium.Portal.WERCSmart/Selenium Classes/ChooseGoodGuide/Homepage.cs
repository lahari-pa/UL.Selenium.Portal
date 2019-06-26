using NTTQA.Selenium.BaseClasses;
using NTTQA.Selenium.ExtensionMethods;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes.ChooseGoodGuide
{
	class ChooseGoodGuide_Homepage : BaseObject
	{
		// Cannot have a more precise container element than this
		public const string BasePath = "//body";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public bool ClickGetStarted()
		{
			return this.containerElement.FindElement(By.XPath(".//a[text()='Get Started NOW']"), 2).TryClick();
		}
	}
}
