@LandingPage
@Login
@Homepage
@Signup
@RetailPartners
@wercsmart
@run_RetailerPartners

Feature: Retailer Partners


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


Scenario: [56914] Retailer Detail Page - Retailer requires Supplier ID and Data Consent Tiers
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load

# Retail Partners Page
And I click the Retail Partners icon in the Navigation Pane
Then I should see the following heading Retail Partners
And I select the retailer: Wal-mart

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

