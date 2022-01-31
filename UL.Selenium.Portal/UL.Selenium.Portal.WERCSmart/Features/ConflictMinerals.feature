@Shared
@LandingPage
@Login
@Homepage
@Signup
@wercsmart
@NewProduct
@ProductGrid
@DataSummarySheet
@wercsmart
@RetailPartners
@ConflictMinerals
@run_conflictminerals

Feature: Conflict Mineral
#The feature appears to be obsolete

Background:
#Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
#Given If I see the retail partners page I set all data consent tiers to true for all retailers in the top section
#Then The home screen should load


@TestCase:68211
Scenario: [68211] Conflict Minerals - Create a new company
Given I create a new email address and save as: Myemail
Given I navigate to the URL: https://secure.supplierwercs.com/Home/ssologin?sourceService=cm
Then the Conflict Minerals page should load
Given in the Conflict Minerals page I click on Create Company Account
Then in the Conflict Minerals page the New Email form should have loaded
Given in the Conflict Minerals page I put in email account: saved as Myemail
Given in the Conflict Minerals page I click on Next
Then in the Conflict Minerals page the Create Company Account form should have loaded
Given in the Conflict Minerals page I create enter Company Details as follows:
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
Given in the Conflict Minerals page I click on Next
Then in the Conflict Minerals page the Company Contact Person form should have loaded
Then in the Conflict Minerals page the Company Contact Person form email value is: saved as Myemail
Given in the Conflict Minerals page I create enter Company Contact Person as follows:
| Field             | Value                  |
| Contact           | Jane Richardson        |
| Phone Number      | 785-532-6413           |
| Additional Emails | richardSmith@smith.com |
| Password          | Welcome1!              |
| City              | London                 |
| Model             | Fiat Uno               |
| Sport             | Basketball             |
| Food              | Profiteroles           |
| Vacation          | New Zealand            |
| IdentityPassword  | Welcome1!              |
Given in the Conflict Minerals page I click on Next
Then I should see a congratulations page
Then I confirm that I have received a Signup confirmation email to account: saved as Myemail
Then I confirm that I have received a CARP account email to account: saved as Myemail
Then I confirm that I have a received a Verification code email to account: saved as Myemail
Given I save the verification code sent to account: saved as Myemail as: Myverificationcode
Given I click on the login button on the congratulations page
Then the Conflict Minerals page should load
Given in the Conflict Minerals login page I enter Email address: saved as Myemail
Given in the Conflict Minerals login page I enter Password: Welcome1!
Given in the Conflict Minerals login page I click on the Login button
Then if an error message shows I retry entering password: Welcome1! and clicking on login
Then the Conflict Minerals Verification page should load
Then In the Conflict Minerals Verification page I enter verification code: saved as Myverificationcode
Then In the Conflict Minerals Verification page I click Verify
Then the Conflict Minerals terms of use page should load
Then in the Conflict Minerals terms of use I check the Accept checkbox
Then in the Conflict Minerals terms of use I click continue
Then in the Conflict Minerals I should see the dashboard
Then in the Conflict Minerals I confirm I see my email address in the header: saved as Myemail





