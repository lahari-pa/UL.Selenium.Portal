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



#Background:
#	Given I verify the following users exist and if not I create them using SHAUser
#		| username    | FirstName | LastName   | Role         | EmailAddress                |
#		| SHAQAAuto9  | QA        | Automation | QA Reviewers | qasha.kxxyxunf@mailosaur.io |

# Assigned to Abbie Zullo
# Created by Abbie Zullo
# Test case can be found at the following paths:
# NetProjects10\WercsSmart Portal\WERCSmart\Product Registration\UPC
@TestCase:91076
Scenario: [91076] Duplicate UPC is not permitted within account - New Product registration - single UPC
	Given I find an existing UPC number in trevor account saved as: ProductAccount using feature context: ExistingUPC_ProductAccount_1
	Given I navigate to the landing page
	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
	Then I save the product information as: TestCase91076
	And I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	#And I call Shared Step 62678 (Product Information - US & Canada, No Child, No OSHA, NO Direct ship, No PL, No NGFR - Continue, Happy path)
	And I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	And I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	And I call Shared Step 75146 (Retailer - Select One or More Retailers that DO NOT REQUIRE Vendor ID or Additional UPC Information, Click Done, Click Continue)
	Then I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page
	Given I click the 'Add' button
	Given I add the following into the UPC Fields
		| UPC Number                            | Container Type    | Size | DPCI | Quantity |
		| saved as ExistingUPC_ProductAccount_1 | Plastic Container | 1    |      |          |
	Given I click 'Select all' under Destination Retailers in the UPC page
	Given I click continue
	And I should see a list style form error with text: There are UPCs that already exists within the WERCSmart database. Please review the UPCs associated within your account, or request to forward a manufacturer's UPCs by creating a new registration as a request from a Distributor. For UPCs that exist within your WERCSmart account, you may use the Report feature to generate a report for your review. UPCs:
	And I navigate to the home page
	And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase91076

@singlerun
@TestCase:82536
Scenario: [82536] Mass Upload UPCs, Checking for Duplicate UPCs
	Given I generate: 5 random UPC numbers and save them starting with: RandomUPC
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	And I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Soap (Bar, Liquid) for Body
	Then I save the product information as: TestCase82536
	And I click continue
	And I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	And I call Shared Step 57501 (Physical and Chemical Properties - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue - HP)
	And I call Shared Step 29181 (Ingredients - add any chemical) with name: soap
	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	And I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
	And I call Shared Step 57506 (Transportation Details 1 - Regulated for Transport(No) - Exemption(Random) - Continue - Happy Path)
	And I call Shared Step 62536 (Transportation Details 2 > I do not ship internationally > Continue - Happy Path)
	And I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Amazon
	And I click continue
	And I click Sample File link and verify the Upload UPC form and save it as test82536 with data:
		| UPC           | Name   | Quantity | Size | Internal SKU | US: Part Number | US: Item Number | GP: Part Number | SP: Part Number | TG: DPCI    | HD: OMSID | CT: Item Number   | Green Good Housekeeping | Green Seal | EPA Safer Choice | Cradle to Cradle | UL Ecologo | EWG Verified | Green Tick | Madesafe | NSF Sustainability Certified |
		| 823973000000  | Saco 1 | 1        | 100  | KS955AR      | 11AB45          | 1001            | 1111            | A0001           | 111-22-0001 | 100000001 | 123-1234,123-1230 | Yes                     |            |                  |                  |            | Yes          |            |          | Yes                          |
		| 0037600724210 | Saco 2 | 2        | 101  |              | 12AB56          | 1002            | 2222            | B0002           | 111-22-0002 | 100000002 | 123-1234,123-1231 |                         | Yes        |                  |                  |            |              | Yes        |          |                              |
		| 978959000000  | Saco 3 | 3        | 102  |              | 12AC67          | 1003            | 3333            | C0003           | 111-22-0003 | 100000003 | 123-1234,123-1232 |                         |            | Yes              |                  |            |              |            |          |                              |
		| 688267000000  | Saco 4 | 4        | 103  | KS956AG      | 12AD89          | 1004            | 4444            | D0004           | 111-22-0004 | 100000004 | 123-1234,123-1233 |                         |            |                  | Yes              |            |              |            | Yes      |                              |
		| 854911000000  | Saco 5 | 5        | 104  | KS957AT      | 12AF00          | 1005            | 5555            | E0005           | 111-22-0005 | 100000005 | 123-1234,123-1234 |                         |            |                  |                  | Yes        |              |            |          |                              |
	And I edit the testdoc.xlsx, and save its filepath as: Bulktest82536 and verify it contains the UPC data in the table saved as: UPCTable82536, (Base Data Only: true)
		| UPC          | Name    | Quantity | Size | Net Explosive Mass | US: Part Number | US: Item Number | GP: Part Number | SP: Part Number | TG: DPCI    | HD: OMSID | CT: Item Number   | Green Good Housekeeping | Green Seal | EPA Safer Choice | Cradle to Cradle | UL Ecologo | EWG Verified | Green Tick | Madesafe | NSF Sustainability Certified |
		| %RandomUPC1% | MySoap1 | 1        | 32   | 1.22               | 00AA01          | 2001            | 1111            | F0001           | 111-22-0001 | 100000001 | 123-1234,123-1230 |                         |            |                  |                  |            |              |            |          |                              |
		| %RandomUPC1% | MySoap2 | 2        | 32   | 2.33               | 00BB02          | 2002            | 1112            | G0002           | 111-22-0002 | 100000002 | 123-1234,123-1231 |                         |            |                  |                  |            |              |            |          |                              |
		| %RandomUPC2% | MySoap3 | 3        | 32   | 3.44               | 00CC03          | 2003            | 1113            | H0003           | 111-22-0003 | 100000003 | 123-1234,123-1232 |                         |            |                  |                  |            |              |            |          |                              |
		| %RandomUPC2% | MySoap4 | 4        | 32   | 4.55               | 00DD04          | 2004            | 1114            | I0004           | 111-22-0004 | 100000004 | 123-1234,123-1233 |                         |            |                  |                  |            |              |            |          |                              |
		| %RandomUPC3% | MySoap5 | 5        | 32   | 5.66               | 00EE05          | 2005            | 1115            | J0005           | 111-22-0005 | 100000005 | 123-1234,123-1234 |                         |            |                  |                  |            |              |            |          |                              |
		| %RandomUPC4% | MySoap6 | 6        | 32   | 6.77               | 00FF06          | 2006            | 1116            | K0006           | 111-22-0006 | 100000006 | 123-1234,123-1235 |                         |            |                  |                  |            |              |            |          |                              |
		| %RandomUPC5% | MySoap7 | 7        | 32   | 7.88               | 00GG07          | 2007            | 1117            | L0007           | 111-22-0007 | 100000007 | 123-1234,123-1236 |                         |            |                  |                  |            |              |            |          |                              |
	Then I click the 'Upload File' button and upload the file saved as: Bulktest82536
	Then I confirm that Add Multiple UPC popup appears and the values are the same as the UPC Upload document saved in the Table called: UPCTable82536
	Then In the Add Multiple dialog box I select all UPCs
	Then I Confirm All UPCs are: Selected
	Then In the Add Multiple dialog box I select the packaging type: <first>
	Then I Check that the type column becomes populated with option: <first>
	Given In the Add Multiple dialog box I click Next
	Then In the Add Multiple dialog box I select all Retailers
	Then I Check if all Retailers are: Selected
	Then In the Add Multiple dialog box I select all Retailers
	Then I Check if all Retailers are: Not Selected
	Then In the Add Multiple dialog box I select all Retailers
	Then I Check if all Retailers are: Selected
	Then In the Add Multiple dialog box I click Finish
	And I confirm that Add Multiple UPC popup disappears and the values on the new product screen are the same as the UPC Upload document saved in the Table called: UPCTable82536
	Given I click continue
	And I should see a list style form error with text: There are UPCs that already exists within the WERCSmart database. Please review the UPCs associated within your account, or request to forward a manufacturer's UPCs by creating a new registration as a request from a Distributor. For UPCs that exist within your WERCSmart account, you may use the Report feature to generate a report for your review. UPCs:
	And I confirm that Add Multiple UPC popup disappears and the values on the new product screen are the same as the UPC Upload document saved in the Table called: UPCTable82536
	Then I make a list of the duplicated UPCs and save it as: duplicateUPCs82536 from the table saved as: UPCTable82536
	Then I use a list of duplicated UPCs saved as: duplicateUPCs82536 and check that they have a warning traingle next to their retailer code and save the ones that do as: warningPresentList82536
	Then Using the Hashtable of duplicate UPCs saved as: warningPresentList82536 I select the UPCS
	Then I Click Delete Rows
	Then I Check the Delete Rows Warning Popup: appears
	Then I Click Ok in the Delete Rows Warning Popup
	Then I Check the Delete Rows Warning Popup: disappears
	Then I Check all Duplicate UPCs saved as: warningPresentList82536 are no longer shown
	Then I click Continue and should not see an error message
	And I navigate to the home page
	And I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase82536

		



	#Given I generate a random UPC number and save as: UPC_A
	#Given I generate a random UPC number and save as: UPC_B
	#Given I generate a random UPC number and save as: UPC_C
	#Given I generate a random UPC number and save as: UPC_D
	#Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	#And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	#And I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Soap (Bar, Liquid) for Body
	#And I click continue
	#And I call Shared Step 57501 (Physical and Chemical Properties - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue - HP)
	#And I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	#And I call Shared Step 29181 (Ingredients - add any chemical) with name: soap
	#And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	#And I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
	#And I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Amazon
	#And I click continue
	#And I click Sample File link and verify the Upload UPC form and save it as test82536 with data:
	#	| UPC          | Quantity | Size | Net Explosive Mass | US: Part Number | US: Item Number | GP: Part Number | SP: Part Number | TG: DPCI    | HD: OMSID | CT: Item Number   |
	#	| 823973000000 | 1        | 11   | 1.22               | 11AB45          | 1001            | 1111            | A0001           | 111-22-0001 | 100000001 | 123-1234,123-1230 |
	#	| 71617198008  | 2        | 22   | 2.33               | 12AB56          | 1002            | 2222            | B0002           | 111-22-0002 | 100000002 | 123-1234,123-1231 |
	#	| 978959000000 | 3        | 33   | 3.44               | 12AC67          | 1003            | 3333            | C0003           | 111-22-0003 | 100000003 | 123-1234,123-1232 |
	#	| 688267000000 | 4        | 44   | 4.55               | 12AD89          | 1004            | 4444            | D0004           | 111-22-0004 | 100000004 | 123-1234,123-1233 |
	#	| 854911000000 | 5        | 55   | 5.66               | 12AF00          | 1005            | 5555            | E0005           | 111-22-0005 | 100000005 | 123-1234,123-1234 |
	#And I create a new file saved as: UploadFile to upload using the UPCs saved as:
	#	| UPC   | Quantity | Size | Net Explosive Mass | US: Part Number | US: Item Number | GP: Part Number | SP: Part Number | TG: DPCI    | HD: OMSID | CT: Item Number   |
	#	| UPC_A | 11       | 1    | 6.6                | 00AA01          | 2001            | 1234            | F0001           | 123-45-6789 | 500000009 | 223-1234,123-1230 |
	#	| UPC_B | 31       | 2    | 7.94               | 00BB02          | 2002            | 2345            | G0002           | 234-56-7890 | 400000008 | 223-1234,123-1231 |
	#	| UPC_C | 61       | 3    | 8.2                | 00CC03          | 2003            | 3456            | H0003           | 345-67-8901 | 300000007 | 223-1234,123-1232 |
	#	| UPC_D | 91       | 4    | 9.06               | 00DD04          | 2004            | 5678            | I0004           | 456-78-9012 | 200000006 | 223-1234,123-1233 |
	##And I Create your own document with UPCs, use the following site to get UPCs https://www.upcdatabase.com/click on the Random Item link and copy and p123-1234,123-1234aste the UPCs that appear on the textbox
	#And I In the UPC document add some duplicate UPCs, save the document
	#And I Click on the Upload File button
	#And I Search for the document that contains the UPCs you will upload, click Open button
	#And I Confirm that the Add Multiple window openswith the UPCs that were added in the document
	#And I Confirm that the size is also the same as from what is in the UPC document
	#And I Select the checkbox that next to the UPC tilte
	#And I From the Packaging type dropdown select one of the options
	#And I Click Next button
	#And I Select the checkbox for the retailer
	#And I Click on the name of the Retailer
	#And I Click on the name of the Retailer again
	#And I Click the Finish button
	#And I Click the continue button
	#And I Confirm that you get a message, There are UPCs that already exist within the WERCSmart database.  Please review the UPCs associated within yout account, or request to forward a manufacturer's UPC by creating a new registration as a request from a Distrubutor. For UPCs that exist within your WERCSmart account, you may use the Report feature to generate a report for your review.  UPCs: xxxxxxxxxxxxxWhere xxxxxxxxxxxxx is the UPC that is duplicatedIf more than one UPC is a duplicate they be shown
	#And I Confirm the UPC rows that are duplicates show the red warning triangle next to the Retailer code
	#And I Select the UPC(s) that are shown as duplicates by checking the box next to the UPC row in the table
	#And I Click the Delete Rows button
	#And I Click OK
	#And I Confirm the UPC(s) you selected for deletion are no longer shown in the UPC table
	#And I Click the Continue button
	#And I Confirm you are allowed to go on to next screen without errors
	#And I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase82536

@TestCase:91801
Scenario: [91801] Duplicate UPC is not permitted within WERCSmart system - Forward Product registration - Case UPC
	Given I call Shared Step 65080b (Login to Studio as user saved as: SHAQAAuto7 and Open SHA manager)
	Then I click the following option in the bottom menu: Search
	Then I save the username for TReVor test user: ProductAccount to context as: AccountUsername
	And In SHA Manager ProductSearch page I run search:
		| Search Term | Search Value                  |
		| Status      | Completed                     |
		| Supplier    | QA_Automation_ProductsAccount |
		| User        | saved as AccountUsername      |
	Then I save a UPC number for any product in the grid to context as: ExistingUPC
	Given I navigate to the landing page
	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	Then I filter the products by: Accepted by Retailers
	And I save the ProductID of the first Product in the grid no in recertification as: testProduct91157
	Given I click Bulk Actions in the Products Grid
	Given I click Forward Product Registration in the Bulk Actions window
	Then I should see the header: Forward Product Registration on the Forward Product Registration window
	And I confirm the active Forward Product Registration tab is: Select Products
	Then I select the product with ID saved as: testProduct91157 under the Select Products tab
	And I select the product with ID saved as: testProduct91157 under the right hand panel of the Select Products tab
	Given I click continue on the Forward Product Registration page
	#Then In the Forward Product Registration Screen I select the first retailer under Other Retailers
	Given in the Select Retailers tab under Forward Product Registration I select the retailer: Walgreens
	And I click continue on the Forward Product Registration page
	Given I select the first product under the Select UPCs tab
	Given I click the Add Casepack button under the Select UPCs tab
	Then I wait for the Add Casepack popup to appear
	And In the Add Casepack modal window I enter the following information:
		| UPC Number           | Type      | Size (Weight Ounces) | Quantity | Transportation Options | Retailer |
		| saved as ExistingUPC | Cardboard | 32                   | 32       | 4A: steel box          | WG       |
	And In the Case UPC modal window I click Save
	Then I check that the alert displayed contains text: There are UPCs that already exists within the WERCSmart database. Please review the UPCs associated within your account, or request to forward a manufacturer's UPCs by creating a new registration as a request from a Distributor. For UPCs that exist within your WERCSmart account, you may use the Report feature to generate a report for your review.
	

@TestCase:91735
Scenario: [91735] Duplicate UPC is not permitted within WERCSmart system - Forward Product registration - single UPC
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I create a product with name: Chalk1 and UPC: UPC91801_1 and take to completed using Test Case 75335and SHA account: SHAQAAuto7 with no login step and save as: TestCase91801_Product1

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
		| UPC Number          | Type      | Size (Ounces) | Retailer |
		| saved as UPC91801_2 | Cardboard | 32            | WG       |
	And In the UPC modal window I click Save
	Then I check that the alert displayed contains text: There are UPCs that already exists within the WERCSmart database. Please review the UPCs associated within your account, or request to forward a manufacturer's UPCs by creating a new registration as a request from a Distributor. For UPCs that exist within your WERCSmart account, you may use the Report feature to generate a report for your review.

@TestCase:91798
Scenario: [91798] Duplicate UPC is not permitted within WERCSmart system - New Product registration - Case UPC
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I create a product with name: Chalk2 and UPC: UPC91801_2 and take to completed using Test Case 75335and SHA account: SHAQAAuto7 with no login step and save as: TestCase91801_Product2
	Given I navigate to the landing page
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
	Then I save the product information as: TestCase91798
    And I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
    Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue) for
		| Retailer |
		| Amazon   |
	Given I click the 'Add Casepack' button
	Given I add the following into the UPC case fields
		| UPC Number          | Container Type | Size | Quantity | Individual Upc Case Pack | Transportation Option |
		| saved as UPC91801_2 | Cardboard      | 32   | 32       |                          | 4A: steel box         |
	Given I click continue
	Then I should see the following error text displayed in the UPC screen: There are UPCs that already exists within the WERCSmart database. Please review the UPCs associated within your account, or request to forward a manufacturer's UPCs by creating a new registration as a request from a Distributor. For UPCs that exist within your WERCSmart account, you may use the Report feature to generate a report for your review.
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase91798

@TestCase:91800
Scenario: [91800] Duplicate UPC is not permitted within account - Forward Product registration - Case UPC
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I create a product with name: Chalk1 and UPC: UPC91800_1 and take to completed using Test Case 75335and SHA account: SHAQAAuto7 with no login step and save as: TestCase91800_Product1
	Given I navigate to the landing page
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I create a product with name: Chalk2 and UPC: UPC91800_2 and take to completed using Test Case 75335and SHA account: SHAQAAuto7 with no login step and save as: TestCase91800_Product2
	Given I navigate to the landing page
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I click Bulk Actions in the Products Grid
	Given I click Forward Product Registration in the Bulk Actions window
	Given I select the product saved as: TestCase91800_Product1 under the Select Products tab
	Given I click continue on the Forward Product Registration page
	Given in the Select Retailers tab under Forward Product Registration I select the retailer: Walgreens
	Given I click continue on the Forward Product Registration page
	Given I select the first product under the Select UPCs tab
	Given I click the Add Casepack button under the Select UPCs tab
	Then I wait for the Add Casepack popup to appear
	And In the Add Casepack modal window I enter the following information:
		| UPC Number          | Type      | Size (Weight Ounces) | Quantity | Transportation Options | Retailer |
		| saved as UPC91800_2 | Cardboard | 32                   | 32       | 4A: steel box          | WG       |
	And In the Case UPC modal window I click Save
	Then I check that the alert displayed contains text: There are UPCs that already exists within the WERCSmart database. Please review the UPCs associated within your account, or request to forward a manufacturer's UPCs by creating a new registration as a request from a Distributor. For UPCs that exist within your WERCSmart account, you may use the Report feature to generate a report for your review.

@TestCase:91741
Scenario: [91741] Duplicate UPC is not permitted within account - New Product registration - Case UPC
	Given I find an existing UPC number in trevor account saved as: ProductAccount using feature context: ExistingUPC_ProductAccount_1
	Given I navigate to the landing page
	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
	Then I save the product information as: TestCase91741
    And I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	And I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	And I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	And I call Shared Step 75146 (Retailer - Select One or More Retailers that DO NOT REQUIRE Vendor ID or Additional UPC Information, Click Done, Click Continue)
	Then I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page
	And in the UPC Window, I click the Add Casepack button
	Given I add the following into the UPC case fields
		| UPC Number                            | Container Type | Size | Quantity | Individual Upc Case Pack | Transportation Option |
		| saved as ExistingUPC_ProductAccount_1 | <first>        | 1    | 1        |                          | <first>               |
	Given I click 'Select all' under Destination Retailers in the UPC page
	Given I click continue
	And I should see a list style form error with text: There are UPCs that already exists within the WERCSmart database. Please review the UPCs associated within your account, or request to forward a manufacturer's UPCs by creating a new registration as a request from a Distributor. For UPCs that exist within your WERCSmart account, you may use the Report feature to generate a report for your review. UPCs:
	And I navigate to the home page
	And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase91741
	
@TestCase:91100
Scenario: [91100] Duplicate UPC is not permitted within account - New Product registration - Bulk Upload
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
	Then I save the product information as: TestCase91100
	And I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	And I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	And I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	And I call Shared Step 75146 (Retailer - Select One or More Retailers that DO NOT REQUIRE Vendor ID or Additional UPC Information, Click Done, Click Continue)
	And I click Sample File link and verify the Upload UPC form and save it as test91100
		| UPC           | Name   | Quantity | Size | Internal SKU | US: Part Number | US: Item Number | GP: Part Number | SP: Part Number | TG: DPCI    | HD: OMSID | CT: Item Number   | Green Good Housekeeping | Green Seal | EPA Safer Choice | Cradle to Cradle | UL Ecologo | EWG Verified | Green Tick | Madesafe | NSF Sustainability Certified |
		| 823973000000  | Saco 1 | 1        | 100  | KS955AR      | 11AB45          | 1001            | 1111            | A0001           | 111-22-0001 | 100000001 | 123-1234,123-1230 | Yes                     |            |                  |                  |            | Yes          |            |          | Yes                          |
		| 0037600724210 | Saco 2 | 2        | 101  |              | 12AB56          | 1002            | 2222            | B0002           | 111-22-0002 | 100000002 | 123-1234,123-1231 |                         | Yes        |                  |                  |            |              | Yes        |          |                              |
		| 978959000000  | Saco 3 | 3        | 102  |              | 12AC67          | 1003            | 3333            | C0003           | 111-22-0003 | 100000003 | 123-1234,123-1232 |                         |            | Yes              |                  |            |              |            |          |                              |
		| 688267000000  | Saco 4 | 4        | 103  | KS956AG      | 12AD89          | 1004            | 4444            | D0004           | 111-22-0004 | 100000004 | 123-1234,123-1233 |                         |            |                  | Yes              |            |              |            | Yes      |                              |
		| 854911000000  | Saco 5 | 5        | 104  | KS957AT      | 12AF00          | 1005            | 5555            | E0005           | 111-22-0005 | 100000005 | 123-1234,123-1234 |                         |            |                  |                  | Yes        |              |            |          |                              |
	And I call Shared Step 65080b (Login to Studio as user saved as: SHAQAAuto9 and Open SHA manager)
	Given I click the following option in the bottom menu: Search
	Given I save the username for TReVor test user: ProductAccount to context as: AccountUsername
	Given In SHA Manager ProductSearch page I run search:
		| Search Term | Search Value |
		| Status      | Completed    |
	And I find the UPC number for: 5 products in the grid and save them to context starting with: ExistingUPC
	Then I add the UPC numbers saved to context starting with: ExistingUPC to the UPC bulk upload spreadsheet: test91100
	Given I navigate to the landing page
	Then I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I search for the product saved as: TestCase91100
	Given I edit the first product in results
	Then I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page
	And I click the 'Upload File' button and upload the file saved as: test91100
	Then I confirm that the Add Multiple UPC window opens
	Then In the Add Multiple dialog box I select all UPCs
	Then In the Add Multiple dialog box I select the packaging type: <first>
	Given In the Add Multiple dialog box I click Next
	And In the Add Multiple dialog box I select all Retailers
	Then In the Add Multiple dialog box I click Finish
	Given I click continue
	Then I should see a list style form error with text: Please fix UPC errors
	And I navigate to the home page
	And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase91100

@TestCase:91157
Scenario: [91157] Duplicate UPC is not permitted within account - Forward Product registration - single UPC
	Given I call Shared Step 65080b (Login to Studio as user saved as: SHAQAAuto7 and Open SHA manager)
	Then I click the following option in the bottom menu: Search
	Then I save the username for TReVor test user: ProductAccount to context as: AccountUsername
	And In SHA Manager ProductSearch page I run search:
		| Search Term | Search Value |
		| Status      | Submitted    |
	Then I save a UPC number for any product in the grid to context as: ExistingUPC
	Given I navigate to the landing page
	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	Then I filter the products by: Accepted by Retailers
	And I save the ProductID of the first Product in the grid no in recertification as: testProduct91157
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

@TestCase:91077
Scenario: [91077] Duplicate UPC is not permitted within WERCSmart system - New Product registration - Single UPC
	Given I find an existing UPC number in trevor account saved as: ProductAccount using feature context: ExistingUPC_ProductAccount_1
	Given I navigate to the landing page
	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
	Then I save the product information as: TestCase91077
	And I call Shared Step 62678 (Product Information - US & Canada, No Child, No OSHA, NO Direct ship, No PL, No NGFR - Continue, Happy path)
	And I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	And I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	And I call Shared Step 75146 (Retailer - Select One or More Retailers that DO NOT REQUIRE Vendor ID or Additional UPC Information, Click Done, Click Continue)
	Then I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page
	Given I click the 'Add' button
	Given I add the following into the UPC Fields
		| UPC Number                            | Container Type    | Size | DPCI | Quantity |
		| saved as ExistingUPC_ProductAccount_1 | Plastic Container | 1    |      |          |
	Given I click 'Select all' under Destination Retailers in the UPC page
	Given I click continue
	And I should see a list style form error with text: There are UPCs that already exists within the WERCSmart database. Please review the UPCs associated within your account, or request to forward a manufacturer's UPCs by creating a new registration as a request from a Distributor. For UPCs that exist within your WERCSmart account, you may use the Report feature to generate a report for your review. UPCs:
	And I navigate to the home page
	And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase91077

	
@TestCase:91101
Scenario: [91101] Duplicate UPC is not permitted within WERCSmart system - New Product registration - Bulk Upload
	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
	Then I save the product information as: TestCase91101
And I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
And I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	And I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	And I call Shared Step 75146 (Retailer - Select One or More Retailers that DO NOT REQUIRE Vendor ID or Additional UPC Information, Click Done, Click Continue)
	And I click Sample File link and verify the Upload UPC form and save it as test91100
		| UPC           | Name       | Quantity | Size | Internal SKU | US: Part Number | US: Item Number | GP: Part Number | SP: Part Number | TG: DPCI    | HD: OMSID | CT: Item Number   | Green Good Housekeeping | Green Seal | EPA Safer Choice | Cradle to Cradle | UL Ecologo | EWG Verified | Green Tick | Madesafe | NSF Sustainability Certified |
		| 823973000000  | Saco 1     | 1        | 100  | KS955AR      | 11AB45          | 1001            | 1111            | A0001           | 111-22-0001 | 100000001 | 123-1234,123-1230 | Yes                     |            |                  |                  |            | Yes          |            |          | Yes                          |
		| 0037600724210 | Saco 2     | 2        | 101  |              | 12AB56          | 1002            | 2222            | B0002           | 111-22-0002 | 100000002 | 123-1234,123-1231 |                         | Yes        |                  |                  |            |              | Yes        |          |                              |
		| 978959000000  | Saco 3     | 3        | 102  |              | 12AC67          | 1003            | 3333            | C0003           | 111-22-0003 | 100000003 | 123-1234,123-1232 |                         |            | Yes              |                  |            |              |            |          |                              |
		| 688267000000  | Saco 4     | 4        | 103  | KS956AG      | 12AD89          | 1004            | 4444            | D0004           | 111-22-0004 | 100000004 | 123-1234,123-1233 |                         |            |                  | Yes              |            |              |            | Yes      |                              |
		| 854911000000  | Saco 5     | 5        | 104  | KS957AT      | 12AF00          | 1005            | 5555            | E0005           | 111-22-0005 | 100000005 | 123-1234,123-1234 |                         |            |                  |                  | Yes        |              |            |          |                              |
	
	#Looks like there is a bug failing this test that does not auto fill product name if using bulk upload file, in testing we can use below method with sample file data+ names to stop this being an issue, but needs to be raised.
	#And I edit the testdoc.xlsx, and save its filepath as: Bulktest95988 and verify it contains the UPC data in the table saved as: UPCTable95988, (Base Data Only: true)

	And I call Shared Step 65080b (Login to Studio as user saved as: SHAQAAuto7 and Open SHA manager)
	Given I click the following option in the bottom menu: Search
	Given I save the username for TReVor test user: ProductAccount to context as: AccountUsername
	Given In SHA Manager ProductSearch page I run search:
		| Search Term | Search Value |
		| Status      | Completed    |
	Given I find a UPC number for: 5 products not belonging to Supplier: QA_Automation_ProductsAccount in the grid and save to context starting with: ExistingUPC
	Then I add the UPC numbers saved to context starting with: ExistingUPC to the UPC bulk upload spreadsheet: test91101 with data:
	#Then I add Generic Product Names to the UPC bulk upload spreadsheet: BulkUpload91101
	Given I navigate to the landing page
	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	Given I search for the product saved as: TestCase91101
	Given I edit the first product in results
	Then I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page
	And I click the 'Upload File' button and upload the file saved as: test91101 with data:
	Then I confirm that the Add Multiple UPC window opens
	Then In the Add Multiple dialog box I select all UPCs
	Then In the Add Multiple dialog box I select the packaging type: <first>
	Given In the Add Multiple dialog box I click Next
	And In the Add Multiple dialog box I select all Retailers
	Then In the Add Multiple dialog box I click Finish
	Given I click continue
	Then I should see a list style form error with text: Please fix UPC errors
	And I navigate to the home page
	And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase91101

	


	

	







	
	

