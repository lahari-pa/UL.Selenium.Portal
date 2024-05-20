@Shared
@LandingPage
@Login
@Homepage
@Signup
@wercsmart
@NewProduct
@ProductGrid
@DataSummarySheet
@StepsPrototype
@wercsmart
@RetailPartners
@SubEnrollment
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:NewProduct
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:TheProduct
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:ProductInformation
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:RegulatoryDocumentsToProvide
@PhysicalAndChemicalProp
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:InventoryStatusProp65
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:Retailer
@GTINAndUPC
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:AdditionalDocumentsToProvide
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:OptionalComments
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:FuelContainerRegulatoryDetails
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:DataAcceptance
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:Summary
@run_Flow28_AutoParts
Feature: [64733] Flow 28 - Auto Parts

@TestCase:60673
Scenario: [60673] Gasoline Container, Portable - RU001419
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given If I see the retail partners page I set all data consent tiers to true for all retailers in the top section
	Then The home screen should load
	# ====== Test Setup - Generating + Saving UPC Number and ensuring no duplicates exist ====== #
	Given I generate a random UPC number and save as: UPC60673
	Given I delete all products with UPC Number: saved as UPC60673

	# ====== Given I call Shared Step 57408 (Create a New Registration via Register New Product icon) ====== #
	Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Given in the New Product page I click Continue

	# ====== And I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Food Item Dispensed by Compressed Gas - Dairy Topping ====== #
	Given I should see the The Product Page
	Given In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Gasoline Container, Portable_#60673
	Given In the Product Section, set the option in section: 'Type of Product (select)' to: Gasoline Container, Portable
 	Given in the The Product page I click Continue
    Then I save the product information as: TestCase60673

	# ====== And I call Shared Step 69687 (Product Information - US, No(PL)) ====== #
	Given I should see the Product Information Page
	Given In the Product Information Section, set the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' to select: United States
	Given In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: Yes
    Given in the Product Information page I click Continue

	Given I should see the Inventory Status, Prop 65 (US) Page
	Given In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
    Given in the Inventory Status, Prop 65 (US) page I click Continue

	Given I should see the Fuel Container Regulatory Details Page
	Given I enter the text of Product is a Safety Can field to: Yes
	Given in the Fuel Container Regulatory Details page I click Continue

	#Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Harbor Freight Tools
	Given I should see the Retailer Page
	Given In the Retailer Section, click 'Add Retailers' button
	Given In the Select Retailers window, select retailer: Harbor Freight Tools
	Given In the Select Retailers window, click 'Done' button
	Given In the Retailer Section, for retailer: Harbor Freight Tools enter 'Indicate full name of product, as sold, via this retailer': Private Label Gasoline
	Given in the Retailer page I click Continue

	# ====== Then I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC60673, container type: Cardboard and size: 20 ====== #
	Given I should see the Universal Product Code (UPC) Page
	Given In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, I click the Add UPC Button
	Given In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, for section: 'Provide the product's UPC(s)- including container type and size (ounces)' enter UPC Number: saved as UPC60673 enter Size: 20 and enter Container Type: Cardboard
	Given in the Universal Product Code (UPC) page I click Continue

	Given I upload PDF document to Upload SDS (Optional) field
	Given I upload PDF document to Generic Private Label (all sides) field
	Then in the Additional Documents To Provide page I click Continue
	Then in the Optional Comments page I click Continue

	# ====== Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Gasoline Container, Portable ====== #
	Given I should see the Data Acceptance Page
	Given In the Data Acceptance Section, click 'Summary' button
	Given I switch to the tab with Data Summary page
	Given In the Summary Page, the 'Type of Product (select)' section should be showing the following value: Gasoline Container, Portable
	Given I close the tab with Data Summary page
	Given I should see the Data Acceptance Page

   # Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase60673
   	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase60673
