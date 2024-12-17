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
@UPC
@NewProduct
@run_ProductRegistration
@StepsPrototype
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:TheProduct
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:ProductInformation
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:NewProduct
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:ProductInformation
@PhysicalAndChemicalProp
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:InventoryStatusProp65
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:RegulatoryDocumentsToProvide
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:OptionalComments
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:DataAcceptance
@Ingredients
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:Retailer
@RegulatoryInformation3
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:TransportationDetails1
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:Formulation3rdParty
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:InventoryStatusProp65
@Product:WERCSmart_Account:Distributor_Page:NewProducts_Tab:ProductCharacteristics_Section:RegulatoryInformation2
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:AdditionalDocumentsToProvide
@Product:WERCSmart_Account:Distributor_Page:NewProducts_Tab:ProductCharacteristics_Section:RestrictUse
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:Sustainability
Feature: Product Registration

@tfs_design
@ignore
#Non-important scenario - Philip
@TestCase:130389
Scenario: [130389] Demo Scenario
	#Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I log in with the account saved in TReVor as: ProductAccount
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Given in the New Product page I click Continue
	Then I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
	Then I save product Product to context as TestCase

#Background:
#Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
#Given If I see the retail partners page I set all data consent tiers to true for all retailers in the top section
#Then The home screen should load

#Removed from regression 2024/04
@ignore
@ScenarioId:486
Scenario: Create a new product
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given If I see the retail partners page I set all data consent tiers to true for all retailers in the top section
	Then The home screen should load
	Then I click the Register New Product icon in the Navigation Pane
	And I should see the header New Product
	Given I click the Register New Product icon in the Navigation Pane
	When I click continue

@ignore
@TestCase:63705
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
	And I set 'Type of Product' to: Answering Machine, Battery Included
	And in the New Product page I click Continue
	Then I save the product information as: TestCase63705
	# Shared step 63704
	Given I should see the Product Information Page
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page, I click Continue

	And For 'U.S. Toxic Substances Control Act (TSCA) status' I select: Compliant
	And I set 'Prop65' to: No
	And in the New Product page I click Continue
	And I should see the Product Includes Battery Page
	And For 'Indicate how battery is packaged' I select: The battery is shipped with but not included in my product.
	And I add the following batteries:
		| Battery Type | Manufacturer | Quantity of Batteries per Package | Quantity of Batteries to Operate Product | Saved As |
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
	Given I click the 'Add' button
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

@ignore
@TestCase:63724
Scenario: [63724] Add New product - Single Battery Product
	# UPC: 630509616084
	# DPCI: 087-06-680
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I generate a random UPC number and save as: UPC63724
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Given in the New Product page I click Continue
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Nickel Metal Hydride (NiMH) Battery
	Then I save the product information as: TestCase63724
	# Setting Product Information
	And I should see the Product Information Page
	And I set 'Product has been classified using OSHA' to: No
	And I set 'Product is shipped directly' to: No
	And I set 'Product is a Retailers Private Label or Brand' to: No
	And I set 'Product is solely for the Retailer's use' to: No
	Given in the New Product page I click Continue
	# Setting Physical and Chemical Properties
	Given I call Shared Step 59927 (Primary Physical State > Solid only available – Without Water Solubility question)
	# Setting Ingredient Information
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Formaldehyde  | 100     | false               | false       |            |
	Given I call Shared Step 145355 Formulation > Batteries - Select Granted - Continue
	Given I call Shared Step 104276 (Enter Regulatory Information - TSCA, CEPA, Not Prop 65)
	Given the 'Select Retailers' window appears
	Then In the 'Select Retailers' window I select the retailer: Target
	And in the New Product page I click Continue
	Given I click the 'Add' button
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
	And I click the browse button for label: Label in both French and English and upload PDF: UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf
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

@ignore
@TestCase:65441
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
	# Setting Product Information
	And I should see the Product Information Page
	And In the Information Page the check box for: United States should be: checked
	And I set 'Product has been classified using OSHA' to: No
	And I set 'Product is shipped directly' to: No
	And I set 'California's Cleaning Product' to: No
	# CA Cleaning question commented out, uncomment when CA Cleaning is re-added
	#And I set 'California's Cleaning Product' to: No
	And I set 'Product is a Retailers Private Label or Brand' to: No
	And I set 'Product is solely for the Retailer's use' to: No
	Given in the New Product page I click Continue
	And I set the Primary Physical State to be: Solid
	And I set the Secondary Physical State to be: Granular
	And I set the water mixture question to: Yes
	And I set the water solubility description to: Dispersible
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
	#And I set the Other DOT Exception field to: None
	And in the New Product page I click Continue
	#Retailer association - select a retailer - continue-happy path
	Given the 'Select Retailers' window appears
	Then In the 'Select Retailers' window I select the retailer: Target
	And in the New Product page I click Continue
	#Enter UPC
	Given I click the 'Add' button
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

@ignore
@TestCase:65392
Scenario: [65392] Ecologo Readiness - Question wording and validation of response
	Given I Login into WERCSmart Portal - Admin Role - WERCs Premium Subscription Account
	Given If I see the retail partners page I set all data consent tiers to true for all retailers in the top section
	Then The home screen should load
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Given in the New Product page I click Continue
	Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Floor Wax Stripper (Light or Medium Build-Up)
	Then I save the product information as: TestCase65392
	#Given I call Shared Step 57401 (Product Information - US only - No GHS, Not Direct Ship, Not PLP, Not GNFR > Continue - Happy Path)
	Given I should see the Product Information Page
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue
	#Given I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' confirm option is selected: Liquid
	And In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Liquid
	And In the Physical and Chemical Properties Section, for section: 'Relative Density' enter text: 120
	Then In the Physical and Chemical Properties Section, set the option in section: 'Relative Density' to: g/ml (grams per milliliter)
	And In the Physical and Chemical Properties Section, for section: 'pH' enter text: 8
	And In the Physical and Chemical Properties Section, for section: 'Boiling Point (in Celsius)' enter text: 100
	Then In the Physical and Chemical Properties Section, for section: 'Flash Point (in Celsius)' enter text: 61
	Then In the Physical and Chemical Properties Section, set the option in section: 'Flash Point Testing Method Used' to: Not applicable/available
	And In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
	Then in the Physical and Chemical Properties page, I click Continue
	Then I add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Formaldehyde  | 100     | false               | false       |            |
	Given in the New Product page I click Continue
	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)

#	Given I call Shared Step 57507 (Transportation Details 1- Not Regulated - Continue - Happy Path)
	Then I should be on the Transportation Details 1 Page
	And In the Transportation Details 1 Section, set the option in section: 'Product is Regulated for Transport': to: Not Regulated
	Then in the Transportation Details 1 page, I click Continue

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
@ignore
@TestCase:67661
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
	# Product Information Page
	And In the Information Page the check box for: United States should be: checked
	And I set the Product has been classified using OSHA (US) option to: No
	And I set the Product is shipped directly by supplier to the consumer option to: No
	And I set the Product is a Retailer's Private Label or Brand option to: No
	And I set the Product is sold to the Retailer solely for the Retailer's use option to: No
	And in the New Product page I click Continue
	# Physical and Chemical Properties Page
	And I should see the Physical and Chemical Properties Page
	Then I save the product information as: TestCase67661
	And in the New Product page I click Continue
	And Primary Physical State should be showing the error messages: This is a required field.
	And I set the Primary Physical State option to: Solid
	And I set the Secondary Physical State option to: Solid
	And I set the When mixed with an equal amount of water option to: No
	And I set the Select the best Water Solubility description option to: Dispersible
	And in the New Product page I click Continue
# Ingredients Page
	And I should see the Ingredients Page
	Then I add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Formaldehyde  | 100     | false               | false       |            |
	Given in the New Product page I click Continue
	# Regulatory 1 Page Details
	And I should see the Waste Classification Data Page
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
	# U.S. Department of Transportation (DOT) Classification Page
	Then I should see the U.S. Department of Transportation (DOT) Classification Page
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
	And I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page
	Given I click the 'Add' button
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
	And I click the browse button for label: Product Label and upload PDF: UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf
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
@ignore
@TestCase:105352
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
	And I should see the Product Information Page
	And In the Information Page the check box for: United States should be: checked
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
		| Battery Type | Manufacturer | Quantity of Batteries per Package | Quantity of Batteries to Operate Product | Saved As |
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
	Given I click the 'Add' button
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
	Then I close the Data Summary Tab
	Given I navigate to the home page
	Then I delete the product: TestCase105352

@ignore
@TestCase:122123
Scenario: [122123] Sustainability Screen - Descriptions, Icons and Indicators
	Given I generate a random UPC number and save as: UPC79428
	#Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I log in with the account saved in TReVor as: ProductAccount
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

	Then In the popup view with the following title: Product Contains Ingredients Typical of a Pesticide I confirm I see the following statement in the popup view: If you need to revise your selection for Pesticides, please use the Product Type tab and go to the Additional Product Information section to make your revisions. Or, revise your ingredient information, ensuring accuracy. Should all indications and ingredients be correct and the product is not a pesticide, please indicate below.
	Then I confirm I see a checkbox in the popup view with the following text: The Product Type, Pest Selection, and Ingredients listed are accurate.
	Then I confirm I check the checkbox in the popup view with the following text: The Product Type, Pest Selection, and Ingredients listed are accurate.
	Then In the popup view with the following title: Product Contains Ingredients Typical of a Pesticide I click the Confirm button
	And I call Shared Step 79507 (Formulation > 3rd Party - Accept formulation - Grant Tier 2 - Continue)
	#And I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I should see the Inventory Status, Prop 65 (US) Page
	Then In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	Then In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page I click Continue

	And I call Shared Step 60932 (Regulatory Information 2 - Microbeads - No)
	And I should see the Additional Documents to Provide Page
	And I call Shared Step 59042 (Browse for File > select > click Open - Happy Path) for document type: IFRA Certificate (Perfumery Products) and file: UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf
	And I call Shared Step 59042 (Browse for File > select > click Open - Happy Path) for document type: GRAS Certificate (Flavor Products) and file: UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf
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
	#And I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue


@TestCase:122261
	Scenario: [122261] Sustainability Screen - Consent Not Granted Message

	Given I generate a random UPC number and save as: UPC122261

	#Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I log in with the account saved in TReVor as: ProductAccount

	#And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Then in the New Product page, I click Continue

	#And I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Raw Material
	Then I should be on the The Product Page
	And In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Mixture, Blend, Formula, Polymer or Solution from Third (3rd, 3d) Party_#122261
	And In the Product Section, set the option in section: 'Type of Product (select)' to: Mixture, Blend, Formula, Polymer or Solution from Third (3rd, 3d) Party
	Then in the The Product page, I click Continue

	Then I save the product information as: TestCase122261

	#Given I call Shared Step 79431 (Ingredients - Add FLAVOR component, Publicly Disclosed = Yes, Select Public Name) and save ingredients as: Ing79428Flav
	#	| CASNumber  | ComponentName | Percentage |
	#	| RR-38669-6 | FLAVORS       | 35         |
	#And I call Shared Step 79436 (Ingredients - Add FRAGRANCE component, Publicly Disclosed = Yes,  Select Public Name) and save ingredient as: Ing79428Frag
	#	| CASNumber | ComponentName                                                                  | Percentage |
	#	| FRAGRANCE | Fragrance - Awapuhi - Skin sens 1, Repro 2, Aquatic acute 2, Aquatic chronic 2 | 35         |
	#And I call Shared Step 79490 (Ingredients - Add non-generic component - Public Disclosed = Yes, select Name Continue) and save ingredient as: Ing79428NG
	#	| CASNumber | ComponentName | Percentage |
	#	| 50-00-0   | Formaldehyde  | 30         |
	Then I should be on the Ingredients Page
	And In the Ingredients section, add the following ingredients:
	| SearchType | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	| CAS number | RR-38669-6  | 50      | True                | False         | FLAVORS     |
	| CAS number | FRAGRANCE   | 50      | True                | False         | Fragrance   |
	Then in the Ingredients page, I click Continue

#    Then I call Shared Step 79507 (Formulation > 3rd Party - Accept formulation - Grant Tier 2 - Continue)
	Then I should be on the Formulation > 3rd Party Page
	And In the Formulation > 3rdParty Section, set the radio option in section: 'By clicking Accept, I certify the formulation information entered is complete and accurate': to: Accept
	And In the Formulation > 3rdParty Section, set the radio option in section: 'Consent to Tier 2.1, 2.2, 4.2 Data Uses': to: Declined
	Then in the Formulation > 3rd Party page, I click Continue

	#And I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I should be on the Inventory Status, Prop 65 (US) Page
	Then In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	Then In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page I click Continue

	#And I call Shared Step 60932 (Regulatory Information 2 - Microbeads - No)
	Then I should be on the Regulatory Information 2 Page
	And In the Regulatory Information 2 Section, set the option in section: 'Product contains microbeads' to: No
	Then in the Regulatory Information 2 page, I click Continue

	Then I should be on the Transportation Details 1 Page
	And In the Transportation Details 1 Section, set the option in section: 'Product is Regulated for Transport': to: No, due to an exemption or exception
	And In the Transportation Details 1 Section, set the option in section: 'Please select DOT Exceptions if applicable?': to: 173.120(b)(3):  Combustible liquid that does not sustain combustion
	Then in the Transportation Details 1 page, I click Continue

	#And I call Shared Step 59042 (Browse for File > select > click Open - Happy Path) for document type: IFRA Certificate (Perfumery Products) and file: UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf
	Then I should be on the Additional Documents to Provide Page
	And In the Additional Documents to Provide, upload PDF document to International Fragrance Association (IFRA) field
	And In the Additional Documents to Provide, upload PDF document to Generally Recognized as Safe (GRAS) field
	Then in the Additional Documents to Provide page, I click Continue

	Then in the Formulation Names page, I click Continue

	#Given I call Shared Step 58610 (Confirm Restrict Use - Restrict)
	Then I should be on the Restrict Use Page
	And In the Restrict Use Section, set the option in section: 'Do you want to restrict searchable access to your registered formula?': to: Restrict
	And In the Restrict Use Section, I enter the text of Access Code field to: 12345678
	Then in the Restrict Use page, I click Continue

	Then I should be on the Sustainability Page
	And In the Sustainability section, the following alert message should be displayed: You have not granted consent to requested Data Use Tiers for this component. Your customer's products will not be fully screened and evaluated by any relevant WERCSmart Recipient chemical policy or product qualification program. The results for each program is displayed above. If you wish to update your consents for this component, please go to Product Characteristics / Formulation > Third-Party.
	Then in the Sustainability page, I click Continue

	#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase59280
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase122261

@ignore
@TestCase:128754
Scenario: [128754] BCP Product - Family Dollar and Dollar Tree Retailers Available for selection
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC128754
	Given I delete all products with UPC Number: saved as UPC128754
	Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Camera w/Battery
	Then I save the product information as: TestCase128754
	Given I call Shared Step 70393 (Product Information - With marketed for use by a Child - Direct Ship - Private Label questions only)
	#And I call Shared Step 132370 (Waste Classification Data - TSCA (Random) - Prop 65 (No) - Continue - Happy Path)
	Given I should see the Inventory Status, Prop 65 (US) Page
	Then In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	Then In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page I click Continue

	Given I call Shared Step 48367 (Product Includes Battery > any type)
		| Battery Type | Quantity of Batteries to Operate Product | Manufacturer | Quantity of Batteries per Package |
		| Alkaline     | 6                                        | <any>        | 6                                 |
	Given I call Shared Step 48369 (Toxicity Characteristics Leaching Procedure (TCLP) - No to ALL With Copper)
	And I call Shared Step 58189 (Answer Electronic Equipment questions - With Cathode Ray - No to all)
	Given I select the following retailers in the Select Retailers popup list view:
		| Retailer                                                 |
		| Dollar Tree Stores, Inc. / Greenbrier International, Inc |
		| Family Dollar                                            |
		| No Retailer/No UPC Product                               |
	Then I click Done on Select Retailers window
	Then I confirm the following retailers are showing in the Retailer page
		| Retailer                                                 |
		| Dollar Tree Stores, Inc. / Greenbrier International, Inc |
		| Family Dollar                                            |
		| No Retailer/No UPC Product                               |
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase128754


@TestCase:127767
Scenario: [127767] Register a Cleaning Supplies - Bleach Product Type for a verification of the Products in Scope Report for Bed Bath and Beyond
	Then I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Given in the New Product page I click Continue
	Given I generate a random UPC number and save as: UPC804879551225
	Then I call Shared Step 57561a (The Product - Enter Product Name: Cleaning Supplies Product for BBB and select Type of Product): Bleach
	Given I call Shared Step 105379 Product Information - US, Pesticide No, No OSHA, No DSV, No PL, No GNFR Without Child question
	Given I set the Primary Physical State option to: Liquid
	And I check the 'I do not have exact' checkbox for field: Flash Point (in Celsius)
	And I check the 'I do not have exact' checkbox for field: Boiling Point (in Celsius)
	Given I set the Secondary Physical State option to: Liquid
	Given I set the Relative Density option to: 0.1
	Given I set the pH option to: 11.5
	Given I set the Boiling Point (in Celsius) option to: Not tested/Unknown
	Given I set the Flash Point (in Celsius) option to: None, No Flash Point
	Given I set the Select the best Water Solubility description option to: Soluble in water
	Given I click continue
	Given I click continue
	Then I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
      	| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Water         | 100     | false               | false       |            |
	Then I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Then I call Shared Step 57507 (Transportation Details 1- Not Regulated - Continue - Happy Path)
	Then In the 'Select Retailers' window I select the retailer: Bed Bath and Beyond (including Harmon, Buy Buy Baby, and Christmas Tree Shops)
	Given I click continue
	Then I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC804879551225, container type: Plastic Container and size: 3.5
	#Then I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
	Then in the Regulatory Documents to Provide page I click Continue

	Given I click continue
	Given I click continue
	Given I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
		| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
	#Then I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: «comments»
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	#Then I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given I should see the Data Acceptance Page
	Then In the Data Acceptance Section, check 'Agreed' checkbox
	Then In the Data Acceptance Section, click 'Accept' button

	Then I call Shared Step 130558 (Go to Retail Partners - Select Bed Bath and Beyond)
	Then I click the Products in Scope button and confirm that a file is produced called BB_Report_DataUsageTier_<Date>.xlsx and save as Products in Scope Report for BBB
	Then I confirm the excel file saved as: Products in Scope Report for BBB contains the following data: Cleaning Supplies Product for BBB
	Then I delete the excel file saved as Products in Scope Report for BBB



@ignore
@TestCase:128144
Scenario: [128144] Login Behavior for Products NOT in Scope for Bed Bath and Beyond
	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Given in the New Product page I click Continue
	Given I call Shared Step 57561a (The Product - Enter Product Name: Product NOT in Scope for BBB and select Type of Product): Pet Shampoo
	Given I generate a random UPC number and save as: UPC128144
	#Given I call Shared Step 57401 (Product Information - US only - No GHS, Not Direct Ship, Not PLP, Not GNFR > Continue - Happy Path)
	Given I should see the Product Information Page
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue
	Given I call Shared Step 57441 (Physical and Chemical Properties - Primary Physical Property - Liquid)
	Then I confirm that the the option: United States is checked for the following section: Select countries the product may be sold in
	Given I set the Select countries the product may be sold in option to: Canada
	Given I set the Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada) option to: No
	Given I set the Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns. option to: No
	Given I set the Product is a Retailer's Private Label or Brand option to: No
	Given I set the Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale) option to: No
	Then I click continue
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| CASNumber  | ComponentName                   | Percent | PublicallyDisclosed | PublicName | TradeSecret |
		| 61789-31-9 | Fatty Acids, coco, sodium salts | 100     |                     |            |             |
	And I call Shared Step 57637 (Regulatory Information 1 - TSCA & CEPA shown, No to PROP 65 - Continue - Happy Path)
	#Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
	Given I should see the Regulatory Information 3 Page
	Then In the Regulatory Information 3 Section, the statement 'Based on the product's recommended use and formulation, this is a possible pharmaceutical waste for California.  Please complete the additional question below to ensure proper classification of this product for the retailer(s).' is displayed
	Then In the Regulatory Information 3 Section, in section: 'Refer to your Product Label.  From the options, select those that appear on the Label.' displayed options are:
	| Option                 |
	| Drug Facts Panel       |
	| Supplement Facts Panel |
	| Nutrition Facts Panel  |
	| None of the Above      |
	Then In the Regulatory Information 3 Section, in section: 'Refer to your Product Label.  From the options, select those that appear on the Label.' click the checkbox option: None of the Above 
	Then In the Regulatory Information 3 Section, the following link: Nutritional and Supplement Labels should be displayed
	Then In the Regulatory Information 3 Section, the following link: Dietary Supplements Label should be displayed
	Then In the Regulatory Information 3 Section, the following link: OTC Drug Facts Label (may include Active Ingredient) should be displayed
	Then in the Regulatory Information 3 page I click Continue
	#Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Bed Bath and Beyond (including Harmon, Buy Buy Baby, and Christmas Tree Shops)
	Given I should see the Retailer Page
	Then In the Retailer Section, click 'Add Retailers' button
	Then In the Select Retailers window, select retailer: Bed Bath and Beyond (including Harmon, Buy Buy Baby, and Christmas Tree Shops)
	Then In the Select Retailers window, click 'Done' button
	Then in the Retailer page I click Continue

	And I call Shared Step 87647 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC128144, container type: Plastic Container and size: 6.2 do not click continue
	Then I click continue
	Given I call Shared Step 78868 - Regulatory Documents to Provide - US and Canada - Request authoring for both
	Given I click continue
	Then I click continue
	And I call Shared Step 64097 - Additional Documents -> Contact Information - Add any Name, address, phone and emergency phone - Happy Path
	Given I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
		| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
	#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: «comments»
	#Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given I call Shared Step 130558 (Go to Retail Partners - Select Bed Bath and Beyond)
	Given I click the Products in Scope button and confirm that an excel file is produced called BB_Report_DataUsageTier_<Date>.xlsx and save as PRODUCTS NOT IN SCOPE REPORT FOR BBB
	Then I confirm the excel file saved as: PRODUCTS NOT IN SCOPE REPORT FOR BBB does not contain the following data: Product NOT in Scope for BBB
	Given I delete the excel file saved as PRODUCTS NOT IN SCOPE REPORT FOR BBB
	Given I click on close in the Report Download dialog
	Given I navigate to the home page

@ignore
@TestCase:128140
Scenario: [128140] Data Tier Expansion for BBB - Products in Scope Report - Nutritional Supplement - Nutritional Supplement - Solid
	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Given in the New Product page I click Continue
	Given I call Shared Step 57561a (The Product - Enter Product Name: Nutritional (Solid) Supplement Product for BBB and select Type of Product): Nutritional Supplement - Solid
	Given I generate a random UPC number and save as: UPC128140
	And I call Shared Step 62678 (Product Information - US & Canada, No Child, No OSHA, NO Direct ship, No PL, No NGFR - Continue, Happy path)
	#Given I call Shared Step 37857 (Enter Physical Property - Solid)
	Given I should see the Physical and Chemical Properties Page
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' confirm option is selected: Solid
	Then In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
	Then In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Then In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
	Then in the Physical and Chemical Properties page I click Continue
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| CASNumber | ComponentName | Percent | PublicallyDisclosed | PublicName | TradeSecret |
		| 56-85-9   | L-Glutamine   | 100     |                     |            |             |
	And I call Shared Step 57637 (Regulatory Information 1 - TSCA & CEPA shown, No to PROP 65 - Continue - Happy Path)
	#Then I call Shared Step 132473 (Regulatory Information 3 - Nutritional Category)
	Given I should see the Regulatory Information 3 Page
	Then In the Regulatory Information 3 Section, the statement 'Based on the product's recommended use and formulation, this is a possible Nutritional Supplement. Please complete the additional question below to ensure proper classification of this product for the retailer(s).' is displayed
	Then In the Regulatory Information 3 Section, in section: 'Refer to your Product Label.  From the options, select those that appear on the Label.' displayed options are:
	| Option                 |
	| Supplement Facts Panel |
	| Nutrition Facts Panel  |
	| None of the Above      |
	Then In the Regulatory Information 3 Section, in section: 'Refer to your Product Label.  From the options, select those that appear on the Label.' click the checkbox option: Nutrition Facts Panel
	Then In the Regulatory Information 3 Section, the following link: Nutritional and Supplement Labels should be displayed
	Then In the Regulatory Information 3 Section, the following link: Dietary Supplements Label should be displayed
	Then in the Regulatory Information 3 page I click Continue

	#Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Bed Bath and Beyond (including Harmon, Buy Buy Baby, and Christmas Tree Shops)
	Given I should see the Retailer Page
	Then In the Retailer Section, click 'Add Retailers' button
	Then In the Select Retailers window, select retailer: Bed Bath and Beyond (including Harmon, Buy Buy Baby, and Christmas Tree Shops)
	Then In the Select Retailers window, click 'Done' button
	Then in the Retailer page I click Continue

	Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC128140, container type: Plastic Container and size: 6.2
	#Given I call Shared Step 60567 (Upload Product Label only)
	Given I should see the Regulatory Documents to Provide Page
	Given in the Regulatory Documents to Provide page I click Continue
	Then In the Regulatory Documents to Provide Section: 'Upload Full Product Label (required) (For private label products please upload a generic label that is not retailer-specific.)' error message should display: Document is required: Product Label
	Then In the Regulatory Documents to Provide Section, upload file in section: 'Upload Full Product Label (required) (For private label products please upload a generic label that is not retailer-specific.)'
	Given in the Regulatory Documents to Provide page I click Continue

	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: «comments»
	#Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given I call Shared Step 130558 (Go to Retail Partners - Select Bed Bath and Beyond)
	Given I click the Products in Scope button and confirm that an excel file is produced called BB_Report_DataUsageTier_<Date>.xlsx and save as Products in Scope Report for BBB
	Then I confirm the excel file saved as: Products in Scope Report for BBB contains the following data: Nutritional (Solid) Supplement Product for BBB
	Given I delete the excel file saved as Products in Scope Report for BBB


@ignore
@TestCase:147446
Scenario: [147446] WM - Authoring option ONLY available
	#Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I log in with the account saved in TReVor as: ProductAccount
	Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk
	Given I generate a random UPC number and save as: UPC147446
	Given I save the product information as: testcase147446
	Given I call Shared Step 63860 (Product Information - US, No(child), No(OSHA), No(DSV), Yes(PLP), No(GNFR))
	#Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I should see the Physical and Chemical Properties Page
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' should be showing the option: Solid
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' confirm option is selected: Solid
	Then In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
	Then In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Then In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
	Then in the Physical and Chemical Properties page I click Continue

	#Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Water
	Given I should see the Ingredients Page
	Then In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	| component name | Water       | 100     |                     |               |             |
	Then in the Ingredients page I click Continue

	#Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I should see the Inventory Status, Prop 65 (US) Page
	Then In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	Then In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page I click Continue

	Given I call Shared Step 65181 (Retailer Association - Add Private Label Information and Select Vendor ID) and select the retailer: Wal-Mart/SAM'S CLUB and enter the name: Allswell and select Vendor id: random
	Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC147446, container type: Plastic Container and size: 2
	And I see the following sections
		| Section                                   |
		| OSHA-compliant Safety Data Sheet, English |
	And The following options should be displayed exclusively for section: OSHA-compliant Safety Data Sheet, English
		| Option            |
		| Request to author |
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: testcase147446



@ignore
@TestCase:147447
Scenario: [147447] Sears - Authoring option ONLY available
	#Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I log in with the account saved in TReVor as: ProductAccount
	Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk
	Given I generate a random UPC number and save as: UPC147447
	Given I save the product information as: testcase147447
	Given I call Shared Step 63860 (Product Information - US, No(child), No(OSHA), No(DSV), Yes(PLP), No(GNFR))
	#Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I should see the Physical and Chemical Properties Page
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' should be showing the option: Solid
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' confirm option is selected: Solid
	Then In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
	Then In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Then In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
	Then in the Physical and Chemical Properties page I click Continue

	#Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Water
	Given I should see the Ingredients Page
	Then In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	| component name | Water       | 100     |                     |               |             |
	Then in the Ingredients page I click Continue

	#Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I should see the Inventory Status, Prop 65 (US) Page
	Then In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	Then In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page I click Continue

	Given I call Shared Step 69682 (Retailer Association - Add Private Label Information) and select the retailer: Sears/K-Mart and enter the name: TestBrand
	Given In the Retailers tab, I select the first Vendor option for retailer: Sears/K-Mart
	Given I click continue
	Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC147447, container type: Plastic Container and size: 2
	And I see the following sections
		| Section                                   |
		| OSHA-compliant Safety Data Sheet, English |
	And The following options should be displayed exclusively for section: OSHA-compliant Safety Data Sheet, English
		| Option            |
		| Request to author |
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: testcase147447

# Created by Saikiran Chittampally
@TestCase:50863
Scenario: [50863] WERCSmart Portal Verification on Required Selections for the "Inventory Status, Prop 65" Page Using the Type of Product: Lip Balm

	#Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC50863

	#Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Then in the New Product page, I click Continue

	#Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Lip Balm
	Then I should be on the The Product Page
	And In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Lip Balm_#50863
	And In the Product Section, set the option in section: 'Type of Product (select)' to: Lip Balm
	Then in the The Product page, I click Continue

	Then I save the product information as: TestCase50863

	#Given I call Shared Step 59680a (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Then I should be on the Product Information Page
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)' to: No
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue

	#Given I call Shared Step 213796 (Physical and Chemical Properties - Applicable Only to Lip Balm (RU000246))
	Then I should be on the Physical and Chemical Properties Page
	And In the Physical and Chemical Properties Section, for section: 'Primary Physical State': the following options should be displayed exclusively:
	| Option |
	| Liquid |
	| Solid  |
	And In the Physical and Chemical Properties Section, set the option in section: 'Primary Physical State' to: Solid
	And In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
	And In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	And In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: No data available
	Then in the Physical and Chemical Properties page, I click Continue

	#Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
	#	| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
	#	| Cocos Nucifera Oil  | 50      | false               | false       |            |
	#	| White Mineral Oil (petroleum)       | 50       | false               | false       |            |
	Then I should be on the Ingredients Page
	And In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue                   | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	| component name | Cocos Nucifera Oil            | 50      | False               | False         |             |
	| component name | White Mineral Oil (petroleum) | 50      | False               | False         |             |
	Then in the Ingredients page, I click Continue

	#Given I call Shared Step 234333 (Inventory Status, Prop 65 (US) - Applicable Only to Lip Balm (RU000246))
	Then I should be on the Inventory Status, Prop 65 (US) Page
	Then in the Inventory Status, Prop 65 (US) page, I click Continue
	And In the Inventory Status, Prop 65 (US) Section, the section 'U.S. Toxic Substances Control Act (TSCA) status' should display an error message: This is a required field.
	And In the Inventory Status, Prop 65 (US) Section, the section 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' should display an error message: This is a required field.
	And In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is exempt from TSCA chemical Inventory listing requirements.
	And In the Inventory Status, Prop 65 (US) Section, the section 'U.S. Toxic Substances Control Act (TSCA) status' should not display an error message: This is a required field.
	And In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	And In the Inventory Status, Prop 65 (US) Section, the section 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' should not display an error message: This is a required field.
	Then in the Inventory Status, Prop 65 (US) page, I click Continue

	#Given I call Shared Step 234334 (Regulatory Information 3 - Applicable Only to Lip Balm (RU000246))
	Then I should be on the Product Labeling Page
	And In the Product Labeling Section, the statement 'Based on the product's recommended use and formulation, this is a possible pharmaceutical waste for California.  Please complete the additional question below to ensure proper classification of this product for the retailer(s).' is displayed
	And In the Product Labeling Section, in section: 'Refer to your Product Label.  From the options, select those that appear on the Label.' displayed options are:
	| Option                 |
	| Drug Facts Panel       |
	| Supplement Facts Panel |
	| Nutrition Facts Panel  |
	| None of the Above      |
	And In the Product Labeling Section, in section: 'Refer to your Product Label.  From the options, select those that appear on the Label.' click the checkbox option: None of the Above
	And In the Product Labeling Section, the following link: OTC Drug Facts Label (may include Active Ingredient) should be displayed
	And In the Product Labeling Section, the following link: Nutritional and Supplement Labels should be displayed
	And In the Product Labeling Section, the following link: Dietary Supplements Label should be displayed
	Then in the Product Labeling page, I click Continue

#	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase50863
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase50863

