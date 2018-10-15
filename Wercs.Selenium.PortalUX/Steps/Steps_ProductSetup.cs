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
	[Binding]
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
			sharedSteps.GivenICallShared51664SHA_AcceptedProduct_SetRetailersToCompletedForSavedAs(savedAs);
			// 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase75335)
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			// In the SHA manager grid I see the WPS ID I have saved as product: TestCase75335 and its status is: Completed
			shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIsAssigned(savedAs, "Completed");
		}

		[StepDefinition(@"I create a product and take to completed using Test Case 75335 and save as: (.*)")]
		public void CreateProductUsingTestCase75335(string savedAs)
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
			sharedSteps.GivenICallShared51664SHA_AcceptedProduct_SetRetailersToCompletedForSavedAs(savedAs);
			// 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase75335)
			sharedSteps.GivenICallShared49841SHA_SearchForExactWPSIDInALLStatus("All", savedAs);
			// In the SHA manager grid I see the WPS ID I have saved as product: TestCase75335 and its status is: Completed
			shaSteps.GivenInTheSHAManagerGridISeeTheWPSIDIHaveSavedAsProductTestCaseAndItsStatusIsAssigned(savedAs, "Completed");
		}

	}
}
