using System.Collections.Generic;
using System.Linq;
using Castle.Core.Internal;
using OpenQA.Selenium;
using UL.Automation.Reporting.Functions;
using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Extensions;
using UL.Selenium.Portal.RPS.Classes;

namespace UL.Selenium.Portal.RPS.Selenium_Classes
{
    class NavBar : SeleniumBaseObject
    {
        #region Page Objects
        protected override By ContainerElementLocator => By.XPath("//div[@class='pull-left clearfix']//ul[contains(@class,'nav navbar-nav')]");

        //Tab Links
        private IWebElement HomeLink => FindElement(By.Id("home-link"), 1);

        private IWebElement DashboardLink => FindElement(By.Id("dashboard-link"), 1);

        private IWebElement RecentActivitiesLink => FindElement(By.Id("statuscheck-link"), 1);

        private IWebElement WebViewersLink => FindElement(By.Id("webviewer-link"), 1);

        private IWebElement ProductLookupsLink => FindElement(By.Id("productlookup-link"), 1);

        private IWebElement HelpAndSupportLink => FindElement(By.Id("freshdesk-link"), 1);

        private IWebElement ItemSyncLink => FindElement(By.Id("ItemSyncMenu"), 1);

        private IWebElement DrumLogLink => FindElement(By.Id("drumlog-link"), 1);

        //-------------------------------------------------------------------------//

        //Sub Tab Links
        private IWebElement DemoViewerLink => this.containerElement.FindElement(By.XPath($"//ul[@class='dropdown-menu']//li//a[text()='Demo Viewer']"), 2);

        private IWebElement DemoStatusLink => this.containerElement.FindElement(By.XPath($"//ul[@class='dropdown-menu']//li//a[text()='Demo Status']"), 2);

        private IWebElement ManualEntryLink => this.containerElement.FindElement(By.XPath($"//div[@class='dropdown-menu show']//a[text()='Manual Entry']"), 2);

        private IWebElement UploadAFileLink => this.containerElement.FindElement(By.XPath($"//div[@class='dropdown-menu show']//[text()='Upload a File']"), 2);




        #endregion

        #region Methods
        public bool TabIsActive(string tabName)
        {
            string thisClass;
            switch (tabName.ToLower())
            {
                case "home":
                    thisClass = HomeLink.ClassAttribute();
                    break;
                case "dashboard":
                    thisClass = DashboardLink.ClassAttribute();
                    break;
                case "recent activities":
                    thisClass = RecentActivitiesLink.ClassAttribute();
                    break;
                case "web viewers":
                    thisClass = WebViewersLink.ClassAttribute();
                    break;
                case "itemsync":
                    thisClass = ItemSyncLink.ClassAttribute();
                    break;
                case "product lookup":
                    thisClass = ProductLookupsLink.ClassAttribute();
                    break;
                case "help & support":
                    thisClass = HelpAndSupportLink.ClassAttribute();
                    break;
                case "drum log":
                    thisClass = DrumLogLink.ClassAttribute();
                    break;
                default:
                    Report.Error("tabName parameter did not match any expected case");
                    return false;
            }
            return !thisClass.IsNullOrEmpty() && thisClass.Contains("active");
        }

        public bool ClickTab(string tabName)
        {
            switch (tabName.ToLower())
            {
                case "home":
                    return HomeLink.TryClick();
                case "dashboard":
                    return DashboardLink.TryClick();
                case "recent activities":
                    return RecentActivitiesLink.TryClick();
                case "web viewers":
                    return WebViewersLink.TryClick();
                case "itemsync":
                    return ItemSyncLink.TryClick(); ;
                case "product lookup":
                    return ProductLookupsLink.TryClick();
                case "help & support":
                    return HelpAndSupportLink.TryClick();
                case "drum log":
                    return DrumLogLink.TryClick();
                default:
                    Report.Error("tabName parameter did not match any expected case");
                    return false;
            }
        }

        public bool ClickSubTab(string tabName)
        {
            switch (tabName.ToLower())
            {
                case "demo viewer":
                    return DemoViewerLink.TryClick();
                case "demo status":
                    return DemoStatusLink.TryClick();
                case "manual entry":
                    return ManualEntryLink.TryClick();
                case "upload a file":
                    return UploadAFileLink.TryClick();

                default:
                    Report.Error("tabName parameter did not match any expected case");
                    return false;
            }
        }



        public List<string> LinkTitles() => this.containerElement.FindElements(By.XPath("./li/a"), 1).Select(x => x.Text).ToList();

        public List<string> LinkSubTitles(string mainTitle)
        {
            List<IWebElement> dropDownEls = this.containerElement.FindElements(By.XPath(".//a[@class='nav-link dropdown-toggle']"), 4).ToList();
            IWebElement wantedEl = dropDownEls.First(x => x.Text == mainTitle);
            List<IWebElement> subTitleEls = wantedEl.FindElements(By.XPath($".//following-sibling::div//a"), 4).ToList();
            List<string> subTitlesStr = subTitleEls.Select(x => x.Text).ToList();
            return subTitlesStr;

        }

        public bool LinkDropDownOpen(string mainTitle)
        {
            List<IWebElement> dropDownEls = this.containerElement.FindElements(By.XPath(".//a[@class='nav-link dropdown-toggle']"), 4).ToList();
            IWebElement wantedEl = dropDownEls.First(x => x.Text == mainTitle);
            string attr = wantedEl.GetAttribute("aria-expanded");
            return attr == "true";


        }

        public bool LinkDropDownClosed(string mainTitle)
        {
            List<IWebElement> dropDownEls = this.containerElement.FindElements(By.XPath(".//a[@class='nav-link dropdown-toggle']"), 4).ToList();
            IWebElement wantedEl = dropDownEls.First(x => x.Text == mainTitle);
            string attr = wantedEl.GetAttribute("aria-expanded");
            return attr == "false";


        }

        public bool CheckTabIsGrey(string tabName)
        {
            List<IWebElement> listOfTabEls = this.containerElement.FindElements(By.XPath($"//li[@id]"), 2).ToList();
            var wantedEl = listOfTabEls.First(x => x.Text == tabName);
            string rbgaCssValue = wantedEl.GetCssValue("background-color");
            return rbgaCssValue == "rgba(229, 232, 236, 1)";
        }

        public bool CheckAllTabsExeptXAreNotGrey(string expectTabName)
        {
            List<IWebElement> listOfTabEls = this.containerElement.FindElements(By.XPath($"//li[@id]"), 2).ToList();
            List<IWebElement> editedTabEls = new List<IWebElement>();
            foreach (var el in listOfTabEls)
            {
                if (el.Text != expectTabName)
                {
                    editedTabEls.Add(el);
                }
            }

            bool tabNotGrey = true;

            foreach (var tab in editedTabEls)
            {
                string rbgaCssValue = tab.GetCssValue("background-color");
                if (rbgaCssValue == "rgba(229, 232, 236, 1)")
                {
                    Report.Info($"The tab with title: {tab.Text} was grey");
                    tabNotGrey = false;

                }
                else
                {
                    Report.Info($"The tab with title: {tab.Text} was not grey");


                }
            }

            return tabNotGrey;
        }

        public bool ConfirmMenuLinksBanner()
        {
            List<IWebElement> menuLinks = this.containerElement.FindElements(By.XPath($"//li"), 5).ToList();
            return menuLinks.Any();
        }





        #endregion
    }

    class NavBarTools : SeleniumBaseObject
    {
        #region Page Objects
        protected override By ContainerElementLocator => By.Id("navbar-tools");

        private IWebElement Gauge => FindElement(By.Id("dropdownMenu1"), 1);

        private IWebElement DropDownContainer => FindElement(By.Id("widget-ul"), 1);

        private IWebElement ResetDashboard => DropDownContainer.FindElement(By.Id("dashboard-reset"), 1);

        private IWebElement RefreshWidgets => DropDownContainer.FindElement(By.Id("dashboard-refresh"), 1);

        private List<IWebElement> VisibleDropDownOptions => DropDownContainer.FindElements(By.XPath(".//li[not(@style='display: none;')]//a"), 2).ToList();



        private IWebElement WidgetTitleOption => DropDownContainer.FindElement(By.Id(""), 1);

        private List<IWebElement> AllDropDownOptions => this.DropDownContainer.FindElements(By.XPath("./li"), 1).ToList();

        #endregion

        #region Methods

        public bool ClickGauge() => this.Gauge.TryClick();

        public bool GaugeDisplayed() => this.Gauge.NotNullAndDisplayed();

        public string ResetDashboardText() => this.ResetDashboard?.Text;

        public string RefreshWidgetsText() => this.RefreshWidgets?.Text;

        public bool ResetDashboardDisplayed() => this.ResetDashboard.NotNullAndDisplayed();

        public bool RefreshWidgetDisplayed() => this.ResetDashboard.NotNullAndDisplayed();

        public bool ClickResetDashboard() => this.ResetDashboard.TryClick();

        public bool ClickRefreshWidgets() => this.RefreshWidgets.TryClick();

        public bool DropDownContainerDisplayed() => this.DropDownContainer.NotNullAndDisplayed();

        public bool DropDownOptionsAvailable() => this.AllDropDownOptions.Any();

        public bool SelectDropDownOption(string option)
        {
            List<IWebElement> allOptions = this.VisibleDropDownOptions;
            IWebElement wantedElement = allOptions.First(x => x.Text == option);
            return wantedElement.TryClick();

        }


        public List<string> GetListOfDropDownOptions()
        {

            List<IWebElement> allOptions = this.VisibleDropDownOptions;
            List<string> optionsAsText = new List<string>();
            foreach (var option in allOptions)
            {
                optionsAsText.Add(option.Text);
            }
            return optionsAsText;
        }



        #endregion
    }
}
