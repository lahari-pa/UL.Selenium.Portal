using System;
using System.Linq;
using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Classes;
using UL.Automation.WebDriver.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using UL.Automation.Reporting.Functions;
using UL.Selenium.Portal.WERCSmart.Steps;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	class Login : SeleniumBaseObject
	{
		protected override By ContainerElementLocator => By.XPath(@"//div[@class='login-wrapper']");

		private IWebElement LoginButton => this.containerElement.FindElement(By.XPath("//form[@class='login-form']//button"), 5);

		private IWebElement EmailInput => this.containerElement.FindElement(By.XPath("//input[@name='loginEmail']"), 5);

		private IWebElement PasswordInput => this.containerElement.FindElement(By.XPath("//input[@name='loginPassword']"), 5);

		private IWebElement ForgotPasswordLink => this.containerElement.FindElement(By.XPath("//a[@id='btnForgotPassword']"), 5);

		private IWebElement SignUpLink => this.containerElement.FindElement(By.XPath("//a[@id='btnSignUp']"), 5);

		private IWebElement EmailError => this.containerElement.FindElement(By.XPath("//p[@id='loginEmail_error']"), 5);

		private IWebElement PasswordError => this.containerElement.FindElement(By.XPath("//p[@id='loginPassword_error']"), 5);

		private IWebElement FormHeader => this.containerElement.FindElement(By.XPath("//div[@id='loginModal']//div[@class='panel-body']/h3"), 5);

		private IWebElement EmailHeader => this.containerElement.FindElement(By.XPath("//label[@for='loginEmail']"), 5);

		private IWebElement PasswordHeader => this.containerElement.FindElement(By.XPath("//label[@for='loginPassword']"), 5);

		private IWebElement LoginError => this.containerElement.FindElement(By.XPath("//div[@id='accountNotifications']//p"), 5);


		public void ClickOutside()
		{
			IWebElement el = this.containerElement.FindElement(By.XPath("//div[contains(@class,'panel-body')]"), 2);
			var actionClass = new Actions(SeleniumWebDriver.CurrentDriver);
			actionClass.MoveToElement(el, -100, -100).Click().Perform();
		}

		public void Change_Language(string language)
		{

			IWebElement languageDropDown = this.containerElement.FindElement(By.XPath("//div[@class='btn-group btn-language']"), 2);
			if (languageDropDown == null)
			{
				throw new Exception("Language Button container could not be found!");
			}

			IWebElement button = languageDropDown.FindElement(By.XPath(".//button"), 2);
			if (button.Text.Trim() == language)
			{
				return;
			}

			button.Click();
			IWebElement selectElement = languageDropDown.FindElements(By.XPath("//ul//a"), 2).FirstOrDefault(x => x.Text == language);
			if (selectElement == null)
			{
				throw new Exception("Language not present in container!");
			}

			selectElement.Click();
		}

		public string Form_Header_Text()
		{
			return this.FormHeader?.Text;
		}

		public string Email_Header_Text()
		{
			return this.EmailHeader?.Text;
		}

		public string Password_Header_Text()
		{
			return this.PasswordHeader?.Text;
		}

		public string Forgotten_Password_Text()
		{
			return this.ForgotPasswordLink?.Text;
		}

		public string SignUp_Text()
		{
			return this.SignUpLink?.Text;
		}

		public string Login_Button_Text()
		{
			return this.LoginButton?.Text;
		}

		public string EmailField {
			get => this.EmailInput?.Text;
			set
			{
				this.EmailInput.EnterText(value);
				this.EmailInput.SendKeys(Keys.Tab);
			}
		}

		public string PasswordField {
			get => this.PasswordInput?.Text;
			set
			{
				//this.PasswordInput.TryEnterText(value);
				this.PasswordInput.TryEnterText(value);
				this.PasswordInput.SendKeys(Keys.Tab);
			}
		}

		public bool Click_Login()
		{
			return this.LoginButton.TryClick();
		}

		public bool Click_Forgotten_Password()
		{
			return this.ForgotPasswordLink.TryClick();
		}

		public bool Click_New_To_WercSmart()
		{
			return this.SignUp_Text() == "New to WERCSmart? Sign Up" && this.SignUpLink.TryClick();
		}

		public string Email_Error_Text()
		{
			return this.EmailError?.FindElement(By.XPath(".//span"), 2)?.Text;
		}

		public string Password_Error_Text()
		{
			return this.PasswordError?.FindElement(By.XPath(".//span"), 2)?.Text;
		}

		public string IncorrectLoginDetails_Error_Text()
		{
			return this.LoginError?.FindElement(By.XPath(".//span"), 2)?.Text;
		}

		public string AccountNotificationsMessageText()
		{
			return this.LoginError?.Text;
		}

		public string GetServerErrorMessage()
		{
			IWebElement errorModal = this.WebDriver.FindElement(By.CssSelector("#accountNotifications .modal-dialog .modal-content"), 2);
			return errorModal?.FindElement(By.CssSelector(".modal-body"), 2)?.Text;
		}

		public bool LoginErrorDisplayed()
		{
			return this.LoginError != null;

		}
	}
	public class LandingPlatform : SeleniumBaseObject
	{
		protected override By ContainerElementLocator => By.Id("container");
		private IWebElement EmailInput => this.ContainerElement.FindElement(By.Id("signInName"), 2);
		private IWebElement PasswordInput => this.ContainerElement.FindElement(By.Id("password"), 2);
		private IWebElement EmailReadOnly => this.ContainerElement.FindElement(By.Id("readonlyEmailAnchor"), 2);
		private IWebElement PageHeader => this.ContainerElement.FindElement(By.XPath(".//div[@class='content-box']/descendant::h1"), 1);
		private IWebElement SubHeader => this.ContainerElement.FindElement(By.XPath(".//div[@class='content-box']/descendant::h2"), 1);
		private IWebElement SignInOrNextBtn => this.ContainerElement.FindElement(By.Id("continue"), 1);
		private IWebElement Loading => this.ContainerElement.FindElement(By.Id("api"), 2);
		public bool EnterEmailId(string email)
		{
			if (this.PageHeader?.Text != "UL Solutions Account" && this.SubHeader?.Text != "Sign in to your account")
			{
				Report.Error($"Expected 'UL Solutions Account' but displayed :'{this.PageHeader.Text}', Expected 'Sign in to your account' but displayed :'{SubHeader.Text}'");
			}
			if (!this.LoadingWait())
			{
				Report.Info("Still Loading...");
				return false;
			}
			Report.Info($"Entering Email Address: '{email}");
			this.EmailInput.EnterText(email);
			Report.Screenshot();
			Report.Info("Clicking Next button");
			return this.SignInOrNextBtn.TryClick();
		}
		public bool SignIn(string email, string password)
		{
			this.WaitForContainerToBeVisible();
			if (!this.EnterEmailId(email))
			{
				Report.Info("Not able to sign in");
				return false;
			}
			if (!this.OverLayer())
			{
				Report.Info("Still Overlay...");
				return false;
			}
			if (this.PageHeader?.Text != "UL Solutions Account" && this.SubHeader?.Text != "Enter your password")
			{
				Report.Error("Header or Sub-header text are mismatched");
			}
			if (!this.LoadingWait())
			{
				Report.Info("Still Loading...");
				return false;
			}
			if (!string.Equals(this.EmailReadOnly?.Text.Replace("arrow_back", "", StringComparison.CurrentCultureIgnoreCase), email,
					StringComparison.CurrentCultureIgnoreCase))
			{
				Report.Info($"Entered {email} mail is not shown {this.EmailReadOnly?.Text}");
				return false;
			}
			Report.Info($"Entering Password: '{password}");
			this.PasswordInput.EnterText(password);
			Report.Screenshot();
			Report.Info("Clicking sign-in button");
			this.SignInOrNextBtn.TryClick();
			return new Homepage().WaitForContainerToBeVisible();
		}
		public bool OverLayer(int attempt = 60)
		{
			Report.Info("Verify the Overlay...");
			IWebElement overLay = this.WebDriver.FindElement(By.Id("simplemodal-overlay"), 2);
			int counter = 0;
			while (overLay != null && counter < attempt)
			{
				overLay = this.WebDriver.FindElement(By.Id("simplemodal-overlay"), 2);
				this.WaitForContainerToBeInvisible(3);
				counter++;
			}
			return overLay == null;
		}
		public bool LoadingWait(int attempt = 60)
		{
			Report.Info("Verify the Loading...");
			string loadWheel = this.Loading?.GetAttribute("class");
			int counter = 0;
			while (loadWheel != string.Empty && counter < attempt)
			{
				loadWheel = this.Loading?.GetAttribute("class");
				this.WaitForContainerToBeInvisible(2);
				counter++;
			}
			return loadWheel == string.Empty;
		}
	}
	public class CookiesFooter : SeleniumBaseObject
	{
		protected override By ContainerElementLocator => By.XPath(".//div[@id='truste-consent-track' and not(contains(@style,'display: none;'))]");
		private IWebElement AcceptCookiesBtn => this.ContainerElement.FindElement(By.XPath(".//button[text()='Accept All Cookies']"), 1);
		public bool AcceptCookiesClick()
		{
			Report.Info("Attempting to Click Accept Cookies Button");
			this.AcceptCookiesBtn.TryClick();
			return true;
		}
		public bool AcceptCookies()
		{
			Delay.Seconds(2);
			if (this.ContainerVisible())
			{
				if (!this.AcceptCookiesClick())
				{
					Report.Info("Failed to Click Accept Cookies Button");
					Report.Screenshot();
					return false;
				}
				Delay.Seconds(2);
				if (this.ContainerVisible())
				{
					Report.Info("Failed to Remove Cookies Bar");
					Report.Screenshot();
					return false;
				}
				Report.Success("Cookies Accepted");
				Report.Screenshot();
				return true;
			}
			Report.Info("Cookies Bar not Showing");
			return true;
		}
	}
}

