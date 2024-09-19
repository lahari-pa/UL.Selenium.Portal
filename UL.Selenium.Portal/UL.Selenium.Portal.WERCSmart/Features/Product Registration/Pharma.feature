@PaymentMethods
@Shared
@Login
@Homepage
@ProductGrid
@ForwardProductRegistration
@NewProduct
@RetailPartners
@Pharma
@StepsPrototype
@DocumentAcceptance
@UPC
@run_Pharma
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:DataAcceptance
@LiquidCoreProduct
@UPC
@StepsPrototype
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:NewProduct
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:ProductInformation
@PhysicalAndChemicalProp
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:TheProduct
@SPLInformation
@Ingredients
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:TransportationRefrigeration
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:TransportationClassification
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:Retailer
@GTINAndUPC
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:RegulatoryDocumentsToProvide
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:PurchaseSummary
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:AdditionalDocumentsToProvide

Feature: Pharma

@TestCase:128085
Scenario: [128085] Pharma - Prescription Pharmaceutical - Aerosol Product

	Given I log in with the account saved in TReVor as: PharmaAccount
	Given I click the Prescription Pharmaceutical icon in the QuickLinks Pane
	Given I generate a random UPC number and save as: UPC128085
	Given I click continue
	Then I should see the Product Type Page
	Then I set 'Product Name' to: Prescription Pharmaceutical, Aerosol
	Then I set 'Type of Product' to: Prescription Pharmaceutical, Aerosol
	Then I click continue
	Given I enter the NDC number: 13630-0089-3
	Then I save the product information as: TestCase128085
	Then I click continue
	Then I click continue
	Given I fill all empty fields in the SPL Information screen
	Then I click continue
	And I set the Secondary Physical State to be: Aerosol
	And I set the pH field to: 5
	And I set the Select the best Water Solubility description to be: Dispersible
	And I set the When the product has a flammable propellant, or contains ingredients with a flash point below 60⁰C then field to: This product is classified as a D001 Hazardous Waste under RCRA (as per Section 13 or 15 of the SDS).
	Then I click continue
	Then I click continue
	Given I fill all empty fields in the Pharma Ingredients screen
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
	| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
	| Nitrogen       | 100     | false               | false       |            |
	Given I set the Should this product be refrigerated for transport or storage? option to: No
	Then I click continue
	Given I set the Is the product regulated for transport (before exceptions or exemptions) option to exactly match: Yes, Agree
	And I set the Select applicable modes of transport for which you classify the product. field to: DOT
	And I select option: Yes, Shipped with Limited quantity under section: Select applicable modes of transport for which you classify the product. and subsection: DOT
	And I select option: Yes, Shipped with Consumer Commodity under section: Select applicable modes of transport for which you classify the product. and subsection: DOT
	Then I click continue
	And I set the UN Number field to: UN1950
	And I set the Proper Shipping Name option to: Aerosols, flammable, n.o.s.
	And I set the Select Hazard Class (if available) option to: 2.1
	Then I click continue
	Given In the Retailers tab, I select the first Vendor option for retailer: Wal-Mart/SAM'S CLUB
	Then I click continue
	Then I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC128085, container type: Aerosol Can - Metal and size: 1
	When I click continue
	When I click continue
	Then Upload Full Product Label (required) (For private label products please upload a generic label that is not retailer-specific.) should be showing the error messages: Document is required: Product Label
	And I call Shared Step 60567 (Upload Product Label only) for section: Upload Full Product Label (required)
	When I click continue
	Given I call Shared Step 59042 (Browse for File > select > click Open - Happy Path) for document type: Upload Full Product Label (required) (For private label products please upload a generic label that is not retailer-specific.) and file: UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf
	When I click continue
	#Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given I should see the Data Acceptance Page
	Then In the Data Acceptance Section, check 'Agreed' checkbox
	Then In the Data Acceptance Section, click 'Accept' button

	And In the Purchase Summary screen I confirm the Purchase Summary header is displayed
	Then In the Thank You screen I confirm the following statement is shown: Thank you for registering your product on WERCSmart for assessment. The retailers may receive your assessment in approximately two (2) business days, if no delays in processing the assessment, and should no data issues arise.
	And I navigate to the home page


@TestCase:127870
Scenario: [127870] Pharma - Tablet or Capsule Count Field is Available for Solid - Solid Gel Consistency

	Given I log in with the account saved in TReVor as: PharmaAccount
	Given I click the Prescription Pharmaceutical icon in the QuickLinks Pane
	Given I generate a random UPC number and save as: UPC127870
	Then In the New Product Section, set the radio option in section: 'Would you like to Create a New Product?': to: Yes, create a new product
	Then in the New Product page, I click Continue
	Given In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Prescription Pharmaceutical, Solid
	Given In the Product Section, set the option in section: 'Type of Product (select)' to: Prescription Pharmaceutical, Solid
 	Given in the Product Type page I click Continue
	Given I should see the Product Information Page
	Then In the Product Information Section, enter the value in section: 'Enter NDC #': 10866-0885-2
	Then In the Product Information Section, verify section: 'Enter NDC #' contains value: (10866-0885-2 - 60 SECOND TASTE CHOCOLATE VANILLA (TOPICAL APF FLUORIDE GEL) GEL [PASCAL COMPANY, INC.]
	Then In the Product Information Section, verify section: 'Product Name' contains value: 60 Second Taste Chocolate Vanilla
	Then In the Product Information Section, verify section: 'Generic Name' contains value: Topical APF Fluoride Gel
	Given in the Product Information page I click Continue
	Given I should see the SPL Information Page
	Then In the SPL Information Section, verify section: 'Manufacturer' contains value: Pascal Company  Inc.
	Then In the SPL Information Section, verify section: 'Prescription Dosage Form' contains value: GEL
	Then In the SPL Information Section, verify section: 'DEA Schedule' contains value: None
	Then In the SPL Information Section, verify section: 'Marketing Category' contains value: Unapproved drug other
	Then In the SPL Information Section, verify section: 'Marketing End Date' contains value: None
	Then In the SPL Information Section, verify section: 'NDA Number' contains value: None
	Then In the SPL Information Section, for section: 'Distributor' enter value: Distributor
	Then I save the product information as: TestCase127870
	Given in the SPL Information page I click Continue
	Given I should see the Product Characteristics Page
	Then In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid Gel Consistency
	Then In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Then In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
	Given in the Product Characteristics page I click Continue
	Given I should see the Ingredients Page
	Then In the Ingredients Section ingredients table, confirm row with component name: Sodium fluoride is displayed
	Then In the Ingredients Table row with component name: Sodium fluoride, in Percent column text input enter: 50
	Then In the Ingredients Section ingredients table, confirm row with component name: Saccharin sodium dihydrate is displayed
	Then In the Ingredients Table row with component name: Saccharin sodium dihydrate, in Percent column text input enter: 50
	Given in the Ingredients page I click Continue
	Given I should see the Transportation - Refrigeration Page
	Then In the Transportation - Refrigeration Section, set the option in section: 'Should this product be refrigerated for transport or storage?' to: No
	Given in the Transportation - Refrigeration page I click Continue
	Given I should see the Transportation Classification Page
	Then In the Transportation Classification Section, set the option in section: 'Is the product regulated for transport (before exceptions or exemptions)' to: No, not regulated
	Given in the Transportation Classification page I click Continue
	Given I should see the Retailer Association Page
	Then In the Retailer Section, for retailer: Wal-Mart/SAM'S CLUB select 'Select Vendor' option: any
	Given in the Retailer Association page I click Continue
	Given I should see the Universal Product Code (UPC) Page
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, I click the Add UPC Button
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, section: 'Tablet or Capsule Count' is displayed
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, for section: 'Tablet or Capsule Count' enter the value: 1234
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, for section: 'Provide the product's UPC(s)- including container type and size (ounces)' enter UPC Number: saved as UPC127870 enter Size: 1 and enter Container Type: Plastic Container
	Given in the Universal Product Code (UPC) page I click Continue
	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase127870
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase127870

@TestCase:127970
Scenario: [127970] Pharma - Regulatory Documents to Provide and Additional Documents to Provide

	Given I log in with the account saved in TReVor as: PharmaAccount
	Given I click the Prescription Pharmaceutical icon in the QuickLinks Pane
	Given I generate a random UPC number and save as: UPC127970
	Then In the New Product Section, set the radio option in section: 'Would you like to Create a New Product?': to: Yes, create a new product
	Then in the New Product page, I click Continue
	Given In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Prescription Pharmaceutical, Solid
	Given In the Product Section, set the option in section: 'Type of Product (select)' to: Prescription Pharmaceutical, Solid
 	Given in the Product Type page I click Continue
	Given I should see the Product Information Page
	Then In the Product Information Section, enter the value in section: 'Enter NDC #': 0002-3228-30
	Then In the Product Information Section, verify section: 'Enter NDC #' contains value: (0002-3228-30 - STRATTERA (ATOMOXETINE HYDROCHLORIDE) CAPSULE [ELI LILLY AND COMPANY ]
	Then In the Product Information Section, verify section: 'Product Name' contains value: Strattera
	Then In the Product Information Section, verify section: 'Generic Name' contains value: Atomoxetine hydrochloride
	Given in the Product Information page I click Continue
	Given I should see the SPL Information Page
	Then In the SPL Information Section, verify section: 'Manufacturer' contains value: Eli Lilly and Company
	Then In the SPL Information Section, verify section: 'Prescription Dosage Form' contains value: CAPSULE
	Then In the SPL Information Section, verify section: 'DEA Schedule' contains value: None
	Then In the SPL Information Section, verify section: 'Marketing Category' contains value: NDA
	Then In the SPL Information Section, verify section: 'Marketing End Date' contains value: None
	Then In the SPL Information Section, verify section: 'NDA Number' contains value: NDA021411
	Then In the SPL Information Section, for section: 'Distributor' enter value: Distributor
	Given in the SPL Information page I click Continue
	Then I save the product information as: TestCase127970
	Given I should see the Product Characteristics Page
	Then In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
	Then In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Then In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
	Given in the Product Characteristics page I click Continue
	Given I should see the Ingredients Page
	Then In the Ingredients Section ingredients table, confirm row with component name: Benzenepropanamine, N-methyl-.gamma.(2-methylphenoxy)-, hydrochloride (1:1), (.gamma.R)- is displayed
	Then In the Ingredients Table row with component name: Benzenepropanamine, N-methyl-.gamma.(2-methylphenoxy)-, hydrochloride (1:1), (.gamma.R)-, in Percent column text input enter: 20
	Then In the Ingredients Section ingredients table, confirm row with component name: Ferric oxide black is displayed
	Then In the Ingredients Table row with component name: Ferric oxide black, in Percent column text input enter: 20
	Then In the Ingredients Section ingredients table, confirm row with component name: Titanium dioxide is displayed
	Then In the Ingredients Table row with component name: Titanium dioxide, in Percent column text input enter: 20
	Then In the Ingredients Section ingredients table, confirm row with component name: SODIUM LAURYL SULFATE is displayed
	Then In the Ingredients Table row with component name: SODIUM LAURYL SULFATE, in Percent column text input enter: 20
	Then In the Ingredients Section ingredients table, confirm row with component name: Gelatin is displayed
	Then In the Ingredients Table row with component name: Gelatin, in Percent column text input enter: 20
	Given in the Ingredients page I click Continue
	Then In the Ingredients Section, I confirm I check the checkbox in the popup view with the following text: The Product Type, Pest Selection, and Ingredients listed are accurate.
	Then In displayed modal, click Confirm footer button
	Then In the Transportation - Refrigeration Section, set the option in section: 'Should this product be refrigerated for transport or storage?' to: No
	Given in the Transportation - Refrigeration page I click Continue
	Given I should see the Transportation Classification Page
	Then In the Transportation Classification Section, set the option in section: 'Is the product regulated for transport (before exceptions or exemptions)' to: No, not regulated
	Given in the Transportation Classification page I click Continue
	Given I should see the Retailer Association Page
	Then In the Retailer Section, for retailer: Wal-Mart/SAM'S CLUB select 'Select Vendor' option: any
	Given in the Retailer Association page I click Continue
	Given I should see the Universal Product Code (UPC) Page
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, I click the Add UPC Button
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, for section: 'Tablet or Capsule Count' enter the value: 1234
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, for section: 'Provide the product's UPC(s)- including container type and size (ounces)' enter UPC Number: saved as UPC127970 enter Size: 1 and enter Container Type: Plastic Container
	Given in the Universal Product Code (UPC) page I click Continue
	Given I should see the Regulatory Documents to Provide Page
	Then in the Regulatory Documents to Provide page I click Continue
	Then In the Regulatory Documents to Provide Section: 'Upload Full Product Label (required) (For private label products please upload a generic label that is not retailer-specific.)' error message should display: Document is required: Product Label
	Then In the Regulatory Documents to Provide Section, upload file in section: 'Upload Full Product Label (required) (For private label products please upload a generic label that is not retailer-specific.)'
	Then in the Regulatory Documents to Provide page I click Continue
	Given I should see the Additional Documents to Provide Page
	Then In the Additional Documents to Provide, section 'Safety Data Sheet (Optional)' is displayed
	Then in the Additional Documents to Provide page I click Continue
	#Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given I should see the Data Acceptance Page
	Then In the Data Acceptance Section, check 'Agreed' checkbox
	Then In the Data Acceptance Section, click 'Accept' button
	Then The Purchase Summary Page is displayed
	Then In the Purchase Summary page message is displayed with text: Thank you for registering your product on WERCSmart for assessment. The retailers may receive your assessment in approximately two (2) business days, if no delays in processing the assessment, and should no data issues arise.
	And I navigate to the home page

@TestCase:128018
Scenario: [128018] Pharma - Forwarding Not Allowed
	Given I log in with the account saved in TReVor as: PharmaAccount
	Given I click the Prescription Pharmaceutical icon in the QuickLinks Pane
	Given I generate a random UPC number and save as: UPC128018
	Then In the New Product Section, set the radio option in section: 'Would you like to Create a New Product?': to: Yes, create a new product
	Then in the New Product page, I click Continue
	Given In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Prescription Pharmaceutical, Solid
	Given In the Product Section, set the option in section: 'Type of Product (select)' to: Prescription Pharmaceutical, Solid
	Given in the Product Type page I click Continue
	Given I should see the Product Information Page
	Then In the Product Information Section, enter the value in section: 'Enter NDC #': 0002-3228-30
	Then In the Product Information Section, verify section: 'Enter NDC #' contains value: (0002-3228-30 - STRATTERA (ATOMOXETINE HYDROCHLORIDE) CAPSULE [ELI LILLY AND COMPANY ]
	Then In the Product Information Section, verify section: 'Product Name' contains value: Strattera
	Then In the Product Information Section, verify section: 'Generic Name' contains value: Atomoxetine hydrochloride
	Given in the Product Information page I click Continue
	Given I should see the SPL Information Page
	Then In the SPL Information Section, verify section: 'Manufacturer' contains value: Eli Lilly and Company
	Then In the SPL Information Section, verify section: 'Prescription Dosage Form' contains value: CAPSULE
	Then In the SPL Information Section, verify section: 'DEA Schedule' contains value: None
	Then In the SPL Information Section, verify section: 'Marketing Category' contains value: NDA
	Then In the SPL Information Section, verify section: 'Marketing End Date' contains value: None
	Then In the SPL Information Section, verify section: 'NDA Number' contains value: NDA021411
	Then In the SPL Information Section, for section: 'Distributor' enter value: Distributor
	Given in the SPL Information page I click Continue
	Then I save the product information as: TestCase128018
	Given I should see the Product Characteristics Page
	Then In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
	Then In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Then In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
	Given in the Product Characteristics page I click Continue
	Given I should see the Ingredients Page
	Then In the Ingredients Section ingredients table, confirm row with component name: Benzenepropanamine, N-methyl-.gamma.(2-methylphenoxy)-, hydrochloride (1:1), (.gamma.R)- is displayed
	Then In the Ingredients Table row with component name: Benzenepropanamine, N-methyl-.gamma.(2-methylphenoxy)-, hydrochloride (1:1), (.gamma.R)-, in Percent column text input enter: 20
	Then In the Ingredients Section ingredients table, confirm row with component name: Ferric oxide black is displayed
	Then In the Ingredients Table row with component name: Ferric oxide black, in Percent column text input enter: 20
	Then In the Ingredients Section ingredients table, confirm row with component name: Titanium dioxide is displayed
	Then In the Ingredients Table row with component name: Titanium dioxide, in Percent column text input enter: 20
	Then In the Ingredients Section ingredients table, confirm row with component name: SODIUM LAURYL SULFATE is displayed
	Then In the Ingredients Table row with component name: SODIUM LAURYL SULFATE, in Percent column text input enter: 20
	Then In the Ingredients Section ingredients table, confirm row with component name: Gelatin is displayed
	Then In the Ingredients Table row with component name: Gelatin, in Percent column text input enter: 20
	Given in the Ingredients page I click Continue
	Then In the Ingredients Section, I confirm I check the checkbox in the popup view with the following text: The Product Type, Pest Selection, and Ingredients listed are accurate.
	Then In displayed modal, click Confirm footer button
	Then In the Transportation - Refrigeration Section, set the option in section: 'Should this product be refrigerated for transport or storage?' to: No
	Given in the Transportation - Refrigeration page I click Continue
	Given I should see the Transportation Classification Page
	Then In the Transportation Classification Section, set the option in section: 'Is the product regulated for transport (before exceptions or exemptions)' to: No, not regulated
	Given in the Transportation Classification page I click Continue
	Given I should see the Retailer Association Page
	Then In the Retailer Section, for retailer: Wal-Mart/SAM'S CLUB select 'Select Vendor' option: any
	Given in the Retailer Association page I click Continue
	Given I should see the Universal Product Code (UPC) Page
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, I click the Add UPC Button
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, for section: 'Tablet or Capsule Count' enter the value: 1234
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, for section: 'Provide the product's UPC(s)- including container type and size (ounces)' enter UPC Number: saved as UPC128018 enter Size: 1 and enter Container Type: Plastic Container
	Given in the Universal Product Code (UPC) page I click Continue
	Then in the Regulatory Documents to Provide page I click Continue
	Then In the Regulatory Documents to Provide Section: 'Upload Full Product Label (required) (For private label products please upload a generic label that is not retailer-specific.)' error message should display: Document is required: Product Label
	Then In the Regulatory Documents to Provide Section, upload file in section: 'Upload Full Product Label (required) (For private label products please upload a generic label that is not retailer-specific.)'
	Then in the Regulatory Documents to Provide page I click Continue
	Given I should see the Additional Documents to Provide Page
	#Then In the Additional Documents to Provide, section 'Safety Data Sheet (Optional)' is displayed
	Then in the Additional Documents to Provide page I click Continue
	#Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given I should see the Data Acceptance Page
	Then In the Data Acceptance Section, check 'Agreed' checkbox
	Then In the Data Acceptance Section, click 'Accept' button
	Then The Purchase Summary Page is displayed
	Then In the Purchase Summary page message is displayed with text: Thank you for registering your product on WERCSmart for assessment. The retailers may receive your assessment in approximately two (2) business days, if no delays in processing the assessment, and should no data issues arise.
	And I navigate to the home page
	Given I call Shared Step 75130 - Bulk Actions - Select Forward Product Registration
	And I enter the text: saved as TestCase128018 in the 'Search by WPS ID or Product Name' field
	And In the Foward Product Registration Screen I should not see product: saved as TestCase128018
	And I navigate to the home page



@TestCase:127847
Scenario: [127847] Pharma - Tablet or Capsule Count Field is Available for Solid - Solid
	Given I log in with the account saved in TReVor as: PharmaAccount
	Given I click the Prescription Pharmaceutical icon in the QuickLinks Pane
	Given I generate a random UPC number and save as: UPC127847
	Then In the New Product Section, set the radio option in section: 'Would you like to Create a New Product?': to: Yes, create a new product
	Then in the New Product page, I click Continue
	Given In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Prescription Pharmaceutical, Solid
	Given In the Product Section, set the option in section: 'Type of Product (select)' to: Prescription Pharmaceutical, Solid
 	Given in the Product Type page I click Continue
	Given I should see the Product Information Page
	Then In the Product Information Section, enter the value in section: 'Enter NDC #': 0002-3228-30
	Then In the Product Information Section, verify section: 'Enter NDC #' contains value: (0002-3228-30 - STRATTERA (ATOMOXETINE HYDROCHLORIDE) CAPSULE [ELI LILLY AND COMPANY ]
	Then In the Product Information Section, verify section: 'Product Name' contains value: Strattera
	Then In the Product Information Section, verify section: 'Generic Name' contains value: Atomoxetine hydrochloride
	Given in the Product Information page I click Continue
	Given I should see the SPL Information Page
	Then In the SPL Information Section, verify section: 'Manufacturer' contains value: Eli Lilly and Company
	Then In the SPL Information Section, verify section: 'Prescription Dosage Form' contains value: CAPSULE
	Then In the SPL Information Section, verify section: 'DEA Schedule' contains value: None
	Then In the SPL Information Section, verify section: 'Marketing Category' contains value: NDA
	Then In the SPL Information Section, verify section: 'Marketing End Date' contains value: None
	Then In the SPL Information Section, verify section: 'NDA Number' contains value: NDA021411
	Then In the SPL Information Section, for section: 'Distributor' enter value: Distributor
	Given in the SPL Information page I click Continue
	Then I save the product information as: TestCase127847
	Given I should see the Product Characteristics Page
	Then In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
	Then In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Then In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
	Given in the Product Characteristics page I click Continue
	Given I should see the Ingredients Page
	Then In the Ingredients Section ingredients table, confirm row with component name: Benzenepropanamine, N-methyl-.gamma.(2-methylphenoxy)-, hydrochloride (1:1), (.gamma.R)- is displayed
	Then In the Ingredients Table row with component name: Benzenepropanamine, N-methyl-.gamma.(2-methylphenoxy)-, hydrochloride (1:1), (.gamma.R)-, in Percent column text input enter: 20
	Then In the Ingredients Section ingredients table, confirm row with component name: Ferric oxide black is displayed
	Then In the Ingredients Table row with component name: Ferric oxide black, in Percent column text input enter: 20
	Then In the Ingredients Section ingredients table, confirm row with component name: Titanium dioxide is displayed
	Then In the Ingredients Table row with component name: Titanium dioxide, in Percent column text input enter: 20
	Then In the Ingredients Section ingredients table, confirm row with component name: SODIUM LAURYL SULFATE is displayed
	Then In the Ingredients Table row with component name: SODIUM LAURYL SULFATE, in Percent column text input enter: 20
	Then In the Ingredients Section ingredients table, confirm row with component name: Gelatin is displayed
	Then In the Ingredients Table row with component name: Gelatin, in Percent column text input enter: 20
	Given in the Ingredients page I click Continue
	Then In the Ingredients Section, I confirm I check the checkbox in the popup view with the following text: The Product Type, Pest Selection, and Ingredients listed are accurate.
	Then In displayed modal, click Confirm footer button
	Given I should see the Transportation - Refrigeration Page
	Then In the Transportation - Refrigeration Section, set the option in section: 'Should this product be refrigerated for transport or storage?' to: No
	Given in the Transportation - Refrigeration page I click Continue
	Given I should see the Transportation Classification Page
	Then In the Transportation Classification Section, set the option in section: 'Is the product regulated for transport (before exceptions or exemptions)' to: No, not regulated
	Given in the Transportation Classification page I click Continue
	Given I should see the Retailer Association Page
	Then In the Retailer Section, for retailer: Wal-Mart/SAM'S CLUB select 'Select Vendor' option: any
	Given in the Retailer Association page I click Continue
	Given I should see the Universal Product Code (UPC) Page
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, I click the Add UPC Button
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, section: 'Tablet or Capsule Count' is displayed
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, for section: 'Tablet or Capsule Count' enter the value: 1234
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, for section: 'Provide the product's UPC(s)- including container type and size (ounces)' enter UPC Number: saved as UPC127847 enter Size: 1 and enter Container Type: Plastic Container
	Given in the Universal Product Code (UPC) page I click Continue
	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase127847
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase127847	

@TestCase:127854
Scenario: [127854] Pharma - Tablet or Capsule Count Field is Available for Solid - Solid Containing Liquid
	Given I log in with the account saved in TReVor as: PharmaAccount
	Given I click the Prescription Pharmaceutical icon in the QuickLinks Pane
	Given I generate a random UPC number and save as: UPC127854
	Then In the New Product Section, set the radio option in section: 'Would you like to Create a New Product?': to: Yes, create a new product
	Then in the New Product page, I click Continue
	Given In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Prescription Pharmaceutical, Solid
	Given In the Product Section, set the option in section: 'Type of Product (select)' to: Prescription Pharmaceutical, Solid
 	Given in the Product Type page I click Continue
	Given I should see the Product Information Page
	Then In the Product Information Section, enter the value in section: 'Enter NDC #': 10866-0885-2
	Then In the Product Information Section, verify section: 'Enter NDC #' contains value: (10866-0885-2 - 60 SECOND TASTE CHOCOLATE VANILLA (TOPICAL APF FLUORIDE GEL) GEL [PASCAL COMPANY, INC.]
	Then In the Product Information Section, verify section: 'Product Name' contains value: 60 Second Taste Chocolate Vanilla
	Then In the Product Information Section, verify section: 'Generic Name' contains value: Topical APF Fluoride Gel
	Given in the Product Information page I click Continue
	Given I should see the SPL Information Page
	Then In the SPL Information Section, verify section: 'Manufacturer' contains value: Pascal Company  Inc.
	Then In the SPL Information Section, verify section: 'Prescription Dosage Form' contains value: GEL
	Then In the SPL Information Section, verify section: 'DEA Schedule' contains value: None
	Then In the SPL Information Section, verify section: 'Marketing Category' contains value: Unapproved drug other
	Then In the SPL Information Section, verify section: 'Marketing End Date' contains value: None
	Then In the SPL Information Section, verify section: 'NDA Number' contains value: None
	Then In the SPL Information Section, for section: 'Distributor' enter value: Distributor
	Given in the SPL Information page I click Continue
	Then I save the product information as: TestCase127854
	Given I should see the Product Characteristics Page
	Then In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid containing liquid
	Then In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Then In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
	Given in the Product Characteristics page I click Continue
	Given I should see the Ingredients Page
	Then In the Ingredients Section ingredients table, confirm row with component name: Sodium fluoride is displayed
	Then In the Ingredients Table row with component name: Sodium fluoride, in Percent column text input enter: 50
	Then In the Ingredients Section ingredients table, confirm row with component name: Saccharin sodium dihydrate is displayed
	Then In the Ingredients Table row with component name: Saccharin sodium dihydrate, in Percent column text input enter: 50
	Given in the Ingredients page I click Continue
	Given I should see the Transportation - Refrigeration Page
	Then In the Transportation - Refrigeration Section, set the option in section: 'Should this product be refrigerated for transport or storage?' to: No
	Given in the Transportation - Refrigeration page I click Continue
	Given I should see the Transportation Classification Page
	Then In the Transportation Classification Section, set the option in section: 'Is the product regulated for transport (before exceptions or exemptions)' to: No, not regulated
	Given in the Transportation Classification page I click Continue
	Given I should see the Retailer Association Page
	Then In the Retailer Section, for retailer: Wal-Mart/SAM'S CLUB select 'Select Vendor' option: any
	Given in the Retailer Association page I click Continue
	Given I should see the Universal Product Code (UPC) Page
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, I click the Add UPC Button
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, section: 'Tablet or Capsule Count' is displayed
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, for section: 'Tablet or Capsule Count' enter the value: 1234
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, for section: 'Provide the product's UPC(s)- including container type and size (ounces)' enter UPC Number: saved as UPC127854 enter Size: 1 and enter Container Type: Plastic Container
	Given in the Universal Product Code (UPC) page I click Continue
	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase127854
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase127854	


@TestCase:127791
Scenario: [127791] Pharma - Retailer Default
	Given I log in with the account saved in TReVor as: PharmaAccount
	Given I click the Prescription Pharmaceutical icon in the QuickLinks Pane
	Given I generate a random UPC number and save as: UPC127791
	Then In the New Product Section, set the radio option in section: 'Would you like to Create a New Product?': to: Yes, create a new product
	Then in the New Product page, I click Continue
	Given In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Prescription Pharmaceutical, Solid
	Given In the Product Section, set the option in section: 'Type of Product (select)' to: Prescription Pharmaceutical, Solid
 	Given in the Product Type page I click Continue
	Given I should see the Product Information Page
	Then In the Product Information Section, enter the value in section: 'Enter NDC #': 10866-0885-2
	Then In the Product Information Section, verify section: 'Enter NDC #' contains value: (10866-0885-2 - 60 SECOND TASTE CHOCOLATE VANILLA (TOPICAL APF FLUORIDE GEL) GEL [PASCAL COMPANY, INC.]
	Then In the Product Information Section, verify section: 'Product Name' contains value: 60 Second Taste Chocolate Vanilla
	Then In the Product Information Section, verify section: 'Generic Name' contains value: Topical APF Fluoride Gel
	Given in the Product Information page I click Continue
	Given I should see the SPL Information Page
	Then In the SPL Information Section, verify section: 'Manufacturer' contains value: Pascal Company  Inc.
	Then In the SPL Information Section, verify section: 'Prescription Dosage Form' contains value: GEL
	Then In the SPL Information Section, verify section: 'DEA Schedule' contains value: None
	Then In the SPL Information Section, verify section: 'Marketing Category' contains value: Unapproved drug other
	Then In the SPL Information Section, verify section: 'Marketing End Date' contains value: None
	Then In the SPL Information Section, verify section: 'NDA Number' contains value: None
	Then In the SPL Information Section, for section: 'Distributor' enter value: Distributor
	Then I save the product information as: TestCase127791
	Given in the SPL Information page I click Continue
	Given I should see the Product Characteristics Page
	Then In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
	Then In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Then In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
	Given in the Product Characteristics page I click Continue
	Given I should see the Ingredients Page
	Then In the Ingredients Section ingredients table, confirm row with component name: Sodium fluoride is displayed
	Then In the Ingredients Table row with component name: Sodium fluoride, in Percent column text input enter: 50
	Then In the Ingredients Section ingredients table, confirm row with component name: Saccharin sodium dihydrate is displayed
	Then In the Ingredients Table row with component name: Saccharin sodium dihydrate, in Percent column text input enter: 50
	Given in the Ingredients page I click Continue
	Given I should see the Transportation - Refrigeration Page
	Then In the Transportation - Refrigeration Section, set the option in section: 'Should this product be refrigerated for transport or storage?' to: No
	Given in the Transportation - Refrigeration page I click Continue
	Given I should see the Transportation Classification Page
	Then In the Transportation Classification Section, set the option in section: 'Is the product regulated for transport (before exceptions or exemptions)' to: No, not regulated
	Given in the Transportation Classification page I click Continue
	Given I should see the Retailer Association Page
	Then In the Retailer Section, following retailers should be displayed:
	| Retailer                   |
	| No Retailer/No UPC Product |
	| Wal-Mart/SAM'S CLUB        |
	Then In the Retailer Section, for retailer: Wal-Mart/SAM'S CLUB select 'Select Vendor' option: any
	Given in the Retailer Association page I click Continue
	Given I should see the Universal Product Code (UPC) Page
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, I click the Add UPC Button
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, verify retailer 'WM' is present under the 'Destination Retailers' column
	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase127791
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase127791




@TestCase:128671
Scenario: [128671] Pharma - Prescription Pharmaceutical - Liquid Core Product

Given I log in with the account saved in TReVor as: PharmaAccount
Given I click the Prescription Pharmaceutical icon in the QuickLinks Pane
Given I generate a random UPC number and save as: UPC127847
Given I click continue
Then I should see the Product Type Page
Then I set 'Product Name' to: Prescription Pharmaceutical with Liquid Core
Then I set 'Type of Product' to: Prescription Pharmaceutical with Liquid Core
Then I click continue
Given I enter the NDC number: 10866-0885-2
Then I save the product information as: TestCase127847
Then I click continue
Then I click continue
Given I fill all empty fields in the SPL Information screen
Then I click continue
#Given I call Shared Step 32931 (Liquid Core Product - select  No - Happy Path)
Given I should see the Liquid Core Product Page
	Then In the Liquid Core Product Section, set the option in section: 'Is there a free liquid in the Product's container that is 10ml or greater?' to: No
	Then in the Liquid Core Product page I click Continue

And I set the Secondary Physical State to be: Solid
And I set the When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5? option to: No
And I set the Select the best Water Solubility description to be: Dispersible
Then I click continue
Then I click continue
Given I fill all empty fields in the Pharma Ingredients screen
Given I add the following ingredients:
		| ComponentName    | Percent |
		| Propane             | 100     |
And I click continue
Given I click the Ok button in the popup view with the following text: The Product Type, Pest Selection, and Ingredients listed are accurate.
  Given In the popup view with the following title: Product Contains Ingredients Typical of a Pesticide I click the Confirm button
Given I set the Should this product be refrigerated for transport or storage? option to: No
Then I click continue
Given I set the Is the product regulated for transport (before exceptions or exemptions) option to exactly match: No, not regulated
Then I click continue
Given In the Retailers tab, I select the first Vendor option for retailer: Wal-Mart/SAM'S CLUB
Then I click continue
Then I call Shared Step 131303 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC127847, container type: Plastic Container, capsule count: 50 and size: 1
When I click continue
When I click continue
Then Upload Full Product Label (required) (For private label products please upload a generic label that is not retailer-specific.) should be showing the error messages: Document is required: Product Label
And I call Shared Step 60567 (Upload Product Label only) for section: Upload Full Product Label (required)
Then I check for the following options in the Additonal Documents to Provide section
| Option                       |
| Safety Data Sheet (Optional) |
When I click continue
Given I call Shared Step 59042 (Browse for File > select > click Open - Happy Path) for document type: Upload Full Product Label (required) (For private label products please upload a generic label that is not retailer-specific.) and file: UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf
When I click continue
#Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
Given I should see the Data Acceptance Page
	Then In the Data Acceptance Section, check 'Agreed' checkbox
	Then In the Data Acceptance Section, click 'Accept' button

And In the Purchase Summary screen I confirm the Purchase Summary header is displayed
Then In the Thank You screen I confirm the following statement is shown: Thank you for registering your product on WERCSmart for assessment. The retailers may receive your assessment in approximately two (2) business days, if no delays in processing the assessment, and should no data issues arise.
Then In the Purchase Summary screen I click Confirm Order
Then In the Thank You screen I click Home
#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase127847
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase127847





@TestCase:128677
Scenario: [128677] Pharma - Prescription Pharmaceutical - Liquid Product

Given I call Shared Step (Login to WERCSmart - Pharma Account)
Given I click the Prescription Pharmaceutical icon in the QuickLinks Pane
Given I generate a random UPC number and save as: UPC128677
Given I click continue
Then I should see the Product Type Page
Then I set 'Product Name' to: prescription pharmaceutical, solid
Then I set 'Type of Product' to: prescription pharmaceutical, solid
Then I click continue
Given I enter the NDC number: 10866-0885-2
Then I save the product information as: TestCase128677
Then I click continue
Then I click continue
Given I fill all empty fields in the SPL Information screen
Then I click continue
Given I set the Secondary Physical State field to: Liquid
And I set the When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5? option to: No
Given I set the Select the best Water Solubility description field to: Dispersible
Then I click continue
Then I click continue
Given I fill all empty fields in the Pharma Ingredients screen
Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
	| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
	| Propane       | 100     | false               | false       |            |
Given I set the Should this product be refrigerated for transport or storage? option to: No
Then I click continue
Given I set the Is the product regulated for transport (before exceptions or exemptions) option to: Yes, Agree
Given I call Shared Step 130543 (Transport - Pharma Flow - Select DOT & Limited Shipping - No Continue)
Then I click continue
Given I call Shared Step 130542 (UN Number - Pharma Flow - enter UN1950 select Aerosol & Haz class, confirm Packing group - Continue)
Given In the Retailers tab, I select the first Vendor option for retailer: Wal-Mart/SAM'S CLUB
Then I click continue
Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC128677, container type: Plastic Container and size: 1
When I click continue
When I click continue
Then Upload Full Product Label (required) (For private label products please upload a generic label that is not retailer-specific.) should be showing the error messages: Document is required: Product Label
And I call Shared Step 60567 (Upload Product Label only) for section: Upload Full Product Label (required)
When I click continue
Given I call Shared Step 59042 (Browse for File > select > click Open - Happy Path) for document type: Upload Full Product Label (required) (For private label products please upload a generic label that is not retailer-specific.) and file: UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf
When I click continue
#Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
Given I should see the Data Acceptance Page
	Then In the Data Acceptance Section, check 'Agreed' checkbox
	Then In the Data Acceptance Section, click 'Accept' button

Then In the Subscription Issue screen I confirm the following statement is shown: This order cannot be processed due to an issue with your subscription. You may need to upgrade to process this registration.
And I navigate to the home page


@TestCase:128134
Scenario: [128134] Pharma -  Product in Recertification
Given I call Shared Step (Login to WERCSmart - Pharma Account)
Given I click the Prescription Pharmaceutical icon in the QuickLinks Pane
Given I generate a random UPC number and save as: UPC128134
Given I click continue
Given I call Shared Step 57500a (Prescription Pharmaceutical - The Product- Enter name, select product type - Continue - Happy Path): prescription pharmaceutical, solid
Given I enter the NDC number: 10866-0885-2
Then I save the product information as: TestCase128134
Then I click continue
Then I click continue
Given I fill all empty fields in the SPL Information screen
Then I click continue
And I set the Secondary Physical State to be: Solid
And I set the When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5? option to: No
And I set the Select the best Water Solubility description to be: Dispersible
Then I click continue
Then I click continue
Given I fill all empty fields in the Pharma Ingredients screen
Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
	| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
	| Propane       | 100     | false               | false       |            |
Given I set the Should this product be refrigerated for transport or storage? option to: No
Then I click continue
Given I set the Is the product regulated for transport (before exceptions or exemptions) option to exactly match: No, not regulated
Then I click continue
Given In the Retailers tab, I select the first Vendor option for retailer: Wal-Mart/SAM'S CLUB
Then I click continue
Then I call Shared Step 131303 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC128134, container type: Plastic Container, capsule count: 50 and size: 1

Given I call Shared Step (Browse for File > select > click Open - Happy Path) for document type: Upload Full Product Label and file: UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf
Then I click continue
Then I check for the following options in the Additonal Documents to Provide section
| Option                       |
| Safety Data Sheet (Optional) |
Given I call Shared Step 59042 (Browse for File > select > click Open - Happy Path) for document type: Safety Data Sheet and file: UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf
Then I click continue
#Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
Given I should see the Data Acceptance Page
	Then In the Data Acceptance Section, check 'Agreed' checkbox
	Then In the Data Acceptance Section, click 'Accept' button

And In the Purchase Summary screen I confirm the Purchase Summary header is displayed
Then In the Thank You screen I confirm the following statement is shown: Thank you for registering your product on WERCSmart for assessment. The retailers may receive your assessment in approximately two (2) business days, if no delays in processing the assessment, and should no data issues arise.
And I navigate to the home page
Given I call Shared Step 75130 - Bulk Actions - Select Forward Product Registration
And I enter the text: saved as TestCase128134 in the 'Search by WPS ID or Product Name' field
And In the Foward Product Registration Screen I should not see product: saved as TestCase128134
And I click the Home navigation icon and accept the alert popup 

Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Submitted Status for saved as: TestCase128134)
Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase128134)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Assigned Status for saved as: TestCase128134)
Given I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase128134)
And I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase128134)
Given I call Shared Step 79500 (WPS Studio - PD+ - set all data and publish using rule and doc queue - CKLT and SBCS only) for product saved as: TestCase128134
Given I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase128134)
Given I call Shared Step 59066 (Go to SHA Manager)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Accepted Status for saved as: TestCase128134)
Given I call Shared Step 51664 (SHA - Accepted Product - set Retailers to Completed for saved as: TestCase128134) for
		| Retailer |
		| Wal-Mart/SAM'S CLUB      |
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Completed Status for saved as: TestCase128134)
And I call Shared Step Completed Product - Add Recert reason 20 for product saved as: TestCase128134
Given I navigate to the landing page
Given I call Shared Step (Login to WERCSmart - Pharma Account)
And I filter for the product saved as: TestCase128134
And I click Row Actions for the first product returned

And I click on the Row Action: Update Required
And I set the Secondary Physical State to be: Solid spray
And I click Save in The Product Page
Given In the New Product page I click tab: Retailer Association
And I click the page heading: Universal Product Code (UPC)
And I click Save in The Product Page
Then Tablet or Capsule Count should not be showing the error messages on upc screen: This is a required field.
And I click Save in The Product Page
Given I call Shared Step (Browse for File > select > click Open - Happy Path) for document type: Upload Full Product Label (required) (For private label products please upload a generic label that is not retailer-specific.) and file: UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf
And I click Save in The Product Page
And I click the page heading: Data Acceptance
#Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
Given I should see the Data Acceptance Page
	Then In the Data Acceptance Section, check 'Agreed' checkbox
	Then In the Data Acceptance Section, click 'Accept' button

And In the Purchase Summary screen I confirm the Purchase Summary header is displayed
Then In the Thank You screen I confirm the following statement is shown: Thank you for registering your product on WERCSmart for assessment. The retailers may receive your assessment in approximately two (2) business days, if no delays in processing the assessment, and should no data issues arise.
And I navigate to the home page
And I filter for the product saved as: TestCase128134
Given I Confirm the product retailers appear in orange - Assessment in Progress status
