@RPS
@Login
@run_HomeTab
@LandingPage
@Home
@Shared
@TopBar
@Navigation
@ProductInformation
@ProductLookUP
Feature: Home Tab

@ScenarioId:6432
Scenario: [105246] Base functionality - Menu Links Banner - options
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: Franky TG User
	Then I click the tab: Home with parameter IsWebViewer: No
	Then I confirm the Home tab has loaded
	Given  I confirm the following tabs are displayed:
		| Link              |
		| Program Health    |
		| Dashboard         |
		| Recent Activities |
		| Web Viewers       |
		| Product Lookup    |
		| Help & Support    |
	Given I call Shared Step 106194 (RPS Sign out)
 
Scenario: [70347] Base Functionality - UL Logo
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the active tab is: <LandingTab>
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the Home tab has loaded
	And I confirm the UL Logo is displayed in the top bar
	Given I click the UL Logo in the top bar
	Then I verify that a tab opens with url: https://www.ul.com/
	And I close the tab with url: https://www.ul.com/
	Given I call Shared Step 106194 (RPS Sign out)

	Examples:
	| Scenario Name                          | Retailer | Page           | IsWebviewer | LandingTab              |
	| [#70347a] Base Functionality - UL Logo | RPS.LW   | Program Health | No          | LWLandingtab            |
	| [#70347b] Base Functionality - UL Logo | RPS.CV   | Program Health | No          | Program Health          |
	| [#70347c] Base Functionality - UL Logo | RPS.TG   | Program Health | No          | Product Lookup          |
	| [#70347d] Base Functionality - UL Logo | RPS.SF   | Program Health | No          | Program Health          |
#	| [#70347e] Base Functionality - UL Logo | RPS.PX   | Program Health | No          | Program Health          |
#	| [#70347f] Base Functionality - UL Logo | RPS.HD   | Program Health | No          | Program Health          |
#	| [#70347g] Base Functionality - UL Logo | RPS.WM   | Program Health | No          | Program Health          |


Scenario: [70346] Base Functionality - Log Out
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the active tab is: <LandingTab>
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the Home tab has loaded
	Given I confirm the user displayed in the top bar matches the active logged in user
	And I click the user button in the top bar
	Then I confirm the 'Sign Out' dropdown option is displayed under the user button
	Given I click on the home page background
	Then I confirm the Home tab has loaded
	Given I call Shared Step 106194 (RPS Sign out)
	Then I confirm the Landing Page has loaded

	Examples:
	| Scenario Name                          | Retailer | Page           | IsWebviewer | LandingTab              |
	| [#70346a] Base Functionality - Log Out | RPS.LW   | Program Health | No          | LWLandingtab            |
	| [#70346b] Base Functionality - Log Out | RPS.CV   | Program Health | No          | Program Health          |
	| [#70346c] Base Functionality - Log Out | RPS.TG   | Program Health | No          | Product Lookup          |
	| [#70346d] Base Functionality - Log Out | RPS.SF   | Program Health | No          | Program Health          |
#	| [#70346e] Base Functionality - Log Out | RPS.PX   | Program Health | No          | Program Health          |
#	| [#70346f] Base Functionality - Log Out | RPS.HD   | Program Health | No          | Program Health          |
#	| [#70346g] Base Functionality - Log Out | RPS.WM   | Program Health | No          | Program Health          |

@ScenarioId:6622
Scenario: [106428] Base Functionality - Home page - layout
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the active tab is: <LandingTab>
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the Home tab has loaded
	Given I confirm the top menu bar is displayed with the logged in username
	And I confirm the navigation menu bar is displayed below the top bar
	Given I click the Gauge button in the navigation bar
	Given I click the Reset Dashboard dropdown option below the navigation bar Gauge button
	Then I confirm the Home tab has loaded
	And I confirm there are a total of 4 widgets displayed in a 2 x 2 grid
	Then I confirm the following Widgets are displayed:
		| Widget                    |
		| RU Categories by RU       |
		| Products by Status        |
		| RU Categories by Supplier |
		| Product Hold Status       |

	Examples:
	| Scenario Name                                      | Retailer | Page           | IsWebviewer | LandingTab              |
	| [#106428a] Base Functionality - Home page - layout | RPS.LW   | Program Health | No          | LWLandingtab            |
	| [#106428b] Base Functionality - Home page - layout | RPS.CV   | Program Health | No          | Program Health          |
	| [#106428c] Base Functionality - Home page - layout | RPS.TG   | Program Health | No          | Product Lookup          |
	| [#106428d] Base Functionality - Home page - layout | RPS.SF   | Program Health | No          | Program Health          |
#	| [#106428e] Base Functionality - Home page - layout | RPS.PX   | Program Health | No          | Program Health          |
#	| [#106428f] Base Functionality - Home page - layout | RPS.HD   | Program Health | No          | Program Health          |
#	| [#106428g] Base Functionality - Home page - layout | RPS.WM   | Program Health | No          | Program Health          |


@ScenarioId:6623
Scenario: [106478] Base Functionality - Home page - widget layout
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the active tab is: <LandingTab>
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Given I confirm there are a total of 4 widgets displayed
	Then I verify each widget displays the correct data

	Examples:
	| Scenario Name                                             | Retailer | Page           | IsWebviewer | LandingTab              |
	| [#106478a] Base Functionality - Home page - widget layout | RPS.LW   | Program Health | No          | LWLandingtab            |
	| [#106478b] Base Functionality - Home page - widget layout | RPS.CV   | Program Health | No          | Program Health          |
	| [#106478c] Base Functionality - Home page - widget layout | RPS.TG   | Program Health | No          | Product Lookup          |
	| [#106478d] Base Functionality - Home page - widget layout | RPS.SF   | Program Health | No          | Program Health          |
#	| [#106478e] Base Functionality - Home page - widget layout | RPS.PX   | Program Health | No          | Program Health          |
#	| [#106478f] Base Functionality - Home page - widget layout | RPS.HD   | Program Health | No          | Program Health          |
#	| [#106478g] Base Functionality - Home page - widget layout | RPS.WM   | Program Health | No          | Program Health          |

@ScenarioId:6558
Scenario: [106453] Base functionality - Menu Links Banner - Gauge icon - menu items display
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the active tab is: <LandingTab>
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Given I click the Gauge button in the navigation bar
	Given I confirm the following drop down options are displayed below the navigation bar Gauge button:
		| Option              |
		| Reset Dashboard     |
		| Refresh All Widgets |
	Given I click on the home page background
	Then I confirm the down down options box is not displayed below the navigation bar Gauge button
	Given I call Shared Step 106194 (RPS Sign out)

	Examples:
	| Scenario Name                                                                       | Retailer | Page           | IsWebviewer | LandingTab              |
	| [#106453a] Base functionality - Menu Links Banner - Gauge icon - menu items display | RPS.LW   | Program Health | No          | LWLandingtab            |
	| [#106453b] Base functionality - Menu Links Banner - Gauge icon - menu items display | RPS.CV   | Program Health | No          | Program Health          |
	| [#106453c] Base functionality - Menu Links Banner - Gauge icon - menu items display | RPS.TG   | Program Health | No          | Product Lookup          |
	| [#106453d] Base functionality - Menu Links Banner - Gauge icon - menu items display | RPS.SF   | Program Health | No          | Program Health          |
#	| [#106453e] Base functionality - Menu Links Banner - Gauge icon - menu items display | RPS.PX   | Program Health | No          | Program Health          |
#	| [#106453f] Base functionality - Menu Links Banner - Gauge icon - menu items display | RPS.HD   | Program Health | No          | Program Health          |
#	| [#106453g] Base functionality - Menu Links Banner - Gauge icon - menu items display | RPS.WM   | Program Health | No          | Program Health          |


@ScenarioId:6435
Scenario: [106468] Base functionality - Menu Links Banner - Gauge icon - shows on correct pages
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the active tab is: <LandingTab>
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the Gauge button is displayed in the navigation bar
	Given I click the main tab: Dashboard
	And I confirm the active tab is: Dashboard
	Then I confirm the Gauge button is displayed in the navigation bar
	Given I click the main tab: Recent Activities
	And I confirm the active tab is: Recent Activities
	Then I confirm the Gauge button is not displayed in the navigation bar
	Given I click the main tab: Product Lookup
	And I confirm the active tab is: Product Lookup
	Then I confirm the Gauge button is not displayed in the navigation bar
	Given I click the main tab: Home
	And I confirm the active tab is: Home
	Then I confirm the Gauge button is displayed in the navigation bar
	Given I call Shared Step 106194 (RPS Sign out)

	Examples:
	| Scenario Name                                                                           | Retailer | Page           | IsWebviewer | LandingTab              |
	| [#106468a] Base functionality - Menu Links Banner - Gauge icon - shows on correct pages | RPS.LW   | Program Health | No          | LWLandingtab            |
	| [#106468b] Base functionality - Menu Links Banner - Gauge icon - shows on correct pages | RPS.CV   | Program Health | No          | Program Health          |
	| [#106468c] Base functionality - Menu Links Banner - Gauge icon - shows on correct pages | RPS.TG   | Program Health | No          | Product Lookup          |
	| [#106468d] Base functionality - Menu Links Banner - Gauge icon - shows on correct pages | RPS.SF   | Program Health | No          | Program Health          |
#	| [#106468e] Base functionality - Menu Links Banner - Gauge icon - shows on correct pages | RPS.PX   | Program Health | No          | Program Health          |
#	| [#106468f] Base functionality - Menu Links Banner - Gauge icon - shows on correct pages | RPS.HD   | Program Health | No          | Program Health          |
#	| [#106468g] Base functionality - Menu Links Banner - Gauge icon - shows on correct pages | RPS.WM   | Program Health | No          | Program Health          |
 
@ScenarioId:6456
Scenario: [106416] Base Functionality - Logged in page banner - layout
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the active tab is: <LandingTab>
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the logged in page banner shows font color: white
	Then I confirm the logged in page banner shows background color: black
	Then I confirm the page heading banner shows the WERCSmart Product Suite logo and it reads : WERCSmart® Product Suite
	Then I confirm the UL Logo is displayed in the top bar
	And I confirm the user displayed in the top bar matches the active logged in user
	And I call Shared Step 106194 (RPS Sign out)

	Examples:
	| Scenario Name                                                  | Retailer | Page           | IsWebviewer | LandingTab              |
	| [#106416a] Base Functionality - Logged in page banner - layout | RPS.LW   | Program Health | No          | LWLandingtab            |
	| [#106416b] Base Functionality - Logged in page banner - layout | RPS.CV   | Program Health | No          | Program Health          |
	| [#106416c] Base Functionality - Logged in page banner - layout | RPS.TG   | Program Health | No          | Product Lookup          |
	| [#106416d] Base Functionality - Logged in page banner - layout | RPS.SF   | Program Health | No          | Program Health          |
#	| [#106416e] Base Functionality - Logged in page banner - layout | RPS.PX   | Program Health | No          | Program Health          |
#	| [#106416f] Base Functionality - Logged in page banner - layout | RPS.HD   | Program Health | No          | Program Health          |
 

@ScenarioId:6510
Scenario: [73077] Base Functionality - WERCSmart Product Suite logo redirects to Home tab
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: Franky TG User 
	And I confirm the active tab is: Product Lookup
	Given I click the main tab: Dashboard
	And I confirm the active tab is: Dashboard
	And I click the UL Logo in the top bar
	And I confirm the active tab is: Product Lookup
	Given I click the main tab: Recent Activities
	And I confirm the active tab is: Recent Activities
	And I click the UL Logo in the top bar
	And I confirm the active tab is: Product Lookup
	Given I click the main tab: Product Lookup
	And I confirm the active tab is: Product Lookup
	And I click the UL Logo in the top bar
	And I confirm the active tab is: Product Lookup
	And I call Shared Step 106194 (RPS Sign out)

@ScenarioId:6453
@tfs_design
Scenario: [108521] Base Functionality - Home - Widget - hamburger icon - Print Chart
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: Franky TG User
	Then I confirm the Home tab has loaded
	Then I Click the hamburger menu for the widget: RU Categories by RU and select the option: Print chart
	Then I check that the print dialog is open
  

	Scenario: [169052] Hamburger Home - Widget Layout
Given I call Shared Step 104950 (RPS Login - Base Functionality)
Then I confirm the Home tab has loaded
	Then I confirm the following Widgets are displayed:
		| Widget                    |
		| RU Categories by RU       |
		| Products by Status        |
		| RU Categories by Supplier |
		| Product Hold Status       |
Given I verify each widget displays the correct data
Given I Check that the Hamburger menu dropdown for widget: RU Categories by RU is displayed
Given I Check that the Hamburger menu dropdown for widget: Products by Status is displayed
Given I Check that the Hamburger menu dropdown for widget: RU Categories by Supplier is displayed
Given I Check that the Hamburger menu dropdown for widget: Product Hold Status is displayed

Scenario: [169347] Home - Update and Reset Dashboard
    Given I call Shared Step 104950 (RPS Login - Base Functionality)
	Then I confirm the Home tab has loaded
	Then I confirm the following Widgets are displayed:
		| Widget                    |
		| RU Categories by RU       |
		| Products by Status        |
		| RU Categories by Supplier |
		| Product Hold Status       |
	And I call Shared Step 106517 (Home > Replace an original widget) for widget: RU Categories by RU
	And I call Shared Step 106517 (Home > Replace an original widget) for widget: Products by Status
	And I call Shared Step 106517 (Home > Replace an original widget) for widget: RU Categories by Supplier
	And I call Shared Step 106517 (Home > Replace an original widget) for widget: Product Hold Status
	Given I click the Gauge button in the navigation bar
	Given I confirm the following drop down options are displayed below the navigation bar Gauge button:
		| Option              |
		| Reset Dashboard     |
		| Refresh All Widgets |
	Given I click the Reset Dashboard dropdown option below the navigation bar Gauge button
	Then I confirm the Home tab has loaded
	Then I confirm the following Widgets are displayed:
		| Widget                    |
		| RU Categories by RU       |
		| Products by Status        |
		| RU Categories by Supplier |
		| Product Hold Status       |
	Given I call Shared Step 106194 (RPS Sign out)

Scenario: [169352] Home page - layout (New for Franky)
 Given I call Shared Step 104950 (RPS Login - Base Functionality)
 Then I confirm the logged in page banner shows font color: white
	Then I confirm the logged in page banner shows background color: navy blue
	Given  I confirm the following tabs are displayed:
		| Link              |
		| Program Health    |
		| Dashboard         |
		| Auditor           |
		| Recent Activities |
		| Web Viewers       |
		| ItemSync          |
		| Product Lookup    |
		| Help & Support    |
	Then I confirm the following Widgets are displayed:
		| Widget                    |
		| RU Categories by RU       |
		| Products by Status        |
		| RU Categories by Supplier |
		| Product Hold Status       |
    Then I confirm an information panel is displayed with heading: Become a sustainability leader.
	Then I confirm an information panel is displayed with heading: All product data in one place. Quick and easy.
	And I call Shared Step 106194 (RPS Sign out)

Scenario: [169348] Home - Chart displays no information
    Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: RPS.CV
    Then I confirm the logged in page banner shows font color: white
	Then I confirm the logged in page banner shows background color: navy blue
	Given  I confirm the following tabs are displayed:
		| Link              |
		| Program Health    |
		| Dashboard         |
		| Auditor           |
		| Recent Activities |
		| Web Viewers       |
		| ItemSync          |
		| Product Lookup    |
		| Help & Support    |
	Then I confirm the following Widgets are displayed:
		| Widget                    |
		| RU Categories by RU       |
		| Products by Status        |
		| RU Categories by Supplier |
		| Product Hold Status       |
    Then I confirm an information panel is displayed with heading: Become a sustainability leader.
	Then I confirm an information panel is displayed with heading: All product data in one place. Quick and easy.
	And I call Shared Step 106194 (RPS Sign out)