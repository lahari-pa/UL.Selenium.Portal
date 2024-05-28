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


Feature: Canadian Tire

Scenario Outline: [179884] Canadian Tire - Menu Links Banner - options
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: RPS.CT
	Given  I confirm the following tabs are displayed:
| Link                    |
| Program Health          |
| Dashboard               |
| Drum Log                |
| Classification History  |
| Recent Activities       |
| ItemSync                |
| Product Lookup          |
| Help & Support          |
   Given I call Shared Step 106194 (RPS Sign out)


Scenario Outline: [180521] RPS - Product Lookup page - layout - Canadian Tire User specific layout 
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: RPS.CT
    Then I click the main tab: Product Lookup
	Then I confirm the page heading banner shows the WERCSmart Product Suite logo and it reads : WERCSmart® Product Suite
	Then I confirm the UL Logo is displayed in the top bar
	And I confirm the user displayed in the top bar matches the active logged in user
	Then I confirm the menu links banner is displayed
	Then I confirm below the menu links banner I see the Product Lookup main page body
	Then I confirm the Product Lookup tab has loaded
	Then I confirm the Product Lookup background color is: grey
	Then I confirm the Product Lookup Text color is: darker grey
	And I confirm the Product Lookup search box is shown
	Then I confirm that the Product Lookup search box place holder text reads: UPC / Product Name / Supplier / WPSID
	Then I confirm that the Product Lookup page buttons to the right of the search box are as follows:
		| Buttons        |
		| More Filters   |
		| Reset          |
		| Select Columns |
    Given In the Product Lookup page I confirm to the right of the buttons I see three trends
		| Trend     |
		| UPCs      |
		| PRODUCTS  |
		| SUPPLIERS |
    Then I confirm the trends graphics shows the % figure
    Given I confirm I do not see the bredcrumbs area under the search field
	Then  I Check that the Product Lookup Products Table is showing
	Then I confirm that the  Product Lookup page headings row has a grey background color
	And In the Product Lookup page, I confirm that the main table shows data rows
	Then In the Product Lookup page, below the Product Lookup table I confirm: page footer is shown
    Given I call Shared Step 106194 (RPS Sign out)

Scenario Outline: [180012] Canadian Tire - Product Lookup - UI - Product Grid
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: RPS.CT
	Then I click the main tab: Product Lookup
	Then I confirm the Product Lookup tab has loaded
	Then In the recent activities page, I confirm that the main table has the following columns:
		| Headings                                                                            |
		| Product Info                                                                        |
		| Packaging Type                                                                      |
		| Packaging Size                                                                      |
		| UPC Level - UPC is for Each or Case                                                 |
		| UPC Level - Code for DOT Packaging                                                  |
		| UPC Level - Code and Description for DOT Packaging                                  |
		| UPC Level - Product Weight Unit of Measure Inner Container                          |
		| UPC Level - Product Weight Value of Package - Inner Container                       |
		| UPC Level - Product Weight Value of Package and Weight of Measure - Inner Container |
		| UPC Level - Product Fluid Unit of Measure - Inner Container                         |
		| UPC Level - Product Fluid Value of Package - Inner Container                        |
		| UPC Level - Product Fluid Value of Package and Unit of Measure - Inner Container    |
		| UPC Level - For Case Packs - Field for the Individual UPC Contained Within the Case |
		| UPC Level - For Case Packs - Field for the Quantity of Individual UPC's in the Case |
		| Actions                                                                             |
   Given I call Shared Step 106194 (RPS Sign out)


Scenario Outline: [179885] RPS - Recent Activities page - layout (includes TAT) - Canadian Tire User specific layout 
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: RPS.CT
	Given I click the main tab: Recent Activities
	And I confirm the active tab is: Recent Activities
	Then I confirm the top menu bar is displayed with the logged in username
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
		| Buttons                                |
		| More Filters                           |
		| Reset                                  |
		| Export to Excel                        |
		| Export Turnaround Time Report to Excel |
	Given In the Product Lookup page I confirm to the right of the buttons I see three trends
		| Trend     |
		| UPCs      |
		| PRODUCTS  |
		| SUPPLIERS |
	Then I confirm the trends graphics do not show the % figure
    Given In the Recent Activites page, I confirm I do not see the breadcrumbs area under the search field
	Then  I Check that the Recent Activities Products Table is showing
	Then I confirm that the recent activities page headings row has a grey background color
	Then In the recent activities page, I confirm that the main table has the following columns:
		| Headings                                                                            |
		| Product Info                                                                        |
		| Most Recent Activity                                                                |
		| Recommended Usage Code                                                              |
		| Recommended Use                                                                     |
		| Package Type                                                                        |
		| Packaging Size                                                                      |
		| Status                                                                              |
		| Turn Around Time                                                                    |
		| Reason                                                                              |
		| UPC                                                                                 |
		| UPC Size                                                                            |
		| UPC Packaging Type                                                                  |
		| UPC Level - UPC is for Each or Case                                                 |
		| UPC Level - Code for DOT Packaging                                                  |
		| UPC Level - Code and Description for DOT Packaging                                  |
		| UPC Level - Product Weight Unit of Measure Inner Container                          |
		| UPC Level - Product Weight Value of Package - Inner Container                       |
		| UPC Level - Product Weight Value of Package and Weight of Measure - Inner Container |
		| UPC Level - Product Fluid Unit of Measure - Inner Container                         |
		| UPC Level - Product Fluid Value of Package - Inner Container                        |
		| UPC Level - Product Fluid Value of Package and Unit of Measure - Inner Container    |
		| UPC Level - For Case Packs - Field for the Individual UPC Contained Within the Case |
		| UPC Level - For Case Packs - Field for the Quantity of Individual UPC's in the Case |
		| Actions                                                                             |
	And In the Recent Activities page, I confirm that the main table shows data rows
	Then In the Recent Activities page, below the Most Recent Activity table I confirm: page footer is shown


Scenario Outline: [179898] Canadian Tire - View Data  - Transportation Data - confirm fields shown
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: RPS.CT
	Then I confirm the Home tab has loaded
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Then I Click the Row actions: View Data for the first product in the Products Grid
	Then I Confirm that Product Information pop up is shown
	Then In the Product Information pop up, I click: Collapse All
	Then I call Shared Step 149247 (Canadian Tire - Product Information pop up - Expand Transportation Data - Confirm rows)


Examples:
		| Scenario Name                                                                             | Page                    | IsWebviewer |
		| [#179898a]  Canadian Tire - View Data  - Transportation Data - confirm fields shown       | Product Lookup          | No          |
		| [#179898b]  Canadian Tire - View Data  - Transportation Data - confirm fields shown       | Recent Activities       | No          |


Scenario Outline: [179897] Canadian Tire - View Data  - Waste - confirm fields shown
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: RPS.CT
	Then I confirm the Home tab has loaded
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Given In the product lookup page, I click the More Filters Button
	Given In the product lookup page, I select the option: Status from the status drop down menu
	Then In the product lookup page, I select the option: Completed from the parameters drop down menu
	Then In the product lookup page More Filters Popup, I Click the the Apply Filter Button
	Given In the product lookup page, I confirm the More Filters popup is not displayed
	Then I Click the Row actions: View Data for the first product in the Products Grid
	Then I Confirm that Product Information pop up is shown
	Then In the Product Information pop up, I click: Collapse All
	Then I call Shared Step 149197 (Canadian Tire - Product Information pop up - Expand Waste - Confirm rows)
	

Examples:
		| Scenario Name                                                               | Page                    | IsWebviewer |
		| [#179897a]  Canadian Tire - View Data  - Waste - confirm fields shown       | Product Lookup          | No          |
		| [#179897b]  Canadian Tire - View Data  - Waste - confirm fields shown       | Recent Activities       | No          |


Scenario Outline: [179895] Canadian Tire - View Data  - Regulatory Data - confirm fields shown
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: RPS.CT
	Then I confirm the Home tab has loaded
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Given In the product lookup page, I click the More Filters Button
	Given In the product lookup page, I select the option: Status from the status drop down menu
	Then In the product lookup page, I select the option: Completed from the parameters drop down menu
	Then In the product lookup page More Filters Popup, I Click the the Apply Filter Button
	Given In the product lookup page, I confirm the More Filters popup is not displayed
	Then I Click the Row actions: View Data for the first product in the Products Grid
	Then I Confirm that Product Information pop up is shown
	Then In the Product Information pop up, I click: Collapse All
	Then I call Shared Step 149119 (Canadian Tire - Product Information pop up - Expand Regulatory Data - Confirm rows)
	

Examples:
		| Scenario Name                                                                         | Page                    | IsWebviewer |
		| [#179895a]  Canadian Tire - View Data  - Regulatory Data - confirm fields shown       | Product Lookup          | No          |
		| [#179895b]  Canadian Tire - View Data  - Regulatory Data - confirm fields shown       | Recent Activities       | No          |


Scenario Outline: [179886] Canadian Tire - View Data  - Product Data - confirm fields shown
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: RPS.CT
	Then I confirm the Home tab has loaded
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Given In the product lookup page, I click the More Filters Button
	Given In the product lookup page, I select the option: Status from the status drop down menu
	Then In the product lookup page, I select the option: Completed from the parameters drop down menu
	Then In the product lookup page More Filters Popup, I Click the the Apply Filter Button
	Given In the product lookup page, I confirm the More Filters popup is not displayed
	Then I Click the Row actions: View Data for the first product in the Products Grid
	Then I Confirm that Product Information pop up is shown
	Then In the Product Information pop up, I click: Collapse All
	Then I call Shared Step 149021 (Canadian Tire - Product Information pop up - Expand Product Data - Confirm rows)
	

Examples:
		| Scenario Name                                                                      | Page                    | IsWebviewer |
		| [#179886a]  Canadian Tire - View Data  - Product Data - confirm fields shown       | Product Lookup          | No          |
		| [#179886b]  Canadian Tire - View Data  - Product Data - confirm fields shown       | Recent Activities       | No          |

Scenario Outline: [179887] Canadian Tire - View Data  - Battery Data codes - confirm fields shown
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: RPS.CT
	Then I confirm the Home tab has loaded
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Given In the product lookup page, I click the More Filters Button
	Given In the product lookup page, I select the option: Status from the status drop down menu
	Then In the product lookup page, I select the option: Completed from the parameters drop down menu
	Then In the product lookup page More Filters Popup, I Click the the Apply Filter Button
	Given In the product lookup page, I confirm the More Filters popup is not displayed
	Then I Click the Row actions: View Data for the first product in the Products Grid
	Then I Confirm that Product Information pop up is shown
	Then In the Product Information pop up, I click: Collapse All
	Then I call Shared Step 149027 (Canadian Tire - Product Information pop up - Expand Battery data codes - Confirm rows)
	

Examples:
		| Scenario Name                                                                            | Page                    | IsWebviewer |
		| [#179887a]  Canadian Tire - View Data  - Battery Data codes - confirm fields shown       | Product Lookup          | No          |
		| [#179887b]  Canadian Tire - View Data  - Battery Data codes - confirm fields shown       | Recent Activities       | No          |

Scenario Outline: [179893] Canadian Tire - View Data  - Pesticide - confirm fields shown
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: RPS.CT
	Then I confirm the Home tab has loaded
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Given In the product lookup page, I click the More Filters Button
	Given In the product lookup page, I select the option: Status from the status drop down menu
	Then In the product lookup page, I select the option: Completed from the parameters drop down menu
	Then In the product lookup page More Filters Popup, I Click the the Apply Filter Button
	Given In the product lookup page, I confirm the More Filters popup is not displayed
	Then I Click the Row actions: View Data for the first product in the Products Grid
	Then I Confirm that Product Information pop up is shown
	Then In the Product Information pop up, I click: Collapse All
	Then I call Shared Step 149077 (Canadian Tire - Product Information pop up - Expand Pesticide - Confirm rows)
	

Examples:
		| Scenario Name                                                                   | Page                    | IsWebviewer |
		| [#179893a]  Canadian Tire - View Data  - Pesticide - confirm fields shown       | Product Lookup          | No          |
		| [#179893b]  Canadian Tire - View Data  - Pesticide - confirm fields shown       | Recent Activities       | No          |




