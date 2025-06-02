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

@TestCase:115256
@Ignore
@Obsolete
Scenario: [115256] CVS - Uses Updated Data Tier Consent Requirements (Excluded Categories)
	Given I log in with the account saved in TReVor as: NoProductsAccount
	Then In the Products Grid I delete All products
	Then For CVS I create a product of type: Toys (RUCC0388), save it as: CVSToysProduct1 and leave it in New Status
	Then I navigate to the Data Consent Tiers Page for CVS
	And I Check that the data consent tiers available for selection only include Tier 1
	Then I click the Products in Scope button and confirm that a file is not produced called CV_Report_DataUsageTier_<Date>.xlsx
	Then I navigate to the Homepage and then In the Products Grid I delete All products

	@tfs_design
	@ignore
	#Waiting for Fabiola to get back to me on why only one switch is displaying - Philip
@TestCase:128141
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
	And In the Side Menu, click Labeled Link with My Products title
