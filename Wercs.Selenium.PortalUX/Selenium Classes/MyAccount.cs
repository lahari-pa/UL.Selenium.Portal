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
    class MyAccount : BaseObject
    {
        public const string BasePath = "//div[@id='myAccountContainer']";
        [FindsBy(How = How.XPath, Using = BasePath)]
        protected override IWebElement containerElement { get; set; }

        public string HeaderShowing()
        {
            return containerElement.FindElement(By.XPath("../div[contains(@class,'page-inner-header')]/h2"), 2).Text;
        }

        public List<string> Subheadings()
        {
            return containerElement.FindElements(By.XPath(".//h2"), 2).Select(x => x.GetValue().Trim()).ToList();
        }

        public string GetCompanyName()
        {
            return containerElement.FindElement(By.XPath("//div[@class='col-sm-3 basic-info']/h3"), 2).Text;
        }
    }
}
