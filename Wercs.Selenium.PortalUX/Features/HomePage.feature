@Login
@Homepage
@ProductGrid
@ForwardProductRegistration
@NewProduct
@RetailPartners
@MyAccount
@LandingPage
@wercsmart
@run_Homepage

Feature: Home Page

Background:
Given I login as the administrator
Then the WERCSmart homepage should load

Scenario: [55796] Navigate to Home Page
Then I should see the UL/WERCSmart Logo in the header bar
And I should see the Notification Icon in the header bar
And I should see the User Icon in the header bar
# And I should see the Supplier Name Dropdown in the header bar
Then I click the User Icon
And I should see My Account in the user dropdown
And I should see Sign Out in the user dropdown
Then I should see the Navigation Menu Icon in the navigation bar
Then I expand the Navigation Menu

And I following should be found in the navigation bar
| Item                 |
| Home                 |
| Register New Product |
| My Messages          |
| Retail Partners      |
| UL Solution Center   |
| Shopping Cart        |
| Support              |

Then I should see the Register Product Hyperlink in the main window
And I should see the Register GoodGuide Hyperlink in the main window
And I should see the Register PurView Hyperlink in the main window
And I should see the WERCSLink Hyperlink in the main window
And I scroll to the bottom of the page
Then I should see the Register Product Hyperlink in the home page header
And I should see the Register GoodGuide Hyperlink in the home page header
And I should see the Register PurView Hyperlink in the home page header
And I should see the WERCSLink Hyperlink in the home page header
And I scroll to the top of the page
And I should see the Subheading Product Information in the main window
And I should see the Subheading Alerts in the main window
And I should see the Subheading Announcements in the main window
And I should see the Subheading Your Products in the products grid
Then there should be products available in the Products Grid

Scenario: [55817] Product Information Panel
When I click on the red triangle next to Product Information to collapse the section
Then the Product Information dialog should be hidden
And the Alerts dialog should be hidden
And the Announcements dialog should be hidden

When I click on the red triangle next to Product Information to expand the section
Then the Product Information dialog should be visible
And the Alerts dialog should be visible
And the Announcements dialog should be visible

And I should see a Pie Chart and Legend under Product Information
And I should see the following states in the Legend:
| State                  | Colour |
| Assessment in Progress | Yellow |
| Sending to Retailers   | Blue   |
| Accepted by Retailers  | Green  |
| Not Yet Submitted      | Grey   |
| Product Update         | Red    |

# Then wants to check that the Pie Chart contains some of the above colours....
# Not sure how to automate these - but putting the steps in anyway
# ==================================================================================================
# And I the pie chart should contain some of the above colours
# And I should see the total number of products in the center of the Pie Chart
# And hovering over sections of the Pie Chart displays percecntage count and state of the products
# ==================================================================================================

Given I see notifications in the Alerts Panel
Then clicking on the top Alert should direct me to the My Messages page
Then I navigate to the home page
And I click More below the Alerts Panel
And I confirm that I am taken to the My Messages Alerts page

Then I navigate to the home page
Given I see notifications in the Announcement Panel
Then clicking on the top Announcement should direct me to the My Messages page

Then I navigate to the home page
And I click More below the Announcements Panel
And I confirm that I am taken to the My Messages Announcements page

Scenario: [55938] Your Products grid
Given I should see the following filter options below Your Products
| Options                | Colour     |
| All                    | Light Grey |
| Not Yet Submitted      | Dark Grey  |
| Assessment in Progress | Yellow     |
| Sending to Retailers   | Blue       |
| Accepted by Retailers  | Green      |
| Needs Your Attention   | Red        |

And I should see an option for More Filters
And I should see an option for Product ID/Name
And I should see an option for Bulk Actions

And the Product Grid should have the following headers:
| Header            |
| ID / Product Name |
| Date Created      |
| Retailers         |
| Actions           |  

And I can navigate between pages using the pagniation buttons at the bottom of the grid
Given I search for the first product in the table
Then I should see the product returned in the search results
And I clear the Search Criteria

# Not sure how to test this - but then wants to check each Product Filter filters correctly....
When I filter the products by: Not Yet Submitted
And I click Row Actions for the first product returned
Then I should see the following options
| Option |
| Edit   |
| Submit |
| Delete |

When I filter the products by: Assessment in Progress
And I click Row Actions for the first product returned
Then I should see the following options
| Option    |
| View      |
| Documents |

When I filter the products by: Sending to Retailers
And I click Row Actions for the first product returned
Then I should see the following options
| Option             |
| View               |
| Documents          |
| UPC Update         |
| Retailer ID Update |
| Resend to Retailer |

When I filter the products by: Accepted by Retailers
And I click Row Actions for the first product returned
Then I should see the following options
| Option                          |
| Edit                            |
| UPC Update                      |
| View                            |
| Documents                       |
# Displays if within the parameter of 1 year or more last activity by supplier/customer
| Delete                          |
| Resend to Existing Customer     |
| Forward To Additional Retailers |

When I filter the products by: Needs Your Attention
And I click Row Actions for the first product returned
Then I should see the following options
| Option    |
| Edit      |
| Documents |
| Submit    |

Scenario: [56020] Bulk Actions
Given I click Bulk Actions in the Products Grid
Then I should see a popup with header Bulk Actions
And I should see the following options available in the Bulk Actions window
| Options                      |
| Forward Product Registration |
| Sync Products to WERCSlink   |
| Accept Documents             |
| Download Reports             |
| Delete Products              |

Scenario: [56054] Navigate to Notifications (Bell Icon)
Given I click on the Notification Icon
Then the Notification page should appear

Scenario: [56149] Click Register Product button from home page - Navigation
Then I click the Register Product icon in the QuickLinks Pane
And I should see the header New Product
And I should see the statement Would you like to Create a New Product?
And I should see the radio button: Yes, create a new product
And I should see the radio button: No, copy an existing product
# Scenario: [56174] Register Product top menu navigation
Scenario: [56151] Register New Product from menu navigation
Then I click the Register New Product icon in the Navigation Pane
And I should see the header New Product
And I should see the statement Would you like to Create a New Product?
And I should see the radio button: Yes, create a new product
And I should see the radio button: No, copy an existing product

Scenario: [56158] Retail Partners navigation
Then I click the Retail Partners icon in the Navigation Pane
Then I should see the following heading Retail Partners
And I should see the following subheading Most Recent Retailers
And I should see the following subheading All Retailers

Scenario: [56161] UL Solution Center navigation
Then I click the UL Solution Center icon in the Navigation Pane
And UNDER DEVELOPMENT

Scenario: [56163] Shopping Cart navigation
Then I click the Shopping Cart icon in the Navigation Pane
And UNDER DEVELOPMENT
# Scenario: [56179] Register PurView top menu navigation
Scenario: [56165] Register PurView navigation
Then I click the Register PurView icon in the QuickLinks Pane
And UNDER DEVELOPMENT
# Scenario: [56181] UL Solution Center top menu navigation
Scenario: [56167] UL Solution Center button - navigation
Then I click the UL Solution Center icon in the QuickLinks Pane
And UNDER DEVELOPMENT
# Scenario: [56184] WERCSLink top menu navigation
Scenario: [56170] WERCSLink button navigation
Then I click the WERCSLink icon in the QuickLinks Pane
And UNDER DEVELOPMENT

Scenario: [56188] Support navigation
Then I click the Support icon in the Navigation Pane
And UNDER DEVELOPMENT

Scenario: [32590] My Account navigation
Then I click the User Icon
And I click on My Account
And I should see the heading: My Account on the My Account page
And I should see the subheading: Your Company User Accounts on the My Account page

Scenario: [56206] Sign Out
Then I click the User Icon
And I click on Sign Out
And the landing page should load

Scenario: [56212] Your Products grid Actions - Edit Navigation
When I filter the products by: Not Yet Submitted
Given I save the ProductID and Name of the first Product in the grid as: FirstProduct
When I click Row Actions for the most recent product returned
Then I click on the Row Action: Edit
Then the Product Type page should be loaded
And the product saved as: FirstProduct should be visible in editor

Scenario: [56214] Your Products grid Actions - Submit Navigation
When I filter the products by: Not Yet Submitted
Given I save the ProductID and Name of the first Product in the grid as: FirstProduct
When I click Row Actions for the most recent product returned
Then I click on the Row Action: Submit
And UNDER DEVELOPMENT

Scenario: [56216] Your Products grid Actions - Delete Navigation
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

Scenario: [56218] Your Products grid Actions - View Navigation
When I filter the products by: Assessment in Progress
And I click Row Actions for the most recent product returned
Then I click on the Row Action: View
And UNDER DEVELOPMENT

Scenario: [56219] Your Products grid Actions - Documents navigation
When I filter the products by: Assessment in Progress
And I click Row Actions for the most recent product returned
Then I click on the Row Action: Documents
And UNDER DEVELOPMENT

Scenario: [56220] Your Products grid Actions - UPC Update navigation
When I filter the products by: Sending to Retailers
And I click Row Actions for the most recent product returned
Then I click on the Row Action: UPC Update
And UNDER DEVELOPMENT

Scenario: [56221] Your Products grid Actions - Retailer ID Update navigation
When I filter the products by: Sending to Retailers
And I click Row Actions for the most recent product returned
Then I click on the Row Action: Retailer ID Update
And UNDER DEVELOPMENT

Scenario: [56222] Your Products grid Actions - Resend to Retailer navigation
When I filter the products by: Sending to Retailers
And I click Row Actions for the most recent product returned
Then I click on the Row Action: Resend to Retailer
And UNDER DEVELOPMENT

Scenario: [56223] Bulk Actions - Forward Product Registration navigation
Given I click Bulk Actions in the Products Grid
And I click Forward Product Registration in the Bulk Actions window
Then I should see the header: Forward Product Registration on the Forward Product Registration window
And I should see the subheading: You did the most recent buisiness with... on the Forward Product Registration window
And I should see the subheading: Select Retailers on the Forward Product Registration window

Scenario: [56224] Bulk Actions - Sync Products to WERCSLink navigation
Given I click Bulk Actions in the Products Grid
And I click Sync Products to WERCSlink in the Bulk Actions window
And UNDER DEVELOPMENT

Scenario: [56225] Bulk Actions - Accept Documents navigation
Given I click Bulk Actions in the Products Grid
And I click Accept Documents in the Bulk Actions window
And UNDER DEVELOPMENT

Scenario: [56226] Bulk Actions - Download Reports navigation
Given I click Bulk Actions in the Products Grid
And I click Download Reports in the Bulk Actions window
And UNDER DEVELOPMENT

Scenario: [56227] Bulk Actions - Delete Products navigation
Given I click Bulk Actions in the Products Grid
And I click Delete Products in the Bulk Actions window
And UNDER DEVELOPMENT

Scenario: [56280] Product Information - Alerts - click on any notification
Then clicking on the top Alert should direct me to the My Messages page
And UNDER DEVELOPMENT

Scenario: [56281] Product Information - Alerts - click More
Then I click More below the Alerts Panel
And UNDER DEVELOPMENT

Scenario: [56282] Product Information - Announcements - click on any notification
Then clicking on the top Announcement should direct me to the My Messages page
And UNDER DEVELOPMENT

Scenario: [56285] Product Information - Announcements - click More
Then I click More below the Announcements Panel
And UNDER DEVELOPMENT 