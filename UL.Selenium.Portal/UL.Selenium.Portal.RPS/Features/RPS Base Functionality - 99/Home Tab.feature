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
Given I call Shared Step 104950 (RPS Login - Base functionality) for TReVor account: RPS.99
Then I confirm the Home tab has loaded
Given  I confirm the following tabs are displayed:
| Link              |
| Home              |
| Dashboard         |
| Recent Activities |
| Web Viewers       |
| Product Lookup    |
| Help & Support    |
Given I call Shared Step 106194 (RPS Sign out)

@ScenarioId:6430
Scenario: [72460] Base Functionality - Home - Update and Reset Dashboard
Given I call Shared Step 104950 (RPS Login - Base functionality) for TReVor account: RPS.99
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

@ScenarioId:6630
Scenario: [70347] Base Functionality - UL Logo
Given I call Shared Step 104950 (RPS Login - Base functionality) for TReVor account: RPS.99
Then I confirm the Home tab has loaded
And I confirm the UL Logo is displayed in the top bar
Given I click the UL Logo in the top bar
Then I verify that a tab opens with url: https://msc.ul.com/en/
And I close the tab with url: https://msc.ul.com/en/
Given I call Shared Step 106194 (RPS Sign out)

@ScenarioId:6433
Scenario: [70346] Base Functionality - Log Out
Given I call Shared Step 104950 (RPS Login - Base functionality) for TReVor account: RPS.99
Then I confirm the Home tab has loaded
Given I confirm the user displayed in the top bar matches the active logged in user
And I click the user button in the top bar
Then I confirm the 'Sign Out' dropdown option is displayed under the user button
Given I click on the home page background
Then I confirm the Home tab has loaded
Given I call Shared Step 106194 (RPS Sign out)
Then I confirm the Landing Page has loaded

@ScenarioId:6622
Scenario: [106428] Base Functionality - Home page - layout
Given I call Shared Step 104950 (RPS Login - Base functionality) for TReVor account: RPS.99
Given I confirm the top menu bar is displayed with the logged in username
And I confirm the navigation menu bar is displayed below the top bar
Then I confirm the Home tab has loaded
And I confirm there are a total of 4 widgets displayed in a 2 x 2 grid
Then I confirm the following Widgets are displayed:
| Widget                    |
| RU Categories by RU       |
| Products by Status        |
| RU Categories by Supplier |
| Product Hold Status       |
Then I confirm an information panel is displayed with heading: Become a sustainability leader.
Then I confirm an information panel is displayed with heading: All product data in one place. Quick and easy.

@ScenarioId:6623
Scenario: [106478] Base Functionality - Home page - widget layout
Given I call Shared Step 104950 (RPS Login - Base functionality) for TReVor account: RPS.99
Given I confirm there are a total of 4 widgets displayed
Then I verify each widget displays the correct data

@ScenarioId:6558
Scenario: [106453] Base functionality - Menu Links Banner - Gauge icon - menu items display
Given I call Shared Step 104950 (RPS Login - Base functionality) for TReVor account: RPS.99
Then I confirm the Home tab has loaded
Given I click the Gauge button in the navigation bar
Given I confirm the following drop down options are displayed below the navigation bar Gauge button:
| Option              |
| Reset Dashboard     |
| Refresh All Widgets |
Given I click on the home page background
Then I confirm the down down options box is not displayed below the navigation bar Gauge button
Given I call Shared Step 106194 (RPS Sign out)

@ScenarioId:6435
Scenario: [106468] Base functionality - Menu Links Banner - Gauge icon - shows on correct pages
Given I call Shared Step 104950 (RPS Login - Base functionality) for TReVor account: RPS.99
Then I confirm the Home tab has loaded
Then I confirm the Gauge button is displayed in the navigation bar
Given I click the tab: Dashboard
And I confirm the active tab is: Dashboard
Then I confirm the Gauge button is displayed in the navigation bar
Given I click the tab: Recent Activities
And I confirm the active tab is: Recent Activities
Then I confirm the Gauge button is not displayed in the navigation bar
Given I click the tab: Product Lookup
And I confirm the active tab is: Product Lookup
Then I confirm the Gauge button is not displayed in the navigation bar
Given I click the tab: Home
And I confirm the active tab is: Home
Then I confirm the Gauge button is displayed in the navigation bar
Given I call Shared Step 106194 (RPS Sign out)

@ScenarioId:6434
Scenario: [106487] Base Functionality - Home - Widget - three dots icon - options and general test
Given I call Shared Step 104950 (RPS Login - Base functionality) for TReVor account: RPS.99
Then I confirm the Home tab has loaded
And I save the first widget containing a graph to context
And I click the dropdown toggle for the saved widget
And I confirm the dropdown menu list is displayed
And I confirm the graph menu list displays the following options:
| Option  |
| Graph   |
| Data    |
| Export  |
| Replace |
And In the graph menu list I confirm I see a pie chart icon to the left of the option: Graph
And In the graph menu list I confirm I see a edit icon to the left of the option: Data
And In the graph menu list I confirm I see a excel icon to the left of the option: Export
And I click 'Data' in the dropdown menu for the saved widget
And I confirm graph content is not displayed for the saved widget
And I confirm data content is displayed for the saved widget
And I click the dropdown toggle for the saved widget
And I click 'Graph' in the dropdown menu for the saved widget
And I confirm data content is not displayed for the saved widget
And I confirm graph content is displayed for the saved widget
And I click the dropdown toggle for the saved widget
And I save the download folder
And I click 'Export' in the dropdown menu for the saved widget
And I confirm a new file has been downloaded with .csv format and save to context as: ExportFile
And I confirm the csv file saved as: ExportFile contains data
And I click the dropdown toggle for the saved widget
And I click 'Replace' in the dropdown menu for the saved widget
And I confirm a popup has loaded with title: 'Select Chart Type'
And I close the Select Chart Type popup

@ScenarioId:6441
Scenario Outline: [72759] Base Functionality - Home - Refresh all widgets - ticket opened - not in scope for Azure
Given I call Shared Step 104950 (RPS Login - Base functionality) for TReVor account: <Account> 
Then I confirm the Home tab has loaded
Then For the RU Categories by RU widget, I save the current titles as: ByRuDataTitles1 and check that when I click on the section: Health and Beauty that the titles change
Then For the RU Categories by Supplier widget, I save the current titles as: BySupplierTitles1 and check that when I click on the section: Health and Beauty that the titles change
Then For the Products by Status widget, I save the current titles as: ProdByStatusTitles1 and check that when I click on the section: Completed that the titles change
Then For the Product Hold Status widget, I save the current titles as: ProdByHoldStatusTitles1 and check that when I click on the section: Other that the titles change
Given I click the Gauge button in the navigation bar
Given I click the Refresh All Widgets dropdown option below the navigation bar Gauge button
Then I confirm the Home tab has loaded
Then I confirm the following Widgets are displayed:
| Widget                    |
| RU Categories by RU       |
| Products by Status        |
| RU Categories by Supplier |
| Product Hold Status       |
Then I Check that the current titles being displayed for widget: RU Categories by RU are the same as those saved as: ByRuDataTitles1
Then I Check that the current titles being displayed for widget: RU Categories by Supplier are the same as those saved as: BySupplierTitles1
Then I Check that the current titles being displayed for widget: Products by Status are the same as those saved as: ProdByStatusTitles1
Then I Check that the current titles being displayed for widget: Product Hold Status are the same as those saved as: ProdByHoldStatusTitles1
Given I call Shared Step 106194 (RPS Sign out)

Examples: 
| Account |
| RPS.99  |
| RPS.LW  |
| RPS.HD  |
| RPS.CV  |

@ScenarioId:6456
Scenario: [106416] Base Functionality - Logged in page banner - layout
Given I call Shared Step 104950 (RPS Login - Base functionality) for TReVor account: RPS.99 
Then I confirm the Home tab has loaded
Then I confirm the logged in page banner shows font color: white
Then I confirm the logged in page banner shows background color: black
Then I confirm the page heading banner shows the WERCSmart Product Suite logo and it reads : WERCSmart® Product Suite
Then I confirm the UL Logo is displayed in the top bar 
And I confirm the user displayed in the top bar matches the active logged in user
And I call Shared Step 106194 (RPS Sign out)

@ScenarioId:6458
Scenario: [70252] Base Functionality - Home - RU Categories by RU Chart - has open Staging  ticket - 502 error in staging
Given I call Shared Step 104950 (RPS Login - Base functionality) for TReVor account: RPS.99 
Then I confirm the Home tab has loaded
Then I confirm the following Widgets are displayed:
| Widget                    |
| RU Categories by RU       |
Then I Confirm that the Graph for the widget: RU Categories by RU is a: Bar Graph
Then I Check that if required, a scroll bar is present for the Widget: RU Categories by RU
Then I call Shared Step 70474 (Verify Chart functionality) for widget: RU Categories by RU 
Then I call Shared Step 70484 (Chart Drill-down Export) for widget: RU Categories by RU 
And I call Shared Step 106194 (RPS Sign out)

@ScenarioId:6465
Scenario: [70613] Base Functionality - Home - RU Category by Supplier chart - Verify product data
Given I call Shared Step 104950 (RPS Login - Base functionality) for TReVor account: RPS.99 
Then I confirm the Home tab has loaded
Then I confirm the following Widgets are displayed:
| Widget                    |
| RU Categories by Supplier |
Then For the RU Categories by RU widget, I save the current titles as: ByRuDataTitles1 and check that when I click on the section: Health and Beauty that the titles change
And For the Widget: RU Categories by RU I select the section with title: Cosmetics
Then I wait for the all widgets to finish loading
Then I confirm Product content is displayed for the widget: RU Categories by RU
Then I save the information for the first product in the product list of widget: RU Categories by RU that contains data to context as: ProductInformation1
Then I Close the Product Information Popup
Given I click the tab: Product Lookup
And I confirm the active tab is: Product Lookup
Then I enter Product ID: ProductInformation1 into the Product Lookup search box
Then I Check that only one Product Is present in the Products Grid with the ID: ProductInformation1
Then I Click the Row actions: View Data for the first product in the Products Grid
Then I save the Product Information for the current Product as: ProductInformation2
Then I Check that two sets of ProductInformation Saved as: ProductInformation1 and ProductInformation2 are the same
Then I Close the Product Information Popup
And I call Shared Step 106194 (RPS Sign out)

@ScenarioId:6510
Scenario: [73077] Base Functionality - WERCSmart Product Suite logo redirects to Home tab
Given I call Shared Step 104950 (RPS Login - Base functionality) for TReVor account: RPS.99 
Then I confirm the Home tab has loaded
Given I click the tab: Dashboard
And I confirm the active tab is: Dashboard
And I call Shared Step 111976 (Click WERCSmart® Product Suite Logo - Confirm Home page shown)
Given I click the tab: Recent Activities
And I confirm the active tab is: Recent Activities
And I call Shared Step 111976 (Click WERCSmart® Product Suite Logo - Confirm Home page shown)
Given I click the tab: Product Lookup
And I confirm the active tab is: Product Lookup
And I call Shared Step 111976 (Click WERCSmart® Product Suite Logo - Confirm Home page shown)
And I call Shared Step 106194 (RPS Sign out)



@ScenarioId:6453
@tfs_design
Scenario: [108521] Base Functionality - Home - Widget - hamburger icon - Print Chart 

Given I call Shared Step 104950 (RPS Login - Base functionality) for TReVor account: RPS.99 
Then I confirm the Home tab has loaded
Then I Click the hamburger menu for the widget: RU Categories by RU and select the option: Print chart
Then I check that the print dialog is open



#Currently this test needs to be manually reviewed for the "open file and take screenshot steps" to ensure the correct widget is being found. 
@ScenarioId:6512
Scenario: [106490] Base Functionality - Widget - hamburger icon - options and general test (Manual Review Report)

Given I call Shared Step 104950 (RPS Login - Base functionality) for TReVor account: RPS.99 
Then I confirm the Home tab has loaded
Then I click the graph hamburger menu for widget: RU Categories by RU
Then I Check that the Hamburger menu dropdown for widget: RU Categories by RU is displayed
Then I Check that the Options displayed in the Hamburger menu for widget: RU Categories by RU are as follows:
| Options                   |
| Print chart               |
| Download PNG image        |
| Download JPEG image       |
| Download PDF document     |
| Download SVG vector image |
#Dont do the print steps here (selenium limitation?)
Then I Click the hamburger menu for the widget: RU Categories by RU and select the option: Download PDF document
Then I confirm that a file is produced called chart.pdf and save as savedasPDF106490
Then I open the file saved as: savedasPDF106490 should see a new tabbed document with the pdf at it contains the text: RU Categories by RU
Then I close the window that was opened
Then I Click the hamburger menu for the widget: RU Categories by RU and select the option: Download PNG image
Then I confirm that a file is produced called chart.png and save as savedasPNG106490
Then I open the file saved as: savedasPNG106490 and take a screenshot
Then I close the window that was opened
Then I Click the hamburger menu for the widget: RU Categories by RU and select the option: Download JPEG image
Then I confirm that a file is produced called chart.jpeg and save as savedasjpeg106490
Then I open the file saved as: savedasjpeg106490 and take a screenshot
Then I close the window that was opened
Then I Click the hamburger menu for the widget: RU Categories by RU and select the option: Download SVG vector image
Then I confirm that a file is produced called chart.svg and save as savedassvg106490
Then I open the file saved as: savedassvg106490 and take a screenshot
Then I close the window that was opened
Then I delete the file saved as savedasPNG106490
Then I delete the file saved as savedasPDF106490
Then I delete the file saved as savedasjpeg106490
Then I delete the file saved as savedassvg106490
And I call Shared Step 106194 (RPS Sign out)

@ScenarioId:6518
Scenario: [70253] Base Functionality - Home - Products by Status Chart - Staging ticket opened
Given I call Shared Step 104950 (RPS Login - Base functionality) for TReVor account: RPS.99 
Then I confirm the Home tab has loaded
Then I confirm the following Widgets are displayed:
| Widget             |
| Products by Status |
Then I Confirm that the Graph for the widget: Products by Status is a: Pie Chart
Then I call Shared Step 70474 (Verify Chart functionality) for widget: Products by Status
Then I call Shared Step 70484 (Chart Drill-down Export) for widget: Products by Status
And I call Shared Step 106194 (RPS Sign out)

@ScenarioId:6584
Scenario: [115713] Product by Status widget - Pie-chart widget - toggle off and on from legend
Given I call Shared Step 104950 (RPS Login - Base functionality) for TReVor account: RPS.99 
Then I confirm the Home tab has loaded
Then I confirm the following Widgets are displayed:
| Widget             |
| Products by Status |
Then I get the current Legend Items for the widget: Products by Status and save them as: LegendItems1
Then I click on the legend item: Completed from the List saved as: LegendItems1, for widget: Products by Status
Then I confirm the Products by Status widget is refreshed and the section with title: Completed is removed from the pie chart
Then I confirm for the widget: Products by Status that the legend entry: Completed is found and in a grey font in the legend list
Then I click the three dots menu icon and select the Export option for the widget: Products by Status
Then I save the download folder
Then I Check that there is a new csv file downloaded and save the file path as: ExportCsv1
Then I check that the file saved as: ExportCsv1 contains the following column headings:
| Heading |
| Status  |
| Count   |
Then I Check that the file saved as: ExportCsv1 included the following data in the column with heading: Status
| Values    |
| Completed |
Then I delete the file saved as ExportCsv1
Then For the Products by Status widget, I save the current titles as: ProdByStatusTitles1 and check that when I click on the section: Submitted that the titles change
Then I get the current Legend Items for the widget: Products by Status and save them as: LegendItems2
Then I click on the legend item: The Dial Corporation from the List saved as: LegendItems2, for widget: Products by Status
Then I confirm the Products by Status widget is refreshed and the section with title: The Dial Corporation is removed from the pie chart
Then I confirm for the widget: Products by Status that the legend entry: The Dial Corporation is found and in a grey font in the legend list
Then I click the three dots menu icon and select the Export option for the widget: Products by Status
Then I save the download folder
Then I Check that there is a new csv file downloaded and save the file path as: ExportCsv2
Then I check that the file saved as: ExportCsv2 contains the following column headings:
| Heading |
| Supplier  |
| Count   |
Then I Check that the file saved as: ExportCsv2 included the following data in the column with heading: Supplier
| Values       |
| Markwins |
Then I delete the file saved as ExportCsv2
Then For the Products by Status widget, I save the current titles as: ProdByStatusTitles2 and check that when I click on the section: Markwins that the products data view is seen.
And For the widget that has title: Products by Status, I click the back button in the Products List and confirm a graph is displayed
Then I get the current Legend Items for the widget: Products by Status and save them as: LegendItems2
Then I confirm for the widget: Products by Status that the legend entry: The Dial Corporation is found and in a grey font in the legend list
Then I click on the legend item: The Dial Corporation from the List saved as: LegendItems2, for widget: Products by Status
Then I confirm the Products by Status widget is refreshed and the section with title: The Dial Corporation is not removed from the pie chart
Then I save the current titles as: ProductsbyStatusTitles1 and check that when I Click Back that the titles change for the Products by Status widget
Then I get the current Legend Items for the widget: Products by Status and save them as: LegendItems1
Then I confirm for the widget: Products by Status that the legend entry: Completed is found and in a grey font in the legend list
Then I click on the legend item: Completed from the List saved as: LegendItems1, for widget: Products by Status
Then I confirm the Products by Status widget is refreshed and the section with title: Completed is not removed from the pie chart

@ScenarioId:6612
Scenario: [109176] Base Functionality - Home - RU Categories by RU Chart - Drilled down - product information
Given I call Shared Step 104950 (RPS Login - Base functionality) for TReVor account: RPS.99 
Then I confirm the Home tab has loaded
Then I confirm the following Widgets are displayed:
| Widget              |
| RU Categories by RU |
Then For the RU Categories by RU widget, I save the current titles as: RUCategoriesByRU1 and check that when I click on the section: Health and Beauty that the titles change
Then I wait for the all widgets to finish loading
And For the Widget: RU Categories by RU I select the section with title: Cosmetics
Then I wait for the all widgets to finish loading
Then I confirm Product content is displayed for the widget: RU Categories by RU
Then I open the Product Information popup for products in the Product list of widget: RU Categories by RU until one has enough data
Then I call Shared Step 109167 (Product Information pop up - layout verification)
Then I call Shared Step 109168 (Product Information pop up - Expand Product Data codes - confirm rows)
Then I call Shared Step 109169 (Product Information pop up - Expand Transportation Data - confirm rows)
Then I call Shared Step 109170 (Product Information pop up - Expand Storage Data - confirm rows)
Then I call Shared Step 109171 (Product Information pop up - Expand Battery Data - confirm rows)
Then I call Shared Step 109172 (Product information pop up - Only 1 section expands at a time)
Then I Close the Product Information Popup

@ScenarioId:6621
Scenario: [109191] Base Functionality - Home - RU Categories by Supplier Chart - Drilled down - product information
Given I call Shared Step 104950 (RPS Login - Base functionality) for TReVor account: RPS.99 
Then I confirm the Home tab has loaded
Then I confirm the following Widgets are displayed:
| Widget                    |
| RU Categories by Supplier |
Then For the RU Categories by Supplier widget, I save the current titles as: RUCategoriesBySupplier1 and check that when I click on the section: Health and Beauty that the titles change
Then I wait for the all widgets to finish loading
And For the Widget: RU Categories by Supplier I select the section with title: Unilever
Then I wait for the all widgets to finish loading
Then I confirm Product content is displayed for the widget: RU Categories by Supplier
Then I open the Product Information popup for products in the Product list of widget: RU Categories by Supplier until one has enough data
Then I call Shared Step 109167 (Product Information pop up - layout verification)
Then I call Shared Step 109168 (Product Information pop up - Expand Product Data codes - confirm rows)
Then I call Shared Step 109169 (Product Information pop up - Expand Transportation Data - confirm rows)
Then I call Shared Step 109170 (Product Information pop up - Expand Storage Data - confirm rows)
Then I call Shared Step 109171 (Product Information pop up - Expand Battery Data - confirm rows)
Then I call Shared Step 109172 (Product information pop up - Only 1 section expands at a time)
Then I Close the Product Information Popup


@ScenarioId:6624
Scenario: [70254] Base Functionality - Home - RU Categories by Supplier Chart - Staging ticket open 
Given I call Shared Step 104950 (RPS Login - Base functionality) for TReVor account: RPS.99 
Then I confirm the Home tab has loaded
Then I confirm the following Widgets are displayed:
| Widget                    |
| RU Categories by Supplier |
Then I Confirm that the Graph for the widget: RU Categories by Supplier is a: Bar Graph
Then I call Shared Step 70474 (Verify Chart functionality) for widget: RU Categories by Supplier
Then I call Shared Step 70484 (Chart Drill-down Export) for widget: RU Categories by Supplier
And I call Shared Step 106194 (RPS Sign out)

@ScenarioId:6625
Scenario: [70255] Base Functionality - Home - Product Hold Status Chart -Staging has open ticket
Given I call Shared Step 104950 (RPS Login - Base functionality) for TReVor account: RPS.99 
Then I confirm the Home tab has loaded
Then I confirm the following Widgets are displayed:
| Widget              |
| Product Hold Status |
Then I Confirm that the Graph for the widget: Product Hold Status is a: Pie Chart
Then I call Shared Step 70474 (Verify Chart functionality) for widget: Product Hold Status
Then I call Shared Step 70484 (Chart Drill-down Export) for widget: Product Hold Status
And I call Shared Step 106194 (RPS Sign out)











       


