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
Scenario: [110399] SHA Manager - Search UPC for Archived Registration - Verify Popup
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Then SHA Search for product by UPC: 0046442718103 in all statuses
	Given I verify the popup message displays with the title "Archived Product / Archived UPC"
	Then I verify the popup data using UPC: 0046442718103
