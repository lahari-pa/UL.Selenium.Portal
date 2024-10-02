@Shared
@wercsmart
@Login
@UlSolutionCenter
@Homepage
@ProductGrid
@ForwardProductRegistration
@NewProduct
@RetailPartners
@MessageCenter
@MyAccount
@LandingPage
@DocumentAcceptance
@DeleteActiveProducts
@Solutions
@ReviewDocuments
@SHA
@SummaryPage
@PaymentMethods
@ProductSetUp
@UPC
@DeleteActiveProducts
@run_BulkActions
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:ProductInformation
@PhysicalAndChemicalProp
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:RegulatoryDocumentsToProvide
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:OptionalComments
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:DataAcceptance
@Ingredients
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:NewProduct
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:Product
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:InventoryStatusProp65
@StepsPrototype
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:TheProduct
@RegulatoryInformation3



Feature: BulkActions

Background:
	Given I verify the following users exist and if not I create them using SHAUser
		| username    | FirstName | LastName   | Role         | EmailAddress                |
		| SHAQAAuto6  | QA        | Automation | QA Reviewers | qasha.kxxyxunf@mailosaur.io |

#Removed from regression 08/2023
@ignore
@TestCase:56223
Scenario: [56223] Bulk Actions - Forward Product Registration navigation
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then the WERCSmart homepage should load
	Given I click Bulk Actions in the Products Grid
	And I click Forward Product Registration in the Bulk Actions window
	Then I should see the header: Forward Product Registration on the Forward Product Registration window
	And I should see the subheading 3: Select Products & UPCs on the Forward Product Registration window

#This test cases uses the ULSC account
@ignore
@TestCase:56224
Scenario: [56224] Bulk Actions - Sync Products to WERCSLink navigation
	Given I Login into WERCSmart Portal - Admin Role - WERCs ULSC Account
	Then the WERCSmart homepage should load
	Given I click Bulk Actions in the Products Grid
	And I click Sync Products in the Bulk Actions window
	And I should see the header: Sync Products to ULSC on the Sync Products to ULSC window
	Then I click on the cancel button on the ULSC Sync popup
	And I should see the Subheading Alerts in the main window
	
@TestCase:88826
Scenario:[88826] Delete Products > Product Not yet submitted
	#Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I log in with the account saved in TReVor as: ProductAccount
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Given in the New Product page I click Continue
	#Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk
	 Then I should be on the The Product Page
	And In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Chalk_#88826
	And In the Product Section, set the option in section: 'Type of Product (select)' to: Chalk
	Then in the The Product page, I click Continue

	Then I save the product information as: TestCase88826
	Then I generate a random UPC number and save as: UPC88826
	#Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Given I should see the Product Information Page
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)' to: No
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue

	#Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I should see the Physical and Chemical Properties Page
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' should be showing the option: Solid
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' confirm option is selected: Solid
	Then In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
	Then In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Then In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
	Then in the Physical and Chemical Properties page I click Continue

	#And I call Shared Step 29181 (Ingredients - add any chemical) with name: Water
	Given I should see the Ingredients Page
	Then In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	| component name | Water       | 100     |                     |               |             |
	Then in the Ingredients page I click Continue

	And I call Shared Step 57503 (Inventory Status, Prop 65 (US) - TSCA(Any Option) - Prop 65 (NO) - Continue - Happy Path)
	And In the 'Select Retailers' window I select the retailer: CVS
	And I click continue
	And I call Shared Step 85909 (UPC - Confirm Package type link and drop down not shown - Add UPC data - Continue) for UPC: saved as UPC88826, container type: Plastic Container and size: 12 click continue
	#Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
	Then in the Regulatory Documents to Provide page I click Continue

	Then in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I navigate to the home page
	Given I click Bulk Actions in the Products Grid
	And I click Delete Products in the Bulk Actions window
	And I should see the header: Delete Active Products on the Delete Active Product window
	Then In the Delete Active Products page I search for WPS ID saved as: TestCase88826
	Then In the Delete Active Products page I click the Filter button
	Then I make sure product saved as: TestCase88826 should not missing from the product list
	Then I select checkbox for product saved as: TestCase88826  
	Then I click on the Make Obsolete button
	Then I select the checkbox in the Make Obsolete popup
	Then In the Make Obsolete popup I click on the Accept button
	Then In the Delete Active Products page I search for WPS ID saved as: TestCase88826
	Then In the Delete Active Products page I click the Filter button
	Then I make sure product saved as: TestCase88826 should missing from the product list
	Given I navigate to the home page
	Then I confirm the follow product doesn't exist in the product grid: TestCase88826
