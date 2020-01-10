@Shared
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
@run_ProductSetUp3rdParty
Feature: ProductSetUp_3rdParty

@ScenarioId:1418
Scenario: [79428] Create a 3rd party product - with Tier 2 approval (include generic component)- thru to Completed (includes adding WPSxxxxxx component)
	Given I generate a random UPC number and save as: UPC79428
	And I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	And I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Raw Material
	Then I save the product information as: TestCase79428
	Given I call Shared Step 79431 (Ingredients - Add FLAVOR component, Publicly Disclosed = Yes, Select Public Name) and save ingredients as: Ing79428Flav
		| CASNumber  | ComponentName | Percentage |
		| RR-38669-6 | FLAVORS       | 35         |
	And I call Shared Step 79436 (Ingredients - Add FRAGRANCE component, Publicly Disclosed = Yes,  Select Public Name) and save ingredient as: Ing79428Frag
		| CASNumber | ComponentName                                                                  | Percentage |
		| FRAGRANCE | Fragrance - Awapuhi - Skin sens 1, Repro 2, Aquatic acute 2, Aquatic chronic 2 | 35         |
	And I call Shared Step 79490 (Ingredients - Add non-generic component - Public Disclosed = Yes, select Name Continue) and save ingredient as: Ing79428NG
		| CASNumber | ComponentName | Percentage |
		| 50-00-0   | Formaldehyde  | 30         |
	Then in the Ingredients page I click Continue
	#And I call Shared Step 79507 (Formulation > 3rd Party - Accept formulation - Grant Tier 2 - Continue)
	Then I call Shared Step 48948 (Formulation > 3rd Party - Select all)
	And I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	And I call Shared Step 60932 (Regulatory Information 2 - Microbeads - No)
	And I should see the Additional Documents to Provide Page
	And I call Shared Step 59042 (Browse for File > select > click Open - Happy Path) for document type: IFRA Certificate (Perfumery Products) and file: C:\Dependencies\WERCSmart\testdoc.pdf
	And I call Shared Step 59042 (Browse for File > select > click Open - Happy Path) for document type: GRAS Certificate (Flavor Products) and file: C:\Dependencies\WERCSmart\testdoc.pdf
	Then in the Additional documents page I click Continue
	Then in the Formulation Names page I click Continue
	And I call Shared Step 58610 (Confirm Restrict Use - Restrict)
	Then in the Sustainability Information page I click Continue
	And I call Shared Step 57883 (Comments - Happy Path) and enter the comment: test
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
	And In Power Designer I left click on section: [SECT2318] WALMART QC RESPONSE FORM
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

@ScenarioId:1420
Scenario: [80768] Create a 3rd party product - with Tier 2 declined (no generic component) - thru to Completed (includes adding WPSxxxxxx component)
	Given I generate a random UPC number and save as: UPC80768
	And I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	And I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Raw Material
	Then I save the product information as: TestCase80768
	And I call Shared Step 79490 (Ingredients - Add non-generic component - Public Disclosed = Yes, select Name Continue) and save ingredient as: Ing80768NG
		| CASNumber | ComponentName | Percentage |
		| 50-00-0   | Formaldehyde  | 100        |
	Then in the Ingredients page I click Continue
	And I call Shared Step 79491 (Formulation > 3rd Party - Accept formulation - Decline Tier 2 - Continue)
	And I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	And I call Shared Step 60932 (Regulatory Information 2 - Microbeads - No)
	#***** the below page is not mentioned in the test design ******
	Given in the Additional Documents to Provide page I click Continue
	Then in the Formulation Names page I click Continue
	And I call Shared Step 58610 (Confirm Restrict Use - Restrict)
	Then in the Sustainability Information page I click Continue
	And I call Shared Step 57883 (Comments - Happy Path) and enter the comment: test
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
	And In Power Designer I left click on section: [SECT2318] WALMART QC RESPONSE FORM
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

@ScenarioId:1419
Scenario: [80763] Create a 3rd party product - with Tier 2 declined (include generic component) - thru to Completed (includes adding WPSxxxxxx component)
	Given I generate a random UPC number and save as: UPC80763
	And I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	And I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Raw Material
	Then I save the product information as: TestCase80763
	Given I call Shared Step 79431 (Ingredients - Add FLAVOR component, Publicly Disclosed = Yes, Select Public Name) and save ingredients as: Ing80763Flav
		| CASNumber  | ComponentName | Percentage |
		| RR-38669-6 | FLAVORS       | 35         |
	And I call Shared Step 79436 (Ingredients - Add FRAGRANCE component, Publicly Disclosed = Yes,  Select Public Name) and save ingredient as: Ing80763Frag
		| CASNumber | ComponentName                                                                                                                                                  | Percentage |
		| FRAGRANCE | Fragrance - Gardenia: Skin irritant 2, Eye damage 1, Skin sensitization 1, Carcinogen 1A, reproductive toxin 2, Aquatic acute 2, Aquatic Chronic 2 / FRAGRANCE | 35         |
	And I call Shared Step 79490 (Ingredients - Add non-generic component - Public Disclosed = Yes, select Name Continue) and save ingredient as: Ing80763NG
		| CASNumber | ComponentName | Percentage |
		| 50-00-0   | Formaldehyde  | 30         |
	Then in the Ingredients page I click Continue
	And I call Shared Step 79491 (Formulation > 3rd Party - Accept formulation - Decline Tier 2 - Continue)
	And I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	And I call Shared Step 60932 (Regulatory Information 2 - Microbeads - No)
	And I should see the Additional Documents to Provide Page
	And I call Shared Step 59042 (Browse for File > select > click Open - Happy Path) for document type: IFRA Certificate (Perfumery Products) and file: C:\Dependencies\WERCSmart\testdoc.pdf
	And I call Shared Step 59042 (Browse for File > select > click Open - Happy Path) for document type: GRAS Certificate (Flavor Products) and file: C:\Dependencies\WERCSmart\testdoc.pdf
	Then in the Additional Documents to Provide page I click Continue
	Then in the Formulation Names page I click Continue
	And I call Shared Step 58610 (Confirm Restrict Use - Restrict)
	Then in the Sustainability Information page I click Continue
	And I call Shared Step 57883 (Comments - Happy Path) and enter the comment: test
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
	And In Power Designer I left click on section: [SECT2318] WALMART QC RESPONSE FORM
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

@ScenarioId:1562
Scenario: [80821] Create a 3rd party product - with Tier 2 approval Specific components for Transparency ratio testing
	Given I generate a random UPC number and save as: UPC80821
	And I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	And I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Raw material
	Then I save the product information as: TestCase80821
	And I call Shared Step 80822 - Ingredients - Add non-generic - specific component - set publicly disclosed and add public name and save ingredient as: Ing808211
		| CASNumber | ComponentName | Percentage | Publicly Disclosed | Public Name            |
		| 100-41-4  | Ethylbenzene  | 25         | Yes                | Undisclosed Ingredient |
	And I verify the Transparency Score displays 100.00%
	And In the Ingredients page I confirm the Publicly Disclosed Transparency score is flagged as a success
	And I call Shared Step 80822 - Ingredients - Add non-generic - specific component - set publicly disclosed and add public name and save ingredient as: Ing808212
		| CASNumber  | ComponentName | Percentage | Publicly Disclosed |
		| 37334-84-2 | Cellolyn 21   | 15         | No                 |
	And I verify the Transparency Score displays 50.00%
	And In the Ingredients page I confirm the Publicly Disclosed Transparency score is flagged as a warning
	And I call Shared Step 79436 (Ingredients - Add FRAGRANCE component, Publicly Disclosed = Yes,  Select Public Name) and save ingredient as: Ing808213
		| CASNumber  | ComponentName    | Percentage |
		| RR-38384-6 | FRAGRANCE-HERBAL | 10         |
	And I verify the Transparency Score displays 33.33%
	And In the Ingredients page I confirm the Publicly Disclosed Transparency score is flagged as a warning
	And I call Shared Step 79436 (Ingredients - Add FRAGRANCE component, Publicly Disclosed = Yes,  Select Public Name) and save ingredient as: Ing808214
		| CASNumber  | ComponentName    | Percentage |
		| RR-38213-8 | FRAGRANCE-BANANA | 10         |
	And I verify the Transparency Score displays 25.00%
	And In the Ingredients page I confirm the Publicly Disclosed Transparency score is flagged as a danger
	And I call Shared Step 80822 - Ingredients - Add non-generic - specific component - set publicly disclosed and add public name and save ingredient as: Ing808215
		| CASNumber | ComponentName    | Percentage | Publicly Disclosed |
		| FLAVOR    | 611 Grape Flavor | 10         | No                 |
	And I verify the Transparency Score displays 20.00%
	And In the Ingredients page I confirm the Publicly Disclosed Transparency score is flagged as a danger
	And I call Shared Step 80822 - Ingredients - Add non-generic - specific component - set publicly disclosed and add public name and save ingredient as: Ing808216
		| CASNumber | ComponentName                 | Percentage | Publicly Disclosed | Public Name            |
		| NA519     | Black Cherry - Natural Flavor | 10         | Yes                | Undisclosed Ingredient |
	And I verify the Transparency Score displays 33.33%
	And In the Ingredients page I confirm the Publicly Disclosed Transparency score is flagged as a warning
	And I call Shared Step 79436 (Ingredients - Add FRAGRANCE component, Publicly Disclosed = Yes,  Select Public Name) and save ingredient as: Ing808217
		| CASNumber | ComponentName                                                                                                       | Percentage |
		| FRAGRANCE | Fragrance - Birch Branch: Skin Irrit. 2, Eye Irrit. 2A, Skin Sens. 1, Repro Tox 2, Acute Aquatic 2, Chronic Acute 2 | 10         |
	And I verify the Transparency Score displays 28.57%
	And In the Ingredients page I confirm the Publicly Disclosed Transparency score is flagged as a warning
	And I call Shared Step 80822 - Ingredients - Add non-generic - specific component - set publicly disclosed and add public name and save ingredient as: Ing808218
		| CASNumber | ComponentName | Percentage | Publicly Disclosed | Public Name            |
		| 7732-18-5 | Water         | 10         | Yes                | Undisclosed Ingredient |
	And I verify the Transparency Score displays 37.50%
	And In the Ingredients page I confirm the Publicly Disclosed Transparency score is flagged as a warning
	Then in the Ingredients page I click Continue
	#And I call Shared Step 79507 (Formulation > 3rd Party - Accept formulation - Grant Tier 2 - Continue)
	Then I call Shared Step 48948 (Formulation > 3rd Party - Select all)
	And I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	And I call Shared Step 60932 (Regulatory Information 2 - Microbeads - No)
	And I should see the Additional Documents to Provide Page
	And I call Shared Step 59042 (Browse for File > select > click Open - Happy Path) for document type: IFRA Certificate (Perfumery Products) and file: C:\Dependencies\WERCSmart\testdoc.pdf
	And I call Shared Step 59042 (Browse for File > select > click Open - Happy Path) for document type: GRAS Certificate (Flavor Products) and file: C:\Dependencies\WERCSmart\testdoc.pdf
	Then in the Additional Documents to Provide page I click Continue
	Then in the Formulation Names page I click Continue
	And I call Shared Step 58610 (Confirm Restrict Use - Restrict)
	Then in the Sustainability Information page I click Continue
	And I call Shared Step 57883 (Comments - Happy Path) and enter the comment: test
	And I call Shared Step 73956 (Go to Summary and verify data) with product type: Raw material
	Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given If purchase details are showing click confirm order
	And I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase80821)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase80821 and its status is: Submitted
	Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase80821)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase80821)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase80821 and its status is: Assigned
	And I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase80821)
	And I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase80821)
	And In Power Designer I left click on section: [SECT2318] WALMART QC RESPONSE FORM
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


