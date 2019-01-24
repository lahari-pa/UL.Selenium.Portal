@LandingPage
@Login
@Homepage
@NewProduct
@RetailPartners
@wercsmart
@ProductGrid
@run_DevelopmentBasicTests

Feature: Basic Tests

Scenario: Login - check navigation menu - check products grid

Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)

Then the WERCSmart homepage should load

Given I expand the Navigation Menu

Then the Navigation Menu should be expanded

Given I collapse the Navigation Menu

Then the Navigation Menu should be collapsed

And there should be products available in the Products Grid

Given I search for the first product in the table

Then I should see the product returned in the search results
