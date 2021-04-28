@Shared
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
@CreateProducts
@Homepage
Feature: Home Page

#pass - staging 4.10
@ScenarioId:421
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
@ScenarioId:422
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
@ScenarioId:423
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
@ScenarioId:424
Scenario: [56149] Click Register Product button from home page - Navigation
	Given I Login into WERCSmart Portal - Admin Role - WERCs Visual Account
	Then the WERCSmart homepage should load
	Then I click the Register New Product icon in the QuickLinks Pane
	And I should see the header New Product
	And I should see the statement Select the type of product to create:
	And I should see the radio button: Create a New Registration
	And I should see the radio button: Copy from an Existing Registration

#pass - staging 4.10
@ScenarioId:425
Scenario: [56158] Retail Partners navigation No Products
	Given I Login into WERCSmart Portal - Admin Role - WERCs Visual Account
	Then the WERCSmart homepage should load
	Then I click the Retail Partners icon in the Navigation Pane
	Then I should see the following heading Retail Partners
	And I should see the following subheading All Retailers
	And I should not see the following subheading Most Recent Retailers

#pass - staging 4.10
@ScenarioId:426
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
@ScenarioId:427
Scenario: [56163] Left hand navigation - Shopping Cart - No Products
	Given I Login into WERCSmart Portal - Admin Role - WERCs Visual Account
	Then the WERCSmart homepage should load
	Then I click the Shopping Cart icon in the Navigation Pane
	And I should see the header: Cart is Empty on the Cart is Empty window
	And I click on the close button on Cart is Empty
	Then I should see the Subheading Announcements in the main window

#pass - staging 4.10 (might need to look at freshdesk link
@ScenarioId:428
Scenario: [56188] Support navigation
	Given I Login into WERCSmart Portal - Admin Role - WERCs Visual Account
	Then the WERCSmart homepage should load
	Then I click the Support icon in the Navigation Pane
	Then Confirm that freshdesk opens in another tab

#pass - staging 4.10
@ScenarioId:429
Scenario: [56206] Sign Out
	Given I Login into WERCSmart Portal - Admin Role - WERCs Visual Account
	Then the WERCSmart homepage should load
	Then I click the User Icon
	And I click on Sign Out
	And the landing page should load

@ScenarioId:435
Scenario: [56281] Product Information - Alerts - click More
	Given I Login into WERCSmart Portal - Admin Role - WERCs Visual Account
	Then the WERCSmart homepage should load
	Then I click More below the Alerts Panel
	And I should see the header: Message Center on the Message Center window

@ScenarioId:443
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
		| My Reports           |
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

@ScenarioId:444
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

@ScenarioId:450
Scenario: [67299] Terms of Use - footer
	Given I Login into WERCSmart Portal - Admin Role - WERCs Visual Account
	Then The home screen should load
	Given I click the Terms of Use link in the footer
	Given I confirm the WERCSmart Terms of Use page opened in a new tab and navigate to it
	And I close the window that opened

@singlerun
@ScenarioId:446
Scenario: [65886] My Products - Pagination
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given If my products grid does not contain enough products then I add them until it displays '...' grid navigation option
	Then The current page in the products grid is: 1
	Given I click next in the products grid
	Then The current page in the products grid is: 2
	Given I click previous in the products grid
	Then The current page in the products grid is: 1
	Given I click ... in the products grid
	Then I should see the products grid navigation input with up and down arrows
	Given I type the number 8 into the products grid page navigation box and press the enter key
	Then The current page in the products grid is: 8
	Given I click ... in the products grid
	Given I enter the up arrow into the products grid page navigation input then the correct page is shown
	Given I click ... in the products grid
	Given I enter the down arrow into the products grid page navigation input then the correct page is shown


#CLF 16/7/2018 This scenario cannot be completed because there are no products returned by the Accepted By Retailers Filter
#in the development environment.
# JS 13/8/18 Finished test now we have more products completed via SHA - it will work in staging at least
@ScenarioId:452
Scenario: [71188] Primary Filter on My Products View - UPC Filter
	Given I log in with the account saved in TReVor as: ProductAccount
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

@ScenarioId:445
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

@ScenarioId:437
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

@ScenarioId:436
Scenario: [58579] Live Help - Chat Feature
	Given I Login into WERCSmart Portal - Admin Role - WERCs Visual Account
	Given I click on the Live Help button on the upper right
	Then I should see the Live Help dialog
	Then In the Live Help dialog I should see a small icon with three lines in the upper left hand corner
	Then In the Live Help dialog I should see an x in the upper right hand corner
	Then In the Live Help dialog I should see the text 'Inbox' at the top of the chat window
	Then In the Live Help dialog I should see the description text: Currently replying in under 2 hours at the top of the chat window
	Then In the Live Help dialog I should see the following text in the message area: Hello there! Need help? Reach out to us right here, and we'll get back to you as soon as we can!
	#Then In the Live Help dialog I should see the following text in the lower part of the chat window: Freshchat
	Then In the Live Help dialog I should see the following placeholder text in the text entry field: Reply here...
	Then In the Live Help dialog I should see the paperclip icon in the lower right hand corner
	Then In the Live Help dialog I should see the smiley icon in the lower right hand corner
	Given In the Live Help dialog I click on the x to close

# Couldn't find the test case in TFS folders, placing it in home page
@ScenarioId:447
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
		| My Reports           |
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
		| My Reports           |
		| UL Solution Center   |
		| Shopping Cart        |
		| Support              |
	And the navigation labels should be hidden

@ScenarioId:448
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
		| File-Text  | My Reports           |
		| Bulb       | UL Solution Center   |
		| Cart       | Shopping Cart        |
		| Life-Saver | Support              |

# Assigned to Amanda Coutant
# Created by Amanda Coutant
# Test case can be found at the following paths:
# NetProjects10\WercsSmart Portal\WERCSmart\Home Page
@ScenarioId:455
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
	And In The products Grid I Wait for the Retailers Popup to appear
	Then I confirm the Retailers popup is displayed
	And I click the products grid container
	And In The products Grid I Wait for the Retailers Popup to disappear
	Then I confirm the Retailers popup is not displayed
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase85275

@ScenarioId:453
Scenario: [71230] Archived Retailers - My Products View
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Then The home screen should load
	Given I filter the products by: Accepted by Retailers	
	#And I should see an option for More Filters
	#Given I click More Filters in the products grid
	#And I select the Wal-Mart/SAM'S CLUB option in the Retailer More Filters drop down
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

@ScenarioId:454
Scenario: [73791] My Products grid - Retailers Column Alphabetical Order
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Then The home screen should load
	Given I filter the products by: Accepted by Retailers
	And I check for all items in the grid that the retailers are alphabetically listed

@ScenarioId:420
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
		| My Reports           |
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
		| My Reports           |
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


	       

	@ScenarioId:10736
Scenario: [156787] Home Page Search - Internal SKU field

Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
Given I generate a random UPC number and save as: UPC156787
Then Generate a random SKU number (12 random digits) and save as: RandomSKU_156787
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
Given I save the product information as: TestCase
Given I call Shared Step 26897 (Product Characteristics - Solid only available - continue)
Given I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Water
Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Given I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue) for
| Retailer  |
| Walgreens |
Given I call Shared Step 162053 (Enter Universal Product Code (UPC) - Battery - Confirm SKU - No Package Type - Do Not Click Continue) for UPC saved as: UPC156787 with container type: Metal Container size: 40.0 and SKU: RandomSKU_156787
Given I click continue
Given I click continue
Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
Given in the Additional Documents to Provide page I click Continue
Given in the Optional Reports and Documents Available for Purchase page I click Continue
Given I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
| Appearance | Autoignition Temperature | Minimum Ignition Energy | Odor     | Odor Threshold    | Partition Coefficient | Personal Protection Equipment | Viscosity |
| Black      | 300                      | 1.005                   | Odorless | No data available | 10                    | Mask                          | 20        |
Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: test
Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
Given If purchase details are showing click confirm order
Given I click the Home navigation icon
Given I search for the product with SKU saved as: RandomSKU_156787



@ScenarioId:10755
Scenario: [158930] Home Page Search - Internal Information

Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
Given I generate a random UPC number and save as: UPC158930
Given I generate a random Product ID and save as: ProductID158930
Then Generate a random SKU number (12 random digits) and save as: RandomSKU158930
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I set the Product Identification (Optional) field to Proudct ID saved as: ProductID158930
Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
Given I save the product information as: TestCase158930
Given I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
Given I call Shared Step 26897 (Product Characteristics - Solid only available - continue)
Given I generate a random Ingredient ID and save as: IngredientID158930
Given In the Ingredient Reference Number field I enter the following text: IngredientID158930 and saved as: IngID
Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Water
Given I should see the Waste Classification Data Page
Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Given I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue) for
| Retailer  |
| Walgreens |
Given I call Shared Step 163416 (Enter Universal Product Code (UPC) - Battery - Confirm SKU - No Package Type - Do Not Click Continue) for UPC saved as: UPC158930 with container type: Metal Container size: 2 and SKU: RandomSKU158930
Given in the Universal Product Code (UPC) page I click Continue
Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
Given in the Additional Documents to Provide page I click Continue
Given in the Optional Reports and Documents Available for Purchase page I click Continue
Given I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
| Appearance | Autoignition Temperature | Minimum Ignition Energy | Odor     | Odor Threshold    | Partition Coefficient | Personal Protection Equipment | Viscosity |
| Black      | 300                      | 1.005                   | Odorless | No data available | 10                    | Mask                          | 20        |
Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: test
Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
Given If purchase details are showing click confirm order
Given I navigate to the home page
Given I click More Filters in the products grid
Given I confirm I see the Product ID, Ingredient ID, SKU field above the Product Grid
Given In the Product ID, Ingredient ID, SKU filter field I search for: ProductID158930
Given I should only see one product in the grid, with Product ID matching that saved as: TestCase158930
Given I clear the Search Criteria
Given I click More Filters in the products grid
Given In the Product ID, Ingredient ID, SKU filter field I search for: IngID
Given I should only see one product in the grid, with Product ID matching that saved as: TestCase158930
Given I clear the Search Criteria
Given I click More Filters in the products grid
Given In the Product ID, Ingredient ID, SKU filter field I search for: RandomSKU158930
Given I should only see one product in the grid, with Product ID matching that saved as: TestCase158930
Given I clear the Search Criteria
Given I click More Filters in the products grid
