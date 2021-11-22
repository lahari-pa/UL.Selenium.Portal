@RPS
@Login
@run_ItemSync_Invalid_File_Popup
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


Feature: ItemSync - Invalid File Popup

@ScenarioId:10385
Scenario: [125672] Base functionality - ItemSync - Invalid File Pop-up (from Browse)

Then I call Shared Step 134359 (RPS Login - User has Standard ItemSync Access)
Then I confirm the Home tab has loaded
Given I click the tab: ItemSync
Then I click the sub tab: Upload a File
Then I wait for the ItemSync Upload a File screen to load
And I confirm the ItemSync Upload a File screen is shown
Then In the ItemSync Upload a File screen, I click the File Upload area and open the File: No valid UPCs.csv
And In the ItemSync Upload a File screen, I click the 'Upload' button
Then In the ItemSync Upload a File screen, I wait for the Upload Loading indicator to finish
Then I call Shared Step 125671 (ItemSync - Invalid File pop-up)
#Then In the ItemSync Upload a File screen, I see the Upload Loading indicator
Given I call Shared Step 106194 (RPS Sign out)
