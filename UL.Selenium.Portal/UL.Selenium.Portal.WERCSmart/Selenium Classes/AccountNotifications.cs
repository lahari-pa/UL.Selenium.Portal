using UL.Automation.Selenium.BaseClasses;
using UL.Automation.Selenium.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	class AccountNotifications : SeleniumBaseObject
	{
		public const string BasePath = "//div[@id='accountNotifications']";

		protected override By ContainerElementLocator => By.XPath(BasePath);

		public void Click_Close()
		{
			this.containerElement.FindElement(By.XPath("//div[@class='modal-footer']/button"), 2).Click();
		}

		public string GetErrorText()
		{
			return this.containerElement.FindElement(By.XPath("//div[@class='modal-body']")).Text.Trim();
		}

		public string GetTitle()
		{
			return this.containerElement.FindElement(By.XPath("//*[@id='myModalLabel']")).Text.Trim();
		}
	}
}
