using System.Collections.Generic;
using System.Linq;
using Reqnroll;
using UL.Automation.Reporting.Functions;
using UL.Selenium.Portal.RPS.Classes;
using UL.Selenium.Portal.RPS.Selenium_Classes;
using UL.Automation.ReqnrollHelpers.Attributes;
using UL.Automation.TReVor.Classes;

namespace UL.Selenium.Portal.RPS.Steps
{
	[Binding, Scope(Tag = "Navigation")]
	class Steps_Navigation
	{
		[RegexStepDefinition(@"I confirm the active tab is: (.*)")]
		public void ConfirmActiveTab(string tab)
		{
            if (tab == "LWLandingtab")
            {
                tab = TestVariables.GetVariableSavedAs("LWLandingTab");
            }
            Report.IsTrue(new NavBar().TabIsActive(tab), "Active tab was not: " + tab + "!", "Active tab was: " + tab);
		}

        [RegexStepDefinition(@"I click the main tab: (.*)")]
		public void ClickTab(string tab)
		{
			Report.IsTrue(new NavBar().ClickTab(tab), "Failed to click tab: " + tab, "Clicked tab: " + tab);
			GeneralUtilities.WaitForLoadingToFinish();
		}

		[RegexStepDefinition(@"I click the tab: (.*) with parameter IsWebViewer: (.*)")]
		public void ClickTab(string tab, string isWebviewer)
		{
            if (tab == "lowes_store")
            {
                tab = TestVariables.GetVariableSavedAs("lowes_store");
            }
            if (isWebviewer == "No")
			{
				Report.IsTrue(new NavBar().ClickTab(tab), "Failed to click tab: " + tab, "Clicked tab: " + tab);
			}
			else
			{
				Report.UseSubSteps = true;
				ClickTabAndNoWait("Web Viewers");
				Report.IsTrue(new NavBar().ClickSubTab(tab), "Failed to click tab: " + tab, "Clicked tab: " + tab);
			}
			GeneralUtilities.WaitForLoadingToFinish();
		}

		[RegexStepDefinition(@"I click on the tab: (.*) and dont wait for it to load")]
		public void ClickTabAndNoWait(string tab)
		{
			Report.IsTrue(new NavBar().ClickTab(tab), "Failed to click tab: " + tab, "Clicked tab: " + tab);

		}

		[RegexStepDefinition(@"I click the sub tab: (.*)")]
		public void ClickSubTab(string tab)
		{
			Report.IsTrue(new NavBar().ClickSubTab(tab), "Failed to click sub tab: " + tab, "Clicked sub tab: " + tab);
			GeneralUtilities.WaitForLoadingToFinish();
		}

        [RegexStepDefinition(@"I confirm the following tabs are displayed:")]
        public void ConfirmDisplayedTabs(Table table)
        {
            var displayedLinks = new NavBar().LinkTitles();
            foreach (var row in table.Rows)
            {
                var expectedLink = row["Link"];
                Report.IsTrue(displayedLinks.Contains(expectedLink), $"Link {expectedLink} was not displayed in the navigation bar!", $"Link {expectedLink} was displayed in the navigation bar");
            }
        }

		[RegexStepDefinition(@"I confirm the following tabs are not displayed:")]
		public void ConfirmTabsNotDisplayed(Table table)
		{
			var displayedLinks = new NavBar().LinkTitles();
			foreach (var row in table.Rows)
			{
				var expectedLink = row["Link"];
				Report.IsTrue(!displayedLinks.Contains(expectedLink), $"Link {expectedLink} was displayed in the navigation bar", $"Link {expectedLink} was not displayed in the navigation bar!");
			}
		}

		[RegexStepDefinition(@"I click the Gauge button in the navigation bar")]
		public void ClickGaugeInNavBar()
		{
			Report.IsTrue(new NavBarTools().ClickGauge(), "Failed to click the Gauge button", "Clicked the Gauge button successfully");
		}

		[RegexStepDefinition(@"I confirm the Gauge button (is|is not) displayed in the navigation bar")]
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

		[RegexStepDefinition(@"I confirm the following drop down options are displayed below the navigation bar Gauge button:")]
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

		[RegexStepDefinition(@"I click the (Reset Dashboard|Refresh All Widgets) dropdown option below the navigation bar Gauge button")]
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

		[RegexStepDefinition(@"I confirm the navigation menu bar is displayed below the top bar")]
		public void ConfirmNavigationBarDisplayed()
		{
			Report.IsTrue(new NavBar().WaitForContainerToBeVisible(), "The navigation bar was not displayed!", "The navigation bar was displayed");
			Report.IsTrue(new NavBarTools().WaitForContainerToBeVisible(), "Navigation tools was not displayed on the right side of the navigation bar!", "Navigation tools was displayed on the right side of the navigation bar");
		}

		[RegexStepDefinition("I confirm the down down options box (is|is not) displayed below the navigation bar Gauge button")]
		public void ConfirmDropDownDisplayed(string isOrIsNot)
		{
			var navigationTools = new NavBarTools();
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



		[RegexStepDefinition(@"I confirm that the the options below the gauge icon are as follows:")]
		public void ConfirmGaugeOptions(Table table)
		{
			List<string> expectedOptions = new List<string>();
			foreach (TableRow thisRow in table.Rows)
			{
				expectedOptions.Add(thisRow["Options"]);
			}

			List<string> foundOptions = new NavBarTools().GetListOfDropDownOptions();
			Report.IsTrue(Enumerable.SequenceEqual(expectedOptions.OrderBy(e => e), foundOptions.OrderBy(e => e)), "The expected and found options below the gauge option did not match", "The expected and found options below the gauge option matched");

		}

		[RegexStepDefinition(@"I confirm that the (.*) tab is active")]
		public void ConfirmTabIsActive(string tab)
		{
			Report.IsTrue(new TopBar().WaitForContainerToBeVisible(), "Top bar did not load!");
			GeneralUtilities.WaitForLoadingToFinish();
			new GridTable().WaitForContainerToBeVisible();
			new Steps_Navigation().ConfirmActiveTab(tab);
			Report.IsTrue(new RecentActivities().WaitForContainerToBeVisible(), string.Format("{0} tab did not load.", tab),
				string.Format("{0} tab successfully loaded.", tab));
		}

		[RegexStepDefinition(@"I confirm that the (.*) tab is active with WebViewer param: (.*)")]
		public void ConfirmTabIsActive(string tab, string isWebviewer)
		{
            if (tab == "lowes_store")
            {
                tab = TestVariables.GetVariableSavedAs("lowes_store");
            }
            if (isWebviewer == "Yes")
			{
				Report.IsTrue(new TopBar().WaitForContainerToBeVisible(), "Top bar did not load!");
				GeneralUtilities.WaitForLoadingToFinish();
				if (tab != "Target_status")
					Report.IsTrue(new GridTable().WaitForContainerToBeVisible(60), string.Format("{0} tab did not load.", tab),
						string.Format("{0} tab successfully loaded.", tab));
				Report.Info("Grid table successfully loaded. Top bar will not show active because it's a WebViewer.");
			}
			else
			{
				Report.IsTrue(new TopBar().WaitForContainerToBeVisible(), "Top bar did not load!");
				GeneralUtilities.WaitForLoadingToFinish();
				new Steps_Navigation().ConfirmActiveTab(tab);
				/*
				Report.IsTrue(new GridTable().WaitForContainerToBeVisible(), string.Format("{0} tab did not load.", tab),
					string.Format("{0} tab successfully loaded.", tab));
				*/
			}
		}

		[RegexStepDefinition(@"I Confirm that the tab: (.*) shows in a grey highlight indicating it is active")]
		public void IConfirmTabIsShowingAsGrey(string tabName)
		{
			Report.IsTrue(new NavBar().CheckTabIsGrey(tabName), "The tab was not grey", "The tab was grey");
		}

		[RegexStepDefinition(@"I Confirm that the tab: (.*) is not shown in grey highlight indicating it is inactive")]
		public void IConfirmTabIsShowingNotAsGrey(string tabName)
		{
			Report.IsTrue(!new NavBar().CheckTabIsGrey(tabName), "The tab was grey", "The tab was not grey");
		}

		[RegexStepDefinition(@"I Confirm that all tabs not labeled: (.*) are not highlighted in grey")]
		public void IConfirmAllOtherTabsNotShowingAsGrey(string tabName)
		{
			Report.IsTrue(new NavBar().CheckAllTabsExeptXAreNotGrey(tabName), "Tabs were found to be grey when they were not expected to be", "All other tabs were not grey");
		}

		[RegexStepDefinition(@"I confirm the menu links banner is displayed")]
		public void ConfirmMenuLinksBannerDisplayed()
		{
			Report.IsTrue(new NavBar().ConfirmMenuLinksBanner(), "Failed to find the menu links banner", "The menu links banner was displayed");
		}

		[RegexStepDefinition(@"I confirm the following sub tabs are displayed under the tab: (.*):")]
		public void ConfirmDisplayedSubTabs(string mainTab, Table table)
		{
			var displayedLinks = new NavBar().LinkSubTitles(mainTab);
			foreach (var row in table.Rows)
			{
				var expectedLink = row["Link"];
				Report.IsTrue(displayedLinks.Contains(expectedLink), $"Sub Link {expectedLink} was not displayed in the navigation bar!", $"Sub Link {expectedLink} was displayed in the navigation bar");
			}
		}

		[RegexStepDefinition(@"I confirm there is a drop down menu below the navigation tab: (.*)")]
		public void ConfirmDropDownMenuShownForTab(string mainTab)
		{
			Report.IsTrue(new NavBar().LinkDropDownOpen(mainTab), "Failed to find the drop down menu", "Successfully found a drop down menu");

		}

		[RegexStepDefinition(@"I confirm there is not a drop down menu below the navigation tab: (.*)")]
		public void ConfirmDropDownMenuNotShownForTab(string mainTab)
		{
			Report.IsTrue(new NavBar().LinkDropDownClosed(mainTab), "Successfully found a drop down menu", "Failed to find the drop down menu");

		}

        [RegexStepDefinition(@"In the Product Lookup page I confirm the search box is shown")]
        public void GivenInTheProductLookupPageIConfirmTheSearchBoxIsShown()
        {
            Report.IsTrue(new NavBar().InProductLookupConfirmSearchBoxIsShown(), "Failed to find the search box", "Successfully found the search box is shown");
        }

        [RegexStepDefinition(@"In the footer area I see the following:")]
        public void GivenInTheFooterAreaISeeTheFollowing(Table table)
        {
            foreach (TableRow row in table.Rows)
            {
                if (row["Element"] == "Rows Per Page Selector")
                {
                    Report.IsTrue(new NavBar().ConfirmRowsPerPageSelectorInFooterArea(), "Failed to find rows per page in footer area", "Successfully found rows per page in footer area");
                }
                if (row["Element"] == "Page Navigation Controls")
                {
                    Report.IsTrue(new NavBar().ConfirmNavigationControlsInFooterArea(), "Failed to find navigation area in footer area", "Successfully found navigation area in footer area");
                }
                if (row["Element"] == "View 1 - 10 of x")
                {
                    Report.IsTrue(new NavBar().ConfirmPageNumberInFooterArea(), "Failed to find page number in footer area", "Successfully found page numbers in footer area");
                }
            }
        }


        [RegexStepDefinition(@"In the Status webview page I confirm the search box is shown")]
        public void GivenInTheStatusWebviewPageIConfirmTheSearchBoxIsShown()
        {
            Report.IsTrue(new NavBar().InStatusWebViewersConfirmSearchBoxIsShown(), "Failed to find the search box", "Successfully found the search box is shown");
        }

        [RegexStepDefinition(@"I confirm Status webviewer page, I confirm background color is: grey")]
        public void GivenIConfirmStatuWebviewerPageIConfirmBackgroundColorIsGrey()
        {
            Report.IsTrue(new NavBar().InStatusWebViewersConfirmBackgroundColorGrey(), "Failed to confirm background color is grey", "Successfully confirmed backgrond color is grey");
        }

        [RegexStepDefinition(@"In the product grid I confirm I see the following columns:")]
        public void GivenInTheProductGridIConfirmISeeTheFollowingColumns(Table table)
        {
            Report.IsTrue(new NavBar().ConfirmProductGridHasFollowingColumns(table), "Failed to find all columns in Product Grid", "Successfully found all columns in Product Grid");
        }

        [RegexStepDefinition(@"In the Product Grid Product Info Column I see the following information:")]
        public void GivenInTheProductGridProductInfoColumnISeeTheFollowingInformation(Table table)
        {
            Report.IsTrue(new NavBar().ConfirmProductGridProductInfoHasFollowingData(table), "Failed to find correct data in Product Info", "Successfully found correct data in Product Info");
        }

        [RegexStepDefinition(@"In the Product Grid the following field: (.*) has the following font color: (.*) and the following font weight: (.*)")]
        public void GivenInTheProductGridTheFollowingField_HasTheFollowingFontColor_AndTheFollowingFontWeight_(string fieldName, string fontColor, string fontWeight)
        {
            Report.IsTrue(new NavBar().ConfirmProuctGridProductInfoColumnFieldHasFont(fieldName, fontColor, fontWeight), "Failed to find correct data in Product Info", "Successfully found correct data in Product Info");
        }
        [RegexStepDefinition(@"In the Status webview page I confirm the search box text reads: (.*)")]
        public void GivenInTheStatusWebviewPageIConfirmTheSearchBoxTextReadsUPCProductNameSuppliesWPSID(string placeholder)
        {
            Report.IsTrue(new NavBar().InStatusWebViewersConfirmSearchBoxDisplaysFollowingPlaceholder(placeholder), "Failed to confirm search box placeholder is: " + placeholder, "Successfully confirmed search box placeholder is: " + placeholder);
        }

        [RegexStepDefinition(@"In the Status webview page I confirm to the right of the buttons I see three trends")]
        public void GivenInTheStatusWebviewPageIConfirmToTheRightOfTheButtonsISeeThreeTrends(Table table)
        {
            Report.IsTrue(new NavBar().InStatusWebViewersConfirmTheFollowingTrendsAreDisplayed(table), "Failed to find all three trends", "Successfully found all three trends");
        }

        [RegexStepDefinition(@"In the Status webview page I confirm below the filters and trend graphics I see the product grid")]
        public void GivenInTheStatusWebviewPageIConfirmBelowTheFiltersAndTrendGraphicsISeeTheProductGrid()
        {
             Report.IsTrue(new NavBar().InStatusWebViewersConfirmTableRowsBelowTrends(), "Failed to find product grid underneath search box", "Successfully found product grid underneath search box");
        }

        [RegexStepDefinition(@"In the Status webview page I confirm the main table heading row background color is grey")]
        public void GivenInTheStatusWebviewPageIConfirmTheMainTableHeadingRowBackgroundColorIsGrey()
        {
            Report.IsTrue(new NavBar().InStatusWebViewersConfirmTableBackgroundColorGrey(), "Failed to confirm table heading is grey", "Successfully confirmed table heading is grey");
        }

        [RegexStepDefinition(@"In the Status webview page I confirm below the Product grid the page footer is shown")]
        public void GivenInTheStatusWebviewPageIConfirmBelowTheProductGridThePageFooterIsShown()
        {
            Report.IsTrue(new NavBar().InStatusWebViewersConfirmFooterIsBelowTable(), "Failed to find the page footer below the product grid", "Successfully found the page footer below the product grid");
        }

        [RegexStepDefinition(@"In the Product Lookup page I confirm the to the right of the search box I see the following buttons:")]
        public void GivenInTheProductLookupPageIConfirmTheToTheRightOfTheSearchBoxISeeTheFollowingButtons(Table table)
        {
            foreach (TableRow row in table.Rows)
            {
                if (row["Button"] == "More Filters")
                {
                    Report.IsTrue(new NavBar().InProductLookupConfirmFilterButtonNextToSearchBox(), "Failed to find filter button", "Successfully found filter button");
                }
                if (row["Button"] == "Reset")
                {
                    Report.IsTrue(new NavBar().InProductLookupConfirmResetButtonNextToSearchBox(), "Failed found reset button", "Successfully found reset button");
                }
                if (row["Button"] == "Select Columns")
                {
                    Report.IsTrue(new NavBar().InProductLookupConfirmSelectColumnsButtonNextToSearchBox(), "Failed found select columns button", "Successfully found select columns button");
                }
                if (row["Button"] == "Export")
                {
                    Report.IsTrue(new NavBar().InProductLookupConfirmExportButtonNextToSearchBox(), "Failed found export button", "Successfully found export button");
                }
            }
        }

        [RegexStepDefinition(@"In the Product Lookup page I confirm to the right of the buttons I see three trends")]
        public void GivenInTheProductLookupPageIConfirmToTheRightOfTheButtonsISeeThreeTrends(Table table)
        {
            Report.IsTrue(new NavBar().InProductLookupConfirmTheFollowingTrendsAreDisplayed(table), "Failed to find all three trends", "Successfully found all three trends");
        }

        [RegexStepDefinition(@"In the Product Lookup page I confirm below the filters and trend graphics I see the product grid")]
        public void GivenInTheProductLookupPageIConfirmBelowTheFiltersAndTrendGraphicsISeeTheProductGrid()
        {
            Report.IsTrue(new NavBar().InProductLookupConfirmTableRowsBelowTrends(), "Failed to find product grid underneath search box", "Successfully found product grid underneath search box");
        }

        [RegexStepDefinition(@"In the Product Lookup page I confirm the main table heading row background color is grey")]
        public void GivenInTheProductLookupPageIConfirmTheMainTableHeadingRowBackgroundColorIsGrey()
        {
            Report.IsTrue(new NavBar().InProductLookupConfirmTableBackgroundColorGrey(), "Failed to confirm table heading is grey", "Successfully confirmed table heading is grey");
        }

        [RegexStepDefinition(@"In the Product Lookup page I confirm data rows are shown")]
        public void GivenInTheProductLookupPageIConfirmDataRowsAreShown()
        {
            Report.IsTrue(new NavBar().InProductLookupConfirmTableHasRows(), "Failed to confirm there are data rows", "Successfully confirmed there are data rows");
        }

        [RegexStepDefinition(@"In the Product Lookup page I confirm below the Product grid the page footer is shown")]
        public void GivenInTheProductLookupPageIConfirmBelowTheProductGridThePageFooterIsShown()
        {
            Report.IsTrue(new NavBar().InProductLookupConfirmFooterIsBelowTable(), "Failed to find the page footer below the product grid", "Successfully found the page footer below the product grid");
        }

        [RegexStepDefinition(@"In the Status webview page I confirm the to the right of the search box I see the following buttons:")]
        public void GivenInTheStatusWebviewPageIConfirmTheToTheRightOfTheSearchBoxISeeTheFollowingButtons(Table table)
        {
            Report.IsTrue(new NavBar().InStatusWebViewersConfirmFilterButtonNextToSearchBox(), "Failed to find filter button", "Successfully found filter button");
            Report.IsTrue(new NavBar().InStatusWebViewersConfirmResetButtonNextToSearchBox(), "Failed found reset button", "Successfully found reset button");
        }

        [RegexStepDefinition(@"In the Status webview page I confirm data rows are shown")]
        public void GivenInTheStatusWebviewPageIConfirmDataRowsAreShown()
        {
            Report.IsTrue(new NavBar().InStatusWebViewersConfirmTableHasRows(), "Failed to confirm there are data rows", "Successfully confirmed there are data rows");
        }

		[RegexStepDefinition(@"I Confirm that the tab: (.*) is  shown in white highlight indicating it is inactive")]
		public void IConfirmTabIsShowingAsWhite(string tabName)
		{
			Report.IsTrue(new NavBar().CheckTabIsWhite(tabName), "The tab is not white", "The tab is white");
		}

		[RegexStepDefinition(@"I confirm the following drop down options are displayed below the navigation bar Web viewers button:")]
		public void ConfirmDropDownOptionsNavBarWebViewers(Table table)
		{
			foreach (var row in table.Rows)
			{
				var expectedRow = row["Option"];
				var navBarTools = new NavBarTools();
				switch (expectedRow)
				{
					case "Store Viewer":
						Report.IsTrue(navBarTools.StoreViewerDisplayed() && navBarTools.StoreViewerText() == "Store Viewer Dashboard", "'Store Viewer Dashboard' option was not displayed!", "'Store Viewer Dashboard' was displayed");
						return;
				}
			}
		}


        [RegexStepDefinition(@"I click Accept all Cookies")]
        public void ClickAcceptallCookies()
        {
            Report.IsTrue(new NavBar().ClickAcceptAllCookies(), "Failed to click Accept All Cookies" , "Successfully clicked Accept all Cookies" );


        }

        [RegexStepDefinition(@"I Confirm that the tab: (.*) shows in a white highlight indicating it is active")]
        public void IConfirmTabActiveIsShowingAsWhite(string tabName)
        {
            Report.IsTrue(new NavBar().CheckTabIsWhite(tabName), "The tab was not white", "The tab was white");
        }

        [RegexStepDefinition(@"I Confirm that the tab: (.*) shows in a bolded underline under text indicating it is active")]
        public void IConfirmTabIsShowingUnderlineUndertext(string tabName)
        {
            Report.IsTrue(new NavBar().CheckUnderlineBelowtext(tabName), "The tab does not show in a bolded underline under text", "The tab shows in a bolded underline under text");
        }

        [RegexStepDefinition(@"I Confirm that the tab: (.*) does not show in a bolded underline under text indicating it is inactive")]
        public void IConfirmTabIsNotShownUnderlineUndertext(string tabName)
        {
            Report.IsTrue(!new NavBar().CheckUnderlineBelowtext(tabName), "The tab shows in a bolded underline under text", "The tab does not show in a bolded underline under text");
        }


    }
}
