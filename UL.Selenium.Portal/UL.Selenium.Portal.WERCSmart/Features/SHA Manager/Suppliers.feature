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
@Studio_Header
@MyAccount


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
Then I confirm the new supplier should be seen in the supplier manager window
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

# Created by Saikiran Chittampally
@TestCase:202291
Scenario: [202291] [Automation] : Supplier Manager - Adding New Supplier - Using Existing Contact Email
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
And In Add New Supplier I enter Contact Email: 2e063d578bc1@.mailosaur.net
And In Add New Supplier I enter Contact Phone: Phone
Then In the Add New Supplier I click on Accept button
And An alert is displayed with next errors:
| Error                                  |
| A user with this email already exists    |
And I should see the 'Add New Supplier' popup
Then In the Add New Supplier I click on Cancel button
Then I confirm the new supplier should not be seen in the supplier manager window

# Created by Saikiran Chittampally
# Executed in QA-Integration env as Edit permission provided for SHAManager Account in Integration environment
@TestCase:202272
Scenario: [202272] Supplier Manager - Company Information - Document Reader Toggle
Given I call Shared Step 65080b (Login to Studio as user saved as: SHAManager and Open SHA manager)
Then I Click 'Suppliers' in SHA Manager
And I should see the 'Supplier Manager' popup
When I search with email in the supplier manager window: 2e063d578bc1@.mailosaur.net
Then I confirm following toggles displayed
|ToggleInfo|
| UL Retail Services (IFS) |
| After-Market Distributor |
| Prescription Pharma      |
| UL Test Company          |
|Document Reader           |
Then I confirm Document Reader Toggle enable check after clicking back button
Then I confirm Document Reader Toggle enable check after clicking save button
Then I close Supplier Manager window

#Currently test case can be run only in QA-Integration, as SHAManager account waiting for additional settings in Staging
@OnlyInIntegration
@TestCase:202273
Scenario: [202273] Supplier Manager - Single Retail Subscription Toggle

Given I call Shared Step 65080b (Login to Studio as user saved as: SHAManager and Open SHA manager)
Then I Click 'Suppliers' in SHA Manager
When I search with email in the supplier manager window: SingleRetailerAccount@kxxyxunf.mailosaur.net
Then In the Supplier Manager Popup I click on the first supplier returned
Then Select the 'Company Information' Tab in Supplier Manager
Then In the Supplier Manager Popup I click on button: Edit
Then In the Supplier Manager Popup I turn off toggle: Single-Retail Subscription
Then In the Supplier Manager Popup I click on button: Save
Then In the Supplier Manager Popup I click on button: Edit
Then In the Supplier Manager Popup I turn on toggle: Single-Retail Subscription
Then In the Supplier Manager Popup I confirm Single-Retail Subscription is turned on
Then In the Supplier Manager Popup I click on button: Back
Then In the Supplier Manager Popup I confirm Single-Retail Subscription is turned off
Then In the Supplier Manager Popup I click on button: Edit
Then In the Supplier Manager Popup I turn on toggle: Single-Retail Subscription
Then In the Supplier Manager Popup I click on button: Save
Then In the Supplier Manager Popup I confirm Single-Retail Subscription is turned on
Then Select the 'Subscription' Tab in Supplier Manager
Then Select the 'Company Information' Tab in Supplier Manager
Then In the Supplier Manager Popup I confirm Single-Retail Subscription is turned on
Then In the Supplier Manager Popup I click on button: Edit
Then In the Supplier Manager Popup I turn off toggle: Single-Retail Subscription
Then In the Supplier Manager Popup I confirm Single-Retail Subscription is turned off
Then In the Supplier Manager Popup I click on button: Save
Then In the Supplier Manager Popup I confirm Single-Retail Subscription is turned off
Then In the Supplier Manager Popup I click on button: Edit
Then In the Supplier Manager Popup I turn on toggle: Single-Retail Subscription
Then In the Supplier Manager Popup I click on button: Save

# Created by Saikiran Chittampally
# Executed in QA-Integration env as Edit permission provided for SHAManager Account in Integration environment
@TestCase:207659
Scenario: [207659] Supplier Manager - UL Retail Services (IFS) Toggle  
Given I call Shared Step 65080b (Login to Studio as user saved as: SHAManager and Open SHA manager)
Then I Click 'Suppliers' in SHA Manager
And I should see the 'Supplier Manager' popup
When I search with email in the supplier manager window: 2e063d578bc1@.mailosaur.net
Then I confirm following toggles displayed
|ToggleInfo|
| UL Retail Services (IFS) |
| After-Market Distributor |
| Prescription Pharma      |
| UL Test Company          |
|Document Reader           |
Then I confirm UL Retail Services (IFS) Toggle enable check after clicking back button
Then I confirm UL Retail Services (IFS) Toggle enable check after clicking save button
Then I close Supplier Manager window
Then I click to open the 'My Wercs' menu and select 'Log Out'
Given I call Shared Step 65080b (Login to Studio as user saved as: SHAManager and Open SHA manager)
Then I Click 'Suppliers' in SHA Manager
And I should see the 'Supplier Manager' popup
When I search with email in the supplier manager window: 2e063d578bc1@.mailosaur.net
Then In the Supplier Manager Popup I confirm UL Retail Services (IFS) is turned on
Then I confirm UL Retail Services (IFS) Toggle enable check after clicking save button
Then I close Supplier Manager window

# Created by Saikiran Chittampally
# Executed in QA-Integration env as Edit permission provided for SHAManager Account in Integration environment
@TestCase:210011
Scenario: [210011] Supplier Manager - After Market Distributor Toggle
Given I call Shared Step 65080b (Login to Studio as user saved as: SHAManager and Open SHA manager)
Then I Click 'Suppliers' in SHA Manager
And I should see the 'Supplier Manager' popup
When I search with email in the supplier manager window: 2e063d578bc1@.mailosaur.net
Then I confirm following toggles displayed
|ToggleInfo|
| UL Retail Services (IFS) |
| After-Market Distributor |
| Prescription Pharma      |
| UL Test Company          |
|Document Reader           |
Then I confirm After-Market Distributor Toggle enable check after clicking back button
Then I confirm After-Market Distributor Toggle enable check after clicking save button
Then I close Supplier Manager window
Then I click to open the 'My Wercs' menu and select 'Log Out'
Given I call Shared Step 65080b (Login to Studio as user saved as: SHAManager and Open SHA manager)
Then I Click 'Suppliers' in SHA Manager
And I should see the 'Supplier Manager' popup
When I search with email in the supplier manager window: 2e063d578bc1@.mailosaur.net
Then In the Supplier Manager Popup I confirm After-Market Distributor is turned on
Then I confirm After-Market Distributor Toggle enable check after clicking save button
Then I close Supplier Manager window

@TestCase:207486
Scenario: [207486] Supplier Manager -Search returns the correct values - Invoice Number - With leading and/or trailing whitespace

Given I log in with the account saved in TReVor as: ProductAccount
Then I navigate to the MyAccount page
Then In the My Account page I navigate to the Order History page
Then In the Order History screen I select Subscription
Then In the Order History screen I save first Invoice Number as: InvoiceNumber
Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
Then I Click 'Suppliers' in SHA Manager
Then In the Supplier Manager Popup I select radio button: Invoice Number
Then In the Supplier Manager Popup I enter the following search term: saved as InvoiceNumber
Then In the Supplier Manager Popup I click on the search button
Then In the Supplier Manager Popup I should see supliers
Then In the Supplier Manager Popup I click on the close button
Then I call Shared Step - In the Supplier Manager popup I select radio button Invoice Number and enter search term with spaces: saved as InvoiceNumber
 
# Created by Saikiran Chittampally
# Executed in QA-Integration env as Edit permission provided for SHAManager Account in Integration environment
@TestCase:214081
Scenario: [214081] Create New IFS Account - Turn UL Retail Services (IFS) Toggle ON
Given I call Shared Step 65080b (Login to Studio as user saved as: SHAManager and Open SHA manager)
Then I Click 'Suppliers' in SHA Manager
And I should see the 'Supplier Manager' popup
When I search with email in the supplier manager window: 2e063d578bc1@.mailosaur.net
Then I confirm following toggles displayed
|ToggleInfo|
| UL Retail Services (IFS) |
| After-Market Distributor |
| Prescription Pharma      |
| UL Test Company          |
|Document Reader           |
Then I confirm UL Retail Services (IFS) Toggle enable check after clicking back button
Then I confirm UL Retail Services (IFS) Toggle enable check after clicking save button
Then I close Supplier Manager window
