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
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:ToxicityCharacteristicLeachingProcedureTCLP
@StepsPrototype
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:ElectronicEquipment
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:ProductIncludesBattery
@GTINAndUPC
@run_Flow26_Electronic

Feature: [64732] Flow 26 - Electronic

@TestCase:60671
Scenario:  [60671] Computer (Combination of Monitor & Desktop) - RU001177
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given If I see the retail partners page I set all data consent tiers to true for all retailers in the top section
	Then The home screen should load
	# ====== Test Setup - Generating + Saving UPC Number and ensuring no duplicates exist ====== #
	Given I generate a random UPC number and save as: UPC60671
	Given I delete all products with UPC Number: saved as UPC60671

	# ====== Given I call Shared Step 57408 (Create a New Registration via Register New Product icon) ====== #
    Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Given in the New Product page I click Continue

	# ====== And I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Computer (Combination of Monitor & Desktop) ====== #
	Given I should see the The Product Page
	Given In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Computer (Combination of Monitor & Desktop)_#60671
	Given I set 'Type of Product' to: Computer (Combination of Monitor & Desktop)
	Given in the The Product page I click Continue
	Then I save the product information as: TestCase60671

	# ====== And I call Shared Step 60935 (Product Information - US - Direct Ship - Private Label Only) ====== #
    Given I should see the Product Information Page
	Given In the Product Information Section, set the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' to select: United States
	Given In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Given In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Given in the Product Information page I click Continue

	Given I should see the Inventory Status, Prop 65 (US) Page
	Given In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	Given In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
    Given in the Inventory Status, Prop 65 (US) page I click Continue

# ======  Given I call Shared Step 48367 (Product Includes Battery > any type) ====== #
# ======  | Battery Type | Manufacturer | Quantity of Batteries per Package | Quantity of Batteries to Operate Product | ====== #
# ======  | Alkaline     | <any>        | 6                                 | 6                                        | ====== #
	Given I should see the Product Includes Battery Page
	Then In the Product Includes Battery Section, set the radio option in section: 'Indicate how battery is packaged': to: The battery is shipped with but not included in my product.
	Given In the Product Includes Battery Section enter the values in the table:
		| Battery Type | Manufacturer | Quantity of Batteries per Package | Quantity of Batteries to Operate Product |
		| Alkaline     | wercs        | 6                                 | 6                                        |
	Given in the Product Includes Battery page, I click Continue

# ======  Given I call Shared Step 61449 Toxicity Characteristic Leaching Procedure (TCLP) - select No to all - Click Continue - Happy Path  ====== #
	Given I should see the Toxicity Characteristic Leaching Procedure (TCLP) Page
	And In the Toxicity Characteristic Leaching Procedure (TCLP) Section, set the option in section: 'Product has had TCLP testing; Report is available' to: No
	Then In the Toxicity Characteristic Leaching Procedure (TCLP) Section, set the radio option in section: 'Lead': to: No
	Then In the Toxicity Characteristic Leaching Procedure (TCLP) Section, set the radio option in section: 'Mercury': to: No
	Then In the Toxicity Characteristic Leaching Procedure (TCLP) Section, set the radio option in section: 'Silver': to: No
	Then In the Toxicity Characteristic Leaching Procedure (TCLP) Section, set the radio option in section: 'Cadmium': to: No
	Then In the Toxicity Characteristic Leaching Procedure (TCLP) Section, set the radio option in section: 'Chromium': to: No
	Then In the Toxicity Characteristic Leaching Procedure (TCLP) Section, set the radio option in section: 'Barium': to: No
	Then In the Toxicity Characteristic Leaching Procedure (TCLP) Section, set the radio option in section: 'Arsenic': to: No
	Then In the Toxicity Characteristic Leaching Procedure (TCLP) Section, set the radio option in section: 'Selenium': to: No
	Then In the Toxicity Characteristic Leaching Procedure (TCLP) Section, set the radio option in section: 'Copper': to: No
	Given in the Toxicity Characteristic Leaching Procedure (TCLP) page, I click Continue

	Given I should see the Electronic Equipment Page
	Given In the Electronic Equipment Section, set the option in section: 'Contains Circuit Board' to: Yes
	Given In the Electronic Equipment Section, set the option in section: 'Has a Cathode Ray Tube (CRT)' to: Yes
	Given in the Electronic Equipment page I click Continue

	Given I should see the Retailer Page
	Given in the Retailer page I click Continue

	# ====== And I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Comments Field Text ====== #
	Given In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: Comment Text
	Then in the Optional Comments page I click Continue

	# ====== Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Computer (Combination of Monitor & Desktop) ====== #
    Given I should see the Data Acceptance Page
	Given I click the Summary button in the Data Acceptance window
	Given I switch to the Data Summary page
	Given Type of Product (select) should be showing the following option: Computer (Combination of Monitor & Desktop)
	Given I close the Data Summary Tab
    Given I should see the Data Acceptance Page

	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase60671
