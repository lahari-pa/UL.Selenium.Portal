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

@ScenarioId:7001
Scenario: [98614] Base Functionality - Recent Activities - Search for Product ID
Given I call Shared Step 104950 (RPS Login - Base functionality) for TReVor account: RPS.99
Then I confirm the Home tab has loaded
Given I click the tab: Recent Activities
Then I confirm the Recent Activities tab has loaded
Then In the recent activities page, I click the label 'Start Date'
Then I confirm the Recent Activities tab has loaded
And In the recent activities Page, In the Products table I select a random product and save product Data to context as: RecentProductData99614
Then In the recent activities Page, In the Products table I search for the product with ID: RecentProductData99614
Then I confirm the Recent Activities tab has loaded
Then In the recent activities Page, In the Products table the first result matches the product ID: RecentProductData99614

@ScenarioId:7002
Scenario: [98615] Base Functionality - Recent Activities - Search for Product Name
Given I call Shared Step 104950 (RPS Login - Base functionality) for TReVor account: RPS.99
Then I confirm the Home tab has loaded
Given I click the tab: Recent Activities
Then I confirm the Recent Activities tab has loaded
Then In the recent activities page, I click the label 'Start Date'
Then I confirm the Recent Activities tab has loaded
And In the recent activities Page, In the Products table I select a random product and save product Data to context as: RecentProductData98615
Then In the recent activities Page, In the Products table I search for the product with Name: RecentProductData98615
Then I confirm the Recent Activities tab has loaded
Then In the recent activities Page, In the Products table the first result matches the product Name: RecentProductData98615

@ScenarioId:7003
Scenario: [98613] Base Functionality - Recent Activities - Search for UPC
Given I call Shared Step 104950 (RPS Login - Base functionality) for TReVor account: RPS.99
Then I confirm the Home tab has loaded
Given I click the tab: Recent Activities
Then I confirm the Recent Activities tab has loaded
Then In the recent activities page, I click the label 'Start Date'
Then I confirm the Recent Activities tab has loaded
And In the recent activities Page, In the Products table I select a random product and save product Data to context as: RecentProductData98613
Then In the recent activities Page, In the Products table I search for the product with UPC: RecentProductData98613
Then I confirm the Recent Activities tab has loaded
Then In the recent activities Page, In the Products table the first result matches the product ID: RecentProductData98613
Then In the recent activities Page, In the Products table there is only 1 result showing
Then In the recent activities Page, In the Products table the First result matches the UPCs saved as: RecentProductData98613

@ScenarioId:7006
Scenario: [73171] Base Functionality - Recent Activities - Search for name with comma
Given I call Shared Step 104950 (RPS Login - Base functionality) for TReVor account: RPS.99
Then I confirm the Home tab has loaded
Given I click the tab: Recent Activities
Then I confirm the Recent Activities tab has loaded
Then In the recent activities page, I click the label 'Start Date'
Then I confirm the Recent Activities tab has loaded
Then In the recent activities Page, In the Products table I search for the product with Name: ,
Then I confirm the Recent Activities tab has loaded
And In the recent activities Page, In the Products table I select a random product and save product Data to context as: RecentProductData73171
Then In the recent activities Page, In the Products table I search for the Partial Name of a comma product saved as: RecentProductData73171
Then I confirm the Recent Activities tab has loaded
Then In the recent activities Page, In the Products table the results contain the product with Name: RecentProductData73171

@ScenarioId:7011
Scenario: [70329] Base Functionality - Recent Activities - Search - Enter Key, or no action shows results
Given I call Shared Step 104950 (RPS Login - Base functionality) for TReVor account: RPS.99
Then I confirm the Home tab has loaded
Given I click the tab: Recent Activities
Then I confirm the Recent Activities tab has loaded
Then In the recent activities page, I click the label 'Start Date'
Then I confirm the Recent Activities tab has loaded
Then In the recent activities Page, In the Products table I search for the product with Name: Bath
Then I confirm the Recent Activities tab has loaded
Then In the recent activities Page, In the Products table I confirm that all displayed results contain Bath in their product name
And In the recent activities Page, In the Products table I click the Reset Button
Then In the recent activities page, I click the label 'Start Date'
Then I confirm the Recent Activities tab has loaded
Then In the recent activities Page, In the Products table I enter name search text: Bath and press the Enter Key
Then I confirm the Recent Activities tab has loaded
Then In the recent activities Page, In the Products table I confirm that all displayed results contain Bath in their product name

@ScenarioId:7012
Scenario: [105064] Base Functionality - Recent Activity - Filter for Product, Filter for new product - data is refreshed in the product grid
Given I call Shared Step 104950 (RPS Login - Base functionality) for TReVor account: RPS.99
Then I confirm the Home tab has loaded
Given I click the tab: Recent Activities
Then I confirm the Recent Activities tab has loaded
Then In the recent activities page, I click the label 'Start Date'
Then I confirm the Recent Activities tab has loaded
Then In the recent activities Page, In the Products table I select 2 random products and save product Data to context as: RecentProductData1 and RecentProductData2
Then In the recent activities Page, In the Products table I search for the product with ID: RecentProductData1
Then I confirm the Recent Activities tab has loaded
Then In the recent activities Page, In the Products table there is only 1 result showing
Then In the recent activities Page, In the Products table the first result matches the product ID: RecentProductData1
Then In the recent activities Page, In the Products table the first result matches the product data: RecentProductData1
Then In the recent activities Page, In the Products table I search for the product with ID: RecentProductData2
Then I confirm the Recent Activities tab has loaded
Then In the recent activities Page, In the Products table there is only 1 result showing
Then In the recent activities Page, In the Products table the first result matches the product ID: RecentProductData2
Then In the recent activities Page, In the Products table the first result matches the product data: RecentProductData2
Then In the recent activities Page, In the Products table I search for the product with ID: RecentProductData1
Then I confirm the Recent Activities tab has loaded
Then In the recent activities Page, In the Products table there is only 1 result showing
Then In the recent activities Page, In the Products table the first result matches the product ID: RecentProductData1
Then In the recent activities Page, In the Products table the first result matches the product data: RecentProductData1


















