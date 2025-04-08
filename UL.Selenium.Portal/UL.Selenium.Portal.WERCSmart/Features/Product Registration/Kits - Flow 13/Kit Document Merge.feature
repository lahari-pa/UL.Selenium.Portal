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
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:OptionalComments
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:DataAcceptance

Feature: Kit Document Merge


Background:
	Given I verify the following users exist and if not I create them using SHAUser
		| username    | FirstName | LastName   | Role         | EmailAddress                |
        | SHAQAAuto9  | QA        | Automation | QA Reviewers | qasha.kxxyxunf@mailosaur.io |

#And I close the window that opened
#And I Click Cancel on the Document List window pop up
# Assigned to Barrett, Beverly
# Created by Barrett, Beverly
# Test case can be found at the following paths:
# NetProjects10\WercsSmart Portal\WERCSmart\Product Registration\Kits - Flow 13\Kit - Document merge
@73950
@ignore
@TestCase:73950
Scenario: [73950] Kit Document merge - Canada only
	
	Given I create a product for a Kit with name: Kit product 1 and Force it to completed using Test Case 78865 Using SHA Acc: SHAQAAuto15 and save as: 73950_KitProduct1
	Given I navigate to the landing page	
	Given I create a product for a Kit with name: Kit product 2 and Force it to completed using Test Case 78865 Using SHA Acc: SHAQAAuto15 and save as: 73950_KitProduct2
	Given I navigate to the landing page
	Given I generate a random UPC number and save as: UPC73949
	Given I login into the WERCSmart Portal - Canada has all data account
	And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	#And I In the shared step below use any of the kit product types - these areCosmetic Products in a kit (RU000777)Hair Care kit (RU000723)Hair Color Kit (RU000724)Emergency Road kit (RU000718)Automotive Care Products (RU000124)Personal Care kit (RU001034)
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Hair Color Kit
	Then I save the product information as: TestCase73950
	And I call Shared Step 62681 - Product Information - Canada, No(DSV), No(PLP), No(GNFR), Continue - Happy Path
	And I call Shared Step 57911 (Regulatory Information 1 - CEPA only shown - Continue - Happy Path)
	And I call Shared Step 31427 (Create the Kit - Adding two products: product 1: 73950_KitProduct1 and product 2: 73950_KitProduct2)
	And I call Shared Step 57506 (Transportation Details 1 - Regulated for Transport(No) - Exemption(Random) - Continue - Happy Path)
	And I call Shared Step 62536 (Transportation Details 2 > I do not ship internationally > Continue - Happy Path)
	And I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	And I should see the Additional Documents to Provide Page
	And I click continue
	#And I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: yrdy
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	#And I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given I should see the Data Acceptance Page
	Then In the Data Acceptance Section, check 'Agreed' checkbox
	Then In the Data Acceptance Section, click 'Accept' button

	And If purchase details are showing click confirm order
	And I call Shared Step 65080b (Login to Studio as user saved as: SHAQAAuto15 and Open SHA manager)
	And I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase73950)
	And In the SHA manager grid I see the WPS ID I have saved as product: TestCase73950 and its status is: Submitted
	And I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase73950)
	And I call Shared Step 65080b (Login to Studio as user saved as: SHAQAAuto15 and Open SHA manager)
	And I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase73950)
	And In the SHA manager grid I see the WPS ID I have saved as product: TestCase73950 and its status is: Assigned
	And I call Shared Step 49743 - SHA Manager - Select Product - Actions - Document Management for saved as: TestCase73950
	And I Confirm you see the Document List pop up
	And In the Document List popup I Confirm the Filename column shows an entry for xxxxxxx.pdf - where xxxxxxx is the product id of product saved as: TestCase73950
	And In the Document List popup I Double click on the filename for product saved as: TestCase73950





	#CLF 21/03/2019 Commenting out below because I cannot get the pdf document
	# And I Scroll thru the PDF document and confirm you see HGHS documents in EN and HGHS documents in CF for both the input products (4 documents in all will be merged into the one PDF)Note: each document in the PDF will show Canada / English or Canada/Francais and the Product Code(s) will show the product ID for the input product
	And I Click Cancel on the Document List window pop up
