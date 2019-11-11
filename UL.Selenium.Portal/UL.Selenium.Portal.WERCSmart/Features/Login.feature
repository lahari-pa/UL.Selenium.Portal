@Shared
@LandingPage
@Login
@Homepage
@wercsmart
@run_Login

Feature: Login

Background:

Given I go to the WERCSmart Log in

@tfs_design
@ScenarioId:5965
Scenario: [50820] Language Selector - Japanese

When From the Language drop down I select Japanese
Then The element: sign in should display text: ログイン
Then The element: email label should display text: 電子メールアドレス
Then The element: password label should display text: パスワード
Then The element: forgotten password should display text: パスワードを忘れた場合
Then The element: login button should display text: ログイン
When From the Language drop down I select English
Then The element: sign in should display text: Login
Then The element: email label should display text: Email
Then The element: password label should display text: Password
Then The element: forgotten password should display text: Forgot your Password?
Then The element: login button should display text: Login


@tfs_design
@ScenarioId:5966
Scenario: [50828] Language Selector - Chinese

When From the Language drop down I select Chinese
Then The element: sign in should display text: 注册
Then The element: email label should display text: 电子邮件地址
Then The element: password label should display text: 密码
Then The element: forgotten password should display text: 忘记密码？
Then The element: login button should display text: 登陆
When From the Language drop down I select English
Then The element: sign in should display text: Login
Then The element: email label should display text: Email
Then The element: password label should display text: Password
Then The element: forgotten password should display text: Forgot your Password?
Then The element: login button should display text: Login


@ScenarioId:461
Scenario: [50830] Validation - Error Messages

Then I ensure that the email input field is not populated
And I ensure that the password input field is not populated
When I click the Login button
Then I should see the following error message for email: This is a required field.
Given I populate the email input field with: SeleniumAdmin01@thewercs.com
When I click the Login button
Then I should see the following error message for password: This is a required field.
Given I ensure that the email input field is not populated
And I populate the password input field with: incorrectpassword
When I click the Login button
Then I should see the following error message for email: This is a required field.
Given on the Login page I log in as test user: ProductAccount
Then the WERCSmart homepage should load


@ScenarioId:462
Scenario: [50831] Account Lockout

Given I popupate the email input field with credentials for account: AccountLockOut
And I populate the password input field with: aaaaa
When I click the Login button
Given I populate the password input field with: bbbbb
When I click the Login button
Given I populate the password input field with: ccccc
When I click the Login button
Then I should see a server error with message: Your account is locked and will unlock after 30 minutes.
#TODO: need to find a better way to manage click when error is displayed
