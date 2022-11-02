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

Feature: Flow 12A

# Created by Saikiran Chittampally
# Test case can be found at the following paths:
# NetProjects10\WERCSmart UX Reboot\WERCSmart\Product Registration\Flow 12
@TestCase:98077
Scenario: [98077] 3rd Party Exclusive Use Option
	
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC98077
	Given I delete all products with UPC Number: saved as UPC98077
	Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Mixture, Blend, Formula, Polymer or Solution from Third (3rd, 3d) Party
	Then I save the product information as: TestCase98077
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Ethanol       | 20      | false               | false       |            |
		| Paracetamol   | 5       | false               | false       |            |
		| Aqua          | 50      | false               | false       |            |
		| Guaifenesin   | 25      | false               | false       |            |
	Given I call Shared Step 48948 (Formulation > 3rd Party - Select all)
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I call Shared Step 60932 (Regulatory Information 2 - Microbeads - No)
	Given in the Additional Documents to Provide section page I click Continue
	Given in the Formulation Names section page I click Continue
	Given I call Shared Step 58610 (Confirm Restrict Use - Restrict)
	Given in the Sustainability section page I click Continue
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Mixture, Blend, Formula, Polymer or Solution from Third (3rd, 3d) Party
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase98077
