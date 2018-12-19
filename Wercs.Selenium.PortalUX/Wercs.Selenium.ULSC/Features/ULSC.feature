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

@run_ULSC

Feature: ULSC

Background:


Scenario: [33001] Navigation links - ULSC - Data Management
Given I Login into WERCSmart Portal - Admin Role - WERCs ULSC Account
Then the WERCSmart homepage should load
And I should see ULSC - Data Management in the navigation bar
Then I click the ULSC - Data Management icon in the QuickLinks Pane
And I switch to the tab: https://wps.thewercs.com/dbSplit/PROD/Wercs.SHA.MVCWebV1/ULSC/Studio?module=1
And UNDER DEVELOPMENT

Scenario: [32996] ULSC - Data Management - User does not have access to Studio

#need to figure out about passwords on different databases. Password is Welcome1! in Production.
Given I define the user: ULSCNoStudio with the following parameters:
| Field                | Value					 |
| Email                | 30259FM@sharklasers.com |
| Password             | T5$wbnsmsubhqn			 |

Given I login as user: ULSCNoStudio
Then the WERCSmart homepage should load
And I should see ULSC - Data Management in the navigation bar
Then I click the ULSC - Data Management icon in the QuickLinks Pane
And I switch to the tab: https://wps.thewercs.com/dbSplit/PROD/Wercs.SHA.MVCWebV1/ULSC/Studio?module=1
#need to create assert on an empty page
And UNDER DEVELOPMENT

Scenario: [23327] WERCSLink - WERCSmart - My Products Page Shows OK
Given I call Shared Step 29665 - Login to WSW as ULSC user
And I call Shared Step 29148 - Login to ULSC as an Administrator User
And I call Shared Step 53079 - WERCSLink go to Services - WERCSmart
And In the WERCSLink dashboard I click left menu link: My Products
And I Confirm the WerCSMart Product Information page is shown in new window/tab
And I Close the new window/tab that opened
And I In the WERCSLink page - Click the My Product link from the WERCSmart area of the Services page
And I Confirm the WERCSmart  Product Information page is shown in a new window
And I Close the new window/tab that opened






