using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UL.Automation.Reporting.Functions;
using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Extensions;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	public class StudioTopHeader : SeleniumBaseObject
	{
		protected override By ContainerElementLocator => By.Id("navmenu");

		private string _topMenuString;

		private IWebElement TopLevelMenu => ContainerElement.FindElement(By.XPath($"./ul/li/a[contains(text(),'{_topMenuString}')]"), 2);
		private string _subMenuString;
		private IWebElement SubMenuItem => TopLevelMenu.FindElement(By.XPath($"./..//li/a[contains(text(),'{_subMenuString}')]"), 2);
		private List<IWebElement> TriMenuItem => SubMenuItem.FindElements(By.XPath("./../ul/li/a"), 2).ToList();

		public bool ClickMenu(string menuString)
		{
			_topMenuString = menuString;
			if (TopLevelMenu == null)
			{
				Report.Error($"Could not find a menu called {menuString}!");
				return false;
			}
			IWebElement menuBox = TopLevelMenu.FindElement(By.XPath("./ul"), 1);
			if (!(menuBox == null) && menuBox.GetAttribute("style").Contains("display: block;"))
			{
				Report.Success($"The menu was already open.");
				return true;
			}
			TopLevelMenu.Hover();
			return TopLevelMenu.TryClick() || TopLevelMenu.TryClick();
		}

		public bool ClickSubMenu(string menuString, string subMenuString)
		{
			_topMenuString = menuString;
			_subMenuString = subMenuString;
			if (SubMenuItem == null)
			{
				Report.Error($"Could not find the sub menu item '{subMenuString}'");
				return false;
			}
			bool menuOpen = true;
			if (!SubMenuItem.VisibleInViewport())
			{
				Report.Info($"the {menuString} Menu was not open. Now opening.");
				menuOpen = ClickMenu(menuString);
			}
			if (menuOpen)
			{
				return SubMenuItem.TryClick();
			}
			else
			{
				Report.Error($"Could not open main menu: {menuString}");
				return false;
			}
		}

		public bool ClickTriMenuItem(string menu, string subMenu, string item)
		{
			_topMenuString = menu;
			_subMenuString = subMenu;
			if (SubMenuItem == null)
			{
				Report.Error($"Could not find the sub menu '{subMenu}'");
				return false;
			}
			SubMenuItem.Hover();
			if (TriMenuItem.Count == 0)
			{
				Report.Info($"There were no items under {subMenu}");
				return false;
			}
			foreach (var MenuItem in TriMenuItem)
			{
				if (MenuItem.Text.Contains(item))
				{
					return MenuItem.TryClick();
				}
			}
			Report.Info($"There was no menu item {item} in the submenu {subMenu}, under {menu}");
			return false;
		}

		public bool ContainsTriMenuItem(string menu, string subMenu, string item)
		{
			_topMenuString = menu;
			_subMenuString = subMenu;
			if (SubMenuItem == null)
			{
				Report.Error($"Could not find the sub menu item '{subMenu}'");
				return false;
			}
			SubMenuItem.Hover();
			if (TriMenuItem.Count == 0)
			{
				Report.Info($"There were no items under {subMenu}");
				return false;
			}
			foreach (var MenuItem in TriMenuItem)
			{
				if (MenuItem.Text.Contains(item))
				{
					return true;
				}
			}
			Report.Info($"There was no menu item {item} in the submenu {subMenu}, under {menu}");
			return false;
		}

		public bool ContainsMenuItem(string menu, string subMenu)
		{
			_topMenuString = menu;
			_subMenuString = subMenu;
			if (SubMenuItem == null)
			{
				Report.Info($"Could not find the sub menu item '{subMenu}'");
				return false;
			}
			return true;
		}
	}
}
