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
@run_ProductCharacteristics

Feature: Product Characteristics

Scenario: [31346] Product Characteristics - Solid navigation
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk
And I should see the Product Characteristics Page
And I should see following statement: Primary Physical State
And I should only see the following options for Primary Physical State:
| State |
| Solid |
And I should see following statement: Secondary Physical State
And I should see following statement: When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?
And I should see following statement: Select the best Water Solubility description

Scenario: [31837] Product Characteristics - Solid validation
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk
And I should see the Product Characteristics Page
When I click continue
And Secondary Physical State should be showing the error messages: This is a required field.
And When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5? should be showing the error messages: This is a required field.
And Select the best Water Solubility description should be showing the error messages: This is a required field.


Scenario: [0000] Product Characteristics - Liquid navigation
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Conditioner
And I should see the Product Characteristics Page
And I should see following statement: Primary Physical State
And I should only see the following options for Primary Physical State:
| State  |
| Liquid |
And I should see following statement: Secondary Physical State
And I should see following statement: Specific Gravity
And I should see following statement: pH
And I should see following statement: Boiling Point (in Celsius)
And I should see following statement: Flash Point (in Celsius)
And I should see following statement: Flash Point Testing Method Used
