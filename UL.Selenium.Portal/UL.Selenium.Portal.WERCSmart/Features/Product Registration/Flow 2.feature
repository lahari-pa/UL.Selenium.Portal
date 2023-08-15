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
@run_Flow2
@Steps_Flow2A
@UPC
Feature: Flow 2

#Remove from regression: 2023/05
@ignore
@TestCase:57367
Scenario: [57367] Spill Clean Up Agent (Mitigation Agent)- RU000957 - 2S
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC57367
	Given I delete all products with UPC Number: saved as UPC57367
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Spill Clean Up Agent (Mitigation Agent)
	Then I save the product information as: TestCase57367
	Given I call Shared Step 57865 (Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
	Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName    | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Triclosan        | 24.94   | false               | false       |            |
		| Hydrogen         | 30.2    | false               | false       |            |
		| Propylene Glycol | 19.8    | false               | false       |            |
		| Butane           | 25.06   | false               | false       |            |
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I call Shared Step 57589 (Enter Pesticide Data - United States (without EPA number))
	Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	#Given I call Shared Step 34455 (U. S. Department of Transportation (DOT) Classification - Enter all valid data)
	Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)
	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Amazon
    Then I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC57367, container type: Cardboard and size: 1
    Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I call Shared Step 60931 (Additional Documents to Provide - Exemption - Special Permit - Product Label)
	And in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient | Product's Dispensing Method |
		| Mask                          | 150                      | 44                      | 10.7      | White      | Floral | No data available | 12                    | Aerosol                     |
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Comment Text
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Spill Clean Up Agent (Mitigation Agent)
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase57367

#Remove from regression: 2023/05
@ignore
@TestCase:57403
Scenario: [57403] Septic System Maintainer (RU000174) - 2LS - 2S
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC57403
	Given I delete all products with UPC Number: saved as UPC57403
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Septic system maintainer
	Then I save the product information as: TestCase57403
	Given I call Shared Step 57865 (Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
	Given I call Shared Step 57501 (Physical and Chemical Properties - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue)
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I call Shared Step 57589 (Enter Pesticide Data - United States (without EPA number))
	Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)
	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Amazon
    Then I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC57403, container type: Cardboard and size: 1
    Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I call Shared Step 60931 (Additional Documents to Provide - Exemption - Special Permit - Product Label)
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Product's Dispensing Method | Partition Coefficient |
		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | Aerosol                     | 41.3005               |
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Comment Text
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Septic system maintainer
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase57403

@TestCase:57439
Scenario: [57439] Anti-Transpirant (RU000992) 2-L
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC57439
	Given I delete all products with UPC Number: saved as UPC57439
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Anti-Transpirant
	Then I save the product information as: TestCase57439
	#CLF 18/6/2019 removing this step because it appears to have been replaced by 73629
	#Given I call Shared Step 62686 (Enter Physical Property - Liquid - Without Water Solubility)
	Given I call Shared Step 57865 (Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
	Given I call Shared Step 73629 (Physical and Chemical Properties - Liquid - select any options(enter pH, boiling point, flash point))
		| Secondary Physical State | Relative Density | pH | Boiling Point (in Celsius) | Flash Point (in Celsius) | Flash Point Testing Method Used | Select the best Water Solubility description |
		| Liquid                   | 2                | 2  | 2                          | 66                       | Closed cup method               | Dispersible                                  |
	#CLF 18/6/2019 removing this step because it appears to have been replaced by 57502
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I call Shared Step 57589 (Enter Pesticide Data - United States (without EPA number))
	Given I call Shared Step 57506 (Transportation Details 1 - Regulated for Transport(No) - Exemption(Random) - Continue - Happy Path)
	Given I call Shared Step 62536 (Transportation Details 2 > I do not ship internationally > Continue - Happy Path)
	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Amazon
    Then I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC57439, container type: Glass Container and size: 33
    Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I call Shared Step 60931 (Additional Documents to Provide - Exemption - Special Permit - Product Label)
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Product's Dispensing Method | Partition Coefficient |
		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | Aerosol                     | 41.3005               |
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Comment Text
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Anti-Transpirant
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase57439

@TestCase:57646
Scenario: [57646] Plant Growth regulator (Liquid or Solid) (RU000291) 2-L
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC57646
	Given I delete all products with UPC Number: saved as UPC57646
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Plant Growth regulator (Liquid or Solid)
	Then I save the product information as: TestCase57646
	Given I call Shared Step 57865 (Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
	Given I call Shared Step 74760 (Physical and Chemical Properties - Select Liquid as primary physical state and enter all required data)


		| Primary Physical State | Secondary Physical State | Relative Density | pH | Boiling Point (in Celsius) | Flash Point (in Celsius) | Flash Point Testing Method Used | Select the best Water Solubility description |
		| Liquid                 | Liquid                   | 2                | 2  | 2                          | 66                       | Closed cup method               | Dispersible                                  |
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I call Shared Step 57589 (Enter Pesticide Data - United States (without EPA number))
	Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)
	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Amazon
    Then I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC57646, container type: Glass Container and size: 1
    Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I call Shared Step 60931 (Additional Documents to Provide - Exemption - Special Permit - Product Label)
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Product's Dispensing Method | Partition Coefficient |
		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | Aerosol                     | 41.3005               |
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Comment Text
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Plant Growth regulator (Liquid or Solid)
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase57646

@TestCase:57648
Scenario: [57648] Trap and/or Bait Station - (RU000208) - 4S
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC57648
	Given I delete all products with UPC Number: saved as UPC57648
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Trap and/or Bait Station
	Then I save the product information as: TestCase57648
	Given I call Shared Step 57865 (Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
	Given I call Shared Step 59927 (Primary Physical State > Solid only available – Without Water Solubility question)
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I call Shared Step 57589 (Enter Pesticide Data - United States (without EPA number))
	Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)
	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Amazon
    Then I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC57648, container type: Glass Container and size: 1
    Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I call Shared Step 60931 (Additional Documents to Provide - Exemption - Special Permit - Product Label)
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Product's Dispensing Method | Partition Coefficient |
		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | Aerosol                     | 41.3005               |
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Comment Text
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Trap and/or Bait Station
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase57648

@TestCase:57649
Scenario: [57649] Cosmetics (RU000034) 2LS - 2L
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Cosmetics
	Then I save the product information as: TestCase57649
	Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Given I call Shared Step 74760 (Physical and Chemical Properties - Select Liquid as primary physical state and enter all required data)
		| Primary Physical State | Secondary Physical State | Relative Density | pH | Boiling Point (in Celsius) | Flash Point (in Celsius) | Flash Point Testing Method Used | Select the best Water Solubility description |
		| Liquid                 | Liquid                   | 2                | 2  | 2                          | 66                       | Closed cup method               | Dispersible                                  |
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
	Given I call Shared Step 57506 (Transportation Details 1 - Regulated for Transport(No) - Exemption(Random) - Continue - Happy Path)
	Given I call Shared Step 62536 (Transportation Details 2 > I do not ship internationally > Continue - Happy Path)
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Product's Dispensing Method | Partition Coefficient |
		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | Aerosol                     | 41.3005               |
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Comment Text
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Cosmetics
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase57649

#Remove from regression: 2023/05
@ignore
@TestCase:57708
Scenario: [57708] Aquarium Maintenance chemicals (RU000327) - 2LS -2L
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC57708
	Given I delete all products with UPC Number: saved as UPC57708
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Aquarium maintenance chemicals
	Then I save the product information as: TestCase57708
	Given I call Shared Step 57865 (Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
	Given I call Shared Step 74760 (Physical and Chemical Properties - Select Liquid as primary physical state and enter all required data)
		| Primary Physical State | Secondary Physical State | Relative Density | pH | Boiling Point (in Celsius) | Flash Point (in Celsius) | Flash Point Testing Method Used | Select the best Water Solubility description |
		| Liquid                 | Liquid                   | 2                | 2  | 2                          | 66                       | Closed cup method               | Dispersible                                  |
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
	Given I call Shared Step 57589 (Enter Pesticide Data - United States (without EPA number))
	Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)
	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Amazon
    Then I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC57708, container type: Cardboard and size: 1
    Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I call Shared Step 60931 (Additional Documents to Provide - Exemption - Special Permit - Product Label)
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Product's Dispensing Method | Partition Coefficient |
		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | Aerosol                     | 41.3005               |
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Comment Text
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Aquarium maintenance chemicals
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase57708

@TestCase:57731
Scenario: [57731] Aquarium maintenance chemicals (RU000327) - 2LS - 2S
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC57731
	Given I delete all products with UPC Number: saved as UPC57731
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Aquarium maintenance chemicals
	Then I save the product information as: TestCase57731
	Given I call Shared Step 57865 (Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
	Given I call Shared Step 57501 (Physical and Chemical Properties - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue)
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
	Given I call Shared Step 57589 (Enter Pesticide Data - United States (without EPA number))
	Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)
	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Amazon
	Then I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC57731, container type: Cardboard and size: 11
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I call Shared Step 60931 (Additional Documents to Provide - Exemption - Special Permit - Product Label)
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Product's Dispensing Method | Partition Coefficient |
		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | Aerosol                     | 41.3005               |
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Comment Text
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Aquarium maintenance chemicals
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase57731

#Remove from regression: 2023/05
@ignore
@TestCase:57910
Scenario: [57910] Septic System Maintainer (RU000174) - 2LS - 2L
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC57910
	Given I delete all products with UPC Number: saved as UPC57910
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Septic system maintainer
	Then I save the product information as: TestCase57910
	Given I call Shared Step 57865 (Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
	Given I call Shared Step 74760 (Physical and Chemical Properties - Select Liquid as primary physical state and enter all required data)
		| Primary Physical State | Secondary Physical State | Relative Density | pH | Boiling Point (in Celsius) | Flash Point (in Celsius) | Flash Point Testing Method Used | Select the best Water Solubility description |
		| Liquid                 | Liquid                   | 2                | 2  | 2                          | 66                       | Closed cup method               | Dispersible                                  |
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I call Shared Step 57589 (Enter Pesticide Data - United States (without EPA number))
	Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)
	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Amazon
    Then I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC57910, container type: Cardboard and size: 1
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I call Shared Step 60931 (Additional Documents to Provide - Exemption - Special Permit - Product Label)
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Product's Dispensing Method | Partition Coefficient |
		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | Aerosol                     | 41.3005               |
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Comment Text
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Septic system maintainer
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase57910

# Created by Aaron Caton
# Test case can be found at the following paths:
# NetProjects10\WERCSmart UX Reboot\WERCSmart\Product Registration\Flow 2
@71274
@TestCase:71274
Scenario: [71274] Flea or Tick Repellent (L) - RU000323
	And I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	#20 June 2019 changed product name from Pest repellant for Use on Animals - liquid to Pest (Flea, Tick, etc.) repellant for Use on Animals - liquid
	And I call Shared Step 57561a (The Product - Enter Product Name: Pest repellant for Use on Animals - liquid and select Type of Product): Pest (Flea, Tick, etc.) repellant for Use on Animals - liquid
	Then I save the product information as: TestCase71274
	And I call Shared Step 56799 (Confirm Product Information shows Pesticide question and its radio buttons)
	Given I call Shared Step 57865 (Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
	Given I call Shared Step 74760 (Physical and Chemical Properties - Select Liquid as primary physical state and enter all required data)
		| Primary Physical State | Secondary Physical State | Relative Density | pH | Boiling Point (in Celsius) | Flash Point (in Celsius) | Flash Point Testing Method Used | Select the best Water Solubility description |
		| Liquid                 | Liquid                   | 2                | 8  | 100                        | 80                       | Not applicable/available        | Dispersible                                  |
	#CLF 26 Feb 2019. This appears to  be the wrong step so changed it to: 57865
	# JS 13/03 - TFS test case changed to use shared 57865
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName    | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Triclosan        | 24.94   | false               | false       |            |
		| Hydrogen         | 30.2    | false               | false       |            |
		| Propylene Glycol | 19.8    | false               | false       |            |
		| Butane           | 25.06   | false               | false       |            |
	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	And I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
	# JS 13/03 Change shared step used to match tfs test case change
	And I call Shared Step 29183 (Pesticide Details - U.S. - No EPA number)
	And I call Shared Step 57507 (Transportation Details 1- Not Regulated - Continue - Happy Path)
	And I call Shared Step 63219 (Retailer Association - Select No Retailer - Click continue)
	And I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	#CLF the below step also seemed to be missing
	# JS 13/03 Additonal Documents To Provide steps were added to tfs test case
	Then I should see the Additional Documents to Provide Page
	# TFS test case change - added shared step
	Given I call Shared Step 59042 (Browse for File > select > click Open - Happy Path) for document type: Please upload a PDF of the product label (full label). and file: UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient | Product's Dispensing Method |
		| Mask                          | 150                      | 44                      | 10.7      | White      | Floral | No data available | 12                    | Aerosol                     |
	And I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test comment
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Pest (Flea, Tick, etc.) repellant for Use on Animals - liquid
	Then I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase71274


	
# Created by Saikiran Chittampally
# Test case can be found at the following paths:
# NetProjects10\WERCSmart UX Reboot\WERCSmart\Product Registration\Flow 2
@TestCase:57647
Scenario: [57647] Insecticide-Flying Bug-Moth Proofing Product containing <98% Para-Dichlorobenzene - (RU001000) - 2S
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC57647
	Given I delete all products with UPC Number: saved as UPC57647
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Insecticide-Flying Bug-Moth Proofing Product containing >98% Para-Dichlorobenzene
	Then I save the product information as: TestCase57647
	Given I call Shared Step 57865 (Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
	Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName    | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Triclosan        | 24.94   | false               | false       |            |
		| Hydrogen         | 30.2    | false               | false       |            |
		| Propylene Glycol | 19.8    | false               | false       |            |
		| Butane           | 25.06   | false               | false       |            |
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I call Shared Step 57589 (Enter Pesticide Data - United States (without EPA number))
	Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)
	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Amazon
	Then I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC57647, container type: Cardboard and size: 1
    Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I call Shared step 65961 (Additional Documents to Provide - Upload Full Product Label - Continue)
	

	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Product's Dispensing Method | Partition Coefficient |
		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | Aerosol                     | 41.3005               |
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Comment Text
	#Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Insecticide-Flying Bug-Moth Proofing Product containing >98% Para-Dichlorobenzene
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase57647


	# Created by Saikiran Chittampally
	# Test case can be found at the following paths:
	# NetProjects10\WERCSmart UX Reboot\WERCSmart\Product Registration\Flow 2
@TestCase:63666
Scenario: [63666] New Product - Food/ Nutritional Drug Fact Panel Questions
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC63666
	Given I delete all products with UPC Number: saved as UPC63666
	Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Pet Shampoo
	Then I save the product information as: TestCase63666
	Given I call Shared Step 57865 (Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
	Given I call Shared Step 57441 (Physical and Chemical Properties - Primary Physical Property - Liquid)
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName    | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Triclosan        | 24.94   | false               | false       |            |
		| Hydrogen         | 30.2    | false               | false       |            |
		| Propylene Glycol | 19.8    | false               | false       |            |
		| Butane           | 25.06   | false               | false       |            |
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
	Given I call Shared Step 57589 (Enter Pesticide Data - United States (without EPA number))
	Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase63666

	# Created by Saikiran Chittampally
@TestCase:217787
Scenario: [217787] Container Types - Primary Physical State Liquid - Dishwashing Soap - RU000610
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC217787
	Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Liquid Dishwashing Soap
	Then I save the product information as: TestCase217787
	Given I call Shared Step 217788 (Product Information - not Pesticide, US only, select Yes for JSON Question - Happy Path)
	Given I call Shared Step 217789 (Physical and Chemical Properties - Physical Property - Liquid )
	Given I call Shared Step 217792 California Cleaning Product Disclosure - Manufacturer
	Then I add the following ingredients:
		| ComponentName                | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Sodium laureth sulfate       | 20      | true               | false       |  Sodium Laureth Sulfate          |
		| Ammonium laureth sulfate                            | 20      | true               | false       |  Ammonium Laureth Sulfate                       |
		| Dodecylbenzene sulfonic acid                        | 5       | true               | false       |     Dodecylbenzene Sulfonic Acid                   |
		| D-Glucopyranose, oligomeric, decyl octyl glycosides     | 5 | true          | false       |     D-Glucopyranose, oligomeric, decyl octyl glycosides        |
		| Sodium hydroxide    | 1	| true               | false       |    Sodium hydroxide          |
		| Water         |49   |    true           |    false         |     Water                   |  
	Given On the Ingredients page for the Ingredient: Sodium laureth sulfate I add Ingredient Type: Intentionally Added and Functional Purpose:
	|Functional Purpose|
	|Antifungal Agent|
	Given On the Ingredients page for the Ingredient: Ammonium laureth sulfate I add Ingredient Type: Intentionally Added and Functional Purpose:
	|Functional Purpose|
	|Antimicrobial Agent|
	Given On the Ingredients page for the Ingredient: Dodecylbenzene sulfonic acid I add Ingredient Type: Intentionally Added and Functional Purpose:
	|Functional Purpose|
	|Deodorizing Agent|
	Given On the Ingredients page for the Ingredient: D-Glucopyranose, oligomeric, decyl octyl glycosides I add Ingredient Type: Intentionally Added and Functional Purpose:
	|Functional Purpose|
	|Preservative|
	Given On the Ingredients page for the Ingredient: Sodium hydroxide I add Ingredient Type: Intentionally Added and Functional Purpose:
	|Functional Purpose|
	|Deodorizing Agent|
	Given On the Ingredients page for the Ingredient: Water I add Ingredient Type: Intentionally Added and Functional Purpose:
	|Functional Purpose|
	|Diluent|
	Given I click continue
	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	And I call Shared Step 57507 (Transportation Details 1- Not Regulated - Continue - Happy Path)
	And If ECOLOGO Readiness page is displayed I call Shared Step 57712 - ECOLOGO Readiness Assessment - Not at this time - Continue - Happy Path
	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Target
	Given I call Shared Step 87647 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC217787, container type: Plastic Container and size: 8.6 do not click continue
	Given I should see following container type from the drop down list
	|Container Type|
	| Coated or Laminated Paperboard |
	| Full Syringe - Medical         |
	| Glass Container                |
	| Metal Container                |
	| Metal Cylinder                 |
	| Plastic Container              |
	| Vial - Medical                 |
	Given I click continue
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase217787
