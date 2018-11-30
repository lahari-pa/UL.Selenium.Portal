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

# NEEDS WORK - call create product to completed steps (one is regulated for transport, one is not regulated for transport)
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

Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Hair Care kit
Then I save the product information as: TestCase63521
Given I call Shared Step 63460 (Additional Product Information - SOLD = US, No(PL), No(GNFR) only shown (mainly kits) Happy Path)
Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
And I should see the Create the Kit Page
Given In the Create the kit page I search for and select: saved as Kit1
Given In the Create the kit page I search for and select: 1
Then in the Create the Kit page I click Continue
And I should see the Transportation Details 1 Page
Then in the Transport Details 1 page I should see the Product is Regulated for Transport question
Then The following radio buttons should be displayed for section: Product is Regulated for Transport
| Button                  |
| Yes                     |
| No, due to an exemption |
#Then in the Transport Details 1 page I should not see the Not regulated option
# Below is equvilent because Not Regulated is not displayed if the last step passes and the count is = 2
And I should see a total of 2 radio buttons for the section: Product is Regulated for Transport
Then in the Transportation Details 1 page I click Continue
Then I should see an error message: This is a required field
Given I set the Product is Regulated for Transport field to: No, due to an exemption
Then I should not see an error message: This is a required field
