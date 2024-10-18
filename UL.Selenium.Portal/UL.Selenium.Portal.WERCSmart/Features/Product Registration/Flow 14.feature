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
@run_Flow14
@StepsPrototype
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:NewProduct
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:TheProduct
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:ProductInformation
@PhysicalAndChemicalProp
@Ingredients
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:InventoryStatusProp65
@GTINAndUPC
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:RegulatoryDocumentsToProvide
@SafetyDataSheetAuthoring
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:OptionalComments
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:DataAcceptance
@LiquidCoreProduct
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:PesticideDetailsUS
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:TransportationDetails1
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:USDepartamentOfTransportationDOT
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:Retailer
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:AdditionalDocumentsToProvide
@SafetyDataSheetAuthoring
@Steps_ProductPrototype
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:PesticideDetailsStateRegistration
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:NewProduct
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:TheProduct

Feature: Flow 14


@TestCase:58736
Scenario: [58736] Sanitizer Wipes for Use on Domesticated Animals (Solid)- RU001240
	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC58736
	Given I delete all products with UPC Number: saved as UPC58736
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Given in the New Product page I click Continue
	#Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Sanitizer Wipes for Use on Domesticated Animals
	Given I should see the The Product Page
	Then In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Sanitizer Wipes for Use on Domesticated Animals_#58736
	Then In the Product Section, set the option in section: 'Type of Product (select)' to: Sanitizer Wipes for Use on Domesticated Animals
 	Then in the The Product page, I click Continue

	Then I save the product information as: TestCase58736
    #Given I call Shared Step 57865 (Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
	Given I should see the Product Information Page
	Then In the Product Information Section, set the option in section: 'Which best describes your product, including when FIFRA 25(b) Exempt' to: Product is intended for preventing, destroying, repelling, or mitigating pests (including insects, rodents, mold, virus, bacteria, and other micro-organisms)
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue

	#Given I call Shared Step 32931 (Liquid Core Product - select  No - Happy Path)
	Given I should see the Liquid Core Product Page
	Then In the Liquid Core Product Section, set the option in section: 'Is there a free liquid in the Product's container that is 10ml or greater?' to: No
	Then in the Liquid Core Product page I click Continue

	#Given I call Shared Step 164954 (Enter Physical Property - Solid - Without Secondary Physical State - Without Water Solubility Question)
	Given I should see the Physical and Chemical Properties Page
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' confirm option is selected: Solid
	Then In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Then in the Physical and Chemical Properties page I click Continue

	#Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
	#	| ComponentName    | Percent | PublicallyDisclosed | TradeSecret | PublicName |
	#	| Triclosan        | 24.94   | false               | false       |            |
	#	| Hydrogen         | 30.2    | false               | false       |            |
	#	| Propylene Glycol | 19.8    | false               | false       |            |
	#	| Butane           | 25.06   | false               | false       |            |

	Given I should see the Ingredients Page
	Then In the Ingredients section, add the following ingredients:
		| SearchType     | SearchValue      | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
		| component name | Triclosan        | 24.94   | false               | false         |             |
		| component name | Hydrogen         | 30.2    | false               | false         |             |
		| component name | Propylene Glycol | 19.8    | false               | false         |             |
		| component name | Butane           | 25.06   | false               | false         |             |
	Then in the Ingredients page I click Continue

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

	#Given I call Shared Step 34455 (U.S. Department of Transportation (DOT) Classification - Enter all valid data)
	Given I should see the U.S. Department of Transportation (DOT) Classification Page
	Then In the U.S. Department of Transportation (DOT) Classification Section, set the option in section: 'UN Number': to: UN1170
	Then In the U.S. Department of Transportation (DOT) Classification Section, set the option in section: 'Proper Shipping Name': to: Ethanol
	Then In the U.S. Department of Transportation (DOT) Classification Section, set the option in section: 'Technical Name (if applicable)': to: Technical Test Name
	Then In the U.S. Department of Transportation (DOT) Classification Section, set the option in section: 'Hazard Class': to: 3
	Then In the U.S. Department of Transportation (DOT) Classification Section, set the option in section: 'Packing Group': to: III
	Then In the U.S. Department of Transportation (DOT) Classification Section, set the option in section: 'Product has a boiling point of <=35⁰C and flash point of >60⁰C. Packing Group selected is not consistent with this data. Verify the data and transportation packing group. If problem persists, please contact Support.': to: Based on defined viscosity parameters, this product is classified as PG III.
	Then in the U.S. Department of Transportation (DOT) Classification page I click Continue

	#Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Staples
	Given I should see the Retailer Page
	Then In the Retailer Section, click 'Add Retailers' button
	Then In the Select Retailers window, select retailer: Staples
	Then In the Select Retailers window, click 'Done' button
	Then in the Retailer page I click Continue

	Then I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC58736, container type: Cardboard and size: 33

	#Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
	Then in the Regulatory Documents to Provide page I click Continue

	#Given I call Shared Step 60931 (Additional Documents to Provide - Exemption - Special Permit - Product Label)
	Given I should see the Additional Documents to Provide Page
	Then In the Additional Documents to Provide, upload PDF document to Upload Transportation Exemption Letter or Special Permit field
	Then In the Additional Documents to Provide, upload PDF document to Provide Full Product Label (required) field
	Then in the Additional Documents to Provide page I click Continue

	Given I should see the Optional Reports and Documents Available for Purchase Page
	And in the Optional Reports and Documents Available for Purchase page I click Continue

	#Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
	#	| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient | Product's Dispensing Method |
	#	| Mask                          | 150                      | 44                      | 10.7      | White      | Floral | No data available | 12                    | Aerosol                     |

	Given I should see the Safety Data Sheet Authoring - Additional Data (Optional) Page
	Then In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Personal Protection Equipment Recommended (select)' to: Mask
	Then In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Autoignition Temperature (°C)' enter text: 150
	Then In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Minimum Ignition Energy (mJ)' enter text: 44
	Then In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Viscosity' enter text: 10.7
	Then In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Appearance' to: White
	Then In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor' to: Floral
	Then In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor Threshold' to: No data available
	Then In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Partition Coefficient' enter text: 12
	And in the Safety Data Sheet Authoring - Additional Data (Optional) page I click Continue

	#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: User added Comments Text 58736. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase58736
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase58736

@TestCase:58738
Scenario: [58738] Sanitizer Wipes for Use on Domesticated Animals (Liquid)- RU001240
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC58738
	Given I delete all products with UPC Number: saved as UPC58738
#	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Then in the New Product page, I click Continue

	#Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Sanitizer for Use on Domesticated Animals
	Given I should see the The Product Page
	Then In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Sanitizer Wipes for Use on Domesticated Animals_#58738
	Then In the Product Section, set the option in section: 'Type of Product (select)' to: Sanitizer Wipes for Use on Domesticated Animals
 	Then in the The Product page I click Continue

	Then I save the product information as: TestCase58738
	#Given I call Shared Step 57865 (Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
	Given I should see the Product Information Page
	Then In the Product Information Section, set the option in section: 'Which best describes your product, including when FIFRA 25(b) Exempt' to: Product is intended for preventing, destroying, repelling, or mitigating pests (including insects, rodents, mold, virus, bacteria, and other micro-organisms)
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue

	Given I should see the Liquid Core Product Page
	Then In the Liquid Core Product Section, set the option in section: 'Is there a free liquid in the Product's container that is 10ml or greater?' to: No
	Then in the Liquid Core Product page I click Continue

	#Given I call Shared Step 236130 (Physical and Chemical Properties - PPS (SOLID) - Applicable Only to Sanitizer Wipes for Use on Domesticated Animals (RU001240))		
	Given I should see the Physical and Chemical Properties Page
	Then In the Physical and Chemical Properties Section, set the option in section: 'Primary Physical State' to: Solid
	Then In the Physical and Chemical Properties Section, the confirm section: 'Secondary Physical State' is not displayed
	Then In the Physical and Chemical Properties Section, the confirm section: 'When mixed with an equal amount of water, will this produce a solution with a pH <=2 or a pH >=12.5?' is displayed
	Then Expand the Liquid Core Product panel

	Given I should see the Liquid Core Product Page
	Then In the Liquid Core Product Section, set the option in section: 'Is there a free liquid in the Product's container that is 10ml or greater?' to: Yes
	Then in the Liquid Core Product page I click Continue

	#Given I call Shared Step 236132 (Physical and Chemical Properties - PPS (LIQUID) - Applicable Only to Sanitizer Wipes for Use on Domesticated Animals (RU001240))
	Given I should see the Physical and Chemical Properties Page
	Then In the Physical and Chemical Properties Section, set the option in section: 'Primary Physical State' to: Liquid
	Then In the Physical and Chemical Properties Section, the confirm section: 'Secondary Physical State' is not displayed
	Then In the Physical and Chemical Properties Section, the confirm section: 'Relative Density' is displayed
	Then In the Physical and Chemical Properties Section, the confirm section: 'pH' is displayed
	Then In the Physical and Chemical Properties Section, the confirm section: 'Boiling Point (in Celsius)' is displayed
	Then In the Physical and Chemical Properties Section, the confirm section: 'Flash Point (in Celsius)' is displayed
	Then Expand the Liquid Core Product panel

	Given I should see the Liquid Core Product Page
	Then In the Liquid Core Product Section, set the option in section: 'Is there a free liquid in the Product's container that is 10ml or greater?' to: No
	Then in the Liquid Core Product page I click Continue

	Given I should see the Physical and Chemical Properties Page
	Then In the Physical and Chemical Properties Section, set the option in section: 'Primary Physical State' to: Solid
	Then In the Physical and Chemical Properties Section, the confirm section: 'Secondary Physical State' is not displayed
	Then In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Then in the Physical and Chemical Properties page I click Continue

	#Given I call Shared Step 74760 (Physical and Chemical Properties - Select Liquid as primary physical state and enter all required data)
	#	| Primary Physical State | Secondary Physical State | Relative Density | pH | Boiling Point (in Celsius) | Flash Point (in Celsius) | Flash Point Testing Method Used | Select the best Water Solubility description |
	#	| Liquid                 | Liquid                   | 2                | 2  | 2                          | 66                       | Closed cup method               | Dispersible                                  |
	#Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
	#	| ComponentName    | Percent | PublicallyDisclosed | TradeSecret | PublicName |
	#	| Triclosan        | 24.94   | false               | false       |            |
	#	| Hydrogen         | 30.2    | false               | false       |            |
	#	| Propylene Glycol | 19.8    | false               | false       |            |
	#	| Butane           | 25.06   | false               | false       |            |

	Given I should see the Ingredients Page
	Then In the Ingredients section, add the following ingredients:
		| SearchType     | SearchValue                          | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
		| component name | Isopropyl Alcohol                    | 100.00  | false               | false         |             |
		| component name | Alkylbenzyldimethylammonium chloride | 0.25    | false               | false         |             |
		| component name | Quaternary ammonium compounds        | 0.25    | false               | false         |             |
	Then in the Ingredients page I click Continue

	#Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I should see the Inventory Status, Prop 65 (US) Page
	Then In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	Then In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page I click Continue

	#Given I call Shared Step 57589 (Enter Pesticide Data - United States (without EPA number))
	Given I should see the Pesticide Details - U.S. Page
	Then In the Pesticide Details - U.S. Section, in 'Product has an Environmental Protection Agency (EPA) Registration Number' enter Yes
	Then In the Pesticide Details - U.S. Section, in 'EPA Pesticide Registration No.' enter 103258-WY-1
	Then in the Pesticide Details - U.S. page I click Continue

	Given I should see the Pesticide Details - State Registration Details Page
	Then In the Pesticide Details - State Registration Details section, click 'Select All' for the status: Pending State Registration for all states
	Then in the Pesticide Details - State Registration Details page I click Continue

	#Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	Given I should see the Transportation Details 1 Page
	Then In the Transportation Details 1 Section, set the option in section: 'Product is Regulated for Transport': to: Yes
	Then In the Transportation Details 1 Section, set the option in section: 'Select all modes of transport that you've classified the product for': to: DOT
	Then In the Transportation Details 1 Section, set the option for DOT mode of transport to: Shipping with limited quantity
	Then in the Transportation Details 1 page I click Continue

	#Given I call Shared Step 34455 (U.S. Department of Transportation (DOT) Classification - Enter all valid data): UN Number: 1992, Proper Shipping Name: Aerosols, Technical Name: Technical Test Name, Hazard Class: 2.1, Packing Group: None
	#Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)
	#Given I call Shared Step 34455 (U.S. Department of Transportation (DOT) Classification - Enter all valid data)
	Given I should see the U.S. Department of Transportation (DOT) Classification Page
	Then In the U.S. Department of Transportation (DOT) Classification Section, set the option in section: 'UN Number': to: UN3175
	Then In the U.S. Department of Transportation (DOT) Classification Section, set the option in section: 'Proper Shipping Name': to: Solids containing flammable liquid, n.o.s.
	Then In the U.S. Department of Transportation (DOT) Classification Section, set the option in section: 'Technical Name (if applicable)': to: Technical Test Name
	Then In the U.S. Department of Transportation (DOT) Classification Section, set the option in section: 'Hazard Class': to: 4.1
	Then In the U.S. Department of Transportation (DOT) Classification Section, set the option in section: 'Packing Group': to: II
	Then in the U.S. Department of Transportation (DOT) Classification page I click Continue
	
	#Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Amazon
	Then I should be on the Retailer Page
	And In the Retailer Section, click 'Add Retailers' button
	And In the Select Retailers window, select retailer: Amazon
	And In the Select Retailers window, click 'Done' button
	Then in the Retailer page, I click Continue

	Then I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC58738, container type: Cardboard and size: 33
    #Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
	Then in the Regulatory Documents to Provide page I click Continue

	#Given I call Shared Step 60931 (Additional Documents to Provide - Exemption - Special Permit - Product Label)
	Given I should see the Additional Documents to Provide Page
	Then In the Additional Documents to Provide, upload PDF document to Upload Transportation Exemption Letter or Special Permit field
	Then In the Additional Documents to Provide, upload PDF document to Provide Full Product Label (required) field
	Then in the Additional Documents to Provide page I click Continue

	And I should see the Optional Reports and Documents Available for Purchase Page
	Then In the Optional Reports and Documents Available for Purchase page, the footer text contains: Additional documents are not subject to standard two day turnaround.
	#Then I check for the following text: Additional documents are not subject to standard two day turnaround. in the Optional Reports and Documents Available for Purchase Page
	And in the Optional Reports and Documents Available for Purchase page I click Continue
#	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
#		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient | Product's Dispensing Method |
#		| Mask                          | 150                      | 44                      | 10.7      | White      | Floral | No data available | 12                    | Aerosol                     |
	Then I should be on the Safety Data Sheet Authoring - Additional Data (Optional) Page
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Personal Protection Equipment Recommended (select)' to: Mask
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Autoignition Temperature (°C)' enter text: 150
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Minimum Ignition Energy (mJ)' enter text: 44
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Viscosity' enter text: 10.7
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Appearance' to: White
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor' to: Floral
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor Threshold' to: No data available
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Partition Coefficient' enter text: 12
	Then in the Safety Data Sheet Authoring - Additional Data (Optional) page, I click Continue



	#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: User added Comments Text 58738. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase58738
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase58738
