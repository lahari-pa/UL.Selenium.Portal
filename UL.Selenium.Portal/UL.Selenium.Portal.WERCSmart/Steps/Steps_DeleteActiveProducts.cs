using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reqnroll;
using UL.Automation.Reporting.Functions;
using UL.Automation.ReqnrollHelpers.Attributes;
using UL.Automation.WebDriver.Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;

namespace UL.Selenium.Portal.WERCSmart.Steps
{
	[Binding, Scope(Tag = "DeleteActiveProducts")]
	class Steps_DeleteActiveProducts
	{

		[RegexStepDefinition(@"I select checkbox for product saved as: (.*)")]
		public void ThenISelectCheckboxForProductSavedAs(string wpsID)
		{
			var deleteActiveProductsObject = new DeleteActiveProducts();
			wpsID = deleteActiveProductsObject.GetProductIDFromContext(wpsID);
			Report.IsTrue(deleteActiveProductsObject.SelectCheckboxForProductWithWPSID(wpsID), "Failed to select checkbox", "Successfully selected checkbox");
		}


		[RegexStepDefinition(@"In the Delete Active Products page I click the Filter button")]
		public void ThenInTheDeleteActiveProductsPageIClickTheFilterButton()
		{
			var deleteActiveProductsObject = new DeleteActiveProducts();
			Report.IsTrue(deleteActiveProductsObject.ClickFilterButtonInDeleteActiveProductsPage(), "Failed to click Filter button", "Successfully clicked Filter button");
			Delay.Seconds(10);
		}

		[RegexStepDefinition(@"In the Delete Active Products page I click the Clear Filter button")]
		public void ThenInTheDeleteActiveProductsPageIClickTheClearFilterButton()
		{
			var deleteActiveProductsObject = new DeleteActiveProducts();
			Report.IsTrue(deleteActiveProductsObject.ClickClearFilterButtonInDeleteActiveProductsPage(), "Failed to click Filter button", "Successfully clicked Filter button");
			Delay.Seconds(10);
		}


		[RegexStepDefinition(@"In the Delete Active Products page I search for WPS ID saved as: (.*)")]
		public void ThenInTheDeleteActiveProductsPageISearchForWPSIDSavedAs(string wpsID)
		{
			var deleteActiveProductsObject = new DeleteActiveProducts();
			wpsID = deleteActiveProductsObject.GetProductIDFromContext(wpsID);
			Report.IsTrue(deleteActiveProductsObject.EnterTextInSearchBarInDeleteActiveProductsPage(wpsID), "Failed to enter WPS ID number in the searchbar", "Successfully entered WPS ID number in the searchbar");
		}

		[RegexStepDefinition(@"I (select|deselect) the checkbox next to WPS ID in the Delete Active Products page")]
		public void ThenISelectTheCheckboxNextToWPSIDInTheDeleteActiveProductsPage(string selectOrDeselect)
		{
			var deleteActiveProductsObject = new DeleteActiveProducts();
			Report.IsTrue(deleteActiveProductsObject.SelectCheckBoxNextToWPSIDLabel(selectOrDeselect), "Failed to " + selectOrDeselect + " checkbox next to WPS ID Label", "Successfully  " + selectOrDeselect + "ed checkbox next to WPS ID Label");
		}

		[RegexStepDefinition(@"I confirm all checkboxes are (selected|deselected) in the Delete Active Products page")]
		public void ThenIConfirmAllCheckboxesAreSelectedInTheDeleteActiveProductsPage(string selectedOrDeselected)
		{
			var deleteActiveProductsObject = new DeleteActiveProducts();
			Report.IsTrue(deleteActiveProductsObject.ConfirmAllProductsInListAreChecked(selectedOrDeselected), "Not all products in product list are " + selectedOrDeselected, "All products in product list are " + selectedOrDeselected);
		}

		[RegexStepDefinition(@"I click on the Make Obsolete button")]
		public void ThenIClickOnTheMakeObsoleteButton()
		{
			var deleteActiveProductsObject = new DeleteActiveProducts();
			Report.IsTrue(deleteActiveProductsObject.ClickMakeObsoleteButton(), "Failed to click 'Make Obsolete' button", "Successfully clicked 'Make Obsolete' button");
			Delay.Seconds(5);
		}

		[RegexStepDefinition(@"I select the checkbox in the Make Obsolete popup")]
		public void ThenIClickOnTheCheckboxInTheMakeObsoletePopup()
		{
			var deleteActiveProductsObject = new DeleteActiveProducts();
			Report.IsTrue(deleteActiveProductsObject.SelectCheckBoxInMakeObsoletePopup(), "Failed to select the checkbox in the Make Obsolete popup", "Successfully selected the checkbox in the Make Obsolete popup");
		}

		[RegexStepDefinition(@"In the Make Obsolete popup I click on the (Accept|Cancel) button")]
		public void GivenInTheDataAcceptancePageIClickOnTheAcceptButton(string acceptOrCancel)
		{
			var deleteActiveProductsObject = new DeleteActiveProducts();
			Report.IsTrue(deleteActiveProductsObject.ClickAcceptButtonInMakeObsoletePopup(acceptOrCancel), "Failed to click " + acceptOrCancel + " button", "Successfully clicked " + acceptOrCancel + " button");
			Delay.Seconds(5);
		}

	}
}
