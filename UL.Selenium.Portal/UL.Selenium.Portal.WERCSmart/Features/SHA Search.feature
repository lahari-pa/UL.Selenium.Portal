@Shared
@SHA
@LandingPage
@Login
@Homepage
@Signup
@RetailPartners
@wercsmart
@DocumentAcceptance
@run_SHASearch
Feature: SHA Search
	Limited to functions which only search SHA Manager

@SHASearch
# QA Test needs UPC 5000171007186, Sprint 2 needs UPC 0046442718103. To access, use TestVariables.GetVariableSavedAs("Archived UPC")
@ScenarioId:1574
Scenario: [110399] SHA Manager - Search UPC for Archived Registration - Verify Popup
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Then SHA Search for Archived UPC. This uses environment variable for know archived product
	Given I verify the popup message displays with the title "Archived Product / Archived UPC"
	Then I close the Archived Product popup
	Then SHA Search for Archived UPC. This uses environment variable for know archived product
