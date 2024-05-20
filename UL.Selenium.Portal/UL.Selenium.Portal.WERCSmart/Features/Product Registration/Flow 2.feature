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
@StepsPrototype
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:NewProduct
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:ProductInformation
@PhysicalAndChemicalProp
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:RegulatoryDocumentsToProvide
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:OptionalComments
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:DataAcceptance
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:InventoryStatusProp65
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:PesticideDetailsUS
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:TransportationDetails1
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:Retailer
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:AdditionalDocumentsToProvide

Feature: Flow 2

@TestCase:57439
Scenario: [57439] Anti-Transpirant (RU000992) 2-L
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC57439
	Given I delete all products with UPC Number: saved as UPC57439
	# ====== Given I call Shared Step 57408 (Create a New Registration via Register New Product icon) ====== #
	Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Given in the New Product page I click Continue
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Anti-Transpirant
	Then I save the product information as: TestCase57439
	#CLF 18/6/2019 removing this step because it appears to have been replaced by 73629
	#Given I call Shared Step 62686 (Enter Physical Property - Liquid - Without Water Solubility)
	#Given I call Shared Step 57865 (Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
	Given I should see the Product Information Page
	Then In the Product Information Section, set the option in section: 'Which best describes your product, including when FIFRA 25(b) Exempt' to: Product is intended for preventing, destroying, repelling, or mitigating pests (including insects, rodents, mold, virus, bacteria, and other micro-organisms)
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue

	Given I call Shared Step 73629 (Physical and Chemical Properties - Liquid - select any options(enter pH, boiling point, flash point))
		| Secondary Physical State | Relative Density | pH | Boiling Point (in Celsius) | Flash Point (in Celsius) | Flash Point Testing Method Used | Select the best Water Solubility description |
		| Liquid                   | 2                | 2  | 2                          | 66                       | Closed cup method               | Dispersible                                  |
	#CLF 18/6/2019 removing this step because it appears to have been replaced by 57502
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
	#Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
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

	Given I call Shared Step 57506 (Transportation Details 1 - Regulated for Transport(No) - Exemption(Random) - Continue - Happy Path)
	Given I call Shared Step 62536 (Transportation Details 2 > I do not ship internationally > Continue - Happy Path)
	#Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Amazon
	Given I should see the Retailer Page
	Then In the Retailer Section, click 'Add Retailers' button
	Then In the Select Retailers window, select retailer: Amazon
	Then In the Select Retailers window, click 'Done' button
	Then in the Retailer page I click Continue

	Then I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC57439, container type: Glass Container and size: 33
    #Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
	Then in the Regulatory Documents to Provide page I click Continue

	#Given I call Shared Step 60931 (Additional Documents to Provide - Exemption - Special Permit - Product Label)
	Given I should see the Additional Documents to Provide Page
	Then I upload PDF document to Upload Transportation Exemption Letter or Special Permit field
	Then I upload PDF document to Provide Full Product Label (required) field
	Then in the Additional Documents to Provide page I click Continue

	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Product's Dispensing Method | Partition Coefficient |
		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | Aerosol                     | 41.3005               |
	#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Comment Text
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Anti-Transpirant
	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase57439
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase57439

@TestCase:57646
Scenario: [57646] Plant Growth regulator (Liquid or Solid) (RU000291) 2-L
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC57646
	Given I delete all products with UPC Number: saved as UPC57646
	# ====== Given I call Shared Step 57408 (Create a New Registration via Register New Product icon) ====== #
	Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Given in the New Product page I click Continue
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Plant Growth regulator (Liquid or Solid)
	Then I save the product information as: TestCase57646
	#Given I call Shared Step 57865 (Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
	Given I should see the Product Information Page
	Then In the Product Information Section, set the option in section: 'Which best describes your product, including when FIFRA 25(b) Exempt' to: Product is intended for preventing, destroying, repelling, or mitigating pests (including insects, rodents, mold, virus, bacteria, and other micro-organisms)
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue

	Given I call Shared Step 74760 (Physical and Chemical Properties - Select Liquid as primary physical state and enter all required data)
		| Primary Physical State | Secondary Physical State | Relative Density | pH | Boiling Point (in Celsius) | Flash Point (in Celsius) | Flash Point Testing Method Used | Select the best Water Solubility description |
		| Liquid                 | Liquid                   | 2                | 2  | 2                          | 66                       | Closed cup method               | Dispersible                                  |
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
	#Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
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
	#Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Amazon
	Given I should see the Retailer Page
	Then In the Retailer Section, click 'Add Retailers' button
	Then In the Select Retailers window, select retailer: Amazon
	Then In the Select Retailers window, click 'Done' button
	Then in the Retailer page I click Continue

	Then I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC57646, container type: Glass Container and size: 1
    #Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
	Then in the Regulatory Documents to Provide page I click Continue

	#Given I call Shared Step 60931 (Additional Documents to Provide - Exemption - Special Permit - Product Label)
	Given I should see the Additional Documents to Provide Page
	Then I upload PDF document to Upload Transportation Exemption Letter or Special Permit field
	Then I upload PDF document to Provide Full Product Label (required) field
	Then in the Additional Documents to Provide page I click Continue

	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Product's Dispensing Method | Partition Coefficient |
		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | Aerosol                     | 41.3005               |
	#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Comment Text
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Plant Growth regulator (Liquid or Solid)
	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase57646
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase57646

@TestCase:57649
Scenario: [57649] Cosmetics (RU000034) 2LS - 2L
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	# ====== Given I call Shared Step 57408 (Create a New Registration via Register New Product icon) ====== #
	Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Given in the New Product page I click Continue
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Cosmetics
	Then I save the product information as: TestCase57649
	#Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Given I should see the Product Information Page
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)' to: No
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue


	Given I call Shared Step 74760 (Physical and Chemical Properties - Select Liquid as primary physical state and enter all required data)
		| Primary Physical State | Secondary Physical State | Relative Density | pH | Boiling Point (in Celsius) | Flash Point (in Celsius) | Flash Point Testing Method Used | Select the best Water Solubility description |
		| Liquid                 | Liquid                   | 2                | 2  | 2                          | 66                       | Closed cup method               | Dispersible                                  |
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
	#Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I should see the Inventory Status, Prop 65 (US) Page
	Then In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	Then In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page I click Continue

	Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
	Given I call Shared Step 57506 (Transportation Details 1 - Regulated for Transport(No) - Exemption(Random) - Continue - Happy Path)
	Given I call Shared Step 62536 (Transportation Details 2 > I do not ship internationally > Continue - Happy Path)
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	#Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
	Then in the Regulatory Documents to Provide page I click Continue

	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Product's Dispensing Method | Partition Coefficient |
		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | Aerosol                     | 41.3005               |
	#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Comment Text
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Cosmetics
#	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase57649
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase57649

@TestCase:57731
Scenario: [57731] Aquarium maintenance chemicals (RU000327) - 2LS - 2S
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC57731
	Given I delete all products with UPC Number: saved as UPC57731
	# ====== Given I call Shared Step 57408 (Create a New Registration via Register New Product icon) ====== #
	Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Given in the New Product page I click Continue
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Aquarium maintenance chemicals
	Then I save the product information as: TestCase57731
	#Given I call Shared Step 57865 (Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
	Given I should see the Product Information Page
	Then In the Product Information Section, set the option in section: 'Which best describes your product, including when FIFRA 25(b) Exempt' to: Product is intended for preventing, destroying, repelling, or mitigating pests (including insects, rodents, mold, virus, bacteria, and other micro-organisms)
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue

# ====== Given I call Shared Step 57501 (Physical and Chemical Properties - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue - HP) ====== #
Given In the Physical and Chemical Properties Section, set the option in section: 'Primary Physical State' to: Solid
Given In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Bonded, fibrous glass web
Given In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
Given In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
Given I click continue
Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
	#Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I should see the Inventory Status, Prop 65 (US) Page
	Then In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	Then In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page I click Continue

	Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
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
	#Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Amazon
	Given I should see the Retailer Page
	Then In the Retailer Section, click 'Add Retailers' button
	Then In the Select Retailers window, select retailer: Amazon
	Then In the Select Retailers window, click 'Done' button
	Then in the Retailer page I click Continue

	Then I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC57731, container type: Cardboard and size: 11
	#Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
	Then in the Regulatory Documents to Provide page I click Continue

	#Given I call Shared Step 60931 (Additional Documents to Provide - Exemption - Special Permit - Product Label)
	Given I should see the Additional Documents to Provide Page
	Then I upload PDF document to Upload Transportation Exemption Letter or Special Permit field
	Then I upload PDF document to Provide Full Product Label (required) field
	Then in the Additional Documents to Provide page I click Continue

	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Product's Dispensing Method | Partition Coefficient |
		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | Aerosol                     | 41.3005               |
	#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Comment Text
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Aquarium maintenance chemicals
#	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase57731
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase57731

# Created by Aaron Caton
# Test case can be found at the following paths:
# NetProjects10\WERCSmart UX Reboot\WERCSmart\Product Registration\Flow 2
@71274
@TestCase:71274
Scenario: [71274] Flea or Tick Repellent (L) - RU000323
	And I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	# ====== Given I call Shared Step 57408 (Create a New Registration via Register New Product icon) ====== #
	Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Given in the New Product page I click Continue
	#20 June 2019 changed product name from Pest repellant for Use on Animals - liquid to Pest (Flea, Tick, etc.) repellant for Use on Animals - liquid
	And I call Shared Step 57561a (The Product - Enter Product Name: Pest repellant for Use on Animals - liquid and select Type of Product): Pest (Flea, Tick, etc.) repellant for Use on Animals - liquid
	Then I save the product information as: TestCase71274
	And I call Shared Step 56799 (Confirm Product Information shows Pesticide question and its radio buttons)
	#Given I call Shared Step 57865 (Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
	Given I should see the Product Information Page
	Then In the Product Information Section, set the option in section: 'Which best describes your product, including when FIFRA 25(b) Exempt' to: Product is intended for preventing, destroying, repelling, or mitigating pests (including insects, rodents, mold, virus, bacteria, and other micro-organisms)
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue

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
	#And I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
	Then in the Regulatory Documents to Provide page I click Continue

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
	#And I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test comment
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

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
	# ====== Given I call Shared Step 57408 (Create a New Registration via Register New Product icon) ====== #
	Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Given in the New Product page I click Continue
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Insecticide-Flying Bug-Moth Proofing Product containing >98% Para-Dichlorobenzene
	Then I save the product information as: TestCase57647
	#Given I call Shared Step 57865 (Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
	Given I should see the Product Information Page
	Then In the Product Information Section, set the option in section: 'Which best describes your product, including when FIFRA 25(b) Exempt' to: Product is intended for preventing, destroying, repelling, or mitigating pests (including insects, rodents, mold, virus, bacteria, and other micro-organisms)
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

	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName    | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Triclosan        | 24.94   | false               | false       |            |
		| Hydrogen         | 30.2    | false               | false       |            |
		| Propylene Glycol | 19.8    | false               | false       |            |
		| Butane           | 25.06   | false               | false       |            |
	#Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
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
	#Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Amazon
	Given I should see the Retailer Page
	Then In the Retailer Section, click 'Add Retailers' button
	Then In the Select Retailers window, select retailer: Amazon
	Then In the Select Retailers window, click 'Done' button
	Then in the Retailer page I click Continue

	Then I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC57647, container type: Cardboard and size: 1
    #Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
	Then in the Regulatory Documents to Provide page I click Continue

	Given I call Shared step 65961 (Additional Documents to Provide - Upload Full Product Label - Continue)
	

	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Product's Dispensing Method | Partition Coefficient |
		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | Aerosol                     | 41.3005               |
	#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Comment Text
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	#Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Insecticide-Flying Bug-Moth Proofing Product containing >98% Para-Dichlorobenzene
#	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase57647
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase57647


	# Created by Saikiran Chittampally
	# Test case can be found at the following paths:
	# NetProjects10\WERCSmart UX Reboot\WERCSmart\Product Registration\Flow 2
@TestCase:63666
Scenario: [63666] New Product - Food/ Nutritional Drug Fact Panel Questions
	#Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC63666
	Given I delete all products with UPC Number: saved as UPC63666
	#Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Then in the New Product page, I click Continue

	Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Pet Shampoo
	Then I save the product information as: TestCase63666
	#Given I call Shared Step 57865 (Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
	Given I should see the Product Information Page
	Then In the Product Information Section, set the option in section: 'Which best describes your product, including when FIFRA 25(b) Exempt' to: Product is intended for preventing, destroying, repelling, or mitigating pests (including insects, rodents, mold, virus, bacteria, and other micro-organisms)
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue

	Given I call Shared Step 57441 (Physical and Chemical Properties - Primary Physical Property - Liquid)
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName    | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Triclosan        | 24.94   | false               | false       |            |
		| Hydrogen         | 30.2    | false               | false       |            |
		| Propylene Glycol | 19.8    | false               | false       |            |
		| Butane           | 25.06   | false               | false       |            |
	#Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I should see the Inventory Status, Prop 65 (US) Page
	Then In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	Then In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page I click Continue

	Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
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
	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase63666
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase63666

	#Executed in Staging Environment
	# Created by Saikiran Chittampally
@TestCase:217787
Scenario: [217787] Container Types - Primary Physical State Liquid - Dishwashing Soap - RU000610
	#Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC217787
	#Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Then in the New Product page, I click Continue

	Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Liquid Dishwashing Soap
	Then I save the product information as: TestCase217787
	Given I call Shared Step 217788 (Product Information - not Pesticide, US only, select Yes for JSON Question - Happy Path)
	Given I call Shared Step 217789 (Physical and Chemical Properties - Physical Property - Liquid )
	Given I call Shared Step 217792 California Cleaning Product Disclosure - Manufacturer
	Then I add the following ingredients:
		| ComponentName                                       | Percent | PublicallyDisclosed | TradeSecret | PublicName                                          |
		| Sodium laureth sulfate                              | 20      | true                | false       | Sodium Laureth Sulfate                              |
		| Ammonium laureth sulfate                            | 20      | true                | false       | Ammonium Laureth Sulfate                            |
		| Dodecylbenzene sulfonic acid                        | 5       | true                | false       | Dodecylbenzene Sulfonic Acid                        |
		| D-Glucopyranose, oligomeric, decyl octyl glycosides | 5       | true                | false       | D-Glucopyranose, oligomeric, decyl octyl glycosides |
		| Sodium hydroxide                                    | 1       | true                | false       | Sodium hydroxide                                    |
		| Water                                               | 49      | true                | false       | Water                                               |
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
	#Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Target
	Given I should see the Retailer Page
	Then In the Retailer Section, click 'Add Retailers' button
	Then In the Select Retailers window, select retailer: Target
	Then In the Select Retailers window, click 'Done' button
	Then in the Retailer page I click Continue

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
#	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase217787
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase217787
