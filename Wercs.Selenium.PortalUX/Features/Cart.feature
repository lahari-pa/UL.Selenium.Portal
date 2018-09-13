@LandingPage
@Login
@Homepage
@wercsmart
@NewProduct
@run_Cart
@SubEnrollment

Feature: Cart

Background:
Given I go to the WERCSmart Log in

@mytag
Scenario: [66635] Left hand navigation - Shopping Cart navigation - Products
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load
Given I click the Shopping Cart icon in the Navigation Pane


Scenario: [63323] Remove single product from cart
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load
Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk
Then I save the product information as: TestCase63323
Given I call Shared Step 26897 (Product Characteristics - Solid only available - continue)
Given I call Shared 57401 (Additional Product Information - US only - No GHS, Not Direct Ship, Not PLP, Not GNFR > Continue - Happy Path)
Given I call Shared Step 29181 (Ingredients - add any chemical) with name: 63323
Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Given I call Shared Step 63219 (Retailer Association - Select No Retailer - Click continue)
Given I call Shared 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
#Click Continue on Additional Documents to Provide
#Click on the Australia GHS SDS dropdown box for Optional Reports and Documents Available for Purchase screen = English (U.S) , English(Australian) option displays)
#Select both options (English (U.S) , English(Australian)) =  Fees displays on right side under total ($400)
#Click Continue
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase63323

Scenario: [74837] Shopping Cart navigation with subscription without products

Given I log in with the subscription without products account

Then The home screen should load

Given I click the Shopping Cart icon in the Navigation Pane

Then I should see the empty shopping cart pop up

And the Empty Cart pop up message reads: There are no items in the shopping cart.

Given I close the Empty Cart pop up

Then The home screen should load

# Currently not working in staging because this account is not set up (works on local)
Scenario: [74919] Shopping cart navigation with products in cart without subscription

Given I log in with the without subscription without products account

Then The home screen should load

Given I click the Shopping Cart icon in the Navigation Pane

Then the Subscription Enrollment page should load

And I see the alert message with text: Subscription enrollment is required to submit your registration for assessment. Please enroll at this time. Once you purchase your subscription, the registration data will transfer for assessment. under Subscription Enrollment
