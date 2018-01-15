using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumUtilities;


namespace Wercs.Selenium.PortalUX.Selenium_Classes
{
    class ProductsGrid : BaseObject
    {
        public const string BasePath = "//div[@id='products-grid']";

        [FindsBy(How = How.XPath, Using = BasePath)]
        protected override IWebElement containerElement { get; set; }

        public bool HeaderShowing()
        {
            var el = containerElement.FindElements(By.XPath("./h3"), 2);
            return el.FirstOrDefault(x => x.Text.Trim() == "YOUR PRODUCTS") != null;
        }

        public bool ProductsPresent()
        {
            var ProductsGrid = containerElement.FindElement(By.XPath(".//table"), 2);
            if (ProductsGrid == null)
                return false;
            return ProductsGrid.FindElements(By.XPath(".//tbody/tr"), 2).Count != 0;
        }

        public int ProductsCount()
        {
            var ProductsGrid = containerElement.FindElement(By.XPath(".//table"), 2);
            if (ProductsGrid == null)
                return 0;
            return ProductsGrid.FindElements(By.XPath(".//tbody/tr"), 2).Count;
        }

        public bool FilterOptionShowingCorrectly(string Option, string ColourExpected)
        {
            var AllFilters = containerElement.FindElements(By.XPath(".//ul[contains(@class,'status-filters')]//a"), 2);
            var RequiredFilter = AllFilters.FirstOrDefault(x => x.Text.Contains(Option));
            if (RequiredFilter == null)
                return false;
            // So the filter exists, now we check the colour

            var ColourShowingRaw = RequiredFilter.GetCssValue("border-bottom-color");
            var ColourShowing = "";

            switch (ColourShowingRaw)
            {
                case ("rgba(192, 203, 209, 1)"):
                    ColourShowing = "Light Grey";
                    break;
                case ("rgba(237, 185, 46, 1)"):
                    ColourShowing = "Yellow";
                    break;
                case ("rgba(0, 152, 255, 1)"):
                    ColourShowing = "Blue";
                    break;
                case ("rgba(30, 143, 31, 1)"):
                    ColourShowing = "Green";
                    break;
                case ("rgba(75, 82, 87, 1)"):
                    ColourShowing = "Dark Grey";
                    break;
                case ("rgba(207, 58, 83, 1)"):
                    ColourShowing = "Red";
                    break;
            }

            return (ColourShowing == ColourExpected);

        }

        public bool ClickFilterOption(string Option)
        {
            try
            {
                var AllFilters = containerElement.FindElements(By.XPath(".//ul[contains(@class,'status-filters')]//a"), 2);
                var RequiredFilter = AllFilters.FirstOrDefault(x => x.Text.Contains(Option));
                if (RequiredFilter == null)
                    return false;
                RequiredFilter.Click();
                GeneralUtilities.Wait_for_load_finish();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool MoreFiltersOptionPresent()
        {
            return containerElement.FindElement(By.XPath(".//a[contains(@class, 'btn') and contains(text(),'More Filters')]"), 2) != null;
        }

        public bool ProductIDNameFieldPresent()
        {
            return containerElement.FindElement(By.XPath(".//input[@id='inputGroup']"), 2) != null;
        }

        public bool BulkActionsOptionPresent()
        {
            return containerElement.FindElement(By.XPath(".//a[contains(@class, 'btn') and contains(text(),'Bulk Actions')]"), 2) != null;
        }

        public void Click_BulkActions()
        {
            containerElement.FindElement(By.XPath(".//a[contains(@class, 'btn') and contains(text(),'Bulk Actions')]"), 2).Click();
        }

        public bool GridHeaderShowing(string Header)
        {
            var AllGridHeaders = containerElement.FindElements(By.XPath(".//table//th"), 2);
            return AllGridHeaders.Select(x => x.Text.Trim()).Contains(Header);
        }

        public string GetIdInFirstGridRow()
        {
            return containerElement.FindElement(By.XPath(".//tbody//tr/td[1]//small"), 2).Text;
        }

        public bool NavigateToNextPage()
        {
            var El = containerElement.FindElement(By.XPath(".//div[contains(@class,'panel-footer')]//li/a[contains(@class,'next')]"), 2);
            if (El == null)
                return false;
            El.Click();
            return true;
        }

        public string ProductIDField
        {
            get { return containerElement.FindElement(By.XPath(".//input[@id='inputGroup']"), 2).Text; }
            set
            {
                var el = containerElement.FindElement(By.XPath(".//input[@id='inputGroup']"), 2);
                el.EnterText(value);
                el.SendKeys(Keys.Return);
            }
        }

        public bool ClickActionsForFirstResultInGrid()
        {
            try
            {
                var Button = containerElement.FindElement(By.XPath(".//table//tbody//tr[1]//button[contains(@class,'ellipsis-button')]"), 2);
                Button.Click();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public List<string> ActionsAvailableInDropDown()
        {
            var DropDownContents = containerElement.FindElements(By.XPath(".//ul[@class='dropdown-menu']//a"), 2);
            if (DropDownContents.Count == 0)
                return null;
            return DropDownContents.Select(x => x.Text.Trim()).ToList();
        }

        public bool ClickRowAction(string Action)
        {
            var DropDownContents = containerElement.FindElements(By.XPath(".//ul[@class='dropdown-menu']//a"), 2);
            if (DropDownContents.Count == 0)
                return false;

            var el = DropDownContents.FirstOrDefault(x => x.Text.Trim() == Action);
            if (el == null)
                return false;
            el.Click();
            return true;
        }

        public ProductGridItem FirstProductInGrid()
        {
            var ProductRow = containerElement.FindElement(By.XPath(".//tbody/tr[1]"), 2);

            var ProductElement = new ProductGridItem();
            ProductElement.ProductID = ProductRow.FindElement(By.XPath(".//small"), 2).Text.Trim();
            ProductElement.ProductName = ProductRow.FindElement(By.XPath(".//div[@data-bind='text:Name']"), 2).Text.Trim();
            ProductElement.DateCreated = ProductRow.FindElement(By.XPath(".//td[@data-bind='text: DateCreated']"), 2).Text.Trim();
            return ProductElement;
        }
    }

    public class ProductGridItem
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string DateCreated { get; set; }
    }

    class BulkActions : BaseObject
    {
        // Really rubbish identifier - but it's the best we have at the moment!
        public const string BasePath = "//h3[text()='Bulk Actions']/../..";

        [FindsBy(How = How.XPath, Using = BasePath)]
        protected override IWebElement containerElement { get; set; }

        public List<string> OptionsAvailable()
        {
            return containerElement.FindElements(By.XPath(".//a//div[contains(@class,'btn-text')]"),2).Select(x=>x.Text.Trim().Replace("\r\n"," ")).ToList();
        }

        public bool OptionChangesOnHover(string Option)
        {
            var el = containerElement.FindElements(By.XPath(".//a//div[contains(@class,'btn-text')]"), 2).FirstOrDefault(x => x.Text.Trim().Replace("\r\n", " ") == Option);
            return el.HoveringChangesColour();
        }

        public bool ClickOption(string Option)
        {
            try
            {
                var el = containerElement.FindElements(By.XPath(".//a//div[contains(@class,'btn-text')]"), 2).FirstOrDefault(x => x.Text.Trim().Replace("\r\n", " ") == Option);
                if (el == null)
                    return false;
                el.Click();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void ClickClose()
        {
            containerElement.FindElement(By.XPath(".//button[@class='close']"),2).Click();
        }
    }

    class DeleteDialog : BaseObject
    {
        public const string BasePath = "//h3[text()='Delete Product']/../..";
        [FindsBy(How = How.XPath, Using = BasePath)]
        protected override IWebElement containerElement { get; set; }

        public void ClickDelete()
        {
            containerElement.FindElement(By.XPath(".//button[text()='Delete']"), 2).Click();
        }

        public void ClickCancel()
        {
            containerElement.FindElement(By.XPath(".//button[text()='Cancel']"), 2).Click();
        }
    }
}
