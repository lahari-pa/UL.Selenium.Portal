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
Feature: ProductGridTags

Scenario Outline: [169099] Product Grid - Recertification tag
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I call Shared Step 235552 (RPS & WV - More Filters - Apply Status = Pending)
	Then I call Shared Step 153264 (RPS & WV > Product Info > Recertification tags check)
	Then I call Shared Step 106194 (RPS Sign out)

Examples:
	| Scenario Name                                 | Retailer | Page              | IsWebviewer |
	| [#169099a] Product Grid - Recertification tag | RPS.CV   | Recent Activities | No          |
	| [#169099b] Product Grid - Recertification tag | RPS.CV   | Product Lookup    | No          |
	| [#169099c] Product Grid - Recertification tag | RPS.LW   | Recent Activities | No          |
	| [#169099d] Product Grid - Recertification tag | RPS.LW   | Product Lookup    | No          |
	| [#169099e] Product Grid - Recertification tag | RPS.LW   | Lowes_store       | Yes         |
	| [#169099f] Product Grid - Recertification tag | RPS.TG   | Recent Activities | No          |
	| [#169099g] Product Grid - Recertification tag | RPS.TG   | Product Lookup    | No          |
	| [#169099h] Product Grid - Recertification tag | RPS.TG   | Target_status     | Yes         |
	| [#169099i] Product Grid - Recertification tag | RPS.SF   | Recent Activities | No          |
	| [#169099j] Product Grid - Recertification tag | RPS.SF   | Product Lookup    | No          |
	| [#169099k] Product Grid - Recertification tag | RPS.SF   | SmartFinal_Store  | Yes         |
	| [#169099l] Product Grid - Recertification tag | RPS.CT   | Recent Activities | No          |
	| [#169099m] Product Grid - Recertification tag | RPS.CT   | Product Lookup    | No          |


Scenario Outline: [169100] Product Grid - ON HOLD tag
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I call Shared Step 235552 (RPS & WV - More Filters - Apply Status = Pending)
	Then In the Product Info Cell in row #1, the red colored ON HOLD tag does show after the Product Name
	Then I call Shared Step 106194 (RPS Sign out)

Examples:
	| Scenario Name                         | Retailer | Page              | IsWebviewer |
	| [#169100a] Product Grid - ON HOLD tag | RPS.CV   | Recent Activities | No          |
	| [#169100b] Product Grid - ON HOLD tag | RPS.CV   | Product Lookup    | No          |
	| [#169100c] Product Grid - ON HOLD tag | RPS.LW   | Recent Activities | No          |
	| [#169100d] Product Grid - ON HOLD tag | RPS.LW   | Product Lookup    | No          |
	| [#169100e] Product Grid - ON HOLD tag | RPS.LW   | Lowes_store       | Yes         |
	| [#169100f] Product Grid - ON HOLD tag | RPS.TG   | Recent Activities | No          |
	| [#169100g] Product Grid - ON HOLD tag | RPS.TG   | Product Lookup    | No          |
	| [#169100h] Product Grid - ON HOLD tag | RPS.TG   | Target_status     | Yes         |
	| [#169100i] Product Grid - ON HOLD tag | RPS.SF   | Recent Activities | No          |
	| [#169100j] Product Grid - ON HOLD tag | RPS.SF   | Product Lookup    | No          |
	| [#169100k] Product Grid - ON HOLD tag | RPS.SF   | SmartFinal_Store  | Yes         |
	| [#169100l] Product Grid - ON HOLD tag | RPS.CT   | Recent Activities | No          |
	| [#169100m] Product Grid - ON HOLD tag | RPS.CT   | Product Lookup    | No          |


Scenario Outline: [169101] Product Grid - Retailer Uploaded Tag
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I call Shared Step 153383 (RPS & WV > Retailer Uploaded tag)
	Then I call Shared Step 106194 (RPS Sign out)

Examples:
	| Scenario Name                                   | Retailer | Page              | IsWebviewer |
	| [#169101a] Product Grid - Retailer Uploaded tag | RPS.TG   | Recent Activities | No          |
	| [#169101b] Product Grid - Retailer Uploaded tag | RPS.TG   | Product Lookup    | No          |
#		| [#169101c] Product Grid - Retailer Uploaded tag | RPS.TG       | Target_store      | Yes         |
	| [#169101d] Product Grid - Retailer Uploaded tag | RPS.TG   | Target_status     | Yes         |
	| [#169101e] Product Grid - Retailer Uploaded tag | RPS.TG   | Target_HQ         | Yes         |
	| [#169101f] Product Grid - Retailer Uploaded tag | RPS.CT   | Recent Activities | No          |
	| [#169101g] Product Grid - Retailer Uploaded tag | RPS.CT   | Product Lookup    | No          |


Scenario Outline: [169102] Product Grid - PLP Tag
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then In the table navigation area, in the Search Input, I enter: <wpsid>
	Then In the Product Info Cell in row #1, the WPSID value does match: <wpsid>
	Then In the Product Info Cell in row #1, the red colored (PLP) tag does show after the Product Name
	Then I call Shared Step 106194 (RPS Sign out)

Examples:
	| Scenario Name                     | Retailer | Page              | IsWebviewer |
	| [#169102a] Product Grid - PLP tag | RPS.CV   | Recent Activities | No          |
	| [#169102b] Product Grid - PLP tag | RPS.CV   | Product Lookup    | No          |
	| [#169102c] Product Grid - PLP tag | RPS.LW   | Recent Activities | No          |
	| [#169102d] Product Grid - PLP tag | RPS.LW   | Product Lookup    | No          |
	| [#169102e] Product Grid - PLP tag | RPS.LW   | Lowes_store       | Yes         |
	| [#169102f] Product Grid - PLP tag | RPS.TG   | Recent Activities | No          |
	| [#169102g] Product Grid - PLP tag | RPS.TG   | Product Lookup    | No          |
	| [#169102h] Product Grid - PLP tag | RPS.TG   | Target_store      | Yes         |
	| [#169102i] Product Grid - PLP tag | RPS.TG   | Target_status     | Yes         |
	| [#169102j] Product Grid - PLP tag | RPS.TG   | Target_HQ         | Yes         |
	| [#169102k] Product Grid - PLP tag | RPS.SF   | Recent Activities | No          |
	| [#169102l] Product Grid - PLP tag | RPS.SF   | Product Lookup    | No          |
	| [#169102m] Product Grid - PLP tag | RPS.SF   | SmartFinal_Store  | Yes         |
	| [#169102n] Product Grid - PLP tag | RPS.CT   | Recent Activities | No          |
	| [#169102o] Product Grid - PLP tag | RPS.CT   | Product Lookup    | No          |

Scenario Outline: [169103] Product Grid - Archived (product) Tag
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I call Shared Step 235552 (RPS & WV - More Filters - Apply Status = Pending)
	Then I call Shared Step 235551 (More Filters - Apply Is UPC archived = true)
	Then In the Product Info Cell in row #1, the red colored Archived tag does show after the WPSID
	Then I call Shared Step 106194 (RPS Sign out)

Examples:
	| Scenario Name                                    | Retailer | Page              | IsWebviewer |
	| [#169103a] Product Grid - Archived (product) tag | RPS.CV   | Recent Activities | No          |
	| [#169103b] Product Grid - Archived (product) tag | RPS.CV   | Product Lookup    | No          |
	| [#169103c] Product Grid - Archived (product) tag | RPS.LW   | Recent Activities | No          |
	| [#169103d] Product Grid - Archived (product) tag | RPS.LW   | Product Lookup    | No          |
	| [#169103e] Product Grid - Archived (product) tag | RPS.LW   | Lowes_store       | Yes         |
	| [#169103f] Product Grid - Archived (product) tag | RPS.TG   | Recent Activities | No          |
	| [#169103g] Product Grid - Archived (product) tag | RPS.TG   | Product Lookup    | No          |
	| [#169103h] Product Grid - Archived (product) tag | RPS.TG   | Target_store      | Yes         |
	| [#169103i] Product Grid - Archived (product) tag | RPS.TG   | Target_status     | Yes         |
	| [#169103j] Product Grid - Archived (product) tag | RPS.TG   | Target_HQ         | Yes         |
	| [#169103k] Product Grid - Archived (product) tag | RPS.SF   | Recent Activities | No          |
	| [#169103l] Product Grid - Archived (product) tag | RPS.SF   | Product Lookup    | No          |
	| [#169103m] Product Grid - Archived (product) tag | RPS.SF   | SmartFinal_Store  | Yes         |
	| [#169103n] Product Grid - Archived (product) tag | RPS.CT   | Recent Activities | No          |
#		| [#169103o] Product Grid - Archived (product) tag | RPS.CT       | Product Lookup    | No          |


Scenario Outline: [169104] Product Grid - Archived (UPC) Tag
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I call Shared Step 235551 (More Filters - Apply Is UPC archived = true)
	Then In the Product Info Cell in row #1, the red colored Archived tag does show after the UPC
	Then I call Shared Step 106194 (RPS Sign out)

Examples:
	| Scenario Name                                | Retailer | Page              | IsWebviewer |
	| [#169104a] Product Grid - Archived (UPC) tag | RPS.CV   | Recent Activities | No          |
	| [#169104b] Product Grid - Archived (UPC) tag | RPS.CV   | Product Lookup    | No          |
	| [#169104c] Product Grid - Archived (UPC) tag | RPS.LW   | Recent Activities | No          |
	| [#169104d] Product Grid - Archived (UPC) tag | RPS.LW   | Product Lookup    | No          |
	| [#169104e] Product Grid - Archived (UPC) tag | RPS.LW   | Lowes_store       | Yes         |
	| [#169104f] Product Grid - Archived (UPC) tag | RPS.TG   | Recent Activities | No          |
	| [#169104g] Product Grid - Archived (UPC) tag | RPS.TG   | Product Lookup    | No          |
	| [#169104h] Product Grid - Archived (UPC) tag | RPS.TG   | Target_store      | Yes         |
	| [#169104i] Product Grid - Archived (UPC) tag | RPS.TG   | Target_status     | Yes         |
	| [#169104j] Product Grid - Archived (UPC) tag | RPS.TG   | Target_HQ         | Yes         |
	| [#169104k] Product Grid - Archived (UPC) tag | RPS.SF   | Recent Activities | No          |
	| [#169104l] Product Grid - Archived (UPC) tag | RPS.SF   | Product Lookup    | No          |
	| [#169104m] Product Grid - Archived (UPC) tag | RPS.SF   | SmartFinal_Store  | Yes         |
	| [#169104n] Product Grid - Archived (UPC) tag | RPS.CT   | Recent Activities | No          |
#		| [#169104o] Product Grid - Archived (UPC) tag | RPS.CT       | Product Lookup    | No          |
