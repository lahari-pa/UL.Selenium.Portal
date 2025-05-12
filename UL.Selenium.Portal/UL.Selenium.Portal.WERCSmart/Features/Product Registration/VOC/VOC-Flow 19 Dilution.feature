@Shared
@LandingPage
@Login
@Homepage
@Signup
@wercsmart
@NewProduct
@ProductGrid
@DataSummarySheet
@StepsPrototype
@wercsmart
@RetailPartners
@run_VOCFlow19
@Ingredients
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:NewProduct
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:TheProduct
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:ProductInformation
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:TransportationDetails1
@PhysicalAndChemicalProp
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:InventoryStatusProp65
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:VOC_OzoneTransportCommission
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:VOC_Summary
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:Retailer
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:RegulatoryDocumentsToProvide
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:AdditionalDocumentsToProvide
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:TransportationDetails2
@SideMenu

Feature: VOC - Flow 19 Dilution - validation of limits (Suite ID: 64747)

@TestCase:62730
Scenario: [62730] VOC -Dilution ration - Sold = 50, Used = 45 limit checking
	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Then In the Side Menu, click Labeled Link with Add Product title
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration'
	Then in the New Product page, I click Continue
	#Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Floor Wax Stripper (Light or Medium Build-Up)
	Then I should be on the The Product Page
	And In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Floor Wax Stripper (Light or Medium Build-Up)_#62730
	And In the Product Section, set the option in section: 'Type of Product (select)' to: Floor Wax Stripper (Light or Medium Build-Up)
	Then in the The Product page, I click Continue
	Then I save the product information as: TestCase62730
	#Given I call Shared Step 57401 (Product Information - US only - No GHS, Not Direct Ship, Not PLP, Not GNFR > Continue - Happy Path)
	Given I should see the Product Information Page
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Cleaning products must comply with California's Cleaning Product Right to Know Act. I would like to provide the additional information needed for this program during registration.' to: No
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
	| component name | Water       | 100     |                     |               |             |
	Then in the Ingredients page I click Continue
	#Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Then I should be on the Inventory Status, Prop 65 (US) Page
	And In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	And In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page, I click Continue
	#Then 225742 Transportation Details 1 - No, due to an exemption or exception
	Then I should be on the Transportation Details 1 Page
	And In the Transportation Details 1 Section, set the option in section: 'Product is Regulated for Transport': to: No, due to an exemption or exception
	Then In the Transportation Details 1 page the 'Please select DOT Exceptions if applicable?' question is displayed
	Then In the Transportation Details 1 page the 'Other DOT Exception' question is displayed
	Then In the Transportation Details 1 page the 'Provide Special Permit numbers (if applicable)' question is displayed
	Then In the Transportation Details 1 Section, set the option in section: 'Please select DOT Exceptions if applicable?': to: 173.120(b)(3):  Combustible liquid that does not sustain combustion
	Then in the Transportation Details 1 page, I click Continue
	Then I should be on the Transportation Details 2 Page
	Then In the Transportation Details 2 Section, set the option in section: 'International Shipping when DOT Exemption taken?': to: I do not ship internationally and I do not know the classification
	Then in the Transportation Details 2 page, I click Continue
	#Given I call Shared Step 62710 (Confirm VOC OTC/CARB heading and select No to FIRST QUESTION ONLY - Happy Path)
	Then I should be on the Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB) Page
	Then In the VOC - Ozone Transport Commission Section, set the option in section: 'Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations.': to: No
	Then In the VOC - Ozone Transport Commission Section, set the option in section: 'Would you like to use the VOC percentages entered for all areas (e.g. country, state, local) for comparison?': to: Yes
	Then In the VOC - Ozone Transport Commission Section, set the option in section: 'Product label specifies a dilution ratio which results in a final VOC concentration for the product during use': to: Yes	
	Then In the VOC - Ozone Transport Commission Section, set the option in section: 'Product's VOC content as sold': to: 50
	Then In the VOC - Ozone Transport Commission Section, set the option in section: 'Product's VOC content as used': to: 45
	Given in the Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB) page I click Continue
	Then I should see the Volatile Organic Compound Summary Page
	Then In the VOC - Ozone Transport Commission Section, the following statements are not editable:
		| Statement                      |
		| VOC percent as sold 50         |
		| VOC percent diluted for use 45 |
	Then In the Volatile Organic Compound Summary Section, the statement 'Exceeds the limits specified in the California Consumer Products Regulation' is displayed
	Then In the Volatile Organic Compound Summary Section, the statement 'Exceeds the limits specified by the Ozone Transport Commission' is displayed
	Then In the Volatile Organic Compound Summary Section, for 'Your acknowledgement of this registration includes that your product..' set 'Yes, I Acknowledge'
	And I click continue
	Given I should see the Retailer Page
	And In the Retailer Section, following retailers should be displayed:
		| Retailer                   |
		| No Retailer/No UPC Product |
	Then in the Retailer page, I click Continue
	#Then I call Shared Step 78080 (Regulatory Documents to Provide - Upload OSHA SDS)
	And I should see the Regulatory Documents to Provide Page
	Given In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Yes, I certify that I have an OSHA-compliant SDS for this product and would like to upload it.
	Given In the Regulatory Documents to Provide Section, upload file in section: 'OSHA SDS'
	And in the Regulatory Documents to Provide page I click Continue
	And I should see the Additional Documents to Provide Page
	Then In the Additional Documents to Provide, upload PDF document for section: Volatile Organic Compounds - Product Label
	And in the Additional Documents to Provide page I click Continue
	And I should see the Optional Reports and Documents Available for Purchase Page
	And in the Optional Reports and Documents Available for Purchase page I click Continue
	And I should see the Optional Comments Page
	And in the Optional Comments page I click Continue
	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase62730
	Then I navigate to the Home Page
	Then I delete the product: TestCase62730

@TestCase:62708
Scenario: [62708] VOC - Flow 19 - Dilution - Limits checking - Sold = 1 Used = 2
	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Then In the Side Menu, click Labeled Link with Add Product title
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration'
	Then in the New Product page, I click Continue
	#Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Floor Wax Stripper (Light or Medium Build-Up)
	Then I should be on the The Product Page
	And In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Floor Wax Stripper (Light or Medium Build-Up)_#62708
	And In the Product Section, set the option in section: 'Type of Product (select)' to: Floor Wax Stripper (Light or Medium Build-Up)
	Then in the The Product page, I click Continue
	Then I save the product information as: TestCase62708
	#Given I call Shared Step 57401 (Product Information - US only - No GHS, Not Direct Ship, Not PLP, Not GNFR > Continue - Happy Path)
	Given I should see the Product Information Page
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Cleaning products must comply with California's Cleaning Product Right to Know Act. I would like to provide the additional information needed for this program during registration.' to: No
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
	| component name | Water       | 100     |                     |               |             |
	Then in the Ingredients page I click Continue
	#Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Then I should be on the Inventory Status, Prop 65 (US) Page
	And In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	And In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page, I click Continue
	#Given I call Shared Step 57507 (Transportation Details 1- Not Regulated - Continue - Happy Path)
	Then I should be on the Transportation Details 1 Page
	Then in the Transportation Details 1 page, I click Continue
	Then In the Transportation Details 1 Section, the error 'This is a required field' is displayed for section 'Product is Regulated for Transport'
	And In the Transportation Details 1 Section, set the option in section: 'Product is Regulated for Transport': to: Not Regulated
	Then in the Transportation Details 1 page, I click Continue
	#Given I call Shared Step 62710 (Confirm VOC OTC/CARB heading and select No to FIRST QUESTION ONLY - Happy Path)
	Then I should be on the Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB) Page
	Then In the VOC - Ozone Transport Commission Section, set the option in section: 'Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations.': to: No
	Then In the VOC - Ozone Transport Commission Section, set the option in section: 'Would you like to use the VOC percentages entered for all areas (e.g. country, state, local) for comparison?': to: Yes
	Then In the VOC - Ozone Transport Commission Section, set the option in section: 'Product label specifies a dilution ratio which results in a final VOC concentration for the product during use': to: Yes
	Given in the Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB) page I click Continue
	Then In the VOC - Ozone Transport Commission Section, 'Product's VOC content as sold' should be showing the error message: This is a required field.
	Then In the VOC - Ozone Transport Commission Section, 'Product's VOC content as used' should be showing the error message: This is a required field.
	Then In the VOC - Ozone Transport Commission Section, set the option in section: 'Product's VOC content as sold': to: 11
	Then In the VOC - Ozone Transport Commission Section, set the option in section: 'Product's VOC content as used': to: 2
	Then In the VOC - Ozone Transport Commission Section, 'Product's VOC content as sold' should not be showing the error message: This is a required field.
	Then In the VOC - Ozone Transport Commission Section, 'Product's VOC content as used' should not be showing the error message: This is a required field.
	Given in the Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB) page I click Continue
	And I should see the Volatile Organic Compound Summary Page
	Then In the Volatile Organic Compound Summary Section, confirm that I see todays 'VOC Analysis Date'
	Then In the Volatile Organic Compound Summary Section, the statement 'Based on your previous selections, the product has the following intended use: The OTC Model Rule and CARB limits for this intended use are:' is displayed
	Then In the Volatile Organic Compound Summary Section, confirm 'Limits' table should exists
	Then In the Volatile Organic Compound Summary Section, the statement 'Based on the type of product, this must comply with the most restrictive VOC limit.' is displayed
	Then In the Volatile Organic Compound Summary Section, the statement 'Does not exceed the limits specified in the California Consumer Products Regulation' is displayed
	Then In the Volatile Organic Compound Summary Section, the statement 'Does not exceed the limits specified by the Ozone Transport Commission' is displayed
	Then In the Volatile Organic Compound Summary Section, for 'Your acknowledgement of this registration includes that your product..' set 'Yes, I Acknowledge'
	And I click continue
	Given I should see the Retailer Page
	And In the Retailer Section, following retailers should be displayed:
		| Retailer                   |
		| No Retailer/No UPC Product |
	Then in the Retailer page, I click Continue
	#Then I call Shared Step 78080 (Regulatory Documents to Provide - Upload OSHA SDS)
	And I should see the Regulatory Documents to Provide Page
	Given In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Yes, I certify that I have an OSHA-compliant SDS for this product and would like to upload it.
	Given In the Regulatory Documents to Provide Section, upload file in section: 'OSHA SDS'
	And in the Regulatory Documents to Provide page I click Continue
	And I should see the Additional Documents to Provide Page
	Then In the Additional Documents to Provide, upload PDF document for section: Volatile Organic Compounds - Product Label
	And in the Additional Documents to Provide page I click Continue
	And I should see the Optional Reports and Documents Available for Purchase Page
	And in the Optional Reports and Documents Available for Purchase page I click Continue
	And I should see the Optional Comments Page
	And in the Optional Comments page I click Continue
	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase62708
	Then I navigate to the Home Page
	Then I delete the product: TestCase62708

@TestCase:56478
Scenario: [56478] VOC - CARB and OTC - Concentrate/dilution = No to Dilution checking warning message shown
	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Then In the Side Menu, click Labeled Link with Add Product title
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration'
	Then in the New Product page, I click Continue
	#Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Floor Wax Stripper (Light or Medium Build-Up)
	Then I should be on the The Product Page
	And In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Floor Wax Stripper (Light or Medium Build-Up)_#56478
	And In the Product Section, set the option in section: 'Type of Product (select)' to: Floor Wax Stripper (Light or Medium Build-Up)
	Then in the The Product page, I click Continue
	Then I save the product information as: TestCase56478
	#Given I call Shared Step 57401 (Product Information - US only - No GHS, Not Direct Ship, Not PLP, Not GNFR > Continue - Happy Path)
	Given I should see the Product Information Page
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Cleaning products must comply with California's Cleaning Product Right to Know Act. I would like to provide the additional information needed for this program during registration.' to: No
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
	| component name | Water       | 100     |                     |               |             |
	Then in the Ingredients page I click Continue
	#Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Then I should be on the Inventory Status, Prop 65 (US) Page
	And In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	And In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page, I click Continue
	#Given I call Shared Step 57507 (Transportation Details 1- Not Regulated - Continue - Happy Path)
	Then I should be on the Transportation Details 1 Page
	Then in the Transportation Details 1 page, I click Continue
	Then In the Transportation Details 1 Section, the error 'This is a required field' is displayed for section 'Product is Regulated for Transport'
	And In the Transportation Details 1 Section, set the option in section: 'Product is Regulated for Transport': to: Not Regulated
	Then in the Transportation Details 1 page, I click Continue
	#Given I call Shared Step 62710 (Confirm VOC OTC/CARB heading and select No to FIRST QUESTION ONLY - Happy Path)
	Then I should be on the Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB) Page
	Then In the VOC - Ozone Transport Commission Section, set the option in section: 'Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations.': to: No
	Then In the VOC - Ozone Transport Commission Section, set the option in section: 'Would you like to use the VOC percentages entered for all areas (e.g. country, state, local) for comparison?': to: Yes
	Then In the VOC - Ozone Transport Commission Section the 'Product label specifies a dilution ratio which results in a final VOC concentration for the product during use' question is displayed
	Then In the VOC - Ozone Transport Commission Section, for section 'Product label specifies a dilution ratio which results in a final VOC concentration for the product during use' confirm that the following options should be displayed:
	| Option |
	| Yes    |
	| No     |
	Given in the Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB) page I click Continue
	Then In the VOC - Ozone Transport Commission Section, 'Product label specifies a dilution ratio which results in a final VOC concentration for the product during use' should be showing the error message: This is a required field.
	Then In the VOC - Ozone Transport Commission Section, set the option in section: 'Product label specifies a dilution ratio which results in a final VOC concentration for the product during use': to: No
	Then In the VOC - Ozone Transport Commission section, I confirm text 'Please be sure you have selected the correct product type. For further questions, please contact Support.' should be displayed
	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase56478
	Then I navigate to the Home Page
	Then I delete the product: TestCase56478
