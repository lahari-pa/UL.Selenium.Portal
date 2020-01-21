@ProductGrid
@ForwardProductRegistration
@NewProduct
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
@run_Forwarding
Feature: Forwarding

@ScenarioId:6325
Scenario: [86003] Forward Product - US Only - PL = No, Packaging type not required/shown
	Given I create a product and take to completed using Test Case 75335 and save as: ProductSetup86003
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
