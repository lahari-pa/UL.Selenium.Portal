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

@morefilters
Scenario: [56829] More Filters
	# Consider creating the test product from scratch every time? nb kit 13 58753
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
		Given I search for product by name: Kit Product 56829 and save the first ID as: Kit_56829
	And I create a Kit product and save details as: Kit_56929
	And I navigate to the landing page
	And I Login into WERCSmart Portal - Admin Role - WERCs Product Account
		And I should see an option for More Filters
	Given I click More Filters in the products grid
	Given I confirm the product exists with Product ID: <Kit_56829> and Name: Kit Product 56829
	Given I enter combinations of More Filters and should see the product ID: <Kit_56829> only for the correct combinations
		| Filter              | Match               |
		| UPC                 | <UPC_56829>         |
		| Brand               | Test Brand          |
		| Retailer            | Walmart/ SAM's Club |
		| Additional Programs | Kit Registrations   |
	Given I enter combinations of Status and More Filters and should see the product ID: <Kit_56829> only for the correct combinations
		| Filter              | Match                  |
		| Status              | Assessment in Progress |
		| Brand               | Test Brand             |
		| Retailer            | Walmart/ SAM's Club    |
		| Additional Programs | Kit Registrations      |
	Given I click More Filters in the products grid
	Then the 'More Filters' options are not displayed
	Given I click More Filters in the products grid
	Then the 'More Filters' options are displayed
	Given I click More Filters in the products grid
	Then the 'More Filters' options are not displayed

# Assigned to Amanda Coutant
# Created by Amanda Coutant
@ScenarioId:451
Scenario: [68413] More Filters - Retailer
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I click More Filters in the products grid
	And I confirm the filter with label: "Retailer" is displayed and default option: "All Retailers"
	And I confirm retailers list based on environment
	#And I should see the following options for the Retailer filter
	#| Option                 |
	#| Ahold                  |
	#| Albertsons Companies   |
	#| Amazon                 |
	#| Autozone               |
	#| Bed Bath and Beyond    |
	#| Canadian Tire          |
	#| Costco                 |
	#| CVS                    |
	#| Delhaize               |
	#| Dick's Sporting Goods  |
	#| Dollar General         |
	#| Dollar Tree            |
	#| Essendant              |
	#| Family Dollar          |
	#| Genuine Parts          |
	#| Harbor Freight Tools   |
	#| HD Supply              |
	#| HyVee                  |
	#| Kohl's                 |
	#| Kroger                 |
	#| Lowes                  |
	#| McLane                 |
	#| Meijer                 |
	#| Michaels               |
	#| New Egg                |
	#| Northgate Market       |
	#| Office Depot           |
	#| O'Reilly Auto Parts    |
	#| Petco                  |
	#| Price Chopper          |
	#| Publix                 |
	#| Rite Aid               |
	#| Save Mart Supermarkets |
	#| Schnucks               |
	#| Sears K Mart           |
	#| Smart & Final          |
	#| Staples                |
	#| SuperValue             |
	#| Target                 |
	#| The Home Depot         |
	#| Topco                  |
	#| Tractor Value Supply   |
	#| Ultra Standard         |
	#| Unified                |
	#| Wakefren               |
	#| Walgreens              |
	#| BONBONS                |
	#| Walmart.com            |
	#| Hayneedle              |
	#| Jet                    |
	#| MODCLOTH               |
	#| Moosejaw               |
	#| Shoes.com              |
	#| Walmart                |
	#| Winco Foods            |
	And I select the Wal-Mart/SAM'S CLUB option in the Retailer More Filters drop down
	And I confirm all products in the grid contain either the the text "WM" or "All" under the 'Retailers' column
