@Shared
@Studio
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
@run_Flow9
@UPC
@StepsPrototype
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:NewProduct
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:ProductInformation
@PhysicalAndChemicalProp
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:RegulatoryDocumentsToProvide
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:OptionalComments
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:DataAcceptance
@Ingredients
@LiquidCoreProduct
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:InventoryStatusProp65
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:Retailer
@SafetyDataSheetAuthoring
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:Product
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:TheProduct
@RegulatoryInformation3
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:InventoryStatusProp65
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:TransportationDetails1
@GTINAndUPC
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:AdditionalDocumentsToProvide
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:Summary
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:PurchaseSummary

Feature: Flow 9

@TestCase:58072
Scenario: [58072] Baby/Infant/Adult Care/Cleansing Wipes - RU000248
	#Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC58072
	Given I delete all products with UPC Number: saved as UPC58072
	#Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration '
	Then in the New Product page, I click Continue

	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Baby/infant/Adult Care/Cleansing Wipes
	Then I save the product information as: TestCase58072
	#Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Given I should see the Product Information Page
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)' to: No
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue

	#Given I call Shared Step 32931 (Liquid Core Product - select  No - Happy Path)
	Given I should see the Liquid Core Product Page
	Then In the Liquid Core Product Section, set the option in section: 'Is there a free liquid in the Product's container that is 10ml or greater?' to: No
	Then in the Liquid Core Product page I click Continue

	#Given I call Shared Step 37857 (Enter Physical Property - Solid)
	Given I should see the Physical and Chemical Properties Page
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' confirm option is selected: Solid
	Then In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
	Then In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Then In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
	Then in the Physical and Chemical Properties page I click Continue
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName    | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Aqua             | 10      | false               | false       |            |
		| Benzoic acid     | 4.5     | false               | false       |            |
		| Citric acid      | 25      | false               | false       |            |
		| Cetearyl alcohol | 40.4    | false               | false       |            |
		| Glycerin         | 20.1    | false               | false       |            |
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

#	Given I call Shared Step 57507 (Transportation Details 1- Not Regulated - Continue - Happy Path)
	Then I should be on the Transportation Details 1 Page
	And In the Transportation Details 1 Section, set the option in section: 'Product is Regulated for Transport': to: Not Regulated
	Then in the Transportation Details 1 page, I click Continue

#	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Walgreens
	Then I should be on the Retailer Page
	And In the Retailer Section, click 'Add Retailers' button
	And In the Select Retailers window, select retailer: Walgreens
	And In the Select Retailers window, click 'Done' button
	Then in the Retailer page, I click Continue

	Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC58072, container type: Plastic Container and size: 10.0
	#Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
	Then in the Regulatory Documents to Provide page I click Continue

	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
#	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
#		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient |
#		| Gloves                        | 150                      | 25.0                    | 11.2      | White      | Floral | No data available | 10                    |
	Then I should be on the Safety Data Sheet Authoring - Additional Data (Optional) Page
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Personal Protection Equipment Recommended (select)' to: Gloves
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Autoignition Temperature' enter text: 150
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Minimum Ignition Energy (mJ)' enter text: 25.0
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Viscosity' enter text: 11.2
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Appearance' to: White
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor' to: Floral
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor Threshold' to: No data available
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Partition Coefficient' enter text: 10
	Then in the Safety Data Sheet Authoring - Additional Data (Optional) page, I click Continue


	#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: User added Comments Text 58072. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Baby/infant/Adult Care/Cleansing Wipes
	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase58072
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase58072
@newproductstepstest
@TestCase:58098
Scenario: [58098] Ingredient Table - Selecting Publicly Disclosed/Label Name
	#Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load
	#Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration '
	Then in the New Product page, I click Continue
	#Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk
	Given I should see the The Product Page
	Given In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Chalk
	Given In the Product Section, set the option in section: 'Type of Product (select)' to: Chalk
 	Given in the The Product page I click Continue
	Then I save the product information as: TestCase58098
	#Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Given I should see the Product Information Page
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)' to: No
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue
	#Given I call Shared Step 37857 (Enter Physical Property - Solid)
	Given I should see the Physical and Chemical Properties Page
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' confirm option is selected: Solid
	Then In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
	Then In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Then In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
	Then in the Physical and Chemical Properties page I click Continue
	Given I should see the Ingredients Page
	Then In the Ingredients section, add component with component name: Water
	Then In the Ingredients Table row with component name: Water, in Percent column text input enter: 100
	Then In the Ingredients Table row with component name: Water, in Public Name column select option Water
	Then In the Ingredients Table row with component name: Water, in Public Name column select confirm Water option is selected
	Then In the Ingredients Table row with component name: Water, in Publicly Disclosed? column confirm checkbox is checked
	Then In the Ingredients Table row with component name: Water, in Trade Secret column confirm checkbox is disabled
	Then In the Ingredients section, add component with component name: Carbon
	Then In the Ingredients Table row with component name: Carbon, in Percent column text input enter: 100
	Then In the Ingredients section, add component with component name: Gold
	Then In the Ingredients Table row with component name: Gold, in Percent column text input enter: 100
	Then In the Ingredients Section, click the component search box
	Then In the Ingredients section, verify Transparency displays value: 33.33%
	Then In the Ingredients section, verify Total Percent displays value: 300
	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase58098
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase58098
	
	@TestCase:58078
	Scenario: [58078] Energy or Nutritional Bars - RU000618
	#Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC58078
	Given I delete all products with UPC Number: saved as UPC58078

	#Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration '
	Then in the New Product page, I click Continue

	#Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Energy or Nutritional Bars
	Given I should see the The Product Page
	Given In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Energy or Nutritional Bars
	Given In the Product Section, set the option in section: 'Type of Product (select)' to: Energy or Nutritional Bars
 	Given in the The Product page I click Continue
	Then I save the product information as: TestCase58078

	#Given I call Shared Step 57401 (Product Information - US only - No GHS, Not Direct Ship, Not PLP, Not GNFR > Continue - Happy Path)
	Given I should see the Product Information Page
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue

	#Given I call Shared Step 37857 (Enter Physical Property - Solid) with the following inputs:
	#	| Secondary Physical State | Water Solubility |
	#	| Granular                 | Dispersible      |
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' confirm option is selected: Solid
	Then In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
	Then In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Then In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
	Then in the Physical and Chemical Properties page I click Continue

	#Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
	#	| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
	#	| Water         | 100     | false               | false       |            |
	Given I should see the Ingredients Page
	Then In the Ingredients section, add component with component name: Water
	Then In the Ingredients Table row with component name: Water, in Percent column text input enter: 100
	Given I click continue

	#Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I should see the Inventory Status, Prop 65 (US) Page
	Then In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	Then In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page I click Continue

	#Then I call Shared Step 132473 (Regulatory Information 3 - Nutritional Category)
	Given I should see the Product Labeling Page
	Then In the Product Labeling Section, the statement 'Based on the product's recommended use and formulation, this is a possible Nutritional Supplement. Please complete the additional question below to ensure proper classification of this product for the retailer(s).' is displayed
	Then In the Product Labeling Section, in section: 'Refer to your Product Label.  From the options, select those that appear on the Label.' displayed options are:
	| Option                 |
	| Supplement Facts Panel |
	| Nutrition Facts Panel  |
	| None of the Above      |
	Then In the Product Labeling Section, in section: 'Refer to your Product Label.  From the options, select those that appear on the Label.' click the checkbox option: Nutrition Facts Panel
	Then In the Product Labeling Section, the following link: Nutritional and Supplement Labels should be displayed
	Then In the Product Labeling Section, the following link: Dietary Supplements Label should be displayed
	Then in the Product Labeling page I click Continue

	#Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: CVS
	Then I should be on the Retailer Page
	And In the Retailer Section, click 'Add Retailers' button
	Then In the Retailer Section is selected retailer: No Retailer/No UPC Product
	And In the Select Retailers window, select retailer: CVS
	And In the Select Retailers window, click 'Done' button
	Then in the Retailer page, I click Continue

	#Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC58078, container type: Plastic Container and size: 3.6
	Given I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, I click the Add UPC Button
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, for section: 'Provide the product's UPC(s)- including container type and size (ounces)' enter UPC Number: saved as UPC58078 enter Size: 12 and enter Container Type: Plastic bag
	Then in the Global Trade Item Number (GTIN) / Universal Product Code (UPC) page I click Continue
	#Given I call Shared Step 132601 (Additional Documents to Provide - Nutritional Flow)
	Given I should see the Additional Documents to Provide Page
	Then In the Additional Documents to Provide, section 'OSHA-compliant Safety Data Sheet (Optional)' is displayed
	Then In the Additional Documents to Provide, section 'Toxicity Characteristic Leaching Procedure (TCLP)' is displayed
	Then In the Additional Documents to Provide, upload PDF document to Upload Full Product Label (required) field
	Then I save the current window handle to context as: MainWindowHandle
	Then In the Additional Documents to Provide, for section Product Label I click button 'View'
	Then In the Additional Documents to Provide, after clicking 'View' button I confirm pdf file is downloaded
	Then in the Additional Documents to Provide  page I click Continue
	Then I close All the current windows except the Main Window
	Given I should see the Optional Reports and Documents Available for Purchase Page
	Then in the Optional Reports and Documents Available for Purchase  page I click Continue
	#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: User added Comments Text 58078. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' is available
	Then in the Optional Comments page I click Continue
	#Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Energy or Nutritional Bars
	Given I should see the Data Acceptance Page
	Then In the Data Acceptance Section, click 'Summary' button
	Given I switch to the tab with Data Summary page
	Given In the Summary Page, the 'Type of Product (select)' section should be showing the following value: Energy or Nutritional Bars
	Given I close the tab with Data Summary page
    Given I should see the Data Acceptance Page
	Given I navigate to the home page
	Then I delete the product: TestCase58078

@TestCase:58079
Scenario: [58079] Energy or Nutritional Powder/Mix - RU000706
	#Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC58079
	Given I delete all products with UPC Number: saved as UPC58079
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration '
	Then in the New Product page, I click Continue
	#Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Energy or Nutritional Powder/Mix
	Given I should see the The Product Page
	Given In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Energy or Nutritional Powder/Mix
	Given In the Product Section, set the option in section: 'Type of Product (select)' to: Energy or Nutritional Powder/Mix
 	Given in the The Product page I click Continue
	Then I save the product information as: TestCase58079
	#Given I call Shared Step 57401 (Product Information - US only - No GHS, Not Direct Ship, Not PLP, Not GNFR > Continue - Happy Path)
	Given I should see the Product Information Page
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue
	#Given I call Shared Step 37857 (Enter Physical Property - Solid) with the following inputs:
	#	| Secondary Physical State | Water Solubility |
	#	| Flaked                   | Soluble in water |
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' confirm option is selected: Solid
	Then In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
	Then In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Then In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
	Then in the Physical and Chemical Properties page I click Continue
	#Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
	#	| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
	#	| Water         | 100     | false               | false       |            |
	Given I should see the Ingredients Page
	Then In the Ingredients section, add component with component name: Water
	Then In the Ingredients Table row with component name: Water, in Percent column text input enter: 100
	Given I click continue
	#Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I should see the Inventory Status, Prop 65 (US) Page
	Then In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	Then In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page I click Continue
	#Then I call Shared Step 132473 (Regulatory Information 3 - Nutritional Category)
	Given I should see the Product Labeling Page
	Then In the Product Labeling Section, the statement 'Based on the product's recommended use and formulation, this is a possible Nutritional Supplement. Please complete the additional question below to ensure proper classification of this product for the retailer(s).' is displayed
	Then In the Product Labeling Section, in section: 'Refer to your Product Label.  From the options, select those that appear on the Label.' displayed options are:
	| Option                 |
	| Supplement Facts Panel |
	| Nutrition Facts Panel  |
	| None of the Above      |
	Then In the Product Labeling Section, in section: 'Refer to your Product Label.  From the options, select those that appear on the Label.' click the checkbox option: Nutrition Facts Panel
	Then In the Product Labeling Section, the following link: Nutritional and Supplement Labels should be displayed
	Then In the Product Labeling Section, the following link: Dietary Supplements Label should be displayed
	Then in the Product Labeling page I click Continue
	#Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Save Mart Supermarkets
	Then I should be on the Retailer Page
	And In the Retailer Section, click 'Add Retailers' button
	Then In the Retailer Section is selected retailer: No Retailer/No UPC Product
	And In the Select Retailers window, select retailer: CVS
	And In the Select Retailers window, click 'Done' button
	Then in the Retailer page, I click Continue
	#Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC58078, container type: Plastic Container and size: 3.6
	Given I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, I click the Add UPC Button
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, for section: 'Provide the product's UPC(s)- including container type and size (ounces)' enter UPC Number: saved as UPC58079 enter Size: 12 and enter Container Type: Plastic bag
	Then in the Global Trade Item Number (GTIN) / Universal Product Code (UPC) page I click Continue
	#Given I call Shared Step 132601 (Additional Documents to Provide - Nutritional Flow)
	Given I should see the Additional Documents to Provide Page
	Then In the Additional Documents to Provide, section 'OSHA-compliant Safety Data Sheet (Optional)' is displayed
	Then In the Additional Documents to Provide, section 'Toxicity Characteristic Leaching Procedure (TCLP)' is displayed
	Then In the Additional Documents to Provide, upload PDF document to Upload Full Product Label (required) field
	Then I save the current window handle to context as: MainWindowHandle
	Then In the Additional Documents to Provide, for section Product Label I click button 'View'
	Then In the Additional Documents to Provide, after clicking 'View' button I confirm pdf file is downloaded
	Then in the Additional Documents to Provide  page I click Continue
	Then I close All the current windows except the Main Window
	Given I should see the Optional Reports and Documents Available for Purchase Page
	Then in the Optional Reports and Documents Available for Purchase  page I click Continue
	#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: User added Comments Text 58078. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' is available
	Then in the Optional Comments page I click Continue
	#Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Energy or Nutritional Bars
	Given I should see the Data Acceptance Page
	Then In the Data Acceptance Section, click 'Summary' button
	Given I switch to the tab with Data Summary page
	Given In the Summary Page, the 'Type of Product (select)' section should be showing the following value: Energy or Nutritional Powder/Mix
	Given I close the tab with Data Summary page
    Given I should see the Data Acceptance Page
	Given I navigate to the home page
	Then I delete the product: TestCase58079

@TestCase:58073
Scenario: [58073] Footwear - Gel Insert - RU000854
	#Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC58073
	Given I delete all products with UPC Number: saved as UPC58073
	#Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration '
	Then in the New Product page, I click Continue

	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Footwear - Gel Insert
	Given I should see the The Product Page
	Given In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Footwear - Gel Insert
	Given In the Product Section, set the option in section: 'Type of Product (select)' to: Footwear - Gel Insert
 	Given in the The Product page I click Continue
	Then I save the product information as: TestCase58073
	#Given I call Shared Step 57401 (Product Information - US only - No GHS, Not Direct Ship, Not PLP, Not GNFR > Continue - Happy Path)
	Given I should see the Product Information Page
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue
	Given I call Shared Step 37857 (Enter Physical Property - Solid) with the following inputs:
		| Secondary Physical State | Water Solubility |
		| Solid                    | Dispersible      |
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Water         | 100     | false               | false       |            |
	#Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I should see the Inventory Status, Prop 65 (US) Page
	Then In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	Then In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page I click Continue

	
#	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: CVS
	Then I should be on the Retailer Page
	And In the Retailer Section, click 'Add Retailers' button
	And In the Select Retailers window, select retailer: CVS
	And In the Select Retailers window, click 'Done' button
	Then in the Retailer page, I click Continue

	Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC58073, container type: Plastic bag and size: 8
	#Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
	Then in the Regulatory Documents to Provide page I click Continue

	#Given I call Shared Step 60567 (Upload Product Label only)
	Given I should see the Regulatory Documents to Provide Page
	Given in the Regulatory Documents to Provide page I click Continue
	Then In the Regulatory Documents to Provide Section: 'Upload Full Product Label (required) (For private label products please upload a generic label that is not retailer-specific.)' error message should display: Document is required: Product Label
	Then In the Regulatory Documents to Provide Section, upload file in section: 'Upload Full Product Label (required) (For private label products please upload a generic label that is not retailer-specific.)'
	Given in the Regulatory Documents to Provide page I click Continue

	Given in the Optional Reports and Documents Available for Purchase page I click Continue
#	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
#		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
#		| Gloves                        | 800                      | 99                      | 60        | Clear      | Odorless | No data available | 11.2                  |
	Then I should be on the Safety Data Sheet Authoring - Additional Data (Optional) Page
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Personal Protection Equipment Recommended (select)' to: Gloves
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Autoignition Temperature' enter text: 800
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Minimum Ignition Energy (mJ)' enter text: 99
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Viscosity' enter text: 60
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Appearance' to: Clear
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor' to: Odorless
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor Threshold' to: No data available
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Partition Coefficient' enter text: 10
	Then in the Safety Data Sheet Authoring - Additional Data (Optional) page, I click Continue


	#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: User added Comments Text 58073. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Footwear - Gel Insert
	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase58073
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase58073

@TestCase:63325
Scenario: [63325] Herbal or Dietary Supplements - RU000712 Flow 9-LS (checking SDS step shows only product label and Additional documents to provide shows SDS as optional)
	#Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration '
	Then in the New Product page, I click Continue
	#Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Herbal or Dietary Supplement
	Given I should see the The Product Page
	Given In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Herbal or Dietary Supplement
	Given In the Product Section, set the option in section: 'Type of Product (select)' to: Herbal or Dietary Supplement
 	Given in the The Product page I click Continue
	Then I save the product information as: TestCase63325
	#Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Given I should see the Product Information Page
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)' to: No
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue
	#Given I call Shared Step 57501 (Physical and Chemical Properties - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue - HP)
	Given I should see the Physical and Chemical Properties Page
	Given In the Physical and Chemical Properties Section, set the option in section: 'Primary Physical State' to: Solid
	Given In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Bonded, fibrous glass web
	Given In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Given In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
	Then in the Physical and Chemical Properties page I click Continue
	#Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Water
	Given I should see the Ingredients Page
	Then In the Ingredients section, add component with component name: Water
	Then In the Ingredients Table row with component name: Water, in Percent column text input enter: 100
	Given I click continue
	#Then I call Shared Step 132427 (Waste Classification Data- For OTC Products)
	Given I should see the Inventory Status, Prop 65 (US) Page
	Then In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page I click Continue
	#Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
	Given I should see the Product Labeling Page
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
	Then in the Product Labeling page I click Continue
	#Given I call Shared Step 26900 (Transportation Details 1 > Not Regulated)
	Given I should see the Transportation Details 1 Page
	Then in the Transportation Details 1  page I click Continue
	Then In the Transportation Details 1 Section, the error 'This is a required field' is displayed for section 'Product is Regulated for Transport'
	Then In the Transportation Details 1 Section, set the option in section: 'Product is Regulated for Transport': to: Not Regulated
	Then in the Transportation Details 1  page I click Continue
	#Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	Then I should be on the Retailer Page
	And In the Retailer Section, click 'Add Retailers' button
	Then In the Retailer Section is selected retailer: No Retailer/No UPC Product
	And In the Select Retailers window, click 'Done' button
	Then in the Retailer page, I click Continue
	Then I should see the Regulatory Documents to Provide Page
	Then in the Regulatory Documents to Provide  page I click Continue
	Then In the Regulatory Documents to Provide Section: 'Upload Full Product Label (required) (For private label products please upload a generic label that is not retailer-specific.)' error message should display: Document is required: Product Label
	Then In the Regulatory Documents to Provide Section, upload file in section: 'Upload Full Product Label (required) (For private label products please upload a generic label that is not retailer-specific.)'
	Given in the Regulatory Documents to Provide page I click Continue
	Then I should see the Additional Documents to Provide Page
	Then In the Additional Documents to Provide, section 'Upload SDS (Optional)' is displayed
	Then In the Additional Documents to Provide, section 'Toxicity Characteristic Leaching Procedure (TCLP)' is displayed
	Then in the Additional Documents to Provide  page I click Continue
	Then I should see the Optional Reports and Documents Available for Purchase Page
	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase63325
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase63325

@TestCase:58091
Scenario: [58091] Latex Gloves - RU000151

	#Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load

	Given I generate a random UPC number and save as: UPC58091
	Given I delete all products with UPC Number: saved as UPC58091

	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration '
	Then in the New Product page, I click Continue

	#Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Latex gloves
	Given I should see the The Product Page
	Given In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Latex gloves_#58091
	Given In the Product Section, set the option in section: 'Type of Product (select)' to: Latex gloves
 	Given in the The Product page I click Continue

	Then I save the product information as: TestCase58091

	#Given I call Shared Step 57401 (Product Information - US only - No GHS, Not Direct Ship, Not PLP, Not GNFR > Continue - Happy Path)
	Given I should see the Product Information Page
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue

	#Given I call Shared Step 37857 (Enter Physical Property - Solid)
	Given I should see the Physical and Chemical Properties Page
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' confirm option is selected: Solid
	Then In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
	Then In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Then In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
	Then in the Physical and Chemical Properties page I click Continue

	#Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
	#	| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
	#	| Water         | 100     | false               | false       |            |
	Given I should see the Ingredients Page
	Then In the Ingredients section, add component with component name: Water
	Then In the Ingredients Table row with component name: Water, in Percent column text input enter: 100
	Given I click continue

	#Then I call Shared Step 132427 (Waste Classification Data- For OTC Products)
	Given I should see the Inventory Status, Prop 65 (US) Page
	Then In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page I click Continue

	# ---- Added these steps,test case in Azure needs to be updated in order to match the flow on the screen - 03/14/25 -----
	Given I should see the Product Labeling Page
	Then In the Product Labeling Section, in section: 'Refer to your Product Label.  From the options, select those that appear on the Label.' click the checkbox option: None of the Above
	Then in the Product Labeling page I click Continue

	#Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Walgreens
	Then I should be on the Retailer Page
	And In the Retailer Section, click 'Add Retailers' button
	Then In the Retailer Section is selected retailer: No Retailer/No UPC Product
	And In the Select Retailers window, select retailer: Walgreens
	And In the Select Retailers window, click 'Done' button
	Then in the Retailer page, I click Continue

	#Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC58091, container type: Plastic Container and size: 37
	Given I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, I click the Add UPC Button
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, for section: 'Provide the product's UPC(s)- including container type and size (ounces)' enter UPC Number: saved as UPC58091 enter Size: 12 and enter Container Type: Plastic bag
	Then in the Global Trade Item Number (GTIN) / Universal Product Code (UPC) page I click Continue

	#Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	# ----removed this step because it does not appear on the screen, test case needs to be updated in Azure - 03/14/25 ----
	#Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
	And In the Regulatory Documents to Provide Section, upload file in section: 'Upload Full Product Label (required) (For private label products please upload a generic label that is not retailer-specific.)'
	Then in the Regulatory Documents to Provide page I click Continue

	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue

	# ----removed these steps because it does not appear on the screen, test case needs to be updated in Azure - 03/14/25 ----
	#Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
	#		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
	#		| Mask                          | 400                      | 60                      | 2.2       | White      | Odorless | No data available | 1.5                   |
	#Then I should be on the Safety Data Sheet Authoring - Additional Data (Optional) Page
	#And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Personal Protection Equipment Recommended (select)' to: Mask
	#And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Autoignition Temperature' enter text: 400
	#And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Minimum Ignition Energy (mJ)' enter text: 60
	#And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Viscosity' enter text: 2.2
	#And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Appearance' to: White
	#And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor' to: Odorless
	#And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor Threshold' to: No data available
	#And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Partition Coefficient' enter text: 1.5
	#Then in the Safety Data Sheet Authoring - Additional Data (Optional) page, I click Continue

	#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: User added Comments Text 58091. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	#Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Latex gloves
	Given I should see the Data Acceptance Page
	Then In the Data Acceptance Section, click 'Summary' button
	Given I switch to the tab with Data Summary page
	Given In the Summary Page, the 'Type of Product (select)' section should be showing the following value: Latex gloves
	Given I close the tab with Data Summary page
    Given I should see the Data Acceptance Page

	#Replace shared 42214
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase58091

@TestCase:58075
Scenario: [58075] Nutritional Supplement for Infants - Liquid - RU001365
	#Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC58075
	Given I delete all products with UPC Number: saved as UPC58075
#	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration '
	Then in the New Product page, I click Continue

	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Nutritional Supplement for Infants - Liquid
	Given I should see the The Product Page
	Given In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Nutritional Supplement for Infants - Liquid
	Given In the Product Section, set the option in section: 'Type of Product (select)' to: Nutritional Supplement for Infants - Liquid
 	Given in the The Product page I click Continue
	Then I save the product information as: TestCase58075
	#Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Given I should see the Product Information Page
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)' to: No
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue

	Then I call Shared Step 57441 (Physical and Chemical Properties - Primary Physical Property - Liquid)
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Aqua          | 65      | false               | false       |            |
		| Vitamin A     | 5       | false               | false       |            |
		| Citric acid   | 25      | false               | false       |            |
		| Vitamin E     | 5       | false               | false       |            |
	# Added in 57637 to make test run. Consult Aaron (WERCS)
	#Given I call Shared Step 57637 (Regulatory Information 1 - TSCA & CEPA shown, No to PROP 65 - Continue - Happy Path)
	#Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I should see the Inventory Status, Prop 65 (US) Page
	Then In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	Then In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page I click Continue

	#Then I call Shared Step 132473 (Regulatory Information 3 - Nutritional Category)
	Given I should see the Regulatory Information 3 Page
	Then In the Regulatory Information 3 Section, the statement 'Based on the product's recommended use and formulation, this is a possible Nutritional Supplement. Please complete the additional question below to ensure proper classification of this product for the retailer(s).' is displayed
	Then In the Regulatory Information 3 Section, in section: 'Refer to your Product Label.  From the options, select those that appear on the Label.' displayed options are:
	| Option                 |
	| Supplement Facts Panel |
	| Nutrition Facts Panel  |
	| None of the Above      |
	Then In the Regulatory Information 3 Section, in section: 'Refer to your Product Label.  From the options, select those that appear on the Label.' click the checkbox option: Nutrition Facts Panel
	Then In the Regulatory Information 3 Section, the following link: Nutritional and Supplement Labels should be displayed
	Then In the Regulatory Information 3 Section, the following link: Dietary Supplements Label should be displayed
	Then in the Regulatory Information 3 page I click Continue

#	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: CVS
	Then I should be on the Retailer Page
	And In the Retailer Section, click 'Add Retailers' button
	And In the Select Retailers window, select retailer: CVS
	And In the Select Retailers window, click 'Done' button
	Then in the Retailer page, I click Continue

	Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC58075, container type: Plastic Container and size: 100
	Then I see the following sections
		| Section                    |
		| Flash Point Testing Report |
	#Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	#Given I call Shared Step 132601 (Additional Documents to Provide - Nutritional Flow)
	Given I should see the Additional Documents to Provide Page
	Then In the Additional Documents to Provide, section 'OSHA-compliant Safety Data Sheet (Optional)' is displayed
	Then In the Additional Documents to Provide, section 'Toxicity Characteristic Leaching Procedure (TCLP)' is displayed
	Then In the Additional Documents to Provide, upload PDF document to Upload Full Product Label (required) field
	Then I save the current window handle to context as: MainWindowHandle
	Then In the Additional Documents to Provide, for section Product Label I click button 'View'
	Then In the Additional Documents to Provide, after clicking 'View' button I confirm pdf file is downloaded
	Then in the Additional Documents to Provide  page I click Continue	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: User added Comments Text 58075. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	Given I navigate to the home page
	Then I delete the product: TestCase58075

@TestCase:58089
Scenario: [58089] Nutritional Supplements for Domesticated Animals - RU001239
	#Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC58089
	Given I delete all products with UPC Number: saved as UPC58089
	#Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration '
	Then in the New Product page, I click Continue

	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Nutritional Supplements for Domesticated Animals
	Then I save the product information as: TestCase58089
	#Given I call Shared Step 57401 (Product Information - US only - No GHS, Not Direct Ship, Not PLP, Not GNFR > Continue - Happy Path)
	Given I should see the Product Information Page
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue
	Then I call Shared Step 57441 (Physical and Chemical Properties - Primary Physical Property - Liquid)
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Aqua          | 65      | false               | false       |            |
		| Vitamin A     | 10      | false               | false       |            |
		| Citric acid   | 25      | false               | false       |            |
	# Added in 57637 to make test run. Ask Wercs testers
	#Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Then I should be on the Inventory Status, Prop 65 (US) Page
	And In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	And In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page, I click Continue

	#Then I call Shared Step 132473 (Regulatory Information 3 - Nutritional Category)
	Given I should see the Regulatory Information 3 Page
	Then In the Regulatory Information 3 Section, the statement 'Based on the product's recommended use and formulation, this is a possible Nutritional Supplement. Please complete the additional question below to ensure proper classification of this product for the retailer(s).' is displayed
	Then In the Regulatory Information 3 Section, in section: 'Refer to your Product Label.  From the options, select those that appear on the Label.' displayed options are:
	| Option                 |
	| Supplement Facts Panel |
	| Nutrition Facts Panel  |
	| None of the Above      |
	Then In the Regulatory Information 3 Section, in section: 'Refer to your Product Label.  From the options, select those that appear on the Label.' click the checkbox option: Nutrition Facts Panel
	Then In the Regulatory Information 3 Section, the following link: Nutritional and Supplement Labels should be displayed
	Then In the Regulatory Information 3 Section, the following link: Dietary Supplements Label should be displayed
	Then in the Regulatory Information 3 page I click Continue

#	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Petco
	Then I should be on the Retailer Page
	And In the Retailer Section, click 'Add Retailers' button
	And In the Select Retailers window, select retailer: Petco
	And In the Select Retailers window, click 'Done' button
	Then in the Retailer page, I click Continue

	Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC58089, container type: Plastic Container and size: 100
	Then I see the following sections
		| Section                    |
		| Flash Point Testing Report |
	#Given I call Shared Step 132601 (Additional Documents to Provide - Nutritional Flow)
	Given I should see the Additional Documents to Provide Page
	Then In the Additional Documents to Provide, section 'OSHA-compliant Safety Data Sheet (Optional)' is displayed
	Then In the Additional Documents to Provide, section 'Toxicity Characteristic Leaching Procedure (TCLP)' is displayed
	Then In the Additional Documents to Provide, upload PDF document to Upload Full Product Label (required) field
	Then I save the current window handle to context as: MainWindowHandle
	Then In the Additional Documents to Provide, for section Product Label I click button 'View'
	Then In the Additional Documents to Provide, after clicking 'View' button I confirm pdf file is downloaded
	Then in the Additional Documents to Provide  page I click Continue	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: User added Comments Text 58089. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	Given I navigate to the home page
	Then I delete the product: TestCase58089

@TestCase:58097
Scenario: [58097] Ingredient Search in Registration
	#Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load
	#Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration '
	Then in the New Product page, I click Continue
	#Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Paint balls
	Given I should see the The Product Page
	Given In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Paint balls
	Given In the Product Section, set the option in section: 'Type of Product (select)' to: Paint balls
 	Given in the The Product page I click Continue
	Then I save the product information as: TestCase58097
	#Given I call Shared Step 57401 (Product Information - US only - No GHS, Not Direct Ship, Not PLP, Not GNFR > Continue - Happy Path)
	Given I should see the Product Information Page
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
	#Given I call Shared Step 73223 (Enter Physical Property - Solid - Without Secondary Physical State)
	Given I should see the Physical and Chemical Properties Page
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' confirm option is selected: Solid
	Then In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Then In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
	Then in the Physical and Chemical Properties page I click Continue
	Given I should see the Ingredients Page
	Then In the Ingredients Section, click the component search box
	Then In the component search box, enter text: 7732-18-5
	Then In the component search box, confirm search results list is displayed
	Then In the component search box, click result where CAS number contains: 7732-18-5
	Given I navigate to the home page
	Then I delete the product: TestCase58097

@tfs_design
@ignore
@TestCase:58094
Scenario: [58094] Suppository, Laxative, Stool-Softener - RU000944
	#Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC58094
	Given I delete all products with UPC Number: saved as UPC58094
	#Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration '
	Then in the New Product page, I click Continue

	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Suppository, Laxative, Stool-Softener
	Then I save the product information as: TestCase58094
	# Missing from TFS test case
	#Given I call Shared Step 57441 (Physical and Chemical Properties - Primary Physical Property - Liquid)
	#Given I call Shared Step 57401 (Product Information - US only - No GHS, Not Direct Ship, Not PLP, Not GNFR > Continue - Happy Path)
	Given I should see the Product Information Page
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName       | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Magnesium citrate   | 15      | false               | false       |            |
		| Magnesium hydroxide | 15      | false               | false       |            |
		| Aqua                | 70      | false               | false       |            |
	#Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I should see the Inventory Status, Prop 65 (US) Page
	Then In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	Then In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page I click Continue

#	Given I call Shared Step 57507 (Transportation Details 1- Not Regulated - Continue - Happy Path)
	Then I should be on the Transportation Details 1 Page
	And In the Transportation Details 1 Section, set the option in section: 'Product is Regulated for Transport': to: Not Regulated
	Then in the Transportation Details 1 page, I click Continue

#	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Walgreens
	Then I should be on the Retailer Page
	And In the Retailer Section, click 'Add Retailers' button
	And In the Select Retailers window, select retailer: Walgreens
	And In the Select Retailers window, click 'Done' button
	Then in the Retailer page, I click Continue

	Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC58094, container type: Plastic Container and size: 100
	#Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
	Then in the Regulatory Documents to Provide page I click Continue

	#Given I call Shared Step 60567 (Upload Product Label only)
	Given I should see the Regulatory Documents to Provide Page
	Given in the Regulatory Documents to Provide page I click Continue
	Then In the Regulatory Documents to Provide Section: 'Upload Full Product Label (required) (For private label products please upload a generic label that is not retailer-specific.)' error message should display: Document is required: Product Label
	Then In the Regulatory Documents to Provide Section, upload file in section: 'Upload Full Product Label (required) (For private label products please upload a generic label that is not retailer-specific.)'
	Given in the Regulatory Documents to Provide page I click Continue

	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	#Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
	#	| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
	#	| Gloves                        | 340                      | 12                      | 20.5      | Clear      | Odorless | No data available | 5.0                   |
	Then I should be on the Safety Data Sheet Authoring - Additional Data (Optional) Page
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Personal Protection Equipment Recommended (select)' to: Gloves
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Autoignition Temperature' enter text: 800
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Minimum Ignition Energy (mJ)' enter text: 99
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Viscosity' enter text: 60
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Appearance' to: Clear
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor' to: Odorless
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor Threshold' to: No data available
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Partition Coefficient' enter text: 10
	Then in the Safety Data Sheet Authoring - Additional Data (Optional) page, I click Continue
	Given in the Optional Comments page I click Continue
		#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: User added Comments Text 58094. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	#Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given I should see the Data Acceptance Page
	Then In the Data Acceptance Section, check 'Agreed' checkbox
	Then In the Data Acceptance Section, click 'Accept' button

	And I call Shared Step 54796 (Purchase Summary)
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase58094

@tfs_design
@ignore
@TestCase:58081
Scenario: [58081] Nutritional Supplement - Solid - RU000619
	#Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC58081
	Given I delete all products with UPC Number: saved as UPC58081
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Nutritional Supplement - Solid
	Given I call Shared Step 62678 (Product Information - US & Canada, No Child, No OSHA, NO Direct ship, No PL, No NGFR - Continue, Happy path)
	#Given I call Shared Step 37857 (Enter Physical Property - Solid)
	Given I should see the Physical and Chemical Properties Page
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' confirm option is selected: Solid
	Then In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
	Then In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Then In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
	Then in the Physical and Chemical Properties page I click Continue
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Aqua          | 50      | false               | false       |            |
		| Vitamin A     | 10      | false               | false       |            |
		| Citric acid   | 30      | false               | false       |            |
		| Vitamin E     | 10      | false               | false       |            |
	#Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I should see the Inventory Status, Prop 65 (US) Page
	Then In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	Then In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page I click Continue

	#Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: CVS
	Given I should see the Retailer Page
	Then In the Retailer Section, click 'Add Retailers' button
	Then In the Select Retailers window, select retailer: CVS
	Then In the Select Retailers window, click 'Done' button
	Then in the Retailer page I click Continue

	Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC58081, container type: Plastic Container and size: 5.2621
	#Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
	Then in the Regulatory Documents to Provide page I click Continue

	#Given I call Shared Step 60567 (Upload Product Label only)
	Given I should see the Regulatory Documents to Provide Page
	Given in the Regulatory Documents to Provide page I click Continue
	Then In the Regulatory Documents to Provide Section: 'Upload Full Product Label (required) (For private label products please upload a generic label that is not retailer-specific.)' error message should display: Document is required: Product Label
	Then In the Regulatory Documents to Provide Section, upload file in section: 'Upload Full Product Label (required) (For private label products please upload a generic label that is not retailer-specific.)'
	Given in the Regulatory Documents to Provide page I click Continue

	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	#Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
	#	| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient |
	#	| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | 41.3005               |
	Then I should be on the Safety Data Sheet Authoring - Additional Data (Optional) Page
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Personal Protection Equipment Recommended (select)' to: Gloves
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Autoignition Temperature' enter text: 800
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Minimum Ignition Energy (mJ)' enter text: 99
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Viscosity' enter text: 60
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Appearance' to: Clear
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor' to: Odorless
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor Threshold' to: No data available
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Partition Coefficient' enter text: 10
	Then in the Safety Data Sheet Authoring - Additional Data (Optional) page, I click Continue
	Given in the Optional Comments page I click Continue
	#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: User added Comments Text 58081. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	#Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given I should see the Data Acceptance Page
	Then In the Data Acceptance Section, check 'Agreed' checkbox
	Then In the Data Acceptance Section, click 'Accept' button

@upctest
@TestCase:58604
Scenario: [58604] Condom - RU000937
	#Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC58604
	Given I delete all products with UPC Number: saved as UPC58604
	#Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration '
	Then in the New Product page, I click Continue

	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Condom with or without Spermicide
	Then I save the product information as: TestCase58604
	Given I call Shared Step 60310 (Product Information - Without Child question)
	#Given I call Shared Step 37857 (Enter Physical Property - Solid)
	Given I should see the Physical and Chemical Properties Page
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' confirm option is selected: Solid
	Then In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
	Then In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Then In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
	Then in the Physical and Chemical Properties page I click Continue
	#Given I call Shared Step 60310 (Product Information - Without Child question)
	Given I should see the Product Information Page
	Then In the Product Information Section, set the option in section: 'Which best describes your product, including when FIFRA 25(b) Exempt' to: Product is not a pesticide and does not make or imply a pesticidal claim on the labeling or in the product description (ex. kills, sterilizes, disinfects, sanitizes, antimicrobial)
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Given in the Product Information page I click Continue

	Given I call Shared Step 37857 (Enter Physical Property - Solid)
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Polyisoprene  | 90      | false               | false       |            |
		| Glucose       | 5       | false               | false       |            |
		| Aqua          | 5       | false               | false       |            |
	#Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Then I call Shared Step 132427 (Waste Classification Data- For OTC Products)
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
	#Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: CVS
	Then I should be on the Retailer Page
	And In the Retailer Section, click 'Add Retailers' button
	And In the Select Retailers window, select retailer: CVS
	And In the Select Retailers window, click 'Done' button
	Then in the Retailer page, I click Continue

	Then I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC58604, container type: Plastic Container and size: 6
	#Given I call Shared Step 60567 (Upload Product Label only)
	Given I should see the Regulatory Documents to Provide Page
	Given in the Regulatory Documents to Provide page I click Continue
	Then In the Regulatory Documents to Provide Section: 'Upload Full Product Label (required) (For private label products please upload a generic label that is not retailer-specific.)' error message should display: Document is required: Product Label
	Then In the Regulatory Documents to Provide Section, upload file in section: 'Upload Full Product Label (required) (For private label products please upload a generic label that is not retailer-specific.)'
	Given in the Regulatory Documents to Provide page I click Continue

	# Needed 'Additional Documents to Provide' Page step
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: User added Comments Text 58604. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Condom with or without Spermicide
	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase58604
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase58604	

# Created by Saikiran Chittampally
#Removed from regression 2024/07
@ignore
@TestCase:213910
Scenario: [213910] WERCSmart Portal and SHA Manager Test Flow for Product Type:  Grass Seed (RU000470)
	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC213910
	#Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration '
	Then in the New Product page, I click Continue

	#Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Grass Seed
	Given I should see the The Product Page
	Given In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Grass Seed
	Given In the Product Section, set the option in section: 'Type of Product (select)' to: Grass Seed
 	Given in the The Product page I click Continue
	Then I save the product information as: TestCase213910
	Given I should see the Product Information Page
	#Given I call Shared Step 214000 (Product Information - Pesticide= Not considered, Fertilizer=YES, SOLD=US, everything else = No - Continue)
	Given I should see the Product Information Page
	Then In the Product Information Section, confirm the question: 'Which best describes your product, including when FIFRA 25(b) Exempt' is displayed
	Then In the Product Information Section, set the option in section: 'Which best describes your product, including when FIFRA 25(b) Exempt' to: Product is not a pesticide and does not make or imply a pesticidal claim on the labeling or in the product description (ex. kills, sterilizes, disinfects, sanitizes, antimicrobial)
	Then In the Product Information Section, set the option in section: 'Does the product contain fertilizer (N, P, K)?' to: Yes
	Then In the Product Information Section, set the option in section: 'Nitrogen /Nitrates (“N”)' to: 21
	Then In the Product Information Section, set the option in section: 'Phosphates /Phosphorous (“P”)' to: 22
	Then In the Product Information Section, set the option in section: 'Potassium(“K”)' to: 4
	Then In the Product Information Section, set the option in section: 'Slow-Release Agent' to: 10.50
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue
	Then In the Product Information Section, a warning pop-up should be displayed with text: 'The ratio of Slow-Release Agent to Nitrogen will prohibit sale and use of the product in Pinellas County, Florida (Restricted). This is informational only and does not restrict your registration to the Retailer.'
	Then In the Product Information Section Section, in Warning modal window click 'Ok' button
	#Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	#214002 Physical and Chemical Properties - Applicable Only to Type of Product:  Grass Seed (RU000470)
	Given I should see the Physical and Chemical Properties Page
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' should be showing the option: Solid
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' confirm option is selected: Solid
	Then In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
	Then In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Then In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
	Then in the Physical and Chemical Properties page I click Continue

	Then I add the following ingredients:
		| ComponentName     | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Grass seed        | 45      | false               | false       |            |
		| Calcium carbonate | 50      | false               | false       |            |
		| Quartz            | 5       | false               | false       |            |
	Given I click continue
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
#	And I call Shared Step 57507 (Transportation Details 1- Not Regulated - Continue - Happy Path)
	Then I should be on the Transportation Details 1 Page
	And In the Transportation Details 1 Section, set the option in section: 'Product is Regulated for Transport': to: Not Regulated
	Then in the Transportation Details 1 page, I click Continue

#	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Wal-Mart/SAM'S CLUB	
	Then I should be on the Retailer Page
	And In the Retailer Section, click 'Add Retailers' button
	And In the Select Retailers window, select retailer: Wal-Mart/SAM'S CLUB
	And In the Select Retailers window, click 'Done' button
	Then in the Retailer page, I click Continue

	Given In the Retailers tab, I select the first Vendor option for retailer: Wal-Mart/SAM'S CLUB
	Then I click continue
	Given I call Shared Step 87647 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC213910, container type: Plastic bag and size: 20 do not click continue
	And I confirm that retailer "WM" is present under the 'Destination Retailers' column in the UPC table
	Then I click continue
	And  I call Shared Step 78080 (Regulatory Documents to Provide - Upload OSHA SDS)
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Test
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Grass seed
	#Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given I should see the Data Acceptance Page
	Then In the Data Acceptance Section, check 'Agreed' checkbox
	Then In the Data Acceptance Section, click 'Accept' button

	Then If purchase details are showing click confirm order
	Given I navigate to the landing page
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase213910)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Assigned Status for saved as: TestCase213910)
	Then I call Shared Step 65969 (Go to Power Designer Plus - Select your product & CKLT - Continue)
	Given I call Shared Step 209526 (WPS Studio - PD+ - set all data and publish using rule and doc queue - CKLT and MTR only) for product saved as: TestCase213910
	Given I call Shared Step 231412 I add the UsageType: PVAL: Product Value with Datacode FERTN with data: Nitrogen / Nitrates (“N”) to the Section - Applicable Only to Type of Product
	Given I confirm data code with data:Nitrogen / Nitrates (“N”) with value:21 added
	Given I remove the Datacode:Nitrogen / Nitrates (“N”) to the Section - Applicable Only to Type of Product
	Given I call Shared Step 231412 I add the UsageType: PVAL: Product Value with Datacode FERTK with data: Potassium (“K”) to the Section - Applicable Only to Type of Product
	Given I confirm data code with data:Potassium (“K”) with value:4 added
	Given I remove the Datacode:Potassium (“K”) to the Section - Applicable Only to Type of Product	
	Given I call Shared Step 231412 I add the UsageType: PVAL: Product Value with Datacode FERTP with data: Phosphates / Phosphorous (“P”) to the Section - Applicable Only to Type of Product
	Given I confirm data code with data:Phosphates / Phosphorous (“P”) with value:22 added
	Given I remove the Datacode:Phosphates / Phosphorous (“P”) to the Section - Applicable Only to Type of Product	
	Given I call Shared Step 231412 I add the UsageType: PVAL: Product Value with Datacode FERTS with data: Slow-Release Agent to the Section - Applicable Only to Type of Product
	Given I confirm data code with data:Slow-Release Agent with value:10.50 added
	Given I remove the Datacode:Slow-Release Agent to the Section - Applicable Only to Type of Product
	Given I call Shared Step 231412 I add the UsageType: PTXT: Product Text with Datacode PCFR with data: Restricted Fertilizer in Pinellas County, Florida to the Section - Applicable Only to Type of Product
	Given I confirm data code with data:Restricted Fertilizer in Pinellas County, Florida with value:May be sold only October 1 through May 31, Pinellas County, Florida added
	Given I remove the Datacode:Restricted Fertilizer in Pinellas County, Florida to the Section - Applicable Only to Type of Product
	Given I call Shared Step 59066 (Go to SHA Manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Completed Status for saved as: TestCase213910)


# Ignore execution in QA-Integration Environment as SHA Automation is set to OFF
# Created by Saikiran Chittampally
#@OnlyInStaging
@TestCase:213905
Scenario: [213905] WERCSmart Portal and SHA Manager Test Flow for Product Type: Fertilizer (RU000462)
	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC213905
	#Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration '
	Then in the New Product page, I click Continue
	#Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): FERTILIZER
	Given I should see the The Product Page
	Given In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Latex gloves
	Given In the Product Section, set the option in section: 'Type of Product (select)' to: FERTILIZER
 	Given in the The Product page I click Continue
	Then I save the product information as: TestCase213905
	#Given I call Shared Step 214000 (Product Information - Pesticide= Not considered, Fertilizer=YES, SOLD=US, everything else = No - Continue)
	Given I should see the Product Information Page
	Then In the Product Information Section, confirm the question: 'Which best describes your product, including when FIFRA 25(b) Exempt' is displayed
	Then In the Product Information Section, set the option in section: 'Which best describes your product, including when FIFRA 25(b) Exempt' to: Product is not a pesticide and does not make or imply a pesticidal claim on the labeling or in the product description (ex. kills, sterilizes, disinfects, sanitizes, antimicrobial)
	Then In the Product Information Section, set the option in section: 'Does the product contain fertilizer (N, P, K)?' to: Yes
	Then In the Product Information Section, set the option in section: 'Nitrogen /Nitrates (“N”)' to: 8
	Then In the Product Information Section, set the option in section: 'Phosphates /Phosphorous (“P”)' to: 14
	Then In the Product Information Section, set the option in section: 'Potassium(“K”)' to: 14
	Then In the Product Information Section, set the option in section: 'Slow-Release Agent' to: 3
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue
	Then In the Product Information Section, a warning pop-up should be displayed with text: 'The ratio of Slow-Release Agent to Nitrogen will prohibit sale and use of the product in Pinellas County, Florida (Restricted). This is informational only and does not restrict your registration to the Retailer.'
	Then In the Product Information Section Section, in Warning modal window click 'Ok' button
	#Given I call Shared Step 213923 (Physical and Chemical Properties - Applicable Only to Engine Fertilizer)
	Given I should see the Physical and Chemical Properties Page
	Then In the Physical and Chemical Properties Section, for section: 'Primary Physical State': the following options should be displayed exclusively:
	| Option |
	| Solid  |
	| Liquid |
	Then In the Physical and Chemical Properties Section, set the option in section: 'Primary Physical State' to: Liquid
	Then In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Liquid
	Then In the Physical and Chemical Properties Section, for section: 'Relative Density' enter text: 11.16
	Then In the Physical and Chemical Properties Section, for section: 'pH' select the checkbox option: 'I do not have exact pH data available to me'
	Then In the Physical and Chemical Properties Section, set the option in section: 'pH' to: Not tested/Unknown
	Then In the Physical and Chemical Properties Section, for section: 'Boiling Point (in Celsius)' select the checkbox option: 'I do not have exact Boiling Point data available to me'
	Then In the Physical and Chemical Properties Section, set the option in section: 'Boiling Point (in Celsius)' to: Not tested/Unknown
	Then In the Physical and Chemical Properties Section, for section: 'Flash Point (in Celsius)' select the checkbox option: 'I do not have exact Flash Point data available to me'
	Then In the Physical and Chemical Properties Section, set the option in section: 'Flash Point (in Celsius)' to: Not Tested/Unknown
	Then In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
	Then in the Physical and Chemical Properties page I click Continue
	#Ingredients - Applicable Only to Type of Product:  Fertilizer (RU000462)
	#Then I add the following ingredients:
	#	| ComponentName     | Percent | PublicallyDisclosed | TradeSecret | PublicName |
	#	| 6484-52-2        | 47.6      | false               | false       |            |
	#	| 57-13-6 | 36.1      | false               | false       |            |
	#	| 14797-55-8            | 16.3       | false               | false       |            |
	Given I should see the Ingredients Page
	Then In the Ingredients section, add component with component name: Ammonium Nitrate
	Then In the Ingredients Table row with component name: Ammonium Nitrate, in Percent column text input enter: 47.6
	Then In the Ingredients section, add component with component name: Urea
	Then In the Ingredients Table row with component name: Urea, in Percent column text input enter: 36.1
	Then In the Ingredients section, add component with component name: Nitrate
	Then In the Ingredients Table row with component name: Nitrate, in Percent column text input enter: 16.3
	Then in the Ingredients page I click Continue
	#Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I should see the Inventory Status, Prop 65 (US) Page
	Then In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	Then In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page I click Continue
	#And I call Shared Step 57507 (Transportation Details 1- Not Regulated - Continue - Happy Path)
	Then I should be on the Transportation Details 1 Page
	And In the Transportation Details 1 Section, set the option in section: 'Product is Regulated for Transport': to: Not Regulated
	Then in the Transportation Details 1 page, I click Continue
	#Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Wal-Mart/SAM'S CLUB	
	Then I should be on the Retailer Page
	And In the Retailer Section, click 'Add Retailers' button
	And In the Select Retailers window, select retailer: Wal-Mart/SAM'S CLUB
	And In the Select Retailers window, click 'Done' button
	Then In the Retailer Section, for retailer: Wal-Mart/SAM'S CLUB select 'Select Vendor' option: any
	Then in the Retailer page, I click Continue
	#Given I call Shared Step 87647 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC213905, container type: Plastic Container and size: 32 do not click continue
	Given I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, I click the Add UPC Button
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, for section: 'Provide the product's UPC(s)- including container type and size (ounces)' enter UPC Number: saved as UPC213905 enter Size: 32 and enter Container Type: Plastic Container
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, verify retailer 'WM' is present under the 'Destination Retailers' column
	Then in the Global Trade Item Number (GTIN) / Universal Product Code (UPC) page I click Continue
	#And  I call Shared Step 78080 (Regulatory Documents to Provide - Upload OSHA SDS)
	#Regulatory Documents to Provide - Applicable Only to Type of Product:  Fertilizer (RU000462)
	Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Yes, I certify that I have an OSHA-compliant SDS for this product and would like to upload it.
	Then In the Regulatory Documents to Provide Section, upload file in section: 'OSHA SDS'
	Then in the Regulatory Documents to Provide page I click Continue
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I should see the Optional Comments Page
	Then in the Optional Comments page I click Continue
	#Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Fertilizer
	#232621 Summary Tab - Data Verification - Applicable Only to FERTILIZER (RU000462)
	Given I should see the Data Acceptance Page
	Then In the Data Acceptance Section, click 'Summary' button
	Given I switch to the tab with Data Summary page
	Given In the Summary Page, the 'Type of Product (select)' section should be showing the following value: Fertilizer
	Given In the Summary Page, the 'Does the product contain fertilizer (N, P, K)?' section should be showing the following value: Yes
	Given In the Summary Page, the 'Nitrogen /Nitrates (“N”)' section should be showing the following value: 8
	Given In the Summary Page, the 'Phosphates /Phosphorous (“P”)' section should be showing the following value: 14
	Given In the Summary Page, the 'Potassium(“K”)' section should be showing the following value: 14
	Given In the Summary Page, the 'Slow-Release Agent' section should be showing the following value: 3
	Then In the Summary Page, verify table data in column Container Type showing the value: Plastic Container
	Then In the Summary Page, verify table data in column Retailers showing the value: WM
	Then In the Summary Page, verify table data for 'Document' section Supplier Uploaded in column File Name showing the value: testdoc.pdf
	Then In the Summary Page, verify table data for 'Document' section Supplier Uploaded in column Actions showing the value: View
	Given I close the tab with Data Summary page
    Given I should see the Data Acceptance Page
	#Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given I should see the Data Acceptance Page
	Then In the Data Acceptance Section, check 'Agreed' checkbox
	Then In the Data Acceptance Section, click 'Accept' button
	Given The Purchase Summary Page is displayed
	Then In the Purchase Summary page message is displayed with text: Thank you for registering your product on WERCSmart for assessment. The retailers may receive your assessment in approximately two (2) business days, if no delays in processing the assessment, and should no data issues arise.
	Then In the Purchase Summary Page, click the 'Home' button
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase213905)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Assigned Status for saved as: TestCase213905)
	Then I call Shared Step 65969 (Go to Power Designer Plus - Select your product & CKLT - Continue)
	Then I call Shared Step 209526 (Power Designer Plus - AUTHORIZE Product (Applicable Only to Products with an Uploaded OSHA-SDS / Kit Products / Products that Do NOT Require an SDS Upload)) for product saved as: TestCase213905
	Then I call Shared Step 209552 Power Designer Plus - APPLY RULES To Product
	Then I call Sared Step 214627 Power Designer Plus - PUBLISH Product (Applicable Only to Battery Products ): TestCase213905
	Given I call Shared Step 231412 I add the UsageType: PTXT: Product Text with Datacode FERT with data: Does the product contain fertilizer (P, N or K)? to the Section - Applicable Only to Type of Product
	Given I confirm data code with data:Does the product contain fertilizer (P, N or K)? with value:Yes added
	Given I remove the Datacode:Does the product contain fertilizer (P, N or K)? to the Section - Applicable Only to Type of Product
	Given I call Shared Step 231412 I add the UsageType: PVAL: Product Value with Datacode FERTN with data: Nitrogen / Nitrates (“N”) to the Section - Applicable Only to Type of Product
	Given I confirm data code with data:Nitrogen / Nitrates (“N”) with value:8 added
	Given I remove the Datacode:Nitrogen / Nitrates (“N”) to the Section - Applicable Only to Type of Product
	Given I call Shared Step 231412 I add the UsageType: PVAL: Product Value with Datacode FERTP with data: Phosphates / Phosphorous (“P”) to the Section - Applicable Only to Type of Product
	Given I confirm data code with data:Phosphates / Phosphorous (“P”) with value:14 added
	Given I remove the Datacode:Phosphates / Phosphorous (“P”) to the Section - Applicable Only to Type of Product
	Given I call Shared Step 231412 I add the UsageType: PVAL: Product Value with Datacode FERTK with data: Potassium (“K”) to the Section - Applicable Only to Type of Product
	Given I confirm data code with data:Potassium (“K”) with value:14 added
	Given I remove the Datacode:Potassium (“K”) to the Section - Applicable Only to Type of Product	
	Given I call Shared Step 231412 I add the UsageType: PVAL: Product Value with Datacode FERTS with data: Slow-Release Agent to the Section - Applicable Only to Type of Product
	Given I confirm data code with data:Slow-Release Agent with value:3 added
	Given I remove the Datacode:Slow-Release Agent to the Section - Applicable Only to Type of Product
	Given I call Shared Step 231412 I add the UsageType: PTXT: Product Text with Datacode PCFR with data: Restricted Fertilizer in Pinellas County, Florida to the Section - Applicable Only to Type of Product
	Given I confirm data code with data:Restricted Fertilizer in Pinellas County, Florida with value:Cannot be sold in Pinellas County, Florida added
	Given I remove the Datacode:Restricted Fertilizer in Pinellas County, Florida to the Section - Applicable Only to Type of Product
	Given I call Shared Step 59066 (Go to SHA Manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Completed Status for saved as: TestCase213905)
