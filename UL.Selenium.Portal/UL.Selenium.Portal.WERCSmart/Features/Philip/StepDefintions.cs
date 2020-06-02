using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Web.Administration;
using Newtonsoft.Json;
using UL.Automation.Reporting.Functions;
using UL.Automation.Reporting.SpecFlow.Classes;
using TechTalk.SpecFlow;


using System.Globalization;
using Newtonsoft.Json.Converters;
using System.Xml;
using UL.Automation.Reporting;
using UL.Automation.Selenium.Classes;
using UL.Automation.TReVor.Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using UL.Automation.Utilities.Functions;
using static UL.Selenium.Portal.WERCSmart.Selenium_Classes.RetailerAbbreviations;
using UL.Selenium.Portal.WERCSmart.Steps;
using UL.Selenium.Portal.WERCSmart.Classes;
using UL.Selenium.Portal.WERCSmart.Steps.New_Product;
using UL.Selenium.Portal.WERCSmart.Steps.New_Product.Product_Type;

namespace UL.Selenium.Portal.WERCSmart.Philip
{
	[Binding, Scope(Tag = "Philip")]
	class StepDefinitions
	{
		public object TheProduct { get; private set; }
		public string File { get; private set; }

		[StepDefinition(@"In the popup view with the following title: (.*) I confirm I see the following buttons in the popup view:")]
		public void ThenIConfirmISeeTheFollowingButtonsInThePopupView(string popupTitle, Table table)
		{
			WebElements webElementsObject = new WebElements();
			Report.IsTrue(webElementsObject.CheckForTheFollowingButtonsInThePopupView(popupTitle, table), "Failed to find all the buttons", "Successfully found all the buttons");
		}


		[StepDefinition(@"I confirm I see a checkbox in the popup view with the following text: (.*)")]
		public void ThenIConfirmISeeACheckboxInThePopupViewWithTheFollowingText(string text)
		{
			WebElements webElementsObject = new WebElements();
			Report.IsTrue(webElementsObject.ConfirmACheckboxWithTheFollowingTextExists(text), "Failed to find the a checkbox with the following text: " + text, "Successfully found a checkbox with the following text: " + text);
		}


		[StepDefinition(@"I confirm the table in the popup view has following column data")]
		public void ThenIConfirmTheTableInThePopupViewHasFollowingColumnData(Table table)
		{
			WebElements webElementsObject = new WebElements();
			Report.IsTrue(webElementsObject.CheckForTheFollowingTableColumnDataInPopupView(table), "Failed to find all the columns", "Successfully found all the columns");
		}


		[StepDefinition(@"I confirm the table in the popup view has the following column titles")]
		public void ThenIConfirmIATableWithTheFollowingColumnTitles(Table table)
		{
			WebElements webElementsObject = new WebElements();
			Report.IsTrue(webElementsObject.CheckForTheFollowingTableColumnTitlesInPopupView(table), "Failed to find all the columns", "Successfully found all the columns");
		}

		[StepDefinition(@"In the popup view with the following title: (.*) I confirm I see the following statement in the popup view: (.*)")]
		public void ThenIConfirmISeeTheFollowingStatementInThePopupView(string popupTitle, string text)
		{
			WebElements webElementsObject = new WebElements();
			Report.IsTrue(webElementsObject.ConfirmTheFollowingTextIsInThePopupView(popupTitle, text), "Failed to find the following text: " + text, "Successfully found the following text: " + text);
		}


		[StepDefinition(@"I confirm there is a popup video titled: (.*) in the Ingredients page")]
		public void ThenIConfirmThereIsAPopupVideoTitled(string popupTitle)
		{
			WebElements webElementsObject = new WebElements();
			Report.IsTrue(webElementsObject.ConfirmThereIsAPopupViewTitled(popupTitle), "Failed to find the following title: " + popupTitle, "Successfully found the following title: " + popupTitle);
		}


		[StepDefinition(@"The following retailers in the Select Retailers popup list view should be selected")]
		public void ThenTheFollowingRetailersInTheSelectRetailersPopupListViewShouldBeSelected(Table table)
		{
			WebElements webElementsObject = new WebElements();
			Report.IsTrue(webElementsObject.CheckThatTheFollowingRetailersAreSelectedInTheRetailersPopupList(table), "Unexpected retailers were found checked", "All expected retailers were checked");
		}


		[StepDefinition(@"I click the delete icon in the Retailer page")]
		public void ThenIClickTheDeleteIconInTheRetailerPage()
		{
			WebElements webElementsObject = new WebElements();
			Report.IsTrue(webElementsObject.SelectTheDeleteSelectedRetailersButton(), "Failed to select the delete selected retailers button", "Successfully selected the delete selected retailers button");
		}


		[StepDefinition(@"I select the following retailers in the Retailer page")]
		public void ThenISelectTheFollowingRetailersInTheRetailerPage(Table table)
		{
			WebElements webElementsObject = new WebElements();
			Report.IsTrue(webElementsObject.SelectTheFollowingRetailersInTheRetailersPage(table), "Failed to select the following retailers", "Successfully selected the following retailers");
		}


		[StepDefinition(@"I confirm the product type field displaying the following results")]
		public void ThenIConfirmTheProductTypeFieldDisplayingTheFollowingResults(Table table)
		{
			WebElements webElementsObject = new WebElements();
			Report.IsTrue(webElementsObject.CheckForTheFollowingResultsInTheProductTypeField(table), "Failed to confirm the following results", "Successfully confirmed the following results");
		}


		[StepDefinition(@"I check that the following sections contain the corresponding titles:")]
		public void ThenICheckThatTheFollowingSectionsContainTheCorrespondingTitles(Table table)
		{
			WebElements webElementsObject = new WebElements();
			Report.IsTrue(webElementsObject.CheckTheFollowingSectionTitles(table), "Failed to confirm the following section titles", "Successfully confirmed the following section titles");
		}



		[StepDefinition(@"I set the following data: (.*) for the following state: (.*)")]
		public void GivenISetTheFollowingDataErtForTheFollowingStateMA(string date, string state)
		{
			WebElements webElementsObject = new WebElements();
			Report.IsTrue(webElementsObject.EnterExpirationDateForStatePesticideReigstration(date, state), "Failed to enter a date", "Successfully entered a date");
		}


		[StepDefinition(@"I enter the following EPA Pesticide Registration No\.: (.*)")]
		public void ThenIEnterTheFollowingEPAPesticideRegistrationNo_(string enterText)
		{
			WebElements webElementsObject = new WebElements();
			Report.IsTrue(webElementsObject.EnterEPAPesticideRegistrationNo(enterText), "Failed to enter text", "Successfully entered text");
		}



		[StepDefinition(@"I confirm the following retailers are showing in the Retailer page")]
		public void ThenIConfirmTheFollowingRetailersAreShowingInTheRetailerPage(Table table)
		{
			WebElements webElementsObject = new WebElements();
			Report.IsTrue(webElementsObject.CheckForTheFollowingRetailersInRetailerPage(table), "Failed to find all retailers", "Successfully found all retailers");
		}


		[StepDefinition(@"I make sure products saved as: (.*) are missing from the product list")]
		public void ThenIMakeSureProductsSavedAsSelectedProductsAreMissingFromTheProductList(string savedAs)
		{
			WebElements webElementsObject = new WebElements();
			var list = Context.GetFromContext(savedAs).ToString();
			string[] listSplit = list.Split(',');
			Report.Info("Testing " + list + " split " + listSplit);
			foreach (string listItem in listSplit)
			{
				Report.IsTrue(webElementsObject.CheckIfProductIsMissing(listItem), "The following product WPS ID: " + savedAs + " should be missing but it was found in the product list", "The following product WPS ID: " + savedAs + " was expected to be missing from the product list and it was");
			}
		}


		[StepDefinition(@"I select checkbox for product saved as: (.*)")]
		public void ThenISelectCheckboxForProductSavedAs(string wpsID)
		{
			WebElements webElementsObject = new WebElements();
			wpsID = webElementsObject.GetProductIDFromContext(wpsID);
			Report.IsTrue(webElementsObject.SelectCheckboxForProductWithWPSID(wpsID), "Failed to select checkbox", "Successfully selected checkbox");
		}


		[StepDefinition(@"In the Delete Active Products page I click the Filter button")]
		public void ThenInTheDeleteActiveProductsPageIClickTheFilterButton()
		{
			WebElements webElementsObject = new WebElements();
			Report.IsTrue(webElementsObject.ClickFilterButtonInDeleteActiveProductsPage(), "Failed to click Filter button", "Successfully clicked Filter button");
			Delay.Seconds(10);
		}

		[StepDefinition(@"In the Delete Active Products page I search for WPS ID saved as: (.*)")]
		public void ThenInTheDeleteActiveProductsPageISearchForWPSIDSavedAs(string wpsID)
		{
			WebElements webElementsObject = new WebElements();
			wpsID = webElementsObject.GetProductIDFromContext(wpsID);
			Report.IsTrue(webElementsObject.EnterTextInSearchBarInDeleteActiveProductsPage(wpsID), "Failed to enter WPS ID number in the searchbar", "Successfully entered WPS ID number in the searchbar");
		}

		[StepDefinition(@"I (select|deselect) the checkbox next to WPS ID in the Delete Active Products page")]
		public void ThenISelectTheCheckboxNextToWPSIDInTheDeleteActiveProductsPage(string selectOrDeselect)
		{
			WebElements webElementsObject = new WebElements();
			Report.IsTrue(webElementsObject.SelectCheckBoxNextToWPSIDLabel(selectOrDeselect), "Failed to " + selectOrDeselect + " checkbox next to WPS ID Label", "Successfully  " + selectOrDeselect + "ed checkbox next to WPS ID Label");
		}

		[StepDefinition(@"I confirm all checkboxes are (selected|deselected) in the Delete Active Products page")]
		public void ThenIConfirmAllCheckboxesAreSelectedInTheDeleteActiveProductsPage(string selectedOrDeselected)
		{
			WebElements webElementsObject = new WebElements();
			Report.IsTrue(webElementsObject.ConfirmAllProductsInListAreChecked(selectedOrDeselected), "Not all products in product list are " + selectedOrDeselected, "All products in product list are " + selectedOrDeselected);
		}

		[StepDefinition(@"I click on the Make Obsolete button")]
		public void ThenIClickOnTheMakeObsoleteButton()
		{
			WebElements webElementsObject = new WebElements();
			Report.IsTrue(webElementsObject.ClickMakeObsoleteButton(), "Failed to click 'Make Obsolete' button", "Successfully clicked 'Make Obsolete' button");
			Delay.Seconds(5);
		}

		[StepDefinition(@"I select the checkbox in the Make Obsolete popup")]
		public void ThenIClickOnTheCheckboxInTheMakeObsoletePopup()
		{
			WebElements webElementsObject = new WebElements();
			Report.IsTrue(webElementsObject.SelectCheckBoxInMakeObsoletePopup(), "Failed to select the checkbox in the Make Obsolete popup", "Successfully selected the checkbox in the Make Obsolete popup");
		}

		[StepDefinition(@"In the Make Obsolete popup I click on the (Accept|Cancel) button")]
		public void GivenInTheDataAcceptancePageIClickOnTheAcceptButton(string acceptOrCancel)
		{ 
			WebElements webElementsObject = new WebElements();
			Report.IsTrue(webElementsObject.ClickAcceptButtonInMakeObsoletePopup(acceptOrCancel), "Failed to click " + acceptOrCancel + " button", "Successfully clicked " + acceptOrCancel + " button");
			Delay.Seconds(5);
		}

		[StepDefinition(@"I select random products checkbox and save as: (.*)")]
		public void ThenISelectRandomProductsCheckbox(string savedAs)
		{
			WebElements webElementsObject = new WebElements();
			Report.IsTrue(webElementsObject.SelectRandomCheckBoxes(savedAs), "Failed to select random checkboxes and save their corresponding product IDs", "Successfully selected random checkboxes and saved their corresponding product IDs");
		}

		[StepDefinition(@"I make sure product saved as: (.*) (should|should not) missing from the product list")]
		public void ThenIMakeSureProductSavedAsSelectedProductIsMissingFromTheProductList(string savedAs, string shouldOrShouldNot)
		{
			WebElements webElementsObject = new WebElements();
			savedAs = webElementsObject.GetProductIDFromContext(savedAs);

			if (shouldOrShouldNot.ToLower() == "should")
			{
				Report.IsTrue(webElementsObject.CheckIfProductIsMissing(savedAs.ToString()), "The following product WPS ID: " + savedAs + " should be missing but it was found in the product list", "The following product WPS ID: " + savedAs + " was expected to be missing from the product list and it was");
			} else if (shouldOrShouldNot.ToLower() == "should not")
			{
				Report.IsTrue(!webElementsObject.CheckIfProductIsMissing(savedAs.ToString()), "The following product WPS ID: " + savedAs + " should not be missing but it was found in the product list", "The following product WPS ID: " + savedAs + " was expected to be found in the product list and it was");
			}
		}




















		[StepDefinition(@"I confirm that the excel file saved as: (.*) contains the following columnss:")]
		public bool ThenIConfirmThatTheExcelFileSavedAsContainsTheFollowingColumns(string savedAs, Table table)
		{
			string File = Context.GetFromContext(savedAs)?.ToString() ?? "";
			if (Report.IsTrue(!string.IsNullOrEmpty(File), "No matching file was found for name: " + savedAs + "!", "File was found: " + File))
			{
				var ExcelUtils = new ExcelFunctions(File.ToString(), "Table");
				List<List<string>> str = new List<List<string>>();
				for (int i = 1; i < table.RowCount + 1; i++)
				{
					List<string> ColumnTitles = ExcelUtils.Excel_GetRow(i);

					str.Add(ColumnTitles);
				}

				Report.Info("hi");
				var abbr = new RetailerAbbreviations();
				string selectedAbbr = "";

				foreach (TableRow thisRow in table.Rows)
				{

					Report.Info("hi1");
					string retailer = thisRow["Retailer"];
					bool isFound = false;

					abbr.Map.TryGetValue(retailer, out selectedAbbr);
					Report.Info("hi1.1 " + retailer + " === " + selectedAbbr);
					foreach (List<string> listStr in str)
					{

						Report.Info("hi2 " + listStr[0] + " === " + retailer + " === " + selectedAbbr);
						if (listStr[0] == selectedAbbr)
						{
							Report.Info("hi2.1");
							isFound = true;
						}
					}
					if (!isFound)
					{
						Report.Info("hi3");
						Report.IsTrue(isFound, "", "");
					}
				}
				Report.Info("hi4");
				return true;
			}
			Report.Info("hi5");
			return false;
		}









		//120873

		[StepDefinition(@"Confirm that there is a middle column called: (.*) between left column called: (.*) and right column called: (.*)")]
		public void GivenConfirmThatThereIsAMiddleColumnCalledBetweenLeftColumnCalledAndRightColumnCalled(string middleColumnName, string leftColumnName, string rightColumnName)
		{
			WebElements WebElementsObject = new WebElements();
			Report.IsTrue(WebElementsObject.ChcekForAColumnBetweenTwoColumns(middleColumnName, leftColumnName, rightColumnName), "Failed to find a middle column called: " + middleColumnName, "Successfully found a middle column called: " + middleColumnName);
		}

		[StepDefinition(@"Find productID that has the letter: (.*) in the CW column and save it as: (.*)")]
		public void ThenFindProductThatHasTheLetterInTheCWColumn(string letter, string saveAs)
		{
			WebElements WebElementsObject = new WebElements();
			string productID = WebElementsObject.FindProductIDWithSpecificLetterInCWColumn(letter);
			Context.AddToContext(saveAs, productID);
			Report.IsTrue(productID != null, "Failed to find a productID", "Successfully found a productID");
		}

		[StepDefinition(@"I open Power Designer Plus")]
		public void ThenIOpenPowerDesignerPlus()
		{
			var thisTopMenu = new StudioTopMenu();
			Report.IsTrue(thisTopMenu.Wait_for_load(60), "Top menu bar not showing", "Top menu bar is showing", showSuccessScreenshot: false);
			Report.IsTrue(thisTopMenu.ClickSubMenu("Authoring", "Power Designer Plus"),
				"Failed to navigate to power designer plus", "Navigated to power designer plus");
		}

		[StepDefinition(@"I search for productID saved as : (.*) in SHA")]
		public void ThenISearchForProductIDSavedAsProductIDInSHA(string saveAs)
		{
			Delay.Seconds(30);
			WebElements WebElementsObject = new WebElements();
			var productID = Context.GetFromContext(saveAs).ToString();
			Report.IsTrue(WebElementsObject.EnterProductWithIDInSHASearchField(productID), "Failed to enter productID: " + productID + " in search field", "Successfully enter productID: " + productID + " in search field");
		}

		[StepDefinition(@"I click the refresh button in SHA")]
		public void ThenIClickTheRefreshButtonInSHA()
		{
			WebElements WebElementsObject = new WebElements();
			Report.IsTrue(WebElementsObject.ClickSearchButtonInSHA(), "Failed to click search button in SHA", "Successfully clicked search button in SHA");
		}


		[StepDefinition(@"I click the Vendor Report section")]
		public void ThenIClickVendorSection()
		{
			Delay.Seconds(30);
			WebElements WebElementsObject = new WebElements();
			Report.IsTrue(WebElementsObject.ClickVendorReportSection(), "Failed to click Vendor Report section", "Successfully clicked Vendor Report section");
		}

		[StepDefinition(@"I click section called: (.*) in the Vendor Report section")]
		public void ThenIClickASection(string sectionName)
		{
			WebElements WebElementsObject = new WebElements();
			Report.IsTrue(WebElementsObject.ClickASectionInVendorReportSection(sectionName), "Failed to click section called: " + sectionName, "Successfully clicked section called: " + sectionName);
		}

		[StepDefinition(@"I check that the following text: (.*) (should|should not) exist")]
		public void ThenCheckText(string text, string shouldOrShouldNot)
		{
			WebElements WebElementsObject = new WebElements();
			Report.IsTrue(WebElementsObject.CheckForTheFollowingText(text, shouldOrShouldNot), "Failed to check if text " + shouldOrShouldNot + " exist", "Successfully checked if text " + shouldOrShouldNot + " exist");
		}

	}
}
