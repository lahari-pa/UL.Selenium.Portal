@Shared
@LandingPage
@Login
@SHA
@Homepage
@Signup
@wercsmart
@NewProduct
@ProductGrid
@DataSummarySheet
@RetailPartners
@SummaryPage
@SupplierReports
@PaymentMethods
@SubEnrollment
@WERCSmart_Signup
@MyAccount
@PackagingTypes
@Brands
@MyIngredients
@SupplierReports
@UPC
@SHA
@FileOps
@ForwardProductRegistration
@ProductSetUp
@MyMessages
@Portal_ShaManager
@run_Suppliers
Feature: Suppliers

@tfs_design
Scenario: [74786] Data Tier Consent Tab Layout

Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
Then I click on the Suppliers link on the top right of the screen
Then The Supplier Manager popup appears
Then In the Supplier Manager Popup I select radio button: Vendor
Given In the Supplier Manager Popup I enter the following search term: Automated Products
Then In the Supplier Manager Popup I click on the search button
Then In the Supplier Manager Popup I click on the first supplier returned
Then In The Supplier Manager popup I click on the category: Data Tier Consent








