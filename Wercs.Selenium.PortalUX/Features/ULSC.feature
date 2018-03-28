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

Background: Given I Login into WERCSmart Portal - Admin Role - WERCs ULSC Account


Scenario: [33001] Navigation links - ULSC - Data Management
Then the WERCSmart homepage should load
And I should see ULSC - Data Management in the navigation bar
Then I click the ULSC - Data Management icon in the QuickLinks Pane
And I switch to the tab: https://wps.thewercs.com/dbSplit/PROD/Wercs.SHA.MVCWebV1/ULSC/Studio?module=1
And UNDER DEVELOPMENT

