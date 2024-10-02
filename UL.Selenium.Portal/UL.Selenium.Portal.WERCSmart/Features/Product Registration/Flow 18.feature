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
@run_Flow18
@StepsPrototype
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:TheProduct
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:ProductInformation
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:NewProduct
@PhysicalAndChemicalProp
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:RegulatoryDocumentsToProvide
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:OptionalComments
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:InventoryStatusProp65
@Ingredients
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:TransportationDetails1
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:Retailer
@SafetyDataSheetAuthoring
@AdditionalDocsContactInfo
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:CaliforniaCleaningProductDisclosure
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:VOC_OzoneTransportCommission
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:AdditionalDocumentsToProvide
@Product:WERCSmart_Account:Distributor_Page:NewProducts_Tab:ReciewAndSubmit_Section:OptionalReportsAndDocumentsAvailableForPurchase
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:DataAcceptance
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:Summary
@Steps_ProductPrototype
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:TransportationDetails2
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:USDepartamentOfTransportationDOT
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:InternationalAirTransportClassification
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:InternationalMarineClassification
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:VOC_OzoneTransportCommission
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:VOC_Summary
@GTINAndUPC

Feature: Flow 18

@tfsdesign
@TestCase:60116
Scenario: [60116] Anti-Static Product - Aerosol - RU000656
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC60116
	Given I delete all products with UPC Number: saved as UPC60116
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Then in the New Product page, I click Continue

	#Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Anti-Static Product - Aerosol
	Then I should see the The Product Page
	Then In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Anti-Static Product - Aerosol_#60116
	Then In the Product Section, set the option in section: 'Type of Product (select)' to: Anti-Static Product - Aerosol
	Then in the The Product page, I click Continue

	Then I save the product information as: TestCase60116

	#Given I call Shared Step 60310 (Product Information - Without Child question)
	Given I should see the Product Information Page
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Given in the Product Information page I click Continue

	#Given I call Shared Step 253461 (Product Information - Applicable Only to Type of Product:  Anti-Static Product - Aerosol (RU000656) with Secondary Physical State:  Bag-on-Valve (BOV))
	Given I should see the Physical and Chemical Properties Page
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' should be showing the option: Aerosol
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' confirm option is selected: Aerosol
	Then In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Bag-on-valve (BOV)
	Then In the Physical and Chemical Properties Section, for section: 'pH' select the checkbox option: 'I do not have exact pH data available to me'
	Then In the Physical and Chemical Properties Section, set the option in section: 'pH' to: Not tested/Unknown
	Then In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: No data available
	Then In the Physical and Chemical Properties Section, set the option in section: 'When the product has a flammable propellant, or contains ingredients with a flash point below 60⁰C then' to: This product is not classified as D001 or D003 Hazardous Waste under RCRA
	Then in the Physical and Chemical Properties page I click Continue

	Given I should see the Ingredients Page
	Then In the Ingredients section, add the following ingredients:
		| SearchType | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
		| CAS number | 64-17-5     | 100     |                     |               |             |
	Then in the Ingredients page I click Continue
	Given I should see the Inventory Status, Prop 65 (US) Page
	Then Expand the Ingredients panel
	Then In the Ingredients section, add the following ingredients:
		| SearchType | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
		| CAS number | 61789-80-8  | 1       |                     |               |             |
	Then in the Ingredients page I click Continue

	#Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I should see the Inventory Status, Prop 65 (US) Page
	Then In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is exempt from TSCA chemical Inventory listing requirements.
	Then In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page I click Continue

	#Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	Given I should see the Transportation Details 1 Page
	Then In the Transportation Details 1 Section, set the option in section: 'Product is Regulated for Transport': to: Yes
	Then In the Transportation Details 1 Section, set the option in section: 'Select all modes of transport that you've classified the product for': to: DOT
	Then In the Transportation Details 1 Section, set the option for DOT mode of transport to: Shipping with limited quantity
	Then In the Transportation Details 1 Section, set the option in section: 'Select all modes of transport that you've classified the product for': to: IMDG
	Then In the Transportation Details 1 Section, set the option for IMDG mode of transport to: Shipping with limited quantity
	Then In the Transportation Details 1 Section, set the option in section: 'Select all modes of transport that you've classified the product for': to: IATA
	Then In the Transportation Details 1 Section, set the option for IATA mode of transport to: Shipping with limited quantity
	Then in the Transportation Details 1 page I click Continue

	#Given I call Shared Step 65705 (Transportation - DOT UN step - Enter UN1950, select Aerosols,  2.1, None, add technical name, Click Continue)
	Given I should see the U.S. Department of Transportation (DOT) Classification Page
	Then In the U. S. Department of Transportation (DOT) Classification Section, set the option in section: 'UN Number': to: UN1950
	Then In the U. S. Department of Transportation (DOT) Classification Section, set the option in section: 'Proper Shipping Name': to: Aerosols, flammable, n.o.s.
	Then In the U. S. Department of Transportation (DOT) Classification Section, set the option in section: 'Hazard Class': to: 2.1
	Then In the U. S. Department of Transportation (DOT) Classification Section, set the option in section: 'Packing Group': to: None
	Then in the U.S. Department of Transportation (DOT) Classification page I click Continue

	Given I should see the International Air Transport (IATA) Classification Page
	Then In the International Air Transport (IATA) Classification Section, set the option in section: 'UN Number': to: UN1950
	Then In the International Air Transport (IATA) Classification Section, set the option in section: 'Hazard Class (select)': to: 2.1
	Then In the International Air Transport (IATA) Classification Section, set the option in section: 'Packing Group': to: None
	Then In the International Air Transport (IATA) Classification Section, set the option in section: 'Proper Shipping Name': to: Aerosols, flammable
	Then in the International Air Transport (IATA) Classification page I click Continue

	Given I should see the International Marine (IMDG) Classification Page
	Then In the International Marine (IMDG) Classification Section, set the option in section: 'UN Number': to: UN1950
	Then In the International Marine (IMDG) Classification Section, set the option in section: 'Proper Shipping Name': to: Aerosols
	Then In the International Marine (IMDG) Classification Section, set the option in section: 'Hazard Class (select)': to: 2
	Then In the International Marine (IMDG) Classification Section, set the option in section: 'Packing Group': to: None
	Then in the International Marine (IMDG) Classification page I click Continue

	#Given I call Shared Step 62710 (Confirm VOC OTC/CARB heading and select No to FIRST QUESTION ONLY - Happy Path)
	Given I should see the Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB) Page
	Then In the VOC - Ozone Transport Commission Section, set the option in section: 'Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations.': to: No
	Then In the VOC - Ozone Transport Commission Section, set the option in section: 'Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the CARB': to: 79.44
	Then In the VOC - Ozone Transport Commission Section, set the option in section: 'Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the OTC Model Rule': to: 79.44
	Then In the VOC - Ozone Transport Commission Section, set the option in section: 'Would you like to use the VOC percentages entered for all areas (e.g. country, state, local) for comparison?': to: Yes
	Then in the Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB) page I click Continue

	#Given I call Shared Step 60468 (VOC - CARB only required - enter value - Continue - Happy Path)
	Given I should see the Volatile Organic Compound Summary Page
	Then In the Volatile Organic Compound Summary Section, confirm that I see todays 'VOC Analysis Date'
	Then In the Volatile Organic Compound Summary Section, confirm 'Limits' table should exists
	Then In the Volatile Organic Compound Summary Section, confirm that I see the following 'CARB' value: 79.44
	Then In the Volatile Organic Compound Summary Section, confirm that I see the following 'OTC Model Rule' value: 79.44
	Then In the Volatile Organic Compound Summary Section, the statement 'Does not exceed the limits specified in the California Consumer Products Regulation' is displayed
	Then In the Volatile Organic Compound Summary Section, the statement 'Does not exceed the limits specified by the Ozone Transport Commission' is displayed
	Then In the Volatile Organic Compound Summary Section, for 'Your acknowledgement of this registration includes that your product..' set 'Yes, I Acknowledge'
	Then in the Volatile Organic Compound Summary page I click Continue

	#Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Staples
	Then I should be on the Retailer Page
	And In the Retailer Section, click 'Add Retailers' button
	And In the Select Retailers window, select retailer: The Home Depot
	And In the Select Retailers window, click 'Done' button
	Then in the Retailer page, I click Continue

	Then I should be on the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, I click the Add UPC Button
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, for section: 'Provide the product's UPC(s)- including container type and size (ounces)' enter UPC Number: saved as UPC60116 enter Size: 6.3 and enter Container Type: Aerosol Can - Metal
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, under Transportation column the checkbox 'DOT' is checked
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, under Transportation column the checkbox 'IMDG' is checked
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, under Transportation column the checkbox 'IATA' is checked
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, verify retailer 'HD' is present under the 'Destination Retailers' column
	Then in the Global Trade Item Number (GTIN) / Universal Product Code (UPC) page, I click Continue

	#Then I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC60116, container type: Aerosol Can and size: 1
	#Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Yes, I certify that I have an OSHA-compliant SDS for this product and would like to upload it.
	Then In the Regulatory Documents to Provide Section, upload file in section: 'OSHA SDS'
	Then in the Regulatory Documents to Provide page I click Continue

	Given I should see the Additional Documents to Provide Page
	Then in the Additional Documents to Provide page I click Continue
	Then In the Additional Documents to Provide, section 'Volatile Organic Compounds' error message should display: Document is required: Product Label
	Then In the Additional Documents to Provide, upload PDF document to Upload Volatile Organic Compounds field
	Then in the Additional Documents to Provide page I click Continue

	Given I should see the Optional Reports and Documents Available for Purchase Page
	Then in the Optional Reports and Documents Available for Purchase page I click Continue

	#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: User added Comments Text 60116. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	#Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Anti-Static Product - Aerosol
	Given I should see the Data Acceptance Page
	Then In the Data Acceptance Section, click 'Summary' button
	Then I switch to the tab with Data Summary page
	Then In the Summary Page, the 'Type of Product' section should be showing the following value: Anti-Static Product - Aerosol
	Then In the Summary Page, the 'Primary Physical State' section should be showing the following value: Aerosol
	Then In the Summary Page, the 'Secondary Physical State' section should be showing the following value: Bag-on-valve (BOV)
	#Then In the Summary Page, verify table data in column CAS Number/ChemicalName showing the value: 64-17-5
	Then In the Summary page, I confirm the Ingredients table matches the following:
	| CAS Number/ChemicalName                                                          | Percent | Publicly Disclosed? | Trade Secret? | INCI Name |
	| Ethyl alcohol                                                                    | 100     | No                  | No            |           |
	| Quaternary ammonium compounds, bis(hydrogenated tallow alkyl)dimethyl, chlorides | 1       | No                  | No            |           |

	Then In the Summary Page, the 'Product is Regulated for Transport' section should be showing the following value: Yes

	Then In the Summary Page, the 'Select all modes of transport that you've classified the product for' section should be showing the following value: DOT
	Then In the Summary Page, the 'Select all modes of transport that you've classified the product for' section should be showing the following value: Shipping with limited quantity
	Then In the Summary Page, the 'Select all modes of transport that you've classified the product for' section should be showing the following value: IMDG
	Then In the Summary Page, the 'Select all modes of transport that you've classified the product for' section should be showing the following value: Shipping with limited quantity
	Then In the Summary Page, the 'Select all modes of transport that you've classified the product for' section should be showing the following value: IATA
	Then In the Summary Page, the 'Select all modes of transport that you've classified the product for' section should be showing the following value: Shipping with limited quantity


	Then In the Summary Page, the 'UN Number' section should be showing the following value: UN1950
	Then In the Summary Page, the 'Proper Shipping Name' section should be showing the following value: Aerosols, flammable, n.o.s.
	Then In the Summary Page, the 'Hazard Class' section should be showing the following value: 2.1
	Then In the Summary Page, the 'Packing Group' section should be showing the following value: None
	Then In the Summary Page, the 'Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by' section should be showing the following value: 79.44
	Then In the Summary Page, the 'Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the OTC Model Rule' section should be showing the following value: 79.44

	Then In the Summary Page, verify table data in column UPC Transportation showing the value: DOT
	Then In the Summary Page, verify table data in column UPC Transportation showing the value: -- Shipping with limited quantity
	Then In the Summary Page, verify table data in column UPC Transportation showing the value: IMDG
	Then In the Summary Page, verify table data in column UPC Transportation showing the value: -- Shipping with limited quantity
	Then In the Summary Page, verify table data in column UPC Transportation showing the value: IATA
	Then In the Summary Page, verify table data in column UPC Transportation showing the value: -- Shipping with limited quantity


	Then In the Summary Page, verify table data in column Container Type showing the value: Aerosol Can - Metal
	Then In the Summary Page, verify table data in column Size (Ounces) showing the value: 6.3
	Then In the Summary Page, verify table data in column Retailers showing the value: HD
	Then I close the tab with Data Summary page

	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase60116

# Created by Saikiran Chittampally
@TestCase:208099
Scenario: [208099] Fabric Softener - Single-Use Dryer Product Only (RU000808)
	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	#Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Then in the New Product page, I click Continue

	#Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Fabric Softener - Single Use Dryer Product Only
	Then I should see the The Product Page
	Then In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Fabric Softener - Single Use Dryer Product Only_#208099
	Then In the Product Section, set the option in section: 'Type of Product (select)' to: Fabric Softener - Single Use Dryer Product Only
	Then in the The Product page, I click Continue

	Then I save the product information as: TestCase208099
	#Given I call Shared Step 250116 Product Information - Product Information - Applicable Only to Type of Product:  Fabric Softener - Single Use Dryer Product Only (RU000808)
	Then I should see the Product Information Page
	Then In the Product Information Section, set the option in section: 'Which best describes your product, including when FIFRA 25(b) Exempt' to: Product is not a pesticide and does not make or imply a pesticidal claim on the labeling or in the product description (ex. kills, sterilizes, disinfects, sanitizes, antimicrobial)
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Cleaning products must comply with California's Cleaning Product Right to Know Act. I would like to provide the additional information needed for this program during registration.' to: Yes
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page, I click Continue

	#Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I should see the Physical and Chemical Properties Page
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' should be showing the option: Solid
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' confirm option is selected: Solid
	Then In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
	Then In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Then In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
	Then in the Physical and Chemical Properties page I click Continue

	#Given I call Shared Step 193979 California Cleaning Product Disclosure - Final Domestic Distributor
	Given I should see the California Cleaning Product Disclosure Page
	Then In the California Cleaning Product Disclosure Section, set the radio option in section: 'Who is publicly identified on the product label as responsible for the product?': to: Final Domestic Distributor
	Then In the California Cleaning Product Disclosure Section, set the option in section: 'Who is the Final Domestic Distributor (if any) of the product?' to: None
	Then In the California Cleaning Product Disclosure Section, set the option in section: 'Is your identity, as the Manufacturer of this product, Confidential Business Information (CBI)?' to: No
	Then In the California Cleaning Product Disclosure Section, set the option in section: 'Select the product's GTIN Brick Code' to: [10000740] Fresheners – Fabric
	Then in the California Cleaning Product Disclosure page I click Continue

	#Given I add the following CA Cleaning ingredients:  
	#	| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName     | IngredientType | FunctionalPurpose             | Clean | Certified |
	#	| Water         | 100     | true               | false       | AQUA           | Fragrance      |  |   |       |
	#Then I click continue

	Given I should see the Ingredients Page
	Then In the Ingredients section, add the following ingredients:
	| SearchType | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name                                                                                                                            | Ingredient Type     | Functional Purpose                | Certified |
	| CAS number | 157905-74-3 | 50      | True                | False         | Ethanaminium, 2-hydroxy-N,N-bis(2-hydroxyethyl)-N-methyl-, esters with C16-18 and C18-unsaturated fatty acids, methyl sulfates (salts) | Intentionally Added | Antistatic Agent, Softening Agent |           |
	| CAS number | 57-11-4     | 50      | True                | False         | Octadecanoic acid                                                                                                                      | Intentionally Added | Binder, Thickener                 |           |
	Then in the Ingredients page I click Continue

	#Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Then I should be on the Inventory Status, Prop 65 (US) Page
	And In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	And In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page, I click Continue

	Then I should be on the Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB) Page
	Then I see the following questions
		| Section                                                                                                                                        |
		| Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations. |
	Then The following options should be displayed for section: Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations.
		| Option |
		| Yes    |
		| No     |
	Then In the VOC - Ozone Transport Commission Section, set the option in section: 'Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations.': to: No
	Then I see the following questions
		| Section                                                                                                                                                       |
		| Product does not contain more than 0.05 grams of VOC per use, as defined in the California Consumer Products Regulation, Title 17, CCR Division 3, Chapter 1. |
	Then The following options should be displayed for section: Product does not contain more than 0.05 grams of VOC per use, as defined in the California Consumer Products Regulation, Title 17, CCR Division 3, Chapter 1.
		| Option   |
		| Agree    |
		| Disagree |
	Then In the VOC - Ozone Transport Commission Section, set the option in section: 'Product does not contain more than 0.05 grams of VOC per use, as defined in the California Consumer Products Regulation, Title 17, CCR Division 3, Chapter 1.': to: Agree
	Then in the Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB) page, I click Continue

	Then I should be on the Retailer Page
	Then in the Retailer page, I click Continue

	Then I should be on the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Yes, I certify that I have an OSHA-compliant SDS for this product and would like to upload it.
	Then In the Regulatory Documents to Provide Section, upload file in section: 'OSHA SDS'
	Then in the Regulatory Documents to Provide page, I click Continue

	Then I should be on the Additional Documents to Provide Page
	Then In the Additional Documents to Provide, upload PDF document to Upload Volatile Organic Compounds field
	Then in the Additional Documents to Provide page, I click Continue

	Then I should be on the Optional Reports and Documents Available for Purchase Page
	Then in the Optional Reports and Documents Available for Purchase page, I click Continue

	Then I should be on the Optional Comments Page
	Then in the Optional Comments page, I click Continue

	Then I should be on the Data Acceptance Page
	Then In the Data Acceptance Section, click 'Summary' button
	Then I switch to the tab with Data Summary page
	Then In the Summary Page, the 'Type of Product (select)' section should be showing the following value: Fabric Softener - Single Use Dryer Product Only
	Then In the Summary Page, the 'Which best describes your product, including when FIFRA 25(b) Exempt' section should be showing the following value: Product is not a pesticide and does not make or imply a pesticidal claim on the labeling or in the product description (ex. kills, sterilizes, disinfects, sanitizes, antimicrobial)
	Then In the Summary Page, the 'Cleaning products must comply with California's Cleaning Product Right to Know Act.' section should be showing the following value: Yes
	Then In the Summary Page, the 'Product does not contain more than 0.05 grams of VOC per use, as defined in the California Consumer Products Regulation, Title 17, CCR Division 3, Chapter 1.' section should be showing the following value: Agree
	Then I close the tab with Data Summary page

	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase208099
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase208099

# Created by Saikiran Chittampally
@TestCase:207582
Scenario: [207582] Personal Fragrance product (more than 20% fragrance) - Liquid (RU000756) - New Flow Testing
	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
#	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Then in the New Product page, I click Continue

	#Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Personal Fragrance Product (more than 20% fragrance) - Liquid
	Then I should see the The Product Page
	Then In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Personal Fragrance Product (more than 20% fragrance) - Liquid
	Then In the Product Section, set the option in section: 'Type of Product (select)' to: Personal Fragrance Product (more than 20% fragrance) - Liquid
	Then in the The Product page, I click Continue

	Then I save the product information as: TestCase207582
	#Given I call Shared Step 57798 (Product Information- Pesticide, Canada Only - No to everything else, Continue)
	Then I should see the Product Information Page
	Then In the Product Information Section, set the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' to not select: United States
	Then In the Product Information Section, set the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' to select: Canada
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page, I click Continue

	#Given I call Shared Step 70675 (Physical and Chemical Properties - Liquid Only - With Water Solubility - Enter all data - Continue)
	Given I should see the Physical and Chemical Properties Page
	Then In the Physical and Chemical Properties Section, set the option in section: 'Primary Physical State' to: Liquid
	Then In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Liquid
	Then In the Physical and Chemical Properties Section, for section: 'Relative Density' enter text: 1.0
	Then In the Physical and Chemical Properties Section, for section: 'pH' enter text: 10.2
	Then In the Physical and Chemical Properties Section, for section: 'Boiling Point (in Celsius)' enter text: 120
	Then In the Physical and Chemical Properties Section, for section: 'Flash Point (in Celsius)' enter text: 55
	Then In the Physical and Chemical Properties Section, set the option in section: 'Flash Point Testing Method Used' to: Closed cup method
	Then In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
	Then in the Physical and Chemical Properties page, I click Continue

	#Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Propane
	Given I should see the Ingredients Page
	Then In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	| component name | Water       | 100     |                     |               |             |
	Then in the Ingredients page I click Continue

	#Given I call Shared Step 57911 (Regulatory Information 1 - CEPA only shown - Continue - Happy Path)
	Given I should see the Inventory Status, Prop 65 (US) Page
	Then In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'Canadian Environmental Protection Act (CEPA) status' to: Compliant with Domestic Substances List (DSL)
	Then in the Inventory Status, Prop 65 (US) page I click Continue

	Then I should see the Pesticide Details - Canada Page
	Given I set the Provide Canada's 5-Digit Pest Control Number (PCN) or 8-Digit Drug Identification Number (DIN) for this product field to: 27925
	And The following options should be displayed for section: Product's packaging includes a Poison Danger symbol
		| Option |
		| Yes    |
		| No     |
	Given I set the Product's packaging includes a Poison Danger symbol option to: No
	Given I set the Alberta option to: Schedule 1
	Given I set the British Columbia option to: Commercial
	Given I set the Manitoba option to: Commercial
	Given I set the New Brunswick option to: None
	Given I set the New Foundland and Labrador option to: Domestic
	Given I set the Nova Scotia option to: Commercial
	Given I set the Ontario option to: Class A: Manufacturing Products
	Given I set the Prince Edward Island option to: Controlled Purchase
	Given I set the Quebec option to: Class 1
	Given I set the Saskatchewan option to: Commercial
	Given I set the Northwest Territory option to: Not Applicable 
	Given I set the Yukon Territory option to: Commercial
	Then I click continue
	#Given I call Shared Step 57506 (Transportation Details 1 - Regulated for Transport(No) - Exemption(Random) - Continue - Happy Path)
	Then I should be on the Transportation Details 1 Page
	And In the Transportation Details 1 Section, set the option in section: 'Product is Regulated for Transport': to: No, due to an exemption or exception
	And In the Transportation Details 1 Section, set the option in section: 'Please select DOT Exceptions if applicable?': to: 173.120(b)(3):  Combustible liquid that does not sustain combustion
	Then in the Transportation Details 1 page, I click Continue

	#Given I call Shared Step 62536 (Transportation Details 2 > I do not ship internationally > Continue - Happy Path)
	Then I should be on the Transportation Details 2 Page
	And In the Transportation Details 2 Section, set the option in section: 'International Shipping when DOT Exemption taken?': to: I do not ship internationally and I do not know the classification
	Then in the Transportation Details 2 page, I click Continue

	And I call Shared Step 62710 (Confirm VOC OTC/CARB heading and select No to FIRST QUESTION ONLY - Happy Path)
	Then I click continue
	Given Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the CARB should be showing the error messages: This is a required field.
	And I set the Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the CARB option to: 50
	Then Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the CARB should should not be showing any error messages
	Then I click continue
	Given I call Shared Step 57801 (Confirm VOC Summary step shown and VOC analysis date is shown - Happy Path)
	And I confirm that statement with text: 'Based on your selection, you have verified your product contains VOC with intended uses as follows.  The CARB VOC compliance limit(s) for the intended use you identified is/are:' is not displayed
	Then in the VOC Limits table, the Use column should contain the value: Personal Fragrance Product (more than 20% fragrance) - Liquid
	Then in the VOC Limits table, the VOC Compliance Limit column should contain the value: 65
	Then in the VOC Limits table, the Regulation column should contain the value: CARB limit
	And I should see the following Voc percent for each state:
		| State           | Regulation            | VOC Value | State VOC Threshold | Message                          |
		| Canada          | State Allowable Limit | 0         | 65                  | Does not exceed the State Limits |
	Then I confirm that I see the following CARB value: 50
	Then The VOC Summary page contains the statement with the text: Based on the type of product, this must comply with the most restrictive VOC limit.
	Then The VOC Summary page contains the statement with the text: Does not exceed the limits specified in the California Consumer Products Regulation
	Given I set the Your acknowledgement of this registration includes that your product option to: Yes, I Acknowledge
	Given in the Volatile Organic Compound Summary page I click Continue
	Given I call Shared Step 150905 (Retailer - NR selected by default)
	Given I call Shared Step 78884 - Regulatory Documents to Provide - Canada only - request authoring, upload label - Continue
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	#And I call Shared Step 64097 - Additional Documents -> Contact Information - Add any Name, address, phone and emergency phone - Happy Path
	Then I should be on the Additional Documents -> Contact Information Page
	And In the Additional Documents -> Contact Information section, for section: 'Manufacturer Name' enter text: Manufacturer
	And In the Additional Documents -> Contact Information section, for section: 'Address' enter text: Address
	And In the Additional Documents -> Contact Information section, for section: 'Phone' enter text: Phone
	And In the Additional Documents -> Contact Information section, for section: 'Emergency Phone' enter text: Emergency Phone
	Then in the Additional Documents -> Contact Information page, I click Continue

	Given I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
		| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
	Given in the Optional Comments page I click Continue
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Personal Fragrance Product (more than 20% fragrance) - Liquid
	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase207582
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase207582

# Created by Saikiran Chittampally
@TestCase:207584
Scenario: [207584] Personal Fragrance product (20% or less fragrance) - Liquid - Canada Only (RU000755) - New Flow Testing
	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
#	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Then in the New Product page, I click Continue

	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Personal Fragrance Product (20% or less fragrance) - Liquid
	Then I save the product information as: TestCase207584
	#Given I call Shared Step 57798 (Product Information- Pesticide, Canada Only - No to everything else, Continue)
	Then I should see the Product Information Page
	Then In the Product Information Section, set the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' to not select: United States
	Then In the Product Information Section, set the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' to select: Canada
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page, I click Continue

	#Given I call Shared Step 70675 (Physical and Chemical Properties - Liquid Only - With Water Solubility - Enter all data - Continue)
	Given I should see the Physical and Chemical Properties Page
	Then In the Physical and Chemical Properties Section, set the option in section: 'Primary Physical State' to: Liquid
	Then In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Liquid
	Then In the Physical and Chemical Properties Section, for section: 'Relative Density' enter text: 1.0
	Then In the Physical and Chemical Properties Section, for section: 'pH' enter text: 10.2
	Then In the Physical and Chemical Properties Section, for section: 'Boiling Point (in Celsius)' enter text: 120
	Then In the Physical and Chemical Properties Section, for section: 'Flash Point (in Celsius)' enter text: 55
	Then In the Physical and Chemical Properties Section, set the option in section: 'Flash Point Testing Method Used' to: Closed cup method
	Then In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
	Then in the Physical and Chemical Properties page, I click Continue

	#Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Propane
	Given I should see the Ingredients Page
	Then In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	| component name | Propane       | 100     |                     |               |             |
	Then in the Ingredients page I click Continue

	Given I call Shared Step 57911 (Regulatory Information 1 - CEPA only shown - Continue - Happy Path)
	Then I should see the Pesticide Details - Canada Page
	Given I set the Provide Canada's 5-Digit Pest Control Number (PCN) or 8-Digit Drug Identification Number (DIN) for this product field to: 27925
	And The following options should be displayed for section: Product's packaging includes a Poison Danger symbol
		| Option |
		| Yes    |
		| No     |
	Given I set the Product's packaging includes a Poison Danger symbol option to: No
	Given I set the Alberta option to: Schedule 1
	Given I set the British Columbia option to: Commercial
	Given I set the Manitoba option to: Commercial
	Given I set the New Brunswick option to: None
	Given I set the New Foundland and Labrador option to: Domestic
	Given I set the Nova Scotia option to: Commercial
	Given I set the Ontario option to: Class A: Manufacturing Products
	Given I set the Prince Edward Island option to: Controlled Purchase
	Given I set the Quebec option to: Class 1
	Given I set the Saskatchewan option to: Commercial
	Given I set the Northwest Territory option to: Not Applicable 
	Given I set the Yukon Territory option to: Commercial
	Then I click continue
	#Given I call Shared Step 57506 (Transportation Details 1 - Regulated for Transport(No) - Exemption(Random) - Continue - Happy Path)
	Then I should be on the Transportation Details 1 Page
	And In the Transportation Details 1 Section, set the option in section: 'Product is Regulated for Transport': to: No, due to an exemption or exception
	And In the Transportation Details 1 Section, set the option in section: 'Please select DOT Exceptions if applicable?': to: 173.120(b)(3):  Combustible liquid that does not sustain combustion
	Then in the Transportation Details 1 page, I click Continue

	#Given I call Shared Step 62536 (Transportation Details 2 > I do not ship internationally > Continue - Happy Path)
	Then I should be on the Transportation Details 2 Page
	And In the Transportation Details 2 Section, set the option in section: 'International Shipping when DOT Exemption taken?': to: I do not ship internationally and I do not know the classification
	Then in the Transportation Details 2 page, I click Continue

	And I call Shared Step 62710 (Confirm VOC OTC/CARB heading and select No to FIRST QUESTION ONLY - Happy Path)
	Then I click continue
	Given Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the CARB should be showing the error messages: This is a required field.
	And I set the Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the CARB option to: 50
	Then Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the CARB should should not be showing any error messages
	Then I click continue
	Then I should see the Volatile Organic Compound Summary Page
	Given I call Shared Step 57801 (Confirm VOC Summary step shown and VOC analysis date is shown - Happy Path)
	And I confirm that statement with text: 'Based on your selection, you have verified your product contains VOC with intended uses as follows.  The CARB VOC compliance limit(s) for the intended use you identified is/are:' is not displayed
	Then in the VOC Limits table, the Use column should contain the value: Personal Fragrance Product (20% or less fragrance) - Liquid
	Then in the VOC Limits table, the VOC Compliance Limit column should contain the value: 75
	Then in the VOC Limits table, the Regulation column should contain the value: CARB limit
	And I should see the following Voc percent for each state:
		| State           | Regulation            | VOC Value | State VOC Threshold | Message                          |
		| Canada          | State Allowable Limit | 0         | 75                  | Does not exceed the State Limits |
	Then I confirm that I see the following CARB value: 50
	Then The VOC Summary page contains the statement with the text: Based on the type of product, this must comply with the most restrictive VOC limit.
	Then The VOC Summary page contains the statement with the text: Does not exceed the limits specified in the California Consumer Products Regulation
	Given I set the Your acknowledgement of this registration includes that your product option to: Yes, I Acknowledge
	Given in the Volatile Organic Compound Summary page I click Continue
	Given I call Shared Step 150905 (Retailer - NR selected by default)
	Given I call Shared Step 78884 - Regulatory Documents to Provide - Canada only - request authoring, upload label - Continue
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	#And I call Shared Step 64097 - Additional Documents -> Contact Information - Add any Name, address, phone and emergency phone - Happy Path
	Then I should be on the Additional Documents -> Contact Information Page
	And In the Additional Documents -> Contact Information section, for section: 'Manufacturer Name' enter text: Manufacturer
	And In the Additional Documents -> Contact Information section, for section: 'Address' enter text: Address
	And In the Additional Documents -> Contact Information section, for section: 'Phone' enter text: Phone
	And In the Additional Documents -> Contact Information section, for section: 'Emergency Phone' enter text: Emergency Phone
	Then in the Additional Documents -> Contact Information page, I click Continue

	Given I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
		| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
	Given in the Optional Comments page I click Continue
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Personal Fragrance Product (20% or less fragrance) - Liquid
	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase207584
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase207584
