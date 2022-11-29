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
@CreateProducts
@ForwardProductRegistration
@PaymentMethods
@ProductSetUp
@run_AccountHasStewardshipInfo

Feature: Account has Stewardship information

Background:
	Given I verify the following users exist and if not I create them using SHAUser
		| username    | FirstName | LastName   | Role         | EmailAddress                |
		| SHAQAAuto5  | QA        | Automation | QA Reviewers | qasha.kxxyxunf@mailosaur.io |

# NetProjects10\WercsSmart Portal\WERCSmart\Canadian Tire - Blue Box Program\Forwarding\Account has Stewardship information\Select Existing UPC - no edit
@TestCase:87217
Scenario: [87217] US & Canada - PL = Yes, Retailer is NOT Canadian Tire, no error re package type on forward
Given I create a product and force it into Completed using Test Case 86187 and SHA account saved as: SHAQAAuto5 (SOLD = US and Canada, PL = Yes, Canadian Tire Retailer Product)
Given I navigate to the landing page
Given I call Shared Step 85328 (Login to WERCSmart - Canada - Address (Yes), Packaging (Yes), Stewardship (Full))
Given I filter the products by: Accepted by Retailers
Given I search for the product saved as: TestCase86187
And I Confirm the Products shown display the Green Colour Status - which is the Accepted by Retailers
And I call Shared Step 75130 - Bulk Actions - Select Forward Product Registration
And I enter the text: saved as TestCase86187 in the 'Search by WPS ID or Product Name' field
And In the Foward Product Registration Screen I should see product: saved as TestCase86187
And In the Foward Product Registration Screen I Select the product: saved as TestCase86187
And I click continue on the Forward Product Registration page
And In the Forward Product Registration Screen I select the first retailer that does not require additional data and is not: Canadian Tire under Other Retailers and save it as: retailer87217
And I click continue on the Forward Product Registration page
And If the Private Label textbox is showing in the Select UPCs screen, I enter the value: N/A
And I call Shared Step 86824 (Forwarding - Select Existing UPC, Click Continue, No error for Package type)
And I should see the subheading 3: Product Results on the Forward Product Registration window
And I click continue on the Forward Product Registration page
And I should see the subheading 3: Review & Submit on the Forward Product Registration window
And I select the true radio for the 'Are Statements True' question under the Review and Submit tab
And I click continue on the Forward Product Registration page
And In the Purchase Summary screen I confirm the Purchase Summary header is displayed
Then In the Thank You screen I confirm the following statement is shown: Thank you for registering your product on WERCSmart for assessment.
And I navigate to the home page
