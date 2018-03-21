using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumUtilities;



namespace Wercs.Selenium.PortalUX.Selenium_Classes
{
	class Signup : BaseObject
	{
		public const string BasePath = "//div[@class='login-wrapper']";
		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public void Enter_Email(string email)
		{
			this.containerElement.FindElement(By.XPath("//input[@id='txtEmail']")).EnterText(email, true, 0.05);
		}

		public void ClickEnterEmail()
		{
			this.containerElement.FindElement(By.XPath("//input[@id='txtEmail']")).Click();
		}

		public void CopyEnterEmailContentsToClipboard()
		{
			var enteremail = this.containerElement.FindElement(By.XPath("//input[@id='txtEmail']"));
			enteremail.SendKeys(OpenQA.Selenium.Keys.Control + "a");
			enteremail.SendKeys(OpenQA.Selenium.Keys.Control + "c");
		}


		public void Enter_ConfirmEmail(string email)
		{
			this.containerElement.FindElement(By.XPath("//input[@id='txtConfirm']")).EnterText(email, true, 0.05);
		}

		public void ClickConfirmEmail()
		{
			this.containerElement.FindElement(By.XPath("//input[@id='txtConfirm']")).Click();
		}

		public void PasteIntoConfirmEmailFromClipboard()
		{
			var confirmEmail = this.containerElement.FindElement(By.XPath("//input[@id='txtConfirm']"));
			confirmEmail.SendKeys(OpenQA.Selenium.Keys.Control + "v");
		}

		public bool Click_Submit()
		{
			try
			{
				this.containerElement.FindElements(By.XPath("//a")).FirstOrDefault(x => x.Text == "Submit").Click();
				return true;
			}
			catch (Exception)
			{
				return false;
			}

		}

		public void Click_Cancel()
		{
			var btn = this.containerElement.FindElement(By.XPath(".//a[@id='carouselCancel']"), 2);
			btn.Click();
		}

		public bool Enter_Email_Error_Exists()
		{
			return (this.containerElement.FindElements(By.XPath("//p[@id='txtEmail_error']/span")).Count > 0);
		}

		public string Get_Email_Error()
		{
			return this.containerElement.FindElements(By.XPath("//p[@id='txtEmail_error']/span"))[0].Text;
		}

		public bool Confirm_Email_Error_Exists()
		{
			return (this.containerElement.FindElements(By.XPath("//p[@id='confirmEmail_error']/span")).Count > 0);
		}

		public string Get_Confirm_Email_Error()
		{
			return this.containerElement.FindElements(By.XPath("//p[@id='confirmEmail_error']/span"))[0].Text;
		}

		public bool Sign_Up_Thank_You_Page_Exists(int secondsToWait = 30)
		{
			IWebElement element = element = this.containerElement.FindElement(By.XPath(".//div[@class='item active']//a[@class= 'btnL btn btn-success']"), 2);

			int i = 0;
			while (element == null && i < secondsToWait)
			{
				Delay.Seconds(Delay.SpeedFactor * 1);
				element = this.containerElement.FindElement(By.XPath(".//div[@class='item active']//a[@class= 'btnL btn btn-success']"), 2);
				i++;
			}

			return element != null && element.Displayed;
		}

		public void Click_Login_On_Sign_Up_Thank_You_Page()
		{
			this.containerElement.FindElement(By.XPath("//div[@class='item active']//a[@class= 'btnL btn btn-success']")).Click();
		}

		public List<string> GetEnterEmailErrors()
		{
			return this.containerElement.FindElements(By.XPath("//p[@id='txtEmail_error']/span")).Select(x => x.Text.Trim()).ToList();
		}

		public List<string> GetConfirmEmailErrors()
		{
			return this.containerElement.FindElements(By.XPath("//p[@id='confirmEmail_error']/span")).Select(x => x.Text.Trim()).ToList();
		}
	}
}
