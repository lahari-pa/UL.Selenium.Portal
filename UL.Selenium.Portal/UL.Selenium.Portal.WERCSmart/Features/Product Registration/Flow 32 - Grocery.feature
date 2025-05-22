@Shared
@LandingPage
@Login
@Homepage
@Signup
@wercsmart
@NewProduct
@ProductGrid
@StepsPrototype
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
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:OptionalComments
@run_FLow32_Grocery
@RegulatoryInformation3
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:AdditionalDocumentsToProvide
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:Summary
@SideMenu

Feature: [64739] Flow 32 - Grocery


@TestCase:60774
Scenario: [60774] Food Item Dispensed by Compressed Gas - Dairy Topping - RU001244

	#Logging in as the correct user
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

	#Just checks that the correct page loads
	Given If I see the retail partners page I set all data consent tiers to true for all retailers in the top section
	Then The home screen should load

	#Test Setup - Generating + Saving UPC Number and ensuring no duplicates exist
	Given I generate a random UPC number and save as: UPC60774
	Given I save the current window handle to context as: MainWindowHandle
	Given I delete all products with UPC Number: saved as UPC60774

    #Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
    Given In the Side Menu, click Labeled Link with Add Product title
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration'
	Given in the New Product page I click Continue

	#And I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Food Item Dispensed by Compressed Gas - Dairy Topping
	And I should see the The Product Page
	And I set 'Product Name' to: Food Item Dispensed by Compressed Gas - Dairy Topping_#60774
	#And In the Product Type tab of the New Product Page, I enter: Food Item Dispensed by Compressed Gas - Dairy Topping in the Type of Product select field
	And I set 'Type of Product' to: Food Item Dispensed by Compressed Gas - Dairy Topping
	And in the The Product page I click Continue
	Then I save the product information as: TestCase60774

	#And I call Shared Step 227373 (Product Information - Applicable Only to Type of Product:  Food Item Dispensed by Compressed Gas - Dairy Topping (RU001244))
	And I should see the Product Information Page
	And In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	And In the Product Information Section, set the option in section: 'Select the product's Country of Origin' to: United States of America
	And In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	And In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	And In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	And In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	And in the Product Information page I click Continue

	#And I call Shared Step 227375 (Physical and Chemical Properties - Applicably Only to Type of Product:  Food Item Dispensed by Compressed Gas - Dairy Topping (RU001244))
	And I should see the Physical and Chemical Properties Page
	And In the Physical and Chemical Properties Section, set the option in section: 'Primary Physical State' to: Product is packaged in a gas cylinder (e.g., whip cream)
	And In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid spray
	And In the Physical and Chemical Properties Section, for section: 'pH' select the checkbox option: 'I do not have exact pH data available to me'
	And In the Physical and Chemical Properties Section, set the option in section: 'pH' to: Not tested/Unknown
	And In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: No data available
	And In the Physical and Chemical Properties Section, set the option in section: 'When the product has a flammable propellant, or contains ingredients with a flash point below 60⁰C then' to: This product is not classified as D001 or D003 Hazardous Waste under RCRA
	And In the Physical and Chemical Properties Section, set the option in section: 'Select all potential allergens included in this product' to: Dairy
	And In the Physical and Chemical Properties Section, set the option in section: 'Product is manufactured in a facility that processes, or contains' to: Dairy or products containing dairy or milk
	And In the Physical and Chemical Properties Section, set the option in section: 'Product is verified and sold as' to: None of the Above
	And In the Physical and Chemical Properties Section, set the option in section: 'Product contains the following sweeteners' to: None of the Above
	And In the Physical and Chemical Properties Section, set the option in section: 'Product contains the following artificial dye(s)' to: None of the Above
	And in the Physical and Chemical Properties page I click Continue

	#And I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
	#	| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
	#	| Butane        | 100     | false               | false       |            |
	And I should see the Ingredients Page
	When in the Ingredients page I click Continue
	Then I should see the ingredients error message
	And The ingredients error message should be showing: ALERT! The ingredient table does not include a compressed gas (Bag-On-Valve) or a propellant. Please update your ingredients to include the propellant before proceeding.
	Then In the Ingredients section, add the following ingredients:
			| SearchType     | SearchValue   | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
			| component name | Water         | 45      | false               | false         |             |
			| component name | Milk          | 50      | false               | false         |             |
			| component name | Nitrous Oxide | 5       | false               | false         |             |
	And in the Ingredients page I click Continue

	#And I call Shared Step 57506 (Transportation Details 1 - Regulated for Transport(No) - Exemption(Random) - Continue - Happy Path)
	Given I should see the Inventory Status, Prop 65 (US) Page
	Given In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	Given In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Given in the Inventory Status, Prop 65 (US) page I click Continue

	#Following the steps from 'Shared Step' 57506
	And I should see the Transportation Details 1 Page
	And In the Transportation Details 1 Section, set the option in section: 'Product is Regulated for Transport': to: Yes
	Given In the Transportation Details 1 Section, set the option for IMDG mode of transport to: Shipping with limited quantity
	And in the Transportation Details 1 page I click Continue

	#Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)
	Then I should see the International Marine (IMDG) Classification Page
	And In the International Marine (IMDG) Classification Section, set the option in section: 'UN Number': to: UN1950
	And In the International Marine (IMDG) Classification Section, set the option in section: 'Proper Shipping Name': to: Aerosols
	And In the International Marine (IMDG) Classification Section, set the option in section: 'Technical Name (if applicable)': to: My Safe Product
	And In the International Marine (IMDG) Classification Section, set the option in section: 'Hazard Class (select)': to: 2
	And In the International Marine (IMDG) Classification Section, set the option in section: 'Packing Group': to: None
	Given in the International Marine (IMDG) Classification page I click Continue

	#Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Walgreens
	Given I should see the Retailer Page
	Given In the Retailer Section, click 'Add Retailers' button
	Given In the Select Retailers window, select retailer: Target
	Given In the Select Retailers window, click 'Done' button
	Given in the Retailer page I click Continue

	#And I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC60774, container type: Aerosol Can - Metal and size: 20
	And I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page
	Given In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, I click the Add UPC Button
	Given In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, for section: 'Provide the product's UPC(s)- including container type and size (ounces)' enter UPC Number: saved as UPC60774 enter Size: 8.2 and enter Container Type: Aerosol Can - Metal
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, under Transportation column the checkbox 'IMDG' is checked
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, under Transportation column the checkbox 'Shipping with limited quantity' is checked
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, verify retailer 'TG' is present under the 'Destination Retailers' column
	And in the Universal Product Code (UPC) page I click Continue
	
	# Regulatory Documents to Provide Page
	And I should see the Regulatory Documents to Provide Page
	And In the Regulatory Documents to Provide Section, upload file in section: 'Upload Full Product Label (required) (For private label products please upload a generic label that is not retailer-specific.)'
	Then In the Regulatory Documents to Provide Section, for section Product Label button Remove should exists
	Then In the Regulatory Documents to Provide Section, for section Product Label I click button 'Remove'
	Then In the Regulatory Documents to Provide Section, in the 'Remove Document' pop up click No button
	Then In the Regulatory Documents to Provide Section, for section Product Label button View should exists
	Then In the Regulatory Documents to Provide Section, for section Product Label I click button 'View'
	Then In the Regulatory Documents to Provide Section, after clicking 'View' button I confirm pdf file is downloaded
	#Then I close the 'Untitled' window
	Then I close All the current windows except the Main Window
	Then in the Regulatory Documents to Provide page I click Continue

	# Additional Documents to Provide Page
	And I should see the Additional Documents to Provide Page
	Then in the Additional Documents to Provide page I click Continue

	# Optional Reports and Documents Available for Purchase Page
	And I should see the Optional Reports and Documents Available for Purchase Page
	Then in the Optional Reports and Documents Available for Purchase page I click Continue

	#And I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Comments Field Text
	And I should see the Optional Comments Page
	And I enter the following into the comments field: Comments Field Text
	Then in the Comments page I click Continue

	#Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Food Item Dispensed by Compressed Gas - Dairy Topping
	Given I should see the Data Acceptance Page
	Given I click the Summary button in the Data Acceptance window
	Given I switch to the Data Summary page
	Given Type of Product (select) should be showing the following option: Food Item Dispensed by Compressed Gas - Dairy Topping
	Given I close the Data Summary Tab
	Given I should see the Data Acceptance Page

	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase60774
	Then In the Side Menu, click Labeled Link with My Products title
	Then In the Product Grid, delete the product saved as: TestCase60774

@TestCase:60775
Scenario: [60775] Cooking oil - Non-Aerosol - RU000942

	#Logging in as the correct user
	Given I log in with the account saved in TReVor as: ProductAccount

	#Just checks that the correct page loads
	Then The home screen should load

	#Test Setup - Generating + Saving UPC Number and ensuring no duplicates exist
	Given I generate a random UPC number and save as: UPC60775
	Given I delete all products with UPC Number: saved as UPC60775

    #Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
    Given In the Side Menu, click Labeled Link with Add Product title
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration'
	Given in the New Product page I click Continue

	#And I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Food Item Dispensed by Compressed Gas - Dairy Topping
	And I should see the The Product Page
	Given In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Cooking oil - Non-Aerosol_#60775
	Given In the Product Section, set the option in section: 'Type of Product (select)' to: Cooking oil - Non-Aerosol
	And in the The Product page I click Continue
	Then I save the product information as: TestCase60775

	#And I call Shared Step 60778 (Primary Physical Property - Packaged in gas cylinder)
	And I should see the Product Information Page
	And In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	And In the Product Information Section, set the option in section: 'Select the product's Country of Origin' to: United States of America
	And In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	And In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	And In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	And In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	And in the Product Information page I click Continue

	#And I call Shared Step 60779 (Physical and Chemical Properties -  Liquid - Cooking Oil - Non-Aerosol)
	And I should see the Physical and Chemical Properties Page
	And In the Physical and Chemical Properties Section, the section: 'Primary Physical State' confirm option is selected: Liquid
	And In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Liquid
	And In the Physical and Chemical Properties Section, for section: 'Relative Density' enter text: 1
	And In the Physical and Chemical Properties Section, for section: 'pH' select the checkbox option: 'I do not have exact pH data available to me'
	And In the Physical and Chemical Properties Section, set the option in section: 'pH' to: Not tested/Unknown
	And In the Physical and Chemical Properties Section, for section: 'Boiling Point (in Celsius)' select the checkbox option: 'I do not have exact Boiling Point data available to me'
	And In the Physical and Chemical Properties Section, set the option in section: 'Boiling Point (in Celsius)' to: Not tested/Unknown
	And In the Physical and Chemical Properties Section, for section: 'Flash Point (in Celsius)' enter text: 321
	And In the Physical and Chemical Properties Section, set the option in section: 'Flash Point Testing Method Used' to: Closed cup method
	And In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Insoluble in water
	And In the Physical and Chemical Properties Section, set the option in section: 'Select all potential allergens included in this product' to: None of the Above
	And In the Physical and Chemical Properties Section, set the option in section: 'Product is manufactured in a facility that processes, or contains' to: None of the Above
	And In the Physical and Chemical Properties Section, set the option in section: 'Product is verified and sold as' to: None of the Above
	And In the Physical and Chemical Properties Section, set the option in section: 'Product contains the following sweeteners' to: None of the Above
	And In the Physical and Chemical Properties Section, set the option in section: 'Product contains the following artificial dye(s)' to: None of the Above
	And in the Physical and Chemical Properties page I click Continue

	#And I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
	#	| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
	#	| Butane        | 100     | false               | false       |            |
	And I should see the Ingredients Page
	#When in the Ingredients page I click Continue
	#Then I should see the ingredients error message
	#And The ingredients error message should be showing: ALERT! The ingredient table does not include a compressed gas (Bag-On-Valve) or a propellant. Please update your ingredients to include the propellant before proceeding.
	Then In the Ingredients section, add the following ingredients:
			| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
			| component name | Brassica Oleifera       | 100     | false               | false         |             |
	And in the Ingredients page I click Continue

	#Given I Confirm the following error message is not visible " ALERT! The ingredient table does not include a compressed gas (Bag-On-Valve) or a propellant. Please update your ingredients to include the propellant before proceeding."

	#Given I call Shared Step 57713 (Enter Regulatory Information - Not Prop 65)
	Given I should see the Inventory Status, Prop 65 (US) Page
	Given In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	Given In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Given in the Inventory Status, Prop 65 (US) page I click Continue

	#Given I call Shared Step 57571 (Regulatory Information 3 - None of the Above Option)
	Given I should see the Product Labeling Page
	Given in the Product Labeling page I click Continue
	Then In the Product Labeling Section, the error 'Please select at least one option from above.' is displayed for section 'Refer to your Product Label. From the options, select those that appear on the Label.'
	Then In the Product Labeling Section, the statement 'Based on the product's recommended use and formulation, this is a possible pharmaceutical waste for California.  Please complete the additional question below to ensure proper classification of this product for the retailer(s).' is displayed
	Then In the Product Labeling Section, in section: 'Refer to your Product Label.  From the options, select those that appear on the Label.' click the checkbox option: None of the Above
	Then In the Product Labeling Section, the following link: OTC Drug Facts Label (may include Active Ingredient) should be displayed
	Then In the Product Labeling Section, the following link: Nutritional and Supplement Labels should be displayed
	Then In the Product Labeling Section, the following link: Dietary Supplements Label should be displayed
	Given in the Product Labeling page I click Continue

	#Following the steps from 'Shared Step' 57506
	And I should see the Transportation Details 1 Page
	And In the Transportation Details 1 Section, set the option in section: 'Product is Regulated for Transport': to: Not Regulated
	And in the Transportation Details 1 page I click Continue

	#Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Walgreens
	Given I should see the Retailer Page
	Given In the Retailer Section, click 'Add Retailers' button
	Given In the Select Retailers window, select retailer: Publix
	Given In the Select Retailers window, click 'Done' button
	Given in the Retailer page I click Continue

	#And I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC60775, container type: Aerosol Can - Metal and size: 20
	And I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page
	Given In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, I click the Add UPC Button
	Given In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, for section: 'Provide the product's UPC(s)- including container type and size (ounces)' enter UPC Number: saved as UPC60775 enter Size: 16 and enter Container Type: Glass Container
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, verify retailer 'PX' is present under the 'Destination Retailers' column
	And in the Universal Product Code (UPC) page I click Continue

	# Regulatory Documents to Provide Page
	And I should see the Regulatory Documents to Provide Page
	And In the Regulatory Documents to Provide Section, upload file in section: 'Upload Full Product Label (required) (For private label products please upload a generic label that is not retailer-specific.)'
	Then in the Regulatory Documents to Provide page I click Continue

	# Additional Documents to Provide Page
	And I should see the Additional Documents to Provide Page
	Then In the Additional Documents to Provide, section 'Upload SDS (Optional)' is displayed
	Then In the Additional Documents to Provide, section 'Flash Point Testing Report' is displayed
	Then In the Additional Documents to Provide, section 'Toxicity Characteristic Leaching Procedure (TCLP)' is displayed
	Then in the Additional Documents to Provide page I click Continue

	# Optional Reports and Documents Available for Purchase Page
	And I should see the Optional Reports and Documents Available for Purchase Page
	Then in the Optional Reports and Documents Available for Purchase page I click Continue

	#And I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Comments Field Text
	And I should see the Optional Comments Page
	And I enter the following into the comments field: Comments Field Text
	Then in the Comments page I click Continue

	#Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Food Item Dispensed by Compressed Gas - Dairy Topping
	Given I should see the Data Acceptance Page
	Given I click the Summary button in the Data Acceptance window
	Given I switch to the Data Summary page
	Then In the Summary Page, the 'Type of Product (select)' section should be showing the following value: Cooking oil - Non-Aerosol
	Then In the Summary Page, the 'Select the product's Country of Origin' section should be showing the following value: United States of America
	Then In the Summary Page, the 'Refer to your Product Label.  From the options, select those that appear on the Label.' section should be showing the following value: None of the Above
	Then In the Summary Page, the 'Product is Regulated for Transport' section should be showing the following value: Not Regulated
	Then In the Summary Page, verify table data in column Container Type showing the value: Glass Container
	Then In the Summary Page, verify table data in column Size (Ounces) showing the value: 16
	Then In the Summary Page, verify table data in column Retailers showing the value: PX
	Then In the Summary Page, the Product Document section Supplier Uploaded should be showing the following document: testdoc.pdf
	Then In the Summary Page, the Product Document section Supplier Uploaded click the view link for the following document: testdoc.pdf
	Then In the Summary Page, after clicking 'View' button I confirm pdf file is downloaded
	Given I close the Data Summary Tab
	Given I should see the Data Acceptance Page

	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase60775
	Then In the Side Menu, click Labeled Link with My Products title
	Then In the Product Grid, delete the product saved as: TestCase60775
