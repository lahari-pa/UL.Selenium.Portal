using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTTQA_Automation_Classes.Base_Classes;
using NTTQA_Automation_Classes.Classes;
using NTTQA_Automation_Classes.Extension_Methods;
using NTTQA_Reporting_Module.Reporting.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using TestStack.White.UIItems.WindowItems;

namespace Wercs.Selenium.ULSC.Selenium_Classes
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
			var el = this.containerElement.FindElement(By.XPath(".//a[@id='dashboard-widgets']"), 2);
			return el != null && el.Displayed;
		}

		public bool ClickResetDashboardIcon()
		{
			return this.containerElement.FindElement(By.XPath(".//a[@id='dashboard-widgets']"), 2).TryClick();
		}

		public bool ResetDashboardDropdownItemDisplayed()
		{
			var el = this.containerElement.FindElement(By.XPath(".//a[@id='dashboard-reset']"), 2);
			return el != null && el.Displayed;
		}

		public bool SignOutDropDownItemDisplayed()
		{
			var el = this.containerElement.FindElement(By.XPath(".//a[@id='logoutDialog']"), 2);
			return el != null && el.Displayed;
		}

		public bool ClickSignOut()
		{
			return this.containerElement.FindElement(By.XPath(".//a[@id='logoutDialog']"), 2).TryClick();
		}

		public bool ULLogoDisplayed()
		{
			var el = this.containerElement.FindElement(By.XPath(".//a[@class='navbar-brand']"), 2);
			return el != null && el.Displayed;
		}

		public bool ClickULLogo()
		{
			return this.containerElement.FindElement(By.XPath(".//a[@class='navbar-brand']"), 2).TryClick();
		}

		public bool TopLeftTitleExists(string expectedTitle)
		{
			var topLeftTitle = this.containerElement.FindElements(By.XPath(".//h3"));
			if (topLeftTitle.Count == 1)
			{
				return expectedTitle == topLeftTitle.First().Text.Trim();
			}
			Report.Error("Count of titles is not as expected. Found: " + topLeftTitle.Count);
			return false;
		}

	}
}
