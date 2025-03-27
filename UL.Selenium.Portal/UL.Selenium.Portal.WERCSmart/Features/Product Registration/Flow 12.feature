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
@SHA
@run_Flow12
@MyAccount
@StepsPrototype
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:NewProduct
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
@ProductGrid

Feature: Flow 12

#Background:
#Given I verify the following users exist and if not I create them using SHAUser
#		| SHAQAAuto9  | QA        | Automation | QA Reviewers | qasha.kxxyxunf@mailosaur.io |

#Scenario: [58430] Mixture, Blend, Formulation, Solution - RU000722
#
## Created by Aaron Caton
#
## Test case can be found at the following paths:
## NetProjects10\WERCSmart UX Reboot\WERCSmart\Product Registration\Flow 12
## NetProjects10\WercsSmart Portal\WERCSmart\Product Registration\Flow 12 - 3rd Party
@TestCase:58430
Scenario: [58430] Mixture, Blend, Formulation, Solution - RU000722

	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load

	#And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration '
	Then in the New Product page, I click Continue

	#And I call Shared Step 82831 (The Product - Enter Product Name and Select Type of Product: Mixture, Blend, Formula, Polymer or Solution from Third (3rd, 3d) Party)
	Then I should be on the The Product Page
	And In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Mixture, Blend, Formula, Polymer or Solution from Third (3rd, 3d) Party
	And In the Product Section, set the option in section: 'Type of Product (select)' to: Mixture, Blend, Formula, Polymer or Solution from Third (3rd, 3d) Party
	Then in the The Product page, I click Continue

	Then I save the product information as: TestCase58430

	#And I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
	#	| ComponentName  | Percent | PublicallyDisclosed | TradeSecret | PublicName |
	#	| 7647-14-5      | 33.33   | false               | false       |            |
	#	| Copper sulfate | 11.67   | false               | false       |            |
	#	| Nitric acid    | 55      | false               | false       |            |
	Then I should be on the Ingredients Page
	And In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue		| Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	| component name | Water        	| 100     | False               | False         |             |
	Then in the Ingredients page, I click Continue

	#And I call Shared Step 48948 (Formulation > 3rd Party - Select all)
	Then I should be on the Formulation > 3rd Party Page
	And In the Formulation > 3rdParty Section, set the radio option in section: 'By clicking Accept, I certify the formulation information entered is complete and accurate': to: Accept
	And In the Formulation > 3rdParty Section, set the radio option in section: 'Consent to Tier 2.1, 2.2, 4.2 Data Uses': to: Granted
	Then in the Formulation > 3rd Party page, I click Continue

	#And I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Then I should be on the Inventory Status, Prop 65 (US) Page
	And In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	And In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page, I click Continue

	#And I call Shared Step 60932 (Regulatory Information 2 - Microbeads - No)
	Then I should be on the Regulatory Information 2 Page
	And In the Regulatory Information 2 Section, set the option in section: 'Product contains microbeads' to: No
	Then in the Regulatory Information 2 page, I click Continue

	Then in the Additional Documents to Provide page, I click Continue

	Then I should be on the Formulation Names Page
	And In the Formulation Names section, for section: 'Formula Name for the WERCSmart Ingredient Directory' confirm that the textbox field is populated with: Mixture, Blend, Formula, Polymer or Solution from Third (3rd, 3d) Party
	And In the Formulation Names section, for section: 'Formula Name for the WERCSmart Ingredient Directory' clear the textbox field
	And in the Formulation Names page, I click Continue
	Then In the Formulation Names section, the section: 'Formula Name for the WERCSmart Ingredient Directory' should display an error message: This is a required field.
	And In the Formulation Names section, for section: 'Formula Name for the WERCSmart Ingredient Directory' enter text: Mixture, Blend, Formula, Polymer or Solution from Third (3rd, 3d) Party
	And In the Formulation Names section, confirm that the full text for section: 'Provide Public Name(s) of the formula you're registering.' is displayed
	And In the Formulation Names section, for section: 'Provide Public Name(s) of the formula you're registering.' confirm that the textbox option: Public Name 1 displays the shadow text: Public Name 1
	And In the Formulation Names section, for section: 'Provide Public Name(s) of the formula you're registering.' confirm that the textbox option: Public Name 2 displays the shadow text: Public Name 2
	And In the Formulation Names section, for section: 'Provide Public Name(s) of the formula you're registering.' confirm that the textbox option: Public Name 3 displays the shadow text: Public Name 3
	And In the Formulation Names section, confirm that the full text for section: 'Business to Consumer Name' is displayed
	And In the Formulation Names section, for section: 'Business to Consumer Name' confirm that the textbox displays the shadow text: Business-to-Consumer Name (Generic Ingredient Name)
	And In the Formulation Names section, for section: 'Business to Consumer Name' enter text: ={};
	And In the Formulation Names section, the section: 'Business to Consumer Name' should display an error message: Enter valid information (The following characters are not allowed: = ; ^ * ¿? !¡ \ ~ [] <> | {} + ® ™)
	And In the Formulation Names section, for section: 'Business to Consumer Name' enter text: test
	And In the Formulation Names section, the section: 'Business to Consumer Name' should not display an error message: Enter valid information (The following characters are not allowed: = ; ^ * ¿? !¡ \ ~ [] <> | {} + ® ™)
	Then in the Formulation Names page, I click Continue
	
	#And I call Shared Step 58610 (Confirm Restrict Use - Restrict)
	Then I should be on the Restrict Use Page
	And In the Restrict Use Section, set the option in section: 'Do you want to restrict searchable access to your registered formula?': to: Restrict
	And In the Restrict Use Section, I enter the text of Access Code field to: 12345678
	Then in the Restrict Use page, I click Continue

	Then I should be on the Sustainability Page
	Then in the Sustainability page, I click Continue

	#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: User added Comments Text 58605. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
	Then I should be on the Optional Comments Page
	And In the Optional Comments Section, in 'Provide any additional comments or information about the product that you want the Assessment Team to know.' enter comment test comment
	Then in the Optional Comments page, I click Continue

	#And I call Shared Step 73956 (Go to Summary and verify data) with product type: Mixture, Blend, Formula, Polymer or Solution from Third (3rd, 3d) Party
	Then I should be on the Data Acceptance Page
	And In the Data Acceptance Section, click 'Summary' button
	And I switch to the tab with Data Summary page
	And In the Summary Page, the 'Type of Product (select)' section should be showing the following value: Mixture, Blend, Formula, Polymer or Solution from Third (3rd, 3d) Party
	And I close the tab with Data Summary page
	Then I should be on the Data Acceptance Page

	#And I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase58430
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase58430
