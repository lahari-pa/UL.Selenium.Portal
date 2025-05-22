@Shared
@LandingPage
@Login
@Homepage
@Signup
@StepsPrototype
@wercsmart
@NewProduct
@ProductGrid
@DataSummarySheet
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
@run_Flow30_Grocery
@SideMenu

Feature: [64735] Flow 30 - Grocery

@ignore
@TestCase:60725
Scenario: [60725] Baked Goods, Crackers - RU001449
	#Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I log in with the account saved in TReVor as: ProductAccount
	Given If I see the retail partners page I set all data consent tiers to true for all retailers in the top section
	Then The home screen should load
	#Test Setup - Generating + Saving UPC Number and ensuring no duplicates exist
	Given I generate a random UPC number and save as: UPC60725
	Given I delete all products with UPC Number: saved as UPC60725
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Baked Goods, Crackers
	Then I save the product information as: TestCase60725
	Given I call Shared Step 74123 (Product Information - Grocery - US - Random Country - No(PL))
	Given I call Shared Step 60741 (Select Primary Physical Property - Solid - With Ingredients)	
	#Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I should see the Inventory Status, Prop 65 (US) Page
	Then In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	Then In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page I click Continue

	Then I click 'Add Retailers' in the Retailers page
	Then In the 'Select retailers' window I should not see the following retailers:
		| Retailer  |
		| Auto Zone |
	#Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Walgreens
	Given I should see the Retailer Page
	Then In the Retailer Section, click 'Add Retailers' button
	Then In the Select Retailers window, select retailer: Walgreens
	Then In the Select Retailers window, click 'Done' button
	Then in the Retailer page I click Continue

	Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC60725, container type: Cardboard and size: 20
    #Given I call Shared Step 60567 (Upload Product Label only)
	Given I should see the Regulatory Documents to Provide Page
	Given in the Regulatory Documents to Provide page I click Continue
	Then In the Regulatory Documents to Provide Section: 'Upload Full Product Label (required) (For private label products please upload a generic label that is not retailer-specific.)' error message should display: Document is required: Product Label
	Then In the Regulatory Documents to Provide Section, upload file in section: 'Upload Full Product Label (required) (For private label products please upload a generic label that is not retailer-specific.)'
	Given in the Regulatory Documents to Provide page I click Continue

	# Additional Documents to Provide Page
	And I should see the Additional Documents to Provide Page
	Given I call Shared Step 60715 (Additional Documents to Provide - OSHA SDS - only) : UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf
	# Optional Reports and Documents Available for Purchase Page
	And I should see the Optional Reports and Documents Available for Purchase Page
	Then in the Optional Reports and Documents Available for Purchase page I click Continue
	And I wait 300 seconds for the Comments Page to load
	#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Comment Text
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Baked Goods, Crackers
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase60725

@TestCase:60724
Scenario: [60724] Condiments, Sauces - RU001454
	#Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I log in with the account saved in TReVor as: ProductAccount
	Given If I see the retail partners page I set all data consent tiers to true for all retailers in the top section
	Then The home screen should load
	#Test Setup - Generating + Saving UPC Number and ensuring no duplicates exist
	Given I generate a random UPC number and save as: UPC60724
	Given I delete all products with UPC Number: saved as UPC60724

	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given In the Side Menu, click Labeled Link with Add Product title
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration'
	Given in the New Product page I click Continue

	#Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Condiments, Sauces
	Given I should see the The Product Page
	Given In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Condiments, Sauces_#60724
	Given In the Product Section, set the option in section: 'Type of Product (select)' to: Condiments, Sauces
	Given in the The Product page I click Continue
	Then I save the product information as: TestCase60724

	#And I call Shared Step 69687 (Product Information - US, No(PL))
	Given I should see the Product Information Page
	Given In the Product Information Section, set the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' to select: United States
	Given In the Product Information Section, set the option in section: 'Select the product's Country of Origin' to: United States of America
	Given In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Given In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Given in the Product Information page I click Continue

	#Given I call Shared Step 60747 (Select Primary Physical Property - Liquid - With Ingredients)
	Given In the Physical and Chemical Properties Section, set the option in section: 'Primary Physical State' to: Liquid
	Given In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Liquid
	Given In the Physical and Chemical Properties Section, for section: 'Relative Density' enter text: 20
	Given In the Physical and Chemical Properties Section, for section: 'pH' enter text: 7
	Given In the Physical and Chemical Properties Section, for section: 'Boiling Point (in Celsius)' select the checkbox option: 'I do not have exact Boiling Point data available to me'
	Given In the Physical and Chemical Properties Section, set the option in section: 'Boiling Point (in Celsius)' to: Not tested/Unknown
	Given In the Physical and Chemical Properties Section, for section: 'Flash Point (in Celsius)' select the checkbox option: 'I do not have exact Flash Point data available to me'
	Given In the Physical and Chemical Properties Section, for section: 'Flash Point (in Celsius)' enter text: >=23C and <38C
	Given In the Physical and Chemical Properties Section, set the option in section: 'Flash Point Testing Method Used' to: Closed cup method
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

	#Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Walgreens
	Given I should see the Retailer Page
	Given In the Retailer Section, click 'Add Retailers' button
	Given In the Select Retailers window, select retailer: Walgreens
	Given In the Select Retailers window, click 'Done' button
	Given in the Retailer page I click Continue

	#Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC60723, container type: Glass Container and size: 20
	Given I should see the Universal Product Code (UPC) Page
	Given In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, I click the Add UPC Button
	Given In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, for section: 'Provide the product's UPC(s)- including container type and size (ounces)' enter UPC Number: saved as UPC60724 enter Size: 20 and enter Container Type: Glass Container
	Given in the Universal Product Code (UPC) page I click Continue

	#Given I call Shared Step 60567 (Upload Product Label only)
	Given I should see the Regulatory Documents to Provide Page
	Given in the Regulatory Documents to Provide page I click Continue
	Then In the Regulatory Documents to Provide Section: 'Upload Full Product Label (required) (For private label products please upload a generic label that is not retailer-specific.)' error message should display: Document is required: Product Label
	Then In the Regulatory Documents to Provide Section, upload file in section: 'Upload Full Product Label (required) (For private label products please upload a generic label that is not retailer-specific.)'
	Then In the Regulatory Documents to Provide Section: 'Upload Full Product Label (required) (For private label products please upload a generic label that is not retailer-specific.)' error message should not display: Document is required: Product Label
	Given in the Regulatory Documents to Provide page I click Continue

	Given I should see the Additional Documents to Provide Page
	Then in the Additional Documents to Provide page I click Continue

	Given I should see the Optional Reports and Documents Available for Purchase Page
	Then in the Optional Reports and Documents Available for Purchase page I click Continue

	#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Comment Text
	Given I should see the Optional Comments Page
	Given In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: Comment Text
	Then in the Optional Comments page I click Continue

	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase60724
	Then In the Side Menu, click Labeled Link with My Products title
	Then In the Product Grid, delete the product saved as: TestCase60724


@TestCase:60723
Scenario: [60723] Jelly, Jam or Preserves - RU001456

	#Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given If I see the retail partners page I set all data consent tiers to true for all retailers in the top section
	Then The home screen should load

	#Test Setup - Generating + Saving UPC Number and ensuring no duplicates exist
	Given I generate a random UPC number and save as: UPC60723
	Given I delete all products with UPC Number: saved as UPC60723

	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
    Given In the Side Menu, click Labeled Link with Add Product title
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration'
	Given in the New Product page I click Continue

	#Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Condiments, Sauces
	Given I should see the The Product Page
	Given In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Jelly, Jam or Preserves_#60723
	Given In the Product Section, set the option in section: 'Type of Product (select)' to: Jelly, Jam or Preserves
	Given in the The Product page I click Continue

	Then I save the product information as: TestCase60723

	#And I call Shared Step 69687 (Product Information - US, No(PL))
    Given I should see the Product Information Page
	Given In the Product Information Section, set the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' to select: United States
	Given In the Product Information Section, set the option in section: 'Select the product's Country of Origin' to: United States of America
	And In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	And In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page, I click Continue

	#Given I call Shared Step 60747 (Select Primary Physical Property - Liquid - With Ingredients)
	Given In the Physical and Chemical Properties Section, set the option in section: 'Primary Physical State' to: Solid
	Given In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
	Given In the Physical and Chemical Properties Section, set the option in section: 'Select all potential allergens included in this product' to: Dairy
	Given In the Physical and Chemical Properties Section, set the option in section: 'Product is manufactured in a facility that processes, or contains' to: Dairy or products containing dairy or milk
	Given In the Physical and Chemical Properties Section, set the option in section: 'Product is verified and sold as' to: None of the Above
	Given In the Physical and Chemical Properties Section, set the option in section: 'Product contains the following sweeteners' to: None of the Above
	Given In the Physical and Chemical Properties Section, set the option in section: 'Product contains the following artificial dye(s)' to: None of the Above
	Given in the Physical and Chemical Properties page I click Continue

	#Given I call Shared Step 57503 (Inventory Status, Prop 65 (US) - TSCA(Any Option) - Prop 65 (NO) - Continue - Happy Path)
	Given I should see the Inventory Status, Prop 65 (US) Page
	Given In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	Given In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
    Given in the Inventory Status, Prop 65 (US) page I click Continue

	#Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Walgreens
	Given I should see the Retailer Page
	Given In the Retailer Section, click 'Add Retailers' button
	Given In the Select Retailers window, select retailer: Walgreens
	Given In the Select Retailers window, click 'Done' button
	Given in the Retailer page I click Continue

	#Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC60723, container type: Glass Container and size: 20
	Given I should see the Universal Product Code (UPC) Page
	Given In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, I click the Add UPC Button
	Given In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, for section: 'Provide the product's UPC(s)- including container type and size (ounces)' enter UPC Number: saved as UPC60723 enter Size: 20 and enter Container Type: Glass Container
	Given in the Universal Product Code (UPC) page I click Continue

	Given I should see the Regulatory Documents to Provide Page
	And in the Regulatory Documents to Provide page I click Continue
	Then In the Regulatory Documents to Provide Section: 'Upload Full Product Label (required) (For private label products please upload a generic label that is not retailer-specific.)' error message should display: Document is required: Product Label
	Given In the Regulatory Documents to Provide Section, upload file in section: 'Upload Full Product Label (required) (For private label products please upload a generic label that is not retailer-specific.)'
	Given in the Regulatory Documents to Provide page I click Continue

	Given I should see the Additional Documents to Provide Page
	Then in the Additional Documents to Provide page I click Continue

	#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Comment Text
	Given In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: Comment Text
	Then in the Optional Comments page I click Continue

	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase60723
	Then In the Side Menu, click Labeled Link with My Products title
	Then In the Product Grid, delete the product saved as: TestCase60723

@ignore
@tfs_design
@TestCase:60722
Scenario: [60722] Nut Butters - RU001455
	#Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I log in with the account saved in TReVor as: ProductAccount
	Given If I see the retail partners page I set all data consent tiers to true for all retailers in the top section
	Then The home screen should load
	#Test Setup - Generating + Saving UPC Number and ensuring no duplicates exist
	Given I generate a random UPC number and save as: UPC60722
	Given I delete all products with UPC Number: saved as UPC60722
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Nut Butters
	Then I save the product information as: TestCase60722
	Given I call Shared Step 74123 (Product Information - Grocery - US - Random Country - No(PL))
	Given I call Shared Step 60741 (Select Primary Physical Property - Solid - With Ingredients)
	#Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I should see the Inventory Status, Prop 65 (US) Page
	Then In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	Then In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page I click Continue

	#Confirm that "Auto Zone" is not listed as a retailer on the Select Retailers pop up
	Given I call Shared Step 69682 (Retailer Association - Add Private Label Information) and select the retailer: Walgreens and enter the name: Private Label Aspirin
	Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC60722, container type: Cardboard and size: 20
	#Given I call Shared Step 60567 (Upload Product Label only)
	Given I should see the Regulatory Documents to Provide Page
	Given in the Regulatory Documents to Provide page I click Continue
	Then In the Regulatory Documents to Provide Section: 'Upload Full Product Label (required) (For private label products please upload a generic label that is not retailer-specific.)' error message should display: Document is required: Product Label
	Then In the Regulatory Documents to Provide Section, upload file in section: 'Upload Full Product Label (required) (For private label products please upload a generic label that is not retailer-specific.)'
	Given in the Regulatory Documents to Provide page I click Continue

	#Additional Documents to Provide Page
	And I should see the Additional Documents to Provide Page
	Given I call Shared Step 60715 (Additional Documents to Provide - OSHA SDS - only) : UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf
	# Optional Reports and Documents Available for Purchase Page
	And I should see the Optional Reports and Documents Available for Purchase Page
	Then in the Optional Reports and Documents Available for Purchase page I click Continue
	#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Comment Text
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Nut Butters
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase60722

@ignore
@TestCase:73041
Scenario: [73041] Cereals - RU001448 - Retailers associated Walgreens
	#Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I log in with the account saved in TReVor as: ProductAccount
	Given If I see the retail partners page I set all data consent tiers to true for all retailers in the top section
	Then The home screen should load
	#Test Setup - Generating + Saving UPC Number and ensuring no duplicates exist
	Given I generate a random UPC number and save as: UPC73041
	Given I delete all products with UPC Number: saved as UPC73041
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Cereals
	Then I save the product information as: TestCase73041
	Given I call Shared Step 74123 (Product Information - Grocery - US - Random Country - No(PL))
	Given I call Shared Step 60741 (Select Primary Physical Property - Solid - With Ingredients)
	#And I call Shared Step 132370 (Waste Classification Data - TSCA (Random) - Prop 65 (No) - Continue - Happy Path)
	Given I should see the Inventory Status, Prop 65 (US) Page
	Then In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	Then In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page I click Continue

	Then I click 'Add Retailers' in the Retailers page
	Then In the 'Select retailers' window I should see the following retailers:
		| Retailer                   |	
		| Walgreens                  |
	Given I click Done in the Select Retailers popup
	Given I navigate to the home page
	Then I delete the product: TestCase73041
