using System.Linq;
using UL.Automation.Selenium.BaseClasses;
using UL.Automation.Selenium.Classes;
using UL.Automation.Selenium.Extensions;
using UL.Automation.Reporting.Functions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	public class WERCSLinkDashboard : BaseObject
	{
		public const string BasePath = "//body";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public bool Wait_for_load(int secondsToWait = 60)
		{
			Delay.Seconds(2);
			Report.Info("Wait for dashboard page");
			ReadOnlyCollection<string> urls = SeleniumBrowser.WebBrowser.WindowHandles;
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
			foreach (string handle in urls)
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

		//public bool ClickMenuAndSubMenuOption(string menu, string submenu = "")
		//{
		//	if (submenu.ToLower() == "wercsmart")
		//	{
		//		submenu = "WERC";
		//	}
		//	var menuOptions = containerElement.FindElements(By.XPath(".//nav/ul/li/a/span"), 2);
		//	if (menuOptions.Count == 0)
		//	{
		//		Report.Error("No menu options were found");
		//		return false;
		//	}

		//	var matchingMenuOption =
		//		menuOptions.FirstOrDefault(x => x.GetValue().ToLower() == menu.ToLower());

		//	if (matchingMenuOption == null)
		//	{
		//		Report.Error("No matching menu option was found for: " + menu);
		//		return false;
		//	}


		//	if (submenu.Length == 0)
		//	{
		//		return true;
		//	}


		//	var submenuOptions =
		//		matchingMenuOption.FindElements(By.XPath("../../ul[contains(@class, 'subnav')]/li/a/span"), 2);

		//	var matchingSubMenuOption =
		//		submenuOptions.FirstOrDefault(x => x.GetValue().ToLower() == submenu.ToLower());

		//	if (matchingSubMenuOption == null)
		//	{
		//		Report.Error("No matching sub menu option was found for: " + submenu);
		//		return false;
		//	}

		//	var parentUL = matchingSubMenuOption.FindElement(By.XPath("../../ul"), 2);

		//	if (parentUL.GetAttribute("aria-expanded") == "false")
		//	{
		//		matchingMenuOption.Click();
		//		Delay.Seconds(1);
		//		submenuOptions = SeleniumBrowser.WebBrowser.FindElements(By.XPath("//ul[contains(@class, 'subnav')]/li/a/span"), 2);

		//		matchingSubMenuOption =
		//			submenuOptions.FirstOrDefault(x => x.GetValue().ToLower() == submenu.ToLower());

		//		if (matchingSubMenuOption == null)
		//		{
		//			Report.Error("No matching sub menu option was found for: " + submenu);
		//			return false;
		//		}

		//		parentUL = matchingSubMenuOption.FindElement(By.XPath("../../ul"), 2);
		//		if (parentUL.GetAttribute("aria-expanded") == "false")
		//		{
		//			menuOptions = SeleniumBrowser.WebBrowser.FindElements(By.XPath("//nav/ul/li/a/span"), 2);
		//			if (menuOptions.Count == 0)
		//			{
		//				Report.Error("No menu options were found");
		//				return false;
		//			}

		//			matchingMenuOption = menuOptions.FirstOrDefault(x => x.GetValue().ToLower() == menu.ToLower());
		//			matchingMenuOption.Click();
		//			Delay.Seconds(1);
		//		}


		//	}

		//	return matchingSubMenuOption.TryClick();
		//}

		//public bool ClickLink(string linkTitle)
		//{
		//	var allLinks = containerElement.FindElements(By.XPath(".//a"));

		//	var matchingLink = allLinks.FirstOrDefault(x => x.GetAttribute("title").ToLower() == linkTitle.ToLower());

		//	if (matchingLink == null)
		//	{
		//		Report.Error("No matching link was found for: " + linkTitle);
		//		return false;
		//	}

		//	return matchingLink.TryClick();
		//}

		//public bool ClickLeftLink(string linkTitle)
		//{
		//	var allLinks = containerElement.FindElements(By.XPath(".//ul[@class='nav']//a/span"));

		//	var matchingLink = allLinks.FirstOrDefault(x => x.GetValue().ToLower() == linkTitle.ToLower());

		//	if (matchingLink == null)
		//	{
		//		Report.Error("No matching link was found for: " + linkTitle);
		//		return false;
		//	}

		//	return matchingLink.TryClick();
		//}

		public bool ClickMainPageLink(string linkTitle)
		{
			ReadOnlyCollection<IWebElement> allLinks = this.containerElement.FindElements(By.XPath(".//a[not(ancestor::ul)]"));

			IWebElement matchingLink = allLinks.FirstOrDefault(x => x.GetAttribute("title").ToLower() == linkTitle.ToLower());

			if (matchingLink == null)
			{
				Report.Error("No matching link was found for: " + linkTitle);
				return false;
			}

			return matchingLink.TryClick();
		}

		public bool AnyServicesGrid()
		{
			IList<IWebElement> els = this.containerElement.FindElements(By.XPath("//div[starts-with(@class,'well well-sm brand')]"), 2);
			return els != null && els.Any();
		}

		public bool StatusCheckPageDisplayed(string title)
		{
			IWebElement el = this.containerElement.FindElement(By.XPath("//div[@id='status-check-page']//h2[contains(text(),'" + title + "')]"), 2);
			return el != null && el.Displayed;
		}

	}
}
