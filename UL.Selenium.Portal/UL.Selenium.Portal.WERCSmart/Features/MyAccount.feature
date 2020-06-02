@Shared
@Homepage
@Login
@Signup
@MyAccount
@wercsmart
@SubEnrollment
@LandingPage
@PaymentMethods
@Freshdesk
@subUpgrade
@RetailPartners
@run_MyAccount
Feature: MyAccount

@ScenarioId:734
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


@ScenarioId:6704
Scenario: [63514] Add and Deactivate a New User from the User Grid
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Then The home screen should load
	Given I click on My Account
	Then I call Shared Step 63511 (Create New User via User Grid)
	Then I create a new email address
	Then I add a new user with the following information
		| User Name | Title | Role | Phone Number | Email Address | Confirm Email | Country Code | Country        |
		| User      | Mr    | User | 123-456-7889 | Saved         | Saved         | empty        | United Kingdom |
	Then I confirm the new user is Active
	Given I Select the ... from the Actions column of the account I just created and select Deactivate
	Then I Wait for a modal popup to appear
	And I Click approve in dialog
	And I Click close in dialog
	Then I confirm the new user is Not Active
	Given I Select the ... from the Actions column of the account I just created and select Activate
	And I Click close in dialog
	Then I confirm the new user is Active
	Then I Select the ... from the Actions column of the account I just created and select Deactivate
	Then I Wait for a modal popup to appear
	And I Click approve in dialog

@ScenarioId:735
Scenario: [64874] Division Area - no divisions set up
	Given I Login into WERCSmart Portal - Admin Role - WERCs Visual Account
	And I navigate to My Account
	And I click on the option Division Accounts
	And I should not see the Division Accounts grid
	And In the My Account page I navigate to the Company Information page
	Then In the Company Information screen I should see 0 Division Accounts

@ScenarioId:736
Scenario: [65887] Pagination
	#CLF 25/6/2019 Changed login account to one that has enough products to page through
	#Given I Login into WERCSmart Portal - Admin Role - WERCs Visual Account
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I navigate to the MyAccount page
	Then I Create new users in the My Account page via the user Grid until there are atleast: 2 pages present
	Then The My Account user grid is currently on page number: 1
	Given I click next in the My Account user grid
	Then The My Account user grid is currently on page number: 2
	Given I click previous in the My Account user grid
	Then The My Account user grid is currently on page number: 1

@ScenarioId:6339
Scenario: [70511] Pagination (...) need an account with six pages of users
	#CLF 25/6/2019 Changed login account to one that has enough products to page through
	#Given I Login into WERCSmart Portal - Admin Role - WERCs Visual Account
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I click on My Account
	#Given I check that there are at least 6 pages of users. If not this test will not work.
	Then I Create new users in the My Account page via the user Grid until there are atleast: 10 pages present
	Given I click ... in the My Account user grid
	Given I see the user grid page navigation input with up and down arrows
	Given I type the number 2 into the user grid page navigation box and press the enter key
	Then The My Account user grid is currently on page number: 2
	Given I click ... in the My Account user grid
	Given I enter the up arrow into the user grid page navigation box then the correct page is shown
	Given I click ... in the My Account user grid
	Given I enter the down arrow into the user grid page navigation box then the correct page is shown

@ScenarioId:737
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
@ScenarioId:738
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


@ScenarioId:739
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

@ScenarioId:1515
Scenario: [90197] Active and Inactive Filter on Your Company User Accounts grid
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I call Shared Step 62676 (Go To My Account)
	Given I call Shared Step 63511 (Create New User via User Grid)
	And I Select the Active filter
	And I Confirm that you See the user you just created in the grid
	And I confirm the new user is Active
	Given I Select the ... from the Actions column of the account I just created and select Deactivate
	And I Click approve in dialog
	And I Click close in dialog	
	And I Confirm that you Don't See the user you just created in the grid
	And I Select the Inactive filter
	And I Confirm that you See the user you just created in the grid
	And I confirm the new user is Not Active


@ScenarioId:1590
Scenario: [85512] My Account - Edit Stewardship Numbers - Cancel button
	Given I Login into WERCSmart Portal - Admin Role - WERCs Visual Account
	And I navigate to My Account
	And In the My Account page I navigate to the Company Information page
	And In Stewardship table click edit
	And I add following stewardship information
		| Province         | Stewardship   |
		| British Columbia | BC-1-1        |
		| Saskatchewan     | SA-1-1        |
	And In Stewardship table I click: Cancel
	And I confirm the pop up shows the heading: Are you sure you wish to cancel?
	And I confirm that I see the following text in the modal window popup: If you cancel, any changes will be lost. Continue?
	And in the modal dialog I click Yes
	And I confirm that I do not see any stewardship information

	@ScenarioId:6057
Scenario: [85513] My Account - Edit Stewardship Numbers - Save button
Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
Then the WERCSmart homepage should load
Given I call Shared Step 62676 (Go To My Account)
And In the My Account page I navigate to the Company Information page
Then I click on the 'Edit' button in Company information in the Stewardship Numbers section
Then I fill in Stweardship Numbers information
| Stewardship | Issue Date | Expire Date |
| test123     | 2019-01-30 | Tomorrow    |
| test123     | 2019-01-30 | Tomorrow    |
| test123     | 2019-01-30 | Tomorrow    |
| test123     | 2019-01-30 | Tomorrow    |
| test123     | 2019-01-30 | Tomorrow    |
Then I save Stewardship Numbers information
Then I confirm that the data saved in the Stewardshp Numbers section is correct
| Stewardship | Issue Date | Expire Date |
| test123     | 2019-01-30 | Tomorrow    |
| test123     | 2019-01-30 | Tomorrow    |
| test123     | 2019-01-30 | Tomorrow    |
| test123     | 2019-01-30 | Tomorrow    |
| test123     | 2019-01-30 | Tomorrow    |


@ScenarioId:6056
Scenario: [85258] My Account - Stewardship Numbers - table display validation
Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
Then the WERCSmart homepage should load
Given I call Shared Step 62676 (Go To My Account)
And In the My Account page I navigate to the Company Information page
Then I check that a heading with the name: Stewardship Numbers exists
Then I check if there is a table in the Stewardship Numbers section
Then I find out how many rows are in the table in the Stewardship Numbers section
Then I check if the Stewardship Numbers table columns names match the following column names
| Column Name   |
| Province      |
| Stewardship   |
| Issue Date    |
| Expire Date   |
Then I check if the Stewardship Numbers table province names match the following province names
| Province Name    |
| British Columbia |
| Saskatchewan     |
| Manitoba         |
| Ontario          |
| Quebec           |
Then I check if 'Edit' button exists in the Stewardship Numbers section


@ScenarioId:6063
Scenario: [97846] - Company Information - Verify the 'State' drop-down is Available
And I call Shared Step 67284 (Login into WERCSmart Portal - Visual Automation Account)
Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
Then the WERCSmart homepage should load
Given I call Shared Step 62676 (Go To My Account)
And In the My Account page I navigate to the Company Information page
Then I click on the 'Edit' button in Company information in the Billing Address section
Then I select the state: Alabama in the Billing Address section
Then I click the 'Save' button in the Billing Address section
Then I confirm that the correct state: Alabama has been saved in the Billing Address
Then I click on the 'Edit' button in Company information in the Shipping Address section
Then I select the state: Wyoming in the Shipping Address section
Then I click the 'Save' button in the Shipping Address section
Then I confirm that the correct state: Wyoming has been saved in the Shipping Address
Then I click the User Icon
And I click on Sign Out


@ScenarioId:6069
Scenario: [53694] - User Role - Reset Password
Given I Login into WERCSmart Portal - Admin Role - Password Reset
Then the WERCSmart homepage should load
Given I call Shared Step 62676 (Go To My Account)
Given I go to Reset Password in User Grid for the current user
#Then I call a Shared Step to create a new password: Welcome22!
Then I call a Shared Step to create a new password for the account saved as: PasswordResetAccount
Then I click the User Icon
And I click on Sign Out
Given I Login into WERCSmart Portal - Admin Role - Password Reset


@ScenarioId:6137
#When running this, update the date 2019-12-09 to whatever the current date is
#Update the date in the above sentence to avoid future confusion
Scenario: [87349] - My Account - Edit Stewardship Numbers - Date validation
Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
Then the WERCSmart homepage should load
Given I call Shared Step 62676 (Go To My Account)
And In the My Account page I navigate to the Company Information page

Then I pass the following data to the Stweardship Numbers table
| Stewardship       | Issue Date | Expire Date |
| testingCurrentRow | 2020-12-30 | 2020-01-30  |
| test              | 2019-01-30 | 2020-01-30  |
| test              | 2019-01-30 | 2020-01-30  |
| test              | 2019-01-30 | 2020-01-30  |
| test              | 2019-01-30 | 2020-01-30  |
Then I save the Stewardship Numbers data
Given I look for the error: Date must be prior to current date. in the row with the province: British Columbia

Then I pass the following data to the Stweardship Numbers table
| Stewardship       | Issue Date | Expire Date |
| testingCurrentRow | 2019-12-08 | 2020-01-30  |
| test              | 2019-01-30 | 2020-01-30  |
| test              | 2019-01-30 | 2020-01-30  |
| test              | 2019-01-30 | 2020-01-30  |
| test              | 2019-01-30 | 2020-01-30  |
Then I save the Stewardship Numbers data
Given I look for the error: No Error in the row with the province: British Columbia

Then I pass the following data to the Stweardship Numbers table
| Stewardship       | Issue Date | Expire Date |
| testingCurrentRow | 2019-12-08 | 2019-12-08  |
| test              | 2019-01-30 | 2020-01-30  |
| test              | 2019-01-30 | 2020-01-30  |
| test              | 2019-01-30 | 2020-01-30  |
| test              | 2019-01-30 | 2020-01-30  |
Then I save the Stewardship Numbers data
Given I look for the error: Date must be later than current date. in the row with the province: British Columbia

Then I pass the following data to the Stweardship Numbers table
| Stewardship       | Issue Date | Expire Date |
| testingCurrentRow | 2019-12-08 | 2019-12-08  |
| test              | 2019-01-30 | 2020-01-30  |
| test              | 2019-01-30 | 2020-01-30  |
| test              | 2019-01-30 | 2020-01-30  |
| test              | 2019-01-30 | 2020-01-30  |
Then I save the Stewardship Numbers data
Given I look for the error: Date must be later than current date. in the row with the province: British Columbia

Then I pass the following data to the Stweardship Numbers table
| Stewardship       | Issue Date | Expire Date |
| testingCurrentRow | 2019-12-08 | 2020-12-09  |
| test              | 2019-01-30 | 2020-01-30  |
| test              | 2019-01-30 | 2020-01-30  |
| test              | 2019-01-30 | 2020-01-30  |
| test              | 2019-01-30 | 2020-01-30  |
Then I save the Stewardship Numbers data
Given I look for the error: No Error in the row with the province: British Columbia









Then I pass the following data to the Stweardship Numbers table
| Stewardship       | Issue Date | Expire Date |
| test              | 2019-01-30 | 2020-01-30  |
| testingCurrentRow | 2020-12-30 | 2020-01-30  |
| test              | 2019-01-30 | 2020-01-30  |
| test              | 2019-01-30 | 2020-01-30  |
| test              | 2019-01-30 | 2020-01-30  |
Then I save the Stewardship Numbers data
Given I look for the error: Date must be prior to current date. in the row with the province: Saskatchewan

Then I pass the following data to the Stweardship Numbers table
| Stewardship       | Issue Date | Expire Date |
| test              | 2019-01-30 | 2020-01-30  |
| testingCurrentRow | 2019-12-08 | 2020-01-30  |
| test              | 2019-01-30 | 2020-01-30  |
| test              | 2019-01-30 | 2020-01-30  |
| test              | 2019-01-30 | 2020-01-30  |
Then I save the Stewardship Numbers data
Given I look for the error: No Error in the row with the province: Saskatchewan

Then I pass the following data to the Stweardship Numbers table
| Stewardship       | Issue Date | Expire Date |
| test              | 2019-01-30 | 2019-01-30  |
| testingCurrentRow | 2019-12-08 | 2019-12-08  |
| test              | 2019-01-30 | 2020-01-30  |
| test              | 2019-01-30 | 2020-01-30  |
| test              | 2019-01-30 | 2020-01-30  |
Then I save the Stewardship Numbers data
Given I look for the error: Date must be later than current date. in the row with the province: Saskatchewan

Then I pass the following data to the Stweardship Numbers table
| Stewardship       | Issue Date | Expire Date |
| test              | 2019-01-30 | 2019-01-30  |
| testingCurrentRow | 2019-12-08 | 2019-12-08  |
| test              | 2019-01-30 | 2020-01-30  |
| test              | 2019-01-30 | 2020-01-30  |
| test              | 2019-01-30 | 2020-01-30  |
Then I save the Stewardship Numbers data
Given I look for the error: Date must be later than current date. in the row with the province: Saskatchewan

Then I pass the following data to the Stweardship Numbers table
| Stewardship       | Issue Date | Expire Date |
| test              | 2019-01-30 | 2019-01-30  |
| testingCurrentRow | 2019-12-08 | 2020-12-09  |
| test              | 2019-01-30 | 2020-01-30  |
| test              | 2019-01-30 | 2020-01-30  |
| test              | 2019-01-30 | 2020-01-30  |
Then I save the Stewardship Numbers data
Given I look for the error: No Error in the row with the province: Saskatchewan









Then I pass the following data to the Stweardship Numbers table
| Stewardship       | Issue Date | Expire Date |
| test              | 2019-01-30 | 2020-01-30  |
| test              | 2019-01-30 | 2020-01-30  |
| testingCurrentRow | 2020-12-30 | 2020-01-30  |
| test              | 2019-01-30 | 2020-01-30  |
| test              | 2019-01-30 | 2020-01-30  |
Then I save the Stewardship Numbers data
Given I look for the error: Date must be prior to current date. in the row with the province: Manitoba

Then I pass the following data to the Stweardship Numbers table
| Stewardship       | Issue Date | Expire Date |
| test              | 2019-01-30 | 2020-01-30  |
| test              | 2019-01-30 | 2020-01-30  |
| testingCurrentRow | 2019-12-08 | 2020-01-30  |
| test              | 2019-01-30 | 2020-01-30  |
| test              | 2019-01-30 | 2020-01-30  |
Then I save the Stewardship Numbers data
Given I look for the error: No Error in the row with the province: Manitoba

Then I pass the following data to the Stweardship Numbers table
| Stewardship       | Issue Date | Expire Date |
| test              | 2019-01-30 | 2019-01-30  |
| test              | 2019-01-30 | 2020-01-30  |
| testingCurrentRow | 2019-12-08 | 2019-12-08  |
| test              | 2019-01-30 | 2020-01-30  |
| test              | 2019-01-30 | 2020-01-30  |
Then I save the Stewardship Numbers data
Given I look for the error: Date must be later than current date. in the row with the province: Manitoba

Then I pass the following data to the Stweardship Numbers table
| Stewardship       | Issue Date | Expire Date |
| test              | 2019-01-30 | 2019-01-30  |
| test              | 2019-01-30 | 2020-01-30  |
| testingCurrentRow | 2019-12-08 | 2019-12-08  |
| test              | 2019-01-30 | 2020-01-30  |
| test              | 2019-01-30 | 2020-01-30  |
Then I save the Stewardship Numbers data
Given I look for the error: Date must be later than current date. in the row with the province: Manitoba

Then I pass the following data to the Stweardship Numbers table
| Stewardship       | Issue Date | Expire Date |
| test              | 2019-01-30 | 2019-01-30  |
| test              | 2019-01-30 | 2020-01-30  |
| testingCurrentRow | 2019-12-08 | 2020-12-09  |
| test              | 2019-01-30 | 2020-01-30  |
| test              | 2019-01-30 | 2020-01-30  |
Then I save the Stewardship Numbers data
Given I look for the error: No Error in the row with the province: Manitoba








Then I pass the following data to the Stweardship Numbers table
| Stewardship       | Issue Date | Expire Date |
| test              | 2019-01-30 | 2020-01-30  |
| test              | 2019-01-30 | 2020-01-30  |
| test              | 2019-01-30 | 2020-01-30  |
| testingCurrentRow | 2020-12-30 | 2020-01-30  |
| test              | 2019-01-30 | 2020-01-30  |
Then I save the Stewardship Numbers data
Given I look for the error: Date must be prior to current date. in the row with the province: Ontario

Then I pass the following data to the Stweardship Numbers table
| Stewardship       | Issue Date | Expire Date |
| test              | 2019-01-19 | 2020-01-30  |
| test              | 2019-01-30 | 2020-01-30  |
| test              | 2019-01-30 | 2020-01-30  |
| testingCurrentRow | 2020-12-30 | 2020-01-30  |
| test              | 2019-01-30 | 2020-01-30  |
Then I save the Stewardship Numbers data
Given I look for the error: No Error in the row with the province: Ontario

Then I pass the following data to the Stweardship Numbers table
| Stewardship       | Issue Date | Expire Date |
| test              | 2019-01-30 | 2019-01-30  |
| test              | 2019-01-30 | 2020-01-30  |
| test              | 2019-01-30 | 2020-01-30  |
| testingCurrentRow | 2019-12-08 | 2019-12-08  |
| test              | 2019-01-30 | 2020-01-30  |
Then I save the Stewardship Numbers data
Given I look for the error: Date must be later than current date. in the row with the province: Ontario

Then I pass the following data to the Stweardship Numbers table
| Stewardship       | Issue Date | Expire Date |
| test              | 2019-01-30 | 2019-01-30  |
| test              | 2019-01-30 | 2020-01-30  |
| test              | 2019-01-30 | 2020-01-30  |
| testingCurrentRow | 2019-12-08 | 2019-12-08  |
| test              | 2019-01-30 | 2020-01-30  |
Then I save the Stewardship Numbers data
Given I look for the error: Date must be later than current date. in the row with the province: Ontario

Then I pass the following data to the Stweardship Numbers table
| Stewardship       | Issue Date | Expire Date |
| test              | 2019-01-30 | 2019-01-30  |
| test              | 2019-01-30 | 2020-01-30  |
| test              | 2019-01-30 | 2020-01-30  |
| testingCurrentRow | 2019-12-08 | 2020-12-09  |
| test              | 2019-01-30 | 2020-01-30  |
Then I save the Stewardship Numbers data
Given I look for the error: No Error in the row with the province: Ontario









Then I pass the following data to the Stweardship Numbers table
| Stewardship | Issue Date | Expire Date |
| test              | 2019-01-30 | 2020-01-30  |
| test              | 2019-01-30 | 2020-01-30  |
| test              | 2019-01-30 | 2020-01-30  |
| test              | 2019-01-30 | 2020-01-30  |
| testingCurrentRow | 2020-12-30 | 2020-01-30  |
Then I save the Stewardship Numbers data
Given I look for the error: Date must be prior to current date. in the row with the province: Quebec

Then I pass the following data to the Stweardship Numbers table
| Stewardship | Issue Date | Expire Date |
| test              | 2019-01-19 | 2020-01-30  |
| test              | 2019-01-30 | 2020-01-30  |
| test              | 2019-01-30 | 2020-01-30  |
| test              | 2019-01-30 | 2020-01-30  |
| testingCurrentRow | 2020-12-30 | 2020-01-30  |
Then I save the Stewardship Numbers data
Given I look for the error: No Error in the row with the province: Quebec

Then I pass the following data to the Stweardship Numbers table
| Stewardship | Issue Date | Expire Date |
| test              | 2019-01-30 | 2019-01-30  |
| test              | 2019-01-30 | 2020-01-30  |
| test              | 2019-01-30 | 2020-01-30  |
| test              | 2019-01-30 | 2020-01-30  |
| testingCurrentRow | 2019-12-08 | 2019-12-08  |
Then I save the Stewardship Numbers data
Given I look for the error: Date must be later than current date. in the row with the province: Quebec

Then I pass the following data to the Stweardship Numbers table
| Stewardship | Issue Date | Expire Date |
| test              | 2019-01-30 | 2019-01-30  |
| test              | 2019-01-30 | 2020-01-30  |
| test              | 2019-01-30 | 2020-01-30  |
| test              | 2019-01-30 | 2020-01-30  |
| testingCurrentRow | 2019-12-08 | 2019-12-08  |
Then I save the Stewardship Numbers data
Given I look for the error: Date must be later than current date. in the row with the province: Quebec

Then I pass the following data to the Stweardship Numbers table
| Stewardship | Issue Date | Expire Date |
| test              | 2019-01-30 | 2019-01-30  |
| test              | 2019-01-30 | 2020-01-30  |
| test              | 2019-01-30 | 2020-01-30  |
| test              | 2019-01-30 | 2020-01-30  |
| testingCurrentRow | 2019-12-08 | 2020-12-09  |
Then I save the Stewardship Numbers data
Given I look for the error: No Error in the row with the province: Quebec









Then I pass the following data to the Stweardship Numbers table
| Stewardship | Issue Date | Expire Date |
|             |            |             |
|             |            |             |
|             |            |             |
|             |            |             |
|             |            |             |
Then I save the Stewardship Numbers data
