using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumUtilities;

namespace Wercs.Selenium.PortalUX.Selenium_Classes
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
