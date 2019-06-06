using NTTQA.Selenium.BaseClasses;
using NTTQA.Selenium.ExtensionMethods;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	class ShoppingCart : BaseObject
	{
		public const string BasePath = "//div[@id='shoppingCart']";
		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }
	}

	class EmptyCart : BaseObject
	{
		public const string BasePath = "//div[starts-with(@class,'modal fade in')]";
		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

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
