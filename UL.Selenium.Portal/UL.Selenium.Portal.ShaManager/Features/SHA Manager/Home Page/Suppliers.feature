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
Then In The Supplier Manager popup I check that the column: Retailer contains all values found in the table:
| Expected Value                                           |
| Costco                                                   |
| Canadian Tire                                            |
| CVS                                                      |
| Target                                                   |
| Walgreens                                                |
| Family Dollar                                            |
| Wal-Mart/SAM'S CLUB                                      |
| Dollar Tree Stores, Inc. / Greenbrier International, Inc |
Then In the supplier manager popup I check that Data Tier Consent Table contains the following columns headings:
| Expected Headers |
|                  |
| Tier 1           |
| Tier 2.1         |
| Tier 2.2         |
| Tier 3           |
| Tier 4.1         |
| Tier 4.2         |
| Name             |
| Email            |
| Date             |








