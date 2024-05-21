@RPS
@Login
@run_RecentActivites_Search
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


Feature: Recent Activities - Search
 
@ScenarioId:7002
Scenario: [98615] Base Functionality - Recent Activities - Search for Product Name
Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
Then I confirm the active tab is: <LandingTab>
Given I click the main tab: Recent Activities
Then I confirm the Recent Activities tab has loaded
And In the recent activities Page, In the Products table I select a random product and save product Data to context as: RecentProductData98615
Then In the recent activities Page, In the Products table I search for the product with Name: RecentProductData98615
Then I confirm the Recent Activities tab has loaded
Then In the recent activities Page, In the Products table the results contain the product with Name: RecentProductData98615

	Examples:
		| Scenario Name                                                              | Retailer | LandingTab               |
		| [#98615a] Base Functionality - Recent Activities - Search for Product Name | RPS.LW   | LWLandingtab             |
		| [#98615b] Base Functionality - Recent Activities - Search for Product Name | RPS.SF   | Program Health           |
#		| [#98615c] Base Functionality - Recent Activities - Search for Product Name | RPS.PX   | Program Health           |
		| [#98615e] Base Functionality - Recent Activities - Search for Product Name | RPS.CV   | Program Health           |
#		| [#98615f] Base Functionality - Recent Activities - Search for Product Name | RPS.HD   | Program Health           |


@ScenarioId:7003
Scenario: [98613] Base Functionality - Recent Activities - Search for UPC
Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
Given I click the main tab: Recent Activities
Then I confirm the Recent Activities tab has loaded
Then Select any UPC shown on the page and save as: savedAs1 
Then I Enter UPC Number : savedAs1 in Search field 
Then I confirm the page has refreshed 
Then I confirm the UPC I saved: savedAs1 is shown in Product Table 

	Examples:
		| Scenario Name                                                     | Retailer | LandingTab               |
		| [#98613a] Base Functionality - Recent Activities - Search for UPC | RPS.LW   | LWLandingtab             |
 		| [#98613b] Base Functionality - Recent Activities - Search for UPC | RPS.CV   | Program Health           |
#		| [#98613c] Base Functionality - Recent Activities - Search for UPC | RPS.WM   | Program Health           |
#		| [#98613d] Base Functionality - Recent Activities - Search for UPC | RPS.PX   | Program Health           |
 		| [#98613e] Base Functionality - Recent Activities - Search for UPC | RPS.SF   | Program Health           |
#		| [#98613f] Base Functionality - Recent Activities - Search for UPC | RPS.HD   | Program Health           |


@ScenarioId:7006
Scenario: [73171] Base Functionality - Recent Activities - Search for name with comma
Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
Then I confirm the active tab is: <LandingTab>
Given I click the main tab: Recent Activities
Then I confirm the Recent Activities tab has loaded
Then In the recent activities Page, In the Products table I search for the product: ,
Then I confirm the Recent Activities tab has loaded
And In the recent activities Page, In the Products table I select a random product and save product Data to context as: RecentProductData73171
Then In the recent activities Page, In the Products table I search for the Partial Name of a comma product saved as: RecentProductData73171
Then I confirm the Recent Activities tab has loaded
Then In the recent activities Page, In the Products table the results contain the product with Name: RecentProductData73171

	Examples:
		| Scenario Name                                                                 | Retailer | LandingTab               |
		| [#73171a] Base Functionality - Recent Activities - Search for name with comma | RPS.LW   | LWLandingtab             |
		| [#73171b] Base Functionality - Recent Activities - Search for name with comma | RPS.SF   | Program Health           |
#		| [#73171c] Base Functionality - Recent Activities - Search for name with comma | RPS.PX   | Program Health           |
		| [#73171e] Base Functionality - Recent Activities - Search for name with comma | RPS.CV   | Program Health           |
#		| [#73171f] Base Functionality - Recent Activities - Search for name with comma | RPS.HD   | Program Health           |



@ScenarioId:7011
Scenario: [70329] Base Functionality - Recent Activities - Search - Enter Key, or no action shows results
Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
Then I confirm the active tab is: <LandingTab>
Given I click the main tab: Recent Activities
Then I confirm the Recent Activities tab has loaded
Then In the recent activities Page, In the Products table I search for the product: Bath
Then I confirm the Recent Activities tab has loaded
Then In the recent activities Page, In the Products table I confirm that all displayed results contain Bath in their product name
And In the recent activities Page, In the Products table I click the Reset Button
Then In the recent activities Page, In the Products table I enter product text: Bath and press the Enter Key
Then I confirm the Recent Activities tab has loaded
Then In the recent activities Page, In the Products table I confirm that all displayed results contain Bath in their product name

	Examples:
		| Scenario Name                                                                                     | Retailer | LandingTab               |
		| [#70329a] Base Functionality - Recent Activities - Search - Enter Key, or no action shows results | RPS.LW   | LWLandingtab             |
		| [#70329b] Base Functionality - Recent Activities - Search - Enter Key, or no action shows results | RPS.SF   | Program Health           |
#		| [#70329c] Base Functionality - Recent Activities - Search - Enter Key, or no action shows results | RPS.WM   | Program Health           |
#		| [#70329d] Base Functionality - Recent Activities - Search - Enter Key, or no action shows results | RPS.PX   | Program Health           |
		| [#70329e] Base Functionality - Recent Activities - Search - Enter Key, or no action shows results | RPS.CV   | Program Health           |
#		| [#70329f] Base Functionality - Recent Activities - Search - Enter Key, or no action shows results | RPS.HD   | Program Health           |

@ScenarioId:7012
Scenario: [105064] Base Functionality - Recent Activity - Filter for Product, Filter for new product - data is refreshed in the product grid
Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
Then I confirm the active tab is: <LandingTab>
Given I click the main tab: Recent Activities 
Then Select any WPSID shown on the page and save as: savedAs1 
Then Select any WPSID shown on the page and save as: savedAs2 
Then I Enter WPSID Number : savedAs1 in Search field 
Then I confirm the page has refreshed 
Then I confirm the WPSID I saved: savedAs1 is shown in Product Table 
Then I Enter WPSID Number : savedAs2 in Search field 
Then I confirm the page has refreshed 
Then I confirm the WPSID I saved: savedAs2 is shown in Product Table
Then I Enter WPSID Number : savedAs1 in Search field 
Then I confirm the page has refreshed 
Then I confirm the WPSID I saved: savedAs1 is shown in Product Table 

	Examples:
		| Scenario Name                                                                                                                        | Retailer | LandingTab               |
		| [#105064a] Base Functionality - Recent Activity - Filter for Product, Filter for new product - data is refreshed in the product grid | RPS.LW   | LWLandingtab             |
 		| [#105064b] Base Functionality - Recent Activity - Filter for Product, Filter for new product - data is refreshed in the product grid | RPS.SF   | Program Health           |
#		| [#105064c] Base Functionality - Recent Activity - Filter for Product, Filter for new product - data is refreshed in the product grid | RPS.WM   | Program Health           |
#		| [#105064d] Base Functionality - Recent Activity - Filter for Product, Filter for new product - data is refreshed in the product grid | RPS.PX   | Program Health           |
 		| [#105064e] Base Functionality - Recent Activity - Filter for Product, Filter for new product - data is refreshed in the product grid | RPS.CV   | Program Health           |
#		| [#105064f] Base Functionality - Recent Activity - Filter for Product, Filter for new product - data is refreshed in the product grid | RPS.HD   | Program Health           |
















