using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Castle.Core.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using UL.Automation.Reporting.Functions;
using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Classes;
using UL.Automation.WebDriver.Extensions;
using UL.Selenium.Portal.RPS.Classes;
using UL.Selenium.Portal.WERCSmart.Classes;

namespace UL.Selenium.Portal.RPS.Selenium_Classes
{
    public class DrumLog : WidgetPage
    {
        #region Page Objects

        protected override By ContainerElementLocator => By.XPath("//div[@id='drum-log-page']");

        private IWebElement OptionButtonsSection => this.containerElement.FindElement(By.XPath(".//div[@class='row search-row']"), 2);

        private IWebElement MoreFiltersOptionButton => this.OptionButtonsSection.FindElement(By.XPath(".//div//button[@id='btnMoreFilters']"), 2);

        private IWebElement BreadCrumbArea => this.containerElement.FindElement(By.XPath(".//div[@id='filterList']"), 2);

        private IWebElement PageTitle => this.containerElement.FindElement(By.XPath(".//h2"), 2);

        private IWebElement SearchBox => FindElement(By.XPath(".//input[@name='search']"), 2);

        public List<IWebElement> ProductLookUpButtons => this.containerElement.FindElements(By.XPath(".//div[@class='row search-row']//div[2]//*"), 2).ToList();

        private IWebElement TableHeadingRow => this.containerElement.FindElement(By.XPath(".//div[@id='gbox_tblDrumLog']//div[@class='ui-jqgrid-hdiv']//tr[@class='ui-jqgrid-labels']"), 2);

        private List<IWebElement> NamedTableHeadings => this.TableHeadingRow.FindElements(By.XPath(".//th[@role='columnheader' and not(contains(@style,'display: none')) and not(@id='tblDrumLog_subgrid')]"), 2).ToList();

        private List<IWebElement> AllTableHeadings => this.TableHeadingRow.FindElements(By.XPath(".//th[@role='columnheader' and not(contains(@style,'display: none'))]"), 2).ToList();

        private List<IWebElement> RowSubHeadings(IWebElement row) => row.FindElements(By.XPath(".//preceding-sibling::div[@class='ui-jqgrid-hdiv']//th[@role='columnheader' and not(contains(@style,'display: none'))]"), 2).ToList();

        private IWebElement ProductTable => this.containerElement.FindElement(By.XPath(".//table[@id='tblDrumLog']"), 1);

        private List<IWebElement> ProductRows => this.ProductTable?.FindElements(By.XPath(".//tbody//tr[not (@id='1') and not(@class='ui-jqgrid-labels') and not (@class='jqgfirstrow') and not(contains(@class,'expanded'))]"), 1).ToList();

        private IWebElement ProductsTableFooter => this.containerElement.FindElement(By.XPath(".//div[@id='tblDrumLogPager']"), 2);

        private IWebElement ItemsPerPageSelector => ProductsTableFooter.FindElement(By.XPath(".//select[@class='ui-pg-selbox form-control']"), 2);
        private IWebElement ResetOptionButton => this.OptionButtonsSection.FindElement(By.XPath(".//a[@id='btnReset']"), 2);
        private List<IWebElement> OnlyexpandedProductRows => this.ProductTable?.FindElements(By.XPath(".//tbody//tr[not (@id='1') and not (@class='ui-jqgrid-labels') and not (@class='jqgfirstrow') and (contains(@class,'ui-subgrid ui-sg-expanded'))]//div[@class='ui-jqgrid-bdiv']"), 1).ToList();
        private IWebElement RowSubHeadingLine(IWebElement row) => row.FindElement(By.XPath(".//preceding-sibling::div[@class='ui-jqgrid-hdiv']"), 2);
        private IWebElement NextPageButton => ProductsTableFooter.FindElement(By.XPath(".//td[@id='next_tblDrumLogPager' and @title='Next Page']//span[@class='glyphicon glyphicon-forward']"), 2);

        private IWebElement LastPageButton => ProductsTableFooter.FindElement(By.XPath(".//td[@id='last_tblDrumLogPager' and @title='Last Page']//span[@class='glyphicon glyphicon-step-forward']"), 2);

        private IWebElement PreviousPageButton => ProductsTableFooter.FindElement(By.XPath(".//td[@id='prev_tblDrumLogPager' and @title='Previous Page']//span[@class='glyphicon glyphicon-backward']"), 2);

        private IWebElement FirstPageButton => ProductsTableFooter.FindElement(By.XPath(".//td[@id='first_tblDrumLogPager' and @title='First Page']//span[@class='glyphicon glyphicon-step-backward']"), 2);
        private IWebElement ProductsCountEl => ProductsTableFooter.FindElement(By.XPath(".//td[@id='tblDrumLogPager_right']//div"), 2);

        #endregion

        #region Methods

        #endregion
        public bool WaitDrumLogWidgetSpinnerFinish()
        {
            if (this.containerElement.WaitUntilElementVisible(By.XPath(".//div[@id='load_tblDrumLog']"), 5) != null)
            {
                return this.containerElement.WaitUntilElementInvisible(By.XPath(".//div[@id='load_tblDrumLog']"), 30);
            }
            return true;
        }

        public bool ClickMoreFiltersOptionButton()
        {
            return this.MoreFiltersOptionButton.TryClick();
        }

        public bool ConfirmBreadCrumbAreaContainsLabel(string label)
        {
            var el = this.BreadCrumbArea;
            string test = el.Text;
            return el.Text.Contains(label);
        }

        public string GetDrumlogBackgroundColor()
        {
            IWebElement backgroundEl = this.containerElement.FindElement(By.XPath(".//ancestor::body"));
            if (backgroundEl == null)
            {
                Report.Error("The Background El was null");
                return null;
            }
            string rbgaCssValue = backgroundEl.GetCssValue("background-color");
            return rbgaCssValue;
        }

        public string GetDrumLogTextColor()
        {
            IWebElement backgroundEl = this.containerElement;
            if (backgroundEl == null)
            {
                Report.Error("The Background El was null");
                return null;
            }

            string rbgaCssValue = backgroundEl.GetCssValue("color");
            return rbgaCssValue;
        }

        public string GetCurrentPageTitle()
        {
            return this.PageTitle.Text;
        }

        public bool SearchBoxPresent()
        {
            IWebElement boxEl = this.SearchBox;
            return boxEl != null;
        }

        public string SearchBoxPlaceHolderText()
        {
            string placeholderText = this.SearchBox.GetAttribute("placeholder");
            Report.Info($"Place holder text was: {placeholderText}");
            return placeholderText;
        }

        public bool CheckProductLookUpButtonsListContains(string expectedButton)
        {
            var ButtonList = this.ProductLookUpButtons;
            foreach (var button in ButtonList)
            {
                if (button.Text == expectedButton)
                {
                    return true;
                }
            }
            return false;
        }

        public bool ConfirmBreadCrumbAreaIsPresent()
        {
            var element = this.BreadCrumbArea;
            if (element == null)
            {
                return false;
            }
            string displayedAttribute = element.GetAttribute("style");
            return displayedAttribute.Contains("block");

        }

        public bool ConfirmTableHeadingRowIsPresent()
        {
            var el = this.TableHeadingRow;
            if (el == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public string GetHeadingsRowBackgroundColor()
        {
            IWebElement backgroundEl = this.TableHeadingRow;
            if (backgroundEl == null)
            {
                Report.Error("The Background El was null");
                return null;
            }

            string rbgaCssValue = backgroundEl.GetCssValue("background-color");
            return rbgaCssValue;
        }

        public bool CheckColumnSesizeAnchorShowsSymbol()
        {
            List<IWebElement> resizeIcons = this.TableHeadingRow.FindElements(By.XPath(".//th[not(contains(@style,'display: none'))]//span[contains(@class,'ui-jqgrid-resize ui-jqgrid-resize-ltr')]"), 2).ToList();
            List<IWebElement> columnHeadings = this.NamedTableHeadings;
            if (resizeIcons.Count() == columnHeadings.Count())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckFirstExpandedRowColumnContainsResizeAnchor(IWebElement wantedRow, string columnName)
        {
            var startingEl = wantedRow;
            var headingRow = startingEl.FindElement(By.XPath($"//preceding-sibling::div[@class='ui-jqgrid-hdiv']"), 2);
            var wantedColumn = headingRow.FindElement(By.XPath($"//table//th[contains(@id,'{columnName}')]"), 2);
            var columnAnchor = wantedColumn.FindElement(By.XPath($"//span[contains(@class,'ui-jqgrid-resize ui-jqgrid-resize-ltr')]"), 2);
            return columnAnchor != null;

        }

        public List<string> GetColumnHeadingTitles()
        {
            var headings = this.NamedTableHeadings;
            List<string> headingStrings = new List<string>();
            foreach (var heading in headings)
            {
                string currentHeading = heading.Text;
                string currentHeadingTrimmed = currentHeading.Trim();
                headingStrings.Add(currentHeadingTrimmed);
            }
            return headingStrings;
        }


        public bool MakeColumnSmaller(string column, IWebElement row = null)
        {
            var headings = this.AllTableHeadings;
            if (column == "Product ID")
            {
                column = "ProductNumber";
            }
            if (column == "UPC Number")
            {
                column = "Upc";
            }
            if (column == "Product Name")
            {
                column = column.Replace(" ", "");
            }
            if (column == "Scan Date" || column == "Date In Drum" || column == "Date Removed" || column == "Found/NotFound" || column == "Manufacturer" || column == "Name" || column == "Product" || column == "UPC" || column == "Volume" || column == "Actions")
            {
                headings = this.RowSubHeadings(row);
            }

            IWebElement wantedColumn = headings.First(x => x.GetAttribute("id").Contains(column));
            IWebElement resizeIcon = wantedColumn.FindElement(By.XPath(".//span[contains(@class,'ui-jqgrid-resize ui-jqgrid-resize-ltr')]"), 2);
            int startWidth = Int32.Parse(wantedColumn.GetAttribute("style").Replace("width: ", "").Replace("px;", ""));

            Actions action = new Actions(SeleniumBrowser.WebBrowser);
            try
            {

                action.ClickAndHold(resizeIcon).MoveByOffset(-30, 0).Release().Build().Perform();
            }
            catch
            {
                Report.Info("The Column could not be any smaller");
            }
            Report.Screenshot();
            int endWidth = Int32.Parse(wantedColumn.GetAttribute("style").Replace("width: ", "").Replace("px;", ""));
            return startWidth > endWidth;


        }

        public bool MakeColumnBigger(string column, IWebElement row = null)
        {
            var headings = this.AllTableHeadings;
            if (column == "Product ID")
            {
                column = "ProductNumber";
            }
            if (column == "UPC Number")
            {
                column = "Upc";
            }
            if (column == "Product Name")
            {
                column = column.Replace(" ", "");
            }
            if (column == "Scan Date" || column == "Date In Drum" || column == "Date Removed" || column == "Found/NotFound" || column == "Manufacturer" || column == "Name" || column == "Product" || column == "UPC" || column == "Volume" || column == "Actions")
            {
                headings = this.RowSubHeadings(row);
            }
            IWebElement wantedColumn = headings.First(x => x.GetAttribute("id").Contains(column));
            IWebElement resizeIcon = wantedColumn.FindElement(By.XPath(".//span[contains(@class,'ui-jqgrid-resize ui-jqgrid-resize-ltr')]"), 2);
            int startWidth = Int32.Parse(wantedColumn.GetAttribute("style").Replace("width: ", "").Replace("px;", ""));

            Actions action = new Actions(SeleniumBrowser.WebBrowser);
            action.ClickAndHold(resizeIcon).MoveByOffset(30, 0).Release().Build().Perform();
            int endWidth = Int32.Parse(wantedColumn.GetAttribute("style").Replace("width: ", "").Replace("px;", ""));
            return startWidth < endWidth;


        }


        public int ProductsCount()
        {
            List<IWebElement> productRows = this.ProductRows;
            if (productRows == null || !productRows.Any())
            {
                return 0;
            }
            return productRows.Count(x => x.Displayed);
        }

        public bool SubGridColumnContainsRightFacingArrow()
        {
            List<IWebElement> rows = this.ProductRows;
            if (rows.IsNullOrEmpty())
            {
                return false;
            }
            bool trianglesFound = true;
            int i = 1;
            foreach (var item in rows)
            {
                IWebElement firstColumn = item.FindElement(By.XPath(".//td[@aria-describedby='tblDrumLog_subgrid']"), 2);
                IWebElement spanEl = firstColumn.FindElement(By.XPath(".//span"), 2);
                string triangleAttribute = spanEl.GetAttribute("class");
                if (triangleAttribute == "glyphicon glyphicon-triangle-right")
                {
                    Report.Info($"Found the Class of Triangle in row: {i}");
                }
                else
                {
                    trianglesFound = false;
                    Report.Info($"Did not find the Class of Triangle in row: {i}");
                }
                i++;

            }
            return trianglesFound;
        }


        public bool HeadingCheckDrumNameColumnIsToRightOfExpandArrow()
        {
            int expandPosition = 0;
            var columnHeadings = this.AllTableHeadings;
            foreach (var column in columnHeadings)
            {
                if (column.Text == "")
                {
                    Report.Info($"Found the expand Column at postion: {expandPosition}");
                    break;
                }
                expandPosition++;
            }

            return columnHeadings[expandPosition + 1].Text.Trim() == "Drum Name";


        }


        public bool CheckDrumNameColumnIsToRightofExpandArrowColumn()
        {
            List<IWebElement> rows = this.ProductRows;
            if (rows.IsNullOrEmpty())
            {
                return false;
            }
            int i = 1;
            bool foundSuccess = true;
            foreach (var item in rows)
            {
                List<IWebElement> columns = item.FindElements(By.XPath($".//td[contains(@aria-describedby,'tblDrumLog') and not(@style='display:none;')]"), 2).ToList();
                bool foundSubGridColumn = false;
                for (int x = 0; x < columns.Count(); x++)
                {
                    if (columns[x].GetAttribute("aria-describedby").Contains("subgrid"))
                    {
                        foundSubGridColumn = true;
                        if (columns[x + 1].GetAttribute("aria-describedby").Contains("Drum Name"))
                        {
                            Report.Info($"The column to the right of the expand arrow column was the Drum Name column for row: {i}");
                        }
                        else
                        {
                            foundSuccess = false;
                            Report.Info($"The column to the right of the expand arrow column was not the ID column for row: {i}");
                        }
                        break;
                    }
                }
                if (foundSubGridColumn == false)
                {
                    foundSuccess = false;
                    Report.Info($"for the row: {i} the expand arrow column was not found");
                }
                i++;
            }
            return foundSuccess;
        }

        public bool CheckColumnContainsDrumName()
        {
            List<IWebElement> rows = this.ProductRows;
            if (rows.IsNullOrEmpty())
            {
                return false;
            }
            bool drumNamePresent = true;
            int i = 1;
            foreach (var item in rows)
            {
                IWebElement wantedColumn = item.FindElement(By.XPath($".//td[@aria-describedby='tblDrumLog_Drum Name']"), 2);
                string textFound = wantedColumn.Text;
                if (textFound == null)
                {
                    Report.Info($"The text found for row: {i} was null");
                    drumNamePresent = false;

                }
                else
                {
                    Report.Info($"The text was found for row: {i}");
                    char[] delimiterChars = { ' ' };
                    string[] splitText = textFound.Split(delimiterChars);
                    string part1 = splitText[0];
                    string part2 = splitText[1];
                    string part3 = splitText[2]; ;
                    for (int y = 3; y < splitText.Count(); y++)
                    {
                        part3 = part3 + " " + splitText[y];
                    }

                    string[] part1format = { "yyyy-MM-dd" };
                    bool part1Passing = true;
                    if (!DateTime.TryParseExact(part1, part1format, System.Globalization.CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dt))
                    {
                        Report.Info($"The first part of the drum name was not a date in the format yyyy-MM-dd");
                        part1Passing = false;
                    }
                    else
                    {
                        Report.Info($"The first part of the drum name was a date in the format yyyy-MM-dd");
                        part1Passing = true;
                    }

                    bool part2Passing = GeneralUtilities.IsDateTime(part2);
                    if (part2Passing)
                    {
                        Report.Info($"The second part of the drum name was a valid time");
                    }
                    else
                    {
                        Report.Info($"The second part of the drum name was not a valid time");
                    }

                    bool part3Passing = part3.Any();
                    if (part3Passing)
                    {
                        Report.Info($"The 3rd part of the drum name contained text");
                    }
                    else
                    {
                        Report.Info($"The 3rd part of the drum name did not contain text");
                    }

                    if (part1Passing && part2Passing && part3Passing)
                    {

                    }
                    else
                    {
                        drumNamePresent = false;
                    }
                }
                i++;
            }
            return drumNamePresent;
        }

        public bool CheckTableAlternatesBetweenGreyAndWhite()
        {
            IWebElement TableEl = this.ProductTable;
            string tableClass = TableEl.GetAttribute("class");
            if (tableClass == "table table-striped ui-jqgrid-btable ui-common-table table-bordered")
            {
                Report.Info("The class of the products table was striped as expected...");
                string rbgaCssValue = TableEl.GetCssValue("background-color");
                if (rbgaCssValue == "rgba(240, 243, 245, 1)")
                {
                    Report.Info("The rgba value found was grey as expected");
                    return true;
                }
                else
                {
                    Report.Info("The rgba value found was not grey as expected");
                    return false;
                }

            }
            else
            {
                Report.Info("The Products table did not contain the expected class for being striped");
                return false;
            }

        }

        public bool ProductsGridFooterPresent()
        {
            var footerEl = this.ProductsTableFooter;
            return footerEl != null;

        }

        public bool SelectOptionFromItemsPerPageSelector(string option)
        {
            IWebElement selecterEl = this.ItemsPerPageSelector;
            selecterEl.Select(option);
            return selecterEl.SelectedOption() == option;
        }

        public bool ScrollToAndCheckTopProductInteractable()
        {
            List<IWebElement> rows = this.ProductRows;
            return rows.First().TryClick();
        }

        public bool ScrollToAndCheckBottomProductInteractable()
        {
            List<IWebElement> rows = this.ProductRows;
            return rows.Last().TryClick();
        }

        public bool ClickResetButton()
        {
            return this.ResetOptionButton.TryClick();
        }

        public bool ExpandFirstRow()
        {
            var rows = this.ProductRows;
            if (rows.IsNullOrEmpty())
            {
                Report.Info("no rows of products were found in the table");
                return false;
            }
            IWebElement firstRow = rows[0];
            IWebElement expandButton = firstRow.FindElement(By.XPath($".//td[contains(@aria-describedby,'tblDrumLog_subgrid')]"), 2);
            if (!expandButton.TryClick())
            {
                Report.Info("Failed to click the expand button");
                return false;
            }
            string expandedAttribute = expandButton.GetAttribute("class");
            return expandedAttribute == "ui-sgcollapsed sgexpanded";


        }



        public List<IWebElement> GetProductRows()
        {
            var rows = this.ProductRows;
            if (rows.IsNullOrEmpty())
            {
                Report.Info("no rows of products were found in the table");
                return null;
            }
            return rows;
        }

        public bool ExpandGivenRow(IWebElement row)
        {

            IWebElement expandButton = row.FindElement(By.XPath($".//td[contains(@aria-describedby,'tblDrumLog_subgrid')]"), 2);
            expandButton.ScrollElementIntoView();
            if (!expandButton.TryClick())
            {
                Report.Info("Failed to click the expand button");
                return false;
            }
            string expandedAttribute = expandButton.GetAttribute("class");
            return expandedAttribute == "ui-sgcollapsed sgexpanded";


        }

        public string GetFirstDrumName()
        {
            List<IWebElement> rows = this.ProductRows;
            if (rows.IsNullOrEmpty())
            {
                Report.Error($"Did not find any product rows");
                return null;
            }

            string column = "Drum Name";
            IWebElement wantedColumn = rows[0].FindElement(By.XPath($".//td[contains(@aria-describedby,'tblDrumLog_{column}')]"), 2);
            if (wantedColumn == null)
            {
                Report.Error($"Did not find the element for Column: {column}");
                return null;
            }
            //will need to check that this ID returned is correct format
            return wantedColumn.Text;
        }

        public string GetFirstLocation()
        {
            List<IWebElement> rows = this.ProductRows;
            if (rows.IsNullOrEmpty())
            {
                Report.Error($"Did not find any product rows");
                return null;
            }

            string column = "Location";
            IWebElement wantedColumn = rows[0].FindElement(By.XPath($".//td[contains(@aria-describedby,'tblDrumLog_{column}')]"), 2);
            if (wantedColumn == null)
            {
                Report.Error($"Did not find the element for Column: {column}");
                return null;
            }
            //will need to check that this ID returned is correct format
            return wantedColumn.Text;
        }


        public string GetFirstStoreName()
        {
            List<IWebElement> rows = this.ProductRows;
            if (rows.IsNullOrEmpty())
            {
                Report.Error($"Did not find any product rows");
                return null;
            }

            string column = "Store Name";
            IWebElement wantedColumn = rows[0].FindElement(By.XPath($".//td[contains(@aria-describedby,'tblDrumLog_{column}')]"), 2);
            if (wantedColumn == null)
            {
                Report.Error($"Did not find the element for Column: {column}");
                return null;
            }
            //will need to check that this ID returned is correct format
            return wantedColumn.Text;
        }


        public IWebElement GetFirstExpandedDrumRow()
        {
            List<IWebElement> rows = this.OnlyexpandedProductRows;
            if (rows.IsNullOrEmpty())
            {
                Report.Error($"Did not find any product rows");
                return null;
            }
            return rows.First();
        }

        public List<string> GetSubRowColumnHeadingTitles(IWebElement row)
        {
            var headings = this.RowSubHeadings(row);
            List<string> headingStrings = new List<string>();
            foreach (var heading in headings)
            {
                string currentHeading = heading.Text;
                string currentHeadingTrimmed = currentHeading.Trim();
                if (currentHeadingTrimmed.IsNullOrEmpty())
                {
                    //do nothing
                    Report.Info($"the heading found contained no heading text, moving on...");
                }
                else
                {
                    headingStrings.Add(currentHeadingTrimmed);

                }
            }
            return headingStrings;
        }

        public IWebElement GetRowByExpandedDrumName(string drumName)
        {
            List<IWebElement> rows = this.OnlyexpandedProductRows;
            if (rows.IsNullOrEmpty())
            {
                Report.Error($"Did not find any product rows");
                return null;
            }
            int i = 1;
            foreach (var item in rows)
            {
                string column = "ProductNumber";
                IWebElement wantedColumn = item.FindElement(By.XPath($".//td[contains(@aria-describedby,'t_{column}')]"), 2);
                if (wantedColumn == null)
                {
                    Report.Error($"Did not find the element for Column: {column}");
                    return null;
                }
                if (wantedColumn.Text.Contains(drumName))
                {
                    Report.Info($"Found the row with expected ID");
                    return item;
                }
            }
            Report.Info("Did not find the row with the expected ID");
            return null;
        }

        public bool CheckRowSubTableColumnResizeAnchorShowsSymbol(IWebElement row)
        {
            List<IWebElement> resizeIcons = this.RowSubHeadingLine(row).FindElements(By.XPath(".//th[not(contains(@style,'display: none'))]//span[contains(@class,'ui-jqgrid-resize ui-jqgrid-resize-ltr')]"), 2).ToList();
            List<IWebElement> columnHeadings = this.RowSubHeadings(row);
            if (resizeIcons.Count() == columnHeadings.Count())
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool RowSubTableContainsExpandedMenuIcon(IWebElement row)
        {
            IWebElement fullRowElement = row.FindElement(By.XPath(".//ancestor::tr[@class='ui-subgrid ui-sg-expanded']"), 2);
            IWebElement expandedIcon = fullRowElement.FindElement(By.XPath(".//td[contains(@class,'subgrid-cell')]//span"), 2);
            string expandedAttr = expandedIcon.GetAttribute("class");
            return expandedAttr == "glyphicon glyphicon-indent-left";

        }

        public bool CollapseFirstRow()
        {
            var rows = this.ProductRows;
            if (rows.IsNullOrEmpty())
            {
                Report.Info("no rows of products were found in the table");
                return false;
            }
            IWebElement firstRow = rows[0];
            IWebElement expandButton = firstRow.FindElement(By.XPath($".//td[contains(@aria-describedby,'tblDrumLog_subgrid')]"), 2);
            if (!expandButton.TryClick())
            {
                Report.Info("Failed to click the collapse button");
                return false;
            }
            string expandedAttribute = expandButton.GetAttribute("class");
            return expandedAttribute == "ui-sgcollapsed sgcollapsed";

        }

        public bool CollapseGivenRow(IWebElement row)
        {

            IWebElement expandButton = row.FindElement(By.XPath($".//td[contains(@aria-describedby,'tblDrumLog_subgrid')]"), 2);
            if (!expandButton.TryClick())
            {
                Report.Info("Failed to click the collapse button");
                return false;
            }
            string expandedAttribute = expandButton.GetAttribute("class");
            return expandedAttribute == "ui-sgcollapsed sgcollapsed";

        }
        public bool ClickNextPageButton()
        {
            return this.NextPageButton.TryClick();
        }

        public string GetCurrentPageNumber()
        {
            IWebElement currentPageEl = this.ProductsTableFooter.FindElement(By.XPath(".//input[@class='ui-pg-input form-control']"), 2);
            return currentPageEl.GetValue();
        }

        public string GetLastPossiblePageNumber()
        {
            IWebElement LastPageEl = this.ProductsTableFooter.FindElement(By.XPath(".//span[@id='sp_1_tblDrumLogPager']"), 2);
            return LastPageEl.Text;
        }

        public bool DrumNameNotRepeated()
        {
            int x = 1;
            int lastPageNumber = Int32.Parse(this.GetLastPossiblePageNumber());
            Dictionary<string, string> namesFoundDict = new Dictionary<string, string>();
            bool noRepeatedName = true;

            while (x < lastPageNumber + 1)
            {
                var productRows = this.ProductRows;
                foreach (var row in productRows)
                {
                    IWebElement nameColumn = row.FindElement(By.XPath($".//td[@aria-describedby='tblDrumLog_Drum Name']"), 2);
                    string nameText = nameColumn.Text;
                    IWebElement statusColumn = row.FindElement(By.XPath($".//td[@aria-describedby='tblDrumLog_Drum Status']"), 2);
                    string statusText = statusColumn.Text;
                    if (namesFoundDict.Contains(new KeyValuePair<string, string>(nameText, statusText)))
                    {
                        if (namesFoundDict[nameText] == statusText && namesFoundDict[nameText] != "Hauled")
                        {
                            noRepeatedName = false;
                            Report.Info($"The Drum Name: {nameText} with status: {statusText} was already in the list");
                        }
                    }
                    else
                    {
                        namesFoundDict.Add(nameText, statusText);
                    }
                }
                if (this.GetCurrentPageNumber() == this.GetLastPossiblePageNumber())
                {
                    break;
                }

                this.ClickNextPageButton();
                this.WaitDrumLogWidgetSpinnerFinish();


            }
            return noRepeatedName;

        }

        public bool DrumContainsDateRemoved(IWebElement row)
        {
            //Looking for at least one Date Removed
            List<IWebElement> wantedColumn = row.FindElements(By.XPath($".//td[contains(@aria-describedby,'t_Date Removed')]"), 2).ToList();
            List<string> foundDates = new List<string>();
            foreach (var item in wantedColumn)
            {

                if (item.Text.IsNullOrEmpty() || item.Text == " ")
                {
                    //do nothing
                }
                else
                {
                    return true;

                }

            }

            return false;
        }



        public bool CheckDateRemovedFormat(IWebElement row)
        {

            List<IWebElement> wantedColumn = row.FindElements(By.XPath($".//td[contains(@aria-describedby,'t_Date Removed')]"), 2).ToList();
            List<string> foundDates = new List<string>();
            foreach (var item in wantedColumn)
            {

                if (item.Text.IsNullOrEmpty() || item.Text == " ")
                {
                    //do nothing
                }
                else
                {
                    Report.Info($"Date found was: {item.Text}");
                    foundDates.Add(item.Text);

                }

            }

            bool correctFormat = true;
            foreach (var date in foundDates)
            {
                string[] expectedFormat = { "yyyy-mm-dd" };
                if (DateTime.TryParseExact(date, expectedFormat, System.Globalization.CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dt))
                {
                    Report.Info($"The Date Found: {date} was in the expected format");
                }
                else
                {
                    correctFormat = false;
                    Report.Info($"The Date Found: {date} was not in the expected format");
                }

            }
            return correctFormat;


        }

        public bool CheckDateInDrumFormat(IWebElement row)
        {

            List<IWebElement> wantedColumn = row.FindElements(By.XPath($".//td[contains(@aria-describedby,'t_Date In Drum')]"), 2).ToList();
            List<string> foundDates = new List<string>();
            foreach (var item in wantedColumn)
            {
                Report.Info($"Date found was: {item.Text}");
                foundDates.Add(item.Text);


            }

            bool correctFormat = true;
            foreach (var date in foundDates)
            {
                string[] expectedFormat = { "yyyy-mm-dd" };
                if (DateTime.TryParseExact(date, expectedFormat, System.Globalization.CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dt))
                {
                    Report.Info($"The Date Found: {date} was in the expected format");
                }
                else
                {
                    correctFormat = false;
                    Report.Info($"The Date Found: {date} was not in the expected format");
                }

            }
            return correctFormat;


        }

        public IWebElement GetExpandedRowFromMainRow(IWebElement row)
        {
            IWebElement expandedRow = row.FindElement(By.XPath($".//following::tr[contains(@id,'expandedContent')][1]"), 2);
            if (expandedRow == null)
            {
                return null;
            }
            return expandedRow;
        }

        public bool CheckScanDateFormat(IWebElement row)
        {

            List<IWebElement> wantedColumn = row.FindElements(By.XPath($".//td[contains(@aria-describedby,'t_Scan Date')]"), 2).ToList();
            List<string> foundDates = new List<string>();
            foreach (var item in wantedColumn)
            {
                Report.Info($"Date found was: {item.Text}");
                foundDates.Add(item.Text);


            }

            bool correctFormat = true;
            foreach (var date in foundDates)
            {
                string[] expectedFormat = { "yyyy-mm-dd" };
                if (DateTime.TryParseExact(date, expectedFormat, System.Globalization.CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dt))
                {
                    Report.Info($"The Date Found: {date} was in the expected format");
                }
                else
                {
                    correctFormat = false;
                    Report.Info($"The Date Found: {date} was not in the expected format");
                }

            }
            return correctFormat;


        }

        public bool LastPageButtonExists()
        {
            return this.LastPageButton != null;
        }
        public bool NextPageButtonExists()
        {
            return this.NextPageButton != null;
        }
        public bool PreviousPageButonExists()
        {
            return this.PreviousPageButton != null;
        }
        public bool FirstPageButonExists()
        {
            return this.FirstPageButton != null;
        }

        public bool ClickLastPageButton()
        {
            return this.LastPageButton.TryClick();
        }

        public bool ClickPreviousPageButton()
        {
            return this.PreviousPageButton.TryClick();
        }

        public bool ClickFirstPageButton()
        {
            return this.FirstPageButton.TryClick();
        }
        public int GetCurrentItemsPerPage()
        {
            IWebElement selecterEl = this.ItemsPerPageSelector;
            return Int32.Parse(selecterEl.SelectedOption());
        }
        public int GetTotalProducts()
        {
            IWebElement footerPageElement = this.ProductsCountEl;
            string fullText = footerPageElement.Text;
            int lengthindex = fullText.Length - 1;
            int lastSpace = fullText.LastIndexOf("f");
            int goLength = lengthindex - lastSpace;
            string updatedString = fullText.Substring(lastSpace + 1, goLength).Trim().Replace(",", "");
            int totalPageInt = Int32.Parse(updatedString);
            return totalPageInt;

        }

        public void EnterCurrentPageValue(string value)
        {
            IWebElement currentPageEl = this.ProductsTableFooter.FindElement(By.XPath(".//input[@class='ui-pg-input form-control']"), 2);
            currentPageEl.ClearTextBox();
            currentPageEl.EnterText(value);
            currentPageEl.SendKeys(Keys.Enter);
        }
        public string GetExpectedProductsRange()
        {
            int itemsPerPage = this.GetCurrentItemsPerPage();
            int currentPageNumber = Int32.Parse(this.GetCurrentPageNumber());
            int startValue = ((currentPageNumber - 1) * (itemsPerPage)) + 1;
            int endValue = startValue - 1 + itemsPerPage;
            string finalRange = startValue + " - " + endValue;
            Report.Info($"The expected range is: {finalRange}");
            return finalRange;
        }
        public string GetDisplayedProductsRange()
        {
            IWebElement footerPageElement = this.ProductsCountEl;
            string fullText = footerPageElement.Text;
            int firsto = fullText.IndexOf("o");
            string firstUpdate = fullText.Substring(0, firsto - 1);
            string removedView = firstUpdate.Replace("View", "");
            string finalString = removedView.TrimStart();
            Report.Info($"The found range is: {finalString}");
            return finalString;

        }

        public List<string> GetCurrentProductDrumName()
        {
            List<string> currentIDs = new List<string>();
            List<IWebElement> rows = this.ProductRows;
            if (rows.IsNullOrEmpty())
            {
                Report.Error($"Did not find any product rows");
                return null;
            }
            string column = "Drum Name";
            int i = 1;
            foreach (var row in rows)
            {
                IWebElement wantedColumn = row.FindElement(By.XPath($".//td[contains(@aria-describedby,'tblDrumLog_{column}')]"), 2);
                if (wantedColumn == null)
                {
                    Report.Error($"Did not find the element for Column: {column} for row: {i}");
                    return null;
                }
                currentIDs.Add(wantedColumn.Text);
                i++;
            }
            return currentIDs;


        }

        public string GetColumValueByDrumname(string column, string DrumLog)
        {

            if (column == "Product Name")
            {
                column = column.Replace(" ", "");
            }
            var wantedRow = this.GetRowByDrumName(DrumLog);
            IWebElement wantedColumn = wantedRow.FindElement(By.XPath($".//td[contains(@aria-describedby,'tblDrumLog_{column}')]"), 2);
            return wantedColumn.Text;
        }

        public IWebElement GetRowByDrumName(string DrumLog)
        {
            List<IWebElement> rows = this.ProductRows;
            if (rows.IsNullOrEmpty())
            {
                Report.Error($"Did not find any product rows");
                return null;
            }
            int i = 1;
            foreach (var item in rows)
            {
                string column = "Drum Name";
                IWebElement wantedColumn = item.FindElement(By.XPath($".//td[contains(@aria-describedby,'tblDrumLog_{column}')]"), 2);
                if (wantedColumn == null)
                {
                    Report.Error($"Did not find the element for Column: {column}");
                    return null;
                }
                if (wantedColumn.Text.Contains(DrumLog))
                {
                    Report.Info($"Found the row with expected ID");
                    return item;
                }
            }
            Report.Info("Did not find the row with the expected ID");
            return null;
        }

        public IWebElement GetExpandedRowFromDrumName(string drumName)
        {
            return this.GetExpandedRowFromMainRow(this.GetRowByDrumName(drumName));
        }


        public string GetExpandedRowValueFromGivenRowAndColumn(IWebElement row, string column)
        {
            IWebElement wantedColumn = row.FindElement(By.XPath($".//td[contains(@aria-describedby,'{column}')]"), 2);

            if (wantedColumn == null)
            {
                Report.Info("The column was null");
                return null;
            }
            return wantedColumn.Text;
        }

        public void EnterSearchBoxText(string searchText) => this.SearchBox.EnterText(searchText);

        public void EnterSearchBoxTextAndpressEnterKey(string searchText)
        {
            this.SearchBox.EnterText(searchText);
            this.SearchBox.SendKeys(Keys.Enter);
        }


        public bool CheckSearchBoxContains(string expectedText) => this.SearchBox.GetAttribute("value") == expectedText;

        public IWebElement GetMatchingDrumNameRow(string drumName)
        {
            int x = 1;
            int lastPageNumber = Int32.Parse(this.GetLastPossiblePageNumber());
            List<string> drumNamesFound = new List<string>();
            while (x < lastPageNumber + 1)
            {
                var productRows = this.ProductRows;
                foreach (var row in productRows)
                {
                    IWebElement wantedColumn = row.FindElement(By.XPath($".//td[@aria-describedby='tblDrumLog_Drum Name']"), 2);
                    string textFound = wantedColumn.Text;
                    if (textFound == drumName)
                    {
                        return row;
                    }

                }

                if (this.GetCurrentPageNumber() == this.GetLastPossiblePageNumber())
                {
                    break;
                }
                this.ClickNextPageButton();
                this.WaitDrumLogWidgetSpinnerFinish();

            }
            return null;

        }



        public DrumLogData GetAllDrumDataByDrumName(string DrumName)
        {
            DrumLogData currentDrumData = new DrumLogData();
            currentDrumData.DrumName = DrumName;
            currentDrumData.DrumType = this.GetColumValueByDrumname("Drum Type", DrumName);
            currentDrumData.DrumStatus = this.GetColumValueByDrumname("Drum Status", DrumName);
            currentDrumData.StoreName = this.GetColumValueByDrumname("Store Name", DrumName);
            currentDrumData.RegionName = this.GetColumValueByDrumname("Region Name", DrumName);
            currentDrumData.Location = this.GetColumValueByDrumname("Location", DrumName);
            currentDrumData.DateOpened = this.GetColumValueByDrumname("Date Opened", DrumName);
            currentDrumData.DateClosed = this.GetColumValueByDrumname("Date Closed", DrumName);
            currentDrumData.DateHauled = this.GetColumValueByDrumname("Date Hauled", DrumName);


            var mainRow = this.GetRowByDrumName(DrumName);
            this.ExpandGivenRow(mainRow);
            this.WaitDrumLogWidgetSpinnerFinish();

            var expandedRowEl = this.GetExpandedRowFromDrumName(DrumName);

            List<IWebElement> expandedRows = expandedRowEl.FindElements(By.XPath(".//tr[not(@class='ui-jqgrid-labels' or @class='jqgfirstrow')]"), 2).ToList();

            List<DrumLogExpandedData> expandedData = new List<DrumLogExpandedData>();

            foreach (var row in expandedRows)
            {

                var currentExpanded = this.GetDrumLogExpandedDataByDrumName(row);
                expandedData.Add(currentExpanded);
            }

            currentDrumData.ExpandedData = expandedData;


            this.CollapseGivenRow(mainRow);
            this.WaitDrumLogWidgetSpinnerFinish();




            return currentDrumData;





        }

        public DrumLogExpandedData GetDrumLogExpandedDataByDrumName(IWebElement row)
        {
            DrumLogExpandedData expandedDrumData = new DrumLogExpandedData();

            expandedDrumData.ScanDate = this.GetExpandedRowValueFromGivenRowAndColumn(row, "Scan Date");
            expandedDrumData.DateInDrum = this.GetExpandedRowValueFromGivenRowAndColumn(row, "Date In Drum");
            expandedDrumData.DateRemoved = this.GetExpandedRowValueFromGivenRowAndColumn(row, "Date Removed");
            expandedDrumData.FoundNotFound = this.GetExpandedRowValueFromGivenRowAndColumn(row, "Found/Not Found");
            expandedDrumData.Manufacturer = this.GetExpandedRowValueFromGivenRowAndColumn(row, "Manufacturer");
            expandedDrumData.Name = this.GetExpandedRowValueFromGivenRowAndColumn(row, "Name");
            expandedDrumData.Product = this.GetExpandedRowValueFromGivenRowAndColumn(row, "Product");
            expandedDrumData.UPC = this.GetExpandedRowValueFromGivenRowAndColumn(row, "UPC");
            expandedDrumData.Volume = this.GetExpandedRowValueFromGivenRowAndColumn(row, "Volume");
            expandedDrumData.Actions = this.GetExpandedRowValueFromGivenRowAndColumn(row, "Actions");

            return expandedDrumData;
        }

        public class DrumLogData
        {
            public string DrumName { get; set; }

            public string DrumType { get; set; }

            public string DrumStatus { get; set; }

            public string StoreName { get; set; }

            public string RegionName { get; set; }
            public string Location { get; set; }

            public string DateOpened { get; set; }

            public string DateClosed { get; set; }

            public string DateHauled { get; set; }

            //need a sub class which will be the expanded data (seperate method that grabs that data)

            public List<DrumLogExpandedData> ExpandedData { get; set; }



            //checking equals for the expanded data may need a rework (foreach in expanded check each property) (do inside the if()?)
            //public override bool Equals(object obj)
            //{
            //    var other = obj as DrumLogData;

            //    if (other == null)
            //        return false;

            //    if (DrumName != other.ID || ProductName != other.ProductName || Supplier != other.Supplier || Status != other.Status || MostRecentActivity != other.MostRecentActivity || UPC.Count() != other.UPC.Count() || UPC.Except(other.UPC).Any())
            //    {

            //        Report.Info("The two sets of recent  product data did not match");
            //        return false;
            //    }

            //    return true;
            //}


        }

        public class DrumLogExpandedData
        {
            public string ScanDate { get; set; }

            public string DateInDrum { get; set; }

            public string DateRemoved { get; set; }
            public string FoundNotFound { get; set; }

            public string Manufacturer { get; set; }

            public string Name { get; set; }

            public string Product { get; set; }

            public string UPC { get; set; }

            public string Volume { get; set; }

            public string Actions { get; set; }

        }



        public class MoreFiltersPopup : SeleniumBaseObject
        {
            #region Page Objects
            protected override By ContainerElementLocator => By.XPath("//div[@id='moreFiltersModal']//div[@class='modal-dialog']");

            private IWebElement CancelButton => this.containerElement.FindElement(By.XPath(".//div[@class='modal-footer lgrey-b']//button[text()='Cancel']"), 2);

            public IWebElement ApplyFilterButton => this.containerElement.FindElement(By.XPath(".//div[@class='modal-footer lgrey-b']//button[text()='Apply Filter']"), 2);

            public List<IWebElement> AllFilterElements => this.containerElement.FindElements(By.XPath($".//div[@class='form-group' and .//label]"), 2).ToList();
            private IWebElement GivenLabelElementInput(string labelText) => this.containerElement.FindElement(By.XPath($".//div[@class='form-group' and .//label[text()='{labelText}']]//div"), 2);



            #endregion

            public bool FilterFieldExists(string filterLabel)
            {
                IWebElement el = this.GivenLabelElementInput(filterLabel);
                return el != null;
            }

            public bool FilterFieldVisibleOnScreen(string filterLabel)
            {
                IWebElement el = this.GivenLabelElementInput(filterLabel);
                return el.VisibleInViewport();
            }

            public bool CancelButtonIsPresent()
            {
                IWebElement el = this.CancelButton;
                return el != null;
            }

            public bool ApplyFilterButtonIsPresent()
            {
                IWebElement el = this.ApplyFilterButton;
                return el != null;
            }

            public bool ClickCancelButton()
            {
                return this.CancelButton.TryClick();
            }

            public bool ClickApplyFiltersButton()
            {
                return this.ApplyFilterButton.TryClick();
            }

            public bool FieldIsADropDown(string labelName)
            {
                IWebElement el = this.GivenLabelElementInput(labelName);
                IWebElement inputElementType = el.FindElement(By.XPath(".//select"), 2);
                return inputElementType != null;
            }


            public bool SelectDropDownOptionForSection(string option, string section)
            {
                IWebElement el = this.GivenLabelElementInput(section);
                if (section == "Store Name")
                {
                    //Click the field first to open menu
                    el.TryClick();
                    IWebElement dropDownEl = this.containerElement.FindElement(By.XPath($"//span[@class='select2-dropdown select2-dropdown--below']"), 10);
                    List<IWebElement> dropDownOptions = dropDownEl.FindElements(By.XPath(".//li"), 2).ToList();
                    if (dropDownOptions.Count() == 1)
                    {
                        Report.Info("The list was empty");
                        int x = 0;
                        while (x < 5)
                        {
                            x++;
                            Delay.Seconds(5);
                            dropDownOptions = dropDownEl.FindElements(By.XPath(".//li"), 2).ToList();
                            if (dropDownOptions.Count() != 1)
                            {
                                Report.Info($"options found");
                                break;
                            }
                        }

                    }
                    var searchOptionEL = dropDownOptions.First(x => x.Text == option);
                    searchOptionEL.TryClick();
                    List<IWebElement> selectedOptionsEl = el.FindElements(By.XPath($"//li[@class='select2-selection__choice']"), 2).ToList();

                    List<string> selectedOptionsStrings = new List<string>();
                    foreach (var thing in selectedOptionsEl)
                    {
                        selectedOptionsStrings.Add(thing.Text.Replace("×", ""));
                    }
                    return selectedOptionsStrings.Contains(option);

                }
                List<IWebElement> optionsElsFound = el.FindElements(By.XPath(".//select//option[position()>1]"), 2).ToList();
                var wantedOptionEL = optionsElsFound.First(x => x.Text == option);
                wantedOptionEL.TryClick();
                return el.FindElement(By.XPath($".//select"), 2).SelectedOption() == option;
            }
            public List<string> GetSectionDropDownOptions(string section)
            {
                IWebElement el = this.GivenLabelElementInput(section);
                List<string> options = new List<string>();
                List<IWebElement> optionsElsFound = el.FindElements(By.XPath(".//select//option[position()>1]"), 2).ToList();
                foreach (var input in optionsElsFound)
                {
                    options.Add(input.Text);
                }
                return options;
            }

            public bool DropDownOptionPresentForSection(string expectedOption, string section)
            {
                var foundOptions = this.GetSectionDropDownOptions(section);
                return foundOptions.Contains(expectedOption);
            }

            public bool DateRemovedOnScreen()
            {
                return this.FilterFieldVisibleOnScreen("Date Removed");
            }

            public bool TopStoreNameFilterOptionVisible()
            {

                List<IWebElement> dropDownOptions = this.FindElements(By.XPath($"//ul[@class='select2-results__options']//li"), 2).ToList();
                if (dropDownOptions.Count() == 0)
                {
                    IWebElement el = this.GivenLabelElementInput("Store Name");
                    el.TryClick();
                    IWebElement dropDownEl = this.containerElement.FindElement(By.XPath($"//span[@class='select2-dropdown select2-dropdown--below']"), 10);
                    dropDownOptions = dropDownEl.FindElements(By.XPath(".//li"), 2).ToList();
                    if (dropDownOptions.Count() == 1)
                    {
                        Report.Info("The list was empty");
                        int x = 0;
                        while (x < 5)
                        {
                            x++;
                            Delay.Seconds(5);
                            dropDownOptions = dropDownEl.FindElements(By.XPath(".//li"), 2).ToList();
                            if (dropDownOptions.Count() != 1)
                            {
                                Report.Info($"options found");
                                break;
                            }
                        }

                    }
                }
                var firstEl = dropDownOptions.First();
                bool visible = firstEl.VisibleInViewport();
                return visible;
            }

            public bool BottomStoreNameFilterOptionVisible()
            {

                List<IWebElement> dropDownOptions = this.FindElements(By.XPath($"//ul[@class='select2-results__options']//li"), 2).ToList();
                if (dropDownOptions.Count() == 0)
                {
                    IWebElement el = this.GivenLabelElementInput("Store Name");
                    el.TryClick();
                    IWebElement dropDownEl = this.containerElement.FindElement(By.XPath($"//span[@class='select2-dropdown select2-dropdown--below']"), 10);
                    dropDownOptions = dropDownEl.FindElements(By.XPath(".//li"), 2).ToList();
                    if (dropDownOptions.Count() == 1)
                    {
                        Report.Info("The list was empty");
                        int x = 0;
                        while (x < 5)
                        {
                            x++;
                            Delay.Seconds(5);
                            dropDownOptions = dropDownEl.FindElements(By.XPath(".//li"), 2).ToList();
                            if (dropDownOptions.Count() != 1)
                            {
                                Report.Info($"options found");
                                break;
                            }
                        }

                    }
                }
                var lastEl = dropDownOptions.Last();
                bool visible = lastEl.VisibleInViewport();
                return visible;
            }
            public bool ScrollToStoreNameTopOption()
            {
                List<IWebElement> dropDownOptions = this.FindElements(By.XPath($"//ul[@class='select2-results__options']//li"), 2).ToList();
                var firstEl = dropDownOptions.First();
                firstEl.ScrollElementIntoView();
                return firstEl.VisibleInViewport();


            }

            public bool ScrollToStoreNameBottomOption()
            {
                List<IWebElement> dropDownOptions = this.FindElements(By.XPath($"//ul[@class='select2-results__options']//li"), 2).ToList();
                var firstEl = dropDownOptions.Last();
                firstEl.ScrollElementIntoView();
                return firstEl.VisibleInViewport();


            }


            public bool ScrollToTopFilter()
            {
                var allFilterEls = this.AllFilterElements;
                var firstEl = allFilterEls.First();
                firstEl.ScrollElementIntoView();
                return firstEl.VisibleInViewport();


            }

            public bool ScrollToBottomFilter()
            {
                var allFilterEls = this.AllFilterElements;
                var firstEl = allFilterEls.Last();
                firstEl.ScrollElementIntoView();
                return firstEl.VisibleInViewport();


            }

            public bool OpenStoreNameDropDown()
            {

                List<IWebElement> dropDownOptions = this.FindElements(By.XPath($"//ul[@class='select2-results__options']//li"), 2).ToList();
                if (dropDownOptions.Count() == 0)
                {
                    IWebElement el = this.GivenLabelElementInput("Store Name");
                    el.TryClick();
                    IWebElement dropDownEl = this.containerElement.FindElement(By.XPath($"//span[@class='select2-dropdown select2-dropdown--below']"), 10);
                    dropDownOptions = dropDownEl.FindElements(By.XPath(".//li"), 2).ToList();
                    if (dropDownOptions.Count() == 1)
                    {
                        Report.Info("The list was empty");
                        int x = 0;
                        while (x < 5)
                        {
                            x++;
                            Delay.Seconds(5);
                            dropDownOptions = dropDownEl.FindElements(By.XPath(".//li"), 2).ToList();
                            if (dropDownOptions.Count() > 1)
                            {
                                Report.Info($"options found");
                                return true;
                            }
                        }

                    }
                    if (dropDownOptions.Count() > 1)
                    {
                        Report.Info($"options found");
                        return true;
                    }
                }
                return false;

            }

            public bool CloseStoreNameDropDown()
            {

                IWebElement dropDownEl = this.containerElement.FindElement(By.XPath($"//span[@class='select2-dropdown select2-dropdown--below']"), 4);
                if (dropDownEl != null)
                {
                    IWebElement el = this.GivenLabelElementInput("Store Name");
                    this.ContainerElement.TryClick();
                    Delay.Seconds(4);
                    dropDownEl = this.containerElement.FindElement(By.XPath($"//span[@class='select2-dropdown select2-dropdown--below']"), 4);
                    if (dropDownEl == null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                return true;

            }

            //Filter drop down does not handle automation well
            public bool OpenGivenFilterDropDown(string filter)
            {

                IWebElement selector = this.FindElement(By.XPath($"//div[@class='form-group'][.//label[text()='{filter}']]//select[@class='input-sm form-control']"), 3);
                List<IWebElement> dropDownOptions = selector.FindElements(By.XPath($".//option[not(text()='-------')]"), 2).ToList();

                var firstEl = dropDownOptions.First();
                bool visible = firstEl.VisibleInViewport();

                selector.TryClick();
                dropDownOptions = selector.FindElements(By.XPath($".//option[not(text()='-------')]"), 2).ToList();
                firstEl = dropDownOptions.First();
                visible = firstEl.VisibleInViewport();
                firstEl.TryClick();






                if (dropDownOptions.Count() == 0)
                {
                    IWebElement el = this.GivenLabelElementInput("Store Name");
                    el.TryClick();
                    selector = this.FindElement(By.XPath($"//div[@class='form-group'][.//label[text()='{filter}']]//select[@class='input-sm form-control']"), 3);
                    dropDownOptions = selector.FindElements(By.XPath($"//option[not(text()='-------')]"), 2).ToList();
                    if (dropDownOptions.Count() == 1)
                    {
                        Report.Info("The list was empty");
                        int x = 0;
                        while (x < 5)
                        {
                            x++;
                            Delay.Seconds(5);
                            dropDownOptions = selector.FindElements(By.XPath($"//option[not(text()='-------')]"), 2).ToList();
                            if (dropDownOptions.Count() != 1)
                            {
                                Report.Info($"options found");
                                return true;
                            }
                        }

                    }
                }
                return false;

            }

            public List<string> GetFilterOptions(string filter)
            {

                IWebElement selector = this.FindElement(By.XPath($"//div[@class='form-group'][.//label[text()='{filter}']]//select[@class='input-sm form-control']"), 3);
                List<IWebElement> dropDownOptions = selector.FindElements(By.XPath($".//option[not(text()='-------')]"), 2).ToList();
                if (dropDownOptions.Count() == 0)
                {
                    Report.Info($"Failed to find any options for the filter");
                    return null;
                }
                List<string> optionsStrings = new List<string>();
                foreach (var option in dropDownOptions)
                {
                    optionsStrings.Add(option.Text.ToLower());

                }
                return optionsStrings;


            }




        }


    }


}