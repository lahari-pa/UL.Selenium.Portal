@RPS
@Login
@run_DrumgLogPageMoreFilters
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


Feature: Drum Log - More Filters

@ScenarioId:10241
Scenario: [98392] Lowe's - Drum Log - More Filters - Layout and field types
Given I call Shared Step 98339 (RPS Lowe's Login)
Then I confirm the Home tab has loaded
Given I click the tab: Drum Log
Then I confirm the Drum Log tab has loaded
Then I confirm the active tab is: Drum Log
Then In the Drum Log Page, I click the More Filters Button
And In the Drum Log Page, The More Filters Popup is showing
Then In the Drum Log page More Filters Popup I check for a scroll bar if the Date Removed Filter Option is not displayed on screen
Then In the Drum Log Page More Filters Popup, I check that the following filters fields exist:
| Filter                    |
| Store Name                |
| Region                    |
| Drum Type                 |
| Drum Type Changed by User |
| Drum Status               |
| Drum Open Date            |
| Drum Closed Date          |
| Product Id                |
| Product Name              |
| Manufacturer Name         |
| UPC Number                |
| Hauled Date               |
| Date In Drum              |
| Date Removed              |
Then In the Drum Log Page More Filters Popup, I Open the Store Name Filter Drop Down menu
Then In the Drum Log Page More Filters Popup, I check that the: Store Name field is a drop down field
And In the Drum Log page More Filters Popup I check I can Scroll through the Store Name options
Then In the Drum Log Page More Filters Popup, I Close the Store Name Filter Drop Down menu
Then In the Drum Log Page More Filters Popup, I check that the: Region field is a drop down field
#Then In the Drum Log Page More Filters Popup, I Open the: Region Filter Drop Down menu
#For Region, both DrumType and status filters will have to miss some steps regarding opening drop down and checking for scroll bar (automation limitations)
Then In the Drum Log Page More Filters Popup, I check that the: Drum Type field is a drop down field
Then In the Drum Log Page More Filters Popup, I check the drop down options for the filter: Drum Type match:
| Filter             |
| FLAMMABLE GAS      |
| FLAMMABLE LIQUID   |
| OXIDIZER           |
| POISON             |
| CLASS 9            |
| CORROSIVE ACIDIC   |
| CORROSIVE ALKALINE |
Then In the Drum Log Page More Filters Popup, I check that the: Drum Type Changed by User field is a drop down field
Then In the Drum Log Page More Filters Popup, I check the drop down options for the filter: Drum Type Changed by User match:
| Filter      |
| Changed     |
| Not Changed |
Then In the Drum Log Page More Filters Popup, I check that the: Drum Status field is a drop down field
Then In the Drum Log Page More Filters Popup, I check the drop down options for the filter: Drum Status match:
| Filter |
| Open   |
| Closed |
| Hauled |



