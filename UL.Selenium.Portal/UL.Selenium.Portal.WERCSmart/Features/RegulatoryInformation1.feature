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
@run_RegulatoryInformation1
Feature: Regulatory Information 1

@TestCase:85492
Scenario: [85492] Regulatory Information 1 - navigation
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk
	Then I save the product information as: TestCase85492
	Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Water         | 100     | false               | false       |            |
	And I should see the Waste Classification Data Page
	And I should see following statement: U.S. Toxic Substances Control Act (TSCA) status
	And I should see following statement: Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase85492

@TestCase:85693
Scenario: [85693] Regulatory Information 1 - validation
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk
	Then I save the product information as: TestCase85693
	Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Water         | 100     | false               | false       |            |
	When I click continue
	And U.S. Toxic Substances Control Act (TSCA) status should be showing the error messages: This is a required field.
	And Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)? should be showing the error messages: This is a required field.
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase85693

@TestCase:85695
Scenario: [85695] California Proposition 65 - select Yes - navigation
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk
	Then I save the product information as: TestCase85695
	Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
	And I set the U.S. Toxic Substances Control Act (TSCA) status option to: Compliant
	And I set the Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)? option to: Yes
	And I should see following statement: Is the need to warn triggered by
	And I should see following statement: How is the exposure warning transmitted? For more information, see Notice of Adoption Article
	Then I click on the Notice of Adoption Article link
	And I confirm that a new Notice of Adoption Article tab opens and navigate to it
	And I close the Notice of Adoption Article tab
	And I should see following statement: Is your exposure warning compliant with Proposition 65 regulations applicable to products manufactured
	And I should see following statement: If the product carries a safe-harbor short-form warning, indicate which of the following is provided:
	And I should see following statement: If the product carries a safe-harbor long-form warning, indicate which of the following is used and enter the names of the Proposition 65 chemicals included in the warning:
	And I should see following statement: If the product carries a custom warning, please provide the exact text that is being used:
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase85695



