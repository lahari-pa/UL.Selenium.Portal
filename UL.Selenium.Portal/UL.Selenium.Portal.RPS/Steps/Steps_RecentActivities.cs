using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using Reqnroll;
using UL.Automation.Reporting.Functions;
using UL.Automation.ReqnrollHelpers.Classes;
using UL.Automation.WebDriver.Classes;
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
            Report.IsTrue(new RecentActivities().WaitRecentActivitiesWidgetSpinnerFinish(), "Failed, Recent activities spinner still spinning", "Success, Recent activities spinner finished ");
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

            if (label.Contains("savedAs"))
            {
                label = (string)Context.GetFromContext(label);
            }
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

		[StepDefinition(@"I confirm that the recent activities page bread crumb area (does|does not) contain the label: (.*)")]
		public void IConfirmThatTheRecentActivitiesPageBreadCrumbAreaDoesNotContainLabel(string doesOrDoesNot, string label)
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
            bool expected = doesOrDoesNot == "does";
            Report.IsTrue(new RecentActivities().ConfirmBreadCrumbAreaContainsLabel(label) == expected, $"Failure, search results list {(expected ? "does not" : "does")} displayed.", $"Success, search results list {doesOrDoesNot} displayed.");
 
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
            string expectedColorString = "rgba(201, 201, 201, 1)";
            Report.Info($"The expected rbga color for the text is: {expectedColorString}");
            string foundColorCode = new RecentActivities().GetHeadingsRowBackgroundColor();
            Report.IsTrue(expectedColorString == foundColorCode, "The found color was not as expected. Actually found: " + foundColorCode, "The color found was as expected");

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
			Report.IsTrue(differences.IsNullOrEmpty(), "The headings found were not as expected", "The headings found matched the expected headings");
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
			if (searchText == "<AnyDate>")
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


		[StepDefinition(@"In the recent Activities page, In the Search Options, the More Filters button has a background color of white")]
		public void IConfirmThatRecentActivitiesPageMoreFiltersButtonIsWhite()
		{
			string expectedColorString = "rgba(255, 255, 255, 1)";
			Report.Info($"The expected rbga color for the background is: {expectedColorString}");
			string foundColorCode = new RecentActivities().GetMoreFiltersButtonBackgroundColor();
            Report.Info(foundColorCode);
            Report.IsTrue(expectedColorString == foundColorCode, "The found color was not as expected", "The color found was as expected");

		}

		[StepDefinition(@"In the recent Activities page, In the Search Options, the More Filters button has a text color of brown")]
		public void IConfirmThatRecentActivitiesPageMoreFiltersTextIsBrown()
		{
			string expectedColorString = "rgba(91, 4, 40, 1)";
			Report.Info($"The expected rbga color for the text is: {expectedColorString}");
			string foundColorCode = new RecentActivities().GetMoreFiltersButtonTextColor();
            Report.Info(foundColorCode);
            Report.IsTrue(expectedColorString == foundColorCode, "The found color was not as expected", "The color found was as expected");

		}

		[StepDefinition(@"In the recent Activities page, In the Search Options, the Export button has a background color of white")]
		public void IConfirmThatRecentActivitiesPageExportButtonIsWhite()
		{
			string expectedColorString = "rgba(255, 255, 255, 1)";
			Report.Info($"The expected rbga color for the background is: {expectedColorString}");
			string foundColorCode = new RecentActivities().GetExportButtonBackgroundColor();
            Report.Info(foundColorCode);
            Report.IsTrue(expectedColorString == foundColorCode, "The found color was not as expected", "The color found was as expected");

		}

		[StepDefinition(@"In the recent Activities page, In the Search Options, the Export button has a text color of brown")]
		public void IConfirmThatRecentActivitiesPageExportTextIsBrown()
		{
			string expectedColorString = "rgba(91, 4, 40, 1)";
			Report.Info($"The expected rbga color for the text is: {expectedColorString}");
			string foundColorCode = new RecentActivities().GetExportButtonTextColor();
            Report.Info(foundColorCode);
            Report.IsTrue(expectedColorString == foundColorCode, "The found color was not as expected", "The color found was as expected");

		}

		[StepDefinition(@"In the recent Activities page, In the Search Options, the Reset button has a background color of white")]
		public void IConfirmThatRecentActivitiesPageResetButtonIsWhite()
		{
			string expectedColorString = "rgba(255, 255, 255, 1)";
			Report.Info($"The expected rbga color for the background is: {expectedColorString}");
			string foundColorCode = new RecentActivities().GetResetButtonBackgroundColor();
            Report.Info(foundColorCode);
            Report.IsTrue(expectedColorString == foundColorCode, "The found color was not as expected", "The color found was as expected");

		}

		[StepDefinition(@"In the recent Activities page, In the Search Options, the Reset button has a text color of brown")]
		public void IConfirmThatRecentActivitiesPageResetTextIsBrown()
		{
			string expectedColorString = "rgba(91, 4, 40, 1)";
			Report.Info($"The expected rbga color for the text is: {expectedColorString}");
			string foundColorCode = new RecentActivities().GetResetButtonTextColor();
            Report.Info(foundColorCode);
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
            Report.IsTrue(expectedButtons.All(i => foundButtons.Contains(i)), "The buttons found were not as expected", "The buttons found matched the expected headings");
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
			foreach (var el in datesAsStrings)
			{
				DateTime parsedDate = DateTime.Parse(el);
				datesFound.Add(parsedDate);
			}
			int i = 1;
			bool orderCorrect = true;

			foreach (var date in datesFound)
			{
				if (i == datesFound.Count())
				{
					break;
				}
				var compared = date.CompareTo(datesFound[i]);
				if (compared == 0 || compared == 1)
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
			string iD = GeneralUtilities.SelectRandomFromListOfStrings(new RecentActivities().GetCurrentProductIDs());
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
			if (secondiD == iD)
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
				if (differntID == false)
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
		[StepDefinition(@"In the Products table footer I check that the current page number is the same as the last page number")]

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
		[StepDefinition(@"In the Products table the total number of pages is correct")]
		public void InTheRecentActivitiesPageInProductsTableTotalNoPagesCorrect()
		{
			int totalProducts = new RecentActivities().GetTotalProducts();
			int foundPages = Int32.Parse(new RecentActivities().GetLastPossiblePageNumber());
			double expectedPageTotalDB = (Double)totalProducts / (Double)(new RecentActivities().GetCurrentItemsPerPage());
			int expectedPageTotal = (int)Math.Ceiling(expectedPageTotalDB);

			Report.IsTrue(foundPages == expectedPageTotal, "The number of pages found was not as expected", "The number of pages found was as expected");
		}

		[StepDefinition(@"In the recent activities Page, In the Products table footer, the number of items per page shows the following options:")]
		[StepDefinition(@"In the Products table footer, the number of items per page shows the following options:")]
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

		[StepDefinition(@"In the recent activities Page, In the Products table footer I confirm the current Items Per page is: (.*)")]
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
			Delay.Seconds(5);
		}

		[StepDefinition(@"In the recent activities Page, In the Products table I search for the product with ID saved to context as: (.*)")]
		public void InTheRecentActivitiesPageInProductsTableSearchForProductIDSavedAs(string savedAs)
        {
			string productID = Context.GetFromContext(savedAs).ToString();
			InTheRecentActivitiesPageInProductsTableSearchForProductID(productID);
		}

		[StepDefinition(@"In the recent activities Page, In the Products table I search for the product with Name: (.*)")]
		public void InTheRecentActivitiesPageInProductsTableSearchForProductName(string productName)
		{

            var productData = (RecentActivities.RecentProductData)Context.GetFromContext(productName);
            productName = productData.ProductName;
			int endindex = productName.IndexOf("UPC");
            string prodName = productName.Substring(0, endindex-1);
            new RecentActivities().EnterSearchBoxTextAndpressEnterKey(prodName);
			Report.IsTrue(new RecentActivities().CheckSearchBoxContains(prodName), "The search box did not contain the text that was searched for", "The search box contained the text that was searched for");

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
                Report.Info(productName);
                int firsto = productName.IndexOf(",");
                string firstUpdate = productName.Substring(firsto);
				productName = firstUpdate;
                Report.Info(productName);

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
			//Report.IsTrue(new RecentActivities().GetFirstProductID() == productID, "The product Ids did not match", "The product Ids matched");
			var gridTable = new GridTable();
			Report.IsTrue(gridTable.ProductInfoCellWPSIDGet(gridTable.ProductInfoCellGet(1)) == productID, "The product Ids did not match", "The product Ids matched");
		}

		[StepDefinition(@"In the recent activities Page, In the Products table the first result matches the product ID saved to context as: (.*)")]
		public void InTheRecentActivitiesPageInProductsTableFirstResultMatchesIDSavedAs(string savedAs)
        {
			string productID = Context.GetFromContext(savedAs).ToString();
			InTheRecentActivitiesPageInProductsTableFirstResultMatchesID(productID);

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
			Report.IsTrue(new RecentActivities().CheckProductNameInResults(productName), "The product name was not found in resultsh", "The product name was found in the results");
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
				savedUPCs = (List<string>)Context.GetFromContext(productUPCs);
			}

			var foundUPCs = new RecentActivities().GetFirstProductUPCs();
			var differences = foundUPCs.Except(savedUPCs);
			Report.IsTrue(!differences.Any() && savedUPCs.Count() == foundUPCs.Count(), "The product UPCs did not match", "The product UPCs matched");
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
			Report.IsTrue(new RecentActivities().ConfirmAllNamesContain(productName), "Not all products contained the search text", "All product names contained the search text");
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
            GeneralUtilities.WaitForLoadingToFinish();
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
			while (x < 9)
			{
				string iD = GeneralUtilities.SelectRandomFromListOfStrings(new RecentActivities().GetCurrentProductIDs());
				string currentData = new RecentActivities().GetColumValueByID("Supplier", iD);
				if (currentData.Contains(value))
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
			endDateLabel = "End Date: " + "\"" + currentDateString + "\"";
			expectedFullText = "Filters: " + startDateLabel + " " + endDateLabel + " Reset";

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

			var allFoundIds = new RecentActivities().GetCurrentProductIDs();
			List<RecentActivities.RecentProductData> currentResults = new List<RecentActivities.RecentProductData>();

			foreach (var item in allFoundIds)
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
			if (matching == "do not match")
			{
				foreach (var result in savedResults)
				{
					Report.Info($"Comparing item number {x + 1} in each list");
					Report.IsTrue(!result.Equals(currentResults[x]), "The Result matched", "The Result did not match");
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

			Report.IsTrue(titleText == expectedText, "The header text did not match", "The header text matched");
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
			Report.IsTrue(footerButtons.Count == 1, "There was not 1 footer button", "There was 1 footer button");

		}

		[StepDefinition(@"In the recent activities Page, In the Export to Excel popup footer I confirm the Close button is shown")]
		public void InTheRecentActivitiesPageInTheExportToExcelPopupFooterIConfirmTheCloseButtonIsShown()
		{
			var footerButtons = new RecentActivities.ExportToExcelPopup().GetAllFooterButtons();
			var buttonText = footerButtons.First().Text;
			Report.IsTrue(buttonText == "Close", "The Close Button was not found", "The Close Button was found");

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
				foreach (var thing in lineValues)
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
				if (currentRowArray.Last() == "")
				{
					currentRowArray = currentRowArray.Where(w => w != currentRowArray.Last()).ToArray();
				}

				var productName = currentRowArray[0];
				var upcNumbers = currentRowArray[1];
				var productNumbers = currentRowArray[2];
				var supplierNames = currentRowArray[3];
				var statusValues = currentRowArray[4];
				var turnAroundTime = currentRowArray[5];
				var recentActivityDates = currentRowArray[6];
				var reason = currentRowArray[7];
				var packagingType = currentRowArray[8];
				var packagingSize = currentRowArray[8];



				if (!foundProductIDs.Contains(productName))
				{
					foundProductIDs.Add(productName);
					Report.Info($"Adding product number: {productName} to the list of found products");
					previouslyCheckedUpcs.Add(upcNumbers);
					Report.Info($"Adding the Upc: {upcNumbers} to the list of seen UPCS");
				}
				else
				{
					Report.Info($"The product number: {productName} was already in the list");
					if (previouslyCheckedUpcs.Contains(upcNumbers))
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
					var wantedProduct = savedProducts.First(x => x.ID == productName);
					Report.Info("Starting Product Checks");
				}
				catch
				{
					Report.Failure($"The Product with ID: {productName} was not found in the list of saved products (was not in the grid)");
				}

				if (productFound == true)
				{
					var wantedProduct = savedProducts.First(x => x.ID == productName);


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
			foreach (var el in savedProducts)
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

			Report.IsTrue(foundDescription == expectedDescription, "The descriptions did not match", "The descriptions matched");

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
			Report.IsTrue(new RecentActivities().ClickActionForGivenProductInResultsGrid(productID, action), "Failed to click the action for the first product", "Successfully clicked the action for the first product");
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

		[StepDefinition(@"In the Recent Activity Product table  - I confirm the Most Recent Activity column displays in date order, newest first")]
		public void GivenInTheRecentActivityProductTable_IConfirmTheMostRecentActivityColumnDisplaysInDateOrderNewestFirst()
		{
			Report.IsTrue(new RecentActivities().ConfirmRecentActivityColumnDisplaysDatesInOrder(), "Failed to click the action for the first product", "Successfully clicked the action for the first product");
		}

        [StepDefinition(@"In the recent page, I confirm for all products the Action column (does|does not) include option: (.*)")]
        public void InTheRecentActivitiesPageIConfirmForAllProductsActionsColumnDoesOrDoesNotContainGivenOption(string doesOrDoesNot, string value)
        {
            if (doesOrDoesNot == "does")
            {
                Report.IsTrue(new ProductLookUp().CheckAllProductsDoesContainGivenOptionInActionsColumn(value), $"None of the rows contained the text: '{value}'", $"All of the rows contained the text: '{value}'");
            }
            else if (doesOrDoesNot == "does not")
            {
                Report.IsTrue(new ProductLookUp().CheckAllProductsDoNotContainGivenOptionInActionsColumn(value), $"At least 1 row contained the text: '{value}'", $"None of the rows contained the text: '{value}'");
            }
        }

        [StepDefinition(@"I confirm in the Recent Activities page the product grid Most Recent Activity column displays the following format: (.*)")]
        public void ThenIConfirmInTheRecentActivitiesPageTheProductGridMostRecentActivityColumnDisplaysTheFollowingFormat(string dateFormat)
        {
            Report.IsTrue(new RecentActivities().ConfirmInTheRecentActivitiesPageTheProductGridMostRecentActivityColumnDisplaysTheFollowingFormat(dateFormat), $"At least 1 date had the incorrect format: '{dateFormat}'", $"None of the dates had the incorrect format: '{dateFormat}'");
        }

        [StepDefinition(@"In the recent activities page, I take note of the number of products in the footer area and save as: (.*)")]
        public void ThenInTheRecentActivitiesPageITakeNoteOfTheNumberOfProductsInTheFooterAreaAndSaveAsProductAmount(string savedAs)
        {
            string totalNumberOfProducts = new RecentActivities().TakeNotOfNumberOfProductsInFooterArea(savedAs);
            Context.AddToContext(savedAs, totalNumberOfProducts);
        }
        
        [StepDefinition(@"I confirm that the recent activities Page bread crumb area contains the label: (.*)")]
        public void IConfirmThatTheProductLookupPageBreadCrumbAreaContainsLabel(string label)
        {

            Report.IsTrue(new ProductLookUp().ConfirmBreadCrumbAreaContainsLabel(label), "The Bread crumb area did not contain the label", "The bread crumb are contained the label");
        }

        [StepDefinition(@"In the recent activites page, I check if the number of products in the footer area (is greater than|is less than|matches) amount saved as: (.*)")]
        public void GivenInTheRecentActivitesPageICheckIfTheNumberOfProductsInTheFooterAreaMatchesAmountSavedAsProductAmount(string option, string savedAs)
        {
            string totalNumberOfProducts = new RecentActivities().TakeNotOfNumberOfProductsInFooterArea(savedAs);
            var savedTotalNumberOfProducts = Context.GetFromContext(savedAs).ToString();

            bool toCheck = false;
            int totalNumberOfProductsInt = Int32.Parse(totalNumberOfProducts);
            int savedTotalNumberOfProductsInt = Int32.Parse(savedTotalNumberOfProducts);

            Report.Info(totalNumberOfProducts + " " + savedTotalNumberOfProducts);
            if (option == "is greater than")
            {
                toCheck = (totalNumberOfProductsInt > savedTotalNumberOfProductsInt);
            }
            else if (option == "is less than")
            {
                toCheck = (totalNumberOfProductsInt < savedTotalNumberOfProductsInt);
            }
            else if (option == "matches")
            {
                toCheck = (totalNumberOfProductsInt == savedTotalNumberOfProductsInt);
            }

            if (toCheck == true)
            {
                Report.Success("Confirmed the number of products in the footer area now " + option + " the number of products in the footer area before");
            }
            else
            {
                Report.Failure("Failed to confirm the number of products in the footer area now " + option + " the number of products in the footer area before");
            }

        }

        [StepDefinition(@"In the Recent Activites page, I confirm I (see|do not see) the breadcrumbs area under the search field")]
        public void GivenIConfirmIDoNotSeeTheBredcrumbsAreaUnderTheSearchField(string seeOrDoesNotSee)
        {
            if (seeOrDoesNotSee == "see")
            {
                Report.IsTrue(new RecentActivities().CheckIfBreadcrumbAreaIsEmpty(), $"Failed to locate the breadcrumbs area", "Successfully located the breadcrumbs area");
            }
            else if (seeOrDoesNotSee == "do not see")
            {
                Report.IsTrue(new RecentActivities().CheckIfBreadcrumbAreaIsEmpty() == false, $"Failed to NOT locate the breadcrumbs area", "Successfully didn't locate the breadcrumbs area");
            }
        }
 
        [StepDefinition(@"I confirm that the Lookup Page bread crumb area does not contain the label: (.*)")]
        public void ThenIConfirmThatTheLookupPageBreadCrumbAreaDoesNotContainTheLabelPackagingTypeGlassContainer(string breadCrumbName)
        {
            Report.IsTrue(new RecentActivities().IConfirmThatTheLookupPageBreadCrumbAreaDoesNotContainTheLabelPackagingTypeGlassContainer(breadCrumbName), "Failed to not find the breadcrumb label", "Successfully didn't find the breadcrumb label");
        }


        [StepDefinition(@"In the recent activities page, I confirm the products shown have the supplier name chosen: (.*)")]
        public void GivenInTheRecentActivitiesPageIConfirmTheProductsShownHaveTheSupplierNameChosen(string supplierName)
        {
            Report.IsTrue(new RecentActivities().InTheRecentActivitiesPageIConfirmTheProductsShownHaveTheSupplierNameChosen(supplierName), "Failed to find the supplier name chosen", "Successfully found the supplier name chosen");
        }


        [StepDefinition(@"In the recent activities Page, I click the x icon for the bread crumb: Supplier Name: (.*)")]
        public void ThenInTheRecentActivitiesPageIClickTheXIconForTheBreadCrumbSupplierNameTheWERCSLTD(string supplierName)
        {
            Report.IsTrue(new RecentActivities().InTheRecentActivitiesPageIClickTheXIconForTheBreadCrumbSupplierName(supplierName), "Failed to click the x icon for the chosen breadcrumb", "Successfully clicked the x icon for the chosen breadcrumb");
        }

		[StepDefinition(@"In the recent activities page, I confirm that the product table  has the following column:(.*)")]
		public void InRecentActivitiesPageIConfirmColumnsNameTimeAroundTime(string columnName)
		{
			Report.IsTrue(new RecentActivities().InTheRecentActivitiesPageTurnAroundTimeColumnFound(columnName), "Failed to find the Column name TurnAround Time" , "Successfully found the Column name TurnAround Time");
		}

		[StepDefinition(@"I click on the entry in the Turnaround Time column")]
		public void InRecentActivitiesPageIClickTurnAroundTimeValue()
		{
			Report.IsTrue(new RecentActivities().InTheRecentActivitiesPageIClickTheTurnAroundTimeValue(), "Failed to click TurnAround Time", "Successfully clicked onTurnAround Time");
		}
		[StepDefinition(@"I confirm a Turnaround time popup displays")]
		public void InTheRecentActivitiesPageIConfirmTurnAroundTimePopupIsDisplayed()
		{
			Report.IsTrue(new RecentActivities().InTheRecentActivitiesPageIConfirmTurnAroundTimePopupIsDisplayed(), "Failed to open TurnAround Time popup", "Successfully opened TurnAround Time Popup");
		}

		[StepDefinition(@"I confirm the TurnAround Time Pop up has loaded")]
		
		public void TurnAroundTimePopupLoaded()
		{
			Report.IsTrue(new TopBar().WaitForContainerToBeVisible(), "Pop Up did not load!");
			GeneralUtilities.WaitForLoadingToFinish();
			Report.IsTrue(new RecentActivities().WaitRecentActivitiesWidgetSpinnerFinish(), "Failed, Recent activities spinner still spinning", "Success, Recent activities spinner finished ");
			new RecentActivities().WaitRecentActivitiesWidgetSpinnerFinish();
			Report.IsTrue(new RecentActivities().WaitForContainerToBeVisible(), "Page content did not load", "Page content loaded");
		}

		[StepDefinition(@"I confirm a Turnaround time popup displays date and Status")]
		public void InTheRecentActivitiesPageIConfirmTurnAroundTimePopupDisplaysDateAndStatus()
		{
			Report.IsTrue(new RecentActivities.TurnAroundTimePopup().InTheRecentActivitiesPageIConfirmTurnAroundTimePopupDisplaysDate(), "Failed to display TurnAround Time date", "Successfully opened TurnAround Time date");
			Report.IsTrue(new RecentActivities.TurnAroundTimePopup().InTheRecentActivitiesPageIConfirmTurnAroundTimePopupDisplaysStatus(), "Failed to display TurnAround Time status", "Successfully opened TurnAround Time status");
		}



		[StepDefinition(@"I confirm I see a Turn Around Time popup Export button")]
		public void InTheRecentActivitiesPageIConfirmTurnAroundTimePopUpExportbuttonIsDisplayed()
		{
			Report.IsTrue(new RecentActivities.TurnAroundTimePopup().InTheRecentActivitiesPageIConfirmTurnAroundTimePopupDisplaysExportButton(), "Failed to display TurnAround Time export", "Successfully opened TurnAround Time export button");
		}


		[StepDefinition(@"I confirm I see a Close button in Turnaround time popup")]
		public void InTheRecentActivitiesPageIConfirmTurnAroundTimePopupCloseButtonIsDisplayed()
		{
			Report.IsTrue(new RecentActivities.TurnAroundTimePopup().InTheRecentActivitiesPageIConfirmTurnAroundTimePopupDisplaysCloseButton(), "Failed to display TurnAround Time close button", "Successfully opened TurnAround Time Close button");
		}


		[StepDefinition(@"I click the Turn Around Time Export button")]
		public void InTheRecentActivitiesPageIClickTurnAroundTimeExportButton()
		{
			Report.IsTrue(new RecentActivities.TurnAroundTimePopup().InTheRecentActivitiesPageIClickTurnAroundTimePopupExportButton(), "Failed to click TurnAround Time export button", "Successfully  clicked TurnAround Export button");
		}

		[StepDefinition(@"I close the turn around time Product Status History popup using the x at the upper right corner")]
		public void InTheRecentActivitiesPageICloseTurnAroundTimePopupUsingXAtTheRightCorner()
		{
			Report.IsTrue(new RecentActivities.TurnAroundTimePopup().InTheRecentActivitiesPageIClickTurnAroundTimePopupXButton(), "Failed to click TurnAround X button", "Successfully clicked TurnAround Export button");
		}

		[StepDefinition(@"I confirm the Turn Around Time pop up header is displayed")]
		public void InTheRecentActivitiesPageIConfirmTurnAroundTimePopupHeaderIsDisplayed()
		{
			Report.IsTrue(new RecentActivities.TurnAroundTimePopup().InTheRecentActivitiesPageIConfirmTurnAroundTimePopupHeaderIsDisplayed(), "Failed to display TurnAround Time pop up header", "Successfully opened TurnAround Time pop up header");
		}

		[StepDefinition(@"I click on the View Data Link")]
		public void InTheProductTableIClickViewDataLink()
		{
			Report.IsTrue(new RecentActivities().InTheProductTableIClickTheViewDataLink(), "Failed to click View Data Link", "Successfully clicked View Data Link");
		}

		[StepDefinition(@"I click on the Documents Link")]
		public void InTheProductTableIClickDocumentsLink()
		{
			Report.IsTrue(new RecentActivities().InTheProductTableIClickTheDocumentsLink(), "Failed to click Documents Link", "Successfully clicked Docuements Link");
		}

		[StepDefinition(@"I confirm the Product Information Pop up has loaded")]
		public void ProductInformationPopupLoaded()
		{
			Report.IsTrue(new TopBar().WaitForContainerToBeVisible(), "Pop Up did not load!");
			GeneralUtilities.WaitForLoadingToFinish();
			Report.IsTrue(new RecentActivities().WaitRecentActivitiesWidgetSpinnerFinish(), "Failed,", "Success");
			new RecentActivities().WaitRecentActivitiesWidgetSpinnerFinish();
			Report.IsTrue(new RecentActivities().WaitForContainerToBeVisible(), "Page content did not load", "Page content loaded");
		}

		[StepDefinition(@"I verify that Product Information pop up is displayed")]
		public void InTheProductTableProductInformationPopupDisplayed()
		{
			Report.IsTrue(new RecentActivities().InTheProductTableIConfirmViewDataPopupIsDisplayed(), "Failed to display View Data pop up", "Successfully opened View Data pop up");
		}

		[StepDefinition(@"I verify that Documents pop up is displayed")]
		public void InTheProductTableDocumentsPopupDisplayed()
		{
			Report.IsTrue(new RecentActivities().InTheProductTableIConfirmDocumentsPopupIsDisplayed(), "Failed to display Documents pop up", "Successfully opened Documents pop up");
		}


		[StepDefinition(@"In the product table, I confirm for all products the Action column (does|does not) include option: (.*)")]
		public void InTheProductTableIConfirmForAllProductsActionsColumnDoesOrDoesNotContainGivenOption(string doesOrDoesNot, string value)
		{
			if (doesOrDoesNot == "does")
			{
				Report.IsTrue(new RecentActivities().InTheProductTableIConfirmForAllProductsActionsColumnDoesContainsGivenOption(value), $"None of the rows contained the text: '{value}'", $"All of the rows contained the text: '{value}'");
			}
			
		}
		
		[StepDefinition(@"In the Recent Activities page I confirm to the right of the buttons I do not see three trends")]
		public void GivenInTheRecentActivitiesPageIConfirmToTheRightOfTheButtonsIDoNotSeeThreeTrends(Table table)
		{
			Report.IsTrue(new NavBar().InRecentActivitiesIConfirmTheFollowingTrendsAreNotDisplayed(table), "Failed to find all three trends", "Successfully found all three trends");
		}

		[StepDefinition(@"I confirm the last page icon in the footer area")]

		public void IConfirmLastPageIconIsDisplayedInFooterArea()
		{
			Report.IsTrue(new RecentActivities().LastPageButtonExists(), "Failed to find the last page button", "Successfully found the last page button");
		}

		[StepDefinition(@"In the Products table footer I click on the last page icon")]

		public void InProductsTableFooterAndClickLastPageButton()
		{
			Report.IsTrue(new RecentActivities().LastPageButtonExists(), "Failed to find the last page button", "Successfully found the last page button");
			Report.IsTrue(new RecentActivities().ClickLastPageButton(), "Failed to click last page button", "Successfully clicked the last page button");
		}

		[StepDefinition(@"I click the next page icon in page footer")]
		public void InProductsTableFooterClickNextPageButton()
		{
			Report.IsTrue(new RecentActivities().NextPageButtonExists(), "Failed to find the Next page button", "Successfully found the Next page button");
			Report.IsTrue(new RecentActivities().ClickNextPageButton(), "Failed to click Next page button", "Successfully clicked the Next page button");

		}


		[StepDefinition(@"I click the previous page icon in page footer")]
		public void InProductsTableFooterClickPreviousPageButton()
		{
			Report.IsTrue(new RecentActivities().PreviousPageButonExists(), "Failed to find the Previous page button", "Successfully found the Previous page button");
			Report.IsTrue(new RecentActivities().ClickPreviousPageButton(), "Failed to click Previous page button", "Successfully clicked the Previous page button");

		}

		[StepDefinition(@"I confirm page number is: (.*)")]
		public void InProductsTableFooterIConfirmPageNumber(string pageNumber)
		{
			string currentNumber = new RecentActivities().GetCurrentPageNumber();
			Report.IsTrue(currentNumber == pageNumber, "The current page number did not match with expected page number", "The current page number matched with expected page number");

		}
		 
		[StepDefinition(@"I confirm the first page icon in the footer area")]

		public void IConfirmFirstPageIconIsDisplayedInFooterArea()
		{
			Report.IsTrue(new RecentActivities().FirstPageButonExists(), "Failed to find the first page button", "Successfully found the first page button");
		}
		[StepDefinition(@"In the Products table footer I click on the first page icon")]
		public void InProductsTableFooterClickFirstPageButton()
		{
			Report.IsTrue(new RecentActivities().ClickFirstPageButton(), "Failed to click First page button", "Successfully clicked the First page button");
		
		}
		[StepDefinition(@"In the page footer, I change the page number: (.*)")]
		public void InProductsTableFooterIChangePageNumber(string value)
		{
			new RecentActivities().ChangePageValue(value);
			Report.Success( "Successfully changed the page number");


		}
		[StepDefinition(@"In the Products table footer, select the items per page option: (.*)")]
		public void InProductsTableFooterSelectItemPerPageOption(string option)
		{
			Report.IsTrue(new RecentActivities().SelectOptionFromItemsPerPageSelector(option), "The Option was not selected", "The option was selected successfully");
		}

		[StepDefinition(@"I confirm number of items per page selection box is shown")]
		public void InProductsTableIConfirmNumberOfItemsPerPageSelectionBox()
		{
			Report.IsTrue(new RecentActivities().ItemsPerPageSelectorExists(), "The number of items per page selection box is not shown", "The number of items per page selection box is shown");
		}

		[StepDefinition(@"In the page footer I click the number of items per page selection box")]
		public void InPageFooterIClickNumberOfItemsPerPageSelectionBox()
		{
			Report.IsTrue(new RecentActivities().ClickItemsPerPageSelector(), "Failed to click the number of items per page selection box", "Successfully clicked the number of items per page selection box");
		}


		[StepDefinition(@"In the Page footer area I confirm Rows per page selector displays: (.*)")]
		public void InProductsTableFooterIConfirmRowsPerPageSelectorDisplays(string expectedNumber)
		{
			string currentNumber = new RecentActivities().GetRowsPerPageNumber();
			Report.IsTrue(currentNumber == expectedNumber, "The Rows per page selector number was not as expected", "The Rows per page selector number was as expected");
		}
 
		[StepDefinition(@"I confirm the Too Many Pages pop up is shown")]
		public void InTheRecentActivitiesPageTooManyPagesPopupIsDisplayed()
		{
			Report.IsTrue(new RecentActivities().InTheProductTableIConfirmTooManyPagesPopupIsDisplayed(), "The Too Many Pages Pop Up is not displayed", "Too Many Pages Pop Up is displayed successfully");
		}

		[StepDefinition(@"In the Too Many Pages pop up, I confirm the heading reads Too Many Pages")]
		public void InTheRecentActivitiesPageTooManyPagesPopUpHeadingIsDisplayed()
		{
			Report.IsTrue(new RecentActivities.TooManyPagesPopup().GetTooManyPagesPopUpHeadingContent() == "Too Many Pages", "The Too Many Pages Pop Up heading is not displayed as expected", "Too Many Pages Pop Up heading is displayed successfully as expected");
		}

		[StepDefinition(@"In the Too Many Pages pop up, at the far right of the pop up heading area, I confirm I see the X icon")]
		public void InTheRecentActivitiesPageTooManyPagePopUpXIsDisplayed()
		{
			Report.IsTrue(new RecentActivities.TooManyPagesPopup().InTheTooManyPagesPopUpXButtonIsDisplayed(), "In Too Many Pages Pop Up X button is not displayed", "In Too Many Pages Pop Up X button is displayed successfully");
		}

		[StepDefinition(@"In the Too Many Pages pop up in the heading area, I click the X icon")]
		public void InTheRecentActivitiesPageTooManyPagePopUpIClickXButton()
		{
			Report.IsTrue(new RecentActivities.TooManyPagesPopup().InTheTooManyPagesPopUpIClickXButton(), "Failed to click X button in The Too Many Pages Pop Up", "Successfully clicked X Button in the Too Many Pages Pop Up ");
		}

		[StepDefinition(@"I confirm the Too Many Pages pop up closes")]
		public void InTheRecentActivitiesPageTooManyPagesPopUpIsClosed()
		{
			Report.IsTrue(new RecentActivities.TooManyPagesPopup().WaitForContainerToBeInvisible(), "The Too Many Pages popup is not displayed", "The Too Many Pages popup is displayed successfully");
		}

		[StepDefinition(@"In the Too Many Rows pop up footer area, I click in the Close button")]
		public void InTheRecentActivitiesPageTooManyPagesPopUpIClickCloseButton()
		{
			Report.IsTrue(new RecentActivities.TooManyPagesPopup().InTheTooManyPagesPopUpIClickCloseButton(), "Failed to click Close Button in Too Many Pages Pop Up", "Sucessfully clicked Close button in Too Many Pages Pop Up");
		}

		[StepDefinition(@"In the Too Many Rows pop up footer area, I click Show Filters")]
		public void InTheRecentActivitiesPageTooManyPagesPopUpIClickShowFilters()
		{
			Report.IsTrue(new RecentActivities.TooManyPagesPopup().InTheTooManyPagesPopUpIClickShowFiltersButton(), "Failed to click Show Filters Button in Too Many Pages Pop Up", "Sucessfully clicked Show Filters button in Too Many Pages Pop Up");
		
		}

		[StepDefinition(@"In the Too Many Pages pop up, below the pop up heading I confirm I see the message")]
		public void InTheRecentActivitiesPageTooManyPagesPopUpMessageIsDisplayed()
		{
			Report.IsTrue(new RecentActivities.TooManyPagesPopup().GetTooManyPagesPopUpBodyContent() == "We are unable to page past 100,000 records. However, you may add a filter to show records that are not currently visible.", "The Too Many Pages Pop Up body is not displayed as expected", "Too Many Pages Pop Up body is displayed successfully as expected");
		}

		[StepDefinition(@"In the Too Many Pages pop up, I confirm I see the pop up footer area")]
		public void InTheRecentActivitiesPageTooManyPagesPopUpISeeFooterArea()
		{
			Report.IsTrue(new RecentActivities.TooManyPagesPopup().InTheTooManyPagesPopUpFooterAreaIsDisplayed(), "The Too Many Pages Pop Up Footer is not displayed", "Too Many Pages Pop Up Footer is displayed successfully");
		}

		[StepDefinition(@"In the Too Many Pages pop up footer area, I confirm I see two buttons:Show Filters, Close")]
		public void InTheRecentActivitiesPageTooManyPagesPopUpButtonsAreDisplayed()
		{
			Report.IsTrue(new RecentActivities.TooManyPagesPopup().InTheTooManyPagesPopUpFooterButtonsAreDisplayed(), "The Too Many Pages Pop Up buttons is not displayed", "Too Many Pages Pop Up buttons is displayed successfully");
		}
 

		[StepDefinition(@"In the Documents pop up, I confirm Product Name is displayed")]
		public void InTheRecentActivitiesPageDocuemntsPopUpIConfirmProductNameIsDisplayed()
		{
			Report.IsTrue(new RecentActivities.DocumentsPopup().InTheDocumentsPopUpProductName(), "Failed to display Product Name", "Successfully displayed Product Name");
		}

		[StepDefinition(@"I Verify List of File Names is displayed in Documentation Popup")]
		public void InTheDocumentationPopUpIVerifyListOfFileNamesIsDisplayed()
		{
			Report.IsTrue(new RecentActivities.DocumentsPopup().InTheDocumentsPopUpFileNameListIsDisplayed(), "Failed to display files list", "Successfully displayed Files list");
		}

		[StepDefinition(@"I Verify document type label: SDS is displayed in Documentation Popup")]
		public void InTheDocumentationPopUpIVerifyDocuemntTypeLabelSDSIsDisplayed()
		{
			Report.IsTrue(new RecentActivities.DocumentsPopup().InTheDocumentsPopUpDocumentTypeLabelSDSIsDisplayed(), "Failed to display document type label", "Successfully displayed document type label");
		}

		[StepDefinition(@"I Verify File name is clickable in Documentation Popup")]
		public void InTheDocumentationPopUpIVerifyFileNameIsClickable()
		{
			Report.IsTrue(new RecentActivities.DocumentsPopup().InTheDocumentsPopUpFileNameIsClickable(), "Failed to verify that file name is clickable", "Successfully verified that file name is clickable");
		}

		[StepDefinition(@"Click on the filename link")]
		public void InTheDocumentationPopUpClickOnFileName()
		{
			Report.IsTrue(new RecentActivities.DocumentsPopup().InTheDocumentsPopUpClickFileName(), "Failed to click file name", "Successfully clicked file name");
		}


		[StepDefinition(@"Confirm the filename shown to the left of the SDS label is the same as the product ID you noted for the product in Studio followed by .PDF")]
		public void InTheDocumentationPopUpConfirmTheFileNameAsNotesInStudio(string savedAs)
		{
			string productCode = new StudioDocuments().TakeNoteOfProductCode(savedAs);
			Report.Info(productCode);
			Report.IsTrue(new RecentActivities.DocumentsPopup().GetFileName().Contains(productCode), "Product code is not displayed in file name", "Product is displayed in filename successfully");
			Report.IsTrue(new RecentActivities.DocumentsPopup().GetFileName() == productCode + ".pdf", "Product ID  is not matched with file name", "Product ID is matched with file name successfully");
		}

		[StepDefinition(@"Confirm the file that is opened is the same as the NGHS file you opened in Studio")]
		public void FileOpenedIsSameAsNGHSFileOpenedInStudio()
		{
			var widgetPage = new WidgetPage();
			Delay.Seconds(3);
			string docURL = widgetPage.DocumentWindowOpen();
			Report.Screenshot();

			if (docURL != null)
			{
				string pdfText = widgetPage.DocumentText(docURL);
				string newTextFromPDF = GeneralUtilities.ConvertTextToNoSpaceString(pdfText);
				string pdfTextFromStudio = new NGHSDocument().GetPdfText();
				Report.IsTrue(pdfTextFromStudio == newTextFromPDF, "Failed to match the 2 PDFs " , "Successfully matched the 2 PDFs" );
			}
			else
			{
				Report.Error("Tabbed document has not been found as expected");
			}
		}

		[StepDefinition(@"Confirm the filename shown to the left of the SDS file label matches the filename you noted in SHA manager")]
		public void InTheDocumentationPopUpConfirmTheFileNameAsNotedInStudio(string savedAs)
		{
			string fileName = new StudioDocuments().TakeNoteOfFileName(savedAs);
			Report.Info(fileName);
			Report.IsTrue(new RecentActivities.DocumentsPopup().GetFileName().Contains(fileName), "Failed to display File Name", "Successfully displayed file name");
			Report.IsTrue(new RecentActivities.DocumentsPopup().GetFileName() == fileName + ".pdf", "File name  is not matched with file name in sha", "File name is matched with sha file name successfully");
		}

		[StepDefinition(@"Confirm the Alias Product you selected is shown in the Product ID field saved as: (.*)")]
		public void GivenInDocumentsPageICheckIfTheAliasNameMatchesProductSavedAsProductID(string savedAs, string retailer)
		{
			string productID = new SelectProduct().TakeNoteOfAliasPrroductID(savedAs, retailer);
			Report.IsTrue(new StudioPowerDesignerPlus().GetProductID() == productID, "Alias product Id  is not matched with product id", "Alias product id is matched with product id successfully");

		}

		[StepDefinition(@"I close the document list pop up")]
		public void ICloseTheDocumentListPopUp()
		{
			Report.IsTrue(new RecentActivities.DocumentsPopup().InTheDocumentsPopUpClickClose(), "Failed to close the document popup", "Successfully closed the document popup");
		}

		[StepDefinition(@"I confirm For WVs TC 146009 - US & Canada , PLP No, GenDoc 1, GENDocCA 1, Doc Accepted Yes product shows the documents type: SDS")]
		public void IConfirmSDSIsDisplayedForTC146009AcceptedYes()
		{
			string documentType = "SDS";
			Report.IsTrue(new RecentActivities.DocumentsPopup().InTheDocumentsPopUpSDSIsDisplayedForTC146009AcceptedYes() == documentType, "Document type is not SDS", "Document type is SDS");
		}

		[StepDefinition(@"I confirm For WVs TC 146064 - US & Canada , PLP No, GenDoc 1, GenDocCA 1 Doc Accepted No \(User rejects published SDS and uploads his own\) product shows the documents type: SDS")]
		public void IConfirmSDSIsDisplayedForTC146009AcceptedNo()
		{
			string documentType = "SDS";
			Report.IsTrue(new RecentActivities.DocumentsPopup().InTheDocumentsPopUpSDSIsDisplayedForTC146009AcceptedNo() == documentType, "Document type is not SDS", "Document type is SDS");
		}

		[StepDefinition(@"I confirm For WVs TC 146098 - US & Canada , PLP No, GenDoc 0, GenDocCA 0 product shows the documents type: SDS")]
		public void IConfirmSDSIsDisplayedForTC146009()
		{
			string documentType = "SDS";
			Report.IsTrue(new RecentActivities.DocumentsPopup().InTheDocumentsPopUpSDSIsDisplayedForTC146009() == documentType, "Document type is not SDS", "Document type is SDS");
		}


		[StepDefinition(@"I confirm  in the Document List pop up, below the main product and the SDS document confirm you see the following three battery products: For WVs TC 1460009 - US & Canada , PLP No, GenDoc 1, GENDocCA 1, Doc Accepted Yes; For WVs TC 146064 - US & Canada , PLP No, GenDoc 1, GenDocCA 1 Doc Accepted No \(User rejects published SDS and uploads his own\); For WVs TC 146098 - US & Canada , PLP No, GenDoc 0, GenDocCA 0")]
		public void IConfirmBatteryProductsAreDisplayedBelowMainProductForNotPLP()
		{
			var batteryProducts = new List<string>() { "Test case 1460009 US & Canada , PLP No, GenDoc 1, GENDocCA 1, Doc Accepted Yes", "Test Case 146064 - US & Canada , PLP No, GenDoc 1, GenDocCA 1 Doc Accepted No (User rejects published SDS and uploads his own)", "Test case 146098 - US & Canada , PLP No, GenDoc 0, GenDocCA 0" };

			List<string> batteryProductNames = new RecentActivities.DocumentsPopup().GetBatteryProducts();
			var differences = batteryProducts.Except(batteryProductNames);
			Report.IsTrue(differences.IsNullOrEmpty(), "The battery products are not displayed", "The battery products are displayed");
		}

		[StepDefinition(@"I confirm  in the Document List pop up, below the main product and the SDS document confirm you see the following two battery products: Test Case 146102 - PLP name for xx wehere xx is retailer name; Test Case 146206 - PLP name for xx wehere xx is retailer name: (.*)")]
		public void IConfirmBatteryProductsAreDisplayedBelowMainProductsForPLP(string retailer)
		{
			retailer = retailer.Substring(4);
			var batteryProducts = new List<string>() { "Test Case 146102 - PLP name for " + retailer, "Test Case 146206 - PLP name for " + retailer };
			List<string> batteryProductNames = new RecentActivities.DocumentsPopup().GetBatteryProducts();
			var differences = batteryProducts.Except(batteryProductNames);
			Report.IsTrue(differences.IsNullOrEmpty(), "The battery products are not displayed", "The battery products are displayed");
		}

		[StepDefinition(@"I confirm Test Case 146102 - PLP name shows the documents type: SDS")]
		public void IConfirmSDSIsDisplaydForTC146102()
		{
			string documentType = "SDS";
			Report.IsTrue(new RecentActivities.DocumentsPopup().InTheDocumentsPopUpSDSIsDisplayedForTC1TC146102() == documentType, "Document type is not SDS", "Document type is SDS");
		}

		[StepDefinition(@"I confirm Test Case 146206 - PLP name shows the documents type: SDS")]
		public void IConfirmSDSIsDisplaydForTC146206()
		{
			string documentType = "SDS";
			Report.IsTrue(new RecentActivities.DocumentsPopup().InTheDocumentsPopUpSDSIsDisplayedForTC146206() == documentType, "Document type is not SDS", "Document type is SDS");
		}

		[StepDefinition(@"Confirm the file that is opened is the same as the SDS SUmmary Sheet file you opened in Studio")]
		public void FileOpenedIsSameAsSDSSummarySheetFileOpenedInStudio()
		{
			var widgetPage = new WidgetPage();
			Delay.Seconds(3);
			string docURL = widgetPage.DocumentWindowOpen();
			Report.Screenshot();

			if (docURL != null)
			{
				string pdfText = widgetPage.DocumentText(docURL);
				string newTextFromPDF = GeneralUtilities.ConvertTextToNoSpaceString(pdfText);
				string pdfTextFromStudio = new SummarySheetDocument().GetPdfText();
				Report.IsTrue(pdfTextFromStudio == newTextFromPDF, "Failed to match the 2 PDFs ", "Successfully matched the 2 PDFs");
			}
			else
			{
				Report.Error("Tabbed document has not been found as expected");
			}
		}

		[StepDefinition(@"Confirm you see the message: No documents found for this UPC in Documentation Popup")]
		public void InTheDocumentationPopUpIVerifyDocumentNotFoundIsDisplayed()
		{
			Report.IsTrue(new RecentActivities.DocumentsPopup().InTheDocumentsPopUpDocumentsNotFound(), "Failed to display the message", "Successfully displayed the message");
		}

		[StepDefinition(@"Confirm the Consumar Label file that is opened is the same as the file you opened in Studio related documents earlier")]
		public void FileOpenedIsSameAsConsumerLabelFileOpenedInStudio()
		{
			var widgetPage = new WidgetPage();
			Delay.Seconds(3);
			string docURL = widgetPage.DocumentWindowOpen();
			Report.Screenshot();

			if (docURL != null)
			{
				string pdfText = widgetPage.DocumentText(docURL);
				string newTextFromPDF = GeneralUtilities.ConvertTextToNoSpaceString(pdfText);
				string pdfTextFromStudio = new RelatedDocuments().GetPdfText();
				Report.IsTrue(pdfTextFromStudio == newTextFromPDF, "Failed to match the 2 PDFs ", "Successfully matched the 2 PDFs");
			}
			else
			{
				Report.Error("Tabbed document has not been found as expected");
			}
		}

		[StepDefinition(@"In the documents list, confirm you see the document type label: Consumer Label")]
		public void InTheDocumentationPopUpIVerifyDocuemntTypeLabelConsumerlabelIsDisplayed()
		{
			Report.IsTrue(new RecentActivities.DocumentsPopup().InTheDocumentsPopUpDocumentTypeLabelConsumerLabelIsDisplayed(), "Failed to display document type label", "Successfully displayed document type label");
		}

		[StepDefinition(@"Confirm the filename shown to the left of the Consumer Label file label is the same as you saw earlier in: Studio")]
		public void IConfirmTheFileNameShownLeftOfConsumerlabelIsSameAsNotedInStudio(string savedAs)
		{
			string fileName = new RelatedDocuments().MakeANoteOfFileNameWithUserTypeSHAMANAGER(savedAs);
			Report.IsTrue(new RecentActivities.DocumentsPopup().GetFileName().Contains(fileName), "failed to match file name", "Matched the filename successfully");
		}

		[StepDefinition(@"Confirm the file that is opened is the same as the SDS file you opened in Studio")]
		public void FileOpenedIsSameAsSDSFileOpenedInStudio()
		{
			var widgetPage = new WidgetPage();
			Delay.Seconds(3);
			string docURL = widgetPage.DocumentWindowOpen();
			Report.Screenshot();

			if (docURL != null)
			{
				string pdfText = widgetPage.DocumentText(docURL);
				string newTextFromPDF = GeneralUtilities.ConvertTextToNoSpaceString(pdfText);
				string pdfTextFromStudio = new NGHSDocument().GetPdfText();
				Report.IsTrue(pdfTextFromStudio == newTextFromPDF, "Failed to match the 2 PDFs ", "Successfully matched the 2 PDFs");
			}
			else
			{
				Report.Error("Tabbed document has not been found as expected");
			}
		}

		[StepDefinition(@"I confirm that I do not see a document type label of SDS")]
		public void InTheDocumentationPopUpIVerifyDocuemntTypeLabelSDSIsNotDisplayed()
		{
			Report.IsFalse(new RecentActivities.DocumentsPopup().InTheDocumentsPopUpDocumentTypeLabelSDSIsDisplayed(), "SDS label is displayed", "Successfully SDS document type label is not displayed");
		}

		[StepDefinition(@"I confirm Test Case 146102 - PLP name shows the documents types:")]
		[StepDefinition(@"I confirm For Test Battery - TC 145494 - Lithium Ion Battery, PLP, with Uploaded SDS, PLP name shows the two documents types:")]
		[StepDefinition(@"I confirm For WVs TC 146009 - US & Canada , PLP No, GenDoc 1, GENDocCA 1, Doc Accepted Yes product shows the documents type:")]
		public void IConfirmListOfSDSIsDisplayedForTC146009AcceptedYes(Table table)
		{
			List<string> expectedDocumentTypes = new List<string>();
			foreach (TableRow thisRow in table.Rows)
			{
				expectedDocumentTypes.Add(thisRow["Document Types"]);
				
			}

			List<string> foundDocumentTypes = new RecentActivities.DocumentsPopup().InTheDocumentsPopUpListOfSDSIsDisplayedForTC146009AcceptedYes();
			var differences = expectedDocumentTypes.Except(foundDocumentTypes);
			Report.IsTrue(differences.IsNullOrEmpty(), "The documents types found were not as expected", "The documents types found matched the expected document types");
		}

		[StepDefinition(@"I confirm Test Case 146206 - PLP name shows the documents types:")]
		[StepDefinition(@"I confirm For Test Battery - TC 145489 - Lithium Ion Battery, PLP, with Authored SDS, PLP name shows the two documents types :")]
		[StepDefinition(@"I confirm For WVs TC 146064 - US & Canada , PLP No, GenDoc 1, GenDocCA 1 Doc Accepted No \(User rejects published SDS and uploads his own\) product shows the documents type:")]
		public void IConfirmListOfSDSIsDisplayedForTC146064AcceptedNo(Table table)
		{
			List<string> expectedDocumentTypes = new List<string>();
			foreach (TableRow thisRow in table.Rows)
			{
				expectedDocumentTypes.Add(thisRow["Document Types"]);
			}

			List<string> foundDocumentTypes = new RecentActivities.DocumentsPopup().InTheDocumentsPopUpListOfSDSIsDisplayedForTC146064AcceptedNo();
			var differences = expectedDocumentTypes.Except(foundDocumentTypes);
			Report.IsTrue(differences.IsNullOrEmpty(), "The documents types found were not as expected", "The documents types found matched the expected document types");
		}

		[StepDefinition(@"I confirm For Test Battery - TC 145493 - Lithium Ion Battery, PLP, with Uploaded AIS, PLP name shows one document types:")]
		[StepDefinition(@"I confirm For WVs TC 146098 - US & Canada , PLP No, GenDoc 0, GenDocCA 0 product shows the documents type:")]
		public void IConfirmListOfSDSIsDisplayedForTC146098(Table table)
		{
			List<string> expectedDocumentTypes = new List<string>();
			foreach (TableRow thisRow in table.Rows)
			{
				expectedDocumentTypes.Add(thisRow["Document Types"]);
			}

			List<string> foundDocumentTypes = new RecentActivities.DocumentsPopup().InTheDocumentsPopUpListOfSDSIsDisplayedForTC146098();
			var differences = expectedDocumentTypes.Except(foundDocumentTypes);
			Report.IsTrue(differences.IsNullOrEmpty(), "The documents types found were not as expected", "The documents types found matched the expected document types");
		}

		[StepDefinition(@"I confirm  In the Document List pop up, below the main product and the SDS document confirm you see the following three battery products:")]
		public void IConfirmListOfBatteryProductsAreDisplayed(Table table)
		{
			List<string> expectedDocumentTypes = new List<string>();
			foreach (TableRow thisRow in table.Rows)
			{
				expectedDocumentTypes.Add(thisRow["Document List"]);
			}

			List<string> foundDocumentTypes = new RecentActivities.DocumentsPopup().InTheDocumentsPopUpListOfDocumentsIsDisplayed();
			var differences = expectedDocumentTypes.Except(foundDocumentTypes);
			Report.IsTrue(differences.IsNullOrEmpty(), "The documents list found were not as expected", "The documents list found matched the expected document list");
		}

        
		[StepDefinition(@"Confirm the file that is opened is the same as the HGHS file you opened in Studio")]
		public void FileOpenedIsSameAsHGHSFileOpenedInStudio()
		{
			var widgetPage = new WidgetPage();
			Delay.Seconds(3);
			string docURL = widgetPage.DocumentWindowOpen();
			Report.Screenshot();

			if (docURL != null)
			{
				string pdfText = widgetPage.DocumentText(docURL);
				string newTextFromPDF = GeneralUtilities.ConvertTextToNoSpaceString(pdfText);
				string pdfTextFromStudio = new NGHSDocument().GetPdfText();
				Report.IsTrue(pdfTextFromStudio == newTextFromPDF, "Failed to match the 2 PDFs ", "Successfully matched the 2 PDFs");
			}
			else
			{
				Report.Error("Tabbed document has not been found as expected");
			}
		}

        [StepDefinition(@"In the product table, in the Actions column, I click: View Data")]
        public void InTheProductTableActionsColumnClickViewData()
        {
            Report.IsTrue(new ProductLookUp().ClickActionForFirstResultInGrid("View Data"), "Failed to click the action for the first product", "Successfully clicked the action for the first product");
        }

 

        [StepDefinition(@"In the recent activities Page, In the Products table I search for the product: (.*)")]
        public void InTheRecentActivitiesPageInProductsTableSearchForProduct(string productName)
        {
            new RecentActivities().EnterSearchBoxText(productName);
            Report.IsTrue(new RecentActivities().CheckSearchBoxContains(productName), "The search box did not contain the text that was searched for", "The search box contained the text that was searched for");

        }

        [StepDefinition(@"In the recent activities Page, In the Products table I enter product text: (.*) and press the Enter Key")]
        public void InTheRecentActivitiesPageInProductsTableSearchForProducAndPressEnter(string productName)
        {
            new RecentActivities().EnterSearchBoxTextAndpressEnterKey(productName);
            Report.IsTrue(new RecentActivities().CheckSearchBoxContains(productName), "The search box did not contain the text that was searched for", "The search box contained the text that was searched for");

        }

    }


}