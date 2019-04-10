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
@ProductSetUp
@DataSummarySheet
@run_ReleaseDay

Feature: Release Day

@71051
@TReVorId:20209
Scenario: [71051] Pesticide Details - EPA Registration number if edited is NOT refresh from Kelly when the Update WERCSmart data link is used

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))

Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Pet Shampoo with Pest Control

Then I save the product information as: TestCase71051

Given I call Shared Step 57514 (Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path)

Given I call Shared Step 57865 (Additional Product Information - Pesticide shown, US only, select No for everything else - Happy Path)

Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide

Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)

Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path

And I should see the Pesticide Details - U.S. Page

And I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: Yes

Given in the New Product page I click Continue

Given I add the EPA registration number: 72315-6

Given in the New Product page I click Continue

And I should see the Pesticide Details - State Registration Details Page

Given I update each Registration Number with the appended text '-edited'

Given in the New Product page I click Continue

And I should see the Transportation Details 1 Page

Then in the New Product page I click section: Pesticide Details - State Registration Details

And I should see the Pesticide Details - State Registration Details Page

Then I check each State Pesticide Registration Number contains the edited suffix

Given I click the Update Wercs Smart data with EPA data through Kelly Services link

Then I check each State Pesticide Registration Number contains the edited suffix

Given I navigate to the home page

Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase71051

@tfs_design
Scenario: [56909] Retailer Detail Page - Retailer does not require Supplier ID but does require Data Consent Tiers
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load

# Retail Partners Page
And I click the Retail Partners icon in the Navigation Pane
Then I should see the following heading Retail Partners
And I select the retailer: Costco

# Retailer Detail Page
Then I should see the retailer heading: Costco
And I confirm that there is a section labeled: Your Supplier IDs
And Section: Your Supplier IDs should be showing text: This retailer does not support Supplier ID management
And I confirm that there is a section labeled: Data Consent Tiers
And I should see the button: What are the Data Usage Tiers? in section: Data Consent Tiers
And I should see the button: Products in Scope in section: Data Consent Tiers
And I confirm that there is a section labeled: Costco & You
And The pie chart should be showing on the retailer details page
And The pie chart footer text should contain: % of your product portfolio is associated with Costco


@TReVorId:20224
Scenario: [56914] Retailer Detail Page - Retailer requires Supplier ID and Data Consent Tiers
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load

# Retail Partners Page
And I click the Retail Partners icon in the Navigation Pane
Then I should see the following heading Retail Partners
And I select the retailer: Wal-Mart

# Retailer Detail Page
Then I should see the retailer heading: Wal-Mart/SAM'S CLUB
And I confirm that there is a section labeled: Your Supplier IDs
And The Supplier ID Table should be showing
And I confirm that there is a section labeled: Data Consent Tiers
And I should see the button: What are the Data Usage Tiers? in section: Data Consent Tiers
And I should see the button: Products in Scope in section: Data Consent Tiers
And I confirm that there is a section labeled: Wal-Mart/SAM'S CLUB & You
And The pie chart should be showing on the retailer details page
And The pie chart footer text should contain: % of your product portfolio is associated with Wal-Mart/SAM'S CLUB

@78417
@TReVorId:21865
Scenario: [78417] Recert by WERCSMart user
Given I create a product with name: 78417 and take to completed using Test Case 75335 and save as: TestCase42273
Given I take a product from completed to recertification using Test Case 75410 saved: TestCase78417
And I call Shared Step 65080 (Login to Studio and Open SHA manager)
And I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase78417)
And I call Shared Step 44240 - SHA - Recertification > process recertification to Assigned status for product saved as TestCase78417
And I Use Test case 84518 to process the product from Assigned back to Completed status saved as TestCase78417

@TReVorId:22087
@ForwardProductRegistration
@TReVorId:22087
Scenario: [75321] Forward Product - Completed Status (NO Recert)
Given I create a product and take to completed using Test Case 75335 and save as: TestCase75321
Given I navigate to the landing page
And I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
And I filter the products by: Accepted by Retailers
And I Confirm the Products shown display the Green Colour Status - which is the Accepted by Retailers
And I filter for the product saved as: TestCase75321
And I call Shared Step 75130 - Bulk Actions - Select Forward Product Registration
Then I should see the header: Forward Product Registration on the Forward Product Registration window
And I enter the text: saved as TestCase75321 in the 'Search by WPS ID or Product Name' field
And In the Foward Product Registration Screen I should see product: saved as TestCase75321
And In the Foward Product Registration Screen I Select the product: saved as TestCase75321
And I click continue on the Forward Product Registration page
#And I Select a "NEW" Retailer which you know is not already associated to the product (should not be present on the note you made earlier)
And In the Forward Product Registration Screen I select a retailer under Other Retailers and save as TestCase75321Retailer
And I Click 'CONTINUE'
And [Shared Step 75140 - Forwarding - Select Products & UPCs step - Add Any missing data and select 1 UPC - Continue]
And I The 'Product Results Tab' is selected
And I Confirm that the UPC Number displays the recently selected "Retailer"(Step 17)
And I Confirm that NO Errors display for the Product
And I Click 'CONTINUE'
And I The 'Review and Submit' step is shown
And I Select the "All of the above statements are true" Radio Button
And I Click 'CONTINUE'
And I Confirm the Purchase Summary page is shown with the success message shown" Thank you for registering your product on WERCSmart for assessment. The retailers may receive your assessment in approximately two (2) business days, if no delays in processing the assessment, and should no data issues arise.  "
And I Click on the 'HOME BUTTON'
And I In SHA Manager
And I In the shared step below search for your product using the WPS ID you noted earlier
And I call Shared Step 49841 (SHA - Search for exact WPS ID in (.*) Status for saved as: (.*))
And I Confirm the Product shows a "Completed Status" for the Original Retailer(see Clients column)
And I Confirm the Productshows a "Submitted Status" for the recently selected Retailer (see clients column)
And [Shared Step 75309 - SHA > Select Product > UPC List]
And I With the SHA Manager Product UPC window open - Click on the 'maximize' icon to expand the view of the window
And I Confirm the recently added Retailer(s)is (are) shown against the UPC you selected
And I Close the SHA Manager Product UPC window
And I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: (.*))
And I In the shared step below search for the Product you are working with
And I call Shared Step 49841 (SHA - Search for exact WPS ID in (.*) Status for saved as: (.*))
And I Confirm the Product shows the ORIGINAL RETAILER(s) with a "Completed Status" (see the Clients column)
And I Confirm the Product shows theNEW RETAILER(s) with an "Accepted Status" (see the Clients column)Note: if you selected a retailer that does not have a feed associated to it you will see the product in Completed status for this retailer)
And I In the Shared Step below - Select the Product with the "Accepted Status"
And I call Shared Step 51664 (SHA - Accepted Product - set Retailers to Completed for saved as: (.*))
And I Confirm the Product now shows a "Completed" Status in Completed for ALL associated Retailers

# Assigned to Barrett, Beverly
# Created by Barrett, Beverly

# Test case can be found at the following paths:
# NetProjects10\WercsSmart Portal\Release Day Tests

Scenario: [73503] VOC - ACP Plan = Yes and CARB Value Above Limit for RU - VOC Results Step Shows Alternative Control Plan
Given I generate a random UPC number and save as: UPC73503
And I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
And I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Insecticide - Fogger
Then I save the product information as: TestCase73503
And I call Shared Step 57532 (Product Characteristics - Aerosol & Gas available - Select Gas - Continue - Happy Path)
And I call Shared Step 57865 (Additional Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
And I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
| ComponentName   | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Sodium chloride | 100   | false               | false       |            |
And I call Shared Step 48360 - Regulatory - Test TSCA and PROP65 - Continue
And I call Shared Step 57589 (Enter Pesticide Data - United States (without EPA number))
And I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
And I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)
And I should see the Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB) Page
And I set the Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations option to: Yes
And I set the Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the CARB option to: 50
And I set the Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the OTC Model Rule option to: 40
And I set the Would you like to use the VOC percentages entered for all areas (e.g. country, state, local) for comparison? option to: Yes
And I click continue
And I should see the Volatile Organic Compound Summary Page
Given I scroll to the bottom of the page
And I confirm statement: Based on the type of product shows the text: Based on the type of product, this must comply with the most restrictive VOC limit.
And I confirm that statement with text: 'Does not exceed the limits specified by the California Consumer Products Regulation' is not displayed
And I confirm that statement with text: 'Exceeds the limit specified by the California Consumer Products Regulation' is not displayed
And The VOC Summary page contains the statement with the text: Alternative Control Plan
And The VOC Summary page contains the statement with the text: Does not exceed the limits specified by the Ozone Transport Commission
And in the New Product page I click section: Volatile Organic Compounds (VOC)
And I set the Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the CARB option to: 30
And I click continue
Given I scroll to the bottom of the page
And I confirm that statement with text: 'Alternative Control Plan' is not displayed
And The VOC Summary page contains the statement with the text: Does not exceed the limits specified in the California Consumer Products Regulation
And in the New Product page I click section: Volatile Organic Compounds (VOC)
And I set the Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations option to: No
And I set the Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the CARB option to: 55
And I click continue
Given I scroll to the bottom of the page
And I confirm that statement with text: 'Alternative Control Plan' is not displayed
And The VOC Summary page contains the statement with the text: Exceeds the limits specified in the California Consumer Products Regulation
And I navigate to the home page
And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase73503

