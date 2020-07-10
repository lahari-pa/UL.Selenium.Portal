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
@run_KitsFlow13DocumentMerge
Feature: Kit Document Merge

@73949
@ScenarioId:1510
Scenario: [73949] Kit - Document merge - US only
	Given I create a Walmart product and take to completed using Test Case 75335 (SOLD set to US only with Walmart as retailer) and save as: 73949_KitProduct1
	Given I navigate to the landing page
	Given I create a Walmart product and take to completed using Test Case 75335 (SOLD set to US only with Walmart as retailer) and save as: 73949_KitProduct2
	Given I navigate to the landing page
	#Given I save product 1520182 to context as 73949_KitProduct1
	#Given I save product 1520183 to context as 73949_KitProduct2
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
	Then I should see a new tabbed document with the pdf containing product code saved as: TestCase73949 and NGHS / English twice
	Then I should see a new tabbed document whose URL contains DocumentID
	Then I Delete the file with name: TempPDF.pdf from the downloads folder

#And I close the window that opened
#And I Click Cancel on the Document List window pop up
# Assigned to Barrett, Beverly
# Created by Barrett, Beverly
# Test case can be found at the following paths:
# NetProjects10\WercsSmart Portal\WERCSmart\Product Registration\Kits - Flow 13\Kit - Document merge
@73950
@ScenarioId:5946
Scenario: [73950] Kit Document merge - Canada only
	#Given I Use Test case 78865 to create a new product which is for NR and Canada only, and get it to completed status.  You will need to run this twice as you need two products to add to the kit.
	Given I create a product with name: Kit product 1 and take to completed using Test Case 78865 and save as: 73950_KitProduct1
	Given I navigate to the landing page
	Given I create a product with name: Kit product 2 and take to completed using Test Case 78865 and save as: 73950_KitProduct2
	Given I navigate to the landing page
	Given I generate a random UPC number and save as: UPC73949
	Given I login into the WERCSmart Portal - Canada has all data account
	And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	#And I In the shared step below use any of the kit product types - these areCosmetic Products in a kit (RU000777)Hair Care kit (RU000723)Hair Color Kit (RU000724)Emergency Road kit (RU000718)Automotive Care Products (RU000124)Personal Care kit (RU001034)
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Hair Color Kit
	Then I save the product information as: TestCase73950
	And I call Shared Step 62681 - Additional Product Information - Canada, No(DSV), No(PLP), No(GNFR), Continue - Happy Path
	And I call Shared Step 57911 (Regulatory Information 1 - CEPA only shown - Continue - Happy Path)
	And I call Shared Step 31427 (Create the Kit - Adding two products: product 1: 73950_KitProduct1 and product 2: 73950_KitProduct2)
	And I call Shared Step 57506 (Transportation Details 1 - Regulated for Transport(No) - Exemption(Random) - Continue - Happy Path)
	And I call Shared Step 62536 (Transportation Details 2 > I do not ship internationally > Continue - Happy Path)
	And I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	And I should see the Additional Documents to Provide Page
	And I click continue
	And I call Shared Step 57883 (Comments - Happy Path) and enter the comment: yrdy
	And I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	And If purchase details are showing click confirm order
	And I call Shared Step 65080 (Login to Studio and Open SHA manager)
	And I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase73950)
	And In the SHA manager grid I see the WPS ID I have saved as product: TestCase73950 and its status is: Submitted
	And I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase73950)
	And I call Shared Step 65080 (Login to Studio and Open SHA manager)
	And I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase73950)
	And In the SHA manager grid I see the WPS ID I have saved as product: TestCase73950 and its status is: Assigned
	And I call Shared Step 49743 - SHA Manager - Select Product - Actions - Document Management for saved as: TestCase73950
	And I Confirm you see the Document List pop up
	And In the Document List popup I Confirm the Filename column shows an entry for xxxxxxx.pdf - where xxxxxxx is the product id of product saved as: TestCase73950
	And In the Document List popup I Double click on the filename for product saved as: TestCase73950
	#CLF 21/03/2019 Commenting out below because I cannot get the pdf document
	# And I Scroll thru the PDF document and confirm you see HGHS documents in EN and HGHS documents in CF for both the input products (4 documents in all will be merged into the one PDF)Note: each document in the PDF will show Canada / English or Canada/Francais and the Product Code(s) will show the product ID for the input product
	And I Click Cancel on the Document List window pop up
