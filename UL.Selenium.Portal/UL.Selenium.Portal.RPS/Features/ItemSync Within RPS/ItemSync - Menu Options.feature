@RPS
@Login
@run_ItemSync_Menu_Options
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


Feature: ItemSync - Menu Options

@ScenarioId:10331
Scenario: [125562] Base functionality - Retailer does not have access to ItemSync
Given I call Shared Step 134361 (RPS Login - User does not have access to ItemSync)
Then I confirm the Home tab has loaded
Given  I confirm the following tabs are displayed:
| Link              |
| Home              |
| Dashboard         |
| Recent Activities |
| Web Viewers       |
| Product Lookup    |
| Help & Support    |
| Auditor           |
Then I confirm the following tabs are not displayed:
| Link     |
| ItemSync |
Given I call Shared Step 106194 (RPS Sign out)

@ScenarioId:10332
Scenario: [125556] Base functionality - Retailer has Access to ItemSync  - Menu Links Banner - options
Then I call Shared Step 134359 (RPS Login - User has Standard ItemSync Access)
Then I confirm the Home tab has loaded
Given  I confirm the following tabs are displayed:
| Link              |
| Home              |
| Dashboard         |
| Recent Activities |
| Web Viewers       |
| Product Lookup    |
| ItemSync          |
| Help & Support    |
| Drum Log          |
Given I call Shared Step 106194 (RPS Sign out)
Then I call Shared Step 134362 (RPS Login - User has Subscription ItemSync access)
Then I confirm the Home tab has loaded
Given  I confirm the following tabs are displayed:
| Link              |
| Home              |
| Dashboard         |
| Recent Activities |
| Web Viewers       |
| Product Lookup    |
| ItemSync          |
| Help & Support    |
Given I call Shared Step 106194 (RPS Sign out)

@ScenarioId:10333
Scenario: [125575] Base functionality - Retailer has Access to ItemSync  - ItemSync menu options
Then I call Shared Step 134359 (RPS Login - User has Standard ItemSync Access)
Then I confirm the Home tab has loaded
Given I click the tab: ItemSync
Then I confirm there is a drop down menu below the navigation tab: ItemSync
Then I confirm the following sub tabs are displayed under the tab: ItemSync:
| Link          |
| Manual Entry  |
| Upload a File |
Given I click the tab: ItemSync
Then I confirm there is not a drop down menu below the navigation tab: ItemSync
Given I call Shared Step 106194 (RPS Sign out)
#Then I click the sub tab: Demo Viewer

@ScenarioId:10334
Scenario: [125578] Base functionality - ItemSync - Manual Entry selected
Then I call Shared Step 134359 (RPS Login - User has Standard ItemSync Access)
Then I confirm the Home tab has loaded
Given I click the tab: ItemSync
Then I click the sub tab: Manual Entry
Then I confirm the ItemSync manual entry screen is shown with the title: Add UPC
Given I call Shared Step 106194 (RPS Sign out)

@ScenarioId:10335
Scenario: [125579] Base functionality - ItemSync - Upload a File selected
Then I call Shared Step 134359 (RPS Login - User has Standard ItemSync Access)
Then I confirm the Home tab has loaded
Given I click the tab: ItemSync
Then I click the sub tab: Upload a File
Then I wait for the ItemSync Upload a File screen to load
And I confirm the ItemSync Upload a File screen is shown
Given I call Shared Step 106194 (RPS Sign out)



