@wercsmart
@API
@run_ApiWasteHaulers
@NoBrowserRequired

Feature: [API] Waste Haulers

@TReVorId:22364
Scenario: Waste Hauler API Test
Given I authenticate username: test@test.pab, password: Welcome1!
Then I save the Waste Hauler report for UPC: 0783707473024 as: WasteHaulerSavedAs
