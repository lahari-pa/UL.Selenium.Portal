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
