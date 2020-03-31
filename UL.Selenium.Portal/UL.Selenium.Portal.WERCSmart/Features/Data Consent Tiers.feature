@Shared
@RetailPartners
@Homepage
@wercsmart
@MyAccount
@run_DataConsentTiers
@SHA



Feature: Data Consent Tiers

Background:
#Given I create an email AllRetailersProductsCompany and save it as ProductAccountEmail
Given I Save the email for the TReVor: ProductAccount Test user as: ProductAccountEmail
Given I save the current emails in the inbox for address saved as: ProductAccountEmail
	Given I log in with the account saved in TReVor as: ProductAccount


@ScenarioId:475
Scenario: [56942] Data Consent Tiers - Walmart
Given I click on My Account
Then I save the administrator Company Name as: ProductAccountCompany
Then I click the Retail Partners icon in the Navigation Pane
	Given I select the retailer: Wal-Mart
	Then I confirm that there is a section labeled: Data Consent Tiers
	Given I ensure the Data Consent Tier Sliders are set as follows:
		| Tier | State |
		| 2.1  | Off   |
		| 2.2  | Off   |
		| 4.2  | Off   |
Given I call Shared Step 54139 (Data Usage Tiers - Tier 1 - confirm cannot edit)
Given I call Shared Step 54139 (Data Usage Tiers - Tier 2.1 - confirm you can edit)
Given I call Shared Step 54140 (Data Usage Tiers - Tier 2.2 - confirm you can edit)
Given I call Shared Step 57069 (Data Usage Tiers - Tier 4.2 - confirm you can edit)
	Given I toggle the data consent tier: Tier 2.1 to: on
	Then I click the Save Changes button
	Given I click close on the Save Changes popup dialog
	Then the warning message in the Retail Partners details page should contain the following:
		| Message                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    |
		| NOTE: Your selection does not meet this retailer's request. Walmart requires suppliers of private label formulated products in the following categories to grant Tier 2.1, Tier 2.2 and Tier 4.2 permissions: Artists/Hobby, Automotive Care, Battery-Containing Products, Cleaning Supplies, Grocery, Health & Beauty, Home Improvement, Kit, Lawn and Garden, Miscellaneous, Nutritional Supplements, OTC - Over the Counter, Pet Care, Pharmacy, Sporting Goods, Stationery and Toys. Wal-Mart/SAM'S CLUB will be notified of your Data Tier selections |
Given I call Shared Step 57186 (Data Consent Tiers - Administrator Email Confirmation - Walmart) for email address saved as: ProductAccountEmail and company name saved as: ProductAccountCompany
| Data Tier | Permission |
| Tier 1    | Active     |
| Tier 2.1  | Active     |
| Tier 2.2  | Disabled   |
| Tier 4.2  | Disabled   |
Given I toggle the data consent tier: Tier 2.1 to: off
Given I toggle the data consent tier: Tier 2.2 to: on
	Then I click the Save Changes button
	Given I click close on the Save Changes popup dialog
	Then the warning message in the Retail Partners details page should contain the following:
		| Message                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    |
		| NOTE: Your selection does not meet this retailer's request. Walmart requires suppliers of private label formulated products in the following categories to grant Tier 2.1, Tier 2.2 and Tier 4.2 permissions: Artists/Hobby, Automotive Care, Battery-Containing Products, Cleaning Supplies, Grocery, Health & Beauty, Home Improvement, Kit, Lawn and Garden, Miscellaneous, Nutritional Supplements, OTC - Over the Counter, Pet Care, Pharmacy, Sporting Goods, Stationery and Toys. Wal-Mart/SAM'S CLUB will be notified of your Data Tier selections |
Given I call Shared Step 57186 (Data Consent Tiers - Administrator Email Confirmation - Walmart) for email address saved as: ProductAccountEmail and company name saved as: ProductAccountCompany
| Data Tier | Permission |
| Tier 1    | Active     |
| Tier 2.1  | Disabled   |
| Tier 2.2  | Active     |
| Tier 4.2  | Disabled   |
Given I toggle the data consent tier: Tier 4.2 to: on
	Then I click the Save Changes button
	Given I click close on the Save Changes popup dialog
Given I call Shared Step 57186 (Data Consent Tiers - Administrator Email Confirmation - Walmart) for email address saved as: ProductAccountEmail and company name saved as: ProductAccountCompany
| Data Tier | Permission |
| Tier 1    | Active     |
| Tier 2.1  | Disabled   |
| Tier 2.2  | Active     |
| Tier 4.2  | Active     |
Given I toggle the data consent tier: Tier 2.1 to: on
	Then I click the Save Changes button
	Given I click close on the Save Changes popup dialog
	And I confirm the NOTE message below the Data Consent Tiers Heading is NOT shown
Given I call Shared Step 57186 (Data Consent Tiers - Administrator Email Confirmation - Walmart) for email address saved as: ProductAccountEmail and company name saved as: ProductAccountCompany
| Data Tier | Permission |
| Tier 1    | Active     |
| Tier 2.1  | Active     |
| Tier 2.2  | Active     |
| Tier 4.2  | Active     |
	Given I ensure the Data Consent Tier Sliders are set as follows:
		| Tier | State |
		| 2.1  | Off   |
		| 2.2  | Off   |
		| 4.2  | Off   |

Scenario: [127895] SHA Manager: Supplier Records: Verification of Data Tier Consent

Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
Then I Click 'Suppliers'
Then Search for 'The WERCS LTD' Vendor
Then Select the '(.*)'
Then Select the '(.*)' Tab
Then Confirm that 'Dollar General' shows Tier 1,Tier 2.1,Tier 2.2 marked with a 'Y'
Then Confirm that 'Costco' shows Tier 1,Tier 2.1,Tier 2.2 marked with a 'Y'
Then Confirm that 'Canadian Tire' shows Tier 1,Tier 2.1,Tier 2.2 marked with a 'Y'
Then Confirm that 'CVS' shows Tier 1,Tier 2.1,Tier 2.2,Tier 3 marked with a 'Y'
Then Confirm that 'Rite Aid' shows Tier 1,Tier 2.1,Tier 2.2,Tier 3 marked with a 'Y'
Then Confirm that 'Target' shows Tier 1,Tier 2.1,Tier 2.2,Tier 3,Tier 4.1 marked with a 'Y'
Then Confirm that 'Walgreens' shows Tier 1,Tier 2.1,Tier 2.2 marked with a 'Y'
Then Confirm that 'Family Dollar' shows Tier 1 marked with a 'Y'
Then Confirm that 'Wal-Mart' shows Tier 1,Tier 2.1,Tier 2.2 marked with a 'Y'
Then Confirm that 'Amazon' shows Tier 1 marked with a 'Y'
Then Confirm that 'Dollar Tree Stores, Inc. / Greenbrier International, Inc' shows Tier 1,Tier 2.1,Tier 2.2 marked with a 'Y'
Then Confirm that 'Bed Bath and Beyond (including Harmon, Buy Buy Baby, and Christmas Tree Shops)' shows Tier 1,Tier 2.1,Tier 2.2,Tier 4.1 marked with a 'Y'
Then I Close 'Supplier Manager'



Scenario: [127901] SHA - Actions - Advanced Reporting - Daily Report - Data Tier Consent

Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
Given I select the: Daily Report - Data Tier Consent report from Advanced Reporting in SHA
Given In the Advanced Reporting popup I click Submit
Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
Then I select the: Daily Report - Data Tier Consent report from Advanced Reporting in SHA
Then In the Advanced Reporting popup I click Submit
And I wait for the Advanced Reporting Preparing Report popup to disappear
Given I confirm that an excel file is produced called Daily Report - Data Tier Consent.xls and save as 127901
And I confirm the excel file saved as 127901 can be opened and contains data
Then I confirm that the excel file saved as: 127901 contains the following columns:
		| Column |
		| Client |	
Then I confirm that the excel file saved as: 127901 contains the following retailers:
| Retailer            |
| Dollar General      |
| Costco              |
| Canadian Tire       |
| CVS                 |
| Rite Aid            |
| Bed Bath and Beyond (including Harmon, Buy Buy Baby, and Christmas Tree Shops) |
| Target              |
| Walgreens           |
| Family Dollar       |
| Walmart             |
| Amazon              |
| Dollar Tree         |
Given I delete the Advanced Report file saved as 127901
Given I Click close in the Advanced Reporting Popup
