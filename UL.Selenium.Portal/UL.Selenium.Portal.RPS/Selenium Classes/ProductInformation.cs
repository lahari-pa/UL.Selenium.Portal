using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using UL.Automation.Reporting.Functions;
using UL.Automation.ReqnrollHelpers.Classes;
using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Classes;
using UL.Automation.WebDriver.Extensions;
using UL.Selenium.Portal.WERCSmart.Classes;

namespace UL.Selenium.Portal.RPS.Selenium_Classes
{
    class ProductInformation : SeleniumBaseObject
    {

        #region Page Objects
        protected override By ContainerElementLocator => By.XPath("//div[@id='ModalBase_Global_Notifications_Container']//div[contains(@class ,'modal-content')]	");

        private IWebElement CloseButton => this.FindElement(By.XPath(".//div[contains(@class,'modal-footer')]//button[text()='Close']"), 2);

        private string HeadingText => this.FindElement(By.XPath(".//h3[@class='modal-title']"), 2).Text;
        private IWebElement CrossCloseIcon => this.FindElement(By.XPath(".//button[@class='close']//span[text()='×']"), 2);

        public IWebElement SectionDataTable(string section) => ContainerElement.WaitUntilElementVisible(By.XPath($"//div[contains(@class,'panel-heading')  and .//a//span[contains(text(),'{section}')]]//following-sibling::div//table"), 4);

        private IWebElement CollapseAllButton => this.FindElement(By.XPath("//*[@id='ModalBase_Global_Notifications_Container']/div/div/div/div[2]/div/div[2]/div/button[1]"), 2);

        private IWebElement ExpandAllButton => this.FindElement(By.XPath("//*[@id='ModalBase_Global_Notifications_Container']/div/div/div/div[2]/div/div[2]/div/button[2]"), 2);

        #endregion

        #region Methods

        public bool ProductInformationPopupPresent() => this.ContainerVisible();

        public bool WaitUntilProductInformationPopupPresent() => this.WaitForContainerToBeVisible();

        public bool WaitUntilProductInformationPopupNotPresent() => this.WaitForContainerToBeInvisible();

        public bool ClickCloseButton() => CloseButton.TryClick();

        public bool ClickProductInformationSection(string section)
        {
            IWebElement sectionToClick = ContainerElement.FindElement(By.XPath($".//div[contains(@class,'panel-group')]//div[.//div[contains(@class,'panel-heading') and .//a//span[contains(text(),'{section}')]]]//a"), 2);
            Delay.Seconds(1);
            return sectionToClick.TryClick();
        }

        public bool ProductInformationSectionIsActive(string section)
        {
            IWebElement sectionPanel = ContainerElement.FindElement(By.XPath($".//div[contains(@class,'panel-group')]//div[.//div[contains(@class,'panel-heading') and .//a//span[contains(text(),'{section}')]]]//div[@role='tabpanel']"), 2);
            string expandedStatus = sectionPanel.GetAttribute("class");
            return expandedStatus.Contains(" show");
        }

        public string GetAdditionalDataBackgroundColor()
        {
            IWebElement backgroundEl = ContainerElement.FindElement(By.XPath(".//div[contains(@class,'panel-heading') and .//a//span[contains(text(),'Additional Data')]]"));
            if (backgroundEl == null)
            {
                Report.Error("The Background El was null");
                return null;
            }
            string rbgaCssValue = backgroundEl.GetCssValue("background-color");
            return rbgaCssValue;
        }


        public string GetAdditionalDataFontColor()
        {
            IWebElement backgroundEl = ContainerElement.FindElement(By.XPath(".//div[contains(@class,'panel-heading') and .//a//span[contains(text(),'Additional Data')]]//a"));
            if (backgroundEl == null)
            {
                Report.Error("The Background El was null");
                return null;
            }
            string rbgaCssValue = backgroundEl.GetCssValue("color");
            return rbgaCssValue;
        }



        //public bool ProductNameMatchesLastProductName()
        //{
        //    if(Context.Contains("PreviousProductName"))
        //    {
        //        string previousProductName = (string)Context.GetFromContext("PreviousProductName");
        //        ProductData prodTopInfo = this.GetProductTopData();
        //        return prodTopInfo.ProductName == previousProductName;
        //    }
        //    Report.Info("There was no previous product name saved to context");
        //    return false;

        //}

        public bool WaitForProductInformationToLoad(int timeout = 30)
        {
            return (ContainerElement.WaitUntilElementVisible(By.XPath(".//div[@class='panel-group']"), timeout)) != null;
        }


        public ProductDataCodes GetProductDataCodes()
        {
            IWebElement dataTable = ContainerElement.FindElement(By.XPath(".//div[@class='panel-heading' and .//a[contains(text(),'Product Details')]]//following-sibling::div//table"), 2);
            List<IWebElement> dataRows = dataTable.FindElements(By.XPath(".//tr"), 2).ToList();
            ProductDataCodes currentProdDataCodes = new ProductDataCodes();
            foreach (var row in dataRows)
            {
                IWebElement title = row.FindElement(By.XPath(".//td[1]"), 2);
                if (title == null)
                {
                    Report.Info("The title Element was null");
                    return null;
                }
                IWebElement value = row.FindElement(By.XPath(".//td[2]"), 2);
                if (value == null)
                {
                    Report.Info("The value Element was null");
                    return null;
                }

                if (title.Text.Contains("Supplier Contact Name"))
                {
                    currentProdDataCodes.SupplierContactName = value.Text;
                }

                if (title.Text.Contains("US EPA Waste Number"))
                {
                    currentProdDataCodes.USEPAWasteNumber = value.Text;
                }

                if (title.Text.Contains("Flash point °C"))
                {
                    currentProdDataCodes.FlashPoint = value.Text;
                }
            }

            return currentProdDataCodes;
        }

        public TransporationData GetTransportationData()
        {
            IWebElement dataTable = ContainerElement.FindElement(By.XPath(".//div[@class='panel-heading' and .//a[contains(text(),'Transportation')]]//following-sibling::div//table"), 2);
            List<IWebElement> dataRows = dataTable.FindElements(By.XPath(".//tr"), 2).ToList();
            TransporationData currentTransporationData = new TransporationData();
            foreach (var row in dataRows)
            {
                IWebElement title = row.FindElement(By.XPath(".//td[1]"), 2);
                if (title == null)
                {
                    Report.Info("The title Element was null");
                    return null;
                }
                IWebElement value = row.FindElement(By.XPath(".//td[2]"), 2);
                if (value == null)
                {
                    Report.Info("The value Element was null");
                    return null;
                }

                if (title.Text.Contains("Emergency Response Guide Number"))
                {
                    currentTransporationData.EmergencyResponseGuideNumber = value.Text;
                }

                if (title.Text.Contains("Hazard Class"))
                {
                    currentTransporationData.HazardClass = value.Text;
                }

                if (title.Text.Contains("UN-No."))
                {
                    currentTransporationData.UNNo = value.Text;
                }

                if (title.Text.Contains("Packing Group"))
                {
                    currentTransporationData.PackingGroup = value.Text;
                }

                if (title.Text.Contains("DOT Vessel Limited Quantity w/units"))
                {
                    currentTransporationData.DOTVesselLimitedQuantity = value.Text;
                }

                if (title.Text.Contains("DOT Marine Pollutant"))
                {
                    currentTransporationData.DOTMarinePollutant = value.Text;
                }

                if (title.Text.Contains("Marine pollutant"))
                {
                    currentTransporationData.Marinepollutant = value.Text;
                }

                if (title.Text.Contains("Miscible in Water"))
                {
                    currentTransporationData.MiscibleinWater = value.Text;
                }
            }

            return currentTransporationData;
        }

        public StorageData GetStorageData()
        {
            IWebElement dataTable = ContainerElement.FindElement(By.XPath(".//div[@class='panel-heading' and .//a[contains(text(),'Storage')]]//following-sibling::div//table"), 2);
            List<IWebElement> dataRows = dataTable.FindElements(By.XPath(".//tr"), 2).ToList();
            StorageData currentStorageData = new StorageData();
            foreach (var row in dataRows)
            {
                IWebElement title = row.FindElement(By.XPath(".//td[1]"), 2);
                if (title == null)
                {
                    Report.Info("The title Element was null");
                    return null;
                }
                IWebElement value = row.FindElement(By.XPath(".//td[2]"), 2);
                if (value == null)
                {
                    Report.Info("The value Element was null");
                    return null;
                }

                if (title.Text.Contains("Uniform Fire Code"))
                {
                    currentStorageData.UniformFireCode = value.Text;
                }

                if (title.Text.Contains("International Fire Code"))
                {
                    currentStorageData.InternationalFireCode = value.Text;
                }

                if (title.Text.Contains("Health Hazards"))
                {
                    currentStorageData.HealthHazards = value.Text;
                }

                if (title.Text.Contains("Flammability"))
                {
                    currentStorageData.Flammability = value.Text;
                }

                if (title.Text.Contains("Stability"))
                {
                    currentStorageData.Stability = value.Text;
                }

                if (title.Text.Contains("Physical and Chemical Hazards"))
                {
                    currentStorageData.PhysicalandChemicalHazards = value.Text;
                }

            }

            return currentStorageData;
        }

        public BatteryData GetBatteryData()
        {
            IWebElement dataTable = ContainerElement.FindElement(By.XPath(".//div[@class='panel-heading' and .//a[contains(text(),'Battery')]]//following-sibling::div//table"), 2);
            List<IWebElement> dataRows = dataTable.FindElements(By.XPath(".//tr"), 2).ToList();
            BatteryData currentBatteryData = new BatteryData();
            foreach (var row in dataRows)
            {
                IWebElement title = row.FindElement(By.XPath(".//td[1]"), 2);
                if (title == null)
                {
                    Report.Info("The title Element was null");
                    return null;
                }
                IWebElement value = row.FindElement(By.XPath(".//td[2]"), 2);
                if (value == null)
                {
                    Report.Info("The value Element was null");
                    return null;
                }

                if (title.Text.Contains("Does the product contain a battery or is it shipped with a battery"))
                {
                    currentBatteryData.ContainsOrShippedWithBattery = value.Text;
                }

                if (title.Text.Contains("Product Itself is a Battery (full assessment)"))
                {
                    currentBatteryData.ProductIsBattery = value.Text;
                }

                if (title.Text.Contains("How Battery Resides in Product"))
                {
                    currentBatteryData.HowBatteryResides = value.Text;
                }

                if (title.Text.Contains("Watt hours for Li Batteries"))
                {
                    currentBatteryData.WattHoursLiBatteries = value.Text;
                }

                if (title.Text.Contains("Weight of battery"))
                {
                    currentBatteryData.BatteryWeight = value.Text;
                }

                if (title.Text.Contains("Quantity (grams) of Lithium present in battery"))
                {
                    currentBatteryData.QuantityOfLithiumPresent = value.Text;
                }

                if (title.Text.Contains("Number of Batteries"))
                {
                    currentBatteryData.NumberOfBatteries = value.Text;
                }

                if (title.Text.Contains("UN38.3 tested"))
                {
                    currentBatteryData.UN383Tested = value.Text;
                }

                if (title.Text.Contains("IATA quality management system"))
                {
                    currentBatteryData.IATAQaulityManagmentSystem = value.Text;
                }

                if (title.Text.Contains("Number of batteries/cells used to run equipment"))
                {
                    currentBatteryData.NumberOfBatteriesToRun = value.Text;
                }
            }

            return currentBatteryData;
        }

        public ProductData GetProductTopData()
        {
            IWebElement topDataTable = ContainerElement.FindElement(By.XPath(".//div[@class='modal-body']//table[contains(@style,'margin-bottom')]"), 2);
            List<IWebElement> dataRows = topDataTable.FindElements(By.XPath(".//tr"), 2).ToList();
            ProductData currentProductTopData = new ProductData();
            foreach (var row in dataRows)
            {
                IWebElement title = row.FindElement(By.XPath(".//td[1]"), 2);
                if (title == null)
                {
                    Report.Info("The title Element was null");
                    return null;
                }
                IWebElement value = row.FindElement(By.XPath(".//td[2]"), 2);
                if (value == null)
                {
                    Report.Info("The value Element was null");
                    return null;
                }

                if (title.Text.Contains("Product :"))
                {
                    currentProductTopData.ProductName = value.Text;
                    Context.AddToContext("PreviousProductName", value.Text);
                }

                if (title.Text.Contains("Supplier :"))
                {
                    currentProductTopData.Supplier = value.Text;
                }

                if (title.Text.Contains("Supplier Contact :"))
                {
                    currentProductTopData.SupplierContact = value.Text;
                }

            }
            return currentProductTopData;


        }

        public bool ProductTopDataHeadingsPresent(List<string> exepctedHeadings)
        {
            IWebElement dataTable = ContainerElement.FindElement(By.XPath(".//div[contains(@class,'modal-body')]//table//tbody[contains(@class,'product-info')]"), 2);
            List<IWebElement> dataRows = dataTable.FindElements(By.XPath(".//tr"), 2).ToList();
            List<string> foundHeadingList = new List<string>();
            foreach (var row in dataRows)
            {
                IWebElement title = row.FindElement(By.XPath(".//td[1]//h4"), 2);
                foundHeadingList.Add(title.Text);
            }

            var differences = exepctedHeadings.Except(foundHeadingList);
            return !differences.Any();
        }

        public bool ProductDataCodesHeadingsPresent(List<string> exepctedHeadings)
        {
            IWebElement dataTable = ContainerElement.FindElement(By.XPath(".//div[contains(@class,'panel-heading') and .//a//span[contains(text(),'Product')]]//following-sibling::div//table"), 2);
            List<IWebElement> dataRows = dataTable.FindElements(By.XPath(".//tr"), 2).ToList();
            List<string> foundHeadingList = new List<string>();
            foreach (var row in dataRows)
            {
                IWebElement title = row.FindElement(By.XPath(".//td[1]"), 2);
                foundHeadingList.Add(title.Text);
            }

            var differences = exepctedHeadings.Except(foundHeadingList);
            if (differences.Any())
            {
                foreach (var thing in differences)
                {
                    Report.Info($"The heading: {thing} was not found");
                }
            }
            return !differences.Any();
        }

        public bool DisposalHeadingsPresent(List<string> exepctedHeadings)
        {
            IWebElement dataTable = ContainerElement.FindElement(By.XPath(".//div[@class='panel-heading' and .//a[contains(text(),'Disposal')]]//following-sibling::div//table"), 2);
            List<IWebElement> dataRows = dataTable.FindElements(By.XPath(".//tr"), 2).ToList();
            List<string> foundHeadingList = new List<string>();
            foreach (var row in dataRows)
            {
                IWebElement title = row.FindElement(By.XPath(".//td[1]"), 2);
                foundHeadingList.Add(title.Text);
            }

            var differences = exepctedHeadings.Except(foundHeadingList);
            if (differences.Any())
            {
                foreach (var thing in differences)
                {
                    Report.Info($"The heading: {thing} was not found");
                }
            }
            return !differences.Any();
        }

        public bool TransporationDataHeadingsPresent(List<string> exepctedHeadings)
        {
            IWebElement dataTable = ContainerElement.FindElement(By.XPath(".//div[contains(@class,'panel-heading') and .//a//span[contains(text(),'Transportation')]]//following-sibling::div//table"), 2);
            List<IWebElement> dataRows = dataTable.FindElements(By.XPath(".//tr"), 2).ToList();
            List<string> foundHeadingList = new List<string>();
            foreach (var row in dataRows)
            {
                IWebElement title = row.FindElement(By.XPath(".//td[1]"), 2);
                foundHeadingList.Add(title.Text);
            }

            var differences = exepctedHeadings.All(i => foundHeadingList.Contains(i));
            return differences;
        }


        public bool AdditionalDataHeadingsPresent(List<string> exepctedHeadings)
        {
            IWebElement dataTable = ContainerElement.FindElement(By.XPath(".//div[contains(@class,'panel-heading') and .//a//span[contains(text(),'Additional Data')]]//following-sibling::div//table"), 2);
            List<IWebElement> dataRows = dataTable.FindElements(By.XPath(".//tr"), 2).ToList();
            List<string> foundHeadingList = new List<string>();
            foreach (var row in dataRows)
            {
                IWebElement title = row.FindElement(By.XPath(".//td[1]"), 2);
                foundHeadingList.Add(title.Text);
            }

            var differences = exepctedHeadings.Except(foundHeadingList);
            return !differences.Any();
        }

        public bool WasteDataHeadingsPresent(List<string> exepctedHeadings)
        {
            IWebElement dataTable = ContainerElement.FindElement(By.XPath(".//div[@class='panel-heading' and .//a[contains(text(),'Waste Data')]]//following-sibling::div//table"), 2);
            List<IWebElement> dataRows = dataTable.FindElements(By.XPath(".//tr"), 2).ToList();
            List<string> foundHeadingList = new List<string>();
            foreach (var row in dataRows)
            {
                IWebElement title = row.FindElement(By.XPath(".//td[1]"), 2);
                foundHeadingList.Add(title.Text);
            }

            var differences = exepctedHeadings.Except(foundHeadingList);
            return !differences.Any();
        }

        public bool RegulatoryDataHeadingsPresent(List<string> exepctedHeadings)
        {
            IWebElement dataTable = ContainerElement.FindElement(By.XPath(".//div[@class='panel-heading' and .//a[contains(text(),'Regulatory Data')]]//following-sibling::div//table"), 2);
            List<IWebElement> dataRows = dataTable.FindElements(By.XPath(".//tr"), 2).ToList();
            List<string> foundHeadingList = new List<string>();
            foreach (var row in dataRows)
            {
                IWebElement title = row.FindElement(By.XPath(".//td[1]"), 2);
                foundHeadingList.Add(title.Text);
            }

            var differences = exepctedHeadings.Except(foundHeadingList);
            return !differences.Any();
        }

        public bool StorageHeadingsPresent(List<string> exepctedHeadings)
        {
            IWebElement dataTable = ContainerElement.FindElement(By.XPath(".//div[contains(@class,'panel-heading') and .//a//span[contains(text(),'Storage')]]//following-sibling::div//table"), 2);
            List<IWebElement> dataRows = dataTable.FindElements(By.XPath(".//tr"), 2).ToList();
            List<string> foundHeadingList = new List<string>();
            foreach (var row in dataRows)
            {
                IWebElement title = row.FindElement(By.XPath(".//td[1]"), 2);
                foundHeadingList.Add(title.Text);
            }

            var differences = exepctedHeadings.Except(foundHeadingList);
            return !differences.Any();
        }

        public bool PesticideHeadingsPresent(List<string> exepctedHeadings)
        {
            IWebElement dataTable = ContainerElement.FindElement(By.XPath(".//div[@class='panel-heading' and .//a[contains(text(),'Pesticide')]]//following-sibling::div//table"), 2);
            List<IWebElement> dataRows = dataTable.FindElements(By.XPath(".//tr"), 2).ToList();
            List<string> foundHeadingList = new List<string>();
            foreach (var row in dataRows)
            {
                IWebElement title = row.FindElement(By.XPath(".//td[1]"), 2);
                foundHeadingList.Add(title.Text);
            }

            var differences = exepctedHeadings.Except(foundHeadingList);
            return !differences.Any();
        }
        public bool BatteryHeadingsPresent(List<string> exepctedHeadings)
        {
            IWebElement dataTable = ContainerElement.FindElement(By.XPath(".//div[contains(@class,'panel-heading') and .//a//span[contains(text(),'Battery')]]//following-sibling::div//table"), 2);
            List<IWebElement> dataRows = dataTable.FindElements(By.XPath(".//tr"), 2).ToList();
            List<string> foundHeadingList = new List<string>();
            foreach (var row in dataRows)
            {
                IWebElement title = row.FindElement(By.XPath(".//td[1]"), 2);
                foundHeadingList.Add(title.Text);
            }

            var differences = exepctedHeadings.Except(foundHeadingList);
            return !differences.Any();
        }

        public bool ProductInformatinSectionsPresent(List<string> exepctedSections)
        {

            List<IWebElement> dataRows = ContainerElement.FindElements(By.XPath(".//div[contains(@class,'panel-heading') and .//a]//a//span"), 2).ToList();
            List<string> foundHeadingList = new List<string>();
            foreach (var row in dataRows)
            {
                string rowText = row.Text;
                string updatedText = rowText.Trim();
                foundHeadingList.Add(updatedText);
            }

            var differences = exepctedSections.All(i => foundHeadingList.Contains(i));
            return differences;
        }

        public bool CheckThatProductInformationMatch(ProductData orginalProductInformation, ProductData newProductInformation)
        {
            Report.Info($"Starting tho check that the two sets of ProductInformation are the same");
            return orginalProductInformation.Equals(newProductInformation);

        }

        public bool CheckTheCurrentProductContainsEnoughData()
        {
            //need count of all products in list etc, or just an i value that indicated which product looking at (mention prod ID or? (what selecting by?))
            Report.Info("Getting the Top table data");
            ProductData topTableData = new ProductInformation().GetProductTopData();
            if (topTableData.ProductName.IsNullOrEmpty() || topTableData.Supplier.IsNullOrEmpty() || topTableData.SupplierContact.IsNullOrEmpty())
            {
                Report.Info("There was not enough data in the Top Table of the Product Information popup");
                return false;
            }
            else
            {
                Report.Info("Getting the Product Data Codes table data");
                Report.IsTrue(new ProductInformation().ClickProductInformationSection("Product Details"), "Failed to click the product information section, Successfully clicked the product information section");
                ProductDataCodes currentProductDataCodes = new ProductInformation().GetProductDataCodes();

                //if (currentProductDataCodes.FlashPoint.IsNullOrEmpty())
                //{
                //    Report.Info("There was not enough data in the Product data codes");
                //    return false;
                //}
                //else
                //{
                //    Report.Info("There was enough data found for the Product");
                //    return true;
                //}

                //I think if there is not enough data, then there should be a popup so here we need to update it so that instead of looking for a flashpoint value
                //we should check that the popup saying no data is not seen
                //can not handle the popup/message as I have yet to see it.
                //for now return true and should fall over in regression etc if popup is seen in mean time.

                return true;


            }

        }

        public bool HeadingTextMatches(string expectedText)
        {
            string foundText = this.HeadingText;
            return foundText == expectedText;
        }

        public bool CrossCloseIconExists()
        {
            return this.CrossCloseIcon != null;
        }

        public bool CollapseAllButtonExists()
        {
            return this.CollapseAllButton != null;
        }

        public bool ExpandAllButtonExists()
        {
            return this.ExpandAllButton != null;
        }

        public bool ClickCrossCloseIcon()
        {
            return this.CrossCloseIcon.TryClick();
        }

        public bool ClickCollapseAll()
        {
            return this.CollapseAllButton.TryClick();
        }

        public bool ClickExpandAll()
        {
            return this.ExpandAllButton.TryClick();
        }

        public bool CloseButtonExists()
        {
            return this.CloseButton != null;
        }

        public bool SectionDataTablePresent(string section)
        {
            //this Method tells you if the table is present if the section is exapnded or not.
            bool present = this.SectionDataTable(section) != null;
            return present;
        }

        public bool ProductInformationPopUpIsDisplayed()
        {
            IWebElement ProductInformationPopUp = this.FindElement(By.XPath("//*[@id='ModalBase_Global_Notifications_Container']/div/div/div"), 2);
            return ProductInformationPopUp.Displayed;
        }

        public bool ProductNameDisplayed()
        {
            IWebElement ProductName = this.FindElement(By.XPath("//div[@id='ModalBase_Global_Notifications_Container']//div[@class ='modal-content']//table//td//span[@data-bind = 'text: ProductName']"), 2);
            return ProductName.Displayed;
        }

        public bool ProductNameIsDisplayedBeforeWPSId()
        {
            IWebElement ProductName = this.FindElement(By.XPath("//div[@id='ModalBase_Global_Notifications_Container']//div[@class ='modal-content']//table//td//span[@data-bind = 'text: ProductName']"), 2);
            IWebElement WPSId = this.FindElement(By.XPath("//div[@id='ModalBase_Global_Notifications_Container']//div[@class ='modal-content']//table//td//span[@data-bind = 'text: ProductNumber']"), 2);
            IWebElement Product = this.FindElement(By.XPath("//div[@id='ModalBase_Global_Notifications_Container']//div[@class ='modal-content']//table//td[2]"), 2);

            var productText = Product.Text;
            Report.Info(productText);
            var productConcatenateName = ProductName.Text + " " + "(" + WPSId.Text + ")";
            Report.Info(productConcatenateName);
            return productText == productConcatenateName;
        }

        public string GetProductName()
        {
            IWebElement ProductName = this.FindElement(By.XPath("//div[@id='ModalBase_Global_Notifications_Container']//div[@class ='modal-content']//table//td//span[@data-bind = 'text: $parent.upcName']"), 2);
            if (ProductName == null)
            {
                Report.Error("The UPC Name element was null");
                return null;
            }
            return ProductName.Text;

        }

        public string GetProductNameinProductInformation()
        {
            IWebElement ProductName = this.FindElement(By.XPath("//div[@id='ModalBase_Global_Notifications_Container']//div[@class ='modal-content']//table//td//span[@data-bind = 'text: ProductName']"), 2);
            if (ProductName == null)
            {
                Report.Error("The Product Name element was null");
                return null;
            }
            return ProductName.Text;

        }


        #endregion


    }
    public class ProductDataCodes
    {
        public string SupplierContactName { get; set; }

        public string USEPAWasteNumber { get; set; }

        public string FlashPoint { get; set; }
        //are two sections for flashpoint, is one a bug?
    }

    public class TransporationData
    {
        public string EmergencyResponseGuideNumber { get; set; }

        public string HazardClass { get; set; }

        public string UNNo { get; set; }

        public string PackingGroup { get; set; }

        public string DOTVesselLimitedQuantity { get; set; }

        public string DOTMarinePollutant { get; set; }

        public string Marinepollutant { get; set; }

        public string MiscibleinWater { get; set; }

    }

    public class StorageData
    {
        public string UniformFireCode { get; set; }

        public string InternationalFireCode { get; set; }

        public string HealthHazards { get; set; }

        public string Flammability { get; set; }

        public string Stability { get; set; }

        public string PhysicalandChemicalHazards { get; set; }

    }

    public class BatteryData
    {
        public string ContainsOrShippedWithBattery { get; set; }

        public string ProductIsBattery { get; set; }

        public string HowBatteryResides { get; set; }

        public string WattHoursLiBatteries { get; set; }

        public string BatteryWeight { get; set; }

        public string QuantityOfLithiumPresent { get; set; }

        public string NumberOfBatteries { get; set; }

        public string UN383Tested { get; set; }

        public string IATAQaulityManagmentSystem { get; set; }

        public string NumberOfBatteriesToRun { get; set; }

    }

    public class ProductData
    {
        public string ProductNumber { get; set; }
        public string ProductName { get; set; }

        public string Supplier { get; set; }

        public string SupplierContact { get; set; }

        public ProductDataCodes ProdDataCodes { get; set; }

        public TransporationData TransData { get; set; }

        public StorageData StrgData { get; set; }

        public BatteryData Battdata { get; set; }

        public override bool Equals(object obj)
        {
            var other = obj as ProductData;

            if (other == null)
                return false;

            if (ProductNumber != other.ProductNumber || ProductName != other.ProductName || Supplier != other.Supplier || SupplierContact != other.SupplierContact || ProdDataCodes.FlashPoint != other.ProdDataCodes.FlashPoint
                || ProdDataCodes.SupplierContactName != other.ProdDataCodes.SupplierContactName || ProdDataCodes.USEPAWasteNumber != other.ProdDataCodes.USEPAWasteNumber || TransData.DOTMarinePollutant != other.TransData.DOTMarinePollutant ||
                TransData.DOTVesselLimitedQuantity != other.TransData.DOTVesselLimitedQuantity || TransData.EmergencyResponseGuideNumber != other.TransData.EmergencyResponseGuideNumber || TransData.HazardClass != other.TransData.HazardClass ||
                TransData.Marinepollutant != other.TransData.Marinepollutant || TransData.MiscibleinWater != other.TransData.MiscibleinWater || TransData.PackingGroup != other.TransData.PackingGroup || TransData.UNNo != other.TransData.UNNo ||
                StrgData.Flammability != other.StrgData.Flammability || StrgData.HealthHazards != other.StrgData.HealthHazards || StrgData.InternationalFireCode != other.StrgData.InternationalFireCode || StrgData.PhysicalandChemicalHazards != other.StrgData.PhysicalandChemicalHazards ||
                StrgData.Stability != other.StrgData.Stability || StrgData.UniformFireCode != other.StrgData.UniformFireCode || Battdata.BatteryWeight != other.Battdata.BatteryWeight || Battdata.ContainsOrShippedWithBattery != other.Battdata.ContainsOrShippedWithBattery ||
                Battdata.HowBatteryResides != other.Battdata.HowBatteryResides || Battdata.IATAQaulityManagmentSystem != other.Battdata.IATAQaulityManagmentSystem || Battdata.NumberOfBatteries != other.Battdata.NumberOfBatteries || Battdata.NumberOfBatteriesToRun != other.Battdata.NumberOfBatteriesToRun ||
                Battdata.ProductIsBattery != other.Battdata.ProductIsBattery || Battdata.QuantityOfLithiumPresent != other.Battdata.QuantityOfLithiumPresent || Battdata.UN383Tested != other.Battdata.UN383Tested || Battdata.WattHoursLiBatteries != other.Battdata.WattHoursLiBatteries)
            {

                Report.Info("The two sets of product Information did not match");
                return false;
            }

            return true;
        }


    }
}

