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
@ProductSetUp
@ForwardProductRegistration
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:NewProduct
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:Product
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:ProductInformation
@PhysicalAndChemicalProp
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:InventoryStatusProp65
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:Retailer
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:AdditionalDocumentsToProvide
@@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:InternationalMarineClassification
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:OptionalComments
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:RegulatoryDocumentsToProvide
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:TheProduct
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:AdditionalDocumentsToProvide
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:TransportationDetails1
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:TransportationDetails2
@GTINAndUPC
@Ingredients
@run_DuplicateUPC
@StepsPrototype
@RegulatoryInformation3
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:DataAcceptance
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:Summary
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:PurchaseSummary

Feature: Duplicate UPC



#Background:
#	Given I verify the following users exist and if not I create them using SHAUser
#		| username    | FirstName | LastName   | Role         | EmailAddress                |
#		| SHAQAAuto9  | QA        | Automation | QA Reviewers | qasha.kxxyxunf@mailosaur.io |

# Assigned to Abbie Zullo
# Created by Abbie Zullo
# Test case can be found at the following paths:
# NetProjects10\WercsSmart Portal\WERCSmart\Product Registration\UPC
#Removed from regression: 2024/09
@ignore
@TestCase:91076
Scenario: [91076] Duplicate UPC is not permitted within account - New Product registration - single UPC

    #Logging in as the correct user
	#Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I log in with the account saved in TReVor as: ProductAccount

	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Given in the New Product page I click Continue

	#Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Seasonings, Spices or Flavoring for Food - Salts (Liquid)
	Given I should see the The Product Page
	Given In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Chalk_#91076
	Given In the Product Section, set the option in section: 'Type of Product (select)' to: Chalk
 	Given in the The Product page I click Continue
    Then I save the product information as: TestCase91076

	#And I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Given I should see the Product Information Page
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)' to: No
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue

	And I should see the Regulatory Documents to Provide Page
	Given In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
	Then in the Regulatory Documents to Provide page I click Continue

	#And I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
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

	#And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	Given In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Given in the Inventory Status, Prop 65 (US) page I click Continue

	#And I call Shared Step 75146 (Retailer - Select One or More Retailers that DO NOT REQUIRE Vendor ID or Additional UPC Information, Click Done, Click Continue)
	Given I should see the Retailer Page
	Given In the Retailer Section, click 'Add Retailers' button
	Given In the Select Retailers window, select retailer: Target
	Given In the Select Retailers window, click 'Done' button
	Given in the Retailer page I click Continue

	And I navigate to the home page
	And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase91076

@singlerun
@TestCase:82536
Scenario: [82536] Soap (Bar, Liquid) for Body (RU000211) - GTIN/UPC - Verify Duplicate UPCs Cannot be Saved
	Given I generate: 5 random UPC numbers and save them starting with: RandomUPC
	#Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I log in with the account saved in TReVor as: ProductAccount
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Given in the New Product page I click Continue
	And I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Soap (Bar, Liquid) for Body
	Then I save the product information as: TestCase82536
	And I click continue
	Given I should see the Product Information Page
	#252868 Product Information - Applicable Only to Type of Product:  Soap (Bar, Liquid) for Body (RU000211)
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)' to: No
	Given In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Given In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Given In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Given In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Given I click continue
	#Given I call Shared Step 252869 Physical and Chemical Properties - Applicable Only to Type of Product:  Soap (Bar, Liquid) for Body (RU000211)
	And I should only see the following options for Primary Physical State:
		| State  |
		| Liquid |
		| Solid  |
	Given In the Physical and Chemical Properties Section, set the option in section: 'Primary Physical State' to: Liquid
	Given In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Liquid
	Then In the Physical and Chemical Properties Section, set the option in section: 'Relative Density' to: lb./gal. (pounds per gallon)
	Then In the Physical and Chemical Properties Section, for section: 'Relative Density' enter text: 3588.55
	Then In the Physical and Chemical Properties Section, for section: 'pH' enter text: 9.2
	Then In the Physical and Chemical Properties Section, for section: 'Boiling Point (in Celsius)' enter text: 97
	Then In the Physical and Chemical Properties Section, for section: 'Flash Point (in Celsius)' select the checkbox option: 'I do not have exact Flash Point data available to me'
	Then In the Physical and Chemical Properties Section, set the option in section: 'Flash Point (in Celsius)' to: None, No Flash Point
	Given In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
	Given I click continue
	#And I call Shared Step 252876 Ingredients - Applicable Only to the Type of Product:  Soap (Bar, Liquid) for Body (RU000211)
	Given I should see the Ingredients Page
	Then In the Ingredients section, add component with component name: Sodium cocoate
	Then In the Ingredients Table row with component name: Sodium cocoate, in Percent column text input enter: 100
	Then In the Ingredients Table row with component name: Sodium cocoate, in Publicly Disclosed? column set checkbox to checked
	Then In the Ingredients Table row with component name: Sodium cocoate, in Public Name column select option Soap, coconut oil
	Given I click continue
	#239830 Inventory Status, Prop 65 (US) - TSCA (EXEMPT) / Prop 65 (NO) - (General Shared-Step)
	Given I should see the Inventory Status, Prop 65 (US) Page
	Then In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is exempt from TSCA chemical Inventory listing requirements.
	Then In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Given I click continue
	#252877 Regulatory Information 3 - Applicable Only to Type of Product:  Soap (Bar, Liquid) for Body (RU000211)
	Given I should see the Product Labeling Page
	Given I click continue
	Then In the Product Labeling Section, the error 'Please select at least one option from above.' is displayed for section 'Refer to your Product Label. From the options, select those that appear on the Label.'
	Then In the Product Labeling Section, in section: 'Refer to your Product Label.  From the options, select those that appear on the Label.' displayed options are:
	| Option                 |
	| Drug Facts Panel       |
	| Supplement Facts Panel |
	| Nutrition Facts Panel  |
	| None of the Above      |
	Then In the Product Labeling Section, in section: 'Refer to your Product Label.  From the options, select those that appear on the Label.' click the checkbox option: None of the Above
	Then In the Product Labeling Section, the following link: OTC Drug Facts Label (may include Active Ingredient) should be displayed
	Then In the Product Labeling Section, the following link: Nutritional and Supplement Labels should be displayed
	Then In the Product Labeling Section, the following link: Dietary Supplements Label should be displayed
	Given I click continue
	#And I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Amazon
	Given I should see the Retailer Page
	Then In the Retailer Section, click 'Add Retailers' button
	Then In the Select Retailers window, select retailer: Target
	Then In the Select Retailers window, click 'Done' button
	Then in the Retailer page I click Continue
	Given I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, click 'sample file' link to download file
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, confirm 'sample file' is downloaded and save as: test82536
	And I edit the testdoc.xlsx, and save its filepath as: Bulktest82536 and verify it contains the UPC data in the table saved as: UPCTable82536, (Base Data Only: true)
		| UPC          | Name    | Quantity | Size | Net Explosive Mass | US: Part Number | US: Item Number | GP: Part Number | SP: Part Number | TG: DPCI    | HD: OMSID | CT: Item Number   | Green Good Housekeeping | Green Seal | EPA Safer Choice | Cradle to Cradle | UL Ecologo | EWG Verified | Green Tick | Madesafe | NSF Sustainability Certified |
		| %RandomUPC4% | MySoap4 | 3        | 32   | 3.44               | 00CC03          | 2003            | 1113            | H0003           | 111-22-0003 | 100000003 | 123-1234,123-1232 |                         |            |                  |                  |            |              |            |          |                              |
		| %RandomUPC4% | MySoap5 | 1        | 32   | 1.22               | 00AA01          | 2001            | 1111            | F0001           | 111-22-0001 | 100000001 | 123-1234,123-1230 |                         |            |                  |                  |            |              |            |          |                              |
		| %RandomUPC1% | MySoap1 | 1        | 32   | 1.22               | 00AA01          | 2001            | 1111            | F0001           | 111-22-0001 | 100000001 | 123-1234,123-1230 |                         |            |                  |                  |            |              |            |          |                              |
		| %RandomUPC2% | MySoap2 | 3        | 32   | 3.44               | 00CC03          | 2003            | 1113            | H0003           | 111-22-0003 | 100000003 | 123-1234,123-1232 |                         |            |                  |                  |            |              |            |          |                              |
		| %RandomUPC3% | MySoap3 | 5        | 32   | 5.66               | 00EE05          | 2005            | 1115            | J0005           | 111-22-0005 | 100000005 | 123-1234,123-1234 |                         |            |                  |                  |            |              |            |          |                              |	
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, click 'Upload File' button and upload file saved as: Bulktest82536
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, confirm 'Add Multiple' modal window should be displayed
	Then I confirm that Add Multiple UPC popup appears and the values are the same as the UPC Upload document saved in the Table called: UPCTable82536
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, at 'Add Multiple' modal check All UPCs checkbox
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, at 'Add Multiple' modal confirm all UPCs are selected
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, at 'Add Multiple' modal select Packaging Type: Plastic Container
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, at 'Add Multiple' modal click 'Next' button
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, at 'Add Multiple' modal confirm all UPCs are selected
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, at 'Add Multiple' modal check retailer: Target
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, at 'Add Multiple' modal click 'Finish' button
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, confirm 'Add Multiple' modal window should not be displayed
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, error message should be displayed with text: 'You have added UPCs to the registration that are already in use within your WERCSmart account. Duplicate UPCs are not permitted, as they may provide conflicting Assessment information to your retailer recipients. Please remove the instances of duplicate UPC(s) from the necessary registration data.'
	Then in the Global Trade Item Number (GTIN) / Universal Product Code (UPC) page I click Continue
	Given I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, confirm the values on the new product screen are the same as the UPC Upload document saved in the Table called: UPCTable82536
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, confirm UPC number saved as RandomUPC4 is duplicated and Warning Icons are displayed
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, check all UPCs with number: RandomUPC4
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, click 'Delete Rows' button
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, confirm Warning modal window should be displayed
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, in Warning modal window click 'Ok' button
	Then in the Global Trade Item Number (GTIN) / Universal Product Code (UPC) page I click Continue
	Given I should see the Regulatory Documents to Provide Page
	And I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase82536


		



	#Given I generate a random UPC number and save as: UPC_A
	#Given I generate a random UPC number and save as: UPC_B
	#Given I generate a random UPC number and save as: UPC_C
	#Given I generate a random UPC number and save as: UPC_D
	#Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	#And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	#And I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Soap (Bar, Liquid) for Body
	#And I click continue
	#And I call Shared Step 57501 (Physical and Chemical Properties - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue - HP)
	#And I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	#And I call Shared Step 29181 (Ingredients - add any chemical) with name: soap
	#And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	#And I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
	#And I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Amazon
	#And I click continue
	#And I click Sample File link and verify the Upload UPC form and save it as test82536 with data:
	#	| UPC          | Quantity | Size | Net Explosive Mass | US: Part Number | US: Item Number | GP: Part Number | SP: Part Number | TG: DPCI    | HD: OMSID | CT: Item Number   |
	#	| 823973000000 | 1        | 11   | 1.22               | 11AB45          | 1001            | 1111            | A0001           | 111-22-0001 | 100000001 | 123-1234,123-1230 |
	#	| 71617198008  | 2        | 22   | 2.33               | 12AB56          | 1002            | 2222            | B0002           | 111-22-0002 | 100000002 | 123-1234,123-1231 |
	#	| 978959000000 | 3        | 33   | 3.44               | 12AC67          | 1003            | 3333            | C0003           | 111-22-0003 | 100000003 | 123-1234,123-1232 |
	#	| 688267000000 | 4        | 44   | 4.55               | 12AD89          | 1004            | 4444            | D0004           | 111-22-0004 | 100000004 | 123-1234,123-1233 |
	#	| 854911000000 | 5        | 55   | 5.66               | 12AF00          | 1005            | 5555            | E0005           | 111-22-0005 | 100000005 | 123-1234,123-1234 |
	#And I create a new file saved as: UploadFile to upload using the UPCs saved as:
	#	| UPC   | Quantity | Size | Net Explosive Mass | US: Part Number | US: Item Number | GP: Part Number | SP: Part Number | TG: DPCI    | HD: OMSID | CT: Item Number   |
	#	| UPC_A | 11       | 1    | 6.6                | 00AA01          | 2001            | 1234            | F0001           | 123-45-6789 | 500000009 | 223-1234,123-1230 |
	#	| UPC_B | 31       | 2    | 7.94               | 00BB02          | 2002            | 2345            | G0002           | 234-56-7890 | 400000008 | 223-1234,123-1231 |
	#	| UPC_C | 61       | 3    | 8.2                | 00CC03          | 2003            | 3456            | H0003           | 345-67-8901 | 300000007 | 223-1234,123-1232 |
	#	| UPC_D | 91       | 4    | 9.06               | 00DD04          | 2004            | 5678            | I0004           | 456-78-9012 | 200000006 | 223-1234,123-1233 |
	##And I Create your own document with UPCs, use the following site to get UPCs https://www.upcdatabase.com/click on the Random Item link and copy and p123-1234,123-1234aste the UPCs that appear on the textbox
	#And I In the UPC document add some duplicate UPCs, save the document
	#And I Click on the Upload File button
	#And I Search for the document that contains the UPCs you will upload, click Open button
	#And I Confirm that the Add Multiple window openswith the UPCs that were added in the document
	#And I Confirm that the size is also the same as from what is in the UPC document
	#And I Select the checkbox that next to the UPC tilte
	#And I From the Packaging type dropdown select one of the options
	#And I Click Next button
	#And I Select the checkbox for the retailer
	#And I Click on the name of the Retailer
	#And I Click on the name of the Retailer again
	#And I Click the Finish button
	#And I Click the continue button
	#And I Confirm that you get a message, There are UPCs that already exist within the WERCSmart database.  Please review the UPCs associated within yout account, or request to forward a manufacturer's UPC by creating a new registration as a request from a Distrubutor. For UPCs that exist within your WERCSmart account, you may use the Report feature to generate a report for your review.  UPCs: xxxxxxxxxxxxxWhere xxxxxxxxxxxxx is the UPC that is duplicatedIf more than one UPC is a duplicate they be shown
	#And I Confirm the UPC rows that are duplicates show the red warning triangle next to the Retailer code
	#And I Select the UPC(s) that are shown as duplicates by checking the box next to the UPC row in the table
	#And I Click the Delete Rows button
	#And I Click OK
	#And I Confirm the UPC(s) you selected for deletion are no longer shown in the UPC table
	#And I Click the Continue button
	#And I Confirm you are allowed to go on to next screen without errors
	#And I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase82536

@TestCase:88879
Scenario: [88879] Input fields and labels for Retailers HD and TG have been Updated
	#Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I log in with the account saved in TReVor as: ProductAccount

	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
		Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Then in the New Product page, I click Continue

	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk
	Then I save the product information as: TestCase88879
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
	Then In the Ingredients section, add component with component name: Calcium Carbonate
	Then In the Ingredients Table row with component name: Calcium Carbonate, in Percent column text input enter: 100
	Then in the Ingredients page I click Continue
	#And I call Shared Step 152747 Inventory Status, Prop 65 (US) - Applicable Only to CHALK (RU000711) - General Shared-Step
	Given I should see the Inventory Status, Prop 65 (US) Page
	Given In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is exempt from TSCA chemical Inventory listing requirements.
	Given In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Given in the Inventory Status, Prop 65 (US) page I click Continue
	#And I call Shared Step 226326 (Retailer - Add Retailer(s):  THE HOME DEPOT - (General Shared-Step))
	Given I should see the Retailer Page
	Given In the Retailer Section, click 'Add Retailers' button
	Given In the Select Retailers window, select retailer: The Home Depot
	Given In the Select Retailers window, click 'Done' button
	Given in the Retailer page I click Continue
	Then I generate a random UPC number and save as: UPC#88879_1
	Then I generate a random UPC number and save as: UPC#88879_2
	Then I generate a random UPC number and save as: UPC#88879_3
	Then I generate a random UPC number and save as: UPC#88879_4
	Then I generate a random UPC number and save as: UPC#88879_5
	Then I generate a random UPC number and save as: UPC#88879_6
	Then I generate a random UPC number and save as: UPC#88879_7
	#Shared Step 252564 GTIN / UPC - Verify OMSID is NO Longer Required When a UPC File is Uploaded for THE HOME DEPOT
	Given I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, click 'sample file' link to download file
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, confirm 'sample file' is downloaded and save as: test88879
	And I edit the testdoc.xlsx, and save its filepath as: Bulktest88879 and verify it contains the UPC data in the table saved as: UPCTable88879, (Base Data Only: true)
		| UPC           | Name     | Quantity | Size | Net Explosive Mass | US: Part Number | US: Item Number | GP: Part Number | SP: Part Number | TG: DPCI    | HD: OMSID | CT: Item Number   |
		| %UPC#88879_1% | MyChalk1 | 1        | 32   | 1.22               | 00AA01          | 2001            | 1111            | F0001           | 111-22-0001 |			| 123-1234,123-1230 |
		| %UPC#88879_2% | MyChalk2 | 2        | 32   | 2.33               | 00BB02          | 2002            | 1112            | G0002           | 111-22-0002 |		    | 123-1234,123-1231 |
		| %UPC#88879_3% | MyChalk3 | 3        | 32   | 3.44               | 00CC03          | 2003            | 1113            | H0003           | 111-22-0003 |			| 123-1234,123-1232 |
		| %UPC#88879_4% | MyChalk4 | 4        | 32   | 4.55               | 00DD04          | 2004            | 1114            | I0004           | 111-22-0004 |			| 123-1234,123-1233 |
		| %UPC#88879_5% | MyChalk5 | 5        | 32   | 5.66               | 00EE05          | 2005            | 1115            | J0005           | 111-22-0005 |			| 123-1234,123-1234 |
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, click 'Upload File' button and upload file saved as: Bulktest88879
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, confirm 'Add Multiple' modal window should be displayed
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, at 'Add Multiple' modal check All UPCs checkbox
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, at 'Add Multiple' modal confirm all UPCs are selected
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, at 'Add Multiple' modal select Packaging Type: Plastic Container
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, at 'Add Multiple' modal click 'Next' button
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, at 'Add Multiple' modal confirm all UPCs are selected
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, at 'Add Multiple' modal check retailer: The Home Depot
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, at 'Add Multiple' modal click 'Finish' button
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, confirm 'Add Multiple' modal window should not be displayed
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, confirm the values on the new product screen are the same as the UPC Upload document saved in the Table called: UPCTable88879
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, verify retailer 'HD' is present under the 'Destination Retailers' column
	Then in the Global Trade Item Number (GTIN) / Universal Product Code (UPC) page I click Continue
	Given I should see the Regulatory Documents to Provide Page
	Then I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase88879

#Removed from regression 2024/06
@ignore
@TestCase:91801
Scenario: [91801] Duplicate UPC is not permitted within WERCSmart system - Forward Product registration - Case UPC
	Given I call Shared Step 65080b (Login to Studio as user saved as: SHAQAAuto7 and Open SHA manager)
	Then I click the following option in the bottom menu: Search
	Then I save the username for TReVor test user: ProductAccount to context as: AccountUsername
	And In SHA Manager ProductSearch page I run search:
		| Search Term | Search Value                  |
		| Status      | Completed                     |
		| Supplier    | QA_Automation_ProductsAccount |
		| User        | saved as AccountUsername      |
	Then I save a UPC number for any product in the grid to context as: ExistingUPC
	Given I navigate to the landing page
	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	Then I filter the products by: Accepted by Retailers
	And I save the ProductID of the first Product in the grid no in recertification as: testProduct91157
	Given I click Bulk Actions in the Products Grid
	Given I click Forward Product Registration in the Bulk Actions window
	Then I should see the header: Forward Product Registration on the Forward Product Registration window
	And I confirm the active Forward Product Registration tab is: Select Products
	Then I select the product with ID saved as: testProduct91157 under the Select Products tab
	And I select the product with ID saved as: testProduct91157 under the right hand panel of the Select Products tab
	Given I click continue on the Forward Product Registration page
	#Then In the Forward Product Registration Screen I select the first retailer under Other Retailers
	Given in the Select Retailers tab under Forward Product Registration I select the retailer: Walgreens
	And I click continue on the Forward Product Registration page
	Given I select the first product under the Select UPCs tab
	Given I click the Add Casepack button under the Select UPCs tab
	Then I wait for the Add Casepack popup to appear
	And In the Add Casepack modal window I enter the following information:
		| UPC Number           | Type      | Size (Weight Ounces) | Quantity | Transportation Options | Retailer |
		| saved as ExistingUPC | Cardboard | 32                   | 32       | 4A: steel box          | WG       |
	And In the Case UPC modal window I click Save
	Then I check that the alert displayed contains text: There are UPCs that already exists within the WERCSmart database. Please review the UPCs associated within your account, or request to forward a manufacturer's UPCs by creating a new registration as a request from a Distributor. For UPCs that exist within your WERCSmart account, you may use the Report feature to generate a report for your review.
	
#Removed from regression 2024/06
@ignore
@TestCase:91735
Scenario: [91735] Duplicate UPC is not permitted within WERCSmart system - Forward Product registration - single UPC
	#Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I log in with the account saved in TReVor as: ProductAccount
	Given I create a product with name: Chalk1 and UPC: UPC91801_1 and take to completed using Test Case 75335and SHA account: SHAQAAuto7 with no login step and save as: TestCase91801_Product1

	Given I navigate to the landing page
	Given I Login into WERCSmart Portal - Admin Role - WERCs Premium Subscription Account
	Given I create a product with name: Chalk2 and UPC: UPC91801_2 and take to completed using Test Case 75335 with no login step and save as: TestCase91801_Product2
	Given I navigate to the landing page
	#Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I log in with the account saved in TReVor as: ProductAccount
	Given I click Bulk Actions in the Products Grid
	Given I click Forward Product Registration in the Bulk Actions window
	Given I select the product saved as: TestCase91801_Product1 under the Select Products tab
	Given I click continue on the Forward Product Registration page
	Given in the Select Retailers tab under Forward Product Registration I select the retailer: Walgreens
	Given I click continue on the Forward Product Registration page
	Given I select the first product under the Select UPCs tab
	Given I click the Add UPC button under the Select UPCs tab
	And In the Add UPC modal window I enter the following information:
		| UPC Number          | Type      | Size (Ounces) | Retailer |
		| saved as UPC91801_2 | Cardboard | 32            | WG       |
	And In the UPC modal window I click Save
	Then I check that the alert displayed contains text: There are UPCs that already exists within the WERCSmart database. Please review the UPCs associated within your account, or request to forward a manufacturer's UPCs by creating a new registration as a request from a Distributor. For UPCs that exist within your WERCSmart account, you may use the Report feature to generate a report for your review.

@TestCase:91798
Scenario: [91798] Duplicate UPC is not permitted within WERCSmart system - New Product registration - Case UPC
	#Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I log in with the account saved in TReVor as: ProductAccount
	Given I create a product with name: Chalk2 and UPC: UPC91801_2 and take to completed using Test Case 75335and SHA account: SHAQAAuto7 with no login step and save as: TestCase91801_Product2
	Given I navigate to the landing page
	#Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I log in with the account saved in TReVor as: ProductAccount
#	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Then in the New Product page, I click Continue

	Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
	Then I save the product information as: TestCase91798
    #And I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
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
		| Retailer |
		| Amazon   |
	Given I click the 'Add Casepack' button
	Given I add the following into the UPC case fields
		| UPC Number          | Container Type | Size | Quantity | Individual Upc Case Pack | Transportation Option |
		| saved as UPC91801_2 | Cardboard      | 32   | 32       |                          | 4A: steel box         |
	Given I click continue
	Then I should see the following error text displayed in the UPC screen: There are UPCs that already exists within the WERCSmart database. Please review the UPCs associated within your account, or request to forward a manufacturer's UPCs by creating a new registration as a request from a Distributor. For UPCs that exist within your WERCSmart account, you may use the Report feature to generate a report for your review.
	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase91798
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase91798

#Removed from regression 2024/06
@ignore
@TestCase:91800
Scenario: [91800] Duplicate UPC is not permitted within account - Forward Product registration - Case UPC
	#Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I log in with the account saved in TReVor as: ProductAccount
	Given I create a product with name: Chalk1 and UPC: UPC91800_1 and take to completed using Test Case 75335and SHA account: SHAQAAuto7 with no login step and save as: TestCase91800_Product1
	Given I navigate to the landing page
	#Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I log in with the account saved in TReVor as: ProductAccount
	Given I create a product with name: Chalk2 and UPC: UPC91800_2 and take to completed using Test Case 75335and SHA account: SHAQAAuto7 with no login step and save as: TestCase91800_Product2
	Given I navigate to the landing page
	#Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I log in with the account saved in TReVor as: ProductAccount
	Given I click Bulk Actions in the Products Grid
	Given I click Forward Product Registration in the Bulk Actions window
	Given I select the product saved as: TestCase91800_Product1 under the Select Products tab
	Given I click continue on the Forward Product Registration page
	Given in the Select Retailers tab under Forward Product Registration I select the retailer: Walgreens
	Given I click continue on the Forward Product Registration page
	Given I select the first product under the Select UPCs tab
	Given I click the Add Casepack button under the Select UPCs tab
	Then I wait for the Add Casepack popup to appear
	And In the Add Casepack modal window I enter the following information:
		| UPC Number          | Type      | Size (Weight Ounces) | Quantity | Transportation Options | Retailer |
		| saved as UPC91800_2 | Cardboard | 32                   | 32       | 4A: steel box          | WG       |
	And In the Case UPC modal window I click Save
	Then I check that the alert displayed contains text: There are UPCs that already exists within the WERCSmart database. Please review the UPCs associated within your account, or request to forward a manufacturer's UPCs by creating a new registration as a request from a Distributor. For UPCs that exist within your WERCSmart account, you may use the Report feature to generate a report for your review.

#Removed from regression: 2024/09
@ignore
@TestCase:91741
Scenario: [91741] Duplicate UPC is not permitted within account - New Product registration - Case UPC
	Given I find an existing UPC number in trevor account saved as: ProductAccount using feature context: ExistingUPC_ProductAccount_1
	Given I navigate to the landing page
	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)

	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Given in the New Product page I click Continue

	#Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Seasonings, Spices or Flavoring for Food - Salts (Liquid)
	Given I should see the The Product Page
	And In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Chalk_#91741
	Given In the Product Section, set the option in section: 'Type of Product (select)' to: Chalk
 	Given in the The Product page I click Continue
    Then I save the product information as: TestCase91741

	#And I call Shared Step 62678 (Product Information - US & Canada, No Child, No OSHA, NO Direct ship, No PL, No NGFR - Continue, Happy path)
	And I should see the Product Information Page
	And In the Product Information Section, set the option in section: 'Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)' to: No
	And In the Product Information Section, set the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' to select: United States
	And In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	And In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	And In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	And In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	And in the Product Information page I click Continue

	#And I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
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

	#And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given I should see the Inventory Status, Prop 65 (US) Page
	Given In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	Given In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Given in the Inventory Status, Prop 65 (US) page I click Continue

	#And I call Shared Step 75146 (Retailer - Select One or More Retailers that DO NOT REQUIRE Vendor ID or Additional UPC Information, Click Done, Click Continue)
	Given I should see the Retailer Page
	Given In the Retailer Section, click 'Add Retailers' button
	Given In the Select Retailers window, select retailer: Target
	Given In the Select Retailers window, click 'Done' button
	Given in the Retailer page I click Continue

	Then I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page
	And in the UPC Window, I click the Add Casepack button
	Given I add the following into the UPC case fields
		| UPC Number                            | Container Type | Size | Quantity | Individual Upc Case Pack | Transportation Option |
		| saved as ExistingUPC_ProductAccount_1 | Cardboard      | 1    | 1        |                          | <first> |
	Given I click 'Select all' under Destination Retailers in the UPC page
	Given I click continue
	And I should see a list style form error with text: There are UPCs that already exists within the WERCSmart database. Please review the UPCs associated within your account, or request to forward a manufacturer's UPCs by creating a new registration as a request from a Distributor. For UPCs that exist within your WERCSmart account, you may use the Report feature to generate a report for your review. UPCs:
	And I navigate to the home page
	And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase91741

#Removed from regression 2024/06
@ignore
@TestCase:91100
Scenario: [91100] Duplicate UPC is not permitted within account - New Product registration - Bulk Upload
	#Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I log in with the account saved in TReVor as: ProductAccount
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Given in the New Product page I click Continue
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
	Then I save the product information as: TestCase91100
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

	#And I call Shared Step 29181 (Ingredients - add any chemical) with name: Water
	Given I should see the Ingredients Page
	Then In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	| component name | Water       | 100     |                     |               |             |
	Then in the Ingredients page I click Continue


	#And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given I should see the Inventory Status, Prop 65 (US) Page
	Given In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	Given In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Given in the Inventory Status, Prop 65 (US) page I click Continue

	And I call Shared Step 75146 (Retailer - Select One or More Retailers that DO NOT REQUIRE Vendor ID or Additional UPC Information, Click Done, Click Continue)
	And I click Sample File link and verify the Upload UPC form and save it as test91100
		| UPC           | Name   | Quantity | Size | Internal SKU | US: Part Number | US: Item Number | GP: Part Number | SP: Part Number | TG: DPCI    | HD: OMSID | CT: Item Number   | Green Good Housekeeping | Green Seal | EPA Safer Choice | Cradle to Cradle | UL Ecologo | EWG Verified | Green Tick | Madesafe | NSF Sustainability Certified |
		| 823973000000  | Saco 1 | 1        | 100  | KS955AR      | 11AB45          | 1001            | 1111            | A0001           | 111-22-0001 | 100000001 | 123-1234,123-1230 | Yes                     |            |                  |                  |            | Yes          |            |          | Yes                          |
		| 0037600724210 | Saco 2 | 2        | 101  |              | 12AB56          | 1002            | 2222            | B0002           | 111-22-0002 | 100000002 | 123-1234,123-1231 |                         | Yes        |                  |                  |            |              | Yes        |          |                              |
		| 978959000000  | Saco 3 | 3        | 102  |              | 12AC67          | 1003            | 3333            | C0003           | 111-22-0003 | 100000003 | 123-1234,123-1232 |                         |            | Yes              |                  |            |              |            |          |                              |
		| 688267000000  | Saco 4 | 4        | 103  | KS956AG      | 12AD89          | 1004            | 4444            | D0004           | 111-22-0004 | 100000004 | 123-1234,123-1233 |                         |            |                  | Yes              |            |              |            | Yes      |                              |
		| 854911000000  | Saco 5 | 5        | 104  | KS957AT      | 12AF00          | 1005            | 5555            | E0005           | 111-22-0005 | 100000005 | 123-1234,123-1234 |                         |            |                  |                  | Yes        |              |            |          |                              |
	#And I call Shared Step 65080b (Login to Studio as user saved as: SHAQAAuto9 and Open SHA manager)
	And I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I click the following option in the bottom menu: Search
	Given I save the username for TReVor test user: ProductAccount to context as: AccountUsername
	Given In SHA Manager ProductSearch page I run search:
		| Search Term | Search Value |
		| Status      | Completed    |
	And I find the UPC number for: 5 products in the grid and save them to context starting with: ExistingUPC
	Then I add the UPC numbers saved to context starting with: ExistingUPC to the UPC bulk upload spreadsheet: test91100
	Given I navigate to the landing page
	#Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I log in with the account saved in TReVor as: ProductAccount
	Given I search for the product saved as: TestCase91100
	Given I edit the first product in results
	And In the New Product page I click tab: Recipient and UPC Details
	And I click the page heading: Global Trade Item Number (GTIN) / Universal Product Code (UPC)
	Then I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page
	And I click the 'Upload File' button and upload the file saved as: test91100
	Then I confirm that the Add Multiple UPC window opens
	Then In the Add Multiple dialog box I select all UPCs
	Then In the Add Multiple dialog box I select the packaging type: <first>
	Given In the Add Multiple dialog box I click Next
	And In the Add Multiple dialog box I select all Retailers
	Then In the Add Multiple dialog box I click Finish
	Given I click continue
	Then I should see a list style form error with text: Please fix UPC errors
	And I navigate to the home page
	And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase91100

@TestCase:91157
Scenario: [91157] Duplicate UPC is not permitted within account - Forward Product registration - single UPC
	#Given I call Shared Step 67823(207480) (Login to WERCSmart - Products Automation Account)
	Given I log in with the account saved in TReVor as: ProductAccount
	Then I generate a random UPC number and save as: UPC91157
	#Given I call Shared Step 57408(252966) (Create a New Registration via Register New Product icon)
	Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Given in the New Product page I click Continue
	#And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
	Given I should see the The Product Page
	Given In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Chalk
	Given In the Product Section, set the option in section: 'Type of Product (select)' to: Chalk
 	Given in the The Product page I click Continue
	Then I save the product information as: TestCase91157
	#And I call Shared Step 59680(252968) (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Given I should see the Product Information Page
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)' to: No
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue
	#And I call Shared Step 26897(252546) (Physical and Chemical Properties - Solid only available - continue)
	Given I should see the Physical and Chemical Properties Page
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' should be showing the option: Solid
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' confirm option is selected: Solid
	Then In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
	Then In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Then In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
	Then in the Physical and Chemical Properties page I click Continue
	#And I call Shared Step 29181(152778) (Ingredients - add any chemical) with name: Water
	Given I should see the Ingredients Page
	Then In the Ingredients section, add component with component name: Calcium Carbonate
	Then In the Ingredients Table row with component name: Calcium Carbonate, in Percent column text input enter: 100
	Then in the Ingredients page I click Continue
	#And I call Shared Step 152747 (Inventory Status, Prop 65 (US) - Applicable Only to CHALK (RU000711) - General Shared-Step)
	Given I should see the Inventory Status, Prop 65 (US) Page
	Given In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is exempt from TSCA chemical Inventory listing requirements.
	Given In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Given in the Inventory Status, Prop 65 (US) page I click Continue
	#And I call Shared Step 252954 (Retailer - Add Retailer(s):  Target and Walgreens - Applicable Only to CHALK (RU000711) - General Shared-Step)
	Given I should see the Retailer Page
	Given In the Retailer Section, click 'Add Retailers' button
	Given In the Select Retailers window, select retailer: Target
	Given In the Select Retailers window, select retailer: Walgreens
	Given In the Select Retailers window, click 'Done' button
	Given in the Retailer page I click Continue
	#Shared Step 253324 GTIN / UPC - Add UPC Number - Applicable Only to CHALK (RU000711) - General Shared-Step
	Given I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, I click the Add UPC Button
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, for section: 'Provide the product's UPC(s)- including container type and size (ounces)' enter UPC Number: saved as UPC91157 enter Size: 12 and enter Container Type: Plastic Container
	Then in the Global Trade Item Number (GTIN) / Universal Product Code (UPC) page I click Continue
	#Shared step 253325 Regulatory Documents to Provide - Upload OSHA-Compliant SDS - Applicable Only to CHALK (RU000711) - General Shared-Step
	Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Yes, I certify that I have an OSHA-compliant SDS for this product and would like to upload it.
	Then In the Regulatory Documents to Provide Section, upload file in section: 'OSHA SDS'
	Then in the Regulatory Documents to Provide page I click Continue
	#Shared Step 253326 Additional Documents to Provide - Applicable Only to CHALK (RU000711) - General Shared-Step - CLICK CONTINUE
	Given I should see the Additional Documents to Provide Page
	Then in the Additional Documents to Provide page I click Continue
	#Shared Step 253327 Optional Reports and Documents Available for Purchase - Applicable Only to CHALK (RU000711) - General Shared-Step - CLICK CONTINUE
	Given I should see the Optional Reports and Documents Available for Purchase Page
	Then in the Optional Reports and Documents Available for Purchase page I click Continue
	#Shared Step 253329 Optional Comments - Applicable Only to CHALK (RU000711) - General Shared-Step - CLICK CONTINUE
	Given I should see the Optional Comments Page
	Then in the Optional Comments page I click Continue
	#Shared Step 253426 Summary Tab - Record the Product ID and/or UPC Number for Posterior Verification
	Then In the Data Acceptance Section, click 'Summary' button
	Then I switch to the tab with Data Summary page
	Then In the Summary Page, verify table data in column UPC Number showing the value: saved as UPC91157
	Then I close the tab with Data Summary page
	#Then I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given I should see the Data Acceptance Page
	Then In the Data Acceptance Section, check 'Agreed' checkbox
	Then In the Data Acceptance Section, click 'Accept' button
	#Shared Step 157174 Purchase Summary - Thank You for Registering Message - Click Home to Continue
	Given The Purchase Summary Page is displayed
	Then In the Purchase Summary page message is displayed with text: Thank you for registering your product on WERCSmart for assessment. The retailers may receive your assessment in approximately two (2) business days, if no delays in processing the assessment, and should no data issues arise.
	Then I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Then In the SHA manager grid I see the WPS ID I have saved as product: TestCase91157 and its status is: Assigned
	Then I call Shared Step 65969 (Go to Power Designer Plus - Select your product & CKLT - Continue)
	Then I call Shared Step 209526 (Power Designer Plus - AUTHORIZE Product (Applicable Only to Products with an Uploaded OSHA-SDS / Kit Products / Products that Do NOT Require an SDS Upload)) for product saved as: TestCase91157
	Then I call Shared Step 209552 Power Designer Plus - APPLY RULES To Product
	Then I call Sared Step 214627 Power Designer Plus - PUBLISH Product (Applicable Only to Battery Products ): TestCase91157
	Then I call Shared Step 59066 (Go to SHA Manager)
	Then In the SHA manager grid I see the WPS ID I have saved as product: TestCase91157 and its status is: Completed
	Then I open the new tab in browser
	Then I navigate to the landing page
	Given I log in with the account saved in TReVor as: ProductAccount
	#253440 Bulk Actions - Forward Product Registration - Verify Duplicate UPCs Cannot Be Forwarded
	Then I call Shared Step 75130 - Bulk Actions - Select Forward Product Registration
	And I enter the text: saved as TestCase91157 in the 'Search by WPS ID or Product Name' field
	And In the Foward Product Registration Screen I should see product: saved as TestCase91157
	And In the Foward Product Registration Screen I Select the product: saved as TestCase91157
	And I click continue on the Forward Product Registration page
	Given in the Select Retailers tab under Forward Product Registration I select the retailer: Office Depot
	And I click continue on the Forward Product Registration page
	Then I select the first product under the Select UPCs tab
	Then I click the Add UPC button under the Select UPCs tab
	And In the Add UPC modal window I enter the following information:
		| UPC Number        | Type        | Size (Ounces) | Retailer |
		| saved as UPC91157 | Plastic bag | 18            | OD       |
	Then In the UPC modal window I click Save
	Then In The Add UPC modal verify for UPC Number error message 'This UPC Number is duplicated' is displayed
	Then In The Add UPC modal verify for Retailers error message 'This UPC Number is duplicated' is displayed
	Then In the UPC modal window I click Cancel
	Then I click the Home navigation icon and accept the alert popup
	Then The home screen should load

#Removed from regression: 2024/09
@ignore
@TestCase:91077
Scenario: [91077] Duplicate UPC is not permitted within WERCSmart system - New Product registration - Single UPC
	Given I find an existing UPC number in trevor account saved as: ProductAccount using feature context: ExistingUPC_ProductAccount_1
	Given I navigate to the landing page
	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)

	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Given in the New Product page I click Continue

	#Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Seasonings, Spices or Flavoring for Food - Salts (Liquid)
	Given I should see the The Product Page
	And In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Chalk_#91077
	Given In the Product Section, set the option in section: 'Type of Product (select)' to: Chalk
 	Given in the The Product page I click Continue
    Then I save the product information as: TestCase91077

	#And I call Shared Step 62678 (Product Information - US & Canada, No Child, No OSHA, NO Direct ship, No PL, No NGFR - Continue, Happy path)
	And I should see the Product Information Page
	And In the Product Information Section, set the option in section: 'Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)' to: No
	And In the Product Information Section, set the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' to select: United States
	And In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	And In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	And In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	And In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	And in the Product Information page I click Continue

	#And I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
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

	#And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given I should see the Inventory Status, Prop 65 (US) Page
	Given In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	Given In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Given in the Inventory Status, Prop 65 (US) page I click Continue

	#And I call Shared Step 75146 (Retailer - Select One or More Retailers that DO NOT REQUIRE Vendor ID or Additional UPC Information, Click Done, Click Continue)
	Given I should see the Retailer Page
	Given In the Retailer Section, click 'Add Retailers' button
	Given In the Select Retailers window, select retailer: Target
	Given In the Select Retailers window, click 'Done' button
	Given in the Retailer page I click Continue

	Then I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page
	Given I click the 'Add' button
	Given I add the following into the UPC Fields
		| UPC Number                            | Container Type    | Size | DPCI | Quantity |
		| saved as ExistingUPC_ProductAccount_1 | Plastic Container | 1    |      |          |
	Given I click 'Select all' under Destination Retailers in the UPC page
	Given I click continue
	And I should see a list style form error with text: There are UPCs that already exists within the WERCSmart database. Please review the UPCs associated within your account, or request to forward a manufacturer's UPCs by creating a new registration as a request from a Distributor. For UPCs that exist within your WERCSmart account, you may use the Report feature to generate a report for your review. UPCs:
	And I navigate to the home page
	And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase91077

#Removed from regression 2024/03
@ignore
@TestCase:91101
Scenario: [91101] Duplicate UPC is not permitted within WERCSmart system - New Product registration - Bulk Upload
	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Given in the New Product page I click Continue
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
	Then I save the product information as: TestCase91101
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

	#And I call Shared Step 29181 (Ingredients - add any chemical) with name: Water
	Given I should see the Ingredients Page
	Then In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	| component name | Water       | 100     |                     |               |             |
	Then in the Ingredients page I click Continue

	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	And I call Shared Step 75146 (Retailer - Select One or More Retailers that DO NOT REQUIRE Vendor ID or Additional UPC Information, Click Done, Click Continue)
	And I click Sample File link and verify the Upload UPC form and save it as test91100
		| UPC           | Name       | Quantity | Size | Internal SKU | US: Part Number | US: Item Number | GP: Part Number | SP: Part Number | TG: DPCI    | HD: OMSID | CT: Item Number   | Green Good Housekeeping | Green Seal | EPA Safer Choice | Cradle to Cradle | UL Ecologo | EWG Verified | Green Tick | Madesafe | NSF Sustainability Certified |
		| 823973000000  | Saco 1     | 1        | 100  | KS955AR      | 11AB45          | 1001            | 1111            | A0001           | 111-22-0001 | 100000001 | 123-1234,123-1230 | Yes                     |            |                  |                  |            | Yes          |            |          | Yes                          |
		| 0037600724210 | Saco 2     | 2        | 101  |              | 12AB56          | 1002            | 2222            | B0002           | 111-22-0002 | 100000002 | 123-1234,123-1231 |                         | Yes        |                  |                  |            |              | Yes        |          |                              |
		| 978959000000  | Saco 3     | 3        | 102  |              | 12AC67          | 1003            | 3333            | C0003           | 111-22-0003 | 100000003 | 123-1234,123-1232 |                         |            | Yes              |                  |            |              |            |          |                              |
		| 688267000000  | Saco 4     | 4        | 103  | KS956AG      | 12AD89          | 1004            | 4444            | D0004           | 111-22-0004 | 100000004 | 123-1234,123-1233 |                         |            |                  | Yes              |            |              |            | Yes      |                              |
		| 854911000000  | Saco 5     | 5        | 104  | KS957AT      | 12AF00          | 1005            | 5555            | E0005           | 111-22-0005 | 100000005 | 123-1234,123-1234 |                         |            |                  |                  | Yes        |              |            |          |                              |
	
	#Looks like there is a bug failing this test that does not auto fill product name if using bulk upload file, in testing we can use below method with sample file data+ names to stop this being an issue, but needs to be raised.
	#And I edit the testdoc.xlsx, and save its filepath as: Bulktest95988 and verify it contains the UPC data in the table saved as: UPCTable95988, (Base Data Only: true)

	And I call Shared Step 65080b (Login to Studio as user saved as: SHAQAAuto7 and Open SHA manager)
	Given I click the following option in the bottom menu: Search
	Given I save the username for TReVor test user: ProductAccount to context as: AccountUsername
	Given In SHA Manager ProductSearch page I run search:
		| Search Term | Search Value |
		| Status      | Completed    |
	Given I find a UPC number for: 5 products not belonging to Supplier: QA_Automation_ProductsAccount in the grid and save to context starting with: ExistingUPC
	Then I add the UPC numbers saved to context starting with: ExistingUPC to the UPC bulk upload spreadsheet: test91101 with data:
	#Then I add Generic Product Names to the UPC bulk upload spreadsheet: BulkUpload91101
	Given I navigate to the landing page
	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	Given I search for the product saved as: TestCase91101
	Given I edit the first product in results
	And In the New Product page I click tab: Recipient and UPC Details
	And I click the page heading: Global Trade Item Number (GTIN) / Universal Product Code (UPC)
	Then I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page
	And I click the 'Upload File' button and upload the file saved as: test91101 with data:
	Then I confirm that the Add Multiple UPC window opens
	Then In the Add Multiple dialog box I select all UPCs
	Then In the Add Multiple dialog box I select the packaging type: <first>
	Given In the Add Multiple dialog box I click Next
	And In the Add Multiple dialog box I select all Retailers
	Then In the Add Multiple dialog box I click Finish
	Given I click continue
	Then I should see a list style form error with text: Please fix UPC errors
	And I navigate to the home page
	And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase91101

	


	

	







	
	

