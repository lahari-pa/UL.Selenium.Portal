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
    class ForwardProductRegistration : BaseObject
    {
        // Again a pretty poor/generic ID, but it's the best we have....
        public const string BasePath = "//div[@id='dataentry']";
        [FindsBy(How = How.XPath, Using = BasePath)]
        protected override IWebElement containerElement { get; set; }

        public List<string> ListOfRetailers()
        {
            var Els = containerElement.FindElements(By.XPath(".//div[contains(@class,'wizard-step-panel')]/div[@role='tabpanel']/div//input[@type='checkbox']/../span"), 2);
            if (Els.Count == 0)
                return null;
            return Els.Select(x => x.Text.Trim()).ToList();
        }

        public string HeaderShowing()
        {
            return containerElement.FindElement(By.XPath(".//h2"), 2).Text.Trim();
        }

        public List<string> SubHeadingsShowing()
        {
            return containerElement.FindElements(By.XPath(".//h3"), 2).Select(x => x.Text.Trim()).ToList();
        }

    }
}
