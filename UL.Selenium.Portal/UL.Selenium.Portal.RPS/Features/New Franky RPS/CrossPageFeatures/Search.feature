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

Feature: Search

Scenario Outline: [169130] Search for Product ID
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the Home tab has loaded
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Then I Enter Product ID : 1625737 in Search field
	Then I confirm the page has refreshed
	Then I confirm the product I searched for is shown with the ID: 1625737




	Examples:
		| Scenario Name                      | Retailer        | Page                    | IsWebviewer |
#		| [#169130a]  Search for Product ID  | RPS.TG          | Product Lookup          | No          |
#		| [#169130b]  Search for Product ID  | RPS.TG          | Recent Activities       | No          |
		| [#169130c]  Search for Product ID  | RPS.CV          | Product Lookup          | No          |
		| [#169130d]  Search for Product ID  | RPS.CV          | Recent Activities       | No          |
		| [#169130e]  Search for Product ID  | RPS.LW          | Product Lookup          | No          |
		| [#169130f]  Search for Product ID  | RPS.LW          | Recent Activities       | No          |
		| [#169130g]  Search for Product ID  | RPS.SF          | Product Lookup          | No          |
		| [#169130h]  Search for Product ID  | RPS.SF          | Recent Activities       | No          |
#		| [#169130i]  Search for Product ID  | RPS.LW          | Demo Viewer             | Yes         |
#		| [#169130j]  Search for Product ID  | RPS.TG          | Store Viewer            | Yes         |
#		| [#169130k]  Search for Product ID  | RPS.TG          | Status Viewer           | Yes         |
#		| [#169130l]  Search for Product ID  | RPS.TG          | HQ Viewer               | Yes         |
#		| [#169130m]  Search for Product ID  | RPS.SF          | SmartFinal_Store        | Yes         |
#		| [#169130n]  Search for Product ID  | RPS.LW          | Drum Log                | No          |
		| [#169130o]  Search for Product ID  | RPS.CT          | Product Lookup          | No          |
		| [#169130p]  Search for Product ID  | RPS.CT          | Recent Activities       | No          |
#	    | [#169130q]  Search for Product ID  | RPS.CT          | Classification History  | No          |

Scenario Outline: [169131] Search for Product Name
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the Home tab has loaded
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Then I Enter Product Name : US & Canada, Label Only, Product PLP, Yes. in Search field
	Then I confirm the page has refreshed
	Then I confirm the product I searched for is shown:  US & Canada, Label Only Product PLP Yes




	Examples:
		| Scenario Name                        | Retailer        | Page                    | IsWebviewer |
#		| [#169131a]  Search for Product Name  | RPS.TG          | Product Lookup          | No          |
#		| [#169131b]  Search for Product Name  | RPS.TG          | Recent Activities       | No          |
		| [#169131c]  Search for Product Name  | RPS.CV          | Product Lookup          | No          |
		| [#169131d]  Search for Product Name  | RPS.CV          | Recent Activities       | No          |
		| [#169131e]  Search for Product Name  | RPS.LW          | Product Lookup          | No          |
		| [#169131f]  Search for Product Name  | RPS.LW          | Recent Activities       | No          |
		| [#169131g]  Search for Product Name  | RPS.SF          | Product Lookup          | No          |
		| [#169131h]  Search for Product Name  | RPS.SF          | Recent Activities       | No          |
#		| [#169131i]  Search for Product Name  | RPS.LW          | Demo Viewer             | Yes         |
#		| [#169131j]  Search for Product Name  | RPS.TG          | Store Viewer            | Yes         |
#		| [#169131k]  Search for Product Name  | RPS.TG          | Status Viewer           | Yes         |
#		| [#169131l]  Search for Product Name  | RPS.TG          | HQ Viewer               | Yes         |
#		| [#169131m]  Search for Product Name  | RPS.SF          | SmartFinal_Store        | Yes         |
#		| [#169131n]  Search for Product Name  | RPS.LW          | Drum Log                | No          |
		| [#169131o]  Search for Product Name  | RPS.CT          | Product Lookup          | No          |
		| [#169131p]  Search for Product Name  | RPS.CT          | Recent Activities       | No          |
#	    | [#169131q]  Search for Product Name  | RPS.CT          | Classification History  | No  

Scenario Outline: [169132] Search for UPC - full UPC
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the Home tab has loaded
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Given In the page footer, I change the page number: 3
	Then I confirm the page has loaded
	Then Select any UPC shown on the page and save as: savedAs 
	Then In the page footer, I change the page number: 1
	Then I confirm the page has loaded
	Then I Enter UPC Number : savedAs in Search field
	Then I confirm the page has refreshed
	Then I confirm the UPC I saved: savedAs is shown in Product Table

	Examples:
		| Scenario Name                          | Retailer        | Page                    | IsWebviewer |
#		| [#169132a]  Search for UPC - full UPC  | RPS.TG          | Product Lookup          | No          |
#		| [#169132b]  Search for UPC - full UPC  | RPS.TG          | Recent Activities       | No          |
		| [#169132c]  Search for UPC - full UPC  | RPS.CV          | Product Lookup          | No          |
		| [#169132d]  Search for UPC - full UPC  | RPS.CV          | Recent Activities       | No          |
		| [#169132e]  Search for UPC - full UPC  | RPS.LW          | Product Lookup          | No          |
		| [#169132f]  Search for UPC - full UPC  | RPS.LW          | Recent Activities       | No          |
		| [#169132g]  Search for UPC - full UPC  | RPS.SF          | Product Lookup          | No          |
		| [#169132h]  Search for UPC - full UPC  | RPS.SF          | Recent Activities       | No          |
#		| [#169132i]  Search for UPC - full UPC  | RPS.LW          | Demo Viewer             | Yes         |
#		| [#169132j]  Search for UPC - full UPC  | RPS.TG          | Store Viewer            | Yes         |
#		| [#169132k]  Search for UPC - full UPC  | RPS.TG          | Status Viewer           | Yes         |
#		| [#169132l]  Search for UPC - full UPC  | RPS.TG          | HQ Viewer               | Yes         |
#		| [#169132m]  Search for UPC - full UPC  | RPS.SF          | SmartFinal_Store        | Yes         |
#		| [#169132n]  Search for UPC - full UPC  | RPS.LW          | Drum Log                | No          |
		| [#169132o]  Search for UPC - full UPC  | RPS.CT          | Product Lookup          | No          |
		| [#169132p]  Search for UPC - full UPC  | RPS.CT          | Recent Activities       | No          |
#	    | [#169132q]  Search for UPC - full UPC  | RPS.CT          | Classification History  | No          |

Scenario Outline: [169133] Search for UPC - partial UPC
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the Home tab has loaded
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Then I call Shared Step 153272 (RPS & WV > Find UPC prefix > Search > Confirm) 

	Examples:
		| Scenario Name                             | Retailer        | Page                    | IsWebviewer |
#		| [#169133a]  Search for UPC - partial UPC  | RPS.TG          | Product Lookup          | No          |
#		| [#169133b]  Search for UPC - partial UPC  | RPS.TG          | Recent Activities       | No          |
		| [#169133c]  Search for UPC - partial UPC  | RPS.CV          | Product Lookup          | No          |
		| [#169133d]  Search for UPC - partial UPC  | RPS.CV          | Recent Activities       | No          |
		| [#169133e]  Search for UPC - partial UPC  | RPS.LW          | Product Lookup          | No          |
		| [#169133f]  Search for UPC - partial UPC  | RPS.LW          | Recent Activities       | No          |
		| [#169133g]  Search for UPC - partial UPC  | RPS.SF          | Product Lookup          | No          |
		| [#169133h]  Search for UPC - partial UPC  | RPS.SF          | Recent Activities       | No          |
#		| [#169133i]  Search for UPC - partial UPC  | RPS.LW          | Demo Viewer             | Yes         |
#		| [#169133j]  Search for UPC - partial UPC  | RPS.TG          | Store Viewer            | Yes         |
#		| [#169133k]  Search for UPC - partial UPC  | RPS.TG          | Status Viewer           | Yes         |
#		| [#169133l]  Search for UPC - partial UPC  | RPS.TG          | HQ Viewer               | Yes         |
#		| [#169133m]  Search for UPC - partial UPC  | RPS.SF          | SmartFinal_Store        | Yes         |
#		| [#169133n]  Search for UPC - partial UPC  | RPS.LW          | Drum Log                | No          |
		| [#169133o]  Search for UPC - partial UPC  | RPS.CT          | Product Lookup          | No          |
		| [#169133p]  Search for UPC - partial UPC  | RPS.CT          | Recent Activities       | No          |
#	    | [#169133q]  Search for UPC - partial UPC  | RPS.CT          | Classification History  | No          |

Scenario Outline: [169134] Search for UPC - ignores leading zeroes
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the Home tab has loaded
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Then I call Shared Step 153276 (RPS & WV > Search field > UPC ignores leading zeroes) 


	Examples:
		| Scenario Name                                        | Retailer        | Page                    | IsWebviewer |
#		| [#169134a]  Search for UPC - ignores leading zeroes  | RPS.TG          | Product Lookup          | No          |
#		| [#169134b]  Search for UPC - ignores leading zeroes  | RPS.TG          | Recent Activities       | No          |
		| [#169134c]  Search for UPC - ignores leading zeroes  | RPS.CV          | Product Lookup          | No          |
		| [#169134d]  Search for UPC - ignores leading zeroes  | RPS.CV          | Recent Activities       | No          |
		| [#169134e]  Search for UPC - ignores leading zeroes  | RPS.LW          | Product Lookup          | No          |
		| [#169134f]  Search for UPC - ignores leading zeroes  | RPS.LW          | Recent Activities       | No          |
		| [#169134g]  Search for UPC - ignores leading zeroes  | RPS.SF          | Product Lookup          | No          |
		| [#169134h]  Search for UPC - ignores leading zeroes  | RPS.SF          | Recent Activities       | No          |
#		| [#169134i]  Search for UPC - ignores leading zeroes  | RPS.LW          | Demo Viewer             | Yes         |
#		| [#169134j]  Search for UPC - ignores leading zeroes  | RPS.TG          | Store Viewer            | Yes         |
#		| [#169134k]  Search for UPC - ignores leading zeroes  | RPS.TG          | Status Viewer           | Yes         |
#		| [#169134l]  Search for UPC - ignores leading zeroes  | RPS.TG          | HQ Viewer               | Yes         |
#		| [#169134m]  Search for UPC - ignores leading zeroes  | RPS.SF          | SmartFinal_Store        | Yes         |
#		| [#169134n]  Search for UPC - ignores leading zeroes  | RPS.LW          | Drum Log                | No          |
		| [#169134o]  Search for UPC - ignores leading zeroes  | RPS.CT          | Product Lookup          | No          |
		| [#169134p]  Search for UPC - ignores leading zeroes  | RPS.CT          | Recent Activities       | No          |
#	    | [#169134q]  Search for UPC - ignores leading zeroes  | RPS.CT          | Classification History  | No          |

Scenario Outline: [169135] Search - Enter Key, or no action shows results
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the Home tab has loaded
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Then I call Shared Step 153277 (RPS & WV > Search field > Enter key or wait return results) 


	Examples:
		| Scenario Name                                               | Retailer        | Page                    | IsWebviewer |
#		| [#169135a]  Search - Enter Key, or no action shows results  | RPS.TG          | Product Lookup          | No          |
#		| [#169135b]  Search - Enter Key, or no action shows results  | RPS.TG          | Recent Activities       | No          |
		| [#169135c]  Search - Enter Key, or no action shows results  | RPS.CV          | Product Lookup          | No          |
		| [#169135d]  Search - Enter Key, or no action shows results  | RPS.CV          | Recent Activities       | No          |
		| [#169135e]  Search - Enter Key, or no action shows results  | RPS.LW          | Product Lookup          | No          |
		| [#169135f]  Search - Enter Key, or no action shows results  | RPS.LW          | Recent Activities       | No          |
		| [#169135g]  Search - Enter Key, or no action shows results  | RPS.SF          | Product Lookup          | No          |
		| [#169135h]  Search - Enter Key, or no action shows results  | RPS.SF          | Recent Activities       | No          |
#		| [#169135i]  Search - Enter Key, or no action shows results  | RPS.LW          | Demo Viewer             | Yes         |
#		| [#169135j]  Search - Enter Key, or no action shows results  | RPS.TG          | Store Viewer            | Yes         |
#		| [#169135k]  Search - Enter Key, or no action shows results  | RPS.TG          | Status Viewer           | Yes         |
#		| [#169135l]  Search - Enter Key, or no action shows results  | RPS.TG          | HQ Viewer               | Yes         |
#		| [#169135m]  Search - Enter Key, or no action shows results  | RPS.SF          | SmartFinal_Store        | Yes         |
#		| [#169135n]  Search - Enter Key, or no action shows results  | RPS.LW          | Drum Log                | No          |
		| [#169135o]  Search - Enter Key, or no action shows results  | RPS.CT          | Product Lookup          | No          |
		| [#169135p]  Search - Enter Key, or no action shows results  | RPS.CT          | Recent Activities       | No          |
#	    | [#169135q]  Search - Enter Key, or no action shows results  | RPS.CT          | Classification History  | No          |


Scenario Outline: [169138] Search text not cleared except by reset
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the Home tab has loaded
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Then I call Shared Step 153315 (RPS & WV > Search text only cleared on Reset) 


	Examples:
		| Scenario Name                                        | Retailer        | Page                    | IsWebviewer |
#		| [#169138a]  Search text not cleared except by reset  | RPS.TG          | Product Lookup          | No          |
#		| [#169138b]  Search text not cleared except by reset  | RPS.TG          | Recent Activities       | No          |
		| [#169138c]  Search text not cleared except by reset  | RPS.CV          | Product Lookup          | No          |
		| [#169138d]  Search text not cleared except by reset  | RPS.CV          | Recent Activities       | No          |
		| [#169138e]  Search text not cleared except by reset  | RPS.LW          | Product Lookup          | No          |
		| [#169138f]  Search text not cleared except by reset  | RPS.LW          | Recent Activities       | No          |
		| [#169138g]  Search text not cleared except by reset  | RPS.SF          | Product Lookup          | No          |
		| [#169138h]  Search text not cleared except by reset  | RPS.SF          | Recent Activities       | No          |
#		| [#169138i]  Search text not cleared except by reset  | RPS.LW          | Demo Viewer             | Yes         |
#		| [#169138j]  Search text not cleared except by reset  | RPS.TG          | Store Viewer            | Yes         |
#		| [#169138k]  Search text not cleared except by reset  | RPS.TG          | Status Viewer           | Yes         |
#		| [#169138l]  Search text not cleared except by reset  | RPS.TG          | HQ Viewer               | Yes         |
#		| [#169138m]  Search text not cleared except by reset  | RPS.SF          | SmartFinal_Store        | Yes         |
#		| [#169138n]  Search text not cleared except by reset  | RPS.LW          | Drum Log                | No          |
		| [#169138o]  Search text not cleared except by reset  | RPS.CT          | Product Lookup          | No          |
		| [#169138p]  Search text not cleared except by reset  | RPS.CT          | Recent Activities       | No          |
#	    | [#169138q]  Search text not cleared except by reset  | RPS.CT          | Classification History  | No          |


Scenario Outline: [169139] Search for Product Name - More Filters shows reduced products for selection
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the Home tab has loaded
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Then I call Shared Step 153316 (RPS & WV - Search text is taken into consideration by More Filters) 


	Examples:
		| Scenario Name                                                                            | Retailer        | Page                    | IsWebviewer |
#		| [#169139a]  Search for Product Name - More Filters shows reduced products for selection  | RPS.TG          | Product Lookup          | No          |
#		| [#169139b]  Search for Product Name - More Filters shows reduced products for selection  | RPS.TG          | Recent Activities       | No          |
		| [#169139c]  Search for Product Name - More Filters shows reduced products for selection  | RPS.CV          | Product Lookup          | No          |
		| [#169139d]  Search for Product Name - More Filters shows reduced products for selection  | RPS.CV          | Recent Activities       | No          |
		| [#169139e]  Search for Product Name - More Filters shows reduced products for selection  | RPS.LW          | Product Lookup          | No          |
		| [#169139f]  Search for Product Name - More Filters shows reduced products for selection  | RPS.LW          | Recent Activities       | No          |
		| [#169139g]  Search for Product Name - More Filters shows reduced products for selection  | RPS.SF          | Product Lookup          | No          |
		| [#169139h]  Search for Product Name - More Filters shows reduced products for selection  | RPS.SF          | Recent Activities       | No          |
#		| [#169139i]  Search for Product Name - More Filters shows reduced products for selection  | RPS.LW          | Demo Viewer             | Yes         |
#		| [#169139j]  Search for Product Name - More Filters shows reduced products for selection  | RPS.TG          | Store Viewer            | Yes         |
#		| [#169139k]  Search for Product Name - More Filters shows reduced products for selection  | RPS.TG          | Status Viewer           | Yes         |
#		| [#169139l]  Search for Product Name - More Filters shows reduced products for selection  | RPS.TG          | HQ Viewer               | Yes         |
#		| [#169139m]  Search for Product Name - More Filters shows reduced products for selection  | RPS.SF          | SmartFinal_Store        | Yes         |
#		| [#169139n]  Search for Product Name - More Filters shows reduced products for selection  | RPS.LW          | Drum Log                | No          |
		| [#169139o]  Search for Product Name - More Filters shows reduced products for selection  | RPS.CT          | Product Lookup          | No          |
		| [#169139p]  Search for Product Name - More Filters shows reduced products for selection  | RPS.CT          | Recent Activities       | No          |
#	    | [#169139q]  Search for Product Name - More Filters shows reduced products for selection  | RPS.CT          | Classification History  | No          |

Scenario Outline: [169140] Search - Apply Filter and apply main search in resulting grid
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the Home tab has loaded
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Then I call Shared Step 163970 (RPS & WV - Applied filter - Main search field apply search - results grid shows correct results) 


	Examples:
		| Scenario Name                                                              | Retailer        | Page                    | IsWebviewer |
#		| [#169140a]  Search - Apply Filter and apply main search in resulting grid  | RPS.TG          | Product Lookup          | No          |
#		| [#169140b]  Search - Apply Filter and apply main search in resulting grid  | RPS.TG          | Recent Activities       | No          |
		| [#169140c]  Search - Apply Filter and apply main search in resulting grid  | RPS.CV          | Product Lookup          | No          |
		| [#169140d]  Search - Apply Filter and apply main search in resulting grid  | RPS.CV          | Recent Activities       | No          |
		| [#169140e]  Search - Apply Filter and apply main search in resulting grid  | RPS.LW          | Product Lookup          | No          |
		| [#169140f]  Search - Apply Filter and apply main search in resulting grid  | RPS.LW          | Recent Activities       | No          |
		| [#169140g]  Search - Apply Filter and apply main search in resulting grid  | RPS.SF          | Product Lookup          | No          |
		| [#169140h]  Search - Apply Filter and apply main search in resulting grid  | RPS.SF          | Recent Activities       | No          |
#		| [#169140i]  Search - Apply Filter and apply main search in resulting grid  | RPS.LW          | Demo Viewer             | Yes         |
#		| [#169140j]  Search - Apply Filter and apply main search in resulting grid  | RPS.TG          | Store Viewer            | Yes         |
#		| [#169140k]  Search - Apply Filter and apply main search in resulting grid  | RPS.TG          | Status Viewer           | Yes         |
#		| [#169140l]  Search - Apply Filter and apply main search in resulting grid  | RPS.TG          | HQ Viewer               | Yes         |
#		| [#169140m]  Search - Apply Filter and apply main search in resulting grid  | RPS.SF          | SmartFinal_Store        | Yes         |
#		| [#169140n]  Search - Apply Filter and apply main search in resulting grid  | RPS.LW          | Drum Log                | No          |
		| [#169140o]  Search - Apply Filter and apply main search in resulting grid  | RPS.CT          | Product Lookup          | No          |
		| [#169140p]  Search - Apply Filter and apply main search in resulting grid  | RPS.CT          | Recent Activities       | No          |
#	    | [#169140q]  Search - Apply Filter and apply main search in resulting grid  | RPS.CT          | Classification History  | No          |


Scenario Outline: [169137] Search - Smart search is not available
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the Home tab has loaded
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Then I call Shared Step 153278 (RPS & WV > Search > No Smart Search shown)


	Examples:
		| Scenario Name                                       | Retailer        | Page                    | IsWebviewer |
#		| [#169137a]  Search - Smart search is not available  | RPS.TG          | Product Lookup          | No          |
#		| [#169137b]  Search - Smart search is not available  | RPS.TG          | Recent Activities       | No          |
		| [#169137c]  Search - Smart search is not available  | RPS.CV          | Product Lookup          | No          |
		| [#169137d]  Search - Smart search is not available  | RPS.CV          | Recent Activities       | No          |
		| [#169137e]  Search - Smart search is not available  | RPS.LW          | Product Lookup          | No          |
		| [#169137f]  Search - Smart search is not available  | RPS.LW          | Recent Activities       | No          |
		| [#169137g]  Search - Smart search is not available  | RPS.SF          | Product Lookup          | No          |
		| [#169137h]  Search - Smart search is not available  | RPS.SF          | Recent Activities       | No          |
#		| [#169137i]  Search - Smart search is not available  | RPS.LW          | Demo Viewer             | Yes         |
#		| [#169137j]  Search - Smart search is not available  | RPS.TG          | Store Viewer            | Yes         |
#		| [#169137k]  Search - Smart search is not available  | RPS.TG          | Status Viewer           | Yes         |
#		| [#169137l]  Search - Smart search is not available  | RPS.TG          | HQ Viewer               | Yes         |
#		| [#169137m]  Search - Smart search is not available  | RPS.SF          | SmartFinal_Store        | Yes         |
#		| [#169137n]  Search - Smart search is not available  | RPS.LW          | Drum Log                | No          |
		| [#169137o]  Search - Smart search is not available  | RPS.CT          | Product Lookup          | No          |
		| [#169137p]  Search - Smart search is not available  | RPS.CT          | Recent Activities       | No          |
#	    | [#169137q]  Search - Smart search is not available  | RPS.CT          | Classification History  | No          |


Scenario Outline: [169136] Search Numeric Data
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the Home tab has loaded
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm the page has loaded
	Then Select any UPC shown on the page and save as: savedAs 
	Then I Enter UPC Number : savedAs in Search field
	Then I confirm the page has refreshed
	Then I confirm the UPC I saved: savedAs is shown in Product Table
	Then In the product lookup Page, In the Products table I click the Reset Button
	Then Select any WPSID shown on the page and save as: savedAs 
	Then I Enter WPSID Number : savedAs in Search field
	Then I confirm the page has refreshed
	Then I confirm the WPSID I saved: savedAs is shown in Product Table
	Then In the product lookup Page, In the Products table I click the Reset Button
	


	Examples:
		| Scenario Name                    | Retailer        | Page                    | IsWebviewer |
#		| [#169136a]  Search Numeric Data  | RPS.TG          | Product Lookup          | No          |
#		| [#169136b]  Search Numeric Data  | RPS.TG          | Recent Activities       | No          |
		| [#169136c]  Search Numeric Data  | RPS.CV          | Product Lookup          | No          |
		| [#169136d]  Search Numeric Data  | RPS.CV          | Recent Activities       | No          |
		| [#169136e]  Search Numeric Data  | RPS.LW          | Product Lookup          | No          |
		| [#169136f]  Search Numeric Data  | RPS.LW          | Recent Activities       | No          |
		| [#169136g]  Search Numeric Data  | RPS.SF          | Product Lookup          | No          |
		| [#169136h]  Search Numeric Data  | RPS.SF          | Recent Activities       | No          |
#		| [#169136i]  Search Numeric Data  | RPS.LW          | Demo Viewer             | Yes         |
#		| [#169136j]  Search Numeric Data  | RPS.TG          | Store Viewer            | Yes         |
#		| [#169136k]  Search Numeric Data  | RPS.TG          | Status Viewer           | Yes         |
#		| [#169136l]  Search Numeric Data  | RPS.TG          | HQ Viewer               | Yes         |
#		| [#169136m]  Search Numeric Data  | RPS.SF          | SmartFinal_Store        | Yes         |
		| [#169136n]  Search Numeric Data  | RPS.CT          | Product Lookup          | No          |
		| [#169136o]  Search Numeric Data  | RPS.CT          | Recent Activities       | No          |


