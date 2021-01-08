@Shared
@wercsmart
@run_Filters
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
@CreateProducts

Feature: Filters

@ScenarioId:449
Scenario: [68388] More Filters - Brand
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I create a new product of type: Bleach, with a Product Line/ Brand added and select Type of Product: Bleach
	And I should see an option for More Filters
	Given I click More Filters in the products grid
	Given I select the More Filters - Brand saved as: Brand68388 by ID
	Given I click Row Actions for the first product returned
	And I click on the Row Action: Edit
	Given In the New Product page I click tab: Product Type
	And I click the page heading: The Product
	# step accepts '~saved as...' and will fetch the value from context
	Then Product Line or Brand (optional) should be showing the value: ~saved as BrandName68388
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase68388


@ScenarioId:5956
Scenario: [56829] More Filters	
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I create a Hair Color Kit using test case 58753 with product name: KitProductMoreFilters56829 and save as: KitProduct56829
	#Create every time or look for id in table first? Need to ensure is passing kit product if do this -> How?


# Assigned to Amanda Coutant
# Created by Amanda Coutant
@ScenarioId:451
Scenario: [68413] More Filters - Retailer
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I click More Filters in the products grid
	And I confirm the filter with label: "Retailer" is displayed and default option: "All Retailers"
	And I confirm retailers list based on environment
	And I select the Wal-Mart/SAM'S CLUB option in the Retailer More Filters drop down
	And I Select the check box next to Show Archived Retailers
	And I confirm all products in the grid contain either the the text "WM" or "All" under the 'Retailers' column



@ScenarioId:10614
Scenario: [111111111] Test Kit Filter Creation
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I create a Hair Color Kit using test case 58753 with product name: KitProductMoreFilters56829 and save as: KitProduct56829



