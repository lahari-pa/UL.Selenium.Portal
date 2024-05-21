using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Extensions;

namespace UL.Selenium.Portal.RPS.Selenium_Classes
{
	class Login : SeleniumBaseObject
	{
		#region Page Objects

		protected override By ContainerElementLocator => By.XPath(@"//div[@class='body-container']");

		private IWebElement SignInButton => ContainerElement.FindElement(By.XPath(".//div[@id='navbarSupportedContent']//button[contains(text(), 'Sign In']"), 1);

		#endregion

		#region Methods

		public bool ClickSignIn => SignInButton.TryClick();

		#endregion

		class LogInModal : BaseModalDialog
		{
			#region Page Objects
			protected override By ContainerElementLocator => By.Id("loginModal");

			private IWebElement LoginButton => ContainerElement.WaitUntilElementVisible(By.Id("cmdLogIn"), 1);

			private IWebElement UserNameInput => ContainerElement.WaitUntilElementVisible(By.Id("UserName"), 1);

			private IWebElement PasswordInput => ContainerElement.WaitUntilElementVisible(By.Id("Password"), 1);

			private IWebElement ValidationErrors => ContainerElement.WaitUntilElementVisible(By.XPath(".//div[@class='validation-summary-errors']"), 3);

			private IWebElement UserNameLabel => this.UserNameInput.FindElement(By.XPath("./preceding-sibling::label[position()=1]"), 1);

			private IWebElement PasswordLabel => this.PasswordInput.FindElement(By.XPath("./preceding-sibling::label[position()=1]"), 1);

			#endregion

			#region Methods
			public bool UserNameLabelDisplayed() => this.UserNameLabel != null && this.UserNameLabel.Text.ToLower() == "user name";

			public bool PasswordLabelDisplayed() => this.PasswordLabel != null && this.PasswordLabel.Text == "Password";

			public bool LoginButtonTextDisplayed() => this.LoginButton?.GetValue() == "Log In";

			public bool CloseButtonTextDisplayed() => this.ButtonWithTextDisplayed("Close");

			public bool ClickCloseButton() => this.ClickButtonByText("Close");

			public bool ClickLoginButton => this.LoginButton.TryClick();

			public bool EnterUserName(string text) => this.UserNameInput.TryEnterText(text) && this.UserNameInput.GetValue() == text;

			public bool EnterPassword(string text) => this.PasswordInput.TryEnterText(text) && this.PasswordInput.GetValue() == text;

			public List<string> LogInErrors() => this.ValidationErrors.FindElements(By.XPath("./ul/li"), 1)?.Select(x => x.Text).ToList();
			#endregion
		}
	}
}
