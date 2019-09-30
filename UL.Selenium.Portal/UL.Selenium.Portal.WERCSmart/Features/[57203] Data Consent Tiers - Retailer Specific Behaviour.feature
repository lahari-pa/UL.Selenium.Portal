@RetailPartners
@Homepage
@LandingPage
@Login
@ForgottenPassword
@wercsmart
@run_DataConsentTiers_RetailerSpecific
Feature: [57203] Data Consent Tiers - Retailer Specific Behavior

#Background:
#Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
#Then I click the Retail Partners icon in the Navigation Pane
Scenario: [57206] Retailer specific - CVS
	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load
	Then I click the Retail Partners icon in the Navigation Pane
	When I select the retailer: CVS
	Then I confirm that there is a section labeled: CVS
	And I confirm that under the pie chart I see the label: % of your product portfolio is associated with CVS
	And I confirm that: CVS requires suppliers of all store branded products to grant Tier 2.1 and Tier 2.2 consent. is showing under the Data Consent Tiers heading
	When I click the More Information hyperlink
	Then I check that the current URL contains: https://login.ulscm.com/RPUI/cvsportal
	And I close the window that opened
	# Test originally wanted "https://labworks.ul.com/Pages/RCL.aspx", but redirects to a different link when clicked, so modified accordingly!
	When I click the Products in Scope button and confirm that an excel file is produced called CV_Report_DataUsageTier_<Date>.xlsx and save as CVSExcelFile
	And I confirm the excel file saved as CVSExcelFile can be opened and contains data
	Given I click on close in the Report Download dialog
	And I click the back arrow next to CVS
	Then I should see the Retail Partners page

@ScenarioId:466
Scenario: [57211] Retailer specific - Costco
	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load
	Then I click the Retail Partners icon in the Navigation Pane
	When I select the retailer: Costco
	And I confirm that: Costco requests suppliers of Cleaning, Health & Beauty, Automotive Care, and Lawn & Garden products to grant Tier 2.1 and Tier 2.2 consent. is showing under the Data Consent Tiers heading
	When I click the More Information hyperlink
	Then I check that the current URL contains: https://www.costco.com/sustainability-environment.html
	And I close the window that opened
	#When I click the Products in Scope button and confirm that an html file is produced called Report_DataUsageTier_*.htm and save as CostcoHTMLFile
	#And I confirm the html file saved as CostcoHTMLFile can be opened and contains text: Unable to generate report since no records were found
	Then I click the Products in Scope button and confirm that an excel file is produced called CO_Report_DataUsageTier_<Date>.xlsx and save as CostcoExcelFile
	And I confirm the excel file saved as CostcoExcelFile can be opened and contains data

@ScenarioId:467
Scenario: [57214] Retailer specific - Dollar Tree
	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load
	Then I click the Retail Partners icon in the Navigation Pane
	When I select the retailer: Dollar Tree
	And I confirm that: Dollar Tree requires suppliers of formulated products to grant Tier 2.1 and Tier 2.2 permissions. is showing under the Data Consent Tiers heading
	And I should not see the More Information hyperlink
	When I click the Products in Scope button and confirm that an excel file is produced called DT_Report_DataUsageTier_<Date>.xlsx and save as DollarTreeExcelFile
	And I confirm the excel file saved as DollarTreeExcelFile can be opened and contains data

@ScenarioId:468
Scenario: [57218] Retailer specific - Family Dollar
	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load
	Then I click the Retail Partners icon in the Navigation Pane
	When I select the retailer: Family Dollar
	And I confirm that: Family Dollar requires suppliers of formulated products to grant Tier 2.1 and Tier 2.2. is showing under the Data Consent Tiers heading
	And I should not see the More Information hyperlink
	When I click the Products in Scope button and confirm that an excel file is produced called FD_Report_DataUsageTiers_<Date>.xlsx and save as FamilyDollarExcelFile
	And I confirm the excel file saved as FamilyDollarExcelFile can be opened and contains data

@ScenarioId:469
Scenario: [57221] Retailer specific - Target
	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load
	Then I click the Retail Partners icon in the Navigation Pane
	When I select the retailer: Target
	And I confirm that: Target requests suppliers of Cleaning and Health & Beauty products to grant Tier 2.1, Tier 2.2, Tier 3, and Tier 4.1 consent. is showing under the Data Consent Tiers heading
	When I click the More Information hyperlink
	Then I check that the current URL contains: https://corporate.target.com/corporate-responsibility/planet/sustainable-products
	And I close the window that opened
	When I click the Products in Scope button and confirm that an excel file is produced called TG_Report_DataUsageTier_<Date>.xlsx and save as TargetExcelFile
	And I confirm the excel file saved as TargetExcelFile can be opened and contains data

@ScenarioId:470
Scenario: [57223] Retailer specific - Walgreens
	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load
	Then I click the Retail Partners icon in the Navigation Pane
	When I select the retailer: Walgreens
	And I confirm that: Walgreens requests suppliers of Cleaning and Health & Beauty products to grant Tier 2.1 and Tier 2.2 consent. is showing under the Data Consent Tiers heading
	When I click the More Information hyperlink
	Then I check that the current URL contains: https://www.walgreens.com/topic/sr/sr_product_integrity_home.jsp
	And I close the window that opened
	When I click the Products in Scope button and confirm that an excel file is produced called WG_Report_DataUsageTier_<Date>.xlsx and save as WalgreensExcelFile
	And I confirm the excel file saved as WalgreensExcelFile can be opened and contains data

@ScenarioId:471
Scenario: [57225] Retailer specific - Walmart
	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load
	Then I click the Retail Partners icon in the Navigation Pane
	When I select the retailer: Wal-Mart
	And I confirm that: Walmart requires suppliers of private label formulated products in the following categories to grant Tier 2.1, Tier 2.2 and Tier 4.2 permissions: Artists/Hobby, Automotive Care, Battery-Containing Products, Cleaning Supplies, Grocery, Health & Beauty, Home Improvement, Kit, Lawn and Garden, Miscellaneous, Nutritional Supplements, OTC - Over the Counter, Pet Care, Pharmacy, Sporting Goods, Stationery and Toys. is showing under the Data Consent Tiers heading
	When I click the More Information hyperlink
	Then I check that the current URL contains: https://www.walmartsustainabilityhub.com/sustainable-chemistry
	And I close the window that opened
	When I click the Products in Scope button and confirm that an excel file is produced called WM_Report_DataUsageTier_<Date>.xlsx and save as WalmartExcelFile
	And I confirm the excel file saved as WalmartExcelFile can be opened and contains data

@ScenarioId:472
Scenario: [57229] Retailer specific - Canadian Tire
	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load
	Then I click the Retail Partners icon in the Navigation Pane
	When I select the retailer: Canadian Tire
	And I confirm that: Canadian Tire requires suppliers of formulated products to grant Tier 2.1 and Tier 2.2 permissions. is showing under the Data Consent Tiers heading
	When I click the Products in Scope button and confirm that an excel file is produced called CT_Report_DataUsageTier_<Date>.xlsx and save as CanadianTireExcelFile
	And I confirm the excel file saved as CanadianTireExcelFile can be opened and contains data

@ScenarioId:473
Scenario: [69112] Retailer specific - Topco
	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load
	Then I click the Retail Partners icon in the Navigation Pane
	When I select the retailer: TopCo
	And I confirm that: TopCo requires suppliers of products to grant Tier 1 at this time. What are the Data Usage Tiers? Data Consent Tiers Accepted Tier 1: Regulatory Support By agreeing to the Terms of Use upon creation of the WERCSmart account, you agree that all registrations will comply with Data Tier 1 for Regulatory Support to the retail recipient for your product registrations. This option cannot be changed in any way. The Terms of Use designate Tier 1 as: Mandatory Consent. Any registered WERCSmart supplier of a product (a "Direct Supplier") is deemed to consent to providing Tier 1 Data Use - Regulatory Support ("Tier 1 Consent") to any entity that sells, transports, stores or disposes of such Direct Supplier's product (each, a "WERCSmart Recipient"). The WERCSmart platform provides Direct Suppliers with a current list of all WERCSmart Recipients as well as product-level information about which specific Recipients are in receipt of Tier 1 data. Any registered supplier that provides components to a Direct Supplier (a "Third-Party Supplier") is also deemed to provide Tier 1 Consent to WERCSmart Recipients. Use of the term "Supplier(s)" shall mean both Direct Suppliers and Third-Party Suppliers. is showing under the Data Consent Tiers

@ScenarioId:474
Scenario: [74540] Target - Data Tier Warning when not all are selected
	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load
	Then I click the Retail Partners icon in the Navigation Pane
	When I select the retailer: Target
	Then the Data Consent Tier: Tier 2.1 should be set to: on
	Given I toggle the data consent tier: Tier 2.1 to: off
	Given I click the Save Changes button
	Given I click close on the Save Changes popup dialog
	Then the warning message in the Retail Partners details page should contain the following:
		| Message                                                                                                                                                                                                                                                                                              |
		| NOTE: Your selection does not meet this retailer's request. Target requests suppliers of Cleaning and Health & Beauty products to grant Tier 2.1, Tier 2.2, Tier 3, and Tier 4.1 consent. Target will be notified of your Data Tier selections                                                       |
		| Revising the Data Use Tier consents you have provided to a retailer will suspend your participation in that retailer’s programs. Product data and reports generated while you consent was in effect will remain available to the retailer, but no further product data or reports will be generated. |
	Given I toggle the data consent tier: Tier 2.1 to: on
	Given I click the Save Changes button
	Then The success message in the Save Changes popup dialog should contain the following:
		| Message                                                                                       |
		| The information was saved correctly and the notification Email was sent to all Administrators |
	Given I click close on the Save Changes popup dialog
	And I confirm the NOTE message below the Data Consent Tiers Heading is NOT shown
	Given I click the back arrow on the Retail Partners Details page
	Then I should see the Retail Partners page
