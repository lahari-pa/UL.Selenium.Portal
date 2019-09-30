@RetailPartners
@Homepage
@wercsmart
@MyAccount
@run_DataConsentTiers
Feature: Data Consent Tiers

Background:
Given I create an email AllRetailersProductsCompany and save it as ProductAccountEmail
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
