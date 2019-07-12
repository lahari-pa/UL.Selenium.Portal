using System;
using System.Runtime.Remoting.Messaging;
using NTTQA.Selenium.BaseClasses;
using NTTQA.Selenium.Classes;
using NTTQA.Selenium.ExtensionMethods;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	class InactivityPopup : SeleniumBaseObject
	{
		public const string BasePath = "//div[@id='LogOutModal']";

		protected override By ContainerElementLocator => By.XPath(BasePath);

		private IWebElement ButtonByText(string btnText) => this.containerElement.FindElement(By.XPath($@".//button[text() = ""{btnText}""]"), 1);

		public bool IsVisible()
		{
			//this.containerElement = SeleniumBrowser.WebBrowser.FindElement(By.XPath(BasePath), 2);
			return this.containerElement.GetAttribute("class") != "modal fade";
		}

		public bool ClickYes() => this.ButtonByText("Yes").TryClick();

		public bool ClickNo() => this.ButtonByText("No").TryClick();

	}
}
