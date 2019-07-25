using NTTQA.Selenium.Reporting.Core;
using TechTalk.SpecFlow;
using UL.Selenium.Portal.WERCSmart.Steps.New_Product;

namespace UL.Selenium.Portal.WERCSmart.Steps
{
	[Binding, Scope(Tag = "CreateProducts")]
	class Steps_CreateProduct
	{
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
	}
}
