@Login
@UlSolutionCenter
@Homepage
@ProductGrid
@ForwardProductRegistration
@NewProduct
@RetailPartners
@MessageCenter
@MyAccount
@LandingPage
@DocumentAcceptance
@DeleteActiveProducts
@ULSC
@run_ULCSDashboard

Feature: Dashboard

# Created by Barrett, Beverly
# Test case can be found at the following paths:
# NetProjects10\PowerUnity\2. WERCSLink - Dashboard
# NetProjects10\WercsSmart Portal\ULSC - UL Secure Connect\2. ULSC - Dashboard
Scenario: [52975] Layout
Given I call Shared Step 29665 - Login to WSW as ULSC user
And I call Shared Step 29148 - Login to ULSC as an Administrator User
And I should see the WERCSLink dashboard
And I Confirm the Layout shows a header, left hand navigation, Message center and KPI areas

Scenario: [52977] Header
Given I call Shared Step 29665 - Login to WSW as ULSC user
Given I call Shared Step 29148 - Login to ULSC as an Administrator User
Then I confirm that the WERCSLink header appears at the top left
And I confirm the WERCSLink sidebar menu icon is displayed
Given I click the WERCSLink sidebar menu icon
Then I confirm the left hand navigation list is collapsed
Given I click the WERCSLink sidebar menu icon
Then I confirm the left hand navigation list is expanded
And I confirm the user button in the header displays the logged in username
And I confirm the Reset Dashboard icon is displayed next to the user button in the header
Given I click the Reset Dashboard icon next to the user button in the header
Then I confirm the Reset Dashboard dropdown item is displayed underneath the header icon
Given I click the user button in the header
Then I confirm the Sign Out dropdown item is displayed
Given I click the user button in the header
Then I confirm the Sign Out dropdown item is not displayed
And I confirm the UL Logo is displayed next to the user button in the header
Given I click the UL Logo next to the user button in the header
Then I confirm a new tab opens with url: https://psi.ul.com/en/

# Created by Barrett, Beverly
# Test case can be found at the following paths:
# NetProjects10\PowerUnity\2. WERCSLink - Dashboard
# NetProjects10\WercsSmart Portal\ULSC - UL Secure Connect\2. ULSC - Dashboard
Scenario: [52987] Navigation pane
Given I call Shared Step 29665 - Login to WSW as ULSC user
Given I call Shared Step 29148 - Login to ULSC as an Administrator User
And I should see the WERCSLink dashboard
And I confirm that the following WERCSLink menu items are showing
| Menu item                  |
| Dashboard                  |
| Key Performance Indicators |
| Recent Activities          |
| Product Lookup             |
| Services                   |
And I click the side bar navigation link: Additional Services
And I confirm the WERCSLink Additional Services page loads
And I click the side bar navigation link: Key Performance Indicators
And I confirm the WERCSLink Key Performance Indicators page loads
And I click the side bar navigation link: Recent Activities
And I confirm the WERCSLink Recent Activities page loads
And I click the side bar navigation link: Product Lookup
And I confirm the WERCSLink Product Lookup page loads
And I click the side bar navigation link: Services
And I confirm the WERCSLink: Services page has loaded
And I click the side bar navigation link: Services
And I confirm the following sub links are displayed below the WERCSLink menu item: Services:
| Sub link |
| WERCSmart              |
| Self-Service Authoring |
| Branded Materials      |
| WERCS Studio           |
Given I click the link: WERCSmart below the WERCSLink menu item: Services
And I confirm the following links are displayed below menu item: Services and sub item WERCSmart
| Link             |
| My Products      |
| Register new product |
Given I click the link: Self-Service Authoring below the WERCSLink menu item: Services
And I confirm the following links are displayed below menu item: Services and sub item Self-Service Authoring
| Link      |
| Authoring |
Given I click the link: Branded Materials below the WERCSLink menu item: Services
And I confirm the following links are displayed below menu item: Services and sub item Branded Materials
| Link              |
| Branded Materials |
Given I click the link: WERCS Studio below the WERCSLink menu item: Services
And I confirm the following links are displayed below menu item: Services and sub item WERCS Studio
| Link            |
| Data Management |
| Reports         |
| Studio Home     |
| Mappings        |
And I click the side bar navigation link: Dashboard
And I should see the WERCSLink dashboard

# Created by Barrett, Beverly

# Test case can be found at the following paths:
# NetProjects10\PowerUnity\2. WERCSLink - Dashboard
# NetProjects10\WercsSmart Portal\ULSC - UL Secure Connect\2. ULSC - Dashboard

Scenario: [52993] Message Center - layout
Given I call Shared Step 29665 - Login to WSW as ULSC user
Given I call Shared Step 29148 - Login to ULSC as an Administrator User
And I confirm the WERCSLink: Dashboard page has loaded
And I confirm the following widget panels are displayed on the Dashboard page:
| Widget         |
| Message Center |
And I confirm that the drop down button with three dots is displayed for dashboard widget: Message Center
And I click the drop down button with three dots for dashboard widget: Message Center
And I confirm that the 'Remove' drop down item is displayed for widget: Message Center
And I click the drop down button with three dots for dashboard widget: Message Center
And I confirm that the 'Remove' drop down item is not displayed for widget: Message Center
#And I Confirm the "Enter WPS ID or Product Name" filter input is diplayed in the Message Center widget
And I Confirm the 'Enter WPS ID or Product Name' filter input is displayed in the Message Center widget
#And I If you are working with a brand new account you will not see anything below the "Enter WPS ID or Product name" field within the Message center area.
#And I If you are working with an older account, confirm you see entries below the "Enter WPS ID or Product Name" field
And I click the drop down button with three dots for dashboard widget: Message Center
And I click the 'Remove' drop down item for widget: Message Center
And I confirm the following widget panels are not displayed on the Dashboard page:
| Widget         |
| Message Center |
And I click the side bar navigation link: Dashboard
And I click the link: Reset Dashboard below the WERCSLink menu item: Dashboard
And I confirm the WERCSLink: Dashboard page has loaded
And I confirm the following widget panels are displayed on the Dashboard page:
| Widget         |
| Message Center |

# Created by Barrett, Beverly
# Test case can be found at the following paths:
# NetProjects10\PowerUnity\2. WERCSLink - Dashboard
# NetProjects10\WercsSmart Portal\ULSC - UL Secure Connect\2. ULSC - Dashboard
Scenario: [52995] KPIs - Defaults
Given I call Shared Step 29665 - Login to WSW as ULSC user
Given I call Shared Step 29148 - Login to ULSC as an Administrator User
And I Confirm the KPI area shows 6 preferred KPIs
And I Confirm the KPIs shown are :Products by Retailer and StatusRUs by CategoryProducts by Recertification ReasonProducts by RURUs by Category by RetailerSubscription Status
And I Confirm the Products by Retailer and Status shows as a pie chart
And I Confirm the RUs by Category shows as a pie chart
And I Confirm the Products by Recertification Reason shows as a bar graph
And I Confirm the Products by RU shows as a bar graph
And I Confirm the RUs by Category by Retailer shows as a pie chart
And I Confirm the Subscription status shows "Coming soon..."
