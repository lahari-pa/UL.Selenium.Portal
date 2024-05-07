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

Background:

#Removed from regression 2023/08
@ignore
@TestCase:55817
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
@TestCase:55938
Scenario: [55938] My Products grid
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
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
@TestCase:56020
Scenario: [56020] Bulk Actions
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
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
#Removed from regression 2023/08
@ignore
@TestCase:56149
Scenario: [56149] Click Register Product button from home page - Navigation
	Given I Login into WERCSmart Portal - Admin Role - WERCs Visual Account
	Then the WERCSmart homepage should load
	Then I click the Register New Product icon in the QuickLinks Pane
	And I should see the header New Product
	And I should see the statement Select the type of product to create:
	And I should see the radio button: Create a New Registration
	And I should see the radio button: Copy from an Existing Registration

#pass - staging 4.10
@TestCase:56206
Scenario: [56206] Sign Out
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then the WERCSmart homepage should load
	Then I click the User Icon
	And I click on Sign Out
	And the landing page should load

@TestCase:56281
Scenario: [56281] Product Information - Alerts - click More
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then the WERCSmart homepage should load
	Then I click More below the Alerts Panel
	And I should see the header: Message Center on the Message Center window

@TestCase:64854
Scenario: [64854] Navigation Settings
	# Sign in and expand the menu, checking the correct items are showing
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then I expand the Navigation Menu
	And the Navigation Menu should be expanded
	And the following icons and labels should be found in the navigation bar
		| Item                 |
		| Home                 |
		| Register New Product |
		| My Messages          |
		| Retail Partners      |
		| My Reports           |
		| Shopping Cart        |
		| Support              |
	And I click on Sign Out
	# Sign back in with same account
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	And the Navigation Menu should be expanded
	Given I click on My Account
	And the Navigation Menu should be expanded
	Then I collapse the Navigation Menu
	And I click on Sign Out
	# Sign back in a third time
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	And the Navigation Menu should be collapsed
	Given I click on My Account
	And the Navigation Menu should be collapsed

@TestCase:64872
Scenario: [64872] Pie Panel Settings
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
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
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
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

@TestCase:67299
Scenario: [67299] Terms of Use - footer
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I click the Terms of Use link in the footer
	Given I confirm the WERCSmart Terms of Use page opened in a new tab and navigate to it
	And I close the window that opened

@singlerun
@TestCase:65886
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

#Removed from regression 2023/08
@ignore
@TestCase:65617
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

@TestCase:231100
Scenario: [231100] Announcements - Add
	Given I navigate to Studio
	Given I call Shared Step 53542 (Login with Administrator Role Continue 2 (2nd login Shared Step))
	Given I call Shared Step 59066 (Go to SHA Manager)
	Given I call Shared Step 59728 (Go to Announcement Manager)
	Given In the the Manage Global Messages dialog I add and save the following messages:
		| Title    | Message   | Type          | Active | Level   |
		| My title | generated | GlobalMessage | true   | Warning |
	Given I close the Manage Global Messages dialog
	Given I navigate to Portal
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then In the announcements area I should see my saved messages

@TestCase:58579
Scenario: [58579] Live Help - Chat Feature
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I click on the Live Help button on the upper right
	Then I should see the Live Help dialog
	Then In the Live Help dialog I should see a small icon with three lines in the upper left hand corner
	Then In the Live Help dialog I should see an x in the upper right hand corner
	Then In the Live Help dialog I should see the text 'Inbox' at the top of the chat window
    Then In the Live Help dialog I should see the following text in the message area: Hello there! Thank you for being a UL WERCSmart User. Reach out to us right here, and we'll get back to you as soon as we can! How may I help you today?
	#Then In the Live Help dialog I should see the following text in the lower part of the chat window: Freshchat
	Then In the Live Help dialog I should see the following placeholder text in the text entry field: Reply here...
	Then In the Live Help dialog I should see the paperclip icon in the lower right hand corner
	Then In the Live Help dialog I should see the smiley icon in the lower right hand corner
	Given In the Live Help dialog I click on the x to close

# Couldn't find the test case in TFS folders, placing it in home page
@TestCase:66335
Scenario: [66335] Main Menu - expanded
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
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
		| Shopping Cart        |
		| Support              |
	And the navigation labels should be hidden

@TestCase:66336
Scenario: [66336] Main Menu - collapsed
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
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
		| Cart       | Shopping Cart        |
		| Life-Saver | Support              |

@TestCase:73791
Scenario: [73791] My Products grid - Retailers Column Alphabetical Order
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Then The home screen should load
	Given I filter the products by: Accepted by Retailers
	And I check for all items in the grid that the retailers are alphabetically listed

#Removed from regression: 2023/08
@ignore
@TestCase:55796
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
