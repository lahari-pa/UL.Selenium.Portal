using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	class TermsOfUse : SeleniumBaseObject
	{
		public const string BasePath = "//div[@id='termsOfUserContainer']";

		protected override By ContainerElementLocator => By.XPath(BasePath);

		public void Accept()
		{
			IWebElement checkBox = this.FindElement(By.XPath(".//input[@id='Accepted']"), 2);
			if (checkBox == null)
			{
				return;
			}

			checkBox.ScrollElementIntoView();
			checkBox.Check(true);

			IWebElement acceptBtn = this.FindElement(By.XPath(".//button[@value='Continue' and @type='submit']"), 2);

			if (acceptBtn == null)
			{
				return;
			}

			acceptBtn.Click();
		}

	}
}
