@LandingPage
@Login
@Homepage
@ForgottenPassword
@wercsmart
@Signup
@run_ForgottenPassword

Feature: Forgotten Password

# Will need to create a user for this to work! Don't use the master

Background:
Given I go to the WERCSmart Log in

Scenario: [52962] Forgot Password - Registered Email

Given I click on the Forgot Your Password Link
And I click the continue button
Then In the Forgotten Password window I should see the following error messages: This is a required field.
Then I should remain on the Forgotten Password dialog
Given I enter a email address: automatedcompany1@gmail.com
And I click the continue button
Then the message should contain Please check your email to get instructions on how to reset your password.
Then I click the login button in the Forgotten Password window

Scenario: [52969] Forgot Password - Unregistered Email
Given I create an email myunregisteredaccount and save it as myunregisteredaccount
Given I save the current emails in the inbox for address saved as: myunregisteredaccount
Given I click on the Forgot Your Password Link
Given I enter an email address: savedas myunregisteredaccount
And I click the continue button
Then the message should contain Please check your email to get instructions on how to reset your password.
Then there should be a new email for email Address saved as: myunregisteredaccount from: <SiteNotification> with the title: WERCSmart Account Information
And the body of the email should show: Dear Future WERCSmart User: Recently you attempted to access WERCSmart and indicated you forgot your password. Our records do not show your email to be registered as a User of WERCSmart at this time. We recommend you create an account.Important Notice: This e-mail may contain privileged or confidential information. If you are not the intended recipient: (1) you may not disclose, use, distribute, copy or rely upon this message or attachment(s); and (2) please notify UL Information and Insights Inc. (“UL”) at WERCSmartCustomer@ul.com, and then delete this message and its attachment(s). UL and its affiliates disclaim all liability for any errors, omissions, corruption or virus in this message or any attachments.

Scenario: [53035] Forgot Password - Badly Formatted Email
Given I click on the Forgot Your Password Link
Given I enter a email address: abc123.tt@j
And I click the continue button
Then In the Forgotten Password window I should see the following error messages: Email is not valid.
And I click the cancel button
Then I should see for the forgotten password: Forgot your Password?

Scenario: [53048] Forgot Password - Reset Password
Given I create an email registeredaccount and save it as registeredaccount
Given I click on the Forgot Your Password Link
Given I enter a email address: automatedcompany1@gmail.com
And I click the continue button
Then in the recieved email I should see the title: WERCSmart Password Reset
Then there should be a new email for email Address saved as: myunregisteredaccount from: <SiteNotification> with the title: WERCSmart Account Information
And the body of the email should show: Dear WERCSmart User, You recently requested to reset the password associated with your account. Please click on the link to reset your password. This link will expire in 30 minutes. If you did not request to have your password reset, immediately contact Support at +1 (877) 642-6753. Thank you. WERCSmart Support
When I click the link in the email I get directed to security questions

