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

Given I log in with email: User_420183bb6907.kxxyxunf@mailosaur.io and password: Pa4*ytuufnn
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
 #Then I check the Payment Methods heading and sub headings are correct
 #Then I confirm the following payment options are available
 #| Options       |
 #| Credit Card   |
 #| ACH           |
 #| Wire Transfer |
 #Then I confirm that the Contact Information is correct for Account saved as New_Sub
 #Then I confirm that the Billing Address is correct for Account saved as New_Sub
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





