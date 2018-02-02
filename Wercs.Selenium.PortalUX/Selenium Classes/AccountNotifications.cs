using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumUtilities;


namespace Wercs.Selenium.PortalUX.Selenium_Classes
{
    class AccountNotifications : BaseObject
    {
        public const string BasePath = "//div[@id='accountNotifications']";

        [FindsBy(How = How.XPath, Using = BasePath)]
        protected override IWebElement containerElement { get; set; }


        public void Click_Close()
        {
			this.containerElement.FindElement(By.XPath("//div[@class='modal-footer']/button"), 2).Click();
        }

        public string GetErrorText()
        {
            return this.containerElement.FindElement(By.XPath("//div[@class='modal-body']")).Text.Trim();
        }

        public string GetTitle()
        {
            return this.containerElement.FindElement(By.XPath("//*[@id='myModalLabel']")).Text.Trim();
        }
    }
}
