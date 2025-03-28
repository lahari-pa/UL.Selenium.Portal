@Shared
@LandingPage
@Login
@Homepage
@NewProduct
@RetailPartners
@wercsmart
@ProductGrid
@run_DevelopmentBasicTests
@MyProductsPage

Feature: Basic Tests

@ScenarioId:1159
Scenario: Login - check navigation menu - check products grid

Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)

Then the WERCSmart homepage should load

Given I expand the Navigation Menu

Then the Navigation Menu should be expanded

Given I collapse the Navigation Menu

Then the Navigation Menu should be collapsed

And On the My Products page, confirm the My Products table does exist

And On the My Products page, uncheck the Show Archived Retailers checkbox

And On the My Products page, confirm the Show Archived Retailers checkbox is not checked

Given On the My Products page, in Product ID/ Name text search input, enter text: Bleach

Then On the My Products page, click Product ID/Name text search button

Then On the My Products page in the My Products table, confirm row with 'Bleach' as Product Name does exist
