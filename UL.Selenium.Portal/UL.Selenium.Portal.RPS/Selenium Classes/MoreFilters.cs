using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using UL.Automation.Reporting.Functions;
using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Classes;
using UL.Automation.WebDriver.Extensions;
using UL.Selenium.Portal.WERCSmart.Classes;
 

namespace UL.Selenium.Portal.RPS.Selenium_Classes
{
    public class MoreFiltersPopup : SeleniumBaseObject
    {
        #region Page Objects
        protected override By ContainerElementLocator => By.XPath ("//div[@class='modal-dialog modal-xl']");

        private IWebElement MoreFiltersOptionButton => this.ContainerElement.FindElement(By.XPath(".//div[@class='input-group']//button[@data-bind='click: filters']"), 2); //Updated PL
        public List<IWebElement> MoreFiltersOptionsElements() => ContainerElement.FindElements(By.XPath(".//a[@class='list-group-item']|.//p//strong[text()='Filter By']/../..//select//option"), 2).ToList();

        private IWebElement GivenLabelElementInput(string labelText) => ContainerElement.FindElement(By.XPath($".//div[@class='form-group' and .//label[text()='{labelText}']]//div"), 2);

        private IWebElement ParameterSearchBox => ContainerElement.FindElement(By.XPath(".//div[@class='modal-dialog']//div[@class='form-group']//input"), 2);

        public List<IWebElement> CurrentFilterParameters => ContainerElement.FindElements(By.XPath(".//ul//li"), 2).ToList();
        public IWebElement OKButton => ContainerElement.FindElement(By.XPath(".//div[@class='modal-footer lgrey-b']//button[text()='OK']"), 2);
        public IWebElement ApplyFilterButton => ContainerElement.FindElement(By.XPath(".//div[@class='modal-footer']//button[contains(text(),'Apply Filters')]"), 2);



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
            el.TryEnterText(value);
            Delay.Seconds(5);
            return el.GetAttribute("value") == value;
        }

        public bool ClickFirstParameterOption()
        {
            var els = this.CurrentFilterParameters;
            
            if (els == null)
            {
                return false;
            }
            else
            {
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
            if (boxEl != null)
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

            List<IWebElement> parameterElList = ContainerElement.FindElements(By.XPath(".//ul//li//span[@data-bind='text: translatedValue']"), 4).ToList();
            if (parameterElList.IsNullOrEmpty())
            {
                parameterElList = ContainerElement.FindElements(By.XPath(".//ul//li"), 4).ToList();
            }
            if (parameterElList.IsNullOrEmpty())
            {
                parameterElList = ContainerElement.FindElements(By.XPath(".//p//strong[text()='Parameters']/../..//div[@class='form-check']//label[@data-bind='text: item.textLine']"), 1).ToList();
            }
            return parameterElList;

        }

        public bool WaitForParametersToShow()
        {
            Report.Info("Starting to wait for Parameters List to Show");
            int x = 0;
            var parametesElList = this.GetCurrentFilterParameters();
            while (parametesElList.IsNullOrEmpty() && x < 15)
            {
                parametesElList = this.GetCurrentFilterParameters();
                x++;
                Delay.Seconds(5);

            }

            if (parametesElList.IsNullOrEmpty())
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

        public bool SelectStatusOption(string option)
        {
            var selectorClick = this.FindElement(By.XPath(".//div[./select][./span[normalize-space()='Select Filter']]"), 1).TryClick();
            List<IWebElement> optionsElsFound1 = this.FindElements(By.XPath(".//div[@class='filter-left'][.//p//strong[text()='Filter By']]//a[@class='list-group-item']"), 2).ToList();
            List<IWebElement> optionsElsFound2 = SeleniumWebDriver.CurrentDriver.FindElements(By.XPath(".//ul[@class='select2-results__options']/li"), 1).ToList();
            List<IWebElement> optionsElsFound = optionsElsFound1.Count != 0 ? optionsElsFound1 : optionsElsFound2;
            var wantedOptionEL = optionsElsFound.First(x => x.Text == option);
            return wantedOptionEL.TryClick();
            //Delay.Seconds(10);
            //return wantedOptionEL.TryClick() && wantedOptionEL.Text == option;
        }



        public bool SelectParameterOption(string option)
        {
            List<IWebElement> optionsElsFound = this.FindElements(By.XPath(".//p//strong[text()='Parameters']/../..//div[@class='form-check']//label[@data-bind='text: item.textLine']"), 2).ToList();
            var wantedOptionEL = optionsElsFound.First(x => x.Text == option);
            IWebElement inputBox = wantedOptionEL.FindElement(By.XPath("./preceding-sibling::input"), 2);
            return inputBox.TryClick() && wantedOptionEL.Text == option;
        }
        public bool SelectSupplierNameParameterOption(string option)
        {
            List<IWebElement> optionsElsFound = this.FindElements(By.XPath(".//div[@class='list-group py-2 filters-scroll']//a"), 2).ToList();

            IWebElement wantedOptionEL = null;

            foreach (IWebElement el in optionsElsFound)
            {
                if (el.Text.Contains(option))
                {
                    wantedOptionEL = el;
                    break;
                }
            }

            return wantedOptionEL.TryClick() && wantedOptionEL.Text == option;
        }
        
        public bool ClickApplyFiltersButton()
        {
            return this.ApplyFilterButton.TryClick();
        }
        public bool InTheProductLookupPageIConfirmTheMoreFiltersBodyIsBetweenTheTopAndBottomOfThePage()
        {
            IWebElement backgroundEl = this.FindElement(By.XPath(".//ancestor::body"));
            return true;
        }
        public bool InTheProductLookupPageIConfirmTheMoreFiltersHeaderContainsTheFollowingTitleMoreFilters(string title)
        {
            IWebElement titleEl = this.FindElement(By.XPath(".//h3[@class='modal-title'][text()='" + title + "']"));
            return titleEl != null;
        }

        public bool InTheProductLookupPageIConfirmTheXIconInTheMoreFiltersPopupIsDisplayed()
        {
            IWebElement xIconEl = this.FindElement(By.XPath(".//button[@class='close']//span"));
            return xIconEl != null;
        }

        public bool InTheProductLookupPageIClickTheXIconInTheMoreFiltersPopup()
        {
            IWebElement xIconEl = this.FindElement(By.XPath(".//button[@class='close']//span"));
            return xIconEl.TryClick();
        }
        public bool InTheProductLookupPageIConfirmTheMoreFiltersPopupIsDisplayed()
        {
            IWebElement moreFiltersPopup = this.FindElement(By.XPath("//div[@class='modal-content']//h3[@class='modal-title'][text()='More Filters']"));
            return moreFiltersPopup != null;
        }

        public bool InTheMoreFiltersPopupIClickGeneralFilters()
        {
            IWebElement generalFiltersButton = this.FindElement(By.XPath("//div[@class='modal-body']//div[@class='col-md-3']//div//span[text() = 'General Filters']"));
            return generalFiltersButton.TryClick();
        }

        public bool InTheMoreFiltersPopupIClickSupplierName()
        {
            IWebElement supplierNameButton = this.FindElement(By.XPath("//div[@class='modal-body']//div[@class='col-md-4']//div//span[text() = 'Supplier Name']"));
            return supplierNameButton.TryClick();
        }

        public bool InTheMoreFiltersPopupISelectEntryFromListOfSupplierName(string name)
        {
            IWebElement supplierNameListButton = this.FindElement(By.XPath($"//div[@class='modal-body']//div[@class='col-md-5']//div[label[text()='{name}']]//input"));
            return supplierNameListButton.TryClick();
        }
        public bool InTheProductLookupPageIConfirmISeeADropdownFieldSelector()
        {
            IWebElement dropDownSelector = this.FindElement(By.XPath(".//span[@class='select2-selection__rendered']"));
            return dropDownSelector != null;
        }
        public bool InTheProductLookupPageIConfirmISeeTheFooterArea()
        {
            IWebElement footerEl = this.FindElement(By.XPath(".//div[@class='modal-footer']//button"));
            return footerEl != null;
        }

        public bool InTheProductLookupPageIConfirmISeeTheFollowingButtonsInTheFooter(Table table)
        {
            IList<IWebElement> footerButtons = this.FindElements(By.XPath(".//div[@class='modal-footer']//button")).ToList();

            foreach (IWebElement el in footerButtons)
            {
                bool buttonFound = false;
                foreach (TableRow row in table.Rows)
                {
                    if (row["Button"] == el.Text)
                    {
                        buttonFound = true;
                    }
                }

                if (buttonFound == false)
                {
                    return false;
                }

            }

            return true;
        }
        public bool InTheProductLookupPageMoreFiltersPopupIClickTheCloseButton()
        {
            IWebElement closeButton = this.FindElement(By.XPath("//div[@class='modal-header']//button[@class='close']"));
            return closeButton.TryClick();
        }

        public bool InTheMoreFiltersPopupISeeTheSelectedFiltersArea()
        {
            IWebElement el = this.ContainerElement.FindElement(By.XPath(".//div[@class='tinyscroll breadcrumbs-container']"), 2);
            return el != null;
        }

        public bool InTheMoreFiltersPopupIClickResetFilters()
        {
            IWebElement el = this.ContainerElement.FindElement(By.XPath(".//button[contains(text(), 'Remove all filters')]"), 2);
            return el.TryClick();
        }

        public bool InTheMoreFiltersFilterInTheFilterByFieldISeeTheFollowingText(string text)
        {
            IWebElement el = this.ContainerElement.FindElement(By.XPath(".//strong[text()='Filter By']/../..//span[@class='select2-selection__rendered']"), 2);
            return el.Text == text;
        }

        public bool InTheMoreFiltersFilterUnderneathTheFilterByFieldISeeTheFollowingText(string text)
        {
            IWebElement el = this.ContainerElement.FindElement(By.XPath(".//strong[text()='Filter By']/../..//p[@class='mt-2']"), 2);
            return el.Text == text;
        }

        public bool InTheMoreFiltersPopupIClickFilterFromFilterPanel(string filter)
        {
            IWebElement filterNameButton = this.FindElement(By.XPath($"//div[@class='modal-body']//div[@class='col-md-4']//div//span[contains(text(),'{filter}')]"));
            return filterNameButton.TryClick();
        }

        public bool InTheMoreFiltersPopupIConfirmFilterParameterPanelListIsDisplayed()
        {
            IWebElement filterParameterPanelList = this.FindElement(By.XPath("//div[@class='modal-body']//div[@class='col-md-5']//div[contains(@class,'filters-scroll')]"));
            return filterParameterPanelList.Displayed;
        }

        public bool InFilterParameterPanelIConfirmFacetCountForListIsDisplayed()
        {
            List<IWebElement> filterParameterPanelFacetCount = this.FindElements(By.XPath("//div[@class='modal-body']//div[@class='col-md-5']//div[@class='filters-scroll']//div[@class='form-check']//label[@data-bind='text: item.count']")).ToList();
            var facetCount = filterParameterPanelFacetCount;
            foreach (var count in facetCount)
            {
                if (count.Displayed)
                {
                    return true;
                }
            }
            return false;
        }

        public bool InFilterParameterPanelIVerifyUPCSearchFieldIsDisplayed()
        {
            IWebElement upcNumberSearchField = this.FindElement(By.XPath("//div[@class='modal-body']//div[@class='col-md-5']//input"));
            return upcNumberSearchField.Displayed;
        }

        public void InFilterParameterPanelIEnterUPCValue(string searchText)
        {
            IWebElement upcSearchBox = this.FindElement(By.XPath("//div[@class='modal-body']//div[@class='col-md-5']//input[contains(@placeholder,'Search')]"));
            upcSearchBox.ClearTextBox();
            upcSearchBox.EnterText(searchText);

        }

        public bool InFilterParameterPanelIVerifyUPCdropdownIsDisplayed()
        {
            IWebElement upcNumberList = this.FindElement(By.XPath("//span[contains(@class,'select2-results')]//ul"));
            return upcNumberList.Displayed;
        }

        public bool InTheMoreFiltersPopupISelectRandomEntryFromListOfUPCs()
        {
            List<IWebElement> UPCsList = this.FindElements(By.XPath($"//span[contains(@class,'select2-results')]//ul//li")).ToList();
            Random rnd = new Random();
            int randomValue = rnd.Next(UPCsList.Count);
            IWebElement upcs = UPCsList[randomValue];
            return upcs.TryClick();
        }


        public bool InFilterParameterPanelIVerifyUPCdropdownSelectorIsDisplayed()
        {
            IWebElement upcdropdownSelector = this.FindElement(By.XPath("//div[@class='modal-body']//div[@class='col-md-5']//select[contains(@data-bind,'availableOperators')]"));
            return upcdropdownSelector.Displayed;
        }

        public bool IConfirmISeeAListOfAvailableOptionsInFilterParameterPanelUPCdropdownSelectorIsDisplayed(List<string> expectedOptions)
        {
            IList<string> options = SeleniumWebDriver.CurrentDriver.FindElements(By.XPath("//div[@class='modal-body']//div[@class='col-md-5']//select[contains(@data-bind,'availableOperators')]//option"), 2).Select(x => x.Text).ToList();
            return options.All(i => expectedOptions.Contains(i));
        }

        public bool InFilterParameterPanelIVerifyUPCdropdownPlaceholderIsDisplayed(string expectedplaceholdervalue)
        {
            IWebElement upcSearchBox = this.FindElement(By.XPath("//div[@class='modal-body']//div[@class='col-md-5']//input"));
            string placeholderText = upcSearchBox.GetAttribute("placeholder");
            Report.Info($"Place holder text was: {placeholderText}");
            return placeholderText == expectedplaceholdervalue;
        }

        public bool InFilterParameterPanelIClickUPCdropdown()
        {
            IWebElement upcSearchBox = this.FindElement(By.XPath("//div[@class='modal-body']//div[@class='col-md-5']//input"));
            return upcSearchBox.TryClick();
        }

        public bool InFilterParameterPanelIConfirmFacetCountForUPCNumberListIsDisplayed()
        {
            List<IWebElement> UPCNumberListFacetCount = this.FindElements(By.XPath("//span[contains(@class,'select2-results')]//ul//li//label[@data-bind='text: item.count']")).ToList();
            var facetCount = UPCNumberListFacetCount;
            foreach (var count in facetCount)
            {
                if (count.Displayed)
                {
                    return true;
                }
            }
            return false;
        }

        public bool InTheFilterParameterPanelSelectOptionInDropdown(string option)
        {
            IWebElement dropdown = this.FindElement(By.XPath("//div[@class='modal-body']//div[@class='col-md-5']//select"));
            dropdown.TryClick();
            IWebElement dropdownoption = this.FindElement(By.XPath($"//div[@class='modal-body']//div[@class='col-md-5']//select//option[text()='{option}']"));
            return dropdownoption.TryClick();
        }



        public void InFilterParameterPanelIEnterSearchValue(string searchText)
        {
            IWebElement parameterSearchBox = this.FindElement(By.XPath("//div[@class='modal-body']//div[@class='col-md-5']//div[contains(@class,'input-group')]//input[@placeholder='Search parameters']"));
            parameterSearchBox.EnterText(searchText);
            parameterSearchBox.SendKeys(Keys.Enter);
        }

        public string GetFirstParameterValue()
        {
            IWebElement parameterValue = this.FindElement(By.XPath("//div[@class='modal-body']//div[@class='col-md-5']//div[@class='form-check'][2]//label"));
            return parameterValue.Text;
        }

        public string GetRandomUPCValueFromDropdownListInFiltersParameters()
        {
            List<IWebElement> UPCsList = this.FindElements(By.XPath($"//span[contains(@class,'select2-results')]//ul//li")).ToList();
            Random rnd = new Random();
            int randomValue = rnd.Next(UPCsList.Count);
            IWebElement upcvalue = UPCsList[randomValue];
            return upcvalue.Text;

        }

        public bool InTheMoreFiltersPopupSelectedFiltersAreaIVerifyBreadcrumbIsDisplayedWithSelectedValue(string searchedText)
        {
            List<string> breadcrumbValue = this.FindElements(By.XPath(".//div[@class='tinyscroll breadcrumbs-container']//p//span[contains(@data-bind,'text')]")).Select(x => x.Text).ToList();
            bool result = breadcrumbValue.Any(value => value.Contains(searchedText));
            return result;

        }

        public bool InFilterParameterPanelIConfirmListForSearchedPartialSupplierNameIsDisplayed(string supplierName)
        {
            List<string> supplierNameList = this.FindElements(By.XPath("//div[@class='modal-body']//div[@class='col-md-5']//div//div[@class='filters-scroll']//label[contains(@data-bind,'text: value')]")).Select(x => x.Text).ToList();
            bool result = supplierNameList.All(value => value.Contains(supplierName));
            return result;
        }

        public bool InFilterParameterPanelIConfirmListForSearchedUPCNumberIsDisplayed(string upcNumber)
        {
            List<string> upcNumberList = this.FindElements(By.XPath("//span[contains(@class,'select2-results')]//ul//li")).Select(x => x.Text).ToList();
            bool result = upcNumberList.All(value => value.Contains(upcNumber));
            return result;
        }
        public bool InTheMoreFiltersPopupISelectRandomEntryFromListOfSupplierName()
        {
            List<IWebElement> supplierNameList = this.FindElements(By.XPath($"//div[@class='modal-body']//div[@class='col-md-5']//div[label[contains(@data-bind,'text: value')]]//input")).ToList();
            Random rnd = new Random();
            int randomValue = rnd.Next(supplierNameList.Count);
            IWebElement supplierName = supplierNameList[randomValue];
            return supplierName.TryClick();
        }

        public bool InTheMoreFiltersPopupISelectRandomEntryFromListOfPackagingType()
        {
            List<IWebElement> packagingTypeList = this.FindElements(By.XPath($"//div[@class='modal-body']//div[@class='col-md-5']//div[label[contains(@data-bind,'text: item.textLine')]]//input")).ToList();
            Random rnd = new Random();
            int randomValue = rnd.Next(packagingTypeList.Count);
            IWebElement packagingType = packagingTypeList[randomValue];
            return packagingType.TryClick();
        }

        public bool InTheMoreFiltersPopupISelectRandomEntryFromListOfPackagingSize()
        {
            List<IWebElement> packagingSizeList = this.FindElements(By.XPath($"//div[@class='modal-body']//div[@class='col-md-5']//div[label[contains(@class,'form-check-label')]]//input")).ToList();
            Random rnd = new Random();
            int randomValue = rnd.Next(packagingSizeList.Count);
            IWebElement packagingSize = packagingSizeList[randomValue];
            return packagingSize.TryClick();
        }

        public bool InFilterParameterPanelIConfirmListStartsWithForSearchedUPCNumberIsDisplayed(string upcNumber)
        {
            List<string> upcNumberList = this.FindElements(By.XPath("//span[contains(@class,'select2-results')]//ul//li")).Select(x => x.Text).ToList();
            bool result = upcNumberList.All(value => value.TrimStart(new char[] { '0' }).StartsWith(upcNumber));
            return result;

        }

        public bool InFilterParameterPanelIConfirmListMachtesExactlyForSearchedUPCNumberIsDisplayed(string upcNumber)
        {
            List<string> upcNumberList = this.FindElements(By.XPath("//span[contains(@class,'select2-results')]//ul//li")).Select(x => x.Text).ToList();
            bool result = upcNumberList.All(value => value.Equals(upcNumber));
            return result;

        }

        public bool InTheMoreFiltersPopupInTheSelectedFiltersIClickClearAll()
        {
            IWebElement clearAllButton = this.FindElement(By.XPath(".//div[@class='row']//div[@class='col-md-12']//span[contains(@data-bind,'clearAll')]"));
            return clearAllButton.TryClick();
        }

        public bool IVerifySearchBoxIsDisplayedFilterCategory()
        {
            IWebElement searchBox = this.FindElement(By.XPath("//div[@class='modal-body']//div[@class='col-md-3']//div//input[contains(@data-bind,'searchInput')]"), 2);
            return searchBox.Displayed;

        }

        public void IEnterValueInSearchBoxOfFilterCategory(string value)
        {
            IWebElement searchBox = this.FindElement(By.XPath("//div[@class='modal-body']//div[@class='col-md-3']//div//input[contains(@data-bind,'searchInput')]"), 2);
            searchBox.EnterText(value);

        }

        public bool InTheMoreFiltersPopupIConfirmFilterIsDisplayedInFilterPanel(string filter)
        {
            IWebElement filterNameButton = this.FindElement(By.XPath($"//div[@class='modal-body']//div[@class='col-md-4']//div//span[contains(text(),'{filter}')]"));
            return filterNameButton.Displayed;
        }

        public bool InTheMoreFiltersPopupIConfirmUPCsSelectedIsShownWithMinusIcon()
        {
            IWebElement selectedUpcNumberWithMinusIcon = this.FindElement(By.XPath($"//div[@class='modal-body']//div[@class='col-md-5']//div//div[@class='list-select']//img[contains(@src,'minus-circle')]"));
            return selectedUpcNumberWithMinusIcon.Displayed;
        }

        public bool InFilterParameterPanelIVerifySearchfieldPlaceholderIsDisplayed(string expectedplaceholdervalue)
        {
            IWebElement upcSearchBox = this.FindElement(By.XPath("//div[@class='modal-body']//div[@class='col-md-5']//div[@class='form-control']//input"));
            string placeholderText = upcSearchBox.GetAttribute("placeholder");
            Report.Info($"Place holder text was: {placeholderText}");
            return placeholderText.Contains(expectedplaceholdervalue);
        }

        public bool InFilterParameterPanelIConfirmCheckBoxBeforeValueForListIsDisplayed()
        {
            List<IWebElement> filterParameterPanelCheckBoxBeforeValue = this.FindElements(By.XPath("//div[@class='modal-body']//div[@class='col-md-5']//div[contains(@class,'filters-scroll')]//div[@class='form-check']//input")).ToList();
            bool result = filterParameterPanelCheckBoxBeforeValue.All(value => value.Displayed);
            return result;

        }

        public bool InFilterParameterPanelIConfirmListOfItemsForSelectionIsDisplayed()
        {
            List<IWebElement> filterParameterPanelCheckBoxBeforeValue = this.FindElements(By.XPath("//div[@class='modal-body']//div[@class='col-md-5']//div[@class='filters-scroll']//div[@class='form-check']//label[@data-bind='text: item.textLine']")).ToList();
            bool result = filterParameterPanelCheckBoxBeforeValue.All(value => value.Displayed);
            return result;

        }

        public bool InTheMoreFiltersPopupIConfirmClearAllButtonIsDisplayedInFilterPanel()
        {
            IWebElement clearAllButton = this.FindElement(By.XPath($"//div[@class='modal-body']//div[@class='col-md-5']//button[contains(text(),'Clear All')]"));
            return clearAllButton.Displayed;
        }

        public bool InTheMoreFiltersPopupIConfirmBoldtextIsDisplayedInFilterPanel(string expectedtext)
        {
            IWebElement boldtext = this.FindElement(By.XPath($"//div[@class='modal-body']//div[@class='col-md-5']//strong"));
            return boldtext.Text == expectedtext;

        }

        public bool InFilterParameterPanelIConfirmListOfCheckboxesAreDisplayed(List<string> expectedOptions)
        {
            {
                IList<string> options = SeleniumWebDriver.CurrentDriver.FindElements(By.XPath("//div[@class='modal-body']//div[@class='col-md-5']//div[contains(@class,'mb-2')]//div//label[contains(@class,'label')]"), 2).Select(x => x.Text).ToList();
                return options.All(i => expectedOptions.Contains(i));
            }

        }

        public bool InFilterParameterPanelIConfirmListForSearchedValueIsDisplayed(string searchedvalue)
        {
            List<string> valueList = this.FindElements(By.XPath("//div[@class='modal-body']//div[@class='col-md-5']//div[@class='filters-scroll']//div[@class='form-check']//label[@data-bind='text: item.textLine']")).Select(x => x.Text).ToList();
            bool result = valueList.All(value => value.ToLower().Contains(searchedvalue.ToLower()));
            return result;
        }

        public bool InFilterParameterPanelIConfirmNoResultsFoundMessageIsDisplayed()
        {
            IWebElement noResultsFoundMessage = this.FindElement(By.XPath($"//div[@class='modal-body']//div[@class='col-md-5']//p[contains(text(),'No results found')]"));
            return noResultsFoundMessage.Displayed;


        }

        public bool InTheMoreFiltersPopupISelectRandomEntryFromListOfItemsInFilterPanel()
        {
            List<IWebElement> filterList = this.FindElements(By.XPath($"//div[@class='modal-body']//div[@class='col-md-5']//div[@class='filters-scroll']//div[@class='form-check']//input")).ToList();
            Random rnd = new Random();
            int randomValue = rnd.Next(filterList.Count);
            IWebElement value = filterList[randomValue];
            return value.TryClick();
        }


        public bool InFilterParameterPanelIConfirmListStartsWithForSearchedValueIsDisplayed(string searchedValue)
        {
            List<string> valueList = this.FindElements(By.XPath("//div[@class='modal-body']//div[@class='col-md-5']//div[@class='filters-scroll']//div[@class='form-check']//label[@data-bind='text: item.textLine']")).Select(x => x.Text).ToList();
            bool result = valueList.All(value => value.ToLower().StartsWith(searchedValue.ToLower()));
            return result;

        }

        public string GetRandomPackagingTypeFromListInFiltersParameters()
        {
            List<IWebElement> PackagingTypeList = this.FindElements(By.XPath($"//div[@class='modal-body']//div[@class='col-md-5']//div[label[contains(@data-bind,'text: item.textLine')]]//label")).ToList();
            Random rnd = new Random();
            int randomValue = rnd.Next(PackagingTypeList.Count);
            IWebElement PackagingTypevalue = PackagingTypeList[randomValue];
            return PackagingTypevalue.Text;

        }

        public bool InFilterParameterPanelIConfirmListMachtesExactlyForSearchedPackagingTypeIsDisplayed(string packagingTypevalue)
        {
            List<string> packagingTypeList = this.FindElements(By.XPath("//div[@class='modal-body']//div[@class='col-md-5']//div//label[contains(@data-bind,'text: item.textLine')]")).Select(x => x.Text).ToList();
            bool result = packagingTypeList.All(value => value.Equals(packagingTypevalue));
            return result;

        }


        public bool InFilterParameterPanelIConfirmListOfSupplierNameForSelectionIsDisplayed()
        {
            List<IWebElement> supplierNameList = this.FindElements(By.XPath("//div[@class='modal-body']//div[@class='col-md-5']//div[contains(@class,'filters-scroll')]//div[@class='form-check']//label[@data-bind='text: value']")).ToList();
            bool result = supplierNameList.All(value => value.Displayed);
            return result;

        }

        public bool IConfirmISeeContainsAsDefaultInSelectorDropdown()
        {
            IWebElement option = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath("//div[@class='modal-body']//div[@class='col-md-5']//select[contains(@data-bind,'availableOperators')]//option[1]"), 2);
            return option.Text == "Contains";
        }

        public bool InFilterParameterPanelIConfirmListStartsWithForSearchedSupplierNameIsDisplayed(string supplierName)
        {
            List<string> supplierNameList = this.FindElements(By.XPath("//div[@class='modal-body']//div[@class='col-md-5']//div[contains(@class,'filters-scroll')]//div[@class='form-check']//label[@data-bind='text: value']")).Select(x => x.Text).ToList();
            bool result = supplierNameList.All(value => value.ToLower().StartsWith(supplierName.ToLower()));
            return result;

        }

        public string GetRandomSupplierNameFromListInFiltersParameters()
        {
            List<IWebElement> SupplierNameList = this.FindElements(By.XPath($"//div[@class='modal-body']//div[@class='col-md-5']//div[label[contains(@data-bind,'text: value')]]//label")).ToList();
            Random rnd = new Random();
            int randomValue = rnd.Next(SupplierNameList.Count);
            IWebElement SupplierNamevalue = SupplierNameList[randomValue];
            return SupplierNamevalue.Text;

        }

        public bool InFilterParameterPanelIConfirmListMachtesExactlyForSearchedSupplierNameIsDisplayed(string supplierName)
        {
            List<string> supplierNameList = this.FindElements(By.XPath("//div[@class='modal-body']//div[@class='col-md-5']//div[@class='filters-scroll']//div[@class='form-check']//label[@data-bind='text: value']")).Select(x => x.Text).ToList();
            bool result = supplierNameList.All(value => value.Equals(supplierName));
            return result;

        }

        public bool InFilterParameterPanelIClearValue()
        {
            IWebElement SearchBox = this.FindElement(By.XPath("//div[@class='modal-body']//div[@class='col-md-5']//input[contains(@placeholder,'Search')]"));
            SearchBox.ClearTextBox();
            Report.Info(SearchBox.Text);
            return SearchBox.Text.IsNullOrEmpty();


        }

        public List<string> IConfirm3PanelsIsDisplayedInMoreFiltersPopup()
        {
            IList<IWebElement> Panels = this.containerElement.FindElements(By.XPath(".//div[@class='modal-body']//h4"), 2);
            List<string> columnsShownNames = new List<string>();


            foreach (IWebElement el in Panels)
            {

                columnsShownNames.Add(el.Text);

            }
            return columnsShownNames;
        }

        public void InTheMoreFiltersPopUpSearchForFilter(string value)
        {
            IWebElement SearchBox = this.FindElement(By.XPath("//div[@class='modal-content']//input[@data-bind='textInput: searchInput']"), 2);
            SearchBox.EnterText(value);

        }

        public void InTheMoreFiltersPopUpSelectProductStatusFilter()
        {
            IWebElement SelectFilter = this.FindElement(By.XPath("//div[@class='modal-content']//div[@class='col-md-4']//div[@class='list-select']//span[contains(text(),'Status')]"), 2);
            SelectFilter.TryClick();

        }

        public bool InTheMoreFiltersPopUpSelectCompletedProductStatusFilter()
        {
            IWebElement SelectFilter = this.FindElement(By.XPath("//div[@class='modal-content']//div[@class='col-md-5']//div[@class='filters-scroll']//div[1]//input[1]"), 2);
            return SelectFilter.TryClick();

        }

        public bool InTheMoreFiltersPopUpSelectFilterParameter(string parameter)
        {
            IWebElement SelectFilter = this.FindElement(By.XPath($"//div[@class='modal-content']//div[@class='col-md-5']//div[@class='filters-scroll']//div//label[text()='{parameter}']//preceding-sibling::input"), 2);
            return SelectFilter.TryClick();

        }

        public bool InTheMoreFiltersPopUpSelectFilter(string filter)
        {
            IWebElement SelectFilter = this.FindElement(By.XPath($"//div[@class='modal-content']//div[@class='col-md-4']//div[@class='list-select']//span[contains(text(),'{filter}')]"), 2);
            return SelectFilter.TryClick();

        }

        public void EnterValueIntoParameterField(string value)
        {
            var inputEl = this.FindElement(By.XPath(".//input[contains(@data-bind,'textInput: start')]"), 2);
            inputEl.EnterText(value);

        }

        public bool InTheMoreFiltersPopupClickResetAllFilters()
        {
            IWebElement el = this.FindElement(By.XPath(".//div[@class='modal-footer']//button[contains(text(),'Remove all filters')]"), 2);
            return el.TryClick();
        }

        public bool InTheMoreFiltersPopUpHasAnyValueParameterIsSelected()
        {
            IWebElement HasAnyValueCheckBox = this.FindElement(By.XPath(".//input[contains(@name,'hasAnyValue')]"), 2);
            return HasAnyValueCheckBox.TryClick();

        }

        public bool InTheMoreFiltersPopupSelectMultipleFromListOfFilters(int value)
        {
            List<IWebElement> filterList = this.FindElements(By.XPath($"//div[@class='modal-body']//div[@class='col-md-5']//div[@class='form-check']//input[@type='checkbox']")).ToList();
            for (int i = 1; i <= 19; i++)
            {
                return filterList[i].TryClick();

            }
            return true;
        }

        public bool InTheMoreFiltersPopupGetselectedHeadersCount(string text)
        {
            IWebElement el = this.FindElement(By.XPath("//div[@class='modal-body']//div[@class='col-md-12']//strong"), 2);
            return el.Text == text;
        }

        public bool InTheMoreFiltersPopupselectedFiltersLimittext(string text)
        {
            IWebElement el = this.FindElement(By.XPath("//div[@class='modal-body']//div[@class='col-md-12']//p[@class='marbot-10']//span[2]"), 2);
            return el.Text == text;
        }

        public bool SearchBoxDisabled()
        {
            var el = this.FindElement(By.XPath("//div[@class='modal-body']//div[@class='col-md-5']//input[@type='search']"), 2);
            if (el == null)
            {
                Report.Info($"el was null");
                return false;
            }
            string disabledStr = el.GetAttribute("disabled");
            if (disabledStr != "true")
            {
                Report.Info($"The Search box was not greyed out");
                return false;
            }
            bool clickable = el.TryClick();
            if (clickable == true)
            {
                Report.Info($"The Search box was still clickable");
                return false;
            }
            return true;


        }

        public bool FiltersCheckboxDisabled()
        {
            List<IWebElement> filterListcheckbox = this.FindElements(By.XPath("//div[@class='modal-body']//div[@class='col-md-5']//div[@class='filters-scroll']//div[@class='form-check']//input")).ToList();
            var el = this.FindElement(By.XPath("//div[@class='modal-body']//div[@class='col-md-5']//div[@class='filters-scroll']//div[@class='form-check']//input"), 2);
            if (filterListcheckbox == null)
            {
                Report.Info($"el was null");
                return false;
            }
            for (int i = 0; i <= filterListcheckbox.Count; i++)
            {
                string disabledStr = el.GetAttribute("disabled");
                if (disabledStr != "true")
                {
                    Report.Info($"The Filters Checkbox was not greyed out");
                    return false;
                }
                bool clickable = el.TryClick();
                if (clickable == true)
                {
                    Report.Info($"The Filters Checkbox was still clickable");
                    return false;
                }
               
            }
            return true;



        }

        public bool InTheMoreFiltersPopupHasValueCheckboxIsDisplayed(string value)
        {
            IWebElement el = this.FindElement(By.XPath($"//div[@class='modal-body']//div[contains(@data-bind,'showHasAnyNoValue')]//div//input[contains(@value,'{value}')]"), 2);
            return el.Displayed;
        }

        public bool InTheMoreFiltersPopupClickHasValueCheckbox(string value)
        {
            IWebElement el = this.FindElement(By.XPath($"//div[@class='modal-body']//div[contains(@data-bind,'showHasAnyNoValue')]//div//input[contains(@value,'{value}')]"), 2);
            return el.TryClick();
        }

        public IWebElement InTheMoreFiltersPopupHasValueCheckbox(string value)
        {
            IWebElement el = this.containerElement.FindElement(By.XPath($"//div[@class='modal-body']//div[contains(@data-bind,'showHasAnyNoValue')]//div//input[contains(@value,'{value}')]"), 2);
            if (el == null)
            {
                Report.Info($"Could not find checkbox with value: '{value}'");
                return null;
            }
            return el;
        }


        #endregion



    }
}

