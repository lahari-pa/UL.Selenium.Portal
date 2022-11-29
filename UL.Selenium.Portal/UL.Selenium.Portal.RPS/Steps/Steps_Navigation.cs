using System.Collections.Generic;
using System.Linq;
using Castle.Core.Internal;
using TechTalk.SpecFlow;
using UL.Automation.Reporting.Functions;
using UL.Selenium.Portal.RPS.Classes;
using UL.Selenium.Portal.RPS.Selenium_Classes;

namespace UL.Selenium.Portal.RPS.Steps
{
    [Binding, Scope(Tag = "Navigation")]
    class Steps_Navigation
    {
        [StepDefinition(@"I confirm the active tab is: (.*)")]
        public void ConfirmActiveTab(string tab)
        {
            Report.IsTrue(new NavBar().TabIsActive(tab), "Active tab was not: " + tab + "!", "Active tab was: " + tab);
        }

        [StepDefinition(@"I click the tab: (.*)")]
        public void ClickTab(string tab)
        {
            Report.IsTrue(new NavBar().ClickTab(tab), "Failed to click tab: " + tab, "Clicked tab: " + tab);
            GeneralUtilities.WaitForLoadingToFinish();
        }

        [StepDefinition(@"I click on the tab: (.*) and dont wait for it to load")]
        public void ClickTabAndNoWait(string tab)
        {
            Report.IsTrue(new NavBar().ClickTab(tab), "Failed to click tab: " + tab, "Clicked tab: " + tab);

        }

        [StepDefinition(@"I click the sub tab: (.*)")]
        public void ClickSubTab(string tab)
        {
            Report.IsTrue(new NavBar().ClickSubTab(tab), "Failed to click sub tab: " + tab, "Clicked sub tab: " + tab);
            GeneralUtilities.WaitForLoadingToFinish();
        }

        [StepDefinition(@"I confirm the following tabs are displayed:")]
        public void ConfirmDisplayedTabs(Table table)
        {
            var displayedLinks = new NavBar().LinkTitles();
            foreach (var row in table.Rows)
            {
                var expectedLink = row["Link"];
                Report.IsTrue(displayedLinks.Contains(expectedLink), $"Link {expectedLink} was not displayed in the navigation bar!", $"Link {expectedLink} was displayed in the navigation bar");
            }
        }

        [StepDefinition(@"I confirm the following tabs are not displayed:")]
        public void ConfirmTabsNotDisplayed(Table table)
        {
            var displayedLinks = new NavBar().LinkTitles();
            foreach (var row in table.Rows)
            {
                var expectedLink = row["Link"];
                Report.IsTrue(!displayedLinks.Contains(expectedLink),$"Link {expectedLink} was displayed in the navigation bar", $"Link {expectedLink} was not displayed in the navigation bar!");
            }
        }

        [StepDefinition(@"I click the Gauge button in the navigation bar")]
        public void ClickGaugeInNavBar()
        {
            Report.IsTrue(new NavBarTools().ClickGauge(), "Failed to click the Gauge button", "Clicked the Gauge button successfully");
        }

        [StepDefinition(@"I confirm the Gauge button (is|is not) displayed in the navigation bar")]
        public void ConfirmGaugeButtonDisplayed(string isOrIsNot)
        {
            if (isOrIsNot != "is" && isOrIsNot != "is not")
            {
                Report.Failure("Step parameter must either be 'is' or 'is not'!");
                return;
            }
            var displayed = isOrIsNot == "is";
            if (displayed)
            {
                Report.IsTrue(new NavBarTools().GaugeDisplayed(), "The Gauge button was not displayed!", "The Gauge button was displayed");
            }
            else
            {
                Report.IsTrue(!new NavBarTools().GaugeDisplayed(), "The Gauge button was displayed when it should not be!", "The Gauge button was not displayed as expected");
            }

        }

        [StepDefinition(@"I confirm the following drop down options are displayed below the navigation bar Gauge button:")]
        public void ConfirmDropDownOptionsNavBarGauge(Table table)
        {
            foreach (var row in table.Rows)
            {
                var expectedRow = row["Option"];
                var navBarTools = new NavBarTools();
                switch (expectedRow)
                {
                    case "Reset Dashboard":
                        Report.IsTrue(navBarTools.ResetDashboardDisplayed() && navBarTools.ResetDashboardText() == "Reset Dashboard", "'Reset Dashboard' option was not displayed!", "'Reset Dashboard' was displayed");
                        return;
                    case "Refresh All Widgets":
                        Report.IsTrue(navBarTools.RefreshWidgetDisplayed() && navBarTools.RefreshWidgetsText() == "Refresh All Widgets", "'Refresh all Widgets' option was not displayed!", "'Refresh All Widgets' was displayed");
                        return;
                }
            }
        }

        [StepDefinition(@"I click the (Reset Dashboard|Refresh All Widgets) dropdown option below the navigation bar Gauge button")]
        public void ClickResetDashboardDropdown(string option)
        {
            switch (option)
            {
                case "Reset Dashboard":
                    Report.IsTrue(new NavBarTools().ClickResetDashboard(), "Failed to click the 'Reset Dashboard' option", "Clicked the 'Reset Dashboard' option successfully");
                    return;
                case "Refresh All Widgets":
                    Report.IsTrue(new NavBarTools().ClickRefreshWidgets(), "Failed to click the 'Refresh All Widgets' option", "Clicked the 'Refresh All Widgets' option successfully");
                    return;
                default:
                    Report.Failure("Step parameter must either be 'Reset Dashboard' or 'Refresh All Widgets'");
                    return;
            }
        }

        [StepDefinition(@"I confirm the navigation menu bar is displayed below the top bar")]
        public void ConfirmNavigationBarDisplayed()
        {
            Report.IsTrue(new NavBar().WaitForContainerToBeVisible(), "The navigation bar was not displayed!", "The navigation bar was displayed");
            Report.IsTrue(new NavBarTools().WaitForContainerToBeVisible(), "Navigation tools was not displayed on the right side of the navigation bar!", "Navigation tools was displayed on the right side of the navigation bar");
        }

        [StepDefinition("I confirm the down down options box (is|is not) displayed below the navigation bar Gauge button")]
        public void ConfirmDropDownDisplayed(string isOrIsNot)
        {
            var navigationTools =  new NavBarTools();
            if (isOrIsNot != "is" && isOrIsNot != "is not")
            {
                Report.Failure("Step parameter must either be 'is' or 'is not'!");
                return;
            }
            var displayed = isOrIsNot == "is";
            if (displayed)
            {
                Report.IsTrue(navigationTools.DropDownContainerDisplayed() && navigationTools.DropDownOptionsAvailable(), "The drop down options box was not displayed under the navigation toolbar!", "The drop down options box was displayed as expected");
            }
            else
            {
                Report.IsTrue(!navigationTools.DropDownContainerDisplayed(), "The drop down options box was displayed when it was not expected!", "The drop down options box was not displayed as expected");
            }
        }

     

        [StepDefinition(@"I confirm that the the options below the gauge icon are as follows:")]
        public void ConfirmGaugeOptions(Table table)
        {
            List<string> expectedOptions = new List<string>();
            foreach (TableRow thisRow in table.Rows)
            {
                expectedOptions.Add(thisRow["Options"]);
            }

            List<string> foundOptions = new NavBarTools().GetListOfDropDownOptions();

            var diff1 = expectedOptions.Except(foundOptions);
            var diff2 = foundOptions.Except(expectedOptions);
            Report.IsTrue(diff1.IsNullOrEmpty() && diff2.IsNullOrEmpty(), "The expected and found options below the gauge option did not match", "The expected and found options below the gauge option matched");        
           
        }

        [StepDefinition(@"I Confirm that the tab: (.*) shows in a grey highlight indicating it is active")]
        public void IConfirmTabIsShowingAsGrey(string tabName)
        {
            Report.IsTrue(new NavBar().CheckTabIsGrey(tabName), "The tab was not grey", "The tab was grey");
        }

        [StepDefinition(@"I Confirm that the tab: (.*) is not shown in grey highlight indicating it is inactive")]
        public void IConfirmTabIsShowingNotAsGrey(string tabName)
        {
            Report.IsTrue(!new NavBar().CheckTabIsGrey(tabName),"The tab was grey", "The tab was not grey");
        }

        [StepDefinition(@"I Confirm that all tabs not labeled: (.*) are not highlighted in grey")]
        public void IConfirmAllOtherTabsNotShowingAsGrey(string tabName)
        {
            Report.IsTrue(new NavBar().CheckAllTabsExeptXAreNotGrey(tabName), "Tabs were found to be grey when they were not expected to be", "All other tabs were not grey");
        }

        [StepDefinition(@"I confirm the menu links banner is displayed")]
        public void ConfirmMenuLinksBannerDisplayed()
        {
            Report.IsTrue(new NavBar().ConfirmMenuLinksBanner(), "Failed to find the menu links banner", "The menu links banner was displayed");
        }

        [StepDefinition(@"I confirm the following sub tabs are displayed under the tab: (.*):")]
        public void ConfirmDisplayedSubTabs(string mainTab, Table table)
        {
            var displayedLinks = new NavBar().LinkSubTitles(mainTab);
            foreach (var row in table.Rows)
            {
                var expectedLink = row["Link"];
                Report.IsTrue(displayedLinks.Contains(expectedLink), $"Sub Link {expectedLink} was not displayed in the navigation bar!", $"Sub Link {expectedLink} was displayed in the navigation bar");
            }
        }

        [StepDefinition(@"I confirm there is a drop down menu below the navigation tab: (.*)")]
        public void ConfirmDropDownMenuShownForTab(string mainTab)
        {
            Report.IsTrue(new NavBar().LinkDropDownOpen(mainTab), "Failed to find the drop down menu", "Successfully found a drop down menu");

        }

        [StepDefinition(@"I confirm there is not a drop down menu below the navigation tab: (.*)")]
        public void ConfirmDropDownMenuNotShownForTab(string mainTab)
        {
            Report.IsTrue(new NavBar().LinkDropDownClosed(mainTab), "Successfully found a drop down menu", "Failed to find the drop down menu");

        }



    }
}
