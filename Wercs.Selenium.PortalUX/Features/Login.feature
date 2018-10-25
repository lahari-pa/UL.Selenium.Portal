@LandingPage
@Login
@Homepage
@wercsmart
@run_Login

Feature: Login

Background:

Given I go to the WERCSmart Log in

@tfs_design
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

@tfs_design
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
Then I should see the following error message for password: This is a required field.
Given I ensure that the email input field is not populated
And I populate the password input field with: incorrectpassword
When I select the Login button
Then I should see the following error message for email: This is a required field.
Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
Then the WERCSmart homepage should load


Scenario: [50831] Account Lockout

Given I popupate the email input field with credientials for account: AccountLockOut
And I populate the password input field with: aaaaa
When I select the Login button
Given I populate the password input field with: bbbbb
When I select the Login button
Given I populate the password input field with: ccccc
When I select the Login button
Then I should see a server error with message: Your account is locked and will unlock after 30 minutes.
