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
@PaymentMethods
@SubEnrollment
@WERCSmart_Signup
@MyAccount
@PackagingTypes
@Brands
@MyIngredients
@UPC
@SHA
@ProductSetUp
@ForwardProductRegistration
@ViewUpcs
@WERCSmart_ChooseGoodGuide

@run_SpecFlowFeature1
Feature: SpecFlowFeature1
	Simple calculator for adding two numbers


















@philtag5
@ScenarioId:10661
Scenario: [156789] UPC Screen - Internal SKU field - Check field parameters and ensure is optional

Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
Given I generate a random UPC number and save as: UPC156789
Then Generate a random SKU number (12 random digits) and save as: RandomSKU_1
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
Given I save the product information as: TestCase
Given I call Shared Step 26897 (Product Characteristics - Solid only available - continue)
Given I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Water
Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Given I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue) for
| Retailer  |
| Walgreens |
Given I call Shared Step 87647 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC156789, container type: Plastic Container and size: 2 do not click continue
Given I click continue
Then I should see the Regulatory Documents to Provide Page
Given In the New Product page I click tab: Recipient and UPC Details
Given I click the page heading: Universal Product Code (UPC)
Given I delete UPC: saved as UPC156789
Given I call Shared Step 158500 (Enter Universal Product Code (UPC) - Battery - Confirm SKU - Do Not Click Continue) for UPC saved as: UPC156789 with container type: Metal Container size: 40.0 and SKU: 12345!@#$%12
Given In the Universal Product Code (UPC) page I click Save
Then I check for the appropriate alert: Only 8 to 12 letters and/or numbers allowed
Given I delete UPC: saved as UPC156789
Given I call Shared Step 158500 (Enter Universal Product Code (UPC) - Battery - Confirm SKU - Do Not Click Continue) for UPC saved as: UPC156789 with container type: Metal Container size: 40.0 and SKU: 12345678
Given In the Universal Product Code (UPC) page I click Save
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase














@philtag6
@ScenarioId:10660
Scenario: [156787] Home Page Search - Internal SKU field

Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
Given I generate a random UPC number and save as: UPC156787
Then Generate a random SKU number (12 random digits) and save as: RandomSKU_156787
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
Given I save the product information as: TestCase
Given I call Shared Step 26897 (Product Characteristics - Solid only available - continue)
Given I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Water
Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Given I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue) for
| Retailer  |
| Walgreens |
Given I call Shared Step 158500 (Enter Universal Product Code (UPC) - Battery - Confirm SKU - Do Not Click Continue) for UPC saved as: UPC156787 with container type: Metal Container size: 40.0 and SKU: RandomSKU_156787
Given I click continue
Given I click continue
Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
Given in the Additional Documents to Provide page I click Continue
Given in the Optional Reports and Documents Available for Purchase page I click Continue
Given I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
| Appearance | Autoignition Temperature | Minimum Ignition Energy | Odor     | Odor Threshold    | Partition Coefficient | Personal Protection Equipment | Viscosity |
| Black      | 300                      | 1.005                   | Odorless | No data available | 10                    | Mask                          | 20        |
Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: test
Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
Given If purchase details are showing click confirm order
Given I click the Home navigation icon
Given I search for the product with SKU saved as: RandomSKU_156787
