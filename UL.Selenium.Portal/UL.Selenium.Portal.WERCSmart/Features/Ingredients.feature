@Shared
@LandingPage
@Login
@Homepage
@Signup
@wercsmart
@NewProduct
@ProductSetUp
@ProductGrid
@DataSummarySheet
@UPC
@SHA
@wercsmart
@RetailPartners
@MyIngredients
@CACleaning
@run_Ingredients
@PaymentMethods
@Studio_Header
@Studio
@DeleteActiveProducts
@StepsPrototype
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:NewProduct
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:ProductInformation
@PhysicalAndChemicalProp
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:RegulatoryDocumentsToProvide
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:OptionalComments
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:DataAcceptance
@Ingredients
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:ECOLOGO
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:InventoryStatusProp65
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:TheProduct
@GTINAndUPC
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:PurchaseSummary
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:Summary
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:Retailer
@SafetyDataSheetAuthoring
Feature: Ingredients
(Suite ID: 64740)

Background:

@TestCase:71985
Scenario: [71985] Sorting Cas Number/ Chemical Name Ingredient page
	Given I log in with the account saved in TReVor as: ProductAccount
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Then in the New Product page, I click Continue

	#Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Mulch with Pesticide
	Then I should be on the The Product Page
	And In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Mulch with Pesticide_#71985
	And In the Product Section, set the option in section: 'Type of Product (select)' to: Mulch with Pesticide
	Then in the The Product page, I click Continue

	Then I save the product information as: TestCase71985
	#Given I call Shared Step 57865 (Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
	Given I should see the Product Information Page
	Then In the Product Information Section, set the option in section: 'Which best describes your product, including when FIFRA 25(b) Exempt' to: Product is intended for preventing, destroying, repelling, or mitigating pests (including insects, rodents, mold, virus, bacteria, and other micro-organisms)
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue

	And I set the Secondary Physical State option to: Solid
	And I set the When mixed with an equal amount of water field to: No
	Then in the Physical and Chemical Properties page I click Continue
	##Product Characteristics
	Given I add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Wood chips    | 50.0    | false               | false       |            |
		| RED 4         | 23.0    | false               | false       |            |
		| Clothianidin  | 27.0    | false               | false       |            |
	When In the ingredients table I click Chemical Name to order
	Then In the ingredients table the ingredients should be in the following order
		| Name         |
		| Clothianidin |
		| RED 4        |
		| Wood chips    |
	When In the ingredients table I click Chemical Name to order
	Then In the ingredients table the ingredients should be in the following order
		| Name         |
		| Wood chips   |
		| RED 4        |
		| Clothianidin |
	When In the ingredients table I click CAS Number to order
	Then In the ingredients table the ingredients should be in the following order
		| Name         |
		| RED 4        |
		| Clothianidin |
		| Wood chips   |
	When In the ingredients table I click CAS Number to order
	Then In the ingredients table the ingredients should be in the following order
		| Name         |
		| Wood chips   |
		| Clothianidin |
		| RED 4        |
	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase71985
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase71985
@TestCase:71987
Scenario: [71987] Sorting Percent on Ingredient page
	Given I log in with the account saved in TReVor as: ProductAccount
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Then in the New Product page, I click Continue

	#Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Mulch with Pesticide
		Then I should be on the The Product Page
	And In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Mulch with Pesticide_#71987
	And In the Product Section, set the option in section: 'Type of Product (select)' to: Mulch with Pesticide
	Then in the The Product page, I click Continue

	Then I save the product information as: TestCase71987
	#Given I call Shared Step 57865 (Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
	Given I should see the Product Information Page
	Then In the Product Information Section, set the option in section: 'Which best describes your product, including when FIFRA 25(b) Exempt' to: Product is intended for preventing, destroying, repelling, or mitigating pests (including insects, rodents, mold, virus, bacteria, and other micro-organisms)
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue

	And I set the Secondary Physical State option to: Solid
	And I set the When mixed with an equal amount of water field to: No
	Then in the Physical and Chemical Properties page I click Continue
	Given I add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Wood chips    | 70.0    | false               | false       |            |
		| RED 4         | 5.0     | false               | false       |            |
		| Clothianidin  | 25.0    | false               | false       |            |
	When In the ingredients table I click Percent to order
	Then In the ingredients table the ingredients should be in the following order
		| Name         |
		| RED 4        |
		| Clothianidin |
		| Wood chips   |
	When In the ingredients table I click Percent to order
	Then In the ingredients table the ingredients should be in the following order
		| Name         |
		| Wood chips   |
		| Clothianidin |
		| RED 4        |
	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase71987
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase71987
@TestCase:65469
Scenario: [65469] Ingredients - Select Publicly Disclosed check box - un-check Publicly Disclosed check box- Trade secret is active
	Given I log in with the account saved in TReVor as: ProductAccount
#	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Then in the New Product page, I click Continue

	Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bubble Solution
	Then I save the product information as: TestCase65469
	Given I call Shared Step 59680a (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Given I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
	Given I call Shared Step 65447 Ingredients - Add any chemical - DO Not click Continue
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Water         | 100     | true                | false       |            |
	Then for ingredient: Water the Trade Secret field is disabled
	Given for ingredient: Water I set Public Disclosure checkbox to checked: false
	Then for ingredient: Water the Trade Secret field is enabled
	Then in the Ingredients page I click Continue
	And I should see the Inventory Status, Prop 65 (US) Page
	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase65469
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase65469

@TestCase:65470
Scenario: [65470] Ingredients - Select Trade Secret check box - Un-check Trade Secret check box - Publicly Disclosed & Public Name are active
	Given I log in with the account saved in TReVor as: ProductAccount
#	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Then in the New Product page, I click Continue

	#Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Bubble Solution
	Then I should be on the The Product Page
	And In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Bubble Solution_#65470
	And In the Product Section, set the option in section: 'Type of Product (select)' to: Bubble Solution
	Then in the The Product page, I click Continue

	Then I save the product information as: TestCase65470
	Given I call Shared Step 59680a (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Given I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
	Given I call Shared Step 65447 Ingredients - Add any chemical - DO Not click Continue
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Water         | 100     | false               | true        |            |
	Then for ingredient: Water the Publicly Disclosed field is disabled
	Then for ingredient: Water the Public Name field is disabled
	Given for ingredient: Water I set Trade Secret checkbox to checked: false
	Then for ingredient: Water the Publicly Disclosed field is enabled
	Then for ingredient: Water the Public Name field is enabled
	Then for ingredient: Water I confirm the Public Name selectbox contains names for selection
	Then in the Ingredients page I click Continue
	And I should see the Inventory Status, Prop 65 (US) Page
	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase65470
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase65470


#CLF - this is basically the same as 65470
@TestCase:65459
Scenario: [65459] Ingredients - Select Trade Secret check box - Publicly Disclosed & Public Name are not active
	Given I log in with the account saved in TReVor as: ProductAccount
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Then in the New Product page, I click Continue

	#Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Bubble Solution
	Then I should be on the The Product Page
	And In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Bubble Solution_#65459
	And In the Product Section, set the option in section: 'Type of Product (select)' to: Bubble Solution
	Then in the The Product page, I click Continue

	Then I save the product information as: TestCase65459
	#Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Given I call Shared Step 59680a (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Given I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
	Given I call Shared Step 65447 Ingredients - Add any chemical - DO Not click Continue
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Water         | 100     | false               | true        |            |
	Then for ingredient: Water the Publicly Disclosed field is disabled
	Then for ingredient: Water the Public Name field is disabled
	Then in the Ingredients page I click Continue
	And I should see the Inventory Status, Prop 65 (US) Page
	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase65459
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase65459
@TestCase:65451
Scenario: [65451] Ingredients - Select Publicly Disclosed check box - Public Name is required, trade secret is not required
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
#	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Then in the New Product page, I click Continue

	#Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Bubble Solution

	#Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bubble Solution
	Then I should be on the The Product Page
	And In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Bubble Solution_#65451
	And In the Product Section, set the option in section: 'Type of Product (select)' to: Bubble Solution
	Then in the The Product page, I click Continue

	Then I save the product information as: TestCase65451
	#Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Given I call Shared Step 59680a (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Given I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
	Given I call Shared Step 65447 Ingredients - Add any chemical - DO Not click Continue
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Water         | 100     | true                | false       |            |
	Then for ingredient: Water the Trade Secret field is disabled
	Then in the Ingredients page I click Continue
	Then for ingredient: Water I should see an error below the public name column which reads: Please select Public Name since you agreed on Publicly Disclosed
	Then for ingredient: Water I select Public Name: Water
	Then in the Ingredients page I click Continue
	And I should see the Inventory Status, Prop 65 (US) Page
	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase65451
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase65451
@TestCase:65448
Scenario: [65448] Ingredients - Publicly Disclosed, Trade secret and Public Name are not required fields
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Then in the New Product page, I click Continue

	#Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Bubble Solution
	Then I should be on the The Product Page
	And In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Bubble Solution_#65448
	And In the Product Section, set the option in section: 'Type of Product (select)' to: Bubble Solution
	Then in the The Product page, I click Continue

	Then I save the product information as: TestCase65448
	#Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Given I should see the Product Information Page
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)' to: No
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue

	Given I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
	Given I call Shared Step 65447 Ingredients - Add any chemical - DO Not click Continue
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Water         | 100     | false               | true        |            |
	Given I confirm the following column titles and inputs are displayed in the ingredients table
		| Column              | Input    |
		| Percent             | textbox  |
		| Publicly Disclosed? | checkbox |
		| Trade Secret?       | checkbox |
		| Public Name         | select   |
	Then in the Ingredients page I click Continue
	And I should see the Inventory Status, Prop 65 (US) Page
#	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase65448
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase65448
@TestCase:63321
Scenario: [63321] Product Ingredients contains a third party component that requires updating for public disclosure
	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Then in the New Product page, I click Continue

	Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bubble Solution
	Then I save the product information as: TestCase63321
	#Given I call Shared Step 65511 (Product Information - No Child, No Direct ship, No PL, Click Continue - Happy Path (use in a BCP))
	Given I call Shared Step 59680a (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Given I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
	And I should see the Ingredients Page
	Given I call Shared Step 65447 Ingredients - Add any chemical - DO Not click Continue
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| WPS1351129    | 50      | false               | true        |            |
		| Water         | 50      | false               | true        |            |
	Then in the Ingredients page I click Continue
	Then a Warning popup dialog should appear with the message: Your product contains a 3rd-Party Formula that may need Data Tier Consent, or if Consent has been accepted by the Formulator, has no ingredients that are indicated to be Public. A notification has been provided to the Formulator to revisit their registration and resubmit if necessary. You may continue with your registration. Should the 3rd-Party Formula be revised, your registration will be updated accordingly and revised scoring will occur. No action is required from you.
	And I should see the Inventory Status, Prop 65 (US) Page
	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase63321
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase63321

@TestCase:71291
Scenario: [71291] Product Ingredients contains a third party component that requires updating for public disclosure
	#Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I log in with the account saved in TReVor as: ProductAccount
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Then in the New Product page, I click Continue

#	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Mulch with Pesticide
	Then I should be on the The Product Page
	And In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Mulch with Pesticide_#71291
	And In the Product Section, set the option in section: 'Type of Product (select)' to: Mulch with Pesticide
	Then in the The Product page, I click Continue

	Then I save the product information as: TestCase71291
	#Given I call Shared Step 57865 (Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
	Given I should see the Product Information Page
	Then In the Product Information Section, set the option in section: 'Which best describes your product, including when FIFRA 25(b) Exempt' to: Product is intended for preventing, destroying, repelling, or mitigating pests (including insects, rodents, mold, virus, bacteria, and other micro-organisms)
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue

	And I set the Secondary Physical State option to: Solid
	And I set the When mixed with an equal amount of water field to: No
	Then in the Physical and Chemical Properties page I click Continue
	Given I add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Wood chips    | 75.0    | false               | false       |            |
		| RED 4         | 20.0    | false               | false       |            |
		| Clothianidin  | 5.0     | false               | false       |            |
	Then in the Ingredients page I click Continue
	And I should see the Neonicotinoid Warning Page
	Then I should see an alert with title: Danger & Warning subtitle: This product contains a neonicotinoid pesticide which may adversely affect pollinating bee populations. Text: Presence of this ingredient may limit the sale of this product through a Retailer. Please refer to the EPA website for more information.
	Then on the Neonicotinoid Warning Page I should see a link with text: EPA website which links to page: https://www.epa.gov/pollinator-protection/epa-actions-protect-pollinators
	Then in the Neonicotinoid Warning page I click Continue
	And I should see the Inventory Status, Prop 65 (US) Page
	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase71291
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase71291
@TestCase:74142
Scenario: [74142] Pop up that Informs the regulations the components are associated
	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load
#	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Then in the New Product page, I click Continue

#	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Mascara - Washable
	Then I should be on the The Product Page
	And In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Mascara - Washable_#74142
	And In the Product Section, set the option in section: 'Type of Product (select)' to: Mascara - Washable
	Then in the The Product page, I click Continue

	Then I save the product information as: TestCase74142
	#Given I call Shared Step 57401 (Product Information - US only - No GHS, Not Direct Ship, Not PLP, Not GNFR > Continue - Happy Path)
	Given I should see the Product Information Page
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue
#Given I call Shared Step 57501 (Physical and Chemical Properties - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue - HP) ====== #
Given In the Physical and Chemical Properties Section, set the option in section: 'Primary Physical State' to: Solid
Given In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Bonded, fibrous glass web
Given In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
Given In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
Given I click continue
Given I add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Chlorine      | 100     | false               | false       |            |
	Given I click the Regulated button for ingredient: Chlorine in the Ingredients table
	Then the 'Regulatory List' window opens
	Given I confirm that a list of regulations associated with the component is displayed
	Given I close the Regulatory List window
	Given I navigate to the home page
	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase74142
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase74142

@TestCase:69796
Scenario: [69796] Aerosol Warning Message on Ingredient page
	#Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	#Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Then in the New Product page, I click Continue

	#Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Hair Styling Product - Aerosol and Pump Spray
	Then I should be on the The Product Page
	And In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Hair Styling Product - Aerosol and Pump Spray_#69796
	And In the Product Section, set the option in section: 'Type of Product (select)' to: Hair Styling Product - Aerosol and Pump Spray
	Then in the The Product page, I click Continue

	Then I save the product information as: TestCase69796
	#Given I call Shared Step 57401 (Product Information - US only - No GHS, Not Direct Ship, Not PLP, Not GNFR > Continue - Happy Path)
	Given I should see the Product Information Page
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue
	Then I should see the Physical and Chemical Properties Page
	Given I set the Primary Physical State option to: Aerosol
	Given I set the Secondary Physical State option to: Bag-on-valve (BOV)
	Given I set the pH option to: 5
	Given I set the Select the best Water Solubility option to: Dispersible
	Given I select the first option in section: When the product has a flammable propellant, or contains ingredients with a flash point below 60⁰C then
	Given I click continue
	Given I click continue
	Then I should see an error message: Formulation must total or exceed 100%.
	Given I add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Water         | 80      | false               | false       |            |
	Given I click continue
	Then I should see an error message: Formulation must total or exceed 100%.
	Given I change the percent field to 100
	Given in the Ingredients page I click Continue
	Then I should see the Inventory Status, Prop 65 (US) Page
	Given In the New Product page I click tab: Product Characteristics
	And I click the page heading: Ingredients
	Then I should not see an error message: Formulation must total or exceed 100%.
	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase69796
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase69796

@TestCase:80728
Scenario: [80728] Ingredients - Transparency Ratio - FRAGRANCE component - included in Denominator, not included in Numerator
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Then in the New Product page, I click Continue

	#Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk
	Then I should be on the The Product Page
	And In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Chalk_#80728
	And In the Product Section, set the option in section: 'Type of Product (select)' to: Chalk
	Then in the The Product page, I click Continue

	Then I save the product information as: TestCase80728
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

	Then I should see the Ingredients Page
	And I verify the Transparency Score displays 0%
	And In the Ingredients page I confirm the Publicly Disclosed Transparency score is flagged as a danger
	And I call Shared Step 79436 (Ingredients - Add FRAGRANCE component, Publicly Disclosed = Yes,  Select Public Name) and save ingredient as: shared79436
		| CASNumber | ComponentName                                                                  | Percentage |
		| FRAGRANCE | Fragrance - Awapuhi - Skin sens 1, Repro 2, Aquatic acute 2, Aquatic chronic 2 | 100        |
	And I verify the Transparency Score displays 0%
	And In the Ingredients page I confirm the Publicly Disclosed Transparency score is flagged as a danger
	Then I click the Publicly Disclosed checkbox for ingredient saved as: shared79436
	And I verify the Transparency Score displays 0%
	Given I navigate to the home page
	#And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase80728
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase80728
@TestCase:80720
Scenario: [80720] Ingredients - Transparency Ratio - FLAVOR component - included in Denominator, not included in Numerator
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	#Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Then in the New Product page, I click Continue

#	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk
	Then I should be on the The Product Page
	And In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Chalk_#80720
	And In the Product Section, set the option in section: 'Type of Product (select)' to: Chalk
	Then in the The Product page, I click Continue

	Then I save the product information as: TestCase80720
	#Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Given I should see the Product Information Page
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)' to: No
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue

	Then I should see the Physical and Chemical Properties Page
	#Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I should see the Physical and Chemical Properties Page
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' should be showing the option: Solid
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' confirm option is selected: Solid
	Then In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
	Then In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Then In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
	Then in the Physical and Chemical Properties page I click Continue

	Then I should see the Ingredients Page
	And I verify the Transparency Score displays 0%
	And In the Ingredients page I confirm the Publicly Disclosed Transparency score is flagged as a danger
	Given I call Shared Step 79431 (Ingredients - Add FLAVOR component, Publicly Disclosed = Yes, Select Public Name) and save ingredients as: shared79431
		| CASNumber | ComponentName | Percentage |
		| FLAVOR    | FLAVOR        | 100        |
	And I verify the Transparency Score displays 0%
	And In the Ingredients page I confirm the Publicly Disclosed Transparency score is flagged as a danger
	Given I click the Publicly Disclosed checkbox for ingredient saved as: shared79431
	And I verify the Transparency Score displays 0%
	Given I navigate to the home page
	#And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase80720
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase80720


# Assigned to Paulina Mata
# Created by Paulina Mata
# Test case can be found at the following paths:
# NetProjects10\WercsSmart Portal\WERCSmart\Product Registration\Ingredients
@TestCase:87301
Scenario: [87301] Ingredients - Selecting a Public Label Name Automatically Initiates Publicly Disclosed Indicator
	#Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I log in with the account saved in TReVor as: ProductAccount
	And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
	#And I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Given I should see the Product Information Page
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)' to: No
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue

	#And I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I should see the Physical and Chemical Properties Page
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' should be showing the option: Solid
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' confirm option is selected: Solid
	Then In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
	Then In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Then In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
	Then in the Physical and Chemical Properties page I click Continue

	Given I call Shared Step 65447 Ingredients - Add any chemical - DO Not click Continue
		| ComponentName    | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Sodium hydroxide | 33      | false               | false       |            |
	And I select the first Public Name dropdown option for ingredient: Sodium hydroxide
	And I confirm the Publicly Disclosed checkbox is: checked for ingredient: Sodium hydroxide
	Given I call Shared Step 65447 Ingredients - Add any chemical - DO Not click Continue
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Water         | 33      | false               | false       |            |
	And I click the Trade Secret checkbox for ingredient: Water
	Then for ingredient: Water the Public Name field is disabled
	Then for ingredient: Water the Publicly Disclosed field is disabled
	Given I call Shared Step 65447 Ingredients - Add any chemical - DO Not click Continue
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Boric acid    | 34      | false               | false       |            |
	And I select the first Public Name dropdown option for ingredient: Boric acid
	Then for ingredient: Boric acid the Trade Secret field is disabled
	And for ingredient: Boric acid I select Public Name: Choose...
	And I click the Trade Secret checkbox for ingredient: Boric acid
	Then for ingredient: Boric acid the Public Name field is disabled
	Then for ingredient: Boric acid the Publicly Disclosed field is disabled
	And I navigate to the home page
	And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase87301

# Assigned to Paulina Mata
# Created by Paulina Mata
# Test case can be found at the following paths:
# NetProjects10\WercsSmart Portal\WERCSmart\Product Registration\Ingredients
@jamesnew
@TestCase:84528
Scenario: [84528] Ingredients - Allow to delete multiple ingredients in formulation
	#Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I log in with the account saved in TReVor as: ProductAccount
	And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Soap (Bar, Liquid) for Body
	Then I save the product information as: TestCase84528
	#And I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Given I should see the Product Information Page
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)' to: No
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue

# ====== Given I call Shared Step 57501 (Physical and Chemical Properties - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue - HP) ====== #
Given In the Physical and Chemical Properties Section, set the option in section: 'Primary Physical State' to: Solid
Given In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Bonded, fibrous glass web
Given In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
Given In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
Given I click continue
#And I Start typing in the component box
	#And I Add as many random ingredients as possible
	Given I call Shared Step 65447 Ingredients - Add any chemical - DO Not click Continue
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Boric acid    | 10      | false               | false       |            |
	Given I call Shared Step 65447 Ingredients - Add any chemical - DO Not click Continue
		| ComponentName    | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Sodium hydroxide | 10      | false               | false       |            |
	Given I call Shared Step 65447 Ingredients - Add any chemical - DO Not click Continue
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Bromate       | 10      | false               | false       |            |
	Given I call Shared Step 65447 Ingredients - Add any chemical - DO Not click Continue
		| ComponentName   | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Sodium chloride | 10      | false               | false       |            |
	Given I call Shared Step 65447 Ingredients - Add any chemical - DO Not click Continue
		| ComponentName     | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Potassium sulfate | 10      | false               | false       |            |
	Given I call Shared Step 65447 Ingredients - Add any chemical - DO Not click Continue
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Water         | 50      | false               | false       |            |
	And I click 'Select all' in the Ingredients table
	And I confirm that all ingredients in the table are selected
	And I confirm the 'Delete' button is available in the Ingredients table
	And I deselect the following ingredients:
		| Name            |
		| Water           |
		| Sodium chloride |
		| Boric acid      |
	And I confirm the following ingredients are unselected:
		| Name            |
		| Water           |
		| Sodium chloride |
		| Boric acid      |
	And I confirm the 'Select all' checkbox in the Ingredients table is unchecked
	And I click 'Select all' in the Ingredients table
	And I confirm that all ingredients in the table are selected
	And I click the 'Delete' button in the Ingredients table
	And I confirm the 'Remove selected components' popup is displayed with message: Are you sure you want to remove all selected components?
	And in the modal dialog I click the "YES" button
	And I confirm there are a total of: 0 ingredients in the table
	And I navigate to the home page
	And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase84528

@TestCase:80800
Scenario: [80800] Ingredients - Transparency Ratio - Regular component
	#Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I log in with the account saved in TReVor as: ProductAccount
	And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
	Then I save the product information as: TestCase80800
	And I call Shared Step 85284 - Product Information - US & Canada, Child (No), OSHA (No), DSV (No), PLP (YES), GNFR (No), Continue
	#And I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I should see the Physical and Chemical Properties Page
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' should be showing the option: Solid
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' confirm option is selected: Solid
	Then In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
	Then In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Then In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
	Then in the Physical and Chemical Properties page I click Continue

	And I verify the Transparency Score displays 0%
	And In the Ingredients page I confirm the Publicly Disclosed Transparency score is flagged as a danger
	And call Shared Step 80090 - Ingredients - Add non-generic chemical, set to publicly Disclosed, select public name and save ingredient as: TestCase80800Component
		| CASNumber | ComponentName | Percentage | Publicly Disclosed | Public Name |
		| 108-95-2  | Phenol        | 57         | Yes                | Phenol      |
	And I verify the Transparency Score displays 100%
	And In the Ingredients page I confirm the Publicly Disclosed Transparency score is flagged as a success
	And I edit the first component to show No for Publicly disclosed
	And I verify the Transparency Score displays 0%
	And In the Ingredients page I confirm the Publicly Disclosed Transparency score is flagged as a danger
	And I navigate to the home page
	And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase80800

@TestCase:109230
Scenario: [109230] Ingredients - Proper ingredients and percentages are showing in Summary and Ingredients Table
	#Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I log in with the account saved in TReVor as: ProductAccount
	Given I generate a random UPC number and save as: UPC109230
	#And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Then in the New Product page, I click Continue
	#And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
	Given I should see the The Product Page
	Given In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Chalk
	Given In the Product Section, set the option in section: 'Type of Product (select)' to: Chalk
 	Given in the The Product page I click Continue
	Then I save the product information as: TestCase109230
	#227718 Product Information - Applicable Only to Type of Product:  Chalk (RU000711)
	#Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Given I should see the Product Information Page
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)' to: No
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue
	#225355 Physical and Chemical Properties - Applicable Only to Type of Product:  Chalk (RU000711)
	Given I should see the Physical and Chemical Properties Page
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' should be showing the option: Solid
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' confirm option is selected: Solid
	Then In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
	Then In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Then In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Insoluble in water
	Then in the Physical and Chemical Properties page I click Continue
	#237670 Ingredients - Applicable Only to Type of Product:  Chalk (RU000711) - Scenario:  Testing Different Component(s) and Disclosure(s)
	Given I should see the Ingredients Page
	Then In the Ingredients section, add component with component name: Calcium Carbonate
	Then In the Ingredients Table row with component name: Calcium Carbonate, in Percent column text input enter: 25
	Then In the Ingredients Table row with component name: Calcium Carbonate, in Publicly Disclosed? column set checkbox to checked
	Then In the Ingredients Table row with component name: Calcium Carbonate, in Public Name column select option Calcium Carbonate
	Then In the Ingredients section, add component with component name: Chlorine
	Then In the Ingredients Table row with component name: Chlorine, in Percent column text input enter: 25
	Then In the Ingredients Table row with component name: Chlorine, in Publicly Disclosed? column set checkbox to checked
	Then In the Ingredients Table row with component name: Chlorine, in Public Name column select option Undisclosed Ingredient
	Then In the Ingredients section, add component with component name: Aluminum Oxide
	Then In the Ingredients Table row with component name: Aluminum oxide, in Percent column text input enter: 25
	Then In the Ingredients Table row with component name: Aluminum oxide, in Trade Secret? column set checkbox to checked
	Then In the Ingredients Table row with component name: Aluminum oxide, in Public Name column is disabled
	Then In the Ingredients section, add component with component name: FM6019
	Then In the Ingredients Table row with component name: FM6019, in Percent column text input enter: 25
	Then In the Ingredients Table row with component name: FM6019, in Publicly Disclosed? column set checkbox to checked
	Then In the Ingredients Table row with component name: FM6019, in Public Name column select option FM6019
	Then in the Ingredients page I click Continue
	Then In the Ingredients section, I confirm the popup should be displayed with the following title: Warning and text: Your product contains a 3rd-Party Formula that may need Data Tier Consent, or if Consent has been accepted by the Formulator, has no ingredients that are indicated to be Public. A notification has been provided to the Formulator to revisit their registration and resubmit if necessary. You may continue with your registration. Should the 3rd-Party Formula be revised, your registration will be updated accordingly and revised scoring will occur. No action is required from you.
	Then In displayed modal, click Ok footer button
	#44966 Inventory Status, Prop 65 (US) - TSCA (Complies) / Prop 65 (NO) - (General Shared-Step #2)
	Then I should be on the Inventory Status, Prop 65 (US) Page
	And In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	And In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page, I click Continue
	#238379 Retailer - Add Retailer(s):  WALGREENS - (General Shared-Step)
	Then I should be on the Retailer Page
	And In the Retailer Section, click 'Add Retailers' button
	And In the Select Retailers window, select retailer: Walgreens
	And In the Select Retailers window, click 'Done' button
	Then in the Retailer page, I click Continue
	#Given I call Shared Step 87647 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC109230, container type: Paper bag and size: 2 do not click continue
	Given I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, I click the Add UPC Button
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, for section: 'Provide the product's UPC(s)- including container type and size (ounces)' enter UPC Number: saved as UPC109230 enter Size: 12 and enter Container Type: Plastic bag
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, verify retailer 'WG' is present under the 'Destination Retailers' column
	And in the Global Trade Item Number (GTIN) / Universal Product Code (UPC) page I click Continue
	#And I call Shared Step 78080 (Regulatory Documents to Provide - Upload OSHA SDS)
	Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Yes, I certify that I have an OSHA-compliant SDS for this product and would like to upload it.
	Then In the Regulatory Documents to Provide Section, upload file in section: 'OSHA SDS'
	Then In the Regulatory Documents to Provide Section, for section OSHA SDS button View should exists
	Then In the Regulatory Documents to Provide Section, for section OSHA SDS button Remove should exists
	Then in the Regulatory Documents to Provide page I click Continue
	#214558 Additional Documents to Provide Page (No Upload is Required) - Click Continue (General Shared-Step)
	Given I should see the Additional Documents to Provide Page
	And in the Additional Documents to Provide page I click Continue
	#And I call Shared Step 214559 (Optional Reports and Documents Available for Purchase - No Document Purchase is Required - Click Continue (General Shared-Step))
	Given I should see the Optional Reports and Documents Available for Purchase Page
	Then The statement: • Additional documents are not subject to standard two day turnaround. is displayed
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue
	#238389 Summary Tab - Data Verification of Different Component(s) and Disclosure(s) - Applicable Only to Type of Product:  CHALK (RU000711)
	Given I should see the Data Acceptance Page
	Then In the Data Acceptance Section, click 'Summary' button
	Given I switch to the tab with Data Summary page
	Given In the Summary Page, the 'Type of Product (select)' section should be showing the following value: Chalk
	Then In the Summary page, I confirm the Ingredients table matches the following:
	| CAS Number/ChemicalName | Percent | Publicly Disclosed? | Trade Secret? | INCI Name             |
	| Calcium carbonate       | 25      | Yes                 | No            | Calcium Carbonate     |
	| Chlorine                | 25      | Yes                 | No		      | Undisclosed Ingredient|
	| Aluminum oxide          | 25		| No                  | Yes           | Trade Secret          |
	| FM6019                  | 25      | Yes                 | No            | FM6019                |
	Then In the Summary Page, verify table data for 'Document' section Supplier Uploaded in column File Name showing the value: testdoc.pdf
	Then In the Summary Page, verify table data for 'Document' section Supplier Uploaded in column Actions showing the value: View
	Given I close the tab with Data Summary page
	#Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given I should see the Data Acceptance Page
	Then In the Data Acceptance Section, check 'Agreed' checkbox
	Then In the Data Acceptance Section, click 'Accept' button
	#157174 Purchase Summary - Thank You for Registering Message - Click Home to Continue
	Given The Purchase Summary Page is displayed
	Then In the Purchase Summary page message is displayed with text: Thank you for registering your product on WERCSmart for assessment. The retailers may receive your assessment in approximately two (2) business days, if no delays in processing the assessment, and should no data issues arise.
	Then In the Purchase Summary Page, click the 'Home' button
	Then The home screen should load
	And I filter for the product saved as: TestCase109230
	And I click Row Actions for the first product returned
	And I click on the Row Action: View
	Then I switch to the Data Summary page
	Then In the Summary page, I confirm the Ingredients table matches the following:
	| CAS Number/ChemicalName | Percent | Publicly Disclosed? | Trade Secret? | INCI Name             |
	| Calcium carbonate       | 25      | Yes                 | No            | Calcium Carbonate     |
	| Chlorine                | 25      | Yes                 | No		      | Undisclosed Ingredient|
	| Aluminum oxide          | 25		| No                  | Yes           | Trade Secret          |
	| FM6019                  | 25      | Yes                 | No            | FM6019                |
	#And In the Data Summary page, I confirm that the Ingredients table matches the following:
	#	| CAS Number/ChemicalName | Percent | Publicly Disclosed? | Trade Secret? | INCI Name              |
	#	| Water                   | 100     | Yes                 | No            | Aqua (Water, Eau)      |
	#	| Chlorine                | 100     | No                  | Yes           | Trade Secret           |
	#	| Formaldehyde            | 100     | No                  | No            |                        |
	#	| Sodium                  | 100     | Yes                 | No            | Undisclosed Ingredient |
	#And I close the window that opened
	#And I filter for the product saved as: TestCase109230
	#And I click Row Actions for the first product returned
	#And I click on the Row Action: Update Required
	#Given In the New Product page I click tab: Physical and Chemical Properties
	#And I click the page heading: Ingredients
	#And I confirm that the ingredients table looks as follows:
	#	| CAS Number/ChemicalName | Percent | Publicly Disclosed? | Trade Secret? | INCI Name              |
	#	| Water                   | 100     | Yes                 | No            | Aqua (Water, Eau)      |
	#	| Chlorine                | 100     | No                  | Yes           | Choose...              |
	#	| Formaldehyde            | 100     | No                  | No            | Choose...              |
	#	| Sodium                  | 100     | Yes                 | No            | Undisclosed Ingredient |
	#And I navigate to the home page

@TestCase:110368
Scenario: [110368] Ingredients- Filtered Ingredient Appears on Top of Filter Option
	#Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I log in with the account saved in TReVor as: ProductAccount
	And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	And I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk
	Then I save the product information as: TestCase110368
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

	Then I enter: Formaldehyde as my ingredient in the Ingredients page, and check that the top option on the filter matches my ingredient		
	And I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase110368


@TestCase:95487
Scenario: [95487] Formulation Screen - Ingredients Staying
	#Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I log in with the account saved in TReVor as: ProductAccount
	#Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Then in the New Product page, I click Continue

	And I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk
	Then I save the product information as: TestCase95487
	#Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Given I should see the Product Information Page
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)' to: No
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue

	Given I call Shared Step 37857 (Enter Physical Property - Solid) with the following inputs:
		| Secondary Physical State | Water Solubility |
		| Flaked                   | Soluble in water |
	Then I should see the Ingredients Page
	When in the Ingredients page I click Continue
	Given I add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Water         | 43.0    | false               | false       |            |
	And for ingredient: Water Percentage displayed: 43.0
	When for ingredient: Water I select Public Name: AQUA
	Then for ingredient: Water Public Name displayed: AQUA
	And I confirm the Publicly Disclosed checkbox is: checked for ingredient: Water
	Given for ingredient: Water I set Public Disclosure checkbox to checked: false
	And for ingredient: Water I set Trade Secret checkbox to checked: true
	Then for ingredient: Water the Public Name field is disabled
	#And In the Ingredients page I confirm the Publicly Disclosed Transparency Score has numerator: 0 and denominator: 1
	And I verify the Transparency Score displays 0.00%
	Given for ingredient: Water I set Trade Secret checkbox to checked: false
	And for ingredient: Water I set Public Disclosure checkbox to checked: true
	#Then In the Ingredients page I confirm the Publicly Disclosed Transparency Score has numerator: 1 and denominator: 1
	And I verify the Transparency Score displays 100.00%
	Then I click continue
	#Given I close the current window
	#Given I open a new window
	#Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I log in with the account saved in TReVor as: ProductAccount
	When I filter the products by: Not Yet Submitted
	Given I save the ProductID and Name of the first Product in the grid as: FirstProduct
	When I click Row Actions for the most recent product returned
	Then I click on the Row Action: Edit
	Then the Product Editor page should be loaded
	And In the New Product page I click tab: Product Characteristics
	And I click the page heading: Ingredients
	And the product saved as: FirstProduct should be visible in editor
	#Looks like th issue is with the ingredients page not showing, instead its the product information page
	And In the ingredients table the ingredients should be in the following order
		| Name  |
		| Water |
	And for ingredient: Water Percentage displayed: 0
	Then I enter text: Butane in the component search box
	And I select the component search result with CAS matching text: 106-97-8 and save ingredient as: Butane_95487
	And In the ingredients table the ingredients should be in the following order
		| Name   |
		| Water  |
		| Butane |
	Then I click the Home navigation icon
	When I filter the products by: Not Yet Submitted
	Given I save the ProductID and Name of the first Product in the grid as: FirstProduct
	When I click Row Actions for the most recent product returned
	Then I click on the Row Action: Edit
	Then the Product Editor page should be loaded
	And the product saved as: FirstProduct should be visible in editor
	And In the ingredients table the ingredients should be in the following order
		| Name   |
		| Water  |
		| Butane |
	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase95487
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase95487





@TestCase:133335
Scenario: [133335] Formulation Screen FIFRA and LOLI Validation Message
	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Then in the New Product page, I click Continue

	Given I call Shared Step 57561a (The Product - Enter Product Name: Pesticide Testing Product and select Type of Product): Insecticide - Fogger
	Then I save the product information as: TestCase133335
	Given I should see the Product Information Page
	Given I call Shared Step 105379 Product Information - US, Pesticide No, No OSHA, No DSV, No PL, No GNFR Without Child question
	And I set the Primary Physical State option to: Aerosol
	And I set the Secondary Physical State option to: Liquid spray
	And I check the 'I do not have exact' checkbox for field: pH
	And I set the pH option to: 4 - 6.9
	And I set the When the product has a flammable propellant, or contains ingredients with a flash point below 60⁰C then option to: This product is not classified as D001 or D003 Hazardous Waste under RCRA
	And in the New Product page I click Continue
	# Ingredient Page
	And I should see the Ingredients Page
	Then I add the following ingredients:
		| ComponentName          | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Glutens, corn          | 50      | false               | false       |            |
		| Butane                 | 0.1     | false               | false       |            |
		| Oils, cedarwood, Texan | 49.9    | false               | false       |            |
	Given in the New Product page I click Continue
	Then I confirm there is a popup view titled: Product Contains Ingredients Typical of a Pesticide in the Ingredients page
	Then In the popup view with the following title: Product Contains Ingredients Typical of a Pesticide I confirm I see the following statement in the popup view: The registration ingredient contains information that typically is included in a product that is considered a pesticide under U.S. E.P.A. guidelines or Canada Pest guidelines. The product type you've selected for this registration is not within the scope of pesticide registrations and the ingredient(s) which are typically used in Pesticide or Herbicide registrations is/are:
	Then In the popup view with the following title: Product Contains Ingredients Typical of a Pesticide I confirm I see the following statement in the popup view: If you need to revise your selection for Pesticides, please use the Product Type tab and go to the Product Information section to make your revisions. Or, revise your ingredient information, ensuring accuracy. Should all indications and ingredients be correct and the product is not a pesticide, please indicate below.
	Then I confirm the table in the popup view has the following column titles
		| Titles          |
		| CAS Number      |
		| Name            |
		| Active or Inert |
	Then I confirm the table in the popup view has following column data
		| CAS Number | Name                   | Active or Inert |
		| 106-97-8   | Butane                 | Inert           |
		| 66071-96-3 | Glutens, corn          | Active          |
		| 68990-83-0 | Oils, cedarwood, Texan | Active          |
	Then In the popup view with the following title: Product Contains Ingredients Typical of a Pesticide I confirm I see the following statement in the popup view: If you need to revise your selection for Pesticides, please use the Product Type tab and go to the Product Information section to make your revisions. Or, revise your ingredient information, ensuring accuracy. Should all indications and ingredients be correct and the product is not a pesticide, please indicate below.
	Then I confirm I see a checkbox in the popup view with the following text: The Product Type, Pest Selection, and Ingredients listed are accurate.
	Then In the popup view with the following title: Product Contains Ingredients Typical of a Pesticide I confirm I see the following buttons in the popup view:
		| Button  |
		| Go back |
		| Confirm |
	Then In the popup view with the following title: Product Contains Ingredients Typical of a Pesticide I click the Go back button
	And I should see the Ingredients Page
	Then in page Ingredients Page I should see error: You must either confirm that your product is not a pesticide, change your product details to confirm that it is a pesticide, or change your ingredients to remove the pesticide ingredients.
	Then I click continue
	Then I confirm there is a popup view titled: Product Contains Ingredients Typical of a Pesticide in the Ingredients page
	Then I confirm I check the checkbox in the popup view with the following text: The Product Type, Pest Selection, and Ingredients listed are accurate.
	Then In the popup view with the following title: Product Contains Ingredients Typical of a Pesticide I click the Confirm button
	## Regulatory 1 Page Details
	And I should see the Waste Classification Data Page
	And I click the page heading: Ingredients
	And I click continue
	Then I confirm there is a popup view titled: Product Contains Ingredients Typical of a Pesticide in the Ingredients page
	Then In the popup view with the following title: Product Contains Ingredients Typical of a Pesticide I click the Confirm button
	Given I click the Home navigation icon
	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase133335
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase133335

# Created by Saikiran Chittampally
@TestCase:158853
Scenario: [158853] Ingredient Identifier
	Given I log in with the account saved in TReVor as: ProductAccount
	Then the WERCSmart homepage should load
	#Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Then in the New Product page, I click Continue

	#Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
	Given I should see the The Product Page
	Given In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Chalk
	Given In the Product Section, set the option in section: 'Type of Product (select)' to: Chalk
 	Given in the The Product page I click Continue
	Then I save the product information as: TestCase158853
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
	Then In the Ingredients Section, confirm section: 'Ingredient Reference Number (Optional)' is displayed
	Then In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	| component name | Water       | 100     |                     |               |             |
	Then in the Ingredients page I click Continue

	And I should see the Inventory Status, Prop 65 (US) Page
	And I click the page heading: Ingredients
	And I should see the Ingredients Page
	Then In the Ingredients Section, set the option in section: 'Ingredient Reference Number (Optional)' to: 1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123
	Then in the Ingredients page I click Continue
	Then In the Ingredients Section, confirm for section: 'Ingredient Reference Number (Optional)' error is displayed: This field has a maximum length of 100 characters
	Then In the Ingredients Section, set the option in section: 'Ingredient Reference Number (Optional)' to: test 123 !@#
	Then in the Ingredients page I click Continue
	Then In the Ingredients Section, confirm for section: 'Ingredient Reference Number (Optional)' error is displayed: Enter valid information (The following characters are not allowed: = ; ^ * ¿? !¡ \ ~ [] <> | {} + ® ™)
	Then In the Ingredients Section, set the option in section: 'Ingredient Reference Number (Optional)' to: test 123 @#
	Then in the Ingredients page I click Continue
	#Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Then I should be on the Inventory Status, Prop 65 (US) Page
	And In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	And In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page, I click Continue

	#Given I call Shared Step 150905 (Retailer - NR selected by default)
	Then I should be on the Retailer Page
	And In the Retailer Section, click 'Add Retailers' button
	Then In the Retailer Section is selected retailer: No Retailer/No UPC Product
	And In the Select Retailers window, click 'Done' button
	Then in the Retailer page, I click Continue
	#Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
	Then in the Regulatory Documents to Provide page I click Continue

	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	#Given I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
	#	| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
	#	| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
	Then I should be on the Safety Data Sheet Authoring - Additional Data (Optional) Page
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Personal Protection Equipment Recommended (select)' to: Gloves
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Autoignition Temperature (°C)' enter text: 800
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Minimum Ignition Energy (mJ)' enter text: 99
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Viscosity' enter text: 60
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Appearance' to: Clear
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor' to: Odorless
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor Threshold' to: No data available
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Partition Coefficient' enter text: 10
	Then in the Safety Data Sheet Authoring - Additional Data (Optional) page, I click Continue	Given in the Optional Comments page I click Continue
	#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue
	Given I should see the Data Acceptance Page
	Then In the Data Acceptance Section, click 'Summary' button
	Given I switch to the tab with Data Summary page
	Given In the Summary Page, the 'Ingredient Reference Number (Optional)' section should be showing the following value: test 123 @#
	Given I close the tab with Data Summary page
	#Then I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given I should see the Data Acceptance Page
	Then In the Data Acceptance Section, check 'Agreed' checkbox
	Then In the Data Acceptance Section, click 'Accept' button
	Then I navigate to the home page
	Then the WERCSmart homepage should load

	

# Created by Saikiran Chittampally
@TestCase:209549
Scenario: [209549] Ingredient Table - Sum of Ingredients: Decimal Place Maximum is Five

	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	Given I generate a random UPC number and save as: UPC209549
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Then in the New Product page, I click Continue

	Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
	Then I save the product information as: TestCase209549
	Given I call Shared Step 59680a (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	#Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I should see the Physical and Chemical Properties Page
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' should be showing the option: Solid
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' confirm option is selected: Solid
	Then In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
	Then In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Then In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
	Then in the Physical and Chemical Properties page I click Continue

	And I should see the Ingredients Page
	Then I add the following ingredients:
		| ComponentName | Percent  | PublicallyDisclosed | TradeSecret | PublicName |
		| 471-34-1      | 3.51131  | false               | false       |            |
		| 7440-44-0     | 10.21141 | false               | false       |            |
		| 7732-18-5     | 15.32251 | false               | false       |            |
		| 1317-61-9     | 15.33361 | false               | false       |            |
		| 7778-18-9     | 61.44374 | false               | false       |            |
	Given I click continue
	And I click the page heading: Ingredients
	Then I confirm the total percent of these five ingredients is 105.82258 %
	And I click continue
	#Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Then I should be on the Inventory Status, Prop 65 (US) Page
	And In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	And In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page, I click Continue

	Given I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue) for
		| Retailer  |
		| Walgreens |
	Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC209549, container type: Metal Container and size: 1
	#Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
	Then in the Regulatory Documents to Provide page I click Continue

	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
		| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
	Given in the Optional Comments page I click Continue
	#Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given I should see the Data Acceptance Page
	Then In the Data Acceptance Section, check 'Agreed' checkbox
	Then In the Data Acceptance Section, click 'Accept' button

	And In the Purchase Summary screen I confirm the Purchase Summary header is displayed
	And In the Purchase Summary screen if Product Billing is displayed I click Confirm Order
	And I navigate to the home page
	And I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase209549)
	Given I call Shared Step (SHA > Select Product > Review) for product saved as: TestCase209549
	Given I confirm the Product Data window has opened
	Then I check for the following columns in Formulation
		| CAS Number | Percent  |
		| 471-34-1   | 3.51131  |
		| 7440-44-0  | 10.21141 |
		| 7732-18-5  | 15.32251 |
		| 1317-61-9  | 15.33361 |
		| 7778-18-9  | 61.44374 |
	And I close the current window and switch to the main window in Studio
	Then I click to open the 'My Wercs' menu and select 'Log Out'

# Created by Saikiran Chittampally
@TestCase:207581
Scenario: [207581] Oven Cleaner - Pump Spray - (RU000798) - New Flow Testing
	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	#Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Then in the New Product page, I click Continue

	#Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Oven Cleaner - Pump Sprays
	Then I should be on the The Product Page
	And In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Oven Cleaner - Pump Sprays_#207581
	And In the Product Section, set the option in section: 'Type of Product (select)' to: Oven Cleaner - Pump Sprays
	Then in the The Product page, I click Continue

	Then I save the product information as: TestCase207581
	Given I call Shared Step 118138a Product Information - US, Pesticide No, No OSHA, No DSV, No CA Cleaning ,No PL, No GNFR Without Child question
	Given I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
	Then I should see the Ingredients Page
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName             |
		| 7732-18-5     | 90      | true                | false       | Water                  |
		| 1310-73-2     | 5       | true                | false       | Sodium hydroxide       |
		| 151-21-3      | 5       | true                | false       | Sodium lauryl sulphate |
	#Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Then I should be on the Inventory Status, Prop 65 (US) Page
	And In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	And In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page, I click Continue

	Then I should see the Pesticide Details - U.S. Page
	And I see the following sections
		| Section                                                                  |
		| Product has an Environmental Protection Agency (EPA) Registration Number |
	And The following options should be displayed for section: Product has an Environmental Protection Agency (EPA) Registration Number
		| Option |
		| Yes    |
		| No     |
	Given I click continue
	Then Product has an Environmental Protection Agency (EPA) Registration Number should be showing the error messages: This is a required field.
	Given I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: Yes
	Then I enter the following EPA Pesticide Registration No.: 9402-10
	Given I click continue
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: AL
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: AR
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: CO
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: DC
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: FL
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: HI
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: ID
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: IL
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: IN
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: KS
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: KY
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: LA
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: ME
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: MI
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: MN
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: MT
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: NH
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: NJ
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: NM
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: NY
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: OH
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: OR
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: PA
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: PR
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: RI
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: TN
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: TX
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: UT
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: VA
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: VT
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: WV
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: WY
	Then I click continue
	And I should see the Transportation Details 1 Page
	And I set the Product is Regulated for Transport field to: Yes
	And I set the Select all modes of transport that you've classified the product for field to: DOT
	And I select option: Shipping with limited quantity under section: Select all modes of transport that you've classified the product for and subsection: DOT
	And I set the Select all modes of transport that you've classified the product for field to: IMDG
	And I select option: Shipping with limited quantity under section: Select all modes of transport that you've classified the product for and subsection: IMDG
	And I click continue
	And I set the UN Number field to: UN1719
	And I set the Technical Name (if applicable) option to: SODIUM HYDROXIDE
	And I set the Packing Group (select) option to: II
	And I click continue
	And I should see the International Marine (IMDG) Classification Page
	And I check the checkbox with description: Copy information from my U.S. Department of Transportation data
	And UN Number should be showing the value: UN1719
	And Proper Shipping Name should be showing the value: Caustic alkali liquid, n.o.s.
	And Technical Name (if applicable) should be showing the value: SODIUM HYDROXIDE
	And Hazard Class (select) should be showing the value: 8
	And Packing Group (select) should be showing the value: II
	And I click continue
	And I should see the Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB) Page
	And I set the Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations. option to: Yes
	And I set the Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the CARB option to: 50
	And I set the Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the OTC Model Rule option to: 40
	And I set the Would you like to use the VOC percentages entered for all areas (e.g. country, state, local) for comparison? option to: Yes
	And I click continue
	Given I call Shared Step 57801 (Confirm VOC Summary step shown and VOC analysis date is shown - Happy Path)
	Given I set the Your acknowledgement of this registration includes that your product option to: Yes, I Acknowledge
	And I click continue
	#And If ECOLOGO Readiness page is displayed I call Shared Step 57712 - ECOLOGO Readiness Assessment - Not at this time - Continue - Happy Path
	Then I should be on the ECOLOGO Readiness Page
	And In the ECOLOGO Readiness Section, set the option in section: 'Take advantage of Premium Subscription benefits by electing to receive a UL ECOLOGO Readiness Assessment...': to: Not at this time
	Then in the ECOLOGO Readiness page, I click Continue

	Given I call Shared Step 150905 (Retailer - NR selected by default)
	#Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
	Then in the Regulatory Documents to Provide page I click Continue

	Then I should see the Additional Documents to Provide Page
	Then I click continue
	Then Volatile Organic Compounds should be showing the error messages: Document is required: VOC Exemption Letter
	Given I call Shared Step 59042 (Browse for File > select > click Open - Happy Path) for document type: VOC Exemption Letter and file: UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf
	Given I call shared step 65961 (Additional Documents to Provide - Upload Full Product Label - Continue.
	Then I should see the Optional Reports and Documents Available for Purchase Page
	Given I click continue
	Given I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Personal Protection Equipment | Appearance | Autoignition Temperature | Minimum Ignition Energy | Odor   | Odor Threshold | Partition Coefficient | Viscosity |
		| Mask                          | Brown      | 2                        | 2                       | Banana | Not applicable | 2                     | 2         |
	
	Then I should see the Optional Comments Page
	Given I click continue
	Given In the Data Acceptance page I select Agreed
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Oven Cleaner - Pump Sprays
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase207581
