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
@SummaryPage
@UPC
@SHA
@run_Flow8
@StepsPrototype
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:NewProduct
@ProductGrid
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:ProductInformation
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:TheProduct
@Ingredients
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:Formulation3rdParty
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:InventoryStatusProp65
@Product:WERCSmart_Account:Distributor_Page:NewProducts_Tab:ProductCharacteristics_Section:RegulatoryInformation2
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:FormulationNames
@Product:WERCSmart_Account:Distributor_Page:NewProducts_Tab:ProductCharacteristics_Section:RestrictUse
@Product:WERCSmart_Page:NewProducts_Tab:RewiewAndSubmit_Section:OptionalComments
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:DataAcceptance
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:Summary
@SideMenu

Feature: Flow 12A

# Created by Saikiran Chittampally
# Test case can be found at the following paths:
# NetProjects10\WERCSmart UX Reboot\WERCSmart\Product Registration\Flow 12
@TestCase:98077
Scenario: [98077] 3rd Party Exclusive Use Option

	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC98077
	Then In the Product Grid, delete all products with UPC Number: saved as UPC98077

	#Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Then In the Side Menu, click Labeled Link with Add Product title
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration'
	Then in the New Product page, I click Continue

	#Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Mixture, Blend, Formula, Polymer or Solution from Third (3rd, 3d) Party
	Then I should be on the The Product Page
	And In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Mixture, Blend, Formula, Polymer or Solution from Third (3rd, 3d) Party
	And In the Product Section, set the option in section: 'Type of Product (select)' to: Mixture, Blend, Formula or Solution from 3rd Party
	Then in the The Product page, I click Continue

	Then I save the product information as: TestCase98077

	#Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
	#	| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
	#	| Ethanol       | 20      | false               | false       |            |
	#	| Paracetamol   | 5       | false               | false       |            |
	#	| Aqua          | 50      | false               | false       |            |
	#	| Guaifenesin   | 25      | false               | false       |            |
	Then I should be on the Ingredients Page
	And In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue		| Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	| component name | Water        	| 100     | False               | False         |             |
	Then in the Ingredients page, I click Continue

	#Given I call Shared Step 48948 (Formulation > 3rd Party - Select all)
	Then I should be on the Formulation > 3rd Party Page
	And In the Formulation > 3rdParty Section, set the radio option in section: 'By clicking Accept, I certify the formulation information entered is complete and accurate': to: Accept
	And In the Formulation > 3rdParty Section, set the radio option in section: 'Consent to Tier 2.1, 2.2, 4.2 Data Uses': to: Granted
	Then in the Formulation > 3rd Party page, I click Continue

	#Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Then I should be on the Inventory Status, Prop 65 (US) Page
	And In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	And In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page, I click Continue

	#Given I call Shared Step 60932 (Regulatory Information 2 - Microbeads - No)
	Then I should be on the Regulatory Information 2 Page
	And In the Regulatory Information 2 Section, set the option in section: 'Product contains microbeads' to: No
	Then in the Regulatory Information 2 page, I click Continue

	Then in the Additional Documents to Provide page, I click Continue
	Then in the Formulation Names page, I click Continue

	#Given I call Shared Step 58610 (Confirm Restrict Use - Restrict)
	Then I should be on the Restrict Use Page
	And In the Restrict Use Section, set the option in section: 'Do you want to restrict searchable access to your registered formula?': to: Restrict
	And In the Restrict Use Section, I enter the text of Access Code field to: 12345678
	Then in the Restrict Use page, I click Continue

	Then in the Sustainability page, I click Continue

	#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test
	Then I should be on the Optional Comments Page
	And In the Optional Comments Section, in 'Provide any additional comments or information about the product that you want the Assessment Team to know.' enter comment test comment
	Then in the Optional Comments page, I click Continue

	#Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Mixture, Blend, Formula, Polymer or Solution from Third (3rd, 3d) Party
	Then I should be on the Data Acceptance Page
	And In the Data Acceptance Section, click 'Summary' button
	And I switch to the tab with Data Summary page
	And In the Summary Page, the 'Type of Product (select)' section should be showing the following value: Mixture, Blend, Formula or Solution from 3rd Party
	And I close the tab with Data Summary page
	Then I should be on the Data Acceptance Page

	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase98077
	Then In the Side Menu, click Labeled Link with My Products title
	Then In the Product Grid, delete the product saved as: TestCase98077
	
# Created by Saikiran Chittampally
# Test case can be found at the following paths:
# NetProjects10\WERCSmart UX Reboot\WERCSmart\Product Registration\Flow 12
@TestCase:119476
Scenario: [119476] Mixture, Blend, Formulation, Solution Verifying Formula Name Updates- RU000722
	
	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC119476
	Then In the Product Grid, delete all products with UPC Number: saved as UPC119476

	#Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Then In the Side Menu, click Labeled Link with Add Product title
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration'
	Then in the New Product page, I click Continue

	#Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Mixture, Blend, Formula, Polymer or Solution from Third (3rd, 3d) Party
	Then I should be on the The Product Page
	And In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Mixture, Blend, Formula, Polymer or Solution from Third (3rd, 3d) Party
	And In the Product Section, set the option in section: 'Type of Product (select)' to: Mixture, Blend, Formula, Polymer or Solution from Third (3rd, 3d) Party
	Then in the The Product page, I click Continue

	Then I save the product information as: TestCase119476

	#Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
	#	| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
	#	| Ethanol       | 20      | false               | false       |            |
	#	| Paracetamol   | 5       | false               | false       |            |
	#	| Aqua          | 50      | false               | false       |            |
	#	| Guaifenesin   | 25      | false               | false       |            |
	Then I should be on the Ingredients Page
	And In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue		| Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	| component name | Water        	| 100     | False               | False         |             |
	Then in the Ingredients page, I click Continue

	#Given I call Shared Step 48948 (Formulation > 3rd Party - Select all)
	Then I should be on the Formulation > 3rd Party Page
	Then In the Formulation > 3rdParty Section, I confirm text 'Chemical Assessments and SDS Authoring' should be displayed
	And In the Formulation > 3rdParty Section, set the radio option in section: 'By clicking Accept, I certify the formulation information entered is complete and accurate': to: Accept
	Then In the Formulation > 3rdParty Section, I confirm text 'Data Use Consents' should be displayed
	And In the Formulation > 3rdParty Section, set the radio option in section: 'Consent to Tier 2.1, 2.2, 4.2 Data Uses': to: Granted
	Then in the Formulation > 3rd Party page, I click Continue

	#Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Then I should be on the Inventory Status, Prop 65 (US) Page
	And In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	And In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page, I click Continue

	#Given I call Shared Step 60932 (Regulatory Information 2 - Microbeads - No)
	Then I should be on the Regulatory Information 2 Page
	And In the Regulatory Information 2 Section, set the option in section: 'Product contains microbeads' to: No
	Then in the Regulatory Information 2 page, I click Continue
	Then in the Additional Documents to Provide page, I click Continue

	Then I should be on the Formulation Names Page
	Then In the Formulation Names section, confirm that the text: 'Provide the name(s) to be used to identify the formula' is displayed
	Then In the Formulation Names section, confirm that the text: 'The product name registered initially with the formula' is displayed
	And In the Formulation Names section, confirm that the full text for section: 'Provide Public Name(s) of the formula you're registering.' is displayed
	And In the Formulation Names section, for section: 'Formula Name for the WERCSmart Ingredient Directory' confirm that the textbox field is populated with: 'Mixture  Blend  Formula  Polymer or Solution from '
	And In the Formulation Names section, for section: 'Formula Name for the WERCSmart Ingredient Directory' clear the textbox field
	And In the Formulation Names section, for section: 'Formula Name for the WERCSmart Ingredient Directory' enter text: Aerosol
	Then In the Formulation Names section, confirm that the question: 'Preliminary Chemical Abstract Number (CAS) if available' is displayed
	And In the Formulation Names section, for section: 'Provide Public Name(s) of the formula you're registering.' confirm that the textbox option: Public Name 1 displays the shadow text: Public Name 1
	And In the Formulation Names section, for section: 'Provide Public Name(s) of the formula you're registering.' confirm that the textbox option: Public Name 2 displays the shadow text: Public Name 2
	And In the Formulation Names section, for section: 'Provide Public Name(s) of the formula you're registering.' confirm that the textbox option: Public Name 3 displays the shadow text: Public Name 3
	Then in the Formulation Names page, I click Continue

	#Given I call Shared Step 58610 (Confirm Restrict Use - Restrict)
	Then I should be on the Restrict Use Page
	And In the Restrict Use Section, set the option in section: 'Do you want to restrict searchable access to your registered formula?': to: Restrict
	And In the Restrict Use Section, I enter the text of Access Code field to: 12345678
	Then in the Restrict Use page, I click Continue

	Then I should be on the Sustainability Page
	Then in the Sustainability page, I click Continue

	#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test
	Then I should be on the Optional Comments Page
	And In the Optional Comments Section, in 'Provide any additional comments or information about the product that you want the Assessment Team to know.' enter comment test comment
	Then in the Optional Comments page, I click Continue

	#Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Mixture, Blend, Formula, Polymer or Solution from Third (3rd, 3d) Party
	Then I should be on the Data Acceptance Page
	And In the Data Acceptance Section, click 'Summary' button
	And I switch to the tab with Data Summary page
	And In the Summary Page, the 'Provide the name(s) to be used to identify the formula' section should be showing the following value: Aerosol
	And I close the tab with Data Summary page
	Then I should be on the Data Acceptance Page

	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase119476
	Then In the Side Menu, click Labeled Link with My Products title
	Then In the Product Grid, delete the product saved as: TestCase119476

