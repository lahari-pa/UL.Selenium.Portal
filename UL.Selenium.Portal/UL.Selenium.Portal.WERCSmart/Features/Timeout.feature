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
@run_Timeout
Feature: Timeout

@Timeout1
@TReVorId:23419
Scenario: [Timeout Test] Mass Upload UPCs Popup, Inactivity Popup can be interacted with
Given I generate: 5 random UPC numbers and save them starting with: RandomUPC
Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
And I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Soap (Bar, Liquid) for Body
Then I save the product information as: TestCase82536
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
And I edit the testdoc.xlsx, and save its filepath as: Bulktest82536 and verify it contains the UPC data in the table saved as: UPCTable82536
		| UPC           | Quantity | Size | Net Explosive Mass | US: Part Number | US: Item Number | GP: Part Number | SP: Part Number | TG: DPCI    | HD: OMSID | CT: Item Number   |
		| <RandomUPC1>  | 1        | 32   | 1.22               | 00AA01          | 2001            | 1111            | F0001           | 111-22-0001 | 100000001 | 123-1234,123-1230 |
		| <RandomUPC1>  | 2        | 32   | 2.33               | 00BB02          | 2002            | 1112            | G0002           | 111-22-0002 | 100000002 | 123-1234,123-1231 |
		| <RandomUPC2>  | 3        | 32   | 3.44               | 00CC03          | 2003            | 1113            | H0003           | 111-22-0003 | 100000003 | 123-1234,123-1232 |
		| <RandomUPC2>  | 4        | 32   | 4.55               | 00DD04          | 2004            | 1114            | I0004           | 111-22-0004 | 100000004 | 123-1234,123-1233 |
		| <RandomUPC3>  | 5        | 32   | 5.66               | 00EE05          | 2005            | 1115            | J0005           | 111-22-0005 | 100000005 | 123-1234,123-1234 |
		| <RandomUPC4>  | 6        | 32   | 6.77               | 00FF06          | 2006            | 1116            | K0006           | 111-22-0006 | 100000006 | 123-1234,123-1235 |
		| <RandomUPC5>  | 7        | 32   | 7.88               | 00GG07          | 2007            | 1117            | L0007           | 111-22-0007 | 100000007 | 123-1234,123-1236 |
Then I click the 'Upload UPCs' button and upload the file saved as: Bulktest82536
Then I confirm that Add Multiple UPC popup appears and the values are the same as the UPC Upload document saved in the Table called: UPCTable82536
Then In the Add Multiple dialog box I select all UPCs
Given I confirm the Inactivity popup is displayed after waiting 15 minutes accurate to the nearest 2 minutes
Then Click Yes on the inactivity popup
Then I confirm the Inactivity pop is closed
#Then I confirm that Add Multiple UPC popup appears and the values are the same as the UPC Upload document saved in the Table called: UPCTable82536
#Given I confirm the Inactivity popup is displayed after waiting 15 minutes accurate to the nearest 2 minutes
#Then Click No on the inactivity popup
#And the landing page should load

@Timeout2
@TReVorId:23420
Scenario: [Timeout Test] Mass Upload UPCs Popup, TimeoutFeature Works Correctly 
Given I generate: 5 random UPC numbers and save them starting with: RandomUPC
Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
And I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Soap (Bar, Liquid) for Body
Then I save the product information as: TestCase82536
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
And I edit the testdoc.xlsx, and save its filepath as: Bulktest82536 and verify it contains the UPC data in the table saved as: UPCTable82536
		| UPC           | Quantity | Size | Net Explosive Mass | US: Part Number | US: Item Number | GP: Part Number | SP: Part Number | TG: DPCI    | HD: OMSID | CT: Item Number   |
		| <RandomUPC1>  | 1        | 32   | 1.22               | 00AA01          | 2001            | 1111            | F0001           | 111-22-0001 | 100000001 | 123-1234,123-1230 |
		| <RandomUPC1>  | 2        | 32   | 2.33               | 00BB02          | 2002            | 1112            | G0002           | 111-22-0002 | 100000002 | 123-1234,123-1231 |
		| <RandomUPC2>  | 3        | 32   | 3.44               | 00CC03          | 2003            | 1113            | H0003           | 111-22-0003 | 100000003 | 123-1234,123-1232 |
		| <RandomUPC2>  | 4        | 32   | 4.55               | 00DD04          | 2004            | 1114            | I0004           | 111-22-0004 | 100000004 | 123-1234,123-1233 |
		| <RandomUPC3>  | 5        | 32   | 5.66               | 00EE05          | 2005            | 1115            | J0005           | 111-22-0005 | 100000005 | 123-1234,123-1234 |
		| <RandomUPC4>  | 6        | 32   | 6.77               | 00FF06          | 2006            | 1116            | K0006           | 111-22-0006 | 100000006 | 123-1234,123-1235 |
		| <RandomUPC5>  | 7        | 32   | 7.88               | 00GG07          | 2007            | 1117            | L0007           | 111-22-0007 | 100000007 | 123-1234,123-1236 |
Then I click the 'Upload UPCs' button and upload the file saved as: Bulktest82536
Then I confirm that Add Multiple UPC popup appears and the values are the same as the UPC Upload document saved in the Table called: UPCTable82536
Then In the Add Multiple dialog box I select all UPCs
Given I confirm the Inactivity popup is displayed after waiting 15 minutes accurate to the nearest 2 minutes
Then I Look for the Landing Page for: 16 minutes
#Then I wait for 960 seconds
#And the landing page should load

@Timeout3
@TReVorId:23421
Scenario: [Timeout Test] Warning Alert- Inactivity popup- Inactivity Popup can be interacted with
Given I log in with the account saved in TReVor as: PremiumSubscriptionAccount
And I call Shared Step 75130 - Bulk Actions - Select Forward Product Registration
Given I wait for 1200 seconds
And I take a ScreenShot
#Then I Check that both an alert and inactivity prompt are on screen
#Given I confirm the Inactivity popup is displayed after waiting 15 minutes accurate to the nearest 2 minutes and no screenshot is taken
##Then I Look for an Alert for a max: 1 minutes
#Then I Look for an Alert for a max: 10 Seconds
#Then I confirm the Inactivity pop is open but dont take a screenshot
#Then Click Yes on the inactivity popup but dont take a screenshot
#Then I confirm the Inactivity pop is closed but dont take a screenshot


@Timeout4
@TReVorId:23422
Scenario: [Timeout Test] Warning Alert- Inactivity popup- TimeoutFeature Works Correctly 
Given I log in with the account saved in TReVor as: PremiumSubscriptionAccount
And I call Shared Step 75130 - Bulk Actions - Select Forward Product Registration
Given I wait for 1200 seconds
Then I Check The landing page has loaded, and report if an Alert and Inactivity Prompt are open if it is not loaded
#Given I confirm the Inactivity popup is displayed after waiting 15 minutes accurate to the nearest 2 minutes
#Then I Look for an Alert every minute for: 4 minutes and when an alert is found I wait for the landing page for: 20 minutes

@Timeout5
@TReVorId:23423
Scenario: [Timeout Test] Add Case UPC Popup- Inactivity popup-Inactivity Popup can be interacted with
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
	Given I click the Add Case UPC button under the Select UPCs tab
	Given I confirm the Inactivity popup is displayed after waiting 15 minutes accurate to the nearest 2 minutes
	Then Click Yes on the inactivity popup
	Then I confirm the Inactivity pop is closed	

@Timeout6
@TReVorId:23424
Scenario: [Timeout Test] Add Case UPC Popup- Inactivity popup- TimeoutFeature Works Correctly
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
	Given I click the Add Case UPC button under the Select UPCs tab
	Given I wait for 1200 seconds
	Then I Check The landing page has loaded, and report if an Alert and Inactivity Prompt are open if it is not loaded
#
#	Given I confirm the Inactivity popup is displayed after waiting 15 minutes accurate to the nearest 2 minutes
#	Then I Look for the Landing Page every minute for a max of: 16 minutes
#	Then I Look for an Alert every minute for a max of: 4 minutes

	#Then I wait for 960 seconds
	#And the landing page should load
	#



	
