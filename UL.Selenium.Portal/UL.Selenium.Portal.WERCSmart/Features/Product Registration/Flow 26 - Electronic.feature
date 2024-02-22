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
@GTINAndUPC
@run_Flow26_Electronic

Feature: [64732] Flow 26 - Electronic

@TestCase:60671
Scenario: [60723] Jelly, Jam or Preserves - RU001456
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given If I see the retail partners page I set all data consent tiers to true for all retailers in the top section
	Then The home screen should load
	# ====== Test Setup - Generating + Saving UPC Number and ensuring no duplicates exist ====== #
	Given I generate a random UPC number and save as: UPC60723
	Given I delete all products with UPC Number: saved as UPC60723
    Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Given in the New Product page I click Continue
	Given I should see the The Product Page
	Given In the Product Section, set the option in section: 'Type of Product (select)' to: Condiments, Sauces
	Given in the The Product page I click Continue
	Then I save the product information as: TestCase60723
    Given I should see the Product Information Page
	Given In the Product Information Section, set the option in section: 'Retailers will be selling my product at their store locations in (select either or both) ' to select: United States
	Given In the Product Information Section, set the option in section: 'Select the product's Country of Origin' to: United States of America
	Given In the Product Information Section, set the option in section: 'Product is a Retailer's Private Label or Brand' to: No
	Given in the Product Information page I click Continue
	Given In the Regulatory Documents to Provide Section, upload file in section: 'Upload Full Product Label (required) (For private label products please upload a generic label that is not retailer-specific.)'
	Given in the Regulatory Documents To Provide page I click Continue
	Given In the Physical and Chemical Properties Section, set the option in section: 'Primary Physical State' to: Solid
	Given In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
	Given In the Physical and Chemical Properties Section, set the option in section: 'Select all potential allergens included in this product' to: Dairy
	Given In the Physical and Chemical Properties Section, set the option in section: 'Product is manufactured in a facility that processes, or contains' to: Dairy or products containing dairy or milk
	Given In the Physical and Chemical Properties Section, set the option in section: 'Product is verified and sold as' to: None of the Above
	Given In the Physical and Chemical Properties Section, set the option in section: 'Product contains the following sweeteners' to: None of the Above
	Given In the Physical and Chemical Properties Section, set the option in section: 'Product contains the following artificial dye(s)' to: None of the Above
	Given in the Physical and Chemical Properties page I click Continue
	Given I should see the Inventory Status, Prop 65 (US) Page
	Given In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	Given In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
    Given in the Inventory Status, Prop 65 (US) page I click Continue
	Given I should see the Retailer Page
	Given In the Retailer Section, click 'Add Retailers' button
	Given In the Select Retailers window, select retailer: Walgreens
	Given In the Select Retailers window, click 'Done' button
	Given in the Retailer page I click Continue
	Given I should see the Universal Product Code (UPC) Page
	Given In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, I click the Add UPC Button
	Given In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, for section: 'Provide the product's UPC(s)- including container type and size (ounces)' enter UPC Number: saved as UPC60723 enter Size: Cardboard and enter Container Type: 20
	Given in the Universal Product Code (UPC) page I click Continue
	Given I upload PDF document to Upload SDS (Optional) field
	Given I upload PDF document to Flash Point Testing Report field
	Then in the Additional Documents To Provide page I click Continue
	Then in the Optional Reports and Documents Available for Purchase page I click Continue
	Given In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: Comment Text
	Then in the Optional Comments page I click Continue
    Given I should see the Data Acceptance Page
	Given I click the Summary button in the Data Acceptance window
	Given I switch to the Data Summary page
	Given Type of Product (select) should be showing the following option: Jelly, Jam or Preserves
	Given I close the Data Summary Tab
    Given I should see the Data Acceptance Page
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase60723




