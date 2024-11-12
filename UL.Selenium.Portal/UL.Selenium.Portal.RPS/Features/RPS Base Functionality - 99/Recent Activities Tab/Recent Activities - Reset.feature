@RPS
@Login
@run_RecentActivites_Reset
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
@MoreFilters
Feature: Recent Activities - Reset

@ScenarioId:8109
Scenario: [106866] Base Functionality - Recent Activities - Reset
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: Franky TG User
#Then I confirm the Home tab has loaded
	Given I click the main tab: Recent Activities
	Then I confirm the Recent Activities tab has loaded
	Then In the recent activities page, I click the label 'Start Date'
	Then I confirm the Recent Activities tab has loaded
	And In the recent activities Page, In the Products table I select a random product and save product Data to context as: RecentProductData106866
	Then In the recent activities Page, In the Products table I search for the product with ID: RecentProductData106866
	Then I confirm the Recent Activities tab has loaded
	Then In the recent activities Page, In the Products table I confirm that all displayed results have RecentProductData106866 as their Product ID
	Then In the recent activities Page, In the Products table the first result matches the product ID: RecentProductData106866
	And In the recent activities Page, In the Products table I click the Reset Button
#Below is used to indicate the results grid shows other products after reset, maybe make a step that saves all displayed products to context then later we can compare this?
	Then In the recent activities Page, In the Products table there is more than 1 result showing
	Then In the recent activities Page, In the Products table I confirm that Not all displayed results have RecentProductData106866 as their Product ID
	Then In the recent activities page, I click the label 'Start Date'
	Then In the recent activities Page, In the Products table I select a random product and save the supplier name to context as: SavedProductSupplier106866
	And In the recent activities Page, I click the More Filters Button
	And In the Product Lookup Page, The More Filters Popup is showing
	Then In the recent activities Page More Filters Popup, In the Supplier Name field, I enter part of: SavedProductSupplier106866 and save the partial text as: SavedProductSupplier106866Partial
	Then In the recent activities Page More Filters Popup, I Click the the Apply Filter Button
	Then In the recent activities Page, The More Filters Popup is not showing
	Then I confirm the Recent Activities page refreshes
	And In the recent activities Page, In the Products table I confirm that all displayed results contain SavedProductSupplier106866Partial in their Supplier name
	And In the recent activities Page, In the Products table I click the Reset Button
	And In the recent activities Page, In the Products table I confirm that not all displayed results contain SavedProductSupplier106866Partial in their Supplier name
	And I call Shared Step 106194 (RPS Sign out)

@ScenarioId:8267
Scenario: [70326] Base Functionality - Recent Activities - Reset again
#Need a method that saves the list of displayed products to context then a method that checks the current displayed products matches/does not match that saved list ( indicate if filters returned etc)
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: Franky TG User
#Then I confirm the Home tab has loaded
	Given I click the main tab: Recent Activities
	Then I confirm the Recent Activities tab has loaded
#Then In the recent activities page, I click the label 'Start Date'
	Then I confirm the Recent Activities tab has loaded
	Then In the recent activities Page, I save all the Results to context as: RecentProductsGridResults1
	And In the recent activities Page, In the Products table I select a random product and save product Data to context as: RecentProductData106866
	Then In the recent activities Page, In the Products table I search for the product with ID: RecentProductData106866
	Then I confirm the Recent Activities tab has loaded
	Then In the recent activities Page, In the Products table I confirm that all displayed results have RecentProductData106866 as their Product ID
	Then In the recent activities Page, In the Products table the first result matches the product ID: RecentProductData106866
	And In the recent activities Page, In the Products table I click the Reset Button
	Then In the recent activities Page, In the Products table there is more than 1 result showing
	And In the recent activities Page, I check the current results match the results saved as RecentProductsGridResults1
	Then In the recent activities Page, In the Products table I select a random product and save the supplier name to context as: SavedProductSupplier106866
	And In the recent activities Page, I click the More Filters Button
	And In the Product Lookup Page, The More Filters Popup is showing
	Then In the recent activities Page More Filters Popup, In the Supplier Name field, I enter part of: SavedProductSupplier106866 and save the partial text as: SavedProductSupplier106866Partial
	Then In the recent activities page, I select the option: Completed from the status drop down menu
	Then In the recent activities Page More Filters Popup, I Click the the Apply Filter Button
	Then In the recent activities Page, The More Filters Popup is not showing
	Then I confirm the Recent Activities page refreshes
	And In the recent activities Page, In the Products table I confirm that all displayed results contain SavedProductSupplier106866Partial in their Supplier name
	Then In the recent activities Page, In the Products table I confirm that all displayed results show Completed as their status
	And In the recent activities Page, In the Products table I click the Reset Button
	Then In the recent activities Page, In the Products table there is more than 1 result showing
	And In the recent activities Page, In the Products table I confirm that not all displayed results contain SavedProductSupplier106866Partial in their Supplier name
	Then In the recent activities Page, In the Products table I confirm that not all displayed results contain Completed in their Supplier name
	And In the recent activities Page, I check the current results match the results saved as RecentProductsGridResults1
	Then In the recent activities Page, In the Products table I select a random product and save the supplier name to context as: SavedProductSupplier106866B
	And In the recent activities Page, I click the More Filters Button
	And In the Product Lookup Page, The More Filters Popup is showing
	Then In the recent activities Page More Filters Popup, In the Supplier Name field, I enter part of: SavedProductSupplier106866B and save the partial text as: SavedProductSupplier106866BPartial
	Then In the recent activities page, I select the option: Accepted from the status drop down menu
	Then In the recent activities Page More Filters Popup, I Click the the Apply Filter Button
	Then In the recent activities Page, The More Filters Popup is not showing
	Then I confirm the Recent Activities page refreshes
	Then I confirm that the recent activities page shows the bread crumb area
	Then I confirm that the recent activities page bread crumb area contains the label: Supplier: "SavedProductSupplier106866BPartial"
	Then I confirm that the recent activities page bread crumb area contains the label: Status: "Accepted"
	And In the recent activities Page, In the Products table I click the Reset Button
	Then In the recent activities Page, In the Products table there is more than 1 result showing
	And In the recent activities Page, In the Products table I confirm that not all displayed results contain SavedProductSupplier106866BPartial in their Supplier name
	Then In the recent activities Page, In the Products table I confirm that not all displayed results contain Accepted in their Supplier name
	And In the recent activities Page, I check the current results match the results saved as RecentProductsGridResults1
	Then In the recent activities Page, In the Products table Breadcrumb area only Start Date and End Date labels are shown
	And I call Shared Step 106194 (RPS Sign out)

@ScenarioId:9352
Scenario: [98356] Base Functionality  - Recent Activities - Primary Reset button clears Supplier name
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: Franky TG User
#Then I confirm the Home tab has loaded
	Given I click the main tab: Recent Activities
	Then I confirm the Recent Activities tab has loaded
	Then In the recent activities Page, I save all the Results to context as: RecentProductsGridResults1
	Then In the recent activities Page, In the Products table I select a random product and save the supplier name to context as: SavedProduct98355
	And In the recent activities Page, I click the More Filters Button
	And In the Product Lookup Page, The More Filters Popup is showing
	Then In the recent activities Page More Filters Popup, In the Supplier Name field, I enter: SavedProduct98355
	Then In the recent activities Page More Filters Popup, I Click the the Apply Filter Button
	Then In the recent activities Page, The More Filters Popup is not showing
	Then I confirm the Recent Activities page refreshes
	Then I confirm that the recent activities page bread crumb area contains the label: Supplier: "SavedProduct98355"
	And In the recent activities Page, In the Products table I confirm that all displayed results contain SavedProduct98355 in their Supplier name
	And In the recent activities Page, In the Products table I click the Reset Button
	And In the recent activities Page, I check the current results match the results saved as RecentProductsGridResults1
	Then I confirm that the recent activities page bread crumb area does not contain the label: Supplier: "SavedProduct98355"
	And In the recent activities Page, In the Products table I confirm that not all displayed results contain SavedProduct98355 in their Supplier name
	And I call Shared Step 106194 (RPS Sign out)





