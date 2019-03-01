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
Given I go to the WERCSmart Log in
Given If not already created, I create a user: New_Sub with the following parameters:
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
| PhoneQuestion         | PhoneQuestion   |
| PhoneHint             | PhoneHint       |
| MentorQuestion          | MentorQuestion    |
| MentorHint              | MentorHint        |
| FriendQuestion       | FriendQuestion |
| FriendHint           | FriendHint     |
| AnimalQuestion          | AnimalQuestion    |
| AnimalHint              | AnimalHint        |
| CollegeQuestion       | CollegeQuestion |
| CollegeHint           | CollegeHint     |
| Pin                  | 1234           |
Given I click on My Account
Then I click on NEW SUBSCRIPTION
Then In the Subscription Enrollment screen I select the following enrollment options
| Articles           | Enhanced Articles  | Formulated Products | Feature Plan | Support Services Plan |
| Up to 5 Product(s) | Up to 5 Product(s) | Up to 5 Product(s)  | Standard     | Silver                |
Then I click on Checkout
Then In the Payment Methods screen I select Payment Method: Credit Card
Then In the Payment Methods screen I enter Credit Card details
| Card Type | Card Number         | Expiration Month | Expiration Year | CVV  | Cardholder Name |
| Visa      | 4111 1111 1111 1111 | 08               | 2028            | 1111 | test            |
Then In the Payment Methods screen I click Continue
#Purchase Summary
Then In the Purchase Summary screen I click Confirm Order
Then In the Thank You screen I click Home
#Given I log in with email: User_ceef42822c24.kxxyxunf@mailosaur.io and password: Pa4*ytuufnn
Given I click on My Account
Then In the My Account screen I navigate to the Subscription Information page
Then In the Subscription Information screen I confirm the Status has the correct information: 5 Formulated, 5 Articles, 5 Enhanced Articles
Then In the Subscription Information screen I click the Upgrade button
Then In the Subscription Upgrade screen I confirm heading as Subscription  Upgrade
Then In the Subscription Upgrade screen I confirm the Standard Feature Plan is selected
Then In the Subscription Upgrade screen I confirm I cannot downgrade the current Feature Plan: Standard
Then In the Subscription Upgrade screen I confirm the Silver Support Services Plan is selected
Then In the Subscription Upgrade screen I confirm I cannot downgrade the current Support Services Plan: Silver
Then In the Subscription Upgrade screen I confirm the Proceed button is disabled when there is no change in the plan selection
Then In the Subscription Upgrade screen for Articles I select Up to 10 Product(s)
Then In the Subscription Upgrade screen I confirm the Proceed button is enabled when a change is made in the plan selection
Then In the Subscription Upgrade screen I confirm the Estimated Annual Cost changes when Articles are changed to Up to 15 Product(s)
Then In the Subscription Upgrade screen I confirm the Estimated Annual Cost per Product changes when Enhanced Articles are changed to Up to 75 Product(s)
Then In the Subscription Upgrade screen I select the following enrollment options
| Articles            | Enhanced Articles   | Formulated Products | Feature Plan | Support Services Plan |
| Up to 15 Product(s) | Up to 15 Product(s) | Up to 15 Product(s) | Premium      | Gold                  |
Then In the Subscription popup I confirm the Subscription Upgrade header exists
And I confirm the chosen options and body text are correct
| Articles            | Enhanced Articles   | Formulated Products | Feature Plan | Support Services Plan | Body Text                                                                                                                            |
| Up to 15 Product(s) | Up to 15 Product(s) | Up to 15 Product(s) | Premium      | Gold                  | Your new purchase will be prorated based on the credit and time left in your current subscription. Checkout to see the final amount. |
Then I click on Checkout
Then In the Payment Methods screen I confirm the Default method is: Credit Card
Then In the Payment Methods screen I click Continue
Then In the Purchase Summary screen I confirm the Purchase Summary header is displayed
Then In the Purchase Summary screen I check the Subscription Billing header is correct
Then In the Purchase Summary screen I confirm the Yearly Radio Option is selected
Then In the Purchase Summary screen I confirm the column headings are correct: Plan Selected, Service Date, Amount
Then In the Purchase Summary screen I confirm the folling statement is shown: Subscription will be automatically charged to the default payment method.
Then In the Purchase Summary screen I confirm the Prices and Payment section contains the text: Prices are quoted in U.S. Dollars. Payment may be made by credit card, ACH transfer or such other methods as may introduced by UL. Payment is required when your order is submitted. The method of payment designated on the My Account area will be used. UL reserves the right to accept or refuse any payment made in any form. UL does not collect or process your payment details. Credit card providers may confirm your order. Payment processing delays may also delay processing of your order.
Then In the Purchase Summary screen I confirm the following statement is shown: By clicking "Confirm Order" you will be enrolled in our subscription plan.
Then In the Purchase Summary screen I click Confirm Order
#Then In the Thank You screen I check the Header is correct
#Then In the Thank You screen I confirm the following statement is shown: Thank you for enrolling in a subscription plan. You’ve successfully submitted your first registration for assessment! What happens now? Our team of Assessment Professionals will review your product’s data and provide information to your recipient for proper handling, transport and storage. The assessment process takes about two (2) business days to finalize and then is transferred to your recipient. Your product’s registration data remains in our database. The UL WERCSmart team works with you to provide over 40 retailers critical product information to on-board your products while keeping the recipient’s employees, consumers and the environment safe. UL is committed to helping you monitor and manage your product’s data needs with the highest standard of confidentiality and service. Should you need any assistance regarding your registration, please visit the Support area’s Solution Center, or contact one of our professional Support Team Representatives.
#Then In the Thank You screen I click Home
#Given I log in with email: User_ceef42822c24.kxxyxunf@mailosaur.io and password: Pa4*ytuufnn
Given I click on My Account
Then In the My Account screen I navigate to the Subscription Information page
Then In the Subscription Information screen I confirm the Status has the correct information: 15 Formulated, 15 Articles, 15 Enhanced Articles
Then In the Subscription Information screen I confirm the Subscription History table has the correct information
| Subscription Level Status      | Quantity |
| Premium Gold Formulated        | 15       |
| Premium Gold Articles          | 15       |
| Premium Gold Enhanced Articles | 15       |
Given I click on My Account
Then In the My Account screen I navigate to the Order History page
Then In the Order History screen I select Subscription
Then In the Order History screen I get the Invoice Number and Date and confirm the invoice email has arrived for user saved as: New_Sub
