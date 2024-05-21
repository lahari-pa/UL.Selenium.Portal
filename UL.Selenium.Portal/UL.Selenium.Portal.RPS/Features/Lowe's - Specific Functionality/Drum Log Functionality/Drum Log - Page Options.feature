@RPS
@Login
@run_DrumgLogPageOptions
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
Feature: Drum Log - Page Options

@ScenarioId:10215
Scenario: [98471] Lowe's - Drum Log - Page options - (Last Page) >|
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: RPS.LW 
	Given I click the main tab: Drum Log
	Then I confirm the Drum Log tab has loaded
	Then I confirm the active tab is: Drum Log
	Then In the Drum Log Page, In the table footer I click on the Last Page Button
	Then I confirm the Drum Log tab has loaded
	Then In the Drum Log Page, In the Products table footer I check that the current page is the same as the last page number

@ScenarioId:10219
Scenario: [98472] Lowe's - Drum Log - Page options - (Previous Page) <<
    Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: RPS.LW 
	Given I click the main tab: Drum Log
	Then I confirm the Drum Log tab has loaded
	Then I confirm the active tab is: Drum Log
	Then In the Drum Log Page, In the Products table footer I click on the Next Page Button
	Then In the Drum Log Page, In the Products table footer I check that the current page is: 2
	Then In the Drum Log Page, In the Products table footer I click on the Previous Page Button
	Then In the Drum Log Page, In the Products table footer I check that the current page is: 1

@ScenarioId:10220
Scenario: [98473] Lowe's - Drum Log - Page options - (First Page) |<
    Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: RPS.LW 
	Given I click the main tab: Drum Log
	Then I confirm the Drum Log tab has loaded
	Then I confirm the active tab is: Drum Log
	Then In the Drum Log page, In the products table footer I confirm I see the first page icon
	Then In the Drum Log Page, In the table footer I click on the Last Page Button
	Then In the Drum Log Page, In the Products table footer I click on the First Page Button
	Then I confirm the Drum Log tab has loaded
	Then In the Drum Log Page, In the Products table footer I check that the current page is: 1

@ScenarioId:10221
Scenario: [98474] Lowe's - Drum Log - Page options 9 (Next Page) >>
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: RPS.LW 
	Given I click the main tab: Drum Log
	Then I confirm the Drum Log tab has loaded
	Then I confirm the active tab is: Drum Log
	Then In the Drum Log Page, In the Products table footer I click on the Next Page Button
	Then I confirm the Drum Log tab has loaded
	Then In the Drum Log Page, In the Products table footer I check that the current page is: 2

@ScenarioId:10223
Scenario: [98476] Lowe's - Drum Log - Page options - changing page number returns correct results
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: RPS.LW 
	Given I click the main tab: Drum Log
	Then I confirm the Drum Log tab has loaded
	Then I confirm the active tab is: Drum Log
	Then In the Drum Log Page, In the Products table footer I enter the page number value of: 3 
	Then In the Drum Log Page, In the Products table footer I confirm the product count range reflects the page I am on