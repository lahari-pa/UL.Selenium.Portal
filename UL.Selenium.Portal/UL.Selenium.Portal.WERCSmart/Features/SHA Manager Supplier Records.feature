@Shared
@SHA
@run_SHAManagerSupplierRecords
Feature: SHA Manager Supplier Records

@ignore
@TestCase:127895
Scenario: [127895] SHA Manager: Supplier Records: Verification of Data Tier Consent

Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
Then I Click 'Suppliers' in SHA Manager
Then Search for the supplier with the following name in Supplier Manager: 'The WERCS LTD'
Then Select the supplier with the following name in Supplier Manager: 'The WERCS LTD - STAGING'
Then Select the 'Data Tier Consent' Tab in Supplier Manager
Then Confirm that 'Dollar General' shows Tier 1,Tier 2.1,Tier 2.2 marked with a 'Y'
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




