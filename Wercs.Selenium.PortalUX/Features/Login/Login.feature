@LandingPage
@Login
@Homepage
@wercsmart
@MyAccount
@run_Login

Feature: Login

Background:

Given I go to the WERCSmart Log in

Scenario: [50820] Language Selector - Japanese

When From the Language drop down I select Japanese
Then I should see for the sign in: ログイン
And I should see for the email label: 電子メールアドレス
And I should see for the password label: パスワード
And I should see for the forgotten password: パスワードを忘れた場合
And I should see for the login button: ログイン
When From the Language drop down I select English
Then I should see for the sign in: Login
And I should see for the email label: Email
And I should see for the password label: Password
And I should see for the forgotten password: Forgot your Password?
And I should see for the login button: Login

Scenario: [50828] Language Selector - Chinese

When From the Language drop down I select Chinese
Then I should see for the sign in: 注册
And I should see for the email label: 电子邮件地址
And I should see for the password label: 密码
And I should see for the forgotten password: 忘记密码？
And I should see for the login button: 登陆
When From the Language drop down I select English
Then I should see for the sign in: Login
And I should see for the email label: Email
And I should see for the password label: Password
And I should see for the forgotten password: Forgot your Password?
And I should see for the login button: Login

Scenario: [50830] Validation - Error Messages

Then I ensure that the email input field is not populated
And I ensure that the password input field is not populated
When I select the Login button
Then I should see the following error message for email: This is a required field.
Given I populate the email input field with: SeleniumAdmin01@thewercs.com
When I select the Login button
Then I should see the following error message for password: Your username or password is either missing or entered incorrectly. Please correct your entries and try again.
Given I ensure that the email input field is not populated
And I populate the password input field with: incorrectpassword
When I select the Login button
Then I should see the following error message for email: This is a required field.

Scenario: [50831] Account Lockout

Given I populate the email input field with: a@a.com
And I populate the password input field with: aaaaa
When I select the Login button
Given I populate the password input field with: bbbbb
When I select the Login button
Given I populate the password input field with: ccccc
When I select the Login button
Then I should see a server error with message: Your account is locked and will unlock after 30 minutes.

Scenario: [52978] Log Into Account
Given I populate the email input field with: automatedcompany1.kxxyxunf@mailosaur.io
And I populate the password input field with: Welcome1!
When I select the Login button
Then the WERCSmart homepage should load
Then I should see username: Automated, Visual Company in the right corner
Given I navigate to the MyAccount page
# need to add to click my account to ?
Then I should see company username: Visual
And I click on Sign Out
