using System;
using System.Collections.Generic;
using System.Linq;
using NTTQA_Automation_Classes.Base_Classes;
using NTTQA_Automation_Classes.Classes;
using NTTQA_Automation_Classes.Extension_Methods;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumUtilities;


namespace Wercs.Selenium.PortalUX.Selenium_Classes
{
	public class StudioLogin : BaseObject
	{
		public const string BasePath = "//div[@id='divLogOn']";
		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public string Username {
			get { return this.containerElement.FindElement(By.XPath(".//input[@id='txtUsername']"), 2).Text; }
			set { this.containerElement.FindElement(By.XPath(".//input[@id='txtUsername']"), 2).EnterText(value); }
		}

		public string Password {
			get { return this.containerElement.FindElement(By.XPath(".//input[@id='txtPassword']"), 2).Text; }
			set
			{
				IWebElement pw = this.containerElement.FindElement(By.XPath(".//input[@id='txtPassword']"), 2);
				pw.EnterText(value);
				pw.SendKeys(Keys.Tab);

			}
		}

		public string Language {
			get
			{
				return this.containerElement.FindElement(By.XPath(".//select[@id='ddlGUILanguage']"), 2)
					.SelectedOption();
			}
			set
			{
				IWebElement lang = this.containerElement.FindElement(By.XPath(".//select[@id='ddlGUILanguage']"), 2);
				lang.SelectByValue(value);
			}
		}

		public bool ClickSignIn()
		{
			var currentWindow = SeleniumBrowser.WebBrowser.CurrentWindowHandle;
			Context.AddToContext("BaseWindow", currentWindow);
			return this.containerElement.FindElement(By.XPath(".//input[@id='cmdLogin']"), 2).TryClick();
		}


	}
}
