@ProductGrid
@ForwardProductRegistration
@NewProduct
@wercsmart
@RetailPartners
@MessageCenter
@MyAccount
@LandingPage
@DocumentAcceptance
@DeleteActiveProducts
@Solutions
@ReviewDocuments
@SHA
@SummaryPage
@PaymentMethods
@ProductSetUp
@ViewUpcs
@Shared
@CreateProducts
@run_Forwarding
Feature: Forwarding

Background:
	Given I verify the following users exist and if not I create them using SHAUser
		| username    | FirstName | LastName   | Role         | EmailAddress                |
		| SHAQAAuto11 | QA        | Automation | QA Reviewers | qasha.kxxyxunf@mailosaur.io |

@ignore
@TestCase:115393
Scenario: [115393] Forward Product - Target - Does not require DPCI
	Then I create a Chalk product for Amazon and Force it into to Completed Using Sha Account: SHAQAAuto11
	Given I navigate to the landing page
	Given I log in with the account saved in TReVor as: ProductAccount
	And I filter for the product saved as: TestCase87685
	And I Confirm the Products shown display the Blue Colour Status - which is the Sending to Retailers
	Given I click Bulk Actions in the Products Grid
	Then I should see a popup with header Bulk Actions
	Given I click Forward Product Registration in the Bulk Actions window
	And I should see the subheading 3: Select Products & UPCs on the Forward Product Registration window
	And I confirm the active Forward Product Registration tab is: Select Products
	Given I select the product with ID saved as: TestCase87685 under the Select Products tab
	Given I click continue on the Forward Product Registration page
	Then I confirm the active Forward Product Registration tab is: Select Retailers
	And in the Select Retailers tab under Forward Product Registration I select the retailer: Target
	Given I click continue on the Forward Product Registration page
	Then I confirm the active Forward Product Registration tab is: Select UPCs
	Given I select the first product under the Select UPCs tab
	Then I select the first UPC in the grid under the Select UPCs tab
	Given I click continue on the Forward Product Registration page
	And I should see the subheading 3: Product Results on the Forward Product Registration window
	And I confirm that there are NO Errors displayed for the Product
	And I click continue on the Forward Product Registration page
	Then I should see the subheading 3: Review & Submit on the Forward Product Registration window
