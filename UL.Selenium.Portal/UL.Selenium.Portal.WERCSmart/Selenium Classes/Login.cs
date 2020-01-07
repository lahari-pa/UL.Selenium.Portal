using System;
using System.Linq;
using UL.Automation.Selenium.BaseClasses;
using UL.Automation.Selenium.Classes;
using UL.Automation.Selenium.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

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

		public void ClickOutside()
		{
			IWebElement el = this.containerElement.FindElement(By.XPath("//div[contains(@class,'panel-body')]"), 2);
			var actionClass = new Actions(SeleniumBrowser.WebBrowser);
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

	}
}
