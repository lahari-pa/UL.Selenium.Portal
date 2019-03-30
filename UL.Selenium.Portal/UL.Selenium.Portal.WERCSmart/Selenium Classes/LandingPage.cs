using System.Collections.Generic;
using System.Linq;
using NTTQA_Automation_Classes.Base_Classes;
using NTTQA_Automation_Classes.Classes;
using NTTQA_Automation_Classes.Extension_Methods;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Wercs.Selenium.PortalUX.Selenium_Classes
{
	class LandingPage : BaseObject
	{
		public const string BasePath = "//div[@class='navbar navbar-default']";
		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public void Click_Login()
		{
			var loginButton = this.containerElement.FindElement(By.XPath(".//a[@id='loginButton']"), 2);
			if (loginButton == null)
			{ loginButton = this.containerElement.FindElement(By.XPath(".//a[contains (@href, 'ssologin')]"), 2); };
			loginButton.Click();
			var selLogin = new Login();
			selLogin.Wait_for_load();
			Delay.Seconds(Delay.SpeedFactor * 1);
		}

		public void Click_Signup()
		{
			var navigationElements = this.containerElement.FindElements(By.XPath(".//ul[@class='nav navbar-nav']//a"), 2);
			navigationElements.FirstOrDefault(x => x.Text.Trim() == "Sign Up").Click();
		}

		public List<string> NavigationOptionsAvailable()
		{
			var elements = this.containerElement.FindElements(By.XPath(".//ul[@class='nav navbar-nav']//a"), 2);
			return elements.Select(x => x.Text.Trim()).ToList();
		}

		public bool SelectOption(string option)
		{
			var optionLink = this.containerElement.FindElements(By.XPath(".//ul[@class='nav navbar-nav']//a"), 2).FirstOrDefault(x => x.GetValue().Trim() == option.Trim());
			if (optionLink == null)
			{ return false; }
			optionLink.Click();
			return true;
		}


	}

	class LandingPageFooter : BaseObject
	{
		public const string BasePath = "//footer/div[@class='container']";
		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }
		public bool ClickGetStartedNow()
		{
			return containerElement.FindElement(By.XPath(".//a[text()='Get started now']"), 2).TryClick();
		}

		public bool ClickTermsOfUse()
		{
			return containerElement.FindElement(By.XPath(".//a[contains(text(),'Terms')]"), 2).TryClick();
		}
	}

	class ManufacturersInfo : BaseObject
	{
		public const string BasePath = "//body[@class='manufacturers']";
		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }
	}

	class RetailersInfo : BaseObject
	{
		public const string BasePath = "//body[@class='retailers']";
		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }
	}

	class SubscriptionInfo : BaseObject
	{
		public const string BasePath = "//body[@class='subscription-options']";
		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }
	}


	class ServerErrorDialog : BaseObject
	{
		public const string BasePath = "//div[contains(@class, 'in')]//h4[@id='myModalLabel']/../..";
		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public string Error_Text()
		{
			return this.containerElement.FindElement(By.XPath(".//div[@class='modal-body']"), 2).Text;
		}

		public bool ClickClose()
		{
			return this.containerElement.FindElement(By.XPath(".//button[@class='btn btn-default']"), 2).TryClick();
		}
	}
}
