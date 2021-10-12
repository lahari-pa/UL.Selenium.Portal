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
@UPC
@run_ProductDocuments

Feature: Product Documents

# Assigned to Barrett, Beverly
# Created by Barrett, Beverly
# Test case can be found at the following paths:
# NetProjects10\WERCSmart UX Reboot\WERCSmart\Product Registration\Product Documents
# NetProjects10\WercsSmart Portal\WERCSmart\Product Registration\Product Documents

@59322
@ScenarioId:1317
Scenario: [59322] Upload document - VOC exemption letter & VOC product label
And I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
# And I In the Shared step below select "Personal Fragrance Product (more than 20 percent fragrance)" as your product type
And I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Personal Fragrance Product (more than 20% fragrance) - Liquid
Then I save the product information as: TestCase59322
	Given I call Shared Step 57401 (Product Information - US only - No GHS, Not Direct Ship, Not PLP, Not GNFR > Continue - Happy Path)
And I call Shared Step 70675 (Physical and Chemical Properties - Liquid Only - With Water Solubility - Enter all data - Continue)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
And I call Shared Step 57506 (Transportation Details 1 - Regulated for Transport(No) - Exemption(Random) - Continue - Happy Path)
And I call Shared Step 62536 (Transportation Details 2 > I do not ship internationally > Continue - Happy Path)
# Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB) Page
Then I should see the Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB) Page
And I set the Product has been granted an Alternative Control Plan option to: Yes
And I set the Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the CARB field to: 23
Given in the New Product page I click Continue
Given In the VOC Acceptance section I agree
Given in the New Product page I click Continue
#And I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
And I call Shared Step 63219 (Retailer Association - Select No Retailer - Click continue)
And I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
And I should see the Additional Documents to Provide Page
#And I Confirm the Volatile Organic Compounds - Product Label control and the Volatile Organic Compounds - VOC Exemption letter is shown (other file upload controls may also be shown but we will only use the VOC ones)
Then in the Additional Documents to Provide page I click Continue
Then Volatile Organic Compounds should be showing the error messages: Document is required: VOC Exemption Letter
Then Volatile Organic Compounds should be showing the error messages: Document is required: Product Label
Given I call Shared Step 59042 (Browse for File > select > click Open - Happy Path) for document type: VOC Exemption Letter and file: UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf
Given I call Shared Step 59042 (Browse for File > select > click Open - Happy Path) for document type: Product Label and file: UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf
Given in the New Product page I click Continue
Given in the Optional Reports and Documents Available for Purchase page I click Continue
And I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
And I call Shared Step 57883 (Comments - Happy Path) and enter the comment: test
And I call Shared Step 73956 (Go to Summary and verify data) with product type: Personal Fragrance Product (more than 20% fragrance) - Liquid
And I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase59322



@ScenarioId:1315
Scenario: [59320] Upload Document - IFRA certificate
And I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
And I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Crayon 
Then I save the product information as: TestCase59320
And I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)

And I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
And I call Shared Step 79436 (Ingredients - Add FRAGRANCE component, Publicly Disclosed = Yes,  Select Public Name) and save ingredient as: shared79436
| CASNumber | ComponentName                                                                  | Percentage |
| FRAGRANCE | Fragrance - Awapuhi - Skin sens 1, Repro 2, Aquatic acute 2, Aquatic chronic 2 | 100        |
Given in the Ingredients page I click Continue
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
And I call Shared Step 63219 (Retailer Association - Select No Retailer - Click continue)
And I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
And I should see the Additional Documents to Provide Page
Then in the Additional Documents to Provide page I click Continue
Then International Fragrance Association (IFRA) should be showing the error messages: Document is required: IFRA Certificate (Perfumery Products)
And I call Shared Step 59042 (Browse for File > select > click Open - Happy Path) for document type: IFRA Certificate (Perfumery Products) and file: UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf
Given I call Shared Step 59042 (Browse for File > select > click Open - Happy Path) for document type: Product Label and file: UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf
Then in the Additional Documents to Provide page I click Continue
Given in the Optional Reports and Documents Available for Purchase page I click Continue
And I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
And I call Shared Step 57883 (Comments - Happy Path) and enter the comment: test
And I call Shared Step 73956 (Go to Summary and verify data) with product type: Crayon
And I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase59320


@ScenarioId:1316
Scenario: [59321] Upload Document - GRAS certificate
And I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
And I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Crayon 
Then I save the product information as: TestCase59321
And I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)

And I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
Given I call Shared Step 79431 (Ingredients - Add FLAVOR component, Publicly Disclosed = Yes, Select Public Name) and save ingredients as: shared79431
| CASNumber | ComponentName | Percentage |
| FLAVOR    | FLAVOR        | 100        |
Given in the Ingredients page I click Continue
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
And I call Shared Step 63219 (Retailer Association - Select No Retailer - Click continue)
And I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
And I should see the Additional Documents to Provide Page
Then in the Additional Documents to Provide page I click Continue
Then Generally Recognized as Safe (GRAS) should be showing the error messages: Document is required: GRAS Certificate (Flavor Products)
And I call Shared Step 59042 (Browse for File > select > click Open - Happy Path) for document type: GRAS Certificate (Flavor Products) and file: UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf
Then in the Additional Documents to Provide page I click Continue
Given in the Optional Reports and Documents Available for Purchase page I click Continue
And I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
And I call Shared Step 57883 (Comments - Happy Path) and enter the comment: test
And I call Shared Step 73956 (Go to Summary and verify data) with product type: Crayon
And I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase59321

