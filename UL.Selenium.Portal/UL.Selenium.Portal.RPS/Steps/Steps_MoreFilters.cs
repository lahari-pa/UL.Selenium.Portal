using System.Collections.Generic;
using Reqnroll;
using UL.Automation.Reporting.Functions;
using UL.Automation.WebDriver.Classes;
using UL.Automation.ReqnrollHelpers.Classes;
using UL.Selenium.Portal.RPS.Selenium_Classes;
using System;
using System.Linq;
using UL.Automation.Reporting.Classes;
using UL.Automation.ReqnrollHelpers.Attributes;
using GeneralUtilities = UL.Selenium.Portal.RPS.Classes.GeneralUtilities;
using UL.Automation.WebDriver.Extensions;

namespace UL.Selenium.Portal.RPS.Steps
{
	[Binding, Scope(Tag = "MoreFilters")]
	class Steps_MoreFilters
    {
		 

		[RegexStepDefinition(@"In the Product Lookup Page, The More Filters Popup is showing")]
		public void InTheProductLookupPageIClickTheMoreFiltersPopupIsShowing()
		{
			Report.IsTrue(new MoreFiltersPopup().WaitForContainerToBeVisible(), "The More filters popup was not showing", "The More filters popup was showing");
		}

		[RegexStepDefinition(@"In the Product Lookup Page, The More Filters Popup is not showing")]
		public void InTheProductLookupPageIClickTheMoreFiltersPopupIsNotShowing()
		{
			Report.IsTrue(new MoreFiltersPopup().WaitForContainerToBeInvisible(), "The More filters popup was showing", "The More filters popup was not showing");
		}

		[RegexStepDefinition(@"In the Product Lookup Page More Filters Popup, I click the (.*) Filter")]
		public void InTheProductLookupMoreFiltersPageIClickFilter(string value)
		{
			Report.IsTrue(new MoreFiltersPopup().ClickFilterOption(value), "Failed to select the filter", "Successfully selected the filter");
			Delay.Seconds(3);
		}

		[RegexStepDefinition(@"In the Product Lookup Page More Filters Popup, I enter the parameter (.*)")]
		public void InTheProductLookupMoreFiltersPageIEnterParameter(string value)
		{
			Report.IsTrue(new MoreFiltersPopup().EnterParameterForSearch(value), "Failed to enter parameter", "Successfully entered parameter");
		}

		[RegexStepDefinition(@"In the Product Lookup Page More Filters Popup, I select the parameter (.*)")]
		public void InTheProductLookupMoreFiltersPageISelectParameter(string value)
		{
			new  MoreFiltersPopup().WaitForParametersToShow();
			Report.IsTrue(new MoreFiltersPopup().ClickGivenParameterOption(value), "Failed to select the parameter", "Successfully selected the parameter");
			Delay.Seconds(3);
		}

		[RegexStepDefinition(@"In the Product Lookup Page More Filters Popup, I select the first parameter")]
		public void InTheProductLookupMoreFiltersPageISelectTheFirstParameter()
		{
			Report.IsTrue(new MoreFiltersPopup().ClickFirstParameterOption(), "Failed to select the first parameter", "Successfully selected the first parameter");
		}

		[RegexStepDefinition(@"In the Product Lookup Page More Filters Popup, I Click the the OK Button")]
		public void InTheProductLookupMoreFiltersPageClickOKButton()
		{
			Report.IsTrue(new MoreFiltersPopup().ClickOKButton(), "The OK button was not clicked", "The OK button was clicked successfully");
		}
         

		[RegexStepDefinition(@"In the product lookup page More Filters Popup, I Click the the Apply Filter Button")]
		public void InTheProductLookUpPageMoreFiltersPopupClickApplyFilterButton()
		{
			Report.IsTrue(new MoreFiltersPopup().ClickApplyFiltersButton(), "The Apply Filter button was not clicked", "The Apply Filter button was clicked successfully");
			Delay.Seconds(10);
		}

		[RegexStepDefinition(@"In the product lookup page, I select the option: (.*) from the status drop down menu")]
		public void InTheProductLookUpPageISelectStatusOption(string option)
		{
			if (option.Contains("SavedProduct"))
			{
				option = (string)Context.GetFromContext(option);
			}
			Report.IsTrue(new MoreFiltersPopup().SelectStatusOption(option), "The option was not selected", "The option was selected successfully");
            Delay.Seconds(3);
		}

		[RegexStepDefinition(@"In the product lookup page, I select the option: (.*) from the parameters drop down menu")]
		public void InTheProductLookUpPageISelectParameterOption(string option)
		{
            Delay.Seconds(3);
			if (option.Contains("SavedProduct"))
			{
				option = (string)Context.GetFromContext(option);
			}
			Report.IsTrue(new MoreFiltersPopup().SelectParameterOption(option), "The option was not selected", "The option was selected successfully");
		}

        [RegexStepDefinition(@"In the product lookup page, I select the Supplier Name option: (.*) from the parameters drop down menu")]
		public void InTheProductLookUpPageISelectSupplierNameParameterOption(string option)
		{
			if (option.Contains("SavedProduct"))
			{
				option = (string)Context.GetFromContext(option);
			}
			Report.IsTrue(new MoreFiltersPopup().SelectSupplierNameParameterOption(option), "The option was not selected", "The option was selected successfully");
		}

		 

        [RegexStepDefinition(@"In the product lookup page, The More Filters Popup is showing")]
        public void InTheProductLookUpPageIClickTheMoreFiltersPopupIsShowing()
        {
            Report.IsTrue(new MoreFiltersPopup().WaitForContainerToBeVisible(), "The More filters popup was not showing", "The More filters popup was showing");
        }

        [RegexStepDefinition(@"In the product lookup page, The More Filters Popup is not showing")]
        public void InTheProductLookUpPageIClickTheMoreFiltersPopupIsNotShowing()
        {
            Report.IsTrue(new MoreFiltersPopup().WaitForContainerToBeInvisible(), "The More filters popup was showing", "The More filters popup was not showing");
        }
 

        [RegexStepDefinition(@"I confirm I (see|do not see) the bredcrumbs area under the search field")]
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

        [RegexStepDefinition(@"In the product lookup page, I confirm the More Filters body is between the top and bottom of the page")]
        public void GivenInTheProductLookupPageIConfirmTheMoreFiltersBodyIsBetweenTheTopAndBottomOfThePage()
        {
            Report.IsTrue(new MoreFiltersPopup().InTheProductLookupPageIConfirmTheMoreFiltersBodyIsBetweenTheTopAndBottomOfThePage(), $"Failed to confirm the More Filters body is between the top and bottom of the page", $"Successfully confirmed the More Filters body is between the top and bottom of the page");
        }

        [RegexStepDefinition(@"In the recent activites page, in the more filters popup I click reset all filters")]
        public void GivenInTheMoreFiltersPopupClickResetAllFilters()
        {
            Report.IsTrue(new MoreFiltersPopup().InTheMoreFiltersPopupClickResetAllFilters(), "Failed to click Remove all filters", "Successfully clicked Remove all filters");
        }

        [RegexStepDefinition(@"In the product lookup page, I confirm the More Filters header contains the following title: (.*)")]
        public void GivenInTheProductLookupPageIConfirmTheMoreFiltersHeaderContainsTheFollowingTitleMoreFilters(string title)
        {
            Report.IsTrue(new MoreFiltersPopup().InTheProductLookupPageIConfirmTheMoreFiltersHeaderContainsTheFollowingTitleMoreFilters(title), $"Failed to confirm the More Filters popup title is: " + title, $"Successfully confirmed the More Filters popup title is: " + title);
        }

        [RegexStepDefinition(@"In the product lookup page, I click the x icon in the More Filters popup")]
        public void GivenInTheProductLookupPageIClickTheXIconInTheMoreFiltersPopup()
        {
            Report.IsTrue(new MoreFiltersPopup().InTheProductLookupPageIClickTheXIconInTheMoreFiltersPopup(), $"Failed to click the x icon in the More Filters popup", $"Successfully clicked the x icon in the More Filters popup");
        }

        [RegexStepDefinition(@"In the product lookup page, I confirm the More Filters popup (is|is not) displayed")]
        public void GivenInTheProductLookupPageIConfirmTheMoreFiltersPopupIsNotDisplayed(string isOrisNot)
        {
            if (isOrisNot == "is")
            {
                Report.IsTrue(new MoreFiltersPopup().InTheProductLookupPageIConfirmTheMoreFiltersPopupIsDisplayed(), $"Failed to confirm the More Filters popup is displayed", $"Successfully confirmed the More Filters popup is displayed");
            }
            else
            {
                Report.IsTrue(new MoreFiltersPopup().InTheProductLookupPageIConfirmTheMoreFiltersPopupIsDisplayed() == false, $"Failed to confirm the More Filters popup is not displayed", $"Successfully confirmed the More Filters popup is not displayed");
            }
        }

        [RegexStepDefinition(@"In the product lookup page, I confirm I see a dropdown field selector")]
        public void GivenInTheProductLookupPageIConfirmISeeADropdownFieldSelector()
        {
            Report.IsTrue(new MoreFiltersPopup().InTheProductLookupPageIConfirmISeeADropdownFieldSelector(), $"Failed to confirm the dropdown selector is displayed", $"Successfully confirmed the dropdown selector is displayed");
        }

        [RegexStepDefinition(@"In the product lookup page, I confirm I see the footer area")]
        public void GivenInTheProductLookupPageIConfirmISeeTheFooterArea()
        {
            Report.IsTrue(new MoreFiltersPopup().InTheProductLookupPageIConfirmISeeTheFooterArea(), $"Failed to confirm the footer area is displayed in the More Filters popu", $"Successfully confirmed the footer area is displayed in the More Filters popup");
        }

        [RegexStepDefinition(@"In the product lookup page, I confirm I see the following buttons in the footer:")]
        public void GivenInTheProductLookupPageIConfirmISeeTheFollowingButtonsInTheFooter(Table table)
        {
            Report.IsTrue(new MoreFiltersPopup().InTheProductLookupPageIConfirmISeeTheFollowingButtonsInTheFooter(table), $"Failed to find all buttons in the More Filters popup", $"Successfully confirmed the all buttons were found in the More Filters popup");
        }

        [RegexStepDefinition(@"In the product lookup page More Filters Popup, I Click the Close button")]
        public void GivenInTheProductLookupPageMoreFiltersPopupIClickTheCloseButton()
        {
            Report.IsTrue(new MoreFiltersPopup().InTheProductLookupPageMoreFiltersPopupIClickTheCloseButton(), $"Failed to the clicked button in the More Filters popup", $"Successfully clicked the close button in the More Filters popup");
        }

        [RegexStepDefinition(@"In the More Filters popup I click Reset filters")]
        public void GivenInTheMoreFiltersPopupIClickResetFilters()
        {
            Report.IsTrue(new MoreFiltersPopup().InTheMoreFiltersPopupIClickResetFilters(), $"Failed to click the Reset Filters button", $"Successfully clicked the Reset Filters button");
        }

        [RegexStepDefinition(@"In the More Filters popup I (see|do not see) the Selected Filters area")]
        public void GivenInTheMoreFiltersPopupIDoNotSeeTheSelectedFiltersArea(string seeOrDoNotSee)
        {
            if (seeOrDoNotSee == "see")
            {
                Report.IsTrue(new MoreFiltersPopup().InTheMoreFiltersPopupISeeTheSelectedFiltersArea(), $"Failed to find the selected filters area", $"Successfully found the selected filters area");
            }
            else
            {
                Report.IsTrue(new MoreFiltersPopup().InTheMoreFiltersPopupISeeTheSelectedFiltersArea() == false, $"Failed to not find the selected filters area", $"Successfully did not find the selected filters area");
            }

        }

        [RegexStepDefinition(@"In the More Filters Filter in the Filter By field I see the following text: (.*)")]
        public void GivenInTheMoreFiltersFilterInTheFilterByFieldISeeTheFollowingText(string text)
        {
            Report.IsTrue(new MoreFiltersPopup().InTheMoreFiltersFilterInTheFilterByFieldISeeTheFollowingText(text), $"Failed to find text in Filter By field", $"Successfully found text in Filter By field");
        }

        [RegexStepDefinition(@"In the More Filters Filter underneath the Filter By field I see the following text: (.*)")]
        public void GivenInTheMoreFiltersFilterUnderneathTheFilterByFieldISeeTheFollowingText(string text)
        {
            Report.IsTrue(new MoreFiltersPopup().InTheMoreFiltersFilterUnderneathTheFilterByFieldISeeTheFollowingText(text) == false, $"Failed to find text underneath Filter By field", $"Successfully found text undernearth Filter By field");
        }
 

        [RegexStepDefinition(@"In the Product Lookup page I confirm to the right of the buttons I do not see three trends")]

        public void GivenInThProductLookupPageIConfirmToTheRightOfTheButtonsIDoNotSeeThreeTrends(Table table)
        {
            Report.IsTrue(new NavBar().InProductLookupIConfirmTheFollowingTrendsAreNotDisplayed(table), "Failed to find all three trends", "Successfully found all three trends");
        }
    
        [RegexStepDefinition(@"In the More Filters pop up, I click  General Filters from the Filter Categories column")]
        public void InTheTheMoreFiltersOptionClickGeneralFilters()
        {
            Report.IsTrue(new MoreFiltersPopup().InTheMoreFiltersPopupIClickGeneralFilters(), "Failed to click General Filters", "Successfully clicked General Filters");
        }


        [RegexStepDefinition(@"In the More Filters pop up, I click Supplier Name from the Filters column")]
        public void InTheTheMoreFiltersOptionClickSupplierName()
        {
            Report.IsTrue(new MoreFiltersPopup().InTheMoreFiltersPopupIClickSupplierName(), "Failed to click Supplier Name", "Successfully clicked Supplier name");

        }

        [RegexStepDefinition(@"In the Filter parameters list I select an entry for the Supplier Name Parmeter list: (.*)")]
        public void InTheTheMoreFiltersOptionSelectEntryForSupplierName(string supplierName)
        {
            GeneralUtilities.WaitForLoadingToFinish();
            Report.IsTrue(new MoreFiltersPopup().InTheMoreFiltersPopupISelectEntryFromListOfSupplierName(supplierName), "Failed to click Supplier Name list", "Successfully clicked Supplier name list");

        }

        [RegexStepDefinition(@"In the More Filters pop up, In the Selected Filters area I click Clear All to remove all filters")]
        public void InTheSelectedFiltersClickClearAll()
        {
            Report.IsTrue(new MoreFiltersPopup().InTheMoreFiltersPopupInTheSelectedFiltersIClickClearAll(), "Failed to click Clear All in the Selected Filters", "Successfully clicked Clear All in the Selected Filters");

        }


        [RegexStepDefinition(@"In the More Filters pop up, I confirm in the Selected Filters area, that breadcrumb shows with the selected value: (.*)")]
        public void InTheMoreFiltersPopupSelectedFiltersAreaIVerifyBreadcrumbIsDisplayedWithSelectedValues(string searchedText)
        {
            if (searchedText.Contains("savedAs"))
            {
                searchedText = (string)Context.GetFromContext(searchedText);
            }
            Report.IsTrue(new MoreFiltersPopup().InTheMoreFiltersPopupSelectedFiltersAreaIVerifyBreadcrumbIsDisplayedWithSelectedValue(searchedText), "Failed to display selected value in breadcrumb", "Successfully displayed selected value in breadcrumb");

        }

        [RegexStepDefinition(@"In the More Filters pop up, I enter value in search box in the Filter Categories column: (.*)")]
        public void InTheMoreFiltersIEnterValueInSearchBoxOfFilterCategory(string value)
        {
            Report.Info("Attempting to Enter value in search box in the Filter Categories column");
            new MoreFiltersPopup().IEnterValueInSearchBoxOfFilterCategory(value);


        }

        [RegexStepDefinition(@"In the More Filters pop up, I confirm searched filter is displayed in Filters Panel : (.*)")]
        public void InTheMoreFiltersPopupIConfirmFilterIsDisplayedInFilterPanel(string searchedText)
        {
            Report.IsTrue(new MoreFiltersPopup().InTheMoreFiltersPopupIConfirmFilterIsDisplayedInFilterPanel(searchedText), "Failed to display searched value in Filters Panel", "Successfully displayed searched value in Filters Panel");

        }

        [RegexStepDefinition(@"In the More Filters pop up, I select Has any value paramater value")]
        public void InTheRecentActivitiesPageMoreFiltersPopUpISelectHasAnyValueParameter()
        {
            Report.IsTrue(new  MoreFiltersPopup().InTheMoreFiltersPopUpHasAnyValueParameterIsSelected(), "Failed to click Has Any value checkbox in the More Filters Pop Up", "Successfully clicked Has Any value checkbox in the More Filters");
        }


        [RegexStepDefinition(@"In the More Filters pop up, I click on searched filter in Filters Panel : (.*)")]
        public void InTheMoreFiltersPopupIClickFilterFromFilterPanel(string filter)
        {
            Report.IsTrue(new MoreFiltersPopup().InTheMoreFiltersPopupIClickFilterFromFilterPanel(filter), "Failed to click on searched value in Filters Panel", "Successfully click on searched value in Filters Panel");

        }


        [RegexStepDefinition(@"In the More Filters pop up, I confirm the Filter Parameter panel shows the search field for UPCs")]
        public void InTheMoreFiltersPopupInFilterParameterPanelIVerifyUPCSearchFieldIsDisplayed()
        {
            Report.IsTrue(new MoreFiltersPopup().InFilterParameterPanelIVerifyUPCSearchFieldIsDisplayed(), "Failed to display UPC Search Field", "Successfully displayed UPC Search Field");

        }

        [RegexStepDefinition(@"In the More Filters pop up, I now type a string of numbers in UPC Number search field: (.*)")]
        [RegexStepDefinition(@"In the More Filters pop up, I now type a string  in Supplier Name search field: (.*)")]
        [RegexStepDefinition(@"In the More Filters pop up, I now type a string  in DPCI search field: (.*)")]
        public void InTheMoreFiltersPopupInFilterParameterPanelIEnterUPCValue(string value)
        {
            Report.Info("Attempting to Enter value in UPC Number search box");
            new MoreFiltersPopup().InFilterParameterPanelIEnterUPCValue(value);

        }


        [RegexStepDefinition(@"I confirm I see the No results found message below the drop down and Search field")]
        public void InTheMoreFiltersPopupInFilterParameterPanelIConfirmListForSearchedUPCNumberIsDisplayed()
        {
            GeneralUtilities.WaitForLoadingToFinish();
            Report.IsTrue(new MoreFiltersPopup().InFilterParameterPanelIConfirmListForSearchedUPCNumberIsDisplayed("No results found"), "Failed to display No results found", "Successfully displayed No results found ");

        }

        [RegexStepDefinition(@"In the More Filters pop up, UPCs I selected earlier are shown at the top of the Search results area with a minus icon in a circle next to each selected UPCs")]
        public void InTheMoreFiltersPopupIConfirmUPCsSelectedIsShownWithMinusIcon()
        {
            GeneralUtilities.WaitForLoadingToFinish();
            Report.IsTrue(new MoreFiltersPopup().InTheMoreFiltersPopupIConfirmUPCsSelectedIsShownWithMinusIcon(), "Failed to display selected UPC Number with minus icon", "Successfully displayed selected UPC Number with minus icon");

        }

        [RegexStepDefinition(@"In the More Filters pop up, I confirm the Filters Parameter panel populates with a list of Supplier Names")]
        [RegexStepDefinition(@"In the More Filters pop up, I confirm the Filters Parameter panel populates with a list of DPCI values")]

        public void InTheTheMoreFiltersIConfirmListOfSupplierNameIsDisplayed()
        {
            GeneralUtilities.WaitForLoadingToFinish(20); 
            Report.IsTrue(new MoreFiltersPopup().InFilterParameterPanelIConfirmListOfSupplierNameForSelectionIsDisplayed(), "Failed to display list of  Supplier Name", "Successfully displayed  list of Supplier name");

        }

        [RegexStepDefinition(@"In the More Filters pop up, I confirm I see Search under the filter parameter heading")]
        public void InTheTheMoreFiltersIConfirmSearchIsDisplayed()
        {
            Report.IsTrue(new MoreFiltersPopup().InTheMoreFiltersPopupIConfirmBoldtextIsDisplayedInFilterPanel("Search"), "Failed to display Search under the filter parameter heading", "Successfully displayed Search under the filter parameter heading");

        }

        [RegexStepDefinition(@"In the More Filters pop up, I confirm the left side of the search box, there is a dropdown box")]
        public void InTheTheMoreFiltersIConfirmdropdownSelectorIsDisplayed()
        {
            Report.IsTrue(new MoreFiltersPopup().InFilterParameterPanelIVerifyUPCdropdownSelectorIsDisplayed( ), "Failed to display Selector dropdown box", "Successfully displayed Selector dropdown box");

        }

        [RegexStepDefinition(@"In the More Filters pop up, I confirm default value of the dropdown box is Contains")]
        public void InTheTheMoreFiltersIConfirmContainsIsDefaultInSelectordropdown()
        {
            Report.IsTrue(new MoreFiltersPopup().IConfirmISeeContainsAsDefaultInSelectorDropdown(), "Failed to display Contains as Default In Selector dropdown", "Successfully displayed Contains as Default In Selector dropdown");

        }

        [RegexStepDefinition(@"In the More Filters pop up, I confirm in the Filter Parameter Panel Selector three options are : Contains, Start With and Is are displayed")]
        public void InTheTheMoreFiltersIConfirmISeeAListOfAvailableOptionsInFilterParameterPanelSelectorIsDisplayed()
        {
            List<string> options = new List<string> { "Contains", "Starts with", "Is" };
            Report.IsTrue(new MoreFiltersPopup().IConfirmISeeAListOfAvailableOptionsInFilterParameterPanelUPCdropdownSelectorIsDisplayed(options), "Failed to display Contains as Default In Selector dropdown", "Successfully displayed Contains as Default In Selector dropdown");

        }


        [RegexStepDefinition(@"In the More Filters pop up, I confirm the list of items shown is narrowed based on the characters I enter: (.*)")]
        public void InTheTheMoreFiltersInFilterParameterPanelIConfirmListStartsWithForSearchedSupplierNameIsDisplayed(string supplierName)
        {
            GeneralUtilities.WaitForLoadingToFinish();
            Report.IsTrue(new MoreFiltersPopup().InFilterParameterPanelIConfirmListStartsWithForSearchedSupplierNameIsDisplayed(supplierName), "Failed to display list of narrowed values based on the characters I enter", "Successfully displayed list of narrowed values based on the characters I enter");

        }

        [RegexStepDefinition(@"In the More Filters pop up, I confirm a blue box with text No results found  is shown under search box")]
        public void InTheTheMoreFiltersInFilterParameterPanelIConfirmNoResultsFoundMessageIsDisplayed()
        {
            GeneralUtilities.WaitForLoadingToFinish();
            Report.IsTrue(new MoreFiltersPopup().InFilterParameterPanelIConfirmNoResultsFoundMessageIsDisplayed(), "Failed to display No results found", "Successfully displayed No results found ");

        }


        [RegexStepDefinition(@"In the More Filters pop up, In the Filter parameters list I select the searched entry for the Supplier Name Parmeter list")]
        [RegexStepDefinition(@"In the More Filters pop up, In the Filter parameters list I select the searched entry for the DPCI Parmeter list")]
        public void InTheMoreFiltersPopupISelectRandomEntryFromListOfSupplierName()
        {
            GeneralUtilities.WaitForLoadingToFinish();
            Report.IsTrue(new MoreFiltersPopup().InTheMoreFiltersPopupISelectRandomEntryFromListOfSupplierName(), "Failed to click Supplier Name list", "Successfully clicked Supplier name list");

        }

        [RegexStepDefinition(@"In the More Filters pop up, I type the parameter value: (.*)")]
        public void InTheRecentActivitiesPageITypeParameterValue(string value)
        {
            new MoreFiltersPopup().EnterValueIntoParameterField(value);
            Report.Success("Value is entered successfully");

        }

        [RegexStepDefinition(@"In the More Filters pop up, I select the option from the Parameters drop down list: (.*)")]
        public void InTheTheMoreFiltersInTheFilterParameterPanelSelectOptionInDropdown(string option)
        {
            GeneralUtilities.WaitForLoadingToFinish();
            Report.IsTrue(new MoreFiltersPopup().InTheFilterParameterPanelSelectOptionInDropdown(option), "Failed to select option 'Starts with' in dropdown", "Successfully selected option 'Starts with' in dropdown");

        }


        [RegexStepDefinition(@"In the More Filters pop up, In the search field in the Filter Parameters panel, In the search box, I enter full Supplier Name: (.*)")]
        public void InTheTheMoreFiltersInFilterParameterPanelIEnterFullSupplierName(string savedAs)
        {
            GeneralUtilities.WaitForLoadingToFinish();
            new MoreFiltersPopup().InFilterParameterPanelIClearValue();
            Report.IsTrue(new MoreFiltersPopup().InFilterParameterPanelIClearValue( ), "Failed to clear value in search box", "Successfully cleared value in search box"); 
            GeneralUtilities.WaitForLoadingToFinish(20); 
            string supplierName = new MoreFiltersPopup().GetRandomSupplierNameFromListInFiltersParameters();
            Context.AddToContext(savedAs, supplierName);
            GeneralUtilities.WaitForLoadingToFinish();
            new MoreFiltersPopup().InFilterParameterPanelIEnterUPCValue(supplierName);
        }

        [RegexStepDefinition(@"I confirm I see the Supplier Name I was searching for: (.*)")]
        public void InTheTheMoreFiltersInFilterParameterPanelIConfirmListMachtesExactlyForSearchedSupplierNameIsDisplayed(string supplierName)
        {
            if (supplierName.Contains("savedAs"))
            {
                supplierName = (string)Context.GetFromContext(supplierName);
            }
            GeneralUtilities.WaitForLoadingToFinish();
            Report.IsTrue(new MoreFiltersPopup().InFilterParameterPanelIConfirmListMachtesExactlyForSearchedSupplierNameIsDisplayed(supplierName), "Failed to display Supplier Name I was searching for", "Successfully displayed Supplier Name I was searching for");

        }

        [RegexStepDefinition(@"In the More Filters pop up, I confirm the Filter Parameter panel shows the WPS Id list")]
        [RegexStepDefinition(@"In the More Filters pop up, I confirm the Filter Parameter panel shows the DPCI list")]
        public void InTheMoreFiltersPopupIConfirmFilterParameterPanelDPCIListIsDisplayed()
        {
            GeneralUtilities.WaitForLoadingToFinish();
            Report.IsTrue(new MoreFiltersPopup().InTheMoreFiltersPopupIConfirmFilterParameterPanelListIsDisplayed(), "Failed to display DPCI list", "Successfully displayed DPCI list");

        }

        [RegexStepDefinition(@"In the More Filters pop up, In Filter Parameter panel I confirm the Search field shows the default text: Search")]
        public void InFilterParameterPanelIVerifyDPCIdropdownPlaceholderIsDisplayed()
        {
            GeneralUtilities.WaitForLoadingToFinish();
            Report.IsTrue(new MoreFiltersPopup().InFilterParameterPanelIVerifyUPCdropdownPlaceholderIsDisplayed("Search parameters"), "Failed to display Search field default text ", "Successfully displayed Search field default text");

        }

        [RegexStepDefinition(@"In the More Filters pop up, In Filter Parameter panel I confirm each item for selection shows a check box before the DPCI value")]
        public void InFilterParameterPanelIConfirmCheckBoxBeforeValueForListIsDisplayed()
        {
            GeneralUtilities.WaitForLoadingToFinish();
            Report.IsTrue(new MoreFiltersPopup().InFilterParameterPanelIConfirmCheckBoxBeforeValueForListIsDisplayed(), "DPCI list does not display checkbox before text/value", "DPCI list displays checbox before text/value");

        }

        [RegexStepDefinition(@"In the More Filters pop up, In Filter Parameter panel I clear the DPCI value in search box")]
        public void  InFilterParameterPanelIClearValue()
        {
            GeneralUtilities.WaitForLoadingToFinish();
            Report.IsTrue(new MoreFiltersPopup().InFilterParameterPanelIClearValue(), "DPCI value in search box is not cleared", "DPCI value in search box is  cleared");

        }


        [RegexStepDefinition(@"In the More Filters pop up, In the search field in the Filter Parameters panel, In the search box, I enter full WPS ID: (.*)")]
        public void InTheTheMoreFiltersInFilterParameterPanelIEnterFullWPSID(string savedAs)
        {
 
            GeneralUtilities.WaitForLoadingToFinish(20);
            string wpsid = new MoreFiltersPopup().GetRandomSupplierNameFromListInFiltersParameters();
            new MoreFiltersPopup().InFilterParameterPanelIClearValue();
            Report.IsTrue(new MoreFiltersPopup().InFilterParameterPanelIClearValue(), "Failed to clear value in search box", "Successfully cleared value in search box");
            Context.AddToContext(savedAs, wpsid);
            GeneralUtilities.WaitForLoadingToFinish();
            new MoreFiltersPopup().InFilterParameterPanelIEnterUPCValue(wpsid);
        }

        [RegexStepDefinition(@"In the More Filters pop up, below the pop up heading I confirm I see 3 panels: Filter Categories, Filters, Filter Parameters")]
        public void InTheMoreFiltersPopUpIVerify3Panels()
        {
            List<string> displayedPanels = new MoreFiltersPopup().IConfirm3PanelsIsDisplayedInMoreFiltersPopup();
            var expectedPanels = new List<string>() { "Filter Categories", "Filters", "Filter Parameters" };
            Report.IsTrue(Enumerable.SequenceEqual(displayedPanels.OrderBy(e => e), expectedPanels.OrderBy(e => e)), " Failed to display the More Filters popup header panels", "Successfully displayed the More Filters popup header panels");


        }

        [RegexStepDefinition(@"In theMore Filters pop up, I select Status: Completed")]
        public void IConfirmThatISelectStatusCompletedInMoreFiltersPopUp()
        {
            new MoreFiltersPopup().InTheMoreFiltersPopUpSearchForFilter("Status");
            new MoreFiltersPopup().InTheMoreFiltersPopUpSelectProductStatusFilter();
            Report.IsTrue(new MoreFiltersPopup().InTheMoreFiltersPopUpSelectCompletedProductStatusFilter(), "Status completed is selected", "Status completed is not selected");

        }

        [RegexStepDefinition(@"In the More Filters pop up, I select Status: (.*)")]
        public void IConfirmThatISelectStatusFilterOptionInMoreFiltersPopUp(string filter)
        {
            new MoreFiltersPopup().InTheMoreFiltersPopUpSearchForFilter("Status");
            new MoreFiltersPopup().InTheMoreFiltersPopUpSelectProductStatusFilter();
            Report.IsTrue(new MoreFiltersPopup().InTheMoreFiltersPopUpSelectFilterParameter(filter), $"Status {filter} is not selected", $"Status {filter} is selected successfully");

        }

        [RegexStepDefinition(@"In the recent activities page, I select the option: (.*) from the status drop down menu")]
        public void InTheRecentActivitiesPageISelectStatusOption(string option)
        {
            if (option.Contains("SavedProduct"))
            {
                option = (string)Context.GetFromContext(option);
            }
            Report.IsTrue(new MoreFiltersPopup().SelectStatusOption(option), "The option was not selected", "The option was selected successfully");
            Delay.Seconds(10);
        }

        [RegexStepDefinition(@"In the recent activities page, I select the option: (.*) from the parameters drop down menu")]
        public void InTheRecentActivitiesPageISelectParameterOption(string option)
        {
            if (option.Contains("SavedProduct"))
            {
                option = (string)Context.GetFromContext(option);
            }
            Report.IsTrue(new MoreFiltersPopup().SelectParameterOption(option), "The option was not selected", "The option was selected successfully");
        }

        [RegexStepDefinition(@"I confirm, under the search box, has value checkbox is displayed: (.*)")]
        public void IConfirmThatInTheMoreFiltersPopupHasValueCheckboxIsDisplayed(string value)
        {
 
            Report.IsTrue(new MoreFiltersPopup().InTheMoreFiltersPopupHasValueCheckboxIsDisplayed(value), "Expected has value checkbox is not displayed ", "The has value checkbox was selected successfully");

        }

        [RegexStepDefinition(@"In the More Filters pop up, I Click has value checkbox: (.*)")]
        public void IConfirmThatInTheMoreFiltersPopupClickHasValueCheckbox(string value)
        {

            Report.IsTrue(new MoreFiltersPopup().InTheMoreFiltersPopupClickHasValueCheckbox(value), "Failed to click has value checkbox ", "Successfully clicked has value checkbox ");

        }

        [RegexStepDefinition(@"In the More Filters pop up, I (check|uncheck) the checkbox with value: (.*)")]
        public void ICheckTheCheckboxWithDescription(string check, string value)
        {
 
            bool toCheck = false;
            if (check == "check")
            {
                toCheck = true;
            }
            else if (check == "uncheck")
            {
                toCheck = false;
            }
            else
            {
                throw new Exception("Specflow paramater must be equal to 'check' or 'uncheck'");
            }
            bool isChecked = new MoreFiltersPopup().InTheMoreFiltersPopupHasValueCheckbox(value).Checked();
            if (isChecked == toCheck)
            {
                Report.Success($"The checkbox was already {check}ed");
                return;
            }
            Report.IsTrue(new MoreFiltersPopup().InTheMoreFiltersPopupClickHasValueCheckbox(value),
                $"Failed to check the checkbox with value: '{value}'!",
                $"Successfully checked the checkbox with value: '{value}'");
            Report.IsTrue(new MoreFiltersPopup().InTheMoreFiltersPopupHasValueCheckbox(value).Checked() == toCheck,
                $"The checkbox was is {check}ed after",
                $"The checkbox is {check}ed as expected");
        }

        [RegexStepDefinition(@"In the More Filters pop up, I confirm Search Control Panel is greyed out and disabled")]
        public void IConfirmThatInTheMoreFiltersPopupSearchBoxDisabled( )
        {

            Report.IsTrue(new MoreFiltersPopup().SearchBoxDisabled(), "Search box is not disabled", "Successfully Search box is disabled");

        }



        #region Shared Steps

        [RegexStepDefinition(@"I call Shared Step 235551 \(More Filters - Apply Is UPC archived = true\)")]
        public void SharedStep235551()
        {
            ReportDetails.CurrentDetails.UseSubSteps = true;

            Report.StartSubStep("Given I click the More Filters button");
            new Steps_RecentActivities().InTheRecentActivitiesPageIClickTheMoreFiltersOption();
            Report.StartSubStep("I confirm the More Filters pop up is shown");
            InTheProductLookupPageIClickTheMoreFiltersPopupIsShowing();
            Report.StartSubStep("In the search field I enter \"Archive\" and confirm a field is shown for selection - will be called \"Is UPC Archived\" or \"Archived UPC\"");
            new MoreFiltersPopup().InTheMoreFiltersPopUpSearchForFilter("Archive");
            Report.StartSubStep("Given, I select the UPC Archived field which is shown");
            Report.IsTrue(new MoreFiltersPopup().InTheMoreFiltersPopUpSelectFilter("Archived"), "Failed to Click Archived UPC", "Successfully clicked Archived UPC");
            Report.StartSubStep("In the Filter Parameters area I select the check box next to \"True\"");
            Report.IsTrue(new MoreFiltersPopup().InTheMoreFiltersPopUpSelectFilterParameter("True"), "Failed to click True checkbox", "Successfully clicked True");

            Report.StartSubStep("I click Apply Filter");
            InTheProductLookUpPageMoreFiltersPopupClickApplyFilterButton();
        }

        [RegexStepDefinition(@"I call Shared Step 235552 \(RPS & WV - More Filters - Apply Status = Pending\)")]
        public void SharedStep235552()
        {
            ReportDetails.CurrentDetails.UseSubSteps = true;

            Report.StartSubStep("Given I click the More Filters button");
            new Steps_RecentActivities().InTheRecentActivitiesPageIClickTheMoreFiltersOption();
            Report.StartSubStep("I confirm the More Filters pop up is shown");
            InTheProductLookupPageIClickTheMoreFiltersPopupIsShowing();
            Report.StartSubStep("In the search field I enter \"Status\"");
            new MoreFiltersPopup().InTheMoreFiltersPopUpSearchForFilter("Status");
            Report.StartSubStep("Given, I select the Product Status field which is shown");
            Report.IsTrue(new MoreFiltersPopup().InTheMoreFiltersPopUpSelectFilter("Status"), "Failed to Click Product Status", "Successfully clicked Product Status");
            Report.StartSubStep("In the Filter Parameters area I select the check box next to \"Pending\"");
            Report.IsTrue(new MoreFiltersPopup().InTheMoreFiltersPopUpSelectFilterParameter("Pending"), "Failed to click Pending checkbox", "Successfully clicked Pending");
            Report.StartSubStep("I click Apply Filter");
            InTheProductLookUpPageMoreFiltersPopupClickApplyFilterButton();
        }


        [RegexStepDefinition(@"I call Shared Step 153388 \(RPS & WV > More Filters > Facet Counts\)")]
        public void SharedStep153388()
        {
            ReportDetails.CurrentDetails.UseSubSteps = true;

            Report.StartSubStep("Given I click the More Filters button");
            new Steps_RecentActivities().InTheRecentActivitiesPageIClickTheMoreFiltersOption();
            Report.StartSubStep("I confirm the More Filters pop up is shown");
            InTheProductLookupPageIClickTheMoreFiltersPopupIsShowing();
            Report.StartSubStep($"In the More Filters pop up, I click  General Filters from the Filter Categories column");
            Report.IsTrue(new MoreFiltersPopup().InTheMoreFiltersPopupIClickGeneralFilters(), "Failed to click General Filters", "Successfully clicked General Filters");

            Report.StartSubStep("In the More Filters pop up, I click Supplier Name from the Filters column");
            Report.IsTrue(new MoreFiltersPopup().InTheMoreFiltersPopupIClickFilterFromFilterPanel("Supplier Name"), "Failed to click Supplier Name", "Successfully clicked Supplier name");
            GeneralUtilities.WaitForLoadingToFinish();
            Report.StartSubStep("In the More Filters pop up, I confirm the Filter Parameter panel shows the Supplier Name list");
            Report.IsTrue(new  MoreFiltersPopup().InTheMoreFiltersPopupIConfirmFilterParameterPanelListIsDisplayed(), "Failed to display Supplier Name list", "Successfully displayed Supplier name list");
            Report.StartSubStep("In the More Filters pop up, I confirm no facet count is shown after the Supplier Name entries");
            Report.IsTrue(new  MoreFiltersPopup().InFilterParameterPanelIConfirmFacetCountForListIsDisplayed() == false, "Supplier Name list displays Facet Count", "Supplier Name list does not display Facet Count");

            Report.StartSubStep("In the More Filters pop up, I click UPC Number from the Filters column");
            Report.IsTrue(new  MoreFiltersPopup().InTheMoreFiltersPopupIClickFilterFromFilterPanel("UPC Number"), "Failed to click UPC Number", "Successfully clicked UPC Number");
            GeneralUtilities.WaitForLoadingToFinish();
            Report.StartSubStep("In the More Filters pop up, I confirm the Filter Parameter panel shows the search field for UPCs");
            Report.IsTrue(new  MoreFiltersPopup().InFilterParameterPanelIVerifyUPCSearchFieldIsDisplayed(), "Failed to display UPC Search Field", "Successfully displayed UPC Search Field");
            Report.StartSubStep("In the More Filters pop up, In the search field in the Filter Parameters panel, I type three digits");
            new  MoreFiltersPopup().InFilterParameterPanelIEnterUPCValue("123");
            Report.StartSubStep("In the More Filters pop up, I confirm the UPCs are shown for selection below the search field");
            Report.IsTrue(new  MoreFiltersPopup().InFilterParameterPanelIVerifyUPCdropdownIsDisplayed(), "Failed to display UPC dropdown list", "Successfully displayed UPC dropdown list");
            Report.StartSubStep("In the More Filters pop up, confirm no facet count is shown after the UPC Numbers in the selection list");
            Report.IsTrue(new  MoreFiltersPopup().InFilterParameterPanelIConfirmFacetCountForUPCNumberListIsDisplayed() == false, "UPC Number list does not display Facet Count", "UPC Number list displays Facet Count");

            Report.StartSubStep("In the More Filters pop up, I click Package Type from the Filters column");
            Report.IsTrue(new  MoreFiltersPopup().InTheMoreFiltersPopupIClickFilterFromFilterPanel("Packaging Type"), "Failed to click Package Type", "Successfully clicked Package Type");
            GeneralUtilities.WaitForLoadingToFinish();
            Report.StartSubStep("In the More Filters pop up, I confirm the Filter Parameter panel shows the Package Type list");
            Report.IsTrue(new  MoreFiltersPopup().InTheMoreFiltersPopupIConfirmFilterParameterPanelListIsDisplayed(), "Failed to display Package Type list", "Successfully displayed Package Type list");
            Report.StartSubStep("In the More Filters pop up, I confirm facet count is shown after the Package Type entries");
            Report.IsTrue(new MoreFiltersPopup().InFilterParameterPanelIConfirmFacetCountForListIsDisplayed(), "Package Type list does not display Facet Count", "Package Type list displays Facet Count");
            Report.StartSubStep("In the More Filters pop up, I click: Close");
            GivenInTheProductLookupPageMoreFiltersPopupIClickTheCloseButton();

        }

        [RegexStepDefinition(@"I call Shared Step 153323 \(RPS & WV > More Filters > Supplier Name > exact match\) for Supplier Name: (.*)")]
        public void SharedStep153323(string savedAs)
        {
            ReportDetails.CurrentDetails.UseSubSteps = true;

            Report.StartSubStep("Given I click the More Filters button");
            new Steps_RecentActivities().InTheRecentActivitiesPageIClickTheMoreFiltersOption();
            Report.StartSubStep("I confirm the More Filters pop up is shown");
            InTheProductLookupPageIClickTheMoreFiltersPopupIsShowing();
            Report.StartSubStep($"In the More Filters pop up, I click  General Filters from the Filter Categories column");
            Report.IsTrue(new MoreFiltersPopup().InTheMoreFiltersPopupIClickGeneralFilters(), "Failed to click General Filters", "Successfully clicked General Filters");
            Report.StartSubStep("In the More Filters pop up, I click Supplier Name from the Filters column");
            Report.IsTrue(new MoreFiltersPopup().InTheMoreFiltersPopupIClickFilterFromFilterPanel("Supplier Name"), "Failed to click Supplier Name", "Successfully clicked Supplier name");
            GeneralUtilities.WaitForLoadingToFinish();
            Report.StartSubStep("In the More Filters pop up, In the Filter Parameters panel, in the Drop down box, I select the IS option ");
            Report.IsTrue(new MoreFiltersPopup().InTheFilterParameterPanelSelectOptionInDropdown("Is"), "Failed to select option 'Is' in dropdown", "Successfully selected option 'Is' in dropdown");
            GeneralUtilities.WaitForLoadingToFinish();
            string supplierName = new MoreFiltersPopup().GetFirstParameterValue();
            Context.AddToContext(savedAs, supplierName);
            Report.StartSubStep("In the More Filters pop up, in the Supplier search field, in the Filter Parameters panel, I enter the full supplier name");
            new  MoreFiltersPopup().InFilterParameterPanelIEnterSearchValue(supplierName);
            GeneralUtilities.WaitForLoadingToFinish();
            Report.StartSubStep($"In the Filter parameters list I select the searched entry for the Supplier Name Parmeter list");
            Report.IsTrue(new MoreFiltersPopup().InTheMoreFiltersPopupISelectEntryFromListOfSupplierName(supplierName), "Failed to click Supplier Name list", "Successfully clicked Supplier name list");
            GeneralUtilities.WaitForLoadingToFinish();
            Report.StartSubStep("In the More Filters pop up, I confirm in the Selected Filters area, that 1 breadcrumb shows with the selected supplier");
            Report.IsTrue(new MoreFiltersPopup().InTheMoreFiltersPopupSelectedFiltersAreaIVerifyBreadcrumbIsDisplayedWithSelectedValue(supplierName), "Failed to display selected supplier in breadcrumb", "Successfully displayed selected supplier in breadcrumb");
            Report.StartSubStep("I click Apply filters");
            InTheProductLookUpPageMoreFiltersPopupClickApplyFilterButton();

        }

        [RegexStepDefinition(@"I call Shared Step 153324 \(RPS & WV > More Filters > Supplier Name > Partial search\) for Supplier Name: (.*)")]
        public void SharedStep153324(string savedAs)
        {
            ReportDetails.CurrentDetails.UseSubSteps = true;

            Report.StartSubStep("Given I click the More Filters button");
            new Steps_RecentActivities().InTheRecentActivitiesPageIClickTheMoreFiltersOption();
            Report.StartSubStep("I confirm the More Filters pop up is shown");
            InTheProductLookupPageIClickTheMoreFiltersPopupIsShowing();
            Report.StartSubStep($"In the More Filters pop up, I click  General Filters from the Filter Categories column");
            Report.IsTrue(new MoreFiltersPopup().InTheMoreFiltersPopupIClickGeneralFilters(), "Failed to click General Filters", "Successfully clicked General Filters");
            Report.StartSubStep("In the More Filters pop up, I click Supplier Name from the Filters column");
            Report.IsTrue(new MoreFiltersPopup().InTheMoreFiltersPopupIClickFilterFromFilterPanel("Supplier Name"), "Failed to click Supplier Name", "Successfully clicked Supplier name");
            GeneralUtilities.WaitForLoadingToFinish();
            string supplierName = new MoreFiltersPopup().GetFirstParameterValue();
            string partialsupplierName = supplierName.Substring(0, 5);
            Context.AddToContext(savedAs, partialsupplierName);
            Report.StartSubStep("In the More Filters pop up, in the Supplier search field, I enter a partial supplier name");
            new MoreFiltersPopup().InFilterParameterPanelIEnterSearchValue(partialsupplierName);
            GeneralUtilities.WaitForLoadingToFinish();
            Report.StartSubStep($"I confirm the list of Suppliers shown in the Parameters panel is narrowed based on the text I entered");
            GeneralUtilities.WaitForLoadingToFinish();
            Report.IsTrue(new MoreFiltersPopup().InFilterParameterPanelIConfirmListForSearchedPartialSupplierNameIsDisplayed(partialsupplierName), "Failed to display Supplier Name list based on search", "Successfully displayed Supplier name list based on search");
            GeneralUtilities.WaitForLoadingToFinish();
            Report.StartSubStep($"In the Filter parameters list I select the searched entry for the Supplier Name Parmeter list");
            Report.IsTrue(new MoreFiltersPopup().InTheMoreFiltersPopupISelectRandomEntryFromListOfSupplierName(), "Failed to click Supplier Name list", "Successfully clicked Supplier name list");
            GeneralUtilities.WaitForLoadingToFinish();
            Report.StartSubStep("In the More Filters pop up, I confirm in the Selected Filters area, that 1 breadcrumb shows with the selected supplier");
            Report.IsTrue(new MoreFiltersPopup().InTheMoreFiltersPopupSelectedFiltersAreaIVerifyBreadcrumbIsDisplayedWithSelectedValue(partialsupplierName), "Failed to display selected supplier in breadcrumb", "Successfully displayed selected supplier in breadcrumb");
            Report.StartSubStep("I click Apply filters");
            InTheProductLookUpPageMoreFiltersPopupClickApplyFilterButton();

        }

        [RegexStepDefinition(@"I call Shared Step 205641 \(More Filters > UPC Number > Format checks\)")]
        public void SharedStep205641()
        {
            ReportDetails.CurrentDetails.UseSubSteps = true;

            Report.StartSubStep("Given I click the More Filters button");
            new Steps_RecentActivities().InTheRecentActivitiesPageIClickTheMoreFiltersOption();
            Report.StartSubStep("I confirm the More Filters pop up is shown");
            InTheProductLookupPageIClickTheMoreFiltersPopupIsShowing();
            Report.StartSubStep($"In the More Filters pop up, I verify search box in the Filter Categories column");
            Report.IsTrue(new MoreFiltersPopup().IVerifySearchBoxIsDisplayedFilterCategory(), "Failed to display search box in Filter Categories column", "Successfully displayed search box in Filter Categories column");
            Report.StartSubStep("In the More Filters pop up, I enter value in search box in the Filter Categories column");
            new MoreFiltersPopup().IEnterValueInSearchBoxOfFilterCategory("UPC Number"); Report.StartSubStep("In the More Filters pop up, I click UPC Number from the Filters column");
            Report.IsTrue(new MoreFiltersPopup().InTheMoreFiltersPopupIClickFilterFromFilterPanel("UPC Number"), "Failed to click UPC Number", "Successfully clicked UPC Number");
            GeneralUtilities.WaitForLoadingToFinish();
            Report.StartSubStep("In the More Filters pop up, I confirm the Filter Parameter panel shows the search field for UPCs");
            Report.IsTrue(new MoreFiltersPopup().InFilterParameterPanelIVerifyUPCSearchFieldIsDisplayed(), "Failed to display UPC Search Field", "Successfully displayed UPC Search Field");
            Report.StartSubStep("In the More Filters pop up, I confirm the Filter Parameter panel shows the dropdown Selector for UPCs");
            Report.IsTrue(new MoreFiltersPopup().InFilterParameterPanelIVerifyUPCdropdownSelectorIsDisplayed(), "Failed to display UPC dropdown Selector", "Successfully displayed UPC dropdown Selector");
            List<string> options = new List<string> { "Contains", "Starts with", "Is" };
            Report.StartSubStep("I confirm the drop down selector shows three options: Contains, Starts with,Is");
            Report.IsTrue(new MoreFiltersPopup().IConfirmISeeAListOfAvailableOptionsInFilterParameterPanelUPCdropdownSelectorIsDisplayed(options), "Failed to display UPC dropdown Selector options", "Successfully displayed UPC dropdown Selector options");
            Report.StartSubStep("I confirm the Search field shows the default text: Search UPCs");
            Report.IsTrue(new MoreFiltersPopup().InFilterParameterPanelIVerifyUPCdropdownPlaceholderIsDisplayed("Search UPCs"), "Failed to display Search field default text: Search UPCs", "Successfully displayed Search field default text: Search UPCs");
            Report.StartSubStep("I click on Search UPCs box");
            Report.IsTrue(new MoreFiltersPopup().InFilterParameterPanelIClickUPCdropdown(), "Failed to click on Search UPCs box", "Successfully clicked on Search UPCs box");
            GeneralUtilities.WaitForLoadingToFinish();
            Report.StartSubStep("I confirm, lists of UPCs generated under the search box");
            Report.IsTrue(new MoreFiltersPopup().InFilterParameterPanelIVerifyUPCdropdownIsDisplayed(), "Failed to display lists of UPCs generated under the search box", "Successfully displayed lists of UPCs generated under the search box");

        }

        [RegexStepDefinition(@"I call Shared Step 205643 \(More Filters > UPC Number > Select filter values and apply\)")]
        public void SharedStep205643()
        {
            ReportDetails.CurrentDetails.UseSubSteps = true;
            GeneralUtilities.WaitForLoadingToFinish();
            Report.StartSubStep($" I select item shown below the drop down and Search field");
            Report.IsTrue(new MoreFiltersPopup().InTheMoreFiltersPopupISelectRandomEntryFromListOfUPCs(), "Failed to select upc from the list ", "Successfully selected upc from the list");
            GeneralUtilities.WaitForLoadingToFinish();
            Report.StartSubStep("In the More Filters pop up, I confirm in the Selected Filters area, that 1 breadcrumb shows with the selected UPC");
            Report.IsTrue(new MoreFiltersPopup().InTheMoreFiltersPopupSelectedFiltersAreaIVerifyBreadcrumbIsDisplayedWithSelectedValue("UPC Number"), "Failed to display selected UPC Number in breadcrumb", "Successfully displayed selected UPC Number in breadcrumb");
            Report.StartSubStep("I click Apply filters");
            InTheProductLookUpPageMoreFiltersPopupClickApplyFilterButton();

        }

        [RegexStepDefinition(@"I call Shared Step 205642 \(More Filters > UPC Number > Contains check\)")]
        public void SharedStep205642()
        {
            ReportDetails.CurrentDetails.UseSubSteps = true;
            GeneralUtilities.WaitForLoadingToFinish();
            Report.StartSubStep("In the More Filters pop up, In the search field in the Filter Parameters panel, I type value");
            new MoreFiltersPopup().InFilterParameterPanelIEnterUPCValue("123456");
            GeneralUtilities.WaitForLoadingToFinish();
            Report.StartSubStep("I confirm the list of items shown is narrowed based on the characters I enter");
            GeneralUtilities.WaitForLoadingToFinish();
            Report.IsTrue(new MoreFiltersPopup().InFilterParameterPanelIConfirmListForSearchedUPCNumberIsDisplayed("123456"), "Failed to display list of narrowed upc numbers based on the characters I enter", "Successfully displayed list of narrowed upc numbers based on the characters I enter");
            Report.StartSubStep("I now type a string of numbers  which I know is NOT present in the list of items shown for selection");
            new MoreFiltersPopup().InFilterParameterPanelIEnterUPCValue("999999999999999");
            GeneralUtilities.WaitForLoadingToFinish();
            Report.StartSubStep("I confirm I see the \"No results found.\" message below the drop down and Search field");
            GeneralUtilities.WaitForLoadingToFinish();
            Report.IsTrue(new MoreFiltersPopup().InFilterParameterPanelIConfirmListForSearchedUPCNumberIsDisplayed("No results found"), "Failed to display No results found", "Successfully displayed No results found ");
            Report.StartSubStep("I clear the numbers I typed into the Search field");
            new MoreFiltersPopup().InFilterParameterPanelIEnterUPCValue("");
            GeneralUtilities.WaitForLoadingToFinish();
            Report.StartSubStep("I confirm the \"No results found.\" message is no longer shown");
            Report.IsTrue(!new MoreFiltersPopup().InFilterParameterPanelIConfirmListForSearchedUPCNumberIsDisplayed("No results found"), " No results found is displayed", "Successfully No results found is not displayed ");
            GeneralUtilities.WaitForLoadingToFinish();
            Report.StartSubStep("I confirm a list of UPCs for selection is shown  below the drop down and Search field");
            Report.IsTrue(new MoreFiltersPopup().InFilterParameterPanelIVerifyUPCdropdownIsDisplayed(), "Failed to display lists of UPCs generated under the search box", "Successfully displayed lists of UPCs generated under the search box");

        }


        [RegexStepDefinition(@"I call Shared Step 205648 \(More Filters > UPC Number > Starts with check\)")]
        public void SharedStep205648()
        {
            ReportDetails.CurrentDetails.UseSubSteps = true;
            GeneralUtilities.WaitForLoadingToFinish();
            Report.StartSubStep("I select the Starts with option from the Parameters drop down list");
            Report.IsTrue(new MoreFiltersPopup().InTheFilterParameterPanelSelectOptionInDropdown("Starts with"), "Failed to select option 'Starts with' in dropdown", "Successfully selected option 'Starts with' in dropdown");
            Report.StartSubStep("In the More Filters pop up, In the search field in the Filter Parameters panel, I type value");
            new MoreFiltersPopup().InFilterParameterPanelIEnterUPCValue("12345");
            GeneralUtilities.WaitForLoadingToFinish();
            Report.StartSubStep("I confirm the list of items shown is narrowed based on the characters I enter");
            GeneralUtilities.WaitForLoadingToFinish();
            Report.IsTrue(new MoreFiltersPopup().InFilterParameterPanelIConfirmListStartsWithForSearchedUPCNumberIsDisplayed("12345"), "Failed to display list of narrowed upc numbers based on the characters I enter", "Successfully displayed list of narrowed upc numbers based on the characters I enter");
            Report.StartSubStep("I now type a string of numbers  which I know is NOT present in the list of items shown for selection");
            new MoreFiltersPopup().InFilterParameterPanelIEnterUPCValue("999999999999999");
            GeneralUtilities.WaitForLoadingToFinish();
            Report.StartSubStep("I confirm I see the \"No results found.\" message below the drop down and Search field");
            GeneralUtilities.WaitForLoadingToFinish();
            Report.IsTrue(new MoreFiltersPopup().InFilterParameterPanelIConfirmListForSearchedUPCNumberIsDisplayed("No results found"), "Failed to display No results found", "Successfully displayed No results found ");
            Report.StartSubStep("I clear the numbers I typed into the Search field");
            new MoreFiltersPopup().InFilterParameterPanelIEnterUPCValue("");
            GeneralUtilities.WaitForLoadingToFinish();
            Report.StartSubStep("I confirm the \"No results found.\" message is no longer shown");
            Report.IsTrue(!new MoreFiltersPopup().InFilterParameterPanelIConfirmListForSearchedUPCNumberIsDisplayed("No results found"), " No results found is displayed", "Successfully No results found is not displayed ");
            GeneralUtilities.WaitForLoadingToFinish();
            Report.StartSubStep("I confirm a list of UPCs for selection is shown  below the drop down and Search field");
            Report.IsTrue(new MoreFiltersPopup().InFilterParameterPanelIVerifyUPCdropdownIsDisplayed(), "Failed to display lists of UPCs generated under the search box", "Successfully displayed lists of UPCs generated under the search box");

        }

        [RegexStepDefinition(@"I call Shared Step 205650 \(More Filters > UPC Number - Is check\) for UPC Number: (.*)")]
        public void SharedStep205650(string savedAs)
        {
            ReportDetails.CurrentDetails.UseSubSteps = true;
            GeneralUtilities.WaitForLoadingToFinish();

            string upcNumber = new MoreFiltersPopup().GetRandomUPCValueFromDropdownListInFiltersParameters();
            Context.AddToContext(savedAs, upcNumber);
            GeneralUtilities.WaitForLoadingToFinish();
            Report.StartSubStep("I select the Is option from the Parameters drop down list");
            Report.IsTrue(new MoreFiltersPopup().InTheFilterParameterPanelSelectOptionInDropdown("Is"), "Failed to select option 'Is' in dropdown", "Successfully selected option 'Is' in dropdown");
            Report.StartSubStep("In the More Filters pop up, In the search field in the Filter Parameters panel, I type value");
            new MoreFiltersPopup().InFilterParameterPanelIEnterUPCValue(upcNumber.Substring(0, 4));
            GeneralUtilities.WaitForLoadingToFinish();
            Report.StartSubStep("I confirm I see the \"No results found.\" message below the drop down and Search field");
            GeneralUtilities.WaitForLoadingToFinish();
            Report.IsTrue(new MoreFiltersPopup().InFilterParameterPanelIConfirmListForSearchedUPCNumberIsDisplayed("No results found"), "Failed to display No results found", "Successfully displayed No results found ");
            Report.StartSubStep("In the More Filters pop up, In the search field in the Filter Parameters panel, I type complete value");
            new MoreFiltersPopup().InFilterParameterPanelIEnterUPCValue(upcNumber);
            Report.StartSubStep("I confirm I see the entry for selection below the drop down and Search fields");
            GeneralUtilities.WaitForLoadingToFinish();
            Report.IsTrue(new MoreFiltersPopup().InFilterParameterPanelIConfirmListMachtesExactlyForSearchedUPCNumberIsDisplayed(upcNumber), "Failed to display upc numbers based on the characters I enter", "Successfully displayed upc numbers based on the characters I enter");
            Report.StartSubStep("I clear the numbers I typed into the Search field");
            new MoreFiltersPopup().InFilterParameterPanelIEnterUPCValue("");
            GeneralUtilities.WaitForLoadingToFinish();
            Report.StartSubStep("I confirm the \"No results found.\" message is no longer shown");
            Report.IsTrue(!new MoreFiltersPopup().InFilterParameterPanelIConfirmListForSearchedUPCNumberIsDisplayed("No results found"), " No results found is displayed", "Successfully No results found is not displayed ");
            GeneralUtilities.WaitForLoadingToFinish();
            Report.StartSubStep("I confirm a list of UPCs for selection is shown  below the drop down and Search field");
            Report.IsTrue(new MoreFiltersPopup().InFilterParameterPanelIVerifyUPCdropdownIsDisplayed(), "Failed to display lists of UPCs generated under the search box", "Successfully displayed lists of UPCs generated under the search box");

        }


        [RegexStepDefinition(@"I call Shared Step 205105 \(More Filters > Checklist Field > Format checks\)")]
        public void SharedStep205105()
        {
            ReportDetails.CurrentDetails.UseSubSteps = true;

            Report.StartSubStep("Given I click the More Filters button");
            new Steps_RecentActivities().InTheRecentActivitiesPageIClickTheMoreFiltersOption();
            Report.StartSubStep("I confirm the More Filters pop up is shown");
            InTheProductLookupPageIClickTheMoreFiltersPopupIsShowing();
            Report.StartSubStep($"In the More Filters pop up, I verify search box in the Filter Categories column");
            Report.IsTrue(new MoreFiltersPopup().IVerifySearchBoxIsDisplayedFilterCategory(), "Failed to display search box in Filter Categories column", "Successfully displayed search box in Filter Categories column");
            Report.StartSubStep("In the More Filters pop up, I enter value in search box in the Filter Categories column");
            new MoreFiltersPopup().IEnterValueInSearchBoxOfFilterCategory("Packaging Type");
            Report.StartSubStep("In the More Filters pop up, I click Packaging Type from the Filters column");
            Report.IsTrue(new MoreFiltersPopup().InTheMoreFiltersPopupIClickFilterFromFilterPanel("Packaging Type"), "Failed to click Packaging Type", "Successfully clicked Packaging Type");
            GeneralUtilities.WaitForLoadingToFinish();
            Report.StartSubStep("In the More Filters pop up, I confirm the Filter Parameter panel shows the search field for Packaging Type");
            Report.IsTrue(new MoreFiltersPopup().InFilterParameterPanelIVerifyUPCSearchFieldIsDisplayed(), "Failed to display Packaging Type Search Field", "Successfully displayed Packaging Type Search Field");
            Report.StartSubStep("In the More Filters pop up, I confirm the Filter Parameter panel shows the dropdown Selector for Packaging Type");
            Report.IsTrue(new MoreFiltersPopup().InFilterParameterPanelIVerifyUPCdropdownSelectorIsDisplayed(), "Failed to display Packaging Type dropdown Selector", "Successfully displayed Packaging Type dropdown Selector");
            List<string> options = new List<string> { "Contains", "Starts with", "Is" };
            Report.StartSubStep("I confirm the drop down selector shows three options: Contains, Starts with,Is");
            Report.IsTrue(new MoreFiltersPopup().IConfirmISeeAListOfAvailableOptionsInFilterParameterPanelUPCdropdownSelectorIsDisplayed(options), "Failed to display Packaging Type dropdown Selector options", "Successfully displayed Packaging Type dropdown Selector options");
            Report.StartSubStep("I confirm the Search field shows the default text: Search ");
            Report.IsTrue(new MoreFiltersPopup().InFilterParameterPanelIVerifySearchfieldPlaceholderIsDisplayed("Search"), "Failed to display Search field default text: Search", "Successfully displayed Search field default text: Search");
            List<string> checkboxoptions = new List<string> { "Has Any Value", "Has No Value" };
            Report.StartSubStep("I confirm below the drop down selector and the Search field, I see two checkbox field: Has Any Value and Has No Value");
            Report.IsTrue(new MoreFiltersPopup().InFilterParameterPanelIConfirmListOfCheckboxesAreDisplayed(checkboxoptions), "Failed to display two checkbox field: Has Any Value and Has No Value", "Successfully displayed two checkbox field: Has Any Value and Has No Value");
            Report.StartSubStep("I confirm, under the Has Any Value and Has No Value, I see bolded text: All Parameters");
            Report.IsTrue(new MoreFiltersPopup().InTheMoreFiltersPopupIConfirmBoldtextIsDisplayedInFilterPanel("All Parameters"), "Failed to display All Parameters bolded text under the search box", "Successfully displayed All Parameters bolded text  under the search box");
            Report.StartSubStep("I confirm, I see a Clear All button far right side of page");
            Report.IsTrue(new MoreFiltersPopup().InTheMoreFiltersPopupIConfirmClearAllButtonIsDisplayedInFilterPanel(), "Failed to Display Clear All Button", "Successfully Displayed Clear All Button");
            Report.StartSubStep("I confirm below the All Parameters text, I see a list of items for selection");
            Report.IsTrue(new MoreFiltersPopup().InFilterParameterPanelIConfirmListOfItemsForSelectionIsDisplayed(), "Failed to display list of items for selection", "Successfully displayed list of items for selection");
            Report.StartSubStep("I confirm each item for selection shows a check box before the text/value");
            Report.IsTrue(new MoreFiltersPopup().InFilterParameterPanelIConfirmCheckBoxBeforeValueForListIsDisplayed(), "Package Type list does not display checkbox before text/value", "Package Type list displays checbox before text/value");
            Report.StartSubStep("I confirm each item shows a number in parenthesis after the text/value");
            Report.IsTrue(new MoreFiltersPopup().InFilterParameterPanelIConfirmFacetCountForListIsDisplayed(), "Package Type list does not display Facet Count", "Package Type list displays Facet Count");
        }


        [RegexStepDefinition(@"I call Shared Step 205106 \(More Filters > Checklist Field - Contains check\)")]
        public void SharedStep205106()
        {
            ReportDetails.CurrentDetails.UseSubSteps = true;
            GeneralUtilities.WaitForLoadingToFinish();
            Report.StartSubStep("In the More Filters pop up, In the search field in the Filter Parameters panel, I type value");
            new MoreFiltersPopup().InFilterParameterPanelIEnterUPCValue("p");
            GeneralUtilities.WaitForLoadingToFinish();
            Report.StartSubStep("I confirm the list of items shown is narrowed based on the characters I enter");
            GeneralUtilities.WaitForLoadingToFinish();
            Report.IsTrue(new MoreFiltersPopup().InFilterParameterPanelIConfirmListForSearchedValueIsDisplayed("p"), "Failed to display list of narrowed values based on the characters I enter", "Successfully displayed list of narrowed values based on the characters I enter");
            Report.StartSubStep("I now type a string of numbers  which I know is NOT present in the list of items shown for selection");
            new MoreFiltersPopup().InFilterParameterPanelIEnterUPCValue("abcd");
            GeneralUtilities.WaitForLoadingToFinish();
            Report.StartSubStep("I confirm I see the \"No results found.\" message below the drop down and Search field");
            GeneralUtilities.WaitForLoadingToFinish();
            Report.IsTrue(new MoreFiltersPopup().InFilterParameterPanelIConfirmNoResultsFoundMessageIsDisplayed(), "Failed to display No results found", "Successfully displayed No results found ");
            Report.StartSubStep("I clear the numbers I typed into the Search field");
            new MoreFiltersPopup().InFilterParameterPanelIEnterUPCValue("");
            GeneralUtilities.WaitForLoadingToFinish();
            Report.StartSubStep("I confirm a list of items for selection is shown  below the drop down and Search field");
            Report.IsTrue(new MoreFiltersPopup().InFilterParameterPanelIConfirmListOfItemsForSelectionIsDisplayed(), "Failed to display list of items for selection under the search box", "Successfully displayed list of items for selection under the search box");

        }

        [RegexStepDefinition(@"I call Shared Step 205107 \(More Filters > Checklist Fields - Select filter values and Apply\)")]
        public void SharedStep205107()
        {
            ReportDetails.CurrentDetails.UseSubSteps = true;
            GeneralUtilities.WaitForLoadingToFinish();
            Report.StartSubStep($"I select or more of the items shown below the drop down and Search field");
            Report.IsTrue(new MoreFiltersPopup().InTheMoreFiltersPopupISelectRandomEntryFromListOfItemsInFilterPanel(), "Failed to select  value from the list ", "Successfully selected value from the list");
            GeneralUtilities.WaitForLoadingToFinish();
            Report.StartSubStep("I confirm the items I selected are shown in the Selected filters area of the More Filters pop up");
            Report.IsTrue(new MoreFiltersPopup().InTheMoreFiltersPopupSelectedFiltersAreaIVerifyBreadcrumbIsDisplayedWithSelectedValue("Packaging Type"), "Failed to display selected UPC Number in breadcrumb", "Successfully displayed selected UPC Number in breadcrumb");
            Report.StartSubStep("I click Apply filters");
            InTheProductLookUpPageMoreFiltersPopupClickApplyFilterButton();

        }


        [RegexStepDefinition(@"I call Shared Step 205108 \(More Filters > Checklist Field > Starts with check\)")]
        public void SharedStep205108()
        {
            ReportDetails.CurrentDetails.UseSubSteps = true;
            GeneralUtilities.WaitForLoadingToFinish();
            Report.StartSubStep("I select the Starts with option from the Parameters drop down list");
            Report.IsTrue(new MoreFiltersPopup().InTheFilterParameterPanelSelectOptionInDropdown("Starts with"), "Failed to select option 'Starts with' in dropdown", "Successfully selected option 'Starts with' in dropdown");
            GeneralUtilities.WaitForLoadingToFinish();
            Report.StartSubStep("In the More Filters pop up, In the search field in the Filter Parameters panel, I type value");
            new MoreFiltersPopup().InFilterParameterPanelIEnterUPCValue("p");
            GeneralUtilities.WaitForLoadingToFinish();
            Report.StartSubStep("I confirm the list of items shown is narrowed based on the characters I enter");
            GeneralUtilities.WaitForLoadingToFinish();
            Report.IsTrue(new MoreFiltersPopup().InFilterParameterPanelIConfirmListStartsWithForSearchedValueIsDisplayed("p"), "Failed to display list of narrowed values based on the characters I enter", "Successfully displayed list of narrowed values based on the characters I enter");
            Report.StartSubStep("I now type a string of numbers  which I know is NOT present in the list of items shown for selection");
            new MoreFiltersPopup().InFilterParameterPanelIEnterUPCValue("abcd");
            GeneralUtilities.WaitForLoadingToFinish();
            Report.StartSubStep("I confirm I see the \"No results found.\" message below the drop down and Search field");
            GeneralUtilities.WaitForLoadingToFinish();
            Report.IsTrue(new MoreFiltersPopup().InFilterParameterPanelIConfirmNoResultsFoundMessageIsDisplayed(), "Failed to display No results found", "Successfully displayed No results found ");
            Report.StartSubStep("I clear the numbers I typed into the Search field");
            new MoreFiltersPopup().InFilterParameterPanelIEnterUPCValue("");
            GeneralUtilities.WaitForLoadingToFinish();
            Report.StartSubStep("I confirm a list of items for selection is shown  below the drop down and Search field");
            Report.IsTrue(new MoreFiltersPopup().InFilterParameterPanelIConfirmListOfItemsForSelectionIsDisplayed(), "Failed to display list of items for selection under the search box", "Successfully displayed list of items for selection under the search box");

        }


        [RegexStepDefinition(@"I call Shared Step 205111 \(More Filters > Checklist Field - Is check\) for Packaging Type: (.*)")]
        public void SharedStep205111(string savedAs)
        {
            ReportDetails.CurrentDetails.UseSubSteps = true;
            GeneralUtilities.WaitForLoadingToFinish();

            string packagingType = new MoreFiltersPopup().GetRandomPackagingTypeFromListInFiltersParameters();
            Context.AddToContext(savedAs, packagingType);
            GeneralUtilities.WaitForLoadingToFinish();
            Report.StartSubStep("I select the Is option from the Parameters drop down list");
            Report.IsTrue(new MoreFiltersPopup().InTheFilterParameterPanelSelectOptionInDropdown("Is"), "Failed to select option 'Is' in dropdown", "Successfully selected option 'Is' in dropdown");
            Report.StartSubStep("In the More Filters pop up, In the search field in the Filter Parameters panel, I type value");
            new MoreFiltersPopup().InFilterParameterPanelIEnterUPCValue(packagingType.Substring(0, 4));
            GeneralUtilities.WaitForLoadingToFinish();
            Report.StartSubStep("I confirm I see the \"No results found.\" message below the drop down and Search field");
            GeneralUtilities.WaitForLoadingToFinish();
            Report.IsTrue(new MoreFiltersPopup().InFilterParameterPanelIConfirmNoResultsFoundMessageIsDisplayed(), "Failed to display No results found", "Successfully displayed No results found ");
            Report.StartSubStep("In the More Filters pop up, In the search field in the Filter Parameters panel, I type complete value");
            new MoreFiltersPopup().InFilterParameterPanelIEnterUPCValue(packagingType);
            Report.StartSubStep("I confirm I see the entry for selection below the drop down and Search fields");
            GeneralUtilities.WaitForLoadingToFinish();
            Report.IsTrue(new MoreFiltersPopup().InFilterParameterPanelIConfirmListMachtesExactlyForSearchedPackagingTypeIsDisplayed(packagingType), "Failed to display  packaging Type based on the characters I enter", "Successfully displayed  packaging Type based on the characters I enter");
            Report.StartSubStep("I clear the numbers I typed into the Search field");
            new MoreFiltersPopup().InFilterParameterPanelIEnterUPCValue("");
            GeneralUtilities.WaitForLoadingToFinish();
            Report.StartSubStep("I confirm a list of items for selection is shown  below the drop down and Search field");
            Report.IsTrue(new MoreFiltersPopup().InFilterParameterPanelIConfirmListOfItemsForSelectionIsDisplayed(), "Failed to display list of items for selection under the search box", "Successfully displayed list of items for selection under the search box");
        }

        [RegexStepDefinition(@"I call Shared Step 153317 \(RPS & WV > More Filters pop up - Display & Close\)")]
        public void SharedStep153317()
        {
            ReportDetails.CurrentDetails.UseSubSteps = true;

            Report.StartSubStep("Given I click the More Filters button");
            new Steps_RecentActivities().InTheRecentActivitiesPageIClickTheMoreFiltersOption();
            Report.StartSubStep("I confirm the More Filters pop up is shown");
            InTheProductLookupPageIClickTheMoreFiltersPopupIsShowing();
            Report.StartSubStep("I confirm I see the More Filters pop up heading which reads: More Filters");
            GivenInTheProductLookupPageIConfirmTheMoreFiltersHeaderContainsTheFollowingTitleMoreFilters("More Filters");
            Report.StartSubStep($"I confirm to the right of the More Filters pop up heading area I see an X ");
            Report.IsTrue(new MoreFiltersPopup().InTheProductLookupPageIConfirmTheXIconInTheMoreFiltersPopupIsDisplayed(), "Failed to display x icon", "Successfully displayed x icon");
            Report.StartSubStep("In the More Filters pop up in the heading area, I click the X icon");
            GivenInTheProductLookupPageIClickTheXIconInTheMoreFiltersPopup();
            Report.StartSubStep("I confirm the More Filters pop up closes");
            GivenInTheProductLookupPageIConfirmTheMoreFiltersPopupIsNotDisplayed("is not");
            Report.StartSubStep("Given I click the More Filters button");
            new Steps_RecentActivities().InTheRecentActivitiesPageIClickTheMoreFiltersOption();
            Report.StartSubStep("I confirm the More Filters pop up is shown");
            InTheProductLookupPageIClickTheMoreFiltersPopupIsShowing();
            Report.StartSubStep("In the More Filters pop up, below the pop up heading I confirm I see 3 panels: Filter Categories, Filters, Filter Parameters");
            InTheMoreFiltersPopUpIVerify3Panels();
            Report.StartSubStep("In the More Filters pop up, I confirm I see the pop up footer area");
            GivenInTheProductLookupPageIConfirmISeeTheFooterArea();
            Table table = new Table("Button");
            table.AddRow("Cancel");
            table.AddRow("Apply filters");
            Report.StartSubStep($"In the Recent Activities page, In the More Filters popup I see the following buttons");
            GivenInTheProductLookupPageIConfirmISeeTheFollowingButtonsInTheFooter(table);
            Report.StartSubStep("In the More Filters pop up, I click: Close");
            GivenInTheProductLookupPageMoreFiltersPopupIClickTheCloseButton();

        }

        [RegexStepDefinition(@"I call Shared Step 163728 \(More Filters - Select Status - Apply - Confirm Actions column does show View Data\) on page: (Recent Activities|Product Lookup) for status: (.*)")]
        public void ThenICallSharedStepMoreFilters_SelectStatus_Apply_ConfirmActionsColumnDoesShowViewDataForStatusXxx(string page, string status)
        {
            Report.UseSubSteps = true;
            if (page == "Recent Activities")
            {
                Report.StartSubStep("In the recent activities page, I click on the More Filters button");
                new Steps_RecentActivities().InTheRecentActivitiesPageIClickTheMoreFiltersOption();
                Report.StartSubStep("In the recent activities page, The More Filters Popup is showing");
                InTheProductLookupPageIClickTheMoreFiltersPopupIsShowing();
                Report.StartSubStep("In the More Filters pop up, I select the status I am working with");
                IConfirmThatISelectStatusFilterOptionInMoreFiltersPopUp(status);
                Report.StartSubStep("In the More Filters pop up, I click: Apply Filter");
                InTheProductLookUpPageMoreFiltersPopupClickApplyFilterButton();
                Delay.Seconds(10);
                Report.StartSubStep("In the recent activities page, The More Filters Popup is not showing");
                InTheProductLookupPageIClickTheMoreFiltersPopupIsNotShowing();
                new Steps_RecentActivities().HomeTabLoaded();
                Report.StartSubStep("In the recent activities Page, I confirm for all products the Action column does include option: 'View Data'");
                new Steps_RecentActivities().InTheRecentActivitiesPageIConfirmForAllProductsActionsColumnContainsGivenOption("View Data");
            }
            else
            {
                Report.StartSubStep("In the product lookup page, I click on the More Filters button");
                new Steps_ProductLookUP().GivenInTheProductLookupPageIClickTheMoreFiltersButton();
                Report.StartSubStep("In the product lookup page, The More Filters Popup is showing");
                InTheProductLookupPageIClickTheMoreFiltersPopupIsShowing();
                Report.StartSubStep("In the More Filters pop up, I select the status I am working with");
                IConfirmThatISelectStatusFilterOptionInMoreFiltersPopUp(status);
                Report.StartSubStep("In the More Filters pop up, I click: Apply Filter");
                InTheProductLookUpPageMoreFiltersPopupClickApplyFilterButton();
                Delay.Seconds(10);
                Report.StartSubStep("In the product lookup page, The More Filters Popup is not showing");
                InTheProductLookupPageIClickTheMoreFiltersPopupIsNotShowing();
                new Steps_ProductLookUP().HomeTabLoaded();

                Report.StartSubStep("In the recent activities Page, I confirm for all products the Action column does include option: 'View Data'");
                new Steps_RecentActivities().InTheRecentActivitiesPageIConfirmForAllProductsActionsColumnContainsGivenOption("View Data");
            }
        }

        [RegexStepDefinition(@"I call Shared Step 106901 \(More Filters - Select Status - Apply - Confirm Actions column does NOT show View Data\) for status: (.*)")]
        public void SharedStep106901a(string status)
        {

            Report.UseSubSteps = true;
            Report.StartSubStep("In the recent activities page, I click on the More Filters button");
            new Steps_RecentActivities().InTheRecentActivitiesPageIClickTheMoreFiltersOption();
            Report.StartSubStep("In the recent activities page, The More Filters Popup is showing");
            InTheProductLookupPageIClickTheMoreFiltersPopupIsShowing();
            Report.StartSubStep("In the More Filters pop up, I select the status I am working with");
            IConfirmThatISelectStatusFilterOptionInMoreFiltersPopUp(status);
            Report.StartSubStep("In the More Filters pop up, I click: Apply Filter");
            InTheProductLookUpPageMoreFiltersPopupClickApplyFilterButton();
            Delay.Seconds(10);
            Report.StartSubStep("In the recent activities page, The More Filters Popup is not showing");
            InTheProductLookupPageIClickTheMoreFiltersPopupIsNotShowing();
            new Steps_RecentActivities().HomeTabLoaded();
            Report.StartSubStep("In the recent activities Page, I confirm for all products the Action column does not include option: 'View Data'");
            new Steps_RecentActivities().InTheRecentActivitiesPageIConfirmForAllProductsActionsColumnDoesNotContainGivenOption("View Data");

        }

        [RegexStepDefinition(@"I call Shared Step 106901b \(More Filters - Select Status - Apply - Confirm Actions column does NOT show View Data\) for status: (.*)")]
        public void SharedStep106901b(string status)
        {

            Report.UseSubSteps = true;
            Report.StartSubStep("In the product lookup page, I click on the More Filters button");
            new Steps_ProductLookUP().GivenInTheProductLookupPageIClickTheMoreFiltersButton();
            Report.StartSubStep("In the product lookup page, The More Filters Popup is showing");
            InTheProductLookupPageIClickTheMoreFiltersPopupIsShowing();
            Report.StartSubStep("In the More Filters pop up, I select the status I am working with");
            InTheProductLookUpPageISelectStatusOption("Status");
            Report.StartSubStep("In the More Filters pop up, I select the parameter I am working with");
            Delay.Seconds(10);
            InTheProductLookUpPageISelectParameterOption(status);
            Report.StartSubStep("In the More Filters pop up, I click: Apply Filter");
            InTheProductLookUpPageMoreFiltersPopupClickApplyFilterButton();
            Delay.Seconds(10);
            Report.StartSubStep("In the product lookup page, The More Filters Popup is not showing");
            InTheProductLookupPageIClickTheMoreFiltersPopupIsNotShowing();
            new Steps_ProductLookUP().HomeTabLoaded();
 
        }

        [RegexStepDefinition(@"I call Shared Step 146428 \(RPS & WV > More Filters > Select Multiple \(for Status viewer & Recent Activities\)")]
        public void ThenICallSharedStepRPSWVMoreFiltersSelectMultipleForStatusViewerRecentActivities()
        {
            new Steps_RecentActivities().InTheRecentActivitiesPageIClickTheMoreFiltersOption();

            InTheProductLookUpPageISelectStatusOption("Status");
            InTheProductLookUpPageISelectParameterOption("Completed");

            InTheProductLookUpPageMoreFiltersPopupClickApplyFilterButton();

            new Steps_RecentActivities().IConfirmThatTheProductLookupPageBreadCrumbAreaContainsLabel("Status: Completed");

            new Steps_RecentActivities().InTheRecentActivitiesPageIClickTheMoreFiltersOption();
        }

        [RegexStepDefinition(@"I call Shared Step 153326 \(RPS & WV > More Filters > Select Multiple \(RUCC and RU\)\)")]
        public void GivenICallSharedStepRPSWVMoreFiltersSelectMultipleRUCCAndRU()
        {
            Report.UseSubSteps = true;
            new Steps_RecentActivities().InTheRecentActivitiesPageIClickTheMoreFiltersOption();

            InTheRecentActivitiesPageISelectStatusOption("Recommended Usage Category Code");
            Delay.Seconds(10);

            InTheRecentActivitiesPageISelectParameterOption("Stationery");
            InTheRecentActivitiesPageISelectParameterOption("Health and Beauty");
            InTheRecentActivitiesPageISelectParameterOption("Battery");

            Report.StartSubStep($"In the Recent Activities page, In the More Filters popup I click the Apply Filters button");
            InTheProductLookUpPageMoreFiltersPopupClickApplyFilterButton();

            new Steps_RecentActivities().IConfirmThatTheProductLookupPageBreadCrumbAreaContainsLabel("Recommended Usage Category Code: Stationery");
            new Steps_RecentActivities().IConfirmThatTheProductLookupPageBreadCrumbAreaContainsLabel("Recommended Usage Category Code: Health and Beauty");
            new Steps_RecentActivities().IConfirmThatTheProductLookupPageBreadCrumbAreaContainsLabel("Recommended Usage Category Code: Battery");

            new Steps_RecentActivities().InTheRecentActivitiesPageIClickTheMoreFiltersOption();

            InTheRecentActivitiesPageISelectStatusOption("Recommended Use");
            Delay.Seconds(10);

            InTheRecentActivitiesPageISelectParameterOption("Chalk");
            InTheRecentActivitiesPageISelectParameterOption("Lithium Ion Battery");
            InTheRecentActivitiesPageISelectParameterOption("Shampoo (Liquid)");

            Report.StartSubStep($"In the Recent Activities page, In the More Filters popup I click the Apply Filters button");
            InTheProductLookUpPageMoreFiltersPopupClickApplyFilterButton();
            Delay.Seconds(10);

            new Steps_RecentActivities().IConfirmThatTheProductLookupPageBreadCrumbAreaContainsLabel("Recommended Use: Chalk");
            new Steps_RecentActivities().IConfirmThatTheProductLookupPageBreadCrumbAreaContainsLabel("Recommended Use: Lithium Ion Battery");
            new Steps_RecentActivities().IConfirmThatTheProductLookupPageBreadCrumbAreaContainsLabel("Recommended Use: Shampoo (Liquid)");

        }

        [RegexStepDefinition(@"I call Shared Step 146595 \(RPS & WV > More Filters > Status - select multiple\)")]
        public void GivenICallSharedStepRPSWVMoreFiltersStatus_SelectMultiple()
        {
            new Steps_RecentActivities().InTheRecentActivitiesPageIClickTheMoreFiltersOption();

            InTheProductLookUpPageISelectStatusOption("Recommended Use");
            InTheProductLookUpPageISelectParameterOption("Chalk");
            InTheProductLookUpPageISelectParameterOption("Lithium Ion Battery");
            InTheProductLookUpPageISelectParameterOption("Shampoo (Liquid)");

            InTheProductLookUpPageMoreFiltersPopupClickApplyFilterButton();

            new Steps_RecentActivities().IConfirmThatTheProductLookupPageBreadCrumbAreaContainsLabel("Recommended Use: Chalk");
            new Steps_RecentActivities().IConfirmThatTheProductLookupPageBreadCrumbAreaContainsLabel("Recommended Use: Lithium Ion Battery");
            new Steps_RecentActivities().IConfirmThatTheProductLookupPageBreadCrumbAreaContainsLabel("Recommended Use: Shampoo (Liquid)");
        }

        [RegexStepDefinition(@"I call Shared Step 153337 \(RPS & WV > More Filters > Packaging type - select multiple\)")]
        public void GivenICallSharedStepRPSWVMoreFiltersPackagingType_SelectMultiple()
        {
            bool expected = true;
            string true_false = "true";
            var driver = SeleniumWebDriver.CurrentDriver;
            new Steps_SuperTable().InTableHeaderClickButtonAndSaveAs("Reset", "dtNow");
            DateTime dtNow = (DateTime)Context.GetFromContext("dtNow");
            Report.IsTrue(GeneralUtilities.NetworkRequestAtTimeConfirmAttributeValue("POST", dtNow, "showAllStatuses", true_false), $"Failure, showAllStatus:{(expected ? "false" : "true")}.", $"Success, showAllStatuses:{true_false}.");
        }

        [RegexStepDefinition(@"I call Shared Step 153320 \(RPS & WV > More Filters >  Clear All Removes all filters\)")]
        public void GivenICallSharedStepRPSWVMoreFiltersRemoveAllFilters()
        {
            Report.UseSubSteps = true;
            Report.StartSubStep("Given I click the More Filters button");
            new Steps_RecentActivities().InTheRecentActivitiesPageIClickTheMoreFiltersOption();
            Report.StartSubStep("In the More Filters pop up, below the pop up heading I confirm I see 3 panels: Filter Categories, Filters, Filter Parameters");
            InTheMoreFiltersPopUpIVerify3Panels();
            Report.StartSubStep($"In the More Filters pop up, I click  General Filters from the Filter Categories column");
            Report.IsTrue(new MoreFiltersPopup().InTheMoreFiltersPopupIClickGeneralFilters(), "Failed to click General Filters", "Successfully clicked General Filters"); 
            Report.StartSubStep("In the More Filters pop up, I click UPC Number from the Filters column");
            Report.IsTrue(new MoreFiltersPopup().InTheMoreFiltersPopupIClickFilterFromFilterPanel("UPC Number"), "Failed to click UPC Number", "Successfully clicked UPC Number");
            GeneralUtilities.WaitForLoadingToFinish(20);
            Report.StartSubStep($" I select item shown below the drop down and Search field");
            Report.IsTrue(new MoreFiltersPopup().InTheMoreFiltersPopupISelectRandomEntryFromListOfUPCs(), "Failed to select upc from the list ", "Successfully selected upc from the list"); 
            Report.StartSubStep("In the More Filters pop up, I click Clear All");
            InTheSelectedFiltersClickClearAll();
            GeneralUtilities.WaitForLoadingToFinish();
            Report.StartSubStep($"In the Recent Activities page, I do not see the breadcrumbs area");
            new Steps_ProductLookUP().GivenIConfirmISeeTheBreadcrumbsAreaUnderTheSearchField("do not see");
            GeneralUtilities.WaitForLoadingToFinish();
            Report.StartSubStep("In the More Filters pop up, I confirm the Filter Parameter panel shows the search field for UPCs");
            Report.IsTrue(new MoreFiltersPopup().InFilterParameterPanelIVerifyUPCSearchFieldIsDisplayed(), "Failed to display UPC Search Field", "Successfully displayed UPC Search Field");
            Table table = new Table("Button");
            table.AddRow("Cancel");
            table.AddRow("Apply filters");
            Report.StartSubStep($"In the Recent Activities page, In the More Filters popup I see the following buttons");
            GivenInTheProductLookupPageIConfirmISeeTheFollowingButtonsInTheFooter(table);
            Report.StartSubStep("In the More Filters pop up, I click:Apply Filters "); 
            InTheProductLookUpPageMoreFiltersPopupClickApplyFilterButton();
            Report.StartSubStep("The More Filters Popup is not showing");
            InTheProductLookupPageIClickTheMoreFiltersPopupIsNotShowing();

        }

        [RegexStepDefinition(@"I call Shared Step 167119 \(RPS & WV > More Filters > Supplier Name, Packaging Type and Packaging Size > Apply filter\)")]
        public void GivenICallSharedStepRPSWVMoreFiltersSupplierNamePackagingTypeAndPackagingSizeApplyFilter()
        {
            ReportDetails.CurrentDetails.UseSubSteps = true;

            Report.StartSubStep("Given I click the More Filters button");
            new Steps_RecentActivities().InTheRecentActivitiesPageIClickTheMoreFiltersOption();
            Report.StartSubStep("I confirm the More Filters pop up is shown");
            InTheProductLookupPageIClickTheMoreFiltersPopupIsShowing();
            Report.StartSubStep($"In the More Filters pop up, I click  General Filters from the Filter Categories column");
            Report.IsTrue(new MoreFiltersPopup().InTheMoreFiltersPopupIClickGeneralFilters(), "Failed to click General Filters", "Successfully clicked General Filters");

            Report.StartSubStep("In the More Filters pop up, I click Supplier Name from the Filters column");
            Report.IsTrue(new MoreFiltersPopup().InTheMoreFiltersPopupIClickFilterFromFilterPanel("Supplier Name"), "Failed to click Supplier Name", "Successfully clicked Supplier name");
            GeneralUtilities.WaitForLoadingToFinish();
            Report.StartSubStep($"In the Filter parameters list I select the searched entry for the Supplier Name Parmeter list");
            Report.IsTrue(new MoreFiltersPopup().InTheMoreFiltersPopupISelectRandomEntryFromListOfSupplierName(), "Failed to click Supplier Name list", "Successfully clicked Supplier name list");
            GeneralUtilities.WaitForLoadingToFinish();
            Report.StartSubStep("In the More Filters pop up, I confirm in the Selected Filters area, that 1 breadcrumb shows with the selected supplier");
            Report.IsTrue(new MoreFiltersPopup().InTheMoreFiltersPopupSelectedFiltersAreaIVerifyBreadcrumbIsDisplayedWithSelectedValue("Supplier Name"), "Failed to display selected supplier in breadcrumb", "Successfully displayed selected supplier in breadcrumb");

            Report.StartSubStep("In the More Filters pop up, I click Packaging Type from the Filters column");
            Report.IsTrue(new MoreFiltersPopup().InTheMoreFiltersPopupIClickFilterFromFilterPanel("Packaging Type"), "Failed to click Packaging Type", "Successfully clicked Packaging Type");
            GeneralUtilities.WaitForLoadingToFinish();
            Report.StartSubStep($"In the Filter parameters list I select the Random entry for the Packaging Type Parmeter list");
            Report.IsTrue(new MoreFiltersPopup().InTheMoreFiltersPopupISelectRandomEntryFromListOfPackagingType(), "Failed to click Packaging Type entry from list", "Successfully clicked Packaging Type entry from list");
            GeneralUtilities.WaitForLoadingToFinish();
            Report.StartSubStep("In the More Filters pop up, I confirm in the Selected Filters area, that 1 breadcrumb shows with the selected Packaging Type");
            Report.IsTrue(new MoreFiltersPopup().InTheMoreFiltersPopupSelectedFiltersAreaIVerifyBreadcrumbIsDisplayedWithSelectedValue("Packaging Type"), "Failed to display selected Packaging Type in breadcrumb", "Successfully displayed selected Packaging Type in breadcrumb");

            Report.StartSubStep("In the More Filters pop up, I click Packaging Size from the Filters column");
            Report.IsTrue(new MoreFiltersPopup().InTheMoreFiltersPopupIClickFilterFromFilterPanel("Packaging Size"), "Failed to click Packaging Size", "Successfully clicked Packaging Size");
            GeneralUtilities.WaitForLoadingToFinish();
            Report.StartSubStep($"In the Filter parameters list I select the Random entry for the Packaging Size Parmeter list");
            Report.IsTrue(new MoreFiltersPopup().InTheMoreFiltersPopupISelectRandomEntryFromListOfPackagingSize(), "Failed to click Packaging Size entry from list", "Successfully clicked Packaging Size entry from list");
            GeneralUtilities.WaitForLoadingToFinish();
            Report.StartSubStep("In the More Filters pop up, I confirm in the Selected Filters area, that 1 breadcrumb shows with the selected Packaging Size");
            Report.IsTrue(new MoreFiltersPopup().InTheMoreFiltersPopupSelectedFiltersAreaIVerifyBreadcrumbIsDisplayedWithSelectedValue("Packaging Size"), "Failed to display selected Packaging Size in breadcrumb", "Successfully displayed selected Packaging Size in breadcrumb");

            Report.StartSubStep("I click Apply filters");
            InTheProductLookUpPageMoreFiltersPopupClickApplyFilterButton();

        }


        [RegexStepDefinition(@"I call Shared Step 180343 \(RPS & WV > More Filters > Select Field from parameters\)")]
        public void GivenICallSharedStepRPSWVMoreFiltersSelectFieldFromParameters()
        {
            Report.UseSubSteps = true;
            new Steps_RecentActivities().InTheRecentActivitiesPageIClickTheMoreFiltersOption();

            Report.StartSubStep($"In the Recent Activities page, In the More Filters popup I click the more Status option");
            InTheRecentActivitiesPageISelectStatusOption("Status");

            Report.StartSubStep($"In the Recent Activities page, In the More Filters popup I click the more Completed parameter");
            InTheRecentActivitiesPageISelectParameterOption("Completed");

            Report.StartSubStep($"In the Recent Activities page, In the More Filters popup I click Apply Filter");
            InTheProductLookUpPageMoreFiltersPopupClickApplyFilterButton();

            Report.StartSubStep($"In the Recent Activities page, I confirm the More Filters popup is no longer shown");
            GivenInTheProductLookupPageIConfirmTheMoreFiltersPopupIsNotDisplayed("is not");
        }


        [RegexStepDefinition(@"I call Shared Step 153321 \(RPS & WV > More Filters > Select Supplier\): (.*)")]
        public void GivenICallSharedStepRPSWVMoreFiltersSelectSupplier(string supplierName)
        {
            Report.UseSubSteps = true;
            Report.StartSubStep($"Given I click: More Filters");
            new Steps_RecentActivities().InTheRecentActivitiesPageIClickTheMoreFiltersOption();

            Report.StartSubStep($"In the More Filters pop up, I click  General Filters from the Filter Categories column");
            Report.IsTrue(new MoreFiltersPopup().InTheMoreFiltersPopupIClickGeneralFilters(), "Failed to click General Filters", "Successfully clicked General Filters");

            Report.StartSubStep($"In the More Filters pop up, I click Supplier Name from the Filters column");
            Report.IsTrue(new MoreFiltersPopup().InTheMoreFiltersPopupIClickSupplierName(), "Failed to click Supplier Name", "Successfully clicked Supplier name");
            GeneralUtilities.WaitForLoadingToFinish();
            Report.StartSubStep($"In the Filter parameters list I select an entry for the Supplier Name Parmeter list");
            Report.IsTrue(new MoreFiltersPopup().InTheMoreFiltersPopupISelectEntryFromListOfSupplierName(supplierName), "Failed to click Supplier Name list", "Successfully clicked Supplier name list");
            GeneralUtilities.WaitForLoadingToFinish();
            Report.StartSubStep($"In the More Filters pop up, I click Apply button");
            InTheProductLookUpPageMoreFiltersPopupClickApplyFilterButton();
            Report.StartSubStep($"I confirm the More Filters pop up closes");
            GivenInTheProductLookupPageIConfirmTheMoreFiltersPopupIsNotDisplayed("is not");
        }




        [RegexStepDefinition(@"I call Shared Step 163792 \(More Filters - Select any Less than 100,000 > Apply Filter\)")]
        public void ThenICallSharedStepMoreFilters_Select_ApplyFilter()
        {
            ReportDetails.CurrentDetails.UseSubSteps = true;

            Report.StartSubStep("I click on the More Filters button");
            new Steps_RecentActivities().InTheRecentActivitiesPageIClickTheMoreFiltersOption();
            Report.StartSubStep("The More Filters Popup is showing");
            InTheProductLookupPageIClickTheMoreFiltersPopupIsShowing();
            Report.StartSubStep("In the More Filters pop up, I select the Packaging type from the drop down list");
            InTheRecentActivitiesPageISelectStatusOption("Packaging Size");
            Report.StartSubStep("In the More Filters pop up, I type the parameter value");
            Delay.Seconds(10);
            InTheRecentActivitiesPageITypeParameterValue("100");
            Report.StartSubStep("In the More Filters pop up, I click: Apply Filter");
            InTheProductLookUpPageMoreFiltersPopupClickApplyFilterButton();
            Delay.Seconds(10);
            Report.StartSubStep("The More Filters Popup is not showing");
            InTheProductLookupPageIClickTheMoreFiltersPopupIsNotShowing();


        }

        [RegexStepDefinition(@"I call Shared Step 204769 \(More Filters > Select 19 parameters > confirm breadcrumbs tags\)")]
        public void SharedStep204769()
        {
            ReportDetails.CurrentDetails.UseSubSteps = true;

            Report.StartSubStep("Given I click the More Filters button");
            new Steps_RecentActivities().InTheRecentActivitiesPageIClickTheMoreFiltersOption();
            Report.StartSubStep("I confirm the More Filters pop up is shown");
            InTheProductLookupPageIClickTheMoreFiltersPopupIsShowing();
            Report.StartSubStep($"In the More Filters pop up, I verify search box in the Filter Categories column");
            Report.IsTrue(new MoreFiltersPopup().IVerifySearchBoxIsDisplayedFilterCategory(), "Failed to display search box in Filter Categories column", "Successfully displayed search box in Filter Categories column");
            Report.StartSubStep("In the More Filters pop up, I enter value in search box in the Filter Categories column");
            new MoreFiltersPopup().IEnterValueInSearchBoxOfFilterCategory("Recommended Usage Category Code"); 
            Report.StartSubStep("In the More Filters pop up, I click Recommended Usage Category Code from the Filters column");
            Report.IsTrue(new MoreFiltersPopup().InTheMoreFiltersPopupIClickFilterFromFilterPanel("Recommended Usage Category Code"), "Failed to click Recommended Usage Category Code", "Successfully clicked Recommended Usage Category Code");
            GeneralUtilities.WaitForLoadingToFinish();
            Report.StartSubStep("In the More Filters pop up, I confirm the Filter Parameter panel shows the search field for Recommended Usage Category Code");
            Report.IsTrue(new MoreFiltersPopup().InFilterParameterPanelIVerifyUPCSearchFieldIsDisplayed(), "Failed to display Recommended Usage Category Code Search Field", "Successfully displayed Recommended Usage Category Code Search Field");
            Report.StartSubStep("In Filter Parameters select 19 items ");
            Report.IsTrue(new MoreFiltersPopup().InTheMoreFiltersPopupSelectMultipleFromListOfFilters(19), "Failed to select multiple filters", "Successfully selected multiple filters");
            Report.StartSubStep("I confirm the selected filters header now shows:\r\nSelected filters (19):");
            Report.IsTrue(new MoreFiltersPopup().InTheMoreFiltersPopupGetselectedHeadersCount("Selected filters (19)"), "Failed to display selected filters headers count", "Successfully displayed selected filters headers count");
            Report.StartSubStep($"In the Recent Activities page, I see the breadcrumbs area");
            new Steps_ProductLookUP().GivenIConfirmISeeTheBreadcrumbsAreaUnderTheSearchField("see");
        }

        [RegexStepDefinition(@"I call Shared Step 163524 \(More Filters > limit filters selected checks\): (.*)")]
        public void SharedStep163524(string value)
        {
            ReportDetails.CurrentDetails.UseSubSteps = true;
  
            Report.StartSubStep("I confirm the Selected filters header now shows:\r\nSelected filters (x):\r\nWhere x is the current limit set");
            Report.IsTrue(new MoreFiltersPopup().InTheMoreFiltersPopupGetselectedHeadersCount($"Selected filters ({value})"), "Failed to display selected filters headers count", "Successfully displayed selected filters headers count");
            Report.StartSubStep("I confirm a message is shown in the Selected filters area which reads:\r\nYou have reached the limit of filters to select");
            Report.IsTrue(new MoreFiltersPopup().InTheMoreFiltersPopupselectedFiltersLimittext("You have reached the limit of filters to select"), "Failed to display the limit message", "Successfully displayed limit message"); 
            Report.StartSubStep("I confirm the Search box under Filter Parameters is \"greyed out\" and I cannot change the search text");
            Report.IsTrue(new MoreFiltersPopup().SearchBoxDisabled(), "Search box is not disabled", "Successfully Search box is disabled");
            Report.StartSubStep("I confirm any additional items not already selected in the parameters panel are not selectable (check boxed are not active)");
            Report.IsTrue(new MoreFiltersPopup().FiltersCheckboxDisabled(), "check box is not disabled", "Successfully check box is disabled");


        }


        [RegexStepDefinition(@"I call Shared Step 203036 \(RPS>More Filters>Verify Phrase Not Found is not shown\)")]
        public void SharedStep203036()
        {
            ReportDetails.CurrentDetails.UseSubSteps = true;
            Report.StartSubStep("Given I click the More Filters button");
            new Steps_RecentActivities().InTheRecentActivitiesPageIClickTheMoreFiltersOption();
            Report.StartSubStep("I confirm the More Filters pop up is shown");
            InTheProductLookupPageIClickTheMoreFiltersPopupIsShowing(); 
            Report.StartSubStep("In the More Filters pop up, I enter value in search box in the Filter Categories column");
            new MoreFiltersPopup().IEnterValueInSearchBoxOfFilterCategory("Recommended Use");
            Report.StartSubStep("In the More Filters pop up, I click Recommended Use from the Filters column");
            Report.IsTrue(new MoreFiltersPopup().InTheMoreFiltersPopupIClickFilterFromFilterPanel("Recommended Use"), "Failed to click Recommended Use", "Successfully clicked Recommended Use");
            GeneralUtilities.WaitForLoadingToFinish();
            Report.StartSubStep("In the More Filters pop up, I confirm the Filter Parameter panel shows the Recommended Use list");
            Report.IsTrue(new MoreFiltersPopup().InTheMoreFiltersPopupIConfirmFilterParameterPanelListIsDisplayed(), "Failed to display Recommended Use list", "Successfully displayed Recommended Use list");
            Report.StartSubStep("In the More Filters pop up, In the search field in the Filter Parameters panel, I type Phrase not found");
            new MoreFiltersPopup().InFilterParameterPanelIEnterUPCValue("Phrase not found");
            List<string> options = new List<string> { "Contains", "Starts with", "Is" };
            Report.StartSubStep("I confirm the drop down selector shows three options: Contains, Starts with,Is");
            Report.IsTrue(new MoreFiltersPopup().IConfirmISeeAListOfAvailableOptionsInFilterParameterPanelUPCdropdownSelectorIsDisplayed(options), "Failed to display Recommended Use dropdown Selector options", "Successfully displayed Recommended Use dropdown Selector options");
            Report.StartSubStep("I select the Contains option from the Parameters drop down list");
            Report.IsTrue(new MoreFiltersPopup().InTheFilterParameterPanelSelectOptionInDropdown("Contains"), "Failed to select option 'Contains' in dropdown", "Successfully selected option 'Contains' in dropdown"); 
            Report.StartSubStep("I confirm I do not see any result for \"Phrase Not Found\"");
            GeneralUtilities.WaitForLoadingToFinish();
            Report.StartSubStep("I confirm I see the \"No results found.\" message below the drop down and Search field");
            Report.StartSubStep("In the More Filters pop up, I click: Close");
            GivenInTheProductLookupPageMoreFiltersPopupIClickTheCloseButton();
 

        }

        [RegexStepDefinition(@"I call Shared Step 204659 \(RPS More Filters filter by Packaging Type")]
        public void SharedStep204659(string value)
        {
            ReportDetails.CurrentDetails.UseSubSteps = true;

            Report.StartSubStep("Given I click the More Filters button");
            new Steps_RecentActivities().InTheRecentActivitiesPageIClickTheMoreFiltersOption();
            Report.StartSubStep("I confirm the More Filters pop up is shown");
            InTheProductLookupPageIClickTheMoreFiltersPopupIsShowing();
            Report.StartSubStep($"In the More Filters pop up, I verify search box in the Filter Categories column");
            Report.IsTrue(new MoreFiltersPopup().IVerifySearchBoxIsDisplayedFilterCategory(), "Failed to display search box in Filter Categories column", "Successfully displayed search box in Filter Categories column");
            Report.StartSubStep("In the More Filters pop up, I enter value in search box in the Filter Categories column");
            new MoreFiltersPopup().IEnterValueInSearchBoxOfFilterCategory("Packaging Type");
            Report.StartSubStep("In the More Filters pop up, I click Packaging Type from the Filters column");
            Report.IsTrue(new MoreFiltersPopup().InTheMoreFiltersPopupIClickFilterFromFilterPanel("Packaging Type"), "Failed to click Packaging Type", "Successfully clicked Packaging Type");
            GeneralUtilities.WaitForLoadingToFinish();
            Report.StartSubStep("I confirm below the All Parameters text, I see a list of items for selection");
            Report.IsTrue(new MoreFiltersPopup().InFilterParameterPanelIConfirmListOfItemsForSelectionIsDisplayed(), "Failed to display list of items for selection", "Successfully displayed list of items for selection");
 
        }

        #endregion
    }

}
