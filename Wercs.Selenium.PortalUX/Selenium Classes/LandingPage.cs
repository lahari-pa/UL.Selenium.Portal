using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumUtilities;



namespace Wercs.Selenium.PortalUX.Selenium_Classes
{
	class LandingPage : BaseObject
	{
		public const string BasePath = "//div[@class='navbar navbar-default']";
		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public void Click_Login()
		{
			var LoginButton = containerElement.FindElement(By.XPath(".//a[@id='loginButton']"), 2);
			LoginButton.Click();
			var Sel_Login = new Login();
			Sel_Login.Wait_for_load();
			Delay.Seconds(Delay.SpeedFactor * 1);
		}

		public void Click_Signup()
		{
			var NavigationElements = containerElement.FindElements(By.XPath(".//ul[@class='nav navbar-nav']//a"), 2);
			NavigationElements.FirstOrDefault(x => x.Text.Trim() == "Sign Up").Click();
		}

		public List<string> NavigationOptionsAvailable()
		{
			var Elements = containerElement.FindElements(By.XPath(".//ul[@class='nav navbar-nav']//a"), 2);
			return Elements.Select(x => x.Text.Trim()).ToList();
		}

		public bool SelectOption(string option)
		{
			var OptionLink = containerElement.FindElements(By.XPath(".//ul[@class='nav navbar-nav']//a"), 2).FirstOrDefault(x => x.GetValue().Trim() == option.Trim());
			if (OptionLink == null)
			{ return false; }
			OptionLink.Click();
			return true;
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
			return containerElement.FindElement(By.XPath(".//div[@class='modal-body']"), 2).Text;
		}
	}
}
