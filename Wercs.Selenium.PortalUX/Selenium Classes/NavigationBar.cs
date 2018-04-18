using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SafewareReporting;
using SeleniumUtilities;

namespace Wercs.Selenium.PortalUX.Selenium_Classes
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
					element.Click();
				}

				return true;
			}
			catch
			{
				return false;
			}
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
			icon.FindElement(By.XPath(".."), 2).Click();
			GeneralUtilities.Wait_for_load_finish();
			return true;
		}
	}

}
