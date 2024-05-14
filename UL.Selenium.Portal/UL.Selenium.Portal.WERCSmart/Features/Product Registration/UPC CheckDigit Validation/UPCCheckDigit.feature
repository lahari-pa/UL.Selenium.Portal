@Shared
@NewProduct
@UPC
@ProductGrid
@SHA
@Homepage
@ForwardProductRegistration
@PaymentMethods
@StepsPrototype
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:NewProduct
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:ProductInformation
@PhysicalAndChemicalProp
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:OptionalComments
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:DataAcceptance

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
	#And I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I should see the Physical and Chemical Properties Page
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' should be showing the option: Solid
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' confirm option is selected: Solid
	Then In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
	Then In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Then In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
	Then in the Physical and Chemical Properties page I click Continue

	#Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Water
	Given I should see the Ingredients Page
	Then In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	| component name | Water       | 100     |                     |               |             |
	Then in the Ingredients page I click Continue

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
	#And I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test comment
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	#And I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given I should see the Data Acceptance Page
	Then In the Data Acceptance Section, check 'Agreed' checkbox
	Then In the Data Acceptance Section, click 'Accept' button

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

	# Created by Saikiran Chittampally
@TestCase:217214
Scenario: [217214] Ingredient Table - Sum of Ingredients: Decimal Place Maximum is Five
Given I log in with the account saved in TReVor as: ProductAccount
	Then the WERCSmart homepage should load
	#Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Then in the New Product page, I click Continue

	Given I call Shared Step 57561a (The Product - Enter Product Name: Battery Powered Equipment or ToolBattery Powered Equipment or ToolBattery Powered Equipment or ToolBattery Powered Equipment or ToolBattery Powered Equipment or ToolBattery Powered Equipment or ToolBattery Powered Equipment or Tool and select Type of Product): Battery Powered Equipment or Tool 
	Then I save the product information as: TestCase217214
	Given I generate a random UPC number and save as: UPC217214
	Given I call Shared Step 60648 (Product Information - US, No (Direct Ship), No (PL), No (GNFR))
	Given I call Shared Step 104290 (Enter Regulatory Information - TSCA Not Prop 65)
	Given I call Shared Step 48367 (Product Includes Battery > any type)
		| Battery Type | Manufacturer | Quantity of Batteries per Package | Quantity of Batteries to Operate Product |
		| Alkaline     | <any>        | 4                               | 2                                  |
	Given I call Shared Step 104083 Toxicity Characteristics Leaching Procedure TCLP - NO to ALL - NO COPPER LISTED
	And I call Shared Step 71955 (Answer Electronic Equipment questions - Without Cathode Ray - No to all)
	Given I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue) for
	| Retailer  |
	| Walgreens |	
	And I should see the Universal Product Code Page
	Given I click the 'Add Casepack' button
	Given I add the following into the UPC case fields
		| UPC Number          | Container Type | Size | Quantity | Individual Upc Case Pack | Transportation Option |
		| saved as UPC217214   | Cardboard      | 6    | 10      |                          | 4A: steel box         |
	Then I click continue
	Then I see the following product name error message: The Product Name on Label must be up to 200 characters max.
	Then I erase a few characters from the product name to be under the 200 character limit: Battery Powered Equipment or Tool
	Then I click continue	
	Given in the Optional Comments page I click Continue
	#Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given I should see the Data Acceptance Page
	Then In the Data Acceptance Section, check 'Agreed' checkbox
	Then In the Data Acceptance Section, click 'Accept' button

	Given If purchase details are showing click confirm order
	Then In the Thank You screen I click Home
	Then the WERCSmart homepage should load
	Given I call Shared Step 75130 - Bulk Actions - Select Forward Product Registration	
	And I enter the text: saved as TestCase217214 in the 'Search by WPS ID or Product Name' field
	And In the Foward Product Registration Screen I should see product: saved as TestCase217214
	And In the Foward Product Registration Screen I Select the product: saved as TestCase217214
	And I click continue on the Forward Product Registration page
	And In the Forward Product Registration Screen I select the first retailer that does not require additional data and is not: Canadian Tire under Other Retailers and save it as: retailer217214
	And I click continue on the Forward Product Registration page
	Given I call Shared Step (Forwarding - Not PLP - Select Product: TestCase217214 & UPCs step - Edit existing UPC Confirm Product name Battery Powered Equipment or ToolBattery Powered Equipment or ToolBattery Powered Equipment or ToolBattery Powered Equipment or ToolBattery Powered Equipment or ToolBatteryBattery Powered Equipment or ToolBattery Powered Equipment or ToolBattery with error message:The Product Name on Label must be up to 200 characters max. and erase text: Battery)
	And I click the My Products icon in the Navigation Pane
