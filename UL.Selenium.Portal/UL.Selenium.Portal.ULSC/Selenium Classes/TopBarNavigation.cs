using System.Linq;
using NTTQA.Selenium.BaseClasses;
using NTTQA.Selenium.ExtensionMethods;
using NTTQA.Selenium.Reporting.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace UL.Selenium.Portal.ULSC.Selenium_Classes
{
	class TopBarNavigation : BaseObject
	{
		public const string BasePath = "//nav[@class='navbar topnavbar']";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public bool WercsLinkNavigationButtonDisplayed()
		{
			var els = this.containerElement.FindElements(By.XPath(".//ul[@class='nav navbar-nav']//a"), 2).ToList();
			return els.Any(x => x != null && x.Displayed);
		}

		public bool ClickWercsLinkNavigationButton()
		{
			var els = this.containerElement.FindElements(By.XPath(".//ul[@class='nav navbar-nav']//a"), 2).ToList();
			return els.First(x => x != null && x.Displayed).TryClick();
		}

		public string UserButtonText()
		{
			return this.containerElement.FindElement(By.XPath(".//li[@class='btn-group']/a"), 2)?.Text;
		}

		public bool ClickUserButton()
		{
			return this.containerElement.FindElement(By.XPath(".//li[starts-with(@class,'btn-group')]/a"), 2).TryClick();
		}

		public bool ResetDashboardIconDisplayed()
		{
			IWebElement el = this.containerElement.FindElement(By.XPath(".//a[@id='dashboard-widgets']"), 2);
			return el != null && el.Displayed;
		}

		public bool ClickResetDashboardIcon()
		{
			return this.containerElement.FindElement(By.XPath(".//a[@id='dashboard-widgets']"), 2).TryClick();
		}

		public bool ResetDashboardDropdownItemDisplayed()
		{
			IWebElement el = this.containerElement.FindElement(By.XPath(".//a[@id='dashboard-reset']"), 2);
			return el != null && el.Displayed;
		}

		public bool SignOutDropDownItemDisplayed()
		{
			IWebElement el = this.containerElement.FindElement(By.XPath(".//a[@id='logoutDialog']"), 2);
			return el != null && el.Displayed;
		}

		public bool ClickSignOut()
		{
			return this.containerElement.FindElement(By.XPath(".//a[@id='logoutDialog']"), 2).TryClick();
		}

		public bool ULLogoDisplayed()
		{
			IWebElement el = this.containerElement.FindElement(By.XPath(".//a[@class='navbar-brand']"), 2);
			return el != null && el.Displayed;
		}

		public bool ClickULLogo()
		{
			return this.containerElement.FindElement(By.XPath(".//a[@class='navbar-brand']"), 2).TryClick();
		}

		public bool TopLeftTitleExists(string expectedTitle)
		{
			System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> topLeftTitle = this.containerElement.FindElements(By.XPath(".//h3"));
			if (topLeftTitle.Count == 1)
			{
				return expectedTitle == topLeftTitle.First().Text.Trim();
			}
			Report.Error("Count of titles is not as expected. Found: " + topLeftTitle.Count);
			return false;
		}

	}
}
