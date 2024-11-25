@Shared
@LandingPage
@Login
@Homepage
@Signup
@wercsmart
@NewProduct
@ProductGrid
@DataSummarySheet
@wercsmart
@RetailPartners
@UPC
@run_ProductDocuments
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:ProductInformation
@PhysicalAndChemicalProp
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:RegulatoryDocumentsToProvide
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:OptionalComments
@Ingredients
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:NewProduct
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:TheProduct
@StepsPrototype

Feature: Product Documents

# Assigned to Barrett, Beverly
# Created by Barrett, Beverly
# Test case can be found at the following paths:
# NetProjects10\WERCSmart UX Reboot\WERCSmart\Product Registration\Product Documents
# NetProjects10\WercsSmart Portal\WERCSmart\Product Registration\Product Documents

@59322
@TestCase:59322
Scenario: [59322] Upload document - VOC exemption letter & VOC product label
	#Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I log in with the account saved in TReVor as: ProductAccount
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Given in the New Product page I click Continue
	# And I In the Shared step below select "Personal Fragrance Product (more than 20 percent fragrance)" as your product type
	And I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Personal Fragrance Product (more than 20% fragrance) - Liquid
	Then I save the product information as: TestCase59322
	Given I call Shared Step 57401 (Product Information - US only - No GHS, Not Direct Ship, Not PLP, Not GNFR > Continue - Happy Path)
	#And I call Shared Step 70675 (Physical and Chemical Properties - Liquid Only - With Water Solubility - Enter all data - Continue)
	Given I should see the Physical and Chemical Properties Page
	Then In the Physical and Chemical Properties Section, set the option in section: 'Primary Physical State' to: Liquid
	Then In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Liquid
	Then In the Physical and Chemical Properties Section, for section: 'Relative Density' enter text: 1.0
	Then In the Physical and Chemical Properties Section, for section: 'pH' enter text: 10.2
	Then In the Physical and Chemical Properties Section, for section: 'Boiling Point (in Celsius)' enter text: 120
	Then In the Physical and Chemical Properties Section, for section: 'Flash Point (in Celsius)' enter text: 55
	Then In the Physical and Chemical Properties Section, set the option in section: 'Flash Point Testing Method Used' to: Closed cup method
	Then In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
	Then in the Physical and Chemical Properties page, I click Continue

	#And I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
	Given I should see the Ingredients Page
	Then In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	| component name | Sodium hydroxide       | 100     |                     |               |             |
	Then in the Ingredients page I click Continue

	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	And I call Shared Step 57506 (Transportation Details 1 - Regulated for Transport(No) - Exemption(Random) - Continue - Happy Path)
	And I call Shared Step 62536 (Transportation Details 2 > I do not ship internationally > Continue - Happy Path)
	# Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB) Page
	Then I should see the Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB) Page
	And I set the Product has been granted an Alternative Control Plan option to: Yes
	And I set the Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the CARB field to: 23
	Given in the New Product page I click Continue
	Given In the VOC Acceptance section I agree
	Given in the New Product page I click Continue
	#And I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	And I call Shared Step 63219 (Retailer Association - Select No Retailer - Click continue)
	#And I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
	Then in the Regulatory Documents to Provide page I click Continue

	And I should see the Additional Documents to Provide Page
	#And I Confirm the Volatile Organic Compounds - Product Label control and the Volatile Organic Compounds - VOC Exemption letter is shown (other file upload controls may also be shown but we will only use the VOC ones)
	Then in the Additional Documents to Provide page I click Continue
	Then Volatile Organic Compounds should be showing the error messages: Document is required: VOC Exemption Letter
	Then Volatile Organic Compounds should be showing the error messages: Document is required: Product Label
	Given I call Shared Step 59042 (Browse for File > select > click Open - Happy Path) for document type: VOC Exemption Letter and file: UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf
	Given I call Shared Step 59042 (Browse for File > select > click Open - Happy Path) for document type: Product Label and file: UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf
	Given in the New Product page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	And I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
		| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
	#And I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	And I call Shared Step 73956 (Go to Summary and verify data) with product type: Personal Fragrance Product (more than 20% fragrance) - Liquid
	And I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase59322



@TestCase:59320
Scenario: [59320] Upload Document - IFRA certificate

	#Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I log in with the account saved in TReVor as: ProductAccount

	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Given in the New Product page I click Continue

	#And I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Crayon
	Then I should be on the The Product Page
	And In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Crayon_#59320
	And In the Product Section, set the option in section: 'Type of Product (select)' to: Crayon
	Then in the The Product page, I click Continue

	Then I save the product information as: TestCase59320

	#And I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Given I should see the Product Information Page
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)' to: No
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue

	#And I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I should see the Physical and Chemical Properties Page
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' should be showing the option: Solid
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' confirm option is selected: Solid
	Then In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
	Then In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Then In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
	Then in the Physical and Chemical Properties page I click Continue

	#And I call Shared Step 79436 (Ingredients - Add FRAGRANCE component, Publicly Disclosed = Yes,  Select Public Name) and save ingredient as: shared79436
	#	| CASNumber | ComponentName                                                                  | Percentage |
	#	| FRAGRANCE | Fragrance - Awapuhi - Skin sens 1, Repro 2, Aquatic acute 2, Aquatic chronic 2 | 100        |
	Then I should be on the Ingredients Page
	And In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue                           | Percent | Publicly Disclosed? | Trade Secret? | Public Name                           |
	| component name | Water                                 | 88      | True                | False         | WATER                                 |
	| component name | SODIUM LAURYL SULFATE                 | 10      | True                | False         | SODIUM LAURYL SULFATE                 |
	| component name | FRAGRANCE - TANGERINE WITH LEMONGRASS | 2       | True                | False         | FRAGRANCE - TANGERINE WITH LEMONGRASS |
	Then in the Ingredients page, I click Continue
	And In the Ingredients Section, I confirm I check the checkbox in the popup view with the following text: The Product Type, Pest Selection, and Ingredients listed are accurate



	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	And I call Shared Step 63219 (Retailer Association - Select No Retailer - Click continue)
	#And I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
	Then in the Regulatory Documents to Provide page I click Continue

	And I should see the Additional Documents to Provide Page
	Then in the Additional Documents to Provide page I click Continue
	Then International Fragrance Association (IFRA) should be showing the error messages: Document is required: IFRA Certificate (Perfumery Products)
	And I call Shared Step 59042 (Browse for File > select > click Open - Happy Path) for document type: IFRA Certificate (Perfumery Products) and file: UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf
	Given I call Shared Step 59042 (Browse for File > select > click Open - Happy Path) for document type: Product Label and file: UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf
	Then in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	And I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
		| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
	#And I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	And I call Shared Step 73956 (Go to Summary and verify data) with product type: Crayon
	And I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase59320


@TestCase:59321
Scenario: [59321] Upload Document - GRAS certificate
	#Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I log in with the account saved in TReVor as: ProductAccount
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Given in the New Product page I click Continue
	And I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Crayon 
	Then I save the product information as: TestCase59321
	#And I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Given I should see the Product Information Page
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)' to: No
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue

	#And I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I should see the Physical and Chemical Properties Page
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' should be showing the option: Solid
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' confirm option is selected: Solid
	Then In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
	Then In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Then In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
	Then in the Physical and Chemical Properties page I click Continue

	Given I call Shared Step 79431 (Ingredients - Add FLAVOR component, Publicly Disclosed = Yes, Select Public Name) and save ingredients as: shared79431
		| CASNumber | ComponentName | Percentage |
		| FLAVOR    | FLAVOR        | 100        |
	Given in the Ingredients page I click Continue
	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	And I call Shared Step 63219 (Retailer Association - Select No Retailer - Click continue)
	#And I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
	Then in the Regulatory Documents to Provide page I click Continue

	And I should see the Additional Documents to Provide Page
	Then in the Additional Documents to Provide page I click Continue
	Then Generally Recognized as Safe (GRAS) should be showing the error messages: Document is required: GRAS Certificate (Flavor Products)
	And I call Shared Step 59042 (Browse for File > select > click Open - Happy Path) for document type: GRAS Certificate (Flavor Products) and file: UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf
	Then in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	And I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
		| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
	#And I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	And I call Shared Step 73956 (Go to Summary and verify data) with product type: Crayon
	And I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase59321

