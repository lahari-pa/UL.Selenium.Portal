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
@run_LithiumBatteryTransportInformation
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:ToxicityCharacteristicLeachingProcedureTCLP
@StepsPrototype
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:InventoryStatusProp65
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:NewProduct
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:NewProduct
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:TheProduct
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:ProductInformation
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:ProductIncludesBattery
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:ElectronicEquipment
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:LithiumBatteryTransportation
Feature: Lithium Battery Transport Information



#Background:
#	Given I verify the following users exist and if not I create them using SHAUser
#		| username    | FirstName | LastName   | Role         | EmailAddress                |
#		| SHAQAAuto16 | QA        | Automation | QA Reviewers | qasha.kxxyxunf@mailosaur.io |

#Removed from regression 2024/03
@ignore
@TestCase:65512
Scenario: [65512] BCP - Contains Lithium Ion installed in product - Lithium Battery Transportation step - question wording and validation
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Camera w/Battery
	Then I save the product information as: TestCase65512

	#Andrew - 65511 should be swapped for 159304
	Given I call Shared Step 159304 (Product Information - US, No(Child), No (DSV), No (PLP))

	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Then I should see the Product Includes Battery Page
	Given I set the Indicate how battery is packaged option to: Installed in the product
	Given I add the following batteries:
		| Battery Type | Manufacturer | Quantity of Batteries per Package | Quantity of Batteries to Operate Product | Saved As            |
		| Lithium Ion  | <any>        | 10                                | 10                                       | lithiumbattery65512 |
	Given I continue to the next screen in the product registration
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

	Given I call Shared Step 58189 (Answer Electronic Equipment questions - With Cathode Ray - No to all)
	Then I should see the Lithium Battery Transportation Page
	And I see the following sections
		| Section                                                                            |
		| For U.S. Department of Transportation (DOT), indicate the transport classification |
	And I should see a total of 3 radio buttons for the section: For U.S. Department of Transportation (DOT), indicate the transport classification
	And The following radio buttons should be displayed for section: For U.S. Department of Transportation (DOT), indicate the transport classification
		| Button                                                                                                                |
		| Meets the requirements of 49CFR173.185(c)(iv) to be transported as non-dangerous goods for road and rail              |
		| Meets the requirements of 49CFR173.185(c)(i) to be transported as non-dangerous goods for road, rail, air, and vessel |
		| Fully-regulated dangerous goods: UN3481, Lithium ion batteries contained in equipment, 9                              |
	And The alert message is displayed with text: Need help? Regulatory services are included in Premium Subscription. Upgrade now!
	And I see the following sections
		| Section                                                  |
		| For Marine transport (IMDG), indicate the classification |
	And I should see a total of 3 radio buttons for the section: For Marine transport (IMDG), indicate the classification
	And The following radio buttons should be displayed for section: For Marine transport (IMDG), indicate the classification
		| Button                                                                                    |
		| Meets requirements of IMDG Special Provision 188 to be transported as non-dangerous goods |
		| Fully-regulated dangerous goods: UN3481, Lithium ion batteries contained in equipment, 9  |
		| None of the above/Not intended for shipment under IMDG                                    |
	And I see the following sections
		| Section                                               |
		| For Air transport (IATA), indicate the classification |
	And I should see a total of 3 radio buttons for the section: For Air transport (IATA), indicate the classification
	And The following radio buttons should be displayed for section: For Air transport (IATA), indicate the classification
		| Button                                                 |
		| Section I                                              |
		| Section II                                             |
		| None of the above/Not intended for shipment under IATA |
	And I see the following sections
		| Section                                                                           |
		| For Canada's Transportation of Dangerous Goods (TDG), indicate the classification |
	And I should see a total of 3 radio buttons for the section: For Canada's Transportation of Dangerous Goods (TDG), indicate the classification
	And The following radio buttons should be displayed for section: For Canada's Transportation of Dangerous Goods (TDG), indicate the classification
		| Button                                                                                       |
		| Meets the requirements of TDG special provision 34 to be transported as non-dangerous goods. |
		| Fully-regulated dangerous goods: UN3481, Lithium ion batteries contained in equipment, 9     |
		| None of the above/Not intended for shipment in Canada                                        |
	Given I click continue
	Then For U.S. Department of Transportation (DOT), indicate the transport classification should be showing the error messages: This is a required field.
	Then For Marine transport (IMDG), indicate the classification should be showing the error messages: This is a required field.
	Then For Air transport (IATA), indicate the classification should be showing the error messages: This is a required field.
	Then For Canada's Transportation of Dangerous Goods (TDG), indicate the classification should be showing the error messages: This is a required field.
	Given I navigate to the home page
	Then The home screen should load
	And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase65512

@TestCase:65523
Scenario: [65523] BCP - Contains Lithium Primary packaged with the product - Lithium Battery Transportation step - question wording and validation

	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load

	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
#	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration '
	Then in the New Product page, I click Continue

	#Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Camera w/Battery
	Then I should be on the The Product Page
	And In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Camera w/Battery_#65523
	And In the Product Section, set the option in section: 'Type of Product (select)' to: Camera w/Battery
	Then in the The Product page, I click Continue

	Then I save the product information as: TestCase65523
	
	#Given I call Shared Step 159304 (Product Information - US, No(Child), No (DSV), No (PLP))
	Given I should see the Product Information Page
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then in the Product Information page I click Continue

	#Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Then I should be on the Inventory Status, Prop 65 (US) Page
	And In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	And In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page, I click Continue

	#Shared Step 61449 (Toxicity Characteristic Leaching Procedure (TCLP) - select NO to all - Click Continue - Happy Path)
	Then I should be on the Product Includes Battery Page
    Then In the Product Includes Battery Section, set the radio option in section: 'Indicate how battery is packaged': to: The battery is shipped with but not included in my product.
	Then In the Product Includes Battery Section enter value Lithium Primary in Battery Type field
	Then In the Product Includes Battery Section enter value <= 1 g in Grams Lithium field
	Then In the Product Includes Battery Section enter value Lithium primary / metal battery -CR1220 (WPS 1558186) in 'Manufacturer' field
	Then In the Product Includes Battery Section enter value 2 in Quantity of Batteries per Package field
	Then In the Product Includes Battery Section enter value 2 in Quantity of Batteries to Operate Product field
	Then in the Product Includes Battery page, I click Continue

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
	And In the Electronic Equipment Section, set the option in section: 'Has a Cathode Ray Tube (CRT)' to: No
	And In the Electronic Equipment Section, set the option in section: 'Has a LCD or Plasma Display' to: No
	Given in the Electronic Equipment page, I click Continue

	Then I should see the Lithium Battery Transportation Page
	Then In the Lithium Battery Transportation Section, for section 'For U.S. Department of Transportation (DOT), indicate the transport classification' confirm that the following options should be displayed:
	| Option                                                                                                                 |
	| Fully-regulated dangerous goods: UN3091, Lithium metal batteries packed with equipment, 9                              |
	| Meets the requirements of 49CFR173.185(c)(iv) to be transported as non-dangerous goods for road and rail               |
	| Meets the requirements of 49CFR173.185(c)(ii) to be transported as non-dangerous goods for road, rail, air, and vessel |
	Then In the Lithium Battery Transportation Section, the text message should be displayed with text: 'Need help? Regulatory services are included in Premium Subscription. Upgrade now!'
	Then In the Lithium Battery Transportation Section, for section 'For Marine transport (IMDG), indicate the classification' confirm that the following options should be displayed:
	| Option                                                                                    |
	| Meets requirements of IMDG Special Provision 188 to be transported as non-dangerous goods |
	| Fully-regulated dangerous goods: UN3091, Lithium metal batteries packed with equipment, 9 |
	| None of the above/Not intended for shipment under IMDG                                    |
	Then In the Lithium Battery Transportation Section, for section 'For Air transport (IATA), indicate the classification' confirm that the following options should be displayed:
	| Option                                                 |
	| Section I                                              |
	| Section II                                             |
	| None of the above/Not intended for shipment under IATA |
	Then In the Lithium Battery Transportation Section, for section 'For Canada's Transportation of Dangerous Goods (TDG), indicate the classification' confirm that the following options should be displayed:
	| Option                                                                                       |
	| Fully-regulated dangerous goods: UN3091, Lithium metal batteries packed with equipment, 9    |
	| Meets the requirements of TDG special provision 34 to be transported as non-dangerous goods. |
	| None of the above/Not intended for shipment in Canada                                        |

	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase65523
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase65523


