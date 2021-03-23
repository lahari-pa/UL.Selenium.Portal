@Shared
@LandingPage
@Login
@Homepage
@wercsmart
@NewProduct
@run_Cart
@SubEnrollment
@Cart
@PaymentMethods
@ProductGrid
Feature: Cart

#Background:
## THIS IS IN THE PRODUCTION BRANCH (MAYBE, HOPEFULLY)
#Given I go to the WERCSmart Log in
@mytag
@ScenarioId:1008
Scenario: [66635] Left hand navigation - Shopping Cart navigation - Products
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I click the Shopping Cart icon in the Navigation Pane

@ScenarioId:1007
Scenario: [63323] Remove single product from cart
	Given I log in with the account saved in TReVor as: CartNoProducts
       Then The home screen should load
       Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
       Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk
       Then I save the product information as: TestCase63323
	   Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
       Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
       Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
             | ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
             | Propane       | 100     | false               | false       |            |
       Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
       Given I call Shared Step 63219 (Retailer Association - Select No Retailer - Click continue)
       Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
       Given in the Additional Documents to Provide page I click Continue
       Given I click the Australia GHS SDS input section in Optional Reports and Documents Available for Purchase and select English (U.S)
       Given I click the Australia GHS SDS input section in Optional Reports and Documents Available for Purchase and select English (Australian)
       Given The total for section Australia GHS SDS in Optional Reports and Documents Available for Purchase should equal $400.00
       Given in the Optional Reports and Documents Available for Purchase page I click Continue
       Given I call Shared Step 64097 - Additional Documents -> Contact Information - Add any Name, address, phone and emergency phone - Happy Path
       Given I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
             | Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
             | Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
       Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: test
       Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
       Given In the Purchase Summary screen I click Remove for product saved as TestCase63323
	   Then I wait for a modal dialog to open
       Given in the modal dialog I click the "CANCEL" button
       Given In the Purchase Summary screen I confirm the Purchase Summary header is displayed
       Given In the Purchase Summary screen I click Remove for product saved as TestCase63323
	   Then I wait for a modal dialog to open
       Given in the modal dialog I click the "REMOVE" button
       Then The home screen should load
       And I search for the product saved as: TestCase63323
       And I click Row Actions for the first product returned
       And I should see the following Actions options
             | Option    |
             | Submit    |
             | Edit      |
             | Delete    |
             | View UPCs |
       Given I click the Shopping Cart icon in the Navigation Pane
       Then I confirm that I see the following text in the modal window popup: There are no items in the shopping cart.
       Then If a modal dialog opens I close it
       Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase63323


@ScenarioId:1009
Scenario: [74837] Shopping Cart navigation with subscription without products
	Given I log in with the subscription without products account
	Then The home screen should load
	Given I click the Shopping Cart icon in the Navigation Pane
	Then I should see the empty shopping cart pop up
	And the Empty Cart pop up message reads: There are no items in the shopping cart.
	Given I close the Empty Cart pop up
	Then The home screen should load

@ScenarioId:1010
Scenario: [74919] Shopping cart navigation with products in cart without subscription
	Given I log in with the without subscription without products account
	Then The home screen should load
	Given I click the Shopping Cart icon in the Navigation Pane
	Then the Subscription Enrollment page should load
	And I see the alert message with text: Subscription enrollment is required to submit your registration for assessment. Please enroll at this time. Once you purchase your subscription, the registration data will transfer for assessment. under Subscription Enrollment
