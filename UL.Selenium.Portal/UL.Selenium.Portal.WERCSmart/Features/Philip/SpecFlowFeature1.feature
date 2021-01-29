@Shared
@RetailPartners
@Homepage
@LandingPage
@ProductGrid
@Login
@SupplierReports
@ForgottenPassword
@CreateProducts
@wercsmart
@DocumentAcceptance
@wercsmart
@ConflictMinerals
@ProductGrid
@Portal_ChooseGoodGuide
@Shared
@LandingPage
@Login
@Homepage
@Signup
@wercsmart
@NewProduct
@ProductGrid
@DataSummarySheet
@wercsmart
@RetailPartners
@SummaryPage
@Shared
@SHA
@LandingPage
@Login
@Homepage
@Signup
@RetailPartners
@wercsmart
@DocumentAcceptance
@WERCSmart_ChooseGoodGuide

@run_SpecFlowFeature1
Feature: SpecFlowFeature1
	Simple calculator for adding two numbers

Scenario: [120815] WERCSmart product - Submitted to SHA, Status = Assigned

# This test case is for loading WS products to be used in RPS testing.  As such it should not be included in any regression tests.
Given I call shared step 144974 (Login to WS as supplier with feed to Web viewers)
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561a (The Product - Enter Product Name: TC 120815 - for RPS - Assigned Status and select Type of Product): Chalk
Given I generate a random UPC number and save as: UPC120815
Then I save the product information as: TestCase120815
Given I call Shared Step 26897 (Product Characteristics - Solid only available - continue)
Given I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Chalk
Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Given I call shared step 120812 (Retailer - Add retailers for RPS)
Given I call shared step 120813 (UPC - Add 2 UPCs - including one for CVS RCL and Add Home Depot OMSID for UPC: CVS, container type: Metal Container and size: 40)
Given I call shared step 51609 (CVS RCL - Yes I wish to continue with registration - Continue)
Given I call shared step 52131 (CVS RCL Information - add Other where available and all other data)
Given I call Shared Step 78080 (Regulatory Documents to Provide - Upload OSHA SDS)
Given in the Additional Documents to Provide page I click Continue
Given in the Optional Reports and Documents Available for Purchase page I click Continue
Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: test
Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
Given If purchase details are showing click confirm order
Given I navigate to the home page
Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Submitted Status for saved as: TestCase120815)
Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase120815)
Given I call Shared Step 59066 (Go to SHA Manager)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Assigned Status for saved as: TestCase120815)
