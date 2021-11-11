@RPS
@Login
@run_RecentActivites_MoreFilters
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

Feature: Recent Activities - More Filters

@ScenarioId:7014
Scenario: [104904] Base Functionality - Recent Activities  - More Filter pop up - confirm all fields are shown
Given I call Shared Step 104950 (RPS Login - Base functionality) for TReVor account: RPS.99
Then I confirm the Home tab has loaded
Given I click the tab: Recent Activities
Then I confirm the Recent Activities tab has loaded
And In the recent activities Page, I click the More Filters Button
Then In the recent activities Page, The More Filters Popup is showing
Then In the recent activities Page More Filters Popup, I check that the following filters fields exist:
| Filter                   |
| Supplier Name            |
| Retail Unique Identifier |
| Status                   |
| Start Date               |
| End Date                 |
And In the recent activities Page More Filters Popup, I check that the Cancel Button Exists
And In the recent activities Page More Filters Popup, I check that the Apply Filter Button Exists
Then In the recent activities Page More Filters Popup, I Click the the Cancel Button 
Then In the recent activities Page, The More Filters Popup is not showing
Then I confirm the Recent Activities tab has loaded

@ScenarioId:7047
Scenario: [70325] Base Functionality - Recent Activities - More Filters - Fields shown are correct type
Given I call Shared Step 104950 (RPS Login - Base functionality) for TReVor account: RPS.99
Then I confirm the Home tab has loaded
Given I click the tab: Recent Activities
Then I confirm the Recent Activities tab has loaded
And In the recent activities Page, I click the More Filters Button
Then In the recent activities Page, The More Filters Popup is showing
Then In the recent activities Page More Filters Popup, I check that the following filters fields exist:
| Filter                   |
| Supplier Name            |
| Retail Unique Identifier |
| Status                   |
| Start Date               |
| End Date                 |
Then In the recent activities Page More Filters Popup, I check that the: Supplier Name field is a text input field
Then In the recent activities Page More Filters Popup, I check that the: Retail Unique Identifier field is a text input field
Then In the recent activities Page More Filters Popup, I check that the: Status field is a drop down field
Then In the recent activities Page More Filters Popup, I check that the following status options exist:
| Option                   |
| Accepted                 |
| Assigned                 |
| Cancelled                |
| Completed                |
| Hold                     |
| New                      |
| Recertification          |
| Release for Distribution |
| Submitted                |    
| UPC Update               |
Then In the recent activities Page More Filters Popup, I click Start Date Input
Then In the recent activities Page More Filters Popup, I Check the calendar selector is Present
Then In the recent activities Page More Filters Popup, I click outside of the calendar selector
Then In the recent activities Page More Filters Popup, I Check the calendar selector is not Present
Then In the recent activities Page More Filters Popup, I click End Date Input
Then In the recent activities Page More Filters Popup, I Check the calendar selector is Present
Then In the recent activities Page More Filters Popup, I click outside of the calendar selector
Then In the recent activities Page More Filters Popup, I Check the calendar selector is not Present
Then In the recent activities Page More Filters Popup, I Click the the Cancel Button 
Then In the recent activities Page, The More Filters Popup is not showing
Then I confirm the Recent Activities tab has loaded
And I call Shared Step 106194 (RPS Sign out)

@ScenarioId:7049
Scenario: [104907] Base Functionality - Recent Activities  - More Filters - Supplier Name - partial search
Given I call Shared Step 104950 (RPS Login - Base functionality) for TReVor account: RPS.99
Then I confirm the Home tab has loaded
Given I click the tab: Recent Activities
Then I confirm the Recent Activities tab has loaded
Then In the recent activities page, I click the label 'Start Date'
Then I confirm the Recent Activities page refreshes
And In the recent activities Page, I click the More Filters Button
Then In the recent activities Page More Filters Popup, In the Supplier Name field, I enter: The Dial
Then In the recent activities Page More Filters Popup, I Click the the Apply Filter Button
Then In the recent activities Page, The More Filters Popup is not showing
Then I confirm the Recent Activities page refreshes
And In the recent activities Page, In the Products table I confirm that all displayed results contain The Dial in their Supplier name
Then I call Shared Step 106809 (Breadcrumbs - Supplier Name field - confirm shown correctly and remove) for text: The Dial
And In the recent activities Page, In the Products table I confirm that not all displayed results contain The Dial in their Supplier name
And I call Shared Step 106194 (RPS Sign out)

@ScenarioId:7053
Scenario: [106759] Base Functionality - Recent Activities  - More Filters - Supplier Name - exact match
#May need updating in the future to find and save random product details and use this supplier (make more filters popup search method less generic?)
Given I call Shared Step 104950 (RPS Login - Base functionality) for TReVor account: RPS.99
Then I confirm the Home tab has loaded
Given I click the tab: Recent Activities
Then I confirm the Recent Activities tab has loaded
Then In the recent activities page, I click the label 'Start Date'
Then I confirm the Recent Activities page refreshes
And In the recent activities Page, I click the More Filters Button
Then In the recent activities Page More Filters Popup, In the Supplier Name field, I enter: Tender Corporation
Then In the recent activities Page More Filters Popup, I Click the the Apply Filter Button
Then In the recent activities Page, The More Filters Popup is not showing
Then I confirm the Recent Activities page refreshes
And In the recent activities Page, In the Products table I confirm that all displayed results match the Supplier name Tender Corporation exactly
Then I call Shared Step 106809 (Breadcrumbs - Supplier Name field - confirm shown correctly and remove) for text: Tender Corporation
And In the recent activities Page, In the Products table I confirm that not all displayed results contain Tender Corporation in their Supplier name
And I call Shared Step 106194 (RPS Sign out)

#Scenario: [104908] Base Functionality - Recent Activities  - More Filters - Retailer Unique Identifier - No results for 99, CV, LW users
#Given I call Shared Step 65080 (Login to Studio and Open SHA manager)

@ScenarioId:7054
Scenario: [104909] Base Functionality - Recent Activities  - More Filters - Status - Accepted
Given I call Shared Step 104950 (RPS Login - Base functionality) for TReVor account: RPS.99
Then I confirm the Home tab has loaded
Given I click the tab: Recent Activities
Then I confirm the Recent Activities tab has loaded
Then In the recent activities page, I click the label 'Start Date'
Then I confirm the Recent Activities page refreshes
And In the recent activities Page, I click the More Filters Button
Then In the recent activities page, I select the option: Accepted from the status drop down menu
Then In the recent activities Page More Filters Popup, I Click the the Apply Filter Button
Then In the recent activities Page, The More Filters Popup is not showing
Then I confirm the Recent Activities page refreshes
Then In the recent activities Page, In the Products table I confirm that all displayed results show Accepted as their status
Then I call Shared Step 106777 (Breadcrumbs - Status Name field - confirm shown correctly and remove) for text: Accepted
Then In the recent activities Page, In the Products table I confirm that not all displayed results show Accepted as their status
And I call Shared Step 106194 (RPS Sign out)


@ScenarioId:7055
Scenario: [106781] Base Functionality - Recent Activities  - More Filters - Status - Assigned
Given I call Shared Step 104950 (RPS Login - Base functionality) for TReVor account: RPS.99
Then I confirm the Home tab has loaded
Given I click the tab: Recent Activities
Then I confirm the Recent Activities tab has loaded
Then In the recent activities page, I click the label 'Start Date'
Then I confirm the Recent Activities page refreshes
And In the recent activities Page, I click the More Filters Button
Then In the recent activities page, I select the option: Assigned from the status drop down menu
Then In the recent activities Page More Filters Popup, I Click the the Apply Filter Button
Then In the recent activities Page, The More Filters Popup is not showing
Then I confirm the Recent Activities page refreshes
Then In the recent activities Page, In the Products table I confirm that all displayed results show Assigned as their status
Then I call Shared Step 106777 (Breadcrumbs - Status Name field - confirm shown correctly and remove) for text: Assigned
Then In the recent activities Page, In the Products table I confirm that not all displayed results show Assigned as their status
And I call Shared Step 106194 (RPS Sign out)

@ScenarioId:7056
Scenario: [90161] Base Functionality - Recent Activities  - More Filters - Status - Cancelled
Given I call Shared Step 104950 (RPS Login - Base functionality) for TReVor account: RPS.99
Then I confirm the Home tab has loaded
Given I click the tab: Recent Activities
Then I confirm the Recent Activities tab has loaded
Then In the recent activities page, I click the label 'Start Date'
Then I confirm the Recent Activities page refreshes
And In the recent activities Page, I click the More Filters Button
Then In the recent activities page, I select the option: Cancelled from the status drop down menu
Then In the recent activities Page More Filters Popup, I Click the the Apply Filter Button
Then In the recent activities Page, The More Filters Popup is not showing
Then I confirm the Recent Activities page refreshes
Then In the recent activities Page, In the Products table I confirm that all displayed results show Cancelled as their status
Then I call Shared Step 106777 (Breadcrumbs - Status Name field - confirm shown correctly and remove) for text: Cancelled
Then In the recent activities Page, In the Products table I confirm that not all displayed results show Cancelled as their status
And I call Shared Step 106194 (RPS Sign out)

@ScenarioId:7057
Scenario: [90163] Base Functionality - Recent Activities  - More Filters - Status - Completed
Given I call Shared Step 104950 (RPS Login - Base functionality) for TReVor account: RPS.99
Then I confirm the Home tab has loaded
Given I click the tab: Recent Activities
Then I confirm the Recent Activities tab has loaded
Then In the recent activities page, I click the label 'Start Date'
Then I confirm the Recent Activities page refreshes
And In the recent activities Page, I click the More Filters Button
Then In the recent activities page, I select the option: Completed from the status drop down menu
Then In the recent activities Page More Filters Popup, I Click the the Apply Filter Button
Then In the recent activities Page, The More Filters Popup is not showing
Then I confirm the Recent Activities page refreshes
Then In the recent activities Page, In the Products table I confirm that all displayed results show Completed as their status
Then I call Shared Step 106777 (Breadcrumbs - Status Name field - confirm shown correctly and remove) for text: Completed
Then In the recent activities Page, In the Products table I confirm that not all displayed results show Completed as their status
And I call Shared Step 106194 (RPS Sign out)

@ScenarioId:7058
Scenario: [106789] Base Functionality - Recent Activities  - More Filters - Status - Submitted
Given I call Shared Step 104950 (RPS Login - Base functionality) for TReVor account: RPS.99
Then I confirm the Home tab has loaded
Given I click the tab: Recent Activities
Then I confirm the Recent Activities tab has loaded
Then In the recent activities page, I click the label 'Start Date'
Then I confirm the Recent Activities page refreshes
And In the recent activities Page, I click the More Filters Button
Then In the recent activities page, I select the option: Submitted from the status drop down menu
Then In the recent activities Page More Filters Popup, I Click the the Apply Filter Button
Then In the recent activities Page, The More Filters Popup is not showing
Then I confirm the Recent Activities page refreshes
Then In the recent activities Page, In the Products table I confirm that all displayed results show Submitted as their status
Then I call Shared Step 106777 (Breadcrumbs - Status Name field - confirm shown correctly and remove) for text: Submitted
Then In the recent activities Page, In the Products table I confirm that not all displayed results show Submitted as their status
And I call Shared Step 106194 (RPS Sign out)

@ScenarioId:7059
Scenario: [90147] Base Functionality - Recent Activities - More Filters - Start Date
Given I call Shared Step 104950 (RPS Login - Base functionality) for TReVor account: RPS.99
Then I confirm the Home tab has loaded
Given I click the tab: Recent Activities
Then I confirm the Recent Activities tab has loaded
And In the recent activities Page, I click the More Filters Button
Then In the recent activities Page, I confirm the Start Date input field shows a date 18 months before today as default
Then In the recent activities Page More Filters Popup, I click Start Date Input
Then In the recent activities Page More Filters Popup, I Check the calendar selector is Present
Then In the recent activities Page More Filters Popup, In the Start Date selector I select the date: 08/25/2019
Then In the recent activities Page More Filters Popup, I Check the calendar selector is not Present
Then In the recent activities Page More Filters Popup, I Click the the Apply Filter Button
Then In the recent activities Page, The More Filters Popup is not showing
Then I confirm the Recent Activities page refreshes
And In the Recent Activities page, I confirm that the main table shows data rows
Then I call Shared Step 107729 (Breadcrumbs - General shared step - confirm shown correctly and remove) for filter: Start Date and text: 08/25/2019
Then I confirm the Recent Activities page refreshes
Then In the recent activities Page, In the Products table I click the Reset Button
Then In the recent activities Page, I confirm the Start Date breadcrumb shows a date 6 months before today as default
And I call Shared Step 106194 (RPS Sign out)


@ScenarioId:7064
Scenario: [106758] Base Functionality - Recent Activities - More Filters - End Date
Given I call Shared Step 104950 (RPS Login - Base functionality) for TReVor account: RPS.99
Then I confirm the Home tab has loaded
Given I click the tab: Recent Activities
Then I confirm the Recent Activities tab has loaded
And In the recent activities Page, I click the More Filters Button
Then In the recent activities Page, I confirm the End Date input field shows todays date as default
Then In the recent activities Page More Filters Popup, I click End Date Input
Then In the recent activities Page More Filters Popup, I Check the calendar selector is Present
Then In the recent activities Page More Filters Popup, In the End Date selector I select the date: 08/25/2020
Then In the recent activities Page More Filters Popup, I Check the calendar selector is not Present
Then In the recent activities Page More Filters Popup, I Click the the Apply Filter Button
Then In the recent activities Page, The More Filters Popup is not showing
Then I confirm the Recent Activities page refreshes
And In the Recent Activities page, I confirm that the main table shows data rows
Then I call Shared Step 107729 (Breadcrumbs - General shared step - confirm shown correctly and remove) for filter: End Date and text: 08/25/2020
Then I confirm the Recent Activities page refreshes
Then In the recent activities Page, In the Products table I click the Reset Button
#Then In the recent activities Page, I confirm the End Date input field shows todays date as default
Then In the recent activities Page, I confirm the End Date breadcrumb shows todays date as default
And I call Shared Step 106194 (RPS Sign out)

@ScenarioId:7065
Scenario: [98448] More Filters - Enter key applies filters - Ticket is with DEV
Given I call Shared Step 104950 (RPS Login - Base functionality) for TReVor account: RPS.99
Then I confirm the Home tab has loaded
Given I click the tab: Recent Activities
Then I confirm the Recent Activities tab has loaded
Then I confirm the Recent Activities page refreshes
And In the recent activities Page, I click the More Filters Button
Then In the recent activities Page More Filters Popup, In the Supplier Name field, I enter: Tender Corporation
Then In the recent activities Page More Filters Popup, I click the Enter Key
Then I confirm that the recent activities page bread crumb area contains the label: Supplier: Tender Corporation

@tfs_design
@ScenarioId:7066
Scenario: [73168] Base Functionality - Recent Activities - More Filters - Supplier Name - Search for name with apostrophe
#Test needs fixing because this currently has an issue entering supplier name into the more filters page (apostrophe specific issue in automation?) ***
Given I call Shared Step 104950 (RPS Login - Base functionality) for TReVor account: RPS.99
Then I confirm the Home tab has loaded
Given I click the tab: Recent Activities
Then I confirm the Recent Activities tab has loaded
Then In the recent activities page, I click the label 'Start Date'
Then I confirm the Recent Activities page refreshes
Then In the recent activities Page, In the Products table I search for the product with Name: '
Then I confirm the Recent Activities tab has loaded
Then In the recent activities Page, In the Products table I select a random product with where the supplier contains: ' and save the supplier name to context as: SavedProduct98448
And In the recent activities Page, I click the More Filters Button
Then In the recent activities Page More Filters Popup, In the Supplier Name field, I enter: SavedProduct98448
Then In the recent activities Page More Filters Popup, I Click the the Apply Filter Button
Then In the recent activities Page, The More Filters Popup is not showing
Then I confirm the Recent Activities page refreshes
And In the recent activities Page, In the Products table I confirm that all displayed results contain SavedProduct98448 in their Supplier name
Then I call Shared Step 106809 (Breadcrumbs - Supplier Name field - confirm shown correctly and remove) for text: SavedProduct98448
And In the recent activities Page, In the Products table I confirm that not all displayed results contain SavedProduct98448 in their Supplier name
And I call Shared Step 106194 (RPS Sign out)

#Scenario: [90166] Base Functionality - Recent Activities - More Filters - Status - Hold
#Currently pausing automtion because goes to SHA and uses retailer (what use for 99?)
#Given I call Shared Step 104950 (RPS Login - Base functionality) for TReVor account: RPS.99
#Then I confirm the Home tab has loaded
#Given I click the tab: Recent Activities
#Then I confirm the Recent Activities tab has loaded
#Then In the recent activities page, I click the label 'Start Date'
#Then I confirm the Recent Activities page refreshes
#And In the recent activities Page, I click the More Filters Button

@ScenarioId:7086
Scenario: [106784] Base Functionality - Recent Activities - More Filters - Status - New 
Given I call Shared Step 104950 (RPS Login - Base functionality) for TReVor account: RPS.99
Then I confirm the Home tab has loaded
Given I click the tab: Recent Activities
Then I confirm the Recent Activities tab has loaded
Then In the recent activities page, I click the label 'Start Date'
Then I confirm the Recent Activities page refreshes
And In the recent activities Page, I click the More Filters Button
Then In the recent activities page, I select the option: New from the status drop down menu
Then In the recent activities Page More Filters Popup, I Click the the Apply Filter Button
Then In the recent activities Page, The More Filters Popup is not showing
Then I confirm the Recent Activities page refreshes
Then In the recent activities Page, In the Products table I confirm that all displayed results show New as their status
Then I call Shared Step 106777 (Breadcrumbs - Status Name field - confirm shown correctly and remove) for text: New
Then In the recent activities Page, In the Products table I confirm that not all displayed results show New as their status
And I call Shared Step 106194 (RPS Sign out)

@ScenarioId:7087
Scenario: [106785] Base Functionality - Recent Activities - More Filters - Status - Recertification
Given I call Shared Step 104950 (RPS Login - Base functionality) for TReVor account: RPS.99
Then I confirm the Home tab has loaded
Given I click the tab: Recent Activities
Then I confirm the Recent Activities tab has loaded
Then In the recent activities page, I click the label 'Start Date'
Then I confirm the Recent Activities page refreshes
And In the recent activities Page, I click the More Filters Button
Then In the recent activities page, I select the option: Recertification from the status drop down menu
Then In the recent activities Page More Filters Popup, I Click the the Apply Filter Button
Then In the recent activities Page, The More Filters Popup is not showing
Then I confirm the Recent Activities page refreshes
Then In the recent activities Page, In the Products table I confirm that all displayed results show Recertification as their status
Then I call Shared Step 106777 (Breadcrumbs - Status Name field - confirm shown correctly and remove) for text: Recertification
Then In the recent activities Page, In the Products table I confirm that not all displayed results show Recertification as their status
And I call Shared Step 106194 (RPS Sign out)

@ScenarioId:7088
Scenario: [106786] Base Functionality - Recent Activities - More Filters - Status - Release for Distribution
Given I call Shared Step 104950 (RPS Login - Base functionality) for TReVor account: RPS.99
Then I confirm the Home tab has loaded
Given I click the tab: Recent Activities
Then I confirm the Recent Activities tab has loaded
Then In the recent activities page, I click the label 'Start Date'
Then I confirm the Recent Activities page refreshes
And In the recent activities Page, I click the More Filters Button
Then In the recent activities page, I select the option: Release for Distribution from the status drop down menu
Then In the recent activities Page More Filters Popup, I Click the the Apply Filter Button
Then In the recent activities Page, The More Filters Popup is not showing
Then I confirm the Recent Activities page refreshes
Then In the recent activities Page, In the Products table I confirm that all displayed results show Release for Distribution as their status
Then I call Shared Step 106777 (Breadcrumbs - Status Name field - confirm shown correctly and remove) for text: Release for Distribution
Then In the recent activities Page, In the Products table I confirm that not all displayed results show Release for Distribution as their status
And I call Shared Step 106194 (RPS Sign out)

@ScenarioId:7089
Scenario: [106790] Base Functionality - Recent Activities - More Filters - Status - UPC Update
Given I call Shared Step 104950 (RPS Login - Base functionality) for TReVor account: RPS.99
Then I confirm the Home tab has loaded
Given I click the tab: Recent Activities
Then I confirm the Recent Activities tab has loaded
Then In the recent activities page, I click the label 'Start Date'
Then I confirm the Recent Activities page refreshes
And In the recent activities Page, I click the More Filters Button
Then In the recent activities page, I select the option: UPC Update from the status drop down menu
Then In the recent activities Page More Filters Popup, I Click the the Apply Filter Button
Then In the recent activities Page, The More Filters Popup is not showing
Then I confirm the Recent Activities page refreshes
Then In the recent activities Page, In the Products table I confirm that all displayed results show UPC Update as their status
Then I call Shared Step 106777 (Breadcrumbs - Status Name field - confirm shown correctly and remove) for text: UPC Update
Then In the recent activities Page, In the Products table I confirm that not all displayed results show UPC Update as their status
And I call Shared Step 106194 (RPS Sign out)
