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
@run_Flow4
Feature: Flow 4

@ScenarioId:987
Scenario: [57922] Odor Remover/Eliminator - Aerosol (RU001086) - 4A
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Odor Remover/Eliminator - Aerosol
	Then I save the product information as: TestCase57922
	Given I call Shared Step 57528 (Physical and Chemical Properties - Aerosol Only - add data - Continue - Happy Path)

	Given I call Shared Step 57865 (Additional Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
	#Given I call Shared Step 63804 (Additional Product Information - enter options)
	#	| Classified using OSHA (US) Globally Harmonized Standards (GHS) | Shipped directly by supplier | California's Cleaning Product Right to Know Act | Private Label or Brand | Good Not for resale |
	#	| No                                                             | No                           | No                                              | No                     | No                  |
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I call Shared Step 57589 (Enter Pesticide Data - United States (without EPA number))

	Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)
	Given I call Shared Step 57923 (Volatile Organic Compound (VOC) Step - enter OTC and CARB - Yes for state values)
		| Product granted Alternative Control Plan | Amount of VOC by CARB | Amount of VOC by OTC Model | VOC for states |
		| No                                       | 2                     | 2                          | Yes            |
	Given in the Volatile Organic Compound Summary page I click Continue
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	#Given I call Shared Step 60567 (Upload Product Label only)
	Given I call Shared Step 78801 (Additional Documents to Provide - VOC and Product Label)
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Product's Dispensing Method | Partition Coefficient |
		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | Aerosol                     | 41.3005               |
	Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: Comment Text
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Odor Remover/Eliminator - Aerosol
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase57922

@ScenarioId:988
Scenario: [57924] Penetrants (RU000801) - Flow 4AL - 4A
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Penetrants
	Then I save the product information as: TestCase57924
	Given I call Shared Step 57539 (Physical and Chemical Properties - Aerosol & Liquid select Aerosol - Continue - Happy Path)	
	Given I call Shared Step 63804 (Additional Product Information - enter options)
		| Classified using OSHA (US) Globally Harmonized Standards (GHS) | Shipped directly by supplier | California's Cleaning Product Right to Know Act | Private Label or Brand | Good Not for resale |
		| No                                                             | No                           | No                                              | No                     | No                  |
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)
	Given I call Shared Step 57923 (Volatile Organic Compound (VOC) Step - enter OTC and CARB - Yes for state values)
		| Product granted Alternative Control Plan | Amount of VOC by CARB | Amount of VOC by OTC Model | VOC for states |
		| No                                       | 2                     | 2                          | Yes            |
	Given in the Volatile Organic Compound Summary page I click Continue
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I call Shared Step 60567 (Upload Product Label only)
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Product's Dispensing Method | Partition Coefficient |
		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | Aerosol                     | 41.3005               |
	Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: Comment Text
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Penetrants
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase57924

@ScenarioId:989
Scenario: [57925] Floor Maintenance Product - Non-Aerosol (RU001433) 4-L
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Floor Maintenance Product - Non-Aerosol
	Then I save the product information as: TestCase57925
	Given I call Shared Step 73629 (Physical and Chemical Properties - Liquid - select any options(enter pH, boiling point, flash point))	
		| Secondary Physical State | Specific Gravity | pH | Boiling Point (in Celsius) | Flash Point (in Celsius) | Flash Point Testing Method Used | Select the best Water Solubility description |
		| Liquid                   | 2                | 2  | 2                          | 66                       | Closed cup method               | Appreciable                                  |
	Given I call Shared Step 63804 (Additional Product Information - enter options)
	| Classified using OSHA (US) Globally Harmonized Standards (GHS) | Shipped directly by supplier | California's Cleaning Product Right to Know Act | Private Label or Brand | Good Not for resale |
	| No                                                             | No                           | No                                              | No                     | No                  |
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)
	Given I call Shared Step 57923 (Volatile Organic Compound (VOC) Step - enter OTC and CARB - Yes for state values)
		| Product granted Alternative Control Plan | Amount of VOC by CARB | Amount of VOC by OTC Model | VOC for states |
		| No                                       | 2                     | 2                          | Yes            |
	Given in the Volatile Organic Compound Summary page I click Continue
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I call Shared Step 60567 (Upload Product Label only)
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Product's Dispensing Method | Partition Coefficient |
		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | Aerosol                     | 41.3005               |
	Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: Comment Text
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Floor Maintenance Product - Non-Aerosol
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase57925

@ScenarioId:990
Scenario: [57927] Floor Wax - Wood (RU000790) 4LS - 4S
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Floor Wax - Wood
	Then I save the product information as: TestCase57927
	Given I call Shared Step 57501 (Physical and Chemical Properties - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue)
	Given I call Shared Step 63804 (Additional Product Information - enter options)
		| Classified using OSHA (US) Globally Harmonized Standards (GHS) | Shipped directly by supplier | California's Cleaning Product Right to Know Act | Private Label or Brand | Good Not for resale |
		| No                                                             | No                           | No                                              | No                     | No                  |
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)
	Given I call Shared Step 57923 (Volatile Organic Compound (VOC) Step - enter OTC and CARB - Yes for state values)
		| Product granted Alternative Control Plan | Amount of VOC by CARB | Amount of VOC by OTC Model | VOC for states |
		| No                                       | 2                     | 2                          | Yes            |
	Given in the Volatile Organic Compound Summary page I click Continue
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I call Shared Step 60567 (Upload Product Label only)
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Product's Dispensing Method | Partition Coefficient |
		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | Aerosol                     | 41.3005               |
	Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: Comment Text
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Floor Wax - Wood
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase57927

@ScenarioId:991
Scenario: [57931] Hair Styling Product - Mousse (RU000669) - 4A
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Hair Styling Product - Mousse
	Then I save the product information as: TestCase57931
	Given I call Shared Step 57528 (Physical and Chemical Properties - Aerosol Only - add data - Continue - Happy Path)
	Given I call Shared Step 63804 (Additional Product Information - enter options)
		| Classified using OSHA (US) Globally Harmonized Standards (GHS) | Shipped directly by supplier | Private Label or Brand | Good Not for resale |
		| No                                                             | No                           | No                     | No                  |
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)
	Given I call Shared Step 57923 (Volatile Organic Compound (VOC) Step - enter OTC and CARB - Yes for state values)
		| Product granted Alternative Control Plan | Amount of VOC by CARB | Amount of VOC by OTC Model | VOC for states |
		| No                                       | 2                     | 2                          | Yes            |
	Given in the Volatile Organic Compound Summary page I click Continue
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I call Shared Step 60567 (Upload Product Label only)
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Product's Dispensing Method | Partition Coefficient |
		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | Aerosol                     | 41.3005               |
	Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: Comment Text
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Hair Styling Product - Mousse
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase57931

@ScenarioId:992
Scenario: [57933] Hair Styling Product - Aerosol and Pump Spray - Flow 4AL - 4A
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Hair Styling Product - Aerosol and Pump Spray
	Then I save the product information as: TestCase57933
	Given I call Shared Step 57539 (Physical and Chemical Properties - Aerosol & Liquid select Aerosol - Continue - Happy Path)
	Given I call Shared Step 63804 (Additional Product Information - enter options)
		| Classified using OSHA (US) Globally Harmonized Standards (GHS) | Shipped directly by supplier | Private Label or Brand | Good Not for resale |
		| No                                                             | No                           | No                     | No                  |
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)
	Given I call Shared Step 57923 (Volatile Organic Compound (VOC) Step - enter OTC and CARB - Yes for state values)
		| Product granted Alternative Control Plan | Amount of VOC by CARB | Amount of VOC by OTC Model | VOC for states |
		| No                                       | 2                     | 2                          | Yes            |
	Given in the Volatile Organic Compound Summary page I click Continue
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I call Shared Step 60567 (Upload Product Label only)
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Product's Dispensing Method | Partition Coefficient |
		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | Aerosol                     | 41.3005               |
	Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: Comment Text
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Hair Styling Product - Aerosol and Pump Spray
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase57933

@ScenarioId:993
Scenario: [57950] Conditioner - Leave In (RU001272) 4-L
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Conditioner - Leave In (Liquid, Non Aerosol)
	Then I save the product information as: TestCase57950
	Given I call Shared Step 73629 (Physical and Chemical Properties - Liquid - select any options(enter pH, boiling point, flash point))
		| Secondary Physical State | Specific Gravity | pH | Boiling Point (in Celsius) | Flash Point (in Celsius) | Flash Point Testing Method Used | Select the best Water Solubility description |
		| Liquid                   | 2                | 2  | 2                          | 66                       | Closed cup method               | Appreciable                                  |
	Given I call Shared Step 63804 (Additional Product Information - enter options)
		| Classified using OSHA (US) Globally Harmonized Standards (GHS) | Shipped directly by supplier | Private Label or Brand | Good Not for resale |
		| No                                                             | No                           | No                     | No                  |
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)
	Given I call Shared Step 57923 (Volatile Organic Compound (VOC) Step - enter OTC and CARB - Yes for state values)
		| Product granted Alternative Control Plan | Amount of VOC by CARB | Amount of VOC by OTC Model | VOC for states |
		| No                                       | 2                     | 2                          | Yes            |
	Given in the Volatile Organic Compound Summary page I click Continue
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I call Shared Step 60567 (Upload Product Label only)
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Product's Dispensing Method | Partition Coefficient |
		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | Aerosol                     | 41.3005               |
	Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: Comment Text
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Conditioner - Leave In (Liquid, Non Aerosol)
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase57950

@ScenarioId:994
Scenario: [57952] Hair Styling Gel- (RU000749) 4LS - 4S
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Hair Styling Gel
	Then I save the product information as: TestCase57952
	Given I call Shared Step 57501 (Physical and Chemical Properties - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue)
	Given I call Shared Step 63804 (Additional Product Information - enter options)
		| Classified using OSHA (US) Globally Harmonized Standards (GHS) | Shipped directly by supplier | Private Label or Brand | Good Not for resale |
		| No                                                             | No                           | No                     | No                  |
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)
	Given I call Shared Step 57923 (Volatile Organic Compound (VOC) Step - enter OTC and CARB - Yes for state values)
		| Product granted Alternative Control Plan | Amount of VOC by CARB | Amount of VOC by OTC Model | VOC for states |
		| No                                       | 2                     | 2                          | Yes            |
	Given in the Volatile Organic Compound Summary page I click Continue
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I call Shared Step 60567 (Upload Product Label only)
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Product's Dispensing Method | Partition Coefficient |
		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | Aerosol                     | 41.3005               |
	Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: Comment Text
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Hair Styling Gel
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase57952

@ScenarioId:995
Scenario: [57958] Adhesive - Aerosol Web Spray (RU000909) - 4A
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Adhesive - Aerosol Web Spray
	Then I save the product information as: TestCase57958
	Given I call Shared Step 57528 (Physical and Chemical Properties - Aerosol Only - add data - Continue - Happy Path)
	#Given I call Shared Step 63804 (Additional Product Information - enter options)
	#| Classified using OSHA (US) Globally Harmonized Standards (GHS) | Shipped directly by supplier | Private Label or Brand | Good Not for resale |
	#| No                                                             | No                           | No                     | No                  |
	Given I call Shared Step 57401 (Additional Product Information - US only - No GHS, Not Direct Ship, Not PLP, Not GNFR > Continue - Happy Path)
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
	Given I call Shared Step 57932 (Regulatory - TSCA Only - Yes to All Prop 65 questions - Continue - Happy Path)
	Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)
	Given I call Shared Step 57923 (Volatile Organic Compound (VOC) Step - enter OTC and CARB - Yes for state values)
		| Product granted Alternative Control Plan | Amount of VOC by CARB | Amount of VOC by OTC Model | VOC for states |
		| No                                       | 2                     | 2                          | Yes            |
	Given in the Volatile Organic Compound Summary page I click Continue
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I call Shared Step 60567 (Upload Product Label only)
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Product's Dispensing Method | Partition Coefficient |
		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | Aerosol                     | 41.3005               |
	Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: Comment Text
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Adhesive - Aerosol Web Spray
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase57958

@ScenarioId:996
Scenario: [57977] Adhesive (Spray, Special Purpose): Polyolefin and Laminate Repair/Edgebanding(RU000912) - 4AL - 4A
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Adhesive (Spray, Special Purpose): Polyolefin and Laminate Repair/Edgebanding
	Then I save the product information as: TestCase57977
	Given I call Shared Step 57539 (Physical and Chemical Properties - Aerosol & Liquid select Aerosol - Continue - Happy Path)
	Given I call Shared Step 63804 (Additional Product Information - enter options)
		| Classified using OSHA (US) Globally Harmonized Standards (GHS) | Shipped directly by supplier | Private Label or Brand | Good Not for resale |
		| No                                                             | No                           | No                     | No                  |
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
	Given I call Shared Step 57932 (Regulatory - TSCA Only - Yes to All Prop 65 questions - Continue - Happy Path)
	Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)
	Given I call Shared Step 57923 (Volatile Organic Compound (VOC) Step - enter OTC and CARB - Yes for state values)
		| Product granted Alternative Control Plan | Amount of VOC by CARB | Amount of VOC by OTC Model | VOC for states |
		| No                                       | 2                     | 2                          | Yes            |
	Given in the Volatile Organic Compound Summary page I click Continue
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I call Shared Step 60567 (Upload Product Label only)
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Product's Dispensing Method | Partition Coefficient |
		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | Aerosol                     | 41.3005               |
	Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: Comment Text
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Adhesive (Spray, Special Purpose): Polyolefin and Laminate Repair/Edgebanding
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase57977

@ScenarioId:997
Scenario: [57982] Bonding agent (RU000023) - 4All - 4G
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Bonding agent
	Then I save the product information as: TestCase57982
	Given I call Shared Step 57978 (Physical and Chemical Properties - All select Gas - Continue - Happy Path)	
	Given I call Shared Step 63804 (Additional Product Information - enter options)
		| Classified using OSHA (US) Globally Harmonized Standards (GHS) | Shipped directly by supplier | Private Label or Brand | Good Not for resale |
		| No                                                             | No                           | No                     | No                  |
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
	Given I call Shared Step 57932 (Regulatory - TSCA Only - Yes to All Prop 65 questions - Continue - Happy Path)
	Given I call Shared Step 57980 (Transportation Details 1 - Yes option - Select IMDG, Limited Quantity - Continue - Happy Path)
	Given I call Shared Step 57981 (Transportation - IMDG UN step - Enter UN1950, select Aerosols,  2.1, None, add technical name, Click Continue)
	Given I call Shared Step 57923 (Volatile Organic Compound (VOC) Step - enter OTC and CARB - Yes for state values)
		| Product granted Alternative Control Plan | Amount of VOC by CARB | Amount of VOC by OTC Model | VOC for states |
		| No                                       | 2                     | 2                          | Yes            |
	Given in the Volatile Organic Compound Summary page I click Continue
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I call Shared Step 60567 (Upload Product Label only)
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Product's Dispensing Method | Partition Coefficient |
		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | Aerosol                     | 41.3005               |
	Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: Comment Text
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Bonding agent
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase57982

@ScenarioId:998
Scenario: [57983] Lubricant, Multi-Purpose, Not for Personal Use (RU000674) 4L
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Lubricant, Multi-Purpose, Not for Personal Use
	Then I save the product information as: TestCase57983
	Given I call Shared Step 74760 (Physical and Chemical Properties - Select Liquid as primary physical state and enter all required data)
		| Primary Physical State | Secondary Physical State | Specific Gravity | pH | Boiling Point (in Celsius) | Flash Point (in Celsius) | Flash Point Testing Method Used | Select the best Water Solubility description |
		| Liquid                 | Liquid                   | 2                | 2  | 2                          | 66                       | Closed cup method               | Appreciable                                  |
	Given I call Shared Step 63804 (Additional Product Information - enter options)
		| Classified using OSHA (US) Globally Harmonized Standards (GHS) | Shipped directly by supplier | Private Label or Brand | Good Not for resale |
		| No                                                             | No                           | No                     | No                  |
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
	Given I call Shared Step 57932 (Regulatory - TSCA Only - Yes to All Prop 65 questions - Continue - Happy Path)
	Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)
	Given I call Shared Step 57923 (Volatile Organic Compound (VOC) Step - enter OTC and CARB - Yes for state values)
		| Product granted Alternative Control Plan | Amount of VOC by CARB | Amount of VOC by OTC Model | VOC for states |
		| No                                       | 2                     | 2                          | Yes            |
	Given in the Volatile Organic Compound Summary page I click Continue
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I call Shared Step 60567 (Upload Product Label only)
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Product's Dispensing Method | Partition Coefficient |
		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | Aerosol                     | 41.3005               |
	Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: Comment Text
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Lubricant, Multi-Purpose, Not for Personal Use
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase57983

@ScenarioId:999
Scenario: [57985] Footwear or Leather Care Product - Aerosol - (RU000744) - 4A
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Footwear or Leather Care Product - Aerosol
	Then I save the product information as: TestCase57985
	Given I call Shared Step 57528 (Physical and Chemical Properties - Aerosol Only - add data - Continue - Happy Path)
	Given I call Shared Step 63804 (Additional Product Information - enter options)
		| Classified using OSHA (US) Globally Harmonized Standards (GHS) | Shipped directly by supplier | Private Label or Brand | Good Not for resale |
		| No                                                             | No                           | No                     | No                  |
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
	Given I call Shared Step 57932 (Regulatory - TSCA Only - Yes to All Prop 65 questions - Continue - Happy Path)
	Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)
	Given I call Shared Step 57923 (Volatile Organic Compound (VOC) Step - enter OTC and CARB - Yes for state values)
		| Product granted Alternative Control Plan | Amount of VOC by CARB | Amount of VOC by OTC Model | VOC for states |
		| No                                       | 2                     | 2                          | Yes            |
	Given in the Volatile Organic Compound Summary page I click Continue
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I call Shared Step 60567 (Upload Product Label only)
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Product's Dispensing Method | Partition Coefficient |
		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | Aerosol                     | 41.3005               |
	Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: Comment Text
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Footwear or Leather Care Product - Aerosol
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase57985

@ScenarioId:1000
Scenario: [57986] Footwear or Leather Care Product - All other forms - (RU000746) - 4All - 4G
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Footwear or Leather Care Product - All other forms
	Then I save the product information as: TestCase57986
	Given I call Shared Step 57978 (Physical and Chemical Properties - All select Gas - Continue - Happy Path)
	Given I call Shared Step 63804 (Additional Product Information - enter options)
		| Classified using OSHA (US) Globally Harmonized Standards (GHS) | Shipped directly by supplier | Private Label or Brand | Good Not for resale |
		| No                                                             | No                           | No                     | No                  |
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
	Given I call Shared Step 57932 (Regulatory - TSCA Only - Yes to All Prop 65 questions - Continue - Happy Path)
	Given I call Shared Step 57980 (Transportation Details 1 - Yes option - Select IMDG, Limited Quantity - Continue - Happy Path)
	Given I call Shared Step 57981 (Transportation - IMDG UN step - Enter UN1950, select Aerosols,  2.1, None, add technical name, Click Continue)
	Given I call Shared Step 57923 (Volatile Organic Compound (VOC) Step - enter OTC and CARB - Yes for state values)
		| Product granted Alternative Control Plan | Amount of VOC by CARB | Amount of VOC by OTC Model | VOC for states |
		| No                                       | 2                     | 2                          | Yes            |
	Given in the Volatile Organic Compound Summary page I click Continue
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I call Shared Step 60567 (Upload Product Label only)
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Product's Dispensing Method | Partition Coefficient |
		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | Aerosol                     | 41.3005               |
	Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: Comment Text
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Footwear or Leather Care Product - All other forms
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase57986

@ScenarioId:1001
Scenario: [57988] Anti-Static Product - Non-Aerosol (RU000667) 4-L
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Anti-Static Product - Non-Aerosol
	Then I save the product information as: TestCase57988
	#Given I call Shared Step 73629 (Physical and Chemical Properties - Liquid - select any options(enter pH, boiling point, flash point))
	#| Secondary Physical State | Specific Gravity | pH      | Boiling Point (in Celsius) | Flash Point (in Celsius) | Flash Point Testing Method Used     | Select the best Water Solubility description |
	#| Liquid                   | 2                | 2       | 2                          | 66                       | Closed cup method                   | Appreciable                                  |
	And I call Shared Step 84554 (Physical and Chemical Properties - Liquid & Solid - Enter all data - Continue - Happy Path)
	#Given I call Shared Step 63804 (Additional Product Information - enter options)
	#| Classified using OSHA (US) Globally Harmonized Standards (GHS) | Shipped directly by supplier | Private Label or Brand | Good Not for resale |
	#| No                                                             | No                            | No                         | No                         |
	Given I call Shared Step 57401 (Additional Product Information - US only - No GHS, Not Direct Ship, Not PLP, Not GNFR > Continue - Happy Path)
	#Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
	#| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
	#| Propane  | 100     | false               | false       |            |
	Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Propane
	Given I call Shared Step 57932 (Regulatory - TSCA Only - Yes to All Prop 65 questions - Continue - Happy Path)
	Given I call Shared Step 57507 (Transportation Details 1- Not Regulated - Continue - Happy Path)
	Given I call Shared Step 57923 (Volatile Organic Compound (VOC) Step - enter OTC and CARB - Yes for state values)
		| Product granted Alternative Control Plan | Amount of VOC by CARB | Amount of VOC by OTC Model | VOC for states |
		| No                                       | 2                     | 2                          | Yes            |
	Given in the Volatile Organic Compound Summary page I click Continue
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I call Shared Step 60567 (Upload Product Label only)
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Product's Dispensing Method | Partition Coefficient |
		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | Aerosol                     | 41.3005               |
	Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: Comment Text
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Anti-Static Product - Non-Aerosol
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase57988

@ScenarioId:1002
Scenario: [57990] Footwear or Leather Care Product - Solid- (RU000745) - 4S
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Footwear or Leather Care Product - Solid
	Then I save the product information as: TestCase57990
	Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I call Shared Step 63804 (Additional Product Information - enter options)
		| Classified using OSHA (US) Globally Harmonized Standards (GHS) | Shipped directly by supplier | Private Label or Brand | Good Not for resale |
		| No                                                             | No                           | No                     | No                  |
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)
	Given I call Shared Step 57923 (Volatile Organic Compound (VOC) Step - enter OTC and CARB - Yes for state values)
		| Product granted Alternative Control Plan | Amount of VOC by CARB | Amount of VOC by OTC Model | VOC for states |
		| No                                       | 2                     | 2                          | Yes            |
	Given in the Volatile Organic Compound Summary page I click Continue
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I call Shared Step 60567 (Upload Product Label only)
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Product's Dispensing Method | Partition Coefficient |
		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | Aerosol                     | 41.3005               |
	Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: Comment Text
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Footwear or Leather Care Product - Solid
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase57990

@ScenarioId:1003
Scenario: [57991] Glue sticks for glue guns- (RU000300) - 4S
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Glue sticks for glue guns
	Then I save the product information as: TestCase57991
	Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I call Shared Step 63804 (Additional Product Information - enter options)
		| Classified using OSHA (US) Globally Harmonized Standards (GHS) | Shipped directly by supplier | Private Label or Brand | Good Not for resale |
		| No                                                             | No                           | No                     | No                  |
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)
	Given I call Shared Step 57923 (Volatile Organic Compound (VOC) Step - enter OTC and CARB - Yes for state values)
		| Product granted Alternative Control Plan | Amount of VOC by CARB | Amount of VOC by OTC Model | VOC for states |
		| No                                       | 2                     | 2                          | Yes            |
	Given in the Volatile Organic Compound Summary page I click Continue
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I call Shared Step 60567 (Upload Product Label only)
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Product's Dispensing Method | Partition Coefficient |
		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | Aerosol                     | 41.3005               |
	Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: Comment Text
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Glue sticks for glue guns
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase57991
