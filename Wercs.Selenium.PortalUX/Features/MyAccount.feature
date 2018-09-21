@Homepage
@Login
@Signup
@MyAccount
@wercsmart
@SubEnrollment
@LandingPage
@PaymentMethods
@run_MyAccount

Feature: MyAccount

@tfs_design
Scenario: [61796] Account User Name in Header
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load
Then I should see user name: AllRetailers, ProductsCompany in the header next to the user icon
Given I click on My Account
And I should see the heading: My Account on the My Account page
Given I save all the users in the User Grid
Given I go to Details in User Grid for the current user
Given In the UserDetails screen I save the current User as: ThisUser
Given In the UserDetails page I set Name to be: Richard Smith
Given In the UserDetails page I click Save
Then In the User Grid the user saved as: ThisUser has been replaced by: Richard Smith
Then I should see user name: Richard Smith in the header next to the user icon
Given I click on My Account
Given I go to Details in User Grid for the current user
Given In the UserDetails page I set Name to be: saved as ThisUser
Given In the UserDetails page I click Save
Then I should see user name: AllRetailers, ProductsCompany in the header next to the user icon

@tfs_design
Scenario: [63514] Create a New User on the User Grid
Given I Login into WERCSmart Portal - Admin Role - WERCs Visual Account
Then The home screen should load
Given I click on My Account
Then I create a new email address
Then I add a new user with the following information
| User Name | Title | Role | Phone Number | Email Address | Confirm Email | Country Code | Country        |
| User      | Mr    | User | 123-456-7889 | Saved         | Saved         | empty        | United Kingdom |
Then I confirm the new user is Active

Scenario: [64874] Division Area - no divisions set up
Given I Login into WERCSmart Portal - Admin Role - WERCs Visual Account
And I navigate to My Account
And I click on the option Division Accounts
And I should not see the Division Accounts grid
And In the My Account page I navigate to the Company Information page
Then In the Company Information screen I should see 0 Division Accounts

Scenario: [65887] Pagination

Given I Login into WERCSmart Portal - Admin Role - WERCs Visual Account

Then The home screen should load

Given I navigate to the MyAccount page

Then The My Account user grid is currently on page number: 1

Given I click next in the My Account user grid

Then The My Account user grid is currently on page number: 2

Given I click previous in the My Account user grid

Then The My Account user grid is currently on page number: 1


# Requires 9 pages of users (not 6 as the test case states)
@tfs_design
Scenario: [70511] Pagination (...) need an account with six pages of users

Given I Login into WERCSmart Portal - Admin Role - WERCs Visual Account

Given I click on My Account

Given I click ... in the My Account user grid

Given I see the user grid page navigation input with up and down arrows

Given I type the number 2 into the user grid page navigation box and press the enter key

Then The My Account user grid is currently on page number: 2

Given I click ... in the My Account user grid

Given I enter the up arrow into the user grid page navigation box then the correct page is shown

Given I click ... in the My Account user grid

Given I enter the down arrow into the user grid page navigation box then the correct page is shown

Scenario: [68417] Company Information

Given I Login into WERCSmart Portal - Admin Role - WERCs Visual Account

Given I click on My Account

Given In the My Account page I navigate to the Company Information page

Then In the Company Information page I confirm the Company Information is correct
| Company Name | Admin Name                | Email Address   | Supplier Type | Country       | Address                  | City   | State | Zip Code | Country Code | Phone        |
| Visual       | Automated, Visual Company | <VisualAccount> | Manufacturer  | United States | 31 British American Blvd | Latham | NY    | 12110    | 1            | 555-555-5555 |

