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
Given I create an email automatedcompany1 and save it as automatedcompany1
Given I save the current emails in the inbox for address saved as: automatedcompany1
Given I click on the Forgot Your Password Link
Given I enter a email address: savedas automatedcompany1
And I click the continue button
Then the message should contain Please check your email to get instructions on how to reset your password.
Then I click the login button in the Forgotten Password window
Then there should be a new email for email Address saved as: automatedcompany1 from: <SiteNotification> with the title: WERCSmart Password Reset
And the body of the email should show: Dear WERCSmart User, We received a request to reset the password associated with your account. Please click on the link to reset your password. If you did not request to have your password reset, please contact Customer Support at +1 (877) 642-6753 immediately. If you would like to change your password in the future, please log in to your account and select Reset Password under Actions in the My Account section. Thank you! UL WERCSmart Customer Support Important Notice: This e-mail may contain privileged or confidential information. If you are not the intended recipient: (1) you may not disclose, use, distribute, copy or rely upon this message or attachment(s); and (2) please notify UL Information and Insights Inc. (“UL”) at WERCSmartCustomer@ul.com, and then delete this message and its attachment(s). UL and its affiliates disclaim all liability for any errors, omissions, corruption or virus in this message or any attachments.

Scenario: [52969] Forgot Password - Unregistered Email
Given I create an email myunregisteredaccount and save it as myunregisteredaccount
Given I save the current emails in the inbox for address saved as: myunregisteredaccount
Given I click on the Forgot Your Password Link
Given I enter an email address: savedas myunregisteredaccount
And I click the continue button
Then the message should contain Please check your email to get instructions on how to reset your password.
Then there should be a new email for email Address saved as: myunregisteredaccount from: <SiteNotification> with the title: WERCSmart Account Information
And the body of the email should show: Dear Future WERCSmart User: Recently you attempted to access WERCSmart and indicated you forgot your password. Our records do not show your email to be registered as a User of WERCSmart at this time. We recommend you create an account. Important Notice: This e-mail may contain privileged or confidential information. If you are not the intended recipient: (1) you may not disclose, use, distribute, copy or rely upon this message or attachment(s); and (2) please notify UL Information and Insights Inc. (“UL”) at WERCSmartCustomer@ul.com, and then delete this message and its attachment(s). UL and its affiliates disclaim all liability for any errors, omissions, corruption or virus in this message or any attachments.

#pass - staging 4.10
Scenario: [53035] Forgot Password - Badly Formatted Email
Given I click on the Forgot Your Password Link
Given I enter a email address: abc123.tt@j
And I click the continue button
Then In the Forgotten Password window I should see the following error messages: Email is not valid.
And I click the cancel button
Then I should see for the forgotten password: Forgot your Password?

Scenario: [53048] Forgot Password - Reset Password
Given I create an email AllRetailersProductsCompany and save it as AllRetailersProductsCompany
Given I save the current emails in the inbox for address saved as: AllRetailersProductsCompany
Given I click on the Forgot Your Password Link
#need to use company with no security questions answered
Given I enter a email address: savedas AllRetailersProductsCompany
And I click the continue button
Then there should be a new email for email Address saved as: AllRetailersProductsCompany from: <SiteNotification> with the title: WERCSmart Password Reset
And the body of the email should show: Dear WERCSmart User, We received a request to reset the password associated with your account. Please click on the link to reset your password. If you did not request to have your password reset, please contact Customer Support at +1 (877) 642-6753 immediately. If you would like to change your password in the future, please log in to your account and select Reset Password under Actions in the My Account section. Thank you! UL WERCSmart Customer Support Important Notice: This e-mail may contain privileged or confidential information. If you are not the intended recipient: (1) you may not disclose, use, distribute, copy or rely upon this message or attachment(s); and (2) please notify UL Information and Insights Inc. (“UL”) at WERCSmartCustomer@ul.com, and then delete this message and its attachment(s). UL and its affiliates disclaim all liability for any errors, omissions, corruption or virus in this message or any attachments.
When I click the link in the email I get directed to security questions

#pass - staging 4.10
Scenario: [50835] Forgot Password - Email Validation
Given I click on the Forgot Your Password Link
And I click the continue button
Then In the Forgotten Password window I should see the following error messages: This is a required field.


Scenario: [64860] Forgot Password (security questions answered)
Given If not already created, I create a user: ForgotPW_SecQs with the following parameters:
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
Then I click the User Icon
And I click on Sign Out
And the landing page should load
Then I go to the WERCSmart Log in
Given I click on the Forgot Your Password Link
Given I enter the email address for the Account saved as: ForgotPW_SecQs
And I click the continue button
Then the message should contain Please check your email to get instructions on how to reset your password.
Then there should be a new email for email Address saved as: ForgotPW_SecQs from: WERCSmartCustomer@ul.com with the title: WERCSmart Password Reset
And the body of the email should contain: Dear WERCSmart User, We received a request to reset the password associated with your account. Please click on the link to reset your password. If you did not request to have your password reset, please contact Customer Support at +1 (877) 642-6753 immediately. If you would like to change your password in the future, please log in to your account and select Reset Password under Actions in the My Account section. Thank you!
And the email should contain a link to reset a WERCSmart Account Password
When I click the link in the email I get directed to security questions
Then I answer the security questions for Account: ForgotPW_SecQs
Then I enter a new password: 123Password! and verify: 123Password!
Then I click the Login button
Then I log in as user: ForgotPW_SecQs with password: 123Password!
Then the WERCSmart homepage should load
