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
@SummaryPage
@UPC
@SHA
@run_Flow8
@Studio
@StepsPrototype
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:ProductInformation
@PhysicalAndChemicalProp
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:InventoryStatusProp65
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:RegulatoryDocumentsToProvide
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:OptionalComments
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:DataAcceptance
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:NewProduct
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:TheProduct
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:TransportationDetails1
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:Retailer

@SafetyDataSheetAuthoring

@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:InventoryStatusProp65
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:TransportationDetails1
Feature: Flow 8

@TestCase:57295
Scenario: [57295] Absorbent solid - Automotive(RU000939) - 8-S
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
#	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Then in the New Product page, I click Continue

	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Absorbent Solid
	Then I save the product information as: TestCase57295
	Given I call Shared Step 63804 (Product Information - US, No(OSHA), No(DSV), Yes (PLP), No(GNFR))
		| Classified using OSHA (US) Globally Harmonized Standards (GHS) | Shipped directly by supplier | Private Label or Brand | Good Not for resale |
		| No                                                             | No                           | No                     | No                  |
	#Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I should see the Physical and Chemical Properties Page
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' should be showing the option: Solid
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' confirm option is selected: Solid
	Then In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
	Then In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Then In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
	Then in the Physical and Chemical Properties page I click Continue

	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
	Given in the Ingredients page I click Continue

	Given I call Shared Step 57932 (Regulatory - TSCA Only - Yes to All Prop 65 questions - Continue - Happy Path)
	#Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	Given I should see the Transportation Details 1 Page
	Then In the Transportation Details 1 Section, set the option in section: 'Product is Regulated for Transport': to: Yes
	Then In the Transportation Details 1 Section, set the option in section: 'Select all modes of transport that you've classified the product for': to: DOT
	Then In the Transportation Details 1 Section, set the option for DOT mode of transport to: Shipping with limited quantity
	Then in the Transportation Details 1 page I click Continue

	Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	#Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
	Then in the Regulatory Documents to Provide page I click Continue

	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
#	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
#		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient |
#		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | 41.3005               |
	Then I should be on the Safety Data Sheet Authoring - Additional Data (Optional) Page
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Personal Protection Equipment Recommended (select)' to: Gloves
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Autoignition Temperature (°C)' enter text: 501.827328
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Minimum Ignition Energy (mJ)' enter text: 10.00001
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Viscosity' enter text: 10.28
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Appearance' to: Brown
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor' to: Orange
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor Threshold' to: No data available
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Partition Coefficient' enter text: 41.3005
	Then in the Safety Data Sheet Authoring - Additional Data (Optional) page, I click Continue


	#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test data
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Absorbent Solid
	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase57295
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase57295

@TestCase:57332
Scenario: [57332] Automotive Accessories containing Gel (Seat Cushions, etc) - 8-S
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
#	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Then in the New Product page, I click Continue

	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Automotive Accessories containing Gel (Seat Cushions, etc.)
	Then I save the product information as: TestCase57332
	Given I call Shared Step 63804 (Product Information - US, No(OSHA), No(DSV), Yes (PLP), No(GNFR))
		| Classified using OSHA (US) Globally Harmonized Standards (GHS) | Shipped directly by supplier | Private Label or Brand | Good Not for resale |
		| No                                                             | No                           | No                     | No                  |
	#Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I should see the Physical and Chemical Properties Page
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' should be showing the option: Solid
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' confirm option is selected: Solid
	Then In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
	Then In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Then In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
	Then in the Physical and Chemical Properties page I click Continue

	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
	Given in the Ingredients page I click Continue
	Given I call Shared Step 57932 (Regulatory - TSCA Only - Yes to All Prop 65 questions - Continue - Happy Path)
	Given I call Shared Step 57980 (Transportation Details 1 - Yes option - Select IMDG, Limited Quantity - Continue - Happy Path)
	Given I call Shared Step 57981 (Transportation Details - UN Number Water (IMDG) - Enter UN Number and select other data - Continue - Happy Path) : 1954
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	#Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
	Then in the Regulatory Documents to Provide page I click Continue

	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
#	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
#		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient |
#		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | 41.3005               |
	Then I should be on the Safety Data Sheet Authoring - Additional Data (Optional) Page
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Personal Protection Equipment Recommended (select)' to: Gloves
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Autoignition Temperature (°C)' enter text: 501.827328
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Minimum Ignition Energy (mJ)' enter text: 10.00001
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Viscosity' enter text: 10.28
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Appearance' to: Brown
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor' to: Orange
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor Threshold' to: No data available
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Partition Coefficient' enter text: 41.3005
	Then in the Safety Data Sheet Authoring - Additional Data (Optional) page, I click Continue


	#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test data
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Automotive Accessories containing Gel (Seat Cushions, etc.)
#	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase57332
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase57332

@TestCase:58187
Scenario: [58187] Matches (RU000317) - 8-S
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
#	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Then in the New Product page, I click Continue

	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Matches
	Then I save the product information as: TestCase58187
	Given I call Shared Step 63804 (Product Information - US, No(OSHA), No(DSV), Yes (PLP), No(GNFR))
		| Classified using OSHA (US) Globally Harmonized Standards (GHS) | Shipped directly by supplier | Private Label or Brand | Good Not for resale |
		| No                                                             | No                           | No                     | No                  |
	#Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I should see the Physical and Chemical Properties Page
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' should be showing the option: Solid
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' confirm option is selected: Solid
	Then In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
	Then In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Then In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
	Then in the Physical and Chemical Properties page I click Continue

	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
	Given in the Ingredients page I click Continue

	Given I call Shared Step 57932 (Regulatory - TSCA Only - Yes to All Prop 65 questions - Continue - Happy Path)
	Given I call Shared Step 57980 (Transportation Details 1 - Yes option - Select IMDG, Limited Quantity - Continue - Happy Path)
	Given I call Shared Step 57981 (Transportation Details - UN Number Water (IMDG) - Enter UN Number and select other data - Continue - Happy Path) : 1954
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	#Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
	Then in the Regulatory Documents to Provide page I click Continue

	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
#	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
#		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient |
#		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | 41.3005               |
	Then I should be on the Safety Data Sheet Authoring - Additional Data (Optional) Page
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Personal Protection Equipment Recommended (select)' to: Gloves
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Autoignition Temperature (°C)' enter text: 501.827328
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Minimum Ignition Energy (mJ)' enter text: 10.00001
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Viscosity' enter text: 10.28
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Appearance' to: Brown
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor' to: Orange
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor Threshold' to: No data available
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Partition Coefficient' enter text: 41.3005
	Then in the Safety Data Sheet Authoring - Additional Data (Optional) page, I click Continue

	#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test data
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Matches
#	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase58187
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase58187
#check RU number and name
@TestCase:58293
Scenario: [58293] Engines for Model Rockets(RU000338) - 8-S
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
#	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Then in the New Product page, I click Continue

	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Engines for Model Rockets
	Then I save the product information as: TestCase58293
	Given I call Shared Step 63804 (Product Information - US, No(OSHA), No(DSV), Yes (PLP), No(GNFR))
        | Product is marketed for use | Classified using OSHA (US) Globally Harmonized Standards (GHS) | Shipped directly by supplier | Private Label or Brand | Good Not for resale |
		| No                          | No                                                             | No                           | No                     | No                  |
    #Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I should see the Physical and Chemical Properties Page
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' should be showing the option: Solid
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' confirm option is selected: Solid
	Then In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
	Then In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Then In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
	Then in the Physical and Chemical Properties page I click Continue

	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
	Given in the Ingredients page I click Continue
	
	Given I call Shared Step 57932 (Regulatory - TSCA Only - Yes to All Prop 65 questions - Continue - Happy Path)
	Given I call Shared Step 57980 (Transportation Details - Yes only option - Select IMDG, Fully regulated - Continue - Happy Path)
	Given I call Shared Step 57981 (Transportation Details - UN Number Water (IMDG) - Enter UN Number and select other data - Continue - Happy Path) : 1954
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	#Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
	Then in the Regulatory Documents to Provide page I click Continue

	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
#	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
#		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient |
#		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | 41.3005               |
	Then I should be on the Safety Data Sheet Authoring - Additional Data (Optional) Page
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Personal Protection Equipment Recommended (select)' to: Gloves
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Autoignition Temperature (°C)' enter text: 501.827328
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Minimum Ignition Energy (mJ)' enter text: 10.00001
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Viscosity' enter text: 10.28
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Appearance' to: Brown
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor' to: Orange
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor Threshold' to: No data available
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Partition Coefficient' enter text: 41.3005
	Then in the Safety Data Sheet Authoring - Additional Data (Optional) page, I click Continue

	#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test data
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Engines for Model Rockets
	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase58293
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase58293
@TestCase:58297
Scenario: [58297] Fireworks (RU000330) - 8-S
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
#	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Then in the New Product page, I click Continue

	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Fireworks
	Then I save the product information as: TestCase58297
	Given I call Shared Step 63804 (Product Information - US, No(OSHA), No(DSV), Yes (PLP), No(GNFR))
		| Classified using OSHA (US) Globally Harmonized Standards (GHS) | Shipped directly by supplier | Private Label or Brand | Good Not for resale |
		| No                                                             | No                           | No                     | No                  |
	#Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I should see the Physical and Chemical Properties Page
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' should be showing the option: Solid
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' confirm option is selected: Solid
	Then In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
	Then In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Then In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
	Then in the Physical and Chemical Properties page I click Continue

	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
	Given I call Shared Step 57932 (Regulatory - TSCA Only - Yes to All Prop 65 questions - Continue - Happy Path)
	#Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	Given I should see the Transportation Details 1 Page
	Then In the Transportation Details 1 Section, set the option in section: 'Product is Regulated for Transport': to: Yes
	Then In the Transportation Details 1 Section, set the option in section: 'Select all modes of transport that you've classified the product for': to: DOT
	Then In the Transportation Details 1 Section, set the option for DOT mode of transport to: Shipping with limited quantity
	Then in the Transportation Details 1 page I click Continue

	Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	#Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
	Then in the Regulatory Documents to Provide page I click Continue

	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
#	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
#		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient |
#		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | 41.3005               |
	Then I should be on the Safety Data Sheet Authoring - Additional Data (Optional) Page
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Personal Protection Equipment Recommended (select)' to: Gloves
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Autoignition Temperature (°C)' enter text: 501.827328
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Minimum Ignition Energy (mJ)' enter text: 10.00001
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Viscosity' enter text: 10.28
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Appearance' to: Brown
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor' to: Orange
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor Threshold' to: No data available
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Partition Coefficient' enter text: 41.3005
	Then in the Safety Data Sheet Authoring - Additional Data (Optional) page, I click Continue


	#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test data
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Fireworks
	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase58297
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase58297
#duplicate-
#Scenario: [57088] Engine (motor) oil for Auto or Boat
#
#Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
#
#Then The home screen should load
#
#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
#
#Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Engine (motor) oil for Auto or Boat
#
#Then I save the product information as: TestCase57088
#
#Given I call Shared Step 73629 (Physical and Chemical Properties - Liquid - select any options(enter pH, boiling point, flash point))
#| Secondary Physical State | Relative Density | pH      | Boiling Point (in Celsius) | Flash Point (in Celsius) | Flash Point Testing Method Used     | Select the best Water Solubility description |
#| Liquid                   | 2                | 2       | 2                          | 66                       | Closed cup method                   | Dispersible                                  |
#
#
#Then I add the following ingredients:
#| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
#| Water  | 100     | false               | false       |            |
#Given in the New Product page I click Continue
#
#Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
#
#Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
#
#Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)
#
#Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
#
#Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
#
#Given in the Additional Documents to Provide page I click Continue
#
#Given in the Optional Reports and Documents Available for Purchase page I click Continue
#
#Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
#| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient |
#| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | 41.3005               |
#
#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test data
#
#Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Engine (motor) oil for Auto or Boat
#
#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase57088
@TestCase:58104
Scenario: [58104] Fabric Dye - Liquid or Solid - 8-L
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
#	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Then in the New Product page, I click Continue

	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Fabric Dye - Liquid or Solid
	Then I save the product information as: TestCase58104
	Given I call Shared Step 73748 (Product Information - US only - No to GHS - No to shipped supplier - No to Private Label - No to Sold to retailer)
	Given I call Shared Step 74760 (Physical and Chemical Properties - Select Liquid as primary physical state and enter all required data)
		| Primary Physical State | Secondary Physical State | Relative Density | pH | Boiling Point (in Celsius) | Flash Point (in Celsius) | Flash Point Testing Method Used | Select the best Water Solubility description |
		| Liquid                 | Liquid                   | 2                | 2  | 2                          | 66                       | Closed cup method               | Dispersible                                  |
	Then I add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Water         | 100     | false               | false       |            |
	Given in the New Product page I click Continue
	#Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Then I should be on the Inventory Status, Prop 65 (US) Page
	And In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	And In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page, I click Continue

	Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	#Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
	Then in the Regulatory Documents to Provide page I click Continue

	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
#	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
#		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient |
#		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | 41.3005               |
	Then I should be on the Safety Data Sheet Authoring - Additional Data (Optional) Page
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Personal Protection Equipment Recommended (select)' to: Gloves
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Autoignition Temperature (°C)' enter text: 501.827328
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Minimum Ignition Energy (mJ)' enter text: 10.00001
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Viscosity' enter text: 10.28
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Appearance' to: Brown
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor' to: Orange
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor Threshold' to: No data available
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Partition Coefficient' enter text: 41.3005
	Then in the Safety Data Sheet Authoring - Additional Data (Optional) page, I click Continue


	#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test data
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Fabric Dye - Liquid or Solid
	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase58104
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase58104

@TestCase:58210
Scenario: [58210] Antibiotic, Liquid or Cream, Non-Aerosol - 8-L
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
#	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Then in the New Product page, I click Continue

	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Antibiotic, Liquid or Cream, Non-Aerosol
	Then I save the product information as: TestCase58210
	Given I call Shared Step 73748 (Product Information - US only - No to GHS - No to shipped supplier - No to Private Label - No to Sold to retailer)
	Given I call Shared Step 74760 (Physical and Chemical Properties - Select Liquid as primary physical state and enter all required data)
		| Primary Physical State | Secondary Physical State | Relative Density | pH | Boiling Point (in Celsius) | Flash Point (in Celsius) | Flash Point Testing Method Used | Select the best Water Solubility description |
		| Liquid                 | Liquid                   | 2                | 2  | 2                          | 66                       | Closed cup method               | Dispersible                                  |
	Then I add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Water         | 100     | false               | false       |            |
	Given in the New Product page I click Continue
	#Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Then I should be on the Inventory Status, Prop 65 (US) Page
	And In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	And In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page, I click Continue

	Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
	#Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	#Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)
	Given I call Shared Step 57507 (Transportation Details 1- Not Regulated - Continue - Happy Path)
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	#Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
	Then in the Regulatory Documents to Provide page I click Continue

	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
#	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
#		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient |
#		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | 41.3005               |
	Then I should be on the Safety Data Sheet Authoring - Additional Data (Optional) Page
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Personal Protection Equipment Recommended (select)' to: Gloves
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Autoignition Temperature (°C)' enter text: 501.827328
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Minimum Ignition Energy (mJ)' enter text: 10.00001
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Viscosity' enter text: 10.28
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Appearance' to: Brown
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor' to: Orange
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor Threshold' to: No data available
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Partition Coefficient' enter text: 41.3005
	Then in the Safety Data Sheet Authoring - Additional Data (Optional) page, I click Continue


	#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test data
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Antibiotic, Liquid or Cream, Non-Aerosol
#	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase58210
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase58210

@TestCase:58285
Scenario: [58285] Toothpaste - Whitening (RU001359) - 8-L
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
#	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Then in the New Product page, I click Continue

	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Toothpaste - Whitening
	Then I save the product information as: TestCase58285
	Given I call Shared Step 73748 (Product Information - US only - No to GHS - No to shipped supplier - No to Private Label - No to Sold to retailer)
	Given I call Shared Step 74760 (Physical and Chemical Properties - Select Liquid as primary physical state and enter all required data)
		| Primary Physical State | Secondary Physical State | Relative Density | pH | Boiling Point (in Celsius) | Flash Point (in Celsius) | Flash Point Testing Method Used | Select the best Water Solubility description |
		| Liquid                 | Liquid                   | 2                | 2  | 2                          | 66                       | Closed cup method               | Dispersible                                  |
	Then I add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Water         | 100     | false               | false       |            |
	Given in the New Product page I click Continue
	#Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Then I should be on the Inventory Status, Prop 65 (US) Page
	And In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	And In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page, I click Continue

	Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	#Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
	Then in the Regulatory Documents to Provide page I click Continue

	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
#	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
#		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient |
#		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | 41.3005               |
	Then I should be on the Safety Data Sheet Authoring - Additional Data (Optional) Page
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Personal Protection Equipment Recommended (select)' to: Gloves
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Autoignition Temperature (°C)' enter text: 501.827328
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Minimum Ignition Energy (mJ)' enter text: 10.00001
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Viscosity' enter text: 10.28
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Appearance' to: Brown
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor' to: Orange
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor Threshold' to: No data available
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Partition Coefficient' enter text: 41.3005
	Then in the Safety Data Sheet Authoring - Additional Data (Optional) page, I click Continue


	#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test data
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Toothpaste - Whitening
#	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase58285
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase58285

@TestCase:58401
Scenario: [58401] Correction Fluid(RU000201) - 8L
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
#	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Then in the New Product page, I click Continue

	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Correction fluid
	Then I save the product information as: TestCase58401
	Given I call Shared Step 63804 (Product Information - US, No(OSHA), No(DSV), Yes (PLP), No(GNFR))
		| Classified using OSHA (US) Globally Harmonized Standards (GHS) | Shipped directly by supplier | Private Label or Brand | Good Not for resale |
		| No                                                             | No                           | No                     | No                  |
		Given I call Shared Step 73629 (Physical and Chemical Properties - Liquid - select any options(enter pH, boiling point, flash point))
		| Secondary Physical State | Relative Density | pH | Boiling Point (in Celsius) | Flash Point (in Celsius) | Flash Point Testing Method Used | Select the best Water Solubility description |
		| Liquid                   | 2                | 2  | 2                          | 66                       | Closed cup method               | Dispersible                                  |
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Cocoa butter  | 100     | false               | false       |            |
	#Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I should see the Inventory Status, Prop 65 (US) Page
	Then In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	Then In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page I click Continue

	#Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	Given I should see the Transportation Details 1 Page
	Then In the Transportation Details 1 Section, set the option in section: 'Product is Regulated for Transport': to: Yes
	Then In the Transportation Details 1 Section, set the option in section: 'Select all modes of transport that you've classified the product for': to: DOT
	Then In the Transportation Details 1 Section, set the option for DOT mode of transport to: Shipping with limited quantity
	Then in the Transportation Details 1 page I click Continue

	Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	#Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
	Then in the Regulatory Documents to Provide page I click Continue

	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
#	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
#		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient |
#		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | 41.3005               |
	Then I should be on the Safety Data Sheet Authoring - Additional Data (Optional) Page
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Personal Protection Equipment Recommended (select)' to: Gloves
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Autoignition Temperature (°C)' enter text: 501.827328
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Minimum Ignition Energy (mJ)' enter text: 10.00001
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Viscosity' enter text: 10.28
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Appearance' to: Brown
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor' to: Orange
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor Threshold' to: No data available
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Partition Coefficient' enter text: 41.3005
	Then in the Safety Data Sheet Authoring - Additional Data (Optional) page, I click Continue

	#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Comment Text
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Correction fluid
	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase58401
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase58401
@TestCase:57339
Scenario: [57339] Craft Kits containing Glues and Paints - Crafts - 8-All - 8L
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
#	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Then in the New Product page, I click Continue

	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Craft kits containing paints and glues
	Then I save the product information as: TestCase57339
    Given I call Shared Step 63860 (Product Information - US, No(child), No(OSHA), No(DSV), Yes(PLP), No(GNFR))
		Given I call Shared Step 74760 (Physical and Chemical Properties - Select Liquid as primary physical state and enter all required data)
		| Primary Physical State | Secondary Physical State | Relative Density | pH | Boiling Point (in Celsius) | Flash Point (in Celsius) | Flash Point Testing Method Used | Select the best Water Solubility description |
		| Liquid                 | Liquid                   | 2                | 2  | 2                          | 66                       | Closed cup method               | Dispersible                                  |
    Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Cocoa butter  | 100     | false               | false       |            |
	#Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Then I should be on the Inventory Status, Prop 65 (US) Page
	And In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	And In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page, I click Continue

	And I call Shared Step 60932 (Regulatory Information 2 - Microbeads - No)
	#Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	Given I should see the Transportation Details 1 Page
	Then In the Transportation Details 1 Section, set the option in section: 'Product is Regulated for Transport': to: Yes
	Then In the Transportation Details 1 Section, set the option in section: 'Select all modes of transport that you've classified the product for': to: DOT
	Then In the Transportation Details 1 Section, set the option for DOT mode of transport to: Shipping with limited quantity
	Then in the Transportation Details 1 page I click Continue

	Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	#Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
	Then in the Regulatory Documents to Provide page I click Continue

	Given I click the browse button for label: Product Label and upload PDF: UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
#	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
#		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient |
#		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | 41.3005               |
	Then I should be on the Safety Data Sheet Authoring - Additional Data (Optional) Page
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Personal Protection Equipment Recommended (select)' to: Gloves
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Autoignition Temperature (°C)' enter text: 501.827328
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Minimum Ignition Energy (mJ)' enter text: 10.00001
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Viscosity' enter text: 10.28
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Appearance' to: Brown
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor' to: Orange
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor Threshold' to: No data available
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Partition Coefficient' enter text: 41.3005
	Then in the Safety Data Sheet Authoring - Additional Data (Optional) page, I click Continue

	#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Comment Text
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Craft kits containing paints and glues
#	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase57339
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase57339

@TestCase:57088
Scenario: [57088] Engine (motor) oil for Auto or Boat - 8L
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
#	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Then in the New Product page, I click Continue

	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Engine (motor) oil for Auto or Boat
	Then I save the product information as: TestCase57088
	Given I call Shared Step 63804 (Product Information - US, No(OSHA), No(DSV), Yes (PLP), No(GNFR))
		| Classified using OSHA (US) Globally Harmonized Standards (GHS) | Shipped directly by supplier | Private Label or Brand | Good Not for resale |
		| No                                                             | No                           | No                     | No                  |
		Given I call Shared Step 73629 (Physical and Chemical Properties - Liquid - select any options(enter pH, boiling point, flash point))
		| Secondary Physical State | Relative Density | pH | Boiling Point (in Celsius) | Flash Point (in Celsius) | Flash Point Testing Method Used | Select the best Water Solubility description |
		| Liquid                   | 2                | 2  | 2                          | 66                       | Closed cup method               | Dispersible                                  |
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Cocoa butter  | 100     | false               | false       |            |
	#Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Then I should be on the Inventory Status, Prop 65 (US) Page
	And In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	And In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page, I click Continue

	Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	#Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
	Then in the Regulatory Documents to Provide page I click Continue

	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
#	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
#		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient |
#		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | 41.3005               |
	Then I should be on the Safety Data Sheet Authoring - Additional Data (Optional) Page
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Personal Protection Equipment Recommended (select)' to: Gloves
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Autoignition Temperature (°C)' enter text: 501.827328
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Minimum Ignition Energy (mJ)' enter text: 10.00001
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Viscosity' enter text: 10.28
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Appearance' to: Brown
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor' to: Orange
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor Threshold' to: No data available
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Partition Coefficient' enter text: 41.3005
	Then in the Safety Data Sheet Authoring - Additional Data (Optional) page, I click Continue

	#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Comment Text
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Engine (motor) oil for Auto or Boat
#	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase57088
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase57088

@TestCase:57709
Scenario: [57709] Training aid repellant (RU000326) - 8LS -8L
	Given I generate a random UPC number and save as: UPC57709
	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
#	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Then in the New Product page, I click Continue

	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Training aid repellant
	Then I save the product information as: TestCase57709
	#Given I call Shared Step 57401 (Product Information - US only - No GHS, Not Direct Ship, Not PLP, Not GNFR > Continue - Happy Path)
	Given I should see the Product Information Page
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue
	#Given I call Shared Step 57501 (Physical and Chemical Properties - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue - HP)
	Given In the Physical and Chemical Properties Section, set the option in section: 'Primary Physical State' to: Solid
	Given In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Bonded, fibrous glass web
	Given In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Given In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
	Given I click continue
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
	#And I call Shared Step 132370 (Waste Classification Data - TSCA (Random) - Prop 65 (No) - Continue - Happy Path)
	Given I should see the Inventory Status, Prop 65 (US) Page
	Then In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	Then In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page I click Continue

	Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
	#Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	Given I should see the Transportation Details 1 Page
	Then In the Transportation Details 1 Section, set the option in section: 'Product is Regulated for Transport': to: Yes
	Then In the Transportation Details 1 Section, set the option in section: 'Select all modes of transport that you've classified the product for': to: DOT
	Then In the Transportation Details 1 Section, set the option for DOT mode of transport to: Shipping with limited quantity
	Then in the Transportation Details 1 page I click Continue

	Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)
#	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Amazon
	Then I should be on the Retailer Page
	And In the Retailer Section, click 'Add Retailers' button
	And In the Select Retailers window, select retailer: Amazon
	And In the Select Retailers window, click 'Done' button
	Then in the Retailer page, I click Continue

Then I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC57709, container type: Cardboard and size: 1
    #Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
	Then in the Regulatory Documents to Provide page I click Continue

	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
#	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
#		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Product's Dispensing Method | Partition Coefficient |
#		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | Aerosol                     | 41.3005               |
	Then I should be on the Safety Data Sheet Authoring - Additional Data (Optional) Page
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Personal Protection Equipment Recommended (select)' to: Gloves
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Autoignition Temperature (°C)' enter text: 501.827328
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Minimum Ignition Energy (mJ)' enter text: 10.00001
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Viscosity' enter text: 10.28
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Appearance' to: Brown
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor' to: Orange
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor Threshold' to: No data available
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Partition Coefficient' enter text: 41.3005
	Then in the Safety Data Sheet Authoring - Additional Data (Optional) page, I click Continue


	#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Comment Text
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Training aid repellant
#	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase57709
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase57709

@TestCase:128744
Scenario: [128744] Ammunition - DOT Exceptions Saved
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
#	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Then in the New Product page, I click Continue

	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Ammunition
	Then I save the product information as: TestCase128744
	Given I call Shared Step 60310 (Product Information - Without Child question)
	#Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I should see the Physical and Chemical Properties Page
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' should be showing the option: Solid
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' confirm option is selected: Solid
	Then In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
	Then In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Then In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
	Then in the Physical and Chemical Properties page I click Continue

	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
	#Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Then I should be on the Inventory Status, Prop 65 (US) Page
	And In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	And In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page, I click Continue

	Given I call Shared Step 128742 (Transportation Details - Regulated for Transport(No) - Exemption(Random) - Continue - Happy Path)
	Given I call Shared Step (Transportation Details - Confirm DOT Exceptions saved - Continue - Happy Path)
#	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase128744
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase128744

	@ignore
#Removed from regression 2023/11
	@TestCase:128743
Scenario: [128743] Ammunition - Other DOT Exception Validation
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
#	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Then in the New Product page, I click Continue

	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Ammunition
	Then I save the product information as: TestCase128743
	Given I call Shared Step 60310 (Product Information - Without Child question)
	#Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I should see the Physical and Chemical Properties Page
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' should be showing the option: Solid
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' confirm option is selected: Solid
	Then In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
	Then In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Then In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
	Then in the Physical and Chemical Properties page I click Continue

	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
	#Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Then I should be on the Inventory Status, Prop 65 (US) Page
	And In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	And In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page, I click Continue

	Given I call Shared Step 128742 (Transportation Details - Regulated for Transport(No) - Exemption(Random) - Continue - Happy Path)
	Given I call Shared Step (Transportation Details - Other DOT Exception Validation - Continue - Happy Path)
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase128743

# Ignore execution in QA-Integration Environment as SHA Automation is set to OFF
# Created by Saikiran Chittampally
@OnlyInStaging
@TestCase:213999	
Scenario: [213999] WERCSmart Portal and SHA Manager Test Flow for Product Type:  Plant Food (RU000148) 
	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC213999
	Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Plant Food
	Then I save the product information as: TestCase213999
	Given I should see the Product Information Page
	Given I call Shared Step 214032 (Product Information - Pesticide= Not considered, Fertilizer=YES, SOLD=US, everything else = No - Continue)
	Then a Warning popup dialog should appear with the message: The ratio of Slow-Release Agent to Nitrogen will prohibit sale and use of this product during Pinellas County regional watershed (June 1 through September 30). This is informational only and will not restrict your registration to the Retailer.
	Then I set the Nitrogen /Nitrates field to: 12
	Then I set the Phosphates /Phosphorous field to: 3	
	Then I set the Potassium field to: 12
	Then I set the Slow-Release Agent field to: 6
	Then I click continue
	Then a Warning popup dialog should appear with the message: The ratio of Slow-Release Agent to Nitrogen will prohibit sale and use of this product during Pinellas County regional watershed (June 1 through September 30). This is informational only and will not restrict your registration to the Retailer.
	Given I call Shared Step 214034 (Physical and Chemical Properties - Applicable Only to Plant Food)
	Then I add the following ingredients:
		| ComponentName     | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| 57-13-6        | 33      | false               | false       |            |
		| 7664-38-2 | 50      | false               | false       |            |
		| 10117-38-1            | 17       | false               | false       |            |
	Given I click continue
	#Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I should see the Inventory Status, Prop 65 (US) Page
	Then In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	Then In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page I click Continue

	#And I call Shared Step 57507 (Transportation Details 1- Not Regulated - Continue - Happy Path)
	Then I should be on the Transportation Details 1 Page
	And In the Transportation Details 1 Section, set the option in section: 'Product is Regulated for Transport': to: Not Regulated
	Then in the Transportation Details 1 page, I click Continue

	#Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Wal-Mart/SAM'S CLUB
	Then I should be on the Retailer Page
	And In the Retailer Section, click 'Add Retailers' button
	And In the Select Retailers window, select retailer: Wal-Mart/SAM'S CLUB
	And In the Select Retailers window, click 'Done' button
	Then in the Retailer page, I click Continue
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)


	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Wal-Mart/SAM'S CLUB	
	Given In the Retailers tab, I select the first Vendor option for retailer: Wal-Mart/SAM'S CLUB
	Then I click continue
	Given I call Shared Step 87647 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC213999, container type: Plastic Container and size: 18 do not click continue
	And I confirm that retailer "WM" is present under the 'Destination Retailers' column in the UPC table
	Then I click continue
	And  I call Shared Step 78080 (Regulatory Documents to Provide - Upload OSHA SDS)
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Test
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Plant food
	#Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given I should see the Data Acceptance Page
	Then In the Data Acceptance Section, check 'Agreed' checkbox
	Then In the Data Acceptance Section, click 'Accept' button

	Then If purchase details are showing click confirm order
	Given I navigate to the landing page
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase213999)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Assigned Status for saved as: TestCase213999)
	Then I call Shared Step 65969 (Go to Power Designer Plus - Select your product & CKLT - Continue)
	Given I call Shared Step 209526(b) (WPS Studio - PD+ - set all data and publish using rule and doc queue for CKLT and MTR only) for product saved as: TestCase213999
	Then I call Shared Step 209552 Power Designer Plus - APPLY RULES To Product
	Then I call Sared Step 214627 Power Designer Plus - PUBLISH Product (Applicable Only to Battery Products ): TestCase213999
	When I switch to the 'Power Designer Plus' tab
	Given I call Shared Step 231412 I add the UsageType: PVAL: Product Value with Datacode FERTN with data: Nitrogen / Nitrates to the Section - Applicable Only to Type of Product
	Given I confirm data code with data:Nitrogen / Nitrates with value:12 added
	Given I remove the Datacode:Nitrogen / Nitrates to the Section - Applicable Only to Type of Product
	Given I call Shared Step 231412 I add the UsageType: PVAL: Product Value with Datacode FERTP with data: Phosphates / Phosphorous to the Section - Applicable Only to Type of Product
	Given I confirm data code with data:Phosphates / Phosphorous with value:3 added
	Given I remove the Datacode:Phosphates / Phosphorous to the Section - Applicable Only to Type of Product
	Given I call Shared Step 231412 I add the UsageType: PVAL: Product Value with Datacode FERTK with data: Potassium to the Section - Applicable Only to Type of Product
	Given I confirm data code with data:Potassium with value:12 added
	Given I remove the Datacode:Potassium to the Section - Applicable Only to Type of Product	
	Given I call Shared Step 231412 I add the UsageType: PVAL: Product Value with Datacode FERTS with data: Slow-Release Agent to the Section - Applicable Only to Type of Product
	Given I confirm data code with data:Slow-Release Agent with value:6 added
	Given I remove the Datacode:Slow-Release Agent to the Section - Applicable Only to Type of Product
	Given I call Shared Step 231412 I add the UsageType: PTXT: Product Text with Datacode PCFR with data: Restricted Fertilizer in Pinellas County, Florida to the Section - Applicable Only to Type of Product
	Given I confirm data code with data:Restricted Fertilizer in Pinellas County, Florida with value:May be sold only October 1 through May 31, Pinellas County, Florida added 
	Given I remove the Datacode:Restricted Fertilizer in Pinellas County, Florida to the Section - Applicable Only to Type of Product
	Given I call Shared Step 59066 (Go to SHA Manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Completed Status for saved as: TestCase213999)


# Ignore execution in QA-Integration Environment as SHA Automation is set to OFF
# Created by Saikiran Chittampally
@TestCase:214039
Scenario: [214039] Test Case 214039: WERCSmart Portal and SHA Manager Test Flow for Product Type: SOIL (RU001075)
	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC214039
	Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Soil (No Additives, Fertilizers, or Inhibitors)
	Then I save the product information as: TestCase214039
	Given I should see the Product Information Page
	Given I call Shared Step 214040 (Product Information -Applicable Only to Type of Product: SOIL No - Continue)
	Given I call Shared Step 214041 (Physical and Chemical Properties - Applicable Only to SOIL)
	Then I add the following ingredients:
		| ComponentName     | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| N/A209      | 50      | false               | false       |            |
		| 308075-07-2 | 50      | false               | false       |            |
	Given I click continue
	Given I call Shared Step 231514 (Inventory Status, Prop 65 - Applicable Only to SOIL)
#	And I call Shared Step 57507 (Transportation Details 1- Not Regulated - Continue - Happy Path)
	Then I should be on the Transportation Details 1 Page
	And In the Transportation Details 1 Section, set the option in section: 'Product is Regulated for Transport': to: Not Regulated
	Then in the Transportation Details 1 page, I click Continue
	#Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Wal-Mart/SAM'S CLUB
	Then I should be on the Retailer Page
	And In the Retailer Section, click 'Add Retailers' button
	And In the Select Retailers window, select retailer: Wal-Mart/SAM'S CLUB
	And In the Select Retailers window, click 'Done' button
	Then in the Retailer page, I click Continue

	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Wal-Mart/SAM'S CLUB	
	Given In the Retailers tab, I select the first Vendor option for retailer: Wal-Mart/SAM'S CLUB
	Then I click continue
	Given I call Shared Step 87647 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC214039, container type: Plastic bag and size: 56 do not click continue
	And I confirm that retailer "WM" is present under the 'Destination Retailers' column in the UPC table
	Then I click continue
	And  I call Shared Step 78080 (Regulatory Documents to Provide - Upload OSHA SDS)
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Test
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Soil (No Additives, Fertilizers, or Inhibitors)
	#Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given I should see the Data Acceptance Page
	Then In the Data Acceptance Section, check 'Agreed' checkbox
	Then In the Data Acceptance Section, click 'Accept' button

	Then If purchase details are showing click confirm order
	Given I navigate to the landing page
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase214039)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Assigned Status for saved as: TestCase214039)
	Then I call Shared Step 65969 (Go to Power Designer Plus - Select your product & CKLT - Continue)
	Given I call Shared Step 209526 (WPS Studio - PD+ - set all data and publish using rule and doc queue - CKLT and MTR only) for product saved as: TestCase214039
	Then I call Shared Step 209552 Power Designer Plus - APPLY RULES To Product
	Then I call Sared Step 214627 Power Designer Plus - PUBLISH Product (Applicable Only to Battery Products ): TestCase214039
	When I switch to the 'Power Designer Plus' tab
	Given I call Shared Step 231412 I add the UsageType: PVAL: Product Value with Datacode FERTN with data: Nitrogen / Nitrates to the Section - Applicable Only to Type of Product
	Given I confirm data code with data:Nitrogen / Nitrates with value:  added
	Given I remove the Datacode:Nitrogen / Nitrates to the Section - Applicable Only to Type of Product
	Given I call Shared Step 231412 I add the UsageType: PVAL: Product Value with Datacode FERTP with data: Phosphates / Phosphorous to the Section - Applicable Only to Type of Product
	Given I confirm data code with data:Phosphates / Phosphorous with value:  added
	Given I remove the Datacode:Phosphates / Phosphorous to the Section - Applicable Only to Type of Product
	Given I call Shared Step 231412 I add the UsageType: PVAL: Product Value with Datacode FERTK with data: Potassium to the Section - Applicable Only to Type of Product
	Given I confirm data code with data:Potassium with value:  added
	Given I remove the Datacode:Potassium to the Section - Applicable Only to Type of Product	
	Given I call Shared Step 231412 I add the UsageType: PVAL: Product Value with Datacode FERTS with data: Slow-Release Agent to the Section - Applicable Only to Type of Product
	Given I confirm data code with data:Slow-Release Agent with value:  added
	Given I remove the Datacode:Slow-Release Agent to the Section - Applicable Only to Type of Product
	Given I call Shared Step 231412 I add the UsageType: PTXT: Product Text with Datacode PCFR with data: Restricted Fertilizer in Pinellas County, Florida to the Section - Applicable Only to Type of Product
	Given I confirm data code with data:Restricted Fertilizer in Pinellas County, Florida with value:  added
	Given I remove the Datacode:Restricted Fertilizer in Pinellas County, Florida to the Section - Applicable Only to Type of Product
	Given I call Shared Step 59066 (Go to SHA Manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Completed Status for saved as: TestCase214039)

