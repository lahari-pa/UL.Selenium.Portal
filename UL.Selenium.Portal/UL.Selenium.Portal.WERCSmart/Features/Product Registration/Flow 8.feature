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
Feature: Flow 8

@TestCase:57295
Scenario: [57295] Absorbent solid - Automotive(RU000939) - 8-S
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Absorbent Solid
	Then I save the product information as: TestCase57295
	Given I call Shared Step 63804 (Product Information - US, No(OSHA), No(DSV), Yes (PLP), No(GNFR))
		| Classified using OSHA (US) Globally Harmonized Standards (GHS) | Shipped directly by supplier | Private Label or Brand | Good Not for resale |
		| No                                                             | No                           | No                     | No                  |
		Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
	Given in the Ingredients page I click Continue

	Given I call Shared Step 57932 (Regulatory - TSCA Only - Yes to All Prop 65 questions - Continue - Happy Path)
	Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient |
		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | 41.3005               |
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test data
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Absorbent Solid
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase57295

@TestCase:57332
Scenario: [57332] Automotive Accessories containing Gel (Seat Cushions, etc) - 8-S
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Automotive Accessories containing Gel (Seat Cushions, etc.)
	Then I save the product information as: TestCase57332
	Given I call Shared Step 63804 (Product Information - US, No(OSHA), No(DSV), Yes (PLP), No(GNFR))
		| Classified using OSHA (US) Globally Harmonized Standards (GHS) | Shipped directly by supplier | Private Label or Brand | Good Not for resale |
		| No                                                             | No                           | No                     | No                  |
		Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
	Given in the Ingredients page I click Continue
	Given I call Shared Step 57932 (Regulatory - TSCA Only - Yes to All Prop 65 questions - Continue - Happy Path)
	Given I call Shared Step 57980 (Transportation Details 1 - Yes option - Select IMDG, Limited Quantity - Continue - Happy Path)
	Given I call Shared Step 57981 (Transportation Details - UN Number Water (IMDG) - Enter UN Number and select other data - Continue - Happy Path) : 1954
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient |
		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | 41.3005               |
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test data
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Automotive Accessories containing Gel (Seat Cushions, etc.)
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase57332

#Remove from regression: 2023/05
@ignore
@TestCase:58184
Scenario: [58184] Craft kits containing clays or plasters(RU000299) - 8-S
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Craft kits containing clays or plasters
	Then I save the product information as: TestCase58184
	Given I call Shared Step 63804 (Product Information - US, No(OSHA), No(DSV), Yes (PLP), No(GNFR))
		| Product is marketed for use | Classified using OSHA (US) Globally Harmonized Standards (GHS) | Shipped directly by supplier | Private Label or Brand | Good Not for resale |
		| No                          | No                                                             | No                           | No                     | No                  |
    Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
	Given in the Ingredients page I click Continue

	Given I call Shared Step 57932 (Regulatory - TSCA Only - Yes to All Prop 65 questions - Continue - Happy Path)
	Given I call Shared Step 57980 (Transportation Details 1 - Yes option - Select IMDG, Limited Quantity - Continue - Happy Path)
	Given I call Shared Step 57981 (Transportation Details - UN Number Water (IMDG) - Enter UN Number and select other data - Continue - Happy Path) : 1954
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient |
		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | 41.3005               |
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test data
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Craft kits containing clays or plasters
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase58184

@TestCase:58187
Scenario: [58187] Matches (RU000317) - 8-S
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Matches
	Then I save the product information as: TestCase58187
	Given I call Shared Step 63804 (Product Information - US, No(OSHA), No(DSV), Yes (PLP), No(GNFR))
		| Classified using OSHA (US) Globally Harmonized Standards (GHS) | Shipped directly by supplier | Private Label or Brand | Good Not for resale |
		| No                                                             | No                           | No                     | No                  |
		Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
	Given in the Ingredients page I click Continue

	Given I call Shared Step 57932 (Regulatory - TSCA Only - Yes to All Prop 65 questions - Continue - Happy Path)
	Given I call Shared Step 57980 (Transportation Details 1 - Yes option - Select IMDG, Limited Quantity - Continue - Happy Path)
	Given I call Shared Step 57981 (Transportation Details - UN Number Water (IMDG) - Enter UN Number and select other data - Continue - Happy Path) : 1954
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient |
		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | 41.3005               |
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test data
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Matches
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase58187

#check RU number and name
@TestCase:58293
Scenario: [58293] Engines for Model Rockets(RU000338) - 8-S
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Engines for Model Rockets
	Then I save the product information as: TestCase58293
	Given I call Shared Step 63804 (Product Information - US, No(OSHA), No(DSV), Yes (PLP), No(GNFR))
        | Product is marketed for use | Classified using OSHA (US) Globally Harmonized Standards (GHS) | Shipped directly by supplier | Private Label or Brand | Good Not for resale |
		| No                          | No                                                             | No                           | No                     | No                  |
    Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
	Given in the Ingredients page I click Continue
	
	Given I call Shared Step 57932 (Regulatory - TSCA Only - Yes to All Prop 65 questions - Continue - Happy Path)
	Given I call Shared Step 57980 (Transportation Details - Yes only option - Select IMDG, Fully regulated - Continue - Happy Path)
	Given I call Shared Step 57981 (Transportation Details - UN Number Water (IMDG) - Enter UN Number and select other data - Continue - Happy Path) : 1954
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient |
		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | 41.3005               |
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test data
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Engines for Model Rockets
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase58293

@TestCase:58297
Scenario: [58297] Fireworks (RU000330) - 8-S
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Fireworks
	Then I save the product information as: TestCase58297
	Given I call Shared Step 63804 (Product Information - US, No(OSHA), No(DSV), Yes (PLP), No(GNFR))
		| Classified using OSHA (US) Globally Harmonized Standards (GHS) | Shipped directly by supplier | Private Label or Brand | Good Not for resale |
		| No                                                             | No                           | No                     | No                  |
		Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
	Given I call Shared Step 57932 (Regulatory - TSCA Only - Yes to All Prop 65 questions - Continue - Happy Path)
	Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient |
		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | 41.3005               |
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test data
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Fireworks
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase58297

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
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
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
	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient |
		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | 41.3005               |
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test data
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Fabric Dye - Liquid or Solid
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase58104

@tfs_design
#Remove from regression: 2023/05
@ignore
@TestCase:57344
Scenario: [57344] Artists Solvent-Thinner - 8-L
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Artist's Solvent/Thinner
	Then I save the product information as: TestCase57344
	Given I call Shared Step 73748 (Product Information - US only - No to GHS - No to shipped supplier - No to Private Label - No to Sold to retailer)
	Given I call Shared Step 73629 (Physical and Chemical Properties - Liquid - select any options(enter pH, boiling point, flash point))
		| Secondary Physical State | Relative Density | pH | Boiling Point (in Celsius) | Flash Point (in Celsius) | Flash Point Testing Method Used | Select the best Water Solubility description |
		| Liquid                   | 2                | 2  | 2                          | 66                       | Closed cup method               | Dispersible                                  |
	Then I add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Water         | 100     | false               | false       |            |
	Given in the New Product page I click Continue
	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient |
		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | 41.3005               |
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test data
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Artist's Solvent/Thinner
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase57344

@TestCase:58210
Scenario: [58210] Antibiotic, Liquid or Cream, Non-Aerosol - 8-L
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
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
	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
	#Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	#Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)
	Given I call Shared Step 57507 (Transportation Details 1- Not Regulated - Continue - Happy Path)
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient |
		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | 41.3005               |
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test data
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Antibiotic, Liquid or Cream, Non-Aerosol
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase58210

#Remove from regression: 2023/05
@ignore
@TestCase:58282
Scenario: [58282] Dental Whitening Gel - 8-L
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Dental whitening gel
	Then I save the product information as: TestCase58282
	Given I call Shared Step 73748 (Product Information - US only - No to GHS - No to shipped supplier - No to Private Label - No to Sold to retailer)
	Given I call Shared Step 73629 (Physical and Chemical Properties - Liquid - select any options(enter pH, boiling point, flash point))
		| Secondary Physical State | Relative Density | pH | Boiling Point (in Celsius) | Flash Point (in Celsius) | Flash Point Testing Method Used | Select the best Water Solubility description |
		| Liquid                   | 2                | 2  | 2                          | 66                       | Closed cup method               | Dispersible                                  |
	Then I add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Water         | 100     | false               | false       |            |
	Given in the New Product page I click Continue
	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
	Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient |
		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | 41.3005               |
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test data
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Dental whitening gel
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase58282

@TestCase:58285
Scenario: [58285] Toothpaste - Whitening (RU001359) - 8-L
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
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
	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient |
		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | 41.3005               |
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test data
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Toothpaste - Whitening
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase58285

#Remove from regression: 2023/05
@ignore
@TestCase:58390
Scenario: [58390] Paint,Model - RU000333
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Paint, Model
	Then I save the product information as: TestCase58390
	Given I call Shared Step 73748 (Product Information - US only - No to GHS - No to shipped supplier - No to Private Label - No to Sold to retailer)
	Given I call Shared Step 73629 (Physical and Chemical Properties - Liquid - select any options(enter pH, boiling point, flash point))
		| Secondary Physical State | Relative Density | pH | Boiling Point (in Celsius) | Flash Point (in Celsius) | Flash Point Testing Method Used | Select the best Water Solubility description |
		| Liquid                   | 2                | 2  | 2                          | 66                       | Closed cup method               | Dispersible                                  |
	Then I add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Water         | 100     | false               | false       |            |
	Given in the New Product page I click Continue
	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient |
		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | 41.3005               |
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test data
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Paint, Model

@TestCase:58401
Scenario: [58401] Correction Fluid(RU000201) - 8L
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
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
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient |
		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | 41.3005               |
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Comment Text
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Correction fluid
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase58401

@TestCase:57339
Scenario: [57339] Craft Kits containing Glues and Paints - Crafts - 8-All - 8L
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Craft kits containing paints and glues
	Then I save the product information as: TestCase57339
    Given I call Shared Step 63860 (Product Information - US, No(child), No(OSHA), No(DSV), Yes(PLP), No(GNFR))
		Given I call Shared Step 74760 (Physical and Chemical Properties - Select Liquid as primary physical state and enter all required data)
		| Primary Physical State | Secondary Physical State | Relative Density | pH | Boiling Point (in Celsius) | Flash Point (in Celsius) | Flash Point Testing Method Used | Select the best Water Solubility description |
		| Liquid                 | Liquid                   | 2                | 2  | 2                          | 66                       | Closed cup method               | Dispersible                                  |
    Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Cocoa butter  | 100     | false               | false       |            |
	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	And I call Shared Step 60932 (Regulatory Information 2 - Microbeads - No)
	Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I click the browse button for label: Product Label and upload PDF: UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient |
		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | 41.3005               |
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Comment Text
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Craft kits containing paints and glues
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase57339

#Remove from regression: 2023/05
@ignore
@TestCase:58810
Scenario: [58810] Helium Tank(RU000340) - 8G
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Helium tank
	Then I save the product information as: TestCase58810
	Given I call Shared Step 63804 (Product Information - US, No(OSHA), No(DSV), Yes (PLP), No(GNFR))
		| Classified using OSHA (US) Globally Harmonized Standards (GHS) | Shipped directly by supplier | Private Label or Brand | Good Not for resale |
		| No                                                             | No                           | No                     | No                  |
		Given I call Shared Step 74981 (Physical and Chemical Properties - gas)
		| Secondary Physical State | Select the best Water Solubility description |
		| Compressed gas           | Low                                          |
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Cocoa butter  | 100     | false               | false       |            |
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient |
		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | 41.3005               |
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Comment Text
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Helium tank
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase58810

#Remove from regression: 2023/05
@ignore
@TestCase:58815
Scenario: [58815] Lighters(RU000000) - 8G
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Lighters
	Then I save the product information as: TestCase58815
	Given I call Shared Step 63804 (Product Information - US, No(OSHA), No(DSV), Yes (PLP), No(GNFR))
		| Classified using OSHA (US) Globally Harmonized Standards (GHS) | Shipped directly by supplier | Private Label or Brand | Good Not for resale |
		| No                                                             | No                           | No                     | No                  |
		Given I call Shared Step 74981 (Physical and Chemical Properties - gas)
		| Secondary Physical State | Select the best Water Solubility description |
		| Compressed gas           | Low                                          |
Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Cocoa butter  | 100     | false               | false       |            |
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient |
		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | 41.3005               |
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Comment Text
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Lighters
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase58815

@TestCase:57088
Scenario: [57088] Engine (motor) oil for Auto or Boat - 8L
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
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
	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient |
		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | 41.3005               |
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Comment Text
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Engine (motor) oil for Auto or Boat
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase57088

@TestCase:57709
Scenario: [57709] Training aid repellant (RU000326) - 8LS -8L
	Given I generate a random UPC number and save as: UPC57709
	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Training aid repellant
	Then I save the product information as: TestCase57709
	Given I call Shared Step 57401 (Product Information - US only - No GHS, Not Direct Ship, Not PLP, Not GNFR > Continue - Happy Path)
	Given I call Shared Step 57501 (Physical and Chemical Properties - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue - HP)
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
	And I call Shared Step 132370 (Waste Classification Data - TSCA (Random) - Prop 65 (No) - Continue - Happy Path)
	Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
	Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)
	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Amazon
    Then I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC57709, container type: Cardboard and size: 1
    Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Product's Dispensing Method | Partition Coefficient |
		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | Aerosol                     | 41.3005               |
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Comment Text
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Training aid repellant
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase57709

@tfs_design
#Remove from regression: 2023/05
@ignore
@TestCase:75840
Scenario: [75840] Single Purpose Cleaner - Flow 8-AL (RU001123)
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC75840
	Given I delete all products with UPC Number: saved as UPC75840
	Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Single Purpose Cleaner
	Given I save the product information as: TestCase75840
	Given I call Shared Step 57401 (Product Information - US only - No GHS, Not Direct Ship, Not PLP, Not GNFR > Continue - Happy Path)
	Given I call Shared Step 57501 (Physical and Chemical Properties - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue)

	#Given I call Shared Step 57539 (Physical and Chemical Properties - Aerosol & Liquid select Aerosol - Continue - Happy Path)
	Given I call Shared Step 69557 (Enter Ingredients for Aerosol Propellent)
	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given I call Shared Step 57589 (Enter Pesticide Data - United States (without EPA number))
	Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Then I should see the Additional Documents to Provide Page
	#And I call Shared Step 60567 (Upload Product Label only) for section: Upload Full Product Label (required)
	Given in the Additional Documents to Provide page I click Continue
	Then I should see the Optional Reports and Documents Available for Purchase Page
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient | Product's Dispensing Method |
		| Gloves                        | 200                      | 5.55                    | 10.5      | Brown      | Orange | No data available | 4.3205                | Aerosol                     |
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Comment Text
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Single Purpose Cleaner
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase75840

#Remove from regression: 2023/05
@ignore
@TestCase:117894
Scenario: [117894] Fireworks (RU000330) - 8-S - UN0358 - Net Explosive Mass UPC Upload
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Then I generate 7 random UPC numbers and save all to list named: UPC_Jacob
	Then I delete all products in contextual list of UPCs: UPC_Jacob
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Fireworks
	Then I save the product information as: TestCase117894
	Given I call Shared Step 63804 (Product Information - US, No(OSHA), No(DSV), Yes (PLP), No(GNFR))
		| Classified using OSHA (US) Globally Harmonized Standards (GHS) | Shipped directly by supplier | Private Label or Brand | Good Not for resale |
		| No                                                             | No                           | No                     | No                  |
		Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
	Given I call Shared Step 57932 (Regulatory - TSCA Only - Yes to All Prop 65 questions - Continue - Happy Path)
	Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)
	Given I select the following retailers in the Select Retailers popup list view:
		| Retailer |
		| Amazon   |
	Then I click Done on Select Retailers window
	Then I click continue
	And I click Sample File link and verify the Upload UPC form and save it as test117894
         | UPC          | Name | Quantity | Size | Net Explosive Mass | US: Part Number | US: Item Number | GP: Part Number | SP: Part Number | TG: DPCI    | HD: OMSID | CT: Item Number   | Green Good Housekeeping | Green Seal | EPA Safer Choice | Cradle to Cradle | UL Ecologo | EWG Verified | Green Tick | Madesafe | NSF Sustainability Certified |
         | 823973000000 |      | 1        | 11   | 1.22               | 11AB45          | 1001            | 1111            | A0001           | 111-22-0001 | 100000001 | 123-1234,123-1230 | Yes                     |            |                  |                  |            | Yes          |            |          | Yes                          |
         | 71617198008  |      | 2        | 22   | 2.33               | 12AB56          | 1002            | 2222            | B0002           | 111-22-0002 | 100000002 | 123-1234,123-1231 |                         | Yes        |                  |                  |            |              | Yes        |          |                              |
         | 978959000000 |      | 3        | 33   | 3.44               | 12AC67          | 1003            | 3333            | C0003           | 111-22-0003 | 100000003 | 123-1234,123-1232 |                         |            | Yes              |                  |            |              |            |          |                              |
         | 688267000000 |      | 4        | 44   | 4.55               | 12AD89          | 1004            | 4444            | D0004           | 111-22-0004 | 100000004 | 123-1234,123-1233 |                         |            |                  | Yes              |            |              |            | Yes      |                              |
         | 854911000000 |      | 5        | 55   | 5.66               | 12AF00          | 1005            | 5555            | E0005           | 111-22-0005 | 100000005 | 123-1234,123-1234 |                         |            |                  |                  | Yes        |              |            |          |                              |
	
	And I edit the testdoc.xlsx, and save its filepath as: Bulktest117894 and verify it contains the UPC data in the table saved as: UPCTable117894, (Base Data Only: true)
		| UPC           | Name      | Quantity | Size | Net Explosive Mass | US: Part Number | GP: Part Number | SP:Part Number | TG: DPCI    | HD: OMSID | CT: Item Number    | Green Good Housekeeping | Green Seal | EPA Safer Choice | Cradle to Cradle | UL Ecologo | EWG Verified | Green Tick | Madesafe | NSF Sustainability Certified |
		| %UPC_Jacob_1% | Firework1 | 1        | 11   | N/A                | 1001            | 1111            | A0001          | 111-22-0001 | 100000001 | 123-1234, 123-1230 |                         |            |                  |                  |            |              |            |          |                              |
		| %UPC_Jacob_2% | Firework2 | 2        | 12   | 1.230              | 1002            | 2222            | A0002          | 111-22-0002 | 100000002 | 123-1234, 123-1231 |                         |            |                  |                  |            |              |            |          |                              |
		| %UPC_Jacob_3% | Firework3 | 3        | 13   | 1.23               | 1003            | 3333            | A0003          | 111-22-0003 | 100000003 | 123-1234, 123-1232 |                         |            |                  |                  |            |              |            |          |                              |
		| %UPC_Jacob_4% | Firework4 | 4        | 14   | 2                  | 1004            | 4444            | A0004          | 111-22-0004 | 100000004 | 123-1234, 123-1233 |                         |            |                  |                  |            |              |            |          |                              |
		| %UPC_Jacob_5% | Firework5 | 5        | 15   | 2.1                | 1005            | 5555            | A0005          | 111-22-0005 | 100000005 | 123-1234, 123-1234 |                         |            |                  |                  |            |              |            |          |                              |
		| %UPC_Jacob_6% | Firework6 | 6        | 16   | -1                 | 1006            | 6666            | A0006          | 111-22-0006 | 100000006 | 123-1234, 123-1235 |                         |            |                  |                  |            |              |            |          |                              |
		| %UPC_Jacob_0% | Firework7 | 7        | 1    | NA                 | 1007            | 7777            | A0007          | 111-22-0007 | 100000007 | 123-1234, 123-1236 |                         |            |                  |                  |            |              |            |          |                              |
	Then I click the 'Upload File' button and upload the file saved as: Bulktest117894
	Then I confirm that Add Multiple UPC popup appears and the values are the same as the UPC Upload document saved in the Table called: UPCTable117894
	Then In the Add Multiple dialog box I select all UPCs
	Then I Confirm All UPCs are: Selected
	Then In the Add Multiple dialog box I select the packaging type: <first>
	Then I Check that the type column becomes populated with option: <first>
	Given In the Add Multiple dialog box I click Next
	Then In the Add Multiple dialog box I select all Retailers
	Then I Check if all Retailers are: Selected
	Then In the Add Multiple dialog box I click Finish
	And I confirm that Add Multiple UPC popup disappears and the values on the new product screen are the same as the UPC Upload document saved in the Table called: UPCTable117894
	Then I click Continue and should not see an error message
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient |
		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | 41.3005               |
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test data
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Fireworks
	Then I navigate to the home page
	Then I delete all products in contextual list of UPCs: UPC_Jacob


#Remove from regression: 2023/05
@ignore
@TestCase:144527
Scenario: [144527] Medical Test Kit With Alcohol Swab - RU000955 - Flow 8S
	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Medical Test Kit With Alcohol Swab
	Given I generate a random UPC number and save as: UPC144527
	Then I save the product information as: TestCase144527
	Given I call Shared Step 57401 (Product Information - US only - No GHS, Not Direct Ship, Not PLP, Not GNFR > Continue - Happy Path)
	Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| CASNumber | ComponentName | Percent | PublicallyDisclosed | PublicName | TradeSecret |
		|           | Alcohol       | 100     |                     |            |             |
	Given I call Shared Step 132370 (Waste Classification Data - TSCA (Random) - Prop 65 (No) - Continue - Happy Path)
	And I set the Product is Regulated for Transport option to: No, due to an exemption or exception
	And The following checkboxes should be displayed for section: Please select DOT Exceptions if applicable?
		| Checkbox																		                                                    |
		|  172.102(c) - Special Provision 47: Product contains 10 mL or less of a Class 3 liquid and is fully absorbed with no free liquid. |
	And The following checkboxes should not be displayed for section: Please select DOT Exceptions if applicable?
		| Checkbox														|
		| 173.159 (a) - Exemption for non-spillable lead-acid batteries |
	And I set the Please select DOT Exceptions if applicable? field to: 172.102(c) - Special Provision 47: Product contains 10 mL or less of a Class 3 liquid and is fully absorbed with no free liquid.
	And I click continue
	And I call Shared Step 62536 (Transportation Details 2 > I do not ship internationally > Continue - Happy Path)
	Given I call Shared Step 75146 (Retailer - Select One or More Retailers that DO NOT REQUIRE Vendor ID or Additional UPC Information, Click Done, Click Continue)
	Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC144527, container type: Plastic Container and size: 9
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I click continue
	Given I click continue
	Given I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Appearance        | Autoignition Temperature | Minimum Ignition Energy | Odor    | Odor Threshold | Partition Coefficient | Personal Protection Equipment | Viscosity |
		| No data available |                          |                         | Neutral | Not applicable | 9                     |                               |           |
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Testing comment area
	Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given I call Shared Step 54796 (Purchase Summary)
	Given I navigate to the home page
	And I search for the product saved as: TestCase144527
	When I click Row Actions for the most recent product returned
	Then I click on the Row Action: View
	Then A Summary page should open in a new browser tab
	Then I confirm the following section: Please select DOT Exceptions if applicable? has the following value: 172.102(c) - Special Provision 47: Product contains 10 mL or less of a Class 3 liquid and is fully absorbed with no free liquid. in the Summary Page
	Given I close the browser tab with the Summary page

@TestCase:128744
Scenario: [128744] Ammunition - DOT Exceptions Saved
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
    Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Ammunition
	Then I save the product information as: TestCase128744
	Given I call Shared Step 60310 (Product Information - Without Child question)
	Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given I call Shared Step 128742 (Transportation Details - Regulated for Transport(No) - Exemption(Random) - Continue - Happy Path)
	Given I call Shared Step (Transportation Details - Confirm DOT Exceptions saved - Continue - Happy Path)
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase128744

	@ignore
#Removed from regression 2023/11
	@TestCase:128743
Scenario: [128743] Ammunition - Other DOT Exception Validation
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
    Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Ammunition
	Then I save the product information as: TestCase128743
	Given I call Shared Step 60310 (Product Information - Without Child question)
	Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
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
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	And I call Shared Step 57507 (Transportation Details 1- Not Regulated - Continue - Happy Path)
	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Wal-Mart/SAM'S CLUB	
	Given In the Retailers tab, I select the first Vendor option for retailer: Wal-Mart/SAM'S CLUB
	Then I click continue
	Given I call Shared Step 87647 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC213999, container type: Plastic Container and size: 18 do not click continue
	And I confirm that retailer "WM" is present under the 'Destination Retailers' column in the UPC table
	Then I click continue
	And  I call Shared Step 78080 (Regulatory Documents to Provide - Upload OSHA SDS)
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Test
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Plant food
	Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
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
	And I call Shared Step 57507 (Transportation Details 1- Not Regulated - Continue - Happy Path)
	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Wal-Mart/SAM'S CLUB	
	Given In the Retailers tab, I select the first Vendor option for retailer: Wal-Mart/SAM'S CLUB
	Then I click continue
	Given I call Shared Step 87647 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC214039, container type: Plastic bag and size: 56 do not click continue
	And I confirm that retailer "WM" is present under the 'Destination Retailers' column in the UPC table
	Then I click continue
	And  I call Shared Step 78080 (Regulatory Documents to Provide - Upload OSHA SDS)
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Test
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Soil (No Additives, Fertilizers, or Inhibitors)
	Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
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

