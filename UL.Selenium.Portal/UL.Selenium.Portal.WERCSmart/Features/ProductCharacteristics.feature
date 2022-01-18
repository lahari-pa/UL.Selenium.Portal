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
@run_ProductCharacteristics

Feature: Physical and Chemical Properties

@ScenarioId:1155
Scenario: [31834] Physical and Chemical Properties - Solid only navigation
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk
Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
Then I save the product information as: TestCase31834
And I should see the Physical and Chemical Properties Page
And I should see following statement: Primary Physical State
And I should only see the following options for Primary Physical State:
| State |
| Solid |
And I should see following statement: Secondary Physical State
And I should see following statement: When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?
And I should see following statement: Select the best Water Solubility description
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase31834

@ScenarioId:1156
Scenario: [31837] Physical and Chemical Properties - Solid only validation
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk
Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
Then I save the product information as: TestCase31837
And I should see the Physical and Chemical Properties Page
When I click continue
And Secondary Physical State should be showing the error messages: This is a required field.
And When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5? should be showing the error messages: This is a required field.
And Select the best Water Solubility description should be showing the error messages: This is a required field.
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase31837


@ScenarioId:1153
Scenario: [31827] Physical and Chemical Properties - Liquid only navigation
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Conditioner
Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
Then I save the product information as: TestCase31827
And I should see the Physical and Chemical Properties Page
And I should see following statement: Primary Physical State
And I should only see the following options for Primary Physical State:
| State  |
| Liquid |
And I should see following statement: Secondary Physical State
And I should see following statement: Relative Density
And I should see following statement: pH
And I should see following statement: Boiling Point (in Celsius)
And I should see following statement: Flash Point (in Celsius)
#And I should see following statement: Flash Point Testing Method Used
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase31827


@ScenarioId:1154
Scenario: [31833] Physical and Chemical Properties - Liquid only validation
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Conditioner
Then I save the product information as: TestCase31833

Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)

And I should see the Physical and Chemical Properties Page
When I click continue
And Secondary Physical State should be showing the error messages: This is a required field.
And Relative Density should be showing the error messages: This is a required field.
And pH should be showing the error messages: This is a required field.
And Boiling Point (in Celsius) should be showing the error messages: This is a required field.
And Flash Point (in Celsius) should be showing the error messages: This is a required field.
#And Flash Point Testing Method Used should be showing the error messages: This is a required field.
And Select the best Water Solubility description should be showing the error messages: This is a required field.
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase31833


@ScenarioId:1149
Scenario: [31786] Physical and Chemical Properties - Aerosol only navigation
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Algicide - Aerosol
Then I save the product information as: TestCase31786
Given I call Shared Step 101692 Product Information - Pesticide Question - Happy Path
Given I call Shared Step 168070 (Physical and Chemical Properties - Aerosol Only - Validation for Algicide Aerosol Type of Product)
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase31786

@ScenarioId:11129
Scenario: [31826] Physical and Chemical Properties - Gas only validation
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Compressed gas
Then I save the product information as: TestCase31826
Given I call Shared Step 57401 (Product Information - US only - No GHS, Not Direct Ship, Not PLP, Not GNFR > Continue - Happy Path)
And I should see the Physical and Chemical Properties Page
Given Primary Physical State should be showing the value: Gas
When I click continue
And Secondary Physical State should be showing the error messages: This is a required field.
And Select the best Water Solubility description should be showing the error messages: This is a required field.
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase31826

@ScenarioId:1151
Scenario: [31804] Physical and Chemical Properties - Gas only navigation
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Compressed gas
Then I save the product information as: TestCase31804
Given I call Shared Step 57401 (Product Information - US only - No GHS, Not Direct Ship, Not PLP, Not GNFR > Continue - Happy Path)
And I should see the Physical and Chemical Properties Page
And I should see following statement: Primary Physical State
And I should only see the following options for Primary Physical State:
| State   |
| Gas     |
And I should see following statement: Secondary Physical State
And I should see following statement: Select the best Water Solubility description
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase31804

@ScenarioId:1157
Scenario: [85157] Physical and Chemical Properties - All navigation
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Bonding agent
Then I save the product information as: TestCase85157
Given I call Shared Step 57401 (Product Information - US only - No GHS, Not Direct Ship, Not PLP, Not GNFR > Continue - Happy Path)
And I should see the Physical and Chemical Properties Page
And I should see following statement: Primary Physical State
And I should only see the following options for Primary Physical State:
| State       |
| Aerosol     |
| Gas         |
| Liquid      |
| Solid       |
And I should see following statement: Secondary Physical State
And I should see following statement: Select the best Water Solubility description
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase85157
