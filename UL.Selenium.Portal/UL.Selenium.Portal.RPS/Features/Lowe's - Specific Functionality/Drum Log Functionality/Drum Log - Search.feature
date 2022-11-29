@RPS
@Login
@run_DrumgLogSearch
@LandingPage
@Home
@Shared
@TopBar
@Navigation
@ProductInformation
@ProductLookUP
@Dashboard
@DrumLog
@RecentActivities
@HelpAndSupport


Feature: Drum Log - Search

@ScenarioId:10227
Scenario: [108293] Lowe's- Drum Log - Search > Drum Name
Given I call Shared Step 98339 (RPS Lowe's Login)
Then I confirm the Home tab has loaded
Given I click the tab: Drum Log
Then I confirm the Drum Log tab has loaded
Then I confirm the active tab is: Drum Log
Then In the Drum Log Page, In the Products table I select a random product and save Drum Data to context as: DrumLogData108293
Then In the Drum Log, In the table I search for the drum with Drum Name: DrumLogData108293
Then I confirm the Drum Log tab has loaded
Then In the Drum Log Page, In the table the first result matches the Drum Name: DrumLogData108293
And I call Shared Step 106194 (RPS Sign out)

@ScenarioId:10230
Scenario: [111072] Lowe's- Drum Log - Search > Store Name
Given I call Shared Step 98339 (RPS Lowe's Login)
Then I confirm the Home tab has loaded
Given I click the tab: Drum Log
Then I confirm the Drum Log tab has loaded
Then I confirm the active tab is: Drum Log
Then In the Drum Log Page, In the Products table I select a random product and save Drum Data to context as: DrumLogData111072
Then In the Drum Log, In the table I search for the drum with Store Name: DrumLogData111072
Then I confirm the Drum Log tab has loaded
Then In the Drum Log Page, In the table the first result matches the Store Name: DrumLogData111072
And I call Shared Step 106194 (RPS Sign out)


@ScenarioId:10232
Scenario: [111073] Lowe's- Drum Log - Search > Location
Given I call Shared Step 98339 (RPS Lowe's Login)
Then I confirm the Home tab has loaded
Given I click the tab: Drum Log
Then I confirm the Drum Log tab has loaded
Then I confirm the active tab is: Drum Log
Then In the Drum Log Page, In the Products table I select a random product and save Drum Data to context as: DrumLogData111073
#Then In the Drum Log, In the table I search for the drum with Location: DrumLogData111073
Then In the Drum Log, In the table I search for the drum with partial Location: DrumLogData111073
Then I confirm the Drum Log tab has loaded
Then In the Drum Log Page, In the table the first result matches the Location: DrumLogData111073
And I call Shared Step 106194 (RPS Sign out)

@ScenarioId:10238
Scenario: [111074] Lowe's- Drum Log - Search > Product Name
Given I call Shared Step 98339 (RPS Lowe's Login)
Then I confirm the Home tab has loaded
Given I click the tab: Drum Log
Then I confirm the Drum Log tab has loaded
Then I confirm the active tab is: Drum Log
Then In the Drum Log Page, In the Products table I select a random product and save Drum Data to context as: DrumLogData111074
Then For the Drum Data saved as: DrumLogData111074 I save the Name for the data in postion: 1 as: SavedAsName111074
Then In the Drum Log Page, In the table I search for the text: SavedAsName111074
Then I confirm the Drum Log tab has loaded
Then In the Drum Log page, I check that the first result in the table contains the Name saved as: SavedAsName111074
And I call Shared Step 106194 (RPS Sign out)
#part of name?

@ScenarioId:10239
Scenario: [108294] Lowe's- Drum Log - Search > Region
Given I call Shared Step 98339 (RPS Lowe's Login)
Then I confirm the Home tab has loaded
Given I click the tab: Drum Log
Then I confirm the Drum Log tab has loaded
Then I confirm the active tab is: Drum Log
Then In the Drum Log Page, In the Products table I select a random product and save Drum Data to context as: DrumLogData108294
Then In the Drum Log, In the table I search for the drum with Region Name: DrumLogData108294
Then I confirm the Drum Log tab has loaded
Then In the Drum Log Page, In the table the first result matches the Region Name: DrumLogData108294
And I call Shared Step 106194 (RPS Sign out)

@ScenarioId:10240
Scenario: [108292] Lowe's- Drum Log - Search > Manufacturer
Given I call Shared Step 98339 (RPS Lowe's Login)
Then I confirm the Home tab has loaded
Given I click the tab: Drum Log
Then I confirm the Drum Log tab has loaded
Then I confirm the active tab is: Drum Log
Then In the Drum Log Page, In the Products table I select a random product and save Drum Data to context as: DrumLogData108292
Then For the Drum Data saved as: DrumLogData108292 I save the Manufacturer for the data in postion: 1 as: SavedAsManufacturer108292
Then In the Drum Log Page, In the table I search for the text: SavedAsManufacturer108292
#Then In the Drum Log, In the table I search for the drum with Drum Name: DrumLogData108292
Then I confirm the Drum Log tab has loaded
Then In the Drum Log Page, In the table I find a result which matches the Drum Name: DrumLogData108292 and save it as: DrumLogData108292row
Then In the Drum Log Page, In the Products table save the Drum Data to context as: DrumLogData108292b for Drum with Drum Name: DrumLogData108292
Then In the Drum Log page, I check that the Data Saved As: DrumLogData108292b contains the Manufacturer saved as: SavedAsManufacturer108292


