@LandingPage
@Login
@Homepage
@Signup
@wercsmart
@run_Signup

Feature: Sign Up

Background:
Given I go to the WERCSmart Log in

Scenario: Sign up a new user

Given I define the user: SignupUser with the following parameters:
| Field                | Value          |
| Email                | User_<random>  |
| Country              | UNITED STATES  |
| FirstName            | Richard        |
| LastName             | Smith          |
| Password             | Pa4*ytuufnn    |
| Address1             | Address 1      |
| Address2             | Address 2      |
| City                 | City Name      |
| State                | Florida        |
| Zip                  | 999            |
| CompanyName          | Company 1      |
| CompanyPhone         | 123456789      |
| CountryCode          | 0078           |
| EmergencyPhoneNumber | 123456789      |
| SupplierType         | Manufacturer   |
| CityQuestion         | CityQuestion   |
| CityHint             | CityHint       |
| CarQuestion          | CarQuestion    |
| CarHint              | CarHint        |
| FriendQuestion       | FriendQuestion |
| FriendHint           | FriendHint     |
| JobQuestion          | JobQuestion    |
| JobHint              | JobHint        |
| MascotQuestion       | MascotQuestion |
| MascotHint           | MascotHint     |
| Pin                  | 1234           |

Given I save the current emails in the inbox for user saved as: SignupUser
Given I click on the New to WERCSmart Link
Then the signup page should appear
Given I enter signup email for user: SignupUser
And I confirm signup email for user: SignupUser
And I click on submit
Then the signup thank you page should appear
Then there should be a new email for user: SignupUser from: WERCSmartCustomer@ul.com with the title: Link to create WERCSmart Account
Then the email should contain a link to set up the WERCSmart account
When I click on the link I should see the WERCSmart new account page
And I enter the information into the new user form for user saved as: SignupUser
And In the new user form I click on continue
Then I should be on the Security questions page of the form
And I enter the following into the Security Questions window for user saved as: SignupUser
And I enter the pin: for user saved as: SignupUser
When In the new user form I click on continue


