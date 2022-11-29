using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Castle.Core.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using UL.Automation.Reporting.Functions;
using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Classes;
using UL.Automation.WebDriver.Extensions;
using static UL.Selenium.Portal.RPS.Selenium_Classes.RecentActivities;

namespace UL.Selenium.Portal.RPS.Selenium_Classes
{
    public class ProductLookUp : SeleniumBaseObject
    {
        #region Page Objects
        protected override By ContainerElementLocator => By.XPath("//div[@class='container-fluid nopadding']");

        private IWebElement SearchBox => FindElement(By.XPath(".//input[@name='lookup']"), 2);

        private IWebElement ProductTable => this.containerElement.FindElement(By.XPath(".//table[@id='tblPLookUpResult']"), 1);
        private List<IWebElement> ProductRows => this.ProductTable?.FindElements(By.XPath(".//tbody//tr[not (@class='jqgfirstrow')]"), 1).ToList();




        //Below is taken from recent activities class, will need xpath updates in many areas. Will update when needed. 





        private IWebElement LoadingSpinner => FindElement(By.XPath(".//div[@id='load_tblPLookUpResult']"), 2);
        private List<IWebElement> OnlyexpandedProductRows => this.ProductTable?.FindElements(By.XPath(".//tbody//tr[not (@id='1') and not (@class='ui-jqgrid-labels') and not (@class='jqgfirstrow') and (contains(@class,'ui-subgrid ui-sg-expanded'))]//div[@class='ui-jqgrid-bdiv']"), 1).ToList();


        private IWebElement PageTitle => this.containerElement.FindElement(By.XPath(".//h2"), 2);

        public List<IWebElement> ProductLookUpButtons => this.containerElement.FindElements(By.XPath(".//ul[@class='list-inline']//li"), 2).ToList();

        private IWebElement BreadCrumbArea => this.containerElement.FindElement(By.XPath(".//div[@id='pLookUp']/div[2]"), 2);

        private IWebElement TableHeadingRow => this.containerElement.FindElement(By.XPath(".//div[@id='gview_tblNewProducts']//div[@class='ui-jqgrid-hdiv']//tr[@class='ui-jqgrid-labels']"), 2);

        private List<IWebElement> AllTableHeadings => this.TableHeadingRow.FindElements(By.XPath(".//th[@role='columnheader' and not(contains(@style,'display: none'))]"), 2).ToList();

        private List<IWebElement> NamedTableHeadings => this.TableHeadingRow.FindElements(By.XPath(".//th[@role='columnheader' and not(contains(@style,'display: none')) and not(@id='tblNewProducts_subgrid')]"), 2).ToList();

        private List<IWebElement> RowSubHeadings(IWebElement row) => row.FindElements(By.XPath(".//preceding-sibling::div[@class='ui-jqgrid-hdiv']//th[@role='columnheader' and not(contains(@style,'display: none'))]"), 2).ToList();

        private IWebElement RowSubHeadingLine(IWebElement row) => row.FindElement(By.XPath(".//preceding-sibling::div[@class='ui-jqgrid-hdiv']"), 2);
        private IWebElement ProductsTableFooter => this.containerElement.FindElement(By.XPath(".//div[@id='tblNewProductsPager']"), 2);
        //
        private IWebElement startDateTag => this.containerElement.FindElement(By.XPath(".//div[@class='col-sm-12']//button[@id='filter_startDate']"), 2);
        private IWebElement endDateTag => this.containerElement.FindElement(By.XPath(".//div[@class='col-sm-12']//button[@id='filter_endDate']"), 2);

        private IWebElement FindGivenBreadcrumb(string breadcrumb) => this.containerElement.FindElement(By.XPath($".//div[@class='col-sm-12']//button[@id='filter_{breadcrumb}']"), 2);
        private IWebElement resetDateTag => this.containerElement.FindElement(By.XPath(".//div[@class='col-sm-12']//button[@id='filter_reset']"), 2);
        private List<IWebElement> AllFilterTags => this.containerElement.FindElements(By.XPath(".//div[@class='col-sm-12']//button[contains(@id,'filter_') and @style='display: inline-block;']"), 2).ToList();

        private List<IWebElement> AllOptionButtons => this.containerElement.FindElements(By.XPath(".//ul[@class='list-inline col-md-6']//li"), 2).ToList();

        private IWebElement OptionButtonsSection => this.containerElement.FindElement(By.XPath(".//ul[@class='list-inline']"), 2); //Updated PL

        private IWebElement MoreFiltersOptionButton => this.OptionButtonsSection.FindElement(By.XPath(".//li//button[contains(text(),'More Filters')]"), 2); //Updated PL
        private IWebElement ResetOptionButton => this.OptionButtonsSection.FindElement(By.XPath(".//li//button[contains(text(),'Select Columns')]"), 2); //Updated PL
        private IWebElement ExportOptionButton => this.OptionButtonsSection.FindElement(By.XPath(".//li//button[contains(text(),'Reset')]"), 2); //Updated PL
        private IWebElement StatusOptionButton => this.OptionButtonsSection.FindElement(By.XPath(".//li//button[contains(text(),'Export to Excel')]"), 2); //Updated PL
        private IWebElement CursorTypeElement => this.containerElement.FindElement(By.XPath(".//div[@class='ui-jqgrid-hdiv']"), 2);

        private IWebElement LastPageButton => ProductsTableFooter.FindElement(By.XPath(".//td[@id='last_tblNewProductsPager' and @title='Last Page']//span[@class='glyphicon glyphicon-step-forward']"), 2);
        private IWebElement NextPageButton => ProductsTableFooter.FindElement(By.XPath(".//td[@id='next_tblNewProductsPager' and @title='Next Page']//span[@class='glyphicon glyphicon-forward']"), 2);

        private IWebElement PreviousPageButton => ProductsTableFooter.FindElement(By.XPath(".//td[@id='prev_tblNewProductsPager' and @title='Previous Page']//span[@class='glyphicon glyphicon-backward']"), 2);

        private IWebElement FirstPageButton => ProductsTableFooter.FindElement(By.XPath(".//td[@id='first_tblNewProductsPager' and @title='First Page']//span[@class='glyphicon glyphicon-step-backward']"), 2);

        private IWebElement ItemsPerPageSelector => ProductsTableFooter.FindElement(By.XPath(".//select[@class='ui-pg-selbox form-control']"), 2);

        //private IWebElement GridScrollBar => this.containerElement.FindElement(By.XPath("."), 2);

        //private IWebElement ScrollUpArrow => this.GridScrollBar.FindElement(By.XPath(".//*[name()='g'][3]"), 2);

        private IWebElement ProductsCountEl => ProductsTableFooter.FindElement(By.XPath(".//td[@id='tblNewProductsPager_right']//div"), 2);


        #endregion

        #region Methods

        public bool WaitProductsGridSpinnerFinish()
        {
            if (this.containerElement.WaitUntilElementVisible(By.XPath(".//div[@id='load_tblPLookUpResult']"), 5) != null)
            {
                return this.containerElement.WaitUntilElementInvisible(By.XPath(".//div[@id='load_tblPLookUpResult']"), 30);
            }
            return true;
        }

        public void EnterSearchBoxText(string searchText) => this.SearchBox.EnterText(searchText);
        public void EnterSearchBoxTextAndpressEnterKey(string searchText)
        {
            this.SearchBox.EnterText(searchText);
            this.SearchBox.SendKeys(Keys.Enter);
        }


        public bool CheckSearchBoxContains(string expectedText) => this.SearchBox.GetAttribute("value") == expectedText;

        public int ProductsCount()
        {
            List<IWebElement> productRows = this.ProductRows;
            if (productRows == null || !productRows.Any())
            {
                return 0;
            }
            return productRows.Count(x => x.Displayed);
        }

        public string FirstProductInGridID()
        {
            IWebElement productNumber = this.ProductRows.FirstOrDefault()?.FindElement(By.XPath($".//td[@aria-describedby='tblPLookUpResult_product']"), 1);
            if (productNumber == null)
            {
                Report.Error("The productNumber element was null");
                return null;
            }
            return productNumber.Text;

        }
        public bool ClickActionForFirstResultInGrid(string action)
        {
            try
            {
                IWebElement button = this.ProductRows.FirstOrDefault()?.FindElement(By.XPath($".//p//a[text()='{action}']"), 1);
                return button.TryClick();
            }
            catch (Exception)
            {
                return false;
            }
        }       

        public bool WaitForProductsGridToLoad(int timeout = 30)
        {
            return (this.containerElement.WaitUntilElementVisible(By.XPath(".//table[@id='tblPLookUpResult']"), timeout)) != null;
        }


        //Below is copied from Recent Activities








        public string GetCurrentPageTitle()
        {
            return this.PageTitle.Text;
        }

        public string GetRecentActivitiesBackgroundColor()
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

        public string GetRecentActivitiesTextColor()
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

        public bool ConfirmBreadCrumbAreaContainsLabel(string label)
        {
            var el = this.BreadCrumbArea;
            string test = el.Text;
            return el.Text.Contains(label);
        }



        public bool ConfirmBreadCrumbAreaContainsStartDatelabel()
        {
            var el = this.BreadCrumbArea;
            var startDateLabel = el.FindElement(By.XPath(".//button[@id='filter_startDate']"), 2);
            string labelText = startDateLabel.Text;
            return labelText.Contains("Start Date:");

        }
        public bool ConfirmBreadCrumbAreaContainsEndDatelabel()
        {
            var el = this.BreadCrumbArea;
            var endDateLabel = el.FindElement(By.XPath(".//button[@id='filter_endDate']"), 2);
            string labelText = endDateLabel.Text;
            return labelText.Contains("End Date:");

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

        //Need to create the above method but for subeheadings (in the expanded product grid)

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
                IWebElement firstColumn = item.FindElement(By.XPath(".//td[@aria-describedby='tblNewProducts_subgrid']"), 2);
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

        public bool CheckColumnContainsData(string column)
        {
            List<IWebElement> rows = this.ProductRows;
            if (rows.IsNullOrEmpty())
            {
                return false;
            }
            bool textPresent = true;
            int i = 1;
            foreach (var item in rows)
            {
                if (column == "Product Name")
                {
                    column = column.Replace(" ", "");
                }
                IWebElement wantedColumn = item.FindElement(By.XPath($".//td[contains(@aria-describedby,'tblNewProducts_{column}')]"), 2);
                if (wantedColumn == null)
                {
                    Report.Info($"Did not find the element for Column: {column}");
                    return false;
                }
                string textFound = wantedColumn.Text;
                if (textFound == null)
                {
                    Report.Info($"The text found for row: {i} and column: {column} was null");
                    textPresent = false;

                }
                else
                {
                    Report.Info($"The text was found for row: {i} and column: {column}");
                }
                i++;
            }
            return textPresent;
        }

        public bool CheckColumnContainsProductID()
        {
            List<IWebElement> rows = this.ProductRows;
            if (rows.IsNullOrEmpty())
            {
                return false;
            }
            bool textPresent = true;
            int i = 1;
            foreach (var item in rows)
            {
                IWebElement wantedColumn = item.FindElement(By.XPath($".//td[@aria-describedby='tblNewProducts_ID']"), 2);
                string textFound = wantedColumn.Text;
                if (textFound == null)
                {
                    Report.Info($"The text found for row: {i} was null");
                    textPresent = false;

                }
                else
                {
                    Report.Info($"The text was found for row: {i}");
                    Regex regex = new Regex(@"^\d+$");
                    if (regex.IsMatch(textFound))
                    {
                        Report.Info($"The Text found for row: {i} was a product ID");
                    }
                    else
                    {
                        Report.Info($"The text was non-numeric, a product number was not found in the row: {i}");
                        textPresent = false;
                    }

                }
                i++;
            }
            return textPresent;
        }



        public bool HeadingCheckIDColumnIsToRightOfExpandArrow()
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

            return columnHeadings[expandPosition + 1].Text.Trim() == "ID";


        }


        public bool CheckIDColumnIsToRightofExpandArrowColumn()
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
                List<IWebElement> columns = item.FindElements(By.XPath($".//td[contains(@aria-describedby,'tblNewProducts') and not(@style='display:none;')]"), 2).ToList();
                bool foundSubGridColumn = false;
                for (int x = 0; x < columns.Count(); x++)
                {
                    if (columns[x].GetAttribute("aria-describedby").Contains("subgrid"))
                    {
                        foundSubGridColumn = true;
                        if (columns[x + 1].GetAttribute("aria-describedby").Contains("ID"))
                        {
                            Report.Info($"The column to the right of the expand arrow column was the ID column for row: {i}");
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

        public bool CheckTableAlternatesBetweenGreyAndWhite()
        {
            IWebElement TableEl = this.ProductTable;
            string tableClass = TableEl.GetAttribute("class");
            if (tableClass == "table table-striped ui-jqgrid-btable ui-common-table table-bordered")
            {
                Report.Info("The class of the products table was striped as expected...");
                string rbgaCssValue = TableEl.GetCssValue("background-color");
                if (rbgaCssValue == "rgba(245, 245, 245, 1)")
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

        public bool CheckGivenBreadcrumbContainsText(string breadcrumb, string searchedText)
        {
            var tagElement = this.FindGivenBreadcrumb(breadcrumb);
            string foundText = tagElement.Text;
            return foundText.Contains(searchedText);
        }

        public bool CheckGivenBreadcrumbHasCloseX(string breadcrumb)
        {
            var tagElement = this.FindGivenBreadcrumb(breadcrumb); ;
            if (tagElement == null)
            {
                Report.Info("The start Date Tag element was null");
                return false;
            }
            IWebElement xElement = tagElement.FindElement(By.XPath(".//i[@class='fa fa-remove']"), 2);
            return xElement != null;

        }

        public bool CheckStartDateTagContainsText(string searchedText)
        {
            var tagElement = this.startDateTag;
            string foundText = tagElement.Text;
            return foundText.Contains(searchedText);
        }

        public bool CheckStartDateTagHasCloseX()
        {
            var tagElement = this.startDateTag;
            if (tagElement == null)
            {
                Report.Info("The start Date Tag element was null");
                return false;
            }
            IWebElement xElement = tagElement.FindElement(By.XPath(".//i[@class='fa fa-remove']"), 2);
            return xElement != null;

        }

        public string GetStartDateTagBackgroundColor()
        {
            IWebElement backgroundEl = this.startDateTag;
            if (backgroundEl == null)
            {
                Report.Error("The Background El was null");
                return null;
            }

            string rbgaCssValue = backgroundEl.GetCssValue("background-color");
            return rbgaCssValue;
        }


        public bool CheckEndDateTagContainsText(string searchedText)
        {
            var tagElement = this.endDateTag;
            string foundText = tagElement.Text;
            return foundText.Contains(searchedText);
        }
        public bool CheckEndDateTagHasCloseX()
        {
            var tagElement = this.endDateTag;
            if (tagElement == null)
            {
                Report.Info("The start Date Tag element was null");
                return false;
            }
            IWebElement xElement = tagElement.FindElement(By.XPath(".//i[@class='fa fa-remove']"), 2);
            return xElement != null;

        }

        public string GetEndDateTagBackgroundColor()
        {
            IWebElement backgroundEl = this.endDateTag;
            if (backgroundEl == null)
            {
                Report.Error("The Background El was null");
                return null;
            }

            string rbgaCssValue = backgroundEl.GetCssValue("background-color");
            return rbgaCssValue;
        }

        public bool ConfirmFilterTagsCorrectOrder()
        {
            var tagList = this.AllFilterTags;
            List<string> expectedTags = new List<string> { "Start Date:", "End Date:", "Reset" };
            Report.Info($"The Found Tags: {string.Join(",", tagList)}");
            Report.Info($"The expected Tags: {string.Join(",", expectedTags)}");
            int i = 0;
            bool tagcorrect = true;
            foreach (var item in tagList)
            {
                if (item.Text.Contains(expectedTags[i]))
                {
                    Report.Info("The Tag found was as expected");

                }
                else
                {
                    Report.Info("The tag found was not as expected");
                    tagcorrect = false;
                }
            }
            return tagcorrect;
        }

        public bool CheckResetTagContainsText(string searchedText)
        {
            var tagElement = this.resetDateTag;
            string foundText = tagElement.Text;
            return foundText.Contains(searchedText);
        }

        public string GetResetTagBackgroundColor()
        {
            IWebElement backgroundEl = this.resetDateTag;
            if (backgroundEl == null)
            {
                Report.Error("The Background El was null");
                return null;
            }

            string rbgaCssValue = backgroundEl.GetCssValue("background-color");
            return rbgaCssValue;
        }

        public string GetResetTagTextColor()
        {
            IWebElement eL = this.resetDateTag;
            if (eL == null)
            {
                Report.Error("The El was null");
                return null;
            }

            string rbgaCssValue = eL.GetCssValue("color");
            return rbgaCssValue;
        }

        public List<string> OptionButtonsStrings()
        {
            var foundButtons = this.AllOptionButtons;
            if (foundButtons == null)
            {
                Report.Info("the Options list was null");
                return null;
            }
            List<string> buttonTexts = new List<string>();
            foreach (var item in foundButtons)
            {
                string currentText = item.Text.Trim();
                buttonTexts.Add(currentText);
            }
            return buttonTexts;
        }

        public bool ConfirmOptionButtonsMatch(List<string> expectedButtons)
        {
            var foundButtonTexts = this.OptionButtonsStrings();
            int i = 0;
            bool matching = true;
            foreach (var item in foundButtonTexts)
            {
                Report.Info($"The Found button text was: {item} and the expected was: {expectedButtons[i]}");
                if (expectedButtons[i] == item)
                {
                    Report.Info("The Found button was a match");
                }
                else
                {
                    Report.Info("The Found button was not a match");
                    matching = false;

                }

            }
            return matching;
        }

        public string GetMoreFiltersButtonBackgroundColor()
        {
            IWebElement backgroundEl = this.MoreFiltersOptionButton;
            if (backgroundEl == null)
            {
                Report.Error("The Background El was null");
                return null;
            }

            string rbgaCssValue = backgroundEl.GetCssValue("background-color");
            return rbgaCssValue;
        }

        public string GetMoreFiltersButtonTextColor()
        {
            IWebElement eL = this.MoreFiltersOptionButton;
            if (eL == null)
            {
                Report.Error("The El was null");
                return null;
            }

            string rbgaCssValue = eL.GetCssValue("color");
            return rbgaCssValue;
        }

        public string GetResetButtonBackgroundColor()
        {
            IWebElement backgroundEl = this.ResetOptionButton;
            if (backgroundEl == null)
            {
                Report.Error("The Background El was null");
                return null;
            }

            string rbgaCssValue = backgroundEl.GetCssValue("background-color");
            return rbgaCssValue;
        }

        public string GetResetButtonTextColor()
        {
            IWebElement eL = this.ResetOptionButton;
            if (eL == null)
            {
                Report.Error("The El was null");
                return null;
            }

            string rbgaCssValue = eL.GetCssValue("color");
            return rbgaCssValue;
        }


        public string GetExportButtonBackgroundColor()
        {
            IWebElement backgroundEl = this.ExportOptionButton;
            if (backgroundEl == null)
            {
                Report.Error("The Background El was null");
                return null;
            }

            string rbgaCssValue = backgroundEl.GetCssValue("background-color");
            return rbgaCssValue;
        }

        public string GetExportButtonTextColor()
        {
            IWebElement eL = this.ExportOptionButton;
            if (eL == null)
            {
                Report.Error("The El was null");
                return null;
            }

            string rbgaCssValue = eL.GetCssValue("color");
            return rbgaCssValue;
        }

        public string GetStatusButtonBackgroundColor()
        {
            IWebElement backgroundEl = this.StatusOptionButton;
            if (backgroundEl == null)
            {
                Report.Error("The Background El was null");
                return null;
            }

            string rbgaCssValue = backgroundEl.GetCssValue("background-color");
            return rbgaCssValue;
        }

        public string GetStatusButtonTextColor()
        {
            IWebElement eL = this.StatusOptionButton;
            if (eL == null)
            {
                Report.Error("The El was null");
                return null;
            }

            string rbgaCssValue = eL.GetCssValue("color");
            return rbgaCssValue;
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
            if (column == "ProductNumber" || column == "Upc")
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
            if (column == "ProductNumber" || column == "Upc")
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

        public bool ExpandFirstRow()
        {
            var rows = this.ProductRows;
            if (rows.IsNullOrEmpty())
            {
                Report.Info("no rows of products were found in the table");
                return false;
            }
            IWebElement firstRow = rows[0];
            IWebElement expandButton = firstRow.FindElement(By.XPath($".//td[contains(@aria-describedby,'tblNewProducts_subgrid')]"), 2);
            if (!expandButton.TryClick())
            {
                Report.Info("Failed to click the expand button");
                return false;
            }
            string expandedAttribute = expandButton.GetAttribute("class");
            return expandedAttribute == "ui-sgcollapsed sgexpanded";


        }

        public bool ExpandRowByID(string productID)
        {
            var rows = this.ProductRows;
            if (rows.IsNullOrEmpty())
            {
                Report.Info("no rows of products were found in the table");
                return false;
            }

            // IWebElement firstRow = rows[0];
            IWebElement wantedRow = rows.First(x => x.Text.Contains(productID));

            IWebElement expandButton = wantedRow.FindElement(By.XPath($".//td[contains(@aria-describedby,'tblNewProducts_subgrid')]"), 2);
            if (!expandButton.TryClick())
            {
                Report.Info("Failed to click the expand button");
                return false;
            }
            string expandedAttribute = expandButton.GetAttribute("class");
            return expandedAttribute == "ui-sgcollapsed sgexpanded";


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
            IWebElement expandButton = firstRow.FindElement(By.XPath($".//td[contains(@aria-describedby,'tblNewProducts_subgrid')]"), 2);
            if (!expandButton.TryClick())
            {
                Report.Info("Failed to click the collapse button");
                return false;
            }
            string expandedAttribute = expandButton.GetAttribute("class");
            return expandedAttribute == "ui-sgcollapsed sgcollapsed";


        }


        public bool CollapseRowByID(string productID)
        {
            var rows = this.ProductRows;
            if (rows.IsNullOrEmpty())
            {
                Report.Info("no rows of products were found in the table");
                return false;
            }
            IWebElement wantedRow = rows.First(x => x.Text.Contains(productID));

            IWebElement expandButton = wantedRow.FindElement(By.XPath($".//td[contains(@aria-describedby,'tblNewProducts_subgrid')]"), 2);
            if (!expandButton.TryClick())
            {
                Report.Info("Failed to click the collapse button");
                return false;
            }
            string expandedAttribute = expandButton.GetAttribute("class");
            return expandedAttribute == "ui-sgcollapsed sgcollapsed";


        }

        public IWebElement GetRowByID(string ID)
        {
            List<IWebElement> rows = this.ProductRows;
            if (rows.IsNullOrEmpty())
            {
                Report.Error($"Did not find any product rows");
                return null;
            }
            bool textPresent = true;
            int i = 1;
            foreach (var item in rows)
            {
                string column = "ID";
                IWebElement wantedColumn = item.FindElement(By.XPath($".//td[contains(@aria-describedby,'tblNewProducts_{column}')]"), 2);
                if (wantedColumn == null)
                {
                    Report.Error($"Did not find the element for Column: {column}");
                    return null;
                }
                if (wantedColumn.Text.Contains(ID))
                {
                    Report.Info($"Found the row with expected ID");
                    return item;
                }
            }
            Report.Info("Did not find the row with the expected ID");
            return null;
        }

        public IWebElement GetRowByExpandedProductID(string ID)
        {
            List<IWebElement> rows = this.OnlyexpandedProductRows;
            if (rows.IsNullOrEmpty())
            {
                Report.Error($"Did not find any product rows");
                return null;
            }
            bool textPresent = true;
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
                if (wantedColumn.Text.Contains(ID))
                {
                    Report.Info($"Found the row with expected ID");
                    return item;
                }
            }
            Report.Info("Did not find the row with the expected ID");
            return null;
        }


        public string GetFirstProductID()
        {
            List<IWebElement> rows = this.ProductRows;
            if (rows.IsNullOrEmpty())
            {
                Report.Error($"Did not find any product rows");
                return null;
            }

            string column = "ID";
            IWebElement wantedColumn = rows[0].FindElement(By.XPath($".//td[contains(@aria-describedby,'tblNewProducts_{column}')]"), 2);
            if (wantedColumn == null)
            {
                Report.Error($"Did not find the element for Column: {column}");
                return null;
            }
            //will need to check that this ID returned is correct format
            return wantedColumn.Text;
        }

        public string GetFirstProductName()
        {
            List<IWebElement> rows = this.ProductRows;
            if (rows.IsNullOrEmpty())
            {
                Report.Error($"Did not find any product rows");
                return null;
            }

            string column = "ProductName";
            IWebElement wantedColumn = rows[0].FindElement(By.XPath($".//td[contains(@aria-describedby,'tblNewProducts_{column}')]"), 2);
            if (wantedColumn == null)
            {
                Report.Error($"Did not find the element for Column: {column}");
                return null;
            }
            //will need to check that this ID returned is correct format
            return wantedColumn.Text;
        }

        public bool CheckProductNameInResults(string expectedName)
        {
            List<IWebElement> rows = this.ProductRows;
            if (rows.IsNullOrEmpty())
            {
                Report.Error($"Did not find any product rows");
                return false;
            }

            string column = "ProductName";
            foreach (var row in rows)
            {
                IWebElement wantedColumn = row.FindElement(By.XPath($".//td[contains(@aria-describedby,'tblNewProducts_{column}')]"), 2);
                if (wantedColumn == null)
                {
                    Report.Error($"Did not find the element for Column: {column}");
                    return false;
                }
                if (wantedColumn.Text == expectedName)
                {
                    return true;
                }

            }
            return false;



        }


        public List<string> GetFirstProductUPCs()
        {
            string firstID = this.GetFirstProductID();
            this.ExpandRowByID(firstID);
            List<string> upcs = this.GetUPCSByID(firstID);
            this.CollapseRowByID(firstID);
            return upcs;

        }

        public List<string> GetSubRowColumnHeadingTitles(IWebElement row)
        {
            var headings = this.RowSubHeadings(row);
            List<string> headingStrings = new List<string>();
            foreach (var heading in headings)
            {
                string currentHeading = heading.Text;
                string currentHeadingTrimmed = currentHeading.Trim();
                headingStrings.Add(currentHeadingTrimmed);
            }
            return headingStrings;
        }

        public bool RowSubTableContainsExpandedMenuIcon(IWebElement row)
        {
            IWebElement fullRowElement = row.FindElement(By.XPath(".//ancestor::tr[@class='ui-subgrid ui-sg-expanded']"), 2);
            IWebElement expandedIcon = fullRowElement.FindElement(By.XPath(".//td[contains(@class,'subgrid-cell')]//span"), 2);
            string expandedAttr = expandedIcon.GetAttribute("class");
            return expandedAttr == "glyphicon glyphicon-indent-left";

        }

        public bool ClickStartDateLabel()
        {
            return this.startDateTag.TryClick();
        }

        public bool ClickGivenBreadcrumb(string breadcrumb)
        {
            return this.FindGivenBreadcrumb(breadcrumb).TryClick();
        }

        public bool ClickGivenBreadcrumbRightSideX(string breadcrumb)
        {
            return this.FindGivenBreadcrumb(breadcrumb).FindElement(By.XPath(".//i[@class='fa fa-remove']"), 2).TryClick();
        }

        public List<string> GetColumnData(string column)
        {
            List<IWebElement> rows = this.ProductRows;
            List<string> columnData = new List<string>();
            if (rows.IsNullOrEmpty())
            {
                return null;
            }
            foreach (var item in rows)
            {
                if (column == "Product Name")
                {
                    column = column.Replace(" ", "");
                }
                IWebElement wantedColumn = item.FindElement(By.XPath($".//td[contains(@aria-describedby,'tblNewProducts_{column}')]"), 2);
                if (wantedColumn == null)
                {
                    Report.Info($"Did not find the element for Column: {column}");
                    return null;
                }
                string textFound = wantedColumn.Text;
                columnData.Add(textFound);


            }
            return columnData;
        }

        public List<string> GetCurrentProductIDs()
        {
            List<string> currentIDs = new List<string>();
            List<IWebElement> rows = this.ProductRows;
            if (rows.IsNullOrEmpty())
            {
                Report.Error($"Did not find any product rows");
                return null;
            }
            string column = "ID";
            int i = 1;
            foreach (var row in rows)
            {
                IWebElement wantedColumn = row.FindElement(By.XPath($".//td[contains(@aria-describedby,'tblNewProducts_{column}')]"), 2);
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

        public string GetMostRecentDateByID(string iD)
        {
            var wantedRow = this.GetRowByID(iD);
            IWebElement wantedColumn = wantedRow.FindElement(By.XPath($".//td[contains(@aria-describedby,'tblNewProducts_Most Recent Activity')]"), 2);
            return wantedColumn.Text;
        }

        public string GetColumValueByID(string column, string iD)
        {
            //Does not appear to work for expanded rows based on the structure of the table
            //if (column == "Product ID")
            //{
            //    column = "ProductNumber";
            //}
            //if (column == "UPC Number")
            //{
            //    column = "Upc";
            //}
            if (column == "Product Name")
            {
                column = column.Replace(" ", "");
            }
            var wantedRow = this.GetRowByID(iD);
            IWebElement wantedColumn = wantedRow.FindElement(By.XPath($".//td[contains(@aria-describedby,'tblNewProducts_{column}')]"), 2);
            return wantedColumn.Text;
        }

        public List<string> GetUPCSByID(string iD)
        {

            var wantedRow = this.GetRowByExpandedProductID(iD);
            string column = "Upc";
            if (wantedRow == null)
            {
                Report.Info("Did not want the expanded row with ID");
                return null;
            }
            List<IWebElement> wantedColumn = wantedRow.FindElements(By.XPath($".//td[contains(@aria-describedby,'t_{column}')]"), 2).ToList();
            if (wantedColumn.IsNullOrEmpty())
            {
                Report.Info("Did not find the UPC column");
                return null;
            }
            List<string> foundUpcs = new List<string>();
            foreach (var item in wantedColumn)
            {
                Report.Info($"UPC found was: {item.Text}");
                foundUpcs.Add(item.Text);
            }
            return foundUpcs;
        }

        public RecentProductData GetRecentProductDataByID(string iD)
        {
            RecentProductData currentRecentData = new RecentProductData();
            currentRecentData.ID = iD;
            currentRecentData.ProductName = this.GetColumValueByID("Product Name", iD);
            currentRecentData.Supplier = this.GetColumValueByID("Supplier", iD);
            currentRecentData.Status = this.GetColumValueByID("Status", iD);
            currentRecentData.MostRecentActivity = this.GetColumValueByID("Most Recent Activity", iD);
            this.ExpandRowByID(iD);
            currentRecentData.UPC = this.GetUPCSByID(iD);
            this.CollapseRowByID(iD);
            return currentRecentData;

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
        public bool ClickNextPageButton()
        {
            return this.NextPageButton.TryClick();
        }
        public bool ClickPreviousPageButton()
        {
            return this.PreviousPageButton.TryClick();
        }

        public bool ClickFirstPageButton()
        {
            return this.FirstPageButton.TryClick();
        }

        public string GetCurrentPageNumber()
        {
            IWebElement currentPageEl = this.ProductsTableFooter.FindElement(By.XPath(".//input[@class='ui-pg-input form-control']"), 2);
            return currentPageEl.GetValue();
        }

        public string GetLastPossiblePageNumber()
        {
            IWebElement LastPageEl = this.ProductsTableFooter.FindElement(By.XPath(".//span[@id='sp_1_tblNewProductsPager']"), 2);
            return LastPageEl.Text;
        }

        public List<string> GetItemsPerPageOptions()
        {
            List<IWebElement> optionsELs = this.ItemsPerPageSelector.FindElements(By.XPath(".//option"), 2).ToList();
            List<string> displayedOptions = new List<string>();
            foreach (var el in optionsELs)
            {
                displayedOptions.Add(el.Text);
            }
            return displayedOptions;

        }

        public bool SelectOptionFromItemsPerPageSelector(string option)
        {
            IWebElement selecterEl = this.ItemsPerPageSelector;
            selecterEl.Select(option);
            return selecterEl.SelectedOption() == option;
        }

        public bool ItemsPerPageOptionsMatch(List<string> expectedOptions)
        {
            List<string> foundOptions = this.GetItemsPerPageOptions();
            var differences = foundOptions.Except(expectedOptions);
            return foundOptions.Count() == expectedOptions.Count() && differences.IsNullOrEmpty();
        }
        public int GetCurrentItemsPerPage()
        {
            IWebElement selecterEl = this.ItemsPerPageSelector;
            return Int32.Parse(selecterEl.SelectedOption());
        }

        public int GetProductsInGrid()
        {
            List<IWebElement> rows = this.ProductRows;
            return rows.Count();
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

        public bool ClickResetButton()
        {
            return this.ResetOptionButton.TryClick();
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

        public bool ConfirmAllNamesContain(string productName)
        {
            List<string> foundNames = this.GetColumnData("Product Name");
            bool contained = true;
            foreach (var item in foundNames)
            {
                if (item.ToLower().Contains(productName.ToLower()))
                {
                    Report.Info($"The product with name: {item} contained the search text");

                }
                else
                {
                    Report.Info($"The product with name: {item} did not contain the search text");
                    contained = false;

                }
            }
            return contained;
        }

        public bool ConfirmAllSuppliers(string supplierName)
        {
            List<string> foundNames = this.GetColumnData("Supplier");
            bool contained = true;
            foreach (var item in foundNames)
            {
                if (item.ToLower().Contains(supplierName.ToLower()))
                {
                    Report.Info($"The supplier with name: {item} contained the search text");

                }
                else
                {
                    Report.Info($"The supplier with name: {item} did not contain the search text");
                    contained = false;

                }
            }
            return contained;
        }

        public bool ConfirmAllStatus(string supplierName)
        {
            List<string> foundNames = this.GetColumnData("Status");
            bool contained = true;
            foreach (var item in foundNames)
            {
                if (item.ToLower().Contains(supplierName.ToLower()))
                {
                    Report.Info($"The supplier with name: {item} contained the search text");

                }
                else
                {
                    Report.Info($"The supplier with name: {item} did not contain the search text");
                    contained = false;

                }
            }
            return contained;
        }

        public bool ConfirmAllSuppliersMatchExactly(string supplierName)
        {
            List<string> foundNames = this.GetColumnData("Supplier");
            bool contained = true;
            foreach (var item in foundNames)
            {
                if (item == supplierName)
                {
                    Report.Info($"The supplier with name: {item} contained the search text");

                }
                else
                {
                    Report.Info($"The supplier with name: {item} did not contain the search text");
                    contained = false;

                }
            }
            return contained;
        }

        public bool ClickMoreFiltersOptionButton()  //Updated PL
        {
            return this.MoreFiltersOptionButton.TryClick();
        }

        public void EnterCurrentPageValue(string value)
        {
            IWebElement currentPageEl = this.ProductsTableFooter.FindElement(By.XPath(".//input[@class='ui-pg-input form-control']"), 2);
            currentPageEl.ClearTextBox();
            currentPageEl.EnterText(value);
            currentPageEl.SendKeys(Keys.Enter);
        }

        #endregion



        public class MoreFiltersPopup : SeleniumBaseObject
        {
            #region Page Objects
            protected override By ContainerElementLocator => By.XPath("//div[@id='moreFiltersModal']//div[@class='modal-dialog']");

            public List<IWebElement> MoreFiltersOptionsElements() => this.containerElement.FindElements(By.XPath(".//a[@class='list-group-item']"), 2).ToList();

            private IWebElement GivenLabelElementInput(string labelText) => this.containerElement.FindElement(By.XPath($".//div[@class='form-group' and .//label[text()='{labelText}']]//div"), 2);

            private IWebElement ParameterSearchBox => this.containerElement.FindElement(By.XPath(".//div[@class='modal-dialog']//div[@class='form-group']//input"), 2);

            public List<IWebElement> CurrentFilterParameters => this.containerElement.FindElements(By.XPath(".//ul//li"), 2).ToList();
            public IWebElement OKButton => this.containerElement.FindElement(By.XPath(".//div[@class='modal-footer lgrey-b']//button[text()='OK']"), 2);




            #endregion

            #region Methods

            public List<string> GetMoreFiltersOptionsText()
            {
                List<string> optionTexts = new List<string>();
                var els = this.MoreFiltersOptionsElements();
                foreach (var el in els)
                {
                    optionTexts.Add(el.Text);
                }
                return optionTexts;
            }

            public bool ClickFilterOption(string label)
            {
                //issue if flashpoint (Symbol)??
                var els = this.MoreFiltersOptionsElements();
                return els.First(x => x.Text == label).TryClick();
            }

            public bool FilterFieldExists(string filterLabel)
            {
                IWebElement el = this.GivenLabelElementInput(filterLabel);
                return el != null;
            }

            public bool EnterParameterForSearch(string value)
            {
                var el = this.ParameterSearchBox;
                el.JsEnterText(value);
                Delay.Seconds(5);
                return el.GetAttribute("value") == value;
            }

            public bool ClickFirstParameterOption()
            {
                var els = this.CurrentFilterParameters;
                var wantedEl = els.First();
                var boxEl = wantedEl.FindElement(By.XPath(".//input"), 2);
                if (boxEl != null)
                {
                    return boxEl.TryClick();
                }
                else
                {
                    return wantedEl.TryClick();
                }

            }

            public bool ClickGivenParameterOption(string value)
            {
               // var els = this.CurrentFilterParameters;
                //List<string> testList = new List<string>();
                //foreach(var el in els)
                //{
                //    testList.Add(el.Text);
                //    if()
                //    el.Text.Substring(0, el.Text.IndexOf("("));
                //}              
                var els = this.GetCurrentFilterParameters();
                List<string> testList = new List<string>();
                foreach (var el in els)
                {
                    testList.Add(el.Text); 
                }
                Report.Info("");
                var wantedEl = els.First(x => x.Text == value);



                IWebElement boxEl = wantedEl.FindElement(By.XPath(".//input"), 2);
                if (boxEl!=null)
                {
                    return boxEl.TryClick();
                }
                else
                {
                    return wantedEl.TryClick();
                }



                
            }
            public bool OKButtonIsPresent()
            {
                IWebElement el = this.OKButton;
                return el != null;
            }

            public bool ClickOKButton()
            {
                return this.OKButton.TryClick();
            }


            public List<IWebElement> GetCurrentFilterParameters()
            {

                // string xPathTest = @"(//ul//li//span[@data-bind='text: translatedValue'] | //ul//li)";
                //List<IWebElement> elList = SeleniumBrowser.WebBrowser.FindElements(By.XPath(xPathTest), 10).ToList();

                List<IWebElement> parameterElList = this.containerElement.FindElements(By.XPath(".//ul//li//span[@data-bind='text: translatedValue']"), 4).ToList();
                if(parameterElList.IsNullOrEmpty())
                {
                    parameterElList= this.containerElement.FindElements(By.XPath(".//ul//li"), 4).ToList();
                }               
                return parameterElList;

            }

            public bool WaitForParametersToShow()
            {
                Report.Info("Starting to wait for Parameters List to Show");
                int x = 0;
                var parametesElList = this.GetCurrentFilterParameters();
                while(parametesElList.IsNullOrEmpty()&&x<15)
                {
                    parametesElList= this.GetCurrentFilterParameters();
                    x++;
                    Delay.Seconds(5);

                }

                if(parametesElList.IsNullOrEmpty())
                {
                    Report.Info($"The parameters list was not showing options");
                    return false;
                }
                else
                {
                    Report.Info($"The parameters list was showing options");
                    return true;
                }
               

            }



            #endregion

        }



    }

    
}





