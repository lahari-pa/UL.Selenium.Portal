@Homepage
@Login
@MyAccount
@wercsmart
@SubEnrollment
@LandingPage
@PaymentMethods
@SubUpgrade

@run_test
Feature: Test


Scenario: TEST
#Given I go to the WERCSmart Log in
#Given If not already created, I create a user: New_Sub with the following parameters:
#| Field                | Value          |
#| Email                | User_<random>  |
#| Country              | UNITED STATES  |
#| FirstName            | Richard        |
#| LastName             | Smith          |
#| Password             | Pa4*ytuufnn    |
#| Address1             | Address 1      |
#| Address2             | Address 2      |
#| City                 | City Name      |
#| State                | Florida        |
#| Zip                  | 999            |
#| CompanyName          | Company 1      |
#| CompanyPhone         | 123-456-7889   |
#| EmergencyPhoneNumber | 123-456-7789   |
#| SupplierType         | Manufacturer   |
#| CityQuestion         | CityQuestion   |
#| CityHint             | CityHint       |
#| CarQuestion          | CarQuestion    |
#| CarHint              | CarHint        |
#| FriendQuestion       | FriendQuestion |
#| FriendHint           | FriendHint     |
#| JobQuestion          | JobQuestion    |
#| JobHint              | JobHint        |
#| MascotQuestion       | MascotQuestion |
#| MascotHint           | MascotHint     |
#| Pin                  | 1234           |
#Given I click on My Account
#Then I click on NEW SUBSCRIPTION
#Then In the Subscription Enrollment screen I select the following enrollment options
#| Articles           | Enhanced Articles  | Formulated Products | Feature Plan | Support Services Plan |
#| Up to 5 Product(s) | Up to 5 Product(s) | Up to 5 Product(s)  | Standard     | Silver                |
#Then I click on Checkout
#Then In the Payment Methods screen I select Payment Method: Credit Card
#Then In the Payment Methods screen I enter Credit Card details
#| Card Type | Card Number         | Expiration Month | Expiration Year | CVV  | Cardholder Name |
#| Visa      | 4111 1111 1111 1111 | 08               | 2028            | 1111 | test            |
#Then In the Payment Methods screen I click Continue
##Purchase Summary
#Then In the Purchase Summary screen I click Confirm Order
#Then In the Thank You screen I click Home
Given I log in with email: User_b69b6adf1a61.kxxyxunf@mailosaur.io and password: Pa4*ytuufnn
Given I click on My Account
Then In the My Account screen I navigate to the Subscription Information page
#Then In the Subscription Information screen I confirm the Status has the correct information: 5 Formulated, 5 Articles, 5 Enhanced Articles
Then In the Subscription Information screen I click the Upgrade button
#Then In the Subscription Upgrade screen I confirm heading as Subscription  Upgrade
#Then In the Subscription Upgrade screen I confirm I cannot downgrade the existing plan
#| Plan                | Current            | Downgrade          |
#| Articles            | Up to 5 Product(s) | Up to 1 Product(s) |
#| Enhanced Articles   | Up to 5 Product(s) | Up to 1 Product(s) |
#| Formulated Products | Up to 5 Product(s) | Up to 1 Product(s) |
Then In the Subscription Upgrade screen I confirm the Standard Feature Plan is selected
Then In the Subscription Upgrade screen I confirm I cannot downgrade the current Feature Plan: Standard
Then In the Subscription Upgrade screen I confirm the Silver Support Services Plan is selected
Then In the Subscription Upgrade screen I confirm I cannot downgrade the current Support Services Plan: Silver



