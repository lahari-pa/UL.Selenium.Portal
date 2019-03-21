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
@run_KitsFlow13

Feature: Kits - Flow 13

# Needs two products in completed status with SOLD set to US only. test case #75335
# Waiting for this test to be finished ^^^


# Assigned to Beverly Barrett
# Created by Beverly Barrett

Scenario: [77862] Create a Kit - Direct ship = Yes and retailer = Walmart - thru to Submitted status in SHA
#Given I For this test case you will need two input products in completed status which have SOLD set to US only and make sure to add Walmart as the retailer for these products.  Use the test case 75335 to create these products - test case is linked to this one.Note: these input products do not have to be direct ship vendor products
Given I create a Walmart product and take to completed using Test Case 75335 (SOLD set to US only with Walmart as retailer) and save as: 77862_KitProduct1
Given I navigate to the landing page
Given I create a Walmart product and take to completed using Test Case 75335 (SOLD set to US only with Walmart as retailer) and save as: 77862_KitProduct2
Given I navigate to the landing page
Given I generate a random UPC number and save as: UPC77862
And I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
#And I In the shared step below use any of the kit product types - these areCosmetic Products in a kit (RU000777)Hair Care kit (RU000723)Hair Color Kit (RU000724)Emergency Road kit (RU000718)Automotive Care Products (RU000124)Personal Care kit (RU001034)
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Hair Color Kit
And I call Shared Step 77872 (Additional Product Information - Kit flow - US only, Direct Ship (yes), Continue)
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
#And I In the shared step below add the two completed products that you are working with
And I call Shared Step 31427 (Create the Kit - Adding two products: product 1: 77862_KitProduct1 and product 2: 77862_KitProduct2)
And I call Shared Step 57506 (Transportation Details 1 - Regulated for Transport(No) - Exemption(Random) - Continue - Happy Path)
And I call Shared Step 62536 (Transportation Details 2 > I do not ship internationally > Continue - Happy Path)
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
And I call Shared Step 65080 (Login to Studio and Open SHA manager)
And I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase77862)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase77862 and its status is: Submitted
And I Confirm the Product ID: TestCase77862 is highlited yellow indicating that this is an e-comm/direct ship product

Scenario: [77837] Create a kit - Direct ship = No, Retailer = Walmart - thru to Submitted
#Given I For this test case you will need two input products in completed status which have SOLD set to US only and make sure to add Walmart as the retailer for these products.  Use the test case 75335 to create these products - test case is linked to this one.Note: these input products do not have to be direct ship vendor products
Given I create a Walmart product and take to completed using Test Case 75335 (SOLD set to US only with Walmart as retailer) and save as: 77837_KitProduct1
#Given I create a product and take to completed using Test Case 75335 (SOLD set to US only with Walmart as retailer) and save as: 77837_KitProduct1
Given I navigate to the landing page
Given I create a Walmart product and take to completed using Test Case 75335 (SOLD set to US only with Walmart as retailer) and save as: 77837_KitProduct2
#Given I create a product and take to completed using Test Case 75335 (SOLD set to US only with Walmart as retailer) and save as: 77837_KitProduct2
Given I navigate to the landing page
Given I generate a random UPC number and save as: UPC77837
And I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
#And I In the shared step below use any of the kit product types - these areCosmetic Products in a kit (RU000777)Hair Care kit (RU000723)Hair Color Kit (RU000724)Emergency Road kit (RU000718)Automotive Care Products (RU000124)Personal Care kit (RU001034)
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Hair Color Kit
And I call Shared Step 77883 (Additional Product Information - Kit flow - US only, Direct Ship (No), Continue)
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
And I call Shared Step 65080 (Login to Studio and Open SHA manager)
And I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase77837)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase77837 and its status is: Submitted
And I Confirm the Product ID: TestCase77837 is not highlited yellow indicating that this is not an e-comm/direct ship product

Scenario: [58753] Hair Color Kit - RU000724
Given I create a product and take to completed using Test Case 75335 and save as: 58753_KitProduct1
Given I navigate to the landing page
Given I create a product and take to completed using Test Case 75335 and save as: 58753_KitProduct2
Given I navigate to the landing page
Given I generate a random UPC number and save as: UPC58753
And I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
#And I In the shared step below use any of the kit product types - these areCosmetic Products in a kit (RU000777)Hair Care kit (RU000723)Hair Color Kit (RU000724)Emergency Road kit (RU000718)Automotive Care Products (RU000124)Personal Care kit (RU001034)
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Hair Color Kit
And I call Shared Step 60648 (Additional Product Information - US, No (Direct Ship), No (PL), No (GNFR))
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
And I call Shared Step 31427 (Create the Kit - Adding two products: product 1: 58753_KitProduct1 and product 2: 58753_KitProduct2)
And I call Shared Step 57506 (Transportation Details 1 - Regulated for Transport(No) - Exemption(Random) - Continue - Happy Path)
And I call Shared Step 62536 (Transportation Details 2 > I do not ship internationally > Continue - Happy Path)
And I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: CVS
And I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC58753, container type: Plastic Container and size: 100
And I should see the Additional Documents to Provide Page
And I click continue
And I call Shared Step 57883 (Comments - Happy Path) and enter the comment: Test Comment Kit 58753
And I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
#And I The Purchase summary step is shown with the success message

#Call create product to completed steps (one is regulated for transport, one is not regulated for transport)
Scenario: [63521] Kit Product - One or more inputs is regulated for transport - Transportation step does NOT shows Not regulated option
Given I login into the WERCSmart Portal - Administrator Role
Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Bleach
Then I save the product information as: Kit1
Given I call Shared Step 74339 (Product Characteristics - Select Liquid and enter only Secondary state, Specific gravity, pH)
Given I set the Boiling Point (in Celsius) field to: 86
Given I set the Flash Point (in Celsius) field to: 92
Given I set the Flash Point Testing Method Used field to: Closed cup
Given I set the Select the best Water Solubility description field to: Decomposes
Then in the Product Characteristics page I click Continue
Given I call Shared Step 74340 (Additional Product Information - Pesticide= Not considered, SOLD=US, everything else = No - Continue)
Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Ketone
Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
And I should see the Transportation Details 1 Page
Given I set the Product is Regulated for Transport field to: Yes
Given I set the Select all modes of transport field to: DOT
Given I set the Select all modes of transport field to: Shipping fully regulated
Then in the Transport Details 1 page I click Continue
And I should see the U. S. Department of Transportation (DOT) Classification Page
Given I set the UN Number field to: UN1950
Given I set the Proper Shipping Name field to: Aerosols
Given I set the Hazard Class field to: 2.1
Given I set the Packing Group field to: None
Then in the U. S. Department of Transportation (DOT) Classification page I click Continue
Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
Then I should see the Additional Documents to Provide Page
Then in the Additional Documents to Provide page I click Continue
Then I should see the Optional Reports and Documents Available for Purchase Page
Then in the Optional Reports and Documents Available for Purchase page I click Continue
Given I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: User added Comments Text 57863. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Bleach

Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Bleach
Then I save the product information as: Kit2
Given I call Shared Step 74339 (Product Characteristics - Select Liquid and enter only Secondary state, Specific gravity, pH)
Given I set the Boiling Point (in Celsius) field to: 86
Given I set the Flash Point (in Celsius) field to: 92
Given I set the Flash Point Testing Method Used field to: Closed cup
Given I set the Select the best Water Solubility description field to: Decomposes
Then in the Product Characteristics page I click Continue
Given I call Shared Step 74340 (Additional Product Information - Pesticide= Not considered, SOLD=US, everything else = No - Continue)
Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Ketone
Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
And I should see the Transportation Details 1 Page
Given I set the Product is Regulated for Transport field to: Yes
Given I set the Select all modes of transport field to: DOT
Given I set the Select all modes of transport field to: Shipping fully regulated
Then in the Transport Details 1 page I click Continue
And I should see the U. S. Department of Transportation (DOT) Classification Page
Given I set the UN Number field to: UN1950
Given I set the Proper Shipping Name field to: Aerosols
Given I set the Hazard Class field to: 2.1
Given I set the Packing Group field to: None
Then in the U. S. Department of Transportation (DOT) Classification page I click Continue
Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
Then I should see the Additional Documents to Provide Page
Then in the Additional Documents to Provide page I click Continue
Then I should see the Optional Reports and Documents Available for Purchase Page
Then in the Optional Reports and Documents Available for Purchase page I click Continue
Given I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: User added Comments Text 57863. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Bleach

#The previous steps just create the kit items
#Scenario: Test
#Given I login into the WERCSmart Portal - Administrator Role
#Given I save to context name: Kit1 and value: 1502868
#Given I save to context name: Kit2 and value: 1502793
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Hair Care kit
Then I save the product information as: TestCase63521
Given I call Shared Step 63460 (Additional Product Information - SOLD = US, No(PL), No(GNFR) only shown (mainly kits) Happy Path)
Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
And I should see the Create the Kit Page
Given In the Create the kit page I search for and select: saved as Kit1
Given In the Create the kit page I search for and select: saved as Kit2
Then in the Create the Kit page I click Continue
And I should see the Transportation Details 1 Page
Then in the Transportation Details 1 page I should see the Product is Regulated for Transport question
Then The following radio buttons should be displayed for section: Product is Regulated for Transport
| Button                               |
| Yes                                  |
| No, due to an exemption or exception |
#Then in the Transport Details 1 page I should not see the Not regulated option
Then The following radio buttons should not be displayed for section: Product is Regulated for Transport
| Button        |
| Not Regulated |
# Below is equvilent because Not Regulated is not displayed if the last step passes and the count is = 2
And I should see a total of 2 radio buttons for the section: Product is Regulated for Transport
Then in the Transportation Details 1 page I click Continue
Then I should see an error message: This is a required field.
Given I set the Product is Regulated for Transport field to: No, due to an exemption or exception
Then I should not see an error message: This is a required field.
Given I set the Please select DOT Exceptions if applicable? field to: 173.159 (a) – Exemption for non-spillable lead-acid batteries
Then in the Transportation Details 1 page I click Continue
And I call Shared Step 62536 (Transportation Details 2 > I do not ship internationally > Continue - Happy Path)
And I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
And I should see the Additional Documents to Provide Page
Then in the Additional Documents to Provide page I click Continue
And I call Shared Step 57883 (Comments - Happy Path) and enter the comment: test
And I should see the Data Acceptance Page
And I click the Summary button in the Data Acceptance window
And I switch to the Data Summary page
And In the Data Summary page I confirm that the following items are included in the kit:
| Kit items     |
| saved as Kit1 |
| saved as Kit2 |
And In the Data Summary page I confirm the following questions and answers
| Question                           | Answer        | True or False |
| Product is Regulated for Transport | Not Regulated | False         |
And In the Data Summary page I confirm that I do not see any errors
And I close the Data Summary tab
And I navigate to the home page
And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase63521

# Assigned to Barrett, Beverly
# Created by Barrett, Beverly

# Test case can be found at the following paths:
# NetProjects10\WercsSmart Portal\WERCSmart\Product Registration\Kits - Flow 13\Kit - Direct Ship Vendor question

@77857
Scenario: [77857] Kit recertification - change Direct Ship from Yes to No - WM only
#Given I save to context name: 77862_KitProduct1 and value: 1549414
#Given I save to context name: 77862_KitProduct2 and value: 1549415
Given I use Test case 77862 to create a kit and save as TestCase77857
And I call Shared Step 65080 (Login to Studio and Open SHA manager)
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
#And I call Shared Step 65080 (Login to Studio and Open SHA manager)
Given I navigate to the landing page

And I call Shared Step 68210 (Login to WERCSmart - Premium Account)
#And I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
And I filter for the product saved as: TestCase77857
#And I confirm that product saved: TestCase77857 is shown with the retailer icons shown in red indicating a recertification is active
And For product saved as: TestCase77857 the status is: Needs Your Attention
And I click Row Actions for the first product returned
And I click on the Row Action: Update Required
#And I If you are using  a ULSC registered user you will see the ULSC Service Data Re-Import step, select No, Continue editing data and click Save
And I should see the The Product Page
#And I The Additional Product Information step is shown - confirm the Yes button is shown as selected for the Direct ship question
#And I Select the No button for the "Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns." question
And I click Save in The Product Page
And In the New Product page I click tab: Review and Submit
And in the New Product page I click section: Data Acceptance
And In the Data Acceptance page I click on the Accept button
And If purchase details are showing click confirm order
And I call Shared Step 65080 (Login to Studio and Open SHA manager)
And I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase77857)
And I Confirm the Product ID: saved as TestCase77857 is not highlited yellow indicating that this is not an e-comm/direct ship product
#And I Confirm that your product is shown in the Recertification status with the red font no longer shown
And In the SHA manager grid I see the WPS ID I have saved as product: TestCase77857 and its status is: Recertification
And I call Shared Step 44240 - SHA - Recertification > process recertification to Assigned status for product saved as TestCase77857
And I call Shared Step 20375 - Go to Product Attributes via Authoring Tab in PDP/PAP (Maxed Out)
And I call Shared Step 78799 - WPS PD+ - Product Attributes - Filter for CNTXT
And In the Product Attribute Screen confirm that no records are found


# Assigned to Barrett, Beverly
# Created by Barrett, Beverly
# Test case can be found at the following paths:
# NetProjects10\WercsSmart Portal\WERCSmart\Product Registration\Kits - Flow 13\Kit - Direct Ship Vendor question
@77858
Scenario: [77858] Kit recertification - Direct Ship - change from No to Yes - WM only
#Given I save to context name: 77862_KitProduct1 and value: 1552743
#Given I save to context name: 77862_KitProduct2 and value: 1552746
#Given I Use Test case 77862 to create a kit which has Direct Ship set to Yes and is for WM only.Test case is linked.  This leaves the kit product in Submitted status in SHA manager
Given I use Test case 77862 to create a kit and save as TestCase77858
And I call Shared Step 65080 (Login to Studio and Open SHA manager)
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
#And I The Additional Product Information step is shown - confirm the Yes button is shown as selected for the Direct ship question
#And I Select the No button for the "Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns." question
And I click Save in The Product Page
And In the New Product page I click tab: Review and Submit
And in the New Product page I click section: Data Acceptance
And In the Data Acceptance page I click on the Accept button
And If purchase details are showing click confirm order
And I call Shared Step 65080 (Login to Studio and Open SHA manager)
And I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase77858)
And I Confirm the Product ID: saved as TestCase77858 is not highlited yellow indicating that this is not an e-comm/direct ship product
#And I Confirm that your product is shown in the Recertification status with the red font no longer shown
And In the SHA manager grid I see the WPS ID I have saved as product: TestCase77858 and its status is: Recertification
And I call Shared Step 44240 - SHA - Recertification > process recertification to Assigned status for product saved as TestCase77858
And I call Shared Step 20375 - Go to Product Attributes via Authoring Tab in PDP/PAP (Maxed Out)
And I call Shared Step 78799 - WPS PD+ - Product Attributes - Filter for CNTXT
And In the Product Attribute Screen confirm that no records are found
And In the Product Attribute Screen I Confirm the screen shows CNTXT present
And In the Product Attribute Screen I Select the first entry in the table with code: CNTXT
And I Confirm the Data area of the screen shows WM.com DSV submission

@73949
Scenario: [73949] Kit - Document merge - US only
Given I create a Walmart product and take to completed using Test Case 75335 (SOLD set to US only with Walmart as retailer) and save as: 73949_KitProduct1
Given I navigate to the landing page
Given I create a Walmart product and take to completed using Test Case 75335 (SOLD set to US only with Walmart as retailer) and save as: 73949_KitProduct2
Given I navigate to the landing page
Given I generate a random UPC number and save as: UPC73949
And I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
#And I In the shared step below use any of the kit product types - these areCosmetic Products in a kit (RU000777)Hair Care kit (RU000723)Hair Color Kit (RU000724)Emergency Road kit (RU000718)Automotive Care Products (RU000124)Personal Care kit (RU001034)
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Hair Color Kit
Then I save the product information as: TestCase73949
And I call Shared Step 60648 (Additional Product Information - US, No (Direct Ship), No (PL), No (GNFR))
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
And I call Shared Step 31427 (Create the Kit - Adding two products: product 1: 73949_KitProduct1 and product 2: 73949_KitProduct2)
And I call Shared Step 57506 (Transportation Details 1 - Regulated for Transport(No) - Exemption(Random) - Continue - Happy Path)
And I call Shared Step 62536 (Transportation Details 2 > I do not ship internationally > Continue - Happy Path)
And I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
And I should see the Additional Documents to Provide Page
And I click continue
And I call Shared Step 57883 (Comments - Happy Path) and enter the comment: test
And I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
And If purchase details are showing click confirm order
And I call Shared Step 65080 (Login to Studio and Open SHA manager)
And I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase73949)
And In the SHA manager grid I see the WPS ID I have saved as product: TestCase73949 and its status is: Submitted
And I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase73949)
And I call Shared Step 65080 (Login to Studio and Open SHA manager)
And I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase73949)
And In the SHA manager grid I see the WPS ID I have saved as product: TestCase73949 and its status is: Assigned
And I call Shared Step 49743 - SHA Manager - Select Product - Actions - Document Management for saved as: TestCase73949
And I Confirm you see the Document List pop up
And In the Document List popup I Confirm the Filename column shows an entry for xxxxxxx.pdf - where xxxxxxx is the product id of product saved as: TestCase73949
And In the Document List popup I Double click on the filename for product saved as: TestCase73949
# And confirm you see NGHS documents in EN for both the input productsNote:
# each document in the PDF will show NGHS / English and the Product Code(s) will show the product ID for the input product

#CLF 21/03/2019 Commenting out below because I cannot get the pdf document
#Then I should see a new tabbed document with the pdf containing product code saved as: TestCase73949 and NGHS / English twice
And I close the window that opened
And I Click Cancel on the Document List window pop up
