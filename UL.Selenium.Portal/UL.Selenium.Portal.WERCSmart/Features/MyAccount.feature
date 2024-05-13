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

@TestCase:61796
Scenario: [61796] Account User Name in Header
	Given I log in with the account saved in TReVor as: NoProductsAccount
	Then The home screen should load
	#CLF 25/6/2019 changed step because the username of this account does not seem to be reliable.
	Then I should see a user name in the header next to the user icon
	Given I click on My Account
	And I should see the heading: My Account on the My Account page
	Given I save all the users in the User Grid
	Given I go to Details in User Grid for the current user
	Given In the UserDetails screen I save the current User as: ThisUser
	Given In the UserDetails page I set Name to be: <RandomString>
	Given In the UserDetails page I click Save
	Then In the User Grid the user saved as: ThisUser has been replaced by: <RandomString>
	Then I should see user name: <RandomString> in the header next to the user icon
	Given I click on My Account
	Given I go to Details in User Grid for the current user
	Given In the UserDetails page I set Name to be: saved as ThisUser
	Given In the UserDetails page I click Save
	Then I should see user name: saved as ThisUser in the header next to the user icon


@TestCase:63514
Scenario: [63514] Add and Deactivate a New User from the User Grid
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Then The home screen should load
	Given I click on My Account
	Then I create a new email address
	Then I add a new user with the following information
		| User Name | Title | Role | Phone Number | Email Address | Confirm Email | Country Code | Country        |
		| User      | Mr    | User | 123-456-7889 | Saved         | Saved         | empty        | United Kingdom |
	Then I search for user with email
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

#Removed from regression 2024/04
@ignore
@TestCase:64874
Scenario: [64874] Division Area - no divisions set up
	Given I Login into WERCSmart Portal - Admin Role - WERCs Visual Account
	And I navigate to My Account
	And I click on the option Division Accounts
	And I should not see the Division Accounts grid
	And In the My Account page I navigate to the Company Information page
	Then In the Company Information screen I should see 0 Division Accounts

@TestCase:65887
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

@TestCase:85258
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
	Then I pass the following data to the Stweardship Numbers table
		| Stewardship       | Issue Date | Expire Date |
		| testingCurrentRow | 2024-12-30 | 2024-01-30  |
		| test              | 2023-01-30 | 2024-01-30  |
		| test              | 2019-01-30 | 2024-01-30  |
		| test              | 2019-01-30 | 2024-01-30  |
		| test              | 2019-01-30 | 2024-01-30  |
	Then I save the Stewardship Numbers data
	Given I look for the error: Date must be prior to current date. in the row with the province: British Columbia
	Then I pass the following data to the Stweardship Numbers table
		| Stewardship       | Issue Date | Expire Date |
		| testingCurrentRow | 2019-12-08 | 2024-01-30  |
		| test              | 2019-01-30 | 2024-01-30  |
		| test              | 2019-01-30 | 2024-01-30  |
		| test              | 2019-01-30 | 2024-01-30  |
		| test              | 2019-01-30 | 2024-01-30  |
	Then I save the Stewardship Numbers data
	Given I look for the error: No Error in the row with the province: British Columbia
	Then I pass the following data to the Stweardship Numbers table
		| Stewardship       | Issue Date | Expire Date |
		| testingCurrentRow | 2019-12-08 | 2019-12-08  |
		| test              | 2019-01-30 | 2024-01-30  |
		| test              | 2019-01-30 | 2024-01-30  |
		| test              | 2019-01-30 | 2024-01-30  |
		| test              | 2019-01-30 | 2024-01-30  |
	Then I save the Stewardship Numbers data	
	Given I look for the error: Date must be later than current date. in the row with the province: British Columbia
	Then I pass the following data to the Stweardship Numbers table
		| Stewardship       | Issue Date | Expire Date |
		| test              | 2019-01-30 | 2024-01-30  |
		| testingCurrentRow | 2024-12-30 | 2024-01-30  |
		| test              | 2019-01-30 | 2024-01-30  |
		| test              | 2019-01-30 | 2024-01-30  |
		| test              | 2019-01-30 | 2024-01-30  |
	Then I save the Stewardship Numbers data
	Given I look for the error: Date must be prior to current date. in the row with the province: Saskatchewan
	Then I pass the following data to the Stweardship Numbers table
		| Stewardship       | Issue Date | Expire Date |
		| test              | 2019-01-30 | 2024-01-30  |
		| testingCurrentRow | 2019-12-08 | 2024-01-30  |
		| test              | 2019-01-30 | 2024-01-30  |
		| test              | 2019-01-30 | 2024-01-30  |
		| test              | 2019-01-30 | 2024-01-30  |
	Then I save the Stewardship Numbers data
	Given I look for the error: No Error in the row with the province: Saskatchewan
	Then I pass the following data to the Stweardship Numbers table
		| Stewardship       | Issue Date | Expire Date |
		| test              | 2019-01-30 | 2024-01-30  |
		| testingCurrentRow | 2019-12-08 | 2022-12-08  |
		| test              | 2019-01-30 | 2025-01-30  |
		| test              | 2019-01-30 | 2024-01-30  |
		| test              | 2019-01-30 | 2024-01-30  |
	Then I save the Stewardship Numbers data
	Given I look for the error: Date must be later than current date. in the row with the province: Saskatchewan
	Then I pass the following data to the Stweardship Numbers table
		| Stewardship       | Issue Date | Expire Date |
		| test              | 2019-01-30 | 2024-01-30  |
		| test              | 2019-01-30 | 2024-01-30  |
		| testingCurrentRow | 2025-12-30 | 2025-01-30  |
		| test              | 2019-01-30 | 2025-01-30  |
		| test              | 2019-01-30 | 2026-01-30  |
	Then I save the Stewardship Numbers data
	Given I look for the error: Date must be prior to current date. in the row with the province: Manitoba
	Then I pass the following data to the Stweardship Numbers table
		| Stewardship       | Issue Date | Expire Date |
		| test              | 2019-01-30 | 2024-01-30  |
		| test              | 2019-01-30 | 2024-01-30  |
		| testingCurrentRow | 2019-12-08 | 2025-01-34  |
		| test              | 2019-01-30 | 2025-01-23  |
		| test              | 2019-01-30 | 2028-01-30  |
	Then I save the Stewardship Numbers data
	Given I look for the error: No Error in the row with the province: Manitoba
	Then I pass the following data to the Stweardship Numbers table
		| Stewardship       | Issue Date | Expire Date |
		| test              | 2019-01-30 | 2034-01-30  |
		| test              | 2019-01-30 | 2025-01-30  |
		| testingCurrentRow | 2019-12-08 | 2019-12-08  |
		| test              | 2019-01-30 | 2025-01-30  |
		| test              | 2019-01-30 | 2024-01-30  |
	Then I save the Stewardship Numbers data
	Given I look for the error: Date must be later than current date. in the row with the province: Manitoba
	Then I pass the following data to the Stweardship Numbers table
		| Stewardship       | Issue Date | Expire Date |
		| test              | 2019-01-30 | 2023-01-30  |
		| test              | 2019-01-30 | 2024-01-30  |
		| test              | 2019-01-30 | 2025-01-30  |
		| testingCurrentRow | 2025-12-30 | 2025-01-30  |
		| test              | 2019-01-30 | 2025-01-30  |
	Then I save the Stewardship Numbers data
	Given I look for the error: Date must be prior to current date. in the row with the province: Ontario
	Then I pass the following data to the Stweardship Numbers table
		| Stewardship       | Issue Date | Expire Date |
		| test              | 2019-01-19 | 2025-01-30  |
		| test              | 2019-01-30 | 2025-01-30  |
		| test              | 2019-01-30 | 2025-01-30  |
		| testingCurrentRow | 2020-12-30 | 2025-01-30  |
		| test              | 2019-01-30 | 2025-01-30  |
	Then I save the Stewardship Numbers data
	Given I look for the error: No Error in the row with the province: Ontario
	Then I pass the following data to the Stweardship Numbers table
		| Stewardship       | Issue Date | Expire Date |
		| test              | 2019-01-30 | 2034-01-30  |
		| test              | 2019-01-30 | 2024-01-30  |
		| test              | 2019-01-30 | 2024-01-30  |
		| testingCurrentRow | 2019-12-08 | 2019-12-08  |
		| test              | 2019-01-30 | 2025-01-30  |
	Then I save the Stewardship Numbers data
	Given I look for the error: Date must be later than current date. in the row with the province: Ontario
	Then I pass the following data to the Stweardship Numbers table
		| Stewardship | Issue Date | Expire Date |
		| test              | 2019-01-30 | 2024-01-30  |
		| test              | 2019-01-30 | 2025-01-30  |
		| test              | 2019-01-30 | 2026-01-30  |
		| test              | 2019-01-30 | 2027-01-30  |
		| testingCurrentRow | 2025-12-30 | 2028-01-30  |
	Then I save the Stewardship Numbers data
	Given I look for the error: Date must be prior to current date. in the row with the province: Quebec

	Then I pass the following data to the Stweardship Numbers table
		| Stewardship | Issue Date | Expire Date |
		| test              | 2019-01-19 | 2024-01-30  |
		| test              | 2019-01-30 | 2024-01-30  |
		| test              | 2019-01-30 | 2024-01-30  |
		| test              | 2019-01-30 | 2024-01-30  |
		| testingCurrentRow | 2020-12-30 | 2024-01-30  |
	Then I save the Stewardship Numbers data
	Given I look for the error: No Error in the row with the province: Quebec
	Then I pass the following data to the Stweardship Numbers table
		| Stewardship | Issue Date | Expire Date |
		| test              | 2019-01-30 | 2034-01-30  |
		| test              | 2019-01-30 | 2025-01-30  |
		| test              | 2019-01-30 | 2025-01-30  |
		| test              | 2019-01-30 | 2025-01-30  |
		| testingCurrentRow | 2019-12-08 | 2019-12-08  |
	Then I save the Stewardship Numbers data
	Given I look for the error: Date must be later than current date. in the row with the province: Quebec
	Then I pass the following data to the Stweardship Numbers table
		| Stewardship | Issue Date | Expire Date |
		|             |            |             |
		|             |            |             |
		|             |            |             |
		|             |            |             |
		|             |            |             |
	Then I save the Stewardship Numbers data
	And I add following stewardship information
		| Province         | Stewardship   |
		| British Columbia | BC-1-1        |
		| Saskatchewan     | SA-1-1        |
	And In Stewardship table I click: Cancel
	And I confirm the pop up shows the heading: Are you sure you wish to cancel?
	And I confirm that I see the following text in the modal window popup: If you cancel, any changes will be lost. Continue?
	And in the modal dialog I click Yes
	And I confirm that I do not see any stewardship information
	Then I click on the 'Edit' button in Company information in the Stewardship Numbers section
	Then I fill in Stweardship Numbers information
		| Stewardship | Issue Date | Expire Date |
		| test123     | 2023-07-03 | Tomorrow    |
		| test123     | 2023-07-03| Tomorrow    |
		| test123     | 2023-07-03 | Tomorrow    |
		| test123     | 2023-07-03 | Tomorrow    |
		| test123     | 2023-07-03 | Tomorrow    |
	Then I save Stewardship Numbers information
	Then I confirm that the data saved in the Stewardshp Numbers section is correct
		| Stewardship | Issue Date | Expire Date |
		| test123     | 2023-07-03 | Tomorrow    |
		| test123     | 2023-07-03| Tomorrow    |
		| test123     | 2023-07-03 | Tomorrow    |
		| test123     | 2023-07-03 | Tomorrow    |
		| test123     | 2023-07-03 | Tomorrow    |
		Then I pass the following data to the Stweardship Numbers table
		| Stewardship | Issue Date | Expire Date |
		|             |            |             |
		|             |            |             |
		|             |            |             |
		|             |            |             |
		|             |            |             |
	Then I save the Stewardship Numbers data

@TestCase:53694
Scenario: [53694] - User Role - Reset Password
	Given I Login into WERCSmart Portal - Admin Role - Password Reset
	Then the WERCSmart homepage should load
	Given I call Shared Step 62676 (Go To My Account)
	Given I go to Reset Password in User Grid for the current user
	Then I call a Shared Step to create a new password for the account saved as: PasswordResetAccount
	Given on the Login page I log in as test user: PasswordResetAccount
	Then I click the User Icon
	And I click on Sign Out
	#When running this, update the date 2023-06-28 to whatever the current date is
	#Update the date in the above sentence to avoid future confusion

# Created by Saikiran Chittampally
	@TestCase:219311
Scenario: [219311] Add User: Error Messaging Checks
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Then the WERCSmart homepage should load
	Given I click on My Account
	When I click on Add new User link
	Then I add following new User information
		| User Name | Title | Role | Phone Number | Email Address | Confirm Email | Country Code | Country        |
		| User123     | Mr    | User | 123-456-7889 | EmailAddressGen@kxxyxunf.mailosaur.net   | Abc@gmail.com    | 1234   | United Kingdom |
	Then I confirm following error message displayed for confirm email text box: Email address and confirmation email address do not match. Please make sure both email addresses are the same.
	When I clear the name and email address fields text
	When I paste into confirm email: EmailAddressGen@kxxyxunf.mailosaur.net
	Then I confirm following error message displayed for confirm email text box: You cannot paste text into this textbox!
	Then I confirm following error message displayed for last name input empty text box: This is a required field.	
	Then I add following new User information
		| User Name | Title | Role | Phone Number | Email Address | Confirm Email | Country Code | Country        |
		|   User123   |  Mr   | User | 123-456-7889 |  EmailAddressGen@kxxyxunf.mailosaur.net  |  EmailAddressGen@kxxyxunf.mailosaur.net   | 1234   | United Kingdom |	
	Then I confirm following error message displayed for email text box: User with same email address exists in the system.
	When I clear the name and email address fields text
	Then I confirm following error message displayed for last name input empty text box: This is a required field.	
	Then I confirm following error message displayed for confirm email text box: This is a required field.
	Then In the dialog I click on Cancel
	Given I click on My Account
	Then I create a new email address
	Then I add a new user with the following information
		| User Name | Title | Role | Phone Number | Email Address | Confirm Email | Country Code | Country        |
		| User      | Mr    | User | 123-456-7889 | Saved         | Saved         | empty        | United Kingdom |
	Then I search for user with email
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

	# Created by Saikiran Chittampally
	@TestCase:223554
Scenario: [223554] - User Role- Reset Password Option - Mismatch
	Given I Login into WERCSmart Portal - Admin Role - Password Reset
	Then the WERCSmart homepage should load
	Given I call Shared Step 62676 (Go To My Account)
	Given I go to Reset Password in User Grid for the current user
	When I enter new password and confirm password input fields with diff data: TestPass123 for the account saved as: PasswordResetAccount
	Then I Confirm mismatch error message displayed: Your passwords do not match. Please try again.

	# Created by Saikiran Chittampally
	@TestCase:223555
Scenario: [223555] - User Role- Reset Password Option - Used Too Recently
	Given I Login into WERCSmart Portal - Admin Role - Password Reset
	Then the WERCSmart homepage should load
	Given I call Shared Step 62676 (Go To My Account)
	Given I go to Reset Password in User Grid for the current user
	When I enter new password for the account saved as: PasswordResetAccount
	Then I Confirm following error message displayed: This password was used too recently.

	# Created by Saikiran Chittampally
	@TestCase:223737
Scenario: [223737] - Order History
	Given I log in with the account saved in TReVor as: ProductAccount
	Then the WERCSmart homepage should load
	Given I navigate to My Account
	Given In the My Account page I navigate to the Order History page
	Then I confirm WERCSmart tab is selected by default
	Then I confirm following columns displayed
	| Column Name		    |
	| Submission Date       |
	| Submitted By          |
	| Payment Received Date |
	| Payment Method        |
	| Fee                   |
	| Actions               |
	When I filter Product Name Mixture, Blend, Formula, Polymer or Solution from Third 3rd, 3d Party with action: Filter
	Then I click view details link
	Then I save Description as: testCaseDescription 
	Then I Confirm Product name or wpsId Filter results testCaseDescription are correct : Mixture, Blend, Formula, Polymer or Solution from Third 3rd, 3d Party (1775498)
	Then I Confirm Clear Filter returns correct results: Clear Filter
	Given I filter Product Name 1775498 with action: Filter
	When I Confirm Clear Filter returns correct results: Clear Filter
	When I filter with order Number : 2261769, Filter
	Then I Confirm Filter results are correct: 2261769
	Then I Confirm Clear Filter returns correct results: Clear Filter
	Then I Confirm Clear Filter results are correct: 2261769
	Given I apply filtering with: Completed Status
	When I click on Filter Button
	Then I confirm filtered with the completed status


