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
@SummaryPage
@PaymentMethods
@SubEnrollment
@WERCSmart_Signup
@MyAccount
@PackagingTypes
@Brands
@MyIngredients
@UPC
@SHA
@ProductSetUp
@ForwardProductRegistration
@run_DuplicateUPC
Feature: Duplicate UPC

# Assigned to Abbie Zullo
# Created by Abbie Zullo
# Test case can be found at the following paths:
# NetProjects10\WercsSmart Portal\WERCSmart\Product Registration\UPC
@TReVorId:23404
Scenario: [91076] Duplicate UPC is not permitted within account - New Product registration - single UPC
	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
	Then I save the product information as: TestCase91076
	And I call Shared Step 26897 (Product Characteristics - Solid only available - continue)
	And I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	And I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	And I call Shared Step 75146 (Retailer - Select One or More Retailers that DO NOT REQUIRE Vendor ID or Additional UPC Information, Click Done, Click Continue)
	And I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I click the following option in the bottom menu: Search
	Given I save the username for TReVor test user: ProductAccount to context as: AccountUsername
	Given In SHA Manager ProductSearch page I run search:
		| Search Term | Search Value                  |
		| Status      | Completed                     |
		| Supplier    | QA_Automation_ProductsAccount |
		| User        | saved as AccountUsername      |
	Given I find a UPC number for any product in the grid and save to context as: ExistingUPC
	Given I navigate to the landing page
	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	Given I search for the product saved as: TestCase91076
	Given I edit the first product in results
	Then in the UPC Window, I should see the Universal Product Code (UPC) Page
	Given I click the 'Add UPC' button
	Given I add the following into the UPC Fields
		| UPC Number           | Container Type    | Size | DPCI | Quantity |
		| saved as ExistingUPC | Plastic Container | 1    |      |          |
	Given I click 'Select all' under Destination Retailers in the UPC page
	Given I click continue
	And I should see a list style form error with text: There are UPCs that already exists within the WERCSmart database. Please review the UPCs associated within your account, or request to forward a manufacturer's UPCs by creating a new registration as a request from a Distributor. For UPCs that exist within your WERCSmart account, you may use the Report feature to generate a report for your review. UPCs:
	And I navigate to the home page
	And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase91076

@TReVorId:23403
Scenario: [82536] Mass Upload UPCs, Checking for Duplicate UPCs
	Given I generate a random UPC number and save as: UPC_A
	Given I generate a random UPC number and save as: UPC_B
	Given I generate a random UPC number and save as: UPC_C
	Given I generate a random UPC number and save as: UPC_D
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	And I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Soap (Bar, Liquid) for Body
	And I click continue
	And I call Shared Step 57501 (Product Characteristics - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue - HP)
	And I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	And I call Shared Step 29181 (Ingredients - add any chemical) with name: soap
	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	And I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
	And I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Amazon
	And I click continue
	And I click Sample File link and verify the Upload UPC form and save it as test82536 with data:
		| UPC          | Quantity | Size | Net Explosive Mass | US: Part Number | US: Item Number | GP: Part Number | SP: Part Number | TG: DPCI    | HD: OMSID | CT: Item Number   |
		| 823973000000 | 1        | 11   | 1.22               | 11AB45          | 1001            | 1111            | A0001           | 111-22-0001 | 100000001 | 123-1234,123-1230 |
		| 71617198008  | 2        | 22   | 2.33               | 12AB56          | 1002            | 2222            | B0002           | 111-22-0002 | 100000002 | 123-1234,123-1231 |
		| 978959000000 | 3        | 33   | 3.44               | 12AC67          | 1003            | 3333            | C0003           | 111-22-0003 | 100000003 | 123-1234,123-1232 |
		| 688267000000 | 4        | 44   | 4.55               | 12AD89          | 1004            | 4444            | D0004           | 111-22-0004 | 100000004 | 123-1234,123-1233 |
		| 854911000000 | 5        | 55   | 5.66               | 12AF00          | 1005            | 5555            | E0005           | 111-22-0005 | 100000005 | 123-1234,123-1234 |
	And I create a new file saved as: UploadFile to upload using the UPCs saved as:
		| UPC   | Quantity | Size | Net Explosive Mass | US: Part Number | US: Item Number | GP: Part Number | SP: Part Number | TG: DPCI    | HD: OMSID | CT: Item Number   |
		| UPC_A | 11       | 1    | 6.6                | 00AA01          | 2001            | 1234            | F0001           | 123-45-6789 | 500000009 | 223-1234,123-1230 |
		| UPC_B | 31       | 2    | 7.94               | 00BB02          | 2002            | 2345            | G0002           | 234-56-7890 | 400000008 | 223-1234,123-1231 |
		| UPC_C | 61       | 3    | 8.2                | 00CC03          | 2003            | 3456            | H0003           | 345-67-8901 | 300000007 | 223-1234,123-1232 |
		| UPC_D | 91       | 4    | 9.06               | 00DD04          | 2004            | 5678            | I0004           | 456-78-9012 | 200000006 | 223-1234,123-1233 |
	#And I Create your own document with UPCs, use the following site to get UPCs https://www.upcdatabase.com/click on the Random Item link and copy and p123-1234,123-1234aste the UPCs that appear on the textbox
	And I In the UPC document add some duplicate UPCs, save the document
	And I Click on the Upload UPCs button
	And I Search for the document that contains the UPCs you will upload, click Open button
	And I Confirm that the Add Multiple window openswith the UPCs that were added in the document
	And I Confirm that the size is also the same as from what is in the UPC document
	And I Select the checkbox that next to the UPC tilte
	And I From the Packaging type dropdown select one of the options
	And I Click Next button
	And I Select the checkbox for the retailer
	And I Click on the name of the Retailer
	And I Click on the name of the Retailer again
	And I Click the Finish button
	And I Click the continue button
	And I Confirm that you get a message, There are UPCs that already exist within the WERCSmart database.  Please review the UPCs associated within yout account, or request to forward a manufacturer's UPC by creating a new registration as a request from a Distrubutor. For UPCs that exist within your WERCSmart account, you may use the Report feature to generate a report for your review.  UPCs: xxxxxxxxxxxxxWhere xxxxxxxxxxxxx is the UPC that is duplicatedIf more than one UPC is a duplicate they be shown
	And I Confirm the UPC rows that are duplicates show the red warning triangle next to the Retailer code
	And I Select the UPC(s) that are shown as duplicates by checking the box next to the UPC row in the table
	And I Click the Delete Rows button
	And I Click OK
	And I Confirm the UPC(s) you selected for deletion are no longer shown in the UPC table
	And I Click the Continue button
	And I Confirm you are allowed to go on to next screen without errors
	And I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase82536

@TReVorId:23398
Scenario: [91801] Duplicate UPC is not permitted within WERCSmart system - Forward Product registration - Case UPC
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I create a product with name: Chalk1 and UPC: UPC91801_1 and take to completed using Test Case 75335 with no login step and save as: TestCase91801_Product1
	Given I navigate to the landing page
	Given I Login into WERCSmart Portal - Admin Role - WERCs Premium Subscription Account
	Given I create a product with name: Chalk2 and UPC: UPC91801_2 and take to completed using Test Case 75335 with no login step and save as: TestCase91801_Product2
	Given I navigate to the landing page
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I click Bulk Actions in the Products Grid
	Given I click Forward Product Registration in the Bulk Actions window
	Given I select the product saved as: TestCase91801_Product1 under the Select Products tab
	Given I click continue on the Forward Product Registration page
	Given in the Select Retailers tab under Forward Product Registration I select the retailer: Walgreens
	Given I click continue on the Forward Product Registration page
	Given I select the first product under the Select UPCs tab
	Given I click the Add Case UPC button under the Select UPCs tab
	And In the Add Case UPC modal window I enter the following information:
		| UPC Number          | Type        | Size (Weight Ounces) | Quantity | Transportation Options | Retailer |
		| saved as UPC91801_2 | Aerosol Can | 32                   | 32       | 4A: steel box          | WG       |
	And In the Case UPC modal window I click Save
	Then I check that the alert displayed contains text: There are UPCs that already exists within the WERCSmart database. Please review the UPCs associated within your account, or request to forward a manufacturer's UPCs by creating a new registration as a request from a Distributor. For UPCs that exist within your WERCSmart account, you may use the Report feature to generate a report for your review.

@TReVorId:23396
Scenario: [91735] Duplicate UPC is not permitted within WERCSmart system - Forward Product registration - single UPC
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I create a product with name: Chalk1 and UPC: UPC91801_1 and take to completed using Test Case 75335 with no login step and save as: TestCase91801_Product1
	Given I navigate to the landing page
	Given I Login into WERCSmart Portal - Admin Role - WERCs Premium Subscription Account
	Given I create a product with name: Chalk2 and UPC: UPC91801_2 and take to completed using Test Case 75335 with no login step and save as: TestCase91801_Product2
	Given I navigate to the landing page
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I click Bulk Actions in the Products Grid
	Given I click Forward Product Registration in the Bulk Actions window
	Given I select the product saved as: TestCase91801_Product1 under the Select Products tab
	Given I click continue on the Forward Product Registration page
	Given in the Select Retailers tab under Forward Product Registration I select the retailer: Walgreens
	Given I click continue on the Forward Product Registration page
	Given I select the first product under the Select UPCs tab
	Given I click the Add UPC button under the Select UPCs tab
	And In the Add UPC modal window I enter the following information:
		| UPC Number          | Type        | Size (Ounces) | Retailer |
		| saved as UPC91801_2 | Aerosol Can | 32            | WG       |
	And In the UPC modal window I click Save
	Then I check that the alert displayed contains text: There are UPCs that already exists within the WERCSmart database. Please review the UPCs associated within your account, or request to forward a manufacturer's UPCs by creating a new registration as a request from a Distributor. For UPCs that exist within your WERCSmart account, you may use the Report feature to generate a report for your review.

@TReVorId:23397
Scenario: [91798] Duplicate UPC is not permitted within WERCSmart system - New Product registration - Case UPC
	Given I Login into WERCSmart Portal - Admin Role - WERCs Premium Subscription Account
	Given I create a product with name: Chalk2 and UPC: UPC91801_2 and take to completed using Test Case 75335 with no login step and save as: TestCase91801_Product2
	Given I navigate to the landing page
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
	Then I save the product information as: TestCase91798
	Given I call Shared Step 26897 (Product Characteristics - Solid only available - continue)
	Given I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue) for
		| Retailer |
		| Amazon   |
	Given I click the 'Add Case UPC' button
	Given I add the following into the UPC case fields
		| UPC Number          | Container Type | Size | Quantity | Individual Upc Case Pack | Transportation Option |
		| saved as UPC91801_2 | Aerosol Can    | 32   | 32       |                          | 4A: steel box         |
	Given I click continue
	Then I should see the following error text displayed in the UPC screen: There are UPCs that already exists within the WERCSmart database. Please review the UPCs associated within your account, or request to forward a manufacturer's UPCs by creating a new registration as a request from a Distributor. For UPCs that exist within your WERCSmart account, you may use the Report feature to generate a report for your review.
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase97198

@TReVorId:23413
Scenario: [91800] Duplicate UPC is not permitted within account - Forward Product registration - Case UPC
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I create a product with name: Chalk1 and UPC: UPC91800_1 and take to completed using Test Case 75335 with no login step and save as: TestCase91800_Product1
	Given I navigate to the landing page
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I create a product with name: Chalk2 and UPC: UPC91800_2 and take to completed using Test Case 75335 with no login step and save as: TestCase91800_Product2
	Given I navigate to the landing page
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I click Bulk Actions in the Products Grid
	Given I click Forward Product Registration in the Bulk Actions window
	Given I select the product saved as: TestCase91800_Product1 under the Select Products tab
	Given I click continue on the Forward Product Registration page
	Given in the Select Retailers tab under Forward Product Registration I select the retailer: Walgreens
	Given I click continue on the Forward Product Registration page
	Given I select the first product under the Select UPCs tab
	Given I click the Add Case UPC button under the Select UPCs tab
	And In the Add Case UPC modal window I enter the following information:
		| UPC Number          | Type        | Size (Weight Ounces) | Quantity | Transportation Options | Retailer |
		| saved as UPC91800_2 | Aerosol Can | 32                   | 32       | 4A: steel box          | WG       |
	And In the Case UPC modal window I click Save
	Then I check that the alert displayed contains text: There are UPCs that already exists within the WERCSmart database. Please review the UPCs associated within your account, or request to forward a manufacturer's UPCs by creating a new registration as a request from a Distributor. For UPCs that exist within your WERCSmart account, you may use the Report feature to generate a report for your review.

@TReVorId:23407
Scenario: [91741] Duplicate UPC is not permitted within account - New Product registration - Case UPC
	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
	Then I save the product information as: TestCase91741
	And I call Shared Step 26897 (Product Characteristics - Solid only available - continue)
	And I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	And I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	And I call Shared Step 75146 (Retailer - Select One or More Retailers that DO NOT REQUIRE Vendor ID or Additional UPC Information, Click Done, Click Continue)
	And I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I click the following option in the bottom menu: Search
	Given I save the username for TReVor test user: ProductAccount to context as: AccountUsername
	Given In SHA Manager ProductSearch page I run search:
		| Search Term | Search Value                  |
		| Status      | Completed                     |
		| Supplier    | QA_Automation_ProductsAccount |
		| User        | saved as AccountUsername      |
	Then I save a UPC number for any product in the grid to context as: ExistingUPC
	Given I navigate to the landing page
	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	Given I search for the product saved as: TestCase91741
	Given I edit the first product in results
	Then in the UPC Window, I should see the Universal Product Code (UPC) Page
	And in the UPC Window, I click the Add Case UPC button
	Given I add the following into the UPC case fields
		| UPC Number           | Container Type | Size | Quantity | Individual Upc Case Pack | Transportation Option |
		| saved as ExistingUPC | <first>        | 1    | 1        |                          | <first>               |
	Given I click 'Select all' under Destination Retailers in the UPC page
	Given I click continue
	And I should see a list style form error with text: There are UPCs that already exists within the WERCSmart database. Please review the UPCs associated within your account, or request to forward a manufacturer's UPCs by creating a new registration as a request from a Distributor. For UPCs that exist within your WERCSmart account, you may use the Report feature to generate a report for your review. UPCs:
	And I navigate to the home page
	And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase91741

	
@TReVorId:23410
Scenario: [91100] Duplicate UPC is not permitted within account - New Product registration - Bulk Upload
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
	Then I save the product information as: TestCase91100
	And I call Shared Step 26897 (Product Characteristics - Solid only available - continue)
	And I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	And I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	And I call Shared Step 75146 (Retailer - Select One or More Retailers that DO NOT REQUIRE Vendor ID or Additional UPC Information, Click Done, Click Continue)
	And I click Sample File link and verify the Upload UPC form and save it as test91100 with data:
		| UPC          | Quantity | Size | Net Explosive Mass | US: Part Number | US: Item Number | GP: Part Number | SP: Part Number | TG: DPCI    | HD: OMSID | CT: Item Number   |
		| 823973000000 | 1        | 11   | 1.22               | 11AB45          | 1001            | 1111            | A0001           | 111-22-0001 | 100000001 | 123-1234,123-1230 |
		| 71617198008  | 2        | 22   | 2.33               | 12AB56          | 1002            | 2222            | B0002           | 111-22-0002 | 100000002 | 123-1234,123-1231 |
		| 978959000000 | 3        | 33   | 3.44               | 12AC67          | 1003            | 3333            | C0003           | 111-22-0003 | 100000003 | 123-1234,123-1232 |
		| 688267000000 | 4        | 44   | 4.55               | 12AD89          | 1004            | 4444            | D0004           | 111-22-0004 | 100000004 | 123-1234,123-1233 |
		| 854911000000 | 5        | 55   | 5.66               | 12AF00          | 1005            | 5555            | E0005           | 111-22-0005 | 100000005 | 123-1234,123-1234 |
	And I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I click the following option in the bottom menu: Search
	Given I save the username for TReVor test user: ProductAccount to context as: AccountUsername
	Given In SHA Manager ProductSearch page I run search:
		| Search Term | Search Value                  |
		| Status      | Completed                     |
		| Supplier    | QA_Automation_ProductsAccount |
		| User        | saved as AccountUsername      |
	And I find the UPC number for: 5 products in the grid and save them to context starting with: ExistingUPC
	Then I add the UPC numbers saved to context starting with: ExistingUPC to the UPC bulk upload spreadsheet: test91100
	Given I navigate to the landing page
	Then I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I search for the product saved as: TestCase91100
	Given I edit the first product in results
	Then in the UPC Window, I should see the Universal Product Code (UPC) Page
	And I click the 'Upload UPCs' button and upload the file saved as: test91100
	Then In the Add Multiple dialog box I select all UPCs
	Then In the Add Multiple dialog box I select the packaging type: <first>
	Given In the Add Multiple dialog box I click Next
	And In the Add Multiple dialog box I select all Retailers
	Then In the Add Multiple dialog box I click Finish
	Given I click continue
	Then I should see a list style form error with text: There are UPCs that already exists within the WERCSmart database. Please review the UPCs associated within your account, or request to forward a manufacturer's UPCs by creating a new registration as a request from a Distributor. For UPCs that exist within your WERCSmart account, you may use the Report feature to generate a report for your review. UPCs:
	And I navigate to the home page
	And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase91100

@TReVorId:23411
	Scenario: [91157] Duplicate UPC is not permitted within account - Forward Product registration - single UPC
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Then  I click the following option in the bottom menu: Search
	Then I save the username for TReVor test user: ProductAccount to context as: AccountUsername
	And In SHA Manager ProductSearch page I run search:
		| Search Term | Search Value                  |
		| Status      | Completed                     |
		| Supplier    | QA_Automation_ProductsAccount |
		| User        | saved as AccountUsername      |
	Then I save a UPC number for any product in the grid to context as: ExistingUPC
	Given I navigate to the landing page
	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	Then  I filter the products by: Accepted by Retailers
	And I save the ProductID of the first Product in the grid as: testProduct91157
	Given I click Bulk Actions in the Products Grid
	Given I click Forward Product Registration in the Bulk Actions window
	Then I should see the header: Forward Product Registration on the Forward Product Registration window
	And I confirm the active Forward Product Registration tab is: Select Products	
	Then I select the product with ID saved as: testProduct91157 under the Select Products tab
	And I select the product with ID saved as: testProduct91157 under the right hand panel of the Select Products tab
	Given I click continue on the Forward Product Registration page
	Then In the Forward Product Registration Screen I select the first retailer under Other Retailers
	And I click continue on the Forward Product Registration page
	Given I select the first product under the Select UPCs tab
	Given I click the Add UPC button under the Select UPCs tab
	And In the Add UPC modal window I enter the following information:
		| UPC Number           | Type    | Size (Ounces) | Retailer   |
		| saved as ExistingUPC | <first> | 1             | Select all |
	And In the UPC modal window I click Save
	Then I check alert text contains There are UPCs that already exists within the WERCSmart database. Please review the UPCs associated within your account, or request to forward a manufacturer's UPCs by creating a new registration as a request from a Distributor. For UPCs that exist within your WERCSmart account, you may use the Report feature to generate a report for your review. and dismiss 
	Then In the UPC modal window I click Cancel
	And I click the Home navigation icon and accept the alert popup 






@TReVorId:23406
Scenario: [91077] Duplicate UPC is not permitted within WERCSmart system - New Product registration - Single UPC
	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
	Then I save the product information as: TestCase91077
	And I call Shared Step 26897 (Product Characteristics - Solid only available - continue)
	And I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	And I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	And I call Shared Step 75146 (Retailer - Select One or More Retailers that DO NOT REQUIRE Vendor ID or Additional UPC Information, Click Done, Click Continue)
	And I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I click the following option in the bottom menu: Search
	Given I save the username for TReVor test user: ProductAccount to context as: AccountUsername
	Given In SHA Manager ProductSearch page I run search:
		| Search Term | Search Value |
		| Status      | Completed    |
	Given I find a UPC number for any product not belonging to Supplier: QA_Automation_ProductsAccount in the grid and save to context as: ExistingUPC
	Given I navigate to the landing page
	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	Given I search for the product saved as: TestCase91077
	Given I edit the first product in results
	Then in the UPC Window, I should see the Universal Product Code (UPC) Page
	Given I click the 'Add UPC' button
	Given I add the following into the UPC Fields
		| UPC Number           | Container Type    | Size | DPCI | Quantity |
		| saved as ExistingUPC | Plastic Container | 1    |      |          |
	Given I click 'Select all' under Destination Retailers in the UPC page
	Given I click continue
	And I should see a list style form error with text: There are UPCs that already exists within the WERCSmart database. Please review the UPCs associated within your account, or request to forward a manufacturer's UPCs by creating a new registration as a request from a Distributor. For UPCs that exist within your WERCSmart account, you may use the Report feature to generate a report for your review. UPCs:
	And I navigate to the home page
	And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase91077

	
@TReVorId:23412
	Scenario: [91101] Duplicate UPC is not permitted within WERCSmart system - New Product registration - Bulk Upload
	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
	Then I save the product information as: TestCase91101
	And I call Shared Step 26897 (Product Characteristics - Solid only available - continue)
	And I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	And I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	And I call Shared Step 75146 (Retailer - Select One or More Retailers that DO NOT REQUIRE Vendor ID or Additional UPC Information, Click Done, Click Continue)
	And I click Sample File link and verify the Upload UPC form and save it as test91101 with data:
		| UPC          | Quantity | Size | Net Explosive Mass | US: Part Number | US: Item Number | GP: Part Number | SP: Part Number | TG: DPCI    | HD: OMSID | CT: Item Number   |
		| 823973000000 | 1        | 11   | 1.22               | 11AB45          | 1001            | 1111            | A0001           | 111-22-0001 | 100000001 | 123-1234,123-1230 |
		| 71617198008  | 2        | 22   | 2.33               | 12AB56          | 1002            | 2222            | B0002           | 111-22-0002 | 100000002 | 123-1234,123-1231 |
		| 978959000000 | 3        | 33   | 3.44               | 12AC67          | 1003            | 3333            | C0003           | 111-22-0003 | 100000003 | 123-1234,123-1232 |
		| 688267000000 | 4        | 44   | 4.55               | 12AD89          | 1004            | 4444            | D0004           | 111-22-0004 | 100000004 | 123-1234,123-1233 |
		| 854911000000 | 5        | 55   | 5.66               | 12AF00          | 1005            | 5555            | E0005           | 111-22-0005 | 100000005 | 123-1234,123-1234 |
	And I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I click the following option in the bottom menu: Search
	Given I save the username for TReVor test user: ProductAccount to context as: AccountUsername
	Given In SHA Manager ProductSearch page I run search:
		| Search Term | Search Value |
		| Status      | Completed    |
	Given I find a UPC number for: 5 products not belonging to Supplier: QA_Automation_ProductsAccount in the grid and save to context starting with: ExistingUPC
	Then I add the UPC numbers saved to context starting with: ExistingUPC to the UPC bulk upload spreadsheet: test91101
	Given I navigate to the landing page
	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)	
	Given I search for the product saved as: TestCase91101
	Given I edit the first product in results
	Then in the UPC Window, I should see the Universal Product Code (UPC) Page
	And I click the 'Upload UPCs' button and upload the file saved as: test91101
	Then In the Add Multiple dialog box I select all UPCs
	Then In the Add Multiple dialog box I select the packaging type: <first>
	Given In the Add Multiple dialog box I click Next
	And In the Add Multiple dialog box I select all Retailers
	Then In the Add Multiple dialog box I click Finish
	Given I click continue
	Then I should see a list style form error with text: There are UPCs that already exists within the WERCSmart database. Please review the UPCs associated within your account, or request to forward a manufacturer's UPCs by creating a new registration as a request from a Distributor. For UPCs that exist within your WERCSmart account, you may use the Report feature to generate a report for your review. UPCs:
	And I navigate to the home page
	And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase91101

	Scenario: [95988] Mass Upload UPCs Floating
	Then I generate: 20 random UPC numbers and save them starting with: RandomUPC
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	And I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Soap (Bar, Liquid) for Body
	Then I save the product information as: TestCase95988
	And I click continue
	And I call Shared Step 57501 (Product Characteristics - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue - HP)
	And I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	And I call Shared Step 29181 (Ingredients - add any chemical) with name: soap
	Then I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
	And I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Amazon
	And I click continue
	And I click Sample File link and verify the Upload UPC form and save it as test95988 with data:
		| UPC          | Quantity | Size | Net Explosive Mass | US: Part Number | US: Item Number | GP: Part Number | SP: Part Number | TG: DPCI    | HD: OMSID | CT: Item Number   |
		| 823973000000 | 1        | 11   | 1.22               | 11AB45          | 1001            | 1111            | A0001           | 111-22-0001 | 100000001 | 123-1234,123-1230 |
		| 71617198008  | 2        | 22   | 2.33               | 12AB56          | 1002            | 2222            | B0002           | 111-22-0002 | 100000002 | 123-1234,123-1231 |
		| 978959000000 | 3        | 33   | 3.44               | 12AC67          | 1003            | 3333            | C0003           | 111-22-0003 | 100000003 | 123-1234,123-1232 |
		| 688267000000 | 4        | 44   | 4.55               | 12AD89          | 1004            | 4444            | D0004           | 111-22-0004 | 100000004 | 123-1234,123-1233 |
		| 854911000000 | 5        | 55   | 5.66               | 12AF00          | 1005            | 5555            | E0005           | 111-22-0005 | 100000005 | 123-1234,123-1234 |
	And I edit the testdoc.xlsx, and save its filepath as: Bulktest95988 and verify it contains the UPC data in the table saved as: UPCTable95988
		| UPC           | Quantity | Size | Net Explosive Mass | US: Part Number | US: Item Number | GP: Part Number | SP: Part Number | TG: DPCI    | HD: OMSID | CT: Item Number   |
		| <RandomUPC1>  | 1        | 32   | 1.22               | 00AA01          | 2001            | 1111            | F0001           | 111-22-0001 | 100000001 | 123-1234,123-1230 |
		| <RandomUPC2>  | 2        | 32   | 2.33               | 00BB02          | 2002            | 1112            | G0002           | 111-22-0002 | 100000002 | 123-1234,123-1231 |
		| <RandomUPC3>  | 3        | 32   | 3.44               | 00CC03          | 2003            | 1113            | H0003           | 111-22-0003 | 100000003 | 123-1234,123-1232 |
		| <RandomUPC4>  | 4        | 32   | 4.55               | 00DD04          | 2004            | 1114            | I0004           | 111-22-0004 | 100000004 | 123-1234,123-1233 |
		| <RandomUPC5>  | 5        | 32   | 5.66               | 00EE05          | 2005            | 1115            | J0005           | 111-22-0005 | 100000005 | 123-1234,123-1234 |
		| <RandomUPC6>  | 6        | 32   | 6.77               | 00FF06          | 2006            | 1116            | K0006           | 111-22-0006 | 100000006 | 123-1234,123-1235 |
		| <RandomUPC7>  | 7        | 32   | 7.88               | 00GG07          | 2007            | 1117            | L0007           | 111-22-0007 | 100000007 | 123-1234,123-1236 |
		| <RandomUPC8>  | 8        | 32   | 8.99               | 00HH08          | 2008            | 1118            | M0008           | 111-22-0008 | 100000008 | 123-1234,123-1237 |
		| <RandomUPC9>  | 9        | 32   | 9.00               | 00II09          | 2009            | 1119            | N0009           | 111-22-0009 | 100000009 | 123-1234,123-1238 |
		| <RandomUPC10> | 10       | 32   | 10.11              | 00JJ10          | 2010            | 1110            | O0010           | 111-22-0010 | 100000010 | 123-1234,123-1239 |
		| <RandomUPC11> | 11       | 32   | 11.22              | 00KK11          | 2011            | 1111            | P0013           | 111-22-0011 | 100000011 | 123-1234,123-1240 |
		| <RandomUPC12> | 12       | 32   | 12.33              | 00LL12          | 2012            | 1112            | Q0014           | 111-22-0012 | 100000012 | 123-1234,123-1241 |
		| <RandomUPC13> | 13       | 32   | 13.44              | 00MM13          | 2013            | 1113            | R0015           | 111-22-0013 | 100000013 | 123-1234,123-1242 |
		| <RandomUPC14> | 14       | 32   | 14.55              | 00NN14          | 2014            | 1114            | S0016           | 111-22-0014 | 100000014 | 123-1234,123-1243 |
		| <RandomUPC15> | 15       | 32   | 15.66              | 00OO15          | 2015            | 1115            | T0015           | 111-22-0015 | 100000015 | 123-1234,123-1244 |
		| <RandomUPC16> | 16       | 32   | 16.77              | 00PP16          | 2016            | 1116            | U0016           | 111-22-0016 | 100000016 | 123-1234,123-1245 |
		| <RandomUPC17> | 17       | 32   | 17.88              | 00QQ17          | 2017            | 1117            | u0017           | 111-22-0017 | 100000017 | 123-1234,123-1246 |
		| <RandomUPC18> | 18       | 32   | 18.99              | 00RR18          | 2018            | 1118            | v0018           | 111-22-0018 | 100000018 | 123-1234,123-1247 |
		| <RandomUPC19> | 19       | 32   | 19.00              | 00SS19          | 2019            | 1119            | W0019           | 111-22-0019 | 100000019 | 123-1234,123-1248 |
		| <RandomUPC20> | 20       | 32   | 20.11              | 00TT20          | 2020            | 1120            | X0020           | 111-22-0020 | 100000020 | 123-1234,123-1249 |
	Then I click the 'Upload UPCs' button and upload the file saved as: Bulktest95988
	Then I confirm that Add Multiple UPC popup appears and the values are the same as the UPC Upload document saved in the Table called: UPCTable95988	
	Then In the Add Multiple dialog box I select all UPCs
	Then I Confirm All UPCs are: Selected
	Then In the Add Multiple dialog box I select the packaging type: <first>
	Given In the Add Multiple dialog box I click Next
	Then In the Add Multiple dialog box I select all Retailers
	Then I Check if all Retailers are: Selected
	Then In the Add Multiple dialog box I select all Retailers
	Then I Check if all Retailers are: Not Selected
	Then In the Add Multiple dialog box I select all Retailers
	Then I Check if all Retailers are: Selected
	Then In the Add Multiple dialog box I click Finish
	And I confirm that Add Multiple UPC popup disappears and the values on the new product screen are the same as the UPC Upload document saved in the Table called: UPCTable95988
	# Check for scoll element
	Then I click Continue and should not see an error message
	And I navigate to the home page
	And I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase95988
	

	

	







	
	

