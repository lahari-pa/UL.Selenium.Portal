@LandingPage
@Login
@Homepage
@Signup
@RetailPartners
@wercsmart
@run_RetailerPartners

Feature: Retailer Partners

@tfs_design
Scenario: [56881] Retailer Partners - Main Page layout (existing supplier)
# Note: We will have a separate test case for new suppliers views of this page
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load
And I click the Retail Partners icon in the Navigation Pane
Then I should see the following heading Retail Partners
And I should see the following subheading Most Recent Retailers
And I should see Retailer tiles under the Most Recent Retailers heading
And I should see the following subheading All Retailers
And I should see Retailer tiles under the All Retailers heading
And I confirm that the retailers shown under the Most Recent Retailers heading are not repeated under the All Retailers heading
And I confirm that none of the available Retailer Tiles are blank
And I confirm that if the Retailer logo is not shown, then the Retailer name is shown in the Retailer tile
# Below step to be added when we have a db connection string
# And Use the Stored Procedure GET_MOST_RECENT_RETAILERS to confirm that the retailers shown under Most Recent Retailers is correct NOTE: Parameters for the GET_MOST_RECENT_RETAILERS are @SUPPLIERGUID  - different for each supplier  @TOPPRODUCTS - use the number 8 @SOURCESERVICE - use the word PORTAL    Supplier GUID should be enclosed in single quotes   The word PORTAL for the SOURCESERVICE does not need single quotes
# And Use this query to see the list of currently active retailers in Portal select * from t_client where f_active = 1 and ISNULL(f_config.value('(/Client/@Active)[1]','varchar(20)'),'true') = 'true'  order by f_name CONFIRM this list matches the list of retailers you see in the Retail Partners page



Scenario: [56895] Retailer Partners - Main Page layout (New supplier)
Given I Login into WERCSmart Portal - Admin Role - WERCs Visual Account

# Retail Partners Page
And I click the Retail Partners icon in the Navigation Pane
Then I should see the following heading Retail Partners
And I should see the following subheading All Retailers
Then I confirm that none of the available Retailer Tiles are blank

# NB: Cannot do the below - situation is not occuring!
# And I confirm that if an image is not present, then the retailer name is displayed
# And I confirm that the available retailers match those in the database

And I check that the following retailers are showing:
| Retailer               | Code  |
| Ahold                  | AH    |
| Albertsons Companies   | SW    |
| Amazon                 | AM    |
| Autozone               | AZ    |
| Bed Bath and Beyond    | BB    |
| Canadian Tire          | CT    |
| Costco                 | CO    |
| CVS                    | CV    |
| Delhaize               | DA    |
| Dick's Sporting Goods  | DI    |
| Dollar General         | DG    |
| Dollar Tree            | DT    |
| Essendant              | US    |
| Family Dollar          | FD    |
| Genuine Parts          | GP    |
| Harbor Freight Tools   | HF    |
| HD Supply              | HS    |
| HyVee                  | HV    |
| Kroger                 | KG    |
| Lowes                  | LW    |
| McLane                 | ML    |
| Meijer                 | MJ    |
| Michaels               | MI    |
| Northgate Market       | NM    |
| Office Depot           | OD    |
| O'Reilly Auto Parts    | OR    |
| Petco                  | PC    |
| Price Chopper          | PR    |
| Rite Aid               | RA    |
| Save Mart Supermarkets | SM    |
| Schnucks               | SC    |
| Sears K Mart           | SE    |
| Smart & Final          | SF    |
| Staples                | SP    |
| SuperValue             | SV    |
| Target                 | TG    |
| The Home Depot         | HD    |
| Topco                  | TP    |
| Tractor Value Supply   | TS    |
| Ultra Standard         | ST    |
| Unified                | UF    |
| Wakefren               | WF    |
| Walgreens              | WG    |
| BONBONS                | WM-BO |
| Walmart.com            | WM-CO |
| Hayneedle              | WM-HN |
| Jet                    | WM-JE |
| MODCLOTH               | WM-MC |
| Moosejaw               | WM-MJ |
| Shoes.com              | WM-SC |
| Walmart                | WM    |
| Winco Foods            | WC    |
| NewEgg                 | NE    |



Scenario: [56903] Retailer Detail Page - Retailer does not require Supplier ID or Data Consent Tiers
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load
Then I click the Retail Partners icon in the Navigation Pane
Then I should see the following heading Retail Partners
When I select the retailer: Lowe's
Then I should see the Retailer Detail page
Then I should see the retailer heading: Lowe's
#This is not showing. Raising the question whether it should be....
#Then I should see message: you may receive your assessment in approximately two (2) business days, if no delays in the assessment, and should no data issues arise. "
And Section: Your Supplier IDs should be showing text: This retailer does not support Supplier ID management
And I confirm that there is a section labeled: Data Consent Tiers
And Section: Data Consent Tiers should be showing text: This recipient does not require additional data consent tiers at this time.


Scenario: [56907] Retailer Detail Page - Retailer does require Supplier ID but does not require Data Consent Tiers
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load
Then I click the Retail Partners icon in the Navigation Pane
Then I should see the following heading Retail Partners
When I select the retailer: Sears
Then I should see the Retailer Detail page
Then I should see the retailer heading: Sears/K-Mart
Then I check that in the Supplier ID table the following columns are showing:
| Column name           |
| Supplier ID           |
| Company or Brand Name |
| Is Active             |
| Is Default            |
| Actions               |

Given I call Shared Step 56968 (Confirm - Data Consent Tiers not required )
And I confirm that there is a section labeled: Data Consent Tiers
And Section: Data Consent Tiers should be showing text: This recipient does not require additional data consent tiers at this time.
Given I call Shared Step 56967 (Confirm Retailer & You information is shown correctly) for retailer: Sears/K-Mart


Scenario: [56981] Retailer & You - layout
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load
Given I click the Retail Partners icon in the Navigation Pane
And I select the retailer: Walgreens
And I confirm that there is a section labeled: Walgreens & You
And The pie chart should be showing on the retailer details page
Given I see a percentage number in the middle of the pie chart
Given I confirm that the color of the pie chart for the Retailer selected is Green
And The pie chart footer text should contain: % of your product portfolio is associated with Walgreens


#BLOCKED because requires database access
Scenario: [56982] Retailer & You - validation of information shown
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load
Given I click the Retail Partners icon in the Navigation Pane
And I select the retailer: Walgreens
And I confirm that there is a section labeled: Walgreens & You


Given I confirm the percentage in the pie chart legend statement matches the percentage shown in the middle of the pie chart
# Not seeing these elements currently, so unable to code it
# Given I see the Thumbs up graphic
# Given I see the "It's been <X> good years" statement below the thumbs up graphic
Given I click the back arrow on the Retail Partners Details page
Then I should see the Retail Partners page

Scenario: [56911] Retailer Detail Page - Your Supplier ID - Add New Supplier ID - Cancel
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load
Then I click the Retail Partners icon in the Navigation Pane
Then I should see the following heading Retail Partners
When I select the retailer: Sears
Then I should see the Retailer Detail page
Given I click on the Add new Supplier ID link
Then I confirm the pop up shows the heading: Add New Supplier
Then I confirm the pop up shows the Supplier ID heading and data entry field
Then I confirm the pop up shows the Company or Brand Name heading and data entry field
Then I confirm the pop up shows the Is Default Heading and check box
Then I confirm the pop up shows a Save button
Then I confirm the pop up shows a Cancel button
Given in the modal dialog I click cancel
Given I confirm in the browser popup
Then I confirm the Add New Supplier ID pop up closes

# Assigned to Beverly Barrett
# Created by Beverly Barrett

@jstest
Scenario: [56927] What are the Data Usage Tiers? - Tier 1: Regulatory Compliance - wording check
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
And I click the Retail Partners icon in the Navigation Pane
And I select the retailer: CVS
And I click the "What are the Data Usage Tiers?" information button in the Retail Partners Details screen
And I click the "Tier 1: Regulatory Compliance" tab in Data Tier Details
And I confirm the text displayed in the Data Tier Details popup contains: "Definition. "Regulatory Support" is any evaluation of Supplier's data that is required to assist any WERCSmart Recipient in complying with any statute or regulation applicable in the United States or other countries (including international laws and regulations), governing the sale, handling, transportation, storage or disposal of products containing chemicals. These evaluations are included in the “WERCSmart Results” which are provided to WERCSmart Recipients to support their regulatory compliance programs. WERCSmart Results are derived using both Public Data and Confidential Data submitted by a Direct Supplier (and its Third-Party Suppliers). WERCSmart Results also include the provision of product safety data sheets, whether authored by the Direct Supplier or by UL authoring services.|Disclosure of Confidential Data. All data elements defined as Confidential Data above will be treated as such and will not be provided to a WERCSmart Recipient, unless a local, state or federal statute requires that a specific element be treated as non-confidential."
And I close the Data Tier Details popup
And I navigate to the home page
