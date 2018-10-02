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
@run_TheProduct

Feature: The Product

Scenario: [31346] The Product navigation
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
And I should see the The Product Page
And I should see following statement: Product Name as it a appears on the Package Label, Container or Safety Data Sheet (SDS)
And I should see following statement: Product Line or Brand (optional)
And I should see following statement: Type of Product (select)

Scenario: [31347] The Product validation
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given in the New Product page I click Continue
#TODO: update below step for product name validation
#And Product Name as it a appears on the Package Label, Container or Safety Data Sheet (SDS) should be showing the error messages: This is a required field.
And Type of Product (select) should be showing the error messages: This is a required field.

