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

@TReVorId:22364
Scenario: Waste Hauler API Test
	Given I authenticate WasteHauler username: rich.french@ul.com, password: Asdf123!
	Then I save the Waste Hauler report for UPC: 00193000093223 as: WasteHaulerSavedAs
