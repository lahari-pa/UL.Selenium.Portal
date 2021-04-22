using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using OpenQA.Selenium;
using UL.Automation.Selenium.BaseClasses;
using UL.Automation.Selenium.Classes;
using UL.Automation.Selenium.Extensions;

namespace UL.Selenium.Portal.RPS.Selenium_Classes
{
    class PrintDialog: SeleniumBaseObject
    {
        //Leaving for now due to issues with the print dialog stopping element clicking and element finding, complicated by the fact there are Shadow DOM elements.
        #region Page Objects
        protected override By ContainerElementLocator => By.XPath("//print-preview-app[@new-print-preview-layout_]");

        //private List<IWebElement> BottomMenuBottoms => FindElements(By.XPath("."), 1).ToList();

        private List<IWebElement> BottomMenuBottoms => this.containerElement.FindElements(By.XPath(""), 1).ToList();
        #endregion

        #region Methods

        public static IWebElement GetShadowRoot(IWebElement shadowHost)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)SeleniumBrowser.WebBrowser;
            return (IWebElement)js.ExecuteScript("return arguments[0].shadowRoot", shadowHost);
        }
        public static IWebElement ShadowHost = SeleniumBrowser.WebBrowser.FindElement(By.CssSelector("shadowHost_CSS"));

        public static IWebElement ShadowRoot = GetShadowRoot(ShadowHost);

        public static IWebElement ShadowTreeElement = ShadowRoot.FindElement(By.CssSelector("shadow_tree_element_css"));

        public static IWebElement GetShadowElement(IWebElement shadowHost, String cssOfShadowElement)
        {
            IWebElement shardowRoot = GetShadowRoot(shadowHost);
            return shardowRoot.FindElement(By.CssSelector(cssOfShadowElement));
        }

        public Process[] GettingWindows()
        {
            Process[] proccessfound = Process.GetProcesses();
            return proccessfound;
        }

        public void PrintTest()
        {
            IJavaScriptExecutor executor = ((IJavaScriptExecutor)SeleniumBrowser.WebBrowser);            
            executor.ExecuteScript("document.querySelector(\"print-preview-app\").shadowRoot.querySelector(\"print-preview-header\").shadowRoot.querySelector(\"paper-button.cancel-button\").click();");
        }



        #endregion
    }
}
