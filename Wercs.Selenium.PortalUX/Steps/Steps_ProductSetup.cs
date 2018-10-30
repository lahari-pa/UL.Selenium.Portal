using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using Castle.Core.Internal;
using NPOI.SS.Formula.Functions;
using ResourcePool;
using SafewareReporting;
using SeleniumUtilities;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Wercs.Selenium.PortalUX.Selenium_Classes;
using WERCSmart;

namespace Wercs.Selenium.PortalUX.Steps
{
	[Binding, Scope(Tag = "ProductSetUp")]
	class Steps_ProductSetup : TechTalk.SpecFlow.Steps
	{
		[StepDefinition(@"I create a product and take to completed using Test Case 75335 \(SOLD set to US only with Walmart as retailer\) and save as: (.*)")]
		public void CreateProductUsingTestCase75335Walmart(string savedAs)
		{
			var sharedSteps = new Steps_Shared();
			var productsGridSteps = new StepsProductGrid();
			var newProductSteps = new StepsNewProduct();
			var newProduct = new NewProduct();
			var shaSteps = new Steps_SHA();
			// Log in to administrator role
			sharedSteps.GivenICallSharedStep67823LoginToWERCSmart_ProductsAutomationAccount();
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
			sharedSteps.GivenICallSharedEnterUniversalProductCodeUPC_UPC_ContainerType_SizeOnly("75335", "Metal Container", "40");
			// 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
			sharedSteps.GivenICallSharedRegulatoryDocumentsToProvide_USOnly_RequestAuthoring_HappyPath();
			// Click continue
			newProductSteps.ClickContinue();
			// Click continue
			newProductSteps.ClickContinue();
			// 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
			var sdsTable = new Table("Personal Protection Equipment", "Autoignition Temperature", "Minimum Ignition Energy", "Viscosity", "Appearance", "Odor", "Odor Threshold", "Partition Coefficient");
			sdsTable.AddRow("Mask", "300", "1", "20", "Black", "Odorless", "No data available", "10");
			sharedSteps.GivenICallSharedSafetyDataSheetAuthoring_AditionalDataStep_AddAnyRandomDataForAllFields_HappyPath(sdsTable);
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
			shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIsAssigned(savedAs, "Submitted");
			// 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase75335)
			sharedSteps.GivenICallSharedSHAManager_Submitted_SelectProductProcessProductData(savedAs);
			// 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase75335)
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			// In the SHA manager grid I see the WPS ID I have saved as product: TestCase75335 and its status is: Assigned
			shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIsAssigned(savedAs, "Assigned");
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
			shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIsAssigned(savedAs, "Accepted");
			// 49841 (SHA - Search for exact WPS ID in Accepted Status for saved as: TestCase75335)
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("Accepted", savedAs);
			// 51664 (SHA - Accepted Product - set Retailers to Completed for saved as: TestCase75335)
			TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
				"Retailer"});
			table4.AddRow(new string[] {
				"CVS"});
			sharedSteps.GivenICallShared51664SHA_AcceptedProduct_SetRetailersToCompletedForSavedAs(savedAs, table4);
			// 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase75335)
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			// In the SHA manager grid I see the WPS ID I have saved as product: TestCase75335 and its status is: Completed
			shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIsAssigned(savedAs, "Completed");
		}

		[Given(@"I create a product with name: (.*) and take to completed using Test Case 75335 and save as: (.*)")]
		public void GivenICreateAProductWithNameAndTakeToCompletedUsingTestCase75335(string name, string savedAs)
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
			TestReport.StartStep("I set the Product Name as it a appears on the Package Label option to: Brand Product " + testCaseId);
			newProductSteps.SetTheSectionOptionTo("Product Name as it a appears on the Package Label",
				"Brand Product " + testCaseId);
			TestReport.StartStep("In the Product Type tab of the New Product Page, I enter: Bleach in the Type of Product select field");
			newProductSteps.GivenInTheProductTypeTabOfTheNewProductPageIEnterXInTheTypeOfProductSelectField("Bleach");
			TestReport.StartStep("I select the first option in the 'Product Line or Brand' drop down and save as: Brand" + testCaseId);
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
			newProductSteps.GivenIShouldSeeXPage("The Product");
			newProductSteps.ThenIClickSaveOrCancelInTheProductPage("Save");
			sharedSteps.GivenICallShared65080LoginToStudioAndOpenSHAManager();
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIsAssigned(savedAs, "Completed");
			shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsAndItsFontIsRedIndicatingARecertification(savedAs);
			sharedSteps.GivenICallSharedStep51351SHASelectProductViewRecertificationHistoryForProductSavedAs(savedAs);

			TechTalk.SpecFlow.Table recertification = new TechTalk.SpecFlow.Table(new string[] {
				"Product ID",
				"Active",
				"Recertification Reason"});
			recertification.AddRow(new string[] {
				"saved as " + savedAs,
				"true",
				"Recertification of Product by WERCSmart Customer"});
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
			shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIsAssigned(savedAs, "Recertification");
			sharedSteps.GivenICallSharedStep51351SHASelectProductViewRecertificationHistoryForProductSavedAs(savedAs);

			TechTalk.SpecFlow.Table recertification2 = new TechTalk.SpecFlow.Table(new string[] {
				"Product ID",
				"Active",
				"Recertification Reason"});
			recertification2.AddRow(new string[] {
				"saved as " + savedAs,
				"false",
				"Recertification of Product by WERCSmart Customer"});
			shaSteps.GivenInTheProductRecertificationHistoryPopupIShouldSeeTheFollowingEntry(recertification2);
			shaSteps.GivenICloseTheProductRecertificationHistoryPopUp();

		}

		[Given(@"I create a product with name: (.*) and take to completed using Test Case 84108 and save as: (.*)")]
		public void GivenICreateAProductWithNameAndTakeToCompletedUsingTestCaseAndSaveAsTestCase(string name, string savedAs)
		{
			TakeProductFromCompletedToRecertification84108(savedAs, name);
		}

		[StepDefinition(@"I create a product and take to completed using Test Case 84108 and save as: (.*)")]
		public void TakeProductFromCompletedToRecertification84108(string savedAs, string name = "Alkaline battery")
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
			sharedSteps.GivenICallSharedStep67823LoginToWERCSmart_ProductsAutomationAccount();
			// Generate UPC number and delete duplicates
			productsGridSteps.GivenIGenerateARandomUPCNumberAndSaveAs("UPC84108");
			productsGridSteps.DeleteAllProductsMatchingCriteria("UPC Number", "saved as UPC84108");
			//And I call Shared Step 57753 (Create a New Registration via Register New Product(expanded menu))
			sharedSteps.GivenICallSharedCreateANewRegistrationViaRegisterNewProductExpandedMenu();
			//And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Alkaline battery
			sharedSteps.GivenICallSharedStepTheProduct_EnterNameSelectProductType_Continue_HappyPath("Alkaline battery", name);
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
			newProductSteps.SetTheSectionOptionTo("OSHA-compliant Safety Data Sheet, English", "I do not have an OSHA-compliant SDS for this battery but do have a Technical Data Sheet (TDS) or Battery Data Sheet (BDS) and would like to upload it");
			//And I call Shared Step 59042 (Browse for File > select > click Open - Happy Path) for document type: Technical Data Sheet(TDS) or Battery Data Sheet(BDS) and file: C:\Dependencies\WERCSmart\testdoc.pdf
			sharedSteps.ICallSharedBrowseForFileSelectClickOpen("Technical Data Sheet (TDS) or Battery Data Sheet (BDS)", @"C:\Dependencies\WERCSmart\testdoc.pdf");
			//And I check the checkbox with description: I confirm that I have provided the most up-to-date, TDS/BDS in this product registration
			newProductSteps.ICheckTheCheckboxWithDescription("check", "I confirm that I have provided the most up-to-date, TDS/BDS in this product registration");
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
			shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIsAssigned(savedAs, "Submitted");
			// 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase75335)
			sharedSteps.GivenICallSharedSHAManager_Submitted_SelectProductProcessProductData(savedAs);
			// 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase75335)
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			// In the SHA manager grid I see the WPS ID I have saved as product: TestCase75335 and its status is: Assigned
			shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIsAssigned(savedAs, "Assigned");
			// 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase75335)
			sharedSteps.GivenICallSharedWPSStudio_JobQueue_WaitForImportProcessRulesJobToComplete(savedAs);
			// 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase75335)
			sharedSteps.GivenICallSharedWPSStudio_OpenPDEditExistingWithSpecificProductClickContinue(savedAs);
			//And I call Shared Step 79500(WPS Studio - PD + -set all data and publish using rule and doc queue -CKLT and SBCS only) for product saved as: TestCase84108
			sharedSteps.GivenICallSharedStep79500WPSStudio_PD_SetAllDataAndPublishUsingRuleAndDocQueue_CKLTAndSBCSOnly(savedAs);
			// 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase75335)
			sharedSteps.GivenICallShared55663WPSStudio_GoToJobQueue_WaitForPublishMultipleToComplete(savedAs);
			// 59066(Go to SHA Manager)
			sharedSteps.GivenICallSharedStep59066GoToSHAManager();
			// 49841 (SHA - Search for exact WPS ID in All Status for saved as: X)
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			Report.Info(
				"the SHA manager grid I see the WPS ID I have saved as product: X and its status is: Completed");
			shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIsAssigned(savedAs, "Completed");

		}

		[Given(@"I create a product with name: (.*) and take to completed using Test Case 84109 and save as: (.*)")]
		public void GivenICreateAProductWithNameAndTakeToCompletedUsing84109(string name, string savedAs)
		{
			TakeProductFromCompletedToRecertification84109(savedAs, name);
		}


		[StepDefinition(@"I create a product and take to completed using Test Case 84109 and save as: (.*)")]
		public void TakeProductFromCompletedToRecertification84109(string savedAs, string name = "Alkaline battery")
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
			//And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Alkaline battery
			sharedSteps.GivenICallSharedStepTheProduct_EnterNameSelectProductType_Continue_HappyPath("Alkaline battery", name);
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
			shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIsAssigned(savedAs, "Submitted");
			// 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase75335)
			sharedSteps.GivenICallSharedSHAManager_Submitted_SelectProductProcessProductData(savedAs);
			// 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase75335)
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			// In the SHA manager grid I see the WPS ID I have saved as product: TestCase75335 and its status is: Assigned
			shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIsAssigned(savedAs, "Assigned");
			// 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase75335)
			sharedSteps.GivenICallSharedWPSStudio_JobQueue_WaitForImportProcessRulesJobToComplete(savedAs);

			//# Note: In Staging and Production - Electronic products are automatically published by the ImportProcessRules so if you are running in either of these sites you can skip to step 28
			//And I check whether the current environment is Staging or Production and if it is I skip the next three steps
			stepsStudio.GivenICheckWhetherTheCurrentEnvironmentIsStagingOrProductionAndIfItIsISkipTheNextThreeSteps();
			// 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: X)
			sharedSteps.GivenICallSharedWPSStudio_OpenPDEditExistingWithSpecificProductClickContinue(savedAs);
			//And I call Shared Step 79500(WPS Studio - PD + -set all data and publish using rule and doc queue -CKLT and SBCS only) for product saved as: TestCase84108
			sharedSteps.GivenICallSharedStep79500WPSStudio_PD_SetAllDataAndPublishUsingRuleAndDocQueue_CKLTAndSBCSOnly(savedAs);
			// 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase75335)
			sharedSteps.GivenICallShared55663WPSStudio_GoToJobQueue_WaitForPublishMultipleToComplete(savedAs);
			// 59066(Go to SHA Manager)
			sharedSteps.GivenICallSharedStep59066GoToSHAManager();
			// 49841 (SHA - Search for exact WPS ID in All Status for saved as: X)
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			Report.Info(
				"the SHA manager grid I see the WPS ID I have saved as product: X and its status is: Completed");
			shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIsAssigned(savedAs, "Completed");

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
			sharedSteps.GivenICallSharedStep67823LoginToWERCSmart_ProductsAutomationAccount();
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
			sharedSteps.GivenICallSharedEnterUniversalProductCodeUPC_UPC_ContainerType_SizeOnly("75335", "Metal Container", "40");
			// 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
			sharedSteps.GivenICallSharedRegulatoryDocumentsToProvide_USOnly_RequestAuthoring_HappyPath();
			// Click continue
			newProductSteps.ClickContinue();
			// Click continue
			newProductSteps.ClickContinue();
			// 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
			var sdsTable = new Table("Personal Protection Equipment", "Autoignition Temperature", "Minimum Ignition Energy", "Viscosity", "Appearance", "Odor", "Odor Threshold", "Partition Coefficient");
			sdsTable.AddRow("Mask", "300", "1", "20", "Black", "Odorless", "No data available", "10");
			sharedSteps.GivenICallSharedSafetyDataSheetAuthoring_AditionalDataStep_AddAnyRandomDataForAllFields_HappyPath(sdsTable);
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
			shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIsAssigned(savedAs, "Submitted");
			// 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase75335)
			sharedSteps.GivenICallSharedSHAManager_Submitted_SelectProductProcessProductData(savedAs);
			// 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase75335)
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			// In the SHA manager grid I see the WPS ID I have saved as product: TestCase75335 and its status is: Assigned
			shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIsAssigned(savedAs, "Assigned");
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
			shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIsAssigned(savedAs, "Accepted");
			Report.Info("49841 (SHA - Search for exact WPS ID in Accepted Status for saved as: TestCase75335)");
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("Accepted", savedAs);
			Report.Info("51664 (SHA - Accepted); Product - set Retailers to Completed for saved as: TestCase75335)");
			TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
				"Retailer"});
			table4.AddRow(new string[] {
				"CVS"});
			sharedSteps.GivenICallShared51664SHA_AcceptedProduct_SetRetailersToCompletedForSavedAs(savedAs, table4);
			Report.Info("(SHA - Search for exact WPS ID in All Status for saved as: TestCase75335)");
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			Report.Info("In the SHA manager grid I see the WPS ID I have saved as product: TestCase75335 and its status is: Completed");
			shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIsAssigned(savedAs, "Completed");
			var ProductDetails = (ProductInformation)Context.GetFromContext(savedAs);
			var ID = ProductDetails.Id;
			StudioSHAManager myStudioShaManager = new StudioSHAManager();

			myStudioShaManager.ClickBottomMenuOption("Search");

			Steps_SHA myStepsSha = new Steps_SHA();
			string status = "Completed";
			TechTalk.SpecFlow.Table table = new TechTalk.SpecFlow.Table(new string[] {
				"SearchTerm",
				"SearchValue"});
			table.AddRow(new string[] {
				"ProductID",
				ID});
			table.AddRow(new string[] {
				"Status",
				status});
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
	}
}
