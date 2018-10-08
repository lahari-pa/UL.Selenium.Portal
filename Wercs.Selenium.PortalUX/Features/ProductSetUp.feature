@LandingPage
@Login
@Homepage
@Signup
@wercsmart
@NewProduct
@ProductGrid
@SHA
@wercsmart
@RetailPartners
@Studio
@run_ProductSetUp

Feature:  Product set up and process to specific statuses (Suite ID: 75359)

Scenario: [75335] Create a new simple product (Chalk) and submit thru to Completed status (NGHS only)
Given I login into the WERCSmart Portal - Administrator Role
Given I generate a random UPC number and save as: UPC75335
Given I delete all products with UPC Number: saved as UPC75335
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
Then I save the product information as: TestCase75335
Given I call Shared Step 26897 (Product Characteristics - Solid only available - continue)
Given I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Given I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue)
Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC75335, container type: Metal Container and size: 40
Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
Given in the Additional Documents to Provide page I click Continue
Given in the Optional Reports and Documents Available for Purchase page I click Continue
Given I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: User added Comments Text 57863. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
Given If purchase details are showing click confirm order
Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase75335)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase75335 and its status is: Submitted
Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase75335)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase75335)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase75335 and its status is: Assigned
Given I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase75335)
Given I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase75335)
Given I call Shared Step 75347 (WPS Studio - PD+ - set all data and publish using rule and Doc queue - CKLT, NGHS and SBCS) for product saved as: TestCase75335
Given I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase75335)
Given I call Shared Step 59066 (Go to SHA Manager)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase75335)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase75335 and its status is: Accepted
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Accepted Status for saved as: TestCase75335)
Given I call Shared Step 51664 (SHA - Accepted Product - set Retailers to Completed for saved as: TestCase75335)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase75335)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase75335 and its status is: Completed

Scenario: [75142] Create a new simple product (Chalk) and submit thru to SHA - Status = Submitted
Given I login into the WERCSmart Portal - Administrator Role
Given I generate a random UPC number and save as: UPC75142
Given I delete all products with UPC Number: saved as UPC75142
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
Then I save the product information as: TestCase75142
Given I call Shared Step 26897 (Product Characteristics - Solid only available - continue)
Given I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Given I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue)
Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC75142, container type: Metal Container and size: 40
Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
Given in the Additional Documents to Provide page I click Continue
Given in the Optional Reports and Documents Available for Purchase page I click Continue
Given I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: User added Comments Text 57863. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
Given If purchase details are showing click confirm order
Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase75142)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase75142 and its status is: Submitted


#Scenario: [80089] Create product with Publicly Disclosed Ingredients (bleach) - process to completed


# Assigned to Beverly Barrett
# Created by Beverly Barrett
Scenario: [79428] Create a 3rd party product - with Tier 2 approval (include generic component)- thru to Completed (includes adding WPSxxxxxx component)
Given I generate a random UPC number and save as: UPC79428
And I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
And I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Raw Material
Then I save the product information as: TestCase79428
Given I call Shared Step 79431 (Ingredients - Add FLAVOR component, Publicly Disclosed = Yes, Select Public Name) and save ingredients as: Ing79428Flav
| CASNumber  | ComponentName | Percentage |
| RR-38669-6 | FLAVORS        | 35         |
And I call Shared Step 79436 (Ingredients - Add FRAGRANCE component, Publicly Disclosed = Yes,  Select Public Name) and save ingredient as: Ing79428Frag
| CASNumber | ComponentName                                                                  | Percentage |
| FRAGRANCE | Fragrance - Awapuhi - Skin sens 1, Repro 2, Aquatic acute 2, Aquatic chronic 2 | 35         |
And I call Shared Step 79490 (Ingredients - Add non-generic component - Public Disclosed = Yes, select Name Continue) and save ingredient as: Ing79428NG
| CASNumber | ComponentName | Percentage |
| 50-00-0   | Formaldehyde  | 30         |
Then in the Ingredients page I click Continue
And I call Shared Step 79507 (Formulation > 3rd Party - Accept formulation - Grant Tier 2 - Continue)
And I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
And I call Shared Step 60932 (Regulatory Information 2 - Microbeads - No)
And I should see the Additional Documents to Provide Page
And I call Shared Step 59042 (Browse for File > select > click Open - Happy Path) for document type: IFRA Certificate (Perfumery Products) and file: C:\Dependencies\WERCSmart\testdoc.pdf
And I call Shared Step 59042 (Browse for File > select > click Open - Happy Path) for document type: GRAS Certificate (Flavor Products) and file: C:\Dependencies\WERCSmart\testdoc.pdf
Then in the Additional documents page I click Continue
Then in the Product aliases page I click Continue
And I call Shared Step 57883 (Comments - Happy Path) and enter the comment: test comment
And I call Shared Step 58610 (Confirm Restrict Use - Restrict)
And I call Shared Step 73956 version 2 (Go to Summary and verify data) with product type: Raw material
Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)

Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase79428)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase79428 and its status is: Submitted
Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase79428)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase79428)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase79428 and its status is: Assigned

Scenario: Test
Given I save to context name: TestCase79428 and value: 1522570
Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
Given I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase79428)
Given I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase79428)
And In Power Designer I left click on section: [SECT0077] Walmart Transportation Information
And In Power Designer I double click on category: Water Soluble?
Then In Power Designer the phrase selector screen should open
And In the phrase selector screen I select phrases:
| Text |
| Y    |
And In the phrase selector screen I click button: Save

And I call Shared Step 79501 (WPS Studio - PD+ - Create Component for 3rd party product)
| Component CAS          | Component ID | Chemical Name               |
| saved as TestCase79428 | MIXTURE      | AAA WERCS Test Raw Material |

And I call Shared Step 79500 (WPS Studio - PD+ - set all data and publish using rule and doc queue - CKLT and SBCS only) for product saved as: TestCase79428
Given I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase79428)
Given I call Shared Step 59066 (Go to SHA Manager)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase79428)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase79428 and its status is: Accepted
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Accepted Status for saved as: TestCase79428)
Given I call Shared Step 51664 (SHA - Accepted Product - set Retailers to Completed for saved as: TestCase79428)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase79428)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase79428 and its status is: Completed
Then I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase79428
