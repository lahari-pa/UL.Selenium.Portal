using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using UL.Automation.WebDriver.Classes;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps.New_Product.Product_Characteristics
{
	[Binding, Scope(Tag = "Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:Retailer")]
	class WERCSmart_Distributor_NewProducts_Retailer
	{
		[StepDefinition(@"In the Select Retailers window, select retailer: (.*)")]
		public void SelectRetailers(string retailer)
		{
			new Steps_Prototype().ISelectTheRetailer(retailer);
		}
		[StepDefinition(@"In the Retailer Section, click 'Add Retailers' button")]
		public void ClickAddRetailers()
		{
			string button = "Add Retailers";
			new Steps_Prototype().ClickButton(button);
		}
		[StepDefinition(@"In the Select Retailers window, click 'Done' button")]
		public void ClickDoneButton()
		{
			new Steps_Prototype().IClickDoneButtonOnSelectRetailersWindow();
		}
		[StepDefinition(@"In the Retailer Section, click 'Delete' icon")]
		public void ClickDeleteButton()
		{
			new Steps_Prototype().ThenIClickTheDeleteIconInTheRetailerPage();
		}
		[StepDefinition(@"In the Select Retailers window, click 'Show logo tile view' link")]
		public void ClickShowLogoTile()
		{
			string option = "logo tile view";
			new Steps_Prototype().ClickRetailersOption(option);
		}
		[StepDefinition(@"In the Select Retailers window, click 'Show list view' link")]
		public void ClickShowListTile()
		{
			string option = "list view";
			new Steps_Prototype().ClickRetailersOption(option);
		}
		[StepDefinition(@"In the Select Retailers window, click 'Select all' link")]
		public void ClickSelectAll()
		{
			string option = "select all";
			new Steps_Prototype().ClickRetailersOption(option);
		}
		[StepDefinition(@"In the Retailer Section, (check|uncheck) the retailer: (.*)")]
		public void CheckUncheckTheretailer(string condition, string retailer)
		{
			new Steps_Prototype().CheckUncheckTheRetailer(condition, retailer);
		}
		[StepDefinition(@"In the Retailer Section, for retailer: (.*) enter 'Indicate full name of product, as sold, via this retailer': (.*)")]
		public void EnterPrivateNameForRetailer(string retailer, string privateLabel)
		{
			new Steps_Prototype().ForRetailerIEnterPrivateLabelName(retailer, privateLabel);
		}
		[StepDefinition(@"In the Retailer Section, for retailer: (.*) select 'Indicate full name of product, as sold, via this retailer' option: (.*)")]
		public void SelectPrivateNameForRetailer(string retailer, string privateLabel)
		{
			new Steps_Prototype().RetailerPrivateLabelSelect(retailer, privateLabel);
		}
		[StepDefinition(@"In the Retailer Section, for retailer: (.*) select 'Select Vendor' option: (.*)")]
		public void SelectVendorOption(string retailer, string option)
		{
			new Steps_Prototype().SelectVendorInRetailerSection(retailer, option);
		}
		[StepDefinition(@"In the Retailer Section, for retailer: (.*) click 'Add New Supplier' button")]
		public void ClickAddNewSupplierButton(string retailer)
		{
			new Steps_Prototype().ClickAddNewSupplierInRetailerSection(retailer);
		}
		[StepDefinition(@"In the Retailer Section 'Add New Supplier' modal window, click 'Save' button")]
		public void ClickSaveAddNewSupplier()
		{
			string popupTitle = "Add New Supplier";
			string button = "Save";
			new Steps_Prototype().ThenInThePopupViewWithTheFollowingTitleIClickTheButton(popupTitle, button);
		}
		[StepDefinition(@"In the Retailer Section 'Add New Supplier' modal window, click 'Cancel' button")]
		public void ClickCancelAddNewSupplier()
		{
			string popupTitle = "Add New Supplier";
			string button = "Cancel";
			new Steps_Prototype().ThenInThePopupViewWithTheFollowingTitleIClickTheButton(popupTitle, button);
		}
		[StepDefinition(@"In the Retailer Section 'Add New Supplier' enter 'Supplier ID': (.*)")]
		public void EnterSupplierIdAddNewSupplier(string supplierId)
		{
			new Steps_Prototype().GivenInTheAddNewSupplierDialogIEnterTheFollowingInTheSupplierIDInput(supplierId);
		}
		[StepDefinition(@"In the Retailer Section 'Add New Supplier' enter 'Company or Brand Name': (.*)")]
		public void EnterCompanyBrandNameAddNewSupplier(string companyBrandName)
		{
			new Steps_Prototype().GivenInTheAddNewSupplierDialogIEnterTheFollowingInTheCompanyOrBrandNameInput(companyBrandName);
		}
		[StepDefinition(@"In the Retailer Section after clicking 'Cancel' in 'Add New Supplier' modal window click (Ok|Cancel) in alert message 'Are you sure want to cancel\?'")]
		public void AcceptAlertAreYouSureToCancel(string responce)
		{
			new Steps_Prototype().AnAlertIsDisplayedWithTheMessage("should", "Are you sure want to cancel ?");
			if(responce == "Ok")
			{
				new Steps_Prototype().ConfirmThealertPopup("accept");
			}
			else
			{
				new Steps_Prototype().ConfirmThealertPopup("dismiss");
			}
			new Steps_Prototype().AnAlertIsDisplayedWithTheMessage("should not", "Are you sure want to cancel ?");

		}
	}
}
