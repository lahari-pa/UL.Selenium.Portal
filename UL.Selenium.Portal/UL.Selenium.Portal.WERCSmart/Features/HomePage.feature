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
@SummaryPage
@PaymentMethods
@ProductSetUp
Feature: Home Page

#pass - staging 4.10
@TReVorId:10160
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
@TReVorId:10154
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
@TReVorId:6653
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
@TReVorId:6658
Scenario: [56149] Click Register Product button from home page - Navigation
	Given I Login into WERCSmart Portal - Admin Role - WERCs Visual Account
	Then the WERCSmart homepage should load
	Then I click the Register New Product icon in the QuickLinks Pane
	And I should see the header New Product
	And I should see the statement Select the type of product to create:
	And I should see the radio button: Create a New Registration
	And I should see the radio button: Copy from an Existing Registration

#pass - staging 4.10
@TReVorId:10157
Scenario: [56158] Retail Partners navigation No Products
	Given I Login into WERCSmart Portal - Admin Role - WERCs Visual Account
	Then the WERCSmart homepage should load
	Then I click the Retail Partners icon in the Navigation Pane
	Then I should see the following heading Retail Partners
	And I should see the following subheading All Retailers
	And I should not see the following subheading Most Recent Retailers

#pass - staging 4.10
@TReVorId:6661
Scenario: [56161] UL Solution Center navigation
	Given I Login into WERCSmart Portal - Admin Role - WERCs Visual Account
	Then the WERCSmart homepage should load
	Then I click the UL Solution Center icon in the Navigation Pane
	Then I confirm that the UL Solution Center page is loaded
	Then I confirm the following sections are displayed in the UL Solution Center page:
		| Sections                 |
		| ECOLOGO                  |
		| Prospector               |
		| GoodGuide for Consumers  |
		| GoodGuide for Suppliers  |
		| UL Secure Connect (ULSC) |
		| ULGHS                    |
		| Navigator                |

#pass - staging 4.10
@TReVorId:10163
Scenario: [56163] Left hand navigation - Shopping Cart - No Products
	Given I Login into WERCSmart Portal - Admin Role - WERCs Visual Account
	Then the WERCSmart homepage should load
	Then I click the Shopping Cart icon in the Navigation Pane
	And I should see the header: Cart is Empty on the Cart is Empty window
	And I click on the close button on Cart is Empty
	Then I should see the Subheading Announcements in the main window

#pass - staging 4.10 (might need to look at freshdesk link
@TReVorId:6666
Scenario: [56188] Support navigation
	Given I Login into WERCSmart Portal - Admin Role - WERCs Visual Account
	Then the WERCSmart homepage should load
	Then I click the Support icon in the Navigation Pane
	Then Confirm that freshdesk opens in another tab

#pass - staging 4.10
@TReVorId:6667
Scenario: [56206] Sign Out
	Given I Login into WERCSmart Portal - Admin Role - WERCs Visual Account
	Then the WERCSmart homepage should load
	Then I click the User Icon
	And I click on Sign Out
	And the landing page should load

#pass - staging 4.10
@TReVorId:10166
Scenario: [56212] My Products grid Actions - Edit Navigation
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then the WERCSmart homepage should load
	When I filter the products by: Not Yet Submitted
	Given I save the ProductID and Name of the first Product in the grid as: FirstProduct
	When I click Row Actions for the most recent product returned
	Then I click on the Row Action: Edit
	Then the Product Editor page should be loaded
	And the product saved as: FirstProduct should be visible in editor

@TReVorId:22069
Scenario: [56214] My Products grid Actions - Submit navigation
	Given I generate a random UPC number and save as: UPC56214
	And I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	And I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Wine
	Then I save the product information as: TestCase56214
	And I call Shared Step 62686 (Enter Physical Property - Liquid - Without Water Solubility)
	And I call Shared Step 94674 (Additional Product Information - RU Wine)
	And I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	And I call Shared Step 49818 (Beverage Regulatory Details)
	And I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	And I call Shared Step 71618 (U. S. Department of Transportation (DOT) Classification - For Alcohol (Packaging III))
	#And I call Shared Step 63219 (Retailer Association - Select No Retailer - Click continue)
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	Given in the Additional Documents to Provide page I click Continue
	#Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: Test
	And I navigate to the home page
	And I filter the products by: Not Yet Submitted
	And I search for the product saved as: TestCase56214
	When I click Row Actions for the most recent product returned
	Then I click on the Row Action: Submit
	And I should see the Data Acceptance Page
	And I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)

@TReVorId:10172
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

# Removing this step as multiple tests are creating products simultaneously - can't guarantee the count =-1 since deleting the product and refreshing
#Then the number of items in the pie chart should be one less than the figure I saved
@TReVorId:10175
Scenario: [56218] My Products grid Actions - View Navigation
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then the WERCSmart homepage should load
	When I filter the products by: Assessment in Progress
	And I click Row Actions for the most recent product returned
	Then I click on the Row Action: View
	Then A Summary page should open in a new browser tab
	Then I should not seen an Accept button
	Given I close the browser tab with the Summary page

@TReVorId:22227
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

@tfs_design
Scenario: [56220] My Products grid Actions - Edit UPCs
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then the WERCSmart homepage should load
	When I filter the products by: Sending to Retailers
	Given I save the ProductID and Name of the first Product in the grid as: FirstProduct
	And I click Row Actions for the most recent product returned
	Then I click on the Row Action: UPC Update
	And UNDER DEVELOPMENT

#Design => Ready
@tfs_design
Scenario: [56280] Document is created and is ready for review
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then clicking on the top Alert should direct me to the My Messages page
	And UNDER DEVELOPMENT

@TReVorId:6682
Scenario: [56281] Product Information - Alerts - click More
	Given I Login into WERCSmart Portal - Admin Role - WERCs Visual Account
	Then the WERCSmart homepage should load
	Then I click More below the Alerts Panel
	And I should see the header: Message Center on the Message Center window

@TReVorId:11379
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

@TReVorId:11383
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

@TReVorId:16680
Scenario: [67299] Terms of Use - footer
	Given I Login into WERCSmart Portal - Admin Role - WERCs Visual Account
	Then The home screen should load
	Given I click the Terms of Use link in the footer
	Given I confirm the WERCSmart Terms of Use page opened in a new tab and navigate to it
	And I close the window that opened

@TReVorId:16679
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

@TReVorId:16681
Scenario: [68388] More Filters - Brand
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I create a new product of type: Bleach, with a Product Line/ Brand added and select Type of Product: Bleach
	And I should see an option for More Filters
	Given I click More Filters in the products grid
	Given I select the More Filters - Brand saved as: Brand68388 by ID
	Given I click Row Actions for the first product returned
	And I click on the Row Action: Edit
	Given In the New Product page I click tab: Product Type
	And I click the page heading: The Product
	# step accepts '~saved as...' and will fetch the value from context
	Then Product Line or Brand (optional) should be showing the value: ~saved as BrandName68388
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase68388

#CLF 16/7/2018 This scenario cannot be completed because there are no products returned by the Accepted By Retailers Filter
#in the development environment.
# JS 13/8/18 Finished test now we have more products completed via SHA - it will work in staging at least
@TReVorId:16776
Scenario: [71188] Primary Filter on My Products View - UPC Filter
	Given I log in with the account saved in TReVor as: PremiumSubscriptionAccount
	Then The home screen should load
	Given I filter the products by: Accepted by Retailers
	Given I click Row Actions for the first product not in the 'Needs Your Attention' status
	And I click on the Row Action: View
	Then A Summary page should open in a new browser tab
	Given in the Summary page I save the UPC number to context as: Summary - UPC - 71188
	Given in the Summary page I save the Product ID to context as: Summary - Product ID - 71188
	Given I close the browser tab with the Summary page
	Given I filter the products by: All
	Given I search for UPC number saved as: Summary - UPC - 71188
	Then I should only see one product in the grid, with Product ID matching that saved as: Summary - Product ID - 71188

@TReVorId:16775
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
		| Filter                 |
		| All                    |
		| Not Yet Submitted      |
		| Assessment in Progress |
		| Sending to Retailers   |
		| Accepted by Retailers  |
		| Needs Your Attention   |
		| Canceled               |

@TReVorId:16773
Scenario: [59732] Announcements - Add
	Given I navigate to Studio
	Given I call Shared Step 53542 (Login with Administrator Role Continue 2 (2nd login Shared Step))
	Given I call Shared Step 59066 (Go to SHA Manager)
	Given I call Shared Step 59728 (Go to Manage Global Messages)
	Given In the the Manage Global Messages dialog I add and save the following messages:
		| Title    | Message   | Type          | Active | Level   |
		| My title | generated | GlobalMessage | true   | Warning |
	Given I close the Manage Global Messages dialog
	Given I navigate to Portal
	Given I Login into WERCSmart Portal - Admin Role - WERCs Visual Account
	Then In the announcements area I should see my saved messages

@TReVorId:16772
Scenario: [58579] Live Help - Chat Feature
	Given I Login into WERCSmart Portal - Admin Role - WERCs Visual Account
	Given I click on the Live Help button on the upper right
	Then I should see the Live Help dialog
	Then In the Live Help dialog I should see the following text: Please provide the following to begin a live chat or call: Support: +1-518-720-6220 or +1-877-642-6753  Agency: +1-855-313-1230
	Given In the Live Help dialog I enter name: John Smith
	Given In the Live Help dialog I enter email: johnsmithtest@test.co.uk
	Given In the Live Help dialog I click on the x to close

@TReVorId:17229
Scenario: [56829] More Filters
	# Consider creating the test product from scratch every time? nb kit 13 58753
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	And I should see an option for More Filters
	Given I click More Filters in the products grid
	Given I confirm the product exists with Product ID: 1501253 and Name: More Filters Test Product
	Given I enter combinations of More Filters and should see the product ID: 1501253 only for the correct combinations
		| Filter              | Match                   |
		| UPC                 | 0601215310023           |
		| Brand               | More Filters Test Brand |
		| Retailer            | CVS                     |
		| Additional Programs | Kit Registrations       |
	Given I enter combinations of Status and More Filters and should see the product ID: 1501253 only for the correct combinations
		| Filter              | Match                   |
		| Status              | Assessment in Progress  |
		| Brand               | More Filters Test Brand |
		| Retailer            | CVS                     |
		| Additional Programs | Kit Registrations       |
	Given I click More Filters in the products grid
	Then the 'More Filters' options are not displayed
	Given I click More Filters in the products grid
	Then the 'More Filters' options are displayed
	Given I click More Filters in the products grid
	Then the 'More Filters' options are not displayed

# Couldn't find the test case in TFS folders, placing it in home page
@TReVorId:18976
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

@TReVorId:18978
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

# Assigned to Amanda Coutant
# Created by Amanda Coutant
@TReVorId:20286
Scenario: [68413] More Filters - Retailer
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I click More Filters in the products grid
	And I confirm the filter with label: "Retailer" is displayed and default option: "All Retailers"
	And I confirm retailers list based on environment
	#And I should see the following options for the Retailer filter
	#| Option                 |
	#| Ahold                  |
	#| Albertsons Companies   |
	#| Amazon                 |
	#| Autozone               |
	#| Bed Bath and Beyond    |
	#| Canadian Tire          |
	#| Costco                 |
	#| CVS                    |
	#| Delhaize               |
	#| Dick's Sporting Goods  |
	#| Dollar General         |
	#| Dollar Tree            |
	#| Essendant              |
	#| Family Dollar          |
	#| Genuine Parts          |
	#| Harbor Freight Tools   |
	#| HD Supply              |
	#| HyVee                  |
	#| Kohl's                 |
	#| Kroger                 |
	#| Lowes                  |
	#| McLane                 |
	#| Meijer                 |
	#| Michaels               |
	#| New Egg                |
	#| Northgate Market       |
	#| Office Depot           |
	#| O'Reilly Auto Parts    |
	#| Petco                  |
	#| Price Chopper          |
	#| Publix                 |
	#| Rite Aid               |
	#| Save Mart Supermarkets |
	#| Schnucks               |
	#| Sears K Mart           |
	#| Smart & Final          |
	#| Staples                |
	#| SuperValue             |
	#| Target                 |
	#| The Home Depot         |
	#| Topco                  |
	#| Tractor Value Supply   |
	#| Ultra Standard         |
	#| Unified                |
	#| Wakefren               |
	#| Walgreens              |
	#| BONBONS                |
	#| Walmart.com            |
	#| Hayneedle              |
	#| Jet                    |
	#| MODCLOTH               |
	#| Moosejaw               |
	#| Shoes.com              |
	#| Walmart                |
	#| Winco Foods            |
	And I select the Wal-Mart/SAM'S CLUB option in the Retailer More Filters drop down
	And I confirm all products in the grid contain either the the text "WM" or "All" under the 'Retailers' column

#And I click the first instance of Actions - Edit UPC in the products grid
#Then I should see the Universal Product Code (UPC) Page
#And I confirm that retailer "WM" is present under the 'Destination Retailers' column in the UPC table
# HomePage/ Actions/ Edit UPCs
@TReVorId:20300
Scenario: [64528] Edit UPCs - Click Link check status in SHA
	Given I create a product and take to completed using Test Case 75335 and save as: ProductSetup64528
	Given I navigate to the landing page
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	And I search for the product saved as: ProductSetup64528
	And I click Row Actions for the first product returned
	Then I click on the Row Action: Edit UPCs
	And I should see the Universal Product Code (UPC) Page
	And I confirm that retailer "CV" is present under the 'Destination Retailers' column in the UPC table
	And I call Shared Step 65080 (Login to Studio and Open SHA manager)
	And I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: ProductSetup64528)
	And In the SHA manager grid I see the WPS ID I have saved as product: ProductSetup64528 and its font is red indicating a recertification
	And I call Shared Step 51351 (SHA > Select Product > View Recertification History) for product saved as: ProductSetup64528
	Given In the Product Recertification History popup I should see the following entry
		| Product ID                 | Recertification Reason | Active |
		| saved as ProductSetup64528 | 2.0 UPC Update         | true   |
	Given I Close the Product Recertification History pop up
	Given I navigate to the landing page
	And I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)

# Assigned to Barrett, Beverly
# Created by Barrett, Beverly
@TReVorId:20301
Scenario: [64529] Edit UPCs - Home - Actions links should show Process UPC Update and Remove UPC Update
	Given I create a product and take to completed using Test Case 75335 and save as: ProductSetup64529
	Given I navigate to the landing page
	And I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	And I search for the product saved as: ProductSetup64529
	And I click Row Actions for the first product returned
	Then I click on the Row Action: Edit UPCs
	And I should see the Universal Product Code (UPC) Page
	And I confirm that retailer "CV" is present under the 'Destination Retailers' column in the UPC table
	And I call Shared Step 65080 (Login to Studio and Open SHA manager)
	And I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: ProductSetup64529)
	And In the SHA manager grid I see the WPS ID I have saved as product: ProductSetup64529 and its font is red indicating a recertification
	And I call Shared Step 51351 (SHA > Select Product > View Recertification History) for product saved as: ProductSetup64529
	Given In the Product Recertification History popup I should see the following entry
		| Product ID                 | Recertification Reason | Active |
		| saved as ProductSetup64529 | 2.0 UPC Update         | true   |
	Given I Close the Product Recertification History pop up
	Given I navigate to the landing page
	And I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	And I search for the product saved as: ProductSetup64529
	And I click Row Actions for the first product returned
	And I should see the following Actions options
		| Option             |
		| Discontinue        |
		| View               |
		| View UPCs          |
		| Process UPC Update |
		| Remove UPC Update  |
		| Monitor Progress   |

# Assigned to Barrett, Beverly
# Created by Barrett, Beverly
@TReVorId:21301
Scenario: [64530] Process UPC Update
	Given I create a product and take to completed using Test Case 75335 and save as: ProductSetup64530
	Given I generate a random UPC number and save as: UPC64530
	Given I navigate to the landing page
	#And I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I log in with the account saved in TReVor as: ProductAccount
	And I search for the product saved as: ProductSetup64530
	And I click Row Actions for the first product returned
	Then I click on the Row Action: Edit UPCs
	And I should see the Universal Product Code (UPC) Page
	And I confirm that retailer "CV" is present under the 'Destination Retailers' column in the UPC table
	And I navigate to the home page
	And I search for the product saved as: ProductSetup64530
	And I click Row Actions for the first product returned
	Then I click on the Row Action: Process UPC Update
	And I should see the Universal Product Code (UPC) Page
	And I call Shared Step 75307 (Edit UPC - Add UPC and all data - Click Save) for UPC Number saved as: "UPC64530", container type: "Plastic Container", size: "10"
	And I should see the Data Acceptance Page
	Then In the Data Acceptance page I select Yes, Agreed
	And In the Data Acceptance page I click on the Accept button
	And the Purchase Summary should load
	And I navigate to the home page
	And I call Shared Step 65080 (Login to Studio and Open SHA manager)
	#And I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: ProductSetup64530)
	Given In the SHA Manager Grid I run a search for product saved as: ProductSetup64530 and its status is: Recertification
	And I call Shared Step 75309 (SHA > Select Product > UPC List) for product saved as: ProductSetup64530
	And I confirm UPC number saved as: "UPC64530" is displayed in the SHA Manager Product UPC list
	And I close the window that opened

#Scenario: debug64530
#
#Given I save to context name: debug64530 and value: 1525087
#
#And I call Shared Step 65080 (Login to Studio and Open SHA manager)
#
#And I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: debug64530)
#
#And I call Shared Step 55637 (SHA - Process UPC Update for Specific product) saved as: debug64530
@TReVorId:21309
Scenario: [64531] Remove UPC Update - Cancel
	Given I create a product and take to completed using Test Case 75335 and save as: ProductSetup64531
	Given I navigate to the landing page
	And I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	And I search for the product saved as: ProductSetup64531
	And I click Row Actions for the first product returned
	Then I click on the Row Action: Edit UPCs
	And I should see the Universal Product Code (UPC) Page
	And I confirm that retailer "CV" is present under the 'Destination Retailers' column in the UPC table
	And I navigate to the home page
	And I call Shared Step 65080 (Login to Studio and Open SHA manager)
	And I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: ProductSetup64531)
	And In the SHA manager grid I see the WPS ID I have saved as product: ProductSetup64531 and its font is red indicating a recertification
	And I call Shared Step 51351 (SHA > Select Product > View Recertification History) for product saved as: ProductSetup64531
	Given In the Product Recertification History popup I should see the following entry
		| Product ID                 | Recertification Reason | Active |
		| saved as ProductSetup64531 | 2.0 UPC Update         | true   |
	Given I Close the Product Recertification History pop up
	Given I navigate to the landing page
	And I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	And I search for the product saved as: ProductSetup64531
	And I click Row Actions for the first product returned
	Then I click on the Row Action: Remove UPC Update
	And I confirm the Remove UPC Update popup displays the warning: Are you sure you want to restore the following Product ?
	And I confirm the Remove UPC Update popup displays the name and ID for product saved as: ProductSetup64531
	Given in the modal dialog I click cancel
	And I confirm the Remove UPC Update popup has closed
	And I click Row Actions for the first product returned
	And I should see the following Actions options
		| Option             |
		| Discontinue        |
		| View               |
		| View UPCs          |
		| Process UPC Update |
		| Remove UPC Update  |
		| Monitor Progress   |

@TReVorId:21324
Scenario: [64532] Remove UPC Update - Remove
	Given I create a product and take to completed using Test Case 75335 and save as: ProductSetup64532
	Given I navigate to the landing page
	And I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	And I search for the product saved as: ProductSetup64532
	And I click Row Actions for the first product returned
	Then I click on the Row Action: Edit UPCs
	And I should see the Universal Product Code (UPC) Page
	And I confirm that retailer "CV" is present under the 'Destination Retailers' column in the UPC table
	And I navigate to the home page
	And I call Shared Step 65080 (Login to Studio and Open SHA manager)
	And I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: ProductSetup64532)
	And In the SHA manager grid I see the WPS ID I have saved as product: ProductSetup64532 and its font is red indicating a recertification
	And I call Shared Step 51351 (SHA > Select Product > View Recertification History) for product saved as: ProductSetup64532
	#20/03/2019 CLF Changed recertification from 2.0 Specific UPC Update to 2.0 UPC Update
	Given In the Product Recertification History popup I should see the following entry
		| Product ID                 | Recertification Reason | Active |
		| saved as ProductSetup64532 | 2.0 UPC Update         | true   |
	Given I Close the Product Recertification History pop up
	Given I navigate to the landing page
	And I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	And I search for the product saved as: ProductSetup64532
	And I click Row Actions for the first product returned
	Then I click on the Row Action: Remove UPC Update
	And in the modal dialog I click the "REMOVE" button
	And I confirm the Remove UPC Update popup has closed
	And I should not see the following Actions options
		| Option             |
		| Process UPC Update |
		| Remove UPC Update  |
	And I call Shared Step 65080 (Login to Studio and Open SHA manager)
	And I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: ProductSetup64532)
	And In the SHA manager grid I see the WPS ID I have saved as product: ProductSetup64532 and its font is not red indicating a recertification
	And I call Shared Step 51351 (SHA > Select Product > View Recertification History) for product saved as: ProductSetup64532
	And I confirm there is no product entry listed with Recertification Reason: 2.0 Specific UPC Update
	Given I Close the Product Recertification History pop up

# Assigned to Amanda Coutant
# Created by Amanda Coutant
# Test case can be found at the following paths:
# NetProjects10\WercsSmart Portal\WERCSmart\Home Page
@TReVorId:21364
Scenario: [85275] Select All - Popup closes
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk
	Then I save the product information as: TestCase85275
	Given I call Shared Step 26897 (Product Characteristics - Solid only available - continue)
	Given I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Chlorine      | 100     | false               | false       |            |
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Then the 'Select Retailers' window appears
	Given I click the Select all retailers option in the Select Retailers popup
	Then all retailers are selected in the Select Retailers window
	Given I click Done in the Select Retailers popup
	Given In the Retailers tab, I select the first Vendor option for retailer: O'Reilly
	Given In the Retailers tab, I select the first Vendor option for retailer: Sears/K-Mart
	Given In the Retailers tab, I select the first Vendor option for retailer: Wal-Mart/SAM'S CLUB
	And I click continue
	And I navigate to the home page
	And I search for the product saved as: TestCase85275
	And I click 'All' under Retailers for the first product returned
	Then I confirm the Retailers popup is displayed
	And I click the products grid container
	Then I confirm the Retailers popup is not displayed
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase85275

@TReVorId:22065
Scenario: [71230] Archived Retailers - My Products View
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Then The home screen should load
	Given I filter the products by: Accepted by Retailers
	And I save the ProductID and Name of the first Product in the grid with a retailer as: TestCase71230
	And I click Row Actions for the first product returned
	And I click on the Row Action: Archive Retailers
	And I should see the Archive Retailers Popup
	And In the Archive Retailers popup, I select the the checkbox next to the the first retailer
	And In the Archive Retailers popup click on: ARCHIVE
	And I search for the product saved as: TestCase71230
	And I Select the check box next to Show Archived Retailers
	And I Confirm that two asterisks are visible in the retailer(s) that are archived icons that display
	And I Deselect the check box next to Show Archived Retailers

@TReVorId:22071
Scenario: [73791] My Products grid - Retailers Column Alphabetical Order
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Then The home screen should load
	Given I filter the products by: Accepted by Retailers
	And I check for all items in the grid that the retailers are alphabetically listed

@TReVorId:6652
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
