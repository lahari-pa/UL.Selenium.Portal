@Shared
@LandingPage
@Login
@Homepage
@Signup
@RetailPartners
@wercsmart
@DocumentAcceptance
@SideMenu
@run_RetailerPartners
Feature: Retailer Partners

@TestCase:56903
Scenario: [56903] Retailer Detail Page - Retailer does not require Supplier ID or Data Consent Tiers
	Given I log in with the account saved in TReVor as: ProductAccount
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Then In the Side Menu, click Labeled Link with Retailers title
	Then I should see the following heading Retail Partners
	Then In the Retail Partners page, click the Lowe's retailer link
	Then I should see the Retailer Detail page
	Then I should see the retailer heading: Lowe's
	And Section: Your Supplier IDs should be showing text: This retailer does not support Supplier ID management
	And In the Retail Partners page, I confirm that there is a section labeled: Data Consent Tiers
	And In the Retail Partners page, Retail partner details should be showing text: Lowe's requires suppliers of products to grant Tier 1 at this time.

@TestCase:56907
Scenario: [56907] Retailer Detail Page - Retailer does require Supplier ID but does not require Data Consent Tiers
	Given I log in with the account saved in TReVor as: ProductAccount
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Then In the Side Menu, click Labeled Link with Retailers title
	Then I should see the following heading Retail Partners
	Then In the Retail Partners page, click the Sears retailer link
	Then I should see the Retailer Detail page
	Then I should see the retailer heading: Sears/K-Mart
	Then In the Retail Partners Details page, Verify Supplier ID table display following columns:
		| Column name           |
		| Supplier ID           |
		| Company or Brand Name |
		| Is Active             |
		| Is Default            |
		| Actions               |
	And Retail partner details should be showing text: Sears/K-Mart requires suppliers of products to grant Tier 1 at this time.
	And I confirm that there is a section labeled: Data Consent Tiers

#Removed from regression: 2024/09
@ignore
@TestCase:56981
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

@ignore
@TestCase:56911
Scenario: [56911] Retailer Detail Page - Your Supplier ID - Add New Supplier ID - Cancel
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Then I click the Retail Partners icon in the Navigation Pane
	Then I should see the following heading Retail Partners
	When I select the retailer: Sears
	Then I should see the Retailer Detail page
	Given I click on the Add new Supplier ID link
	Then I Wait for a modal popup to appear
	Then I confirm the pop up shows the heading: Add New Supplier
	Then I confirm the pop up shows the Supplier ID heading and data entry field
	Then I confirm the pop up shows the Company or Brand Name heading and data entry field
	Then I confirm the pop up shows the Is Default Heading and check box
	Then I confirm the pop up shows a Save button
	Then I confirm the pop up shows a Cancel button
	Given in the modal dialog I click cancel
	Given I confirm in the browser popup
	Then I confirm the Add New Supplier ID pop up closes

# NB logged ticket for spelling error, waiting for correction
#Removed from regression: 2024/09
@ignore
@TestCase:56933
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
	And In the Side Menu, click Labeled Link with My Products title

# Assigned to Barrett, Beverly
# Created by Barrett, Beverly
# Test case can be found at the following paths:
# NetProjects10\WERCSmart UX Reboot\WERCSmart\Retail Partners\Supplier ID\Supplier ID validation - retailer specific
# NetProjects10\WercsSmart Portal\WERCSmart\Retail Partners\Supplier ID
# ******* Blocked because cannot run database queries on staging, also the query appears to be wrong or the database string is.
@ignore
@TestCase:57261
Scenario: [57261] Retailer Detail Page (O'Reilly) - Your Supplier ID - Add New Supplier ID - Save  - DB validation is only for local
	#Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I log in with the account saved in TReVor as: ProductAccount
	Given I call Shared Step 57264 (Go To Retail Partners - Select O'Reilly)
	And I confirm the Retailer Details Page has loaded
	And I confirm that there is a section labeled: Your Supplier IDs
	And The Supplier ID Table should be showing
	Given I call Shared Step 58828 - Delete Supplier with ID: 654327
	Given I click on the Add new Supplier ID link
	Then I Wait for a modal popup to appear
	And in the Add New Supplier Dialog I click save
	And in the Add New Supplier Dialog I Confirm an error shows below the Supplier ID question: This is a required field.
	And in the Add New Supplier Dialog I Confirm an error shows below Company or Brand Name question: This is a required field.
	And in the Add New Supplier Dialog I enter the following in the Supplier ID input: abc
	And in the Add New Supplier Dialog I click save
	And in the Add New Supplier Dialog I Confirm an error shows below the Supplier ID question: You must enter valid O'Reilly Vendor id.
	And in the Add New Supplier Dialog I Confirm an error shows below Company or Brand Name question: This is a required field.
	And in the Add New Supplier Dialog I select the first option in the Company or Brand Name input and save to context as: companybrand57261
	And in the Add New Supplier Dialog I click save
	And in the Add New Supplier Dialog I Confirm that no error shows below Company or Brand Name question
	And in the Add New Supplier Dialog I Confirm an error shows below the Supplier ID question: You must enter valid O'Reilly Vendor id.
	And in the Add New Supplier Dialog I enter the following in the Supplier ID input: 12
	And in the Add New Supplier Dialog I click save
	And in the Add New Supplier Dialog I Confirm an error shows below the Supplier ID question: You must enter valid O'Reilly Vendor id.
	And in the Add New Supplier Dialog I enter the following in the Supplier ID input: 654327
	And in the Add New Supplier Dialog I click save
	Then I confirm that in the Supplier IDS list the following row exists
		| Supplier ID | Company or Brand Name       |
		| 654327      | saved as: companybrand57261 |
	And I call Shared Step 58828 - Delete Supplier with ID: 654327

#And I call Shared Step 57247 - Database check - find t_vendor records for specific Retailer: Reilly and Supplier: Products Automation Account
# And I Confirm the Supplier ID you added is shown in the result for the query on the t_vendor table
#
# ***** Space between test cases ***** #
#
# Assigned to Barrett, Beverly
# Created by Barrett, Beverly
# Test case can be found at the following paths:
# NetProjects10\WERCSmart UX Reboot\WERCSmart\Retail Partners\Supplier ID
# NetProjects10\WercsSmart Portal\WERCSmart\Retail Partners\Supplier ID
#DB queries are not automated because they will not work in staging
@TestCase:56920
Scenario: [56920] Your Supplier IDs - Actions - Deactivate
	Given I log in with the account saved in TReVor as: ProductAccount
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Then In the Side Menu, click Labeled Link with Retailers title
	Then I should see the following heading Retail Partners
	Then In the Retail Partners page, click the O'Reilly retailer link
	Then I should see the Retailer Detail page

	#And I In the Supplier ID table find the Supplier ID 56920x where x = 1 for O'Reilly, 2 for Sears, 3 for Wal-Mart
	Then For Retailer: O'Reilly If the supplier ID: 56920x is not found In the Supplier Table I add it with the first option in the Company or Brand Name field.

	Then For retailer: O'Reilly I confirm the the supplier ID: 56920x is found in the supplier ID Table and save it as: supplierID56920
	And I Confirm the Is Active column for SupplierID saved as supplierID56920 shows a green check mark
	#And I call Shared Step 57621 - Supplier ID table > Select Deactivate - Confirm Supplier ID Is set to Inactive for supplierID saved as supplierID56920
	And In the  Retail Partners Details page,Click action and Deactivate for Supplier Id saved as: supplierID56920
	And In the  Retail Partners Details page, I Confirm the Is Active column for SupplierID saved as supplierID56920 does not show a green check mark
	#And I call Shared Step 57565 - Supplier ID table > Select Activate - Confirm Supplier ID Is set to Active for supplierID saved as supplierID56920
	And In the  Retail Partners Details page,Click action and Activate for Supplier Id saved as: supplierID56920
	And In the  Retail Partners Details page, I Confirm the Is Active column for SupplierID saved as supplierID56920 shows a green check mark



@TestCase:56909
Scenario: [56909] Retailer Detail Page - Retailer does not require Supplier ID but does require Data Consent Tiers
	Given I log in with the account saved in TReVor as: ProductAccount
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Then In the Side Menu, click Labeled Link with Retailers title
	Then I should see the following heading Retail Partners
	Then In the Retail Partners page, click the CVS retailer link
	Then I should see the Retailer Detail page
	Then I should see the retailer heading: CVS
	And I confirm that there is a section labeled: Your Supplier IDs
	And Section: Your Supplier IDs should be showing text: This retailer does not support Supplier ID management
	And I confirm that there is a section labeled: Data Consent Tiers
	And In the Retail Partners Details page, 'Products in Scope' link should be displayed
	And In the Retail Partners Details page, 'What are the Data Usage Tiers' link should be displayed



@TestCase:56914
Scenario: [56914] Retailer Detail Page - Retailer requires Supplier ID and Data Consent Tiers
	Given I log in with the account saved in TReVor as: ProductAccount
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Then In the Side Menu, click Labeled Link with Retailers title
	Then I should see the following heading Retail Partners
	Then In the Retail Partners page, click the Wal-Mart/SAM'S CLUB retailer link
	Then I should see the Retailer Detail page
	Then I should see the retailer heading: Wal-Mart/SAM'S CLUB
	And I confirm that there is a section labeled: Your Supplier IDs
	And The Supplier ID Table should be showing
	And I confirm that there is a section labeled: Data Consent Tiers
	And In the Retail Partners Details page, 'Products in Scope' link should be displayed
	And In the Retail Partners Details page, 'What are the Data Usage Tiers' link should be displayed
