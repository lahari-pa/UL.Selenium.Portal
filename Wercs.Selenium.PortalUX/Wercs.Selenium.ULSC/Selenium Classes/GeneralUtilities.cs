using System;
using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;
using NTTQA_Automation_Classes.Classes;
using NTTQA_Automation_Classes.Extension_Methods;
using NTTQA_Reporting_Module.Reporting.Core;
using OpenQA.Selenium;

namespace Wercs.Selenium.ULSC.Selenium_Classes
{
	public static class GeneralUtilities
	{
		public static bool WaitForWidgetSpinner(int secondsToWait = 30)
		{
			Report.Info("Waiting for spinners to disappear");
			var spinner = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//div[@class='xbox-spinner']"), 2);
			var i = 0;
			try
			{
				while ((spinner != null && spinner.Displayed) && i < secondsToWait)
				{
					spinner = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//div[@class='xbox-spinner']"), 2);
					Delay.Seconds(1);
					i++;
				}
				return spinner == null || !spinner.Displayed;
			}
			catch (StaleElementReferenceException)
			{
				// occurs when the spinner el is no longer attached to the page after the initialisation- hence we are satisfied to return success
				return true;
			}
			catch (Exception ex)
			{
				Report.Error(ex);
				return false;
			}
		}
	}
}
