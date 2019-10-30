using NTTQA.Selenium.Reporting.Core;
using NTTQA.Selenium.SpecFlow;
using TechTalk.SpecFlow;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;
using UL.Selenium.Portal.WERCSmart.Steps.New_Product;
using UL.Selenium.Portal.WERCSmart.Steps.New_Product.Product_Type;

namespace UL.Selenium.Portal.WERCSmart.Steps
{
	[Binding, Scope(Tag = "CreateProducts")]
	class Steps_CreateProduct
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
			sharedSteps.GivenICallSharedEnterUniversalProductCodeUPC_CVSUPC_ContainerType_SizeOnly("Metal Container", "40");
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


		
	}

}

