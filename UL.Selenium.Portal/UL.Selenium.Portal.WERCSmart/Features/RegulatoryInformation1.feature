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
@run_RegulatoryInformation1
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:ProductInformation
@PhysicalAndChemicalProp
@StepsPrototype
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:NewProduct
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:TheProduct
@Ingredients
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:InventoryStatusProp65
Feature: Regulatory Information 1

@TestCase:85693
Scenario: [85693] Regulatory Information 1 - validation

	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load

	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Then in the New Product page, I click Continue

	#Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk
	Then I should be on the The Product Page
	And In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Chalk_#85693
	And In the Product Section, set the option in section: 'Type of Product (select)' to: Chalk
	Then in the The Product page, I click Continue

	Then I save the product information as: TestCase85693

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

	#Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
	#	| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
	#	| Water         | 100     | false               | false       |            |
	Then I should see the Ingredients Page
	And In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	| component name | Water       | 100     | False               | False         |             |
	Then in the Ingredients page, I click Continue

	Then I should see the Inventory Status, Prop 65 (US) Page
	And in the Inventory Status, Prop 65 (US) page, I click Continue
	Then In the Inventory Status, Prop 65 (US) Section, the section 'U.S. Toxic Substances Control Act (TSCA) status' should display an error message: This is a required field.
	Then In the Inventory Status, Prop 65 (US) Section, the section 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' should display an error message: This is a required field.

	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase85693
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase85693

@TestCase:85695
Scenario: [85695] California Proposition 65 - select Yes - navigation

	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load

	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Then in the New Product page, I click Continue

	#Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk
	Then I should be on the The Product Page
	And In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Chalk_#85695
	And In the Product Section, set the option in section: 'Type of Product (select)' to: Chalk
	Then in the The Product page, I click Continue

	Then I save the product information as: TestCase85695

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

	#Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
	#	| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
	#	| Water         | 100     | false               | false       |            |
	Then I should see the Ingredients Page
	And In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	| component name | Water       | 100     | False               | False         |             |
	Then in the Ingredients page, I click Continue

	Then I should see the Inventory Status, Prop 65 (US) Page
	And In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is exempt from TSCA chemical Inventory listing requirements.
	And In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: Yes
	And In the Inventory Status, Prop 65 (US) Section, the following sections should be displayed:
	| Section                                                                                                                                                                      |
	| Is the need to warn triggered by                                                                                                                                             |
	| How is the exposure warning transmitted? For more information, see Notice of Adoption Article                                                                                |
	| Is your exposure warning compliant with Proposition 65 regulations applicable to products manufactured                                                                       |
	| If the product carries a safe-harbor short-form warning, indicate which of the following is provided:                                                                        |
	| If the product carries a safe-harbor long-form warning, indicate which of the following is used and enter the names of the Proposition 65 chemicals included in the warning: |
	| If the product carries a custom warning, please provide the exact text that is being used:                                                                                   |
	Then In the Inventory Status, Prop 65 (US) Section, for section 'How is the exposure warning transmitted? For more information, see' click the link titled: 'Notice of Adoption Article'
	And In the Inventory Status, Prop 65 (US) Section, switch to the tab titled: 'Notice of Adoption Article'
	Then In the Inventory Status, Prop 65 (US) Section, close the tab titled: 'Notice of Adoption Article'

	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase85695
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase85695


