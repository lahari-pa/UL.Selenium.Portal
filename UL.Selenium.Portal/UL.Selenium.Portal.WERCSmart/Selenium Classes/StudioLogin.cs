using OpenQA.Selenium;
using UL.Automation.ReqnrollHelpers.Classes;
using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Classes;
using UL.Automation.WebDriver.Extensions;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	public class StudioLogin : SeleniumBaseObject
	{
		public const string BasePath = "//div[@id='divLogOn']";
		protected override By ContainerElementLocator => By.XPath(BasePath);

		public string Username
		{
			get => this.containerElement.FindElement(By.XPath(".//input[@id='txtUsername']"), 2).Text;
			set => this.containerElement.FindElement(By.XPath(".//input[@id='txtUsername']"), 2).EnterText(value);
		}

		public string Password
		{
			get => this.containerElement.FindElement(By.XPath(".//input[@id='txtPassword']"), 2).Text;
			set
			{
				IWebElement pw = this.containerElement.FindElement(By.XPath(".//input[@id='txtPassword']"), 2);
				pw.EnterText(value);
				pw.SendKeys(Keys.Tab);

			}
		}

		public string Language
		{
			get => this.containerElement.FindElement(By.XPath(".//select[@id='ddlGUILanguage']"), 2)
					.SelectedOption();
			set
			{
				IWebElement lang = this.containerElement.FindElement(By.XPath(".//select[@id='ddlGUILanguage']"), 2);
				lang.SelectByValue(value);
			}
		}

		public bool ClickSignIn()
		{
			string currentWindow = SeleniumWebDriver.CurrentDriver.CurrentWindowHandle;
			Context.AddToContext("BaseWindow", currentWindow);
			return this.containerElement.FindElement(By.XPath(".//input[@id='cmdLogin']"), 2).TryClick();
		}


	}
}
