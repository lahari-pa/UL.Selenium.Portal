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
@run_AccountHasStewardshipInfo

Feature: Account has Stewardship information

# Assigned to Barrett, Beverly
# Created by Barrett, Beverly

# Test case can be found at the following paths:
# NetProjects10\WercsSmart Portal\WERCSmart\Canadian Tire - Blue Box Program\Forwarding\Account has Stewardship information\Select Existing UPC - no edit

#Coralie 7 Dec 2018 blocked because cannot currently develop 86187
Scenario: [87217] US & Canada - PL = Yes, Retailer is NOT Canadian Tire, no error re package type on forward
Given I For this test case you will need a product which has SOLD = US and Canada, PL = Yes and is in completed status for Canadian Tire, use Test case 86187 to create a product in this status.
And [Shared Step 85328 - Login to WERCSmart - Canada - Address (Yes), Packaging (Yes), Stewardship (Full)]
And I Click the Accepted by Retailers Filter heading
And I Enter the product ID for the product you are working with and press enter
And I Confirm the Retailers icon is shown in the green Accepted by Retailers color
And [Shared Step 75130 - Bulk Actions - Select Forward Product Registration]
And I In the Search by WPS ID or Product name start typing the WPS ID or product name of the product you are working with
And I Confirm the product is shown for selection
And I Select the product by clicking on it
And I Click Continue
And I Select a retailer other than Canadian Tire, make sure to select a retailer that does not require additional data (such as BB, DI, KG)
And I Click Continue
And I Add Information in the Private Label field for the retailer you selected
And [Shared Step 86824 - Forwarding - Select Existing UPC, Click Continue, No error for Package type]
And I The Product Results step is shown
And I Confirm no errors are shown for your product
And I Click Continue
And I The Review and Submit step is shown
And I Select the "All of the above statements are true" radio button
And I Click Continue
And I Confirm the Purchase Summary page is shown with the success message shown" Thank you for registering your product on WERCSmart for assessment. The retailers may receive your assessment in approximately two (2) business days, if no delays in processing the assessment, and should no data issues arise.  "
And I Click Home
