using UL.Automation.Selenium.BaseClasses;
using UL.Automation.Selenium.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

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
