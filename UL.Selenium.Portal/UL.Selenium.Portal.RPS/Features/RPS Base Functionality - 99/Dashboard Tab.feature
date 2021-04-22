@RPS
@Login
@run_DashboardTab
@LandingPage
@Home
@Shared
@TopBar
@Navigation
@ProductInformation
@ProductLookUP
@Dashboard


Feature: Dashboard Tab

@ScenarioId:6631
Scenario: [106525] Base Functionality - Dashboard page - layout
Given I call Shared Step 104950 (RPS Login - Base functionality) for TReVor account: RPS.99
Then I confirm the Home tab has loaded
Given I click the tab: Dashboard
And I confirm the active tab is: Dashboard
Then I confirm the Dashboard tab has loaded
Given I confirm the top menu bar is displayed with the logged in username
And I confirm the navigation menu bar is displayed below the top bar
And I confirm there are a total of 8 widgets displayed in a 2 x 4 grid
Then I confirm the following Widgets are displayed:
| Widget                         |
| Generic Bucket Code by RU      |
| RCRA by RU Category            |
| RU Category by Supplier        |
| RU Category by RU              |
| Product Recertification Status |
| Product Status                 |
| Product Hold Status            |
| Supplier Subscription Status   |
Then I confirm there is no page footer shown

@ScenarioId:6632
Scenario: [70322] Base Functionality - Dashboard - Product Status Chart - ticket open download file missing labels - not being fixed in Azure release
Given I call Shared Step 104950 (RPS Login - Base functionality) for TReVor account: RPS.99
Then I confirm the Home tab has loaded
Given I click the tab: Dashboard
Then I confirm the Dashboard tab has loaded
Then I confirm the following Widgets are displayed:
| Widget         |
| Product Status |
Then I Confirm that the Graph for the widget: Product Status is a: Pie Chart
Then In the Product Status widget, I confirm that a legend is shown
Then I call Shared Step 70474 (Verify Chart functionality) for widget: Product Status
Then I call Shared Step 70484 (Chart Drill-down Export) for widget: Product Status
Then I call Shared Step 108597 (Widget data view - Contact Supplier - email verification) for widget: Product Status
And I call Shared Step 106194 (RPS Sign out)

@ScenarioId:6634
Scenario: [70323] Base Functionality - Dashboard - Product Hold Status Chart - Server error on export
Given I call Shared Step 104950 (RPS Login - Base functionality) for TReVor account: RPS.99
Then I confirm the Home tab has loaded
Given I click the tab: Dashboard
Then I confirm the Dashboard tab has loaded
Then I confirm the following Widgets are displayed:
| Widget         |
| Product Hold Status |
Then I Confirm that the Graph for the widget: Product Hold Status is a: Pie Chart
Then In the Product Hold Status widget, I confirm that a legend is shown
Then I call Shared Step 70474 (Verify Chart functionality) for widget: Product Hold Status
Then I call Shared Step 70484 (Chart Drill-down Export) for widget: Product Hold Status
Then I call Shared Step 108597 (Widget data view - Contact Supplier - email verification) for widget: Product Hold Status
And I call Shared Step 106194 (RPS Sign out)

@ScenarioId:6635
Scenario: [70324] Base Functionality - Dashboard - Supplier Subscription Status Chart - has open ticket not in scope for Azure
Given I call Shared Step 104950 (RPS Login - Base functionality) for TReVor account: RPS.99
Then I confirm the Home tab has loaded
Given I click the tab: Dashboard
Then I confirm the Dashboard tab has loaded
Then I confirm the following Widgets are displayed:
| Widget                       |
| Supplier Subscription Status |
Then I Confirm that the Graph for the widget: Supplier Subscription Status is a: Pie Chart
Then In the Supplier Subscription Status widget, I confirm that a legend is not shown
Then I call Shared Step 70474 (Verify Chart functionality) for widget: Supplier Subscription Status
Then I call Shared Step 70484 (Chart Drill-down Export) for widget: Supplier Subscription Status
And I call Shared Step 106194 (RPS Sign out)

@ScenarioId:6641
Scenario: [72760] Dashboard - Refresh all widget - has open ticket - not in scope for Azure
Given I call Shared Step 104950 (RPS Login - Base functionality) for TReVor account: RPS.99
Then I confirm the Home tab has loaded
Given I click the tab: Dashboard
Then I confirm the Dashboard tab has loaded
Then I confirm the following Widgets are displayed:
| Widget                         |
| Generic Bucket Code by RU      |
| RCRA by RU Category            |
| RU Category by Supplier        |
| RU Category by RU              |
| Product Recertification Status |
| Product Status                 |
| Product Hold Status            |
| Supplier Subscription Status   |
Then For the Generic Bucket Code by RU widget, I save the current titles as: GenericBucketCodebyRU1 and check that when I click on the section: <first> that the titles change
Then For the RCRA by RU Category widget, I save the current titles as: RCRAbyRUCategory1 and check that when I click on the section: <first> that the titles change
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
| Widget                         |
| Generic Bucket Code by RU      |
| RCRA by RU Category            |
| RU Category by Supplier        |
| RU Category by RU              |
| Product Recertification Status |
| Product Status                 |
| Product Hold Status            |
| Supplier Subscription Status   |
Then I Check that the current titles being displayed for widget: Generic Bucket Code by RU are the same as those saved as: GenericBucketCodebyRU1
Then I Check that the current titles being displayed for widget: RCRA by RU Category are the same as those saved as: RCRAbyRUCategory1
Then I Check that the current titles being displayed for widget: RU Category by Supplier are the same as those saved as: RUCategorybySupplier1
Then I Check that the current titles being displayed for widget: RU Category by RU are the same as those saved as: RUCategorybyRU1
Then I Check that the current titles being displayed for widget: Product Recertification Status are the same as those saved as: ProductRecertificationStatus1
Then I Check that the current titles being displayed for widget: Product Status are the same as those saved as: ProductStatus1
Then I Check that the current titles being displayed for widget: Product Hold Status are the same as those saved as: ProductHoldStatus1
Then I Check that for widget Supplier Subscription Status the supplier list is not showing
Given I call Shared Step 106194 (RPS Sign out)

#73078 Can not be fully automated to will need manual review for email checks.
@ScenarioId:6649
@tfs_design
Scenario: [73078] Base Functionality - Dashboard - Supplier Subscription Status Chart data
Given I call Shared Step 104950 (RPS Login - Base functionality) for TReVor account: RPS.99
Then I confirm the Home tab has loaded
Given I click the tab: Dashboard
Then I confirm the Dashboard tab has loaded
Then I confirm the following Widgets are displayed:
| Widget                         |
| Supplier Subscription Status   |
Then For the Supplier Subscription Status widget, I save the current titles as: SupplierSubscriptionStatusTitles1 and check that when I click on the section: Subscribed Suppliers that the supplier list view is seen.
Then I Check that for the widget Supplier Subscription Status, the Suppliers List shows the Following headings:
| Headers  |
| Supplier |
| Contact  |
| E-Mail   | 
#Below step could be useful how to have a seperate color in the report. 
Then END OF AUTOMATION: TEST CASE NEEDS MANUAL COMPLETION
Given I call Shared Step 106194 (RPS Sign out)


@ScenarioId:6662
Scenario: [73311] Base Functionality - Dashboard - Print functionality works with one chart
Given I call Shared Step 104950 (RPS Login - Base functionality) for TReVor account: RPS.99
Then I confirm the Home tab has loaded
Given I click the tab: Dashboard
Then I confirm the Dashboard tab has loaded
Then I call Shared Step 106605 (Dashboard - Remove Widget) for widget: RCRA by RU Category
Then I call Shared Step 106605 (Dashboard - Remove Widget) for widget: RU Category by Supplier
Then I call Shared Step 106605 (Dashboard - Remove Widget) for widget: RU Category by RU 
Then I call Shared Step 106605 (Dashboard - Remove Widget) for widget: Product Recertification Status
Then I call Shared Step 106605 (Dashboard - Remove Widget) for widget: Product Status
Then I call Shared Step 106605 (Dashboard - Remove Widget) for widget: Product Hold Status
Then I call Shared Step 106605 (Dashboard - Remove Widget) for widget: Supplier Subscription Status
#Issue with automating the print dialogue
#Print Check: Last chart click the hamburger icon and click print chart. **Confirom print dialogue is open then close.**
Then I call Shared Step 54484 (Dashboard - Gauge - Reset Dashboard - confrim page refreshes)
Then In the Dashboard page, I confirm all widgets are shown correctly in their original order:
| Widget                         |
| Generic Bucket Code by RU      |
| RCRA by RU Category            |
| RU Category by Supplier        |
| RU Category by RU              |
| Product Recertification Status |
| Product Status                 |
| Product Hold Status            |
| Supplier Subscription Status   |
Given I call Shared Step 106194 (RPS Sign out)

@ScenarioId:6664
Scenario: [74214] Base Functionality - Dashboard - Able to resize chart when there is only one
Given I call Shared Step 104950 (RPS Login - Base functionality) for TReVor account: RPS.99
Then I confirm the Home tab has loaded
Given I click the tab: Dashboard
Then I confirm the Dashboard tab has loaded
Then I call Shared Step 106605 (Dashboard - Remove Widget) for widget: RCRA by RU Category
Then I call Shared Step 106605 (Dashboard - Remove Widget) for widget: RU Category by Supplier
Then I call Shared Step 106605 (Dashboard - Remove Widget) for widget: RU Category by RU 
Then I call Shared Step 106605 (Dashboard - Remove Widget) for widget: Product Recertification Status
Then I call Shared Step 106605 (Dashboard - Remove Widget) for widget: Product Status
Then I call Shared Step 106605 (Dashboard - Remove Widget) for widget: Product Hold Status
Then I call Shared Step 106605 (Dashboard - Remove Widget) for widget: Supplier Subscription Status
#drag down for resize should work for all widget?
#Then Drag test Generic Bucket Code by RU

@ScenarioId:6665
Scenario: [104896] Base Functionality - Dashboard - Dashboard - Export - Shows data for chart/graph shown
Given I call Shared Step 104950 (RPS Login - Base functionality) for TReVor account: RPS.99
Then I confirm the Home tab has loaded
Given I click the tab: Dashboard
Then I confirm the Dashboard tab has loaded
Then I confirm the following Widgets are displayed:
| Widget                    |
| Generic Bucket Code by RU |
Then I call Shared Step 70484 (Chart Drill-down Export) for widget: Generic Bucket Code by RU

@ScenarioId:6666
Scenario: [72574] Base Functionality - Dashboard - URL does not show # - has IE11 staging ticket
Given I call Shared Step 104950 (RPS Login - Base functionality) for TReVor account: RPS.99
Then I confirm the Home tab has loaded
Given I click the tab: Dashboard
Then I confirm the Dashboard tab has loaded
Then I confirm the following Widgets are displayed:
| Widget                    |
| Generic Bucket Code by RU |
Then For the Generic Bucket Code by RU widget, I save the current titles as: GenericBucketCodebyRU1 and check that when I click on the section: <first> that the titles change
And For the Widget: Generic Bucket Code by RU I select the section with title: <first>
Then I wait for the all widgets to finish loading
Then I confirm Product content is displayed for the widget: Generic Bucket Code by RU
And For the widget that has title: Generic Bucket Code by RU, I click the back button in the Products List and confirm a graph is displayed
Then In the URL area of the browser page, I confirm that the URL does not contain a #
Given I call Shared Step 106194 (RPS Sign out)

@ScenarioId:6667
Scenario: [106590] Removing Widgets from the Dashboard and re-adding - has open ticket - not in scope for Azure
Given I call Shared Step 104950 (RPS Login - Base functionality) for TReVor account: RPS.99
Then I confirm the Home tab has loaded
Given I click the tab: Dashboard
Then I confirm the Dashboard tab has loaded
Then I confirm the following Widgets are displayed:
| Widget                         |
| Generic Bucket Code by RU      |
| RCRA by RU Category            |
| RU Category by Supplier        |
| RU Category by RU              |
| Product Recertification Status |
| Product Status                 |
| Product Hold Status            |
| Supplier Subscription Status   |
Then I call Shared Step 106605 (Dashboard - Remove Widget) for widget: Generic Bucket Code by RU 
Then I call Shared Step 106623 (Dashboard - Gauge - Re-add removed widget) for widget: Generic Bucket Code by RU 
Then I call Shared Step 106605 (Dashboard - Remove Widget) for widget: RCRA by RU Category
Then I call Shared Step 106623 (Dashboard - Gauge - Re-add removed widget) for widget: RCRA by RU Category
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

@ScenarioId:6668
Scenario: [106592] Resetting the Dashboard
Given I call Shared Step 104950 (RPS Login - Base functionality) for TReVor account: RPS.99
Then I confirm the Home tab has loaded
Given I click the tab: Dashboard
Then I confirm the Dashboard tab has loaded
Then I confirm the following Widgets are displayed:
| Widget                         |
| Generic Bucket Code by RU      |
| RCRA by RU Category            |
| RU Category by Supplier        |
| RU Category by RU              |
| Product Recertification Status |
| Product Status                 |
| Product Hold Status            |
| Supplier Subscription Status   |
Then In the Dashboard page, I confirm all widgets are shown correctly in their original order:
| Widget                         |
| Generic Bucket Code by RU      |
| RCRA by RU Category            |
| RU Category by Supplier        |
| RU Category by RU              |
| Product Recertification Status |
| Product Status                 |
| Product Hold Status            |
| Supplier Subscription Status   |
Then I call Shared Step 106605 (Dashboard - Remove Widget) for widget: Generic Bucket Code by RU 
Then I call Shared Step 106605 (Dashboard - Remove Widget) for widget: RCRA by RU Category
Then I click the Gauge button in the navigation bar
Then I confirm that the the options below the gauge icon are as follows:
| Options                   |
| RCRA by RU Category       |
| Generic Bucket Code by RU |
| Reset Dashboard           |
| Refresh All Widgets       |
Then I call Shared Step 54484 (Dashboard - Gauge - Reset Dashboard - confrim page refreshes)
Then In the Dashboard page, I confirm all widgets are shown correctly in their original order:
| Widget                         |
| Generic Bucket Code by RU      |
| RCRA by RU Category            |
| RU Category by Supplier        |
| RU Category by RU              |
| Product Recertification Status |
| Product Status                 |
| Product Hold Status            |
| Supplier Subscription Status   |
Given I call Shared Step 106194 (RPS Sign out)

@ScenarioId:6669
Scenario: [70317] Generic Bucket Code by RU Chart
Given I call Shared Step 104950 (RPS Login - Base functionality) for TReVor account: RPS.99
Then I confirm the Home tab has loaded
Given I click the tab: Dashboard
Then I confirm the Dashboard tab has loaded
Then I confirm the following Widgets are displayed:
| Widget                         |
| Generic Bucket Code by RU      |
Then I Confirm that the Graph for the widget: Generic Bucket Code by RU is a: Bar Graph
Then In the Generic Bucket Code by RU widget, I confirm that a legend is not shown
Then I call Shared Step 70474 (Verify Chart functionality) for widget: Generic Bucket Code by RU
Then I call Shared Step 70484 (Chart Drill-down Export) for widget: Generic Bucket Code by RU
And I call Shared Step 106194 (RPS Sign out)

@ScenarioId:6670
Scenario: [70319] Base Functionality - Dashboard - RU Category by Supplier Chart - IE11 & Chrome  502 error and very poor performance
Given I call Shared Step 104950 (RPS Login - Base functionality) for TReVor account: RPS.99
Then I confirm the Home tab has loaded
Given I click the tab: Dashboard
Then I confirm the Dashboard tab has loaded
Then I confirm the following Widgets are displayed:
| Widget                  |
| RU Category by Supplier |
Then I Confirm that the Graph for the widget: RU Category by Supplier is a: Bar Graph
Then In the RU Category by Supplier widget, I confirm that a legend is not shown
Then I call Shared Step 70474 (Verify Chart functionality) for widget: RU Category by Supplier
Then I call Shared Step 70484 (Chart Drill-down Export) for widget: RU Category by Supplier
And I call Shared Step 106194 (RPS Sign out)

@ScenarioId:6671
Scenario: [70320] Base Functionality - Dashboard - RU Category by RU Chart - ie11 & Chrome 502 error
Given I call Shared Step 104950 (RPS Login - Base functionality) for TReVor account: RPS.99
Then I confirm the Home tab has loaded
Given I click the tab: Dashboard
Then I confirm the Dashboard tab has loaded
Then I confirm the following Widgets are displayed:
| Widget            |
| RU Category by RU |
Then I Confirm that the Graph for the widget: RU Category by RU is a: Bar Graph
Then In the RU Category by RU widget, I confirm that a legend is not shown
Then I call Shared Step 70474 (Verify Chart functionality) for widget: RU Category by RU
Then I call Shared Step 70484 (Chart Drill-down Export) for widget: RU Category by RU
And I call Shared Step 106194 (RPS Sign out)

@ScenarioId:6672
Scenario: [70321] Base Functionality - Dashboard - Product Recertification Status Chart
Given I call Shared Step 104950 (RPS Login - Base functionality) for TReVor account: RPS.99
Then I confirm the Home tab has loaded
Given I click the tab: Dashboard
Then I confirm the Dashboard tab has loaded
Then I confirm the following Widgets are displayed:
| Widget                         |
| Product Recertification Status |
Then I Confirm that the Graph for the widget: Product Recertification Status is a: Pie Chart
Then In the Product Recertification Status widget, I confirm that a legend is shown
Then I call Shared Step 70474 (Verify Chart functionality) for widget: Product Recertification Status
Then I call Shared Step 70484 (Chart Drill-down Export) for widget: Product Recertification Status
Then I call Shared Step 108597 (Widget data view - Contact Supplier - email verification) for widget: Product Recertification Status
And I call Shared Step 106194 (RPS Sign out)

@tfs_design
Scenario: [105031] Base Functionality - Dashboard - Product Hold Status displays active reason - needs thought if SHA does not show all active holds
Given I call Shared Step 104950 (RPS Login - Base functionality) for TReVor account: RPS.99
Then I confirm the Home tab has loaded
Given I click the tab: Dashboard
Then I confirm the Dashboard tab has loaded
Then I confirm the following Widgets are displayed:
| Widget              |
| Product Hold Status |
#This test involves studio/sha, leaving for now to foucs on Automation of RPS elements. 

@ScenarioId:6673
Scenario: [109212] Base Functionality - Dashboard - Product Status Chart - Drilled down - Contact Supplier
Given I call Shared Step 104950 (RPS Login - Base functionality) for TReVor account: RPS.99
Then I confirm the Home tab has loaded
Given I click the tab: Dashboard
Then I confirm the Dashboard tab has loaded
Then I confirm the following Widgets are displayed:
| Widget         |
| Product Status |
Then For the Product Status widget, I save the current titles as: ProductStatusTitles1 and check that when I click on the section: <first> that the titles change
And For the Widget: Product Status I select the section with title: <first>
Then I wait for the all widgets to finish loading
Then I confirm Product content is displayed for the widget: Product Status
Then I Confirm that the Products List for the widget: Product Status contains the column headings:
| Headings       |
| Product Number |
| Name           |
| UPCs           |
Then I Confirm that the Products list for the widget: Product Status contains 'Contact Supplier' in all rows
#Then For the widget (.*) In the Products list, I click on the Contact Supplier Link for the Product <first>
Then END OF AUTOMATION: TEST CASE NEEDS MANUAL COMPLETION. Message: Shared Step 109186 Cannot be automated, needs to be manually reviewed.
Given I call Shared Step 106194 (RPS Sign out)

@ScenarioId:6675
Scenario: [109214] Base Functionality - Dashboard - Supplier Subscription Status chart - Drilled down - Contact
Given I call Shared Step 104950 (RPS Login - Base functionality) for TReVor account: RPS.99
Then I confirm the Home tab has loaded
Given I click the tab: Dashboard
Then I confirm the Dashboard tab has loaded
Then I confirm the following Widgets are displayed:
| Widget                       |
| Supplier Subscription Status |
Then For the Supplier Subscription Status widget, I save the current titles as: SupplierSubscriptionStatusTitles1 and check that when I click on the section: Subscribed Suppliers that the supplier list view is seen.
Then I Check that for the widget Supplier Subscription Status, the Suppliers List shows the Following headings:
| Headers  |
| Supplier |
| Contact  |
| E-Mail   | 
#Then For the widget (.*) In the Suppliers list, I click on the Contact Supplier Link for the Product <first>
Then END OF AUTOMATION: TEST CASE NEEDS MANUAL COMPLETION. Message: Shared Step 109186 Cannot be automated, needs to be manually reviewed.


@ScenarioId:6676
Scenario: [109206] Base Functionality - Dashboard - Generic Bucket Code by RU Chart - Drilled down - PRODUCT INFORMATION
Given I call Shared Step 104950 (RPS Login - Base functionality) for TReVor account: RPS.99
Then I confirm the Home tab has loaded
Given I click the tab: Dashboard
Then I confirm the Dashboard tab has loaded
Then I confirm the following Widgets are displayed:
| Widget                         |
| Generic Bucket Code by RU      |
Then For the Generic Bucket Code by RU widget, I save the current titles as: GenericBucketCodebyRU1 and check that when I click on the section: <first> that the titles change
Then For the Generic Bucket Code by RU widget, I save the current titles as: GenericBucketCodebyRU2 and check that when I click on the section: <first> that the products data view is seen.
Then I open the Product Information popup for products in the Product list of widget: Generic Bucket Code by RU until one has enough data
Then I call Shared Step 109167 (Product Information pop up - layout verification)
Then I call Shared Step 109168 (Product Information pop up - Expand Product Data codes - confirm rows)
Then I call Shared Step 109169 (Product Information pop up - Expand Transportation Data - confirm rows)
Then I call Shared Step 109170 (Product Information pop up - Expand Storage Data - confirm rows)
Then I call Shared Step 109171 (Product Information pop up - Expand Battery Data - confirm rows)
Then I call Shared Step 109172 (Product information pop up - Only 1 section expands at a time)
Then I Close the Product Information Popup

@ScenarioId:6677
Scenario: [109207] Base Functionality - Dashboard - RCRA by RU Category Chart - Drilled down - PRODUCT INFORMATION
Given I call Shared Step 104950 (RPS Login - Base functionality) for TReVor account: RPS.99
Then I confirm the Home tab has loaded
Given I click the tab: Dashboard
Then I confirm the Dashboard tab has loaded
Then I confirm the following Widgets are displayed:
| Widget                         |
| RCRA by RU Category     |
Then For the RCRA by RU Category widget, I save the current titles as: RCRAByRUCategoryTitles1 and check that when I click on the section: <first> that the titles change
Then For the RCRA by RU Category widget, I save the current titles as: RCRAByRUCategoryTitles2 and check that when I click on the section: <first> that the products data view is seen.
Then I open the Product Information popup for products in the Product list of widget: RCRA by RU Category until one has enough data
Then I call Shared Step 109167 (Product Information pop up - layout verification)
Then I call Shared Step 109168 (Product Information pop up - Expand Product Data codes - confirm rows)
Then I call Shared Step 109169 (Product Information pop up - Expand Transportation Data - confirm rows)
Then I call Shared Step 109170 (Product Information pop up - Expand Storage Data - confirm rows)
Then I call Shared Step 109171 (Product Information pop up - Expand Battery Data - confirm rows)
Then I call Shared Step 109172 (Product information pop up - Only 1 section expands at a time)

@ScenarioId:6678
Scenario: [109209] Base Functionality - Dashboard - RU Category by Supplier Chart - Drilled down - PRODUCT INFORMATION
Given I call Shared Step 104950 (RPS Login - Base functionality) for TReVor account: RPS.99
Then I confirm the Home tab has loaded
Given I click the tab: Dashboard
Then I confirm the Dashboard tab has loaded
Then I confirm the following Widgets are displayed:
| Widget                  |
| RU Category by Supplier |
Then For the RU Category by Supplier widget, I save the current titles as: RUCategorybySupplierTitles1 and check that when I click on the section: <first> that the titles change
Then For the RU Category by Supplier widget, I save the current titles as: RUCategorybySupplierTitles2 and check that when I click on the section: <first> that the products data view is seen.
Then I open the Product Information popup for products in the Product list of widget: RU Category by Supplier until one has enough data
Then I call Shared Step 109167 (Product Information pop up - layout verification)
Then I call Shared Step 109168 (Product Information pop up - Expand Product Data codes - confirm rows)
Then I call Shared Step 109169 (Product Information pop up - Expand Transportation Data - confirm rows)
Then I call Shared Step 109170 (Product Information pop up - Expand Storage Data - confirm rows)
Then I call Shared Step 109171 (Product Information pop up - Expand Battery Data - confirm rows)
Then I call Shared Step 109172 (Product information pop up - Only 1 section expands at a time)

@ScenarioId:9728
Scenario: [109210] Base Functionality - Dashboard - RU Category by RU Chart - Drilled down - PRODUCT INFORMATION
Given I call Shared Step 104950 (RPS Login - Base functionality) for TReVor account: RPS.99
Then I confirm the Home tab has loaded
Given I click the tab: Dashboard
Then I confirm the Dashboard tab has loaded
Then I confirm the following Widgets are displayed:
| Widget            |
| RU Category by RU |
Then For the RU Category by RU widget, I save the current titles as: RUCategorybyRUTitles1 and check that when I click on the section: <first> that the titles change
Then For the RU Category by RU widget, I save the current titles as: RUCategorybyRUTitles2 and check that when I click on the section: <first> that the products data view is seen.
Then I open the Product Information popup for products in the Product list of widget: RU Category by RU until one has enough data
Then I call Shared Step 109167 (Product Information pop up - layout verification)
Then I call Shared Step 109168 (Product Information pop up - Expand Product Data codes - confirm rows)
Then I call Shared Step 109169 (Product Information pop up - Expand Transportation Data - confirm rows)
Then I call Shared Step 109170 (Product Information pop up - Expand Storage Data - confirm rows)
Then I call Shared Step 109171 (Product Information pop up - Expand Battery Data - confirm rows)
Then I call Shared Step 109172 (Product information pop up - Only 1 section expands at a time)

@ScenarioId:6680
Scenario: [109211] Base Functionality - Dashboard- Product Recertification Status Chart - Drilled down - Contact Supplier
Given I call Shared Step 104950 (RPS Login - Base functionality) for TReVor account: RPS.99
Then I confirm the Home tab has loaded
Given I click the tab: Dashboard
Then I confirm the Dashboard tab has loaded
Then I confirm the following Widgets are displayed:
| Widget         |
| Product Recertification Status |
Then For the Product Recertification Status widget, I save the current titles as: ProductRecertificationStatusTitles1 and check that when I click on the section: <first> that the titles change
And For the Widget: Product Recertification Status I select the section with title: <first>
Then I wait for the all widgets to finish loading
Then I confirm Product content is displayed for the widget: Product Recertification Status
Then I Confirm that the Products List for the widget: Product Recertification Status contains the column headings:
| Headings       |
| Product Number |
| Name           |
| UPCs           |
Then I Confirm that the Products list for the widget: Product Recertification Status contains 'Contact Supplier' in all rows
#Then For the widget (.*) In the Products list, I click on the Contact Supplier Link for the Product <first>
Then END OF AUTOMATION: TEST CASE NEEDS MANUAL COMPLETION. Message: Shared Step 109186 Cannot be automated, needs to be manually reviewed.
Given I call Shared Step 106194 (RPS Sign out)
































