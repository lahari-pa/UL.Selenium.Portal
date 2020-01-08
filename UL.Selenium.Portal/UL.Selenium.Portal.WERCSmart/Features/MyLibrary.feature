@Shared
@Homepage
@Login
@Signup
@MyAccount
@wercsmart
@SubEnrollment
@LandingPage
@PaymentMethods
@NewProduct
@PackagingTypes
@Brands
@MyIngredients
@DataSummarySheet
@ProductGrid
@ProductSetUp
@run_MyLibrary
Feature: MyLibrary

@ScenarioId:797
Scenario: [64884] My Library
	Given I Login into WERCSmart Portal - Admin Role - WERCs Visual Account
	Then The home screen should load
	Given I click on My Account
	Given In the My Account page I navigate to the My Library page
	Then I should see the following tabs in the My Library page
		| Tab                            |
		| My Packaging Types             |
		| My Brands                      |
		| My Distributors                |
		| My Ingredients                 |
		| Contact Information per SDS(s) |

@ScenarioId:799
Scenario: [70535] Add Brand
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I click on My Account
	Given In the My Account page I navigate to the My Library page
	Given I navigate to the My Brands tab in the My Library page
	Given I click 'Add New' in the My Brands section of My Library
	Given I enter the Brand Name: NewBrand(TM) in the input field on the expanded row
	Then I confirm the 'Active' input is checked on the expanded row in the My Brands grid
	Given I click Save on the expanded row in the My Brands grid
	Then I confirm the last saved brand appears in the My Brands grid
	Then I confirm that the text 'Yes' is displayed under the 'Active' column for the last saved brand
	And I save the active brands list to context
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	And I confirm that only 'Active' brands saved in My Library - My Brands appear in the 'Product Line or Brand' drop down

@ScenarioId:800
Scenario: [70536] Edit Brand - Deactivate
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I click on My Account
	Given In the My Account page I navigate to the My Library page
	Given I navigate to the My Brands tab in the My Library page
	Given I click 'Add New' in the My Brands section of My Library
	Given I enter the Brand Name: NewBrand(TM) in the input field on the expanded row
	Then I confirm the 'Active' input is checked on the expanded row in the My Brands grid
	Given I click Save on the expanded row in the My Brands grid
	Given I click Edit in the My Brands grid for the last saved brand
	Given I deselect the 'Active' checkbox on the expanded row in the My Brands grid
	Given I click Save on the expanded row in the My Brands grid
	Then I confirm that the text 'No' is displayed under the 'Active' column for the last saved brand
	And I save the active brands list to context
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	And I confirm that only 'Active' brands saved in My Library - My Brands appear in the 'Product Line or Brand' drop down

@ScenarioId:801
Scenario: [70537] Edit Brand - Update Name
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I click on My Account
	Given In the My Account page I navigate to the My Library page
	Given I navigate to the My Brands tab in the My Library page
	Given I click 'Add New' in the My Brands section of My Library
	Given I enter the Brand Name: NewTestBrand(TM) in the input field on the expanded row
	Then I confirm the 'Active' input is checked on the expanded row in the My Brands grid
	Given I click Save on the expanded row in the My Brands grid
	Given I click Edit in the My Brands grid for the last saved brand
	Given I enter the Brand Name: NewTestBrandEdited(TM) in the input field on the expanded row
	Given I click Save on the expanded row in the My Brands grid
	And I save the active brands list to context
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	And I confirm that only 'Active' brands saved in My Library - My Brands appear in the 'Product Line or Brand' drop down

@ScenarioId:798
Scenario: [70533] Edit Packaging Type
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I click on My Account
	Given In the My Account page I navigate to the My Library page
	Then I confirm the current active tab on the My Library page is: My Packaging Types
	Given I click 'Add New' in the My Packaging Types section of My Library
	Then I should see the Packaging Type Page
	Given I set the Package Type Name field to: Super Packaging Type (TM)
	Given I click continue
	Then I should see the Bill of Materials Page
	And I save the Packaging Type details as: ThisPackaging
	Given I click Add Row in the Bill Of Materials grid
	Given I select the option: Clear Glass for the My Packaging Materials field in the table
	Given I select the option: 250.0 for the My Packaging Weight (grams) field in the table
	Given I click continue
	Then I should see the CONEG Page
	Given I set the Does your container or any packaging in contact with food or drink (including cap) contain Bisphenol A (BPA) field to: No
	Given I set the Do you have a CONEG Certificate for this package? field to: Yes
	And I click the CONEG browse button and upload PDF: C:\Dependencies\WERCSmart\testdoc.pdf
	Given I click continue
	Given In the Data Acceptance page I click on the Accept button
	Then I confirm that the Packaging Type saved as: ThisPackaging appears in the My Packaging Types grid
	Given I edit Packaging Type saved as: ThisPackaging
	Given I set the Package Type Name field to: Super Packaging Type Edited (TM)
	Given I click continue
	And I save the Packaging Type details as: ThisPackaging
	Given I click continue
	Then I should see the CONEG Page
	Given I click continue
	Given In the Data Acceptance page I click on the Accept button
	Then I confirm that the Packaging Type saved as: ThisPackaging appears in the My Packaging Types grid
	Given I delete Packaging Type saved as: ThisPackaging
	Then I confirm the name and ID for Packaging Type saved as: ThisPackaging appear in the Delete Product pop up
	Given I click Delete in the Delete Product pop up
	Then I confirm that the Packaging Type saved as: ThisPackaging does not appear in the My Packaging Types grid

@ScenarioId:802
Scenario: [70539] Add an Ingredient (Basic) and remove
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I click on My Account
	Given In the My Account page I navigate to the My Library page
	Given I navigate to the My Ingredients tab in the My Library page
	And I save the current list of ingredients in My Library to context as: My Library Ingredients
	Given I enter the text: wat into the My Ingredients search field
	And I select the smart search result with name: Water and CAS: 7732-18-5
	And I save the ingredient I added in My Library to context as: water70539
	Given I click Save in the My Ingredients tab
	Given I click the WERCSmart logo
	Then The home screen should load
	#This is a pre-set up product which we know has the Ingredients option in the Product Characteristics tab
	# this is not reliable.. replace with step - I take a product to the Ingredients screen (product set up steps)
	#Given I edit the product with ID: 1470688
	Given I create a product and take it to the ingredients page and save as: TestCase70539
	#Given In the New Product page I click tab: Product Characteristics
	#
	#And in the New Product page I click section: Ingredients
	Given I click the 'Use My Ingredients' button
	Then I see the My Ingredients pop up
	And I confirm My Ingredient saved as: water70539 appears in the Use My Ingredients popup
	And I click OK in the My Ingredients dialog
	Given I click on My Account
	Given In the My Account page I navigate to the My Library page
	Given I navigate to the My Ingredients tab in the My Library page
	Given I remove My Ingredient in My Library saved as: water70539
	Then I confirm the component name in the delete product popup matches the ingredient saved as: water70539
	Given I click: YES in the 'Remove Component from My Ingredients' pop up
	Then I confirm My Ingredient saved as: water70539 in My Library has been removed from the grid
	# delete TestCase70539
	Then I navigate to the home page
	Then I delete the product: TestCase70539

@ScenarioId:803
Scenario: [70556] Add an Ingredient (Trade secret) and remove
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I click on My Account
	Given In the My Account page I navigate to the My Library page
	Given I navigate to the My Ingredients tab in the My Library page
	And I save the current list of ingredients in My Library to context as: My Library Ingredients
	Given I enter the text: wat into the My Ingredients search field
	And I select the smart search result with name: Water and CAS: 7732-18-5
	And I save the ingredient I added in My Library to context as: water70556
	Given I click the Trade Secret checkbox for My Ingredient saved as: water70556
	And I click Save in the My Ingredients tab
	Given I click the WERCSmart logo
	Then The home screen should load
	#This is a pre-set up product which we know has the Ingredients option in the Product Characteristics tab
	#Given I edit the product with ID: 1470688
	#
	#Given In the New Product page I click tab: Product Characteristics
	#
	#And in the New Product page I click section: Ingredients
	Given I create a product and take it to the ingredients page and save as: TestCase70556
	Given I click the 'Use My Ingredients' button
	Then I see the My Ingredients pop up
	And I confirm My Ingredient saved as: water70556 appears in the Use My Ingredients popup
	And I click OK in the My Ingredients dialog
	Given I click on My Account
	Given In the My Account page I navigate to the My Library page
	Given I navigate to the My Ingredients tab in the My Library page
	Given I remove My Ingredient in My Library saved as: water70556
	Then I confirm the component name in the delete product popup matches the ingredient saved as: water70556
	Given I click: YES in the 'Remove Component from My Ingredients' pop up
	Then I confirm My Ingredient saved as: water70556 in My Library has been removed from the grid
	Then I navigate to the home page
	Then I delete the product: TestCase70556

Scenario: [70567] Add an Ingredient (Publicly Disclosed) and remove
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I click on My Account
	Given In the My Account page I navigate to the My Library page
	Given I navigate to the My Ingredients tab in the My Library page
	And I save the current list of ingredients in My Library to context as: My Library Ingredients
	# Test specifies 'type 50-00' and select Formaldehyde but this is returning all results containing sequence '500' in the CAS,
	# ordererd numerically, disregarding the dash.
	# Suggest adding better 'search functionality' tests later.
	# There is a lot of junk data, and the results for 50-00-0 search are not displaying the Public Name/ synonym options.
	# Have reported to Amanda. Use search by name for now.
	Given I enter the text: Formald into the My Ingredients search field
	And I select the smart search result with name: Formaldehyde and CAS: 50-00-0
	And I save the ingredient I added in My Library to context as: formaldehyde70567
	Given I click the Publicly Disclosed checkbox for My Ingredient saved as: formaldehyde70567
	Given I set the Public Name to be: Formaldehyde solution for My Ingredient saved as: formaldehyde70567
	And I click Save in the My Ingredients tab
	Given I click the WERCSmart logo
	Then The home screen should load
	#This is a pre-set up product which we know has the Ingredients option in the Product Characteristics tab
	#Given I edit the product with ID: 1470688
	#
	#Given In the New Product page I click tab: Product Characteristics
	#
	#And in the New Product page I click section: Ingredients
	Given I create a product and take it to the ingredients page and save as: TestCase70567
	Given I click the 'Use My Ingredients' button
	Then I see the My Ingredients pop up
	And I confirm My Ingredient saved as: formaldehyde70567 appears in the Use My Ingredients popup
	And I click OK in the My Ingredients dialog
	Given I click on My Account
	Given In the My Account page I navigate to the My Library page
	Given I navigate to the My Ingredients tab in the My Library page
	Given I remove My Ingredient in My Library saved as: formaldehyde70567
	Then I confirm the component name in the delete product popup matches the ingredient saved as: formaldehyde70567
	Given I click: YES in the 'Remove Component from My Ingredients' pop up
	Then I confirm My Ingredient saved as: formaldehyde70567 in My Library has been removed from the grid
	Then I navigate to the home page
	Then I delete the product: TestCase70567

Scenario: [73329] Edit Ingredient
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I click on My Account
	Given In the My Account page I navigate to the My Library page
	Given I navigate to the My Ingredients tab in the My Library page
	Given I add the following ingredients and save them to context as: My Library New Ingredients
		| Chemical Name             | CAS          |
		| Sulfuric acid             | 7664-93-9    |
		| Cobalt sulfate            | 10124-43-3   |
		| Graphene                  | 1034343-98-0 |
		| Pyrrole-2-carboxylic acid | 634-97-9     |
		| Formaldehyde              | 50-00-0      |
		| Polycarbonate             | 25037-45-0   |
		| Nitric acid               | 7697-37-2    |
		| Cumene                    | 98-82-8      |
		| Argon                     | 7440-37-1    |
		| Mica                      | 12001-26-2   |
	# The test has a step 'Select one of the ingredients' before editing other ones. Having an ingredient selected has no bearing on 'Save' so skipping this
	# And I select the ingredient in My Library at index: 5 from ingredients saved as: My Library Ingredients
	# Explicit 'true/false' will only ever edit ingredient state once. Flip the checkbox with Y/N, avoid checking the same value repeatedly
	# Public Name iterates the option up or down in the list of dropdown options (+,-). If index out of range, select the first option
	Given I edit the ingredients: My Library New Ingredients and save the edited ingredients to context as: My Library Ingredients Edited
		| Index | Click Publicly Disclosed | Click Trade Secret | Public Name Change |
		| 1     | Y                        | N                  | +                  |
		| 2     | N                        | Y                  | =                  |
		| 3     | N                        | N                  | -                  |
		| 4     | N                        | Y                  | =                  |
		| 5     | Y                        | N                  | +                  |
		| 6     | Y                        | N                  | +                  |
		| 7     | N                        | Y                  | =                  |
		| 8     | N                        | N                  | -                  |
		| 9     | N                        | Y                  | =                  |
		| 10    | Y                        | N                  | +                  |
	And I click Save in the My Ingredients tab
	Given I navigate to the home page
	Then The home screen should load
	Given I click on My Account
	Given In the My Account page I navigate to the My Library page
	Given I navigate to the My Ingredients tab in the My Library page
	And I confirm that all changes in edited ingredients: My Library Ingredients Edited were saved
	# Repeat editing steps - check saved changes persist over mutliple operation
	Given I edit the ingredients: My Library Ingredients Edited and save the edited ingredients to context as: My Library Ingredients Edited 2
		| Index | Click Publicly Disclosed | Click Trade Secret | Public Name Change |
		| 1     | Y                        | N                  | +                  |
		| 2     | N                        | Y                  | +                  |
		| 3     | Y                        | N                  | -                  |
		| 4     | N                        | Y                  | +                  |
		| 5     | N                        | N                  | =                  |
		| 6     | Y                        | Y                  | =                  |
		| 7     | N                        | Y                  | =                  |
		| 8     | Y                        | N                  | -                  |
		| 9     | N                        | Y                  | =                  |
		| 10    | Y                        | Y                  | =                  |
	And I click Save in the My Ingredients tab
	Given I navigate to the home page
	Then The home screen should load
	Given I click on My Account
	Given In the My Account page I navigate to the My Library page
	Given I navigate to the My Ingredients tab in the My Library page
	Then I confirm that all changes in edited ingredients: My Library Ingredients Edited 2 were saved
	And I remove all ingredients in the list saved as: My Library New Ingredients

@ScenarioId:805
Scenario: [73328] Pagination functionality
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I click on My Account
	Given In the My Account page I navigate to the My Library page
	Given I navigate to the My Ingredients tab in the My Library page
	Then I ensure that there are enough Ingredients in the My Ingredients page to enable pagination
	And I save the current list of ingredients in My Library to context as: My Library Ingredients Pagination
	Then I confirm the navigation button is enabled in the My Ingredients grid
	Given I click the Next button in the My Ingredients grid navigation
	Then I confirm the current active page number in the My Ingredients grid is: 2
	And I confirm the ingredients for page 2 saved as: My Library Ingredients Pagination are displayed
	Given I click the Next button in the My Ingredients grid navigation
	Then I confirm the current active page number in the My Ingredients grid is: 3
	And I confirm the ingredients for page 3 saved as: My Library Ingredients Pagination are displayed
	Given I click the Previous button in the My Ingredients grid navigation
	Then I confirm the current active page number in the My Ingredients grid is: 2
	And I confirm the ingredients for page 2 saved as: My Library Ingredients Pagination are displayed
	Given I click the Previous button in the My Ingredients grid navigation
	Then I confirm the current active page number in the My Ingredients grid is: 1
	And I confirm the ingredients for page 1 saved as: My Library Ingredients Pagination are displayed
	Given I click page number: 2 in the My Ingredients grid navigation
	Then I confirm the current active page number in the My Ingredients grid is: 2
	And I confirm the ingredients for page 2 saved as: My Library Ingredients Pagination are displayed
	Given I click page number: 3 in the My Ingredients grid navigation
	Then I confirm the current active page number in the My Ingredients grid is: 3
	And I confirm the ingredients for page 3 saved as: My Library Ingredients Pagination are displayed
	And I navigate to the home page

@ScenarioId:804
Scenario: [73326] Searching an Ingredient
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I click on My Account
	Given In the My Account page I navigate to the My Library page
	Given I navigate to the My Ingredients tab in the My Library page
	Given I enter the text: 50-0 into the My Ingredients search field
	Then I confirm that the smart search results contain a chemical with CAS: 50-00-0 and Name: Formaldehyde
	Given I enter the text: Formald into the My Ingredients search field
	Then I confirm that the smart search results contain a chemical with CAS: 50-00-0 and Name: Formaldehyde
	And I navigate to the home page

Scenario: [70516] Add and Remove Packaging Type
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I click on My Account
	Given In the My Account page I navigate to the My Library page
	Then I confirm the current active tab on the My Library page is: My Packaging Types
	Given I click 'Add New' in the My Packaging Types section of My Library
	Then I should see the Packaging Type Page
	Given I set the Package Type Name field to: Super Packaging Type 1 (TM)
	Given I click continue
	Then I should see the Bill of Materials Page
	And I save the Packaging Type details as: ThisPackaging
	Given I click Add Row in the Bill Of Materials grid
	Given I select the option: Clear Glass for the My Packaging Materials field in the table
	Given I select the option: 99 for the My Packaging Weight (grams) field in the table
	Given I click continue
	Then I should see the CONEG Page
	Given I set the Does your container or any packaging in contact with food or drink (including cap) contain Bisphenol A (BPA) field to: No
	Given I set the Do you have a CONEG Certificate for this package? field to: Yes
	And I click the browse button for label: CONEG Certificate and upload PDF: C:\Dependencies\WERCSmart\testdoc.pdf
	#And I Verify the 'VIEW' and 'REMOVE' Buttons become active
	#And I Click the 'VIEW BUTTON'
	#And I Confirm the file opens for viewing in a new window
	#And I Close the window
	Given I click continue
	Then I should see the Data Acceptance Page
	#And I Confirm the following statement displays under 'Data Acceptance' - "In case of any problem with this product we will communicate to the following email address. Please update this email address if you want us to use a different email"
	#And I Confirm the email registered (user) is populated in the field under the Statement
	#And I Confirm the 'SUMMARY BUTTON' is available
	#And I Confirm the 'SUMMARY' Page opens in a NEW TAB
	Given I click the Summary button in the Data Acceptance window
	Given I switch to the Data Summary page
	Then Product Name should be showing value: Super Packaging Type 1 (TM)
	Given I close the Data Summary tab
	Then I should see the Data Acceptance Page
	#And I Verify the 'Summary Page' matched with the data/text entered for the '' you created
	#And I Click on the top-right 'PRINT BUTTON'
	#And I Verify the 'Summary Print Preview' contains the information you entered for the Packaging Type
	#And I Close the 'Print Preview Tab'
	#And I Click the 'ACCEPT BUTTON'
	Given In the Data Acceptance page I click on the Accept button
	#And I Verify your 'ID number and Packaging Type Name' appears under "ID / Packaging Type Name"
	Then I confirm that the Packaging Type saved as: ThisPackaging appears in the My Packaging Types grid
	#And I Verify the date appears under "Date Created"
	#And I Under the 'Actions Column' - Click on the [...]
	#And I Select the 'DELETE' Option
	#And I Verify popup Delete Product with message " Are you sure you want to remove this item?" and the name  and ID of your new packaging type
	#And I Click the 'DELETE Button'
	Given I delete Packaging Type saved as: ThisPackaging
	Then I confirm the name and ID for Packaging Type saved as: ThisPackaging appear in the Delete Product pop up
	Given I click Delete in the Delete Product pop up
	And I confirm that the Packaging Type saved as: ThisPackaging does not appear in the My Packaging Types grid
