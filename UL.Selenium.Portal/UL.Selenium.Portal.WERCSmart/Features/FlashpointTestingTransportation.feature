@Shared
@LandingPage
@Login
@Homepage
@ForgottenPassword
@SupplierReports
@NewProduct
@RetailPartners
@wercsmart
@Signup
@ProductGrid
@run_FlashPointTestingMethodAndTransportation
@PhysicalAndChemicalProp
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:TransportationDetails1
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:ProductInformation
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:NewProduct
@Ingredients
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:InventoryStatusProp65
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:USDepartamentOfTransportationDOT
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:Retailer
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:RegulatoryDocumentsToProvide
@SafetyDataSheetAuthoring
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:OptionalComments
@StepsPrototype
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:TheProduct
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:TransportationDetails2

Feature: Flash Point, testing method and Transportation (Suite ID: 74116)

# Assigned to Beverly Barrett
# Created by Beverly Barrett
@TestCase:74337
Scenario: [74337] Flash Point < 60°C - Testing method shows closed cup only, Transportation shows Yes and No due to an exemption, Hazard class 3 must be used

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load

#And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
Then I click the Add Product icon in the Navigation Pane
Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
Then in the New Product page, I click Continue


#And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bleach
Then I should be on the The Product Page
And In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Bleach
And In the Product Section, set the option in section: 'Type of Product (select)' to: Bleach
Then in the The Product page, I click Continue

Given I generate a random UPC number and save as: UPC74337
Then I save the product information as: TestCase74337

#And I call Shared Step 74340 (Product Information - Pesticide= Not considered, SOLD=US, everything else = No - Continue)
Then I should be on the Product Information Page
And In the Product Information Section, set the option in section: 'Which best describes your product, including when FIFRA 25(b) Exempt' to: Product is not a pesticide and does not make or imply a pesticidal claim on the labeling or in the product description (ex. kills, sterilizes, disinfects, sanitizes, antimicrobial)
And In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
And In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
And In the Product Information Section, set the option in section: 'Cleaning products must comply with California's Cleaning Product Right to Know Act. I would like to provide the additional information needed for this program during registration.' to: No
And In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
And In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
Then in the Product Information page, I click Continue

#And I call Shared Step 74339 (Physical and Chemical Properties - Select Liquid and enter only Secondary state, Relative Density, pH)
Then I should be on the Physical and Chemical Properties Page
And In the Physical and Chemical Properties Section, set the option in section: 'Primary Physical State' to: Liquid
And In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Liquid
And In the Physical and Chemical Properties Section, for section: 'Relative Density' enter text: 20
And In the Physical and Chemical Properties Section, for section: 'pH' enter text: 7
And In the Physical and Chemical Properties Section, for section: 'Boiling Point (in Celsius)' enter text: 40
And In the Physical and Chemical Properties Section, for section: 'Flash Point (in Celsius)' enter text: 50
And In the Physical and Chemical Properties Section, for section: 'Flash Point Testing Method Used': the following options should be displayed exclusively:
| Option            |
| Closed cup method |
And In the Physical and Chemical Properties Section, set the option in section: 'Flash Point Testing Method Used' to: Closed cup method
And In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
Then in the Physical and Chemical Properties page, I click Continue

#And I call Shared Step 29181 (Ingredients - add any chemical) with name: Water
Then I should be on the Ingredients Page
And In the Ingredients section, add the following ingredients:
| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
| component name | Water       | 100     | False               | False         |             |
Then in the Ingredients page, I click Continue


#And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Then I should be on the Inventory Status, Prop 65 (US) Page
And In the Inventory Status, Prop 65 (US) Section, the following sections should only be displayed:
| Section                                                                                                                                                                   |
| U.S. Toxic Substances Control Act (TSCA) status                                                                                                                           |
| Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65) |
And In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
And In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
Then in the Inventory Status, Prop 65 (US) page, I click Continue

Then I should be on the Transportation Details 1 Page
And In the Transportation Details 1 Section, for section 'Product is Regulated for Transport': the following options should be displayed exclusively:
| Option                               |
| No, due to an exemption or exception |
And In the Transportation Details 1 Section, set the option in section: 'Product is Regulated for Transport': to: Yes
And In the Transportation Details 1 Section, set the option in section: 'Select all modes of transport that you've classified the product for': to: DOT
And In the Transportation Details 1 Section, set the option for DOT mode of transport to: Shipping fully regulated
Then in the Transportation Details 1 page, I click Continue


#And I call Shared Step 81310 (UN Number - enter UN1950 select Aerosol & Haz class, confirm Packing group - Continue)
Then I should be on the U. S. Department of Transportation (DOT) Classification Page
And In the U. S. Department of Transportation (DOT) Classification Section, set the option in section: 'UN Number': to: UN1950
And In the U. S. Department of Transportation (DOT) Classification Section, set the option in section: 'Proper Shipping Name': to: Aerosols
And In the U. S. Department of Transportation (DOT) Classification Section, set the option in section: 'Hazard Class': to: 2.1
And In the U. S. Department of Transportation (DOT) Classification Section, set the option in section: 'Packing Group': to: None
Then in the U. S. Department of Transportation (DOT) Classification page, I click Continue


#And section: UN Number is highlighed in red indicating an error
#And UN Number should be showing the error messages: The UN-Number (DOT) is invalid with the selected Hazard Class and Flash Point value.|The Flash Point (50C - less than or equal to 60C) must only be used with Hazard Class 3
And In the U. S. Department of Transportation (DOT) Classification Section, verify that the section: 'UN Number' is highlighted in red indicating an error
And In the U. S. Department of Transportation (DOT) Classification Section, the section: 'UN Number' should be showing error message: The UN-Number (DOT) is invalid with the selected Hazard Class and Flash Point value.|The Flash Point (50C - less than or equal to 60C) must only be used with Hazard Class 3


#And I call Shared Step 81311 (UN Number - enter UN1206 - confirm pre-populated select radio button - Continue)
And In the U. S. Department of Transportation (DOT) Classification Section, set the option in section: 'UN Number': to: UN1206
And In the U. S. Department of Transportation (DOT) Classification Section, verify section: 'Proper Shipping Name' contains value: Heptanes
And In the U. S. Department of Transportation (DOT) Classification Section, verify section: 'Hazard Class (select)' contains value: 3
And In the U. S. Department of Transportation (DOT) Classification Section, verify section: 'Packing Group (select)' contains value: II
Then in the U. S. Department of Transportation (DOT) Classification page, I click Continue

#new prototype step for error checks 
Then I should not see any error messages on the page

#And I You may see the Ecologo Readiness step depending on your subscription level - if the step is shown use the shared step below, if not skip to step 28
#review updates steps for bellow 
And If ECOLOGO Readiness page is displayed I call Shared Step 57712 - ECOLOGO Readiness Assessment - Not at this time - Continue - Happy Path

#And I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
Then I should be on the Retailer Page
And In the Retailer Section is selected retailer: No Retailer/No UPC Product
Then in the Retailer page, I click Continue


#And I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
Then I should be on the Regulatory Documents to Provide Page
And In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
Then in the Regulatory Documents to Provide page, I click Continue

And I should be on the Additional Documents to Provide Page
Then in the Additional Documents to Provide page, I click Continue
And I should be on the Optional Reports and Documents Available for Purchase Page
Then in the Optional Reports and Documents Available for Purchase page, I click Continue

#And I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
#| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
Then I should be on the Safety Data Sheet Authoring - Additional Data (Optional) Page
And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Personal Protection Equipment Recommended (select)' to: Gloves
And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Autoignition Temperature (°C)' enter text: 500
And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Minimum Ignition Energy (mJ)' enter text: 9
And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Viscosity' enter text: 12.0
And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Appearance' to: Black
And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor' to: Odorless
And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor Threshold' to: No data available
And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Partition Coefficient' enter text: 1
Then in the Safety Data Sheet Authoring - Additional Data (Optional) page, I click Continue


#And I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Test Comment
Then I should be on the Optional Comments Page
And In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: Test Comment
Then in the Optional Comments page, I click Continue


And I should be on the Data Acceptance Page
Given I click the Summary button in the Data Acceptance window
Then I switch to the Data Summary page
And I close the window that opened
And I navigate to the home page
And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase74337

# Assigned to Beverly Barrett
# Created by Beverly Barrett
@TestCase:74349
Scenario: [74349] Flash Point = 60°C - Testing method shows closed cup only, Transportation shows Yes and No due to an exemption, Hazard class 3 must be used

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load

#And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
Then I click the Add Product icon in the Navigation Pane
And In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
Then in the Add Product page, I click Continue

#And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bleach
Then I should be on the The Product Page
And In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Bleach
And In the Product Section, set the option in section: 'Type of Product (select)' to: Bleach
Then in the The Product page, I click Continue

Given I generate a random UPC number and save as: UPC74349
Then I save the product information as: TestCase74349

#And I call Shared Step 74340 (Product Information - Pesticide= Not considered, SOLD=US, everything else = No - Continue)
Then I should be on the Product Information Page
And In the Product Information Section, set the option in section: 'Which best describes your product, including when FIFRA 25(b) Exempt' to: Product is not a pesticide and does not make or imply a pesticidal claim on the labeling or in the product description (ex. kills, sterilizes, disinfects, sanitizes, antimicrobial)
And In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
And In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
And In the Product Information Section, set the option in section: 'Cleaning products must comply with California's Cleaning Product Right to Know Act. I would like to provide the additional information needed for this program during registration.' to: No
And In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
And In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
Then in the Product Information page, I click Continue

#And I call Shared Step 74339 (Physical and Chemical Properties - Select Liquid and enter only Secondary state, Relative Density, pH)
Then I should be on the Physical and Chemical Properties Page
And In the Physical and Chemical Properties Section, set the option in section: 'Primary Physical State' to: Liquid
And In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Liquid
And In the Physical and Chemical Properties Section, for section: 'Relative Density' enter text: 20
And In the Physical and Chemical Properties Section, for section: 'pH' enter text: 7
And In the Physical and Chemical Properties Section, for section: 'Boiling Point (in Celsius)' enter text: 38
And In the Physical and Chemical Properties Section, for section: 'Flash Point (in Celsius)' enter text: 60
And In the Physical and Chemical Properties Section, for section: 'Flash Point Testing Method Used': the following options should be displayed exclusively:
| Option            |
| Closed cup method |
And In the Physical and Chemical Properties Section, set the option in section: 'Flash Point Testing Method Used' to: Closed cup method
And In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
Then in the Physical and Chemical Properties page, I click Continue

#And I call Shared Step 29181 (Ingredients - add any chemical) with name: Water
Then I should be on the Ingredients Page
And In the Ingredients section, add the following ingredients:
| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
| component name | Water       | 100     | False               | False         |             |
Then in the Ingredients page, I click Continue

#And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Then I should be on the Inventory Status, Prop 65 (US) Page
And In the Inventory Status, Prop 65 (US) Section, the following sections should only be displayed:
| Section                                                                                                                                                                   |
| U.S. Toxic Substances Control Act (TSCA) status                                                                                                                           |
| Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65) |
And In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
And In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
Then in the Inventory Status, Prop 65 (US) page, I click Continue

Then I should be on the Transportation Details 1 Page
And In the Transportation Details 1 Section, for section 'Product is Regulated for Transport': the following options should be displayed exclusively:
| Option                               |
| No, due to an exemption or exception |
And In the Transportation Details 1 Section, set the option in section: 'Product is Regulated for Transport': to: Yes
And In the Transportation Details 1 Section, set the option in section: 'Select all modes of transport that you've classified the product for': to: DOT
And In the Transportation Details 1 Section, set the option for DOT mode of transport to: Shipping fully regulated
Then in the Transportation Details 1 page, I click Continue

#And I call Shared Step 81310 (UN Number - enter UN1950 select Aerosol & Haz class, confirm Packing group - Continue)
Then I should be on the U. S. Department of Transportation (DOT) Classification Page
And In the U. S. Department of Transportation (DOT) Classification Section, set the option in section: 'UN Number': to: UN1950
And In the U. S. Department of Transportation (DOT) Classification Section, set the option in section: 'Proper Shipping Name': to: Aerosols
And In the U. S. Department of Transportation (DOT) Classification Section, set the option in section: 'Hazard Class': to: 2.1
And In the U. S. Department of Transportation (DOT) Classification Section, set the option in section: 'Packing Group': to: None
Then in the U. S. Department of Transportation (DOT) Classification page, I click Continue

#And section: UN Number is highlighed in red indicating an error
#And UN Number should be showing the error messages: The UN-Number (DOT) is invalid with the selected Hazard Class and Flash Point value.|The Flash Point (50C - less than or equal to 60C) must only be used with Hazard Class 3
And In the U. S. Department of Transportation (DOT) Classification Section, verify that the section: 'UN Number' is highlighted in red indicating an error
And In the U. S. Department of Transportation (DOT) Classification Section, the section: 'UN Number' should be showing error message: The UN-Number (DOT) is invalid with the selected Hazard Class and Flash Point value.|The Flash Point (50C - less than or equal to 60C) must only be used with Hazard Class 3


#And I call Shared Step 81311 (UN Number - enter UN1206 - confirm pre-populated select radio button - Continue)
And In the U. S. Department of Transportation (DOT) Classification Section, set the option in section: 'UN Number': to: UN1206
And In the U. S. Department of Transportation (DOT) Classification Section, verify section: 'Proper Shipping Name' contains value: Heptanes
And In the U. S. Department of Transportation (DOT) Classification Section, verify section: 'Hazard Class (select)' contains value: 3
And In the U. S. Department of Transportation (DOT) Classification Section, verify section: 'Packing Group (select)' contains value: II
Then in the U. S. Department of Transportation (DOT) Classification page, I click Continue

And I should not see any error messages on the page

#And I You may see the Ecologo Readiness step depending on your subscription level - if the step is shown use the shared step below, if not skip to step 28
#review updates steps for bellow 
And If ECOLOGO Readiness page is displayed I call Shared Step 57712 - ECOLOGO Readiness Assessment - Not at this time - Continue - Happy Path

#And I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
Then I should be on the Retailer Page
And In the Retailer Section is selected retailer: No Retailer/No UPC Product
Then in the Retailer page, I click Continue

#And I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
Then I should be on the Regulatory Documents to Provide Page
And In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
Then in the Regulatory Documents to Provide page, I click Continue

And I should be on the Additional Documents to Provide Page
Then in the Additional Documents to Provide page, I click Continue
And I should be on the Optional Reports and Documents Available for Purchase Page
Then in the Optional Reports and Documents Available for Purchase page, I click Continue

#And I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
#| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
Then I should be on the Safety Data Sheet Authoring - Additional Data (Optional) Page
And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Personal Protection Equipment Recommended (select)' to: Gloves
And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Autoignition Temperature (°C)' enter text: 500
And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Minimum Ignition Energy (mJ)' enter text: 9
And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Viscosity' enter text: 12.0
And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Appearance' to: Black
And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor' to: Odorless
And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor Threshold' to: No data available
And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Partition Coefficient' enter text: 1
Then in the Safety Data Sheet Authoring - Additional Data (Optional) page, I click Continue

#And I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Test Comment
Then I should be on the Optional Comments Page
And In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: Test Comment
Then in the Optional Comments page, I click Continue

And I should see the Data Acceptance Page
Given I click the Summary button in the Data Acceptance window
Then I switch to the Data Summary page
And I close the window that opened
And I navigate to the home page
And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase74349


# Assigned to Beverly Barrett
# Created by Beverly Barrett
@TestCase:74357
Scenario: [74357] Flash Point < 60°C - Testing method shows closed cup only, Transportation select No due to an exemption
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load

#And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
Then I click the Add Product icon in the Navigation Pane
Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration

#And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bleach
Then I should be on the The Product Page
And In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Bleach
And In the Product Section, set the option in section: 'Type of Product (select)' to: Bleach
Then in the The Product page, I click Continue

Given I generate a random UPC number and save as: UPC74357
Then I save the product information as: TestCase74357

#And I call Shared Step 74340 (Product Information - Pesticide= Not considered, SOLD=US, everything else = No - Continue)
Then I should be on the Product Information Page
And In the Product Information Section, set the option in section: 'Which best describes your product, including when FIFRA 25(b) Exempt' to: Product is not a pesticide and does not make or imply a pesticidal claim on the labeling or in the product description (ex. kills, sterilizes, disinfects, sanitizes, antimicrobial)
And In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
And In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
And In the Product Information Section, set the option in section: 'Cleaning products must comply with California's Cleaning Product Right to Know Act. I would like to provide the additional information needed for this program during registration.' to: No
And In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
And In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
Then in the Product Information page, I click Continue

#And I call Shared Step 74339 (Physical and Chemical Properties - Select Liquid and enter only Secondary state, Relative Density, pH)
Then I should be on the Physical and Chemical Properties Page
And In the Physical and Chemical Properties Section, set the option in section: 'Primary Physical State' to: Liquid
And In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Liquid
And In the Physical and Chemical Properties Section, for section: 'Relative Density' enter text: 20
And In the Physical and Chemical Properties Section, for section: 'pH' enter text: 7
And In the Physical and Chemical Properties Section, for section: 'Boiling Point (in Celsius)' enter text: 40
And In the Physical and Chemical Properties Section, for section: 'Flash Point (in Celsius)' enter text: 50
And In the Physical and Chemical Properties Section, for section: 'Flash Point Testing Method Used': the following options should be displayed exclusively:
| Option            |
| Closed cup method |
And In the Physical and Chemical Properties Section, set the option in section: 'Flash Point Testing Method Used' to: Closed cup method
And In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
Then in the Physical and Chemical Properties page, I click Continue

#And I call Shared Step 29181 (Ingredients - add any chemical) with name: Water
Then I should be on the Ingredients Page
And In the Ingredients section, add the following ingredients:
| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
| component name | Water       | 100     | False               | False         |             |
Then in the Ingredients page, I click Continue

#And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Then I should be on the Inventory Status, Prop 65 (US) Page
And In the Inventory Status, Prop 65 (US) Section, the following sections should only be displayed:
| Section                                                                                                                                                                   |
| U.S. Toxic Substances Control Act (TSCA) status                                                                                                                           |
| Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65) |
And In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
And In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
Then in the Inventory Status, Prop 65 (US) page, I click Continue

Then I should be on the Transportation Details 1 Page
And In the Transportation Details 1 Section, for section 'Product is Regulated for Transport': the following options should be displayed exclusively:
| Option                               |
| Yes                                  |
| No, due to an exemption or exception |
And In the Transportation Details 1 Section, set the option in section: 'Product is Regulated for Transport': to: No, due to an exemption or exception
And In the Transportation Details 1 Section, set the option in section: 'Please select DOT Exceptions if applicable?': to: 173.120(a)(2)
Then in the Transportation Details 1 page, I click Continue


#And I call Shared Step 62536 (Transportation Details 2 > I do not ship internationally > Continue - Happy Path)
Then I should be on the Transportation Details 2 Page
And In the Transportation Details 2 Section, set the option in section: 'International Shipping when DOT Exemption taken?': to: I do not ship internationally and I do not know the classification
Then in the Transportation Details 2 page, I click Continue

#And I You may see the Ecologo Readiness step depending on your subscription level - if the step is shown use the shared step below, if not skip to step 23
And If ECOLOGO Readiness page is displayed I call Shared Step 57712 - ECOLOGO Readiness Assessment - Not at this time - Continue - Happy Path

#And I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
Then I should be on the Retailer Page
And In the Retailer Section is selected retailer: No Retailer/No UPC Product
Then in the Retailer page, I click Continue

#And I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
Then I should be on the Regulatory Documents to Provide Page
And In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
Then in the Regulatory Documents to Provide page, I click Continue

And I should be on the Additional Documents to Provide Page
Then in the Additional Documents to Provide page, I click Continue
And I should be on the Optional Reports and Documents Available for Purchase Page
Then in the Optional Reports and Documents Available for Purchase page, I click Continue

#And I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
#| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
Then I should be on the Safety Data Sheet Authoring - Additional Data (Optional) Page
And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Personal Protection Equipment Recommended (select)' to: Gloves
And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Autoignition Temperature (°C)' enter text: 800
And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Minimum Ignition Energy (mJ)' enter text: 25
And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Viscosity' enter text: 11.0
And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Appearance' to: Black
And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor' to: Odorless
And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor Threshold' to: No data available
And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Partition Coefficient' enter text: 1
Then in the Safety Data Sheet Authoring - Additional Data (Optional) page, I click Continue

#And I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Test Comment
Then I should be on the Optional Comments Page
And In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: Test Comment
Then in the Optional Comments page, I click Continue

And I should see the Data Acceptance Page
Given I click the Summary button in the Data Acceptance window
Then I switch to the Data Summary page
And I close the window that opened
And I navigate to the home page
And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase74357

# Assigned to Beverly Barrett
# Created by Beverly Barrett
@TestCase:74346
Scenario: [74346] Flash Point > 60°C - Testing method shows all, Transportation shows all, Hazard class 3 must NOT be used
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load

#And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
Then I click the Add Product icon in the Navigation Pane
Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration

#And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bleach
Then I should be on the The Product Page
And In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Bleach
And In the Product Section, set the option in section: 'Type of Product (select)' to: Bleach
Then in the The Product page, I click Continue

Given I generate a random UPC number and save as: UPC74346
Then I save the product information as: TestCase74346

#And I call Shared Step 74340 (Product Information - Pesticide= Not considered, SOLD=US, everything else = No - Continue)
Then I should be on the Product Information Page
And In the Product Information Section, set the option in section: 'Which best describes your product, including when FIFRA 25(b) Exempt' to: Product is not a pesticide and does not make or imply a pesticidal claim on the labeling or in the product description (ex. kills, sterilizes, disinfects, sanitizes, antimicrobial)
And In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
And In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
And In the Product Information Section, set the option in section: 'Cleaning products must comply with California's Cleaning Product Right to Know Act. I would like to provide the additional information needed for this program during registration.' to: No
And In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
And In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
Then in the Product Information page, I click Continue

#And I call Shared Step 74339 (Physical and Chemical Properties - Select Liquid and enter only Secondary state, Relative Density, pH)
Then I should be on the Physical and Chemical Properties Page
And In the Physical and Chemical Properties Section, set the option in section: 'Primary Physical State' to: Liquid
And In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Liquid
And In the Physical and Chemical Properties Section, for section: 'Relative Density' enter text: 20
And In the Physical and Chemical Properties Section, for section: 'pH' enter text: 7
And In the Physical and Chemical Properties Section, for section: 'Boiling Point (in Celsius)' enter text: 50
And In the Physical and Chemical Properties Section, for section: 'Flash Point (in Celsius)' enter text: 80
And In the Physical and Chemical Properties Section, for section: 'Flash Point Testing Method Used': the following options should be displayed exclusively:
| Option                   |
| Closed cup method        |
| Open cup method          |
| Not applicable/available |
And In the Physical and Chemical Properties Section, set the option in section: 'Flash Point Testing Method Used' to: Open cup method
And In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
Then in the Physical and Chemical Properties page, I click Continue

#And I call Shared Step 29181 (Ingredients - add any chemical) with name: Water
Then I should be on the Ingredients Page
And In the Ingredients section, add the following ingredients:
| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
| component name | Water       | 100     | False               | False         |             |
Then in the Ingredients page, I click Continue

#And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Then I should be on the Inventory Status, Prop 65 (US) Page
And In the Inventory Status, Prop 65 (US) Section, the following sections should only be displayed:
| Section                                                                                                                                                                   |
| U.S. Toxic Substances Control Act (TSCA) status                                                                                                                           |
| Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65) |
And In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
And In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
Then in the Inventory Status, Prop 65 (US) page, I click Continue

Then I should be on the Transportation Details 1 Page
And In the Transportation Details 1 Section, for section 'Product is Regulated for Transport': the following options should be displayed exclusively:
| Option                               |
| Yes                                  |
| No, due to an exemption or exception |
| Not Regulated                        |
And In the Transportation Details 1 Section, set the option in section: 'Product is Regulated for Transport': to: Yes
And In the Transportation Details 1 Section, set the option in section: 'Select all modes of transport that you've classified the product for': to: DOT
And In the Transportation Details 1 Section, set the option for DOT mode of transport to: Shipping fully regulated
Then in the Transportation Details 1 page, I click Continue

#And I call Shared Step 81311 (UN Number - enter UN1206 - confirm pre-populated select radio button - Continue)
And In the U. S. Department of Transportation (DOT) Classification Section, set the option in section: 'UN Number': to: UN1206
And In the U. S. Department of Transportation (DOT) Classification Section, verify section: 'Proper Shipping Name' contains value: Heptanes
And In the U. S. Department of Transportation (DOT) Classification Section, verify section: 'Hazard Class (select)' contains value: 3
And In the U. S. Department of Transportation (DOT) Classification Section, verify section: 'Packing Group (select)' contains value: II
Then in the U. S. Department of Transportation (DOT) Classification page, I click Continue

#And section: UN Number is highlighed in red indicating an error
#And UN Number should be showing the error messages: The UN-Number (DOT) is invalid with the selected Hazard Class and Flash Point value.|The Flash Point (50C - less than or equal to 60C) must only be used with Hazard Class 3
And In the U. S. Department of Transportation (DOT) Classification Section, verify that the section: 'UN Number' is highlighted in red indicating an error
And In the U. S. Department of Transportation (DOT) Classification Section, the section: 'UN Number' should be showing error message: The UN-Number (DOT) is invalid with the selected Hazard Class and Flash Point value.|The Flash Point (80C - greater than 60C) must not be used with Hazard Class 3

#And I call Shared Step 81310 (UN Number - enter UN1950 select Aerosol & Haz class, confirm Packing group - Continue)
Then I should be on the U. S. Department of Transportation (DOT) Classification Page
And In the U. S. Department of Transportation (DOT) Classification Section, set the option in section: 'UN Number': to: UN1950
And In the U. S. Department of Transportation (DOT) Classification Section, set the option in section: 'Proper Shipping Name': to: Aerosols
And In the U. S. Department of Transportation (DOT) Classification Section, set the option in section: 'Hazard Class': to: 2.1
And In the U. S. Department of Transportation (DOT) Classification Section, set the option in section: 'Packing Group': to: None
Then in the U. S. Department of Transportation (DOT) Classification page, I click Continue


And I should not see any error messages on the page

#And I You may see the Ecologo Readiness step depending on your subscription level - if the step is shown use the shared step below, if not skip to step 28
And If ECOLOGO Readiness page is displayed I call Shared Step 57712 - ECOLOGO Readiness Assessment - Not at this time - Continue - Happy Path

#And I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
Then I should be on the Retailer Page
And In the Retailer Section is selected retailer: No Retailer/No UPC Product
Then in the Retailer page, I click Continue

#And I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
Then I should be on the Regulatory Documents to Provide Page
And In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
Then in the Regulatory Documents to Provide page, I click Continue

And I should be on the Additional Documents to Provide Page
Then in the Additional Documents to Provide page, I click Continue
And I should be on the Optional Reports and Documents Available for Purchase Page
Then in the Optional Reports and Documents Available for Purchase page, I click Continue

#And I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
#| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
Then I should be on the Safety Data Sheet Authoring - Additional Data (Optional) Page
And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Personal Protection Equipment Recommended (select)' to: Gloves
And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Autoignition Temperature (°C)' enter text: 800
And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Minimum Ignition Energy (mJ)' enter text: 25
And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Viscosity' enter text: 11.0
And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Appearance' to: Black
And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor' to: Odorless
And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor Threshold' to: No data available
And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Partition Coefficient' enter text: 1
Then in the Safety Data Sheet Authoring - Additional Data (Optional) page, I click Continue

#And I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Test Comment
Then I should be on the Optional Comments Page
And In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: Test Comment
Then in the Optional Comments page, I click Continue

And I should see the Data Acceptance Page
Given I click the Summary button in the Data Acceptance window
Then I switch to the Data Summary page
And I close the window that opened
And I navigate to the home page
And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase74346

# Assigned to Beverly Barrett
# Created by Beverly Barrett

@TestCase:74364
Scenario: [74364] Flash Point > 60°C - Testing method shows all, Transportation shows all, Hazard class 3 must NOT be used
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load

#And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
Then I click the Add Product icon in the Navigation Pane
Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration

#And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bleach
Then I should be on the The Product Page
And In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Bleach
And In the Product Section, set the option in section: 'Type of Product (select)' to: Bleach
Then in the The Product page, I click Continue
Given I generate a random UPC number and save as: UPC74364
Then I save the product information as: TestCase74364

#And I call Shared Step 74340 (Product Information - Pesticide= Not considered, SOLD=US, everything else = No - Continue)
Then I should be on the Product Information Page
And In the Product Information Section, set the option in section: 'Which best describes your product, including when FIFRA 25(b) Exempt' to: Product is not a pesticide and does not make or imply a pesticidal claim on the labeling or in the product description (ex. kills, sterilizes, disinfects, sanitizes, antimicrobial)
And In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
And In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
And In the Product Information Section, set the option in section: 'Cleaning products must comply with California's Cleaning Product Right to Know Act. I would like to provide the additional information needed for this program during registration.' to: No
And In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
And In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
Then in the Product Information page, I click Continue

#And I call Shared Step 74339 (Physical and Chemical Properties - Select Liquid and enter only Secondary state, Relative Density, pH)
Then I should be on the Physical and Chemical Properties Page
And In the Physical and Chemical Properties Section, set the option in section: 'Primary Physical State' to: Liquid
And In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Liquid
And In the Physical and Chemical Properties Section, for section: 'Relative Density' enter text: 20
And In the Physical and Chemical Properties Section, for section: 'pH' enter text: 7
And In the Physical and Chemical Properties Section, for section: 'Boiling Point (in Celsius)' enter text: 50
And In the Physical and Chemical Properties Section, for section: 'Flash Point (in Celsius)' enter text: 80
And In the Physical and Chemical Properties Section, for section: 'Flash Point Testing Method Used': the following options should be displayed exclusively:
| Option                   |
| Closed cup method        |
| Open cup method          |
| Not applicable/available |
And In the Physical and Chemical Properties Section, set the option in section: 'Flash Point Testing Method Used' to: Closed cup method
And In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Insoluble in water
Then in the Physical and Chemical Properties page, I click Continue

#And I call Shared Step 29181 (Ingredients - add any chemical) with name: Water
Then I should be on the Ingredients Page
And In the Ingredients section, add the following ingredients:
| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
| component name | Water       | 100     | False               | False         |             |
Then in the Ingredients page, I click Continue

#And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Then I should be on the Inventory Status, Prop 65 (US) Page
And In the Inventory Status, Prop 65 (US) Section, the following sections should only be displayed:
| Section                                                                                                                                                                   |
| U.S. Toxic Substances Control Act (TSCA) status                                                                                                                           |
| Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65) |
And In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
And In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
Then in the Inventory Status, Prop 65 (US) page, I click Continue

Then I should be on the Transportation Details 1 Page
And In the Transportation Details 1 Section, for section 'Product is Regulated for Transport': the following options should be displayed exclusively:
| Option                               |
| Yes                                  |
| No, due to an exemption or exception |
| Not Regulated                        |
And In the Transportation Details 1 Section, set the option in section: 'Product is Regulated for Transport': to: Yes
And In the Transportation Details 1 Section, set the option in section: 'Select all modes of transport that you've classified the product for': to: DOT
And In the Transportation Details 1 Section, set the option for DOT mode of transport to: Shipping fully regulated
Then in the Transportation Details 1 page, I click Continue

#And I call Shared Step 81311 (UN Number - enter UN1206 - confirm pre-populated select radio button - Continue)
And In the U. S. Department of Transportation (DOT) Classification Section, set the option in section: 'UN Number': to: UN1206
And In the U. S. Department of Transportation (DOT) Classification Section, verify section: 'Proper Shipping Name' contains value: Heptanes
And In the U. S. Department of Transportation (DOT) Classification Section, verify section: 'Hazard Class (select)' contains value: 3
And In the U. S. Department of Transportation (DOT) Classification Section, verify section: 'Packing Group (select)' contains value: II
Then in the U. S. Department of Transportation (DOT) Classification page, I click Continue


#And section: UN Number is highlighed in red indicating an error
#And UN Number should be showing the error messages: The UN-Number (DOT) is invalid with the selected Hazard Class and Flash Point value.|The Flash Point (50C - less than or equal to 60C) must only be used with Hazard Class 3
And In the U. S. Department of Transportation (DOT) Classification Section, verify that the section: 'UN Number' is highlighted in red indicating an error
And In the U. S. Department of Transportation (DOT) Classification Section, the section: 'UN Number' should be showing error message: The UN-Number (DOT) is invalid with the selected Hazard Class and Flash Point value.|The Flash Point (80C - greater than 60C) must not be used with Hazard Class 3

#And I call Shared Step 81310 (UN Number - enter UN1950 select Aerosol & Haz class, confirm Packing group - Continue)
Then I should be on the U. S. Department of Transportation (DOT) Classification Page
And In the U. S. Department of Transportation (DOT) Classification Section, set the option in section: 'UN Number': to: UN1950
And In the U. S. Department of Transportation (DOT) Classification Section, set the option in section: 'Proper Shipping Name': to: Aerosols
And In the U. S. Department of Transportation (DOT) Classification Section, set the option in section: 'Hazard Class': to: 2.1
And In the U. S. Department of Transportation (DOT) Classification Section, set the option in section: 'Packing Group': to: None
Then in the U. S. Department of Transportation (DOT) Classification page, I click Continue


And I should not see any error messages on the page

#And I You may see the Ecologo Readiness step depending on your subscription level - if the step is shown use the shared step below, if not skip to step 28
And If ECOLOGO Readiness page is displayed I call Shared Step 57712 - ECOLOGO Readiness Assessment - Not at this time - Continue - Happy Path

#And I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
Then I should be on the Retailer Page
And In the Retailer Section is selected retailer: No Retailer/No UPC Product
Then in the Retailer page, I click Continue

#And I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
Then I should be on the Regulatory Documents to Provide Page
And In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
Then in the Regulatory Documents to Provide page, I click Continue

And I should be on the Additional Documents to Provide Page
Then in the Additional Documents to Provide page, I click Continue
And I should be on the Optional Reports and Documents Available for Purchase Page
Then in the Optional Reports and Documents Available for Purchase page, I click Continue

#And I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
#| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
Then I should be on the Safety Data Sheet Authoring - Additional Data (Optional) Page
And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Personal Protection Equipment Recommended (select)' to: Gloves
And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Autoignition Temperature (°C)' enter text: 800
And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Minimum Ignition Energy (mJ)' enter text: 25
And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Viscosity' enter text: 11.0
And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Appearance' to: Black
And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor' to: Odorless
And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor Threshold' to: No data available
And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Partition Coefficient' enter text: 1
Then in the Safety Data Sheet Authoring - Additional Data (Optional) page, I click Continue

#And I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Test Comment
Then I should be on the Optional Comments Page
And In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: Test Comment 74346
Then in the Optional Comments page, I click Continue

And I should see the Data Acceptance Page
Given I click the Summary button in the Data Acceptance window
Then I switch to the Data Summary page
And I close the window that opened
And I navigate to the home page
And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase74364

# Assigned to Beverly Barrett
# Created by Beverly Barrett

@TestCase:74365
Scenario: [74365] Flash Point > 60°C - Testing method shows all, Transportation shows all, Hazard class 3 must NOT be used
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load

#And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
Then I click the Add Product icon in the Navigation Pane
Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration

#And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bleach
Then I should be on the The Product Page
And In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Bleach
And In the Product Section, set the option in section: 'Type of Product (select)' to: Bleach
Then in the The Product page, I click Continue
Given I generate a random UPC number and save as: UPC74365
Then I save the product information as: TestCase74365

#And I call Shared Step 74340 (Product Information - Pesticide= Not considered, SOLD=US, everything else = No - Continue)
Then I should be on the Product Information Page
And In the Product Information Section, set the option in section: 'Which best describes your product, including when FIFRA 25(b) Exempt' to: Product is not a pesticide and does not make or imply a pesticidal claim on the labeling or in the product description (ex. kills, sterilizes, disinfects, sanitizes, antimicrobial)
And In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
And In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
And In the Product Information Section, set the option in section: 'Cleaning products must comply with California's Cleaning Product Right to Know Act. I would like to provide the additional information needed for this program during registration.' to: No
And In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
And In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
Then in the Product Information page, I click Continue

#And I call Shared Step 74339 (Physical and Chemical Properties - Select Liquid and enter only Secondary state, Relative Density, pH)
Then I should be on the Physical and Chemical Properties Page
And In the Physical and Chemical Properties Section, set the option in section: 'Primary Physical State' to: Liquid
And In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Liquid
And In the Physical and Chemical Properties Section, for section: 'Relative Density' enter text: 20
And In the Physical and Chemical Properties Section, for section: 'pH' enter text: 7
And In the Physical and Chemical Properties Section, for section: 'Boiling Point (in Celsius)' enter text: 50
And In the Physical and Chemical Properties Section, for section: 'Flash Point (in Celsius)' enter text: 80
And In the Physical and Chemical Properties Section, for section: 'Flash Point Testing Method Used': the following options should be displayed exclusively:
| Option                   |
| Closed cup method        |
| Open cup method          |
| Not applicable/available |
And In the Physical and Chemical Properties Section, set the option in section: 'Flash Point Testing Method Used' to: Not applicable/available
And In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Insoluble in water
Then in the Physical and Chemical Properties page, I click Continue

#And I call Shared Step 29181 (Ingredients - add any chemical) with name: Water
Then I should be on the Ingredients Page
And In the Ingredients section, add the following ingredients:
| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
| component name | Water       | 100     | False               | False         |             |
Then in the Ingredients page, I click Continue

#And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Then I should be on the Inventory Status, Prop 65 (US) Page
And In the Inventory Status, Prop 65 (US) Section, the following sections should only be displayed:
| Section                                                                                                                                                                   |
| U.S. Toxic Substances Control Act (TSCA) status                                                                                                                           |
| Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65) |
And In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
And In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
Then in the Inventory Status, Prop 65 (US) page, I click Continue

Then I should be on the Transportation Details 1 Page
And In the Transportation Details 1 Section, for section 'Product is Regulated for Transport': the following options should be displayed exclusively:
| Option                               |
| Yes                                  |
| No, due to an exemption or exception |
| Not Regulated                        |
And In the Transportation Details 1 Section, set the option in section: 'Product is Regulated for Transport': to: Yes
And In the Transportation Details 1 Section, set the option in section: 'Select all modes of transport that you've classified the product for': to: DOT
And In the Transportation Details 1 Section, set the option for DOT mode of transport to: Shipping fully regulated
Then in the Transportation Details 1 page, I click Continue

#And I call Shared Step 81311 (UN Number - enter UN1206 - confirm pre-populated select radio button - Continue)
And In the U. S. Department of Transportation (DOT) Classification Section, set the option in section: 'UN Number': to: UN1206
And In the U. S. Department of Transportation (DOT) Classification Section, verify section: 'Proper Shipping Name' contains value: Heptanes
And In the U. S. Department of Transportation (DOT) Classification Section, verify section: 'Hazard Class (select)' contains value: 3
And In the U. S. Department of Transportation (DOT) Classification Section, verify section: 'Packing Group (select)' contains value: II
Then in the U. S. Department of Transportation (DOT) Classification page, I click Continue


#And section: UN Number is highlighed in red indicating an error
#And UN Number should be showing the error messages: The UN-Number (DOT) is invalid with the selected Hazard Class and Flash Point value.|The Flash Point (50C - less than or equal to 60C) must only be used with Hazard Class 3
And In the U. S. Department of Transportation (DOT) Classification Section, verify that the section: 'UN Number' is highlighted in red indicating an error
And In the U. S. Department of Transportation (DOT) Classification Section, the section: 'UN Number' should be showing error message: Flash Point is required with Hazard Class 3

#And I call Shared Step 81310 (UN Number - enter UN1950 select Aerosol & Haz class, confirm Packing group - Continue)
Then I should be on the U. S. Department of Transportation (DOT) Classification Page
And In the U. S. Department of Transportation (DOT) Classification Section, set the option in section: 'UN Number': to: UN1950
And In the U. S. Department of Transportation (DOT) Classification Section, set the option in section: 'Proper Shipping Name': to: Aerosols
And In the U. S. Department of Transportation (DOT) Classification Section, set the option in section: 'Hazard Class': to: 2.1
And In the U. S. Department of Transportation (DOT) Classification Section, set the option in section: 'Packing Group': to: None
Then in the U. S. Department of Transportation (DOT) Classification page, I click Continue


And I should not see any error messages on the page

#And I You may see the Ecologo Readiness step depending on your subscription level - if the step is shown use the shared step below, if not skip to step 28
And If ECOLOGO Readiness page is displayed I call Shared Step 57712 - ECOLOGO Readiness Assessment - Not at this time - Continue - Happy Path

#And I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
Then I should be on the Retailer Page
And In the Retailer Section is selected retailer: No Retailer/No UPC Product
Then in the Retailer page, I click Continue

#And I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
Then I should be on the Regulatory Documents to Provide Page
And In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
Then in the Regulatory Documents to Provide page, I click Continue

And I should be on the Additional Documents to Provide Page
Then in the Additional Documents to Provide page, I click Continue
And I should be on the Optional Reports and Documents Available for Purchase Page
Then in the Optional Reports and Documents Available for Purchase page, I click Continue

#And I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
#| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
Then I should be on the Safety Data Sheet Authoring - Additional Data (Optional) Page
And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Personal Protection Equipment Recommended (select)' to: Gloves
And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Autoignition Temperature (°C)' enter text: 500
And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Minimum Ignition Energy (mJ)' enter text: 9
And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Viscosity' enter text: 12.0
And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Appearance' to: Black
And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor' to: Odorless
And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor Threshold' to: No data available
And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Partition Coefficient' enter text: 1
Then in the Safety Data Sheet Authoring - Additional Data (Optional) page, I click Continue

#And I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Test Comment
Then I should be on the Optional Comments Page
And In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: Test Comment
Then in the Optional Comments page, I click Continue

And I should see the Data Acceptance Page
Given I click the Summary button in the Data Acceptance window
Then I switch to the Data Summary page
And I close the window that opened
And I navigate to the home page
And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase74365

# Assigned to Beverly Barrett
# Created by Beverly Barrett

@TestCase:74366
Scenario: [74366] Flash Point = 60°C - Testing method shows closed cup only, Transportation select No due to an exemption
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load

#And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
Then I click the Add Product icon in the Navigation Pane
Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration

#And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bleach
Then I should be on the The Product Page
And In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Bleach
And In the Product Section, set the option in section: 'Type of Product (select)' to: Bleach
Then in the The Product page, I click Continue
Given I generate a random UPC number and save as: UPC74366
Then I save the product information as: TestCase74366

#And I call Shared Step 74340 (Product Information - Pesticide= Not considered, SOLD=US, everything else = No - Continue)
Then I should be on the Product Information Page
And In the Product Information Section, set the option in section: 'Which best describes your product, including when FIFRA 25(b) Exempt' to: Product is not a pesticide and does not make or imply a pesticidal claim on the labeling or in the product description (ex. kills, sterilizes, disinfects, sanitizes, antimicrobial)
And In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
And In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
And In the Product Information Section, set the option in section: 'Cleaning products must comply with California's Cleaning Product Right to Know Act. I would like to provide the additional information needed for this program during registration.' to: No
And In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
And In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
Then in the Product Information page, I click Continue

#And I call Shared Step 74339 (Physical and Chemical Properties - Select Liquid and enter only Secondary state, Relative Density, pH)
Then I should be on the Physical and Chemical Properties Page
And In the Physical and Chemical Properties Section, set the option in section: 'Primary Physical State' to: Liquid
And In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Liquid
And In the Physical and Chemical Properties Section, for section: 'Relative Density' enter text: 20
And In the Physical and Chemical Properties Section, for section: 'pH' enter text: 7
And In the Physical and Chemical Properties Section, for section: 'Boiling Point (in Celsius)' enter text: 45
And In the Physical and Chemical Properties Section, for section: 'Flash Point (in Celsius)' enter text: 60
And In the Physical and Chemical Properties Section, for section: 'Flash Point Testing Method Used': the following options should be displayed exclusively:
| Option            |
| Closed cup method |
And In the Physical and Chemical Properties Section, set the option in section: 'Flash Point Testing Method Used' to: Closed cup method
And In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Insoluble in water
Then in the Physical and Chemical Properties page, I click Continue

#And I call Shared Step 29181 (Ingredients - add any chemical) with name: Water
Then I should be on the Ingredients Page
And In the Ingredients section, add the following ingredients:
| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
| component name | Water       | 100     | False               | False         |             |
Then in the Ingredients page, I click Continue

#And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Then I should be on the Inventory Status, Prop 65 (US) Page
And In the Inventory Status, Prop 65 (US) Section, the following sections should only be displayed:
| Section                                                                                                                                                                   |
| U.S. Toxic Substances Control Act (TSCA) status                                                                                                                           |
| Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65) |
And In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
And In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
Then in the Inventory Status, Prop 65 (US) page, I click Continue

Then I should be on the Transportation Details 1 Page
And In the Transportation Details 1 Section, for section 'Product is Regulated for Transport': the following options should be displayed exclusively:
| Option                               |
| Yes                                  |
| No, due to an exemption or exception |
And In the Transportation Details 1 Section, set the option in section: 'Product is Regulated for Transport': to: No, due to an exemption or exception
And In the Transportation Details 1 Section, set the option in section: 'Please select DOT Exceptions if applicable?': to: 173.120(a)(2)
Then in the Transportation Details 1 page, I click Continue

#And I call Shared Step 62536 (Transportation Details 2 > I do not ship internationally > Continue - Happy Path)
Then I should be on the Transportation Details 2 Page
And In the Transportation Details 2 Section, set the option in section: 'International Shipping when DOT Exemption taken?': to: I do not ship internationally and I do not know the classification
Then in the Transportation Details 2 page, I click Continue

And I should not see any error messages on the page

#And I You may see the Ecologo Readiness step depending on your subscription level - if the step is shown use the shared step below, if not skip to step 24
And If ECOLOGO Readiness page is displayed I call Shared Step 57712 - ECOLOGO Readiness Assessment - Not at this time - Continue - Happy Path

#And I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
Then I should be on the Retailer Page
And In the Retailer Section is selected retailer: No Retailer/No UPC Product
Then in the Retailer page, I click Continue

#And I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
Then I should be on the Regulatory Documents to Provide Page
And In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
Then in the Regulatory Documents to Provide page, I click Continue

And I should be on the Additional Documents to Provide Page
Then in the Additional Documents to Provide page, I click Continue
And I should be on the Optional Reports and Documents Available for Purchase Page
Then in the Optional Reports and Documents Available for Purchase page, I click Continue

#And I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
#| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
Then I should be on the Safety Data Sheet Authoring - Additional Data (Optional) Page
And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Personal Protection Equipment Recommended (select)' to: Gloves
And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Autoignition Temperature (°C)' enter text: 500
And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Minimum Ignition Energy (mJ)' enter text: 9
And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Viscosity' enter text: 12.0
And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Appearance' to: Black
And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor' to: Odorless
And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor Threshold' to: No data available
And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Partition Coefficient' enter text: 1
Then in the Safety Data Sheet Authoring - Additional Data (Optional) page, I click Continue

#And I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Test Comment
Then I should be on the Optional Comments Page
And In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: Test Comment
Then in the Optional Comments page, I click Continue

And I should see the Data Acceptance Page
Given I click the Summary button in the Data Acceptance window
Then I switch to the Data Summary page
And I close the window that opened
And I navigate to the home page
And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase74366

# Assigned to Beverly Barrett
# Created by Beverly Barrett

@TestCase:74368
Scenario: [74368] Flash Point Range < 23 - Testing method shows closed cup only, Transportation shows Yes and No due to an exemption, Hazard class 3 must be used
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load

#And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
Then I click the Add Product icon in the Navigation Pane
Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration

#And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bleach
Then I should be on the The Product Page
And In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Bleach
And In the Product Section, set the option in section: 'Type of Product (select)' to: Bleach
Then in the The Product page, I click Continue
Given I generate a random UPC number and save as: UPC74368
Then I save the product information as: TestCase74368

#And I call Shared Step 74340 (Product Information - Pesticide= Not considered, SOLD=US, everything else = No - Continue)
Then I should be on the Product Information Page
And In the Product Information Section, set the option in section: 'Which best describes your product, including when FIFRA 25(b) Exempt' to: Product is not a pesticide and does not make or imply a pesticidal claim on the labeling or in the product description (ex. kills, sterilizes, disinfects, sanitizes, antimicrobial)
And In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
And In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
And In the Product Information Section, set the option in section: 'Cleaning products must comply with California's Cleaning Product Right to Know Act. I would like to provide the additional information needed for this program during registration.' to: No
And In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
And In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
Then in the Product Information page, I click Continue

#And I call Shared Step 74339 (Physical and Chemical Properties - Select Liquid and enter only Secondary state, Relative Density, pH)
Then I should be on the Physical and Chemical Properties Page
And In the Physical and Chemical Properties Section, set the option in section: 'Primary Physical State' to: Liquid
And In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Liquid
And In the Physical and Chemical Properties Section, for section: 'Relative Density' enter text: 20
And In the Physical and Chemical Properties Section, for section: 'pH' enter text: 7
And In the Physical and Chemical Properties Section, for section: 'Boiling Point (in Celsius)' enter text: 45
And In the Physical and Chemical Properties Section, for section: 'Flash Point (in Celsius)' select the checkbox option: 'I do not have exact Flash Point data available to me'
And In the Physical and Chemical Properties Section, set the option in section: 'Flash Point (in Celsius)' to: <23C
And In the Physical and Chemical Properties Section, for section: 'Flash Point Testing Method Used': the following options should be displayed exclusively:
| Option            |
| Closed cup method |
And In the Physical and Chemical Properties Section, set the option in section: 'Flash Point Testing Method Used' to: Closed cup method
And In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Insoluble in water
Then in the Physical and Chemical Properties page, I click Continue

#And I call Shared Step 29181 (Ingredients - add any chemical) with name: Water
Then I should be on the Ingredients Page
And In the Ingredients section, add the following ingredients:
| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
| component name | Water       | 100     | False               | False         |             |
Then in the Ingredients page, I click Continue

#And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Then I should be on the Inventory Status, Prop 65 (US) Page
And In the Inventory Status, Prop 65 (US) Section, the following sections should only be displayed:
| Section                                                                                                                                                                   |
| U.S. Toxic Substances Control Act (TSCA) status                                                                                                                           |
| Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65) |
And In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
And In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
Then in the Inventory Status, Prop 65 (US) page, I click Continue

Then I should be on the Transportation Details 1 Page
And In the Transportation Details 1 Section, for section 'Product is Regulated for Transport': the following options should be displayed exclusively:
| Option                               |
| Yes                                  |
| No, due to an exemption or exception |
And In the Transportation Details 1 Section, set the option in section: 'Product is Regulated for Transport': to: Yes
And In the Transportation Details 1 Section, set the option in section: 'Select all modes of transport that you've classified the product for': to: DOT
And In the Transportation Details 1 Section, set the option for DOT mode of transport to: Shipping fully regulated
Then in the Transportation Details 1 page, I click Continue

#And I call Shared Step 81310 (UN Number - enter UN1950 select Aerosol & Haz class, confirm Packing group - Continue)
Then I should be on the U. S. Department of Transportation (DOT) Classification Page
And In the U. S. Department of Transportation (DOT) Classification Section, set the option in section: 'UN Number': to: UN1950
And In the U. S. Department of Transportation (DOT) Classification Section, set the option in section: 'Proper Shipping Name': to: Aerosols
And In the U. S. Department of Transportation (DOT) Classification Section, set the option in section: 'Hazard Class': to: 2.1
And In the U. S. Department of Transportation (DOT) Classification Section, set the option in section: 'Packing Group': to: None
Then in the U. S. Department of Transportation (DOT) Classification page, I click Continue

#And section: UN Number is highlighed in red indicating an error
#And UN Number should be showing the error messages: The UN-Number (DOT) is invalid with the selected Hazard Class and Flash Point value.|The Flash Point (50C - less than or equal to 60C) must only be used with Hazard Class 3
And In the U. S. Department of Transportation (DOT) Classification Section, verify that the section: 'UN Number' is highlighted in red indicating an error
And In the U. S. Department of Transportation (DOT) Classification Section, the section: 'UN Number' should be showing error message: The UN-Number (DOT) is invalid with the selected Hazard Class and Flash Point value.|The Flash Point (22C - less than or equal to 60C) must only be used with Hazard Class 3

#And I call Shared Step 81311 (UN Number - enter UN1206 - confirm pre-populated select radio button - Continue)
And In the U. S. Department of Transportation (DOT) Classification Section, set the option in section: 'UN Number': to: UN1206
And In the U. S. Department of Transportation (DOT) Classification Section, verify section: 'Proper Shipping Name' contains value: Heptanes
And In the U. S. Department of Transportation (DOT) Classification Section, verify section: 'Hazard Class (select)' contains value: 3
And In the U. S. Department of Transportation (DOT) Classification Section, verify section: 'Packing Group (select)' contains value: II
Then in the U. S. Department of Transportation (DOT) Classification page, I click Continue

And I should not see any error messages on the page

#And I You may see the Ecologo Readiness step depending on your subscription level - if the step is shown use the shared step below, if not skip to step 28
And If ECOLOGO Readiness page is displayed I call Shared Step 57712 - ECOLOGO Readiness Assessment - Not at this time - Continue - Happy Path

#And I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
Then I should be on the Retailer Page
And In the Retailer Section is selected retailer: No Retailer/No UPC Product
Then in the Retailer page, I click Continue

#And I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
Then I should be on the Regulatory Documents to Provide Page
And In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
Then in the Regulatory Documents to Provide page, I click Continue

And I should be on the Additional Documents to Provide Page
Then in the Additional Documents to Provide page, I click Continue
And I should be on the Optional Reports and Documents Available for Purchase Page
Then in the Optional Reports and Documents Available for Purchase page, I click Continue

#And I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
#| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
Then I should be on the Safety Data Sheet Authoring - Additional Data (Optional) Page
And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Personal Protection Equipment Recommended (select)' to: Gloves
And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Autoignition Temperature (°C)' enter text: 500
And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Minimum Ignition Energy (mJ)' enter text: 9
And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Viscosity' enter text: 12.0
And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Appearance' to: Black
And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor' to: Odorless
And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor Threshold' to: No data available
And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Partition Coefficient' enter text: 1
Then in the Safety Data Sheet Authoring - Additional Data (Optional) page, I click Continue

#And I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Test Comment
Then I should be on the Optional Comments Page
And In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: Test Comment
Then in the Optional Comments page, I click Continue

And I should see the Data Acceptance Page
Given I click the Summary button in the Data Acceptance window
Then I switch to the Data Summary page
And I close the window that opened
And I navigate to the home page
And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase74368

# Assigned to Beverly Barrett
# Created by Beverly Barrett

@TestCase:74372
Scenario: [74372] Flash Point Range >=23 and <38 - Testing method shows closed cup only, Transportation shows Yes and No due to an exemption, Hazard class 3 must be used
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load

#And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
Then I click the Add Product icon in the Navigation Pane
Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration

#And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bleach
Then I should be on the The Product Page
And In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Bleach
And In the Product Section, set the option in section: 'Type of Product (select)' to: Bleach
Then in the The Product page, I click Continue

Given I generate a random UPC number and save as: UPC74372
Then I save the product information as: TestCase74372

#And I call Shared Step 74340 (Product Information - Pesticide= Not considered, SOLD=US, everything else = No - Continue)
Then I should be on the Product Information Page
And In the Product Information Section, set the option in section: 'Which best describes your product, including when FIFRA 25(b) Exempt' to: Product is not a pesticide and does not make or imply a pesticidal claim on the labeling or in the product description (ex. kills, sterilizes, disinfects, sanitizes, antimicrobial)
And In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
And In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
And In the Product Information Section, set the option in section: 'Cleaning products must comply with California's Cleaning Product Right to Know Act. I would like to provide the additional information needed for this program during registration.' to: No
And In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
And In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
Then in the Product Information page, I click Continue

#And I call Shared Step 74339 (Physical and Chemical Properties - Select Liquid and enter only Secondary state, Relative Density, pH)
Then I should be on the Physical and Chemical Properties Page
And In the Physical and Chemical Properties Section, set the option in section: 'Primary Physical State' to: Liquid
And In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Liquid
And In the Physical and Chemical Properties Section, for section: 'Relative Density' enter text: 20
And In the Physical and Chemical Properties Section, for section: 'pH' enter text: 7
And In the Physical and Chemical Properties Section, for section: 'Boiling Point (in Celsius)' enter text: 50
And In the Physical and Chemical Properties Section, for section: 'Flash Point (in Celsius)' select the checkbox option: 'I do not have exact Flash Point data available to me'
And In the Physical and Chemical Properties Section, set the option in section: 'Flash Point (in Celsius)' to: >=23C and <38C
And In the Physical and Chemical Properties Section, for section: 'Flash Point Testing Method Used': the following options should be displayed exclusively:
| Option            |
| Closed cup method |
And In the Physical and Chemical Properties Section, set the option in section: 'Flash Point Testing Method Used' to: Closed cup method
And In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Insoluble in water
Then in the Physical and Chemical Properties page, I click Continue

#And I call Shared Step 29181 (Ingredients - add any chemical) with name: Water
Then I should be on the Ingredients Page
And In the Ingredients section, add the following ingredients:
| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
| component name | Water       | 100     | False               | False         |             |
Then in the Ingredients page, I click Continue

#And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Then I should be on the Inventory Status, Prop 65 (US) Page
And In the Inventory Status, Prop 65 (US) Section, the following sections should only be displayed:
| Section                                                                                                                                                                   |
| U.S. Toxic Substances Control Act (TSCA) status                                                                                                                           |
| Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65) |
And In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
And In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
Then in the Inventory Status, Prop 65 (US) page, I click Continue

Then I should be on the Transportation Details 1 Page
And In the Transportation Details 1 Section, for section 'Product is Regulated for Transport': the following options should be displayed exclusively:
| Option                               |
| Yes                                  |
| No, due to an exemption or exception |
And In the Transportation Details 1 Section, set the option in section: 'Product is Regulated for Transport': to: Yes
And In the Transportation Details 1 Section, set the option in section: 'Select all modes of transport that you've classified the product for': to: DOT
And In the Transportation Details 1 Section, set the option for DOT mode of transport to: Shipping fully regulated
Then in the Transportation Details 1 page, I click Continue

#And I call Shared Step 81310 (UN Number - enter UN1950 select Aerosol & Haz class, confirm Packing group - Continue)
Then I should be on the U. S. Department of Transportation (DOT) Classification Page
And In the U. S. Department of Transportation (DOT) Classification Section, set the option in section: 'UN Number': to: UN1950
And In the U. S. Department of Transportation (DOT) Classification Section, set the option in section: 'Proper Shipping Name': to: Aerosols
And In the U. S. Department of Transportation (DOT) Classification Section, set the option in section: 'Hazard Class': to: 2.1
And In the U. S. Department of Transportation (DOT) Classification Section, set the option in section: 'Packing Group': to: None
Then in the U. S. Department of Transportation (DOT) Classification page, I click Continue

#And section: UN Number is highlighed in red indicating an error
#And UN Number should be showing the error messages: The UN-Number (DOT) is invalid with the selected Hazard Class and Flash Point value.|The Flash Point (50C - less than or equal to 60C) must only be used with Hazard Class 3
And In the U. S. Department of Transportation (DOT) Classification Section, verify that the section: 'UN Number' is highlighted in red indicating an error
And In the U. S. Department of Transportation (DOT) Classification Section, the section: 'UN Number' should be showing error message: The UN-Number (DOT) is invalid with the selected Hazard Class and Flash Point value.|The Flash Point (23C - less than or equal to 60C) must only be used with Hazard Class 3
#And I call Shared Step 81311 (UN Number - enter UN1206 - confirm pre-populated select radio button - Continue)
And In the U. S. Department of Transportation (DOT) Classification Section, set the option in section: 'UN Number': to: UN1206
And In the U. S. Department of Transportation (DOT) Classification Section, verify section: 'Proper Shipping Name' contains value: Heptanes
And In the U. S. Department of Transportation (DOT) Classification Section, verify section: 'Hazard Class (select)' contains value: 3
And In the U. S. Department of Transportation (DOT) Classification Section, verify section: 'Packing Group (select)' contains value: II
Then in the U. S. Department of Transportation (DOT) Classification page, I click Continue

And I should not see any error messages on the page

#And I You may see the Ecologo readiness step depending on your subscription.  If you see the Ecologo step use the shared step below.  If you do not see it skip to step 29
And If ECOLOGO Readiness page is displayed I call Shared Step 57712 - ECOLOGO Readiness Assessment - Not at this time - Continue - Happy Path

#And I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
Then I should be on the Regulatory Documents to Provide Page
And In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
Then in the Regulatory Documents to Provide page, I click Continue

And I should be on the Additional Documents to Provide Page
Then in the Additional Documents to Provide page, I click Continue
And I should be on the Optional Reports and Documents Available for Purchase Page
Then in the Optional Reports and Documents Available for Purchase page, I click Continue

#And I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
#| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
Then I should be on the Safety Data Sheet Authoring - Additional Data (Optional) Page
And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Personal Protection Equipment Recommended (select)' to: Gloves
And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Autoignition Temperature (°C)' enter text: 500
And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Minimum Ignition Energy (mJ)' enter text: 9
And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Viscosity' enter text: 12.0
And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Appearance' to: Black
And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor' to: Odorless
And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor Threshold' to: No data available
And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Partition Coefficient' enter text: 1
Then in the Safety Data Sheet Authoring - Additional Data (Optional) page, I click Continue

#And I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Test Comment
Then I should be on the Optional Comments Page
And In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: Test Comment
Then in the Optional Comments page, I click Continue

And I should see the Data Acceptance Page
Given I click the Summary button in the Data Acceptance window
Then I switch to the Data Summary page
And I close the window that opened
And I navigate to the home page
And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase74372

# Assigned to Beverly Barrett
# Created by Beverly Barrett

@TestCase:74374
Scenario: [74374] Flash Point Range >=38 and <=60  - Testing method shows closed cup only, Transportation shows Yes and No due to an exemption, Hazard class 3 must be used
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load

#And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
Then I click the Add Product icon in the Navigation Pane
Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration

#And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bleach
Then I should be on the The Product Page
And In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Bleach
And In the Product Section, set the option in section: 'Type of Product (select)' to: Bleach
Then in the The Product page, I click Continue

#And I call Shared Step 74340 (Product Information - Pesticide= Not considered, SOLD=US, everything else = No - Continue)
Then I should be on the Product Information Page
And In the Product Information Section, set the option in section: 'Which best describes your product, including when FIFRA 25(b) Exempt' to: Product is not a pesticide and does not make or imply a pesticidal claim on the labeling or in the product description (ex. kills, sterilizes, disinfects, sanitizes, antimicrobial)
And In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
And In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
And In the Product Information Section, set the option in section: 'Cleaning products must comply with California's Cleaning Product Right to Know Act. I would like to provide the additional information needed for this program during registration.' to: No
And In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
And In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
Then in the Product Information page, I click Continue

#And I call Shared Step 74339 (Physical and Chemical Properties - Select Liquid and enter only Secondary state, Relative Density, pH)
Then I should be on the Physical and Chemical Properties Page
And In the Physical and Chemical Properties Section, set the option in section: 'Primary Physical State' to: Liquid
And In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Liquid
And In the Physical and Chemical Properties Section, for section: 'Relative Density' enter text: 20
And In the Physical and Chemical Properties Section, for section: 'pH' enter text: 7
And In the Physical and Chemical Properties Section, for section: 'Boiling Point (in Celsius)' enter text: 50
And In the Physical and Chemical Properties Section, for section: 'Flash Point (in Celsius)' select the checkbox option: 'I do not have exact Flash Point data available to me'
And In the Physical and Chemical Properties Section, set the option in section: 'Flash Point (in Celsius)' to: >=38C and <=60C
And In the Physical and Chemical Properties Section, for section: 'Flash Point Testing Method Used': the following options should be displayed exclusively:
| Option            |
| Closed cup method |
And In the Physical and Chemical Properties Section, set the option in section: 'Flash Point Testing Method Used' to: Closed cup method
And In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Insoluble in water
Then in the Physical and Chemical Properties page, I click Continue

#And I call Shared Step 29181 (Ingredients - add any chemical) with name: Water
Then I should be on the Ingredients Page
And In the Ingredients section, add the following ingredients:
| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
| component name | Water       | 100     | False               | False         |             |
Then in the Ingredients page, I click Continue


#And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Then I should be on the Inventory Status, Prop 65 (US) Page
And In the Inventory Status, Prop 65 (US) Section, the following sections should only be displayed:
| Section                                                                                                                                                                   |
| U.S. Toxic Substances Control Act (TSCA) status                                                                                                                           |
| Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65) |
And In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
And In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
Then in the Inventory Status, Prop 65 (US) page, I click Continue

Then I should be on the Transportation Details 1 Page
And In the Transportation Details 1 Section, for section 'Product is Regulated for Transport': the following options should be displayed exclusively:
| Option                               |
| Yes                                  |
| No, due to an exemption or exception |
And In the Transportation Details 1 Section, set the option in section: 'Product is Regulated for Transport': to: Yes
And In the Transportation Details 1 Section, set the option in section: 'Select all modes of transport that you've classified the product for': to: DOT
And In the Transportation Details 1 Section, set the option for DOT mode of transport to: Shipping fully regulated
Then in the Transportation Details 1 page, I click Continue

#And I call Shared Step 81310 (UN Number - enter UN1950 select Aerosol & Haz class, confirm Packing group - Continue)
Then I should be on the U. S. Department of Transportation (DOT) Classification Page
And In the U. S. Department of Transportation (DOT) Classification Section, set the option in section: 'UN Number': to: UN1950
And In the U. S. Department of Transportation (DOT) Classification Section, set the option in section: 'Proper Shipping Name': to: Aerosols
And In the U. S. Department of Transportation (DOT) Classification Section, set the option in section: 'Hazard Class': to: 2.1
And In the U. S. Department of Transportation (DOT) Classification Section, set the option in section: 'Packing Group': to: None
Then in the U. S. Department of Transportation (DOT) Classification page, I click Continue

#And section: UN Number is highlighed in red indicating an error
#And UN Number should be showing the error messages: The UN-Number (DOT) is invalid with the selected Hazard Class and Flash Point value.|The Flash Point (50C - less than or equal to 60C) must only be used with Hazard Class 3
And In the U. S. Department of Transportation (DOT) Classification Section, verify that the section: 'UN Number' is highlighted in red indicating an error
And In the U. S. Department of Transportation (DOT) Classification Section, the section: 'UN Number' should be showing error message: The UN-Number (DOT) is invalid with the selected Hazard Class and Flash Point value.|The Flash Point (39C - less than or equal to 60C) must only be used with Hazard Class 3
#And I call Shared Step 81311 (UN Number - enter UN1206 - confirm pre-populated select radio button - Continue)
And In the U. S. Department of Transportation (DOT) Classification Section, set the option in section: 'UN Number': to: UN1206
And In the U. S. Department of Transportation (DOT) Classification Section, verify section: 'Proper Shipping Name' contains value: Heptanes
And In the U. S. Department of Transportation (DOT) Classification Section, verify section: 'Hazard Class (select)' contains value: 3
And In the U. S. Department of Transportation (DOT) Classification Section, verify section: 'Packing Group (select)' contains value: II
Then in the U. S. Department of Transportation (DOT) Classification page, I click Continue

And I should not see any error messages on the page

#And I You may see the Ecologo readiness step depending on your subscription.  If you see the Ecologo step use the shared step below.  If you do not see it skip to step 29
And If ECOLOGO Readiness page is displayed I call Shared Step 57712 - ECOLOGO Readiness Assessment - Not at this time - Continue - Happy Path
#And I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
Then I should be on the Regulatory Documents to Provide Page
And In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
Then in the Regulatory Documents to Provide page, I click Continue

And I should be on the Additional Documents to Provide Page
Then in the Additional Documents to Provide page, I click Continue
And I should be on the Optional Reports and Documents Available for Purchase Page
Then in the Optional Reports and Documents Available for Purchase page, I click Continue

#And I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
#| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
Then I should be on the Safety Data Sheet Authoring - Additional Data (Optional) Page
And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Personal Protection Equipment Recommended (select)' to: Gloves
And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Autoignition Temperature (°C)' enter text: 500
And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Minimum Ignition Energy (mJ)' enter text: 9
And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Viscosity' enter text: 12.0
And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Appearance' to: Black
And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor' to: Odorless
And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor Threshold' to: No data available
And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Partition Coefficient' enter text: 1
Then in the Safety Data Sheet Authoring - Additional Data (Optional) page, I click Continue

#And I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Test Comment
Then I should be on the Optional Comments Page
And In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: Test Comment
Then in the Optional Comments page, I click Continue

And I should see the Data Acceptance Page
Given I click the Summary button in the Data Acceptance window
Then I switch to the Data Summary page
And I close the window that opened
And I navigate to the home page
And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase74374

# Assigned to Beverly Barrett
# Created by Beverly Barrett

@TestCase:74376
Scenario: [74376] Flash Point Range > 60 and < 93 - Testing method shows all, Transportation shows all, Hazard class 3 must NOT be used
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load

#And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
Then I click the Add Product icon in the Navigation Pane
Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration

#And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bleach
Then I should be on the The Product Page
And In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Bleach
And In the Product Section, set the option in section: 'Type of Product (select)' to: Bleach
Then in the The Product page, I click Continue

#And I call Shared Step 74340 (Product Information - Pesticide= Not considered, SOLD=US, everything else = No - Continue)
Then I should be on the Product Information Page
And In the Product Information Section, set the option in section: 'Which best describes your product, including when FIFRA 25(b) Exempt' to: Product is not a pesticide and does not make or imply a pesticidal claim on the labeling or in the product description (ex. kills, sterilizes, disinfects, sanitizes, antimicrobial)
And In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
And In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
And In the Product Information Section, set the option in section: 'Cleaning products must comply with California's Cleaning Product Right to Know Act. I would like to provide the additional information needed for this program during registration.' to: No
And In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
And In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
Then in the Product Information page, I click Continue


#And I call Shared Step 74339 (Physical and Chemical Properties - Select Liquid and enter only Secondary state, Relative Density, pH)
Then I should be on the Physical and Chemical Properties Page
And In the Physical and Chemical Properties Section, set the option in section: 'Primary Physical State' to: Liquid
And In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Liquid
And In the Physical and Chemical Properties Section, for section: 'Relative Density' enter text: 20
And In the Physical and Chemical Properties Section, for section: 'pH' enter text: 7
And In the Physical and Chemical Properties Section, for section: 'Boiling Point (in Celsius)' enter text: 50
And In the Physical and Chemical Properties Section, for section: 'Flash Point (in Celsius)' select the checkbox option: 'I do not have exact Flash Point data available to me'
And In the Physical and Chemical Properties Section, set the option in section: 'Flash Point (in Celsius)' to: >60C and <=93C
And In the Physical and Chemical Properties Section, for section: 'Flash Point Testing Method Used': the following options should be displayed exclusively:
| Option                   |
| Closed cup method        |
| Open cup method          |
| Not applicable/available |
And In the Physical and Chemical Properties Section, set the option in section: 'Flash Point Testing Method Used' to: Open cup method
And In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Insoluble in water
Then in the Physical and Chemical Properties page, I click Continue

#And I call Shared Step 29181 (Ingredients - add any chemical) with name: Water
Then I should be on the Ingredients Page
And In the Ingredients section, add the following ingredients:
| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
| component name | Water       | 100     | False               | False         |             |
Then in the Ingredients page, I click Continue


#And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Then I should be on the Inventory Status, Prop 65 (US) Page
And In the Inventory Status, Prop 65 (US) Section, the following sections should only be displayed:
| Section                                                                                                                                                                   |
| U.S. Toxic Substances Control Act (TSCA) status                                                                                                                           |
| Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65) |
And In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
And In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
Then in the Inventory Status, Prop 65 (US) page, I click Continue

Then I should be on the Transportation Details 1 Page
And In the Transportation Details 1 Section, for section 'Product is Regulated for Transport': the following options should be displayed exclusively:
| Option                               |
| Yes                                  |
| No, due to an exemption or exception |
| Not Regulated                        |
And In the Transportation Details 1 Section, set the option in section: 'Product is Regulated for Transport': to: Yes
And In the Transportation Details 1 Section, set the option in section: 'Select all modes of transport that you've classified the product for': to: DOT
And In the Transportation Details 1 Section, set the option for DOT mode of transport to: Shipping fully regulated
Then in the Transportation Details 1 page, I click Continue
#And I call Shared Step 81311 (UN Number - enter UN1206 - confirm pre-populated select radio button - Continue)
And In the U. S. Department of Transportation (DOT) Classification Section, set the option in section: 'UN Number': to: UN1206
And In the U. S. Department of Transportation (DOT) Classification Section, verify section: 'Proper Shipping Name' contains value: Heptanes
And In the U. S. Department of Transportation (DOT) Classification Section, verify section: 'Hazard Class (select)' contains value: 3
And In the U. S. Department of Transportation (DOT) Classification Section, verify section: 'Packing Group (select)' contains value: II
Then in the U. S. Department of Transportation (DOT) Classification page, I click Continue

#And section: UN Number is highlighed in red indicating an error
#And UN Number should be showing the error messages: The UN-Number (DOT) is invalid with the selected Hazard Class and Flash Point value.|The Flash Point (50C - less than or equal to 60C) must only be used with Hazard Class 3
And In the U. S. Department of Transportation (DOT) Classification Section, verify that the section: 'UN Number' is highlighted in red indicating an error
And In the U. S. Department of Transportation (DOT) Classification Section, the section: 'UN Number' should be showing error message: The UN-Number (DOT) is invalid with the selected Hazard Class and Flash Point value.|The Flash Point (61C - greater than 60C) must not be used with Hazard Class 3
#And I call Shared Step 81310 (UN Number - enter UN1950 select Aerosol & Haz class, confirm Packing group - Continue)
Then I should be on the U. S. Department of Transportation (DOT) Classification Page
And In the U. S. Department of Transportation (DOT) Classification Section, set the option in section: 'UN Number': to: UN1950
And In the U. S. Department of Transportation (DOT) Classification Section, set the option in section: 'Proper Shipping Name': to: Aerosols
And In the U. S. Department of Transportation (DOT) Classification Section, set the option in section: 'Hazard Class': to: 2.1
And In the U. S. Department of Transportation (DOT) Classification Section, set the option in section: 'Packing Group': to: None
Then in the U. S. Department of Transportation (DOT) Classification page, I click Continue

And I should not see any error messages on the page

#And I You may see the Ecologo readiness step depending on your subscription.  If you see the Ecologo step use the shared step below.  If you do not see it skip to step 29
And If ECOLOGO Readiness page is displayed I call Shared Step 57712 - ECOLOGO Readiness Assessment - Not at this time - Continue - Happy Path

#And I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
Then I should be on the Regulatory Documents to Provide Page
And In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
Then in the Regulatory Documents to Provide page, I click Continue

And I should be on the Additional Documents to Provide Page
Then in the Additional Documents to Provide page, I click Continue
And I should be on the Optional Reports and Documents Available for Purchase Page
Then in the Optional Reports and Documents Available for Purchase page, I click Continue

#And I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
#| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
Then I should be on the Safety Data Sheet Authoring - Additional Data (Optional) Page
And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Personal Protection Equipment Recommended (select)' to: Gloves
And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Autoignition Temperature (°C)' enter text: 500
And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Minimum Ignition Energy (mJ)' enter text: 9
And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Viscosity' enter text: 12.0
And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Appearance' to: Black
And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor' to: Odorless
And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor Threshold' to: No data available
And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Partition Coefficient' enter text: 1
Then in the Safety Data Sheet Authoring - Additional Data (Optional) page, I click Continue

#And I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Test Comment
Then I should be on the Optional Comments Page
And In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: Test Comment
Then in the Optional Comments page, I click Continue

And I should see the Data Acceptance Page
Given I click the Summary button in the Data Acceptance window
Then I switch to the Data Summary page
And I close the window that opened
And I navigate to the home page
And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase74376

# Assigned to Beverly Barrett
# Created by Beverly Barrett

@TestCase:74379
Scenario: [74379] Flash Point Range >=93 and <=815 - Testing method shows all, Transportation shows all, Hazard class 3 must NOT be used
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load

#And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
Then I click the Add Product icon in the Navigation Pane
Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration

#And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bleach
Then I should be on the The Product Page
And In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Bleach
And In the Product Section, set the option in section: 'Type of Product (select)' to: Bleach
Then in the The Product page, I click Continue
Then I save the product information as: TestCase74379

#And I call Shared Step 74340 (Product Information - Pesticide= Not considered, SOLD=US, everything else = No - Continue)
Then I should be on the Product Information Page
And In the Product Information Section, set the option in section: 'Which best describes your product, including when FIFRA 25(b) Exempt' to: Product is not a pesticide and does not make or imply a pesticidal claim on the labeling or in the product description (ex. kills, sterilizes, disinfects, sanitizes, antimicrobial)
And In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
And In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
And In the Product Information Section, set the option in section: 'Cleaning products must comply with California's Cleaning Product Right to Know Act. I would like to provide the additional information needed for this program during registration.' to: No
And In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
And In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
Then in the Product Information page, I click Continue

#And I call Shared Step 74339 (Physical and Chemical Properties - Select Liquid and enter only Secondary state, Relative Density, pH)
Then I should be on the Physical and Chemical Properties Page
And In the Physical and Chemical Properties Section, set the option in section: 'Primary Physical State' to: Liquid
And In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Liquid
And In the Physical and Chemical Properties Section, for section: 'Relative Density' enter text: 20
And In the Physical and Chemical Properties Section, for section: 'pH' enter text: 7
And In the Physical and Chemical Properties Section, for section: 'Boiling Point (in Celsius)' enter text: 50
And In the Physical and Chemical Properties Section, for section: 'Flash Point (in Celsius)' select the checkbox option: 'I do not have exact Flash Point data available to me'
And In the Physical and Chemical Properties Section, set the option in section: 'Flash Point (in Celsius)' to: >=93C and <=815C
And In the Physical and Chemical Properties Section, for section: 'Flash Point Testing Method Used': the following options should be displayed exclusively:
| Option                   |
| Closed cup method        |
| Open cup method          |
| Not applicable/available |
And In the Physical and Chemical Properties Section, set the option in section: 'Flash Point Testing Method Used' to: Open cup method
And In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
Then in the Physical and Chemical Properties page, I click Continue

#And I call Shared Step 29181 (Ingredients - add any chemical) with name: Water
Then I should be on the Ingredients Page
And In the Ingredients section, add the following ingredients:
| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
| component name | Water       | 100     | False               | False         |             |
Then in the Ingredients page, I click Continue


#And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Then I should be on the Inventory Status, Prop 65 (US) Page
And In the Inventory Status, Prop 65 (US) Section, the following sections should only be displayed:
| Section                                                                                                                                                                   |
| U.S. Toxic Substances Control Act (TSCA) status                                                                                                                           |
| Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65) |
And In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
And In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
Then in the Inventory Status, Prop 65 (US) page, I click Continue

Then I should be on the Transportation Details 1 Page
And In the Transportation Details 1 Section, for section 'Product is Regulated for Transport': the following options should be displayed exclusively:
| Option                               |
| Yes                                  |
| No, due to an exemption or exception |
| Not Regulated                        |
And In the Transportation Details 1 Section, set the option in section: 'Product is Regulated for Transport': to: Yes
And In the Transportation Details 1 Section, set the option in section: 'Select all modes of transport that you've classified the product for': to: DOT
And In the Transportation Details 1 Section, set the option for DOT mode of transport to: Shipping fully regulated
Then in the Transportation Details 1 page, I click Continue
#And I call Shared Step 81311 (UN Number - enter UN1206 - confirm pre-populated select radio button - Continue)
And In the U. S. Department of Transportation (DOT) Classification Section, set the option in section: 'UN Number': to: UN1206
And In the U. S. Department of Transportation (DOT) Classification Section, verify section: 'Proper Shipping Name' contains value: Heptanes
And In the U. S. Department of Transportation (DOT) Classification Section, verify section: 'Hazard Class (select)' contains value: 3
And In the U. S. Department of Transportation (DOT) Classification Section, verify section: 'Packing Group (select)' contains value: II
Then in the U. S. Department of Transportation (DOT) Classification page, I click Continue

#And section: UN Number is highlighed in red indicating an error
#And UN Number should be showing the error messages: The UN-Number (DOT) is invalid with the selected Hazard Class and Flash Point value.|The Flash Point (50C - less than or equal to 60C) must only be used with Hazard Class 3
And In the U. S. Department of Transportation (DOT) Classification Section, verify that the section: 'UN Number' is highlighted in red indicating an error
And In the U. S. Department of Transportation (DOT) Classification Section, the section: 'UN Number' should be showing error message: The UN-Number (DOT) is invalid with the selected Hazard Class and Flash Point value.|The Flash Point (94C - greater than 60C) must not be used with Hazard Class 3
#And I call Shared Step 81310 (UN Number - enter UN1950 select Aerosol & Haz class, confirm Packing group - Continue)
Then I should be on the U. S. Department of Transportation (DOT) Classification Page
And In the U. S. Department of Transportation (DOT) Classification Section, set the option in section: 'UN Number': to: UN1950
And In the U. S. Department of Transportation (DOT) Classification Section, set the option in section: 'Proper Shipping Name': to: Aerosols
And In the U. S. Department of Transportation (DOT) Classification Section, set the option in section: 'Hazard Class': to: 2.1
And In the U. S. Department of Transportation (DOT) Classification Section, set the option in section: 'Packing Group': to: None
Then in the U. S. Department of Transportation (DOT) Classification page, I click Continue

And I should not see any error messages on the page

#And I You may see the Ecologo readiness step depending on your subscription.  If you see the Ecologo step use the shared step below.  If you do not see it skip to step 29
And If ECOLOGO Readiness page is displayed I call Shared Step 57712 - ECOLOGO Readiness Assessment - Not at this time - Continue - Happy Path
#And I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
Then I should be on the Regulatory Documents to Provide Page
And In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
Then in the Regulatory Documents to Provide page, I click Continue

And I should be on the Additional Documents to Provide Page
Then in the Additional Documents to Provide page, I click Continue
And I should be on the Optional Reports and Documents Available for Purchase Page
Then in the Optional Reports and Documents Available for Purchase page, I click Continue

#And I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
#| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
Then I should be on the Safety Data Sheet Authoring - Additional Data (Optional) Page
And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Personal Protection Equipment Recommended (select)' to: Gloves
And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Autoignition Temperature (°C)' enter text: 500
And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Minimum Ignition Energy (mJ)' enter text: 9
And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Viscosity' enter text: 12.0
And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Appearance' to: Black
And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor' to: Odorless
And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor Threshold' to: No data available
And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Partition Coefficient' enter text: 1
Then in the Safety Data Sheet Authoring - Additional Data (Optional) page, I click Continue

#And I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Test Comment
Then I should be on the Optional Comments Page
And In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: Test Comment
Then in the Optional Comments page, I click Continue

And I should see the Data Acceptance Page
Given I click the Summary button in the Data Acceptance window
Then I switch to the Data Summary page
And I close the window that opened
And I navigate to the home page
Given I search for the product saved as: TestCase74379
When I click Row Actions for the most recent product returned
And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase74379

# Assigned to Beverly Barrett
# Created by Beverly Barrett

@TestCase:74380
Scenario: [74380] Flash Point Range Not Tested - Testing method shows Not Applicable/available, Transportation shows all, UN page shows - FP is required with Hazard Class 3
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load

#And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
Then I click the Add Product icon in the Navigation Pane
Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration

#And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bleach
Then I should be on the The Product Page
And In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Bleach
And In the Product Section, set the option in section: 'Type of Product (select)' to: Bleach
Then in the The Product page, I click Continue

#And I call Shared Step 74340 (Product Information - Pesticide= Not considered, SOLD=US, everything else = No - Continue)
Then I should be on the Product Information Page
And In the Product Information Section, set the option in section: 'Which best describes your product, including when FIFRA 25(b) Exempt' to: Product is not a pesticide and does not make or imply a pesticidal claim on the labeling or in the product description (ex. kills, sterilizes, disinfects, sanitizes, antimicrobial)
And In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
And In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
And In the Product Information Section, set the option in section: 'Cleaning products must comply with California's Cleaning Product Right to Know Act. I would like to provide the additional information needed for this program during registration.' to: No
And In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
And In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
Then in the Product Information page, I click Continue


#And I call Shared Step 74339 (Physical and Chemical Properties - Select Liquid and enter only Secondary state, Relative Density, pH)
Then I should be on the Physical and Chemical Properties Page
And In the Physical and Chemical Properties Section, set the option in section: 'Primary Physical State' to: Liquid
And In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Liquid
And In the Physical and Chemical Properties Section, for section: 'Relative Density' enter text: 20
And In the Physical and Chemical Properties Section, for section: 'pH' enter text: 7
And In the Physical and Chemical Properties Section, for section: 'Boiling Point (in Celsius)' enter text: 75
And In the Physical and Chemical Properties Section, for section: 'Flash Point (in Celsius)' select the checkbox option: 'I do not have exact Flash Point data available to me'
And In the Physical and Chemical Properties Section, set the option in section: 'Flash Point (in Celsius)' to: Not Tested/Unknown
And In the Physical and Chemical Properties Section, for section: 'Flash Point Testing Method Used': the following options should be displayed exclusively:
| Option                   |
| Not Tested/Unknown |
And In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Insoluble in water
Then in the Physical and Chemical Properties page, I click Continue

#And I call Shared Step 29181 (Ingredients - add any chemical) with name: Water
Then I should be on the Ingredients Page
And In the Ingredients section, add the following ingredients:
| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
| component name | Water       | 100     | False               | False         |             |
Then in the Ingredients page, I click Continue


#And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Then I should be on the Inventory Status, Prop 65 (US) Page
And In the Inventory Status, Prop 65 (US) Section, the following sections should only be displayed:
| Section                                                                                                                                                                   |
| U.S. Toxic Substances Control Act (TSCA) status                                                                                                                           |
| Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65) |
And In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
And In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
Then in the Inventory Status, Prop 65 (US) page, I click Continue

Then I should be on the Transportation Details 1 Page
And In the Transportation Details 1 Section, for section 'Product is Regulated for Transport': the following options should be displayed exclusively:
| Option                               |
| Yes                                  |
| No, due to an exemption or exception |
| Not Regulated                        |
And In the Transportation Details 1 Section, set the option in section: 'Product is Regulated for Transport': to: Yes
And In the Transportation Details 1 Section, set the option in section: 'Select all modes of transport that you've classified the product for': to: DOT
And In the Transportation Details 1 Section, set the option for DOT mode of transport to: Shipping fully regulated
Then in the Transportation Details 1 page, I click Continue
#And I call Shared Step 81311 (UN Number - enter UN1206 - confirm pre-populated select radio button - Continue)
And In the U. S. Department of Transportation (DOT) Classification Section, set the option in section: 'UN Number': to: UN1206
And In the U. S. Department of Transportation (DOT) Classification Section, verify section: 'Proper Shipping Name' contains value: Heptanes
And In the U. S. Department of Transportation (DOT) Classification Section, verify section: 'Hazard Class (select)' contains value: 3
And In the U. S. Department of Transportation (DOT) Classification Section, verify section: 'Packing Group (select)' contains value: II
Then in the U. S. Department of Transportation (DOT) Classification page, I click Continue

#And section: UN Number is highlighed in red indicating an error
#And UN Number should be showing the error messages: The UN-Number (DOT) is invalid with the selected Hazard Class and Flash Point value.|The Flash Point (50C - less than or equal to 60C) must only be used with Hazard Class 3
And In the U. S. Department of Transportation (DOT) Classification Section, verify that the section: 'UN Number' is highlighted in red indicating an error
And In the U. S. Department of Transportation (DOT) Classification Section, the section: 'UN Number' should be showing error message: Flash Point is required with Hazard Class 3
#And I call Shared Step 81310 (UN Number - enter UN1950 select Aerosol & Haz class, confirm Packing group - Continue)
Then I should be on the U. S. Department of Transportation (DOT) Classification Page
And In the U. S. Department of Transportation (DOT) Classification Section, set the option in section: 'UN Number': to: UN1950
And In the U. S. Department of Transportation (DOT) Classification Section, set the option in section: 'Proper Shipping Name': to: Aerosols
And In the U. S. Department of Transportation (DOT) Classification Section, set the option in section: 'Hazard Class': to: 2.1
And In the U. S. Department of Transportation (DOT) Classification Section, set the option in section: 'Packing Group': to: None
Then in the U. S. Department of Transportation (DOT) Classification page, I click Continue

And I should not see any error messages on the page

#And I You may see the Ecologo readiness step depending on your subscription.  If you see the Ecologo step use the shared step below.  If you do not see it skip to step 29
And If ECOLOGO Readiness page is displayed I call Shared Step 57712 - ECOLOGO Readiness Assessment - Not at this time - Continue - Happy Path
#And I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
Then I should be on the Regulatory Documents to Provide Page
And In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
Then in the Regulatory Documents to Provide page, I click Continue

And I should be on the Additional Documents to Provide Page
Then in the Additional Documents to Provide page, I click Continue
And I should be on the Optional Reports and Documents Available for Purchase Page
Then in the Optional Reports and Documents Available for Purchase page, I click Continue

#And I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
#| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
Then I should be on the Safety Data Sheet Authoring - Additional Data (Optional) Page
And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Personal Protection Equipment Recommended (select)' to: Gloves
And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Autoignition Temperature (°C)' enter text: 500
And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Minimum Ignition Energy (mJ)' enter text: 9
And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Viscosity' enter text: 12.0
And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Appearance' to: Black
And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor' to: Odorless
And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor Threshold' to: No data available
And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Partition Coefficient' enter text: 1
Then in the Safety Data Sheet Authoring - Additional Data (Optional) page, I click Continue

#And I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Test Comment
Then I should be on the Optional Comments Page
And In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: Test Comment
Then in the Optional Comments page, I click Continue

And I should see the Data Acceptance Page
Given I click the Summary button in the Data Acceptance window
Then I switch to the Data Summary page
And I close the window that opened
And I navigate to the home page
And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase74380

# Assigned to Beverly Barrett
# Created by Beverly Barrett

@TestCase:74382
Scenario: [74382] Flash Point Range None, No Flash Point- Testing method shows Not Applicable/available, Transportation shows all, UN page shows - FP is required with Hazard Class 3
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load

#And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
Then I click the Add Product icon in the Navigation Pane
Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration

#And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bleach
Then I should be on the The Product Page
And In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Bleach
And In the Product Section, set the option in section: 'Type of Product (select)' to: Bleach
Then in the The Product page, I click Continue

#And I call Shared Step 74340 (Product Information - Pesticide= Not considered, SOLD=US, everything else = No - Continue)
Then I should be on the Product Information Page
And In the Product Information Section, set the option in section: 'Which best describes your product, including when FIFRA 25(b) Exempt' to: Product is not a pesticide and does not make or imply a pesticidal claim on the labeling or in the product description (ex. kills, sterilizes, disinfects, sanitizes, antimicrobial)
And In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
And In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
And In the Product Information Section, set the option in section: 'Cleaning products must comply with California's Cleaning Product Right to Know Act. I would like to provide the additional information needed for this program during registration.' to: No
And In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
And In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
Then in the Product Information page, I click Continue

#And I call Shared Step 74339 (Physical and Chemical Properties - Select Liquid and enter only Secondary state, Relative Density, pH)
Then I should be on the Physical and Chemical Properties Page
And In the Physical and Chemical Properties Section, set the option in section: 'Primary Physical State' to: Liquid
And In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Liquid
And In the Physical and Chemical Properties Section, for section: 'Relative Density' enter text: 20
And In the Physical and Chemical Properties Section, for section: 'pH' enter text: 7
And In the Physical and Chemical Properties Section, for section: 'Boiling Point (in Celsius)' enter text: 75
And In the Physical and Chemical Properties Section, for section: 'Flash Point (in Celsius)' select the checkbox option: 'I do not have exact Flash Point data available to me'
And In the Physical and Chemical Properties Section, set the option in section: 'Flash Point (in Celsius)' to: None, No Flash Point
And In the Physical and Chemical Properties Section, for section: 'Flash Point Testing Method Used': the following options should be displayed exclusively:
| Option                   |
| Not Tested/Unknown |
And In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Insoluble in water
Then in the Physical and Chemical Properties page, I click Continue

#And I call Shared Step 29181 (Ingredients - add any chemical) with name: Water
Then I should be on the Ingredients Page
And In the Ingredients section, add the following ingredients:
| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
| component name | Water       | 100     | False               | False         |             |
Then in the Ingredients page, I click Continue


#And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Then I should be on the Inventory Status, Prop 65 (US) Page
And In the Inventory Status, Prop 65 (US) Section, the following sections should only be displayed:
| Section                                                                                                                                                                   |
| U.S. Toxic Substances Control Act (TSCA) status                                                                                                                           |
| Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65) |
And In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
And In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
Then in the Inventory Status, Prop 65 (US) page, I click Continue

Then I should be on the Transportation Details 1 Page
And In the Transportation Details 1 Section, for section 'Product is Regulated for Transport': the following options should be displayed exclusively:
| Option                               |
| Yes                                  |
| No, due to an exemption or exception |
| Not Regulated                        |
And In the Transportation Details 1 Section, set the option in section: 'Product is Regulated for Transport': to: Yes
And In the Transportation Details 1 Section, set the option in section: 'Select all modes of transport that you've classified the product for': to: DOT
And In the Transportation Details 1 Section, set the option for DOT mode of transport to: Shipping fully regulated
Then in the Transportation Details 1 page, I click Continue
#And I call Shared Step 81311 (UN Number - enter UN1206 - confirm pre-populated select radio button - Continue)
And In the U. S. Department of Transportation (DOT) Classification Section, set the option in section: 'UN Number': to: UN1206
And In the U. S. Department of Transportation (DOT) Classification Section, verify section: 'Proper Shipping Name' contains value: Heptanes
And In the U. S. Department of Transportation (DOT) Classification Section, verify section: 'Hazard Class (select)' contains value: 3
And In the U. S. Department of Transportation (DOT) Classification Section, verify section: 'Packing Group (select)' contains value: II
Then in the U. S. Department of Transportation (DOT) Classification page, I click Continue

#And section: UN Number is highlighed in red indicating an error
#And UN Number should be showing the error messages: The UN-Number (DOT) is invalid with the selected Hazard Class and Flash Point value.|The Flash Point (50C - less than or equal to 60C) must only be used with Hazard Class 3
And In the U. S. Department of Transportation (DOT) Classification Section, verify that the section: 'UN Number' is highlighted in red indicating an error
And In the U. S. Department of Transportation (DOT) Classification Section, the section: 'UN Number' should be showing error message: Flash Point is required with Hazard Class 3
#And I call Shared Step 81310 (UN Number - enter UN1950 select Aerosol & Haz class, confirm Packing group - Continue)
Then I should be on the U. S. Department of Transportation (DOT) Classification Page
And In the U. S. Department of Transportation (DOT) Classification Section, set the option in section: 'UN Number': to: UN1950
And In the U. S. Department of Transportation (DOT) Classification Section, set the option in section: 'Proper Shipping Name': to: Aerosols
And In the U. S. Department of Transportation (DOT) Classification Section, set the option in section: 'Hazard Class': to: 2.1
And In the U. S. Department of Transportation (DOT) Classification Section, set the option in section: 'Packing Group': to: None
Then in the U. S. Department of Transportation (DOT) Classification page, I click Continue

And I should not see any error messages on the page

#And I You may see the Ecologo readiness step depending on your subscription.  If you see the Ecologo step use the shared step below.  If you do not see it skip to step 29
And If ECOLOGO Readiness page is displayed I call Shared Step 57712 - ECOLOGO Readiness Assessment - Not at this time - Continue - Happy Path
#And I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
Then I should be on the Regulatory Documents to Provide Page
And In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
Then in the Regulatory Documents to Provide page, I click Continue

And I should be on the Additional Documents to Provide Page
Then in the Additional Documents to Provide page, I click Continue
And I should be on the Optional Reports and Documents Available for Purchase Page
Then in the Optional Reports and Documents Available for Purchase page, I click Continue

#And I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
#| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
Then I should be on the Safety Data Sheet Authoring - Additional Data (Optional) Page
And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Personal Protection Equipment Recommended (select)' to: Gloves
And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Autoignition Temperature (°C)' enter text: 500
And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Minimum Ignition Energy (mJ)' enter text: 9
And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Viscosity' enter text: 12.0
And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Appearance' to: Black
And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor' to: Odorless
And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor Threshold' to: No data available
And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Partition Coefficient' enter text: 1
Then in the Safety Data Sheet Authoring - Additional Data (Optional) page, I click Continue

#And I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Test Comment
Then I should be on the Optional Comments Page
And In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: Test Comment
Then in the Optional Comments page, I click Continue
And I should see the Data Acceptance Page
Given I click the Summary button in the Data Acceptance window
Then I switch to the Data Summary page
And I close the window that opened
And I navigate to the home page
And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase74382
