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
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:ProductInformation
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:TransportationDetails1
@PhysicalAndChemicalProp
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:InventoryStatusProp65

Feature: VOC - Flow 19 Dilution - validation of limits (Suite ID: 64747)

@TestCase:62730
Scenario: [62730] VOC - Flow 19 - Dilution ration - Sold = 50, Used = 45 limit checking
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
#	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Then in the New Product page, I click Continue

	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Floor Wax Stripper (Light or Medium Build-Up)
	Then I save the product information as: TestCase62730
	#Given I call Shared Step 57401 (Product Information - US only - No GHS, Not Direct Ship, Not PLP, Not GNFR > Continue - Happy Path)
	Given I should see the Product Information Page
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

	#Given I call Shared Step 57507 (Transportation Details 1- Not Regulated - Continue - Happy Path)
	Then I should be on the Transportation Details 1 Page
	And In the Transportation Details 1 Section, set the option in section: 'Product is Regulated for Transport': to: Not Regulated
	Then in the Transportation Details 1 page, I click Continue

	Given I call Shared Step 62710 (Confirm VOC OTC/CARB heading and select No to FIRST QUESTION ONLY - Happy Path)
	Given I set the Would you like to use the VOC percentages entered for all areas (e.g. country, state, local) for comparison? option to: Yes
		Given I set the Product label specifies a dilution ratio which results in a final VOC concentration for the product during use field to: Yes
	Given I set 'Product label dilution ratio' to: Yes
	Given I set 'VOC Content As Sold' to: 50
	Given I set 'VOC Content As Used' to: 45
	Given I click continue
	Then I should see the Volatile Organic Compound Summary Page
	Then in the VOC Summary page I should see the following noneditable statements
		| Statement                                                                           |
		| VOC percent as sold 50                                                              |
		| VOC percent diluted for use 45                                                      |
		| Based on the type of product, this must comply with the most restrictive VOC limit. |
		| Exceeds the limits specified in the California Consumer Products Regulation         |
		| Exceeds the limits specified by the Ozone Transport Commission                      |
	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase62730
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase62730

@TestCase:62708
Scenario: [62708] VOC - Flow 19 - Dilution - Limits checking - Sold = 1 Used = 2
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
#	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Then in the New Product page, I click Continue

	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Floor Wax Stripper (Light or Medium Build-Up)
	Then I save the product information as: TestCase62708
	#Given I call Shared Step 57401 (Product Information - US only - No GHS, Not Direct Ship, Not PLP, Not GNFR > Continue - Happy Path)
	Given I should see the Product Information Page
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

	#Given I call Shared Step 57507 (Transportation Details 1- Not Regulated - Continue - Happy Path)
	Then I should be on the Transportation Details 1 Page
	And In the Transportation Details 1 Section, set the option in section: 'Product is Regulated for Transport': to: Not Regulated
	Then in the Transportation Details 1 page, I click Continue

	Given I call Shared Step 62710 (Confirm VOC OTC/CARB heading and select No to FIRST QUESTION ONLY - Happy Path)
	#Given I set the Product label specifies a dilution ratio which results in a final VOC concentration for the product during use field to: Yes
		Given I set the Would you like to use the VOC percentages entered for all areas (e.g. country, state, local) for comparison? option to: Yes
	Given I set 'Product label dilution ratio' to: Yes
	Given in the VOC page I click Continue
	Then For the Product's VOC content as sold field I should see the following error: This is a required field.
	Then For the Product's VOC content as used field I should see the following error: This is a required field.
	Given I set 'VOC Content As Sold' to: 1
	Given I set 'VOC Content As Used' to: 2
	#Given I set the Product's VOC content as sold field to: 1
	#Given I set the Product's VOC content as used field to: 2
	Then For the Product's VOC content as sold field I should see not see an error
	Then For the Product's VOC content as used field I should see not see an error
	Given in the VOC page I click Continue
	Then I should see the Volatile Organic Compound Summary Page
	Given I call Shared Step 57801 (Confirm VOC Summary step shown, Confirm VOC analysis date is shown - Happy Path)
	Given I call Shared Step 57817 (VOC Results - Confirm VOC Limits table shows correct values (OTC & CARB) - Happy Path): Floor Wax Stripper (Light or Medium Build-Up)
	Then in the VOC Summary page I should see the following noneditable statements
		| Statement                                                                                                                                    |
		| VOC percent as sold 1                                                                                                                        |
		| VOC percent diluted for use 2                                                                                                                |
		| Based on the type of product, this must comply with the most restrictive VOC limit.                                                          |
		| Does not exceed the limits specified in the California Consumer Products Regulation                                                          |
		| Does not exceed the limits specified by the Ozone Transport Commission                                                                       |
		| Based on your previous selections, the product has the following intended use: The OTC Model Rule and CARB limits for this intended use are: |
#	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase62708
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase62708

@TestCase:56478
Scenario: [56478] VOC - CARB and OTC for Flow 19 products - Concentrate/dilution = No to Dilution checking warning message shown
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
#	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Then in the New Product page, I click Continue

	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Floor Wax Stripper (Light or Medium Build-Up)
	Then I save the product information as: TestCase56478
	#Given I call Shared Step 57401 (Product Information - US only - No GHS, Not Direct Ship, Not PLP, Not GNFR > Continue - Happy Path)
	Given I should see the Product Information Page
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

#	Given I call Shared Step 57507 (Transportation Details 1- Not Regulated - Continue - Happy Path)
	Then I should be on the Transportation Details 1 Page
	And In the Transportation Details 1 Section, set the option in section: 'Product is Regulated for Transport': to: Not Regulated
	Then in the Transportation Details 1 page, I click Continue

	Given I call Shared Step 62710 (Confirm VOC OTC/CARB heading and select No to FIRST QUESTION ONLY - Happy Path)
	Then the VOC concentration question shows a yes and a no button
	Given in the VOC page I click Continue
	Then For the VOC concentration question field I should see the following error: This is a required field.
	Given I set the Product label specifies a dilution ratio which results in a final VOC concentration for the product during use field to: No
	Then For the VOC page I should see the following error: Please be sure you have selected the correct product type. For further questions, please contact Support.
	Given in the VOC page I click Continue
#	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase56478
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase56478
