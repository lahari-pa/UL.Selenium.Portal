@LandingPage
@Login
@Homepage
@Signup
@wercsmart
@NewProduct
@ProductGrid
@DataSummarySheet
@wercsmart
@RetailPartners
@SummaryPage
@PaymentMethods
@SubEnrollment
@WERCSmart_Signup
@MyAccount
@SubUpgrade
@ProductSetUp
@SupplierAccounts
@run_SupplierAccounts

Feature: SupplierAccounts

@TReVorId:22360
Scenario: Create new account with supplier settings
Given I go to the WERCSmart Log in
Given I create supplier account with the following parameters and save as: ProductsNewAccount
| Field                | Value                   |
| Email                | User_<random>           |
| Country              | UNITED STATES           |
| FirstName            | WERCS                   |
| LastName             | Test_Automation_Upgrade |
| Password             | Pa4*ytuufnn             |
| Address1             | Address 1               |
| Address2             | Address 2               |
| City                 | City Name               |
| State                | Florida                 |
| Zip                  | 999                     |
| CompanyName          | Company 1               |
| CompanyPhone         | 123-456-7889            |
| EmergencyPhoneNumber | 123-456-7789            |
| SupplierType         | Manufacturer            |
| PhoneQuestion        | PhoneQuestion           |
| PhoneHint            | PhoneHint               |
| MentorQuestion       | MentorQuestion          |
| MentorHint           | MentorHint              |
| FriendQuestion       | FriendQuestion          |
| FriendHint           | FriendHint              |
| AnimalQuestion       | AnimalQuestion          |
| AnimalHint           | AnimalHint              |
| CollegeQuestion      | CollegeQuestion         |
| CollegeHint          | CollegeHint             |
| Pin                  | 1234                    |
