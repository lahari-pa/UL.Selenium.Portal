using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	class PasswordExpired : SeleniumBaseObject
	{
		public const string BasePath = "//body[@class='login-body']";
		protected override By ContainerElementLocator => By.XPath(BasePath);


		public string TopMessage()
		{
			return this.containerElement.FindElement(By.XPath(".//div[@class='item active']/p"), 2)?.Text;
		}

		public string TopHeading()
		{
			return this.containerElement.FindElement(By.XPath(".//div[@class='item active']/h4"), 2)?.Text;
		}

		public string OriginalPassword {
			get => this.containerElement.FindElement(By.XPath("//input[@name='loginPassword']"), 2)?.Text;
			set => this.containerElement.FindElement(By.XPath("//input[@name='loginPassword']"), 2).EnterText(value);
		}

		public string NewPassword {
			get => this.containerElement.FindElement(By.XPath("//input[@id='newPassword']"), 2)?.Text;
			set => this.containerElement.FindElement(By.XPath("//input[@id='newPassword']"), 2).EnterText(value);
		}

		public string VerifyPassword {
			get => this.containerElement.FindElement(By.XPath("//input[@id='verifyPassword']"), 2)?.Text;
			set => this.containerElement.FindElement(By.XPath("//input[@id='verifyPassword']"), 2).EnterText(value);
		}

		public bool ClickContinue()
		{
			return this.containerElement.FindElement(By.XPath("//a[@type='button' and @id='carouselContinue']"), 2).TryClick();
		}

		public bool ClickLogin()
		{
			return this.containerElement.FindElement(By.XPath("//a[@type='button' and @id='corouselLogin']"), 2).TryClick();
		}

	}
}
