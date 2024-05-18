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
@run_Flow18
@StepsPrototype
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:TheProduct
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:ProductInformation
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:NewProduct
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:ProductInformation
@PhysicalAndChemicalProp
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:RegulatoryDocumentsToProvide
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:OptionalComments
@Ingredients
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:Retailer
@SafetyDataSheetAuthoring
@AdditionalDocsContactInfo

Feature: Flow 18

@ignore
@tfsdesign
@TestCase:60116
Scenario: [60116] Anti-Static Product - Aerosol - RU000656
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC60116
	Given I delete all products with UPC Number: saved as UPC60116
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Anti-Static Product - Aerosol
	Then I save the product information as: TestCase60116
	Given I call Shared Step 60310 (Product Information - Without Child question)
	Given I call Shared Step 57111 (Enter Product Data for Physical State - Aerosol only)
	Given I click continue
	Then I should see an error message: ALERT! The ingredient table does not include a compressed gas (Bag-On-Valve) or a propellant. Please update your ingredients to include the propellant before proceeding.
	Given I call Shared Step 69557 (Enter Ingredients for Aerosol Propellent)
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	Given I call Shared Step 65705 (Transportation - DOT UN step - Enter UN1950, select Aerosols,  2.1, None, add technical name, Click Continue)
	Given I call Shared Step 62710 (Confirm VOC OTC/CARB heading and select No to FIRST QUESTION ONLY - Happy Path)
	Given I call Shared Step 60468 (VOC - CARB only required - enter value - Continue - Happy Path)
	Given I click continue
	#Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Staples
	Then I should be on the Retailer Page
	And In the Retailer Section, click 'Add Retailers' button
	And In the Select Retailers window, select retailer: Staples
	And In the Select Retailers window, click 'Done' button
	Then in the Retailer page, I click Continue

	Then I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC60116, container type: Aerosol Can and size: 1
	#Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
	Then in the Regulatory Documents to Provide page I click Continue

	Given I call Shared Step 60567 (Upload Product Label only) for section: Volatile Organic Compounds
	And in the Optional Reports and Documents Available for Purchase page I click Continue
	#Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
	#	| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient | Product's Dispensing Method |
	#	| Mask                          | 150                      | 44                      | 10.7      | White      | Floral | No data available | 12                    | Aerosol                     |
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


	#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: User added Comments Text 60116. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Anti-Static Product - Aerosol
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase60116

# Created by Saikiran Chittampally
@TestCase:208099
Scenario: [208099] Fabric Softener - Single-Use Dryer Product Only (RU000808)
	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	#Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Then in the New Product page, I click Continue

	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Fabric Softener - Single Use Dryer Product Only
	Then I save the product information as: TestCase208099
	Given I call Shared Step 208116 Product Information - FIFRA 25(b) Product Not a Pesticide, US (SOLD), NO (OSHA), NO (DSV), YES (CA RTK), NO (PL), NO (GNFR)
	#Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I should see the Physical and Chemical Properties Page
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' should be showing the option: Solid
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' confirm option is selected: Solid
	Then In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
	Then In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Then In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
	Then in the Physical and Chemical Properties page I click Continue

	Given I call Shared Step 193979 California Cleaning Product Disclosure - Final Domestic Distributor
	Given I add the following CA Cleaning ingredients:  
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName     | IngredientType | FunctionalPurpose             | Clean | Certified |
		| Water         | 100     | true               | false       | AQUA           | Fragrance      |  |   |       |
	Then I click continue
	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Then I should see the Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB) Page
	Then I see the following questions
		| Section                                                                                                                                        |
		| Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations. |
	Then The following options should be displayed for section: Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations.
		| Option |
		| Yes    |
		| No     |
	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase208099
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase208099

# Created by Saikiran Chittampally
@TestCase:207582
Scenario: [207582] Personal Fragrance product (more than 20% fragrance) - Liquid (RU000756) - New Flow Testing
	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
#	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Then in the New Product page, I click Continue

	#Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Personal Fragrance Product (more than 20% fragrance) - Liquid
	Then I should see the The Product Page
	Then In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Personal Fragrance Product (more than 20% fragrance) - Liquid
	Then In the Product Section, set the option in section: 'Type of Product (select)' to: Personal Fragrance Product (more than 20% fragrance) - Liquid
	Then in the The Product page, I click Continue

	Then I save the product information as: TestCase207582
	#Given I call Shared Step 57798 (Product Information- Pesticide, Canada Only - No to everything else, Continue)
	Then I should see the Product Information Page
	Then In the Product Information Section, set the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' to select: United States
	Then In the Product Information Section, set the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' to not select: Canada

	Given I call Shared Step 70675 (Physical and Chemical Properties - Liquid Only - With Water Solubility - Enter all data - Continue)
	#Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Propane
	Given I should see the Ingredients Page
	Then In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	| component name | Propane       | 100     |                     |               |             |
	Then in the Ingredients page I click Continue

	Given I call Shared Step 57911 (Regulatory Information 1 - CEPA only shown - Continue - Happy Path)
	Then I should see the Pesticide Details - Canada Page
	Given I set the Provide Canada's 5-Digit Pest Control Number (PCN) or 8-Digit Drug Identification Number (DIN) for this product field to: 27925
	And The following options should be displayed for section: Product's packaging includes a Poison Danger symbol
		| Option |
		| Yes    |
		| No     |
	Given I set the Product's packaging includes a Poison Danger symbol option to: No
	Given I set the Alberta option to: Schedule 1
	Given I set the British Columbia option to: Commercial
	Given I set the Manitoba option to: Commercial
	Given I set the New Brunswick option to: None
	Given I set the New Foundland and Labrador option to: Domestic
	Given I set the Nova Scotia option to: Commercial
	Given I set the Ontario option to: Class A: Manufacturing Products
	Given I set the Prince Edward Island option to: Controlled Purchase
	Given I set the Quebec option to: Class 1
	Given I set the Saskatchewan option to: Commercial
	Given I set the Northwest Territory option to: Not Applicable 
	Given I set the Yukon Territory option to: Commercial
	Then I click continue
	Given I call Shared Step 57506 (Transportation Details 1 - Regulated for Transport(No) - Exemption(Random) - Continue - Happy Path)
	Given I call Shared Step 62536 (Transportation Details 2 > I do not ship internationally > Continue - Happy Path)
	And I call Shared Step 62710 (Confirm VOC OTC/CARB heading and select No to FIRST QUESTION ONLY - Happy Path)
	Then I click continue
	Given Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the CARB should be showing the error messages: This is a required field.
	And I set the Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the CARB option to: 50
	Then Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the CARB should should not be showing any error messages
	Then I click continue
	Given I call Shared Step 57801 (Confirm VOC Summary step shown and VOC analysis date is shown - Happy Path)
	And I confirm that statement with text: 'Based on your selection, you have verified your product contains VOC with intended uses as follows.  The CARB VOC compliance limit(s) for the intended use you identified is/are:' is not displayed
	Then in the VOC Limits table, the Use column should contain the value: Personal Fragrance Product (more than 20% fragrance) - Liquid
	Then in the VOC Limits table, the VOC Compliance Limit column should contain the value: 65
	Then in the VOC Limits table, the Regulation column should contain the value: CARB limit
	And I should see the following Voc percent for each state:
		| State           | Regulation            | VOC Value | State VOC Threshold | Message                          |
		| Canada          | State Allowable Limit | 0         | 65                  | Does not exceed the State Limits |
	Then I confirm that I see the following CARB value: 50
	Then The VOC Summary page contains the statement with the text: Based on the type of product, this must comply with the most restrictive VOC limit.
	Then The VOC Summary page contains the statement with the text: Does not exceed the limits specified in the California Consumer Products Regulation
	Given I set the Your acknowledgement of this registration includes that your product option to: Yes, I Acknowledge
	Given in the Volatile Organic Compound Summary page I click Continue
	Given I call Shared Step 150905 (Retailer - NR selected by default)
	Given I call Shared Step 78884 - Regulatory Documents to Provide - Canada only - request authoring, upload label - Continue
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	#And I call Shared Step 64097 - Additional Documents -> Contact Information - Add any Name, address, phone and emergency phone - Happy Path
	Then I should be on the Additional Documents -> Contact Information Page
	And In the Additional Documents -> Contact Information section, for section: 'Manufacturer Name' enter text: Manufacturer
	And In the Additional Documents -> Contact Information section, for section: 'Address' enter text: Address
	And In the Additional Documents -> Contact Information section, for section: 'Phone' enter text: Phone
	And In the Additional Documents -> Contact Information section, for section: 'Emergency Phone' enter text: Emergency Phone
	Then in the Additional Documents -> Contact Information page, I click Continue

	Given I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
		| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
	Given in the Optional Comments page I click Continue
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Personal Fragrance Product (more than 20% fragrance) - Liquid
	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase207582
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase207582
# Created by Saikiran Chittampally
@TestCase:207584
Scenario: [207584] Personal Fragrance product (20% or less fragrance) - Liquid - Canada Only (RU000755) - New Flow Testing
	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
#	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Then in the New Product page, I click Continue

	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Personal Fragrance Product (20% or less fragrance) - Liquid
	Then I save the product information as: TestCase207584
	Given I call Shared Step 57798 (Product Information- Pesticide, Canada Only - No to everything else, Continue)
	Given I call Shared Step 70675 (Physical and Chemical Properties - Liquid Only - With Water Solubility - Enter all data - Continue)
	#Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Propane
	Given I should see the Ingredients Page
	Then In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	| component name | Propane       | 100     |                     |               |             |
	Then in the Ingredients page I click Continue

	Given I call Shared Step 57911 (Regulatory Information 1 - CEPA only shown - Continue - Happy Path)
	Then I should see the Pesticide Details - Canada Page
	Given I set the Provide Canada's 5-Digit Pest Control Number (PCN) or 8-Digit Drug Identification Number (DIN) for this product field to: 27925
	And The following options should be displayed for section: Product's packaging includes a Poison Danger symbol
		| Option |
		| Yes    |
		| No     |
	Given I set the Product's packaging includes a Poison Danger symbol option to: No
	Given I set the Alberta option to: Schedule 1
	Given I set the British Columbia option to: Commercial
	Given I set the Manitoba option to: Commercial
	Given I set the New Brunswick option to: None
	Given I set the New Foundland and Labrador option to: Domestic
	Given I set the Nova Scotia option to: Commercial
	Given I set the Ontario option to: Class A: Manufacturing Products
	Given I set the Prince Edward Island option to: Controlled Purchase
	Given I set the Quebec option to: Class 1
	Given I set the Saskatchewan option to: Commercial
	Given I set the Northwest Territory option to: Not Applicable 
	Given I set the Yukon Territory option to: Commercial
	Then I click continue
	Given I call Shared Step 57506 (Transportation Details 1 - Regulated for Transport(No) - Exemption(Random) - Continue - Happy Path)
	Given I call Shared Step 62536 (Transportation Details 2 > I do not ship internationally > Continue - Happy Path)
	And I call Shared Step 62710 (Confirm VOC OTC/CARB heading and select No to FIRST QUESTION ONLY - Happy Path)
	Then I click continue
	Given Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the CARB should be showing the error messages: This is a required field.
	And I set the Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the CARB option to: 50
	Then Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the CARB should should not be showing any error messages
	Then I click continue
	Then I should see the Volatile Organic Compound Summary Page
	Given I call Shared Step 57801 (Confirm VOC Summary step shown and VOC analysis date is shown - Happy Path)
	And I confirm that statement with text: 'Based on your selection, you have verified your product contains VOC with intended uses as follows.  The CARB VOC compliance limit(s) for the intended use you identified is/are:' is not displayed
	Then in the VOC Limits table, the Use column should contain the value: Personal Fragrance Product (20% or less fragrance) - Liquid
	Then in the VOC Limits table, the VOC Compliance Limit column should contain the value: 75
	Then in the VOC Limits table, the Regulation column should contain the value: CARB limit
	And I should see the following Voc percent for each state:
		| State           | Regulation            | VOC Value | State VOC Threshold | Message                          |
		| Canada          | State Allowable Limit | 0         | 75                  | Does not exceed the State Limits |
	Then I confirm that I see the following CARB value: 50
	Then The VOC Summary page contains the statement with the text: Based on the type of product, this must comply with the most restrictive VOC limit.
	Then The VOC Summary page contains the statement with the text: Does not exceed the limits specified in the California Consumer Products Regulation
	Given I set the Your acknowledgement of this registration includes that your product option to: Yes, I Acknowledge
	Given in the Volatile Organic Compound Summary page I click Continue
	Given I call Shared Step 150905 (Retailer - NR selected by default)
	Given I call Shared Step 78884 - Regulatory Documents to Provide - Canada only - request authoring, upload label - Continue
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	#And I call Shared Step 64097 - Additional Documents -> Contact Information - Add any Name, address, phone and emergency phone - Happy Path
	Then I should be on the Additional Documents -> Contact Information Page
	And In the Additional Documents -> Contact Information section, for section: 'Manufacturer Name' enter text: Manufacturer
	And In the Additional Documents -> Contact Information section, for section: 'Address' enter text: Address
	And In the Additional Documents -> Contact Information section, for section: 'Phone' enter text: Phone
	And In the Additional Documents -> Contact Information section, for section: 'Emergency Phone' enter text: Emergency Phone
	Then in the Additional Documents -> Contact Information page, I click Continue

	Given I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
		| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
	Given in the Optional Comments page I click Continue
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Personal Fragrance Product (20% or less fragrance) - Liquid
	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase207584
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase207584
