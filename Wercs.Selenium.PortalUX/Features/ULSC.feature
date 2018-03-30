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
@wercsmart

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





