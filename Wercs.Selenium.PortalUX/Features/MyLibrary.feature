@Homepage
@Login
@Signup
@MyAccount
@wercsmart
@SubEnrollment
@LandingPage
@PaymentMethods
@NewProduct
@run_MyLibrary

Feature: MyLibrary

Scenario: [64884] My Library

Given I Login into WERCSmart Portal - Admin Role - WERCs Visual Account

Then The home screen should load

Given I click on My Account

Given In the My Account screen I navigate to the My Library page

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

Given In the My Account screen I navigate to the My Library page

Given I navigate to the My Brands tab in the My Library page

Given I click 'Add New' in the My Brands section of My Library

Given I enter the Brand Name: NewBrand(TM) in the input field on the expanded row

Then I confirm the 'Active' input is checked on the expanded row in the My Brands grid

Given I click Save on the expanded row in the My Brands grid

Then I confirm the last saved brand appears in the My Brands grid

Then I confirm that the text 'Yes' is displayed under the 'Active' column for the last saved brand

Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)

Then I confirm the last created brand in My Library - My Brands appears in the 'Product Line or Brand' drop down
