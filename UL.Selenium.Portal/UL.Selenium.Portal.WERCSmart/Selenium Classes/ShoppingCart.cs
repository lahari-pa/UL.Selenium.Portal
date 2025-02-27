using OpenQA.Selenium;
using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Extensions;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	class ShoppingCart : SeleniumBaseObject
	{
		public const string BasePath = "//div[@id='shoppingCart']";
		protected override By ContainerElementLocator => By.XPath(BasePath);
	}

	class EmptyCart : SeleniumBaseObject
	{
		public const string BasePath = "//div[starts-with(@class,'modal fade in')]";
		protected override By ContainerElementLocator => By.XPath(BasePath);

		public bool ClickClose()
		{
			return this.containerElement.FindElement(By.XPath(".//button[@class='close']"), 2).TryClick();
		}

		public string BodyMessage()
		{
			return this.containerElement.FindElement(By.XPath(".//div[@class='modal-body']"), 2)?.Text;
		}
	}
}
