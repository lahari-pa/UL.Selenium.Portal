@RPS
@Login
@run_ItemSync_Results_Screen
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


Feature: ItemSync - Results Screen

# Removed from regression: 2024/08
@ignore
@ScenarioId:10444
Scenario: [125716] Base functionality - ItemSync - Results Screen - layout - initial display
	Then I call Shared Step 134359 (RPS Login - User has Standard ItemSync Access)
	Then I confirm the Home tab has loaded
	Then I call Shared Step 126165 (RPS - ItemSync - Go to Manual Entry screen)
	Then I call Shared Step 125709 (ItemSync - Manual Entry - Add UPC)
	And In the ItemSync Manual Entry screen, I Click the Upload Button
	#Confirm table is now showing with the headings: (table)
	Then I wait for the ItemSync Manual Entry screen to load
	Then In the ItemSync Manual Entry screen, I confirm that the UPC Details Results Table has the following columns:
		| Headings         |
		| Valid?           |
		| UPC              |
		| Status           |
		| Definition       |
		| Suggested Action |
	Then In the ItemSync Manual Entry screen, I confirm the table footer is showing
	And I Confirm the Item Sync Results Page shows the title 'UPC Details'
	Then I Confirm the Item Sync Results Page shows the Buttons: in order
		| Buttons         |
		| More Filters    |
		| Reset           |
		| Export to Excel |
	Given I call Shared Step 106194 (RPS Sign out)

# Removed from regression: 2024/08
@ignore
@ScenarioId:11236
Scenario: [125717] Base functionality - ItemSync - Results Screen -  Results grid columns
	Then I call Shared Step 134359 (RPS Login - User has Standard ItemSync Access)
	Then I confirm the Home tab has loaded
	Then I call Shared Step 126165 (RPS - ItemSync - Go to Manual Entry screen)
	Then I call Shared Step 125709 (ItemSync - Manual Entry - Add UPC)
	And In the ItemSync Manual Entry screen, I Click the Upload Button
	Then I wait for the ItemSync Manual Entry screen to load
	Then In the ItemSync Manual Entry screen, I confirm that the UPC Details Results Table has the following columns:
		| Headings         |
		| Valid?           |
		| UPC              |
		| Status           |
		| Definition       |
		| Suggested Action |
	Given I call Shared Step 106194 (RPS Sign out)

# Removed from regression: 2024/08
@ignore
@ScenarioId:10474
Scenario: [125718] Base functionality - ItemSync - Results Screen -  Navigation buttons
	Then I call Shared Step 134359 (RPS Login - User has Standard ItemSync Access)
	Then I confirm the Home tab has loaded
	Then I call Shared Step 125737 (ItemSync > Upload File to Results page) for file: notepad 301 upcs with some invalid.csv
	Then I wait for the ItemSync Upload a File screen to load
	Then I Confirm the Item Sync Results Page shows the UPC results grid
	Then In the ItemSync Upload a File screen, I confirm the table footer is showing
	Then In the ItemSync Upload a File screen, I confirm that the UPC Details Results Table footer has the following page navigation icons:
		| Icons         |
		| First page    |
		| Next page     |
		| Previous Page |
		| Last Page     |
	Then In the ItemSync Upload a File screen, I confirm that the UPC Details Results Table footer diplays hover over text for the following icons:
		| Icons         |
		| Next page     |
		| Last Page     |
	Then In the ItemSync Upload a File screen, I click the: Next Page Icon in the UPC Details Reults Table Footer.
	Then I wait for the ItemSync Upload a File screen to load
	Then In the ItemSync Upload a File screen, I confirm that the UPC Details Results Table footer diplays hover over text for the following icons:
		| Icons         |
		| Next page     |
		| Last Page     |
	Given I call Shared Step 106194 (RPS Sign out)

# Removed from regression: 2024/08
@ignore
@ScenarioId:10510
Scenario: [125720] Base functionality - ItemSync - Results Screen - Items per page selector
	Then I call Shared Step 134359 (RPS Login - User has Standard ItemSync Access)
	Then I confirm the Home tab has loaded
	Then I call Shared Step 125737 (ItemSync > Upload File to Results page) for file: notepad 301 upcs with some invalid.csv
	Then I wait for the ItemSync Upload a File screen to load
	Then I Confirm the Item Sync Results Page shows the UPC results grid
	Then In the ItemSync Upload a File screen, I confirm I see the items per page drop down selector
	Then In the ItemSync Upload a File screen, I confirm I see the items per page selector is set to: 10
	Then In the ItemSync Upload a File screen, I confirm the possible items per page options are:
		| Options |
		| 10      |
		| 20      |
		| 30      |
	Then In the ItemSync Upload a File screen, I select the items per page option: 20
	Then I wait for the ItemSync Upload a File screen to load
	Then In the ItemSync Upload a File screen, I confirm the number of rows in the UPC Details Results table is: 20
	Then In the ItemSync Upload a File screen, I select the items per page option: 10
	Then I wait for the ItemSync Upload a File screen to load
	Then In the ItemSync Upload a File screen, I confirm the number of rows in the UPC Details Results table is: 10
	Then In the ItemSync Upload a File screen, I select the items per page option: 30
	Then I wait for the ItemSync Upload a File screen to load
	Then In the ItemSync Upload a File screen, I confirm the number of rows in the UPC Details Results table is: 30
	Given I call Shared Step 106194 (RPS Sign out)

# Removed from regression: 2024/08
@ignore
@ScenarioId:10521
Scenario: [125722] Base functionality - ItemSync - Results Screen - Grid count indicator
	Then I call Shared Step 134359 (RPS Login - User has Standard ItemSync Access)
	Then I confirm the Home tab has loaded
	Then I call Shared Step 125737 (ItemSync > Upload File to Results page) for file: notepad 301 upcs with some invalid.csv
	Then I wait for the ItemSync Upload a File screen to load
	Then I Confirm the Item Sync Results Page shows the UPC results grid
	Then In the ItemSync Upload a File screen, I confirm I see the grid count indicator
	Then In the ItemSync Upload a File screen, I confirm the grid count indicator is shown in the format: View 1 - 10 of x
	Given I call Shared Step 106194 (RPS Sign out)

# Removed from regression: 2024/08
@ignore
@ScenarioId:10522
Scenario: [125723] Base functionality - ItemSync - Results Screen -  Invalid UPC - static text
	Then I call Shared Step 134359 (RPS Login - User has Standard ItemSync Access)
	Then I confirm the Home tab has loaded
	Then I call Shared Step 125737 (ItemSync > Upload File to Results page) for file: test 1 valid and 1 invalid upc.csv
	Then I wait for the ItemSync Upload a File screen to load
