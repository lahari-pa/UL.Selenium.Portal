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

@ScenarioId:1170
Scenario: [85492] Regulatory Information 1 - navigation
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk
	Then I save the product information as: TestCase85492
	Given I call Shared Step 26897 (Product Characteristics - Solid only available - continue)
	Given I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
	And I should see the Regulatory Information 1 Page
	And I should see following statement: U.S. Toxic Substances Control Act (TSCA) status
	And I should see following statement: Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase85492

@ScenarioId:1171
Scenario: [85693] Regulatory Information 1 - validation
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk
	Then I save the product information as: TestCase85693
	Given I call Shared Step 26897 (Product Characteristics - Solid only available - continue)
	Given I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
	When I click continue
	And U.S. Toxic Substances Control Act (TSCA) status should be showing the error messages: This is a required field.
	And Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)? should be showing the error messages: This is a required field.
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase85693

@ScenarioId:1172
Scenario: [85695] California Proposition 65 - select Yes - navigation
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk
	Then I save the product information as: TestCase85695
	Given I call Shared Step 26897 (Product Characteristics - Solid only available - continue)
	Given I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
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

	Scenario: [123123123] Actions - 3rd Party Access Code Window

Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Then I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
And I call Shared Step 82831 (The Product - Enter Product Name and Select Type of Product: Raw material)
Then I save the product information as: TestCase90002
Then I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
| CASNumber | ComponentName   | Percent | PublicallyDisclosed | PublicName | TradeSecret |
|           | Sodium chloride | 33.33   | false               |            | false       |
|           | Copper sulfate  | 11.67   | false               |            | false       |
|           | Nitric acid     | 55      | false               |            | false       |
Then I call Shared Step 48948 (Formulation > 3rd Party - Select all)
Then I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
Then I call Shared Step 60932 (Regulatory Information 2 - Microbeads - No)
Then I click continue
Then I click continue
Then I click continue
And I call Shared Step 58610 (Confirm Restrict Use - Restrict)
Then I should see the Sustainability Page
Given in the Sustainability page I click Continue
Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: User added Comments Text 58605. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
Given I click the Home navigation icon
Given I search for the product saved as: TestCase90002
When I click Row Actions for the most recent product returned
Then I click on the Row Action: Access Code
Then Check popup date productID: TestCase90002 productType:Raw material productAccessCode: 1234
And I close the window that opened


Scenario: [127575] Battery Registration - Regulatory Documents - Needs "I don't Need" Option

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load
Given I generate a random UPC number and save as: UPC59273
Given I delete all products with UPC Number: saved as UPC59273
Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Alkaline battery
Then I save the product information as: TestCase59273
Given I call Shared Step 59927 (Primary Physical State > Solid only available – Without Water Solubility question)
Given I should see the Additional Product Information Page
Given I call Shared Step 102767 (Additional Product Information (Battery flow - not Lithium) - OSHA (No), DSV (No), PLP (No), GNFR (No))
Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
| CASNumber | ComponentName       | Percent | PublicallyDisclosed | PublicName | TradeSecret |
|           | Potassium hydroxide | 20.5    | false               |            | false       |
|           | Zinc chloride       | 9.5     | false               |            | false       |
|           | Aqua                | 70      | false               |            | false       |
Given I call Shared Step 57637 (Regulatory Information 1 - TSCA & CEPA shown, No to PROP 65 - Continue - Happy Path)
Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Walgreens
Given I call Shared Step 60826 (Enter Universal Product Code (UPC) - Battery - Confirm Quantity ) for UPC saved as: UPC59273 with container type: Metal Container size: 40.0 and quantity: 100
Given I should see the Regulatory Documents to Provide Page
Then I check if AIS is not uploaded
Then I should not see radio option: I don't need a WHMIS Compliant SDS
Then I should not see radio option: I don't need an OSHA-Compliant Safety Data Sheet (SDS) document for this product
And I click the browse button for label: I have an Article Information Sheet (AIS), Technical Data Sheet (TDS), Battery Data Sheet (BDS) to provide. and upload PDF: C:\Dependencies\WERCSmart\testdoc.pdf
Then I should see radio option: I don't need an OSHA - Compliant Safety Data Sheet (SDS) Document for this product
Then I should see radio option: I don't need a WHMIS Compliant SDS
