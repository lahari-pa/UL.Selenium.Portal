using OpenQA.Selenium;
using UL.Automation.Reporting.Functions;
using UL.Automation.Selenium.BaseClasses;
using UL.Automation.Selenium.Classes;
using UL.Automation.Selenium.Extensions;

namespace UL.Selenium.Portal.RPS.Selenium_Classes
{
    public class DemoViewer : SeleniumBaseObject
    {
        #region Page Objects
        protected override By ContainerElementLocator => By.XPath("//body[//input[@name='__RequestVerificationToken']]");


        private IWebElement LoginInputArea => this.containerElement.FindElement(By.XPath(".//fieldset[//legend[text()='Account Information']]"), 2);

        #endregion

        #region Methods

        public bool WaitForLoginInputAreaToLoad()
        {
            int x = 0;
            while(x<30)
            {
                IWebElement el = this.LoginInputArea;
                if(el!=null)
                {
                    Report.Info($"The Login Input area was loaded");
                    return true;
                }
                x++;
                Delay.Seconds(1);
            }

            Report.Info($"The Login input area was not loaded after 30 seconds");
            return false;
        }

        #endregion
    }
}