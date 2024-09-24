using System.Collections.Generic;
using OpenQA.Selenium;
using Reqnroll;
using UL.Automation.Reporting.Functions;
using UL.Automation.WebDriver.Classes;
using UL.Automation.WebDriver.Extensions;
using UL.Automation.ReqnrollHelpers.Classes;
using UL.Selenium.Portal.RPS.Selenium_Classes;

namespace UL.Selenium.Portal.RPS.Steps
{
    [Binding, Scope(Tag = "ProductInformation")]
    class Steps_ProductInformation
    {

        [StepDefinition(@"I save the Product Information for the current Product as: (.*)")]
        public void ISaveTheProductInformationForCurrentProduct(string productSavedAs)
        {
            Report.IsTrue(new ProductInformation().WaitForContainerToBeVisible(), "The product Information popup did not load", "The Product Information popup was loaded");
            Report.IsTrue(new ProductInformation().WaitForProductInformationToLoad(), "The Product Information Table did not Load", "The Product Information Table Loaded");
            Report.Info("Attempting to save the Product Data for the Current Product");
            Report.Info("Getting the Top table data");
            ProductData activeProductData = new ProductData();
            ProductData topTableData = new ProductInformation().GetProductTopData();
            Report.Info("Getting the Product Data Codes table data");
            if(!new ProductInformation().ProductInformationSectionIsActive("Product Data Codes"))
            {
                new ProductInformation().ClickProductInformationSection("Product Data Codes");
            }            
            ProductDataCodes currentProductDataCodes = new ProductInformation().GetProductDataCodes();
            Report.Info("Getting the Transportation table data");
            if (!new ProductInformation().ProductInformationSectionIsActive("Transportation Data"))
            {
                new ProductInformation().ClickProductInformationSection("Transportation Data");
            }
            TransporationData currentTransporationData = new ProductInformation().GetTransportationData();
            Report.Info("Getting the Storage table data");
            if (!new ProductInformation().ProductInformationSectionIsActive("Storage Data"))
            {
                new ProductInformation().ClickProductInformationSection("Storage Data");
            }
            StorageData currentStroageData = new ProductInformation().GetStorageData();
            Report.Info("Getting the Battery table data");
            if (!new ProductInformation().ProductInformationSectionIsActive("Battery Data"))
            {
                new ProductInformation().ClickProductInformationSection("Battery Data");
            }
            BatteryData currentBatteryData = new ProductInformation().GetBatteryData();

            Report.Info("Attempting to Create a full product data set");
           

            string prodID = topTableData.ProductName;
            int lengthindex = prodID.Length - 1;
            int lastOpenBracket = prodID.LastIndexOf("(");
            int goLength = lengthindex - lastOpenBracket;
            prodID = prodID.Substring(lastOpenBracket + 1, goLength);
            prodID = prodID.Replace(")", "");

            activeProductData.ProductNumber = prodID;
            activeProductData.ProductName = topTableData.ProductName;
            activeProductData.Supplier = topTableData.Supplier;
            activeProductData.SupplierContact = topTableData.SupplierContact;
            activeProductData.ProdDataCodes = currentProductDataCodes;
            activeProductData.TransData = currentTransporationData;
            activeProductData.StrgData = currentStroageData;
            activeProductData.Battdata = currentBatteryData;

            Report.Info($"Saving the Product with its information to context as: {productSavedAs}");

            Context.AddToContext(productSavedAs, activeProductData);

        }


        [StepDefinition(@"I save the information for the first product in the product list of widget: (.*) that contains data to context as: (.*)")]
        public void SaveProductInfromationForProductWithData(string widgetTitle, string productSavedAs)
        {
            Report.Info("Getting all the product numbers being shown in the Product List");
            List<string> currentProductsNumbers = new Home.Widget(widgetTitle).GetCurrentProductNumbers();
            foreach (var number in currentProductsNumbers)
            {
                IWebElement wantedProduct = new Home.Widget(widgetTitle).GetGivenProductLink(number);
                Report.IsTrue(wantedProduct.TryClick(), "Failed to click the product", "Successfully clicked the product");
                Report.IsTrue(new ProductInformation().WaitForContainerToBeVisible(), "The product Information popup did not load", "The Product Information popup was loaded");
                Report.IsTrue(new ProductInformation().WaitForProductInformationToLoad(), "The Product Information Table did not Load", "The Product Information Table Loaded");
                if (Context.Contains("PreviousProductName"))
                {
                    string previousProductName = (string)Context.GetFromContext("PreviousProductName");
                    int i = 0;
                    bool matching = true;
                    while(matching==true&&i<6)
                    {
                        try
                        {
                            ProductData prodTopInfo = new ProductInformation().GetProductTopData();
                            matching = prodTopInfo.ProductName == previousProductName;
                        }
                        catch
                        {
                            Delay.Seconds(2);
                            ProductData prodTopInfo = new ProductInformation().GetProductTopData();
                            matching = prodTopInfo.ProductName == previousProductName;
                        }
                    }                    

                }
                else
                {
                    Report.Info("There was no previous product name saved to context");
                }

                


                bool containsData = new ProductInformation().CheckTheCurrentProductContainsEnoughData();


                if (containsData==true)
                {
                    this.ISaveTheProductInformationForCurrentProduct(productSavedAs);
                    var prodInfo = (ProductData)Context.GetFromContext(productSavedAs);
                    if(number!=prodInfo.ProductNumber)
                    {
                        Report.Failure("The Product Number found in the popup did not match the product number selected from the list of products");
                        return;
                    }
                    return;
                }
                else
                {
                    Report.Info("The Product chosen did not contain enough data, moving onto the next product in the list");
                    Report.IsTrue(new ProductInformation().ClickCloseButton(), "Failed to Click Close", "Successfully Clicked Close");
                    Report.IsTrue(new ProductInformation().WaitUntilProductInformationPopupNotPresent(), "The Product Information popup was still present", "The Product Informaion popup was no longer present");
                }
                
            }


        }

        

        [StepDefinition(@"I Close the Product Information Popup")]
        public void ICloseProductInformationPopup()
        {
            Report.Info("I Click the Close Button on the Product Infromation Popup");
            Report.IsTrue(new ProductInformation().ClickCloseButton(), "Failed to click the close button", "Successfully clicked the close button");
            Report.IsTrue(new ProductInformation().WaitUntilProductInformationPopupNotPresent(), "The product information popup was still Presen!", "The Product Information popup was not present");

        }

        [StepDefinition(@"I Check that two sets of ProductInformation Saved as: (.*) and (.*) are the same")]
        public void ICheckThatTwoSetsOfProductInformationAreTheSame(string savedInformation1, string savedInformation2)
        {
            Report.Info("I Start to check that the two sets of Product Information are the same");
            Report.Info("Getting ProductInformation set 1 from context");
            var productInformation1 = (ProductData)Context.GetFromContext(savedInformation1);
            Report.Info("Getting ProductInformation set 2 from context");
            var productInformation2 = (ProductData)Context.GetFromContext(savedInformation2);

            Report.IsTrue(new ProductInformation().CheckThatProductInformationMatch(productInformation1, productInformation2), "The Two sets of product Information were not the same", "The Two sets of Product Information were the same");
        }


        [StepDefinition(@"I open the Product Information popup for products in the Product list of widget: (.*) until one has enough data")]
        public void OpenProductInformationFromProductListUntilOneHasData(string widgetTitle)
        {
            Report.Info("Getting all the product numbers being shown in the Product List");
            List<string> currentProductsNumbers = new Home.Widget(widgetTitle).GetCurrentProductNumbers();
            foreach (var number in currentProductsNumbers)
            {
                IWebElement wantedProduct = new Home.Widget(widgetTitle).GetGivenProductLink(number);
                Report.IsTrue(wantedProduct.TryClick(), "Failed to click the product", "Successfully clicked the product");
                Report.IsTrue(new ProductInformation().WaitForContainerToBeVisible(), "The product Information popup did not load", "The Product Information popup was loaded");
                Report.IsTrue(new ProductInformation().WaitForProductInformationToLoad(60), "The Product Information Table did not Load", "The Product Information Table Loaded");
                if (Context.Contains("PreviousProductName"))
                {
                    string previousProductName = (string)Context.GetFromContext("PreviousProductName");
                    int i = 0;
                    bool matching = true;
                    while (matching == true && i < 6)
                    {
                        try
                        {
                            ProductData prodTopInfo = new ProductInformation().GetProductTopData();
                            matching = prodTopInfo.ProductName == previousProductName;
                        }
                        catch
                        {
                            Delay.Seconds(2);
                            ProductData prodTopInfo = new ProductInformation().GetProductTopData();
                            matching = prodTopInfo.ProductName == previousProductName;
                        }

                        i++;
                    }

                }
                else
                {
                    Report.Info("There was no previous product name saved to context");
                }


               

                bool containsData = new ProductInformation().CheckTheCurrentProductContainsEnoughData();


                if (containsData == true)
                {
                    Report.Success("The Product Information popup was open and contained enough data");
                    Report.IsTrue(new ProductInformation().ClickProductInformationSection("Product Details"), "Failed to Click the section", "Successfully clicked the section");
                    Report.IsTrue(!new ProductInformation().ProductInformationSectionIsActive("Product Details"), "The section was expanded", "The section was not expanded");
                    Report.IsTrue(!new ProductInformation().SectionDataTablePresent("Product Details"), "The additional area is shown below the Product Data Codes heading was showing", "The additional area is shown below the Product Data Codes heading was not showing");
                    return; 





                }
                else
                {
                    Report.Info("The Product chosen did not contain enough data, moving onto the next product in the list");
                    Report.IsTrue(new ProductInformation().ClickCloseButton(), "Failed to Click Close", "Successfully Clicked Close");
                    Report.IsTrue(new ProductInformation().WaitUntilProductInformationPopupNotPresent(), "The Product Information popup was still present", "The Product Informaion popup was no longer present");
                }

            }


        }

        [StepDefinition(@"I wait for the Product Information Popup to load")]
        public void IWaitForTheProductInformationPopupToLoad()
        {
            Report.IsTrue(new ProductInformation().WaitForContainerToBeVisible(), "The product Information popup did not load", "The Product Information popup was loaded");
         
        }

        [StepDefinition(@"I wait for the Product Information Popup to dissapear")]
        public void IWaitForTheProductInformationPopupToDissapear()
        {
            Report.IsTrue(new ProductInformation().WaitUntilProductInformationPopupNotPresent(), "The product information popup was still Presen!", "The Product Information popup was not present");

        }

        [StepDefinition(@"I wait for the Product Information Popup Table to load")]
        public void IWaitForTheProductInformationPopupTableToLoad()
        {           
            Report.IsTrue(new ProductInformation().WaitForProductInformationToLoad(), "The Product Information Table did not Load", "The Product Information Table Loaded");
        }

        [StepDefinition(@"In the Product Infromation Popup I call shared step 109167 if there is data, and 111879 if there is no data")]
        public void InTheProductInformationScreenICall109167or111879()
        {
         

            new Steps_Shared().SharedStep109167();

        }


        [StepDefinition(@"In the Product Infromation Popup I Click the 'x' Close icon")]
        public void InTheProductInformationPopupPopupIClickTheXCloseicon()
        {            
            Report.IsTrue(new ProductInformation().ClickCrossCloseIcon(), "Failed to Click the 'x' Close icon", "Successfully clicked the 'x' Close icon");

        }

        [StepDefinition(@"In the Product Information pop up, I click: Collapse All")]
        public void InTheProductInformationPopupPopupIClickCollapseAll()
        {
            Report.IsTrue(new ProductInformation().ClickCollapseAll(), "Failed to Click the Collpase All", "Successfully clicked the Collapse ALl");

        }

        [StepDefinition(@"I Confirm that Product Information pop up is shown")]
        public void IConfirmProductInformationPopupIsShown()
        {
            Report.IsTrue(new ProductInformation().ProductInformationPopUpIsDisplayed(), "Product Information pop up is not displayed", "Successfully Product Information pop up is displayed");

        }

        [StepDefinition(@"I confirm I  see both a product name and a UPC name")]
        public void IConfirmProductNameIsShown()
        {
            Report.IsTrue(new ProductInformation().ProductNameDisplayed(), "Product Name is not displayed", "Successfully Product Name is displayed");

        }

        [StepDefinition(@"In the Product Information pop up I confirm the Product line shows the product name before the WPS ID")]
        public void IConfirmProductNameIsShownBeforeWPSID()
        {
            Report.IsTrue(new ProductInformation().ProductNameIsDisplayedBeforeWPSId(), "Product Name is not displayed before WPS ID", "Successfully Product Name is displayed befor WPS ID");

        }

        [StepDefinition(@"In the Product Information popup Additional Data heading I confirm background color: Orange")]

        public void ConfirmAdditionalDataBackgroundColorIsOrange()
        {

            string expectedColorString = "rgba(237, 125, 49, 1)";
            Report.Info($"The expected rbga color for the background is: {expectedColorString}");
            string foundColorCode = new ProductInformation().GetAdditionalDataBackgroundColor();
            Report.IsTrue(expectedColorString == foundColorCode, "The found color was not as expected", "The color found was as expected");

        }


        [StepDefinition(@"In the Additional Data heading I confirm font color: white")]

        public void ConfirmAdditionalDataHeadingColorIsWhite()
        {

            string expectedColorString = "rgba(255, 255, 255, 1)";
            Report.Info($"The expected rbga color for the background is: {expectedColorString}");
            string foundColorCode = new ProductInformation().GetAdditionalDataFontColor();
            Report.IsTrue(expectedColorString == foundColorCode, "The found color was not as expected", "The color found was as expected");

        }





    }
}
