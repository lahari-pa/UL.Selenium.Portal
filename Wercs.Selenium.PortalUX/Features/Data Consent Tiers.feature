@RetailPartners
@Homepage
@run_DataConsentTiers

Feature: Data Consent Tiers

Scenario: [56942] Data Consent Tiers - Walmart
Given I login into the WERCSmart Portal - Administrator Role
Then I click the Retail Partners icon in the Navigation Pane
When I select the retailer: Wal-Mart
Then I should see the Data Consent Tiers heading
And the Tier 1 Data Usage Tier should not be editable
And the Tier 2.1 Data Usage Tier should be editable
And the Tier 2.2 Data Usage Tier should be editable
And the Tier 4.2 Data Usage Tier should be editable
And the Save Changes button should be showing
Given I set the Tier 2.1 slider to be active
And I set the Tier 2.2 slider to be inactive
And I set the Tier 4.2 slider to be inactive
Then I click on the Save Changes button
And I close the Saved Message popup dialog



