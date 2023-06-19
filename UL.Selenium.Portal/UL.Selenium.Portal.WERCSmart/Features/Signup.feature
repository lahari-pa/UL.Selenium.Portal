@Shared
@SubEnrollment
@LandingPage
@PaymentMethods
@Login
@Homepage
@WERCSmart_Signup
@MyAccount
@NewProduct
@ProductGrid
@DataSummarySheet
@RetailPartners
@wercsmart
@run_Signup
Feature: Sign Up

Background:
	Given I go to the WERCSmart Log in

@TestCase:53069
Scenario: [53069] Signup - Account Creation - Happy Path
	Given I define the user: SignupUser with the following parameters:
		| Field                | Value                   |
		| Email                | User_<random>           |
		| Country              | UNITED STATES           |
		| FirstName            | Richard                 |
		| LastName             | Smith                   |
		| Password             | Pa4*ytuufnn             |
		| Address1             | Address 1               |
		| Address2             | Address 2               |
		| City                 | City Name               |
		| State                | Florida                 |
		| Zip                  | 999                     |
		| CompanyName          | Wercs QA Automated test |
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
	Given I save the current emails in the inbox for user saved as: SignupUser
	Given I click on the New to WERCSmart Link
	Then the signup page should appear
	Given I enter signup email for user: SignupUser
	And I confirm signup email for user: SignupUser
	And I click on submit
	Then the signup thank you page should appear
	Then there should be a new email for user: SignupUser from: <SiteNotification> with the title: Link to create WERCSmart Account
	Then the email should contain a link to set up the WERCSmart account
	When I click on the link I should see the WERCSmart new account page
	And I enter the information into the new user form for user saved as: SignupUser
	And In the new user form I click on continue
	Then I should be on the Security Questions page of the form
	And I enter the following into the Security Questions window for user saved as: SignupUser
	And I enter the pin for user saved as: SignupUser
	When In the new user form I click on continue
	Given I go to the WERCSmart Log in
	Given I login as user: SignupUser
	Given If terms of use page appears I accept
	Then the WERCSmart homepage should load
	Then I should see username for user saved as: SignupUser in the right corner
	And I click the Retail Partners icon in the Navigation Pane
	Then I should see the following heading Retail Partners
	And I select the retailer: Wal-Mart/SAM'S CLUB
	Then I Confirm Regulatory support toggle is Active
	Then I confirm the following text in Data Consent Tiers table is displayed:By agreeing to the Terms of Use upon creation of the WERCSmart account, you agree that all registrations will comply with Data Tier 1 for Regulatory Support to the retail recipient for your product registrations. This option cannot be changed in any way.
	And I confirm the following text in Data Consent Tiers table is displayed:Mandatory Consent. Any registered WERCSmart supplier of a product (a "Direct Supplier") is deemed to consent to providing Tier 1 Data Use - Regulatory Support ("Tier 1 Consent") to any entity that sells, transports, stores or disposes of such Direct Supplier's product (each, a "WERCSmart Recipient"). The WERCSmart platform provides Direct Suppliers with a current list of all WERCSmart Recipients as well as product-level information about which specific Recipients are in receipt of Tier 1 data. Any registered supplier that provides components to a Direct Supplier (a "Third-Party Supplier") is also deemed to provide Tier 1 Consent to WERCSmart Recipients. Use of the term "Supplier(s)" shall mean both Direct Suppliers and Third-Party Suppliers.
	Given I click the back arrow on the Retail Partners Details page
	Then I click on Sign Out


#pass - staging 4.10
@ignore
@TestCase:52998
Scenario: [52998] Signup - Emails Do Not Match
	Given I click on the New to WERCSmart Link
	Then the signup page should appear
	And I click on submit
	Then Under the Enter Email text box the following errors should appear
		| Error text                |
		| This is a required field. |
	Then Under the Confirm Email text box the following errors should appear
		| Error text                |
		| This is a required field. |
	Given I enter signup email: AnyOldUser@fake.com
	And I confirm signup email: Different@fake.com
	And I click on submit
	Then Under the Enter Email text box the following errors should appear
		| Error text                                  |
		| Email and confirm email fields do not match |
	Then I click Cancel on the Sign Up screen

#pass - staging 4.10
@TestCase:53000
Scenario: [53000] Signup - Copy and Paste Email Address
	Given I click on the New to WERCSmart Link
	Then the signup page should appear
	Given I enter signup email: AnyOldUser@fake.com
	Given I copy the current value of the signup email
	When I paste into confirm email: AnyOldUser@fake.com
	Then I should see popup error: You cannot paste text into this textbox!
	Given In the popup error I click on Cancel

@ignore
@TestCase:57737
Scenario: [57737] New Account - Required fields
	Given I define the user: SignupUser2 with the following parameters:
		| Field                | Value           |
		| Email                | User_<random>   |
		| Country              | UNITED STATES   |
		| FirstName            | Richard         |
		| LastName             | Smith           |
		| Password             | Selenium1!      |
		| Address1             | Address 1       |
		| Address2             | Address 2       |
		| City                 | City Name       |
		| State                | Florida         |
		| Zip                  | 999             |
		| CompanyName          | Company 1       |
		| CompanyPhone         | 123-456-4789    |
		| EmergencyPhoneNumber | 123-456-4789    |
		| SupplierType         | Manufacturer    |
		| PhoneQuestion        | PhoneQuestion   |
		| PhoneHint            | PhoneHint       |
		| MentorQuestion       | MentorQuestion  |
		| MentorHint           | MentorHint      |
		| FriendQuestion       | FriendQuestion  |
		| FriendHint           | FriendHint      |
		| AnimalQuestion       | AnimalQuestion  |
		| AnimalHint           | AnimalHint      |
		| CollegeQuestion      | CollegeQuestion |
		| CollegeHint          | CollegeHint     |
		| Pin                  | 1234            |
	Given I save the current emails in the inbox for user saved as: SignupUser2
	Given I click on the New to WERCSmart Link
	Then the signup page should appear
	Given I enter signup email for user: SignupUser2
	And I confirm signup email for user: SignupUser2
	And I click on submit
	Then the signup thank you page should appear
	Then there should be a new email for user: SignupUser2 from: <SiteNotification> with the title: Link to create WERCSmart Account
	Then the email should contain a link to set up the WERCSmart account
	When I click on the link I should see the WERCSmart new account page
	And In the new user form I click on continue
	Then I should be on the Account Information page of the form
	Then In the Country entry error I see error message: This is a required field.
	Then In the First Name entry error I see error message: This is a required field.
	Then In the Last Name entry error I see error message: This is a required field.
	Then In the Password entry error I see error message: This is a required field.
	Then In the Confirm Password entry error I see error message: This is a required field.
	Then In the Address 1 entry error I see error message: This is a required field.
	Then In the City entry error I see error message: This is a required field.
	Then In the State entry error I see error message: This is a required field.
	Then In the Zip entry error I see error message: This is a required field.
	Then In the Company entry error I see error message: This is a required field.
	Then In the Company Phone entry error I see error message: This is a required field.
	Then In the Country Code entry error I see error message: This is a required field.
	Then In the Emergency Phone Number entry error I see error message: This is a required field.
	Then In the Supplier Type entry error I see error message: This is a required field.
	And I enter the information into the new user form for user saved as: SignupUser2
	And In the new user form I click on continue
	Then I should be on the Security Questions page of the form
	And In the new user form I click on continue
	# Questions changed by #71591
	Then I check the Security Questions show the error: This is a required field.
	And I enter the following into the Security Questions window for user saved as: SignupUser2
	When In the new user form I click on continue
	Then In the PINQuestion entry error I see error message: This is a required field.
	And I enter the pin for user saved as: SignupUser2
	#Then I wait 2 seconds
	When In the new user form I click on continue
	#When In the new user form I click on continue
	#Then I wait 5 seconds
	Given I go to the WERCSmart Log in
	Given I login as user: SignupUser2
	Given If terms of use page appears I accept
	Then the WERCSmart homepage should load
	Then I should see username for user saved as: SignupUser2 in the right corner
# Then In the CityQuestion entry error I see error message: This is a required field.
# Then In the CarQuestion entry error I see error message: This is a required field.
# Then In the JobQuestion entry error I see error message: This is a required field.
# Then In the MascotQuestion entry error I see error message: This is a required field.
# Then In the FriendQuestion entry error I see error message: This is a required field.
# Then In the PINQuestion entry error I see error message: This is a required field.

@ignore
@TestCase:112431
Scenario: [112431] Signup - Account Creation - New user Email does not contain outdated PDF Attachment
	Given I define the user: SignupUser with the following parameters:
		| Field                | Value                   |
		| Email                | User_<random>           |
		| Country              | UNITED STATES           |
		| FirstName            | Richard                 |
		| LastName             | Smith                   |
		| Password             | Pa4*ytuufnn             |
		| Address1             | Address 1               |
		| Address2             | Address 2               |
		| City                 | City Name               |
		| State                | Florida                 |
		| Zip                  | 999                     |
		| CompanyName          | Wercs QA Automated test |
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
	Given I save the current emails in the inbox for user saved as: SignupUser
	Given I click on the New to WERCSmart Link
	Then the signup page should appear
	Given I enter signup email for user: SignupUser
	And I confirm signup email for user: SignupUser
	And I click on submit
	Then the signup thank you page should appear
	Then there should be a new email for user: SignupUser from: <SiteNotification> with the title: Link to create WERCSmart Account
	Then the email should contain a link to set up the WERCSmart account
	When I click on the link I should see the WERCSmart new account page
	And I enter the information into the new user form for user saved as: SignupUser
	And In the new user form I click on continue
	Then I should be on the Security Questions page of the form
	And I enter the following into the Security Questions window for user saved as: SignupUser
	And I enter the pin for user saved as: SignupUser
	When In the new user form I click on continue
	Given I go to the WERCSmart Log in
	Given I login as user: SignupUser
	Given If terms of use page appears I accept
	Then the WERCSmart homepage should load
	Then I should see username for user saved as: SignupUser in the right corner
	Then there is a new email for user: SignupUser from: <SiteNotification> with the title: Welcome to WERCSmart! Thank you for creating an account! and it should contain no attachments with the file name: WERCSmartSupplierFAQ2017







