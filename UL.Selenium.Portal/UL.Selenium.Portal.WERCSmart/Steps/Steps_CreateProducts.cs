using NTTQA.Selenium.Reporting.Core;
using NTTQA.Selenium.SpecFlow;
using TechTalk.SpecFlow;
using TestStack.White.UIItems.TabItems;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;
using UL.Selenium.Portal.WERCSmart.Steps.New_Product;
using UL.Selenium.Portal.WERCSmart.Steps.New_Product.Product_Type;

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
			shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIs(savedAs,"Submitted");
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
			tableSds.AddRow("Mask", "300", "1.005", "20", "Black", "Odorless", "No data available", "10 ");
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
	}
}
