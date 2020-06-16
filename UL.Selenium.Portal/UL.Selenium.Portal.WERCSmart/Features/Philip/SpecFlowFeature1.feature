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
@SHA
@UPC
@run_AdditionalProductInformation
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
@SHA
@CreateProducts
@ForwardProductRegistration
@PaymentMethods
@ProductSetUp
@run_AccountHasStewardshipInfo
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
@Studio
@SHA
@UPC
@run_StwdInWpsStudiofeature
@Philip
@Shared
@NewProduct
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
@ProductSetUp
@SHA
@Studio
@ForwardProductRegistration
@ProductSetUp
@SupplierReports
@CreateProducts
@ViewUpcs
@Solutions
@run_NotIncludedGeneralTests
@Shared
@NewProduct
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
@ProductSetUp
@SHA
@Studio
@ForwardProductRegistration
@ProductSetUp
@SupplierReports
@CreateProducts
@ViewUpcs
@Solutions
@run_NotIncludedGeneralTests
@Shared
@NewProduct
@Homepage
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
@UPC
@ReviewDocuments
@SHA
@MyMessages
@run_MyMessages
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
@UPC
@ReviewDocuments
@SHA
@MyMessages
@run_MyMessages
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
@PaymentMethods
@SHA
@CreateProducts
@Studio
@ProductSetUp
@ProductGrid
@Shared
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
@Portal_ULSC
@ULSC
@Shared
@Pharma
@run_Transportation

Feature: ChooseGoodGuide.com Scenarios

#Philip - Get back to 58430

Scenario: [128085] Pharma - Prescription Pharmaceutical - Aerosol Product

Given I call Shared Step (Login to WERCSmart - Pharma Account)
Given I click the Prescription Pharmaceutical icon in the QuickLinks Pane
Given I generate a random UPC number and save as: UPC127970
Given I click continue
Then I should see the Product Type Page
Then I set 'Product Name' to: Prescription Pharmaceutical, Aerosol
Then I set 'Type of Product' to: Prescription Pharmaceutical, Aerosol
Then I click continue
Given I enter the NDC number: 13630-0089-3
Then I save the product information as: TestCase127870
Then I click continue
Then I click continue
Given I fill all empty fields in the SPL Information screen
Then I click continue
And I set the Secondary Physical State to be: Aerosol
And I set the pH field to: 5
And I set the Select the best Water Solubility description to be: Very soluble
And I set the When the product has a flammable propellant, or contains ingredients with a flash point below 60⁰C then field to: This product is classified as a D001 Hazardous Waste under RCRA (as per Section 13 or 15 of the SDS).
Then I click continue
Then I click continue
Given I fill all empty fields in the Pharma Ingredients screen
Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
	| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
	| Propane       | 100     | false               | false       |            |
Given I set the Should this product be refrigerated for transport or storage? option to: No
Then I click continue
Given I set the Is the product regulated for transport (before exceptions or exemptions) option to exactly match: Yes, Agree
And I set the Select applicable modes of transport for which you classify the product. field to: DOT
And I select option: Yes, Shipped with Limited quantity under section: Select applicable modes of transport for which you classify the product. and subsection: DOT
And I select option: Yes, Shipped with Consumer Commodity under section: Select applicable modes of transport for which you classify the product. and subsection: DOT
Then I click continue
Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)
Given In the Retailers tab, I select the first Vendor option for retailer: Wal-Mart/SAM'S CLUB
Then I click continue
Then I call Shared Step 131303 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC127970, container type: Plastic Container, capsule count: 50 and size: 1
When I click continue
When I click continue
Then Upload Full Product Label (required) (For private label products please upload a generic label that is not retailer-specific.) should be showing the error messages: Document is required: Product Label
And I call Shared Step 60567 (Upload Product Label only) for section: Upload Full Product Label (required)
When I click continue
Given I call Shared Step 59042 (Browse for File > select > click Open - Happy Path) for document type: Upload Full Product Label (required) (For private label products please upload a generic label that is not retailer-specific.) and file: C:\Dependencies\WERCSmart\testdoc.pdf
When I click continue
When I click continue
Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
And In the Purchase Summary screen I confirm the Purchase Summary header is displayed
Then In the Thank You screen I confirm the following statement is shown: Thank you for registering your product on WERCSmart for assessment. The retailers may receive your assessment in approximately two (2) business days, if no delays in processing the assessment, and should no data issues arise.
And I navigate to the home page

# Click on Prescription Pharmaceutical Icon
# New Product - Selected by default "Yes, Create a New Product"
# Click CONTINUE
# Product Type: Enter a Product Name
# Product Type:  Prescription Pharmaceutical, Aerosol
# Click CONTINUE
# In Product Information screen, for the NDC
#, copy and paste 13630-0089-3 and select it, Product Name and Generic Name get populated, click Continue
# In SPL Information screen - Confirm the fields are automatically populated, if a field is not populate (for example the Distributor field, fill it in) - click continue
# In Product Characteristics for secondary state drop down select- Aerosol
# For the pH type in a number between 1-14
# Select the best Water Solubility description from the drop down
# For question: "When the product has a flammable propellant, or contains ingredients with a flash point below 60⁰C then," select any of the three options available
# Click Continue

# The Ingredients get populated automatically, fill in the percentages for each ingredient - click Continue
# Select No for question: "Should this product be refrigerated for transport or storage?"
# Confirm only the 'Yes, Agree' Radio Button is available for the "Is the product regulated for transport" question
# Select The "DOT" checkbox,
# Select the checkbox : Shipping with Limited quantity and Shipping with Consumer Commodity
# Click Continue
Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)
# In Retailer Association section select a Vendor from the drop down for  Wal-Mart/SAM'S CLUB
# Click Continue
# In the Universal Product Code (UPC) section click +Add UPC button
Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC«upc», container type: Aerosol Can and size: 12
# Click Continue in the Regulatory Documents to Provide
# Confirm an error message shows: "Document is required: Product Label"
# Click Browse for the upload a "Product Label" file
# Find and select a PDF type document, click open; file uploads
# Click Continue; Additional Documents to Provide section shows
# Safety Data Sheet and Transportation Exemption Letter or Special Permit options should be available, but not required
# Click Continue, Data Acceptance sections appears
Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
# Purchase Summary page is shown with the following message: "Thank you for registering your product on WERCSmart for assessment. The retailers may receive your assessment in approximately two (2) business days, if no delays in processing the assessment, and should no data issues arise."
# Click Home button



Scenario: [129793] Advanced Reporting - Last 30 Days, Random Product for Reviewer

Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
Then I select the: Last 30 Days, Random Product for Reviewer report from Advanced Reporting in SHA
Then I Check that the Description Text for the Report: Last 30 Days, Random Product for Reviewer is shown as: 20 Random Products for a Reviewer in the Last 30 Days
Then I wait for the Advanced Reporting Preparing Report popup to disappear
Given I confirm that an excel file is produced called Last 30 Days, Random Product for Reviewer.xls and save as 125585
Then I confirm that the excel file saved as: 125585 contains the following columns:
| Column              |
| ID                  |
| Product Name        |
| Reviewer            |
| Last Published Date |
Then I delete the Advanced Report file saved as 125585
# Need to add a shared step for Populating the reviewer input field. Input with the automation account (might need to use amandac) and click submit



Scenario: [128920] Electronics - Dollar Tree/Family Dollar Retailers Available for Selection

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Stereo Equipment / Radio, Not Portable, No Battery Included
Then I save the product information as: TestCase60671
Given I call Shared Step 60935 Additional Product Information - US - Direct Ship - Private Label Only
Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
Given I call Shared Step 61449 Toxicity Characteristic Leaching Procedure (TCLP) - select No to all - Click Continue - Happy Path
Given I call Shared Step 58189 Answer Electronic Equipment questions - With Cathode Ray - No to all
Given I select the following retailers in the Select Retailers popup list view:
		| Retailer                                                 |
		| Dollar Tree Stores, Inc. / Greenbrier International, Inc |
		| Family Dollar                                            |
Then I click Done on Select Retailers window
Then I confirm the following retailers are showing in the Retailer page
		| Retailer												   |
		| Dollar Tree Stores, Inc. / Greenbrier International, Inc |
		| Family Dollar                                            |
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase60671


Scenario: [128769] Battery Product - Dollar Tree/ Family Dollar Retailers Available for Selection

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load
Given I generate a random UPC number and save as: UPC59273
Given I delete all products with UPC Number: saved as UPC59273
Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Alkaline battery
Then I save the product information as: TestCase59273
Given I call Shared Step 59927 (Primary Physical State > Solid only available – Without Water Solubility question)
Given I should see the Additional Product Information Page
Given I call Shared Step 102767 (Additional Product Information (Battery flow - not Lithium) - OSHA (No), DSV (No), PLP (No), GNFR (No))
Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
| CASNumber | ComponentName       | Percent | PublicallyDisclosed | PublicName | TradeSecret |
|           | Potassium hydroxide | 20.5    | false               |            | false       |
|           | Zinc chloride       | 9.5     | false               |            | false       |
|           | Aqua                | 70      | false               |            | false       |
Given I call Shared Step 57637 (Regulatory Information 1 - TSCA & CEPA shown, No to PROP 65 - Continue - Happy Path)
Given I select the following retailers in the Select Retailers popup list view:
		| Retailer                                                 |
		| Dollar Tree Stores, Inc. / Greenbrier International, Inc |
		| Family Dollar                                            |
Then I click Done on Select Retailers window
Then I confirm the following retailers are showing in the Retailer page
		| Retailer												   |
		| Dollar Tree Stores, Inc. / Greenbrier International, Inc |
		| Family Dollar                                            |
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase59273


Scenario: [128694] DSV Option Available for Electronic - Peripherals - RU001162

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Peripherals (Keyboard, Mouse, Trackball) without Battery
Then I confirm that the the option: United States is checked for the following section: Select countries the product may be sold in
Then I confirm that the following section is available for selection: Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase60671


Scenario: [128721] DSV Option Available for Appliance - Hot Water Tank (Standard, no electronic components) - RU001206

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Appliance - Hot Water Tank (Standard, no electronic components)
Then I confirm that the the option: United States is checked for the following section: Select countries the product may be sold in
Then I confirm that the following section is available for selection: Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase60671


Scenario: [128703] DSV Option Available for Auto Parts - Engine Parts and Components with Electrical Parts -  RU001428

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Engine Parts and Components with Electrical Parts
Then I confirm that the the option: United States is checked for the following section: Select countries the product may be sold in
Then I confirm that the following section is available for selection: Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase60671


Scenario: [133610] Formulation Screen:  Attestation Reset on Data Change

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561a (The Product - Enter Product Name: TRAP AND/OR BAIT STATION TEST PRODUCT and select Type of Product): Trap and/or Bait Station
Given I set the Primary Physical State option to: Solid
Given I set the Secondary Physical State option to: Solid
Given I set the When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5? option to: No
Then I click continue
Given I set the Which one best describes your product option to: Product is not considered a pesticide product
Then I confirm that the the option: United States is checked for the following section: Select countries the product may be sold in
Given I set the Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada) option to: No
Given I set the Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns. option to: No

Then I click continue
Then I add the following ingredients:
| ComponentName	| Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Glutens       | 100     | false               | false       |            |
 Then I click continue
Then I confirm I check the checkbox in the popup view with the following text: The Product Type, Pest Selection, and Ingredients listed are accurate.
Then In the popup view with the following title: Product Contains Ingredients Typical of a Pesticide I click the Confirm button
 Then I click continue
# For the question 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?  - Select 'NO'
# Click 'CONTINUE'
# In the 'Additional Product Information Page'
# CONFIRM the 'Additional Product Information Page' displays the Question "Which one best describes your product"
# Select the Radio Button Option - "Product is not considered a pesticide product"
# CONFIRM that by default the "United States" checkbox is selected
# Select 'NO' for the rest of the questions listed in the 'Additional Product Information Page'
# Click 'CONTINUE'
# In the 'INGREDIENTS SCREEN' enter the following CAS Numbers
# 66071-96-3 - Glutens, corn @ 100%
# Click 'CONTINUE'
# CONFIRM that you are prompted with the 'PRODUCT CONTAINS INGREDIENTS TYPICAL OF A PESTICIDE' Message Box
# CONFIRM that the Component is marked as 'ACTIVE'
# Click on the 'GO BACK BUTTON'
# CONFIRM that transitions back to the 'INGREDIENTS PAGE'
# Do not make any changes to the Components - leave them as is
# Click on the 'PRODUCT TYPE' Tab
# Click on 'THE PRODUCT' Edit Pencil Icon
# CONFIRM it transitions back to 'THE PRODUCT' PAGE
# Edit the Product Name to 'RESET PRODUCT'
# Change the 'TYPE OF PRODUCT' TO:  Chalk
# Click 'CONTINUE'
# In the Product Characteristics Page -  By default 'SOLID' is selected as a Primary Physical State
# Select SOLID for Secondary Physical State
# For the question 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?  - Select 'NO'
# Click on the 'Water Solubility description' drop-down and select Soluble in Water
# Click 'CONTINUE'
# CONFIRM that it transitions to the 'Additional Product Information Page'
# CONFIRM that the Pesticide Section in the Additional Product Information Page shows
# CONFIRM that the first question is the 'Select countries the product may be sold in'
# Select 'NO' for the rest of the questions in the Page
# Click 'CONTINUE'
# Transitions to the 'INGREDIENTS Page'
# Click 'CONTINUE' on the 'INGREDIENTS' Page
# CONFIRM that you are NOT prompted with the window message 'Product Contains Ingredients Typical of a Pesticide'
# By changing the Product Type - the flow should reset and no longer show the Pesticide Information
#Continues onto the 'Waste Classification Data' Page
Given I click the Home navigation icon
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: Pesticide Testing Product
