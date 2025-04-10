using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using UL.Automation.Reporting.Functions;
using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Extensions;
using UL.Selenium.Portal.WERCSmart.Classes;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes.SpecflowRewrite
{
	class SideMenu : SeleniumBaseObject
	{
		#region Class Objects
		protected override By ContainerElementLocator => By.Id("SideMenu");
		private IWebElement HamburgerIcon => this.FindElement(By.XPath(".//div[contains(@class,'hamburger-to-close')]"), 1);
		public List<IconLink> IconLinksList => [.. this.FindElements(By.XPath(".//div[@class='sidemenu-icons']//a[@title]"), 1).Select(x => new IconLink(x))];
		public IconLink IconLinkByTitle(string titleLabel) => this.IconLinksList.FirstOrDefault(x => x.Title.Equals(titleLabel, System.StringComparison.Ordinal));
		public List<LabeledLink> LabeledLinksList => [.. this.FindElements(By.XPath(".//div[contains(@class,'sidemenu-links')]//a[text()]"), 1).Select(x => new LabeledLink(x))];
		public LabeledLink LabeledLinkByTitle(string titleLabel) => this.LabeledLinksList.FirstOrDefault(x => x.Title.Equals(titleLabel, System.StringComparison.Ordinal));
		#endregion

		#region Class Methods
		#region Hamburger Icon Methods
		public bool HamburgerIconExists()
		{
			Report.Info($"Attempting to confirm Hamburger Icon exists.");
			return this.HamburgerIcon != null;
		}

		public bool HamburgerIconClick()
		{
			Report.Info($"Attempting to click Hsmburger Icon.");
			return this.HamburgerIcon.TryClick();
		}

		public bool SidebarMenuExpanded()
		{
			Report.Info($"Attempting to confirm Sidebar Menu is expanded.");
			return this.HamburgerIcon.GetAttribute("class").Contains("closed");
		}
		#endregion
		#region Icon Links List Methods
		public bool IconLinksListExists()
		{
			Report.Info($"Attempting to confirm Icon Links list exists.");
			return !this.IconLinksList.IsNullOrEmpty();
		}

		public List<string> IconLinksTitlesList()
		{
			Report.Info($"Attempting to get Icon Links titles list.");
			return [.. this.IconLinksList.Select(x => x.Title)];
		}

		public bool IconLinkByTitleExists(string titleLabel)
		{
			Report.Info($"Attempting to confirm '{titleLabel}' Icon Link exists.");
			return this.IconLinkByTitle(titleLabel) != null;
		}
		#endregion
		#region Labeled Links List Methods
		public bool LabeledLinksListExists()
		{
			Report.Info($"Attempting to confirm Labeled Links list exists.");
			return !this.LabeledLinksList.IsNullOrEmpty();
		}

		public List<string> LabeledLinksTitlesList()
		{
			Report.Info($"Attempting to get Labeled Links Titles list.");
			return [.. this.LabeledLinksList.Select(x => x.Title)];
		}

		public bool LabeledLinkByTitleExists(string titleLabel)
		{
			Report.Info($"Attempting to confirm '{titleLabel}' Labeled Link exists.");
			return this.LabeledLinkByTitle(titleLabel) != null;
		}
		#endregion
		#endregion
	}

	class IconLink(IWebElement containerElement)
	{
		#region Class Objects
		private IWebElement ContainerElement = containerElement;
		public string Title => this.ContainerElement.FindElement(By.XPath(".//span[@class='sr-only']"), 1)?.Text.Trim();
		private string AlertsCountString => this.ContainerElement.FindElement(By.XPath(".//i[contains(@class,'sidemenu-icon')]"), 1)?.GetAttribute("data-content").Trim();
		#endregion

		#region Class Methods
		public bool Click()
		{
			Report.Info($"Attempting to click '{this.Title}' Icon link.");
			return this.ContainerElement.TryClick();
		}

		public bool AlertsExist()
		{
			Report.Info($"Attempting to confirm '{this.Title}' Icon link alerts exist.");
			return !this.AlertsCountString.IsNullOrEmpty();
		}

		public string AlertsCount()
		{
			Report.Info($"Attempting to get '{this.Title}' Icon link alerts count.");
			return this.AlertsCountString;
		}
		#endregion
	}

	class LabeledLink(IWebElement containerElement)
	{
		#region Class Objects
		private IWebElement ContainerElement = containerElement;
		public string Title => this.ContainerElement.Text.Trim();
		public string AlertsCountString => this.ContainerElement.FindElement(By.XPath(".//span[@class='badge']"), 1)?.Text.Trim();
		#endregion

		#region Class Methods
		public bool Click()
		{
			Report.Info($"Attempting to click '{this.Title}' Labeled link.");
			return this.ContainerElement.TryClick();
		}

		public bool AlertsExist()
		{
			Report.Info($"Attempting to confirm '{this.Title}' Labeled link alerts exist.");
			return !this.AlertsCountString.IsNullOrEmpty();
		}

		public string AlertsCount()
		{
			Report.Info($"Attempting to get '{this.Title}' Labeled link alerts count.");
			return this.AlertsCountString;
		}
		#endregion
	}
}
