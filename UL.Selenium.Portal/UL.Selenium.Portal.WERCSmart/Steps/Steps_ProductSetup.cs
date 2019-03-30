using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Core.Internal;
using NPOI.SS.Formula.Functions;
using NTTQA_Automation_Classes.Classes;
using NTTQA_Reporting_Module;
using NTTQA_Reporting_Module.Reporting.Core;
using NUnit.Framework.Internal;
using SeleniumUtilities;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using TestStack.White.Recording;
using Wercs.Selenium.PortalUX.Selenium_Classes;
using Wercs.Selenium.PortalUX.Selenium_Classes.New_Product;
using WERCSmart;

namespace Wercs.Selenium.PortalUX.Steps
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
			//sharedSteps.GivenICallSharedStep67823LoginToWERCSmart_ProductsAutomationAccount();
			sharedSteps.Shared68210_LoginToWercSmart_PremiumAccount();
			// Generate UPC number and delete duplicates
			productsGridSteps.GivenIGenerateARandomUPCNumberAndSaveAs("UPC75335");
			productsGridSteps.DeleteAllProductsMatchingCriteria("UPC Number", "saved as UPC75335");
			// 57408 (Create a New Registration via Register New Product icon)
			sharedSteps.GivenICallSharedStepCreateANewRegistrationViaRegisterNewProductIcon();
			// 57500 (The Product- Enter name, select product type - Continue - Happy Path)
			sharedSteps.GivenICallSharedStepTheProduct_EnterNameSelectProductType_Continue_HappyPath("Chalk");
			// Save product to context
			newProductSteps.SaveProductInformation(savedAs);
			// 26897 (Product Characteristics - Solid only available - continue)
			sharedSteps.SharedProductCharacteristics_SolidOnlyAvailable_Continue();
			// 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
			sharedSteps.ICallSharedAdditionalProductInformationUSOnlyNoChildNoGHSNoDirectShipNoPLPNoGNFR();
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
			TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
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

		[StepDefinition(
			@"I create a product with name: (.*) and take to completed using Test Case 75335 and save as: (.*)")]
		public void GivenICreateProductUsingTestCase75335(string name, string savedAs)
		{
			this.CreateProductUsingTestCase75335(savedAs, name);
		}

		[StepDefinition(@"I create a product and take to completed using Test Case 75335 and save as: (.*)")]
		public void GivenICreateProductUsingTestCase75335(string savedAs)
		{
			this.CreateProductUsingTestCase75335(savedAs, "Chalk");
		}

		[StepDefinition(@"I create a new product of type: Bleach, with a Product Line/ Brand added")]
		public void CreateProductWithProductLineBrand()
		{
			TestReport.UseSubSteps = true;
			var sharedSteps = new Steps_Shared();
			var newProductSteps = new StepsNewProduct();
			// 57408 (Create a New Registration via Register New Product icon)
			TestReport.StartStep("I create a new registration with the beaker icon");
			sharedSteps.GivenICallSharedStepCreateANewRegistrationViaRegisterNewProductIcon();
			TestReport.StartStep("I should see the The Product Page");
			newProductSteps.GivenIShouldSeeXPage("The Product");
			var testCaseId = GlobalParameters.TestCaseId;
			if (testCaseId == null)
			{
				throw new Exception("Unable to locate a test case ID in global parameters which is required!");
			}

			TestReport.StartStep(
				"I set the Product Name as it a appears on the Package Label option to: Brand Product " + testCaseId);
			newProductSteps.SetTheSectionOptionTo("Product Name as it a appears on the Package Label",
				"Brand Product " + testCaseId);
			TestReport.StartStep(
				"In the Product Type tab of the New Product Page, I enter: Bleach in the Type of Product select field");
			newProductSteps.GivenInTheProductTypeTabOfTheNewProductPageIEnterXInTheTypeOfProductSelectField("Bleach");
			TestReport.StartStep(
				"I select the first option in the 'Product Line or Brand' drop down and save as: Brand" + testCaseId);
			newProductSteps.SelectFirstOptionInBrandDropDown();
			TestReport.StartStep("I click Continue");
			newProductSteps.ClickContinue();
			TestReport.StartStep("I save the product information as TestCase" + testCaseId);
			var prodDetails = new NewProduct().GetCurrentProductInformation();
			Context.AddToContext($"TestCase{testCaseId}", prodDetails);
			TestReport.StartStep("Navigate to the home page");
			new StepsHomepage().ThenINavigateToTheHomePage();
		}

		[StepDefinition(@"I take a product from completed to recertification using Test Case 75410 saved: (.*)")]
		public void TakeProductFromCompletedToRecertification(string savedAs)
		{
			TestReport.UseSubSteps = true;
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
				savedAs,"red");
			sharedSteps.GivenICallSharedStep51351SHASelectProductViewRecertificationHistoryForProductSavedAs(savedAs);

			TechTalk.SpecFlow.Table recertification = new TechTalk.SpecFlow.Table(new string[] {
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
			newProductSteps.GivenInTheNewProductPageIClickSection("Product Characteristics");
			newProductSteps.GivenIChangeTheSecondaryPhysicalStateDropDownFromItsCurrentSelectionToANewSelection();
			newProductSteps.ThenIClickSaveOrCancelInTheProductPage("Save");
			newProductSteps.GivenInTheNewProductPageIClickTab("Review and Submit");
			newProductSteps.GivenInTheNewProductPageIClickSection("Data Acceptance");
			newProductSteps.GivenInTheDataAcceptancePageIClickOnTheAcceptButton();
			newProductSteps.GivenIfPurchaseDetailsAreShowingClickConfirmOrder();
			thisStepsHomePage.ThenINavigateToTheHomePage();
			thisStepsProductGrid.GivenISearchForTheProductSavedAs(savedAs);
			//CLF 26 Oct 2018 This does not always seem to change immediately
			thisStepsProductGrid.GivenForProductSavedAsTestCaseTheStatusIs(savedAs, "Assessment in Progress");
			sharedSteps.GivenICallShared65080LoginToStudioAndOpenSHAManager();
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(savedAs,
				"Recertification");
			sharedSteps.GivenICallSharedStep51351SHASelectProductViewRecertificationHistoryForProductSavedAs(savedAs);

			TechTalk.SpecFlow.Table recertification2 = new TechTalk.SpecFlow.Table(new string[] {
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
		[Given(@"I create a product with name: (.*) and take to completed using Test Case 84108 and save as: (.*)")]
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

		[Given(@"I create a product with name: (.*) and take to completed using Test Case 84109 and save as: (.*)")]
		public void GivenITakeProductFromCompletedToRecertification84109(string name, string savedAs)
		{
			this.TakeProductFromCompletedToRecertification84109(savedAs, name);
		}

		[StepDefinition(@"I create a product and take to completed using Test Case 84109 and save as: (.*)")]
		public void GivenITakeProductFromCompletedToRecertification84109(string savedAs)
		{
			this.TakeProductFromCompletedToRecertification84109(savedAs, "Alkaline battery");
		}

		[Given(@"I call test stuff for saved as: (.*)")]
		public void GivenICallTestStuff(string savedAs)
		{
			Test(savedAs);
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
			TestReport.UseSubSteps = true;
			var sharedSteps = new Steps_Shared();
			var productsGridSteps = new StepsProductGrid();
			var newProductSteps = new StepsNewProduct();
			var newProduct = new NewProduct();
			var shaSteps = new Steps_SHA();
			var thisGlobalSteps = new GlobalSteps();
			thisGlobalSteps.NavigateToLandingPage();
			// Log in to administrator role
			//sharedSteps.GivenICallSharedStep67823LoginToWERCSmart_ProductsAutomationAccount();
			thisGlobalSteps.LoginToWERCSmartAdmin("WERCs Premium Subscription Account");
			// Generate UPC number and delete duplicates
			productsGridSteps.GivenIGenerateARandomUPCNumberAndSaveAs("UPC75335");
			productsGridSteps.DeleteAllProductsMatchingCriteria("UPC Number", "saved as UPC75335");
			// 57408 (Create a New Registration via Register New Product icon)
			sharedSteps.GivenICallSharedStepCreateANewRegistrationViaRegisterNewProductIcon();
			// 57500 (The Product- Enter name, select product type - Continue - Happy Path)
			sharedSteps.GivenICallSharedStepTheProduct_EnterNameSelectProductType_Continue_HappyPath("Chalk", name);
			// Save product to context
			newProductSteps.SaveProductInformation(savedAs);
			// 26897 (Product Characteristics - Solid only available - continue)
			sharedSteps.SharedProductCharacteristics_SolidOnlyAvailable_Continue();
			// 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
			sharedSteps.ICallSharedAdditionalProductInformationUSOnlyNoChildNoGHSNoDirectShipNoPLPNoGNFR();
			// 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
			sharedSteps.ICallSharedIngredients_AddAnyChemical("Sodium hydroxide");
			// 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
			sharedSteps.ICallSharedRegulatoryInformation1_TSCARandom_Pro65No_Continue();
			// 57510 \(Retailer Association - Select A Retailer - Continue - Happy Path\) and select the retailer: CVS
			sharedSteps.GivenICallSharedRetailerAssociation_SelectARetailer_Continue_HappyPath("CVS");
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
			sharedSteps.GivenICallShared55663WPSStudio_GoToJobQueue_WaitForPublishMultipleToComplete(savedAs);
			// 59066(Go to SHA Manager)
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
			TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
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
			var ID = ProductDetails.Id;
			StudioSHAManager myStudioShaManager = new StudioSHAManager();

			myStudioShaManager.ClickBottomMenuOption("Search");

			Steps_SHA myStepsSha = new Steps_SHA();
			string status = "Completed";
			TechTalk.SpecFlow.Table table = new TechTalk.SpecFlow.Table(new string[] {
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
			StudioSHAManager mySHAManager = new StudioSHAManager();
			mySHAManager.WaitForProductList(10);
			Product topProduct = new StudioSHAManager().GetTopXProducts(1).FirstOrDefault();

			if (topProduct == null || !(topProduct.Status == status && topProduct.ID == ID))
			{
				Report.Failure("Failed to create product and process through to completed.");
			}

		}

		[Given(@"I create a product with name: (.*) and take to completed using Test Case 84108 and save as: (.*)")]
		public void TakeProductFromCompletedToRecertification84108(string name, string savedAs)
		{
			if (Context.Contains("ElectronicProduct"))
			{
				Context.AddToContext("ElectronicProduct", "false");
			}

			TestReport.UseSubSteps = true;
			var sharedSteps = new Steps_Shared();
			var productsGridSteps = new StepsProductGrid();
			var newProductSteps = new StepsNewProduct();
			var newProduct = new NewProduct();
			var shaSteps = new Steps_SHA();
			var thisGlobalSteps = new GlobalSteps();
			thisGlobalSteps.NavigateToLandingPage();
			// Log in to administrator role
			//sharedSteps.GivenICallSharedStep67823LoginToWERCSmart_ProductsAutomationAccount();
			thisGlobalSteps.LoginToWERCSmartAdmin("WERCs Premium Subscription Account");
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
			//And I call Shared Step 26897 (Product Characteristics - Solid only available - continue)
			sharedSteps.SharedProductCharacteristics_SolidOnlyAvailable_Continue();
			//And I call Shared Step 57401 (Additional Product Information - US only - No GHS, Not Direct Ship, Not PLP, Not GNFR > Continue - Happy Path)
			sharedSteps.GivenICallSharedAdditionalProductInformation_USOnly_NoGHSNotDirectShipNotPLPNotGNFR_Continue();
			// 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
			sharedSteps.ICallSharedIngredients_AddAnyChemical("Sodium hydroxide");
			// 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
			sharedSteps.ICallSharedRegulatoryInformation1_TSCARandom_Pro65No_Continue();
			//And I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
			sharedSteps.ICallSharedRetailer_SelectNoRetailer_ClickDone();
			//Given I set the  field to: I do not have an OSHA-compliant SDS for this battery but do have a Technical Data Sheet(TDS) or Battery Data Sheet(BDS) and would like to upload it
			newProductSteps.SetTheSectionOptionTo("OSHA-compliant Safety Data Sheet, English",
				"I do not have an OSHA-compliant SDS for this battery but do have a Technical Data Sheet (TDS) or Battery Data Sheet (BDS) and would like to upload it");
			//And I call Shared Step 59042 (Browse for File > select > click Open - Happy Path) for document type: Technical Data Sheet(TDS) or Battery Data Sheet(BDS) and file: C:\Dependencies\WERCSmart\testdoc.pdf
			sharedSteps.ICallSharedBrowseForFileSelectClickOpen(
				"Technical Data Sheet (TDS) or Battery Data Sheet (BDS)", @"C:\Dependencies\WERCSmart\testdoc.pdf");
			//And I check the checkbox with description: I confirm that I have provided the most up-to-date, TDS/BDS in this product registration
			newProductSteps.ICheckTheCheckboxWithDescription("check",
				"I confirm that I have provided the most up-to-date, TDS/BDS in this product registration");
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
			TestReport.UseSubSteps = true;
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
			//And I call Shared Step 69687(Additional Product Information - US, No(PL))
			sharedSteps.GivenICallSharedStepAdditionalProductInformation_CountryAndPrivateLabelOrBrand_No();
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

		[Given(@"I take a product from completed to recertification using Test Case 84511 saved: (.*)")]
		public void GivenITakeAProductFromCompletedToRecertificationUsingTestCaseSavedTestCase(string savedAs)
		{
			TestReport.UseSubSteps = true;
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
			TechTalk.SpecFlow.Table recertification = new TechTalk.SpecFlow.Table(new string[] {
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
			//And In the New Product page I click tab: Product Characteristics
			newProductSteps.GivenInTheNewProductPageIClickTab("Product Characteristics");
			//And in the New Product page I click section: Toxicity Characteristic Leaching Procedure(TCLP)
			newProductSteps.GivenInTheNewProductPageIClickSection("Toxicity Characteristic Leaching Procedure (TCLP)");
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
			newProductSteps.GivenInTheNewProductPageIClickSection("Data Acceptance");
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
			TechTalk.SpecFlow.Table recertification2 = new TechTalk.SpecFlow.Table(new string[] {
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

		[Given(@"I create a product with name: (.*) and take to completed using Test Case 80821 and save as: (.*)")]
		public void GivenICreateAProductWithNameAndTakeToCompletedUsingTestCaseAndSaveAsTestCase(string productName,
			string savedAs)
		{
			TestReport.UseSubSteps = true;
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
			TechTalk.SpecFlow.Table table34 = new TechTalk.SpecFlow.Table(new string[] {
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
			stepsNewProductIngredients.IngredientsPageIConfirmThePublicallyDisclosedTotalDenominatorIsShowing("1", "1");
			//And In the Ingredients page I confirm the Publicly Disclosed Transparency score is flagged as a success
			stepsNewProductIngredients
				.IngredientsPageIConfirmThePubliclyDisclosedTransparencyScoreIsFlaggedRed("success");
			//And I call Shared Step 80822 - Ingredients - Add non-generic - specific component - set publicly disclosed and add public name and save ingredient as: Ing808212
			//| CASNumber  | ComponentName | Percentage | Publicly Disclosed | Public Name            |
			//| 37334-84-2 | Cellolyn 21   | 15         | No                 | Undisclosed Ingredient |
			TechTalk.SpecFlow.Table table35 = new TechTalk.SpecFlow.Table(new string[] {
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
			stepsNewProductIngredients.IngredientsPageIConfirmThePublicallyDisclosedTotalDenominatorIsShowing("1", "2");
			//And In the Ingredients page I confirm the Publicly Disclosed Transparency score is flagged as a warning
			stepsNewProductIngredients
				.IngredientsPageIConfirmThePubliclyDisclosedTransparencyScoreIsFlaggedRed("warning");
			//And I call Shared Step 79436 (Ingredients - Add FRAGRANCE component, Publicly Disclosed = Yes, Select Public Name) and save ingredient as: Ing808213
			//| CASNumber  | ComponentName    | Percentage |
			//| RR-38384-6 | FRAGRANCE-HERBAL | 10         |
			TechTalk.SpecFlow.Table table36 = new TechTalk.SpecFlow.Table(new string[] {
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
			stepsNewProductIngredients.IngredientsPageIConfirmThePublicallyDisclosedTotalDenominatorIsShowing("1", "3");
			//And In the Ingredients page I confirm the Publicly Disclosed Transparency score is flagged as a warning
			stepsNewProductIngredients
				.IngredientsPageIConfirmThePubliclyDisclosedTransparencyScoreIsFlaggedRed("warning");
			//And I call Shared Step 79436 (Ingredients - Add FRAGRANCE component, Publicly Disclosed = Yes, Select Public Name) and save ingredient as: Ing808214
			//| CASNumber  | ComponentName    | Percentage |
			//| RR-38213-8 | FRAGRANCE-BANANA | 10         |
			TechTalk.SpecFlow.Table table37 = new TechTalk.SpecFlow.Table(new string[] {
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
			stepsNewProductIngredients.IngredientsPageIConfirmThePublicallyDisclosedTotalDenominatorIsShowing("1", "4");
			//And In the Ingredients page I confirm the Publicly Disclosed Transparency score is flagged as a danger
			stepsNewProductIngredients
				.IngredientsPageIConfirmThePubliclyDisclosedTransparencyScoreIsFlaggedRed("danger");
			//And I call Shared Step 80822 - Ingredients - Add non-generic - specific component - set publicly disclosed and add public name and save ingredient as: Ing808215
			//| CASNumber | ComponentName    | Percentage | Publicly Disclosed | Public Name            |
			//| FLAVOR    | 611 Grape Flavor | 10         | No                 | Undisclosed Ingredient |
			TechTalk.SpecFlow.Table table38 = new TechTalk.SpecFlow.Table(new string[] {
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
			stepsNewProductIngredients.IngredientsPageIConfirmThePublicallyDisclosedTotalDenominatorIsShowing("1", "5");
			//And In the Ingredients page I confirm the Publicly Disclosed Transparency score is flagged as a danger
			stepsNewProductIngredients
				.IngredientsPageIConfirmThePubliclyDisclosedTransparencyScoreIsFlaggedRed("danger");
			//And I call Shared Step 80822 - Ingredients - Add non-generic - specific component - set publicly disclosed and add public name and save ingredient as: Ing808216
			//| CASNumber | ComponentName                 | Percentage | Publicly Disclosed | Public Name            |
			//| NA519     | Black Cherry - Natural Flavor | 10         | Yes                | Undisclosed Ingredient |
			TechTalk.SpecFlow.Table table39 = new TechTalk.SpecFlow.Table(new string[] {
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
			stepsNewProductIngredients.IngredientsPageIConfirmThePublicallyDisclosedTotalDenominatorIsShowing("2", "6");
			//And In the Ingredients page I confirm the Publicly Disclosed Transparency score is flagged as a warning
			stepsNewProductIngredients
				.IngredientsPageIConfirmThePubliclyDisclosedTransparencyScoreIsFlaggedRed("warning");
			//And I call Shared Step 79436 (Ingredients - Add FRAGRANCE component, Publicly Disclosed = Yes, Select Public Name) and save ingredient as: Ing808217
			//| CASNumber | ComponentName                                                                                                       | Percentage |
			//| FRAGRANCE | Fragrance - Birch Branch: Skin Irrit. 2, Eye Irrit. 2A, Skin Sens. 1, Repro Tox 2, Acute Aquatic 2, Chronic Acute 2 | 10         |
			TechTalk.SpecFlow.Table table40 = new TechTalk.SpecFlow.Table(new string[] {
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
			stepsNewProductIngredients.IngredientsPageIConfirmThePublicallyDisclosedTotalDenominatorIsShowing("2", "7");
			//And In the Ingredients page I confirm the Publicly Disclosed Transparency score is flagged as a warning
			stepsNewProductIngredients
				.IngredientsPageIConfirmThePubliclyDisclosedTransparencyScoreIsFlaggedRed("warning");
			//And I call Shared Step 80822 - Ingredients - Add non-generic - specific component - set publicly disclosed and add public name and save ingredient as: Ing808218
			//| CASNumber | ComponentName | Percentage | Publicly Disclosed | Public Name            |
			//| 7732-18-5 | Water         | 10         | Yes                | Undisclosed Ingredient |
			TechTalk.SpecFlow.Table table41 = new TechTalk.SpecFlow.Table(new string[] {
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
			stepsNewProductIngredients.IngredientsPageIConfirmThePublicallyDisclosedTotalDenominatorIsShowing("3", "8");
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
			newProductSteps.GivenInTheNewProductPageIClickContinue("Product aliases");
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
			TechTalk.SpecFlow.Table table42 = new TechTalk.SpecFlow.Table(new string[] {
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

			TechTalk.SpecFlow.Table table43 = new TechTalk.SpecFlow.Table(new string[] {
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
			TestReport.UseSubSteps = true;
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

			TechTalk.SpecFlow.Table table34 = new TechTalk.SpecFlow.Table(new string[] {
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

			TechTalk.SpecFlow.Table table36 = new TechTalk.SpecFlow.Table(new string[] {
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
			TechTalk.SpecFlow.Table table55 = new TechTalk.SpecFlow.Table(new string[] {
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
			sharedSteps.GivenICallSharedStepFormulationRdParty_AcceptFormulation_GrantTier_Continue();
			//And I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
			sharedSteps.GivenICallSharedEnterRegulatoryInformation_NotProp();
			//And I call Shared Step 60932 (Regulatory Information 2 - Microbeads - No)
		//	sharedSteps.SharedRegulatoryInformation2_Microbeads_No();
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
			newProductSteps.GivenInTheNewProductPageIClickContinue("Product aliases");
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
			//And In Power Designer I left click on section: [SECT0077] Walmart Transportation Information
			studioSteps.GivenInPowerDesignerIClickOnSection("left", "[SECT0077] Walmart Transportation Information");
			//And In Power Designer I double click on category: Water Soluble?
			studioSteps.GivenInPowerDesignerIDoubleClickOnCategory("Water Soluble?");
			//Then In Power Designer the phrase selector screen should open
			studioSteps.ThenInPowerDesignerThePhraseSelectorScreenShouldOpen();
			//And In the phrase selector screen I select phrases:
			//| Text |
			//| Y    |
			TechTalk.SpecFlow.Table table42 = new TechTalk.SpecFlow.Table(new string[] {
				"Text"
			});
			table42.AddRow(new string[] {
				"Y"
			});
			studioSteps.ThenInThePhraseSelectorScreenISelectPhrases(table42);
			//And In the phrase selector screen I click button: Save
			studioSteps.ThenInThePhraseSelectorScreenIClickButton("Save");

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
		[Given(@"I use Test case 77862 to create a kit and save as (.*)")]
		public void GivenIUseTestCaseToCreateAKitAndSaveAsTestCase(string saveAs)
		{
			TestReport.UseSubSteps = true;
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
				TestReport.StartStep("Beginning create kit 1");
				CreateProductUsingTestCase75335Walmart("77862_KitProduct1");
				thisGlobalSteps.NavigateToLandingPage();
			}

			if (!Context.Contains("77862_KitProduct2"))
			{
				TestReport.StartStep("Beginning create kit 2");
				CreateProductUsingTestCase75335Walmart("77862_KitProduct2");
				thisGlobalSteps.NavigateToLandingPage();
			}

			//And I call Shared Step 67823(Login to WERCSmart - Products Automation Account)
			sharedSteps.Shared68210_LoginToWercSmart_PremiumAccount();

			// Generate UPC number and delete duplicates
			productsGridSteps.GivenIGenerateARandomUPCNumberAndSaveAs("UPC77862");
			productsGridSteps.DeleteAllProductsMatchingCriteria("UPC Number", "saved as UPC77862");


			//And I call Shared Step 57753(Create a New Registration via Register New Product(expanded menu))
			sharedSteps.GivenICallSharedCreateANewRegistrationViaRegisterNewProductExpandedMenu();
			//And I In the shared step below use any of the kit product types -these are* Cosmetic Products in a kit(RU000777)*Hair Care kit(RU000723)*Hair Color Kit(RU000724)*Emergency Road kit(RU000718)*Automotive Care Products(RU000124)*Personal Care kit(RU001034)
			//And I call Shared Step 57500(The Product - Enter name, select product type - Continue - Happy Path): (.*)
			sharedSteps.GivenICallSharedStepTheProduct_EnterNameSelectProductType_Continue_HappyPath(
				"Emergency Road kit", "Kit" + System.DateTime.Now.DayOfWeek + System.DateTime.Now.Hour + System.DateTime.Now.Minute + System.DateTime.Now.Second);
			//And I call Shared Step 77872(Additional Product Information - Kit flow - US only, Direct Ship(yes), Continue)
			newProductSteps.SaveProductInformation(saveAs);
			sharedSteps.Shared77872_AdditionalProductInformation_KitFlow_UsOnly_DirectShip_Yes_Continue();
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
			TestReport.UseSubSteps = true;
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
			// 26897 (Product Characteristics - Solid only available - continue)
			sharedSteps.SharedProductCharacteristics_SolidOnlyAvailable_Continue();
			// 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
			sharedSteps.ICallSharedAdditionalProductInformationUSOnlyNoChildNoGHSNoDirectShipNoPLPNoGNFR();
			// 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
			sharedSteps.ICallSharedIngredients_AddAnyChemical("Sodium hydroxide");
			// 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
			sharedSteps.ICallSharedRegulatoryInformation1_TSCARandom_Pro65No_Continue();
			//And I call Shared Step 75146(Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue)
			TechTalk.SpecFlow.Table retailerTable = new TechTalk.SpecFlow.Table(new string[] {
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

		[Given(@"I Use Test case 84518 to process the product from Assigned back to Completed status saved as (.*)")]
		public void GivenIUseTestCaseToProcessTheProductFromAssignedBackToCompletedStatusSavedAsTestCase(string savedAs)
		{
			ProcessAssignedFormulatedProductBackToCompletedUsingTestCase84518(savedAs);
		}



		public void ProcessAssignedFormulatedProductBackToCompletedUsingTestCase84518(string savedAs)
		{
			Steps_Shared sharedSteps = new Steps_Shared();

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
			//TestReport.StartStep("I click the Document queue icon in the tool bar");
			Steps_Studio thisStepsStudio = new Steps_Studio();
			thisStepsStudio.GivenInPowerDesignerPlusPageInMyToolbarTabIClickOnDocumentQueueButton();
			TestReport.StartStep("I click the filter icon");
			thisStepsStudio.InDocumentQueuePopupIClickOnFilterIcon();
			var productDetails = (ProductInformation)Context.GetFromContext(savedAs);
			var id = productDetails.Id;
			thisStepsStudio.InDocumentQueueFilterPageIEnterValueInSelectBox("Matches", @"Product\Alias");
			TestReport.StartStep("I enter the product id in the Product/Alias area of the filter and click Apply");
			thisStepsStudio.InDocumentQueueFilterPageIEnterValueInEntryBox(id, @"Product\Alias");
			thisStepsStudio.InDocumentQueueFilterPageIClickOnApply();

			for (int i = 0; i < 5; i++)
			{
				Delay.Seconds(5);
				Report.Screenshot();
				DocumentQueuePage newDocumentQueuePage = new DocumentQueuePage();
				Report.IsTrue(newDocumentQueuePage.Wait_for_load(30), "Document queue page failed to load",
					"Document queue page loaded");
				List<Document> listOfDocuments = newDocumentQueuePage.GetAllDocuments();
				if (listOfDocuments.Count > 0)
				{
					break;
				}
			}

			TestReport.StartStep(
				"I confirm the product is shown with entries for SBCS EN PDF, NGHS EN PDF, NGHS EN RTF, CKLT EN PDF");
			TechTalk.SpecFlow.Table tblCheckDocument = new TechTalk.SpecFlow.Table(new string[] {
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
			TestReport.StartStep("I click Process Documents");
			thisStepsStudio.InDocumentQueueFilterPageIClickOnProcessDocuments();
			Delay.Seconds(2);
			Report.Screenshot();
			GeneralUtilities.StudioWaitForSpinner(60);
			TestReport.StartStep(
				"I confirm a pop up shows with message indicating 4 queued documents were sent for publishing");
			thisStepsStudio.IShouldSeeAnAlertAsFollows("queued document(s) were sent for publishing.");
			TestReport.StartStep("I click OK ");
			thisStepsStudio.ICloseAlert();
			TestReport.StartStep("I close the Document queue window");
			thisStepsStudio.InDocumentQueueFilterPageIClickOnClose();

			// And I call Shared Step 55663(WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: (.*))
			sharedSteps.GivenICallShared55663WPSStudio_GoToJobQueue_WaitForPublishMultipleToComplete(savedAs);
			// 59066(Go to SHA Manager)
			sharedSteps.GivenICallSharedStep59066GoToSHAManager();
			// 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase75335)
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			//And I Depending in the retailers you selected your product will be shown in the Accepted or Completed status.If any retailer is shown in Accepted use the shared step below to set to Completed
			Steps_SHA shaSteps = new Steps_SHA();
			TestReport.StartStep("Depending in the retailers you selected your product will be shown in the Accepted or Completed status");
			shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(savedAs, "Accepted or Completed");

			var currentStatus = new StudioSHAManager().GetproductStatus(id).StatusName;

			if (currentStatus == "Accepted")
			{
				// 51664 (SHA - Accepted Product - set Retailers to Completed for saved as: TestCase75335)
				TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
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
			// 26897 (Product Characteristics - Solid only available - continue)
			sharedSteps.SharedProductCharacteristics_SolidOnlyAvailable_Continue();
			//And I call Shared Step 78879 - Additional Product Information -Canada Only - Child(NO), GHS(NO), DSV(NO), PLP(NO), GNFR(NO), Continue
			sharedSteps.ThenICallSharedStep78879AdditionalProductInformation_CanadaOnly_ChildNOGHSNODSVNOPLPNOGNFRNOContinue();
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
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			// In the SHA manager grid I see the WPS ID I have saved as product: TestCase75335 and its status is: Accepted
			shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(savedAs,
				"Completed");

		}

	}

}
