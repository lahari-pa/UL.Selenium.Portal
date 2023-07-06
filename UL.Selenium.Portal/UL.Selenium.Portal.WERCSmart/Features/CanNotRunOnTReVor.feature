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
@SHA
@UPC
@ignore
@run_CanNotRunOnTReVor
Feature: CanNotRunOnTReVor

#Remove from regression: 2023/05
@ignore
@TestCase:88918
Scenario: [88918] United Stationers Item Number Added in Sample Spread Sheet
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk
	Then I save the product information as: TestCase88918
	Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	And I call Shared Step 29181 (Ingredients - add any chemical) with name: Water
	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	And In the 'Select Retailers' window I select the retailer: Essendant
	And I click continue
	Then I generate a random UPC number and save as: UPC#88918_1
	Then I generate a random UPC number and save as: UPC#88918_2
	Then I generate a random UPC number and save as: UPC#88918_3
	Then I generate a random UPC number and save as: UPC#88918_4
	Then I generate a random UPC number and save as: UPC#88918_5
	Then I generate a random UPC number and save as: UPC#88918_6
	Then I generate a random UPC number and save as: UPC#88918_7
	And I click Sample File link and verify the Upload UPC form and save it as test88918
		| UPC           | Name   | Quantity | Size | Internal SKU | US: Part Number | US: Item Number | GP: Part Number | SP: Part Number | TG: DPCI    | HD: OMSID | CT: Item Number   | Green Good Housekeeping | Green Seal | EPA Safer Choice | Cradle to Cradle | UL Ecologo | EWG Verified | Green Tick | Madesafe | NSF Sustainability Certified |
		| 823973000000  | Saco 1 | 1        | 100  | KS955AR      | 11AB45          | 1001            | 1111            | A0001           | 111-22-0001 | 100000001 | 123-1234,123-1230 | Yes                     |                  |                  |            |              | Yes        |            |          | Yes                          |                
		| 0037600724210 | Saco 2 | 2        | 101  |              | 12AB56          | 1002            | 2222            | B0002           | 111-22-0002 | 100000002 | 123-1234,123-1231 |                         | Yes              |                  |            |              |            | Yes        |          |                              |
		| 978959000000  | Saco 3 | 3        | 102  |              | 12AC67          | 1003            | 3333            | C0003           | 111-22-0003 | 100000003 | 123-1234,123-1232 |                         |                  | Yes              |            |              |            |            |          |                              |
		| 688267000000  | Saco 4 | 4        | 103  | KS956AG      | 12AD89          | 1004            | 4444            | D0004           | 111-22-0004 | 100000004 | 123-1234,123-1233 |                         |                  |                  | Yes        |              |            |            | Yes      |                              |
		| 854911000000  | Saco 5 | 5        | 104  | KS957AT      | 12AF00          | 1005            | 5555            | E0005           | 111-22-0005 | 100000005 | 123-1234,123-1234 |                         |                  |                  |            | Yes          |            |            |          |                              |

	And I edit the testdoc.xlsx, and save its filepath as: Bulktest88918 and verify it contains the UPC data in the table saved as: UPCTable88918, (Base Data Only: false)
		| UPC           | Name     | Quantity | Size | Net Explosive Mass | US: Part Number | US: Item Number | GP: Part Number | SP: Part Number | TG: DPCI    | HD: OMSID | CT: Item Number   | Green Good Housekeeping | Green Seal | EPA Safer Choice | Cradle to Cradle | UL Ecologo | EWG Verified | Green Tick | Madesafe | NSF Sustainability Certified |
		| %UPC#88918_1% | MyChalk1 | 1        | 32   | 1.22               | 00AA01          | 2001            | 1111            | F0001           | 111-22-0001 | 100000001 | 123-1234,123-1230 |                         |            |                  |                  |            |              |            |          |                              |
		| %UPC#88918_2% | MyChalk2 | 2        | 32   | 2.33               | 00BB02          | 2002            | 1112            | G0002           | 111-22-0002 | 100000002 | 123-1234,123-1231 |                         |            |                  |                  |            |              |            |          |                              |
		| %UPC#88918_3% | MyChalk3 | 3        | 32   | 3.44               | 00CC03          | 2003            | 1113            | H0003           | 111-22-0003 | 100000003 | 123-1234,123-1232 |                         |            |                  |                  |            |              |            |          |                              |
		| %UPC#88918_4% | MyChalk4 | 4        | 32   | 4.55               | 00DD04          | 2004            | 1114            | I0004           | 111-22-0004 | 100000004 | 123-1234,123-1233 |                         |            |                  |                  |            |              |            |          |                              |
		| %UPC#88918_5% | MyChalk5 | 5        | 32   | 5.66               | 00EE05          | 2005            | 1115            | J0005           | 111-22-0005 | 100000005 | 123-1234,123-1234 |                         |            |                  |                  |            |              |            |          |                              |
		| %UPC#88918_6% | MyChalk6 | 6        | 32   | 6.77               | 00FF06          | 2006            | 1116            | K0006           | 111-22-0006 | 100000006 | 123-1234,123-1235 |                         |            |                  |                  |            |              |            |          |                              |
		| %UPC#88918_7% | MyChalk7 | 7        | 32   | 7.88               | 00GG07          | 2007            | 1117            | L0007           | 111-22-0007 | 100000007 | 123-1234,123-1236 |                         |            |                  |                  |            |              |            |          |                              |
			Then I click the 'Upload File' button and upload the file saved as: Bulktest88918
	Then I confirm that Add Multiple UPC popup appears and the values are the same as the UPC Upload document saved in the Table called: UPCTable88918
	Then In the Add Multiple dialog box I select all UPCs
	Then I Confirm All UPCs are: Selected
	Then In the Add Multiple dialog box I select the packaging type: <first>
	Then I Check that the type column becomes populated with option: <first>
	Given In the Add Multiple dialog box I click Next
	Then In the Add Multiple dialog box I select all Retailers
	Then I Check if all Retailers are: Selected
	And I check that the Item Number of each Essendant product matches the excel file named: testdoc.xlsx uploaded saved as: UPCTablePath88918
	And I check that the Part Number of each Essendant product matches the excel file named: testdoc.xlsx uploaded saved as: UPCTablePath88918
	Then In the Add Multiple dialog box I click Finish
	And I confirm that Add Multiple UPC popup disappears and the values on the new product screen are the same as the UPC Upload document saved in the Table called: UPCTable88918
	When In the Recipient and Product Details tab, I expand the first UPC
	Then I check that Item Number for retailer Essendant UPC item 1 should match the UPC Upload document saved in the Table called: UPCTable88918
	And I check that Part Number for retailer Essendant UPC item 1 should match the UPC Upload document saved in the Table called: UPCTable88918
	Then I click Continue and should not see an error message
	And In the New Product page I should be on tab: Review and Submit
	When In the New Product page I click tab: Recipient and UPC Details
	And I click the page heading: Universal Product Code (UPC)
	And In the Recipient and Product Details tab, I expand the first UPC
	Then I check that Item Number for retailer Essendant UPC item 1 should match the UPC Upload document saved in the Table called: UPCTable88918
	And I check that Part Number for retailer Essendant UPC item 1 should match the UPC Upload document saved in the Table called: UPCTable88918
	Then I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase88918

	# Failing due to bug 117614

