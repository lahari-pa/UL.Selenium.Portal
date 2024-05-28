@RPS
@Login
@run_HomeTab
@LandingPage
@Home
@Shared
@Navigation
@Dashboard
@RecentActivities
@ProductLookUp


Feature: Table Items

Scenario Outline: [169370] Recent Activities - Turnaround Time Column displays
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the Home tab has loaded
	Then I click the main tab: Recent Activities
	Then I confirm the Recent Activities tab has loaded
	And In the recent activities page, I confirm that the product table  has the following column: TurnAround Time

	Examples:
	| Scenario Name                                                  | Retailer |
#| [#169370a] Recent Activities - Turnaround Time Column displays | RPS.TG |
	| [#169370b] Recent Activities - Turnaround Time Column displays | RPS.CV |
#| [#169370c] Recent Activities - Turnaround Time Column displays | RPS.HD |
	| [#169370d] Recent Activities - Turnaround Time Column displays | RPS.CT |
	
Scenario Outline: [169371] Recent Activities - Turnaround Time Column - displays popup
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the Home tab has loaded
	Then I click the main tab: Recent Activities
	Then I confirm the Recent Activities tab has loaded
	And In the recent activities page, I confirm that the product table  has the following column: TurnAround Time
	Then I click on the entry in the Turnaround Time column
	Then I confirm the TurnAround Time Pop up has loaded
	Then I confirm a Turnaround time popup displays
	Then I confirm a Turnaround time popup displays date and Status
	Then I confirm the Turn Around Time pop up header is displayed
	Then I confirm I see a Turn Around Time popup Export button
	Then I confirm I see a Close button in Turnaround time popup
	Then I click the Turn Around Time Export button
	Then I close the turn around time Product Status History popup using the x at the upper right corner

	Examples:
	| Scenario Name                                                  | Retailer |
#| [#169371a] Recent Activities - Turnaround Time Column - displays popups | RPS.TG |
	| [#169371b] Recent Activities - Turnaround Time Column - displays popup | RPS.CV |
#| [#169371c] Recent Activities - Turnaround Time Column - displays popup | RPS.HD |
	| [#169371d] Recent Activities - Turnaround Time Column - displays popup | RPS.CT |
	
Scenario Outline: [169175] Actions - Contact Supplier and View Data links
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the Home tab has loaded
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I click on the View Data Link
	Then I confirm the Product Information Pop up has loaded
	Then I verify that Product Information pop up is displayed
	Then I Close the Product Information Popup

	Examples:
		| Scenario Name                                             | Retailer        | Page               | IsWebviewer |
#		| [#169175a] Actions - Contact Supplier and View Data links | RPS.TG          | Product Lookup     | No          |
#		| [#169175b] Actions - Contact Supplier and View Data links |RPS.TG           | Recent Activities  | No          |
		| [#169175c] Actions - Contact Supplier and View Data links | RPS.CV          | Product Lookup     | No          |
		| [#169175d] Actions - Contact Supplier and View Data links | RPS.CV          | Recent Activities  | No          |
		| [#169175e] Actions - Contact Supplier and View Data links | RPS.LW          | Product Lookup     | No          |
		| [#169175f] Actions - Contact Supplier and View Data links | RPS.LW          | Recent Activities  | No          |
		| [#169175g] Actions - Contact Supplier and View Data links | RPS.SF          |Product Lookup      | No          |
		| [#169175h]Actions - Contact Supplier and View Data linkst | RPS.SF          | Recent Activities  | No          |


Scenario Outline: [169177] Contact Supplier -  displays for all products
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the Home tab has loaded
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then In the product table, I confirm for all products the Action column does include option: Contact Supplier


	Examples:
		| Scenario Name                                                      | Retailer        | Page                       | IsWebviewer |
#		| [#169177a] Actions - Contact Supplier -  displays for all products | RPS.TG          | Product Lookup             | No          |
#		| [#169177b] Actions - Contact Supplier -  displays for all products | RPS.TG          | Recent Activities          | No          |
		| [#169177c] Actions - Contact Supplier -  displays for all products | RPS.CV          | Product Lookup             | No          |
		| [#169177d] Actions - Contact Supplier -  displays for all products | RPS.CV          | Recent Activities          | No          |
		| [#169177e] Actions - Contact Supplier -  displays for all products | RPS.LW          | Product Lookup             | No          |
		| [#169177f] Actions - Contact Supplier -  displays for all products | RPS.LW          | Recent Activities          | No          |
#		| [#169177g] Actions - Contact Supplier -  displays for all products | RPS.LW          |Demo Viewer(RPS)            | No          |
		| [#169177h]Actions - Contact Supplier -  displays for all products  | RPS.SF          | Recent Activities          | No          |
#		| [#169177i] Actions - Contact Supplier -  displays for all products | RPS.TG          | Store Viewer(RPS)          | No          |
#		| [#169177j] Actions - Contact Supplier -  displays for all products | RPS.TG          | Status Viewer(RPS)         | No          |
#		| [#169177k] Actions - Contact Supplier -  displays for all products | RPS.TG          | HQ Viewer(RPS)             | No          |
#		| [#169177l] Actions - Contact Supplier -  displays for all products | RPS.SF          | Store Viewer               | No          |
#		| [#169177m] Actions - Contact Supplier -  displays for all products | RPS.LW          | Drum Log                   | No          |
#		| [#169177n] Actions - Contact Supplier -  displays for all products | RPS.CT          | Classification History     | No          |

Scenario Outline: [169522] Web Viewer - Actions - Contact Supplier Not shown and View Data links
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the Home tab has loaded
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then In the product table, I confirm for all products the Action column does not include option: Contact Supplier
	Then I click on the View Data Link
	Then I confirm the Product Information Pop up has loaded
	Then I verify that Product Information pop up is displayed
	Then I Close the Product Information Popup



	Examples:
		| Scenario Name                                                                    | Retailer        | Page                 | IsWebviewer   |
#		| [#169522a] Web Viewer - Actions - Contact Supplier Not shown and View Data links | RPS.TG          | Target_HQ            | Yes           |
#		| [#169522b] Web Viewer - Actions - Contact Supplier Not shown and View Data links | RPS.TG          | Target_status        | Yes           |
#		| [#169522c] Web Viewer - Actions - Contact Supplier Not shown and View Data links | RPS.TG          | Target_store         | Yes           |
		| [#169522d] Web Viewer - Actions - Contact Supplier Not shown and View Data links | RPS.SF          | SmartFinal_Store     | Yes           |
		| [#169522e]Web Viewer - Actions - Contact Supplier Not shown and View Data links  | RPS.LW          | Demo_Store           | Yes           |
	