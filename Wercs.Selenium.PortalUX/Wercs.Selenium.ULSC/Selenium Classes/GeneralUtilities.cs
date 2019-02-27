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
			var spinner = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//div[@class='xbox-spinner']"), 2);
			var i = 0;
			while ((spinner != null && spinner.Displayed) && i < secondsToWait)
			{
				spinner = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//div[@class='xbox-spinner']"), 2);
				Delay.Seconds(1);
				i++;
			}
			return spinner == null || !spinner.Displayed;
		}
	}
}
