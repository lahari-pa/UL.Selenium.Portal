@Homepage
@Login
@MyAccount
@wercsmart
@SubEnrollment
@LandingPage
@PaymentMethods

@run_test
Feature: Test


Scenario: TEST

#Given I log in with email: User_28e4aafb46f2.kxxyxunf@mailosaur.io and password: Pa4*ytuufnn
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
Given I click on My Account
Then I click on NEW SUBSCRIPTION
Then I select the following enrollment options
| Articles           | Enhanced Articles  | Formulated Products | Feature Plan | Support Services Plan |
| Up to 1 Product(s) | Up to 1 Product(s) | Up to 1 Product(s)  | Limited      | General Support       |
Then I cancel the Enrollment dialog, confirm correct page opens and Proceed
And I confirm the chosen options and body text are correct
| Articles           | Enhanced Articles  | Formulated Products | Feature Plan | Support Services Plan | Body Text                                                                                                                            |
| Up to 1 Product(s) | Up to 1 Product(s) | Up to 1 Product(s)  | Limited      | General               | Your new purchase will be prorated based on the credit and time left in your current subscription. Checkout to see the final amount. |
Then I click on Checkout
Then I check the Payment Methods heading and sub headings are correct
Then I confirm the following payment options are available
| Options       |
| Credit Card   |
| ACH           |
| Wire Transfer |
Then I confirm that the Contact Information is correct for Account saved as New_Sub
Then I confirm that the Billing Address is correct for Account saved as New_Sub
And I open the Edit Address form
Then I confirm the Sub Headings are correct: Primary Account Contact, Billing Address
Then I confirm the Edit Address form has the correct fields
| Field                     |
| First Name                |
| Last Name                 |
| Email Address             |
| Address 1                 |
| Address 2                 |
| City                      |
| State                     |
| Country                   |
| Zip Code                  |
| Phone Number              |
| Shipping/Billing Checkbox |
Then I un-check the Shipping Address is the same as the billing address checkbox
And I confirm the Shipping Address form has the correct fields
| Field                     |
| Address 1                 |
| Address 2                 |
| City                      |
| State                     |
| Country                   |
| Zip Code                  |
| Phone Number              |
Then I check the Shipping Address is the same as the billing address checkbox
Then I confirm the Shipping Address is hidden
Then I cancel the Edit Address form
Then I edit the Billing Address for user saved as: New_Sub
# ** If field is not to be changed, enter <empty> into table **
| Address Line 1 | Address Line 2 | City    | State   | Zip Code | Country | Phone Number |
| Address_New    | <empty>        | <empty> | <empty> | <empty>  | <empty> | <empty>      |
And I confirm that the Billing Address is correct for Account saved as New_Sub
Then I confirm the Continue Button is disabled
Then I select Payment Method: Credit Card
Then I confirm the Credit Card fields are correct
| Field           |
| Card Type       |
| Card Number     |
| Expiration Date |
| CVV             |
| Cardholder Name |
Then I select Payment Method: ACH
Then I confirm the ACH fields are correct
| Field               |
| ABA/Routing Number  |
| Bank Account Number |
| Account Type        |
| Bank Name           |
| Account Holder Name |
Then I select Payment Method: Wire Transfer
Then I confirm the following warning message appears: Wire Transfer subscription payment will result in the WERCSmart account being locked with regard to registration, UPC updates, and recertifications until funds are received and applied to the subscription balance due. No grace period for receipt of funds is provided for Wire Transfer payments. If you need immediate access to these functions, please select a different payment option before finalizing subscription.
Then I select Payment Method: Credit Card
Then I click Continue
Then I confirm Credit Card error messages for the following fields are displayed
| Field           |
| Card Number     |
| Expiration Date |
| CVV             |
| Cardholder Name |
Then I select Payment Method: ACH
Then I click Continue
Then I confirm ACH error messages for the following fields are displayed
| Field               |
| ABA/Routing Number  |
| Bank Account Number |
| Account Type        |
| Bank Name           |
| Account Holder Name |
Then I select Payment Method: Credit Card
Then I enter Credit Card details
| Card Type | Card Number         | Expiration Month | Expiration Year | CVV  | Cardholder Name |
| Visa      | 4111 1111 1111 1111 | 08               | 2028            | 1111 | test            |
Then I click Continue
#Purchase Summary
Then In the Purchase Summary screen I confirm the Purchase Summary header is displayed
Then In the Purchase Summary screen I check the Subscription Billing header is correct
Then In the Purchase Summary screen I confirm the Yearly Radio Option is selected
Then In the Purchase Summary screen I confirm the column headings are correct: Plan Selected, Service Date, Amount
Then In the Purchase Summary screen I confirm the folling statement is shown: Subscription will be automatically charged to the default payment method
Then In the Purchase Summary screen I confirm the Prices and Payment section contains the text: Prices are quoted in U.S. Dollars.  Payment may be made by credit card, ACH transfer or such other methods as may introduced by UL.  Payment is required when your order is submitted. The method of payment designated on the My Account area will be used.  UL reserves the right to accept or refuse any payment made in any form.  UL does not collect or process your payment details.  Credit card providers may confirm your order. Payment processing delays may also delay processing of your order.								
Then In the Purchase Summary screen I confirm the following statement is shown: By clicking "Confirm Order" you will be enrolled in our subscription plan.
Then In the Purchase Summary screen I click Confirm Order
Then In the Thank You screen I check the Header is correct
#Then In the Thank You screen I confirm the following statement is shown: Thank you for enrolling in a subscription plan. You’ve successfully submitted your first registration for assessment! What happens now? Our team of Assessment Professionals will review your product’s data and provide information to your recipient for proper handling, transport and storage. The assessment process takes about two (2) business days to finalize and then is transferred to your recipient. Your product’s registration data remains in our database. The UL WERCSmart team works with you to provide over 40 retailers critical product information to on-board your products while keeping the recipient’s employees, consumers and the environment safe. UL is committed to helping you monitor and manage your product’s data needs with the highest standard of confidentiality and service. Should you need any assistance regarding your registration, please visit the Support area’s Solution Center, or contact one of our professional Support Team Representatives.
Then In the Thank You screen I click Home
Given I click on My Account
Then In the My Account screen I navigate to the Subscription Information page
Then In the Subscription Information screen I confirm the Status has the correct information: 1 Formulated, 1 Articles, 1 Enhanced Articles
Then In the Subscription Information screen I confirm the Subscription History table has the correct information
| Subscription Level Status | Quantity |
| Limited Formulated        | 1        |
| Limited Articles          | 1        |
| Limited Enhanced Articles | 1        |
Given I click on My Account
Then In the My Account screen I navigate to the Order History page
Then In the Order History screen I select Subscription
Then In the Order History screen I get the Invoice Number and Date and confirm the invoice email has arrived for user saved as: New_Sub
