using System.Collections.Generic;
using System.Linq;
using Castle.Core.Internal;
using OpenQA.Selenium;
using UL.Automation.Reporting.Functions;
using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Extensions;
using UL.Selenium.Portal.RPS.Classes;

namespace UL.Selenium.Portal.RPS.Selenium_Classes
{
    class SuperTable : SeleniumBaseObject
    {
        #region Page Objects
        protected override By ContainerElementLocator => By.Id("supertable_main");
        #endregion
        // public 
        #region Methods

        #endregion
    }

    class SuperTableNav : SeleniumBaseObject
    {
        #region Page Objects
        protected override By ContainerElementLocator => By.XPath("//div[contains(@class,'table-page-nav')]");
        private IWebElement NavLabel => ContainerElement.FindElement(By.XPath(".//input[@type='text']"), 1);
        private List<IWebElement> ButtonList => ContainerElement.FindElements(By.XPath(".//button"), 1).ToList();
        private List<IWebElement> CardList => ContainerElement.FindElements(By.XPath(".//div[@class='card-body']"), 1).ToList();
        private List<IWebElement> BreadcrumbList => ContainerElement.FindElements(By.XPath(@".//div[@class='filter-breadcrumbs']//span[contains(@class,'btn btn-gray')]"), 1).ToList();
        #endregion

        #region Methods
        // Nav Text
        #region Nav Text
        public bool NavLabelExists()
        {
            Report.Info("Attempting to confirm the Nav Label exists.");
            return NavLabel != null;
        }

        public string NavLabelGet()
        {
            Report.Info("Attempting to get the Nav Label text.");
            return NavLabel.Text;
        }
        #endregion

        // Nav Buttons
        #region Nav Buttons
        private IWebElement NavButtonGet(string buttonLabel)
        {
            Report.Info($"Attempting to get '{buttonLabel}' Button.");
            return ContainerElement.FindElement(By.XPath($".//button[contains(.,'{buttonLabel}')]"), 1);
        }
        public bool NavButtonExists(string buttonLabel)
        {
            Report.Info($"Attempting to confirm '{buttonLabel}' Button exists.");
            return NavButtonGet(buttonLabel) != null;
        }

        public bool NavButtonClick(string buttonLabel)
        {
            Report.Info($"Attempting to click '{buttonLabel}' Button.");
            bool result = false;
            if(NavButtonExists(buttonLabel))
            {
                result = NavButtonGet(buttonLabel).TryClick();
            }
            return result;
        }

        public string NavButtonGetColor(string buttonLabel)
        {
            Report.Info($"Attempting to get the color of '{buttonLabel}' Button.");
            string result = null;
            if (NavButtonExists(buttonLabel))
            {
                result = NavButtonGet(buttonLabel).GetCssValue("background-color");
            }
            return result;
        }

        public bool NavButtonHoveringChangesColor(string buttonLabel)
        {
            Report.Info($"Attempting to confirm color changes when hovering over '{buttonLabel}' Button.");
            bool result = false;
            if (NavButtonExists(buttonLabel))
            {
                result = NavButtonGet(buttonLabel).HoveringChangesColour();
            }
            return result;
        }
        #endregion

        // Breadcrumbs
        #region Breadcrumbs
        private bool BreadcrumbListExists()
        {
            Report.Info("Attempting to confirm breadcrumb list exists.");
            return BreadcrumbList != null;
        }

        public int BreadcrumbListCount()
        {
            Report.Info("Attempting to count the number of breadcrumbs in breadcrumb list.");
            int result = 0;
            if (BreadcrumbListExists())
            {
                result = BreadcrumbList.Count();
            }
            return result;
        }

        private List<IWebElement> BreadcrumbListWithFilterGet(string filter)
        {
            Report.Info($"Attempting get breadcrumb list members with '{filter}' filter.");
            List<IWebElement> result = null;
            if (BreadcrumbListExists())
            {
                result = BreadcrumbList.Where(x => x.FindElement(By.XPath(".//span[data-bind='text: `${field}: ${text}`']")).Text.Contains($"{filter}. ")).ToList();
            }
            return result;
        }

        public int BreadcrumbListWithFilterCount(string filter)
        {
            Report.Info($"Attempting to count number of breadcrumb list members with '{filter}' filter.");
            return BreadcrumbListWithFilterGet(filter).Count();
        }

        private IWebElement BreadcrumbGet(string breadcrumbLabel)
        {
            Report.Info($"Attempting to get '{breadcrumbLabel}' breadcrumb");
            return BreadcrumbList.Where(x => x.FindElement(By.XPath(".//span[data-bind='text: `${field}: ${text}`']")).Text == breadcrumbLabel).SingleOrDefault();
        }

        public bool BreadcrumbExists(string breadcrumbLabel)
        {
            Report.Info($"Attempting to confirm '{breadcrumbLabel}' breadcrumb exists.");
            return BreadcrumbGet(breadcrumbLabel) != null;
        }

        private IWebElement BreadcrumbCloseButtonGet(string breadcrumbLabel)
        {
            Report.Info($"Attempting to get '{breadcrumbLabel}' breadcrumb close button.");
            return BreadcrumbGet(breadcrumbLabel).FindElement(By.XPath(".//i[@data-bind='click: remove']"), 1);
        }

        public bool BreadcrumbCloseButtonExists(string breadcrumbLabel)
        {
            Report.Info($"Attempting to confirm '{breadcrumbLabel}' breadcrumb close button exists.");
            return BreadcrumbCloseButtonGet(breadcrumbLabel) != null;
        }

        public bool BreadcrumbClose(string breadcrumbLabel)
        {
            Report.Info($"Attempting to close '{breadcrumbLabel}' breadcrumb.");
            bool result = false;
            if(BreadcrumbCloseButtonExists(breadcrumbLabel))
            {
                result = BreadcrumbCloseButtonGet(breadcrumbLabel).TryClick();
            }
            return result;
        }
        #endregion

        // Cards
        #region Cards
        private bool CardListExists()
        {
            Report.Info("Attempting to confirm card list exists.");
            return CardList != null;
        }

        public int CardListCount()
        {
            Report.Info("Attempting to count the number of cards in card list.");
            int result = 0;
            if (CardListExists())
            {
                result = CardList.Count();
            }
            return result;
        }

        private IWebElement CardGet(string cardLabel)
        {
            Report.Info($"Attempting to get '{cardLabel}' card");
            return CardList.Where(x => x.FindElement(By.XPath(".//h6[contains(@class,'card-subtitle')]")).Text == cardLabel).SingleOrDefault();
        }

        public bool CardExists(string cardLabel)
        {
            Report.Info($"Attempting to confirm '{cardLabel}' card exists.");
            return CardGet(cardLabel) != null;
        }

        public bool CardHoverTooltipExists(string cardLabel)
        {
            Report.Info($"Attempting to confirm '{cardLabel}' card tooltip exists.");
            bool result = false;
            if (CardExists(cardLabel))
            {
                IWebElement iCard = CardGet(cardLabel);
                iCard.Hover();
                result = iCard.GetAttribute("aria-describedby") != null;
            }
            return result;
        }

        public string CardHoverToolTipGet(string cardLabel)
        {
            Report.Info($"Attempting to get '{cardLabel}' card tooltip test.");
            string result = null;
            if (CardHoverTooltipExists(cardLabel))
            {
                result = CardGet(cardLabel).GetAttribute("data-original-title");
            }
            return result;
        }

        private IWebElement CardCountGet(string cardLabel)
        {
            Report.Info($"Attempting to get '{cardLabel}' card count element.");
            IWebElement result = null;
            if (CardExists(cardLabel))
            {
                result = CardGet(cardLabel).FindElement(By.XPath(".//span[@data-bind='text: count']"), 1);
            }
            return result;
        }

        public bool CardCountExists(string cardLabel)
        {
            Report.Info($"Attempting to confirm '{cardLabel}' card count exits.");
            return CardCountGet(cardLabel) != null;
        }

        public string CardCountGetValue(string cardLabel)
        {
            Report.Info($"Attempting to get '{cardLabel}' card count string.");
            string result = null;
            if (CardCountExists(cardLabel))
            {
                result = CardCountGet(cardLabel).Text;
            }
            return result;
        }

        private IWebElement CardGrowthGet(string cardLabel)
        {
            Report.Info($"Attempting to get '{cardLabel}' card growth element.");
            IWebElement result = null;
            if (CardExists(cardLabel))
            {
                result = CardGet(cardLabel).FindElement(By.XPath(".//span[@data-bind='text: count']"), 1);
            }
            return result;
        }

        public bool CardGrowthExists(string cardLabel)
        {
            Report.Info($"Attempting to confirm '{cardLabel}' card growth exists.");
            return CardGrowthGet(cardLabel) != null;
        }

        public string CardGrowthGetValue(string cardLabel)
        {
            Report.Info($"Attempting to get '{cardLabel}' card growth value.");
            string result = null;
            if (CardGrowthExists(cardLabel))
            {
                result = CardGrowthGet(cardLabel).Text;
            }
            return result;
        }

        public bool CardGrowthHasClass(string cardLabel, string classString)
        {
            Report.Info($"Attempting to confirm if '{cardLabel}' card growth has '{classString}' class.");
            bool result = false;
            if (CardGrowthExists(cardLabel))
            {
                result =  CardGrowthGet(cardLabel).GetAttribute("class").Contains(classString);
            }
            return result;
        }
        #endregion

        #endregion
    }
    /*
    class SuperTableBreadcrumb : SeleniumBaseObject
    {
        #region Page Objects
        protected override By ContainerElementLocator => By.XPath(@"//div[@class='filter-breadcrumbs']//span[@class]");
        private string breadcrumbLabel => ContainerElement.FindElement(By.XPath(".//span[data-bind='text: `${field}: ${text}`']"),1).Text;
        private IWebElement breadcrumbCloseButton => ContainerElement.FindElement(By.XPath(".//i[@data-bind='click: remove']"), 1);
        #endregion

        #region Methods
        public bool breadcrumbLabelContains(string labelText)
        {
            Report.Info($"Attempting to confrim breadcrumb label contains '{labelText}'.");
            return breadcrumbLabel.Contains(labelText);
        }

        public bool breadcrumbCloseButtonClick()
        {
            Report.Info("Attempting to click breadcrumb close button.");
            return breadcrumbCloseButton.TryClick();
        }
        #endregion
    }
    */
    class SuperTableFooter : SeleniumBaseObject
    {
        #region Page Objects
        protected override By ContainerElementLocator => By.XPath("tfoot");
        private IWebElement RowsPerPageSelector => ContainerElement.FindElement(By.XPath(".//select[@title]"), 1);
        private List<IWebElement> RowsPerPageSelectorOptionsList => RowsPerPageSelector.FindElements(By.XPath(".//option"), 1).ToList();
        #endregion

        #region Methods
        #region Rows Per Page Selector
        public bool RowsPerPageSelectorExists()
        {
            Report.Info($"Attempting to confirm Rows Per Page Selector exists.");
            return RowsPerPageSelector != null;
        }

        public bool RowsPerPageSelectorClick()
        {
            Report.Info($"Attempting to click Rows Per Page Selector.");
            bool result = false;
            if (RowsPerPageSelectorExists())
            {
                result = RowsPerPageSelector.TryClick();
            }
            return result;
        }

        private IWebElement RowsPerPageSelectorOptionGet(string optionLabel)
        {
            Report.Info($"Attempting to get Rows Per Page selector '{optionLabel}' option.");
            return RowsPerPageSelector.FindElement(By.XPath($".//option[@text = {optionLabel}]"), 1);
        }
        #endregion

        #region Pagiator Buttons
        private IWebElement PagiatorButtonGet(string buttonLabel)
        {
            Report.Info($"Attempting to get '{buttonLabel}' pagiator button.");
            return ContainerElement.FindElement(By.XPath($".//button[@title = {buttonLabel}]"), 1);
        }

        public bool PagiatorButtonExists(string buttonLabel)
        {
            Report.Info($"Attempting to confirm '{buttonLabel}' pagiator button exists.");
            return PagiatorButtonGet(buttonLabel) != null;
        }

        public bool PagiatorButtonClick(string buttonLabel)
        {
            Report.Info($"Attempting to click '{buttonLabel}' pagiator button.");
            bool result = false;
            if(PagiatorButtonExists(buttonLabel))
            {
                result = PagiatorButtonGet(buttonLabel).TryClick();
            }
            return result;
        }
        #endregion

        #region Page Indicies
        private IWebElement PagiatorPageIndicySpanGet(string spanLabel)
        {
            Report.Info($"Attempting to get '{spanLabel}' Page Indicy span.");
            return ContainerElement.FindElement(By.XPath($".//span[contains(@data-bind,'{spanLabel}')]"), 1);
        }

        public bool PagiatorPageIndicySpanExists(string spanLabel)
        {
            Report.Info($"Attempting to confirm '{spanLabel}' Page Indicy span exists.");
            return PagiatorPageIndicySpanGet(spanLabel) != null;
        }

        public string PagiatorPageIndicySpanGetValue(string spanLabel)
        {
            Report.Info($"Attempting to get '{spanLabel}' Page Indicy span value.");
            string result = null;
            if (PagiatorPageIndicySpanExists(spanLabel))
            {
                result = PagiatorPageIndicySpanGet(spanLabel).Text;
            }
            return result;
        }
        #endregion

        #endregion
    }

    class SuperTableDataGrid : SeleniumBaseObject
    {
        #region Page Objects
        protected override By ContainerElementLocator => By.Id("gview_dataGrid");
        #endregion

        #region Methods

        #endregion
    }
}
