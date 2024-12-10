using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reqnroll;
using UL.Automation.Reporting.Functions;
using UL.Automation.ReqnrollHelpers.Attributes;
using UL.Automation.WebDriver.Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;
using UL.Selenium.Portal.WERCSmart.Steps.New_Product;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps.New_Product.Product_Characteristics
{
	[Binding, Scope(Tag = "Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:Retailer")]
	class WERCSmart_Distributor_NewProducts_Retailer
	{
		[RegexStepDefinition(@"In the Select Retailers window, select retailer: (.*)")]
		public void SelectRetailers(string retailer)
		{
			var selectRetailers = new SelectRetailers();
			Report.IsTrue(selectRetailers.SelectRetailer(retailer), $"Failed to select retailer: {retailer}!", $"Successfully selected retailer: {retailer}");
		}
		[RegexStepDefinition(@"In the Retailer Section, click 'Add Retailers' button")]
		public void ClickAddRetailers()
		{
			string button = "Add Retailers";
			new Steps_Prototype().ClickButton(button);
		}
		[RegexStepDefinition(@"In the Select Retailers window, click 'Done' button")]
		public void ClickDoneButton()
		{
			Report.IsTrue(new SelectRetailers().ClickDone(), "Failed to click Done button.", "Successfully clicked Done button.");
		}
		[RegexStepDefinition(@"In the Retailer Section, click 'Delete' icon")]
		public void ClickDeleteButton()
		{
			var retailerObject = new Retailer();
			Report.IsTrue(retailerObject.SelectTheDeleteSelectedRetailersButton(), "Failed to delete selected retailers", "Successfully deleted selected retailers");
		}
		[RegexStepDefinition(@"In the Select Retailers window, click 'Show logo tile view' link")]
		public void ClickShowLogoTile()
		{
			string option = "logo tile view";
			new Steps_Prototype().ClickRetailersOption(option);
		}
		[RegexStepDefinition(@"In the Select Retailers window, click 'Show list view' link")]
		public void ClickShowListTile()
		{
			string option = "list view";
			new Steps_Prototype().ClickRetailersOption(option);
		}
		[RegexStepDefinition(@"In the Select Retailers window, click 'Select all' link")]
		public void ClickSelectAll()
		{
			string option = "select all";
			new Steps_Prototype().ClickRetailersOption(option);
		}
		[RegexStepDefinition(@"In the Retailer Section, (check|uncheck) the retailer: (.*)")]
		public void CheckUncheckTheretailer(string condition, string retailer)
		{
			Report.IsTrue(new Retailer().CheckUncheckRetailer(condition, retailer), $"Failed to {condition} retailer: {retailer}!", $"Successfully {condition}ed retailer: {retailer}");
		}
		[RegexStepDefinition(@"In the Retailer Section, for retailer: (.*) enter 'Indicate full name of product, as sold, via this retailer': (.*)")]
		public void EnterPrivateNameForRetailer(string retailer, string option)
		{
			Report.IsTrue(new Retailer().EnterPrivateLabelName(option, retailer), $"Failed to set the Private label name to be: {option} for retailer: {retailer}", $"Successfully set private label name to be: {option} for retailer: {retailer}");
		}
		[RegexStepDefinition(@"In the Retailer Section, for retailer: (.*) select 'Indicate full name of product, as sold, via this retailer' option: (.*)")]
		public void SelectPrivateNameForRetailer(string retailer, string option)
		{
			Report.IsTrue(new RetailersRow(retailer).EnterSelectName(option), $"Failed to select full name {option} for {retailer} retailer", $"Successfully selected full name {option} for {retailer} retailer");

			//Report.IsTrue(new Retailer().RetailerPrivateLabelOptionSelect(retailer, option), $"Failed to set the Private label name to be: {option} for retailer: {retailer}", $"Successfully set private label name to be: {option} for retailer: {retailer}");
		}
		[RegexStepDefinition(@"In the Retailer Section, for retailer: (.*) select 'Select Vendor' option: (.*)")]
		public void SelectVendorOption(string retailer, string option)
		{
			if (option == "any")
			{
				Report.IsTrue(new RetailersRow(retailer).EnterSelectAnyVendor(), $"Failed to select Vendor for {retailer} retailer", $"Successfully selected Vendor for {retailer} retailer");
			}
			else
			{
				Report.IsTrue(new RetailersRow(retailer).EnterSelectVendor(option), $"Failed to select Vendor {option} for {retailer} retailer", $"Successfully selected Vendor {option} for {retailer} retailer");
			}
		}
		[RegexStepDefinition(@"In the Retailer Section, for retailer: (.*) click 'Add New Supplier' button")]
		public void ClickAddNewSupplierButton(string retailer)
		{
			Report.IsTrue(new RetailersRow(retailer).ClickAddNewSupplier(), $"Failed to click 'Add New Supplier' button for {retailer} retailer", $"Successfully clicked 'Add New Supplier' button for {retailer} retailer");
		}
		[RegexStepDefinition(@"In the Retailer Section 'Add New Supplier' modal window, click 'Save' button")]
		public void ClickSaveAddNewSupplier()
		{
			string popupTitle = "Add New Supplier";
			string button = "Save";
			new Steps_Prototype().ThenInThePopupViewWithTheFollowingTitleIClickTheButton(popupTitle, button);
		}
		[RegexStepDefinition(@"In the Retailer Section 'Add New Supplier' modal window, click 'Cancel' button")]
		public void ClickCancelAddNewSupplier()
		{
			string popupTitle = "Add New Supplier";
			string button = "Cancel";
			new Steps_Prototype().ThenInThePopupViewWithTheFollowingTitleIClickTheButton(popupTitle, button);
		}
		[RegexStepDefinition(@"In the Retailer Section 'Add New Supplier' enter 'Supplier ID': (.*)")]
		public void EnterSupplierIdAddNewSupplier(string supplierId)
		{
			var thisAddNewSupplier = new AddNewSupplier();
			Report.IsTrue(thisAddNewSupplier.EnterSupplierID(supplierId), "Failed to add supplier ID input",
				"Entered supplier ID value");
		}
		[RegexStepDefinition(@"In the Retailer Section 'Add New Supplier' enter 'Company or Brand Name': (.*)")]
		public void EnterCompanyBrandNameAddNewSupplier(string companyBrandName)
		{
			var thisAddNewSupplier = new AddNewSupplier();
			Report.IsTrue(thisAddNewSupplier.EnterCompanyOrBrandName(companyBrandName), "Failed to add company or brand name input",
				"Entered company or brand name value");
		}
		[RegexStepDefinition(@"In the Retailer Section after clicking 'Cancel' in 'Add New Supplier' modal window click (Ok|Cancel) in alert message 'Are you sure want to cancel\?'")]
		public void AcceptAlertAreYouSureToCancel(string responce)
		{
			new Steps_Prototype().AnAlertIsDisplayedWithTheMessage("should", "Are you sure want to cancel ?");
			if (responce == "Ok")
			{
				new Steps_Prototype().ConfirmThealertPopup("accept");
			}
			else
			{
				new Steps_Prototype().ConfirmThealertPopup("dismiss");
			}
			new Steps_Prototype().AnAlertIsDisplayedWithTheMessage("should not", "Are you sure want to cancel ?");

		}
		[RegexStepDefinition(@"In the Retailer Section (is|is not) selected retailer: (.*)")]
		public void SelectedRetailersShouldBe(string is_isnot, string retailer)
		{
			var actualRetailers = new Retailer().SelectedRetailers();
			bool expected = is_isnot == "is";
			Report.IsTrue(actualRetailers.Contains(retailer) == expected, $"Failure, the selected retailer {(expected ? "is not" : "is")} added.", $"Success, the selected retailer {is_isnot} added.");

		}
		[RegexStepDefinition(@"In the Retailer Section, following retailers (should|should not) be displayed:")]
		public void DisplayedRetaiers(string condition, Table table)
		{
			new Steps_Retailer().SelectedRetailersShouldBe(condition, table);
		}
		[RegexStepDefinition("In the Select Retailers window, confirm that (.*) is listed as a retailer")]
		public void ThenInTheSelectRetailersWindowConfirmThatCanadianTireIsListedAsARetailer(string retailer)
		{
			Report.IsTrue(new SelectRetailers().GetListOfRetailers().Contains(retailer),
							$"Retailer is not listed: {retailer}", $"Retailer is listed as expected: {retailer}");
		}
		[RegexStepDefinition(@"In the Retailer Section confirm that the product names from the drop down for: Indicate full name of product, as sold, via this retailer \(e.g. Private Label Aspirin\) for Wal-Mart appear in alphabetical order")]
		public void ThenInTheRetailerSectionConfirmThatTheProductNamesFromTheDropDownForIndicateFullNameOfProductAsSoldViaThisRetailerE_G_PrivateLabelAspirinForWal_MartAppearInAlphabeticalOrder()
		{

			string dropDownTitle = "Indicate full name of product, as sold, via this retailer (e.g. Private Label Aspirin)";
			string retailer = "Wal-Mart";
			var retailerObject = new Retailer();
			Report.IsTrue(retailerObject.ConfirmDropDownOptionsAreInAlphabeticalOrderForRetailer(dropDownTitle, retailer), "Drop down options were not in alphabetical order", "Drop down options were in alphabetical order");
		}

	}
}
