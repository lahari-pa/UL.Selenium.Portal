using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using UL.Automation.Reporting.Functions;
using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Classes;
using UL.Automation.WebDriver.Extensions;
using UL.Selenium.Portal.RPS.Classes;
using UL.Selenium.Portal.WERCSmart.Classes;
using static UL.Selenium.Portal.RPS.Selenium_Classes.RecentActivities;


namespace UL.Selenium.Portal.RPS.Selenium_Classes
{
    public class ProductLookUp : SeleniumBaseObject
    {
        #region Page Objects
        protected override By ContainerElementLocator => By.XPath("//div[contains(@class, 'container-fluid') or contains(@class,'body-container')]");

        private IWebElement SearchBox => FindElement(By.XPath(".//input[@name='lookup']"), 2);
        private IWebElement ProductLookupSearchBox => FindElement(By.XPath("//input[contains(@data-bind, 'textInput: searchText')]"), 2);
        private IWebElement ProductTable => ContainerElement.FindElement(By.XPath(".//table[@id='tblPLookUpResult' or @id='dataGrid']"), 1);
        private List<IWebElement> ProductRows => this.ProductTable?.FindElements(By.XPath(".//tbody//tr[not (@class='jqgfirstrow')]"), 1).ToList();




        //Below is taken from recent activities class, will need xpath updates in many areas. Will update when needed.





        private IWebElement LoadingSpinner => FindElement(By.XPath(".//div[@id='load_tblPLookUpResult']"), 2);
        private List<IWebElement> OnlyexpandedProductRows => this.ProductTable?.FindElements(By.XPath(".//tbody//tr[not (@id='1') and not (@class='ui-jqgrid-labels') and not (@class='jqgfirstrow') and (contains(@class,'ui-subgrid ui-sg-expanded'))]//div[@class='ui-jqgrid-bdiv']"), 1).ToList();


        private IWebElement PageTitle => ContainerElement.FindElement(By.XPath(".//h2"), 2);

        public List<IWebElement> ProductLookUpButtons => ContainerElement.FindElements(By.XPath(".//div[@class='col']//button"), 2).ToList();

        private IWebElement BreadCrumbArea => ContainerElement.FindElement(By.XPath(".//div[@class='filter-breadcrumbs']"), 2);

        private IWebElement TableHeadingRow => ContainerElement.FindElement(By.XPath(".//div[@id='gview_tblNewProducts']//div[@class='ui-jqgrid-hdiv']//tr[@class='ui-jqgrid-labels']"), 2);

        private List<IWebElement> AllTableHeadings => this.TableHeadingRow.FindElements(By.XPath(".//th[@role='columnheader' and not(contains(@style,'display: none'))]"), 2).ToList();

        private List<IWebElement> NamedTableHeadings => this.TableHeadingRow.FindElements(By.XPath(".//th[@role='columnheader' and not(contains(@style,'display: none')) and not(@id='tblNewProducts_subgrid')]"), 2).ToList();

        private List<IWebElement> RowSubHeadings(IWebElement row) => row.FindElements(By.XPath(".//preceding-sibling::div[@class='ui-jqgrid-hdiv']//th[@role='columnheader' and not(contains(@style,'display: none'))]"), 2).ToList();

        private IWebElement RowSubHeadingLine(IWebElement row) => row.FindElement(By.XPath(".//preceding-sibling::div[@class='ui-jqgrid-hdiv']"), 2);
        private IWebElement ProductsTableFooter => ContainerElement.FindElement(By.XPath(".//div[@id='tblNewProductsPager']"), 2);
        private IWebElement PageFooter => ContainerElement.FindElement(By.XPath(".//tfoot"), 2);
        //
        private IWebElement startDateTag => ContainerElement.FindElement(By.XPath(".//div[@class='col-sm-12']//button[@id='filter_startDate']"), 2);
        private IWebElement endDateTag => ContainerElement.FindElement(By.XPath(".//div[@class='col-sm-12']//button[@id='filter_endDate']"), 2);

        private IWebElement FindGivenBreadcrumb(string breadcrumb) => this.containerElement.FindElement(By.XPath($".//div[@class='col-sm-12']//button[@id='filter_{breadcrumb}']"), 2);
        private IWebElement resetDateTag => ContainerElement.FindElement(By.XPath(".//div[@class='col-sm-12']//button[@id='filter_reset']"), 2);
        private List<IWebElement> AllFilterTags => ContainerElement.FindElements(By.XPath(".//div[@class='col-sm-12']//button[contains(@id,'filter_') and @style='display: inline-block;']"), 2).ToList();

        private List<IWebElement> AllOptionButtons => ContainerElement.FindElements(By.XPath(".//ul[@class='list-inline col-md-6']//li"), 2).ToList();

        private IWebElement OptionButtonsSection => ContainerElement.FindElement(By.XPath(".//div[contains(@class,'table-page')]"), 2); //Updated PL

        private IWebElement MoreFiltersOptionButton => this.ContainerElement.FindElement(By.XPath(".//button[normalize-space(.) = 'More Filters']"), 2); //Updated PL
        private IWebElement ResetOptionButton => this.ContainerElement.FindElement(By.XPath(".//button[contains(@data-bind,'click: reset')]"), 2); //Updated PL
        private IWebElement SelectColumnsOptionnButton => this.FindElement(By.XPath(".//button[normalize-space()='Select Columns']"), 2); //Updated PL
        private IWebElement ExportOptionButton => this.OptionButtonsSection.FindElement(By.XPath(".//div//button[contains(@data-bind,'exportToExcel')]"), 2); //Updated PL
        private IWebElement StatusOptionButton => this.OptionButtonsSection.FindElement(By.XPath(".//li//button[contains(text(),'Export to Excel')]"), 2); //Updated PL
        private IWebElement CursorTypeElement => ContainerElement.FindElement(By.XPath(".//div[@class='ui-jqgrid-hdiv']"), 2);

        private IWebElement LastPageButton => ProductsTableFooter.FindElement(By.XPath(".//td[@id='last_tblNewProductsPager' and @title='Last Page']//span[@class='glyphicon glyphicon-step-forward']"), 2);
        private IWebElement NextPageButton => ProductsTableFooter.FindElement(By.XPath(".//td[@id='next_tblNewProductsPager' and @title='Next Page']//span[@class='glyphicon glyphicon-forward']"), 2);

        private IWebElement PreviousPageButton => ProductsTableFooter.FindElement(By.XPath(".//td[@id='prev_tblNewProductsPager' and @title='Previous Page']//span[@class='glyphicon glyphicon-backward']"), 2);

        private IWebElement FirstPageButton => ProductsTableFooter.FindElement(By.XPath(".//td[@id='first_tblNewProductsPager' and @title='First Page']//span[@class='glyphicon glyphicon-step-backward']"), 2);

        private IWebElement ItemsPerPageSelector => ProductsTableFooter.FindElement(By.XPath(".//select[@class='ui-pg-selbox form-control']"), 2);

        //private IWebElement GridScrollBar => ContainerElement.FindElement(By.XPath("."), 2);

        //private IWebElement ScrollUpArrow => this.GridScrollBar.FindElement(By.XPath(".//*[name()='g'][3]"), 2);

        private IWebElement ProductsCountEl => ProductsTableFooter.FindElement(By.XPath(".//td[@id='tblNewProductsPager_right']//div"), 2);


        #endregion

        #region Methods

        public bool WaitProductsGridSpinnerFinish()
        {
            if (ContainerElement.WaitUntilElementVisible(By.XPath(".//div[@id='load_tblPLookUpResult']"), 5) != null)
            {
                return ContainerElement.WaitUntilElementInvisible(By.XPath(".//div[@id='load_tblPLookUpResult']"), 30);
            }
            return true;
        }

        public bool ProductTableIsPresent() => this.ProductTable.NotNullAndDisplayed();

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
        public string GetSearchedProductInGridByID()
        {
            IWebElement productNumber = this.ProductRows.FirstOrDefault()?.FindElement(By.XPath($".//mark"), 1);
            if (productNumber == null)
            {
                Report.Error("The productNumber element was null");
                return null;
            }
            return productNumber.Text;

        }

        public string GetSearchedProductInGridByName()
        {
            IWebElement productName = this.ProductRows.FirstOrDefault()?.FindElement(By.XPath($".//td[@aria-describedby='dataGrid_PRODINFO']"), 1);
            if (productName == null)
            {
                Report.Error("The productName element was null");
                return null;
            }
            return productName.Text;

        }

        public List<string> GetSearchedProductInGridByUPCOrWPSIDOrSupplierName()
        {

            List<IWebElement> productInformation = this.FindElements(By.XPath(".//td[@aria-describedby='dataGrid_PRODINFO']"), 2).ToList();
            List<string> productInformationStrings = new List<string>();
            foreach (var number in productInformation)
            {
                string upcNumber = number.Text;
                productInformationStrings.Add(upcNumber);
            }
            return productInformationStrings;


        }

        public bool SearchMatchWithUPC(string savedAs)
        {
            List<string> foundProducts = this.GetSearchedProductInGridByUPCOrWPSIDOrSupplierName();
            foreach (var product in foundProducts)
            {
                product.Contains(savedAs);

            }
            return true;
        }

        public string GetSearchedProductInGridByUPC()
        {
            IWebElement upcNumber = this.ProductRows.FirstOrDefault()?.FindElement(By.XPath($".//mark"), 1);
            if (upcNumber == null)
            {
                Report.Error("The UPC Number element was null");
                return null;
            }
            return upcNumber.Text;

        }

        public string GetSearchedProductInGridByWPSID()
        {
            IWebElement wpsidNumber = this.ProductRows.FirstOrDefault()?.FindElement(By.XPath($".//mark"), 1);
            if (wpsidNumber == null)
            {
                Report.Error("The WPSID Number element was null");
                return null;
            }
            return wpsidNumber.Text;

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
            return (ContainerElement.WaitUntilElementVisible(By.XPath(".//table[@id='tblPLookUpResult']"), timeout)) != null;
        }


        //Below is copied from Recent Activities








        public string GetCurrentPageTitle()
        {
            return this.PageTitle.Text;
        }

        public string GetRecentActivitiesBackgroundColor()
        {
            IWebElement backgroundEl = ContainerElement.FindElement(By.XPath(".//ancestor::body"));
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
            IWebElement backgroundEl = ContainerElement;
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
            IWebElement boxEl = this.ProductLookupSearchBox;
            return boxEl != null;
        }

        public string SearchBoxPlaceHolderText()
        {
            string placeholderText = this.ProductLookupSearchBox.GetAttribute("placeholder");
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

        public bool IClickBreadCrumbArea()
        {
            var el = this.BreadCrumbArea; 
            return el.TryClick();
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
        IWebElement TablesHeadingRow = this.FindElement(By.XPath(".//div[@class = 'ui-jqgrid-hdiv ui-state-default ui-corner-top']//tr[@class='ui-jqgrid-labels']"), 2);
            if (TablesHeadingRow == null)
            {
                Report.Error("The Background El was null");
                return null;
            }

            string rbgaCssValue = TablesHeadingRow.GetCssValue("background-color");
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
        public List<string> GetColumnsShownNameListInProductTable()
        {

            IList<IWebElement> ColumnsShown = this.containerElement.FindElements(By.XPath(".//th[@role='columnheader' and not(contains(@style,'display: none')) and not(@id='tblNewProducts_subgrid')]"), 2);
            List<string> columnsShownNames = new List<string>();
            
            
            foreach (IWebElement el in ColumnsShown)
            {
           
                columnsShownNames.Add(el.Text.Trim());
                
            }
            columnsShownNames.RemoveAll(t => t == "Actions" || t == "Product Info");
            return columnsShownNames;

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
            var footerEl = this.PageFooter;
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
            string column = "PRODINFO";
            int i = 1;
            foreach (var row in rows)
            {
                IWebElement wantedColumn = row.FindElement(By.XPath($".//td[contains(@aria-describedby,'dataGrid_PRODINFO')]/span[2]"), 2);
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

        public bool ClickSelectColumnsButton()
        {
            if (this.SelectColumnsOptionnButton == null)
            {
                return false;
            }

            return this.SelectColumnsOptionnButton.TryClick();
        }

        public bool SelectColumnsButtonGraphicExists()
        {
            Report.Info($"Attempting to confirm graphic exists on Select Columns Button exists.");
            IWebElement SelectColumnsButtonGraphic = this.SelectColumnsOptionnButton.FindElement(By.XPath(".//*[local-name()='svg'][contains(@class,'three-columns')]"), 1);
            return SelectColumnsButtonGraphic != null;
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

        public bool ClickSaveReportOptionButton()  
        {
            IWebElement SaveReportOptionButton = this.FindElement(By.XPath(".//div[@class='col']//button[contains(@data-bind,'showSaveReport')]"), 2);
            return SaveReportOptionButton.TryClick();
        }

        public void EnterCurrentPageValue(string value)
        {
            IWebElement currentPageEl = this.ProductsTableFooter.FindElement(By.XPath(".//input[@class='ui-pg-input form-control']"), 2);
            currentPageEl.ClearTextBox();
            currentPageEl.EnterText(value);
            currentPageEl.SendKeys(Keys.Enter);
        }

        public bool ClickOpenReportOptionButton()
        {
            IWebElement openReportOptionButton = this.FindElement(By.XPath(".//div[@class='col']//button[contains(@data-bind,'showOpenReport')]"), 2);
            return openReportOptionButton.TryClick();
        }

        public bool CheckAllProductsDoesContainGivenOptionInActionsColumn(string value)
        {
            List<IWebElement> rows = this.ProductRows;
            if (rows.IsNullOrEmpty())
            {
                Report.Failure("There was no product rows found in the grid");
                return false;
            }
            bool textNotFound = false;
            int i = 1;
            foreach (var item in rows)
            {
                IWebElement wantedColum = item.FindElement(By.XPath(".//td[@aria-describedby='dataGrid_ACTIONS']']"), 2);
                List<IWebElement> actionsOptionsEl = wantedColum.FindElements(By.XPath(".//a"), 2).ToList();
                bool optionNotFound = false;
                foreach (var option in actionsOptionsEl)
                {
                    Report.Info($"Current Option Text Is: {option.Text}");

                    if (option.Text != value)
                    {
                        Report.Info($"The Text: '{value}' was not found for row: {i}");
                        optionNotFound = true;

                    }
                }
                if (optionNotFound == true)
                {
                    Report.Info($"The text: '{value}' was not found in row: {i}");
                    textNotFound = true;
                }
                i++;

            }
            return textNotFound;
        }

        public bool CheckAllProductsDoNotContainGivenOptionInActionsColumn(string value)
        {
            List<IWebElement> rows = this.ProductRows;
            if (rows.IsNullOrEmpty())
            {
                Report.Failure("There was no product rows found in the grid");
                return false;
            }
            bool textNotFound = true;
            int i = 1;
            foreach (var item in rows)
            {
                IWebElement wantedColum = item.FindElement(By.XPath(".//td[@aria-describedby='dataGrid_ACTIONS']"), 2);
                List<IWebElement> actionsOptionsEl = wantedColum.FindElements(By.XPath(".//a"), 2).ToList();
                bool optionNotFound = true;
                foreach (var option in actionsOptionsEl)
                {
                    Report.Info($"Current Option Text Is: {option.Text}");

                    if (option.Text == value)
                    {
                        Report.Info($"The Text: '{value}' was found for row: {i}");
                        optionNotFound = false;

                    }
                }
                if (optionNotFound == false)
                {
                    Report.Info($"The text: '{value}' was found in row: {i}");
                    textNotFound = false;
                }
                i++;

            }
            return textNotFound;
        }

        public bool IConfirmTheColumnNameISelectedAndSavedAs_IsDisplayedNextToTheActionsColumn(string columnName)
        {
            IWebElement columnNextToActionsColumn = this.FindElement(By.XPath(".//div[@class='ui-jqgrid-hdiv ui-state-default ui-corner-top']//th[@id='dataGrid_ACTIONS']/preceding-sibling::th[1]//span[@title]"), 2);
            string test = columnNextToActionsColumn.Text;
            return columnNextToActionsColumn.Text.Trim() == columnName.Trim();
        }

        public bool ConfirmTableGraphicIsNextToSelectColumnsButton()
        {
            IWebElement tableIcon = this.FindElement(By.XPath(".//button[@data-bind='click: selectCols']//*[@class='bi bi-layout-three-columns']"), 2);
            return tableIcon != null;
        }
        public bool ConfirmColumnSelectorsPopupIsOrIsNotDisplayed()
        {
            IWebElement SelectorPopup = this.ContainerElement.FindElement(By.XPath(".//div[@class='modal fade columnsSelectorDialog show']"), 2);
            return SelectorPopup != null;
        }

        public bool IConfirmTheColumnSelectorPopupDisplaysTheFollowingTitleColumnsSelector(string popupTitle)
        {
            IWebElement headerTitle = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath(".//div[@class='modal fade columnsSelectorDialog show']//div[@class='modal-header']//h5[@data-bind='text: title']"), 2);
            return headerTitle.Text.Trim() == popupTitle.Trim();
        }

        public bool ConfirmColumnSelectorsPopupDisplaysAnXIcon()
        {
            IWebElement XIcon = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath(".//div[@class='modal fade columnsSelectorDialog show']//span[text()='×']"), 2);
            return XIcon != null;
        }
        public bool IConfirmTheColumnSelectorPopupDisplaysAColumnSelectorList()
        {
            IWebElement columnSelectorList = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath(".//div[@class='modal fade columnsSelectorDialog show']//div[@class='modal-body']//ul[@id='sortableColumnSelector']"), 2);
            return columnSelectorList != null;
        }


        public bool IConfirmTheColumnSelectorPopupDisplaysOrMoreEntries()
        {
            IList<IWebElement> columnSelectorList = this.ContainerElement.FindElements(By.XPath(".//div[@class='modal fade columnsSelectorDialog show']//div[@class='modal-body']//ul[@id='sortableColumnSelector']//li"), 2).ToList();
            return columnSelectorList.Count() > 0;
        }
        public bool IConfirmTheColumnSelectorPopupDisplaysAHamburgerIconNextToEachEntry()
        {
            IList<IWebElement> columnSelectorList = this.ContainerElement.FindElements(By.XPath(".//div[@class='modal fade columnsSelectorDialog show']//div[@class='modal-body']//ul[@id='sortableColumnSelector']//li"), 2).ToList();
            foreach (IWebElement el in columnSelectorList)
            {
                IWebElement columnSelectorItem = el.FindElement(By.XPath(".//span[@class='px-2 py-0 d-inline handle ui-sortable-handle']"), 2);
                if (columnSelectorItem == null)
                {
                    return false;
                }
            }
            return true;
        }
        public bool IConfirmTheColumnSelectorPopupDisplaysAnXIconNextToEachEntry()
        {
            IList<IWebElement> columnSelectorList = this.ContainerElement.FindElements(By.XPath(".//div[@class='modal fade columnsSelectorDialog show']//div[@class='modal-body']//ul[@id='sortableColumnSelector']//li"), 2).ToList();
            foreach (IWebElement el in columnSelectorList)
            {
                IWebElement columnSelectorItem = el.FindElement(By.XPath(".//i[@class='fa fa-remove fa-lg']"), 2);
                if (columnSelectorItem == null)
                {
                    return false;
                }
            }
            return true;
        }
        public bool IConfirmTheColumnSelectorPopupDisplaysAnAddColumnButtonAtTheBottom()
        {
            IWebElement columnSelectorList = this.ContainerElement.FindElement(By.XPath(".//div[@class='modal fade columnsSelectorDialog show']//div[@class='modal-body']//a[@data-bind='click: $data.add.bind($data)']"), 2);
            return columnSelectorList != null;
        }
        public bool IConfirmTheColumnSelectorPopupDisplaysTheFollowingButtons(Table table)
        {
            IList<IWebElement> columnSelectorList = this.ContainerElement.FindElements(By.XPath(".//div[@class='modal fade columnsSelectorDialog show']//div[@class='modal-footer']//div[@data-bind='with: model']//button"), 2).ToList();
            foreach (IWebElement el in columnSelectorList)
            {
                bool buttonFound = false;

                foreach (TableRow row in table.Rows)
                {

                    if (el.Text == row["Button"])
                    {
                        buttonFound = true;
                        break;
                    }

                }

                if (buttonFound == false)
                {
                    return false;
                }
            }
            return true;
        }

        public bool InTheColumnSelectorPopupIClickClose()
        {
            IWebElement closeButton = this.ContainerElement.FindElement(By.XPath("//div[@class='modal fade columnsSelectorDialog show']//div[@class='modal-header']//button[@data-dismiss='modal']"), 2);
            return closeButton.TryClick();
        }
        public bool IConfirmISeeANewRowAtTheBottomOfTheColumnSelectorPopup()
        {
            IWebElement emptyColumn = this.containerElement.FindElement(By.XPath(".//span[@class='select2-selection__placeholder']"), 2);
            return emptyColumn != null;
        }
        public bool InTheProductLookUpPageIClickExportButton()
        {
            return ExportOptionButton.TryClick();
        }

        public IWebElement GetRowByWPSID(string ID)
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
                string column = "PRODINFO";
                IWebElement wantedColumn = item.FindElement(By.XPath($".//td[contains(@aria-describedby,'dataGrid_PRODINFO')]/span[2]')]"), 2);
                var wantedColumnData = wantedColumn.GetTextContent();
                wantedColumnData = wantedColumnData.Substring(6, wantedColumnData.Length-7);
                if (wantedColumnData == null)
                {
                    Report.Error($"Did not find the element for Column: {column}");
                    return null;
                }
                if (wantedColumnData.Contains(ID))
                {
                    Report.Info($"Found the row with expected ID");
                    return item;
                }
            }
            Report.Info("Did not find the row with the expected ID");
            return null;
        }

        public string GetColumValueByWPSID(string column, string iD)
        {
            if (column == "Prod Info")
            {
                column = column.Replace(" ", "");
            }
            var wantedRow = this.GetRowByWPSID(iD);
            IWebElement wantedColumn = wantedRow.FindElement(By.XPath($".//td[contains(@aria-describedby,'dataGrid_{column}')]"), 2);
            return wantedColumn.Text;
        }

        public class ProductLookupData
        {

            public string ProductNumber { get; set; }

            public string ProductName { get; set; }

            public string SupplierName { get; set; }

            public string RecommendedUsageCategoryCode { get; set; }

            public string RecommendedUse { get; set; }


            public string UPC { get; set; }

            public override bool Equals(object obj)
            {
                var other = obj as ProductLookupData;

                if (other == null)
                    return false;

                if (ProductNumber != other.ProductNumber || ProductName != other.ProductName || SupplierName != other.SupplierName || RecommendedUsageCategoryCode != other.RecommendedUsageCategoryCode || RecommendedUse != other.RecommendedUse || UPC != other.UPC)
                {

                    Report.Info("The two sets of recent  product data did not match");
                    return false;
                }

                return true;
            }

        }

        public ProductLookupData GetProductLookupDataByID(string iD)
        {
            ProductLookupData currentRecentData = new ProductLookupData();
            currentRecentData.ProductNumber = iD;
            currentRecentData.ProductName = this.GetColumValueByWPSID("Prod Info", iD);
            currentRecentData.SupplierName = this.GetColumValueByWPSID("Prod Info", iD);
            currentRecentData.UPC = this.GetColumValueByWPSID("Prod Info", iD);
            currentRecentData.RecommendedUsageCategoryCode = this.GetColumValueByWPSID("Recommended Usage Category Code", iD);
            currentRecentData.RecommendedUse = this.GetColumValueByWPSID("Recommended Use", iD);
            return currentRecentData;

        }

        public bool InTheProductLookUpSearchProduct(string text)
        {
            IWebElement searchField = this.FindElement(By.XPath("//input[contains(@data-bind,'textInput: searchText')]"), 2);
             return searchField.TryEnterText(text);
        }
        public bool MainPageBodyDisplayed()
        {
            IWebElement mainPageBody = this.FindElement(By.XPath("//div[contains(@id,'supertable_main')]"), 2);
            return mainPageBody.Displayed;
        }

        public string TakeNoteOfUPCNumber(string savedAs)
        {
            IWebElement upcNumber = this.FindElement(By.XPath("//span[contains(text(), 'UPC')]"), 1);
            string number = upcNumber.Text;
            number = number.Substring(4);
            return number;
        }

        public string TakeNoteOfWPSIDNumber(string savedAs)
        {
            IWebElement wpsidNumber = this.FindElement(By.XPath("//span[contains(text(), 'WPSID')]"), 1);
            string number = wpsidNumber.Text;
            number = number.Substring(7);
            return number;
        }

        public string TakeNoteOfFirstFourDigitsOfUPCNumber(string savedAs)
        {
            IWebElement upcNumber = this.FindElement(By.XPath("//span[contains(text(), 'UPC')]"), 1);
            string number = upcNumber.Text;
            number = number.Substring(4,8);
            return number;
        }

        public string TakeNoteOfProductName(string savedAs)
        {
            IWebElement productName = this.FindElement(By.XPath("//table[@id ='dataGrid']//tr[@role ='row']//td/strong"), 1);
            string name = productName.Text;
            return name;
        }

        public void InTheProductLookUpSearchProductAndClickEnter(string text)
        {
            IWebElement searchField = this.FindElement(By.XPath("//input[contains(@data-bind,'textInput: searchText')]"), 2);
            searchField.TryEnterText(text);
            searchField.SendKeys(Keys.Enter);
        }
        public bool GetSearchFieldValue(string expectedText)
        {
            IWebElement searchField = this.FindElement(By.XPath("//input[contains(@data-bind,'textInput: searchText')]"), 2);
            string a = searchField.GetAttribute("value");
            Report.Info(a);

            return searchField.GetAttribute("value") == expectedText;
        }


        public bool InTheProductLookUpIConfirmTrendGraphicsShowFigure()
        {
            IWebElement card = this.FindElement(By.XPath($"//div[@class='card']"), 2);
            string cardText = card.Text;
            return cardText.Contains("%");

        }

        

        #endregion

        public class ColumnSelectorPopup : SeleniumBaseObject
        {
            protected override By ContainerElementLocator => By.XPath("//div[contains(@class, 'modal fade')][contains(@style,'display: block')]");

            public bool IClickTheAddColumnButtonInTheColumnSelectorPopup()
            {
                IWebElement addColumn = this.ContainerElement.FindElement(By.XPath(".//div[@class='modal-body']//a[@data-bind='click: $data.add.bind($data)']"), 2);
                return addColumn.TryClick();
            }
            public bool ISelectTheFirstOptionInTheNarrowedListInTheColumnSelectorPopup()
            {
                IList<IWebElement> optionsList = this.ContainerElement.FindElements(By.XPath("//ul[@class='select2-results__options']//li"), 2).ToList();
                return optionsList[0].TryClick();
            }

            public bool IConfirmISeeTheBreadcrumbsAreaUnderTheSearchField()
            {
                List<IWebElement> breadcrumbs = this.ContainerElement.FindElements(By.XPath(".//div[contains(@class, 'breadcrumbs')]//span"), 2).ToList();
                return breadcrumbs.Count > 0;
            }
            public bool IConfirmISeeANewRowAtTheBottomOfTheColumnSelectorPopup()
            {
                IWebElement emptyColumn = this.ContainerElement.FindElement(By.XPath(".//div[@class='modal-body']//span[@class='select2-selection__placeholder']"), 2);
                return emptyColumn != null;
            }
            public bool IClickOnTheNewRowAtTheBottomOfTheColumnSelectorPopup()
            {
                IWebElement emptyColumn = this.ContainerElement.FindElement(By.XPath(".//span[@class='select2-selection__placeholder']"), 2);
                return emptyColumn.TryClick();
            }

            public bool IConfirmTheNewRowAtTheBottomOfTheColumnSelectorPopupShowsTheDefaultTextSelectColumn(string defaultText)
            {
                IWebElement emptyColumn = this.ContainerElement.FindElement(By.XPath(".//span[@class='select2-selection__placeholder']"), 2);
                return emptyColumn.Text == defaultText;
            }

            public bool ISelectTheDropDownSelectorForTheNewRowAtTheBottomOfTheColumnSelectorPopup()
            {
                IWebElement dropdownArrow = this.ContainerElement.FindElement(By.XPath(".//span[@class='select2-selection__placeholder']/../following-sibling::span[@class='select2-selection__arrow']"), 2);
                return dropdownArrow.TryClick();
            }

            public bool IConfirmISeeAListOfAvailableColumnsInTheDropdownSelectorInColumnSelectorPopup()
            {
                IList<IWebElement> optionsList = SeleniumWebDriver.CurrentDriver.FindElements(By.XPath(".//ul[@class='select2-results__options']//li"), 2).ToList();
                return optionsList != null && optionsList.Count() > 0;
            }

            public bool ITypeTheFollowingIntoATextfieldForTheNewRowAtTheBottomOfTheColumnSelectorPopup(string text)
            {
                IWebElement textFieldEl = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath(".//ul[@class='select2-results__options']/../preceding-sibling::span//input"), 2);
                return textFieldEl.TryEnterText(text);
            }

            public bool ISelectTheFollowingAvailableColumnInTheDropdownSelectorInColumnSelectorPopup(string columnName)
            {
                IWebElement columnNameEl = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath(".//ul[@class='select2-results__options']//li[text()='" + columnName + "']"), 2);
                return columnNameEl.TryClick();
            }

            public bool IConfirmResetToDefaultIsDisplayedInTheSelectorColumnPopup()
            {
                IWebElement resetToDefaultButton = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath(".//div[@class='modal-footer']//button[contains(@data-bind,'click: $data.reset')]"), 2);
                return resetToDefaultButton.Displayed;
            }

            public bool IConfirmSelectorColumnPopupIsDisplayed()
            {
                IWebElement selectorColumnPopup = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath(".//div[@class='modal-content']//h3[text()='Column Editor']"), 2);
                return selectorColumnPopup.Displayed;
            }

            public List<string> IConfirm3PanelsIsDisplayedInSelectorColumnPopup()
            {
                IList<IWebElement> Panels = this.containerElement.FindElements(By.XPath(".//div[@class='modal-body']//div[@class='col-md-4']//h4"), 2);
                List<string> columnsShownNames = new List<string>();


                foreach (IWebElement el in Panels)
                {

                    columnsShownNames.Add(el.Text);

                }
                return columnsShownNames;
            }

            public bool IClickTheCloseButtonInTheSelectorColumnPopup()
            {
                IWebElement closeButton = this.ContainerElement.FindElement(By.XPath(".//div[@class='modal-footer']//button[@data-bind='click: applyChanges.bind($data)']/preceding-sibling::button[@data-dismiss='modal']"), 2);
                return closeButton.TryClick();
            }

            public int AppliedColumnsPanelCount()
            {
                IList<IWebElement> appliedColumnsPanel = this.ContainerElement.FindElements(By.XPath("//ul[@id='sortableColumnSelector']//li"), 2);
                return appliedColumnsPanel.Count();
                    
            }

            public bool ISelectCategoryFromFilterCategory(string category)
            {
                IWebElement filterCategory = this.ContainerElement.FindElement(By.XPath($"//span[contains(@data-bind ,'categoryLabel')][contains(text(),'{category}')]"), 2);
                return filterCategory.TryClick();

            }

            public string GetSelectedCategoryBackgroungColor(string category)
            {
                IWebElement backgroundEl = this.ContainerElement.FindElement(By.XPath($"//div[@class='list-select selected'][span[contains(@data-bind ,'categoryLabel')][contains(text(),'{category}')]]"), 2);
                if (backgroundEl == null)
                {
                    Report.Error("The Background El was null");
                    return null;
                }
                string rbgaCssValue = backgroundEl.GetCssValue("background-color");
                return rbgaCssValue;

            }

            public int FiltersInFiltersPanelCount()
            {
                IList<IWebElement> appliedColumnsPanel = this.ContainerElement.FindElements(By.XPath("//div[contains(@class,'list-select')]//span[@data-bind='text: desc']"), 2);
                return appliedColumnsPanel.Count();

            }

            public bool ISelectFilterFromFiltersPanel(string filter)
            {
                IWebElement filterCategory = this.ContainerElement.FindElement(By.XPath($"//div[contains(@class,'list-select')]//span[@data-bind='text: desc'][contains(text(),'{filter}')]"), 2);
                return filterCategory.TryClick();

            }

            public string GetSelectedFilterBackgroungColor(string filter)
            {
                IWebElement backgroundEl = this.ContainerElement.FindElement(By.XPath($"//div[contains(@class,'list-select selected')][span[@data-bind='text: desc'][contains(text(),'{filter}')]]"), 2);
                if (backgroundEl == null)
                {
                    Report.Error("The Background El was null");
                    return null;
                }
                string rbgaCssValue = backgroundEl.GetCssValue("background-color");
                return rbgaCssValue;

            }

            public bool IConfirmTheFilterAddedIsDisplayedInAppliedColumnPanel(string filter)
            {

                IWebElement filterinappliedcolumn = this.FindElement(By.XPath($"//ul[@id='sortableColumnSelector']//li//div//span[text()='{filter}']"), 1);
                return filterinappliedcolumn.NotNullAndDisplayed();
            }


            public bool IConfirmTheColumnNameISelectedAndSavedAs_IsDisplayed(string columnName)
            {

                IWebElement namedColumn = this.FindElement(By.XPath($".//div[@class='ui-jqgrid-hdiv ui-state-default ui-corner-top']//th[contains(normalize-space(),'{columnName}')]"),1);
                return namedColumn.NotNullAndDisplayed();
            }

            public bool IConfirmTheColumnNameISelectedAndSavedAsColumnNameIsDisplayedNextToTheActionsColumn(string columnName)
            {
                IWebElement finalColumn = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath("//div[@class='ui-jqgrid-hdiv ui-state-default ui-corner-top']//th//span[text()='Actions']/../../preceding-sibling::th[1]//div//span[text()='" + columnName + "']"), 2);
                return finalColumn != null;
            }
            public bool ConfirmColumnSelectorsPopupIsOrIsNotDisplayed()
            {
                IWebElement SelectorPopup = this.ContainerElement.FindElement(By.XPath(".//div[contains(@class,'modal-dialog')]"), 2);
                return SelectorPopup != null;
            }

            public List<string> GetColumnsShownNameListInSelectorPopup()
            {
                IList<IWebElement> ColumnsShown = SeleniumWebDriver.CurrentDriver.FindElements(By.XPath("//ul[@id='sortableColumnSelector']//li//span[@class='select2-selection__rendered'][@title]"), 2);
                List<string> columnsShownNames = new List<string>();

                foreach (IWebElement el in ColumnsShown)
                {
                    string test = el.Text;
                    columnsShownNames.Add(test);
                }

                return columnsShownNames;
            }
            
            public bool ConfirmColumnSelectorsPopupDisplaysAnXIcon()
            {
                IWebElement XIcon = this.ContainerElement.FindElement(By.XPath(".//div[@class='modal-header']//span[text()='×']"), 2);
                return XIcon != null;
            }
            public bool IConfirmTheColumnSelectorPopupDisplaysAColumnSelectorList()
            {
                IWebElement columnSelectorList = this.ContainerElement.FindElement(By.XPath(".//div[@class='modal-body']//ul[@id='sortableColumnSelector']"), 2);
                return columnSelectorList != null;
            }

            public bool IConfirmTheColumnSelectorPopupDisplaysOrMoreEntries()
            {
                IList<IWebElement> columnSelectorList = this.ContainerElement.FindElements(By.XPath(".//div[@class='modal-body']//ul[@id='sortableColumnSelector']//li"), 2).ToList();
                return columnSelectorList.Count() > 0;
            }

            public bool IConfirmTheColumnSelectorPopupDisplaysAHamburgerIconNextToEachEntry()
            {
                IList<IWebElement> columnSelectorList = this.ContainerElement.FindElements(By.XPath(".//div[@class='modal fade columnsSelectorDialog show']//div[@class='modal-body']//ul[@id='sortableColumnSelector']//li"), 2).ToList();
                foreach (IWebElement el in columnSelectorList)
                {
                    IWebElement columnSelectorItem = el.FindElement(By.XPath(".//span[@class='px-2 py-0 d-inline handle ui-sortable-handle']"), 2);
                    if (columnSelectorItem == null)
                    {
                        return false;
                    }
                }
                return true;
            }

            public bool IClickTheApplyButtonInTheSelectorColumnPopup()
            {
                IWebElement applyButton = this.ContainerElement.FindElement(By.XPath(".//div[@class='modal-footer']//button[@data-bind='click: applyChanges.bind($data)']"), 2);
                return applyButton.TryClick();
            }
            public bool IConfirmTheColumnSelectorPopupDisplaysAnXIconNextToEachEntry()
            {
                IList<IWebElement> columnSelectorList = this.ContainerElement.FindElements(By.XPath(".//div[@class='modal fade columnsSelectorDialog show']//div[@class='modal-body']//ul[@id='sortableColumnSelector']//li"), 2).ToList();
                foreach (IWebElement el in columnSelectorList)
                {
                    IWebElement columnSelectorItem = el.FindElement(By.XPath(".//i[@class='fa fa-remove fa-lg']"), 2);
                    if (columnSelectorItem == null)
                    {
                        return false;
                    }
                }
                return true;
            }
            public bool IConfirmTheColumnSelectorPopupDisplaysAnAddColumnButtonAtTheBottom()
            {
                IWebElement columnSelectorList = this.ContainerElement.FindElement(By.XPath(".//div[@class='modal-body']//a[@data-bind='click: $data.add.bind($data)']"), 2);
                return columnSelectorList != null;
            }
            public bool IConfirmTheColumnSelectorPopupDisplaysTheFollowingButtons(Table table)
            {
                IList<IWebElement> columnSelectorList = this.ContainerElement.FindElements(By.XPath(".//div[@class='modal fade columnsSelectorDialog show']//div[@class='modal-footer']//div[@data-bind='with: model']//button"), 2).ToList();
                foreach (IWebElement el in columnSelectorList)
                {
                    bool buttonFound = false;

                    foreach (TableRow row in table.Rows)
                    {

                        if (el.Text == row["Button"])
                        {

                            buttonFound = true;
                            break;
                        }

                    }
                    
                    if (buttonFound == false)
                    {
                        return false;
                    }
                }
                return true; ;
            }
            public bool InTheColumnSelectorPopupIClickClose()
            {
                IList<IWebElement> ColumnsShown = this.ContainerElement.FindElements(By.XPath(".//ul[@id='sortableColumnSelector']//li//span[@class='select2-selection__rendered'][@title]"), 2);
                List<string> columnsShownNames = new List<string>();

                foreach (IWebElement el in ColumnsShown)
                {
                    columnsShownNames.Add(el.Text);
                }
                IWebElement closeButton = this.ContainerElement.FindElement(By.XPath(".//div[@class='modal-header']//button[@data-dismiss='modal']"), 2);
                return closeButton.TryClick();
            }
            public bool InTheColumnSelectorPopupISelectHamBurger()
            {          
                IWebElement columnSelectorHamBurger = this.ContainerElement.FindElement(By.XPath("//*[@id='sortableColumnSelector']/li[1]/div/span[1]"), 2);
                return columnSelectorHamBurger.TryClick();
            
            }
            public void InTheColumnSelectorPopupPlaceTheColumnInNewPosition()
            {
                IWebElement firstColumn = this.ContainerElement.FindElement(By.XPath("//*[@id='sortableColumnSelector']/li[3]/div/span[1]"), 2);
                IWebElement secondColumn = this.ContainerElement.FindElement(By.XPath("//*[@id='sortableColumnSelector']/li[1]/div/span[1]"), 2);
                Actions actions = new Actions(SeleniumBrowser.WebBrowser);

          
                actions.MoveToElement(firstColumn);
                actions.ClickAndHold();

                actions.MoveToElement(secondColumn);
                actions.Release().Perform();

            }


        }


        public class ReportPopup : SeleniumBaseObject
        {
            protected override By ContainerElementLocator => By.XPath("//div[contains(@class, 'modal fade')][contains(@style,'display: block')]//div[contains(@class, 'content')]");

            public bool IConfirmTheSaveReportPopupDisplaysTheFollowingTitleSaveReport(string popupTitle)
            {
                IWebElement headerTitle = this.FindElement(By.XPath(".//div[@class='modal fade show']//div[@class='modal-header']//h3[@data-bind='text: title']"), 2);
                return headerTitle.Text.Trim() == popupTitle.Trim();
            }
 
            public bool InTheReportPopupEnterName(string text)
            {
                IWebElement nameField = this.FindElement(By.XPath(".//div[@class='modal fade show']//div[@class='modal-body']//div[contains(@class, 'col-sm-6')]//input[@id='reportName']"), 2);
                return nameField.TryEnterText(text);
            }

            public bool InTheSaveReportPopupClickSaveButton()
            {
                IWebElement saveButton = this.FindElement(By.XPath(".//div[@class='modal fade show']//div[@class='modal-footer']//button[contains(@data-bind, 'submitReport')]"), 2); 
                return saveButton.TryClick();
            }

            public bool InTheOpenReportPopupClickOpenButton()
            {
                IWebElement openButton = this.FindElement(By.XPath(".//div[@class='modal fade show']//div[@class='modal-footer']//button[contains(@data-bind, 'loadReport')]"), 2);
                return openButton.TryClick();
            }

            public bool InTheOpenReportPopupClickISelectReport(string reportName)
            {
                IWebElement report = this.FindElement(By.XPath($".//div[@class='modal fade show']//div[@class='modal-body']//tr//td[contains(text(), '{reportName}')] "), 2);
                return report.TryClick();
            }

            public bool InTheOpenReportPopupVerifyReportNameIsDisplayed(string reportName)
            {
                IWebElement report = this.FindElement(By.XPath($".//div[@class='modal fade show']//div[@class='modal-body']//tr//td[contains(text(), '{reportName}')] "), 2);
                return report != null;
            }


        }



    }


}





