using System;
using UL.Automation.WebDriver.Classes;
using UL.Automation.WebDriver.Extensions;
using UL.Automation.Reporting.Functions;
using OpenQA.Selenium;
using UL.Automation.ReqnrollHelpers.Classes;
using System.Collections.ObjectModel;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	public static class StudioUtilites
	{
		public static bool SwitchToWindow(string popupTitle, bool switchToFirstFrame = true)
		{
			if (Context.GetFromContext("BaseWindow") == null)
			{
				Context.AddToContext("BaseWindow", SeleniumWebDriver.CurrentDriver.CurrentWindowHandle);
			}
			else
			{
				try
				{
					SeleniumWebDriver.CurrentDriver.SwitchTo().Window(Context.GetFromContext("BaseWindow").ToString());
				}
				catch (Exception)
				{
					ReadOnlyCollection<string> handlesTemp = SeleniumWebDriver.CurrentDriver.WindowHandles;
					string currentWindow = SeleniumWebDriver.CurrentDriver.CurrentWindowHandle;
					Context.AddToContext("BaseWindow", currentWindow);
				}

			}

			if (popupTitle == "BaseWindow")
			{
				SeleniumWebDriver.CurrentDriver.SwitchTo().Window(Context.GetFromContext("BaseWindow").ToString());
				return true;
			}

			ReadOnlyCollection<string> handles = SeleniumWebDriver.CurrentDriver.WindowHandles;


			int i = 0;
			while (i < 20)
			{
				foreach (string handle in handles)
				{
					if (SeleniumWebDriver.CurrentDriver.SwitchTo().Window(handle).Title.Contains(popupTitle))
					{
						try
						{
							SeleniumWebDriver.CurrentDriver.Manage().Window.Maximize();
						}
						catch (Exception ex)
						{
							Report.Error(ex.Message);
						}


						if (switchToFirstFrame && SeleniumWebDriver.CurrentDriver.FindElement(By.XPath("//body/iframe"), 2) != null)
						{
							SeleniumBrowser.WebBrowser.SwitchTo().Frame(SeleniumWebDriver.CurrentDriver.FindElement(By.XPath("//body/iframe"), 2));
						}

						Report.Success("Found window containing title: " + popupTitle);
						return true;
					}
				}

				Delay.Seconds(Delay.SpeedFactor * 1);
				i++;
			}

			SeleniumWebDriver.CurrentDriver.SwitchTo().Window(Context.GetFromContext("BaseWindow").ToString());
			return false;
		}

	}
}
