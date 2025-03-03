using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using UL.Automation.Reporting.Functions;
using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Extensions;
using UL.Selenium.Portal.WERCSmart.Classes;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes.ProductTemplate
{
	class SideNavbar : SeleniumBaseObject
	{
		#region Page Objects
		protected override By ContainerElementLocator => By.Id("navigation");
		private List<IWebElement> NavLinkList => this.FindElements(By.XPath(".//a[@class='nav-link']"), 1).ToList();
		#endregion

		#region Methods
		public bool NavLinkListExists()
		{
			Report.Info($"Attempting to confirm Navigation Link list exists.");
			return !this.NavLinkList.IsNullOrEmpty();
		}

		public int NavLinkListCount()
		{
			Report.Info($"Attempting to get the number of links in Navigation link list.");
			return this.NavLinkList.Count;
		}

		public bool NavLinkItemExists(string linkTitle)
		{
			Report.Info($"Attempting to confirm Navigation List item '{linkTitle}' exists.");
			return this.NavLinkList.Any(x => string.Equals(x.Text, linkTitle));
		}

		public bool NavLinkItemClick(string linkTitle)
		{
			Report.Info($"Attempting to click Navigation List item '{linkTitle}'.");
			return this.NavLinkList.Where(x => string.Equals(x.Text, linkTitle)).FirstOrDefault()?.TryClick() ?? false;
		}
		#endregion
	}
}
