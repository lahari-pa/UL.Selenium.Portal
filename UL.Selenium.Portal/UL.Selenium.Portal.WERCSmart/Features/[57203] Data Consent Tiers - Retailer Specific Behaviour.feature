@Shared
@RetailPartners
@Homepage
@LandingPage
@ProductGrid
@Login
@SupplierReports
@ForgottenPassword
@CreateProducts
@wercsmart
@DocumentAcceptance
@run_DataConsentTiers_RetailerSpecific
Feature: [57203] Data Consent Tiers - Retailer Specific Behavior

@ScenarioId:8261

#Background:
#Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
#Then I click the Retail Partners icon in the Navigation Pane
@ScenarioId:5990
Scenario: [57206] Retailer specific - CVS
	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load
	Then I click the Retail Partners icon in the Navigation Pane
	When I select the retailer: CVS
	Then I confirm that there is a section labeled: CVS
	And I confirm that under the pie chart I see the label: % of your product portfolio is associated with CVS
	And I confirm that: CVS requires suppliers of formulated products in the following categories to grant Tier 2.1, Tier 2.2 and Tier 4.1 permissions: Artists/Hobby, Automotive Care, Cleaning Supplies, Health & Beauty, Home Improvement, Lawn and Garden, Miscellaneous, Nutritional Supplements, Over-the-Counter (OTC), Pet Care, Photography, Sporting Goods, Stationery and Pharmacy is showing under the Data Consent Tiers heading
	When I click the More Information hyperlink
	Then I check that the current URL contains: https://login.ulscm.com/RPUI/cvsportal
	And I close the window that opened
	# Test originally wanted "https://labworks.ul.com/Pages/RCL.aspx", but redirects to a different link when clicked, so modified accordingly!
	When I click the Products in Scope button and confirm that an excel file is produced called CV_Report_DataUsageTier_<Date>.xlsx and save as CVSExcelFile
	And I confirm the excel file saved as CVSExcelFile can be opened and contains data
	Given I click on close in the Report Download dialog
	And I click the back arrow next to CVS
	Then I should see the Retail Partners page

@tfs_design
@CostcoRemoval
@ScenarioId:466
#Obsolete test case after costco removal (4/30/2020)
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
	When I click the Products in Scope button and confirm that an excel file is produced called FD_Report_DataUsageTier_<Date>.xlsx and save as FamilyDollarExcelFile
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

@ScenarioId:6036
Scenario: [115256] CVS - Uses Updated Data Tier Consent Requirements (Excluded Categories)
	Given I log in with the account saved in TReVor as: NoProductsAccount
	Then In the Products Grid I delete All products
	Then For CVS I create a product of type: Toys (RUCC0388), save it as: CVSToysProduct1 and leave it in New Status
	Then I navigate to the Data Consent Tiers Page for CVS
	And I Check that the data consent tiers available for selection only include Tier 1
	Then I click the Products in Scope button and confirm that a file is not produced called CV_Report_DataUsageTier_<Date>.xlsx
	Then I navigate to the Homepage and then In the Products Grid I delete All products


	@singleRun
@ScenarioId:6035
Scenario: [115255] CVS - Uses Updated Data Tier Consent Requirements (Included Categories)

	Given I log in with the account saved in TReVor as: NoProductsAccount
	Then In the Products Grid I delete All products
	Then For CVS I create a product of type: Health & Beauty (RUCC0392), save it as: CVSHBProduct1 and leave it in New Status
	Then I navigate to the CVS retailer Page then check that it contains the expected data tiers and that Products in Scope downloads a file, save it as: CVSHBExcelFile and check that is shows the expected product saved as: CVSHBProduct1
	Then For CVS I create a product of type: Artist Supply (RUCC0384), save it as: CVSArtistProduct1 and leave it in New Status
	Then I navigate to the CVS retailer Page then check that it contains the expected data tiers and that Products in Scope downloads a file, save it as: CVSArtistExcelFile and check that is shows the expected product saved as: CVSArtistProduct1
	Then For CVS I create a product of type: Cleaning Supply (RUCC0397), save it as: CVSCleaningProduct1 and leave it in New Status
	Then I navigate to the CVS retailer Page then check that it contains the expected data tiers and that Products in Scope downloads a file, save it as: CVSCleaningExcelFile and check that is shows the expected product saved as: CVSCleaningProduct1
	Then For CVS I create a product of type: Home Improvement (RUCC0394), save it as: CVSHomeProduct1 and leave it in New Status
	Then I navigate to the CVS retailer Page then check that it contains the expected data tiers and that Products in Scope downloads a file, save it as: CVSHomeExcelFile and check that is shows the expected product saved as: CVSHomeProduct1
	Then For CVS I create a product of type: Lawn & Garden (RUCC0395), save it as: CVSLawnGardenProduct1 and leave it in New Status
	Then I navigate to the CVS retailer Page then check that it contains the expected data tiers and that Products in Scope downloads a file, save it as: CVSLawnGardenExcelFile and check that is shows the expected product saved as: CVSLawnGardenProduct1
 	Then For CVS I create a product of type: Miscellaneous (RUCC0400), save it as: CVSMiscProduct1 and leave it in New Status
	Then I navigate to the CVS retailer Page then check that it contains the expected data tiers and that Products in Scope downloads a file, save it as: CVSMiscExcelFile and check that is shows the expected product saved as: CVSMiscProduct1
	Then For CVS I create a product of type: Nutritional (RUCC0592), save it as: CVSNutritionalProduct1 and leave it in New Status
	Then I navigate to the CVS retailer Page then check that it contains the expected data tiers and that Products in Scope downloads a file, save it as: CVSNutritionalExcelFile and check that is shows the expected product saved as: CVSNutritionalProduct1
	Then For CVS I create a product of type: Over-the-Counter (RUCC1002), save it as: CVSOTCProduct1 and leave it in New Status
	Then I navigate to the CVS retailer Page then check that it contains the expected data tiers and that Products in Scope downloads a file, save it as: CVSOTCExcelFile and check that is shows the expected product saved as: CVSOTCProduct1
	Then For CVS I create a product of type: Pet Care (RUCC0387), save it as: CVSPetCareProduct1 and leave it in New Status
	Then I navigate to the CVS retailer Page then check that it contains the expected data tiers and that Products in Scope downloads a file, save it as: CVSPetCareExcelFile and check that is shows the expected product saved as: CVSPetCareProduct1
	Then For CVS I create a product of type: Photography (RUCC0735), save it as: CVSPhotopraphyProduct1 and leave it in New Status
	Then I navigate to the CVS retailer Page then check that it contains the expected data tiers and that Products in Scope downloads a file, save it as: CVSPhotopraphyExcelFile and check that is shows the expected product saved as: CVSPhotopraphyProduct1
	Then For CVS I create a product of type: Sporting Goods (RUCC0386), save it as: CVSSportingGoodsProduct1 and leave it in New Status
	Then I navigate to the CVS retailer Page then check that it contains the expected data tiers and that Products in Scope downloads a file, save it as: CVSSportingGoodsExcelFile and check that is shows the expected product saved as: CVSSportingGoodsProduct1
	Then For CVS I create a product of type: Stationery (RUCC0385), save it as: CVSStationeryProduct1 and leave it in New Status
	Then I navigate to the CVS retailer Page then check that it contains the expected data tiers and that Products in Scope downloads a file, save it as: CVSStationeryExcelFile and check that is shows the expected product saved as: CVSStationeryProduct1
	Then For CVS I create a product of type: Pharmacy (RUCC0393), save it as: CVSPharmacyProduct1 and leave it in New Status
	Then I navigate to the CVS retailer Page then check that it contains the expected data tiers and that Products in Scope downloads a file, save it as: CVSPharmacyExcelFile and check that is shows the expected product saved as: CVSPharmacyProduct1
	
	

	#Then For CVS I create a product of type: Battery (RUCC0733), save it as: CVSBatteryProduct1 and leave it in New Status
	#Then I navigate to the CVS retailer Page then check that it contains the expected data tiers and that Products in Scope downloads a file, save it as: CVSBatteryExcelFile and check that is shows the expected product saved as: CVSBatteryProduct1
	#Cannot create Grocery Products for cvs, waiting on dev response
	#Then For CVS I create a product of type: Grocery (RUCC0389), save it as: CVSGroceryProduct1 and leave it in New Status
	#Then I navigate to the CVS retailer Page then check that it contains the expected data tiers and that Products in Scope downloads a file, save it as: CVSGroceryExcelFile and check that is shows the expected product saved as: CVSGroceryProduct1

	@tfs_design
	#Waiting for Fabiola to get back to me on why only one switch is displaying - Philip
@ScenarioId:8261
	Scenario: [128141] Verification that 'Bed Bath and Beyond' Displays under 'My Retailers' and its Data Consent Tiers

Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Then I click the Retail Partners icon in the Navigation Pane
	When I select the retailer: Bed Bath and Beyond (Including Harmon, Buy buy Baby, and Christmas Tree Shops)
	And I confirm that: Bed Bath and Beyond (including Harmon, Buy Buy Baby, and Christmas Tree Shops) requires suppliers of formulated products in the following categories to grant Tier 2.1, Tier 2.2 and Tier 4.1 permissions: Cleaning Supplies, Grocery, Health & Beauty, Nutritional Supplements, OTC - Over the Counter, and Pharmacy is showing under the Data Consent Tiers heading
	When I click the More Information hyperlink
	Then I check that the current URL contains: https://bedbathandbeyond.gcs-web.com/static-files/551ad447-b204-4204-90c8-a5064079c2f5/
	And I close the window that opened

	And I click the "What are the Data Usage Tiers?" information button in the Retail Partners Details screen

	And I click the "Tier 1: Regulatory Compliance" tab in Data Tier Details
	And I confirm the Data Tier Details subheading reads: What does Regulatory Support mean?
	And I click download PDF for "What does Regulatory Support mean?"
	Then I confirm a new window opens displaying the document url: https://staging.thewercs.com/Wercs.SHA.MVCWebV1/RetailPartners/Retailer/Index/ec6b4522-b4f7-4567-acd2-8101450b6a07

	And I click the "Tier 2: Chemical Program Support" tab in Data Tier Details
	And I confirm the Data Tier Details subheading reads: What does Chemical Program Support mean?
	And I click download PDF for "What does Chemical Program Support mean?"
	Then I confirm a new window opens displaying the document url: https://staging.thewercs.com/Wercs.SHA.MVCWebV1/RetailPartners/Retailer/Index/ec6b4522-b4f7-4567-acd2-8101450b6a07

	And I click the "Tier 3: Supplemental Reports" tab in Data Tier Details
	And I confirm the Data Tier Details subheading reads: What does Supplemental Reports for Internal Business Use Only mean?
	And I click download PDF for "What does Supplemental Reports for Internal Business Use Only mean?"
	Then I confirm a new window opens displaying the document url: https://staging.thewercs.com/Wercs.SHA.MVCWebV1/RetailPartners/Retailer/Index/ec6b4522-b4f7-4567-acd2-8101450b6a07

	And I click the "Tier 4: Public Disclosure Options" tab in Data Tier Details
	And I confirm the Data Tier Details subheading reads: What are my Public Disclosure Options?
	And I click download PDF for "What are my Public Disclosure Options?"
	Then I confirm a new window opens displaying the document url: https://staging.thewercs.com/Wercs.SHA.MVCWebV1/RetailPartners/Retailer/Index/ec6b4522-b4f7-4567-acd2-8101450b6a07

	And The Data Tier Details popup shows the following tabs:
		| Tab                               |
		| Tier 1: Regulatory Compliance     |
		| Tier 2: Chemical Program Support  |
		| Tier 3: Supplemental Reports      |
		| Tier 4: Public Disclosure Options |
	And I close the Data Tier Details popup

	Then I confirm that there is a section labeled: Data Consent Tiers
	Given I ensure the Data Consent Tier On/Off switch exists for the following tiers:
		| Tier |
		| 1    |
	Given I click the back arrow on the Retail Partners Details page
	Then I should see the Retail Partners page
	And I navigate to the home page
