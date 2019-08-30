@wercsmart
@API
@run_ApiWasteHaulers
@NoBrowserRequired
@Homepage
@SupplierReports
@CreateProducts
@ProductGrid
Feature: [API] Item Sync

Scenario: [108810] Item Sync
	Given I generate a unique UPC number and save as: upc
	Given I authenticate ItemSync username: QATest, password: c06Q3@!gRzNzqk
	Then I save the Item Sync report as: ItemSyncReport using Retailer GUID: 736EA04E-9654-49B3-BB55-C66C5CEB55A3 and
		| UPC        |
		| 1234567890 |

@tfs_design
Scenario: [108810] Item Sync
	Given I generate a unique UPC number and save as: upc
	Then I create an electronic product for ItemSync and save it as: 108810, with UPC: upc
	Given I authenticate ItemSync username: QATest, password: c06Q3@!gRzNzqk
	Then I save the Item Sync report as: ItemSyncReport using Retailer GUID: 736EA04E-9654-49B3-BB55-C66C5CEB55A3 and
		| UPC |
		| upc |
	#Guid is WM
	Then I verify that data was returned as expected from file saved as: ItemSyncReport
