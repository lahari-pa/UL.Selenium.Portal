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

Scenario: [31834] Product Characteristics - Solid only navigation
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk
Then I save the product information as: TestCase31834
And I should see the Product Characteristics Page
And I should see following statement: Primary Physical State
And I should only see the following options for Primary Physical State:
| State |
| Solid |
And I should see following statement: Secondary Physical State
And I should see following statement: When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?
And I should see following statement: Select the best Water Solubility description
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase31834

Scenario: [31837] Product Characteristics - Solid only validation
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk
Then I save the product information as: TestCase31837
And I should see the Product Characteristics Page
When I click continue
And Secondary Physical State should be showing the error messages: This is a required field.
And When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5? should be showing the error messages: This is a required field.
And Select the best Water Solubility description should be showing the error messages: This is a required field.
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase31837


Scenario: [31827] Product Characteristics - Liquid only navigation
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Conditioner
Then I save the product information as: TestCase31827
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
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase31827


Scenario: [31833] Product Characteristics - Liquid only validation
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Conditioner
Then I save the product information as: TestCase31833
And I should see the Product Characteristics Page
When I click continue
And Secondary Physical State should be showing the error messages: This is a required field.
And Specific Gravity should be showing the error messages: This is a required field.
And pH should be showing the error messages: This is a required field.
And Boiling Point (in Celsius) should be showing the error messages: This is a required field.
And Flash Point (in Celsius) should be showing the error messages: This is a required field.
And Flash Point Testing Method Used should be showing the error messages: This is a required field.
And Select the best Water Solubility description should be showing the error messages: This is a required field.
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase31833


Scenario: [31786] Product Characteristics - Aerosol only navigation
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Algicide - Aerosol
Then I save the product information as: TestCase31786
And I should see the Product Characteristics Page
And I should see following statement: Primary Physical State
And I should only see the following options for Primary Physical State:
| State   |
| Aerosol |
And I should see following statement: Secondary Physical State
And I should see following statement: pH
And I should see following statement: When the product has a flammable propellant, or contains ingredients with a flash point below 60⁰C then
And The following radio buttons should be displayed for section: When the product has a flammable propellant, or contains ingredients with a flash point below 60⁰C then
| Button |
| This product is classified as a D001 Hazardous Waste under RCRA (as per Section 13 or 15 of the SDS).      |
| This product is classified as a D003 Hazardous Waste under RCRA.      |
| This product is not classified as D001 or D003 Hazardous Waste under RCRA      |
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase31786


Scenario: [31789] Product Characteristics - Aerosol only validation
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Algicide - Aerosol
Then I save the product information as: TestCase31789
And I should see the Product Characteristics Page
When I click continue
And Secondary Physical State should be showing the error messages: This is a required field.
And pH should be showing the error messages: This is a required field.
And When the product has a flammable propellant, or contains ingredients with a flash point below 60⁰C then should be showing the error messages: This is a required field.
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase31789
