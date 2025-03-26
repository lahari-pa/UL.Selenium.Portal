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
@run_ProductCharacteristics
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:ProductInformation
@PhysicalAndChemicalProp
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:NewProduct
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:TheProduct
@StepsPrototype

Feature: Physical and Chemical Properties

@TestCase:31833
Scenario: [31833] Physical and Chemical Properties - Liquid - Validation
	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration '
	Then in the New Product page, I click Continue
	#Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Conditioner
	Given I should see the The Product Page
	Given In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Conditioner
	Given In the Product Section, set the option in section: 'Type of Product (select)' to: Conditioner
 	Given in the The Product page I click Continue
	Then I save the product information as: TestCase31833
	#Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Given I should see the Product Information Page
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)' to: No
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue
	And I should see the Physical and Chemical Properties Page
	Then in the Physical and Chemical Properties page I click Continue
	Then In the Physical and Chemical Properties Section, confirm for section: 'Secondary Physical State' error is displayed: This is a required field.
	Then In the Physical and Chemical Properties Section, confirm for section: 'Relative Density' error is displayed: This is a required field.
	Then In the Physical and Chemical Properties Section, confirm for section: 'pH' error is displayed: This is a required field.
	Then In the Physical and Chemical Properties Section, confirm for section: 'Boiling Point (in Celsius)' error is displayed: This is a required field.
	Then In the Physical and Chemical Properties Section, confirm for section: 'Flash Point (in Celsius)' error is displayed: This is a required field.
	Then In the Physical and Chemical Properties Section, confirm for section: 'Select the best Water Solubility description' error is displayed: This is a required field.
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase31833

@TestCase:31826
Scenario: [31826] Physical and Chemical Properties -  Gas - Validation
	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration '
	Then in the New Product page, I click Continue
	#Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Compressed gas
	Given I should see the The Product Page
	Given In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Compressed gas
	Given In the Product Section, set the option in section: 'Type of Product (select)' to: Compressed gas
 	Given in the The Product page I click Continue
	Then I save the product information as: TestCase31826
	#Given I call Shared Step 57401 (Product Information - US only - No GHS, Not Direct Ship, Not PLP, Not GNFR > Continue - Happy Path)
	Given I should see the Product Information Page
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue
	And I should see the Physical and Chemical Properties Page
	Then In the Physical and Chemical Properties Section, for section: 'Primary Physical State': the following options should be displayed exclusively:
	| Option |
	| Gas    |
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' confirm option is selected: Gas
	Then in the Physical and Chemical Properties page I click Continue
	Then In the Physical and Chemical Properties Section, confirm for section: 'Secondary Physical State' error is displayed: This is a required field.
	Then In the Physical and Chemical Properties Section, confirm for section: 'Select the best Water Solubility description' error is displayed: This is a required field.
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase31826

@TestCase:85157
Scenario: [85157] Physical and Chemical Properties for 'Bonding Agent' Type of Product - Validation
	#Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load
	#Given I call Shared Step 57408 (Create a New Registration via Register New
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration '
	Then in the New Product page, I click Continue
	#Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Bonding agent
	Given I should see the The Product Page
	Given In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Bonding agent
	Given In the Product Section, set the option in section: 'Type of Product (select)' to: Bonding agent
 	Given in the The Product page I click Continue
	Then I save the product information as: TestCase85157
	#Given I call Shared Step 57401 (Product Information - US only - No GHS, Not Direct Ship, Not PLP, Not GNFR > Continue - Happy Path)
	Given I should see the Product Information Page
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue
	#168000 Physical and Chemical Properties - Primary Physical State Validation for 'BONDING AGENT' Type of Product
	And I should see the Physical and Chemical Properties Page
	Then In the Physical and Chemical Properties Section, for section: 'Primary Physical State': the following options should be displayed exclusively:
	| Option  |
	| Aerosol |
	| Gas     |
	| Liquid  |
	| Solid   |
	Then In the Physical and Chemical Properties Section, the confirm section: 'Secondary Physical State' is displayed
	Then In the Physical and Chemical Properties Section, the confirm section: 'Select the best Water Solubility description' is displayed
	#168038 Physical and Chemical Properties - Required Field Validation
	Then in the Physical and Chemical Properties page I click Continue
	Then In the Physical and Chemical Properties Section, confirm for section: 'Primary Physical State' error is displayed: This is a required field.
	Then In the Physical and Chemical Properties Section, confirm for section: 'Secondary Physical State' error is displayed: This is a required field.
	Then In the Physical and Chemical Properties Section, confirm for section: 'Select the best Water Solubility description' error is displayed: This is a required field.
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase85157
