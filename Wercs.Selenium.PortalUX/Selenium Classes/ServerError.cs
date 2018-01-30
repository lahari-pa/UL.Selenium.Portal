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
    class ServerError : BaseObject
    {
        public const string BasePath = "//h4[@id='myModalLabel']";

        [FindsBy(How = How.XPath, Using = BasePath)]
        protected override IWebElement containerElement { get; set; }


        public void Click_Close()
        {
            containerElement.FindElement(By.XPath("..//button"), 2).Click();
        }

        public string GetErrorMessage()
        {
            var ErrorMessageContainer = containerElement.FindElement(By.XPath("../..//div[@class='modal-body']"), 2);
            if (ErrorMessageContainer != null)
            {
                return ErrorMessageContainer.GetValue();
            }
            else
            {
                return "";
            }

        }
    }
}
