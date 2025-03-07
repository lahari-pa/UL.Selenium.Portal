using OpenQA.Selenium;
using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Extensions;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	class PasswordExpired : SeleniumBaseObject
	{
		protected override By ContainerElementLocator => By.CssSelector("body.login-body .login-wrapper.register");

		public string TopMessage()
		{
			return this.FindElement(By.XPath(".//div[@class='item active']/p"), 2)?.Text;
		}

		public string TopHeading()
		{
			return this.FindElement(By.XPath(".//div[@class='item active']/h4"), 2)?.Text;
		}

		public string OriginalPassword
		{
			get => this.FindElement(By.XPath(".//input[@name='loginPassword']"), 2)?.Text;
			set => this.FindElement(By.XPath(".//input[@name='loginPassword']"), 2).EnterText(value);
		}

		public string NewPassword
		{
			get => this.FindElement(By.XPath(".//input[@id='newPassword']"), 2)?.Text;
			set => this.FindElement(By.XPath(".//input[@id='newPassword']"), 2).EnterText(value);
		}

		public string VerifyPassword
		{
			get => this.FindElement(By.XPath(".//input[@id='verifyPassword']"), 2)?.Text;
			set => this.FindElement(By.XPath(".//input[@id='verifyPassword']"), 2).EnterText(value);
		}

		public bool ClickContinue()
		{
			return this.FindElement(By.XPath(".//a[@type='button' and @id='carouselContinue']"), 2).TryClick();
		}

		public bool ClickLogin()
		{
			return this.FindElement(By.XPath(".//a[@type='button' and @id='corouselLogin']"), 2).TryClick();
		}
	}
}
