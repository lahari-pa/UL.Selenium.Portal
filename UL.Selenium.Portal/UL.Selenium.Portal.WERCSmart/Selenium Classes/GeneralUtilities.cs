using System;
using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;
using NTTQA.Selenium.Classes;
using NTTQA.Selenium.ExtensionMethods;
using NTTQA.Selenium.Reporting.Core;
using OpenQA.Selenium;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	public static class GeneralUtilities
	{
		public static bool StudioWaitForSpinner()
		{
			try
			{
				var spinner = SeleniumBrowser.WebBrowser.FindElements(By.XPath(".//img[@class='spinner-overlay']"), 2);
				while (spinner.Any(x => x.Displayed))
				{
					Delay.Seconds(Delay.SpeedFactor * 1);
					spinner = SeleniumBrowser.WebBrowser.FindElements(By.XPath(".//img[@class='spinner-overlay']"), 2);
				}

				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public static bool StudioWaitForSpinner(int maxSecondsToWait)
		{
			try
			{
				for (int i = 0; i < maxSecondsToWait; i++)
				{
					var spinner = SeleniumBrowser.WebBrowser.FindElements(By.XPath(".//img[@class='spinner-overlay']"), 2);
					if (!spinner.Any(x => x.Displayed))
					{
						return true;
					}
					Delay.Seconds(Delay.SpeedFactor * 1);
				}

				return false;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public static bool Wait_for_load_finish()
		{
			Delay.Seconds(2);
			if (SeleniumBrowser.WebBrowser.FindElement(By.XPath("//body[contains(@class,'pace')]"), 2) == null)
			{
				return true;
			}

			while (SeleniumBrowser.WebBrowser.FindElement(By.XPath("//body[contains(@class,'pace')]"), 2).GetAttribute("class").Contains("pace-running"))
			{
				Delay.Seconds(Delay.SpeedFactor * 1);
			}

			return true;
		}

		public static bool Loading_Active()
		{
			return SeleniumBrowser.WebBrowser.FindElement(By.XPath("//body[contains(@class,'pace')]")) != null;
		}

		public static void ScrollToBottomOfPage()
		{
			((IJavaScriptExecutor)SeleniumBrowser.WebBrowser).ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
		}

		public static void ScrollToTopOfPage()
		{
			((IJavaScriptExecutor)SeleniumBrowser.WebBrowser).ExecuteScript("window.scrollTo(0, 0)");
		}

		public static bool WaitForRefreshToDisappear(IWebElement button, int maxWaitTime = 60)
		{
			try
			{
				if (button.FindElement(By.XPath(".//i[contains(@class,'fa-refresh')]"), 2) == null)
				{
					return true;
				}

				int i = 0;
				while (button.FindElement(By.XPath(".//i[contains(@class,'fa-refresh')]"), 2) != null && i < maxWaitTime)
				{
					Delay.Seconds(Delay.SpeedFactor * 1);
					Report.Info("Waiting: " + i.ToString());
					i++;
				}

				return button.FindElement(By.XPath(".//i[contains(@class,'fa-refresh']"), 2) == null;
			}
			catch (Exception e)
			{
				if (button.IsElementStale())
				{
					Report.Info("Element is stale");
				}
				return true;
			}
		}

		public static bool WaitForSpinnerToDisappear(IWebElement button, int waitMax = 60)
		{
			var spinner = button.FindElement(By.XPath(".//i[contains(@class,'fa fa-spinner')]"), 2);
			if (spinner == null || !spinner.Displayed)
			{
				return true;
			}
			int i = 0;
			while ((spinner != null && spinner.Displayed) && i < waitMax)
			{
				spinner = button.FindElement(By.XPath(".//i[contains(@class,'fa fa-spinner')]"), 2);
				Delay.Seconds(1);
				i++;
			}
			return spinner == null || !spinner.Displayed;
		}

		public static bool CloseAjaxPopup()
		{
			return SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//button[@data-dismiss = 'modal' and text()='Close']"), 2).TryClick();
		}

		public static bool AjaxPopupExists()
		{
			return SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//p[contains(text(),'There was an error processing your request. Please try again.')]"), 2) != null;
		}

		public static List<string> CvsUpcs()
		{
			var web = new HtmlWeb();
			var document = web.Load(@"https://www.upcitemdb.com/info-cvs");
			var nodes = document.DocumentNode.SelectNodes(@"//a[@name='upclist']//following-sibling::div//ul//li//div[@class='rImage']/a");
			var upcValues = nodes.Select(x => x.InnerText).ToList();
			return upcValues;
		}

		public static bool TrySelect(IWebElement el, string optionValue, bool ignoreWhitespace = false)
		{
			try
			{
				if (el.TagName != "select")
				{
					return false;
				}
				if (!ignoreWhitespace)
				{
					el.Select(optionValue);
					return el.SelectedOption() == optionValue;
				}
				var options = el.FindElements(By.XPath("./option"), 1);
				foreach (var thisOptionEl in options)
				{
					var thisOptionValue = thisOptionEl.GetValue();
					if (thisOptionValue.Replace(" ", string.Empty) != optionValue.Replace(" ", string.Empty))
					{
						continue;
					}
					el.Select(thisOptionValue);
					return el.SelectedOption() == thisOptionValue;
				}
				return false;
			}
			catch (Exception)
			{
				return false;
			}
		}


	}
}
