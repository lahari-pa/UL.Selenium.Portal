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
@SHA
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
	Then I should see the Universal Product Code (UPC) Page
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
		| Search Term | Search Value                  |
		| Status      | Completed                     |
	Given I find a UPC number for any product not belonging to Supplier: QA_Automation_ProductsAccount in the grid and save to context as: ExistingUPC
	Given I navigate to the landing page
	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
		Given I search for the product saved as: TestCase91077
	Given I edit the first product in results
	Then I should see the Universal Product Code (UPC) Page
	Given I click the 'Add UPC' button
	Given I add the following into the UPC Fields
		| UPC Number           | Container Type    | Size | DPCI | Quantity |
		| saved as ExistingUPC | Plastic Container | 1    |      |          |
	Given I click 'Select all' under Destination Retailers in the UPC page
	Given I click continue
	And I should see a list style form error with text: There are UPCs that already exists within the WERCSmart database. Please review the UPCs associated within your account, or request to forward a manufacturer's UPCs by creating a new registration as a request from a Distributor. For UPCs that exist within your WERCSmart account, you may use the Report feature to generate a report for your review. UPCs:
	And I navigate to the home page
	And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase91077
