using System.Collections.Generic;
using TechTalk.SpecFlow;
using UL.Automation.Reporting.Functions;
using UL.Automation.WebDriver.Classes;
using UL.Automation.SpecFlow.Classes;
using UL.Selenium.Portal.RPS.Classes;
using UL.Selenium.Portal.RPS.Selenium_Classes;

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
            if(productID.Contains("ProductInformation"))
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
            Report.IsTrue(buttons.Count == new ProductLookUp().ProductLookUpButtons.Count, "The number of buttons found did not match the expected number of buttons", "The expected number of button matched the found number of buttons");
            foreach (var button in buttons)
            {
                Report.IsTrue(new ProductLookUp().CheckProductLookUpButtonsListContains(button), "The button was not found in the list of buttons", "The button was found");
            }

        }

        [StepDefinition(@"In the Product Lookup Page, I click the More Filters Button")]
        public void InTheProductLookupPageIClickTheMoreFiltersOption()
        {
            Report.IsTrue(new ProductLookUp().ClickMoreFiltersOptionButton(), "Failed to click the more filters button", "Successfully clicked the more filters button");
        }

        [StepDefinition(@"In the Product Lookup Page, The More Filters Popup is showing")]
        public void InTheProductLookupPageIClickTheMoreFiltersPopupIsShowing()
        {
            Report.IsTrue(new ProductLookUp.MoreFiltersPopup().WaitForContainerToBeVisible(), "The More filters popup was not showing", "The More filters popup was showing");
        }

        [StepDefinition(@"In the Product Lookup Page, The More Filters Popup is not showing")]
        public void InTheProductLookupPageIClickTheMoreFiltersPopupIsNotShowing()
        {
            Report.IsTrue(new ProductLookUp.MoreFiltersPopup().WaitForContainerToBeInvisible(), "The More filters popup was showing", "The More filters popup was not showing");
        }

        [StepDefinition(@"In the Product Lookup Page More Filters Popup, I click the (.*) Filter")]
        public void InTheProductLookupMoreFiltersPageIClickFilter(string value)
        {
            Report.IsTrue(new ProductLookUp.MoreFiltersPopup() .ClickFilterOption(value),"Failed to select the filter","Successfully selected the filter");
            Delay.Seconds(3);
        }

        [StepDefinition(@"In the Product Lookup Page More Filters Popup, I enter the parameter (.*)")]
        public void InTheProductLookupMoreFiltersPageIEnterParameter(string value)
        {
            Report.IsTrue(new ProductLookUp.MoreFiltersPopup().EnterParameterForSearch(value), "Failed to enter parameter", "Successfully entered parameter");
        }

        [StepDefinition(@"In the Product Lookup Page More Filters Popup, I select the parameter (.*)")]
        public void InTheProductLookupMoreFiltersPageISelectParameter(string value)
        {
            new ProductLookUp.MoreFiltersPopup().WaitForParametersToShow();
            Report.IsTrue(new ProductLookUp.MoreFiltersPopup().ClickGivenParameterOption(value), "Failed to select the parameter", "Successfully selected the parameter");
            Delay.Seconds(3);
        }

        [StepDefinition(@"In the Product Lookup Page More Filters Popup, I select the first parameter")]
        public void InTheProductLookupMoreFiltersPageISelectTheFirstParameter()
        {
            Report.IsTrue(new ProductLookUp.MoreFiltersPopup().ClickFirstParameterOption(), "Failed to select the first parameter", "Successfully selected the first parameter");
        }

        [StepDefinition(@"In the Product Lookup Page More Filters Popup, I Click the the OK Button")]
        public void InTheProductLookupMoreFiltersPageClickOKButton()
        {
            Report.IsTrue(new ProductLookUp.MoreFiltersPopup().ClickOKButton(), "The OK button was not clicked", "The OK button was clicked successfully");
        }

        [StepDefinition(@"I confirm that the Lookup Page bread crumb area contains the label: (.*)")]
        public void IConfirmThatTheProductLookupPageBreadCrumbAreaContainsLabel(string label)
        {
           
            Report.IsTrue(new ProductLookUp().ConfirmBreadCrumbAreaContainsLabel(label), "The Bread crumb area did not contain the label", "The bread crumb are contained the label");
        }




    }
}
