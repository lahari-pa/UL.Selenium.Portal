@RPS
@Login
@run_HomeTab
@LandingPage
@Home
@Shared
@Navigation
@Dashboard
@RecentActivities 
@ProductLookUP
@TopBar
@ProductInformation
@run_DrumgLogLayout
@DrumLog
@HelpAndSupport


Feature: Lowe's

Scenario Outline: [108078] Lowe's functionality - Menu Links Banner - options
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: RPS.LW
	Given  I confirm the following tabs are displayed:
| Link                    |
| Program Health          |
| Dashboard               |
| Recent Activities       |
| Web Viewers             |
| ItemSync                |
| Product Lookup          |
| Help & Support          |
   Given I call Shared Step 106194 (RPS Sign out)

Scenario Outline: [109134] Lowe's - Menu Links Banner - Gauge icon - shows on correct pages
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: RPS.LW
	Then I confirm the Home tab has loaded
	And I confirm the Gauge button is displayed in the navigation bar
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
	And I confirm the Gauge button is displayed in the navigation bar
	Given I call Shared Step 106194 (RPS Sign out)


Scenario Outline: [108080] Lowe's functionality - Menu Links Banner - active page/ heading background color
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: RPS.LW
	Then I confirm the Home tab has loaded
	And I Confirm that the tab: Program Health shows in a grey highlight indicating it is active
	Then I click the main tab: Dashboard
	Then I confirm the Dashboard tab has loaded
	Then I confirm the active tab is: Dashboard
	And I Confirm that the tab: Dashboard shows in a grey highlight indicating it is active
	And I Confirm that the tab: Program Health is  shown in white highlight indicating it is inactive
	Then I click the main tab: Recent Activities
	Then I confirm the Recent Activities tab has loaded
	Then I confirm the active tab is: Recent Activities
	And I Confirm that the tab: Recent Activities shows in a grey highlight indicating it is active
	And I Confirm that the tab: Dashboard is  shown in white highlight indicating it is inactive
	Then I click the main tab: Product Lookup
	Then I confirm the Product Lookup tab has loaded
	Then I confirm the active tab is: Product Lookup
	And I Confirm that the tab: Product Lookup shows in a grey highlight indicating it is active
	And I Confirm that the tab: Recent Activities is  shown in white highlight indicating it is inactive
	Then I click the main tab: Web Viewers
	And I Confirm that the tab: Product Lookup shows in a grey highlight indicating it is active
	And I confirm there is a drop down menu below the navigation tab: Web Viewers
	Then I click the main tab: Web Viewers
	And I confirm there is not a drop down menu below the navigation tab: Web Viewers
	Then I click the main tab: Help & Support
	And I Confirm the Help & Support Popup is displayed
	Then In the Help & Support Popup I click the X Icon
	And I Confirm the Help & Support Popup is not displayed
	And I Confirm that the tab: Product Lookup shows in a grey highlight indicating it is active
	Given I call Shared Step 106194 (RPS Sign out)

Scenario Outline: [108082] Lowe's Functionality - Dashboard page - layout
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: RPS.LW
	Then I confirm the Home tab has loaded
	Then I click the main tab: Dashboard
	Then I confirm the Dashboard tab has loaded
	Given I confirm the top menu bar is displayed with the logged in username
	And I confirm the navigation menu bar is displayed below the top bar
	And I confirm there are a total of 8 widgets displayed in a 2 x 4 grid
	Then I confirm the following Widgets are displayed:
		| Widget                                        |
		| Lowes Haz Code by RU                          |
		| EPA/RCRA Waste Code by RU Category            |
		| RU Category by Supplier                       |
		| RU Category by RU                             |
		| Product Recertification Status                |
		| Product Status                                |   
		| Product Hold Status                           |
		| Supplier Subscription Status                  |
    Then I confirm there is no page footer shown
	Given I call Shared Step 106194 (RPS Sign out)


	
Scenario Outline: [108094] Lowe's Dashboard - Resetting the Dashboard
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: RPS.LW
	Then I confirm the Home tab has loaded
	Then I click the main tab: Dashboard
	Then I confirm the following Widgets are displayed:
		| Widget                                        |
		| Lowes Haz Code by RU                          |
		| EPA/RCRA Waste Code by RU Category            |
		| RU Category by Supplier                       |
		| RU Category by RU                             |
		| Product Recertification Status                |
		| Product Status                                |   
		| Product Hold Status                           |
 		| Supplier Subscription Status                  |
    Then I call Shared Step 106605 (Dashboard - Remove Widget) for widget: Lowes Haz Code by RU 
	Then I call Shared Step 106605 (Dashboard - Remove Widget) for widget: EPA/RCRA Waste Code by RU Category
	Then I click the Gauge button in the navigation bar
	Then I confirm that the the options below the gauge icon are as follows:
		| Options                                       |
		| Lowes Haz Code by RU                          |
		| EPA/RCRA Waste Code by RU Category            |
		| Reset Dashboard                               |
		| Refresh All Widgets                           |
    Then I click the Reset Dashboard dropdown option below the navigation bar Gauge button
	Then I confirm the Dashboard tab has loaded
	Then I confirm the following Widgets are displayed:
		| Widget                                        |
		| Lowes Haz Code by RU                          |
		| EPA/RCRA Waste Code by RU Category            |
		| RU Category by Supplier                       |
		| RU Category by RU                             |
		| Product Recertification Status                |
		| Product Status                                |   
		| Product Hold Status                           |
 		| Supplier Subscription Status                  |
	Given I call Shared Step 106194 (RPS Sign out)


Scenario Outline: [108919] Lowe's Dashboard - Refresh all widget
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: RPS.LW
	Then I confirm the Home tab has loaded
	Then I click the main tab: Dashboard
	Then For the Lowes Haz Code by RU widget, I save the current titles as: LowesHazcodebyRU1 and check that when I click on the section: <first> that the titles change
    Then For the EPA/RCRA Waste Code by RU Category widget, I save the current titles as: RCRAbyRUCategory1 and check that when I click on the section: <first> that the titles change
    Then For the RU Category by Supplier widget, I save the current titles as: RUCategorybySupplier1 and check that when I click on the section: <first> that the titles change
    Then For the RU Category by RU widget, I save the current titles as: RUCategorybyRU1 and check that when I click on the section: <first> that the titles change
    Then For the Product Recertification Status widget, I save the current titles as: ProductRecertificationStatus1 and check that when I click on the section: <first> that the titles change
    Then For the Product Status widget, I save the current titles as: ProductStatus1 and check that when I click on the section: <first> that the titles change
    Then For the Product Hold Status widget, I save the current titles as: ProductHoldStatus1 and check that when I click on the section: <first> that the titles change
    Then For the Widget: Supplier Subscription Status I select the section with title: <first>
	Then I Check that for widget Supplier Subscription Status the supplier list is showing 
    Given I click the Gauge button in the navigation bar 
    Given I click the Refresh All Widgets dropdown option below the navigation bar Gauge button
    Then I confirm the Dashboard tab has loaded
    Then I confirm the following Widgets are displayed:
		| Widget                                        |
		| Lowes Haz Code by RU                          |
		| EPA/RCRA Waste Code by RU Category            |
		| RU Category by Supplier                       |
		| RU Category by RU                             |
		| Product Recertification Status                |
		| Product Status                                |   
		| Product Hold Status                           |
 		| Supplier Subscription Status                  |
    Then I Check that the current titles being displayed for widget: Lowes Haz Code by RU are the same as those saved as: LowesHazcodebyRU1
    Then I Check that the current titles being displayed for widget: EPA/RCRA Waste Code by RU Category are the same as those saved as: RCRAbyRUCategory1
	Then I Check that the current titles being displayed for widget: RU Category by Supplier are the same as those saved as: RUCategorybySupplier1
    Then I Check that the current titles being displayed for widget: RU Category by RU are the same as those saved as: RUCategorybyRU1
    Then I Check that the current titles being displayed for widget: Product Recertification Status are the same as those saved as: ProductRecertificationStatus1
    Then I Check that the current titles being displayed for widget: Product Status are the same as those saved as: ProductStatus1
    Then I Check that the current titles being displayed for widget: Product Hold Status are the same as those saved as: ProductHoldStatus1
    Then I Check that for widget Supplier Subscription Status the supplier list is not showing
    Given I call Shared Step 106194 (RPS Sign out)


Scenario Outline: [108091] Lowe's Removing Widgets from the Dashboard and re-adding 
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: RPS.LW
	Then I confirm the Home tab has loaded
	Given I click the main tab: Dashboard
	Then I confirm the Dashboard tab has loaded
	Then I confirm the following Widgets are displayed:
		| Widget                                        |
		| Lowes Haz Code by RU                          |
		| EPA/RCRA Waste Code by RU Category            |
		| RU Category by Supplier                       |
		| RU Category by RU                             |
		| Product Recertification Status                |
		| Product Status                                |   
		| Product Hold Status                           |
 		| Supplier Subscription Status                  |
	Then I call Shared Step 106605 (Dashboard - Remove Widget) for widget: Lowes Haz Code by RU 
	Then I call Shared Step 106623 (Dashboard - Gauge - Re-add removed widget) for widget: Lowes Haz Code by RU 
	Then I call Shared Step 106605 (Dashboard - Remove Widget) for widget: EPA/RCRA Waste Code by RU Category
	Then I call Shared Step 106623 (Dashboard - Gauge - Re-add removed widget) for widget: EPA/RCRA Waste Code by RU Category
	Then I call Shared Step 106605 (Dashboard - Remove Widget) for widget: RU Category by Supplier
	Then I call Shared Step 106623 (Dashboard - Gauge - Re-add removed widget) for widget: RU Category by Supplier
	Then I call Shared Step 106605 (Dashboard - Remove Widget) for widget: RU Category by RU
	Then I call Shared Step 106623 (Dashboard - Gauge - Re-add removed widget) for widget: RU Category by RU
	Then I call Shared Step 106605 (Dashboard - Remove Widget) for widget: Product Recertification Status
	Then I call Shared Step 106623 (Dashboard - Gauge - Re-add removed widget) for widget: Product Recertification Status
	Then I call Shared Step 106605 (Dashboard - Remove Widget) for widget: Product Status
	Then I call Shared Step 106623 (Dashboard - Gauge - Re-add removed widget) for widget: Product Status
	Then I call Shared Step 106605 (Dashboard - Remove Widget) for widget: Product Hold Status
	Then I call Shared Step 106623 (Dashboard - Gauge - Re-add removed widget) for widget: Product Hold Status
	Then I call Shared Step 106605 (Dashboard - Remove Widget) for widget: Supplier Subscription Status
	Then I call Shared Step 106623 (Dashboard - Gauge - Re-add removed widget) for widget: Supplier Subscription Status
	Then I call Shared Step 54484 (Dashboard - Gauge - Reset Dashboard - confrim page refreshes)
	Given I call Shared Step 106194 (RPS Sign out)


Scenario Outline: [108090] Lowe's Hazcode by RU Chart 
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: RPS.LW
	Then I confirm the Home tab has loaded
	Given I click the main tab: Dashboard
	Then I confirm the Dashboard tab has loaded
	Then I confirm the following Widgets are displayed:
		| Widget                       |
		| Lowes Haz Code by RU         |
	Then I Confirm that the Graph for the widget: Lowes Haz Code by RU is a: Bar Graph
	Then In the Lowes Haz Code by RU widget, I confirm that a legend is not shown
	Then I call Shared Step 70474 (Verify Chart functionality) for widget: Lowes Haz Code by RU
	Then I call Shared Step 70484 (Chart Drill-down Export) for widget: Lowes Haz Code by RU
	And I call Shared Step 106194 (RPS Sign out)

Scenario Outline: [109226] Lowe's - Dashboard - Lowes Hazcode by RU Chart - Drilled down - PRODUCT INFORMATION
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: RPS.LW
	Then I confirm the Home tab has loaded
	Given I click the main tab: Dashboard
	Then I confirm the Dashboard tab has loaded
	Then I confirm the following Widgets are displayed:
		| Widget                              |
		| Lowes Haz Code by RU                |
    Then For the Lowes Haz Code by RU widget, I save the current titles as: LowesHazcodebyRU1 and check that when I click on the section: <first> that the titles change
	Then For the Lowes Haz Code by RU widget, I save the current titles as: LowesHazcodebyRU2 and check that when I click on the section: <first> that the products data view is seen.
	Then I open the Product Information popup for products in the Product list of widget: Lowes Haz Code by RU until one has enough data
	Then I call Shared Step 109167 (Product Information pop up - layout verification)
	Then I call Shared Step 109168 (Product Information pop up - Expand Product Details - confirm rows)
	Then I call Shared Step 109169 (Product Information pop up - Expand Transportation - confirm rows)
	Then I call Shared Step 109170 (Product Information pop up - Expand Storage - confirm rows)
	Then I call Shared Step 109171 (Product Information pop up - Expand Battery - confirm rows)
	Then I call Shared Step 109172 (Product information pop up - Only 1 section expands at a time)
	And I call Shared Step 106194 (RPS Sign out)

Scenario Outline: [168782] Lowe's - Recent Activities - Export 
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: RPS.LW
	Then I confirm the Home tab has loaded
	Given I click the main tab: Recent Activities
	Then I confirm the Recent Activities tab has loaded
	Then I confirm the active tab is: Recent Activities
	Then In the recent activities Page, I save all the Results to context as: RecentProductsGridResults1
	Then I call Shared Step 146627 (Recent Activities - Export - Open File)
    Then I check that the file saved as: recentactivitiesfile contains the following column headings:
| Heading                   |
| Product Name              |
| UPC Number                |
| Product Number            |
| Supplier Name             |
| Status                    |
| Turnaround Time           |
| Most Recent Activity      |
| Reason                    |
| Packaging Type            |
| Packaging Size            |


   #Step that checks the cvs file for data in products grid
   Then In the recent activities Page, I confirm the Products shown in the export file saved as: recentactivitiesfile  match the products saved as: RecentProductsGridResults1
   Then I delete the file saved as recentactivitiesfile
   And I call Shared Step 106194 (RPS Sign out)