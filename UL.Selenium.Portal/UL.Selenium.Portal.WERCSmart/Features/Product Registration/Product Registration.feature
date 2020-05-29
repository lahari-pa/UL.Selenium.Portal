@Shared
@LandingPage
@Login
@Homepage
@Signup
@wercsmart
@NewProduct
@ProductGrid
@DataSummarySheet
@MyIngredients
@wercsmart
@RetailPartners
@run_ProductRegistration
Feature: Product Registration

#Background:
#Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
#Given If I see the retail partners page I set all data consent tiers to true for all retailers in the top section
#Then The home screen should load
@ScenarioId:486
Scenario: Create a new product
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given If I see the retail partners page I set all data consent tiers to true for all retailers in the top section
	Then The home screen should load
	Then I click the Register New Product icon in the Navigation Pane
	And I should see the header New Product
	Given I click the Register New Product icon in the Navigation Pane
	When I click continue

@ScenarioId:483
Scenario: [63705] New Product - BCP
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given If I see the retail partners page I set all data consent tiers to true for all retailers in the top section
	Then The home screen should load
	Given I delete all products with UPC Number: 630509667031
	And I click the Register New Product icon in the Navigation Pane
	And I should see the header New Product
	And I Select the Create a New Registration radio button
	And in the New Product page I click Continue
	And I set 'Product Name' to: Answering Machine, Battery Included
	#And In the Product Type tab of the New Product Page, I enter: Answering Machine, Battery Included in the Type of Product select field
	And I set 'Type of Product' to: Answering Machine, Battery Included
	And in the New Product page I click Continue
	Then I save the product information as: TestCase63705
	# Shared step 63704
	And I should see the Additional Product Information Page
	And In the Additional Information Page the check box for: United States should be: checked
	And I set 'Product is shipped directly' to: No
	And I set 'Product is a Retailers Private Label or Brand' to: No
	And I set 'Product is solely for the Retailer's use' to: No
	And in the New Product page I click Continue
	And For 'U.S. Toxic Substances Control Act (TSCA) status' I select: Compliant
	And I set 'Prop65' to: No
	And in the New Product page I click Continue
	And I should see the Product Includes Battery Page
	And For 'Indicate how battery is packaged' I select: The battery is shipped with but not included in my product.
	And I add the following batteries:
		| Battery Type | Manufacturer | Number of batteries per package | How many batteries required to run | Saved As |
		| Lithium Ion  | <any>        | 4                               | 4                                  | battery1 |
		| Alkaline     | <any>        | 6                               | 6                                  | battery2 |
	And in the New Product page I click Continue
	And I should see the Toxicity Characteristic Leaching Procedure (TCLP) Page
	And I set 'Product has had TCLP; Report is available' to: No
	And I set all the metal presence value to: No
	And in the New Product page I click Continue
	And I should see the Electronic Equipment Page
	And I set 'Contains Circuit Board' to: No
	And I set 'Has a LCD or Plasma Display' to: No
	And in the New Product page I click Continue
	#################### Coralie 11/4/2018: Adding in Lithium Battery Transportation section to test
	##Assume this screen is appearing because of selecting a Lithium type battery
	And I should see the Lithium Battery Transportation Page
	And I set 'DOT' to: Fully-regulated dangerous goods: UN3481, Lithium ion batteries packed with equipment, 9
	And I set 'IMDG' to: None of the above/Not intended for shipment under IMDG
	And I set 'IATA' to: Section II
	And I set 'TDG' to: Meets the requirements of TDG special provision 34 to be transported as non-dangerous goods.
	And in the New Product page I click Continue
	#################### Coralie 11/4/2018: Clicking add a retailer step no longer necessary because it automatically opens on clicking continue
	#Select any retailer except for O'Reilly, Sears/K-Mart or Wal-Mart/SAM's CLUB because choosing any of these retailers will cause the Select Vendor drop down to display
	Given the 'Select Retailers' window appears
	Then In the 'Select Retailers' window I select the retailer: Target
	And in the New Product page I click Continue
	Given I click the 'Add UPC' button
	Then I add the following into the UPC Fields
		| Field         | Value        |
		| UPCNumber     | 630509667031 |
		| ContainerType | Aerosol Can  |
		| Size          | 20           |
		| DPCI          | 087-16-0238  |
		| Quantity      |              |
	Given in the New Product page I click Continue
	Then the comments field should appear
	And I enter the following into the comments field: Comments Field Text
	Given in the New Product page I click Continue
	Then The Data Acceptance page should appear
	Given I click the Summary button in the Data Acceptance window
	Then I switch to the Data Summary page
	And I should see the following batteries present:
		| BatteryType | Manufacturer | NumberPerPackage | RequiredToRun | Saved As |
		| Lithium Ion | saved as     | 4                | 4             | battery1 |
		| Alkaline    | saved as     | 6                | 6             | battery2 |
	Then I close the Data Summary tab
	Given I navigate to the home page
	Then I delete the product: TestCase63705

@ScenarioId:484
Scenario: [63724] Add New product - Single Battery Product
	# UPC: 630509616084
	# DPCI: 087-06-680
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I generate a random UPC number and save as: UPC63724
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Nickel Metal Hydride (NiMH) Battery
	Then I save the product information as: TestCase63724
	# Setting Product Characteristics
	Given I call Shared Step 59927 (Primary Physical State > Solid only available – Without Water Solubility question)
	# Setting Additional Product Information
	And I should see the Additional Product Information Page
	And I set 'Product has been classified using OSHA' to: No
	And I set 'Product is shipped directly' to: No
	And I set 'Product is a Retailers Private Label or Brand' to: No
	And I set 'Product is solely for the Retailer's use' to: No
	Given in the New Product page I click Continue
	# Setting Ingredient Information
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Formaldehyde  | 100     | false               | false       |            |
	Given I call Shared Step 104276 (Enter Regulatory Information - TSCA, CEPA, Not Prop 65)
	Given the 'Select Retailers' window appears
	Then In the 'Select Retailers' window I select the retailer: Target
	And in the New Product page I click Continue
	Given I click the 'Add UPC' button
	Then I add the following into the UPC Fields
		| Field         | Value             |
		| UPCNumber     | saved as UPC63724 |
		| ContainerType | Aerosol Can       |
		| Size          | 20                |
		| DPCI          | 087-16-0238       |
		| Quantity      | 12                |
	#Regulatory Documents to Provide - US only _ request authoring - Happy Path
	Given in the New Product page I click Continue
	And I should see the Regulatory Documents to Provide Page
	And I set the radio option in section: Batteries are considered Articles under Global Harmonized Standards. A Safety Data Sheet (SDS) is not required, but may be provided instead of an AIS.  When providing an SDS it must be both U.S. and Canada formats. to: I need an OSHA-Compliant Safety Data Sheet (SDS) authored for this product.
	And I set the radio option in section: WHMIS-compliant Safety Data Sheet, English and French-Canadian to: I need a WHMIS-Compliant bilingual Safety Data Sheet (SDS) authored for this product.
	And I click the browse button for label: Label in both French and English and upload PDF: C:\Dependencies\WERCSmart\testdoc.pdf
	Then I click continue
	#SaDS authoring - additional data
	And I should see the Additional Documents to Provide Page
	Then I click continue
	And I should see the Optional Reports and Documents Available for Purchase Page
	Then I click continue
	And I call Shared Step 64097 - Additional Documents -> Contact Information - Add any Name, address, phone and emergency phone - Happy Path
	And I should see the Safety Data Sheet Authoring - Additional Data (Optional) Page
	And in the Review and Submit tab of the New Product Page for Personal Protection Equipment Recommended I select: Gloves
	And in the Review and Submit tab of the New Product Page for Autoignition I enter: 55
	And in the Review and Submit tab of the New Product Page for Minimum Ignition Energy I enter: 55
	And in the Review and Submit tab of the New Product Page for Viscosity I enter: 4.5
	And in the Review and Submit tab of the New Product Page for Appearance I select: Buff
	And in the Review and Submit tab of the New Product Page for Odor I select: Roasted soy
	And in the Review and Submit tab of the New Product Page for Odor Threshold I select: No data available
	And in the Review and Submit tab of the New Product Page for Partition Coefficient I enter: 5.5
	Given in the New Product page I click Continue
	Then the comments field should appear
	And I enter the following into the comments field: Comments Field Text
	Given in the New Product page I click Continue
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase63724

@ScenarioId:6225
Scenario: [65441] Delete a UPC from the UPC Grid
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given If I see the retail partners page I set all data consent tiers to true for all retailers in the top section
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC65441
	Given I delete all products with UPC Number: saved as UPC65441
	And I click the Register New Product icon in the Navigation Pane
	And I should see the header New Product
	And I Select the Create a New Registration radio button
	And in the New Product page I click Continue
	And I set 'Product Name' to: abrasive
	#And In the Product Type tab of the New Product Page, I enter: Abrasive in the Type of Product select field
	And I set 'Type of Product' to: Abrasive
	And in the New Product page I click Continue
	Then I save the product information as: TestCase65441
	And I set the Primary Physical State to be: Solid
	And I set the Secondary Physical State to be: Granular
	And I set the water mixture question to: Yes
	And I set the water solubility description to: Completely soluble
	Given in the New Product page I click Continue
	# Setting Additional Product Information
	And I should see the Additional Product Information Page
	And In the Additional Information Page the check box for: United States should be: checked
	And I set 'Product has been classified using OSHA' to: No
	And I set 'Product is shipped directly' to: No
	# CA Cleaning question commented out, uncomment when CA Cleaning is re-added
	#And I set 'California's Cleaning Product' to: No
	And I set 'Product is a Retailers Private Label or Brand' to: No
	And I set 'Product is solely for the Retailer's use' to: No
	Given in the New Product page I click Continue
	#Enter ingredients
	Then I add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Formaldehyde  | 100     | false               | false       |            |
	Given in the New Product page I click Continue
	#Enter regulatory information - not prop 65
	And For 'U.S. Toxic Substances Control Act (TSCA) status' I select: Compliant
	And I set 'Prop65' to: No
	And in the New Product page I click Continue
	#Transportation details 1 - not regulated - continue - happy path
	And I should see the Transportation Details 1 Page
	And in the Product Characteristics tab of the New Product Page, for Product is Regulated for Transport I select: Not Regulated
	#And in the Product Characteristics tab of the New Product Page, for DOT Exceptions I select: 173.120(a)(2), 173.120(a)(3)
	#And I set the Other DOT Exception field to: None
	And in the New Product page I click Continue
	#Retailer association - select a retailer - continue-happy path
	Given the 'Select Retailers' window appears
	Then In the 'Select Retailers' window I select the retailer: Target
	And in the New Product page I click Continue
	#Enter UPC
	Given I click the 'Add UPC' button
	Then I add the following into the UPC Fields
		| Field         | Value             |
		| UPCNumber     | saved as UPC65441 |
		| ContainerType | Aerosol Can       |
		| Size          | 20                |
		| DPCI          | 087-16-0238       |
	And in the New Product page I click Continue
	#Navigate back to UPC screen by click the reipient and upc details tab in the header
	Given In the New Product page I click tab: Recipient and UPC Details
	Given I click the page heading: Universal Product Code (UPC)
	And I should see the Universal Product Code Page
	And I delete UPC: saved as UPC65441
	Then In the list of UPCs I should not see UPC: saved as UPC65441
	#delete product
	Given I navigate to the home page
	Then I delete the product: TestCase65441

@ScenarioId:485
Scenario: [65392] Ecologo Readiness - Question wording and validation of response
	Given I Login into WERCSmart Portal - Admin Role - WERCs Premium Subscription Account
	Given If I see the retail partners page I set all data consent tiers to true for all retailers in the top section
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Floor Wax Stripper (Light or Medium Build-Up)
	Then I save the product information as: TestCase65392
	And I call Shared Step 57514 (Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path)
	Given I call Shared Step 57401 (Additional Product Information - US only - No GHS, Not Direct Ship, Not PLP, Not GNFR > Continue - Happy Path)
	Then I add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Formaldehyde  | 100     | false               | false       |            |
	Given in the New Product page I click Continue
	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given I call Shared Step 57507 (Transportation Details 1- Not Regulated - Continue - Happy Path)
	Given I call Shared Step 62710 (Confirm VOC OTC/CARB heading and select No to FIRST QUESTION ONLY - Happy Path)
	Given I call Shared Step 60515 (VOC - Dilution - Yes to ratio - enter any values > Continue - Happy Path)
	Given I click continue
	Given The ECOLOGO Readiness page should be loaded
	Given I confirm the ECOLOGO Readiness Assessment question is displayed
	Given the ECOLOGO Readiness Assessment question should show the following options:
	| Option           |
	| Yes              |
	| Not at this time |
	Given I click continue
	Then I should see an error message: This is a required field.
	Given I set ECOLOGO Readiness Assessment to: Yes
	And I should not see any error messages
	Given I set ECOLOGO Readiness Assessment to: Not at this time
	Then I click continue
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	Given I navigate to the home page
	Then I delete the product: TestCase65392


@tfs_design
Scenario: [67661] Verify Canada SDS on the Optional Reports and Documents Available for Purchase screen
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	# Checking that the test will run correctly by handling extra screens / removing existing products
	Given If I see the retail partners page I set all data consent tiers to true for all retailers in the top section
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC67661
	Given I delete all products with UPC Number: saved as UPC67661
	# New Product Page
	And I click the Register New Product icon in the Navigation Pane
	And I should see the New Product Page
	And I set the Select the type of product to create option to: Create a New Registration
	And in the New Product page I click Continue
	# The Product Page
	And I should see the The Product Page
	And I set the Product Name option to: Deodorant - Non-aerosol
	#And In the Product Type tab of the New Product Page, I enter: Deodorant - Non-aerosol in the Type of Product select field
	And I set 'Type of Product' to: Deodorant - Non-aerosol
	And in the New Product page I click Continue
	# Product Characteristics Page
	And I should see the Product Characteristics Page
	Then I save the product information as: TestCase67661
	And in the New Product page I click Continue
	And Primary Physical State should be showing the error messages: This is a required field.
	And I set the Primary Physical State option to: Solid
	And I set the Secondary Physical State option to: Solid
	And I set the When mixed with an equal amount of water option to: No
	And I set the Select the best Water Solubility description option to: Very soluble
	And in the New Product page I click Continue
	# Additional Product Information Page
	And In the Additional Information Page the check box for: United States should be: checked
	And I set the Product has been classified using OSHA (US) option to: No
	And I set the Product is shipped directly by supplier to the consumer option to: No
	And I set the Product is a Retailer's Private Label or Brand option to: No
	And I set the Product is sold to the Retailer solely for the Retailer's use option to: No
	And in the New Product page I click Continue
	# Ingredients Page
	And I should see the Ingredients Page
	Then I add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Formaldehyde  | 100     | false               | false       |            |
	Given in the New Product page I click Continue
	# Regulatory 1 Page Details
	And I should see the Regulatory Information 1 Page
	And I set the U.S. Toxic Substances Control Act (TSCA) status option to: Compliant
	And I set the Product, including container and/or packaging, contains a chemical on California's Prop 65 list option to: No
	Given in the New Product page I click Continue
	# Regulatory 3 Page Details
	And I should see the Regulatory Information 3 Page
	And I set the below options for field: Refer to your Product Label
		| Option            |
		| None of the Above |
	Given in the New Product page I click Continue
	# Transportation Details 1 Page
	And I should see the Transportation Details 1 Page
	And I set the Product is Regulated for Transport option to: Yes
	And I set the below options for field: Select all modes of transport that you've classified the product for
		| Option                         |
		| DOT                            |
		| Shipping with limited quantity |
	Given in the New Product page I click Continue
	# U. S. Department of Transportation (DOT) Classification Page
	Then I should see the U. S. Department of Transportation (DOT) Classification Page
	And I set the UN Number field to: UN1944
	And I set the Proper Shipping Name field to: Matches, safety
	And I set the Technical Name (if applicable) field to: My Safe Product
	And I set the Hazard Class (select) field to: 4.1
	And I set the Packing Group (select) field to: III
	Given in the New Product page I click Continue
	# Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB) Page
	Then The VOC OTC CARB page should be loaded
	And I set 'Product has been granted an Alternative Control' to: No
	And I set the HVOC (high volatile organic compound) content field to: 200
	And I set the MVOC (microbial volatile organic compound) content field to: 200
	Given in the New Product page I click Continue
	# Volatile Organic Compound Summary Page
	Then I should see the Volatile Organic Compound Summary Page
	Given In the VOC Acceptance section I agree
	Given in the New Product page I click Continue
	# Retailers Page
	Then In the 'Select Retailers' window I select the retailer: Walgreens
	And I should see the Retailer Page
	Given in the New Product page I click Continue
	# Universal Product Code (UPC) Page
	And I should see the Universal Product Code (UPC) Page
	Given I click the 'Add UPC' button
	Then I add the following into the UPC Fields
		| Field         | Value             |
		| UPCNumber     | saved as UPC67661 |
		| ContainerType | Glass Container   |
		| Size          | 20                |
	And in the New Product page I click Continue
	# Regulatory Documents to Provide
	And I should see the Regulatory Documents to Provide Page
	And I set the OSHA-compliant Safety Data Sheet, English field to: Request to author
	Then in the New Product page I click Continue
	# Additional Documents to Provide Page
	And I should see the Additional Documents to Provide Page
	And I click the browse button for label: Product Label and upload PDF: C:\Dependencies\WERCSmart\testdoc.pdf
	Then in the New Product page I click Continue
	# Optional Reports and Documents Available for Purchase Page
	And I should see the Optional Reports and Documents Available for Purchase Page
	And I purchase the following additional documents:
		| Document Name  | Language      |
		| Canada GHS SDS | English (U.S) |
	Then in the New Product page I click Continue
	# Additional Documents -> Contact Information Page
	And I should see the Additional Documents -> Contact Information Page
	And I set the Manufacturer Name field to: Manufacturer
	And I set the Address field to: Address
	And I set the Phone field to: Phone
	And I set the Emergency Phone field to: EmergencyPhone
	Then in the New Product page I click Continue
	# Safety Data Sheet Authoring - Additional Data (Optional) Page
	And I should see the Safety Data Sheet Authoring - Additional Data (Optional) Page
	And I set the below options for field: Personal Protection Equipment Recommended
		| Option |
		| Mask   |
	And I set the Autoignition Temperature (°C) field to: 20
	And I set the Minimum Ignition Energy (mJ) field to: 20
	And I set the Viscosity field to: 20
	And I set the Appearance field to: Brown
	And I set the Odor field to: Banana
	And I set the Odor Threshold field to: Not applicable
	And I set the Partition Coefficient field to: 20
	Then in the New Product page I click Continue
	# Optional Reports and Documents Available for Purchase Page
	Then I click the page heading: Optional Reports and Documents Available for Purchase
	And the following additional documents should be showing as selected:
		| Document Name  | Language      |
		| Canada GHS SDS | English (U.S) |
	# Delete the prodiuct created to cleanup
	Given I navigate to the home page
	Then I delete the product: TestCase67661

@jacob
@tfs_design
@ScenarioId:482
Scenario: [105352] Product Comments screen Max input length
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given If I see the retail partners page I set all data consent tiers to true for all retailers in the top section
	Then The home screen should load
	Given I delete all products with UPC Number: 630509667031
	And I click the Register New Product icon in the Navigation Pane
	And I should see the header New Product
	And I Select the Create a New Registration radio button
	And in the New Product page I click Continue
	And I set 'Product Name' to: Answering Machine, Battery Included
	And I set 'Type of Product' to: Answering Machine, Battery Included
	And in the New Product page I click Continue
	Then I save the product information as: TestCase105352
	And I should see the Additional Product Information Page
	And In the Additional Information Page the check box for: United States should be: checked
	And I set 'Product is shipped directly' to: No
	And I set 'Product is a Retailers Private Label or Brand' to: No
	And I set 'Product is solely for the Retailer's use' to: No
	And in the New Product page I click Continue
	And For 'U.S. Toxic Substances Control Act (TSCA) status' I select: Compliant
	And I set 'Prop65' to: No
	And in the New Product page I click Continue
	And I should see the Product Includes Battery Page
	And For 'Indicate how battery is packaged' I select: The battery is shipped with but not included in my product.
	And I add the following batteries:
		| Battery Type | Manufacturer | Number of batteries per package | How many batteries required to run | Saved As |
		| Lithium Ion  | <any>        | 4                               | 4                                  | battery1 |
		| Alkaline     | <any>        | 6                               | 6                                  | battery2 |
	And in the New Product page I click Continue
	And I should see the Toxicity Characteristic Leaching Procedure (TCLP) Page
	And I set 'Product has had TCLP; Report is available' to: No
	And I set all the metal presence value to: No
	And in the New Product page I click Continue
	And I should see the Electronic Equipment Page
	And I set 'Contains Circuit Board' to: No
	And I set 'Has a LCD or Plasma Display' to: No
	And in the New Product page I click Continue
	And I should see the Lithium Battery Transportation Page
	And I set 'DOT' to: Fully-regulated dangerous goods: UN3481, Lithium ion batteries packed with equipment, 9
	And I set 'IMDG' to: None of the above/Not intended for shipment under IMDG
	And I set 'IATA' to: Section II
	And I set 'TDG' to: Meets the requirements of TDG special provision 34 to be transported as non-dangerous goods.
	And in the New Product page I click Continue
	Given the 'Select Retailers' window appears
	Then In the 'Select Retailers' window I select the retailer: Target
	And in the New Product page I click Continue
	Given I click the 'Add UPC' button
	Then I add the following into the UPC Fields
		| Field         | Value        |
		| UPCNumber     | 630509667031 |
		| ContainerType | Aerosol Can  |
		| Size          | 20           |
		| DPCI          | 087-16-0238  |
		| Quantity      |              |
	Given in the New Product page I click Continue
	Then the comments field should appear
	And I enter the following into the comments field: 300 character test: 12345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
	And in the New Product page I click Continue
	Then I check the Comment error message shows: This field exceeds max length (500).
	Then I enter the following into the comments field: 201 character test: 1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901	And in the New Product page I click Continue
	Then I check the Comment error message shows: This field exceeds max length (200).
	Then I enter the following into the comments field: 200 character test: 123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
	Then in the New Product page I click Continue
	Then The Data Acceptance page should appear
	Given I click the Summary button in the Data Acceptance window
	Then I switch to the Data Summary page
	And I should see the following batteries present:
		| BatteryType | Manufacturer | NumberPerPackage | RequiredToRun | Saved As |
		| Lithium Ion | saved as     | 4                | 4             | battery1 |
		| Alkaline    | saved as     | 6                | 6             | battery2 |
	Then I close the Data Summary tab
	Given I navigate to the home page
	Then I delete the product: TestCase105352

	@ScenarioId:6627
Scenario: [122123] Sustainability Screen - Descriptions, Icons and Indicators
	Given I generate a random UPC number and save as: UPC79428
	And I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	And I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Raw Material
	Then I save the product information as: TestCase79428
	Given I call Shared Step 79431 (Ingredients - Add FLAVOR component, Publicly Disclosed = Yes, Select Public Name) and save ingredients as: Ing79428Flav
		| CASNumber  | ComponentName | Percentage |
		| RR-38669-6 | FLAVORS       | 35         |
	And I call Shared Step 79436 (Ingredients - Add FRAGRANCE component, Publicly Disclosed = Yes,  Select Public Name) and save ingredient as: Ing79428Frag
		| CASNumber | ComponentName                                                                  | Percentage |
		| FRAGRANCE | Fragrance - Awapuhi - Skin sens 1, Repro 2, Aquatic acute 2, Aquatic chronic 2 | 35         |
	And I call Shared Step 79490 (Ingredients - Add non-generic component - Public Disclosed = Yes, select Name Continue) and save ingredient as: Ing79428NG
		| CASNumber | ComponentName | Percentage |
		| 7726-95-6   | 6Bromine  | 30         |
	Then in the Ingredients page I click Continue 
	And I call Shared Step 79507 (Formulation > 3rd Party - Accept formulation - Grant Tier 2 - Continue)
	And I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	And I call Shared Step 60932 (Regulatory Information 2 - Microbeads - No)
	And I should see the Additional Documents to Provide Page
	And I call Shared Step 59042 (Browse for File > select > click Open - Happy Path) for document type: IFRA Certificate (Perfumery Products) and file: C:\Dependencies\WERCSmart\testdoc.pdf
	And I call Shared Step 59042 (Browse for File > select > click Open - Happy Path) for document type: GRAS Certificate (Flavor Products) and file: C:\Dependencies\WERCSmart\testdoc.pdf
	Then in the Additional documents page I click Continue
	Then in the Formulation Names page I click Continue
	And I call Shared Step 58610 (Confirm Restrict Use - Restrict)
	And I should see the Sustainability Page
	And In the New Product page I should be on tab: Review and Submit
	Then I check if the logo is displayed for the following retailers
	| Retailer	    |
	| Canadian Tire |
	| Costco        |
	| CVS           |
	| Dollar Tree   |
	| Family Dollar |
	| Target        |
	| Walgreens     |
	| Walmart       |

	Then I check if a checkmark image is displayed above the following retailers
	| Retailer      |
	| Canadian Tire |
	| Costco        |
	| CVS           |
	| Dollar Tree   |
	| Family Dollar |
	| Target        |
	

	Then I check if a yellow triangle image is displayed above the following retailers
	| Retailer	    |
	| Walgreens     |
	| Walmart       |

	Then I check if a 'Scope' button is displayed below the following retailers
	| Retailer	    |
	| Canadian Tire |
	| Costco        |
	| CVS           |
	| Dollar Tree   |
	| Family Dollar |
	| Target        |
	| Walgreens     |
	| Walmart       |


	#Update below to take retailer?
	Then I hover over the yellow triangle image for retailer: Walgreens
	Then I check if the text displayed over the yellow triangle image matches the following text: The following ingredients are on this WERCSmart Recipient's screening list for chemicals of concern. If your customer sells products within the Scope of this Recipient's program, it may impact your customer's relationship with the Retailer.
	Then I hover over the yellow triangle image for retailer: Walmart
	Then I check if the text displayed over the yellow triangle image matches the following text: The following ingredients are on this WERCSmart Recipient's screening list for chemicals of concern. If your customer sells products within the Scope of this Recipient's program, it may impact your customer's relationship with the Retailer.


	Then I check if the retailer modal is displayed for the following retailer: CO
	Then I check if the retailer modal is displaying the following text: Costco requests suppliers of Cleaning, Health & Beauty, Automotive Care, and Lawn & Garden products to grant Tier 2.1 and Tier 2.2 consent.
	Then I close the retailer modal

	Then I check if the retailer modal is displayed for the following retailer: CV
	Then I check if the retailer modal is displaying the following text: CVS requires suppliers of formulated products in the following categories to grant Tier 2.1, Tier 2.2, Tier 3 and Tier 4.1 permissions: Artists/Hobby, Automotive Care, Cleaning Supplies, Health & Beauty, Home Improvement, Lawn and Garden, Miscellaneous, Nutritional Supplements, Over-the-Counter (OTC), Pet Care, Photography, Sporting Goods, Stationery and Pharmacy
	Then I close the retailer modal

	Then I check if the retailer modal is displayed for the following retailer: DT
	Then I check if the retailer modal is displaying the following text: Dollar Tree requires suppliers of formulated products to grant Tier 2.1 and Tier 2.2 permissions.
	Then I close the retailer modal

	Then I check if the retailer modal is displayed for the following retailer: WM
	Then I check if the retailer modal is displaying the following text: Walmart requires suppliers of private label formulated products in the following categories to grant Tier 2.1, Tier 2.2 and Tier 4.2 permissions: Artists/Hobby, Automotive Care, Battery-Containing Products, Cleaning Supplies, Grocery, Health & Beauty, Home Improvement, Kit, Lawn and Garden, Miscellaneous, Nutritional Supplements, OTC - Over the Counter, Pet Care, Pharmacy, Sporting Goods, Stationery and Toys.
	Then I close the retailer modal
	Then in the Sustainability Information page I click Continue
	And I call Shared Step 57883 (Comments - Happy Path) and enter the comment: test


	@ScenarioId:6674
	Scenario: [122261] Sustainability Screen - Consent Not Granted Message
	Given I generate a random UPC number and save as: UPC79428
	And I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	And I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Raw Material
	Then I save the product information as: TestCase79428
	Given I call Shared Step 79431 (Ingredients - Add FLAVOR component, Publicly Disclosed = Yes, Select Public Name) and save ingredients as: Ing79428Flav
		| CASNumber  | ComponentName | Percentage |
		| RR-38669-6 | FLAVORS       | 35         |
	And I call Shared Step 79436 (Ingredients - Add FRAGRANCE component, Publicly Disclosed = Yes,  Select Public Name) and save ingredient as: Ing79428Frag
		| CASNumber | ComponentName                                                                  | Percentage |
		| FRAGRANCE | Fragrance - Awapuhi - Skin sens 1, Repro 2, Aquatic acute 2, Aquatic chronic 2 | 35         |
	And I call Shared Step 79490 (Ingredients - Add non-generic component - Public Disclosed = Yes, select Name Continue) and save ingredient as: Ing79428NG
		| CASNumber | ComponentName | Percentage |
		| 50-00-0   | Formaldehyde  | 30         |
	Then in the Ingredients page I click Continue 
	Then The Formulation 3rd Party Step is shown
    Then I call Shared Step 79491 (Formulation > 3rd Party - Accept formulation - Decline Tier 4.1 - Continue)
	When I click continue
	And I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	And I call Shared Step 60932 (Regulatory Information 2 - Microbeads - No)
	And I should see the Additional Documents to Provide Page
	And I call Shared Step 59042 (Browse for File > select > click Open - Happy Path) for document type: IFRA Certificate (Perfumery Products) and file: C:\Dependencies\WERCSmart\testdoc.pdf
	And I call Shared Step 59042 (Browse for File > select > click Open - Happy Path) for document type: GRAS Certificate (Flavor Products) and file: C:\Dependencies\WERCSmart\testdoc.pdf
	Then in the Additional documents page I click Continue
	When I click continue
	And I call Shared Step 58610 (Confirm Restrict Use - Restrict)
	And I should see the Sustainability Page
	Then I check if alert message displays the following text: You have not granted consent to requested Data Use Tiers for this component.  Your customer's products will not be fully screened and evaluated by any relevant WERCSmart Recipient chemical policy or product qualification program.  The results for each program is displayed above.  If you wish to update your consents for this component, please go to Product Characteristics / Formulation > Third-Party
	When I click continue

