using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using ResourcePool;
using SeleniumUtilities;


namespace Wercs.Selenium.PortalUX.Selenium_Classes
{
	class StudioTopMenu : BaseObject
	{
		public const string BasePath = "//div[@id='navmenu']";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public bool Wait_for_load(int secondsToWait=60)
		{
			try
			{
				SeleniumBrowser.ExitIFrame();
			}
			catch (Exception e)
			{
				//do nothing
			}

			return base.Wait_for_load(secondsToWait);
		}

		
		//My Wercs, UL Secure Connect, Authoring, Management, Distribution, System, Window, Help
		public bool ClickTopMenuItem(string item)
		{
			var navBar = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//div[@id='navmenu']"));
			navBar.ScrollElementIntoView();
			var ListOfOptions = containerElement.FindElements(By.XPath(".//li//a"));
			return ListOfOptions.FirstOrDefault(x => x.Text.Trim().ToLower() == item.Trim().ToLower()).TryClick();

		}

		public bool ClickSubMenu(string menuItem, string submenuItem)
		{
			var navBar = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//div[@id='navmenu']"));
			navBar.ScrollElementIntoView();
			var ListOfOptions = containerElement.FindElements(By.XPath(".//li//a"));
			var topMenuItem = ListOfOptions.FirstOrDefault(x => x.Text.Trim().ToLower() == menuItem.Trim().ToLower());
			if (topMenuItem.TryClick())
			{
				var ListOfSubMenuOptions = topMenuItem.FindElements(By.XPath(".//following-sibling::ul/li/a"));
				return ListOfSubMenuOptions.FirstOrDefault(x => x.Text.Trim().ToLower() == submenuItem.Trim().ToLower()).TryClick();
			}
			return false;
		}
		
	}
}
