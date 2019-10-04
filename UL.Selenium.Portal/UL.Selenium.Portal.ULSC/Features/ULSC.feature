@Shared
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
@Portal_ULSC
@ULSC

@run_ULSC

Feature: ULSC

Background:

@33001
#The ULSC Account does not seem to be successfully linked
@TReVorId:22178
Scenario: [33001] Navigation links - ULSC - Data Management
Given I navigate to WERCSmart
Given I Login into WERCSmart Portal - Admin Role - WERCs ULSC Account
Then the WERCSmart homepage should load
And I should see ULSC - Data Management in the navigation bar
Then I click the ULSC - Data Management icon in the QuickLinks Pane
And I Confirm New window opens with the Studio Data Management window open (Welcome page shows) and that NO script errors display
#And I Confirm that the URL shown is the Studio site registered to the Supplier that this user is linked to.
#And I Click Continue (to close the welcome dialog)
And I close the tab with the Data Management page

@32996
@TReVorId:22177
Scenario: [32996] ULSC - Data Management - User does not have access to Studio
Given I navigate to WERCSmart
Given I Login into WERCSmart Portal - Admin Role - WERCs ULSC Account
Then the WERCSmart homepage should load
And I should see ULSC - Data Management in the navigation bar
Then I click the ULSC - Data Management icon in the QuickLinks Pane
And I Confirm New window opens with the error message: Your WERCSmart email address has either not been configured or licensed to access ULSC. Please contact your ULSC representative to learn more.


@TReVorId:22176
Scenario: [23327] WERCSLink - WERCSmart - My Products Page Shows OK
Given I call Shared Step 29665 - Login to WSW as ULSC user
And I call Shared Step 29148 - Login to ULSC as an Administrator User
And I call Shared Step 53079 - WERCSLink go to Services - WERCSmart
#And In the WERCSLink dashboard I click left menu link: My Products
And I click the link: My Products below menu item: Services and sub item WERCSmart
And I Confirm the WerCSMart Product Information page is shown in new window/tab
And I close the tab with the Product Information page
Given I navigate to tab with title: Services
And In the WERCSLink page - Click the My Product link from the WERCSmart area of the Services page
And I Confirm the WerCSMart Product Information page is shown in new window/tab
And I close the tab with the Product Information page
