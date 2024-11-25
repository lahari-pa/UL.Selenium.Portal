@RPS
@Login
@run_HomeTab
@LandingPage
@Home
@Shared
@Navigation
@Dashboard
@RecentActivities
@TopBar
@run_DrumgLogLayout
@DrumLog
@HelpAndSupport
@MoreFilters

Feature: Target

Scenario Outline: [163200] Target - Menu Links Banner - options
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: RPS.TG
	Given I confirm the following tabs are displayed:
		| Link              |
		| Program Health    |
		| Dashboard         |
		| Recent Activities |
		| Web Viewers       |
		| ItemSync          |
		| Product Lookup    |
		| Download Center   |
		| Help & Support    |
	Given I call Shared Step 106194 (RPS Sign out)


Scenario Outline: [165090] RPS - Target Logistics Web Viewer - View Data  - Additional Data - confirm fields shown (Target_HQ)
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: RPS.TG
	Given I call Shared Step 153163 (RPS - Go to Logistics/Store Web Viewer): Target_HQ
	Then In the product table, in the Actions column, I click: View Data
	Then I confirm the Product Information Pop up has loaded
	And I verify that Product Information pop up is displayed
	Then I call Shared Step 165091 (Logistics Viewer - View Data - Additional Data - Confirm rows (Target Specific - Target HQ Viewer))
	Then I Close the Product Information Popup
	Given I call Shared Step 106194 (RPS Sign out)

Scenario Outline: [163791] RPS - Target Status/Store Web Viewer - View Data  - Additional Data - confirm fields shown
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: RPS.TG
	Given I call Shared Step 153163 (RPS - Go to Logistics/Store Web Viewer): Target_store
	Then In the product table, in the Actions column, I click: View Data
	Then I confirm the Product Information Pop up has loaded
	And I verify that Product Information pop up is displayed
	Then I call Shared Step 163203 (Status/Store Viewer - View Data - Additional Data - Confirm rows (Target specific))
	Then I Close the Product Information Popup
	Given I call Shared Step 106194 (RPS Sign out)

Scenario Outline: [162797] Target Status Viewer - View Data  - Additional Data codes - confirm fields shown
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: RPS.TG
	Given I call Shared Step 153163 (RPS - Go to Logistics/Store Web Viewer): Target_status
	Then In the product table, in the Actions column, I click: View Data
	Then I confirm the Product Information Pop up has loaded
	And I verify that Product Information pop up is displayed
	Then I call Shared Step 162795 (View Data - Product Information Pop up - Additional Data Codes - Confirm row (Target Specific))
	Then I Close the Product Information Popup
	Given I call Shared Step 106194 (RPS Sign out)



