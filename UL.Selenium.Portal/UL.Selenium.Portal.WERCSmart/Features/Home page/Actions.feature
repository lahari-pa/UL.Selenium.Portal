@wercsmart
@run_Actions
@Login
@UlSolutionCenter
@Homepage
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
Feature: Actions

# Assigned to Amanda Coutant
# Created by Amanda Coutant
# Test case can be found at the following paths:
# NetProjects10\WercsSmart Portal\WERCSmart\Home Page\Actions\View UPCs
@TReVorId:22123
Scenario: [73424] View UPCs - Product with UPCs
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Then the WERCSmart homepage should load
	When I filter the products by: Sending to Retailers
	#And I save the ProductID and Name of the first Product in the grid with a retailer as: TestCase73424
	And I save the ProductID and Name of the first Product in the grid with a retailer as Product Information, saved as: TestCase73424
	And I click Row Actions for the first product returned
	And I click on the Row Action: View UPCs
	And I switch to the tab with title: View UPCs
	And I save the UPCs associated to the product as: TestCase73424UPCs
	And I call Shared Step 65080 (Login to Studio and Open SHA manager)
	And I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase73424)
	And I call Shared Step 75309 (SHA > Select Product > UPC List) for product saved as: TestCase73424
	And I confirm all UPC numbers in the list saved as: TestCase73424UPCs are displayed in the SHA Manager Product UPC list
	And I close the window that opened

@TReVorId:11377
Scenario: [63663] Obsoleting/Deleting a Product (not submitted status)
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given If I see the retail partners page I set all data consent tiers to true for all retailers in the top section
	Then The home screen should load
	Then I click the Register New Product icon in the Navigation Pane
	And I Select the Create a New Registration radio button
	And in the New Product page I click Continue
	And I set 'Product Name' to: Soap63663
	#And In the Product Type tab of the New Product Page, I enter: Soap (Bar, Liquid) for Body in the Type of Product select field
	And I set 'Type of Product' to: Soap (Bar, Liquid) for Body
	And in the New Product page I click Continue
	Then I save the product information as: TestCase63663
	And I set the Primary Physical State to be: Solid
	And I set the Secondary Physical State to be: Solid
	And I set the When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5? option to: No
	And I set the Select the best Water Solubility description to be: Very soluble
	And in the New Product page I click Continue
	Given I navigate to the home page
	Then I delete the product: TestCase63663
