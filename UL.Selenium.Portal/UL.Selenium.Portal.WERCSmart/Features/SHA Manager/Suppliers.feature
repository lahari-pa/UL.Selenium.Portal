@Shared
@LandingPage
@Login
@Homepage
@Signup
@wercsmart
@NewProduct
@ProductGrid
@SHA
@wercsmart
@RetailPartners
@CreateProducts
@PaymentMethods
@UPC
@Studio
@ProductSetUp
@run_ProductSetUp
@SupplierAccounts

Feature: Suppliers

@TestCase:199660
Scenario: [199660] Supplier Manager - Adding New Supplier

Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
Then I click on the Suppliers link on the top right of the screen
And I should see the 'Supplier Manager' popup
Then In the Supplier Manager Popup I click on button: New Supplier 
And I should see the 'Add New Supplier' popup
Then In the Add New Supplier I click on Accept button
And An alert is displayed with next errors:
| Error                                  |
| Please specify a Company Name          |
| Please specify a Country               |
| Please specify a Country Code          |
| Please specify a Supplier Phone number |
| Please specify a Primary Address       |
| Please specify a City                  |
| Please specify a State                |
| Please specify a Postal Code           |
| Please specify a Contact Name          |
| Please specify a Contact Email         |
| Please specify a Contact Phone         |
And In Add New Supplier I enter Company Name: CompanyName
And In Add New Supplier I enter Supplier Seller ID: 123456
And In Add New Supplier I enter Country: United States
And I Add New Supplier I enter Country Code: +1
And In Add New Supplier I enter Supplier Phone: 123456789
And In Add New Supplier I enter Address: 7856 Paris st
And In Add New Supplier I enter City: New York
And In Add New Supplier I enter State: New York
And In Add New Supplier I enter Postal Code: 58963
And In Add New Supplier I enter Contact Name: Name
And In Add New Supplier I enter Contact Email: random
And In Add New Supplier I enter Contact Phone: Phone
Then In the Add New Supplier I click on Accept button
And An alert is displayed with the message: The supplier was successfully added to the system.
Then I close alert
And I should not see the 'Add New Supplier' popup


# Created by Saikiran Chittampally
@TestCase:202277
Scenario: [202277] Supplier Manager - Adding New Supplier - Accept Button Action
Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
Then I Click 'Suppliers' in SHA Manager
And I should see the 'Supplier Manager' popup
Then In the Supplier Manager Popup I click on button: New Supplier 
And I should see the 'Add New Supplier' popup
Then In the Add New Supplier I click on Accept button
And An alert is displayed with next errors:
| Error                                  |
| Please specify a Company Name          |
| Please specify a Country               |
| Please specify a Country Code          |
| Please specify a Supplier Phone number |
| Please specify a Primary Address       |
| Please specify a City                  |
| Please specify a State                |
| Please specify a Postal Code           |
| Please specify a Contact Name          |
| Please specify a Contact Email         |
| Please specify a Contact Phone         |
And In Add New Supplier I enter random Company Name
And In Add New Supplier I enter Supplier Seller ID: 123456
And In Add New Supplier I enter Country: United States
And I Add New Supplier I enter Country Code: +1
And In Add New Supplier I enter Supplier Phone: 123456789
And In Add New Supplier I enter Address: 7856 Paris st
And In Add New Supplier I enter City: New York
And In Add New Supplier I enter State: New York
And In Add New Supplier I enter Postal Code: 58963
And In Add New Supplier I enter Contact Name: Name
And In Add New Supplier I enter Contact Email: random
And In Add New Supplier I enter Contact Phone: Phone
Then In the Add New Supplier I click on Accept button
And An alert is displayed with the message: The supplier was successfully added to the system.
Then I close alert
And I should not see the 'Add New Supplier' popup
Then I confirm the new supplier added in the supplier manager window
Then I confirm following tabs appear available
| tabs                |
| Company Information |
| User Information    |
| Vendor information  |
| Subscription        |
| Data Tier Consent   |
And I click on Company Information tab
Then I confirm following toggles displayed
|ToggleInfo|
| UL Retail Services (IFS) |
| After-Market Distributor |
| Prescription Pharma      |
| UL Test Company          |
|Document Reader|

# Created by Saikiran Chittampally
@TestCase:202274
Scenario: [202274] Supplier Manager - Adding New Supplier -Cancel Button Action
Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
Then I Click 'Suppliers' in SHA Manager
And I should see the 'Supplier Manager' popup
Then In the Supplier Manager Popup I click on button: New Supplier 
And I should see the 'Add New Supplier' popup
Then In the Add New Supplier I click on Accept button
And An alert is displayed with next errors:
| Error                                  |
| Please specify a Company Name          |
| Please specify a Country               |
| Please specify a Country Code          |
| Please specify a Supplier Phone number |
| Please specify a Primary Address       |
| Please specify a City                  |
| Please specify a State                |
| Please specify a Postal Code           |
| Please specify a Contact Name          |
| Please specify a Contact Email         |
| Please specify a Contact Phone         |
And In Add New Supplier I enter random Company Name
And In Add New Supplier I enter Supplier Seller ID: 123456
And In Add New Supplier I enter Country: United States
And I Add New Supplier I enter Country Code: +1
And In Add New Supplier I enter Supplier Phone: 123456789
And In Add New Supplier I enter Address: 7856 Paris st
And In Add New Supplier I enter City: New Jersey
And In Add New Supplier I enter State: New Jersey
And In Add New Supplier I enter Postal Code: 58873
And In Add New Supplier I enter Contact Name: Contact
And In Add New Supplier I enter Contact Email: random
And In Add New Supplier I enter Contact Phone: Phone
Then In the Add New Supplier I click on Cancel button
And I should not see the 'Add New Supplier' popup
Then I click on New Supplier Button
Then In the Add New Supplier I click on Accept button
And An alert is displayed with next errors:
| Error                                  |
| Please specify a Company Name          |
| Please specify a Country               |
| Please specify a Country Code          |
| Please specify a Supplier Phone number |
| Please specify a Primary Address       |
| Please specify a City                  |
| Please specify a State                |
| Please specify a Postal Code           |
| Please specify a Contact Name          |
| Please specify a Contact Email         |
| Please specify a Contact Phone         |
Then In the Add New Supplier I click on Cancel button
Then I close Supplier Manager window

# Created by Saikiran Chittampally
@TestCase:202338
Scenario: [202338] [Automation] : Suppliers : Supplier Manager - Adding New Supplier - Username and Temporary Password Emails
Given I go to the WERCSmart Log in
Given I create an email EmailAddressGen and save it as EmailAddressGen
Given I save the current emails in the inbox for address saved as: EmailAddressGen
Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
Then I Click 'Suppliers' in SHA Manager
And I should see the 'Supplier Manager' popup
Then In the Supplier Manager Popup I click on button: New Supplier 
And I should see the 'Add New Supplier' popup
Then In the Add New Supplier I click on Accept button
And An alert is displayed with next errors:
| Error                                  |
| Please specify a Company Name          |
| Please specify a Country               |
| Please specify a Country Code          |
| Please specify a Supplier Phone number |
| Please specify a Primary Address       |
| Please specify a City                  |
| Please specify a State                |
| Please specify a Postal Code           |
| Please specify a Contact Name          |
| Please specify a Contact Email         |
| Please specify a Contact Phone         |
And In Add New Supplier I enter random Company Name
And In Add New Supplier I enter Supplier Seller ID: 123456
And In Add New Supplier I enter Country: United States
And I Add New Supplier I enter Country Code: +1
And In Add New Supplier I enter Supplier Phone: 123456789
And In Add New Supplier I enter Address: 7856 Paris st
And In Add New Supplier I enter City: New York
And In Add New Supplier I enter State: New York
And In Add New Supplier I enter Postal Code: 58963
And In Add New Supplier I enter Contact Name: Name
Given I enter email address: savedas EmailAddressGen
And In Add New Supplier I enter Contact Phone: Phone
Then In the Add New Supplier I click on Accept button
And An alert is displayed with the message: The supplier was successfully added to the system.
Then I close alert
And I should not see the 'Add New Supplier' popup
Then I confirm the new supplier added in the supplier manager window
Then there should be a new email for email Address saved as: EmailAddressGen from: <SiteNotification> with the title: Welcome to the UL WERCSmart Product Registration Process
And the html of the email should show: UL, working in collaboration with retailers in both the United States and Canada, has established a User Sign-On for your organization. The UL WERCSmart online portal is used by retailers to provide vital information about products being sold through the retailer. A separate email will be provided to you with a temporary password. After receiving the data, UL will utilize the information provided about your product to generate regulatory compliance data, for handling of returns and other reverse-logistic purposes.To begin to register your product data, the site address is UL-WERCSmart (ulwercsmart.com). The site performs best when using either Google Chrome or Microsoft Edge as your browser. If you need assistance while using the site, please email ULWERCSmartCustomer@ul.com. Thank you. Important Notice: This email may contain privileged or confidential information. If you are not the intended recipient (1) you may not disclose, use, distribute, copy or rely upon this message or attachment(s); and (2) please notify UL Verification Services at DSVCustomer@UL.com and then delete this message and its attachment(s). UL and its affiliates disclaim all liability for any errors, omissions, corruption or virus in this message or any attachment(s).
Then there should be a new email for email Address saved as: EmailAddressGen from: <SiteNotification> with the title: UL WERCSmart Temporary Password
And the html of the email should show: Recently, in a separate email, UL provided you information related to the WERCSmart registration process. Your temporary password is: (Password) Once successfully accessing the site, if you go to the My Account area, you can update your password as you'd like. To begin to register your product data, the site address is UL-WERCSmart (ulwercsmart.com) and best performance is achieved when using either Google Chrome or Microsoft Edge. If you need assistance while using the site, please email ULWERCSmartCustomer@ul.com. Thank you. Important Notice: This email may contain privileged or confidential information. If you are not the intended recipient (1) you may not disclose, use, distribute, copy or rely upon this message or attachment(s); and (2) please notify UL Verification Services at DSVCustomer@UL.com and then delete this message and its attachment(s). UL and its affiliates disclaim all liability for any errors, omissions, corruption or virus in this message or any attachment(s).
