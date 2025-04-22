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
@UPC
@run_ProductDocuments
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:ProductInformation
@PhysicalAndChemicalProp
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:RegulatoryDocumentsToProvide
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:OptionalComments
@Ingredients
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:NewProduct
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:TheProduct
@StepsPrototype
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:InventoryStatusProp65
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:AdditionalDocumentsToProvide
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:Summary
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:DataAcceptance
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:TransportationDetails1
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:TransportationDetails2
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:VOC_OzoneTransportCommission
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:VOC_Summary
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:PurchaseSummary
@RegulatoryInformation3
Feature: Product Documents

# Assigned to Barrett, Beverly
# Created by Barrett, Beverly
# Test case can be found at the following paths:
# NetProjects10\WERCSmart UX Reboot\WERCSmart\Product Registration\Product Documents
# NetProjects10\WercsSmart Portal\WERCSmart\Product Registration\Product Documents

@59322
@TestCase:59322
Scenario: [59322] Upload document - VOC exemption letter & VOC product label
	#Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I log in with the account saved in TReVor as: ProductAccount

	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration'
	Given in the New Product page I click Continue

	# And I In the Shared step below select "Personal Fragrance Product (more than 20 percent fragrance)" as your product type
	#And I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Personal Fragrance Product (more than 20% fragrance) - Liquid
	Then I should be on the The Product Page
	And In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Personal Fragrance Product (more than 20% fragrance) - Liquid_#59322
	And In the Product Section, set the option in section: 'Type of Product (select)' to: Personal Fragrance Product (more than 20% fragrance) - Liquid
	Then in the The Product page, I click Continue

	Then I save the product information as: TestCase59322

	#Given I call Shared Step 57401 (Product Information - US only - No GHS, Not Direct Ship, Not PLP, Not GNFR > Continue - Happy Path)
	Given I should see the Product Information Page
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue

	#And I call Shared Step 70675 (Physical and Chemical Properties - Liquid Only - With Water Solubility - Enter all data - Continue)
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

	#And I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
	Given I should see the Ingredients Page
	Then In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	| component name | Water       | 100     |                     |               |             |
	Then in the Ingredients page I click Continue

	#And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Then I should be on the Inventory Status, Prop 65 (US) Page
	And In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is exempt from TSCA chemical Inventory listing requirements.
	And In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page, I click Continue

	#PRODUCT LABELING - TEST CASE NEEDS TO BE UPDATED TO INCLUDE THIS PAGE -- 03/26/25
	Given I should see the Product Labeling Page
	Then In the Product Labeling Section, in section: 'Refer to your Product Label.  From the options, select those that appear on the Label.' click the checkbox option: None of the Above
	Then in the Product Labeling page I click Continue

	#And I call Shared Step 57506 (Transportation Details 1 - Regulated for Transport(No) - Exemption(Random) - Continue - Happy Path)
	And I should see the Transportation Details 1 Page
	And In the Transportation Details 1 Section, set the option in section: 'Product is Regulated for Transport': to: No, due to an exemption or exception
	And In the Transportation Details 1 Section, set the option in section: 'Please select DOT Exceptions if applicable?': to: 173.120(b)(3):  Combustible liquid that does not sustain combustion
	Then in the Transportation Details 1 page, I click Continue

	#And I call Shared Step 62536 (Transportation Details 2 > I do not ship internationally > Continue - Happy Path)
	Then I should see the Transportation Details 2 Page
	And In the Transportation Details 2 Section, set the option in section: 'International Shipping when DOT Exemption taken?': to: I do not ship internationally and I do not know the classification
	Then in the Transportation Details 2 page, I click Continue

	# Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB) Page
	Then I should see the Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB) Page
	And In the VOC - Ozone Transport Commission Section, set the option in section: 'Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations.': to: Yes
	And In the VOC - Ozone Transport Commission Section, set the option in section: 'Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the CARB': to: 5
	And In the VOC - Ozone Transport Commission Section, set the option in section: 'Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the OTC Model Rule': to: 5
	Then in the Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB) page, I click Continue
	Then I should see the Volatile Organic Compound Summary Page
	And In the Volatile Organic Compound Summary Section, for 'Your acknowledgement of this registration includes that your product..' set 'Yes, I Acknowledge'
	Then in the Volatile Organic Compound Summary page, I click Continue

	#And I call Shared Step 63219 (Retailer Association - Select No Retailer - Click continue)
	Then I should be on the Retailer Page
	Then in the Retailer page, I click Continue

	#And I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Yes, I certify that I have an OSHA-compliant SDS for this product and would like to upload it.
	And In the Regulatory Documents to Provide Section, upload file in section: 'OSHA SDS'
	Then in the Regulatory Documents to Provide page I click Continue

	And I should see the Additional Documents to Provide Page
	And In the Additional Documents to Provide, for section VOC Exemption Letter the 'Browse' button should exists
	And In the Additional Documents to Provide, for section Product Label the 'Browse' button should exists
	Then in the Additional Documents to Provide page I click Continue
	And In the Additional Documents to Provide, section 'Volatile Organic Compounds' error message should display: Document is required: Product Label
	And In the Additional Documents to Provide, upload PDF document for section: Volatile Organic Compounds - VOC Exemption Letter
	And In the Additional Documents to Provide, upload PDF document for section: Volatile Organic Compounds - Product Label
	Then in the Additional Documents to Provide page I click Continue

	Then in the Optional Reports and Documents Available for Purchase page I click Continue

	#And I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	#Given I should see the Data Acceptance Page
	#And In the Data Acceptance Section, check 'Agreed' checkbox
	#And In the Data Acceptance Section, click 'Accept' button
	#And In the Purchase Summary page message is displayed with text: Thank you for registering your product on WERCSmart for assessment. The retailers may receive your assessment in approximately two (2) business days, if no delays in processing the assessment, and should no data issues arise.

	#And I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase59322
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase59322

	
@TestCase:59320
Scenario: [59320] Upload Document - IFRA certificate

	#Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I log in with the account saved in TReVor as: ProductAccount

	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration'
	Given in the New Product page I click Continue

	#And I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Crayon
	Then I should be on the The Product Page
	And In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Shampoo (Solid)_#59320
	And In the Product Section, set the option in section: 'Type of Product (select)' to: Shampoo (Solid)
	Then in the The Product page, I click Continue

	Then I save the product information as: TestCase59320

	#And I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Given I should see the Product Information Page
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
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

	#And I call Shared Step 79436 (Ingredients - Add FRAGRANCE component, Publicly Disclosed = Yes,  Select Public Name) and save ingredient as: shared79436
	#	| CASNumber | ComponentName                                                                  | Percentage |
	#	| FRAGRANCE | Fragrance - Awapuhi - Skin sens 1, Repro 2, Aquatic acute 2, Aquatic chronic 2 | 100        |
	Then I should be on the Ingredients Page
	And In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue                                                                                                                                                              | Percent | Publicly Disclosed? | Trade Secret? | Public Name                                                                                                                                                              |
	| component name | Water                                                                                                                                                                    | 88      | True                | False         | Water                                                                                                                                                                    |
	| component name | SODIUM LAURYL SULFATE                                                                                                                                                    | 10      | True                | False         | SODIUM LAURYL SULFATE                                                                                                                                                    |
	| component name | Fragrance - Tangerine with Lemongrass: Flammable liquid, harmful if swallowed, skin irritant 2, eye irritant 2A, skin sensitizer 1, repro 2, aquatic acute and chronic 1 | 2       | True                | False         | Fragrance - Tangerine with Lemongrass: Flammable liquid, harmful if swallowed, skin irritant 2, eye irritant 2A, skin sensitizer 1, repro 2, aquatic acute and chronic 1 |
	Then in the Ingredients page, I click Continue
	And In the Ingredients Section, I confirm I check the checkbox in the popup view with the following text: The Product Type, Pest Selection, and Ingredients listed are accurate.
	Given In the Ingredients Section, In the popup view with the following title: Product Contains Ingredients Typical of a Pesticide I click the Confirm button

	#And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Then I should be on the Inventory Status, Prop 65 (US) Page
	And In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is exempt from TSCA chemical Inventory listing requirements.
	And In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page, I click Continue

	#Transportation details 1 - not regulated 
	And I should see the Transportation Details 1 Page
	And In the Transportation Details 1 Section, set the option in section: 'Product is Regulated for Transport': to: Not Regulated
	Then in the Transportation Details 1 page, I click Continue

	#And I call Shared Step 63219 (Retailer Association - Select No Retailer - Click continue)
	Then I should be on the Retailer Page
	Then in the Retailer page, I click Continue

	#And I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Yes, I certify that I have an OSHA-compliant SDS for this product and would like to upload it.
	And In the Regulatory Documents to Provide Section, upload file in section: 'OSHA SDS'
	Then in the Regulatory Documents to Provide page I click Continue

	#Additional Documents to Provide - Applicable Only to Type of Product:  Shampoo (Solid) (RU001651) - IFRA Certificate Required
	And I should see the Additional Documents to Provide Page
	Then in the Additional Documents to Provide page I click Continue
	Then In the Additional Documents to Provide, section 'International Fragrance Association (IFRA)' error message should display: Document is required: IFRA Certificate (Perfumery Products)
	And In the Additional Documents to Provide Section, for section IFRA Certificate (Perfumery Products) I click button 'Browse'
	And In the Additional Documents to Provide, upload PDF document to International Fragrance Association (IFRA) field
	When In the Additional Documents to Provide, for section IFRA Certificate (Perfumery Products) I click button 'View'
	Then In the Additional Documents to Provide, after clicking 'View' button I confirm pdf file is downloaded
	Then in the Additional Documents to Provide page I click Continue

	#Optional Reports and Documents Available for Purchase Page - Click CONTINUE 
	And I should see the Optional Reports and Documents Available for Purchase Page
	Given in the Optional Reports and Documents Available for Purchase page I click Continue

	#And I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	#And I call Shared Step 73956 (Go to Summary and verify data) with product type: Crayon
	Then I should see the Data Acceptance Page
	And In the Data Acceptance Section, click 'Summary' button
	And I switch to the tab with Data Summary page
	And In the Summary Page, the 'Type of Product (select)' section should be showing the following value: Shampoo (Solid)
	And In the Summary page, I confirm the Ingredients table matches the following:
	| CAS Number/ChemicalName                                                                                                                                                  | Percent | Publicly Disclosed? | Trade Secret? | INCI Name                                                                                                                                                                |
	| Water                                                                                                                                                                    | 88      | Yes                 | No            | Water                                                                                                                                                                    |
	| Sodium lauryl sulfate                                                                                                                                                    | 10      | Yes                 | No            | SODIUM LAURYL SULFATE                                                                                                                                                    |
	| Fragrance - Tangerine with Lemongrass: Flammable liquid, harmful if swallowed, skin irritant 2, eye irritant 2A, skin sensitizer 1, repro 2, aquatic acute and chronic 1 | 2       | Yes                 | No            | Fragrance - Tangerine with Lemongrass: Flammable liquid, harmful if swallowed, skin irritant 2, eye irritant 2A, skin sensitizer 1, repro 2, aquatic acute and chronic 1 |
	Then In the Summary Page, click the View button for section: IFRA Certificate (Perfumery Products)
	Then In the Summary Page, after clicking 'View' button I confirm pdf file is downloaded
	And I close the tab with Data Summary page
	Then I should be on the Data Acceptance Page

	#And I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase59320
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase59320

@TestCase:59321
Scenario: [59321] Upload Document - GRAS certificate

	#Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I log in with the account saved in TReVor as: ProductAccount

	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration'
	Given in the New Product page I click Continue

	#And I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Crayon
	Then I should be on the The Product Page
	And In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Lip Balm_#59321
	And In the Product Section, set the option in section: 'Type of Product (select)' to: Lip Balm
	Then in the The Product page, I click Continue

	Then I save the product information as: TestCase59321

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
	Then In the Physical and Chemical Properties Section, for section: 'Primary Physical State': the following options should be displayed:
	| Option |
	| Solid  |
	| Liquid |
	And In the Physical and Chemical Properties Section, set the option in section: 'Primary Physical State' to: Solid
	Then In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
	Then In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Then In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: No data available
	Then in the Physical and Chemical Properties page I click Continue

	#Given I call Shared Step 79431 (Ingredients - Add FLAVOR component, Publicly Disclosed = Yes, Select Public Name) and save ingredients as: shared79431
	#	| CASNumber | ComponentName | Percentage |
	#	| FLAVOR    | FLAVOR        | 100        |
	Then I should be on the Ingredients Page
	And In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	| component name | FLAVOR      | 100     |                     |               |             |
	Then in the Ingredients page I click Continue

	#And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Then I should be on the Inventory Status, Prop 65 (US) Page
	And In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is exempt from TSCA chemical Inventory listing requirements.
	And In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page, I click Continue

	Then I should be on the Product Labeling Page
	And In the Product Labeling Section, in section: 'Refer to your Product Label.  From the options, select those that appear on the Label.' click the checkbox option: None of the Above
	Then in the Product Labeling page, I click Continue

	#And I call Shared Step 63219 (Retailer Association - Select No Retailer - Click continue)
	Then I should be on the Retailer Page
	Then in the Retailer page, I click Continue

	#And I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Yes, I certify that I have an OSHA-compliant SDS for this product and would like to upload it.
	And In the Regulatory Documents to Provide Section, upload file in section: 'OSHA SDS'
	Then in the Regulatory Documents to Provide page I click Continue

	And I should see the Additional Documents to Provide Page
	Then in the Additional Documents to Provide page I click Continue
	And In the Additional Documents to Provide, for section 'Generally Recognized as Safe (GRAS)' error message should display: Document is required: GRAS Certificate (Flavor Products)
	And In the Additional Documents to Provide, upload PDF document to Generally Recognized as Safe (GRAS) field
	Then in the Additional Documents to Provide page I click Continue

	Then in the Optional Reports and Documents Available for Purchase page I click Continue

	#And I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	#Given I should see the Data Acceptance Page
	#And In the Data Acceptance Section, check 'Agreed' checkbox
	#And In the Data Acceptance Section, click 'Accept' button
	#And In the Purchase Summary page message is displayed with text: Thank you for registering your product on WERCSmart for assessment. The retailers may receive your assessment in approximately two (2) business days, if no delays in processing the assessment, and should no data issues arise.

	#And I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase59321
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase59321
