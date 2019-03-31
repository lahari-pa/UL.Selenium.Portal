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

Scenario: [56927] What are the Data Usage Tiers? - Tier 1: Regulatory Compliance - wording check
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
And I click the Retail Partners icon in the Navigation Pane
And I select the retailer: CVS
And I click the "What are the Data Usage Tiers?" information button in the Retail Partners Details screen
And I click the "Tier 1: Regulatory Compliance" tab in Data Tier Details
And I confirm the text displayed in the Data Tier Details popup matches for each section:
| Section | Text                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          |
| A       | Definition. "Regulatory Support" is any evaluation of Supplier's data that is required to assist any WERCSmart Recipient in complying with any statute or regulation applicable in the United States or other countries (including international laws and regulations), governing the sale, handling, transportation, storage or disposal of products containing chemicals. These evaluations are included in the “WERCSmart Results” which are provided to WERCSmart Recipients to support their regulatory compliance programs. WERCSmart Results are derived using both Public Data and Confidential Data submitted by a Direct Supplier (and its Third-Party Suppliers). WERCSmart Results also include the provision of product safety data sheets, whether authored by the Direct Supplier or by UL authoring services. |
| B       | Disclosure of Confidential Data. All data elements defined as Confidential Data above will be treated as such and will not be provided to a WERCSmart Recipient, unless a local, state or federal statute requires that a specific element be treated as non-confidential.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    |
And I close the Data Tier Details popup
And I navigate to the home page

Scenario: [56929] What are the Data Usage Tiers? - Tier 2: Chemical Program Support - wording check
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
And I click the Retail Partners icon in the Navigation Pane
And I select the retailer: CVS
And I click the "What are the Data Usage Tiers?" information button in the Retail Partners Details screen
And I click the "Tier 2: Chemical Program Support" tab in Data Tier Details
And I confirm the Data Tier Details subheading reads: What does Chemical Program Support mean?
And I confirm the text displayed in the Data Tier Details popup matches for each section:
| Section | Text                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              |
| A       | Definition. "Chemical Program Support" includes providing the following types of information to Designated Recipient(s) only:                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     |
| A1      | Product Ingredient Lists. The Standard Chemical Names and Standard Chemical Numbers for each ingredient on a product’s Publicly Disclosed Ingredient List for each of a Supplier's products that a Designated Recipient sells. These data do not include any of the following Confidential Data elements:                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         |
| A1a     | The chemical identity of any ingredient marked as not publicly disclosed or as a trade secret on the WERCSmart Product Formulation page;                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          |
| A1b     | The chemical identity of the ingredients of any Third-Party Component in a product (unless those ingredients are marked as publicly disclosed on the WERCSmart Component Formulation page by the Third-Party Supplier of the component); and                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      |
| A1c     | The percent by weight of any ingredient in a product.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             |
| A1      | This information is used by a Designated Recipient to search its product portfolio for chemicals of interest. The Public Name of an ingredient is insufficient for this purpose, because a Public Name may be ambiguous and fail to resolve to a specific Unique Chemical. Standard Chemical Names and/or Standard Chemical Numbers are required because these chemical identifiers are used to define which ingredients are included in the various regulatory, scientific or trade association lists that Designated Recipients use to identify chemicals of interest. The Designated Recipient is not authorized to publicly disclose this additional chemical identity data.                                                                                                                                                                                                                                                                                                                                                                                                                                  |
| A2      | Transparency Ratios for each of a Supplier's products that a Designated Recipient sells. The "Transparency Ratio" is the number of ingredients on a product's Publicly Disclosed Ingredient List divided by the number of ingredients on a product’s Full Formulation Ingredient List. The ratios are used by a Designated Recipient to evaluate the visibility it has into the chemical composition of its product portfolio. The Designated Recipient is not authorized to publicly disclose product Transparency Ratios.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       |
| A3      | Chemical Screen Results. Product Chemical Screen results, where a product’s Full Formulation Ingredient List is screened against a Designated Recipient's restricted substance list (a “Chemical Screen”). The Designated Recipient is provided with an indication of whether the product passes or fails the screen. The Standard Chemical Name or Standard Chemical Number of the specific ingredient(s) failing the Chemical Screen shall only be provided if that ingredient is listed on a product’s Publicly Disclosed Ingredient List. Confidential Data may be used to derive Chemical Screen results (e.g., screen against a Full Formulation Ingredient List, or use percent formulation to demonstrate compliance with a restriction limit), provided there is no disclosure of any Confidential Data to the Designated Recipient. The Designated Recipient is not authorized to publicly disclose product-level results from its Chemical Screens.                                                                                                                                                    |
| A4      | Aggregate Chemical Usage Reports. "Aggregate Chemical Usage Reports" are reports which summarize the prevalence or volume of chemicals in a Designated Recipient's product portfolio. These reports track and characterize usage of chemicals to inform chemical policy development at the Designated Recipient. Confidential Data may be used to derive Aggregate Chemical Usage Reports (e.g., calculate prevalence of all chemicals on the Full Formulation Ingredient Lists of products in an assortment, or use percent formulation to calculate mass-weighted chemical usage), provided there is no disclosure of any Confidential Data to the Designated Recipient. The Designated Recipient is authorized to publicly disclose summary information from Aggregate Chemical Usage Reports, provided that such disclosure does not identify specific products or suppliers. If the Designated Recipient is reporting on the volume of chemicals in its assortment, for example, such results must be presented at the product category level, without identifying amounts per specific supplier or product. |
| B       | Third Party Suppliers. All Third-Party Suppliers of components in a product shall separately provide Tier 2 Data Use Consent to the use of their Confidential Data for providing Chemical Program Support.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        |
And I close the Data Tier Details popup
And I navigate to the home page

Scenario: [56931] What are the Data Usage Tiers? - Tier 3: Supplemental Reports - wording check
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
And I click the Retail Partners icon in the Navigation Pane
And I select the retailer: CVS
And I click the "What are the Data Usage Tiers?" information button in the Retail Partners Details screen
And I click the "Tier 3: Supplemental Reports" tab in Data Tier Details
And I confirm the Data Tier Details subheading reads: What does Supplemental Reports for Internal Business Use Only mean?
And I confirm the text displayed in the Data Tier Details popup matches for each section:
| Section | Text                                                                                                                                                                                                                                                                                                                                                                     |
| A       | Definition. "Supplemental Reports" include providing data needed for sustainability evaluations, product qualification and rating programs, assortment curation programs, and supplier qualification programs operated by a Designated Recipient.                                                                                                                        |
| A1      | Supplemental Reports will be derived using data submitted by a supplier as part of a supplier’s record, or as part of a product’s regulatory or supplemental record. Supplemental supplier and product records are populated from survey data, which may be collected from supplier via UL Supply Chain Network, WERCSmart, PurView, or as otherwise provided.           |
| A2      | Confidential Data may be used to derive Supplemental Reports (e.g., as inputs for rules used to rate or qualify products), provided there is no disclosure of Confidential Data to the Designated Recipient. In limited cases, UL may designate specific data elements collected by a survey as confidential, and not disclose these elements to a Designated Recipient. |
| B       | Third-Party Suppliers. In the event that the Confidential Data required to derive a Supplemental Report is controlled by a Third-Party Supplier, that party shall separately provide Tier 3 consent to the use of its Confidential Data for deriving Supplemental Reports.                                                                                               |
And I close the Data Tier Details popup
And I navigate to the home page

# NB logged ticket for spelling error, waiting for correction
Scenario: [56933] What are the Data Usage Tiers? - Tier 4: Public Disclosure Options - wording check
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
And I click the Retail Partners icon in the Navigation Pane
And I select the retailer: CVS
And I click the "What are the Data Usage Tiers?" information button in the Retail Partners Details screen
And I click the "Tier 4: Public Disclosure Options" tab in Data Tier Details
And I confirm the Data Tier Details subheading reads: What are my Public Disclosure Options?
And I confirm the text displayed in the Data Tier Details popup matches for each section:
| Section | Text                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         |
| A       | Definition of Public Disclosure Options: Suppliers may opt to authorize a Designated Recipient to publicly disclose one or more of the following types of data for its external business purposes, which may include consumer-facing marketing and product or supplier information programs:                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 |
| A1      | Derived Results from Supplemental Reports (Tier 4.1). Derived Results include any qualification decisions or ratings the Designated Recipient derives based on the data in a regulatory or supplemental product record or in a supplier record. Qualification decisions are determinations that a supplier or product satisfies a set of criteria (e.g., a supplier exhibits a set of sustainability attributes, or a product does not contain certain types of chemicals). Ratings are scores assigned to a product or supplier based on an evaluative framework defined by a Designated Recipient. A Designated Recipient may publicly disclose information from Supplemental Reports only in a form that does not reveal the Confidential Data of any supplier. For example, a Designated Recipient may publish the results of a product qualification decision (e.g., the product meets a set of criteria), but it is prohibited from disclosing that a product exhibits a specific attribute that is Confidential Data. |
| A2      | Product Ingredient Lists (Tier 4.2). A Designated Recipient may utilize the Public Names on a product’s Publicly Disclosed Ingredient List to publish such list on its website.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              |
| A3      | Other Supplier-Provided Data (Tier 4.3). A Designated Recipient may publicly disclose any supplier-provided, non-confidential data elements from a product or supplier record. No Confidential Data elements may be publicly disclosed.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      |
And I close the Data Tier Details popup
And I navigate to the home page

Scenario: [56925] My Data & Recipients - General layout checks
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
And I click the Retail Partners icon in the Navigation Pane
And I select the retailer: CVS
And I confirm the Retailer Details Page has loaded
And I confirm that there is a section labeled: Data Consent Tiers
And I confirm the Data Consent Tiers table is displayed
And I should see the More Information hyperlink
And I confirm the "What are the Data Usage Tiers?" information button is displayed on the Retail Partners Details screen
And I confirm the "Products in Scope" information button is displayed on the Retail Partners Details screen
And I confirm that row: 1 of the Data Consent Tiers table displays: "Tier 1: Regulatory Support"
And the Data Consent Tier: Tier 1 should be set to: on
And I should not be able to edit Tier Tier 1
And I navigate to the home page

Scenario: [56926] My Data & Recipients - What are the Data Usage Tiers - tab/headings
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
And I click the Retail Partners icon in the Navigation Pane
And I select the retailer: CVS
And I click the "What are the Data Usage Tiers?" information button in the Retail Partners Details screen
And The Data Tier Details popup shows the following tabs:
| Tab                               |
| Tier 1: Regulatory Compliance     |
| Tier 2: Chemical Program Support  |
| Tier Tier 3: Supplemental Reports |
| Tier 4: Publicly Disclose Options |
And I close the Data Tier Details popup
And I navigate to the home page

# Assigned to Barrett, Beverly
# Created by Barrett, Beverly
# Test case can be found at the following paths:
# NetProjects10\WERCSmart UX Reboot\WERCSmart\Retail Partners\Supplier ID\Supplier ID validation - retailer specific
# NetProjects10\WercsSmart Portal\WERCSmart\Retail Partners\Supplier ID

# ******* Blocked because cannot run database queries on staging, also the query appears to be wrong or the database string is.
@TFS_design
Scenario: [57261] Retailer Detail Page (O'Reilly) - Your Supplier ID - Add New Supplier ID - Save  - DB validation is only for local
Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
And I click the Retail Partners icon in the Navigation Pane
And I select the retailer: O'Reilly
And I confirm the Retailer Details Page has loaded
And I confirm that there is a section labeled: Your Supplier IDs
And The Supplier ID Table should be showing
Given I click on the Add new Supplier ID link
And in the Add New Supplier Dialog I click save
And in the Add New Supplier Dialog I Confirm an error shows below the Supplier ID question: This is a required field
And in the Add New Supplier Dialog I Confirm an error shows below Company or Brand Name question: This is a required field
And in the Add New Supplier Dialog I enter the following in the Supplier ID input: abc
And in the Add New Supplier Dialog I click save
And in the Add New Supplier Dialog I Confirm an error shows below the Supplier ID question: You must enter valid O'Reilly Vendor id
And in the Add New Supplier Dialog I Confirm an error shows below Company or Brand Name question: This is a required field
And in the Add New Supplier Dialog I enter the following in the Company or Brand Name input: Automated
And in the Add New Supplier Dialog I click save
And in the Add New Supplier Dialog I Confirm that no error shows below Company or Brand Name question
And in the Add New Supplier Dialog I Confirm an error shows below the Supplier ID question: You must enter valid O'Reilly Vendor id
And in the Add New Supplier Dialog I enter the following in the Supplier ID input: 12
And in the Add New Supplier Dialog I click save
And in the Add New Supplier Dialog I Confirm an error shows below the Supplier ID question: You must enter valid O'Reilly Vendor id
And in the Add New Supplier Dialog I enter the following in the Supplier ID input: 654327
And in the Add New Supplier Dialog I click save
Then I confirm that in the Supplier IDS list the following row exists
| Supplier ID | Company or Brand Name |
| 654327      | Automated             |
And I call Shared Step 57247 - Database check - find t_vendor records for specific Retailer: Reilly and Supplier: Products Automation Account
And I Confirm the Supplier ID you added is shown in the result for the query on the t_vendor table
And [Shared Step 58828 - Delete Supplier ID]

# Assigned to Barrett, Beverly
# Created by Barrett, Beverly

# Test case can be found at the following paths:
# NetProjects10\WERCSmart UX Reboot\WERCSmart\Retail Partners\Supplier ID
# NetProjects10\WercsSmart Portal\WERCSmart\Retail Partners\Supplier ID


#DB queries are not automated because they will not work in staging
Scenario: [56920] Your Supplier IDs - Actions - Deactivate
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
And I click the Retail Partners icon in the Navigation Pane
And I select the retailer: O'Reilly
And I confirm the Retailer Details Page has loaded
#And I In the Supplier ID table find the Supplier ID 56920x where x = 1 for O'Reilly, 2 for Sears, 3 for Wal-Mart
And I find the Supplier ID for O'Reilly in the SupplierID table and save as supplierID56920
And I Confirm the Is Active column for SupplierID saved as supplierID56920 shows a green check mark
And I call Shared Step 57621 - Supplier ID table > Select Deactivate - Confirm Supplier ID Is set to Inactive for supplierID saved as supplierID56920
#And [Shared Step 57319 - Database Check - Find t_vendor Is_active records for Specific Supplier and Retailer]
#And I Confirm the results of the query shows the Is_active column is set to 0
#And I Confirm the results of the query shows the f_user_updated column is set (not 0's)
#And I We will now re-set the Is Active column to Active so that we can re-use the supplier ID
And I call Shared Step 57565 - Supplier ID table > Select Activate - Confirm Supplier ID Is set to Active for supplierID saved as supplierID56920
#And [Shared Step 57319 - Database Check - Find t_vendor Is_active records for Specific Supplier and Retailer]
#'And I Confirm the results of the query show the Is Active column is set to 1
#And I Confirm the results of the query shows the F_User_updated column is set (does not show 0's)


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
