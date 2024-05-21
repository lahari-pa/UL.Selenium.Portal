@RPS
@Login
@run_DrumgLogFunctionalityGeneral
@LandingPage
@Home
@Shared
@TopBar
@Navigation
@ProductInformation
@ProductLookUP
@Dashboard
@DrumLog
@HelpAndSupport


Feature: Drum Log Functionality General

@ScenarioId:10042
#Currently missing steps due to an issue with "Filters:" row.
Scenario: [105020] Drum Log - Breadcrumbs - Ticket is with DEV
Given I call Shared Step 98339 (RPS Lowe's Login)
Then I confirm the Home tab has loaded
Given I click the main tab: Drum Log
Then I confirm the Drum Log tab has loaded
Then In the Drum Log Page, I click the More Filters Button
And In the Drum Log Page, The More Filters Popup is showing
Then In the Drum Log Page More Filters Popup, I check that the: Store Name field is a drop down field
And In the Drum Log page, I select the option: UL Latham Test from the: Store Name drop down menu
Then In the Drum Log page, I Verify page refreshes in the background with a new row called: Filters:
#Verify background page loads and contains new row called "Filters"
#^No Row is Showing
Then In the Drum Log page, I select the option: REACTIVE from the: Drum Type drop down menu
Then In the Drum Log Page More Filters Popup, I Click the the Apply Filter Button
#Verify can see the breadcrumbs listed
Then I confirm that the Drum Log page bread crumb area contains the label: (.*)
Then I confirm that the Drum Log page bread crumb area contains the label: (.*)
#The above does not check that the there are no other labels. Maybe use a "only"?
