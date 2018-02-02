@LandingPage
@Login
@Homepage
@ForgottenPassword
@wercsmart
@run_ForgottenPassword

Feature: Forgotten Password

# Will need to create a user for this to work! Don't use the master

Background:
Given I go to the WERCSmart Log in

Scenario: Forgot Password - Registered Email
Given I login as the administrator
Given I logout

Given I click on the Forgot Your Password Link
And I click the next button
Then I should remain on the Forgotten Password dialog
Given I enter a email address: Thisemail@email.com
And I click the continue button
Then I should see a confirmation message saying: Please check your email to get instructions on how to reset your password.

Scenario: Forgot Password - Unregistered Email 
Given I click on the Forgot Your Password Link
Given I enter a unregistered email address
And I click the continue button
Then I should see a error message saying: Your username or password is either missing or entered correctly. Please correct your entries and try again.

Scenario: Forgot Password - Badly Formatted Email
Given I click on the Forgot Your Password Link
Given I enter a invalid email address
And I click the continue button
Then I should see a error message saying: Email is not valid.

Scenario: Forgot Password - Reset Password
Given I click on the Forgot Your Password Link
Given I enter a registered email address
And I click the continue button
Then in the recieved email I should see the title: WERCSmart Password Reset
And the body of the email should show: Dear WERCSmart User, You recently requested to reset the password associated with your account. Please click on the link to reset your password. This link will expire in 30 minutes. If you did not request to have your password reset, immediately contact Support at +1 (877) 642-6753. Thank you. WERCSmart Support
When I click the link in the email I get directed to security questions

