using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using ResourcePool;
using SeleniumUtilities;


namespace Wercs.Selenium.PortalUX.Selenium_Classes
{
	public class ULSCLogin : BaseObject
	{
		public const string BasePath = "//div[contains(@class, 'login-container')]";
		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public string Username {
			get { return this.containerElement.FindElement(By.XPath(".//input[@id='UserName']"), 2).Text; }
			set { this.containerElement.FindElement(By.XPath(".//input[@id='UserName']"), 2).EnterText(value); }
		}

		public string Password {
			get { return this.containerElement.FindElement(By.XPath(".//input[@id='Password']"), 2).Text; }
			set
			{
				IWebElement pw = this.containerElement.FindElement(By.XPath(".//input[@id='Password']"), 2);
				pw.EnterText(value);
				pw.SendKeys(Keys.Tab);

			}
		}



		public bool ClickLogIn()
		{
			return this.containerElement.FindElement(By.XPath(".//button"), 2).TryClick();
		}

		public bool ClickForgottenPasswordLink()
		{
			return this.containerElement.FindElement(By.XPath(".//a[contains(@href, 'Login')]"), 2).TryClick();
		}
	}
}

