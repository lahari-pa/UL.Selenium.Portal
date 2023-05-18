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
And I should see the 'Supplier Manager' popup
Then In the Supplier Manager Popup I check next radio buttons:
| Radio Button   |
| Company        |
| User Name      |
| E-Mail         |
| Phone          |
| Invoice Number |
And I call Shared step In the Supplier Manager Popup - radio button 'Company',enter in search 'Company' and check column headers:
| Column             |
| Name               |
| Subscription       |
| SubscriptionStatus |
| Phone              |
| City               |
| State              |
And I call Shared step In the Supplier Manager Popup - radio button 'User Name',enter in search 'User Name' and check column headers:
| Column             |
| Name               |
| Subscription       |
| SubscriptionStatus |
| Phone              |
| City               |
| State              |
And I call Shared step In the Supplier Manager Popup - radio button 'E-Mail',enter in search 'E-Mail' and check column headers:
| Column             |
| Name               |
| Subscription       |
| SubscriptionStatus |
| Phone              |
| City               |
| State              |
And I call Shared step In the Supplier Manager Popup - radio button 'Phone',enter in search '999-999-9999' and check column headers:
| Column             |
| Name               |
| Subscription       |
| SubscriptionStatus |
| Phone              |
| City               |
| State              |
And I call Shared step In the Supplier Manager Popup - radio button 'Invoice Number',enter in search 'Invoice Number' and check column headers:
| Column             |
| Name               |
| Subscription       |
| SubscriptionStatus |
| Phone              |
| City               |
| State              |



