using System;
using System.Collections.Generic;
using System.Linq;
using NTTQA_Automation_Classes.Base_Classes;
using NTTQA_Automation_Classes.Classes;
using NTTQA_Automation_Classes.Extension_Methods;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	class Login : BaseObject
	{
		public const string BasePath = "//div[@class='login-wrapper']";
		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public void ClickOutside()
		{
			var el = this.containerElement.FindElement(By.XPath("//div[contains(@class,'panel-body')]"), 2);
			var actionClass = new Actions(SeleniumBrowser.WebBrowser);
			actionClass.MoveToElement(el, -100, -100).Click().Perform();
		}

		public void Change_Language(string language)
		{

			var languageDropDown = this.containerElement.FindElement(By.XPath("//div[@class='btn-group btn-language']"), 2);
			if (languageDropDown == null)
			{
				throw new Exception("Language Button container could not be found!");
			}

			var button = languageDropDown.FindElement(By.XPath(".//button"), 2);
			if (button.Text.Trim() == language)
			{
				return;
			}

			button.Click();
			var selectElement = languageDropDown.FindElements(By.XPath("//ul//a"), 2).FirstOrDefault(x => x.Text == language);
			if (selectElement == null)
			{
				throw new Exception("Language not present in container!");
			}

			selectElement.Click();
		}

		public string Form_Header_Text()
		{
			return this.containerElement.FindElement(By.XPath("//div[@id='loginModal']//div[@class='panel-body']/h3"), 2).Text;
		}

		public string Email_Header_Text()
		{
			return this.containerElement.FindElement(By.XPath("//label[@for='loginEmail']"), 2).Text;
		}

		public string Password_Header_Text()
		{
			return this.containerElement.FindElement(By.XPath("//label[@for='loginPassword']"), 2).Text;
		}

		public string Forgotten_Password_Text()
		{
			return this.containerElement.FindElement(By.XPath("//a[@id='btnForgotPassword']"), 2).Text;
		}

		public string Login_Button_Text()
		{
			return this.containerElement.FindElement(By.XPath("//form[@class='login-form']//button"), 2).Text;
		}

		public string EmailField {
			get { return this.containerElement.FindElement(By.XPath("//input[@name='loginEmail']"), 2).Text; }
			set { this.containerElement.FindElement(By.XPath("//input[@name='loginEmail']"), 2).EnterText(value); }
		}

		public string PasswordField {
			get { return this.containerElement.FindElement(By.XPath("//input[@name='loginPassword']"), 2).Text; }
			set
			{
				IWebElement pw = this.containerElement.FindElement(By.XPath("//input[@name='loginPassword']"), 2);
				pw.EnterText(value);
				pw.SendKeys(Keys.Tab);

			}
		}

		public void Click_Login()
		{
			IWebElement loginButton =
				this.containerElement.FindElement(By.XPath("//form[@class='login-form']//button"), 2);

			if (loginButton != null)
			{
				loginButton.ClickWithScroll();
			}
			else
			{
				throw new Exception("Login button was not found");
			}

		}

		public void Click_Forgotten_Password()
		{
			IList<IWebElement> listOfATags = this.containerElement.FindElements(By.XPath("//form[@class='login-form']//a"));
			listOfATags.FirstOrDefault(x => x.Text == "Forgot your Password?").Click();
		}

		public void Click_New_To_Wercsmart()
		{
			IList<IWebElement> listOfATags = this.containerElement.FindElements(By.XPath("//form[@class='login-form']//a"));
			listOfATags.FirstOrDefault(x => x.Text == "New to WERCSmart? Sign Up").Click();
		}

		public string Email_Validation()
		{
			return this.containerElement.FindElement(By.XPath("//p[@id='loginEmail_error']//span"), 2).Text;
		}

		public string Password_Validation()
		{
			return this.containerElement.FindElement(By.XPath("//p[@id='loginPassword_error']//span"), 2).Text;
		}

	}
}
