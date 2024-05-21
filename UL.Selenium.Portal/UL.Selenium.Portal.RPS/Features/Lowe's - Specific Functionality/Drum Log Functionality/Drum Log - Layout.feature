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
@ignore
@HelpAndSupport
Feature: Drum Log - Layout


@ScenarioId:10212
#Removed from regression: 2023/06
@ignore
Scenario: [105096] Lowe's - Drum Log - Drum details -  Date Removed format
	Given I call Shared Step 98339 (RPS Lowe's Login)
	Then I confirm the Home tab has loaded
	Given I click the main tab: Drum Log
	Then I confirm the Drum Log tab has loaded
	Then I confirm the active tab is: Drum Log
	And In the Drum Log page, I Look for an expanded Row that contains Date Removed data and save it to context as: expandedRow105096
	Then In the Drum Log page, I check that the Date Removed Column For the row saved as: expandedRow105096 shows in the format yyyy-mm-dd
	#And In the Drum Log page, I expand the first row of the products table
	#Then In the Drum Log page, I check that there are additional rows below the expanded version of the first row in the products table.
	#Then In the Drum Log page, I check that the Date Removed Column For the expanded first row shows in the format yyy-mm-dd

@ScenarioId:10213
#Remove from regression: 2023/06
@ignore
Scenario: [105086] Lowe's - Drum Log - Drum details -  Date in Drum format
	Given I call Shared Step 98339 (RPS Lowe's Login)
	Then I confirm the Home tab has loaded
	Given I click the main tab: Drum Log
	Then I confirm the Drum Log tab has loaded
	Then I confirm the active tab is: Drum Log
	And In the Drum Log page, I expand the first row of the products table
	Then In the Drum Log page, I check that there are additional rows below the expanded version of the first row in the products table.
	Then In the Drum Log page, I check that the 'Date In Drum' Column For the first row shows in the format yyyy-mm-dd

@ScenarioId:10214
#Removed from regression: 2023/06
@ignore
Scenario: [105084] Lowe's - Drum Log - Drum details - Scan Date format
	Given I call Shared Step 98339 (RPS Lowe's Login)
	Then I confirm the Home tab has loaded
	Given I click the main tab: Drum Log
	Then I confirm the Drum Log tab has loaded
	Then I confirm the active tab is: Drum Log
	And In the Drum Log page, I expand the first row of the products table
	Then In the Drum Log page, I check that there are additional rows below the expanded version of the first row in the products table.
	Then In the Drum Log page, I check that the 'Scan Date' Column For the first row shows in the format yyyy-mm-dd