using System;
using UL.Automation.Selenium.Classes;
using UL.Automation.Selenium.Extensions;
using UL.Automation.Reporting.Functions;
using OpenQA.Selenium;
using UL.Automation.Reporting.SpecFlow.Classes;
using System.Collections.ObjectModel;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	public static class StudioUtilites
	{
		public static bool SwitchToWindow(string popupTitle, bool switchToFirstFrame = true)
		{
			if (Context.GetFromContext("BaseWindow") == null)
			{
				Context.AddToContext("BaseWindow", SeleniumBrowser.WebBrowser.CurrentWindowHandle);
			}
			else
			{
				try
				{
					SeleniumBrowser.WebBrowser.SwitchTo().Window(Context.GetFromContext("BaseWindow").ToString());
				}
				catch (Exception)
				{
					ReadOnlyCollection<string> handlesTemp = SeleniumBrowser.WebBrowser.WindowHandles;
					string currentWindow = SeleniumBrowser.WebBrowser.CurrentWindowHandle;
					Context.AddToContext("BaseWindow", currentWindow);
				}

			}

			if (popupTitle == "BaseWindow")
			{
				SeleniumBrowser.WebBrowser.SwitchTo().Window(Context.GetFromContext("BaseWindow").ToString());
				return true;
			}

			ReadOnlyCollection<string> handles = SeleniumBrowser.WebBrowser.WindowHandles;


			int i = 0;
			while (i < 20)
			{
				foreach (string handle in handles)
				{
					if (SeleniumBrowser.WebBrowser.SwitchTo().Window(handle).Title.Contains(popupTitle))
					{
						try
						{
							SeleniumBrowser.WebBrowser.Manage().Window.Maximize();
						}
						catch (Exception ex)
						{
							Report.Error(ex.Message);
						}


						if (switchToFirstFrame && SeleniumBrowser.WebBrowser.FindElement(By.XPath("//body/iframe"), 2) != null)
						{
							SeleniumBrowser.WebBrowser.SwitchTo().Frame(SeleniumBrowser.WebBrowser.FindElement(By.XPath("//body/iframe"), 2));
						}

						Report.Success("Found window containing title: " + popupTitle);
						return true;
					}
				}

				Delay.Seconds(Delay.SpeedFactor * 1);
				i++;
			}

			SeleniumBrowser.WebBrowser.SwitchTo().Window(Context.GetFromContext("BaseWindow").ToString());
			return false;
		}

	}
}
