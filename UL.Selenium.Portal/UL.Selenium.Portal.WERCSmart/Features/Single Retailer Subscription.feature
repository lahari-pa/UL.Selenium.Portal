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


Feature: Single Retailer Subscription

@TestCase:200502

Scenario: [200502] Single Retailer - Supplier Manager - Search and Result Table Revisions

Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
Then I click on the Suppliers link on the top right of the screen
Then The Supplier Manager popup appears
And In the Supplier Manager Popup I select radio button: Company
And In the Supplier Manager Popup I enter the following search term: Company Name
And In the Supplier Manager Popup I click on the search button


