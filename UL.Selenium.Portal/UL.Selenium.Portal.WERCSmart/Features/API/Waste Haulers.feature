@Shared
@wercsmart
@API
@run_ApiWasteHaulers
@NoBrowserRequired
@Homepage
@SupplierReports
@RetailPartners
@CreateProducts
@ProductGrid
Feature: [API] Waste Haulers

@ScenarioId:1382
Scenario: Waste Hauler API Test
	Given I authenticate WasteHauler username: WasteHaulerAPITest@ydcdps5a.mailosaur.net, password: Welcome1!
	Then I save the Waste Hauler report for UPC: 00193000093223 as: WasteHaulerSavedAs
