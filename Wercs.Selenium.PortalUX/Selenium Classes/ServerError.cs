using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumUtilities;


namespace Wercs.Selenium.PortalUX.Selenium_Classes
{
	class ServerError : BaseObject
	{
		public const string BasePath = "//h4[@id='myModalLabel']";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }


		public void Click_Close()
		{
			this.containerElement.FindElement(By.XPath("..//button"), 2).Click();
		}

		public string GetErrorMessage()
		{
			var errorMessageContainer = this.containerElement.FindElement(By.XPath("../..//div[@class='modal-body']"), 2);
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
