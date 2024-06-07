@RPS
@Login
@run_HomeTab
@LandingPage
@Home
@Shared
@Navigation
@Dashboard
@ProductLookUP
@RecentActivities
@MoreFilters

Feature: More Filters

Scenario Outline: [169147] More Filters - Facets
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer> 
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Then I call Shared Step 153388 (RPS & WV > More Filters > Facet Counts)
 

	Examples:
		| Scenario Name                       | Retailer        | Page                    | IsWebviewer |
 		| [#169147a]  More Filters - Facets   | RPS.TG          | Product Lookup          | No          |
 		| [#169147b]  More Filters - Facets   | RPS.TG          | Recent Activities       | No          |
		| [#169147c]  More Filters - Facets   | RPS.CV          | Product Lookup          | No          |
		| [#169147d]  More Filters - Facets   | RPS.CV          | Recent Activities       | No          |
		| [#169147e]  More Filters - Facets   | RPS.LW          | Product Lookup          | No          |
		| [#169147f]  More Filters - Facets   | RPS.LW          | Recent Activities       | No          |
		| [#169147g]  More Filters - Facets   | RPS.SF          | Product Lookup          | No          |
# 		| [#169147h]  More Filters - Facets   | RPS.SF          | Recent Activities       | No          |
#		| [#169147i]  More Filters - Facets   | RPS.LW          | Demo Viewer             | Yes         |
#		| [#169147j]  More Filters - Facets   | RPS.TG          | Store Viewer            | Yes         |
#		| [#169147k]  More Filters - Facets   | RPS.TG          | Status Viewer           | Yes         |
#		| [#169147l]  More Filters - Facets   | RPS.TG          | HQ Viewer               | Yes         |
#		| [#169147m]  More Filters - Facets   | RPS.SF          | SmartFinal_Store        | Yes         |
 		| [#169147n]  More Filters - Facets   | RPS.LW          | Lowes_store             | Yes         |
		| [#169147o]  More Filters - Facets   | RPS.CT          | Product Lookup          | No          |
#    	| [#169147p]  More Filters - Facets   | RPS.CT          | Recent Activities       | No          |
#	    | [#169147q]  More Filters - Facets   | RPS.CT          | Classification History  | No          |
 

 Scenario Outline: [169148] More Filters - Supplier Name - exact match
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer> 
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Then I call Shared Step 153323 (RPS & WV > More Filters > Supplier Name > exact match) for Supplier Name: SavedProduct
	Then I call Shared Step 106809 (Breadcrumbs - Supplier Name field - confirm shown correctly and remove) for text: SavedProduct
 
	Examples:
		| Scenario Name                                            | Retailer        | Page                    | IsWebviewer |
 		| [#169148a]  More Filters - Supplier Name - exact match   | RPS.TG          | Product Lookup          | No          |
 		| [#169148b]  More Filters - Supplier Name - exact match   | RPS.TG          | Recent Activities       | No          |
		| [#169148c]  More Filters - Supplier Name - exact match   | RPS.CV          | Product Lookup          | No          |
		| [#169148d]  More Filters - Supplier Name - exact match   | RPS.CV          | Recent Activities       | No          |
		| [#169148e]  More Filters - Supplier Name - exact match   | RPS.LW          | Product Lookup          | No          |
		| [#169148f]  More Filters - Supplier Name - exact match   | RPS.LW          | Recent Activities       | No          |
		| [#169148g]  More Filters - Supplier Name - exact match   | RPS.SF          | Product Lookup          | No          |
 		| [#169148h]  More Filters - Supplier Name - exact match   | RPS.SF          | Recent Activities       | No          |
#		| [#169148i]  More Filters - Supplier Name - exact match   | RPS.LW          | Demo Viewer             | Yes         |
#		| [#169148j]  More Filters - Supplier Name - exact match   | RPS.TG          | Store Viewer            | Yes         |
#		| [#169148k]  More Filters - Supplier Name - exact match   | RPS.TG          | Status Viewer           | Yes         |
#		| [#169148l]  More Filters - Supplier Name - exact match   | RPS.TG          | HQ Viewer               | Yes         |
		| [#169148m]  More Filters - Supplier Name - exact match   | RPS.SF          | SmartFinal_Store        | Yes         |
 		| [#169148n]  More Filters - Supplier Name - exact match   | RPS.LW          | Lowes_store             | Yes         |
		| [#169148o]  More Filters - Supplier Name - exact match   | RPS.CT          | Product Lookup          | No          |
    	| [#169148p]  More Filters - Supplier Name - exact match   | RPS.CT          | Recent Activities       | No          |
#	    | [#169148q]  More Filters - Supplier Name - exact match   | RPS.CT          | Classification History  | No          |


Scenario Outline: [226303] 3 Panel-More Filters - Supplier Name - partial search
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer> 
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Then I call Shared Step 153324 (RPS & WV > More Filters > Supplier Name > Partial search) for Supplier Name: SavedProduct
	Then I call Shared Step 106809 (Breadcrumbs - Supplier Name field - confirm shown correctly and remove) for text: SavedProduct
 
	Examples:
		| Scenario Name                                                       | Retailer        | Page                    | IsWebviewer |
 		| [#226303a]  3 Panel-More Filters - Supplier Name - partial search   | RPS.TG          | Product Lookup          | No          |
 		| [#226303b]  3 Panel-More Filters - Supplier Name - partial search   | RPS.TG          | Recent Activities       | No          |
		| [#226303c]  3 Panel-More Filters - Supplier Name - partial search   | RPS.CV          | Product Lookup          | No          |
		| [#226303d]  3 Panel-More Filters - Supplier Name - partial search   | RPS.CV          | Recent Activities       | No          |
		| [#226303e]  3 Panel-More Filters - Supplier Name - partial search   | RPS.LW          | Product Lookup          | No          |
		| [#226303f]  3 Panel-More Filters - Supplier Name - partial search   | RPS.LW          | Recent Activities       | No          |
		| [#226303g]  3 Panel-More Filters - Supplier Name - partial search   | RPS.SF          | Product Lookup          | No          |
 		| [#226303h]  3 Panel-More Filters - Supplier Name - partial search   | RPS.SF          | Recent Activities       | No          |
#		| [#226303i]  3 Panel-More Filters - Supplier Name - partial search   | RPS.LW          | Demo Viewer             | Yes         |
#		| [#226303j]  3 Panel-More Filters - Supplier Name - partial search   | RPS.TG          | Store Viewer            | Yes         |
#		| [#226303k]  3 Panel-More Filters - Supplier Name - partial search   | RPS.TG          | Status Viewer           | Yes         |
#		| [#226303l]  3 Panel-More Filters - Supplier Name - partial search   | RPS.TG          | HQ Viewer               | Yes         |
		| [#226303m]  3 Panel-More Filters - Supplier Name - partial search   | RPS.SF          | SmartFinal_Store        | Yes         |
# 		| [#226303n]  3 Panel-More Filters - Supplier Name - partial search   | RPS.LW          | Lowes_store             | Yes         |
#		| [#226303o]  3 Panel-More Filters - Supplier Name - partial search   | RPS.CT          | Product Lookup          | No          |
#   	| [#226303p]  3 Panel-More Filters - Supplier Name - partial search   | RPS.CT          | Recent Activities       | No          |
#	    | [#226303q]  3 Panel-More Filters - Supplier Name - partial search   | RPS.CT          | Classification History  | No          |

Scenario Outline: [169159] More Filters - Supplier Name - reloads on Clear All filters
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer> 
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Then I call Shared Step 167119 (RPS & WV > More Filters > Supplier Name, Packaging Type and Packaging Size > Apply filter)
	Then I confirm the page has refreshed
	Then In the recent activities Page, I click the More Filters Button
	Then In the More Filters popup I see the Selected Filters area
	Then In the More Filters pop up, In the Selected Filters area I click Clear All to remove all filters
	Then In the More Filters popup I do not see the Selected Filters area
	Then In the product lookup page More Filters Popup, I Click the the Apply Filter Button
	Then I confirm the page has refreshed

 
	Examples:
		| Scenario Name                                                             | Retailer        | Page                    | IsWebviewer |
 		| [#169159a]  More Filters - Supplier Name - reloads on Clear All filters   | RPS.TG          | Product Lookup          | No          |
 		| [#169159b]  More Filters - Supplier Name - reloads on Clear All filters   | RPS.TG          | Recent Activities       | No          |
#		| [#169159c]  More Filters - Supplier Name - reloads on Clear All filters   | RPS.CV          | Product Lookup          | No          |
		| [#169159d]  More Filters - Supplier Name - reloads on Clear All filters   | RPS.CV          | Recent Activities       | No          |
		| [#169159e]  More Filters - Supplier Name - reloads on Clear All filters   | RPS.LW          | Product Lookup          | No          |
		| [#169159f]  More Filters - Supplier Name - reloads on Clear All filters   | RPS.LW          | Recent Activities       | No          |
		| [#169159g]  More Filters - Supplier Name - reloads on Clear All filters   | RPS.SF          | Product Lookup          | No          |
 		| [#169159h]  More Filters - Supplier Name - reloads on Clear All filters   | RPS.SF          | Recent Activities       | No          |
#		| [#169159i]  More Filters - Supplier Name - reloads on Clear All filters   | RPS.LW          | Demo Viewer             | Yes         |
#		| [#169159j]  More Filters - Supplier Name - reloads on Clear All filters   | RPS.TG          | Store Viewer            | Yes         |
#		| [#169159k]  More Filters - Supplier Name - reloads on Clear All filters   | RPS.TG          | Status Viewer           | Yes         |
#		| [#169159l]  More Filters - Supplier Name - reloads on Clear All filters   | RPS.TG          | HQ Viewer               | Yes         |
		| [#169159m]  More Filters - Supplier Name - reloads on Clear All filters   | RPS.SF          | SmartFinal_Store        | Yes         |
 		| [#169159n]  More Filters - Supplier Name - reloads on Clear All filters   | RPS.LW          | Lowes_store             | Yes         |
		| [#169159o]  More Filters - Supplier Name - reloads on Clear All filters   | RPS.CT          | Product Lookup          | No          |
#    	| [#169159p]  More Filters - Supplier Name - reloads on Clear All filters   | RPS.CT          | Recent Activities       | No          |
#	    | [#169159q]  More Filters - Supplier Name - reloads on Clear All filters   | RPS.CT          | Classification History  | No          |
  
 Scenario Outline: [224886] 3 Panel-More Filters - UPC Number - Contains
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer> 
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Then I call Shared Step 205641 (More Filters > UPC Number > Format checks)
	Then I call Shared Step 205642 (More Filters > UPC Number > Contains check)
	Then I call Shared Step 205643 (More Filters > UPC Number > Select filter values and apply)
	Then I confirm the page has refreshed
	Then I confirm that the recent activities page bread crumb area contains the label: UPC Number

 
	Examples:
		| Scenario Name                                              | Retailer        | Page                    | IsWebviewer |
 		| [#224886a]  3 Panel-More Filters - UPC Number - Contains   | RPS.TG          | Product Lookup          | No          |
 		| [#224886b]  3 Panel-More Filters - UPC Number - Contains   | RPS.TG          | Recent Activities       | No          |
		| [#224886c]  3 Panel-More Filters - UPC Number - Contains   | RPS.CV          | Product Lookup          | No          |
		| [#224886d]  3 Panel-More Filters - UPC Number - Contains   | RPS.CV          | Recent Activities       | No          |
		| [#224886e]  3 Panel-More Filters - UPC Number - Contains   | RPS.LW          | Product Lookup          | No          |
		| [#224886f]  3 Panel-More Filters - UPC Number - Contains   | RPS.LW          | Recent Activities       | No          |
		| [#224886g]  3 Panel-More Filters - UPC Number - Contains   | RPS.SF          | Product Lookup          | No          |
 		| [#224886h]  3 Panel-More Filters - UPC Number - Contains   | RPS.SF          | Recent Activities       | No          |
#		| [#224886i]  3 Panel-More Filters - UPC Number - Contains   | RPS.LW          | Demo Viewer             | Yes         |
#		| [#224886j]  3 Panel-More Filters - UPC Number - Contains   | RPS.TG          | Store Viewer            | Yes         |
#		| [#224886k]  3 Panel-More Filters - UPC Number - Contains   | RPS.TG          | Status Viewer           | Yes         |
#		| [#224886l]  3 Panel-More Filters - UPC Number - Contains   | RPS.TG          | HQ Viewer               | Yes         |
		| [#224886m]  3 Panel-More Filters - UPC Number - Contains   | RPS.SF          | SmartFinal_Store        | Yes         |
 		| [#224886n]  3 Panel-More Filters - UPC Number - Contains   | RPS.LW          | Lowes_store             | Yes         |
		| [#224886o]  3 Panel-More Filters - UPC Number - Contains   | RPS.CT          | Product Lookup          | No          |
    	| [#224886p]  3 Panel-More Filters - UPC Number - Contains   | RPS.CT          | Recent Activities       | No          |
#	    | [#224886q]  3 Panel-More Filters - UPC Number - Contains   | RPS.CT          | Classification History  | No          |

Scenario Outline: [224887] 3 Panel-More Filters - UPC Number - Starts with
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer> 
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Then I call Shared Step 205641 (More Filters > UPC Number > Format checks)
	Then I call Shared Step 205648 (More Filters > UPC Number > Starts with check)
	Then I call Shared Step 205643 (More Filters > UPC Number > Select filter values and apply)
	Then I confirm the page has refreshed
	Then I confirm that the recent activities page bread crumb area contains the label: UPC Number

 
	Examples:
		| Scenario Name                                                 | Retailer        | Page                    | IsWebviewer |
 		| [#224887a]  3 Panel-More Filters - UPC Number - Starts with   | RPS.TG          | Product Lookup          | No          |
# 		| [#224887b]  3 Panel-More Filters - UPC Number - Starts with   | RPS.TG          | Recent Activities       | No          |
		| [#224887c]  3 Panel-More Filters - UPC Number - Starts with   | RPS.CV          | Product Lookup          | No          |
#		| [#224887d]  3 Panel-More Filters - UPC Number - Starts with   | RPS.CV          | Recent Activities       | No          |
		| [#224887e]  3 Panel-More Filters - UPC Number - Starts with   | RPS.LW          | Product Lookup          | No          |
#		| [#224887f]  3 Panel-More Filters - UPC Number - Starts with   | RPS.LW          | Recent Activities       | No          |
		| [#224887g]  3 Panel-More Filters - UPC Number - Starts with   | RPS.SF          | Product Lookup          | No          |
# 		| [#224887h]  3 Panel-More Filters - UPC Number - Starts with   | RPS.SF          | Recent Activities       | No          |
#		| [#224887i]  3 Panel-More Filters - UPC Number - Starts with   | RPS.LW          | Demo Viewer             | Yes         |
#		| [#224887j]  3 Panel-More Filters - UPC Number - Starts with   | RPS.TG          | Store Viewer            | Yes         |
#		| [#224887k]  3 Panel-More Filters - UPC Number - Starts with   | RPS.TG          | Status Viewer           | Yes         |
#		| [#224887l]  3 Panel-More Filters - UPC Number - Starts with   | RPS.TG          | HQ Viewer               | Yes         |
#		| [#224887m]  3 Panel-More Filters - UPC Number - Starts with   | RPS.SF          | SmartFinal_Store        | Yes         |
 		| [#224887n]  3 Panel-More Filters - UPC Number - Starts with   | RPS.LW          | Lowes_store             | Yes         |
		| [#224887o]  3 Panel-More Filters - UPC Number - Starts with   | RPS.CT          | Product Lookup          | No          |
    	| [#224887p]  3 Panel-More Filters - UPC Number - Starts with   | RPS.CT          | Recent Activities       | No          |
#	    | [#224887q]  3 Panel-More Filters - UPC Number - Starts with   | RPS.CT          | Classification History  | No          |

Scenario Outline: [224888] 3 Panel-More Filters - UPC Number - Is 
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer> 
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Then I call Shared Step 205641 (More Filters > UPC Number > Format checks)
	Then I call Shared Step 205650 (More Filters > UPC Number - Is check) for UPC Number: SavedProduct
	Then I call Shared Step 205643 (More Filters > UPC Number > Select filter values and apply)
	Then I confirm the page has refreshed
	Then I confirm that the recent activities page bread crumb area contains the label: UPC Number

 
	Examples:
		| Scenario Name                                         | Retailer        | Page                    | IsWebviewer |
 		| [#224888a]  3 Panel-More Filters - UPC Number - Is    | RPS.TG          | Product Lookup          | No          |
  		| [#224888b]  3 Panel-More Filters - UPC Number - Is    | RPS.TG          | Recent Activities       | No          |
		| [#224888c]  3 Panel-More Filters - UPC Number - Is    | RPS.CV          | Product Lookup          | No          |
 		| [#224888d]  3 Panel-More Filters - UPC Number - Is    | RPS.CV          | Recent Activities       | No          |
		| [#224888e]  3 Panel-More Filters - UPC Number - Is    | RPS.LW          | Product Lookup          | No          |
 		| [#224888f]  3 Panel-More Filters - UPC Number - Is    | RPS.LW          | Recent Activities       | No          |
		| [#224888g]  3 Panel-More Filters - UPC Number - Is    | RPS.SF          | Product Lookup          | No          |
  		| [#224888h]  3 Panel-More Filters - UPC Number - Is    | RPS.SF          | Recent Activities       | No          |
#		| [#224888i]  3 Panel-More Filters - UPC Number - Is    | RPS.LW          | Demo Viewer             | Yes         |
#		| [#224888j]  3 Panel-More Filters - UPC Number - Is    | RPS.TG          | Store Viewer            | Yes         |
#		| [#224888k]  3 Panel-More Filters - UPC Number - Is    | RPS.TG          | Status Viewer           | Yes         |
#		| [#224888l]  3 Panel-More Filters - UPC Number - Is    | RPS.TG          | HQ Viewer               | Yes         |
#		| [#224888m]  3 Panel-More Filters - UPC Number - Is    | RPS.SF          | SmartFinal_Store        | Yes         |
 		| [#224888n]  3 Panel-More Filters - UPC Number - Is    | RPS.LW          | Lowes_store             | Yes         |
		| [#224888o]  3 Panel-More Filters - UPC Number - Is    | RPS.CT          | Product Lookup          | No          |
    	| [#224888p]  3 Panel-More Filters - UPC Number - Is    | RPS.CT          | Recent Activities       | No          |
#	    | [#224888q]  3 Panel-More Filters - UPC Number - Is    | RPS.CT          | Classification History  | No          |


 Scenario Outline: [224889] 3 Panel-More Filters - UPC Number - No Results found when parameter already selected
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer> 
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Then I call Shared Step 205641 (More Filters > UPC Number > Format checks)
	Then I call Shared Step 205642 (More Filters > UPC Number > Contains check)
	Then I call Shared Step 205643 (More Filters > UPC Number > Select filter values and apply)
	Then I confirm the page has refreshed
	Then I confirm that the recent activities page bread crumb area contains the label: UPC Number
    Then In the recent activities Page, I click the More Filters Button
	Then In the Product Lookup Page, The More Filters Popup is showing
	Then In the More Filters pop up, I confirm in the Selected Filters area, that breadcrumb shows with the selected value: UPC Number
	And In the More Filters pop up, I enter value in search box in the Filter Categories column: UPC Number
	Then In the More Filters pop up, I confirm searched filter is displayed in Filters Panel : UPC Number
	Then In the More Filters pop up, I click on searched filter in Filters Panel : UPC Number
	Then In the More Filters pop up, I confirm the Filter Parameter panel shows the search field for UPCs
	Then In the More Filters pop up, UPCs I selected earlier are shown at the top of the Search results area with a minus icon in a circle next to each selected UPCs 
	Then In the More Filters pop up, I now type a string of numbers in UPC Number search field: 999999909
	Then I confirm I see the No results found message below the drop down and Search field
	Then In the More Filters pop up, UPCs I selected earlier are shown at the top of the Search results area with a minus icon in a circle next to each selected UPCs 
	Then In the product lookup page More Filters Popup, I Click the Close button
    Then In the Product Lookup Page, The More Filters Popup is not showing
	Examples:
		| Scenario Name                                                                                      | Retailer        | Page                    | IsWebviewer |
 		| [#224889a]  3 Panel-More Filters - UPC Number - No Results found when parameter already selected   | RPS.TG          | Product Lookup          | No          |
 		| [#224889b]  3 Panel-More Filters - UPC Number - No Results found when parameter already selected   | RPS.TG          | Recent Activities       | No          |
		| [#224889c]  3 Panel-More Filters - UPC Number - No Results found when parameter already selected   | RPS.CV          | Product Lookup          | No          |
		| [#224889d]  3 Panel-More Filters - UPC Number - No Results found when parameter already selected   | RPS.CV          | Recent Activities       | No          |
		| [#224889e]  3 Panel-More Filters - UPC Number - No Results found when parameter already selected   | RPS.LW          | Product Lookup          | No          |
		| [#224889f]  3 Panel-More Filters - UPC Number - No Results found when parameter already selected   | RPS.LW          | Recent Activities       | No          |
		| [#224889g]  3 Panel-More Filters - UPC Number - No Results found when parameter already selected   | RPS.SF          | Product Lookup          | No          |
 		| [#224889h]  3 Panel-More Filters - UPC Number - No Results found when parameter already selected   | RPS.SF          | Recent Activities       | No          |
#		| [#224889i]  3 Panel-More Filters - UPC Number - No Results found when parameter already selected   | RPS.LW          | Demo Viewer             | Yes         |
#		| [#224889j]  3 Panel-More Filters - UPC Number - No Results found when parameter already selected   | RPS.TG          | Store Viewer            | Yes         |
#		| [#224889k]  3 Panel-More Filters - UPC Number - No Results found when parameter already selected   | RPS.TG          | Status Viewer           | Yes         |
#		| [#224889l]  3 Panel-More Filters - UPC Number - No Results found when parameter already selected   | RPS.TG          | HQ Viewer               | Yes         |
		| [#224889m]  3 Panel-More Filters - UPC Number - No Results found when parameter already selected   | RPS.SF          | SmartFinal_Store        | Yes         |
 		| [#224889n]  3 Panel-More Filters - UPC Number - No Results found when parameter already selected   | RPS.LW          | Lowes_store             | Yes         |
		| [#224889o]  3 Panel-More Filters - UPC Number - No Results found when parameter already selected   | RPS.CT          | Product Lookup          | No          |
    	| [#224889p]  3 Panel-More Filters - UPC Number - No Results found when parameter already selected   | RPS.CT          | Recent Activities       | No          |
#	    | [#224889q]  3 Panel-More Filters - UPC Number - No Results found when parameter already selected   | RPS.CT          | Classification History  | No          |


Scenario Outline: [224897] 3 Panel-More Filters - Checklist fields - Contains
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer> 
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Then I call Shared Step 205105 (More Filters > Checklist Field > Format checks)
	Then I call Shared Step 205106 (More Filters > Checklist Field - Contains check)
	Then I call Shared Step 205107 (More Filters > Checklist Fields - Select filter values and Apply)
	Then I confirm the page has refreshed
	Then I confirm that the recent activities page bread crumb area contains the label: Packaging Type

 
	Examples:
		| Scenario Name                                                    | Retailer        | Page                    | IsWebviewer |
 		| [#224897a]  3 Panel-More Filters - Checklist fields - Contains   | RPS.TG          | Product Lookup          | No          |
 		| [#224897b]  3 Panel-More Filters - Checklist fields - Contains   | RPS.TG          | Recent Activities       | No          |
#		| [#224897c]  3 Panel-More Filters - Checklist fields - Contains   | RPS.CV          | Product Lookup          | No          |
		| [#224897d]  3 Panel-More Filters - Checklist fields - Contains   | RPS.CV          | Recent Activities       | No          |
		| [#224897e]  3 Panel-More Filters - Checklist fields - Contains   | RPS.LW          | Product Lookup          | No          |
		| [#224897f]  3 Panel-More Filters - Checklist fields - Contains   | RPS.LW          | Recent Activities       | No          |
		| [#224897g]  3 Panel-More Filters - Checklist fields - Contains   | RPS.SF          | Product Lookup          | No          |
 		| [#224897h]  3 Panel-More Filters - Checklist fields - Contains   | RPS.SF          | Recent Activities       | No          |
#		| [#224897i]  3 Panel-More Filters - Checklist fields - Contains   | RPS.LW          | Demo Viewer             | Yes         |
#		| [#224897j]  3 Panel-More Filters - Checklist fields - Contains   | RPS.TG          | Store Viewer            | Yes         |
#		| [#224897k]  3 Panel-More Filters - Checklist fields - Contains   | RPS.TG          | Status Viewer           | Yes         |
#		| [#224897l]  3 Panel-More Filters - Checklist fields - Contains   | RPS.TG          | HQ Viewer               | Yes         |
		| [#224897m]  3 Panel-More Filters - Checklist fields - Contains   | RPS.SF          | SmartFinal_Store        | Yes         |
 		| [#224897n]  3 Panel-More Filters - Checklist fields - Contains   | RPS.LW          | Lowes_store             | Yes         |
		| [#224897o]  3 Panel-More Filters - Checklist fields - Contains   | RPS.CT          | Product Lookup          | No          |
#    	| [#224897p]  3 Panel-More Filters - Checklist fields - Contains   | RPS.CT          | Recent Activities       | No          |
#	    | [#224897q]  3 Panel-More Filters - Checklist fields - Contains   | RPS.CT          | Classification History  | No          |


Scenario Outline: [224898] 3 Panel-More Filters - Checklist fields - Starts with 
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer> 
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Then I call Shared Step 205105 (More Filters > Checklist Field > Format checks)
	Then I call Shared Step 205108 (More Filters > Checklist Field > Starts with check)
	Then I call Shared Step 205107 (More Filters > Checklist Fields - Select filter values and Apply)
	Then I confirm the page has refreshed
	Then I confirm that the recent activities page bread crumb area contains the label: Packaging Type

 
	Examples:
		| Scenario Name                                                        | Retailer        | Page                    | IsWebviewer |
 		| [#224898a]  3 Panel-More Filters - Checklist fields - Starts with    | RPS.TG          | Product Lookup          | No          |
 		| [#224898b]  3 Panel-More Filters - Checklist fields - Starts with    | RPS.TG          | Recent Activities       | No          |
#		| [#224898c]  3 Panel-More Filters - Checklist fields - Starts with    | RPS.CV          | Product Lookup          | No          |
		| [#224898d]  3 Panel-More Filters - Checklist fields - Starts with    | RPS.CV          | Recent Activities       | No          |
		| [#224898e]  3 Panel-More Filters - Checklist fields - Starts with    | RPS.LW          | Product Lookup          | No          |
		| [#224898f]  3 Panel-More Filters - Checklist fields - Starts with    | RPS.LW          | Recent Activities       | No          |
		| [#224898g]  3 Panel-More Filters - Checklist fields - Starts with    | RPS.SF          | Product Lookup          | No          |
 		| [#224898h]  3 Panel-More Filters - Checklist fields - Starts with    | RPS.SF          | Recent Activities       | No          |
#		| [#224898i]  3 Panel-More Filters - Checklist fields - Starts with    | RPS.LW          | Demo Viewer             | Yes         |
#		| [#224898j]  3 Panel-More Filters - Checklist fields - Starts with    | RPS.TG          | Store Viewer            | Yes         |
#		| [#224898k]  3 Panel-More Filters - Checklist fields - Starts with    | RPS.TG          | Status Viewer           | Yes         |
#		| [#224898l]  3 Panel-More Filters - Checklist fields - Starts with    | RPS.TG          | HQ Viewer               | Yes         |
		| [#224898m]  3 Panel-More Filters - Checklist fields - Starts with    | RPS.SF          | SmartFinal_Store        | Yes         |
 		| [#224898n]  3 Panel-More Filters - Checklist fields - Starts with    | RPS.LW          | Lowes_store             | Yes         |
		| [#224898o]  3 Panel-More Filters - Checklist fields - Starts with    | RPS.CT          | Product Lookup          | No          |
#    	| [#224898p]  3 Panel-More Filters - Checklist fields - Starts with    | RPS.CT          | Recent Activities       | No          |
#	    | [#224898q]  3 Panel-More Filters - Checklist fields - Starts with    | RPS.CT          | Classification History  | No          |

Scenario Outline: [224899] 3 Panel-More Filters - Checklist fields - Is
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer> 
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Then I call Shared Step 205105 (More Filters > Checklist Field > Format checks)
	Then I call Shared Step 205111 (More Filters > Checklist Field - Is check) for Packaging Type: SavedProduct
	Then I call Shared Step 205107 (More Filters > Checklist Fields - Select filter values and Apply)
	Then I confirm the page has refreshed
	Then I confirm that the recent activities page bread crumb area contains the label: Packaging Type

 
	Examples:
		| Scenario Name                                               | Retailer        | Page                    | IsWebviewer |
 		| [#224899a]  3 Panel-More Filters - Checklist fields - Is    | RPS.TG          | Product Lookup          | No          |
 		| [#224899b]  3 Panel-More Filters - Checklist fields - Is    | RPS.TG          | Recent Activities       | No          |
#		| [#224899c]  3 Panel-More Filters - Checklist fields - Is    | RPS.CV          | Product Lookup          | No          |
		| [#224899d]  3 Panel-More Filters - Checklist fields - Is    | RPS.CV          | Recent Activities       | No          |
		| [#224899e]  3 Panel-More Filters - Checklist fields - Is    | RPS.LW          | Product Lookup          | No          |
		| [#224899f]  3 Panel-More Filters - Checklist fields - Is    | RPS.LW          | Recent Activities       | No          |
		| [#224899g]  3 Panel-More Filters - Checklist fields - Is    | RPS.SF          | Product Lookup          | No          |
 		| [#224899h]  3 Panel-More Filters - Checklist fields - Is    | RPS.SF          | Recent Activities       | No          |
#		| [#224899i]  3 Panel-More Filters - Checklist fields - Is    | RPS.LW          | Demo Viewer             | Yes         |
#		| [#224899j]  3 Panel-More Filters - Checklist fields - Is    | RPS.TG          | Store Viewer            | Yes         |
#		| [#224899k]  3 Panel-More Filters - Checklist fields - Is    | RPS.TG          | Status Viewer           | Yes         |
#		| [#224899l]  3 Panel-More Filters - Checklist fields - Is    | RPS.TG          | HQ Viewer               | Yes         |
		| [#224899m]  3 Panel-More Filters - Checklist fields - Is    | RPS.SF          | SmartFinal_Store        | Yes         |
 		| [#224899n]  3 Panel-More Filters - Checklist fields - Is    | RPS.LW          | Lowes_store             | Yes         |
		| [#224899o]  3 Panel-More Filters - Checklist fields - Is    | RPS.CT          | Product Lookup          | No          |
#    	| [#224899p]  3 Panel-More Filters - Checklist fields - Is    | RPS.CT          | Recent Activities       | No          |
#	    | [#224899q]  3 Panel-More Filters - Checklist fields - Is    | RPS.CT          | Classification History  | No          |


Scenario Outline: [225879] 3 Panel-More Filters- Suppliers Name- Default Dropdown- Contains
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer> 
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Then In the recent activities Page, I click the More Filters Button
	Then In the recent activities Page, The More Filters Popup is showing 
	And In the More Filters pop up, I enter value in search box in the Filter Categories column: Supplier Name
	Then In the More Filters pop up, I confirm searched filter is displayed in Filters Panel : Supplier Name
	Then In the More Filters pop up, I click on searched filter in Filters Panel : Supplier Name
	Then In the More Filters pop up, I confirm the Filters Parameter panel populates with a list of Supplier Names
	Then In the More Filters pop up, I confirm I see Search under the filter parameter heading
	Then In the More Filters pop up, I confirm the left side of the search box, there is a dropdown box
	Then In the More Filters pop up, I confirm default value of the dropdown box is Contains
	Then In the product lookup page More Filters Popup, I Click the Close button
 
	Examples:
		| Scenario Name                                                                   | Retailer        | Page                    | IsWebviewer |
 		| [#225879a]  3 Panel-More Filters- Suppliers Name- Default Dropdown- Contains    | RPS.TG          | Product Lookup          | No          |
 		| [#225879b]  3 Panel-More Filters- Suppliers Name- Default Dropdown- Contains    | RPS.TG          | Recent Activities       | No          |
 		| [#225879c]  3 Panel-More Filters- Suppliers Name- Default Dropdown- Contains    | RPS.CV          | Product Lookup          | No          |
		| [#225879d]  3 Panel-More Filters- Suppliers Name- Default Dropdown- Contains    | RPS.CV          | Recent Activities       | No          |
		| [#225879e]  3 Panel-More Filters- Suppliers Name- Default Dropdown- Contains    | RPS.LW          | Product Lookup          | No          |
		| [#225879f]  3 Panel-More Filters- Suppliers Name- Default Dropdown- Contains    | RPS.LW          | Recent Activities       | No          |
		| [#225879g]  3 Panel-More Filters- Suppliers Name- Default Dropdown- Contains    | RPS.SF          | Product Lookup          | No          |
 		| [#225879h]  3 Panel-More Filters- Suppliers Name- Default Dropdown- Contains    | RPS.SF          | Recent Activities       | No          |
#		| [#225879i]  3 Panel-More Filters- Suppliers Name- Default Dropdown- Contains    | RPS.LW          | Demo Viewer             | Yes         |
#		| [#225879j]  3 Panel-More Filters- Suppliers Name- Default Dropdown- Contains    | RPS.TG          | Store Viewer            | Yes         |
#		| [#225879k]  3 Panel-More Filters- Suppliers Name- Default Dropdown- Contains    | RPS.TG          | Status Viewer           | Yes         |
#		| [#225879l]  3 Panel-More Filters- Suppliers Name- Default Dropdown- Contains    | RPS.TG          | HQ Viewer               | Yes         |
		| [#225879m]  3 Panel-More Filters- Suppliers Name- Default Dropdown- Contains    | RPS.SF          | SmartFinal_Store        | Yes         |
 		| [#225879n]  3 Panel-More Filters- Suppliers Name- Default Dropdown- Contains    | RPS.LW          | Lowes_store             | Yes         |
		| [#225879o]  3 Panel-More Filters- Suppliers Name- Default Dropdown- Contains    | RPS.CT          | Product Lookup          | No          |
#    	| [#225879p]  3 Panel-More Filters- Suppliers Name- Default Dropdown- Contains    | RPS.CT          | Recent Activities       | No          |
#	    | [#225879q]  3 Panel-More Filters- Suppliers Name- Default Dropdown- Contains    | RPS.CT          | Classification History  | No          |

Scenario Outline: [225824] 3 Panel-More Filters- Suppliers Name- Contains/Start With/Is- Layout
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer> 
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Then In the recent activities Page, I click the More Filters Button
	Then In the recent activities Page, The More Filters Popup is showing 
	And In the More Filters pop up, I enter value in search box in the Filter Categories column: Supplier Name
	Then In the More Filters pop up, I confirm searched filter is displayed in Filters Panel : Supplier Name
	Then In the More Filters pop up, I click on searched filter in Filters Panel : Supplier Name
	Then In the More Filters pop up, I confirm the Filters Parameter panel populates with a list of Supplier Names
	Then In the More Filters pop up, I confirm I see Search under the filter parameter heading
	Then In the More Filters pop up, I confirm the left side of the search box, there is a dropdown box
	Then In the More Filters pop up, I confirm default value of the dropdown box is Contains
	Then In the More Filters pop up, I confirm in the Filter Parameter Panel Selector three options are : Contains, Start With and Is are displayed
	Then In the product lookup page More Filters Popup, I Click the Close button
 
	Examples:
		| Scenario Name                                                                       | Retailer        | Page                    | IsWebviewer |
 		| [#225824a]  3 Panel-More Filters- Suppliers Name- Contains/Start With/Is- Layout    | RPS.TG          | Product Lookup          | No          |
 		| [#225824b]  3 Panel-More Filters- Suppliers Name- Contains/Start With/Is- Layout    | RPS.TG          | Recent Activities       | No          |
 		| [#225824c]  3 Panel-More Filters- Suppliers Name- Contains/Start With/Is- Layout    | RPS.CV          | Product Lookup          | No          |
		| [#225824d]  3 Panel-More Filters- Suppliers Name- Contains/Start With/Is- Layout    | RPS.CV          | Recent Activities       | No          |
		| [#225824e]  3 Panel-More Filters- Suppliers Name- Contains/Start With/Is- Layout    | RPS.LW          | Product Lookup          | No          |
		| [#225824f]  3 Panel-More Filters- Suppliers Name- Contains/Start With/Is- Layout    | RPS.LW          | Recent Activities       | No          |
		| [#225824g]  3 Panel-More Filters- Suppliers Name- Contains/Start With/Is- Layout    | RPS.SF          | Product Lookup          | No          |
 		| [#225824h]  3 Panel-More Filters- Suppliers Name- Contains/Start With/Is- Layout    | RPS.SF          | Recent Activities       | No          |
#		| [#225824i]  3 Panel-More Filters- Suppliers Name- Contains/Start With/Is- Layout    | RPS.LW          | Demo Viewer             | Yes         |
#		| [#225824j]  3 Panel-More Filters- Suppliers Name- Contains/Start With/Is- Layout    | RPS.TG          | Store Viewer            | Yes         |
#		| [#225824k]  3 Panel-More Filters- Suppliers Name- Contains/Start With/Is- Layout    | RPS.TG          | Status Viewer           | Yes         |
#		| [#225824l]  3 Panel-More Filters- Suppliers Name- Contains/Start With/Is- Layout    | RPS.TG          | HQ Viewer               | Yes         |
		| [#225824m]  3 Panel-More Filters- Suppliers Name- Contains/Start With/Is- Layout    | RPS.SF          | SmartFinal_Store        | Yes         |
 		| [#225824n]  3 Panel-More Filters- Suppliers Name- Contains/Start With/Is- Layout    | RPS.LW          | Lowes_store             | Yes         |
		| [#225824o]  3 Panel-More Filters- Suppliers Name- Contains/Start With/Is- Layout    | RPS.CT          | Product Lookup          | No          |
#    	| [#225824p]  3 Panel-More Filters- Suppliers Name- Contains/Start With/Is- Layout    | RPS.CT          | Recent Activities       | No          |
#	    | [#225824q]  3 Panel-More Filters- Suppliers Name- Contains/Start With/Is- Layout    | RPS.CT          | Classification History  | No          |

Scenario Outline: [225879] More Filters- Suppliers Name- Contains
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer> 
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Then In the recent activities Page, I click the More Filters Button
	Then In the Product Lookup Page, The More Filters Popup is showing 
	And In the More Filters pop up, I enter value in search box in the Filter Categories column: Supplier Name
	Then In the More Filters pop up, I confirm searched filter is displayed in Filters Panel : Supplier Name
	Then In the More Filters pop up, I click on searched filter in Filters Panel : Supplier Name
	Then In the More Filters pop up, I confirm the Filters Parameter panel populates with a list of Supplier Names
	Then In the More Filters pop up, I confirm I see Search under the filter parameter heading
	Then In the More Filters pop up, I confirm the left side of the search box, there is a dropdown box
	Then In the More Filters pop up, I confirm default value of the dropdown box is Contains
	Then In the product lookup page More Filters Popup, I Click the Close button
 
	Examples:
		| Scenario Name                                                                   | Retailer        | Page                    | IsWebviewer |
 		| [#225879a]  3 Panel-More Filters- Suppliers Name- Default Dropdown- Contains    | RPS.TG          | Product Lookup          | No          |
 		| [#225879b]  3 Panel-More Filters- Suppliers Name- Default Dropdown- Contains    | RPS.TG          | Recent Activities       | No          |
 		| [#225879c]  3 Panel-More Filters- Suppliers Name- Default Dropdown- Contains    | RPS.CV          | Product Lookup          | No          |
		| [#225879d]  3 Panel-More Filters- Suppliers Name- Default Dropdown- Contains    | RPS.CV          | Recent Activities       | No          |
		| [#225879e]  3 Panel-More Filters- Suppliers Name- Default Dropdown- Contains    | RPS.LW          | Product Lookup          | No          |
		| [#225879f]  3 Panel-More Filters- Suppliers Name- Default Dropdown- Contains    | RPS.LW          | Recent Activities       | No          |
		| [#225879g]  3 Panel-More Filters- Suppliers Name- Default Dropdown- Contains    | RPS.SF          | Product Lookup          | No          |
 		| [#225879h]  3 Panel-More Filters- Suppliers Name- Default Dropdown- Contains    | RPS.SF          | Recent Activities       | No          |
#		| [#225879i]  3 Panel-More Filters- Suppliers Name- Default Dropdown- Contains    | RPS.LW          | Demo Viewer             | Yes         |
#		| [#225879j]  3 Panel-More Filters- Suppliers Name- Default Dropdown- Contains    | RPS.TG          | Store Viewer            | Yes         |
#		| [#225879k]  3 Panel-More Filters- Suppliers Name- Default Dropdown- Contains    | RPS.TG          | Status Viewer           | Yes         |
#		| [#225879l]  3 Panel-More Filters- Suppliers Name- Default Dropdown- Contains    | RPS.TG          | HQ Viewer               | Yes         |
		| [#225879m]  3 Panel-More Filters- Suppliers Name- Default Dropdown- Contains    | RPS.SF          | SmartFinal_Store        | Yes         |
 		| [#225879n]  3 Panel-More Filters- Suppliers Name- Default Dropdown- Contains    | RPS.LW          | Lowes_store             | Yes         |
		| [#225879o]  3 Panel-More Filters- Suppliers Name- Default Dropdown- Contains    | RPS.CT          | Product Lookup          | No          |
#    	| [#225879p]  3 Panel-More Filters- Suppliers Name- Default Dropdown- Contains    | RPS.CT          | Recent Activities       | No          |
#	    | [#225879q]  3 Panel-More Filters- Suppliers Name- Default Dropdown- Contains    | RPS.CT          | Classification History  | No          |

Scenario Outline: [225899] 3 Panel-More Filters- Suppliers Name- Start With 
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer> 
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Then In the recent activities Page, I click the More Filters Button
	Then In the Product Lookup Page, The More Filters Popup is showing
	And In the More Filters pop up, I enter value in search box in the Filter Categories column: Supplier Name
	Then In the More Filters pop up, I confirm searched filter is displayed in Filters Panel : Supplier Name
	Then In the More Filters pop up, I click on searched filter in Filters Panel : Supplier Name
	Then In the More Filters pop up, I confirm the Filters Parameter panel populates with a list of Supplier Names
	Then In the More Filters pop up, I confirm I see Search under the filter parameter heading
	Then In the More Filters pop up, I confirm the left side of the search box, there is a dropdown box
	Then In the More Filters pop up, I confirm default value of the dropdown box is Contains
	Then In the More Filters pop up, I confirm in the Filter Parameter Panel Selector three options are : Contains, Start With and Is are displayed
	Then In the More Filters pop up, I select the option from the Parameters drop down list: Starts with
	Then In the More Filters pop up, I now type a string  in Supplier Name search field: abcdf
	Then In the More Filters pop up, I confirm a blue box with text No results found  is shown under search box 
	Then In the More Filters pop up, I now type a string  in Supplier Name search field: Lor
	Then In the More Filters pop up, I confirm the list of items shown is narrowed based on the characters I enter: Lor
	Then In the More Filters pop up, In the Filter parameters list I select the searched entry for the Supplier Name Parmeter list
	Then In the More Filters pop up, I confirm in the Selected Filters area, that breadcrumb shows with the selected value: Lor
	Then In the product lookup page More Filters Popup, I Click the the Apply Filter Button
	Then I confirm the page has refreshed
	Then I confirm that the recent activities page bread crumb area contains the label: Lor
 
	Examples:
		| Scenario Name                                                    | Retailer        | Page                    | IsWebviewer |
 		| [#225899a]  3 Panel-More Filters- Suppliers Name- Start With     | RPS.TG          | Product Lookup          | No          |
 		| [#225899b]  3 Panel-More Filters- Suppliers Name- Start With     | RPS.TG          | Recent Activities       | No          |
 		| [#225899c]  3 Panel-More Filters- Suppliers Name- Start With     | RPS.CV          | Product Lookup          | No          |
		| [#225899d]  3 Panel-More Filters- Suppliers Name- Start With     | RPS.CV          | Recent Activities       | No          |
#		| [#225899e]  3 Panel-More Filters- Suppliers Name- Start With     | RPS.LW          | Product Lookup          | No          |
		| [#225899f]  3 Panel-More Filters- Suppliers Name- Start With     | RPS.LW          | Recent Activities       | No          |
		| [#225879g]  3 Panel-More Filters- Suppliers Name- Start With     | RPS.SF          | Product Lookup          | No          |
 		| [#225899h]  3 Panel-More Filters- Suppliers Name- Start With     | RPS.SF          | Recent Activities       | No          |
#		| [#225899i]  3 Panel-More Filters- Suppliers Name- Start With     | RPS.LW          | Demo Viewer             | Yes         |
#		| [#225899j]  3 Panel-More Filters- Suppliers Name- Start With     | RPS.TG          | Store Viewer            | Yes         |
#		| [#225899k]  3 Panel-More Filters- Suppliers Name- Start With     | RPS.TG          | Status Viewer           | Yes         |
#		| [#225899l]  3 Panel-More Filters- Suppliers Name- Start With     | RPS.TG          | HQ Viewer               | Yes         |
		| [#225899m]  3 Panel-More Filters- Suppliers Name- Start With     | RPS.SF          | SmartFinal_Store        | Yes         |
# 		| [#225899n]  3 Panel-More Filters- Suppliers Name- Start With     | RPS.LW          | Lowes_store             | Yes         |
#		| [#225899o]  3 Panel-More Filters- Suppliers Name- Start With     | RPS.CT          | Product Lookup          | No          |
#    	| [#225899p]  3 Panel-More Filters- Suppliers Name- Start With     | RPS.CT          | Recent Activities       | No          |
#	    | [#225899q]  3 Panel-More Filters- Suppliers Name- Start With     | RPS.CT          | Classification History  | No          |

Scenario Outline: [225900] 3 Panel-More Filters- Suppliers Name- Is 
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer> 
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Then In the recent activities Page, I click the More Filters Button
	Then In the recent activities Page, The More Filters Popup is showing 
	And In the More Filters pop up, I enter value in search box in the Filter Categories column: Supplier Name
	Then In the More Filters pop up, I confirm searched filter is displayed in Filters Panel : Supplier Name
	Then In the More Filters pop up, I click on searched filter in Filters Panel : Supplier Name
	Then In the More Filters pop up, I confirm the Filters Parameter panel populates with a list of Supplier Names
	Then In the More Filters pop up, I confirm I see Search under the filter parameter heading
	Then In the More Filters pop up, I confirm the left side of the search box, there is a dropdown box
	Then In the More Filters pop up, I confirm default value of the dropdown box is Contains
	Then In the More Filters pop up, I confirm in the Filter Parameter Panel Selector three options are : Contains, Start With and Is are displayed
	Then In the More Filters pop up, I select the option from the Parameters drop down list: Is
	Then In the More Filters pop up, In the search field in the Filter Parameters panel, In the search box, I enter full Supplier Name: savedAs
	Then I confirm I see the Supplier Name I was searching for: savedAs
	Then In the More Filters pop up, I now type a string  in Supplier Name search field: Lor
	Then In the More Filters pop up, I confirm a blue box with text No results found  is shown under search box 
	Then In the More Filters pop up, In the search field in the Filter Parameters panel, In the search box, I enter full Supplier Name: savedAs
	Then I confirm I see the Supplier Name I was searching for: savedAs 
	Then In the More Filters pop up, In the Filter parameters list I select the searched entry for the Supplier Name Parmeter list
	Then In the More Filters pop up, I confirm in the Selected Filters area, that breadcrumb shows with the selected value: savedAs
	Then In the product lookup page More Filters Popup, I Click the the Apply Filter Button
	Then I confirm the page has refreshed
	Then I confirm that the recent activities page bread crumb area contains the label: savedAs
 
	Examples:
		| Scenario Name                                             | Retailer        | Page                    | IsWebviewer |
 		| [#225900a]  3 Panel-More Filters- Suppliers Name- Is      | RPS.TG          | Product Lookup          | No          |
 		| [#225900b]  3 Panel-More Filters- Suppliers Name- Is      | RPS.TG          | Recent Activities       | No          |
 		| [#225900c]  3 Panel-More Filters- Suppliers Name- Is      | RPS.CV          | Product Lookup          | No          |
		| [#225900d]  3 Panel-More Filters- Suppliers Name- Is      | RPS.CV          | Recent Activities       | No          |
#		| [#225900e]  3 Panel-More Filters- Suppliers Name- Is      | RPS.LW          | Product Lookup          | No          |
		| [#225900f]  3 Panel-More Filters- Suppliers Name- Is      | RPS.LW          | Recent Activities       | No          |
		| [#225900g]  3 Panel-More Filters- Suppliers Name- Is      | RPS.SF          | Product Lookup          | No          |
 		| [#225900h]  3 Panel-More Filters- Suppliers Name- Is      | RPS.SF          | Recent Activities       | No          |
#		| [#225900i]  3 Panel-More Filters- Suppliers Name- Is      | RPS.LW          | Demo Viewer             | Yes         |
#		| [#225900j]  3 Panel-More Filters- Suppliers Name- Is      | RPS.TG          | Store Viewer            | Yes         |
#		| [#225900k]  3 Panel-More Filters- Suppliers Name- Is      | RPS.TG          | Status Viewer           | Yes         |
#		| [#225900l]  3 Panel-More Filters- Suppliers Name- Is      | RPS.TG          | HQ Viewer               | Yes         |
		| [#225900m]  3 Panel-More Filters- Suppliers Name- Is      | RPS.SF          | SmartFinal_Store        | Yes         |
# 		| [#225900n]  3 Panel-More Filters- Suppliers Name- Is      | RPS.LW          | Lowes_store             | Yes         |
#		| [#225900o]  3 Panel-More Filters- Suppliers Name- Is      | RPS.CT          | Product Lookup          | No          |
#    	| [#225900p]  3 Panel-More Filters- Suppliers Name- Is      | RPS.CT          | Recent Activities       | No          |
#	    | [#225900q]  3 Panel-More Filters- Suppliers Name- Is      | RPS.CT          | Classification History  | No          |

Scenario Outline: [225903] 3 Panel-More Filters- Suppliers Name- Toggle Dropdown 
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer> 
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Then In the recent activities Page, I click the More Filters Button
	Then In the recent activities Page, The More Filters Popup is showing 
	And In the More Filters pop up, I enter value in search box in the Filter Categories column: Supplier Name
	Then In the More Filters pop up, I confirm searched filter is displayed in Filters Panel : Supplier Name
	Then In the More Filters pop up, I click on searched filter in Filters Panel : Supplier Name
	Then In the More Filters pop up, I confirm the Filters Parameter panel populates with a list of Supplier Names
	Then In the More Filters pop up, I confirm I see Search under the filter parameter heading
	Then In the More Filters pop up, I confirm the left side of the search box, there is a dropdown box
	Then In the More Filters pop up, I confirm default value of the dropdown box is Contains
	Then In the More Filters pop up, I confirm in the Filter Parameter Panel Selector three options are : Contains, Start With and Is are displayed 
	Then In the More Filters pop up, I now type a string  in Supplier Name search field: eal
	Then In the More Filters pop up, I confirm the Filters Parameter panel populates with a list of Supplier Names
	Then In the More Filters pop up, I select the option from the Parameters drop down list: Starts with 
	Then In the More Filters pop up, I confirm a blue box with text No results found  is shown under search box 
	Then In the More Filters pop up, I select the option from the Parameters drop down list: Is 
	Then In the More Filters pop up, I confirm a blue box with text No results found  is shown under search box 
	Then In the More Filters pop up, I select the option from the Parameters drop down list: Contains 
	Then In the More Filters pop up, I confirm the Filters Parameter panel populates with a list of Supplier Names
 
 
	Examples:
		| Scenario Name                                                           | Retailer        | Page                    | IsWebviewer |
 		| [#225903a]  3 Panel-More Filters- Suppliers Name- Toggle Dropdown       | RPS.TG          | Product Lookup          | No          |
 		| [#225903b]  3 Panel-More Filters- Suppliers Name- Toggle Dropdown       | RPS.TG          | Recent Activities       | No          |
 		| [#225903c]  3 Panel-More Filters- Suppliers Name- Toggle Dropdown       | RPS.CV          | Product Lookup          | No          |
		| [#225903d]  3 Panel-More Filters- Suppliers Name- Toggle Dropdown       | RPS.CV          | Recent Activities       | No          |
#		| [#225903e]  3 Panel-More Filters- Suppliers Name- Toggle Dropdown       | RPS.LW          | Product Lookup          | No          |
		| [#225903f]  3 Panel-More Filters- Suppliers Name- Toggle Dropdown       | RPS.LW          | Recent Activities       | No          |
		| [#225903g]  3 Panel-More Filters- Suppliers Name- Toggle Dropdown       | RPS.SF          | Product Lookup          | No          |
 		| [#225903h]  3 Panel-More Filters- Suppliers Name- Toggle Dropdown       | RPS.SF          | Recent Activities       | No          |
#		| [#225903i]  3 Panel-More Filters- Suppliers Name- Toggle Dropdown       | RPS.LW          | Demo Viewer             | Yes         |
#		| [#225903j]  3 Panel-More Filters- Suppliers Name- Toggle Dropdown       | RPS.TG          | Store Viewer            | Yes         |
#		| [#225903k]  3 Panel-More Filters- Suppliers Name- Toggle Dropdown       | RPS.TG          | Status Viewer           | Yes         |
#		| [#225903l]  3 Panel-More Filters- Suppliers Name- Toggle Dropdown       | RPS.TG          | HQ Viewer               | Yes         |
		| [#225903m]  3 Panel-More Filters- Suppliers Name- Toggle Dropdown       | RPS.SF          | SmartFinal_Store        | Yes         |
# 		| [#225903n]  3 Panel-More Filters- Suppliers Name- Toggle Dropdown       | RPS.LW          | Lowes_store             | Yes         |
#		| [#225903o]  3 Panel-More Filters- Suppliers Name- Toggle Dropdown       | RPS.CT          | Product Lookup          | No          |
#    	| [#225903p]  3 Panel-More Filters- Suppliers Name- Toggle Dropdown       | RPS.CT          | Recent Activities       | No          |
#	    | [#225903q]  3 Panel-More Filters- Suppliers Name- Toggle Dropdown       | RPS.CT          | Classification History  | No          |



Scenario Outline: [224917] 3 Panel-More Filters pop up  - DPCI -  "No results found" 
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer> 
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Then In the recent activities Page, I click the More Filters Button
	Then In the recent activities Page, The More Filters Popup is showing 
	And In the More Filters pop up, I enter value in search box in the Filter Categories column: DPCI Number
	Then In the More Filters pop up, I confirm searched filter is displayed in Filters Panel : DPCI Number
	Then In the More Filters pop up, I click on searched filter in Filters Panel : DPCI Number 
	Then In the More Filters pop up, I confirm I see Search under the filter parameter heading
	Then In the More Filters pop up, I confirm the left side of the search box, there is a dropdown box
	Then In the More Filters pop up, I confirm default value of the dropdown box is Contains
	Then In the More Filters pop up, I confirm in the Filter Parameter Panel Selector three options are : Contains, Start With and Is are displayed 
    Then In the More Filters pop up, In Filter Parameter panel I confirm the Search field shows the default text: Search
	Then In the More Filters pop up, I confirm the Filter Parameter panel shows the DPCI list
	Then In the More Filters pop up, In Filter Parameter panel I confirm each item for selection shows a check box before the DPCI value
    Then In the More Filters pop up, I now type a string  in DPCI search field: 99999999
	Then In the More Filters pop up, I confirm a blue box with text No results found  is shown under search box 
	Then In the More Filters pop up, In Filter Parameter panel I clear the DPCI value in search box
	Then In the More Filters pop up, I confirm the Filters Parameter panel populates with a list of DPCI values
     Then In the More Filters pop up, I now type a string  in DPCI search field: abcd
	Then In the More Filters pop up, I confirm a blue box with text No results found  is shown under search box 
 
 
	Examples:
		| Scenario Name                                                               | Retailer        | Page                    | IsWebviewer | 
 		| [#224917a]  3 Panel-More Filters pop up  - DPCI -  "No results found"       | RPS.TG          | Product Lookup          | No          | 
#		| [#224917b]  3 Panel-More Filters pop up  - DPCI -  "No results found"       | RPS.TG          | Store Viewer            | Yes         |
#		| [#224917c]  3 Panel-More Filters pop up  - DPCI -  "No results found"       | RPS.TG          | Status Viewer           | Yes         |
#		| [#224917d]  3 Panel-More Filters pop up  - DPCI -  "No results found"       | RPS.TG          | HQ Viewer               | Yes         |
 

Scenario Outline: [224918] 3 Panel-More Filters pop up  - DPCI - Contains
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer> 
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Then In the recent activities Page, I click the More Filters Button
	Then In the recent activities Page, The More Filters Popup is showing 
	And In the More Filters pop up, I enter value in search box in the Filter Categories column: DPCI Number
	Then In the More Filters pop up, I confirm searched filter is displayed in Filters Panel : DPCI Number
	Then In the More Filters pop up, I click on searched filter in Filters Panel : DPCI Number 
	Then In the More Filters pop up, I confirm I see Search under the filter parameter heading
	Then In the More Filters pop up, I confirm the left side of the search box, there is a dropdown box
	Then In the More Filters pop up, I confirm default value of the dropdown box is Contains
	Then In the More Filters pop up, I confirm in the Filter Parameter Panel Selector three options are : Contains, Start With and Is are displayed 
	Then In the More Filters pop up, In Filter Parameter panel I confirm the Search field shows the default text: Search
	Then In the More Filters pop up, I confirm the Filter Parameter panel shows the DPCI list
	Then In the More Filters pop up, In Filter Parameter panel I confirm each item for selection shows a check box before the DPCI value
    Then In the More Filters pop up, I select the option from the Parameters drop down list: Contains 
	Then In the More Filters pop up, I now type a string  in DPCI search field: 12
	Then In the More Filters pop up, I confirm the Filters Parameter panel populates with a list of DPCI values
    Then In the More Filters pop up, I now type a string  in DPCI search field: 99999999
	Then In the More Filters pop up, I confirm a blue box with text No results found  is shown under search box 
    Then In the More Filters pop up, I now type a string  in DPCI search field: 12
	Then In the More Filters pop up, I confirm the Filters Parameter panel populates with a list of DPCI values
	Then In the More Filters pop up, In the Filter parameters list I select the searched entry for the DPCI Parmeter list
	Then In the product lookup page More Filters Popup, I Click the the Apply Filter Button
	Then I confirm the page has refreshed
	Then I confirm that the recent activities page bread crumb area contains the label: DPCI
 
 
	Examples:
		| Scenario Name                                                    | Retailer        | Page                    | IsWebviewer | 
 		| [#224918a]  3 Panel-More Filters pop up  - DPCI - Contains       | RPS.TG          | Product Lookup          | No          | 
#		| [#224918b]  3 Panel-More Filters pop up  - DPCI - Contains       | RPS.TG          | Store Viewer            | Yes         |
#		| [#224918c]  3 Panel-More Filters pop up  - DPCI - Contains       | RPS.TG          | Status Viewer           | Yes         |
#		| [#224918d]  3 Panel-More Filters pop up  - DPCI - Contains       | RPS.TG          | HQ Viewer               | Yes         |
 

 Scenario Outline: [224919] 3 Panel-More Filters pop up - DPCI - Starts With
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer> 
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Then In the recent activities Page, I click the More Filters Button
	Then In the recent activities Page, The More Filters Popup is showing 
	And In the More Filters pop up, I enter value in search box in the Filter Categories column: DPCI Number
	Then In the More Filters pop up, I confirm searched filter is displayed in Filters Panel : DPCI Number
	Then In the More Filters pop up, I click on searched filter in Filters Panel : DPCI Number 
	Then In the More Filters pop up, I confirm I see Search under the filter parameter heading
	Then In the More Filters pop up, I confirm the left side of the search box, there is a dropdown box
	Then In the More Filters pop up, I confirm default value of the dropdown box is Contains
	Then In the More Filters pop up, I confirm in the Filter Parameter Panel Selector three options are : Contains, Start With and Is are displayed 
	Then In the More Filters pop up, In Filter Parameter panel I confirm the Search field shows the default text: Search
	Then In the More Filters pop up, I confirm the Filter Parameter panel shows the DPCI list
	Then In the More Filters pop up, In Filter Parameter panel I confirm each item for selection shows a check box before the DPCI value
    Then In the More Filters pop up, I select the option from the Parameters drop down list: Starts with
	Then In the More Filters pop up, I now type a string  in DPCI search field: 261
	Then In the More Filters pop up, I confirm the list of items shown is narrowed based on the characters I enter: 261
    Then In the More Filters pop up, I now type a string  in DPCI search field: 99999999
	Then In the More Filters pop up, I confirm a blue box with text No results found  is shown under search box 
    Then In the More Filters pop up, I now type a string  in DPCI search field: 261
	Then In the More Filters pop up, I confirm the Filters Parameter panel populates with a list of DPCI values
	Then In the More Filters pop up, In the Filter parameters list I select the searched entry for the DPCI Parmeter list
	Then In the product lookup page More Filters Popup, I Click the the Apply Filter Button
	Then I confirm the page has refreshed
	Then I confirm that the recent activities page bread crumb area contains the label: DPCI
 
 
	Examples:
		| Scenario Name                                                      | Retailer        | Page                    | IsWebviewer | 
 		| [#224919a]  3 Panel-More Filters pop up - DPCI - Starts With       | RPS.TG          | Product Lookup          | No          | 
#		| [#224919b]  3 Panel-More Filters pop up - DPCI - Starts With       | RPS.TG          | Store Viewer            | Yes         |
#		| [#224919c]  3 Panel-More Filters pop up - DPCI - Starts With       | RPS.TG          | Status Viewer           | Yes         |
#		| [#224919d]  3 Panel-More Filters pop up - DPCI - Starts With       | RPS.TG          | HQ Viewer               | Yes         |
 

 Scenario Outline: [225795] 3 Panel-More Filters - WPSID - Contains
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer> 
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Then In the recent activities Page, I click the More Filters Button
	Then In the recent activities Page, The More Filters Popup is showing 
	And In the More Filters pop up, I enter value in search box in the Filter Categories column: WPS ID
	Then In the More Filters pop up, I confirm searched filter is displayed in Filters Panel : WPS ID
	Then In the More Filters pop up, I click on searched filter in Filters Panel : WPS ID 
	Then In the More Filters pop up, I confirm I see Search under the filter parameter heading
	Then In the More Filters pop up, I confirm the left side of the search box, there is a dropdown box
	Then In the More Filters pop up, I confirm default value of the dropdown box is Contains
	Then In the More Filters pop up, I confirm in the Filter Parameter Panel Selector three options are : Contains, Start With and Is are displayed 
	Then In the More Filters pop up, In Filter Parameter panel I confirm the Search field shows the default text: Search
	Then In the More Filters pop up, I confirm the Filter Parameter panel shows the WPS Id list
	Then In the More Filters pop up, In Filter Parameter panel I confirm each item for selection shows a check box before the DPCI value
    Then In the More Filters pop up, I select the option from the Parameters drop down list: Contains 
	Then In the More Filters pop up, I now type a string  in DPCI search field: 12
	Then In the More Filters pop up, I confirm the Filters Parameter panel populates with a list of DPCI values
    Then In the More Filters pop up, In the Filter parameters list I select the searched entry for the DPCI Parmeter list
    Then In the More Filters pop up, In the Selected Filters area I click Clear All to remove all filters
	Then In the More Filters popup I do not see the Selected Filters area
	Then In the More Filters pop up, I click on searched filter in Filters Panel : WPS ID 
    Then In the More Filters pop up, I now type a string  in DPCI search field: 99999999
	Then In the More Filters pop up, I confirm a blue box with text No results found  is shown under search box 
    Then In the More Filters pop up, I now type a string  in DPCI search field: 12
	Then In the More Filters pop up, I confirm the Filters Parameter panel populates with a list of DPCI values
	Then In the More Filters pop up, In the Filter parameters list I select the searched entry for the DPCI Parmeter list
	Then In the product lookup page More Filters Popup, I Click the the Apply Filter Button
	Then I confirm the page has refreshed
	Then I confirm that the recent activities page bread crumb area contains the label: WPS ID
 
 
	Examples:
		| Scenario Name                                             | Retailer        | Page                    | IsWebviewer |
 		| [#225795a]  3 Panel-More Filters - WPSID - Contains       | RPS.TG          | Product Lookup          | No          |
 		| [#225795b]  3 Panel-More Filters - WPSID - Contains       | RPS.TG          | Recent Activities       | No          |
 		| [#225795c]  3 Panel-More Filters - WPSID - Contains       | RPS.CV          | Product Lookup          | No          |
		| [#225795d]  3 Panel-More Filters - WPSID - Contains       | RPS.CV          | Recent Activities       | No          |
#		| [#225795e]  3 Panel-More Filters - WPSID - Contains       | RPS.LW          | Product Lookup          | No          |
		| [#225795f]  3 Panel-More Filters - WPSID - Contains       | RPS.LW          | Recent Activities       | No          |
		| [#225795g]  3 Panel-More Filters - WPSID - Contains       | RPS.SF          | Product Lookup          | No          |
 		| [#225795h]  3 Panel-More Filters - WPSID - Contains       | RPS.SF          | Recent Activities       | No          |
#		| [#225795i]  3 Panel-More Filters - WPSID - Contains       | RPS.LW          | Demo Viewer             | Yes         |
#		| [#225795j]  3 Panel-More Filters - WPSID - Contains       | RPS.TG          | Store Viewer            | Yes         |
#		| [#225795k]  3 Panel-More Filters - WPSID - Contains       | RPS.TG          | Status Viewer           | Yes         |
#		| [#225795l]  3 Panel-More Filters - WPSID - Contains       | RPS.TG          | HQ Viewer               | Yes         |
		| [#225795m]  3 Panel-More Filters - WPSID - Contains       | RPS.SF          | SmartFinal_Store        | Yes         |
# 		| [#225795n]  3 Panel-More Filters - WPSID - Contains       | RPS.LW          | Lowes_store             | Yes         |
#		| [#225795o]  3 Panel-More Filters - WPSID - Contains       | RPS.CT          | Product Lookup          | No          |
#    	| [#225795p]  3 Panel-More Filters - WPSID - Contains       | RPS.CT          | Recent Activities       | No          |
#	    | [#225795q]  3 Panel-More Filters - WPSID - Contains       | RPS.CT          | Classification History  | No          |


Scenario Outline: [225796] 3 Panel-More Filters - WPSID - Start With
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer> 
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Then In the recent activities Page, I click the More Filters Button
	Then In the recent activities Page, The More Filters Popup is showing 
	And In the More Filters pop up, I enter value in search box in the Filter Categories column: WPS ID
	Then In the More Filters pop up, I confirm searched filter is displayed in Filters Panel : WPS ID
	Then In the More Filters pop up, I click on searched filter in Filters Panel : WPS ID
	Then In the More Filters pop up, I confirm I see Search under the filter parameter heading
	Then In the More Filters pop up, I confirm the left side of the search box, there is a dropdown box
	Then In the More Filters pop up, I confirm default value of the dropdown box is Contains
	Then In the More Filters pop up, I confirm in the Filter Parameter Panel Selector three options are : Contains, Start With and Is are displayed 
	Then In the More Filters pop up, In Filter Parameter panel I confirm the Search field shows the default text: Search
	Then In the More Filters pop up, I confirm the Filter Parameter panel shows the DPCI list
	Then In the More Filters pop up, In Filter Parameter panel I confirm each item for selection shows a check box before the DPCI value
    Then In the More Filters pop up, I select the option from the Parameters drop down list: Starts with
	Then In the More Filters pop up, I now type a string  in DPCI search field: 100
	Then In the More Filters pop up, I confirm the list of items shown is narrowed based on the characters I enter: 100
    Then In the More Filters pop up, I now type a string  in DPCI search field: 99999999
	Then In the More Filters pop up, I confirm a blue box with text No results found  is shown under search box 
    Then In the More Filters pop up, I now type a string  in DPCI search field: 100
	Then In the More Filters pop up, I confirm the Filters Parameter panel populates with a list of DPCI values
	Then In the More Filters pop up, In the Filter parameters list I select the searched entry for the DPCI Parmeter list
	Then In the product lookup page More Filters Popup, I Click the the Apply Filter Button
	Then I confirm the page has refreshed
	Then I confirm that the recent activities page bread crumb area contains the label: WPS ID
 
 
	Examples:
		| Scenario Name                                               | Retailer        | Page                    | IsWebviewer |
 		| [#225796a]  3 Panel-More Filters - WPSID - Start With       | RPS.TG          | Product Lookup          | No          |
 		| [#225796b]  3 Panel-More Filters - WPSID - Start With       | RPS.TG          | Recent Activities       | No          |
 		| [#225796c]  3 Panel-More Filters - WPSID - Start With       | RPS.CV          | Product Lookup          | No          |
		| [#225796d]  3 Panel-More Filters - WPSID - Start With       | RPS.CV          | Recent Activities       | No          |
#		| [#225796e]  3 Panel-More Filters - WPSID - Start With       | RPS.LW          | Product Lookup          | No          |
		| [#225796f]  3 Panel-More Filters - WPSID - Start With       | RPS.LW          | Recent Activities       | No          |
		| [#225796g]  3 Panel-More Filters - WPSID - Start With       | RPS.SF          | Product Lookup          | No          |
 		| [#225796h]  3 Panel-More Filters - WPSID - Start With       | RPS.SF          | Recent Activities       | No          |
#		| [#225796i]  3 Panel-More Filters - WPSID - Start With       | RPS.LW          | Demo Viewer             | Yes         |
#		| [#225796j]  3 Panel-More Filters - WPSID - Start With       | RPS.TG          | Store Viewer            | Yes         |
#		| [#225796k]  3 Panel-More Filters - WPSID - Start With       | RPS.TG          | Status Viewer           | Yes         |
#		| [#225796l]  3 Panel-More Filters - WPSID - Start With       | RPS.TG          | HQ Viewer               | Yes         |
		| [#225796m]  3 Panel-More Filters - WPSID - Start With       | RPS.SF          | SmartFinal_Store        | Yes         |
# 		| [#225796n]  3 Panel-More Filters - WPSID - Start With       | RPS.LW          | Lowes_store             | Yes         |
#		| [#225796o]  3 Panel-More Filters - WPSID - Start With       | RPS.CT          | Product Lookup          | No          |
#    	| [#225796p]  3 Panel-More Filters - WPSID - Start With       | RPS.CT          | Recent Activities       | No          |
#	    | [#225796q]  3 Panel-More Filters - WPSID - Start With       | RPS.CT          | Classification History  | No          |


Scenario Outline: [225797] 3 Panel-More Filters - WPSID - Is
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer> 
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Then In the recent activities Page, I click the More Filters Button
	Then In the recent activities Page, The More Filters Popup is showing 
	And In the More Filters pop up, I enter value in search box in the Filter Categories column: WPS ID
	Then In the More Filters pop up, I confirm searched filter is displayed in Filters Panel : WPS ID
	Then In the More Filters pop up, I click on searched filter in Filters Panel : WPS ID
	Then In the More Filters pop up, I confirm I see Search under the filter parameter heading
	Then In the More Filters pop up, I confirm the left side of the search box, there is a dropdown box
	Then In the More Filters pop up, I confirm default value of the dropdown box is Contains
	Then In the More Filters pop up, I confirm in the Filter Parameter Panel Selector three options are : Contains, Start With and Is are displayed 
	Then In the More Filters pop up, In Filter Parameter panel I confirm the Search field shows the default text: Search
	Then In the More Filters pop up, I confirm the Filter Parameter panel shows the DPCI list
	Then In the More Filters pop up, In Filter Parameter panel I confirm each item for selection shows a check box before the DPCI value  
	Then In the More Filters pop up, In the search field in the Filter Parameters panel, In the search box, I enter full WPS ID: savedAs
    Then In the More Filters pop up, I select the option from the Parameters drop down list: Is 
	Then I confirm I see the Supplier Name I was searching for: savedAs
	Then In the More Filters pop up, I now type a string  in Supplier Name search field: 123
	Then In the More Filters pop up, I confirm a blue box with text No results found  is shown under search box 
	Then In the More Filters pop up, I select the option from the Parameters drop down list: Contains 
	Then In the More Filters pop up, In the search field in the Filter Parameters panel, In the search box, I enter full WPS ID: savedAs
	Then In the More Filters pop up, I select the option from the Parameters drop down list: Is 
	Then I confirm I see the Supplier Name I was searching for: savedAs 
	Then In the More Filters pop up, In the Filter parameters list I select the searched entry for the Supplier Name Parmeter list
	Then In the More Filters pop up, I confirm in the Selected Filters area, that breadcrumb shows with the selected value: savedAs
	Then In the product lookup page More Filters Popup, I Click the the Apply Filter Button
	Then I confirm the page has refreshed
	Then I confirm that the recent activities page bread crumb area contains the label: savedAs
 
 
 
	Examples:
		| Scenario Name                                       | Retailer        | Page                    | IsWebviewer |
 		| [#225797a]  3 Panel-More Filters - WPSID - Is       | RPS.TG          | Product Lookup          | No          |
 		| [#225797b]  3 Panel-More Filters - WPSID - Is       | RPS.TG          | Recent Activities       | No          |
# 		| [#225797c]  3 Panel-More Filters - WPSID - Is       | RPS.CV          | Product Lookup          | No          |
#		| [#225797d]  3 Panel-More Filters - WPSID - Is       | RPS.CV          | Recent Activities       | No          |
#		| [#225797e]  3 Panel-More Filters - WPSID - Is       | RPS.LW          | Product Lookup          | No          |
		| [#225797f]  3 Panel-More Filters - WPSID - Is       | RPS.LW          | Recent Activities       | No          |
		| [#225797g]  3 Panel-More Filters - WPSID - Is       | RPS.SF          | Product Lookup          | No          |
 		| [#225797h]  3 Panel-More Filters - WPSID - Is       | RPS.SF          | Recent Activities       | No          |
#		| [#225797i]  3 Panel-More Filters - WPSID - Is       | RPS.LW          | Demo Viewer             | Yes         |
#		| [#225797j]  3 Panel-More Filters - WPSID - Is       | RPS.TG          | Store Viewer            | Yes         |
#		| [#225797k]  3 Panel-More Filters - WPSID - Is       | RPS.TG          | Status Viewer           | Yes         |
#		| [#225797l]  3 Panel-More Filters - WPSID - Is       | RPS.TG          | HQ Viewer               | Yes         |
		| [#225797m]  3 Panel-More Filters - WPSID - Is       | RPS.SF          | SmartFinal_Store        | Yes         |
# 		| [#225797n]  3 Panel-More Filters - WPSID - Is       | RPS.LW          | Lowes_store             | Yes         |
#		| [#225797o]  3 Panel-More Filters - WPSID - Is       | RPS.CT          | Product Lookup          | No          |
#    	| [#225797p]  3 Panel-More Filters - WPSID - Is       | RPS.CT          | Recent Activities       | No          |
#	    | [#225797q]  3 Panel-More Filters - WPSID - Is       | RPS.CT          | Classification History  | No          |

Scenario Outline: [203037] More Filters- RU- "Phrase not found" is not shown 
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer> 
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Then I call Shared Step 203036 (RPS>More Filters>Verify Phrase Not Found is not shown)
 

	Examples:
		| Scenario Name                                                    | Retailer        | Page                    | IsWebviewer |
 		| [#203037a]  More Filters- RU- "Phrase not found" is not shown    | RPS.TG          | Product Lookup          | No          |
 		| [#203037b]  More Filters- RU- "Phrase not found" is not shown    | RPS.TG          | Recent Activities       | No          |
		| [#203037c]  More Filters- RU- "Phrase not found" is not shown    | RPS.CV          | Product Lookup          | No          |
		| [#203037d]  More Filters- RU- "Phrase not found" is not shown    | RPS.CV          | Recent Activities       | No          |
		| [#203037e]  More Filters- RU- "Phrase not found" is not shown    | RPS.LW          | Product Lookup          | No          |
		| [#203037f]  More Filters- RU- "Phrase not found" is not shown    | RPS.LW          | Recent Activities       | No          |
		| [#203037g]  More Filters- RU- "Phrase not found" is not shown    | RPS.SF          | Product Lookup          | No          |
# 		| [#203037h]  More Filters- RU- "Phrase not found" is not shown    | RPS.SF          | Recent Activities       | No          |
#		| [#203037i]  More Filters- RU- "Phrase not found" is not shown    | RPS.LW          | Demo Viewer             | Yes         |
#		| [#203037j]  More Filters- RU- "Phrase not found" is not shown    | RPS.TG          | Store Viewer            | Yes         |
#		| [#203037k]  More Filters- RU- "Phrase not found" is not shown    | RPS.TG          | Status Viewer           | Yes         |
#		| [#203037l]  More Filters- RU- "Phrase not found" is not shown    | RPS.TG          | HQ Viewer               | Yes         |
#		| [#203037m]  More Filters- RU- "Phrase not found" is not shown    | RPS.SF          | SmartFinal_Store        | Yes         |
# 		| [#203037n]  More Filters- RU- "Phrase not found" is not shown    | RPS.LW          | Lowes_store             | Yes         |
#		| [#203037o]  More Filters- RU- "Phrase not found" is not shown    | RPS.CT          | Product Lookup          | No          |
#    	| [#203037p]  More Filters- RU- "Phrase not found" is not shown    | RPS.CT          | Recent Activities       | No          |
#	    | [#203037q]  More Filters- RU- "Phrase not found" is not shown    | RPS.CT          | Classification History  | No          |
 

 Scenario Outline: [224774] 3 Panel-More Filters- Supplier Name- Has Any/No Value 
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer> 
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Then In the recent activities Page, I click the More Filters Button
	Then In the Product Lookup Page, The More Filters Popup is showing
	And In the More Filters pop up, I enter value in search box in the Filter Categories column: Supplier Name
	Then In the More Filters pop up, I confirm searched filter is displayed in Filters Panel : Supplier Name
	Then In the More Filters pop up, I click on searched filter in Filters Panel : Supplier Name
	Then In the More Filters pop up, I confirm the Filters Parameter panel populates with a list of Supplier Names
	Then In the More Filters pop up, I confirm I see Search under the filter parameter heading
	Then In the More Filters pop up, I confirm the left side of the search box, there is a dropdown box
	Then In the More Filters pop up, I confirm default value of the dropdown box is Contains
	Then In the More Filters pop up, I confirm in the Filter Parameter Panel Selector three options are : Contains, Start With and Is are displayed
	Then I confirm, under the search box, has value checkbox is displayed: Has Any Value 
	Then I confirm, under the search box, has value checkbox is displayed: Has No Value 
    Then In the More Filters pop up, I check the checkbox with value: Has Any Value
	Then In the More Filters pop up, I confirm Search Control Panel is greyed out and disabled
	Then In the More Filters pop up, I check the checkbox with value: Has No Value
	Then In the More Filters pop up, I confirm Search Control Panel is greyed out and disabled
	Then In the More Filters pop up, I check the checkbox with value: Has Any Value
	Then I confirm, under the search box, has value checkbox is displayed: Has Any Value 
    Then In the product lookup page More Filters Popup, I Click the the Apply Filter Button
	Then I confirm the page has refreshed
	Then I confirm that the recent activities page bread crumb area contains the label: Has Any Value

	Examples:
		| Scenario Name                                                         | Retailer        | Page                    | IsWebviewer |
 		| [#224774a]  3 Panel-More Filters- Supplier Name- Has Any/No Value     | RPS.TG          | Product Lookup          | No          |
 		| [#224774b]  3 Panel-More Filters- Supplier Name- Has Any/No Value     | RPS.TG          | Recent Activities       | No          |
 		| [#224774c]  3 Panel-More Filters- Supplier Name- Has Any/No Value     | RPS.CV          | Product Lookup          | No          |
		| [#224774d]  3 Panel-More Filters- Supplier Name- Has Any/No Value     | RPS.CV          | Recent Activities       | No          |
#		| [#224774e]  3 Panel-More Filters- Supplier Name- Has Any/No Value     | RPS.LW          | Product Lookup          | No          |
		| [#224774f]  3 Panel-More Filters- Supplier Name- Has Any/No Value     | RPS.LW          | Recent Activities       | No          |
		| [#224774g]  3 Panel-More Filters- Supplier Name- Has Any/No Value     | RPS.SF          | Product Lookup          | No          |
 		| [#224774h]  3 Panel-More Filters- Supplier Name- Has Any/No Value     | RPS.SF          | Recent Activities       | No          |
#		| [#224774i]  3 Panel-More Filters- Supplier Name- Has Any/No Value     | RPS.LW          | Demo Viewer             | Yes         |
#		| [#224774j]  3 Panel-More Filters- Supplier Name- Has Any/No Value     | RPS.TG          | Store Viewer            | Yes         |
#		| [#224774k]  3 Panel-More Filters- Supplier Name- Has Any/No Value     | RPS.TG          | Status Viewer           | Yes         |
#		| [#224774l]  3 Panel-More Filters- Supplier Name- Has Any/No Value     | RPS.TG          | HQ Viewer               | Yes         |
		| [#224774m]  3 Panel-More Filters- Supplier Name- Has Any/No Value     | RPS.SF          | SmartFinal_Store        | Yes         |
# 		| [#224774n]  3 Panel-More Filters- Supplier Name- Has Any/No Value     | RPS.LW          | Lowes_store             | Yes         |
#		| [#224774o]  3 Panel-More Filters- Supplier Name- Has Any/No Value     | RPS.CT          | Product Lookup          | No          |
#    	| [#224774p]  3 Panel-More Filters- Supplier Name- Has Any/No Value     | RPS.CT          | Recent Activities       | No          |
#	    | [#224774q]  3 Panel-More Filters- Supplier Name- Has Any/No Value     | RPS.CT          | Classification History  | No          |

Scenario Outline: [224790] 3 Panel-More Filters-DPCI- Has Any/No Value
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer> 
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Then In the recent activities Page, I click the More Filters Button
	Then In the recent activities Page, The More Filters Popup is showing 
	And In the More Filters pop up, I enter value in search box in the Filter Categories column: DPCI Number
	Then In the More Filters pop up, I confirm searched filter is displayed in Filters Panel : DPCI Number
	Then In the More Filters pop up, I click on searched filter in Filters Panel : DPCI Number 
	Then In the More Filters pop up, I confirm I see Search under the filter parameter heading
	Then In the More Filters pop up, I confirm the left side of the search box, there is a dropdown box
	Then In the More Filters pop up, I confirm default value of the dropdown box is Contains
	Then In the More Filters pop up, I confirm in the Filter Parameter Panel Selector three options are : Contains, Start With and Is are displayed 
	Then I confirm, under the search box, has value checkbox is displayed: Has Any Value 
	Then I confirm, under the search box, has value checkbox is displayed: Has No Value 
    Then In the More Filters pop up, I check the checkbox with value: Has Any Value
	Then In the More Filters pop up, I confirm Search Control Panel is greyed out and disabled
	Then In the More Filters pop up, I check the checkbox with value: Has No Value
	Then In the More Filters pop up, I confirm Search Control Panel is greyed out and disabled
	Then In the More Filters pop up, I check the checkbox with value: Has Any Value
	Then I confirm, under the search box, has value checkbox is displayed: Has Any Value 
    Then In the product lookup page More Filters Popup, I Click the the Apply Filter Button
	Then I confirm the page has refreshed
	Then I confirm that the recent activities page bread crumb area contains the label: Has Any Value
 
	Examples:
		| Scenario Name                                                 | Retailer        | Page                    | IsWebviewer | 
 		| [#224790a]  3 Panel-More Filters-DPCI- Has Any/No Value       | RPS.TG          | Product Lookup          | No          | 
#		| [#224790b]  3 Panel-More Filters-DPCI- Has Any/No Value       | RPS.TG          | Store Viewer            | Yes         |
#		| [#224790c]  3 Panel-More Filters-DPCI- Has Any/No Value       | RPS.TG          | Status Viewer           | Yes         |
#		| [#224790d]  3 Panel-More Filters-DPCI- Has Any/No Value       | RPS.TG          | HQ Viewer               | Yes         |
 

 Scenario Outline: [224796] 3 Panel-More Filters pop up - Filter By Packaging Type- Has Any Value/Has No Value - Checkbox List
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer> 
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Then I call Shared Step 204659 (RPS More Filters filter by Packaging Type)
	Then In the More Filters pop up, I confirm I see Search under the filter parameter heading
	Then In the More Filters pop up, I confirm the left side of the search box, there is a dropdown box
	Then In the More Filters pop up, I confirm default value of the dropdown box is Contains
	Then In the More Filters pop up, I confirm in the Filter Parameter Panel Selector three options are : Contains, Start With and Is are displayed 
	Then I confirm, under the search box, has value checkbox is displayed: Has Any Value 
	Then I confirm, under the search box, has value checkbox is displayed: Has No Value 
    Then In the More Filters pop up, I check the checkbox with value: Has Any Value
	Then In the More Filters pop up, I confirm Search Control Panel is greyed out and disabled
	Then In the More Filters pop up, I check the checkbox with value: Has No Value
	Then In the More Filters pop up, I confirm Search Control Panel is greyed out and disabled
	Then In the More Filters pop up, I check the checkbox with value: Has Any Value
	Then I confirm, under the search box, has value checkbox is displayed: Has Any Value 
    Then In the product lookup page More Filters Popup, I Click the the Apply Filter Button
	Then I confirm the page has refreshed
	Then I confirm that the recent activities page bread crumb area contains the label: Has Any Value
 
	Examples:

		| Scenario Name                                                                                                      | Retailer        | Page                    | IsWebviewer |
 		| [#224796a]  3 Panel-More Filters pop up - Filter By Packaging Type- Has Any Value/Has No Value - Checkbox List     | RPS.TG          | Product Lookup          | No          |
 		| [#224796b]  3 Panel-More Filters pop up - Filter By Packaging Type- Has Any Value/Has No Value - Checkbox List     | RPS.TG          | Recent Activities       | No          |
 		| [#224796c]  3 Panel-More Filters pop up - Filter By Packaging Type- Has Any Value/Has No Value - Checkbox List     | RPS.CV          | Product Lookup          | No          |
		| [#224796d]  3 Panel-More Filters pop up - Filter By Packaging Type- Has Any Value/Has No Value - Checkbox List     | RPS.CV          | Recent Activities       | No          |
#		| [#224796e]  3 Panel-More Filters pop up - Filter By Packaging Type- Has Any Value/Has No Value - Checkbox List     | RPS.LW          | Product Lookup          | No          |
		| [#224796f]  3 Panel-More Filters pop up - Filter By Packaging Type- Has Any Value/Has No Value - Checkbox List     | RPS.LW          | Recent Activities       | No          |
		| [#224796g]  3 Panel-More Filters pop up - Filter By Packaging Type- Has Any Value/Has No Value - Checkbox List     | RPS.SF          | Product Lookup          | No          |
 		| [#224796h]  3 Panel-More Filters pop up - Filter By Packaging Type- Has Any Value/Has No Value - Checkbox List     | RPS.SF          | Recent Activities       | No          |
#		| [#224796i]  3 Panel-More Filters pop up - Filter By Packaging Type- Has Any Value/Has No Value - Checkbox List     | RPS.LW          | Demo Viewer             | Yes         |
#		| [#224796j]  3 Panel-More Filters pop up - Filter By Packaging Type- Has Any Value/Has No Value - Checkbox List     | RPS.TG          | Store Viewer            | Yes         |
#		| [#224796k]  3 Panel-More Filters pop up - Filter By Packaging Type- Has Any Value/Has No Value - Checkbox List     | RPS.TG          | Status Viewer           | Yes         |
#		| [#224796l]  3 Panel-More Filters pop up - Filter By Packaging Type- Has Any Value/Has No Value - Checkbox List     | RPS.TG          | HQ Viewer               | Yes         |
		| [#224796m]  3 Panel-More Filters pop up - Filter By Packaging Type- Has Any Value/Has No Value - Checkbox List     | RPS.SF          | SmartFinal_Store        | Yes         |
# 		| [#224796n]  3 Panel-More Filters pop up - Filter By Packaging Type- Has Any Value/Has No Value - Checkbox List     | RPS.LW          | Lowes_store             | Yes         |
#		| [#224796o]  3 Panel-More Filters pop up - Filter By Packaging Type- Has Any Value/Has No Value - Checkbox List     | RPS.CT          | Product Lookup          | No          |
#    	| [#224796p]  3 Panel-More Filters pop up - Filter By Packaging Type- Has Any Value/Has No Value - Checkbox List     | RPS.CT          | Recent Activities       | No          |
#	    | [#224796q]  3 Panel-More Filters pop up - Filter By Packaging Type- Has Any Value/Has No Value - Checkbox List     | RPS.CT          | Classification History  | No          |

Scenario Outline: [224810] 3 Panel-More Filters- Has Any/No Value- Open/Save Report
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer> 
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Then In the recent activities Page, I click the More Filters Button
	Then In the Product Lookup Page, The More Filters Popup is showing
	And In the More Filters pop up, I enter value in search box in the Filter Categories column: Supplier Name
	Then In the More Filters pop up, I confirm searched filter is displayed in Filters Panel : Supplier Name
	Then In the More Filters pop up, I click on searched filter in Filters Panel : Supplier Name
	Then In the More Filters pop up, I confirm the Filters Parameter panel populates with a list of Supplier Names
	Then In the More Filters pop up, I confirm I see Search under the filter parameter heading
	Then In the More Filters pop up, I confirm the left side of the search box, there is a dropdown box
	Then In the More Filters pop up, I confirm default value of the dropdown box is Contains
	Then In the More Filters pop up, I confirm in the Filter Parameter Panel Selector three options are : Contains, Start With and Is are displayed
	Then I confirm, under the search box, has value checkbox is displayed: Has Any Value 
	Then I confirm, under the search box, has value checkbox is displayed: Has No Value 
    Then In the More Filters pop up, I check the checkbox with value: Has Any Value
	Then In the More Filters pop up, I confirm Search Control Panel is greyed out and disabled 
	Then In the product lookup page More Filters Popup, I Click the the Apply Filter Button
	Then I confirm the page has refreshed
	Then I confirm that the recent activities page bread crumb area contains the label: Has Any Value
	Then I confirm that the Product Lookup page buttons to the right of the search box are as follows:
		| Buttons        |
		| More Filters   |
		| Reset          |
		| Select Columns |
		| Export         |
		| Open Report    |
		| Save Report    |
	 Then In the product lookup page, I click the Save Report Button
	 Then I confirm the Report popup displays the following title: Save Report
	 Then In Save Report popup I Enter Name: auomationtest in Name field
	 Then In Save Report popup, I click Save button
	 Then In the Product Lookup Page, The Report Popup is not showing
	 Then I confirm that the recent activities page bread crumb area contains the label: Has Any Value
	 Then In the product lookup Page, In the Products table I click the Reset Button
	 Then I confirm the page has refreshed
	 Then I confirm that the recent activities page bread crumb area does not contain the label: Has Any Value
	 Then In the product lookup page, I click the Open Report Button
	 Then I confirm the Report popup displays the following title: Open Report
	 Then In Open Report popup, Report:auomationtest is displayed 
	 Then In Open Report popup, I Select Report:auomationtest
	 Then In Open Report popup, I click Open button
	 Then In the Product Lookup Page, The Report Popup is not showing
	 Then I confirm the page has refreshed
	 Then I confirm that the recent activities page bread crumb area contains the label: Has Any Value

	Examples:
		| Scenario Name                                                            | Retailer           | Page                    | IsWebviewer |
 		| [#224810a]  3 Panel-More Filters- Has Any/No Value- Open/Save Report     | RPS.TG          | Product Lookup          | No          |
 		| [#224810b]  3 Panel-More Filters- Has Any/No Value- Open/Save Report     | RPS.SF          | Product Lookup          | No          |
 		| [#224810c]  3 Panel-More Filters- Has Any/No Value- Open/Save Report     | RPS.CT          | Product Lookup          | No          |
		| [#224810d]  3 Panel-More Filters- Has Any/No Value- Open/Save Report     | RPS.CV          | Product Lookup          | No          |
 		| [#224810e]  3 Panel-More Filters- Has Any/No Value- Open/Save Report     | RPS.LW          | Product Lookup          | No          |
	
	
Scenario Outline: [243835] 3 Panel-More Filters- Suppliers Name- Select All 
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer> 
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Then In the recent activities Page, I click the More Filters Button
	Then In the Product Lookup Page, The More Filters Popup is showing
	And In the More Filters pop up, I enter value in search box in the Filter Categories column: Supplier Name
	Then In the More Filters pop up, I confirm searched filter is displayed in Filters Panel : Supplier Name
	Then In the More Filters pop up, I click on searched filter in Filters Panel : Supplier Name
	Then In the More Filters pop up, I confirm the Filters Parameter panel populates with a list of Supplier Names
	Then In the More Filters pop up, I confirm I see Search under the filter parameter heading
	Then In the More Filters pop up, I confirm the left side of the search box, there is a dropdown box
	Then In the More Filters pop up, I confirm default value of the dropdown box is Contains
	Then In the More Filters pop up, I confirm in the Filter Parameter Panel Selector three options are : Contains, Start With and Is are displayed
    Then  In the More Filters pop up, I now type a string  in Supplier Name search field: lor 
    Then I call Shared Step 243836 (RPS- More Filters- Select All- Contains): lor
	Then I confirm the page has refreshed
	Then In the product lookup Page, In the Products table I click the Reset Button
    Then In the recent activities Page, I click the More Filters Button
	Then In the Product Lookup Page, The More Filters Popup is showing
	And In the More Filters pop up, I enter value in search box in the Filter Categories column: Supplier Name
	Then In the More Filters pop up, I confirm searched filter is displayed in Filters Panel : Supplier Name
	Then In the More Filters pop up, I click on searched filter in Filters Panel : Supplier Name
	Then In the More Filters pop up, I confirm the Filters Parameter panel populates with a list of Supplier Names
	Then In the More Filters pop up, I confirm I see Search under the filter parameter heading
	Then In the More Filters pop up, I confirm the left side of the search box, there is a dropdown box
	Then In the More Filters pop up, I confirm default value of the dropdown box is Contains
	Then In the More Filters pop up, I confirm in the Filter Parameter Panel Selector three options are : Contains, Start With and Is are displayed
	Then In the More Filters pop up, I select the option from the Parameters drop down list: Is
    Then In the More Filters pop up, In the search field in the Filter Parameters panel, In the search box, I enter full Supplier Name: savedAs
    Then I confirm I see the Supplier Name I was searching for: savedAs
    Then I call Shared Step 243837 (RPS- More Filters- Select All- Is): savedAs
	Then I confirm the page has refreshed
	Then In the product lookup Page, In the Products table I click the Reset Button
    Then In the recent activities Page, I click the More Filters Button
	Then In the Product Lookup Page, The More Filters Popup is showing
	And In the More Filters pop up, I enter value in search box in the Filter Categories column: Supplier Name
	Then In the More Filters pop up, I confirm searched filter is displayed in Filters Panel : Supplier Name
	Then In the More Filters pop up, I click on searched filter in Filters Panel : Supplier Name
	Then In the More Filters pop up, I confirm the Filters Parameter panel populates with a list of Supplier Names
	Then In the More Filters pop up, I confirm I see Search under the filter parameter heading
	Then In the More Filters pop up, I confirm the left side of the search box, there is a dropdown box
	Then In the More Filters pop up, I confirm default value of the dropdown box is Contains
	Then In the More Filters pop up, I confirm in the Filter Parameter Panel Selector three options are : Contains, Start With and Is are displayed
	Then In the More Filters pop up, I select the option from the Parameters drop down list: Starts with
	Then In the More Filters pop up, I now type a string  in Supplier Name search field: Lor
	Then In the More Filters pop up, I confirm the list of items shown is narrowed based on the characters I enter: Lor
    Then I call Shared Step 243838 (RPS- More Filters- Select All- Starts with): Lor
	Then I confirm the page has refreshed

	Examples:
		| Scenario Name                                                     | Retailer        | Page                    | IsWebviewer |
 		| [#243835a]  3 Panel-More Filters- Suppliers Name- Select All      | RPS.TG          | Product Lookup          | No          |
 		| [#243835b]  3 Panel-More Filters- Suppliers Name- Select All      | RPS.TG          | Recent Activities       | No          |
# 		| [#243835c]  3 Panel-More Filters- Suppliers Name- Select All      | RPS.CV          | Product Lookup          | No          |
		| [#243835d]  3 Panel-More Filters- Suppliers Name- Select All      | RPS.CV          | Recent Activities       | No          |
#		| [#243835e]  3 Panel-More Filters- Suppliers Name- Select All      | RPS.LW          | Product Lookup          | No          |
		| [#243835f]  3 Panel-More Filters- Suppliers Name- Select All      | RPS.LW          | Recent Activities       | No          |
		| [#243835g]  3 Panel-More Filters- Suppliers Name- Select All      | RPS.SF          | Product Lookup          | No          |
 		| [#243835h]  3 Panel-More Filters- Suppliers Name- Select All      | RPS.SF          | Recent Activities       | No          |
#		| [#243835i]  3 Panel-More Filters- Suppliers Name- Select All      | RPS.LW          | Demo Viewer             | Yes         |
#		| [#243835j]  3 Panel-More Filters- Suppliers Name- Select All      | RPS.TG          | Store Viewer            | Yes         |
#		| [#243835k]  3 Panel-More Filters- Suppliers Name- Select All      | RPS.TG          | Status Viewer           | Yes         |
#		| [#243835l]  3 Panel-More Filters- Suppliers Name- Select All      | RPS.TG          | HQ Viewer               | Yes         |
		| [#243835m]  3 Panel-More Filters- Suppliers Name- Select All      | RPS.SF          | SmartFinal_Store        | Yes         |
# 		| [#243835n]  3 Panel-More Filters- Suppliers Name- Select All      | RPS.LW          | Lowes_store             | Yes         |
#		| [#243835o]  3 Panel-More Filters- Suppliers Name- Select All      | RPS.CT          | Product Lookup          | No          |
#    	| [#243835p]  3 Panel-More Filters- Suppliers Name- Select All      | RPS.CT          | Recent Activities       | No          |
#	    | [#243835q]  3 Panel-More Filters- Suppliers Name- Select All      | RPS.CT          | Classification History  | No          |


Scenario Outline: [243839] 3 Panel-More Filters- WPSID- Select All 
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer> 
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Then In the recent activities Page, I click the More Filters Button
	Then In the Product Lookup Page, The More Filters Popup is showing
    And In the More Filters pop up, I enter value in search box in the Filter Categories column: WPS ID
	Then In the More Filters pop up, I confirm searched filter is displayed in Filters Panel : WPS ID
	Then In the More Filters pop up, I click on searched filter in Filters Panel : WPS ID 
	Then In the More Filters pop up, I confirm I see Search under the filter parameter heading
	Then In the More Filters pop up, I confirm the left side of the search box, there is a dropdown box
	Then In the More Filters pop up, I confirm default value of the dropdown box is Contains
	Then In the More Filters pop up, I confirm in the Filter Parameter Panel Selector three options are : Contains, Start With and Is are displayed 
	Then In the More Filters pop up, In Filter Parameter panel I confirm the Search field shows the default text: Search
	Then In the More Filters pop up, I confirm the Filter Parameter panel shows the WPS Id list
	Then In the More Filters pop up, In Filter Parameter panel I confirm each item for selection shows a check box before the DPCI value
    Then In the More Filters pop up, I select the option from the Parameters drop down list: Contains 
	Then In the More Filters pop up, I now type a string  in DPCI search field: 12
	Then In the More Filters pop up, I confirm the Filters Parameter panel populates with a list of DPCI values
    Then I call Shared Step 243836 (RPS- More Filters- Select All- Contains): 12
	Then I confirm the page has refreshed
	Then In the product lookup Page, In the Products table I click the Reset Button
    Then In the recent activities Page, I click the More Filters Button
	Then In the Product Lookup Page, The More Filters Popup is showing
    And In the More Filters pop up, I enter value in search box in the Filter Categories column: WPS ID
	Then In the More Filters pop up, I confirm searched filter is displayed in Filters Panel : WPS ID
	Then In the More Filters pop up, I click on searched filter in Filters Panel : WPS ID
	Then In the More Filters pop up, I confirm I see Search under the filter parameter heading
	Then In the More Filters pop up, I confirm the left side of the search box, there is a dropdown box
	Then In the More Filters pop up, I confirm default value of the dropdown box is Contains
	Then In the More Filters pop up, I confirm in the Filter Parameter Panel Selector three options are : Contains, Start With and Is are displayed 
	Then In the More Filters pop up, In Filter Parameter panel I confirm the Search field shows the default text: Search
	Then In the More Filters pop up, I confirm the Filter Parameter panel shows the DPCI list 
	Then In the More Filters pop up, In the search field in the Filter Parameters panel, In the search box, I enter full WPS ID: savedAs
    Then In the More Filters pop up, I select the option from the Parameters drop down list: Is 
	Then I confirm I see the Supplier Name I was searching for: savedAs
    Then I call Shared Step 243837 (RPS- More Filters- Select All- Is): savedAs
	Then I confirm the page has refreshed
	Then In the product lookup Page, In the Products table I click the Reset Button
    Then In the recent activities Page, I click the More Filters Button
	Then In the Product Lookup Page, The More Filters Popup is showing
	And In the More Filters pop up, I enter value in search box in the Filter Categories column: WPS ID
	Then In the More Filters pop up, I confirm searched filter is displayed in Filters Panel : WPS ID
	Then In the More Filters pop up, I click on searched filter in Filters Panel : WPS ID
	Then In the More Filters pop up, I confirm I see Search under the filter parameter heading
	Then In the More Filters pop up, I confirm the left side of the search box, there is a dropdown box
	Then In the More Filters pop up, I confirm default value of the dropdown box is Contains
	Then In the More Filters pop up, I confirm in the Filter Parameter Panel Selector three options are : Contains, Start With and Is are displayed 
	Then In the More Filters pop up, In Filter Parameter panel I confirm the Search field shows the default text: Search
	Then In the More Filters pop up, I confirm the Filter Parameter panel shows the DPCI list
	Then In the More Filters pop up, In Filter Parameter panel I confirm each item for selection shows a check box before the DPCI value
    Then In the More Filters pop up, I select the option from the Parameters drop down list: Starts with
	Then In the More Filters pop up, I now type a string  in DPCI search field: 100
	Then In the More Filters pop up, I confirm the list of items shown is narrowed based on the characters I enter: 100
    Then I call Shared Step 243838 (RPS- More Filters- Select All- Starts with): 100
	Then I confirm the page has refreshed

	Examples:
		| Scenario Name                                            | Retailer        | Page                    | IsWebviewer |
 		| [#243839a]  3 Panel-More Filters- WPSID- Select All      | RPS.TG          | Product Lookup          | No          |
 		| [#243839b]  3 Panel-More Filters- WPSID- Select All      | RPS.TG          | Recent Activities       | No          |
# 		| [#243839c]  3 Panel-More Filters- WPSID- Select All      | RPS.CV          | Product Lookup          | No          |
#		| [#243839d]  3 Panel-More Filters- WPSID- Select All      | RPS.CV          | Recent Activities       | No          |
#		| [#243839e]  3 Panel-More Filters- WPSID- Select All      | RPS.LW          | Product Lookup          | No          |
		| [#243839f]  3 Panel-More Filters- WPSID- Select All      | RPS.LW          | Recent Activities       | No          |
		| [#243839g]  3 Panel-More Filters- WPSID- Select All      | RPS.SF          | Product Lookup          | No          |
 		| [#243839h]  3 Panel-More Filters- WPSID- Select All      | RPS.SF          | Recent Activities       | No          |
#		| [#243839i]  3 Panel-More Filters- WPSID- Select All      | RPS.LW          | Demo Viewer             | Yes         |
#		| [#243839j]  3 Panel-More Filters- WPSID- Select All      | RPS.TG          | Store Viewer            | Yes         |
#		| [#243839k]  3 Panel-More Filters- WPSID- Select All      | RPS.TG          | Status Viewer           | Yes         |
#		| [#243839l]  3 Panel-More Filters- WPSID- Select All      | RPS.TG          | HQ Viewer               | Yes         |
		| [#243839m]  3 Panel-More Filters- WPSID- Select All      | RPS.SF          | SmartFinal_Store        | Yes         |
# 		| [#243839n]  3 Panel-More Filters- WPSID- Select All      | RPS.LW          | Lowes_store             | Yes         |
#		| [#243839o]  3 Panel-More Filters- WPSID- Select All      | RPS.CT          | Product Lookup          | No          |
#    	| [#243839p]  3 Panel-More Filters- WPSID- Select All      | RPS.CT          | Recent Activities       | No          |
#	    | [#243839q]  3 Panel-More Filters- WPSID- Select All      | RPS.CT          | Classification History  | No          |
