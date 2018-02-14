@LandingPage
@Login
@Homepage
@Signup
@ForgottenPassword
@run_ForgottenPassword

Feature: Forgotten Password

# Will need to create a user for this to work! Don't use the master

Background:
Given I go to the WERCSmart Log in

Scenario: [50765] Forgot Password - With Security Questions answered
Given I create a user account with the following parameters saved as: ForgotPasswordUser
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
| CompanyPhone         | 123-456-5789   |
| EmergencyPhoneNumber | 123-456-5789   |
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
And I save the current emails in the inbox for user saved as: ForgotPasswordUser
Then I navigate to the landing page
When I click on the Forgot Your Password Link
And I enter the email address for user saved as: ForgotPasswordUser
And I click the continue button in the Forgotten Password window
Then there should be a new email for user: ForgotPasswordUser from: <SiteNotification> with the title: WERCSmart Password Reset
When I click on the link I should see the WERCSmart new account page

Scenario: [50835] Forgot Password - Email Validation
Given I click on the Forgot Your Password Link
When I click the continue button in the Forgotten Password window
Then In the Forgotten Password window I should see the following error messages: Email address is required
Given I generate a new email address for user saved as EmailValidation
And I enter the email address for user saved as: EmailValidation
When I click the continue button in the Forgotten Password window
Then there should not be a new email for user: EmailValidation from: <SiteNotification> with the title: WERCSmart Password Reset
Then In the Forgotten Password window I should see the following error messages: Email not updated
Given I enter a email address: badlyformatted@nopostext
When I click the continue button in the Forgotten Password window
Then In the Forgotten Password window I should see the following error messages: Format validation error



Scenario: Forgot Password - Registered Email
Given I login as the administrator
Given I logout
Given I click on the Forgot Your Password Link
And I click the next button
Then I should remain on the Forgotten Password dialog
Given I enter a email address: Thisemail@email.com
And I click the continue button in the Forgotten Password window
Then I should see a confirmation message saying: Please check your email to get instructions on how to reset your password.

Scenario: Forgot Password - Unregistered Email
Given I click on the Forgot Your Password Link
Given I enter a unregistered email address
And I click the continue button in the Forgotten Password window
Then I should see a error message saying: Your username or password is either missing or entered correctly. Please correct your entries and try again.

Scenario: Forgot Password - Badly Formatted Email
Given I click on the Forgot Your Password Link
Given I enter a invalid email address
And I click the continue button in the Forgotten Password window
Then I should see a error message saying: Email is not valid.

Scenario: Forgot Password - Reset Password
Given I click on the Forgot Your Password Link
Given I enter a registered email address
And I click the continue button in the Forgotten Password window
Then in the recieved email I should see the title: WERCSmart Password Reset
And the body of the email should show: Dear WERCSmart User, You recently requested to reset the password associated with your account. Please click on the link to reset your password. This link will expire in 30 minutes. If you did not request to have your password reset, immediately contact Support at +1 (877) 642-6753. Thank you. WERCSmart Support
When I click the link in the email I get directed to security questions
