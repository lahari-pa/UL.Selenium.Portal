@RPS
@Login
@run_ItemSync_UPC_Limit_Exceeded
@LandingPage
@Home
@Shared
@TopBar
@Navigation
@ProductInformation
@ProductLookUP
@Dashboard
@RecentActivities
@RPSSHA
@ItemSync
@ignore


Feature: ItemSync - UPC Limit Exceeded

# Removed from regression: 2024/08
@ignore
@ScenarioId:10387
Scenario: [125685] Base functionality - ItemSync - UPC Limit Exceeded (from Browse)
	Then I call Shared Step 134359 (RPS Login - User has Standard ItemSync Access)
	Then I confirm the Home tab has loaded
	Given I click the main tab: ItemSync
	Then I click the sub tab: Upload a File
	Then I wait for the ItemSync Upload a File screen to load
	And I confirm the ItemSync Upload a File screen is shown
	Then In the ItemSync Upload a File screen, I click the File Upload area and open the File: 1100 UPCs from notepad.csv
	And In the ItemSync Upload a File screen, I click the 'Upload' button
	Then In the ItemSync Upload a File screen, I wait for the Upload Loading indicator to finish
	Then I call Shared Step 125689 (ItemSync - UPC Limit Exceeded pop-up)
	Given I call Shared Step 106194 (RPS Sign out)
