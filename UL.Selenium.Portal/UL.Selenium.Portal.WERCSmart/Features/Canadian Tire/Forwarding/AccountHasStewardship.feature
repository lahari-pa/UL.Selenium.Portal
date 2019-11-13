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

Feature: Account has Stewardship information

# NetProjects10\WercsSmart Portal\WERCSmart\Canadian Tire - Blue Box Program\Forwarding\Account has Stewardship information\Select Existing UPC - no edit
@ScenarioId:1402
Scenario: [87217] US & Canada - PL = Yes, Retailer is NOT Canadian Tire, no error re package type on forward
Given I create a Completed product using Test Case 86187 (SOLD = US and Canada, PL = Yes, Canadian Tire Retailer Product)
Given I navigate to the landing page
Given I call Shared Step 85328 (Login to WERCSmart - Canada - Address (Yes), Packaging (Yes), Stewardship (Full))
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
And If the Private Label textbox is showing in the Select UPCs screen, I enter the value: N/A
And I call Shared Step 86824 (Forwarding - Select Existing UPC, Click Continue, No error for Package type)
And I should see the subheading 3: Product Results on the Forward Product Registration window
And I click continue on the Forward Product Registration page
And I should see the subheading 3: Review & Submit on the Forward Product Registration window
And I select the true radio for the 'Are Statements True' question under the Review and Submit tab
And I click continue on the Forward Product Registration page
And In the Purchase Summary screen I confirm the Purchase Summary header is displayed
Then In the Thank You screen I confirm the following statement is shown: Thank you for registering your product on WERCSmart for assessment.
And I navigate to the home page


@ScenarioId:6012
Scenario: [85963] Forward Product - US Only - PL = Yes, Packaging type not required/shown
NetProjects10\WercsSmart Portal\WERCSmart\Canadian Tire - Blue Box Program\Forwarding
# I For this test case you will need a product which has SOLD = US only, PL = Yes and is in completed status for 1 or more retailers, use Test case 85965 to create a product in this status.
Given I create a Product using Test Case 85965 (SOLD = US only, PL = Yes, Completed status for 1 or more retailers)
And I navigate to the landing page
And I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
# I Click the Accepted by Retailers Filter heading
Then I filter the products by: Accepted by Retailers
# I Enter the product ID for the product you are working with and press enter
Given I search for the product saved as: TestCase85965
# I Confirm all retailers are shown in the green Accepted by Retailers color
And I Confirm the Products shown display the Green Colour Status - which is the Accepted by Retailers
# [Shared Step 75130 - Bulk Actions - Select Forward Product Registration]
And I call Shared Step 75130 - Bulk Actions - Select Forward Product Registration
# I In the Search by WPS ID or Product name start typing the WPS ID or product name of the product you are working with
And I enter the text: saved as TestCase85965 in the 'Search by WPS ID or Product Name' field
# I Confirm the product is shown for selection
And In the Foward Product Registration Screen I should see product: saved as TestCase85965
# I Select the product by clicking on it
And In the Foward Product Registration Screen I Select the product: saved as TestCase85965
# I Click Continue
And I click continue on the Forward Product Registration page
# I Select a retailer which you know is not already associated to the product
And In the Forward Product Registration Screen I select the first retailer that does not require additional data and is not: Canadian Tire under Other Retailers and save it as: retailer87217
# I Click Continue
And I click continue on the Forward Product Registration page
# [Shared Step 86002 - Forwarding - PLP - Select Product & UPCs step - Edit existing UPC Confirm Package type not shown]
# I The Product Results step is shown
# I Confirm no errors are shown for your product
Then I call Shared Step 86002 (Forwarding - PLP - Select Product: TestCase85965 & UPCs step - Edit existing UPC Confirm)
# I The Review and Submit step is shown
And I should see the subheading 3: Review & Submit on the Forward Product Registration window
# I Select the "All of the above statements are true" radio button
And I select the true radio for the 'Are Statements True' question under the Review and Submit tab
# I Click Continue
And I click continue on the Forward Product Registration page
# I Confirm the Purchase Summary page is shown with the success message shown" Thank you for registering your product on WERCSmart for assessment. The retailers may receive your assessment in approximately two (2) business days, if no delays in processing the assessment, and should no data issues arise.  "
And In the Purchase Summary screen I confirm the Purchase Summary header is displayed
Then In the Thank You screen I confirm the following statement is shown: Thank you for registering your product on WERCSmart for assessment.
# I Click Home
And I navigate to the home page


@ScenarioId:6014
Scenario: [86003] Forward Product - US Only - PL = No, Packaging type not required/shown
NetProjects10\WercsSmart Portal\WERCSmart\Canadian Tire - Blue Box Program\Forwarding

Given I create a product and take to completed using Test Case 75335 and save as: TestCase86003
# I For this test case you will need a product which has SOLD = US only, PL = No and is in completed status for 1 or more retailers, use Test case 75335 to create a product in this status.
And I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Then I filter the products by: Accepted by Retailers
Given I search for the product saved as: TestCase86003
And I Confirm the Products shown display the Green Colour Status - which is the Accepted by Retailers
And I call Shared Step 75130 - Bulk Actions - Select Forward Product Registration
And I enter the text: saved as TestCase86003 in the 'Search by WPS ID or Product Name' field
And In the Foward Product Registration Screen I should see product: saved as TestCase86003
And In the Foward Product Registration Screen I Select the product: saved as TestCase86003
And I click continue on the Forward Product Registration page
And In the Forward Product Registration Screen I select the first retailer that does not require additional data and is not: Canadian Tire under Other Retailers and save it as: retailer87217
And I click continue on the Forward Product Registration page
# [Shared Step 86002 - Forwarding - PLP - Select Product & UPCs step - Edit existing UPC Confirm Package type not shown]
Then I call Shared Step 86004 (Forwarding - Not PLP - Select Product: TestCase86003 & UPCs step - Edit existing UPC Confirm Package Type not shown)
# I The Product Results step is shown
# I Confirm no errors are shown for your product
And I should see the subheading 3: Review & Submit on the Forward Product Registration window
And I select the true radio for the 'Are Statements True' question under the Review and Submit tab
And I click continue on the Forward Product Registration page
And In the Purchase Summary screen I confirm the Purchase Summary header is displayed
Then In the Thank You screen I confirm the following statement is shown: Thank you for registering your product on WERCSmart for assessment.
And I navigate to the home page


Scenario: [87271] US & Canada - PL = Yes, Retailer is NOT Canadian Tire, no error re package type on forward
NetProjects10\WercsSmart Portal\WERCSmart\Canadian Tire - Blue Box Program\Forwarding\Account has partial stewardship information\Select Existing UPC - no edit

Given I For this test case you will need a product which has SOLD = US and Canada, PL = Yes and is in completed status for Canadian Tire, use Test case 86455 to create a product in this status.
And [Shared Step 85770 - Login to WERCSmart - Canada - Address (Yes), Packaging (Yes), Stewardship (Partial)]
And I Click the Accepted by Retailers Filter heading
And I Enter the product ID for the product you are working with and press enter
And I Confirm the Retailers icon is shown in the green Accepted by Retailers color
And [Shared Step 75130 - Bulk Actions - Select Forward Product Registration]
And I In the Search by WPS ID or Product name start typing the WPS ID or product name of the product you are working with
And I Confirm the product is shown for selection
And I Select the product by clicking on it
And I Click Continue
And I Select a retailer other than Canadian Tire, make sure to select a retailer that does not require additional data (such as BB, DI, KG)
And I Click Continue
And I Add Information in the Private Label field for the retailer you selected
And [Shared Step 86824 - Forwarding - Select Existing UPC, Click Continue, No error for Package type]
And I The Product Results step is shown
And I Confirm no errors are shown for your product
And I Click Continue
And I The Review and Submit step is shown
And I Select the "All of the above statements are true" radio button
And I Click Continue
And I Confirm the Purchase Summary page is shown with the success message shown" Thank you for registering your product on WERCSmart for assessment. The retailers may receive your assessment in approximately two (2) business days, if no delays in processing the assessment, and should no data issues arise.  "
And I Click Home

Scenario: [87275] US & Canada - PL = Yes, Retailer is NOT Canadian Tire, no error re package type on forward
NetProjects10\WercsSmart Portal\WERCSmart\Canadian Tire - Blue Box Program\Forwarding\Account has no stewardship information\Select Existing UPC - no edit
Given I For this test case you will need a product which has SOLD = US and Canada, PL = Yes and is in completed status for Canadian Tire, use Test case 86418 to create a product in this status.
And [Shared Step 85324 - Login to WERCSmart - Canada - Address (Yes), Packaging (Yes), Stewardship (No)]
And I Click the Accepted by Retailers Filter heading
And I Enter the product ID for the product you are working with and press enter
And I Confirm the Retailers icon is shown in the green Accepted by Retailers color
And [Shared Step 75130 - Bulk Actions - Select Forward Product Registration]
And I In the Search by WPS ID or Product name start typing the WPS ID or product name of the product you are working with
And I Confirm the product is shown for selection
And I Select the product by clicking on it
And I Click Continue
And I Select a retailer other than Canadian Tire, make sure to select a retailer that does not require additional data (such as BB, DI, KG)
And I Click Continue
And I Add Information in the Private Label field for the retailer you selected
And [Shared Step 86824 - Forwarding - Select Existing UPC, Click Continue, No error for Package type]
And I The Product Results step is shown
And I Confirm no errors are shown for your product
And I Click Continue
And I The Review and Submit step is shown
And I Select the "All of the above statements are true" radio button
And I Click Continue
And I Confirm the Purchase Summary page is shown with the success message shown" Thank you for registering your product on WERCSmart for assessment. The retailers may receive your assessment in approximately two (2) business days, if no delays in processing the assessment, and should no data issues arise.  "
And I Click Home

