using Reqnroll;
using System.IO.Packaging;
using UL.Automation.Reporting.Functions;
using UL.Automation.ReqnrollHelpers.Attributes;
using UL.Automation.ReqnrollHelpers.Classes;
using UL.Automation.WebDriver.Classes;
using UL.Selenium.Portal.WERCSmart.Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps
{
	[Binding, Scope(Tag = "ForwardProductRegistrationPage")]
	internal class Steps_ForwardProductRegistrationPage
	{
		#region Prototype Steps

		#endregion

		#region Wizard Tabs List Steps
		[RegexStepDefinition(@"On the Forward Product Registration page, confirm wizard tabs list (does|does not) exists")]
		public void ForwardProductRegistrationConfirmWizardTabsListExists(string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			ForwardProductRegistrationPage forwardProductRegistration = new ForwardProductRegistrationPage();
			Report.IsTrue(expected == forwardProductRegistration.WizardTabsListExists(), $"Failure, failed to confirm wizard tabs list {does_doesnot} exist.", $"Success, confirmed wizard tabs list {does_doesnot} exist.");
		}

		[RegexStepDefinition(@"On the Forward Product Registration Page, confirm (Select Products|Select Retailers|Select UPCs|Product Results|Review & Submit) wizard tab (does_does not) exist")]
		public void ForwardProductRegistrationConfirmWizardTabExists(string tabLabel, string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			ForwardProductRegistrationPage forwardProductRegistration = new ForwardProductRegistrationPage();
			if (Report.IsTrue(forwardProductRegistration.WizardTabsListExists(), $"Failure, failed to confirm wizard tabs list does exist.", $"Success, confirmed wizard tabs list does exist."))
			{
				Report.IsTrue(expected == forwardProductRegistration.WizardTabExists(tabLabel), $"Failure, failed to confirm '{tabLabel}' wizard tab {does_doesnot} exist.", $"Success, confirmed '{tabLabel}' wizard tab {does_doesnot} exist.");
			}
		}

		[RegexStepDefinition(@"On the Forward Product Registration Page, confirm (Select Products|Select Retailers|Select UPCs|Product Results|Review & Submit) wizard tab (is|is not) active")]
		public void ForwardProductRegistrationConfirmWizardTabIsIsNotActive(string tabLabel, string is_isnot)
		{
			bool expected = is_isnot == "is";
			ForwardProductRegistrationPage forwardProductRegistration = new ForwardProductRegistrationPage();
			if (Report.IsTrue(forwardProductRegistration.WizardTabsListExists(), $"Failure, failed to confirm wizard tabs list does exist.", $"Success, confirmed wizard tabs list does exist."))
			{
				if (Report.IsTrue(forwardProductRegistration.WizardTabExists(tabLabel), $"Failure, failed to confirm '{tabLabel}' wizard tab does exist.", $"Success, confirmed '{tabLabel}' wizard tab does exist."))
				{
					Report.IsTrue(expected == forwardProductRegistration.WizardTabActive(tabLabel), $"Failure, failed to confirm '{tabLabel}' wizard tab {is_isnot} active.", $"Success, confirmed '{tabLabel}' wizard tab {is_isnot} active.");
				}
			}
		}

		[RegexStepDefinition(@"On the Forward Product Registration Page, click (Select Products|Select Retailers|Select UPCs|Product Results|Review & Submit) wizard tab")]
		public void ForwardProductRegistrationClickWizardTab(string tabLabel)
		{
			ForwardProductRegistrationPage forwardProductRegistration = new ForwardProductRegistrationPage();
			if (Report.IsTrue(forwardProductRegistration.WizardTabsListExists(), $"Failure, failed to confirm wizard tabs list does exist.", $"Success, confirmed wizard tabs list does exist."))
			{
				if (Report.IsTrue(forwardProductRegistration.WizardTabExists(tabLabel), $"Failure, failed to confirm '{tabLabel}' wizard tab does exist.", $"Success, confirmed '{tabLabel}' wizard tab does exist."))
				{
					Report.IsTrue(forwardProductRegistration.WizardTabClick(tabLabel), $"Failure, failed to click '{tabLabel}' wizard tab.", $"Success, clicked '{tabLabel}' wizard tab.");
				}
			}
		}
		#endregion

		#region Continue Button Steps
		[RegexStepDefinition(@"On the Forward Product Registration Page, confirm the 'Continue' Button (does|does not) exist")]
		public void ForwardProductRegistrationConfirmContinueButtonExists(string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			string buttonLabel = "Continue";
			ForwardProductRegistrationPage forwardProductRegistration = new ForwardProductRegistrationPage();
			Report.IsTrue(expected == forwardProductRegistration.LabeledButtonExists(buttonLabel), $"Failure, failed to confirm '{buttonLabel}' button {does_doesnot} exist.", $"Success, confirmed '{buttonLabel}' button {does_doesnot} exist.");
		}

		[RegexStepDefinition(@"On the Forward Product Registration Page, click the 'Continue' Button")]
		public void ForwardProductRegistrationClickContinueButton()
		{
			string buttonLabel = "Continue";
			ForwardProductRegistrationPage forwardProductRegistration = new ForwardProductRegistrationPage();
			if (Report.IsTrue(forwardProductRegistration.LabeledButtonExists(buttonLabel), $"Failure, failed to confirm '{buttonLabel}' button does exist.", $"Success, confirmed '{buttonLabel}' button does exist."))
			{
				Report.IsTrue(forwardProductRegistration.LabeledButtonClick(buttonLabel), $"Failure, failed to click '{buttonLabel}' button.", $"Success, clicked '{buttonLabel}' button.");
			}
		}
		#endregion

		#region Select Products Tab Steps
		#region Search by WPS ID or Product Name Steps
		[RegexStepDefinition(@"In the Select Products Tab, confirm 'Search by WPSID or Product Name' Text Input (does|does not) exist")]
		public void SelectProductsTabConfirmTextInputExists(string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			string sectionLabel = "Search by WPSID or Product Name";
			ForwardProductRegistrationPage forwardProductRegistration = new ForwardProductRegistrationPage();
			Report.IsTrue(expected == forwardProductRegistration.SectionTextInputExists(sectionLabel), $"Failure, failed to confirm '{sectionLabel}' text input {does_doesnot} exist.", $"Success, confirmed '{sectionLabel}' text input {does_doesnot} exist.");
		}

		[RegexStepDefinition(@"In the Select Products Tab, click 'Search by WPSID or Product Name' Text Input")]
		public void SelectProductsTabClickTextInput()
		{
			string sectionLabel = "Search by WPSID or Product Name";
			ForwardProductRegistrationPage forwardProductRegistration = new ForwardProductRegistrationPage();
			if (Report.IsTrue(forwardProductRegistration.SectionTextInputExists(sectionLabel), $"Failure, failed to confirm '{sectionLabel}' text input does exist.", $"Success, confirmed '{sectionLabel}' text input does exist."))
			{
				Report.IsTrue(forwardProductRegistration.SectionTextInputClick(sectionLabel), $"Failure, failed to click '{sectionLabel}' text input.", $"Success, clicked '{sectionLabel}' text input.");
			}
		}

		[RegexStepDefinition(@"In the Select Products Tab, in 'Search by WPSID or Product Name' Text Input enter text: (.*)")]
		public void SelectProductsTabClickTextInput(string inputText)
		{
			string sectionLabel = "Search by WPSID or Product Name";
			ForwardProductRegistrationPage forwardProductRegistration = new ForwardProductRegistrationPage();
			if (Report.IsTrue(forwardProductRegistration.SectionTextInputExists(sectionLabel), $"Failure, failed to confirm '{sectionLabel}' text input does exist.", $"Success, confirmed '{sectionLabel}' text input does exist."))
			{
				Report.IsTrue(forwardProductRegistration.SectionTextInputEnterText(sectionLabel, inputText), $"Failure, in '{sectionLabel}' text input failed to enter text: '{inputText}'.", $"Success, in '{sectionLabel}' text input entered text: '{inputText}'.");
			}
		}

		[RegexStepDefinition(@"In the Select Products Tab, confirm product upc search result list (does|does not) exist")]
		public void SelectProductsTabConfirmProductUPCSearchResultListExists(string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			ForwardProductRegistrationPage forwardProductRegistration = new ForwardProductRegistrationPage();
			Report.IsTrue(expected == forwardProductRegistration.ProductUpcSearchResultsListExists(), $"Failure, failed to confirm product upc search result list {does_doesnot} exist.", $"Success, confirmed product upc search result list {does_doesnot} exist.");
		}

		[RegexStepDefinition(@"In the Select Products Tab, confirm product upc search result with '(.*)' Product Name (does|does not) exist")]
		public void SelectProductsTabConfirmProductUPCSearchResultProductNameExists(string productName, string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			ForwardProductRegistrationPage forwardProductRegistration = new ForwardProductRegistrationPage();
			if(Report.IsTrue(forwardProductRegistration.ProductUpcSearchResultsListExists(), $"Failure, failed to confirm product upc search result list does exist.", $"Success, confirmed product upc search result list does exist."))
			{
				Report.IsTrue(expected == forwardProductRegistration.ProductUpcSearchResultByProductNameExists(productName), $"Failure, failed to confirm product upc search result with '{productName}' product name {does_doesnot} exist.", $"Success, confirmed product upc search result with '{productName}' product name {does_doesnot} exist.");
			}
		}

		[RegexStepDefinition(@"In the Select Products Tab, click product upc search result with '(.*)' Product Name")]
		public void SelectProductsTabClickProductUPCSearchResultProductName(string productName)
		{
			ForwardProductRegistrationPage forwardProductRegistration = new ForwardProductRegistrationPage();
			if (Report.IsTrue(forwardProductRegistration.ProductUpcSearchResultsListExists(), $"Failure, failed to confirm product upc search result list does exist.", $"Success, confirmed product upc search result list does exist."))
			{
				if(Report.IsTrue(forwardProductRegistration.ProductUpcSearchResultByProductNameExists(productName), $"Failure, failed to confirm product upc search result with '{productName}' product name does exist.", $"Success, confirmed product upc search result with '{productName}' product name does exist."))
				{
					Report.IsTrue(forwardProductRegistration.ProductUpcSearchResultByProductName(productName).Click(), $"Failure, failed to click product upc search result with '{productName}' product name.", $"Success, clicked product upc search result with '{productName}' product name.");
				}
			}
		}

		[RegexStepDefinition(@"In the Select Products Tab, confirm product upc search result with '(.*)' Product Name checkbox (is|is not) checked")]
		public void SelectProductsTabConfirmProductUPCSearchResultProductNameChecked(string productName, string is_isnot)
		{
			bool expected = is_isnot == "is";
			ForwardProductRegistrationPage forwardProductRegistration = new ForwardProductRegistrationPage();
			if (Report.IsTrue(forwardProductRegistration.ProductUpcSearchResultsListExists(), $"Failure, failed to confirm product upc search result list does exist.", $"Success, confirmed product upc search result list does exist."))
			{
				if (Report.IsTrue(forwardProductRegistration.ProductUpcSearchResultByProductNameExists(productName), $"Failure, failed to confirm product upc search result with '{productName}' product name does exist.", $"Success, confirmed product upc search result with '{productName}' product name does exist."))
				{
					Report.IsTrue(expected == forwardProductRegistration.ProductUpcSearchResultByProductName(productName).CheckboxChecked(), $"Failure, failed to confirm product upc search result with '{productName}' product name checkbox {is_isnot} checked.", $"Success, confirmed product upc search result with '{productName}' product name checkbox {is_isnot} checked.");
				}
			}
		}

		[RegexStepDefinition(@"In the Select Products Tab, confirm product upc search result with '(.*)' WPSID (does|does not) exist")]
		public void SelectProductsTabConfirmProductUPCSearchResultWPSIDExists(string wpsid, string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			ForwardProductRegistrationPage forwardProductRegistration = new ForwardProductRegistrationPage();
			if (Report.IsTrue(forwardProductRegistration.ProductUpcSearchResultsListExists(), $"Failure, failed to confirm product upc search result list does exist.", $"Success, confirmed product upc search result list does exist."))
			{
				Report.IsTrue(expected == forwardProductRegistration.ProductUpcSearchResultByWPSIDExists(wpsid), $"Failure, failed to confirm product upc search result with '{wpsid}' WPSID {does_doesnot} exist.", $"Success, confirmed product upc search result with '{wpsid}' WPSID {does_doesnot} exist.");
			}
		}

		[RegexStepDefinition(@"In the Select Products Tab, click product upc search result with '(.*)' WPSID")]
		public void SelectProductsTabClickProductUPCSearchResultWPSID(string wpsid)
		{
			ForwardProductRegistrationPage forwardProductRegistration = new ForwardProductRegistrationPage();
			if (Report.IsTrue(forwardProductRegistration.ProductUpcSearchResultsListExists(), $"Failure, failed to confirm product upc search result list does exist.", $"Success, confirmed product upc search result list does exist."))
			{
				if (Report.IsTrue(forwardProductRegistration.ProductUpcSearchResultByWPSIDExists(wpsid), $"Failure, failed to confirm product upc search result with '{wpsid}' WPSID does exist.", $"Success, confirmed product upc search result with '{wpsid}' WPSID does exist."))
				{
					Report.IsTrue(forwardProductRegistration.ProductUpcSearchResultByWPSID(wpsid).Click(), $"Failure, failed to click product upc search result with '{wpsid}' WPSID.", $"Success, clicked product upc search result with '{wpsid}' WPSID.");
				}
			}
		}

		[RegexStepDefinition(@"In the Select Products Tab, confirm product upc search result with '(.*)' WPSID checkbox (is|is not) checked")]
		public void SelectProductsTabConfirmProductUPCSearchResultWPSIDChecked(string wpsid, string is_isnot)
		{
			bool expected = is_isnot == "is";
			ForwardProductRegistrationPage forwardProductRegistration = new ForwardProductRegistrationPage();
			if (Report.IsTrue(forwardProductRegistration.ProductUpcSearchResultsListExists(), $"Failure, failed to confirm product upc search result list does exist.", $"Success, confirmed product upc search result list does exist."))
			{
				if (Report.IsTrue(forwardProductRegistration.ProductUpcSearchResultByWPSIDExists(wpsid), $"Failure, failed to confirm product upc search result with '{wpsid}' WPSID does exist.", $"Success, confirmed product upc search result with '{wpsid}' WPSID does exist."))
				{
					Report.IsTrue(expected == forwardProductRegistration.ProductUpcSearchResultByWPSID(wpsid).CheckboxChecked(), $"Failure, failed to confirm product upc search result with '{wpsid}' WPSID checkbox {is_isnot} checked.", $"Success, confirmed product upc search result with '{wpsid}' WPSID checkbox {is_isnot} checked.");
				}
			}
		}
		#endregion

		#region Selected Products List Steps
		[RegexStepDefinition(@"In the Select Products Tab, confirm Selected Products list (does|does not) exist")]
		public void SelectProductsTabConfirmSelectedProductsListExists(string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			ForwardProductRegistrationPage forwardProductRegistration = new ForwardProductRegistrationPage();
			Report.IsTrue(expected == forwardProductRegistration.SelectedProductsListExists(), $"Failure, failed to confirm selected products list {does_doesnot} exist.", $"Success, confirmed selected products list {does_doesnot} exist.");
		}

		[RegexStepDefinition(@"In the Select Products Tab, confirm Selected Product with (.*) Product Name (does|does not) exist")]
		public void SelectProductsTabConfirmSelectedProductProductNameExists(string productName, string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			ForwardProductRegistrationPage forwardProductRegistration = new ForwardProductRegistrationPage();
			if(Report.IsTrue(forwardProductRegistration.SelectedProductsListExists(), $"Failure, failed to confirm selected products list does exist.", $"Success, confirmed selected products list does exist."))
			{
				Report.IsTrue(expected == forwardProductRegistration.SelectedProductByProductNameExists(productName), $"Failure, failed to confirm selected product with '{productName}' product name {does_doesnot} exist.", $"Success, confirmed selected product with '{productName}' product name {does_doesnot} exist.");
			}
		}

		[RegexStepDefinition(@"In the Select Products Tab, click Selected Product with (.*) Product Name checkbox")]
		public void SelectProductsTabClickSelectedProductProductNameCheckbox(string productName)
		{
			ForwardProductRegistrationPage forwardProductRegistration = new ForwardProductRegistrationPage();
			if (Report.IsTrue(forwardProductRegistration.SelectedProductsListExists(), $"Failure, failed to confirm selected products list does exist.", $"Success, confirmed selected products list does exist."))
			{
				if(Report.IsTrue(forwardProductRegistration.SelectedProductByProductNameExists(productName), $"Failure, failed to confirm selected product with '{productName}' product name does exist.", $"Success, confirmed selected product with '{productName}' product name does exist."))
				{
					Report.IsTrue(forwardProductRegistration.SelectedProductByProductName(productName).CheckboxClick(), $"Failure, failed to click selected product with '{productName}' product name checkbox.", $"Success, clicked selected product with '{productName}' product name checkbox.");
				}
			}
		}

		[RegexStepDefinition(@"In the Select Products Tab, confirm Selected Product with (.*) Product Name checkbox (is|is not) checked")]
		public void SelectProductsTabConfirmSelectedProductProductNameCheckboxChecked(string productName, string is_isnot)
		{
			bool expected = is_isnot == "is";
			ForwardProductRegistrationPage forwardProductRegistration = new ForwardProductRegistrationPage();
			if (Report.IsTrue(forwardProductRegistration.SelectedProductsListExists(), $"Failure, failed to confirm selected products list does exist.", $"Success, confirmed selected products list does exist."))
			{
				if (Report.IsTrue(forwardProductRegistration.SelectedProductByProductNameExists(productName), $"Failure, failed to confirm selected product with '{productName}' product name does exist.", $"Success, confirmed selected product with '{productName}' product name does exist."))
				{
					Report.IsTrue(expected == forwardProductRegistration.SelectedProductByProductName(productName).CheckboxChecked(), $"Failure, failed to confirm selected product with '{productName}' product name checkbox {is_isnot} checked.", $"Success, confirmed selected product with '{productName}' product name checkbox {is_isnot} checked.");
				}
			}
		}

		[RegexStepDefinition(@"In the Select Products Tab, confirm Selected Product with (.*) WPSID (does|does not) exist")]
		public void SelectProductsTabConfirmSelectedProductWPSIDExists(string wpsid, string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			ForwardProductRegistrationPage forwardProductRegistration = new ForwardProductRegistrationPage();
			if (Report.IsTrue(forwardProductRegistration.SelectedProductsListExists(), $"Failure, failed to confirm selected products list does exist.", $"Success, confirmed selected products list does exist."))
			{
				Report.IsTrue(expected == forwardProductRegistration.SelectedProductByWPSIDExists(wpsid), $"Failure, failed to confirm selected product with '{wpsid}' WPSID {does_doesnot} exist.", $"Success, confirmed selected product with '{wpsid}' WPSID {does_doesnot} exist.");
			}
		}

		[RegexStepDefinition(@"In the Select Products Tab, click Selected Product with (.*) WPSID checkbox")]
		public void SelectProductsTabClickSelectedProductWPSIDCheckbox(string wpsid)
		{
			ForwardProductRegistrationPage forwardProductRegistration = new ForwardProductRegistrationPage();
			if (Report.IsTrue(forwardProductRegistration.SelectedProductsListExists(), $"Failure, failed to confirm selected products list does exist.", $"Success, confirmed selected products list does exist."))
			{
				if (Report.IsTrue(forwardProductRegistration.SelectedProductByWPSIDExists(wpsid), $"Failure, failed to confirm selected product with '{wpsid}' WPSID does exist.", $"Success, confirmed selected product with '{wpsid}' WPSID does exist."))
				{
					Report.IsTrue(forwardProductRegistration.SelectedProductByWPSID(wpsid).CheckboxClick(), $"Failure, failed to click selected product with '{wpsid}' WPSID checkbox.", $"Success, clicked selected product with '{wpsid}' WPSID checkbox.");
				}
			}
		}

		[RegexStepDefinition(@"In the Select Products Tab, confirm Selected Product with (.*) WPSID checkbox (is|is not) checked")]
		public void SelectProductsTabConfirmSelectedProductWPSIDCheckboxChecked(string wpsid, string is_isnot)
		{
			bool expected = is_isnot == "is";
			ForwardProductRegistrationPage forwardProductRegistration = new ForwardProductRegistrationPage();
			if (Report.IsTrue(forwardProductRegistration.SelectedProductsListExists(), $"Failure, failed to confirm selected products list does exist.", $"Success, confirmed selected products list does exist."))
			{
				if (Report.IsTrue(forwardProductRegistration.SelectedProductByWPSIDExists(wpsid), $"Failure, failed to confirm selected product with '{wpsid}' WPSID does exist.", $"Success, confirmed selected product with '{wpsid}' WPSID does exist."))
				{
					Report.IsTrue(forwardProductRegistration.SelectedProductByWPSID(wpsid).CheckboxChecked(), $"Failure, failed to confirm selected product with '{wpsid}' WPSID checkbox {is_isnot} checked.", $"Success, confirmed selected product with '{wpsid}' WPSID checkbox {is_isnot} checked.");
				}
			}
		}

		[RegexStepDefinition(@"In Select Products Tab, confirm Remove Selected Products button (does|does not) exist")]
		public void SelectProductsTabConfirmRemoveSelectedProductsButtonExists(string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			ForwardProductRegistrationPage forwardProductRegistration = new ForwardProductRegistrationPage();
			Report.IsTrue(forwardProductRegistration.RemoveCheckedProductsButtonDisplayed(), $"Failure, failed to confirm Remove Selected Products button {does_doesnot} exist.", $"Success, confirmed Remove Selected Products button {does_doesnot} exist.");
		}

		[RegexStepDefinition(@"In Select Products Tab, click Remove Selected Products button")]
		public void SelectProductsTabClickRemoveSelectedProductsButton()
		{
			ForwardProductRegistrationPage forwardProductRegistration = new ForwardProductRegistrationPage();
			if (Report.IsTrue(forwardProductRegistration.RemoveCheckedProductsButtonDisplayed(), $"Failure, failed to confirm Remove Selected Products button does exist.", $"Success, confirmed Remove Selected Products button does exist."))
			{
				Report.IsTrue(forwardProductRegistration.RemoveCheckedProductsButtonClick(), $"Failure, failed to click remove selected products button.", $"Success, clicked remove selected products button.");
			}
		}
		#endregion
		#endregion

		#region Select Retailers Tab Steps
		[RegexStepDefinition(@"In the Select Retailers Tab, confirm Select Retailer Action Links list (does|does not) exist")]
		public void SelectRetailersTabConfirmSelectRetailerActionLinksListExists(string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			ForwardProductRegistrationPage forwardProductRegistration = new ForwardProductRegistrationPage();
			Report.IsTrue(expected == forwardProductRegistration.SelectRetailerActionLinksListExists(), $"Failure, failed to confirm Select Retailer Action Links list {does_doesnot} exist.", $"Success, confirmed Select Retailer Action Link list {does_doesnot} exist.");
		}

		[RegexStepDefinition(@"In the Select Retailers Tab, confirm (Select all|Show list view|Show logo tile view) Select Retailer Action Link (does|does not) exist")]
		public void SelectRetailersTabConfirmSelectRetailerActionLinkExists(string linkLabel, string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			ForwardProductRegistrationPage forwardProductRegistration = new ForwardProductRegistrationPage();
			if(Report.IsTrue(forwardProductRegistration.SelectRetailerActionLinksListExists(), $"Failure, failed to confirm Select Retailer Action Links list does exist.", $"Success, confirmed Select Retailer Action Link list does exist."))
			{
				Report.IsTrue(expected == forwardProductRegistration.SelectRetailerActionLinkExists(linkLabel), $"Failure, failed to confirm '{linkLabel}' select retailer action link {does_doesnot} exist.", $"Success, confirmed '{linkLabel}' select retailer action link {does_doesnot} exist.");
			}
		}

		[RegexStepDefinition(@"In the Select Retailers Tab, click (Select all|Show list view|Show logo tile view) Select Retailer Action Link")]
		public void SelectRetailersTabClickSelectRetailerActionLink(string linkLabel)
		{
			ForwardProductRegistrationPage forwardProductRegistration = new ForwardProductRegistrationPage();
			if (Report.IsTrue(forwardProductRegistration.SelectRetailerActionLinksListExists(), $"Failure, failed to confirm Select Retailer Action Links list does exist.", $"Success, confirmed Select Retailer Action Link list does exist."))
			{
				if(Report.IsTrue(forwardProductRegistration.SelectRetailerActionLinkExists(linkLabel), $"Failure, failed to confirm '{linkLabel}' select retailer action link does exist.", $"Success, confirmed '{linkLabel}' select retailer action link does exist."))
				{
					Report.IsTrue(forwardProductRegistration.SelectRetailerActionLinkClick(linkLabel), $"Failure, failed to click '{linkLabel}' select retailer action link.", $"Success, clicked '{linkLabel}' select retailer action link.");
				}
			}
		}

		[RegexStepDefinition(@"In the Select Retailers Tab, confirm Selectable Retailers list (does|does not) exist")]
		public void SelectRetailersTabConfirmSelectableRetailersListExists(string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			ForwardProductRegistrationPage forwardProductRegistration = new ForwardProductRegistrationPage();
			Report.IsTrue(expected == forwardProductRegistration.SelectableRetailersListExists(), $"Failure, failed to confirm selectable retailers list {does_doesnot} exist.", $"Success, confirmed selectable retailers list {does_doesnot} exist.");
		}

		[RegexStepDefinition(@"In the Select Retailers Tab, confirm (.*) Selectable Retailer (does|does not) exist")]
		public void SelectRetailersTabConfirmSelectableRetailerExists(string retailerLabel, string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			ForwardProductRegistrationPage forwardProductRegistration = new ForwardProductRegistrationPage();
			if(Report.IsTrue(forwardProductRegistration.SelectableRetailersListExists(), $"Failure, failed to confirm selectable retailers list does exist.", $"Success, confirmed selectable retailers list does exist."))
			{
				Report.IsTrue(expected == forwardProductRegistration.SelectableRetailerExists(retailerLabel), $"Failure, failed to confirm '{retailerLabel}' selectable retailer {does_doesnot} exist.", $"Success, confirmed '{retailerLabel}' selectable retailer {does_doesnot} exist.");
			}
		}

		[RegexStepDefinition(@"In the Select Retailers Tab, click (.*) Selectable Retailer Checkbox")]
		public void SelectRetailersTabClickSelectableRetailerCheckbox(string retailerLabel)
		{
			ForwardProductRegistrationPage forwardProductRegistration = new ForwardProductRegistrationPage();
			if (Report.IsTrue(forwardProductRegistration.SelectableRetailersListExists(), $"Failure, failed to confirm selectable retailers list does exist.", $"Success, confirmed selectable retailers list does exist."))
			{
				if(Report.IsTrue(forwardProductRegistration.SelectableRetailerExists(retailerLabel), $"Failure, failed to confirm '{retailerLabel}' selectable retailer does exist.", $"Success, confirmed '{retailerLabel}' selectable retailer does exist."))
				{
					Report.IsTrue(forwardProductRegistration.SelectableRetailer(retailerLabel).CheckboxClick(), $"Failure, failed to click '{retailerLabel}' selectable retailer checkbox.", $"Success, clicked '{retailerLabel}' selectable retailer checkbox.");
				}
			}
		}

		[RegexStepDefinition(@"In the Select Retailers Tab, confirm (.*) Selectable Retailer Checkbox (is|is not) checked")]
		public void SelectRetailersTabConfirmSelectableRetailerCheckboxChecked(string retailerLabel, string is_isnot)
		{
			bool expected = is_isnot == "is";
			ForwardProductRegistrationPage forwardProductRegistration = new ForwardProductRegistrationPage();
			if (Report.IsTrue(forwardProductRegistration.SelectableRetailersListExists(), $"Failure, failed to confirm selectable retailers list does exist.", $"Success, confirmed selectable retailers list does exist."))
			{
				if (Report.IsTrue(forwardProductRegistration.SelectableRetailerExists(retailerLabel), $"Failure, failed to confirm '{retailerLabel}' selectable retailer does exist.", $"Success, confirmed '{retailerLabel}' selectable retailer does exist."))
				{
					Report.IsTrue(expected == forwardProductRegistration.SelectableRetailer(retailerLabel).CheckboxChecked(), $"Failure, failed to confirm '{retailerLabel}' selectable retailer checkbox {is_isnot} checked.", $"Success, confirmed '{retailerLabel}' selectable retailer checkbox {is_isnot} checked.");
				}
			}
		}

		[RegexStepDefinition(@"In the Select Retailers Tab, confirm (.*) Selectable Retailer (is|is not) in the 'You most recently did buisness with...' section")]
		public void SelectRetailersTabConfirmSelectableRetailerIsRecent(string retailerLabel, string is_isnot)
		{
			bool expected = is_isnot == "is";
			ForwardProductRegistrationPage forwardProductRegistration = new ForwardProductRegistrationPage();
			if (Report.IsTrue(forwardProductRegistration.SelectableRetailersListExists(), $"Failure, failed to confirm selectable retailers list does exist.", $"Success, confirmed selectable retailers list does exist."))
			{
				if (Report.IsTrue(forwardProductRegistration.SelectableRetailerExists(retailerLabel), $"Failure, failed to confirm '{retailerLabel}' selectable retailer does exist.", $"Success, confirmed '{retailerLabel}' selectable retailer does exist."))
				{
					Report.IsTrue(expected == forwardProductRegistration.SelectableRetailer(retailerLabel).IsRecent(), $"Failure, failed to confirm '{retailerLabel}' selectable retailer {is_isnot} in the 'You most recently did business with...' section.", $"Success, confirmed '{retailerLabel}' selectable retailer {is_isnot} in the 'You most recently did business with...' section.");
				}
			}
		}
		#endregion

		#region Select UPCs Tab Steps
		[RegexStepDefinition(@"In the Select UPCs Tab, confirm Select Products Table Product Rows list (does|does not) exist")]
		public void SelctUPCsTabConfirmSelectProductsTableProductRowsListExists(string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			ForwardProductRegistrationPage forwardProductRegistration = new ForwardProductRegistrationPage();
			Report.IsTrue(expected == forwardProductRegistration.SelectProductsProductRowsListExists(), $"Failure, failed to confirm Select Products Table Product Rows list {does_doesnot} exist.", $"Success, confirmed Select Products Table Product Rows list {does_doesnot} exist.");
		}

		[RegexStepDefinition(@"In the Select UPCs Tab, confirm Select Products Table Product Row with (.*) Product Name (does|does not) exist")]
		public void SelectUPCsTabConfirmSelectProductsTableProductRowWithProductNameExists(string productName, string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			ForwardProductRegistrationPage forwardProductRegistration = new ForwardProductRegistrationPage();
			if(Report.IsTrue(forwardProductRegistration.SelectProductsProductRowsListExists(), $"Failure, failed to confirm Select Products Table Product Rows list does exist.", $"Success, confirmed Select Products Table Product Rows list does exist."))
			{
				Report.IsTrue(expected == forwardProductRegistration.SelectProductsProductRowByProductNameExists(productName), $"Failure, failed to confirm Select Products Table Product Row with '{productName}' Product Name {does_doesnot} exist.", $"Success, confirmed Select Products Table Product Row with '{productName}' Product Name {does_doesnot} exist.");
			}
		}

		[RegexStepDefinition(@"In the Select UPCs Tab, click Select Products Table Product Row with (.*) Product Name")]
		public void SelectUPCsTabClickSelectProductsTableProductRowWithProductName(string productName)
		{
			ForwardProductRegistrationPage forwardProductRegistration = new ForwardProductRegistrationPage();
			if (Report.IsTrue(forwardProductRegistration.SelectProductsProductRowsListExists(), $"Failure, failed to confirm Select Products Table Product Rows list does exist.", $"Success, confirmed Select Products Table Product Rows list does exist."))
			{
				if(Report.IsTrue(forwardProductRegistration.SelectProductsProductRowByProductNameExists(productName), $"Failure, failed to confirm Select Products Table Product Row with '{productName}' Product Name does exist.", $"Success, confirmed Select Products Table Product Row with '{productName}' Product Name does exist."))
				{
					Report.IsTrue(forwardProductRegistration.SelectProductsProductRowByProductName(productName).Click(), $"Failure, failed to click Select Products Table Product Row with '{productName}' Product Name.", $"Success, clicked Select Products Table Product Row with '{productName}' Product Name.");
				}
			}
		}
		#endregion
	}
}
