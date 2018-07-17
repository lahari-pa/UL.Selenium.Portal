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
	class StudioSHAManager : BaseObject
	{
		public const string BasePath = "//iframe[@id='Widget1FRAME']";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public bool WaitForProductList(int secondsToWait)
		{
			if (!SeleniumBrowser.SwitchToIFrame("Widget1FRAME"))
			{
				SeleniumBrowser.ExitIFrame();
				if (!SeleniumBrowser.SwitchToIFrame("Widget1FRAME"))
				{
					Report.Error("Could nto switch to iframe");
				}
			}
			for (int i = 0; i < secondsToWait; i++)
			{
				try
				{
					if (SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//table[@id='list']")) != null)
					{
						return true;
					}
				}
				catch (Exception e)
				{
					//do nothing
				}
				Delay.Seconds(1);
				i++;
			}

			return false;
		}

		public bool ClickTopMenuItem(string option)
		{
			try
			{
				var ListOfTopMenuOptions =
					SeleniumBrowser.WebBrowser.FindElements(By.XPath(".//div[@id='ddtopmenubar']/ul/li/a"));
				IWebElement menuOption = ListOfTopMenuOptions.FirstOrDefault(x => x.Text.ToLower() == option.ToLower());
				return menuOption.TryClick();
			}
			catch (Exception e)
			{
				return false;
			}

			return false;
		}

		public bool ClickActionsMenuOption(string option)
		{
			try
			{
				if (!SeleniumBrowser.SwitchToIFrame("Widget1FRAME"))
				{
					SeleniumBrowser.ExitIFrame();
					if (!SeleniumBrowser.SwitchToIFrame("Widget1FRAME"))
					{
						Report.Info("Couuld not switch to iframe");
						return false;
					}
				}
				var ListOfTopMenuOptions =
					SeleniumBrowser.WebBrowser.FindElements(By.XPath(".//ul[@id='ddsubmenu1']/li/a"));
				IWebElement menuOption = ListOfTopMenuOptions.FirstOrDefault(x => x.GetValue(true).ToLower() == option.ToLower());
				Report.Info("Found options: " + string.Join(",", ListOfTopMenuOptions.Select(x => x.GetValue(true)).ToList()));
				if (menuOption != null)
				{
					return menuOption.TryClick(Click_Functionality.ClickType.JavaScript);
				}
				else
				{
					Report.Info("Matching menu option has not been found");
					return false;
				}
				
			}
			catch (Exception e)
			{
				Report.Info(e.Message);
				return false;
			}

		}
	}
}
