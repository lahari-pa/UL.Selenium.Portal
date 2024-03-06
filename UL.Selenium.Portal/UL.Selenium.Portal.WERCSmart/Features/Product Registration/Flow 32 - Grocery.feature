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
@SubEnrollment
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:NewProduct
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:TheProduct
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:InventoryStatusProp65
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:ProductInformation
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:Retailer
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:RegulatoryDocumentsToProvide
@PhysicalAndChemicalProp
@Ingredients
@GTINAndUPC
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:TransportationDetails1
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:InternationalMarineClassification
@run_FLow32_Grocery

Feature: [64739] Flow 32 - Grocery


@TestCase:60774
Scenario: [60774] Food Item Dispensed by Compressed Gas - Dairy Topping - RU001244

# ====== Logging in as the correct user ====== #
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

# ====== Just checks that the correct page loads ====== #
Given If I see the retail partners page I set all data consent tiers to true for all retailers in the top section
Then The home screen should load

# ====== Test Setup - Generating + Saving UPC Number and ensuring no duplicates exist ====== #
Given I generate a random UPC number and save as: UPC60774
Given I delete all products with UPC Number: saved as UPC60774

    # ====== Given I call Shared Step 57408 (Create a New Registration via Register New Product icon) ====== #
    Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Given in the New Product page I click Continue

# ====== And I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Food Item Dispensed by Compressed Gas - Dairy Topping ====== #
And I should see the The Product Page
And I set 'Product Name' to: Food Item Dispensed by Compressed Gas - Dairy Topping
#And In the Product Type tab of the New Product Page, I enter: Food Item Dispensed by Compressed Gas - Dairy Topping in the Type of Product select field
And I set 'Type of Product' to: Food Item Dispensed by Compressed Gas - Dairy Topping
And in the The Product page I click Continue
Then I save the product information as: TestCase60774

# ====== Given I call Shared Step 60756 (Product Information with Country and every option) ====== #
And I should see the Product Information Page
And In the Product Information Section, set the option in section: 'Retailers will be selling my product at their store locations in (select either or both) ' to select: United States
And In the Product Information Section, set the option in section: 'Select the product's Country of Origin' to: United Kingdom
And In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
And In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
And In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product ' to: No
And In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
And in the Product Information page I click Continue

# Regulatory Documents to Provide Page
And I should see the Regulatory Documents to Provide Page
And In the Regulatory Documents to Provide Section, upload file in section: 'Upload Full Product Label (required) (For private label products please upload a generic label that is not retailer-specific.)'
Then in the Regulatory Documents to Provide page I click Continue

# ====== And I call Shared Step 60778 (Primary Physical Property - Packaged in gas cylinder) ====== #
And I should see the Physical and Chemical Properties Page
And In the Physical and Chemical Properties Section, set the option in section: 'Primary Physical State' to: Product is packaged in a gas cylinder (e.g., whip cream)
And In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Liquid
And In the Physical and Chemical Properties Section, for section: 'pH' enter text: 7
And In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Dispersible
And In the Physical and Chemical Properties Section, set the option in section: 'When the product has a flammable propellant, or contains ingredients with a flash point below 60⁰C then' to: This product is not classified as D001 or D003 Hazardous Waste under RCRA
And In the Physical and Chemical Properties Section, set the option in section: 'Select all potential allergens included in this product' to: Dairy
And In the Physical and Chemical Properties Section, set the option in section: 'Product is manufactured in a facility that processes, or contains' to: Dairy or products containing dairy or milk
And In the Physical and Chemical Properties Section, set the option in section: 'Product is verified and sold as' to: None of the Above
And In the Physical and Chemical Properties Section, set the option in section: 'Product contains the following sweeteners' to: None of the Above
And In the Physical and Chemical Properties Section, set the option in section: 'Product contains the following artificial dye(s)' to: None of the Above
And in the Physical and Chemical Properties page I click Continue

# ====== And I call Shared Step 57570 (Enter Ingredients) and add the following ingredients: ====== #
# ======		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName | ====== #
# ======		| Butane        | 100     | false               | false       |            | ====== #
And I should see the Ingredients Page
When in the Ingredients page I click Continue
Then I should see the ingredients error message
And The ingredients error message should be showing: ALERT! The ingredient table does not include a compressed gas (Bag-On-Valve) or a propellant. Please update your ingredients to include the propellant before proceeding.
Then In the Ingredients section, add the following ingredients:
		| SearchType     | SearchText | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
		| component name | Butane      |  100    | false                | false        |   Water    |
And in the Ingredients page I click Continue

# ====== And I call Shared Step 57506 (Transportation Details 1 - Regulated for Transport(No) - Exemption(Random) - Continue - Happy Path) ====== #
Given I should see the Inventory Status, Prop 65 (US) Page
Given In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
Given In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
Given in the Inventory Status, Prop 65 (US) page I click Continue

# ====== Following the steps from 'Shared Step' 57506 ====== #
And I should see the Transportation Details 1 Page
And In the Transportation Details 1 Section, set the option in section: 'Product is Regulated for Transport': to: Yes
Given In the Transportation Details 1 Section, set the option for IMDG mode of transport to: Shipping fully regulated
And in the Transportation Details 1 page I click Continue

# ====== Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path) ====== #
Then I should see the International Marine (IMDG) Classification Page
And In the International Marine (IMDG) Classification Section, set the option in section: 'UN Number': to: UN1950
And In the International Marine (IMDG) Classification Section, set the option in section: 'Proper Shipping Name': to: Aerosols
And In the International Marine (IMDG) Classification Section, set the option in section: 'Technical Name (if applicable)': to: My Safe Product
And In the International Marine (IMDG) Classification Section, set the option in section: 'Hazard Class (select)': to: 2
And In the International Marine (IMDG) Classification Section, set the option in section: 'Packing Group': to: None
Given in the International Marine (IMDG) Classification page I click Continue

	# ====== Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Walgreens ====== #
	Given I should see the Retailer Page
	Given In the Retailer Section, click 'Add Retailers' button
	Given In the Select Retailers window, select retailer: Walgreens
	Given In the Select Retailers window, click 'Done' button
	Given in the Retailer page I click Continue

# ====== And I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC60774, container type: Aerosol Can - Metal and size: 20 ====== #
And I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page
Given In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, I click the Add UPC Button
Given In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, for section: 'Provide the product's UPC(s)- including container type and size (ounces)' enter UPC Number: saved as UPC60774 enter Size: 20 and enter Container Type: Aerosol Can - Metal
And in the Universal Product Code (UPC) page I click Continue

# Additional Documents to Provide Page
And I should see the Additional Documents to Provide Page
Then in the Additional Documents to Provide page I click Continue

# Optional Reports and Documents Available for Purchase Page
And I should see the Optional Reports and Documents Available for Purchase Page
Then in the Optional Reports and Documents Available for Purchase page I click Continue

# ====== And I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Comments Field Text ====== #
And I should see the Optional Comments Page
And I enter the following into the comments field: Comments Field Text
Then in the Comments page I click Continue

# ====== Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Food Item Dispensed by Compressed Gas - Dairy Topping ====== #
Given I should see the Data Acceptance Page
Given I click the Summary button in the Data Acceptance window
Given I switch to the Data Summary page
Given Type of Product (select) should be showing the following option: Food Item Dispensed by Compressed Gas - Dairy Topping
Given I close the Data Summary Tab
Given I should see the Data Acceptance Page

Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase60774

@TestCase:60775
Scenario: [60775] Cooking Oil, Non-Aerosol - RU000942

# ====== Logging in as the correct user ====== #
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

# ====== Just checks that the correct page loads ====== #
Given If I see the retail partners page I set all data consent tiers to true for all retailers in the top section
Then The home screen should load

# ====== Test Setup - Generating + Saving UPC Number and ensuring no duplicates exist ====== #
Given I generate a random UPC number and save as: UPC60775
Given I delete all products with UPC Number: saved as UPC60775

    # ====== Given I call Shared Step 57408 (Create a New Registration via Register New Product icon) ====== #
    Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Given in the New Product page I click Continue

# ====== And I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Food Item Dispensed by Compressed Gas - Dairy Topping ====== #
And I should see the The Product Page
And I set 'Product Name' to: Food Item Dispensed by Compressed Gas - Dairy Topping
#And In the Product Type tab of the New Product Page, I enter: Food Item Dispensed by Compressed Gas - Dairy Topping in the Type of Product select field
And I set 'Type of Product' to: Food Item Dispensed by Compressed Gas - Dairy Topping
And in the The Product page I click Continue
Then I save the product information as: TestCase60775

# ====== Given I call Shared Step 60756 (Product Information with Country and every option) ====== #
And I should see the Product Information Page
And In the Product Information Section, set the option in section: 'Retailers will be selling my product at their store locations in (select either or both) ' to select: United States
And In the Product Information Section, set the option in section: 'Select the product's Country of Origin' to: United Kingdom
And In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
And In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
And In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product ' to: No
And In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
And in the Product Information page I click Continue

# Regulatory Documents to Provide Page
And I should see the Regulatory Documents to Provide Page
And In the Regulatory Documents to Provide Section, upload file in section: 'Upload Full Product Label (required) (For private label products please upload a generic label that is not retailer-specific.)'
Then in the Regulatory Documents to Provide page I click Continue

# ====== And I call Shared Step 60778 (Primary Physical Property - Packaged in gas cylinder) ====== #
And I should see the Physical and Chemical Properties Page
And In the Physical and Chemical Properties Section, set the option in section: 'Primary Physical State' to: Product is packaged in a gas cylinder (e.g., whip cream)
And In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Liquid
And In the Physical and Chemical Properties Section, for section: 'pH' enter text: 7
And In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Dispersible
And In the Physical and Chemical Properties Section, set the option in section: 'When the product has a flammable propellant, or contains ingredients with a flash point below 60⁰C then' to: This product is not classified as D001 or D003 Hazardous Waste under RCRA
And In the Physical and Chemical Properties Section, set the option in section: 'Select all potential allergens included in this product' to: Dairy
And In the Physical and Chemical Properties Section, set the option in section: 'Product is manufactured in a facility that processes, or contains' to: Dairy or products containing dairy or milk
And In the Physical and Chemical Properties Section, set the option in section: 'Product is verified and sold as' to: None of the Above
And In the Physical and Chemical Properties Section, set the option in section: 'Product contains the following sweeteners' to: None of the Above
And In the Physical and Chemical Properties Section, set the option in section: 'Product contains the following artificial dye(s)' to: None of the Above
And in the Physical and Chemical Properties page I click Continue

# ====== And I call Shared Step 57570 (Enter Ingredients) and add the following ingredients: ====== #
# ======		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName | ====== #
# ======		| Butane        | 100     | false               | false       |            | ====== #
And I should see the Ingredients Page
When in the Ingredients page I click Continue
Then I should see the ingredients error message
And The ingredients error message should be showing: ALERT! The ingredient table does not include a compressed gas (Bag-On-Valve) or a propellant. Please update your ingredients to include the propellant before proceeding.
Then In the Ingredients section, add the following ingredients:
		| SearchType     | SearchText | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
		| component name | Butane      |  100    | false                | false        |   Water    |
And in the Ingredients page I click Continue

#Given I Confirm the following error message is not visible " ALERT! The ingredient table does not include a compressed gas (Bag-On-Valve) or a propellant. Please update your ingredients to include the propellant before proceeding."

# ====== And I call Shared Step 57506 (Transportation Details 1 - Regulated for Transport(No) - Exemption(Random) - Continue - Happy Path) ====== #
Given I should see the Inventory Status, Prop 65 (US) Page
Given In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
Given In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
Given in the Inventory Status, Prop 65 (US) page I click Continue

# ====== Following the steps from 'Shared Step' 57506 ====== #
And I should see the Transportation Details 1 Page
And In the Transportation Details 1 Section, set the option in section: 'Product is Regulated for Transport': to: Yes
Given In the Transportation Details 1 Section, set the option for IMDG mode of transport to: Shipping fully regulated
And in the Transportation Details 1 page I click Continue

# ====== Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path) ====== #
Then I should see the International Marine (IMDG) Classification Page
And In the International Marine (IMDG) Classification Section, set the option in section: 'UN Number': to: UN1950
And In the International Marine (IMDG) Classification Section, set the option in section: 'Proper Shipping Name': to: Aerosols
And In the International Marine (IMDG) Classification Section, set the option in section: 'Technical Name (if applicable)': to: My Safe Product
And In the International Marine (IMDG) Classification Section, set the option in section: 'Hazard Class (select)': to: 2
And In the International Marine (IMDG) Classification Section, set the option in section: 'Packing Group': to: None
Given in the International Marine (IMDG) Classification page I click Continue

	# ====== Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Walgreens ====== #
	Given I should see the Retailer Page
	Given In the Retailer Section, click 'Add Retailers' button
	Given In the Select Retailers window, select retailer: Walgreens
	Given In the Select Retailers window, click 'Done' button
	Given in the Retailer page I click Continue

# ====== And I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC60775, container type: Aerosol Can - Metal and size: 20 ====== #
And I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page
Given In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, I click the Add UPC Button
Given In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, for section: 'Provide the product's UPC(s)- including container type and size (ounces)' enter UPC Number: saved as UPC60775 enter Size: 20 and enter Container Type: Aerosol Can - Metal
And in the Universal Product Code (UPC) page I click Continue

# Additional Documents to Provide Page
And I should see the Additional Documents to Provide Page
Then in the Additional Documents to Provide page I click Continue

# Optional Reports and Documents Available for Purchase Page
And I should see the Optional Reports and Documents Available for Purchase Page
Then in the Optional Reports and Documents Available for Purchase page I click Continue

# ====== And I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Comments Field Text ====== #
And I should see the Optional Comments Page
And I enter the following into the comments field: Comments Field Text
Then in the Comments page I click Continue

# ====== Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Food Item Dispensed by Compressed Gas - Dairy Topping ====== #
Given I should see the Data Acceptance Page
Given I click the Summary button in the Data Acceptance window
Given I switch to the Data Summary page
Given Type of Product (select) should be showing the following option: Food Item Dispensed by Compressed Gas - Dairy Topping
Given I close the Data Summary Tab
Given I should see the Data Acceptance Page

Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase60775
