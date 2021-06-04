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

Feature: UPCCheckDigit


Scenario: [Jacob] UPC Check Digit validations
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	And I call Shared Step 82831 (The Product - Enter Product Name and Select Type of Product: Mixture, Blend, Formula, Polymer or Solution from Third (3rd, 3d) Party)
	Then I save the product information as: TestCase58430
	And I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Water         | 100     | false               | false       |            |
	And I call Shared Step 48948 (Formulation > 3rd Party - Select all)
	And I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	And I call Shared Step 60932 (Regulatory Information 2 - Microbeads - No)
	And I click continue
	And I should see following statement: Provide the name(s) to be used to identify the formula
	Then I set the Formula Name for the WERCSmart Ingredient Directory field to: -
	Then I set the Formula Name for the WERCSmart Ingredient Directory field to: Mixture, Blend, Formula, Polymer or Solution from Third (3rd, 3d) Party
	And I should see following statement: Provide Public Name(s) of the formula you're registering. This will be available to the Supplier to select for your ingredient when the ingredient is indicated to be Publicly Available. Public Names are typically on a products label, website or other information available to the general public.
	And I should see following statement: Public Name 1
	And I should see following statement: Public Name 2
	And I should see following statement: Public Name 3
	And I should see following statement: For ingredients used in cleaning products its Business-to-Consumer name must comply with the requirements of the California Cleaning Product Right to Know Act. Manufacturer must use a name that is only as generic as necessary to protect the confidential identity of the ingredient. In developing the generic name, the manufacturer must use the generic name framework provided by the Federal Environmental Protection Agency (EPA) guidance for the Toxic Substances Control Act (TSCA) Confidential Inventory.
	And I should see following statement: Business to Consumer Name
	Then I check that the input field with label: Business to Consumer Name has the following placeholder: Business-to-Consumer Name (Generic Ingredient Name)
	Then I set the Business to Consumer Name field to: = ; ^ * ¿? !¡ \ ~ [] <> | {} + )
	Then I click continue 
	And Business to Consumer Name should be showing the error messages: Enter valid information (The following characters are not allowed: = ; ^ * ¿? !¡ \ ~ [] <> | {} + )
	Then I set the Business to Consumer Name field to: Test
	And Business to Consumer Name should not be showing the error messages: Enter valid information (The following characters are not allowed: = ; ^ * ¿? !¡ \ ~ [] <> | {} + )
	And I click continue
	And I call Shared Step 58610 (Confirm Restrict Use - Restrict)
	And I should see the Sustainability Page
	Given in the Sustainability page I click Continue
	Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: User added Comments Text 58605. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
	And I call Shared Step 73956 (Go to Summary and verify data) with product type: Mixture, Blend, Formula, Polymer or Solution from Third (3rd, 3d) Party

	And I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase58430
