using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumUtilities;



namespace Wercs.Selenium.PortalUX.Selenium_Classes
{
    public static class GeneralUtilities
    {
        public static bool Wait_for_load_finish()
        {
            Delay.Seconds(Delay.SpeedFactor * 1);
            var bodyElement = GlobalParameters.Browser.WebBrowser.FindElement(By.XPath("//body[contains(@class,'pace')]"), 2);
            if (bodyElement == null)
                return true;
            while(bodyElement.GetAttribute("class").Contains("pace-running"))
            {
               Delay.Seconds(Delay.SpeedFactor*1);
               bodyElement = GlobalParameters.Browser.WebBrowser.FindElement(By.XPath("//body[contains(@class,'pace')]"), 2);
            }

            return true;
        }

       

        public static void ScrollToBottomOfPage()
        {
            ((IJavaScriptExecutor)GlobalParameters.Browser.WebBrowser).ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
        }

        public static void ScrollToTopOfPage()
        {
            ((IJavaScriptExecutor)GlobalParameters.Browser.WebBrowser).ExecuteScript("window.scrollTo(0, 0)");
        }
    }
}
