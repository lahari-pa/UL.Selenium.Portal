@Shared
@NewProduct
@UPC
@ProductGrid
@SHA
@Homepage

Feature: UPCCheckDigit


@ignore
@TestCase:169528
Scenario: [169528] UPC Check Digit validations - With Recert
	Given I login into the WERCSmart Portal - Canada has all data account
	Given I generate a random UPC number and save as: goodUPC
	Given I delete all products with UPC Number: saved as goodUPC
	And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
	Then I save the product information as: 169528ProductInfo
	And I call Shared Step 85284 - Product Information - US & Canada, Child (No), OSHA (No), DSV (No), PLP (YES), GNFR (No), Continue
	And I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Water
	And I call Shared Step 57637 (Regulatory Information 1 - TSCA & CEPA shown, No to PROP 65 - Continue - Happy Path)
	And I call Shared Step 85990 - Retailers - PLP - Select one or more retailer and add PL information - Continue
		| Retailer      |
		| Canadian Tire |
	Then I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page
	And I click the 'Add' button
	Then I enter an intentionally bad UPC with the following fields and save bad UPC as badUPC
	| UPC Number      | Container Type | Size | Package Type |
	| saved as badUPC | Cardboard      | 10   | myPkg        |
	Then in the Universal Product Code (UPC) page I click Continue
	And I should see the following error text displayed in the UPC screen: Please ensure your UPC is 12 or 14 digits and contains leading zeroes and check digit
	Then I add the following into the UPC Fields
	| UPC Number       | Container Type | Size | Package Type |
	| saved as goodUPC | Cardboard      | 10   | myPkg        |
	Then in the Universal Product Code (UPC) page I click Continue
	And I call Shared Step 78868 - Regulatory Documents to Provide - US and Canada - Request authoring for both
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	And I call Shared Step 64097 - Additional Documents -> Contact Information - Add any Name, address, phone and emergency phone - Happy Path
	Given I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
		| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
	And I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test comment
	And I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given If purchase details are showing click confirm order
	And I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: 169528ProductInfo)
	Given In the SHA manager grid I see the WPS ID I have saved as product: 169528ProductInfo and its status is: Submitted
	And I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: 169528ProductInfo)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Assigned Status for saved as: 169528ProductInfo)
	Given In the SHA manager grid I see the WPS ID I have saved as product: 169528ProductInfo and its status is: Assigned
	And I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: 169528ProductInfo)
	And I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: 169528ProductInfo)
	And I call Shared Step 78877 - WPS Studio - PD+ - set all data and publish using rule and doc queue - CKLT, NGHS, HSGH (EN and CF) and SBCS for saved as: 169528ProductInfo
	And I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: 169528ProductInfo)
	Given I call Shared Step 59066 (Go to SHA Manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: 169528ProductInfo)
	Given In the SHA manager grid I see the WPS ID I have saved as product: 169528ProductInfo and its status is: Accepted or Completed
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: 169528ProductInfo)
	Then In the SHA manager I search for the Product saved as: TestCase86187 and if its Status is Accepted I set the retailers: to Completed and check the Products Grid
	| Retailer      |
	| Canadian Tire |

	And I call Shared Step 43587 - SHA Manager > Completed Product - Add Recert reason 20 for product saved as: 169528ProductInfo

	And I navigate to the WERCSmart site
	Given I login into the WERCSmart Portal - Canada has all data account
	And I search for the product saved as: 169528ProductInfo
	And I click Row Actions for the first product returned
	And I click on the Row Action: Update Required
	And In the New Product page I click tab: Recipient and UPC Details
	And I click the page heading: Universal Product Code (UPC)
	And In the Recipient and Product Details tab, I expand the first UPC
	And I delete the value in the UPC Number field
	Then I add the following into the UPC Fields
	| UPC Number      | Container Type | Size | Package Type |
	| saved as badUPC | Cardboard      | 10   | myPkg        |
	Then In the Universal Product Code (UPC) page I click Save
	And I should see the following error text displayed in the UPC screen: Please ensure your UPC is 12 or 14 digits and contains leading zeroes and check digit
