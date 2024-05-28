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

Feature: Actions

Scenario: [169248] View Data  - Transportation Data - confirm fields shown
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
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
	Then I call Shared Step 110820 (View Data - Product Information pop up - Expand Transportation Data (Longer version) - confirm rows)



	Examples:
		| Scenario Name                                                        | Retailer        | Page                    | IsWebviewer |
#		| [#169248a]  View Data  - Transportation Data - confirm fields shown  | RPS.TG          | Product Lookup          | No          |
#		| [#169248b]  View Data  - Transportation Data - confirm fields shown  | RPS.TG          | Recent Activities       | No          |
		| [#169248c]  View Data  - Transportation Data - confirm fields shown  | RPS.SF          | Product Lookup          | No          |
		| [#169248d]  View Data  - Transportation Data - confirm fields shown  | RPS.SF          | Recent Activities       | No          |
		| [#169248e]  View Data  - Transportation Data - confirm fields shown  | RPS.LW          | Product Lookup          | No          |
		| [#169248f]  View Data  - Transportation Data - confirm fields shown  | RPS.LW          | Recent Activities       | No          |
	

	Scenario: [169258]  View Data  - Battery Data - confirm fields shown
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the Home tab has loaded
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Then I Click the Row actions: View Data for the first product in the Products Grid
	Then I Confirm that Product Information pop up is shown
	Then I call Shared Step 163151 (Product Information pop up - New version - Battery Data - confirm rows)



	Examples:
		| Scenario Name                                                  | Retailer        | Page                    | IsWebviewer |
#		| [#169258a]   View Data  - Battery Data - confirm fields shown  | RPS.TG          | Product Lookup          | No          |
#		| [#169258b]   View Data  - Battery Data - confirm fields shown  | RPS.TG          | Recent Activities       | No          |
		| [#169258c]   View Data  - Battery Data - confirm fields shown  | RPS.SF          | Product Lookup          | No          |
		| [#169258d]   View Data  - Battery Data - confirm fields shown  | RPS.SF          | Recent Activities       | No          |
		| [#169258e]   View Data  - Battery Data - confirm fields shown  | RPS.LW          | Product Lookup          | No          |
		| [#169258f]   View Data  - Battery Data - confirm fields shown  | RPS.LW          | Recent Activities       | No          |
		| [#169258g]   View Data  - Battery Data - confirm fields shown  | RPS.CV          | Product Lookup          | No          |
		| [#169258h]   View Data  - Battery Data - confirm fields shown  | RPS.CV          | Recent Activities       | No          |	

Scenario: [169234]  View Data  - Product Data codes - confirm fields shown
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the Home tab has loaded
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Then I Click the Row actions: View Data for the first product in the Products Grid
	Then I Confirm that Product Information pop up is shown
	Then I call Shared Step 152620 (View Data - Product Information pop up - Product Details - Confirm rows)



	Examples:
		| Scenario Name                                                        | Retailer        | Page                    | IsWebviewer |
#		| [#169234a]   View Data  - Product Data codes - confirm fields shown  | RPS.TG          | Product Lookup          | No          |
#		| [#169234b]   View Data  - Product Data codes - confirm fields shown  | RPS.TG          | Recent Activities       | No          |
		| [#169234c]   View Data  - Product Data codes - confirm fields shown  | RPS.SF          | Product Lookup          | No          |
		| [#169234d]   View Data  - Product Data codes - confirm fields shown  | RPS.SF          | Recent Activities       | No          |
		| [#169234e]   View Data  - Product Data codes - confirm fields shown  | RPS.LW          | Product Lookup          | No          |
		| [#169234f]   View Data  - Product Data codes - confirm fields shown  | RPS.LW          | Recent Activities       | No          |
#		| [#169234g]   View Data  - Product Data codes - confirm fields shown  | RPS.TG          | Target_Store            | Yes         |
#		| [#169234h]   View Data  - Product Data codes - confirm fields shown  | RPS.TG          | Target_Status           | Yes         |	
		| [#169234i]   View Data  - Product Data codes - confirm fields shown  | RPS.LW          | Lowes_Store             | Yes         |
#		| [#169234j]   View Data  - Product Data codes - confirm fields shown  | RPS.TG          | Target_HQ               | Yes         |
		| [#169234k]   View Data  - Product Data codes - confirm fields shown  | RPS.SF          | SmartFinal_Store        | Yes         |	


Scenario: [169568]  View Data  - Disposal - confirm fields shown
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the Home tab has loaded
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Then I Click the Row actions: View Data for the first product in the Products Grid
	Then I Confirm that Product Information pop up is shown
	Then I call Shared Step 163160 (Product Information pop up - New Version - Disposal - Confirm rows)



	Examples:
		| Scenario Name                                              | Retailer        | Page                    | IsWebviewer |
#		| [#169568a]   View Data  - Disposal - confirm fields shown  | RPS.TG          | Target_Store            | Yes         |
#		| [#169568b]   View Data  - Disposal - confirm fields shown  | RPS.TG          | Target_Status           | Yes         |	
		| [#169568c]   View Data  - Disposal - confirm fields shown  | RPS.LW          | Lowes_Store             | Yes         |
#		| [#169568d]   View Data  - Disposal - confirm fields shown  | RPS.TG          | Target_HQ               | Yes         |
		| [#169568e]   View Data  - Disposal - confirm fields shown  | RPS.SF          | SmartFinal_Store        | Yes         |	


Scenario: [169257]  View Data  - Storage Data - confirm fields shown 
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the Home tab has loaded
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Then I Click the Row actions: View Data for the first product in the Products Grid
	Then I Confirm that Product Information pop up is shown
	Then I call Shared Step 163153 (Product Information pop up - New version - Storage Data - Confirm rows)



	Examples:
		| Scenario Name                                                   | Retailer        | Page                    | IsWebviewer |
#		| [#169257a]   View Data  - Storage Data - confirm fields shown   | RPS.TG          | Product Lookup          | No          |
#		| [#169257b]   View Data  - Storage Data - confirm fields shown   | RPS.TG          | Recent Activities       | No          |
		| [#169257c]   View Data  - Storage Data - confirm fields shown   | RPS.SF          | Product Lookup          | No          |
		| [#169257d]   View Data  - Storage Data - confirm fields shown   | RPS.SF          | Recent Activities       | No          |
		| [#169257e]   View Data  - Storage Data - confirm fields shown   | RPS.LW          | Product Lookup          | No          |
		| [#169257f]   View Data  - Storage Data - confirm fields shown   | RPS.LW          | Recent Activities       | No          |
#		| [#169257g]   View Data  - Storage Data - confirm fields shown   | RPS.TG          | Target_Store            | Yes         |
		| [#169257h]   View Data  - Storage Data - confirm fields shown   | RPS.CV          | Product Lookup          | No          |	
		| [#169257i]   View Data  - Storage Data - confirm fields shown   | RPS.CV          | Recent Activities       | No          |


Scenario: [169264] View Data - Both Product and UPC Name are shown when UPC Name is present
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the Home tab has loaded
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Then I Enter Product ID : 1625737 in Search field
	Then I confirm the page has refreshed
	Then I save the Product Name shown for the product as: savedAs I am working with
	Then I Click the Row actions: View Data for the first product in the Products Grid
	Then I wait for the Product Information Popup to load
	Then I Confirm that Product Information pop up is shown
	Then I confirm I  see both a product name and a UPC name
	Then I confirm that the UPC name saved: savedAs is shown in Product Information pop up 

	Examples:
		| Scenario Name                                                                           | Retailer        | Page                    | IsWebviewer |
		| [#169264a]   View Data - Both Product and UPC Name are shown when UPC Name is present   | RPS.CV          | Product Lookup          | No          |
		| [#169264b]   View Data - Both Product and UPC Name are shown when UPC Name is present   | RPS.CV          | Recent Activities       | No          |
#		| [#169264c]   View Data - Both Product and UPC Name are shown when UPC Name is present   | RPS.LW          | Product Lookup          | No          |
#		| [#169264d]   View Data - Both Product and UPC Name are shown when UPC Name is present   | RPS.LW          | Recent Activities       | No          |
#		| [#169264e]   View Data - Both Product and UPC Name are shown when UPC Name is present   | RPS.LW          | Demo Viewer             | Yes         |
#		| [#169264f]   View Data - Both Product and UPC Name are shown when UPC Name is present   | RPS.TG          | Recent Activities       | No          |
#		| [#169264g]   View Data - Both Product and UPC Name are shown when UPC Name is present   | RPS.TG          | Target_Store            | Yes         |
#		| [#169264h]   View Data - Both Product and UPC Name are shown when UPC Name is present   | RPS.TG          | Product Lookup          | No          |	
#		| [#169264i]   View Data - Both Product and UPC Name are shown when UPC Name is present   | RPS.TG          | Target_Status           | Yes         |
#       | [#169264g]   View Data - Both Product and UPC Name are shown when UPC Name is present   | RPS.TG          | Target_HQ               | Yes         |
		| [#169264k]   View Data - Both Product and UPC Name are shown when UPC Name is present   | RPS.SF          | Recent Activities       | No          |
		| [#169264l]   View Data - Both Product and UPC Name are shown when UPC Name is present   | RPS.SF          | Product Lookup          | No          |
#		| [#169264m]   View Data - Both Product and UPC Name are shown when UPC Name is present   | RPS.SF          | Store Viewer            | Yes         |
#		| [#169264n]   View Data - Both Product and UPC Name are shown when UPC Name is present   | RPS.LW          | Drum Log                | No          |
		| [#169264o]   View Data - Both Product and UPC Name are shown when UPC Name is present   | RPS.CT          | Recent Activities       | No          |
		| [#169264p]   View Data - Both Product and UPC Name are shown when UPC Name is present   | RPS.CT          | Product Lookup          | No          |
#		| [#169264q]   View Data - Both Product and UPC Name are shown when UPC Name is present   | RPS.CT          | Classification History  | No          |		   

Scenario: [169261] View Data  - Collapse All
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the Home tab has loaded
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Then I call Shared Step 153375 (RPS > Actions > View Data > Collapse All)

	Examples:
		| Scenario Name                            | Retailer        | Page                    | IsWebviewer |
		| [#169261a]   View Data  - Collapse All   | RPS.CV          | Product Lookup          | No          |
		| [#169261b]   View Data  - Collapse All   | RPS.CV          | Recent Activities       | No          |
#		| [#169261c]   View Data  - Collapse All   | RPS.LW          | Product Lookup          | No          |
#		| [#169261d]   View Data  - Collapse All   | RPS.LW          | Recent Activities       | No          |
#		| [#169261e]   View Data  - Collapse All   | RPS.LW          | Demo Viewer             | Yes         |
#		| [#169261f]   View Data  - Collapse All   | RPS.TG          | Recent Activities       | No          |
#		| [#169261g]   View Data  - Collapse All   | RPS.TG          | Target_Store            | Yes         |
#		| [#169261h]   View Data  - Collapse All   | RPS.TG          | Product Lookup          | No          |	
#		| [#169261i]   View Data  - Collapse All   | RPS.TG          | Target_Status           | Yes         |
#       | [#169261g]   View Data  - Collapse All   | RPS.TG          | Target_HQ               | Yes         |
		| [#169261k]   View Data  - Collapse All   | RPS.SF          | Recent Activities       | No          |
		| [#169261l]   View Data  - Collapse All   | RPS.SF          | Product Lookup          | No          |
#		| [#169261m]   View Data  - Collapse All   | RPS.SF          | Store Viewer            | Yes         |
#		| [#169261n]   View Data  - Collapse All   | RPS.LW          | Drum Log                | No          |
		| [#169261o]   View Data  - Collapse All   | RPS.CT          | Recent Activities       | No          |
		| [#169261p]   View Data  - Collapse All   | RPS.CT          | Product Lookup          | No          |
#		| [#169261q]   View Data  - Collapse All   | RPS.CT          | Classification History  | No          |		   


Scenario: [169572] View Data  - sections remain expanded until closed
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the Home tab has loaded
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Then I Click the Row actions: View Data for the first product in the Products Grid
	Then I wait for the Product Information Popup to load
	Then I Confirm that Product Information pop up is shown
	Then I call Shared Step 151306 (View Data - Product Information pop up - Product Data Codes > Collapse and Expand)
	Then I call Shared Step 152628 (View Data - Product Information pop up - Transportation Data > Collapse and Expand)
	Then I call Shared Step 152629 (View Data - Product Information pop up - Storage Data > Collapse and Expand)
	Then I call Shared Step 152630 (View Data - Product Information pop up - Battery Data > Collapse and Expand)

	Examples:
		| Scenario Name                                                     | Retailer        | Page                    | IsWebviewer |
		| [#169572a]   View Data  - sections remain expanded until closed   | RPS.CV          | Product Lookup          | No          |
		| [#169572b]   View Data  - sections remain expanded until closed   | RPS.CV          | Recent Activities       | No          |
#		| [#169572c]   View Data  - sections remain expanded until closed   | RPS.LW          | Product Lookup          | No          |
#		| [#169572d]   View Data  - sections remain expanded until closed   | RPS.LW          | Recent Activities       | No          |
#		| [#169572e]   View Data  - sections remain expanded until closed   | RPS.LW          | Demo Viewer             | Yes         |
#		| [#169572f]   View Data  - sections remain expanded until closed   | RPS.TG          | Recent Activities       | No          |
#		| [#169572g]   View Data  - sections remain expanded until closed   | RPS.TG          | Target_Store            | Yes         |
#		| [#169572h]   View Data  - sections remain expanded until closed   | RPS.TG          | Product Lookup          | No          |	
#		| [#169572i]   View Data  - sections remain expanded until closed   | RPS.TG          | Target_Status           | Yes         |
#       | [#169572g]   View Data  - sections remain expanded until closed   | RPS.TG          | Target_HQ               | Yes         |
		| [#169572k]   View Data  - sections remain expanded until closed   | RPS.SF          | Recent Activities       | No          |
		| [#169572l]   View Data  - sections remain expanded until closed   | RPS.SF          | Product Lookup          | No          |
#		| [#169572m]   View Data  - sections remain expanded until closed   | RPS.SF          | Store Viewer            | Yes         |
#		| [#169572n]   View Data  - sections remain expanded until closed   | RPS.LW          | Drum Log                | No          |
		| [#169572o]   View Data  - sections remain expanded until closed   | RPS.CT          | Recent Activities       | No          |
		| [#169572p]   View Data  - sections remain expanded until closed   | RPS.CT          | Product Lookup          | No          |
#		| [#169572q]   View Data  - sections remain expanded until closed   | RPS.CT          | Classification History  | No          |		   


Scenario: [169263] View Data  - Retailer Uploaded Product - pop up layout
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the Home tab has loaded
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Then I Enter Product ID : 9100 in Search field
	Then I confirm the page has loaded
	And I save the Product Name shown for the product as: savedAs I am working with
	Then I Click the Row actions: View Data for the first product in the Products Grid
	Then I wait for the Product Information Popup to load
	Then I Confirm that Product Information pop up is shown
	Then In the Product Information pop up I confirm the Product line shows the product name before the WPS ID
	Then I confirm the name shown matches the name I made a note : savedAs
	Then I call Shared Step 211934 (Product Information - For Retailer Uploaded) for TReVor account: <Retailer>

	


	Examples:
		| Scenario Name                                                       | Retailer        | Page                    | IsWebviewer |
#		| [#169263a]  View Data  - Retailer Uploaded Product - pop up layout  | RPS.TG          | Product Lookup          | No          |
#		| [#169263b]  View Data  - Retailer Uploaded Product - pop up layout  | RPS.TG          | Recent Activities       | No          |
		| [#169263c]  View Data  - Retailer Uploaded Product - pop up layout  | RPS.CT          | Product Lookup          | No          |
		| [#169263d]  View Data  - Retailer Uploaded Product - pop up layout  | RPS.CT          | Recent Activities       | No          |
#		| [#169263e]  View Data  - Retailer Uploaded Product - pop up layout  | RPS.TG          | Target_Store            | Yes         |
#		| [#169263f]  View Data  - Retailer Uploaded Product - pop up layout  | RPS.TG          | Target_HQ               | Yes         |
#	    | [#169263f]  View Data  - Retailer Uploaded Product - pop up layout  | RPS.TG          | Target_Status           | Yes         |

Scenario: [169262] View Data  - Expand All
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the Home tab has loaded
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Then I call Shared Step 153374 (RPS - Actions - View Data > Expand All)


	Examples:
		| Scenario Name                        | Retailer        | Page                    | IsWebviewer |
#		| [#169262a]  View Data  - Expand All  | RPS.CV          | Product Lookup          | No          |
#		| [#169262b]  View Data  - Expand All  | RPS.CV          | Recent Activities       | No          |
		| [#169262c]  View Data  - Expand All  | RPS.LW          | Product Lookup          | No          |
		| [#169262d]  View Data  - Expand All  | RPS.LW          | Recent Activities       | No          |
		| [#169262e]  View Data  - Expand All  | RPS.LW          | Demo Viewer             | Yes         |
#		| [#169262f]  View Data  - Expand All  | RPS.TG          | Target_HQ               | Yes         |
#	    | [#169262g]  View Data  - Expand All  | RPS.TG          | Target_Status           | Yes         |
#		| [#169262h]  View Data  - Expand All  | RPS.TG          | Target_Store            | No          |
#		| [#169262i]  View Data  - Expand All  | RPS.TG          | Recent Activities       | No          |
#		| [#169262j]  View Data  - Expand All  | RPS.TG          | Product Lookup          | No          |
		| [#169262k]  View Data  - Expand All  | RPS.SF          | Recent Activities       | No          |
		| [#169262l]  View Data  - Expand All  | RPS.SF          | Product Lookup          | Yes         |
		| [#169262m]  View Data  - Expand All  | RPS.SF          | Store Viewer            | Yes         |
	    | [#169262n]  View Data  - Expand All  | RPS.LW          | Drum Log                | Yes         |
		| [#169262o]  View Data  - Expand All  | RPS.CT          | Product Lookup          | No          |
		| [#169262p]  View Data  - Expand All  | RPS.CT          | Recent Activities       | No          |
#		| [#169262q]  View Data  - Expand All  | RPS.CT          | Classification History  | No          |
	