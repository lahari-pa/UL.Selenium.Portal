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
@run_ProductSetUpKit

Feature: ProductSetUp_Kit

@TReVorId:21325
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
