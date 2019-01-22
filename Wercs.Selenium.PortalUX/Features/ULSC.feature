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
@ULSC

@run_ULSC

Feature: ULSC

Background:


# Created by Beverly Barrett

# Test case can be found at the following paths:
# NetProjects10\PowerUnity\3. ULSC - Portal\3.1 ULSC Menu
# NetProjects10\WercsSmart Portal\ULSC - UL Secure Connect\3. ULSC - Portal\3.1 ULSC Navigation item

#UNDER CONSTRUCTION
Scenario: [33001] Portal - Navigation links - ULSC - Data Management - User is registered in ULSC
#In the shared step below login to Portal as a user who is linked to a ULSC Supplier who is registered in the ULSC Studio database
And I call Shared Step 67038 (Login into WERCSmart Portal - ULSC Role)
Then the WERCSmart homepage should load
And I should see ULSC - Data Management in the navigation bar
Then I click the ULSC - Data Management icon in the QuickLinks Pane
And I Confirm that a new tab opens
And I Confirm that the WERCS Studio "Data Management Welcome" page/pop up is shown and that NO script errors display
And I Confirm that the URL shown is the Studio site registered to the Supplier that this user is linked to.
And I Click Continue (to close the welcome dialog)
And I Close the tab/window that opened

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







