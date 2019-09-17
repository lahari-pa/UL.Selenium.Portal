@Homepage
@Login
@Signup
@MyAccount
@wercsmart
@SubEnrollment
@LandingPage
@PaymentMethods
@Freshdesk
@run_MyAccount
Feature: MyAccount

@TReVorId:22223
Scenario: [61796] Account User Name in Header
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	#CLF 25/6/2019 changed step because the username of this account does not seem to be reliable.
	#Then I should see user name: Automated, Products in the header next to the user icon
	Then I should see a user name in the header next to the user icon
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
	Then I should see user name: saved as ThisUser in the header next to the user icon

@TReVorId:22076
Scenario: [63514] Add and Deactivate a New User from the User Grid
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I click on My Account
	Then I create a new email address
	Then I add a new user with the following information
		| User Name | Title | Role | Phone Number | Email Address | Confirm Email | Country Code | Country        |
		| User      | Mr    | User | 123-456-7889 | Saved         | Saved         | empty        | United Kingdom |
	Then I confirm the new user is Active
	Given I Select the ... from the Actions column of the account I just created and select Deactivate
	And I Click approve in dialog
	And I Click close in dialog
	Then I confirm the new user is Not Active
	Given I Select the ... from the Actions column of the account I just created and select Activate
	And I Click close in dialog
	Then I confirm the new user is Active
	Then I Select the ... from the Actions column of the account I just created and select Deactivate
	And I Click approve in dialog

@TReVorId:22078
Scenario: [64874] Division Area - no divisions set up
	Given I Login into WERCSmart Portal - Admin Role - WERCs Visual Account
	And I navigate to My Account
	And I click on the option Division Accounts
	And I should not see the Division Accounts grid
	And In the My Account page I navigate to the Company Information page
	Then In the Company Information screen I should see 0 Division Accounts

@TReVorId:13901
Scenario: [65887] Pagination
	#CLF 25/6/2019 Changed login account to one that has enough products to page through
	#Given I Login into WERCSmart Portal - Admin Role - WERCs Visual Account
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I navigate to the MyAccount page
	Then The My Account user grid is currently on page number: 1
	Given I click next in the My Account user grid
	Then The My Account user grid is currently on page number: 2
	Given I click previous in the My Account user grid
	Then The My Account user grid is currently on page number: 1

@TReVorId:22224
Scenario: [70511] Pagination (...) need an account with six pages of users
	#CLF 25/6/2019 Changed login account to one that has enough products to page through
	#Given I Login into WERCSmart Portal - Admin Role - WERCs Visual Account
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I click on My Account
	Given I check that there are at least 6 pages of users. If not this test will not work.
	Given I click ... in the My Account user grid
	Given I see the user grid page navigation input with up and down arrows
	Given I type the number 2 into the user grid page navigation box and press the enter key
	Then The My Account user grid is currently on page number: 2
	Given I click ... in the My Account user grid
	Given I enter the up arrow into the user grid page navigation box then the correct page is shown
	Given I click ... in the My Account user grid
	Given I enter the down arrow into the user grid page navigation box then the correct page is shown

@TReVorId:16677
Scenario: [68417] Company Information
	Given I Login into WERCSmart Portal - Admin Role - WERCs Visual Account
	Given I click on My Account
	Given In the My Account page I navigate to the Company Information page
	Then In the Company Information page I confirm the Company Information is correct
		| Company Name | Admin Name                    | Email Address   | Supplier Type | Country       | Address  | City   | State | Zip Code | Country Code | Phone        |
		| QA_Visual    | WERCS Test_Automation_Lockout | <VisualAccount> | Manufacturer  | United States | Address1 | Latham | FL    | 12205    | 1            | 123-456-7889 |

# Assigned to Paulina Mata
# Created by Larkin, Steve
# Test case can be found at the following paths:
# NetProjects10\WercsSmart Portal\WERCSmart\My Account\Subscription Information
@TReVorId:21429
Scenario: [87304] Video link How to Subscribe
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I click on My Account
	And I click the 'How to Subscribe' link in My Account
	Given I switch to the tab: https://wercsmart.freshdesk.com/en/support/solutions/articles/25000014513-wercsmart-2-0-subscription-enrollment-and-management
	And I save the current window as: Subscription Enrollment and Management
	And In the "WERCSmart 2.0 - Subscription Enrollment and Management" WercSmart Solutions article, I click the link for 'To view a video... click here'
	And I confirm a new tab opens to YouTube with a video titled: WERCSmart Subscription Overview
	And I close the window saved as: YouTube
	And I close the window saved as: Subscription Enrollment and Management


@TReVorId:23507
Scenario: [92613] Add and Deactivate a New User from the User Grid
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 62676 (Go To My Account)
	Given I call Shared Step 63511 (Create New User via User Grid)
	Given I confirm there was an email with title: Welcome to WERCSmart sent to the new user and I click the link with text: support article and video
	Given I confirm the WERCSmart FreshDesk 'Solutions' page is loaded
	Given I confirm there is an article displayed containing the 'WERCSmart Introductory Video'
	Given I navigate to the landing page
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I click on My Account
	Given I Select the ... from the Actions column of the account I just created and select Deactivate
	And I Click approve in dialog
	And I Click close in dialog
	Then I confirm the new user is Not Active
