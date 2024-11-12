@RPS
@Login
@run_RecentActivites_Layout
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


Feature: Recent Activities - Layout

@ScenarioId:6745
#Removed from regression: 2023/06
@ignore
Scenario: [106628] Base Functionality - Recent Activities page - layout - Staging ticket for CVS user
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: Franky TG User
	#Then I confirm the Home tab has loaded
	Given I click the main tab: Recent Activities
	Then I confirm the Recent Activities tab has loaded
	Then I confirm the top menu bar is displayed with the logged in username
	Then I Check that the current page title is 'Recent Activities'
	Then I Check that the Recent Activities Products Table is showing
	Then I confirm the Recent Activities background color is: grey
	Then I confirm the Recent Activities Text color is: darker grey
	And I confirm the Recent Activities search box is shown
	Then I confirm that the recent activities search box place holder text reads: Product ID / Product Name / UPC Number
	Then I confirm that the recent activities page buttons to the right of the search box are as follows:
		| Buttons            |
		| More Filters       |
		| Reset              |
		| Export to Excel    |
		| Show Legend Status |
	Then I confirm that the recent activities page shows the bread crumb area
	Then I confirm that the recent activities page bread crumb area contains the label: Filters
	And I confirm that the recent activities page bread crumb area contains the label 'Start Date:'
	And I confirm that the recent activities page bread crumb area contains the label 'End Date:'
	Then I confirm that the recent activities page bread crumb area contains the label: Reset
	Then I confirm that the recent activities page headings row has a grey background color
	Then In the recent activities page, I confirm the column labels show a colon (:) icon as the column resize anchor
	Then In the recent activities page, I confirm that the main table has the following columns:
		| Headings             |
		| ID                   |
		| Product Name         |
		| Supplier             |
		| Status               |
		| Most Recent Activity |
		| Actions              |
	And In the Recent Activities page, I confirm that the main table shows data rows
	Then In the recent activities page, I confirm that In the data row to the far left I confirm I see a right facing arrow (Expand arrow)
	Then In the Recent Activities page, I confirm that to the right of the expand arrow I see the product ID
	Then ~~MANUAL CHECK~~ In the Recent Activities page, I confirm that each column of data is aligned to the left of the column
	Then In the Recent Activities page, I confirm that the table shows alternating background color (grey to white)
	Then In the Recent Activities page, below the Most Recent Activity table I confirm: page footer is shown

@ScenarioId:6783
#Removed from regression: 2023/06
@ignore
Scenario: [105057] Base Functionality - Recent Activities - IE11 browser - shows data correctly
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: Franky TG User
	#Then I confirm the Home tab has loaded
	Given I click the main tab: Recent Activities
	Then I confirm the Recent Activities tab has loaded
	Then In the recent activities page, I confirm that the main table has the following columns:
		| Headings             |
		| ID                   |
		| Product Name         |
		| Supplier             |
		| Status               |
		| Most Recent Activity |
		| Actions              |
	Then In the Recent Activities page, I confirm that the main table shows data rows
	Then In the recent activities page, I confirm that the main table contains data in the following columns:
		| Headings             |
		| ID                   |
		| Product Name         |
		| Supplier             |
		| Status               |
		| Most Recent Activity |
		| Actions              |
	And I call Shared Step 106194 (RPS Sign out)

@ScenarioId:6818
#Removed from regression: 2023/06
@ignore
Scenario: [106642] Base Functionality - Recent Activities page - breadcrumbs
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: Franky TG User
	#Then I confirm the Home tab has loaded
	Given I click the main tab: Recent Activities
	Then I confirm the Recent Activities tab has loaded
	Then In the recent Activities page, In the start date breadcrumb the background color is grey
	Then In the recent Activities page, In the Start Date breadcrumb, I confirm text shown: Start Date:
	Then In the recent Activities page, In the Start Date breadcrumb, I confirm text shown: <AnyDate>
	Then In the recent Activities page, In the start date breadcrumb, confirm X is showing
	And In the recent Activities page, In the end date breadcrumb the background color is grey
	Then In the recent Activities page, In the end Date breadcrumb, I confirm text shown: End Date:
	Then In the recent Activities page, In the end Date breadcrumb, I confirm text shown: <AnyDate>
	Then In the recent Activities page, In the end date breadcrumb, confirm X is showing
	Then In the recent Activities page, Confirm Reset Date breadcrumb displays text 'Reset'
	Then In the recent Activities page, In the reset breadcrumb the background color is white
	Then In the recent Activities page, In the reset breadcrumb the text color is black

@ScenarioId:6936
Scenario: [106643] Base Functionality - Recent Activities page - buttons format
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the active tab is: <LandingTab>
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	#Then I confirm the Home tab has loaded
	Given I click the main tab: Recent Activities
	Then I confirm the Recent Activities tab has loaded
	Then In the Recent Activities page, In Confirm the following search buttons are showing:
		| Buttons                    |
		| More Filters               |
		| Reset                      |
		| Export to Excel            |
	Then In the recent Activities page, In the Search Options, the More Filters button has a background color of white
	Then In the recent Activities page, In the Search Options, the More Filters button has a text color of brown
	Then In the recent Activities page, In the Search Options, the Reset button has a background color of white
	Then In the recent Activities page, In the Search Options, the Reset button has a text color of brown
	Then In the recent Activities page, In the Search Options, the Export button has a background color of white
	Then In the recent Activities page, In the Search Options, the Export button has a text color of brown

		Examples:
	| Scenario Name                                                           | Retailer | Page           | IsWebviewer | LandingTab              |
	| [#106643a] Base Functionality - Recent Activities page - buttons format | RPS.LW   | Program Health | No          | LWLandingtab            |
	| [#106643b] Base Functionality - Recent Activities page - buttons format | RPS.CV   | Program Health | No          | Program Health          |
	| [#106643c] Base Functionality - Recent Activities page - buttons format | RPS.TG   | Program Health | No          | Product Lookup          |
	| [#106643d] Base Functionality - Recent Activities page - buttons format | RPS.SF   | Program Health | No          | Program Health          |
#	| [#106643e] Base Functionality - Recent Activities page - buttons format | RPS.PX   | Program Health | No          | Program Health          |
#	| [#106643f] Base Functionality - Recent Activities page - buttons format | RPS.HD   | Program Health | No          | Program Health          |
#	| [#106643g] Base Functionality - Recent Activities page - buttons format | RPS.WM   | Program Health | No          | Program Health          |

@ScenarioId:6937
Scenario: [111157] Base Functionality - Recent Activities page - resize columns
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the active tab is: <LandingTab>
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	#Then I confirm the Home tab has loaded
	Given I click the main tab: Recent Activities
	Then I confirm the Recent Activities tab has loaded
	Then I call Shared Step 111155 (Table Heading or sub heading - confirm column resize anchor - resize column) On the: Recent Activities page, for the column: Status
	Then I call Shared Step 111155 (Table Heading or sub heading - confirm column resize anchor - resize column) On the: Recent Activities page, for the column: Most Recent Activity
	Then I call Shared Step 111155 (Table Heading or sub heading - confirm column resize anchor - resize column) On the: Recent Activities page, for the column: Actions



	Examples:
	| Scenario Name                                                           | Retailer | Page           | IsWebviewer | LandingTab              |
	| [#111157a] Base Functionality - Recent Activities page - resize columns | RPS.LW   | Program Health | No          | LWLandingtab            |
	| [#111157b] Base Functionality - Recent Activities page - resize columns | RPS.CV   | Program Health | No          | Program Health          |
	| [#111157c] Base Functionality - Recent Activities page - resize columns | RPS.TG   | Program Health | No          | Product Lookup          |
	| [#111157d] Base Functionality - Recent Activities page - resize columns | RPS.SF   | Program Health | No          | Program Health          |
#	| [#111157e] Base Functionality - Recent Activities page - resize columns | RPS.PX   | Program Health | No          | Program Health          |
#	| [#111157f] Base Functionality - Recent Activities page - resize columns | RPS.HD   | Program Health | No          | Program Health          |
#	| [#111157g] Base Functionality - Recent Activities page - resize columns | RPS.WM   | Program Health | No          | Program Health          |


@ScenarioId:6967
Scenario: [99209] Base Functionality - Recent Activities - Confirm Most Recent Order
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: Franky TG User
	#Then I confirm the Home tab has loaded
	Given I click the main tab: Recent Activities
	Then I confirm the Recent Activities tab has loaded
	Then In the recent activities page, I click the label 'Start Date'
	Then I confirm the Recent Activities tab has loaded
	And I confirm that the recent activities page bread crumb area does not contain the label 'Start Date:'
	Then In the recent activities Page, In the Products table I confirm the Most Recent Activity column displays in date order, newest first
	And I call Shared Step 106194 (RPS Sign out)

@ScenarioId:11067
Scenario: [104961] Base Functionality - Recent Activities - Most Recent Activity Column shows date only (not time)
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the active tab is: <LandingTab>
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	#Then I confirm the Home tab has loaded
	Given I click the main tab: Recent Activities
	Then I confirm the Recent Activities tab has loaded
	Then In the recent activities Page, In the Products table I confirm the Most Recent Activity column displays dates in the format of yyyy-mm-dd

	Examples:
	| Scenario Name                                                                                              | Retailer | Page           | IsWebviewer | LandingTab              |
	| [#104961a] Base Functionality - Recent Activities - Most Recent Activity Column shows date only (not time) | RPS.LW   | Program Health | No          | LWLandingtab            |
	| [#104961b] Base Functionality - Recent Activities - Most Recent Activity Column shows date only (not time) | RPS.CV   | Program Health | No          | Program Health          |
	| [#104961c] Base Functionality - Recent Activities - Most Recent Activity Column shows date only (not time) | RPS.TG   | Program Health | No          | Product Lookup          |
	| [#104961d] Base Functionality - Recent Activities - Most Recent Activity Column shows date only (not time) | RPS.SF   | Program Health | No          | Program Health          |
#	| [#104961e] Base Functionality - Recent Activities - Most Recent Activity Column shows date only (not time) | RPS.PX   | Program Health | No          | Program Health          |
#	| [#104961f] Base Functionality - Recent Activities - Most Recent Activity Column shows date only (not time) | RPS.HD   | Program Health | No          | Program Health          |
#	| [#104961g] Base Functionality - Recent Activities - Most Recent Activity Column shows date only (not time) | RPS.WM   | Program Health | No          | Program Health          |


@ScenarioId:6980
#Removed from regression: 2023/10
@ignore
#The loading period for the bar is too short to be able to perfomr robust automation on 
Scenario: [104958] Base Functionality - Recent Activities - Page is Loading - indicator shows
	Given RPS Login - Base functionality for TReVor account: <Retailer> and do not wait for load
	Given I click on the tab: Recent Activities and Verify loading dot is displayed

	Examples:
	| Scenario Name                                                                         | Retailer | Page           | IsWebviewer | LandingTab              |
	| [#104958a] Base Functionality - Recent Activities - Page is Loading - indicator shows | RPS.LW   | Program Health | No          | LWLandingtab            |
	| [#104958b] Base Functionality - Recent Activities - Page is Loading - indicator shows | RPS.CV   | Program Health | No          | Program Health          |
	| [#104958c] Base Functionality - Recent Activities - Page is Loading - indicator shows | RPS.TG   | Program Health | No          | Product Lookup          |
	| [#104958d] Base Functionality - Recent Activities - Page is Loading - indicator shows | RPS.SF   | Program Health | No          | Program Health          |
#	| [#104958e] Base Functionality - Recent Activities - Page is Loading - indicator shows | RPS.PX   | Program Health | No          | Program Health          |
#	| [#104958f] Base Functionality - Recent Activities - Page is Loading - indicator shows | RPS.HD   | Program Health | No          | Program Health          |
#	| [#104958g] Base Functionality - Recent Activities - Page is Loading - indicator shows | RPS.WM   | Program Health | No          | Program Health          |


@tfs_design
#The loading period for the bar is too short to be able to perfomr robust automation on 
@ScenarioId:11068
	Scenario: [92215] Base Functionality - Recent Activities - More Filters is unavailable when page is loading


@ScenarioId:6981
Scenario: [99208] Base Functionality - Recent Activities - Validate Date Stamp vs SHA
	#Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: RPS.99
	#Then I confirm the Home tab has loaded
	#Given I click the main tab: Recent Activities
	#Then I confirm the Recent Activities tab has loaded
	#Then In the recent activities page, I click the label 'Start Date'
	#Then I confirm the Recent Activities tab has loaded
	#And In the recent activities Page, In the Products table I select a random product and save product Data to context as: RecentProduct92215
	#sha password is differnt area on TReVor 
	And I call Shared Step 65080 (Login to Studio and Open SHA manager) 
	Then In The SHA products grid I filter for product saved as: RecentProduct92215 and check that last activity date matches the one found in RPS
