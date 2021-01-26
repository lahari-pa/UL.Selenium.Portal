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
@WERCSmart_ChooseGoodGuide

@run_SpecFlowFeature1
Feature: SpecFlowFeature1
	Simple calculator for adding two numbers

@philtag1
Scenario: [157758] Forwarding - UPC tab - Internal SKU field

Given I create a product with name: Chalk2 and UPC: UPC91800_2 and take to completed using Test Case 75335 with no login step and save as: NewProduct
Given I navigate to the landing page
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Given I navigate to the landing page
Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
Given I generate a random UPC number and save as: RandomUPC
Given I filter the products by: Accepted by Retailers
Given I search for the product saved as: NewProduct
Given I Confirm the Products shown display the Green Colour Status - which is the Accepted by Retailers
Given I call Shared Step 75130 - Bulk Actions - Select Forward Product Registration
Given I enter the text: saved as NewProduct in the 'Search by WPS ID or Product Name' field
Given In the Foward Product Registration Screen I should see product: saved as NewProduct
Given In the Foward Product Registration Screen I Select the product: saved as NewProduct
Given I click continue on the Forward Product Registration page
Given In the Forward Product Registration Screen I select the first retailer that does not require additional data and is not: CVS under Other Retailers and save it as: NewRetailer
Given I click continue on the Forward Product Registration page
Given I confirm the active Forward Product Registration tab is: Select UPCs
Given I select the first product under the Select UPCs tab
Given I select the first UPC in the grid under the Select UPCs tab
# Click the Edit button for the selected UPC
# Confirm that you see the Edit UPC popup
# Confirm that the Edit UPC popup contains a textbox for Internal SKU
# Enter the following string into the Internal SKU field: 123456789
# Click Save on the Edit UPC popup
# Confirm that your Internal SKU value appears on the collapsed view for the UPC
# Click the Add UPC button# Confirm that the Add UPC popup contains a textbox for Internal SKU. Ensure that it is blank.
# Enter UPC saved as: RandomUPC into the UPC Number field# Select a random Type
# Enter a number for Size
# Enter the following string into the Internal SKU field: 123$%^789
# Click Save on the Add UPC popup
# Ensure that you see an error below the Internal SKU field: Only 8 to 12 letters and/or numbers allowed
# Enter the following string into the Internal SKU field: 123456789123456789# Click Save on the Add UPC popup
# Ensure that you see an error below the Internal SKU field: Only 8 to 12 letters and/or numbers allowed
# Enture the following string into the Internal SKU field: 1231231234
# Click Save on the Add UPC popup
# Confirm that you see your new Internal SKU for your new UPC saved as: RandomUPC in the collapsed UPC view
Given I click continue on the Forward Product Registration page
Given I should see the subheading 3: Product Results on the Forward Product Registration window
Given I confirm that there are NO Errors displayed for the Product
Given I click continue on the Forward Product Registration page
Given I should see the subheading 3: Review & Submit on the Forward Product Registration window
Given I select the true radio for the 'Are Statements True' question under the Review and Submit tab
Given I click continue on the Forward Product Registration page
Given In the Purchase Summary screen I confirm the Purchase Summary header is displayed
















@philtag2
@ScenarioId:10658
Scenario: [156945] Battery Registration - New Battery Package option

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Given If I see the retail partners page I set all data consent tiers to true for all retailers in the top section
Then The home screen should load
Given I delete all products with UPC Number: 630509667031
Given I click the Register New Product icon in the Navigation Pane
Given I should see the header New Product
Given I Select the Create a New Registration radio button
Given in the New Product page I click Continue
Given I set 'Product Name' to: Calculator, Non-Printing, Battery Included
Given I set 'Type of Product' to: Calculator, Non-Printing, Battery Included
Given in the New Product page I click Continue
Then I save the product information as: TestCase156945
Then I should see the Additional Product Information Page
Then In the Additional Information Page the check box for: United States should be: checked
Then I set 'Product is shipped directly' to: No
Then I set 'Product is a Retailers Private Label or Brand' to: No
Then I set 'Product is solely for the Retailer's use' to: No
Then in the New Product page I click Continue
Then For 'U.S. Toxic Substances Control Act (TSCA) status' I select: Compliant
Then I set 'Prop65' to: No
Then in the New Product page I click Continue
Then I should see the Product Includes Battery Page
#
Then For 'Indicate how battery is packaged' I select: Installed in the Product and Shipped with Additional Batteries not within the Product.
Then I add the following batteries:
| Battery Type | How many batteries required to run | Manufacturer | Number of batteries per package | Saved As |
| Alkaline     | 3                                  | <any>        | 1                               | battery2 |
Then in the New Product page I click Continue
Then in page Product Includes Battery I should see error: The number of batteries in the package is less than the number required to run the equipment. Please correct the entries.
Then in page Product Includes Battery I should see error: You have indicated there is a battery in the Product and in the Packaging (not in the Product). This would be a minimum of two (2) batteries in the overall package. Either adjust the selection for Indicate how Battery is Packaged or Update the Number of Batteries or Cells per Package.
Given I call Shared Step 48367 (Product Includes Battery > any type)
| Battery Type | How many batteries required to run | Manufacturer | Number of batteries per package | Saved As |
| Alkaline     | 1                                  | <any>        | 2                               | battery2 |
Then I delete the following battery saved as: battery2
Then I add the following batteries:
| Battery Type | How many batteries required to run | Manufacturer | Number of batteries per package | Saved As |
| Alkaline     | 1                                  | <any>        | 2                               | battery2 |
#
Then I should see the Toxicity Characteristic Leaching Procedure (TCLP) Page
Then I set 'Product has had TCLP; Report is available' to: No
#
Then I set all the metal presence value to: No
Then in the New Product page I click Continue
#
Then I should see the Electronic Equipment Page
Then I set 'Contains Circuit Board' to: No
Then I set 'Has a LCD or Plasma Display' to: No
Then in the New Product page I click Continue
#
Given the 'Select Retailers' window appears
#
Then In the 'Select Retailers' window I select the retailer: Target
Then in the New Product page I click Continue
Given I click the 'Add UPC' button
Then I add the following into the UPC Fields
| UPC Number   | Container Type | Size | DPCI        | Quantity |
| 630509667031 | Aerosol Can    | 20   | 087-16-0238 |          |

Given in the New Product page I click Continue
Then the comments field should appear
Then I enter the following into the comments field: Comments Field Text
Given in the New Product page I click Continue
Then The Data Acceptance page should appear
Given I click the Summary button in the Data Acceptance window
Then I should see the following batteries present:
| BatteryType | Manufacturer | NumberPerPackage | RequiredToRun | Saved As |
| Alkaline    | saved as     | 2                | 1             | battery2 |
Then I switch to the Data Summary page
Then I close the Data Summary tab
Given I navigate to the home page
Then I delete the product: TestCase156945


















@philtag3
@ScenarioId:10657
Scenario: [156910] UPC and Retailer (All)

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Given I click the My Reports icon in the QuickLinks Pane
Given Under the Supplier Reports menu I choose: UPC and Retailer (All)
Given In the Supplier Reports screen the current page description should be: For all active registrations, a list of the UPCs and Retailers associated.
Given In the Supplier Reports screen I click on the Download button
Given I click on close in the Report Download dialog
Given I confirm that an excel file is produced called UPC and Retailer (All).xlsx and save as ExcelReport
Given I confirm that the excel file saved as: ExcelReport contains the following columns:
| Column                       |
| WERCSmart ID                 |
| Product Name                 |
| Brand                        |
| Internal Product ID          |
| Ingredient ID                |
| UPC                          |
| Internal SKU                 |
| UPC Name                     |
| Retailer                     |
| Status                       |
| Ounces                       |
| Unique Product Identifier    |
| Container Type               |
| Package Type                 |
| Net Explosive Mass           |
| Case Pack                    |
| Case Pack Individual UPC     |
| Private Label                |
| Direct Ship Vendor           |
| Goods Not For Resale         |
| Registration Type            |
| Subscription Type            |
| Green Good Housekeeping      |
| Green Seal                   |
| EPA Safer Choice             |
| Cradle To Cradle             |
| UL EcoLogo                   |
| EWG Verified                 |
| Green Tick                   |
| Made Safe                    |
| NSF Sustainability Certified |
Given I delete the excel file saved as ExcelReport























@philtag4
Scenario: [156796] UPC Screen - Internal SKU field - Bulk Upload

Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
Given I generate a random UPC number and save as: RandomUPC_1
Given I generate a random UPC number and save as: RandomUPC_2
Given I generate a random UPC number and save as: RandomUPC_3
Given I generate a random UPC number and save as: RandomUPC_4
Given I generate a random UPC number and save as: RandomUPC_5
# Generate a random SKU number (12 random digits) and save as: RandomSKU_1
# Generate a random SKU number (12 random digits) and save as: RandomSKU_2
# Generate a random SKU number (12 random digits) and save as: RandomSKU_3
# Generate a random SKU number (12 random digits) and save as: RandomSKU_4
# Generate a random SKI number (12 random digits) and save as: RandomSKU_5
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
# The following steps will check if the Bulk Upload of UPC records including Internal SKUs works correctly. Some of these may be reduced into single steps using a table.
# Download the Sample File from the UPC screen and save file as: UPCBulkUploadSampleFile# Ensure that Sample File saved as UPCBulkUploadSampleFile contains a column called 'Internal SKU'
# Replace the first UPC in the spreadsheet saved as UPCBulkUploadSampleFile with UPC saved as: RandomUPC_14
# Enter the SKU saved as RandomSKU_1 in the Internal SKU column for the same record as UPC saved as RandomUPC_1
# Replace the second UPC in the spreadsheet saved as UPCBulkUploadSampleFile with UPC saved as: RandomUPC_2
# Enter the SKU saved as RandomSKU_2 in the Internal SKU column for the same record as UPC saved as RandomUPC_2
# Replace the third UPC in the spreadsheet saved as UPCBulkUploadSampleFile with UPC saved as: RandomUPC_3
# Enter the SKU saved as RandomSKU_3 in the Internal SKU column for the same record as UPC saved as RandomUPC_3
# Replace the fourth UPC in the spreadsheet saved as UPCBulkUploadSampleFile with UPC saved as: RandomUPC_4
# Enter the SKU saved as RandomSKU_4 in the Internal SKU column for the same record as UPC saved as RandomUPC_4
# Replace the fifth UPC in the spreadsheet saved as UPCBulkUploadSampleFile with UPC saved as: RandomUPC_5
# Enter the SKU saved as RandomSKU_5 in the Internal SKU column for the same record as UPC saved as RandomUPC_5
Given I click the 'Upload UPCs' button and upload the file saved as: UPCBulkUploadSampleFile
Given I confirm that the Add Multiple UPC window opens
# Ensure that that Add Multiple UPC window contains a column called 'Internal SKU'
# Ensure that all saved SKUs are present in the 'Internal SKU' column and correspond to their correct UPCsGiven In the Add Multiple dialog box I select all UPCs
Given In the Add Multiple dialog box I select the packaging type: Plastic Container
Given In the Add Multiple dialog box I click Next
Given In the Add Multiple dialog box I select all Retailers
Given In the Add Multiple dialog box I click Finish
Given in the Universal Product Code (UPC) page I click Continue
# Ensure that the flow proceeds to the next page without error
Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase
















@philtag5
Scenario: [156789] UPC Screen - Internal SKU field - Check field parameters and ensure is optional

Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
Given I generate a random UPC number and save as: RandomUPC
# Generate a random SKU number (12 random digits) and save as: RandomSKU
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
# A new shared step will be required for the UPC screen that includes entry of an Internal SKU. Steps are detailed below.
# Enter Random UPC saved as RandomUPC in the UPC field# Select a Container Type
# Enter a Size (Weight Ounces)
# Ensure that Internal SKU field is blank# Click continue
# Ensure that flow proceeds to the next screen - Regulatory Documents to Provide
Given In the New Product page I click tab: Recipient and UPC Details
Given I click the page heading: Universal Product Code (UPC)
# In the following steps, we will test to ensure strings containing less that 12 characters and strings containing special characters get an error when trying to continue for the Internal SKU field
# Enter this string into the Internal SKU field - 12345!@#$%12
# Click continue
# Ensure that page does not proceed and you receive an error in the UPC screen
# Enter this string into the Internal SKU field - 12345678
# Click continue
# Ensure that page does not proceed and you receive an error in the UPC screen
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase















@philtag6
Scenario: [156787] Home Page Search - Internal SKU field

Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
Given I generate a random UPC number and save as: RandomUPC
# Generate a random SKU number (12 random digits) and save as: RandomSKU
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
# A new shared step will be required for the UPC screen that includes entry of an Internal SKU. Steps are detailed below.
# Enter Random UPC saved as RandomUPC in the UPC field
# Select a Container Type# Enter a Size (Weight Ounces)
# Enter your randomly generated SKU saved as: RandomSKU
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
# In the Home screen, in the Products grid, enter SKU saved as RandomSKU into the Internal SKU search box
# Click the Search magnifying glass icon button next to the Internal SKU search field
# Ensure that only the product saved as TestCase is available in the grid
