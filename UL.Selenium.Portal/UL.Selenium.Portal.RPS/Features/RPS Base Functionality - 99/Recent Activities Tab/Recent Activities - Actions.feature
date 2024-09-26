@RPS
@Login
@run_RecentActivites_Actions
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

Feature: Recent Activities - Actions

@ScenarioId:9379
Scenario: [99212] Base Functionality - Recent Activities - Contact Supplier -  displays for all products
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the active tab is: <LandingTab>
	Given I click the main tab: Recent Activities
	Then I confirm the Recent Activities tab has loaded
	Then In the recent activities Page, I confirm for all products the Action column includes option: Contact Supplier
	And I call Shared Step 106194 (RPS Sign out)

	Examples:  
		| Scenario Name                                                                                      | Retailer | LandingTab               |
		| [#99212a]  Base Functionality - Recent Activities - Contact Supplier -  displays for all products  | RPS.LW   | LWLandingtab             |
		| [#99212b]  Base Functionality - Recent Activities - Contact Supplier -  displays for all products  | RPS.SF   | Program Health           |
#		| [#99212c]  Base Functionality - Recent Activities - Contact Supplier -  displays for all products  | RPS.WM   | Program Health           |
#		| [#99212d]  Base Functionality - Recent Activities - Contact Supplier -  displays for all products  | RPS.PX   | Program Health           |
		| [#99212e]  Base Functionality - Recent Activities - Contact Supplier -  displays for all products  | RPS.CV   | Program Health           |
#		| [#99212f]  Base Functionality - Recent Activities - Contact Supplier -  displays for all products  | RPS.HD   | Program Health           |


@ScenarioId:9381
Scenario: [99211] Base Functionality - Recent Activities - View Data displays for Completed products
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the active tab is: <LandingTab>
	Given I click the main tab: Recent Activities
	Then I confirm the Recent Activities tab has loaded
	And In the recent activities Page, I click the More Filters Button
	Then In the More Filters pop up, I click  General Filters from the Filter Categories column
	Then In the More Filters pop up, I select Status: Completed
	Then In the recent activities Page More Filters Popup, I Click the the Apply Filter Button
	Then In the recent activities Page, The More Filters Popup is not showing
	Then I confirm the Recent Activities page refreshes
	Then In the recent activities Page, In the Products table I confirm that all displayed results show Completed as their status
	Then In the recent activities Page, I confirm for all products the Action column includes option: View Data
	And I call Shared Step 106194 (RPS Sign out)

	Examples:  
		| Scenario Name                                                                                  | Retailer | LandingTab               |
		| [#99211a]  Base Functionality - Recent Activities - View Data displays for Completed products  | RPS.LW   | LWLandingtab             |
		| [#99211b]  Base Functionality - Recent Activities - View Data displays for Completed products  | RPS.SF   | Program Health           |
#		| [#99211c]  Base Functionality - Recent Activities - View Data displays for Completed products  | RPS.WM   | Program Health           |
#		| [#99211d]  Base Functionality - Recent Activities - View Data displays for Completed products  | RPS.PX   | Program Health           |
		| [#99211e]  Base Functionality - Recent Activities - View Data displays for Completed products  | RPS.CV   | Program Health           |
#		| [#99211f]  Base Functionality - Recent Activities - View Data displays for Completed products  | RPS.HD   | Program Health           |
		| [#99211g]  Base Functionality - Recent Activities - View Data displays for Completed products  | RPS.TG   | Program Health           |

# Removed from regression: 2024/08
@ignore
@ScenarioId:9382
Scenario: [99210] Base Functionality - Recent Activities - View Data does not display for non-completed products 
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: Franky TG User
	Then I confirm the Home tab has loaded
	Given I click the main tab: Recent Activities
	Then I confirm the Recent Activities tab has loaded
	Then I call Shared Step 106901 (More Filters - Select Status - Apply - Confirm Actions column does NOT show View Data) for status: Accepted
	Then I call Shared Step 106901 (More Filters - Select Status - Apply - Confirm Actions column does NOT show View Data) for status: Assigned
	Then I call Shared Step 106901 (More Filters - Select Status - Apply - Confirm Actions column does NOT show View Data) for status: Cancelled
	Then I call Shared Step 106901 (More Filters - Select Status - Apply - Confirm Actions column does NOT show View Data) for status: Hold
	Then I call Shared Step 106901 (More Filters - Select Status - Apply - Confirm Actions column does NOT show View Data) for status: New
	Then I call Shared Step 106901 (More Filters - Select Status - Apply - Confirm Actions column does NOT show View Data) for status: Recertification
	Then I call Shared Step 106901 (More Filters - Select Status - Apply - Confirm Actions column does NOT show View Data) for status: Release for Distribution
	Then I call Shared Step 106901 (More Filters - Select Status - Apply - Confirm Actions column does NOT show View Data) for status: Submitted
	And I call Shared Step 106194 (RPS Sign out)

@ScenarioId:9384
Scenario: [106908] Base Functionality - Recent Activities - View Data  - pop up layout
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: Franky TG User
	Given I click the main tab: Recent Activities
	Then I confirm the Recent Activities tab has loaded
	And In the recent activities Page, I click the More Filters Button
	Then In the More Filters pop up, I click  General Filters from the Filter Categories column
	Then In the More Filters pop up, I select Status: Completed
	Then In the recent activities Page More Filters Popup, I Click the the Apply Filter Button
	Then In the recent activities Page, The More Filters Popup is not showing
	Then I confirm the Recent Activities page refreshes
	Then I Click the Row actions: View Data for the first product in the Products Grid
	Then I wait for the Product Information Popup to load
	Then In the Product Infromation Popup I call shared step 109167 if there is data, and 111879 if there is no data
	Then I Close the Product Information Popup
	Then I Click the Row actions: View Data for the first product in the Products Grid
	Then I wait for the Product Information Popup to load
	And In the Product Infromation Popup I Click the 'x' Close icon
	And I wait for the Product Information Popup to dissapear
	And I call Shared Step 106194 (RPS Sign out)

@ScenarioId:9740
Scenario: [106919] Base Functionality - Recent Activities - View Data  - Product Data codes - confirm fields shown
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the active tab is: <LandingTab>
	Given I click the main tab: Recent Activities
	Then I confirm the Recent Activities tab has loaded
	And In the recent activities Page, I click the More Filters Button
	Then In the More Filters pop up, I click  General Filters from the Filter Categories column
	Then In the More Filters pop up, I select Status: Completed
	Then In the recent activities Page More Filters Popup, I Click the the Apply Filter Button
	Then In the recent activities Page, The More Filters Popup is not showing
	Then I confirm the Recent Activities page refreshes
	Then I Click the Row actions: View Data for the first product in the Products Grid
	Then I call Shared Step 109168 (Product Information pop up - Expand Product Details - confirm rows)
	And I Close the Product Information Popup
	And I call Shared Step 106194 (RPS Sign out)

	Examples:
		| Scenario Name                                                                                              | Retailer | LandingTab               |
		| [#106919a] Base Functionality - Recent Activities - View Data  - Product Data codes - confirm fields shown | RPS.LW   | LWLandingtab             |
#		| [#106919b] Base Functionality - Recent Activities - View Data  - Product Data codes - confirm fields shown | RPS.SF   | Program Health           |
#		| [#106919c] Base Functionality - Recent Activities - View Data  - Product Data codes - confirm fields shown | RPS.WM   | Program Health           |
#		| [#106919d] Base Functionality - Recent Activities - View Data  - Product Data codes - confirm fields shown | RPS.PX   | Program Health           |

# Removed from regression: 2024/08
@ignore
@ScenarioId:9741
Scenario: [106920] Base Functionality - Recent Activities - View Data  - Transportation Data - confirm fields shown 
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the active tab is: <LandingTab>
	Given I click the main tab: Recent Activities
	Then I confirm the Recent Activities tab has loaded
	And In the recent activities Page, I click the More Filters Button
	Then In the More Filters pop up, I click  General Filters from the Filter Categories column
	Then In the More Filters pop up, I select Status: Completed
	Then In the recent activities Page More Filters Popup, I Click the the Apply Filter Button
	Then In the recent activities Page, The More Filters Popup is not showing
	Then I confirm the Recent Activities page refreshes
	Then I Click the Row actions: View Data for the first product in the Products Grid
	Then I call Shared Step 109169 (Product Information pop up - Expand Transportation - confirm rows)
	And I Close the Product Information Popup
	And I call Shared Step 106194 (RPS Sign out)

	Examples:  
		| Scenario Name                                                                                                | Retailer | LandingTab               |
		| [#106920a] Base Functionality - Recent Activities - View Data  - Transportation Data - confirm fields shown  | RPS.LW   | LWLandingtab             |
#		| [#106920b] Base Functionality - Recent Activities - View Data  - Transportation Data - confirm fields shown  | RPS.SF   | Program Health           |
#		| [#106920c] Base Functionality - Recent Activities - View Data  - Transportation Data - confirm fields shown  | RPS.WM   | Program Health           |
#		| [#106920d] Base Functionality - Recent Activities - View Data  - Transportation Data - confirm fields shown  | RPS.PX   | Program Health           |

# Removed from regression: 2024/08
@ignore
@ScenarioId:9742
Scenario: [106943] Base Functionality - Recent Activities - View Data  - Storage Data - confirm fields shown 
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the active tab is: <LandingTab>
	Given I click the main tab: Recent Activities
	Then I confirm the Recent Activities tab has loaded
	And In the recent activities Page, I click the More Filters Button
	Then In the More Filters pop up, I click  General Filters from the Filter Categories column
	Then In the More Filters pop up, I select Status: Completed
	Then In the recent activities Page More Filters Popup, I Click the the Apply Filter Button
	Then In the recent activities Page, The More Filters Popup is not showing
	Then I confirm the Recent Activities page refreshes
	Then I Click the Row actions: View Data for the first product in the Products Grid
	Then I call Shared Step 109170 (Product Information pop up - Expand Storage - confirm rows)
	And I Close the Product Information Popup
	And I call Shared Step 106194 (RPS Sign out)

	Examples:  
		| Scenario Name                                                                                          | Retailer | LandingTab               |
		| [#106943a]  Base Functionality - Recent Activities - View Data  - Storage Data - confirm fields shown  | RPS.LW   | LWLandingtab             |
#		| [#106943b]  Base Functionality - Recent Activities - View Data  - Storage Data - confirm fields shown  | RPS.SF   | Program Health           |
#		| [#106943c]  Base Functionality - Recent Activities - View Data  - Storage Data - confirm fields shown  | RPS.WM   | Program Health           |
#		| [#106943d]  Base Functionality - Recent Activities - View Data  - Storage Data - confirm fields shown  | RPS.PX   | Program Health           |

# Removed from regression: 2024/08
@ignore
@ScenarioId:9743
Scenario: [106945] Base Functionality - Recent Activities - View Data  - Battery Data - confirm fields shown
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the active tab is: <LandingTab>
	Given I click the main tab: Recent Activities
	Then I confirm the Recent Activities tab has loaded
	And In the recent activities Page, I click the More Filters Button
	Then In the More Filters pop up, I click  General Filters from the Filter Categories column
	Then In the More Filters pop up, I select Status: Completed
	Then In the recent activities Page More Filters Popup, I Click the the Apply Filter Button
	Then In the recent activities Page, The More Filters Popup is not showing
	Then I confirm the Recent Activities page refreshes
	Then I Click the Row actions: View Data for the first product in the Products Grid
	Then I call Shared Step 109171 (Product Information pop up - Expand Battery - confirm rows)
	And I Close the Product Information Popup
	And I call Shared Step 106194 (RPS Sign out)

	Examples:  
		| Scenario Name                                                                                          | Retailer | LandingTab               |
		| [#106945a]  Base Functionality - Recent Activities - View Data  - Battery Data - confirm fields shown  | RPS.LW   | LWLandingtab             |
#		| [#106945b]  Base Functionality - Recent Activities - View Data  - Battery Data - confirm fields shown  | RPS.SF   | Program Health           |
#		| [#106945c]  Base Functionality - Recent Activities - View Data  - Battery Data - confirm fields shown  | RPS.WM   | Program Health           |
#		| [#106945d]  Base Functionality - Recent Activities - View Data  - Battery Data - confirm fields shown  | RPS.PX   | Program Health           |



@ScenarioId:9744
Scenario: [106947] Base Functionality - Recent Activities - View Data  - only 1 expanded data section shows
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the active tab is: <LandingTab>
	Given I click the main tab: Recent Activities
	Then I confirm the Recent Activities tab has loaded
	And In the recent activities Page, I click the More Filters Button
	Then In the More Filters pop up, I click  General Filters from the Filter Categories column
	Then In the More Filters pop up, I select Status: Completed
	Then In the recent activities Page More Filters Popup, I Click the the Apply Filter Button
	Then In the recent activities Page, The More Filters Popup is not showing
	Then I confirm the Recent Activities page refreshes
	Then I Click the Row actions: View Data for the first product in the Products Grid
	Given I Confirm that the Product Information pop up is shown
	Then I call Shared Step 109172 (Product information pop up - Only 1 section expands at a time)
	And I Close the Product Information Popup
	And I call Shared Step 106194 (RPS Sign out)

	Examples:  
		| Scenario Name                                                                                         | Retailer | LandingTab               |
		| [#106947a]  Base Functionality - Recent Activities - View Data  - only 1 expanded data section shows  | RPS.LW   | LWLandingtab             |
#		| [#106947b]  Base Functionality - Recent Activities - View Data  - only 1 expanded data section shows  | RPS.SF   | Program Health           |
#		| [#106947c]  Base Functionality - Recent Activities - View Data  - only 1 expanded data section shows  | RPS.WM   | Program Health           |
#		| [#106947d]  Base Functionality - Recent Activities - View Data  - only 1 expanded data section shows  | RPS.PX   | Program Health           |
		| [#106947e]  Base Functionality - Recent Activities - View Data  - only 1 expanded data section shows  | RPS.CV   | Program Health           |
#		| [#106947f]  Base Functionality - Recent Activities - View Data  - only 1 expanded data section shows  | RPS.HD   | Program Health           |