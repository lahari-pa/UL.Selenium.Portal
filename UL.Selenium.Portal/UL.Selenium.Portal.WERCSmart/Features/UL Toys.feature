@Shared
@wercsmart
@run_ULToys
@ConflictMinerals
@WERCSmart_ChooseGoodGuide

Feature: UL Toys

@tfs_design
@ignore
@TestCase:68368
Scenario: [68368] UL Toys - Create a New Company
Given I navigate to the URL: https://staging.thewercs.com/SHA.MVCWeb/Home/ssologin?sourceService=Toys
Then I click the 'Create Company Account' button
And I enter the Email: <random>
Given I save the current emails in the inbox for address saved as: AccountEmailAddress
And I click the Next button
Given I create an account with the following parameters:
| Field                  | Value             |
| Company Name           | This test company |
| Address                | Address first     |
| Address 2              | Address second    |
| Address 3              | Address third     |
| City                   | City name         |
| State                  | Kansas            |
| Postal Code            | 66506             |
| Country                | United States     |
| Phone Number           | 785-532-6412      |
| Emergency Phone Number | 785-532-6412      |
| Fax                    | 785-532-7408      |
And I click the Next button
And The contact person page should appear
Given I setup the Company Contact Person as follows:
| Field                                       | Value                  |
| Contact                                     | Jane Richardson        |
| Phone Number                                | 785-532-6413           |
| Additional Emails                           | richardSmith@smith.com |
| Password                                    | Welcome1!              |
| What city were you born in?                 | TheWercs               |
| What was the Model of your first car?       | TheWercs               |
| What is your favorite sport?                | TheWercs               |
| What is your favorite food or drink?        | TheWercs               |
| What is your favorite vacation destination? | TheWercs               |
| Secure Password                             | Welcome1!              |
And I click the Next button
Then I wait for the congratulations page to appear
And I confirm that I have received a ULToys account email to account: saved as AccountEmailAddress
And I confirm that I have received a Signup confirmation email to account: saved as AccountEmailAddress
Then I confirm that I have a received a Verification code email to account: saved as AccountEmailAddress
Given I save the verification code sent to account: saved as AccountEmailAddress as: Myverificationcode
Given I click on the login button on the congratulations page
Given on the ULToys login page I enter the Email address: saved as AccountEmailAddress
Given on the ULToys login page I enter the Password: Welcome1!
Then on the ULToys login page I click on the Login button
Then the ULToys Verification page should load
Then on the ULToys Verification page I enter verification code: saved as Myverificationcode
Then on the ULToys Verification page I click Verify
Then the ULToys terms of use page should load
Then on the ULToys terms of use I check the Accept checkbox
Then on the ULToys terms of use I click continue
And the ULToys My Company Details page should load
