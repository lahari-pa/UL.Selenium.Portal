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

Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)

Then I confirm the last created brand in My Library - My Brands appears in the 'Product Line or Brand' drop down

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

Then I confirm that the Packaging Type saved as: ThisPackaging does not appear in the My Packaging Types grid
