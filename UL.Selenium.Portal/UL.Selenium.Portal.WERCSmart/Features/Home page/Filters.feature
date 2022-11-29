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

@TestCase:68388
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


@tfs_design
@ignore
@TestCase:56829
Scenario: [56829] More Filters	

	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Then I Search the Products Grid for the kit product with name: KitProductMoreFilters56829, and create the kit if it is not found
	Then I create a object of FilterInformation from the table below: and save it as: MoreFiltersInformation56829
	| FilterType          | Variable                    |
	| Brand               | TestBrand                   |
	| Retailer            | CVS                         |
	| Additional Programs | Kit Registrations           |
	| UPC                 | UPC Saved As UPC58753       |
	| ID                  | ID Saved As KitProduct56829 |
	| Status              | Assessment in Progress      |
	| Name                | KitProductMoreFilters56829  |
	Then I enter 3 differnt but valid random filter combinations in the Products Grid and expect to see the product saved as: MoreFiltersInformation56829 each time
	#+Remaining steps from Dev Ops Test Case

# Assigned to Amanda Coutant
# Created by Amanda Coutant
@TestCase:68413
Scenario: [68413] More Filters - Retailer
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I click More Filters in the products grid
	And I confirm the filter with label: "Retailer" is displayed and default option: "All Retailers"
	And I confirm retailers list based on environment
	And I select the Wal-Mart/SAM'S CLUB option in the Retailer More Filters drop down
	And I Select the check box next to Show Archived Retailers
	And I confirm all products in the grid contain either the the text "WM" or "All" under the 'Retailers' column




