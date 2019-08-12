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
@PaymentMethods
@SubEnrollment
@WERCSmart_Signup
@MyAccount
@PackagingTypes
@Brands
@MyIngredients
@ProductSetUp
@DataSummarySheet
@SHA
@run_ReleaseDay

Feature: Release Day

@SHA
@ForwardProductRegistration
@TReVorId:22087
@75321
@TReVorId:22087
Scenario: [75321] Forward Product - Completed Status (NO Recert)
Given I create a product and take to completed using Test Case 75335 and save as: TestCase75321
#Given I save to context name: TestCase75321 and value: 1557473
Given I navigate to the landing page
And I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
And I filter the products by: Accepted by Retailers
And I Confirm the Products shown display the Green Colour Status - which is the Accepted by Retailers
And I filter for the product saved as: TestCase75321
And I call Shared Step 75130 - Bulk Actions - Select Forward Product Registration
Then I should see the header: Forward Product Registration on the Forward Product Registration window
And I enter the text: saved as TestCase75321 in the 'Search by WPS ID or Product Name' field
And In the Foward Product Registration Screen I should see product: saved as TestCase75321
And In the Foward Product Registration Screen I Select the product: saved as TestCase75321
And I click continue on the Forward Product Registration page
#And I Select a "NEW" Retailer which you know is not already associated to the product saved into context as 'retailer'
And In the Forward Product Registration Screen I select a retailer under Other Retailers and save as TestCase75321Retailer
And I click continue on the Forward Product Registration page
And I call Shared Step 75140 - Forwarding - Select Products & UPCs step - Add Any missing data and select 1 UPC - Continue and save UPC as TestCase75321UPC
Then I should see the header: Product Results on the Forward Product Registration window
Then I confirm that for UPC Number saved as TestCase75321UPC the retailer is displayed as saved as TestCase75321Retailer
And I confirm that NO Errors display for the Product
And I click continue on the Forward Product Registration page
Then I should see the header: Review & Submit on the Forward Product Registration window
Then I select the true radio for the 'Are Statements True' question under the Review and Submit tab
And I click continue on the Forward Product Registration page
And In the Purchase Summary screen I confirm the Purchase Summary header is displayed
Then In the Purchase Summary screen I confirm the folling statement is shown: Thank you for registering your product on WERCSmart for assessment. The retailers may receive your assessment in approximately two (2) business days, if no delays in processing the assessment, and should no data issues arise.

#Scenario: Test75321
#Given I save to context name: TestCase75321 and value: 1555642
And I call Shared Step 65080 (Login to Studio and Open SHA manager)
And I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase75321)
And I Confirm the Product shows status: Completed for retailer: saved as retailer
And I Confirm the Product shows status: Submitted for retailer: saved as TestCase75321Retailer


And I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase75321)
And I call Shared Step 75309 (SHA > Select Product > UPC List) for product saved as: TestCase75321
And In the SHA Manager Product UPC window I confirm that for UPC: saved as UPC75335 retailer: saved as TestCase75321Retailer is showing
And I close the window that opened
And I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase75321)
#And I In the shared step below search for the Product you are working with

#Scenario: 2Test75321
#Given I save to context name: TestCase75321 and value: 1555642
#Given I add to context name: UPC75335 and value: 0625828223600
#Given I add to context name: TestCase75321Retailer and value: Harbor Freight Tools
#Given I add to context name: retailer and value: CVS
#And I call Shared Step 65080 (Login to Studio and Open SHA manager)
And I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase75321)
#And I Confirm the Product shows the ORIGINAL RETAILER(s) with a "Completed Status" (see the Clients column)
And I Confirm the Product shows status: Completed for retailer: saved as retailer
#And I Confirm the Product shows theNEW RETAILER(s) with an "Accepted Status" (see the Clients column)
#Note: if you selected a retailer that does not have a feed associated to it you will see the product in Completed status for this retailer)
And I Confirm the Product shows status: Accepted for retailer: saved as TestCase75321Retailer
#And I In the Shared Step below - Select the Product with the "Accepted Status"
Given I call Shared Step 51664 (SHA - Accepted Product - set Retailers to Completed for saved as: TestCase75321) for
| Retailer                       |
| saved as TestCase75321Retailer |
And I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase75321)
And I Confirm the Product shows status: Completed for retailer: saved as retailer
And I Confirm the Product shows status: Completed for retailer: saved as TestCase75321Retailer


# Assigned to Barrett, Beverly
# Created by Barrett, Beverly

# Test case can be found at the following paths:
# NetProjects10\WercsSmart Portal\Release Day Tests

Scenario: [78414] Submit Product, Reject from Submitted in SHA, Resubmit from Portal.  SHA shows in Submitted status
Given I Use Test case 75142 to create a NEW PRODUCT and get it to Submitted status in SHA
And I call Shared Step 65080 (Login to Studio and Open SHA manager)
And I Search for you product using the shared step below
And I call Shared Step 49841 (SHA - Search for exact WPS ID in (.*) Status for saved as: (.*))
And [Shared Step 83242 - SHA - Submitted or Assigned product - Reject Submission - any subject - Save]
And I call Shared Step 49841 (SHA - Search for exact WPS ID in (.*) Status for saved as: (.*))
And I Confirm theProduct shows the"NEW Status"
And I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
And I Filter for the Product you are working with
And I Click the "... Icon" in the Actions Column for your Product
And I Select the 'Edit' Option
And I Clickon the "Review and Submit Tab Heading"
And I Click the "Comments Step Heading"
And I Click the 'CONTINUE'
And I Click the "Accept Button"
And I The Purchase Summary page is shown with the Thank you message - You should NOT See a cost for the product at this step.
And I Click on the 'HOME BUTTON'
And I Go to SHA Manager
And I call Shared Step 49841 (SHA - Search for exact WPS ID in (.*) Status for saved as: (.*))
And I Confirm the Productshows a "Submitted Status"
