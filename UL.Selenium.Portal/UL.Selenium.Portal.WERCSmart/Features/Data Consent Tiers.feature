@RetailPartners
@Homepage
@wercsmart
@run_DataConsentTiers

Feature: Data Consent Tiers

Background:
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then I click the Retail Partners icon in the Navigation Pane

@tfs_design
Scenario: [56942] Data Consent Tiers - Walmart
Given I select the retailer: Wal-Mart
Then I confirm that there is a section labeled: Data Consent Tiers
Given I ensure the Data Consent Tier Sliders are set as follows:
| Tier | State |
| 2.1  | Off   |
| 2.2  | Off   |
| 4.2  | Off   |
Then I should not be able to edit Tier 1
And I should be able to edit Tier 2.1
And I should be able to edit Tier 2.2
And I should be able to edit Tier 4.2
And the save changes button is shown

Given I ensure the Data Consent Tier Sliders are set as follows:
| Tier | State |
| 2.1  | On    |

Then I click the Save Changes button
And I click close on the Save Changes popup dialog
And the following warning message should be showing: NOTE: Your selection does not meet this retailer's request. Walmart requires suppliers of private label formulated products in the following categories to grant Tier 2.1, Tier 2.2 and Tier 4.2 permissions: Artists/Hobby, Automotive Care, Battery-Containing Products, Cleaning Supplies, Grocery, Health & Beauty, Home Improvement, Kit, Lawn and Garden, Miscellaneous, Nutritional Supplements, OTC - Over the Counter, Pet Care, Pharmacy, Sporting Goods, Stationery and Toys. Wal-Mart/SAM'S CLUB will be notified of your Data Tier selections
And the save changes button is not shown

# And Data Consent Tiers - Administrator Email Confirmation - Walmart

Given I ensure the Data Consent Tier Sliders are set as follows:
| Tier | State |
| 2.1  | Off   |
| 2.2  | On    |

Then I click the Save Changes button
And I click close on the Save Changes popup dialog
And the following warning message should be showing: NOTE: Your selection does not meet this retailer's request. Walmart requires suppliers of private label formulated products in the following categories to grant Tier 2.1, Tier 2.2 and Tier 4.2 permissions: Artists/Hobby, Automotive Care, Battery-Containing Products, Cleaning Supplies, Grocery, Health & Beauty, Home Improvement, Kit, Lawn and Garden, Miscellaneous, Nutritional Supplements, OTC - Over the Counter, Pet Care, Pharmacy, Sporting Goods, Stationery and Toys. Wal-Mart/SAM'S CLUB will be notified of your Data Tier selections
And the save changes button is not shown

# And Data Consent Tiers - Administrator Email Confirmation - Walmart

Given I ensure the Data Consent Tier Sliders are set as follows:
| Tier | State |
| 4.1  | On    |

Then I click the Save Changes button
And I click close on the Save Changes popup dialog
And the following warning message should be showing: NOTE: Your selection does not meet this retailer's request. Walmart requires suppliers of private label formulated products in the following categories to grant Tier 2.1, Tier 2.2 and Tier 4.2 permissions: Artists/Hobby, Automotive Care, Battery-Containing Products, Cleaning Supplies, Grocery, Health & Beauty, Home Improvement, Kit, Lawn and Garden, Miscellaneous, Nutritional Supplements, OTC - Over the Counter, Pet Care, Pharmacy, Sporting Goods, Stationery and Toys. Wal-Mart/SAM'S CLUB will be notified of your Data Tier selections
And the save changes button is not shown

# And Data Consent Tiers - Administrator Email Confirmation - Walmart

Given I ensure the Data Consent Tier Sliders are set as follows:
| Tier | State |
| 2.1  | On    |

Then I click the Save Changes button
And I click close on the Save Changes popup dialog

And I confirm the NOTE message below the Data Consent Tiers Heading is NOT shown
And the save changes button is not shown

# And Data Consent Tiers - Administrator Email Confirmation - Walmart

Given I ensure the Data Consent Tier Sliders are set as follows:
| Tier | State |
| 2.1  | Off   |
| 2.2  | Off   |
| 4.2  | Off   |

# And Database checks for Data Consent Tier changes



