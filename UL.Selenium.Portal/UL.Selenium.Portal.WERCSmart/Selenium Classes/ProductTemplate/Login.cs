using OpenQA.Selenium;
using UL.Automation.Reporting.Functions;
using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Extensions;


namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes.ProductTemplate
{
	class ProductTemplateLogin : SeleniumBaseObject
	{
		#region Page Objects
		protected override By ContainerElementLocator => By.XPath(@"//body[.//form[contains(@action,'WSProductTemplating')]]");
		private IWebElement UserNameInput => this.FindElement(By.Id("UserName"));
		private IWebElement PasswordInput => this.FindElement(By.Id("Password"));
		private IWebElement PasswordResetLink => this.FindElement(By.LinkText("Reset"));
		private IWebElement NextButton => this.FindElement(By.XPath(".//button[normalize-space(text())='Next']"));
		#endregion

		#region Methods
		public bool UserNameInputExists()
		{
			Report.Info($"Attempting to confirm User Name input exists.");
			return this.UserNameInput != null;
		}

		public bool UserNameInputEnterText(string userName)
		{
			Report.Info($"Attempting to enter user name: '{userName}'");
			return this.UserNameInput.TryEnterText(userName);
		}

		public bool PasswordInputExists()
		{
			Report.Info($"Attempting to confirm Password input exists.");
			return this.PasswordInput != null;
		}

		public bool PasswordInputEnterText(string userName)
		{
			Report.Info($"Attempting to enter password: '*******'");
			return this.PasswordInput.TryEnterText(userName);
		}

		public bool NextButtonExists()
		{
			Report.Info($"Attempting to confirm Next button exists.");
			return this.NextButton != null;
		}

		public bool NextButtonClick()
		{
			Report.Info($"Attempting to click Next button.");
			return this.NextButton.TryClick();
		}


		#endregion
	}
}
