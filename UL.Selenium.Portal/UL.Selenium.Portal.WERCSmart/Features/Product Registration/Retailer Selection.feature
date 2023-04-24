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
@run_RetailerSelection
@UPC
@PaymentMethods
@SelectRetailers 

Feature: Retailer Selection

@ignore
@TestCase:78933
Scenario: [78933] Select Retailers - Show List View
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Soap (Bar, Liquid) for Body
	Then I save the product information as: TestCase78933
	Given I call Shared Step 63860 (Product Information - US, No(child), No(OSHA), No(DSV), Yes(PLP), No(GNFR))
	Given I call Shared Step 57501 (Physical and Chemical Properties - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue)
	# Failing on 'child' question.
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Chlorine      | 100     | false               | false       |            |
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
	Then the 'Select Retailers' window appears
	Given I click the List view retailers option in the Select Retailers popup
	Then I confirm that retailers are displayed in list view with checkboxes next to each
	Given I select the following retailers in the Select Retailers popup list view:
		| Retailer                   |
		| CVS                        |
		| Staples                    |
		| No Retailer/No UPC Product |
	Given I click Done in the Select Retailers popup
	Then The selected retailers on the Retailer page should be:
		| Retailer                   |
		| CVS                        |
		| Staples                    |
		| No Retailer/No UPC Product |
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase78933


@ignore
@TestCase:78936
Scenario: [78936] Select Retailers - Show Logo Tile View
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Soap (Bar, Liquid) for Body
	Then I save the product information as: TestCase78936
	Given I call Shared Step 63860 (Product Information - US, No(child), No(OSHA), No(DSV), Yes(PLP), No(GNFR))
	Given I call Shared Step 57501 (Physical and Chemical Properties - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue)
	# Failing on 'child' question
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Chlorine      | 100     | false               | false       |            |
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
	Then the 'Select Retailers' window appears
	Given I click the Logo tile view retailers option in the Select Retailers popup
	Then I confirm that retailers are displayed in tile view with checkboxes next to each
	Given In the 'Select Retailers' window I select the retailer: Petco
	Then The selected retailers on the Retailer page should be:
		| Retailer                   |
		| Petco                      |
		| No Retailer/No UPC Product |
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase78936

@TestCase:78937
Scenario: [78937] Select Retailers - Select All
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk
	Then I save the product information as: TestCase78937
	Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Chlorine      | 100     | false               | false       |            |
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Then the 'Select Retailers' window appears
	Given I click the Select all retailers option in the Select Retailers popup
	Then all retailers are selected in the Select Retailers window
	Given I save all retailers in the Select Retailers window in alphabetical order as: AllSelectRetailers78937
	Given I click Done in the Select Retailers popup
	Then the selected retailers on the Retailer page should match the retailer list saved as AllSelectRetailers78937
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase78937

@ignore
@TestCase:85276
Scenario: [85276] Select Retailers - Errors highlighted
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Soap (Bar, Liquid) for Body
	And I should see the Product Information Page
	And I should see following statement: Select countries the product may be sold in
	And I should see following statement: Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)
	And I should see following statement: Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)
	And I should see following statement: Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.
	Given I set all product information options to No
	Given in the Product Information page I click Continue
	Given I call Shared Step 57501 (Physical and Chemical Properties - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue - HP)
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
	And I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
	Given I click 'Add Retailers' in the Retailers page
	Given I click the Select all retailers option in the Select Retailers popup
	Then all retailers are selected in the Select Retailers window
	Given I click Done in the Select Retailers popup
	Given I click continue
	Then I confirm I see error messages for the following retailers
		| Retailer            |
		| O'Reilly            |
		| Sears/K-Mart        |
		| Wal-Mart/SAM'S CLUB |

@TestCase:96708
Scenario: [96708] Beverage RU - No Walmart
	Given I generate a random UPC number and save as: UPC96708
	And I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	# And I Enter "Juice and Juice Drinks" in Type of Product smart search field
	And I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Juice and Juice Drinks
	Then I save the product information as: TestCase96708
	# I Record the entry you select for Water Solubility
	#: WAS NOT USED
	Given I call Shared Step 69687 (Product Information - US, No(PL))
	And I call Shared Step 70675 (Physical and Chemical Properties - Liquid Only - With Water Solubility - Enter all data - Continue)
	# I think this was the step that was needed.
	And I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	And I call Shared Step 49818 (Beverage Regulatory Details)
	# I Confirm on the Select Retailer popup that Walmart is not available.
	# I Close popup
	Given I click 'Add Retailers' in the Retailers page
	Then I check that Walmart and all of its affiliates are not available
	Then I navigate to the home page
	And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase96708
	# Then I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase96708

@TestCase:136057
Scenario: [136057] Select Retailers - Removing Retailer(s) Selected
	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): chalk
	Then I save the product information as: TestCase1234
	Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	And I call Shared Step 29181 (Ingredients - add any chemical) with name: Calcium
	And I call Shared Step 132370 (Waste Classification Data - TSCA (Random) - Prop 65 (No) - Continue - Happy Path)
	Given I select the following retailers in the Select Retailers popup list view:
		| Retailer              |
		| CVS                   |
		| Dollar General        |
		| Family Dollar         |
		| Dick's Sporting Goods |
		| Amazon                |
		| Best Buy              |
	Given I click Done in the Select Retailers popup
	And The selected retailers on the Retailer page should be:
		| Retailer                   |
		| CVS                        |
		| Dollar General             |
		| Family Dollar              |
		| Dick's Sporting Goods      |
		| Amazon                     |
		| Best Buy                   |
		| No Retailer/No UPC Product |
	Then I select the following retailers in the Retailer page
		| Retailers      |
		| CVS            |
		| Dollar General |
	Then I click the delete icon in the Retailer page
	And The selected retailers on the Retailer page should not be:
		| Retailer              |
		| CVS                   |
		| Dollar General        |
	Given I click 'Add Retailers' in the Retailers page
	Then The following retailers in the Select Retailers popup list view should not be selected
		| Retailers      |
		| CVS            |
		| Dollar General |
	Given I click Done in the Select Retailers popup
	Given I click continue
	And I click the 'Add' button
	And I confirm that retailer "CV" is not present under the 'Destination Retailers' column in the UPC table
	And I confirm that retailer "DG" is not present under the 'Destination Retailers' column in the UPC table
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase1234

@TestCase:133311
Scenario: [133311] Retailer Private Label List Appear in Alphabetical Order
	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): chalk
	Given I call Shared Step 63860 (Product Information - US, No(child), No(OSHA), No(DSV), Yes(PLP), No(GNFR))
	Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| CASNumber | ComponentName | Percent | PublicallyDisclosed | PublicName | TradeSecret |
		|           | calcium       | 100     |                     |            |             |
	Given I call Shared Step 132370 (Waste Classification Data - TSCA (Random) - Prop 65 (No) - Continue - Happy Path)
	Then In the 'Select Retailers' window I select the retailer: Albertsons Companies
	Then I confirm that the product names from the drop down for: Indicate full name of product, as sold, via this retailer (e.g. Private Label Aspirin) for Albertsons Companies appear in alphabetical order
	Then I select the following retailers in the Retailer page
		| Retailers            |
		| Albertsons Companies |
	Then I click the delete icon in the Retailer page
	Then In the 'Select Retailers' window I select the retailer: Wal-Mart/SAM'S CLUB
	Then I confirm that the product names from the drop down for: Indicate full name of product, as sold, via this retailer (e.g. Private Label Aspirin) for Wal-Mart appear in alphabetical order

@TestCase:125130
Scenario: [125130] Canadian Tire Available for Selection for Articles
	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Candy, Chewing Gum
	Then I save the product information as: TestCase125130
	And Select countries the product may be sold in should be showing the value: United States
	And I set the Select countries the product may be sold in field to: Canada
	Given I set the Product is a Retailer's Private Label or Brand option to exactly match: No
	Then I click continue
	Given I call Shared Step 104276 (Enter Regulatory Information - TSCA, CEPA, Not Prop 65)
	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Canadian Tire
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase125130

@TestCase:128920
Scenario: [128920] Electronics - Dollar Tree/Family Dollar Retailers Available for Selection
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Stereo Equipment / Radio, Not Portable, No Battery Included
	Then I save the product information as: TestCase128920
	Given I call Shared Step 60935 Product Information - US - Direct Ship - Private Label Only
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I call Shared Step 61449 Toxicity Characteristic Leaching Procedure (TCLP) - select No to all - Click Continue - Happy Path
	Given I set the Contains Circuit Board option to: No
	Given I set the Has a LCD or Plasma Display option to: No
	Then I click continue
	Given I select the following retailers in the Select Retailers popup list view:
		| Retailer                                                 |
		| Dollar Tree Stores, Inc. / Greenbrier International, Inc |
		| Family Dollar                                            |
	Then I click Done on Select Retailers window
	Then I confirm the following retailers are showing in the Retailer page
		| Retailer												   |
		| Dollar Tree Stores, Inc. / Greenbrier International, Inc |
		| Family Dollar                                            |
		| No Retailer/No UPC Product							   |
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase128920

@TestCase:128769
Scenario: [128769] Battery Product - Dollar Tree/ Family Dollar Retailers Available for Selection
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC59273
	Given I delete all products with UPC Number: saved as UPC59273
	Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Alkaline battery
	Then I save the product information as: TestCase59273
	Given I should see the Product Information Page
	Given I call Shared Step 102767 (Product Information (Battery flow - not Lithium) - OSHA (No), DSV (No), PLP (No), GNFR (No))
	Given Primary Physical State should be showing the value: Solid
	Given I set the Secondary Physical State option to: Solid
	Given I set the When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5? option to: No
	Given in the Physical and Chemical Properties page I click Continue
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| CASNumber | ComponentName       | Percent | PublicallyDisclosed | PublicName | TradeSecret |
		|           | Potassium hydroxide | 20.5    | false               |            | false       |
		|           | Zinc chloride       | 9.5     | false               |            | false       |
		|           | Aqua                | 70      | false               |            | false       |
	Given I should see the Formulation > Batteries Page
	Then I set the Consent to Tier 2.1, 2.2, 4.2 Data Uses option to: Granted
	Given I click continue
	Given I call Shared Step 57637 (Regulatory Information 1 - TSCA & CEPA shown, No to PROP 65 - Continue - Happy Path)
	Given I click 'Add Retailers' in the Retailers page
	Given I select the following retailers in the Select Retailers popup list view:
		| Retailer                                                 |
		| Dollar Tree Stores, Inc. / Greenbrier International, Inc |
		| Family Dollar                                            |
	Then I click Done on Select Retailers window
	Then I confirm the following retailers are showing in the Retailer page
		| Retailer												   |
		| Dollar Tree Stores, Inc. / Greenbrier International, Inc |
		| Family Dollar                                            |
		| No Retailer/No UPC Product							   |
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase59273

# Created by Saikiran Chittampally
@TestCase:181949
Scenario: [181949] Single Retailer Checkbox and Hover message

	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk
	Then I save the product information as: TestCase181949
	Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Propane
	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Then I should see the Retailer Page
	Then I confirm for the checkbox in Retailer page : Registration is for a Single Retail Recipient (No Retailer +1) and will use Single-Retail Subscription program
	Then I confirm the message on retailers page : Single-Retailer subscription permits the registration to be part of an annual subscription that permits only one (1) active retailer + "No Retailer" to be associated to a product registration. The Single-Retailer registration is not permitted to have more than ten (10) active GTIN/UPCs associated. Single-Retailer subscription is a discounted annual rate. You may convert, at a future time, the registration to a Tiered Subscription (formula, enhanced, article) and your annual amount will be pro-rated.
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase181949

# Created by Saikiran Chittampally
@TestCase:182824
Scenario: [182824] Single Retailer - UPC Screen and Retailer Screen Checks 
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk
Given I generate a random UPC number and save as: UPC182824
Given I generate a random UPC number and save as: UPC1828241
Given I generate a random UPC number and save as: UPC1828242
Given I generate a random UPC number and save as: UPC1828243
Given I generate a random UPC number and save as: UPC1828244
Given I generate a random UPC number and save as: UPC1828245
Given I generate a random UPC number and save as: UPC1828246
Given I generate a random UPC number and save as: UPC1828247
Given I generate a random UPC number and save as: UPC1828248
Given I generate a random UPC number and save as: UPC1828249
Given I generate a random UPC number and save as: UPC1828240
Then I save the product information as: TestCase182824
Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Propane
Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Then I should see the Retailer Page
Given I confirm the single retailer checkbox is displayed on the retailer page
Given I confirm if the single retailer checkbox is displayed on the retailer page
And The selected retailers on the Retailer page should be:
		| Retailer                   |
		| No Retailer/No UPC Product |
Then I click 'Add Retailers' in the Retailers page
Given In the 'Select Retailers' window I select the retailer: Amazon
Given I click 'Add Retailers' in the Retailers page
Given I confirm when I select the retailer: Staples the retailers cannot be selected, checkboxes appear grayed out with red crossed out circle
Given I click Done in the Select Retailers popup
Then I click continue
Then I should see the Universal Product Code (UPC) Page
Given I call Shared Step 57960a (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only - Do Not Click Continue) for UPC: saved as UPC182824, container type: Plastic Container and size: 4
Given I call Shared Step 57960a (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only - Do Not Click Continue) for UPC: saved as UPC1828241, container type: Plastic Container and size: 6
Given I call Shared Step 57960a (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only - Do Not Click Continue) for UPC: saved as UPC1828242, container type: Plastic Container and size: 7
Given I call Shared Step 57960a (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only - Do Not Click Continue) for UPC: saved as UPC1828243, container type: Plastic Container and size: 3
Given I call Shared Step 57960a (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only - Do Not Click Continue) for UPC: saved as UPC1828244, container type: Plastic Container and size: 4
Given I call Shared Step 57960a (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only - Do Not Click Continue) for UPC: saved as UPC1828245, container type: Plastic Container and size: 5
Given I call Shared Step 57960a (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only - Do Not Click Continue) for UPC: saved as UPC1828246, container type: Plastic Container and size: 6
Given I call Shared Step 57960a (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only - Do Not Click Continue) for UPC: saved as UPC1828247, container type: Plastic Container and size: 7
Given I call Shared Step 57960a (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only - Do Not Click Continue) for UPC: saved as UPC1828248, container type: Plastic Container and size: 8
Given I call Shared Step 57960a (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only - Do Not Click Continue) for UPC: saved as UPC1828249, container type: Plastic Container and size: 9
And I should not see the following UPC buttons:
		| Option       |
		| Add          |
		| Add Casepack |
		| Upload File  |
	Given in the Universal Product Code (UPC) page I click Continue
	And In the New Product page I click tab: Recipient and UPC Details
	And I click the page heading: Retailer
	Given I click the single retailer checkbox
	And I click Save in The Product Page
	And I should see the following UPC buttons:
		| Option       |
		| Add          |
		| Add Casepack |
	Given I call Shared Step 57960a (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only - Do Not Click Continue) for UPC: saved as UPC1828240, container type: Plastic Container and size: 9
	Then In the Universal Product Code (UPC) page I click Save
	And In the New Product page I click tab: Recipient and UPC Details
	And I click the page heading: Retailer
	Given I confirm if the single retailer checkbox is disabled
	And I click the page heading: Universal Product Code (UPC)
	Given I delete UPC: saved as UPC1828240
	Then In the Universal Product Code (UPC) page I click Save
	And In the New Product page I click tab: Recipient and UPC Details
	And I click the page heading: Retailer
	Given I click the single retailer checkbox
	And I click Save in The Product Page
	Then I should see the Universal Product Code (UPC) Page
	And I should not see the following UPC buttons:
		| Option       |
		| Add          |
		| Add Casepack |
		| Upload File  |
Then In the Universal Product Code (UPC) page I click Save
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase182824

# Created by Saikiran Chittampally
@TestCase:181979
Scenario: [181979] Single Retailer Checkbox Checks

	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk
	Then I save the product information as: TestCase181979
	Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Propane
	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Then I should see the Retailer Page
	Then I confirm the following retailers are showing in the Retailer page
		| Retailer					 |
		| No Retailer/No UPC Product |
	Given I click 'Add Retailers' in the Retailers page
	Then the 'Select Retailers' window appears
	Given I Confirm that on the top right corner the Select All option is NOT available
	Then In the 'Select Retailers' window I select the retailer: Amazon
	Given I click 'Add Retailers' in the Retailers page
	Given I confirm when I select the retailer: Staples the retailers cannot be selected, checkboxes appear grayed out with red crossed out circle
	Given I click Done in the Select Retailers popup
	Given I click the single retailer checkbox
	Then I click 'Add Retailers' in the Retailers page
	Then I Confirm that on the top right corner the Select All option is available
	Given I click the Select all retailers option in the Select Retailers popup
	Then all retailers are selected in the Select Retailers window
	Given I save all retailers in the Select Retailers window in alphabetical order as: AllSelectRetailers181979
	Given I click Done in the Select Retailers popup
	Then the selected retailers on the Retailer page should match the retailer list saved as AllSelectRetailers181979
	Given I confirm if the single retailer checkbox is disabled
	Given I click 'Add Retailers' in the Retailers page
	Then the 'Select Retailers' window appears
	Given I click the Select all retailers option in the Select Retailers popup
	Given I click Done in the Select Retailers popup
	Given I click the single retailer checkbox
	Given I click 'Add Retailers' in the Retailers page
	Then the 'Select Retailers' window appears
	Given I Confirm that on the top right corner the Select All option is NOT available
	Then In the 'Select Retailers' window I select the retailer: Amazon
	Given I click 'Add Retailers' in the Retailers page
	Given I confirm when I select the retailer: Staples the retailers cannot be selected, checkboxes appear grayed out with red crossed out circle
	Given I click Done in the Select Retailers popup
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase181979

	
# Created by Saikiran Chittampally
@TestCase:183582
Scenario: [183582] Behaviors and Restrictions on Duplicate UPCs 
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk
Given I generate a random UPC number and save as: UPC183582
Then I save the product information as: TestCase183582
Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Propane
Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Then I confirm for the checkbox in Retailer page : Registration is for a Single Retail Recipient (No Retailer +1) and will use Single-Retail Subscription program
Given In the 'Select Retailers' window I select the retailer: Target
Given I click continue
Given I call Shared Step 57960a (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only - Do Not Click Continue) for UPC: saved as UPC183582, container type: Plastic Container and size: 4
Then in the Universal Product Code (UPC) page I click Continue
Given I call Shared Step 78080 (Regulatory Documents to Provide - Upload OSHA SDS)
Given in the Additional Documents to Provide page I click Continue
Given in the Optional Reports and Documents Available for Purchase page I click Continue
Given in the Optional Comments page I click Continue
Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
Given In the Thank You screen I click Home
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk
Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Propane
Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Given I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue) for
		| Retailer  |
		| Walgreens |
Given I call Shared Step 57960a (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only - Do Not Click Continue) for UPC: saved as UPC183582, container type: Plastic Container and size: 12
Then in the Universal Product Code (UPC) page I click Continue
And I should see a list style form error with text: There are UPCs that already exists within the WERCSmart database. Please review the UPCs associated within your account, or request to forward a manufacturer's UPCs by creating a new registration as a request from a Distributor. For UPCs that exist within your WERCSmart account, you may use the Report feature to generate a report for your review. UPCs:
And I navigate to the home page
And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase183582


