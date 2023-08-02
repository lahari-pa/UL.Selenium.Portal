using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using Castle.Core.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using TechTalk.SpecFlow;
using UL.Automation.Reporting.Functions;
using UL.Automation.WebDriver.Classes;
using UL.Automation.SpecFlow.Classes;
using UL.Selenium.Portal.RPS.Classes;
using UL.Selenium.Portal.RPS.Selenium_Classes;
using UL.Selenium.Portal.WERCSmart.Classes;

namespace UL.Selenium.Portal.RPS.Steps
{
    [Binding, Scope(Tag = "RecentActivities")]
    class Steps_RecentActivities
    {

        [StepDefinition(@"I confirm the Recent Activities tab has loaded")]
        [StepDefinition(@"I confirm the Recent Activities page refreshes")]
        public void HomeTabLoaded()
        {
            Report.IsTrue(new TopBar().WaitForContainerToBeVisible(), "Top bar did not load!");
            GeneralUtilities.WaitForLoadingToFinish();
            new RecentActivities().WaitRecentActivitiesWidgetSpinnerFinish();
            new Steps_Navigation().ConfirmActiveTab("Recent Activities");
            Report.IsTrue(new RecentActivities().WaitForContainerToBeVisible(), "Page content did not load", "Page content loaded");
        }

        [StepDefinition(@"I Check that the current page title is 'Recent Activities'")]
        public void CheckRecentActivitiesTitle()
        {
            Report.IsTrue(new RecentActivities().GetCurrentPageTitle() == "Recent Activities", "The Page title was not as expected", "The page title was as expected");
        }

        [StepDefinition(@"I Check that the Recent Activities Products Table is showing")]
        public void CheckRecentActivitiesProductsTable()
        {
            Report.IsTrue(new RecentActivities().ProductTableIsPresent(), "The recent Activities products table was not showing", "The recent Activities products table was showing");
        }

        [StepDefinition(@"I confirm the Recent Activities background color is: grey")]
        public void ConfirmRecentActivitiesBackgroundColorIsGrey()
        {

            string expectedColorString = "rgba(240, 243, 245, 1)";
            Report.Info($"The expected rbga color for the background is: {expectedColorString}");
            string foundColorCode = new RecentActivities().GetRecentActivitiesBackgroundColor();
            Report.IsTrue(expectedColorString == foundColorCode, "The found color was not as expected", "The color found was as expected");

        }

        [StepDefinition(@"I confirm the Recent Activities Text color is: darker grey")]
        public void ConfirmRecentActivitiesTextColorIsGrey()
        {

            string expectedColorString = "rgba(115, 135, 156, 1)";
            Report.Info($"The expected rbga color for the text is: {expectedColorString}");
            string foundColorCode = new RecentActivities().GetRecentActivitiesTextColor();
            Report.IsTrue(expectedColorString == foundColorCode, "The found color was not as expected", "The color found was as expected");

        }

        [StepDefinition(@"I confirm the Recent Activities search box is shown")]
        public void ConfirmRecentActivitiesSearchBoxIsPresent()
        {
            Report.IsTrue(new RecentActivities().SearchBoxPresent(), "The search box was not present", "The search box was present");
        }

        [StepDefinition(@"I confirm that the recent activities search box place holder text reads: (.*)")]
        public void IConfirmThatRecentActivitiesSearchBoxPlaceHolderTextReads(string placeholderText)
        {
            Report.IsTrue(new RecentActivities().SearchBoxPlaceHolderText() == placeholderText, "The place holder text did not match the expected", "The place holder text was as expected");
        }

        [StepDefinition(@"I confirm that the recent activities page buttons to the right of the search box are as follows:")]
        public void IConfirmThatTheRecentActivitiesPageButtonsAreAsFollows(Table table)
        {
            List<string> buttons = new List<string>();
            foreach (TableRow thisRow in table.Rows)
            {
                buttons.Add(thisRow["Buttons"]);
            }
            Report.IsTrue(buttons.Count == new RecentActivities().RecentActivitiesButtons.Count, "The number of buttons found did not match the expected number of buttons", "The expected number of button matched the found number of buttons");
            foreach (var button in buttons)
            {
                Report.IsTrue(new RecentActivities().CheckRecentActivitiesButtonsListContains(button), "The button was not found in the list of buttons", "The button was found");
            }

        }

        [StepDefinition(@"I confirm that the recent activities page shows the bread crumb area")]
        public void IConfirmThatTheRecentActivitiesPageShowsBreadCrumbArea()
        {
            Report.IsTrue(new RecentActivities().ConfirmBreadCrumbAreaIsPresent(), "The breadcrumb area was not present", "The bread crumb area was present");
        }

        [StepDefinition(@"I confirm that the recent activities page bread crumb area contains the label: (.*)")]
        public void IConfirmThatTheRecentActivitiesPageBreadCrumbAreaContainsLabel(string label)
        {
            if (label.Contains("SavedProduct"))
            {
                string placeholder = label;
                var reg = new Regex("\".*?\"");
                var matches = reg.Matches(label);
                var wantedMatch = matches[0];
                string matchStr = wantedMatch.ToString();
                string finalStr = matchStr.Replace("\"", "");
                var found = (string)Context.GetFromContext(finalStr);                        

                label = label.Replace(finalStr, found);
            }
            Report.IsTrue(new RecentActivities().ConfirmBreadCrumbAreaContainsLabel(label), "The Bread crumb area did not contain the label", "The bread crumb are contained the label");
        }

        [StepDefinition(@"I confirm that the recent activities page bread crumb area does not contain the label: (.*)")]
        public void IConfirmThatTheRecentActivitiesPageBreadCrumbAreaDoesNotContainLabel(string label)
        {
            if (label.Contains("SavedProduct"))
            {
                string placeholder = label;
                var reg = new Regex("\".*?\"");
                var matches = reg.Matches(label);
                var wantedMatch = matches[0];
                string matchStr = wantedMatch.ToString();
                string finalStr = matchStr.Replace("\"", "");
                var found = (string)Context.GetFromContext(finalStr);

                label = label.Replace(finalStr, found);
            }
            Report.IsTrue(!new RecentActivities().ConfirmBreadCrumbAreaContainsLabel(label),"The bread crumb are contained the label", "The Bread crumb area did not contain the label");
        }

        [StepDefinition(@"I confirm that the recent activities page bread crumb area contains the label 'Start Date:'")]
        public void IConfrimThatTheRecentActivitiesPagenBreadCrumbAreaContainsLabelStartDate()
        {
            Report.IsTrue(new RecentActivities().ConfirmBreadCrumbAreaContainsStartDatelabel(), "The Start Date: label was not found", "The Start Date: label was found");
        }

        [StepDefinition(@"I confirm that the recent activities page bread crumb area does not contain the label 'Start Date:'")]
        public void IConfrimThatTheRecentActivitiesPagenBreadCrumbAreaDoesNotContainLabelStartDate()
        {
            Report.IsTrue(!new RecentActivities().ConfirmBreadCrumbAreaContainsStartDatelabel(), "The Start Date: label was found", "The Start Date: label was not found");
        }

        [StepDefinition(@"I confirm that the recent activities page bread crumb area contains the label 'End Date:'")]
        public void IConfrimThatTheRecentActivitiesPagenBreadCrumbAreaContainsLabelEndDate()
        {
            Report.IsTrue(new RecentActivities().ConfirmBreadCrumbAreaContainsEndDatelabel(), "The End Date: label was not found", "The End Date: label was found");
        }

        [StepDefinition(@"I confirm that the recent activities page shows the headings row in the table")]
        public void IConfirmThatTheRecentActivitiesPageShowsHeadingsRow()
        {
            Report.IsTrue(new RecentActivities().ConfirmTableHeadingRowIsPresent(), "The headings row was not found", "The headings row was found");
        }

        [StepDefinition(@"I confirm that the recent activities page headings row has a grey background color")]
        public void IConfirmThatRecentActivitiesPageHeadingsShowGrey()
        {
            string expectedColorString = "rgba(229, 232, 236, 1)";
            Report.Info($"The expected rbga color for the text is: {expectedColorString}");
            string foundColorCode = new RecentActivities().GetHeadingsRowBackgroundColor();
            Report.IsTrue(expectedColorString == foundColorCode, "The found color was not as expected", "The color found was as expected");

        }

        [StepDefinition(@"In the recent activities page, I confirm the column labels show a colon \(:\) icon as the column resize anchor")]
        public void InTheRecentActivitiesPageConfirmLabelsShowColonAsResizeAnchor()
        {
            Report.IsTrue(new RecentActivities().CheckColumnSesizeAnchorShowsSymbol(), "not all columns showed a colon as the resize anchor in the main table", "All columns showed a colon as ther reize anchor in the main table");
        }

        [StepDefinition(@"In the recent activities page, I confirm that the main table has the following columns:")]
        public void InRecentActivitiesPageIConfirmColumnsNames(Table table)
        {
            List<string> expectedHeadings = new List<string>();
            foreach (TableRow thisRow in table.Rows)
            {
                expectedHeadings.Add(thisRow["Headings"]);
            }
            List<string> foundHeadings = new RecentActivities().GetColumnHeadingTitles();
            var differences = expectedHeadings.Except(foundHeadings);
            Report.IsTrue(differences.IsNullOrEmpty() && expectedHeadings.Count() == foundHeadings.Count(), "The headings found were not as expected", "The headings found matched the expected headings");
        }

        [StepDefinition(@"In the recent activities page, I confirm that the main table includes the following columns:")]
        public void InRecentActivitiesPageIConfirmColumnsIncluded(Table table)
        {
            List<string> expectedHeadings = new List<string>();
            foreach (TableRow thisRow in table.Rows)
            {
                expectedHeadings.Add(thisRow["Headings"]);
            }
            List<string> foundHeadings = new RecentActivities().GetColumnHeadingTitles();
            var differences = expectedHeadings.Except(foundHeadings);
            Report.IsTrue(differences.IsNullOrEmpty(), "The headings were not all included", "The headings were all included");
        }
        [StepDefinition(@"In the Recent Activities page, I confirm that the main table shows data rows")]
        public void InTheRecentActivitiesPageIConfirmThatTableShowsDataRows()
        {
            int rowCount = new RecentActivities().ProductsCount();
            Report.IsTrue(rowCount > 0, "Data Rows were not showing", "Data Rows were showing");

        }

        [StepDefinition(@"In the recent activities page, I confirm that In the data row to the far left I confirm I see a right facing arrow \(Expand arrow\)")]
        public void InTheRecentActivitiesPageIConfirmThatTheTableContainsRightFacingArrow()
        {
            Report.IsTrue(new RecentActivities().SubGridColumnContainsRightFacingArrow(), "The first column did not contain a right facing arrow in every row", "The first column did contain a right facing arrow in every row");
        }

        [StepDefinition(@"In the Recent Activities page, I confirm that to the right of the expand arrow I see the product ID")]
        public void InTheRecentActivitiesPageConfirmProductIDToRightOfExpandArrow()
        {
            Report.IsTrue(new RecentActivities().HeadingCheckIDColumnIsToRightOfExpandArrow(), "The ID column heading was not to the right of the expand arrow column heading", "The ID column heading was to the right of the expand arrow column heading");
            Report.IsTrue(new RecentActivities().CheckIDColumnIsToRightofExpandArrowColumn(), "The product ID column was not to the right of the expand arrow column", "The product ID column was to the right of the expand arrow column");
            Report.IsTrue(new RecentActivities().CheckColumnContainsProductID(), "The column to the right of the expand arrow column did not containProduct IDs in all rows", "The column to the right of the expand arrow column contained Product IDs in all rows");
        }

        [StepDefinition(@"~~MANUAL CHECK~~ In the Recent Activities page, I confirm that each column of data is aligned to the left of the column")]
        public void InTheRecentActivitiesPageConfirmDataAlignedToLeft()
        {
            Report.Warning("MANAUAL CHECK: In the data row I confirm each column of data is aligned to the left of the column");
        }

        [StepDefinition(@"In the Recent Activities page, I confirm that the table shows alternating background color \(grey to white\)")]
        public void InTheRecentActivitiesPageIConfirmTableShowsAlternatingBackgroundColor()
        {
            Report.IsTrue(new RecentActivities().CheckTableAlternatesBetweenGreyAndWhite(), "the table background color was not alternating between grey and white", "the table background color was alternating between grey and white");
        }

        [StepDefinition(@"In the Recent Activities page, below the Most Recent Activity table I confirm: page footer is shown")]
        public void InTheRecentActivitiesPageICheckThatTheTableFooterIsShown()
        {
            Report.IsTrue(new RecentActivities().ProductsGridFooterPresent(), "The table footer was not shown", "The table footer was shown");
        }

        [StepDefinition(@"In the recent activities page, I confirm that the main table contains data in the following columns:")]
        public void InRecentActivitiesPageIConfirmColumnsContainData(Table table)
        {
            List<string> expectedHeadings = new List<string>();
            foreach (TableRow thisRow in table.Rows)
            {
                expectedHeadings.Add(thisRow["Headings"]);
            }
            foreach (var item in expectedHeadings)
            {
                Report.IsTrue(new RecentActivities().CheckColumnContainsData(item), "The column: " + item + " did not contain data", "The column: " + item + " contained data");
            }

        }

        [StepDefinition(@"In the recent Activities page, In the Start Date breadcrumb, I confirm text shown: (.*)")]
        public void InTheRecentActivitiesPageInTheStartDateBreadcrumbConfirmText(string searchText)
        {
            if (searchText == "<CurrentDate>")
            {
                Report.Info("Looking for the current date");
                searchText = DateTime.Today.ToString();
                searchText = searchText.Replace("12:00:00 AM", "").Trim();
            }
            if (searchText == "<StartDate>")
            {
                Report.Info("Looking for the current date minus 6 months");
                searchText = DateTime.Today.AddMonths(-6).ToString("MM/dd/yyyy");
                searchText = searchText.Replace("12:00:00 AM", "").Trim();

            }
            if(searchText=="<AnyDate>")
            {
                Report.Info("Looking for any date in the Start Date breadcrumb");
                Report.IsTrue(new RecentActivities().CheckStartDateContainsAnyDate(), "The start date breadcrumb did not contain any type of date", "The start date breadcrumb contained a date");
                return;
            }
            Report.IsTrue(new RecentActivities().CheckStartDateTagContainsText(searchText), "Failed to find the text", "The text was showing in the start date breadcrumb");
        }

        [StepDefinition(@"In the recent Activities page, In the start date breadcrumb, confirm X is showing")]
        public void InTheRecentActivitiesPageInTheStartDateBreadcrumbConfirmXShowing()
        {
            Report.IsTrue(new RecentActivities().CheckStartDateTagHasCloseX(), "The X was not showing", "The X was showing in the start date breadcrumb");

        }

        [StepDefinition(@"In the recent Activities page, In the start date breadcrumb the background color is grey")]
        public void IConfirmThatRecentActivitiesPageStartDateBreadCrumbBackroundColorIsGrey()
        {
            string expectedColorString = "rgba(229, 232, 236, 1)";
            Report.Info($"The expected rbga color for the background is: {expectedColorString}");
            string foundColorCode = new RecentActivities().GetStartDateTagBackgroundColor();
            Report.IsTrue(expectedColorString == foundColorCode, "The found color was not as expected", "The color found was as expected");

        }


        [StepDefinition(@"In the recent Activities page, In the end Date breadcrumb, I confirm text shown: (.*)")]
        public void InTheRecentActivitiesPageInTheEndDateBreadcrumbConfirmText(string searchText)
        {
            if (searchText == "<CurrentDate>")
            {
                Report.Info("Looking for the current date");
                searchText = DateTime.Today.ToString("MM/dd/yyyy");
                searchText = searchText.Replace("12:00:00 AM", "").Trim();
            }
            if (searchText == "<AnyDate>")
            {
                Report.Info("Looking for any date in the End Date breadcrumb");
                Report.IsTrue(new RecentActivities().CheckEndDateContainsAnyDate(), "The end date breadcrumb did not contain any type of date", "The end date breadcrumb contained a date");
                return;
            }
            Report.IsTrue(new RecentActivities().CheckEndDateTagContainsText(searchText), "Failed to find the text", "The text was showing in the end date breadcrumb");
        }

        [StepDefinition(@"In the recent Activities page, In the end date breadcrumb, confirm X is showing")]
        public void InTheRecentActivitiesPageInTheEndDateBreadcrumbConfirmXShowing()
        {
            Report.IsTrue(new RecentActivities().CheckEndDateTagHasCloseX(), "The X was not showing", "The X was showing in the end date breadcrumb");

        }

        [StepDefinition(@"In the recent Activities page, In the end date breadcrumb the background color is grey")]
        public void IConfirmThatRecentActivitiesPageEndDateBreadCrumbBackroundColorIsGrey()
        {
            string expectedColorString = "rgba(229, 232, 236, 1)";
            Report.Info($"The expected rbga color for the background is: {expectedColorString}");
            string foundColorCode = new RecentActivities().GetEndDateTagBackgroundColor();
            Report.IsTrue(expectedColorString == foundColorCode, "The found color was not as expected", "The color found was as expected");

        }

        [StepDefinition(@"In the recent Activities page, Confirm the breadcrumbs are in the correct order")]
        public void IConfirmThatRecentActivitiesPageConfirmBreadCrumbsCorrectOrder()
        {
            Report.IsTrue(new RecentActivities().ConfirmFilterTagsCorrectOrder(), "The order of the tags was not correct", "The order of the tags was correct");
        }


        [StepDefinition(@"In the recent Activities page, Confirm Reset Date breadcrumb displays text 'Reset'")]
        public void InTheRecentActivitiesPageInTheResetBreadcrumbConfirmText()
        {

            Report.IsTrue(new RecentActivities().CheckResetTagContainsText("Reset"), "Failed to find the text", "The text was showing in the reset breadcrumb");
        }

        [StepDefinition(@"In the recent Activities page, In the reset breadcrumb the background color is white")]
        public void IConfirmThatRecentActivitiesPageResetBreadCrumbBackroundColorIsWhite()
        {
            string expectedColorString = "rgba(255, 255, 255, 1)";
            Report.Info($"The expected rbga color for the background is: {expectedColorString}");
            string foundColorCode = new RecentActivities().GetResetTagBackgroundColor();
            Report.IsTrue(expectedColorString == foundColorCode, "The found color was not as expected", "The color found was as expected");

        }

        [StepDefinition(@"In the recent Activities page, In the reset breadcrumb the text color is black")]
        public void IConfirmThatRecentActivitiesPageResetBreadCrumbTextColorIsBlack()
        {
            string expectedColorString = "rgba(51, 51, 51, 1)";
            Report.Info($"The expected rbga color for the text is: {expectedColorString}");
            string foundColorCode = new RecentActivities().GetResetTagTextColor();
            Report.IsTrue(expectedColorString == foundColorCode, "The found color was not as expected", "The color found was as expected");

        }


        [StepDefinition(@"In the recent Activities page, In the Search Options, the More Filters button has a background color of black")]
        public void IConfirmThatRecentActivitiesPageMoreFiltersButtonIsWhite()
        {
            string expectedColorString = "rgba(0, 43, 69, 1)";
            Report.Info($"The expected rbga color for the background is: {expectedColorString}");
            string foundColorCode = new RecentActivities().GetMoreFiltersButtonBackgroundColor();
            Report.IsTrue(expectedColorString == foundColorCode, "The found color was not as expected", "The color found was as expected");

        }

        [StepDefinition(@"In the recent Activities page, In the Search Options, the More Filters button has a text color of white")]
        public void IConfirmThatRecentActivitiesPageMoreFiltersTextIsBlack()
        {
            string expectedColorString = "rgba(255, 255, 255, 1)";
            Report.Info($"The expected rbga color for the text is: {expectedColorString}");
            string foundColorCode = new RecentActivities().GetMoreFiltersButtonTextColor();
            Report.IsTrue(expectedColorString == foundColorCode, "The found color was not as expected", "The color found was as expected");

        }

        [StepDefinition(@"In the recent Activities page, In the Search Options, the Export button has a background color of white")]
        public void IConfirmThatRecentActivitiesPageExportButtonIsWhite()
        {
            string expectedColorString = "rgba(255, 255, 255, 1)";
            Report.Info($"The expected rbga color for the background is: {expectedColorString}");
            string foundColorCode = new RecentActivities().GetExportButtonBackgroundColor();
            Report.IsTrue(expectedColorString == foundColorCode, "The found color was not as expected", "The color found was as expected");

        }

        [StepDefinition(@"In the recent Activities page, In the Search Options, the Export button has a text color of black")]
        public void IConfirmThatRecentActivitiesPageExportTextIsBlack()
        {
            string expectedColorString = "rgba(51, 51, 51, 1)";
            Report.Info($"The expected rbga color for the text is: {expectedColorString}");
            string foundColorCode = new RecentActivities().GetExportButtonTextColor();
            Report.IsTrue(expectedColorString == foundColorCode, "The found color was not as expected", "The color found was as expected");

        }

        [StepDefinition(@"In the recent Activities page, In the Search Options, the Reset button has a background color of white")]
        public void IConfirmThatRecentActivitiesPageResetButtonIsWhite()
        {
            string expectedColorString = "rgba(255, 255, 255, 1)";
            Report.Info($"The expected rbga color for the background is: {expectedColorString}");
            string foundColorCode = new RecentActivities().GetResetButtonBackgroundColor();
            Report.IsTrue(expectedColorString == foundColorCode, "The found color was not as expected", "The color found was as expected");

        }

        [StepDefinition(@"In the recent Activities page, In the Search Options, the Reset button has a text color of black")]
        public void IConfirmThatRecentActivitiesPageResetTextIsBlack()
        {
            string expectedColorString = "rgba(51, 51, 51, 1)";
            Report.Info($"The expected rbga color for the text is: {expectedColorString}");
            string foundColorCode = new RecentActivities().GetResetButtonTextColor();
            Report.IsTrue(expectedColorString == foundColorCode, "The found color was not as expected", "The color found was as expected");

        }

        [StepDefinition(@"In the recent Activities page, In the Search Options, the Status button has a background color of white")]
        public void IConfirmThatRecentActivitiesPageStatusButtonIsWhite()
        {
            string expectedColorString = "rgba(255, 255, 255, 1)";
            Report.Info($"The expected rbga color for the background is: {expectedColorString}");
            string foundColorCode = new RecentActivities().GetStatusButtonBackgroundColor();
            Report.IsTrue(expectedColorString == foundColorCode, "The found color was not as expected", "The color found was as expected");

        }

        [StepDefinition(@"In the recent Activities page, In the Search Options, the Status button has a text color of black")]
        public void IConfirmThatRecentActivitiesPageStatusTextIsBlack()
        {
            string expectedColorString = "rgba(51, 51, 51, 1)";
            Report.Info($"The expected rbga color for the text is: {expectedColorString}");
            string foundColorCode = new RecentActivities().GetStatusButtonTextColor();
            Report.IsTrue(expectedColorString == foundColorCode, "The found color was not as expected", "The color found was as expected");

        }

        [StepDefinition(@"In the Recent Activities page, In Confirm the following search buttons are showing:")]
        public void InTheRecentActivitiesPageConfirmSearchButtons(Table table)
        {
            List<string> expectedButtons = new List<string>();
            foreach (TableRow thisRow in table.Rows)
            {
                expectedButtons.Add(thisRow["Buttons"]);
            }
            List<string> foundButtons = new RecentActivities().OptionButtonsStrings();
            var differences = expectedButtons.Except(foundButtons);
            Report.IsTrue(differences.IsNullOrEmpty() && expectedButtons.Count() == foundButtons.Count(), "The buttons found were not as expected", "The buttons found matched the expected headings");
        }

        [StepDefinition(@"In the Recent Activities page, I expand the first row of the products table")]
        public void InTheRecentActivitiesPageIExpandFirstRow()
        {
            Report.IsTrue(new RecentActivities().ExpandFirstRow(), "Failed to expand the first row", "The first row was expanded successfully");
        }

        [StepDefinition(@"In the Recent Activities page, I collapse the first row of the products table")]
        public void InTheRecentActivitiesPageICollapseFirstRow()
        {
            Report.IsTrue(new RecentActivities().CollapseFirstRow(), "Failed to collapse the first row", "The first row was collapsed successfully");
        }

        [StepDefinition(@"In the recent Activities page, I check that there are additional rows below the expanded version of the first row in the products table.")]
        public void InTheRecentActivitiesPageCheckFirstRowExpandedAdditionalRows()
        {
            IWebElement row = new RecentActivities().GetRowByExpandedProductID(new RecentActivities().GetFirstProductID());
            Report.IsTrue(row != null, "There was not any additional rows below the expanded first row", "There was additional rows below the expanded first row");
        }

        [StepDefinition(@"In the recent Activities page, I check that there are no additional rows below the expanded version of the first row in the products table.")]
        public void InTheRecentActivitiesPageCheckFirstRowExpandedNoAdditionalRows()
        {
            IWebElement row = new RecentActivities().GetRowByExpandedProductID(new RecentActivities().GetFirstProductID());
            Report.IsTrue(row == null, "There was additional rows below the expanded first row", "There was not any additional rows below the expanded first row");
        }

        [StepDefinition(@"In the recent activities page, I confirm that the expanded first row has following columns in the sub table:")]
        public void InRecentActivitiesPageIConfirmExapndedFirstRowColumnsNames(Table table)
        {
            IWebElement row = new RecentActivities().GetRowByExpandedProductID(new RecentActivities().GetFirstProductID());
            List<string> expectedHeadings = new List<string>();
            foreach (TableRow thisRow in table.Rows)
            {
                expectedHeadings.Add(thisRow["Headings"]);
            }
            List<string> foundHeadings = new RecentActivities().GetSubRowColumnHeadingTitles(row);
            var differences = expectedHeadings.Except(foundHeadings);
            Report.IsTrue(differences.IsNullOrEmpty() && expectedHeadings.Count() == foundHeadings.Count(), "The headings found were not as expected", "The headings found matched the expected headings");
        }

        [StepDefinition(@"In the recent Activities page, I confirm that the expanded first row column headings show the ':' resize anchor")]
        public void InRecentActivitiesPageConfrimExpandedFirstRowResizeAnchor()
        {
            IWebElement row = new RecentActivities().GetRowByExpandedProductID(new RecentActivities().GetFirstProductID());
            Report.StartStep("In the heading row I confirm the column label show a colon ':' icon as the column resize anchor");
            Report.IsTrue(new RecentActivities().CheckRowSubTableColumnResizeAnchorShowsSymbol(row), "not all columns showed a colon as the resize anchor in the main table", "All columns showed a colon as ther reize anchor in the main table");
        }

        [StepDefinition(@"In the recent activities page, I confirm that the expanded first row does not have the column: (.*)")]
        public void InRecentActivitiesPageIConfirmExapndedFirstRowColumnDoesNotContainColumn(string header)
        {
            IWebElement row = new RecentActivities().GetRowByExpandedProductID(new RecentActivities().GetFirstProductID());

            List<string> foundHeadings = new RecentActivities().GetSubRowColumnHeadingTitles(row);

            Report.IsTrue(!foundHeadings.Contains(header), "The heading was found", "The heading was not found");
        }

        [StepDefinition(@"In the recent activities page, I confirm that in the expanded first row I see the expanded menu icon to the left")]
        public void InTheRecentActivitiesPageIConfirmThatInExpandedFirstRowIseeExpandedMenuIcon()
        {
            IWebElement row = new RecentActivities().GetRowByExpandedProductID(new RecentActivities().GetFirstProductID());
            Report.IsTrue(new RecentActivities().RowSubTableContainsExpandedMenuIcon(row), "The expanded first row did not contain an expanded menu icon the the left", "The expanded first row did contain an expanded menu icon the the left");
        }

        [StepDefinition(@"In the recent activities page, I click the label 'Start Date'")]
        public void InTheRecentActivitiesPageIClickTheLabelStartDate()
        {
            Report.IsTrue(new RecentActivities().ClickStartDateLabel(), "Failed to click the start date label", "Successfully clicked the start date label");
            this.HomeTabLoaded();
        }

        [StepDefinition(@"In the recent activities Page, In the Products table I confirm the Most Recent Activity column displays in date order, newest first")]
        public void InTheRecentActivitiesPageInProductsTableIConfirmRecentActivityColumnInDateOrder()
        {
            List<string> datesAsStrings = new RecentActivities().GetColumnData("Most Recent Activity");
            List<DateTime> datesFound = new List<DateTime>();
            foreach(var el in datesAsStrings)
            {
                DateTime parsedDate = DateTime.Parse(el);
                datesFound.Add(parsedDate);
            }
            int i = 1;
            bool orderCorrect = true;
            
            foreach(var date in datesFound)
            {
                if(i== datesFound.Count())
                {
                    break;
                }
                var compared = date.CompareTo(datesFound[i]);
                if(compared==0|| compared==1)
                {
                    //do nothing
                }
                else
                {
                    Report.Failure($"When comparing date: {i} to {i + 1}, the order was not as expected");
                    orderCorrect = false;
                }
                i++;
            }
            Report.IsTrue(orderCorrect, "The dates were not in the correct order", " The dates were in the correct order");
        }
        [StepDefinition(@"In the recent activities Page, In the Products table I confirm the Most Recent Activity column displays dates in the format of yyyy-mm-dd")]
        public void InTheRecentActivitiesPageInProductsTableIConfirmRecentActivityColumnContainsOnlyDates()
        {
            List<string> datesAsStrings = new RecentActivities().GetColumnData("Most Recent Activity");
            List<DateTime> datesFound = new List<DateTime>();
            bool correctFormat = true;
            foreach (var el in datesAsStrings)
            {
                string format = "yyyy-mm-dd";
                DateTime dateTimeGeneral;
                DateTime dateTime;
                if (DateTime.TryParse(el, out dateTimeGeneral))
                {
                    Report.Info($"The Date: {el} was a type of date");
                    if (DateTime.TryParseExact(el, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
                    {
                        Report.Info($"The Date: {el} was the correct format");
                    }
                    else
                    {
                        Report.Failure($"The Date: {el} was not the correct format");
                        correctFormat = false;
                    }
                }
                else
                {
                    Report.Failure($"The value: {el} was not a date");
                    correctFormat = false;
                }

               
            }
            Report.IsTrue(correctFormat, "Not all dates were in the correct format", "All dates were in the correct format");
        }

        [StepDefinition(@"In the recent activities Page, In the Products table I select a random product and save product Data to context as: (.*)")]
        public void InTheRecentActivitiesPageInProductsTableISelectRandomProductsAndSaveDataAs(string savedAs)
        {
            string iD= GeneralUtilities.SelectRandomFromListOfStrings(new RecentActivities().GetCurrentProductIDs());
            RecentActivities.RecentProductData currentData = new RecentActivities().GetRecentProductDataByID(iD);
            Context.AddToContext(savedAs, currentData);
        }


        [StepDefinition(@"In the recent activities Page, In the Products table I select 2 random products and save product Data to context as: (.*) and (.*)")]
        public void InTheRecentActivitiesPageInProductsTableISelectRandomProductsAndSaveDataAs(string savedAs1, string savedAs2)
        {
            string iD = GeneralUtilities.SelectRandomFromListOfStrings(new RecentActivities().GetCurrentProductIDs());
            RecentActivities.RecentProductData currentData = new RecentActivities().GetRecentProductDataByID(iD);
            Context.AddToContext(savedAs1, currentData);

            string secondiD = GeneralUtilities.SelectRandomFromListOfStrings(new RecentActivities().GetCurrentProductIDs());
            if(secondiD==iD)
            {
                int i = 0;
                bool differntID = false;
                while (i < 5 && differntID == false)
                {
                    secondiD = GeneralUtilities.SelectRandomFromListOfStrings(new RecentActivities().GetCurrentProductIDs());
                    if (secondiD != iD)
                    {
                        differntID = true;
                    }
                    i++;
                }
                if(differntID==false)
                {
                    Report.Failure("Failed to find a second differnt ID in the table");
                    return;
                }

            }
            RecentActivities.RecentProductData secondData = new RecentActivities().GetRecentProductDataByID(secondiD);
            Context.AddToContext(savedAs2, secondData);

        }

        [StepDefinition(@"In the recent activities Page, In the Products table footer I click on the Last Page Button")]
        public void InTheRecentActivitiesPageInProductsTableFooterAndClickLastPageButton()
        {
            Report.IsTrue(new RecentActivities().LastPageButtonExists(), "Failed to find the last page button", "Successfully found the last page button");
            Report.IsTrue(new RecentActivities().ClickLastPageButton(), "Failed to click last page button", "Successfully clicked the last page button");
            this.HomeTabLoaded();
        }

        [StepDefinition(@"In the recent activities Page, In the Products table footer I check that the current page is the same as the last page number")]
        public void InTheRecentActivitiesPageInProductsTableFooterCheckFinalPageActive()
        {
            string currentNumber = new RecentActivities().GetCurrentPageNumber();
            string finalNumber = new RecentActivities().GetLastPossiblePageNumber();
            Report.IsTrue(currentNumber == finalNumber, "The current page number did not match the last page number", "The current page number matched the last page number");
        }

        [StepDefinition(@"In the recent activities Page, In the Products table footer I click on the Next Page Button")]
        public void InTheRecentActivitiesPageInProductsTableFooterAndClickNextPageButton()
        {
            Report.IsTrue(new RecentActivities().NextPageButtonExists(), "Failed to find the Next page button", "Successfully found the Next page button");
            Report.IsTrue(new RecentActivities().ClickNextPageButton(), "Failed to click Next page button", "Successfully clicked the Next page button");
            this.HomeTabLoaded();

        }

        [StepDefinition(@"In the recent activities Page, In the Products table footer I click on the Previous Page Button")]
        public void InTheRecentActivitiesPageInProductsTableFooterAndClickPreviousPageButton()
        {
            Report.IsTrue(new RecentActivities().PreviousPageButonExists(), "Failed to find the Previous page button", "Successfully found the Previous page button");
            Report.IsTrue(new RecentActivities().ClickPreviousPageButton(), "Failed to click Previous page button", "Successfully clicked the Previous page button");
            this.HomeTabLoaded();

        }

        [StepDefinition(@"In the recent activities Page, In the Products table footer I click on the First Page Button")]
        public void InTheRecentActivitiesPageInProductsTableFooterAndClickFirstPageButton()
        {
            Report.IsTrue(new RecentActivities().FirstPageButonExists(), "Failed to find the First page button", "Successfully found the First page button");
            Report.IsTrue(new RecentActivities().ClickFirstPageButton(), "Failed to click First page button", "Successfully clicked the First page button");
            this.HomeTabLoaded();

        }

        [StepDefinition(@"In the recent activities Page, In the Products table footer I check that the current page is: (.*)")]
        public void InTheRecentActivitiesPageInProductsTableFooterCheckCurrentPageExpected(string expectedPage)
        {
            string currentNumber = new RecentActivities().GetCurrentPageNumber();
            Report.IsTrue(currentNumber == expectedPage, "The current page number was not as expected", "The current page number was as expected");
        }

        [StepDefinition(@"In the recent activities Page, I check the full page is visible")]
        public void InTheRecentActivitiesPageCheckFullPageIsVisible()
        {
            this.CheckRecentActivitiesTitle();

            var table = new Table("Link");
            table.AddRow("Home");
            table.AddRow("Dashboard");
            table.AddRow("Recent Activities");
            table.AddRow("Web Viewers");
            table.AddRow("Product Lookup");
            table.AddRow("Help & Support");     
            new Steps_Navigation().ConfirmDisplayedTabs(table);
            new Steps_TopBar().ConfirmBannerFontColorIsWhite("WERCSmart® Product Suite");
            this.ConfirmRecentActivitiesSearchBoxIsPresent();
            var buttonsTable = new Table("Buttons");
            buttonsTable.AddRow("More Filters");
            buttonsTable.AddRow("Reset");
            buttonsTable.AddRow("Export to Excel");
            buttonsTable.AddRow("Show Legend Status");
            this.IConfirmThatTheRecentActivitiesPageButtonsAreAsFollows(buttonsTable);


            this.IConfirmThatTheRecentActivitiesPageShowsBreadCrumbArea();
            this.IConfirmThatTheRecentActivitiesPageBreadCrumbAreaContainsLabel("Filters");
            //this.IConfrimThatTheRecentActivitiesPagenBreadCrumbAreaContainsLabelStartDate();
            this.IConfrimThatTheRecentActivitiesPagenBreadCrumbAreaContainsLabelEndDate();
            this.IConfirmThatTheRecentActivitiesPageBreadCrumbAreaContainsLabel("Reset");

            this.IConfirmThatTheRecentActivitiesPageShowsHeadingsRow();
            this.InTheRecentActivitiesPageIConfirmThatTableShowsDataRows();
            this.InTheRecentActivitiesPageICheckThatTheTableFooterIsShown();


        }

        [StepDefinition(@"In the recent activities Page, In the Products table I scroll down to the bottom product and check its interactable")]
        public void InTheRecentActivitiesPageInProductsTableScrollToBottomProduct()
        {
            Report.IsTrue(new RecentActivities().ScrollToAndCheckBottomProductInteractable(), "Failed to scroll to and interact with the bottom product", "Successfully scrolled to and interact with the bottom product");

        }

        [StepDefinition(@"In the recent activities Page, In the Products table I scroll down to the top product and check its interactable")]
        public void InTheRecentActivitiesPageInProductsTableScrollToTopProduct()
        {
            Report.IsTrue(new RecentActivities().ScrollToAndCheckTopProductInteractable(), "Failed to scroll to and interact with the top product", "Successfully scrolled to and interact with the top product");

        }

        [StepDefinition(@"In the recent activities Page, In the Products table the total number of pages is correct")]
        public void InTheRecentActivitiesPageInProductsTableTotalNoPagesCorrect()
        {
            int totalProducts = new RecentActivities().GetTotalProducts();
            int foundPages = Int32.Parse(new RecentActivities().GetLastPossiblePageNumber());
            double expectedPageTotalDB =  (Double)totalProducts / (Double)(new RecentActivities().GetCurrentItemsPerPage());
            int expectedPageTotal= (int)Math.Ceiling(expectedPageTotalDB);

            Report.IsTrue(foundPages == expectedPageTotal, "The number of pages found was not as expected", "The number of pages found was as expected");
        }

        [StepDefinition(@"In the recent activities Page, In the Products table footer, the number of items per page shows the following options:")]
        public void InTheRecentActivitiesPageInProductsTableFooterNoItemsPerPageOptionsMatch(Table table)
        {
            List<string> options = new List<string>();
            foreach (TableRow thisRow in table.Rows)
            {
                options.Add(thisRow["Option"]);
            }
            Report.IsTrue(new RecentActivities().ItemsPerPageOptionsMatch(options), "The options did not match", "The options matched");
        }

        [StepDefinition(@"In the recent activities Page, In the Products table footer, select the items per page option: (.*)")]
        public void InTheRecentActivitiesPageInProductsTableFooterSelectItemPerPageOption(string option)
        {
            Report.IsTrue(new RecentActivities().SelectOptionFromItemsPerPageSelector(option), "The Option was not selected", "The option was selected successfully");
            this.HomeTabLoaded();
        }

        [StepDefinition(@"In the recent activities Page, In the Products table I click the Reset Button")]
        public void InTheRecentActivitiesPageInProductsTableIClickReset()
        {
            Report.IsTrue(new RecentActivities().ClickResetButton(), "Failed to click reset", "Successfully clicked the reset button");
            this.HomeTabLoaded();
        }

        [StepDefinition(@"In the recent activities Page, In the Products table footer I check the current Items Per page is: (.*)")]
        public void InTheRecentActivitiesPageInProductsTableFooterCurrentItemsPerPageIs(int option)
        {
            Report.IsTrue(new RecentActivities().GetCurrentItemsPerPage() == option, "The current items per page was not as expected", "The current items per page was as expected");
        }


        [StepDefinition(@"In the recent activities Page, In the Products table footer I enter the page number value of: (.*)")]
        public void InTheRecentActivitiesPageInProductsTableFooterEnterPageNumber(string value)
        {
            new RecentActivities().EnterCurrentPageValue(value);
            this.HomeTabLoaded();
            this.InTheRecentActivitiesPageInProductsTableFooterCheckCurrentPageExpected(value);
        }

        [StepDefinition(@"In the recent activities Page, In the Products table footer I confirm the product count range reflects the page I am on")]
        public void InTheRecentActivitiesPageInProductsTableFooteProducsAccountCorrect()
        {
            var recentActivities = new RecentActivities();
            Report.IsTrue(recentActivities.GetExpectedProductsRange() == recentActivities.GetDisplayedProductsRange(), "Found range did not match the expected", "Found range matched the expected");


        }

        [StepDefinition(@"In the recent activities Page, In the Products table I search for the product with ID: (.*)")]
        public void InTheRecentActivitiesPageInProductsTableSearchForProductID(string productID)
        {
            if (productID.ToLower().Contains("recentproductdata"))
            {
                var productData = (RecentActivities.RecentProductData)Context.GetFromContext(productID);
                productID = productData.ID;
            }
            new RecentActivities().EnterSearchBoxText(productID);
            Report.IsTrue(new RecentActivities().CheckSearchBoxContains(productID), "The search box did not contain the text that was searched for", "The search box contained the text that was searched for");
            
        }

        [StepDefinition(@"In the recent activities Page, In the Products table I search for the product with Name: (.*)")]
        public void InTheRecentActivitiesPageInProductsTableSearchForProductName(string productName)
        {
            if (productName.ToLower().Contains("recentproductdata"))
            {
                var productData = (RecentActivities.RecentProductData)Context.GetFromContext(productName);
                productName = productData.ProductName;
            }
            new RecentActivities().EnterSearchBoxText(productName);
            Report.IsTrue(new RecentActivities().CheckSearchBoxContains(productName), "The search box did not contain the text that was searched for", "The search box contained the text that was searched for");

        }

        [StepDefinition(@"In the recent activities Page, In the Products table I enter name search text: (.*) and press the Enter Key")]
        public void InTheRecentActivitiesPageInProductsTableSearchForProductNameAndPressEnter(string productName)
        {
            if (productName.ToLower().Contains("recentproductdata"))
            {
                var productData = (RecentActivities.RecentProductData)Context.GetFromContext(productName);
                productName = productData.ProductName;
            }
            new RecentActivities().EnterSearchBoxTextAndpressEnterKey(productName);

            Report.IsTrue(new RecentActivities().CheckSearchBoxContains(productName), "The search box did not contain the text that was searched for", "The search box contained the text that was searched for");

        }


        [StepDefinition(@"In the recent activities Page, In the Products table I search for the Partial Name of a comma product saved as: (.*)")]
        public void InTheRecentActivitiesPageInProductsTableSearchForProductPartialCommaName(string productName)
        {
            if (productName.ToLower().Contains("recentproductdata"))
            {
                var productData = (RecentActivities.RecentProductData)Context.GetFromContext(productName);
                productName = productData.ProductName;
                int firsto = productName.IndexOf(",");
                string firstUpdate = productName.Substring(0, firsto);
                productName = firstUpdate;


            }
            new RecentActivities().EnterSearchBoxText(productName);
            Report.IsTrue(new RecentActivities().CheckSearchBoxContains(productName), "The search box did not contain the text that was searched for", "The search box contained the text that was searched for");

        }

        [StepDefinition(@"In the recent activities Page, In the Products table I search for the product with UPC: (.*)")]
        public void InTheRecentActivitiesPageInProductsTableSearchForProductUPC(string productUPC)
        {
            if (productUPC.ToLower().Contains("recentproductdata"))
            {
                var productData = (RecentActivities.RecentProductData)Context.GetFromContext(productUPC);
                productUPC = productData.UPC.First();
            }
            new RecentActivities().EnterSearchBoxText(productUPC);
            Report.IsTrue(new RecentActivities().CheckSearchBoxContains(productUPC), "The search box did not contain the text that was searched for", "The search box contained the text that was searched for");

        }

        [StepDefinition(@"In the recent activities Page, In the Products table the first result matches the product ID: (.*)")]
        public void InTheRecentActivitiesPageInProductsTableFirstResultMatchesID(string productID)
        {
            if (productID.ToLower().Contains("recentproductdata"))
            {
                var productData = (RecentActivities.RecentProductData)Context.GetFromContext(productID);
                productID = productData.ID;
            }
            if (productID.ToLower().Contains("recentproductdata"))
            {
                var productData = (RecentActivities.RecentProductData)Context.GetFromContext(productID);
                productID = productData.ID;
            }
            Report.IsTrue(new RecentActivities().GetFirstProductID() == productID, "The product Ids did not match", "The product Ids matched");
        }

        [StepDefinition(@"In the recent activities Page, In the Products table the first result matches the product Name: (.*)")]
        public void InTheRecentActivitiesPageInProductsTableFirstResultMatchesName(string productName)
        {
            if (productName.ToLower().Contains("recentproductdata"))
            {
                var productData = (RecentActivities.RecentProductData)Context.GetFromContext(productName);
                productName = productData.ProductName;
            }
            Report.IsTrue(new RecentActivities().GetFirstProductName() == productName, "The product names did not match", "The product names matched");
        }

        [StepDefinition(@"In the recent activities Page, In the Products table the results contain the product with Name: (.*)")]
        public void InTheRecentActivitiesPageInProductsTableResultContainName(string productName)
        {
            if (productName.ToLower().Contains("recentproductdata"))
            {
                var productData = (RecentActivities.RecentProductData)Context.GetFromContext(productName);
                productName = productData.ProductName;
            }
            Report.IsTrue(new RecentActivities().CheckProductNameInResults(productName), "The product name was not found in resultsh", "The product name was found in the results");;
        }

        [StepDefinition(@"In the recent activities Page, In the Products table the First result matches the UPCs saved as: (.*)")]
        public void InTheRecentActivitiesPageInProductsTableFirstResultMatchesUPC(string productUPCs)
        {
            List<string> savedUPCs = new List<string>();
            if (productUPCs.ToLower().Contains("recentproductdata"))
            {
                var productData = (RecentActivities.RecentProductData)Context.GetFromContext(productUPCs);
                savedUPCs = productData.UPC;
            }
            else
            {
                savedUPCs= (List<string>)Context.GetFromContext(productUPCs);
            }
           
            var foundUPCs = new RecentActivities().GetFirstProductUPCs();
            var differences = foundUPCs.Except(savedUPCs);
            Report.IsTrue(!differences.Any() && savedUPCs.Count()== foundUPCs.Count(), "The product UPCs did not match", "The product UPCs matched");
        }

        [StepDefinition(@"In the recent activities Page, In the Products table the first result matches the product data: (.*)")]
        public void InTheRecentActivitiesPageInProductsTableFirstResultMatchesData(string productID)
        {
           
            var productData = (RecentActivities.RecentProductData)Context.GetFromContext(productID);
            productID = productData.ID;          
            string firstID = new RecentActivities().GetFirstProductID();
            RecentActivities.RecentProductData currentData = new RecentActivities().GetRecentProductDataByID(firstID);
            Report.IsTrue(currentData.Equals(productData), "The Two sets of recent product data did not match", "The two sets of recent product data matched");
        }


        [StepDefinition(@"In the recent activities Page, In the Products table there is only 1 result showing")]
        public void InTheRecentActivitiesPageInProductsTableThereIsOnly1Result()
        {
            Report.IsTrue(new RecentActivities().ProductsCount() == 1, "The was not just 1 product in the table", "The was just 1 product in the table");
        }

        [StepDefinition(@"In the recent activities Page, In the Products table there is more than 1 result showing")]
        public void InTheRecentActivitiesPageInProductsTableThereIsMoreThan1Result()
        {
            Report.IsTrue(new RecentActivities().ProductsCount() > 1, "The was not more than 1 product in the table", "The was more than 1 product in the table");
        }

        [StepDefinition(@"In the Recent Activities page, I expand the row for Product with ID: (.*)")]
        public void InTheRecentActivitiesPageIExpandRow(string productID)
        {
            if (productID.ToLower().Contains("recentproductdata"))
            {
                var productData = (RecentActivities.RecentProductData)Context.GetFromContext(productID);
                productID = productData.ID;
            }
            Report.IsTrue(new RecentActivities().ExpandRowByID(productID), "Failed to expand the first row", "The first row was expanded successfully");
        }

        [StepDefinition(@"In the Recent Activities page, I collapse the row for Product with ID: (.*)")]
        public void InTheRecentActivitiesPageICollapseRow(string productID)
        {
            if (productID.ToLower().Contains("recentproductdata"))
            {
                var productData = (RecentActivities.RecentProductData)Context.GetFromContext(productID);
                productID = productData.ID;
            }
            Report.IsTrue(new RecentActivities().CollapseRowByID(productID), "Failed to collapse the first row", "The first row was collapse successfully");
        }

        [StepDefinition(@"In the recent activities Page, In the Products table I confirm that all displayed results contain (.*) in their product name")]
        public void InTheRecentActivitiesPageInProductsTableConfirmAllProductNamesContain(string productName)
        {
           Report.IsTrue(new RecentActivities().ConfirmAllNamesContain(productName),"Not all products contained the search text","All product names contained the search text");
        }




        [StepDefinition(@"In the recent activities Page, In the Products table I confirm that all displayed results contain (.*) in their Supplier name")]
        public void InTheRecentActivitiesPageInProductsTableConfirmAllSupplierNamesContain(string productName)
        {
            if (productName.Contains("SavedProduct"))
            {
                productName = (string)Context.GetFromContext(productName);
            }
            Report.IsTrue(new RecentActivities().ConfirmAllSuppliers(productName), "Not all Suppliers contained the search text", "All Suppliers names contained the search text");
        }

        [StepDefinition(@"In the recent activities Page, In the Products table I confirm that all displayed results match the Supplier name (.*) exactly")]
        public void InTheRecentActivitiesPageInProductsTableConfirmAllSupplierNamesExact(string productName)
        {
            Report.IsTrue(new RecentActivities().ConfirmAllSuppliersMatchExactly(productName), "Not all Suppliers exactly matched the search text", "All Suppliers names exactly matched the search text");
        }


        [StepDefinition(@"In the recent activities Page, In the Products table I confirm that not all displayed results contain (.*) in their Supplier name")]
        public void InTheRecentActivitiesPageInProductsTableConfirmNotAllSupplierNamesContain(string productName)
        {
            if (productName.Contains("SavedProduct"))
            {
                productName = (string)Context.GetFromContext(productName);
            }
            Report.IsTrue(!new RecentActivities().ConfirmAllSuppliers(productName), "All Suppliers names contained the search text", "Not all Suppliers contained the search text");
        }

        [StepDefinition(@"In the recent activities Page, In the Products table I confirm that all displayed results show (.*) as their status")]
        public void InTheRecentActivitiesPageInProductsTableConfirmAllStatusShow(string status)
        {
            if (status.Contains("SavedProduct"))
            {
                status = (string)Context.GetFromContext(status);
            }
            Report.IsTrue(new RecentActivities().ConfirmAllStatus(status), "All Suppliers names contained the search text", "Not all Suppliers contained the search text");
        }


        [StepDefinition(@"In the recent activities Page, In the Products table I confirm that not all displayed results show (.*) as their status")]
        public void InTheRecentActivitiesPageInProductsTableConfirmNotAllStatusShow(string status)
        {
            Report.IsTrue(!new RecentActivities().ConfirmAllStatus(status), "Not all Suppliers contained the search text", "All Suppliers names contained the search text");
        }



        [StepDefinition(@"In the recent activities Page, I click the More Filters Button")]
        public void InTheRecentActivitiesPageIClickTheMoreFiltersOption()
        {
            Report.IsTrue(new RecentActivities().ClickMoreFiltersOptionButton(), "Failed to click the more filters button", "Successfully clicked the more filters button");
        }

        [StepDefinition(@"In the recent activities Page, The More Filters Popup is showing")]
        public void InTheRecentActivitiesPageIClickTheMoreFiltersPopupIsShowing()
        {
            Report.IsTrue(new RecentActivities.MoreFiltersPopup().WaitForContainerToBeVisible(),"The More filters popup was not showing","The More filters popup was showing");
        }

        [StepDefinition(@"In the recent activities Page, The More Filters Popup is not showing")]
        public void InTheRecentActivitiesPageIClickTheMoreFiltersPopupIsNotShowing()
        {
            Report.IsTrue(new RecentActivities.MoreFiltersPopup().WaitForContainerToBeInvisible(), "The More filters popup was showing","The More filters popup was not showing");
        }

        [StepDefinition(@"In the recent activities Page More Filters Popup, I check that the following filters fields exist:")]
        public void InTheRecentActivitiesPageMoreFiltersPopupCheckFiltersExist(Table table)
        {
            List<string> filters = new List<string>();
            foreach (TableRow thisRow in table.Rows)
            {
                filters.Add(thisRow["Filter"]);
            }
            foreach(var filter in filters)
            {
                Report.IsTrue(new RecentActivities.MoreFiltersPopup().FilterFieldExists(filter), "The filter: "+filter+" was not found", "The filter: " + filter + " was found");
            }
        }

        [StepDefinition(@"In the recent activities Page More Filters Popup, I check that the Cancel Button Exists")]
        public void InTheRecentActivitiesPageMoreFiltersPopupCheckCancelButtonExists()
        {
            Report.IsTrue(new RecentActivities.MoreFiltersPopup().CancelButtonIsPresent(), "The cancel button did not exists", "The cancel button exists");
        }

        [StepDefinition(@"In the recent activities Page More Filters Popup, I check that the Apply Filter Button Exists")]
        public void InTheRecentActivitiesPageMoreFiltersPopupCheckApplyFilterButtonExists()
        {
            Report.IsTrue(new RecentActivities.MoreFiltersPopup().ApplyFilterButtonIsPresent(), "The Apply Filter button did not exists", "The Apply Filter button exists");
        }

        [StepDefinition(@"In the recent activities Page More Filters Popup, I Click the the Cancel Button")]
        public void InTheRecentActivitiesPageMoreFiltersPopupClickCancelButton()
        {
            Report.IsTrue(new RecentActivities.MoreFiltersPopup().ClickCancelButton(), "The Cancel button was not clicked", "The Cancel button was clicked successfully");
        }

        [StepDefinition(@"In the recent activities Page More Filters Popup, I Click the the Apply Filter Button")]
        public void InTheRecentActivitiesPageMoreFiltersPopupClickApplyFilterButton()
        {
            Report.IsTrue(new RecentActivities.MoreFiltersPopup().ClickApplyFiltersButton(), "The Apply Filter button was not clicked", "The Apply Filter button was clicked successfully");
        }

        [StepDefinition(@"In the recent activities Page More Filters Popup, I check that the: (.*) field is a text input field")]
        public void InTheRecentActivitiesPageMoreFiltersPopupCheckThatFieldIsATextInput(string label)
        {
            Report.IsTrue(new RecentActivities.MoreFiltersPopup().FieldIsATextInputField(label), "The field was not a text input", "The field was a text input");
        }

        [StepDefinition(@"In the recent activities Page More Filters Popup, I check that the: (.*) field is a drop down field")]
        public void InTheRecentActivitiesPageMoreFiltersPopupCheckThatFieldIsADropDown(string label)
        {
            Report.IsTrue(new RecentActivities.MoreFiltersPopup().FieldIsADropDown(label), "The field was not a drop down", "The field was a drop down");
        }

        [StepDefinition(@"In the recent activities Page More Filters Popup, I check that the following status options exist:")]
        public void InTheRecentActivitiesPageMoreFiltersPopupCheckStatusOptionsExists(Table table)
        {
            List<string> options = new List<string>();
            foreach (TableRow thisRow in table.Rows)
            {
                options.Add(thisRow["Option"]);
            }
            foreach(var option in options)
            {
                Report.IsTrue(new RecentActivities.MoreFiltersPopup().StatusOptionPresent(option), "The option: "+option+" was not found in the list", "The option: " + option + " was found in the list");
            }
           
        }
                

        [StepDefinition(@"In the recent activities Page More Filters Popup, I click Start Date Input")]
        public void InTheRecentActivitiesPageMoreFiltersPopupIClickStartDateInput()
        {
            Report.IsTrue(new RecentActivities.MoreFiltersPopup().ClickStartDateInput(), "Failed to click outside of the calendar selector", "Successfully clicked outside of the calendar selector");
        }

        [StepDefinition(@"In the recent activities Page More Filters Popup, I click End Date Input")]
        public void InTheRecentActivitiesPageMoreFiltersPopupIClickEndDateInput()
        {
            Report.IsTrue(new RecentActivities.MoreFiltersPopup().ClickEndDateInput(), "Failed to click outside of the calendar selector", "Successfully clicked outside of the calendar selector");
        }

        [StepDefinition(@"In the recent activities Page More Filters Popup, I click outside of the calendar selector")]
        public void InTheRecentActivitiesPageMoreFiltersPopupIClickOutsideCalendarSelector()
        {
            Report.IsTrue(new RecentActivities.MoreFiltersPopup().ClickOutsideDatePicker(), "Failed to click outside of the calendar selector", "Successfully clicked outside of the calendar selector");
        }

        [StepDefinition(@"In the recent activities Page More Filters Popup, I Check the calendar selector is (Present|not Present)")]
        public void InTheRecentActivitiesPageMoreFiltersPopupICheckCalendarSelectorPresence(string presence)
        {
            if(presence=="Present")
            {
                Report.IsTrue(new RecentActivities.DatePickerDropDown().WaitForContainerToBeVisible(10), "The Calendar selector was not shown", "The Calendar selector was shown");
            }
            if(presence=="not Present")
            {
                Report.IsTrue(new RecentActivities.DatePickerDropDown().WaitForContainerToBeInvisible(10), "The Calendar selector was shown","The Calendar selector was not shown");

            }
        }

        [StepDefinition(@"In the recent activities Page More Filters Popup, In the (.*) field, I enter: (.*)")]
        public void InTheRecentActivitiesPageMoreFiltersPopupIEnterTextIntoInputField(string inputField, string value)
        {
            if(value.Contains("SavedProduct"))
            {
                value =(string)Context.GetFromContext(value);
            }
            Report.IsTrue(new RecentActivities.MoreFiltersPopup().EnterValueIntoInputField(value, inputField), "Failed to enter value", "Successfully entered value");
            
        }

        [StepDefinition(@"In the recent activities Page More Filters Popup, In the (.*) field, I enter part of: (.*) and save the partial text as: (.*)")]
        public void InTheRecentActivitiesPageMoreFiltersPopupIEnterPartialTextIntoInputField(string inputField, string value, string savedAs)
        {
            if (value.Contains("SavedProduct"))
            {
                value = (string)Context.GetFromContext(value);
            }
            string partialValue = value.Substring(0, value.Length / 2);
            Context.AddToContext(savedAs, partialValue);

            Report.IsTrue(new RecentActivities.MoreFiltersPopup().EnterValueIntoInputField(partialValue, inputField), "Failed to enter value", "Successfully entered value");
        }

        [StepDefinition(@"In the recent activities page, I click the Breadcrumb: (.*)")]
        public void InTheRecentActivitiesPageIClickTheBreadCrumb(string breadcrumb)
        {
            Report.IsTrue(new RecentActivities().ClickGivenBreadcrumb(breadcrumb), "Failed to click the given breadcrumb", "Successfully clicked the given breadcrumb");
            this.HomeTabLoaded();
        }

        [StepDefinition(@"In the recent activities page, I click the 'X' for Breadcrumb: (.*)")]
        public void InTheRecentActivitiesPageIClickTheBreadCrumbX(string breadcrumb)
        {
            Report.IsTrue(new RecentActivities().ClickGivenBreadcrumbRightSideX(breadcrumb), "Failed to click the x at the far right of the breadcrumb button", "Successfully clicked the x at the far right of the breadcrumb button");
            this.HomeTabLoaded();
        }

        [StepDefinition(@"In the recent activities page, I select the option: (.*) from the status drop down menu")]
        public void InTheRecentActivitiesPageISelectStatusOption(string option)
        {
            if (option.Contains("SavedProduct"))
            {
                option = (string)Context.GetFromContext(option);
            }
            Report.IsTrue(new RecentActivities.MoreFiltersPopup().SelectStatusOption(option), "The option was not selected","The option was selected successfully");
        }

        [StepDefinition(@"In the recent activities Page, I confirm the Start Date input field shows a date 18 months before today as default")]
        public void InTheRecentActivitiesPageConfirmStateDateInputShowsDate18MonthsInPast()
        {
            //Might need to convert the Today date to same timezone as RPS?
            string foundDate = new RecentActivities.MoreFiltersPopup().GetDisplayedStartDate();
            DateTime foundDateConvert = DateTime.Parse(foundDate);
            DateTime currentDate = DateTime.Today;
            string expectedDateString = foundDateConvert.AddMonths(18).ToString("MM-dd-yyyy");
            string currentDateString= currentDate.ToString("MM-dd-yyyy");
            Report.Info($"Todays date is: {currentDateString}");
            Report.Info($"The found date was: {foundDateConvert}");
            Report.Info($"For the found start date to be 18 months before the current date, the current date must be: {expectedDateString}");

            Report.IsTrue(currentDateString == expectedDateString, "The Start Date found in the input field was not 18 months before the current today", "The Start Date found in the input field was 18 months before the current today");

        }

        [StepDefinition(@"In the recent activities Page, I confirm the End Date input field shows todays date as default")]
        public void InTheRecentActivitiesPageConfirmEndDateInputShowsTodaysDate()
        {
            //Might need to convert the Today date to same timezone as RPS?
            string foundDate = new RecentActivities.MoreFiltersPopup().GetDisplayedEndDate();
            DateTime foundDateConvert = DateTime.Parse(foundDate);
            DateTime currentDate = DateTime.Today;
            string expectedDateString = foundDateConvert.ToString("MM-dd-yyyy");
            string currentDateString = currentDate.ToString("MM-dd-yyyy");
            Report.Info($"Todays date is: {currentDateString}");
            Report.Info($"The found date was: {foundDateConvert}");

            Report.IsTrue(currentDateString == expectedDateString, "The Start Date found in the input field was not todays Date", "The Start Date found in the input field was todays date");

        }


        [StepDefinition(@"In the recent activities Page More Filters Popup, In the Start Date selector I select the date: (.*)")]
        public void InTheRecentActivitiesPageMoreFiltersPopupISelectStartDate(string date)
        {            
            DateTime convertedDate=  DateTime.Parse(date);
            string Month = String.Format("{0:MMMM}", convertedDate);
            string day = String.Format("{0:dd}", convertedDate);
            string year = String.Format("{0:yyyy}", convertedDate);
            
            string inputMonthYear = Month + " " + year;
            string currentMonthYear = new RecentActivities.DatePickerDropDown().GetCurrentMonthAndYear();
            if (inputMonthYear == currentMonthYear)
            {
                Report.Success("The current Month Year was already the same as the date we were going to select, moving on");

            }
            else
            {
                string foundDate = new RecentActivities.MoreFiltersPopup().GetDisplayedStartDate();
                DateTime foundDateConvert = DateTime.Parse(foundDate);
                string direction = "";
                if (foundDateConvert < convertedDate)
                {
                    direction = "forwards";
                }
                else
                {
                    direction = "backwards";
                }
                bool monthYearCorrect = false;
                int x = 0;

                while (monthYearCorrect == false && x < 30)
                {
                    if(direction=="forwards")
                    {
                        Report.Info("Clicking the Forwards Month Button");
                        new RecentActivities.DatePickerDropDown().ClickNextMonthButton();
                    }
                    if(direction=="backwards")
                    {
                        Report.Info("Clicking the Backwards Month Button");
                        new RecentActivities.DatePickerDropDown().ClickPreviousMonthButton();
                    }
                    Delay.Seconds(0.5);
                    string updatedMonthYear = new RecentActivities.DatePickerDropDown().GetCurrentMonthAndYear();
                    if(updatedMonthYear== inputMonthYear)
                    {
                        Report.Success("The updated Month/Year matched to input Month/Year");
                        monthYearCorrect = true;
                    }
                    x++;

                }

                if(x==30)
                {
                    Report.Info("Total loops was 30, stopping increasing/decreasing the month to avoid infiite loop");
                }

                if(!monthYearCorrect)
                {
                    Report.Failure("The found month/year did not match the input");
                    return;                    
                }


            }

            Report.Info("Attempting to select Day...");
            Report.IsTrue(new RecentActivities.DatePickerDropDown().ClickCalendarDay(day), "Failed to click day", "Successfully clicked day");
            Delay.Seconds(2);
            string finalFoundDate =  new RecentActivities.MoreFiltersPopup().GetDisplayedStartDate();
            Report.Info($"The found final date was: {finalFoundDate}");
            Report.IsTrue(finalFoundDate == date, "The date found did not match the input date", "The date found matched the input date");
            


        }


        [StepDefinition(@"In the recent activities Page More Filters Popup, In the End Date selector I select the date: (.*)")]
        public void InTheRecentActivitiesPageMoreFiltersPopupISelectEndDate(string date)
        {           
            DateTime convertedDate = DateTime.Parse(date);    
            string Month = String.Format("{0:MMMM}", convertedDate);
            string day = String.Format("{0:dd}", convertedDate);
            string year = String.Format("{0:yyyy}", convertedDate);

            string inputMonthYear = Month + " " + year;
            string currentMonthYear = new RecentActivities.DatePickerDropDown().GetCurrentMonthAndYear();
            if (inputMonthYear == currentMonthYear)
            {
                Report.Success("The current Month Year was already the same as the date we were going to select, moving on");

            }
            else
            {
                string foundDate = new RecentActivities.MoreFiltersPopup().GetDisplayedEndDate();
                DateTime foundDateConvert = DateTime.Parse(foundDate);
                string direction = "";
                if (foundDateConvert < convertedDate)
                {
                    direction = "forwards";
                }
                else
                {
                    direction = "backwards";
                }
                bool monthYearCorrect = false;
                int x = 0;

                while (monthYearCorrect == false && x < 30)
                {
                    if (direction == "forwards")
                    {
                        Report.Info("Clicking the Forwards Month Button");
                        new RecentActivities.DatePickerDropDown().ClickNextMonthButton();
                    }
                    if (direction == "backwards")
                    {
                        Report.Info("Clicking the Backwards Month Button");
                        new RecentActivities.DatePickerDropDown().ClickPreviousMonthButton();
                    }
                    Delay.Seconds(0.5);
                    string updatedMonthYear = new RecentActivities.DatePickerDropDown().GetCurrentMonthAndYear();
                    if (updatedMonthYear == inputMonthYear)
                    {
                        Report.Success("The updated Month/Year matched to input Month/Year");
                        monthYearCorrect = true;
                    }
                    x++;

                }

                if (x == 30)
                {
                    Report.Info("Total loops was 30, stopping increasing/decreasing the month to avoid infiite loop");
                }

                if (!monthYearCorrect)
                {
                    Report.Failure("The found month/year did not match the input");
                    return;
                }


            }

            Report.Info("Attempting to select Day...");
            Report.IsTrue(new RecentActivities.DatePickerDropDown().ClickCalendarDay(day), "Failed to click day", "Successfully clicked day");
            Delay.Seconds(2);
            string finalFoundDate = new RecentActivities.MoreFiltersPopup().GetDisplayedEndDate();
            Report.Info($"The found final date was: {finalFoundDate}");
            Report.IsTrue(finalFoundDate == date, "The date found did not match the input date", "The date found matched the input date");
                       
        }


        [StepDefinition(@"In the recent activities Page More Filters Popup, I click the Enter Key")]
        public void InTheRecentActivitiesPageMoreFiltersPopupIClickTheEnterKey()
        {
            new RecentActivities.MoreFiltersPopup().ApplyFilterButton.SendKeys(Keys.Enter);
            this.InTheRecentActivitiesPageIClickTheMoreFiltersPopupIsNotShowing();
        }

        [StepDefinition(@"In the recent activities Page, In the Products table I select a random product and save the supplier name to context as: (.*)")]
        public void InTheRecentActivitiesPageInProductsTableISelectRandomProductsAndSaveSupplierNameAs(string savedAs)
        {
            string iD = GeneralUtilities.SelectRandomFromListOfStrings(new RecentActivities().GetCurrentProductIDs());
            string currentData = new RecentActivities().GetColumValueByID("Supplier", iD);
            Context.AddToContext(savedAs, currentData);
        }

        [StepDefinition(@"In the recent activities Page, In the Products table I select a random product with where the supplier contains: (.*) and save the supplier name to context as: (.*)")]
        public void InTheRecentActivitiesPageInProductsTableISelectRandomProductsAndSaveSupplierNameAsIfContains(string value, string savedAs)
        {
            int x = 0;
            while ( x<9)
            {
                string iD = GeneralUtilities.SelectRandomFromListOfStrings(new RecentActivities().GetCurrentProductIDs());
                string currentData = new RecentActivities().GetColumValueByID("Supplier", iD);
                if(currentData.Contains(value))
                {
                    Report.Success($"Found a supplier: {currentData} which contains: {value}");
                    Context.AddToContext(savedAs, currentData);                   
                    return;
                }
                x++;


            }
            Report.Failure($"Did not find a product which contained the value: {value} in the supplier name");            
           
        }

        [StepDefinition(@"In the recent activities Page, I confirm the Start Date breadcrumb shows a date 6 months before today as default")]
        public void InTheRecentActivitiesPageConfirmStateDateBreadcrumbShowsDate6MonthsInPast()
        {
            //Might need to convert the Today date to same timezone as RPS?
            string foundDate = new RecentActivities().GetDisplayedStartDateFromBreadcrumb();

            DateTime foundDateConvert = DateTime.Parse(foundDate);
            DateTime currentDate = DateTime.Today;
            string expectedDateString = foundDateConvert.AddMonths(6).ToString("MM-dd-yyyy");
            string currentDateString = currentDate.ToString("MM-dd-yyyy");
            Report.Info($"Todays date is: {currentDateString}");
            Report.Info($"The found date was: {foundDateConvert}");
            Report.Info($"For the found start date to be 6 months before the current date, the current date must be: {expectedDateString}");
            Report.IsTrue(currentDateString == expectedDateString, "The Start Date found in the input field was not 6 months before the current today", "The Start Date found in the input field was 6 months before the current today");

        }

        [StepDefinition(@"In the recent activities Page, I confirm the End Date breadcrumb shows todays date as default")]
        public void InTheRecentActivitiesPageConfirmEndDatebreadcrumbShowsTodaysDate()
        {
            //Might need to convert the Today date to same timezone as RPS?
            string foundDate = new RecentActivities().GetDisplayedEndDateFromBreadcrumb();


            DateTime foundDateConvert = DateTime.Parse(foundDate);
            DateTime currentDate = DateTime.Today;
            string expectedDateString = foundDateConvert.ToString("MM-dd-yyyy");
            string currentDateString = currentDate.ToString("MM-dd-yyyy");
            Report.Info($"Todays date is: {currentDateString}");
            Report.Info($"The found date was: {foundDateConvert}");

            Report.IsTrue(currentDateString == expectedDateString, "The Start Date found in the input field was not todays Date", "The Start Date found in the input field was todays date");

        }

        [StepDefinition(@"In the recent activities Page, In the Products table I select the first product and save the supplier name to context as: (.*)")]
        public void InTheRecentActivitiesPageInProductsTableISelectFirstProductsAndSaveSupplierNameAs(string savedAs)
        {
            string iD = new RecentActivities().FirstProductInGridID();
            string currentData = new RecentActivities().GetColumValueByID("Supplier", iD);
            Context.AddToContext(savedAs, currentData);
        }

        [StepDefinition(@"In the recent activities Page, In the Products table I select the first product and save the status to context as: (.*)")]
        public void InTheRecentActivitiesPageInProductsTableISelectFirstProductsAndSaveStatusNameAs(string savedAs)
        {
            string iD = new RecentActivities().FirstProductInGridID();
            string currentData = new RecentActivities().GetColumValueByID("Status", iD);
            Context.AddToContext(savedAs, currentData);
        }

        [StepDefinition(@"In the recent activities Page, In the Products table I click the Reset Breadcrumb")]
        public void InTheRecentActivitiesPageInProductsTableIClickResetBreadCrumb()
        {
            Report.IsTrue(new RecentActivities().ClickResetBreadCrumb(), "Failed to click the reset breadcrumb", "Successfully clicked the reset breadcrumb");
            this.HomeTabLoaded();
        }

        [StepDefinition(@"In the recent activities Page, In the Products table Breadcrumb area only Start Date and End Date labels are shown")]
        public void InTheRecentActivitiesPageInProductsTableOnlyStartAndEndDateBreadcrumbsShown()
        {
            string expectedFullText = "";
            string startDateLabel = "";
            string endDateLabel = "";

            DateTime currentDate = DateTime.Today;
            string expectedDateString = currentDate.AddMonths(-6).ToString("MM/dd/yyyy");
            string currentDateString = currentDate.ToString("MM/dd/yyyy");
            startDateLabel = "Start Date: " + "\"" + expectedDateString + "\"";
            endDateLabel= "End Date: " + "\"" + currentDateString + "\"";
            expectedFullText = "Filters: " + startDateLabel + " "+ endDateLabel + " Reset";

            Report.IsTrue(new RecentActivities().ConfirmBreadCrumbAreaMatchesLabel(expectedFullText), "The Bread crumb area did not only contain the Start and End Date Breadcrumbs", "The Bread crumb area only contained the Start and End Date Breadcrumbs");

        }

        [StepDefinition(@"In the recent activities Page, In the Products table I select the second product and save the supplier name to context as: (.*)")]
        public void InTheRecentActivitiesPageInProductsTableISelectSecondProductsAndSaveSupplierNameAs(string savedAs)
        {
            string iD = new RecentActivities().SecondProductInGridID();
            string currentData = new RecentActivities().GetColumValueByID("Supplier", iD);
            Context.AddToContext(savedAs, currentData);
        }


        [StepDefinition(@"In the recent activities Page, In the Products table I select the second product and save the status to context as: (.*)")]
        public void InTheRecentActivitiesPageInProductsTableISelectSecondProductsAndSaveStatusNameAs(string savedAs)
        {
            string iD = new RecentActivities().SecondProductInGridID();
            string currentData = new RecentActivities().GetColumValueByID("Status", iD);
            Context.AddToContext(savedAs, currentData);
        }

        [StepDefinition(@"In the recent activities Page, In the Products table I confirm that all displayed results have (.*) as their Product ID")]
        public void InTheRecentActivitiesPageInProductsTableConfirmAllProductIDsMatch(string productID)
        {
            if (productID.Contains("SavedProduct"))
            {
                productID = (string)Context.GetFromContext(productID);
            }
            if (productID.ToLower().Contains("recentproductdata"))
            {
                var productData = (RecentActivities.RecentProductData)Context.GetFromContext(productID);
                productID = productData.ID;
            }

            Report.IsTrue(new RecentActivities().ConfirmAllIDsMatch(productID), "Not all IDs contained the search text", "All IDs contained the search text");
        }


        [StepDefinition(@"In the recent activities Page, In the Products table I confirm that Not all displayed results have (.*) as their Product ID")]
        public void InTheRecentActivitiesPageInProductsTableConfirmNotAllProductIDsMatch(string productID)
        {
            if (productID.Contains("SavedProduct"))
            {
                productID = (string)Context.GetFromContext(productID);
            }
            if (productID.ToLower().Contains("recentproductdata"))
            {
                var productData = (RecentActivities.RecentProductData)Context.GetFromContext(productID);
                productID = productData.ID;
            }
            Report.IsTrue(!new RecentActivities().ConfirmAllIDsMatch(productID), "All IDs contained the search text", "Not all IDs contained the search text");
        }

        [StepDefinition(@"In the recent activities Page, I save all the Results to context as: (.*)")]
        public void InTheRecentActivitiesPageInProductsTableISaveAllTheResultsToContextAs(string savedAs)
        {

           var allFoundIds =  new RecentActivities().GetCurrentProductIDs();
           List<RecentActivities.RecentProductData> currentResults = new List<RecentActivities.RecentProductData>();

            foreach(var item in allFoundIds)
            {
                Report.Info($"Attempting to get and save the data for the result with ID:{item}");
                RecentActivities.RecentProductData currentData = new RecentActivities().GetRecentProductDataByID(item);
                currentResults.Add(currentData);
            }
            Report.Info($"All Results saved, saving the list to context as: {savedAs}");
            Context.AddToContext(savedAs, currentResults);
        }

        [StepDefinition(@"In the recent activities Page, I check the current results (match|do not match) the results saved as (.*)")]
        public void InTheRecentActivitiesPageInProductsTableICheckTheCurrentResultsMatchTheResultsSavedAs(string matching, string savedAs)
        {

            var allFoundIds = new RecentActivities().GetCurrentProductIDs();
            List<RecentActivities.RecentProductData> currentResults = new List<RecentActivities.RecentProductData>();

            foreach (var item in allFoundIds)
            {
                Report.Info($"Attempting to get and save the data for the result with ID:{item}");
                RecentActivities.RecentProductData currentData = new RecentActivities().GetRecentProductDataByID(item);
                currentResults.Add(currentData);
                Report.Screenshot();
            }

            var savedResults = (List<RecentActivities.RecentProductData>)Context.GetFromContext(savedAs);
            int x = 0;
            if (matching == "match")
            {
                foreach (var result in savedResults)
                {
                    Report.Info($"Comparing item number {x + 1} in each list");
                    Report.IsTrue(result.Equals(currentResults[x]), "The Result did not match", "The Result matched");
                    if (!result.Equals(currentResults[x]))
                    {
                        Report.Info($"The saved Results was ID: {result.ID} and the current Result was ID: {currentResults[x].ID}");
                    }
                    x++;

                }
            }
            if(matching=="do not match")
            {
                foreach (var result in savedResults)
                {
                    Report.Info($"Comparing item number {x + 1} in each list");
                    Report.IsTrue(!result.Equals(currentResults[x]),"The Result matched", "The Result did not match");
                    if (result.Equals(currentResults[x]))
                    {
                        Report.Info($"The saved Results was ID: {result.ID} and the current Result was ID: {currentResults[x].ID}");
                    }
                    x++;
                }
            }
          
        }


        [StepDefinition(@"In the recent activities Page, I click the Export To Excel Button")]
        public void InTheRecentActivitiesPageIClickTheExportToExcelButton()
        {
            Report.IsTrue(new RecentActivities().ClickExportToExcelButton(), "Failed to click the Export To Excel button", "Successfully clicked the Export To Excel button");
        }

        [StepDefinition(@"In the recent activities Page, The Export to Excel Popup is showing")]
        public void InTheRecentActivitiesPageIClickTheExportToExcelPopupIsShowing()
        {
            Report.IsTrue(new RecentActivities.ExportToExcelPopup().WaitForContainerToBeVisible(), "The Export to Excel popup was not showing", "The Export to Excel popup was showing");
        }

        [StepDefinition(@"In the recent activities Page, The Export to Excel Popup is not showing")]
        public void InTheRecentActivitiesPageIClickTheExportToExcelPopupIsNotShowing()
        {
            Report.IsTrue(new RecentActivities.ExportToExcelPopup().WaitForContainerToBeInvisible(), "The Export to Excel popup was showing", "The Export to Excel popup was not showing");
        }

        [StepDefinition(@"In the recent activities Page, In the Export to Excel popup I Confirm the header text reads: (.*)")]
        public void InTheRecentActivitiesPageInTheExportToExcelPopupIConfirmHeaderTextReads(string expectedText)
        {
            var titleText = new RecentActivities.ExportToExcelPopup().GetHeaderTitleText();

            Report.IsTrue(titleText==expectedText,"The header text did not match", "The header text matched");
        }

        [StepDefinition(@"In the recent activities Page, In the Export to Excel popup I Confirm the 'x' Close icon is shown")]
        public void InTheRecentActivitiesPageInTheExportToExcelPopupIConfirmTheXCloseiconIsShown()
        {
            Report.IsTrue(new RecentActivities.ExportToExcelPopup().HeaderCrossFound(), "The Header Cross was not found", "The Header Cross was found");

        }

        [StepDefinition(@"In the recent activities Page, In the Export to Excel popup I Confirm the main body text reads: (.*)")]
        public void InTheRecentActivitiesPageInTheExportToExcelPopupIConfirmTheMainBodyTextReads(string expectedText)
        {
            var bodyText = new RecentActivities.ExportToExcelPopup().GetBodyText();
            Report.Info($"The found body text was: {bodyText}");

            Report.IsTrue(bodyText == expectedText, "The main body text did not match", "The main body text matched");

        }

        [StepDefinition(@"In the recent activities Page, In the Export to Excel popup I Confirm the Export to Excel Button shows")]
        public void InTheRecentActivitiesPageInTheExportToExcelPopupIConfirmTHeExportToExcelButtonShows()
        {
            Report.IsTrue(new RecentActivities.ExportToExcelPopup().ExportButtonFound(), "The Export to Excel Button  was not found", "The Export to Excel Button  was not found");

        }

        [StepDefinition(@"In the recent activities Page, In the Export to Excel popup I Confirm the Export Button text reads: (.*)")]
        public void InTheRecentActivitiesPageInTheExportToExcelPopupIConfirmTheExportButtontReads(string expectedText)
        {
            var buttonText = new RecentActivities.ExportToExcelPopup().GetExportButtonText();
            Report.Info($"The found Export Button text was: {buttonText}");

            Report.IsTrue(buttonText == expectedText, "The Export Button Text did not match", "The Export Button Text text matched");

        }

        [StepDefinition(@"In the recent activities Page, In the Export to Excel popup footer I confirm there is only 1 button shown")]
        public void InTheRecentActivitiesPageInTheExportToExcelPopupFooterIConfirmThereIsOnly1ButtonShown()
        {
           
            var footerButtons = new RecentActivities.ExportToExcelPopup().GetAllFooterButtons();
            Report.IsTrue(footerButtons.Count==1,"There was not 1 footer button","There was 1 footer button");               

        }

        [StepDefinition(@"In the recent activities Page, In the Export to Excel popup footer I confirm the Close button is shown")]
        public void InTheRecentActivitiesPageInTheExportToExcelPopupFooterIConfirmTheCloseButtonIsShown()
        {
            var footerButtons = new RecentActivities.ExportToExcelPopup().GetAllFooterButtons();
            var buttonText = footerButtons.First().Text;
            Report.IsTrue(buttonText=="Close", "The Close Button was not found", "The Close Button was found");

        }

        [StepDefinition(@"In the recent activities Page, In the Export to Excel popup I click away from the export pop up")]
        public void InTheRecentActivitiesPageInTheExportToExcelPopupIClickAwayFromTheExportPopupUp()
        {
            Report.Info($"Attempting to click away from the popup");            
            Actions action = new Actions(SeleniumBrowser.WebBrowser);
            action.MoveByOffset(200, 200).Perform();
            Thread.Sleep(10000);
            action.Click();
            action.Perform();            

        }

        [StepDefinition(@"In the recent activities Page, In the Export to Excel popup footer I click Close")]
        public void InTheRecentActivitiesPageInTheExportToExcelPopupFooterIClickCloseButton()
        {
            Report.IsTrue(new RecentActivities.ExportToExcelPopup().ClickCloseButton(), "Failed to Click Close", "Successfully clicked Close");

        }

        [StepDefinition(@"In the recent activities Page, In the Export to Excel popup I click the 'x' Close icon")]
        public void InTheRecentActivitiesPageInTheExportToExcelPopupIClickXCloseIcon()
        {
            Report.IsTrue(new RecentActivities.ExportToExcelPopup().ClickHeaderCross(), "Failed to Click the 'x' Close icon", "Successfully clicked the 'x' Close icon");

        }

        [StepDefinition(@"In the recent activities Page, In the Export to Excel popup I click the Export All Values")]
        public void InTheRecentActivitiesPageInTheExportToExcelPopupIClickExportAllValues()
        {
            Report.IsTrue(new RecentActivities.ExportToExcelPopup().ClickExportAllValues(), "Failed to Click Export All Values", "Successfully clicked Export All Values");

        }

        [StepDefinition(@"In the recent activities Page, I confirm the Products shown in the export file saved as: (.*)  match the products saved as: (.*)")]
        public void InTheRecentActivitiesPageIConfirmProductsInExportFileMatchSavedProducts(string fileSavedAs, string valuesSavedAs)
        {
                 
            var savedProducts = (List<RecentActivities.RecentProductData>)Context.GetFromContext(valuesSavedAs);
            
   

            string File = Context.GetFromContext(fileSavedAs)?.ToString() ?? "";
            var lines = System.IO.File.ReadAllLines(File);

           

            List<string> foundProductIDs = new List<string>();
            List<string> previouslyCheckedUpcs = new List<string>();

            for (int i = 1; i < lines.Count(); i++)
            {
               // var lineValues = lines[i].Split(',');
                string[] lineValues = Regex.Matches(lines[i], @"(""[^""]*""|[^,])+").Cast<Match>().Select(m => m.Value).ToArray();
                List<string> currentRowRawValues = new List<string>();                
                foreach(var thing in lineValues)
                {
                    MatchCollection mc = Regex.Matches(thing, "\"([^\"]*)\"");
                    for (int z = 0; z < mc.Count; z++)
                    {                      
                       var testVal = mc[z].ToString();
                       string rawValue = mc[z].ToString().Replace("\"", "");
                       string replacement = Regex.Replace(rawValue, @"\t|\n|\r", "");
                       currentRowRawValues.Add(replacement);
                    }                            
                }
                string[] currentRowArray = currentRowRawValues.ToArray();                
                if(currentRowArray.Last() =="")
                {
                    currentRowArray = currentRowArray.Where(w => w != currentRowArray.Last()).ToArray();
                }               
                    
                var productNumber = currentRowArray[0];
                var productName = currentRowArray[1];
                var upcNumbers = currentRowArray[2];
                var statusValues = currentRowArray[3];
                var emailAddresses = currentRowArray[4];
                var recentActivityDates = currentRowArray[5];
                var supplierNames = currentRowArray[6];
                var kitProduct = currentRowArray[7];
                var archived = currentRowArray[8];

              

                if (!foundProductIDs.Contains(productNumber))
                {
                    foundProductIDs.Add(productNumber);
                    Report.Info($"Adding product number: {productNumber} to the list of found products");
                    previouslyCheckedUpcs.Add(upcNumbers);
                    Report.Info($"Adding the Upc: {upcNumbers} to the list of seen UPCS");
                }
                else
                {
                    Report.Info($"The product number: {productNumber} was already in the list");
                    if(previouslyCheckedUpcs.Contains(upcNumbers))
                    {
                        Report.Failure($"The upc number: {upcNumbers} was already checked, either the upc number is a duplicate or the same data entry is being checked again!");
                    }
                    else
                    {
                        previouslyCheckedUpcs.Add(upcNumbers);
                        Report.Info($"Adding the Upc: {upcNumbers} to the list of seen UPCS");
                    }

                }

                bool productFound = true;
                try
                {
                    var wantedProduct = savedProducts.First(x => x.ID == productNumber);
                    Report.Info("Starting Product Checks");
                }
                catch
                {
                    Report.Failure($"The Product with ID: {productNumber} was not found in the list of saved products (was not in the grid)");
                }

                if (productFound == true)
                {
                    var wantedProduct = savedProducts.First(x => x.ID == productNumber);

                    Report.Info($"Saved product number: {wantedProduct.ID}");
                    Report.Info($"File product number: {productNumber}");
                    Report.IsTrue(wantedProduct.ID == productNumber, "The product number did not match", "The product number matched");

                    Report.Info($"Saved Product name: {wantedProduct.ProductName}");
                    Report.Info($"File Product name: {productName}");
                    Report.IsTrue(wantedProduct.ProductName == productName, "The Product name did not match", "The Product name matched");

                    Report.Info($"Saved UPC number(s): {string.Join(", ", wantedProduct.UPC)}");
                    Report.Info($"File UPC number: {upcNumbers}");
                    Report.IsTrue(wantedProduct.UPC.Contains(upcNumbers), "The UPC number did not match", "The UPC number matched");

                    Report.Info($"Saved status: {wantedProduct.Status}");
                    Report.Info($"File status: {statusValues}");
                    Report.IsTrue(wantedProduct.Status == statusValues, "The status did not match", "The status matched");

                    Report.Info($"Saved Most Recent Activity Date: {wantedProduct.MostRecentActivity}");
                    Report.Info($"File Most Recent Activity Date: {recentActivityDates}");
                    var fileToDate = Convert.ToDateTime(recentActivityDates);
                    var convertedDate = fileToDate.ToString("yyyy-MM-dd");
                    Report.IsTrue(wantedProduct.MostRecentActivity == convertedDate, "The Most Recent Activity Date did not match", "The Most Recent Activity Date matched");

                    Report.Info($"Saved Most Recent Activity Date: {wantedProduct.Supplier}");
                    Report.Info($"File Most Recent Activity Date: {supplierNames}");
                    Report.IsTrue(wantedProduct.Supplier == supplierNames, "The Most Recent Activity Date did not match", "The Supplier Name matched");

                    Report.Info($"Finished Checking Product");
                }
                

             
            }

            Report.Info($"There are no more products to check in the csv file");


            var allSavedProductIDs = new List<string>();
            foreach(var el in savedProducts)
            {
                allSavedProductIDs.Add(el.ID);
            }

            var differences = allSavedProductIDs.Except(foundProductIDs);


            Report.IsTrue(differences.IsNullOrEmpty(), "There was additional products found in the grid that were not in the file (accounting for mulitple UPCs)", "There was no additional products found in the grid that were not in the file (accounting for mulitple UPCs)");


        }

        [StepDefinition(@"In the recent activities Page, I click the Legend Status Button")]
        public void InTheRecentActivitiesPageIClickTheLegendStatusButton()
        {
            Report.IsTrue(new RecentActivities().ClickLegendStatusButton(), "Failed to click the Legend Status button", "Successfully clicked the Legend To Status button");
        }

        [StepDefinition(@"In the recent activities Page, The Status Column Key Popup is showing")]
        public void InTheRecentActivitiesPageIClickTheStatusColumnKeyPopupIsShowing()
        {
            Report.IsTrue(new RecentActivities.StatusColumnKeyPopup().WaitForContainerToBeVisible(), "The Status Column Key popup was not showing", "The Status Column Key popup was showing");
        }

        [StepDefinition(@"In the recent activities Page, In the Status Column Key popup I Confirm the header text reads: (.*)")]
        public void InTheRecentActivitiesPageInTheStatusColumnKeyPopupIConfirmHeaderTextReads(string expectedText)
        {
            var titleText = new RecentActivities.StatusColumnKeyPopup().GetHeaderTitleText();

            Report.IsTrue(titleText == expectedText, "The header text did not match", "The header text matched");
        }

        [StepDefinition(@"In the recent activities Page, In the Status Column Key popup I Confirm the 'x' Close icon is shown")]
        public void InTheRecentActivitiesPageInTheStatusColumnKeyPopupIConfirmTheXCloseiconIsShown()
        {
            Report.IsTrue(new RecentActivities.StatusColumnKeyPopup().HeaderCrossFound(), "The Header Cross was not found", "The Header Cross was found");

        }

        [StepDefinition(@"In the recent activities Page, In the Status Column Key popup I Confirm the section: (.*) has description text: (.*)")]
        public void InTheRecentActivitiesPageInTheStatusColumnKeyPopupIConfirmSectionXHasMatchingDescription(string section, string expectedDescription)
        {
            var foundDescription = new RecentActivities.StatusColumnKeyPopup().GetDescriptionForStatusSection(section);
            Report.Info($"Expected Description was: {expectedDescription}");
            Report.Info($"Found Description was: {foundDescription}");

            Report.IsTrue(foundDescription==expectedDescription, "The descriptions did not match", "The descriptions matched");

        }

        [StepDefinition(@"In the recent activities Page, In the Status Column Key popup footer I click Close")]
        public void InTheRecentActivitiesPageInTheStatusColumnKeyPopupFooterIClickCloseButton()
        {
            Report.IsTrue(new RecentActivities.StatusColumnKeyPopup().ClickCloseButton(), "Failed to Click Close", "Successfully clicked Close");

        }

        [StepDefinition(@"In the recent activities Page, The Status Column Key popup is not showing")]
        public void InTheRecentActivitiesPageIClickTheStatusColumnKeyPopupIsNotShowing()
        {
            Report.IsTrue(new RecentActivities.StatusColumnKeyPopup().WaitForContainerToBeInvisible(), "The Status Column Key popup was showing", "The Status Column Key popup was not showing");
        }

        [StepDefinition(@"In the recent activities Page, I confirm for all products the Action column includes: Contact Supplier")]
        public void InTheRecentActivitiesPageIConfirmForAllProductsActionsColumnContainsContactSupplier()
        {
            Report.IsTrue(new RecentActivities().CheckAllProductsContainContactSupplierInActionsColumn(), "Not all rows contained the text: 'Contact Supplier'", "All rows contained the text: 'Contact Supplier'");
        }

        [StepDefinition(@"In the recent activities Page, I confirm for all products the Action column includes option: (.*)")]
        public void InTheRecentActivitiesPageIConfirmForAllProductsActionsColumnContainsGivenOption(string value)
        {
            Report.IsTrue(new RecentActivities().CheckAllProductsContaisGivenOptionInActionsColumn(value), $"Not all rows contained the text: '{value}'", $"All rows contained the text: '{value}'");
        }

        [StepDefinition(@"In the recent activities Page, I confirm for all products the Action column does not include option: (.*)")]
        public void InTheRecentActivitiesPageIConfirmForAllProductsActionsColumnDoesNotContainGivenOption(string value)
        {
            Report.IsTrue(new RecentActivities().CheckAllProductsDoNotContainGivenOptionInActionsColumn(value), $"At least 1 row contained the text: '{value}'", $"None of the rows contained the text: '{value}'");
        }

        [StepDefinition(@"In the recent activities Page, In the Products table I select the first product and save the Product Information to context as: (.*)")]
        public void InTheRecentActivitiesPageInProductsTableISelectFirstProductAndSaveProductInformationAs(string savedAs)
        {
            
            string iD = new RecentActivities().FirstProductInGridID();
            RecentActivities.RecentProductData currentData = new RecentActivities().GetRecentProductDataByID(iD);
            Context.AddToContext(savedAs, currentData);
        }

        [StepDefinition(@"In the recent activities Page, I Click the Row actions: (.*) for the first product in the Products Grid")]
        public void InTheRecentActivitiesPageInProductsTableIClickRowActionForFirstProduct(string action)
        {
            Report.IsTrue(new RecentActivities().ClickActionForFirstResultInGrid(action), "Failed to click the action for the first product", "Successfully clicked the action for the first product");
        }

        [StepDefinition(@"In the recent activities Page, I Click the Row actions: (.*) for the product: (.*)")]
        public void InTheRecentActivitiesPageInProductsTableIClickRowActionForGivenProduct(string action, string productID)
        {

            if (productID.ToLower().Contains("recentproductdata"))
            {
                var productData = (RecentActivities.RecentProductData)Context.GetFromContext(productID);
                productID = productData.ID;
            }
            Report.IsTrue(new RecentActivities().ClickActionForGivenProductInResultsGrid(productID,action), "Failed to click the action for the first product", "Successfully clicked the action for the first product");
        }

        [StepDefinition(@"In the Recent Activity Page, I Click Away from the Product Information Popup")]
        public void InTheRecentActivitiesPageInTheProductInformationPopupIClickAway()
        {
            Report.Info($"Attempting to click away from the popup");
            Actions action = new Actions(SeleniumBrowser.WebBrowser);
            action.MoveByOffset(300, 300).Perform();
            Thread.Sleep(10000);
            action.Click();
            action.Perform();

        }








    }
}