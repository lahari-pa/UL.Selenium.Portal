using OpenQA.Selenium;
using System;
using UL.Automation.Reporting.Functions;
using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Extensions;
using UL.Automation.WebDriver.Classes;
using UL.Automation.WebDriver.Classes;
using System.Configuration;
using System.Collections.Specialized;
using TReVor.Api.Wrapper.Classes;
using UL.Automation.TReVor.Classes;
using UL.Automation.WebDriver.Shared.Classes.Configuration;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{ 
	public class LoginScreen : SeleniumBaseObject
	{
		protected override By ContainerElementLocator => By.XPath(@".//table[@class='logon-container']");

		private IWebElement UserName => this.ContainerElement.FindElement(By.Id("txtUsername"), 2);

		private IWebElement Password => this.ContainerElement.FindElement(By.Id("txtPassword"), 2);

		private IWebElement LoginButton => this.ContainerElement.FindElement(By.Id("cmdLogin"), 2);
		private string _errorString;
		private IWebElement ErrorMessage => this.ContainerElement.FindElement(By.XPath($"./..//span[contains(text(),'{_errorString}')]"), 2);
		public bool LoginAsUser(string details)
		{

			TReVorTestUsers user = TestUsers.GetUserSavedAs(details);

			string username;
			string password;

			username = user.Username;
			password = user.Password;

			Report.Info("Entering Username");
			if (this.UserName.TryEnterText(username))
			{
				Report.Info("Entering Password");
				if (this.Password.TryEnterText(password, simulateTyping: true, DelayBetweenKeyStrokes: 0.1))
				{
					switch (SeleniumConfig.CurrentConfig.SeleniumSettings.BrowserType.ToLower())
					{
						case "chrome":
						case "firefox":
						case "microsoftedge":
						case "microsoft edge":
						case "edge":
							Delay.Seconds(0.1);
							break;
						default:
							Delay.Seconds(5);
							break;
					}
					Report.Info("Clicking login button");
					return this.LoginButton.JsClick();
				}
			}

			return false;
		}

		internal bool DispayErrorMessage(string errorString)
		{
			_errorString = errorString;
			return this.ErrorMessage != null;
		}
	}
}
