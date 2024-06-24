@Shared
@Login
@Homepage
@Signup
@wercsmart
@NewProduct
@ProductGrid
@DataSummarySheet
@wercsmart
@RetailPartners
@NewProduct
@run_voc
@StepsPrototype
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:NewProduct
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:ProductInformation
@PhysicalAndChemicalProp
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:InventoryStatusProp65
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:RegulatoryDocumentsToProvide
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:OptionalComments
@Ingredients
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:PesticideDetailsUS
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:TransportationDetails1

@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:ECOLOGO
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:InventoryStatusProp65

Feature: VOC

@test74626
@TestCase:74626
Scenario: [74626] VOC - Show state collection when state table has a value
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	#Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Then in the New Product page, I click Continue

	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Insecticide - Fogger
	Then I save the product information as: TestCase74626
	#Given I call Shared Step 57865 (Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
	Given I should see the Product Information Page
	Then In the Product Information Section, set the option in section: 'Which best describes your product, including when FIFRA 25(b) Exempt' to: Product is intended for preventing, destroying, repelling, or mitigating pests (including insects, rodents, mold, virus, bacteria, and other micro-organisms)
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue

	Then I call Shared Step 57454 (Physical and Chemical Properties - Aerosol & Gas available - Select Aerosol - Continue - Happy Path)
	Given I call Shared Step 69557 (Enter Ingredients for Aerosol Propellent)
	#And I call Shared Step 132370 (Waste Classification Data - TSCA (Random) - Prop 65 (No) - Continue - Happy Path)
	Given I should see the Inventory Status, Prop 65 (US) Page
	Then In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	Then In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page I click Continue

	#Given I call Shared Step 57589 (Enter Pesticide Data - United States (without EPA number))
	Given I should see the Pesticide Details - U.S. Page
	Then In the Pesticide Details - U.S. Section, in 'Product has an Environmental Protection Agency (EPA) Registration Number' enter No
	Then In the Pesticide Details - U.S. Section, in 'Product has a State Registration' enter No
	Then In the Pesticide Details - U.S. Section, in 'Select the applicable exemption' enter Food Based Pesticides - Exempt from EPA Registration
	Then in the Pesticide Details - U.S. page I click Continue

	#Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	Given I should see the Transportation Details 1 Page
	Then In the Transportation Details 1 Section, set the option in section: 'Product is Regulated for Transport': to: Yes
	Then In the Transportation Details 1 Section, set the option in section: 'Select all modes of transport that you've classified the product for': to: DOT
	Then In the Transportation Details 1 Section, set the option for DOT mode of transport to: Shipping with limited quantity
	Then in the Transportation Details 1 page I click Continue

	Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)
	Given I call Shared Step 57923 (Volatile Organic Compound (VOC) Step - enter OTC and CARB - Yes for state values)
		| Product granted Alternative Control Plan | Amount of VOC by CARB | Amount of VOC by OTC Model | VOC for states |
		| No                                       | 0                     | 0                          | Yes            |
	And I should see the following Voc percent for each state:
		| State           | Regulation            | VOC Value | State VOC Threshold | Message                          |
		| Connecticut     | State Allowable Limit | 0         | 45                  | Does not exceed the State Limits |
		| Delaware        | State Allowable Limit | 0         | 45                  | Does not exceed the State Limits |
		| Illinois        | State Allowable Limit | 0         | 45                  | Does not exceed the State Limits |
		| Indiana         | State Allowable Limit | 0         | 45                  | Does not exceed the State Limits |
		| Massachusetts   | State Allowable Limit | 0         | 45                  | Does not exceed the State Limits |
		| Maryland        | State Allowable Limit | 0         | 45                  | Does not exceed the State Limits |
		| Maine           | State Allowable Limit | 0         | 45                  | Does not exceed the State Limits |
		| Michigan        | State Allowable Limit | 0         | 45                  | Does not exceed the State Limits |
		| New Hampshire   | State Allowable Limit | 0         | 45                  | Does not exceed the State Limits |
		| New Jersey      | State Allowable Limit | 0         | 45                  | Does not exceed the State Limits |
		| New York        | State Allowable Limit | 0         | 45                  | Does not exceed the State Limits |
		| Ohio            | State Allowable Limit | 0         | 45                  | Does not exceed the State Limits |
		| Pennsylvania    | State Allowable Limit | 0         | 45                  | Does not exceed the State Limits |
		| Rhode Island    | State Allowable Limit | 0         | 45                  | Does not exceed the State Limits |
		| Utah            | State Allowable Limit | 0         | 45                  | Does not exceed the State Limits |
		| Virginia        | State Allowable Limit | 0         | 45                  | Does not exceed the State Limits |
		| Vermont         | State Allowable Limit | 0         | 45                  | Does not exceed the State Limits |
	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase74626
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase74626
@TestCase:56475
Scenario: [56475] VOC checks for Fabric Softener - single Use dryer product (RU000808)
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	#Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Then in the New Product page, I click Continue

	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Fabric Softener - Single Use Dryer Product Only
	Then I save the product information as: TestCase56475
	#Given I call Shared Step 57401 (Product Information - US only - No GHS, Not Direct Ship, Not PLP, Not GNFR > Continue - Happy Path)
	Given I should see the Product Information Page
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
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

	#Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Formaldehyde
	Given I should see the Ingredients Page
	Then In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	| component name | Formaldehyde       | 100     |                     |               |             |
	Then in the Ingredients page I click Continue

	#Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Then I should be on the Inventory Status, Prop 65 (US) Page
	And In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	And In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page, I click Continue

	Then I should see the Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB) Page
	Then I see the following questions
		| Section                                                                                                                                        |
		| Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations. |
	Then The following options should be displayed for section: Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations.
		| Option |
		| Yes    |
		| No     |
	And in the New Product page I click Continue
	Then Product has been granted an Alternative Control Plan should be showing the error messages: This is a required field.
	Given I set the Product has been granted an Alternative Control Plan option to: No
	Then I see the following questions
		| Section                                                                                                                                                       |
		| Product does not contain more than 0.05 grams of VOC per use, as defined in the California Consumer Products Regulation, Title 17, CCR Division 3, Chapter 1. |
	Then I should see a total of 2 radio buttons for the section: Product does not contain more than 0.05 grams
	Then The following options should be displayed for section: Product does not contain more than 0.05 grams
		| Option   |
		| Agree    |
		| Disagree |
	Given in the New Product page I click Continue
	Then Product does not contain more than 0.05 grams of VOC per use should be showing the error messages: This is a required field.
	Given I set the Product does not contain more than 0.05 grams of VOC per use option to: Disagree
	Given in the New Product page I click Continue
	# Confirm the VOC Summary page is NOT shown (because there are no results for show for this RU)
	# If the Ecologo step is shown run the Shared Step below - if not continue at step 35
	# Shared 57712
	#Given If ECOLOGO Readiness page is displayed I call Shared Step 57712 - ECOLOGO Readiness Assessment - Not at this time - Continue - Happy Path
	Then I should be on the ECOLOGO Readiness Page
	And In the ECOLOGO Readiness Section, set the option in section: 'Take advantage of Premium Subscription benefits by electing to receive a UL ECOLOGO Readiness Assessment...': to: Not at this time
	Then in the ECOLOGO Readiness page, I click Continue

	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	#Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
	Then in the Regulatory Documents to Provide page I click Continue

	Then I should see the Additional Documents to Provide Page
	Then I see the following sections
		| Section                                           |
		| Volatile Organic Compounds                        |
		| Toxicity Characteristic Leaching Procedure (TCLP) |
	Given in the New Product page I click Continue
	Then I should see an error message: Document is required: Product Label
	Then Toxicity Characteristic Leaching Procedure (TCLP) should not be showing any error messages
	#Given I call Shared Step 60567 (Upload Product Label only)
	Given I should see the Regulatory Documents to Provide Page
	Given in the Regulatory Documents to Provide page I click Continue
	Then In the Regulatory Documents to Provide Section: 'Upload Full Product Label (required) (For private label products please upload a generic label that is not retailer-specific.)' error message should display: Document is required: Product Label
	Then In the Regulatory Documents to Provide Section, upload file in section: 'Upload Full Product Label (required) (For private label products please upload a generic label that is not retailer-specific.)'
	Given in the Regulatory Documents to Provide page I click Continue

	Then I should see the Optional Reports and Documents Available for Purchase Page
	Given in the New Product page I click Continue
	Then I should see the Safety Data Sheet Authoring - Additional Data (Optional) Page
	Given I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
		| Goggles                       | 500                      | 45                      | 15.0      | Black      | Odorless | No data available | 5                     |
	#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test data
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Fabric Softener - Single Use Dryer Product Only
	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase56475
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase56475
@TestCase:56477
Scenario: [56477] VOC checks for Charcoal lighter material (RU000743)
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	# Checking that the test will run correctly by handling extra screens
	Given If I see the retail partners page I set all data consent tiers to true for all retailers in the top section
	Then The home screen should load
	# New Product Page
	And I click the Register New Product icon in the Navigation Pane
	And I should see the New Product Page
	And I set the Select the type of product to create option to: Create a New Registration
	And in the New Product page I click Continue
	# The Product Page
	And I should see the The Product Page
	And I set the Product Name option to: Charcoal Lighter Material
	#And In the Product Type tab of the New Product Page, I enter: Charcoal Lighter Material in the Type of Product select field
	And I set 'Type of Product' to: Charcoal Lighter Material
	And in the New Product page I click Continue
# Product Information page
	And I should see the Product Information Page
	And In the Information Page the check box for: United States should be: checked
	And I set the Product has been classified using OSHA (US) option to: No
	And I set the Product is shipped directly by supplier to the consumer option to: No
	And I set the Product is a Retailer's Private Label or Brand option to: No
	And I set the Product is sold to the Retailer solely for the Retailer's use option to: No
	And in the New Product page I click Continue
	# Physical and Chemical Properties Page
	And I should see the Physical and Chemical Properties Page
	Then I save the product information as: TestCase56477
	And I should only see the following options for Primary Physical State:
		| State  |
		| Liquid |
	And I set the Secondary Physical State option to: Liquid
	And I set the Relative Density option to: 2
	And I set the pH option to: 2
	And I set the Boiling Point (in Celsius) option to: 2
	And I set the Flash Point (in Celsius) option to: 2
	And I set the Flash Point Testing Method Used option to: Closed cup method
	And I set the Select the best Water Solubility description option to: Dispersible
	And in the New Product page I click Continue
		# Ingredient Page
	And I should see the Ingredients Page
	Then I add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Water         | 100     | false               | false       |            |
	Given in the New Product page I click Continue
	# Regulatory 1 Page Details
	And I should see the Waste Classification Data Page
	And I set the U.S. Toxic Substances Control Act (TSCA) status option to: Compliant
	And I set 'Prop65' to: No
	Given in the New Product page I click Continue
	# Transportation Details 1 Page
	And I should see the Transportation Details 1 Page
	And in the Product Characteristics tab of the New Product Page, for Product is Regulated for Transport I select: No, due to an exemption or exception
	And in the Product Characteristics tab of the New Product Page, for DOT Exceptions I select: 173.120(b)(3): Combustible liquid that does not sustain combustion
	Given in the New Product page I click Continue
	# Transportation Details 2 Page
	And I should see the Transportation Details 2 Page
	And I set the International Shipping when DOT Exemption taken? option to: I do not ship internationally and I do not know the classification
	Given in the New Product page I click Continue
	# Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB) Page
	And I should see the Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB) Page
	And I set the Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations. option to: No
	And I confirm that I see the following VOC Content below threshold CARB statement: Verify VOC content is below the threshold of 0.02lb/start of CARB
	And I confirm that I see the following VOC Content below threshold OTC statement: Verify VOC content is below the threshold of 0.02lb/start of OTC
	Given in the New Product page I click Continue
	Then Verify VOC content is below the threshold of 0.02lb/start of CARB should be showing the error messages: This is a required field.
	Then Verify VOC content is below the threshold of 0.02lb/start of OTC should be showing the error messages: This is a required field.
	And I set the Verify VOC content is below the threshold of 0.02lb/start of CARB option to: No
	Then Verify VOC content is below the threshold of 0.02lb/start of CARB should not be showing the error messages: This is a required field.
	And I set the Verify VOC content is below the threshold of 0.02lb/start of OTC option to: No
	Then Verify VOC content is below the threshold of 0.02lb/start of OTC should not be showing the error messages: This is a required field.
	Given in the New Product page I click Continue
	# Volatile Organic Compound Summary page
	And I should see the Volatile Organic Compound Summary Page
	And I confirm that I see todays VOC Analysis Date
	And I should see the following Voc Limits with units  present:
		| Use                       | VOC Compliance Limit | Units    | Regulation           |
		| Charcoal Lighter Material | 0.02                 | lb/start | OTC Model rule limit |
		| Charcoal Lighter Material | 0.02                 | lb/start | CARB limit           |
	And I confirm statement: Based on the type of product shows the text: Based on the type of product, this must comply with the most restrictive VOC limit.
	And I confirm statement: limits specified by CARB shows the text: Exceeds the limits specified by CARB
	And I confirm statement: limits specified by OTC shows the text: Exceeds the limits specified by OTC Model Rule
	# Change the CARB  and OTC threshold options
	Then I click the page heading: Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB)
	And I set the Verify VOC content is below the threshold of 0.02lb/start of CARB option to: Yes
	And I set the Verify VOC content is below the threshold of 0.02lb/start of OTC option to: Yes
	And in the New Product page I click Continue
	And I confirm statement: limits specified by CARB shows the text: Does not exceed the limits specified by CARB
	And I confirm statement: limits specified by OTC shows the text: Does not exceed the limits specified by OTC Model Rule
	Given I set the Your acknowledgement of this registration includes that your product option to: Yes, I Acknowledge

	And in the New Product page I click Continue
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	# Regulatory Documents to Provide Page
	And I should see the Regulatory Documents to Provide Page
	And in the Review and Submit tab of the New Product Page for OSHA compliant SDS I select: Request to author
	And in the New Product page I click Continue
	# Additional Documents to Provide Page
	And I should see the Additional Documents to Provide Page
	And in the New Product page I click Continue
	Then Volatile Organic Compounds should be showing the error messages: Document is required: Product Label
	And I click the browse button for label: Product Label and upload PDF: UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf
	And in the New Product page I click Continue
	# Optional Reports and Documents Available for Purchase Page
	And I should see the Optional Reports and Documents Available for Purchase Page
	And in the New Product page I click Continue
	# Safety Data Sheet Authoring - Additional Data (Optional) Page
	And I should see the Safety Data Sheet Authoring - Additional Data (Optional) Page
	And I set the Appearance field to: Brown
	And I set the Odor field to: Banana
	And I set the Odor Threshold field to: Not applicable
	And I set the Partition Coefficient field to: 5
	And in the New Product page I click Continue
	# Comments Page
	And I should see the Optional Comments Page
	And in the New Product page I click Continue
	# Data Acceptance Page and clean up
	And I should see the Data Acceptance Page
	Given I navigate to the home page
	Then I delete the product: TestCase56477

@TestCase:56481
Scenario: [56481] VOC checks for Oven Cleaner - pump sprays (RU000798) - CARB and OTC
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	#Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Then in the New Product page, I click Continue

	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Oven Cleaner - Pump Sprays
	Then I save the product information as: TestCase56481
	#Given I call Shared Step 57401 (Product Information - US only - No GHS, Not Direct Ship, Not PLP, Not GNFR > Continue - Happy Path)
	Given I should see the Product Information Page
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue
	Given I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
	#Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Formaldehyde
	Given I should see the Ingredients Page
	Then In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	| component name | Formaldehyde       | 100     |                     |               |             |
	Then in the Ingredients page I click Continue

#	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Then I should be on the Inventory Status, Prop 65 (US) Page
	And In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	And In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page, I click Continue

	Given I call Shared Step 57506 (Transportation Details 1 - Regulated for Transport(No) - Exemption(Random) - Continue - Happy Path)
	Given I call Shared Step 62536 (Transportation Details 2 > I do not ship internationally > Continue - Happy Path)
	Given I call Shared Step 62710 (Confirm VOC OTC/CARB heading and select No to FIRST QUESTION ONLY - Happy Path)
	Then I see the following sections
		| Section                                                                                                                      |
		| Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the CARB           |
		| Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the OTC Model Rule |
		| Would you like to use the VOC percentages entered for all areas (e.g. country, state, local) for comparison?                 |
	Then The following options should be displayed for section: Would you like to use the VOC percentages entered for all areas (e.g. country, state, local) for comparison?
		| Option                                                      |
		| Yes                                                         |
		| No, I would like to manually enter VOC value for each area. |
	Given in the New Product page I click Continue
	Then Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the CARB should be showing the error messages: This is a required field.
	Then Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the OTC Model Rule should be showing the error messages: This is a required field.
	Then Would you like to use the VOC percentages entered for all areas (e.g. country, state, local) for comparison? should be showing the error messages: This is a required field.
	Given I set the Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the CARB option to: 40
	Then Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the CARB should not be showing the error messages: This is a required field.
	Given I set the Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the OTC Model Rule option to: 5
	Then Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the OTC Model Rule should not be showing the error messages: This is a required field.
	Given I set the Would you like to use the VOC percentages option to: Yes
	Then Would you like to use the VOC percentages entered for all areas (e.g. country, state, local) for comparison? should not be showing the error messages: This is a required field.
	Given in the New Product page I click Continue
	Given I call Shared Step 57801 (Confirm VOC Summary step shown, Confirm VOC analysis date is shown - Happy Path)
	Then I confirm the VOC limits table has an entry for Regulation: CARB
	Then I confirm the VOC limits table has an entry for Regulation: OTC
	Then I should see data for States in the 'VOC Content as weight percentage of total formula' table
	Then I confirm that I see the following CARB value: 40
	Then I confirm that I see the following OTC Model Rule value: 5
	Then I confirm statement: Based on the type of product shows the text: Based on the type of product, this must comply with the most restrictive VOC limit.
	And I confirm the Exceeds/Does not exceed statement is shown and is correct based on inputted CARB value: 40
	And I confirm the Exceeds/Does not exceed statement is shown and is correct based on inputted OTC value: 5
	Given I set the Your acknowledgement of this registration includes that your product option to: Yes, I Acknowledge
	Given in the New Product page I click Continue
	# If your supplier account is on Premium subscription you will see the Ecologo step - perform the Shared Step below if you do, if not skip to step 43
	#Given If ECOLOGO Readiness page is displayed I call Shared Step 57712 - ECOLOGO Readiness Assessment - Not at this time - Continue - Happy Path
	Then I should be on the ECOLOGO Readiness Page
	And In the ECOLOGO Readiness Section, set the option in section: 'Take advantage of Premium Subscription benefits by electing to receive a UL ECOLOGO Readiness Assessment...': to: Not at this time
	Then in the ECOLOGO Readiness page, I click Continue

	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	#Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
	Then in the Regulatory Documents to Provide page I click Continue

	Then I should see the Additional Documents to Provide Page
	Then I see the following sections
		| Section                    |
		| Volatile Organic Compounds |
	Given in the New Product page I click Continue
	Then I should see an error message: Document is required: Product Label
	#Given I call Shared Step 60567 (Upload Product Label only)
	Given I should see the Regulatory Documents to Provide Page
	Given in the Regulatory Documents to Provide page I click Continue
	Then In the Regulatory Documents to Provide Section: 'Upload Full Product Label (required) (For private label products please upload a generic label that is not retailer-specific.)' error message should display: Document is required: Product Label
	Then In the Regulatory Documents to Provide Section, upload file in section: 'Upload Full Product Label (required) (For private label products please upload a generic label that is not retailer-specific.)'
	Given in the Regulatory Documents to Provide page I click Continue

	Then I should see the Optional Reports and Documents Available for Purchase Page
	Given in the New Product page I click Continue
	Then I should see the Safety Data Sheet Authoring - Additional Data (Optional) Page
	Given I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
		| Gloves                        | 100                      | 250                     | 1200      | Black      | Odorless | No data available | 50                    |
	#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: User added Comments Text 74992. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	Then The Data Acceptance page should appear
	Then In the Data Acceptance page I select Agreed
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Oven Cleaner - Pump Sprays
	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase56481
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase56481
@TestCase:56483
Scenario: [56483] VOC - Antiperspirant and Deodorant checks
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	# Checking that the test will run correctly by handling extra screens
	Given If I see the retail partners page I set all data consent tiers to true for all retailers in the top section
	Then The home screen should load
	# New Product Page
	And I click the Register New Product icon in the Navigation Pane
	And I should see the New Product Page
	And I set the Select the type of product to create option to: Create a New Registration
	And in the New Product page I click Continue
	# The Product Page
	And I should see the The Product Page
	And I set the Product Name option to: Antiperspirants - Non-aerosol
	#And In the Product Type tab of the New Product Page, I enter: Antiperspirants - Non-aerosol in the Type of Product select field
	And I set 'Type of Product' to: Antiperspirants - Non-aerosol
	And in the New Product page I click Continue
	# Product Information page
	And I should see the Product Information Page
	And In the Information Page the check box for: United States should be: checked
	And I set the Product has been classified using OSHA (US) option to: No
	And I set the Product is shipped directly by supplier to the consumer option to: No
	And I set the Product is a Retailer's Private Label or Brand option to: No
	And I set the Product is sold to the Retailer solely for the Retailer's use option to: No
	And in the New Product page I click Continue
	# Physical and Chemical Properties Page
	And I should see the Physical and Chemical Properties Page
	Then I save the product information as: TestCase56483
	And I should only see the following options for Primary Physical State:
		| State  |
		| Liquid |
		| Solid  |
	And I set the Primary Physical State option to: Solid
	And I set the Secondary Physical State option to: Solid
	And I set the When mixed with an equal amount of water option to: No
	And I set the Select the best Water Solubility description option to: Dispersible
	And in the New Product page I click Continue
	# Ingredient Page
	And I should see the Ingredients Page
	Then I add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Water         | 100     | false               | false       |            |
	Given in the New Product page I click Continue
	# Regulatory 1 Page Details
	And I should see the Waste Classification Data Page
	And I set the U.S. Toxic Substances Control Act (TSCA) status option to: Compliant
	And I set 'Prop65' to: No
	Given in the New Product page I click Continue
	# Regulatory 3 Page Details
	And I should see the Regulatory Information 3 Page
	And I set the below options for field: Refer to your Product Label
		| Option            |
		| None of the Above |
	Given in the New Product page I click Continue
	# Transportation Details 1 Page
	And I should see the Transportation Details 1 Page
	And I set the Product is Regulated for Transport option to: Not Regulated
	Given in the New Product page I click Continue
	# Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB) Page
	And I should see the Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB) Page
	And I set the Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations. option to: No
	And in the New Product page I click Continue
	Then HVOC (high volatile organic compound) content as weight percent of the total formulation should be showing the error messages: This is a required field.
	Then MVOC (medium volatile organic compound) content as weight percentage of the total formulation should be showing the error messages: This is a required field.
	And I set the HVOC (high volatile organic compound) content as weight percent of the total formulation field to: 1
	And I set the MVOC (medium volatile organic compound) content as weight percentage of the total formulation field to: 1
	And in the New Product page I click Continue
	# Volatile Organic Compound Summary page
	And I should see the Volatile Organic Compound Summary Page
	And I confirm that I see todays VOC Analysis Date
	And I should see the following Voc Limits present:
		| Use                           | VOC Compliance Limit | Regulation                         |
		| Antiperspirants - Non-aerosol | 0                    | HVOC CARB and OTC Model Rule limit |
		| Antiperspirants - Non-aerosol | 0                    | MVOC CARB and OTC Model Rule limit |
	And I confirm that I see the following HVOC value: 1
	And I confirm that I see the following MVOC value: 1
	And I confirm statement: Based on the type of product shows the text: Based on the type of product, this must comply with the most restrictive VOC limit.
	And I confirm statement: limits specified shows the text: Exceeds the limits specified by CARB and OTC Model Rule
	#change the HVOC and MVOC value
	Then I click the page heading: Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB)
	And I set the HVOC (high volatile organic compound) content as weight percent of the total formulation field to: 0
	And I set the MVOC (medium volatile organic compound) content as weight percentage of the total formulation field to: 0
	And in the New Product page I click Continue
	And I confirm statement: limits specified shows the text: Does not exceed the limits specified by CARB and OTC Model Rule
	Given I set the Your acknowledgement of this registration includes that your product option to: Yes, I Acknowledge
	And in the New Product page I click Continue
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	# Regulatory Documents to Provide Page
	And I should see the Regulatory Documents to Provide Page
	And in the Review and Submit tab of the New Product Page for OSHA compliant SDS I select: Request to author
	And in the New Product page I click Continue
	# Additional Documents to Provide Page
	And I should see the Additional Documents to Provide Page
	And in the New Product page I click Continue
	Then Volatile Organic Compounds should be showing the error messages: Document is required: Product Label
	And I click the browse button for label: Product Label and upload PDF: UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf
	And in the New Product page I click Continue
	# Optional Reports and Documents Available for Purchase Page
	And I should see the Optional Reports and Documents Available for Purchase Page
	And in the New Product page I click Continue
	# Safety Data Sheet Authoring - Additional Data (Optional) Page
	And I should see the Safety Data Sheet Authoring - Additional Data (Optional) Page
	And I set the Appearance field to: Brown
	And I set the Odor field to: Banana
	And I set the Odor Threshold field to: Not applicable
	And I set the Partition Coefficient field to: 5
	And in the New Product page I click Continue
	# Comments Page
	And I should see the Optional Comments Page
	And in the New Product page I click Continue
	# Data Acceptance Page and clean up
	And I should see the Data Acceptance Page
	Given I navigate to the home page
	Then I delete the product: TestCase56483

@TestCase:56484
Scenario: [56484] VOC - Aero checks
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	# Checking that the test will run correctly by handling extra screens
	Given If I see the retail partners page I set all data consent tiers to true for all retailers in the top section
	Then The home screen should load
	# New Product Page
	And I click the Register New Product icon in the Navigation Pane
	And I should see the New Product Page
	And I set the Select the type of product to create option to: Create a New Registration
	And in the New Product page I click Continue
	# The Product Page
	And I should see the The Product Page
	And I set the Product Name option to: Clear Coating - Aerosol
	#And In the Product Type tab of the New Product Page, I enter: Clear Coating - Aerosol in the Type of Product select field
	And I set 'Type of Product' to: Clear Coating - Aerosol
	And in the New Product page I click Continue
	# Product Information page
	And I should see the Product Information Page
	And In the Information Page the check box for: United States should be: checked
	And I set the Product has been classified using OSHA (US) option to: No
	And I set the Product is shipped directly by supplier to the consumer option to: No
	And I set the Product is a Retailer's Private Label or Brand option to: No
	And I set the Product is sold to the Retailer solely for the Retailer's use option to: No
	And in the New Product page I click Continue
	# Physical and Chemical Properties Page
	And I should see the Physical and Chemical Properties Page
	Then I save the product information as: TestCase56484
	And I should only see the following options for Primary Physical State:
		| State   |
		| Aerosol |
	And I set the Secondary Physical State option to: Solid spray
	And I set the pH option to: 2
	And I set the Select the best Water Solubility description option to: Dispersible
	And I set the When the product has a flammable propellant, or contains ingredients with a flash point below 60⁰C then option to: This product is not classified as D001 or D003 Hazardous Waste under RCRA
	And in the New Product page I click Continue
	# Ingredient Page
	And I should see the Ingredients Page
	Then I add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Air           | 100     | false               | false       |            |
	Given in the New Product page I click Continue
	# Regulatory 1 Page Details
	And I should see the Waste Classification Data Page
	And I set the U.S. Toxic Substances Control Act (TSCA) status option to: Compliant
	And I set 'Prop65' to: No
	Given in the New Product page I click Continue
	# Transportation Details 1 Page
	And I should see the Transportation Details 1 Page
	And I set the Product is Regulated for Transport option to: Yes
	And I set the below options for field: Select all modes of transport that you've classified the product for
		| Option                           |
		| DOT                              |
		| Shipping with limited quantity   |
	Given in the New Product page I click Continue
	# U. S. Department of Transportation (DOT) Classification Page
	Then I should see the U. S. Department of Transportation (DOT) Classification Page
	And I set the UN Number field to: UN1950
	And I set the Proper Shipping Name field to: Aerosols
	And I set the Technical Name (if applicable) field to: Clear Coating - Aerosol
	And I set the Hazard Class (select) field to: 2.1
	And I set the Packing Group (select) field to: None
	Given in the New Product page I click Continue
	# Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB) Page
	And I should see the Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB) Page
	Then I see the following questions
		| Section                                                                                                                                        |
		| Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations. |
		| VOC content in grams ozone per gram                                                                                                            |
	And I set the Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations. option to: No
	And in the New Product page I click Continue
	Then VOC content in grams ozone per gram should be showing the error messages: This is a required field.
	And I set the VOC content in grams ozone per gram field to: 0.5
	And in the New Product page I click Continue
	# Volatile Organic Compound Summary page
	And I should see the Volatile Organic Compound Summary Page
	And I confirm that I see todays VOC Analysis Date
	And I confirm that I see the bold VOC-OTC-CARB Compliance Limits statement: Based on your selection, you have verified your product contains VOC with intended uses as follows. The Aerosol Coatings by the CARB VOC compliance limit(s) for the intended use you identified is/are:
	And I should see the following Voc Limits present:
		| Use                     | VOC Compliance Limit | Regulation                  |
		| Clear Coating - Aerosol | 0.85                 | Aerosol Coatings CARB limit |
	And I confirm that I see the following VOC Grams Ozone value: 0.5
	And I confirm statement: limits specified shows the text: Does not exceed the limits specified in the Aerosol Coatings by the CARB
	And I confirm statement: Based on the type of product shows the text: Based on the type of product, this must comply with the most restrictive VOC limit.
	#change the VOC grams value
	Then I click the page heading: Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB)
	And I set the VOC content in grams ozone per gram field to: 1
	And in the New Product page I click Continue
	And I confirm statement: limits specified shows the text: Exceeds the limits specified in the Aerosol Coatings by the CARB
	Given I set the Your acknowledgement of this registration includes that your product option to: Yes, I Acknowledge
	And in the New Product page I click Continue
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	# Regulatory Documents to Provide Page
	And I should see the Regulatory Documents to Provide Page
	And in the Review and Submit tab of the New Product Page for OSHA compliant SDS I select: Request to author
	And in the New Product page I click Continue
	# Additional Documents to Provide Page
	And I should see the Additional Documents to Provide Page
	And in the New Product page I click Continue
	Then Volatile Organic Compounds should be showing the error messages: Document is required: Product Label
	And I click the browse button for label: Product Label and upload PDF: UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf
	And in the New Product page I click Continue
	# Optional Reports and Documents Available for Purchase Page
	And I should see the Optional Reports and Documents Available for Purchase Page
	And in the New Product page I click Continue
	# Safety Data Sheet Authoring - Additional Data (Optional) Page
	And I should see the Safety Data Sheet Authoring - Additional Data (Optional) Page
	And I set the Appearance field to: Brown
	And I set the Odor field to: Banana
	And I set the Odor Threshold field to: Not applicable
	And I set the Partition Coefficient field to: 5
	#And in the New Product page I click Continue
	#Then Product's Dispensing Method should be showing the error messages: This is a required field.
	And I set the Product's Dispensing Method field to: Pump
	And in the New Product page I click Continue
	# Comments Page
	And I should see the Optional Comments Page
	And in the New Product page I click Continue
	# Data Acceptance Page and clean up
	And I should see the Data Acceptance Page
	Given I navigate to the home page
	Then I delete the product: TestCase56484

@TestCase:56476
Scenario: [56476] VOC checks for Personal Fragrance product
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
#	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Then in the New Product page, I click Continue

	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Personal Fragrance Product (more than 20% fragrance) - Liquid
	Then I save the product information as: TestCase56476
	#Given I call Shared Step 57401 (Product Information - US only - No GHS, Not Direct Ship, Not PLP, Not GNFR > Continue - Happy Path)
	Given I should see the Product Information Page
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue
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

	#Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Acetone
	Given I should see the Ingredients Page
	Then In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	| component name | Acetone       | 100     |                     |               |             |
	Then in the Ingredients page I click Continue

#	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Then I should be on the Inventory Status, Prop 65 (US) Page
	And In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	And In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page, I click Continue

	Given I call Shared Step 57506 (Transportation Details 1 - Regulated for Transport(No) - Exemption(Random) - Continue - Happy Path)
	Given I call Shared Step 62536 (Transportation Details 2 > I do not ship internationally > Continue - Happy Path)
	Given I call Shared Step 62710 (Confirm VOC OTC/CARB heading and select No to FIRST QUESTION ONLY - Happy Path)
	Then I see the following sections
		| Section                                                                                                            |
		| Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the CARB |
	Then I do not see the following sections
		| Section                                                                                                                                                              |
		| Amount of VOC content (as a weight percentage (%) of the total formulation) contained in this product, excluding exempt compounds, as defined by the OTC Model Rule. |
	Given in the New Product page I click Continue
	Then Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the CARB should be showing the error messages: This is a required field.
	Given I set the Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the CARB option to: 20
	Given in the New Product page I click Continue
	Given I call Shared Step 57801 (Confirm VOC Summary step shown, Confirm VOC analysis date is shown - Happy Path)
	Then I confirm that I see the bold VOC-OTC-CARB Compliance Limits statement: Based on your selection, you have verified your product contains VOC with intended uses as follows. The CARB VOC compliance limit(s) for the intended use you identified is/are:
	Given I call Shared Step 57819 (VOC Results - Confirm VOC Limits table shows correct values (CARB only) - Happy Path): Personal Fragrance Product (more than 20% fragrance) - Liquid
	And I confirm that I see the following VOC content as weight percentage for each state statement: VOC content as weight percentage of total formula, minus exempt compounds, for each of the following states.
	Then I confirm that I see the following CARB value: 20
	Then I confirm statement: Based on the type of product shows the text: Based on the type of product, this must comply with the most restrictive VOC limit.
	And I confirm the Exceeds/Does not exceed statement is shown and is correct based on inputted CARB value: 20
	Given I set the Your acknowledgement of this registration includes that your product option to: Yes, I Acknowledge
	Given in the New Product page I click Continue
	#Given If ECOLOGO Readiness page is displayed I call Shared Step 57712 - ECOLOGO Readiness Assessment - Not at this time - Continue - Happy Path
	Then I should be on the ECOLOGO Readiness Page
	And In the ECOLOGO Readiness Section, set the option in section: 'Take advantage of Premium Subscription benefits by electing to receive a UL ECOLOGO Readiness Assessment...': to: Not at this time
	Then in the ECOLOGO Readiness page, I click Continue
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	#Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
	Then in the Regulatory Documents to Provide page I click Continue

	Then I should see the Additional Documents to Provide Page
	Then I see the following sections
		| Section                    |
		| Volatile Organic Compounds |
	Given in the New Product page I click Continue
	Then I should see an error message: Document is required: Product Label
	#Given I call Shared Step 60567 (Upload Product Label only)
	Given I should see the Regulatory Documents to Provide Page
	Given in the Regulatory Documents to Provide page I click Continue
	Then In the Regulatory Documents to Provide Section: 'Upload Full Product Label (required) (For private label products please upload a generic label that is not retailer-specific.)' error message should display: Document is required: Product Label
	Then In the Regulatory Documents to Provide Section, upload file in section: 'Upload Full Product Label (required) (For private label products please upload a generic label that is not retailer-specific.)'
	Given in the Regulatory Documents to Provide page I click Continue

	Then I should see the Optional Reports and Documents Available for Purchase Page
	Given in the New Product page I click Continue
	Then I should see the Safety Data Sheet Authoring - Additional Data (Optional) Page
	Given I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
		| Goggles                       | 200                      | 25                      | 12.2      | Black      | Odorless | No data available | 5                     |
	#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: User added Comments Text 74992. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Personal Fragrance Product (more than 20% fragrance) - Liquid
	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase56476
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase56476
	

@TestCase:73503
Scenario: [73503] VOC - ACP Plan = Yes and CARB Value Above Limit for RU - VOC Results Step Shows Alternative Control Plan
	Given I generate a random UPC number and save as: UPC73503
	And I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	And I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Insecticide - Fogger
	Then I save the product information as: TestCase73503
	#Given I call Shared Step 57865 (Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
	Given I should see the Product Information Page
	Then In the Product Information Section, set the option in section: 'Which best describes your product, including when FIFRA 25(b) Exempt' to: Product is intended for preventing, destroying, repelling, or mitigating pests (including insects, rodents, mold, virus, bacteria, and other micro-organisms)
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue

	And I call Shared Step 57532 (Physical and Chemical Properties - Aerosol & Gas available - Select Gas - Continue - Happy Path)
	And I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| 7647-14-5     | 100     | false               | false       |            |
	And I call Shared Step 48360 - Regulatory - Test TSCA and PROP65 - Continue
	#And I call Shared Step 57589 (Enter Pesticide Data - United States (without EPA number))
	Given I should see the Pesticide Details - U.S. Page
	Then In the Pesticide Details - U.S. Section, in 'Product has an Environmental Protection Agency (EPA) Registration Number' enter No
	Then In the Pesticide Details - U.S. Section, in 'Product has a State Registration' enter No
	Then In the Pesticide Details - U.S. Section, in 'Select the applicable exemption' enter Food Based Pesticides - Exempt from EPA Registration
	Then in the Pesticide Details - U.S. page I click Continue

	#And I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	Given I should see the Transportation Details 1 Page
	Then In the Transportation Details 1 Section, set the option in section: 'Product is Regulated for Transport': to: Yes
	Then In the Transportation Details 1 Section, set the option in section: 'Select all modes of transport that you've classified the product for': to: DOT
	Then In the Transportation Details 1 Section, set the option for DOT mode of transport to: Shipping with limited quantity
	Then in the Transportation Details 1 page I click Continue

	And I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)
	And I should see the Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB) Page
    And I set the Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations. option to: Yes
	And I set the Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the CARB option to: 50
	And I set the Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the OTC Model Rule option to: 40
	And I set the Would you like to use the VOC percentages entered for all areas (e.g. country, state, local) for comparison? option to: Yes
	And I click continue
	And I should see the Volatile Organic Compound Summary Page
	Given I scroll to the bottom of the page
	And I confirm statement: Based on the type of product shows the text: Based on the type of product, this must comply with the most restrictive VOC limit.
	And I confirm that statement with text: 'Does not exceed the limits specified by the California Consumer Products Regulation' is not displayed
	And I confirm that statement with text: 'Exceeds the limit specified by the California Consumer Products Regulation' is not displayed
	And The VOC Summary page contains the statement with the text: Alternative Control Plan
	And The VOC Summary page contains the statement with the text: Does not exceed the limits specified by the Ozone Transport Commission
	And I click the page heading: Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB)
	And I set the Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the CARB option to: 40
	And I click continue
	Given I scroll to the bottom of the page
	And I confirm that statement with text: 'Alternative Control Plan' is not displayed
	And The VOC Summary page contains the statement with the text: Does not exceed the limits specified in the California Consumer Products Regulation
	And I click the page heading: Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB)
	And I set the Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations. option to: No
	And I set the Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the CARB option to: 55
	And I click continue
	Given I scroll to the bottom of the page
	And I confirm that statement with text: 'Alternative Control Plan' is not displayed
	And The VOC Summary page contains the statement with the text: Exceeds the limits specified in the California Consumer Products Regulation
	And I navigate to the home page
	And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase73503
