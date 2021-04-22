@RPS
@Login
@run_DrumgLogLayout
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


Feature: Drum Log - Layout

@ScenarioId:10045
Scenario: [105079] Lowe's - Drum Log - Tab heading shows as active when selected
Given I call Shared Step 98339 (RPS Lowe's Login)
Then I confirm the Home tab has loaded
Given I click the tab: Drum Log
Then I confirm the Drum Log tab has loaded
Then I confirm the active tab is: Drum Log
And I Confirm that the tab: Drum Log shows in a grey highlight indicating it is active
Then I Confirm that all tabs not labeled: Drum Log are not highlighted in grey
Given I click the tab: Recent Activities
Then I confirm the Recent Activities tab has loaded
Then I Confirm that the tab: Drum Log is not shown in grey highlight indicating it is inactive
And I Confirm that the tab: Recent Activities shows in a grey highlight indicating it is active
Then I confirm the active tab is: Recent Activities
Given I click the tab: Drum Log
Then I confirm the Drum Log tab has loaded
Then I confirm the active tab is: Drum Log
And I Confirm that the tab: Drum Log shows in a grey highlight indicating it is active

@ScenarioId:10048
Scenario: [108105] Lowe's Functionality - Drum Log page - layout
Given I call Shared Step 98339 (RPS Lowe's Login)
Then I confirm the Home tab has loaded
Given I click the tab: Drum Log
Then I confirm the Drum Log tab has loaded
Then I confirm the active tab is: Drum Log
Then I confirm the page heading banner shows the WERCSmart Product Suite logo and it reads : WERCSmart® Product Suite
Then I confirm the UL Logo is displayed in the top bar 
And I confirm the user displayed in the top bar matches the active logged in user
Then I confirm the menu links banner is displayed
And I confirm the Drum Log Page background color is: grey
Then I confirm the Drum Log Page Text color is: darker grey
Then I Check that the current page title is 'Drum Log'
Then I confirm the Drum Log search box is shown
Then I confirm that the Drum Log search box place holder text reads: Search
Then I confirm that the Drum Log Page buttons to the right of the search box are as follows:
| Buttons         |
| More Filters    |
| Reset           |
| Export to Excel |
Then I confirm that the Drum Log page does not show the bread crumb area
Then I confirm that the Drum Log page shows the headings row in the table
Then I confirm that the Drum Log page headings row has a grey background color
Then In the Drum Log page, I confirm the column labels show a colon (:) icon as the column resize anchor
Then In the Drum Log page, I confirm that the main table has the following columns:
| Headings    |
| Drum Name   |
| Drum Type   |
| Drum Status |
| Store Name  |
| Region Name |
| Location    |
| Date Opened |
| Date Closed |
| Date Hauled |
Then I call Shared Step 111155 (Table Heading or sub heading - confirm column resize anchor - resize column) On the: Drum Log page, for the column: Drum Name
Then I call Shared Step 111155 (Table Heading or sub heading - confirm column resize anchor - resize column) On the: Drum Log page, for the column: Drum Type
Then I call Shared Step 111155 (Table Heading or sub heading - confirm column resize anchor - resize column) On the: Drum Log page, for the column: Drum Status
Then I call Shared Step 111155 (Table Heading or sub heading - confirm column resize anchor - resize column) On the: Drum Log page, for the column: Store Name
Then I call Shared Step 111155 (Table Heading or sub heading - confirm column resize anchor - resize column) On the: Drum Log page, for the column: Region Name
Then I call Shared Step 111155 (Table Heading or sub heading - confirm column resize anchor - resize column) On the: Drum Log page, for the column: Location
Then I call Shared Step 111155 (Table Heading or sub heading - confirm column resize anchor - resize column) On the: Drum Log page, for the column: Date Opened
Then I call Shared Step 111155 (Table Heading or sub heading - confirm column resize anchor - resize column) On the: Drum Log page, for the column: Date Closed
Then I call Shared Step 111155 (Table Heading or sub heading - confirm column resize anchor - resize column) On the: Drum Log page, for the column: Date Hauled
Then In the Drum Logg page, I confirm that the main table shows data rows
Then In the Drum Log page, I confirm that In the data row to the far left I confirm I see a right facing arrow (Expand arrow)
Then In the Drum Log page, I confirm that to the right of the expand arrow I see the Drum Name
Then ~~MANUAL CHECK~~ In the Drum Log page, I confirm that each column of data is aligned to the left of the column
Then In the Drum Log page, I confirm that the table shows alternating background color (grey to white)
Then In the Drum Log Page, In the Products table footer, select the items per page option: 30
Then ~~MANUAL CHECK~~ In the Drum Log page, I confirm a slider bar is shown to the right of the table
Then In the Drum Log Page, In the Products table I scroll down to the bottom product and check its interactable
Then In the Drum Log Page, In the Products table I scroll up to the top product and check its interactable
Then In the Drum Log Page, In the Products table I click the Reset Button
Then In the Drum Log page, below the Most Recent Activity table I confirm: page footer is shown


@ScenarioId:10137
Scenario: [111156] Lowe's Functionality - Drum Log page - Resize columns
Given I call Shared Step 98339 (RPS Lowe's Login)
Then I confirm the Home tab has loaded
Given I click the tab: Drum Log
Then I confirm the Drum Log tab has loaded
Then I confirm the active tab is: Drum Log
Then I call Shared Step 111155 (Table Heading or sub heading - confirm column resize anchor - resize column) On the: Drum Log page, for the column: Drum Name
And In the Drum Log page, I expand the first row of the products table
And I call Shared Step 111155 (Table Heading or sub heading - confirm column resize anchor - resize column) On the: Drum Log page, for the column: Scan Date


@ScenarioId:10139
@ManualCheck
Scenario: [108106] Lowe's - Drum Log page - Expand arrow 
Given I call Shared Step 98339 (RPS Lowe's Login)
Then I confirm the Home tab has loaded
Given I click the tab: Drum Log
Then I confirm the Drum Log tab has loaded
Then I confirm the active tab is: Drum Log
And In the Drum Log page, I expand the first row of the products table
Then In the Drum Log page, I check that there are additional rows below the expanded version of the first row in the products table.
Then In the Drum Log page, I confirm that the expanded first row has following columns in the sub table:
| Headings       |
| Scan Date      |
| Date In Drum   |
| Date Removed   |
| Found/NotFound |
| Manufacturer   |
| Name           |
| Product        |
| UPC            |
| Volume         |
| Actions        |
Then In the Drum Log page, I confirm that the expanded first row column headings show the ':' resize anchor
Then ~~MANUAL CHECK~~ In the Drum Log page, I confirm that each column of data is aligned to the left of the column
Then In the Drum Log page, I confirm that in the expanded first row I see the expanded menu icon to the left
And In the Drum Log page, I collapse the first row of the products table
Then In the Drum Log page, I check that there are no additional rows below the expanded version of the first row in the products table.

@ScenarioId:10194
Scenario: [105117] Lowe's - Drum Log - Entries shown are not repeated
Given I call Shared Step 98339 (RPS Lowe's Login)
Then I confirm the Home tab has loaded
Given I click the tab: Drum Log
Then I confirm the Drum Log tab has loaded
Then I confirm the active tab is: Drum Log
And In the Drum Log page, I check that the data shown is not repeated

@ScenarioId:10212
Scenario: [105096] Lowe's - Drum Log - Drum details -  Date Removed format
Given I call Shared Step 98339 (RPS Lowe's Login)
Then I confirm the Home tab has loaded
Given I click the tab: Drum Log
Then I confirm the Drum Log tab has loaded
Then I confirm the active tab is: Drum Log
And In the Drum Log page, I Look for an expanded Row that contains Date Removed data and save it to context as: expandedRow105096
Then In the Drum Log page, I check that the Date Removed Column For the row saved as: expandedRow105096 shows in the format yyyy-mm-dd
#
#And In the Drum Log page, I expand the first row of the products table
#Then In the Drum Log page, I check that there are additional rows below the expanded version of the first row in the products table.
#Then In the Drum Log page, I check that the Date Removed Column For the expanded first row shows in the format yyy-mm-dd

@ScenarioId:10213
Scenario: [105086] Lowe's - Drum Log - Drum details -  Date in Drum format
Given I call Shared Step 98339 (RPS Lowe's Login)
Then I confirm the Home tab has loaded
Given I click the tab: Drum Log
Then I confirm the Drum Log tab has loaded
Then I confirm the active tab is: Drum Log
And In the Drum Log page, I expand the first row of the products table
Then In the Drum Log page, I check that there are additional rows below the expanded version of the first row in the products table.
Then In the Drum Log page, I check that the 'Date In Drum' Column For the first row shows in the format yyyy-mm-dd

@ScenarioId:10214
Scenario: [105084] Lowe's - Drum Log - Drum details - Scan Date format
Given I call Shared Step 98339 (RPS Lowe's Login)
Then I confirm the Home tab has loaded
Given I click the tab: Drum Log
Then I confirm the Drum Log tab has loaded
Then I confirm the active tab is: Drum Log
And In the Drum Log page, I expand the first row of the products table
Then In the Drum Log page, I check that there are additional rows below the expanded version of the first row in the products table.
Then In the Drum Log page, I check that the 'Scan Date' Column For the first row shows in the format yyyy-mm-dd
