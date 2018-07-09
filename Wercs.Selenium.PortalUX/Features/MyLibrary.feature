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
@ProductGrid
@run_MyLibrary

Feature: MyLibrary

Scenario: [64884] My Library

Given I Login into WERCSmart Portal - Admin Role - WERCs Visual Account

Then The home screen should load

Given I click on My Account

Given In the My Account page I navigate to the My Library page

Then I should see the following tabs in the My Library page
| Tab                |
| My Packaging Types |
| My Brands          |
| My Distributors    |
| My Ingredients     |

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

Scenario: [70537] Edit Brand - Update Name

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

Given I enter the Brand Name: NewBrandEdited(TM) in the input field on the expanded row

Given I click Save on the expanded row in the My Brands grid

And I save the active brands list to context

Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)

And I confirm that only 'Active' brands saved in My Library - My Brands appear in the 'Product Line or Brand' drop down

Scenario: [70516] Add and Remove Packaging Type

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

Given I select the option: 99 for the My Packaging Weight (grams) field in the table

Given I click continue

Given In the Data Acceptance page I click on the Accept button

Then I confirm that the Packaging Type saved as: ThisPackaging appears in the My Packaging Types grid

Given I delete Packaging Type saved as: ThisPackaging

Then I confirm the name and ID for Packaging Type saved as: ThisPackaging appear in the Delete Product pop up

Given I click Delete in the Delete Product pop up

And I confirm that only 'Active' brands saved in My Library - My Brands appear in the 'Product Line or Brand' drop down

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

Given In the Data Acceptance page I click on the Accept button

Then I confirm that the Packaging Type saved as: ThisPackaging appears in the My Packaging Types grid

Given I edit Packaging Type saved as: ThisPackaging

Given I set the Package Type Name field to: Super Packaging Type Edited (TM)

Given I click continue

And I save the Packaging Type details as: ThisPackaging

Given I click continue

Given In the Data Acceptance page I click on the Accept button

Then I confirm that the Packaging Type saved as: ThisPackaging appears in the My Packaging Types grid

Given I delete Packaging Type saved as: ThisPackaging

Then I confirm the name and ID for Packaging Type saved as: ThisPackaging appear in the Delete Product pop up

Given I click Delete in the Delete Product pop up

Then I confirm that the Packaging Type saved as: ThisPackaging does not appear in the My Packaging Types grid

Scenario: [70539] Add an Ingredient (Basic) and remove

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

Given I click on My Account

Given In the My Account page I navigate to the My Library page

Given I navigate to the My Ingredients tab in the My Library page

And I save the current list of ingredients in My Library to context

Given I enter the text: wat into the My Ingredients search field

And I select 'Water' from the smart search results

And I save the ingredient I added in My Library to context

Given I click Save in the My Ingredients tab

Given I click the WERCSmart logo

Then The home screen should load

#This is a pre-set up product which we know has the Ingredients option in the Product Characteristics tab
Given I edit the product with ID: 1470688

Given In the New Product page I click tab: Product Characteristics

And in the New Product page I click section: Ingredients

Given I click the 'Use My Ingredients' button

Then I see the My Ingredients pop up

Then I confirm that the component with name: Water is displayed in the My Ingredients pop up

And I click OK in the My Ingredients dialog

Given I click on My Account

Given In the My Account page I navigate to the My Library page

Given I navigate to the My Ingredients tab in the My Library page

Given I remove the last ingredient I added to My Library

Then I confirm the component name in the delete product popup matches the last ingredient I added

Given I click: YES in the 'Remove Component from My Ingredients' pop up

Then I confirm the ingredient I added to My Library has been removed from the ingredients grid
