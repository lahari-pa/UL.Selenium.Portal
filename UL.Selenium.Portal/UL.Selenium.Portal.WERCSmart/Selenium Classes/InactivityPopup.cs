using System;
using NTTQA.Selenium.BaseClasses;
using NTTQA.Selenium.Classes;
using NTTQA.Selenium.ExtensionMethods;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	class InactivityPopup : BaseObject
	{
		public const string BasePath = "//div[@id='LogOutModal']";
		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public bool IsVisible()
		{
			this.containerElement = SeleniumBrowser.WebBrowser.FindElement(By.XPath(BasePath), 2);
			return this.containerElement.GetAttribute("class") != "modal fade";
		}

		public bool ClickYes()
		{
			var btn = this.containerElement.FindElement(By.XPath(".//button[text()='Yes']"));
			if (btn == null)
			{
				return false;
			}

			try
			{
				btn.Click();
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public bool ClickNo()
		{
			var btn = this.containerElement.FindElement(By.XPath(".//a[text()='No']"));
			if (btn == null)
			{
				return false;
			}

			try
			{
				btn.Click();
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}


	}
}
