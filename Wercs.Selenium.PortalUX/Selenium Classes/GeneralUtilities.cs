using OpenQA.Selenium;
using ResourcePool;
using SeleniumUtilities;



namespace Wercs.Selenium.PortalUX.Selenium_Classes
{
	public static class GeneralUtilities
	{
		public static bool Wait_for_load_finish()
		{
			Delay.Seconds(Delay.SpeedFactor * 1);
			var bodyElement = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//body[contains(@class,'pace')]"), 2);
			if (bodyElement == null)
			{
				return true;
			}

			while (bodyElement.GetAttribute("class").Contains("pace-running"))
			{
				Delay.Seconds(Delay.SpeedFactor * 1);
				bodyElement = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//body[contains(@class,'pace')]"), 2);
			}

			return true;
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
			if (button.FindElement(By.XPath(".//i[contains(@class,'fa-refresh')]"), 2) == null)
			{
				return true;
			}

			int i = 0;
			while (button.FindElement(By.XPath(".//i[contains(@class,'fa-refresh']"), 2) != null && i < maxWaitTime)
			{
				Delay.Seconds(Delay.SpeedFactor * 1);
				i++;
			}

			return button.FindElement(By.XPath(".//i[contains(@class,'fa-refresh']"), 2) != null;
		}
	}
}
