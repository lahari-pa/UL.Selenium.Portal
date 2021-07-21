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

@ScenarioId:6325
Scenario: [86003] Forward Product - US Only - PL = No, Packaging type not required/shown
	#Given I create a product and take to completed using Test Case 75335 and save as: ProductSetup86003
	Given I create a product and take to completed using Test Case 75335 Using SHA Account: SHAQAAuto11 and save as: ProductSetup86003
	Given I navigate to the landing page
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I filter the products by: Accepted by Retailers
	Given I search for the product saved as: ProductSetup86003
	And I Confirm the Products shown display the Green Colour Status - which is the Accepted by Retailers
	And I call Shared Step 75130 - Bulk Actions - Select Forward Product Registration
	And I enter the text: saved as ProductSetup86003 in the 'Search by WPS ID or Product Name' field
	And In the Foward Product Registration Screen I should see product: saved as ProductSetup86003
	And In the Foward Product Registration Screen I Select the product: saved as ProductSetup86003
	And I click continue on the Forward Product Registration page
	And In the Forward Product Registration Screen I select the first retailer that does not require additional data and is not: CVS under Other Retailers and save it as: retailer86003
	And I click continue on the Forward Product Registration page
	And I call Shared Step 86004 (Forwarding - Not PLP - Select Product: ProductSetup86003 & UPCs step - Edit existing UPC Confirm Package Type not shown)
	And I click continue on the Forward Product Registration page
	And I select the true radio for the 'Are Statements True' question under the Review and Submit tab
	And I click continue on the Forward Product Registration page
	And In the Purchase Summary screen I confirm the Purchase Summary header is displayed

@ScenarioId:6946
Scenario: [115393] Forward Product - Target - Does not require DPCI
	#Then I create a Chalk product for Amazon and Proccess it through to Accepted
	Then I create a Chalk product for Amazon and Proccess it through to Accepted Using Sha Account: SHAQAAuto11
	Given I navigate to the landing page
	Given I log in with the account saved in TReVor as: ProductAccount
	#Then I save the following text: 1621940 as TestCase87685
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
