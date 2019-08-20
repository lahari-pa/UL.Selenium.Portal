@wercsmart
@API
@run_ApiWasteHaulers
@NoBrowserRequired
@Homepage
@SupplierReports
Feature: [API] Waste Haulers

@TReVorId:22364
Scenario: Waste Hauler API Test
	Given I authenticate username: test@test.pab, password: Welcome1!
	Then I save the Waste Hauler report for UPC: 0783707473024 as: WasteHaulerSavedAs

#tests 106100:
Scenario: WM Hauler Profile Logic Update
	Given I authenticate username: test@test.pab, password: Welcome1!
	Then I save the Waste Hauler report for UPC: {upc} as: {reportSavedAs}
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I click the Supplier Reports icon in the QuickLinks Pane
	Given Under the Supplier Reports menu I choose: Waste Classification Summary for All Registrations
	Then In the Supplier Reports screen the current sub-page should be: Waste Classification Summary for All Registrations
	And In the Supplier Report page I should see the report description should be showing with text: Report will show the waste classification for each of the 50 states and other areas within the United States, as well as the Federal waste classification. For specific information about a registration's waste classification, and how the waste classification was derived, you may request an Additional Document from the My Products area for the registration you're interested in receiving details about.
	Given In the Supplier Reports screen I click on the Download button
	Given I confirm that a file is downloaded with file name: Waste Classification Summary for All Registrations.xlsx then close the Report Download popup. I save the file as SupplierReport106100
	Given I verify the XML data saved as: {reportSavedAs} matches the corresponding Excel file saved as: SupplierReport106100
