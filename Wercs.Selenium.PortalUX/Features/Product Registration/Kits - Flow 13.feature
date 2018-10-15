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
@run_KitsFlow13

Feature: Kits - Flow 13

# Needs two products in completed status with SOLD set to US only. test case #75335
# Waiting for this test to be finished ^^^


# Assigned to Beverly Barrett
# Created by Beverly Barrett

Scenario: [77862] Create a Kit - Direct ship = Yes and retailer = Walmart - thru to Submitted status in SHA
#Given I For this test case you will need two input products in completed status which have SOLD set to US only and make sure to add Walmart as the retailer for these products.  Use the test case 75335 to create these products - test case is linked to this one.Note: these input products do not have to be direct ship vendor products
Given I create a product and take to completed using Test Case 75335 (SOLD set to US only with Walmart as retailer) and save as: 77862_KitProduct1
Given I navigate to the landing page
Given I create a product and take to completed using Test Case 75335 (SOLD set to US only with Walmart as retailer) and save as: 77862_KitProduct2
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
Given I create a product and take to completed using Test Case 75335 (SOLD set to US only with Walmart as retailer) and save as: 77837_KitProduct1
Given I navigate to the landing page
Given I create a product and take to completed using Test Case 75335 (SOLD set to US only with Walmart as retailer) and save as: 77837_KitProduct2
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
