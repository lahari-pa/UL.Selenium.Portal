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
| Please specify a State                 |
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
|Document Reader           |

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
| Please specify a State                 |
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
| Please specify a State                 |
| Please specify a Postal Code           |
| Please specify a Contact Name          |
| Please specify a Contact Email         |
| Please specify a Contact Phone         |
Then In the Add New Supplier I click on Cancel button
Then I close Supplier Manager window






