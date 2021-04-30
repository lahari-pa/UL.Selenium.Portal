using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Castle.Core.Internal;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using UL.Automation.Reporting.Functions;
using UL.Automation.SpecFlow.Classes;
using UL.Selenium.Portal.RPS.Classes;
using UL.Selenium.Portal.RPS.Selenium_Classes;
using UL.Selenium.Portal.WERCSmart.Classes;

namespace UL.Selenium.Portal.RPS.Steps
{
    [Binding, Scope(Tag = "DrumLog")]
    class Steps_DrumLog
    {

        [StepDefinition(@"I confirm the Drum Log tab has loaded")]
        [StepDefinition(@"I confirm the Drum Log page refreshes")]
        public void HomeTabLoaded()
        {
            Report.IsTrue(new TopBar().WaitForContainerToBeVisible(), "Top bar did not load!");
            GeneralUtilities.WaitForLoadingToFinish();
            new DrumLog().WaitDrumLogWidgetSpinnerFinish();
            new Steps_Navigation().ConfirmActiveTab("Drum Log");
            Report.IsTrue(new DrumLog().WaitForContainerToBeVisible(), "Page content did not load", "Page content loaded");
        }

        [StepDefinition(@"In the Drum Log Page, I click the More Filters Button")]
        public void InTheDrumLogPageIClickTheMoreFiltersOption()
        {
            Report.IsTrue(new DrumLog().ClickMoreFiltersOptionButton(), "Failed to click the more filters button", "Successfully clicked the more filters button");
        }




        [StepDefinition(@"In the Drum Log Page, The More Filters Popup is showing")]
        public void InTheDrumLogPageIClickTheMoreFiltersPopupIsShowing()
        {
            Report.IsTrue(new DrumLog.MoreFiltersPopup().WaitForContainerToBeVisible(), "The More filters popup was not showing", "The More filters popup was showing");
        }

        [StepDefinition(@"In the Drum Log Page, The More Filters Popup is not showing")]
        public void InTheDrumLogPageIClickTheMoreFiltersPopupIsNotShowing()
        {
            Report.IsTrue(new DrumLog.MoreFiltersPopup().WaitForContainerToBeInvisible(), "The More filters popup was showing", "The More filters popup was not showing");
        }

        [StepDefinition(@"In the Drum Log Page More Filters Popup, I check that the following filters fields exist:")]
        public void InTheDrumLogPageMoreFiltersPopupCheckFiltersExist(Table table)
        {
            List<string> filters = new List<string>();
            foreach (TableRow thisRow in table.Rows)
            {
                filters.Add(thisRow["Filter"]);
            }
            foreach (var filter in filters)
            {
                Report.IsTrue(new DrumLog.MoreFiltersPopup().FilterFieldExists(filter), "The filter: " + filter + " was not found", "The filter: " + filter + " was found");
            }
        }

        [StepDefinition(@"In the Drum Log Page More Filters Popup, I check that the Cancel Button Exists")]
        public void InTheDrumLogPageMoreFiltersPopupCheckCancelButtonExists()
        {
            Report.IsTrue(new DrumLog.MoreFiltersPopup().CancelButtonIsPresent(), "The cancel button did not exists", "The cancel button exists");
        }

        [StepDefinition(@"In the Drum Log Page More Filters Popup, I check that the Apply Filter Button Exists")]
        public void InTheDrumLogPageMoreFiltersPopupCheckApplyFilterButtonExists()
        {
            Report.IsTrue(new DrumLog.MoreFiltersPopup().ApplyFilterButtonIsPresent(), "The Apply Filter button did not exists", "The Apply Filter button exists");
        }

        [StepDefinition(@"In the Drum Log Page More Filters Popup, I Click the the Cancel Button")]
        public void InTheDrumLogPageMoreFiltersPopupClickCancelButton()
        {
            Report.IsTrue(new DrumLog.MoreFiltersPopup().ClickCancelButton(), "The Cancel button was not clicked", "The Cancel button was clicked successfully");
        }

        [StepDefinition(@"In the Drum Log Page More Filters Popup, I Click the the Apply Filter Button")]
        public void InTheDrumLogPageMoreFiltersPopupClickApplyFilterButton()
        {
            Report.IsTrue(new DrumLog.MoreFiltersPopup().ClickApplyFiltersButton(), "The Apply Filter button was not clicked", "The Apply Filter button was clicked successfully");
        }






        [StepDefinition(@"In the Drum Log Page More Filters Popup, I check that the: (.*) field is a drop down field")]
        public void InTheDrumLogPageMoreFiltersPopupCheckThatFieldIsADropDown(string label)
        {
            Report.IsTrue(new DrumLog.MoreFiltersPopup().FieldIsADropDown(label), "The field was not a drop down", "The field was a drop down");


        }

        [StepDefinition(@"In the Drum Log page, I select the option: (.*) from the: (.*) drop down menu")]
        public void InTheDrumLogPageISelectStatusOption(string option, string section)
        {
            if (option.Contains("SavedProduct"))
            {
                option = (string)Context.GetFromContext(option);
            }
            Report.IsTrue(new DrumLog.MoreFiltersPopup().SelectDropDownOptionForSection(option, section), "The option was not selected", "The option was selected successfully");
        }


        [StepDefinition(@"In the  Drum Log  page, I Verify page refreshes in the background with a new row called: (.*)")]
        public void InTheRecentActivitiesPageISelectStatusOption(string rowName)
        {
            Report.Failure("Can not automate currently, as there is no row");
        }

        [StepDefinition(@"In the Drum Log page, I Verify page refreshes in the background with a new row called: (.*)")]
        public void InTheDrumLogPageIVerifyBreadCrumbs(string rowName)
        {
            Report.Failure("Can not automate currently, as there is no row");
        }

        [StepDefinition(@"I confirm that the Drum Log page bread crumb area contains the label: (.*)")]
        public void IConfirmThatTheDrumLogPageBreadCrumbAreaContainsLabel(string label)
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
            Report.IsTrue(new DrumLog().ConfirmBreadCrumbAreaContainsLabel(label), "The Bread crumb area did not contain the label", "The bread crumb are contained the label");
        }

        [StepDefinition(@"I confirm the Drum Log Page background color is: grey")]
        public void ConfirmDrumLogBackgroundColorIsGrey()
        {

            string expectedColorString = "rgba(240, 243, 245, 1)";
            Report.Info($"The expected rbga color for the background is: {expectedColorString}");
            string foundColorCode = new DrumLog().GetDrumlogBackgroundColor();
            Report.IsTrue(expectedColorString == foundColorCode, "The found color was not as expected", "The color found was as expected");

        }

        [StepDefinition(@"I confirm the Drum Log Page Text color is: darker grey")]
        public void ConfirmDrumLogTextColorIsGrey()
        {

            string expectedColorString = "rgba(115, 135, 156, 1)";
            Report.Info($"The expected rbga color for the text is: {expectedColorString}");
            string foundColorCode = new DrumLog().GetDrumLogTextColor();
            Report.IsTrue(expectedColorString == foundColorCode, "The found color was not as expected", "The color found was as expected");

        }

        [StepDefinition(@"I Check that the current page title is 'Drum Log'")]
        public void CheckDrumLogTitle()
        {
            Report.IsTrue(new DrumLog().GetCurrentPageTitle() == "Drum Log", "The Page title was not as expected", "The page title was as expected");
        }

        [StepDefinition(@"I confirm the Drum Log search box is shown")]
        public void ConfirmDrumLogSearchBoxIsPresent()
        {
            Report.IsTrue(new DrumLog().SearchBoxPresent(), "The search box was not present", "The search box was present");
        }

        [StepDefinition(@"I confirm that the Drum Log search box place holder text reads: (.*)")]
        public void IConfirmThatDrumLogSearchBoxPlaceHolderTextReads(string placeholderText)
        {
            Report.IsTrue(new DrumLog().SearchBoxPlaceHolderText() == placeholderText, "The place holder text did not match the expected", "The place holder text was as expected");
        }

        [StepDefinition(@"I confirm that the Drum Log Page buttons to the right of the search box are as follows:")]
        public void IConfirmThatInTheDrumLogPageButtonsAreAsFollows(Table table)
        {
            List<string> buttons = new List<string>();
            foreach (TableRow thisRow in table.Rows)
            {
                buttons.Add(thisRow["Buttons"]);
            }
            Report.IsTrue(buttons.Count == new DrumLog().ProductLookUpButtons.Count, "The number of buttons found did not match the expected number of buttons", "The expected number of button matched the found number of buttons");
            foreach (var button in buttons)
            {
                Report.IsTrue(new DrumLog().CheckProductLookUpButtonsListContains(button), "The button was not found in the list of buttons", "The button was found");
            }

        }


        [StepDefinition(@"I confirm that the Drum Log page shows the bread crumb area")]
        public void IConfirmThatTheDrumLogPageShowsBreadCrumbArea()
        {
            Report.IsTrue(new DrumLog().ConfirmBreadCrumbAreaIsPresent(), "The breadcrumb area was not present", "The bread crumb area was present");
        }

        [StepDefinition(@"I confirm that the Drum Log page does not show the bread crumb area")]
        public void IConfirmThatTheDrumLogPageDoesNotShowTheBreadCrumbArea()
        {
            Report.IsTrue(!new DrumLog().ConfirmBreadCrumbAreaIsPresent(), "The bread crumb area was present", "The breadcrumb area was not present");
        }

        [StepDefinition(@"I confirm that the Drum Log page shows the headings row in the table")]
        public void IConfirmThatTheDrumLogPageShowsHeadingsRow()
        {
            Report.IsTrue(new DrumLog().ConfirmTableHeadingRowIsPresent(), "The headings row was not found", "The headings row was found");
        }



        [StepDefinition(@"I confirm that the Drum Log page headings row has a grey background color")]
        public void IConfirmThatDrumLogPageHeadingsShowGrey()
        {
            string expectedColorString = "rgba(240, 243, 245, 1)";
            Report.Info($"The expected rbga color for the text is: {expectedColorString}");
            string foundColorCode = new DrumLog().GetHeadingsRowBackgroundColor();
            Report.IsTrue(expectedColorString == foundColorCode, "The found color was not as expected", "The color found was as expected");

        }

        [StepDefinition(@"In the Drum Log page, I confirm the column labels show a colon \(:\) icon as the column resize anchor")]
        public void InTheDrumLogPageConfirmLabelsShowColonAsResizeAnchor()
        {
            Report.IsTrue(new DrumLog().CheckColumnSesizeAnchorShowsSymbol(), "not all columns showed a colon as the resize anchor in the main table", "All columns showed a colon as ther reize anchor in the main table");
        }

        [StepDefinition(@"In the Drum Log page, I confirm that the main table has the following columns:")]
        public void InDrumLogPageIConfirmColumnsNames(Table table)
        {
            List<string> expectedHeadings = new List<string>();
            foreach (TableRow thisRow in table.Rows)
            {
                expectedHeadings.Add(thisRow["Headings"]);
            }
            List<string> foundHeadings = new DrumLog().GetColumnHeadingTitles();
            var differences = expectedHeadings.Except(foundHeadings);
            Report.IsTrue(differences.IsNullOrEmpty() && expectedHeadings.Count() == foundHeadings.Count(), "The headings found were not as expected", "The headings found matched the expected headings");
        }

        [StepDefinition(@"In the Drum Logg page, I confirm that the main table shows data rows")]
        public void InTheDrumLogPageIConfirmThatTableShowsDataRows()
        {
            int rowCount = new DrumLog().ProductsCount();
            Report.IsTrue(rowCount > 0, "Data Rows were not showing", "Data Rows were showing");

        }

        [StepDefinition(@"In the Drum Log page, I confirm that In the data row to the far left I confirm I see a right facing arrow \(Expand arrow\)")]
        public void InTheDrumLogPageIConfirmThatTheTableContainsRightFacingArrow()
        {
            Report.IsTrue(new DrumLog().SubGridColumnContainsRightFacingArrow(), "The first column did not contain a right facing arrow in every row", "The first column did contain a right facing arrow in every row");
        }

        [StepDefinition(@"In the Drum Log page, I confirm that to the right of the expand arrow I see the Drum Name")]
        public void InTheDrumLogPageConfirmProductIDToRightOfExpandArrow()
        {
            Report.IsTrue(new DrumLog().HeadingCheckDrumNameColumnIsToRightOfExpandArrow(), "The Drum Name column heading was not to the right of the expand arrow column heading", "The Drum Name column heading was to the right of the expand arrow column heading");
            Report.IsTrue(new DrumLog().CheckDrumNameColumnIsToRightofExpandArrowColumn(), "The Drum Name column was not to the right of the expand arrow column", "The Drum Name column was to the right of the expand arrow column");
            Report.IsTrue(new DrumLog().CheckColumnContainsDrumName(), "The column to the right of the expand arrow column did not contain Drum Names in all rows", "The column to the right of the expand arrow column contained Drum Name in all rows");
        }

        [StepDefinition(@"~~MANUAL CHECK~~ In the Drum Log page, I confirm that each column of data is aligned to the left of the column")]
        public void InTheRecentActivitiesPageConfirmDataAlignedToLeft()
        {
            Report.Warning("MANAUAL CHECK: In the data row I confirm each column of data is aligned to the left of the column");
            Report.Screenshot();
        }

        [StepDefinition(@"In the Drum Log page, I confirm that the table shows alternating background color \(grey to white\)")]
        public void InTheDrumLogPageIConfirmTableShowsAlternatingBackgroundColor()
        {
            Report.IsTrue(new DrumLog().CheckTableAlternatesBetweenGreyAndWhite(), "the table background color was not alternating between grey and white", "the table background color was alternating between grey and white");
        }

        [StepDefinition(@"In the Drum Log page, below the Most Recent Activity table I confirm: page footer is shown")]
        public void InTheDrumLogPageICheckThatTheTableFooterIsShown()
        {
            Report.IsTrue(new DrumLog().ProductsGridFooterPresent(), "The table footer was not shown", "The table footer was shown");
        }

        [StepDefinition(@"In the Drum Log Page, In the Products table footer, select the items per page option: (.*)")]
        public void InThDrumLogPageInProductsTableFooterSelectItemPerPageOption(string option)
        {
            Report.IsTrue(new DrumLog().SelectOptionFromItemsPerPageSelector(option), "The Option was not selected", "The option was selected successfully");
            this.HomeTabLoaded();
        }

        [StepDefinition(@"In the Drum Log Page, In the Products table I scroll down to the bottom product and check its interactable")]
        public void InTheDrumLogPageInProductsTableScrollToBottomProduct()
        {
            Report.IsTrue(new DrumLog().ScrollToAndCheckBottomProductInteractable(), "Failed to scroll to and interact with the bottom product", "Successfully scrolled to and interact with the bottom product");

        }

        [StepDefinition(@"In the Drum Log Page, In the Products table I scroll up to the top product and check its interactable")]
        public void InTheDrumLogPageInProductsTableScrollToTopProduct()
        {
            Report.IsTrue(new DrumLog().ScrollToAndCheckTopProductInteractable(), "Failed to scroll to and interact with the top product", "Successfully scrolled to and interact with the top product");

        }

        [StepDefinition(@"In the Drum Log Page, In the Products table I click the Reset Button")]
        public void InTheDrumLogPageInProductsTableIClickReset()
        {
            Report.IsTrue(new DrumLog().ClickResetButton(), "Failed to click reset", "Successfully clicked the reset button");
            this.HomeTabLoaded();
        }


        [StepDefinition(@"~~MANUAL CHECK~~ In the Drum Log page, I confirm a slider bar is shown to the right of the table")]
        public void InTheRecentActivitiesPageConfirmSliderBarShownToRightOfTable()
        {
            Report.Warning("MANAUAL CHECK: In the data row I confirm a slider bar is shown to the right of the table");
            Report.Screenshot();
        }

        [StepDefinition(@"In the Drum Log page, I expand the first row of the products table")]
        public void InTheDrumLogPageIExpandFirstRow()
        {
            Report.IsTrue(new DrumLog().ExpandFirstRow(), "Failed to expand the first row", "The first row was expanded successfully");
        }

        [StepDefinition(@"In the Drum Log page, I check that there are additional rows below the expanded version of the first row in the products table.")]
        public void InTheDrumLogPageCheckFirstRowExpandedAdditionalRows()
        {
            IWebElement row = new DrumLog().GetFirstExpandedDrumRow();
            Report.IsTrue(row != null, "There was not any additional rows below the expanded first row", "There was additional rows below the expanded first row");
        }




        [StepDefinition(@"In the Drum Log page, I confirm that the expanded first row has following columns in the sub table:")]
        public void InDrumLogPageIConfirmExapndedFirstRowColumnsNames(Table table)
        {
            IWebElement row = new DrumLog().GetFirstExpandedDrumRow();
            List<string> expectedHeadings = new List<string>();
            foreach (TableRow thisRow in table.Rows)
            {
                expectedHeadings.Add(thisRow["Headings"]);
            }
            List<string> foundHeadings = new DrumLog().GetSubRowColumnHeadingTitles(row);
            var differences = expectedHeadings.Except(foundHeadings);
            Report.Info($"Found headings were: {string.Join(",", foundHeadings)}");
            if (differences.Any())
            {
                Report.Info($"The found differences: {string.Join(",", differences)}");
            }
            Report.IsTrue(differences.IsNullOrEmpty() && expectedHeadings.Count() == foundHeadings.Count(), "The headings found were not as expected", "The headings found matched the expected headings");
        }

        [StepDefinition(@"In the Drum Log page, I confirm that the expanded first row column headings show the ':' resize anchor")]
        public void InDrumLogPageConfrimExpandedFirstRowResizeAnchor()
        {
            IWebElement row = new DrumLog().GetFirstExpandedDrumRow();
            Report.StartStep("In the heading row I confirm the column label show a colon ':' icon as the column resize anchor");
            Report.IsTrue(new DrumLog().CheckRowSubTableColumnResizeAnchorShowsSymbol(row), "not all columns showed a colon as the resize anchor in the main table", "All columns showed a colon as ther reize anchor in the main table");
        }



        [StepDefinition(@"In the Drum Log page, I confirm that in the expanded first row I see the expanded menu icon to the left")]
        public void InTheDrumLogPageIConfirmThatInExpandedFirstRowIseeExpandedMenuIcon()
        {
            IWebElement row = new DrumLog().GetFirstExpandedDrumRow();
            Report.IsTrue(new DrumLog().RowSubTableContainsExpandedMenuIcon(row), "The expanded first row did not contain an expanded menu icon the the left", "The expanded first row did contain an expanded menu icon the the left");
        }

        [StepDefinition(@"In the Drum Log page, I collapse the first row of the products table")]
        public void InTheDrumLogPageICollapseFirstRow()
        {
            Report.IsTrue(new DrumLog().CollapseFirstRow(), "Failed to collapse the first row", "The first row was collapsed successfully");
        }

        [StepDefinition(@"In the Drum Log page, I check that there are no additional rows below the expanded version of the first row in the products table.")]
        public void InTheDrumLogPageCheckFirstRowExpandedNoAdditionalRows()
        {
            IWebElement row = new DrumLog().GetFirstExpandedDrumRow();
            Report.IsTrue(row == null, "There was additional rows below the expanded first row", "There was not any additional rows below the expanded first row");
        }

        [StepDefinition(@"In the Drum Log page, I check that the data shown is not repeated")]
        public void InTheDrumLogPageCheckDataIsNotDuplicated()
        {
            Report.IsTrue(new DrumLog().DrumNameNotRepeated(), "There was repeated data", "No Repeated Data was found");
        }


        [StepDefinition(@"In the Drum Log page, I Look for an expanded Row that contains Date Removed data and save it to context as: (.*)")]
        public void InTheDrumLogLookForDateRemovedData(string savedAs)
        {

            int x = 1;
            int lastPageNumber = Int32.Parse(new DrumLog().GetLastPossiblePageNumber());
            while (x < lastPageNumber + 1)
            {
                var productRows = new DrumLog().GetProductRows();

                foreach (var row in productRows)
                {

                    new DrumLog().ExpandGivenRow(row);
                    IWebElement expandedRow = new DrumLog().GetExpandedRowFromMainRow(row);
                    new DrumLog().WaitDrumLogWidgetSpinnerFinish();

                    if (new DrumLog().DrumContainsDateRemoved(expandedRow))
                    {
                        Context.AddToContext(savedAs, expandedRow);
                        return;
                    }
                    new DrumLog().CollapseGivenRow(row);
                    new DrumLog().WaitDrumLogWidgetSpinnerFinish();
                }

                if (new DrumLog().GetCurrentPageNumber() == new DrumLog().GetLastPossiblePageNumber())
                {
                    break;
                }
                new DrumLog().ClickNextPageButton();
                new DrumLog().WaitDrumLogWidgetSpinnerFinish();
            }
            Report.Failure("None of the rows contained a single Date Removed value");
        }


        [StepDefinition(@"In the Drum Log page, I check that the Date Removed Column For the row saved as: (.*) shows in the format yyyy-mm-dd")]
        public void InTheDrumLogCheckExpandedGivenRowDateRemovedFormat(string savedAs)
        {
            IWebElement row = (IWebElement)Context.GetFromContext(savedAs);
            Report.IsTrue(new DrumLog().CheckDateRemovedFormat(row), "Not all values for Date Removed were in the expected format", "All values for Date Removed were in the expected format");
        }

        [StepDefinition(@"In the Drum Log page, I check that the 'Date In Drum' Column For the first row shows in the format yyyy-mm-dd")]
        public void InTheDrumLogCheckExpandedFirstRowDateInDrumFormat()
        {
            IWebElement row = new DrumLog().GetFirstExpandedDrumRow();
            Report.IsTrue(new DrumLog().CheckDateInDrumFormat(row), "Not all values for Date In Drum were in the expected format", "All values for Date In Drum were in the expected format");
        }

        [StepDefinition(@"In the Drum Log page, I check that the 'Scan Date' Column For the first row shows in the format yyyy-mm-dd")]
        public void InTheDrumLogCheckExpandedFirstRowScanDateFormat()
        {
            IWebElement row = new DrumLog().GetFirstExpandedDrumRow();
            Report.IsTrue(new DrumLog().CheckScanDateFormat(row), "Not all values for Scan Date were in the expected format", "All values for Scan Date were in the expected format");
        }

        [StepDefinition(@"In the Drum Log Page, In the table footer I click on the Last Page Button")]
        public void InThDrumLogPageInTableFooterAndClickLastPageButton()
        {
            Report.IsTrue(new DrumLog().LastPageButtonExists(), "Failed to find the last page button", "Successfully found the last page button");
            Report.IsTrue(new DrumLog().ClickLastPageButton(), "Failed to click last page button", "Successfully clicked the last page button");
            this.HomeTabLoaded();
        }

        [StepDefinition(@"In the Drum Log Page, In the Products table footer I check that the current page is the same as the last page number")]
        public void InTheRecentActivitiesPageInProductsTableFooterCheckFinalPageActive()
        {
            string currentNumber = new DrumLog().GetCurrentPageNumber();
            string finalNumber = new DrumLog().GetLastPossiblePageNumber();
            Report.IsTrue(currentNumber == finalNumber, "The current page number did not match the last page number", "The current page number matched the last page number");
            //go back to first page (last page not displaying total products?
            new DrumLog().ClickFirstPageButton();
            this.HomeTabLoaded();
            double itemsPerPage = Convert.ToDouble(new DrumLog().GetCurrentItemsPerPage());
            double totalDisplayedProducts = Convert.ToDouble(new DrumLog().GetTotalProducts());
            double temp = totalDisplayedProducts / itemsPerPage;
            bool pageCountMatches = Int32.Parse(finalNumber) == Convert.ToInt32(Math.Ceiling(totalDisplayedProducts / itemsPerPage));
            Report.Info($"Items per page: {itemsPerPage}");
            Report.Info($"total displayed products: {totalDisplayedProducts}");
            Report.Info($"Displayed pages: {Int32.Parse(finalNumber)}");
            Report.IsTrue(pageCountMatches, "The page count does not match the expected calculation based on the number of products divided by the products per page", "The page count was an expected match");

        }

        [StepDefinition(@"In the Drum Log Page, In the Products table footer I click on the Next Page Button")]
        public void InTheDrumLogPageInProductsTableFooterAndClickNextPageButton()
        {
            Report.IsTrue(new DrumLog().NextPageButtonExists(), "Failed to find the Next page button", "Successfully found the Next page button");
            Report.IsTrue(new DrumLog().ClickNextPageButton(), "Failed to click Next page button", "Successfully clicked the Next page button");
            this.HomeTabLoaded();

        }

        [StepDefinition(@"In the Drum Log Page, In the Products table footer I check that the current page is: (.*)")]
        public void InTheDrumLogPageInProductsTableFooterCheckCurrentPageExpected(string expectedPage)
        {
            string currentNumber = new DrumLog().GetCurrentPageNumber();
            Report.IsTrue(currentNumber == expectedPage, "The current page number was not as expected", "The current page number was as expected");
        }

        [StepDefinition(@"In the Drum Log Page, In the Products table footer I click on the Previous Page Button")]
        public void InTheDrumLogPageInProductsTableFooterAndClickPreviousPageButton()
        {
            Report.IsTrue(new DrumLog().PreviousPageButonExists(), "Failed to find the Previous page button", "Successfully found the Previous page button");
            Report.IsTrue(new DrumLog().ClickPreviousPageButton(), "Failed to click Previous page button", "Successfully clicked the Previous page button");
            this.HomeTabLoaded();

        }

        [StepDefinition(@"In the Drum Log page, In the products table footer I confirm I see the first page icon")]
        public void InTheDrumLogPageInProductsTableFooterIConfirmISeeTheFirstPageIcon()
        {
            Report.IsTrue(new DrumLog().FirstPageButonExists(), "Failed to find the First page button", "Successfully found the First page button");
        }

        [StepDefinition(@"In the Drum Log Page, In the Products table footer I click on the First Page Button")]
        public void InTheDrumLogPageInProductsTableFooterAndClickFirstPageButton()
        {
            Report.IsTrue(new DrumLog().FirstPageButonExists(), "Failed to find the First page button", "Successfully found the First page button");
            Report.IsTrue(new DrumLog().ClickFirstPageButton(), "Failed to click First page button", "Successfully clicked the First page button");
            this.HomeTabLoaded();

        }

        [StepDefinition(@"In the Drum Log Page, In the Products table footer I enter the page number value of: (.*)")]
        public void InTheDrumLogPageInProductsTableFooterEnterPageNumber(string value)
        {
            new DrumLog().EnterCurrentPageValue(value);
            this.HomeTabLoaded();
            this.InTheDrumLogPageInProductsTableFooterCheckCurrentPageExpected(value);
        }

        [StepDefinition(@"In the Drum Log Page, In the Products table footer I confirm the product count range reflects the page I am on")]
        public void InTheDrumLogPageInProductsTableFooteProducsAccountCorrect()
        {
            var drumLogPage = new DrumLog();
            Report.IsTrue(drumLogPage.GetExpectedProductsRange() == drumLogPage.GetDisplayedProductsRange(), "Found range did not match the expected", "Found range matched the expected");


        }


        [StepDefinition(@"In the Drum Log Page, In the Products table I select a random product and save Drum Data to context as: (.*)")]
        public void InTheDrumLogPageInProductsTableISelectRandomDrumAndSaveDataAs(string savedAs)
        {
            string drumName = GeneralUtilities.SelectRandomFromListOfStrings(new DrumLog().GetCurrentProductDrumName());
            DrumLog.DrumLogData currentData = new DrumLog().GetAllDrumDataByDrumName(drumName);
            Context.AddToContext(savedAs, currentData);
        }

        [StepDefinition(@"In the Drum Log Page, In the Products table I select the first product and save Drum Data to context as: (.*)")]
        public void InTheDrumLogPageInProductsTableISelectFirstDrumAndSaveDataAs(string savedAs)
        {
            string drumName = new DrumLog().GetCurrentProductDrumName().First();
            DrumLog.DrumLogData currentData = new DrumLog().GetAllDrumDataByDrumName(drumName);
            Context.AddToContext(savedAs, currentData);
        }



        [StepDefinition(@"In the Drum Log, In the table I search for the drum with Drum Name: (.*)")]
        public void InTheDrumLogPageInProductsTableSearchForDrumName(string drumName)
        {
            if (drumName.ToLower().Contains("drumlogdata"))
            {
                var drumData = (DrumLog.DrumLogData)Context.GetFromContext(drumName);
                drumName = drumData.DrumName;
            }
            new DrumLog().EnterSearchBoxText(drumName);
            Report.IsTrue(new DrumLog().CheckSearchBoxContains(drumName), "The search box did not contain the text that was searched for", "The search box contained the text that was searched for");

        }

        [StepDefinition(@"In the Drum Log Page, In the table the first result matches the Drum Name: (.*)")]
        public void InTheDrumLogPageInTableFirstResultMatchesDrumName(string drumName)
        {

            if (drumName.ToLower().Contains("drumlogdata"))
            {
                var drumData = (DrumLog.DrumLogData)Context.GetFromContext(drumName);
                drumName = drumData.DrumName;
            }
            Report.IsTrue(new DrumLog().GetFirstDrumName() == drumName, "The Drum Name did not match", "The Drum Name matched");
        }

        [StepDefinition(@"In the Drum Log Page, In the table the first result matches the Store Name: (.*)")]
        public void InTheDrumLogPageInTableFirstResultMatchesStoreName(string storeName)
        {

            if (storeName.ToLower().Contains("drumlogdata"))
            {
                var drumData = (DrumLog.DrumLogData)Context.GetFromContext(storeName);
                storeName = drumData.StoreName;
            }
            Report.IsTrue(new DrumLog().GetFirstStoreName() == storeName, "The Drum Name did not match", "The Drum Name matched");
        }


        [StepDefinition(@"In the Drum Log, In the table I search for the drum with Store Name: (.*)")]
        public void InTheDrumLogPageInTableSearchForStoreName(string storeName)
        {
            if (storeName.ToLower().Contains("drumlogdata"))
            {
                var drumData = (DrumLog.DrumLogData)Context.GetFromContext(storeName);
                storeName = drumData.StoreName;
            }
            new DrumLog().EnterSearchBoxText(storeName);
            Report.IsTrue(new DrumLog().CheckSearchBoxContains(storeName), "The search box did not contain the text that was searched for", "The search box contained the text that was searched for");


        }

        [StepDefinition(@"In the Drum Log, In the table I search for the drum with Location: (.*)")]
        public void InTheDrumLogPageInTableSearchForLoction(string loction)
        {
            if (loction.ToLower().Contains("drumlogdata"))
            {
                var drumData = (DrumLog.DrumLogData)Context.GetFromContext(loction);
                loction = drumData.Location;
            }
            new DrumLog().EnterSearchBoxText(loction);
            Report.IsTrue(new DrumLog().CheckSearchBoxContains(loction), "The search box did not contain the text that was searched for", "The search box contained the text that was searched for");

        }

        [StepDefinition(@"In the Drum Log, In the table I search for the drum with partial Location: (.*)")]
        public void InTheDrumLogPageInTableSearchForPartialLoction(string location)
        {
            if (location.ToLower().Contains("drumlogdata"))
            {
                var drumData = (DrumLog.DrumLogData)Context.GetFromContext(location);
                location = drumData.Location;
                var arrayW = location.Split();
                string partialLocation = arrayW[0] + ' ' + arrayW[1];
                location = partialLocation;

            }
            new DrumLog().EnterSearchBoxText(location);
            Report.IsTrue(new DrumLog().CheckSearchBoxContains(location), "The search box did not contain the text that was searched for", "The search box contained the text that was searched for");

        }

        [StepDefinition(@"In the Drum Log Page, In the table the first result matches the Location: (.*)")]
        public void InTheDrumLogPageInTableFirstResultMatchesLocation(string location)
        {

            if (location.ToLower().Contains("drumlogdata"))
            {
                var drumData = (DrumLog.DrumLogData)Context.GetFromContext(location);
                location = drumData.Location;
            }
            var test = new DrumLog().GetFirstLocation();
            Report.IsTrue(new DrumLog().GetFirstLocation() == location, "The Location did not match", "The Location matched");
        }

        /// <summary>
        /// This is for the expanded column called 'Name', if
        /// </summary>
        /// <param name="name"></param>
        [StepDefinition(@"In the Drum Log Page, In the table I search for the drum with Name: (.*) for the expanded row in postion: (.*)")]
        public void InTheDrumLogPageInTableSearchForNameFromData(string name, string position)
        {
            if (name.ToLower().Contains("drumlogdata"))
            {
                int positionInt;
                Int32.TryParse(position, out positionInt);
                var drumData = (DrumLog.DrumLogData)Context.GetFromContext(name);
                name = drumData.ExpandedData[positionInt - 1].Name;
                Report.Info($"Name used: {name}");
            }
            new DrumLog().EnterSearchBoxText(name);
            Report.IsTrue(new DrumLog().CheckSearchBoxContains(name), "The search box did not contain the text that was searched for", "The search box contained the text that was searched for");

        }

        [StepDefinition(@"In the Drum Log Page, In the table I search for the text: (.*)")]
        public void InTheDrumLogPageInTableSearchForText(string text)
        {

            if (text.ToLower().Contains("savedas"))
            {
                text = (string)Context.GetFromContext(text);
                Report.Info($"Name used: {text}");
            }
            new DrumLog().EnterSearchBoxText(text);
            Report.IsTrue(new DrumLog().CheckSearchBoxContains(text), "The search box did not contain the text that was searched for", "The search box contained the text that was searched for");

        }

        [StepDefinition(@"For the Drum Data saved as: (.*) I save the Name for the data in postion: (.*) as: (.*)")]
        public void ForTheDrumLogDataSavedAsSaveNameForPositionAs(string savedAs, int position, string saveAs)
        {
            var drumData = (DrumLog.DrumLogData)Context.GetFromContext(savedAs);
            var wantedRow = drumData.ExpandedData[position - 1];
            var wantedValue = wantedRow.Name;
            Context.AddToContext(saveAs, wantedValue);

        }


        [StepDefinition(@"For the Drum Data saved as: (.*) I save the Manufacturer for the data in postion: (.*) as: (.*)")]
        public void ForTheDrumLogDataSavedAsSaveManufacturerForPositionAs(string savedAs, int position, string saveAs)
        {
            var drumData = (DrumLog.DrumLogData)Context.GetFromContext(savedAs);
            var wantedRow = drumData.ExpandedData[position - 1];
            var wantedValue = wantedRow.Manufacturer;
            Context.AddToContext(saveAs, wantedValue);

        }

        [StepDefinition(@"In the Drum Log page, I check that the first result in the table contains the Name saved as: (.*)")]
        public void InTheDrumLogPageCheckFirstResultContainsNameSavedAs(string savedAs)
        {
            this.InTheDrumLogPageInProductsTableISelectFirstDrumAndSaveDataAs("CurrentFirstData");
            var firstResultData = (DrumLog.DrumLogData)Context.GetFromContext("CurrentFirstData");
            string CurrentFirstData = (string)Context.GetFromContext(savedAs);
            List<string> nameData = new List<string>();
            var expandedDataFound = firstResultData.ExpandedData;
            foreach (var item in expandedDataFound)
            {
                if (item.Name == CurrentFirstData)
                {
                    Report.Success($"The Name: {CurrentFirstData} was found in one of the expanded rows.");
                    return;
                }
                Report.Info($"The Name found was: {item.Name}");
            }
            Report.Failure($"The Name: {CurrentFirstData} was not found in one of the expanded rows.");
            return;



        }


        [StepDefinition(@"In the Drum Log, In the table I search for the drum with Region Name: (.*)")]
        public void InTheDrumLogPageInTableSearchForRegionName(string regionName)
        {
            if (regionName.ToLower().Contains("drumlogdata"))
            {
                var drumData = (DrumLog.DrumLogData)Context.GetFromContext(regionName);
                regionName = drumData.RegionName;

                new DrumLog().EnterSearchBoxText(regionName);
                Report.IsTrue(new DrumLog().CheckSearchBoxContains(regionName), "The search box did not contain the text that was searched for", "The search box contained the text that was searched for");

            }



        }

        [StepDefinition(@"In the Drum Log Page, In the table the first result matches the Region Name: (.*)")]
        public void InTheDrumLogPageInTableFirstResultMatchesRegionName(string regionName)
        {

            if (regionName.ToLower().Contains("drumlogdata"))
            {
                var drumData = (DrumLog.DrumLogData)Context.GetFromContext(regionName);
                regionName = drumData.RegionName;
            }
            Report.IsTrue(new DrumLog().GetFirstLocation() == regionName, "The Region Name did not match", "The Region Name matched");
        }

        [StepDefinition(@"In the Drum Log Page, In the table I find a result which matches the Drum Name: (.*) and save it as: (.*)")]
        public void InTheDrumLogPageInTableResultFoundMatchingDrumName(string drumName, string savedAs)
        {

            if (drumName.ToLower().Contains("drumlogdata"))
            {
                var drumData = (DrumLog.DrumLogData)Context.GetFromContext(drumName);
                drumName = drumData.DrumName;
            }

            IWebElement wantedRow = new DrumLog().GetMatchingDrumNameRow(drumName);
            Context.AddToContext(savedAs, wantedRow);

            Report.IsTrue(!wantedRow.IsNullOrEmpty(), "No Results matched the Drum Name", "A matching Drum Name was found in the results");
        }

        [StepDefinition(@"In the Drum Log Page, In the Products table save the Drum Data to context as: (.*) for Drum with Drum Name: (.*)")]
        public void InTheDrumLogPageInProductsTableISaveDataAsForDrumName(string savedAs, string drumName)
        {
            //check to ensure drum can be found on screen (may need to change page)
            if (drumName.ToLower().Contains("drumlogdata"))
            {
                var drumData = (DrumLog.DrumLogData)Context.GetFromContext(drumName);
                drumName = drumData.DrumName;
            }
            var foundRow = new DrumLog().GetMatchingDrumNameRow(drumName);
            if (foundRow == null)
            {
                Report.Failure("Could not find a row with the Drum Name");
                return;
            }
            DrumLog.DrumLogData currentData = new DrumLog().GetAllDrumDataByDrumName(drumName);
            if (!currentData.IsNullOrEmpty())
            {
                Context.AddToContext(savedAs, currentData);
                Report.Success("Data added to context");
                return;
            }
            else
            {
                Report.Failure("The data was empty");
                return;
            }

        }

        [StepDefinition(@"In the Drum Log page, I check that the Data Saved As: (.*) contains the Manufacturer saved as: (.*)")]
        public void InTheDrumLogPageCheckDataSavedAsContainsManufacturer(string dataSavedAs, string manufacturerSavedAs)
        {

            var savedData = (DrumLog.DrumLogData)Context.GetFromContext(dataSavedAs);
            string manufacturer = (string)Context.GetFromContext(manufacturerSavedAs);
            var expandedDataFound = savedData.ExpandedData;
            foreach (var item in expandedDataFound)
            {
                if (item.Manufacturer == manufacturer)
                {
                    Report.Success($"The Name: {manufacturer} was found in one of the expanded rows.");
                    return;
                }
                Report.Info($"The Name found was: {item.Manufacturer}");
            }
            Report.Failure($"The Name: {manufacturer} was not found in one of the expanded rows.");
            return;

        }

        [StepDefinition(@"In the Drum Log page More Filters Popup I check for a scroll bar if the Date Removed Filter Option is not displayed on screen")]
        public void InTheDrumLogPageMoreFilterPopupCheckDateRemovedFilterIsDisplayed()
        {
            if (new DrumLog.MoreFiltersPopup().DateRemovedOnScreen())
            {
                Report.Success("The Date Removed filter option was visible on scree, no scroll bar is expected");
                return;
            }
            Report.IsTrue(new DrumLog.MoreFiltersPopup().ScrollToTopFilter(), "Failed to scroll to the top filter", "Sucessfully scrolled to the top filter");
            Report.IsTrue(!new DrumLog.MoreFiltersPopup().DateRemovedOnScreen(), "Date Removed Filter was visible which was not expected", "The data removed filter was not on screen, as expected");
            Report.IsTrue(new DrumLog.MoreFiltersPopup().ScrollToBottomFilter(), "Failed to scroll to the bottom filter", "Successfully scrolled to the top filter");
            Report.IsTrue(new DrumLog.MoreFiltersPopup().ScrollToTopFilter(), "Failed to scroll to the top filter", "Sucessfully scrolled to the top filter");



        }

        [StepDefinition(@"In the Drum Log page More Filters Popup I check I can Scroll through the Store Name options")]
        public void InTheDrumLogPageMoreFilterPopupCheckICanScrollThroughStroreNameOptions()
        {
            Report.IsTrue(new DrumLog.MoreFiltersPopup().TopStoreNameFilterOptionVisible(), "The top filter option was not visible", "The top filter option was visible");
            Report.IsTrue(new DrumLog.MoreFiltersPopup().ScrollToStoreNameTopOption(), "Failed to scroll to the top filter option", "Sucessfully scrolled to the top filter option");
            Report.IsTrue(new DrumLog.MoreFiltersPopup().ScrollToStoreNameBottomOption(), "Failed to scroll to the bottom filter option", "Sucessfully scrolled to the bottom filter option");
            Report.IsTrue(new DrumLog.MoreFiltersPopup().ScrollToStoreNameTopOption(), "Failed to scroll to the top filter option", "Sucessfully scrolled to the top filter option");



        }

        [StepDefinition(@"In the Drum Log Page More Filters Popup, I Open the Store Name Filter Drop Down menu")]
        public void InTheDrumLogPageMoreFiltersPopupOpenStoreNameFilterDropDown()
        {
            Report.IsTrue(new DrumLog.MoreFiltersPopup().OpenStoreNameDropDown(), "The Store Name Drop Down Menu was not opened", "The Store Name Drop Down Menu was opened");


        }

        [StepDefinition(@"In the Drum Log Page More Filters Popup, I Close the Store Name Filter Drop Down menu")]
        public void InTheDrumLogPageMoreFiltersPopupCloseStoreNameFilterDropDown()
        {
            Report.IsTrue(new DrumLog.MoreFiltersPopup().CloseStoreNameDropDown(), "The Store Name Drop Down Menu was not closed", "The Store Name Drop Down Menu was closed");


        }

        [StepDefinition(@"In the Drum Log Page More Filters Popup, I check the drop down options for the filter: (.*) match:")]
        public void InTheDrumLogPageMoreFiltersPopupCheckDropDownOptionsForFilterMatch(string filter, Table table)
        {
            List<string> filtersExpected = new List<string>();
            foreach (TableRow thisRow in table.Rows)
            {
                filtersExpected.Add(thisRow["Filter"].ToLower());
            }
            var foundOptions = new DrumLog.MoreFiltersPopup().GetFilterOptions(filter);


            Report.Info($"expected filters: {string.Join(",", filtersExpected)}");

            Report.Info($"filters found: {string.Join(",", foundOptions)}");


            var differences = filtersExpected.Except(foundOptions);

            if (differences.Any())
            {
                Report.Info($"Differences found: {string.Join(",", differences)}");

            }

            Report.IsTrue(differences.IsNullOrEmpty() && filtersExpected.Count() == foundOptions.Count(), "The Filters found were not as expected", "The Filters found matched the expected headings");

        }


    }
}
