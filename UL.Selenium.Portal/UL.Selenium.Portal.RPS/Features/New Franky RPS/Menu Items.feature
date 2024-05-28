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
@Dashboard
@RecentActivities
@HelpAndSupport

Feature: Menu Items

Scenario Outline: [169070] Menu Links Banner - layout
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the active tab is: <LandingTab>
	Then I click the main tab: Program Health
	Then I confirm the Home tab has loaded
	Then I confirm the menu links banner is displayed
	# Check background color of navbar menu items
	# Check font color of navbar menu items
	# Check left alignment of navbar menu items
	# Check right alignment of navbar dropdown item
	Given I call Shared Step 106194 (RPS Sign out)

	Examples:
	| Scenario Name                         | Retailer | LandingTab               |
	| [#169070a] Menu Links Banner - layout | RPS.LW   | LWLandingtab             |
	| [#169070b] Menu Links Banner - layout | RPS.CV   | Program Health           |
#	| [#169070c] Menu Links Banner - layout | RPS.WM   | Program Health           |
#	| [#169070d] Menu Links Banner - layout | RPS.HD   | Program Health           |
	| [#169070e] Menu Links Banner - layout | RPS.SF   | Program Health           |
#	| [#169070f] Menu Links Banner - layout | RPS.PX   | Program Health           |
	| [#169070g] Menu Links Banner - layout | RPS.TG   | Product Lookup           |
	| [#169070h] Menu Links Banner - layout | RPS.CT   | Program Health           |

Scenario Outline: [169071] Menu Links Banner - Gauge icon - menu items display
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the active tab is: <LandingTab>
	Then I click the main tab: <TestingTab>
	Then I confirm the active tab is: <TestingTab>
	Then I click the Gauge button in the navigation bar
	Then I confirm the down down options box is displayed below the navigation bar Gauge button
	Given I confirm the following drop down options are displayed below the navigation bar Gauge button:
		| Option              |
		| Reset Dashboard     |
		| Refresh All Widgets |
	Then I click the Gauge button in the navigation bar
	Then I confirm the down down options box is not displayed below the navigation bar Gauge button
	Given I call Shared Step 106194 (RPS Sign out)

	Examples:
	| Scenario Name                                                         | Retailer | LandingTab               | TestingTab           | 
	| [#169071a] Menu Links Banner - Gauge icon - menu items display - Home | RPS.LW   | LWLandingtab             | Dashboard            |
	| [#169071b] Menu Links Banner - Gauge icon - menu items display - Home | RPS.CV   | Program Health           | Dashboard            |
#	| [#169071c] Menu Links Banner - Gauge icon - menu items display - Home | RPS.WM   | Program Health           | Dashboard            |
#	| [#169071d] Menu Links Banner - Gauge icon - menu items display - Home | RPS.HD   | Program Health           | Dashboard            |
	| [#169071e] Menu Links Banner - Gauge icon - menu items display - Home | RPS.SF   | Program Health           | Dashboard            |
#	| [#169071f] Menu Links Banner - Gauge icon - menu items display - Home | RPS.PX   | Program Health           | Dashboard            |
	| [#169071g] Menu Links Banner - Gauge icon - menu items display - Home | RPS.TG   | Product Lookup           | Dashboard            |
	| [#169071h] Menu Links Banner - Gauge icon - menu items display - Home | RPS.CT   | Program Health           | Dashboard            |

Scenario Outline: [169073] Menu Links Banner - active page/ heading background color
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the active tab is: <LandingTab>
	Then I click the main tab: Program Health
	Then I confirm the Home tab has loaded
	Then I click Accept all Cookies
	# Check background color of navbar menu home button
	Then I confirm the active tab is: Program Health
	And I Confirm that the tab: Program Health shows in a white highlight indicating it is active
	Then I click the main tab: Dashboard
	Then I confirm the Dashboard tab has loaded
	Then I confirm the active tab is: Dashboard
	And I Confirm that the tab: Dashboard shows in a white highlight indicating it is active
	And I Confirm that the tab: Program Health is not shown in grey highlight indicating it is inactive
	Then I click the main tab: Recent Activities
	Then I confirm the Recent Activities tab has loaded
	Then I confirm the active tab is: Recent Activities
	And I Confirm that the tab: Recent Activities shows in a white highlight indicating it is active
	And I Confirm that the tab: Dashboard is not shown in grey highlight indicating it is inactive
	Then I click the main tab: Product Lookup
	Then I confirm the Product Lookup tab has loaded
	Then I confirm the active tab is: Product Lookup
	And I Confirm that the tab: Product Lookup shows in a white highlight indicating it is active
	And I Confirm that the tab: Recent Activities is not shown in grey highlight indicating it is inactive
	Then I click the main tab: Web Viewers
	And I Confirm that the tab: Product Lookup shows in a white highlight indicating it is active
	And I confirm there is a drop down menu below the navigation tab: Web Viewers
	Then I click the main tab: Web Viewers
	And I confirm there is not a drop down menu below the navigation tab: Web Viewers
	Then I click the main tab: Help & Support
	And I Confirm the Help & Support Popup is displayed
	Then In the Help & Support Popup I click the X Icon
	And I Confirm the Help & Support Popup is not displayed
	And I Confirm that the tab: Product Lookup shows in a white highlight indicating it is active
	Given I call Shared Step 106194 (RPS Sign out)

	Examples:
	| Scenario Name                                                        | Retailer | LandingTab              |
#	| [#169073a] Menu Links Banner - active page/ heading background color | RPS.WM   | Program Health          |
	| [#169073b] Menu Links Banner - active page/ heading background color | RPS.TG   | Product Lookup          |
#	| [#169073c] Menu Links Banner - active page/ heading background color | RPS.HD   | Program Health          |
	| [#169073d] Menu Links Banner - active page/ heading background color | RPS.SF   | Program Health          |
#	| [#169073e] Menu Links Banner - active page/ heading background color | RPS.PX   | Program Health          |

Scenario Outline: [169074] Menu Links Banner - Gauge icon - shows on correct pages
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the active tab is: <LandingTab>
	Then I click the main tab: Program Health
	Then I confirm the Home tab has loaded
	And I confirm the Gauge button is not displayed in the navigation bar
	Then I click the main tab: Dashboard
	Then I confirm the Dashboard tab has loaded
	And I confirm the Gauge button is displayed in the navigation bar
	Then I click the main tab: Recent Activities
	Then I confirm the Recent Activities tab has loaded
	And I confirm the Gauge button is not displayed in the navigation bar
	Then I click the main tab: Product Lookup
	Then I confirm the Product Lookup tab has loaded
	And I confirm the Gauge button is not displayed in the navigation bar
	Then I click the main tab: Program Health
	Then I confirm the Home tab has loaded
	And I confirm the Gauge button is not displayed in the navigation bar
	Given I call Shared Step 106194 (RPS Sign out)

	Examples:
	| Scenario Name                                                      | Retailer | LandingTab               |
	| [#169074a] Menu Links Banner - Gauge icon - shows on correct pages | RPS.LW   | LWLandingtab             |
	| [#169074b] Menu Links Banner - Gauge icon - shows on correct pages | RPS.CV   | Program Health           |
#	| [#169074c] Menu Links Banner - Gauge icon - shows on correct pages | RPS.WM   | Program Health           |
#	| [#169074d] Menu Links Banner - Gauge icon - shows on correct pages | RPS.HD   | Program Health           |
	| [#169074e] Menu Links Banner - Gauge icon - shows on correct pages | RPS.SF   | Program Health           |
#	| [#169074f] Menu Links Banner - Gauge icon - shows on correct pages | RPS.PX   | Program Health           |
	| [#169074g] Menu Links Banner - Gauge icon - shows on correct pages | RPS.TG   | Product Lookup           |
	| [#169074h] Menu Links Banner - Gauge icon - shows on correct pages | RPS.CT   | Program Health           |