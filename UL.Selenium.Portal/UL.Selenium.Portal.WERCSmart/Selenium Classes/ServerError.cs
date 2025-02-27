using OpenQA.Selenium;
using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Extensions;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	class ServerError : SeleniumBaseObject
	{
		public const string BasePath = "//h4[@id='myModalLabel']";

		protected override By ContainerElementLocator => By.XPath(BasePath);


		public void Click_Close()
		{
			this.containerElement.FindElement(By.XPath("..//button"), 2).Click();
		}

		public string GetErrorMessage()
		{
			IWebElement errorMessageContainer = this.containerElement.FindElement(By.XPath("../..//div[@class='modal-body']"), 2);
			if (errorMessageContainer != null)
			{
				return errorMessageContainer.GetValue();
			}
			else
			{
				return "";
			}

		}
	}
}
