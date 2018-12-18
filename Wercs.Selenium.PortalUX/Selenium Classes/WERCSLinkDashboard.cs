using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using ResourcePool;
using SafewareReporting;
using SeleniumUtilities;


namespace Wercs.Selenium.PortalUX.Selenium_Classes
{
	public class WERCSLinkDashboard : BaseObject
	{
		public const string BasePath = "//body";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public bool Wait_for_load(int secondsToWait = 60)
		{
			Delay.Seconds(2);
			Report.Info("Wait for dahsboard page");
			var urls = SeleniumBrowser.WebBrowser.WindowHandles;
			for (int i = 0; i < 30; i++)
			{
				urls = SeleniumBrowser.WebBrowser.WindowHandles;
				if (urls.Count > 1)
				{
					break;
				}

				Delay.Seconds(1);
			}

			if (urls.Count < 2)
			{
				return false;
			}

			//var current = SeleniumBrowser.WebBrowser.CurrentWindowHandle;

			foreach (var handle in urls)
			{
				if (SeleniumBrowser.WebBrowser.SwitchTo().Window(handle).Title.Contains("Dashboard"))
				{
					SeleniumBrowser.WebBrowser.Manage().Window.Maximize();
					Report.Success("Found window containing title: Dashboard");
					Delay.Seconds(3);
					Report.Screenshot();
					break;
				}
			}

			this.containerElement = SeleniumBrowser.WebBrowser.FindElement(By.XPath(BasePath));
			if (base.Wait_for_load(30))
			{
				return true;
			}

			return false;
		}

		public void Close()
		{
			SeleniumBrowser.WebBrowser.Close();
		}

		public bool ClickMenuAndSubMenuOption(string menu, string submenu = "")
		{
			var menuOptions = containerElement.FindElements(By.XPath(".//nav/ul/li/a"), 2);
			if (menuOptions.Count == 0)
			{
				Report.Error("No menu options were found");
				return false;
			}

			var matchingMenuOption =
				menuOptions.FirstOrDefault(x => x.GetAttribute("title").ToLower() == menu.ToLower());

			if (matchingMenuOption == null)
			{
				Report.Error("No matching menu option was found for: " + menu);
				return false;
			}

			if (!matchingMenuOption.TryClick())
			{
				Report.Error("Failed to click menu option: " + menu);
				return false;
			}

			if (submenu.Length == 0)
			{
				return true;
			}

			var submenuOptions =
				matchingMenuOption.FindElements(By.XPath("./following-sibling::ul[contains(@class, 'subnav')]/li/a"));

			var matchingSubMenuOption =
				submenuOptions.FirstOrDefault(x => x.GetAttribute("title").ToLower() == submenu.ToLower());

			if (matchingSubMenuOption == null)
			{
				Report.Error("No matching sub menu option was found for: " + submenu);
				return false;
			}

			return matchingSubMenuOption.TryClick();
		}

		public bool ClickLink(string linkTitle)
		{
			var allLinks = containerElement.FindElements(By.XPath(".//a"));

			var matchingLink = allLinks.FirstOrDefault(x => x.GetAttribute("title").ToLower() == linkTitle.ToLower());

			if (matchingLink == null)
			{
				Report.Error("No matching link was found for: " + linkTitle);
				return false;
			}

			return matchingLink.TryClick();
		}

		public bool ClickLeftLink(string linkTitle)
		{
			var allLinks = containerElement.FindElements(By.XPath(".//ul[@class='nav']//a"));

			var matchingLink = allLinks.FirstOrDefault(x => x.GetAttribute("title").ToLower() == linkTitle.ToLower());

				if (matchingLink == null)
			{
				Report.Error("No matching link was found for: " + linkTitle);
				return false;
			}

			return matchingLink.TryClick();
		}

		public bool ClickMainPageLink(string linkTitle)
		{
			var allLinks = containerElement.FindElements(By.XPath(".//a[not(ancestor::ul)]"));

			var matchingLink = allLinks.FirstOrDefault(x => x.GetAttribute("title").ToLower() == linkTitle.ToLower());

			if (matchingLink == null)
			{
				Report.Error("No matching link was found for: " + linkTitle);
				return false;
			}

			return matchingLink.TryClick();
		}
	}
}
