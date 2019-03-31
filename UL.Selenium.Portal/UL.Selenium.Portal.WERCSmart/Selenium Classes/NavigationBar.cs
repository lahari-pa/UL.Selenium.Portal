using System.Collections.Generic;
using System.Linq;
using NTTQA_Automation_Classes.Base_Classes;
using NTTQA_Automation_Classes.Extension_Methods;
using NTTQA_Reporting_Module.Reporting.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	class NavigationBar : BaseObject
	{
		public const string BasePath = "//nav[@role='navigation']";
		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public bool NavigationIconShowing()
		{
			return this.containerElement.FindElement(By.XPath(".//div[contains(@class,'hamburger')]"), 2) != null;
		}

		public bool NavigationIconClick(bool expand = true)
		{
			try
			{
				var element = this.containerElement.FindElement(By.XPath(".//div[contains(@class,'hamburger')]"), 2);
				var elementClosed = !element.GetAttribute("class").Contains("closed");
				if (elementClosed && expand || !elementClosed && !expand)
				{
					return element.TryClick();
				}
				return true;
			}
			catch
			{
				return false;
			}
		}

		public bool NavigationMenuExpanded()
		{
			var element = this.containerElement.FindElement(By.XPath(".//div[contains(@class,'hamburger')]"), 2);
			var elementClosed = element.GetAttribute("class").Contains("closed");
			return elementClosed;
		}

		public bool ItemShowingInNavigationPanel(string item, bool iconOnly = false)
		{
			var sideIcons = this.containerElement.FindElements(By.XPath(".//div[@class='sidemenu-icons']//a"), 2);
			var iconPresent = sideIcons.FirstOrDefault(x => x.GetAttribute("title").Contains(item));
			if (iconPresent == null || !iconPresent.Displayed)
			{
				return false;
			}


			// Icon is present!

			if (this.containerElement.FindElement(By.XPath(".//div[contains(@class,'sidemenu-links')]"), 2).GetAttribute("class").Contains("closed"))
			{
				// Navigation Panel is not expanded!
				return iconOnly;
			}

			var expandedIcons = this.containerElement.FindElements(By.XPath(".//div[contains(@class,'sidemenu-links')]//a"), 2);

			var expandedOption = expandedIcons.FirstOrDefault(x => x.Text.Contains(item));

			return (expandedOption != null && expandedOption.Displayed);
		}

		public bool AllNavigationLabelsAreHidden()
		{
			var allItems = new List<string> {
				"Home",
				"Register New Product",
				"My Messages",
				"Retail Partners",
				"Supplier Reports",
				"UL Solution Center",
				"Support"
			};
			var expandedLabels = this.containerElement.FindElement(By.XPath(".//div[contains(@class,'sidemenu-links') and not(contains(@class,'closed'))]"), 2);
			return expandedLabels == null;
		}

		public bool IconTextDisplayedOnHover(string icon, string item)
		{
			var sideIcons = this.containerElement.FindElements(By.XPath(".//div[@class='sidemenu-icons']//a/i"), 2);
			if (sideIcons == null)
			{
				Report.Failure("Unable to find navigation icon bar");
				return false;
			}
			// Fetch the icon with class matching the expected logo (eg. fa fa-home)
			var iconEl = sideIcons.FirstOrDefault(x => x.GetAttribute("class").Contains(icon.ToLower()));
			if (iconEl == null)
			{
				Report.Failure("Unable to find navigation icon: " + icon);
				return false;
			}
			//The tooltip displays the title attribute of the a element. Compare this to the expected outcome in the table
			var iconTitle = iconEl.FindElement(By.XPath("./parent::a"), 2)?.GetAttribute("title");
			return iconTitle?.Contains(item) ?? false;
		}

		//Home, Register, Retail Partners, Supplier Reports, Solution Center, Shopping Cart, Support
		public bool Click_Icon(string destination)
		{
			var allIcons = this.containerElement.FindElements(By.XPath(".//div[@class='sidemenu-icons']//a"), 2);
			var icon = allIcons.FirstOrDefault(x => x.GetAttribute("title").Trim().Contains(destination));
			if (icon == null)
			{
				Report.Info("Icons found: " + string.Join(",", allIcons.ToList().Select(x => x.GetAttribute("title").Trim())));
				return false;
			}
			return icon.FindElement(By.XPath(".."), 2).TryClick();
		}

		public bool Click_ExpandedMenuLink(string destination)
		{
			var allLinks = this.containerElement.FindElements(By.XPath(".//div[contains(@class,'sidemenu-link')]//a[not(contains(@class,'spacer'))]"), 2);
			if (allLinks.Count == 0)
			{
				Report.Info("No links were found in the expanded navigation menu");
				return false;
			}
			var icon = allLinks.FirstOrDefault(x => x.Text.Trim().Contains(destination));
			if (icon == null)
			{
				Report.Info("Navigation menu link found: " + string.Join(",", allLinks.ToList().Select(x => x.Text.Trim())));
				return false;
			}
			return icon.TryClick();
		}
	}
}
