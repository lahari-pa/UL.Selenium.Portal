@RetailPartners
@Homepage
@wercsmart
@run_DataConsentTiers

Feature: Data Consent Tiers

Background:
Given I create an email AllRetailersProductsCompany and save it as ProductAccount
Given I save the current emails in the inbox for address saved as: ProductAccount
Given I log in with the account saved in TReVor as: ProductAccount


@TReVorId:22221
Scenario: [56942] Data Consent Tiers - Walmart
# save company name to context

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
| Message                                                                                                                                                                                                                                                                                             |
| NOTE: Your selection does not meet this retailer's request. Walmart requires suppliers of private label formulated products in the following categories to grant Tier 2.1, Tier 2.2 and Tier 4.2 permissions: Artists/Hobby, Automotive Care, Battery-Containing Products, Cleaning Supplies, Grocery, Health & Beauty, Home Improvement, Kit, Lawn and Garden, Miscellaneous, Nutritional Supplements, OTC - Over the Counter, Pet Care, Pharmacy, Sporting Goods, Stationery and Toys. Wal-Mart/SAM'S CLUB will be notified of your Data Tier selections      |
Given I call Shared Step 57186 (Data Consent Tiers - Administrator Email Confirmation - Walmart) for email address saved as: ProductAccount
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
| Message                                                                                                                                                                                                                                                                                             |
| NOTE: Your selection does not meet this retailer's request. Walmart requires suppliers of private label formulated products in the following categories to grant Tier 2.1, Tier 2.2 and Tier 4.2 permissions: Artists/Hobby, Automotive Care, Battery-Containing Products, Cleaning Supplies, Grocery, Health & Beauty, Home Improvement, Kit, Lawn and Garden, Miscellaneous, Nutritional Supplements, OTC - Over the Counter, Pet Care, Pharmacy, Sporting Goods, Stationery and Toys. Wal-Mart/SAM'S CLUB will be notified of your Data Tier selections      |
Given I call Shared Step 57186 (Data Consent Tiers - Administrator Email Confirmation - Walmart) for email address saved as: ProductAccount
| Data Tier | Permission |
| Tier 1    | Active     |
| Tier 2.1  | Disabled   |
| Tier 2.2  | Active     |
| Tier 4.2  | Disabled   |

Given I toggle the data consent tier: Tier 4.2 to: on
Then I click the Save Changes button
Given I click close on the Save Changes popup dialog
#Then there should be a new email for email Address saved as: ProductAccount from: <SiteNotification> with the title: WERCSmart Data Use Tier Consents Changed for Wal-Mart/SAM'S CLUB
#And the body of the email should show: Hello WERCS Automated Products, Recently an administrator has changed the Data Usage permissions for Wal-Mart/SAM'S CLUB to include: Tier 1: Regulatory Support: ActiveTier 2.1: Restricted Substances List (RCL) Screening and Aggregate Chemical Usage Reports: DisabledTier 2.2: Chemical Identity of Publicly Disclosed Ingredient Lists and Transparency: ActiveTier 4.2: Publicly Disclose Product Ingredient Lists: Active For questions please contact the WERCSmart Customer Support. Thank you, Your WERCSmart Team Important Notice: This e-mail may contain privileged or confidential information. If you are not the intended recipient (1) you may not disclose, use, distribute, copy or rely upon this message or attachment(s); and (2) please notify UL PSi at WERCSmartCustomer@ul.com and then delete this message and its attachment(s). UL PSi and its affiliates disclaim all liability for any errors, omissions, corruption or virus in this message or any attachment(s).
Given I call Shared Step 57186 (Data Consent Tiers - Administrator Email Confirmation - Walmart) for email address saved as: ProductAccount
| Data Tier | Permission |
| Tier 1    | Active     |
| Tier 2.1  | Disabled   |
| Tier 2.2  | Active     |
| Tier 4.2  | Active     |

Given I toggle the data consent tier: Tier 2.1 to: on
Then I click the Save Changes button
Given I click close on the Save Changes popup dialog
And I confirm the NOTE message below the Data Consent Tiers Heading is NOT shown
#Then there should be a new email for email Address saved as: ProductAccount from: <SiteNotification> with the title: WERCSmart Data Use Tier Consents Changed for Wal-Mart/SAM'S CLUB
#And the body of the email should show: Hello WERCS Automated Products, Recently an administrator has changed the Data Usage permissions for Wal-Mart/SAM'S CLUB to include: Tier 1: Regulatory Support: ActiveTier 2.1: Restricted Substances List (RCL) Screening and Aggregate Chemical Usage Reports: ActiveTier 2.2: Chemical Identity of Publicly Disclosed Ingredient Lists and Transparency: ActiveTier 4.2: Publicly Disclose Product Ingredient Lists: Active For questions please contact the WERCSmart Customer Support. Thank you, Your WERCSmart Team Important Notice: This e-mail may contain privileged or confidential information. If you are not the intended recipient (1) you may not disclose, use, distribute, copy or rely upon this message or attachment(s); and (2) please notify UL PSi at WERCSmartCustomer@ul.com and then delete this message and its attachment(s). UL PSi and its affiliates disclaim all liability for any errors, omissions, corruption or virus in this message or any attachment(s).
Given I call Shared Step 57186 (Data Consent Tiers - Administrator Email Confirmation - Walmart) for email address saved as: ProductAccount
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
