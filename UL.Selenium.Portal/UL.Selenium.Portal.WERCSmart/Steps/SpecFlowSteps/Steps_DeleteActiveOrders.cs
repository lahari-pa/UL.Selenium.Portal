using Reqnroll;
using System.Linq;
using UL.Automation.Reporting.Functions;
using UL.Automation.ReqnrollHelpers.Attributes;
using UL.Automation.WebDriver.Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using System;
using System.IO;
using UL.Automation.ReqnrollHelpers.Classes;



namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps
{
	[Binding, Scope(Tag = "DeleteActiveOrdersPage")]
	class Steps_DeleteActiveOrders
	{
		[RegexStepDefinition(@"In the Delete Active Orders section, In UPC Number field enter value: (.*)")]
		public void EnterUPCNumber(string value)
		{
			string fieldname = "UPC Number";
			new DeleteActiveOrdersPage().EnterText(fieldname, value);
		}

		[RegexStepDefinition(@"In the Delete Active Orders section, In WPS ID field enter value: (.*)")]
		public void EnterWPSID(string value)
		{
			string fieldname = "WPS ID";
			new DeleteActiveOrdersPage().EnterText(fieldname, value);
		}

		[RegexStepDefinition(@"In the Delete Active Orders section, In Product Name field enter value: (.*)")]
		public void EnterProductName(string value)
		{
			string fieldname = "Product Name";
			new DeleteActiveOrdersPage().EnterText(fieldname, value);
		}

		[RegexStepDefinition(@"In the Delete Active Orders section, Filter the products by: (All|Not Yet Submitted|Completed)")]
		public void FilterTheProductsByOptions(string filter)
		{
			Report.Info("Filtering Product Grid by " + filter);
			var deleteActiveOrdersPage = new DeleteActiveOrdersPage();
			Report.IsTrue(deleteActiveOrdersPage.ClickStatusFilter(filter), $"Failed to click filter option:{filter}", $"Successfully filtered grid by: {filter}");
		}

		[RegexStepDefinition(@"In the Delete Active Orders section, click 'Filter' button")]
		public void ClickFilter()
		{
			string button = "Filter";
			new Steps_Prototype().ClickButton(button);
		}

		[RegexStepDefinition(@"In the Delete Active Orders section, click 'Clear Filter' button")]
		public void ClickClearFilter()
		{
			string button = "Clear Filter";
			new Steps_Prototype().ClickButton(button);
		}


		[RegexStepDefinition(@"In the Delete Active Orders section, Verify 'Products which have had no activity for 1 year or more are eligible for deletion on this screen' is displayed")]
		public void VerifyProductsWhichHasNoActivityIsDisplayed()
		{
			var deleteActiveOrdersPage = new DeleteActiveOrdersPage();
			Report.IsTrue(deleteActiveOrdersPage.VerifyTheTextProductsWhichHaveActivity(), "Failed to display 'Products which have had no activity for 1 year or more are eligible for deletion on this screen'", "Successfully displayed 'Products which have had no activity for 1 year or more are eligible for deletion on this screen'");
		}

		#region Pagiation Button Steps
		[RegexStepDefinition(@"In the Delete Active Orders section, confirm (Prev|…|Next) Pagination button (does|does not) exist")]
		public void DeleteActiveOrderPageConfirmPagiationButtonDoesDoesNotExist(string buttonLabel, string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			MyProductsTableFooter myProductTableFooter = new MyProductsTableFooter();
			Report.IsTrue(expected == myProductTableFooter.PaginationButtonExists(buttonLabel), $"Failure, failed to confirm {buttonLabel} pagination button {does_doesnot} exist.", $"Success, confirmed {buttonLabel} pagination button {does_doesnot} exist.");
		}

		[RegexStepDefinition(@"In the Delete Active Orders section, click (Prev|…|Next) Pagination button")]
		public void DeleteActiveOrderPageClickPagiationButton(string buttonLabel)
		{
			MyProductsTableFooter myProductTableFooter = new MyProductsTableFooter();
			if (Report.IsTrue(myProductTableFooter.PaginationButtonExists(buttonLabel), $"Failure, failed to confirm {buttonLabel} pagination button does exist.", $"Success, confirmed {buttonLabel} pagination button does exist."))
			{
				Report.IsTrue(myProductTableFooter.PaginationButtonClick(buttonLabel), $"Failure, failed to click {buttonLabel} pagination button.", $"Success, click {buttonLabel} pagination button currently selected.");
			}
		}

		[RegexStepDefinition(@"In the Delete Active Orders section, confirm (Prev|…|Next) Pagination button (is|is not) disabled")]
		public void DeleteActiveOrderConfirmPagiationButtonIsIsNotDisabled(string buttonLabel, string is_isnot)
		{
			bool expected = is_isnot == "is";
			MyProductsTableFooter myProductTableFooter = new MyProductsTableFooter();
			if (Report.IsTrue(myProductTableFooter.PaginationButtonExists(buttonLabel), $"Failure, failed to confirm {buttonLabel} pagination button does exist.", $"Success, confirmed {buttonLabel} pagination button does exist."))
			{
				Report.IsTrue(expected == myProductTableFooter.PaginationButtonDisabled(buttonLabel), $"Failure, failed to confirm {buttonLabel} pagination button {is_isnot} disabled.", $"Success, confirmed {buttonLabel} pagination button {is_isnot} disabled.");
			}
		}

		[RegexStepDefinition(@"In the Delete Active Orders section, confirm (Prev|…|Next) Pagination button (is|is not) currently selected")]
		public void DeleteActiveOrderConfirmPagiationButtonIsIsNotSelected(string buttonLabel, string is_isnot)
		{
			bool expected = is_isnot == "is";
			MyProductsTableFooter myProductTableFooter = new MyProductsTableFooter();
			if (Report.IsTrue(myProductTableFooter.PaginationButtonExists(buttonLabel), $"Failure, failed to confirm {buttonLabel} pagination button does exist.", $"Success, confirmed {buttonLabel} pagination button does exist."))
			{
				Report.IsTrue(expected == myProductTableFooter.PaginationButtonCurrent(buttonLabel), $"Failure, failed to confirm {buttonLabel} pagination button {is_isnot} currently selected.", $"Success, confirmed {buttonLabel} pagination button {is_isnot} currently selected.");
			}
		}
		#endregion


		[RegexStepDefinition(@"In the Delete Active Orders section, click 'Make Obsolete' button")]
		public void ClickMakeObsolete()
		{
			string button = "Make Obsolete ";
			new Steps_Prototype().ClickButton(button);
		}

		#region Make Obsolete Popup

		[RegexStepDefinition(@"In the Delete Active Orders section, in the 'Make Obsolete' pop up click '(Accept|Cancel) button")]
		public void ClickAcceptCancelMakeObsoletePopUp(string button)
		{
			string popupTitle = "Make Obsolete";
			new Steps_Prototype().ThenInThePopupViewWithTheFollowingTitleIClickTheButton(popupTitle, button);
		}

		[RegexStepDefinition(@"In the Delete Active Orders section, the 'Make Obsolete' popup (should|should not) be displayed")]
		public void MakeObsoleteIsDisplayed(string condition)
		{
			string modalTitle = "Make Obsolete";
			new Steps_Prototype().ThenIConfirmThePopUpShowsTheHeading(condition, modalTitle);
		}

		[RegexStepDefinition(@"In the Delete Active Orders section, the 'Make Obsolete' popup click 'Accept' checkbox")]
		public void MakeObsoleteCheckboxClickAcceptCheckbox()
		{
			var deleteActiveOrdersPage = new DeleteActiveOrdersPage();
			Report.IsTrue(deleteActiveOrdersPage.ClickIAgreeCheckboxInMakeObsoletePopUp(), "Failed to click 'Accept' checkbox", "Successfully clicked 'Accept' checkbox");
		}

		#endregion


		[RegexStepDefinition(@"In the Delete Active Orders section, From the Select Supplier ID dropdown - Select option: (.*)")]
		public void SupplierIDDropdownSelectOption(string optionValue)
		{
			var deleteActiveOrdersPage = new DeleteActiveOrdersPage();
			Report.IsTrue(deleteActiveOrdersPage.SupplierIDDropdownExists(), $"Failed, Supplier ID dropdown is not displayed", $"Successfully displayed Supplier ID dropdown");
			Report.IsTrue(deleteActiveOrdersPage.SupplierIDDropdownClick(), $"Failed to click Supplier ID dropdown", $"Successfully clicked Supplier ID dropdown ");
			Report.IsTrue(deleteActiveOrdersPage.SupplierIDDropdownOptionExists(optionValue), $"Failed, Supplier ID dropdown option {optionValue} is not displayed", $"Successfully displayed Supplier ID dropdown option {optionValue}");
			Report.IsTrue(deleteActiveOrdersPage.SupplierIDDropdownOptionClick(optionValue), $"Failed to click option {optionValue} in Supplier ID dropdown", $"Successfully clicked option {optionValue} in Supplier ID dropdown");
		}

		[RegexStepDefinition(@"In the Delete Active Orders section, Verify 'Products' table is displayed")]
		public void VerifyProducrsTableIsDisplayed()
		{
			Report.IsTrue(new DeleteActiveOrdersPage().TableExists(), "Products table is not displayed", "Successfully Products table is displayed");
		}


		[RegexStepDefinition(@"In the Delete Active Orders section, Select Product checkbox for 'Product Name': (.*)")]
		public void SelectProductForProductName(string productName)
		{
			Report.IsTrue(new DeleteActiveOrdersPage().SelectProductBasedOnProductName(productName), $"Failed to select product for product name {productName}", $"Successfully selected product for product name {productName}");
		}


		[RegexStepDefinition(@"In the Delete Active Orders section, Select Product checkbox for 'UPC Number': (.*)")]
		public void SelectProductForUPCNumber(string upc)
		{
			Report.IsTrue(new DeleteActiveOrdersPage().SelectProductBasedOnUPCNUmber(upc), $"Failed to select product for UPC Number {upc}", $"Failed to select product for UPC Number  {upc}");
		}

		[RegexStepDefinition(@"In the Delete Active Orders section, Select Product checkbox for 'WPS ID': (.*)")]
		public void SelectProductForWPSID(string wpsid)
		{
			Report.IsTrue(new DeleteActiveOrdersPage().SelectProductBasedOnWPSID(wpsid), $"Failed to select product for WPS ID {wpsid}", $"Successfully selected product for WPS ID {wpsid}");
		}

		[RegexStepDefinition(@"In the Delete Active Orders section, Select All Product checkbox")]
		public void SelectAllProductCheckbox()
		{
			Report.IsTrue(new DeleteActiveOrdersPage().SelectAllProductsCheckbox(), "Failed to select all products", "Successfully selected all products");
		}
	}


}

