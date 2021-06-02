using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UL.Automation.Selenium.Classes;
using UL.Automation.Reporting.Functions;
using UL.Automation.SpecFlow.Classes;
using UL.Automation.Utilities.Functions;
using TechTalk.SpecFlow;
using UL.Automation.Reporting;
using UL.Automation.TReVor.Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product.Product_Type;
using UL.Selenium.Portal.WERCSmart.Steps.New_Product;
using UL.Selenium.Portal.WERCSmart.Steps.New_Product.Product_Type;

namespace UL.Selenium.Portal.WERCSmart.Steps
{
	[Binding, Scope(Tag = "ProductSetUp")]
	class Steps_ProductSetup : TechTalk.SpecFlow.Steps
	{
		[StepDefinition(
			@"I create a Walmart product and take to completed using Test Case 75335 \(SOLD set to US only with Walmart as retailer\) and save as: (.*)")]
		public void CreateProductUsingTestCase75335Walmart(string savedAs)
		{

			Report.Info("Create Walmark product using Test Case 75335");
			var sharedSteps = new Steps_Shared();
			var productsGridSteps = new StepsProductGrid();
			var newProductSteps = new StepsNewProduct();
			var newProduct = new NewProduct();
			var shaSteps = new Steps_SHA();
			// Log in to administrator role
			sharedSteps.GivenICallSharedStep67823LoginToWERCSmart_ProductsAutomationAccount();
			//sharedSteps.Shared68210_LoginToWercSmart_PremiumAccount();
			// Generate UPC number and delete duplicates
			productsGridSteps.GivenIGenerateARandomUPCNumberAndSaveAs("UPC75335");
			productsGridSteps.DeleteAllProductsMatchingCriteria("UPC Number", "saved as UPC75335");
			// 57408 (Create a New Registration via Register New Product icon)
			sharedSteps.GivenICallSharedStepCreateANewRegistrationViaRegisterNewProductIcon();
			// 57500 (The Product- Enter name, select product type - Continue - Happy Path)
			sharedSteps.GivenICallSharedStepTheProduct_EnterNameSelectProductType_Continue_HappyPath("Chalk");
			// Save product to context
			newProductSteps.SaveProductInformation(savedAs);
			// 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
			sharedSteps.ICallSharedProductInformationUSOnlyNoChildNoGHSNoDirectShipNoPLPNoGNFR();
			// 26897 (Product Characteristics - Solid only available - continue)
			sharedSteps.SharedPhysicalandChemicalProperties_SolidOnlyAvailable_Continue();
			// 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
			sharedSteps.ICallSharedIngredients_AddAnyChemical("Sodium hydroxide");
			// 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
			sharedSteps.ICallSharedRegulatoryInformation1_TSCARandom_Pro65No_Continue();
			// Select Walmart as the retailer and continue
			sharedSteps.Shared77845_Retailer_SelectWM_Done_SelectVendorID_Continue();
			// 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC75335, container type: Metal Container and size: 40
			sharedSteps.GivenICallSharedEnterUniversalProductCodeUPC_UPC_ContainerType_SizeOnly("75335",
				"Metal Container", "40");
			// 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
			sharedSteps.GivenICallSharedRegulatoryDocumentsToProvide_USOnly_RequestAuthoring_HappyPath();
			// Click continue
			newProductSteps.ClickContinue();
			// Click continue
			newProductSteps.ClickContinue();
			// 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
			var sdsTable = new Table("Personal Protection Equipment", "Autoignition Temperature",
				"Minimum Ignition Energy", "Viscosity", "Appearance", "Odor", "Odor Threshold",
				"Partition Coefficient");
			sdsTable.AddRow("Mask", "300", "1", "20", "Black", "Odorless", "No data available", "10");
			sharedSteps
				.GivenICallSharedSafetyDataSheetAuthoring_AditionalDataStep_AddAnyRandomDataForAllFields_HappyPath(
					sdsTable);
			// 57883 (Comments - Happy Path) and enter the comment: Test Comment 75335
			sharedSteps.GivenICallSharedCommentsHappyPath("Test Comment 75335");
			// 57885 (Data Acceptance - Click Accept - Happy Path)
			sharedSteps.GivenICallSharedDataAcceptance_ClickAccept_HappyPath();
			// If purchase details are showing click confirm order
			newProductSteps.GivenIfPurchaseDetailsAreShowingClickConfirmOrder();
			// 65080 (Login to Studio and Open SHA manager)
			sharedSteps.GivenICallShared65080LoginToStudioAndOpenSHAManager();
			// 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase75335)
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			// In the SHA manager grid I see the WPS ID I have saved as product: TestCase75335 and its status is: Submitted
			shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(savedAs,
				"Submitted");
			// 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase75335)
			sharedSteps.GivenICallSharedSHAManager_Submitted_SelectProductProcessProductData(savedAs);
			// 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase75335)
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			// In the SHA manager grid I see the WPS ID I have saved as product: TestCase75335 and its status is: Assigned
			shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(savedAs,
				"Assigned");
			// 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase75335)
			sharedSteps.GivenICallSharedWPSStudio_JobQueue_WaitForImportProcessRulesJobToComplete(savedAs);
			// 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase75335)
			sharedSteps.GivenICallSharedWPSStudio_OpenPDEditExistingWithSpecificProductClickContinue(savedAs);
			// 75347 (WPS Studio - PD+ - set all data and publish using rule and Doc queue - CKLT, NGHS and SBCS) for product saved as: TestCase75335
			sharedSteps.GivenICallSharedWPSStudio_PD_SetAllDataAndPublishUsingRuleAndDocQueue_CKLTNGHSAndSBCS(savedAs);
			// 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase75335)
			sharedSteps.GivenICallShared55663WPSStudio_GoToJobQueue_WaitForPublishMultipleToComplete(savedAs);
			// 59066(Go to SHA Manager)
			sharedSteps.GivenICallSharedStep59066GoToSHAManager();
			// 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase75335)
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			// In the SHA manager grid I see the WPS ID I have saved as product: TestCase75335 and its status is: Accepted
			shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(savedAs,
				"Accepted");
			// 49841 (SHA - Search for exact WPS ID in Accepted Status for saved as: TestCase75335)
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("Accepted", savedAs);
			// 51664 (SHA - Accepted Product - set Retailers to Completed for saved as: TestCase75335)
			var table4 = new Table(new string[] {
				"Retailer"
			});
			table4.AddRow(new string[] {
				"Wal-Mart/SAM'S CLUB (WM)"
			});
			sharedSteps.GivenICallShared51664SHA_AcceptedProduct_SetRetailersToCompletedForSavedAs(savedAs, table4);
			// 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase75335)
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			// In the SHA manager grid I see the WPS ID I have saved as product: TestCase75335 and its status is: Completed
			shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(savedAs,
				"Completed");
		}

		[StepDefinition(@"I create a new product which has SOLD = US only, PL = No and is in completed status for One or more retailers and save the product as: (.*)")]
		public void GivenICreateANewProductWhichHasSOLDUSOnlyPLNoAndIsInCompletedStatusForOneOrMoreRetailersAndSaveTheProductAs(string savedAs)
		{
			new Steps_ProductSetup().GivenICreateProductUsingTestCase75335(savedAs, "Chalk");
		}

		[StepDefinition(@"I create a product with name: (.*) and take to completed using Test Case 75335 and save as: (.*)")]
		public void GivenICreateProductUsingTestCase75335(string name, string savedAs)
		{
			this.CreateProductUsingTestCase75335(savedAs, name);
		}

		[StepDefinition(@"I create a product and take to completed using Test Case 75335 and save as: (.*)")]
		public void GivenICreateProductUsingTestCase75335(string savedAs)
		{
			this.CreateProductUsingTestCase75335(savedAs, "Chalk");
		}

		


		[StepDefinition(@"I create a product with name: (.*) and UPC: (.*) and take to completed using Test Case 75335 with no login step and save as: (.*)")]
		public void GivenICreateProductUsingTestCase75335(string name, string upc, string savedAs)
		{
			this.CreateProductUsingTestCase75335(savedAs, upc, name);
		}


		[StepDefinition(@"I create a new product of type: Bleach, with a Product Line/ Brand added and select Type of Product: (.*)")]
		public void CreateProductWithProductLineBrand(string type)
		{
			ReportSettings.UseSubSteps = true;
			var sharedSteps = new Steps_Shared();
			var newProductSteps = new StepsNewProduct();
			// 57408 (Create a New Registration via Register New Product icon)
			Report.StartStep("I create a new registration with the beaker icon");
			sharedSteps.GivenICallSharedStepCreateANewRegistrationViaRegisterNewProductIcon();
			Report.StartStep("I should see the The Product Page");
			newProductSteps.GivenIShouldSeeXPage("The Product");
			string testCaseId = TReVorSettings.TestCaseId;
			if (testCaseId == null)
			{
				throw new Exception("Unable to locate a test case ID in global parameters which is required!");
			}

			Report.StartStep(
				"In the Product Type tab of the New Product Page, I enter: Bleach in the Type of Product select field");
			//newProductSteps.GivenInTheProductTypeTabOfTheNewProductPageIEnterXInTheTypeOfProductSelectField("Bleach");
			new Steps_TheProduct().SetProductNameTo("Bleach");
			Report.StartStep(
				"I select the first option in the 'Product Line or Brand' drop down and save as: Brand" + testCaseId);
			newProductSteps.SelectFirstOptionInBrandDropDown();
			Report.StartStep("In the Product Type tab of the New Product Page, I enter: " + type + " in the Type of Product select field");
			new Steps_TheProduct().SetTypeOfProductTo(type);
			Report.StartStep("I click Continue");
			newProductSteps.ClickContinue();
			Report.StartStep("I save the product information as TestCase" + testCaseId);
			ProductInformation prodDetails = new NewProduct().GetCurrentProductInformation();
			Context.AddToContext($"TestCase{testCaseId}", prodDetails);
			Report.StartStep("Navigate to the home page");
			new StepsHomepage().ThenINavigateToTheHomePage();
		}

		[StepDefinition(@"I take a product from completed to recertification using Test Case 75410 saved: (.*)")]
		public void TakeProductFromCompletedToRecertification(string savedAs)
		{
			ReportSettings.UseSubSteps = true;
			var sharedSteps = new Steps_Shared();
			var newProductSteps = new StepsNewProduct();
			var shaSteps = new Steps_SHA();
			var thisGlobalSteps = new GlobalSteps();
			var thisStepsProductGrid = new StepsProductGrid();
			var thisStepsHomePage = new StepsHomepage();


			thisGlobalSteps.NavigateToLandingPage();
			sharedSteps.GivenICallSharedStep67823LoginToWERCSmart_ProductsAutomationAccount();
			thisStepsProductGrid.GivenISearchForTheProductSavedAs(savedAs);
			thisStepsProductGrid.GivenForProductSavedAsTestCaseTheStatusIs(savedAs, "Completed");
			thisStepsProductGrid.WhenIClickRowActionsForTheFirstProductReturned();
			thisStepsProductGrid.ClickRowAction("Update Data");
			thisStepsProductGrid.IShouldSeeTheUpdateRegistrationPopup();
			thisStepsProductGrid.InUpdateRegistrationPopupIClickButton("Yes");
			newProductSteps.GivenIShouldSeeXPage("The Product");
			newProductSteps.ThenIClickSaveOrCancelInTheProductPage("Save");
			sharedSteps.GivenICallShared65080LoginToStudioAndOpenSHAManager();
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(savedAs,
				"Completed");
			shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsAndItsFontIsRedOrNotRedIndicatingARecertification(
				savedAs, "red");
			sharedSteps.GivenICallSharedStep51351SHASelectProductViewRecertificationHistoryForProductSavedAs(savedAs);

			var recertification = new Table(new string[] {
				"Product ID",
				"Active",
				"Recertification Reason"
			});
			recertification.AddRow(new string[] {
				"saved as " + savedAs,
				"true",
				"Recertification of Product by WERCSmart Customer"
			});
			shaSteps.GivenInTheProductRecertificationHistoryPopupIShouldSeeTheFollowingEntry(recertification);
			shaSteps.GivenICloseTheProductRecertificationHistoryPopUp();
			thisGlobalSteps.NavigateToLandingPage();
			sharedSteps.GivenICallSharedStep67823LoginToWERCSmart_ProductsAutomationAccount();
			thisStepsProductGrid.GivenISearchForTheProductSavedAs(savedAs);
			thisStepsProductGrid.GivenForProductSavedAsTestCaseTheStatusIs(savedAs, "Needs Your Attention");
			thisStepsProductGrid.WhenIClickRowActionsForTheFirstProductReturned();
			thisStepsProductGrid.ClickRowAction("Update Required");
			//#And I If you are using a supplier registered for ULSC you will see the ULSC Service Data-Re-Import step, select the No, continue editing data radio button and click Save
			newProductSteps.GivenIShouldSeeXPage("The Product");
			//newProductSteps.GivenInTheNewProductPageIClickTab("Product Characteristics");
			newProductSteps.ClickPageHeading("Product Characteristics");
			newProductSteps.GivenIChangeTheSecondaryPhysicalStateDropDownFromItsCurrentSelectionToANewSelection();
			newProductSteps.ThenIClickSaveOrCancelInTheProductPage("Save");
			newProductSteps.GivenInTheNewProductPageIClickTab("Review and Submit");
			newProductSteps.ClickPageHeading("Data Acceptance");
			newProductSteps.GivenInTheDataAcceptancePageIClickOnTheAcceptButton();
			newProductSteps.GivenIfPurchaseDetailsAreShowingClickConfirmOrder();
			thisStepsHomePage.ThenINavigateToTheHomePage();
			thisStepsProductGrid.GivenISearchForTheProductSavedAs(savedAs);
			sharedSteps.GivenICallShared65080LoginToStudioAndOpenSHAManager();
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(savedAs,
				"Recertification");
			sharedSteps.GivenICallSharedStep51351SHASelectProductViewRecertificationHistoryForProductSavedAs(savedAs);

			var recertification2 = new Table(new string[] {
				"Product ID",
				"Active",
				"Recertification Reason"
			});
			recertification2.AddRow(new string[] {
				"saved as " + savedAs,
				"false",
				"Recertification of Product by WERCSmart Customer"
			});
			shaSteps.GivenInTheProductRecertificationHistoryPopupIShouldSeeTheFollowingEntry(recertification2);
			shaSteps.GivenICloseTheProductRecertificationHistoryPopUp();

		}

		/*
		[StepDefinition(@"I create a product with name: (.*) and take to completed using Test Case 84108 and save as: (.*)")]
		public void GivenITakeProductWithNameFromCompletedToRecertification84108(string name, string savedAs)
		{
			this.TakeProductFromCompletedToRecertification84108(savedAs, name);
		}
		*/
		[StepDefinition(@"I create a product and take to completed using Test Case 84108 and save as: (.*)")]
		public void GivenITakeProductFromCompletedToRecertification84108(string savedAs)
		{
			this.TakeProductFromCompletedToRecertification84108(savedAs, "Alkaline battery");
		}

		[StepDefinition(@"I create a product with name: (.*) and take to completed using Test Case 84109 and save as: (.*)")]
		public void GivenITakeProductFromCompletedToRecertification84109(string name, string savedAs)
		{
			this.TakeProductFromCompletedToRecertification84109(savedAs, name);
		}

		[StepDefinition(@"I create a product and take to completed using Test Case 84109 and save as: (.*)")]
		public void GivenITakeProductFromCompletedToRecertification84109(string savedAs)
		{
			this.TakeProductFromCompletedToRecertification84109(savedAs, "Alkaline battery");
		}

		[StepDefinition(@"I call test stuff for saved as: (.*)")]
		public void GivenICallTestStuff(string savedAs)
		{
			this.Test(savedAs);
		}


		public void Test(string savedAs)
		{
			var thisGlobalSteps = new GlobalSteps();
			var sharedSteps = new Steps_Shared();
			thisGlobalSteps.NavigateToLandingPage();
			// Log in to administrator role
			//sharedSteps.GivenICallSharedStep67823LoginToWERCSmart_ProductsAutomationAccount();
			thisGlobalSteps.LoginToWERCSmartAdmin("WERCs Premium Subscription Account");
			sharedSteps.GivenICallShared65080LoginToStudioAndOpenSHAManager();
			// 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase75335)
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
		}

		public void CreateProductUsingTestCase75335(string savedAs, string name)
		{
			ReportSettings.UseSubSteps = true;
			var sharedSteps = new Steps_Shared();
			var productsGridSteps = new StepsProductGrid();
			var newProductSteps = new StepsNewProduct();
			var newProduct = new NewProduct();
			var shaSteps = new Steps_SHA();
			var thisGlobalSteps = new GlobalSteps();
			thisGlobalSteps.NavigateToLandingPage();
			// Log in to administrator role
			Report.StartStep("Starting Shared Step 67823 Login To WERCSmart_ProductsAutomationAccount");
			sharedSteps.GivenICallSharedStep67823LoginToWERCSmart_ProductsAutomationAccount();
			//thisGlobalSteps.LoginToWERCSmartAdmin("WERCs Premium Subscription Account");
			// Generate UPC number and delete duplicates
			Report.Info("Generating UPC");
			productsGridSteps.GivenIGenerateARandomUPCNumberAndSaveAs("UPC75335");
			Report.Info("Removing all refernces to the UPC generated");
			productsGridSteps.DeleteAllProductsMatchingCriteria("UPC Number", "saved as UPC75335");
			// 57408 (Create a New Registration via Register New Product icon)
			Report.StartStep("Create a New Registration via Register New Product icon");
			sharedSteps.GivenICallSharedStepCreateANewRegistrationViaRegisterNewProductIcon();
			// 57500 (The Product- Enter name, select product type - Continue - Happy Path)
			Report.StartStep("The Product- Enter name, select product type - Continue - Happy Path");
			sharedSteps.GivenICallSharedStepTheProduct_EnterNameSelectProductType_Continue_HappyPath("Chalk", name);
			// Save product to context
			newProductSteps.SaveProductInformation(savedAs);
			// 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
			Report.StartStep("Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path");
			sharedSteps.ICallSharedProductInformationUSOnlyNoChildNoGHSNoDirectShipNoPLPNoGNFR();
			// 26897 (Product Characteristics - Solid only available - continue)
			Report.StartStep("Product Characteristics - Solid only available - continue");
			sharedSteps.SharedPhysicalandChemicalProperties_SolidOnlyAvailable_Continue();
			// 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
			Report.StartStep("(Ingredients - add any chemical) with name: Sodium hydroxide");
			sharedSteps.ICallSharedIngredients_AddAnyChemical("Sodium hydroxide");
			// 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
			Report.StartStep("Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)");
			sharedSteps.ICallSharedRegulatoryInformation1_TSCARandom_Pro65No_Continue();
			// 57510 \(Retailer Association - Select A Retailer - Continue - Happy Path\) and select the retailer: CVS
			Report.StartStep("(Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: CVS");
			sharedSteps.GivenICallSharedRetailerAssociation_SelectARetailer_Continue_HappyPath("CVS");

			Context.AddToContext("retailer", "CVS");
			// 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC75335, container type: Metal Container and size: 40
			Report.StartStep("(Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC75335, container type: Metal Container and size: 40");
			sharedSteps.GivenICallSharedEnterUniversalProductCodeUPC_UPC_ContainerType_SizeOnly("75335",
				"Metal Container", "40");
			// 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
			Report.StartStep("Regulatory Documents to Provide - US only - request authoring - Happy Path");
			sharedSteps.GivenICallSharedRegulatoryDocumentsToProvide_USOnly_RequestAuthoring_HappyPath();
			// Click continue
			newProductSteps.ClickContinue();
			// Click continue
			newProductSteps.ClickContinue();
			// 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
			Report.StartStep("Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path");
			var sdsTable = new Table("Personal Protection Equipment", "Autoignition Temperature",
				"Minimum Ignition Energy", "Viscosity", "Appearance", "Odor", "Odor Threshold",
				"Partition Coefficient");
			sdsTable.AddRow("Mask", "300", "1", "20", "Black", "Odorless", "No data available", "10");
			sharedSteps
				.GivenICallSharedSafetyDataSheetAuthoring_AditionalDataStep_AddAnyRandomDataForAllFields_HappyPath(
					sdsTable);
			// 57883 (Comments - Happy Path) and enter the comment: Test Comment 75335
			Report.StartStep("Comments - Happy Path");
			sharedSteps.GivenICallSharedCommentsHappyPath("Test Comment 75335");
			// 57885 (Data Acceptance - Click Accept - Happy Path)
			Report.StartStep("Data Acceptance - Click Accept - Happy Path");
			sharedSteps.GivenICallSharedDataAcceptance_ClickAccept_HappyPath();
			// If purchase details are showing click confirm order
			Report.StartStep("If purchase details are showing click confirm order");
			newProductSteps.GivenIfPurchaseDetailsAreShowingClickConfirmOrder();
			// 65080 (Login to Studio and Open SHA manager)
			//********************
			//SHA Manager
			//********************
			sharedSteps.GivenICallShared65080LoginToStudioAndOpenSHAManager();
			// 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase75335)
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			Report.StartStep("the SHA manager grid I see the WPS ID I have saved as product: TestCase75335 and its status is: Submitted");
			// In the SHA manager grid I see the WPS ID I have saved as product: TestCase75335 and its status is: Submitted
			shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(savedAs,
				"Submitted");
			// 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase75335)
			sharedSteps.GivenICallSharedSHAManager_Submitted_SelectProductProcessProductData(savedAs);
			// 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase75335)
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			Report.StartStep("the SHA manager grid I see the WPS ID I have saved as product: TestCase75335 and its status is: Assigned");
			// In the SHA manager grid I see the WPS ID I have saved as product: TestCase75335 and its status is: Assigned
			shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(savedAs,
				"Assigned");
			// 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase75335)
			sharedSteps.GivenICallSharedWPSStudio_JobQueue_WaitForImportProcessRulesJobToComplete(savedAs);
			// 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase75335)
			sharedSteps.GivenICallSharedWPSStudio_OpenPDEditExistingWithSpecificProductClickContinue(savedAs);
			Report.StartStep("75347 (WPS) Studio - PD+ - set all data and publish using rule and Doc queue - CKLT, NGHS and SBCS) for product saved as: TestCase75335");
			sharedSteps.GivenICallSharedWPSStudio_PD_SetAllDataAndPublishUsingRuleAndDocQueue_CKLTNGHSAndSBCS(savedAs);
			// 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase75335)
			Report.StartStep("WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved");
			sharedSteps.GivenICallShared55663WPSStudio_GoToJobQueue_WaitForPublishMultipleToComplete(savedAs);
			// 59066(Go to SHA Manager)
			Report.StartStep("Go to SHA Manager");
			sharedSteps.GivenICallSharedStep59066GoToSHAManager();
			// 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase75335)
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			Report.StartStep("the SHA manager grid I see the WPS ID I have saved as product: TestCase75335 and its status is: Accepted");
			shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(savedAs,
				"Accepted");
			Report.StartStep("49841 (SHA - Search for exact WPS ID in Accepted Status for saved as: TestCase75335)");
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("Accepted", savedAs);
			Report.StartStep("(SHA - Search for exact WPS ID in All Status for saved as: TestCase75335)");
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			Report.StartStep("51664 (SHA - Accepted); Product - set Retailers to Completed for saved as: TestCase75335)");
			var table4 = new Table(new string[] {
				"Retailer"
			});
			table4.AddRow(new string[] {
				"CVS"
			});
			sharedSteps.GivenICallShared51664SHA_AcceptedProduct_SetRetailersToCompletedForSavedAs(savedAs, table4);
			Report.StartStep("(SHA - Search for exact WPS ID in All Status for saved as: TestCase75335)");
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			Report.StartStep("In the SHA manager grid I see the WPS ID I have saved as product: TestCase75335 and its status is: Completed");
			shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(savedAs,
				"Completed");
			var ProductDetails = (ProductInformation)Context.GetFromContext(savedAs);
			string ID = ProductDetails.Id;
			var myStudioShaManager = new StudioSHAManager();

			myStudioShaManager.ClickBottomMenuOption("Search");

			var myStepsSha = new Steps_SHA();
			string status = "Completed";
			var table = new Table(new string[] {
				"SearchTerm",
				"SearchValue"
			});
			table.AddRow(new string[] {
				"ProductID",
				ID
			});
			table.AddRow(new string[] {
				"Status",
				status
			});
			myStepsSha.GivenInSHAManagerPageIRunSearch(table);

			Delay.Seconds(2);
			var mySHAManager = new StudioSHAManager();
			mySHAManager.WaitForProductList(10);
			Product topProduct = new StudioSHAManager().GetTopXProducts(1).FirstOrDefault();

			if (topProduct == null || !(topProduct.Status == status && topProduct.ID == ID))
			{
				Report.Failure("Failed to create product and process through to completed.");
			}

		}

		public void CreateProductUsingTestCase75335(string savedAs, string upcSavedAs, string name)
		{
			ReportSettings.UseSubSteps = true;
			var sharedSteps = new Steps_Shared();
			var productsGridSteps = new StepsProductGrid();
			var newProductSteps = new StepsNewProduct();
			var newProduct = new NewProduct();
			var shaSteps = new Steps_SHA();
			var thisGlobalSteps = new GlobalSteps();
			//thisGlobalSteps.LoginToWERCSmartAdmin("WERCs Premium Subscription Account");
			// Generate UPC number and delete duplicates
			Report.Info("Generating UPC");
			productsGridSteps.GivenIGenerateARandomUPCNumberAndSaveAs(upcSavedAs);
			Report.Info("Removing all refernces to the UPC generated");
			productsGridSteps.DeleteAllProductsMatchingCriteria("UPC Number", "saved as " + upcSavedAs);
			// 57408 (Create a New Registration via Register New Product icon)
			Report.Info("Create a New Registration via Register New Product icon");
			sharedSteps.GivenICallSharedStepCreateANewRegistrationViaRegisterNewProductIcon();
			// 57500 (The Product- Enter name, select product type - Continue - Happy Path)
			Report.Info("The Product- Enter name, select product type - Continue - Happy Path");
			sharedSteps.GivenICallSharedStepTheProduct_EnterNameSelectProductType_Continue_HappyPath("Chalk", name);
			// Save product to context
			newProductSteps.SaveProductInformation(savedAs);
			// 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
			Report.Info("Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path");
			sharedSteps.ICallSharedProductInformationUSOnlyNoChildNoGHSNoDirectShipNoPLPNoGNFR();
			// 26897 (Product Characteristics - Solid only available - continue)
			Report.Info("Product Characteristics - Solid only available - continue");
			sharedSteps.SharedPhysicalandChemicalProperties_SolidOnlyAvailable_Continue();
			// 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
			Report.Info("(Ingredients - add any chemical) with name: Sodium hydroxide");
			sharedSteps.ICallSharedIngredients_AddAnyChemical("Sodium hydroxide");
			// 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
			Report.Info("Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)");
			sharedSteps.ICallSharedRegulatoryInformation1_TSCARandom_Pro65No_Continue();
			// 57510 \(Retailer Association - Select A Retailer - Continue - Happy Path\) and select the retailer: CVS
			Report.Info("(Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: CVS");
			sharedSteps.GivenICallSharedRetailerAssociation_SelectARetailer_Continue_HappyPath("CVS");

			Context.AddToContext("retailer", "CVS");
			// 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as upcSavedAs, container type: Metal Container and size: 40
			Report.Info("(Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as " + upcSavedAs + ", container type: Metal Container and size: 40");
			string upcNumberSavedAs = "";
			if (upcSavedAs.Contains("UPC"))
			{
				char[] trimChars = new char[] { 'U', 'P', 'C' };
				upcNumberSavedAs = upcSavedAs.TrimStart(trimChars);
			}
			sharedSteps.GivenICallSharedEnterUniversalProductCodeUPC_UPC_ContainerType_SizeOnly(upcNumberSavedAs,
				"Metal Container", "40");
			// 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
			Report.Info("Regulatory Documents to Provide - US only - request authoring - Happy Path");
			sharedSteps.GivenICallSharedRegulatoryDocumentsToProvide_USOnly_RequestAuthoring_HappyPath();
			// Click continue
			newProductSteps.ClickContinue();
			// Click continue
			newProductSteps.ClickContinue();
			// 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
			Report.Info("Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path");
			var sdsTable = new Table("Personal Protection Equipment", "Autoignition Temperature",
				"Minimum Ignition Energy", "Viscosity", "Appearance", "Odor", "Odor Threshold",
				"Partition Coefficient");
			sdsTable.AddRow("Mask", "300", "1", "20", "Black", "Odorless", "No data available", "10");
			sharedSteps
				.GivenICallSharedSafetyDataSheetAuthoring_AditionalDataStep_AddAnyRandomDataForAllFields_HappyPath(
					sdsTable);
			// 57883 (Comments - Happy Path) and enter the comment: Test Comment 75335
			Report.Info("Comments - Happy Path");
			sharedSteps.GivenICallSharedCommentsHappyPath("Test Comment 75335");
			// 57885 (Data Acceptance - Click Accept - Happy Path)
			Report.Info("Data Acceptance - Click Accept - Happy Path");
			sharedSteps.GivenICallSharedDataAcceptance_ClickAccept_HappyPath();
			// If purchase details are showing click confirm order
			Report.Info("If purchase details are showing click confirm order");
			newProductSteps.GivenIfPurchaseDetailsAreShowingClickConfirmOrder();
			// 65080 (Login to Studio and Open SHA manager)
			//********************
			//SHA Manager
			//********************
			sharedSteps.GivenICallShared65080LoginToStudioAndOpenSHAManager();
			// 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase75335)
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			Report.Info(
				"the SHA manager grid I see the WPS ID I have saved as product: TestCase75335 and its status is: Submitted");
			// In the SHA manager grid I see the WPS ID I have saved as product: TestCase75335 and its status is: Submitted
			shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(savedAs,
				"Submitted");
			// 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase75335)
			sharedSteps.GivenICallSharedSHAManager_Submitted_SelectProductProcessProductData(savedAs);
			// 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase75335)
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			Report.Info(
				"the SHA manager grid I see the WPS ID I have saved as product: TestCase75335 and its status is: Assigned");
			// In the SHA manager grid I see the WPS ID I have saved as product: TestCase75335 and its status is: Assigned
			shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(savedAs,
				"Assigned");
			// 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase75335)
			sharedSteps.GivenICallSharedWPSStudio_JobQueue_WaitForImportProcessRulesJobToComplete(savedAs);
			// 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase75335)
			sharedSteps.GivenICallSharedWPSStudio_OpenPDEditExistingWithSpecificProductClickContinue(savedAs);
			Report.Info(
				"75347 (WPS) Studio - PD+ - set all data and publish using rule and Doc queue - CKLT, NGHS and SBCS) for product saved as: TestCase75335");
			sharedSteps.GivenICallSharedWPSStudio_PD_SetAllDataAndPublishUsingRuleAndDocQueue_CKLTNGHSAndSBCS(savedAs);
			// 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase75335)
			Report.Info("WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved");
			sharedSteps.GivenICallShared55663WPSStudio_GoToJobQueue_WaitForPublishMultipleToComplete(savedAs);
			// 59066(Go to SHA Manager)
			Report.Info("Go to SHA Manager");
			sharedSteps.GivenICallSharedStep59066GoToSHAManager();
			// 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase75335)
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			Report.Info(
				"the SHA manager grid I see the WPS ID I have saved as product: TestCase75335 and its status is: Accepted");
			shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(savedAs,
				"Accepted");
			Report.Info("49841 (SHA - Search for exact WPS ID in Accepted Status for saved as: TestCase75335)");
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("Accepted", savedAs);
			Report.Info("(SHA - Search for exact WPS ID in All Status for saved as: TestCase75335)");
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			Report.Info("51664 (SHA - Accepted); Product - set Retailers to Completed for saved as: TestCase75335)");
			var table4 = new Table(new string[] {
				"Retailer"
			});
			table4.AddRow(new string[] {
				"CVS"
			});
			sharedSteps.GivenICallShared51664SHA_AcceptedProduct_SetRetailersToCompletedForSavedAs(savedAs, table4);
			Report.Info("(SHA - Search for exact WPS ID in All Status for saved as: TestCase75335)");
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			Report.Info(
				"In the SHA manager grid I see the WPS ID I have saved as product: TestCase75335 and its status is: Completed");
			shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(savedAs,
				"Completed");
			var ProductDetails = (ProductInformation)Context.GetFromContext(savedAs);
			string ID = ProductDetails.Id;
			var myStudioShaManager = new StudioSHAManager();

			myStudioShaManager.ClickBottomMenuOption("Search");

			var myStepsSha = new Steps_SHA();
			string status = "Completed";
			var table = new Table(new string[] {
				"SearchTerm",
				"SearchValue"
			});
			table.AddRow(new string[] {
				"ProductID",
				ID
			});
			table.AddRow(new string[] {
				"Status",
				status
			});
			myStepsSha.GivenInSHAManagerPageIRunSearch(table);

			Delay.Seconds(2);
			var mySHAManager = new StudioSHAManager();
			mySHAManager.WaitForProductList(10);
			Product topProduct = new StudioSHAManager().GetTopXProducts(1).FirstOrDefault();

			if (topProduct == null || !(topProduct.Status == status && topProduct.ID == ID))
			{
				Report.Failure("Failed to create product and process through to completed.");
			}
		}

		[StepDefinition(@"I create a product with name: (.*) using Test Case 87686 which has a Case pack UPC for 1 or more retailers and which is in Completed status and save as: (.*)")]
		public void GivenICreateAProductUsingTestCaseWhichHasACasePackUPCForOrMoreRetailersAndWhichIsInCompletedStatus_(string name, string savedAs)
		{
			if (Context.Contains("Chalk"))
			{
				Context.AddToContext("Chalk", "false");
			}
			ReportSettings.UseSubSteps = true;
			var sharedSteps = new Steps_Shared();
			var productsGridSteps = new StepsProductGrid();
			var newProductSteps = new StepsNewProduct();
			var newProduct = new NewProduct();
			var shaSteps = new Steps_SHA();
			var thisGlobalSteps = new GlobalSteps();
			var stepsSharedUPC = new StepsUPC();
			var stepsStudio = new Steps_Studio();

			thisGlobalSteps.NavigateToLandingPage();
			// Log in to administrator role
			//sharedSteps.GivenICallSharedStep67823LoginToWERCSmart_ProductsAutomationAccount();
			thisGlobalSteps.LoginToWERCSmartAdmin("WERCs Premium Subscription Account");
			productsGridSteps.GivenIGenerateARandomUPCNumberAndSaveAs("UPC87686");
			sharedSteps.GivenICallSharedStepCreateANewRegistrationViaRegisterNewProductIcon();
			sharedSteps.GivenICallSharedStepTheProduct_EnterNameSelectProductType_Continue_HappyPath(name);
			newProductSteps.SaveProductInformation(savedAs);
			sharedSteps.SharedPhysicalandChemicalProperties_SolidOnlyAvailable_Continue();
			sharedSteps.ICallSharedProductInformationUSOnlyNoChildNoGHSNoDirectShipNoPLPNoGNFR();
			sharedSteps.ICallSharedIngredients_AddAnyChemical("Sodium Hydroxide");
			sharedSteps.ICallSharedRegulatoryInformation1_TSCARandom_Pro65No_Continue();
			var retailerTable = new Table(new string[] {
				"Retailer"});
			retailerTable.AddRow(new string[] {
				"Amazon"});
			sharedSteps
				.GivenICallSharedStep75146Retailer_SelectOneOrMoreRetailersThatDoNotRequireVendorIDOrAdditionalUPCInformationClickDoneClickContinue(
					retailerTable);
			stepsSharedUPC.UPCCaseAddInformation("87686", "Paper bag", "2", "4", "UPC87685", "4A: steel box");
			sharedSteps.GivenICallSharedRegulatoryDocumentsToProvide_USOnly_RequestAuthoring_HappyPath();
			//Given in the Additional Documents to Provide page I click Continue
			newProductSteps.ClickContinue();
			//Given in the Optional Reports and Dcouments Available For Purchase page I click Continue
			newProductSteps.ClickContinue();
			// 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
			var sdsTable = new Table("Personal Protection Equipment", "Autoignition Temperature",
				"Minimum Ignition Energy", "Viscosity", "Appearance", "Odor", "Odor Threshold",
				"Partition Coefficient");
			sdsTable.AddRow("Mask", "300", "1.005", "20", "Black", "Odorless", "No data available", "10");
			sharedSteps
				.GivenICallSharedSafetyDataSheetAuthoring_AditionalDataStep_AddAnyRandomDataForAllFields_HappyPath(
					sdsTable);
			//	And I call Shared Step 57883(Comments - Happy Path) and enter the comment: test
			sharedSteps.GivenICallSharedCommentsHappyPath("test");
			// 57885 (Data Acceptance - Click Accept - Happy Path)
			sharedSteps.GivenICallSharedDataAcceptance_ClickAccept_HappyPath();
			// If purchase details are showing click confirm order
			newProductSteps.GivenIfPurchaseDetailsAreShowingClickConfirmOrder();
			// 65080 (Login to Studio and Open SHA manager)
			sharedSteps.GivenICallShared65080LoginToStudioAndOpenSHAManager();
			// 49841 (SHA - Search for exact WPS ID in All Status for saved as: X )
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			// In the SHA manager grid I see the WPS ID I have saved as product: X and its status is: Submitted
			shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(savedAs,
				"Submitted");
			// 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase87686)
			sharedSteps.GivenICallSharedSHAManager_Submitted_SelectProductProcessProductData(savedAs);
			// 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase87686)
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			// In the SHA manager grid I see the WPS ID I have saved as product: TestCase87686 and its status is: Assigned
			shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(savedAs,
				"Assigned");
			// 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase87686)
			sharedSteps.GivenICallSharedWPSStudio_JobQueue_WaitForImportProcessRulesJobToComplete(savedAs);

			//# Note: In Staging and Production - Electronic products are automatically published by the ImportProcessRules so if you are running in either of these sites you can skip to step 28
			//And I check whether the current environment is Staging or Production and if it is I skip the next three steps
			stepsStudio.GivenICheckWhetherTheCurrentEnvironmentIsStagingOrProductionAndIfItIsISkipTheNextThreeSteps();
			// 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: X)
			sharedSteps.GivenICallSharedWPSStudio_OpenPDEditExistingWithSpecificProductClickContinue(savedAs);
			//And I call Shared Step 79500(WPS Studio - PD + -set all data and publish using rule and doc queue -CKLT and SBCS only) for product saved as: TestCase87686
			sharedSteps.GivenICallSharedStep79500WPSStudio_PD_SetAllDataAndPublishUsingRuleAndDocQueue_CKLTAndSBCSOnly(
				savedAs);

			// 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase87686)
			sharedSteps.GivenICallShared55663WPSStudio_GoToJobQueue_WaitForPublishMultipleToComplete(savedAs);
			// 59066(Go to SHA Manager)
			sharedSteps.GivenICallSharedStep59066GoToSHAManager();
			// 49841 (SHA - Search for exact WPS ID in All Status for saved as: X)
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			Report.Info(
				"the SHA manager grid I see the WPS ID I have saved as product: X and its status is: Completed");
			shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(savedAs,
				"Accepted or Completed");
		}

		[StepDefinition(@"I create a product with name: (.*) and take to completed using Test Case 84108 and save as: (.*)")]
		public void TakeProductFromCompletedToRecertification84108(string name, string savedAs)
		{
			if (Context.Contains("ElectronicProduct"))
			{
				Context.AddToContext("ElectronicProduct", "false");
			}

			ReportSettings.UseSubSteps = true;
			var sharedSteps = new Steps_Shared();
			var productsGridSteps = new StepsProductGrid();
			var newProductSteps = new StepsNewProduct();
			var newProduct = new NewProduct();
			var shaSteps = new Steps_SHA();
			var thisGlobalSteps = new GlobalSteps();
			thisGlobalSteps.NavigateToLandingPage();
			// Log in to administrator role
			//sharedSteps.GivenICallSharedStep67823LoginToWERCSmart_ProductsAutomationAccount();
			//thisGlobalSteps.LoginToWERCSmartAdmin("WERCs Premium Subscription Account");
			Report.StartStep("Starting Shared Step 67823 Login To WERCSmart_ProductsAutomationAccount");
			sharedSteps.GivenICallSharedStep67823LoginToWERCSmart_ProductsAutomationAccount();
			// Generate UPC number and delete duplicates
			productsGridSteps.GivenIGenerateARandomUPCNumberAndSaveAs("UPC84108");
			productsGridSteps.DeleteAllProductsMatchingCriteria("UPC Number", "saved as UPC84108");
			//And I call Shared Step 57753 (Create a New Registration via Register New Product(expanded menu))
			sharedSteps.GivenICallSharedCreateANewRegistrationViaRegisterNewProductExpandedMenu();
			//And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Alkaline battery
			sharedSteps.GivenICallSharedStepTheProduct_EnterNameSelectProductType_Continue_HappyPath("Alkaline battery",
				name);
			// Save product to context
			newProductSteps.SaveProductInformation(savedAs);

			//And I call Shared Step 57401 (Product Information - No GHS, Not Direct Ship, Not PLP, Not GNFR > Continue - Happy Path)
			sharedSteps.GivenICallSharedProductInformation_NoGHSNotDirectShipNotPLPNotGNFR_Continue();
			//And I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
			sharedSteps.SharedPhysicalandChemicalProperties_SolidOnlyAvailable_Continue();
			
			// 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
			sharedSteps.ICallSharedIngredients_AddAnyChemical("Sodium hydroxide");
			// 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
			//sharedSteps.ICallSharedRegulatoryInformation1_TSCARandom_Pro65No_Continue();
			sharedSteps.ICallSharedRegulatoryInformation1_TSCAAndCEPAShown_NoToProp65();
			//And I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
			sharedSteps.ICallSharedRetailer_SelectNoRetailer_ClickDone();
			//Given I set the  field to: I do not have an OSHA-compliant SDS for this battery but do have a Technical Data Sheet(TDS) or Battery Data Sheet(BDS) and would like to upload it
			//newProductSteps.SetTheSectionOptionTo("OSHA-compliant Safety Data Sheet, English",
				//"I do not have an OSHA-compliant SDS for this battery but do have a Technical Data Sheet (TDS) or Battery Data Sheet (BDS) and would like to upload it");
			//And I call Shared Step 59042 (Browse for File > select > click Open - Happy Path) for document type: Technical Data Sheet(TDS) or Battery Data Sheet(BDS) and file: C:\Dependencies\WERCSmart\testdoc.pdf
			sharedSteps.ICallSharedBrowseForFileSelectClickOpen(
				"Technical Data Sheet (TDS), Battery Data Sheet (BDS)", @"C:\Dependencies\WERCSmart\testdoc.pdf");
			newProductSteps.SetRadioOptionInSectionTo("Batteries are considered Articles under Global Harmonized Standards",
				"I don't need an OSHA-Compliant Safety Data Sheet (SDS) document for this product.");
			newProductSteps.SetRadioOptionInSectionTo("WHMIS-compliant Safety Data Sheet, English and French-Canadian",
				"I don't need a WHMIS Compliant SDS");
			//Given in the Regulatory Documents to Provide page I click Continue
			newProductSteps.ClickContinue();
			//Given in the Additional Documents to Provide page I click Continue
			newProductSteps.ClickContinue();
			//Given in the Optional Reports and Dcouments Available For Purchase page I click Continue
			newProductSteps.ClickContinue();
			//Given in the Comments page I click Continue
			newProductSteps.ClickContinue();
			// 57885 (Data Acceptance - Click Accept - Happy Path)
			sharedSteps.GivenICallSharedDataAcceptance_ClickAccept_HappyPath();
			// If purchase details are showing click confirm order
			newProductSteps.GivenIfPurchaseDetailsAreShowingClickConfirmOrder();
			// 65080 (Login to Studio and Open SHA manager)
			sharedSteps.GivenICallShared65080LoginToStudioAndOpenSHAManager();
			// 49841 (SHA - Search for exact WPS ID in All Status for saved as: X )
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			// In the SHA manager grid I see the WPS ID I have saved as product: X and its status is: Submitted
			shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(savedAs,
				"Submitted");
			// 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase75335)
			sharedSteps.GivenICallSharedSHAManager_Submitted_SelectProductProcessProductData(savedAs);
			// 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase75335)
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			// In the SHA manager grid I see the WPS ID I have saved as product: TestCase75335 and its status is: Assigned
			shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(savedAs,
				"Assigned");
			// 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase75335)
			sharedSteps.GivenICallSharedWPSStudio_JobQueue_WaitForImportProcessRulesJobToComplete(savedAs);
			// 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase75335)
			sharedSteps.GivenICallSharedWPSStudio_OpenPDEditExistingWithSpecificProductClickContinue(savedAs);
			//And I call Shared Step 79500(WPS Studio - PD + -set all data and publish using rule and doc queue -CKLT and SBCS only) for product saved as: TestCase84108
			sharedSteps.GivenICallSharedStep79500WPSStudio_PD_SetAllDataAndPublishUsingRuleAndDocQueue_CKLTAndSBCSOnly(
				savedAs);
			// 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase75335)
			sharedSteps.GivenICallShared55663WPSStudio_GoToJobQueue_WaitForPublishMultipleToComplete(savedAs);
			// 59066(Go to SHA Manager)
			sharedSteps.GivenICallSharedStep59066GoToSHAManager();
			// 49841 (SHA - Search for exact WPS ID in All Status for saved as: X)
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			Report.Info(
				"the SHA manager grid I see the WPS ID I have saved as product: X and its status is: Completed");
			shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(savedAs,
				"Completed");

		}


		[StepDefinition(@"I create a product and take to completed using Test Case 84109 and save as: (.*)")]
		public void TakeProductFromCompletedToRecertification84109(string savedAs,
			string name = "Answering machine, No battery included")
		{
			ReportSettings.UseSubSteps = true;
			var sharedSteps = new Steps_Shared();
			var productsGridSteps = new StepsProductGrid();
			var newProductSteps = new StepsNewProduct();
			var newProduct = new NewProduct();
			var shaSteps = new Steps_SHA();
			var stepsStudio = new Steps_Studio();
			var thisGlobalSteps = new GlobalSteps();

			thisGlobalSteps.NavigateToLandingPage();
			// Log in to administrator role
			sharedSteps.GivenICallSharedStep67823LoginToWERCSmart_ProductsAutomationAccount();
			//And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
			sharedSteps.GivenICallSharedStepCreateANewRegistrationViaRegisterNewProductIcon();
			//And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Answering machine, No battery included
			sharedSteps.GivenICallSharedStepTheProduct_EnterNameSelectProductType_Continue_HappyPath(
				"Answering machine, No battery included", name);
			// Save product to context
			newProductSteps.SaveProductInformation(savedAs);
			//And I call Shared Step 69687(Product Information - US, No(PL))
			//sharedSteps.GivenICallSharedStepProductInformation_CountryAndPrivateLabelOrBrand_No();
			//And I call Shared Step 60935 Product Information - US - Direct Ship - Private Label Only
			sharedSteps.GivenICallSharedStep60935ProductInformation_US_DirectShip_PrivateLabelOnly();
			//And I call Shared Step 57503(Regulatory Information 1 - TSCA(Random) - Prop 65(No) - Continue - Happy Path)
			sharedSteps.ICallSharedRegulatoryInformation1_TSCARandom_Pro65No_Continue();
			//And I call Shared Step 48369(Toxicity Characteristics Leaching Procedure(TCLP) - No to ALL With Copper)
			sharedSteps.GivenICallSharedStepToxicityCharacteristicsLeachingProcedureTCLP_NoToALLWithCopper();
			//And I call Shared Step 71955(Answer Electronic Equipment questions - Without Cathode Ray - No to all)
			sharedSteps.GivenICallSharedStepAnswerElectronicEquipmentQuestions_WithoutCathodeRay_NoToAll();
			//And I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
			sharedSteps.ICallSharedRetailer_SelectNoRetailer_ClickDone();

			//And I should see the Additional Documents to Provide Page
			newProductSteps.GivenIShouldSeeXPage("Additional Documents to Provide");
			//Given in the Additional Documents to Provide page I click Continue
			newProductSteps.ClickContinue();
			//Given in the Optional Reports and Documents Available for Purchase page I click Continue
			newProductSteps.ClickContinue();
			//	And I call Shared Step 57883(Comments - Happy Path) and enter the comment: test
			sharedSteps.GivenICallSharedCommentsHappyPath("test");
			// 57885 (Data Acceptance - Click Accept - Happy Path)
			sharedSteps.GivenICallSharedDataAcceptance_ClickAccept_HappyPath();
			// If purchase details are showing click confirm order
			newProductSteps.GivenIfPurchaseDetailsAreShowingClickConfirmOrder();
			// 65080 (Login to Studio and Open SHA manager)
			sharedSteps.GivenICallShared65080LoginToStudioAndOpenSHAManager();
			// 49841 (SHA - Search for exact WPS ID in All Status for saved as: X )
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			// In the SHA manager grid I see the WPS ID I have saved as product: X and its status is: Submitted
			shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(savedAs,
				"Submitted");
			// 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase75335)
			sharedSteps.GivenICallSharedSHAManager_Submitted_SelectProductProcessProductData(savedAs);
			// 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase75335)
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			// In the SHA manager grid I see the WPS ID I have saved as product: TestCase75335 and its status is: Assigned
			shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(savedAs,
				"Assigned");
			// 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase75335)
			sharedSteps.GivenICallSharedWPSStudio_JobQueue_WaitForImportProcessRulesJobToComplete(savedAs);

			//# Note: In Staging and Production - Electronic products are automatically published by the ImportProcessRules so if you are running in either of these sites you can skip to step 28
			//And I check whether the current environment is Staging or Production and if it is I skip the next three steps
			stepsStudio.GivenICheckWhetherTheCurrentEnvironmentIsStagingOrProductionAndIfItIsISkipTheNextThreeSteps();
			// 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: X)
			sharedSteps.GivenICallSharedWPSStudio_OpenPDEditExistingWithSpecificProductClickContinue(savedAs);
			//And I call Shared Step 79500(WPS Studio - PD + -set all data and publish using rule and doc queue -CKLT and SBCS only) for product saved as: TestCase84108
			sharedSteps.GivenICallSharedStep79500WPSStudio_PD_SetAllDataAndPublishUsingRuleAndDocQueue_CKLTAndSBCSOnly(
				savedAs);
			// 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase75335)
			sharedSteps.GivenICallShared55663WPSStudio_GoToJobQueue_WaitForPublishMultipleToComplete(savedAs);
			// 59066(Go to SHA Manager)
			sharedSteps.GivenICallSharedStep59066GoToSHAManager();
			// 49841 (SHA - Search for exact WPS ID in All Status for saved as: X)
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			Report.Info(
				"the SHA manager grid I see the WPS ID I have saved as product: X and its status is: Completed");
			shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(savedAs,
				"Completed");

		}

		[StepDefinition(@"I take a product from completed to recertification using Test Case 84511 saved: (.*)")]
		public void GivenITakeAProductFromCompletedToRecertificationUsingTestCaseSavedTestCase(string savedAs)
		{
			ReportSettings.UseSubSteps = true;
			var sharedSteps = new Steps_Shared();
			var newProductSteps = new StepsNewProduct();
			var shaSteps = new Steps_SHA();
			var thisGlobalSteps = new GlobalSteps();
			var thisStepsProductGrid = new StepsProductGrid();
			var thisStepsHomePage = new StepsHomepage();

			//Given I navigate to the landing page
			thisGlobalSteps.NavigateToLandingPage();
			//Given I login into the WERCSmart Portal - Administrator Role
			sharedSteps.GivenICallSharedStep67823LoginToWERCSmart_ProductsAutomationAccount();
			//Given I search for the product saved as: TestCase84511
			thisStepsProductGrid.GivenISearchForTheProductSavedAs(savedAs);
			//Given For product saved as: TestCase84511 the status is: Completed
			thisStepsProductGrid.GivenForProductSavedAsTestCaseTheStatusIs(savedAs, "Completed");
			//And I click Row Actions for the first product returned
			thisStepsProductGrid.WhenIClickRowActionsForTheFirstProductReturned();
			//And I click on the Row Action: Update Data
			thisStepsProductGrid.ClickRowAction("Update Data");
			thisStepsProductGrid.IShouldSeeTheUpdateRegistrationPopup();
			thisStepsProductGrid.InUpdateRegistrationPopupIClickButton("Yes");
			//#And If you are using a supplier registered for ULSC you will see the ULSC Service Data-Re-Import step, select the No, continue editing data radio button and click Save
			//And I should see the The Product Page
			newProductSteps.GivenIShouldSeeXPage("The Product");
			//Then I click Save in The Product Page
			newProductSteps.ThenIClickSaveOrCancelInTheProductPage("Save");
			//Given I call Shared Step 65080(Login to Studio and Open SHA manager)
			sharedSteps.GivenICallShared65080LoginToStudioAndOpenSHAManager();
			//Given I call Shared Step 49841(SHA - Search for exact WPS ID in All Status for saved as: TestCase84511)
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			//Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase84511 and its status is: Completed
			shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(savedAs,
				"Completed");
			//Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase84511 and its font is red indicating a recertification
			shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsAndItsFontIsRedOrNotRedIndicatingARecertification(
				"red", savedAs);
			//And I call Shared Step 51351(SHA > Select Product > View Recertification History) for product saved as: TestCase84511
			sharedSteps.GivenICallSharedStep51351SHASelectProductViewRecertificationHistoryForProductSavedAs(savedAs);
			//And In the Product Recertification History popup I should see the following entry
			//| Product ID | Active | Recertification Reason |
			//| saved as TestCase84511 | true | Recertification of Product by WERCSmart Customer |
			var recertification = new Table(new string[] {
				"Product ID",
				"Active",
				"Recertification Reason"
			});
			recertification.AddRow(new string[] {
				"saved as " + savedAs,
				"true",
				"Recertification of Product by WERCSmart Customer"
			});
			shaSteps.GivenInTheProductRecertificationHistoryPopupIShouldSeeTheFollowingEntry(recertification);
			//And I Close the Product Recertification History pop up
			shaSteps.GivenICloseTheProductRecertificationHistoryPopUp();

			//Given I navigate to the landing page
			thisGlobalSteps.NavigateToLandingPage();
			//Given I login into the WERCSmart Portal - Administrator Role
			sharedSteps.GivenICallSharedStep67823LoginToWERCSmart_ProductsAutomationAccount();
			//Given I search for the product saved as: TestCase84511
			thisStepsProductGrid.GivenISearchForTheProductSavedAs(savedAs);
			//Given For product saved as: TestCase84511 the status is: Needs Your Attention
			thisStepsProductGrid.GivenForProductSavedAsTestCaseTheStatusIs(savedAs, "Needs Your Attention");
			//And I click Row Actions for the first product returned
			thisStepsProductGrid.WhenIClickRowActionsForTheFirstProductReturned();
			//And I click on the Row Action: Update Required
			thisStepsProductGrid.ClickRowAction("Update Required");
			//#And if you are using a supplier registered for ULSC you will see the ULSC Service Data-Re-Import step, select the No, continue editing data radio button and click Save
			//And I should see the The Product Page
			newProductSteps.GivenIShouldSeeXPage("The Product");
			//And In the New Product page I click tab: Physical and Chemical Properties
			newProductSteps.GivenInTheNewProductPageIClickTab("Product Characteristics");
			//And in the New Product page I click section: Toxicity Characteristic Leaching Procedure(TCLP)
			newProductSteps.ClickPageHeading("Toxicity Characteristic Leaching Procedure (TCLP)");
			//And I set the Lead option to: Yes
			newProductSteps.SetTheSectionOptionTo("Lead", "Yes");
			//And I set the Mercury option to: Yes
			newProductSteps.SetTheSectionOptionTo("Mercury", "Yes");
			//And I set the Silver option to: Yes
			newProductSteps.SetTheSectionOptionTo("Silver", "Yes");
			//Then I click Save in The Product Page
			newProductSteps.ThenIClickSaveOrCancelInTheProductPage("Save");
			//And In the New Product page I click tab: Review and Submit
			newProductSteps.GivenInTheNewProductPageIClickTab("Review and Submit");
			//And in the New Product page I click section: Data Acceptance
			newProductSteps.ClickPageHeading("Data Acceptance");
			//And In the Data Acceptance page I click on the Accept button
			newProductSteps.GivenInTheDataAcceptancePageIClickOnTheAcceptButton();
			//Given If purchase details are showing click confirm order
			newProductSteps.GivenIfPurchaseDetailsAreShowingClickConfirmOrder();
			//And I navigate to the home page
			thisStepsHomePage.ThenINavigateToTheHomePage();
			//And I search for the product saved as: TestCase84511
			thisStepsProductGrid.GivenISearchForTheProductSavedAs(savedAs);
			//Given For product saved as: TestCase84511 the status is: Assessment in Progress
			thisStepsProductGrid.GivenForProductSavedAsTestCaseTheStatusIs(savedAs, "Assessment in Progress");
			//Given I call Shared Step 65080(Login to Studio and Open SHA manager)
			sharedSteps.GivenICallShared65080LoginToStudioAndOpenSHAManager();
			//Given I call Shared Step 49841(SHA - Search for exact WPS ID in All Status for saved as: TestCase84511)
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			//Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase84511 and its status is: Recertification
			shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(savedAs,
				"Recertification");
			//# And I Confirm your product is shown in the Recertification status without the red recertification font color
			//And I call Shared Step 51351(SHA > Select Product > View Recertification History) for product saved as: TestCase84511
			sharedSteps.GivenICallSharedStep51351SHASelectProductViewRecertificationHistoryForProductSavedAs(savedAs);
			//And In the Product Recertification History popup I should see the following entry
			//| Product ID | Active | Recertification Reason |
			//| saved as TestCase84511 | false | Recertification of Product by WERCSmart Customer |
			var recertification2 = new Table(new string[] {
				"Product ID",
				"Active",
				"Recertification Reason"
			});
			recertification2.AddRow(new string[] {
				"saved as " + savedAs,
				"false",
				"Recertification of Product by WERCSmart Customer"
			});
			shaSteps.GivenInTheProductRecertificationHistoryPopupIShouldSeeTheFollowingEntry(recertification2);
			//And I Close the Product Recertification History pop up
			shaSteps.GivenICloseTheProductRecertificationHistoryPopUp();
		}

		[StepDefinition(@"I create a product with name: (.*) and take to completed using Test Case 80821 and save as: (.*)")]
		public void GivenICreateAProductWithNameAndTakeToCompletedUsingTestCaseAndSaveAsTestCase(string productName,
			string savedAs)
		{
			ReportSettings.UseSubSteps = true;
			var sharedSteps = new Steps_Shared();
			var newProductSteps = new StepsNewProduct();
			var stepsNewProductIngredients = new StepsIngredients();
			var shaSteps = new Steps_SHA();
			var thisGlobalSteps = new GlobalSteps();
			var thisStepsProductGrid = new StepsProductGrid();
			var thisStepsHomePage = new StepsHomepage();
			var studioSteps = new Steps_Studio();
			//Scenario: [80821] Create a 3rd party product - with Tier 2 approval Specific components for Transparency ratio testing
			//Given I generate a random UPC number and save as: UPC80821
			new StepsProductGrid().GivenIGenerateARandomUPCNumberAndSaveAs("UPC" + savedAs);
			//And I call Shared Step 67823(Login to WERCSmart - Products Automation Account)
			//Given I navigate to the landing page
			thisGlobalSteps.NavigateToLandingPage();
			//Given I login into the WERCSmart Portal - Administrator Role
			sharedSteps.GivenICallSharedStep67823LoginToWERCSmart_ProductsAutomationAccount();
			//And I call Shared Step 57753 (Create a New Registration via Register New Product(expanded menu))
			sharedSteps.GivenICallSharedCreateANewRegistrationViaRegisterNewProductExpandedMenu();
			//And I call Shared Step 57561(The Product - Enter Product Name and select Type of Product): Raw Material
			sharedSteps.GivenICallSharedStepTheProduct_EnterProductNameAndSelectTypeOfProduct("Raw Material");
			//Then I save the product information as: TestCase80821
			newProductSteps.SaveProductInformation(savedAs);
			//And I call Shared Step 80822 - Ingredients - Add non - generic - specific component - set publicly disclosed and add public name and save ingredient as: Ing808211
			var table34 = new Table(new string[] {
				"CASNumber",
				"ComponentName",
				"Percentage",
				"Publicly Disclosed",
				"Public Name"
			});
			table34.AddRow(new string[] {
				"100-41-4",
				"Ethylbenzene",
				"25",
				"Yes",
				"Undisclosed Ingredient"
			});
			sharedSteps
				.ThenICallSharedStep_Ingredients_AddNon_Generic_SpecificComponent_SetPubliclyDisclosedAndAddPublicName(
					"Ing" + savedAs + "1", table34);

			//And In the Ingredients page I confirm the Publicly Disclosed Transparency Score has numerator: 1 and denominator: 1
			// stepsNewProductIngredients.IngredientsPageIConfirmThePublicallyDisclosedTotalDenominatorIsShowing("1", "1");
			stepsNewProductIngredients.ThenIVerifyTheTransparencyScoreDisplays((float)100.00);
			//And In the Ingredients page I confirm the Publicly Disclosed Transparency score is flagged as a success
			stepsNewProductIngredients
				.IngredientsPageIConfirmThePubliclyDisclosedTransparencyScoreIsFlaggedRed("success");
			//And I call Shared Step 80822 - Ingredients - Add non-generic - specific component - set publicly disclosed and add public name and save ingredient as: Ing808212
			//| CASNumber  | ComponentName | Percentage | Publicly Disclosed | Public Name            |
			//| 37334-84-2 | Cellolyn 21   | 15         | No                 | Undisclosed Ingredient |
			var table35 = new Table(new string[] {
				"CASNumber",
				"ComponentName",
				"Percentage",
				"Publicly Disclosed",
				"Public Name"
			});
			table35.AddRow(new string[] {
				"37334-84-2",
				"Cellolyn 21",
				"15",
				"No",
				"Undisclosed Ingredient"
			});
			sharedSteps
				.ThenICallSharedStep_Ingredients_AddNon_Generic_SpecificComponent_SetPubliclyDisclosedAndAddPublicName(
					"Ing" + savedAs + "2", table35);
			//And In the Ingredients page I confirm the Publicly Disclosed Transparency Score has numerator: 1 and denominator: 2
			//stepsNewProductIngredients.IngredientsPageIConfirmThePublicallyDisclosedTotalDenominatorIsShowing("1", "2");
			stepsNewProductIngredients.ThenIVerifyTheTransparencyScoreDisplays((float)50.00);
			//And In the Ingredients page I confirm the Publicly Disclosed Transparency score is flagged as a warning
			stepsNewProductIngredients
				.IngredientsPageIConfirmThePubliclyDisclosedTransparencyScoreIsFlaggedRed("warning");
			//And I call Shared Step 79436 (Ingredients - Add FRAGRANCE component, Publicly Disclosed = Yes, Select Public Name) and save ingredient as: Ing808213
			//| CASNumber  | ComponentName    | Percentage |
			//| RR-38384-6 | FRAGRANCE-HERBAL | 10         |
			var table36 = new Table(new string[] {
				"CASNumber",
				"ComponentName",
				"Percentage"
			});
			table36.AddRow(new string[] {
				"RR-38384-6",
				"FRAGRANCE-HERBAL",
				"10"
			});
			sharedSteps.CallSharedIngredients_AddFragranceComponent_PubliclyDisclosedYes_SelectPublicName(
				"Ing" + savedAs + "5", table36);
			//And In the Ingredients page I confirm the Publicly Disclosed Transparency Score has numerator: 1 and denominator: 3
			//stepsNewProductIngredients.IngredientsPageIConfirmThePublicallyDisclosedTotalDenominatorIsShowing("1", "3");
			stepsNewProductIngredients.ThenIVerifyTheTransparencyScoreDisplays((float)33.33);
			//And In the Ingredients page I confirm the Publicly Disclosed Transparency score is flagged as a warning
			stepsNewProductIngredients
				.IngredientsPageIConfirmThePubliclyDisclosedTransparencyScoreIsFlaggedRed("warning");
			//And I call Shared Step 79436 (Ingredients - Add FRAGRANCE component, Publicly Disclosed = Yes, Select Public Name) and save ingredient as: Ing808214
			//| CASNumber  | ComponentName    | Percentage |
			//| RR-38213-8 | FRAGRANCE-BANANA | 10         |
			var table37 = new Table(new string[] {
				"CASNumber",
				"ComponentName",
				"Percentage"
			});
			table37.AddRow(new string[] {
				"RR-38213-8",
				"FRAGRANCE-BANANA",
				"10"
			});
			sharedSteps.CallSharedIngredients_AddFragranceComponent_PubliclyDisclosedYes_SelectPublicName(
				"Ing" + savedAs + "6", table37);
			//Then In the Ingredients page I confirm the Publicly Disclosed Transparency Score has numerator: 1 and denominator: 4
			//stepsNewProductIngredients.IngredientsPageIConfirmThePublicallyDisclosedTotalDenominatorIsShowing("1", "4");
			stepsNewProductIngredients.ThenIVerifyTheTransparencyScoreDisplays((float)25.00);
			//And In the Ingredients page I confirm the Publicly Disclosed Transparency score is flagged as a danger
			stepsNewProductIngredients
				.IngredientsPageIConfirmThePubliclyDisclosedTransparencyScoreIsFlaggedRed("danger");
			//And I call Shared Step 80822 - Ingredients - Add non-generic - specific component - set publicly disclosed and add public name and save ingredient as: Ing808215
			//| CASNumber | ComponentName    | Percentage | Publicly Disclosed | Public Name            |
			//| FLAVOR    | 611 Grape Flavor | 10         | No                 | Undisclosed Ingredient |
			var table38 = new Table(new string[] {
				"CASNumber",
				"ComponentName",
				"Percentage",
				"Publicly Disclosed",
				"Public Name"
			});
			table38.AddRow(new string[] {
				"FLAVOR",
				"611 Grape Flavor",
				"10",
				"No",
				"Undisclosed Ingredient"
			});
			sharedSteps
				.ThenICallSharedStep_Ingredients_AddNon_Generic_SpecificComponent_SetPubliclyDisclosedAndAddPublicName(
					"Ing" + savedAs + "7", table38);
			//And In the Ingredients page I confirm the Publicly Disclosed Transparency Score has numerator: 1 and denominator: 5
			//stepsNewProductIngredients.IngredientsPageIConfirmThePublicallyDisclosedTotalDenominatorIsShowing("1", "5");
			stepsNewProductIngredients.ThenIVerifyTheTransparencyScoreDisplays((float)20.00);
			//And In the Ingredients page I confirm the Publicly Disclosed Transparency score is flagged as a danger
			stepsNewProductIngredients
				.IngredientsPageIConfirmThePubliclyDisclosedTransparencyScoreIsFlaggedRed("danger");
			//And I call Shared Step 80822 - Ingredients - Add non-generic - specific component - set publicly disclosed and add public name and save ingredient as: Ing808216
			//| CASNumber | ComponentName                 | Percentage | Publicly Disclosed | Public Name            |
			//| NA519     | Black Cherry - Natural Flavor | 10         | Yes                | Undisclosed Ingredient |
			var table39 = new Table(new string[] {
				"CASNumber",
				"ComponentName",
				"Percentage",
				"Publicly Disclosed",
				"Public Name"
			});
			table39.AddRow(new string[] {
				"NA519",
				"Black Cherry - Natural Flavor",
				"10",
				"Yes",
				"Undisclosed Ingredient"
			});
			sharedSteps
				.ThenICallSharedStep_Ingredients_AddNon_Generic_SpecificComponent_SetPubliclyDisclosedAndAddPublicName(
					"Ing" + savedAs + "8", table39);
			//And In the Ingredients page I confirm the Publicly Disclosed Transparency Score has numerator: 2 and denominator: 6
			//stepsNewProductIngredients.IngredientsPageIConfirmThePublicallyDisclosedTotalDenominatorIsShowing("2", "6");
			stepsNewProductIngredients.ThenIVerifyTheTransparencyScoreDisplays((float)33.33);
			//And In the Ingredients page I confirm the Publicly Disclosed Transparency score is flagged as a warning
			stepsNewProductIngredients
				.IngredientsPageIConfirmThePubliclyDisclosedTransparencyScoreIsFlaggedRed("warning");
			//And I call Shared Step 79436 (Ingredients - Add FRAGRANCE component, Publicly Disclosed = Yes, Select Public Name) and save ingredient as: Ing808217
			//| CASNumber | ComponentName                                                                                                       | Percentage |
			//| FRAGRANCE | Fragrance - Birch Branch: Skin Irrit. 2, Eye Irrit. 2A, Skin Sens. 1, Repro Tox 2, Acute Aquatic 2, Chronic Acute 2 | 10         |
			var table40 = new Table(new string[] {
				"CASNumber",
				"ComponentName",
				"Percentage"
			});
			table40.AddRow(new string[] {
				"FRAGRANCE",
				"Fragrance - Birch Branch: Skin Irrit. 2, Eye Irrit. 2A, Skin Sens. 1, Repro Tox 2" +
				", Acute Aquatic 2, Chronic Acute 2",
				"10"
			});
			sharedSteps.CallSharedIngredients_AddFragranceComponent_PubliclyDisclosedYes_SelectPublicName(
				"Ing" + savedAs + "9", table40);
			//And In the Ingredients page I confirm the Publicly Disclosed Transparency Score has numerator: 2 and denominator: 7
			//stepsNewProductIngredients.IngredientsPageIConfirmThePublicallyDisclosedTotalDenominatorIsShowing("2", "7");
			stepsNewProductIngredients.ThenIVerifyTheTransparencyScoreDisplays((float)28.57);
			//And In the Ingredients page I confirm the Publicly Disclosed Transparency score is flagged as a warning
			stepsNewProductIngredients
				.IngredientsPageIConfirmThePubliclyDisclosedTransparencyScoreIsFlaggedRed("warning");
			//And I call Shared Step 80822 - Ingredients - Add non-generic - specific component - set publicly disclosed and add public name and save ingredient as: Ing808218
			//| CASNumber | ComponentName | Percentage | Publicly Disclosed | Public Name            |
			//| 7732-18-5 | Water         | 10         | Yes                | Undisclosed Ingredient |
			var table41 = new Table(new string[] {
				"CASNumber",
				"ComponentName",
				"Percentage",
				"Publicly Disclosed",
				"Public Name"
			});
			table41.AddRow(new string[] {
				"7732-18-5",
				"Water",
				"10",
				"Yes",
				"Undisclosed Ingredient"
			});
			sharedSteps
				.ThenICallSharedStep_Ingredients_AddNon_Generic_SpecificComponent_SetPubliclyDisclosedAndAddPublicName(
					"Ing" + savedAs + "10", table41);
			//And In the Ingredients page I confirm the Publicly Disclosed Transparency Score has numerator: 3 and denominator: 8
			//stepsNewProductIngredients.IngredientsPageIConfirmThePublicallyDisclosedTotalDenominatorIsShowing("3", "8");
			stepsNewProductIngredients.ThenIVerifyTheTransparencyScoreDisplays((float)37.50);
			//And In the Ingredients page I confirm the Publicly Disclosed Transparency score is flagged as a warning
			stepsNewProductIngredients
				.IngredientsPageIConfirmThePubliclyDisclosedTransparencyScoreIsFlaggedRed("warning");
			//Then in the Ingredients page I click Continue
			newProductSteps.GivenInTheNewProductPageIClickContinue("Ingredients");
			//And I call Shared Step 79507 (Formulation > 3rd Party - Accept formulation - Grant Tier 2 - Continue)
			sharedSteps.GivenICallSharedStepFormulationRdParty_AcceptFormulation_GrantTier_Continue();
			//And I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
			sharedSteps.GivenICallSharedEnterRegulatoryInformation_NotProp();
			//And I call Shared Step 60932 (Regulatory Information 2 - Microbeads - No)
			sharedSteps.SharedRegulatoryInformation2_Microbeads_No();
			//And I should see the Additional Documents to Provide Page
			newProductSteps.GivenIShouldSeeXPage("Additional Documents to Provide");
			//And I call Shared Step 59042 (Browse for File > select > click Open - Happy Path) for document type: IFRA Certificate(Perfumery Products) and file: C:\Dependencies\WERCSmart\testdoc.pdf
			sharedSteps.ICallSharedBrowseForFileSelectClickOpen("IFRA Certificate (Perfumery Products)",
				@"C:\Dependencies\WERCSmart\testdoc.pdf");
			//And I call Shared Step 59042 (Browse for File > select > click Open - Happy Path) for document type: GRAS Certificate(Flavor Products) and file: C:\Dependencies\WERCSmart\testdoc.pdf
			sharedSteps.ICallSharedBrowseForFileSelectClickOpen("GRAS Certificate (Flavor Products)",
				@"C:\Dependencies\WERCSmart\testdoc.pdf");
			//Then in the Additional documents page I click Continue
			newProductSteps.GivenInTheNewProductPageIClickContinue("Additional documents");
			//Then in the Product aliases page I click Continue
			newProductSteps.GivenInTheNewProductPageIClickContinue("Formulation Names");
			//And I call Shared Step 57883 (Comments - Happy Path) and enter the comment: test
			sharedSteps.GivenICallSharedCommentsHappyPath("Test Comment");
			//And I call Shared Step 58610 (Confirm Restrict Use - Restrict)
			sharedSteps.SharedConfirmRestrictUse_Restrict();
			//And I call Shared Step 73956 (Go to Summary and verify data) with product type: Raw material
			sharedSteps.SharedGoToSummaryAndVerifyData("Raw material");
			// 57885 (Data Acceptance - Click Accept - Happy Path)
			sharedSteps.GivenICallSharedDataAcceptance_ClickAccept_HappyPath();
			// If purchase details are showing click confirm order
			newProductSteps.GivenIfPurchaseDetailsAreShowingClickConfirmOrder();
			// 65080 (Login to Studio and Open SHA manager)
			sharedSteps.GivenICallShared65080LoginToStudioAndOpenSHAManager();
			// 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase75335)
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			// In the SHA manager grid I see the WPS ID I have saved as product: TestCase75335 and its status is: Submitted
			shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(savedAs,
				"Submitted");
			//Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase80821)
			sharedSteps.GivenICallSharedSHAManager_Submitted_SelectProductProcessProductData(savedAs);
			//Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase80821)
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			//Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase80821 and its status is: Assigned
			shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(savedAs,
				"Assigned");
			//And I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase80821)
			sharedSteps.GivenICallSharedWPSStudio_JobQueue_WaitForImportProcessRulesJobToComplete(savedAs);
			//And I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase80821)
			sharedSteps.GivenICallSharedWPSStudio_OpenPDEditExistingWithSpecificProductClickContinue(savedAs);
			//And In Power Designer I left click on section: [SECT0077] Walmart Transportation Information
			studioSteps.GivenInPowerDesignerIClickOnSection("left", "[SECT0077] Walmart Transportation Information");
			//And In Power Designer I double click on category: Water Soluble?
			studioSteps.GivenInPowerDesignerIDoubleClickOnCategory("Water Soluble?");
			//Then In Power Designer the phrase selector screen should open
			studioSteps.ThenInPowerDesignerThePhraseSelectorScreenShouldOpen();
			//And In the phrase selector screen I select phrases:
			//| Text |
			//| Y    |
			var table42 = new Table(new string[] {
				"Text"
			});
			table42.AddRow(new string[] {
				"Y"
			});
			studioSteps.ThenInThePhraseSelectorScreenISelectPhrases(table42);
			//And In the phrase selector screen I click button: Save
			studioSteps.ThenInThePhraseSelectorScreenIClickButton("Save");
			//And I call Shared Step 79501 (WPS Studio - PD+ - Create Component for 3rd party product)
			//| Component CAS          | Component ID | Chemical Name               |
			//| saved as TestCase80821 | MIXTURE      | AAA WERCS Test Raw Material |

			var table43 = new Table(new string[] {
				"Component CAS",
				"Component ID",
				"Chemical Name"
			});
			table43.AddRow(new string[] {
				"saved as " + savedAs,
				"MIXTURE",
				"AAA WERCS Test Raw Material"
			});
			sharedSteps.GivenICallSharedStep79501WPSStudio_PD_CreateComponentForRdPartyProduct(table43);
			//Given I click on home to navigate back to editing specific product saved as TestCase80821
			studioSteps.GivenIClickOnHomeToNavigateBackToEditingSpecificProductSavedAs(savedAs);

			//And I call Shared Step 79500 (WPS Studio - PD+ - set all data and publish using rule and doc queue - CKLT and SBCS only) for product saved as: TestCase80821
			sharedSteps.GivenICallSharedStep79500WPSStudio_PD_SetAllDataAndPublishUsingRuleAndDocQueue_CKLTAndSBCSOnly(
				savedAs);

			// 59066(Go to SHA Manager)
			sharedSteps.GivenICallSharedStep59066GoToSHAManager();
			//Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase80821)
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			Report.Info(
				"the SHA manager grid I see the WPS ID I have saved as product: X and its status is: Completed");
			//Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase80821 and its status is: Completed
			shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(savedAs,
				"Completed");



		}

		[StepDefinition(
			@"I create a product with name: (.*) while logged in as (.*) and take to completed using Test Case 79428 and save as: (.*)")]
		public void GivenICreateAProductWithNameAndTakeToCompletedUsingTestCase79428AndSaveAsTestCase(
			string productName, string loggedInAs, string savedAs)
		{
			ReportSettings.UseSubSteps = true;
			var sharedSteps = new Steps_Shared();
			var newProductSteps = new StepsNewProduct();
			var stepsNewProductIngredients = new StepsIngredients();
			var shaSteps = new Steps_SHA();
			var thisGlobalSteps = new GlobalSteps();
			var thisStepsProductGrid = new StepsProductGrid();
			var thisStepsHomePage = new StepsHomepage();
			var studioSteps = new Steps_Studio();
			//Scenario: [80821] Create a 3rd party product - with Tier 2 approval Specific components for Transparency ratio testing
			//Given I generate a random UPC number and save as: UPC80821
			new StepsProductGrid().GivenIGenerateARandomUPCNumberAndSaveAs("UPC" + savedAs);
			//And I call Shared Step 67823(Login to WERCSmart - Products Automation Account)
			//Given I navigate to the landing page
			thisGlobalSteps.NavigateToLandingPage();
			//Given I login into the WERCSmart Portal - Administrator Role

			if (loggedInAs == "Portal - ULSC Role")
			{
				sharedSteps.Shared67038_LoginToWercSmartPortal_UlscRole();
			}
			else
			{
				sharedSteps.GivenICallSharedStep67823LoginToWERCSmart_ProductsAutomationAccount();
			}

			//And I call Shared Step 57753 (Create a New Registration via Register New Product(expanded menu))
			sharedSteps.GivenICallSharedCreateANewRegistrationViaRegisterNewProductExpandedMenu();
			//And I call Shared Step 57561(The Product - Enter Product Name and select Type of Product): Raw Material
			sharedSteps.GivenICallSharedStepTheProduct_EnterProductNameAndSelectTypeOfProduct("Raw Material");

			Report.Info("Checking for warning dialog");
			if (new DataEntryNotification().Wait_for_close(10))
			{
				Report.Info("Warning open");
				Report.Screenshot();
				if (!new DataEntryNotification().ClickOK())
				{
					Report.Error("Could not close warning");
				}
			}
			newProductSteps.SaveProductInformation(savedAs);
			//And I Use the shared step below to add a FLAVOR component to your formulation - for example use a FLAVORS Ingredient with the CAS Number of RR - 38669 - 6
			//And I call Shared Step 79431(Ingredients - Add FLAVOR component, Publicly Disclosed = Yes, Select Public Name) and save ingredients as: (.*)

			var table34 = new Table(new string[] {
				"CASNumber",
				"ComponentName",
				"Percentage",
				"Publicly Disclosed",
				"Public Name"
			});
			table34.AddRow(new string[] {
				"RR-38669-6",
				"FLAVORS",
				"35",
				"Yes",
				"Undisclosed Ingredient"
			});
			sharedSteps
				.ThenICallSharedStep_Ingredients_AddNon_Generic_SpecificComponent_SetPubliclyDisclosedAndAddPublicName(
					"Ing" + savedAs + "1", table34);

			//And I Use the shared step below to add a FRAGRANCE component to your formulation - for example use Fragrance - Gardenia: Skin irritant 2, Eye damage 1, Skin sensitization 1, Carcinogen 1A, reproductive toxin 2, Aquatic acute 2, Aquatic Chronic 2 / FRAGRANCE
			//And I call Shared Step 79436(Ingredients - Add FRAGRANCE component, Publicly Disclosed = Yes, Select Public Name) and save ingredient as: (.*)

			var table36 = new Table(new string[] {
				"CASNumber",
				"ComponentName",
				"Percentage"
			});
			table36.AddRow(new string[] {
				"RR-38384-6",
				"FRAGRANCE-HERBAL",
				"35"
			});
			sharedSteps.CallSharedIngredients_AddFragranceComponent_PubliclyDisclosedYes_SelectPublicName(
				"Ing" + savedAs + "5", table36);


			//And I call Shared Step 79490(Ingredients - Add non - generic component - Public Disclosed = Yes, select Name Continue) and save ingredient as: Ing79428NG
			//	| CASNumber | ComponentName | Percentage |
			//	| 50 - 00 - 0 | Formaldehyde | 30 |
			var table55 = new Table(new string[] {
				"CASNumber",
				"ComponentName",
				"Percentage",
				"Publicly Disclosed",
				"Public Name"
			});
			table55.AddRow(new string[] {
				"50-00-0",
				"Formaldehyde",
				"30",
				"Yes",
				"Undisclosed Ingredient"
			});
			sharedSteps
				.ThenICallSharedStep_Ingredients_AddNon_Generic_SpecificComponent_SetPubliclyDisclosedAndAddPublicName(
					"Ing" + savedAs + "3", table55);


			//Then in the Ingredients page I click Continue
			newProductSteps.GivenInTheNewProductPageIClickContinue("Ingredients");
			//And I call Shared Step 79507 (Formulation > 3rd Party - Accept formulation - Grant Tier 2 - Continue)
			sharedSteps.SharedFormulation3rdParty_SelectAll();			
			//And I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
			sharedSteps.GivenICallSharedEnterRegulatoryInformation_NotProp();
			//And I call Shared Step 60932 (Regulatory Information 2 - Microbeads - No)
			sharedSteps.SharedRegulatoryInformation2_Microbeads_No();
			//And I should see the Additional Documents to Provide Page
			newProductSteps.GivenIShouldSeeXPage("Additional Documents to Provide");
			//And I call Shared Step 59042 (Browse for File > select > click Open - Happy Path) for document type: IFRA Certificate(Perfumery Products) and file: C:\Dependencies\WERCSmart\testdoc.pdf
			sharedSteps.ICallSharedBrowseForFileSelectClickOpen("IFRA Certificate (Perfumery Products)",
				@"C:\Dependencies\WERCSmart\testdoc.pdf");
			//And I call Shared Step 59042 (Browse for File > select > click Open - Happy Path) for document type: GRAS Certificate(Flavor Products) and file: C:\Dependencies\WERCSmart\testdoc.pdf
			sharedSteps.ICallSharedBrowseForFileSelectClickOpen("GRAS Certificate (Flavor Products)",
				@"C:\Dependencies\WERCSmart\testdoc.pdf");
			//Then in the Additional documents page I click Continue
			newProductSteps.GivenInTheNewProductPageIClickContinue("Additional documents");
			//Then in the Product aliases page I click Continue
			newProductSteps.GivenInTheNewProductPageIClickContinue("Formulation Names");
			//And I call Shared Step 58610(Confirm Restrict Use - Restrict)
			sharedSteps.SharedConfirmRestrictUse_Restrict();			
			//In the Sustainability page I click Continue
			newProductSteps.ClickContinue();
			//And I call Shared Step 57883 (Comments - Happy Path) and enter the comment: test
			sharedSteps.GivenICallSharedCommentsHappyPath("Test Comment");			
			//And I call Shared Step 73956 (Go to Summary and verify data) with product type: Raw material
			sharedSteps.SharedGoToSummaryAndVerifyData("Raw material");
			// 57885 (Data Acceptance - Click Accept - Happy Path)
			sharedSteps.GivenICallSharedDataAcceptance_ClickAccept_HappyPath();
			// If purchase details are showing click confirm order
			newProductSteps.GivenIfPurchaseDetailsAreShowingClickConfirmOrder();

			//************************** Switching to SHA Manager ********************

			// 65080 (Login to Studio and Open SHA manager)
			sharedSteps.GivenICallShared65080LoginToStudioAndOpenSHAManager();
			// 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase75335)
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			// In the SHA manager grid I see the WPS ID I have saved as product: TestCase75335 and its status is: Submitted
			shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(savedAs,
				"Submitted");
			//Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase80821)
			sharedSteps.GivenICallSharedSHAManager_Submitted_SelectProductProcessProductData(savedAs);
			//Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase80821)
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			//Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase80821 and its status is: Assigned
			shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(savedAs,
				"Assigned");
			//And I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase80821)
			sharedSteps.GivenICallSharedWPSStudio_JobQueue_WaitForImportProcessRulesJobToComplete(savedAs);
			//And I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase80821)
			sharedSteps.GivenICallSharedWPSStudio_OpenPDEditExistingWithSpecificProductClickContinue(savedAs);
			//And In Power Designer I click on the 'Sections' side tab
			studioSteps.InPowerDesignerIClickOnTheSectionsSideTab();
			//And In Power Designer I left click on section: [SECT0077] Walmart Transportation Information
			studioSteps.GivenInPowerDesignerIClickOnSection("left", "[SECT0077] Walmart Transportation Information");
			//And In Power Designer I double click on category: Water Soluble?
			studioSteps.GivenInPowerDesignerIDoubleClickOnCategory("Water Soluble?");
			//Then In Power Designer the phrase selector screen should open
			studioSteps.ThenInPowerDesignerThePhraseSelectorScreenShouldOpen();
			//And In the phrase selector screen I select phrases:
			//| Text |
			//| Y    |
			var table42 = new Table(new string[] {
				"Text"
			});
			table42.AddRow(new string[] {
				"Y"
			});
			studioSteps.ThenInThePhraseSelectorScreenISelectPhrases(table42);
			//And In the phrase selector screen I click button: Save
			studioSteps.ThenInThePhraseSelectorScreenIClickButton("Save");

			//42196 Issue In below step -> "Failed to find menu item: Home" -> "Power designer plus has not loaded"
			//Given I click on home to navigate back to editing specific product saved as TestCase80821
			studioSteps.GivenIClickOnHomeToNavigateBackToEditingSpecificProductSavedAs(savedAs);

			//And I call Shared Step 79500 (WPS Studio - PD+ - set all data and publish using rule and doc queue - CKLT and SBCS only) for product saved as: TestCase80821
			sharedSteps.GivenICallSharedStep79500WPSStudio_PD_SetAllDataAndPublishUsingRuleAndDocQueue_CKLTAndSBCSOnly(
				savedAs);

			// 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase75335)
			sharedSteps.GivenICallShared55663WPSStudio_GoToJobQueue_WaitForPublishMultipleToComplete(savedAs);

			// 59066(Go to SHA Manager)
			sharedSteps.GivenICallSharedStep59066GoToSHAManager();
			//Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase80821)
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			Report.Info(
				"the SHA manager grid I see the WPS ID I have saved as product: X and its status is: Completed");
			//Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase80821 and its status is: Completed
			shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(savedAs,
				"Completed");



		}

		//Scenario: [77862] Create a Kit - Direct ship = Yes and retailer = Walmart - thru to Submitted status in SHA
		[StepDefinition(@"I use Test case 77862 to create a kit and save as (.*)")]
		public void GivenIUseTestCaseToCreateAKitAndSaveAsTestCase(string saveAs)
		{
			ReportSettings.UseSubSteps = true;
			var sharedSteps = new Steps_Shared();
			var productsGridSteps = new StepsProductGrid();
			var newProductSteps = new StepsNewProduct();
			var newProduct = new NewProduct();
			var shaSteps = new Steps_SHA();
			var thisGlobalSteps = new GlobalSteps();

			//For this test case you will need two input products in completed status which have SOLD set to US only and make sure to add
			//Walmart as the retailer for these products.
			//Use the test case 75335 to create these products - test case is linked to this one.Note: these input
			//products do not have to be direct ship vendor products
			if (!Context.Contains("77862_KitProduct1"))
			{
				Report.StartStep("Beginning create kit 1");
				this.CreateProductUsingTestCase75335Walmart("77862_KitProduct1");
				thisGlobalSteps.NavigateToLandingPage();
			}

			if (!Context.Contains("77862_KitProduct2"))
			{
				Report.StartStep("Beginning create kit 2");
				this.CreateProductUsingTestCase75335Walmart("77862_KitProduct2");
				thisGlobalSteps.NavigateToLandingPage();
			}

			//And I call Shared Step 67823(Login to WERCSmart - Products Automation Account)
			sharedSteps.GivenICallSharedStep67823LoginToWERCSmart_ProductsAutomationAccount();

			// Generate UPC number and delete duplicates
			productsGridSteps.GivenIGenerateARandomUPCNumberAndSaveAs("UPC77862");
			productsGridSteps.DeleteAllProductsMatchingCriteria("UPC Number", "saved as UPC77862");


			//And I call Shared Step 57753(Create a New Registration via Register New Product(expanded menu))
			sharedSteps.GivenICallSharedCreateANewRegistrationViaRegisterNewProductExpandedMenu();
			//And I In the shared step below use any of the kit product types -these are* Cosmetic Products in a kit(RU000777)*Hair Care kit(RU000723)*Hair Color Kit(RU000724)*Emergency Road kit(RU000718)*Automotive Care Products(RU000124)*Personal Care kit(RU001034)
			//And I call Shared Step 57500(The Product - Enter name, select product type - Continue - Happy Path): (.*)
			sharedSteps.GivenICallSharedStepTheProduct_EnterNameSelectProductType_Continue_HappyPath(
				"Emergency Road kit", "Kit" + System.DateTime.Now.DayOfWeek + System.DateTime.Now.Hour + System.DateTime.Now.Minute + System.DateTime.Now.Second);
			//And I call Shared Step 77872(Product Information - Kit flow - US only, Direct Ship(yes), Continue)
			newProductSteps.SaveProductInformation(saveAs);
			sharedSteps.Shared77872_ProductInformation_KitFlow_UsOnly_DirectShip_Yes_Continue();
			//And I call Shared Step 57503(Regulatory Information 1 - TSCA(Random) - Prop 65(No) - Continue - Happy Path)
			sharedSteps.ICallSharedRegulatoryInformation1_TSCARandom_Pro65No_Continue();
			//And I In the shared step below add the two completed products that you are working with
			//And I call Shared Step 31427(Create the Kit - Adding two products: product 1: (.*) and product 2: (.*))
			sharedSteps.Shared31427_CreateTheKit_AddingTwoProducts("77862_KitProduct1", "77862_KitProduct2");
			//And I call Shared Step 57506(Transportation Details 1 - Regulated for Transport(No) - Exemption(Random) - Continue - Happy Path)
			sharedSteps
				.GivenICallSharedTransportationDetails_RegulatedForTransportNo_ExemptionRandom_Continue_HappyPath();
			//And I call Shared Step 62536(Transportation Details 2 > I do not ship internationally > Continue - Happy Path)
			sharedSteps.SharedTransportationDetails2_DoNotShipInternationally_Continue();
			//And I call Shared Step 77845(Retailer - Select WM, Done, Select Vendor ID, Continue)
			sharedSteps.Shared77845_Retailer_SelectWM_Done_SelectVendorID_Continue();
			//And I call Shared Step 42759(Portal - UPC Page - add 1 UPC)
			sharedSteps.Shared42759a_Portal_UpcPage_AddUpcSavedAs("UPC77862");
			//And I click continue
			newProductSteps.ClickContinue();
			//And the comments field should appear
			newProductSteps.ThenTheCommentsFieldShouldAppear();
			//And I click continue
			newProductSteps.ClickContinue();
			// 57885 (Data Acceptance - Click Accept - Happy Path)
			sharedSteps.GivenICallSharedDataAcceptance_ClickAccept_HappyPath();
			// If purchase details are showing click confirm order
			newProductSteps.GivenIfPurchaseDetailsAreShowingClickConfirmOrder();
			//And I Click Home
			// 65080 (Login to Studio and Open SHA manager)
			sharedSteps.GivenICallShared65080LoginToStudioAndOpenSHAManager();
			// 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase75335)
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", saveAs);
			// In the SHA manager grid I see the WPS ID I have saved as product: TestCase75335 and its status is: Submitted
			shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(saveAs,
				"Submitted");
			//And I Confirm the Product ID: TestCase77862 is highlited yellow indicating that this is an e-comm/direct ship product

			shaSteps.ConfirmProductIdIsHighlightedYellow_EcommDirectShipProduct(saveAs);

		}


		[StepDefinition(@"I create a product with name: (.*) and take to completed using Test Case 75651 and save as: (.*)")]
		public void GivenICreateProductUsingTestCase75651(string name, string savedAs)
		{
			this.CreateProductUsingTestCase75651(savedAs, name);
		}

		public void CreateProductUsingTestCase75651(string savedAs, string name)
		{
			ReportSettings.UseSubSteps = true;
			var sharedSteps = new Steps_Shared();
			var productsGridSteps = new StepsProductGrid();
			var newProductSteps = new StepsNewProduct();
			var newProduct = new NewProduct();
			var shaSteps = new Steps_SHA();
			var thisGlobalSteps = new GlobalSteps();
			thisGlobalSteps.NavigateToLandingPage();
			// Log in to administrator role
			thisGlobalSteps.LoginToWERCSmartAdmin("WERCs Premium Subscription Account");
			// Generate UPC number and delete duplicates
			productsGridSteps.GivenIGenerateARandomUPCNumberAndSaveAs("UPC75651");
			productsGridSteps.DeleteAllProductsMatchingCriteria("UPC Number", "saved as UPC75651");
			// 57408 (Create a New Registration via Register New Product icon)
			sharedSteps.GivenICallSharedStepCreateANewRegistrationViaRegisterNewProductIcon();
			// 57500 (The Product- Enter name, select product type - Continue - Happy Path)
			sharedSteps.GivenICallSharedStepTheProduct_EnterNameSelectProductType_Continue_HappyPath("Chalk", name);
			// Save product to context
			newProductSteps.SaveProductInformation(savedAs);
			// 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
			sharedSteps.ICallSharedProductInformationUSOnlyNoChildNoGHSNoDirectShipNoPLPNoGNFR();
			// 26897 (Product Characteristics - Solid only available - continue)
			sharedSteps.SharedPhysicalandChemicalProperties_SolidOnlyAvailable_Continue();
			// 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
			sharedSteps.ICallSharedIngredients_AddAnyChemical("Sodium hydroxide");
			// 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
			sharedSteps.ICallSharedRegulatoryInformation1_TSCARandom_Pro65No_Continue();
			//And I call Shared Step 75146(Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue)
			var retailerTable = new Table(new string[] {
				"Retailer"});
			retailerTable.AddRow(new string[] {
				"CVS"});
			sharedSteps
				.GivenICallSharedStep75146Retailer_SelectOneOrMoreRetailersThatDoNotRequireVendorIDOrAdditionalUPCInformationClickDoneClickContinue(
					retailerTable);

			// 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC75335, container type: Metal Container and size: 40
			sharedSteps.GivenICallSharedEnterUniversalProductCodeUPC_UPC_ContainerType_SizeOnly("75651", "Metal Container", "40");
			// 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
			sharedSteps.GivenICallSharedRegulatoryDocumentsToProvide_USOnly_RequestAuthoring_HappyPath();
			// Click continue
			newProductSteps.ClickContinue();
			// Click continue
			newProductSteps.ClickContinue();
			// 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
			var sdsTable = new Table("Personal Protection Equipment", "Autoignition Temperature",
				"Minimum Ignition Energy", "Viscosity", "Appearance", "Odor", "Odor Threshold",
				"Partition Coefficient");
			sdsTable.AddRow("Mask", "300", "1", "20", "Black", "Odorless", "No data available", "10");
			sharedSteps
				.GivenICallSharedSafetyDataSheetAuthoring_AditionalDataStep_AddAnyRandomDataForAllFields_HappyPath(
					sdsTable);
			// 57883 (Comments - Happy Path) and enter the comment: Test Comment 75335
			sharedSteps.GivenICallSharedCommentsHappyPath("Test Comment 75335");
			// 57885 (Data Acceptance - Click Accept - Happy Path)
			sharedSteps.GivenICallSharedDataAcceptance_ClickAccept_HappyPath();
			// If purchase details are showing click confirm order
			newProductSteps.GivenIfPurchaseDetailsAreShowingClickConfirmOrder();
			// 65080 (Login to Studio and Open SHA manager)
			sharedSteps.GivenICallShared65080LoginToStudioAndOpenSHAManager();
			// 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase75335)
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			Report.Info(
				"the SHA manager grid I see the WPS ID I have saved as product: TestCase75335 and its status is: Submitted");
			// In the SHA manager grid I see the WPS ID I have saved as product: TestCase75335 and its status is: Submitted
			shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(savedAs,
				"Submitted");
			// 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase75335)
			sharedSteps.GivenICallSharedSHAManager_Submitted_SelectProductProcessProductData(savedAs);
			// 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase75335)
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			Report.Info(
				"the SHA manager grid I see the WPS ID I have saved as product: TestCase75335 and its status is: Assigned");
			// In the SHA manager grid I see the WPS ID I have saved as product: TestCase75335 and its status is: Assigned
			shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(savedAs,
				"Assigned");


		}

		[StepDefinition(@"I Use Test case 84518 to process the product from Assigned back to Completed status saved as (.*)")]
		public void GivenIUseTestCaseToProcessTheProductFromAssignedBackToCompletedStatusSavedAsTestCase(string savedAs)
		{
			this.ProcessAssignedFormulatedProductBackToCompletedUsingTestCase84518(savedAs);
		}



		public void ProcessAssignedFormulatedProductBackToCompletedUsingTestCase84518(string savedAs)
		{
			var sharedSteps = new Steps_Shared();

			//If you are running this test case you already have a formulated product which is in Assigned status having come from Recertification.
			//And I call Shared Step 65080(Login to Studio and Open SHA manager)
			sharedSteps.GivenICallShared65080LoginToStudioAndOpenSHAManager();
			//And I call Shared Step 68969(WPS Studio - Open PD +, edit existing with specific product > Click Continue for product saved as: (.*))
			sharedSteps.GivenICallSharedWPSStudio_OpenPDEditExistingWithSpecificProductClickContinue(savedAs);
			//And[Shared Step 75932 - WPS Studio - Toolbars - My Toolbar - Check IN / Out - Check in -close pop up]
			//This seems to do the same job...
			sharedSteps.GivenICallSharedStep49742_WPS_CheckInProduct(savedAs);
			//For recertification of a formulated product which has authoring requested,
			//we have to add NGHS to the document queue manually - CKLT and SBCS will be automatically
			//added to the document queue
			sharedSteps.ICallSharedStep84505();
			//Step 84505 - WPS PD + -Current Document - Add NGHS RTF and PDF to Document queue]
			//And I Click the Document Queue icon(icon looks like a page with three dots below it)
			//Report.StartStep("I click the Document queue icon in the tool bar");
			var thisStepsStudio = new Steps_Studio();
			thisStepsStudio.GivenInPowerDesignerPlusPageInMyToolbarTabIClickOnDocumentQueueButton();
			Report.StartStep("I click the filter icon");
			thisStepsStudio.InDocumentQueuePopupIClickOnFilterIcon();
			var productDetails = (ProductInformation)Context.GetFromContext(savedAs);
			string id = productDetails.Id;
			thisStepsStudio.InDocumentQueueFilterPageIEnterValueInSelectBox("Matches", @"Product\Alias");
			Report.StartStep("I enter the product id in the Product/Alias area of the filter and click Apply");
			thisStepsStudio.InDocumentQueueFilterPageIEnterValueInEntryBox(id, @"Product\Alias");
			thisStepsStudio.InDocumentQueueFilterPageIClickOnApply();

			for (int i = 0; i < 5; i++)
			{
				Delay.Seconds(5);
				Report.Screenshot();
				var newDocumentQueuePage = new DocumentQueuePage();
				Report.IsTrue(newDocumentQueuePage.Wait_for_load(30), "Document queue page failed to load",
					"Document queue page loaded");
				List<Document> listOfDocuments = newDocumentQueuePage.GetAllDocuments();
				if (listOfDocuments.Count > 0)
				{
					break;
				}
			}

			Report.StartStep(
				"I confirm the product is shown with entries for SBCS EN PDF, NGHS EN PDF, NGHS EN RTF, CKLT EN PDF");
			var tblCheckDocument = new TechTalk.SpecFlow.Table(new string[] {
				"ProductOrAlias",
				"Subformat",
				"Language",
				"DocType"
			});
			tblCheckDocument.AddRow(new string[] {
				"saved as " + savedAs,
				"SBCS",
				"EN",
				"PDF"
			});
			tblCheckDocument.AddRow(new string[] {
				"saved as " + savedAs,
				"NGHS",
				"EN",
				"PDF"
			});
			tblCheckDocument.AddRow(new string[] {
				"saved as " + savedAs,
				"NGHS",
				"EN",
				"RTF"
			});
			tblCheckDocument.AddRow(new string[] {
				"saved as " + savedAs,
				"CKLT",
				"EN",
				"PDF"
			});
			thisStepsStudio.GivenICheckTheFollowingItemsAreShowingInTheDocumentQueueTable(tblCheckDocument);
			Delay.Seconds(3);
			thisStepsStudio.IClickOnPublishThisDocumentToOpenDocumentQueuePopup();
			Delay.Seconds(3);
			Report.Screenshot();
			// And I Confirm you see entries for NGHS(RTF and PDF), CKLT and SBCS(both PDF only)
			// And I Select the two entries for NGHS
			// And I Click Process Documents
			// And I 2 queued document(s) were sent for publishing message is shown - Click OK to close
			// And I Select the entries for CKLT and SBCS
			// And I Click process Documents
			// And I 2 queued document(s) were sent for publishing message is shown - Click OK to close
			thisStepsStudio.InDocumentQueueFilterPageIClickOnSelectAllCheckbox();
			Report.Screenshot();
			Report.StartStep("I click Process Documents");
			thisStepsStudio.InDocumentQueueFilterPageIClickOnProcessDocuments();
			Delay.Seconds(2);
			Report.Screenshot();
			GeneralUtilities.StudioWaitForSpinner(60);
			Report.StartStep(
				"I confirm a pop up shows with message indicating 4 queued documents were sent for publishing");
			thisStepsStudio.IShouldSeeAnAlertAsFollows("queued document(s) were sent for publishing.");
			Report.StartStep("I click OK ");
			thisStepsStudio.ICloseAlert();
			Report.StartStep("I close the Document queue window");
			thisStepsStudio.InDocumentQueueFilterPageIClickOnClose();

			// And I call Shared Step 55663(WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: (.*))
			sharedSteps.GivenICallShared55663WPSStudio_GoToJobQueue_WaitForPublishMultipleToComplete(savedAs);
			// 59066(Go to SHA Manager)
			sharedSteps.GivenICallSharedStep59066GoToSHAManager();
			// 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase75335)
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			//And I Depending in the retailers you selected your product will be shown in the Accepted or Completed status.If any retailer is shown in Accepted use the shared step below to set to Completed
			var shaSteps = new Steps_SHA();
			Report.StartStep("Depending in the retailers you selected your product will be shown in the Accepted or Completed status");
			shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(savedAs, "Accepted or Completed");

			string currentStatus = new StudioSHAManager().GetproductStatus(id).StatusName;

			if (currentStatus == "Accepted")
			{
				// 51664 (SHA - Accepted Product - set Retailers to Completed for saved as: TestCase75335)
				var table4 = new TechTalk.SpecFlow.Table(new string[] {
					"Retailer"
				});
				table4.AddRow(new string[] {
					"Wal-Mart/SAM'S CLUB (WM)"
				});
				sharedSteps.GivenICallShared51664SHA_AcceptedProduct_SetRetailersToCompletedForSavedAs(savedAs, table4);
				// 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase75335)
				sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
				// In the SHA manager grid I see the WPS ID I have saved as product: TestCase75335 and its status is: Completed
				shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(savedAs,
					"Completed");
			}



		}

		[StepDefinition(
			@"I create a product with name: (.*) and take to completed using Test Case 78865 and save as: (.*)")]
		public void GivenICreateProductUsingTestCase78865(string name, string savedAs)
		{
			this.CreateProductUsingTestCase78865(savedAs, name);
		}

		public void CreateProductUsingTestCase78865(string savedAs, string name)
		{
			Report.Info("Create product using Test Case 78865");
			var sharedSteps = new Steps_Shared();
			var productsGridSteps = new StepsProductGrid();
			var newProductSteps = new StepsNewProduct();
			var newProduct = new NewProduct();
			var shaSteps = new Steps_SHA();
			//Given I login into the WERCSmart Portal - Canada has all data account
			new GlobalSteps().LoginToWERCSmart("Canada has all data account");
			// Generate UPC number and delete duplicates
			productsGridSteps.GivenIGenerateARandomUPCNumberAndSaveAs("UPC78865");
			productsGridSteps.DeleteAllProductsMatchingCriteria("UPC Number", "saved as UPC78865");
			// 57408 (Create a New Registration via Register New Product icon)
			sharedSteps.GivenICallSharedStepCreateANewRegistrationViaRegisterNewProductIcon();
			// 57500 (The Product- Enter name, select product type - Continue - Happy Path)
			sharedSteps.GivenICallSharedStepTheProduct_EnterNameSelectProductType_Continue_HappyPath("Chalk");
			// Save product to context
			newProductSteps.SaveProductInformation(savedAs);

			//And I call Shared Step 78879 - Product Information -Canada Only - Child(NO), GHS(NO), DSV(NO), PLP(NO), GNFR(NO), Continue
			sharedSteps.ThenICallSharedStep78879ProductInformation_CanadaOnly_ChildNOGHSNODSVNOPLPNOGNFRNOContinue();
			// 26897 (Product Characteristics - Solid only available - continue)
			sharedSteps.SharedPhysicalandChemicalProperties_SolidOnlyAvailable_Continue();
			
			// 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
			sharedSteps.ICallSharedIngredients_AddAnyChemical("Sodium hydroxide");
			//And I call Shared Step 57911(Regulatory Information 1 - CEPA only shown - Continue - Happy Path)
			sharedSteps.GivenICallSharedStepRegulatoryInformation_CEPAOnlyShown_Continue_HappyPath();
			//And I call Shared Step 29206(Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
			sharedSteps.ICallSharedRetailer_SelectNoRetailer_ClickDone();
			//And I call Shared Step 78884 - Regulatory Documents to Provide - Canada only - request authoring, upload label -Continue
			sharedSteps.ThenICallSharedStep78884RegulatoryDocumentsToProvide_CanadaOnly_RequestAuthoringUploadLabel_Continue();
			//Given in the Additional Documents to Provide page I click Continue
			newProductSteps.ClickContinue();
			//Given in the Optional Reports and Documents Available for Purchase page I click Continue
			newProductSteps.ClickContinue();
			//And I call Shared Step 64097 - Additional Documents->Contact Information - Add any Name, address, phone and emergency phone - Happy Path
			sharedSteps.GivenICallSharedStep64097_AdditionalDocuments_ContactInformation_AddAnyNameAddressPhoneAndEmergencyPhone_HappyPath();
			var sdsTable = new Table("Personal Protection Equipment", "Autoignition Temperature",
				"Minimum Ignition Energy", "Viscosity", "Appearance", "Odor", "Odor Threshold",
				"Partition Coefficient");
			sdsTable.AddRow("Mask", "300", "1", "20", "Black", "Odorless", "No data available", "10");
			sharedSteps
				.GivenICallSharedSafetyDataSheetAuthoring_AditionalDataStep_AddAnyRandomDataForAllFields_HappyPath(
					sdsTable);
			// 57883 (Comments - Happy Path) and enter the comment: Test Comment 75335
			sharedSteps.GivenICallSharedCommentsHappyPath("Test Comment 75335");
			// 57885 (Data Acceptance - Click Accept - Happy Path)
			sharedSteps.GivenICallSharedDataAcceptance_ClickAccept_HappyPath();

			//#And I The Purchase summary page will be shown with your product included.  Confirm your product shows entries forChemical AssessmentAdditional document Canada GHS SDS ENGLISH (USA)Additional document language Canada GHS SDS FRENCH (CANADA)

			// If purchase details are showing click confirm order
			newProductSteps.GivenIfPurchaseDetailsAreShowingClickConfirmOrder();
			// 65080 (Login to Studio and Open SHA manager)
			sharedSteps.GivenICallShared65080LoginToStudioAndOpenSHAManager();
			// 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase75335)
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			// In the SHA manager grid I see the WPS ID I have saved as product: TestCase75335 and its status is: Submitted
			shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(savedAs,
				"Submitted");
			// 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase75335)
			sharedSteps.GivenICallSharedSHAManager_Submitted_SelectProductProcessProductData(savedAs);
			// 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase75335)
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			// In the SHA manager grid I see the WPS ID I have saved as product: TestCase75335 and its status is: Assigned
			shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(savedAs,
				"Assigned");
			// 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase75335)
			sharedSteps.GivenICallSharedWPSStudio_JobQueue_WaitForImportProcessRulesJobToComplete(savedAs);
			// 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase75335)
			sharedSteps.GivenICallSharedWPSStudio_OpenPDEditExistingWithSpecificProductClickContinue(savedAs);
			//And I call Shared Step 78888 - WPS Studio - PD + -set all data and publish using rule and doc queue -CKLT, HGHS(EN and CF) and SBCS for product saved as TestCase78865
			sharedSteps.GivenICallSharedStep78888WPSStudio_PD_SetAllDataAndPublishUsingRuleAndDocQueue_CKLTHGHSENAndCFAndSBCS(savedAs);
			// 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase75335)
			sharedSteps.GivenICallShared55663WPSStudio_GoToJobQueue_WaitForPublishMultipleToComplete(savedAs);
			// 59066(Go to SHA Manager)
			sharedSteps.GivenICallSharedStep59066GoToSHAManager();
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			// In the SHA manager grid I see the WPS ID I have saved as product: TestCase75335 and its status is: Accepted
			shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(savedAs,
				"Completed");

		}


		[StepDefinition(@"I create a product and take it to the ingredients page and save as: (.*)")]
		public void CreateProductAndTakeToTheIngredientsPage(string savedAs)
		{
			var sharedSteps = new Steps_Shared();
			// 57408 (Create a New Registration via Register New Product icon)
			sharedSteps.GivenICallSharedStepCreateANewRegistrationViaRegisterNewProductIcon();
			// 57500 (The Product- Enter name, select product type - Continue - Happy Path)
			sharedSteps.GivenICallSharedStepTheProduct_EnterNameSelectProductType_Continue_HappyPath("Chalk", "ingredient test");
			// Save product to context
			new StepsNewProduct().SaveProductInformation(savedAs);
			// 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
			sharedSteps.ICallSharedProductInformationUSOnlyNoChildNoGHSNoDirectShipNoPLPNoGNFR();
			// 26897 (Product Characteristics - Solid only available - continue)
			sharedSteps.SharedPhysicalandChemicalProperties_SolidOnlyAvailable_Continue();

		}


		[StepDefinition(@"I generate a random UPC number for Amazon data tiers and save as: (.*)")]
		public void GivenIGenerateARandomUPCNumberForAmazon(string savedAs)
		{
			string uPCNo = GeneralFunctions.GenerateUPCNumber();
			var amUpc = "0192233" + uPCNo.Substring(7);
			var checkDigit = UpcCheckDigit(amUpc);
			var finalUpc = amUpc + checkDigit;
			Context.AddToContext(savedAs, finalUpc);
			Report.Info("Generated UPC No: " + finalUpc);
		}

		public static int UpcCheckDigit(string code)
		{
			int sum = 0;
			for (int i = 0; i < code.Length; i++)
			{
				int n = int.Parse(code.Substring(code.Length - 1 - i, 1));
				sum += i % 2 == 0 ? n * 3 : n;
			}
			return sum % 10 == 0 ? 0 : 10 - sum % 10;
		}

		public void CreateProductAndTakeToSubmitted(string savedAs, string name)
		{
			ReportSettings.UseSubSteps = true;
			var sharedSteps = new Steps_Shared();
			var productsGridSteps = new StepsProductGrid();
			var newProductSteps = new StepsNewProduct();
			var newProduct = new NewProduct();
			var shaSteps = new Steps_SHA();
			var thisGlobalSteps = new GlobalSteps();
			//thisGlobalSteps.NavigateToLandingPage();
			//// Log in to administrator role
			//sharedSteps.GivenICallSharedStep67823LoginToWERCSmart_ProductsAutomationAccount();
			//thisGlobalSteps.LoginToWERCSmartAdmin("WERCs Premium Subscription Account");
			// 57408 (Create a New Registration via Register New Product icon)
			sharedSteps.GivenICallSharedStepCreateANewRegistrationViaRegisterNewProductIcon();
			// 57500 (The Product- Enter name, select product type - Continue - Happy Path)
			sharedSteps.GivenICallSharedStepTheProduct_EnterNameSelectProductType_Continue_HappyPath("Chalk", name);
			// Save product to context
			newProductSteps.SaveProductInformation(savedAs);
			// 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
			sharedSteps.ICallSharedProductInformationUSOnlyNoChildNoGHSNoDirectShipNoPLPNoGNFR();
			// 26897 (Product Characteristics - Solid only available - continue)
			sharedSteps.SharedPhysicalandChemicalProperties_SolidOnlyAvailable_Continue();
			// 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
			sharedSteps.ICallSharedIngredients_AddAnyChemical("Sodium hydroxide");
			// 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
			sharedSteps.ICallSharedRegulatoryInformation1_TSCARandom_Pro65No_Continue();
			// 57510 \(Retailer Association - Select A Retailer - Continue - Happy Path\) and select the retailer: CVS
			sharedSteps.ICallSharedRetailer_SelectNoRetailer_ClickDone();
			// 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
			sharedSteps.GivenICallSharedRegulatoryDocumentsToProvide_USOnly_RequestAuthoring_HappyPath();
			// Click continue
			newProductSteps.ClickContinue();
			// Click continue
			newProductSteps.ClickContinue();
			// 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
			var sdsTable = new Table("Personal Protection Equipment", "Autoignition Temperature",
				"Minimum Ignition Energy", "Viscosity", "Appearance", "Odor", "Odor Threshold",
				"Partition Coefficient");
			sdsTable.AddRow("Mask", "300", "1", "20", "Black", "Odorless", "No data available", "10");
			sharedSteps
				.GivenICallSharedSafetyDataSheetAuthoring_AditionalDataStep_AddAnyRandomDataForAllFields_HappyPath(
					sdsTable);
			// 57883 (Comments - Happy Path) and enter the comment: Test Comment 75335
			sharedSteps.GivenICallSharedCommentsHappyPath("Test Comment 75335");
			// 57885 (Data Acceptance - Click Accept - Happy Path)
			sharedSteps.GivenICallSharedDataAcceptance_ClickAccept_HappyPath();
			// If purchase details are showing click confirm order
			newProductSteps.GivenIfPurchaseDetailsAreShowingClickConfirmOrder();

			////SHA Manager
			////********************
			//sharedSteps.GivenICallShared65080LoginToStudioAndOpenSHAManager();
			//// 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase75335)
			//sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			//Report.Info(
			//	"the SHA manager grid I see the WPS ID I have saved as product: TestCase75335 and its status is: Submitted");
			//// In the SHA manager grid I see the WPS ID I have saved as product: TestCase75335 and its status is: Submitted
			//shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(savedAs,
			//	"Submitted");
		}

		[StepDefinition(@"I create a product with RU - Chalk and take to submitted and save as: (.*)")]
		public void GivenICreateProductAndTakeItToSubmitted(string savedAs)
		{
			this.CreateProductAndTakeToSubmitted(savedAs, "Chalk");
		}

		[StepDefinition(@"I create a product and save as: (.*) and name as: (.*)")]
		public void CreateProductConditionerAndTakeToSubmitted(string savedAs, string name)
		{
			ReportSettings.UseSubSteps = true;
			var sharedSteps = new Steps_Shared();
			var productsGridSteps = new StepsProductGrid();
			var newProductSteps = new StepsNewProduct();
			var newProduct = new NewProduct();
			var shaSteps = new Steps_SHA();
			var thisGlobalSteps = new GlobalSteps();
			//thisGlobalSteps.NavigateToLandingPage();
			//// Log in to administrator role
			//sharedSteps.GivenICallSharedStep67823LoginToWERCSmart_ProductsAutomationAccount();
			//thisGlobalSteps.LoginToWERCSmartAdmin("WERCs Premium Subscription Account");
			// 57408 (Create a New Registration via Register New Product icon)
			productsGridSteps.GivenIGenerateARandomUPCNumberAndSaveAs("UPC75335");
			sharedSteps.GivenICallSharedStepCreateANewRegistrationViaRegisterNewProductIcon();
			// 57500 (The Product- Enter name, select product type - Continue - Happy Path)
			sharedSteps.GivenICallSharedStepTheProduct_EnterNameSelectProductType_Continue_HappyPath("Conditioner", name);
			// Save product to context
			newProductSteps.SaveProductInformation(savedAs);
			sharedSteps.SharedProductInformation_US_No_Child_OSHA_DSV_Yes_PLP_No_GNFR();
			sharedSteps.SharedPhysicalandChemicalProperties_LiquidOnlyAvailable_EnterAllData_Continue();

			sharedSteps.ICallSharedIngredients_AddAnyChemical("Sodium hydroxide");
			sharedSteps.ICallSharedRegulatoryInformation1_TSCARandom_Pro65No_Continue();
			sharedSteps.GivenICallSharedRegulatoryInformation_DrugFactsPanel_NoneOfTheAbove_Continue_HappyPath();
			sharedSteps.ICallSharedTransportationDetails1_NotRegulated();
			sharedSteps.GivenICallSharedRetailerAssociation_AddPrivateLabelInformationAndVendorId("Wal-Mart/SAM'S CLUB", "Holiday Time", "TestBrand");
			sharedSteps.GivenICallSharedEnterUniversalProductCodeUPC_UPC_ContainerType_SizeOnly("75335", "Cardboard", "2");
			//sharedSteps.retailer
			//sharedSteps.ICallSharedRetailer_SelectNoRetailer_ClickDone();
			// 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
			sharedSteps.GivenICallSharedRegulatoryDocumentsToProvide_USOnly_RequestAuthoring_HappyPath();
			// Click continue
			newProductSteps.ClickContinue();
			// Click continue
			newProductSteps.ClickContinue();
			// 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
			var sdsTable = new Table("Personal Protection Equipment", "Autoignition Temperature",
				"Minimum Ignition Energy", "Viscosity", "Appearance", "Odor", "Odor Threshold",
				"Partition Coefficient");
			sdsTable.AddRow("Mask", "300", "1", "20", "Black", "Odorless", "No data available", "10");
			sharedSteps
				.GivenICallSharedSafetyDataSheetAuthoring_AditionalDataStep_AddAnyRandomDataForAllFields_HappyPath(
					sdsTable);
			// 57883 (Comments - Happy Path) and enter the comment: Test Comment 75335
			sharedSteps.GivenICallSharedCommentsHappyPath("Test Comment");
			// 57885 (Data Acceptance - Click Accept - Happy Path)
			sharedSteps.GivenICallSharedDataAcceptance_ClickAccept_HappyPath();
			// If purchase details are showing click confirm order
			newProductSteps.GivenIfPurchaseDetailsAreShowingClickConfirmOrder();
		}

		public void CreateProductChalkWithCanadianTierAndPLAndGoToSummary(string savedAs, string name)
		{
			ReportSettings.UseSubSteps = true;
			var sharedSteps = new Steps_Shared();
			var productsGridSteps = new StepsProductGrid();
			var newProductSteps = new StepsNewProduct();
			var newProduct = new NewProduct();
			var shaSteps = new Steps_SHA();
			var thisGlobalSteps = new GlobalSteps();
			productsGridSteps.GivenIGenerateARandomUPCNumberAndSaveAs("UPCForCT");
			sharedSteps.GivenICallSharedStepCreateANewRegistrationViaRegisterNewProductIcon();
			// 57500 (The Product- Enter name, select product type - Continue - Happy Path)
			sharedSteps.GivenICallSharedStepTheProduct_EnterNameSelectProductType_Continue_HappyPath("Crayon", name);
			// Save product to context
			newProductSteps.SaveProductInformation(savedAs);
			sharedSteps.ThenICallSharedStep85730ProductInformation_CanadaOnly_ChildNOGHSNODSVNOPLPYESGNFRNOContinue();
			sharedSteps.SharedPhysicalandChemicalProperties_SolidOnlyAvailable_Continue();
			sharedSteps.ICallSharedIngredients_AddAnyChemical("Sodium hydroxide");
			sharedSteps.GivenICallSharedStepRegulatoryInformation_CEPAOnlyShown_Continue_HappyPath();
			var retailerTable = new Table("Retailer");
			retailerTable.AddRow("Canadian Tire");
			sharedSteps.ThenICallSharedStep_Retailers_PLP_SelectOneOrMoreRetailerAndAddPLInformation_Continue(retailerTable);
			sharedSteps.ThenICallSharedStep75702_UPC_AddUPCContainerTypeSizeAndPackageTypeNoRetailerDataNeeded_Continue("saved as UPCForCT", "Metal Container", "2");
			//sharedSteps.GivenICallSharedEnterUniversalProductCodeUPC_UPC_ContainerType_SizeOnly("75335", "Cardboard", "2");
			//sharedSteps.retailer
			//sharedSteps.ICallSharedRetailer_SelectNoRetailer_ClickDone();
			// 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
			sharedSteps.ThenICallSharedStep78884RegulatoryDocumentsToProvide_CanadaOnly_RequestAuthoringUploadLabel_Continue();
			// Click continue
			newProductSteps.ClickContinue();
			// Click continue
			newProductSteps.ClickContinue();
			sharedSteps.GivenICallSharedStep64097_AdditionalDocuments_ContactInformation_AddAnyNameAddressPhoneAndEmergencyPhone_HappyPath();
			// 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
			var sdsTable = new Table("Personal Protection Equipment", "Autoignition Temperature",
				"Minimum Ignition Energy", "Viscosity", "Appearance", "Odor", "Odor Threshold",
				"Partition Coefficient");
			sdsTable.AddRow("Mask", "300", "1", "20", "Black", "Odorless", "No data available", "10");
			sharedSteps
				.GivenICallSharedSafetyDataSheetAuthoring_AditionalDataStep_AddAnyRandomDataForAllFields_HappyPath(
					sdsTable);
			// 57883 (Comments - Happy Path) and enter the comment: Test Comment 75335
			sharedSteps.GivenICallSharedCommentsHappyPath("Test Comment");
		}

		public void CreateProductChalkAndClickAcceptOnDataAcceptance(string savedAs, string name)
		{
			ReportSettings.UseSubSteps = true;
			var sharedSteps = new Steps_Shared();
			var productsGridSteps = new StepsProductGrid();
			var newProductSteps = new StepsNewProduct();
			var newProduct = new NewProduct();
			var shaSteps = new Steps_SHA();
			var thisGlobalSteps = new GlobalSteps();
			//thisGlobalSteps.NavigateToLandingPage();
			//// Log in to administrator role
			//sharedSteps.GivenICallSharedStep67823LoginToWERCSmart_ProductsAutomationAccount();
			//thisGlobalSteps.LoginToWERCSmartAdmin("WERCs Premium Subscription Account");
			// 57408 (Create a New Registration via Register New Product icon)
			sharedSteps.GivenICallSharedStepCreateANewRegistrationViaRegisterNewProductIcon();
			// 57500 (The Product- Enter name, select product type - Continue - Happy Path)
			sharedSteps.GivenICallSharedStepTheProduct_EnterNameSelectProductType_Continue_HappyPath("Chalk", name);
			// Save product to context
			newProductSteps.SaveProductInformation(savedAs);
			// 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
			sharedSteps.ICallSharedProductInformationUSOnlyNoChildNoGHSNoDirectShipNoPLPNoGNFR();
			// 26897 (Product Characteristics - Solid only available - continue)
			sharedSteps.SharedPhysicalandChemicalProperties_SolidOnlyAvailable_Continue();
			// 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
			sharedSteps.ICallSharedIngredients_AddAnyChemical("Sodium hydroxide");

			new StepsIngredients().ThenIConfirmICheckTheCheckboxInThePopupViewWithTheFollowingTextTheProductTypePestSelectionAndIngredientsListedAreAccurate_("The Product Type, Pest Selection, and Ingredients listed are accurate.");
			new StepsIngredients().ThenInThePopupViewWithTheFollowingTitleProductContainsIngredientsTypicalOfAPesticideIClickTheConfirmButton("Product Contains Ingredients Typical of a Pesticide", "Confirm");

			// 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
			sharedSteps.ICallSharedRegulatoryInformation1_TSCARandom_Pro65No_Continue();
			// 57510 \(Retailer Association - Select A Retailer - Continue - Happy Path\) and select the retailer: CVS
			sharedSteps.ICallSharedRetailer_SelectNoRetailer_ClickDone();
			// 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
			sharedSteps.GivenICallSharedRegulatoryDocumentsToProvide_USOnly_RequestAuthoring_HappyPath();
			// Click continue
			newProductSteps.ClickContinue();
			// Click continue
			newProductSteps.ClickContinue();
			// 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
			var sdsTable = new Table("Personal Protection Equipment", "Autoignition Temperature",
				"Minimum Ignition Energy", "Viscosity", "Appearance", "Odor", "Odor Threshold",
				"Partition Coefficient");
			sdsTable.AddRow("Mask", "300", "1", "20", "Black", "Odorless", "No data available", "10");
			sharedSteps
				.GivenICallSharedSafetyDataSheetAuthoring_AditionalDataStep_AddAnyRandomDataForAllFields_HappyPath(
					sdsTable);
			// 57883 (Comments - Happy Path) and enter the comment: Test Comment 75335
			sharedSteps.GivenICallSharedCommentsHappyPath("Test Comment");
			// 57885 (Data Acceptance - Click Accept - Happy Path)
			sharedSteps.GivenICallSharedDataAcceptance_ClickAccept_HappyPath();
		}

		public void CreateProductConditionerForCVSAndTakeToDataSummary(string savedAs, string name)
		{
			ReportSettings.UseSubSteps = true;
			var sharedSteps = new Steps_Shared();
			var productsGridSteps = new StepsProductGrid();
			var newProductSteps = new StepsNewProduct();
			var newProduct = new NewProduct();
			var shaSteps = new Steps_SHA();
			var thisGlobalSteps = new GlobalSteps();
			//thisGlobalSteps.NavigateToLandingPage();
			//// Log in to administrator role
			//sharedSteps.GivenICallSharedStep67823LoginToWERCSmart_ProductsAutomationAccount();
			//thisGlobalSteps.LoginToWERCSmartAdmin("WERCs Premium Subscription Account");
			// 57408 (Create a New Registration via Register New Product icon)
			productsGridSteps.GivenIGenerateARandomUPCNumberAndSaveAs("UPC75335");
			sharedSteps.GivenICallSharedStepCreateANewRegistrationViaRegisterNewProductIcon();
			// 57500 (The Product- Enter name, select product type - Continue - Happy Path)
			sharedSteps.GivenICallSharedStepTheProduct_EnterNameSelectProductType_Continue_HappyPath("Conditioner", name);
			// Save product to context
			newProductSteps.SaveProductInformation(savedAs);
			sharedSteps.SharedProductInformation_US_No_Child_OSHA_DSV_Yes_PLP_No_GNFR();
			sharedSteps.SharedPhysicalandChemicalProperties_LiquidOnlyAvailable_EnterAllData_Continue();

			sharedSteps.ICallSharedIngredients_AddAnyChemical("Sodium hydroxide");
			sharedSteps.ICallSharedRegulatoryInformation1_TSCARandom_Pro65No_Continue();
			sharedSteps.GivenICallSharedRegulatoryInformation_DrugFactsPanel_NoneOfTheAbove_Continue_HappyPath();
			sharedSteps.ICallSharedTransportationDetails1_NotRegulated();
			Report.Info("(Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: CVS");
			var retailerTable = new Table("Retailer");
			retailerTable.AddRow("CVS");
			sharedSteps.ThenICallSharedStep_Retailers_PLP_SelectOneOrMoreRetailerAndAddPLInformation_Continue(retailerTable);
			//Report.Info("(Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC75335, container type: Metal Container and size: 40");
			//sharedSteps.GivenICallSharedEnterUniversalProductCodeUPC_UPC_ContainerType_SizeOnly("75335",
			//	"Metal Container", "40");
			sharedSteps.GivenICallSharedEnterUniversalProductCodeUPC_CVSUPC_ContainerType_SizeOnly("Metal Container", "40");
			sharedSteps.GivenICallSharedRegulatoryDocumentsToProvide_USOnly_RequestAuthoring_HappyPath();
			// Click continue
			newProductSteps.ClickContinue();
			// Click continue
			newProductSteps.ClickContinue();
			// 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
			var sdsTable = new Table("Personal Protection Equipment", "Autoignition Temperature",
				"Minimum Ignition Energy", "Viscosity", "Appearance", "Odor", "Odor Threshold",
				"Partition Coefficient");
			sdsTable.AddRow("Mask", "300", "1", "20", "Black", "Odorless", "No data available", "10");
			sharedSteps
				.GivenICallSharedSafetyDataSheetAuthoring_AditionalDataStep_AddAnyRandomDataForAllFields_HappyPath(
					sdsTable);
			// 57883 (Comments - Happy Path) and enter the comment: Test Comment 75335
			sharedSteps.GivenICallSharedCommentsHappyPath("Test Comment");
			// 57885 (Data Acceptance - Click Accept - Happy Path)
			//sharedSteps.GivenICallSharedDataAcceptance_ClickAccept_HappyPath();
			//// If purchase details are showing click confirm order
			//newProductSteps.GivenIfPurchaseDetailsAreShowingClickConfirmOrder();
		}

		public void CreateProductConditionerForTargetAndTakeToDataSummary(string savedAs, string name)
		{
			ReportSettings.UseSubSteps = true;
			var sharedSteps = new Steps_Shared();
			var productsGridSteps = new StepsProductGrid();
			var newProductSteps = new StepsNewProduct();
			var newProduct = new NewProduct();
			var shaSteps = new Steps_SHA();
			var thisGlobalSteps = new GlobalSteps();
			//thisGlobalSteps.NavigateToLandingPage();
			//// Log in to administrator role
			//sharedSteps.GivenICallSharedStep67823LoginToWERCSmart_ProductsAutomationAccount();
			//thisGlobalSteps.LoginToWERCSmartAdmin("WERCs Premium Subscription Account");
			// 57408 (Create a New Registration via Register New Product icon)
			productsGridSteps.GivenIGenerateARandomUPCNumberAndSaveAs("UPC75335");
			sharedSteps.GivenICallSharedStepCreateANewRegistrationViaRegisterNewProductIcon();
			// 57500 (The Product- Enter name, select product type - Continue - Happy Path)
			sharedSteps.GivenICallSharedStepTheProduct_EnterNameSelectProductType_Continue_HappyPath("Conditioner", name);
			// Save product to context
			newProductSteps.SaveProductInformation(savedAs);
			sharedSteps.SharedProductInformation_US_No_Child_OSHA_DSV_Yes_PLP_No_GNFR();
			sharedSteps.SharedPhysicalandChemicalProperties_LiquidOnlyAvailable_EnterAllData_Continue();

			sharedSteps.ICallSharedIngredients_AddAnyChemical("Sodium hydroxide");
			sharedSteps.ICallSharedRegulatoryInformation1_TSCARandom_Pro65No_Continue();
			sharedSteps.GivenICallSharedRegulatoryInformation_DrugFactsPanel_NoneOfTheAbove_Continue_HappyPath();
			sharedSteps.ICallSharedTransportationDetails1_NotRegulated();
			Report.Info("(Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: CVS");
			var retailerTable = new Table("Retailer");
			retailerTable.AddRow("Target");
			sharedSteps.ThenICallSharedStep_Retailers_PLP_SelectOneOrMoreRetailerAndAddPLInformation_Continue(retailerTable);
			var upcTable = new Table("UPCNumber", "ContainerType", "Size", "DPCI");
			upcTable.AddRow("saved as UPC75335", "Metal Container", "40", "007-07-1234");
			newProductSteps.ThenIClickTheAddUpcButton();
			newProductSteps.ThenIAddTheFollowingIntoTheUpcFields(upcTable);
			newProductSteps.ClickContinue();
			sharedSteps.GivenICallSharedRegulatoryDocumentsToProvide_USOnly_RequestAuthoring_HappyPath();
			// Click continue
			newProductSteps.ClickContinue();
			// Click continue
			newProductSteps.ClickContinue();
			// 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
			var sdsTable = new Table("Personal Protection Equipment", "Autoignition Temperature",
				"Minimum Ignition Energy", "Viscosity", "Appearance", "Odor", "Odor Threshold",
				"Partition Coefficient");
			sdsTable.AddRow("Mask", "300", "1", "20", "Black", "Odorless", "No data available", "10");
			sharedSteps
				.GivenICallSharedSafetyDataSheetAuthoring_AditionalDataStep_AddAnyRandomDataForAllFields_HappyPath(
					sdsTable);
			// 57883 (Comments - Happy Path) and enter the comment: Test Comment 75335
			sharedSteps.GivenICallSharedCommentsHappyPath("Test Comment");
			// 57885 (Data Acceptance - Click Accept - Happy Path)
			//sharedSteps.GivenICallSharedDataAcceptance_ClickAccept_HappyPath();
			//// If purchase details are showing click confirm order
			//newProductSteps.GivenIfPurchaseDetailsAreShowingClickConfirmOrder();
		}

		public void CreateProductConditionerForCostcoAndTakeToDataSummary(string savedAs, string name)
		{
			ReportSettings.UseSubSteps = true;
			var sharedSteps = new Steps_Shared();
			var productsGridSteps = new StepsProductGrid();
			var newProductSteps = new StepsNewProduct();
			var newProduct = new NewProduct();
			var shaSteps = new Steps_SHA();
			var thisGlobalSteps = new GlobalSteps();
			//thisGlobalSteps.NavigateToLandingPage();
			//// Log in to administrator role
			//sharedSteps.GivenICallSharedStep67823LoginToWERCSmart_ProductsAutomationAccount();
			//thisGlobalSteps.LoginToWERCSmartAdmin("WERCs Premium Subscription Account");
			// 57408 (Create a New Registration via Register New Product icon)
			productsGridSteps.GivenIGenerateARandomUPCNumberAndSaveAs("UPC75335");
			sharedSteps.GivenICallSharedStepCreateANewRegistrationViaRegisterNewProductIcon();
			// 57500 (The Product- Enter name, select product type - Continue - Happy Path)
			sharedSteps.GivenICallSharedStepTheProduct_EnterNameSelectProductType_Continue_HappyPath("Conditioner", name);
			// Save product to context
			newProductSteps.SaveProductInformation(savedAs);
			sharedSteps.SharedProductInformation_US_No_Child_OSHA_DSV_Yes_PLP_No_GNFR();
			sharedSteps.SharedPhysicalandChemicalProperties_LiquidOnlyAvailable_EnterAllData_Continue();

			sharedSteps.ICallSharedIngredients_AddAnyChemical("Sodium hydroxide");
			sharedSteps.ICallSharedRegulatoryInformation1_TSCARandom_Pro65No_Continue();
			sharedSteps.GivenICallSharedRegulatoryInformation_DrugFactsPanel_NoneOfTheAbove_Continue_HappyPath();
			sharedSteps.ICallSharedTransportationDetails1_NotRegulated();
			Report.Info("(Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer:");
			var retailerTable = new Table("Retailer");
			retailerTable.AddRow("Costco");
			sharedSteps.ThenICallSharedStep_Retailers_PLP_SelectOneOrMoreRetailerAndAddPLInformation_Continue(retailerTable);
			var upcTable = new Table("UPCNumber", "ContainerType", "Size");
			upcTable.AddRow("saved as UPC75335", "Metal Container", "40");
			newProductSteps.ThenIClickTheAddUpcButton();
			newProductSteps.ThenIAddTheFollowingIntoTheUpcFields(upcTable);
			newProductSteps.ClickContinue();
			sharedSteps.GivenICallSharedRegulatoryDocumentsToProvide_USOnly_RequestAuthoring_HappyPath();
			// Click continue
			newProductSteps.ClickContinue();
			// Click continue
			newProductSteps.ClickContinue();
			// 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
			var sdsTable = new Table("Personal Protection Equipment", "Autoignition Temperature",
				"Minimum Ignition Energy", "Viscosity", "Appearance", "Odor", "Odor Threshold",
				"Partition Coefficient");
			sdsTable.AddRow("Mask", "300", "1", "20", "Black", "Odorless", "No data available", "10");
			sharedSteps
				.GivenICallSharedSafetyDataSheetAuthoring_AditionalDataStep_AddAnyRandomDataForAllFields_HappyPath(
					sdsTable);
			// 57883 (Comments - Happy Path) and enter the comment: Test Comment 75335
			sharedSteps.GivenICallSharedCommentsHappyPath("Test Comment");
			// 57885 (Data Acceptance - Click Accept - Happy Path)
			//sharedSteps.GivenICallSharedDataAcceptance_ClickAccept_HappyPath();
			//// If purchase details are showing click confirm order
			//newProductSteps.GivenIfPurchaseDetailsAreShowingClickConfirmOrder();
		}

		public void CreateProductConditionerForDollarTreeAndTakeToDataSummary(string savedAs, string name)
		{
			ReportSettings.UseSubSteps = true;
			var sharedSteps = new Steps_Shared();
			var productsGridSteps = new StepsProductGrid();
			var newProductSteps = new StepsNewProduct();
			var newProduct = new NewProduct();
			var shaSteps = new Steps_SHA();
			var thisGlobalSteps = new GlobalSteps();
			//thisGlobalSteps.NavigateToLandingPage();
			//// Log in to administrator role
			//sharedSteps.GivenICallSharedStep67823LoginToWERCSmart_ProductsAutomationAccount();
			//thisGlobalSteps.LoginToWERCSmartAdmin("WERCs Premium Subscription Account");
			// 57408 (Create a New Registration via Register New Product icon)
			productsGridSteps.GivenIGenerateARandomUPCNumberAndSaveAs("UPC75335");
			sharedSteps.GivenICallSharedStepCreateANewRegistrationViaRegisterNewProductIcon();
			// 57500 (The Product- Enter name, select product type - Continue - Happy Path)
			sharedSteps.GivenICallSharedStepTheProduct_EnterNameSelectProductType_Continue_HappyPath("Conditioner", name);
			// Save product to context
			newProductSteps.SaveProductInformation(savedAs);
			sharedSteps.SharedProductInformation_US_No_Child_OSHA_DSV_Yes_PLP_No_GNFR();
			sharedSteps.SharedPhysicalandChemicalProperties_LiquidOnlyAvailable_EnterAllData_Continue();
			sharedSteps.ICallSharedIngredients_AddAnyChemical("Sodium hydroxide");
			sharedSteps.ICallSharedRegulatoryInformation1_TSCARandom_Pro65No_Continue();
			sharedSteps.GivenICallSharedRegulatoryInformation_DrugFactsPanel_NoneOfTheAbove_Continue_HappyPath();
			sharedSteps.ICallSharedTransportationDetails1_NotRegulated();
			Report.Info("(Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer:");
			var retailerTable = new Table("Retailer");
			retailerTable.AddRow("Dollar Tree Stores, Inc. / Greenbrier International, Inc");
			sharedSteps.ThenICallSharedStep_Retailers_PLP_SelectOneOrMoreRetailerAndAddPLInformation_Continue(retailerTable);
			var upcTable = new Table("UPCNumber", "ContainerType", "Size");
			upcTable.AddRow("saved as UPC75335", "Metal Container", "40");
			newProductSteps.ThenIClickTheAddUpcButton();
			newProductSteps.ThenIAddTheFollowingIntoTheUpcFields(upcTable);
			newProductSteps.ClickContinue();
			sharedSteps.GivenICallSharedRegulatoryDocumentsToProvide_USOnly_RequestAuthoring_HappyPath();
			// Click continue
			newProductSteps.ClickContinue();
			// Click continue
			newProductSteps.ClickContinue();
			// 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
			var sdsTable = new Table("Personal Protection Equipment", "Autoignition Temperature",
				"Minimum Ignition Energy", "Viscosity", "Appearance", "Odor", "Odor Threshold",
				"Partition Coefficient");
			sdsTable.AddRow("Mask", "300", "1", "20", "Black", "Odorless", "No data available", "10");
			sharedSteps
				.GivenICallSharedSafetyDataSheetAuthoring_AditionalDataStep_AddAnyRandomDataForAllFields_HappyPath(
					sdsTable);
			// 57883 (Comments - Happy Path) and enter the comment: Test Comment 75335
			sharedSteps.GivenICallSharedCommentsHappyPath("Test Comment");
			// 57885 (Data Acceptance - Click Accept - Happy Path)
			//sharedSteps.GivenICallSharedDataAcceptance_ClickAccept_HappyPath();
			//// If purchase details are showing click confirm order
			//newProductSteps.GivenIfPurchaseDetailsAreShowingClickConfirmOrder();
		}

		public void CreateProductConditionerForFamilyDollarAndTakeToDataSummary(string savedAs, string name)
		{
			ReportSettings.UseSubSteps = true;
			var sharedSteps = new Steps_Shared();
			var productsGridSteps = new StepsProductGrid();
			var newProductSteps = new StepsNewProduct();
			var newProduct = new NewProduct();
			var shaSteps = new Steps_SHA();
			var thisGlobalSteps = new GlobalSteps();
			productsGridSteps.GivenIGenerateARandomUPCNumberAndSaveAs("UPC75335");
			sharedSteps.GivenICallSharedStepCreateANewRegistrationViaRegisterNewProductIcon();
			// 57500 (The Product- Enter name, select product type - Continue - Happy Path)
			sharedSteps.GivenICallSharedStepTheProduct_EnterNameSelectProductType_Continue_HappyPath("Conditioner", name);
			// Save product to context
			newProductSteps.SaveProductInformation(savedAs);
			sharedSteps.SharedProductInformation_US_No_Child_OSHA_DSV_Yes_PLP_No_GNFR();
			sharedSteps.SharedPhysicalandChemicalProperties_LiquidOnlyAvailable_EnterAllData_Continue();

			sharedSteps.ICallSharedIngredients_AddAnyChemical("Sodium hydroxide");
			sharedSteps.ICallSharedRegulatoryInformation1_TSCARandom_Pro65No_Continue();
			sharedSteps.GivenICallSharedRegulatoryInformation_DrugFactsPanel_NoneOfTheAbove_Continue_HappyPath();
			sharedSteps.ICallSharedTransportationDetails1_NotRegulated();
			Report.Info("(Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer:");
			var retailerTable = new Table("Retailer");
			retailerTable.AddRow("Family Dollar");
			sharedSteps.ThenICallSharedStep_Retailers_PLP_SelectOneOrMoreRetailerAndAddPLInformation_Continue(retailerTable);
			var upcTable = new Table("UPCNumber", "ContainerType", "Size");
			upcTable.AddRow("saved as UPC75335", "Metal Container", "40");
			newProductSteps.ThenIClickTheAddUpcButton();
			newProductSteps.ThenIAddTheFollowingIntoTheUpcFields(upcTable);
			newProductSteps.ClickContinue();
			sharedSteps.GivenICallSharedRegulatoryDocumentsToProvide_USOnly_RequestAuthoring_HappyPath();
			// Click continue
			newProductSteps.ClickContinue();
			// Click continue
			newProductSteps.ClickContinue();
			// 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
			var sdsTable = new Table("Personal Protection Equipment", "Autoignition Temperature",
				"Minimum Ignition Energy", "Viscosity", "Appearance", "Odor", "Odor Threshold",
				"Partition Coefficient");
			sdsTable.AddRow("Mask", "300", "1", "20", "Black", "Odorless", "No data available", "10");
			sharedSteps
				.GivenICallSharedSafetyDataSheetAuthoring_AditionalDataStep_AddAnyRandomDataForAllFields_HappyPath(
					sdsTable);
			// 57883 (Comments - Happy Path) and enter the comment: Test Comment 75335
			sharedSteps.GivenICallSharedCommentsHappyPath("Test Comment");
			// 57885 (Data Acceptance - Click Accept - Happy Path)
			//sharedSteps.GivenICallSharedDataAcceptance_ClickAccept_HappyPath();
			//// If purchase details are showing click confirm order
			//newProductSteps.GivenIfPurchaseDetailsAreShowingClickConfirmOrder();
		}

		public void CreateProductConditionerForAmazonAndTakeToDataSummary(string savedAs, string name)
		{
			ReportSettings.UseSubSteps = true;
			var sharedSteps = new Steps_Shared();
			var productsGridSteps = new StepsProductGrid();
			var newProductSteps = new StepsNewProduct();
			var newProduct = new NewProduct();
			var shaSteps = new Steps_SHA();
			var thisGlobalSteps = new GlobalSteps();
			//productsGridSteps.GivenIGenerateARandomUPCNumberAndSaveAs("UPC75335");
			this.GivenIGenerateARandomUPCNumberForAmazon("UPC75335");
			sharedSteps.GivenICallSharedStepCreateANewRegistrationViaRegisterNewProductIcon();
			// 57500 (The Product- Enter name, select product type - Continue - Happy Path)
			sharedSteps.GivenICallSharedStepTheProduct_EnterNameSelectProductType_Continue_HappyPath("Conditioner", name);
			// Save product to context
			newProductSteps.SaveProductInformation(savedAs);
			sharedSteps.SharedProductInformation_US_No_Child_OSHA_DSV_Yes_PLP_No_GNFR();
			sharedSteps.SharedPhysicalandChemicalProperties_LiquidOnlyAvailable_EnterAllData_Continue();

			sharedSteps.ICallSharedIngredients_AddAnyChemical("Sodium hydroxide");
			sharedSteps.ICallSharedRegulatoryInformation1_TSCARandom_Pro65No_Continue();
			sharedSteps.GivenICallSharedRegulatoryInformation_DrugFactsPanel_NoneOfTheAbove_Continue_HappyPath();
			sharedSteps.ICallSharedTransportationDetails1_NotRegulated();
			Report.Info("(Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer:");
			var retailerTable = new Table("Retailer");
			retailerTable.AddRow("Amazon");
			sharedSteps.ThenICallSharedStep_Retailers_PLP_SelectOneOrMoreRetailerAndAddPLInformation_Continue(retailerTable);
			var upcTable = new Table("UPCNumber", "ContainerType", "Size");
			upcTable.AddRow("saved as UPC75335", "Metal Container", "40");
			newProductSteps.ThenIClickTheAddUpcButton();
			newProductSteps.ThenIAddTheFollowingIntoTheUpcFields(upcTable);
			newProductSteps.ClickContinue();
			sharedSteps.GivenICallSharedRegulatoryDocumentsToProvide_USOnly_RequestAuthoring_HappyPath();
			// Click continue
			newProductSteps.ClickContinue();
			// Click continue
			newProductSteps.ClickContinue();
			// 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
			var sdsTable = new Table("Personal Protection Equipment", "Autoignition Temperature",
				"Minimum Ignition Energy", "Viscosity", "Appearance", "Odor", "Odor Threshold",
				"Partition Coefficient");
			sdsTable.AddRow("Mask", "300", "1", "20", "Black", "Odorless", "No data available", "10");
			sharedSteps
				.GivenICallSharedSafetyDataSheetAuthoring_AditionalDataStep_AddAnyRandomDataForAllFields_HappyPath(
					sdsTable);
			// 57883 (Comments - Happy Path) and enter the comment: Test Comment 75335
			sharedSteps.GivenICallSharedCommentsHappyPath("Test Comment");
			// 57885 (Data Acceptance - Click Accept - Happy Path)
			//sharedSteps.GivenICallSharedDataAcceptance_ClickAccept_HappyPath();
			//// If purchase details are showing click confirm order
			//newProductSteps.GivenIfPurchaseDetailsAreShowingClickConfirmOrder();
		}

		public void CreateProductConditionerForWalgreensAndTakeToDataSummary(string savedAs, string name)
		{
			ReportSettings.UseSubSteps = true;
			var sharedSteps = new Steps_Shared();
			var productsGridSteps = new StepsProductGrid();
			var newProductSteps = new StepsNewProduct();
			var newProduct = new NewProduct();
			var shaSteps = new Steps_SHA();
			var thisGlobalSteps = new GlobalSteps();
			productsGridSteps.GivenIGenerateARandomUPCNumberAndSaveAs("UPC75335");
			sharedSteps.GivenICallSharedStepCreateANewRegistrationViaRegisterNewProductIcon();
			// 57500 (The Product- Enter name, select product type - Continue - Happy Path)
			sharedSteps.GivenICallSharedStepTheProduct_EnterNameSelectProductType_Continue_HappyPath("Conditioner", name);
			// Save product to context
			newProductSteps.SaveProductInformation(savedAs);
			sharedSteps.SharedProductInformation_US_No_Child_OSHA_DSV_Yes_PLP_No_GNFR();
			sharedSteps.SharedPhysicalandChemicalProperties_LiquidOnlyAvailable_EnterAllData_Continue();

			sharedSteps.ICallSharedIngredients_AddAnyChemical("Sodium hydroxide");
			sharedSteps.ICallSharedRegulatoryInformation1_TSCARandom_Pro65No_Continue();
			sharedSteps.GivenICallSharedRegulatoryInformation_DrugFactsPanel_NoneOfTheAbove_Continue_HappyPath();
			sharedSteps.ICallSharedTransportationDetails1_NotRegulated();
			Report.Info("(Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer:");
			var retailerTable = new Table("Retailer");
			retailerTable.AddRow("Walgreens");
			sharedSteps.ThenICallSharedStep_Retailers_PLP_SelectOneOrMoreRetailerAndAddPLInformation_Continue(retailerTable);
			var upcTable = new Table("UPCNumber", "ContainerType", "Size");
			upcTable.AddRow("saved as UPC75335", "Metal Container", "40");
			newProductSteps.ThenIClickTheAddUpcButton();
			newProductSteps.ThenIAddTheFollowingIntoTheUpcFields(upcTable);
			newProductSteps.ClickContinue();
			sharedSteps.GivenICallSharedRegulatoryDocumentsToProvide_USOnly_RequestAuthoring_HappyPath();
			// Click continue
			newProductSteps.ClickContinue();
			// Click continue
			newProductSteps.ClickContinue();
			// 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
			var sdsTable = new Table("Personal Protection Equipment", "Autoignition Temperature",
				"Minimum Ignition Energy", "Viscosity", "Appearance", "Odor", "Odor Threshold",
				"Partition Coefficient");
			sdsTable.AddRow("Mask", "300", "1", "20", "Black", "Odorless", "No data available", "10");
			sharedSteps
				.GivenICallSharedSafetyDataSheetAuthoring_AditionalDataStep_AddAnyRandomDataForAllFields_HappyPath(
					sdsTable);
			// 57883 (Comments - Happy Path) and enter the comment: Test Comment 75335
			sharedSteps.GivenICallSharedCommentsHappyPath("Test Comment");
			// 57885 (Data Acceptance - Click Accept - Happy Path)
			//sharedSteps.GivenICallSharedDataAcceptance_ClickAccept_HappyPath();
			//// If purchase details are showing click confirm order
			//newProductSteps.GivenIfPurchaseDetailsAreShowingClickConfirmOrder();
		}

		public void CreateProductConditionerForRiteAidAndTakeToDataSummary(string savedAs, string name)
		{
			ReportSettings.UseSubSteps = true;
			var sharedSteps = new Steps_Shared();
			var productsGridSteps = new StepsProductGrid();
			var newProductSteps = new StepsNewProduct();
			var newProduct = new NewProduct();
			var shaSteps = new Steps_SHA();
			var thisGlobalSteps = new GlobalSteps();
			productsGridSteps.GivenIGenerateARandomUPCNumberAndSaveAs("UPC75335");
			sharedSteps.GivenICallSharedStepCreateANewRegistrationViaRegisterNewProductIcon();
			// 57500 (The Product- Enter name, select product type - Continue - Happy Path)
			sharedSteps.GivenICallSharedStepTheProduct_EnterNameSelectProductType_Continue_HappyPath("Conditioner", name);
			// Save product to context
			newProductSteps.SaveProductInformation(savedAs);
			sharedSteps.SharedProductInformation_US_No_Child_OSHA_DSV_Yes_PLP_No_GNFR();
			sharedSteps.SharedPhysicalandChemicalProperties_LiquidOnlyAvailable_EnterAllData_Continue();

			sharedSteps.ICallSharedIngredients_AddAnyChemical("Sodium hydroxide");
			sharedSteps.ICallSharedRegulatoryInformation1_TSCARandom_Pro65No_Continue();
			sharedSteps.GivenICallSharedRegulatoryInformation_DrugFactsPanel_NoneOfTheAbove_Continue_HappyPath();
			sharedSteps.ICallSharedTransportationDetails1_NotRegulated();
			Report.Info("(Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer:");
			var retailerTable = new Table("Retailer");
			retailerTable.AddRow("Rite Aid");
			sharedSteps.ThenICallSharedStep_Retailers_PLP_SelectOneOrMoreRetailerAndAddPLInformation_Continue(retailerTable);
			var upcTable = new Table("UPCNumber", "ContainerType", "Size");
			upcTable.AddRow("saved as UPC75335", "Metal Container", "40");
			newProductSteps.ThenIClickTheAddUpcButton();
			newProductSteps.ThenIAddTheFollowingIntoTheUpcFields(upcTable);
			newProductSteps.ClickContinue();
			sharedSteps.GivenICallSharedRegulatoryDocumentsToProvide_USOnly_RequestAuthoring_HappyPath();
			// Click continue
			newProductSteps.ClickContinue();
			// Click continue
			newProductSteps.ClickContinue();
			// 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
			var sdsTable = new Table("Personal Protection Equipment", "Autoignition Temperature",
				"Minimum Ignition Energy", "Viscosity", "Appearance", "Odor", "Odor Threshold",
				"Partition Coefficient");
			sdsTable.AddRow("Mask", "300", "1", "20", "Black", "Odorless", "No data available", "10");
			sharedSteps
				.GivenICallSharedSafetyDataSheetAuthoring_AditionalDataStep_AddAnyRandomDataForAllFields_HappyPath(
					sdsTable);
			// 57883 (Comments - Happy Path) and enter the comment: Test Comment 75335
			sharedSteps.GivenICallSharedCommentsHappyPath("Test Comment");
			// 57885 (Data Acceptance - Click Accept - Happy Path)
			//sharedSteps.GivenICallSharedDataAcceptance_ClickAccept_HappyPath();
			//// If purchase details are showing click confirm order
			//newProductSteps.GivenIfPurchaseDetailsAreShowingClickConfirmOrder();
		}

		[StepDefinition("I Use Test case 75142 to create a NEW PRODUCT and get it to Submitted status in SHA")]
		public void IUseTestCase75142ToCreateANEWPRODUCTAndGetItToSubmittedStatusInSHA()
		{
			ReportSettings.UseSubSteps = true;

			var globalSteps = new GlobalSteps();
			var sharedSteps = new Steps_Shared();
			var stepsProductGrid = new StepsProductGrid();
			var stepsNewProduct = new StepsNewProduct();
			var stepsSHA = new Steps_SHA();



			Report.StartStep("I login into the WERCSmart Portal - Administrator Role");
			globalSteps.LoginToWERCSmart("Administrator Role");
			Report.StartStep("I generate a random UPC number and save as: UPC75142");
			stepsProductGrid.GivenIGenerateARandomUPCNumberAndSaveAs("UPC75142");
			Report.StartStep("I delete all products with UPC Number: saved as UPC75142");
			stepsProductGrid.DeleteAllProductsMatchingCriteria("UPC Number", "saved as UPC75142");
			Report.StartStep("I call Shared Step 57408 (Create a New Registration via Register New Product icon)");
			sharedSteps.GivenICallSharedStepCreateANewRegistrationViaRegisterNewProductIcon();
			Report.StartStep("I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk");
			sharedSteps.GivenICallSharedStepTheProduct_EnterNameSelectProductType_Continue_HappyPath("Chalk");
			Report.StartStep("I save the product information as: TestCase75142");
			stepsNewProduct.SaveProductInformation("TestCase75142");
			Report.StartStep("I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)");
			sharedSteps.ICallSharedProductInformationUSOnlyNoChildNoGHSNoDirectShipNoPLPNoGNFR();
			Report.StartStep("I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)");
			sharedSteps.SharedPhysicalandChemicalProperties_SolidOnlyAvailable_Continue();
			
			Report.StartStep("I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide");
			sharedSteps.ICallSharedIngredients_AddAnyChemical("Sodium hydroxide");
			Report.StartStep("I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)");
			sharedSteps.ICallSharedRegulatoryInformation1_TSCARandom_Pro65No_Continue();
			Report.StartStep("I call Shared Step 75146");

			Table retailerTable = new Table("Retailer");
			retailerTable.AddRow("CVS");

			sharedSteps.GivenICallSharedStep75146Retailer_SelectOneOrMoreRetailersThatDoNotRequireVendorIDOrAdditionalUPCInformationClickDoneClickContinue(retailerTable);
			Report.StartStep("I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC75142, container type: Metal Container and size: 40");
			sharedSteps.GivenICallSharedEnterUniversalProductCodeUPC_UPC_ContainerType_SizeOnly("75142", "Metal Container", "40");



			Report.StartStep("I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)");
			sharedSteps.GivenICallSharedRegulatoryDocumentsToProvide_USOnly_RequestAuthoring_HappyPath();
			Report.StartStep("in the Additional Documents to Provide page I click Continue");
			stepsNewProduct.GivenInTheNewProductPageIClickContinue("Additional Documents to Provide");
			Report.StartStep("in the Optional Reports and Documents Available for Purchase page I click Continue");
			stepsNewProduct.GivenInTheNewProductPageIClickContinue("Optional Reports and Documents Available for Purchase");
			Report.StartStep("I call Shared Step 57884");

			Table additionalData = new Table("Personal Protection Equipment", "Autoignition Temperature", "Minimum Ignition Energy", "Viscosity", "Appearance", "Odor", "Odor Threshold", "Partition Coefficient");
			additionalData.AddRow("Mask", "300", "1.005", "20", "Black", "Odorless", "No data available", "10");
			sharedSteps.GivenICallSharedSafetyDataSheetAuthoring_AditionalDataStep_AddAnyRandomDataForAllFields_HappyPath(additionalData);
			Report.StartStep("I call Shared Step 57883");
			sharedSteps.GivenICallSharedCommentsHappyPath(@"User added Comments Text 57863. !""�$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.");
			Report.StartStep("I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)");
			sharedSteps.GivenICallSharedDataAcceptance_ClickAccept_HappyPath();
			Report.StartStep("If purchase details are showing click confirm order");
			stepsNewProduct.GivenIfPurchaseDetailsAreShowingClickConfirmOrder();
			Report.StartStep("I call Shared Step 65080 (Login to Studio and Open SHA manager)");
			sharedSteps.GivenICallShared65080LoginToStudioAndOpenSHAManager();
			Report.StartStep("I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase75142)");
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", "TestCase75142");
			Report.StartStep("In the SHA manager grid I see the WPS ID I have saved as product: TestCase75142 and its status is: Submitted");
			stepsSHA.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs("TestCase75142", "Submitted");



		}

		[StepDefinition("I Use Test case 75142 to create a NEW PRODUCT and get it to Submitted status in SHA for the Products Automation Account")]
		public void IUseTestCase75142ToCreateANEWPRODUCTAndGetItToSubmittedStatusInSHAForProductsAutomationAccount()
		{
			ReportSettings.UseSubSteps = true;

			var globalSteps = new GlobalSteps();
			var sharedSteps = new Steps_Shared();
			var stepsProductGrid = new StepsProductGrid();
			var stepsNewProduct = new StepsNewProduct();
			var stepsSHA = new Steps_SHA();



			Report.StartStep("I login into the WERCSmart Portal - ProductAccount");
			globalSteps.LoginToWERCSmart("ProductAccount");
			Report.StartStep("I generate a random UPC number and save as: UPC75142");
			stepsProductGrid.GivenIGenerateARandomUPCNumberAndSaveAs("UPC75142");
			Report.StartStep("I delete all products with UPC Number: saved as UPC75142");
			stepsProductGrid.DeleteAllProductsMatchingCriteria("UPC Number", "saved as UPC75142");
			Report.StartStep("I call Shared Step 57408 (Create a New Registration via Register New Product icon)");
			sharedSteps.GivenICallSharedStepCreateANewRegistrationViaRegisterNewProductIcon();
			Report.StartStep("I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk");
			sharedSteps.GivenICallSharedStepTheProduct_EnterNameSelectProductType_Continue_HappyPath("Chalk");
			Report.StartStep("I save the product information as: TestCase75142");
			stepsNewProduct.SaveProductInformation("TestCase75142");
			Report.StartStep("I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)");
			sharedSteps.ICallSharedProductInformationUSOnlyNoChildNoGHSNoDirectShipNoPLPNoGNFR();
			Report.StartStep("I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)");
			sharedSteps.SharedPhysicalandChemicalProperties_SolidOnlyAvailable_Continue();
			
			Report.StartStep("I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide");
			sharedSteps.ICallSharedIngredients_AddAnyChemical("Sodium hydroxide");
			Report.StartStep("I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)");
			sharedSteps.ICallSharedRegulatoryInformation1_TSCARandom_Pro65No_Continue();
			Report.StartStep("I call Shared Step 75146");

			Table retailerTable = new Table("Retailer");
			retailerTable.AddRow("CVS");

			sharedSteps.GivenICallSharedStep75146Retailer_SelectOneOrMoreRetailersThatDoNotRequireVendorIDOrAdditionalUPCInformationClickDoneClickContinue(retailerTable);
			Report.StartStep("I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC75142, container type: Metal Container and size: 40");
			sharedSteps.GivenICallSharedEnterUniversalProductCodeUPC_UPC_ContainerType_SizeOnly("75142", "Metal Container", "40");



			Report.StartStep("I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)");
			sharedSteps.GivenICallSharedRegulatoryDocumentsToProvide_USOnly_RequestAuthoring_HappyPath();
			Report.StartStep("in the Additional Documents to Provide page I click Continue");
			stepsNewProduct.GivenInTheNewProductPageIClickContinue("Additional Documents to Provide");
			Report.StartStep("in the Optional Reports and Documents Available for Purchase page I click Continue");
			stepsNewProduct.GivenInTheNewProductPageIClickContinue("Optional Reports and Documents Available for Purchase");
			Report.StartStep("I call Shared Step 57884");

			Table additionalData = new Table("Personal Protection Equipment", "Autoignition Temperature", "Minimum Ignition Energy", "Viscosity", "Appearance", "Odor", "Odor Threshold", "Partition Coefficient");
			additionalData.AddRow("Mask", "300", "1.005", "20", "Black", "Odorless", "No data available", "10");
			sharedSteps.GivenICallSharedSafetyDataSheetAuthoring_AditionalDataStep_AddAnyRandomDataForAllFields_HappyPath(additionalData);
			Report.StartStep("I call Shared Step 57883");
			sharedSteps.GivenICallSharedCommentsHappyPath(@"User added Comments Text 57863. !""�$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.");
			Report.StartStep("I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)");
			sharedSteps.GivenICallSharedDataAcceptance_ClickAccept_HappyPath();
			Report.StartStep("If purchase details are showing click confirm order");
			stepsNewProduct.GivenIfPurchaseDetailsAreShowingClickConfirmOrder();
			Report.StartStep("I call Shared Step 65080 (Login to Studio and Open SHA manager)");
			sharedSteps.GivenICallShared65080LoginToStudioAndOpenSHAManager();
			Report.StartStep("I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase75142)");
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", "TestCase75142");
			Report.StartStep("In the SHA manager grid I see the WPS ID I have saved as product: TestCase75142 and its status is: Submitted");
			stepsSHA.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs("TestCase75142", "Submitted");



		}


		public void TaketoProductTypeandSave(string name, string savedAs)
		{
			ReportSettings.UseSubSteps = true;
			var sharedSteps = new Steps_Shared();
			var productsGridSteps = new StepsProductGrid();
			var newProductSteps = new StepsNewProduct();
			var newProduct = new NewProduct();
			var shaSteps = new Steps_SHA();
			var thisGlobalSteps = new GlobalSteps();
			sharedSteps.GivenICallSharedStepCreateANewRegistrationViaRegisterNewProductIcon();
			sharedSteps.GivenICallSharedStepTheProduct_EnterNameSelectProductType_Continue_HappyPath("Chalk", name);
			newProductSteps.SaveProductInformation(savedAs);
		}


		[StepDefinition(@"I create a product with sds upload and name as: (.*) then take to data acceptance and save as: (.*)")]
		public void TakeProductWithSDSUploadToDataAcceptance(string name, string savedAs)
		{
			ReportSettings.UseSubSteps = true;
			var sharedSteps = new Steps_Shared();
			var productsGridSteps = new StepsProductGrid();
			var newProductSteps = new StepsNewProduct();
			var newProduct = new NewProduct();
			var shaSteps = new Steps_SHA();
			var thisGlobalSteps = new GlobalSteps();
			sharedSteps.GivenICallSharedStepCreateANewRegistrationViaRegisterNewProductIcon();
			sharedSteps.GivenICallSharedStepTheProduct_EnterNameSelectProductType_Continue_HappyPath("Chalk", name);
			newProductSteps.SaveProductInformation(savedAs);

			//Philip - Change
			sharedSteps.ICallSharedProductInformationUSOnlyNoChildNoGHSNoDirectShipNoPLPNoGNFR();
			sharedSteps.SharedPhysicalandChemicalProperties_SolidOnlyAvailable_Continue();
			//

			sharedSteps.ICallSharedIngredients_AddAnyChemical("Sodium hydroxide");
			sharedSteps.ICallSharedRegulatoryInformation1_TSCARandom_Pro65No_Continue();
			sharedSteps.ICallSharedRetailer_SelectNoRetailer_ClickDone();
			newProductSteps.SetTheSectionOptionTo("OSHA-compliant Safety Data Sheet, English",
				"Yes, I certify that I have an OSHA-compliant SDS for this product and would like to upload it.");
			newProductSteps.UploadPDFFile("OSHA SDS", @"C:\Dependencies\WERCSmart\testdoc.pdf");
			//newProductSteps.ICheckTheCheckboxWithDescription("check","I confirm that I have provided the most up-to-date, OSHA-compliant SDS in this product registration.");
			newProductSteps.ICheckTheCheckboxWithDescription("check", "I confirm I am providing the most current Safety Data Sheet");
			newProductSteps.ClickContinue();
			newProductSteps.ClickContinue();
			newProductSteps.ClickContinue();
			newProductSteps.ClickContinue();

		}

		[StepDefinition(@"I Use Test case 87685 to create a product which has a Case UPC and a regular UPC, processed to completed status")]
		public void IUseTestCase87685ToCreateAProductWhichHasACaseUPCAndARegularUPCProcessedToCompletedStatus()
		{
			ReportSettings.UseSubSteps = true;

			var globalSteps = new GlobalSteps();
			var sharedSteps = new Steps_Shared();
			var stepsProductGrid = new StepsProductGrid();
			var stepsNewProduct = new StepsNewProduct();
			var stepsSHA = new Steps_SHA();
			var stepsSharedUPC = new StepsUPC();

			Report.StartStep("I log in with the account saved in TReVor as: PremiumSubscriptionAccount");
			globalSteps.ILogInWithTheAccountSavedInTrevorAs("PremiumSubscriptionAccount");
			Report.StartStep("I generate a random UPC number and save as: UPC87685");
			stepsProductGrid.GivenIGenerateARandomUPCNumberAndSaveAs("UPC87685");
			Delay.Seconds(2);
			Report.StartStep("I generate a random UPC number and save as: UPC876851");
			stepsProductGrid.GivenIGenerateARandomUPCNumberAndSaveAs("UPC876851");
			Report.StartStep("I call Shared Step 57408 (Create a New Registration via Register New Product icon)");
			sharedSteps.GivenICallSharedStepCreateANewRegistrationViaRegisterNewProductIcon();
			Report.StartStep("I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk");
			sharedSteps.GivenICallSharedStepTheProduct_EnterNameSelectProductType_Continue_HappyPath("Chalk");

			Report.StartStep("I save the product Information as: TestCase87685");
			stepsNewProduct.SaveProductInformation("TestCase87685");
			Report.StartStep("I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)");
			sharedSteps.ICallSharedProductInformationUSOnlyNoChildNoGHSNoDirectShipNoPLPNoGNFR();
			Report.StartStep("I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)");
			sharedSteps.SharedPhysicalandChemicalProperties_SolidOnlyAvailable_Continue();
			
			Report.StartStep("I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide");
			sharedSteps.ICallSharedIngredients_AddAnyChemical("Sodium hydroxide");
			Report.StartStep("Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)");
			sharedSteps.ICallSharedRegulatoryInformation1_TSCARandom_Pro65No_Continue();
			Report.StartStep("I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue) for");

			var retailerTable = new TechTalk.SpecFlow.Table("Retailer");
			retailerTable.AddRow("Amazon");

			sharedSteps.GivenICallSharedStep75146Retailer_SelectOneOrMoreRetailersThatDoNotRequireVendorIDOrAdditionalUPCInformationClickDoneClickContinue(retailerTable);
			Report.StartStep("I call Shared Step 87647 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC87685, container type: Paper bag and size: 2 do not click continue");
			stepsSharedUPC.EnterUPCInfoDoNotClickContinue("87685", "Paper bag", "2");

			//Report.StartStep("I call Shared Step 87641(Enter Universal Product Code - case information) for UPC: saved as UPC876851, container type: Paper bag and size: 2 and Quantity: 4 and Transportation option: 4A: steel box");
			//stepsSharedUPC.UPCCaseInformation("876851", "Paper bag", "2", "4", "4A: steel box");

			Report.StartStep("I call Shared Step 87829 (UPC - Add Case UPC - All Data > Continue) for UPC: saved as UPC (.*), container type: (.*) and size: (.*) and Quantity: (.*) and Individual Upc Case Pack saved As: (.*) and Transportation option: (.*)");
			stepsSharedUPC.UPCCaseAddInformation("876851", "Paper bag", "2", "4", "UPC87685", "4A: steel box");


			Report.StartStep("I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)");
			sharedSteps.GivenICallSharedRegulatoryDocumentsToProvide_USOnly_RequestAuthoring_HappyPath();
			Report.StartStep("in the Additional Documents to Provide page I click Continue");
			stepsNewProduct.GivenInTheNewProductPageIClickContinue(" Additional Documents to Provide");
			Report.StartStep("in the Optional Reports and Documents Available for Purchase page I click Continue");
			stepsNewProduct.GivenInTheNewProductPageIClickContinue("Optional Reports and Documents Available for Purchase");

			Report.StartStep("I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:");

			var additionalData = new Table("Personal Protection Equipment", "Autoignition Temperature", "Minimum Ignition Energy", "Viscosity", "Appearance", "Odor", "Odor Threshold", "Partition Coefficient");
			additionalData.AddRow("Mask", "300", "1.005", "20", "Black", "Odorless", "No data available", "10");

			sharedSteps.GivenICallSharedSafetyDataSheetAuthoring_AditionalDataStep_AddAnyRandomDataForAllFields_HappyPath(additionalData);
			Report.StartStep("I call Shared Step 57883");
			sharedSteps.GivenICallSharedCommentsHappyPath(@"User added Comments Text 57863. !""�$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.");
			Report.StartStep("I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)");
			sharedSteps.GivenICallSharedDataAcceptance_ClickAccept_HappyPath();
			Report.StartStep("If purchase details are showing click confirm order");
			stepsNewProduct.GivenIfPurchaseDetailsAreShowingClickConfirmOrder();
			Report.StartStep("I call Shared Step 65080 (Login to Studio and Open SHA manager)");
			sharedSteps.GivenICallShared65080LoginToStudioAndOpenSHAManager();
			Report.StartStep("I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase87685)");
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", "TestCase87685");
			Report.StartStep("In the SHA manager grid I see the WPS ID I have saved as product: TestCase87685 and its status is: Submitted");
			stepsSHA.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs("TestCase87685", "Submitted");
			Report.StartStep("I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase87685)");
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", "TestCase87685");
			Report.StartStep("I call Shared Step 75309 (SHA > Select Product > UPC Retailer and Feed) for product saved as: TestCase87685");
			sharedSteps.Shared75309_SHA_SelectProduct_UpcList("TestCase87685");
			Report.StartStep("In the list of UPCs I should not see case pack indicatior for UPC: saved as UPC87685");
			stepsSHA.ConfirmCaseUpc("not see", "saved as UPC87685");
			Report.StartStep("I wait 10 seconds");
			Delay.Seconds(10);
			Report.StartStep("In the list of UPCs I should see case pack indicatior for UPC: saved as UPC876851");
			stepsSHA.ConfirmCaseUpc("see", "saved as UPC876851");
			Report.StartStep("I close the window saved as: SHAManagerProductUPC");
			globalSteps.SwitchBackToMainWindow("SHAManagerProductUPC");
			Report.StartStep("I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase87685)");
			sharedSteps.GivenICallSharedSHAManager_Submitted_SelectProductProcessProductData("TestCase87685");
			Report.StartStep("I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase87685)");
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", "TestCase87685");
			Report.StartStep("In the SHA manager grid I see the WPS ID I have saved as product: TestCase87685 and its status is: Assigned");
			stepsSHA.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs("TestCase87685", "Assigned");
			Report.StartStep("I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase87685)");
			sharedSteps.GivenICallSharedWPSStudio_JobQueue_WaitForImportProcessRulesJobToComplete("TestCase87685");
			Report.StartStep("I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase87685)");
			sharedSteps.GivenICallSharedWPSStudio_OpenPDEditExistingWithSpecificProductClickContinue("TestCase87685");
			Report.StartStep("I call Shared Step 75347 (WPS Studio - PD+ - set all data and publish using rule and Doc queue - CKLT, NGHS and SBCS) for product saved as: TestCase87685");
			sharedSteps.GivenICallSharedWPSStudio_PD_SetAllDataAndPublishUsingRuleAndDocQueue_CKLTNGHSAndSBCS("TestCase87685");
			Report.StartStep("I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase87685)");
			sharedSteps.GivenICallShared55663WPSStudio_GoToJobQueue_WaitForPublishMultipleToComplete("TestCase87685");
			Report.StartStep("I call Shared Step 59066 (Go to SHA Manager)");
			sharedSteps.GivenICallSharedStep59066GoToSHAManager();
			Report.StartStep("I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase87685)");
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", "TestCase87685");
			Report.StartStep("In the SHA manager grid I see the WPS ID I have saved as product: TestCase87685 and its status is: Accepted");
			stepsSHA.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs("TestCase87685", "Accepted");
			Report.StartStep("I call Shared Step 49841 (SHA - Search for exact WPS ID in Accepted Status for saved as: TestCase87685)");
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("Accepted", "TestCase87685");
			Report.StartStep("I call Shared Step 51664 (SHA - Accepted Product - set Retailers to Completed for saved as: TestCase87685) for");

			var retailerTable2 = new TechTalk.SpecFlow.Table("Retailer");
			retailerTable2.AddRow("Amazon");

			sharedSteps.GivenICallShared51664SHA_AcceptedProduct_SetRetailersToCompletedForSavedAs("TestCase87685", retailerTable2);
			Report.StartStep("I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase87685)");
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", "TestCase87685");
			Report.StartStep("In the SHA manager grid I see the WPS ID I have saved as product: TestCase87685 and its status is: Completed");
			stepsSHA.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs("TestCase87685", "Completed");

		}



		[StepDefinition(@"I create a Crayon product and take to completed using Test Case 86116 and save as: (.*) with upc: (.*)")]
		public void CreateProductUsingTestCase86116(string savedAs, string upc)
		{
			ReportSettings.UseSubSteps = true;
			var sharedSteps = new Steps_Shared();
			var productsGridSteps = new StepsProductGrid();
			var newProductSteps = new StepsNewProduct();
			var newProduct = new NewProduct();
			var shaSteps = new Steps_SHA();
			var thisGlobalSteps = new GlobalSteps();
			//productsGridSteps.GivenIGenerateARandomUPCNumberAndSaveAs("UPC86116");
			sharedSteps.GivenICallSharedStepCreateANewRegistrationViaRegisterNewProductIcon();
			sharedSteps.GivenICallSharedStepTheProduct_EnterProductNameAndSelectTypeOfProduct("Crayon");
			newProductSteps.SaveProductInformation(savedAs);


			//Philip - Change
			sharedSteps.ThenICallSharedStep85730ProductInformation_CanadaOnly_ChildNOGHSNODSVNOPLPYESGNFRNOContinue();
			sharedSteps.SharedPhysicalandChemicalProperties_SolidOnlyAvailable_Continue();
			//


			sharedSteps.ICallSharedIngredients_AddAnyChemical("Sodium hydroxide");
			sharedSteps.GivenICallSharedStepRegulatoryInformation_CEPAOnlyShown_Continue_HappyPath();
			var retailerTable = new Table("Retailer");
			retailerTable.AddRow("Canadian Tire");
			sharedSteps.ThenICallSharedStep_Retailers_PLP_SelectOneOrMoreRetailerAndAddPLInformation_Continue(retailerTable);
			sharedSteps.ThenICallSharedStep75702_UPC_AddUPCContainerTypeSizeAndPackageTypeNoRetailerDataNeeded_Continue("saved as " + upc, "Metal Container", "5");
			sharedSteps.ThenICallSharedStep78884RegulatoryDocumentsToProvide_CanadaOnly_RequestAuthoringUploadLabel_Continue();
			newProductSteps.GivenInTheNewProductPageIClickContinue("Additional Documents to Provide");
			newProductSteps.GivenInTheNewProductPageIClickContinue("Optional Reports and Documents Available for Purchase");
			sharedSteps.GivenICallSharedStep64097_AdditionalDocuments_ContactInformation_AddAnyNameAddressPhoneAndEmergencyPhone_HappyPath();
			var sdsTable = new Table("Personal Protection Equipment", "Autoignition Temperature",
				"Minimum Ignition Energy", "Viscosity", "Appearance", "Odor", "Odor Threshold",
				"Partition Coefficient");
			sdsTable.AddRow("Mask", "300", "1", "20", "Black", "Odorless", "No data available", "10");
			sharedSteps
				.GivenICallSharedSafetyDataSheetAuthoring_AditionalDataStep_AddAnyRandomDataForAllFields_HappyPath(
					sdsTable);
			sharedSteps.GivenICallSharedCommentsHappyPath("Test Comment 86116");
			sharedSteps.GivenICallSharedDataAcceptance_ClickAccept_HappyPath();
			newProductSteps.GivenIfPurchaseDetailsAreShowingClickConfirmOrder();
			sharedSteps.GivenICallShared65080LoginToStudioAndOpenSHAManager();
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(savedAs,
				"Submitted");
			sharedSteps.GivenICallSharedSHAManager_Submitted_SelectProductProcessProductData(savedAs);
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(savedAs,
				"Assigned");
			sharedSteps.GivenICallSharedWPSStudio_JobQueue_WaitForImportProcessRulesJobToComplete(savedAs);
			sharedSteps.GivenICallSharedWPSStudio_OpenPDEditExistingWithSpecificProductClickContinue(savedAs);
			sharedSteps.GivenICallSharedWPSStudio_PD_SetAllDataAndPublishUsingRuleAndDocQueue_CKLTNGHSAndSBCS(savedAs);
			sharedSteps.GivenICallShared55663WPSStudio_GoToJobQueue_WaitForPublishMultipleToComplete(savedAs);
			sharedSteps.GivenICallSharedStep59066GoToSHAManager();
			//sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			//shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(savedAs,
			//	"Accepted");
			//sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("Accepted", savedAs);
			//sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			//var table4 = new Table(new string[] {
			//	"Retailer"
			//});
			//table4.AddRow(new string[] {
			//	"CVS"
			//});
			//sharedSteps.GivenICallShared51664SHA_AcceptedProduct_SetRetailersToCompletedForSavedAs(savedAs, table4);
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			shaSteps.InTheSHAMangerGridIFindProductAndEnsureIsCompletedIfAccepted(savedAs, retailerTable);

			
			//var ProductDetails = (ProductInformation)Context.GetFromContext(savedAs);
			//string ID = ProductDetails.Id;
			//var myStudioShaManager = new StudioSHAManager();

			//myStudioShaManager.ClickBottomMenuOption("Search");

			//var myStepsSha = new Steps_SHA();
			//string status = "Completed";
			//var table = new Table(new string[] {
			//	"SearchTerm",
			//	"SearchValue"
			//});
			//table.AddRow(new string[] {
			//	"ProductID",
			//	ID
			//});
			//table.AddRow(new string[] {
			//	"Status",
			//	status
			//});
			//myStepsSha.GivenInSHAManagerPageIRunSearch(table);

			//Delay.Seconds(2);
			//var mySHAManager = new StudioSHAManager();
			//mySHAManager.WaitForProductList(10);
			//Product topProduct = new StudioSHAManager().GetTopXProducts(1).FirstOrDefault();

			//if (topProduct == null || !(topProduct.Status == status && topProduct.ID == ID))
			//{
			//	Report.Failure("Failed to create product and process through to completed.");
			//}
		}

		[StepDefinition(@"I create a Crayon product and take to completed using Test Case 86454 and save as: (.*)")]
		public void CreateProductUsingTestCase86454(string savedAs)
		{
			ReportSettings.UseSubSteps = true;
			var sharedSteps = new Steps_Shared();
			var productsGridSteps = new StepsProductGrid();
			var newProductSteps = new StepsNewProduct();
			var newProduct = new NewProduct();
			var shaSteps = new Steps_SHA();
			var thisGlobalSteps = new GlobalSteps();
			sharedSteps.GivenICallSharedStepCreateANewRegistrationViaRegisterNewProductIcon();
			sharedSteps.GivenICallSharedStepTheProduct_EnterProductNameAndSelectTypeOfProduct("Crayon");
			newProductSteps.SaveProductInformation(savedAs);



			//Philip - Change
			sharedSteps.ThenICallSharedStep78879ProductInformation_CanadaOnly_ChildNOGHSNODSVNOPLPNOGNFRNOContinue();
			sharedSteps.SharedPhysicalandChemicalProperties_SolidOnlyAvailable_Continue();
			//sharedSteps.SharedPhysicalandChemicalProperties_SolidOnlyAvailable_Continue();
			//sharedSteps.ThenICallSharedStep78879ProductInformation_CanadaOnly_ChildNOGHSNODSVNOPLPNOGNFRNOContinue();
			//


			sharedSteps.ICallSharedIngredients_AddAnyChemical("Sodium hydroxide");
			sharedSteps.GivenICallSharedStepRegulatoryInformation_CEPAOnlyShown_Continue_HappyPath();
			sharedSteps.GivenICallSharedRetailerAssociation_SelectARetailer_Continue_HappyPath("Canadian Tire");
			var retailerTable = new Table("Retailer");
			retailerTable.AddRow("Canadian Tire");
			sharedSteps.ThenICallSharedStep75702_UPC_AddUPCContainerTypeSizeAndPackageTypeNoRetailerDataNeeded_Continue("saved as UPC86258", "Metal Container", "5");
			sharedSteps.ThenICallSharedStep78884RegulatoryDocumentsToProvide_CanadaOnly_RequestAuthoringUploadLabel_Continue();
			newProductSteps.GivenInTheNewProductPageIClickContinue("Additional Documents to Provide");
			newProductSteps.GivenInTheNewProductPageIClickContinue("Optional Reports and Documents Available for Purchase");
			sharedSteps.GivenICallSharedStep64097_AdditionalDocuments_ContactInformation_AddAnyNameAddressPhoneAndEmergencyPhone_HappyPath();
			var sdsTable = new Table("Personal Protection Equipment", "Autoignition Temperature",
				"Minimum Ignition Energy", "Viscosity", "Appearance", "Odor", "Odor Threshold",
				"Partition Coefficient");
			sdsTable.AddRow("Mask", "300", "1", "20", "Black", "Odorless", "No data available", "10");
			sharedSteps
				.GivenICallSharedSafetyDataSheetAuthoring_AditionalDataStep_AddAnyRandomDataForAllFields_HappyPath(
					sdsTable);
			sharedSteps.GivenICallSharedCommentsHappyPath("Test Comment");
			sharedSteps.GivenICallSharedDataAcceptance_ClickAccept_HappyPath();
			newProductSteps.GivenIfPurchaseDetailsAreShowingClickConfirmOrder();
			sharedSteps.GivenICallShared65080LoginToStudioAndOpenSHAManager();
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(savedAs,
				"Submitted");
			sharedSteps.GivenICallSharedSHAManager_Submitted_SelectProductProcessProductData(savedAs);
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(savedAs,
				"Assigned");
			sharedSteps.GivenICallSharedWPSStudio_JobQueue_WaitForImportProcessRulesJobToComplete(savedAs);
			sharedSteps.GivenICallSharedWPSStudio_OpenPDEditExistingWithSpecificProductClickContinue(savedAs);
			sharedSteps.GivenICallSharedWPSStudio_PD_SetAllDataAndPublishUsingRuleAndDocQueue_CKLTNGHSAndSBCS(savedAs);
			sharedSteps.GivenICallShared55663WPSStudio_GoToJobQueue_WaitForPublishMultipleToComplete(savedAs);
			sharedSteps.GivenICallSharedStep59066GoToSHAManager();
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			
			shaSteps.InTheSHAMangerGridIFindProductAndEnsureIsCompletedIfAccepted(savedAs, retailerTable);			
		}

		[StepDefinition(@"I create a Chalk product and take to completed using Test Case 86114 and save as: (.*)")]
		public void CreateProductUsingTestCase86114(string savedAs)
		{
			ReportSettings.UseSubSteps = true;
			var sharedSteps = new Steps_Shared();
			var productsGridSteps = new StepsProductGrid();
			var newProductSteps = new StepsNewProduct();
			var newProduct = new NewProduct();
			var shaSteps = new Steps_SHA();
			var thisGlobalSteps = new GlobalSteps();
			sharedSteps.GivenICallSharedStepCreateANewRegistrationViaRegisterNewProductIcon();
			sharedSteps.GivenICallSharedStepTheProduct_EnterProductNameAndSelectTypeOfProduct("Chalk");
			newProductSteps.SaveProductInformation(savedAs);
			sharedSteps.SharedPhysicalandChemicalProperties_SolidOnlyAvailable_Continue();
			sharedSteps.ThenICallSharedStep85284_ProductInformation_USCanadaChildNoOSHANoDSVNoPLPYESGNFRNoContinue();
			sharedSteps.ICallSharedIngredients_AddAnyChemical("Sodium hydroxide");
			sharedSteps.ICallSharedRegulatoryInformation1_TSCAAndCEPAShown_NoToProp65();
			sharedSteps.SelectRetailers("Amazon");
			sharedSteps.ThenICallSharedStep75702_UPC_AddUPCContainerTypeSizeAndPackageTypeNoRetailerDataNeeded_Continue("saved as UPC86259", "Metal Container", "5");
			sharedSteps.ThenICallSharedStep78868_RegulatoryDocumentsToProvide_USAndCanada_RequestAuthoringForBoth();
			newProductSteps.GivenInTheNewProductPageIClickContinue("Additional Documents to Provide");
			newProductSteps.GivenInTheNewProductPageIClickContinue("Optional Reports and Documents Available for Purchase");
			sharedSteps.GivenICallSharedStep64097_AdditionalDocuments_ContactInformation_AddAnyNameAddressPhoneAndEmergencyPhone_HappyPath();
			var sdsTable = new Table("Personal Protection Equipment", "Autoignition Temperature",
				"Minimum Ignition Energy", "Viscosity", "Appearance", "Odor", "Odor Threshold",
				"Partition Coefficient");
			sdsTable.AddRow("Mask", "300", "1", "20", "Black", "Odorless", "No data available", "10");
			sharedSteps
				.GivenICallSharedSafetyDataSheetAuthoring_AditionalDataStep_AddAnyRandomDataForAllFields_HappyPath(
					sdsTable);
			sharedSteps.GivenICallSharedCommentsHappyPath("Test Comment");
			sharedSteps.GivenICallSharedDataAcceptance_ClickAccept_HappyPath();
			newProductSteps.GivenIfPurchaseDetailsAreShowingClickConfirmOrder();
			sharedSteps.GivenICallShared65080LoginToStudioAndOpenSHAManager();
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(savedAs,
				"Submitted");
			sharedSteps.GivenICallSharedSHAManager_Submitted_SelectProductProcessProductData(savedAs);
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(savedAs,
				"Assigned");
			sharedSteps.GivenICallSharedWPSStudio_JobQueue_WaitForImportProcessRulesJobToComplete(savedAs);
			sharedSteps.GivenICallSharedWPSStudio_OpenPDEditExistingWithSpecificProductClickContinue(savedAs);
			sharedSteps.GivenICallSharedWPSStudio_PD_SetAllDataAndPublishUsingRuleAndDocQueue_CKLTNGHSAndSBCS(savedAs);
			sharedSteps.GivenICallShared55663WPSStudio_GoToJobQueue_WaitForPublishMultipleToComplete(savedAs);
			sharedSteps.GivenICallSharedStep59066GoToSHAManager();
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(savedAs,
				"Accepted");
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("Accepted", savedAs);
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			var table4 = new Table(new string[] {
				"Retailer"
			});
			table4.AddRow(new string[] {
				"Amazon"
			});
			sharedSteps.GivenICallShared51664SHA_AcceptedProduct_SetRetailersToCompletedForSavedAs(savedAs, table4);
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(savedAs,
				"Completed");
		}

		[StepDefinition(@"I create a Crayon product and take to completed using Test Case 86458 and save as: (.*)")]
		public void CreateProductUsingTestCase86458(string savedAs)
		{
			ReportSettings.UseSubSteps = true;
			var sharedSteps = new Steps_Shared();
			var productsGridSteps = new StepsProductGrid();
			var newProductSteps = new StepsNewProduct();
			var newProduct = new NewProduct();
			var shaSteps = new Steps_SHA();
			var thisGlobalSteps = new GlobalSteps();
			sharedSteps.GivenICallSharedStepCreateANewRegistrationViaRegisterNewProductIcon();
			sharedSteps.GivenICallSharedStepTheProduct_EnterProductNameAndSelectTypeOfProduct("Crayon");
			newProductSteps.SaveProductInformation(savedAs);
			sharedSteps.SharedPhysicalandChemicalProperties_SolidOnlyAvailable_Continue();
			sharedSteps.ICallSharedProductInformationUSAndCanadaNoChildNoOSHANoDirectShipNoPLNoNGFR_Continue();
			sharedSteps.ICallSharedIngredients_AddAnyChemical("Sodium hydroxide");
			sharedSteps.ICallSharedRegulatoryInformation1_TSCAAndCEPAShown_NoToProp65();
			sharedSteps.GivenICallSharedRetailerAssociation_SelectARetailer_Continue_HappyPath("Canadian Tire");
			var retailerTable = new Table("Retailer");
			retailerTable.AddRow("Canadian Tire");
			sharedSteps.ThenICallSharedStep75702_UPC_AddUPCContainerTypeSizeAndPackageTypeNoRetailerDataNeeded_Continue("saved as UPC86260", "Metal Container", "5");
			sharedSteps.ThenICallSharedStep78868_RegulatoryDocumentsToProvide_USAndCanada_RequestAuthoringForBoth();
			newProductSteps.GivenInTheNewProductPageIClickContinue("Additional Documents to Provide");
			newProductSteps.GivenInTheNewProductPageIClickContinue("Optional Reports and Documents Available for Purchase");
			sharedSteps.GivenICallSharedStep64097_AdditionalDocuments_ContactInformation_AddAnyNameAddressPhoneAndEmergencyPhone_HappyPath();
			var sdsTable = new Table("Personal Protection Equipment", "Autoignition Temperature",
				"Minimum Ignition Energy", "Viscosity", "Appearance", "Odor", "Odor Threshold",
				"Partition Coefficient");
			sdsTable.AddRow("Mask", "300", "1", "20", "Black", "Odorless", "No data available", "10");
			sharedSteps
				.GivenICallSharedSafetyDataSheetAuthoring_AditionalDataStep_AddAnyRandomDataForAllFields_HappyPath(
					sdsTable);
			sharedSteps.GivenICallSharedCommentsHappyPath("Test Comment");
			sharedSteps.GivenICallSharedDataAcceptance_ClickAccept_HappyPath();
			newProductSteps.GivenIfPurchaseDetailsAreShowingClickConfirmOrder();
			sharedSteps.GivenICallShared65080LoginToStudioAndOpenSHAManager();
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(savedAs,
				"Submitted");
			sharedSteps.GivenICallSharedSHAManager_Submitted_SelectProductProcessProductData(savedAs);
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(savedAs,
				"Assigned");
			sharedSteps.GivenICallSharedWPSStudio_JobQueue_WaitForImportProcessRulesJobToComplete(savedAs);
			sharedSteps.GivenICallSharedWPSStudio_OpenPDEditExistingWithSpecificProductClickContinue(savedAs);
			sharedSteps.GivenICallSharedWPSStudio_PD_SetAllDataAndPublishUsingRuleAndDocQueue_CKLTNGHSAndSBCS(savedAs);
			sharedSteps.GivenICallShared55663WPSStudio_GoToJobQueue_WaitForPublishMultipleToComplete(savedAs);
			sharedSteps.GivenICallSharedStep59066GoToSHAManager();
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			shaSteps.InTheSHAMangerGridIFindProductAndEnsureIsCompletedIfAccepted(savedAs, retailerTable);
			
		}

		[StepDefinition(@"I create a Crayon product and take to completed using Test Case 86455 and save as: (.*)")]
		public void CreateProductUsingTestCase86455(string savedAs)
		{
			ReportSettings.UseSubSteps = true;
			var sharedSteps = new Steps_Shared();
			var productsGridSteps = new StepsProductGrid();
			var newProductSteps = new StepsNewProduct();
			var newProduct = new NewProduct();
			var shaSteps = new Steps_SHA();
			var thisGlobalSteps = new GlobalSteps();
			//productsGridSteps.GivenIGenerateARandomUPCNumberAndSaveAs("UPC86116");
			sharedSteps.GivenICallSharedStepCreateANewRegistrationViaRegisterNewProductIcon();
			sharedSteps.GivenICallSharedStepTheProduct_EnterProductNameAndSelectTypeOfProduct("Crayon");
			newProductSteps.SaveProductInformation(savedAs);
			sharedSteps.SharedPhysicalandChemicalProperties_SolidOnlyAvailable_Continue();
			sharedSteps.ThenICallSharedStep85284_ProductInformation_USCanadaChildNoOSHANoDSVNoPLPYESGNFRNoContinue();
			sharedSteps.ICallSharedIngredients_AddAnyChemical("Sodium hydroxide");
			sharedSteps.ICallSharedRegulatoryInformation1_TSCAAndCEPAShown_NoToProp65();
			var retailerTable = new Table("Retailer");
			retailerTable.AddRow("Canadian Tire");
			sharedSteps.ThenICallSharedStep_Retailers_PLP_SelectOneOrMoreRetailerAndAddPLInformation_Continue(retailerTable);
			sharedSteps.ThenICallSharedStep75702_UPC_AddUPCContainerTypeSizeAndPackageTypeNoRetailerDataNeeded_Continue("saved as UPC86462", "Metal Container", "5");
			sharedSteps.ThenICallSharedStep78868_RegulatoryDocumentsToProvide_USAndCanada_RequestAuthoringForBoth();
			newProductSteps.GivenInTheNewProductPageIClickContinue("Additional Documents to Provide");
			newProductSteps.GivenInTheNewProductPageIClickContinue("Optional Reports and Documents Available for Purchase");
			sharedSteps.GivenICallSharedStep64097_AdditionalDocuments_ContactInformation_AddAnyNameAddressPhoneAndEmergencyPhone_HappyPath();
			var sdsTable = new Table("Personal Protection Equipment", "Autoignition Temperature",
				"Minimum Ignition Energy", "Viscosity", "Appearance", "Odor", "Odor Threshold",
				"Partition Coefficient");
			sdsTable.AddRow("Mask", "300", "1", "20", "Black", "Odorless", "No data available", "10");
			sharedSteps
				.GivenICallSharedSafetyDataSheetAuthoring_AditionalDataStep_AddAnyRandomDataForAllFields_HappyPath(
					sdsTable);
			sharedSteps.GivenICallSharedCommentsHappyPath("Test Comment");
			sharedSteps.GivenICallSharedDataAcceptance_ClickAccept_HappyPath();
			newProductSteps.GivenIfPurchaseDetailsAreShowingClickConfirmOrder();
			sharedSteps.GivenICallShared65080LoginToStudioAndOpenSHAManager();
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(savedAs,
				"Submitted");
			sharedSteps.GivenICallSharedSHAManager_Submitted_SelectProductProcessProductData(savedAs);
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(savedAs,
				"Assigned");
			sharedSteps.GivenICallSharedWPSStudio_JobQueue_WaitForImportProcessRulesJobToComplete(savedAs);
			sharedSteps.GivenICallSharedWPSStudio_OpenPDEditExistingWithSpecificProductClickContinue(savedAs);
			sharedSteps.GivenICallSharedWPSStudio_PD_SetAllDataAndPublishUsingRuleAndDocQueue_CKLTNGHSAndSBCS(savedAs);
			sharedSteps.GivenICallShared55663WPSStudio_GoToJobQueue_WaitForPublishMultipleToComplete(savedAs);
			sharedSteps.GivenICallSharedStep59066GoToSHAManager();
			//sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			//shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(savedAs,
			//	"Accepted");
			//sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("Accepted", savedAs);
			//sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			//var table4 = new Table(new string[] {
			//	"Retailer"
			//});
			//table4.AddRow(new string[] {
			//	"CVS"
			//});
			//sharedSteps.GivenICallShared51664SHA_AcceptedProduct_SetRetailersToCompletedForSavedAs(savedAs, table4);
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			shaSteps.InTheSHAMangerGridIFindProductAndEnsureIsCompletedIfAccepted(savedAs, retailerTable);
			//shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(savedAs,"Completed");
			//var ProductDetails = (ProductInformation)Context.GetFromContext(savedAs);
			//string ID = ProductDetails.Id;
			//var myStudioShaManager = new StudioSHAManager();

			//myStudioShaManager.ClickBottomMenuOption("Search");

			//var myStepsSha = new Steps_SHA();
			//string status = "Completed";
			//var table = new Table(new string[] {
			//	"SearchTerm",
			//	"SearchValue"
			//});
			//table.AddRow(new string[] {
			//	"ProductID",
			//	ID
			//});
			//table.AddRow(new string[] {
			//	"Status",
			//	status
			//});
			//myStepsSha.GivenInSHAManagerPageIRunSearch(table);

			//Delay.Seconds(2);
			//var mySHAManager = new StudioSHAManager();
			//mySHAManager.WaitForProductList(10);
			//Product topProduct = new StudioSHAManager().GetTopXProducts(1).FirstOrDefault();

			//if (topProduct == null || !(topProduct.Status == status && topProduct.ID == ID))
			//{
			//	Report.Failure("Failed to create product and process through to completed.");
			//}
		}

		[StepDefinition(@"I create a Chalk product and take to completed using Test Case 86115 and save as: (.*)")]
		public void CreateProductUsingTestCase86115(string savedAs)
		{
			ReportSettings.UseSubSteps = true;
			var sharedSteps = new Steps_Shared();
			var productsGridSteps = new StepsProductGrid();
			var newProductSteps = new StepsNewProduct();
			var newProduct = new NewProduct();
			var shaSteps = new Steps_SHA();
			var thisGlobalSteps = new GlobalSteps();
			sharedSteps.GivenICallSharedStepCreateANewRegistrationViaRegisterNewProductIcon();
			sharedSteps.GivenICallSharedStepTheProduct_EnterProductNameAndSelectTypeOfProduct("Chalk");
			newProductSteps.SaveProductInformation(savedAs);
			sharedSteps.SharedPhysicalandChemicalProperties_SolidOnlyAvailable_Continue();
			sharedSteps.ICallSharedProductInformationUSAndCanadaNoChildNoOSHANoDirectShipNoPLNoNGFR_Continue();
			sharedSteps.ICallSharedIngredients_AddAnyChemical("Sodium hydroxide");
			sharedSteps.ICallSharedRegulatoryInformation1_TSCAAndCEPAShown_NoToProp65();
			sharedSteps.GivenICallSharedRetailerAssociation_SelectARetailer_Continue_HappyPath("Amazon");
			sharedSteps.ThenICallSharedStep75702_UPC_AddUPCContainerTypeSizeAndPackageTypeNoRetailerDataNeeded_Continue("saved as UPC86463", "Metal Container", "5");
			sharedSteps.ThenICallSharedStep78868_RegulatoryDocumentsToProvide_USAndCanada_RequestAuthoringForBoth();
			newProductSteps.GivenInTheNewProductPageIClickContinue("Additional Documents to Provide");
			newProductSteps.GivenInTheNewProductPageIClickContinue("Optional Reports and Documents Available for Purchase");
			sharedSteps.GivenICallSharedStep64097_AdditionalDocuments_ContactInformation_AddAnyNameAddressPhoneAndEmergencyPhone_HappyPath();
			var sdsTable = new Table("Personal Protection Equipment", "Autoignition Temperature",
				"Minimum Ignition Energy", "Viscosity", "Appearance", "Odor", "Odor Threshold",
				"Partition Coefficient");
			sdsTable.AddRow("Mask", "300", "1", "20", "Black", "Odorless", "No data available", "10");
			sharedSteps
				.GivenICallSharedSafetyDataSheetAuthoring_AditionalDataStep_AddAnyRandomDataForAllFields_HappyPath(
					sdsTable);
			sharedSteps.GivenICallSharedCommentsHappyPath("Test Comment");
			sharedSteps.GivenICallSharedDataAcceptance_ClickAccept_HappyPath();
			newProductSteps.GivenIfPurchaseDetailsAreShowingClickConfirmOrder();
			sharedSteps.GivenICallShared65080LoginToStudioAndOpenSHAManager();
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(savedAs,
				"Submitted");
			sharedSteps.GivenICallSharedSHAManager_Submitted_SelectProductProcessProductData(savedAs);
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(savedAs,
				"Assigned");
			sharedSteps.GivenICallSharedWPSStudio_JobQueue_WaitForImportProcessRulesJobToComplete(savedAs);
			sharedSteps.GivenICallSharedWPSStudio_OpenPDEditExistingWithSpecificProductClickContinue(savedAs);
			sharedSteps.GivenICallSharedWPSStudio_PD_SetAllDataAndPublishUsingRuleAndDocQueue_CKLTNGHSAndSBCS(savedAs);
			sharedSteps.GivenICallShared55663WPSStudio_GoToJobQueue_WaitForPublishMultipleToComplete(savedAs);
			sharedSteps.GivenICallSharedStep59066GoToSHAManager();
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(savedAs,
				"Accepted");
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("Accepted", savedAs);
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			var table4 = new Table(new string[] {
				"Retailer"
			});
			table4.AddRow(new string[] {
				"Amazon"
			});
			sharedSteps.GivenICallShared51664SHA_AcceptedProduct_SetRetailersToCompletedForSavedAs(savedAs, table4);
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(savedAs,"Completed");
		}

		[StepDefinition(@"I create a Chalk product and take to completed using Test Case 86419 and save as: (.*)")]
		public void CreateProductUsingTestCase86419(string savedAs)
		{
			ReportSettings.UseSubSteps = true;
			var sharedSteps = new Steps_Shared();
			var productsGridSteps = new StepsProductGrid();
			var newProductSteps = new StepsNewProduct();
			var newProduct = new NewProduct();
			var shaSteps = new Steps_SHA();
			var thisGlobalSteps = new GlobalSteps();
			sharedSteps.GivenICallSharedStepCreateANewRegistrationViaRegisterNewProductIcon();
			sharedSteps.GivenICallSharedStepTheProduct_EnterProductNameAndSelectTypeOfProduct("Chalk");
			newProductSteps.SaveProductInformation(savedAs);


			//Philip - Change
			sharedSteps.ICallSharedProductInformationUSAndCanadaNoChildNoOSHANoDirectShipNoPLNoNGFR_Continue();
			sharedSteps.SharedPhysicalandChemicalProperties_SolidOnlyAvailable_Continue();
			//sharedSteps.SharedPhysicalandChemicalProperties_SolidOnlyAvailable_Continue();
			//sharedSteps.ICallSharedProductInformationUSAndCanadaNoChildNoOSHANoDirectShipNoPLNoNGFR_Continue();



			sharedSteps.ICallSharedIngredients_AddAnyChemical("Sodium hydroxide");
			sharedSteps.ICallSharedRegulatoryInformation1_TSCAAndCEPAShown_NoToProp65();
			sharedSteps.GivenICallSharedRetailerAssociation_SelectARetailer_Continue_HappyPath("Canadian Tire");
			var retailerTable = new Table("Retailer");
			retailerTable.AddRow("Canadian Tire");
			sharedSteps.ThenICallSharedStep75702_UPC_AddUPCContainerTypeSizeAndPackageTypeNoRetailerDataNeeded_Continue("saved as UPC86264", "Metal Container", "5");
			sharedSteps.ThenICallSharedStep78868_RegulatoryDocumentsToProvide_USAndCanada_RequestAuthoringForBoth();
			newProductSteps.GivenInTheNewProductPageIClickContinue("Additional Documents to Provide");
			newProductSteps.GivenInTheNewProductPageIClickContinue("Optional Reports and Documents Available for Purchase");
			sharedSteps.GivenICallSharedStep64097_AdditionalDocuments_ContactInformation_AddAnyNameAddressPhoneAndEmergencyPhone_HappyPath();
			var sdsTable = new Table("Personal Protection Equipment", "Autoignition Temperature",
				"Minimum Ignition Energy", "Viscosity", "Appearance", "Odor", "Odor Threshold",
				"Partition Coefficient");
			sdsTable.AddRow("Mask", "300", "1", "20", "Black", "Odorless", "No data available", "10");
			sharedSteps
				.GivenICallSharedSafetyDataSheetAuthoring_AditionalDataStep_AddAnyRandomDataForAllFields_HappyPath(
					sdsTable);
			sharedSteps.GivenICallSharedCommentsHappyPath("Test Comment");
			sharedSteps.GivenICallSharedDataAcceptance_ClickAccept_HappyPath();
			newProductSteps.GivenIfPurchaseDetailsAreShowingClickConfirmOrder();
			sharedSteps.GivenICallShared65080LoginToStudioAndOpenSHAManager();
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(savedAs,
				"Submitted");
			sharedSteps.GivenICallSharedSHAManager_Submitted_SelectProductProcessProductData(savedAs);
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(savedAs,
				"Assigned");
			sharedSteps.GivenICallSharedWPSStudio_JobQueue_WaitForImportProcessRulesJobToComplete(savedAs);
			sharedSteps.GivenICallSharedWPSStudio_OpenPDEditExistingWithSpecificProductClickContinue(savedAs);
			sharedSteps.GivenICallSharedWPSStudio_PD_SetAllDataAndPublishUsingRuleAndDocQueue_CKLTNGHSAndSBCS(savedAs);
			sharedSteps.GivenICallShared55663WPSStudio_GoToJobQueue_WaitForPublishMultipleToComplete(savedAs);
			sharedSteps.GivenICallSharedStep59066GoToSHAManager();
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			shaSteps.InTheSHAMangerGridIFindProductAndEnsureIsCompletedIfAccepted(savedAs, retailerTable);
			//shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(savedAs,"Completed");
		}


		[StepDefinition(@"I create a Chalk product which has a Case UPC and a regular UPC, process to completed and save the product as: (.*)")]
		public void ChalkCaseUPCToCompleted(string savedAs)
		{
			ReportSettings.UseSubSteps = true;

			var globalSteps = new GlobalSteps();
			var sharedSteps = new Steps_Shared();
			var stepsProductGrid = new StepsProductGrid();
			var stepsNewProduct = new StepsNewProduct();
			var stepsSHA = new Steps_SHA();
			var stepsSharedUPC = new StepsUPC();

			//Report.StartStep("I log in with the account saved in TReVor as: PremiumSubscriptionAccount");
			//globalSteps.ILogInWithTheAccountSavedInTrevorAs("PremiumSubscriptionAccount");
			Report.StartStep("I generate a random UPC number and save as: UPC87685");
			stepsProductGrid.GivenIGenerateARandomUPCNumberAndSaveAs("UPC87685");
			Delay.Seconds(2);
			Report.StartStep("I generate a random UPC number and save as: UPC876851");
			stepsProductGrid.GivenIGenerateARandomUPCNumberAndSaveAs("UPC876851");
			Report.StartStep("I call Shared Step 57408 (Create a New Registration via Register New Product icon)");
			sharedSteps.GivenICallSharedStepCreateANewRegistrationViaRegisterNewProductIcon();
			Report.StartStep("I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk");
			sharedSteps.GivenICallSharedStepTheProduct_EnterNameSelectProductType_Continue_HappyPath("Chalk");

			Report.StartStep("I save the product Information as: " + savedAs);
			stepsNewProduct.SaveProductInformation(savedAs);
			Report.StartStep("I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)");
			sharedSteps.ICallSharedProductInformationUSOnlyNoChildNoGHSNoDirectShipNoPLPNoGNFR();
			Report.StartStep("I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)");
			sharedSteps.SharedPhysicalandChemicalProperties_SolidOnlyAvailable_Continue();
			
			Report.StartStep("I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide");
			sharedSteps.ICallSharedIngredients_AddAnyChemical("Sodium hydroxide");
			Report.StartStep("Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)");
			sharedSteps.ICallSharedRegulatoryInformation1_TSCARandom_Pro65No_Continue();
			Report.StartStep("I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue) for");

			var retailerTable = new TechTalk.SpecFlow.Table("Retailer");
			retailerTable.AddRow("Amazon");

			sharedSteps.GivenICallSharedStep75146Retailer_SelectOneOrMoreRetailersThatDoNotRequireVendorIDOrAdditionalUPCInformationClickDoneClickContinue(retailerTable);
			//Report.StartStep("I call Shared Step 87647 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC87685, container type: Paper bag and size: 2 do not click continue");
			//stepsSharedUPC.EnterUPCInfoDoNotClickContinue("87685", "Paper bag", "2");

			//Report.StartStep("I call Shared Step 87641(Enter Universal Product Code - case information) for UPC: saved as UPC876851, container type: Paper bag and size: 2 and Quantity: 4 and Transportation option: 4A: steel box");
			//stepsSharedUPC.UPCCaseInformation("876851", "Paper bag", "2", "4", "4A: steel box");

			Report.StartStep("I call Shared Step 87829 (UPC - Add Case UPC - All Data > Continue) for UPC: saved as UPC (.*), container type: (.*) and size: (.*) and Quantity: (.*) and Individual Upc Case Pack saved As: (.*) and Transportation option: (.*)");
			stepsSharedUPC.UPCCaseAddInformation("876851", "Paper bag", "2", "4", "", "<first>");


			Report.StartStep("I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)");
			sharedSteps.GivenICallSharedRegulatoryDocumentsToProvide_USOnly_RequestAuthoring_HappyPath();
			Report.StartStep("in the Additional Documents to Provide page I click Continue");
			stepsNewProduct.GivenInTheNewProductPageIClickContinue(" Additional Documents to Provide");
			Report.StartStep("in the Optional Reports and Documents Available for Purchase page I click Continue");
			stepsNewProduct.GivenInTheNewProductPageIClickContinue("Optional Reports and Documents Available for Purchase");

			Report.StartStep("I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:");

			var additionalData = new Table("Personal Protection Equipment", "Autoignition Temperature", "Minimum Ignition Energy", "Viscosity", "Appearance", "Odor", "Odor Threshold", "Partition Coefficient");
			additionalData.AddRow("Mask", "300", "1.005", "20", "Black", "Odorless", "No data available", "10");

			sharedSteps.GivenICallSharedSafetyDataSheetAuthoring_AditionalDataStep_AddAnyRandomDataForAllFields_HappyPath(additionalData);
			Report.StartStep("I call Shared Step 57883");
			sharedSteps.GivenICallSharedCommentsHappyPath(@"User added Comments Text 57863. !""�$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.");
			Report.StartStep("I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)");
			sharedSteps.GivenICallSharedDataAcceptance_ClickAccept_HappyPath();
			Report.StartStep("If purchase details are showing click confirm order");
			stepsNewProduct.GivenIfPurchaseDetailsAreShowingClickConfirmOrder();
			sharedSteps.GivenICallShared65080LoginToStudioAndOpenSHAManager();
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			stepsSHA.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(savedAs,
				"Submitted");
			sharedSteps.GivenICallSharedSHAManager_Submitted_SelectProductProcessProductData(savedAs);
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			stepsSHA.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(savedAs,
				"Assigned");
			sharedSteps.GivenICallSharedWPSStudio_JobQueue_WaitForImportProcessRulesJobToComplete(savedAs);
			sharedSteps.GivenICallSharedWPSStudio_OpenPDEditExistingWithSpecificProductClickContinue(savedAs);
			sharedSteps.GivenICallSharedWPSStudio_PD_SetAllDataAndPublishUsingRuleAndDocQueue_CKLTNGHSAndSBCS(savedAs);
			sharedSteps.GivenICallShared55663WPSStudio_GoToJobQueue_WaitForPublishMultipleToComplete(savedAs);
			sharedSteps.GivenICallSharedStep59066GoToSHAManager();
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			stepsSHA.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(savedAs,
				"Accepted");
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("Accepted", savedAs);
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			var table4 = new Table(new string[] {
				"Retailer"
			});
			table4.AddRow(new string[] {
				"Amazon"
			});
			sharedSteps.GivenICallShared51664SHA_AcceptedProduct_SetRetailersToCompletedForSavedAs(savedAs, table4);
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			stepsSHA.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(savedAs,
				"Completed");
		}

		[StepDefinition(@"I enter: (.*) as my ingredient in the Ingredients page, and check that the top option on the filter matches my ingredient")]
		public void IEnterAnIngredientAndCheckTopOptionMatches(string myIngredient)
		{
			ReportSettings.UseSubSteps = true;
			var ingredients = new Ingredients();
			var selNewProduct = new UPC();
			Report.StartStep("I Check I am on the Ingredients page");
			Report.IsTrue(selNewProduct.WaitForSection("Ingredients"),
				"The Ingredients page is not showing when it was expected to",
				"The Ingredients page is showing as expected");
			Report.Screenshot();
			Report.StartStep($"I enter: {myIngredient} as the ingredient in the ingredients page");
			ingredients.ClickComponentSearchPlaceholder();
			ingredients.EnterTextSearchComponent(myIngredient);
			Report.StartStep("I check my ingredient is at the top of the filter");
			Report.IsTrue(ingredients.IngredientMatchesFirstOption(myIngredient), "The first option did not match the input option", "The first option matched the input option");

		}

		[StepDefinition(@"I Submit a new product which has a Case UPC and a regular UPC")]
		public void ISubmitANewProductWhichHasACaseUPCAndARegularUPC()
		{
			ReportSettings.UseSubSteps = true;

			var globalSteps = new GlobalSteps();
			var sharedSteps = new Steps_Shared();
			var stepsProductGrid = new StepsProductGrid();
			var stepsNewProduct = new StepsNewProduct();
			var stepsSHA = new Steps_SHA();
			var stepsSharedUPC = new StepsUPC();

			Report.StartStep("I log in with the account saved in TReVor as: PremiumSubscriptionAccount");
			globalSteps.ILogInWithTheAccountSavedInTrevorAs("PremiumSubscriptionAccount");
			Report.StartStep("I generate a random UPC number and save as: UPC87685");
			stepsProductGrid.GivenIGenerateARandomUPCNumberAndSaveAs("UPC87685");
			Delay.Seconds(2);
			Report.StartStep("I generate a random UPC number and save as: UPC876851");
			stepsProductGrid.GivenIGenerateARandomUPCNumberAndSaveAs("UPC876851");
			Report.StartStep("I call Shared Step 57408 (Create a New Registration via Register New Product icon)");
			sharedSteps.GivenICallSharedStepCreateANewRegistrationViaRegisterNewProductIcon();
			Report.StartStep("I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk");
			sharedSteps.GivenICallSharedStepTheProduct_EnterNameSelectProductType_Continue_HappyPath("Chalk");

			Report.StartStep("I save the product Information as: TestCase87685");
			stepsNewProduct.SaveProductInformation("TestCase87685");
			Report.StartStep("I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)");
			sharedSteps.ICallSharedProductInformationUSOnlyNoChildNoGHSNoDirectShipNoPLPNoGNFR();


			Report.StartStep("I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)");
			sharedSteps.SharedPhysicalandChemicalProperties_SolidOnlyAvailable_Continue();

			Report.StartStep("I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide");
			sharedSteps.ICallSharedIngredients_AddAnyChemical("Sodium hydroxide");
			Report.StartStep("Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)");
			sharedSteps.ICallSharedRegulatoryInformation1_TSCARandom_Pro65No_Continue();
			Report.StartStep("I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue) for");

			var retailerTable = new TechTalk.SpecFlow.Table("Retailer");
			retailerTable.AddRow("Amazon");

			sharedSteps.GivenICallSharedStep75146Retailer_SelectOneOrMoreRetailersThatDoNotRequireVendorIDOrAdditionalUPCInformationClickDoneClickContinue(retailerTable);
			Report.StartStep("I call Shared Step 87647 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC87685, container type: Paper bag and size: 2 do not click continue");
			stepsSharedUPC.EnterUPCInfoDoNotClickContinue("87685", "Paper bag", "2");

			//Report.StartStep("I call Shared Step 87641(Enter Universal Product Code - case information) for UPC: saved as UPC876851, container type: Paper bag and size: 2 and Quantity: 4 and Transportation option: 4A: steel box");
			//stepsSharedUPC.UPCCaseInformation("876851", "Paper bag", "2", "4", "4A: steel box");

			Report.StartStep("I call Shared Step 87829 (UPC - Add Case UPC - All Data > Continue) for UPC: saved as UPC (.*), container type: (.*) and size: (.*) and Quantity: (.*) and Individual Upc Case Pack saved As: (.*) and Transportation option: (.*)");
			stepsSharedUPC.UPCCaseAddInformation("876851", "Paper bag", "2", "4", "UPC87685", "4A: steel box");			
			Report.StartStep("I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)");
			sharedSteps.GivenICallSharedRegulatoryDocumentsToProvide_USOnly_RequestAuthoring_HappyPath();	
			Report.StartStep("in the Additional Documents to Provide page I click Continue");
			stepsNewProduct.GivenInTheNewProductPageIClickContinue(" Additional Documents to Provide");
			Report.StartStep("in the Optional Reports and Documents Available for Purchase page I click Continue");
			stepsNewProduct.GivenInTheNewProductPageIClickContinue("Optional Reports and Documents Available for Purchase");
			Report.StartStep("I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:");
			var additionalData = new Table("Personal Protection Equipment", "Autoignition Temperature", "Minimum Ignition Energy", "Viscosity", "Appearance", "Odor", "Odor Threshold", "Partition Coefficient");
			additionalData.AddRow("Mask", "300", "1.005", "20", "Black", "Odorless", "No data available", "10");
			sharedSteps.GivenICallSharedSafetyDataSheetAuthoring_AditionalDataStep_AddAnyRandomDataForAllFields_HappyPath(additionalData);
			Report.StartStep("I call Shared Step 57883");
			sharedSteps.GivenICallSharedCommentsHappyPath(@"User added Comments Text 57863. !""�$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.");
			Report.StartStep("I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)");
			sharedSteps.GivenICallSharedDataAcceptance_ClickAccept_HappyPath();
			Report.StartStep("If purchase details are showing click confirm order");
			stepsNewProduct.GivenIfPurchaseDetailsAreShowingClickConfirmOrder();
		}

		[StepDefinition("I create a NEW PRODUCT, select all certifications on the UPC screen and get it to Submitted status in SHA")]
		public void ICreateANewProductSelectAllCertificationsAndGetItToSubmittedStatusInSHA()
		{
			ReportSettings.UseSubSteps = true;

			var globalSteps = new GlobalSteps();
			var sharedSteps = new Steps_Shared();
			var stepsProductGrid = new StepsProductGrid();
			var stepsNewProduct = new StepsNewProduct();
			var stepsSHA = new Steps_SHA();




			Report.StartStep("I login into the WERCSmart Portal - Administrator Role");
			globalSteps.LoginToWERCSmart("Administrator Role");
			Report.StartStep("I generate a random UPC number and save as: UPC75142");
			stepsProductGrid.GivenIGenerateARandomUPCNumberAndSaveAs("UPC75142");
			Report.StartStep("I delete all products with UPC Number: saved as UPC75142");
			stepsProductGrid.DeleteAllProductsMatchingCriteria("UPC Number", "saved as UPC75142");
			Report.StartStep("I call Shared Step 57408 (Create a New Registration via Register New Product icon)");
			sharedSteps.GivenICallSharedStepCreateANewRegistrationViaRegisterNewProductIcon();
			Report.StartStep("I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk");
			sharedSteps.GivenICallSharedStepTheProduct_EnterNameSelectProductType_Continue_HappyPath("Chalk");
			Report.StartStep("I save the product information as: TestCase75142");
			stepsNewProduct.SaveProductInformation("TestCase75142");
			Report.StartStep("I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)");
			sharedSteps.ICallSharedProductInformationUSOnlyNoChildNoGHSNoDirectShipNoPLPNoGNFR();
			Report.StartStep("I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)");
			sharedSteps.SharedPhysicalandChemicalProperties_SolidOnlyAvailable_Continue();
			
			Report.StartStep("I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide");
			sharedSteps.ICallSharedIngredients_AddAnyChemical("Sodium hydroxide");
			Report.StartStep("I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)");
			sharedSteps.ICallSharedRegulatoryInformation1_TSCARandom_Pro65No_Continue();
			sharedSteps.Shared77845_Retailer_SelectWM_Done_SelectVendorID_Continue();

			//Report.StartStep("I call Shared Step 75146");

			//Table retailerTable = new Table("Retailer");
			//retailerTable.AddRow("Walmart");

			//sharedSteps.GivenICallSharedStep75146Retailer_SelectOneOrMoreRetailersThatDoNotRequireVendorIDOrAdditionalUPCInformationClickDoneClickContinue(retailerTable);
			Report.StartStep("In the upc screen I add the UPC: saved as UPC75142, container type: Metal Container and size: 40, then select all certifications");
			stepsNewProduct.InTheUPCScreenIAddUPCDetailsAndSelectAllCertifications("75142", "Metal Container", "40");

			Report.StartStep("I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)");
			sharedSteps.GivenICallSharedRegulatoryDocumentsToProvide_USOnly_RequestAuthoring_HappyPath();
			Report.StartStep("in the Additional Documents to Provide page I click Continue");
			stepsNewProduct.GivenInTheNewProductPageIClickContinue("Additional Documents to Provide");
			Report.StartStep("in the Optional Reports and Documents Available for Purchase page I click Continue");
			stepsNewProduct.GivenInTheNewProductPageIClickContinue("Optional Reports and Documents Available for Purchase");
			Report.StartStep("I call Shared Step 57884");

			Table additionalData = new Table("Personal Protection Equipment", "Autoignition Temperature", "Minimum Ignition Energy", "Viscosity", "Appearance", "Odor", "Odor Threshold", "Partition Coefficient");
			additionalData.AddRow("Mask", "300", "1.005", "20", "Black", "Odorless", "No data available", "10");
			sharedSteps.GivenICallSharedSafetyDataSheetAuthoring_AditionalDataStep_AddAnyRandomDataForAllFields_HappyPath(additionalData);
			Report.StartStep("I call Shared Step 57883");
			sharedSteps.GivenICallSharedCommentsHappyPath(@"User added Comments Text 57863. !""�$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.");
			Report.StartStep("I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)");
			sharedSteps.GivenICallSharedDataAcceptance_ClickAccept_HappyPath();
			Report.StartStep("If purchase details are showing click confirm order");
			stepsNewProduct.GivenIfPurchaseDetailsAreShowingClickConfirmOrder();
			Report.StartStep("I call Shared Step 65080 (Login to Studio and Open SHA manager)");
			sharedSteps.GivenICallShared65080LoginToStudioAndOpenSHAManager();
			Report.StartStep("I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase75142)");
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", "TestCase75142");
			Report.StartStep("In the SHA manager grid I see the WPS ID I have saved as product: TestCase75142 and its status is: Submitted");
			stepsSHA.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs("TestCase75142", "Submitted");


		}

		[StepDefinition(@"I create a Chalk product for WalMart and Proccess it to completed and save it as: (.*)")]
		public void ICreateAChalkProductForWalmartAndProccessItToCompleted(string savedAs)
		{
			ReportSettings.UseSubSteps = true;
			var sharedSteps = new Steps_Shared();
			var productsGridSteps = new StepsProductGrid();
			var newProductSteps = new StepsNewProduct();
			var newProduct = new NewProduct();
			var shaSteps = new Steps_SHA();
			var thisGlobalSteps = new GlobalSteps();
			Report.StartStep("I generate a random UPC number and save as: UPC75142");
			new StepsProductGrid().GivenIGenerateARandomUPCNumberAndSaveAs("UPC75142");
			sharedSteps.GivenICallSharedStepCreateANewRegistrationViaRegisterNewProductIcon();
			sharedSteps.GivenICallSharedStepTheProduct_EnterProductNameAndSelectTypeOfProduct("Chalk");
			newProductSteps.SaveProductInformation(savedAs);
			sharedSteps.SharedPhysicalandChemicalProperties_SolidOnlyAvailable_Continue();
			sharedSteps.ThenICallSharedStep85284_ProductInformation_USCanadaChildNoOSHANoDSVNoPLPYESGNFRNoContinue();
			sharedSteps.ICallSharedIngredients_AddAnyChemical("Sodium hydroxide");
			sharedSteps.ICallSharedRegulatoryInformation1_TSCAAndCEPAShown_NoToProp65();
			//sharedSteps.Shared77845_Retailer_SelectWM_Done_SelectVendorID_Continue();
			
			var retailerSelectionSteps = new StepsSelectRetailers();
			ReportSettings.UseSubSteps = true;
			Report.StartStep("I should see the Select Retailers Popup");
			retailerSelectionSteps.GivenIShouldSeeTheSelectRetailersPopUp();
			Report.StartStep("I select the retailer: Wal-Mart/SAM'S CLUB and click Done");
			new StepsSelectRetailers().SelectTheRetailer("Walmart");
			Report.StartStep("I set the Vendor as: Testing");
			//new Steps_Retailer().ISelectVendorId("Testing");
			new Steps_Retailer().ISelectFirstVendorIdForRetailer("Walmart");
			new Retailer().SelectPrivateLabelName("Great Value");
			Report.StartStep("I click continue");
			newProductSteps.ClickContinue();
			Report.StartStep("In the upc screen I add the UPC: saved as UPC75142, container type: Metal Container and size: 40, then select all certifications");
			new StepsNewProduct().InTheUPCScreenIAddUPCDetailsAndSelectAllCertifications("75142", "Metal Container", "40");



			//sharedSteps.ThenICallSharedStep75702_UPC_AddUPCContainerTypeSizeAndPackageTypeNoRetailerDataNeeded_Continue("saved as UPC86259", "Metal Container", "5");
			sharedSteps.ThenICallSharedStep78868_RegulatoryDocumentsToProvide_USAndCanada_RequestAuthoringForBoth();
			newProductSteps.GivenInTheNewProductPageIClickContinue("Additional Documents to Provide");
			newProductSteps.GivenInTheNewProductPageIClickContinue("Optional Reports and Documents Available for Purchase");
			sharedSteps.GivenICallSharedStep64097_AdditionalDocuments_ContactInformation_AddAnyNameAddressPhoneAndEmergencyPhone_HappyPath();
			var sdsTable = new Table("Personal Protection Equipment", "Autoignition Temperature",
				"Minimum Ignition Energy", "Viscosity", "Appearance", "Odor", "Odor Threshold",
				"Partition Coefficient");
			sdsTable.AddRow("Mask", "300", "1", "20", "Black", "Odorless", "No data available", "10");
			sharedSteps
				.GivenICallSharedSafetyDataSheetAuthoring_AditionalDataStep_AddAnyRandomDataForAllFields_HappyPath(
					sdsTable);
			sharedSteps.GivenICallSharedCommentsHappyPath("Test Comment");
			sharedSteps.GivenICallSharedDataAcceptance_ClickAccept_HappyPath();
			newProductSteps.GivenIfPurchaseDetailsAreShowingClickConfirmOrder();
			sharedSteps.GivenICallShared65080LoginToStudioAndOpenSHAManager();
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(savedAs,
				"Submitted");
			sharedSteps.GivenICallSharedSHAManager_Submitted_SelectProductProcessProductData(savedAs);
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(savedAs,
				"Assigned");
			sharedSteps.GivenICallSharedWPSStudio_JobQueue_WaitForImportProcessRulesJobToComplete(savedAs);
			sharedSteps.GivenICallSharedWPSStudio_OpenPDEditExistingWithSpecificProductClickContinue(savedAs);
			sharedSteps.GivenICallSharedWPSStudio_PD_SetAllDataAndPublishUsingRuleAndDocQueue_CKLTNGHSAndSBCS(savedAs);
			sharedSteps.GivenICallShared55663WPSStudio_GoToJobQueue_WaitForPublishMultipleToComplete(savedAs);
			sharedSteps.GivenICallSharedStep59066GoToSHAManager();
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(savedAs,
				"Accepted");
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("Accepted", savedAs);
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			var table4 = new Table(new string[] {
				"Retailer"
			});
			table4.AddRow(new string[] {
				"Amazon"
			});
			sharedSteps.GivenICallShared51664SHA_AcceptedProduct_SetRetailersToCompletedForSavedAs(savedAs, table4);
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(savedAs,
				"Completed");
		}

		[StepDefinition("I create a NEW PRODUCT, select all certifications on the UPC screen and get it to Completed status in SHA")]
		public void ICreateANewProductSelectAllCertificationsAndGetItToCompletedStatusInSHA()
		{
			ReportSettings.UseSubSteps = true;

			var globalSteps = new GlobalSteps();
			var sharedSteps = new Steps_Shared();
			var stepsProductGrid = new StepsProductGrid();
			var stepsNewProduct = new StepsNewProduct();
			var stepsSHA = new Steps_SHA();




			Report.StartStep("I login into the WERCSmart Portal - Administrator Role");
			globalSteps.LoginToWERCSmart("Administrator Role");
			Report.StartStep("I generate a random UPC number and save as: UPC75142");
			stepsProductGrid.GivenIGenerateARandomUPCNumberAndSaveAs("UPC75142");
			Report.StartStep("I delete all products with UPC Number: saved as UPC75142");
			stepsProductGrid.DeleteAllProductsMatchingCriteria("UPC Number", "saved as UPC75142");
			Report.StartStep("I call Shared Step 57408 (Create a New Registration via Register New Product icon)");
			sharedSteps.GivenICallSharedStepCreateANewRegistrationViaRegisterNewProductIcon();
			Report.StartStep("I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk");
			sharedSteps.GivenICallSharedStepTheProduct_EnterNameSelectProductType_Continue_HappyPath("Chalk");
			Report.StartStep("I save the product information as: TestCase75142");
			stepsNewProduct.SaveProductInformation("TestCase75142");
			Report.StartStep("I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)");
			sharedSteps.ICallSharedProductInformationUSOnlyNoChildNoGHSNoDirectShipNoPLPNoGNFR();
			Report.StartStep("I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)");
			sharedSteps.SharedPhysicalandChemicalProperties_SolidOnlyAvailable_Continue();
			
			Report.StartStep("I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide");
			sharedSteps.ICallSharedIngredients_AddAnyChemical("Sodium hydroxide");
			Report.StartStep("I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)");
			sharedSteps.ICallSharedRegulatoryInformation1_TSCARandom_Pro65No_Continue();
			sharedSteps.Shared77845_Retailer_SelectWM_Done_SelectVendorID_Continue();
			
			Report.StartStep("In the upc screen I add the UPC: saved as UPC75142, container type: Metal Container and size: 40, then select all certifications");
			stepsNewProduct.InTheUPCScreenIAddUPCDetailsAndSelectAllCertifications("75142", "Metal Container", "40");

			Report.StartStep("I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)");
			sharedSteps.GivenICallSharedRegulatoryDocumentsToProvide_USOnly_RequestAuthoring_HappyPath();
			Report.StartStep("in the Additional Documents to Provide page I click Continue");
			stepsNewProduct.GivenInTheNewProductPageIClickContinue("Additional Documents to Provide");
			Report.StartStep("in the Optional Reports and Documents Available for Purchase page I click Continue");
			stepsNewProduct.GivenInTheNewProductPageIClickContinue("Optional Reports and Documents Available for Purchase");
			Report.StartStep("I call Shared Step 57884");

			Table additionalData = new Table("Personal Protection Equipment", "Autoignition Temperature", "Minimum Ignition Energy", "Viscosity", "Appearance", "Odor", "Odor Threshold", "Partition Coefficient");
			additionalData.AddRow("Mask", "300", "1.005", "20", "Black", "Odorless", "No data available", "10");
			sharedSteps.GivenICallSharedSafetyDataSheetAuthoring_AditionalDataStep_AddAnyRandomDataForAllFields_HappyPath(additionalData);
			Report.StartStep("I call Shared Step 57883");
			sharedSteps.GivenICallSharedCommentsHappyPath(@"User added Comments Text 57863. !""�$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.");
			Report.StartStep("I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)");
			sharedSteps.GivenICallSharedDataAcceptance_ClickAccept_HappyPath();
			Report.StartStep("If purchase details are showing click confirm order");
			stepsNewProduct.GivenIfPurchaseDetailsAreShowingClickConfirmOrder();
			
			sharedSteps.GivenICallShared65080LoginToStudioAndOpenSHAManager();
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", "TestCase75142");
			stepsSHA.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs("TestCase75142",
				"Submitted");
			sharedSteps.GivenICallSharedSHAManager_Submitted_SelectProductProcessProductData("TestCase75142");
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", "TestCase75142");
			stepsSHA.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs("TestCase75142",
				"Assigned");
			sharedSteps.GivenICallSharedWPSStudio_JobQueue_WaitForImportProcessRulesJobToComplete("TestCase75142");
			sharedSteps.GivenICallSharedWPSStudio_OpenPDEditExistingWithSpecificProductClickContinue("TestCase75142");
			sharedSteps.GivenICallSharedWPSStudio_PD_SetAllDataAndPublishUsingRuleAndDocQueue_CKLTNGHSAndSBCS("TestCase75142");
			sharedSteps.GivenICallShared55663WPSStudio_GoToJobQueue_WaitForPublishMultipleToComplete("TestCase75142");
			sharedSteps.GivenICallSharedStep59066GoToSHAManager();
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", "TestCase75142");
			stepsSHA.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs("TestCase75142",
				"Accepted");
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("Accepted", "TestCase75142");
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", "TestCase75142");
			var table4 = new Table(new string[] {
				"Retailer"
			});
			table4.AddRow(new string[] {
				"WalMart"
			});
			sharedSteps.GivenICallShared51664SHA_AcceptedProduct_SetRetailersToCompletedForSavedAs("TestCase75142", table4);
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", "TestCase75142");
			stepsSHA.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs("TestCase75142",
				"Completed");


		}

		[StepDefinition(@"I create a Chalk product and take to completed for distributor and save as: (.*)")]
		public void CreateProductForDistributor(string savedAs)
		{
			ReportSettings.UseSubSteps = true;
			var sharedSteps = new Steps_Shared();
			var productsGridSteps = new StepsProductGrid();
			var newProductSteps = new StepsNewProduct();
			var newProduct = new NewProduct();
			var shaSteps = new Steps_SHA();
			var thisGlobalSteps = new GlobalSteps();
			sharedSteps.GivenICallSharedStepCreateANewRegistrationViaRegisterNewProductIcon();
			sharedSteps.GivenICallSharedStepTheProduct_EnterProductNameAndSelectTypeOfProduct("Chalk");
			newProductSteps.SaveProductInformation(savedAs);
			sharedSteps.SharedPhysicalandChemicalProperties_SolidOnlyAvailable_Continue();
			sharedSteps.ICallSharedProductInformationUSOnlyNoChildNoGHSNoDirectShipNoPLPNoGNFR();
			sharedSteps.ICallSharedIngredients_AddAnyChemical("Sodium hydroxide");
			sharedSteps.ICallSharedRegulatoryInformation1_TSCAAndCEPAShown_NoToProp65();
			sharedSteps.GivenICallSharedRetailerAssociation_SelectARetailer_Continue_HappyPath("Amazon");
			sharedSteps.ThenICallSharedStep75702_UPC_AddUPCContainerTypeSizeAndPackageTypeNoRetailerDataNeeded_Continue("savedas UPC86463", "Metal Container", "5");
			sharedSteps.GivenICallSharedRegulatoryDocumentsToProvide_USOnly_RequestAuthoring_HappyPath();
			newProductSteps.GivenInTheNewProductPageIClickContinue("Additional Documents to Provide");
			newProductSteps.GivenInTheNewProductPageIClickContinue("Optional Reports and Documents Available for Purchase");
			var sdsTable = new Table("Personal Protection Equipment", "Autoignition Temperature",
				"Minimum Ignition Energy", "Viscosity", "Appearance", "Odor", "Odor Threshold",
				"Partition Coefficient");
			sdsTable.AddRow("Mask", "300", "1", "20", "Black", "Odorless", "No data available", "10");
			sharedSteps
				.GivenICallSharedSafetyDataSheetAuthoring_AditionalDataStep_AddAnyRandomDataForAllFields_HappyPath(
					sdsTable);
			sharedSteps.GivenICallSharedCommentsHappyPath("Test Comment");
			sharedSteps.GivenICallSharedDataAcceptance_ClickAccept_HappyPath();
			newProductSteps.GivenIfPurchaseDetailsAreShowingClickConfirmOrder();
			sharedSteps.GivenICallShared65080LoginToStudioAndOpenSHAManager();
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(savedAs,
				"Submitted");
			sharedSteps.GivenICallSharedSHAManager_Submitted_SelectProductProcessProductData(savedAs);
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(savedAs,
				"Assigned");
			sharedSteps.GivenICallSharedWPSStudio_JobQueue_WaitForImportProcessRulesJobToComplete(savedAs);
			sharedSteps.GivenICallSharedWPSStudio_OpenPDEditExistingWithSpecificProductClickContinue(savedAs);
			sharedSteps.GivenICallSharedWPSStudio_PD_SetAllDataAndPublishUsingRuleAndDocQueue_CKLTNGHSAndSBCS(savedAs);
			sharedSteps.GivenICallShared55663WPSStudio_GoToJobQueue_WaitForPublishMultipleToComplete(savedAs);
			sharedSteps.GivenICallSharedStep59066GoToSHAManager();
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(savedAs,
				"Accepted");
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("Accepted", savedAs);
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			var table4 = new Table(new string[] {
				"Retailer"
			});
			table4.AddRow(new string[] {
				"Amazon"
			});
			sharedSteps.GivenICallShared51664SHA_AcceptedProduct_SetRetailersToCompletedForSavedAs(savedAs, table4);
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(savedAs,
				"Completed");
		}

		[StepDefinition(@"I create a Hair Color Kit using test case 58753 with product name: (.*) and save as: (.*)")]
		public void CreateHairColorKitUsing58753AndSaveAs(string productName, string savedAs)
		{
			ReportSettings.UseSubSteps = true;
			var sharedSteps = new Steps_Shared();
			var productsGridSteps = new StepsProductGrid();
			var newProductSteps = new StepsNewProduct();
			var newProduct = new NewProduct();
			var shaSteps = new Steps_SHA();
			var thisGlobalSteps = new GlobalSteps();
			Report.StartStep("I create a product and take to completed using Test Case 75335 and save as: 58753_KitProduct1");
			this.GivenICreateProductUsingTestCase75335("58753_KitProduct1");			
			Report.StartStep("I navigate to the landing page");
			thisGlobalSteps.NavigateToLandingPage();
			Report.StartStep("I create a product and take to completed using Test Case 75335 and save as: 58753_KitProduct2");
			this.GivenICreateProductUsingTestCase75335("58753_KitProduct2");
			Report.StartStep("I navigate to the landing page");
			thisGlobalSteps.NavigateToLandingPage();
			Report.StartStep("I generate a random UPC number and save as: UPC58753");
			productsGridSteps.GivenIGenerateARandomUPCNumberAndSaveAs("UPC58753");
			Report.StartStep("And I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)");
			sharedSteps.GivenICallSharedStep67823LoginToWERCSmart_ProductsAutomationAccount();
			Report.StartStep("And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))");
			sharedSteps.GivenICallSharedCreateANewRegistrationViaRegisterNewProductExpandedMenu();
			
			Report.StartStep($"The Product- Enter name: {productName}, select product type, Enter TestBrand - Continue - Happy Path): Hair Color Kit");
			new Steps_TheProduct().SetProductNameProductTypeProductLine(productName, "Hair Color Kit", "TestBrand");
			new StepsNewProduct().SaveProductInformation(savedAs);
			Report.StartStep("And I call Shared Step 60648 (Product Information - US, No (Direct Ship), No (PL), No (GNFR))");
			sharedSteps.Shared60648_ProductInformation_Us_NoDirectShip_NoPl_NoGnfr();
			Report.StartStep("And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)");
			sharedSteps.ICallSharedRegulatoryInformation1_TSCARandom_Pro65No_Continue();
			Report.StartStep("And I call Shared Step 31427 (Create the Kit - Adding two products: product 1: 58753_KitProduct1 and product 2: 58753_KitProduct2)");
			sharedSteps.Shared31427_CreateTheKit_AddingTwoProducts("58753_KitProduct1", "58753_KitProduct2");
			Report.StartStep("And I call Shared Step 57506 (Transportation Details 1 - Regulated for Transport(No) - Exemption(Random) - Continue - Happy Path)");
			sharedSteps.GivenICallSharedTransportationDetails_RegulatedForTransportNo_ExemptionRandom_Continue_HappyPath();
			Report.StartStep("And I call Shared Step 62536 (Transportation Details 2 > I do not ship internationally > Continue - Happy Path)");
			sharedSteps.SharedTransportationDetails2_DoNotShipInternationally_Continue();
			Report.StartStep("And I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: CVS");
			sharedSteps.GivenICallSharedRetailerAssociation_SelectARetailer_Continue_HappyPath("CVS");
			Report.StartStep("And I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC58753, container type: Plastic Container and size: 100");
			sharedSteps.GivenICallSharedEnterUniversalProductCodeUPC_UPC_ContainerType_SizeOnly("58753", "Plastic Container", "100");
			Report.StartStep("And I should see the Additional Documents to Provide Page");
			newProductSteps.ProductEditorShouldBeLoaded();
			Report.StartStep("And I click continue");
			newProductSteps.ClickContinue();
			Report.StartStep("And I call Shared Step 57883 (Comments - Happy Path) and enter the comment: Test Comment Kit 58753");
			sharedSteps.GivenICallSharedCommentsHappyPath("Test Comment Kit 58753");
			Report.StartStep("And I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)");
			sharedSteps.GivenICallSharedDataAcceptance_ClickAccept_HappyPath();

		}

	}

}
