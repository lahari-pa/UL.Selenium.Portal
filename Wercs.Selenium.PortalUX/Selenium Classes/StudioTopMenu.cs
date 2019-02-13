using System;
using System.Collections.Generic;
using System.Linq;
using NTTQA_Automation_Classes.Base_Classes;
using NTTQA_Automation_Classes.Classes;
using NTTQA_Automation_Classes.Extension_Methods;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;


namespace Wercs.Selenium.PortalUX.Selenium_Classes
{
	public class StudioTopMenu : BaseObject
	{
		public const string BasePath = "//div[@id='navmenu']";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public bool Wait_for_load(int secondsToWait = 30)
		{
			//get the window
			StudioUtilites.SwitchToWindow("Wercs Studio");
			SeleniumBrowser.WebBrowser.SwitchTo().DefaultContent();
			this.containerElement = SeleniumBrowser.WebBrowser.FindElement(By.XPath(BasePath));
			return base.Wait_for_load(30);
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
