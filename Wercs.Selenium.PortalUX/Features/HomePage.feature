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

@run_Homepage

Feature: Home Page

Background:


Scenario: [55796] Navigate to Home Page
Given I Login into WERCSmart Portal - Admin Role - WERCs Visual Account
Then the WERCSmart homepage should load
Then I should see the UL/WERCSmart Logo in the header bar
And I should see the User Icon in the header bar
# And I should see the Supplier Name Dropdown in the header bar
Then I click the User Icon
And I should see My Account in the user dropdown
And I should see Sign Out in the user dropdown
Then I should see the Navigation Menu Icon in the navigation bar
Then I expand the Navigation Menu

And the following icons and labels should be found in the navigation bar
| Item                 |
| Home                 |
| Register New Product |
| My Messages          |
| Retail Partners      |
| Supplier Reports     |
| UL Solution Center   |
| Shopping Cart        |
| Support              |

Then I collapse the Navigation Menu

And the following icons should be found in the navigation bar
| Item                 |
| Home                 |
| Register New Product |
| My Messages          |
| Retail Partners      |
| Supplier Reports     |
| UL Solution Center   |
| Shopping Cart        |
| Support              |

Then I click on the triangle next to Product Information to collapse the section
And I scroll to the top of the page
And I should see the Subheading Product Information in the main window
And I should see the Subheading Alerts in the main window
And I should see the Subheading Announcements in the main window
And I should see the Subheading My Products in the products grid
Then I click on the triangle next to Product Information to expand the section

And I should see the Subheading Product Information expanded in the main window
And I should see the Subheading Alerts expanded in the main window
And I should see the Subheading Announcements expanded in the main window



Scenario: [55817] Product Information Panel - No Alerts/No Products
Given I Login into WERCSmart Portal - Admin Role - WERCs Visual Account
Then the WERCSmart homepage should load
When I click on the triangle next to Product Information to collapse the section
Then the Product Information dialog should be hidden
And the Alerts dialog should be hidden
And the Announcements dialog should be hidden

When I click on the triangle next to Product Information to expand the section
Then the Product Information dialog should be visible
And the Alerts dialog should be visible
And the Announcements dialog should be visible

And I should see a Pie Chart and Legend under Product Information
And I should see the following states in the Legend:
| State             | Colour |
| Not Yet Submitted | Grey   |
| Assessment in Progress | Yellow |
| Sending to Retailers   | Blue   |
| Accepted by Retailers  | Green  |
| Needs Your Attention   | Red    |

Given I see notifications in the Announcement Panel


Scenario: [55938] My Products grid
Given I Login into WERCSmart Portal - Admin Role - WERCs Visual Account
Then the WERCSmart homepage should load
Given I should see the following filter options below My Products
| Options                | Colour       |
| All                    | Light Purple |
| Not Yet Submitted      | Dark Grey    |
| Assessment in Progress | Yellow       |
| Sending to Retailers   | Blue         |
| Accepted by Retailers  | Green        |
| Needs Your Attention   | Red          |
| Canceled               |              |

And I should see an option for More Filters
And I should see an option for Product ID/Name
And I should see an option for Bulk Actions

And the Product Grid should have the following headers:
| Header            |
| ID / Product Name |
| Date Created      |
| Retailers         |
| Actions           |


Scenario: [56020] Bulk Actions
Given I Login into WERCSmart Portal - Admin Role - WERCs Visual Account
Then the WERCSmart homepage should load
Given I click Bulk Actions in the Products Grid
Then I should see a popup with header Bulk Actions
And I should see the following options available in the Bulk Actions window
| Options                      |
| Forward Product Registration |
| Accept Documents             |
| Delete Products              |
And I click on the close button on Bulk Actions
Then I should see the Subheading My Products in the products grid

Scenario: [56149] Click Register Product button from home page - Navigation
Given I Login into WERCSmart Portal - Admin Role - WERCs Visual Account
Then the WERCSmart homepage should load
Then I click the Register New Product icon in the QuickLinks Pane
And I should see the header New Product
And I should see the statement Select the type of product to create:
And I should see the radio button: Create a New Registration
And I should see the radio button: Copy from an Existing Registration

Scenario: [56158] Retail Partners navigation No Products
Given I Login into WERCSmart Portal - Admin Role - WERCs Visual Account
Then the WERCSmart homepage should load
Then I click the Retail Partners icon in the Navigation Pane
Then I should see the following heading Retail Partners
And I should see the following subheading All Retailers
And I should not see the following subheading Most Recent Retailers


Scenario: [56161] UL Solution Center navigation
Given I Login into WERCSmart Portal - Admin Role - WERCs Visual Account
Then the WERCSmart homepage should load
Then I click the UL Solution Center icon in the Navigation Pane
Then I should see the following option ECOLogo
Then I should see the following option Prospector
Then I should see the following option GoodGuide for Consumers
Then I should see the following option GoodGuide for Suppliers
Then I should see the following option UL Secure Connect (ULSC)
Then I should see the following option ULGHS

Scenario: [56163] Left hand navigation - Shopping Cart - No Products
Given I Login into WERCSmart Portal - Admin Role - WERCs Visual Account
Then the WERCSmart homepage should load
Then I click the Shopping Cart icon in the Navigation Pane
And UNDER DEVELOPMENT

#This test cases uses the ULSC account
Scenario: [56170] WERCSLink button navigation
Given I Login into WERCSmart Portal - Admin Role - WERCs ULSC Account
Then the WERCSmart homepage should load
Then I click the WERCSLink icon in the QuickLinks Pane
And UNDER DEVELOPMENT

Scenario: [56188] Support navigation
Given I Login into WERCSmart Portal - Admin Role - WERCs Visual Account
Then the WERCSmart homepage should load
Then I click the Support icon in the Navigation Pane
And I switch to the tab: https://wercsmart.freshdesk.com/en/support/solutions
And UNDER DEVELOPMENT


Scenario: [56206] Sign Out
Given I Login into WERCSmart Portal - Admin Role - WERCs Visual Account
Then the WERCSmart homepage should load
Then I click the User Icon
And I click on Sign Out
And the landing page should load

Scenario: [56212] My Products grid Actions - Edit Navigation
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then the WERCSmart homepage should load
When I filter the products by: Not Yet Submitted
Given I save the ProductID and Name of the first Product in the grid as: FirstProduct
When I click Row Actions for the most recent product returned
Then I click on the Row Action: Edit
Then the Product Type page should be loaded
And the product saved as: FirstProduct should be visible in editor

Scenario: [56214] My Products grid Actions - Submit Navigation
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then the WERCSmart homepage should load
When I filter the products by: Not Yet Submitted
Given I save the ProductID and Name of the first Product in the grid as: FirstProduct
When I click Row Actions for the most recent product returned
Then I click on the Row Action: Submit
And UNDER DEVELOPMENT

Scenario: [56216] My Products grid Actions - Delete Navigation
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then the WERCSmart homepage should load
Then I click the Register New Product icon in the Navigation Pane
And the Product Editor page should be loaded
Then I create a shell product with name TestProduct saved as TestProduct
Then I navigate to the home page
Given I search for the product saved as: TestProduct
When I click Row Actions for the most recent product returned
Then I click on the Row Action: Delete
And I cancel the Delete Dialog
Then I should see products in the Product Grid
When I click Row Actions for the most recent product returned
Then I click on the Row Action: Delete
And I confirm the Delete Dialog
Then I should not see products in the Product Grid
And UNDER DEVELOPMENT

Scenario: [56218] My Products grid Actions - View Navigation
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then the WERCSmart homepage should load
When I filter the products by: Assessment in Progress
And I click Row Actions for the most recent product returned
Then I click on the Row Action: View
And UNDER DEVELOPMENT

Scenario: [56219] My Products grid Actions - Documents navigation
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then the WERCSmart homepage should load
When I filter the products by: Assessment in Progress
And I click Row Actions for the most recent product returned
Then I click on the Row Action: Documents
And UNDER DEVELOPMENT

Scenario: [56220] My Products grid Actions - Edit UPCs
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then the WERCSmart homepage should load
When I filter the products by: Sending to Retailers
Given I save the ProductID and Name of the first Product in the grid as: FirstProduct
And I click Row Actions for the most recent product returned
Then I click on the Row Action: UPC Update
And UNDER DEVELOPMENT

Scenario: [56223] Bulk Actions - Forward Product Registration navigation
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then the WERCSmart homepage should load
Given I click Bulk Actions in the Products Grid
And I click Forward Product Registration in the Bulk Actions window
Then I should see the header: Forward Product Registration on the Forward Product Registration window
And I should see the subheading 3: Select Retailers on the Forward Product Registration window
And I should see the subheading 4: You most recently did business with... on the Forward Product Registration window


#This test cases uses the ULSC account
Scenario: [56224] Bulk Actions - Sync Products to WERCSLink navigation
Given I Login into WERCSmart Portal - Admin Role - WERCs ULSC Account
Then the WERCSmart homepage should load
Given I click Bulk Actions in the Products Grid
And I click Sync Products in the Bulk Actions window
And I should see the header: Sync Products to ULSC on the Sync Products to ULSC window
Then I click on the cancel button on the ULSC Sync popup
And I should see the Subheading Alerts in the main window

Scenario: [56225] Bulk Actions - Accept Documents navigation
Given I Login into WERCSmart Portal - Admin Role - WERCs Visual Account
Then the WERCSmart homepage should load
Given I click Bulk Actions in the Products Grid
And I click Accept Documents in the Bulk Actions window
And I should see the header: Document Acceptance on the Document Acceptance window


Scenario: [56227] Bulk Actions - Delete Products navigation
Given I Login into WERCSmart Portal - Admin Role - WERCs Visual Account
Then the WERCSmart homepage should load
Given I click Bulk Actions in the Products Grid
And I click Delete Products in the Bulk Actions window
And I should see the header: Delete Active Products on the Delete Active Product window

Scenario: [56280] Product Information - Alerts - click on any notification
Then clicking on the top Alert should direct me to the My Messages page
And UNDER DEVELOPMENT

Scenario: [56281] Product Information - Alerts - click More
Given I Login into WERCSmart Portal - Admin Role - WERCs Visual Account
Then the WERCSmart homepage should load
Then I click More below the Alerts Panel
And I should see the header: Message Center on the Message Center window


