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
@SubEnrollment
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:NewProduct
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:Product
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:ProductInformation
@PhysicalAndChemicalProp
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:InventoryStatusProp65
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:Retailer
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:AdditionalDocumentsToProvide
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:OptionalComments
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:RegulatoryDocumentsToProvide
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:TheProduct
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:ToxicityCharacteristicLeachingProcedureTCLP
@StepsPrototype
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:ElectronicEquipment
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:ProductIncludesBattery
@GTINAndUPC
@ProductTemplateLogin
@ProductTemplateSideNavBar
@run_Flow26_Electronic
@Ingredients
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:Formulated_Batteries
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:LithiumBatteryCharacteristics
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:LithiumBatteryTransportation
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:DataAcceptance
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:Summary
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:PurchaseSummary

Feature: [64732] Flow 26 - Electronic

@TestCase:60671
Scenario: [60671] Computer (Combination of Monitor & Desktop) - RU001177

#	Then I navigate to the URL saved in TReVor as: Product Template URL
#	Then In the Product Template Login page, log in with account saved in TReVor as: SHAUser
#	Then In the Side Navigation Bar, click the 'Create Products From Templates' link

	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given If I see the retail partners page I set all data consent tiers to true for all retailers in the top section
	Then The home screen should load
	# ======= Test Setup - Generating + Saving UPC Number and ensuring no duplicates exist ====== #
	#Given I generate a random UPC number and save as: UPC60671
	#Given I delete all products with UPC Number: saved as UPC60671
#	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Then in the New Product page, I click Continue

	#Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Computer (Combination of Monitor & Desktop)
	Given I should see the The Product Page
	Then In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Lithium Ion Battery_#60671
	Then In the Product Section, set the option in section: 'Type of Product (select)' to: Lithium Ion Battery
	Then in the The Product page I click Continue

	Then I save the product information as: TestCase60671
	#Given I call Shared Step 60935 Product Information - US - Direct Ship - Private Label Only
	Given I should see the Product Information Page
	Then In the Product Information Section, set the option in section: 'Select one option below' to: Battery is not packaged for Retail Sale
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue

	#In the step below, confirm that the following text is visible on the TCLP screen, "Please answer the following question with regards to your product, not the battery contained in your product." on the TCLP screen.
	#Given I call Shared 250997 Physical and Chemical Properties - Applicable Only to Type of Product:  Lithium Ion Battery (RU000345) - Scenario:  Battery is not packaged for Retail Sale
	Given I should see the Physical and Chemical Properties Page
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' confirm option is selected: Solid
	Then In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
	Then In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Then in the Physical and Chemical Properties page I click Continue

	#Given I call Shared Step 48367 (Product Includes Battery > any type)
	#| Battery Type | Manufacturer | Quantity of Batteries per Package | Quantity of Batteries to Operate Product |
	#| Alkaline     | <any>        | 6                               | 6                                  |
	Given I should see the Ingredients Page
	Then In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue                   | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	| component name | Graphite                      | 25      |                     |               |             |
	| component name | Lithium Cobalt Oxide (CoLiO2) | 30      |                     |               |             |
	| CAS number     | 9011-17-0                     | 15      |                     |               |             |
	| component name | Diethyl Carbonate             | 15      |                     |               |             |
	| component name | Carbonate, Methyl Ethyl       | 15      |                     |               |             |
	Then in the Ingredients page I click Continue

	Given I should see the Formulation > Batteries Page
	Then In the Formulation > Batteries Section, I confirm text 'Data Use Consents' should be displayed
	Then In the Formulation > Batteries Section, set the radio option in section: 'Consent to Tier 2.1, 2.2, 4.2 Data Uses': to: Granted
	Then in the Formulation > Batteries page I click Continue

	#Given I call Shared Step 251002 (Inventory Status, Prop 65 (US) - Applicable Only to Type of Product: Lithium Ion Battery (RU000345) - Scenario:  Battery is not packaged for Retail Sale)
	Given I should see the Inventory Status, Prop 65 (US) Page
	Then In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	Then In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'Canadian Environmental Protection Act (CEPA) status' to: Exempt (DSL and/or NDSL)
	Then In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page I click Continue

	Given I should see the Battery State of Charge Page
	
	Then in the Battery State of Charge page I click Continue

	Given I should see the Lithium Battery Characteristics Page
	Then In the Lithium Battery Characteristics Section, in 'Type of Battery' select Battery
	Then In the Lithium Battery Characteristics Section, in 'Watt-hour of the battery' enter 100
	Then In the Lithium Battery Characteristics Section, in 'Weight of the single unit' enter 2
	Then In the Lithium Battery Characteristics Section, in 'Battery is manufactured under a Quality Management Program outlined in IATA 3.9.2.6' enter Unknown
	Then in the Lithium Battery Characteristics page I click Continue

	Given I should see the Lithium Battery Transportation Page
	Then In the Lithium Battery Transportation Section, set the radio option in section: 'For U.S. Department of Transportation (DOT), indicate the transport classification': to: Meets the requirements of 49CFR173.185(c)(iv) to be transported as non-dangerous goods for road and rail
	Then In the Lithium Battery Transportation Section, set the radio option in section: 'For Marine transport (IMDG), indicate the classification': to: Meets requirements of IMDG Special Provision 188 to be transported as non-dangerous goods
	Then In the Lithium Battery Transportation Section, set the radio option in section: 'For Air transport (IATA), indicate the classification': to: None of the above/Not intended for shipment under IATA
	Then In the Lithium Battery Transportation Section, set the radio option in section: 'For Canada's Transportation of Dangerous Goods (TDG), indicate the classification': to: None of the above/Not intended for shipment in Canada
	Then in the Lithium Battery Transportation page I click Continue

	Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, upload file in section: 'I have an Article Information Sheet (AIS), Technical Data Sheet (TDS), Battery Data Sheet (BDS) to provide.'
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'Batteries are considered Articles under Global Harmonized Standards. A Safety Data Sheet (SDS) is not required, but may be provided instead of an AIS. When providing an SDS it must be both U.S. and Canada formats.' to: I don't need an OSHA-Compliant Safety Data Sheet (SDS) document for this product.
	Then In the Regulatory Documents to Provide Section, upload file in section: 'Upload UN38.3 Test Document (Required)'
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'WHMIS-compliant Safety Data Sheet, English and French-Canadian' to: I don't need a WHMIS Compliant SDS
	Then In the Regulatory Documents to Provide Section, upload file in section: 'Label in both French and English'
	Then in the Regulatory Documents to Provide page I click Continue

	Given I should see the Additional Documents to Provide Page
	Then in the Additional Documents to Provide page I click Continue

	Given I should see the Optional Reports and Documents Available for Purchase Page
	Then in the Optional Reports and Documents Available for Purchase page I click Continue

	#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Comment Text
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	#Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Computer (Combination of Monitor & Desktop)
	Given I should see the Data Acceptance Page
	Then In the Data Acceptance Section, click 'Summary' button
	Then I switch to the tab with Data Summary page
	Then In the Summary Page, the 'Type of Product (select)' section should be showing the following value: Lithium Ion Battery
	Then In the Summary Page, the 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' section should be showing the following value: No
	Then I close the tab with Data Summary page

	Given I should see the Data Acceptance Page
	Then In the Data Acceptance Section, check 'Agreed' checkbox
	Then In the Data Acceptance Section, click 'Accept' button

	Given The Purchase Summary Page is displayed
	Then In the Purchase Summary page message is displayed with text: Thank you for registering your product on WERCSmart for assessment. The retailers may receive your assessment in approximately two (2) business days, if no delays in processing the assessment, and should no data issues arise.
	Then In the Purchase Summary Page, click the 'Home' button

	Then The home screen should load
