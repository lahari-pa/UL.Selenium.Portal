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
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:NewProduct
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:TheProduct
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:DistributorRequestUPCSection
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:ProductInformation
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:InventoryStatusProp65
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:Retailer
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:ToxicityCharacteristicLeachingProcedureTCLP
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:ElectronicEquipment
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:ProductIncludesBattery
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:DataAcceptance
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:Summary
@GTINAndUPC
@run_Flow15
@StepsPrototype
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:OptionalComments

Feature: Flow 15

@TestCase:58760
Scenario: [58760] Light Bulbs - Light Emitting Diodes (LED) - RU000948
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC58760
	Given I delete all products with UPC Number: saved as UPC58760

	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
    Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Given in the New Product page I click Continue

	#And I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Food Item Dispensed by Compressed Gas - Dairy Topping
	And I should see the The Product Page
	And In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Light Bulbs - Light Emitting Diodes (LED)
	And In the Product Section, set the option in section: 'Type of Product (select)' to: Light Bulbs - Light Emitting Diodes (LED)
	And in the The Product page I click Continue
	Then I save the product information as: TestCase58760

	#And I call Shared Step 69687 (Product Information - US, No(PL))
    Given I should see the Product Information Page
	Given In the Product Information Section, set the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' to select: United States
	Given In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Given in the Product Information page I click Continue

	Given I should see the Inventory Status, Prop 65 (US) Page
	Given In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	Given In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Given in the Inventory Status, Prop 65 (US) page I click Continue

	#Given I call Shared Step 48369 (Toxicity Characteristics Leaching Procedure (TCLP) - No to ALL With Copper)
	Given I should see the Toxicity Characteristic Leaching Procedure (TCLP) Page
	Given In the Toxicity Characteristic Leaching Procedure (TCLP) Section, set the option in section: 'Product has had TCLP testing; Report is available' to: No
	Given In the Toxicity Characteristic Leaching Procedure (TCLP) Section, set the radio option in section: 'Lead': to: No
	Given In the Toxicity Characteristic Leaching Procedure (TCLP) Section, set the radio option in section: 'Mercury': to: No
	Given In the Toxicity Characteristic Leaching Procedure (TCLP) Section, set the radio option in section: 'Silver': to: No
	Given In the Toxicity Characteristic Leaching Procedure (TCLP) Section, set the radio option in section: 'Cadmium': to: No
	Given In the Toxicity Characteristic Leaching Procedure (TCLP) Section, set the radio option in section: 'Chromium': to: No
	Given In the Toxicity Characteristic Leaching Procedure (TCLP) Section, set the radio option in section: 'Barium': to: No
	Given In the Toxicity Characteristic Leaching Procedure (TCLP) Section, set the radio option in section: 'Arsenic': to: No
	Given In the Toxicity Characteristic Leaching Procedure (TCLP) Section, set the radio option in section: 'Selenium': to: No
	Given In the Toxicity Characteristic Leaching Procedure (TCLP) Section, set the radio option in section: 'Copper': to: No
	Given in the Toxicity Characteristic Leaching Procedure (TCLP) page I click Continue

	#Given I call Shared Step 58189 (Answer Electronic Equipment questions - With Cathode Ray - No to all)
	Given I should see the Electronic Equipment Page
	Given In the Electronic Equipment Section, set the option in section: 'Contains Circuit Board' to: Yes
	Given In the Electronic Equipment Section, set the option in section: 'Has a Cathode Ray Tube (CRT)' to: Yes
	Given in the Electronic Equipment page I click Continue

	#Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Amazon
	Given I should see the Retailer Page
	Given In the Retailer Section, click 'Add Retailers' button
	Given In the Select Retailers window, select retailer: Amazon
	Given In the Select Retailers window, click 'Done' button
	Given in the Retailer page I click Continue

	#Then I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC58760, container type: Plastic Container and size: 22
	And I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page
	Given In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, I click the Add UPC Button
	Given In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, for section: 'Provide the product's UPC(s)- including container type and size (ounces)' enter UPC Number: saved as UPC58760 enter Size: 22 and enter Container Type: Plastic Container
	And in the Universal Product Code (UPC) page I click Continue

	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue

	#And I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Comments Field Text
	And I should see the Optional Comments Page
	And In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: User added Comments Text 58760. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
	Then in the Optional Comments page I click Continue

	#Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Light Bulbs - Light Emitting Diodes (LED)
	Given I should see the Data Acceptance Page
	Given In the Data Acceptance Section, click 'Summary' button
	Given I switch to the tab with Data Summary page
	Given In the Summary Page, the 'Type of Product (select)' section should be showing the following value: Light Bulbs - Light Emitting Diodes (LED)
	Given I close the tab with Data Summary page

	Given I navigate to the home page
	Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase58760

@TestCase:58759
Scenario: [58759] Servers, Small-Scale - RU001183
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC58759
	Given I delete all products with UPC Number: saved as UPC58759

    #Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
    Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Given in the New Product page I click Continue

	#And I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Servers, Small-Scale
    And I should see the The Product Page
	And In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Servers, Small-Scale
	And In the Product Section, set the option in section: 'Type of Product (select)' to: Servers, Small-Scale
	And in the The Product page I click Continue
	Then I save the product information as: TestCase58759

	Given I should see the Product Information Page
	Given In the Product Information Section, set the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' to select: United States
	Given In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Given In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Given in the Product Information page I click Continue

	#Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I should see the Inventory Status, Prop 65 (US) Page
	Given In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	Given In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Given in the Inventory Status, Prop 65 (US) page I click Continue

	#Given I call Shared Step 48367 (Product Includes Battery > any type)
	# 	| Battery Type | Manufacturer | Quantity of Batteries per Package | Quantity of Batteries to Operate Product |
	# 	| Alkaline     | <any>        | 4                               | 2                                  |
	Given I should see the Product Includes Battery Page
	Given In the Product Includes Battery Section enter the values in the table:
          | Battery Is Packaged      | Battery Type | Manufacturer                                                        | Quantity of Batteries per Package | Quantity of Batteries to Operate Product |
          | Installed in the product | Alkaline     | FM - Alkaline Battery (RU000344)  by The WERCS LTD (WPS ID 1775597) | 4                                 | 2                                        |
	Given in the Product Includes Battery page I click Continue

	#Given I call Shared Step 104083 Toxicity Characteristics Leaching Procedure TCLP - NO to ALL - NO COPPER LISTED
	Given I should see the Toxicity Characteristic Leaching Procedure (TCLP) Page
	Given In the Toxicity Characteristic Leaching Procedure (TCLP) Section, set the option in section: 'Product has had TCLP testing; Report is available' to: No
	Given In the Toxicity Characteristic Leaching Procedure (TCLP) Section, set the radio option in section: 'Lead': to: No
	Given In the Toxicity Characteristic Leaching Procedure (TCLP) Section, set the radio option in section: 'Mercury': to: No
	Given In the Toxicity Characteristic Leaching Procedure (TCLP) Section, set the radio option in section: 'Silver': to: No
	Given In the Toxicity Characteristic Leaching Procedure (TCLP) Section, set the radio option in section: 'Cadmium': to: No
	Given In the Toxicity Characteristic Leaching Procedure (TCLP) Section, set the radio option in section: 'Chromium': to: No
	Given In the Toxicity Characteristic Leaching Procedure (TCLP) Section, set the radio option in section: 'Barium': to: No
	Given In the Toxicity Characteristic Leaching Procedure (TCLP) Section, set the radio option in section: 'Arsenic': to: No
	Given In the Toxicity Characteristic Leaching Procedure (TCLP) Section, set the radio option in section: 'Selenium': to: No
	Given in the Toxicity Characteristic Leaching Procedure (TCLP) page I click Continue

	#Given I call Shared Step 58189 (Answer Electronic Equipment questions - With Cathode Ray - No to all)
	Given I should see the Electronic Equipment Page
	Given In the Electronic Equipment Section, set the option in section: 'Contains Circuit Board' to: No
	Given In the Electronic Equipment Section, set the option in section: 'Has a Cathode Ray Tube (CRT)' to: No
	Given In the Electronic Equipment Section, set the option in section: 'Has a LCD or Plasma Display' to: No
	Given in the Electronic Equipment page I click Continue

	#Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Staples
	Given I should see the Retailer Page
	Given In the Retailer Section, click 'Add Retailers' button
	Given In the Select Retailers window, select retailer: Staples
	Given In the Select Retailers window, click 'Done' button
	Given in the Retailer page I click Continue

	#And I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC58759, container type: Plastic Container and size: 10.00
	And I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page
	Given In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, I click the Add UPC Button
	Given In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, for section: 'Provide the product's UPC(s)- including container type and size (ounces)' enter UPC Number: saved as UPC58759 enter Size: 22 and enter Container Type: Plastic Container
	And in the Universal Product Code (UPC) page I click Continue

	#Given in the Additional Documents to Provide page I click Continue
	#Given in the Other Product Document Uploads page I click Continue

	#And I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: User added Comments Text 58759. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
	And I should see the Optional Comments Page
	And I enter the following into the comments field: User added Comments Text 58759. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
	Then in the Comments page I click Continue

	#Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Servers, Small-Scale
	Given I should see the Data Acceptance Page
	Given In the Data Acceptance Section, click 'Summary' button
	Given I switch to the tab with Data Summary page
	Given In the Summary Page, the 'Type of Product (select)' section should be showing the following value: Servers, Small-Scale
	Given I close the tab with Data Summary page
	Given I should see the Data Acceptance Page

	Given I navigate to the home page
	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase58759
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase58759
