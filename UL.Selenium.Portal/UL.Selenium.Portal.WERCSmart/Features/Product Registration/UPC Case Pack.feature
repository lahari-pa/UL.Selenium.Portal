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
@SummaryPage
@PaymentMethods
@SubEnrollment
@WERCSmart_Signup
@MyAccount
@PackagingTypes
@Brands
@MyIngredients
@UPC
@SHA
@ForwardProductRegistration
@ProductSetUp
@ViewUpcs
@run_UPCCasePack
@StepsPrototype
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:NewProduct
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:TheProduct
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:ProductInformation
@PhysicalAndChemicalProp
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:RegulatoryDocumentsToProvide
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:InventoryStatusProp65
@Ingredients
@SafetyDataSheetAuthoring
@AdditionalDocsContactInfo
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:DataAcceptance
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:OptionalComments
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:Retailer

@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:InventoryStatusProp65
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:USDepartamentOfTransportationDOT
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:AdditionalDocumentsToProvide
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:TransportationDetails1
@SafetyDataSheetAuthoring
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:ElectronicEquipment
@GTINAndUPC
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:Summary
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:InternationalMarineClassification
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:USDepartamentOfTransportationDOT
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:VOC_Summary
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:VOCForCaliforniaAirDistrictAndCanada
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:ECOLOGO
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:AdditionalDocumentsToProvide
@RegulatoryInformation3
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:VOC_OzoneTransportCommission
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:VOC_Summary
@SideMenu

Feature: UPC Case Pack



#Background:
	#Given I verify the following users exist and if not I create them using SHAUser
#		| username    | FirstName | LastName   | Role         | EmailAddress                |
#		| SHAQAAuto30 | QA        | Automation | QA Reviewers | qasha.kxxyxunf@mailosaur.io |

@TestCase:87640
Scenario: [87640] UPC - Case Pack Only Present in product
	#Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I log in with the account saved in TReVor as: ProductAccount
	Given I generate a random UPC number and save as: UPC87640
	Then The home screen should load
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Then In the Side Menu, click Labeled Link with Add Product title
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration'
	Then in the New Product page, I click Continue
	#Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
	Then I should be on the The Product Page
	And In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Lipbalm_#87640
	Given In the Product Section, set the option in section: 'Type of Product (select)' to: Lip balm
 	Given in the The Product page I click Continue
	Then I save the product information as: TestCase87640
	#Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Given I should see the Product Information Page
	Then I should be on the Product Information Page
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)' to: No
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue
	#Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I should be on the Physical and Chemical Properties Page
	Then In the Physical and Chemical Properties Section, set the option in section: 'Primary Physical State' to: Solid
	Then In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
	Then In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Then In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
	Then in the Physical and Chemical Properties page I click Continue
	#Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
	Then I should be on the Ingredients Page
    And In the Ingredients section, add the following ingredients:
    | SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
    | component name | Water       | 100     | False               | False         |             |
    Then in the Ingredients page, I click Continue
	#Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given I should be on the Inventory Status, Prop 65 (US) Page
	Then In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	Then In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page I click Continue
    Given I should see the Product Labeling Page
	Then In the Product Labeling Section, in section: 'Refer to your Product Label.  From the options, select those that appear on the Label.' click the checkbox option: None of the Above
	Then in the Product Labeling page, I click Continue
	#Given I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue) for
    #| Retailer  |
    #| Walgreens |
    Then I should be on the Retailer Page
	And In the Retailer Section, click 'Add Retailers' button
	And In the Select Retailers window, select retailer: Amazon
	And In the Select Retailers window, click 'Done' button
	Then in the Retailer page, I click Continue
	#Given I call Shared Step 87641(Enter Universal Product Code - case information) for UPC: saved as UPC87640, container type: Paper bag and size: 2 and Quantity: 4 and Transportation option: random
	Given I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page
    Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, I click the 'Add Casepack' button
    Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, for section: 'GTIN/UPC (include check digit)' enter the value: saved as UPC87640
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, for section: 'Size (Fluid Ounces)' enter the value: 2
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, for section: 'Container Type' select the value: Plastic Container
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, for section: 'Quantity of Units within the Case' enter the value: 5
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, for section: 'Transportation Options' enter the value: 1A2: removable head steel drum
	Given in the Global Trade Item Number (GTIN) / Universal Product Code (UPC) page I click Continue
	#Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Then I should be on the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Yes, I certify that I have an OSHA-compliant SDS for this product and would like to upload it.
	Then In the Regulatory Documents to Provide Section, upload file in section: 'OSHA SDS'
	Then In the Regulatory Documents to Provide Section, for section OSHA SDS button View should exists
	Then In the Regulatory Documents to Provide Section, for section OSHA SDS button Remove should exists
	Then in the Regulatory Documents to Provide page, I click Continue
	Then I should be on the Additional Documents to Provide Page
	Then in the Additional Documents to Provide page, I click Continue
	Then I should be on the Optional Reports and Documents Available for Purchase Page
	Then in the Optional Reports and Documents Available for Purchase page, I click Continue
	#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test data
	Then I should be on the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page, I click Continue
	#Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
    Then I should be on the Data Acceptance Page
	Then In the Data Acceptance Section, check 'Agreed' checkbox
	Then In the Data Acceptance Section, click 'Accept' button
	Given If purchase details are showing click confirm order
	
	
@TestCase:87650
@TestCase:87650
Scenario: [87650] Battery Product - limit of 5 UPCs for Lithium ion battery- Case UPC counts towards the 5 limit
	#Given I login into the WERCSmart Portal - Administrator Role
	Given I log in with the account saved in TReVor as: ProductAccount
	Given I generate a random UPC number and save as: UPC87650
	Given I generate a random UPC number and save as: UPC876501
	Given I generate a random UPC number and save as: UPC876502
	Given I generate a random UPC number and save as: UPC876503
	Given I generate a random UPC number and save as: UPC876504
#	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Then In the Side Menu, click Labeled Link with Add Product title
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration'
	Then in the New Product page, I click Continue

	Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Lithium Ion Battery
    Then I save the product information as: TestCase87650
	Given I call Shared Step 65493 (Product Information - US only - Battery is packaged for Retail Sales - No to everything else - Continue)
#	Given I call Shared Step 59927 (Primary Physical State > Solid only available – Without Water Solubility question)
	Then I should be on the Physical and Chemical Properties Page
	And In the Physical and Chemical Properties Section, the section: 'Primary Physical State' should be showing the option: Solid
	And In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
	And In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Then in the Physical and Chemical Properties page, I click Continue

	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName      | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Lithium hydroxide  | 6.7     | false               | false       |            |
		| Graphite           | 33.2    | false               | false       |            |
		| Ethylene carbonate | 60.1    | false               | false       |            |
	Given I should see the Formulation > Batteries Page
	Then I set the Consent to Tier 2.1, 2.2, 4.2 Data Uses option to: Granted
	Given I click continue
	#Given I call Shared Step 57637 (Regulatory Information 1 - TSCA & CEPA shown, No to PROP 65 - Continue - Happy Path)
	Then I should be on the Inventory Status, Prop 65 (US) Page
	And In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is exempt from TSCA chemical Inventory listing requirements.
	And In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'Canadian Environmental Protection Act (CEPA) status' to: Compliant with Domestic Substances List (DSL)
	And In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No 
	Then in the Inventory Status, Prop 65 (US) page, I click Continue

	Given I call Shared Step 54799 (Lithium Battery Characteristics - any data - Happy path)
	Given I call Shared Step 60096 (Lithium Battery Transportation)
	Then I should see the following retailers:
		| Retailers                  |
		| No Retailer/No UPC Product |
	#Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Walgreens
	Then I should be on the Retailer Page
	And In the Retailer Section, click 'Add Retailers' button
	And In the Select Retailers window, select retailer: Walgreens
	And In the Select Retailers window, click 'Done' button
	Then in the Retailer page, I click Continue

	Then I should see lithium battery message: Lithium battery registrations have a maximum of five (5) UPCs per registration. If you have additional UPCs, please create a new registration.
	Given I call Shared Step 87658 (Enter Universal Product Code (UPC)) for UPC saved as: UPC87650 with container type: Plastic Container size: 25 and quantity: 50 do not click continue
	Given I call Shared Step 87658 (Enter Universal Product Code (UPC)) for UPC saved as: UPC876501 with container type: Plastic Container size: 25 and quantity: 50 do not click continue
	Given I call Shared Step 87658 (Enter Universal Product Code (UPC)) for UPC saved as: UPC876502 with container type: Plastic Container size: 25 and quantity: 50 do not click continue
	Given I call Shared Step 87658 (Enter Universal Product Code (UPC)) for UPC saved as: UPC876503 with container type: Plastic Container size: 25 and quantity: 50 do not click continue
	Given I call Shared Step(Enter Universal Product Code - case information) for UPC: saved as UPC876504, container type: Paper bag and size: 2 and Quantity: 4 and Transportation option: 4A: steel box do not click continue
	Then I should see maximum upc limit message: This product registration has reached the maximum limit of active UPC entries. You may remove UPC entries that are no longer valid, if possible. Also, be sure the UPC entries are for the specific registration being made. If you need an exception to the UPC limit for this registration, please contact support and advise the total quantity of UPCs needed to accommodate this registration.
	And I should not see the following UPC buttons:
		| Option       |
		| Add          |
		| Add Casepack |
	Given in the Universal Product Code (UPC) page I click Continue
	Given I click the browse button for label: I have an Article Information Sheet (AIS), Technical Data Sheet (TDS), Battery Data Sheet (BDS) to provide. and upload PDF: UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf
	Given I call Shared Step 104662 - Regulatory Documents to Provide - Lithium Batteries - US and Canada - Request authoring for both
	Given I call Shared Step 69422 (Additional Documents to Provide - Upload Product Photo)
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
#	And I call Shared Step 64097 - Additional Documents -> Contact Information - Add any Name, address, phone and emergency phone - Happy Path
	Then I should be on the Additional Documents -> Contact Information Page
	And In the Additional Documents -> Contact Information section, for section: 'Manufacturer Name' enter text: Manufacturer
	And In the Additional Documents -> Contact Information section, for section: 'Address' enter text: Address
	And In the Additional Documents -> Contact Information section, for section: 'Phone' enter text: Phone
	And In the Additional Documents -> Contact Information section, for section: 'Emergency Phone' enter text: Emergency Phone
	Then in the Additional Documents -> Contact Information page, I click Continue

#	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
#		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient |
#		| Gloves                        | 650                      | 0.400                   | 1.005     | Black      | Acidic | No data available | 7.388                 |
	Then I should be on the Safety Data Sheet Authoring - Additional Data (Optional) Page
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Personal Protection Equipment Recommended (select)' to: Gloves
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Autoignition Temperature (°C)' enter text: 650
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Minimum Ignition Energy (mJ)' enter text: 0.400
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Viscosity' enter text: 1.005
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Appearance' to: Black
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor' to: Acidic
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor Threshold' to: No data available
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Partition Coefficient' enter text: 7.388
	Then in the Safety Data Sheet Authoring - Additional Data (Optional) page, I click Continue


	#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test data
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	#Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given I should see the Data Acceptance Page
	Then In the Data Acceptance Section, check 'Agreed' checkbox
	Then In the Data Acceptance Section, click 'Accept' button

	Given If purchase details are showing click confirm order
	Given I call Shared Step 65080b (Login to Studio as user saved as: SHAQAAuto30 and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase87650)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase87650 and its status is: Submitted
	Given I call Shared Step 75309 (SHA > Select Product > UPC Retailer and Feed) for product saved as: TestCase87650
	And In the list of UPCs I should see case pack indicatior for UPC: saved as UPC876504
	And In the list of UPCs I should not see case pack indicatior for UPC: saved as UPC87650
	And In the list of UPCs I should not see case pack indicatior for UPC: saved as UPC876501
	And In the list of UPCs I should not see case pack indicatior for UPC: saved as UPC876502
	And In the list of UPCs I should not see case pack indicatior for UPC: saved as UPC876503

@TestCase:87676
Scenario: [87676] UPC - Case Pack can be removed from new product
	#Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I log in with the account saved in TReVor as: ProductAccount
	Given I generate a random UPC number and save as: UPC87676
	Then The home screen should load
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Then In the Side Menu, click Labeled Link with Add Product title
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration'
	Then in the New Product page, I click Continue

	#Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
	Then I should be on the The Product Page
	And In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: AirFreshener_#87676
	Given In the Product Section, set the option in section: 'Type of Product (select)' to: Air Freshener - Single Phase Aerosol
 	Given in the The Product page I click Continue
	Then I save the product information as: TestCase87676
    Given I generate a random UPC number and save as: UPC87676
    Then I save the product information as: TestCase87676
	Then I should be on the Product Information Page
	Then In the Product Information Section, set the option in section: 'Which best describes your product, including when FIFRA 25(b) Exempt' to: Product is not a pesticide and does not make or imply a pesticidal claim on the labeling or in the product description (ex. kills, sterilizes, disinfects, sanitizes, antimicrobial)
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	And In the Product Information Section, set the option in section: 'Cleaning products must comply with California's Cleaning Product Right to Know Act. I would like to provide the additional information needed for this program during registration.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue

	#Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I should see the Physical and Chemical Properties Page
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' should be showing the option: Aerosol
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' confirm option is selected: Aerosol
	Then In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid spray
	Then In the Physical and Chemical Properties Section, for section: 'pH' enter text: 5
	Then In the Physical and Chemical Properties Section, set the option in section: 'When the product has a flammable propellant, or contains ingredients with a flash point below 60⁰C then' to: This product is classified as a D001 Hazardous Waste under RCRA (as per Section 13 or 15 of the SDS).
	Then in the Physical and Chemical Properties page I click Continue

	#Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
	Then I should be on the Ingredients Page
    And In the Ingredients section, add the following ingredients:
    | SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
    | component name | Formaldehyde      | 20     | False               | False         |             |
    | component name | Acetaldehyde      | 20     | False               | False         |             |
    | component name | Acetone           | 20     | False               | False         |             |
    | component name | Picric Acid       | 20     | False               | False         |             |
    | component name | Butane            | 20     | False               | False         |             |
    Then in the Ingredients page, I click Continue
#	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Then I should be on the Inventory Status, Prop 65 (US) Page
	And In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	And In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page, I click Continue
	Then I should be on the Transportation Details 1 Page
    And In the Transportation Details 1 Section, verify in 'Product is Regulated for Transport' section is option: Yes
    And In the Transportation Details 1 Section, set the option in section: 'Select all modes of transport that you've classified the product for': to: DOT
    And In the Transportation Details 1 Section, set the option for DOT mode of transport to: Shipping fully regulated
    Then in the Transportation Details 1 page, I click Continue
	Then I should be on the U.S. Department of Transportation (DOT) Classification Page
    And In the U.S. Department of Transportation (DOT) Classification Section, set the option in section: 'UN Number': to: UN1950
    And In the U.S. Department of Transportation (DOT) Classification Section, set the option in section: 'Proper Shipping Name': to: Aerosols
    And In the U.S. Department of Transportation (DOT) Classification Section, set the option in section: 'Hazard Class': to: 2.2
    And In the U.S. Department of Transportation (DOT) Classification Section, set the option in section: 'Packing Group': to: None
    Then in the U.S. Department of Transportation (DOT) Classification page, I click Continue
	And I should see the Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB) Page
	Then In the VOC - Ozone Transport Commission Section, set the option in section: 'Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations.': to: No
	Then In the VOC - Ozone Transport Commission Section, set the option in section: 'Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the CARB': to: 5
	Then In the VOC - Ozone Transport Commission Section, set the option in section: 'Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the OTC Model Rule': to: 5
	Then In the VOC - Ozone Transport Commission Section, set the option in section: 'Would you like to use the VOC percentages entered for all areas (e.g. country, state, local) for comparison?': to: Yes
	Then in the Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB) page, I click Continue	
	And I should see the Volatile Organic Compound Summary Page
	Then In the Volatile Organic Compound Summary Section, confirm that I see todays 'VOC Analysis Date'
	Then In the Volatile Organic Compound Summary Section, confirm 'Limits' table should exists
	Then In the Volatile Organic Compound Summary Section, confirm 'VOC content as weight percentage of total formula, minus exempt compounds, for each of the following states.' table should exists
	Then In the Volatile Organic Compound Summary Section, confirm that I see the following 'CARB' value: 5
	Then In the Volatile Organic Compound Summary Section, confirm that I see the following 'OTC Model Rule' value: 5
	Then In the Volatile Organic Compound Summary Section, the statement 'Based on the type of product, this must comply with the most restrictive VOC limit.' is displayed
	Then In the Volatile Organic Compound Summary Section, for 'Your acknowledgement of this registration includes that your product..' set 'Yes, I Acknowledge'
	Then in the Volatile Organic Compound Summary page, I click Continue	

	#Given I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue) for
		#| Retailer |
		#| Amazon   |
    Then I should be on the Retailer Page
	And In the Retailer Section, click 'Add Retailers' button
	And In the Select Retailers window, select retailer: Walgreens
	And In the Select Retailers window, click 'Done' button
	Then in the Retailer page, I click Continue

	#Given I call Shared Step 87641(Enter Universal Product Code - case information) for UPC: saved as UPC87676, container type: Paper bag and size: 2 and Quantity: 4 and Transportation option: 4A: steel box
	Given I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page
    Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, I click the 'Add Casepack' button
    Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, for section: 'GTIN/UPC (include check digit)' enter the value: saved as UPC87676
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, for section: 'Size (Fluid Ounces)' enter the value: 2
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, for section: 'Container Type' select the value: Aerosol Can - Metal
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, for section: 'Quantity of Units within the Case' enter the value: 5
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, for section: 'Transportation Options' enter the value: 1A2: removable head steel drum
	Given in the Global Trade Item Number (GTIN) / Universal Product Code (UPC) page I click Continue
	#Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
	Then in the Regulatory Documents to Provide page, I click Continue
	Then I should be on the Additional Documents to Provide Page
	Then In the Additional Documents to Provide, upload PDF document for section: Volatile Organic Compounds - Product Label
	Given in the Additional Documents to Provide page I click Continue
	Then I should be on the Optional Reports and Documents Available for Purchase Page
	Then in the Optional Reports and Documents Available for Purchase page, I click Continue
#	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
#		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient |
#		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | 41.3005               |
	Then I should be on the Safety Data Sheet Authoring - Additional Data (Optional) Page
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Personal Protection Equipment Recommended (select)' to: Gloves
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Autoignition Temperature' enter text: 501.827328
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Minimum Ignition Energy (mJ)' enter text: 10.00001
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Viscosity' enter text: 10.28
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Appearance' to: Brown
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor' to: Orange
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor Threshold' to: No data available
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Product's Dispensing Method' select option: Aerosol
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Partition Coefficient' enter text: 41.3005
	Then in the Safety Data Sheet Authoring - Additional Data (Optional) page, I click Continue
	#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test data
	Then I should be on the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page, I click Continue



@TestCase:87685
Scenario: [87685] UPC - Case Pack & Regular UPC present in Product - Process to Complete
	#Given I login into the WERCSmart Portal - Administrator Role
	Given I log in with the account saved in TReVor as: ProductAccount
	Given I generate a random UPC number and save as: UPC87685
	Given I generate a random UPC number and save as: UPC876851
#	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Then In the Side Menu, click Labeled Link with Add Product title
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration'
	Then in the New Product page, I click Continue

	Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
	Then I save the product information as: TestCase87685
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

	#Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
	Given I should see the Ingredients Page
	Then In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	| component name | Sodium hydroxide       | 100     |                     |               |             |
	Then in the Ingredients page I click Continue

#	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Then I should be on the Inventory Status, Prop 65 (US) Page
	And In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	And In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page, I click Continue

	Given I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue) for
		| Retailer |
		| Amazon   |
	Given I call Shared Step 87647 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC87685, container type: Paper bag and size: 2 do not click continue
	Given I call Shared Step 87641(Enter Universal Product Code - case information) for UPC: saved as UPC876851, container type: Paper bag and size: 2 and Quantity: 4 and Transportation option: 4A: steel box
	#Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
	Then in the Regulatory Documents to Provide page I click Continue

	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
		| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
	#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: User added Comments Text 57863. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	#Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given I should see the Data Acceptance Page
	Then In the Data Acceptance Section, check 'Agreed' checkbox
	Then In the Data Acceptance Section, click 'Accept' button

	Given If purchase details are showing click confirm order
	Given I call Shared Step 65080b (Login to Studio as user saved as: SHAQAAuto30 and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase87685)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase87685 and its status is: Submitted
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase87685)
	Given I call Shared Step 75309 (SHA > Select Product > UPC Retailer and Feed) for product saved as: TestCase87685
	And In the list of UPCs I should not see case pack indicatior for UPC: saved as UPC87685
	And In the list of UPCs I should see case pack indicatior for UPC: saved as UPC876851
	And I close the window saved as: SHAManagerProductUPC
	Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase87685)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase87685)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase87685 and its status is: Assigned
	Given I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase87685)
	Given I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase87685)
	Given I call Shared Step 75347 (WPS Studio - PD+ - set all data and publish using rule and Doc queue - CKLT, NGHS and SBCS) for product saved as: TestCase87685
	Given I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase87685)
	Given I call Shared Step 59066 (Go to SHA Manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase87685)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase87685 and its status is: Accepted
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Accepted Status for saved as: TestCase87685)
	Given I call Shared Step 51664 (SHA - Accepted Product - set Retailers to Completed for saved as: TestCase87685) for
		| Retailer |
		| Amazon   |
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase87685)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase87685 and its status is: Completed

@TestCase:87686
Scenario: [87686] UPC - Case Pack Only Present in Product - Process to Complete
	#Given I login into the WERCSmart Portal - Administrator Role
	Given I log in with the account saved in TReVor as: ProductAccount
	Given I generate a random UPC number and save as: UPC87686
#	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Then In the Side Menu, click Labeled Link with Add Product title
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration'
	Then in the New Product page, I click Continue

	Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
	Then I save the product information as: TestCase87686
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

	#Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
	Given I should see the Ingredients Page
	Then In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	| component name | Sodium hydroxide       | 100     |                     |               |             |
	Then in the Ingredients page I click Continue

#	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Then I should be on the Inventory Status, Prop 65 (US) Page
	And In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	And In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page, I click Continue

	Given I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue) for
		| Retailer |
		| Amazon   |
	Given I call Shared Step 87641(Enter Universal Product Code - case information) for UPC: saved as UPC87686, container type: Paper bag and size: 2 and Quantity: 4 and Transportation option: 4A: steel box
	#Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
	Then in the Regulatory Documents to Provide page I click Continue

	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
		| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
	#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	#Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given I should see the Data Acceptance Page
	Then In the Data Acceptance Section, check 'Agreed' checkbox
	Then In the Data Acceptance Section, click 'Accept' button

	Given If purchase details are showing click confirm order
	Given I call Shared Step 65080b (Login to Studio as user saved as: SHAQAAuto30 and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase87686)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase87686 and its status is: Submitted
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase87686)
	#Changed from UPC List to UPC Retailer and Feed in Sprint 16
	Given I call Shared Step 75309 (SHA > Select Product > UPC Retailer and Feed) for product saved as: TestCase87686
	And In the list of UPCs I should see case pack indicatior for UPC: saved as UPC87686
	Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase87686)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase87686)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase87686 and its status is: Assigned
	Given I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase87686)
	Given I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase87686)
	Given I call Shared Step 75347 (WPS Studio - PD+ - set all data and publish using rule and Doc queue - CKLT, NGHS and SBCS) for product saved as: TestCase87686
	Given I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase87686)
	Given I call Shared Step 59066 (Go to SHA Manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase87686)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase87686 and its status is: Accepted
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Accepted Status for saved as: TestCase87686)
	Given I call Shared Step 51664 (SHA - Accepted Product - set Retailers to Completed for saved as: TestCase87686) for
		| Retailer |
		| Amazon   |
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase87686)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase87686 and its status is: Completed

	#Philip - Working
	@tfs_design
	@ignore
@singlerun
@TestCase:87894
Scenario: [87894] Forwarding - Edit existing Case UPC
Given I Use Test case 87685 to create a product which has a Case UPC and a regular UPC, processed to completed status
	Given I navigate to the landing page
	And I call Shared Step (Login to WERCSmart - Premium Account)
	Then I filter the products by: Accepted by Retailers
	And I filter for the product saved as: TestCase87894
	And I Confirm the Products shown display the Green Colour Status - which is the Accepted by Retailers
	And I call Shared Step 75130 - Bulk Actions - Select Forward Product Registration
	And I should see the subheading 3: Select Products & UPCs on the Forward Product Registration window
	#Then I select the product with ID saved as: TestCase87894 under the Select Products tab
	Then I get the product ID for the product saved as: TestCase87685 then I use this ID in the select Products & UPCs page
	Given I click continue on the Forward Product Registration page
	Then I confirm the active Forward Product Registration tab is: Select Retailers
	#And I Select a retailer which is not already present on the product you are working with, make sure to select a retailer that does not require additional data (such as BB, DI, KG)
	#Then In the Forward Product Registration Screen I select the first retailer that does not require additional data and is not: Amazon under Other Retailers and save it as: ChosenRetailer87894
	Then I select one of the following retailers: and saved the chosen retailer as: <ChosenRetailer87894>
		| Retailer                                                                       |
		| Bed Bath and Beyond (including Harmon, Buy Buy Baby, and Christmas Tree Shops) |
		| Dick's Sporting Goods                                                          |
		| Kroger                                                                         |
	Given I click continue on the Forward Product Registration page
	Then I select the first product under the Select UPCs tab
	#Then I confirm that: WM is displayed in the Destination Retailers column under Select UPCs
	#<-- use as example for accessing this right side table on select UPCs page
	Then I confirm that UPC information is displayed in the Select UPCs Table
	Then I Check that the Truck Icon is not present next to the UPC saved as: UPC87685
	Then I Check that the Truck Icon is present next to the UPC saved as: UPC876851
	And I call Shared Step 87897 (Forwarding - Edit Existing Case UPC: UPC876851 - confirm data shown correctly, change all data, Save, Continue) and save the table as: EditCaseUPCTable87894
		| Container type | Size | Quantity | Individual UPC contained in the Case Pack | Transportation Options              |
		| Paper bag      | 2    | 4        | <UPC87685>                                | 4A:  steel box                      |
		| Aerosol Can    | 4    | 8        | Individual UPC contained in the Case Pack | 1A1:  non-removable head steel drum |
	Then I confirm the active Forward Product Registration tab is: Product Results
	And I confirm that there are NO Errors displayed for the Product
	And I click continue on the Forward Product Registration page
	Then I confirm the active Forward Product Registration tab is: Review & Submit
	Then I select the true radio for the 'Are Statements True' question under the Review and Submit tab
	And I click continue on the Forward Product Registration page
	And In the Purchase Summary screen I confirm the Purchase Summary header is displayed
	Then In the Thank You screen I confirm the following statement is shown: Thank you for registering your product on WERCSmart for assessment.
	Then In the Thank You screen I click Home
	And I call Shared Step 65080b (Login to Studio as user saved as: SHAQAAuto30 and Open SHA manager)
	And I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase87894)
	Then I Check that the product under the retailer: Amazon is under the status: Accepted
	Then I Check that the product under the retailer: <ChosenRetailer87894> is under the status: Submitted
	Given I call Shared Step 75309 (SHA > Select Product > UPC Retailer and Feed) for product saved as: TestCase87894
	Then I call Shared Step 88419 (SHA > UPC - Confirm Case UPC fields (No internal UPC) > Close window) for UPC saved as: UPC876851 for the retailer: Amazon using details saved in the table: EditCaseUPCTable87894

@TestCase:87835
Scenario: [87835] View UPCs shows Case UPC Data
	#Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I log in with the account saved in TReVor as: ProductAccount
	Given I generate a random UPC number and save as: UPC87835
	Given I generate a random UPC number and save as: UPC87835-2
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given In the Side Menu, click Labeled Link with Add Product title
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration'
	Given in the New Product page I click Continue
	#And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
	Then I should be on the The Product Page
	And In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Chalk_#80720
	And In the Product Section, set the option in section: 'Type of Product (select)' to: Chalk
	Then in the The Product page, I click Continue
	Then I save the product information as: TestCase87835
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

	#And I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium Hydroxide
	Given I should see the Ingredients Page
	Then In the Ingredients section, add component with component name: Water
	Then In the Ingredients Table row with component name: Water, in Percent column text input enter: 100
	Then in the Ingredients page I click Continue

	#And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	Given In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Given in the Inventory Status, Prop 65 (US) page I click Continue

	#Given I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue) for
	Given I should see the Retailer Page
	Given In the Retailer Section, click 'Add Retailers' button
	Given In the Select Retailers window, select retailer: Target
	Given In the Select Retailers window, click 'Done' button
	Given in the Retailer page I click Continue


	#Given I call Shared Step 87647 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC87835, container type: Paper bag and size: 2 do not click continue
	Given I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, I click the Add UPC Button
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, for section: 'Provide the product's UPC(s)- including container type and size (ounces)' enter UPC Number: saved as UPC87835 enter Size: 12 and enter Container Type: Plastic bag
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, verify retailer 'TG' is present under the 'Destination Retailers' column

	#And I call Shared Step 87829 (UPC - Add Casepack - All Data > Continue) for UPC: saved as UPC87835-2, container type: Plastic Container and size: 1 and Quantity: 1 and Individual Upc Case Pack saved As: UPC87835 and Transportation option: 4A: steel box
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, I click the 'Add Casepack' button
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, for section: 'GTIN/UPC (include check digit)' enter the value: saved as UPC87835-2
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, for section: 'Size (Fluid Ounces)' enter the value: 2
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, for section: 'Container Type' select the value: Paper bag
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, for section: 'Quantity of Units within the Case' enter the value: 5
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, for section: 'Transportation Options' enter the value: 1A2: removable head steel drum
	Then in the Global Trade Item Number (GTIN) / Universal Product Code (UPC) page I click Continue


	#And I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
	Then in the Regulatory Documents to Provide page I click Continue

	And I should see the Additional Documents to Provide Page
	Given in the Additional Documents to Provide page I click Continue
	And I should see the Optional Reports and Documents Available for Purchase Page
	Given in the Optional Reports and Documents Available for Purchase page I click Continue


	#And I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
	#	| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
	#	| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
	Then I should be on the Safety Data Sheet Authoring - Additional Data (Optional) Page
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Personal Protection Equipment Recommended (select)' to: Gloves
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Autoignition Temperature' enter text: 800
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Minimum Ignition Energy (mJ)' enter text: 99
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Viscosity' enter text: 60
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Appearance' to: Clear
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor' to: Odorless
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor Threshold' to: No data available
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Partition Coefficient' enter text: 10
	Then in the Safety Data Sheet Authoring - Additional Data (Optional) page, I click Continue	Given in the Optional Comments page I click Continue

	#And I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Test Comment
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	And I navigate to the home page
	Then I filter for the product saved as: TestCase87835
	And I click Row Actions for the first product returned
	Then I click on the Row Action: View UPCs
	And I switch to the tab with title: View UPCs
	And I verify the Case UPC data is correct in the View UPCs window: 
	    | UPC Number   | Container Type    | Size Ounces | Retailer | Associated UPC  | Quantity | Transport                      |
		| %UPC87835-2% | Paper bag         | 2           | TG       |                 | 5        | 1A2: removable head steel drum |

	And I verify the Regular UPC data is correct in the View UPCs window:
	    | UPC Number | Container Type | Size Ounces  | Retailer |
		| %UPC87835% | Plastic bag    | 12           | TG       |
	And I close the window that opened

	#And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase87835
	Then I delete the product: TestCase87835


@TestCase:87631
	Scenario: [87631] Universal Product Code (UPC) Step - Add Casepack - Size (Weight Ounces) field validation
	#Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I log in with the account saved in TReVor as: ProductAccount
	Given I generate a random UPC number and save as: UPC87631
	Then The home screen should load
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Then In the Side Menu, click Labeled Link with Add Product title
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration'
	Then in the New Product page, I click Continue
	#Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
	Then I should be on the The Product Page
	And In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Chalk_#87631
	Given In the Product Section, set the option in section: 'Type of Product (select)' to: Chalk
 	Given in the The Product page I click Continue
	Then I save the product information as: TestCase87631
    Given I generate a random UPC number and save as: UPC87631
    Then I save the product information as: TestCase87631
	#Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
    Then I should be on the Product Information Page
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)' to: No
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue
    #Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
    Given I should be on the Physical and Chemical Properties Page
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' should be showing the option: Solid
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' confirm option is selected: Solid
	Then In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
	Then In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Then In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
	Then in the Physical and Chemical Properties page I click Continue
    #And I call Shared Step 29181 (Ingredients - add any chemical) with name: Chlorine
    Then I should be on the Ingredients Page
    And In the Ingredients section, add the following ingredients:
    | SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
    | component name | Chalk       | 100     | False               | False         |             |
    Then in the Ingredients page, I click Continue
	#Then 231938 Inventory Status, Prop 65 (US) - Compliant - Prop 65 (NO)
	Given I should be on the Inventory Status, Prop 65 (US) Page
	Then In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	Then In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page I click Continue
    #Given I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue) for
    #| Retailer  |
    #| Walgreens |
    Then I should be on the Retailer Page
	And In the Retailer Section, click 'Add Retailers' button
	And In the Select Retailers window, select retailer: Amazon
	And In the Select Retailers window, click 'Done' button
	Then in the Retailer page, I click Continue
    Given I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page
    Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, I click the 'Add Casepack' button
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, for section: 'GTIN/UPC (include check digit)' enter the value: saved as UPC87631
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, for section: 'Size (Fluid Ounces)' enter the value: 2
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, for section: 'Container Type' select the value: Plastic Container
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, for section: 'Quantity of Units within the Case' enter the value: abcd
	Given in the Global Trade Item Number (GTIN) / Universal Product Code (UPC) page I click Continue
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, the error: 'Enter a valid Number (no decimals allowed or [+ -] signs)' is displayed for the section: 'Quantity of Units within the Case'
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, for section: 'Quantity of Units within the Case' enter the value: 12.23
	Given in the Global Trade Item Number (GTIN) / Universal Product Code (UPC) page I click Continue
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, the error: 'Enter a valid number (no decimals allowed or {+ -] signs)' is displayed for the section: 'Quantity of Units within the Case'
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, for section: 'Quantity of Units within the Case' enter the value: 5
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, for section: 'Transportation Options' enter the value: 1A2: removable head steel drum
	Given in the Global Trade Item Number (GTIN) / Universal Product Code (UPC) page I click Continue
	Then I check if the Regulatory Documents page is shown
	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase87631
	Then In the Side Menu, click Labeled Link with My Products title
	Then In the Product Grid, delete the product saved as: TestCase87631


@TestCase:87633
Scenario: [87633] Universal Product Code (UPC) Step - Add Casepack - Size (Weight Ounces) field validation
	#Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I log in with the account saved in TReVor as: ProductAccount
	Given I generate a random UPC number and save as: UPC87633
	Then The home screen should load
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Then In the Side Menu, click Labeled Link with Add Product title
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration'
	Then in the New Product page, I click Continue
	#Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
	Then I should be on the The Product Page
	And In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Chalk_#87633
	Given In the Product Section, set the option in section: 'Type of Product (select)' to: Chalk
 	Given in the The Product page I click Continue
	Then I save the product information as: TestCase87633
    Given I generate a random UPC number and save as: UPC87633
    Then I save the product information as: TestCase87633
	#Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
    Then I should be on the Product Information Page
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)' to: No
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue
    #Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
    Given I should be on the Physical and Chemical Properties Page
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' should be showing the option: Solid
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' confirm option is selected: Solid
	Then In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
	Then In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Then In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
	Then in the Physical and Chemical Properties page I click Continue
    #And I call Shared Step 29181 (Ingredients - add any chemical) with name: Chlorine
    Then I should be on the Ingredients Page
    And In the Ingredients section, add the following ingredients:
    | SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
    | component name | Chalk       | 100     | False               | False         |             |
    Then in the Ingredients page, I click Continue
	#Then 231938 Inventory Status, Prop 65 (US) - Compliant - Prop 65 (NO)
	Given I should be on the Inventory Status, Prop 65 (US) Page
	Then In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	Then In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page I click Continue
    #Given I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue) for
    #| Retailer  |
    #| Walgreens |
    Then I should be on the Retailer Page
	And In the Retailer Section, click 'Add Retailers' button
	And In the Select Retailers window, select retailer: Amazon
	And In the Select Retailers window, click 'Done' button
	Then in the Retailer page, I click Continue
	Given I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page
    Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, I click the 'Add Casepack' button
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, for section: 'GTIN/UPC (include check digit)' enter the value: saved as UPC87633
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, for section: 'Container Type' select the value: Plastic Container
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, for section: 'Size (Fluid Ounces)' enter the value: abc
	Given in the Global Trade Item Number (GTIN) / Universal Product Code (UPC) page I click Continue
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, the error: 'This field must be a number.' is displayed for the section: 'Size (Weight Ounces)'
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, for section: 'Size (Fluid Ounces)' enter the value: 1+1
	Given in the Global Trade Item Number (GTIN) / Universal Product Code (UPC) page I click Continue
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, the error: 'This field must be a number.' is displayed for the section: 'Size (Weight Ounces)'
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, for section: 'Size (Fluid Ounces)' enter the value: 2
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, the error: 'This field must be a number.' is not displayed for the section: 'Size (Weight Ounces)'
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, for section: 'Quantity of Units within the Case' enter the value: 5
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, for section: 'Transportation Options' enter the value: 1A2: removable head steel drum
	Given in the Global Trade Item Number (GTIN) / Universal Product Code (UPC) page I click Continue
	Then I check if the Regulatory Documents page is shown
	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase87628
	Then In the Side Menu, click Labeled Link with My Products title
	Then In the Product Grid, delete the product saved as: TestCase87633



@ScenarioId:10145
Scenario: [87718] Universal Product Code (UPC) Step - Collapsed View of Case UPC
#Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
Given I log in with the account saved in TReVor as: ProductAccount
#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Then In the Side Menu, click Labeled Link with Add Product title
Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration'
Then in the New Product page, I click Continue
#Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Bubble solution
#Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bubble solution
Then I should be on the The Product Page
And In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Bubble_solution_#87718
And In the Product Section, set the option in section: 'Type of Product (select)' to: Bubble solution
Then in the The Product page, I click Continue
Given I generate a random UPC number and save as: UPC87718
Then I save the product information as: TestCase87718
And I should see the Product Information Page
#And I call Shared Step 85730 - Product Information - Canada Only - Child (NO), GHS (NO), DSV (NO), PLP(YES), GNFR (NO), Continue
#Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
Given I should see the Product Information Page
Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
Then In the Product Information Section, set the option in section: 'Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)' to: No
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
	
#And I call Shared Step 29181c (Ingredients - add any chemical - For Canada Only) with name: Chlorine
#Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Water
Given I should see the Ingredients Page
Then In the Ingredients section, add component with component name: Glycerin
Then In the Ingredients section, add component with component name: Corn Syrup
Then In the Ingredients section, add component with component name: Water
Then In the Ingredients Table row with component name: Glycerin, in Percent column text input enter: 33.33
Then In the Ingredients Table row with component name: Corn Syrup, in Percent column text input enter: 33.33
Then In the Ingredients Table row with component name: Water, in Percent column text input enter: 33.34
Then in the Ingredients page I click Continue
#Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Then I should be on the Inventory Status, Prop 65 (US) Page
And In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
And In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
Then in the Inventory Status, Prop 65 (US) page, I click Continue
#Given I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue) for
Given I should see the Retailer Page
Given In the Retailer Section, click 'Add Retailers' button
Given In the Select Retailers window, select retailer: Target
Given In the Select Retailers window, click 'Done' button
Given in the Retailer page I click Continue

#Given I call Shared Step 87647 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC109230, container type: Paper bag and size: 2 do not click continue
Given I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page
Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, I click the 'Add Casepack' button
Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, for section: 'GTIN/UPC (include check digit)' enter the value: saved as UPC87718
Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, for section: 'Size (Fluid Ounces)' enter the value: 2
Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, for section: 'Quantity of Units within the Case' enter the value: 5
Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, for section: 'Transportation Options' enter the value: 1A2: removable head steel drum

Then I select the case UPC dropdown arrow to collapse the UPC saved as: UPC87718
Then I check for a truck icon for UPC: saved as UPC87718
Then I check if the case UPC details are collapsed for UPC: saved as UPC87718
Then I confirm a case dropdown contains the following UPC: saved as UPC87718
Then I confirm that the truck icon is displaying next to the case UPC: saved as UPC87718
Then I select the case UPC dropdown arrow to expand the UPC saved as: UPC87718
Then I confirm the Size field is below the Container field
Then I confirm the Quantity field is below the Size field
#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase87718
Then In the Side Menu, click Labeled Link with My Products title
Then I delete the product: TestCase87718



@TestCase:87818
Scenario: [87818] UPC - Case UPC - Individual UPC contained in the Case Pack drop down - none available for selection
#Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
Given I log in with the account saved in TReVor as: ProductAccount
#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Then In the Side Menu, click Labeled Link with Add Product title
Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration'
Then in the New Product page, I click Continue
#Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): After Shave
Then I should be on the The Product Page
And In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: After_Shave_#87818
And In the Product Section, set the option in section: 'Type of Product (select)' to: After Shave
Then in the The Product page, I click Continue
Given I generate a random UPC number and save as: UPC87818
Then I save the product information as: TestCase87818
And I should see the Product Information Page
#And I call Shared Step 85730 - Product Information - Canada Only - Child (NO), GHS (NO), DSV (NO), PLP(YES), GNFR (NO), Continue
Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
Then in the Product Information page I click Continue
#Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' confirm option is selected: Liquid
And In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Liquid
And In the Physical and Chemical Properties Section, for section: 'Relative Density' enter text: 120
Then In the Physical and Chemical Properties Section, set the option in section: 'Relative Density' to: g/ml (grams per milliliter)
And In the Physical and Chemical Properties Section, for section: 'pH' enter text: 8
And In the Physical and Chemical Properties Section, for section: 'Boiling Point (in Celsius)' enter text: 100
Then In the Physical and Chemical Properties Section, for section: 'Flash Point (in Celsius)' enter text: 60
Then In the Physical and Chemical Properties Section, set the option in section: 'Flash Point Testing Method Used' to: Closed cup method
And In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
Then in the Physical and Chemical Properties page, I click Continue
#And I call Shared Step 29181c (Ingredients - add any chemical - For Canada Only) with name: Chlorine
Given I should see the Ingredients Page
Then In the Ingredients section, add component with component name: Ethyl alcohol
Then In the Ingredients section, add component with component name: Witch hazel extract
Then In the Ingredients section, add component with component name: Water
Then In the Ingredients Table row with component name: Ethyl alcohol, in Percent column text input enter: 33.33
Then In the Ingredients Table row with component name: Witch hazel extract, in Percent column text input enter: 33.33
Then In the Ingredients Table row with component name: Water, in Percent column text input enter: 33.34
Then in the Ingredients page I click Continue
Then I should be on the Inventory Status, Prop 65 (US) Page
And In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
And In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
Then in the Inventory Status, Prop 65 (US) page, I click Continue
Then In the Product Labeling Section, in section: 'Refer to your Product Label.  From the options, select those that appear on the Label.' click the checkbox option: None of the Above
Then in the Product Information page I click Continue
Given I should see the Transportation Details 1 Page
Then In the Transportation Details 1 Section, set the option in section: 'Product is Regulated for Transport': to: Yes
Then In the Transportation Details 1 Section, set the option in section: 'Select all modes of transport that you've classified the product for': to: DOT
Then In the Transportation Details 1 Section, set the option for DOT mode of transport to: Shipping with limited quantity
Then in the Transportation Details 1 page I click Continue
And In the U.S. Department of Transportation (DOT) Classification Section, set the option in section: 'UN Number': to: UN1266
Then In the U.S. Department of Transportation (DOT) Classification Section, set the option in section: 'Packing Group': to: II
Then In the U.S. Department of Transportation (DOT) Classification Section, set the option in section: 'Product has a boiling point of <=35⁰C and flash point of >60⁰C. Packing Group selected is not consistent with this data. Verify the data and transportation packing group. If problem persists, please contact Support.': to: Based on defined viscosity parameters, this product is classified as PG III.
Then in the U.S. Department of Transportation (DOT) Classification page, I click Continue
Then In the VOC - Ozone Transport Commission Section, set the option in section: 'Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations.': to: No
Then In the VOC - Ozone Transport Commission Section, set the option in section: 'Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the CARB': to: 5
Then In the VOC - Ozone Transport Commission Section, set the option in section: 'Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the OTC Model Rule': to: 5
Then in the Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB) page, I click Continue	
Then In the Volatile Organic Compound Summary Section, for 'Your acknowledgement of this registration includes that your product..' set 'Yes, I Acknowledge'
Then in the Volatile Organic Compound Summary page, I click Continue	

#Then I call Shared Step  (Select Retailers Canadian Tire and enter additional requirements field - Indicate full name of product, as sold via thisretailer)
Then I should be on the Retailer Page
And In the Retailer Section, click 'Add Retailers' button
And In the Select Retailers window, select retailer: Walgreens
And In the Select Retailers window, click 'Done' button
Then in the Retailer page, I click Continue
#Given I click the 'Add Casepack' button
#Given I add the following into the UPC case fields
#		| UPC Number          | Container Type    | Size | Quantity | Individual Upc Case Pack | Transportation Option |
#		| saved as UPC87818   | Plastic Container | 32   | 123      |                          | 4A: steel box         |
Given I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page
Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, I click the 'Add Casepack' button
Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, for section: 'Internal SKU' enter the value: ABC14789
Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, for section: 'Size (Fluid Ounces)' enter the value: 2
Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, for section: 'Quantity of Units within the Case' enter the value: 5
Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, for section: 'Transportation Options' enter the value: 1A2: removable head steel drum
Then I confirm the Individual UPC field is shown in the Universal Product Code (UPC) Page
Then I confirm Individual UPC field does not display any options
#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase87818
Then In the Side Menu, click Labeled Link with My Products title
Then I delete the product: TestCase87818


		# Created by Saikiran Chittampally
	@TestCase:163564
Scenario: [163564] SHA Automation - Create a Chalk Product and Submit thru Completed Status
	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	Given I generate a random UPC number and save as: UPC163564
#	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Then In the Side Menu, click Labeled Link with Add Product title
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration'
	Then in the New Product page, I click Continue

	Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
	Then I save the product information as: TestCase163564
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

	#Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Water
	Given I should see the Ingredients Page
	Then In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	| component name | Water       | 100     |                     |               |             |
	Then in the Ingredients page I click Continue

	#Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Then I should be on the Inventory Status, Prop 65 (US) Page
	And In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	And In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page, I click Continue

	Given I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue) for
		| Retailer  |
		| Walgreens |
	Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC163564, container type: Metal Container and size: 1
	Given I call Shared Step 78080 (Regulatory Documents to Provide - Upload OSHA SDS)
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
#	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
#	| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
#	| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
	Then I should be on the Safety Data Sheet Authoring - Additional Data (Optional) Page
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Personal Protection Equipment Recommended (select)' to: Mask
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Autoignition Temperature (°C)' enter text: 300
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Minimum Ignition Energy (mJ)' enter text: 1.005
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Viscosity' enter text: 20
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Appearance' to: Black
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor' to: Odorless
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor Threshold' to: No data available
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Partition Coefficient' enter text: 10
	Then in the Safety Data Sheet Authoring - Additional Data (Optional) page, I click Continue


	Given in the Optional Comments page I click Continue
	#Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given I should see the Data Acceptance Page
	Then In the Data Acceptance Section, check 'Agreed' checkbox
	Then In the Data Acceptance Section, click 'Accept' button

	And In the Purchase Summary screen if Product Billing is displayed I click Confirm Order
	And I navigate to the home page
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Submitted Status for saved as: TestCase163564)
	Given I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase163564)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase163564)
	And I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase163564)
	Given I call Shared Step 75347 (WPS Studio - PD+ - set all data and publish using rule and Doc queue - CKLT, NGHS and SBCS) for product saved as: TestCase163564
	And I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase163564)
	Given I call Shared Step 59066 (Go to SHA Manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase163564)
	Given I call Shared Step 51664 (SHA - Accepted Product - set Retailers to Completed for saved as: TestCase163564) for
		| Retailer		|
		| Walgreens		|


@TestCase:209159
Scenario: [209159] UPC Assessment Details - Edit UPC updates - the Added column shows current date
	Given I log in with the account saved in TReVor as: ProductAccount
	Given I generate a random UPC number and save as: UPC209159A
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given In the Side Menu, click Labeled Link with Add Product title
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration'
	Given in the New Product page I click Continue
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
	Then I save the product information as: TestCase209159
	Given I call Shared Step (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	#Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
	Then in the Regulatory Documents to Provide page I click Continue

	#Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I should see the Physical and Chemical Properties Page
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' should be showing the option: Solid
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' confirm option is selected: Solid
	Then In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
	Then In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Then In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
	Then in the Physical and Chemical Properties page I click Continue

	And I call Shared Step 29181c (Ingredients - add any chemical - For Canada Only) with name: Chlorine
	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	#Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Amazon
	Then I should be on the Retailer Page
	And In the Retailer Section, click 'Add Retailers' button
	And In the Select Retailers window, select retailer: Amazon
	And In the Select Retailers window, click 'Done' button
	Then in the Retailer page, I click Continue

	Given I call Shared Step 87641(Enter Universal Product Code - case information) for UPC: saved as UPC209159A, container type: Paper bag and size: 2 and Quantity: 4 and Transportation option: 4A: steel box
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
#	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
#		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient |
#		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | 41.3005               |
	Then I should be on the Safety Data Sheet Authoring - Additional Data (Optional) Page
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Personal Protection Equipment Recommended (select)' to: Gloves
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Autoignition Temperature (°C)' enter text: 501.827328
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Minimum Ignition Energy (mJ)' enter text: 10.00001
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Viscosity' enter text: 10.28
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Appearance' to: Brown
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor' to: Orange
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor Threshold' to: No data available
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Partition Coefficient' enter text: 41.3005
	Then in the Safety Data Sheet Authoring - Additional Data (Optional) page, I click Continue

	#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test data
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	#Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given I should see the Data Acceptance Page
	Then In the Data Acceptance Section, check 'Agreed' checkbox
	Then In the Data Acceptance Section, click 'Accept' button

	Given If purchase details are showing click confirm order
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase209159)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase209159 and its status is: Submitted
	Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase209159)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase209159)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase209159 and its status is: Assigned
	Given I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase209159)
	Given I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase209159)
	Given I call Shared Step 75347 (WPS Studio - PD+ - set all data and publish using rule and Doc queue - CKLT, NGHS and SBCS) for product saved as: TestCase209159
	Given I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase209159)
	Given I call Shared Step 59066 (Go to SHA Manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Accepted Status for saved as: TestCase209159)		
	Given I navigate to the landing page
	Given I log in with the account saved in TReVor as: ProductAccount
	Given I generate a random UPC number and save as: UPC209159
	Given I search for the product saved as: TestCase209159
	When I click Row Actions for the most recent product returned
	Then I click on the Row Action: Edit UPCs	
	And I click Save in The Product Page
	Given I call Shared Step 87647 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC209159, container type: Plastic Container and size: 18 do not click continue
	
	And I click Save in The Product Page
	#And I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given I should see the Data Acceptance Page
	Then In the Data Acceptance Section, check 'Agreed' checkbox
	Then In the Data Acceptance Section, click 'Accept' button

	Given If purchase details are showing click confirm order
	And I navigate to the home page

	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase209159)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase87685 and its status is: Accepted
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Accepted Status for saved as: TestCase209159)
	Then I call Shared Step 134404 (SHA > Select Product > UPC Assessment Details) for product saved as: TestCase209159
	And I confirm the Product UPC window has opened
	Given In the UPC Assessment Details Screen, I Confirm that I see the Product ID saved as: TestCase209159
	Then In the SHA UPC list I should see UPC: saved as UPC209159 in Any Row of the UPC table
	And I close the current window and switch to the main window in Studio
	

	# Created by Saikiran Chittampally
	@TestCase:119633
Scenario: [119633] Case Pack UPC: UPC Becomes Archived, Case UPC Becomes Archived
	Given I log in with the account saved in TReVor as: ProductAccount
	Given I generate a random UPC number and save as: UPC119633
	Given I generate a random UPC number and save as: UPC1196331
	Given I generate a random UPC number and save as: UPC1196332
#	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Then In the Side Menu, click Labeled Link with Add Product title
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration'
	Then in the New Product page, I click Continue

	Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
	Then I save the product information as: TestCase119633
	Given I call Shared Step (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	#Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
	Then in the Regulatory Documents to Provide page I click Continue

	#Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I should see the Physical and Chemical Properties Page
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' should be showing the option: Solid
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' confirm option is selected: Solid
	Then In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
	Then In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Then In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
	Then in the Physical and Chemical Properties page I click Continue

	#Given I call Shared Step 29181 (Ingredients - add any chemical) with name: water
	Given I should see the Ingredients Page
	Then In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	| component name | Water       | 100     |                     |               |             |
	Then in the Ingredients page I click Continue

	
#	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Then I should be on the Inventory Status, Prop 65 (US) Page
	And In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	And In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page, I click Continue

	#Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Walgreens
	Then I should be on the Retailer Page
	And In the Retailer Section, click 'Add Retailers' button
	And In the Select Retailers window, select retailer: Walgreens
	And In the Select Retailers window, click 'Done' button
	Then in the Retailer page, I click Continue

	Given I enter information for Enter Universal Product Code (UPC) - UPC-Container Type - Size Only for UPC: for UPC: saved as UPC119633, container type: Plastic Container and size: 25 - do not click continue
	Given I enter information for Enter Universal Product Code (UPC) - UPC-Container Type - Size Only for UPC: for UPC: saved as UPC1196331, container type: Plastic Container and size: 2 - do not click continue
	And I call Shared Step 87829 (UPC - Add Casepack - All Data > Continue) for UPC: saved as UPC1196332, container type: Plastic Container and size: 1 and Quantity: 1 and Individual Upc Case Pack saved As: UPC119633 and Transportation option: 4A: steel box	

	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
#	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
#	| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
#	| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
	Then I should be on the Safety Data Sheet Authoring - Additional Data (Optional) Page
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Personal Protection Equipment Recommended (select)' to: Mask
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Autoignition Temperature (°C)' enter text: 300
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Minimum Ignition Energy (mJ)' enter text: 1.005
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Viscosity' enter text: 20
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Appearance' to: Black
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor' to: Odorless
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor Threshold' to: No data available
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Partition Coefficient' enter text: 10
	Then in the Safety Data Sheet Authoring - Additional Data (Optional) page, I click Continue

	Given in the Optional Comments page I click Continue
	#Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given I should see the Data Acceptance Page
	Then In the Data Acceptance Section, check 'Agreed' checkbox
	Then In the Data Acceptance Section, click 'Accept' button

	And In the Purchase Summary screen if Product Billing is displayed I click Confirm Order
	And I navigate to the home page
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase119633)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Assigned Status for saved as: TestCase119633)
	Given I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase119633)
	Given I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase119633)
	Given I call Shared Step 75347 (WPS Studio - PD+ - set all data and publish using rule and Doc queue - CKLT, NGHS and SBCS) for product saved as: TestCase119633
	Given I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase119633)
	Given I call Shared Step 59066 (Go to SHA Manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Accepted Status for saved as: TestCase119633)		
	Given I navigate to the landing page
	Given I log in with the account saved in TReVor as: ProductAccount
	Given I search for the product saved as: TestCase119633
	When I click Row Actions for the most recent product returned
	Then I click on the Row Action: Edit UPCs	
	And I click Save in The Product Page
	And I delete UPC saved as: UPC1196331 
	Given I Click Ok in the Delete Rows Warning Popup
	And I click Save in The Product Page
	#And I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given I should see the Data Acceptance Page
	Then In the Data Acceptance Section, check 'Agreed' checkbox
	Then In the Data Acceptance Section, click 'Accept' button

	Given If purchase details are showing click confirm order
	And I navigate to the home page
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase119633 and its status is: Accepted
	Then I call Shared Step 75309 (SHA > Select Product > UPC Retailer and Feed) for product saved as: TestCase119633
	And I confirm the Product UPC window has opened
	Then In the SHA UPC list I should see the case pack asterisk for the UPC: saved as UPC1196331
	And I close the current window and switch to the main window in Studio




	@TestCase:217540
Scenario: [217540]	Registration: Canada only/Canada and US/US only: UPC Level Data
	Given I log in with the account saved in TReVor as: ProductAccount
	Given I generate a random UPC number and save as: UPC217540
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given In the Side Menu, click Labeled Link with Add Product title
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration'
	Given in the New Product page I click Continue	
	#Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
	Then I should see the The Product Page
	Then In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Chalk
	Then In the Product Section, set the option in section: 'Type of Product (select)' to: Chalk
	Given in the The Product page I click Continue	
	#Given I call Shared Step 78879 - Product Information - Canada Only - Child (NO), GHS (NO), DSV (NO), PLP (NO), GNFR (NO), Continue
	Then I should see the Product Information Page
	When In the Product Information Section, Check or Uncheck for the section check: Retailers will be selling my product at their store locations in (select either or both) to : Canada
	When In the Product Information Section, Check or Uncheck for the section uncheck: Retailers will be selling my product at their store locations in (select either or both) to : United States
	When In the Product Information Section, set the option in section: 'Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)' to: No
	When In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	When In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	When In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	When In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page, I click Continue	

	
	#And I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Then I should see the Physical and Chemical Properties Page
	Given In the Physical and Chemical Properties Section, set the option in section: 'Primary Physical State' to: Solid
	Given In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
	Given In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Given In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
	Then in the Physical and Chemical Properties page, I click Continue


	#Given I call Shared Step 29181 (Ingredients - add any chemical) with name: water
	Given I should see the Ingredients Page
	Then In the Ingredients section, add the following ingredients:
		| SearchType     | SearchText | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
		| component name | Water      |  100    | false                | false        | Water    |
	Then in the Ingredients page I click Continue

	#Given I call Shared Step 57911 (Regulatory Information 1 - CEPA only shown - Continue - Happy Path)	
	Then I should see the Inventory Status, Prop 65 (US) Page
	Given In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'Canadian Environmental Protection Act (CEPA) status' to: Compliant with Domestic Substances List (DSL)
	Given In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is exempt from TSCA chemical Inventory listing requirements.
	Given In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page, I click Continue
	
	#Given I call shared step 72414 (Retailer - Canada Only > Select Canadian Tire > Continue - Happy Path)
	Then I should be on the Retailer Page
	And In the Retailer Section, click 'Add Retailers' button
	Then In the Retailer Section is selected retailer: No Retailer/No UPC Product
	And In the Select Retailers window, click 'Done' button
	Then in the Retailer page, I click Continue

	Given I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, I click the Add UPC Button
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, for section: 'Provide the product's UPC(s)- including container type and size (ounces)' enter UPC Number: saved as UPC217540 enter Size: 12 and enter Container Type: Plastic bag

    Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, I click the 'Add Casepack' button
    Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, for section: 'GTIN/UPC (include check digit)' enter the value: saved as UPC87676
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, for section: 'Size (Fluid Ounces)' enter the value: 2
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, for section: 'Container Type' select the value: Aerosol Can - Metal
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, for section: 'Quantity of Units within the Case' enter the value: 5
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, for section: 'Transportation Options' enter the value: 1A2: removable head steel drum
	Given in the Global Trade Item Number (GTIN) / Universal Product Code (UPC) page I click Continue



	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given in the Optional Comments page I click Continue
	#Given I call Shared Step 64097 - Additional Documents -> Contact Information - Add any Name, address, phone and emergency phone - Happy Path
	Given In the Additional Documents -> Contact Information section, for section: 'Manufacturer Name' enter text: Manufacturer
	Given In the Additional Documents -> Contact Information section, for section: 'Address' enter text: Address
	Given In the Additional Documents -> Contact Information section, for section: 'Phone' enter text: Phone
	Given In the Additional Documents -> Contact Information section, for section: 'Emergency Phone' enter text: 1234 8856789
	Given in the Additional Documents page I click Continue	
	#Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
	#	| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient |
	#	| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | 41.3005               |
	Then I should see the Safety Data Sheet Authoring - Additional Data (Optional) Page
	When In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Personal Protection Equipment Recommended (select)' to: Gloves
	When In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Autoignition Temperature (°C)' enter text: 501.827328 
	When In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Minimum Ignition Energy (mJ)' enter text: 10.00001
	When In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Viscosity' enter text: 10.28
	When In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Appearance' to: Brown
	When In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor' to: Orange
	When In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor Threshold' to: No data available
	When In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Partition Coefficient' enter text: 41.3005
	Then I click continue
	Given in the Optional Comments page I click Continue
	#Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given I should see the Data Acceptance Page
	Then In the Data Acceptance Section, check 'Agreed' checkbox
	Then In the Data Acceptance Section, click 'Accept' button

	And If purchase details are showing click confirm order
	And I navigate to the home page	

	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given In the Side Menu, click Labeled Link with Add Product title
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration'
	Given in the New Product page I click Continue	
	#Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
	Then I should see the The Product Page
	Then In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Chalk
	Then In the Product Section, set the option in section: 'Type of Product (select)' to: Chalk
	Given in the The Product page I click Continue	
	Then I should see the Product Information Page
	Then I save the product information as: TestCase217540A	
	Given I generate a random UPC number and save as: UPC217540A
	#Given I call Shared Step (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	When In the Product Information Section, set the option in section: 'Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)' to: No
	When In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	When In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	When In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	When In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page, I click Continue	
	#Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Then I should see the Regulatory Documents to Provide Page	
	When In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
	Then in the Regulatory Documents to Provide page, I click Continue	
	#Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Then I should see the Physical and Chemical Properties Page
	Given In the Physical and Chemical Properties Section, set the option in section: 'Primary Physical State' to: Solid
	Given In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
	Given In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Given In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
	Then in the Physical and Chemical Properties page, I click Continue
	#Given I call Shared Step 29181 (Ingredients - add any chemical) with name: water
	Then In the Ingredients section, add the following ingredients:
		| SearchType     | SearchText | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
		| component name | Water      |  100    | false                | false        | Water    |
	Then in the Ingredients page, I click Continue
	#Given I call Shared Step 104290 (Enter Regulatory Information - TSCA Not Prop 65)
	Then I should see the Inventory Status, Prop 65 (US) Page
	Given In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is exempt from TSCA chemical Inventory listing requirements.
	Given In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page, I click Continue
	#Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Walgreens
	Then I should be on the Retailer Page
	And In the Retailer Section, click 'Add Retailers' button
	And In the Select Retailers window, select retailer: Walgreens
	And In the Select Retailers window, click 'Done' button
	Then in the Retailer page, I click Continue

	Given I enter information for Enter Universal Product Code (UPC) - UPC-Container Type - Size Only for UPC: for UPC: saved as UPC217540A, container type: Plastic bag and size: 2 - do not click continue
	Then I click continue
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	#Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
	#	| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient |
	#	| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | 41.3005               |
	Then I should see the Safety Data Sheet Authoring - Additional Data (Optional) Page
	When In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Personal Protection Equipment Recommended (select)' to: Gloves
	When In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Autoignition Temperature (°C)' enter text: 501.827328 
	When In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Minimum Ignition Energy (mJ)' enter text: 10.00001
	When In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Viscosity' enter text: 10.28
	When In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Appearance' to: Brown
	When In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor' to: Orange
	When In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor Threshold' to: No data available
	When In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Partition Coefficient' enter text: 41.3005
	Then I click continue
	#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test data
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	#Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given I should see the Data Acceptance Page
	Then In the Data Acceptance Section, check 'Agreed' checkbox
	Then In the Data Acceptance Section, click 'Accept' button

	Given If purchase details are showing click confirm order
	And I navigate to the home page

	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given In the Side Menu, click Labeled Link with Add Product title
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration'
	Given in the New Product page I click Continue	
	#Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
	Then I should see the The Product Page
	Then In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Chalk
	Then In the Product Section, set the option in section: 'Type of Product (select)' to: Chalk
	Given in the The Product page I click Continue	
	Then I should see the Product Information Page
	Then I save the product information as: TestCase217540B
	Given I generate a random UPC number and save as: UPC217540B
	#Given I call Shared Step 62678 (Product Information - US & Canada, No Child, No OSHA, NO Direct ship, No PL, No NGFR - Continue, Happy path)
	Then I should see the Product Information Page
	When In the Product Information Section, Check or Uncheck for the section check: Retailers will be selling my product at their store locations in (select either or both) to : Canada
	When In the Product Information Section, set the option in section: 'Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)' to: No
	When In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	When In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	When In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	When In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page, I click Continue	
	#Given I call Shared Step 145129 Regulatory Documents to Provide - Upload AIS and CCCR
	Then I should see the Regulatory Documents to Provide Page	
	When In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
	Then in the Regulatory Documents to Provide page, I click Continue
	#Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Then I should see the Physical and Chemical Properties Page
	Given In the Physical and Chemical Properties Section, set the option in section: 'Primary Physical State' to: Solid
	Given In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
	Given In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Given In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
	Then in the Physical and Chemical Properties page, I click Continue
	#Given I call Shared Step 29181 (Ingredients - add any chemical) with name: water
	Then In the Ingredients section, add the following ingredients:
		| SearchType     | SearchText | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
		| component name | Water      |  100    | false                | false        | Water    |
	Then in the Ingredients page, I click Continue
	#Given I call Shared Step 104276 (Enter Regulatory Information - TSCA, CEPA, Not Prop 65)
	Then I should see the Inventory Status, Prop 65 (US) Page
	Given For Canadian Environmental Protection Act (CEPA) status I select: Compliant with Domestic Substances List (DSL)
	Given In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is exempt from TSCA chemical Inventory listing requirements.
	Given In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page, I click Continue	
	#Given I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue) for
	#	| Retailer |
	#	| CVS      |
	#	| Canadian Tire         |
	Then I should see the Retailer Page
	Given I select the following retailers in the Select Retailers popup list view:
		| Retailer |
		| CVS      |
		| Canadian Tire         |
	Then I click Done in the Select Retailers popup
	Then in the Retailer page, I click Continue
	Given I enter information for Enter Universal Product Code (UPC) - UPC-Container Type - Size Only for UPC: for UPC: saved as UPC217540B, container type: Plastic Container and size: 2 - do not click continue
	Then I click continue
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	#Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
	#	| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient |
	#	| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | 41.3005               |
	Then I should see the Safety Data Sheet Authoring - Additional Data (Optional) Page
	When In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Personal Protection Equipment Recommended (select)' to: Gloves
	When In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Autoignition Temperature (°C)' enter text: 501.827328 
	When In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Minimum Ignition Energy (mJ)' enter text: 10.00001
	When In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Viscosity' enter text: 10.28
	When In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Appearance' to: Brown
	When In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor' to: Orange
	When In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor Threshold' to: No data available
	When In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Partition Coefficient' enter text: 41.3005
	Then I click continue
	Given in the Optional Comments page I click Continue
	#Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given I should see the Data Acceptance Page
	Then In the Data Acceptance Section, check 'Agreed' checkbox
	Then In the Data Acceptance Section, click 'Accept' button

	And If purchase details are showing click confirm order
	And I navigate to the home page	

