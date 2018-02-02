@LandingPage
@Login
@Homepage
@Signup
@MyAccount
@wercsmart
@run_Signup

Feature: Sign Up

Background:
Given I go to the WERCSmart Log in

Scenario: [53069] Signup - Account Creation - Happy Path
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
| CompanyPhone         | 123-456-7889   |
| EmergencyPhoneNumber | 123-456-7789   |
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
Given I go to the WERCSmart Log in
Given I login as user: SignupUser
Given If terms of use page appears I accept
Then the WERCSmart homepage should load
Then I should see username for user saved as: SignupUser in the right corner

Scenario: [52998] Signup - Emails Do Not Match
Given I click on the New to WERCSmart Link
Then the signup page should appear
And I click on submit
Then Under the Enter Email text box the following errors should appear
| Error text                |
| This is a required field. |
Then Under the Confirm Email text box the following errors should appear
| Error text                |
| This is a required field. |
Given I enter signup email: AnyOldUser@fake.com
And I confirm signup email: Different@fake.com
And I click on submit
Then Under the Enter Email text box the following errors should appear
| Error text                                  |
| Email and confirm email fields do not match |

Scenario: [53000] Signup - Copy and Paste Email Address
Given I click on the New to WERCSmart Link
Then the signup page should appear
Given I enter signup email: AnyOldUser@fake.com
Given I copy the current value of the signup email
When I paste into confirm email: AnyOldUser@fake.com
Then I should see popup error: You cannot paste text into this textbox!
Given In the popup error I click on Cancel

Scenario: [57737] New Account - Required fields
Given I define the user: SignupUser2 with the following parameters:
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
| CompanyPhone         | 123-456-4789   |
| EmergencyPhoneNumber | 123-456-4789   |
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

Given I save the current emails in the inbox for user saved as: SignupUser2
Given I click on the New to WERCSmart Link
Then the signup page should appear
Given I enter signup email for user: SignupUser2
And I confirm signup email for user: SignupUser2
And I click on submit
Then the signup thank you page should appear
Then there should be a new email for user: SignupUser2 from: WERCSmartCustomer@ul.com with the title: Link to create WERCSmart Account
Then the email should contain a link to set up the WERCSmart account
When I click on the link I should see the WERCSmart new account page
And In the new user form I click on continue
Then In the Country entry error I see error message: This is a required field.
Then In the First Name entry error I see error message: This is a required field.
Then In the Last Name entry error I see error message: This is a required field.
Then In the Password entry error I see error message: This is a required field.
Then In the Confirm Password entry error I see error message: This is a required field.
Then In the Address 1 entry error I see error message: This is a required field.
Then In the City entry error I see error message: This is a required field.
Then In the State entry error I see error message: This is a required field.
Then In the Zip entry error I see error message: This is a required field.
Then In the Company entry error I see error message: This is a required field.
Then In the Company Phone entry error I see error message: This is a required field.
Then In the Country Code entry error I see error message: This is a required field.
Then In the Emergency Phone Number entry error I see error message: This is a required field.
Then In the Supplier Type entry error I see error message: This is a required field.



And I enter the information into the new user form for user saved as: SignupUser
And In the new user form I click on continue
Then I should be on the Security questions page of the form
And I enter the following into the Security Questions window for user saved as: SignupUser
And I enter the pin: for user saved as: SignupUser
When In the new user form I click on continue
Given I go to the WERCSmart Log in
Given I login as user: SignupUser
Given If terms of use page appears I accept
Then the WERCSmart homepage should load
Then I should see username for user saved as: SignupUser in the right corner

