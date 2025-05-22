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
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:ProductInformation
@PhysicalAndChemicalProp
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:ToxicityCharacteristicLeachingProcedureTCLP
@StepsPrototype
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:NewProduct
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:InventoryStatusProp65
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:RegulatoryDocumentsToProvide
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:OptionalComments
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:DataAcceptance
@Ingredients
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:Retailer
@RegulatoryInformation3
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:TheProduct
@GTINAndUPC
@SideMenu
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:InventoryStatusProp65
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:ElectronicEquipment

Feature: Retailer Selection

@ignore
@TestCase:78933
Scenario: [78933] Select Retailers - Show List View
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given In the Side Menu, click Labeled Link with Add Product title
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration'
	Given in the New Product page I click Continue
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Soap (Bar, Liquid) for Body
	Then I save the product information as: TestCase78933
	Given I call Shared Step 63860 (Product Information - US, No(child), No(OSHA), No(DSV), Yes(PLP), No(GNFR))
#Given I call Shared Step 57501 (Physical and Chemical Properties - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue - HP)
Given In the Physical and Chemical Properties Section, set the option in section: 'Primary Physical State' to: Solid
Given In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Bonded, fibrous glass web
Given In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
Given In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
Given I click continue
# Failing on 'child' question.
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Chlorine      | 100     | false               | false       |            |
	#Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I should see the Inventory Status, Prop 65 (US) Page
	Then In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	Then In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page I click Continue

	#Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
	Given I should see the Regulatory Information 3 Page
	Then In the Regulatory Information 3 Section, the statement 'Based on the product's recommended use and formulation, this is a possible pharmaceutical waste for California.  Please complete the additional question below to ensure proper classification of this product for the retailer(s).' is displayed
	Then In the Regulatory Information 3 Section, in section: 'Refer to your Product Label.  From the options, select those that appear on the Label.' displayed options are:
	| Option                 |
	| Drug Facts Panel       |
	| Supplement Facts Panel |
	| Nutrition Facts Panel  |
	| None of the Above      |
	Then In the Regulatory Information 3 Section, in section: 'Refer to your Product Label.  From the options, select those that appear on the Label.' click the checkbox option: None of the Above 
	Then In the Regulatory Information 3 Section, the following link: Nutritional and Supplement Labels should be displayed
	Then In the Regulatory Information 3 Section, the following link: Dietary Supplements Label should be displayed
	Then In the Regulatory Information 3 Section, the following link: OTC Drug Facts Label (may include Active Ingredient) should be displayed
	Then in the Regulatory Information 3 page I click Continue
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
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given In the Side Menu, click Labeled Link with Add Product title
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration'
	Given in the New Product page I click Continue
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Soap (Bar, Liquid) for Body
	Then I save the product information as: TestCase78936
	Given I call Shared Step 63860 (Product Information - US, No(child), No(OSHA), No(DSV), Yes(PLP), No(GNFR))
#Given I call Shared Step 57501 (Physical and Chemical Properties - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue - HP)
Given In the Physical and Chemical Properties Section, set the option in section: 'Primary Physical State' to: Solid
Given In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Bonded, fibrous glass web
Given In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
Given In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
Given I click continue
# Failing on 'child' question
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Chlorine      | 100     | false               | false       |            |
	#Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I should see the Inventory Status, Prop 65 (US) Page
	Then In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	Then In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page I click Continue

	#Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
	Given I should see the Regulatory Information 3 Page
	Then In the Regulatory Information 3 Section, the statement 'Based on the product's recommended use and formulation, this is a possible pharmaceutical waste for California.  Please complete the additional question below to ensure proper classification of this product for the retailer(s).' is displayed
	Then In the Regulatory Information 3 Section, in section: 'Refer to your Product Label.  From the options, select those that appear on the Label.' displayed options are:
	| Option                 |
	| Drug Facts Panel       |
	| Supplement Facts Panel |
	| Nutrition Facts Panel  |
	| None of the Above      |
	Then In the Regulatory Information 3 Section, in section: 'Refer to your Product Label.  From the options, select those that appear on the Label.' click the checkbox option: None of the Above 
	Then In the Regulatory Information 3 Section, the following link: Nutritional and Supplement Labels should be displayed
	Then In the Regulatory Information 3 Section, the following link: Dietary Supplements Label should be displayed
	Then In the Regulatory Information 3 Section, the following link: OTC Drug Facts Label (may include Active Ingredient) should be displayed
	Then in the Regulatory Information 3 page I click Continue
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
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given In the Side Menu, click Labeled Link with Add Product title
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration'
	Given in the New Product page I click Continue
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk
	Then I save the product information as: TestCase78937
	#Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Given I should see the Product Information Page
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)' to: No
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue

	#Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I should see the Physical and Chemical Properties Page
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' should be showing the option: Solid
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' confirm option is selected: Solid
	Then In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
	Then In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Then In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
	Then in the Physical and Chemical Properties page I click Continue

	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Water         | 100     | false               | false       |            |
	#Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I should see the Inventory Status, Prop 65 (US) Page
	Then In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	Then In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page I click Continue

	Then the 'Select Retailers' window appears
	Given I click the Select all retailers option in the Select Retailers popup
	Then all retailers are selected in the Select Retailers window
	Given I save all retailers in the Select Retailers window in alphabetical order as: AllSelectRetailers78937
	Given I click Done in the Select Retailers popup
	Then the selected retailers on the Retailer page should match the retailer list saved as AllSelectRetailers78937
	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase78937
	Then In the Side Menu, click Labeled Link with My Products title
	Then In the Product Grid, delete the product saved as: TestCase78937

@ignore
@TestCase:85276
Scenario: [85276] Select Retailers - Errors highlighted
#Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I log in with the account saved in TReVor as: ProductAccount
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given In the Side Menu, click Labeled Link with Add Product title
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration'
	Given in the New Product page I click Continue
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Soap (Bar, Liquid) for Body
	And I should see the Product Information Page
	And I should see following statement: Select countries the product may be sold in
	And I should see following statement: Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)
	And I should see following statement: Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)
	And I should see following statement: Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.
	Given I set all product information options to No
	Given in the Product Information page I click Continue
#Given I call Shared Step 57501 (Physical and Chemical Properties - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue - HP)
Given In the Physical and Chemical Properties Section, set the option in section: 'Primary Physical State' to: Solid
Given In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Bonded, fibrous glass web
Given In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
Given In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
Given I click continue
Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
	#And I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I should see the Inventory Status, Prop 65 (US) Page
	Then In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	Then In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page I click Continue

	#Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
	Given I should see the Regulatory Information 3 Page
	Then In the Regulatory Information 3 Section, the statement 'Based on the product's recommended use and formulation, this is a possible pharmaceutical waste for California.  Please complete the additional question below to ensure proper classification of this product for the retailer(s).' is displayed
	Then In the Regulatory Information 3 Section, in section: 'Refer to your Product Label.  From the options, select those that appear on the Label.' displayed options are:
	| Option                 |
	| Drug Facts Panel       |
	| Supplement Facts Panel |
	| Nutrition Facts Panel  |
	| None of the Above      |
	Then In the Regulatory Information 3 Section, in section: 'Refer to your Product Label.  From the options, select those that appear on the Label.' click the checkbox option: None of the Above 
	Then In the Regulatory Information 3 Section, the following link: Nutritional and Supplement Labels should be displayed
	Then In the Regulatory Information 3 Section, the following link: Dietary Supplements Label should be displayed
	Then In the Regulatory Information 3 Section, the following link: OTC Drug Facts Label (may include Active Ingredient) should be displayed
	Then in the Regulatory Information 3 page I click Continue
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

@TestCase:136057
Scenario: [136057] Select Retailers - Removing Retailer(s) Selected
	#Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	Given I log in with the account saved in TReVor as: ProductAccount
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given In the Side Menu, click Labeled Link with Add Product title
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration'
	Given in the New Product page I click Continue
	#Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): chalk
	Given In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Chalk
	Given In the Product Section, set the option in section: 'Type of Product (select)' to: Chalk
 	Given in the The Product page I click Continue
	Then I save the product information as: TestCase136057
	#Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Given I should see the Product Information Page
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)' to: No
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue
	#Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I should see the Physical and Chemical Properties Page
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' should be showing the option: Solid
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' confirm option is selected: Solid
	Then In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
	Then In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Then In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
	Then in the Physical and Chemical Properties page I click Continue
	#And I call Shared Step 29181 (Ingredients - add any chemical) with name: Calcium
	Given I should see the Ingredients Page
	Then In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	| component name | Calcium       | 100   |                     |               |             |
	Then in the Ingredients page I click Continue
	#Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Then I should be on the Inventory Status, Prop 65 (US) Page
	And In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	And In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page, I click Continue
	Given I should see the Retailer Page
	Then In the Retailer Section, click 'Add Retailers' button
	Then In the Select Retailers window, select retailer: CVS
	Then In the Select Retailers window, select retailer: Dollar General
	Then In the Select Retailers window, select retailer: Family Dollar
	Then In the Select Retailers window, select retailer: Dick's Sporting Goods
	Then In the Select Retailers window, select retailer: Amazon
	Then In the Select Retailers window, select retailer: Best Buy
	Then In the Select Retailers window, click 'Done' button
	And In the Retailer Section, following retailers should be displayed:
		| Retailer                   |
		| CVS                        |
		| Dollar General             |
		| Family Dollar              |
		| Dick's Sporting Goods      |
		| Amazon                     |
		| Best Buy                   |
		| No Retailer/No UPC Product |
	Then In the Retailer Section, check the retailer: Family Dollar
	Then In the Retailer Section, check the retailer: CVS
	Then In the Retailer Section, click 'Delete' icon
	And In the Retailer Section, following retailers should not be displayed:
		| Retailer              |
		| CVS                   |
		| Family Dollar         |
	Then In the Retailer Section, click 'Add Retailers' button
	Then In the Retailer Section is not selected retailer: CVS
	Then In the Retailer Section is not selected retailer: Family Dollar
	Then In the Select Retailers window, click 'Done' button
	Then in the Retailer page I click Continue
	Given I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, I click the Add UPC Button
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, verify retailer 'CV' is not present under the 'Destination Retailers' column
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, verify retailer 'FD' is not present under the 'Destination Retailers' column
	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase1234
	Then In the Side Menu, click Labeled Link with My Products title
	Then I delete the product: TestCase136057

@TestCase:133311
Scenario: [133311] Retailer Private Label List Appear in Alphabetical Order
	#Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	Given I log in with the account saved in TReVor as: ProductAccount
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given In the Side Menu, click Labeled Link with Add Product title
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration'
	Given in the New Product page I click Continue
	#Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): chalk
	Given In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: chalk
	Given In the Product Section, set the option in section: 'Type of Product (select)' to: Chalk
 	Given in the The Product page I click Continue
	Then I save the product information as: TestCase133311
	#Given I call Shared Step 63860 (Product Information - US, No(child), No(OSHA), No(DSV), Yes(PLP), No(GNFR))
	Given I should see the Product Information Page
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)' to: No
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: Yes
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue
	#Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I should see the Physical and Chemical Properties Page
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' should be showing the option: Solid
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' confirm option is selected: Solid
	Then In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
	Then In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Then In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
	Then in the Physical and Chemical Properties page I click Continue
	#Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
	#	| CASNumber | ComponentName | Percent | PublicallyDisclosed | PublicName | TradeSecret |
	#	|           | calcium       | 100     |                     |            |             |
	Given I should see the Ingredients Page
	Then In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	| component name | Water       | 100     |                     |               |             |
	Then in the Ingredients page I click Continue
	#Given I call Shared Step 132370 (Waste Classification Data - TSCA (Random) - Prop 65 (No) - Continue - Happy Path)
	Given I should see the Inventory Status, Prop 65 (US) Page
	Then In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	Then In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page I click Continue
	Given I should see the Retailer Page
	Then In the Retailer Section, click 'Add Retailers' button
	Then In the Select Retailers window, select retailer: Wal-Mart/SAM'S CLUB
	Then In the Select Retailers window, click 'Done' button
	Then In the Retailer Section confirm that the product names from the drop down for: Indicate full name of product, as sold, via this retailer (e.g. Private Label Aspirin) for Wal-Mart appear in alphabetical order
	Then In the Retailer Section, for retailer: Wal-Mart/SAM'S CLUB select 'Select Vendor' option: any
	Then In the Retailer Section, for retailer: Wal-Mart/SAM'S CLUB select 'Indicate full name of product, as sold, via this retailer' option: Equate
	Then in the Retailer page I click Continue
	Then In the Side Menu, click Labeled Link with My Products title
	Then In the Product Grid, delete the product saved as: TestCase133311
	

@TestCase:125130
Scenario: [125130] Canadian Tire Available for Selection for Articles
	#Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	Given I log in with the account saved in TReVor as: ProductAccount
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given In the Side Menu, click Labeled Link with Add Product title
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration'
	Given in the New Product page I click Continue
	#Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Candy, Chewing Gum
	Given In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Candy, Chewing Gum
	Given In the Product Section, set the option in section: 'Type of Product (select)' to: Candy, Chewing Gum
 	Given in the The Product page I click Continue
	Then I save the product information as: TestCase125130
	Given I should see the Product Information Page
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, Check or Uncheck for the section check: Retailers will be selling my product at their store locations in (select either or both) to : Canada
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then in the Product Information page I click Continue
	#Given I call Shared Step 104276 (Enter Regulatory Information - TSCA, CEPA, Not Prop 65)
	Given I should see the Inventory Status, Prop 65 (US) Page
	Given In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	Given In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'Canadian Environmental Protection Act (CEPA) status' to: Compliant with Domestic Substances List (DSL)
	Given in the Inventory Status, Prop 65 (US) page I click Continue
	#Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Canadian Tire
	Given I should see the Retailer Page
	Then In the Retailer Section, click 'Add Retailers' button
	Then In the Select Retailers window, confirm that Canadian Tire is listed as a retailer
	Then In the Select Retailers window, click 'Done' button
	Then in the Retailer page I click Continue
	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase125130
	Then In the Side Menu, click Labeled Link with My Products title
	Then In the Product Grid, delete the product saved as: TestCase125130

@TestCase:128920
Scenario: [128920] Electronics - Dollar Tree/Family Dollar Retailers Available for Selection
	#Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given In the Side Menu, click Labeled Link with Add Product title
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration'
	Given in the New Product page I click Continue
	#Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Stereo Equipment / Radio, Not Portable, No Battery Included
	Given I should see the The Product Page
	Given In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Stereo Equipment / Radio, Not Portable, No Battery Included
	Given In the Product Section, set the option in section: 'Type of Product (select)' to: Stereo Equipment / Radio, Not Portable, No Battery Included
 	Given in the The Product page I click Continue
	Then I save the product information as: TestCase128920
	#Given I call Shared Step 60935 Product Information - US - Direct Ship - Private Label Only
	Given I should see the Product Information Page
	Given In the Product Information Section, set the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' to select: United States
	Given In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Given In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Given in the Product Information page I click Continue
	#Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I should see the Inventory Status, Prop 65 (US) Page
	Then In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	Then In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page I click Continue
	#Given I call Shared Step 61449 Toxicity Characteristic Leaching Procedure (TCLP) - select No to all - Click Continue - Happy Path
	Given I should see the Toxicity Characteristic Leaching Procedure (TCLP) Page
	And In the Toxicity Characteristic Leaching Procedure (TCLP) Section, set the option in section: 'Product has had TCLP testing; Report is available' to: No
	Then In the Toxicity Characteristic Leaching Procedure (TCLP) Section, set the radio option in section: 'Lead': to: No
	Then In the Toxicity Characteristic Leaching Procedure (TCLP) Section, set the radio option in section: 'Mercury': to: No
	Then In the Toxicity Characteristic Leaching Procedure (TCLP) Section, set the radio option in section: 'Silver': to: No
	Then In the Toxicity Characteristic Leaching Procedure (TCLP) Section, set the radio option in section: 'Cadmium': to: No
	Then In the Toxicity Characteristic Leaching Procedure (TCLP) Section, set the radio option in section: 'Chromium': to: No
	Then In the Toxicity Characteristic Leaching Procedure (TCLP) Section, set the radio option in section: 'Barium': to: No
	Then In the Toxicity Characteristic Leaching Procedure (TCLP) Section, set the radio option in section: 'Arsenic': to: No
	Then In the Toxicity Characteristic Leaching Procedure (TCLP) Section, set the radio option in section: 'Selenium': to: No
	Then In the Toxicity Characteristic Leaching Procedure (TCLP) Section, set the radio option in section: 'Copper': to: No
	Given in the Toxicity Characteristic Leaching Procedure (TCLP) page, I click Continue
	#Given I call Shared Step 58189 (Answer Electronic Equipment questions - With Cathode Ray - No to all)
	Given I should see the Electronic Equipment Page
	Then In the Electronic Equipment Section, set the option in section: 'Contains Circuit Board' to: No
	And In the Electronic Equipment Section, set the option in section: 'Has a LCD or Plasma Display' to: No
	Given in the Electronic Equipment page, I click Continue
	Given I should see the Retailer Page
	Then In the Retailer Section, click 'Add Retailers' button
	Then In the Select Retailers window, confirm that Dollar Tree Stores, Inc. / Greenbrier International, Inc is listed as a retailer
	Then In the Select Retailers window, confirm that Family Dollar is listed as a retailer
	Then In the Select Retailers window, select retailer: Dollar Tree Stores, Inc. / Greenbrier International, Inc
	Then In the Select Retailers window, select retailer: Family Dollar
	Then In the Select Retailers window, click 'Done' button
	Then in the Retailer page I click Continue
	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase128920
	Then In the Side Menu, click Labeled Link with My Products title
	Then In the Product Grid, delete the product saved as: TestCase128920

@TestCase:128769
Scenario: [128769] Battery Product - Dollar Tree/ Family Dollar Retailers Available for Selection
#Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC59273
	Given I delete all products with UPC Number: saved as UPC59273
	#Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Then In the Side Menu, click Labeled Link with Add Product title
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration'
	Then in the New Product page, I click Continue

	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Alkaline battery
	Then I save the product information as: TestCase59273
	#Given I call Shared Step 102767 (Product Information (Battery flow - not Lithium) - OSHA (No), DSV (No), PLP (No), GNFR (No))
	Then I should be on the Product Information Page
	And In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No 
	And In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	And In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	And In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page, I click Continue

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
	#Given I call Shared Step 57637 (Regulatory Information 1 - TSCA & CEPA shown, No to PROP 65 - Continue - Happy Path)
	Then I should be on the Inventory Status, Prop 65 (US) Page
	And In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is exempt from TSCA chemical Inventory listing requirements.
	And In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'Canadian Environmental Protection Act (CEPA) status' to: Compliant with Domestic Substances List (DSL)
	And In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No 
	Then in the Inventory Status, Prop 65 (US) page, I click Continue

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
	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase59273
		Then In the Side Menu, click Labeled Link with My Products title
	Then In the Product Grid, delete the product saved as: TestCase59273

# Created by Saikiran Chittampally
@TestCase:181979
Scenario: [181979] Single Retailer Checkbox Checks

	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given In the Side Menu, click Labeled Link with Add Product title
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration'
	Given in the New Product page I click Continue
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk
	Then I save the product information as: TestCase181979
	#Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Given I should see the Product Information Page
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)' to: No
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue

	#Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
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


#	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Then I should be on the Inventory Status, Prop 65 (US) Page
	And In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	And In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page, I click Continue

	Then I should see the Retailer Page
	Then I confirm if the single retailer checkbox is displayed on the retailer page
	And In the Retailer Section is selected retailer: No Retailer/No UPC Product
	And In the Retailer Section, click 'Add Retailers' button


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
	Then I confirm the checkbox Registration is for a Single Retail Recipient (No Retailer +1) and will use Single-Retail Subscription program is present for stand alone batteries in Retailer page
	Given I select all retails in Retailers page table view
	Then I click the delete icon in the Retailer page
	Given I click Done in the Select Retailers popup
	Then I check the checkbox Registration is for a Single Retail Recipient (No Retailer +1) and will use Single-Retail Subscription program
	Given I click 'Add Retailers' in the Retailers page
	Then the 'Select Retailers' window appears
	Given I Confirm that on the top right corner the Select All option is NOT available
	Then In the 'Select Retailers' window I select the retailer: Amazon
	Given I click 'Add Retailers' in the Retailers page
	Given I confirm when I select the retailer: Staples the retailers cannot be selected, checkboxes appear grayed out with red crossed out circle
	Given I click Done in the Select Retailers popup
	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase181979
	Then In the Side Menu, click Labeled Link with My Products title
	Then In the Product Grid, delete the product saved as: TestCase181979

	
# Created by Saikiran Chittampally
@TestCase:183582
Scenario: [183582] Behaviors and Restrictions on Duplicate UPCs 
Given I log in with the account saved in TReVor as: SingleRetailerAccount
Then The home screen should load
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given In the Side Menu, click Labeled Link with Add Product title
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration'
	Given in the New Product page I click Continue
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk
Given I generate a random UPC number and save as: UPC183582
Then I save the product information as: TestCase183582
#Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
Given I should see the Product Information Page
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)' to: No
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue

#Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
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



#Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Then I should be on the Inventory Status, Prop 65 (US) Page
	And In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	And In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page, I click Continue

Then I confirm if the single retailer checkbox is displayed on the retailer page
Given In the 'Select Retailers' window I select the retailer: Target
Given I click continue
Given I call Shared Step 57960a (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only - Do Not Click Continue) for UPC: saved as UPC183582, container type: Plastic Container and size: 4
Then in the Universal Product Code (UPC) page I click Continue
Given I call Shared Step 78080 (Regulatory Documents to Provide - Upload OSHA SDS)
Given in the Additional Documents to Provide page I click Continue
Given in the Optional Reports and Documents Available for Purchase page I click Continue
Given in the Optional Comments page I click Continue
#Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
Given I should see the Data Acceptance Page
	Then In the Data Acceptance Section, check 'Agreed' checkbox
	Then In the Data Acceptance Section, click 'Accept' button

Given In the Thank You screen I click Home
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given In the Side Menu, click Labeled Link with Add Product title
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration'
	Given in the New Product page I click Continue
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk
#Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
Given I should see the Product Information Page
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)' to: No
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue

#Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
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

#Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Then I should be on the Inventory Status, Prop 65 (US) Page
	And In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	And In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page, I click Continue

Given I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue) for
		| Retailer  |
		| Walgreens |
Given I call Shared Step 57960a (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only - Do Not Click Continue) for UPC: saved as UPC183582, container type: Plastic Container and size: 12
Then in the Universal Product Code (UPC) page I click Continue
And I should see a list style form error with text: There are UPCs that already exists within the WERCSmart database. Please review the UPCs associated within your account, or request to forward a manufacturer's UPCs by creating a new registration as a request from a Distributor. For UPCs that exist within your WERCSmart account, you may use the Report feature to generate a report for your review. UPCs:
And I navigate to the home page
And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase183582

# Created by Saikiran Chittampally
@TestCase:184381
Scenario: [184381] My Retail Partners: Data Tier Consent - Hover Messaging 
#Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Given I log in with the account saved in TReVor as: ProductAccount
#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given In the Side Menu, click Labeled Link with Add Product title
Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration'
Given in the New Product page I click Continue


#And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
Given I should see the The Product Page
Given In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Chalk
Given In the Product Section, set the option in section: 'Type of Product (select)' to: Chalk
Given in the The Product page I click Continue
Given I generate a random UPC number and save as: UPC184381
Then I save the product information as: TestCase184381

#Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
Given I should see the Product Information Page
Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
Then In the Product Information Section, set the option in section: 'Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)' to: No
Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
Then in the Product Information page I click Continue

#Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
Given I should see the Physical and Chemical Properties Page
Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' should be showing the option: Solid
Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' confirm option is selected: Solid
Then In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
Then In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
Then In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
Then in the Physical and Chemical Properties page I click Continue

#Then I call Shared Step 29181 (Ingredients - add any chemical) with name: Water
Given I should see the Ingredients Page
Then In the Ingredients section, add the following ingredients:
| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
| component name | Water       | 100     |                     |               |             |

Then in the Ingredients page I click Continue
#Then I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Then I should be on the Inventory Status, Prop 65 (US) Page
And In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
And In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
Then in the Inventory Status, Prop 65 (US) page, I click Continue
Then I should be on the Retailer Page
And In the Retailer Section, click 'Add Retailers' button
And In the Select Retailers window, select retailer: Walgreens
And In the Select Retailers window, click 'Done' button
Then in the Retailer page, I click Continue
Given I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page
Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, I click the Add UPC Button
Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, for section: 'Provide the product's UPC(s)- including container type and size (ounces)' enter UPC Number: saved as UPC184381 enter Size: 12 and enter Container Type: Plastic bag
Then in the Global Trade Item Number (GTIN) / Universal Product Code (UPC) page I click Continue
#Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
Given I should see the Regulatory Documents to Provide Page
Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Yes, I certify that I have an OSHA-compliant SDS for this product and would like to upload it.
Then In the Regulatory Documents to Provide Section, upload file in section: 'OSHA SDS'
Then In the Regulatory Documents to Provide Section, for section OSHA SDS button View should exists
Then In the Regulatory Documents to Provide Section, for section OSHA SDS button Remove should exists
Then in the Regulatory Documents to Provide page I click Continue
Given in the Additional Documents to Provide page I click Continue
Given in the Optional Reports and Documents Available for Purchase page I click Continue
Given in the Optional Comments page I click Continue
#And I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
Given I should see the Data Acceptance Page
Then In the Data Acceptance Section, check 'Agreed' checkbox
Then In the Data Acceptance Section, click 'Accept' button
Then In the Thank You screen I click Home
And I click the Retail Partners icon in the Navigation Pane
Then I should see the following heading Retail Partners
Then I select the retailer: Rite Aid
And I confirm that: Rite Aid requests suppliers of Cleaning, Health & Beauty, OTC (Over-the-Counter), Nutritional Supplements, Artists Supplies, Stationery, Toys and Miscellaneous products to grant Tier 2.1, 2.2, 3 and 4.1 consent. is showing under the Data Consent Tiers heading
And I navigate to the home page
Then The home screen should load



# Created by Saikiran Chittampally
@TestCase:184567
Scenario: [184567] My Products - Single Retailer: Indicator and Hover Message / And "Kit Registrations" removed from Additional Programs
Given I log in with the account saved in TReVor as: SingleRetailerAccount
Then The home screen should load
#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given In the Side Menu, click Labeled Link with Add Product title
Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration'
Given in the New Product page I click Continue
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk
Given I generate a random UPC number and save as: UPC184567
Then I save the product information as: TC184567
#Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
Given I should see the Product Information Page
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)' to: No
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue

#Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
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

#Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Then I should be on the Inventory Status, Prop 65 (US) Page
	And In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	And In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page, I click Continue

Then I confirm if the single retailer checkbox is displayed on the retailer page
Given In the 'Select Retailers' window I select the retailer: Rite Aid
Given I click continue
Given I call Shared Step 57960a (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only - Do Not Click Continue) for UPC: saved as UPC184567, container type: Plastic Container and size: 4
Then in the Universal Product Code (UPC) page I click Continue
Given I call Shared Step 77383 (Regulatory Documents to Provide - Request to Author (Happy Path))
Given in the Additional Documents to Provide page I click Continue
Given in the Optional Reports and Documents Available for Purchase page I click Continue
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
Given In the Thank You screen I click Home
Given I confirm the product: TC184567
Given I confirm that the indicator Single Retailer RA is showing above No Retailer and Rite Aid
Given I confirm that when hover over on the Single Retailer : Single-Retailer Subscription for Rite Aid message is showing
And I should see an option for More Filters
Given I click More Filters in the products grid
Given I Click on the ADDITIONAL PROGRAMS drop down and confirm options should be available under Additional Programs
