@RPS
@Login
@run_RecentActivites_PageOptions
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


Feature: Recent Activities - Page Options



@ScenarioId:6982
Scenario: [98463] Base Functionality - Recent Activities - Page options - (Last Page) >| 
Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: Franky TG User
#Then I confirm the Home tab has loaded
Given I click the main tab: Recent Activities
Then I confirm the Recent Activities tab has loaded
Then In the recent activities page, I click the label 'Start Date'
Then I confirm the Recent Activities tab has loaded
Then In the recent activities Page, In the Products table footer I click on the Last Page Button
Then I confirm the Recent Activities tab has loaded
And In the recent activities Page, In the Products table footer I check that the current page is the same as the last page number

@ScenarioId:6984
Scenario: [98464] Base Functionality - Recent Activities - Page options - (Previous Page) <<
Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
 Then I confirm the active tab is: <LandingTab>
 Then I click Accept all Cookies
Given I click the main tab: Recent Activities
Then I confirm the Recent Activities tab has loaded  
And In the recent activities Page, In the Products table footer I click on the Next Page Button
Then In the recent activities Page, In the Products table footer I check that the current page is: 2
Then In the recent activities Page, In the Products table footer I click on the Previous Page Button
And In the recent activities Page, In the Products table footer I check that the current page is: 1

	Examples:
	| Scenario Name                                                                       | Retailer | LandingTab               |
	| [#98464a]Base Functionality - Recent Activities - Page options - (Previous Page) << | RPS.LW   | LWLandingtab             |
	| [#98464b]Base Functionality - Recent Activities - Page options - (Previous Page) << | RPS.CV   | Program Health           |
#	| [#98464c]Base Functionality - Recent Activities - Page options - (Previous Page) << | RPS.HD   | Program Health           |
	| [#98464d]Base Functionality - Recent Activities - Page options - (Previous Page) << | RPS.SF   | Program Health           |
#	| [#98464e]Base Functionality - Recent Activities - Page options - (Previous Page) << | RPS.WM   | Program Health           |
#	| [#98464f]Base Functionality - Recent Activities - Page options - (Previous Page) << | RPS.PX   | Program Health           |
 

@ScenarioId:6985
Scenario: [98465] Base Functionality - Recent Activities - Page options (First Page)  ||<
Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: Franky TG User
#Then I confirm the Home tab has loaded
Given I click the main tab: Recent Activities
Then I confirm the Recent Activities tab has loaded
Then In the recent activities page, I click the label 'Start Date'
Then I confirm the Recent Activities tab has loaded
Then In the recent activities Page, In the Products table footer I click on the Last Page Button
Then I confirm the Recent Activities tab has loaded
And In the recent activities Page, In the Products table footer I check that the current page is the same as the last page number
Then In the recent activities Page, In the Products table footer I click on the First Page Button
And In the recent activities Page, In the Products table footer I check that the current page is: 1

@ScenarioId:6986
Scenario: [98466] Base Functionality - Recent Activities - Page options (Next Page) >>
Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
 Then I confirm the active tab is: <LandingTab>
 Then I click Accept all Cookies
Given I click the main tab: Recent Activities
Then I confirm the Recent Activities tab has loaded
And In the recent activities Page, In the Products table footer I click on the Next Page Button
Then In the recent activities Page, In the Products table footer I check that the current page is: 2

	Examples:
	| Scenario Name                                                                  | Retailer | LandingTab               |
	| [#98466a]Base Functionality - Recent Activities - Page options (Next Page) >> | RPS.LW   | LWLandingtab             |
	| [#98466b]Base Functionality - Recent Activities - Page options (Next Page) >> | RPS.CV   | Program Health           |
#	| [#98466c]Base Functionality - Recent Activities - Page options (Next Page) >> | RPS.HD   | Program Health           |
	| [#98466d]Base Functionality - Recent Activities - Page options (Next Page) >> | RPS.SF   | Program Health           |
#	| [#98466e]Base Functionality - Recent Activities - Page options (Next Page) >> | RPS.WM   | Program Health           |
#	| [#98466f]Base Functionality - Recent Activities - Page options (Next Page) >> | RPS.PX   | Program Health           |
 

@ScenarioId:6988
Scenario: [199959] Base Functionality - Recent Activities - Page options - Change number of products per page with reset
Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: Franky TG User
#Then I confirm the Home tab has loaded
Given I click the main tab: Recent Activities
Then I confirm the Recent Activities tab has loaded
Then In the recent activities page, I click the label 'Start Date'
Then I confirm the Recent Activities tab has loaded
Then In the recent activities Page, In the Products table footer, the number of items per page shows the following options:
| Option |
| 10      |
| 20      |
| 30      |
Then In the recent activities Page, In the Products table footer, select the items per page option: 20
Then In the recent activities Page, I check the full page is visible
Then In the recent activities Page, In the Products table I scroll down to the bottom product and check its interactable
Then In the recent activities Page, In the Products table I scroll down to the top product and check its interactable
Then In the recent activities Page, In the Products table the total number of pages is correct
And In the recent activities Page, In the Products table I click the Reset Button
Then In the recent activities Page, I check the full page is visible
Then In the recent activities Page, In the Products table footer I check that the current page is: 1

@ScenarioId:6990
Scenario: [98462] Base Functionality - Recent Activities - Page options - change page number
Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: Franky TG User
#Then I confirm the Home tab has loaded
Given I click the main tab: Recent Activities
Then I confirm the Recent Activities tab has loaded
Then In the recent activities page, I click the label 'Start Date'
Then I confirm the Recent Activities tab has loaded
Then In the recent activities Page, In the Products table footer I enter the page number value of: 5

@ScenarioId:6999
Scenario: [98468] Base Functionality - Recent Activities - Page options - changing page number returns correct results
Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: Franky TG User
#Then I confirm the Home tab has loaded
Given I click the main tab: Recent Activities
Then I confirm the Recent Activities tab has loaded
Then In the recent activities page, I click the label 'Start Date'
Then I confirm the Recent Activities tab has loaded
Then In the recent activities Page, In the Products table footer I enter the page number value of: 5
Then In the recent activities Page, In the Products table footer I confirm the product count range reflects the page I am on




