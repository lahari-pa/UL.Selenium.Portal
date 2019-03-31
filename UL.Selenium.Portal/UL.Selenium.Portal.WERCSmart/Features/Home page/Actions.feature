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


Feature: Actions

# Assigned to Amanda Coutant
# Created by Amanda Coutant

# Test case can be found at the following paths:
# NetProjects10\WercsSmart Portal\WERCSmart\Home Page\Actions\View UPCs

Scenario: [73424] View UPCs - Product with UPCs
Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
Then the WERCSmart homepage should load
When I filter the products by: Sending to Retailers
And I save the ProductID and Name of the first Product in the grid with a retailer as: TestCase73424
And I click Row Actions for the first product returned
And I click on the Row Action: View UPCs
And I should see the View UPCs page
And I save the UPCs associated to the product as TestCase73424UPCs
And I call Shared Step 65080 (Login to Studio and Open SHA manager)
And I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase73424)
And I call Shared Step 75309 (SHA > Select Product > UPC List) for product saved as: ProductSetup64530
And I confirm the list of UPCs saved as: TestCase73424UPCs is displayed in the SHA Manager Product UPC list
And I close the window that opened
