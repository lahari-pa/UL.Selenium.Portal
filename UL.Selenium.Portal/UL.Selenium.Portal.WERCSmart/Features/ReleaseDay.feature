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
@run_ReleaseDay

Feature: Release Day

@ForwardProductRegistration
@TReVorId:22087
Scenario: [75321] Forward Product - Completed Status (NO Recert)
Given I create a product and take to completed using Test Case 75335 and save as: TestCase75321
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
#And I Select a "NEW" Retailer which you know is not already associated to the product (should not be present on the note you made earlier)
And In the Forward Product Registration Screen I select a retailer under Other Retailers and save as TestCase75321Retailer
And I Click 'CONTINUE'
And [Shared Step 75140 - Forwarding - Select Products & UPCs step - Add Any missing data and select 1 UPC - Continue]
And I The 'Product Results Tab' is selected
And I Confirm that the UPC Number displays the recently selected "Retailer"(Step 17)
And I Confirm that NO Errors display for the Product
And I Click 'CONTINUE'
And I The 'Review and Submit' step is shown
And I Select the "All of the above statements are true" Radio Button
And I Click 'CONTINUE'
And I Confirm the Purchase Summary page is shown with the success message shown" Thank you for registering your product on WERCSmart for assessment. The retailers may receive your assessment in approximately two (2) business days, if no delays in processing the assessment, and should no data issues arise.  "
And I Click on the 'HOME BUTTON'
And I In SHA Manager
And I In the shared step below search for your product using the WPS ID you noted earlier
And I call Shared Step 49841 (SHA - Search for exact WPS ID in (.*) Status for saved as: (.*))
And I Confirm the Product shows a "Completed Status" for the Original Retailer(see Clients column)
And I Confirm the Productshows a "Submitted Status" for the recently selected Retailer (see clients column)
And [Shared Step 75309 - SHA > Select Product > UPC List]
And I With the SHA Manager Product UPC window open - Click on the 'maximize' icon to expand the view of the window
And I Confirm the recently added Retailer(s)is (are) shown against the UPC you selected
And I Close the SHA Manager Product UPC window
And I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: (.*))
And I In the shared step below search for the Product you are working with
And I call Shared Step 49841 (SHA - Search for exact WPS ID in (.*) Status for saved as: (.*))
And I Confirm the Product shows the ORIGINAL RETAILER(s) with a "Completed Status" (see the Clients column)
And I Confirm the Product shows theNEW RETAILER(s) with an "Accepted Status" (see the Clients column)Note: if you selected a retailer that does not have a feed associated to it you will see the product in Completed status for this retailer)
And I In the Shared Step below - Select the Product with the "Accepted Status"
And I call Shared Step 51664 (SHA - Accepted Product - set Retailers to Completed for saved as: (.*))
And I Confirm the Product now shows a "Completed" Status in Completed for ALL associated Retailers

# Assigned to Barrett, Beverly
# Created by Barrett, Beverly

# Test case can be found at the following paths:
# NetProjects10\WercsSmart Portal\Release Day Tests


