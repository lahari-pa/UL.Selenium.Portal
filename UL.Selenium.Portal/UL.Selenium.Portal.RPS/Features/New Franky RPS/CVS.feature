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
@MoreFilters

Feature: CVS

Scenario Outline: [108079] CVS functionality - Menu Links Banner - options
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: RPS.CV
	Given I confirm the following tabs are displayed:
		| Link              |
		| Program Health    |
		| Dashboard         |
		| Recent Activities |
		| ItemSync          |
		| Web Viewers       |
		| Product Lookup    |
		| Help & Support    |
	Given I call Shared Step 106194 (RPS Sign out)

Scenario Outline: [109135] CVS - Menu Links Banner - Gauge icon - shows on correct pages
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: RPS.CV
	#Then I confirm the Home tab has loaded
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


Scenario Outline: [108081] CVS functionality - Menu Links Banner - active page/ heading background color
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: RPS.CV
	#Then I confirm the Home tab has loaded
	And I Confirm that the tab: Home shows in a grey highlight indicating it is active
	Then I click the main tab: Dashboard
	Then I confirm the Dashboard tab has loaded
	Then I confirm the active tab is: Dashboard
	And I Confirm that the tab: Dashboard shows in a grey highlight indicating it is active
	And I Confirm that the tab: Home is  shown in white highlight indicating it is inactive
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

Scenario Outline: [90142] CVS - Web Viewer Menu Options
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: RPS.CV
	#Then I confirm the Home tab has loaded
	Then I click the main tab: Web Viewers
	And I confirm there is a drop down menu below the navigation tab: Web Viewers
	Given I confirm the following drop down options are displayed below the navigation bar Web viewers button:
		| Option    |
		| CVS_store |
	Given I call Shared Step 106194 (RPS Sign out)

Scenario: [165120] RPS - Recent Activities page - layout (includes TAT) - CVS User specific layout
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: RPS.CV
	#Then I confirm the Home tab has loaded
	Given I click the main tab: Recent Activities
	Then I confirm the Recent Activities tab has loaded
	Then I confirm the page heading banner shows the WERCSmart Product Suite logo and it reads : WERCSmart® Product Suite
	Then I confirm the UL Logo is displayed in the top bar
	And I confirm the user displayed in the top bar matches the active logged in user
	Then I confirm the menu links banner is displayed
	Then I confirm below the menu links banner I see the Product Lookup main page body
	Then I confirm the Recent Activities tab has loaded
	Then I confirm the Recent Activities background color is: grey
	Then I confirm the Recent Activities Text color is: darker grey
	And I confirm the Recent Activities search box is shown
	Then I confirm that the recent activities search box place holder text reads: UPC / Product Name / Supplier / WPSID
	Then I confirm that the recent activities page buttons to the right of the search box are as follows:
		| Buttons                    |
		| More Filters               |
		| Reset                      |
		| Export to Excel            |
		| Export TAT Report to Excel |
	Given In the Product Lookup page I confirm to the right of the buttons I see three trends
		| Trend     |
		| UPCs      |
		| PRODUCTS  |
		| SUPPLIERS |
	Given In the Recent Activites page, I confirm I do not see the breadcrumbs area under the search field
	Then I Check that the Recent Activities Products Table is showing
	Then I confirm that the recent activities page headings row has a grey background color
	Then In the recent activities page, I confirm that the main table has the following columns:
		| Headings             |
		| Product Info         |
		| Product Status       |
		| Turnaround Time      |
		| Most Recent Activity |
		| Reason               |
		| Packaging Type       |
		| Packaging Size (oz)  |
		| Actions              |
	And In the Recent Activities page, I confirm that the main table shows data rows
	Then In the Recent Activities page, below the Most Recent Activity table I confirm: page footer is shown
	And I call Shared Step 106194 (RPS Sign out)


Scenario Outline: [163698] CVS - Recent Activities - Export
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: RPS.CV
	#Then I confirm the Home tab has loaded
	Given I click the main tab: Recent Activities
	Then I confirm the Recent Activities tab has loaded
	Then I confirm the active tab is: Recent Activities
	Then In the recent activities Page, I save all the Results to context as: RecentProductsGridResults1
	Then I call Shared Step 146627 (Recent Activities - Export - Open File)
	Then I check that the file saved as: recentactivitiesfile contains the following column headings:
		| Heading              |
		| Product Name         |
		| UPC Number           |
		| Product Number       |
		| Supplier Name        |
		| Status               |
		| Turnaround Time      |
		| Most Recent Activity |
		| Reason               |
		| Packaging Type       |
		| Packaging Size       |
   #Step that checks the cvs file for data in products grid
	Then In the recent activities Page, I confirm the Products shown in the export file saved as: recentactivitiesfile  match the products saved as: RecentProductsGridResults1
	Then I delete the file saved as recentactivitiesfile
	And I call Shared Step 106194 (RPS Sign out)


Scenario Outline: [110834] CVS - Recent Activities - View Data  - Transportation Data - confirm fields shown
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: RPS.CV
	#Then I confirm the Home tab has loaded
	Given I click the main tab: Recent Activities
	Then I confirm the Recent Activities tab has loaded
	Then I confirm the active tab is: Recent Activities
	And In the recent activities Page, I click the More Filters Button
	Then In theMore Filters pop up, I select Status: Completed
	Then In the recent activities Page More Filters Popup, I Click the the Apply Filter Button
	Given In the product lookup page, I confirm the More Filters popup is not displayed
	Then I Click the Row actions: View Data for the first product in the Products Grid
	Then I wait for the Product Information Popup to load
	Then I Confirm that Product Information pop up is shown
	Then I call Shared Step 110820 (View Data - Product Information pop up - Expand Transportation Data (Longer version) - confirm rows)


Scenario Outline: [110833] CVS - Recent Activities - View Data  - Product Details - confirm fields shown shown
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: RPS.CV
	#Then I confirm the Home tab has loaded
	Given I click the main tab: Recent Activities
	Then I confirm the Recent Activities tab has loaded
	Then I confirm the active tab is: Recent Activities
	And In the recent activities Page, I click the More Filters Button
	Then In theMore Filters pop up, I select Status: Completed
	Then In the recent activities Page More Filters Popup, I Click the the Apply Filter Button
	Given In the product lookup page, I confirm the More Filters popup is not displayed
	Then I Click the Row actions: View Data for the first product in the Products Grid
	Then I wait for the Product Information Popup to load
	Then I Confirm that Product Information pop up is shown
	Then I call Shared Step 110819 (Home Depot & CVS Only - Product Information pop up - Expand Product Details - Confirm rows)

Scenario Outline: [110830] CVS - Home - RU Categories by Supplier Chart - Drilled down - product information
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: RPS.CV
	#Then I confirm the Home tab has loaded
	Then I confirm the following Widgets are displayed:
		| Widget                    |
		| RU Categories by Supplier |
	Then For the RU Categories by Supplier widget, I save the current titles as: RUCategoriesBySupplier1 and check that when I click on the section: Health and Beauty that the titles change
	Then I wait for the all widgets to finish loading
	And For the Widget: RU Categories by Supplier I select the section with title: Unilever
	Then I wait for the all widgets to finish loading
	Then I confirm Product content is displayed for the widget: RU Categories by Supplier
	Then I Confirm that the Products List for the widget: RU Categories by Supplier contains the column headings:
		| Headings       |
		| Product Number |
		| Name           |
		| UPCs           |
		| Supplier       |
	Then I open the Product Information popup for products in the Product list of widget: RU Categories by Supplier until one has enough data
	Then I call Shared Step 109167 (Product Information pop up - layout verification)
	Then I call Shared Step 110819 (Home Depot & CVS Only - Product Information pop up - Expand Product Details - Confirm rows)
	Then I call Shared Step 110820 (View Data - Product Information pop up - Expand Transportation Data (Longer version) - confirm rows)
	Then I call Shared Step 109170 (Product Information pop up - Expand Storage - confirm rows)
	Then I call Shared Step 109171 (Product Information pop up - Expand Battery - confirm rows)
	Then I call Shared Step 109172 (Product information pop up - Only 1 section expands at a time)
	Then I Close the Product Information Popup


Scenario Outline: [110829] CVS - Home - RU Categories by RU Chart - Drilled down - product information
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: RPS.CV
	#Then I confirm the Home tab has loaded
	Then I confirm the following Widgets are displayed:
		| Widget              |
		| RU Categories by RU |
	Then For the RU Categories by RU widget, I save the current titles as: RUCategoriesByRU1 and check that when I click on the section: Health and Beauty that the titles change
	Then I wait for the all widgets to finish loading
	And For the Widget: RU Categories by RU I select the section with title: Conditioner
	Then I wait for the all widgets to finish loading
	Then I confirm Product content is displayed for the widget: RU Categories by RU
	Then I Confirm that the Products List for the widget: RU Categories by RU contains the column headings:
		| Headings       |
		| Product Number |
		| Name           |
		| UPCs           |
		| Supplier       |
	Then I open the Product Information popup for products in the Product list of widget: RU Categories by RU until one has enough data
	Then I call Shared Step 109167 (Product Information pop up - layout verification)
	Then I call Shared Step 110819 (Home Depot & CVS Only - Product Information pop up - Expand Product Details - Confirm rows)
	Then I call Shared Step 110820 (View Data - Product Information pop up - Expand Transportation Data (Longer version) - confirm rows)
	Then I call Shared Step 109170 (Product Information pop up - Expand Storage - confirm rows)
	Then I call Shared Step 109171 (Product Information pop up - Expand Battery - confirm rows)
	Then I call Shared Step 109172 (Product information pop up - Only 1 section expands at a time)
	Then I Close the Product Information Popup

Scenario Outline: [110835] CVS - Product Lookup - View Data  - Product Data codes - confirm fields shown
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: RPS.CV
	#Then I confirm the Home tab has loaded
	Given I click the main tab: Product Lookup
	Then I confirm the Product Lookup tab has loaded
	Then I confirm the active tab is: Product Lookup
	Then I Click the Row actions: View Data for the first product in the Products Grid
	Then I wait for the Product Information Popup to load
	Then I Confirm that Product Information pop up is shown
	Then I call Shared Step 110819 (Home Depot & CVS Only - Product Information pop up - Expand Product Details - Confirm rows)

Scenario Outline: [168573] CVS - Product Lookup  - Export when field selected for export contains a comma in the description
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: RPS.CV
	#Then I confirm the Home tab has loaded
	Given I click the main tab: Product Lookup
	Then I confirm the Product Lookup tab has loaded
	Then I confirm the active tab is: Product Lookup
	Then I call Shared Step 153321 (RPS & WV > More Filters > Select Supplier): QA Squad 2 for RPS, PV, WV and ItemSync
	And I call Shared Step 151361 (Product Lookup - Select Columns - Add new Column to pop up - Click Apply) category: General Filters, filter: Is the need to warn triggered by:
	Then In the Product Lookup Page, I click the Export Button
	Then I save the download folder
	Then I confirm a new file has been downloaded with .csv format and save to context as: output
	Then I Check that there is a new csv file downloaded and save the file path as: output
	Then I check that the file saved as: output contains the following column headings:
		| Heading                           |
		| Product Name                      |
		| UPC Number                        |
		| Product Number                    |
		| Supplier Name                     |
		| Recommended Usage Category Code   |
		| Recommended Use                   |
		| CVS BUCKET                        |
		| US EPA Waste Number               |
		| California Waste Bucket           |
		| CVS California Waste Code         |
		| Is the need to warn triggered by: |
	Then I delete the file saved as output
	And I call Shared Step 106194 (RPS Sign out)