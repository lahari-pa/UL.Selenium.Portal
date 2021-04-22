@RPS
@Login
@run_RecentActivites_Actions
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

Feature: Recent Activities - Actions

@ScenarioId:9379
Scenario: [99212] Base Functionality - Recent Activities - Contact Supplier -  displays for all products
Given I call Shared Step 104950 (RPS Login - Base functionality) for TReVor account: RPS.99
Then I confirm the Home tab has loaded
Given I click the tab: Recent Activities
Then I confirm the Recent Activities tab has loaded
Then In the recent activities page, I confirm that the main table includes the following columns:
| Headings             |
| Actions              |
#And In the recent activities Page, I confirm for all products the Action column includes: Contact Supplier
Then In the recent activities Page, I confirm for all products the Action column includes option: Contact Supplier
And I call Shared Step 106194 (RPS Sign out)

@ScenarioId:9381
Scenario: [99211] Base Functionality - Recent Activities - View Data displays for Completed products
Given I call Shared Step 104950 (RPS Login - Base functionality) for TReVor account: RPS.99
Then I confirm the Home tab has loaded
Given I click the tab: Recent Activities
Then I confirm the Recent Activities tab has loaded
And In the recent activities Page, I click the More Filters Button
Then In the recent activities page, I select the option: Completed from the status drop down menu
Then In the recent activities Page More Filters Popup, I Click the the Apply Filter Button
Then In the recent activities Page, The More Filters Popup is not showing
Then I confirm the Recent Activities page refreshes
Then In the recent activities Page, In the Products table I confirm that all displayed results show Completed as their status
Then In the recent activities Page, I confirm for all products the Action column includes option: View Data
And I call Shared Step 106194 (RPS Sign out)

@ScenarioId:9382
Scenario: [99210] Base Functionality - Recent Activities - View Data does not display for non-completed products 
Given I call Shared Step 104950 (RPS Login - Base functionality) for TReVor account: RPS.99
Then I confirm the Home tab has loaded
Given I click the tab: Recent Activities
Then I confirm the Recent Activities tab has loaded
Then I call Shared Step 106901 (More Filters - Select Status - Apply - Confirm Actions column does NOT show View Data) for status: Accepted
Then I call Shared Step 106901 (More Filters - Select Status - Apply - Confirm Actions column does NOT show View Data) for status: Assigned
Then I call Shared Step 106901 (More Filters - Select Status - Apply - Confirm Actions column does NOT show View Data) for status: Cancelled
Then I call Shared Step 106901 (More Filters - Select Status - Apply - Confirm Actions column does NOT show View Data) for status: Hold
Then I call Shared Step 106901 (More Filters - Select Status - Apply - Confirm Actions column does NOT show View Data) for status: New
Then I call Shared Step 106901 (More Filters - Select Status - Apply - Confirm Actions column does NOT show View Data) for status: Recertification
Then I call Shared Step 106901 (More Filters - Select Status - Apply - Confirm Actions column does NOT show View Data) for status: Release for Distribution
Then I call Shared Step 106901 (More Filters - Select Status - Apply - Confirm Actions column does NOT show View Data) for status: Submitted
And I call Shared Step 106194 (RPS Sign out)

@ScenarioId:9384
Scenario: [106908] Base Functionality - Recent Activities - View Data  - pop up layout
Given I call Shared Step 104950 (RPS Login - Base functionality) for TReVor account: RPS.99
Then I confirm the Home tab has loaded
Given I click the tab: Recent Activities
Then I confirm the Recent Activities tab has loaded
And In the recent activities Page, I click the More Filters Button
Then In the recent activities page, I select the option: Completed from the status drop down menu
Then In the recent activities Page More Filters Popup, I Click the the Apply Filter Button
Then In the recent activities Page, The More Filters Popup is not showing
Then I confirm the Recent Activities page refreshes
Then In the recent activities Page, In the Products table I select the first product and save the Product Information to context as: Recentproductdata106908
And In the recent activities Page, I Click the Row actions: View Data for the product: Recentproductdata106908
Then I wait for the Product Information Popup to load
Then I wait for the Product Information Popup Table to load
Then In the Product Infromation Popup I call shared step 109167 if there is data, and 111879 if there is no data
Then In the Recent Activity Page, I Click Away from the Product Information Popup
And I wait for the Product Information Popup to dissapear
And In the recent activities Page, I Click the Row actions: View Data for the product: Recentproductdata106908
Then I wait for the Product Information Popup to load
Then I wait for the Product Information Popup Table to load
Then I Close the Product Information Popup
And In the recent activities Page, I Click the Row actions: View Data for the product: Recentproductdata106908
Then I wait for the Product Information Popup to load
Then I wait for the Product Information Popup Table to load
And In the Product Infromation Popup I Click the 'x' Close icon
And I wait for the Product Information Popup to dissapear
And I call Shared Step 106194 (RPS Sign out)

@ScenarioId:9740
Scenario: [106919] Base Functionality - Recent Activities - View Data  - Product Data codes - confirm fields shown

Given I call Shared Step 104950 (RPS Login - Base functionality) for TReVor account: RPS.99
Then I confirm the Home tab has loaded
Given I click the tab: Recent Activities
Then I confirm the Recent Activities tab has loaded
And In the recent activities Page, I click the More Filters Button
Then In the recent activities page, I select the option: Completed from the status drop down menu
Then In the recent activities Page More Filters Popup, I Click the the Apply Filter Button
Then In the recent activities Page, The More Filters Popup is not showing
Then I confirm the Recent Activities page refreshes
And In the recent activities Page, In the Products table I select a random product and save product Data to context as: Recentproductdata106919
And In the recent activities Page, I Click the Row actions: View Data for the product: Recentproductdata106919
Given I Confirm that the Product Information pop up is shown
Then I call Shared Step 109168 (Product Information pop up - Expand Product Data codes - confirm rows)
And I Close the Product Information Popup
And I call Shared Step 106194 (RPS Sign out)

@ScenarioId:9741
Scenario: [106920] Base Functionality - Recent Activities - View Data  - Transportation Data - confirm fields shown 

Given I call Shared Step 104950 (RPS Login - Base functionality) for TReVor account: RPS.99
Then I confirm the Home tab has loaded
Given I click the tab: Recent Activities
Then I confirm the Recent Activities tab has loaded
And In the recent activities Page, I click the More Filters Button
Then In the recent activities page, I select the option: Completed from the status drop down menu
Then In the recent activities Page More Filters Popup, I Click the the Apply Filter Button
Then In the recent activities Page, The More Filters Popup is not showing
Then I confirm the Recent Activities page refreshes
And In the recent activities Page, In the Products table I select a random product and save product Data to context as: Recentproductdata106919
And In the recent activities Page, I Click the Row actions: View Data for the product: Recentproductdata106919
Given I Confirm that the Product Information pop up is shown
Then I call Shared Step 109169 (Product Information pop up - Expand Transportation Data - confirm rows)
And I Close the Product Information Popup
And I call Shared Step 106194 (RPS Sign out)

@ScenarioId:9742
Scenario: [106943] Base Functionality - Recent Activities - View Data  - Storage Data - confirm fields shown 

Given I call Shared Step 104950 (RPS Login - Base functionality) for TReVor account: RPS.99
Then I confirm the Home tab has loaded
Given I click the tab: Recent Activities
Then I confirm the Recent Activities tab has loaded
And In the recent activities Page, I click the More Filters Button
Then In the recent activities page, I select the option: Completed from the status drop down menu
Then In the recent activities Page More Filters Popup, I Click the the Apply Filter Button
Then In the recent activities Page, The More Filters Popup is not showing
Then I confirm the Recent Activities page refreshes
And In the recent activities Page, In the Products table I select a random product and save product Data to context as: Recentproductdata106919
And In the recent activities Page, I Click the Row actions: View Data for the product: Recentproductdata106919
Given I Confirm that the Product Information pop up is shown
Then I call Shared Step 109170 (Product Information pop up - Expand Storage Data - confirm rows)
And I Close the Product Information Popup
And I call Shared Step 106194 (RPS Sign out)

@ScenarioId:9743
Scenario: [106945] Base Functionality - Recent Activities - View Data  - Battery Data - confirm fields shown

Given I call Shared Step 104950 (RPS Login - Base functionality) for TReVor account: RPS.99
Then I confirm the Home tab has loaded
Given I click the tab: Recent Activities
Then I confirm the Recent Activities tab has loaded
And In the recent activities Page, I click the More Filters Button
Then In the recent activities page, I select the option: Completed from the status drop down menu
Then In the recent activities Page More Filters Popup, I Click the the Apply Filter Button
Then In the recent activities Page, The More Filters Popup is not showing
Then I confirm the Recent Activities page refreshes
And In the recent activities Page, In the Products table I select a random product and save product Data to context as: Recentproductdata106919
And In the recent activities Page, I Click the Row actions: View Data for the product: Recentproductdata106919
Given I Confirm that the Product Information pop up is shown
Then I call Shared Step 109171 (Product Information pop up - Expand Battery Data - confirm rows)
And I Close the Product Information Popup
And I call Shared Step 106194 (RPS Sign out)

@ScenarioId:9744
Scenario: [106947] Base Functionality - Recent Activities - View Data  - only 1 expanded data section shows

Given I call Shared Step 104950 (RPS Login - Base functionality) for TReVor account: RPS.99
Then I confirm the Home tab has loaded
Given I click the tab: Recent Activities
Then I confirm the Recent Activities tab has loaded
And In the recent activities Page, I click the More Filters Button
Then In the recent activities page, I select the option: Completed from the status drop down menu
Then In the recent activities Page More Filters Popup, I Click the the Apply Filter Button
Then In the recent activities Page, The More Filters Popup is not showing
Then I confirm the Recent Activities page refreshes
And In the recent activities Page, In the Products table I select a random product and save product Data to context as: Recentproductdata106919
And In the recent activities Page, I Click the Row actions: View Data for the product: Recentproductdata106919
Given I Confirm that the Product Information pop up is shown
Then I call Shared Step 109172 (Product information pop up - Only 1 section expands at a time)
And I Close the Product Information Popup
And I call Shared Step 106194 (RPS Sign out)
