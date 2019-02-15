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
And I Click the Additional Services link in the left hand navigation list
And I Confirm the Additional Services page is shown (this is still under development so we may need to add more steps for this page in the future)
And I Click the Key Performance Indicators list in the left hand navigation list
And I Confirm the Key Performance Indicator page is shown
And I Click the Recent Activities link in the left hand navigation list
And I Confirm the Recent Activities page is shown
And I Click the Product Lookup link in the left hand navigation list
And I Confirm the Product Lookup page is shown
And I Click the Services link in the left hand navigation list
And I Confirm the Services page is shown
And I Click the Services link again
And I Confirm you see links below the Services link for the following:WERCSmartSelf-Servicing AuthoringBranded MaterialsWERCS Studio
And I Click the WERCSmart link below the Services link in the left hand navigation pane
And I Confirm you see links below the WERCSmart link for the following items:My Products Register ProductSelf-Service AuthoringBranded MaterialsWERCS Studio
And I Click the Self-Service Authoring link in the left hand navigation list
And I Confirm you see links below the Self-Service Authoring link for the following items:Authoring
And I Click the Branded Materials link in the left hand navigation list
And I Confirm you see links below the Branded Materials link for the following items:Branded Materials
And I Click the WERCS Studio link in the left hand navigation list
And I Confirm you see links below the WERCS Studio link for the following items:Data ManagementReportsStudio HomeMappings
And I Scroll to the top of the left hand navigation list
And I Click the Dashboard link on the left hand navigation list
And I Confirm the Dashboard page is shown
