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

Feature: Page Options

Scenario Outline: [169120] Page options - (Last Page)
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	#Then I confirm the Home tab has loaded
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Then I call Shared Step 163792 (More Filters - Select any Less than 100,000 > Apply Filter) 
	Then I confirm the last page icon in the footer area
	Then In the Products table footer I click on the last page icon
    Then I confirm the page has loaded
    And In the Products table footer I check that the current page number is the same as the last page number


	Examples:
		| Scenario Name                           | Retailer        | Page                    | IsWebviewer |
#		| [#169120a]  Page options - (Last Page)  | RPS.TG          | Product Lookup          | No          |
#		| [#169120b]  Page options - (Last Page)  |RPS.TG           | Recent Activities       | No          |
		| [#169120c]  Page options - (Last Page)  | RPS.CV          | Product Lookup          | No          |
		| [#169120d]  Page options - (Last Page)  | RPS.CV          | Recent Activities       | No          |
		| [#169120e]  Page options - (Last Page)  | RPS.LW          | Product Lookup          | No          |
		| [#169120f]  Page options - (Last Page)  | RPS.LW          | Recent Activities       | No          |
		| [#169120g]  Page options - (Last Page)  | RPS.SF          |Product Lookup           | No          |
#		| [#169120h] Page options - (Last Page)   | RPS.SF          | Recent Activities       | No          |
#		| [#169120i]  Page options - (Last Page)  | RPS.LW          | Demo Viewer             | Yes         |
#		| [#169120j]  Page options - (Last Page)  |RPS.TG           | Store Viewer            | Yes         |
#		| [#169120k]  Page options - (Last Page)  | RPS.TG          | Status Viewer           | Yes         |
#		| [#169120l]  Page options - (Last Page)  | RPS.TG          | HQ Viewer               | Yes         |
		| [#169120m]  Page options - (Last Page)  | RPS.SF          | SmartFinal_Store        | Yes         |
#		| [#169120n]  Page options - (Last Page)  | RPS.LW          | Drum Log                | No          |
		| [#169120o]  Page options - (Last Page)  | RPS.CT          |Product Lookup           | No          |
		| [#169120p] Page options - (Last Page)   | RPS.CT          | Recent Activities       | No          |
#	    | [#169120q] Page options - (Last Page)   | RPS.CT          | Classification History  | No          |

Scenario Outline: [169121] Page options - (Previous Page) <
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	#Then I confirm the Home tab has loaded
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Then I click the next page icon in page footer
	Then I confirm the page has refreshed
	And I confirm page number is: 2
	Then I click the previous page icon in page footer
    Then I confirm the page has refreshed
    And I confirm page number is: 1


	Examples:
		| Scenario Name                                 | Retailer        | Page                    | IsWebviewer |
#		| [#169121a]  Page options - (Previous Page) <  | RPS.TG          | Product Lookup          | No          |
#		| [#169121b]  Page options - (Previous Page) <  |RPS.TG           | Recent Activities       | No          |
		| [#169121c]  Page options - (Previous Page) <  | RPS.CV          | Product Lookup          | No          |
		| [#169121d]  Page options - (Previous Page) <  | RPS.CV          | Recent Activities       | No          |
		| [#169121e]  Page options - (Previous Page) <  | RPS.LW          | Product Lookup          | No          |
		| [#169121f]  Page options - (Previous Page) <  | RPS.LW          | Recent Activities       | No          |
		| [#169121g]  Page options - (Previous Page) <  | RPS.SF          |Product Lookup           | No          |
		| [#169121h] Page options - (Previous Page) <   | RPS.SF          | Recent Activities       | No          |
#		| [#169121i]  Page options - (Previous Page) <  | RPS.LW          | Demo Viewer             | Yes         |
#		| [#169121j]  Page options - (Previous Page) <  |RPS.TG           | Store Viewer            | Yes         |
#		| [#169121k] Page options - (Previous Page) <   | RPS.TG          | Status Viewer           | Yes         |
#		| [#169121l]  Page options - (Previous Page) <  | RPS.TG          | HQ Viewer               | Yes         |
		| [#169121m]  Page options - (Previous Page) <  | RPS.SF          | SmartFinal_Store        | Yes         |
#		| [#169121n]  Page options - (Previous Page) <  | RPS.LW          | Drum Log                | No          |
		| [#169121o]  Page options - (Previous Page) <  | RPS.CT          |Product Lookup           | No          |
		| [#169121p] Page options - (Previous Page) <   | RPS.CT          | Recent Activities       | No          |
#	    | [#169121q] Page options - (Previous Page) <   | RPS.CT          | Classification History  | No          |

Scenario Outline: [169122] Page options - (First Page) |<
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	#Then I confirm the Home tab has loaded
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Then I call Shared Step 163792 (More Filters - Select any Less than 100,000 > Apply Filter) 
	Then I confirm the first page icon in the footer area
	Then In the Products table footer I click on the last page icon
	Then I confirm the page has refreshed
	And In the Products table footer I check that the current page number is the same as the last page number
    Then In the Products table footer I click on the first page icon
	Then I confirm the page has refreshed
	And I confirm page number is: 1
    

	Examples:
		| Scenario Name                                 | Retailer        | Page                    | IsWebviewer |
#		| [#169122a]  Page options - (First Page) \|<   | RPS.TG          | Product Lookup          | No          |
#		| [#169122b]  Page options - (First Page) \|<   |RPS.TG           | Recent Activities       | No          |
		| [#169122c]  Page options - (First Page) \|<   | RPS.CV          | Product Lookup          | No          |
		| [#169122d]  Page options - (First Page) \|<   | RPS.CV          | Recent Activities       | No          |
		| [#169122e]  Page options - (First Page) \|<   | RPS.LW          | Product Lookup          | No          |
		| [#169122f]  Page options - (First Page) \|<   | RPS.LW          | Recent Activities       | No          |
		| [#169122g]  Page options - (First Page) \|<   | RPS.SF          | Product Lookup          | No          |
#		| [#169122h] Page options - (First Page) \|<    | RPS.SF          | Recent Activities       | No          |
#		| [#169122i]  Page options - (First Page) \|<   | RPS.LW          | Demo Viewer             | Yes         |
#		| [#169122j]  Page options - (First Page) \|<   |RPS.TG           | Store Viewer            | Yes         |
#		| [#169122k] Page options - (First Page) \|<    | RPS.TG          | Status Viewer           | Yes         |
#		| [#169122l]  Page options - (First Page) \|<   | RPS.TG          | HQ Viewer               | Yes         |
#		| [#169122m]  Page options - (First Page) \|<   | RPS.SF          | SmartFinal_Store        | Yes         |
#		| [#169122n] Page options - (First Page) \|<    | RPS.LW          | Drum Log                | No          |
		| [#169122o]  Page options - (First Page) \|<   | RPS.CT          | Product Lookup          | No          |
		| [#169122p] Page options - (First Page) \|<    | RPS.CT          | Recent Activities       | No          |
#	    | [#169122q] Page options - (First Page) \|<    | RPS.CT          | Classification History  | No          |


Scenario Outline: [169123] Page options - (Next Page) >
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	#Then I confirm the Home tab has loaded
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded 
	Then  I click the next page icon in page footer
	Then I confirm the page has refreshed
	And I confirm page number is: 2
    

	Examples:
		| Scenario Name                              | Retailer        | Page                    | IsWebviewer |
#		| [#169123a]  Page options - (Next Page) >   | RPS.TG          | Product Lookup          | No          |
#		| [#169123b]  Page options - (Next Page) >   |RPS.TG           | Recent Activities       | No          |
		| [#169123c]  Page options - (Next Page) >   | RPS.CV          | Product Lookup          | No          |
		| [#169123d]  Page options - (Next Page) >   | RPS.CV          | Recent Activities       | No          |
		| [#169123e]  Page options - (Next Page) >   | RPS.LW          | Product Lookup          | No          |
		| [#169123f]  Page options - (Next Page) >   | RPS.LW          | Recent Activities       | No          |
		| [#169123g]  Page options - (Next Page) >   | RPS.SF          | Product Lookup          | No          |
		| [#169123h] Page options - (Next Page) >    | RPS.SF          | Recent Activities       | No          |
#		| [#169123i]  Page options - (Next Page) >   | RPS.LW          | Demo Viewer             | Yes         |
#		| [#169123j]  Page options - (Next Page) >   |RPS.TG           | Store Viewer            | Yes         |
#		| [#169123k] Page options - (Next Page) >    | RPS.TG          | Status Viewer           | Yes         |
#		| [#169123l]  Page options - (Next Page) >   | RPS.TG          | HQ Viewer               | Yes         |
		| [#169123m]  Page options - (Next Page) >   | RPS.SF          | SmartFinal_Store        | Yes         |
#		| [#169123n] Page options - (Next Page) >    | RPS.LW          | Drum Log                | No          |
		| [#169123o]  Page options - (Next Page) >   | RPS.CT          | Product Lookup          | No          |
		| [#169123p] Page options - (Next Page) >    | RPS.CT          | Recent Activities       | No          |
#	    | [#169123q] Page options - (Next Page) >    | RPS.CT          | Classification History  | No          |

Scenario Outline: [169124] Page options - change page number
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	#Then I confirm the Home tab has loaded
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded 
	Then In the page footer, I change the page number: 6
	Then I confirm the page has refreshed
	And I confirm page number is: 6
    

	Examples:
		| Scenario Name                                   | Retailer        | Page                    | IsWebviewer |
#		| [#169124a]  Page options - change page number   | RPS.TG          | Product Lookup          | No          |
#		| [#169124b]  Page options - change page number   |RPS.TG           | Recent Activities       | No          |
		| [#169124c]  Page options - change page number   | RPS.CV          | Product Lookup          | No          |
		| [#169124d]  Page options - change page number   | RPS.CV          | Recent Activities       | No          |
		| [#169124e]  Page options - change page number   | RPS.LW          | Product Lookup          | No          |
		| [#169124f]  Page options - change page number   | RPS.LW          | Recent Activities       | No          |
		| [#169124g]  Page options - change page number   | RPS.SF          | Product Lookup          | No          |
		| [#169124h]  Page options - change page number   | RPS.SF          | Recent Activities       | No          |
#		| [#169124i]  Page options - change page number   | RPS.LW          | Demo Viewer             | Yes         |
#		| [#169124j]  Page options - change page number   |RPS.TG           | Store Viewer            | Yes         |
#		| [#169124k]  Page options - change page number   | RPS.TG          | Status Viewer           | Yes         |
#		| [#169124l]  Page options - change page number   | RPS.TG          | HQ Viewer               | Yes         |
		| [#169124m]  Page options - change page number   | RPS.SF          | SmartFinal_Store        | Yes         |
#		| [#169124n]  Page options - change page number   | RPS.LW          | Drum Log                | No          |
		| [#169124o]  Page options - change page number   | RPS.CT          | Product Lookup          | No          |
		| [#169124p]  Page options - change page number   | RPS.CT          | Recent Activities       | No          |
#	    | [#169124q]  Page options - change page number   | RPS.CT          | Classification History  | No          |

Scenario Outline: [169125] Page options - changing page number returns correct results
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	#Then I confirm the Home tab has loaded
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded 
	Then In the page footer, I change the page number: 6
	Then I confirm the page has refreshed
	And In the recent activities Page, In the Products table footer I confirm the product count range reflects the page I am on
    

	Examples:
		| Scenario Name                                                             | Retailer        | Page                    | IsWebviewer |
#		| [#169125a]  Page options - changing page number returns correct results   | RPS.TG          | Product Lookup          | No          |
#		| [#169125b]  Page options - changing page number returns correct results   |RPS.TG           | Recent Activities       | No          |
		| [#169125c]  Page options - changing page number returns correct results   | RPS.CV          | Product Lookup          | No          |
		| [#169125d]  Page options - changing page number returns correct results   | RPS.CV          | Recent Activities       | No          |
		| [#169125e]  Page options - changing page number returns correct results   | RPS.LW          | Product Lookup          | No          |
		| [#169125f]  Page options - changing page number returns correct results   | RPS.LW          | Recent Activities       | No          |
		| [#169125g]  Page options - changing page number returns correct results   | RPS.SF          | Product Lookup          | No          |
		| [#169125h]  Page options - changing page number returns correct results   | RPS.SF          | Recent Activities       | No          |
#		| [#169125i]  Page options - changing page number returns correct results   | RPS.LW          | Demo Viewer             | Yes         |
#		| [#169125j]  Page options - changing page number returns correct results   |RPS.TG           | Store Viewer            | Yes         |
#		| [#169125k]  Page options - changing page number returns correct results   | RPS.TG          | Status Viewer           | Yes         |
#		| [#169125l]  Page options - changing page number returns correct results   | RPS.TG          | HQ Viewer               | Yes         |
		| [#169125m]  Page options - changing page number returns correct results   | RPS.SF          | SmartFinal_Store        | Yes         |
#		| [#169125n]  Page options - changing page number returns correct results   | RPS.LW          | Drum Log                | No          |
		| [#169125o]  Page options - changing page number returns correct results   | RPS.CT          | Product Lookup          | No          |
		| [#169125p]  Page options - changing page number returns correct results   | RPS.CT          | Recent Activities       | No          |
#	    | [#169125q]  Page options - changing page number returns correct results   | RPS.CT          | Classification History  | No          |


Scenario Outline: [169126] Page options - Change number of products per page
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	#Then I confirm the Home tab has loaded
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Then I confirm number of items per page selection box is shown
	Then In the page footer I click the number of items per page selection box
	Then In the Products table footer, the number of items per page shows the following options:
    | Option  |
    | 10      |
    | 20      |
    | 30      |
    Then In the Products table footer, select the items per page option: 20
	Then I confirm the page has refreshed
	And I confirm page number is: 1
	And In the Products table the total number of pages is correct

	Examples:
		| Scenario Name                                                   | Retailer        | Page                    | IsWebviewer |
#		| [#169126a]  Page options - Change number of products per page   | RPS.TG          | Product Lookup          | No          |
#		| [#169126b]  Page options - Change number of products per page   | RPS.TG           | Recent Activities       | No          |
		| [#169126c]  Page options - Change number of products per page   | RPS.CV          | Product Lookup          | No          |
		| [#169126d]  Page options - Change number of products per page   | RPS.CV          | Recent Activities       | No          |
		| [#169126e]  Page options - Change number of products per page   | RPS.LW          | Product Lookup          | No          |
		| [#169126f]  Page options - Change number of products per page   | RPS.LW          | Recent Activities       | No          |
		| [#169126g]  Page options - Change number of products per page   | RPS.SF          | Product Lookup          | No          |
		| [#169126h]  Page options - Change number of products per page   | RPS.SF          | Recent Activities       | No          |
#		| [#169126i]  Page options - Change number of products per page   | RPS.LW          | Demo Viewer             | Yes         |
#		| [#169126j]  Page options - Change number of products per page   |RPS.TG           | Store Viewer            | Yes         |
#		| [#169126k]  Page options - Change number of products per page   | RPS.TG          | Status Viewer           | Yes         |
#		| [#169126l]  Page options - Change number of products per page   | RPS.TG          | HQ Viewer               | Yes         |
		| [#169126m]  Page options - Change number of products per page   | RPS.SF          | SmartFinal_Store        | Yes         |
#		| [#169126n]  Page options - Change number of products per page   | RPS.LW          | Drum Log                | No          |
		| [#169126o]  Page options - Change number of products per page   | RPS.CT          | Product Lookup          | No          |
		| [#169126p]  Page options - Change number of products per page   | RPS.CT          | Recent Activities       | No          |
#	    | [#169126q]  Page options - Change number of products per page   | RPS.CT          | Classification History  | No          |

Scenario Outline: [169129] Base Functionality - Recent Activities - Page options - page number accepts 5 digits
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	#Then I confirm the Home tab has loaded
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Then In the Page footer area I confirm Rows per page selector displays: 10
	Then In the page footer, I change the page number: 10000
	Then I confirm the page has refreshed
	And I confirm page number is: 10000


	Examples:
		| Scenario Name                                                                                      | Retailer        | Page                    | IsWebviewer |
#		| [#169129a]  Base Functionality - Recent Activities - Page options - page number accepts 5 digits   | RPS.TG          | Product Lookup          | No          |
#		| [#169129b]  Base Functionality - Recent Activities - Page options - page number accepts 5 digits   | RPS.TG          | Recent Activities       | No          |
		| [#169129c]  Base Functionality - Recent Activities - Page options - page number accepts 5 digits   | RPS.CV          | Product Lookup          | No          |
		| [#169129d]  Base Functionality - Recent Activities - Page options - page number accepts 5 digits   | RPS.CV          | Recent Activities       | No          |
		| [#169129e]  Base Functionality - Recent Activities - Page options - page number accepts 5 digits   | RPS.LW          | Product Lookup          | No          |
		| [#169129f]  Base Functionality - Recent Activities - Page options - page number accepts 5 digits   | RPS.LW          | Recent Activities       | No          |
		| [#169129g]  Base Functionality - Recent Activities - Page options - page number accepts 5 digits   | RPS.SF          | Product Lookup          | No          |
		| [#169129h]  Base Functionality - Recent Activities - Page options - page number accepts 5 digits   | RPS.SF          | Recent Activities       | No          |
#		| [#169129i]  Base Functionality - Recent Activities - Page options - page number accepts 5 digits   | RPS.LW          | Demo Viewer             | Yes         |
#		| [#169129j]  Base Functionality - Recent Activities - Page options - page number accepts 5 digits   | RPS.TG          | Store Viewer            | Yes         |
#		| [#169129k]  Base Functionality - Recent Activities - Page options - page number accepts 5 digits   | RPS.TG          | Status Viewer           | Yes         |
#		| [#169129l]  Base Functionality - Recent Activities - Page options - page number accepts 5 digits   | RPS.TG          | HQ Viewer               | Yes         |
		| [#169129m]  Base Functionality - Recent Activities - Page options - page number accepts 5 digits   | RPS.SF          | SmartFinal_Store        | Yes         |
#		| [#169129n]  Base Functionality - Recent Activities - Page options - page number accepts 5 digits   | RPS.LW          | Drum Log                | No          |
		| [#169129o]  Base Functionality - Recent Activities - Page options - page number accepts 5 digits   | RPS.CT          | Product Lookup          | No          |
		| [#169129p]  Base Functionality - Recent Activities - Page options - page number accepts 5 digits   | RPS.CT          | Recent Activities       | No          |
#	    | [#169129q]  Base Functionality - Recent Activities - Page options - page number accepts 5 digits   | RPS.CT          | Classification History  | No          |


Scenario Outline: [169127] Page Options - Warning message when > 100,000 records present
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	#Then I confirm the Home tab has loaded
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Then I call Shared Step 154003 (RPS & WV - Warning message when > 100,000 records) 


	Examples:
		| Scenario Name                                                                                      | Retailer        | Page                    | IsWebviewer |
#		| [#169127a]  Page Options - Warning message when > 100,000 records present   | RPS.TG          | Product Lookup          | No          |
#		| [#169127b]  Page Options - Warning message when > 100,000 records present   | RPS.TG          | Recent Activities       | No          |
		| [#169127c]  Page Options - Warning message when > 100,000 records present   | RPS.CV          | Product Lookup          | No          |
		| [#169127d]  Page Options - Warning message when > 100,000 records present   | RPS.CV          | Recent Activities       | No          |
		| [#169127e]  Page Options - Warning message when > 100,000 records present   | RPS.LW          | Product Lookup          | No          |
		| [#169127f]  Page Options - Warning message when > 100,000 records present   | RPS.LW          | Recent Activities       | No          |
		| [#169127g]  Page Options - Warning message when > 100,000 records present   | RPS.SF          | Product Lookup          | No          |
		| [#169127h]  Page Options - Warning message when > 100,000 records present   | RPS.SF          | Recent Activities       | No          |
#		| [#169127i]  Page Options - Warning message when > 100,000 records present   | RPS.LW          | Demo Viewer             | Yes         |
#		| [#169127j]  Page Options - Warning message when > 100,000 records present   | RPS.TG          | Store Viewer            | Yes         |
#		| [#169127k]  Page Options - Warning message when > 100,000 records present   | RPS.TG          | Status Viewer           | Yes         |
#		| [#169127l]  Page Options - Warning message when > 100,000 records present   | RPS.TG          | HQ Viewer               | Yes         |
		| [#169127m]  Page Options - Warning message when > 100,000 records present   | RPS.SF          | SmartFinal_Store        | Yes         |
#		| [#169127n]  Page Options - Warning message when > 100,000 records present   | RPS.LW          | Drum Log                | No          |
		| [#169127o]  Page Options - Warning message when > 100,000 records present   | RPS.CT          | Product Lookup          | No          |
		| [#169127p]  Page Options - Warning message when > 100,000 records present   | RPS.CT          | Recent Activities       | No          |
#	    | [#169127q]  Page Options - Warning message when > 100,000 records present   | RPS.CT          | Classification History  | No          |


Scenario Outline: [169128] Page Options - Warning message when > 100,000 records present when filter applied
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	#Then I confirm the Home tab has loaded
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Then I call Shared Step 154005 (RPS & WV > Warning re 100,000 and More Filters applied) 


	Examples:
		| Scenario Name                                                                                      | Retailer        | Page                    | IsWebviewer |
#		| [#169128a]  Page Options - Warning message when > 100,000 records present when filter applied   | RPS.TG          | Product Lookup          | No          |
#		| [#169128b]  Page Options - Warning message when > 100,000 records present when filter applied   | RPS.TG          | Recent Activities       | No          |
		| [#169128c]  Page Options - Warning message when > 100,000 records present when filter applied   | RPS.CV          | Product Lookup          | No          |
		| [#169128d]  Page Options - Warning message when > 100,000 records present when filter applied   | RPS.CV          | Recent Activities       | No          |
		| [#169128e]  Page Options - Warning message when > 100,000 records present when filter applied   | RPS.LW          | Product Lookup          | No          |
		| [#169128f]  Page Options - Warning message when > 100,000 records present when filter applied   | RPS.LW          | Recent Activities       | No          |
		| [#169128g]  Page Options - Warning message when > 100,000 records present when filter applied   | RPS.SF          | Product Lookup          | No          |
		| [#169128h]  Page Options - Warning message when > 100,000 records present when filter applied   | RPS.SF          | Recent Activities       | No          |
#		| [#169128i]  Page Options - Warning message when > 100,000 records present when filter applied   | RPS.LW          | Demo Viewer             | Yes         |
#		| [#169128j]  Page Options - Warning message when > 100,000 records present when filter applied   | RPS.TG          | Store Viewer            | Yes         |
#		| [#169128k]  Page Options - Warning message when > 100,000 records present when filter applied   | RPS.TG          | Status Viewer           | Yes         |
#		| [#169128l]  Page Options - Warning message when > 100,000 records present when filter applied   | RPS.TG          | HQ Viewer               | Yes         |
		| [#169128m]  Page Options - Warning message when > 100,000 records present when filter applied   | RPS.SF          | SmartFinal_Store        | Yes         |
#		| [#169128n]  Page Options - Warning message when > 100,000 records present when filter applied   | RPS.LW          | Drum Log                | No          |
		| [#169128o]  Page Options - Warning message when > 100,000 records present when filter applied   | RPS.CT          | Product Lookup          | No          |
		| [#169128p]  Page Options - Warning message when > 100,000 records present when filter applied   | RPS.CT          | Recent Activities       | No          |
#	    | [#169128q]  Page Options - Warning message when > 100,000 records present when filter applied   | RPS.CT          | Classification History  | No          |




