@RPS
@Login
@run_RecentActivites_Breadcrumbs
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

Feature: Recent Activities - Breadcrumbs


@ScenarioId:7090
Scenario: [73094] Base Functionality - Recent Activity - Breadcrumbs - Verify Options are the same
Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: RPS.99
Then I confirm the Home tab has loaded
Given I click the main tab: Recent Activities
Then I confirm the Recent Activities tab has loaded
Then I confirm the Recent Activities page refreshes
And In the recent activities Page, I click the More Filters Button
Then In the recent activities Page More Filters Popup, In the Supplier Name field, I enter: The Dial
Then In the recent activities page, I select the option: Assigned from the status drop down menu
Then In the recent activities Page More Filters Popup, I Click the the Apply Filter Button
Then In the recent activities Page, The More Filters Popup is not showing
Then I confirm the Recent Activities page refreshes
Then I confirm that the recent activities page bread crumb area contains the label: Supplier: "The Dial"
Then I confirm that the recent activities page bread crumb area contains the label: Status: "Assigned"
Given I click the main tab: Product Lookup
Then I confirm the Product Lookup tab has loaded
And I confirm the active tab is: Product Lookup
Then I confirm that the Product Lookup page buttons to the right of the search box are as follows:
| Buttons         |
| More Filters    |
| Reset           |
| Export to Excel |
| Select Columns  |
Then In the Product Lookup Page, I click the More Filters Button
And In the Product Lookup Page, The More Filters Popup is showing
Then In the Product Lookup Page More Filters Popup, I click the Supplier Name Filter
Then In the Product Lookup Page More Filters Popup, I select the parameter The Dial Corporation
Then In the Product Lookup Page More Filters Popup, I click the Physical state Filter
Then In the Product Lookup Page More Filters Popup, I select the parameter Cream
And In the Product Lookup Page More Filters Popup, I Click the the OK Button
Then In the Product Lookup Page, The More Filters Popup is not showing
Then I confirm that the Lookup Page bread crumb area contains the label: Supplier: "The Dial Corporation"
Then I confirm that the Lookup Page bread crumb area contains the label: Physical state: "Cream"
And I call Shared Step 106194 (RPS Sign out)


@ScenarioId:7117
Scenario: [105035] Base Functionality - Recent Activities - default date range
Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: RPS.99
Then I confirm the Home tab has loaded
Given I click the main tab: Recent Activities
Then I confirm the Recent Activities tab has loaded
And I confirm that the recent activities page shows the bread crumb area
Then In the recent activities Page, I confirm the Start Date breadcrumb shows a date 6 months before today as default
And In the recent activities Page, I confirm the End Date breadcrumb shows todays date as default
And I call Shared Step 106194 (RPS Sign out)


@ScenarioId:7119
Scenario: [105018] Base Functionality - Recent Activities - Breadcrumbs
Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: Franky TG User
Then I confirm the Home tab has loaded
Given I click the main tab: Recent Activities
Then I confirm the Recent Activities tab has loaded
Then In the recent activities Page, In the Products table I select a random product and save the supplier name to context as: SavedProduct105018
And In the recent activities Page, I click the More Filters Button
Then In the recent activities Page More Filters Popup, In the Supplier Name field, I enter: SavedProduct105018
Then In the recent activities page, I select the option: New from the status drop down menu
Then In the recent activities Page More Filters Popup, I Click the the Apply Filter Button
Then In the recent activities Page, The More Filters Popup is not showing
Then I confirm the Recent Activities page refreshes
Then I confirm that the recent activities page bread crumb area contains the label: Supplier: "SavedProduct105018"
Then I confirm that the recent activities page bread crumb area contains the label: Status: "New"
Then In the recent activities Page, I confirm the Start Date breadcrumb shows a date 6 months before today as default
And In the recent activities Page, I confirm the End Date breadcrumb shows todays date as default
And I call Shared Step 106194 (RPS Sign out)

@ScenarioId:8099
Scenario: [106837] Base Functionality - Recent Activities - Breadcrumbs - Reset
Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: RPS.99
Then I confirm the Home tab has loaded
Given I click the main tab: Recent Activities
Then I confirm the Recent Activities tab has loaded
Then In the recent activities Page, In the Products table I select the first product and save the supplier name to context as: SavedProductSupplier106837a
And In the recent activities Page, In the Products table I select the first product and save the status to context as: SavedProductStatus106837a
And In the recent activities Page, I click the More Filters Button
And In the Product Lookup Page, The More Filters Popup is showing
Then In the recent activities Page More Filters Popup, In the Supplier Name field, I enter: SavedProductSupplier106837a
Then In the recent activities page, I select the option: SavedProductStatus106837a from the status drop down menu
Then In the recent activities Page More Filters Popup, I Click the the Apply Filter Button
Then In the recent activities Page, The More Filters Popup is not showing
Then I confirm the Recent Activities page refreshes
And I confirm that the recent activities page shows the bread crumb area
And In the Recent Activities page, I confirm that the main table shows data rows
And In the recent activities Page, In the Products table I confirm that all displayed results contain SavedProductSupplier106837a in their Supplier name
Then In the recent activities Page, In the Products table I confirm that all displayed results show SavedProductStatus106837a as their status
Then I confirm that the recent activities page bread crumb area contains the label: Supplier: "SavedProductSupplier106837a"
Then I confirm that the recent activities page bread crumb area contains the label: Status: "SavedProductStatus106837a"
Then I confirm that the recent activities page bread crumb area contains the label: Reset
Then In the recent activities Page, In the Products table I click the Reset Breadcrumb
Then In the recent activities Page, In the Products table Breadcrumb area only Start Date and End Date labels are shown
And In the recent activities Page, In the Products table I confirm that not all displayed results contain SavedProductSupplier106837a in their Supplier name
Then In the recent activities Page, In the Products table I select the second product and save the supplier name to context as: SavedProductSupplier106837b
And In the recent activities Page, In the Products table I select the second product and save the status to context as: SavedProductStatus106837b
And In the recent activities Page, I click the More Filters Button
And In the Product Lookup Page, The More Filters Popup is showing
Then In the recent activities Page More Filters Popup, In the Supplier Name field, I enter part of: SavedProductSupplier106837b and save the partial text as: SavedProductSupplier106837bPartial
Then In the recent activities page, I select the option: SavedProductStatus106837b from the status drop down menu
Then In the recent activities Page More Filters Popup, I Click the the Apply Filter Button
Then In the recent activities Page, The More Filters Popup is not showing
Then I confirm the Recent Activities page refreshes
And I confirm that the recent activities page shows the bread crumb area
And In the Recent Activities page, I confirm that the main table shows data rows
Then I confirm that the recent activities page bread crumb area contains the label: Supplier: "SavedProductSupplier106837bPartial"
Then I confirm that the recent activities page bread crumb area contains the label: Status: "SavedProductStatus106837b"
Then In the recent activities Page, In the Products table I click the Reset Breadcrumb
And In the recent activities Page, In the Products table I confirm that not all displayed results contain SavedProductSupplier106837bPartial in their Supplier name
Then In the recent activities Page, In the Products table Breadcrumb area only Start Date and End Date labels are shown
And I call Shared Step 106194 (RPS Sign out)


@ScenarioId:8108
Scenario: [98355] Base Functionality - Recent Activities - Reset button in breadcrumb area clears Supplier name
Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: RPS.99
Then I confirm the Home tab has loaded
Given I click the main tab: Recent Activities
Then I confirm the Recent Activities tab has loaded
Then In the recent activities Page, In the Products table I select a random product and save the supplier name to context as: SavedProduct98355
And In the recent activities Page, I click the More Filters Button
And In the Product Lookup Page, The More Filters Popup is showing
Then In the recent activities Page More Filters Popup, In the Supplier Name field, I enter: SavedProduct98355
Then In the recent activities Page More Filters Popup, I Click the the Apply Filter Button
Then In the recent activities Page, The More Filters Popup is not showing
Then I confirm the Recent Activities page refreshes
Then I confirm that the recent activities page bread crumb area contains the label: Supplier: "SavedProduct98355"
And In the recent activities Page, In the Products table I confirm that all displayed results contain SavedProduct98355 in their Supplier name
Then In the recent activities Page, In the Products table I click the Reset Breadcrumb
Then I confirm that the recent activities page bread crumb area does not contain the label: Supplier: "SavedProduct98355"
And In the recent activities Page, In the Products table I confirm that not all displayed results contain SavedProduct98355 in their Supplier name
And I call Shared Step 106194 (RPS Sign out)


Scenario: [169166] Recent Activities - Breadcrumbs - multiple selection and reset
Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: Franky TG User
Then I confirm the Home tab has loaded
Given I click the main tab: Recent Activities
Then I confirm the Recent Activities tab has loaded
Then In the recent activities page, I take note of the number of products in the footer area and save as: ProductAmount169166
Given I call Shared Step 146428 (RPS & WV > More Filters > Select Multiple (for Status viewer & Recent Activities)
Then In the recent activities Page, In the Products table I click the Reset Button
Given In the recent activites page, I check if the number of products in the footer area matches amount saved as: ProductAmount169166
And I call Shared Step 106194 (RPS Sign out)





