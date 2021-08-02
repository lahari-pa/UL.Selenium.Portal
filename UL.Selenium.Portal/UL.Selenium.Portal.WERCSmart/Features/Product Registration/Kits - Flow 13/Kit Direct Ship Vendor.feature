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
@PaymentMethods
@SHA
@SummaryPage
@ProductSetUp
@run_KitsFlow13DirectShipVendor
Feature: Kit Direct Ship Vendor

Background:
	Given I verify the following users exist and if not I create them using SHAUser
		| username    | FirstName | LastName   | Role         | EmailAddress                |
		| SHAQAAuto14 | QA        | Automation | QA Reviewers | qasha.kxxyxunf@mailosaur.io |

# Needs two products in completed status with SOLD set to US only. test case #75335
# Waiting for this test to be finished ^^^
# Assigned to Beverly Barrett
# Created by Beverly Barrett
@ScenarioId:6005
Scenario: [77862] Create a Kit - Direct ship = Yes and retailer = Walmart - thru to Submitted status in SHA
	#Given I For this test case you will need two input products in completed status which have SOLD set to US only and make sure to add Walmart as the retailer for these products.  Use the test case 75335 to create these products - test case is linked to this one.Note: these input products do not have to be direct ship vendor products
	#Given I create a Walmart product and take to completed using Test Case 75335 (SOLD set to US only with Walmart as retailer) and save as: 77862_KitProduct1

	Given I create a Walmart product and take to completed using Test Case 75335 using SHA Acc: SHAQAAuto14 (SOLD set to US only with Walmart as retailer) and save as: 77862_KitProduct1
	Given I navigate to the landing page
	#Given I create a Walmart product and take to completed using Test Case 75335 (SOLD set to US only with Walmart as retailer) and save as: 77862_KitProduct2
	Given I create a Walmart product and take to completed using Test Case 75335 using SHA Acc: SHAQAAuto14 (SOLD set to US only with Walmart as retailer) and save as: 77862_KitProduct2

	Given I navigate to the landing page
	Given I generate a random UPC number and save as: UPC77862
	And I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	#And I In the shared step below use any of the kit product types - these areCosmetic Products in a kit (RU000777)Hair Care kit (RU000723)Hair Color Kit (RU000724)Emergency Road kit (RU000718)Automotive Care Products (RU000124)Personal Care kit (RU001034)
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Hair Color Kit
	And I call Shared Step 77872 (Product Information - Kit flow - US only, Direct Ship (yes), Continue)
	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	#And I In the shared step below add the two completed products that you are working with
	And I call Shared Step 31427 (Create the Kit - Adding two products: product 1: 77862_KitProduct1 and product 2: 77862_KitProduct2)
	And I call Shared Step 57506 (Transportation Details 1 - Regulated for Transport(No) - Exemption(Random) - Continue - Happy Path)
	And I call Shared Step 62536 (Transportation Details 2 > I do not ship internationally > Continue - Happy Path)
	And I call Shared Step 77845 (Retailer - Select WM, Done, Select Vendor ID, Continue)
	And I call Shared Step 42759 (Portal - UPC Page - add 1 UPC)
	# And I The Product Comments step is shown - click Continue
	#And I should see the Product Comments Page
	And in the Additional Documents to Provide page I click Continue
	And the comments field should appear
	And I click continue
	And I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	And In the Purchase Summary screen I confirm the Purchase Summary header is displayed
	#And I The Purchase summary step is shown with the success message
	And I navigate to the home page
	And I call Shared Step 65080b (Login to Studio as user saved as: SHAQAAuto14 and Open SHA manager)
	And I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase77862)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase77862 and its status is: Submitted
	And I Confirm the Product ID: TestCase77862 is highlited yellow indicating that this is an e-comm/direct ship product

@ScenarioId:5943
Scenario: [77837] Create a kit - Direct ship = No, Retailer = Walmart - thru to Submitted
	#Given I For this test case you will need two input products in completed status which have SOLD set to US only and make sure to add Walmart as the retailer for these products.  Use the test case 75335 to create these products - test case is linked to this one.Note: these input products do not have to be direct ship vendor products
	#Given I create a Walmart product and take to completed using Test Case 75335 (SOLD set to US only with Walmart as retailer) and save as: 77837_KitProduct1
	Given I create a Walmart product and take to completed using Test Case 75335 using SHA Acc: SHAQAAuto14 (SOLD set to US only with Walmart as retailer) and save as: 77837_KitProduct1

	#Given I create a product and take to completed using Test Case 75335 (SOLD set to US only with Walmart as retailer) and save as: 77837_KitProduct1
	Given I navigate to the landing page
	#Given I create a Walmart product and take to completed using Test Case 75335 (SOLD set to US only with Walmart as retailer) and save as: 77837_KitProduct2
	Given I create a Walmart product and take to completed using Test Case 75335 using SHA Acc: SHAQAAuto14 (SOLD set to US only with Walmart as retailer) and save as: 77837_KitProduct2

	#Given I create a product and take to completed using Test Case 75335 (SOLD set to US only with Walmart as retailer) and save as: 77837_KitProduct2
	Given I navigate to the landing page
	Given I generate a random UPC number and save as: UPC77837
	And I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	#And I In the shared step below use any of the kit product types - these areCosmetic Products in a kit (RU000777)Hair Care kit (RU000723)Hair Color Kit (RU000724)Emergency Road kit (RU000718)Automotive Care Products (RU000124)Personal Care kit (RU001034)
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Hair Color Kit
	Given I call Shared Step 60648 (Product Information - US, No (Direct Ship), No (PL), No (GNFR))
	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	#And I In the shared step below add the two completed products that you are working with
	And I call Shared Step 31427 (Create the Kit - Adding two products: product 1: 77837_KitProduct1 and product 2: 77837_KitProduct2)
	And I call Shared Step 57507 (Transportation Details 1- Not Regulated - Continue - Happy Path)
	And I call Shared Step 77845 (Retailer - Select WM, Done, Select Vendor ID, Continue)
	And I call Shared Step 42759 (Portal - UPC Page - add 1 UPC)
	# And I The Product Comments step is shown - click Continue
	#And I should see the Product Comments Page
	And the comments field should appear
	And I click continue
	And I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	And In the Purchase Summary screen I confirm the Purchase Summary header is displayed
	#And I The Purchase summary step is shown with the success message
	And I navigate to the home page
	And I call Shared Step 65080b (Login to Studio as user saved as: SHAQAAuto14 and Open SHA manager)
	And I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase77837)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase77837 and its status is: Submitted
	And I Confirm the Product ID: saved as TestCase77837 is not highlited yellow indicating that this is not an e-comm/direct ship product

# Assigned to Barrett, Beverly
# Created by Barrett, Beverly
# Test case can be found at the following paths:
# NetProjects10\WercsSmart Portal\WERCSmart\Product Registration\Kits - Flow 13\Kit - Direct Ship Vendor question
@77857
@ScenarioId:10356
Scenario: [77857] Kit recertification - change Direct Ship from Yes to No - WM only
	#Given I save to context name: 77862_KitProduct1 and value: 1549414
	#Given I save to context name: 77862_KitProduct2 and value: 1549415
	#Given I use Test case 77862 to create a kit and save as TestCase77857
	Given I use Test case 77862 to create a kit using SHA Acc: SHAQAAuto14 and save as TestCase77857
	And I call Shared Step 65080b (Login to Studio as user saved as: SHAQAAuto14 and Open SHA manager)
	And I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase77857)
	And I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase77857)
	And I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase77857)
	And In the SHA manager grid I see the WPS ID I have saved as product: TestCase77857 and its status is: Assigned
	And I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase77857)
	And I call Shared Step 20375 - Go to Product Attributes via Authoring Tab in PDP/PAP (Maxed Out)
	And I call Shared Step 78799 - WPS PD+ - Product Attributes - Filter for CNTXT
	And In the Product Attribute Screen I Confirm the screen shows CNTXT present
	And In the Product Attribute Screen I Select the first entry in the table with code: CNTXT
	And I Confirm the Data area of the screen shows WM.com DSV submission
	And I close the current window
	And I call Shared Step 59066 (Go to SHA Manager)
	And I call Shared Step 51349 - SHA Manager > Assigned Product - Add Recert reason 20 for product saved as: TestCase77857
	And In the SHA Manager Grid I run a search for product saved as: TestCase77857 and its status is: Assigned
	And In the SHA manager grid I see the WPS ID I have saved as product: TestCase77857 and its status is: Assigned
	And In the SHA manager grid I see the WPS ID I have saved as product: TestCase77857 and its font is red indicating a recertification
	#Scenario: test
	#Given I save to context name: TestCase77857 and value: 1549382
	#And I call Shared Step 65080b (Login to Studio as user saved as: SHAQAAuto14 and Open SHA manager)
	Given I navigate to the landing page
	And I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	#And I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	And I filter for the product saved as: TestCase77857
	#And I confirm that product saved: TestCase77857 is shown with the retailer icons shown in red indicating a recertification is active
	And For product saved as: TestCase77857 the status is: Needs Your Attention
	And I click Row Actions for the first product returned
	And I click on the Row Action: Update Required
	#And I If you are using  a ULSC registered user you will see the ULSC Service Data Re-Import step, select No, Continue editing data and click Save
	And I should see the The Product Page
	#And I Select the No button for the "Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns." question
	And I click Save in The Product Page
	And In the New Product page I click tab: Review and Submit
	And I click the page heading: Data Acceptance
	And In the Data Acceptance page I click on the Accept button
	And If purchase details are showing click confirm order
	And I call Shared Step 65080b (Login to Studio as user saved as: SHAQAAuto14 and Open SHA manager)
	And I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase77857)
	And I Confirm the Product ID: saved as TestCase77857 is not highlited yellow indicating that this is not an e-comm/direct ship product
	#And I Confirm that your product is shown in the Recertification status with the red font no longer shown
	And In the SHA manager grid I see the WPS ID I have saved as product: TestCase77857 and its status is: Recertification
	And I call Shared Step 44240 - SHA - Recertification > process recertification to Assigned status for product saved as TestCase77857
	And I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase77857)
	And I call Shared Step 20375 - Go to Product Attributes via Authoring Tab in PDP/PAP (Maxed Out)
	And I call Shared Step 78799 - WPS PD+ - Product Attributes - Filter for CNTXT
	And In the Product Attribute Screen confirm that no records are found

# Assigned to Barrett, Beverly
# Created by Barrett, Beverly
# Test case can be found at the following paths:
# NetProjects10\WercsSmart Portal\WERCSmart\Product Registration\Kits - Flow 13\Kit - Direct Ship Vendor question
@77858
@ScenarioId:11183
Scenario: [77858] Kit recertification - Direct Ship - change from No to Yes - WM only
	#Given I save to context name: 77862_KitProduct1 and value: 1552743
	#Given I save to context name: 77862_KitProduct2 and value: 1552746
	#Given I Use Test case 77862 to create a kit which has Direct Ship set to Yes and is for WM only.Test case is linked.  This leaves the kit product in Submitted status in SHA manager
	#Given I use Test case 77862 to create a kit and save as TestCase77858
	Given I use Test case 77862 to create a kit using SHA Acc: SHAQAAuto14 and save as TestCase77858

	And I call Shared Step 65080b (Login to Studio as user saved as: SHAQAAuto14 and Open SHA manager)
	And I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase77858)
	And I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase77858)
	#And I Use the shared step below to search for your product
	And I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase77858)
	And In the SHA manager grid I see the WPS ID I have saved as product: TestCase77858 and its status is: Assigned
	#And I In the shared step below open the PD+ module selecting your product - make sure the MTR/CKLT subformat is selected
	And I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase77858)
	And I call Shared Step 20375 - Go to Product Attributes via Authoring Tab in PDP/PAP (Maxed Out)
	And I call Shared Step 78799 - WPS PD+ - Product Attributes - Filter for CNTXT
	And In the Product Attribute Screen confirm that no records are found
	And I close the current window
	And I call Shared Step 59066 (Go to SHA Manager)
	And I call Shared Step 51349 - SHA Manager > Assigned Product - Add Recert reason 20 for product saved as: TestCase77858
	And I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase77858)
	And In the SHA manager grid I see the WPS ID I have saved as product: TestCase77858 and its status is: Assigned
	And In the SHA manager grid I see the WPS ID I have saved as product: TestCase77858 and its font is red indicating a recertification
	Given I navigate to the landing page
	And I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	And I filter for the product saved as: TestCase77858
	#And I confirm that product saved: TestCase77857 is shown with the retailer icons shown in red indicating a recertification is active
	And For product saved as: TestCase77858 the status is: Needs Your Attention
	And I click Row Actions for the first product returned
	And I click on the Row Action: Update Required
	#And I If you are using  a ULSC registered user you will see the ULSC Service Data Re-Import step, select No, Continue editing data and click Save
	And I should see the The Product Page
	And I click Save in The Product Page
	#And I Select the No button for the "Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns." question
	And I click Save in The Product Page
	And In the New Product page I click tab: Review and Submit
	And I click the page heading: Data Acceptance
	And In the Data Acceptance page I click on the Accept button
	And If purchase details are showing click confirm order
	And I call Shared Step 65080b (Login to Studio as user saved as: SHAQAAuto14 and Open SHA manager)
	And I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase77858)
	And I Confirm the Product ID: saved as TestCase77858 is not highlited yellow indicating that this is not an e-comm/direct ship product
	#And I Confirm that your product is shown in the Recertification status with the red font no longer shown
	And In the SHA manager grid I see the WPS ID I have saved as product: TestCase77858 and its status is: Recertification
	And I call Shared Step 44240 - SHA - Recertification > process recertification to Assigned status for product saved as TestCase77858
	And I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase77858)
	And I call Shared Step 20375 - Go to Product Attributes via Authoring Tab in PDP/PAP (Maxed Out)
	And I call Shared Step 78799 - WPS PD+ - Product Attributes - Filter for CNTXT
	And In the Product Attribute Screen confirm that no records are found
	And In the Product Attribute Screen I Confirm the screen shows CNTXT present
	And In the Product Attribute Screen I Select the first entry in the table with code: CNTXT
	And I Confirm the Data area of the screen shows WM.com DSV submission
