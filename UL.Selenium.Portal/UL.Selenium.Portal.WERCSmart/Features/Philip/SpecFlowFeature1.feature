@Shared
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
@SHA
@UPC
@run_AdditionalProductInformation
@Shared
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
@SHA
@CreateProducts
@ForwardProductRegistration
@PaymentMethods
@ProductSetUp
@run_AccountHasStewardshipInfo
@Shared
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
@Studio
@SHA
@UPC
@run_StwdInWpsStudiofeature
@Philip
@Shared
@NewProduct
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
@PackagingTypes
@Brands
@MyIngredients
@UPC
@ProductSetUp
@SHA
@Studio
@ForwardProductRegistration
@ProductSetUp
@SupplierReports
@CreateProducts
@ViewUpcs
@Solutions
@run_NotIncludedGeneralTests
@Shared
@NewProduct
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
@PackagingTypes
@Brands
@MyIngredients
@UPC
@ProductSetUp
@SHA
@Studio
@ForwardProductRegistration
@ProductSetUp
@SupplierReports
@CreateProducts
@ViewUpcs
@Solutions
@run_NotIncludedGeneralTests
@Shared
@NewProduct
@Homepage
@Shared
@wercsmart
@Login
@UlSolutionCenter
@Homepage
@ProductGrid
@ForwardProductRegistration
@NewProduct
@RetailPartners
@MessageCenter
@MyAccount
@LandingPage
@DocumentAcceptance
@DeleteActiveProducts
@Solutions
@UPC
@ReviewDocuments
@SHA
@MyMessages
@run_MyMessages
@Shared
@wercsmart
@Login
@UlSolutionCenter
@Homepage
@ProductGrid
@ForwardProductRegistration
@NewProduct
@RetailPartners
@MessageCenter
@MyAccount
@LandingPage
@DocumentAcceptance
@DeleteActiveProducts
@Solutions
@UPC
@ReviewDocuments
@SHA
@MyMessages
@run_MyMessages
@Shared
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
@PaymentMethodsSelect Waste Classification Summary
@SHA
@CreateProducts
@Studio
@ProductSetUp
@ProductGrid
@Shared
@Login
@UlSolutionCenter
@Homepage
@ProductGrid
@ForwardProductRegistration
@NewProduct
@RetailPartners
@MessageCenter
@MyAccount
@LandingPage
@DocumentAcceptance
@DeleteActiveProducts
@Portal_ULSC
@ULSC
@Shared
@Pharma
@CreateProducts
@NewProduct
@ProductGrid
@ProductSetUp
@Homepage
@NewDistributor
@MyAccount
@NewProduct
@Shared
@PaymentMethods
@SHA

@run_Transportation

Feature: ChooseGoodGuide.com Scenarios

Scenario: My new scenario

Given I Submit a new product which has a Case UPC and a regular UPC
Given I navigate to the landing page
Given I call Shared Step (Login to WERCSmart - Premium Account)
Then I delete the Supplier Report file saved as 73082
# Please do a new thing
Given I click the Supplier Reports icon in the QuickLinks Pane
Given Under the Supplier Reports menu I choose: another choice
Given In the Supplier Reports screen I click on the Download button
Given I click on close in the Report Download dialog
Given I confirm that an excel file is produced called UPCs and Registrations (Retailer Specific).xlsx and save as 73082
Then I confirm that in the excel file saved as: 73082 for the UPC saved as: UPC876851 there is a 'Y' in the Case Pack column and an Individual UPC listed as: UPC87685



Scenario: [122365] Create a distributor request and process it to completed

Given I generate a random UPC number and save as: UPC86463
Given I log in with the account saved in TReVor as: PremiumSubscriptionAccount
Given I create a Chalk product and take to completed for distributor and save as: TestCase0001
Given I navigate to the landing page
Given I log in with the account saved in TReVor as: CanadaHasAllData
Then the WERCSmart homepage should load
Given I create a distibutor request as TestCase0002 and send to manufacturer
Given I navigate to the landing page
Given I log in with the account saved in TReVor as: PremiumSubscriptionAccount
Then the WERCSmart homepage should load
Given I click on My Account
Given In the My Account page I navigate to the My Library page
Given I navigate to the My Distributors tab in the My Library page
Given I search for the product in My Distributor: TestCase0001
Given I click Approve for the most recent product returned in my dist
Given I navigate to the landing page
Given I log in with the account saved in TReVor as: CanadaHasAllData
Then the WERCSmart homepage should load
Then I search for the product saved as: TestCase0002
Then I click Row Actions for the first product returned
Then I click on the Row Action: Edit
Then I should see the Distributor Request - UPC Selection Page
Then I click Save in The Product Page
Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Amazon
Given I call Shared Step for dist - UPC - Add UPCName, Container type, Size and Package type (no retailer data needed) - Continue for UPC Name: test, container type: Metal Container and size: 5
Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
Then In the Thank You screen I confirm the following statement is shown: Thank you for registering your product on WERCSmart for assessment.
Then I call Shared Step 65080 (Login to Studio and Open SHA manager)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase0002)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase0002 and its status is: Submitted
Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase0002)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase0002)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase0002 and its status is: Accepted or Completed


Scenario: [139445] CA Cleaning - Ingredients Screen - Validation for INTENTIONALLY ADDED Ingredient Type and Multi-Select Functional Purpose

Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): General Purpose Cleaner - Non-aerosol
Given I call Shared Step 57501 (Product Characteristics - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue - HP)
Given I set the Which one best describes your product option to: Product is not considered a pesticide product
Given In the Additional Product Information Screen I answer the questions as follows - US only - No to GHS - No to shipped supplier - Yes to CA Cleaning - No to Private Label - No to Sold to retailer)
Then I click continue
# Please insert Shared Step
# 139442 here
# Continue to the California Cleaning Product Disclosure Page
# Select the 'Manufacturer' Radio Button for Publicly Identified on the Product Label
Given In the California Cleaning Product Disclosure tab, I enter: NONE in the Final Domestic Distributor
# Select the 'NO' Button for CBI
Given In the Claifornia Cleaning Product Disclosure I choose 'Manufacturer' and select 'No' for CBI, then enter Placeholder Details
Given In the California Cleaning Product Disclosure tab, I enter: 1-800-258-7412 in the Company's Toll-Free Phone Number
Given In the California Cleaning Product Disclosure tab, I enter: http://google.com in the Company Web Address
# From the GTIN Brick Code Drop-Down - Select [10000397] Cleaning Aids
Given I set the Product's GTIN Brick Code to: [10000397] Cleaning Aids
# Click CONTINUE
Then I click continue
# Enter CAS/Chemical Name - 68515-73-1 - D-Glucopyranose, oligomeric, octyl glycosides @ 100% - Publicly Disclosed Checked - Public Name
# Select INTENTIONALLY ADDED for Ingredient Type
Given I add the following CA Cleaning ingredients:  
		| ComponentName                                       | Percent | PublicallyDisclosed | TradeSecret | PublicName      | IngredientType      | FunctionalPurpose | Clean | Certified |
		| D-Glucopyranose, oligomeric, decyl octyl glycosides | 100     | true                | false       | Decyl Glucoside | Intentionally Added | Abrasive          | true  | true      |
# CONFIRM that the CHOOSE Button becomes available - In addition an warning message will display "Please select at least one Functional Purpose since Ingredient Type is indicated to be Intentionally Added"
# Click on the CHOOSE...Button
# CONFIRM a drop-down menu opens
# Scroll down using the side scroll bar
# Click on BRIGHTENING AGENT
# CONFIRM the selection populates in the field
# Make a second selection - Select DEODORIZING AGENT
# CONFIRM the second selection populates in the field
# Scroll down using the side scroll bar to make a third selection
# Click on PROCESSING AID
# CONFIRM the selection populates in the field
# Click on the CLOSE BUTTON
# CONFIRM the side menu drop-down closes
# CONFIRM ALL 3 selections display in the field under Functional Purpose
Then I click continue
# CONFIRM no error message pop-ups show
# CONFIRM it transitions to the WASTE CLASSIFICATION DATA TSCA Page
Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: ThisProduct



Scenario: [141144] SHA Manager - Clear Shopping Cart Action - Email

Given I create an email AdminEmailAddress and save it as AdminEmailAddress
Given I save the current emails in the inbox for address saved as: AdminEmailAddress
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk
Given I call Shared Step 26897 (Product Characteristics - Solid only available - continue)
Given I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Water
Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Given I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue) for
| Retailer  |
| Walgreens |
Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: CVS, container type: Plastic Container and size: 2
Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
Given in the Optional Reports and Documents Available for Purchase page I click Continue
Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: test
Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
# In the next step, just go to the home page. Do NOT click Confirm Order in the Purchase Summary screen. Our goal here is to have items in the cart.
Given I click the Home navigation icon
# Ensure that there are two items in the cart (Cart icon with a little number next to it)
Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
Given I Click 'Suppliers' in SHA Manager
Then In the Supplier Manager Popup I select radio button: E-Mail
Given In the Supplier Manager Popup I enter the following search term: Automated Products
Given In the Supplier Manager Popup I click on the search button
Given In the Supplier Manager Popup I click on the first supplier returned
Given In The Supplier Manager popup I click on the category: Subscription
# Ensure that you see a button with the text "Clear Cart for All Users"
# Click the Clear Cart for All Users button
Given In The Supplier Manager popup I click on the 'Clear Cart for All Users' button
# Ensure you see a popup with the following text: You have selected to clear the shopping cart for this account. The Account's Administrator(s) will be notified via email of this action.  Are you sure you want to proceed? It cannot be reversed.
Given In the Clear Cart for All Users Popup I confirm the correct text is displayed
# Click Continue on the popup
Given In the Clear Cart for All Users Popup I click the Continue button
# Enter the UserID and Password for SHA Manager into the UserID and Password fields in the popup
# click Continue in the credentials popup
Given In the Clear Shopping Cart Popup I enter the following UserID: QASHA, Password: aThewercs1!, TFS Ticket Number: a, Support Ticket Number: a then I click Continue
# Ensure you see a confirmation popup with the following text: The Cart has successfully been cleared for all users from the active database. the account administrator has been notified via email.
Given In the Results Clear Shopping Cart for All Users Popup I confirm the correct text is displayed
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
# Confirm that the Cart icon in the left navigation panel shows there are 0 items in the cart
Given there should be a new email for email Address saved as: AdminEmailAddress from: ULSCN.Notifications@ULNotification.com with the title: WERCSmart Shopping Cart Cleared by UL
Given the body of the email should show: Your shopping cart has been cleared of registrations by a UL representative as requested by your organization. Registrations may be restored to your cart and submitted. No registration data has been affected by removal from the shopping cart. If you have any questions regarding this action, please contact us at WERCSmartCustomer@UL.com.  Thank you.  The WERCSmart Team @ UL  Important Notice: This e-mail may contain privileged or confidential information. If you are not the intended recipient (1) you may not disclose, use, distribute, copy or rely upon this message or attachment(s); and (2) please notify UL PSi at WERCSmartCustomer@ul.com and then delete this message and its attachment(s). UL PSi and its affiliates disclaim all liability for any errors, omissions, corruption or virus in this message or any attachment(s).







Scenario: [140441] SHA Manager - Clear Shopping Cart Action

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk
Given I call Shared Step 26897 (Product Characteristics - Solid only available - continue)
Given I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Water
Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Given I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue) for
| Retailer  |
| Walgreens |
Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: CVS, container type: Plastic Container and size: 2
Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
Given in the Additional Documents to Provide page I click Continue
Given in the Optional Reports and Documents Available for Purchase page I click Continue
And I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
		| Gloves                        | 120                      | 4                       | 10.0      | Black      | Odorless | No data available | 1                     |
Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: test
Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
# In the next step, just go to the home page. Do NOT click Confirm Order in the Purchase Summary screen. Our goal here is to have items in the cart.
Given I click the Home navigation icon
# Ensure that there are two items in the cart (Cart icon with a little number next to it)
Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
Given I Click 'Suppliers' in SHA Manager
Then In the Supplier Manager Popup I select radio button: E-Mail
Given In the Supplier Manager Popup I enter the following search term: User_827ded5e92e5.kxxyxunf@mailosaur.io
Given In the Supplier Manager Popup I click on the search button
Given In the Supplier Manager Popup I click on the first supplier returned
Given In The Supplier Manager popup I click on the category: Subscription
# Ensure that you see a button with the text "Clear Cart for All Users"
# Click the Clear Cart for All Users button
Given In The Supplier Manager popup I click on the 'Clear Cart for All Users' button
# Ensure you see a popup with the following text: You have selected to clear the shopping cart for this account. The Account's Administrator(s) will be notified via email of this action.  Are you sure you want to proceed? It cannot be reversed.
# Click Continue on the popup
Given In the Clear Cart for All Users Popup I confirm the correct text is displayed
# Enter the UserID and Password for SHA Manager into the UserID and Password fields in the popup
# click Continue in the credentials popup
Given In the Clear Cart for All Users Popup I click the Continue button
Given In the Clear Shopping Cart Popup I enter the following UserID: QASHA, Password: aThewercs1!, TFS Ticket Number: a, Support Ticket Number: a then I click Continue
# Ensure you see a confirmation popup with the following text: The Cart has successfully been cleared for all users from the active database. the account administrator has been notified via email.
Given In the Results Clear Shopping Cart for All Users Popup I confirm the correct text is displayed
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
# Confirm that the Cart icon in the left navigation panel shows there are 0 items in the cart






Scenario: [141027] Product Types Registered- CSV Zip File

Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)

# Click on My Reports in the left navigation; My Reports screen displays
Given I click the My Reports icon in the QuickLinks Pane

# Select Product Types Registered; right side of the screen becomes active
Given Under the Supplier Reports menu I choose: Product Types Registered

# From the Select File Type dropdown select: CSV
Then I select CSV from the Select File Type

# Select Zip Report checkbox
# Click on Request Report button: Report download pop up appears
Then I select the Request Report button excel file is produced called Product Types Registered.csv and save as Product Types Registered

# Open the report (in Chrome it will be on the bottom of the browser) File Zip pop up window opens
# Double click on the file
# Confirm report opens properly without any errors and as a csv file
# Close Report
Given I click the Products in Scope button and confirm that an excel file is produced called Product Types Registered.csv and save as Product Types Registered
Given I delete the excel file saved as Product Types Registered

# Click Close button on Report Download pop up, My Reports screen refreshes
Then I click Close in the Report Download popup

# Confirm Product Types Registered report name appears in the history table
# File Type  appears as: CSV (Zip)
Given I click the Products in Scope button and confirm that an excel file is produced called Product Types Registered.csv and save as Product Types Registered
Given I delete the excel file saved as Product Types Registered

# Date Requested column should show today's date and time stamp
# Requested By Column should show User Name
Then I confirm the most recent file has the following information Report Name: Product Types Registered File Type: CSV Date Requested: 1/1/1111 Requested By: WERCS Test_Automation_ProductsAccount

# In the Actions column you should see the download button
# Click Download button; Report download pop up shows
# Open the report (in Chrome it will be on the bottom of the browser) File Zip pop up window opens
Then I click the Download button for the most recent Report

# Double click on the File
# Confirm report opens properly without any errors
# Close the report
Given I click the Products in Scope button and confirm that an excel file is produced called Product Types Registered (1).csv and save as Product Types Registered (1)
Given I delete the excel file saved as Product Types Registered (1)

# Close Report download pop up
Then I click Close in the Report Download popup





Scenario: [141028] Registration Updates Not Submitted- CSV Zip File

Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)

# Click on My Reports in the left navigation; My Reports screen displays
Given I click the My Reports icon in the QuickLinks Pane

# Select Registration Updates Not Submitted; right side of the screen becomes active
Given Under the Supplier Reports menu I choose: Registration Updates Not Submitted

# From the Select File Type dropdown select: CSV
Then I select CSV from the Select File Type

# Select Zip Report checkbox
# Click on Request Report button: Report download pop up appears
Then I select the Request Report button excel file is produced called Registration Updates Not Submitted.csv and save as Registration Updates Not Submitted

# Open the report (in Chrome it will be on the bottom of the browser) File Zip pop up window opens
# Double click on the file
# Confirm report opens properly without any errors and as a csv file
# Close Report
Given I click the Products in Scope button and confirm that an excel file is produced called Registration Updates Not Submitted.csv and save as Registration Updates Not Submitted
Given I delete the excel file saved as Registration Updates Not Submitted

# Click Close button on Report Download pop up, My Reports screen refreshes
Then I click Close in the Report Download popup

# Confirm Registration Updates Not Submitted report name appears in the history table
# File Type  appears as: CSV (Zip)
Given I click the Products in Scope button and confirm that an excel file is produced called Registration Updates Not Submitted.csv and save as Registration Updates Not Submitted
Given I delete the excel file saved as Registration Updates Not Submitted

# Date Requested column should show today's date and time stamp
# Requested By Column should show User Name
Then I confirm the most recent file has the following information Report Name: Registration Updates Not Submitted File Type: CSV Date Requested: 1/1/1111 Requested By: WERCS Test_Automation_ProductsAccount

# In the Actions column you should see the download button
# Click Download button; Report download pop up shows
# Open the report (in Chrome it will be on the bottom of the browser) File Zip pop up window opens
Then I click the Download button for the most recent Report

# Double click on the File
# Confirm report opens properly without any errors
# Close the report
Given I click the Products in Scope button and confirm that an excel file is produced called Registration Updates Not Submitted (1).csv and save as Registration Updates Not Submitted (1)
Given I delete the excel file saved as Registration Updates Not Submitted (1)

# Close Report download pop up
Then I click Close in the Report Download popup




Scenario: [141029] Subscription Product Types- CSV Zip File

Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)

# Click on My Reports in the left navigation; My Reports screen displays
Given I click the My Reports icon in the QuickLinks Pane

# Select Subscription Product Types; right side of the screen becomes active
Given Under the Supplier Reports menu I choose: Subscription Product Types

# From the Select File Type dropdown select: CSV
Then I select CSV from the Select File Type

# Select Zip Report checkbox
# Click on Request Report button: Report download pop up appears
Then I select the Request Report button excel file is produced called Subscription Product Types.csv and save as Subscription Product Types

# Open the report (in Chrome it will be on the bottom of the browser) File Zip pop up window opens
# Double click on the file
# Confirm report opens properly without any errors and as a csv file
# Close Report
Given I click the Products in Scope button and confirm that an excel file is produced called Subscription Product Types.csv and save as Subscription Product Types
Given I delete the excel file saved as Subscription Product Types

# Click Close button on Report Download pop up, My Reports screen refreshes
Then I click Close in the Report Download popup

# Confirm Subscription Product Types report name appears in the history table
# File Type  appears as: CSV (Zip)
Given I click the Products in Scope button and confirm that an excel file is produced called Subscription Product Types.csv and save as Subscription Product Types
Given I delete the excel file saved as Subscription Product Types

# Date Requested column should show today's date and time stamp
# Requested By Column should show User Name
Then I confirm the most recent file has the following information Report Name: Subscription Product Types File Type: CSV Date Requested: 1/1/1111 Requested By: WERCS Test_Automation_ProductsAccount

# In the Actions column you should see the download button
# Click Download button; Report download pop up shows
# Open the report (in Chrome it will be on the bottom of the browser) File Zip pop up window opens
Then I click the Download button for the most recent Report

# Double click on the File
# Confirm report opens properly without any errors
# Close the report
Given I click the Products in Scope button and confirm that an excel file is produced called Subscription Product Types (1).csv and save as Subscription Product Types (1)
Given I delete the excel file saved as Subscription Product Types (1)

# Close Report download pop up
Then I click Close in the Report Download popup






Scenario: [141034] UPC Duplication- CSV Zip File

Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)

# Click on My Reports in the left navigation; My Reports screen displays
Given I click the My Reports icon in the QuickLinks Pane

# Select UPC Duplication; right side of the screen becomes active
Given Under the Supplier Reports menu I choose: UPC Duplication

# From the Select File Type dropdown select: CSV
Then I select CSV from the Select File Type

# Select Zip Report checkbox
# Click on Request Report button: Report download pop up appears
Then I select the Request Report button excel file is produced called UPC Duplication.csv and save as UPC Duplication

# Open the report (in Chrome it will be on the bottom of the browser) File Zip pop up window opens
# Double click on the file
# Confirm report opens properly without any errors and as a csv file
# Close Report
Given I click the Products in Scope button and confirm that an excel file is produced called UPC Duplication.csv and save as UPC Duplication
Given I delete the excel file saved as UPC Duplication

# Click Close button on Report Download pop up, My Reports screen refreshes
Then I click Close in the Report Download popup

# Confirm UPC Duplication report name appears in the history table
# File Type  appears as: CSV (Zip)
# Date Requested column should show today's date and time stamp
# Requested By Column should show User Name
Then I confirm the most recent file has the following information Report Name: UPC Duplication File Type: CSV Date Requested: 1/1/1111 Requested By: WERCS Test_Automation_ProductsAccount

# In the Actions column you should see the download button
# Click Download button; Report download pop up shows
Then I click the Download button for the most recent Report

# Open the report (in Chrome it will be on the bottom of the browser) File Zip pop up window opens
# Double click on the File
# Confirm report opens properly without any errors
# Close the report
Given I click the Products in Scope button and confirm that an excel file is produced called UPC Duplication (1).csv and save as UPC Duplication (1)
Given I delete the excel file saved as UPC Duplication (1)

# Close Report download pop up
Then I click Close in the Report Download popup




Scenario: [141036] Volatile Organic Compounds- CSV Zip File

Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)

# Click on My Reports in the left navigation; My Reports screen displays
Given I click the My Reports icon in the QuickLinks Pane

# Select Volatile Organic Compounds; right side of the screen becomes active
Given Under the Supplier Reports menu I choose: Volatile Organic Compounds

# From the Select File Type dropdown select: CSV
Then I select CSV from the Select File Type

# Select Zip Report checkbox
# Click on Request Report button: Report download pop up appears
Then I select the Request Report button excel file is produced called Volatile Organic Compounds.csv and save as Volatile Organic Compounds

# Open the report (in Chrome it will be on the bottom of the browser) File Zip pop up window opens
# Double click on the file
# Confirm report opens properly without any errors and as a csv file
# Close Report
Given I click the Products in Scope button and confirm that an excel file is produced called Volatile Organic Compounds.csv and save as Volatile Organic Compounds
Given I delete the excel file saved as Volatile Organic Compounds

# Click Close button on Report Download pop up, My Reports screen refreshes
Then I click Close in the Report Download popup

# Confirm Volatile Organic Compounds report name appears in the history table
# File Type  appears as: CSV (Zip)
# Date Requested column should show today's date and time stamp
# Requested By Column should show User Name
Then I confirm the most recent file has the following information Report Name: Volatile Organic Compounds File Type: CSV Date Requested: 1/1/1111 Requested By: WERCS Test_Automation_ProductsAccount

# In the Actions column you should see the download button
# Click Download button; Report download pop up shows
Then I click the Download button for the most recent Report

# Open the report (in Chrome it will be on the bottom of the browser) File Zip pop up window opens
# Double click on the File
# Confirm report opens properly without any errors
# Close the report
Given I click the Products in Scope button and confirm that an excel file is produced called Volatile Organic Compounds (1).csv and save as Volatile Organic Compounds (1)
Given I delete the excel file saved as Volatile Organic Compounds (1)

# Close Report download pop up
Then I click Close in the Report Download popup






Scenario: [141041] Waste Classification Summary- CSV Zip File

Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)

# Click on My Reports in the left navigation; My Reports screen displays
Given I click the My Reports icon in the QuickLinks Pane

# Select Waste Classification Summary; right side of the screen becomes active
Given Under the Supplier Reports menu I choose: Waste Classification Summary

# From the Select File Type dropdown select: CSV
Then I select CSV from the Select File Type

# Select Zip Report checkbox

# Click on Request Report button: Report download pop up appears
Then I select the Request Report button excel file is produced called Waste Classification Summary.csv and save as Waste Classification Summary

# Open the report (in Chrome it will be on the bottom of the browser) File Zip pop up window opens
# Double click on the file
# Confirm report opens properly without any errors and as a csv file
# Close Report
Given I click the Products in Scope button and confirm that an excel file is produced called Waste Classification Summary.csv and save as Waste Classification Summary
Given I delete the excel file saved as Waste Classification Summary

# Click Close button on Report Download pop up, My Reports screen refreshes
Then I click Close in the Report Download popup

# Confirm Waste Classification Summary report name appears in the history table
# File Type  appears as: CSV (Zip)
# Date Requested column should show today's date and time stamp
# Requested By Column should show User Name
Then I confirm the most recent file has the following information Report Name: Waste Classification Summary File Type: CSV Date Requested: 1/1/1111 Requested By: WERCS Test_Automation_ProductsAccount

# In the Actions column you should see the download button
# Click Download button; Report download pop up shows
Then I click the Download button for the most recent Report

# Open the report (in Chrome it will be on the bottom of the browser) File Zip pop up window opens
# Double click on the File
# Confirm report opens properly without any errors
# Close the report
Given I click the Products in Scope button and confirm that an excel file is produced called Waste Classification Summary (1).csv and save as Waste Classification Summary (1)
Given I delete the excel file saved as Waste Classification Summary (1)

# Close Report download pop up
Then I click Close in the Report Download popup




	























































































































	#Done
Scenario: [128140] Data Tier Expansion for BBB - Products in Scope Report - Nutritional Supplement - Nutritional Supplement - Solid

Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561a (The Product - Enter Product Name: Nutritional (Solid) Supplement Product for BBB and select Type of Product): Nutritional Supplement - Solid
Given I generate a random UPC number and save as: UPC128140
Given I call Shared Step 37857 (Enter Physical Property - Solid)
And I call Shared Step 62678 (Additional Product Information - US & Canada, No Child, No OSHA, NO Direct ship, No PL, No NGFR - Continue, Happy path)
Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
| CASNumber | ComponentName | Percent | PublicallyDisclosed | PublicName | TradeSecret |
| 56-85-9   | L-Glutamine   | 100     |                     |            |             |
And I call Shared Step 57637 (Regulatory Information 1 - TSCA & CEPA shown, No to PROP 65 - Continue - Happy Path)
Given I call Shared Step 132473 (Regulatory Information 3 - Nutritional Category)
Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Bed Bath and Beyond (including Harmon, Buy Buy Baby, and Christmas Tree Shops)
Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC128140, container type: Plastic Container and size: 6.2
Given I call Shared Step 60567 (Upload Product Label only)
Given in the Optional Reports and Documents Available for Purchase page I click Continue
Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: «comments»
Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
Given I call Shared Step 130558 (Go to Retail Partners - Select Bed Bath and Beyond)
Given I click the Products in Scope button and confirm that an excel file is produced called BB_Report_DataUsageTier_Current_Month_Day_Year.xlsx and save as Products in Scope Report for BBB
Then I confirm the excel file saved as: Products in Scope Report for BBB contains the following data: Nutritional (Solid) Supplement Product for BBB
Given I delete the excel file saved as Products in Scope Report for BBB


	#Done-Mostly
Scenario: [128144] Login Behavior for Products NOT in Scope for Bed Bath and Beyond

Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561a (The Product - Enter Product Name: Product NOT in Scope for BBB and select Type of Product): Pet Shampoo
Given I generate a random UPC number and save as: UPC128144
Given I call Shared Step 57441 (Product Characteristics - Primary Physical Property - Liquid)
#Then I confirm that the the option: United States is checked for the following section: Select countries the product may be sold in
Given I set the Select countries the product may be sold in option to: Canada
Given I set the Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada) option to: No
Given I set the Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns. option to: No
Given I set the Product is a Retailer's Private Label or Brand option to: No
Given I set the Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale) option to: No
Then I click continue
Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
| CASNumber  | ComponentName                   | Percent | PublicallyDisclosed | PublicName | TradeSecret |
| 61789-31-9 | Fatty Acids, coco, sodium salts | 100     |                     |            |             |
And I call Shared Step 57637 (Regulatory Information 1 - TSCA & CEPA shown, No to PROP 65 - Continue - Happy Path)
Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Bed Bath and Beyond (including Harmon, Buy Buy Baby, and Christmas Tree Shops)
And I call Shared Step 87647 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC128144, container type: Plastic Container and size: 6.2 do not click continue
Then I click continue
Given I call Shared Step 78868 - Regulatory Documents to Provide - US and Canada - Request authoring for both
Given I call Shared Step 60567 (Upload Product Label only)
Then I click continue
And I call Shared Step 64097 - Additional Documents -> Contact Information - Add any Name, address, phone and emergency phone - Happy Path
Given I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
		| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
	Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: «comments»
Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
Given I call Shared Step 130558 (Go to Retail Partners - Select Bed Bath and Beyond)
Given I click the Products in Scope button and confirm that an excel file is produced called BB_Report_DataUsageTier_Current_Month_Day_Year.xlsx and save as PRODUCTS NOT IN SCOPE REPORT FOR BBB
Then I confirm the excel file saved as: PRODUCTS NOT IN SCOPE REPORT FOR BBB does not contain the following data: Product NOT in Scope for BBB
Given I delete the excel file saved as PRODUCTS NOT IN SCOPE REPORT FOR BBB
Given I navigate to the home page
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
# Confirm that the 'Data Consent Tier' Pop-Up Window Does Not Show


Scenario: [123456] Create a new simple product (Chalk) and process from NEW to Accepted

Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
Then I save the product information as: TestCaseCreate
Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Chlorine
Given I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue) for
| Retailer  |
| Walgreens |
| Amazon    |
Given I call Shared Step 60533 (Additional Documents to Provide - Flash Point and Product Label only) : documentPathNeeded
# Document path needed in above step



Scenario: [129793] Advanced Reporting - Last 30 Days, Random Product for Reviewer

Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
Then I select the: Last 30 Days, Random Product for Reviewer report from Advanced Reporting in SHA
Then I Check that the Description Text for the Report: Last 30 Days, Random Product for Reviewer is shown as: 20 Random Products for a Reviewer in the Last 30 Days
Then I wait for the Advanced Reporting Preparing Report popup to disappear
Given I confirm that an excel file is produced called Last 30 Days, Random Product for Reviewer.xls and save as 125585
Then I confirm that the excel file saved as: 125585 contains the following columns:
| Column              |
| ID                  |
| Product Name        |
| Reviewer            |
| Last Published Date |
Then I delete the Advanced Report file saved as 125585
# Need to add a shared step for Populating the reviewer input field. Input with the automation account (might need to use amandac) and click submit


Scenario: [133610] Formulation Screen:  Attestation Reset on Data Change

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561a (The Product - Enter Product Name: TRAP AND/OR BAIT STATION TEST PRODUCT and select Type of Product): Trap and/or Bait Station
Then I save the product information as: TestCase133610
Given I set the Primary Physical State option to: Solid
Given I set the Secondary Physical State option to: Solid
Given I set the When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5? option to: No
Then I click continue
And I see the following sections
| Section                               |
| Which one best describes your product |
Given I set the Which one best describes your product option to: Product is not considered a pesticide product
#Then I confirm that the the option: United States is checked for the following section: Select countries the product may be sold in
Given I set the Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada) option to: No
Given I set the Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns. option to: No
Given I set the Product is a Retailer's Private Label or Brand option to: No
Given I set the Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale) option to: No
Then I click continue
Then I add the following ingredients:
| ComponentName	| Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Glutens, corn       | 100     | false         | false       |            |
Then I click continue
Then I confirm there is a popup view titled: Product Contains Ingredients Typical of a Pesticide in the Ingredients page
Then In the popup view with the following title: Product Contains Ingredients Typical of a Pesticide I confirm I see the following statement in the popup view: You've indicated the product is not a pesticide under the EPA's Federal Insecticide and Rodenticide Act (FIFRA).
Then I confirm the table in the popup view has following column data
| CAS Number | Name                   | Active or Inert |
| 66071-96-3 | Glutens, corn          | Active          |
Then In the popup view with the following title: Product Contains Ingredients Typical of a Pesticide I click the Go back button
And I should see the Ingredients Page
When In the New Product page I click tab: Product Type
And I click the page heading: The Product
And I should see the The Product Page
And I set the Product Name as it a appears on the Package Label, Container or Safety Data Sheet (SDS) field to: RESET PRODUCT
And I set 'Type of Product' to: Chalk
Then I save the product information as: TestCase133610
Then I click continue
Then I click continue
Given I set the Primary Physical State option to: Solid
Given I set the Secondary Physical State option to: Solid
Given I set the When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5? option to: No
Given I set the Select the best Water Solubility description option to: Soluble in water
Then I click continue
And I should see the Additional Product Information Page
And I see the following sections
| Section                               |
| Which one best describes your product |
Given I set the Which one best describes your product option to: Product is not considered a pesticide product
Given I set the Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under) option to: No
Given I set the Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada) option to: No
Given I set the Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns. option to: No
Given I set the Product is a Retailer's Private Label or Brand option to: No
Given I set the Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale) option to: No
Then I click continue
And I should see the Ingredients Page
Then I click continue
Then I confirm there is not a popup view titled: Product Contains Ingredients Typical of a Pesticide in the Ingredients page
And I should see the Waste Classification Data Page
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase133610

Then I click close for the warning popup titled: California Cleaning Right to Know




Scenario: [87275] US & Canada - PL = Yes, Retailer is NOT Canadian Tire, no error re package type on forward
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Given I filter the products by: Accepted by Retailers
Given I search for the product saved as: TestCase86187
And I Confirm the Products shown display the Green Colour Status - which is the Accepted by Retailers
And I call Shared Step 75130 - Bulk Actions - Select Forward Product Registration
And I enter the text: saved as TestCase86187 in the 'Search by WPS ID or Product Name' field
And In the Foward Product Registration Screen I should see product: saved as TestCase86187
And In the Foward Product Registration Screen I Select the product: saved as TestCase86187
And I click continue on the Forward Product Registration page
And In the Forward Product Registration Screen I select the first retailer that does not require additional data and is not: Canadian Tire under Other Retailers and save it as: retailer87217
And I click continue on the Forward Product Registration page
And I call Shared Step 86002 (Forwarding - PLP - Select Product: saved as TestCase86187 & UPCs step - Edit existing UPC Confirm)

And If the Private Label textbox is showing in the Select UPCs screen, I enter the value: N/A
And I call Shared Step 86824 (Forwarding - Select Existing UPC, Click Continue, No error for Package type)

And I should see the subheading 3: Product Results on the Forward Product Registration window
And I click continue on the Forward Product Registration page
And I should see the subheading 3: Review & Submit on the Forward Product Registration window
And I select the true radio for the 'Are Statements True' question under the Review and Submit tab
And I click continue on the Forward Product Registration page
And In the Purchase Summary screen I confirm the Purchase Summary header is displayed
Then In the Thank You screen I confirm the following statement is shown: Thank you for registering your product on WERCSmart for assessment.



Scenario: [85963] Forward Product - US Only - PL = Yes, Packaging type not required/shown
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Given I filter the products by: Accepted by Retailers
Given I search for the product saved as: TestCase86187
And I Confirm the Products shown display the Green Colour Status - which is the Accepted by Retailers
And I call Shared Step 75130 - Bulk Actions - Select Forward Product Registration
And I enter the text: saved as TestCase86187 in the 'Search by WPS ID or Product Name' field
And In the Foward Product Registration Screen I should see product: saved as TestCase86187
And In the Foward Product Registration Screen I Select the product: saved as TestCase86187
And I click continue on the Forward Product Registration page
And In the Forward Product Registration Screen I select the first retailer that does not require additional data and is not: Canadian Tire under Other Retailers and save it as: retailer87217
And I click continue on the Forward Product Registration page
And I call Shared Step 86002 (Forwarding - PLP - Select Product: saved as TestCase86187 & UPCs step - Edit existing UPC Confirm)

#And If the Private Label textbox is showing in the Select UPCs screen, I enter the value: N/A
#And I call Shared Step 86824 (Forwarding - Select Existing UPC, Click Continue, No error for Package type)

And I should see the subheading 3: Product Results on the Forward Product Registration window
And I click continue on the Forward Product Registration page
And I should see the subheading 3: Review & Submit on the Forward Product Registration window
And I select the true radio for the 'Are Statements True' question under the Review and Submit tab
And I click continue on the Forward Product Registration page
And In the Purchase Summary screen I confirm the Purchase Summary header is displayed
Then In the Thank You screen I confirm the following statement is shown: Thank you for registering your product on WERCSmart for assessment.


Scenario: [87922] Universal Product Code (UPC) Step - Add Case UPC - Size (Weight Ounces) field validation
Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Bleach
Given I generate a random UPC number and save as: UPC87633
Then I save the product information as: TestCase87633
Given I call Shared Step 57501 (Product Characteristics - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue - HP)
Given I set the Which one best describes your product option to: Product is not considered a pesticide product
Given I call Shared Step 118064 (Additional Product Information - US only - No GHS, Not Direct Ship, Not CA Cleaning ,Not PLP, Not GNFR > Continue - Happy Path)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Chlorine
Then I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
Then I call Shared Step 126160 (U.S. Department of Transportation (DOT) Classification - Enter UN1057 - Lighter Fluid)
Given I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue) for
| Retailer  |
| Walgreens |
And I should see the Universal Product Code Page
And I call Shared Step 87647 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC87633, container type: Plastic Container and size: abc do not click continue
Given I check for the appropriate alert: This field must be a number
Given I fill in the UPC data; UPC:UPC87633, Product Type:Plastic Container, Product Weight: +6
Then I click continue
Given I check for the appropriate alert: This field must be a number
Given I fill in the UPC data; UPC:UPC87633, Product Type:Plastic Container, Product Weight: 6
Then I check for the appropriate alert: No error
Then I click continue
And I should see the Regulatory Documents to Provide Page
Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase87633


Scenario: [87691] UPC - Case Pack, Recertification by WERCSmart User - Remove Case Pack Leaving Only Regular UPC
Given I Use Test case 87685 to create a product which has a Case UPC and a regular UPC, processed to completed status
Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
And I filter for the product saved as: TestCase87685
	And I Confirm the Products shown display the Green Colour Status - which is the Accepted by Retailers
	Given I click Bulk Actions in the Products Grid
	Then I should see a popup with header Bulk Actions
	And I click on the Row Action: Update Data
	And I should see the Update Registration popup
	And In the Update Registration popup I click on button Yes
	#And I If you are using a supplier registered for ULSC you will see the ULSC Service Data-Re-Import step, select the No, continue editing data radio button and click Save
	And I should see the The Product Page
	Then I click Save in The Product Page
	When In the New Product page I click tab: Recipient and UPC Details
	And I click the page heading: Universal Product Code (UPC)
	Then I confirm the case dropdown with the following UPC: saved as UPC87685 should be available for selection
    Then I Click Delete Rows
	Then I confirm the case dropdown with the following UPC: saved as UPC87685 should not be available for selection
    Then I click Continue and should not see an error message
	When In the New Product page I click tab: Review and Submit
	And I click the page heading: Additional Documents to Provide
	And I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	And In the Purchase Summary screen I confirm the Purchase Summary header is displayed
	And In the Purchase Summary screen if Product Billing is displayed I click Confirm Order
