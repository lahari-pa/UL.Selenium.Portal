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
@CreateProducts
@Studio
@ProductSetUp
@run_ProductSetUp

Feature:  Product set up and process to specific statuses (Suite ID: 75359)
@Test1
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
Given I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue) for
| Retailer |
| CVS      |
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
Given I call Shared Step 51664 (SHA - Accepted Product - set Retailers to Completed for saved as: TestCase75335) for
| Retailer |
| CVS      |
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase75335)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase75335 and its status is: Completed

@Test2
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
Given I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue) for
| Retailer |
| CVS      |
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

@Test3
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
Given If purchase details are showing click confirm order

#************************** Switching to SHA Manager ********************
Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase79428)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase79428 and its status is: Submitted
Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase79428)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase79428)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase79428 and its status is: Assigned

#Scenario: Test
#Given I save to context name: TestCase79428 and value: 1523039
#Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
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
Given I click on home to navigate back to editing specific product saved as TestCase79428
And I call Shared Step 79500 (WPS Studio - PD+ - set all data and publish using rule and doc queue - CKLT and SBCS only) for product saved as: TestCase79428
Given I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase79428)
Given I call Shared Step 59066 (Go to SHA Manager)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase79428)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase79428 and its status is: Completed
#Given I navigate to the landing page
#And I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
#Then I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase79428

@Test4

@Test5
Scenario: [80768] Create a 3rd party product - with Tier 2 declined (no generic component) - thru to Completed (includes adding WPSxxxxxx component)
Given I generate a random UPC number and save as: UPC80768
And I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
And I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Raw Material
Then I save the product information as: TestCase80768
And I call Shared Step 79490 (Ingredients - Add non-generic component - Public Disclosed = Yes, select Name Continue) and save ingredient as: Ing79428NG
| CASNumber | ComponentName | Percentage |
| 50-00-0   | Formaldehyde  | 100        |
Then in the Ingredients page I click Continue
And I call Shared Step 79491 (Formulation > 3rd Party - Accept formulation - Decline Tier 2 - Continue)
And I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
And I call Shared Step 60932 (Regulatory Information 2 - Microbeads - No)
#***** the below page is not mentioned in the test design ******
Given in the Aliases page I click Continue
Given in the Additional Documents to Provide page I click Continue
And I call Shared Step 57883 (Comments - Happy Path) and enter the comment: test
And I call Shared Step 58610 (Confirm Restrict Use - Restrict)
And I call Shared Step 73956 (Go to Summary and verify data) with product type: Raw material
Given in the Comments page I click Continue
And I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
Given If purchase details are showing click confirm order

And I call Shared Step 65080 (Login to Studio and Open SHA manager)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase80768)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase80768 and its status is: Submitted
And I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase80768)
And I call Shared Step 49841 (SHA - Search for exact WPS ID in Assigned Status for saved as: TestCase80768)
And I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase80768)
And I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase80768)
And In Power Designer I left click on section: [SECT0077] Walmart Transportation Information
And In Power Designer I double click on category: Water Soluble?
Then In Power Designer the phrase selector screen should open
And In the phrase selector screen I select phrases:
| Text |
| Y    |
And In the phrase selector screen I click button: Save
And I call Shared Step 79501 (WPS Studio - PD+ - Create Component for 3rd party product)
| Component CAS          | Component ID | Chemical Name               |
| saved as TestCase80768 | MIXTURE      | AAA WERCS Test Raw Material |
Given I click on home to navigate back to editing specific product saved as TestCase80768
And I call Shared Step 79500 (WPS Studio - PD+ - set all data and publish using rule and doc queue - CKLT and SBCS only) for product saved as: TestCase80768
And I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase80768)
Given I call Shared Step 59066 (Go to SHA Manager)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase80768)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase80768 and its status is: Completed
#Given I navigate to the landing page
#And I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
#Then I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase80768

@Test6
Scenario: [80763] Create a 3rd party product - with Tier 2 declined (include generic component) - thru to Completed (includes adding WPSxxxxxx component)
Given I generate a random UPC number and save as: UPC80763
And I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
And I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Raw Material
Then I save the product information as: TestCase80763
Given I call Shared Step 79431 (Ingredients - Add FLAVOR component, Publicly Disclosed = Yes, Select Public Name) and save ingredients as: Ing79428Flav
| CASNumber  | ComponentName | Percentage |
| RR-38669-6 | FLAVORS        | 35         |
And I call Shared Step 79436 (Ingredients - Add FRAGRANCE component, Publicly Disclosed = Yes,  Select Public Name) and save ingredient as: Ing79428Frag
| CASNumber | ComponentName                                                                                                                                                  | Percentage |
| FRAGRANCE | Fragrance - Gardenia: Skin irritant 2, Eye damage 1, Skin sensitization 1, Carcinogen 1A, reproductive toxin 2, Aquatic acute 2, Aquatic Chronic 2 / FRAGRANCE | 35         |
And I call Shared Step 79490 (Ingredients - Add non-generic component - Public Disclosed = Yes, select Name Continue) and save ingredient as: Ing79428NG
| CASNumber | ComponentName | Percentage |
| 50-00-0   | Formaldehyde  | 30         |
Then in the Ingredients page I click Continue
And I call Shared Step 79491 (Formulation > 3rd Party - Accept formulation - Decline Tier 2 - Continue)
And I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
And I call Shared Step 60932 (Regulatory Information 2 - Microbeads - No)
And I should see the Additional Documents to Provide Page
And I call Shared Step 59042 (Browse for File > select > click Open - Happy Path) for document type: IFRA Certificate (Perfumery Products) and file: C:\Dependencies\WERCSmart\testdoc.pdf
And I call Shared Step 59042 (Browse for File > select > click Open - Happy Path) for document type: GRAS Certificate (Flavor Products) and file: C:\Dependencies\WERCSmart\testdoc.pdf
Then in the Additional documents page I click Continue
Then in the Product aliases page I click Continue
And I call Shared Step 57883 (Comments - Happy Path) and enter the comment: test
And I call Shared Step 58610 (Confirm Restrict Use - Restrict)
And I call Shared Step 73956 (Go to Summary and verify data) with product type: Raw material
Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
Given If purchase details are showing click confirm order

#************************** Switching to SHA Manager ********************
Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase80763)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase80763 and its status is: Submitted
Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase80763)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase80763)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase80763 and its status is: Assigned
And I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase80763)
And I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase80763)
And In Power Designer I left click on section: [SECT0077] Walmart Transportation Information
And In Power Designer I double click on category: Water Soluble?
Then In Power Designer the phrase selector screen should open
And In the phrase selector screen I select phrases:
| Text |
| Y    |
And In the phrase selector screen I click button: Save
And I call Shared Step 79501 (WPS Studio - PD+ - Create Component for 3rd party product)
| Component CAS          | Component ID | Chemical Name               |
| saved as TestCase80763 | MIXTURE      | AAA WERCS Test Raw Material |
Given I click on home to navigate back to editing specific product saved as TestCase80763
And I call Shared Step 79500 (WPS Studio - PD+ - set all data and publish using rule and doc queue - CKLT and SBCS only) for product saved as: TestCase80763
And I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase80763)
Given I call Shared Step 59066 (Go to SHA Manager)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase80763)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase80763 and its status is: Completed
#Given I navigate to the landing page
#And I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
#Then I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase80763

@Test7
Scenario: [80089] Create product with Publicly Disclosed Ingredients (bleach) - process to completed
Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bleach
Then I save the product information as: TestCase80089
And I call Shared Step 57501 (Product Characteristics - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue - HP)
And I call Shared Step 74340 (Additional Product Information - Pesticide= Not considered, SOLD=US, everything else = No - Continue)
And call Shared Step 80090 - Ingredients - Add non-generic chemical, set to publicly Disclosed, select public name and save ingredient as: Ing800891
| CASNumber | ComponentName | Percentage |
| 100-41-4  | Ethylbenzene  | 35         |
Given I call Shared Step 79431 (Ingredients - Add FLAVOR component, Publicly Disclosed = Yes, Select Public Name) and save ingredients as: Ing800892
| CASNumber  | ComponentName | Percentage |
| RR-38669-6 | FLAVORS       | 35         |
And call Shared Step 80091 - Ingredients - Add Non-generic component - set percentage - not publicly disclosed and save ingredient as: Ing800893
| CASNumber | ComponentName | Percentage |
| 108-95-2  | Phenol        | 30         |
Then in the Ingredients page I click Continue
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
And I call Shared Step 57507 (Transportation Details 1- Not Regulated - Continue - Happy Path)
And I call Shared Step 57712 - ECOLOGO Readiness Assessment - Not at this time - Continue - Happy Path
And I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
And I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
And I should see the Additional Documents to Provide Page
And I call Shared Step 59042 (Browse for File > select > click Open - Happy Path) for document type: IFRA Certificate (Perfumery Products) and file: C:\Dependencies\WERCSmart\testdoc.pdf
And I call Shared Step 59042 (Browse for File > select > click Open - Happy Path) for document type: GRAS Certificate (Flavor Products) and file: C:\Dependencies\WERCSmart\testdoc.pdf
Then in the Additional documents page I click Continue
Given in the Optional Reports and Documents Available for Purchase page I click Continue
Given I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
And I call Shared Step 57883 (Comments - Happy Path) and enter the comment: test
And I call Shared Step 73956 (Go to Summary and verify data) with product type: Bleach
Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
Given If purchase details are showing click confirm order

#************************** Switching to SHA Manager **********************
Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase80089)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase80089 and its status is: Submitted
Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase80089)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase80089)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase80089 and its status is: Assigned
And I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase80089)
And I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase80089)
And I call Shared Step 75347 (WPS Studio - PD+ - set all data and publish using rule and Doc queue - CKLT, NGHS and SBCS) for product saved as: TestCase80089
And I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase80089)
Given I call Shared Step 59066 (Go to SHA Manager)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase80089)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase80089 and its status is: Completed
#Given I navigate to the landing page
#And I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
#Then I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase80089

@Test8
Scenario: [84109] Create Electronic - process to Completed (Answering machine, no battery included)
Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Answering machine, No battery included
Then I save the product information as: TestCase84109
And I call Shared Step 69687 (Additional Product Information - US, No(PL))
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
And I call Shared Step 48369 (Toxicity Characteristics Leaching Procedure (TCLP) - No to ALL With Copper)
And I call Shared Step 71955 (Answer Electronic Equipment questions - Without Cathode Ray - No to all)
And I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
And I should see the Additional Documents to Provide Page
Given in the Additional Documents to Provide page I click Continue
Given in the Optional Reports and Documents Available for Purchase page I click Continue
And I call Shared Step 57883 (Comments - Happy Path) and enter the comment: test
And I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
Given If purchase details are showing click confirm order

Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase84109)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase84109 and its status is: Submitted
Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase84109)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase84109)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase84109 and its status is: Assigned
And I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase84109)

#Note: In Staging and Production - Electronic products are automatically published by the ImportProcessRules so if you are running in either of these sites you can skip to step 28
	And I check whether the current environment is Staging or Production and if it is I skip the next three steps
	And I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase84109)
	And I call Shared Step 79500 (WPS Studio - PD+ - set all data and publish using rule and doc queue - CKLT and SBCS only) for product saved as: TestCase84109
	And I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase84109)

Given I call Shared Step 59066 (Go to SHA Manager)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase84109)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase84109 and its status is: Completed
#Given I navigate to the landing page
#And I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
#Then I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase84109

@Test9
Scenario: [84511] Electronic Product from Completed status to Recertification
#If you are using this test case you already have a product you are working with and it is in a Completed status for 1 or more retailers.
Given I create an electronic product and save it as: TestCase84511
Given I navigate to the landing page
Given I login into the WERCSmart Portal - Administrator Role
Given I search for the product saved as: TestCase84511
Given For product saved as: TestCase84511 the status is: Completed
And I click Row Actions for the first product returned
And I click on the Row Action: Update Data
#And I If you are using a supplier registered for ULSC you will see the ULSC Service Data-Re-Import step, select the No, continue editing data radio button and click Save
And I should see the The Product Page
Then I click Save in The Product Page
#Scenario: Test
#Given I save to context name: TestCase84511 and value: 1524214
Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase84511)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase84511 and its status is: Completed
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase84511 and its font is red indicating a recertification
And I call Shared Step 51351 (SHA > Select Product > View Recertification History) for product saved as: TestCase84511
And In the Product Recertification History popup I should see the following entry
| Product ID             | Active | Recertification Reason                           |
| saved as TestCase84511 | true   | Recertification of Product by WERCSmart Customer |
And I Close the Product Recertification History pop up
#Scenario: Test
#Given I save to context name: TestCase84511 and value: 1524214
Given I navigate to the landing page
Given I login into the WERCSmart Portal - Administrator Role
Given I search for the product saved as: TestCase84511
Given For product saved as: TestCase84511 the status is: Needs Your Attention
And I click Row Actions for the first product returned
And I click on the Row Action: Update Required
#And I If you are using a supplier registered for ULSC you will see the ULSC Service Data-Re-Import step, select the No, continue editing data radio button and click Save
And I should see the The Product Page
And In the New Product page I click tab: Product Characteristics
And in the New Product page I click section: Toxicity Characteristic Leaching Procedure (TCLP)
And I set the Lead option to: Yes
And I set the Mercury option to: Yes
And I set the Silver option to: Yes
Then I click Save in The Product Page
And In the New Product page I click tab: Review and Submit
And in the New Product page I click section: Data Acceptance
And In the Data Acceptance page I click on the Accept button
Given If purchase details are showing click confirm order
And I navigate to the home page
And I search for the product saved as: TestCase84511
Given For product saved as: TestCase84511 the status is: Assessment in Progress
Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase84511)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase84511 and its status is: Recertification
#And I Confirm your product is shown in the Recertification status without the red recertification font color
And I call Shared Step 51351 (SHA > Select Product > View Recertification History) for product saved as: TestCase84511
And In the Product Recertification History popup I should see the following entry
| Product ID             | Active | Recertification Reason                           |
| saved as TestCase84511 | false  | Recertification of Product by WERCSmart Customer |
And I Close the Product Recertification History pop up
#Given I navigate to the landing page
#And I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
#Then I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase84511

@Test10
Scenario: [75410] Product from Completed status to Recertification
Given I create a product and take to completed using Test Case 75335 and save as: TestCase75410

#Scenario: Test
#Given I save to context name: TestCase75410 and value: 1524399
Given I navigate to the landing page
Given I login into the WERCSmart Portal - Administrator Role
Given I search for the product saved as: TestCase75410
Given For product saved as: TestCase75410 the status is: Completed
And I click Row Actions for the first product returned
And I click on the Row Action: Update Data
#And I If you are using a supplier registered for ULSC you will see the ULSC Service Data-Re-Import step, select the No, continue editing data radio button and click Save
And I should see the The Product Page
Then I click Save in The Product Page

#Scenario: Test
#Given I save to context name: TestCase75410 and value: 1524479
Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase75410)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase75410 and its status is: Completed
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase75410 and its font is red indicating a recertification
And I call Shared Step 51351 (SHA > Select Product > View Recertification History) for product saved as: TestCase75410
And In the Product Recertification History popup I should see the following entry
| Product ID             | Active | Recertification Reason                           |
| saved as TestCase75410 | true   | Recertification of Product by WERCSmart Customer |

Given I navigate to the landing page
Given I login into the WERCSmart Portal - Administrator Role
Given I search for the product saved as: TestCase75410
Given For product saved as: TestCase75410 the status is: Needs Your Attention
And I click Row Actions for the first product returned
And I click on the Row Action: Update Required
#And I If you are using a supplier registered for ULSC you will see the ULSC Service Data-Re-Import step, select the No, continue editing data radio button and click Save
And I should see the The Product Page
And in the New Product page I click section: Product Characteristics
And I Change the Secondary Physical State drop down from its current selection to a new selection
Then I click Save in The Product Page
And In the New Product page I click tab: Review and Submit
And in the New Product page I click section: Data Acceptance
And In the Data Acceptance page I click on the Accept button
Given If purchase details are showing click confirm order
And I navigate to the home page
And I search for the product saved as: TestCase75410
Given For product saved as: TestCase75410 the status is: Assessment in Progress
Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase75410 and its status is: Recertification
#And I Confirm your product is shown in the Recertification status without the red recertification font color
And I call Shared Step 51351 (SHA > Select Product > View Recertification History) for product saved as: TestCase75410
And In the Product Recertification History popup I should see the following entry
| Product ID             | Active | Recertification Reason                           |
| saved as TestCase75410 | false  | Recertification of Product by WERCSmart Customer |
And I Close the Product Recertification History pop up
#Given I navigate to the landing page
#And I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
#Then I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase75410

@Test11
Scenario: [84507] Recertification > Process recertification > Process multiple products
Given I create a product with name: 8450712 and take to completed using Test Case 84108 and save as: TestCase845072
Given I take a product from completed to recertification using Test Case 75410 saved: TestCase845072
Given I create a product with name: 8450711 and take to completed using Test Case 75335 and save as: TestCase845071
Given I take a product from completed to recertification using Test Case 75410 saved: TestCase845071
Given I create a product with name: 8450713 and take to completed using Test Case 84109 and save as: TestCase845073
Given I take a product from completed to recertification using Test Case 84511 saved: TestCase845073

#Scenario: Test
#And I call Shared Step 65080 (Login to Studio and Open SHA manager)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Recertification Status for saved as: TestCase84511)
Given In SHA Manager ProductSearch page I run search:
| Status          | SearchPattern | ProductName |
| Recertification | Contains      | 845071      |
Given In SHA Manager I select the following products:
| ProductID               |
| saved as TestCase845071 |
| saved as TestCase845072 |
| saved as TestCase845073 |
And I Click the Process Recertification button
And I Confirm the Recertification pop up is shown
And I Uncheck the Auto Assign Regulatory Specialist to Product check box
And I Select AutomatedQASha  from the drop down list for Select Regulatory Specialist
And In the Recertification popup I click Continue
And In the Recertification popup the Continue button will no longer be shown
#And I After a short interval the Progress bar will show as grey hatching indicating processing of the first product has finished
#And I After each product is processed the progress bar will move along until it it shown in complete grey color
And in the Recertification popup I wait for all processing to be completed
And in the Recertification popup I should see the following products as successfully assigned
| ProductID               |
| saved as TestCase845071 |
| saved as TestCase845072 |
| saved as TestCase845073 |
And In the Recertification popup I click Continue
And I Confirm the Recertification pop up is closed
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase845072)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase845071 and its status is: Assigned
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase845072)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase845072 and its status is: Assigned
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase845072)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase845073 and its status is: Assigned


@Test12
Scenario: [85965] Create a new simple product (Chalk) with SOLD = US Only, PL = Yes and submit thru to Completed status (NGHS only)
Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
Given I generate a random UPC number and save as: UPC85965
Given I delete all products with UPC Number: saved as UPC85965
And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
Then I save the product information as: TestCase85965
And I call Shared Step 26897 (Product Characteristics - Solid only available - continue)
And I call Shared Step 63860 (Additional Product Information - US, No(child), No(OSHA), No(DSV), Yes(PLP), No(GNFR))
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
And I call Shared Step 85990 - Retailers - PLP - Select one or more retailer and add PL information - Continue
| Retailer       |
| CVS            |
| Dollar General |
Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC85965, container type: Metal Container and size: 40
And I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
Given in the Additional Documents to Provide page I click Continue
Given in the Optional Reports and Documents Available for Purchase page I click Continue
Given I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
And I call Shared Step 57883 (Comments - Happy Path) and enter the comment: Test comment
And I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
#Depending on your subscription you will either see the Purchase summary success message or you will see the Purchase summary with you product details shown.  If the product details are shown click Confirm order
Given If purchase details are showing click confirm order
Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase85965)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase85965 and its status is: Submitted
Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase85965)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase85965)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase85965 and its status is: Assigned
And I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase85965)
And I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase85965)
Given I call Shared Step 85983 - WPS Studio - PD\+ PLP with NGHS only - set all data and publish using rule and DOC queue for product saved as: TestCase85965
And I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase85965)
Given I call Shared Step 59066 (Go to SHA Manager)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase85965)
#Note: If the retailer you selected does not have a feed then the retailer will be shown in Completed status
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase85965 and its status is: Accepted
Given I call Shared Step 51664 (SHA - Accepted Product - set Retailers to Completed for saved as: TestCase85965) for
| Retailer       |
| CVS            |
| Dollar General |
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase85965)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase85965 and its status is: Completed

@Test13
Scenario: [77859] Create a kit  - Direct ship = Yes Retailer not Walmart thru to Submitted status 1
#For this test case you will need two input products in completed status which have SOLD set to US only
#and make sure to add any retailer except Walmart as the retailer for these products.
#Use the test case 75335 to create these products - test case is linked to this one.
#Note: these input products do not have to be direct ship vendor products
Given I create a product with name: 778591 and take to completed using Test Case 75335 and save as: TestCase778591
Given I create a product with name: 778592 and take to completed using Test Case 75335 and save as: TestCase778592
Given I navigate to the landing page

#Scenario: [77859] Create a kit  - Direct ship = Yes Retailer not Walmart thru to Submitted status
#Given I save to context name: TestCase778591 and value: 1525307
#Given I save to context name: TestCase778592 and value: 1525308
And I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
Given I generate a random UPC number and save as: UPC77859
Given I delete all products with UPC Number: saved as UPC77859
And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
#In the shared step below use any of the kit product types - these are Cosmetic Products in a kit (RU000777)Hair Care kit (RU000723)Hair Color Kit (RU000724)Emergency Road kit (RU000718)Automotive Care Products (RU000124)Personal Care kit (RU001034)
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Personal Care kit
Then I save the product information as: TestCase77859
And I call Shared Step 77872 (Additional Product Information - Kit flow - US only, Direct Ship (yes), Continue)
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
# In the shared step below add the two completed products that you are working with
And I call Shared Step 31427 (Create the Kit - Adding two products: product 1: TestCase778591  and product 2: TestCase778592)
And I call Shared Step 57507 (Transportation Details 1- Not Regulated - Continue - Happy Path)
# In the shared step below do NOT select Walmart as your retailer
Given I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue) for
| Retailer |
| CVS      |
And I call Shared Step 42759 (Portal - UPC Page - add 1 UPC)
Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: User added Comments Text 57863. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
Given If purchase details are showing click confirm order
And I call Shared Step 65080 (Login to Studio and Open SHA manager)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase77859)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase77859 and its status is: Submitted
Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase77859)

#Scenario: test
#Given I save to context name: TestCase77859 and value: 1525212
And I call Shared Step 65080 (Login to Studio and Open SHA manager)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase77859 and its status is: Assigned
And I Confirm the Product ID: saved as TestCase77859 is not highlited yellow indicating that this is not an e-comm/direct ship product
And I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase77859)
And I call Shared Step 20375 - Go to Product Attributes via Authoring Tab in PDP/PAP (Maxed Out)
And I call Shared Step 78799 - WPS PD+ - Product Attributes - Filter for CNTXT
And In Product Attributes Popup Page I should see 0 results

@Test14
Scenario: [80821] Create a 3rd party product - with Tier 2 approval Specific components for Transparency ratio testing
Given I generate a random UPC number and save as: UPC80821
And I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
And I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Raw Material
Then I save the product information as: TestCase80821
And I call Shared Step 80822 - Ingredients - Add non-generic - specific component - set publicly disclosed and add public name and save ingredient as: Ing808211
| CASNumber | ComponentName | Percentage | Publicly Disclosed | Public Name            |
| 100-41-4  | Ethylbenzene  | 25         | Yes                | Undisclosed Ingredient |
And In the Ingredients page I confirm the Publicly Disclosed Transparency Score has numerator: 1 and denominator: 1
And In the Ingredients page I confirm the Publicly Disclosed Transparency score is flagged as a success
And I call Shared Step 80822 - Ingredients - Add non-generic - specific component - set publicly disclosed and add public name and save ingredient as: Ing808212
| CASNumber  | ComponentName | Percentage | Publicly Disclosed | Public Name            |
| 37334-84-2 | Cellolyn 21   | 15         | No                 | Undisclosed Ingredient |
And In the Ingredients page I confirm the Publicly Disclosed Transparency Score has numerator: 1 and denominator: 2
And In the Ingredients page I confirm the Publicly Disclosed Transparency score is flagged as a warning
And I call Shared Step 79436 (Ingredients - Add FRAGRANCE component, Publicly Disclosed = Yes,  Select Public Name) and save ingredient as: Ing808213
| CASNumber  | ComponentName    | Percentage |
| RR-38384-6 | FRAGRANCE-HERBAL | 10         |
And In the Ingredients page I confirm the Publicly Disclosed Transparency Score has numerator: 1 and denominator: 3
And In the Ingredients page I confirm the Publicly Disclosed Transparency score is flagged as a warning
And I call Shared Step 79436 (Ingredients - Add FRAGRANCE component, Publicly Disclosed = Yes,  Select Public Name) and save ingredient as: Ing808214
| CASNumber  | ComponentName    | Percentage |
| RR-38213-8 | FRAGRANCE-BANANA | 10         |
Then In the Ingredients page I confirm the Publicly Disclosed Transparency Score has numerator: 1 and denominator: 4
And In the Ingredients page I confirm the Publicly Disclosed Transparency score is flagged as a danger
And I call Shared Step 80822 - Ingredients - Add non-generic - specific component - set publicly disclosed and add public name and save ingredient as: Ing808215
| CASNumber | ComponentName    | Percentage | Publicly Disclosed | Public Name            |
| FLAVOR    | 611 Grape Flavor | 10         | No                 | Undisclosed Ingredient |
And In the Ingredients page I confirm the Publicly Disclosed Transparency Score has numerator: 1 and denominator: 5
And In the Ingredients page I confirm the Publicly Disclosed Transparency score is flagged as a danger
And I call Shared Step 80822 - Ingredients - Add non-generic - specific component - set publicly disclosed and add public name and save ingredient as: Ing808216
| CASNumber | ComponentName                 | Percentage | Publicly Disclosed | Public Name            |
| NA519     | Black Cherry - Natural Flavor | 10         | Yes                | Undisclosed Ingredient |
And In the Ingredients page I confirm the Publicly Disclosed Transparency Score has numerator: 2 and denominator: 6
And In the Ingredients page I confirm the Publicly Disclosed Transparency score is flagged as a warning
And I call Shared Step 79436 (Ingredients - Add FRAGRANCE component, Publicly Disclosed = Yes,  Select Public Name) and save ingredient as: Ing808217
| CASNumber | ComponentName                                                                                                       | Percentage |
| FRAGRANCE | Fragrance - Birch Branch: Skin Irrit. 2, Eye Irrit. 2A, Skin Sens. 1, Repro Tox 2, Acute Aquatic 2, Chronic Acute 2 | 10         |
And In the Ingredients page I confirm the Publicly Disclosed Transparency Score has numerator: 2 and denominator: 7
And In the Ingredients page I confirm the Publicly Disclosed Transparency score is flagged as a warning
And I call Shared Step 80822 - Ingredients - Add non-generic - specific component - set publicly disclosed and add public name and save ingredient as: Ing808218
| CASNumber | ComponentName | Percentage | Publicly Disclosed | Public Name            |
| 7732-18-5 | Water         | 10         | Yes                | Undisclosed Ingredient |
And In the Ingredients page I confirm the Publicly Disclosed Transparency Score has numerator: 3 and denominator: 8
And In the Ingredients page I confirm the Publicly Disclosed Transparency score is flagged as a warning
Then in the Ingredients page I click Continue
And I call Shared Step 79507 (Formulation > 3rd Party - Accept formulation - Grant Tier 2 - Continue)
And I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
And I call Shared Step 60932 (Regulatory Information 2 - Microbeads - No)
And I should see the Additional Documents to Provide Page
And I call Shared Step 59042 (Browse for File > select > click Open - Happy Path) for document type: IFRA Certificate (Perfumery Products) and file: C:\Dependencies\WERCSmart\testdoc.pdf
And I call Shared Step 59042 (Browse for File > select > click Open - Happy Path) for document type: GRAS Certificate (Flavor Products) and file: C:\Dependencies\WERCSmart\testdoc.pdf
Then in the Additional documents page I click Continue
Then in the Product aliases page I click Continue
And I call Shared Step 57883 (Comments - Happy Path) and enter the comment: test
And I call Shared Step 58610 (Confirm Restrict Use - Restrict)
And I call Shared Step 73956 (Go to Summary and verify data) with product type: Raw material
Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
Given If purchase details are showing click confirm order

#Scenario: test
#Given I save to context name: TestCase80821 and value: 1525198
And I call Shared Step 65080 (Login to Studio and Open SHA manager)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase80821)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase80821 and its status is: Submitted
Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase80821)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase80821)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase80821 and its status is: Assigned
And I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase80821)
And I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase80821)
And In Power Designer I left click on section: [SECT0077] Walmart Transportation Information
And In Power Designer I double click on category: Water Soluble?
Then In Power Designer the phrase selector screen should open
And In the phrase selector screen I select phrases:
| Text |
| Y    |
And In the phrase selector screen I click button: Save
And I call Shared Step 79501 (WPS Studio - PD+ - Create Component for 3rd party product)
| Component CAS          | Component ID | Chemical Name               |
| saved as TestCase80821 | MIXTURE      | AAA WERCS Test Raw Material |
Given I click on home to navigate back to editing specific product saved as TestCase80821
And I call Shared Step 79500 (WPS Studio - PD+ - set all data and publish using rule and doc queue - CKLT and SBCS only) for product saved as: TestCase80821
Given I call Shared Step 59066 (Go to SHA Manager)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase80821)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase80821 and its status is: Completed
#Given I navigate to the landing page
#And I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
#Then I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase80821

# Assigned to Barrett, Beverly
# Created by Barrett, Beverly

# Test case can be found at the following paths:
# NetProjects10\WercsSmart Portal\WERCSmart\Canadian Tire - Blue Box Program\New Product Submission\Submit and process to Completed\Account has Full Stewardship Data

Scenario: [86187] Create a new simple product SOLD = US and Canada, PL = Yes, Canadian Tire Retailer Product  - submit thru to Completed status
Given [Shared Step 85328 - Login to WERCSmart - Canada - Address (Yes), Packaging (Yes), Stewardship (Full)]
And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
And I In the shared step below select Chalk as your product type
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): (.*)
And I Make a note of the WPS ID shown at the top of the screen
And I call Shared Step 26897 (Product Characteristics - Solid only available - continue)
And [Shared Step 85284 - Additional Product Information - US & Canada, Child (No), OSHA (No), DSV (No), PLP (YES), GNFR (No), Continue]
And I call Shared Step 29181 (Ingredients - add any chemical) with name: (.*)
And I call Shared Step 57637 (Regulatory Information 1 - TSCA & CEPA shown, No to PROP 65 - Continue - Happy Path)
And I In the shared step below  be sure to select Canadian Tire as the retailer
And [Shared Step 85990 - Retailers - PLP - Select one or more retailer and add PL information - Continue]
And [Shared Step 75702 - UPC - Add UPC, Container type, Size and Package type (no retailer data needed) - Continue]
And [Shared Step 78868 - Regulatory Documents to Provide - US and Canada - Request authoring for both]
And I The Additional documents to provide step is shown
And I Click Continue
And I The Optional Reports and Documents Available for Purchase step is shown
And I Click Continue
And [Shared Step 64097 - Additional Documents -> Contact Information - Add any Name, address, phone and emergency phone - Happy Path]
And I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
| Requires Table |
| Parameters     |
And I call Shared Step 57883 (Comments - Happy Path) and enter the comment: (.*)
And I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
And I The Purchase summary page shows with you product details shown.  Confirm you see entries for your product for Chemical assessment, SDS authoring North American Combined GHS SDS ENGLISH (USA), Additional document Canada GHS SDS ENGLISH (USA) Additional document language Canada GHS SDS FRENCH (CANADA)
And I Click Confirm Order
And I Click Home
And I call Shared Step 65080 (Login to Studio and Open SHA manager)
And I In the shared step below filter for your product
And I call Shared Step 49841 (SHA - Search for exact WPS ID in (.*) Status for saved as: (.*))
And I Confirm your product is shown in the Submitted status.Note this may take a few minutes for the Zuora process to process your product, if it is not shown in Submitted wait a minute or two and re-search for your product
And I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: (.*))
And I call Shared Step 49841 (SHA - Search for exact WPS ID in (.*) Status for saved as: (.*))
And I Confirm the product is shown in the Assigned status
And I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: (.*))
And I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: (.*))
And [Shared Step 78877 - WPS Studio - PD+ - set all data and publish using rule and doc queue - CKLT, NGHS, HSGH (EN and CF) and SBCS]
And I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: (.*))
And I IN SHA Manager - use the step below to search for your product
And I call Shared Step 49841 (SHA - Search for exact WPS ID in (.*) Status for saved as: (.*))
And I Confirm the product is shown in Accepted or Completed status depending in the retailers selected
And I If any retailer is shown in accepted status use the shared step below to set all to Completed
And I call Shared Step 51664 (SHA - Accepted Product - set Retailers to Completed for saved as: (.*))
