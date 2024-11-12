using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using UL.Automation.Reporting.Functions;
using UL.Automation.WebDriver.Classes;
using UL.Automation.WebDriver.Extensions;

namespace UL.Selenium.Portal.RPS.Selenium_Classes
{
    public class Home : WidgetPage
    {
        #region Page Objects
        private List<IWebElement> DisplayedGraphs => FindElements(By.XPath(".//div[contains(@id,'-graph')][.//div[contains(@id, '-graph-content')]//*[name()='svg' and contains(@class,'highcharts-root')]|.//div[@class='graph-no-content'][not(@style='display=none;')]]"), 1).ToList();

        private List<IWebElement> InformationPanels => FindElements(By.XPath(".//div[@class='row']/div[@class='col-md-6']"), 1).ToList();

        private IWebElement UsernameInHeadingBanner => this.FindElement(By.XPath(@"//li[@class='btn-group']"), 2);
        private IWebElement ULLogoInHeadingBanner => this.FindElement(By.XPath(@"//img[@src='/Content/images/UL-logo.png']/.."), 2);
        private IWebElement HeadingItemWithNameInRPS => this.FindElement(By.XPath(@"//ul[@class='nav subheader fixed-top shadow-sm']//li"), 2);
        private IWebElement HeadingOption => this.FindElement(By.XPath(@"//ul[@class='nav navbar-nav ml-auto']"), 2);
        private IWebElement BodyEl => this.FindElement(By.XPath(@"//body[@class='  pace-done']"), 2);
        private IWebElement MainRPSPageTitle => this.FindElement(By.XPath(@"//head//title[text()='WERCSmart Retail Product Suite']"), 2);
        private IWebElement HomeLink => this.FindElement(By.XPath(@"//li[@id='home-link'][@class='active']"), 2);
        #endregion

        #region Methods   
        public bool ISeeMyUsernameInTheHeadingBanner(string username) => UsernameInHeadingBanner.FindElement(By.XPath(@"//button[text()='" + username + "']"), 2) != null;
        public bool ClickUsernameInHeadingBanner() => UsernameInHeadingBanner.TryClick();
        public bool ClickULLogoInTheHeaderArea() => ULLogoInHeadingBanner.TryClick();

        public bool ClickHeadingItemWithNameInRPS(string headingItem) => this.HeadingItemWithNameInRPS.FindElement(By.XPath(@"//a[text()='" + headingItem + "']"), 2).TryClick();
        public bool ISeeTheFollowingOption(string option) => this.HeadingOption.FindElement(By.XPath(@"//a[text()='" + option + "']"), 2) != null;
        public bool IClickAnywhere() => this.BodyEl.TryClick();
        public bool IAmOnTheMainRPSPage() => this.MainRPSPageTitle != null;
        public bool HomePageIsDisplayedInRPS() => this.HomeLink != null;
        
        public bool WaitUntilHomeXGraphsDisplayed(int graphNumber = 4, int waitForSeconds = 30)
        {

            int i = 0;
            while (i < waitForSeconds)
            {
                if (this.DisplayedGraphs.Count() == graphNumber)
                {
                    Report.Info("The number of displayed graphs matched the expected number");
                    return true;
                }
                i++;
                Delay.Seconds(1);
            }
            Report.Info($"The number of displayed graphs ({this.DisplayedGraphs.Count()}) did not match the expected number after: {i} seconds");
            return false;

        }

        public List<string> InformationPanelTitles() => this.InformationPanels.Select(x => x.FindElement(By.XPath(".//h1"), 1).Text).ToList();



        #endregion

        public bool SelectWebViewersDropDownOption(string dropDownOption)
        {
            IWebElement dropDownOptionEl = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath(".//div[@class='dropdown-menu show']//a[@class='dropdown-item '][contains(text(), '" + dropDownOption + "')]"), 1);
            return dropDownOptionEl.TryClick();
        }

        public bool PageNotFoundErrorDisplayed()
        {
            IWebElement errorPage = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath("//div//h1[text()='404 Not Found']"), 1);
            return errorPage.Displayed;
        }


    }
}

