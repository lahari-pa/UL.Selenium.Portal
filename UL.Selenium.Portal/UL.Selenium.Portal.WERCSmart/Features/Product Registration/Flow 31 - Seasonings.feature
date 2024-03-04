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
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:Product
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:ProductInformation
@PhysicalAndChemicalProp
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:InventoryStatusProp65
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:Retailer
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:AdditionalDocumentsToProvide
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:OptionalComments
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:RegulatoryDocumentsToProvide
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:TheProduct
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:AdditionalDocumentsToProvide
@GTINAndUPC
@run_Flow31_Seasonings
Feature: [64739] Flow 31 - Seasonings

@TestCase:60737
Scenario: [60737] Seasonings, Spices or Flavoring for Food - Salts (Solid)- RU001246
	# ====== Logging in as the correct user ====== #
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	# ====== Just checks that the correct page loads ====== #
	#Given If I see the retail partners page I set all data consent tiers to true for all retailers in the top section
	Then The home screen should load
	# ====== Test Setup - Generating + Saving UPC Number and ensuring no duplicates exist ====== #
	#Given I generate a random UPC number and save as: UPC60737
	#Given I delete all products with UPC Number: saved as UPC60737
	Given I generate a unique UPC number and save as: UPC60737

	# ====== Following the steps from 'Shared Step' 57408 ====== #
	Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Given in the New Product page I click Continue

	# ====== Following the steps from 'Shared Step' 57561 ====== #
	Given I should see the The Product Page
	Given In the Product Section, set the option in section: 'Type of Product (select)' to: Seasonings, Spices or Flavoring for Food - Salts - Solid
 	Given in the The Product page I click Continue
	Then I save the product information as: TestCase60737

	# ====== Following the steps from 'Shared Step' 60756 ====== #
	Given I should see the Product Information Page
 	And In the Product Information Section, set the option in section: 'Retailers will be selling my product at their store locations' to: United States of America
    And I set the Select the product's Country of Origin field to: United Kingdom
	Given I set the Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada) option to: No
	Given In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Given In the Product Information Section, set the option in section: 'Product is a Retailer's Private Label or Brand' to: No
	Given In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Given in the Product Information page I click Continue

	# Regulatory Documents to Provide Page
And I should see the Regulatory Documents to Provide Page
And I click the browse button for label: Product Label and upload PDF: UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf
Then in the Regulatory Documents to Provide page I click Continue

	# ====== Following the steps from 'Shared Step' 60741 ====== #
	Given In the Physical and Chemical Properties Section, set the option in section: 'Primary Physical State' to: Solid
	Given In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
	Given In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Given In the Physical and Chemical Properties Section, set the option in section: 'Select all potential allergens included in this product' to: Dairy
	And I set the Product is manufactured in a facility that processes, or contains field to: Dairy or products containing dairy or milk
	Given In the Physical and Chemical Properties Section, set the option in section: 'Product is verified and sold as' to: None of the Above
	Given In the Physical and Chemical Properties Section, set the option in section: 'Product contains the following sweeteners' to: None of the Above
	And I set the Product contains the following artificial dye(s) field to: None of the Above
	Given in the Physical and Chemical Properties page I click Continue

# ====== Following the steps from 'Shared Step' 57570 ====== #
And I should see the Ingredients Page
When in the Ingredients page I click Continue
Then I should see the ingredients error message
And The ingredients error message should be showing: Formulation must total or exceed 100%.
Then I add the following ingredients:
| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Butane        | 100     | false               | false       |            |
And in the Ingredients page I click Continue
	#Given I Confirm the following error message is not visible " ALERT! The ingredient table does not include a compressed gas (Bag-On-Valve) or a propellant. Please update your ingredients to include the propellant before proceeding."

	# ====== Following the steps from 'Shared Step' 57883 ====== #
	Given I should see the Inventory Status, Prop 65 (US) Page
	Given In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	Given In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
    Given in the Inventory Status, Prop 65 (US) page I click Continue

	# ====== Following the steps from 'Shared Step' 57510 ====== #
	Given I should see the Retailer Page
	Given In the Retailer Section, click 'Add Retailers' button
	Given In the Select Retailers window, select retailer: Walgreens
	Given In the Select Retailers window, click 'Done' button
	Given in the Retailer page I click Continue

	# ====== Following the steps from 'Shared Step' 57960 ====== #
	Given I should see the Universal Product Code (UPC) Page
	Given In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, I click the Add UPC Button
	Given In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, for section: 'Provide the product's UPC(s)- including container type and size (ounces)' enter UPC Number: saved as UPC60737 enter Size: Cardboard and enter Container Type: 20
	Given in the Universal Product Code (UPC) page I click Continue

    Given I upload PDF document to Upload SDS (Optional) field
	# Additional Documents to Provide Page
	#And I should see the Additional Documents to Provide Page
	Then in the Additional Documents to Provide page I click Continue
	# Optional Reports and Documents Available for Purchase Page
	#And I should see the Optional Reports and Documents Available for Purchase Page
	Then in the Optional Reports and Documents Available for Purchase page I click Continue
	Then in the Optional Comments page I click Continue

	# ====== Following the steps from 'Shared Step' 73956 ====== #
	Given I should see the Data Acceptance Page
	Given I click the Summary button in the Data Acceptance window
	Given I switch to the Data Summary page
	Given Type of Product (select) should be showing the following option: Seasonings, Spices or Flavoring for Food - Salts - Solid
	Given I close the Data Summary Tab
    Given I should see the Data Acceptance Page

	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase60737

@TestCase:60738
Scenario: [60738] Seasonings, Spices or Flavoring for Food - Salts (Liquid)- RU001246
	# ====== Logging in as the correct user ====== #
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	# ====== Just checks that the correct page loads ====== #
	#Given If I see the retail partners page I set all data consent tiers to true for all retailers in the top section
	Then The home screen should load
	# ====== Test Setup - Generating + Saving UPC Number and ensuring no duplicates exist ====== #
	Given I generate a random UPC number and save as: UPC60738
	Given I delete all products with UPC Number: saved as UPC60738

		# ====== Following the steps from 'Shared Step' 57408 ====== #
	Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Given in the New Product page I click Continue

	# ====== Following the steps from 'Shared Step' 57561 ====== #
	Given I should see the The Product Page
	Given In the Product Section, set the option in section: 'Type of Product (select)' to: Seasonings, Spices or Flavoring for Food - Salts (Liquid)
 	Given in the The Product page I click Continue
    Then I save the product information as: TestCase60738

		# ====== Following the steps from 'Shared Step' 60756 ====== #
	Given I should see the Product Information Page
 	And In the Product Information Section, set the option in section: 'Retailers will be selling my product at their store locations' to: United States of America
    And I set the Select the product's Country of Origin field to: United Kingdom
	Given I set the Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada) option to: No
	Given In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Given In the Product Information Section, set the option in section: 'Product is a Retailer's Private Label or Brand' to: No
	Given In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Given in the Product Information page I click Continue

		# Regulatory Documents to Provide Page
	And I should see the Regulatory Documents to Provide Page
	And I click the browse button for label: Product Label and upload PDF: UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf
	Then in the Regulatory Documents to Provide page I click Continue

		# ====== Following the steps from 'Shared Step' 60741 ====== #
	Given In the Physical and Chemical Properties Section, set the option in section: 'Primary Physical State' to: Liquid
	Given In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Liquid
	Given In the Physical and Chemical Properties Section, for section: 'Relative Density' enter text: 20
	Given In the Physical and Chemical Properties Section, for section: 'pH' enter text: 7
	Given I check the 'I do not have exact' checkbox for field: Boiling Point (in Celsius)
	Given In the Physical and Chemical Properties Section, set the option in section: 'Boiling Point (in Celsius)' to: Not tested/Unknown
	Given I check the 'I do not have exact' checkbox for field: Flash Point (in Celsius)
	Given In the Physical and Chemical Properties Section, for section: 'Flash Point (in Celsius)' enter text: >=23C and <38C
	Given In the Physical and Chemical Properties Section, set the option in section: 'Flash Point Testing Method Used' to: Closed cup method
	Given In the Physical and Chemical Properties Section, set the option in section: 'Select all potential allergens included in this product' to: Dairy
	And I set the Product is manufactured in a facility that processes, or contains field to: Dairy or products containing dairy or milk
	Given In the Physical and Chemical Properties Section, set the option in section: 'Product is verified and sold as' to: None of the Above
	Given In the Physical and Chemical Properties Section, set the option in section: 'Product contains the following sweeteners' to: None of the Above
	And I set the Product contains the following artificial dye(s) field to: None of the Above
	Given in the Physical and Chemical Properties page I click Continue

	# ====== Following the steps from 'Shared Step' 57570 ====== #
	And I should see the Ingredients Page
	When in the Ingredients page I click Continue
	Then I should see the ingredients error message
	And The ingredients error message should be showing: ALERT! The ingredient table does not include a compressed gas (Bag-On-Valve) or a propellant. Please update your ingredients to include the propellant before proceeding.
	Then I add the following ingredients:
	| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
	| Butane        | 100     | false               | false       |            |
	And in the Ingredients page I click Continue
	#Given I Confirm the following error message is not visible " ALERT! The ingredient table does not include a compressed gas (Bag-On-Valve) or a propellant. Please update your ingredients to include the propellant before proceeding."

	# ====== Following the steps from 'Shared Step' 57883 ====== #
	Given I should see the Inventory Status, Prop 65 (US) Page
	Given In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	Given In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
    Given in the Inventory Status, Prop 65 (US) page I click Continue

		# ====== Following the steps from 'Shared Step' 57506 ====== #
	# ====== Following the steps from 'Shared Step' 57506 ====== #
	And I should see the Transportation Details 1 Page
	And I set the Product is Regulated for Transport option to: Yes
	And I set the below options for field: Select all modes of transport that you've classified the product for
	| Option                   |
	| IMDG                     |
	| Shipping fully regulated |
	And in the Transportation Details 1 page I click Continue

	# ====== Following the steps from 'Shared Step' 57728 ====== #
	Then I should see the International Marine (IMDG) Classification Page
	And I set the UN Number field to: UN1950
	And I set the Proper Shipping Name field to: Aerosols
	And I set the Technical Name (if applicable) field to: My Safe Product
	And I set the Hazard Class (select) field to: 2
	And I set the Packing Group (select) field to: None
	Given in the International Marine (IMDG) Classification page I click Continue

		# ====== Following the steps from 'Shared Step' 62536 ====== #
	Given I should see the Transportation Details 2 Page
	And I set the International Shipping when DOT Exemption taken? option to: I do not ship internationally and I do not know the classification
	Given in the Transportation Details 2 page I click Continue

		# ====== Following the steps from 'Shared Step' 57510 ====== #
	Given I should see the Retailer Page
	Given In the Retailer Section, click 'Add Retailers' button
	Given In the Select Retailers window, select retailer: Walgreens
	Given In the Select Retailers window, click 'Done' button
	Given in the Retailer page I click Continue

		# ====== Following the steps from 'Shared Step' 57960 ====== #
	Given I should see the Universal Product Code (UPC) Page
	Given In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, I click the Add UPC Button
	Given In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, for section: 'Provide the product's UPC(s)- including container type and size (ounces)' enter UPC Number: saved as UPC60738 enter Size: 20 and enter Container Type: any
	Given in the Universal Product Code (UPC) page I click Continue

    Given I upload PDF document to Upload SDS (Optional) field
	Then in the Additional Documents To Provide page I click Continue
	# Additional Documents to Provide Page
	And I should see the Additional Documents to Provide Page
	Then in the Additional Documents to Provide page I click Continue

	# Optional Reports and Documents Available for Purchase Page
	# ====== Following the steps from 'Shared Step' 57883 ====== #
	Then in the Optional Reports and Documents Available for Purchase page I click Continue
	Given In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: Comment Text
	Then in the Optional Comments page I click Continue

	# ====== Following the steps from 'Shared Step' 73956 ====== #
    Given I should see the Data Acceptance Page
	Given I click the Summary button in the Data Acceptance window
	Given I switch to the Data Summary page
	Given Type of Product (select) should be showing the following option: Seasonings, Spices or Flavoring for Food - Salts (Liquid)
    Given I should see the Data Acceptance Page

	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase60738
