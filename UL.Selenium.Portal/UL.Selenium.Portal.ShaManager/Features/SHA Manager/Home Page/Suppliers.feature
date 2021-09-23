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
@ignore
#Need to confirm with Amanda which retailers should be expected - Philip
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
| Expected Value																 |
| Bed Bath and Beyond (including Harmon, Buy Buy Baby, and Christmas Tree Shops) |
| CVS                                                                            |
| Dollar General                                                                 |
| Dollar Tree Stores, Inc. / Greenbrier International, Inc	                     |
| Family Dollar	                                                                 |
| Rite Aid	                                                                     |
| Target	                                                                     |
| Walgreens	                                                                     |
| Wal-Mart/SAM'S CLUB		                                                     |
Then In The Supplier Manager popup I check that the column: Retailer is in alphabetical order
Then In the supplier manager popup I check that Data Tier Consent Table contains the following columns headings:
| Expected Headers |
|                  |
| Tier 1           |
| Tier 2.1         |
| Tier 2.2         |
| Tier 3           |
| Tier 4.1         |
| Name             |
| Email            |
| Date             |
Then In The Supplier Manager popup I check that the column: Name contains all values found in the table:
| Expected Value       |
|                      |
| Automated, Products  |
|                      |
| Automated, Products  |
| Automated, Products  |
| Automated, Products  |
| Automated, Products  |
| Automated, Products  |
| Automated, Products  |
Then In the Supplier Manager popup I check that in The Data Tier Consent Table the email column contains only valid email addresses
Then In the Supplier Manager popup I check that in The Data Tier Consent Table the date column contains dates that are in the format mm-dd-yyyy
Then In the Supplier Manager Popup I click on the close button



Scenario: [141144] SHA Manager - Clear Shopping Cart Action - Email

Given I create an email User_57099522fb7d and save it as AdminEmailAddress
Given I save the current emails in the inbox for address saved as: AdminEmailAddress
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I generate a random UPC number and save as: UPC141144
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk
Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Water
Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Given I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue) for
| Retailer  |
| Walgreens |
Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC141144, container type: Plastic Container and size: 2
Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
Given in the Additional Documents to Provide page I click Continue
Given in the Optional Reports and Documents Available for Purchase page I click Continue
And I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
		| Gloves                        | 120                      | 4                       | 10.0      | Black      | Odorless | No data available | 1                     |
Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: test
Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
Given I click the Home navigation icon
Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
Given I Click 'Suppliers' in SHA Manager
Then In the Supplier Manager Popup I select radio button: E-Mail
Given In the Supplier Manager Popup I enter the following accounts email: ProductAccount
Given In the Supplier Manager Popup I click on the search button
Given In the Supplier Manager Popup I click on the first supplier returned
Given In The Supplier Manager popup I click on the category: Subscription
Given In The Supplier Manager popup I click on the 'Clear Cart for All Users' button
Given In the Clear Cart for All Users Popup I confirm the correct text is displayed
Given In the Clear Cart for All Users Popup I click the Continue button
Given In the Clear Shopping Cart Popup I enter the following UserID: QASHA, Password: Thewercs3!, TFS Ticket Number: a, Support Ticket Number: a then I click Continue
Given In the Results Clear Shopping Cart for All Users Popup I confirm the correct text is displayed
Given I navigate to the landing page
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Given there should be a new email for email Address saved as: AdminEmailAddress from: ULSCN.Notifications@ULNotification.com with the title: WERCSmart Shopping Cart Cleared by UL
Given the body of the email should show: Your shopping cart has been cleared of registrations by a UL representative as requested by your organization. Registrations may be restored to your cart and submitted. No registration data has been affected by removal from the shopping cart. If you have any questions regarding this action, please contact us at WERCSmartCustomer@UL.com. Thank you. The WERCSmart Team @ UL Important Notice: This e-mail may contain privileged or confidential information. If you are not the intended recipient (1) you may not disclose, use, distribute, copy or rely upon this message or attachment(s); and (2) please notify UL PSi at WERCSmartCustomer@ul.com and then delete this message and its attachment(s). UL PSi and its affiliates disclaim all liability for any errors, omissions, corruption or virus in this message or any attachment(s).

