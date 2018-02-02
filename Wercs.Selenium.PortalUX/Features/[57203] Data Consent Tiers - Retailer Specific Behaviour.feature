@RetailPartners
@Homepage
@LandingPage
@Login
@ForgottenPassword
@wercsmart
@run_DataConsentTiers_RetailerSpecific

Feature: [57203] Data Consent Tiers - Retailer Specific Behaviour

Background:
Given Login into WERCSmart Portal - Administrator Role - WERCs Account
Then I click the Retail Partners icon in the Navigation Pane

Scenario: [57206] Retailer specific - CVS
When I select the retailer: CVS
Then I confirm that there is a section labeled: CVS & You 
And I confirm that under the pie chart I see the label: % of your product portfolio is associated with CVS
And I confirm that: CVS requires suppliers of all store branded products to grant Tier 2.1 and Tier 2.2 consent. is showing under the Data Consent Tiers heading

When I click the More Infomation hyperlink
Then I check that the current URL contains: https://login.ulscm.com/RPUI/cvsportal
And I close the window that opened

# Test originally wanted "https://labworks.ul.com/Pages/RCL.aspx", but redirects to a different link when clicked, so modified accordingly!

When I click the Products in Scope button
Then I confirm that an excel file is produced called CV_Report_DataUsageTier_<Date>.xlsx and save as CVSExcelFile
And I confirm the excel file saved as CVSExcelFile can be opened and contains data

# And Close the excel file and return to the Portal page
# And Click the back arrow next to CVS
# You should be returned to the main Retail Partner page.

Scenario: [57211] Retailer specific - Costco
When I select the retailer: Costco
And I confirm that: Costco requires suppliers of all store branded products to grant Tier 2.1 and Tier 2.2 consent. is showing under the Data Consent Tiers heading

When I click the More Infomation hyperlink
Then I check that the current URL contains: https://www.costco.com/sustainability-environment.html
And I close the window that opened

When I click the Products in Scope button
Then I confirm that an excel file is produced called CO_Report_DataUsageTier_<Date>.xlsx and save as CostcoExcelFile
And I confirm the excel file saved as CostcoExcelFile can be opened and contains data

Scenario: [57214] Retailer specific - Dollar Tree
When I select the retailer: Dollar Tree
And I confirm that: Dollar Tree requires suppliers of Cleaning and Health & Beauty products to grant Tier 2.1 and Tier 2.2 consent. is showing under the Data Consent Tiers heading
And I should not see the More Information hyperlink
When I click the Products in Scope button
Then I confirm that an excel file is produced called DT_Report_DataUsageTier_<Date>.xlsx and save as DollarTreeExcelFile
And I confirm the excel file saved as DollarTreeExcelFile can be opened and contains data

Scenario: [57221] Retailer specific - Target
When I select the retailer: Target
And I confirm that: Target requests suppliers of Cleaning and Health & Beauty products to grant Tier 2.1, Tier 2.2, Tier 3, and Tier 4.1 consent. is showing under the Data Consent Tiers heading

When I click the More Infomation hyperlink
Then I check that the current URL contains: https://corporate.target.com/corporate-responsibility/sustainability/sustainable-products
And I close the window that opened

When I click the Products in Scope button
Then I confirm that an excel file is produced called TG_Report_DataUsageTier_<Date>.xlsx and save as TargetExcelFile
And I confirm the excel file saved as TargetExcelFile can be opened and contains data

Scenario: [57223] Retailer specific - Walgreens
When I select the retailer: Walgreens
And I confirm that: Walgreens requests suppliers of Cleaning and Health & Beauty products to grant Tier 2.1 and Tier 2.2 consent. is showing under the Data Consent Tiers heading

When I click the More Infomation hyperlink
Then I check that the current URL contains: https://www.walgreens.com/topic/sr/sr_product_integrity_home.jsp
And I close the window that opened

When I click the Products in Scope button
Then I confirm that an excel file is produced called WG_Report_DataUsageTier_<Date>.xlsx and save as WalgreensExcelFile
And I confirm the excel file saved as WalgreensExcelFile can be opened and contains data

Scenario: [57225] Retailer specific - Walmart
When I select the retailer: Wal-Mart
And I confirm that: Walmart requires suppliers of private label formulated products in the following categories to grant Tier 2.1, Tier 2.2 and Tier 4.2 permissions: Artists/Hobby, Automotive Care, Battery-Containing Products, Cleaning Supplies, Grocery, Health & Beauty, Home Improvement, Kit, Lawn and Garden, Miscellaneous, Nutritional Supplements, OTC - Over the Counter, Pet Care, Pharmacy, Sporting Goods, Stationery and Toys. is showing under the Data Consent Tiers heading

When I click the More Infomation hyperlink
Then I check that the current URL contains: https://www.walmartsustainabilityhub.com/sustainable-chemistry
And I close the window that opened

When I click the Products in Scope button
Then I confirm that an excel file is produced called WM_Report_DataUsageTier_<Date>.xlsx and save as WalmartExcelFile
And I confirm the excel file saved as WalmartExcelFile can be opened and contains data

Scenario: [57229] Retailer specific - Canadian Tire

When I select the retailer: Canadian Tire
And I confirm that: Canadian Tire requires suppliers of formulated products to grant Tier 2.1 and Tier 2.2 permissions. is showing under the Data Consent Tiers heading

When I click the Products in Scope button
Then I confirm that an excel file is produced called CT_Report_DataUsageTier_<Date>.xlsx and save as CanadianTireExcelFile
And I confirm the excel file saved as CanadianTireExcelFile can be opened and contains data