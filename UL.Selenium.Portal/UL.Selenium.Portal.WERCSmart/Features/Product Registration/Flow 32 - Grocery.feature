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
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:InventoryStatusProp65
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

# ====== Following the steps from 'Shared Step' 57753 ====== #
Given I click the Add Product icon in the Navigation Pane
And I should see the New Product Page
And I set the Select the type of product to create option to: Create a New Registration
And in the New Product page I click Continue

# ====== Following the steps from 'Shared Step' 57561 ====== #
And I should see the The Product Page
And I set the Product Name as it a appears on the Package Label field to: Food Item Dispensed by Compressed Gas - Dairy Topping
#And In the Product Type tab of the New Product Page, I enter: Food Item Dispensed by Compressed Gas - Dairy Topping in the Type of Product select field
And I set 'Type of Product' to: Food Item Dispensed by Compressed Gas - Dairy Topping
And in the The Product page I click Continue
Then I save the product information as: TestCase60774

# ====== Following the steps from 'Shared Step' 60756 ====== #
And I should see the Product Information Page
And Select countries the product may be sold in should be showing the value: United States
And I set the Select the product's Country of Origin field to: United Kingdom
And I set the Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) field to: No
And I set the Product is shipped directly by supplier to the consumer. field to: No
And I set the Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product field to: No
And I set the Product is a Retailer's Private Label or Brand field to: No
And I set the Product is sold to the Retailer solely for the Retailer's use field to: No
And in the Product Information page I click Continue

# Regulatory Documents to Provide Page
And I should see the Regulatory Documents to Provide Page
And I click the browse button for label: Product Label and upload PDF: UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf
Then in the Regulatory Documents to Provide page I click Continue

# ====== Following the steps from 'Shared Step' 60778 ====== #
And I should see the Physical and Chemical Properties Page
And Primary Physical State should be showing the value: Product is packaged in a gas cylinder (e.g., whip cream)
And I set the Secondary Physical State option to: Liquid
And I set the pH field to: 7
And I set the Select the best Water Solubility description field to: Dispersible
And I set the When the product has a flammable propellant field to: This product is not classified as D001 or D003 Hazardous Waste under RCRA
And I set the Select all potential allergens included in this product field to: Dairy
And I set the Product is manufactured in a facility that processes, or contains field to: Dairy or products containing dairy or milk
And I set the Product is verified and sold as field to: None of the Above
And I set the Product contains the following sweeteners field to: None of the Above
And I set the Product contains the following artificial dye(s) option to: None of the Above
And in the Physical and Chemical Properties page I click Continue

# ====== Following the steps from 'Shared Step' 57570 ====== #
And I should see the Ingredients Page
When in the Ingredients page I click Continue
Then I should see the ingredients error message
And The ingredients error message should be showing: ALERT! The ingredient table does not include a compressed gas (Bag-On-Valve) or a propellant. Please update your ingredients to include the propellant before proceeding.
Then I add the following ingredients:
| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Butane        | 100     | false               | false       |            |
And in the Ingredients page I click Continue
Given I confirm I check the checkbox in the popup view with the following text: The Product Type, Pest Selection, and Ingredients listed are accurate.
Given In the popup view with the following title: Product Contains Ingredients Typical of a Pesticide I click the Confirm button

# ====== Following the steps from 'Shared Step' 57503 ====== #
Given I should see the Inventory Status, Prop 65 (US) Page
Given In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
Given In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
Given in the Inventory Status, Prop 65 (US) page I click Continue

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

Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Walgreens

# ====== Following the steps from 'Shared Step' 57960 ====== #
And I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page
Given I click the 'Add' button
Then I add the following into the UPC Fields
| Field         | Value             |
| UPCNumber     | saved as UPC60774 |
| ContainerType | Aerosol Can - Metal       |
| Size          | 20                |
And in the Universal Product Code (UPC) page I click Continue

# Additional Documents to Provide Page
And I should see the Additional Documents to Provide Page
Then in the Additional Documents to Provide page I click Continue

# Optional Reports and Documents Available for Purchase Page
And I should see the Optional Reports and Documents Available for Purchase Page
Then in the Optional Reports and Documents Available for Purchase page I click Continue

# ====== Following the steps from 'Shared Step' 57883 ====== #
And I should see the Optional Comments Page
And I enter the following into the comments field: Comments Field Text
Then in the Comments page I click Continue

#Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Food Item Dispensed by Compressed Gas - Dairy Topping
# ====== Following the steps from 'Shared Step' 73956 ====== #
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

# ====== Following the steps from 'Shared Step' 57753 ====== #
Given I click the Add Product icon in the Navigation Pane
And I should see the New Product Page
And I set the Select the type of product to create option to: Create a New Registration
And in the New Product page I click Continue

# ====== Following the steps from 'Shared Step' 57561 ====== #
And I should see the The Product Page
And I set the Product Name as it a appears on the Package Label field to: Cooking oil - Non-Aerosol
#And In the Product Type tab of the New Product Page, I enter: Food Item Dispensed by Compressed Gas - Dairy Topping in the Type of Product select field
And I set 'Type of Product' to: Food Item Dispensed by Compressed Gas - Dairy Topping
And in the The Product page I click Continue
Then I save the product information as: TestCase60775

# ====== Following the steps from 'Shared Step' 60756 ====== #
And I should see the Product Information Page
And I set the Select the product's Country of Origin field to: United Kingdom
And I set the Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) field to: No
And I set the Product is shipped directly by supplier to the consumer. field to: No
And I set the Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product field to: No
And I set the Product is sold to the Retailer solely for the Retailer's use field to: No
And in the Product Information page I click Continue

# Regulatory Documents to Provide Page
And I should see the Regulatory Documents to Provide Page
And I click the browse button for label: Product Label and upload PDF: UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf
Then in the Regulatory Documents to Provide page I click Continue

# ====== Following the steps from 'Shared Step' 60779 ====== #
And I should see the Physical and Chemical Properties Page
And Primary Physical State should be showing the value: Product is packaged in a gas cylinder (e.g., whip cream)
And I set the Secondary Physical State option to: Liquid
And I set the pH field to: 7
And I set the Select the best Water Solubility description field to: Dispersible
And I set the When the product has a flammable propellant field to: This product is not classified as D001 or D003 Hazardous Waste under RCRA
And I set the Select all potential allergens included in this product field to: Dairy
And I set the Product is manufactured in a facility that processes, or contains field to: Dairy or products containing dairy or milk
And I set the Product is verified and sold as field to: None of the Above
And I set the Product contains the following sweeteners field to: None of the Above
And I set the Product contains the following artificial dye(s) option to: None of the Above
And in the Physical and Chemical Properties page I click Continue

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

# ====== Following the steps from 'Shared Step' 57571 ====== #

Given I should see the Inventory Status, Prop 65 (US) Page
Given In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
Given In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
Given in the Inventory Status, Prop 65 (US) page I click Continue

# ====== Following the steps from 'Shared Step' 57506 ====== #
Given I set the Product is Regulated for Transport option to: No, due to an exemption or exception
Given I set the Please select DOT Exceptions if applicable option to: 173.120(a)(4)
And in the Transportation Details 1 page I click Continue

# ====== Following the steps from 'Shared Step' 57713 ====== #
Given I confirm the Label Information section on the Regulatory Information 3 page contains a link for: OTC Drug Facts Label (may include Active Ingredient)
Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
Given I set the Refer to your Product Label option to: None of the Above
And in the Regulatory Information 3 page I click Continue

And I should see the Transportation Details 2 Page
And In the Product Characteristics tab of the New Product Page, for International Shipping when DOT Exemption taken I select: I do not ship internationally and I do not know the classification
And in the New Product page I click Continue

# ====== Following the steps from 'Shared Step' 57960 ====== #
And I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page
Given I click the 'Add' button
Then I add the following into the UPC Fields
| Field         | Value               |
| UPCNumber     | saved as UPC60774   |
| ContainerType | Aerosol Can - Metal |
| Size          | 20                  |
And in the Universal Product Code (UPC) page I click Continue

# Additional Documents to Provide Page
And I should see the Additional Documents to Provide Page
Then in the Additional Documents to Provide page I click Continue

# Optional Reports and Documents Available for Purchase Page
And I should see the Optional Reports and Documents Available for Purchase Page
Then in the Optional Reports and Documents Available for Purchase page I click Continue

# ====== Following the steps from 'Shared Step' 57883 ====== #
And I should see the Optional Comments Page
And I enter the following into the comments field: Comments Field Text
Then in the Comments page I click Continue

#Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Food Item Dispensed by Compressed Gas - Dairy Topping
# ====== Following the steps from 'Shared Step' 73956 ====== #
Given I should see the Data Acceptance Page
Given I click the Summary button in the Data Acceptance window
Given I switch to the Data Summary page
Given Type of Product (select) should be showing the following option: Cooking oil - Non-Aerosol
Given I close the Data Summary Tab
Given I should see the Data Acceptance Page

Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase60775
