using System;
using Reqnroll;
using TReVor.Api.Wrapper.Classes;
using UL.Automation.Reporting;
using UL.Automation.Reporting.Classes;
using UL.Automation.Reporting.Functions;
using UL.Automation.ReqnrollHelpers.Classes;
using TReVor.Integrations.Classes;
using UL.Automation.WebDriver.Classes;
using UL.Selenium.Portal.RPS.Selenium_Classes;
using TReVor.Core.Classes.Software;
using UL.Automation.TReVor.Classes;

namespace UL.Selenium.Portal.RPS.Steps
{
    [Binding, Scope(Tag = "SuperTable")]
    class Steps_SuperTable
    {
        [StepDefinition(@"In the table, I confirm that row #([1-9][0-9]*) (does|does not) exists")]
        public void InTableConfirmRowExists(string rowNumberString, string does_doesnot)
        {
            int rowNumber = int.Parse(rowNumberString);
            bool expected = does_doesnot == "does";
            var gridTable = new GridTable();
            Report.IsTrue(!(gridTable.GridTableRowExists(rowNumber) ^ expected), $"Failure, row #{rowNumber} {(expected ? "does not" : "does")} exist.", $"Success, row #{rowNumber} {does_doesnot} exist as expected.");
        }

        [StepDefinition(@"In the table, in row #(.*), I save the (Product Name|UPC|WPSID|Supplier Name) as: (.*)")]
        public void InTableRowSaveValueAs(string rowNumberString, string valueLabel, string savedAs)
        {
            var gridTable = new GridTable();
            string value;
            int rowNumber = int.Parse(rowNumberString);
            string does_doesnot = "does";
            bool expected = does_doesnot == "does";
            if (!Report.IsTrue(!(gridTable.GridTableRowExists(rowNumber) ^ expected), $"Failure, row #{rowNumber} {(expected ? "does not" : "does")} exist.", $"Success, row #{rowNumber} {does_doesnot} exist as expected."))
            {
                return;
            }
            switch (valueLabel)
            {
                case "Product Name":
                    value = gridTable.ProductInfoCellNameGet(gridTable.ProductInfoCellGet(rowNumber));
                    break;
                case "UPC":
                    value = gridTable.ProductInfoCellUPCGet(gridTable.ProductInfoCellGet(rowNumber));
                    break;
                case "WPSID":
                    value = gridTable.ProductInfoCellWPSIDGet(gridTable.ProductInfoCellGet(rowNumber));
                    break;
                case "Supplier Name":
                    value = gridTable.ProductInfoCellCompanyNameGet(gridTable.ProductInfoCellGet(rowNumber));
                    break;
                default:
                    Report.Error("Error: inccorect Value Label entered.");
                    return;
            }
            Report.Info($"Saving the {valueLabel}: '{value}' to context as: '{savedAs}'.");
            Context.AddToContext(savedAs, value);
        }

        [StepDefinition(@"In the table footer, I save the total number of rows as: (.*)")]
        public void InTableSaveTotalNumberOfRowsAs(string savedAs)
        {
            Report.Info($"Attempting to save the total number of rows as: '{savedAs}'.");
            Context.AddToContext(savedAs, new SuperTableFooter().RowIndexValueGet("total"));
        }

        [StepDefinition(@"In the table footer, I confirm the total number of rows (does|does not) match: ([1-9][0-9]*)")]
        public void InTableConfirmTotalNumberOfRows(string does_doesnot, string expectedValueString)
        {
            Report.Info($"Attempting to confirm total number of rows {does_doesnot} match '{expectedValueString}'.");
            bool expected = does_doesnot == "does";
            Report.IsTrue(!((expectedValueString == new SuperTableFooter().RowIndexValueGet("total")) ^ expected), $"Failure, total number of rows should {(expected ? "match" : "not match")} {expectedValueString}.", $"Success, total number of rows {does_doesnot} match {expectedValueString} as expected.");
        }

        [StepDefinition(@"In the table footer, I confirm the total number of rows (does|does not) match value saved as: (.*)")]
        public void InTableConfirmTotalNumberOfRowsSavedAs(string does_doesnot, string savedAs)
        {
            Report.Info($"Attempting to get '{savedAs}' from context.");
            string expectedValueString = Context.GetFromContext(savedAs).ToString();
            InTableConfirmTotalNumberOfRows(does_doesnot, expectedValueString);
        }

        [StepDefinition(@"In the table footer, I confirm the rows per page selector (does|does not) exist")]
        public void InTableFooterConfirmRowsPerPageSelectorDoesDoesNotExist(string does_doesnot)
        {
            Report.Info($"Attempting to confirm rows per page selector {does_doesnot} exist.");
            bool expected = does_doesnot == "does";
            Report.IsTrue(!(new SuperTableFooter().RowsPerPageSelectorExists() ^ expected), $"Failure, rows per page selector {(expected ? "does not" : "does")} exist and {(expected?"should":"should not")}.", $"Success, rows per page selector {does_doesnot} exist, as expected.");
        }

        [StepDefinition(@"In the table footer, I confirm the page navigation controls (do|do not) exist")]
        public void InTableFooterConfirmPageNavigationCotrolsnDoDoNotExist(string do_donot)
        {
            Report.Info($"Attempting to confirm page navigation controls {do_donot} exist.");
            bool expected = do_donot == "do";
            var superTableFooter = new SuperTableFooter();
            string[] buttonLabels = { "First Page", "Previous Page", "Next Page", "Last Page" };
            bool result = true;
            foreach(string buttonLabel in buttonLabels)
            {
                result &= Report.IsTrue(!(superTableFooter.PagiatorButtonExists(buttonLabel) ^ expected), $"Failure, '{buttonLabel}' pagiator button {(expected ? "does not" : "does")} exist and {(expected?"should":"should not")}.", $"Success, '{buttonLabel}' pagiator button {(expected ? "does" : "does not")} exist, as expected.");
            }
            Report.IsTrue(result, $"Failure, page navigation controls {(expected ? "do not" : "do")} exist and {(expected ? "should" : "should not")}.", $"Success, page navigation controls {do_donot} exist as expected.");
        }

        [StepDefinition(@"In the table footer, I confirm the row index (does|does not) exist")]
        public void InTableFooterConfirmRowIndexDoesDoesNotExist(string does_doesnot)
        {
            Report.Info($"Attempting to confirm row index {does_doesnot} exist.");
            bool expected = does_doesnot == "does";
            Report.IsTrue(!(new SuperTableFooter().RowIndexExists() ^ expected), $"Failure, row index {(expected ? "does not" : "does")} exist and {(expected ? "should" : "should not")}.");
        }

        [StepDefinition(@"In the table navigation bar, I click the '(.*)' button")]
        public void InTableHeaderClickButton(string buttonLabel)
        {
            var superTableNav = new SuperTableNav();
            Report.IsTrue(superTableNav.NavButtonExists(buttonLabel), $"Failure, '{buttonLabel}' button does not exist.", $"Success, '{buttonLabel}' button exists.");
            Report.IsTrue(superTableNav.NavButtonClick(buttonLabel), $"Failure, unable to click '{buttonLabel}' button.", $"Success, clicked '{buttonLabel}' button.");
            Delay.Seconds(5);
        }

        [StepDefinition(@"In the table navigation bar, I click the '(.*)' button and save the time to context as: (.*)")]
        public void InTableHeaderClickButtonAndSaveAs(string buttonLabel, string savedAs)
        {
            var superTableNav = new SuperTableNav();
            Report.IsTrue(superTableNav.NavButtonExists(buttonLabel), $"Failure, '{buttonLabel}' button does not exist.", $"Success, '{buttonLabel}' button exists.");
            Report.IsTrue(superTableNav.NavButtonClick(buttonLabel), $"Failure, unable to click '{buttonLabel}' button.", $"Success, clicked '{buttonLabel}' button.");
            DateTime dtNow = DateTime.UtcNow;
            Context.AddToContext(savedAs, dtNow);
            Delay.Seconds(5);
        }

        [StepDefinition(@"I confirm the More Filters modal is (open|closed)")]
        public void ConfirmMoreFiltersModalOpenClosed(string open_closed)
        {
            bool expected = open_closed == "open";
            Report.IsTrue(!(new BaseModalDialog().ContainerVisible() ^ expected), $"Failure, More Filters modal should be {open_closed} and is not.", $"Success, More Filters modal is {open_closed}.");
        }

        [StepDefinition(@"In the More Filters Modal, I open the Filter By selector")]
        public void InMoreFiltersModalOpenFilterBySelector()
        {
            Report.Info("Attempting to open the Filter By selector.");
            new MoreFiltersModal().FilterBySelectorClick();
        }

        [StepDefinition(@"In the More Filters Modal Filter By Selector, I select the (.*) option")]
        public void InMoreFitlersModalFilterBySelectorSelectOption(string optionLabel)
        {
            Report.Info($"Attempting to open the '{optionLabel}' option in the Filter By selector.");
            var moreFiltersModal = new MoreFiltersModal();
            Report.IsTrue(moreFiltersModal.FilterBySelectorExists(), "Failure, Filter By Selector doesn't exist.", "Success, Filter By Selector exists.");
            Report.IsTrue(moreFiltersModal.FilterBySelectorClick(), "Failure, failed to click the Filter By Selector.", "Success, clicked on the Filter By Selector.");
            Report.IsTrue(moreFiltersModal.FilterBySelectorDropdownOpen(), "Failure, Filter By Selector is not open.", "Success, Filter By Selector is open.");
            Report.IsTrue(moreFiltersModal.FilterBySelectorDropdownOptionExists(optionLabel), $"Failure, '{optionLabel}' option does not exist.", $"Success, '{optionLabel}' option exists.");
            Report.IsTrue(moreFiltersModal.FilterBySelectorDropdownOptionClick(optionLabel), $"Failure, failed to click '{optionLabel}' option.", $"Success, clicked '{optionLabel}' option.");
            Report.IsTrue(moreFiltersModal.ModalSpinnerWaitToDisappear(), "Failure, results failed to load in time.", "Success, results loaded in time.");
        }

        [StepDefinition(@"In the More Filters Modal, I confirm the (.*) Options list is shown")]
        public void InMoreFilterModalConfirmOptionListShownNotShown(string optionLabel)
        {
            var moreFiltersModal = new MoreFiltersModal();
            Report.IsTrue(moreFiltersModal.FilterOptionAreaExists(), "Failure, Filter Option area doesn't exist.", "Success, Filter Option area exists.");
            Report.IsTrue(moreFiltersModal.FilterOptionTitleExists(), "Failure, Filter Option Title doesn't exist.", "Success, Filter Option Title exists.");
            //Report.IsTrue(moreFiltersModal.FilterOptionTitleGet() == optionLabel, $"Failure, expected title: '{optionLabel}' does not match displayed title: '{moreFiltersModal.FilterOptionTitleGet()}'.", "Success, expected title matches displayed title.");
            Report.IsTrue(moreFiltersModal.FilterOptionOptionsListExists(), "Failure, Filter Option Options List does not exist.", "Success, Filter Option Options List exists.");
        }

        [StepDefinition(@"In the More Filters Modal Filter Option Options List, I save Option #([1-9][0-9]*) to context as: (.*)")]
        public void InMoreFiltersModalFilterOptionOptionsListSaveOptionNumberAs(string iOptionString, string saveAs)
        {
            var moreFiltersModal = new MoreFiltersModal();
            Report.IsTrue(int.TryParse(iOptionString, out int iOption), $"Failure, '{iOptionString}' was unable to be parsed as a number.", "Success, option number correctly parsed.");
            iOption = iOption - 1;
            Report.Info($"Attempting to save Filter Option Options List Option #{iOptionString} to context as: '{saveAs}'.");
            Report.IsTrue(moreFiltersModal.FilterOptionAreaExists(), "Failure, Filter Option area doesn't exist.", "Success, Filter Option area exists.");
            Report.IsTrue(moreFiltersModal.FilterOptionOptionsListExists(), "Failure, Filter Option Options List does not exist.", "Success, Filter Option Options List exists.");
            Report.IsTrue(moreFiltersModal.FilterOptionOptionsListOptionExists(iOption), $"Failure, Option #{iOptionString} does not exist in Filter Options Option List.", $"Success, Option #{iOptionString} exists.");
            string optionLabel = moreFiltersModal.FilterOptionOptionsListOptionLabelGet(iOption);
            Context.AddToContext(saveAs, optionLabel);
            Report.IsTrue(Context.Contains(saveAs), $"Failure, failed to save Option #{iOptionString}: '{optionLabel}' to context as '{saveAs}'.", $"Success, saved Option #{iOptionString}: '{optionLabel}' to context as '{saveAs}'");
        }

        [StepDefinition(@"In the More Filters Modal Filter Option Options List, I add Option #([1-9][0-9]*) to the filter list")]
        public void InMoreFiltersModalFilterOptionOptionsListClickOptionNumber(string iOptionString)
        {
            var moreFiltersModal = new MoreFiltersModal();
            Report.IsTrue(int.TryParse(iOptionString, out int iOption), $"Failure, '{iOptionString}' was unable to be parsed as a number.", "Success, option number correctly parsed.");
            iOption = iOption - 1;
            Report.Info($"Attempting to add  Filter Option Options List Option #{iOptionString} to the filter list.");
            Report.IsTrue(moreFiltersModal.FilterOptionAreaExists(), "Failure, Filter Option area doesn't exist.", "Success, Filter Option area exists.");
            Report.IsTrue(moreFiltersModal.FilterOptionOptionsListExists(), "Failure, Filter Option Options List does not exist.", "Success, Filter Option Options List exists.");
            Report.IsTrue(moreFiltersModal.FilterOptionOptionsListOptionExists(iOption), $"Failure, Option #{iOptionString} does not exist in Filter Options Option List.", $"Success, Option #{iOptionString} exists.");
            string optionLabel = moreFiltersModal.FilterOptionOptionsListOptionLabelGet(iOption);
            Report.IsTrue(moreFiltersModal.FilterOptionOptionsListOptionClick(iOption), $"Failure, failed to click Option #{iOptionString}.", $"Success, clicked Option #{iOptionString}.");
            Report.IsTrue(moreFiltersModal.BreadcrumbContainerExists(), "Failure, Breadcrumb Container doesn't exist.", "Success, Breadcrumb container exists.");
            Report.IsTrue(moreFiltersModal.BreadcrumbExists(optionLabel), $"Failure, '{optionLabel}' breadcrumb does not exist.", $"Success, '{optionLabel}' breadcrumb exists.");
        }

        [StepDefinition(@"In the More Filters Modal, I click the (.*) button")]
        public void InMoreFiltersModalClickButton(string buttonLabel)
        {
            var moreFiltersModal = new MoreFiltersModal();
            Report.IsTrue(moreFiltersModal.ButtonWithTextDisplayed(buttonLabel), $"Failure, '{buttonLabel}' button is not displayed.", $"Success, '{buttonLabel}' button is displayed.");
            Report.IsTrue(moreFiltersModal.ClickButtonByText(buttonLabel), $"Failure, failed to click '{buttonLabel}' button.", $"Success, clicked '{buttonLabel}' button.");
            //Report.IsTrue(new GridTable().GridTableLoadingSpinnerWaitToDisappear(), $"Failure, failed to load updates.", "Success, loaded updates");
            Delay.Seconds(5);
        }

        [StepDefinition(@"In the Product Info Cell in row #([1-9][0-9]*), the (.*) value (does|does not) match: (.*)")]
        public void InProductInfoCellInRowValueDoesDoesNotMatch(string rowNumberString, string picLabel, string does_doesnot, string valueExpected)
        {
            var gridTable = new GridTable();
            bool expected = does_doesnot == "does";
            if (valueExpected == "<wpsid>")
            {
                valueExpected = TestVariables.GetVariableSavedAs("WPSID");
            }
            Report.IsTrue(int.TryParse(rowNumberString, out int rowNumber), $"Failure, '{rowNumberString}' was unable to be parsed as a number.", "Success, option number correctly parsed.");
            if(Report.IsTrue(gridTable.ProductInfoCellExists(rowNumber), $"Failure, table row #{rowNumber} does not exist.", $"Success, table row #{rowNumber} exists."))
            {
                string valueDisplayed;
                switch (picLabel)
                {
                    case "Product Name":
                        valueDisplayed = gridTable.ProductInfoCellNameGet(gridTable.ProductInfoCellGet(rowNumber));
                        break;
                    case "UPC":
                        valueDisplayed = gridTable.ProductInfoCellUPCGet(gridTable.ProductInfoCellGet(rowNumber));
                        break;
                    case "WPSID":
                        valueDisplayed = gridTable.ProductInfoCellWPSIDGet(gridTable.ProductInfoCellGet(rowNumber));
                        break;
                    case "Supplier Name":
                        valueDisplayed = gridTable.ProductInfoCellCompanyNameGet(gridTable.ProductInfoCellGet(rowNumber));
                        break;
                    default:
                        Report.Error($"Error: '{picLabel}' is not a valid label.");
                        return;
                }
                Report.IsTrue(!((valueDisplayed.StartsWith(valueExpected)) ^ expected), $"Failure, {picLabel} expected value: '{valueExpected}' {(expected ? "does not" : "does")} match value displayed: '{valueDisplayed}'.", $"Success, {picLabel} value: '{valueDisplayed}' {does_doesnot} match as expected.");
            }
        }

        [StepDefinition(@"In the Product Info Cell in row #([1-9][0-9]*), the (.*) value (does|does not) match value saved to context as: (.*)")]
        public void InProductInfoCellInRowValueDoesDoesNotMatchSavedToContext(string rowNumberString, string picLabel, string does_doesnot, string savedAs)
        {
            if (Report.IsTrue(Context.Contains(savedAs), $"Failure, no variable saved as '{savedAs}' in context.", $"Success, found variable saved as '{savedAs}' in context."))
            {
                var valueExpected = Context.GetFromContext(savedAs).ToString();
                InProductInfoCellInRowValueDoesDoesNotMatch(rowNumberString, picLabel, does_doesnot, valueExpected);
            }
        }

        [StepDefinition(@"In the Product Info Cell in row #([1-9][0-9]*), the (.*) colored (.*) tag (does|does not) show after the (Product Name|UPC|WPSID|Supplier Name)")]
        public void InTheRecentActivitesPageInProductTableFirstResultShowsTag(string rowNumberString, string tagColor, string tagLabel, string does_doesnot, string valueLabel)
        {
            var gridTable = new GridTable();
            bool expected = does_doesnot == "does";
            Report.IsTrue(int.TryParse(rowNumberString, out int rowNumber), $"Failure, '{rowNumberString}' was unable to be parsed as a number.", "Success, option number correctly parsed.");
            if (Report.IsTrue(gridTable.ProductInfoCellExists(rowNumber), $"Failure, table row #{rowNumber} does not exist.", $"Success, table row #{rowNumber} exists."))
            {
                Report.IsTrue(!(gridTable.ProductInfoCellTagExists(gridTable.ProductInfoCellGet(rowNumber), tagColor, tagLabel, valueLabel) ^ expected), $"Failure, {tagColor} '{tagLabel}' {(expected ? "does not" : "does")} exist and {(expected ? "should" : "should not")}.", $"Success, {tagColor} '{tagLabel}' {does_doesnot} exist, as expected");
            }
        }

        [StepDefinition(@"In the table navigation area, I confirm the Breadcrumb List (does|does not) exist")]
        public void InTableNavigationAreaConfirmBreadcrumbListExists(string does_doesnot)
        {
            bool expected = does_doesnot == "does";
            Report.IsTrue(!(new SuperTableNav().BreadcrumbListExists() ^ expected), $"Failure, breadcrumb list {(expected ? "does not" : "does")} exist.", $"Success, breadcrumb list {does_doesnot} exist.");
        }

        [StepDefinition(@"In the table navigation area, I confirm the Breadcrumb List (does|does not) contain the Breadcrumb labeled: (.*)")]
        public void InTableNavigationAreaConfirmBreadcrumbListContainsBreadcrumbLabeled(string does_doesnot, string breadcrumbLabel)
        {
            bool expected = does_doesnot == "does";
            Report.IsTrue(!(new SuperTableNav().BreadcrumbExists(breadcrumbLabel) ^ expected), $"Failure, breadcrumb '{breadcrumbLabel}' {(expected ? "does not" : "does")} appear in the breadcrumb list.", $"Success, breadcrumb '{breadcrumbLabel}' {does_doesnot} appear in the breadcrumb list.");
        }

        [StepDefinition(@"In the table navigation area, I confirm the Breadcrumb List (does|does not) contain the Breadcrumb label saved to context as: (.*)")]
        public void InTableNavigationAreaConfirmBreadcrumbListContainsBreadcrumbLabelSavedAs(string does_doesnot, string savedAs)
        {
            if (Report.IsTrue(Context.Contains(savedAs), $"Failure, no variable saved as '{savedAs}' in context.", $"Success, found variable saved as '{savedAs}' in context."))
            {
                var breadcrumbLabel = Context.GetFromContext(savedAs).ToString();
                InTableNavigationAreaConfirmBreadcrumbListContainsBreadcrumbLabeled(does_doesnot, breadcrumbLabel);
            }
        }

        [StepDefinition(@"In the table navigation area, in the Search Input, I enter: (.*)")]
        public void InTableNavigationAreaSearchInputEnter(string textString)
        {
            var superTableNav = new SuperTableNav();
            if (Report.IsTrue(superTableNav.SearchInputExists(), "Failure, table navigation search input does not exist.", "Success, table navigation search input exists"))
            {
                if (textString == "<wpsid>")
                {
                    textString = TestVariables.GetVariableSavedAs("WPSID");
                }

                Report.IsTrue(superTableNav.SearchInputEnterText(textString), $"Failure, failed to enter '{textString}' in the search input.", $"Success, entered '{textString}' in the search input.");
                Report.IsTrue(superTableNav.SearchInputTextGet() == textString, $"Failure, failed to confirm '{textString}' was entered in search input", $"Success, confirmed '{textString}' was entered in search input.");
            }
            Delay.Seconds(5);
        }
    }
}
