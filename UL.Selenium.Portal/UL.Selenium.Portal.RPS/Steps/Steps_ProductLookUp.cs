using System.Collections.Generic;
using Reqnroll;
using UL.Automation.Reporting.Functions;
using UL.Automation.WebDriver.Classes;
using UL.Automation.ReqnrollHelpers.Classes;
using UL.Selenium.Portal.RPS.Classes;
using UL.Selenium.Portal.RPS.Selenium_Classes;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using Castle.Core.Internal;
using UL.Selenium.Portal.WERCSmart.Classes;
using NPOI.SS.Formula.Functions;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using GeneralUtilities = UL.Selenium.Portal.RPS.Classes.GeneralUtilities;

namespace UL.Selenium.Portal.RPS.Steps
{
	[Binding, Scope(Tag = "ProductLookUP")]
	class Steps_ProductLookUP
	{
		[StepDefinition(@"I confirm the Product Lookup tab has loaded")]
		[StepDefinition(@"I confirm the Product Lookup page refreshes")]
		public void HomeTabLoaded()
		{
			Report.IsTrue(new TopBar().WaitForContainerToBeVisible(), "Top bar did not load!");
			GeneralUtilities.WaitForLoadingToFinish();
			new ProductLookUp().WaitProductsGridSpinnerFinish();
			new Steps_Navigation().ConfirmActiveTab("Product Lookup");
			Report.IsTrue(new ProductLookUp().WaitForContainerToBeVisible(), "Dashboard content did not load", "Dashboard content loaded");
		}

		[StepDefinition(@"I enter Product ID: (.*) into the Product Lookup search box")]
		public void IEnterProductIDIntoProductLookup(string productID)
		{
			Report.Info($"Checking to see if Product ID contains 'ProductInformation'");
			if (productID.Contains("ProductInformation"))
			{
				Report.Info($"The Product ID contained 'ProductInformation', trying to get the ID from context");
				var savedInfo = (ProductData)Context.GetFromContext(productID);
				productID = savedInfo.ProductNumber;
			}
			new ProductLookUp().EnterSearchBoxText(productID);
			Report.IsTrue(new ProductLookUp().CheckSearchBoxContains(productID), "The Product Search Box did not contain the Product ID", "The Product Search Box contained the product ID");

		}
		[StepDefinition(@"I Check that only one Product Is present in the Products Grid with the ID: (.*)")]
		public void CheckProductsGridOnly1ProductWithID(string productID)
		{

			Report.IsTrue(new ProductLookUp().WaitProductsGridSpinnerFinish(), "The Spinner is still showing, the products grid has not loaded", "The products grid has loaded");
			Report.Info($"Checking to see if Product ID contains 'ProductInformation'");
			if (productID.Contains("ProductInformation"))
			{
				Report.Info($"The Product ID contained 'ProductInformation', trying to get the ID from context");
				var savedInfo = (ProductData)Context.GetFromContext(productID);
				productID = savedInfo.ProductNumber;
			}
			Report.Info($"Checking the number of products in the product grid");
			Report.IsTrue(new ProductLookUp().ProductsCount() == 1, "There was not just one product in the Grid", "There was only one product found in the Grid");
			Report.IsTrue(new ProductLookUp().FirstProductInGridID() == productID, "", "");

		}

		[StepDefinition(@"I Click the Row actions: (.*) for the first product in the Products Grid")]
		public void IClickRowActionForFirstProduct(string action)
		{
			Report.IsTrue(new ProductLookUp().ClickActionForFirstResultInGrid(action), "Failed to click the action for the first product", "Successfully clicked the action for the first product");
		}

		[StepDefinition(@"I confirm that the Product Lookup page buttons to the right of the search box are as follows:")]
		public void IConfirmThatThProductLookupPageButtonsAreAsFollows(Table table)
		{
			List<string> buttons = new List<string>();
			foreach (TableRow thisRow in table.Rows)
			{
				buttons.Add(thisRow["Buttons"]);
			}
			foreach (var button in buttons)
			{
				Report.IsTrue(new ProductLookUp().CheckProductLookUpButtonsListContains(button), "The button was not found in the list of buttons", "The button was found");
			}

		}

		[StepDefinition(@"In the product lookup page, I click the More Filters Button")]
		public void GivenInTheProductLookupPageIClickTheMoreFiltersButton()
		{
			Report.IsTrue(new ProductLookUp().ClickMoreFiltersOptionButton(), "Failed to click the more filters button", "Successfully clicked the more filters button");
		}
 
		[StepDefinition(@"I confirm that the Lookup Page bread crumb area contains the label: (.*)")]
		public void IConfirmThatTheProductLookupPageBreadCrumbAreaContainsLabel(string label)
		{

			Report.IsTrue(new ProductLookUp().ConfirmBreadCrumbAreaContainsLabel(label), "The Bread crumb area did not contain the label", "The bread crumb are contained the label");
		}

 
		[StepDefinition(@"In the product lookup Page, In the Products table I click the Reset Button")]
		public void InTheProductLookupPageInProductsTableIClickReset()
		{
			Report.IsTrue(new ProductLookUp().ClickResetButton(), "Failed to click reset", "Successfully clicked the reset button");
			this.HomeTabLoaded();
		}
 
        [StepDefinition(@"In the product lookup page, I confirm for all products the Action column (does|does not) include option: (.*)")]
        public void InTheProductLookUpPageIConfirmForAllProductsActionsColumnDoesOrDoesNotContainGivenOption(string doesOrDoesNot, string value)
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

        [StepDefinition(@"I click the Add Column button in the Column Selector popup")]
        public void ThenIClickTheAddColumnButtonInTheColumnSelectorPopup()
        {
            Report.IsTrue(new ProductLookUp.ColumnSelectorPopup().IClickTheAddColumnButtonInTheColumnSelectorPopup(), "Failed click the Add Column button", "Successfully clicked the Add Column button");
        }

        [StepDefinition(@"I confirm I see a new row at the bottom of the Column Selector popup")]
        public void ThenIConfirmISeeANewRowAtTheBottomOfTheColumnSelectorPopup()
        {
            Report.IsTrue(new ProductLookUp.ColumnSelectorPopup().IConfirmISeeANewRowAtTheBottomOfTheColumnSelectorPopup(), "Failed to find a new row", "Successfully found a new row");
        }

        [StepDefinition(@"I click on the new row at the bottom of the Column Selector popup")]
        public void ThenIClickOnTheNewRowAtTheBottomOfTheColumnSelectorPopup()
        {
            Report.IsTrue(new ProductLookUp.ColumnSelectorPopup().IClickOnTheNewRowAtTheBottomOfTheColumnSelectorPopup(), "Failed to click the new row", "Successfully clicked new row");
        }


        [StepDefinition(@"I confirm the new row at the bottom of the Column Selector popup shows the default text: (.*)")]
        public void ThenIConfirmTheNewRowAtTheBottomOfTheColumnSelectorPopupShowsTheDefaultTextSelectColumn(string defaultText)
        {
            Report.IsTrue(new ProductLookUp.ColumnSelectorPopup().IConfirmTheNewRowAtTheBottomOfTheColumnSelectorPopupShowsTheDefaultTextSelectColumn(defaultText), "Failed to confirm the new row shows the default text", "Successfully confirmed the new row shows the default text");
        }

        [StepDefinition(@"I select the drop down selector for the new row at the bottom of the Column Selector popup")]
        public void ThenISelectTheDropDownSelectorForTheNewRowAtTheBottomOfTheColumnSelectorPopup()
        {
            Report.IsTrue(new ProductLookUp.ColumnSelectorPopup().ISelectTheDropDownSelectorForTheNewRowAtTheBottomOfTheColumnSelectorPopup(), "Failed to select the dropdown selector for the new row", "Successfully selected the dropdown selector for the new row");
        }

        [StepDefinition(@"I confirm I (see|do not see) a list of available columns in the dropdown selector in Column Selector popup that contain the following text: (.*)")]
        public void ThenIConfirmISeeAListOfAvailableColumnsInTheDropdownSelectorInColumnSelectorPopupThatContainTheFollowingText(string seeOrDoNotSee, string text)
        {
            if (seeOrDoNotSee == "see")
            {
                Report.IsTrue(new ProductLookUp.ColumnSelectorPopup().IConfirmISeeAListOfAvailableColumnsInTheDropdownSelectorInColumnSelectorPopup(), "Failed to find a list of available columns", "Successfully found a list of available columns");
            }
            else
            {
                Report.IsTrue(new ProductLookUp.ColumnSelectorPopup().IConfirmISeeAListOfAvailableColumnsInTheDropdownSelectorInColumnSelectorPopup() == false, "Failed to not find a list of available columns", "Successfully didn't find a list of available columns");
            }
        }

        [StepDefinition(@"I type the following into a textfield for the new row at the bottom of the Column Selector popup: (.*)")]
        public void ThenITypeTheFollowingIntoATextfieldForTheNewRowAtTheBottomOfTheColumnSelectorPopup(string text)
        {
            Report.IsTrue(new ProductLookUp.ColumnSelectorPopup().ITypeTheFollowingIntoATextfieldForTheNewRowAtTheBottomOfTheColumnSelectorPopup(text), "Failed to type text into the new row", "Successfully typed the text into the new row");
        }


        [StepDefinition(@"I confirm I (see|do not see) a list of available columns in the dropdown selector in Column Selector popup")]
        public void ThenIConfirmISeeAListOfAvailableColumnsInTheDropdownSelectorInColumnSelectorPopup(string seeOrDoNotSee)
        {
            if (seeOrDoNotSee == "see")
            {
                Report.IsTrue(new ProductLookUp.ColumnSelectorPopup().IConfirmISeeAListOfAvailableColumnsInTheDropdownSelectorInColumnSelectorPopup(), "Failed to find a list of available columns", "Successfully found a list of available columns");
            }
            else
            {
                Report.IsTrue(new ProductLookUp.ColumnSelectorPopup().IConfirmISeeAListOfAvailableColumnsInTheDropdownSelectorInColumnSelectorPopup() == false, "Failed to not find a list of available columns", "Successfully didn't find a list of available columns");
            }
        }

        [StepDefinition(@"I select the following available column in the dropdown selector in Column Selector popup: (.*) and save as: (.*)")]
        public void ThenISelectTheFollowingAvailableColumnInTheDropdownSelectorInColumnSelectorPopupAndSaveAs(string columnName, string savedAs)
        {
            Report.IsTrue(new ProductLookUp.ColumnSelectorPopup().ISelectTheFollowingAvailableColumnInTheDropdownSelectorInColumnSelectorPopup(columnName), "Failed to select the following column: " + columnName, "Successfully selected the following column: " + columnName);
            Context.AddToContext(savedAs, columnName);
        }

        [StepDefinition(@"I click the Close button in the Selector Column popup")]
        public void ThenIClickTheCloseButtonInTheSelectorColumnPopup()
        {
            Report.IsTrue(new ProductLookUp.ColumnSelectorPopup().IClickTheCloseButtonInTheSelectorColumnPopup(), "Failed to click the Close button", "Successfully clicked the Close button");
        }
        /*
        [StepDefinition(@"I confirm the column name I selected and saved as: (.*) (is|is not) displayed next to the Actions column")]
        public void ThenIConfirmTheColumnNameISelectedAndSavedAsColumnNameIsDisplayedNextToTheActionsColumn(string savedAs, string isOrIsNot)
        {
            string columnName = Context.GetFromContext(savedAs).ToString();
            Report.Info("test: " + columnName);
            if (isOrIsNot == "is")
            {
                Report.IsTrue(new ProductLookUp.ColumnSelectorPopup().IConfirmTheColumnNameISelectedAndSavedAsColumnNameIsDisplayedNextToTheActionsColumn(columnName), "Failed to locate saved column", "Successfully located saved column");
            }
            else
            {
                Report.IsTrue(new ProductLookUp.ColumnSelectorPopup().IConfirmTheColumnNameISelectedAndSavedAsColumnNameIsDisplayedNextToTheActionsColumn(columnName) == false, "Failed to not locate saved column", "Successfully didn't locate saved column");

            }
        }
        */
        [StepDefinition(@"I confirm the column name I selected and saved as: (.*) (is|is not) displayed")]
        public void ThenIConfirmTheColumnNameISelectedAndSavedAs_IsDisplayed(string columnName, string isOrIsNot)
        {
            if (isOrIsNot == "is")
            {
                Report.IsTrue(new ProductLookUp.ColumnSelectorPopup().IConfirmTheColumnNameISelectedAndSavedAs_IsDisplayed(columnName), "Failed to confirm new column is displayed", "Successfully confirmed new column is displayed");
            } else
            {
                Report.IsTrue(new ProductLookUp.ColumnSelectorPopup().IConfirmTheColumnNameISelectedAndSavedAs_IsDisplayed(columnName) == false, "Failed to confirm new column is not displayed", "Successfully confirmed new column is not displayed");

            }
        }
        
        [StepDefinition(@"In the product lookup Page, In the Products table I click the Select Columns Button")]
        public void InTheProductLookupPageInProductsTableIClickSelectColumns()
        {
            Report.IsTrue(new ProductLookUp().ClickSelectColumnsButton(), "Failed to click select columns", "Successfully clicked the select columns button");
            this.HomeTabLoaded();
        }

        [StepDefinition(@"I confirm the Column Selector popup (is|is not) shown")]
        public void ThenIConfirmTheColumnSelectorPopupIsShown(string isOrIsNot)
        {
            if (isOrIsNot == "is")
            {
                Report.IsTrue(new ProductLookUp.ColumnSelectorPopup().ConfirmColumnSelectorsPopupIsOrIsNotDisplayed(), $"Failed to find the column selector popup", $"Successfully found the column selector popup");
            }
            else
            {
                Report.IsTrue(new ProductLookUp.ColumnSelectorPopup().ConfirmColumnSelectorsPopupIsOrIsNotDisplayed() == false, $"Failed to not find  the column selector popup", $"Successfully didn't find the column selector popup");
            }
        }

        [StepDefinition(@"I confirm the column name I selected and saved as: (.*) is displayed next to the Actions column")]
        public void ThenIConfirmTheColumnNameISelectedAndSavedAsColumnNameIsDisplayedNextToTheActionsColumn(string savedAs)
        {
            Report.IsTrue(new ProductLookUp().IConfirmTheColumnNameISelectedAndSavedAs_IsDisplayedNextToTheActionsColumn(savedAs), "Failed to locate saved column", "Successfully located saved column");
        }

        [StepDefinition(@"I click the Apply button in the Selector Column popup")]
        public void ThenIClickTheApplyButtonInTheSelectorColumnPopup()
        {
            Report.IsTrue(new ProductLookUp.ColumnSelectorPopup().IClickTheApplyButtonInTheSelectorColumnPopup(), "Failed to click the Apply button", "Successfully clicked the apply button");
            Delay.Seconds(10);
        }

        [StepDefinition(@"I save the order of the columns shown in the Column Selector Popup as: (.*)")]
        public void ISaveTheOrderOfTheColumnsShownInTheColumnSelectorPopupAs(string savedAs)
        {

            List<string> columnNamesList = new ProductLookUp.ColumnSelectorPopup().GetColumnsShownNameListInSelectorPopup();
            
            if (columnNamesList.Count != 0)
            {
                Report.Success("Successfully found list of column names in Column Selector Popup");
                Context.AddToContext(savedAs, columnNamesList);
            }
            else
            {
                Report.Success("Failed to find list of column names in Column Selector Popup");
            }
        }
        /*
        [StepDefinition(@"I confirm the column name I selected and saved as: (.*) is displayed")]
        public void ThenIConfirmTheColumnNameISelectedAndSavedAs_IsDisplayed(string savedAs)
        {
            string columnName = Context.GetFromContext(savedAs).ToString();
            Report.IsTrue(new ProductLookUp.ColumnSelectorPopup().IConfirmTheColumnNameISelectedAndSavedAs_IsDisplayed(columnName), "Failed to confirm new column is displayed", "Successfully confirmed new column is displayed");
        }
        */
        [StepDefinition(@"I confirm there is a table graphic next to the Select Columns button")]
        public void ThenIConfirmThereIsATableGraphicNextToTheSelectColumnsButton()
        {
            Report.IsTrue(new ProductLookUp().SelectColumnsButtonGraphicExists(), "Failed to find graohic on the Select Columns Button.", "Successfully found graphic on the Select Columns Button.");
        }
        
        [StepDefinition(@"I select the first option in the narrowed list in the Column Selector popup")]
        public void ThenISelectTheFirstOptionInTheNarrowedListInTheColumnSelectorPopup()
        {
            Report.IsTrue(new ProductLookUp.ColumnSelectorPopup().ISelectTheFirstOptionInTheNarrowedListInTheColumnSelectorPopup(), "Failed to select the first option", "Successfully selected the first option");
        }

        [StepDefinition(@"I confirm the Column Selector popup displays the following title: (.*)")]
        public void ThenIConfirmTheColumnSelectorPopupDisplaysTheFollowingTitleColumnsSelector(string popupTitle)
        {
            Report.IsTrue(new ProductLookUp().IConfirmTheColumnSelectorPopupDisplaysTheFollowingTitleColumnsSelector(popupTitle), $"Failed to find the following title in the column selector popup: " + popupTitle, $"Successfully found the following title in the column selector popup: " + popupTitle);
        }


        [StepDefinition(@"I confirm the Column Selector popup displays an x icon in the top right corner")]
        public void ThenIConfirmTheColumnSelectorPopupDisplaysAnXIconInTheTopRightCorner()
        {
            Report.IsTrue(new ProductLookUp.ColumnSelectorPopup().ConfirmColumnSelectorsPopupDisplaysAnXIcon(), $"Failed to find the x icon in the top right corner", $"Successfully found the x icon in the top right corner");
        }

        [StepDefinition(@"I confirm the Column Selector popup displays a column selector list")]
        public void ThenIConfirmTheColumnSelectorPopupDisplaysAColumnSelectorList()
        {
            Report.IsTrue(new ProductLookUp.ColumnSelectorPopup().IConfirmTheColumnSelectorPopupDisplaysAColumnSelectorList(), $"Failed to find the column selector list in the column selector popup", $"Successfully found the column selector list in the column seletor popup");
        }



        [StepDefinition(@"I confirm the Column Selector popup displays 1 or more entries")]
        public void ThenIConfirmTheColumnSelectorPopupDisplaysOrMoreEntries()
        {
            Report.IsTrue(new ProductLookUp.ColumnSelectorPopup().IConfirmTheColumnSelectorPopupDisplaysOrMoreEntries(), $"Failed to find 1 or more entries in the Column Selector popup", $"Successfully found 1 or more entries in the Column Selector popup");
        }

        [StepDefinition(@"I confirm the Column Selector popup displays a hamburger icon next to each entry")]
        public void ThenIConfirmTheColumnSelectorPopupDisplaysAHamburgerIconNextToEachEntry()
        {
            Report.IsTrue(new ProductLookUp.ColumnSelectorPopup().IConfirmTheColumnSelectorPopupDisplaysAHamburgerIconNextToEachEntry(), $"Failed to find the hamburger icon next to each entry", $"Successfully found the hamburger icon next to each entry");
        }

        [StepDefinition(@"I confirm the Column Selector popup displays an x icon next to each entry")]
        public void ThenIConfirmTheColumnSelectorPopupDisplaysAnXIconNextToEachEntry()
        {
            Report.IsTrue(new ProductLookUp.ColumnSelectorPopup().IConfirmTheColumnSelectorPopupDisplaysAnXIconNextToEachEntry(), $"Failed to find an ex icon next to each entry", $"Successfully found an x icon next to each entry");
        }

        [StepDefinition(@"I confirm the Column Selector popup displays an Add Column button at the bottom")]
        public void ThenIConfirmTheColumnSelectorPopupDisplaysAnAddColumnButtonAtTheBottom()
        {
            Report.IsTrue(new ProductLookUp.ColumnSelectorPopup().IConfirmTheColumnSelectorPopupDisplaysAnAddColumnButtonAtTheBottom(), $"Failed to find the Add Column button at the bottom of the popup", $"Successfully found the Add Column button at the bottom of the popup");
        }

        [StepDefinition(@"I confirm the Column Selector popup displays the following buttons:")]
        public void ThenIConfirmTheColumnSelectorPopupDisplaysTheFollowingButtons(Table table)
        {
            Report.IsTrue(new ProductLookUp.ColumnSelectorPopup().IConfirmTheColumnSelectorPopupDisplaysTheFollowingButtons(table), $"Failed to find all the buttons in the table", $"Successfully found all the bottom in the table");
        }

        [StepDefinition(@"In the Column Selector popup I click close")]
        public void ThenInTheColumnSelectorPopupIClickClose()
        {
            Report.IsTrue(new ProductLookUp.ColumnSelectorPopup().InTheColumnSelectorPopupIClickClose(), $"Failed to close the Column Selector popup", $"Successfully closed the Column Selector popup");
        }

        [StepDefinition(@"I confirm I (see|do not see) the breadcrumbs area under the search field")]
        public void GivenIConfirmISeeTheBreadcrumbsAreaUnderTheSearchField(string seeOrDoNotSee)
        {
            if (seeOrDoNotSee == "see")
            {
                Report.IsTrue(new ProductLookUp.ColumnSelectorPopup().IConfirmISeeTheBreadcrumbsAreaUnderTheSearchField(), $"Failed to find the breadcrumbs area", $"Successfully found the breadcrumbs area");
            }
            else
            {
                Report.IsTrue(new ProductLookUp.ColumnSelectorPopup().IConfirmISeeTheBreadcrumbsAreaUnderTheSearchField() == false, $"Failed to not find the breadcrumbs area", $"Successfully didn't find the breadcrumbs area");
            }
        }

        [StepDefinition(@"I confirm I (see|do not see) the bredcrumbs area under the search field")]
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
 
        [StepDefinition(@"In the Product Lookup Page, I save all the Results to context as: (.*)")]
        public void InTheProductLookUpPageInProductsTableISaveAllTheResultsToContextAs(string savedAs)
        {
            Report.IsTrue(new ProductLookUp().WaitProductsGridSpinnerFinish(), "The Spinner is still showing, the products grid has not loaded", "The products grid has loaded");
            var allFoundIds = new ProductLookUp().GetCurrentProductIDs();
            List<ProductLookUp.ProductLookupData> currentResults = new List<ProductLookUp.ProductLookupData>();

            foreach (var item in allFoundIds)
            {
                var items = item.Substring(6,item.Length-7);
                Report.Info($"Attempting to get and save the data for the result with ID:{items}");
                ProductLookUp.ProductLookupData currentData = new ProductLookUp().GetProductLookupDataByID(items);
                Report.Info("pasS7");
                currentResults.Add(currentData);
            }
            Report.Info($"All Results saved, saving the list to context as: {savedAs}");
            Context.AddToContext(savedAs, currentResults);
        }


        [StepDefinition(@"In the Product Lookup Page, I click the Export Button")]
        public void InTheProductLookUpPageIClickExportButton()
        {
            Report.IsTrue(new ProductLookUp().InTheProductLookUpPageIClickExportButton(), "Failed to click Export button", $"Successfully clicked on Export button");
        }

        [StepDefinition(@"In the product lookup Page, I confirm the Products shown in the export file saved as: (.*)  match the products saved as: (.*)")]
        public void InTheProductLookupPageIConfirmProductsInExportFileMatchSavedProducts(string fileSavedAs, string valuesSavedAs)
        {

            var savedProducts = (List<ProductLookUp.ProductLookupData>)Context.GetFromContext(valuesSavedAs);



            string File = Context.GetFromContext(fileSavedAs)?.ToString() ?? "";
            var lines = System.IO.File.ReadAllLines(File);



            List<string> foundProductIDs = new List<string>();
            List<string> previouslyCheckedUpcs = new List<string>();

            for (int i = 1; i < lines.Count(); i++)
            {
                // var lineValues = lines[i].Split(',');
                string[] lineValues = Regex.Matches(lines[i], @"(""[^""]*""|[^,])+").Cast<System.Text.RegularExpressions.Match>().Select(m => m.Value).ToArray();
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
                var productNumber = currentRowArray[2];
                var supplierName = currentRowArray[3];
                var recommendedUsageCategoryCode = currentRowArray[4];
                var recommendedUse = currentRowArray[5];



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
                    var wantedProduct = savedProducts.First(x => x.ProductNumber == productNumber);
                    Report.Info("Starting Product Checks");
                }
                catch
                {
                    Report.Failure($"The Product with ID: {productNumber} was not found in the list of saved products (was not in the grid)");
                }

                if (productFound == true)
                {
                    var wantedProduct = savedProducts.First(x => x.ProductNumber == productNumber);

                    Report.Info($"Saved product number: {wantedProduct.ProductNumber}");
                    Report.Info($"File product number: {productNumber}");
                    Report.IsTrue(wantedProduct.ProductNumber == productNumber, "The product number did not match", "The product number matched");

                    Report.Info($"Saved Product name: {wantedProduct.ProductName}");
                    Report.Info($"File Product name: {productName}");
                    Report.IsTrue(wantedProduct.ProductName == productName, "The Product name did not match", "The Product name matched");

                    Report.Info($"Saved UPC number(s): {string.Join(", ", wantedProduct.UPC)}");
                    Report.Info($"File UPC number: {upcNumbers}");
                    Report.IsTrue(wantedProduct.UPC.Contains(upcNumbers), "The UPC number did not match", "The UPC number matched");


                    Report.Info($"Saved Recommended Usage Category Code: {wantedProduct.RecommendedUsageCategoryCode}");
                    Report.Info($"File Recommended Usage Category Code: {recommendedUsageCategoryCode}");
                    var fileToDate = Convert.ToDateTime(recommendedUsageCategoryCode);
                    Report.IsTrue(wantedProduct.UPC.Contains(recommendedUsageCategoryCode), "The Recommended Usage Category Code did not match", "The Recommended Usage Category Code matched");

                    Report.Info($"Saved Recommended Use: {wantedProduct.RecommendedUse}");
                    Report.Info($"File Recommended Use: {recommendedUse}");
                    Report.IsTrue(wantedProduct.RecommendedUse == recommendedUse, "The Recommended Use did not match", "The Recommended Use matched");

                    Report.Info($"Saved Supplier Name: {wantedProduct.SupplierName}");
                    Report.Info($"File Supplier Name: {supplierName}");
                    Report.IsTrue(wantedProduct.SupplierName == supplierName, "The Supplier Name did not match", "The Supplier Name matched");

                    Report.Info($"Finished Checking Product");
                }



            }

            Report.Info($"There are no more products to check in the csv file");


            var allSavedProductIDs = new List<string>();
            foreach (var el in savedProducts)
            {
                allSavedProductIDs.Add(el.ProductNumber);
            }

            var differences = allSavedProductIDs.Except(foundProductIDs);


            Report.IsTrue(differences.IsNullOrEmpty(), "There was additional products found in the grid that were not in the file (accounting for mulitple UPCs)", "There was no additional products found in the grid that were not in the file (accounting for mulitple UPCs)");


        }

        
        [StepDefinition(@"I Enter WPS ID : (.*) in Search field")]
        [StepDefinition(@"I Enter Product ID : (.*) in Search field")]
        [StepDefinition(@"I Enter Product Name : (.*) in Search field")]
        public void InTheProductLookUpSearchtheProduct(string text)
        {
            Report.IsTrue(new ProductLookUp().InTheProductLookUpSearchProduct(text), "Failed to search the product", $"Successfully searched the product");
        }

        [StepDefinition(@"I save the order of the columns shown in the Product Table as: (.*)")]
        public void ISaveTheOrderOfTheColumnsShownInTheProductTableAs(string savedAs)
        {
            List<string> columnNamesList = new ProductLookUp().GetColumnsShownNameListInProductTable();
            if (columnNamesList.Count != 0)
            {
                Report.Success("Successfully found list of column names in Column Selector Popup");
                Context.AddToContext(savedAs, columnNamesList);
            }
            else
            {
                Report.Success("Failed to find list of column names in Column Selector Popup");
            }
        }
        [StepDefinition(@"I confirm columns shown in the Column Selector Popup: (.*) match with columns shown in the Product Table: (.*)")]
        
        public void IMatchTheColumnOrders(string productTable, string columnSelector)
        {
            List<string> ProductTableColumnNamesList = new ProductLookUp().GetColumnsShownNameListInProductTable();
            List<string> ColumnSelectorColumnNamesList =  (List<string>)Context.GetFromContext(columnSelector);
            bool ColumnsareTheSame = ColumnSelectorColumnNamesList.SequenceEqual(ProductTableColumnNamesList);
            Report.IsTrue(ColumnsareTheSame, "ProductTableColumnNames and ColumnSelectorColumnNames does not match", " Successfully ProductTableColumnNames and ColumnSelectorColumnNames matched");
        }
        [StepDefinition(@"I use mouse to select the hamburger icon for the column name: (.*)")]

        public void IIuseMouseToSelectHamburgerIcon(string columnName)
        {
            Report.IsTrue( new ProductLookUp.ColumnSelectorPopup().InTheColumnSelectorPopupISelectHamBurger(),"Failed to use mouse","Sucessfully used mouse");
        }
        [StepDefinition(@"I use mouse to place the coluum: (.*) into a new position in the list")]

        public void IuseMouseToPlaceTheColumnInNewPosition(string columnName)
        {
            
            Report.Info("Attempting to place the column in new position");
            new ProductLookUp.ColumnSelectorPopup().InTheColumnSelectorPopupPlaceTheColumnInNewPosition();
            
        }
        [StepDefinition(@"I confirm below the menu links banner I see the Product Lookup main page body")]

        public void IconfirmProductLookupMainBodyIsDisplayed()
        {

            Report.IsTrue(new ProductLookUp().MainPageBodyDisplayed(), "The main page body is not present", "The main page body is present");

        }
        [StepDefinition(@"I confirm the Product Lookup background color is: grey")]

        public void ConfirmProductLookupBackgroundColorIsGrey()
        {

            string expectedColorString = "rgba(248, 248, 248, 1)";
            Report.Info($"The expected rbga color for the background is: {expectedColorString}");
            string foundColorCode = new ProductLookUp().GetRecentActivitiesBackgroundColor();
            Report.Info($"The found rbga color for the background is: {foundColorCode}");
            Report.IsTrue(expectedColorString == foundColorCode, "The found color was not as expected", "The color found was as expected");

        }

        [StepDefinition(@"I confirm the Product Lookup Text color is: darker grey")]

        public void ConfirmProductLookupTextColorIsGrey()
        {

            string expectedColorString = "rgba(0, 0, 0, 1)";
            Report.Info($"The expected rbga color for the text is: {expectedColorString}");
            string foundColorCode = new ProductLookUp().GetRecentActivitiesTextColor();
            Report.Info($"The found rbga color for the text is: {foundColorCode}");
            Report.IsTrue(expectedColorString == foundColorCode, "The found color was not as expected", "The color found was as expected");

        }

        [StepDefinition(@"I confirm the Product Lookup search box is shown")]

        public void ConfirmProductLookupSearchBoxIsPresent()
        {
            Report.IsTrue(new ProductLookUp().SearchBoxPresent(), "The search box was not present", "The search box was present");
        }

        [StepDefinition(@"I confirm that the Product Lookup search box place holder text reads: (.*)")]

        public void IConfirmThatProductLookupSearchBoxPlaceHolderTextReads(string placeholderText)
        {
            Report.IsTrue(new ProductLookUp().SearchBoxPlaceHolderText() == placeholderText, "The place holder text did not match the expected", "The place holder text was as expected");
        }

        [StepDefinition(@"In the Product Lookup page I confirm to the right of the buttons I do not see three trends")]

        public void GivenInThProductLookupPageIConfirmToTheRightOfTheButtonsIDoNotSeeThreeTrends(Table table)
        {
            Report.IsTrue(new NavBar().InProductLookupIConfirmTheFollowingTrendsAreNotDisplayed(table), "Failed to find all three trends", "Successfully found all three trends");
        }
      

        [StepDefinition(@"I Check that the Product Lookup Products Table is showing")]

        public void CheckProductLookupProductsTable()
        {
            Report.IsTrue(new ProductLookUp().ProductTableIsPresent(), "The products table is not showing", "The products table is showing");
        }

        [StepDefinition(@"I confirm that the  Product Lookup page headings row has a grey background color")]

        public void IConfirmThatProductLookupPageHeadingsShowGrey()
        {
            string expectedColorString = "rgba(0, 0, 0, 0)";
            Report.Info($"The expected rbga color for the text is: {expectedColorString}");
            string foundColorCode = new ProductLookUp().GetHeadingsRowBackgroundColor();
            Report.IsTrue(expectedColorString == foundColorCode, "The found color was not as expected. Actually found: " + foundColorCode, "The color found was as expected");

        }      

        [StepDefinition(@"In the Product Lookup page, I confirm that the main table shows data rows")]

        public void InTheProductLookupPageIConfirmThatTableShowsDataRows()
        {
            int rowCount = new ProductLookUp().ProductsCount();
            Report.IsTrue(rowCount > 0, "Data Rows were not showing", "Data Rows were showing");

        }

        [StepDefinition(@"In the Product Lookup page, below the Product Lookup table I confirm: page footer is shown")]

        public void InTheProductLookupPageICheckThatTheTableFooterIsShown()
        {
            Report.IsTrue(new ProductLookUp().ProductsGridFooterPresent(), "The table footer was not shown", "The table footer was shown");
        }

        [StepDefinition(@"In the Product Lookup page, I confirm that the main table does not show data rows")]

        public void InTheProductLookupPageIConfirmThatTableDoesNotShowDataRows()
        {
            int rowCount = new ProductLookUp().ProductsCount();
            Report.IsTrue(rowCount == 0, "Data Rows are showing", "Data Rows are not showing");
        }

        [StepDefinition(@"I confirm the product I searched for is shown with the ID: (.*)")]
        public void CheckProductsGridDisplaysProductWithID(string productID)
        {

            Report.IsTrue(new ProductLookUp().WaitProductsGridSpinnerFinish(), "The Spinner is still showing, the products grid has not loaded", "The products grid has loaded");
            Report.Info($"Checking to see if Product ID contains 'ProductInformation'");
            if (productID.Contains("ProductInformation"))
            {
                Report.Info($"The Product ID contained 'ProductInformation', trying to get the ID from context");
                var savedInfo = (ProductData)Context.GetFromContext(productID);
                productID = savedInfo.ProductNumber;
            }
            Report.Info($"Checking the number of products in the product grid");
            Report.IsTrue(new ProductLookUp().ProductsCount() == 1, "There was not just one product in the Grid", "There was only one product found in the Grid");
            Report.IsTrue(new ProductLookUp().GetSearchedProductInGridByID() == productID, "Product Number searched for is not displayed", "Product Number searched for is displayed successfully");

        }

        [StepDefinition(@"I confirm the product I searched for is shown: (.*)")]
        public void CheckProductsGridDisplaysProductISearched(string productName)
        {

            Report.IsTrue(new ProductLookUp().WaitProductsGridSpinnerFinish(), "The Spinner is still showing, the products grid has not loaded", "The products grid has loaded");
            Report.Info($"Checking to see if Product ID contains 'ProductInformation'");
            if (productName.Contains("ProductInformation"))
            {
                Report.Info($"The Product name contained 'ProductInformation', trying to get the Name from context");
                var savedInfo = (ProductData)Context.GetFromContext(productName);
                productName = savedInfo.ProductName;
            }  
            Report.IsTrue(new ProductLookUp().GetSearchedProductInGridByName().Contains(productName), "Product Name searched for is not displayed", "Product Name searched for is displayed successfully");

        }


        [StepDefinition(@"Select any UPC shown on the page and save as: (.*)")]
        public void SelectAnyUPCAndSaveTheNumber(string savedAs)
        {
            string upcNumber = new ProductLookUp().TakeNoteOfUPCNumber(savedAs);
            Context.AddToContext(savedAs, upcNumber);
        }

        [StepDefinition(@"I Enter UPC Number : (.*) in Search field")]
        public void InTheProductLookUpSearchtheProductByUPCNumber(string savedAs)
        {
            string upcNumber = new ProductLookUp().TakeNoteOfUPCNumber(savedAs);
            var savedpUpcNumber = Context.GetFromContext(savedAs).ToString();

            Report.IsTrue(new ProductLookUp().InTheProductLookUpSearchProduct(savedpUpcNumber), "Failed to search the product", $"Successfully searched the product");

        }

        [StepDefinition(@"I confirm the UPC I saved: (.*) is shown in Product Table")]
        public void InTheProductLookUpSeartheProductByUPCNumber(string savedAs)
        {
            string upcNumber = new ProductLookUp().TakeNoteOfUPCNumber(savedAs);
            var savedpUpcNumber = Context.GetFromContext(savedAs).ToString();

            Report.IsTrue(new ProductLookUp().InTheProductLookUpSearchProduct(savedpUpcNumber), "Failed to search the product", $"Successfully searched the product");

            Report.IsTrue(new ProductLookUp().WaitProductsGridSpinnerFinish(), "The Spinner is still showing, the products grid has not loaded", "The products grid has loaded");

            Report.IsTrue(new ProductLookUp().GetSearchedProductInGridByUPC() == savedpUpcNumber, "UPC Number searched for is not displayed", "UPC Number searched for is displayed successfully");
        }

        [StepDefinition(@"Select first 4 digits of UPC  shown on the page and save as: (.*)")]
        public void SelectFirstFourDigitsOfUPCAndSaveTheNumber(string savedAs)
        {
            string upcNumber = new ProductLookUp().TakeNoteOfFirstFourDigitsOfUPCNumber(savedAs);
            Context.AddToContext(savedAs, upcNumber);
        }

        [StepDefinition(@"I Enter first 4 digits of UPC Number : (.*) in Search field")]
        public void InTheProductLookUpSearchtheProductByPartialUPCNumber(string savedAs)
        {
            string upcNumber = new ProductLookUp().TakeNoteOfFirstFourDigitsOfUPCNumber(savedAs);
            var savedpUpcNumber = Context.GetFromContext(savedAs).ToString();

            Report.IsTrue(new ProductLookUp().InTheProductLookUpSearchProduct(savedpUpcNumber), "Failed to search the product", $"Successfully searched the product");
            Report.IsTrue(new ProductLookUp().GetSearchedProductInGridByID() == savedpUpcNumber, "Product Number searched for is not displayed", "Product Number searched for is displayed successfully");

        }


        [StepDefinition(@"I confirm the UPC Number I saved: (.*) is shown in Product Table")]
        public void InTheProductLookUpSearchTheProductByUPCNumberOrWPSOrSupplierName(string savedAs)
        {
            Report.IsTrue(new ProductLookUp().SearchMatchWithUPC(savedAs), "UPC Number searched for is not displayed", "UPC Number searched for is displayed successfully");

        }

        [StepDefinition(@"In the search field enter a product ID, product name or UPC and click Enter button: (.*)")]
        public void InTheProductLookUpSearchtheProductAndClickEnter(string text)
        {
            Report.Info("Attempting to Enter the product ID");
            new ProductLookUp().InTheProductLookUpSearchProductAndClickEnter(text);
        }

        [StepDefinition(@"I confirm the trends graphics do show the % figure")]
        public void InTheProductLookUpIConfirmTrendGraphicsShowFigure()
        {
            Report.IsTrue(new ProductLookUp().InTheProductLookUpIConfirmTrendGraphicsShowFigure(), "Trend Graphics does not show % figure", "Trend Graphics displays % figure");
        }

        [StepDefinition(@"I confirm the trends graphics (shows|do not show) the % figure")]
        public void InTheProductLookUpIConfirmTrendGraphicsShowFigure(string seeOrDoesNotSee)
        {
            if (seeOrDoesNotSee == "show")
            {
                Report.IsTrue(new ProductLookUp().InTheProductLookUpIConfirmTrendGraphicsShowFigure(), "Trend Graphics does not show % figure", "Trend Graphics displays % figure");
            }
            else if (seeOrDoesNotSee == "do not show")
            {
                Report.IsFalse(new ProductLookUp().InTheProductLookUpIConfirmTrendGraphicsShowFigure(), "Trend Graphics shows % figure", "Trend Graphics does not display % figure");
            }


        }

        [StepDefinition(@"I save the Product Name shown for the product as: (.*) I am working with")]
        public void SaveTheProductname(string savedAs)
        {
            string productName = new ProductLookUp().TakeNoteOfProductName(savedAs);
            Context.AddToContext(savedAs, productName);
        }

        [StepDefinition(@"I confirm that the UPC name saved: (.*) is shown in Product Information pop up")]
        public void InTheProductInformationUPCNameisDisplayedSameAsSavedValue(string savedAs)
        {
            string upcName = new ProductLookUp().TakeNoteOfProductName(savedAs);
            Report.Info(upcName);
            var savedpUpcName = Context.GetFromContext(savedAs).ToString();
            Report.Info(savedpUpcName);
            Report.IsTrue(new ProductInformation().GetProductName() == savedpUpcName, "UPC Name is not matched", "UPC Name is matched successfully");

        }

        [StepDefinition(@"I confirm that the Product name saved: (.*) matches with the product name in Documentations pop up")]
        public void InTheDocumentationPopUpProductNameisDisplayedSameAsSavedValue(string savedAs)
        {
            string productName = new ProductLookUp().TakeNoteOfProductName(savedAs);
            Report.Info(productName);
            if (new RecentActivities.DocumentsPopup().GetProductName() != null)
                Report.IsTrue(new RecentActivities.DocumentsPopup().GetProductName() == productName, "Product Name is not matched", "Product Name is matched successfully");
            else
                Report.Info("Product Name is not present");

        }

        [StepDefinition(@"I confirm the name shown matches the name I made a note : (.*)")]
        public void InTheProductInformationProductNameisDisplayedSameAsSavedValue(string savedAs)
        {
            string productName = new ProductLookUp().TakeNoteOfProductName(savedAs);
            Report.Info(productName);
            var savedProductName = Context.GetFromContext(savedAs).ToString();
            Report.Info(savedProductName);
            Report.IsTrue(new ProductInformation().GetProductNameinProductInformation() == savedProductName, "Product Name is not matched", "Product Name is matched successfully");

        }
        [StepDefinition(@"I confirm the text I entered : (.*) into the search field is still shown")]
        public void InTheProductLookUpSearchFieldTextIEnteredIsStillShown(string text)
        {
            Report.IsTrue(new ProductLookUp().GetSearchFieldValue(text), "Text I Entered is not shown", "Text I entered is shown successfully");

        }

        [StepDefinition(@"In the Products table I click the Reset Button")]
        public void InProductsTableIClickReset()
        {
            Report.IsTrue(new ProductLookUp().ClickResetButton(), "Failed to click reset", "Successfully clicked the reset button");
        }

        [StepDefinition(@"Select any WPSID shown on the page and save as: (.*)")]
        public void SelectAnyWPSIDAndSaveTheNumber(string savedAs)
        {
            string wpsidNumber = new ProductLookUp().TakeNoteOfWPSIDNumber(savedAs);
            Context.AddToContext(savedAs, wpsidNumber);
        }

        [StepDefinition(@"I Enter WPSID Number : (.*) in Search field")]
        public void InTheProductLookUpSearchtheProductByWPSIDNumber(string savedAs)
        {
            string wpsidNumber = new ProductLookUp().TakeNoteOfWPSIDNumber(savedAs);
            var savedWpsIdNumber = Context.GetFromContext(savedAs).ToString();

            Report.IsTrue(new ProductLookUp().InTheProductLookUpSearchProduct(savedWpsIdNumber), "Failed to search the product", $"Successfully searched the product");

        }

        [StepDefinition(@"I confirm the WPSID I saved: (.*) is shown in Product Table")]
        public void InTheProductLookUpSeartheProductByWPSIDNumber(string savedAs)
        {
            string wpsNumber = new ProductLookUp().TakeNoteOfWPSIDNumber(savedAs);
            var savedpWpsNumber = Context.GetFromContext(savedAs).ToString();

            Report.IsTrue(new ProductLookUp().InTheProductLookUpSearchProduct(savedpWpsNumber), "Failed to search the product", $"Successfully searched the product");

            Report.IsTrue(new ProductLookUp().WaitProductsGridSpinnerFinish(), "The Spinner is still showing, the products grid has not loaded", "The products grid has loaded");
            var wpsidNumber = new ProductLookUp().GetSearchedProductInGridByWPSID();
            Report.IsTrue(savedpWpsNumber.Contains(wpsidNumber), "WPSID Number searched for is not displayed", "WPSID Number searched for is displayed successfully");
        }

        [StepDefinition(@"I confirm below the column selector pop up header I see 3 panels: Applied Columns, Filter Categories, Filters")]
        public void InTheColumnSelectorPopUpIVerify3Panels()
        {
            List <string> displayedPanels = new ProductLookUp.ColumnSelectorPopup().IConfirm3PanelsIsDisplayedInSelectorColumnPopup();
            var expectedPanels = new List<string>() {"Applied Columns", "Filter Categories", "Filters" };
            Report.IsTrue(Enumerable.SequenceEqual(displayedPanels.OrderBy(e => e), expectedPanels.OrderBy(e => e)), " Failed to display the column selector popup header panels", "Successfully displayed the selector popup header panels");


        }

        [StepDefinition(@"I confirm the selected category (.*) is highlighted in blue")]
        public void ConfirmSelectedCategoryBackgroundColorIsBlue(string category)
        {

            string expectedColorString = "rgba(211, 211, 211, 1)";
            string foundColorCode = new ProductLookUp.ColumnSelectorPopup().GetSelectedCategoryBackgroungColor(category);
            Report.Info($"The expected rbga color for the background is: {foundColorCode}");
            Report.IsTrue(expectedColorString == foundColorCode, "The found color was not as expected", "The color found was as expected");

        }

        [StepDefinition(@"I confirm the selected filter (.*) is highlighted in blue")]
        public void ConfirmSelectedFilterBackgroundColorIsBlue(string filter)
        {

            string expectedColorString = "rgba(211, 211, 211, 1)";
            string foundColorCode = new ProductLookUp.ColumnSelectorPopup().GetSelectedFilterBackgroungColor(filter);
            Report.Info($"The expected rbga color for the background is: {foundColorCode}");
            Report.IsTrue(expectedColorString == foundColorCode, "The found color was not as expected", "The color found was as expected");

        }

        [StepDefinition(@"I confirm in the Filters Panel a list of filters populate")]
        public void ConfirmListOfFiltersPopulate()
        {

            int rowCount = new ProductLookUp.ColumnSelectorPopup().FiltersInFiltersPanelCount();
            Report.IsTrue(rowCount > 1, "List of filters does not popluate in filters panel", "List of filters popluate in filters panel");

        }

        [StepDefinition(@"I confirm I see (.*) or more entries show in the Applied Columns panel")]
        public void Confirm1OrMoreEntriesIsDisplayedInAppliedColumn(int number)
        {

            int rowCount = new ProductLookUp.ColumnSelectorPopup().AppliedColumnsPanelCount();
            Report.IsTrue(rowCount >= number, "List of filters does not display in Applied Columns panel", "List of filters popluate in Applied Column panel");

        }

        [StepDefinition(@"I confirm a new filter was added to the applied columns panel: (.*)")]
        public void ConfirmFilterAddedIsDisplayedToAppliedColumnsPanel(string filter)
        {
            Report.IsTrue(new ProductLookUp.ColumnSelectorPopup().IConfirmTheFilterAddedIsDisplayedInAppliedColumnPanel(filter), "Filter does not display in Applied Columns panel", "Filter popluate in Applied Column panel");

        }

        [StepDefinition(@"In the product lookup page, I click the Save Report Button")]
        public void GivenInTheProductLookupPageIClickTheSaveReportButton()
        {
            Report.IsTrue(new ProductLookUp().ClickSaveReportOptionButton(), "Failed to click the Save Report button", "Successfully clicked the Save Report button");
        }

        [StepDefinition(@"I confirm the Report popup displays the following title: (.*)")]
        public void ThenIConfirmTheSaveReportPopupDisplaysTheFollowingTitleSaveReport(string reportTitle)
        {
            Report.IsTrue(new ProductLookUp.ReportPopup().IConfirmTheSaveReportPopupDisplaysTheFollowingTitleSaveReport(reportTitle), $"Failed to find the following title in the Save Report popup: " + reportTitle, $"Successfully found the following title in the Save Report popup: " + reportTitle);
        }

        [StepDefinition(@"In Save Report popup I Enter Name: (.*) in Name field")]
        public void InTheSaveReportPopupEnterName(string text)
        {
            Report.IsTrue(new ProductLookUp.ReportPopup().InTheReportPopupEnterName(text), "Failed to enter name in save report popup", $"Successfully entered name in save report popup");
        }

        [StepDefinition(@"In Save Report popup, I click Save button")]
        public void InTheSaveReportPopupIClickSaveButton()
        {
            Report.IsTrue(new ProductLookUp.ReportPopup().InTheSaveReportPopupClickSaveButton(), $"Failed to click Save Button in Save Report Popup" , "Successfully clicked Save Button in Save Report Popup");
        }

        [StepDefinition(@"In the Product Lookup Page, The Report Popup is not showing")]
        public void InTheProductLookupPageSaveReportPopupIsNotShowing()
        {
            Report.IsTrue(new ProductLookUp.ReportPopup().WaitForContainerToBeInvisible(), "The More filters popup was showing", "The More filters popup was not showing");
        }

        [StepDefinition(@"In the product lookup page, I click the Open Report Button")]
        public void GivenInTheProductLookupPageIClickTheOpenReportButton()
        {
            Report.IsTrue(new ProductLookUp().ClickOpenReportOptionButton(), "Failed to click the Open Report button", "Successfully clicked the Open Report button");
        }

        [StepDefinition(@"In Open Report popup, I click Open button")]
        public void InTheOpenReportPopupIClickOpenButton()
        {
            Report.IsTrue(new ProductLookUp.ReportPopup().InTheOpenReportPopupClickOpenButton(), $"Failed to click Open Button in Open Report Popup", "Successfully clicked Open Button in Open Report Popup");
        }

        [StepDefinition(@"In Open Report popup, I Select Report:(.*)")]
        public void InTheOpenReportPopupISelecReport(string reportName)
        {
            Report.IsTrue(new ProductLookUp.ReportPopup().InTheOpenReportPopupClickISelectReport(reportName), $"Failed to Select Report in Open Report Popup", "Successfully Selected Report  in Open Report Popup");
        }

        [StepDefinition(@"In Open Report popup, Report:(.*) is displayed")]
        public void InTheOpenReportPopupVerifyReportNameIsDisplayed(string reportName)
        {
            Report.IsTrue(new ProductLookUp.ReportPopup().InTheOpenReportPopupVerifyReportNameIsDisplayed(reportName), $"Failed to display Report in Open Report Popup", "Successfully displayed Report  in Open Report Popup");
        }



    }

}
