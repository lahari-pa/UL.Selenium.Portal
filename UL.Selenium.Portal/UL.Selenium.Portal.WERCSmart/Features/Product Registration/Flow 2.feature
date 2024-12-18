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
@SafetyDataSheetAuthoring
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:TransportationDetails2
@RegulatoryInformation3
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:PurchaseSummary
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:ProductInformation
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:TheProduct
@PhysicalAndChemicalProp
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:CaliforniaCleaningProductDisclosure
@Ingredients
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:InventoryStatusProp65
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:TransportationDetails1
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:Retailer
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:ECOLOGO
@GTINAndUPC
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:Summary
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:PesticideDetailsUS
Feature: Flow 2

@TestCase:57439
Scenario: [57439] Anti-Transpirant (RU000992) 2-L
Given I log in with the account saved in TReVor as: ProductAccount
Then The home screen should load
Given I generate a random UPC number and save as: UPC57439
Then In the Product Grid, delete all products with UPC Number: saved as UPC57439

#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I click the Add Product icon in the Navigation Pane
Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
Given in the New Product page I click Continue

#Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Anti-Transpirant
Then I should be on the The Product Page
And In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Anti-Transpirant_#59276
And In the Product Section, set the option in section: 'Type of Product (select)' to: Anti-Transpirant
Then in the The Product page, I click Continue

Then I save the product information as: TestCase57439

#Given I call Shared Step 57865 (Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
Then I should be on the Product Information Page
Then In the Product Information Section, set the option in section: 'Which best describes your product, including when FIFRA 25(b) Exempt' to: Product is intended for preventing, destroying, repelling, or mitigating pests (including insects, rodents, mold, virus, bacteria, and other micro-organisms)
Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
Then in the Product Information page, I click Continue

#Given I call Shared Step 73629 (Physical and Chemical Properties - Liquid - select any options(enter pH, boiling point, flash point))
#	| Secondary Physical State | Relative Density | pH | Boiling Point (in Celsius) | Flash Point (in Celsius) | Flash Point Testing Method Used | Select the best Water Solubility description |
#	| Liquid                   | 2                | 2  | 2                          | 66                       | Closed cup method               | Dispersible                                  |
Then I should be on the Physical and Chemical Properties Page
And In the Physical and Chemical Properties Section, the section: 'Primary Physical State' should be showing the option: Liquid 
And In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Liquid
And In the Physical and Chemical Properties Section, for section: 'Relative Density' enter text: 2
And In the Physical and Chemical Properties Section, for section: 'pH' enter text: 2
And In the Physical and Chemical Properties Section, for section: 'Boiling Point (in Celsius)' enter text: 2
And In the Physical and Chemical Properties Section, for section: 'Flash Point (in Celsius)' enter text: 66
And In the Physical and Chemical Properties Section, set the option in section: 'Flash Point Testing Method Used' to: Closed cup method
And In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Cloth not soluble
Then in the Physical and Chemical Properties page, I click Continue

#Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
#	| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
#	| Propane       | 100     | false               | false       |            |
Then I should be on the Ingredients Page
And In the Ingredients section, add the following ingredients:
| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
| component name | Water       | 100     | False               | False         |             |
Then in the Ingredients page, I click Continue

#Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
Given I should be on the Inventory Status, Prop 65 (US) Page
Then In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
Then In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
Then in the Inventory Status, Prop 65 (US) page, I click Continue

#Given I call Shared Step 57589 (Enter Pesticide Data - United States (without EPA number))
Given I should be on the Pesticide Details - U.S. Page
Then In the Pesticide Details - U.S. Section, in 'Product has an Environmental Protection Agency (EPA) Registration Number' enter No
Then In the Pesticide Details - U.S. Section, in 'Product has a State Registration' enter No
Then In the Pesticide Details - U.S. Section, in 'Select the applicable exemption' enter Food Based Pesticides - Exempt from EPA Registration
Then in the Pesticide Details - U.S. page, I click Continue

#Given I call Shared Step 57506 (Transportation Details 1 - Regulated for Transport(No) - Exemption(Random) - Continue - Happy Path)
Then I should be on the Transportation Details 1 Page
And In the Transportation Details 1 Section, set the option in section: 'Product is Regulated for Transport': to: No, due to an exemption or exception
And In the Transportation Details 1 Section, set the option in section: 'Please select DOT Exceptions if applicable?': to: 173.120(b)(3):  Combustible liquid that does not sustain combustion
Then in the Transportation Details 1 page, I click Continue

#Given I call Shared Step 62536 (Transportation Details 2 > I do not ship internationally > Continue - Happy Path)
Then I should be on the Transportation Details 2 Page
And In the Transportation Details 2 Section, set the option in section: 'International Shipping when DOT Exemption taken?': to: I do not ship internationally and I do not know the classification
Then in the Transportation Details 2 page, I click Continue

#Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Amazon
Given I should be on the Retailer Page
Then In the Retailer Section, click 'Add Retailers' button
Then In the Select Retailers window, select retailer: Amazon
Then In the Select Retailers window, click 'Done' button
Then in the Retailer page, I click Continue

#Then I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC57439, container type: Glass Container and size: 33
Then I should be on the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page
And In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, I click the Add UPC Button
And In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, for section: 'Provide the product's UPC(s)- including container type and size (ounces)' enter UPC Number: saved as UPC57439 enter Size: 33 and enter Container Type: Glass Container
Then in the Global Trade Item Number (GTIN) / Universal Product Code (UPC) page, I click Continue

#Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
Given I should be on the Regulatory Documents to Provide Page
Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
Then in the Regulatory Documents to Provide page, I click Continue

#Given I call Shared Step 60931 (Additional Documents to Provide - Exemption - Special Permit - Product Label)
Given I should be on the Additional Documents to Provide Page
Then In the Additional Documents to Provide, upload PDF document to Upload Transportation Exemption Letter or Special Permit field
Then In the Additional Documents to Provide, upload PDF document to Provide Full Product Label (required) field
Then in the Additional Documents to Provide page, I click Continue

Then in the Optional Reports and Documents Available for Purchase page, I click Continue

#Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
#	| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Product's Dispensing Method | Partition Coefficient |
#	| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | Aerosol                     | 41.3005               |
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

#Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Anti-Transpirant
Then I should be on the Data Acceptance Page
And In the Data Acceptance Section, click 'Summary' button
And I switch to the tab with Data Summary page
And In the Summary Page, the 'Type of Product (select)' section should be showing the following value: Anti-Transpirant
And I close the tab with Data Summary page
Then I should be on the Data Acceptance Page

#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase57439
Then I navigate to the Home Page
Then In the Product Grid, delete the product saved as: TestCase57439

@TestCase:57646
Scenario: [57646] Plant Growth regulator (Liquid or Solid) (RU000291) 2-L
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC57646
	Given I delete all products with UPC Number: saved as UPC57646
#	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Then in the New Product page, I click Continue

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
	Then I should be on the Retailer Page
	And In the Retailer Section, click 'Add Retailers' button
	And In the Select Retailers window, select retailer: Amazon
	And In the Select Retailers window, click 'Done' button
	Then in the Retailer page, I click Continue

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

	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Plant Growth regulator (Liquid or Solid)
	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase57646
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase57646

@TestCase:57649
Scenario: [57649] Cosmetics (RU000034) 2LS - 2L
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
#	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Then in the New Product page, I click Continue

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

	#Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
	Given I should see the Regulatory Information 3 Page
	Then In the Regulatory Information 3 Section, the statement 'Based on the product's recommended use and formulation, this is a possible pharmaceutical waste for California.  Please complete the additional question below to ensure proper classification of this product for the retailer(s).' is displayed
	Then In the Regulatory Information 3 Section, in section: 'Refer to your Product Label.  From the options, select those that appear on the Label.' displayed options are:
	| Option                 |
	| Drug Facts Panel       |
	| Supplement Facts Panel |
	| Nutrition Facts Panel  |
	| None of the Above      |
	Then In the Regulatory Information 3 Section, in section: 'Refer to your Product Label.  From the options, select those that appear on the Label.' click the checkbox option: None of the Above 
	Then In the Regulatory Information 3 Section, the following link: Nutritional and Supplement Labels should be displayed
	Then In the Regulatory Information 3 Section, the following link: Dietary Supplements Label should be displayed
	Then In the Regulatory Information 3 Section, the following link: OTC Drug Facts Label (may include Active Ingredient) should be displayed
	Then in the Regulatory Information 3 page I click Continue
	
	#Given I call Shared Step 57506 (Transportation Details 1 - Regulated for Transport(No) - Exemption(Random) - Continue - Happy Path)
	Then I should be on the Transportation Details 1 Page
	And In the Transportation Details 1 Section, set the option in section: 'Product is Regulated for Transport': to: No, due to an exemption or exception
	And In the Transportation Details 1 Section, set the option in section: 'Please select DOT Exceptions if applicable?': to: 173.120(b)(3):  Combustible liquid that does not sustain combustion
	Then in the Transportation Details 1 page, I click Continue

	#Given I call Shared Step 62536 (Transportation Details 2 > I do not ship internationally > Continue - Happy Path)
	Then I should be on the Transportation Details 2 Page
	And In the Transportation Details 2 Section, set the option in section: 'International Shipping when DOT Exemption taken?': to: I do not ship internationally and I do not know the classification
	Then in the Transportation Details 2 page, I click Continue

	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
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
#	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Then in the New Product page, I click Continue

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

#Given I call Shared Step 57501 (Physical and Chemical Properties - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue - HP)
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

	#Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
	Given I should see the Regulatory Information 3 Page
	Then In the Regulatory Information 3 Section, the statement 'Based on the product's recommended use and formulation, this is a possible pharmaceutical waste for California.  Please complete the additional question below to ensure proper classification of this product for the retailer(s).' is displayed
	Then In the Regulatory Information 3 Section, in section: 'Refer to your Product Label.  From the options, select those that appear on the Label.' displayed options are:
	| Option                 |
	| Drug Facts Panel       |
	| Supplement Facts Panel |
	| Nutrition Facts Panel  |
	| None of the Above      |
	Then In the Regulatory Information 3 Section, in section: 'Refer to your Product Label.  From the options, select those that appear on the Label.' click the checkbox option: None of the Above 
	Then In the Regulatory Information 3 Section, the following link: Nutritional and Supplement Labels should be displayed
	Then In the Regulatory Information 3 Section, the following link: Dietary Supplements Label should be displayed
	Then In the Regulatory Information 3 Section, the following link: OTC Drug Facts Label (may include Active Ingredient) should be displayed
	Then in the Regulatory Information 3 page I click Continue
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
	Then I should be on the Retailer Page
	And In the Retailer Section, click 'Add Retailers' button
	And In the Select Retailers window, select retailer: Amazon
	And In the Select Retailers window, click 'Done' button
	Then in the Retailer page, I click Continue

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

	Given I log in with the account saved in TReVor as: ProductAccount

	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Given in the New Product page, I click Continue

	#And I call Shared Step 57561a (The Product - Enter Product Name: Pest repellant for Use on Animals - liquid and select Type of Product): Pest (Flea, Tick, etc.) repellant for Use on Animals - liquid
	Then I should be on the The Product Page
	And In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Pest (Flea, Tick, etc.) repellant for Use on Animals - liquid_#71274
	And In the Product Section, set the option in section: 'Type of Product (select)' to: Pest (Flea, Tick, etc.) repellant for Use on Animals - liquid
	Then in the The Product page, I click Continue

	Then I save the product information as: TestCase71274

	#And I call Shared Step 56799 (Confirm Product Information shows Pesticide question and its radio buttons)
	#Given I call Shared Step 57865 (Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
	Given I should see the Product Information Page
	Then In the Product Information Section, set the option in section: 'Which best describes your product, including when FIFRA 25(b) Exempt' to: Product is intended for preventing, destroying, repelling, or mitigating pests (including insects, rodents, mold, virus, bacteria, and other micro-organisms)
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page, I click Continue

	#Given I call Shared Step 74760 (Physical and Chemical Properties - Select Liquid as primary physical state and enter all required data)
	#	| Primary Physical State | Secondary Physical State | Relative Density | pH | Boiling Point (in Celsius) | Flash Point (in Celsius) | Flash Point Testing Method Used | Select the best Water Solubility description |
	#	| Liquid                 | Liquid                   | 2                | 8  | 100                        | 80                       | Not applicable/available        | Dispersible                                  |
	Then I should be on the Physical and Chemical Properties Page
	And In the Physical and Chemical Properties Section, the section: 'Primary Physical State' should be showing the option: Liquid
	And In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Liquid
	And In the Physical and Chemical Properties Section, for section: 'Relative Density' enter text: 1.04
	And In the Physical and Chemical Properties Section, for section: 'pH' enter text: 8
	And In the Physical and Chemical Properties Section, for section: 'Boiling Point (in Celsius)' enter text: 100
	And In the Physical and Chemical Properties Section, for section: 'Flash Point (in Celsius)' select the checkbox option: 'I do not have exact Flash Point data available to me'
	And In the Physical and Chemical Properties Section, set the option in section: 'Flash Point (in Celsius)' to: None, No Flash Point
	And In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
	Then in the Physical and Chemical Properties page, I click Continue

	#Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
	#	| ComponentName    | Percent | PublicallyDisclosed | TradeSecret | PublicName |
	#	| Triclosan        | 24.94   | false               | false       |            |
	#	| Hydrogen         | 30.2    | false               | false       |            |
	#	| Propylene Glycol | 19.8    | false               | false       |            |
	#	| Butane           | 25.06   | false               | false       |            |
	Then I should be on the Ingredients Page
	And In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue      | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	| component name | Glycerol         | 50      | False               | False         |             |
	| component name | Oils, Clove      | 10      | False               | False         |             |
	| component name | Potassium Oleate | 20      | False               | False         |             |
	| component name | Water            | 20      | False               | False         |             |
	Then in the Ingredients page, I click Continue

	#And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Then I should be on the Inventory Status, Prop 65 (US) Page
	And In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is exempt from TSCA chemical Inventory listing requirements.
	And In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page, I click Continue

	#Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
	Given I should be on the Product Labeling Page
	Then In the Product Labeling Section, the statement 'Based on the product's recommended use and formulation, this is a possible pharmaceutical waste for California.  Please complete the additional question below to ensure proper classification of this product for the retailer(s).' is displayed
	Then In the Product Labeling Section, in section: 'Refer to your Product Label.  From the options, select those that appear on the Label.' displayed options are:
	| Option                 |
	| Drug Facts Panel       |
	| Supplement Facts Panel |
	| Nutrition Facts Panel  |
	| None of the Above      |
	Then In the Product Labeling Section, in section: 'Refer to your Product Label.  From the options, select those that appear on the Label.' click the checkbox option: None of the Above 
	Then In the Product Labeling Section, the following link: Nutritional and Supplement Labels should be displayed
	Then In the Product Labeling Section, the following link: Dietary Supplements Label should be displayed
	Then In the Product Labeling Section, the following link: OTC Drug Facts Label (may include Active Ingredient) should be displayed
	Then in the Product Labeling page, I click Continue

	#And I call Shared Step 29183 (Pesticide Details - U.S. - No EPA number)
	Given I should be on the Pesticide Details - U.S. Page
	And In the Pesticide Details - U.S. Section, in 'Product has an Environmental Protection Agency (EPA) Registration Number' enter No
	And In the Pesticide Details - U.S. Section, in 'Product has a State Registration' enter No
	And In the Pesticide Details - U.S. Section, in 'Select the applicable exemption' enter Product is FIFRA 25(b) Exempt.
	Then in the Pesticide Details - U.S. page, I click Continue

	#And I call Shared Step 57507 (Transportation Details 1- Not Regulated - Continue - Happy Path)
	Then I should be on the Transportation Details 1 Page
	And In the Transportation Details 1 Section, set the option in section: 'Product is Regulated for Transport': to: Not Regulated
	Then in the Transportation Details 1 page, I click Continue

	#And I call Shared Step 63219 (Retailer Association - Select No Retailer - Click continue)
	Then I should be on the Retailer Page
	Then in the Retailer page, I click Continue

	#And I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should be on the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Yes, I certify that I have an OSHA-compliant SDS for this product and would like to upload it.
	And In the Regulatory Documents to Provide Section, upload file in section: 'OSHA SDS'
	Then in the Regulatory Documents to Provide page, I click Continue

	Then I should see the Additional Documents to Provide Page
	And in the Additional Documents to Provide page, I click Continue
	Then In the Additional Documents to Provide, section 'Provide Full Product Label (required)' error message should display: Document is required:  Please upload a PDF of the Product Label (Full Label).
	And In the Additional Documents to Provide, upload PDF document to Provide Full Product Label (required) field
	Then in the Additional Documents to Provide page, I click Continue

	Given in the Optional Reports and Documents Available for Purchase page, I click Continue

	#And I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test comment
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	#Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Pest (Flea, Tick, etc.) repellant for Use on Animals - liquid
	Then I should be on the Data Acceptance Page
	And In the Data Acceptance Section, click 'Summary' button
	And I switch to the tab with Data Summary page
	And In the Summary Page, the 'Type of Product (select)' section should be showing the following value: Pest (Flea, Tick, etc.) repellant for Use on Animals - liquid
	And In the Summary Page, the 'Which best describes your product, including when FIFRA 25(b) Exempt' section should be showing the following value: Product is intended for preventing, destroying, repelling, or mitigating pests (including insects, rodents, mold, virus, bacteria, and other micro-organisms)
	And In the Summary Page, the 'U.S. Toxic Substances Control Act (TSCA) Status' section should be showing the following value: This product is exempt from TSCA chemical Inventory listing requirements.
	And In the Summary Page, the 'Refer to your Product Label.  From the options, select those that appear on the Label.' section should be showing the following value: None of the Above
	And In the Summary Page, the 'Product has an Environmental Protection Agency (EPA) Registration Number' section should be showing the following value: No
	And In the Summary Page, the 'Product has a State Registration' section should be showing the following value: No
	And In the Summary Page, the 'Select the applicable exemption' section should be showing the following value: Product is FIFRA 25(b) Exempt.
	And In the Summary Page, the 'Product is Regulated for Transport' section should be showing the following value: Not Regulated
	And In the Summary Page, click the View button for section: Please upload a PDF of the product label (full label).
	Then In the Summary Page, after clicking 'View' button I confirm pdf file is downloaded
	And In the Summary Page, click the View button for section: OSHA-SDS
	Then In the Summary Page, after clicking 'View' button I confirm pdf file is downloaded
	And I close the tab with Data Summary page
	Then I should be on the Data Acceptance Page

	#Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	#Given I should see the Data Acceptance Page
	#Then In the Data Acceptance Section, check 'Agreed' checkbox
	#Then In the Data Acceptance Section, click 'Accept' button

	#Then I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase71274
	#Then In the Purchase Summary page message is displayed with text: Thank you for registering your product on WERCSmart for assessment. The retailers may receive your assessment in approximately two (2) business days, if no delays in processing the assessment, and should no data issues arise.
	#Then In the Purchase Summary Page, click the 'Home' button
	#Then The home screen should load



	
# Created by Saikiran Chittampally
# Test case can be found at the following paths:
# NetProjects10\WERCSmart UX Reboot\WERCSmart\Product Registration\Flow 2
@TestCase:57647
Scenario: [57647] Insecticide-Flying Bug-Moth Proofing Product containing <98% Para-Dichlorobenzene - (RU001000) - 2S
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC57647
	Given I delete all products with UPC Number: saved as UPC57647
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Then in the New Product page, I click Continue

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
	Then I should be on the Retailer Page
	And In the Retailer Section, click 'Add Retailers' button
	And In the Select Retailers window, select retailer: Amazon
	And In the Select Retailers window, click 'Done' button
	Then in the Retailer page, I click Continue

	Then I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC57647, container type: Cardboard and size: 1
    #Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
	Then in the Regulatory Documents to Provide page I click Continue

	Given I call Shared step 65961 (Additional Documents to Provide - Upload Full Product Label - Continue)
	

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

	#Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
	Given I should see the Regulatory Information 3 Page
	Then In the Regulatory Information 3 Section, the statement 'Based on the product's recommended use and formulation, this is a possible pharmaceutical waste for California.  Please complete the additional question below to ensure proper classification of this product for the retailer(s).' is displayed
	Then In the Regulatory Information 3 Section, in section: 'Refer to your Product Label.  From the options, select those that appear on the Label.' displayed options are:
	| Option                 |
	| Drug Facts Panel       |
	| Supplement Facts Panel |
	| Nutrition Facts Panel  |
	| None of the Above      |
	Then In the Regulatory Information 3 Section, in section: 'Refer to your Product Label.  From the options, select those that appear on the Label.' click the checkbox option: None of the Above 
	Then In the Regulatory Information 3 Section, the following link: Nutritional and Supplement Labels should be displayed
	Then In the Regulatory Information 3 Section, the following link: Dietary Supplements Label should be displayed
	Then In the Regulatory Information 3 Section, the following link: OTC Drug Facts Label (may include Active Ingredient) should be displayed
	Then in the Regulatory Information 3 page I click Continue
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

	#Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Liquid Dishwashing Soap
	Then I should be on the The Product Page
	And In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Liquid Dishwashing Soap_#217787
	And In the Product Section, set the option in section: 'Type of Product (select)' to: Liquid Dishwashing Soap
	Then in the The Product page, I click Continue

	Then I save the product information as: TestCase217787

	#Given I call Shared Step 217788 (Product Information - not Pesticide, US only, select Yes for JSON Question - Happy Path)
	Then I should be on the Product Information Page
	And In the Product Information Section, set the option in section: 'Which best describes your product, including when FIFRA 25(b) Exempt' to: Product is not a pesticide and does not make or imply a pesticidal claim on the labeling or in the product description (ex. kills, sterilizes, disinfects, sanitizes, antimicrobial)
	And In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	And In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	And In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	And In the Product Information Section, set the option in section: 'Cleaning products must comply with California's Cleaning Product Right to Know Act. I would like to provide the additional information needed for this program during registration.' to: Yes
	And In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	And In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page, I click Continue

	#Given I call Shared Step 217789 (Physical and Chemical Properties - Physical Property - Liquid )
	Then I should be on the Physical and Chemical Properties Page
	And In the Physical and Chemical Properties Section, the section: 'Primary Physical State' should be showing the option: Liquid
	And In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Liquid
	And In the Physical and Chemical Properties Section, for section: 'Relative Density' enter text: 0.1
	And In the Physical and Chemical Properties Section, for section: 'pH' enter text: 6
	And In the Physical and Chemical Properties Section, for section: 'Boiling Point (in Celsius)' enter text: 100
	And In the Physical and Chemical Properties Section, for section: 'Flash Point (in Celsius)' enter text: 100
	And In the Physical and Chemical Properties Section, set the option in section: 'Flash Point Testing Method Used' to: Not applicable/available
	And In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Miscible
	Then in the Physical and Chemical Properties page, I click Continue

	#Given I call Shared Step 217792 California Cleaning Product Disclosure - Manufacturer
	Then I should be on the California Cleaning Product Disclosure Page 
	And In the California Cleaning Product Disclosure Section, set the radio option in section: 'Who is publicly identified on the product label as responsible for the product?': to: Manufacturer
	And In the California Cleaning Product Disclosure Section, set the option in section: 'Who is the Final Domestic Distributor (if any) of the product?' to: Target
	And In the California Cleaning Product Disclosure Section, set the option in section: 'Is your identity, as the Manufacturer of this product, Confidential Business Information (CBI)?' to: No
	And In the California Cleaning Product Disclosure Section, set the option in section: 'Select the product's GTIN Brick Code' to: [10000397] Cleaning Aids
	Then in the California Cleaning Product Disclosure page, I click Continue

	Then I should be on the Ingredients Page
	And In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue                                         | Percent | Publicly Disclosed? | Trade Secret? | Public Name                                         |
	| component name | Sodium laureth sulfate                              | 20      | True                | False         | Sodium Laureth Sulfate                              |
	| component name | Ammonium laureth sulfate                            | 20      | True                | False         | Ammonium Laureth Sulfate                            |
	| component name | Dodecylbenzene sulfonic acid                        | 5       | True                | False         | Dodecylbenzene Sulfonic Acid                        |
	| component name | D-Glucopyranose, oligomeric, decyl octyl glycosides | 5       | True                | False         | D-Glucopyranose, oligomeric, decyl octyl glycosides |
	| component name | Sodium hydroxide                                    | 1       | True                | False         | Sodium Hydroxide                                    |
	| component name | Water                                               | 49      | True                | False         | Water                                               |
	And In the Ingredients Section ingredients table, for Ingredient: Sodium laureth sulfate add Ingredient Type: Intentionally Added and Functional Purpose:
	| Functional Purpose |
	| Antifungal Agent   |
	And In the Ingredients Section ingredients table, for Ingredient: Ammonium laureth sulfate add Ingredient Type: Intentionally Added and Functional Purpose:
	| Functional Purpose  |
	| Antimicrobial Agent |
	And In the Ingredients Section ingredients table, for Ingredient: Dodecylbenzene sulfonic acid add Ingredient Type: Intentionally Added and Functional Purpose:
	| Functional Purpose  |
	| Deodorizing Agent   |
	And In the Ingredients Section ingredients table, for Ingredient: D-Glucopyranose, oligomeric, decyl octyl glycosides add Ingredient Type: Intentionally Added and Functional Purpose:
	| Functional Purpose |
	| Preservative       |
	And In the Ingredients Section ingredients table, for Ingredient: Sodium hydroxide add Ingredient Type: Intentionally Added and Functional Purpose:
	| Functional Purpose |
	| Deodorizing Agent  |
	And In the Ingredients Section ingredients table, for Ingredient: Water add Ingredient Type: Intentionally Added and Functional Purpose:
	| Functional Purpose |
	| Diluent            |
	Then in the Ingredients page, I click Continue
	#And In the Ingredients Section, I confirm I check the checkbox in the popup view with the following text: The Product Type, Pest Selection, and Ingredients listed are accurate.
	#And In the Ingredients Section, In the popup view with the following title: Product Contains Ingredients Typical of a Pesticide I click the Confirm button

	#Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Then I should be on the Inventory Status, Prop 65 (US) Page
	And In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	And In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page, I click Continue

	#And I call Shared Step 57507 (Transportation Details 1- Not Regulated - Continue - Happy Path)
	Then I should be on the Transportation Details 1 Page
	And In the Transportation Details 1 Section, set the option in section: 'Product is Regulated for Transport': to: Not Regulated
	Then in the Transportation Details 1 page, I click Continue

	#And If ECOLOGO Readiness page is displayed I call Shared Step 57712 - ECOLOGO Readiness Assessment - Not at this time - Continue - Happy Path

	#Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Target
	Then I should be on the Retailer Page
	And In the Retailer Section, click 'Add Retailers' button
	And In the Select Retailers window, select retailer: Target
	And In the Select Retailers window, click 'Done' button
	Then in the Retailer page, I click Continue

	#Given I call Shared Step 87647 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC217787, container type: Plastic Container and size: 8.6 do not click continue
	Then I should be on the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page
	And In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, I click the Add UPC Button
	And In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, for section: 'Provide the product's UPC(s)- including container type and size (ounces)' enter UPC Number: 711969119824 enter Size: 8.6 and enter Container Type: Plastic Container
	And In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, the following container types should be displayed from the drop down list:
	| Container Type                 |
	| Coated or Laminated Paperboard |
	| Full Syringe - Medical         |
	| Glass Container                |
	| Metal Container                |
	| Metal Cylinder                 |
	| Plastic Container              |
	| Vial - Medical                 |
	Then in the Global Trade Item Number (GTIN) / Universal Product Code (UPC) page, I click Continue

#	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase217787
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase217787
