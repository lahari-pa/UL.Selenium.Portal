@wercsmart
@run_Homepage

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
@Solutions
@ReviewDocuments
@SHA


Feature: Home Page


#pass staging 4.10
Scenario: [55796] Navigate to Home Page
Given I Login into WERCSmart Portal - Admin Role - WERCs Visual Account
Then the WERCSmart homepage should load

# Check correct items are showing in header bar
Then I should see the UL/WERCSmart Logo in the header bar
And I should see the User Icon in the header bar

# Check correct items are showing in the User dropdown menu
Then I click the User Icon
And I should see My Account in the user dropdown
And I should see Sign Out in the user dropdown

# Checking that the navigation bar is showing
Then I should see the Navigation Menu Icon in the navigation bar

# Expands the navigation bar and checks that the correct icons and labels are showing
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

# Collapses the navigation bar and checks that only the icons are displayed on the screen (not the labels!)
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

# Checks that the top menu can be collapsed successfully
Then I click on the triangle next to Product Information to collapse the section
And I scroll to the top of the page
And I should see the Subheading Product Information in the main window
And I should see the Subheading Alerts in the main window
And I should see the Subheading Announcements in the main window
And I should see the Subheading My Products in the products grid

# Checks that the correct items are showing when the section is expanded
Then I click on the triangle next to Product Information to expand the section
And I should see the Subheading Product Information expanded in the main window
And I should see the Subheading Alerts expanded in the main window
And I should see the Subheading Announcements expanded in the main window

#pass - staging 4.10
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
| State                  | Colour |
| Not Yet Submitted      | Grey   |
| Assessment in Progress | Yellow |
| Sending to Retailers   | Blue   |
| Accepted by Retailers  | Green  |
| Needs Your Attention   | Red    |

Given I see notifications in the Announcement Panel

#pass
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

#pass - staging 4.10
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

#pass - staging 4.10
Scenario: [56149] Click Register Product button from home page - Navigation
Given I Login into WERCSmart Portal - Admin Role - WERCs Visual Account
Then the WERCSmart homepage should load
Then I click the Register New Product icon in the QuickLinks Pane
And I should see the header New Product
And I should see the statement Select the type of product to create:
And I should see the radio button: Create a New Registration
And I should see the radio button: Copy from an Existing Registration

#pass - staging 4.10
Scenario: [56158] Retail Partners navigation No Products
Given I Login into WERCSmart Portal - Admin Role - WERCs Visual Account
Then the WERCSmart homepage should load
Then I click the Retail Partners icon in the Navigation Pane
Then I should see the following heading Retail Partners
And I should see the following subheading All Retailers
And I should not see the following subheading Most Recent Retailers

#pass - staging 4.10
Scenario: [56161] UL Solution Center navigation
Given I Login into WERCSmart Portal - Admin Role - WERCs Visual Account
Then the WERCSmart homepage should load
Then I click the UL Solution Center icon in the Navigation Pane
Then Confirm that you are taken to the UL Solution Center page
Then Confirm in the UL Solution Center page you see sections for:
| Sections                 |
| ECOLOGO                  |
| Prospector               |
| GoodGuide for Consumers  |
| GoodGuide for Suppliers  |
| UL Secure Connect (ULSC) |
| ULGHS                    |

#pass - staging 4.10
Scenario: [56163] Left hand navigation - Shopping Cart - No Products
Given I Login into WERCSmart Portal - Admin Role - WERCs Visual Account
Then the WERCSmart homepage should load
Then I click the Shopping Cart icon in the Navigation Pane
And I should see the header: Cart is Empty on the Cart is Empty window
And I click on the close button on Cart is Empty
Then I should see the Subheading Announcements in the main window

#pass - staging 4.10 (might need to look at freshdesk link
Scenario: [56188] Support navigation
Given I Login into WERCSmart Portal - Admin Role - WERCs Visual Account
Then the WERCSmart homepage should load
Then I click the Support icon in the Navigation Pane
Then Confirm that freshdesk opens in another tab

#pass - staging 4.10
Scenario: [56206] Sign Out
Given I Login into WERCSmart Portal - Admin Role - WERCs Visual Account
Then the WERCSmart homepage should load
Then I click the User Icon
And I click on Sign Out
And the landing page should load

#pass - staging 4.10
Scenario: [56212] My Products grid Actions - Edit Navigation
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then the WERCSmart homepage should load
When I filter the products by: Not Yet Submitted
Given I save the ProductID and Name of the first Product in the grid as: FirstProduct
When I click Row Actions for the most recent product returned
Then I click on the Row Action: Edit
Then the Product Type page should be loaded
And the product saved as: FirstProduct should be visible in editor

#Design
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
Given I save the number of items in the pie chart
When I click Row Actions for the most recent product returned
Then I click on the Row Action: Delete
And I confirm the Delete Dialog
Then I should not see products in the Product Grid
Then the number of items in the pie chart should be one less than the figure I saved

Scenario: [56218] My Products grid Actions - View Navigation
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then the WERCSmart homepage should load
When I filter the products by: Assessment in Progress
And I click Row Actions for the most recent product returned
Then I click on the Row Action: View
Then A Summary page should open in a new browser tab
Then I should not seen an Accept button
Given I close the browser tab with the Summary page



Scenario: [56219] My Products grid Actions - Documents navigation
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then the WERCSmart homepage should load
When I filter the products by: Assessment in Progress
And I click Row Actions for the most recent product returned
Then I click on the Row Action: Documents
And I should see Review Documents
Then In the Documents section I should see the following columns: Document Name, Subformat, Language, Actions
Given I click on the View link of the first document in Supplier Uploaded
Then a document should open
Given I close the document


#Design
Scenario: [56220] My Products grid Actions - Edit UPCs
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then the WERCSmart homepage should load
When I filter the products by: Sending to Retailers
Given I save the ProductID and Name of the first Product in the grid as: FirstProduct
And I click Row Actions for the most recent product returned
Then I click on the Row Action: UPC Update
And UNDER DEVELOPMENT

#pass - staging 4.10
Scenario: [56223] Bulk Actions - Forward Product Registration navigation
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then the WERCSmart homepage should load
Given I click Bulk Actions in the Products Grid
And I click Forward Product Registration in the Bulk Actions window
Then I should see the header: Forward Product Registration on the Forward Product Registration window
And I should see the subheading 3: Select Products & UPCs on the Forward Product Registration window

#pass - staging 4.10
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

Scenario: [56227] Bulk Actions  Delete Products navigation
Given I Login into WERCSmart Portal - Admin Role - WERCs Visual Account
Then the WERCSmart homepage should load
Given I click Bulk Actions in the Products Grid
And I click Delete Products in the Bulk Actions window
And I should see the header: Delete Active Products on the Delete Active Product window

Scenario: [56280] Document is created and is ready for review
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then clicking on the top Alert should direct me to the My Messages page
And UNDER DEVELOPMENT

Scenario: [56281] Product Information - Alerts - click More
Given I Login into WERCSmart Portal - Admin Role - WERCs Visual Account
Then the WERCSmart homepage should load
Then I click More below the Alerts Panel
And I should see the header: Message Center on the Message Center window

Scenario: [64854] Navigation Settings

# Sign in and expand the menu, checking the correct items are showing
Given I Login into WERCSmart Portal - Admin Role - WERCs Visual Account
Then I expand the Navigation Menu
And the Navigation Menu should be expanded
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
And I click on Sign Out

# Sign back in with same account
Given I Login into WERCSmart Portal - Admin Role - WERCs Visual Account
And the Navigation Menu should be expanded
Given I click on My Account
And the Navigation Menu should be expanded
Then I collapse the Navigation Menu
And I click on Sign Out

# Sign back in a third time
Given I Login into WERCSmart Portal - Admin Role - WERCs Visual Account
And the Navigation Menu should be collapsed
Given I click on My Account
And the Navigation Menu should be collapsed

Scenario: [64872] Pie Panel Settings

Given I Login into WERCSmart Portal - Admin Role - WERCs Visual Account
When I click on the triangle next to Product Information to expand the section
And I should see a Pie Chart and Legend under Product Information
And I should see the following states in the Legend:
| State                  | Colour |
| Not Yet Submitted      | Grey   |
| Assessment in Progress | Yellow |
| Sending to Retailers   | Blue   |
| Accepted by Retailers  | Green  |
| Needs Your Attention   | Red    |
And I should see the Subheading Alerts in the main window
# The below checks for both the dialog and the 'More...' button
And the Alerts dialog should be visible
And I should see the Subheading Announcements in the main window
And the Announcements dialog should be visible
And I click on Sign Out
Given I Login into WERCSmart Portal - Admin Role - WERCs Visual Account
And I should see a Pie Chart and Legend under Product Information

# Collapse the section

When I click on the triangle next to Product Information to collapse the section
And I should not see a Pie Chart and Legend under Product Information
And the Alerts dialog should be hidden
And the Announcements dialog should be hidden

# Then expand the section

When I click on the triangle next to Product Information to expand the section
And I should see a Pie Chart and Legend under Product Information
And I should see the Subheading Alerts in the main window
And the Alerts dialog should be visible
And I should see the Subheading Announcements in the main window
And the Announcements dialog should be visible

Scenario: [67299] Terms of Use - footer

Given I Login into WERCSmart Portal - Admin Role - WERCs Visual Account

Then The home screen should load

Given I click the Terms of Use link in the footer

Given I confirm the WERCSmart Terms of Use page opened in a new tab and navigate to it

And I close the window that opened

Scenario: [65886] My Products - Pagination

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

Then The current page in the products grid is: 1

Given I click next in the products grid

Then The current page in the products grid is: 2

Given I click previous in the products grid

Then The current page in the products grid is: 1

Given I click ... in the products grid

Then I should see the products grid navigation input with up and down arrows

Given I type the number 15 into the products grid page navigation box and press the enter key

Then The current page in the products grid is: 15

Given I click ... in the products grid

Given I enter the up arrow into the products grid page navigation input then the correct page is shown

Given I click ... in the products grid

Given I enter the down arrow into the products grid page navigation input then the correct page is shown

# NB this test requires pre set up products with a Brand/ Product Line added in the 'The Product' section
Scenario: [68388] More Filters - Brand
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load
And I should see an option for More Filters
Given I click More Filters in the products grid
Given I select the SuperBrand(TM) option in the Brand More Filters drop down
Given I click Row Actions for the first product returned
And I click on the Row Action: Edit
Given In the New Product page I click tab: Product Type
And in the New Product page I click section: The Product
Then Product Line or Brand (optional) should be showing the value: SuperBrand(TM)


#CLF 16/7/2018 This scenario cannot be completed because there are no products returned by the Accepted By Retailers Filter
#in the development environment - It will work in staging.
Scenario: [71188] Primary Filter on My Products View - UPC Filter
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load
Given I filter the products by: Accepted by Retailers
Given I edit the first product in results

Scenario: [65617] Correct Order of Statuses
Given I Login into WERCSmart Portal - Admin Role - WERCs Visual Account
And I should see a Pie Chart and Legend under Product Information
And I should see the following states in the following order in the Legend:
| State                  |
| Not Yet Submitted      |
| Assessment in Progress |
| Sending to Retailers   |
| Accepted by Retailers  |
| Needs Your Attention   |
And I should see the following filters in the following order under My products:
| Filter                  |
| All                    |
| Not Yet Submitted      |
| Assessment in Progress |
| Sending to Retailers   |
| Accepted by Retailers  |
| Needs Your Attention   |
| Canceled               |

Scenario: [59732] Announcements - Add
Given I navigate to Studio
Given I call shared step 53542 (Login with Administrator Role Continue 2 (2nd login shared step))
Given I call shared step 59066 (Go to SHA Manager)
Given I call shared step 59728 (Go to Manage Global Messages)
Given In the the Manage Global Messages dialog I add and save the following messages:
| Title    | Message   | Type          | Active | Level   |
| My title | generated | GlobalMessage | true   | Warning |
Given I close the Manage Global Messages dialog
Given I navigate to Portal
Given I Login into WERCSmart Portal - Admin Role - WERCs Visual Account
Then In the announcements area I should see my saved messages


Scenario: [58579] Live Help - Chat Feature
Given I Login into WERCSmart Portal - Admin Role - WERCs Visual Account
Given I click on the Live Help button on the upper right
Then I should see the Live Help dialog
Then In the Live Help dialog I should see the following text: Please provide the following to begin a live chat or call: Support: +1-518-720-6220 or +1-877-642-6753  Agency: +1-855-313-1230
Given In the Live Help dialog I enter name: John Smith
Given In the Live Help dialog I enter email: johnsmithtest@test.co.uk
Given In the Live Help dialog I click on the x to close

Scenario: [56829] More Filters

Given I Login into WERCSmart Portal - Admin Role - WERCs Visual Account

Then The home screen should load

And I should see an option for More Filters

Given I click More Filters in the products grid

# Confirm that you are able to search with combinations  (example : UPC and Retailer , UPC and Additional Programs , UPC and Brand,  UPC-Brand-Retailer-Additional Programs)

# Couldn't find the test case in TFS folder heirarchy, placing it in home page
Scenario: [66335] Main Menu - expanded

Given I Login into WERCSmart Portal - Admin Role - WERCs Visual Account

Then The home screen should load

And I should see the navigation menu icon in the navigation bar

Given I expand the Navigation Menu

Then the Navigation Menu should be expanded

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

Given I collapse the Navigation Menu

Then the following icons should be found in the navigation bar
| Item                 |
| Home                 |
| Register New Product |
| My Messages          |
| Retail Partners      |
| Supplier Reports     |
| UL Solution Center   |
| Shopping Cart        |
| Support              |

And the navigation labels should be hidden

Scenario: [66336] Main Menu - collapsed

Given I Login into WERCSmart Portal - Admin Role - WERCs Visual Account

Then The home screen should load

Given I expand the Navigation Menu

Then the Navigation Menu should be expanded

Given I collapse the Navigation Menu

Then the Navigation Menu should be collapsed

Given the hover over text is as expected for the following navigation icons
| Icon       | Text                 |
| Home       | Home                 |
| Flask      | Register New Product |
| Envelope   | My Messages          |
| Handshake  | Retail Partners      |
| Cloud      | Supplier Reports     |
| Bulb       | UL Solution Center   |
| Cart       | Shopping Cart        |
| Life-Saver | Support              |
