@Shared
@wercsmart
@API
@Homepage
@SupplierReports
@RetailPartners
@CreateProducts
@ProductGrid
@run_ItemSync
Feature:ItemSync

# uses 736EA04E-9654-49B3-BB55-C66C5CEB55A3(WM) as the requesting retailer
Scenario: [API]ItemSync
	Given I generate a random UPC number and save as: UPC108810
	Given I generate a random UPC number and save as: UPC2
	Given I authenticate ItemSync username: QATest, password: c06Q3@!gRzNzqk
	Given I save the Item Sync report as: test using Retailer GUID: 736EA04E-9654-49B3-BB55-C66C5CEB55A3 and
		| UPC saved as | Expected Status |
		| UPC108810    | 0               |
		| UPC2         | 0               |

@tfs_design
# uses 16793FA3-452C-45B6-AF48-969AFDF58216(TG) as the requesting retailer
Scenario: [108810]ItemSync
	Given I generate a random UPC number and save as: UPC108810
	Given I authenticate ItemSync username: QATest, password: c06Q3@!gRzNzqk
	Given I save the Item Sync report as: report108810 using Retailer GUID: 16793FA3-452C-45B6-AF48-969AFDF58216 and
		| UPC saved as | Expected Status |
		| UPC108810    | 0               |
		| UPC2         | 0               |
	#	Then I start the ItemSync post process
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I create an electronic product for ItemSync and save it as: 108810Product, with UPC: UPC108810
	Then I save the Item Sync report as: report108810 using Retailer GUID: 16793FA3-452C-45B6-AF48-969AFDF58216 and
		| UPC saved as | Expected Status |
		| UPC108810    | 9               |
		| UPC2         | 9               |
	#	Then I start the ItemSync post process
	Given I move the product saved as 108810Product created for ItemSync from Submitted to Completed
	Given I authenticate ItemSync username: QATest, password: c06Q3@!gRzNzqk
	Given I save the Item Sync report as: report108810 using Retailer GUID: 16793FA3-452C-45B6-AF48-969AFDF58216 and
		| UPC saved as | Expected Status |
		| UPC108810    | 1               |
