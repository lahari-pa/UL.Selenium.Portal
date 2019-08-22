@wercsmart
@API
@run_ApiWasteHaulers
@NoBrowserRequired
@Homepage
@SupplierReports
Feature: [API] Item Sync

@tfs_design
Scenario: [API] Item Sync
	Given I authenticate username: test@test.pab, password: Welcome1!
	Then I save the Item Sync report as: ItemSyncReport using:
		| UPC           | Retailer GUID                        |
		| 0715146145811 | 736EA04E-9654-49B3-BB55-C66C5CEB55A3 |
#Guid is WM
