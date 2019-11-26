using NTTQA.Selenium.Classes;
using NTTQA.Selenium.Reporting.Core;
using NTTQA.Selenium.SpecFlow;
using TechTalk.SpecFlow;
using System.Collections.Generic;
using TestStack.White.UIItems.TabItems;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;
using UL.Selenium.Portal.WERCSmart.Steps.New_Product;
using UL.Selenium.Portal.WERCSmart.Steps.New_Product.Product_Type;
using Castle.Core.Internal;

namespace UL.Selenium.Portal.WERCSmart.Steps
{
	[Binding, Scope(Tag = "CreateProducts")]
	class Steps_CreateProduct : TechTalk.SpecFlow.Steps
	{
		[StepDefinition(@"I create an electronic product for ItemSync and save it as: (.*), with UPC: (.*)")]
		public void GivenICreateAnElectronicProductForItemSyncPartOne(string saveAs)
		{
			TestReport.UseSubSteps = true;
			var MyStepsShared = new Steps_Shared();
			var MyStepsNewProduct = new StepsNewProduct();
			var MyStepsSHA = new Steps_SHA();
			var MyStepsStudio = new Steps_Studio();
			var MyStepsAPI = new API.Steps_Api();

			//Login, start creation
			MyStepsShared.GivenICallSharedStep67823LoginToWERCSmart_ProductsAutomationAccount();
			MyStepsShared.GivenICallSharedStepCreateANewRegistrationViaRegisterNewProductIcon();
			MyStepsShared.GivenICallSharedStepTheProduct_EnterNameSelectProductType_Continue_HappyPath("Answering machine, No battery included");
			MyStepsNewProduct.SaveProductInformation(saveAs);
			MyStepsShared.GivenICallSharedStepAdditionalProductInformation_CountryAndPrivateLabelOrBrand_No();
			MyStepsShared.ICallSharedRegulatoryInformation1_TSCARandom_Pro65No_Continue();
			MyStepsShared.GivenICallSharedStepToxicityCharacteristicsLeachingProcedureTCLP_NoToALLWithCopper();
			MyStepsShared.GivenICallSharedStepAnswerElectronicEquipmentQuestions_WithoutCathodeRay_NoToAll();
			MyStepsShared.ICallSharedRetailer_SelectNoRetailer_ClickDone();
			MyStepsNewProduct.GivenIShouldSeeXPage("Additional Documents to Provide");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Additional Documents to Provide");
			MyStepsNewProduct.GivenIShouldSeeXPage("Optional Reports and Documents Available for Purchase");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Optional Reports and Documents Available for Purchase");
			MyStepsShared.GivenICallSharedCommentsHappyPath("test");
			MyStepsShared.GivenICallSharedDataAcceptance_ClickAccept_HappyPath();
			MyStepsNewProduct.GivenIfPurchaseDetailsAreShowingClickConfirmOrder();
			MyStepsShared.GivenICallShared65080LoginToStudioAndOpenSHAManager();
			// Product is created
		}

		[StepDefinition(@"I move the product saved as (.*) created for ItemSync from Submitted to Completed")]
		public void GivenICreateAnElectronicProductForItemSyncPartTwo(string saveAs)
		{
			TestReport.UseSubSteps = true;
			var MyStepsShared = new Steps_Shared();
			var MyStepsSHA = new Steps_SHA();
			var MyStepsStudio = new Steps_Studio();
			var MyStepsAPI = new API.Steps_Api();

			Report.Info("Given I call Shared Step 49841(SHA - Search for exact WPS ID in All Status for saved as: " + saveAs + ")");
			MyStepsShared.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("Submitted", saveAs);
			Report.Info("Given In the SHA manager grid I see the WPS ID I have saved as product: " + saveAs + " and its status is: Submitted");
			MyStepsSHA.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(saveAs, "Submitted");
			Report.Info("Given I call Shared Step 40657(SHA Manager - Submitted - Select product > process product data for product saved as: " + saveAs + ")");
			MyStepsShared.GivenICallSharedSHAManager_Submitted_SelectProductProcessProductData(saveAs);
			Report.Info("Given I call Shared Step 49841(SHA - Search for exact WPS ID in All Status for saved as: " + saveAs + ")");
			MyStepsShared.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", saveAs);
			Report.Info("Given In the SHA manager grid I see the WPS ID I have saved as product: " + saveAs + " and its status is: Assigned");
			MyStepsSHA.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(saveAs, "Assigned");
			Report.Info("And I call Shared Step 55662(WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: " + saveAs + ")");
			MyStepsShared.GivenICallSharedWPSStudio_JobQueue_WaitForImportProcessRulesJobToComplete(saveAs);
			Report.Info("And I check whether the current environment is Staging or Production and if it is I skip the next three steps");
			MyStepsStudio.GivenICheckWhetherTheCurrentEnvironmentIsStagingOrProductionAndIfItIsISkipTheNextThreeSteps();
			Report.Info("And I call Shared Step 68969(WPS Studio - Open PD +, edit existing with specific product > Click Continue for product saved as: " + saveAs + ")");
			MyStepsShared.GivenICallSharedWPSStudio_OpenPDEditExistingWithSpecificProductClickContinue(saveAs);
			Report.Info("And I call Shared Step 79500(WPS Studio - PD + -set all data and publish using rule and doc queue -CKLT and SBCS only) for product saved as: " + saveAs);
			MyStepsShared.GivenICallSharedStep79500WPSStudio_PD_SetAllDataAndPublishUsingRuleAndDocQueue_CKLTAndSBCSOnly(saveAs);
			Report.Info("And I call Shared Step 55663(WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: " + saveAs + ")");
			MyStepsShared.GivenICallShared55663WPSStudio_GoToJobQueue_WaitForPublishMultipleToComplete(saveAs);
			Report.Info("Given I call Shared Step 59066(Go to SHA Manager)");
			MyStepsShared.GivenICallSharedStep59066GoToSHAManager();
			Report.Info("Given I call Shared Step 49841(SHA - Search for exact WPS ID in All Status for saved as: " + saveAs + ")");
			MyStepsShared.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", saveAs);
			Report.Info("Given In the SHA manager grid I see the WPS ID I have saved as product: " + saveAs + " and its status is: Completed");
			MyStepsSHA.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(saveAs, "Completed");
		}

		[StepDefinition(@"I create an electronic product and save it as: (.*)")]
		public void GivenICreateAnElectronicProductAndSaveItAs(string saveAs)
		{
			TestReport.UseSubSteps = true;
			var MyStepsShared = new Steps_Shared();
			var MyStepsNewProduct = new StepsNewProduct();
			var MyStepsSHA = new Steps_SHA();
			var MyStepsStudio = new Steps_Studio();

			//And I call Shared Step 67823(Login to WERCSmart - Products Automation Account)
			MyStepsShared.GivenICallSharedStep67823LoginToWERCSmart_ProductsAutomationAccount();
			//And I call Shared Step 57408(Create a New Registration via Register New Product icon)
			MyStepsShared.GivenICallSharedStepCreateANewRegistrationViaRegisterNewProductIcon();
			//And I call Shared Step 57500(The Product - Enter name, select product type - Continue - Happy Path): Answering machine, No battery included
			MyStepsShared.GivenICallSharedStepTheProduct_EnterNameSelectProductType_Continue_HappyPath("Answering machine, No battery included");
			//Then I save the product information as: TestCase84109
			MyStepsNewProduct.SaveProductInformation(saveAs);
			//And I call Shared Step 69687(Additional Product Information - US, No(PL))
			MyStepsShared.GivenICallSharedStepAdditionalProductInformation_CountryAndPrivateLabelOrBrand_No();
			//And I call Shared Step 57503(Regulatory Information 1 - TSCA(Random) - Prop 65(No) - Continue - Happy Path)
			MyStepsShared.ICallSharedRegulatoryInformation1_TSCARandom_Pro65No_Continue();
			//And I call Shared Step 48369(Toxicity Characteristics Leaching Procedure(TCLP) - No to ALL With Copper)
			MyStepsShared.GivenICallSharedStepToxicityCharacteristicsLeachingProcedureTCLP_NoToALLWithCopper();
			//And I call Shared Step 71955(Answer Electronic Equipment questions - Without Cathode Ray - No to all)
			MyStepsShared.GivenICallSharedStepAnswerElectronicEquipmentQuestions_WithoutCathodeRay_NoToAll();
			//And I call Shared Step 29206(Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
			MyStepsShared.ICallSharedRetailer_SelectNoRetailer_ClickDone();
			//And I should see the Additional Documents to Provide Page
			//Given in the Additional Documents to Provide page I click Continue
			MyStepsNewProduct.GivenIShouldSeeXPage("Additional Documents to Provide");
			//Given in the Optional Reports and Documents Available for Purchase page I click Continue
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Additional Documents to Provide");
			MyStepsNewProduct.GivenIShouldSeeXPage("Optional Reports and Documents Available for Purchase");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Optional Reports and Documents Available for Purchase");
			//And I call Shared Step 57883(Comments - Happy Path) and enter the comment: test
			MyStepsShared.GivenICallSharedCommentsHappyPath("test");
			//And I call Shared Step 57885(Data Acceptance - Click Accept - Happy Path)
			MyStepsShared.GivenICallSharedDataAcceptance_ClickAccept_HappyPath();
			//Given If purchase details are showing click confirm order
			MyStepsNewProduct.GivenIfPurchaseDetailsAreShowingClickConfirmOrder();

			//Given I call Shared Step 65080(Login to Studio and Open SHA manager)
			MyStepsShared.GivenICallShared65080LoginToStudioAndOpenSHAManager();
			Report.Info(
				"Given I call Shared Step 49841(SHA - Search for exact WPS ID in All Status for saved as: " + saveAs + ")");
			MyStepsShared.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("Submitted", saveAs);
			Report.Info(
				"Given In the SHA manager grid I see the WPS ID I have saved as product: " + saveAs + " and its status is: Submitted");
			MyStepsSHA.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(saveAs, "Submitted");
			Report.Info(
				"Given I call Shared Step 40657(SHA Manager - Submitted - Select product > process product data for product saved as: " + saveAs + ")");
			MyStepsShared.GivenICallSharedSHAManager_Submitted_SelectProductProcessProductData(saveAs);
			Report.Info(
				"Given I call Shared Step 49841(SHA - Search for exact WPS ID in All Status for saved as: " + saveAs + ")");
			MyStepsShared.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", saveAs);
			Report.Info(
				"Given In the SHA manager grid I see the WPS ID I have saved as product: " + saveAs + " and its status is: Assigned");
			MyStepsSHA.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(saveAs, "Assigned");
			Report.Info(
				"And I call Shared Step 55662(WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: " + saveAs + ")");
			MyStepsShared.GivenICallSharedWPSStudio_JobQueue_WaitForImportProcessRulesJobToComplete(saveAs);
			//# Note: In Staging and Production - Electronic products are automatically published by the ImportProcessRules so if you are running in either of these sites you can skip to step 28
			Report.Info(
				"And I check whether the current environment is Staging or Production and if it is I skip the next three steps");
			MyStepsStudio.GivenICheckWhetherTheCurrentEnvironmentIsStagingOrProductionAndIfItIsISkipTheNextThreeSteps();
			Report.Info(
				"And I call Shared Step 68969(WPS Studio - Open PD +, edit existing with specific product > Click Continue for product saved as: " + saveAs + ")");
			MyStepsShared.GivenICallSharedWPSStudio_OpenPDEditExistingWithSpecificProductClickContinue(saveAs);
			Report.Info(
				"And I call Shared Step 79500(WPS Studio - PD + -set all data and publish using rule and doc queue -CKLT and SBCS only) for product saved as: " + saveAs);
			MyStepsShared.GivenICallSharedStep79500WPSStudio_PD_SetAllDataAndPublishUsingRuleAndDocQueue_CKLTAndSBCSOnly(saveAs);
			Report.Info(
				"And I call Shared Step 55663(WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: " + saveAs + ")");
			MyStepsShared.GivenICallShared55663WPSStudio_GoToJobQueue_WaitForPublishMultipleToComplete(saveAs);
			Report.Info(
				"Given I call Shared Step 59066(Go to SHA Manager)");
			MyStepsShared.GivenICallSharedStep59066GoToSHAManager();
			Report.Info(
				"Given I call Shared Step 49841(SHA - Search for exact WPS ID in All Status for saved as: " + saveAs + ")");
			MyStepsShared.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", saveAs);
			Report.Info(
				"Given In the SHA manager grid I see the WPS ID I have saved as product: " + saveAs + " and its status is: Completed");
			MyStepsSHA.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(saveAs, "Completed");


		}

		[StepDefinition(@"I create a kit component in completed status")]
		public void CreateKitComponentInCompletedStatus()
		{

		}

		/// <summary>
		/// Generates a random UPC and saves as UPC_{savedAs}
		/// brand = 'TestBrand' (should always exist in products account)
		/// retailer = Walmart/ SAM's club
		/// Saves product information (id) as: Kit_{savedAs}
		/// </summary>
		[StepDefinition(@"I create a Kit product and save details as: Kit_(.*)")]
		public void CreateAKitProduct(string savedAs)
		{
			if (Context.Contains($"Kit_{savedAs}"))
			{
				// search for UPC and save to context as UPC__{savedAs}
				//var id = Context.GetFromContext($"Kit_{savedAs}");
				// search
				new StepsProductGrid().GivenISearchForTheProductSavedAs(savedAs);
				// row action - view upcs
				new StepsProductGrid().WhenIClickRowActionsForTheFirstProductReturned();
				new StepsProductGrid().ClickRowAction("View UPCs");
				new GlobalSteps().SwitchToTabWithTitle("View UPCs");
				// save upc
				new Steps_ViewUpcs().SaveFirstUpcToContext($"UPC_{savedAs}");
				// switch tab
				new GlobalSteps().ThenCloseTheWindowThatOpened();
				return;
			}
			TestReport.UseSubSteps = true;
			var sharedSteps = new Steps_Shared();
			var productsGridSteps = new StepsProductGrid();
			var newProductSteps = new StepsNewProduct();
			var shaSteps = new Steps_SHA();
			var thisGlobalSteps = new GlobalSteps();
			if (!Context.Contains($"{savedAs}_KitProduct1"))
			{
				TestReport.StartStep("Beginning create kit 1");
				//new Steps_ProductSetup().CreateProductUsingTestCase75335Walmart($"KitProduct1_{savedAs}");
				new Steps_ProductSetup().CreateProductUsingTestCase75335($"KitProduct1_{savedAs}", "KitProduct1");
				thisGlobalSteps.NavigateToLandingPage();
			}
			if (!Context.Contains($"{savedAs}_KitProduct2"))
			{
				TestReport.StartStep("Beginning create kit 2");
				//new Steps_ProductSetup().CreateProductUsingTestCase75335Walmart($"KitProduct2_{savedAs}");
				new Steps_ProductSetup().CreateProductUsingTestCase75335($"KitProduct2_{savedAs}", "KitProduct2");
				thisGlobalSteps.NavigateToLandingPage();
			}
			sharedSteps.GivenICallSharedStep67823LoginToWERCSmart_ProductsAutomationAccount();
			// Generate UPC number and delete duplicates
			productsGridSteps.GivenIGenerateARandomUPCNumberAndSaveAs($"UPC_{savedAs}");
			productsGridSteps.DeleteAllProductsMatchingCriteria("UPC Number", $"saved as UPC_{savedAs}");
			//And I call Shared Step 57753(Create a New Registration via Register New Product(expanded menu))
			sharedSteps.GivenICallSharedCreateANewRegistrationViaRegisterNewProductExpandedMenu();
			//And I In the shared step below use any of the kit product types -these are* Cosmetic Products in a kit(RU000777)*Hair Care kit(RU000723)*Hair Color Kit(RU000724)*Emergency Road kit(RU000718)*Automotive Care Products(RU000124)*Personal Care kit(RU001034)
			//And I call Shared Step 57500(The Product - Enter name, select product type - Continue - Happy Path): (.*)

			// add brand
			//sharedSteps.GivenICallSharedStepTheProduct_EnterNameSelectProductType_Continue_HappyPath("Hair Color Kit", $"Kit Product {savedAs}");

			new Steps_TheProduct().SetProductNameProductTypeProductLine($"Kit Product {savedAs}", "Hair Color Kit", "TestBrand");
			//And I call Shared Step 77872(Additional Product Information - Kit flow - US only, Direct Ship(yes), Continue)
			newProductSteps.SaveProductInformation($"Kit_{savedAs}");
			// fix
			sharedSteps.Shared77872_AdditionalProductInformation_KitFlow_UsOnly_DirectShip_Yes_Continue();
			//And I call Shared Step 57503(Regulatory Information 1 - TSCA(Random) - Prop 65(No) - Continue - Happy Path)
			sharedSteps.ICallSharedRegulatoryInformation1_TSCARandom_Pro65No_Continue();
			//And I In the shared step below add the two completed products that you are working with
			//And I call Shared Step 31427(Create the Kit - Adding two products: product 1: (.*) and product 2: (.*))
			sharedSteps.Shared31427_CreateTheKit_AddingTwoProducts($"KitProduct1_{savedAs}", $"KitProduct2_{savedAs}");
			//And I call Shared Step 57506(Transportation Details 1 - Regulated for Transport(No) - Exemption(Random) - Continue - Happy Path)
			sharedSteps.GivenICallSharedTransportationDetails_RegulatedForTransportNo_ExemptionRandom_Continue_HappyPath();
			//And I call Shared Step 62536(Transportation Details 2 > I do not ship internationally > Continue - Happy Path)
			sharedSteps.SharedTransportationDetails2_DoNotShipInternationally_Continue();
			//And I call Shared Step 77845(Retailer - Select WM, Done, Select Vendor ID, Continue)
			sharedSteps.Shared77845_Retailer_SelectWM_Done_SelectVendorID_Continue();
			//And I call Shared Step 42759(Portal - UPC Page - add 1 UPC)
			sharedSteps.Shared42759a_Portal_UpcPage_AddUpcSavedAs($"UPC_{savedAs}");
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
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", $"Kit_{savedAs}");
			// In the SHA manager grid I see the WPS ID I have saved as product: TestCase75335 and its status is: Submitted
			shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(savedAs, "Submitted");
			//And I Confirm the Product ID: TestCase77862 is highlited yellow indicating that this is an e-comm/direct ship product
			shaSteps.ConfirmProductIdIsHighlightedYellow_EcommDirectShipProduct($"Kit_{savedAs}");

		}

		[StepDefinition(@"I search for product by name: (.*) and save the first grid item as: (.*)")]
		public void SearchProductAndSave(string name, string savedAs)
		{
			TestReport.UseSubSteps = true;
			TestReport.StartStep("Searching for product: " + name);
			var selProdGrid = new ProductsGrid {
				ProductIdField = name
			};
			GeneralUtilities.Wait_for_load_finish();
			ProductGridItem productElement = selProdGrid.FirstProductInGrid();
			if (productElement != null)
			{
				TestReport.StartStep("Saving the top product as: " + savedAs);
				Context.AddToContext(savedAs, productElement);
				Report.Info("Saved product to context");
			}
			else
			{
				Report.Info("No Product was found by name: " + name);
			}
			selProdGrid.ProductIdField = string.Empty;
		}

		[StepDefinition(@"I create a Completed product using Test Case 86187 \(SOLD = US and Canada, PL = Yes, Canadian Tire Retailer Product\)")]
		public void CreateProductUsing86187()
		{
			TestReport.UseSubSteps = true;
			TestReport.StartStep("I login into the WERCSmart Portal - Canada has all data account");
			new GlobalSteps().LoginToWERCSmart("Canada has all data account");
			TestReport.StartStep("I generate a random UPC number and save as: UPC86187");
			new StepsProductGrid().GivenIGenerateARandomUPCNumberAndSaveAs("UPC86187");
			TestReport.StartStep("I delete all products with UPC Number: saved as UPC86187");
			new StepsProductGrid().DeleteAllProductsMatchingCriteria("UPC Number", "saved as UPC86187");
			TestReport.StartStep("I call Shared Step 57408 (Create a New Registration via Register New Product icon)");
			new Steps_Shared().GivenICallSharedStepCreateANewRegistrationViaRegisterNewProductIcon();
			TestReport.StartStep("I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk");
			new Steps_Shared().GivenICallSharedStepTheProduct_EnterNameSelectProductType_Continue_HappyPath("Chalk");
			TestReport.StartStep("I save the product information as: TestCase86187");
			new StepsNewProduct().SaveProductInformation("TestCase86187");
			TestReport.StartStep("I call Shared Step 26897 (Product Characteristics - Solid only available - continue)");
			new Steps_Shared().SharedProductCharacteristics_SolidOnlyAvailable_Continue();
			TestReport.StartStep("I call Shared Step 85284 - Additional Product Information - US & Canada, Child (No), OSHA (No), DSV (No), PLP (YES), GNFR (No), Continue");
			new Steps_Shared().ThenICallSharedStep85284_AdditionalProductInformation_USCanadaChildNoOSHANoDSVNoPLPYESGNFRNoContinue();
			TestReport.StartStep("I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide");
			new Steps_Shared().ICallSharedIngredients_AddAnyChemical("Sodium hydroxide");
			TestReport.StartStep("I call Shared Step 57637 (Regulatory Information 1 - TSCA & CEPA shown, No to PROP 65 - Continue - Happy Path)");
			new Steps_Shared().ICallSharedRegulatoryInformation1_TSCAAndCEPAShown_NoToProp65();
			TestReport.StartStep("I call Shared Step 85990 - Retailers - PLP - Select one or more retailer and add PL information - Continue");
			var retailers = new Table("Retailer");
			retailers.AddRow("Canadian Tire");
			new Steps_Shared().ThenICallSharedStep_Retailers_PLP_SelectOneOrMoreRetailerAndAddPLInformation_Continue(retailers);
			TestReport.StartStep("I call Shared Step 75702 - UPC - Add UPC, Container type, Size and Package type (no retailer data needed) - Continue for UPC: saved as UPC86187, container type: Metal Container and size: 40");
			new Steps_Shared().ThenICallSharedStep75702_UPC_AddUPCContainerTypeSizeAndPackageTypeNoRetailerDataNeeded_Continue(
				"saved as UPC86187", "Metal Container", "40");
			TestReport.StartStep("I call Shared Step 78868 - Regulatory Documents to Provide - US and Canada - Request authoring for both");
			new Steps_Shared().ThenICallSharedStep78868_RegulatoryDocumentsToProvide_USAndCanada_RequestAuthoringForBoth();
			TestReport.StartStep("in the Additional Documents to Provide page I click Continue");
			new StepsNewProduct().GivenInTheNewProductPageIClickContinue("Additional Documents to Provide");
			TestReport.StartStep("in the Optional Reports and Documents Available for Purchase page I click Continue");
			new StepsNewProduct().GivenInTheNewProductPageIClickContinue("Optional Reports and Documents Available for Purchase");
			TestReport.StartStep("I call Shared Step 64097 - Additional Documents -> Contact Information - Add any Name, address, phone and emergency phone - Happy Path");
			new Steps_Shared().GivenICallSharedStep64097_AdditionalDocuments_ContactInformation_AddAnyNameAddressPhoneAndEmergencyPhone_HappyPath();
			TestReport.StartStep("I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:");
			var tableSds = new Table("Personal Protection Equipment", "Autoignition Temperature", "Minimum Ignition Energy", "Viscosity", "Appearance", "Odor", "Odor Threshold", "Partition Coefficient");
			tableSds.AddRow("Mask", "300", "1.005", "20", "Black", "Odorless", "No data available", "10");
			new Steps_Shared().GivenICallSharedSafetyDataSheetAuthoring_AditionalDataStep_AddAnyRandomDataForAllFields_HappyPath(
				tableSds);
			TestReport.StartStep("I call Shared Step 57883 (Comments - Happy Path) and enter the comment: test comment");
			new Steps_Shared().GivenICallSharedCommentsHappyPath("Test Comment");
			TestReport.StartStep("I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)");
			new Steps_Shared().GivenICallSharedDataAcceptance_ClickAccept_HappyPath();
			TestReport.StartStep("If purchase details are showing click confirm order");
			new StepsNewProduct().GivenIfPurchaseDetailsAreShowingClickConfirmOrder();
			TestReport.StartStep("I call Shared Step 65080 (Login to Studio and Open SHA manager)");
			new Steps_Shared().GivenICallShared65080LoginToStudioAndOpenSHAManager();
			TestReport.StartStep("I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase86187)");
			new Steps_Shared().GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", "TestCase86187");
			TestReport.StartStep("In the SHA manager grid I see the WPS ID I have saved as product: TestCase86187 and its status is: Submitted");
			new Steps_SHA().GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(
				"TestCase86187","Submitted");
			TestReport.StartStep("I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase86187)");
			new Steps_Shared().GivenICallSharedSHAManager_Submitted_SelectProductProcessProductData("TestCase86187");
			TestReport.StartStep("I call Shared Step 49841 (SHA - Search for exact WPS ID in Assigned Status for saved as: TestCase86187)");
			new Steps_Shared().GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("Assigned", "TestCase86187");
			TestReport.StartStep("In the SHA manager grid I see the WPS ID I have saved as product: TestCase86187 and its status is: Assigned");
			new Steps_SHA().GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(
				"TestCase86187", "Assigned");
			TestReport.StartStep("I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase86187)");
			new Steps_Shared().GivenICallSharedWPSStudio_JobQueue_WaitForImportProcessRulesJobToComplete("TestCase86187");
			TestReport.StartStep("I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase86187)");
			new Steps_Shared().GivenICallSharedWPSStudio_OpenPDEditExistingWithSpecificProductClickContinue("TestCase86187");
			TestReport.StartStep("I call Shared Step 78877 - WPS Studio - PD+ - set all data and publish using rule and doc queue - CKLT, NGHS, HSGH (EN and CF) and SBCS for saved as: TestCase86187");
			new Steps_Shared().GivenICallSharedStep_WPSStudio_PD_SetAllDataAndPublishUsingRuleAndDocQueue_CKLTNGHSHSGHENAndCFAndSBCS(
				"TestCase86187");
			TestReport.StartStep("I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase86187)");
			new Steps_Shared().GivenICallShared55663WPSStudio_GoToJobQueue_WaitForPublishMultipleToComplete("TestCase86187");
			TestReport.StartStep("I call Shared Step 59066 (Go to SHA Manager)");
			new Steps_Shared().GivenICallSharedStep59066GoToSHAManager();
			TestReport.StartStep("I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase86187)");
			new Steps_Shared().GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", "TestCase86187");
			TestReport.StartStep("In the SHA manager grid I see the WPS ID I have saved as product: TestCase86187 and its status is: Accepted or Completed");
			new Steps_SHA().GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(
				"TestCase86187", "Accepted or Completed");
			TestReport.StartStep("I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase86187)");
			new Steps_Shared().GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", "TestCase86187");
			TestReport.StartStep("I call Shared Step 51664 (SHA - Accepted Product - set Retailers to Completed for saved as: TestCase86187) for");
			var retailersTable = new Table("Retailer");
			retailersTable.AddRow("CVS");
			new Steps_Shared().GivenICallShared51664SHA_AcceptedProduct_SetRetailersToCompletedForSavedAs("TestCase86187", retailersTable);
			TestReport.StartStep("I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase86187)");
			new Steps_Shared().GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", "TestCase86187");
			TestReport.StartStep("In the SHA manager grid I see the WPS ID I have saved as product: TestCase86187 and its status is: Completed");
			new Steps_SHA().GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(
				"TestCase86187", "Completed");
		}

		[StepDefinition(@"For CVS I create a product of type: Health & Beauty \(RUCC0392\), save it as: (.*) and leave it in New Status")]
		public void ForCVSICreateProductOfTypeHealthBeautyAndLeaveAsNew(string savedAs)
		{
			TestReport.UseSubSteps = true;
			var sharedSteps = new Steps_Shared();
			var productsGridSteps = new StepsProductGrid();
			var newProductSteps = new StepsNewProduct();
			var newProduct = new NewProduct();
			var shaSteps = new Steps_SHA();
			var thisGlobalSteps = new GlobalSteps();
			var selectRetailers = new StepsSelectRetailers();
			var name = "Conditioner";

			productsGridSteps.GivenIGenerateARandomUPCNumberAndSaveAs("UPC75335");
			sharedSteps.GivenICallSharedStepCreateANewRegistrationViaRegisterNewProductIcon();
			sharedSteps.GivenICallSharedStepTheProduct_EnterNameSelectProductType_Continue_HappyPath("Conditioner", name);
			newProductSteps.SaveProductInformation(savedAs);
			sharedSteps.SharedProductCharacteristics_LiquidOnlyAvailable_EnterAllData_Continue();
			sharedSteps.SharedAdditionalProductInformation_US_No_Child_OSHA_DSV_Yes_PLP_No_GNFR();
			sharedSteps.ICallSharedIngredients_AddAnyChemical("Sodium hydroxide");
			sharedSteps.ICallSharedRegulatoryInformation1_TSCARandom_Pro65No_Continue();
			sharedSteps.GivenICallSharedRegulatoryInformation_DrugFactsPanel_NoneOfTheAbove_Continue_HappyPath();
			sharedSteps.ICallSharedTransportationDetails1_NotRegulated();
			Report.Info("(Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: CVS");
			var retailerTable = new Table("Retailer");
			retailerTable.AddRow("CVS");
			sharedSteps.ThenICallSharedStep_Retailers_PLP_SelectOneOrMoreRetailerAndAddPLInformation_Continue(retailerTable);


		



			sharedSteps.GivenICallSharedEnterUniversalProductCodeUPC_CVSUPC_ContainerType_SizeOnly("Metal Container", "40");
			//go back to homepage (products grid)
			new StepsHomepage().ThenINavigateToTheHomePage();
			new GlobalSteps().ThenTheHomeScreenShouldLoad();
		}

		[StepDefinition(@"For CVS I create a product of type: Toys \(RUCC0388\), save it as: (.*) and leave it in New Status")]
		public void ForCVSICreateProductOfTypeToysAndLeaveAsNew(string savedAs)
		{
			var sharedSteps = new Steps_Shared();
			var productsGridSteps = new StepsProductGrid();
			var newProductSteps = new StepsNewProduct();
			var newProduct = new NewProduct();
			var shaSteps = new Steps_SHA();
			var thisGlobalSteps = new GlobalSteps();
			var selectRetailers = new StepsSelectRetailers();

			sharedSteps.GivenICallSharedStepCreateANewRegistrationViaRegisterNewProductIcon();
			sharedSteps.GivenICallSharedStepTheProduct_EnterProductNameAndSelectTypeOfProduct("Fireworks");
			newProductSteps.SaveProductInformation(savedAs);
			sharedSteps.SharedProductCharacteristics_SolidOnlyAvailable_Continue();

			Table table63804 = new Table("Classified using OSHA (US) Globally Harmonized Standards (GHS)", "Shipped directly by supplier", "Private Label or Brand", "Good Not for resale");
			table63804.AddRow("No", "No", "No", "No");

			sharedSteps.ICallSharedStepAdditionalProductInformationEnterOptions(table63804);

			Table table57570 = new Table("ComponentName", "Percent", "PublicallyDisclosed", "TradeSecret", "PublicName");
			table57570.AddRow("Propane", "100", "false", "false", "");

			sharedSteps.GivenICallSharedStepEnterIngredients(table57570);
			sharedSteps.GivenICallSharedEnterRegulatoryInformation_YesToProp();
			sharedSteps.GivenICallSharedTransportationDetails1_YesOption_SelectDOTLimitedQuantity();
			sharedSteps.GivenICallSharedUSDepartmentofTransportationDOTClassification_EnterUN1950Aerosol_SelectData();
			Report.Info("Then I select a retailer");
			selectRetailers.SelectTheRetailer("CVS");
			newProductSteps.ClickContinue();
			sharedSteps.GivenICallSharedEnterUniversalProductCodeUPC_CVSUPC_ContainerType_SizeOnly("Metal Container", "40");
			//go back to homepage (products grid)
			new StepsHomepage().ThenINavigateToTheHomePage();
			new GlobalSteps().ThenTheHomeScreenShouldLoad();


		}


		[StepDefinition(@"For CVS I create a product of type: Artist Supply \(RUCC0384\), save it as: (.*) and leave it in New Status")]
		public void ForCVSICreateProductOfTypeArtistSupplyAndLeaveAsNew(string savedAs)
		{
			var sharedSteps = new Steps_Shared();
			var productsGridSteps = new StepsProductGrid();
			var newProductSteps = new StepsNewProduct();
			var newProduct = new NewProduct();
			var shaSteps = new Steps_SHA();
			var thisGlobalSteps = new GlobalSteps();
			var stepsIngredients = new StepsIngredients();
			var selectRetailers = new StepsSelectRetailers();

			sharedSteps.GivenICallSharedStepCreateANewRegistrationViaRegisterNewProductIcon();
			sharedSteps.GivenICallSharedStepTheProduct_EnterProductNameAndSelectTypeOfProduct("Artist's Solvent/Thinner");
			newProductSteps.SaveProductInformation(savedAs);

			Table table73629 = new Table("Secondary Physical State", "Specific Gravity", "pH", "Boiling Point (in Celsius)", "Flash Point (in Celsius)", "Flash Point Testing Method Used", "Select the best Water Solubility description");
			table73629.AddRow("Liquid", "2", "2", "2", "66", "Closed cup method", "Appreciable");

			sharedSteps.ICallSharedStepProductCharacteristicsWithBoilingPointPHFlashPoint(table73629);
			sharedSteps.GivenICallSharedStepAdditionalProductInformation_WithMarketedForUseByAChild_OSHA_PrivateLabel();

			Table tableIngredients = new Table("ComponentName", "Percent", "PublicallyDisclosed", "TradeSecret", "PublicName");
			tableIngredients.AddRow("Water", "100", "false", "false", "");

			stepsIngredients.AddIngredients(tableIngredients);
			newProductSteps.GivenInTheNewProductPageIClickContinue("New Product");
			sharedSteps.ICallSharedRegulatoryInformation1_TSCARandom_Pro65No_Continue();
			sharedSteps.GivenICallSharedTransportationDetails1_YesOption_SelectDOTLimitedQuantity();
			sharedSteps.GivenICallSharedUSDepartmentofTransportationDOTClassification_EnterUN1950Aerosol_SelectData();

			//var retailerTable = new Table("Retailer");
			//retailerTable.AddRow("CVS");
			//sharedSteps.ThenICallSharedStep_Retailers_PLP_SelectOneOrMoreRetailerAndAddPLInformation_Continue(retailerTable);



			Report.Info("Then I select a retailer");
			selectRetailers.SelectTheRetailer("CVS");
			newProductSteps.ClickContinue();


			sharedSteps.GivenICallSharedEnterUniversalProductCodeUPC_CVSUPC_ContainerType_SizeOnly("Metal Container", "40");
			//go back to homepage (products grid)
			new StepsHomepage().ThenINavigateToTheHomePage();
			new GlobalSteps().ThenTheHomeScreenShouldLoad();



		}

		[StepDefinition(@"For CVS I create a product of type: Cleaning Supply \(RUCC0397\), save it as: (.*) and leave it in New Status")]
		public void ForCVSICreateProductOfTypeCleaningSupplyAndLeaveAsNew(string savedAs)
		{
			var sharedSteps = new Steps_Shared();
			var productsGridSteps = new StepsProductGrid();
			var newProductSteps = new StepsNewProduct();
			var newProduct = new NewProduct();
			var shaSteps = new Steps_SHA();
			var thisGlobalSteps = new GlobalSteps();
			var stepsIngredients = new StepsIngredients();
			var stepsProductChar = new Steps_ProductCharacteristics();
			var selectRetailers = new StepsSelectRetailers();





			sharedSteps.GivenICallSharedStepCreateANewRegistrationViaRegisterNewProductIcon();
			sharedSteps.GivenICallSharedStepTheProduct_EnterProductNameAndSelectTypeOfProduct("Abrasive");
			newProductSteps.SaveProductInformation(savedAs);
			stepsProductChar.SetThePrimayPhysicalStateTo("Solid");
			stepsProductChar.ThenISetTheSecondaryPhysicalStateToBe("Granular");
			newProductSteps.ThenISetTheWaterMixtureQuestionTo("Yes");
			stepsProductChar.ThenISetTheWaterSolubilityDescriptionTo("Completely soluble");
			newProductSteps.GivenInTheNewProductPageIClickContinue("New Product");
			newProductSteps.GivenIShouldSeeXPage("Additional Product Information");
			sharedSteps.GivenICallSharedStepAdditionalProductInformation_WithMarketedForUseByAChild_OSHA_PrivateLabel();
			Table tableIngredients = new Table("ComponentName", "Percent", "PublicallyDisclosed", "TradeSecret", "PublicName");
			tableIngredients.AddRow("Formaldehyde", "100", "false", "false", "");

			stepsIngredients.AddIngredients(tableIngredients);
			newProductSteps.GivenInTheNewProductPageIClickContinue("New Product");
			sharedSteps.ICallSharedRegulatoryInformation1_TSCARandom_Pro65No_Continue();
			newProductSteps.GivenIShouldSeeXPage("Transportation Details 1");
			newProductSteps.GivenInTheProductCharacteristicsTabOfTheNewProductPageForProductIsRegulatedForTransportISelect("Not Regulated");
			newProductSteps.GivenInTheNewProductPageIClickContinue("New Product");
			Report.Info("Then I select a retailer");
			selectRetailers.SelectTheRetailer("CVS");
			newProductSteps.ClickContinue();
			sharedSteps.GivenICallSharedEnterUniversalProductCodeUPC_CVSUPC_ContainerType_SizeOnly("Metal Container", "40");
			//go back to homepage (products grid)
			new StepsHomepage().ThenINavigateToTheHomePage();
			new GlobalSteps().ThenTheHomeScreenShouldLoad();


		}

		[StepDefinition(@"For CVS I create a product of type: Home Improvement \(RUCC0394\), save it as: (.*) and leave it in New Status")]
		public void ForCVSICreateProductOfTypeHomeImprovmentAndLeaveAsNew(string savedAs)
		{

			var sharedSteps = new Steps_Shared();
			var productsGridSteps = new StepsProductGrid();
			var newProductSteps = new StepsNewProduct();
			var newProduct = new NewProduct();
			var shaSteps = new Steps_SHA();
			var thisGlobalSteps = new GlobalSteps();
			var stepsIngredients = new StepsIngredients();
			var stepsProductChar = new Steps_ProductCharacteristics();
			var selectRetailers = new StepsSelectRetailers();


			//productsGridSteps.GivenIGenerateARandomUPCNumberAndSaveAs("UPC108254Lightbulb");
			sharedSteps.GivenICallSharedStepCreateANewRegistrationViaRegisterNewProductIcon();
			sharedSteps.GivenICallSharedStepTheProduct_EnterProductNameAndSelectTypeOfProduct("Light Bulbs - Incandescent Bulbs");
			newProductSteps.SaveProductInformation(savedAs);
			sharedSteps.GivenICallSharedStepAdditionalProductInformation_CountryAndPrivateLabelOrBrand_No();
			sharedSteps.ICallSharedRegulatoryInformation1_TSCARandom_Pro65No_Continue();
			sharedSteps.GivenICallSharedStepAnswerElectronicEquipmentQuestions_WithoutCathodeRay_NoToAll();
			Report.Info("Then I select a retailer");
			selectRetailers.SelectTheRetailer("CVS");
			newProductSteps.ClickContinue();
			sharedSteps.GivenICallSharedEnterUniversalProductCodeUPC_CVSUPC_ContainerType_SizeOnly("Metal Container", "40");
			//go back to homepage (products grid)
			new StepsHomepage().ThenINavigateToTheHomePage();
			new GlobalSteps().ThenTheHomeScreenShouldLoad();


		}
		[StepDefinition(@"For CVS I create a product of type: Lawn & Garden \(RUCC0395\), save it as: (.*) and leave it in New Status")]
		public void ForCVSICreateProductOfTypeLawnGardenAndLeaveAsNew(string savedAs)
		{
			var sharedSteps = new Steps_Shared();
			var productsGridSteps = new StepsProductGrid();
			var newProductSteps = new StepsNewProduct();
			var newProduct = new NewProduct();
			var shaSteps = new Steps_SHA();
			var thisGlobalSteps = new GlobalSteps();
			var stepsIngredients = new StepsIngredients();
			var stepsProductChar = new Steps_ProductCharacteristics();
			var selectRetailers = new StepsSelectRetailers();


			//productsGridSteps.GivenIGenerateARandomUPCNumberAndSaveAs("UPC108254Lightbulb");
			sharedSteps.GivenICallSharedStepCreateANewRegistrationViaRegisterNewProductIcon();
			sharedSteps.GivenICallSharedStepTheProduct_EnterProductNameAndSelectTypeOfProduct("Charcoal Lighter Material");
			newProductSteps.SaveProductInformation(savedAs);
			Table table73629 = new Table("Secondary Physical State", "Specific Gravity", "pH", "Boiling Point (in Celsius)", "Flash Point (in Celsius)", "Flash Point Testing Method Used", "Select the best Water Solubility description");
			table73629.AddRow("Liquid", "2", "2", "2", "66", "Closed cup method", "Very soluble");

			sharedSteps.ICallSharedStepProductCharacteristicsWithBoilingPointPHFlashPoint(table73629);
			Table table63804 = new Table("Classified using OSHA (US) Globally Harmonized Standards (GHS)", "Shipped directly by supplier", "Private Label or Brand", "Good Not for resale");
			table63804.AddRow("No", "No", "No", "No");

			sharedSteps.ICallSharedStepAdditionalProductInformationEnterOptions(table63804);

			Table table57570 = new Table("ComponentName", "Percent", "PublicallyDisclosed", "TradeSecret", "PublicName");
			table57570.AddRow("Butane", "100", "false", "false", "");

			sharedSteps.GivenICallSharedStepEnterIngredients(table57570);

			sharedSteps.ICallSharedRegulatoryInformation1_TSCARandom_Pro65No_Continue();
			sharedSteps.GivenICallSharedTransportationDetails_RegulatedForTransportNo_ExemptionRandom_Continue_HappyPath();
			sharedSteps.SharedTransportationDetails2_DoNotShipInternationally_Continue();
			newProductSteps.SetTheSectionOptionTo(" Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations.", "No");
			newProductSteps.SetTheSectionOptionTo("Verify VOC content is below the threshold of 0.02lb/start of CARB","No");
			newProductSteps.SetTheSectionOptionTo("Verify VOC content is below the threshold of 0.02lb/start of OTC", "No");
			newProductSteps.GivenInTheNewProductPageIClickContinue("New Product");
			newProductSteps.GivenInTheNewProductPageIClickContinue("New Product");

			Report.Info("Then I select a retailer");
			selectRetailers.SelectTheRetailer("CVS");
			newProductSteps.ClickContinue();
			sharedSteps.GivenICallSharedEnterUniversalProductCodeUPC_CVSUPC_ContainerType_SizeOnly("Metal Container", "40");
			//go back to homepage (products grid)
			new StepsHomepage().ThenINavigateToTheHomePage();
			new GlobalSteps().ThenTheHomeScreenShouldLoad();


		}
		[StepDefinition(@"For CVS I create a product of type: Miscellaneous \(RUCC0400\), save it as: (.*) and leave it in New Status")]
		public void ForCVSICreateProductOfTypeMiscAndLeaveAsNew(string savedAs)
		{
			var sharedSteps = new Steps_Shared();
			var productsGridSteps = new StepsProductGrid();
			var newProductSteps = new StepsNewProduct();
			var newProduct = new NewProduct();
			var shaSteps = new Steps_SHA();
			var thisGlobalSteps = new GlobalSteps();
			var stepsIngredients = new StepsIngredients();
			var stepsProductChar = new Steps_ProductCharacteristics();
			var stepsSelectretailers = new StepsSelectRetailers();
			var selectRetailers = new StepsSelectRetailers();



			sharedSteps.GivenICallSharedStepCreateANewRegistrationViaRegisterNewProductIcon();
			sharedSteps.GivenICallSharedStepTheProduct_EnterProductNameAndSelectTypeOfProduct("Candle and/or Wax");
			newProductSteps.SaveProductInformation(savedAs);
			sharedSteps.SharedProductCharacteristics_SolidOnlyAvailable_Continue();
			sharedSteps.GivenICallSharedAdditionalProductInformation_USOnly_NoGHSNotDirectShipNotPLPNotGNFR_Continue();
			Table table57570 = new Table("ComponentName", "Percent", "PublicallyDisclosed", "TradeSecret", "PublicName");
			table57570.AddRow("Sodium chloride", "100", "false", "false", "");

			sharedSteps.GivenICallSharedStepEnterIngredients(table57570);
			sharedSteps.GivenICallSharedEnterRegulatoryInformation_NotProp();
			//sharedSteps.GivenICallSharedRegulatoryInformation_DrugFactsPanel_NoneOfTheAbove_Continue_HappyPath();
			//stepsSelectretailers.GivenIShouldSeeTheSelectRetailersPopUp();
			Report.Info("Then I select a retailer");
			selectRetailers.SelectTheRetailer("CVS");
			newProductSteps.ClickContinue();
			sharedSteps.GivenICallSharedEnterUniversalProductCodeUPC_CVSUPC_ContainerType_SizeOnly("Metal Container", "40");
			//go back to homepage (products grid)
			new StepsHomepage().ThenINavigateToTheHomePage();
			new GlobalSteps().ThenTheHomeScreenShouldLoad();

		}
		[StepDefinition(@"For CVS I create a product of type: Nutritional \(RUCC0592\), save it as: (.*) and leave it in New Status")]
		public void ForCVSICreateProductOfTypeNutritionalAndLeaveAsNew(string savedAs)
		{
			var sharedSteps = new Steps_Shared();
			var productsGridSteps = new StepsProductGrid();
			var newProductSteps = new StepsNewProduct();
			var newProduct = new NewProduct();
			var shaSteps = new Steps_SHA();
			var thisGlobalSteps = new GlobalSteps();
			var stepsIngredients = new StepsIngredients();
			var stepsProductChar = new Steps_ProductCharacteristics();
			var stepsSelectretailers = new StepsSelectRetailers();
			var selectRetailers = new StepsSelectRetailers();



			sharedSteps.GivenICallSharedStepCreateANewRegistrationViaRegisterNewProductIcon();
			sharedSteps.GivenICallSharedStepTheProduct_EnterProductNameAndSelectTypeOfProduct("Candle and/or Wax");
			newProductSteps.SaveProductInformation(savedAs);

			Table table37857 = new Table("Secondary Physical State", "Water Solubility");
			table37857.AddRow("Grainy", "Soluble in hot water");
			sharedSteps.GivenICallSharedEnterPhysicalProperty_SolidParameters(table37857);
			sharedSteps.GivenICallSharedAdditionalProductInformation_USOnly_NoGHSNotDirectShipNotPLPNotGNFR_Continue();
			Table table57570 = new Table("ComponentName", "Percent", "PublicallyDisclosed", "TradeSecret", "PublicName");
			table57570.AddRow("Sodium chloride", "100", "false", "false", "");

			sharedSteps.GivenICallSharedStepEnterIngredients(table57570);
			sharedSteps.GivenICallSharedEnterRegulatoryInformation_NotProp();
			//sharedSteps.GivenICallSharedRegulatoryInformation_DrugFactsPanel_NoneOfTheAbove_Continue_HappyPath();
			Report.Info("Then I select a retailer");
			selectRetailers.SelectTheRetailer("CVS");
			newProductSteps.ClickContinue();
			sharedSteps.GivenICallSharedEnterUniversalProductCodeUPC_CVSUPC_ContainerType_SizeOnly("Metal Container", "40");
			//go back to homepage (products grid)
			new StepsHomepage().ThenINavigateToTheHomePage();
			new GlobalSteps().ThenTheHomeScreenShouldLoad();


		}
		[StepDefinition(@"For CVS I create a product of type: Over-the-Counter \(RUCC1002\), save it as: (.*) and leave it in New Status")]
		public void ForCVSICreateProductOfTypeOTCAndLeaveAsNew(string savedAs)
		{
			var sharedSteps = new Steps_Shared();
			var productsGridSteps = new StepsProductGrid();
			var newProductSteps = new StepsNewProduct();
			var newProduct = new NewProduct();
			var shaSteps = new Steps_SHA();
			var thisGlobalSteps = new GlobalSteps();
			var stepsIngredients = new StepsIngredients();
			var stepsProductChar = new Steps_ProductCharacteristics();
			var stepsSelectretailers = new StepsSelectRetailers();
			var selectRetailers = new StepsSelectRetailers();

			sharedSteps.GivenICallSharedStepCreateANewRegistrationViaRegisterNewProductIcon();
			sharedSteps.GivenICallSharedStepTheProduct_EnterProductNameAndSelectTypeOfProduct("Latex gloves");
			newProductSteps.SaveProductInformation(savedAs);

			sharedSteps.GivenICallSharedEnterPhysicalProperty_Solid();
			sharedSteps.GivenICallSharedAdditionalProductInformation_USOnly_NoGHSNotDirectShipNotPLPNotGNFR_Continue();
			Table table57570 = new Table("ComponentName", "Percent", "PublicallyDisclosed", "TradeSecret", "PublicName");
			table57570.AddRow("Sodium chloride", "100", "false", "false", "");

			sharedSteps.GivenICallSharedStepEnterIngredients(table57570);
			sharedSteps.GivenICallSharedEnterRegulatoryInformation_NotProp();
			//sharedSteps.GivenICallSharedRegulatoryInformation_DrugFactsPanel_NoneOfTheAbove_Continue_HappyPath();
			Report.Info("Then I select a retailer");
			selectRetailers.SelectTheRetailer("CVS");
			newProductSteps.ClickContinue();
			sharedSteps.GivenICallSharedEnterUniversalProductCodeUPC_CVSUPC_ContainerType_SizeOnly("Metal Container", "40");
			//go back to homepage (products grid)
			new StepsHomepage().ThenINavigateToTheHomePage();
			new GlobalSteps().ThenTheHomeScreenShouldLoad();


		}

		[StepDefinition(@"For CVS I create a product of type: Pet Care \(RUCC0387\), save it as: (.*) and leave it in New Status")]
		public void ForCVSICreateProductOfTypePetCareAndLeaveAsNew(string savedAs)
		{
			var sharedSteps = new Steps_Shared();
			var productsGridSteps = new StepsProductGrid();
			var newProductSteps = new StepsNewProduct();
			var newProduct = new NewProduct();
			var shaSteps = new Steps_SHA();
			var thisGlobalSteps = new GlobalSteps();
			var stepsIngredients = new StepsIngredients();
			var stepsProductChar = new Steps_ProductCharacteristics();
			var stepsSelectretailers = new StepsSelectRetailers();
			var selectRetailers = new StepsSelectRetailers();

			sharedSteps.GivenICallSharedStepCreateANewRegistrationViaRegisterNewProductIcon();
			sharedSteps.GivenICallSharedStepTheProduct_EnterProductNameAndSelectTypeOfProduct("Aquarium maintenance chemicals");
			newProductSteps.SaveProductInformation(savedAs);


			Table table74760 = new Table("Primary Physical State", "Secondary Physical State", "Specific Gravity", "pH", "Boiling Point (in Celsius)", "Flash Point (in Celsius)", "Flash Point Testing Method Used", "Select the best Water Solubility description");
			table74760.AddRow("Liquid", "Liquid", "2", "2", "2", "66", "Closed cup method", "Very soluble");

			sharedSteps.ICallSharedProductCharacteristics_MoreThanOneState_SelectLiquidAndEnterOtherOptions(table74760);
			sharedSteps.GivenICallSharedStepAdditionalProductInformation_PesticideShownUSOnlySelectNoForEverythingElse_HappyPath();
			Table table57570 = new Table("ComponentName", "Percent", "PublicallyDisclosed", "TradeSecret", "PublicName");
			table57570.AddRow("Sodium chloride", "100", "false", "false", "");

			sharedSteps.GivenICallSharedStepEnterIngredients(table57570);
			sharedSteps.GivenICallSharedEnterRegulatoryInformation_NotProp();
			sharedSteps.GivenICallSharedRegulatoryInformation_DrugFactsPanel_NoneOfTheAbove_Continue_HappyPath();
			sharedSteps.GivenICallSharedStepEnterPesticideData_UnitedStatesWithoutEPANumber();
			sharedSteps.GivenICallSharedTransportationDetails1_YesOption_SelectDOTLimitedQuantity();
			sharedSteps.GivenICallSharedUSDepartmentofTransportationDOTClassification_EnterUN1950Aerosol_SelectData();

			Report.Info("Then I select a retailer");
			selectRetailers.SelectTheRetailer("CVS");
			newProductSteps.ClickContinue();
			sharedSteps.GivenICallSharedEnterUniversalProductCodeUPC_CVSUPC_ContainerType_SizeOnly("Metal Container", "40");
			//go back to homepage (products grid)
			new StepsHomepage().ThenINavigateToTheHomePage();
			new GlobalSteps().ThenTheHomeScreenShouldLoad();


		}

		[StepDefinition(@"For CVS I create a product of type: Photography \(RUCC0735\), save it as: (.*) and leave it in New Status")]
		public void ForCVSICreateProductOfTypePhotographyAndLeaveAsNew(string savedAs)
		{
			var sharedSteps = new Steps_Shared();
			var productsGridSteps = new StepsProductGrid();
			var newProductSteps = new StepsNewProduct();
			var newProduct = new NewProduct();
			var shaSteps = new Steps_SHA();
			var thisGlobalSteps = new GlobalSteps();
			var stepsIngredients = new StepsIngredients();
			var stepsProductChar = new Steps_ProductCharacteristics();
			var stepsSelectretailers = new StepsSelectRetailers();
			var selectRetailers = new StepsSelectRetailers();

			sharedSteps.GivenICallSharedStepCreateANewRegistrationViaRegisterNewProductIcon();
			sharedSteps.GivenICallSharedStepTheProduct_EnterProductNameAndSelectTypeOfProduct("Photograph Coating - Aerosol");
			newProductSteps.SaveProductInformation(savedAs);

			sharedSteps.GivenICallSharedStepEnterProductDataForPhysicalState_AerosolOnly();
			sharedSteps.GivenICallSharedStepAdditionalProductInformationWithCountryAndEveryOption();
			newProduct.ClickContinue();
			sharedSteps.GivenICallSharedEnterIngrediebtsForAerosolPropellant();
			sharedSteps.GivenICallSharedEnterRegulatoryInformation_NotProp();

			sharedSteps.GivenICallSharedStepTransportationDetails_YesOnlyOption_SelectIMDGFullyRegulated_Continue_HappyPath();
			sharedSteps.GivenICallSharedUSDepartmentofTransportationDOTClassification_EnterUN1950Aerosol_SelectData();
			sharedSteps.GivenICallSharedStepConfirmVOCSCAQMDStepTitleConfirmACPQuestionShown_SelectNo_HappyPath();
			sharedSteps.GivenICallSharedStepVOC_AEROQuestionOzoneEnterValue_ClickContinue_HappyPath("0.5");
			newProduct.ClickContinue();
			Report.Info("Then I select a retailer");
			selectRetailers.SelectTheRetailer("CVS");
			newProductSteps.ClickContinue();
			sharedSteps.GivenICallSharedEnterUniversalProductCodeUPC_CVSUPC_ContainerType_SizeOnly("Aerosol Can", "40");
			new StepsHomepage().ThenINavigateToTheHomePage();
			new GlobalSteps().ThenTheHomeScreenShouldLoad();



			//Table table57570 = new Table("ComponentName", "Percent", "PublicallyDisclosed", "TradeSecret", "PublicName");
			//table57570.AddRow("Sodium chloride", "100", "false", "false", "");

			//sharedSteps.GivenICallSharedStepEnterIngredients(table57570);
			//sharedSteps.GivenICallSharedEnterRegulatoryInformation_NotProp();
			//sharedSteps.GivenICallSharedRegulatoryInformation_DrugFactsPanel_NoneOfTheAbove_Continue_HappyPath();
			//Report.Info("Then I select a retailer");
			//selectRetailers.SelectTheRetailer("CVS");
			//newProductSteps.ClickContinue();
			//sharedSteps.GivenICallSharedEnterUniversalProductCodeUPC_CVSUPC_ContainerType_SizeOnly("Metal Container", "40");
			////go back to homepage (products grid)
			//new StepsHomepage().ThenINavigateToTheHomePage();
			//new GlobalSteps().ThenTheHomeScreenShouldLoad();

		}

		[StepDefinition(@"For CVS I create a product of type: Sporting Goods \(RUCC0386\), save it as: (.*) and leave it in New Status")]
		public void ForCVSICreateProductOfTypeSportingGoodsAndLeaveAsNew(string savedAs)
		{
			var sharedSteps = new Steps_Shared();
			var productsGridSteps = new StepsProductGrid();
			var newProductSteps = new StepsNewProduct();
			var newProduct = new NewProduct();
			var shaSteps = new Steps_SHA();
			var thisGlobalSteps = new GlobalSteps();
			var stepsIngredients = new StepsIngredients();
			var stepsProductChar = new Steps_ProductCharacteristics();
			var stepsSelectretailers = new StepsSelectRetailers();
			var selectRetailers = new StepsSelectRetailers();

			sharedSteps.GivenICallSharedStepCreateANewRegistrationViaRegisterNewProductIcon();
			sharedSteps.GivenICallSharedStepTheProduct_EnterProductNameAndSelectTypeOfProduct("Lighters");
			newProductSteps.SaveProductInformation(savedAs);

			Table table74981 = new Table("Secondary Physical State", "Select the best Water Solubility description");
			table74981.AddRow("Compressed gas", "Low");
			sharedSteps.ICallSharedProductCharacteristics_Gas(table74981);
			Table table63804 = new Table("Classified using OSHA (US) Globally Harmonized Standards (GHS)", "Shipped directly by supplier", "Private Label or Brand", "Good Not for resale");
			table63804.AddRow("No", "No", "No", "No");

			sharedSteps.ICallSharedStepAdditionalProductInformationEnterOptions(table63804);
			Table table57570 = new Table("ComponentName", "Percent", "PublicallyDisclosed", "TradeSecret", "PublicName");
			table57570.AddRow("Sodium chloride", "100", "false", "false", "");

			sharedSteps.GivenICallSharedStepEnterIngredients(table57570);
			sharedSteps.GivenICallSharedEnterRegulatoryInformation_NotProp();
			sharedSteps.GivenICallSharedTransportationDetails1_YesOption_SelectDOTLimitedQuantity();
			sharedSteps.GivenICallSharedUSDepartmentofTransportationDOTClassification_EnterUN1950Aerosol_SelectData();
			Report.Info("Then I select a retailer");
			selectRetailers.SelectTheRetailer("CVS");
			newProductSteps.ClickContinue();
			sharedSteps.GivenICallSharedEnterUniversalProductCodeUPC_CVSUPC_ContainerType_SizeOnly("Metal Container", "40");
			//go back to homepage (products grid)
			new StepsHomepage().ThenINavigateToTheHomePage();
			new GlobalSteps().ThenTheHomeScreenShouldLoad();


		}

		[StepDefinition(@"For CVS I create a product of type: Stationery \(RUCC0385\), save it as: (.*) and leave it in New Status")]
		public void ForCVSICreateProductOfTypeStationeryAndLeaveAsNew(string savedAs)

		{
			TestReport.UseSubSteps = true;
			var sharedSteps = new Steps_Shared();
			var productsGridSteps = new StepsProductGrid();
			var newProductSteps = new StepsNewProduct();
			var newProduct = new NewProduct();
			var shaSteps = new Steps_SHA();
			var thisGlobalSteps = new GlobalSteps();
			var selectRetailers = new StepsSelectRetailers();
			sharedSteps.GivenICallSharedStepCreateANewRegistrationViaRegisterNewProductIcon();
			sharedSteps.GivenICallSharedStepTheProduct_EnterProductNameAndSelectTypeOfProduct("Chalk");
			newProductSteps.SaveProductInformation(savedAs);
			sharedSteps.SharedProductCharacteristics_SolidOnlyAvailable_Continue();
			sharedSteps.ICallSharedAdditionalProductInformationUSAndCanadaNoChildNoOSHANoDirectShipNoPLNoNGFR_Continue();
			sharedSteps.ICallSharedIngredients_AddAnyChemical("Sodium hydroxide");
			sharedSteps.ICallSharedRegulatoryInformation1_TSCAAndCEPAShown_NoToProp65();

			Report.Info("Then I select a retailer");
			selectRetailers.SelectTheRetailer("CVS");
			newProductSteps.ClickContinue();
			sharedSteps.GivenICallSharedEnterUniversalProductCodeUPC_CVSUPC_ContainerType_SizeOnly("Metal Container", "40");
			//go back to homepage (products grid)
			new StepsHomepage().ThenINavigateToTheHomePage();
			new GlobalSteps().ThenTheHomeScreenShouldLoad();

		}

		[StepDefinition(@"For CVS I create a product of type: Battery \(RUCC0733\), save it as: (.*) and leave it in New Status")]
		public void ForCVSICreateProductOfTypeBatteryAndLeaveAsNew(string savedAs)

		{
			var sharedSteps = new Steps_Shared();
			var productsGridSteps = new StepsProductGrid();
			var newProductSteps = new StepsNewProduct();
			var newProduct = new NewProduct();
			var shaSteps = new Steps_SHA();
			var thisGlobalSteps = new GlobalSteps();
			var stepsIngredients = new StepsIngredients();
			var stepsProductChar = new Steps_ProductCharacteristics();
			var stepsSelectretailers = new StepsSelectRetailers();
			var selectRetailers = new StepsSelectRetailers();

			sharedSteps.GivenICallSharedStepCreateANewRegistrationViaRegisterNewProductIcon();
			sharedSteps.GivenICallSharedStepTheProduct_EnterProductNameAndSelectTypeOfProduct("Lithium ion batteries");
			newProductSteps.SaveProductInformation(savedAs);

			sharedSteps.SharedPrimaryPhysicalStateSolidOnlyAvailable_WithoutWaterSolubilityQuestion();
			sharedSteps.SharedAdditionalProductInformation_USOnly_BatteryIsPackedForRetailSales_NoElse();

			Table table57570 = new Table("ComponentName", "Percent", "PublicallyDisclosed", "TradeSecret", "PublicName");
			table57570.AddRow("Sodium chloride", "100", "false", "false", "");

			sharedSteps.GivenICallSharedStepEnterIngredients(table57570);
			sharedSteps.GivenICallSharedEnterRegulatoryInformation_TSCACEPANotProp();
			sharedSteps.SharedLithiumBatteryCharacteristics_AnyData();
			sharedSteps.SharedLithiumBatteryTransportation();
			Report.Info("Then I select a retailer");
			selectRetailers.SelectTheRetailer("CVS");
			newProductSteps.ClickContinue();
			this.GivenICallSharedEnterUniversalProductCodeUPC_CVSUPC_ContainerType_SizeOnly("Metal Container", "40", "1");
			//sharedSteps.GivenICallSharedEnterUniversalProductCodeUPC_CVSUPC_ContainerType_SizeOnly("Metal Container", "40");
			//go back to homepage (products grid)
			new StepsHomepage().ThenINavigateToTheHomePage();
			new GlobalSteps().ThenTheHomeScreenShouldLoad();



		}

		[StepDefinition(@"For CVS I create a product of type: Grocery \(RUCC0389\), save it as: (.*) and leave it in New Status")]
		public void ForCVSICreateProductOfTypeGroceryAndLeaveAsNew(string savedAs)

		{
			var sharedSteps = new Steps_Shared();
			var productsGridSteps = new StepsProductGrid();
			var newProductSteps = new StepsNewProduct();
			var newProduct = new NewProduct();
			var shaSteps = new Steps_SHA();
			var thisGlobalSteps = new GlobalSteps();
			var stepsIngredients = new StepsIngredients();
			var stepsProductChar = new Steps_ProductCharacteristics();
			var stepsSelectretailers = new StepsSelectRetailers();
			var selectRetailers = new StepsSelectRetailers();
			sharedSteps.GivenICallSharedStepCreateANewRegistrationViaRegisterNewProductIcon();
			sharedSteps.GivenICallSharedStepTheProduct_EnterProductNameAndSelectTypeOfProduct("Cereals");
			newProductSteps.SaveProductInformation(savedAs);
			sharedSteps.GivenICallSharedStepSelectPrimaryPhysicalProperty_Solid_WithIngredients();
			sharedSteps.GivenICallSharedStep60726AdditionalProductInformation_CountryAndPrivateLabelOrBrand_Yes();
			sharedSteps.GivenICallSharedEnterRegulatoryInformation_NotProp();
			Report.Info("Then I select a retailer");
			selectRetailers.SelectTheRetailer("CVS");
			newProductSteps.ClickContinue();
			sharedSteps.GivenICallSharedEnterUniversalProductCodeUPC_CVSUPC_ContainerType_SizeOnly("Metal Container", "40");
			//go back to homepage (products grid)
			new StepsHomepage().ThenINavigateToTheHomePage();
			new GlobalSteps().ThenTheHomeScreenShouldLoad();




		}

		[StepDefinition(@"For CVS I create a product of type: Pharmacy \(RUCC0393\), save it as: (.*) and leave it in New Status")]
		public void ForCVSICreateProductOfTypePharmacyAndLeaveAsNew(string savedAs)

		{
			var sharedSteps = new Steps_Shared();
			var productsGridSteps = new StepsProductGrid();
			var newProductSteps = new StepsNewProduct();
			var newProduct = new NewProduct();
			var shaSteps = new Steps_SHA();
			var thisGlobalSteps = new GlobalSteps();
			var stepsIngredients = new StepsIngredients();
			var stepsProductChar = new Steps_ProductCharacteristics();
			var stepsSelectretailers = new StepsSelectRetailers();
			var selectRetailers = new StepsSelectRetailers();

			sharedSteps.GivenICallSharedStepCreateANewRegistrationViaRegisterNewProductIcon();
			sharedSteps.GivenICallSharedStepTheProduct_EnterProductNameAndSelectTypeOfProduct("Medicinal Liquids (cough medicine, eye drops, ear drops, nasal spray and inhalers)");
			newProductSteps.SaveProductInformation(savedAs);
			sharedSteps.SharedProductCharacteristics_LiquidOnly_WithWaterSolubility_EnterAllData_Continue();
			sharedSteps.ICallSharedAdditionalProductInformationUSOnlyNoChildNoGHSNoDirectShipNoPLPNoGNFR();
			Table table57570 = new Table("ComponentName", "Percent", "PublicallyDisclosed", "TradeSecret", "PublicName");
			table57570.AddRow("Sodium chloride", "100", "false", "false", "");

			sharedSteps.GivenICallSharedStepEnterIngredients(table57570);
			sharedSteps.GivenICallSharedEnterRegulatoryInformation_NotProp();
			sharedSteps.GivenICallSharedTransportationDetails_RegulatedForTransportNo_ExemptionRandom_Continue_HappyPath();
			sharedSteps.SharedTransportationDetails2_DoNotShipInternationally_Continue();
			Report.Info("Then I select a retailer");
			selectRetailers.SelectTheRetailer("CVS");
			newProductSteps.ClickContinue();
			sharedSteps.GivenICallSharedEnterUniversalProductCodeUPC_CVSUPC_ContainerType_SizeOnly("Metal Container", "40");
			//go back to homepage (products grid)
			new StepsHomepage().ThenINavigateToTheHomePage();
			new GlobalSteps().ThenTheHomeScreenShouldLoad();


		}

		[StepDefinition(@"I create a CA Cleaning Compliant product, select ingredient type and functional purpose then save it as: (.*) and progress it to submitted")]
		public void CreateCACleaningCompliantProductSelectIngredientTypeAndFunctionalPurposeAndProgressToSubmitted(string savedAs)
		{
			var sharedSteps = new Steps_Shared();
			var productsGridSteps = new StepsProductGrid();
			var newProductSteps = new StepsNewProduct();
			var newProduct = new NewProduct();
			var shaSteps = new Steps_SHA();
			var thisGlobalSteps = new GlobalSteps();
			var stepsIngredients = new StepsIngredients();
			var stepsProductChar = new Steps_ProductCharacteristics();
			var selectRetailers = new StepsSelectRetailers();





			sharedSteps.GivenICallSharedStepCreateANewRegistrationViaRegisterNewProductIcon();
			sharedSteps.GivenICallSharedStepTheProduct_EnterProductNameAndSelectTypeOfProduct("Abrasive");
			newProductSteps.SaveProductInformation(savedAs);
			stepsProductChar.SetThePrimayPhysicalStateTo("Solid");
			stepsProductChar.ThenISetTheSecondaryPhysicalStateToBe("Granular");
			newProductSteps.ThenISetTheWaterMixtureQuestionTo("Yes");
			stepsProductChar.ThenISetTheWaterSolubilityDescriptionTo("Completely soluble");
			newProductSteps.GivenInTheNewProductPageIClickContinue("New Product");
			newProductSteps.GivenIShouldSeeXPage("Additional Product Information");

			//Create new version of this step to Answer CA cleaning question 
			//sharedSteps.GivenICallSharedStepAdditionalProductInformation_WithMarketedForUseByAChild_OSHA_PrivateLabel();
			this.AdditionalProductInformation_YesToCACleaning();
			this.InTheCACleaningProductDisclosureScreenChooseHappyPath();

			newProductSteps.ClickContinue();

			//Create Updated/New version for CA cleaning product ingredient entry.
			Table tableIngredients1 = new Table("ComponentName", "Percent", "PublicallyDisclosed", "TradeSecret", "PublicName");
			tableIngredients1.AddRow("Formaldehyde", "25", "false", "false", "");
			stepsIngredients.AddIngredients(tableIngredients1);

			Table tableIngredients2 = new Table("ComponentName", "Percent", "PublicallyDisclosed", "TradeSecret", "PublicName");
			tableIngredients2.AddRow("Water", "25", "false", "false", "");
			stepsIngredients.AddIngredients(tableIngredients2);

			Table tableIngredients3 = new Table("ComponentName", "Percent", "PublicallyDisclosed", "TradeSecret", "PublicName");
			tableIngredients3.AddRow("Sodium chloride", "25", "false", "false", "");
			stepsIngredients.AddIngredients(tableIngredients3);

			Table tableIngredients4 = new Table("ComponentName", "Percent", "PublicallyDisclosed", "TradeSecret", "PublicName");
			tableIngredients4.AddRow("Butane", "25", "false", "false", "");
			stepsIngredients.AddIngredients(tableIngredients4);
			Table tableFunctionalPurpose1 = new Table("Functional Purpose");
			tableFunctionalPurpose1.AddRow("NA");
			Table tableFunctionalPurpose2 = new Table("Functional Purpose");
			tableFunctionalPurpose2.AddRow("Abrasive");
			Table tableFunctionalPurpose3 = new Table("Functional Purpose");
			tableFunctionalPurpose3.AddRow("Abrasive");
			tableFunctionalPurpose3.AddRow("Adhesive");
			tableFunctionalPurpose3.AddRow("Antifreeze");
			stepsIngredients.OnTheIngredientsPageSelectTypeAndPurpose("Formaldehyde", "Fragrance",tableFunctionalPurpose1);
			stepsIngredients.OnTheIngredientsPageSelectTypeAndPurpose("Water", "Intentionally Added", tableFunctionalPurpose2);
			stepsIngredients.OnTheIngredientsPageSelectTypeAndPurpose("Sodium chloride", "Non-functional Byproduct", tableFunctionalPurpose3);
			stepsIngredients.OnTheIngredientsPageSelectTypeAndAllPurpose("Butane", "Non-functional Contaminant");


			newProductSteps.GivenInTheNewProductPageIClickContinue("New Product");
			sharedSteps.ICallSharedRegulatoryInformation1_TSCARandom_Pro65No_Continue();
			newProductSteps.GivenIShouldSeeXPage("Transportation Details 1");
			newProductSteps.GivenInTheProductCharacteristicsTabOfTheNewProductPageForProductIsRegulatedForTransportISelect("Not Regulated");
			newProductSteps.GivenInTheNewProductPageIClickContinue("New Product");
			Report.Info("Then I select a retailer");
			selectRetailers.SelectTheRetailer("CVS");
			newProductSteps.ClickContinue();
			sharedSteps.GivenICallSharedEnterUniversalProductCodeUPC_CVSUPC_ContainerType_SizeOnly("Metal Container", "40");

			//add remaining steps in to get to submitted
			//below not yet tested for this product type

			sharedSteps.SharedCVSPharmacy_YesIWishToContinue();
			new StepsNewProduct().SetTheSectionOptionTo("What is the CVS Store Brand associated to this product?", "CVS Health (CVS Pharmacy)");
			new StepsNewProduct().SetTheSectionOptionTo("Who is the Product Development Manager (PDM) for this product?", "Lacross, Elizabeth A. Elizabeth.LaCross@CVSHealth.com");
			new StepsNewProduct().SetTheSectionOptionTo("What is the CVS merchandising category for this product?", "Facial Care");
			new StepsNewProduct().SetTheSectionOptionTo("Is this product specifically designed, marketed or labeled for infants, babies, or children?", "No");
			new StepsNewProduct().SetTheSectionOptionTo("Is this a topically used product which includes but is not limited to liquids, ointments, bath soaps/bombs, scrubs, masks, wipes, lotions, creams and gels?", "Yes");
			new StepsNewProduct().SetTheSectionOptionTo("Product contains microbeads", "No");
			new StepsNewProduct().SetTheSectionOptionTo("Is this product intended to be rinsed off after use?","No");
			new StepsNewProduct().SetTheSectionOptionTo("Refer to your Product Label. Select the options that appear on the label.", "None of the Above");
			new StepsNewProduct().SetTheSectionOptionTo("Is this product intended to be ingested?", "No");
			new StepsNewProduct().SetTheSectionOptionTo("Is this product a personal care sanitizer, wash, or cleanser (e.g., Hand, Body, Facial)?", "No");
			new StepsNewProduct().ClickContinue();

			TestReport.StartStep("I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)");
			sharedSteps.GivenICallSharedRegulatoryDocumentsToProvide_USOnly_RequestAuthoring_HappyPath();
			TestReport.StartStep("in the Additional Documents to Provide page I click Continue");
			newProductSteps.GivenInTheNewProductPageIClickContinue("Additional Documents to Provide");
			TestReport.StartStep("in the Optional Reports and Documents Available for Purchase page I click Continue");
			newProductSteps.GivenInTheNewProductPageIClickContinue("Optional Reports and Documents Available for Purchase");
			TestReport.StartStep("I call Shared Step 57884");

			Table additionalData = new Table("Personal Protection Equipment", "Autoignition Temperature", "Minimum Ignition Energy", "Viscosity", "Appearance", "Odor", "Odor Threshold", "Partition Coefficient");
			additionalData.AddRow("Mask", "300", "1.005", "20", "Black", "Odorless", "No data available", "10");
			sharedSteps.GivenICallSharedSafetyDataSheetAuthoring_AditionalDataStep_AddAnyRandomDataForAllFields_HappyPath(additionalData);
			TestReport.StartStep("I call Shared Step 57883");
			sharedSteps.GivenICallSharedCommentsHappyPath(@"User added Comments Text 57863. !""£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.");
			TestReport.StartStep("I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)");
			sharedSteps.GivenICallSharedDataAcceptance_ClickAccept_HappyPath();
			TestReport.StartStep("If purchase details are showing click confirm order");
			newProductSteps.GivenIfPurchaseDetailsAreShowingClickConfirmOrder();






			//go back to homepage (products grid)
			new StepsHomepage().ThenINavigateToTheHomePage();
			new GlobalSteps().ThenTheHomeScreenShouldLoad();


		}

		[StepDefinition(@"In the Additional Product Information Screen I answer the questions as follows - US only - No to GHS - No to shipped supplier - Yes to CA Cleaning - No to Private Label - No to Sold to retailer\)")]
		public void AdditionalProductInformation_YesToCACleaning()
		{
			var MyStepsNewProduct = new StepsNewProduct();
			var myNewProduct = new NewProduct();
			MyStepsNewProduct.GivenIShouldSeeXPage("Additional Product Information");
			Delay.Seconds(1);
			if (myNewProduct.SectionExists(
				"Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)"))
			{
				MyStepsNewProduct.SetTheSectionOptionTo(
					"Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)",
					"No");
			}

			if (myNewProduct.SectionExists(
				"Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)")
			)
			{
				MyStepsNewProduct.SetTheSectionOptionTo(
					"Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)",
					"No");
			}

			if (myNewProduct.SectionExists("Product is shipped directly by supplier to the consumer."))
			{
				MyStepsNewProduct.SetTheSectionOptionTo("Product is shipped directly by supplier to the consumer.",
					"No");
			}

			if (myNewProduct.SectionExists("Cleaning products must comply with California's Cleaning Product Right to Know Act."))
			{
				MyStepsNewProduct.SetTheSectionOptionTo("Cleaning products must comply with California's Cleaning Product Right to Know Act.",
					"Yes");
			}



			if (myNewProduct.SectionExists("Product is a Retailer's Private Label or Brand"))
			{
				MyStepsNewProduct.SetTheSectionOptionTo("Product is a Retailer's Private Label or Brand", "No");
			}

			if (myNewProduct.SectionExists(
				"Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)")
			)
			{
				MyStepsNewProduct.SetTheSectionOptionTo(
					"Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)",
					"No");
			}

			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("New Product");
			TestReport.StartStep("In the Additional Product Information page I click Continue");
			MyStepsNewProduct.GivenInTheNewProductPageIClickContinue("Additional Product Information");
		}

		[StepDefinition(@"In the Claifornia Cleaning Product Disclosure I choose 'Manufacturer' and select 'No' for CBI, then enter Placeholder Details")]
		public void InTheCACleaningProductDisclosureScreenChooseHappyPath()
		{
			var MyStepsNewProduct = new StepsNewProduct();
			var myNewProduct = new NewProduct();
	
			MyStepsNewProduct.GivenIShouldSeeXPage("California Cleaning Product Disclosure");
			Delay.Seconds(1);

			if (myNewProduct.SectionExists("Who is publicly identified on the product label as responsible for the product?"))
			{
				MyStepsNewProduct.SetRadioOptionInSectionTo("Who is publicly identified on the product label as responsible for the product?", "Manufacturer");
			}

			if (myNewProduct.SectionExists("Who is the Final Domestic Distributor (if any) of the product?"))
			{
				MyStepsNewProduct.GivenInTheCaliforniaCleaningProductDisclosureTabIEnterInFinalDomesticDistributorTextField("Company Name");
			}

			if (myNewProduct.SectionExists("Is your identity, as the Manufacturer of this product, Confidential Business Information (CBI)?"))
			{
				MyStepsNewProduct.SetTheSectionOptionTo("Is your identity, as the Manufacturer of this product, Confidential Business Information (CBI)?", "No");
			}

			if (myNewProduct.SectionExists("Company's Toll-Free Phone Number"))
			{
				MyStepsNewProduct.GivenInTheCaliforniaCleaningProductDisclosureTabIEnterInTollFreePhoneNumberTextField("11111111111");
			}

			if (myNewProduct.SectionExists("Company Web Address"))
			{
				MyStepsNewProduct.GivenInTheCaliforniaCleaningProductDisclosureTabIEnterInCompanyWebAddressTextField("http://TestWebsitePlaceholderName.com");
			}

			if (myNewProduct.SectionExists("Select the product's GTIN Brick Code"))
			{
				MyStepsNewProduct.ThenISetTheProductsGTINBrickCodeTo("[10000424] Laundry Detergents");
			}




		}

		[StepDefinition(@"CVS Pharmacy - No, Later Date")]
		public void SharedCVSPharmacy_YesIWishToContinue()
		{
			TestReport.UseSubSteps = true;
			var selNewProductSteps = new StepsNewProduct();
			TestReport.StartStep("I confirm the CVS Pharmacy section appears");
			selNewProductSteps.GivenIShouldSeeXPage("CVS Own Brand Registration");
			TestReport.StartStep(
				"I set the Continue? option to: Yes, I wish to continue registration");
			selNewProductSteps.SetTheSectionOptionTo(
				"Continue?",
				"Yes, I wish to continue registration");
			TestReport.StartStep("I click continue");
			selNewProductSteps.ClickContinue();
		}

		[StepDefinition(@"I Enter Universal Product Code details for a CVS Product, container type: (.*), size: (.*), Quantity (.*)")]
		public void GivenICallSharedEnterUniversalProductCodeUPC_CVSUPC_ContainerType_SizeOnly(string containerType,string size, string quantity)
		{
			TestReport.UseSubSteps = true;
			var stepsNewProduct = new StepsNewProduct();
			TestReport.StartStep("I should see the Universal Product Code (UPC) Page");
			stepsNewProduct.GivenIShouldSeeXPage("Universal Product Code (UPC)");
			for (int i = 0; i < 100; i++)
			{
				Report.Info("Entering UPC information. Attempt: " + (i + 1));
				TestReport.StartStep("I click the 'Add UPC' button");
				stepsNewProduct.ThenIClickTheAddUpcButton();
				TestReport.StartStep("I add the following into the UPC Fields");
				string upc = TReVorDetails.TReVor.VisualStudioFunctions.GetRandomUpcNumber("CVS");
				Report.Info("UPC number: " + upc);
				var upcInfo = new UpcInformation {
					ContainerType = containerType,
					Size = size,
					UpcNumber = upc,
					Quantity= quantity					
				};
				Report.IsTrue(new NewProduct().InputUpcInformation(upcInfo), "Failed to input UPC Information!",
					"Successfully inputted UPC information!");
				TestReport.StartStep("In the Universal Product Code (UPC) page I click Continue");
				stepsNewProduct.GivenInTheNewProductPageIClickContinue("Universal Product Code (UPC)");
				GeneralUtilities.Wait_for_load_finish();
				// not returning...
				if (new NewProduct().FormError().IsNullOrEmpty())
				{
					return;
				}
				// delete upc that failed
				stepsNewProduct.GivenIDeleteUPC(upc);
				Report.Info("An error was showing! on click continue! Attempting a different UPC");
			}
		}

		[StepDefinition(@"For Staples I create a product of type a product and progress to the UPC screen")]
		public void ForStaplesICreateANewProductAndCheckThatICanSuccessfullyEnterAPartNumber()

		{
			TestReport.UseSubSteps = true;
			var sharedSteps = new Steps_Shared();
			var productsGridSteps = new StepsProductGrid();
			var newProductSteps = new StepsNewProduct();
			var newProduct = new NewProduct();
			var shaSteps = new Steps_SHA();
			var thisGlobalSteps = new GlobalSteps();
			var selectRetailers = new StepsSelectRetailers();
			sharedSteps.GivenICallSharedStepCreateANewRegistrationViaRegisterNewProductIcon();
			sharedSteps.GivenICallSharedStepTheProduct_EnterProductNameAndSelectTypeOfProduct("Chalk");
			sharedSteps.SharedProductCharacteristics_SolidOnlyAvailable_Continue();
			sharedSteps.ICallSharedAdditionalProductInformationUSAndCanadaNoChildNoOSHANoDirectShipNoPLNoNGFR_Continue();
			sharedSteps.ICallSharedIngredients_AddAnyChemical("Sodium hydroxide");
			sharedSteps.ICallSharedRegulatoryInformation1_TSCAAndCEPAShown_NoToProp65();

			Report.Info("Then I select a retailer");
			selectRetailers.SelectTheRetailer("Staples");
			newProductSteps.ClickContinue();
	

		}

		[StepDefinition(@"I enter Container type: (.*), Size (.*), Packaging type: (.*) and Part number: (.*) then click continue in the UPC screen")]
		public void IEnterContainerTypeSizePackagingTypeAndPartNumberThenClickContinue(string containerType, string size, string packagingType, string partNumber)
		{
			TestReport.UseSubSteps = true;
			var newProductSteps = new StepsNewProduct();
			TestReport.StartStep("I Click Add Part Number in the UPC screen");
			newProductSteps.ThenIClickTheAddPartNumber();
			this.IEnterUPCDetailsAndPartNumberIntoTheUPCScreen(containerType,size,packagingType,partNumber);
			TestReport.StartStep("I should see the Regulatory Documents to Provide Page");
			new StepsNewProduct().GivenIShouldSeeXPage("Regulatory Documents to Provide");
		}


		[StepDefinition(@"I enter UPC details, container type: (.*), size: (.*) and packaging type: (.*) then I enter Part Number: (.*)")]
		public void IEnterUPCDetailsAndPartNumberIntoTheUPCScreen(string containerType,string size, string packagingType, string partNumber)
		{
			TestReport.UseSubSteps = true;
			var stepsNewProduct = new StepsNewProduct();
			TestReport.StartStep("I should see the Universal Product Code (UPC) Page");
			stepsNewProduct.GivenIShouldSeeXPage("Universal Product Code (UPC)");
			for (int i = 0; i < 100; i++)
			{
				Report.Info("Entering UPC information. Attempt: " + (i + 1));
				TestReport.StartStep("I add the following into the UPC Fields");
				string upc = TReVorDetails.TReVor.VisualStudioFunctions.GetRandomUpcNumber("CVS");
				Report.Info("UPC number: " + upc);

				var upcInfo = new UpcInformation();
				if (packagingType=="NA")
				{

					upcInfo.ContainerType = containerType;
					upcInfo.Size = size;
										
				}
				else
				{
					upcInfo.ContainerType = containerType;
					upcInfo.Size = size;
					upcInfo.PackageType = packagingType;

				}

				Report.IsTrue(new NewProduct().InputPartNumberInformation(upcInfo,partNumber), "Failed to input UPC Information!",
					"Successfully inputted UPC information!");
				TestReport.StartStep("In the Universal Product Code (UPC) page I click Continue");
				stepsNewProduct.GivenInTheNewProductPageIClickContinue("Universal Product Code (UPC)");
				GeneralUtilities.Wait_for_load_finish();
				// not returning...
				if (new NewProduct().FormError().IsNullOrEmpty())
				{
					return;
				}
				// delete upc that failed
				stepsNewProduct.GivenIDeleteUPC(upc);
				Report.Info("An error was showing! on click continue! Attempting a different UPC");
			}
		}





	}

}

