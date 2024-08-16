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
Feature: Pesticides


@TestCase:62775
Scenario: [62775] Pesticides - Validation of Which one best describes your product question - Prevents, Destroys etc
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	#Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Then in the New Product page, I click Continue

	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Pet Shampoo with Pest Control
	Then I save the product information as: TestCase62775
	And I should see the Product Information Page
	Given I see the following sections
		| Section                               |
		| Which best describes your product, including when FIFRA 25(b) Exempt |
	Given I should see a total of 3 radio buttons for the section: Which best describes your product, including when FIFRA 25(b) Exempt
	Then I should see the following radio buttons:
		| Button                                                                                                                                                                               |
		| Product is intended for preventing, destroying, repelling, or mitigating pests (including insects, rodents, mold, virus, bacteria, and other micro-organisms)                        |
		| Product is intended for use as a plant regulator (controls growth), defoliant (removes leaves), or desiccant (dehydrates plants to control growth)                                   |
		| Product is not a pesticide and does not make or imply a pesticidal claim on the labeling or in the product description (ex. kills, sterilizes, disinfects, sanitizes, antimicrobial) |
	And in the New Product page I click Continue
	Then I should see an error message: This is a required field.
	And I set the Which best describes your product, including when FIFRA 25(b) Exempt field to: Product is intended for preventing, destroying, repelling, or mitigating pests (including insects, rodents, mold, virus, bacteria, and other micro-organisms)
	Then Which best describes your product, including when FIFRA 25(b) Exempt should not be showing the error messages: This is a required field.
	And in the New Product page I click Continue
	Then Which best describes your product, including when FIFRA 25(b) Exempt should not be showing the error messages: This is a required field.
	Given I navigate to the home page
	Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase62775

@ignore
#Removed from regression 2023/11
@TestCase:62849
Scenario: [62849] Pesticide - Manually entered date not altered by refresh from Kelly
	#Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load
	Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Pet Shampoo with Pest Control
	Given I save the product information as: TestCase62849
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

	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
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
	Given I add the EPA registration number: 305-48
	Given in the New Product page I click Continue
	Then I should see the Pesticide Details - State Registration Details Page
	Then I confirm that there is data populated in the Expiration Date Column for some States
	Then I confirm the 'Is Kelly Data' field is marked with a check for every State containing data in 'Expiration Date'
	Then I edit the Expiration Date to: 2022-12-01 for the State: NY on the Pesticide State Registration Details page
	Given I confirm the Expiration Date Provided By Kelly field for state: NY is blank
	Given in the Pesticide Details - State Registration Details page I click Continue
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: AL
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: AR
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: CO
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: CT
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: DC
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: FL
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: HI
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: ID
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: IL
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: IN
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: KS
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: KY
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: KL
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: LA
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: MA
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: ME
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: MI
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
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: SD
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: TN
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: TX
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: UT
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: VA
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: VT
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: WV
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: WY
	Given in the New Product page I click Continue
	Given I click the page heading: Pesticide Details - U.S.
	Then I should see the Pesticide Details - U.S. Page
	Given in the Pesticide Details - U.S. page I click Continue
	Given I confirm the Expiration Date Provided By Kelly field for state: NY is blank
	Then I confirm the Expiration Date field for state: NY is showing the value: 2022-12-01
	Given I click the Update Wercs Smart data with EPA data through Kelly Services link
	Then I confirm the Expiration Date field for state: NY is showing the value: 2022-12-01
	Given I navigate to the home page
	Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase62849

@TestCase:62852
Scenario: [62852] Pesticide - Product Label is required
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	#Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Then in the New Product page, I click Continue

	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Pet Shampoo with Pest Control
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
	Given I should see the Ingredients Page
	Then In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	| component name | Sodium hydroxide       | 100     |                     |               |             |
	Then in the Ingredients page I click Continue

	#Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
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
	#Given I call Shared Step 57589 (Enter Pesticide Data - United States (without EPA number))
	Given I should see the Pesticide Details - U.S. Page
	Then In the Pesticide Details - U.S. Section, in 'Product has an Environmental Protection Agency (EPA) Registration Number' enter No
	Then In the Pesticide Details - U.S. Section, in 'Product has a State Registration' enter No
	Then In the Pesticide Details - U.S. Section, in 'Select the applicable exemption' enter Food Based Pesticides - Exempt from EPA Registration
	Then in the Pesticide Details - U.S. page I click Continue

#	Given I call Shared Step 57507 (Transportation Details 1- Not Regulated - Continue - Happy Path)
	Then I should be on the Transportation Details 1 Page
	And In the Transportation Details 1 Section, set the option in section: 'Product is Regulated for Transport': to: Not Regulated
	Then in the Transportation Details 1 page, I click Continue

	#Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	Then I should be on the Retailer Page
	Then in the Retailer page, I click Continue

	#Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
	Then in the Regulatory Documents to Provide page I click Continue

	Then I should see the Additional Documents to Provide Page
	Given I see the following sections
		| Section                               |
		| Provide Full Product Label (required) |
	Given in the Additional Documents to Provide page I click Continue
	Then Provide Full Product Label (required) should be showing the error messages: Document is required: Please upload a PDF of the product label (full label).
	Given I call Shared Step 59042 (Browse for File > select > click Open - Happy Path) for document type: Please upload a PDF of the product label (full label). and file: UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf
	# Click continue confirm no error
	Given I click continue
	Given I navigate to the home page
	Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase62852

@TestCase:56547
Scenario: [56547] Pesiticde Data - EPA registration - Active Ingredient information returned from call to Kelly API
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	#Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
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
	Given I navigate to the home page
	Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase56547

@ignore
#Removed from regression 2023/11
@TestCase:57512
Scenario: [57512] Pesticide question shows in Product Information for Flow 2L
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Given in the New Product page I click Continue
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Pet Shampoo with Pest Control
	Given I save the product information as: TestCase57512
	And I call Shared Step 56799 (Confirm Product Information shows Pesticide question and its radio buttons)
	#Given I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
	Given I navigate to the home page
	Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase57512

@ignore
#Removed from regression 2023/11
@TestCase:57516
Scenario: [57516] Pesticide question shows in Product Information for Flow 2-LS
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Given in the New Product page I click Continue
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Fertilizer
	Given I save the product information as: TestCase57516
	And I call Shared Step 56799 (Confirm Product Information shows Pesticide question and its radio buttons)
	#Given I call Shared Step 57501 (Physical and Chemical Properties - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue)
	Given I navigate to the home page
	Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase57516

@ignore
#Removed from regression 2023/11
@TestCase:57520
Scenario: [57520] Pesticide question shows in Product Information for Flow 2-LS-B
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Given in the New Product page I click Continue
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Animal Deterrent - Non-Aerosol
	Given I save the product information as: TestCase57520
	And I call Shared Step 56799 (Confirm Product Information shows Pesticide question and its radio buttons)
	#Given I call Shared Step 57501 (Physical and Chemical Properties - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue)
	Given I navigate to the home page
	Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase57520

@ignore
#Removed from regression 2023/11
@TestCase:57522
Scenario: [57522] Pesticide question shows in Product Information for Flow 2-S
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Given in the New Product page I click Continue
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Mulch with Pesticide
	Given I save the product information as: TestCase57522
	And I call Shared Step 56799 (Confirm Product Information shows Pesticide question and its radio buttons)
	#Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I navigate to the home page
	Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase57522

@ignore
#Removed from regression 2023/11
@TestCase:57527
Scenario: [57527] Pesticide question shows in Product Information for Flow 6-A
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Given in the New Product page I click Continue
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Disinfectant (Aerosol)
	Given I save the product information as: TestCase57527
	And I call Shared Step 56799 (Confirm Product Information shows Pesticide question and its radio buttons)
	#Given I call Shared Step 57528 (Physical and Chemical Properties - Aerosol Only - add data - Continue - Happy Path)
	Given I navigate to the home page
	Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase57527

@ignore
#Removed from regression 2023/11
@TestCase:57529
Scenario: [57529] Pesticide question shows in Product Information for Flow 6-AG
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Given in the New Product page I click Continue
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Insecticide - Fogger
	Given I save the product information as: TestCase57529
	And I call Shared Step 56799 (Confirm Product Information shows Pesticide question and its radio buttons)
	#Given I call Shared Step 57532 (Physical and Chemical Properties - Aerosol & Gas available - Select Gas - Continue - Happy Path)
	Given I navigate to the home page
	Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase57529

@ignore
#Removed from regression 2023/11
@TestCase:57533
Scenario: [57533] Pesticide question shows in Product Information for Flow 6-All
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Given in the New Product page I click Continue
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Insecticide - Flea and Tick
	Given I save the product information as: TestCase57533
	And I call Shared Step 56799 (Confirm Product Information shows Pesticide question and its radio buttons)
	#Given I call Shared Step 57501 (Physical and Chemical Properties - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue)
	Given I navigate to the home page
	Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase57533

@ignore
#Removed from regression 2023/11
@TestCase:57534
Scenario: [57534] Pesticide question shows in Product Information for Flow 6-LS
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Given in the New Product page I click Continue
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Bathroom and Tile Cleaner - Non-aerosol
	Given I save the product information as: TestCase57534
	And I call Shared Step 56799 (Confirm Product Information shows Pesticide question and its radio buttons)
	#Given I call Shared Step 57501 (Physical and Chemical Properties - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue)
	Given I navigate to the home page
	Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase57534

@ignore
#Removed from regression 2023/11
@TestCase:57546
Scenario: [57546] Pesticide question shows in Product Information for Flow 2-A
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Given in the New Product page I click Continue
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Algicide - Aerosol
	Given I save the product information as: TestCase57546
	And I call Shared Step 56799 (Confirm Product Information shows Pesticide question and its radio buttons)
	#Given I call Shared Step 57528 (Physical and Chemical Properties - Aerosol Only - add data - Continue - Happy Path)
	Given I navigate to the home page
	Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase57546

@ignore
#Removed from regression 2023/11
@TestCase:66344
Scenario: [66344] Pesticide question shows in Product Information for 3-Pest
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Given in the New Product page I click Continue
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Wipes, Disinfecting
	Given I save the product information as: TestCase66344
    Given I call Shared Step 105379 Product Information - US, Pesticide No, No OSHA, No DSV, No PL, No GNFR Without Child question
	#Given I call Shared Step 32931 (Liquid Core Product - select  No - Happy Path)
	Given I should see the Liquid Core Product Page
	Then In the Liquid Core Product Section, set the option in section: 'Is there a free liquid in the Product's container that is 10ml or greater?' to: No
	Then in the Liquid Core Product page I click Continue

	#Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I should see the Physical and Chemical Properties Page
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' should be showing the option: Solid
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' confirm option is selected: Solid
	Then In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
	Then In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Then In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
	Then in the Physical and Chemical Properties page I click Continue

	Given I navigate to the home page
	Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase66344

@ignore
#Removed from regression 2023/11
@TestCase:66345
Scenario: [66345] Pesticide question shows in Product Information for Flow3-VOCSCA
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Given in the New Product page I click Continue
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Wood Finishing Cloth with Stain
	Given I save the product information as: TestCase66345
	#Given I call Shared Step 57865 (Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
	Given I should see the Product Information Page
	Then In the Product Information Section, set the option in section: 'Which best describes your product, including when FIFRA 25(b) Exempt' to: Product is intended for preventing, destroying, repelling, or mitigating pests (including insects, rodents, mold, virus, bacteria, and other micro-organisms)
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue

	#Given I call Shared Step 32931 (Liquid Core Product - select  No - Happy Path)
	Given I should see the Liquid Core Product Page
	Then In the Liquid Core Product Section, set the option in section: 'Is there a free liquid in the Product's container that is 10ml or greater?' to: No
	Then in the Liquid Core Product page I click Continue

	#Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I should see the Physical and Chemical Properties Page
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' should be showing the option: Solid
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' confirm option is selected: Solid
	Then In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
	Then In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Then In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
	Then in the Physical and Chemical Properties page I click Continue

	Given I navigate to the home page
	Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase66345

@56500
#@ignore
@TestCase:56500
Scenario: [56500] Pesticide Data- Canada - validation of questions (updated)
	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Given in the New Product page I click Continue
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Bleach
	Given I save the product information as: TestCase56500
    Given I call Shared Step 140562 (Product Information - YES to pesticide - Canada only, No OSHA, No Direct Ship, No CA Cleaning - Continue - Happy Path)
    And I call Shared Step 102750 (Physical and Chemical Properties - Select primary physical state (liquid), flash point (above 60), and all other required data)
	And I call Shared Step 29181c (Ingredients - add any chemical - For Canada Only) with name: Sodium hydroxide
	Given I call Shared Step 57911 (Regulatory Information 1 - CEPA only shown - Continue - Happy Path)
	Then I should see the Pesticide Details - Canada Page
	Then Field exists: Provide Canada's 5-Digit Pest Control Number (PCN) or 8-Digit Drug Identification Number (DIN) for this product
	#And I Confirm the Canadian Pest Control Number question shows a data entry type control
	# 'field exists' only passes on a data entry element
	Then in the Pesticide Details - Canada page I click Continue
	# JS TFS test case changed to remove Manitoba, Saskatchewan and Northwest Territory from expected fields with error
	Then For every field in the table I should see the following error: This is a required field.
		| Field                      |
		| Provide Canada             |
		| Product                    |
		| Alberta                    |
		| British Columbia           |
		| New Brunswick              |
		| New Foundland              |
		| Nova Scotia                |
		| Ontario                    |
		| Prince Edward Island       |
		| Quebec                     |
		| Yukon Territory            |
		| Saskatchewan               |
		| Manitoba                   |
	Then For every field in the table I should not see the following error: This is a required field.
		| Field               |
		| Northwest Territory |
	# Type in a Canadian Pest Control Products (PCP) Registration Number with more than 5 digits and less than 8 digits
	Given I set the Provide Canada's 5-Digit Pest Control Number (PCN) or 8-Digit Drug Identification Number (DIN) for this product field to: 279255
	Then in the Pesticide Details - Canada page I click Continue
	Then Provide Canada should be showing the error messages: Enter a valid number (5 or 8 digits).
	# Enter data in the Canada Pest Control Number field that contains alpha characters
	Given I set the Provide Canada's 5-Digit Pest Control Number (PCN) or 8-Digit Drug Identification Number (DIN) for this product field to: abc256
	Then in the Pesticide Details - Canada page I click Continue
	Then Provide Canada should be showing the error messages: Enter a valid number (5 or 8 digits).
	# Enter less than 5 digits in the Canada Pest Control Number field
	Given I set the Provide Canada's 5-Digit Pest Control Number (PCN) or 8-Digit Drug Identification Number (DIN) for this product field to: 2792
	Then in the Pesticide Details - Canada page I click Continue
	Then Provide Canada should be showing the error messages: Enter a valid number (5 or 8 digits).
	# Enter more than 8 digits in the Canada Pest Control Number field
	Given I set the Provide Canada's 5-Digit Pest Control Number (PCN) or 8-Digit Drug Identification Number (DIN) for this product field to: 2792101055
	Then in the Pesticide Details - Canada page I click Continue
	Then Provide Canada should be showing the error messages: Enter a valid number (5 or 8 digits).
	# Enter in a valid PCP Registration (5 or 8 digits)
	Given I set the Provide Canada's 5-Digit Pest Control Number (PCN) or 8-Digit Drug Identification Number (DIN) for this product field to: 27925
	Then in the Pesticide Details - Canada page I click Continue
	Then Provide Canada's 5-Digit Pest Control Number (PCN) or 8-Digit Drug Identification Number (DIN) for this product should not be showing any error messages
	Then Field exists: Product's packaging includes a Poison Danger symbol
	And The following options should be displayed for section: Product's packaging includes a Poison Danger symbol
		| Option |
		| Yes    |
		| No     |
	And Section: Product's packaging includes a Poison Danger symbol should be showing an error message
	Given I set the Product's packaging includes a Poison Danger symbol field to: No
	Then Product's packaging includes a Poison Danger symbol should not be showing any error messages
	Given I set the Alberta field to: Choose...
    Then For every field in the table I call Shared Step 56494 expecting error: This is a required field.
		| Field                |
		| Alberta              |
		| British Columbia     |
		| New Brunswick        |
		| New Foundland        |
		| Nova Scotia          |
		| Ontario              |
		| Prince Edward Island |
		| Quebec               |
		| Yukon Territory      |
		| Saskatchewan         |
		| Manitoba             |
	# Confirm N/A is shown as already selected for the Northwest Territory question
  	And Northwest Territory should be showing the value: Not Applicable
	Then in the Pesticide Details - Canada page I click Continue
	#Given I call Shared Step 57507 (Transportation Details 1- Not Regulated - Continue - Happy Path)
	Then I should be on the Transportation Details 1 Page
	And In the Transportation Details 1 Section, set the option in section: 'Product is Regulated for Transport': to: Not Regulated
	Then in the Transportation Details 1 page, I click Continue

	Given I call Shared Step 69388 (Retailer - Canada Only - Select No Retailer/No UPC product > Done > Continue - Happy Path)
	Given I call Shared Step 69389 (Regulatory Documents to Provide - Canada only - Confirm questions - Request author, add label and todays date - Continue)
	Then I should see the Additional Documents to Provide Page
	Then in the Additional Documents to Provide page I click Continue
	Then I should see the Optional Reports and Documents Available for Purchase Page
	Then in the Optional Reports and Documents Available for Purchase page I click Continue
#	And I call Shared Step 64097 - Additional Documents -> Contact Information - Add any Name, address, phone and emergency phone - Happy Path
	Then I should be on the Additional Documents -> Contact Information Page
	And In the Additional Documents -> Contact Information section, for section: 'Manufacturer Name' enter text: Manufacturer
	And In the Additional Documents -> Contact Information section, for section: 'Address' enter text: Address
	And In the Additional Documents -> Contact Information section, for section: 'Phone' enter text: Phone
	And In the Additional Documents -> Contact Information section, for section: 'Emergency Phone' enter text: Emergency Phone
	Then in the Additional Documents -> Contact Information page, I click Continue

	And I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
		| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
	#And I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Test Comment 0000
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	Then In the Data Acceptance page I select Agreed
	And I should not see any error messages
	Given I navigate to the home page
	Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase56500

#Removed from regression: 2023/04
@ignore
@TestCase:56541
Scenario: [56541] Pesticide Data - United States - EPA Registered - Data returned from call to Kelly API (done)
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Given in the New Product page I click Continue
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Pet Shampoo with pest control
	Given I save the product information as: TestCase56541
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

	#Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
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
	And I should see the Pesticide Details - U.S. Page
	And I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: Yes
	Given in the New Product page I click Continue
	Given I add the EPA registration number: 72315-6
	Given in the New Product page I click Continue
	And I should see the Pesticide Details - State Registration Details Page
	Given I confirm that there is data populated in the Expiration Date Column for some States
	Then I confirm that every date in the Expiration Date column has a matching date in the Expiration Date provided by Kelly column
	And I confirm the 'Is Kelly Data' field is marked with a check for every State containing data in 'Expiration Date'
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: AL
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: AR
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: CO
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: CT
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: DC
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: FL
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: HI
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
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: SD
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: TN
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: TX
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: UT
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: VA
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: VT
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: WV
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: WY
	Given in the New Product page I click Continue
	And I should see the Transportation Details 1 Page
	Given I navigate to the home page
	Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase56541

@TestCase:62778
Scenario: [62778] Pesticide Details - U.S. - Validation of Product has an Environment Protection Agency (EPA) Registration Number
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	#Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Then in the New Product page, I click Continue

	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Pet Shampoo with Pest Control
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
	Given I should see the Ingredients Page
	Then In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	| component name | Sodium hydroxide       | 100     |                     |               |             |
	Then in the Ingredients page I click Continue

	#Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
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
	And The following options should be displayed for section: Product has an Environmental Protection Agency (EPA) Registration Number
		| Option |
		| Yes    |
		| No     |
	Given I click continue
	Then Product has an Environmental Protection Agency (EPA) Registration Number should be showing the error messages: This is a required field.
	Given I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: Yes
	Then Product has an Environmental Protection Agency (EPA) Registration Number should not be showing the error messages: This is a required field
	And I confirm the EPA Pesticide Registration table is shown
	Given I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: No
	Then I confirm the EPA Pesticide Registration table is not shown
	And I see the following sections
		| Section                         |
		| Select the applicable exemption |
	Then Product has an Environmental Protection Agency (EPA) Registration Number should not be showing the error messages: This is a required field
	Given I navigate to the home page
	Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase62778

@TestCase:62780
Scenario: [62780] Pesticide Details - U.S. - Validation of EPA Registration Number table
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	#Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
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
	Given I navigate to the home page
	Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase62780

@TestCase:56577
Scenario: [56577] Pesticide Data - EPA data - Is Kelly Data is updated when user edits date from Kelly
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	#Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
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
	Given I navigate to the home page
	Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase56577

#Removed from regression: 2023/04
@ignore
@TestCase:62799
Scenario: [62799] Pesticide Details - State Registration - Manual entry of dates and coloring
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Pet Shampoo with Pest Control
	Then I save the product information as: TestCase62799
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
	Given I add the EPA registration number: testregistrationnumber
	Given I click continue
	Then I should see the Pesticide Details - State Registration Details Page
	And I confirm the State Registration EPA table does not contain any Expiration data
	Given I set the Expiration Date to be 29 days from today using the calendar selector for state: AL
	Then I confirm that the EPA table row for state: AL is highlighted with the color: orange
	And I confirm the Expiration Date Provided By Kelly field for state: AL is blank
	And I confirm the 'Is Kelly Data' field for State: AL is not checked
	Given I set the Expiration Date to be 60 days from today using the calendar selector for state: NY
	Then I confirm that the EPA table row for state: NY is highlighted with the color: yellow
	Given I set the Expiration Date to be 100 days from today using the calendar selector for state: WA
	Then I confirm that the EPA table row for state: WA is highlighted with the color: none
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: AK
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: AR
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: AZ
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
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: NE
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: NH
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: NJ
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: NM
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: NV
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
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: WI
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: WV
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: WY
	Given I click continue
	And I should see the Transportation Details 1 Page
	Then I click the page heading: Pesticide Details - State Registration Details
	Then I confirm that the EPA table row for state: AL is highlighted with the color: orange
	Then I confirm that the EPA table row for state: NY is highlighted with the color: yellow
	Then I confirm that the EPA table row for state: WA is highlighted with the color: none
	Given I navigate to the home page
	Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase62799

# Assigned to Barrett, Beverly
# Created by Barrett, Beverly
# Test case can be found at the following paths:
# NetProjects10\WERCSmart UX Reboot\WERCSmart\Product Registration\Pesticides
# NetProjects10\WercsSmart Portal\WERCSmart\Product Registration\Pesticides
@TestCase:56502
Scenario: [56502] Pesticide Data - United States - EPA Exempt
	#And I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	Given I log in with the account saved in TReVor as: ProductAccount
	#And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
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
	Then in the Pesticide Details - U.S. page I click Continue
	Then In the Pesticide Details - U.S. Section, confirm for section: 'Product has an Environmental Protection Agency (EPA) Registration Number' options background color is red
	Then In the Pesticide Details - U.S. Section, confirm for section: 'Product has an Environmental Protection Agency (EPA) Registration Number' error is displayed: This is a required field.
	Then In the Pesticide Details - U.S. Section, in 'Product has an Environmental Protection Agency (EPA) Registration Number' enter No
	Then in the Pesticide Details - U.S. page I click Continue
	Then In the Pesticide Details - U.S. Section, confirm for section: 'Product has a State Registration' options background color is red
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
	Then I call Shared Step 65080 (Login to Studio and Open SHA manager)
	#And I call Shared Step 65080b (Login to Studio as user saved as: SHAQAAuto17 and Open SHA manager)
	#And I Use the shared step below to search for your product - you may have to wait a few minutes for the product to show in submitted (the Zuora process)
	And I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase56502)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase56502 and its status is: Assigned
	#And I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase56502)
	And I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase56502)
	Then In Power Designer I left click on section: [SECT0127] State Pesticide Information
	Then In Power Designer, confirm no data is displayed in section 'SECT0127 State Pesticide Information'

#Removed from regression: 2023/04
@ignore
@TestCase:71051
Scenario: [71051] Pesticide Details - EPA Registration number if edited is NOT refresh from Kelly when the Update WERCSmart data link is used
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Pet Shampoo with Pest Control
	Then I save the product information as: TestCase71051
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
	And I should see the Pesticide Details - U.S. Page
	And I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: Yes
	Given in the New Product page I click Continue
	Given I add the EPA registration number: 72315-6
	Given in the New Product page I click Continue
	And I should see the Pesticide Details - State Registration Details Page
	Given I update each Registration Number with the appended text '-edited'
	Given in the New Product page I click Continue
	And I should see the Transportation Details 1 Page
	Then I click the page heading: Pesticide Details - State Registration Details
	And I should see the Pesticide Details - State Registration Details Page
	Then I check each State Pesticide Registration Number contains the edited suffix
	Given I click the Update Wercs Smart data with EPA data through Kelly Services link
	Then I check each State Pesticide Registration Number contains the edited suffix
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: AL
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: AR
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: CO
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: CT
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: DC
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: FL
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: HI
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: ID
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: IL
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: IN
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: KS
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: KY
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: LA
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: MD
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
	Given I navigate to the home page
	Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase71051

#Removed from regression: 2023/04
@ignore
@TestCase:62848
Scenario: [62848] Pesticide Details - EPA Expiration Date is refresh from Kelly when the Update WERCSmart data link is used
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Pet Shampoo with Pest Control
	Then I save the product information as: TestCase62848
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
	And I should see the Pesticide Details - U.S. Page
	And I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: Yes
	Given in the New Product page I click Continue
	Given I add the EPA registration number: 56228-10
	Given in the New Product page I click Continue
	And I should see the Pesticide Details - State Registration Details Page
	Given I confirm that there is data populated in the Expiration Date Column for some States
	And I confirm the 'Is Kelly Data' field is marked with a check for every State containing data in 'Expiration Date'
	Then I edit the Expiration Date to: 2022-12-31 for the State: AZ on the Pesticide State Registration Details page
	Given In the Pesticide Details - State Registration Details page I click 'x' for the following state: AL
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
	Given in the New Product page I click Continue
	Then I click the page heading: Pesticide Details - U.S.
	And I should see the Pesticide Details - U.S. Page
	Given in the New Product page I click Continue
	And I should see the Pesticide Details - State Registration Details Page
	Then I confirm the 'Is Kelly Data' field for State: AZ is not checked
	Given I click the Update Wercs Smart data with EPA data through Kelly Services link
	Then I confirm the Expiration Date matches the value provided by Kelly on the State Registration Details Page for the edited State
	#Then I confirm the 'Is Kelly Data' field for State: AZ is checked
	#Given I navigate to the home page
	#Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase62848
	 

@ignore
#Removed from regression 2023/11
@TestCase:121120
Scenario:[121120] Pesticide - New Radio Icon Option
	#Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I log in with the account saved in TReVor as: ProductAccount
	Given I generate a random UPC number and save as: UPC121120
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Given in the New Product page I click Continue
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Pet Shampoo with pest control
	Then I save the product information as: TestCase121120
	Given I call Shared Step 105379 Product Information - US, Pesticide No, No OSHA, No DSV, No PL, No GNFR Without Child question
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
	#And I call Shared Step 29181 (Ingredients - add any chemical) with name: Water
	Given I should see the Ingredients Page
	Then In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	| component name | Water       | 100     |                     |               |             |
	Then in the Ingredients page I click Continue

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
	And I should see the Transportation Details 1 Page
    And The following options should be displayed exclusively for section: Product is Regulated for Transport
		| Option                               |
		| Yes                                  |
		| No, due to an exemption or exception |
		| Not Regulated                        |
    And I set the Product is Regulated for Transport field to: Not Regulated
    And I click continue
	And In the 'Select Retailers' window I select the retailer: Walgreens
	And I click continue
	And I call Shared Step 85909 (UPC - Confirm Package type link and drop down not shown - Add UPC data - Continue) for UPC: saved as UPC121120, container type: Plastic Container and size: 12 click continue
	#Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
	Then in the Regulatory Documents to Provide page I click Continue

	Then in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	And I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
		| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
	#And I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given If purchase details are showing click confirm order

	
@TestCase:132756
Scenario: [132756] Canadian Province Pesticide Options
	#Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I log in with the account saved in TReVor as: ProductAccount
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
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
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase132756
