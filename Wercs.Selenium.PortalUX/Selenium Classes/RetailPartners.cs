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
    class RetailPartners : BaseObject
    {
        public const string BasePath = "//div[@id='retailPartners']";
        [FindsBy(How = How.XPath, Using = BasePath)]
        protected override IWebElement containerElement { get; set; }

        public string HeaderShowing()
        {
            return containerElement.FindElement(By.XPath("..//h2"), 2).Text;
        }

        public List<string> SubHeadingsShowing()
        {
            return containerElement.FindElements(By.XPath(".//h3"), 2).Select(x => x.Text.Trim()).ToList();
        }
    }
}
