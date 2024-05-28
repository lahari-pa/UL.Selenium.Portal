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

Feature: Documents

Scenario Outline: [169582] Status/Logistics Viewer - Document - US Only, PLP = No, Authored SDS
    Given I call Shared Step 65080 (Login to Studio and Open SHA manager) 
	And I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: 1625268)
	Then I call Shared Step 146584 (WPS Studio - PD+ - Current Document > List of Published > Open NGHS - keep window open)
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the Home tab has loaded
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Given I call Shared Step 153152 (RPS/WV : Search for specific product) WPSId: 1625268
	Then I click on the Documents Link
	Then I call Shared Step 220316 (Webviewer: Documents - SDS US opens directly - compare to NGHS)
	Examples:
		| Scenario Name                                                                     | Retailer        | Page                    | IsWebviewer  |
#		| [#169582a]  Status/Logistics Viewer - Document - US Only, PLP = No, Authored SDS  | RPS.TG          | Status Viewer           | Yes          |
#		| [#169582b]  Status/Logistics Viewer - Document - US Only, PLP = No, Authored SDS  | RPS.TG          | HQ Store Viewer         | Yes          |
#		| [#169582c]  Status/Logistics Viewer - Document - US Only, PLP = No, Authored SDS  | RPS.TG          | Store Viewer            | Yes          |
		| [#169582d]  Status/Logistics Viewer - Document - US Only, PLP = No, Authored SDS  | RPS.SF          | SmartFinal_Store        | Yes          |
#		| [#169582e]  Status/Logistics Viewer - Document - US Only, PLP = No, Authored SDS  | RPS.LW          | lowes_store             | Yes          |


Scenario Outline: [169583] Status/Logistics Viewer Document - US Only, PLP = No, Uploads own SDS on Submission
    Given I call Shared Step 65080 (Login to Studio and Open SHA manager) 
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: 1625277)
	And I call Shared Step 49743 - SHA Manager - Select Product - Actions - Document Management for saved as: 1625277
	Then I call Shared Step 146422 (SHA Manager > Document Management > Primary 1, Source 0, document)
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the Home tab has loaded
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Given I call Shared Step 153152 (RPS/WV : Search for specific product) WPSId: 1625277
	Then I click on the Documents Link
	Then I call Shared Step 220438 (Webviewer: Documents - US SDS opens directly - compare to Uploaded SDS)

	Examples:
		| Scenario Name                                                                                    | Retailer        | Page                    | IsWebviewer  |
#		| [#169583a]  Status/Logistics Viewer Document - US Only, PLP = No, Uploads own SDS on Submission  | RPS.TG          | Status Viewer           | Yes          |
#		| [#169583b]  Status/Logistics Viewer Document - US Only, PLP = No, Uploads own SDS on Submission  | RPS.TG          | HQ Store Viewer         | Yes          |
#		| [#169583c]  Status/Logistics Viewer Document - US Only, PLP = No, Uploads own SDS on Submission  | RPS.TG          | Store Viewer            | Yes          |
		| [#169583d]  Status/Logistics Viewer Document - US Only, PLP = No, Uploads own SDS on Submission  | RPS.SF          | SmartFinal_Store        | Yes          |
#		| [#169583e]  Status/Logistics Viewer Document - US Only, PLP = No, Uploads own SDS on Submission  | RPS.LW          | lowes_store             | Yes          |      


Scenario: [169581] Status/Logistics Viewer - Document - US Only, PLP = Yes, Uploads own SDS on Submission
    Given I call Shared Step 65080 (Login to Studio and Open SHA manager) 
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: 1619826)
	And I call Shared Step 49743 - SHA Manager - Select Product - Actions - Document Management for saved as: 1619826
	Then I call Shared Step 146422 (SHA Manager > Document Management > Primary 1, Source 0, document)
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the Home tab has loaded
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Given I call Shared Step 153152 (RPS/WV : Search for specific product) WPSId: 1619826
	Then I click on the Documents Link
	Then I call Shared Step 220438 (Webviewer: Documents - US SDS opens directly - compare to Uploaded SDS)

	Examples:
		| Scenario Name                                                                                       | Retailer        | Page                    | IsWebviewer  |
#		| [#169581a]  Status/Logistics Viewer - Document - US Only, PLP = Yes, Uploads own SDS on Submission  | RPS.TG          | Status Viewer           | Yes          |
#		| [#169581b]  Status/Logistics Viewer - Document - US Only, PLP = Yes, Uploads own SDS on Submission  | RPS.TG          | HQ Store Viewer         | Yes          |
#		| [#169581c]  Status/Logistics Viewer - Document - US Only, PLP = Yes, Uploads own SDS on Submission  | RPS.TG          | Store Viewer            | Yes          |
		| [#169581d]  Status/Logistics Viewer - Document - US Only, PLP = Yes, Uploads own SDS on Submission  | RPS.SF          | SmartFinal_Store        | Yes          |
#		| [#169581e]  Status/Logistics Viewer - Document - US Only, PLP = Yes, Uploads own SDS on Submission  | RPS.LW          | lowes_store             | Yes          |      
	
	
	Scenario Outline: [169588] Status/Logistics Viewer -  Document - US & Canada, PLP = Yes, Uploaded US SDS 
    Given I call Shared Step 65080 (Login to Studio and Open SHA manager) 
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: 1625486)
	And I call Shared Step 49743 - SHA Manager - Select Product - Actions - Document Management for saved as: 1625486
	Then I call Shared Step 146422 (SHA Manager > Document Management > Primary 1, Source 0, document)
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the Home tab has loaded
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Given I call Shared Step 153152 (RPS/WV : Search for specific product) WPSId: 1625486
	Then I click on the Documents Link
	Then I call Shared Step 220438 (Webviewer: Documents - US SDS opens directly - compare to Uploaded SDS)

	Examples:
		| Scenario Name                                                                               | Retailer        | Page                    | IsWebviewer  |
#		| [#169588a]  Status/Logistics Viewer -  Document - US & Canada, PLP = Yes, Uploaded US SDS   | RPS.TG          | Status Viewer           | Yes          |
#		| [#169588b]  Status/Logistics Viewer -  Document - US & Canada, PLP = Yes, Uploaded US SDS   | RPS.TG          | HQ Store Viewer         | Yes          |
#		| [#169588c]  Status/Logistics Viewer -  Document - US & Canada, PLP = Yes, Uploaded US SDS   | RPS.TG          | Store Viewer            | Yes          |
		| [#169588d]  Status/Logistics Viewer -  Document - US & Canada, PLP = Yes, Uploaded US SDS   | RPS.SF          | SmartFinal_Store        | Yes          |
#		| [#169588e]  Status/Logistics Viewer -  Document - US & Canada, PLP = Yes, Uploaded US SDS   | RPS.LW          | lowes_store             | Yes          |      

Scenario Outline: [169589] Status Viewer - Document - US & Canada, PLP = No, Published US SDS
    Given I call Shared Step 65080 (Login to Studio and Open SHA manager) 
	And I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: 1625327)
	Then I call Shared Step 146584 (WPS Studio - PD+ - Current Document > List of Published > Open NGHS - keep window open)
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the Home tab has loaded
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Given I call Shared Step 153152 (RPS/WV : Search for specific product) WPSId: 1625327
	Then I click on the Documents Link
	Then I call Shared Step 220316 (Webviewer: Documents - SDS US opens directly - compare to NGHS)

	Examples:
		| Scenario Name                                                                    | Retailer        | Page                    | IsWebviewer  |
#		| [#169589a]  Status Viewer - Document - US & Canada, PLP = No, Published US SDS   | RPS.TG          | Status Viewer           | Yes          |
#		| [#169589b]  Status Viewer - Document - US & Canada, PLP = No, Published US SDS   | RPS.TG          | HQ Store Viewer         | Yes          |
#		| [#169589c]  Status Viewer - Document - US & Canada, PLP = No, Published US SDS   | RPS.TG          | Store Viewer            | Yes          |
		| [#169589d]  Status Viewer - Document - US & Canada, PLP = No, Published US SDS   | RPS.SF          | SmartFinal_Store        | Yes          |
#		| [#169589e]  Status Viewer - Document - US & Canada, PLP = No, Published US SDS   | RPS.LW          | lowes_store             | Yes          |      


Scenario Outline: [169590] Status/Logistics Viewer - Document - US & Canada, PLP = No, Uploaded US SDS
    Given I call Shared Step 65080 (Login to Studio and Open SHA manager) 
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: 1625348)
	And I call Shared Step 49743 - SHA Manager - Select Product - Actions - Document Management for saved as: 1625348
	Then I call Shared Step 146422 (SHA Manager > Document Management > Primary 1, Source 0, document)
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the Home tab has loaded
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Given I call Shared Step 153152 (RPS/WV : Search for specific product) WPSId: 1625348
	Then I click on the Documents Link
	Then I call Shared Step 220438 (Webviewer: Documents - US SDS opens directly - compare to Uploaded SDS)

	Examples:
		| Scenario Name                                                                             | Retailer        | Page                    | IsWebviewer  |
#		| [#169590a]  Status/Logistics Viewer - Document - US & Canada, PLP = No, Uploaded US SDS   | RPS.TG          | Status Viewer           | Yes          |
#		| [#169590b]  Status/Logistics Viewer - Document - US & Canada, PLP = No, Uploaded US SDS   | RPS.TG          | HQ Store Viewer         | Yes          |
#		| [#169590c]  Status/Logistics Viewer - Document - US & Canada, PLP = No, Uploaded US SDS   | RPS.TG          | Store Viewer            | Yes          |
		| [#169590d]  Status/Logistics Viewer - Document - US & Canada, PLP = No, Uploaded US SDS   | RPS.SF          | SmartFinal_Store        | Yes          |
#		| [#169590e]  Status/Logistics Viewer - Document - US & Canada, PLP = No, Uploaded US SDS   | RPS.LW          | lowes_store             | Yes          |      


Scenario Outline: [169587] Status/Logistics Viewer - Document - US & Canada, PLP = Yes, GenDoc = 1, Published  Alias US SDS
    Given I call Shared Step 65080 (Login to Studio and Open SHA manager) 
	And I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: 1625484)
	Then I call Shared Step 146583 (WPS Studio - PD+ - Select Alias product for retailer) WPSID: 1625484 Retailer: <Retailer>
	Then I call Shared Step 146584 (WPS Studio - PD+ - Current Document > List of Published > Open NGHS - keep window open)
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the Home tab has loaded
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Given I call Shared Step 153152 (RPS/WV : Search for specific product) WPSId: 1625484
	Then I click on the Documents Link
	Then I call Shared Step 220316 (Webviewer: Documents - SDS US opens directly - compare to NGHS)

	Examples:
		| Scenario Name                                                                                                 | Retailer        | Page                    | IsWebviewer  |
#		| [#169587a]  Status/Logistics Viewer - Document - US & Canada, PLP = Yes, GenDoc = 1, Published  Alias US SDS  | RPS.TG          | Status Viewer           | Yes          |
#		| [#169587b]  Status/Logistics Viewer - Document - US & Canada, PLP = Yes, GenDoc = 1, Published  Alias US SDS  | RPS.TG          | HQ Store Viewer         | Yes          |
#		| [#169587c]  Status/Logistics Viewer - Document - US & Canada, PLP = Yes, GenDoc = 1, Published  Alias US SDS  | RPS.TG          | Store Viewer            | Yes          |
		| [#169587d]  Status/Logistics Viewer - Document - US & Canada, PLP = Yes, GenDoc = 1, Published  Alias US SDS  | RPS.SF          | SmartFinal_Store        | Yes          |
#		| [#169587e]  Status/Logistics Viewer - Document - US & Canada, PLP = Yes, GenDoc = 1, Published  Alias US SDS  | RPS.LW          | lowes_store             | Yes          |      
				

Scenario Outline: [169585] Status/Logistics Viewer - Document - US & Canada, Kit Product, PLP = No, Merged SDS
    Given I call Shared Step 65080 (Login to Studio and Open SHA manager) 
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: 1626669)
	And I call Shared Step 49743 - SHA Manager - Select Product - Actions - Document Management for saved as: 1626669
	Then I call Shared Step 146422 (SHA Manager > Document Management > Primary 1, Source 0, document)
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the Home tab has loaded
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Given I call Shared Step 153152 (RPS/WV : Search for specific product) WPSId: 1626669
	Then I call Shared Step 149250 (Any Page - Actions: Open Document Link (not PLP))
	Given I call Shared Step 148846 (Webviewer: Documents > Kit > Merged SDS > Keep pop up open)
	Then I confirm  in the Document List pop up, below the main product and the SDS document confirm you see the following three battery products: For WVs TC 1460009 - US & Canada , PLP No, GenDoc 1, GENDocCA 1, Doc Accepted Yes; For WVs TC 146064 - US & Canada , PLP No, GenDoc 1, GenDocCA 1 Doc Accepted No (User rejects published SDS and uploads his own); For WVs TC 146098 - US & Canada , PLP No, GenDoc 0, GenDocCA 0
	Then I confirm For WVs TC 146009 - US & Canada , PLP No, GenDoc 1, GENDocCA 1, Doc Accepted Yes product shows the documents type: SDS 
	Then I confirm For WVs TC 146064 - US & Canada , PLP No, GenDoc 1, GenDocCA 1 Doc Accepted No (User rejects published SDS and uploads his own) product shows the documents type: SDS
	Then I confirm For WVs TC 146098 - US & Canada , PLP No, GenDoc 0, GenDocCA 0 product shows the documents type: SDS 
	Then I close the document list pop up

	Examples:
		| Scenario Name                                                                                    | Retailer        | Page                    | IsWebviewer  |
#		| [#169585a]  Status/Logistics Viewer - Document - US & Canada, Kit Product, PLP = No, Merged SDS  | RPS.TG          | Status Viewer           | Yes          |
#		| [#169585b]  Status/Logistics Viewer - Document - US & Canada, Kit Product, PLP = No, Merged SDS  | RPS.TG          | HQ Store Viewer         | Yes          |
#		| [#169585c]  Status/Logistics Viewer - Document - US & Canada, Kit Product, PLP = No, Merged SDS  | RPS.TG          | Store Viewer            | Yes          |
		| [#169585d]  Status/Logistics Viewer - Document - US & Canada, Kit Product, PLP = No, Merged SDS  | RPS.SF          | SmartFinal_Store        | Yes          |
#		| [#169585e]  Status/Logistics Viewer - Document - US & Canada, Kit Product, PLP = No, Merged SDS  | RPS.LW          | lowes_store             | Yes          |      


Scenario Outline: [169297] Document - US Only, Battery, PLP = No, Uploads own SDS and UN38.3 and SDS Summary sheet
    Given I call Shared Step 65080 (Login to Studio and Open SHA manager) 
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: 1625483)
	And I call Shared Step 49743 - SHA Manager - Select Product - Actions - Document Management for saved as: 1625483
	Then I call Shared Step 146422 (SHA Manager > Document Management > Primary 1, Source 0, document)
	And I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: 1625268)
	Then I call Shared Step 146585 (WPS Studio - PD+ - Current Document > List of Published > Open Summary Sheet - keep window open)
	Then I call Shared Step 148764 (WPS Studio - Report writer - find UN38.3 document name) for WPSID: 1625483
	Then I call Shared Step 148765 (WPS Studio - PD+ - related documents - Open UN38.3 document)
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the Home tab has loaded
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Given I call Shared Step 153152 (RPS/WV : Search for specific product) WPSId: 1625483
	Then I call Shared Step 149250 (Any Page - Actions: Open Document Link (not PLP))
	Then I call Shared Step 149246 (Webviewer: Documents >US SDS compare to Uploaded SDS)
	Then I call Shared Step 149110 (Webviewer: Documents > Battery > UN38.3 compare to Studio related document)
	Then I call Shared Step 149071 (Webviewer: Documents > SDS Summary Sheet compare to SBCS)
	Then I close the document list pop up

	Examples:
		| Scenario Name                                                                                        | Retailer        | Page                    | IsWebviewer |
#		| [#169297a]  Document - US Only, Battery, PLP = No, Uploads own SDS and UN38.3 and SDS Summary sheet  | RPS.TG          | Product Lookup          | No          |
#		| [#169297b]  Document - US Only, Battery, PLP = No, Uploads own SDS and UN38.3 and SDS Summary sheet  | RPS.TG          | Recent Activities       | No          |
		| [#169297c]  Document - US Only, Battery, PLP = No, Uploads own SDS and UN38.3 and SDS Summary sheet  | RPS.SF          | Product Lookup          | No          |
		| [#169297d]  Document - US Only, Battery, PLP = No, Uploads own SDS and UN38.3 and SDS Summary sheet  | RPS.SF          | Recent Activities       | No          |
#		| [#169297e]  Document - US Only, Battery, PLP = No, Uploads own SDS and UN38.3 and SDS Summary sheet  | RPS.LW          | Product Lookup          | No          |      
#		| [#169297f]  Document - US Only, Battery, PLP = No, Uploads own SDS and UN38.3 and SDS Summary sheet  | RPS.LW          | Recent Activities       | No          |
#		| [#169297g]  Document - US Only, Battery, PLP = No, Uploads own SDS and UN38.3 and SDS Summary sheet  | RPS.CV          | Product Lookup          | No          |
#		| [#169297h]  Document - US Only, Battery, PLP = No, Uploads own SDS and UN38.3 and SDS Summary sheet  | RPS.CV          | Recent Activities       | No          |      


Scenario Outline: [169298] Document - US Only, Battery, PLP = No, Uploads AIS document (not shown in WV) so only UN38.3 is shown and SDS Summary Sheet
    Given I call Shared Step 65080 (Login to Studio and Open SHA manager) 
	And I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: 1625268)
	Then I call Shared Step 146585 (WPS Studio - PD+ - Current Document > List of Published > Open Summary Sheet - keep window open)
	Then I call Shared Step 148764 (WPS Studio - Report writer - find UN38.3 document name) for WPSID: 1625482
	Then I call Shared Step 148765 (WPS Studio - PD+ - related documents - Open UN38.3 document)
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the Home tab has loaded
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Given I call Shared Step 153152 (RPS/WV : Search for specific product) WPSId: 1625482
	Then I call Shared Step 149250 (Any Page - Actions: Open Document Link (not PLP))
	Then I call Shared Step 149110 (Webviewer: Documents > Battery > UN38.3 compare to Studio related document)
	Then I call Shared Step 149071 (Webviewer: Documents > SDS Summary Sheet compare to SBCS)
	Then I close the document list pop up

	Examples:
		| Scenario Name                                                                                                                            | Retailer        | Page                    | IsWebviewer |
#		| [#169298a]  Document - US Only, Battery, PLP = No, Uploads AIS document (not shown in WV) so only UN38.3 is shown and SDS Summary Sheet  | RPS.TG          | Product Lookup          | No          |
#		| [#169298b]  Document - US Only, Battery, PLP = No, Uploads AIS document (not shown in WV) so only UN38.3 is shown and SDS Summary Sheet  | RPS.TG          | Recent Activities       | No          |
		| [#169298c]  Document - US Only, Battery, PLP = No, Uploads AIS document (not shown in WV) so only UN38.3 is shown and SDS Summary Sheet  | RPS.SF          | Product Lookup          | No          |
		| [#169298d]  Document - US Only, Battery, PLP = No, Uploads AIS document (not shown in WV) so only UN38.3 is shown and SDS Summary Sheet  | RPS.SF          | Recent Activities       | No          |
#		| [#169298e]  Document - US Only, Battery, PLP = No, Uploads AIS document (not shown in WV) so only UN38.3 is shown and SDS Summary Sheet  | RPS.LW          | Product Lookup          | No          |      
#		| [#169298f]  Document - US Only, Battery, PLP = No, Uploads AIS document (not shown in WV) so only UN38.3 is shown and SDS Summary Sheet  | RPS.LW          | Recent Activities       | No          |
#		| [#169298g]  Document - US Only, Battery, PLP = No, Uploads AIS document (not shown in WV) so only UN38.3 is shown and SDS Summary Sheet  | RPS.CV          | Product Lookup          | No          |
#		| [#169298h]  Document - US Only, Battery, PLP = No, Uploads AIS document (not shown in WV) so only UN38.3 is shown and SDS Summary Sheet  | RPS.CV          | Recent Activities       | No          |   


Scenario Outline: [169343] Document - US Only, Battery, PLP = Yes, Uploads AIS document (not shown in WV) so only UN38.3 & Summary Sheet are shown
    Given I call Shared Step 65080 (Login to Studio and Open SHA manager) 
	And I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: 1625268)
	Then I call Shared Step 146583 (WPS Studio - PD+ - Select Alias product for retailer) WPSID: 1625689 Retailer: <Retailer>
	Then I call Shared Step 146585 (WPS Studio - PD+ - Current Document > List of Published > Open Summary Sheet - keep window open)
	Then I call Shared Step 148764 (WPS Studio - Report writer - find UN38.3 document name) for WPSID: 1625689
	Then I call Shared Step 148765 (WPS Studio - PD+ - related documents - Open UN38.3 document)
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the Home tab has loaded
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Given I call Shared Step 153152 (RPS/WV : Search for specific product) WPSId: 1625689
	Then I call Shared Step 149196 (Any Page - Actions: Open Document Link for PLP)
	Then I call Shared Step 149110 (Webviewer: Documents > Battery > UN38.3 compare to Studio related document)
	Then I call Shared Step 149071 (Webviewer: Documents > SDS Summary Sheet compare to SBCS)
	Then I close the document list pop up

	Examples:
		| Scenario Name                                                                                                                        | Retailer        | Page                    | IsWebviewer |
#		| [#169343a]  Document - US Only, Battery, PLP = Yes, Uploads AIS document (not shown in WV) so only UN38.3 & Summary Sheet are shown  | RPS.TG          | Product Lookup          | No          |
#		| [#169343b]  Document - US Only, Battery, PLP = Yes, Uploads AIS document (not shown in WV) so only UN38.3 & Summary Sheet are shown  | RPS.TG          | Recent Activities       | No          |
		| [#169343c]  Document - US Only, Battery, PLP = Yes, Uploads AIS document (not shown in WV) so only UN38.3 & Summary Sheet are shown  | RPS.SF          | Product Lookup          | No          |
		| [#169343d]  Document - US Only, Battery, PLP = Yes, Uploads AIS document (not shown in WV) so only UN38.3 & Summary Sheet are shown  | RPS.SF          | Recent Activities       | No          |
#		| [#169343e]  Document - US Only, Battery, PLP = Yes, Uploads AIS document (not shown in WV) so only UN38.3 & Summary Sheet are shown  | RPS.LW          | Product Lookup          | No          |      
#		| [#169343f]  Document - US Only, Battery, PLP = Yes, Uploads AIS document (not shown in WV) so only UN38.3 & Summary Sheet are shown  | RPS.LW          | Recent Activities       | No          |
#		| [#169343g]  Document - US Only, Battery, PLP = Yes, Uploads AIS document (not shown in WV) so only UN38.3 & Summary Sheet are shown  | RPS.CV          | Product Lookup          | No          |
#		| [#169343h]  Document - US Only, Battery, PLP = Yes, Uploads AIS document (not shown in WV) so only UN38.3 & Summary Sheet are shown  | RPS.CV          | Recent Activities       | No          |      


Scenario Outline: [169594] Status/Logistics Viewer - Document - US Only, Label Product, PLP = Yes,  No Label/SDS added during submission
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the Home tab has loaded
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Given I call Shared Step 153152 (RPS/WV : Search for specific product) WPSId: 1625710
	Then I call Shared Step 149196 (Any Page - Actions: Open Document Link for PLP)
	Then I call Shared Step 146592 (Webviewer: Documents > No documents shown)

	Examples:
		| Scenario Name                                                                                                              | Retailer        | Page                    | IsWebviewer  |
#		| [#169594a]  Status/Logistics Viewer - Document - US Only, Label Product, PLP = Yes,  No Label/SDS added during submission  | RPS.TG          | Status Viewer           | Yes          |
#		| [#169594b]  Status/Logistics Viewer - Document - US Only, Label Product, PLP = Yes,  No Label/SDS added during submission  | RPS.TG          | HQ Store Viewer         | Yes          |
#		| [#169594c]  Status/Logistics Viewer - Document - US Only, Label Product, PLP = Yes,  No Label/SDS added during submission  | RPS.TG          | Store Viewer            | Yes          |
		| [#169594d]  Status/Logistics Viewer - Document - US Only, Label Product, PLP = Yes,  No Label/SDS added during submission  | RPS.SF          | SmartFinal_Store        | Yes          |
#		| [#169594e]  Status/Logistics Viewer - Document - US Only, Label Product, PLP = Yes,  No Label/SDS added during submission  | RPS.LW          | lowes_store             | Yes          |      


Scenario Outline: [169596] Status/Logistics Viewer - Document - US Only, Label Product, PLP = No,  No Label/SDS added during submission, SDS Summary Sheet
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the Home tab has loaded
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Given I call Shared Step 153152 (RPS/WV : Search for specific product) WPSId: 1625706
	Then I call Shared Step 149250 (Any Page - Actions: Open Document Link (not PLP))
	Then I call Shared Step 146592 (Webviewer: Documents > No documents shown)

	Examples:
		| Scenario Name                                                                                                                                | Retailer        | Page                    | IsWebviewer  |
#		| [#169596a]  Status/Logistics Viewer - Document - US Only, Label Product, PLP = No,  No Label/SDS added during submission, SDS Summary Sheet  | RPS.TG          | Status Viewer           | Yes          |
#		| [#169596b]  Status/Logistics Viewer - Document - US Only, Label Product, PLP = No,  No Label/SDS added during submission, SDS Summary Sheet  | RPS.TG          | HQ Store Viewer         | Yes          |
#		| [#169596c]  Status/Logistics Viewer - Document - US Only, Label Product, PLP = No,  No Label/SDS added during submission, SDS Summary Sheet  | RPS.TG          | Store Viewer            | Yes          |
		| [#169596d]  Status/Logistics Viewer - Document - US Only, Label Product, PLP = No,  No Label/SDS added during submission, SDS Summary Sheet  | RPS.SF          | SmartFinal_Store        | Yes          |
#		| [#169596e]  Status/Logistics Viewer - Document - US Only, Label Product, PLP = No,  No Label/SDS added during submission, SDS Summary Sheet  | RPS.LW          | lowes_store             | Yes          |      
	
	
Scenario Outline: [169593] Status/Logistics Viewer - Document - US Only, Label Product, PLP = Yes, Uploads SDS during Submission (no label)
    Given I call Shared Step 65080 (Login to Studio and Open SHA manager) 
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: 1625712)
	And I call Shared Step 49743 - SHA Manager - Select Product - Actions - Document Management for saved as: 1625712
	Then I call Shared Step 146422 (SHA Manager > Document Management > Primary 1, Source 0, document)
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the Home tab has loaded
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Given I call Shared Step 153152 (RPS/WV : Search for specific product) WPSId: 1625712
	Then I call Shared Step 149196 (Any Page - Actions: Open Document Link for PLP)
	Then I call Shared Step 149246 (Webviewer: Documents >US SDS compare to Uploaded SDS)

	Examples:
		| Scenario Name                                                                                                                 | Retailer        | Page                    | IsWebviewer  |
#		| [#169593a]  Status/Logistics Viewer - Document - US Only, Label Product, PLP = Yes, Uploads SDS during Submission (no label)  | RPS.TG          | Status Viewer           | Yes          |
#		| [#169593b]  Status/Logistics Viewer - Document - US Only, Label Product, PLP = Yes, Uploads SDS during Submission (no label)  | RPS.TG          | HQ Store Viewer         | Yes          |
#		| [#169593c]  Status/Logistics Viewer - Document - US Only, Label Product, PLP = Yes, Uploads SDS during Submission (no label)  | RPS.TG          | Store Viewer            | Yes          |
		| [#169593d]  Status/Logistics Viewer - Document - US Only, Label Product, PLP = Yes, Uploads SDS during Submission (no label)  | RPS.SF          | SmartFinal_Store        | Yes          |
#		| [#169593e]  Status/Logistics Viewer - Document - US Only, Label Product, PLP = Yes, Uploads SDS during Submission (no label)  | RPS.LW          | lowes_store             | Yes          |      


Scenario Outline: [169597] Status/Logistics Viewer - Document - US Only, Label Product, PLP = No, Uploaded SDS during submission (No Label)
    Given I call Shared Step 65080 (Login to Studio and Open SHA manager) 
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: 1625707)
	And I call Shared Step 49743 - SHA Manager - Select Product - Actions - Document Management for saved as: 1625707
	Then I call Shared Step 146422 (SHA Manager > Document Management > Primary 1, Source 0, document)
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the Home tab has loaded
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Given I call Shared Step 153152 (RPS/WV : Search for specific product) WPSId: 1625707
	Then I call Shared Step 149250 (Any Page - Actions: Open Document Link (not PLP))
	Then I call Shared Step 149246 (Webviewer: Documents >US SDS compare to Uploaded SDS)

	Examples:
		| Scenario Name                                                                                                                 | Retailer        | Page                    | IsWebviewer  |
#		| [#169597a]  Status/Logistics Viewer - Document - US Only, Label Product, PLP = No, Uploaded SDS during submission (No Label)  | RPS.TG          | Status Viewer           | Yes          |
#		| [#169597b]  Status/Logistics Viewer - Document - US Only, Label Product, PLP = No, Uploaded SDS during submission (No Label)  | RPS.TG          | HQ Store Viewer         | Yes          |
#		| [#169597c]  Status/Logistics Viewer - Document - US Only, Label Product, PLP = No, Uploaded SDS during submission (No Label)  | RPS.TG          | Store Viewer            | Yes          |
		| [#169597d]  Status/Logistics Viewer - Document - US Only, Label Product, PLP = No, Uploaded SDS during submission (No Label)  | RPS.SF          | SmartFinal_Store        | Yes          |
#		| [#169597e]  Status/Logistics Viewer - Document - US Only, Label Product, PLP = No, Uploaded SDS during submission (No Label)  | RPS.LW          | lowes_store             | Yes          |      


Scenario Outline: [169592] Status/Logistics Viewer - Document - US Only, Label Product, PLP = Yes, Label
    Given I call Shared Step 65080 (Login to Studio and Open SHA manager) 
	And I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: 1625709)
	Then I call Shared Step 146626 (WPS Studio - PD+ > Related Documents > Consumer Label > SHAMANAGER user)
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the Home tab has loaded
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Given I call Shared Step 153152 (RPS/WV : Search for specific product) WPSId: 1625709
	Then I call Shared Step 149196 (Any Page - Actions: Open Document Link for PLP)
	Then I call Shared Step 149121 (Webviewer: Documents  > Consumer Label compare with Studio related document)
	Then I close the document list pop up

	Examples:
		| Scenario Name                                                                              | Retailer        | Page                    | IsWebviewer  |
#		| [#169592a]  Status/Logistics Viewer - Document - US Only, Label Product, PLP = Yes, Label  | RPS.TG          | Status Viewer           | Yes          |
#		| [#169592b]  Status/Logistics Viewer - Document - US Only, Label Product, PLP = Yes, Label  | RPS.TG          | HQ Store Viewer         | Yes          |
#		| [#169592c]  Status/Logistics Viewer - Document - US Only, Label Product, PLP = Yes, Label  | RPS.TG          | Store Viewer            | Yes          |
		| [#169592d]  Status/Logistics Viewer - Document - US Only, Label Product, PLP = Yes, Label  | RPS.SF          | SmartFinal_Store        | Yes          |
#		| [#169592e]  Status/Logistics Viewer - Document - US Only, Label Product, PLP = Yes, Label  | RPS.LW          | lowes_store             | Yes          |      


Scenario Outline: [1695925] Status/Logistics Viewer - Document - US Only, Label Product, PLP = No, Label 
    Given I call Shared Step 65080 (Login to Studio and Open SHA manager) 
	And I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: 1625705)
	Then I call Shared Step 146626 (WPS Studio - PD+ > Related Documents > Consumer Label > SHAMANAGER user)
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the Home tab has loaded
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Given I call Shared Step 153152 (RPS/WV : Search for specific product) WPSId: 1625705
	Then I call Shared Step 149250 (Any Page - Actions: Open Document Link (not PLP))
	Then I call Shared Step 149121 (Webviewer: Documents  > Consumer Label compare with Studio related document)
	Then I close the document list pop up

	Examples:
		| Scenario Name                                                                             | Retailer        | Page                    | IsWebviewer  |
#		| [#169595a]  Status/Logistics Viewer - Document - US Only, Label Product, PLP = No, Label  | RPS.TG          | Status Viewer           | Yes          |
#		| [#169595b]  Status/Logistics Viewer - Document - US Only, Label Product, PLP = No, Label  | RPS.TG          | HQ Store Viewer         | Yes          |
#		| [#169595c]  Status/Logistics Viewer - Document - US Only, Label Product, PLP = No, Label  | RPS.TG          | Store Viewer            | Yes          |
		| [#169595d]  Status/Logistics Viewer - Document - US Only, Label Product, PLP = No, Label  | RPS.SF          | SmartFinal_Store        | Yes          |
#		| [#169595e]  Status/Logistics Viewer - Document - US Only, Label Product, PLP = No, Label  | RPS.LW          | lowes_store             | Yes          |      


Scenario Outline: [169598] Status/Logistics Viewer - Document - US Only, Battery, PLP = Yes, Authored SDS & UN38.3
    Given I call Shared Step 65080 (Login to Studio and Open SHA manager) 
	And I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: 1625687)
	Then I call Shared Step 146583 (WPS Studio - PD+ - Select Alias product for retailer) WPSID: 1625687 Retailer: <Retailer>
	Then I call Shared Step 146584 (WPS Studio - PD+ - Current Document > List of Published > Open NGHS - keep window open)
	Then I call Shared Step 148764 (WPS Studio - Report writer - find UN38.3 document name) for WPSID: 1625687
	Then I call Shared Step 148765 (WPS Studio - PD+ - related documents - Open UN38.3 document)
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the Home tab has loaded
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Given I call Shared Step 153152 (RPS/WV : Search for specific product) WPSId: 1625687
	Then I call Shared Step 149196 (Any Page - Actions: Open Document Link for PLP)
	Then I call Shared Step 149035 (Webviewer: Documents > SDS US compare to NGHS)
	Then I call Shared Step 149110 (Webviewer: Documents > Battery > UN38.3 compare to Studio related document)

	Examples:
		| Scenario Name                                                                                        | Retailer        | Page                    | IsWebviewer  |
#		| [#169598a]  Status/Logistics Viewer - Document - US Only, Battery, PLP = Yes, Authored SDS & UN38.3  | RPS.TG          | Status Viewer           | Yes          |
#		| [#169598b]  Status/Logistics Viewer - Document - US Only, Battery, PLP = Yes, Authored SDS & UN38.3  | RPS.TG          | HQ Store Viewer         | Yes          |
#		| [#169598c]  Status/Logistics Viewer - Document - US Only, Battery, PLP = Yes, Authored SDS & UN38.3  | RPS.TG          | Store Viewer            | Yes          |
		| [#169598d]  Status/Logistics Viewer - Document - US Only, Battery, PLP = Yes, Authored SDS & UN38.3  | RPS.SF          | SmartFinal_Store        | Yes          |
#		| [#169598e]  Status/Logistics Viewer - Document - US Only, Battery, PLP = Yes, Authored SDS & UN38.3  | RPS.LW          | lowes_store             | Yes          |      

Scenario Outline: [169599] Status/Logistics Viewer - Document - US Only, Battery, PLP = Yes, Uploads own SDS and UN38.3
    Given I call Shared Step 65080 (Login to Studio and Open SHA manager) 
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: 1625690)
	And I call Shared Step 49743 - SHA Manager - Select Product - Actions - Document Management for saved as: 1625690
	Then I call Shared Step 146422 (SHA Manager > Document Management > Primary 1, Source 0, document)
	Then I call Shared Step 148764 (WPS Studio - Report writer - find UN38.3 document name) for WPSID: 1625690
	Then I call Shared Step 148765 (WPS Studio - PD+ - related documents - Open UN38.3 document)
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the Home tab has loaded
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Given I call Shared Step 153152 (RPS/WV : Search for specific product) WPSId: 1625690
	Then I call Shared Step 149196 (Any Page - Actions: Open Document Link for PLP)
	Then I call Shared Step 149246 (Webviewer: Documents >US SDS compare to Uploaded SDS)
	Then I call Shared Step 149110 (Webviewer: Documents > Battery > UN38.3 compare to Studio related document)

	Examples:
		| Scenario Name                                                                                             | Retailer        | Page                    | IsWebviewer  |
#		| [#169599a]  Status/Logistics Viewer - Document - US Only, Battery, PLP = Yes, Uploads own SDS and UN38.3  | RPS.TG          | Status Viewer           | Yes          |
#		| [#169599b]  Status/Logistics Viewer - Document - US Only, Battery, PLP = Yes, Uploads own SDS and UN38.3  | RPS.TG          | HQ Store Viewer         | Yes          |
#		| [#169599c]  Status/Logistics Viewer - Document - US Only, Battery, PLP = Yes, Uploads own SDS and UN38.3  | RPS.TG          | Store Viewer            | Yes          |
		| [#169599d]  Status/Logistics Viewer - Document - US Only, Battery, PLP = Yes, Uploads own SDS and UN38.3  | RPS.SF          | SmartFinal_Store        | Yes          |
#		| [#169599e]  Status/Logistics Viewer - Document - US Only, Battery, PLP = Yes, Uploads own SDS and UN38.3  | RPS.LW          | lowes_store             | Yes          |      


Scenario Outline: [169600] Status/Logistics Viewer - Document - US Only, Battery, PLP = Yes, Uploads AIS document (not shown in WV) so only UN38.3 is shown
    Given I call Shared Step 65080 (Login to Studio and Open SHA manager) 
	And I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: 1625689)
	Then I call Shared Step 148764 (WPS Studio - Report writer - find UN38.3 document name) for WPSID: 1625689
	Then I call Shared Step 148765 (WPS Studio - PD+ - related documents - Open UN38.3 document)
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the Home tab has loaded
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Given I call Shared Step 153152 (RPS/WV : Search for specific product) WPSId: 1625689
	Then I call Shared Step 149196 (Any Page - Actions: Open Document Link for PLP)
	Then I call Shared Step 149110 (Webviewer: Documents > Battery > UN38.3 compare to Studio related document)

	Examples:
		| Scenario Name                                                                                                                                 | Retailer        | Page                    | IsWebviewer  |
#		| [#169600a]  Status/Logistics Viewer - Document - US Only, Battery, PLP = Yes, Uploads AIS document (not shown in WV) so only UN38.3 is shown  | RPS.TG          | Status Viewer           | Yes          |
#		| [#169600b]  Status/Logistics Viewer - Document - US Only, Battery, PLP = Yes, Uploads AIS document (not shown in WV) so only UN38.3 is shown  | RPS.TG          | HQ Store Viewer         | Yes          |
#		| [#169600c]  Status/Logistics Viewer - Document - US Only, Battery, PLP = Yes, Uploads AIS document (not shown in WV) so only UN38.3 is shown  | RPS.TG          | Store Viewer            | Yes          |
		| [#169600d]  Status/Logistics Viewer - Document - US Only, Battery, PLP = Yes, Uploads AIS document (not shown in WV) so only UN38.3 is shown  | RPS.SF          | SmartFinal_Store        | Yes          |
#		| [#169600e]  Status/Logistics Viewer - Document - US Only, Battery, PLP = Yes, Uploads AIS document (not shown in WV) so only UN38.3 is shown  | RPS.LW          | lowes_store             | Yes          |      

Scenario Outline: [169576] Status/Logistics Viewer - Document - US Only, PLP = Yes, Authored SDS
    Given I call Shared Step 65080 (Login to Studio and Open SHA manager) 
	And I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: 1619176)
	Then I call Shared Step 146583 (WPS Studio - PD+ - Select Alias product for retailer) WPSID: 1619176 Retailer: <Retailer>
	Then I call Shared Step 146584 (WPS Studio - PD+ - Current Document > List of Published > Open NGHS - keep window open)
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the Home tab has loaded
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Given I call Shared Step 153152 (RPS/WV : Search for specific product) WPSId: 1619176
	Then I click on the Documents Link
	Then I call Shared Step 220316 (Webviewer: Documents - SDS US opens directly - compare to NGHS)

	Examples:
		| Scenario Name                                                                     | Retailer        | Page                    | IsWebviewer  |
#		| [#169576a] Status/Logistics Viewer - Document - US Only, PLP = Yes, Authored SDS  | RPS.TG          | Status Viewer           | Yes          |
#		| [#169576b] Status/Logistics Viewer - Document - US Only, PLP = Yes, Authored SDS  | RPS.TG          | HQ Store Viewer         | Yes          |
#		| [#169576c] Status/Logistics Viewer - Document - US Only, PLP = Yes, Authored SDS  | RPS.TG          | Store Viewer            | Yes          |
		| [#169576d] Status/Logistics Viewer - Document - US Only, PLP = Yes, Authored SDS  | RPS.SF          | SmartFinal_Store        | Yes          |
#		| [#169576e] Status/Logistics Viewer - Document - US Only, PLP = Yes, Authored SDS  | RPS.LW          | lowes_store             | Yes          |


 Scenario Outline: [169602] Status/Logistics Viewer - Document - US Only, Battery, PLP = No, Authored SDS & UN38.3
    Given I call Shared Step 65080 (Login to Studio and Open SHA manager) 
	And I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: 1625479)
	Then I call Shared Step 146584 (WPS Studio - PD+ - Current Document > List of Published > Open NGHS - keep window open)
	Then I call Shared Step 148764 (WPS Studio - Report writer - find UN38.3 document name) for WPSID: 1625479
	Then I call Shared Step 148765 (WPS Studio - PD+ - related documents - Open UN38.3 document)
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the Home tab has loaded
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Given I call Shared Step 153152 (RPS/WV : Search for specific product) WPSId: 1625479
	Then I call Shared Step 149250 (Any Page - Actions: Open Document Link (not PLP))
	Then I call Shared Step 149035 (Webviewer: Documents > SDS US compare to NGHS)
	Then I call Shared Step 149110 (Webviewer: Documents > Battery > UN38.3 compare to Studio related document)

	Examples:
		| Scenario Name                                                                                      | Retailer        | Page                    | IsWebviewer  |
#		| [#169602a] Status/Logistics Viewer - Document - US Only, Battery, PLP = No, Authored SDS & UN38.3  | RPS.TG          | Status Viewer           | Yes          |
#		| [#169602b] Status/Logistics Viewer - Document - US Only, Battery, PLP = No, Authored SDS & UN38.3  | RPS.TG          | HQ Store Viewer         | Yes          |
#		| [#169602c] Status/Logistics Viewer - Document - US Only, Battery, PLP = No, Authored SDS & UN38.3  | RPS.TG          | Store Viewer            | Yes          |
		| [#169602d] Status/Logistics Viewer - Document - US Only, Battery, PLP = No, Authored SDS & UN38.3  | RPS.SF          | SmartFinal_Store        | Yes          |
#		| [#169602e] Status/Logistics Viewer - Document - US Only, Battery, PLP = No, Authored SDS & UN38.3  | RPS.LW          | lowes_store             | Yes          |      

Scenario Outline: [169603] Status/Logistics Viewer - Document - US Only, Battery, PLP = No, Uploads own SDS and UN38.3 
    Given I call Shared Step 65080 (Login to Studio and Open SHA manager) 
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: 1625483)
	And I call Shared Step 49743 - SHA Manager - Select Product - Actions - Document Management for saved as: 1625483
	Then I call Shared Step 146422 (SHA Manager > Document Management > Primary 1, Source 0, document)
	And I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: 1625483)
	Then I call Shared Step 148764 (WPS Studio - Report writer - find UN38.3 document name) for WPSID: 1625483
	Then I call Shared Step 148765 (WPS Studio - PD+ - related documents - Open UN38.3 document)
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the Home tab has loaded
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Given I call Shared Step 153152 (RPS/WV : Search for specific product) WPSId: 1625483
	Then I call Shared Step 149250 (Any Page - Actions: Open Document Link (not PLP))
	Then I call Shared Step 149246 (Webviewer: Documents >US SDS compare to Uploaded SDS)
	Then I call Shared Step 149110 (Webviewer: Documents > Battery > UN38.3 compare to Studio related document)

	Examples:
		| Scenario Name                                                                                            | Retailer        | Page                    | IsWebviewer  |
#		| [#169603a] Status/Logistics Viewer - Document - US Only, Battery, PLP = No, Uploads own SDS and UN38.3   | RPS.TG          | Status Viewer           | Yes          |
#		| [#169603b] Status/Logistics Viewer - Document - US Only, Battery, PLP = No, Uploads own SDS and UN38.3   | RPS.TG          | HQ Store Viewer         | Yes          |
#		| [#169603c] Status/Logistics Viewer - Document - US Only, Battery, PLP = No, Uploads own SDS and UN38.3   | RPS.TG          | Store Viewer            | Yes          |
		| [#169603d] Status/Logistics Viewer - Document - US Only, Battery, PLP = No, Uploads own SDS and UN38.3   | RPS.SF          | SmartFinal_Store        | Yes          |
#		| [#169603e] Status/Logistics Viewer - Document - US Only, Battery, PLP = No, Uploads own SDS and UN38.3   | RPS.LW          | lowes_store             | Yes          |      


Scenario Outline: [169584] Status/Logistics Viewer - Document - US & Canada, Kit Product, PLP = Yes, Merged SDS
    Given I call Shared Step 65080 (Login to Studio and Open SHA manager) 
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: 1626670)
	And I call Shared Step 49743 - SHA Manager - Select Product - Actions - Document Management for saved as: 1626670
	Then I call Shared Step 146422 (SHA Manager > Document Management > Primary 1, Source 0, document)
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the Home tab has loaded
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Given I call Shared Step 153152 (RPS/WV : Search for specific product) WPSId: 1626670
	Then I click on the Documents Link
	Given I call Shared Step 148846 (Webviewer: Documents > Kit > Merged SDS > Keep pop up open)
	Then I confirm  in the Document List pop up, below the main product and the SDS document confirm you see the following two battery products: Test Case 146102 - PLP name for xx wehere xx is retailer name; Test Case 146206 - PLP name for xx wehere xx is retailer name: <Retailer>
	Then I confirm Test Case 146102 - PLP name shows the documents type: SDS
	Then I confirm Test Case 146206 - PLP name shows the documents type: SDS
	Then I close the document list pop up

	Examples:
		| Scenario Name                                                                                     | Retailer        | Page                    | IsWebviewer  |
#		| [#169584a]  Status/Logistics Viewer - Document - US & Canada, Kit Product, PLP = Yes, Merged SDS  | RPS.TG          | Status Viewer           | Yes          |
#		| [#169584b]  Status/Logistics Viewer - Document - US & Canada, Kit Product, PLP = Yes, Merged SDS  | RPS.TG          | HQ Store Viewer         | Yes          |
#		| [#169584c]  Status/Logistics Viewer - Document - US & Canada, Kit Product, PLP = Yes, Merged SDS  | RPS.TG          | Store Viewer            | Yes          |
		| [#169584d]  Status/Logistics Viewer - Document - US & Canada, Kit Product, PLP = Yes, Merged SDS  | RPS.SF          | SmartFinal_Store        | Yes          |
#		| [#169584e]  Status/Logistics Viewer - Document - US & Canada, Kit Product, PLP = Yes, Merged SDS  | RPS.LW          | lowes_store             | Yes          |      


Scenario Outline: [169604] Status/Logistics Viewer - Document - US Only, Battery, PLP = No, Uploads AIS document (not shown in WV) so only UN38.3 is shown
    Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	And I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: 1625482)
	Then I call Shared Step 148764 (WPS Studio - Report writer - find UN38.3 document name) for WPSID: 1625482
	Then I call Shared Step 148765 (WPS Studio - PD+ - related documents - Open UN38.3 document)
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the Home tab has loaded
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Given I call Shared Step 153152 (RPS/WV : Search for specific product) WPSId: 1625482
	Then I call Shared Step 149250 (Any Page - Actions: Open Document Link (not PLP))
	Then I call Shared Step 149110 (Webviewer: Documents > Battery > UN38.3 compare to Studio related document)

	Examples:
		| Scenario Name                                                                                                                                | Retailer        | Page                    | IsWebviewer  |
#		| [#169604a] Status/Logistics Viewer - Document - US Only, Battery, PLP = No, Uploads AIS document (not shown in WV) so only UN38.3 is shown   | RPS.TG          | Status Viewer           | Yes          |
#		| [#169604b] Status/Logistics Viewer - Document - US Only, Battery, PLP = No, Uploads AIS document (not shown in WV) so only UN38.3 is shown   | RPS.TG          | HQ Store Viewer         | Yes          |
#		| [#169604c] Status/Logistics Viewer - Document - US Only, Battery, PLP = No, Uploads AIS document (not shown in WV) so only UN38.3 is shown   | RPS.TG          | Store Viewer            | Yes          |
		| [#169604d] Status/Logistics Viewer - Document - US Only, Battery, PLP = No, Uploads AIS document (not shown in WV) so only UN38.3 is shown   | RPS.SF          | SmartFinal_Store        | Yes          |
#		| [#169604e] Status/Logistics Viewer - Document - US Only, Battery, PLP = No, Uploads AIS document (not shown in WV) so only UN38.3 is shown   | RPS.LW          | lowes_store             | Yes          |      

Scenario Outline: [169605] Status/Logistics Viewer - Document - US & Canada, Battery, PLP = Yes, Authored SDS & UN38.3
    Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	And I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: 1625687)
	Then I call Shared Step 146583 (WPS Studio - PD+ - Select Alias product for retailer) WPSID: 1625687 Retailer: <Retailer>
	Then I call Shared Step 146584 (WPS Studio - PD+ - Current Document > List of Published > Open NGHS - keep window open)
	Then I call Shared Step 148764 (WPS Studio - Report writer - find UN38.3 document name) for WPSID: 1625687
	Then I call Shared Step 148765 (WPS Studio - PD+ - related documents - Open UN38.3 document)
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the Home tab has loaded
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Given I call Shared Step 153152 (RPS/WV : Search for specific product) WPSId: 1625687
	Then I call Shared Step 149196 (Any Page - Actions: Open Document Link for PLP)
	Then I call Shared Step 149035 (Webviewer: Documents > SDS US compare to NGHS)
	Then I call Shared Step 149110 (Webviewer: Documents > Battery > UN38.3 compare to Studio related document)

	Examples:
		| Scenario Name                                                                                            | Retailer        | Page                    | IsWebviewer  |
#		| [#169605a] Status/Logistics Viewer - Document - US & Canada, Battery, PLP = Yes, Authored SDS & UN38.3   | RPS.TG          | Status Viewer           | Yes          |
#		| [#169605b] Status/Logistics Viewer - Document - US & Canada, Battery, PLP = Yes, Authored SDS & UN38.3   | RPS.TG          | HQ Store Viewer         | Yes          |
#		| [#169605c] Status/Logistics Viewer - Document - US & Canada, Battery, PLP = Yes, Authored SDS & UN38.3   | RPS.TG          | Store Viewer            | Yes          |
		| [#169605d] Status/Logistics Viewer - Document - US & Canada, Battery, PLP = Yes, Authored SDS & UN38.3   | RPS.SF          | SmartFinal_Store        | Yes          |
#		| [#169605e] Status/Logistics Viewer - Document - US & Canada, Battery, PLP = Yes, Authored SDS & UN38.3   | RPS.LW          | lowes_store             | Yes          |      


Scenario Outline: [169607] Status/Logistics Viewer - Document - US & Canada, Battery, PLP = Yes, User Uploads AIS document (not shown in WV) so only UN3
    Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	And I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: 1625689)
	Then I call Shared Step 148764 (WPS Studio - Report writer - find UN38.3 document name) for WPSID: 1625689
	Then I call Shared Step 148765 (WPS Studio - PD+ - related documents - Open UN38.3 document)
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the Home tab has loaded
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Given I call Shared Step 153152 (RPS/WV : Search for specific product) WPSId: 1625689
	Then I call Shared Step 149196 (Any Page - Actions: Open Document Link for PLP)
	Then I confirm that I do not see a document type label of SDS
	Then I call Shared Step 149110 (Webviewer: Documents > Battery > UN38.3 compare to Studio related document)

	Examples:
		| Scenario Name                                                                                                                              | Retailer        | Page                    | IsWebviewer  |
#		| [#169607a] Status/Logistics Viewer - Document - US & Canada, Battery, PLP = Yes, User Uploads AIS document (not shown in WV) so only UN3   | RPS.TG          | Status Viewer           | Yes          |
#		| [#169607b] Status/Logistics Viewer - Document - US & Canada, Battery, PLP = Yes, User Uploads AIS document (not shown in WV) so only UN3   | RPS.TG          | HQ Store Viewer         | Yes          |
#		| [#169607c] Status/Logistics Viewer - Document - US & Canada, Battery, PLP = Yes, User Uploads AIS document (not shown in WV) so only UN3   | RPS.TG          | Store Viewer            | Yes          |
		| [#169607d] Status/Logistics Viewer - Document - US & Canada, Battery, PLP = Yes, User Uploads AIS document (not shown in WV) so only UN3   | RPS.SF          | SmartFinal_Store        | Yes          |
#		| [#169607e] Status/Logistics Viewer - Document - US & Canada, Battery, PLP = Yes, User Uploads AIS document (not shown in WV) so only UN3   | RPS.LW          | lowes_store             | Yes          |      		
		
Scenario Outline: [169616] Status/Logistics Viewer - Document - US & Canada, Battery, PLP = No, GenDoc = 0,User Uploads AIS document (not shown in WV) so only UN38.3 is shown
    Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	And I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: 1625482)
	Then I call Shared Step 148764 (WPS Studio - Report writer - find UN38.3 document name) for WPSID: 1625482
	Then I call Shared Step 148765 (WPS Studio - PD+ - related documents - Open UN38.3 document)
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the Home tab has loaded
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Given I call Shared Step 153152 (RPS/WV : Search for specific product) WPSId: 1625482
	Then I call Shared Step 149250 (Any Page - Actions: Open Document Link (not PLP))
	Then I confirm that I do not see a document type label of SDS
	Then I call Shared Step 149110 (Webviewer: Documents > Battery > UN38.3 compare to Studio related document)

	Examples:
		| Scenario Name                                                                                                                                                    | Retailer        | Page                    | IsWebviewer  |
#		| [#169616a] Status/Logistics Viewer - Document - US & Canada, Battery, PLP = No, GenDoc = 0,User Uploads AIS document (not shown in WV) so only UN38.3 is shown   | RPS.TG          | Status Viewer           | Yes          |
#		| [#169616b] Status/Logistics Viewer - Document - US & Canada, Battery, PLP = No, GenDoc = 0,User Uploads AIS document (not shown in WV) so only UN38.3 is shown   | RPS.TG          | HQ Store Viewer         | Yes          |
#		| [#169616c] Status/Logistics Viewer - Document - US & Canada, Battery, PLP = No, GenDoc = 0,User Uploads AIS document (not shown in WV) so only UN38.3 is shown   | RPS.TG          | Store Viewer            | Yes          |
		| [#169616d] Status/Logistics Viewer - Document - US & Canada, Battery, PLP = No, GenDoc = 0,User Uploads AIS document (not shown in WV) so only UN38.3 is shown   | RPS.SF          | SmartFinal_Store        | Yes          |
#		| [#169616e] Status/Logistics Viewer - Document - US & Canada, Battery, PLP = No, GenDoc = 0,User Uploads AIS document (not shown in WV) so only UN38.3 is shown   | RPS.LW          | lowes_store             | Yes          |      


Scenario Outline: [169291] Document - US Only, Label Product, PLP = Yes, Label & SDS Summary Sheet
    Given I call Shared Step 65080 (Login to Studio and Open SHA manager) 
	And I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: 1625709)
	Then I call Shared Step 146626 (WPS Studio - PD+ > Related Documents > Consumer Label > SHAMANAGER user)
	Then I call Shared Step 146583 (WPS Studio - PD+ - Select Alias product for retailer) WPSID: 1625709 Retailer: <Retailer>
	Then I call Shared Step 146585 (WPS Studio - PD+ - Current Document > List of Published > Open Summary Sheet - keep window open)
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the Home tab has loaded
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Given I call Shared Step 153152 (RPS/WV : Search for specific product) WPSId: 1625709
    Then I call Shared Step 149196 (Any Page - Actions: Open Document Link for PLP)
	Then I call Shared Step 149121 (Webviewer: Documents  > Consumer Label compare with Studio related document)
	Then I call Shared Step 149071 (Webviewer: Documents > SDS Summary Sheet compare to SBCS)
	Then I close the document list pop up

	Examples:
		| Scenario Name                                                                        | Retailer        | Page                    | IsWebviewer |
#		| [#169291a]  Document - US Only, Label Product, PLP = Yes, Label & SDS Summary Sheet  | RPS.TG          | Product Lookup          | No          |
#		| [#169291b]  Document - US Only, Label Product, PLP = Yes, Label & SDS Summary Sheet  | RPS.TG          | Recent Activities       | No          |
		| [#169291c]  Document - US Only, Label Product, PLP = Yes, Label & SDS Summary Sheet  | RPS.SF          | Product Lookup          | No          |
		| [#169291d]  Document - US Only, Label Product, PLP = Yes, Label & SDS Summary Sheet  | RPS.SF          | Recent Activities       | No          |
#		| [#169291e]  Document - US Only, Label Product, PLP = Yes, Label & SDS Summary Sheet  | RPS.LW          | Product Lookup          | No          |      
#		| [#169291f]  Document - US Only, Label Product, PLP = Yes, Label & SDS Summary Sheet  | RPS.LW          | Recent Activities       | No          |
#		| [#169291g]  Document - US Only, Label Product, PLP = Yes, Label & SDS Summary Sheet  | RPS.CV          | Product Lookup          | No          |
#		| [#169291h]  Document - US Only, Label Product, PLP = Yes, Label & SDS Summary Sheet  | RPS.CV          | Recent Activities       | No          |      


Scenario Outline: [169292] Document - US Only, Label Product, PLP = Yes, Uploads SDS during Submission (no label) & Summary Sheet
    Given I call Shared Step 65080 (Login to Studio and Open SHA manager) 
    Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: 1625712)
	And I call Shared Step 49743 - SHA Manager - Select Product - Actions - Document Management for saved as: 1625712
	Then I call Shared Step 146422 (SHA Manager > Document Management > Primary 1, Source 0, document)
	And I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: 1625712)
	Then I call Shared Step 146583 (WPS Studio - PD+ - Select Alias product for retailer) WPSID: 1625712 Retailer: <Retailer>
	Then I call Shared Step 146585 (WPS Studio - PD+ - Current Document > List of Published > Open Summary Sheet - keep window open)
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the Home tab has loaded
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Given I call Shared Step 153152 (RPS/WV : Search for specific product) WPSId: 1625712
    Then I call Shared Step 149196 (Any Page - Actions: Open Document Link for PLP)
	Then I call Shared Step 149246 (Webviewer: Documents >US SDS compare to Uploaded SDS)
	Then I call Shared Step 149071 (Webviewer: Documents > SDS Summary Sheet compare to SBCS)
	Then I close the document list pop up

	Examples:
		| Scenario Name                                                                                                       | Retailer        | Page                    | IsWebviewer |
#		| [#169292a]  Document - US Only, Label Product, PLP = Yes, Uploads SDS during Submission (no label) & Summary Sheet  | RPS.TG          | Product Lookup          | No          |
#		| [#169292b]  Document - US Only, Label Product, PLP = Yes, Uploads SDS during Submission (no label) & Summary Sheet  | RPS.TG          | Recent Activities       | No          |
		| [#169292c]  Document - US Only, Label Product, PLP = Yes, Uploads SDS during Submission (no label) & Summary Sheet  | RPS.SF          | Product Lookup          | No          |
		| [#169292d]  Document - US Only, Label Product, PLP = Yes, Uploads SDS during Submission (no label) & Summary Sheet  | RPS.SF          | Recent Activities       | No          |
#		| [#169292e]  Document - US Only, Label Product, PLP = Yes, Uploads SDS during Submission (no label) & Summary Sheet  | RPS.LW          | Recent Activities       | No          |
#		| [#169292g]  Document - US Only, Label Product, PLP = Yes, Uploads SDS during Submission (no label) & Summary Sheet  | RPS.CV          | Product Lookup          | No          |
#		| [#169292h]  Document - US Only, Label Product, PLP = Yes, Uploads SDS during Submission (no label) & Summary Sheet  | RPS.CV          | Recent Activities       | No          |      

Scenario Outline: [169293] Document - US Only, Label Product, PLP = Yes,  No Label/SDS added during submission - SDS Summary Sheet
    Given I call Shared Step 65080 (Login to Studio and Open SHA manager) 
	And I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: 1625710)
	Then I call Shared Step 146583 (WPS Studio - PD+ - Select Alias product for retailer) WPSID: 1625710 Retailer: <Retailer>
	Then I call Shared Step 146585 (WPS Studio - PD+ - Current Document > List of Published > Open Summary Sheet - keep window open)
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the Home tab has loaded
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Given I call Shared Step 153152 (RPS/WV : Search for specific product) WPSId: 1625710
    Then I call Shared Step 149196 (Any Page - Actions: Open Document Link for PLP)
	Then I call Shared Step 149071 (Webviewer: Documents > SDS Summary Sheet compare to SBCS)
	Then I close the document list pop up

	Examples:
		| Scenario Name                                                                                                       | Retailer        | Page                    | IsWebviewer |
#		| [#169293a] Document - US Only, Label Product, PLP = Yes,  No Label/SDS added during submission - SDS Summary Sheet  | RPS.TG          | Product Lookup          | No          |
#		| [#169293b] Document - US Only, Label Product, PLP = Yes,  No Label/SDS added during submission - SDS Summary Sheet  | RPS.TG          | Recent Activities       | No          |
		| [#169293c] Document - US Only, Label Product, PLP = Yes,  No Label/SDS added during submission - SDS Summary Sheet  | RPS.SF          | Product Lookup          | No          |
		| [#169293d] Document - US Only, Label Product, PLP = Yes,  No Label/SDS added during submission - SDS Summary Sheet  | RPS.SF          | Recent Activities       | No          |
#		| [#169293e] Document - US Only, Label Product, PLP = Yes,  No Label/SDS added during submission - SDS Summary Sheet  | RPS.LW          | Recent Activities       | No          |
#		| [#169293g] Document - US Only, Label Product, PLP = Yes,  No Label/SDS added during submission - SDS Summary Sheet  | RPS.CV          | Product Lookup          | No          |
#		| [#169293h] Document - US Only, Label Product, PLP = Yes,  No Label/SDS added during submission - SDS Summary Sheet  | RPS.CV          | Recent Activities       | No          |

Scenario Outline: [169294] Document - US Only, Label Product, PLP = No, Label & SDS Summary Sheet
    Given I call Shared Step 65080 (Login to Studio and Open SHA manager) 
	And I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: 1625705)
	Then I call Shared Step 146626 (WPS Studio - PD+ > Related Documents > Consumer Label > SHAMANAGER user)
	Then I call Shared Step 146585 (WPS Studio - PD+ - Current Document > List of Published > Open Summary Sheet - keep window open)
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the Home tab has loaded
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Given I call Shared Step 153152 (RPS/WV : Search for specific product) WPSId: 1625705
    Then I call Shared Step 149250 (Any Page - Actions: Open Document Link (not PLP))
	Then I call Shared Step 149121 (Webviewer: Documents  > Consumer Label compare with Studio related document)
	Then I call Shared Step 149071 (Webviewer: Documents > SDS Summary Sheet compare to SBCS)
	Then I close the document list pop up

	Examples:
		| Scenario Name                                                                        | Retailer        | Page                    | IsWebviewer |
#		| [#169294a]  Document - US Only, Label Product, PLP = No, Label & SDS Summary Sheet  | RPS.TG          | Product Lookup          | No          |
#		| [#169294b]  Document - US Only, Label Product, PLP = No, Label & SDS Summary Sheet  | RPS.TG          | Recent Activities       | No          |
		| [#169294c]  Document - US Only, Label Product, PLP = No, Label & SDS Summary Sheet  | RPS.SF          | Product Lookup          | No          |
		| [#169294d]  Document - US Only, Label Product, PLP = No, Label & SDS Summary Sheet  | RPS.SF          | Recent Activities       | No          |
#		| [#169294e]  Document - US Only, Label Product, PLP = No, Label & SDS Summary Sheet  | RPS.LW          | Product Lookup          | No          |      
#		| [#169294f]  Document - US Only, Label Product, PLP = No, Label & SDS Summary Sheet  | RPS.LW          | Recent Activities       | No          |
#		| [#169294g]  Document - US Only, Label Product, PLP = No, Label & SDS Summary Sheet  | RPS.CV          | Product Lookup          | No          |
#		| [#169294h]  Document - US Only, Label Product, PLP = No, Label & SDS Summary Sheet  | RPS.CV          | Recent Activities       | No          |      


Scenario Outline: [169296] Document - US Only, Label Product, PLP = No, Uploaded SDS during submission (No Label), SDS Summary Sheet
    Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: 1625707)
	And I call Shared Step 49743 - SHA Manager - Select Product - Actions - Document Management for saved as: 1625707
	Then I call Shared Step 146422 (SHA Manager > Document Management > Primary 1, Source 0, document)
	And I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: 1625707)
	Then I call Shared Step 146585 (WPS Studio - PD+ - Current Document > List of Published > Open Summary Sheet - keep window open)
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the Home tab has loaded
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Given I call Shared Step 153152 (RPS/WV : Search for specific product) WPSId: 1625707
    Then I call Shared Step 149250 (Any Page - Actions: Open Document Link (not PLP))
	Then I call Shared Step 149246 (Webviewer: Documents >US SDS compare to Uploaded SDS)
	Then I call Shared Step 149071 (Webviewer: Documents > SDS Summary Sheet compare to SBCS)
	Then I close the document list pop up

	Examples:
		| Scenario Name                                                                                                          | Retailer        | Page                    | IsWebviewer |
#		| [#169296a]  Document - US Only, Label Product, PLP = No, Uploaded SDS during submission (No Label), SDS Summary Sheet  | RPS.TG          | Product Lookup          | No          |
#		| [#169296b]  Document - US Only, Label Product, PLP = No, Uploaded SDS during submission (No Label), SDS Summary Sheet  | RPS.TG          | Recent Activities       | No          |
		| [#169296c]  Document - US Only, Label Product, PLP = No, Uploaded SDS during submission (No Label), SDS Summary Sheet  | RPS.SF          | Product Lookup          | No          |
		| [#169296d]  Document - US Only, Label Product, PLP = No, Uploaded SDS during submission (No Label), SDS Summary Sheet  | RPS.SF          | Recent Activities       | No          |
#		| [#169296e]  Document - US Only, Label Product, PLP = No, Uploaded SDS during submission (No Label), SDS Summary Sheet  | RPS.LW          | Product Lookup          | No          |      
#		| [#169296f]  Document - US Only, Label Product, PLP = No, Uploaded SDS during submission (No Label), SDS Summary Sheet  | RPS.LW          | Recent Activities       | No          |
#		| [#169296g]  Document - US Only, Label Product, PLP = No, Uploaded SDS during submission (No Label), SDS Summary Sheet  | RPS.CV          | Product Lookup          | No          |
#		| [#169296h]  Document - US Only, Label Product, PLP = No, Uploaded SDS during submission (No Label), SDS Summary Sheet  | RPS.CV          | Recent Activities       | No          |      

Scenario Outline: [169295] Document - US Only, Label Product, PLP = Yes,  No Label/SDS added during submission - SDS Summary Sheet
    Given I call Shared Step 65080 (Login to Studio and Open SHA manager) 
	And I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: 1625706)
	Then I call Shared Step 146585 (WPS Studio - PD+ - Current Document > List of Published > Open Summary Sheet - keep window open)
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the Home tab has loaded
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Given I call Shared Step 153152 (RPS/WV : Search for specific product) WPSId: 1625706
    Then I call Shared Step 149250 (Any Page - Actions: Open Document Link (not PLP))
	Then I call Shared Step 149071 (Webviewer: Documents > SDS Summary Sheet compare to SBCS)
	Then I close the document list pop up

	Examples:
		| Scenario Name                                                                                                       | Retailer        | Page                    | IsWebviewer |
#		| [#169295a] Document - US Only, Label Product, PLP = Yes,  No Label/SDS added during submission - SDS Summary Sheet  | RPS.TG          | Product Lookup          | No          |
#		| [#169295b] Document - US Only, Label Product, PLP = Yes,  No Label/SDS added during submission - SDS Summary Sheet  | RPS.TG          | Recent Activities       | No          |
		| [#169295c] Document - US Only, Label Product, PLP = Yes,  No Label/SDS added during submission - SDS Summary Sheet  | RPS.SF          | Product Lookup          | No          |
		| [#169295d] Document - US Only, Label Product, PLP = Yes,  No Label/SDS added during submission - SDS Summary Sheet  | RPS.SF          | Recent Activities       | No          |
#		| [#169295e] Document - US Only, Label Product, PLP = Yes,  No Label/SDS added during submission - SDS Summary Sheet  | RPS.LW          | Recent Activities       | No          |
#		| [#169295g] Document - US Only, Label Product, PLP = Yes,  No Label/SDS added during submission - SDS Summary Sheet  | RPS.CV          | Product Lookup          | No          |
#		| [#169295h] Document - US Only, Label Product, PLP = Yes,  No Label/SDS added during submission - SDS Summary Sheet  | RPS.CV          | Recent Activities       | No          |      

Scenario Outline: [169272] Document - US Only, PLP = No, Authored SDS & Summary Sheet
    Given I call Shared Step 65080 (Login to Studio and Open SHA manager) 
	And I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: 1625268)
	Then I call Shared Step 146584 (WPS Studio - PD+ - Current Document > List of Published > Open NGHS - keep window open)
	Then I call Shared Step 146585 (WPS Studio - PD+ - Current Document > List of Published > Open Summary Sheet - keep window open)
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the Home tab has loaded
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Given I call Shared Step 153152 (RPS/WV : Search for specific product) WPSId: 1625268
	Then I call Shared Step 149250 (Any Page - Actions: Open Document Link (not PLP))
	Then I call Shared Step 149035 (Webviewer: Documents > SDS US compare to NGHS)
	Then I call Shared Step 149071 (Webviewer: Documents > SDS Summary Sheet compare to SBCS)
	Then I close the document list pop up

	Examples:
		| Scenario Name                                                           | Retailer        | Page                    | IsWebviewer |
#		| [#169272a]  Document - US Only, PLP = No, Authored SDS & Summary Sheet  | RPS.TG          | Product Lookup          | No          |
#		| [#169272b]  Document - US Only, PLP = No, Authored SDS & Summary Sheet  | RPS.TG          | Recent Activities       | No          |
		| [#169272c]  Document - US Only, PLP = No, Authored SDS & Summary Sheet  | RPS.SF          | Product Lookup          | No          |
		| [#169272d]  Document - US Only, PLP = No, Authored SDS & Summary Sheet  | RPS.SF          | Recent Activities       | No          |
#		| [#169272e]  Document - US Only, PLP = No, Authored SDS & Summary Sheet  | RPS.LW          | Product Lookup          | No          |      
#		| [#169272f]  Document - US Only, PLP = No, Authored SDS & Summary Sheet  | RPS.LW          | Recent Activities       | No          |
#		| [#169272g]  Document - US Only, PLP = No, Authored SDS & Summary Sheet  | RPS.CV          | Product Lookup          | No          |
#		| [#169272h]  Document - US Only, PLP = No, Authored SDS & Summary Sheet  | RPS.CV          | Recent Activities       | No          |      


Scenario Outline: [169271] Document - US Only, PLP = Yes, Authored SDS and Summary Sheet
    Given I call Shared Step 65080 (Login to Studio and Open SHA manager) 
	And I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: 1805465)
	Then I call Shared Step 146583 (WPS Studio - PD+ - Select Alias product for retailer) WPSID: 1805465 Retailer: <Retailer>
	Then I call Shared Step 146584 (WPS Studio - PD+ - Current Document > List of Published > Open NGHS - keep window open)
	Then I call Shared Step 146585 (WPS Studio - PD+ - Current Document > List of Published > Open Summary Sheet - keep window open)
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the Home tab has loaded
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Given I call Shared Step 153152 (RPS/WV : Search for specific product) WPSId: 1805465
	Then I call Shared Step 149196 (Any Page - Actions: Open Document Link for PLP)
	Then I call Shared Step 149035 (Webviewer: Documents > SDS US compare to NGHS)
	Then I call Shared Step 149071 (Webviewer: Documents > SDS Summary Sheet compare to SBCS)
	Then I close the document list pop up

	Examples:
		| Scenario Name                                                              | Retailer        | Page                    | IsWebviewer |
#		| [#169271a]  Document - US Only, PLP = Yes, Authored SDS and Summary Sheet  | RPS.TG          | Product Lookup          | No          |
#		| [#169271b]  Document - US Only, PLP = Yes, Authored SDS and Summary Sheet  | RPS.TG          | Recent Activities       | No          |
		| [#169271c]  Document - US Only, PLP = Yes, Authored SDS and Summary Sheet  | RPS.SF          | Product Lookup          | No          |
		| [#169271d]  Document - US Only, PLP = Yes, Authored SDS and Summary Sheet  | RPS.SF          | Recent Activities       | No          |
#		| [#169271e]  Document - US Only, PLP = Yes, Authored SDS and Summary Sheet  | RPS.LW          | Product Lookup          | No          |      
#		| [#169271f]  Document - US Only, PLP = Yes, Authored SDS and Summary Sheet  | RPS.LW          | Recent Activities       | No          |
#		| [#169271g]  Document - US Only, PLP = Yes, Authored SDS and Summary Sheet  | RPS.CV          | Product Lookup          | No          |
#		| [#169271h]  Document - US Only, PLP = Yes, Authored SDS and Summary Sheet  | RPS.CV          | Recent Activities       | No          |      


Scenario Outline: [169273] Document - US Only, PLP = Yes, Uploads own SDS on Submission & Summary Sheet
    Given I call Shared Step 65080 (Login to Studio and Open SHA manager) 
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: 1619826)
	And I call Shared Step 49743 - SHA Manager - Select Product - Actions - Document Management for saved as: 1619826
	Then I call Shared Step 146422 (SHA Manager > Document Management > Primary 1, Source 0, document)
	And I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: 1619826)
    Then I call Shared Step 146583 (WPS Studio - PD+ - Select Alias product for retailer) WPSID: 1619826 Retailer: <Retailer>
	Then I call Shared Step 146585 (WPS Studio - PD+ - Current Document > List of Published > Open Summary Sheet - keep window open)
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the Home tab has loaded
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Given I call Shared Step 153152 (RPS/WV : Search for specific product) WPSId: 1619826
	Then I call Shared Step 149196 (Any Page - Actions: Open Document Link for PLP)
	Then I call Shared Step 149246 (Webviewer: Documents >US SDS compare to Uploaded SDS)
	Then I call Shared Step 149071 (Webviewer: Documents > SDS Summary Sheet compare to SBCS)
	Then I close the document list pop up

	Examples:
		| Scenario Name                                                                             | Retailer        | Page                    | IsWebviewer |
#		| [#169273a]  Document - US Only, PLP = Yes, Uploads own SDS on Submission & Summary Sheet  | RPS.TG          | Product Lookup          | No          |
#		| [#169273b]  Document - US Only, PLP = Yes, Uploads own SDS on Submission & Summary Sheet  | RPS.TG          | Recent Activities       | No          |
		| [#169273c]  Document - US Only, PLP = Yes, Uploads own SDS on Submission & Summary Sheet  | RPS.SF          | Product Lookup          | No          |
		| [#169273d]  Document - US Only, PLP = Yes, Uploads own SDS on Submission & Summary Sheet  | RPS.SF          | Recent Activities       | No          |
#		| [#169273e]  Document - US Only, PLP = Yes, Uploads own SDS on Submission & Summary Sheet  | RPS.LW          | Product Lookup          | No          |      
#		| [#169273f]  Document - US Only, PLP = Yes, Uploads own SDS on Submission & Summary Sheet  | RPS.LW          | Recent Activities       | No          |
#		| [#169273g]  Document - US Only, PLP = Yes, Uploads own SDS on Submission & Summary Sheet  | RPS.CV          | Product Lookup          | No          |
#		| [#169273h]  Document - US Only, PLP = Yes, Uploads own SDS on Submission & Summary Sheet  | RPS.CV          | Recent Activities       | No          |      


Scenario Outline: [169274] Document - US Only, PLP = No, Uploads own SDS on Submission & Summary Sheet
    Given I call Shared Step 65080 (Login to Studio and Open SHA manager) 
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: 1625277)
	And I call Shared Step 49743 - SHA Manager - Select Product - Actions - Document Management for saved as: 1625277
	Then I call Shared Step 146422 (SHA Manager > Document Management > Primary 1, Source 0, document)
	And I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: 1625277)
	Then I call Shared Step 146585 (WPS Studio - PD+ - Current Document > List of Published > Open Summary Sheet - keep window open)
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the Home tab has loaded
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Given I call Shared Step 153152 (RPS/WV : Search for specific product) WPSId: 1625277
	Then I call Shared Step 149250 (Any Page - Actions: Open Document Link (not PLP))
	Then I call Shared Step 149246 (Webviewer: Documents >US SDS compare to Uploaded SDS)
	Then I call Shared Step 149071 (Webviewer: Documents > SDS Summary Sheet compare to SBCS)
	Then I close the document list pop up

	Examples:
		| Scenario Name                                                                            | Retailer        | Page                    | IsWebviewer |
#		| [#169274a]  Document - US Only, PLP = No, Uploads own SDS on Submission & Summary Sheet  | RPS.TG          | Product Lookup          | No          |
#		| [#169274b]  Document - US Only, PLP = No, Uploads own SDS on Submission & Summary Sheet  | RPS.TG          | Recent Activities       | No          |
		| [#169274c]  Document - US Only, PLP = No, Uploads own SDS on Submission & Summary Sheet  | RPS.SF          | Product Lookup          | No          |
		| [#169274d]  Document - US Only, PLP = No, Uploads own SDS on Submission & Summary Sheet  | RPS.SF          | Recent Activities       | No          |
#		| [#169274e]  Document - US Only, PLP = No, Uploads own SDS on Submission & Summary Sheet  | RPS.LW          | Product Lookup          | No          |      
#		| [#169274f]  Document - US Only, PLP = No, Uploads own SDS on Submission & Summary Sheet  | RPS.LW          | Recent Activities       | No          |
#		| [#169274g]  Document - US Only, PLP = No, Uploads own SDS on Submission & Summary Sheet  | RPS.CV          | Product Lookup          | No          |
#		| [#169274h]  Document - US Only, PLP = No, Uploads own SDS on Submission & Summary Sheet  | RPS.CV          | Recent Activities       | No          |      

Scenario Outline: [169276] Document - US & Canada, Kit Product, PLP = No, Merged SDS, Summary Sheet
    Given I call Shared Step 65080 (Login to Studio and Open SHA manager) 
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: 1626669)
	And I call Shared Step 49743 - SHA Manager - Select Product - Actions - Document Management for saved as: 1626669
	Then I call Shared Step 146422 (SHA Manager > Document Management > Primary 1, Source 0, document)
	Then I call Shared Step 146583 (WPS Studio - PD+ - Select Alias product for retailer) WPSID: 1626669 Retailer: <Retailer>
	Then I call Shared Step 146585 (WPS Studio - PD+ - Current Document > List of Published > Open Summary Sheet - keep window open)
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the Home tab has loaded
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Given I call Shared Step 153152 (RPS/WV : Search for specific product) WPSId: 1626669
	Then I call Shared Step 149250 (Any Page - Actions: Open Document Link (not PLP))
	Given I call Shared Step 148846 (Webviewer: Documents > Kit > Merged SDS > Keep pop up open)
	Then I confirm  in the Document List pop up, below the main product and the SDS document confirm you see the following three battery products: For WVs TC 1460009 - US & Canada , PLP No, GenDoc 1, GENDocCA 1, Doc Accepted Yes; For WVs TC 146064 - US & Canada , PLP No, GenDoc 1, GenDocCA 1 Doc Accepted No (User rejects published SDS and uploads his own); For WVs TC 146098 - US & Canada , PLP No, GenDoc 0, GenDocCA 0
	Then I confirm For WVs TC 146009 - US & Canada , PLP No, GenDoc 1, GENDocCA 1, Doc Accepted Yes product shows the documents type:
	| Document Types           |
	| SDS                      |
	| SDS, Canada GHS, French  |
	| SDS, Canada GHS, English |
	| SDS Summary Sheet        |

	Then I confirm For WVs TC 146064 - US & Canada , PLP No, GenDoc 1, GenDocCA 1 Doc Accepted No (User rejects published SDS and uploads his own) product shows the documents type:
	| Document Types           |
	| SDS                      |
	| SDS, Canada GHS, French  |
	| SDS, Canada GHS, English |
	| SDS Summary Sheet        |
	Then I confirm For WVs TC 146098 - US & Canada , PLP No, GenDoc 0, GenDocCA 0 product shows the documents type:
	| Document Types           |
	| SDS                      |
	| SDS, Canada GHS, French  |
	| SDS Summary Sheet        |
	Then I close the document list pop up

	Examples:
		| Scenario Name                                                                         | Retailer        | Page                    | IsWebviewer |
#		| [#169276a]  Document - US & Canada, Kit Product, PLP = No, Merged SDS, Summary Sheet  | RPS.TG          | Product Lookup          | No          |
#		| [#169276b]  Document - US & Canada, Kit Product, PLP = No, Merged SDS, Summary Sheet  | RPS.TG          | Recent Activities       | No          |
		| [#169276c]  Document - US & Canada, Kit Product, PLP = No, Merged SDS, Summary Sheet  | RPS.SF          | Product Lookup          | No          |
		| [#169276d]  Document - US & Canada, Kit Product, PLP = No, Merged SDS, Summary Sheet  | RPS.SF          | Recent Activities       | No          |
#		| [#169276e]  Document - US & Canada, Kit Product, PLP = No, Merged SDS, Summary Sheet  | RPS.LW          | Product Lookup          | No          |      
#		| [#169276f]  Document - US & Canada, Kit Product, PLP = No, Merged SDS, Summary Sheet  | RPS.LW          | Recent Activities       | No          |
#		| [#169276g]  Document - US & Canada, Kit Product, PLP = No, Merged SDS, Summary Sheet  | RPS.CV          | Product Lookup          | No          |
#		| [#169276h]  Document - US & Canada, Kit Product, PLP = No, Merged SDS, Summary Sheet  | RPS.CV          | Recent Activities       | No          |      

Scenario Outline: [169617] Status/Logistics Viewer - Document - US & Canada, BCP Product, PLP = Yes, Authored US SDS
    Given I call Shared Step 65080 (Login to Studio and Open SHA manager) 
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: 1626661)
	And I call Shared Step 49743 - SHA Manager - Select Product - Actions - Document Management for saved as: 1626661
	Then I call Shared Step 148839 (SHA Manager - Open Merged SDS for BCP) with WPSID: 1626661 
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the Home tab has loaded
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Given I call Shared Step 153152 (RPS/WV : Search for specific product) WPSId: 1626661
	Then I call Shared Step 149196 (Any Page - Actions: Open Document Link for PLP)
	Then I call Shared Step 148960 (Webviewer: Documents > Compare SDS with Merged SDS in SHA manager for BCP)
	Then I confirm  In the Document List pop up, below the main product and the SDS document confirm you see the following three battery products:
	| Document List                                                                                     |
	| Test Battery - TC 145489 - Lithium Ion Battery, PLP, with Authored SDS, PLP name                  |
	| Test Battery - TC 145494 - Lithium Ion Battery, PLP, with Uploaded SDS, PLP name                  |
	| Test Battery - TC 145493 - Lithium Ion Battery PLP with Uploaded AIS PLP name                     |

	Then I confirm For Test Battery - TC 145494 - Lithium Ion Battery, PLP, with Uploaded SDS, PLP name shows the two documents types: 
	| Document Types           |
	| SDS                      |
	| UN38.3 Test Document     |
	Then I confirm For Test Battery - TC 145489 - Lithium Ion Battery, PLP, with Authored SDS, PLP name shows the two documents types :
	| Document Types           |
	| SDS                      |
	| UN38.3 Test Document     |
	Then I confirm For Test Battery - TC 145493 - Lithium Ion Battery, PLP, with Uploaded AIS, PLP name shows one document types:
	| Document Types           |
	| UN38.3 Test Document     |
	Then I close the document list pop up

	Examples:
		| Scenario Name                                                                                          | Retailer        | Page                    | IsWebviewer  |
#		| [#169617a] Status/Logistics Viewer - Document - US & Canada, BCP Product, PLP = Yes, Authored US SDS   | RPS.TG          | Status Viewer           | Yes          |
#		| [#169617b] Status/Logistics Viewer - Document - US & Canada, BCP Product, PLP = Yes, Authored US SDS   | RPS.TG          | HQ Store Viewer         | Yes          |
#		| [#169617c] Status/Logistics Viewer - Document - US & Canada, BCP Product, PLP = Yes, Authored US SDS   | RPS.TG          | Store Viewer            | Yes          |
		| [#169617d] Status/Logistics Viewer - Document - US & Canada, BCP Product, PLP = Yes, Authored US SDS   | RPS.SF          | SmartFinal_Store        | Yes          |
#		| [#169617e] Status/Logistics Viewer - Document - US & Canada, BCP Product, PLP = Yes, Authored US SDS   | RPS.LW          | lowes_store             | Yes          |      

Scenario Outline: [169618] Status/Logistics Viewer - Document - US & Canada, BCP Product, PLP = Yes, Uploaded US SDS
    Given I call Shared Step 65080 (Login to Studio and Open SHA manager) 
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: 1626662)
	And I call Shared Step 49743 - SHA Manager - Select Product - Actions - Document Management for saved as: 1626662
	Then I call Shared Step 148839 (SHA Manager - Open Merged SDS for BCP) with WPSID: 1626662 
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the Home tab has loaded
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Given I call Shared Step 153152 (RPS/WV : Search for specific product) WPSId: 1626662
	Then I call Shared Step 149196 (Any Page - Actions: Open Document Link for PLP)
	Then I call Shared Step 148960 (Webviewer: Documents > Compare SDS with Merged SDS in SHA manager for BCP)
	Then I confirm  In the Document List pop up, below the main product and the SDS document confirm you see the following three battery products:
	| Document List                                                                                     |
	| Test Battery - TC 145489 - Lithium Ion Battery, PLP, with Authored SDS, PLP name                  |
	| Test Battery - TC 145494 - Lithium Ion Battery, PLP, with Uploaded SDS, PLP name                  |
	| Test Battery - TC 145493 - Lithium Ion Battery PLP with Uploaded AIS PLP name                     |

	Then I confirm For Test Battery - TC 145494 - Lithium Ion Battery, PLP, with Uploaded SDS, PLP name shows the two documents types: 
	| Document Types           |
	| SDS                      |
	| UN38.3 Test Document     |
	Then I confirm For Test Battery - TC 145489 - Lithium Ion Battery, PLP, with Authored SDS, PLP name shows the two documents types :
	| Document Types           |
	| SDS                      |
	| UN38.3 Test Document     |
	Then I confirm For Test Battery - TC 145493 - Lithium Ion Battery, PLP, with Uploaded AIS, PLP name shows one document types:
	| Document Types           |
	| UN38.3 Test Document     |
	Then I close the document list pop up

	Examples:
		| Scenario Name                                                                                          | Retailer        | Page                    | IsWebviewer  |
#		| [#169618a] Status/Logistics Viewer - Document - US & Canada, BCP Product, PLP = Yes, Uploaded US SDS   | RPS.TG          | Status Viewer           | Yes          |
#		| [#169618b] Status/Logistics Viewer - Document - US & Canada, BCP Product, PLP = Yes, Uploaded US SDS   | RPS.TG          | HQ Store Viewer         | Yes          |
#		| [#169618c] Status/Logistics Viewer - Document - US & Canada, BCP Product, PLP = Yes, Uploaded US SDS   | RPS.TG          | Store Viewer            | Yes          |
		| [#169618d] Status/Logistics Viewer - Document - US & Canada, BCP Product, PLP = Yes, Uploaded US SDS   | RPS.SF          | SmartFinal_Store        | Yes          |
#		| [#169618e] Status/Logistics Viewer - Document - US & Canada, BCP Product, PLP = Yes, Uploaded US SDS   | RPS.LW          | lowes_store             | Yes          |      


Scenario Outline: [169275] Document - US & Canada, Kit Product, PLP = Yes, Merged SDS, Summary Sheet
    Given I call Shared Step 65080 (Login to Studio and Open SHA manager) 
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: 1626670)
	And I call Shared Step 49743 - SHA Manager - Select Product - Actions - Document Management for saved as: 1626670
	Then I call Shared Step 146422 (SHA Manager > Document Management > Primary 1, Source 0, document)
	And I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: 1626670)
	Then I call Shared Step 146583 (WPS Studio - PD+ - Select Alias product for retailer) WPSID: 1626670 Retailer: <Retailer>
	Then I call Shared Step 146585 (WPS Studio - PD+ - Current Document > List of Published > Open Summary Sheet - keep window open)
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the Home tab has loaded
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Given I call Shared Step 153152 (RPS/WV : Search for specific product) WPSId: 1626670
	Then I call Shared Step 149196 (Any Page - Actions: Open Document Link for PLP)
	Given I call Shared Step 148846 (Webviewer: Documents > Kit > Merged SDS > Keep pop up open)
	Then I confirm  in the Document List pop up, below the main product and the SDS document confirm you see the following two battery products: Test Case 146102 - PLP name for xx wehere xx is retailer name; Test Case 146206 - PLP name for xx wehere xx is retailer name: <Retailer>
	Then I confirm Test Case 146102 - PLP name shows the documents types:
	| Document Types           |
	| SDS                      |
	| SDS, Canada GHS, French  |
	| SDS, Canada GHS, English |
	| SDS Summary Sheet        |
	Then I confirm Test Case 146206 - PLP name shows the documents types:
	| Document Types           |
	| SDS                      |
	| SDS, Canada GHS, French  |
	| SDS Summary Sheet        |
	Then I close the document list pop up

	Examples:
		| Scenario Name                                                                          | Retailer        | Page                    | IsWebviewer |
#		| [#169275a]  Document - US & Canada, Kit Product, PLP = Yes, Merged SDS, Summary Sheet  | RPS.TG          | Product Lookup          | No          |
#		| [#169275b]  Document - US & Canada, Kit Product, PLP = Yes, Merged SDS, Summary Sheet  | RPS.TG          | Recent Activities       | No          |
		| [#169275c]  Document - US & Canada, Kit Product, PLP = Yes, Merged SDS, Summary Sheet  | RPS.SF          | Product Lookup          | No          |
		| [#169275d]  Document - US & Canada, Kit Product, PLP = Yes, Merged SDS, Summary Sheet  | RPS.SF          | Recent Activities       | No          |
#		| [#169275e]  Document - US & Canada, Kit Product, PLP = Yes, Merged SDS, Summary Sheet  | RPS.LW          | Product Lookup          | No          |      
#		| [#169275f]  Document - US & Canada, Kit Product, PLP = Yes, Merged SDS, Summary Sheet  | RPS.LW          | Recent Activities       | No          |
#		| [#169275g]  Document - US & Canada, Kit Product, PLP = Yes, Merged SDS, Summary Sheet  | RPS.CV          | Product Lookup          | No          |
#		| [#169275h]  Document - US & Canada, Kit Product, PLP = Yes, Merged SDS, Summary Sheet  | RPS.CV          | Recent Activities       | No          |      



Scenario Outline: [169300] Document - US & Canada, PLP = Yes, GenDoc = 1, Published  Alias US SDS, Published SDS Summary and Published Alias WHMIS SDS (EN & CF)
    Given I call Shared Step 65080 (Login to Studio and Open SHA manager) 
	And I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: 1625484)
	Then I call Shared Step 146583 (WPS Studio - PD+ - Select Alias product for retailer) WPSID: 1625484 Retailer: <Retailer>
	Then I call Shared Step 146584 (WPS Studio - PD+ - Current Document > List of Published > Open NGHS - keep window open)
	Then I call Shared Step 150041 (WPS Studio - PD+ - Current Document > List of Published > Open HGHS in EN and CF keep windows open)
	Then I call Shared Step 146585 (WPS Studio - PD+ - Current Document > List of Published > Open Summary Sheet - keep window open)
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the Home tab has loaded
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Given I call Shared Step 153152 (RPS/WV : Search for specific product) WPSId: 1625484
	Then I call Shared Step 149196 (Any Page - Actions: Open Document Link for PLP)
	Then I call Shared Step 149035 (Webviewer: Documents > SDS US compare to NGHS)
	Then I call Shared Step 149205 (Webviewer: Documents > SDS, Canada GHS, English compare to HGHS)
	Then I call Shared Step 146328 (Webviewer: Documents > SDS, Canada GHS, French compare to HGHS in CF)
	Then I call Shared Step 149071 (Webviewer: Documents > SDS Summary Sheet compare to SBCS)


	Examples:
		| Scenario Name                                                                                                                                      | Retailer        | Page                    | IsWebviewer |
#		| [#169300a]  Document - US & Canada, PLP = Yes, GenDoc = 1, Published  Alias US SDS, Published SDS Summary and Published Alias WHMIS SDS (EN & CF)  | RPS.TG          | Product Lookup          | No          |
#		| [#169300b]  Document - US & Canada, PLP = Yes, GenDoc = 1, Published  Alias US SDS, Published SDS Summary and Published Alias WHMIS SDS (EN & CF)  | RPS.TG          | Recent Activities       | No          |
		| [#169300c]  Document - US & Canada, PLP = Yes, GenDoc = 1, Published  Alias US SDS, Published SDS Summary and Published Alias WHMIS SDS (EN & CF)  | RPS.SF          | Product Lookup          | No          |
		| [#169300d]  Document - US & Canada, PLP = Yes, GenDoc = 1, Published  Alias US SDS, Published SDS Summary and Published Alias WHMIS SDS (EN & CF)  | RPS.SF          | Recent Activities       | No          |
#		| [#169300e]  Document - US & Canada, PLP = Yes, GenDoc = 1, Published  Alias US SDS, Published SDS Summary and Published Alias WHMIS SDS (EN & CF)  | RPS.LW          | Product Lookup          | No          |      
#		| [#169300f]  Document - US & Canada, PLP = Yes, GenDoc = 1, Published  Alias US SDS, Published SDS Summary and Published Alias WHMIS SDS (EN & CF)  | RPS.LW          | Recent Activities       | No          |
#		| [#169300g]  Document - US & Canada, PLP = Yes, GenDoc = 1, Published  Alias US SDS, Published SDS Summary and Published Alias WHMIS SDS (EN & CF)  | RPS.CV          | Product Lookup          | No          |
#		| [#169300h]  Document - US & Canada, PLP = Yes, GenDoc = 1, Published  Alias US SDS, Published SDS Summary and Published Alias WHMIS SDS (EN & CF)  | RPS.CV          | Recent Activities       | No          |      
#		| [#169300i]  Document - US & Canada, PLP = Yes, GenDoc = 1, Published  Alias US SDS, Published SDS Summary and Published Alias WHMIS SDS (EN & CF)  | RPS.CT          | Product Lookup          | No          |
#		| [#169300j]  Document - US & Canada, PLP = Yes, GenDoc = 1, Published  Alias US SDS, Published SDS Summary and Published Alias WHMIS SDS (EN & CF)  | RPS.CT          | Recent Activities       | No          |      


Scenario Outline: [169301] Document - US & Canada, PLP = Yes, Uploaded US SDS and Published Alias WHMIS SDS in EN and CF, and SDS Summary Sheet
    Given I call Shared Step 65080 (Login to Studio and Open SHA manager) 
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: 1625486)
	And I call Shared Step 49743 - SHA Manager - Select Product - Actions - Document Management for saved as: 1625486
	Then I call Shared Step 146422 (SHA Manager > Document Management > Primary 1, Source 0, document)
	And I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: 1625486)
	Then I call Shared Step 146583 (WPS Studio - PD+ - Select Alias product for retailer) WPSID: 1625486 Retailer: <Retailer>
	Then I call Shared Step 150041 (WPS Studio - PD+ - Current Document > List of Published > Open HGHS in EN and CF keep windows open)
	Then I call Shared Step 146585 (WPS Studio - PD+ - Current Document > List of Published > Open Summary Sheet - keep window open)
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the Home tab has loaded
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Given I call Shared Step 153152 (RPS/WV : Search for specific product) WPSId: 1625486
	Then I call Shared Step 149196 (Any Page - Actions: Open Document Link for PLP)
	Then I call Shared Step 149246 (Webviewer: Documents >US SDS compare to Uploaded SDS)
	Then I call Shared Step 149205 (Webviewer: Documents > SDS, Canada GHS, English compare to HGHS)
	Then I call Shared Step 146328 (Webviewer: Documents > SDS, Canada GHS, French compare to HGHS in CF)
	Then I call Shared Step 149071 (Webviewer: Documents > SDS Summary Sheet compare to SBCS)


	Examples:
		| Scenario Name                                                                                                                     | Retailer        | Page                    | IsWebviewer |
#		| [#169301a]  Document - US & Canada, PLP = Yes, Uploaded US SDS and Published Alias WHMIS SDS in EN and CF, and SDS Summary Sheet  | RPS.TG          | Product Lookup          | No          |
#		| [#169301b]  Document - US & Canada, PLP = Yes, Uploaded US SDS and Published Alias WHMIS SDS in EN and CF, and SDS Summary Sheet  | RPS.TG          | Recent Activities       | No          |
		| [#169301c]  Document - US & Canada, PLP = Yes, Uploaded US SDS and Published Alias WHMIS SDS in EN and CF, and SDS Summary Sheet  | RPS.SF          | Product Lookup          | No          |
		| [#169301d]  Document - US & Canada, PLP = Yes, Uploaded US SDS and Published Alias WHMIS SDS in EN and CF, and SDS Summary Sheet  | RPS.SF          | Recent Activities       | No          |
#		| [#169301e]  Document - US & Canada, PLP = Yes, Uploaded US SDS and Published Alias WHMIS SDS in EN and CF, and SDS Summary Sheet  | RPS.LW          | Product Lookup          | No          |      
#		| [#169301f]  Document - US & Canada, PLP = Yes, Uploaded US SDS and Published Alias WHMIS SDS in EN and CF, and SDS Summary Sheet  | RPS.LW          | Recent Activities       | No          |
#		| [#169301g]  Document - US & Canada, PLP = Yes, Uploaded US SDS and Published Alias WHMIS SDS in EN and CF, and SDS Summary Sheet  | RPS.CV          | Product Lookup          | No          |
#		| [#169301h]  Document - US & Canada, PLP = Yes, Uploaded US SDS and Published Alias WHMIS SDS in EN and CF, and SDS Summary Sheet  | RPS.CV          | Recent Activities       | No          |      
#		| [#169301i]  Document - US & Canada, PLP = Yes, Uploaded US SDS and Published Alias WHMIS SDS in EN and CF, and SDS Summary Sheet  | RPS.CT          | Product Lookup          | No          |
#		| [#169301j]  Document - US & Canada, PLP = Yes, Uploaded US SDS and Published Alias WHMIS SDS in EN and CF, and SDS Summary Sheet  | RPS.CT          | Recent Activities       | No          |      


Scenario Outline: [169303] Document - US & Canada, PLP = No, Published US SDS & Published WHMIS SDS in CF and EN & Summary Sheet
    Given I call Shared Step 65080 (Login to Studio and Open SHA manager) 
	And I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: 1625327)
	Then I call Shared Step 146584 (WPS Studio - PD+ - Current Document > List of Published > Open NGHS - keep window open)
	Then I call Shared Step 150041 (WPS Studio - PD+ - Current Document > List of Published > Open HGHS in EN and CF keep windows open)
	Then I call Shared Step 146585 (WPS Studio - PD+ - Current Document > List of Published > Open Summary Sheet - keep window open)
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the Home tab has loaded
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Given I call Shared Step 153152 (RPS/WV : Search for specific product) WPSId: 1625327
	Then I call Shared Step 149196 (Any Page - Actions: Open Document Link for PLP)
	Then I call Shared Step 149035 (Webviewer: Documents > SDS US compare to NGHS)
	Then I call Shared Step 149205 (Webviewer: Documents > SDS, Canada GHS, English compare to HGHS)
	Then I call Shared Step 146328 (Webviewer: Documents > SDS, Canada GHS, French compare to HGHS in CF)
	Then I call Shared Step 149071 (Webviewer: Documents > SDS Summary Sheet compare to SBCS)


	Examples:
		| Scenario Name                                                                                                      | Retailer        | Page                    | IsWebviewer |
#		| [#169303a]  Document - US & Canada, PLP = No, Published US SDS & Published WHMIS SDS in CF and EN & Summary Sheet  | RPS.TG          | Product Lookup          | No          |
#		| [#169303b]  Document - US & Canada, PLP = No, Published US SDS & Published WHMIS SDS in CF and EN & Summary Sheet  | RPS.TG          | Recent Activities       | No          |
		| [#169303c]  Document - US & Canada, PLP = No, Published US SDS & Published WHMIS SDS in CF and EN & Summary Sheet  | RPS.SF          | Product Lookup          | No          |
		| [#169303d]  Document - US & Canada, PLP = No, Published US SDS & Published WHMIS SDS in CF and EN & Summary Sheet  | RPS.SF          | Recent Activities       | No          |
#		| [#169303e]  Document - US & Canada, PLP = No, Published US SDS & Published WHMIS SDS in CF and EN & Summary Sheet  | RPS.LW          | Product Lookup          | No          |      
#		| [#169303f]  Document - US & Canada, PLP = No, Published US SDS & Published WHMIS SDS in CF and EN & Summary Sheet  | RPS.LW          | Recent Activities       | No          |
#		| [#169303g]  Document - US & Canada, PLP = No, Published US SDS & Published WHMIS SDS in CF and EN & Summary Sheet  | RPS.CV          | Product Lookup          | No          |
#		| [#169303h]  Document - US & Canada, PLP = No, Published US SDS & Published WHMIS SDS in CF and EN & Summary Sheet  | RPS.CV          | Recent Activities       | No          |      
#		| [#169303i]  Document - US & Canada, PLP = No, Published US SDS & Published WHMIS SDS in CF and EN & Summary Sheet  | RPS.CT          | Product Lookup          | No          |
#		| [#169303j]  Document - US & Canada, PLP = No, Published US SDS & Published WHMIS SDS in CF and EN & Summary Sheet  | RPS.CT          | Recent Activities       | No          |      

Scenario Outline: [169302] Document - US & Canada, PLP = No, Published US SDS & Published WHMIS SDS in CF and EN & Summary Sheet
    Given I call Shared Step 65080 (Login to Studio and Open SHA manager) 
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: 1625489)
	And I call Shared Step 49743 - SHA Manager - Select Product - Actions - Document Management for saved as: 1625489
    Then I call Shared Step 146422 (SHA Manager > Document Management > Primary 1, Source 0, document) 
	And I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: 1625489)
	Then I call Shared Step 146583 (WPS Studio - PD+ - Select Alias product for retailer) WPSID: 1625489 Retailer: <Retailer>
	Then I call Shared Step 146585 (WPS Studio - PD+ - Current Document > List of Published > Open Summary Sheet - keep window open)
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the Home tab has loaded
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Given I call Shared Step 153152 (RPS/WV : Search for specific product) WPSId: 1625489
	Then I call Shared Step 149196 (Any Page - Actions: Open Document Link for PLP)
    Then I call Shared Step 149246 (Webviewer: Documents >US SDS compare to Uploaded SDS)
	Then I call Shared Step 149071 (Webviewer: Documents > SDS Summary Sheet compare to SBCS)



	Examples:
		| Scenario Name                                                                                                                       | Retailer        | Page                    | IsWebviewer |
#		| [#169302a]  Document - US & Canada, PLP = Yes, Uploaded US SDS is shown, Uploaded WHMIS SDS in CF  is shown, and SDS Summary Sheet  | RPS.TG          | Product Lookup          | No          |
#		| [#169302b]  Document - US & Canada, PLP = Yes, Uploaded US SDS is shown, Uploaded WHMIS SDS in CF  is shown, and SDS Summary Sheet  | RPS.TG          | Recent Activities       | No          |
#		| [#169302c]  Document - US & Canada, PLP = Yes, Uploaded US SDS is shown, Uploaded WHMIS SDS in CF  is shown, and SDS Summary Sheet  | RPS.SF          | Product Lookup          | No          |
		| [#169302d]  Document - US & Canada, PLP = Yes, Uploaded US SDS is shown, Uploaded WHMIS SDS in CF  is shown, and SDS Summary Sheet  | RPS.SF          | Recent Activities       | No          |
#		| [#169302e]  Document - US & Canada, PLP = Yes, Uploaded US SDS is shown, Uploaded WHMIS SDS in CF  is shown, and SDS Summary Sheet  | RPS.LW          | Product Lookup          | No          |      
#		| [#169302f]  Document - US & Canada, PLP = Yes, Uploaded US SDS is shown, Uploaded WHMIS SDS in CF  is shown, and SDS Summary Sheet  | RPS.LW          | Recent Activities       | No          |
#		| [#169302g]  Document - US & Canada, PLP = Yes, Uploaded US SDS is shown, Uploaded WHMIS SDS in CF  is shown, and SDS Summary Sheet  | RPS.CV          | Product Lookup          | No          |
#		| [#169302h]  Document - US & Canada, PLP = Yes, Uploaded US SDS is shown, Uploaded WHMIS SDS in CF  is shown, and SDS Summary Sheet  | RPS.CV          | Recent Activities       | No          |      
#		| [#169302i]  Document - US & Canada, PLP = Yes, Uploaded US SDS is shown, Uploaded WHMIS SDS in CF  is shown, and SDS Summary Sheet  | RPS.CT          | Product Lookup          | No          |
#		| [#169302j]  Document - US & Canada, PLP = Yes, Uploaded US SDS is shown, Uploaded WHMIS SDS in CF  is shown, and SDS Summary Sheet  | RPS.CT          | Recent Activities       | No          |      


Scenario Outline: [169304] Document - US & Canada, PLP = No, Uploaded US SDS is shown and Uploaded WHMIS SDS is shown and Summary Sheet
    Given I call Shared Step 65080 (Login to Studio and Open SHA manager) 
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: 1625348)
	And I call Shared Step 49743 - SHA Manager - Select Product - Actions - Document Management for saved as: 1625348
    Then I call Shared Step 146422 (SHA Manager > Document Management > Primary 1, Source 0, document) 
	And I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: 1625348)
	Then I call Shared Step 146583 (WPS Studio - PD+ - Select Alias product for retailer) WPSID: 1625489 Retailer: <Retailer>
	Then I call Shared Step 146585 (WPS Studio - PD+ - Current Document > List of Published > Open Summary Sheet - keep window open)
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the Home tab has loaded
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Given I call Shared Step 153152 (RPS/WV : Search for specific product) WPSId: 1625348
	Then I call Shared Step 149196 (Any Page - Actions: Open Document Link for PLP)
    Then I call Shared Step 149246 (Webviewer: Documents >US SDS compare to Uploaded SDS)
	Then I call Shared Step 149071 (Webviewer: Documents > SDS Summary Sheet compare to SBCS)



	Examples:
		| Scenario Name                                                                                                             | Retailer        | Page                    | IsWebviewer |
#		| [#169304a]  Document - US & Canada, PLP = No, Uploaded US SDS is shown and Uploaded WHMIS SDS is shown and Summary Sheet  | RPS.TG          | Product Lookup          | No          |
#		| [#169304b]  Document - US & Canada, PLP = No, Uploaded US SDS is shown and Uploaded WHMIS SDS is shown and Summary Sheet  | RPS.TG          | Recent Activities       | No          |
#		| [#169304c]  Document - US & Canada, PLP = No, Uploaded US SDS is shown and Uploaded WHMIS SDS is shown and Summary Sheet  | RPS.SF          | Product Lookup          | No          |
		| [#169304d]  Document - US & Canada, PLP = No, Uploaded US SDS is shown and Uploaded WHMIS SDS is shown and Summary Sheet  | RPS.SF          | Recent Activities       | No          |
#		| [#169304e]  Document - US & Canada, PLP = No, Uploaded US SDS is shown and Uploaded WHMIS SDS is shown and Summary Sheet  | RPS.LW          | Product Lookup          | No          |      
#		| [#169304f]  Document - US & Canada, PLP = No, Uploaded US SDS is shown and Uploaded WHMIS SDS is shown and Summary Sheet  | RPS.LW          | Recent Activities       | No          |
#		| [#169304g]  Document - US & Canada, PLP = No, Uploaded US SDS is shown and Uploaded WHMIS SDS is shown and Summary Sheet  | RPS.CV          | Product Lookup          | No          |
#		| [#169304h]  Document - US & Canada, PLP = No, Uploaded US SDS is shown and Uploaded WHMIS SDS is shown and Summary Sheet  | RPS.CV          | Recent Activities       | No          |      
#		| [#169304i]  Document - US & Canada, PLP = No, Uploaded US SDS is shown and Uploaded WHMIS SDS is shown and Summary Sheet  | RPS.CT          | Product Lookup          | No          |
#		| [#169304j]  Document - US & Canada, PLP = No, Uploaded US SDS is shown and Uploaded WHMIS SDS is shown and Summary Sheet  | RPS.CT          | Recent Activities       | No          |      




