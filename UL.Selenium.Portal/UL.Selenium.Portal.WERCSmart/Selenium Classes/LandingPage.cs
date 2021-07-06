using System.Collections.Generic;
using System.Linq;
using UL.Automation.Selenium.BaseClasses;
using UL.Automation.Selenium.Classes;
using UL.Automation.Selenium.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	class LandingPage : SeleniumBaseObject
	{
		protected override By ContainerElementLocator => By.XPath("//div[@class='navbar navbar-default']");

		private IWebElement Login => this.containerElement.FindElement(By.XPath("//a[@id='loginButton']"), 1);

		private IWebElement SignUp => this.containerElement.FindElement(By.XPath("//ul[@class='nav navbar-nav']//a[contains(text(),'Sign Up')]"), 1);

		private IWebElement NavigationBar => this.containerElement.FindElement(By.XPath(".//ul[@class='nav navbar-nav']"), 1);

		public bool Click_Login()
		{
			IWebElement loginButton = this.Login ?? this.containerElement.FindElement(By.XPath(".//a[contains (@href, 'ssologin')]"), 2);
			return loginButton.TryClick() && new Login().WaitForContainerToBeVisible();
		}

		public bool Click_SignUp() => this.SignUp.TryClick();

		public List<string> NavigationOptionsAvailable()
		{
			IList<IWebElement> els = this.NavigationBar.FindElements(By.XPath(".//a"), 1);
			return els.Any() ? els.Select(x => x.Text.Trim()).ToList() : new List<string>();
		}

		public bool SelectOption(string option)
		{
			IWebElement optionLink = this.NavigationBar.FindElements(By.XPath(".//a"), 2).FirstOrDefault(x => x.GetValue().Trim() == option.Trim());
			return optionLink != null && optionLink.TryClick();
		}


	}

	class LandingPageFooter : SeleniumBaseObject
	{
		protected override By ContainerElementLocator => By.XPath("//footer/div[@class='container']");

		public bool ClickGetStartedNow() => this.containerElement.FindElement(By.XPath(".//a[text()='Get started now']"), 2).TryClick();

		public bool ClickTermsOfUse() => this.containerElement.FindElement(By.XPath(".//a[contains(text(),'Terms')]"), 2).TryClick();
	}

	class ManufacturersInfo : SeleniumBaseObject
	{
		protected override By ContainerElementLocator => By.XPath("//body[@class='manufacturers']");
	}

	class RetailersInfo : SeleniumBaseObject
	{
		protected override By ContainerElementLocator => By.XPath("//body[@class='retailers']");
	}

	class SubscriptionInfo : SeleniumBaseObject
	{
		protected override By ContainerElementLocator => By.XPath("//body[@class='subscription-options']");
	}


	class ServerErrorDialog : SeleniumBaseObject
	{
		protected override By ContainerElementLocator => By.XPath("//div[contains(@class, 'in')]//h4[@id='myModalLabel']/../..");

		public string Error_Text() => this.containerElement.FindElement(By.XPath(".//div[@class='modal-body']"), 2)?.Text;

		public bool ClickClose() => this.containerElement.FindElement(By.XPath(".//button[@class='btn btn-default']"), 2).TryClick();
	}
}
