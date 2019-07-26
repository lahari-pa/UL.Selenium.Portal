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
				IList<IWebElement> spinner = SeleniumBrowser.WebBrowser.FindElements(By.XPath(".//img[@class='spinner-overlay']"), 2);
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
					IList<IWebElement> spinner = SeleniumBrowser.WebBrowser.FindElements(By.XPath(".//img[@class='spinner-overlay']"), 2);
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
			// wait up to 2 seconds for the loading bar to become visible
			SeleniumBrowser.WebBrowser.WaitUntilElementVisible(By.XPath("//body[contains(@class,'pace-running')]"), 2);
			// waits up to 30 seconds for the loading bar to then become invisible
			return SeleniumBrowser.WebBrowser.WaitUntilElementInvisible(By.XPath("//body[contains(@class,'pace-running')]"), 30);
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
				return button.WaitUntilElementInvisible(By.XPath(".//i[contains(@class,'fa-refresh')]"), maxWaitTime);
			}
			catch (Exception)
			{
				return false;
			}
		}

		public static bool WaitForSpinnerToDisappear(IWebElement button, int waitMax = 60)
		{
			try
			{
				return button.WaitUntilElementInvisible(By.XPath(".//i[contains(@class,'fa fa-spinner')]"), waitMax);
			}
			catch (Exception)
			{
				return false;
			}
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
			HtmlDocument document = web.Load(@"https://www.upcitemdb.com/info-cvs");
			HtmlNodeCollection nodes = document.DocumentNode.SelectNodes(@"//a[@name='upclist']//following-sibling::div//ul//li//div[@class='rImage']/a");
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
				IList<IWebElement> options = el.FindElements(By.XPath("./option"), 1);
				foreach (IWebElement thisOptionEl in options)
				{
					string thisOptionValue = thisOptionEl.GetValue();
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
