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

Scenario: [158930] Home Page Search - Internal Information

Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
Given I generate a random UPC number and save as: RandomUPC
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
Given I save the product information as: TestCase158930
Given I call Shared Step 26897 (Product Characteristics - Solid only available - continue)
Given I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
# Type random string into the Ingredient Reference Number field and save to context as: IngID
Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Water
Given I should see the Waste Classification Data Page
Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Given I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue) for
| Retailer  |
| Walgreens |
Given I click the 'Add UPC' button
Given I enter UPC Number: saved as RandomUPC
Given I Select a container type from the drop down list
Given I enter Size Value: 2
# Enter a random string of letters and numbers 9 chars long into the Internal SKU field and save as: RandomSKU
Given in the Universal Product Code (UPC) page I click Continue
Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
Given in the Additional Documents to Provide page I click Continue
Given in the Optional Reports and Documents Available for Purchase page I click Continue
Given I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
| Appearance | Autoignition Temperature | Minimum Ignition Energy | Odor     | Odor Threshold    | Partition Coefficient | Personal Protection Equipment | Viscosity |
| Black      | 300                      | 1.005                   | Odorless | No data available | 10                    | Mask                          | 20        |
Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: test
Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
Given If purchase details are showing click confirm order
Given I navigate to the home page
Given I click More Filters in the products grid
# Ensure that there is a filter field with the text "Product ID, Ingredient ID, SKU"
# In the Product ID, Ingredient ID, SKU filter field, enter Product Identification saved as: ProdID and click the corresponding search button
# Ensure that the only product returned in the grid is product saved as: TestProduct
# Click the Clear button in the Filters section
# In the Product ID, Ingredient ID, SKU filter field, enter Product Identification saved as: IngID and click the corresponding search button
# Ensure that the only product returned in the grid is product saved as: TestProduct
# Click the Clear button in the Filters section
# In the Product ID, Ingredient ID, SKU filter field, enter Product Identification saved as: RandomSKU and click the corresponding search button
# Ensure that the only product returned in the grid is product saved as: TestProduct
# Click the Clear button in the Filters section
