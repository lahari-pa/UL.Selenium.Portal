@RPS
@Login
@run_ItemSync_Manual_Entry
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
@ItemSync
@Cards
@SuperTable
@MoreFilters
Feature: CardsUPCProductSupplier

Scenario Outline: [169630] Products Card - Any Page - Total Shown
	Given I log into the RPS Integrated site as Retailer: <Retailer>
	Then I confirm the active tab is: <LandingTab>
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm that the cards are in the following order:
		| CardName  |
		| UPCs      |
		| PRODUCTS  |
		| SUPPLIERS |
	Then I confirm that the PRODUCTS card contains a numeric value
	Then I confirm that the PRODUCTS card contains a graphic
	Then I confirm that the PRODUCTS card does not show a percentage value
	Then I confirm that the hover text for the PRODUCTS card is: Count of Completed Products.

Examples:
	| Scenario Name                                     | Retailer | Page              | IsWebviewer | LandingTab     |
	| [#169630a] Products Card - Any Page - Total Shown | TG       | Recent Activities | No          | Product Lookup |
	| [#169630b] Products Card - Any Page - Total Shown | TG       | Product Lookup    | No          | Product Lookup |
	| [#169630c] Products Card - Any Page - Total Shown | TG       | Target_status     | Yes         | Product Lookup |
	| [#169630d] Products Card - Any Page - Total Shown | TG       | Target_store      | Yes         | Product Lookup |
	| [#169630e] Products Card - Any Page - Total Shown | TG       | Target_HQ         | Yes         | Product Lookup |
	| [#169630f] Products Card - Any Page - Total Shown | LW       | Recent Activities | No          | LWLandingtab   |
	| [#169630g] Products Card - Any Page - Total Shown | LW       | Product Lookup    | No          | LWLandingtab   |
	| [#169630h] Products Card - Any Page - Total Shown | LW       | Lowes_store       | Yes         | LWLandingtab   |
	| [#169630i] Products Card - Any Page - Total Shown | CV       | Recent Activities | No          | Program Health |
	| [#169630j] Products Card - Any Page - Total Shown | CV       | Product Lookup    | No          | Program Health |

Scenario Outline: [169648] RPS - Any Page - User configured to show "ALL" products - No Trend Cards shown in page
	Given I log into the RPS Integrated site as Retailer: <Retailer>
	#Then I confirm the Home tab has loaded
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm that I do not see the three cards to the right of the Search field and buttons

Examples:
	| Scenario Name                                                                                     | Retailer | Page              | IsWebviewer |
	| [#169648a] RPS - Any Page - User configured to show "ALL" products - No Trend Cards shown in page | SF       | Recent Activities | No          |
	| [#169648b] RPS - Any Page - User configured to show "ALL" products - No Trend Cards shown in page | SF       | Product Lookup    | No          |
	| [#169648c] RPS - Any Page - User configured to show "ALL" products - No Trend Cards shown in page | SF       | SmartFinal_Store  | Yes         |

Scenario Outline: [169633] UPCs card - Any Page - Total & Percentage shown
	Given I log into the RPS Integrated site as Retailer: <Retailer>
	Then I confirm the active tab is: <LandingTab>
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm that I see card with label: UPCs
	Then I confirm that the UPCs card contains a numeric value
	Then I confirm that the UPCs card contains a graphic
	Then I confirm that the UPCs card shows a percentage value
	Then I confirm that the hover text for the UPCs card is: Count of Completed UPCs. Percentage measures Month over Month (MoM) growth

Examples:
	| Scenario Name                                              | Retailer | Page           | IsWebviewer | LandingTab     |
	| [#169633a] UPCs card - Any Page - Total & Percentage shown | TG       | Target_store   | Yes         | Product Lookup |
	| [#169633b] UPCs card - Any Page - Total & Percentage shown | TG       | Product Lookup | No          | Product Lookup |
	| [#169633c] UPCs card - Any Page - Total & Percentage shown | CV       | Product Lookup | No          | Program Health |
	| [#169633d] UPCs card - Any Page - Total & Percentage shown | LW       | Lowes_store    | Yes         | LWLandingtab   |
	| [#169633e] UPCs card - Any Page - Total & Percentage shown | LW       | Product Lookup | No          | LWLandingtab   |

#Removed from regression: 2023/06
@ignore
Scenario Outline: [169635] Suppliers card - Any Page - Total & Percentage shown
	Given I log into the RPS Integrated site as Retailer: <Retailer>
	Then I confirm the active tab is: <LandingTab>
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm that I see card with label: SUPPLIERS
	Then I confirm that the SUPPLIERS card contains a numeric value
	Then I confirm that the SUPPLIERS card contains a graphic
	Then I confirm that the SUPPLIERS card shows a percentage value
	Then I confirm that the hover text for the SUPPLIERS card is: Count of Suppliers in your Product Portfolio. Percentage measures Month over Month (MoM) growth

Examples:
	| Scenario Name                                                   | Retailer | Page           | IsWebviewer | LandingTab     |
	| [#169635a] Suppliers card - Any Page - Total & Percentage shown | TG       | Target_store   | Yes         | Product Lookup |
	| [#169635b] Suppliers card - Any Page - Total & Percentage shown | TG       | Product Lookup | No          | Product Lookup |
	| [#169635c] Suppliers card - Any Page - Total & Percentage shown | CV       | Product Lookup | No          | Program Health |
	| [#169635d] Suppliers card - Any Page - Total & Percentage shown | LW       | Lowes_store    | Yes         | LWLandingtab   |
	| [#169635e] Suppliers card - Any Page - Total & Percentage shown | LW       | Product Lookup | No          | LWLandingtab   |

Scenario Outline: [169637] UPCs card - Any Page - Total only shown
	Given I log into the RPS Integrated site as Retailer: <Retailer>
	Then I confirm the active tab is: <LandingTab>
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm that I see card with label: UPCs
	Then I confirm that the UPCs card contains a numeric value
	Then I confirm that the UPCs card contains a graphic
	Then I confirm that the UPCs card does not show a percentage value
	Then I confirm that the hover text for the UPCs card is: Count of Completed UPCs

Examples:
	| Scenario Name                                      | Retailer | Page              | IsWebviewer | LandingTab     |
	| [#169637a] UPCs card - Any Page - Total only shown | TG       | Recent Activities | No          | Product Lookup |
	| [#169637b] UPCs card - Any Page - Total only shown | TG       | Target_HQ         | Yes         | Product Lookup |
	| [#169637c] UPCs card - Any Page - Total only shown | TG       | Target_status     | Yes         | Product Lookup |
	| [#169637d] UPCs card - Any Page - Total only shown | CV       | Recent Activities | No          | Program Health |

Scenario Outline: [169639] Suppliers card - Any Page - Total only shown
	Given I log into the RPS Integrated site as Retailer: <Retailer>
	Then I confirm the active tab is: <LandingTab>
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm that I see card with label: SUPPLIERS
	Then I confirm that the SUPPLIERS card contains a numeric value
	Then I confirm that the SUPPLIERS card contains a graphic
	Then I confirm that the SUPPLIERS card does not show a percentage value
	Then I confirm that the hover text for the SUPPLIERS card is: Count of Suppliers in your Product Portfolio

Examples:
	| Scenario Name                                           | Retailer | Page              | IsWebviewer | LandingTab     |
	| [#169639a] Suppliers card - Any Page - Total only shown | TG       | Recent Activities | No          | Product Lookup |
	| [#169639b] Suppliers card - Any Page - Total only shown | TG       | Target_HQ         | Yes         | Product Lookup |
	| [#169639c] Suppliers card - Any Page - Total only shown | TG       | Target_status     | Yes         | Product Lookup |
	| [#169639d] Suppliers card - Any Page - Total only shown | CV       | Recent Activities | No          | Program Health |

Scenario Outline: [169112] Page is Loading - indicator shows
	Given I log into the RPS Integrated site as Retailer: <Retailer>
	Then I confirm the active tab is: <LandingTab>
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>

Examples:
	| Scenario Name                                | Retailer | Page              | IsWebviewer | LandingTab     |
	| [#169112a] Page is Loading - indicator shows | CV       | Recent Activities | No          | Program Health |
	| [#169112b] Page is Loading - indicator shows | CV       | Product Lookup    | No          | Program Health |
	| [#169112c] Page is Loading - indicator shows | LW       | Recent Activities | No          | LWLandingtab   |
	| [#169112d] Page is Loading - indicator shows | LW       | Product Lookup    | No          | LWLandingtab   |
	| [#169112e] Page is Loading - indicator shows | LW       | Lowes_store       | Yes         | LWLandingtab   |
	| [#169112f] Page is Loading - indicator shows | TG       | Recent Activities | No          | Product Lookup |
	| [#169112g] Page is Loading - indicator shows | TG       | Product Lookup    | No          | Product Lookup |
	| [#169112h] Page is Loading - indicator shows | TG       | Target_store      | Yes         | Product Lookup |
	| [#169112i] Page is Loading - indicator shows | TG       | Target_status     | Yes         | Product Lookup |
	| [#169112j] Page is Loading - indicator shows | TG       | Target_HQ         | Yes         | Product Lookup |
	| [#169112k] Page is Loading - indicator shows | SF       | Recent Activities | No          | Program Health |
	| [#169112l] Page is Loading - indicator shows | SF       | Product Lookup    | No          | Program Health |
	| [#169112m] Page is Loading - indicator shows | SF       | SmartFinal_Store  | Yes         | Program Health |
#		| [#169112n] Page is Loading - indicator shows | LW       | Drum Log               | No          |
#		| [#169112o] Page is Loading - indicator shows | CT       | Recent Activities      | No          |
#		| [#169112p] Page is Loading - indicator shows | CT       | Product Lookup         | No          |
#		| [#169112q] Page is Loading - indicator shows | CT       | Classification History | No          |

Scenario Outline: [169113] Check for showAllStatuses = true
	Given I log into the RPS Integrated site as Retailer: <Retailer>
	Then I confirm the active tab is: <LandingTab>
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I call Shared Step 148793 (RPS/WV any page - check for showAllStatuses : true)
	Then I call Shared Step 106194 (RPS Sign out)

Examples:
	| Scenario Name                               | Retailer | Page              | IsWebviewer | LandingTab     |
#		| [#169113a] Check for showAllStatuses = true | CV       | Recent Activities | No          | Program Health         |
	| [#169113b] Check for showAllStatuses = true | LW       | Recent Activities | No          | LWLandingtab   |
	| [#169113c] Check for showAllStatuses = true | TG       | Recent Activities | No          | Product Lookup |
#`		| [#169113d] Check for showAllStatuses = true | SF       | Recent Activities | No          | Program Health         |
	| [#169113e] Check for showAllStatuses = true | TG       | Target_status     | Yes         | Product Lookup |
	| [#169113f] Check for showAllStatuses = true | TG       | Target_HQ         | Yes         | Product Lookup |
#		| [#169113g] Check for showAllStatuses = true | CT       | Recent Activities | No          |

Scenario Outline: [169325] Check for showAllStatuses = false
	Given I log into the RPS Integrated site as Retailer: <Retailer>
	Then I confirm the active tab is: <LandingTab>
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I call Shared Step 148793 (RPS/WV any page - check for showAllStatuses : false)
	Then I call Shared Step 106194 (RPS Sign out)

Examples:
	| Scenario Name                                | Retailer | Page           | IsWebviewer | LandingTab     |
	| [#169325a] Check for showAllStatuses = false | TG       | Product Lookup | No          | Product Lookup |
	| [#169325b] Check for showAllStatuses = false | CV       | Product Lookup | No          | Program Health |
#		| [#169325c] Check for showAllStatuses = false | SF       | Product Lookup | No          | Program Health       |
	| [#169325d] Check for showAllStatuses = false | LW       | Product Lookup | No          | LWLandingtab   |
	| [#169325e] Check for showAllStatuses = false | TG       | Target_store   | Yes         | Product Lookup |
#		| [#169325f] Check for showAllStatuses = false | CT       | Product Lookup    | No          |

Scenario Outline: [169167] Reset
	Given I log into the RPS Integrated site as Retailer: <Retailer>
	Then I confirm the active tab is: <LandingTab>
	Then I click Accept all Cookies
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then In the table footer, I save the total number of rows as: OriginalTotalRows_169167
	Then In the table, in row #1, I save the WPSID as: WPSID_169167
	Then In the recent activities Page, In the Products table I search for the product with ID saved to context as: WPSID_169167
	Then In the table navigation bar, I click the 'Reset' button
	Then In the table footer, I confirm the total number of rows does match value saved as: OriginalTotalRows_169167
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then In the table footer, I confirm the total number of rows does match value saved as: OriginalTotalRows_169167
	Then I call Shared Step 153321 (RPS & WV > More Filters > Select Supplier): <Supplier>
	Then In the table navigation bar, I click the 'Reset' button
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then In the table footer, I confirm the total number of rows does match value saved as: OriginalTotalRows_169167
	Then I call Shared Step 106194 (RPS Sign out)

Examples:
	| Scenario Name    | Retailer | Page              | IsWebviewer | LandingTab     | Supplier      |
	| [#169167a] Reset | CV       | Recent Activities | No          | Program Health | The WERCS LTD |
	| [#169167b] Reset | CV       | Product Lookup    | No          | Program Health | The WERCS LTD |
	| [#169167c] Reset | LW       | Recent Activities | No          | Program Health | The WERCS LTD |
	| [#169167d] Reset | LW       | Product Lookup    | No          | Program Health | The WERCS LTD |
	| [#169167e] Reset | LW       | Lowes_store       | Yes         | Program Health | The WERCS LTD |
	| [#169167f] Reset | TG       | Recent Activities | No          | TGlandingtab   | The WERCS LTD |
	| [#169167g] Reset | TG       | Product Lookup    | No          | TGlandingtab   | The WERCS LTD |
	| [#169167h] Reset | TG       | Target_store      | Yes         | TGlandingtab   | The WERCS LTD |
	| [#169167i] Reset | TG       | Target_status     | Yes         | TGlandingtab   | The WERCS LTD |
	| [#169167j] Reset | TG       | Target_HQ         | Yes         | TGlandingtab   | The WERCS LTD |
	| [#169167k] Reset | SF       | Recent Activities | No          | Program Health | The WERCS LTD |
	| [#169167l] Reset | SF       | Product Lookup    | No          | Program Health | The WERCS LTD |
	| [#169167m] Reset | SF       | SmartFinal_Store  | Yes         | Program Health | The WERCS LTD |
#		| [#169167o] Reset | CT       | Recent Activities      | No          |
#		| [#169167p] Reset | CT       | Product Lookup         | No          |
#		| [#169167q] Reset | CT       | Classification History | No          |

Scenario Outline: [169168] Reset again
	Given I log into the RPS Integrated site as Retailer: <Retailer>
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then In the table footer, I save the total number of rows as: OriginalTotalRows_169168
	Then In the table, in row #1, I save the WPSID as: WPSID_169167
	Then In the recent activities Page, In the Products table I search for the product with ID saved to context as: WPSID_169167
	Then In the table navigation bar, I click the 'Reset' button
	Then In the recent activities Page, I click the More Filters Button
	Then In the More Filters pop up, I click  General Filters from the Filter Categories column
	Then In the More Filters pop up, I click Supplier Name from the Filters column
	Then In the Filter parameters list I select an entry for the Supplier Name Parmeter list: <Supplier>
	Then In the product lookup page More Filters Popup, I Click the the Apply Filter Button
	Then In the product lookup page, I confirm the More Filters popup is not displayed
	Then In the table footer, I confirm the total number of rows does not match value saved as: OriginalTotalRows_169168
	Then In the table navigation bar, I click the 'Reset' button
	Then In the recent activities Page, I click the More Filters Button
	Then In the More Filters pop up, I click  General Filters from the Filter Categories column
	Then In the More Filters pop up, I click Supplier Name from the Filters column
	Then In the Filter parameters list I select an entry for the Supplier Name Parmeter list: <Supplier>
	Then In the product lookup page More Filters Popup, I Click the the Apply Filter Button
	Then In the product lookup page, I confirm the More Filters popup is not displayed
	Then In the table navigation area, I confirm the Breadcrumb List does exist
	Then In the table navigation area, I confirm the Breadcrumb List does contain the Breadcrumb labeled: <Supplier>
	Then In the table navigation bar, I click the 'Reset' button
	Then In the table footer, I confirm the total number of rows does match value saved as: OriginalTotalRows_169168
	Then In the table navigation area, I confirm the Breadcrumb List does not contain the Breadcrumb labeled: <Supplier>
	Then I call Shared Step 106194 (RPS Sign out)

Examples:
	| Scenario Name          | Retailer | Page              | IsWebviewer | LandingTab     | Supplier      |
	| [#169168a] Reset again | CV       | Recent Activities | No          | Program Health | The WERCS LTD |
	| [#169168b] Reset again | CV       | Product Lookup    | No          | Program Health | The WERCS LTD |
	| [#169168c] Reset again | LW       | Recent Activities | No          | Program Health | The WERCS LTD |
	| [#169168d] Reset again | LW       | Product Lookup    | No          | Program Health | The WERCS LTD |
	| [#169168e] Reset again | LW       | Lowes_store       | Yes         | Program Health | The WERCS LTD |
	| [#169168f] Reset again | TG       | Recent Activities | No          | TGlandingtab   | The WERCS LTD |
	| [#169168g] Reset again | TG       | Product Lookup    | No          | TGlandingtab   | The WERCS LTD |
	| [#169168h] Reset again | TG       | Target_store      | Yes         | TGlandingtab   | The WERCS LTD |
	| [#169168i] Reset again | TG       | Target_status     | Yes         | TGlandingtab   | The WERCS LTD |
	| [#169168j] Reset again | TG       | Target_HQ         | Yes         | TGlandingtab   | The WERCS LTD |
	| [#169168k] Reset again | SF       | Recent Activities | No          | Program Health | The WERCS LTD |
	| [#169168l] Reset again | SF       | Product Lookup    | No          | Program Health | The WERCS LTD |
	| [#169168m] Reset again | SF       | SmartFinal_Store  | Yes         | Program Health | The WERCS LTD |
#		| [#169168o] Reset again | CT       | Recent Activities      | No          |
#		| [#169168p] Reset again | CT       | Product Lookup         | No          |
#		| [#169168q] Reset again | CT       | Classification History | No          |


Scenario Outline: [169106] Page Footer - Layout
	Given I log into the RPS Integrated site as Retailer: <Retailer>
	Then I confirm the active tab is: <LandingTab>
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then In the table footer, I confirm the rows per page selector does exist
	Then In the table footer, I confirm the page navigation controls do exist
	Then In the table footer, I confirm the row index does exist
	Then I call Shared Step 106194 (RPS Sign out)

Examples:
	| Scenario Name                   | Retailer | Page              | IsWebviewer | LandingTab     |
	| [#169106a] Page Footer - Layout | CV       | Recent Activities | No          | Program Health |
	| [#169106b] Page Footer - Layout | CV       | Product Lookup    | No          | Program Health |
	| [#169106c] Page Footer - Layout | LW       | Recent Activities | No          | LWLandingtab   |
	| [#169106d] Page Footer - Layout | LW       | Product Lookup    | No          | LWLandingtab   |
	| [#169106e] Page Footer - Layout | LW       | Lowes_store       | Yes         | LWLandingtab   |
	| [#169106f] Page Footer - Layout | TG       | Recent Activities | No          | Product Lookup |
	| [#169106g] Page Footer - Layout | TG       | Product Lookup    | No          | Product Lookup |
	| [#169106h] Page Footer - Layout | TG       | Target_store      | Yes         | Product Lookup |
	| [#169106i] Page Footer - Layout | TG       | Target_status     | Yes         | Product Lookup |
	| [#169106j] Page Footer - Layout | TG       | Target_HQ         | Yes         | Product Lookup |
	| [#169106k] Page Footer - Layout | SF       | Recent Activities | No          | Program Health |
	| [#169106l] Page Footer - Layout | SF       | Product Lookup    | No          | Program Health |
	| [#169106m] Page Footer - Layout | SF       | SmartFinal_Store  | Yes         | Program Health |
#		| [#169106n] Page Footer - Layout | LW       | Drum Log               | No          |
#		| [#169106o] Page Footer - Layout | CT       | Recent Activities      | No          |
#		| [#169106p] Page Footer - Layout | CT       | Product Lookup         | No          |
#		| [#169106q] Page Footer - Layout | CT       | Classification History | No          |