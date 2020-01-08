using System;
using UL.Automation.Selenium.Classes;
using UL.Automation.Selenium.Extensions;
using UL.Automation.Reporting.Functions;
using OpenQA.Selenium;

namespace UL.Selenium.Portal.ULSC.Selenium_Classes
{
	public static class GeneralUtilities
	{
		public static bool WaitForWidgetSpinner(int secondsToWait = 30)
		{
			Report.Info("Waiting for spinners to disappear");
			IWebElement spinner = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//div[@class='xbox-spinner']"), 2);
			int i = 0;
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
				Report.Error(ex.Message);
				return false;
			}
		}
	}
}
