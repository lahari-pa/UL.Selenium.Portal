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
@SHA
@run_Pesticides
@UPC
@StepsPrototype
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:NewProduct
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:ProductInformation
@PhysicalAndChemicalProp
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:RegulatoryDocumentsToProvide
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:OptionalComments
@Ingredients
@LiquidCoreProduct
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:PesticideDetailsUS
@AdditionalDocsContactInfo
@RegulatoryInformation3
@Studio
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:InventoryStatusProp65
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:TransportationDetails1
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:DataAcceptance
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:ECOLOGO
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:InventoryStatusProp65
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:TheProduct
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:PesticideDetailsStateRegistration
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:USDepartamentOfTransportationDOT
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:InternationalMarineClassification
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:VOC_OzoneTransportCommission
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:VOC_Summary
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:Retailer
@SafetyDataSheetAuthoring
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:PurchaseSummary
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:AdditionalDocumentsToProvide
@GTINAndUPC
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:Summary
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:Retailer
@SafetyDataSheetAuthoring
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:NeonicotinoidWarning
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:PesticideDetailsCanada
@SideMenu

Feature: Pesticides


@TestCase:62775
Scenario: [62775] Pesticides - Validation of Which one best describes your product question - Prevents, Destroys etc
	#Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load
	#Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Then In the Side Menu, click Labeled Link with Add Product title
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration'
	Then in the New Product page, I click Continue
	#Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Pet Shampoo with Pest Control
	Given In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Pet Shampoo with Pest Control
	Given In the Product Section, set the option in section: 'Type of Product (select)' to: Pet Shampoo with Pest Control
 	Given in the The Product page I click Continue
	Then I save the product information as: TestCase62775
	And I should see the Product Information Page
	Then In the Product Information Section, confirm the question: 'Which best describes your product, including when FIFRA 25(b) Exempt' is displayed
	Then In the Product Information Section, confirm following options should be exclusively displayed for section: 'Which best describes your product, including when FIFRA 25(b) Exempt'
		| Option                                                                                                                                                                               |
		| Product is intended for preventing, destroying, repelling, or mitigating pests (including insects, rodents, mold, virus, bacteria, and other micro-organisms)                        |
		| Product is intended for use as a plant regulator (controls growth), defoliant (removes leaves), or desiccant (dehydrates plants to control growth)                                   |
		| Product is not a pesticide and does not make or imply a pesticidal claim on the labeling or in the product description (ex. kills, sterilizes, disinfects, sanitizes, antimicrobial) |
 	Given in the Product Information page I click Continue
	Then In the Product Information Section, the section: 'Which best describes your product, including when FIFRA 25(b) Exempt' should be showing error message: This is a required field.
	Then In the Product Information Section, set the option in section: 'Which best describes your product, including when FIFRA 25(b) Exempt' to: Product is intended for preventing, destroying, repelling, or mitigating pests (including insects, rodents, mold, virus, bacteria, and other micro-organisms)
	Given in the Product Information page I click Continue
	Then In the Product Information Section, the section: 'Which best describes your product, including when FIFRA 25(b) Exempt' should not be showing error message: This is a required field.
	Given In the Side Menu, click Labeled Link with My Products title
	Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase62775

@TestCase:62852
Scenario: [62852] Pesticide - Product Label is required
	#Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load
	#Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Then In the Side Menu, click Labeled Link with Add Product title
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration'
	Then in the New Product page, I click Continue
	#Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Pet Shampoo with Pest Control
	Given In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Pet Shampoo with Pest Control
	Given In the Product Section, set the option in section: 'Type of Product (select)' to: Pet Shampoo with Pest Control
 	Given in the The Product page I click Continue
	Given I save the product information as: TestCase62852
	#Given I call Shared Step 57865 (Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
	Given I should see the Product Information Page
	Then In the Product Information Section, set the option in section: 'Which best describes your product, including when FIFRA 25(b) Exempt' to: Product is intended for preventing, destroying, repelling, or mitigating pests (including insects, rodents, mold, virus, bacteria, and other micro-organisms)
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue
	#Given I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' confirm option is selected: Liquid
	And In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Liquid
	And In the Physical and Chemical Properties Section, for section: 'Relative Density' enter text: 120
	Then In the Physical and Chemical Properties Section, set the option in section: 'Relative Density' to: g/ml (grams per milliliter)
	And In the Physical and Chemical Properties Section, for section: 'pH' enter text: 8
	And In the Physical and Chemical Properties Section, for section: 'Boiling Point (in Celsius)' enter text: 100
	Then In the Physical and Chemical Properties Section, for section: 'Flash Point (in Celsius)' enter text: 61
	Then In the Physical and Chemical Properties Section, set the option in section: 'Flash Point Testing Method Used' to: Not applicable/available
	And In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
	Then in the Physical and Chemical Properties page, I click Continue
	#Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
	And I should see the Ingredients Page
	Then In the Ingredients section, add component with component name: Water
	Then In the Ingredients Table row with component name: Water, in Percent column text input enter: 100
	Then in the Ingredients page I click Continue
	#Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Then I should be on the Inventory Status, Prop 65 (US) Page
	And In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	And In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page, I click Continue
	#Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
	Given I should see the Product Labeling Page
	Then In the Product Labeling Section, the statement 'Based on the product's recommended use and formulation, this is a possible pharmaceutical waste for California.  Please complete the additional question below to ensure proper classification of this product for the retailer(s).' is displayed
	Then In the Product Labeling Section, in section: 'Refer to your Product Label.  From the options, select those that appear on the Label.' displayed options are:
	| Option                 |
	| Drug Facts Panel       |
	| Supplement Facts Panel |
	| Nutrition Facts Panel  |
	| None of the Above      |
	Then In the Product Labeling Section, in section: 'Refer to your Product Label.  From the options, select those that appear on the Label.' click the checkbox option: None of the Above 
	Then In the Product Labeling Section, the following link: Nutritional and Supplement Labels should be displayed
	Then In the Product Labeling Section, the following link: Dietary Supplements Label should be displayed
	Then In the Product Labeling Section, the following link: OTC Drug Facts Label (may include Active Ingredient) should be displayed
	Then in the Product Labeling page I click Continue
	#Given I call Shared Step 57589 (Enter Pesticide Data - United States (without EPA number))
	Given I should see the Pesticide Details - U.S. Page
	Then In the Pesticide Details - U.S. Section, in 'Product has an Environmental Protection Agency (EPA) Registration Number' enter No
	Then In the Pesticide Details - U.S. Section, in 'Product has a State Registration' enter No
	Then In the Pesticide Details - U.S. Section, in 'Select the applicable exemption' enter Food Based Pesticides - Exempt from EPA Registration
	Then in the Pesticide Details - U.S. page I click Continue
	#Given I call Shared Step 57507 (Transportation Details 1- Not Regulated - Continue - Happy Path)
	Then I should be on the Transportation Details 1 Page
	And In the Transportation Details 1 Section, set the option in section: 'Product is Regulated for Transport': to: Not Regulated
	Then in the Transportation Details 1 page, I click Continue
	#Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	Then I should be on the Retailer Page
	And In the Retailer Section, click 'Add Retailers' button
	Then In the Retailer Section is selected retailer: No Retailer/No UPC Product
	And In the Select Retailers window, click 'Done' button
	Then in the Retailer page, I click Continue
	#Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
	Then in the Regulatory Documents to Provide page I click Continue
	Then I should see the Additional Documents to Provide Page
	Then In the Additional Documents to Provide, section 'Provide Full Product Label (required)' is displayed
	Given in the Additional Documents to Provide page I click Continue
	Then In the Additional Documents to Provide, section 'Provide Full Product Label (required)' error message should display: Document is required: Please upload a PDF of the product label (full label).
	Then In the Additional Documents to Provide, upload PDF document to Provide Full Product Label (required) field
	Given in the Additional Documents to Provide page I click Continue
	Then I should see the Optional Reports and Documents Available for Purchase Page
	Given In the Side Menu, click Labeled Link with My Products title
	Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase62852

@TestCase:56547
Scenario: [56547] Pesiticde Data - EPA registration - Active Ingredient information returned from call to Kelly API
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	#Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Then In the Side Menu, click Labeled Link with Add Product title
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration'
	Then in the New Product page, I click Continue

	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Pet Shampoo with Pest Control
	Given I save the product information as: TestCase56547
	#Given I call Shared Step 57865 (Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
	Given I should see the Product Information Page
	Then In the Product Information Section, set the option in section: 'Which best describes your product, including when FIFRA 25(b) Exempt' to: Product is intended for preventing, destroying, repelling, or mitigating pests (including insects, rodents, mold, virus, bacteria, and other micro-organisms)
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue

	#Given I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' confirm option is selected: Liquid
	And In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Liquid
	And In the Physical and Chemical Properties Section, for section: 'Relative Density' enter text: 120
	Then In the Physical and Chemical Properties Section, set the option in section: 'Relative Density' to: g/ml (grams per milliliter)
	And In the Physical and Chemical Properties Section, for section: 'pH' enter text: 8
	And In the Physical and Chemical Properties Section, for section: 'Boiling Point (in Celsius)' enter text: 100
	Then In the Physical and Chemical Properties Section, for section: 'Flash Point (in Celsius)' enter text: 61
	Then In the Physical and Chemical Properties Section, set the option in section: 'Flash Point Testing Method Used' to: Not applicable/available
	And In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
	Then in the Physical and Chemical Properties page, I click Continue
	#Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
	Given I should see the Ingredients Page
	Then In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	| component name | Sodium hydroxide       | 100     |                     |               |             |
	Then in the Ingredients page I click Continue

#	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Then I should be on the Inventory Status, Prop 65 (US) Page
	And In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	And In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page, I click Continue

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
	Then I should see the Pesticide Details - U.S. Page
	Given I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: Yes
	Given in the New Product page I click Continue
	Given I add the EPA registration number: 73605-2
	Given in the New Product page I click Continue
	Then I should see the Pesticide Details - State Registration Details Page
	Given I click the page heading: Pesticide Details - U.S.
	Then I should see the Pesticide Details - U.S. Page
	Given I confirm data for EPA Registration: 73605-2 is complete
	Given In the Side Menu, click Labeled Link with My Products title
	Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase56547

@TestCase:62778
Scenario: [62778] Pesticide Details - U.S. - Validation of Product has an Environment Protection Agency (EPA) Registration Number
	#Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load
	#Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Then In the Side Menu, click Labeled Link with Add Product title
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration'
	Then in the New Product page, I click Continue
	#Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Pet Shampoo with Pest Control
	Given In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Pet Shampoo with Pest Control
	Given In the Product Section, set the option in section: 'Type of Product (select)' to: Pet Shampoo with Pest Control
 	Given in the The Product page I click Continue
	Then I save the product information as: TestCase62778
	#Given I call Shared Step 57865 (Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
	Given I should see the Product Information Page
	Then In the Product Information Section, set the option in section: 'Which best describes your product, including when FIFRA 25(b) Exempt' to: Product is intended for preventing, destroying, repelling, or mitigating pests (including insects, rodents, mold, virus, bacteria, and other micro-organisms)
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue
	#Given I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' confirm option is selected: Liquid
	And In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Liquid
	And In the Physical and Chemical Properties Section, for section: 'Relative Density' enter text: 120
	Then In the Physical and Chemical Properties Section, set the option in section: 'Relative Density' to: g/ml (grams per milliliter)
	And In the Physical and Chemical Properties Section, for section: 'pH' enter text: 8
	And In the Physical and Chemical Properties Section, for section: 'Boiling Point (in Celsius)' enter text: 100
	Then In the Physical and Chemical Properties Section, for section: 'Flash Point (in Celsius)' enter text: 61
	Then In the Physical and Chemical Properties Section, set the option in section: 'Flash Point Testing Method Used' to: Not applicable/available
	And In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
	Then in the Physical and Chemical Properties page, I click Continue
	#Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
	And I should see the Ingredients Page
	Then In the Ingredients section, add component with component name: Water
	Then In the Ingredients Table row with component name: Water, in Percent column text input enter: 100
	Then in the Ingredients page I click Continue
	#Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Then I should be on the Inventory Status, Prop 65 (US) Page
	And In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	And In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page, I click Continue
	#Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
	Given I should see the Product Labeling Page
	Then In the Product Labeling Section, the statement 'Based on the product's recommended use and formulation, this is a possible pharmaceutical waste for California.  Please complete the additional question below to ensure proper classification of this product for the retailer(s).' is displayed
	Then In the Product Labeling Section, in section: 'Refer to your Product Label.  From the options, select those that appear on the Label.' displayed options are:
	| Option                 |
	| Drug Facts Panel       |
	| Supplement Facts Panel |
	| Nutrition Facts Panel  |
	| None of the Above      |
	Then In the Product Labeling Section, in section: 'Refer to your Product Label.  From the options, select those that appear on the Label.' click the checkbox option: None of the Above 
	Then In the Product Labeling Section, the following link: Nutritional and Supplement Labels should be displayed
	Then In the Product Labeling Section, the following link: Dietary Supplements Label should be displayed
	Then In the Product Labeling Section, the following link: OTC Drug Facts Label (may include Active Ingredient) should be displayed
	Then in the Product Labeling page I click Continue
	Then I should see the Pesticide Details - U.S. Page
	Then In the Pesticide Details - U.S. Section, confirm the question: 'Product has an Environmental Protection Agency (EPA) Registration Number' is displayed
	Then In the Pesticide Details - U.S. Section, confirm following options should be displayed for section: 'Product has an Environmental Protection Agency (EPA) Registration Number'
		| Option |
		| Yes    |
		| No     |
	Then in the Pesticide Details - U.S. page I click Continue
	Then In the Pesticide Details - U.S. Section, confirm for section: 'Product has an Environmental Protection Agency (EPA) Registration Number' error is displayed: This is a required field.
	Then In the Pesticide Details - U.S. Section, in 'Product has an Environmental Protection Agency (EPA) Registration Number' enter Yes
	Then In the Pesticide Details - U.S. Section, confirm for section: 'Product has an Environmental Protection Agency (EPA) Registration Number' error is not displayed: This is a required field.
	Then In the Pesticide Details - U.S. Section, confirm the EPA Pesticide Registration table is displayed
	Then In the Pesticide Details - U.S. Section, in 'Product has an Environmental Protection Agency (EPA) Registration Number' enter No
	Then In the Pesticide Details - U.S. Section, confirm the EPA Pesticide Registration table is not displayed
	Then In the Pesticide Details - U.S. Section, confirm the question: 'Select the applicable exemption' is displayed
	Then In the Pesticide Details - U.S. Section, confirm for section: 'Product has an Environmental Protection Agency (EPA) Registration Number' error is not displayed: This is a required field.
	Given In the Side Menu, click Labeled Link with My Products title
	Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase62778

@TestCase:62780
Scenario: [62780] Pesticide Details - U.S. - Validation of EPA Registration Number table
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	#Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Then In the Side Menu, click Labeled Link with Add Product title
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration'
	Then in the New Product page, I click Continue

	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Pet Shampoo with Pest Control
	Then I save the product information as: TestCase62780
	#Given I call Shared Step 57865 (Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
	Given I should see the Product Information Page
	Then In the Product Information Section, set the option in section: 'Which best describes your product, including when FIFRA 25(b) Exempt' to: Product is intended for preventing, destroying, repelling, or mitigating pests (including insects, rodents, mold, virus, bacteria, and other micro-organisms)
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue

	#Given I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' confirm option is selected: Liquid
	And In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Liquid
	And In the Physical and Chemical Properties Section, for section: 'Relative Density' enter text: 120
	Then In the Physical and Chemical Properties Section, set the option in section: 'Relative Density' to: g/ml (grams per milliliter)
	And In the Physical and Chemical Properties Section, for section: 'pH' enter text: 8
	And In the Physical and Chemical Properties Section, for section: 'Boiling Point (in Celsius)' enter text: 100
	Then In the Physical and Chemical Properties Section, for section: 'Flash Point (in Celsius)' enter text: 61
	Then In the Physical and Chemical Properties Section, set the option in section: 'Flash Point Testing Method Used' to: Not applicable/available
	And In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
	Then in the Physical and Chemical Properties page, I click Continue
	#Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
	Given I should see the Ingredients Page
	Then In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	| component name | Sodium hydroxide       | 100     |                     |               |             |
	Then in the Ingredients page I click Continue

#	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Then I should be on the Inventory Status, Prop 65 (US) Page
	And In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	And In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page, I click Continue

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
	Then I should see the Pesticide Details - U.S. Page
	And I see the following sections
		| Section                                                                  |
		| Product has an Environmental Protection Agency (EPA) Registration Number |
	Given I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: Yes
	And I confirm the EPA Pesticide Registration table is shown
	Then I confirm the EPA Registration table contains the heading: Provide the EPA Registration Number
	And I confirm the following columns are displayed in the EPA Registration table
		| Column Heading                 |
		| EPA Pesticide Registration No. |
		| Federal EPA Active Ingredient. |
		| Percent of Active Ingredient.  |
		| Remove                         |
	Given I click continue
	Then I should see an error message: Federal Registration Number is required
	Given I click Remove for the item on the first EPA Registration Table row
	And I confirm the EPA Registration Table contains a total of 0 rows
	And I click continue
	Then I should see an error message: Required answer missing
	Given I click Add Row in the EPA Registration Table
	And I click continue
	Then I should see an error message: Federal Registration Number is required
	And I confirm the EPA Registration Table contains a total of 1 rows
	Given I add the EPA registration number: 123456789
	Given I click continue
	Then I should see the Pesticide Details - State Registration Details Page
	And I check the State Pesticide Registration Number field matches the text: 123456789
	Given In the Side Menu, click Labeled Link with My Products title
	Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase62780

@TestCase:56577
Scenario: [56577] Pesticide Data - EPA data - Is Kelly Data is updated when user edits date from Kelly
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	#Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Then In the Side Menu, click Labeled Link with Add Product title
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration'
	Then in the New Product page, I click Continue

	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Pet Shampoo with Pest Control
	Then I save the product information as: TestCase56577
	#Given I call Shared Step 57865 (Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
	Given I should see the Product Information Page
	Then In the Product Information Section, set the option in section: 'Which best describes your product, including when FIFRA 25(b) Exempt' to: Product is intended for preventing, destroying, repelling, or mitigating pests (including insects, rodents, mold, virus, bacteria, and other micro-organisms)
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue

	#Given I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' confirm option is selected: Liquid
	And In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Liquid
	And In the Physical and Chemical Properties Section, for section: 'Relative Density' enter text: 120
	Then In the Physical and Chemical Properties Section, set the option in section: 'Relative Density' to: g/ml (grams per milliliter)
	And In the Physical and Chemical Properties Section, for section: 'pH' enter text: 8
	And In the Physical and Chemical Properties Section, for section: 'Boiling Point (in Celsius)' enter text: 100
	Then In the Physical and Chemical Properties Section, for section: 'Flash Point (in Celsius)' enter text: 61
	Then In the Physical and Chemical Properties Section, set the option in section: 'Flash Point Testing Method Used' to: Not applicable/available
	And In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
	Then in the Physical and Chemical Properties page, I click Continue
	#Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
	Given I should see the Ingredients Page
	Then In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	| component name | Sodium hydroxide       | 100     |                     |               |             |
	Then in the Ingredients page I click Continue

#	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Then I should be on the Inventory Status, Prop 65 (US) Page
	And In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	And In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page, I click Continue

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
	Then I should see the Pesticide Details - U.S. Page
	Given I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: Yes
	Given I add the EPA registration number: 56228-10
	Given I click continue
	Then I should see the Pesticide Details - State Registration Details Page
	And I confirm that there is data populated in the Expiration Date Column for some States
	And I confirm the 'Is Kelly Data' field is marked with a check for every State containing data in 'Expiration Date'
	Then I edit the Expiration Date to: 2020-12-31 for the State: AZ on the Pesticide State Registration Details page
	Given in the New Product page I click Continue
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: AK
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: AL
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: AR
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: CA
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: CO
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: CT
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: DC
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: DE
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: FL
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: GA
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: HI
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: IA
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: ID
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: IL
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: IN
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: KS
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: KY
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: LA
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: MA
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: MD
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: ME
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: MI
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: MN
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: MO
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: MS
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: MT
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: NC
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: ND
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: NH
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: NJ
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: NM
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: NV
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: NY
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: OH
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: OK
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: OR
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: PA
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: PR
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: RI
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: SC
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: SD
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: TN
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: TX
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: UT
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: VA
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: VT
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: WA
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: WI
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: WV
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: WY
	And I should see the Transportation Details 1 Page
	Then I click the page heading: Pesticide Details - State Registration Details
	Then I confirm the 'Is Kelly Data' field for State: AZ is not checked
	Given In the Side Menu, click Labeled Link with My Products title
	Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase56577

# Assigned to Barrett, Beverly
# Created by Barrett, Beverly
# Test case can be found at the following paths:
# NetProjects10\WERCSmart UX Reboot\WERCSmart\Product Registration\Pesticides
# NetProjects10\WercsSmart Portal\WERCSmart\Product Registration\Pesticides
#Removed from regression: 2025/04
@ignore
@TestCase:56502
Scenario: [56502] Pesticide Data - United States - EPA Exempt
	#And I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	Given I log in with the account saved in TReVor as: ProductAccount
	#And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Given In the Side Menu, click Labeled Link with Add Product title
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration'
	Given in the New Product page I click Continue
	#And I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Pet Shampoo with Pest Control
	Given In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Pet Shampoo with Pest Control
	Given In the Product Section, set the option in section: 'Type of Product (select)' to: Pet Shampoo with Pest Control
 	Given in the The Product page I click Continue
	#Given I call Shared Step 57865 (Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
	Given I should see the Product Information Page
	Then In the Product Information Section, set the option in section: 'Which best describes your product, including when FIFRA 25(b) Exempt' to: Product is intended for preventing, destroying, repelling, or mitigating pests (including insects, rodents, mold, virus, bacteria, and other micro-organisms)
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue
	Then I save the product information as: TestCase56502
	#Given I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' confirm option is selected: Liquid
	And In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Liquid
	And In the Physical and Chemical Properties Section, for section: 'Relative Density' enter text: 120
	Then In the Physical and Chemical Properties Section, set the option in section: 'Relative Density' to: g/ml (grams per milliliter)
	And In the Physical and Chemical Properties Section, for section: 'pH' enter text: 8
	And In the Physical and Chemical Properties Section, for section: 'Boiling Point (in Celsius)' enter text: 100
	Then In the Physical and Chemical Properties Section, for section: 'Flash Point (in Celsius)' enter text: 61
	Then In the Physical and Chemical Properties Section, set the option in section: 'Flash Point Testing Method Used' to: Not applicable/available
	And In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
	Then in the Physical and Chemical Properties page, I click Continue
	#And I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
	Given I should see the Ingredients Page
	Then In the Ingredients section, add component with component name: Water
	Then In the Ingredients Table row with component name: Water, in Percent column text input enter: 100
	Then in the Ingredients page I click Continue
	#And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Then I should be on the Inventory Status, Prop 65 (US) Page
	And In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	And In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page, I click Continue

	Given I should see the Product Labeling Page
	Then In the Product Labeling Section, in section: 'Refer to your Product Label.  From the options, select those that appear on the Label.' click the checkbox option: None of the Above
	Then in the Product Labeling page, I click Continue

	Then I should see the Pesticide Details - U.S. Page
	Then In the Pesticide Details - U.S. Section, for section: 'Product has an Environmental Protection Agency (EPA) Registration Number' get default option's background color and save it as: defaultColor
	Then in the Pesticide Details - U.S. page I click Continue
	Then In the Pesticide Details - U.S. Section, confirm for section: 'Product has an Environmental Protection Agency (EPA) Registration Number' options background color is not default saved as: defaultColor
	Then In the Pesticide Details - U.S. Section, confirm for section: 'Product has an Environmental Protection Agency (EPA) Registration Number' error is displayed: This is a required field.
	Then In the Pesticide Details - U.S. Section, in 'Product has an Environmental Protection Agency (EPA) Registration Number' enter No
	Then In the Pesticide Details - U.S. Section, for section: 'Product has a State Registration' get default option's background color and save it as: defaultColor
	Then in the Pesticide Details - U.S. page I click Continue
	Then In the Pesticide Details - U.S. Section, confirm for section: 'Product has a State Registration' options background color is not default saved as: defaultColor
	Then In the Pesticide Details - U.S. Section, confirm for section: 'Product has a State Registration' error is displayed: This is a required field.
	Then In the Pesticide Details - U.S. Section, confirm for section: 'Select the applicable exemption' error is displayed: This is a required field.
	Then In the Pesticide Details - U.S. Section, for section: 'Select the applicable exemption': the following options should be displayed exclusively:
	| Option                                               |
	| Food Based Pesticides - Exempt from EPA Registration |
	| Device based products - Exempt from EPA Registration |
	| Pheromone Traps – Exempt from EPA Registration       |
	Then In the Pesticide Details - U.S. Section, I confirm text 'Due to the lack of both an Active and an Inert Ingredient in the ingredients entered, the election for FIFRA 25(b) exemption is not available. Please either enter the Federal EPA Registration Number, or review the ingredients that have been entered, in its entirety, for accuracy. Note: WERCSmart requires 100% disclosure of the ingredients.' should be displayed
	Then In the Pesticide Details - U.S. Section, in 'Product has a State Registration' enter No
	Then In the Pesticide Details - U.S. Section, in 'Select the applicable exemption' enter Food Based Pesticides - Exempt from EPA Registration
	Then in the Pesticide Details - U.S. page I click Continue
	#And I call Shared Step 57507 (Transportation Details 1- Not Regulated - Continue - Happy Path)
	Then I should be on the Transportation Details 1 Page
	And In the Transportation Details 1 Section, set the option in section: 'Product is Regulated for Transport': to: Not Regulated
	Then in the Transportation Details 1 page, I click Continue
	#And I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	Then I should be on the Retailer Page
	And In the Retailer Section, click 'Add Retailers' button
	Then In the Retailer Section is selected retailer: No Retailer/No UPC Product
	And In the Select Retailers window, click 'Done' button
	Then in the Retailer page, I click Continue
	#And I call Shared Step 78080 (Regulatory Documents to Provide - Upload OSHA SDS)
	Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Yes, I certify that I have an OSHA-compliant SDS for this product and would like to upload it.
	Then In the Regulatory Documents to Provide Section, upload file in section: 'OSHA SDS'
	Then In the Regulatory Documents to Provide Section, for section OSHA SDS button View should exists
	Then In the Regulatory Documents to Provide Section, for section OSHA SDS button Remove should exists
	Then in the Regulatory Documents to Provide page I click Continue
	#Then I call shared step 65961 (Additional Documents to Provide - Upload Full Product Label - Continue.
	Then I should see the Additional Documents to Provide Page
	Then In the Additional Documents to Provide, upload PDF document to Provide Full Product Label (required) field
	Then in the Additional Documents to Provide page I click Continue
	Then I should see the Optional Reports and Documents Available for Purchase Page
	Then in the Optional Reports and Documents Available for Purchase page, I click Continue
	Then I should see the Optional Comments Page
	Then in the Optional Comments page, I click Continue
	#Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given I should see the Data Acceptance Page
	Then In the Data Acceptance Section, check 'Agreed' checkbox
	Then In the Data Acceptance Section, click 'Accept' button
	Given The Purchase Summary Page is displayed
	Then In the Purchase Summary page message is displayed with text: Thank you for registering your product on WERCSmart for assessment. The retailers may receive your assessment in approximately two (2) business days, if no delays in processing the assessment, and should no data issues arise.
	Then In the Purchase Summary Page, click the 'Home' button
	Then The home screen should load


@TestCase:132756
Scenario: [132756] Canadian Province Pesticide Options
	#Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I log in with the account saved in TReVor as: ProductAccount
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given In the Side Menu, click Labeled Link with Add Product title
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration'
	Given in the New Product page I click Continue
	#Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Bleach
	Given I should see the The Product Page
	Given In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Bleach
	Given In the Product Section, set the option in section: 'Type of Product (select)' to: Bleach
 	Given in the The Product page I click Continue
	Given I save the product information as: TestCase132756
	#234362 Product Information - Yes Pesticide - Canada only, No OSHA, No Direct Ship, No Ca Cleaning, No Private Label, No GNFR
	#Given I call Shared Step 140562 (Product Information - YES to pesticide - Canada only, No OSHA, No Direct Ship, No CA Cleaning - Continue - Happy Path)
	Given I should see the Product Information Page
	Then In the Product Information Section, set the option in section: 'Which best describes your product, including when FIFRA 25(b) Exempt' to: Product is intended for preventing, destroying, repelling, or mitigating pests (including insects, rodents, mold, virus, bacteria, and other micro-organisms)
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, Check or Uncheck for the section uncheck: Retailers will be selling my product at their store locations in (select either or both) to : United States
	Then In the Product Information Section, set the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' to select: Canada
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Cleaning products must comply with California's Cleaning Product Right to Know Act. I would like to provide the additional information needed for this program during registration.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue
	#43920 Physical and Chemical Properties Screen - Select SOLID Option
	Given I should see the Physical and Chemical Properties Page
	Then In the Physical and Chemical Properties Section, set the option in section: 'Primary Physical State' to: Solid
	And In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
	Then In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Given In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
	Then in the Physical and Chemical Properties page I click Continue
	#Then I call Shared Step 29181 (Ingredients - add any chemical) with name: Water
	And I should see the Ingredients Page
	Then In the Ingredients section, add component with component name: Water
	Then In the Ingredients Table row with component name: Water, in Percent column text input enter: 100
	Then in the Ingredients page I click Continue
	#And I call Shared Step 57911 (Regulatory Information 1 - CEPA only shown - Continue - Happy Path)
	And I should see the Inventory Status, Prop 65 (US) Page
	Then In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'Canadian Environmental Protection Act (CEPA) status' to: Compliant with Domestic Substances List (DSL)
	Then in the Inventory Status, Prop 65 (US) page I click Continue
	#234364 Pesticide Details - Canada - Options Available for each Province
	Then I should see the Pesticide Details - Canada Page
	Then In the 'Pesticide Details - Canada' in row number 1 enter 'Canada's 5-Digit Pest Control Number(s) (PCN) or 8-Digit Drug Identification Number(s) (DIN)': 12345
	Then In the Pesticide Details - Canada Section, set the option in section: 'Product's packaging includes a Poison Danger symbol': to: No
	Then In the Pesticide Details - Canada Section, confirm following options should be exclusively displayed for section: Alberta
	| Option     |
	| None       |
	| Schedule 1 |
	| Schedule 2 |
	| Schedule 3 |
	| Schedule 4 |
	Then In the Pesticide Details - Canada Section, set option for Province: 'Alberta': to: None
	Then In the Pesticide Details - Canada Section, confirm following options should be exclusively displayed for section: British Columbia
	| Option            |
	| None              |
	| Permit Restricted |
	| Restricted        |
	| Commercial        |
	| Domestic          |
	| Excluded          |
	Then In the Pesticide Details - Canada Section, set option for Province: 'British Columbia': to: Excluded
	Then In the Pesticide Details - Canada Section, confirm following options should be exclusively displayed for section: Manitoba
	| Option              |
	| None                |
	| Commercial          |
	| Controlled Purchase |
	| Not Regulated       |
	| Restricted          |
	| Self-Select         |
	Then In the Pesticide Details - Canada Section, set option for Province: 'Manitoba': to: Commercial
	Then In the Pesticide Details - Canada Section, confirm following options should be exclusively displayed for section: New Brunswick
	| Option                 |
	| None                   |
	| Banned                 |
	| Domestic / Self-Select |
	| Non-Domestic           |
	Then In the Pesticide Details - Canada Section, set option for Province: 'New Brunswick': to: Banned
	Then In the Pesticide Details - Canada Section, confirm following options should be exclusively displayed for section: New Foundland and Labrador
	| Option     |
	| None       |
	| Banned     |
	| Domestic   |
	| Commercial |
	| Restricted |
	Then In the Pesticide Details - Canada Section, set option for Province: 'New Foundland and Labrador': to: Banned
	Then In the Pesticide Details - Canada Section, confirm following options should be exclusively displayed for section: Nova Scotia
	| Option                |
	| None                  |
	| Allowed / Self-Select |
	| Banned                |
	| Commercial            |
	| Controlled Purchase   |
	| Restricted            |
	| Not Regulated         |
	Then In the Pesticide Details - Canada Section, set option for Province: 'Nova Scotia': to: Banned
	Then In the Pesticide Details - Canada Section, confirm following options should be exclusively displayed for section: Ontario
	| Option                                                    |
	| None                                                      |
	| Class A: Manufacturing Products                           |
	| Class B: Restricted                                       |
	| Class C: Commercial                                       |
	| Class D: Banned-Cosmetic Pesticide                        |
	| Class D: Domestic Controlled Purchase Requiring a License |
	| Class D: Domestic with License                            |
	| Class D: Domestic without License                         |
	| Class E: Treated Seed                                     |
	Then In the Pesticide Details - Canada Section, set option for Province: 'Ontario': to: None
	Then In the Pesticide Details - Canada Section, confirm following options should be exclusively displayed for section: Prince Edward Island
	| Option                  |
	| None                    |
	| Banned                  |
	| Controlled Purchase     |
	| Exempt: Schedule 7      |
	| Exempt: Schedule 2      |
	| Non-Domestic            |
	| Self-Select: Schedule 8 |
	Then In the Pesticide Details - Canada Section, set option for Province: 'Prince Edward Island': to: None
	Then In the Pesticide Details - Canada Section, confirm following options should be exclusively displayed for section: Quebec 
	| Option   |
	| None     |
	| Class 1  |
	| Class 2  |
	| Class 3  |
	| Class 3A |
	| Class 4  |
	| Class 5  |
	| Banned   |
	Then In the Pesticide Details - Canada Section, set option for Province: 'Quebec': to: None
	Then In the Pesticide Details - Canada Section, confirm following options should be exclusively displayed for section: Saskatchewan  
	| Option     |
	| None       |
	| Commercial |
	| Restricted |
	Then In the Pesticide Details - Canada Section, set option for Province: 'Saskatchewan': to: None
	Then In the Pesticide Details - Canada Section, confirm following options should be exclusively displayed for section: Northwest Territory  
	| Option         |
	| Not Applicable |
	Then In the Pesticide Details - Canada Section, set option for Province: 'Northwest Territory': to: Not Applicable
	Then In the Pesticide Details - Canada Section, confirm following options should be exclusively displayed for section: Yukon Territory  
	| Option     |
	| None       |
	| Commercial |
	| Domestic   |
	| Restricted |
	Then In the Pesticide Details - Canada Section, set option for Province: 'Yukon Territory': to: None
	Then in the Pesticide Details - Canada page I click Continue
	Then I should see the Transportation Details 1 Page
	Then In the Side Menu, click Labeled Link with My Products title
	Then I delete the product: TestCase132756
