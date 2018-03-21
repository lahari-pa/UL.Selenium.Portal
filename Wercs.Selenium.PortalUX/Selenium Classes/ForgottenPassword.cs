using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumUtilities;


namespace Wercs.Selenium.PortalUX.Selenium_Classes
{
	class ForgottenPassword : BaseObject
	{
		public const string BasePath = "//div[@class='login-wrapper']";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		/// <summary>
		/// Gets the Continue button
		/// </summary>
		public void Click_Continue()
		{
			var btn = this.containerElement.FindElement(By.XPath(".//a[@id='carouselContinue']"), 2);
			btn.Click();
		}

		/// <summary>
		/// Gets the cancel button on the forgot password page
		/// </summary>
		public void Click_Cancel()
		{
			var btn = this.containerElement.FindElement(By.XPath(".//a[@id='carouselCancel']"), 2);
			btn.Click();
		}

		public void Enter_Email(string email)
		{
			int count = 0;
			while (count < 10)
			{
				try
				{
					this.containerElement.FindElement(By.XPath("//input[@id='forgotEmail']"), 2).EnterText(email, true);
					return;
				}
				catch (Exception)
				{
					Delay.Seconds(Delay.SpeedFactor * 1);
					count++;
				}

				throw new Exception("Could not enter email!");
			}

		}

		public bool Login_Button_Exists()
		{
			return this.containerElement.FindElement(By.XPath("//a[@id='btnLogin']"), 2).Displayed;
		}

		///<summary>
		/// Clicking the login button that is found on the forget password screen (after you enter email)
		///</summary>
		public void Click_Login_Button()
		{
			this.containerElement.FindElement(By.XPath("//a[@id='btnLogin']"), 2).Click();
		}

		public List<string> GetErrors()
		{
			try
			{
				return this.containerElement.FindElements(By.XPath("//p[@id='email_error']/span"), 2).Select(x => x.GetValue().Trim()).ToList();
			}
			catch (Exception)
			{
				return new List<string>();
			}


		}

		///<summary>
		/// this is for the success message when a user submits a valid email
		///</summary>
		public string ForgotPasswordSuccessMessage()
		{
			return this.containerElement.FindElement(By.XPath("//*[@id='wizardCarousel']/div[1]/div[2]/p"), 2).GetValue();
		}
	}
}
