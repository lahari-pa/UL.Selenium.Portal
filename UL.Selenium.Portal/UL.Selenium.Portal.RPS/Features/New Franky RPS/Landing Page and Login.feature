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
@Global

Feature: Landing Page and Login

Scenario Outline: [169067] Logged in page banner - layout
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the active tab is: <LandingTab>
	#And I confirm the logged in page banner shows background color: navy blue
	#And I confirm the logged in page banner shows font color: white
	And I confirm the page heading banner shows the WERCSmart Product Suite logo and it reads : WERCSmart® Product Suite
	And I confirm the Product Suite Brand Name Logo is displayed in the top bar
	And I confirm the user displayed in the top bar matches the active logged in user
	Given I call Shared Step 106194 (RPS Sign out)

	Examples:
	| Scenario Name                             | Retailer | LandingTab               |
	| [#169067a] Logged in page banner - layout | RPS.LW   | LWLandingtab             |
	| [#169067b] Logged in page banner - layout | RPS.CV   | Program Health           |
#	| [#169067c] Logged in page banner - layout | RPS.WM   | Program Health           |
#	| [#169067d] Logged in page banner - layout | RPS.HD   | Program Health           |
	| [#169067e] Logged in page banner - layout | RPS.SF   | Program Health           |
#	| [#169067f] Logged in page banner - layout | RPS.PX   | Program Health           |
	| [#169067g] Logged in page banner - layout | RPS.TG   | Product Lookup           |
	| [#169067h] Logged in page banner - layout | RPS.CT   | Program Health           |

Scenario Outline: [169076] UL Solution logo redirects to Home tab
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the active tab is: <LandingTab>
	Then I click the main tab: Dashboard
	Then I confirm the Dashboard tab has loaded
	Then I call Shared Step 111976 (Click UL Solutions Logo - Confirm Home page shown)
	Then I confirm the active tab is: <LandingTab>
	Then I click the main tab: Recent Activities
	Then I confirm the Recent Activities tab has loaded
	Then I call Shared Step 111976 (Click UL Solutions Logo - Confirm Home page shown)
	Then I confirm the active tab is: <LandingTab>
	Then I click the main tab: Product Lookup
	Then I confirm the Product Lookup tab has loaded
	Then I call Shared Step 111976 (Click UL Solutions Logo - Confirm Home page shown)
	Then I confirm the active tab is: <LandingTab>
	Given I call Shared Step 106194 (RPS Sign out)

	Examples:
	| Scenario Name                                     | Retailer | LandingTab               |
	| [#169076a] UL Solution logo redirects to Home tab | RPS.LW   | LWLandingtab             |
	| [#169076b] UL Solution logo redirects to Home tab | RPS.CV   | Program Health           |
#	| [#169076c] UL Solution logo redirects to Home tab | RPS.WM   | Program Health           |
#	| [#169076d] UL Solution logo redirects to Home tab | RPS.HD   | Program Health           |
	| [#169076e] UL Solution logo redirects to Home tab | RPS.SF   | Program Health           |
#	| [#169076f] UL Solution logo redirects to Home tab | RPS.PX   | Program Health           |
	| [#169076g] UL Solution logo redirects to Home tab | RPS.TG   | Product Lookup           |
	| [#169076h] UL Solution logo redirects to Home tab | RPS.CT   | Program Health           |

Scenario Outline: [169078] Log Out
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the active tab is: <LandingTab>
	And I confirm the user displayed in the top bar matches the active logged in user
	Then I click the user button in the top bar
	And I confirm the 'Sign Out' dropdown option is displayed under the user button
	Then I click the user button in the top bar
	Then I confirm the active tab is: <LandingTab>
	Given I call Shared Step 106194 (RPS Sign out)
	Then I confirm the Landing Page has loaded

	Examples:
	| Scenario Name      | Retailer | LandingTab               |
	| [#169078a] Log Out | RPS.LW   | LWLandingtab             |
	| [#169078b] Log Out | RPS.CV   | Program Health           |
#	| [#169078c] Log Out | RPS.WM   | Program Health           |
#	| [#169078d] Log Out | RPS.HD   | Program Health           |
	| [#169078e] Log Out | RPS.SF   | Program Health           |
#	| [#169078f] Log Out | RPS.PX   | Program Health           |
	| [#169078g] Log Out | RPS.TG   | Product Lookup           |
	| [#169078h] Log Out | RPS.CT   | Program Health           |

Scenario Outline: [169079] UL Logo
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the active tab is: <LandingTab>
	Then I confirm the UL Logo is displayed in the top bar
	Then I click the UL Logo in the top bar
	Then I confirm the active tab is: <LandingTab>
	Given I call Shared Step 106194 (RPS Sign out)

	Examples:
	| Scenario Name      | Retailer | LandingTab               |
	| [#169079a] UL Logo | RPS.LW   | LWLandingtab             |
	| [#169079b] UL Logo | RPS.CV   | Program Health           |
#	| [#169079c] UL Logo | RPS.WM   | Program Health           |
#	| [#169079d] UL Logo | RPS.HD   | Program Health           |
	| [#169079e] UL Logo | RPS.SF   | Program Health           |
#	| [#169079f] UL Logo | RPS.PX   | Program Health           |
	| [#169079g] UL Logo | RPS.TG   | Product Lookup           |
	| [#169079h] UL Logo | RPS.CT   | Program Health           |

# Removed from regression: 2024/08
@ignore
Scenario: [70243] Landing Page
	And I confirm the logged in page banner shows background color: red
	Then I verify that there is a Sign In Link in the upper-right corner
	And I verify that there is a UL Logo in the upper-right corner
	And I verify that there is a section titled Good business with I'd like to learn more button
	And I verify that there is a section titled Instant Access displaying a graph
	And I verify that under offerings there is a section for UL Audit with 'request more information' button
	And I verify that under offerings there is a section for UL PurView with 'request more information' button
	And I verify that under offerings there is a section for Item Scan with 'request more information' button
	And I verify that there is a section titled Let's talk with I'd like to learn more button
	And I verify that the following items are displayed in the Landing Page Footer:
		| Item                    |
		| UL Logo                 |
		| About UL WERCSmart Link |
		| Contact Us Link         |
		| Sign In button          |

# Removed from regression: 2024/08
@ignore
Scenario: [70244] I'd Like to Learn More
	And I click on the "I'd like to learn more" button in the Good business section
	And I verify that a tab opens with url: https://www.ul.com/services/portfolios/chemical-data-management
	Then I close the tab with url: https://www.ul.com/services/portfolios/chemical-data-management
	And I verify that the I'd like to learn more link for section: Let's talk has a subject line containing: Retail Product Suite

# Removed from regression: 2024/08
@ignore
Scenario: [70246] Request More Information
	Given I verify that the Request more information link for section: UL Audit has a subject line containing: I would like to learn more about UL Audit
	And I verify that the Request more information link for section: UL PurView has a subject line containing: I would like to learn more about UL Purview
	And I verify that the Request more information link for section: Item Scan has a subject line containing: I would like to learn more about UL Item Scan

# Removed from regression: 2024/08
@ignore
Scenario: [70247] Footer
	And I verify that the following items are displayed in the Landing Page Footer:
		| Item                    |
		| About UL WERCSmart Link |
		| Contact Us Link         |
		| Sign In button          |
	Then I confirm the footer shows background color: grey
	And I click the footer link: About UL WERCSmart
	And I verify that a tab opens with url: https://ulwercsmart.com/
	Then I close the tab with url: https://ulwercsmart.com/
	And I verify that the Contact Us button in the footer is a valid email link

Scenario Outline: [169650] Closing browser logs user out
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the active tab is: <LandingTab>
	Then I close the browser, all instances
	Then I open a new browser window
	Then I navigate to the RPS landing page
	And I confirm the Landing Page has loaded

	Examples:
	| Scenario Name                            | Retailer | LandingTab               |
	| [#169650a] Closing browser logs user out | RPS.LW   | LWLandingtab             |
	| [#169650b] Closing browser logs user out | RPS.CV   | Program Health           |
#	| [#169650c] Closing browser logs user out | RPS.WM   | Program Health           |
#	| [#169650d] Closing browser logs user out | RPS.HD   | Program Health           |
	| [#169650e] Closing browser logs user out | RPS.SF   | Program Health           |
#	| [#169650f] Closing browser logs user out | RPS.PX   | Program Health           |
	| [#169650g] Closing browser logs user out | RPS.TG   | Product Lookup           |
	| [#169650h] Closing browser logs user out | RPS.CT   | Program Health           |

Scenario: [73218] Sign In / Sign Out
	Given I save TReVor test user: RPS.CV to Context as the active user
	Given I confirm the Landing Page has loaded
	Given I enter incorrect credentials for User name and Password fields
	Given I click 'Log in'
	Then I confirm the error is displayed indicating Account does not exist or password is incorrect
	Given I enter the User Name for the active user
	And I enter an incorrect Password
	Given I click 'Log in'
	Then I confirm the error is displayed indicating Account does not exist or password is incorrect
	Given I enter the Password for the active user
	Given I click 'Log in'
	#Then I confirm the Home tab has loaded
	Given I confirm the user displayed in the top bar matches the active logged in user
	And I click the user button in the top bar
	And I click 'Sign Out' under the user button
	Then I confirm the Landing Page has loaded

Scenario Outline: [169651] Base Functionality - Automatic sign out
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the active tab is: <LandingTab>
	Then I wait for 20 minutes
	Then I refresh the web page
	Then I confirm the Landing Page has loaded

	Examples:
	| Scenario Name                                      | Retailer | LandingTab               |
	| [#169651a] Base Functionality - Automatic sign out | RPS.LW   | LWLandingtab             |
	| [#169651b] Base Functionality - Automatic sign out | RPS.CV   | Program Health           |
#	| [#169651c] Base Functionality - Automatic sign out | RPS.WM   | Program Health           |
#	| [#169651d] Base Functionality - Automatic sign out | RPS.HD   | Program Health           |
	| [#169651e] Base Functionality - Automatic sign out | RPS.SF   | Program Health           |
#	| [#169651f] Base Functionality - Automatic sign out | RPS.PX   | Program Health           |
	| [#169651g] Base Functionality - Automatic sign out | RPS.TG   | Product Lookup           |
	| [#169651h] Base Functionality - Automatic sign out | RPS.CT   | Program Health           |

Scenario Outline: [111866] Verify Drum Log tab does not display
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the active tab is: <LandingTab>
	And I confirm the following tabs are not displayed:
		| Link     |
		| Drum Log |
	Then I cannot change URL to access Drumlog page
	Given I call Shared Step 106194 (RPS Sign out)
	# Repeat for Home Depot and RPS.99 when added
	Examples:
	| Scenario Name                                   | Retailer | LandingTab           |
	| [#111866a] Verify Drum Log tab does not display | RPS.CV   | Program Health       |
#	| [#111866b] Verify Drum Log tab does not display | RPS.HD   | Program Health       |
#	| [#111866c] Verify Drum Log tab does not display | RPS.99   | Program Health       |