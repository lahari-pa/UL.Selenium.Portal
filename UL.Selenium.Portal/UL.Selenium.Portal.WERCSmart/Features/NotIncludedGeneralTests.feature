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
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:ProductInformation
@PhysicalAndChemicalProp
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:RegulatoryDocumentsToProvide
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:OptionalComments
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:DataAcceptance
@Ingredients
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:NewProduct
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:TheProduct
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:InventoryStatusProp65
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:TransportationDetails1
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:Retailer
@ignore
@RegulatoryInformation3
@SafetyDataSheetAuthoring


Feature: NotIncludedGeneralTests

##This is a feature that is used to debug tests that you don't want included in trevor.
Scenario: [NOTINCLUDEDGENERALTEST] UPC View: Continue button is hidden occasionally from the user-- test 1
	Then I generate: 5 random UPC numbers and save them starting with: RandomUPC
	#Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I log in with the account saved in TReVor as: ProductAccount
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration'
	Given in the New Product page I click Continue
	And I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Soap (Bar, Liquid) for Body
	Then I save the product information as: TestCase95988
	And I click continue
	#And I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Given I should see the Product Information Page
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)' to: No
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue

	#Given I call Shared Step 57501 (Physical and Chemical Properties - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue - HP)
	Given In the Physical and Chemical Properties Section, set the option in section: 'Primary Physical State' to: Solid
	Given In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Bonded, fibrous glass web
	Given In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Given In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
	Given I click continue
	#And I call Shared Step 29181 (Ingredients - add any chemical) with name: soap
	Given I should see the Ingredients Page
	Then In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	| component name | Soap       | 100     |                     |               |             |
	Then in the Ingredients page I click Continue

	Then I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
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
	#And I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Amazon
	Given I should see the Retailer Page
	Then In the Retailer Section, click 'Add Retailers' button
	Then In the Select Retailers window, select retailer: Amazon
	Then In the Select Retailers window, click 'Done' button
	Then in the Retailer page I click Continue

	And I click continue

Scenario: [NOTINCLUDEDGENERALTEST] Forwarding - Edit existing Case UPC
	Given I navigate to the landing page
	Then I save the randomly generated UPC: 333446962121 as: UPC87685
	Then I save the randomly generated UPC: 795866162008 as: UPC876851
	Then I save the randomly generated UPC: 1513537 as: TestCase87894
	And I call Shared Step (Login to WERCSmart - Premium Account)
	Then I filter the products by: Accepted by Retailers
	And I filter for the product saved as: TestCase87894
	And I Confirm the Products shown display the Green Colour Status - which is the Accepted by Retailers
	And I call Shared Step 75130 - Bulk Actions - Select Forward Product Registration
	And I should see the subheading 3: Select Products & UPCs on the Forward Product Registration window
	Then I select the product with ID saved as: TestCase87894 under the Select Products tab
	Given I click continue on the Forward Product Registration page
	Then I confirm the active Forward Product Registration tab is: Select Retailers
	#And I Select a retailer which is not already present on the product you are working with, make sure to select a retailer that does not require additional data (such as BB, DI, KG)
	Then In the Forward Product Registration Screen I select the first retailer that does not require additional data and is not: Amazon under Other Retailers and save it as: ChosenRetailer87894
	Given I click continue on the Forward Product Registration page
	Then I select the first product under the Select UPCs tab
	#Then I confirm that: WM is displayed in the Destination Retailers column under Select UPCs
	#<-- use as example for accessing this right side table on select UPCs page
	Then I confirm that UPC information is displayed in the Destination Retailers column under the Select UPCs Table
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
	And I call Shared Step 65080 (Login to Studio and Open SHA manager)
	And I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase87894)
	#
	#
	Given I call Shared Step 75309 (SHA > Select Product > UPC Retailer and Feed) for product saved as: TestCase87894

Scenario: [NOTINCLUDEDGENERALTEST] Forwarding - Edit existing Case UPC second half
	Given I navigate to the landing page
	Then I save the randomly generated UPC: 333446962121 as: UPC87685
	Then I save the randomly generated UPC: 795866162008 as: UPC876851
	Then I save the randomly generated UPC: 1513537 as: TestCase87894
	And I call Shared Step 65080 (Login to Studio and Open SHA manager)
	And I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase87894)
	Then I Check that the product under the retailer: AM is under the status: Accepted

Scenario: [NOTINCLUDEDGENERALTEST] Forwarding - Edit existing Case UPC -ID search testing
	Given I log in with the account saved in TReVor as: PremiumSubscriptionAccount
	Given I generate a random UPC number and save as: UPC87685
	Given I generate a random UPC number and save as: UPC876851
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration'
	Given in the New Product page I click Continue
	Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
	Then I save the product information as: TestCase87685
	Given I navigate to the home page
	Then I filter the products by: Accepted by Retailers
	And I call Shared Step 75130 - Bulk Actions - Select Forward Product Registration
	And I should see the subheading 3: Select Products & UPCs on the Forward Product Registration window
	Then I get the product ID for the product saved as: TestCase87685 then I use this ID in the select Products & UPCs page
	Given I click continue on the Forward Product Registration page

Scenario: [NOTINCLUDEDGENERALTEST] Alert '0' now is Alert '--' : Check
	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	And I should see the Subheading Alerts in the main window
	And the Alerts dialog should be visible
	Then I see notifications in the Alerts Panel
	Then I Check the Alert with text: You have Products Awaiting Update! has the ID: --

Scenario: [NOTINCLUDEDGENERALTEST] Dupe UPC tool, Creating product with one dupe upc and one non dupe upc
	Given I find an existing UPC number in trevor account saved as: ProductAccount using feature context: ExistingUPC_ProductAccount_1
	Given I navigate to the landing page
	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration'
	Given in the New Product page I click Continue
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
	Then I save the product information as: TestCase91076
	#And I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I should see the Physical and Chemical Properties Page
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' should be showing the option: Solid
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' confirm option is selected: Solid
	Then In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
	Then In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Then In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
	Then in the Physical and Chemical Properties page I click Continue

	#And I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Given I should see the Product Information Page
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)' to: No
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue

	#And I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
	Given I should see the Ingredients Page
	Then In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	| component name | Sodium hydroxide       | 100     |                     |               |             |
	Then in the Ingredients page I click Continue

	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	And I call Shared Step 75146 (Retailer - Select One or More Retailers that DO NOT REQUIRE Vendor ID or Additional UPC Information, Click Done, Click Continue)
	Then I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page
	Given I click the 'Add' button
	Given I add the following into the UPC Fields
		| UPC Number                            | Container Type    | Size | DPCI | Quantity |
		| saved as ExistingUPC_ProductAccount_1 | Plastic Container | 1    |      |          |
	Given I click the 'Add' button
	Then I generate a random UPC number and save as: RandomUPC91076
	Given I add the following into the UPC Fields
		| UPC Number              | Container Type    | Size | DPCI | Quantity |
		| saved as RandomUPC91076 | Plastic Container | 1    |      |          |
	Given I click 'Select all' under Destination Retailers in the UPC page
	Given I click continue
	And I should see a list style form error with text: There are UPCs that already exists within the WERCSmart database. Please review the UPCs associated within your account, or request to forward a manufacturer's UPCs by creating a new registration as a request from a Distributor. For UPCs that exist within your WERCSmart account, you may use the Report feature to generate a report for your review. UPCs:
	And I navigate to the home page



Scenario: [NOTINCLUDEDGENERALTEST] SHA LOGIN CHECKER
	And I call Shared Step 65080 (Login to Studio and Open SHA manager)

#This test will not work as the email will not be sent to products account (selecting product from differnt user)
Scenario: [NOTINCLUDEDGENERALTEST] Suspend a Product - Formula - Document Issue - Check Email does not contain Blurb
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I Save the email for the TReVor: ProductAccount Test user as: ProductAccountEmail
	Given I save the current emails in the inbox for address saved as: ProductAccountEmail
	Then In SHA Manager I set the filter for status to : Assigned
	And In SHA Manager I select the first product
	And I click the following option in the bottom menu: Suspended
	And In the Suspended dialog I Select the following clients: All
	And In the Suspended dialog in the Select Regulatory Specialist drop down I choose: Automated QASha
	And In the Suspended dialog in the Select Subject drop down I choose: Formula – Document Issue
	And In the Suspended dialog in the Supplier Message field I should see: The composition data provided does not match information listed on the document. You may either provide a corrected document, or correct the composition data to resolve this issue.
	And In the Suspended dialog in the Supplier Message field I add the following text: supplier message input
	And In the Suspended dialog in the Internal Product Note field I should see: The composition data provided does not match information listed on the document. You may either provide a corrected document, or correct the composition data to resolve this issue.
	And In the Suspended dialog in the Internal Product Note field I add the following text: internal product note input
	And In the Suspended dialog I click Save
	And I close alert
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Suspended Status for saved as: ID)
	Then I Check there should be a new suspension notification email for user: ProductAccountEmail for the Product saved as: ID with the suspension subject of: Formula – Document Issue and check it does not contain text from the table:
		| SearchText                                                                                                                                                                                                                                                      |
		| Use the “Recertification” link available on the registration to correct the issue; or                                                                                                                                                                           |
		| Contact the Help Desk Hub via a ticket.  If you registered the product, a ticket is already created in your My Ticket area of the Hub (post a reply to the existing ticket).                                                                                    |
		| If you recertify the data, accept the revisions allowing data transfer.  The assessment will proceed.                                                                                                                                                           |
		| Be aware:  If no response within ten (10) days will result in registration cancellation and the assessment will not proceed to the retailer.  You may contact the Help Desk for reinstatement of the assessment as needed, but the hold remains until resolved. |

Scenario: [NOTINCLUDEDGENERALTEST] Rejected Registration - Edit -  Message is displayed about Rejected Registrations and SDS Restrictions
	Given I Use Test case 75142 to create a NEW PRODUCT and get it to Submitted status in SHA
	And I call Shared Step 83242 (SHA - Submitted or Assigned product - Reject Submission - any subject - Save for the product saved as: TestCase75142)
	And I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase75142)
	And In the SHA manager grid I see the WPS ID I have saved as product: TestCase75142 and its status is: New
	Given I navigate to the landing page
	#Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I log in with the account saved in TReVor as: ProductAccount
	Then I filter for the product saved as: TestCase75142
	And I edit the product saved as: TestCase75142
	Then I confirm the Rejected Registration popup displays the warning: Please be aware that rejected registrations will not permit any changes to the Safety Data Sheet (SDS) option. Upon rejection, if you want to change your Safety Data Sheet selection (i.e. Select Authoring instead of providing a Document, you will need to DELETE the rejected registration and create a new registration to submit, with your proper selection.
	Given in the modal dialog I click cancel
	Then I confirm the Rejected Registration popup has closed
	And I edit the product saved as: TestCase75142
	Then I confirm the Rejected Registration popup displays the warning: Please be aware that rejected registrations will not permit any changes to the Safety Data Sheet (SDS) option. Upon rejection, if you want to change your Safety Data Sheet selection (i.e. Select Authoring instead of providing a Document, you will need to DELETE the rejected registration and create a new registration to submit, with your proper selection.
	Given in the modal dialog I click Continue
	And I should see the The Product Page

Scenario: [NOTINCLUDEDGENERALTEST] Advanced Reporting - Registrations Published report -

	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Then I select the: Product Registrations Published report from Advanced Reporting in SHA
	Then I Check that the Description Text for the Report: Product Registrations Published is shown as: Assessed Registrations Published for Transfer and Completion to Retailers within a Date Range
	Then I enter start Date: 08-08-2019 and end Date: 11-14-2019 for the Advanced report then I click Submit
	And I wait for the Advanced Reporting Preparing Report popup to disappear
	#For below step need an actual file to get name etc
	Given I confirm that an excel file is produced called PM Monthly Status Report - Target.xlsx and save as 105329
	#For below step need an actual file for headers
	Then I confirm that the excel file saved as: 105329 contains the following columns:
		| Column              |
		| WPSID               |
		| Product Name        |
		| WMDRUM              |
		| WMCAD               |
		| WMBC                |
		| PYST                |
		| PYSTM               |
		| FPF                 |
		| PH                  |
		| RU                  |
		| EPAN                |
		| CAWC                |
		| WSWC                |
		| UNM                 |
		| HCM                 |
		| PSNDWM              |
		| HCDWM               |
		| DVID                |
		| PSNV                |
		| HCW                 |
		| UNIFFC              |
		| BATT                |
		| BATTT               |
		| CHEMICAL            |
		| KIT                 |
		| OTC                 |
		| TGWAST              |
		| MPIND               |
		| DOTPG               |
		| DERGN               |
		| INTFC               |
		| CASEC               |
		| CASECD              |
		| DOTBMP              |
		| IMDGBMP             |
		| CATEST              |
		| WATEST              |
		| CNTXT               |
		| Last Published Date |
		| Published By        |
		| Recert              |
		| Product_status      |
		| GHS                 |

Scenario: [NOTINCLUDEDGENERALTEST] Subscription by Account and Product Type Report 
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Then I select the: Subscription by Account and Product Type report from Advanced Reporting in SHA
	Then I Check that the Description Text for the Report: Subscription by Account and Product Type is shown as: Subscription information for submitted registrations, including overall quantity of IDs and UPCs for the accounts.  All products and all accounts. Indicator of Past Due balance and Active subscriptions. Quantity of registrations per status, including cancelled, excluding new.  Internal Use Only.
	Then In the Advanced Reporting popup I click Submit
	And I wait for the Advanced Reporting Preparing Report popup to disappear
	#For below step need an actual file to get name etc
	Given I confirm that an excel file is produced called Subscription by Account and Product Type.xlsx and save as Testcase122472
	#Update Colum headings
	Then I confirm that the excel file saved as: Testcase122472 contains the following columns:
		| Column                                       |
		| Supplier                                     |
		| Administrator E-Mail                         |
		| Country                                      |
		| Total Active IDs Qty                         |
		| Total Active UPC Qty                         |
		| Submitted (Qty of IDs / UPCs in this status) |
		| Assigned                                     |
		| Completed                                    |
		| Cancelled                                    |
		| Suspended                                    |
		| Accepted                                     |
		| Release for distribution                     |
		| Formula                                      |
		| Enhanced                                     |
		| Articles                                     |
		| Subscription                                 |
		| Agency                                       |
		| Subscription Date (most recent)              |
		| Active Subscription                          |
		| Past Due Balance                             |
	Then I delete the Advanced Report file saved as Testcase122472

Scenario: [NOTINCLUDEDGENERALTEST] UL Solutions: Navigator Logo has TradeMark Symbol
	Given I Login into WERCSmart Portal - Admin Role - WERCs Visual Account
	Then the WERCSmart homepage should load
	Then I click the UL Solution Center icon in the Navigation Pane
	Then I confirm that the UL Solution Center page is loaded
	Then I confirm the following sections are displayed in the UL Solution Center page:
		| Sections  |
		| Navigator |

#Then do Image Comparison here
Scenario: [NOTINCLUDEDGENERALTEST] product submit upc info entry
	Given I generate a random UPC number and save as: UPC109503
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration'
	Given in the New Product page I click Continue
	And I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk
	Then I save the product information as: TestCase109503
	#Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I should see the Physical and Chemical Properties Page
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' should be showing the option: Solid
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' confirm option is selected: Solid
	Then In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
	Then In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Then In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
	Then in the Physical and Chemical Properties page I click Continue

	#Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Given I should see the Product Information Page
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)' to: No
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue

	#Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
	Given I should see the Ingredients Page
	Then In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	| component name | Sodium hydroxide       | 100     |                     |               |             |
	Then in the Ingredients page I click Continue

	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue) for
		| Retailer  |
		| Walgreens |
	Given I call Shared Step 87647 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC109503, container type: Paper bag and size: 2 do not click continue
	Given I click continue
	And  I call Shared Step 78080 (Regulatory Documents to Provide - Upload OSHA SDS)
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	#Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given I should see the Data Acceptance Page
	Then In the Data Acceptance Section, check 'Agreed' checkbox
	Then In the Data Acceptance Section, click 'Accept' button


Scenario: [NOTINCLUDEDGENERALTEST] UL Solution Center - Shows Updated Navigator Logo
	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	Given I click the UL Solution Center icon in the QuickLinks Pane
	Then I confirm that the UL Solution Center page is loaded
	Then I Confirm the Navigator heading is displayed next to an icon
	#Check Icon is updated version
	And I Confirm the information statement for section: Navigator reads: Navigator highlights the main chemical regulatory requirements for over 50 countries around the world. These summaries compile the most important information all in one place, offering easy to understand explanations of complex topics, paired with links to laws and helpful resources. Summaries are authored and updated by our global regulatory specialists, whose primary responsibility is the monitoring and reporting of regulations in their given country.
	And I confirm the Learn More button is displayed for section: Navigator
	Given I click the Learn More button for section: Navigator
	Given I switch to the Navigator information tab
	Then I check that the current URL contains: https://msc.ul.com/en/products/navigator/

Scenario: [NOTINCLUDEDGENERALTEST] Pub to completed then run report
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I create a Chalk product which has a Case UPC and a regular UPC, process to completed and save the product as: (.*)

Scenario: [NOTINCLUDEDGENERALTEST] Completed product test 1
	Given I create a product and take to completed using Test Case 75335 and save as: ProductSetup64528
	Given I navigate to the landing page

Scenario: [NOTINCLUDEDGENERALTEST] UPCs and Registrations (Retailer Specific) - Report correctly displays case pack individual UPC
	#For Ticket 108160
	#add product with indv upc and case pack upc to this and get both upc as saved as
	Given I Submit a new product which has a Case UPC and a regular UPC
	Given I navigate to the landing page
	And I call Shared Step (Login to WERCSmart - Premium Account)
	#Should be able to remove the wait but check first
	Then I wait for 30 seconds
	Given I click the My Reports icon in the QuickLinks Pane
	Given Under the Supplier Reports menu I choose: UPCs and Registrations (Retailer Specific)
	Then In the Supplier Reports screen the current sub-page should be: UPCs and Registrations (Retailer Specific)
	Given In the Supplier Reports screen I click on the Download button
	Given I click on close in the Report Download dialog
	Given I confirm that an excel file is produced called UPCs and Registrations (Retailer Specific).xlsx and save as 73082
	Then I confirm that in the excel file saved as: 73082 for the UPC saved as: UPC876851 there is a 'Y' in the Case Pack column and an Individual UPC listed as: UPC87685
	And I delete the Supplier Report file saved as 73082

Scenario: [NOTINCLUDEDGENERALTEST] TESTCVS Revision to Data Tier Consent Requirements
	Then I create a upc number for CVS
	Given I create a new supplier products account: (.*) and create a new brand in that account

Scenario: [NOTINCLUDEDGENERALTEST] CVS Revision to Data Tier Consent Requirements
	Given I create a new supplier products account: (.*) and create a new brand in that account

Scenario: [NOTINCLUDEDGENERALTEST] TOYNoProductsAcc - CVS Revision to Data Tier Consent Requirements - Toys Don't require Consent Tiers
	Given I log in with the account saved in TReVor as: NoProductsAccount
	Then In the Products Grid I delete All products
	Then For CVS I create a product of type: Health & Beauty (RUCC0392), save it as: CVSHBProduct1 and leave it in New Status
	Then I navigate to the Data Consent Tiers Page for CVS
	And I Check that The expected data tiers for CVS are present in the Data Consent Tiers Section
	Then I navigate to the Homepage and then In the Products Grid I delete All products

Scenario: [NOTINCLUDEDGENERALTEST] HBNoProductsAcc - CVS Revision to Data Tier Consent Requirements health and beauty
	Given I log in with the account saved in TReVor as: NoProductsAccount
	Then In the Products Grid I delete All products
	Then For CVS I create a product of type: Health & Beauty (RUCC0392), save it as: CVSHBProduct1 and leave it in New Status
	Then I navigate to the Data Consent Tiers Page for CVS
	And I Check that The expected data tiers for CVS are the only ones present in the Data Consent Tiers Section
	Then I navigate to the Homepage and then In the Products Grid I delete All products
	Then For CVS I create a product of type: Toys (RUCC0388), save it as: CVSToyProduct1 and leave it in New Status

#now create all other products
Scenario: [NOTINCLUDEDGENERALTEST] DebugNoProductsAcc - CVS Revision to Data Tier Consent Requirements health and beauty
	Given I log in with the account saved in TReVor as: NoProductsAccount
	Then In the Products Grid I delete All products
	Then For CVS I create a product of type: Toys (RUCC0388), save it as: CVSToyProduct1 and leave it in New Status

@AndrewCVSRun
Scenario: [NOTINCLUDEDGENERALTEST] TicketNoProductsAcc - CVS Revision to Data Tier Consent Requirements health and beauty
	#For ticket 105950
	Given I log in with the account saved in TReVor as: NoProductsAccount
	Then In the Products Grid I delete All products
	Then For CVS I create a product of type: Toys (RUCC0388), save it as: CVSToysProduct1 and leave it in New Status
	Then I navigate to the Data Consent Tiers Page for CVS
	And I Check that the data consent tiers available for selection only include Tier 1
	Then I click the Products in Scope button and confirm that a file is not produced called CV_Report_DataUsageTier_<Date>.xlsx
	Then I navigate to the Homepage and then In the Products Grid I delete All products
	Then For CVS I create a product of type: Health & Beauty (RUCC0392), save it as: CVSHBProduct1 and leave it in New Status
	Then I navigate to the Data Consent Tiers Page for CVS
	And I Check that The expected data tiers for CVS are the only ones present in the Data Consent Tiers Section
	When I click the Products in Scope button and confirm that a file is produced called CV_Report_DataUsageTier_<Date>.xlsx and save as CVSHBExcelFile
	Then I confirm that the excel file saved as: CVSHBExcelFile contains the WPSID for the Product saved as: CVSHBProduct1
	Then I delete the Supplier Report file saved as CVSHBExcelFile
	Then I navigate to the Homepage and then In the Products Grid I delete All products
	Then For CVS I create a product of type: Artist Supply (RUCC0384), save it as: CVSArtistProduct1 and leave it in New Status
	Then I navigate to the Data Consent Tiers Page for CVS
	And I Check that The expected data tiers for CVS are the only ones present in the Data Consent Tiers Section
	When I click the Products in Scope button and confirm that a file is produced called CV_Report_DataUsageTier_<Date>.xlsx and save as CVSArtistExcelFile
	Then I confirm that the excel file saved as: CVSArtistExcelFile contains the WPSID for the Product saved as: CVSArtistProduct1
	Then I delete the Supplier Report file saved as CVSArtistExcelFile
	Then I navigate to the Homepage and then In the Products Grid I delete All products
	Then For CVS I create a product of type: Cleaning Supply (RUCC0397), save it as: CVSCleaningProduct1 and leave it in New Status
	Then I navigate to the Data Consent Tiers Page for CVS
	And I Check that The expected data tiers for CVS are the only ones present in the Data Consent Tiers Section
	When I click the Products in Scope button and confirm that a file is produced called CV_Report_DataUsageTier_<Date>.xlsx and save as CVSCleaningExcelFile
	Then I confirm that the excel file saved as: CVSCleaningExcelFile contains the WPSID for the Product saved as: CVSCleaningProduct1
	Then I delete the Supplier Report file saved as CVSCleaningExcelFile
	Then I navigate to the Homepage and then In the Products Grid I delete All products
	Then For CVS I create a product of type: Home Improvement (RUCC0394), save it as: CVSHomeProduct1 and leave it in New Status
	Then I navigate to the Data Consent Tiers Page for CVS
	And I Check that The expected data tiers for CVS are the only ones present in the Data Consent Tiers Section
	When I click the Products in Scope button and confirm that a file is produced called CV_Report_DataUsageTier_<Date>.xlsx and save as CVSHomeExcelFile
	Then I confirm that the excel file saved as: CVSHomeExcelFile contains the WPSID for the Product saved as: CVSHomeProduct1
	Then I delete the Supplier Report file saved as CVSHomeExcelFile
	Then I navigate to the Homepage and then In the Products Grid I delete All products
	Then For CVS I create a product of type: Lawn & Garden (RUCC0395), save it as: CVSLawnGardenProduct1 and leave it in New Status
	Then I navigate to the Data Consent Tiers Page for CVS
	And I Check that The expected data tiers for CVS are the only ones present in the Data Consent Tiers Section
	When I click the Products in Scope button and confirm that a file is produced called CV_Report_DataUsageTier_<Date>.xlsx and save as CVSLawnGardenExcelFile
	Then I confirm that the excel file saved as: CVSLawnGardenExcelFile contains the WPSID for the Product saved as: CVSLawnGardenProduct1
	Then I delete the Supplier Report file saved as CVSLawnGardenExcelFile
	Then I navigate to the Homepage and then In the Products Grid I delete All products
	Then For CVS I create a product of type: Miscellaneous (RUCC0400), save it as: CVSMiscProduct1 and leave it in New Status
	Then I navigate to the Data Consent Tiers Page for CVS
	And I Check that The expected data tiers for CVS are the only ones present in the Data Consent Tiers Section
	When I click the Products in Scope button and confirm that a file is produced called CV_Report_DataUsageTier_<Date>.xlsx and save as CVSMiscExcelFile
	Then I confirm that the excel file saved as: CVSMiscExcelFile contains the WPSID for the Product saved as: CVSMiscProduct1
	Then I delete the Supplier Report file saved as CVSMiscExcelFile
	Then I navigate to the Homepage and then In the Products Grid I delete All products
	Then For CVS I create a product of type: Nutritional (RUCC0592), save it as: CVSNutritionalProduct1 and leave it in New Status
	Then I navigate to the Data Consent Tiers Page for CVS
	And I Check that The expected data tiers for CVS are the only ones present in the Data Consent Tiers Section
	When I click the Products in Scope button and confirm that a file is produced called CV_Report_DataUsageTier_<Date>.xlsx and save as CVSNutritionalExcelFile
	Then I confirm that the excel file saved as: CVSNutritionalExcelFile contains the WPSID for the Product saved as: CVSNutritionalProduct1
	Then I delete the Supplier Report file saved as CVSNutritionalExcelFile
	Then I navigate to the Homepage and then In the Products Grid I delete All products
	Then For CVS I create a product of type: Over-the-Counter (RUCC1002), save it as: CVSOTCProduct1 and leave it in New Status
	Then I navigate to the Data Consent Tiers Page for CVS
	And I Check that The expected data tiers for CVS are the only ones present in the Data Consent Tiers Section
	When I click the Products in Scope button and confirm that a file is produced called CV_Report_DataUsageTier_<Date>.xlsx and save as CVSOTCExcelFile
	Then I confirm that the excel file saved as: CVSOTCExcelFile contains the WPSID for the Product saved as: CVSOTCProduct1
	Then I delete the Supplier Report file saved as CVSOTCExcelFile
	Then I navigate to the Homepage and then In the Products Grid I delete All products
	Then For CVS I create a product of type: Pet Care (RUCC0387), save it as: CVSPetCareProduct1 and leave it in New Status
	Then I navigate to the Data Consent Tiers Page for CVS
	And I Check that The expected data tiers for CVS are the only ones present in the Data Consent Tiers Section
	When I click the Products in Scope button and confirm that a file is produced called CV_Report_DataUsageTier_<Date>.xlsx and save as CVSPetCareExcelFile
	Then I confirm that the excel file saved as: CVSPetCareExcelFile contains the WPSID for the Product saved as: CVSPetCareProduct1
	Then I delete the Supplier Report file saved as CVSPetCareExcelFile
	Then I navigate to the Homepage and then In the Products Grid I delete All products
	Then For CVS I create a product of type: Photography (RUCC0735), save it as: CVSPhotopraphyProduct1 and leave it in New Status
	Then I navigate to the Data Consent Tiers Page for CVS
	And I Check that The expected data tiers for CVS are the only ones present in the Data Consent Tiers Section
	When I click the Products in Scope button and confirm that a file is produced called CV_Report_DataUsageTier_<Date>.xlsx and save as CVSPhotopraphyExcelFile
	Then I confirm that the excel file saved as: CVSPhotopraphyExcelFile contains the WPSID for the Product saved as: CVSPhotopraphyProduct1
	Then I delete the Supplier Report file saved as CVSPhotopraphyExcelFile
	Then I navigate to the Homepage and then In the Products Grid I delete All products
	Then For CVS I create a product of type: Sporting Goods (RUCC0386), save it as: CVSSportingGoodsProduct1 and leave it in New Status
	Then I navigate to the Data Consent Tiers Page for CVS
	And I Check that The expected data tiers for CVS are the only ones present in the Data Consent Tiers Section
	When I click the Products in Scope button and confirm that a file is produced called CV_Report_DataUsageTier_<Date>.xlsx and save as CVSSportingGoodsExcelFile
	Then I confirm that the excel file saved as: CVSSportingGoodsExcelFile contains the WPSID for the Product saved as: CVSSportingGoodsProduct1
	Then I delete the Supplier Report file saved as CVSSportingGoodsExcelFile
	Then I navigate to the Homepage and then In the Products Grid I delete All products
	Then For CVS I create a product of type: Stationery (RUCC0385), save it as: CVSStationeryProduct1 and leave it in New Status
	Then I navigate to the Data Consent Tiers Page for CVS
	And I Check that The expected data tiers for CVS are the only ones present in the Data Consent Tiers Section
	When I click the Products in Scope button and confirm that a file is produced called CV_Report_DataUsageTier_<Date>.xlsx and save as CVSStationeryExcelFile
	Then I confirm that the excel file saved as: CVSStationeryExcelFile contains the WPSID for the Product saved as: CVSStationeryProduct1
	Then I delete the Supplier Report file saved as CVSStationeryExcelFile
	Then I navigate to the Homepage and then In the Products Grid I delete All products
	Then For CVS I create a product of type: Battery (RUCC0733), save it as: CVSBatteryProduct1 and leave it in New Status
	Then I navigate to the Data Consent Tiers Page for CVS
	And I Check that The expected data tiers for CVS are the only ones present in the Data Consent Tiers Section
	When I click the Products in Scope button and confirm that a file is produced called CV_Report_DataUsageTier_<Date>.xlsx and save as CVSBatteryExcelFile
	Then I confirm that the excel file saved as: CVSBatteryExcelFile contains the WPSID for the Product saved as: CVSBatteryProduct1
	Then I delete the Supplier Report file saved as CVSBatteryExcelFile
	Then I navigate to the Homepage and then In the Products Grid I delete All products
	Then For CVS I create a product of type: Grocery (RUCC0389), save it as: CVSGroceryProduct1 and leave it in New Status
	Then I navigate to the Data Consent Tiers Page for CVS
	And I Check that The expected data tiers for CVS are the only ones present in the Data Consent Tiers Section
	When I click the Products in Scope button and confirm that a file is produced called CV_Report_DataUsageTier_<Date>.xlsx and save as CVSGroceryExcelFile
	Then I confirm that the excel file saved as: CVSGroceryExcelFile contains the WPSID for the Product saved as: CVSGroceryProduct1
	Then I delete the Supplier Report file saved as CVSGroceryExcelFile
	Then I navigate to the Homepage and then In the Products Grid I delete All products
	Then For CVS I create a product of type: Pharmacy (RUCC0393), save it as: CVSPharmacyProduct1 and leave it in New Status
	Then I navigate to the Data Consent Tiers Page for CVS
	And I Check that The expected data tiers for CVS are the only ones present in the Data Consent Tiers Section
	When I click the Products in Scope button and confirm that a file is produced called CV_Report_DataUsageTier_<Date>.xlsx and save as CVSPharmacyExcelFile
	Then I confirm that the excel file saved as: CVSPharmacyExcelFile contains the WPSID for the Product saved as: CVSPharmacyProduct1
	Then I delete the Supplier Report file saved as CVSPharmacyExcelFile
	Then I navigate to the Homepage and then In the Products Grid I delete All products

Scenario: [NOTINCLUDEDGENERALTEST] Daily Report - Data Tier Consent - CVS Updated Updated Data Tier Consent Requirements

#105950 linked
#Blocked so currently use screenshot from DB for ticket test
#Create a product that requires tier 4.1 then Check report reflects 4.1 need
#Method for opening the report, checking for retailer X and checking the tier coloum Y contains at least one
Scenario: [NOTINCLUDEDGENERALTEST] Retailer specific - CVS
	#Mayve just updated 57206
	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load
	Then I click the Retail Partners icon in the Navigation Pane
	When I select the retailer: CVS
	Then I confirm that there is a section labeled: CVS
	And I confirm that under the pie chart I see the label: % of your product portfolio is associated with CVS
	#Update to match new description text
	And I confirm that: CVS requires suppliers of all store branded products to grant Tier 2.1 and Tier 2.2 consent. is showing under the Data Consent Tiers heading
	When I click the More Information hyperlink
	Then I check that the current URL contains: https://login.ulscm.com/RPUI/cvsportal
	And I close the window that opened
	# Test originally wanted "https://labworks.ul.com/Pages/RCL.aspx", but redirects to a different link when clicked, so modified accordingly!
	When I click the Products in Scope button and confirm that an excel file is produced called CV_Report_DataUsageTier_<Date>.xlsx and save as CVSExcelFile
	And I confirm the excel file saved as CVSExcelFile can be opened and contains data
	Then I delete the Supplier Report file saved as CVSExcelFile
	Given I click on close in the Report Download dialog
	And I click the back arrow next to CVS
	Then I should see the Retail Partners page

Scenario: [NOTINCLUDEDGENERALTEST] CVS Product Creation Debug scenario
	Given I log in with the account saved in TReVor as: NoProductsAccount
	Then In the Products Grid I delete All products
	Then For CVS I create a product of type: Photography (RUCC0735), save it as: CVSPhotopraphyProduct1 and leave it in New Status
	Then I navigate to the Data Consent Tiers Page for CVS
	And I Check that The expected data tiers for CVS are the only ones present in the Data Consent Tiers Section
	When I click the Products in Scope button and confirm that a file is produced called CV_Report_DataUsageTier_<Date>.xlsx and save as CVSPetCareExcelFile
	Then I confirm that the excel file saved as: CVSPetCareExcelFile contains the WPSID for the Product saved as: CVSPhotopraphyProduct1
	Then I delete the Supplier Report file saved as CVSPetCareExcelFile
	Then I navigate to the Homepage and then In the Products Grid I delete All products

Scenario: [NOTINCLUDEDGENERALTEST] LawnCVS Product Creation Debug scenario
	Given I log in with the account saved in TReVor as: NoProductsAccount
	Then In the Products Grid I delete All products
	Then For CVS I create a product of type: Lawn & Garden (RUCC0395), save it as: CVSLawnGardenProduct1 and leave it in New Status
	Then I navigate to the Data Consent Tiers Page for CVS
	And I Check that The expected data tiers for CVS are the only ones present in the Data Consent Tiers Section
	When I click the Products in Scope button and confirm that a file is produced called CV_Report_DataUsageTier_<Date>.xlsx and save as CVSLawnGardenExcelFile
	Then I confirm that the excel file saved as: CVSLawnGardenExcelFile contains the WPSID for the Product saved as: CVSLawnGardenProduct1
	Then I delete the Supplier Report file saved as CVSLawnGardenExcelFile
	Then I navigate to the Homepage and then In the Products Grid I delete All products

Scenario: [NOTINCLUDEDGENERALTEST] Ticket 106898
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Then I select the: PM Walmart Monthly WMQC Report report from Advanced Reporting in SHA
	Then I Check that the Description Text for the Report: PM Walmart Monthly WMQC Report is shown as: Walmart Monthly Published WMQC subformat Report
	Then I enter start Date: 08-08-2019 and end Date: 11-14-2019 for the Advanced report then I click Submit
	And I wait for the Advanced Reporting Preparing Report popup to disappear
	#For below step need an actual file to get name etc
	Given I confirm that an excel file is produced called PM Monthly Status Report - Target.xlsx and save as 105329
	#Update Colum headings
	Then I confirm that the excel file saved as: 105329 contains the following columns:
		| Column   |
		| UPC Name |
	Then I delete the Advanced Report file saved as 105329

Scenario: [NOTINCLUDEDGENERALTEST] Ticket 106921
	Given I Use Test case 75142 to create a NEW PRODUCT and get it to Submitted status in SHA
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Then I select the: UPC Details for Registration - Specific Retailer report from Advanced Reporting in SHA
	Then I Check that the Description Text for the Report: UPC Details for Registration - Specific Retailer is shown as: Internal Use Only.  UPCs are listed for a chosen Retailer and include any additional UPC data such as Case Pack, Net Explosive Mass, and other details.
	Then In The advanced reporting screen I enter WPSID saved as: TestCase75142
	Then In The advanced reporting screen I choose retailer: CVS
	Then In the Advanced Reporting popup I click Submit
	And I wait for the Advanced Reporting Preparing Report popup to disappear
	#Change to Correct File Name
	Given I confirm that an excel file is produced called PM Monthly Status Report - Target.xlsx and save as 105329
	#Update Column headings
	Then I confirm that the excel file saved as: 105329 contains the following columns: and they are in the correct order.
		| Column   |
		| UPC Name |
	Then I delete the Advanced Report file saved as 105329

Scenario: [NOTINCLUDEDGENERALTEST] 96172
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Then I select the: Data Quality Review for Walmart report from Advanced Reporting in SHA
	Then I Check that the Description Text for the Report: Data Quality Review for Walmart is shown as: Output consists of numerous datapoints that will allow internal users to manage the output for their immediate purpose and provide an overview of the Walmart-specific data provided to the retailer as a means of Quality Assurance. The report allow you to filter by product Last publish Date range and is limited to 500 records.
	Then I enter start Date: 08-08-2019 and end Date: 11-14-2019 for the Advanced report then I click Submit
	And I wait for the Advanced Reporting Preparing Report popup to disappear
	#Change to Correct File Name
	Given I confirm that an excel file is produced called PM Monthly Status Report - Target.xlsx and save as 105329
	#Update Column headings
	Then I confirm that the excel file saved as: 105329 contains the following columns: and they are in the correct order.
		| Column   |
		| UPC Name |
	Then I delete the Advanced Report file saved as 105329

Scenario: [NOTINCLUDEDGENERALTEST] Ticket 106922
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Then I select the: UPCs Added Yesterday report from Advanced Reporting in SHA
	Then I Check that the Description Text for the Report: UPCs Added Yesterday is shown as: UPCs Added Yesterday
	Then In the Advanced Reporting popup I click Submit
	And I wait for the Advanced Reporting Preparing Report popup to disappear
	#Change to Correct File Name
	Given I confirm that an excel file is produced called PM Monthly Status Report - Target.xlsx and save as 105329
	#Update Column headings
	Then I confirm that the excel file saved as: 105329 contains the following columns: and they are in the correct order.
		| Column   |
		| UPC Name |
	Then I delete the Advanced Report file saved as 105329

Scenario: [NOTINCLUDEDGENERALTEST] Ticket 106924
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Then I select the: VOC Monthly Report - Walmart report from Advanced Reporting in SHA
	Then I Check that the Description Text for the Report: VOC Monthly Report - Walmart is shown as: Walmart Monthly VOC Report
	Then I enter start Date: 08-08-2019 and end Date: 11-14-2019 for the Advanced report then I click Submit
	And I wait for the Advanced Reporting Preparing Report popup to disappear
	#For below step need an actual file to get name etc
	Given I confirm that an excel file is produced called PM Monthly Status Report - Target.xlsx and save as 105329
	#Update Colum headings
	Then I confirm that the excel file saved as: 105329 contains the following columns:
		| Column   |
		| UPC Name |
	Then I delete the Advanced Report file saved as 105329

Scenario: [NOTINCLUDEDGENERALTEST] Ticket 106931
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Then I select the: WalMart DSV Products Report report from Advanced Reporting in SHA
	Then I Check that the Description Text for the Report: WalMart DSV Products Report is shown as: WalMart DSV Products Report
	Then In the Advanced Reporting popup I click Submit
	And I wait for the Advanced Reporting Preparing Report popup to disappear
	#Change to Correct File Name
	Given I confirm that an excel file is produced called PM Monthly Status Report - Target.xlsx and save as 105329
	#Update Column headings
	Then I confirm that the excel file saved as: 105329 contains the following columns: and they are in the correct order.
		| Column   |
		| UPC Name |
	Then I delete the Advanced Report file saved as 105329

Scenario: [NOTINCLUDEDGENERALTEST] Ticket 106932
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Then I select the: WM Slotting Code Report report from Advanced Reporting in SHA
	Then I Check that the Description Text for the Report: WM Slotting Code Report is shown as: WM Slotting Code Report
	Then I enter start Date: 08-08-2019 and end Date: 11-14-2019 for the Advanced report then I click Submit
	And I wait for the Advanced Reporting Preparing Report popup to disappear
	#For below step need an actual file to get name etc
	Given I confirm that an excel file is produced called PM Monthly Status Report - Target.xlsx and save as 105329
	#Update Colum headings
	Then I confirm that the excel file saved as: 105329 contains the following columns: and they are in the correct order.
		| Column   |
		| UPC Name |
	Then I delete the Advanced Report file saved as 105329

Scenario: [NOTINCLUDEDGENERALTEST] Ticket 107365
	Then I create a NEW PRODUCT, select all certifications on the UPC screen and get it to Submitted status in SHA
	Then I select the: Data Quality Review for Walmart report from Advanced Reporting in SHA
	Then I Check that the Description Text for the Report: Data Quality Review for Walmart is shown as: Output consists of numerous datapoints that will allow internal users to manage the output for their immediate purpose and provide an overview of the Walmart-specific data provided to the retailer as a means of Quality Assurance. The report allow you to filter by product Last publish Date range and is limited to 500 records.
	Then I enter start Date: 08-08-2019 and end Date: 11-14-2019 for the Advanced report then I click Submit
	And I wait for the Advanced Reporting Preparing Report popup to disappear
	#For below step need an actual file to get name etc
	#Change File Name
	Given I confirm that an excel file is produced called PM Monthly Status Report - Target.xlsx and save as 1073651
	#Update the column names below ( for checking Y only include the new headers)
	Then I confirm that the excel file saved as: 1073651 contains the following columns: and they are in the correct order.
		| Column   |
		| UPC Name |
	Then I confirm that the excel file saved as: 1073651 contains the WPSID saved as: TestCase75142 and has a 'Y' in the columns:
		| Column   |
		| UPC Name |
	Then I delete the Advanced Report file saved as 1073651
	Then I select the: UPC Details for Registration - Specific Retailer report from Advanced Reporting in SHA
	Then I Check that the Description Text for the Report: UPC Details for Registration - Specific Retailer is shown as: Internal Use Only.  UPCs are listed for a chosen Retailer and include any additional UPC data such as Case Pack, Net Explosive Mass, and other details.
	Then In The advanced reporting screen I enter WPSID saved as: TestCase75142
	Then In The advanced reporting screen I choose retailer: Wal-Mart/SAM'S CLUB
	Then In the Advanced Reporting popup I click Submit
	And I wait for the Advanced Reporting Preparing Report popup to disappear
	#Change to Correct File Name
	Given I confirm that an excel file is produced called PM Monthly Status Report - Target.xlsx and save as 1073652
	#Update Column headings
	Then I confirm that the excel file saved as: 1073652 contains the following columns: and they are in the correct order.
		| Column   |
		| UPC Name |
	Then I confirm that the excel file saved as: 1073652 contains the WPSID saved as: TestCase75142 and has a 'Y' in the columns:
		| Column   |
		| UPC Name |
	Then I delete the Advanced Report file saved as 1073652
	Then I select the: WalMart DSV Products Report report from Advanced Reporting in SHA
	Then I Check that the Description Text for the Report: WalMart DSV Products Report is shown as: WalMart DSV Products Report
	Then In the Advanced Reporting popup I click Submit
	And I wait for the Advanced Reporting Preparing Report popup to disappear
	#Change to Correct File Name
	Given I confirm that an excel file is produced called PM Monthly Status Report - Target.xlsx and save as 1073653
	#Update Column headings
	Then I confirm that the excel file saved as: 1073653 contains the following columns: and they are in the correct order.
		| Column   |
		| UPC Name |
	Then I confirm that the excel file saved as: 1073653 contains the WPSID saved as: TestCase75142 and has a 'Y' in the columns:
		| Column   |
		| UPC Name |
	Then I delete the Advanced Report file saved as 1073653
	
	Then I select the: WM Slotting Code Report report from Advanced Reporting in SHA
	Then I Check that the Description Text for the Report: WM Slotting Code Report is shown as: WM Slotting Code Report
	Then I enter start Date: 08-08-2019 and end Date: 11-14-2019 for the Advanced report then I click Submit
	And I wait for the Advanced Reporting Preparing Report popup to disappear
	#For below step need an actual file to get name etc
	Given I confirm that an excel file is produced called PM Monthly Status Report - Target.xlsx and save as 1073654
	#Update Colum headings
	Then I confirm that the excel file saved as: 1073654 contains the following columns:
		| Column   |
		| UPC Name |
	Then I confirm that the excel file saved as: 1073654 contains the WPSID saved as: TestCase75142 and has a 'Y' in the columns:
		| Column   |
		| UPC Name |
	Then I delete the Advanced Report file saved as 1073654

Scenario: [CVSTESTINGDEBUG] CERIAL
	Given I log in with the account saved in TReVor as: NoProductsAccount
	Then In the Products Grid I delete All products
	Then For CVS I create a product of type: Cleaning Supply (RUCC0397), save it as: CVSCleaningProduct1 and leave it in New Status
	Then I navigate to the CVS retailer Page then check that it contains the expected data tiers and that Products in Scope downloads a file, save it as: CVSCleaningExcelFile and check that is shows the expected product saved as: CVSCleaningProduct1

Scenario: [CVSTESTINGBATT] Battery

Given I log in with the account saved in TReVor as: NoProductsAccount
Then In the Products Grid I delete All products
Then For CVS I create a product of type: Battery (RUCC0733), save it as: CVSBatteryProduct1 and leave it in New Status
Then I navigate to the CVS retailer Page then check that it contains the expected data tiers and that Products in Scope downloads a file, save it as: CVSBatteryExcelFile and check that is shows the expected product saved as: CVSBatteryProduct1


Scenario: [CVSTESTINGPHAR] Pharm

Given I log in with the account saved in TReVor as: NoProductsAccount
Then In the Products Grid I delete All products
Then For CVS I create a product of type: Pharmacy (RUCC0393), save it as: CVSPharmacyProduct1 and leave it in New Status
Then I navigate to the CVS retailer Page then check that it contains the expected data tiers and that Products in Scope downloads a file, save it as: CVSPharmacyExcelFile and check that is shows the expected product saved as: CVSPharmacyProduct1


Scenario: [CVSTIERS] Daily Report -  CVS TIERS CHECK
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Then I select the: Daily Report - Data Tier Consent report from Advanced Reporting in SHA
	Then In the Advanced Reporting popup I click Submit
	And I wait for the Advanced Reporting Preparing Report popup to disappear
	Given I confirm that an excel file is produced called Daily Report - Data Tier Consent.xls and save as 115163
	#Update Column headings
	Then I confirm that the excel file saved as: 115163 contains the following columns:
		| Column              |
		| UPC Name            |
	Then I confirm that the excel file saved as: 115163 contains CVS products with tiers 2.1, 2.2 and 4.1 granted 	
	Then I delete the Advanced Report file saved as 115163

Scenario: [ProductProccess] WM CHALK COMPLETED
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Then I create a Chalk product for WalMart and Proccess it to completed and save it as: WMCHALKTEST1

Scenario: [SHALOADING] SHA LOADING DEBUG
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)

Scenario: [NOTINCLUDEDGENERALTEST] UPC: Part Number for staples check

#For TFS ticket 116739
#login
#create a product e.g chalk
#select staples
#enter PartNumber + details
#press continue and check next page loads
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then For Staples I create a product of RUCC Stationery and progress it to the UPC screen
Then I enter Container type: Metal Container, Size 40, Packaging type: spring fling packaging and Part number: ABC123 then click continue in the UPC screen

Scenario: [UPCSTEPPARTNUMBER] Part Num Staples

#101023 test case link to 116739 and finish
	#Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I log in with the account saved in TReVor as: ProductAccount
	And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
Then I save the product information as: TestCase105352
#And I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
Given I should see the Physical and Chemical Properties Page
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' should be showing the option: Solid
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' confirm option is selected: Solid
	Then In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
	Then In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Then In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
	Then in the Physical and Chemical Properties page I click Continue

#And I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
Given I should see the Product Information Page
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)' to: No
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue

#And I call Shared Step 29181 (Ingredients - add any chemical) with name: water
Given I should see the Ingredients Page
	Then In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	| component name | Water       | 100     |                     |               |             |
	Then in the Ingredients page I click Continue

And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Given the 'Select Retailers' window appears
Then In the 'Select Retailers' window I select the retailer: Staples
And in the New Product page I click Continue
Then I enter Container type: Metal Container, Size 40, Packaging type: NA and Part number: ABC123 then click continue in the UPC screen
#And I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
	Then in the Regulatory Documents to Provide page I click Continue

Given in the Additional Documents to Provide page I click Continue
Given in the Optional Reports and Documents Available for Purchase page I click Continue
#Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
#	| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Product's Dispensing Method | Partition Coefficient |
#	| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | Aerosol                     | 41.3005               |
	Then I should see the Safety Data Sheet Authoring - Additional Data (Optional) Page
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Personal Protection Equipment Recommended (select)' to: Gloves
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Autoignition Temperature (°C)' enter text: 800
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Minimum Ignition Energy (mJ)' enter text: 99
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Viscosity' enter text: 60
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Appearance' to: Clear
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor' to: Odorless
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor Threshold' to: No data available
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Partition Coefficient' enter text: 10
	Then in the Safety Data Sheet Authoring - Additional Data (Optional) page I click Continue
	Given in the Optional Comments page I click Continue
#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test
Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

Then I should see the Data Acceptance Page	
Given I click the Summary button in the Data Acceptance window
Given I switch to the Data Summary page
Then I confirm that the Prouct UPC Table shows in the UPC Number column the value of PART NUMBER for the UPC with Name: Chalk
Given I close the Data Summary tab
And I navigate to the home page
And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase105352



#Then I confirm that the Data Summary section Provide the product's UPC(s), including container type and size (ounces) shows the value for Container Type saved as: TestCase73082Container for UPC saved as: TestCase73082UPC
#check this below works and add scenario correctly. (also spp of "Prouct" fix)
#Then I confirm that the Prouct UPC Table shows in the UPC Number column the value of PART NUMBER for the UPC with Name: Chalk
#Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
#And I Click 'CONTINUE' on the 'Optional Reports and Documents Available for Purchase' Page
#And I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
#| Requires Table |
#| Parameters     |
#And I Click 'CONTINUE' in the 'COMMENTS' step shown
#And I With the Data Acceptance step shown - Click the 'Summary Button'
#And I Confirm the Summary View for your product shows in a new tab window
#And I Scroll down until you see the UPC question, Confirm you see PART NUMBER below the UPC Number heading
#
#
#And I Close the Summary View window and return to the Data Acceptance step in WERCSmart window
#And I On the left-navigation - Click the 'HOME ICON'
#And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: (.*)
#Given I click continue
#Then I should see the Data Acceptance Page	
#Given I click the Summary button in the Data Acceptance window
#Given I switch to the Data Summary page
#Then Product Name should be showing value: Super Packaging Type 1 (TM)
#Given I close the Data Summary tab




Scenario: [UPCCOLUMNS] UPCCOLUMNS after grid

	Given I Submit a new product which has a Case UPC and a regular UPC
	Given I navigate to the landing page
	And I call Shared Step (Login to WERCSmart - Premium Account)
	And I filter for the product saved as: TestCase87685
	And I click Row Actions for the first product returned
	Then I click on the Row Action: View UPCs
	Then I navigate to the View UPC tab and Check that the Product UPCs table contains the coloumn labeled 'UPC Name'	
	Given I generate a random UPC number and save as: UPC109503
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration'
	Given in the New Product page I click Continue
	And I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk
	Then I save the product information as: TestCase109503
	#Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I should see the Physical and Chemical Properties Page
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' should be showing the option: Solid
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' confirm option is selected: Solid
	Then In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
	Then In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Then In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
	Then in the Physical and Chemical Properties page I click Continue

	#Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Given I should see the Product Information Page
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)' to: No
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue

	#Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
	Given I should see the Ingredients Page
	Then In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	| component name | Sodium hydroxide       | 100     |                     |               |             |
	Then in the Ingredients page I click Continue

	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue) for
		| Retailer  |
		| Walgreens |
	Given I call Shared Step 87647 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC109503, container type: Paper bag and size: 2 do not click continue
	Given I click continue
	And  I call Shared Step 78080 (Regulatory Documents to Provide - Upload OSHA SDS)
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	#Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given I should see the Data Acceptance Page
	Then In the Data Acceptance Section, check 'Agreed' checkbox
	Then In the Data Acceptance Section, click 'Accept' button

	Then If purchase details are showing click confirm order
	Given I navigate to the landing page
	And I call Shared Step (Login to WERCSmart - Premium Account)	
	And I filter for the product saved as: TestCase109503
	And I click Row Actions for the first product returned
	Then I click on the Row Action: View UPCs
	Then I navigate to the View UPC tab and Check that the Product UPCs table contains the coloumn labeled 'UPC Name'

Scenario: [UPCCOLUMNS] View - UPC name column exists in the Product UPCs table

	Given I Submit a new product which has a Case UPC and a regular UPC
	Given I navigate to the landing page
	And I call Shared Step (Login to WERCSmart - Premium Account)
	And I filter for the product saved as: TestCase87685
	And I click Row Actions for the first product returned
	Then I click on the Row Action: View
	Then I navigate to the View tab for product saved as: TestCase87685 and Check that the Product UPCs table contains the coloumn labeled 'UPC Name'
	Given I generate a random UPC number and save as: UPC109503
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration'
	Given in the New Product page I click Continue
	And I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk
	Then I save the product information as: TestCase109503
	#Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I should see the Physical and Chemical Properties Page
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' should be showing the option: Solid
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' confirm option is selected: Solid
	Then In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
	Then In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Then In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
	Then in the Physical and Chemical Properties page I click Continue

	#Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Given I should see the Product Information Page
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)' to: No
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue

	#Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
	Given I should see the Ingredients Page
	Then In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	| component name | Sodium hydroxide       | 100     |                     |               |             |
	Then in the Ingredients page I click Continue

	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue) for
		| Retailer  |
		| Walgreens |
	Given I call Shared Step 87647 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC109503, container type: Paper bag and size: 2 do not click continue
	Given I click continue
	And  I call Shared Step 78080 (Regulatory Documents to Provide - Upload OSHA SDS)
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	#Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given I should see the Data Acceptance Page
	Then In the Data Acceptance Section, check 'Agreed' checkbox
	Then In the Data Acceptance Section, click 'Accept' button

	Then If purchase details are showing click confirm order
	Given I navigate to the landing page
	And I call Shared Step (Login to WERCSmart - Premium Account)	
	And I filter for the product saved as: TestCase109503
	And I click Row Actions for the first product returned
	Then I click on the Row Action: View
	Then I navigate to the View tab for product saved as: TestCase109503 and Check that the Product UPCs table contains the coloumn labeled 'UPC Name'

Scenario: [CVSQA] CVS DATA TIERS IN QA DEBUG
	Given I log in with the account saved in TReVor as: NoProductsAccount
	Then In the Products Grid I delete All products	
	Then For CVS I create a product of type: Artist Supply (RUCC0384), save it as: CVSArtistProduct1 and leave it in New Status
	Then I navigate to the CVS retailer Page then check that it contains the expected data tiers and that Products in Scope downloads a file, save it as: CVSArtistExcelFile and check that is shows the expected product saved as: CVSArtistProduct1


Scenario: [IngredientsTableCheck] Non Cleaning Product Ingredients Check

	Given I generate a random UPC number and save as: UPC56214
	#Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I log in with the account saved in TReVor as: ProductAccount
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration'
	Given in the New Product page I click Continue
	And I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk
	Then I save the product information as: TestCase56214
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

	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
	| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName   |
	| Propane       | 25      | false               | false       |              |
	| Water         | 25      | false               | false       | Water        |
	| Formaldehyde  | 25      | true                | false       | Formaldehyde |
	| Sodium        | 25      | false               | true        |              |
	#And I call Shared Step 29181 (Ingredients - add any chemical) with name: Chlorine

	# then go back to the table page and check contains same as above data.  (navigate to the .. page etc)




	#And I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)	
	Given I should see the Inventory Status, Prop 65 (US) Page
	Then In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	Then In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page I click Continue

	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	#Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
	Then in the Regulatory Documents to Provide page I click Continue

	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	And I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
		| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
	#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Test
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	And I should see the Data Acceptance Page
	Given I click the Summary button in the Data Acceptance window
	Then I switch to the Data Summary page
	And I close the window that opened
	And I navigate to the home page





Scenario: [IngredientsTableCheck] Non Cleaning Ingredients Table navigate back
	#Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I log in with the account saved in TReVor as: ProductAccount
	Given I generate a random UPC number and save as: UPC109230
	And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
	Then I save the product information as: TestCase109230
	#Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
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

	Given I call Shared Step 65447 Ingredients - Add any chemical - DO Not click Continue
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName        |
		| Water         | 100     | true                | false       | Aqua (Water, Eau) |
	Given I call Shared Step 65447 Ingredients - Add any chemical - DO Not click Continue
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Chlorine      | 100     | false               | true        |            |
	Given I call Shared Step 65447 Ingredients - Add any chemical - DO Not click Continue
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Formaldehyde  | 100     | false               | false       |            |
	Given I call Shared Step 65447 Ingredients - Add any chemical - DO Not click Continue
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName             |
		| Sodium        | 100     | true                | false       | Undisclosed Ingredient |
	And I click continue
	Then I should see the Regulatory Information 1 Page for the New Product
	Given In the New Product page I click tab: Physical and Chemical Properties
	And I click the page heading: Ingredients
	And I confirm that the ingredients table looks as follows:
		| CAS Number/ChemicalName | Percent | Publicly Disclosed? | Trade Secret? | INCI Name              |
		| Water                   | 100     | Yes                 | No            | Aqua (Water, Eau)      |
		| Chlorine                | 100     | No                  | Yes           | Choose...              |
		| Formaldehyde            | 100     | No                  | No            | Choose...              |
		| Sodium                  | 100     | Yes                 | No            | Undisclosed Ingredient |
	And I click continue
	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue) for
		| Retailer  |
		| Walgreens |
	Given I call Shared Step 87647 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC109230, container type: Paper bag and size: 2 do not click continue
	And I click continue
	And I call Shared Step 78080 (Regulatory Documents to Provide - Upload OSHA SDS)
	And in the Additional Documents to Provide page I click Continue
	And in the Optional Reports and Documents Available for Purchase page I click Continue
	#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	Given I click the Summary button in the Data Acceptance window
	Then I switch to the Data Summary page
	And In the Data Summary page, I confirm that the Ingredients table matches the following:
		| CAS Number/ChemicalName | Percent | Publicly Disclosed? | Trade Secret? | INCI Name              |
		| Water                   | 100     | Yes                 | No            | Aqua (Water, Eau)      |
		| Chlorine                | 100     | No                  | Yes           | Trade Secret           |
		| Formaldehyde            | 100     | No                  | No            |                        |
		| Sodium                  | 100     | Yes                 | No            | Undisclosed Ingredient |
	And I close the window that opened
	#Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given I should see the Data Acceptance Page
	Then In the Data Acceptance Section, check 'Agreed' checkbox
	Then In the Data Acceptance Section, click 'Accept' button

	And I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Submitted Status for saved as: TestCase109230)
	Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase109230)
	And I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase109230)
	And I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase109230)
	Given I call Shared Step 75347 (WPS Studio - PD+ - set all data and publish using rule and Doc queue - CKLT, NGHS and SBCS) for product saved as: TestCase109230
	And I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase109230)
	Given I call Shared Step 59066 (Go to SHA Manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase109230)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase109230 and its status is: Accepted or Completed
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase109230)
	Given I call Shared Step 51664 (SHA - Accepted Product - set Retailers to Completed for saved as: TestCase109230) for
		| Retailer  |
		| Walgreens |
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase109230)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase109230 and its status is: Completed
	And I call Shared Step 43587 - SHA Manager > Completed Product - Add Recert reason 20 for product saved as: TestCase109230
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase109230)
	And In the SHA manager grid I see the WPS ID I have saved as product: TestCase109230 and its font is red indicating a recertification
	Given I navigate to the landing page
	#Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I log in with the account saved in TReVor as: ProductAccount
	And I filter for the product saved as: TestCase109230
	And I click Row Actions for the first product returned
	And I click on the Row Action: View
	Then I switch to the Data Summary page
	And In the Data Summary page, I confirm that the Ingredients table matches the following:
		| CAS Number/ChemicalName | Percent | Publicly Disclosed? | Trade Secret? | INCI Name              |
		| Water                   | 100     | Yes                 | No            | Aqua (Water, Eau)      |
		| Chlorine                | 100     | No                  | Yes           | Trade Secret           |
		| Formaldehyde            | 100     | No                  | No            |                        |
		| Sodium                  | 100     | Yes                 | No            | Undisclosed Ingredient |
	And I close the window that opened
	And I filter for the product saved as: TestCase109230
	And I click Row Actions for the first product returned
	And I click on the Row Action: Update Required
	Given In the New Product page I click tab: Physical and Chemical Properties
	And I click the page heading: Ingredients
	And I confirm that the ingredients table looks as follows:
		| CAS Number/ChemicalName | Percent | Publicly Disclosed? | Trade Secret? | INCI Name              |
		| Water                   | 100     | Yes                 | No            | Aqua (Water, Eau)      |
		| Chlorine                | 100     | No                  | Yes           | Choose...              |
		| Formaldehyde            | 100     | No                  | No            | Choose...              |
		| Sodium                  | 100     | Yes                 | No            | Undisclosed Ingredient |
	And I navigate to the home page

@AssignedDebug
Scenario: [AssignedToAcceptedTest] NotAcceptedDebugScenario
	Given I create a product and take to completed using Test Case 75335 and save as: TestCase75321
	Given I navigate to the landing page
	And I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	And I filter the products by: Accepted by Retailers
	And I Confirm the Products shown display the Green Colour Status - which is the Accepted by Retailers
	And I filter for the product saved as: TestCase75321
	And I call Shared Step 75130 - Bulk Actions - Select Forward Product Registration
	Then I should see the header: Forward Product Registration on the Forward Product Registration window
	And I enter the text: saved as TestCase75321 in the 'Search by WPS ID or Product Name' field
	And In the Foward Product Registration Screen I should see product: saved as TestCase75321
	And In the Foward Product Registration Screen I Select the product: saved as TestCase75321
	And I click continue on the Forward Product Registration page
	And In the Forward Product Registration Screen I select a retailer under Other Retailers and save as TestCase75321Retailer
	And I click continue on the Forward Product Registration page
	And I call Shared Step 75140 - Forwarding - Select Products & UPCs step - Add Any missing data and select 1 UPC - Continue and save UPC as TestCase75321UPC
	Then I should see the subheading 3: Product Results on the Forward Product Registration window
	Then I confirm that for UPC Number saved as TestCase75321UPC the retailer is displayed as saved as TestCase75321Retailer
	And I confirm that there are NO Errors displayed for the Product
	And I click continue on the Forward Product Registration page
	Then I should see the subheading 3: Review & Submit on the Forward Product Registration window
	Then I select the true radio for the 'Are Statements True' question under the Review and Submit tab
	And I click continue on the Forward Product Registration page
	And In the Purchase Summary screen I confirm the Purchase Summary header is displayed
	Then In the Thank You screen I confirm the following statement is shown: Thank you for registering your product on WERCSmart for assessment.
	And I call Shared Step 65080 (Login to Studio and Open SHA manager)
	And I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase75321)
	And I Confirm the Product shows status: Completed for retailer: saved as retailer
	And I Confirm the Product shows status: Submitted for retailer: saved as TestCase75321Retailer
	And I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase75321)
	And I call Shared Step 75309 (SHA > Select Product > UPC Retailer and Feed) for product saved as: TestCase75321
	And I confirm the Product UPC window has opened
	And I confirm that retailer saved as: TestCase75321Retailer appears for UPC saved as: TestCase75321UPC
	And I close the current window and switch to the main window in Studio
	And I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase75321)
	And I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase75321)
	And I Confirm the Product shows status: Completed for retailer: saved as retailer
	And I Confirm the Product shows status: Accepted for retailer: saved as TestCase75321Retailer


	Scenario: [CVSTIERSCLEANING] CVS - CLEANING TEST

	Given I log in with the account saved in TReVor as: NoProductsAccount
	Then In the Products Grid I delete All products
	Then For CVS I create a product of type: Cleaning Supply (RUCC0397), save it as: CVSCleaningProduct1 and leave it in New Status
	Then I navigate to the CVS retailer Page then check that it contains the expected data tiers and that Products in Scope downloads a file, save it as: CVSCleaningExcelFile and check that is shows the expected product saved as: CVSCleaningProduct1

	#================================================================= DOT ==========================================================================#

	
		Then I should see the following error text displayed in the UPC screen: 1
		Then I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase10006

	
		Then I should see the following error text displayed in the UPC screen: 1
		Then I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase10003

	
		Then I should see the following error text displayed in the UPC screen: 1
		Then I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase10021


#================================================================== IATA + DOT =====================================================================#

	
		Then I should see the following error text displayed in the UPC screen: 1
		Then I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase20002



	
		Then I should see the following error text displayed in the UPC screen: 1
		Then I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase20016


	

	Scenario: [Mode7] Mode 7 - Scenario 23 UPC Transportation
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration'
	Given in the New Product page I click Continue
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Lead Acid (Non-Spillable) Battery
	Then I save the product information as: TestCase97484
	Given I call Shared Step 59927 (Primary Physical State > Solid only available – Without Water Solubility question)
	Given I should see the Product Information Page
	Given I call Shared Step 102767 (Product Information (Battery flow - not Lithium) - OSHA (No), DSV (No), PLP (No), GNFR (No))
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Water         | 100     | false               | false       |            |		
	Given I call Shared Step 57637 (Regulatory Information 1 - TSCA & CEPA shown, No to PROP 65 - Continue - Happy Path)
	And I should see the Transportation Details 1 Page	
	And I set the Product is Regulated for Transport field to: Yes
	And I set the Select all modes of transport that you've classified the product for field to: IMDG
	And I select option: Shipping with limited quantity under section: Select all modes of transport that you've classified the product for and subsection: IMDG
	And I click continue
	And I set the UN Number field to: UN2650
	And I click continue	
	Given I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue) for
		| Retailer  |
		| Walgreens |
	Given I click the 'Add' button
	Then I generate a random UPC number and save as: RandomUPC91076
	Given I add the following into the UPC Fields
		| UPC Number              | Container Type    | Size | DPCI | Quantity |
		| saved as RandomUPC91076 | Plastic Container | 55   |      | 1        |
	Given I Check that in the UPC screen, under the Transportation Column to option IMDG is checked
	Then I Check that in the UPC screen, under the Transportation Column to option Shipping with limited quantity is checked
	Given I click continue
	Then I should see a list style form error with text: UPC failing Transportation Rules. Review your Transport overrides.	
	#Then I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCaseXXXXX

	Scenario: [Mode7] Mode 7 - Scenario 9 UPC Transportation
	#This scenario needs updating to a differnt scenario (one that takes haz class of 2.x, but first need to to ask about "subsidery haz class"?
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC60116
	Given I delete all products with UPC Number: saved as UPC60116
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration'
	Given in the New Product page I click Continue
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Anti-Static Product - Aerosol
	Then I save the product information as: TestCase60116
	#Given I call Shared Step 60310 (Product Information - Without Child question)
	Given I should see the Product Information Page
	Then In the Product Information Section, set the option in section: 'Which best describes your product, including when FIFRA 25(b) Exempt' to: Product is not a pesticide and does not make or imply a pesticidal claim on the labeling or in the product description (ex. kills, sterilizes, disinfects, sanitizes, antimicrobial)
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Given in the Product Information page I click Continue

	Given I call Shared Step 57111 (Enter Product Data for Physical State - Aerosol only)
	Given I click continue
	Then I should see an error message: ALERT! The ingredient table does not include a compressed gas (Bag-On-Valve) or a propellant. Please update your ingredients to include the propellant before proceeding.
	Given I call Shared Step 69557 (Enter Ingredients for Aerosol Propellent)
	#Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I should see the Inventory Status, Prop 65 (US) Page
	Then In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	Then In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page I click Continue

	#Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	#Given I call Shared Step 65705 (Transportation - DOT UN step - Enter UN1950, select Aerosols,  2.1, None, add technical name, Click Continue)
	And I should see the Transportation Details 1 Page	
	And I set the Product is Regulated for Transport field to: Yes
	And I set the Select all modes of transport that you've classified the product for field to: IMDG
	And I select option: Shipping with limited quantity under section: Select all modes of transport that you've classified the product for and subsection: IMDG
	And I click continue
	And I set the UN Number field to: UN3241 
	And I click continue
	Given I call Shared Step 62710 (Confirm VOC OTC/CARB heading and select No to FIRST QUESTION ONLY - Happy Path)
	Given I call Shared Step 60468 (VOC - CARB only required - enter value - Continue - Happy Path)
	Given I click continue
	Given I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue) for
		| Retailer  |
		| Walgreens |
	Given I click the 'Add' button
	Then I generate a random UPC number and save as: RandomUPC91076
	Given I add the following into the UPC Fields
		| UPC Number              | Container Type | Size | DPCI | Quantity |
		| saved as RandomUPC91076 | Aerosol Can    | 200   |      |          |
	Given I Check that in the UPC screen, under the Transportation Column to option IMDG is checked
	Then I Check that in the UPC screen, under the Transportation Column to option Shipping with limited quantity is checked
	Given I click continue
	Then I should see a list style form error with text: UPC failing Transportation Rules. Review your Transport overrides.	
	#Then I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCaseXXXXX

	Scenario: [Mode6] Mode 6 - Scenario 3 UPC Transportation

	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC60116
	Given I delete all products with UPC Number: saved as UPC60116
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration'
	Given in the New Product page I click Continue
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Anti-Static Product - Aerosol
	Then I save the product information as: TestCase60116
	#Given I call Shared Step 60310 (Product Information - Without Child question)
	Given I should see the Product Information Page
	Then In the Product Information Section, set the option in section: 'Which best describes your product, including when FIFRA 25(b) Exempt' to: Product is not a pesticide and does not make or imply a pesticidal claim on the labeling or in the product description (ex. kills, sterilizes, disinfects, sanitizes, antimicrobial)
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Given in the Product Information page I click Continue

	Given I call Shared Step 57111 (Enter Product Data for Physical State - Aerosol only)
	Given I click continue
	Then I should see an error message: ALERT! The ingredient table does not include a compressed gas (Bag-On-Valve) or a propellant. Please update your ingredients to include the propellant before proceeding.
	Given I call Shared Step 69557 (Enter Ingredients for Aerosol Propellent)
	#Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I should see the Inventory Status, Prop 65 (US) Page
	Then In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	Then In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page I click Continue

	#Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	#Given I call Shared Step 65705 (Transportation - DOT UN step - Enter UN1950, select Aerosols,  2.1, None, add technical name, Click Continue)
	And I should see the Transportation Details 1 Page	
	And I set the Product is Regulated for Transport field to: Yes
	And I set the Select all modes of transport that you've classified the product for field to: DOT
	And I select option: Shipping with limited quantity under section: Select all modes of transport that you've classified the product for and subsection: DOT
	And I set the Provide Special Permit numbers (if applicable) field to: 14188 	
	And I click continue
	And I set the UN Number field to: UN3159 
	And I click continue
	Given I call Shared Step 62710 (Confirm VOC OTC/CARB heading and select No to FIRST QUESTION ONLY - Happy Path)
	Given I call Shared Step 60468 (VOC - CARB only required - enter value - Continue - Happy Path)
	Given I click continue
	Given I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue) for
		| Retailer  |
		| Walgreens |
	Given I click the 'Add' button
	Then I generate a random UPC number and save as: RandomUPC91076
	Given I add the following into the UPC Fields
		| UPC Number              | Container Type | Size | DPCI | Quantity |
		| saved as RandomUPC91076 | Aerosol Can    | 55   |      |          |
	Given I Check that in the UPC screen, under the Transportation Column to option DOT is checked
	Then I Check that in the UPC screen, under the Transportation Column to option Shipping with limited quantity is checked
	Given I click continue
	Then I should see a list style form error with text: UPC failing Transportation Rules. Review your Transport overrides.	
	#Then I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCaseXXXXX

	Scenario: [Mode6] Mode 6 - Scenario 28 UPC Trasnportation

	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bleach
		And I call Shared Step 74340 (Product Information - Pesticide= Not considered, SOLD=US, everything else = No - Continue)
And I call Shared Step 74339 (Physical and Chemical Properties - Select Liquid and enter only Secondary state, Relative Density, pH)
	And I set the Boiling Point (in Celsius) field to: 1
	And I set the Flash Point (in Celsius) field to: 65
	And The following options should be displayed exclusively for section: Flash Point Testing Method Used
	| Option            |
	| Closed cup method |
	And I set the Flash Point Testing Method Used field to: Closed cup method
	And I set the Select the best Water Solubility description field to: Insoluble
	And I click continue
	#And I call Shared Step 29181 (Ingredients - add any chemical) with name: water
	Given I should see the Ingredients Page
	Then In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	| component name | Water       | 100     |                     |               |             |
	Then in the Ingredients page I click Continue

	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	And I should see the Transportation Details 1 Page
	And The following options should be displayed exclusively for section: Product is Regulated for Transport
	| Option                               |
	| Yes                                  |
	| No, due to an exemption or exception |
	And I set the Product is Regulated for Transport field to: Yes
	And I set the Select all modes of transport that you've classified the product for field to: DOT
	And I select option: Shipping with limited quantity under section: Select all modes of transport that you've classified the product for and subsection: DOT
	And I click continue
	And I set the UN Number field to: UN2258
	And I click continue
	Given I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue) for
		| Retailer  |
		| Walgreens |
	Given I click the 'Add' button
	Then I generate a random UPC number and save as: RandomUPC91076
	Given I add the following into the UPC Fields
		| UPC Number              | Container Type    | Size | DPCI | Quantity |
		| saved as RandomUPC91076 | Plastic Container | 55   |      |          |
	Given I Check that in the UPC screen, under the Transportation Column to option DOT is checked
	Then I Check that in the UPC screen, under the Transportation Column to option Shipping with limited quantity is checked
	Given I click continue
	Then I should see a list style form error with text: UPC failing Transportation Rules. Review your Transport overrides.	
	#Then I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCaseXXXXX

	Scenario: [Mode6] Mode 6 - Scenario 15 UPC Transportation
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration'
	Given in the New Product page I click Continue
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Lead Acid (Non-Spillable) Battery
	Then I save the product information as: TestCase97484
	Given I call Shared Step 59927 (Primary Physical State > Solid only available – Without Water Solubility question)
	Given I should see the Product Information Page
	Given I call Shared Step 102767 (Product Information (Battery flow - not Lithium) - OSHA (No), DSV (No), PLP (No), GNFR (No))
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName       | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Ammonium dichromate | 100     | false               | false       |            |		
	Given I call Shared Step 57637 (Regulatory Information 1 - TSCA & CEPA shown, No to PROP 65 - Continue - Happy Path)
	And I should see the Transportation Details 1 Page	
	And I set the Product is Regulated for Transport field to: Yes
	And I set the Select all modes of transport that you've classified the product for field to: DOT
	And I select option: Shipping with limited quantity under section: Select all modes of transport that you've classified the product for and subsection: DOT
	And I click continue
	And I set the UN Number field to: UN1439
	And I click continue	
	Given I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue) for
		| Retailer  |
		| Walgreens |
	Given I click the 'Add' button
	Then I generate a random UPC number and save as: RandomUPC91076
	Given I add the following into the UPC Fields
		| UPC Number              | Container Type    | Size | DPCI | Quantity |
		| saved as RandomUPC91076 | Plastic Container | 55   |      | 1        |
	Given I Check that in the UPC screen, under the Transportation Column to option DOT is checked
	Then I Check that in the UPC screen, under the Transportation Column to option Shipping with limited quantity is checked
	Given I click continue
	Then I should see a list style form error with text: UPC failing Transportation Rules. Review your Transport overrides.	
	#Then I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCaseXXXXX


	Scenario: [Mode4x5] Mode 4x5 - Scenario 4 UPC Transportation

	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC60116
	Given I delete all products with UPC Number: saved as UPC60116
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration'
	Given in the New Product page I click Continue
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Anti-Static Product - Aerosol
	Then I save the product information as: TestCase60116
	#Given I call Shared Step 60310 (Product Information - Without Child question)
	Given I should see the Product Information Page
	Then In the Product Information Section, set the option in section: 'Which best describes your product, including when FIFRA 25(b) Exempt' to: Product is not a pesticide and does not make or imply a pesticidal claim on the labeling or in the product description (ex. kills, sterilizes, disinfects, sanitizes, antimicrobial)
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Given in the Product Information page I click Continue

	Given I call Shared Step 57111 (Enter Product Data for Physical State - Aerosol only)
	Given I click continue
	Then I should see an error message: ALERT! The ingredient table does not include a compressed gas (Bag-On-Valve) or a propellant. Please update your ingredients to include the propellant before proceeding.
	Given I call Shared Step 69557 (Enter Ingredients for Aerosol Propellent)
	#Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I should see the Inventory Status, Prop 65 (US) Page
	Then In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	Then In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page I click Continue

	#Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	#Given I call Shared Step 65705 (Transportation - DOT UN step - Enter UN1950, select Aerosols,  2.1, None, add technical name, Click Continue)
	And I should see the Transportation Details 1 Page	
	And I set the Product is Regulated for Transport field to: Yes
	And I set the Select all modes of transport that you've classified the product for field to: IATA
	And I select option: Shipping with consumer commodity under section: Select all modes of transport that you've classified the product for and subsection: IATA
	And I click continue
	And I set the UN Number field to: UN1950
	And I set the Proper Shipping Name field to: Aerosols, flammable
	And I set the Hazard Class (select) field to: 2.1	
	And I click continue
	Given I call Shared Step 62710 (Confirm VOC OTC/CARB heading and select No to FIRST QUESTION ONLY - Happy Path)
	Given I call Shared Step 60468 (VOC - CARB only required - enter value - Continue - Happy Path)
	Given I click continue
	Given I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue) for
		| Retailer  |
		| Walgreens |
	Given I click the 'Add' button
	Then I generate a random UPC number and save as: RandomUPC91076
	Given I add the following into the UPC Fields
		| UPC Number              | Container Type | Size | DPCI | Quantity |
		| saved as RandomUPC91076 | Aerosol Can    | 55   |      |          |
	Given I Check that in the UPC screen, under the Transportation Column to option IATA is checked
	Then I Check that in the UPC screen, under the Transportation Column to option Shipping with consumer commodity is checked
	Given I click continue
	Then I should see a list style form error with text: UPC failing Transportation Rules. Review your Transport overrides.	
	#Then I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCaseXXXXX

	Scenario: [Mode4x5] Mode 4x5 - Scenario 15 UPC Trasnportation

	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bleach
		And I call Shared Step 74340 (Product Information - Pesticide= Not considered, SOLD=US, everything else = No - Continue)
And I call Shared Step 74339 (Physical and Chemical Properties - Select Liquid and enter only Secondary state, Relative Density, pH)
	And I set the Boiling Point (in Celsius) field to: 1
	And I set the Flash Point (in Celsius) field to: 65	
	And I set the Flash Point Testing Method Used field to: Closed cup method
	And I set the Select the best Water Solubility description field to: Insoluble
	And I click continue
	#And I call Shared Step 29181 (Ingredients - add any chemical) with name: water
	Given I should see the Ingredients Page
	Then In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	| component name | Water       | 100     |                     |               |             |
	Then in the Ingredients page I click Continue

	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	And I should see the Transportation Details 1 Page
	And I set the Product is Regulated for Transport field to: Yes
	And I set the Select all modes of transport that you've classified the product for field to: IATA
	And I select option: Shipping with consumer commodity under section: Select all modes of transport that you've classified the product for and subsection: IATA
	And I click continue
	And I set the UN Number field to: UN3175
	And I click continue
	Given I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue) for
		| Retailer  |
		| Walgreens |
	Given I click the 'Add' button
	Then I generate a random UPC number and save as: RandomUPC91076
	Given I add the following into the UPC Fields
		| UPC Number              | Container Type    | Size | DPCI | Quantity |
		| saved as RandomUPC91076 | Plastic Container | 55   |      |          |
	Given I Check that in the UPC screen, under the Transportation Column to option IATA is checked
	Then I Check that in the UPC screen, under the Transportation Column to option Shipping with consumer commodity is checked
	Given I click continue
	Then I should see a list style form error with text: UPC failing Transportation Rules. Review your Transport overrides.	
	#Then I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCaseXXXXX


	Scenario: [Mode4x5] Mode 4x5 - Scenario 20 UPC Trasnportation

	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bleach
	And I call Shared Step 74339 (Physical and Chemical Properties - Select Liquid and enter only Secondary state, Relative Density, pH)
	And I set the Boiling Point (in Celsius) field to: 1
	And I set the Flash Point (in Celsius) field to: 65	
	And I set the Flash Point Testing Method Used field to: Closed cup method
	And I set the Select the best Water Solubility description field to: Insoluble
	And I click continue
	Given I call Shared Step 74340 (Product Information - Pesticide= Not considered, SOLD=US, everything else = No - Continue)
	#And I call Shared Step 29181 (Ingredients - add any chemical) with name: water
	Given I should see the Ingredients Page
	Then In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	| component name | Water       | 100     |                     |               |             |
	Then in the Ingredients page I click Continue

	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	And I should see the Transportation Details 1 Page
	And I set the Product is Regulated for Transport field to: Yes
	And I set the Select all modes of transport that you've classified the product for field to: IATA
	And I select option: Shipping with limited quantity under section: Select all modes of transport that you've classified the product for and subsection: IATA
	And I click continue
	And I set the UN Number field to: UN2307
	And I click continue
	Given I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue) for
		| Retailer  |
		| Walgreens |
	Given I click the 'Add' button
	Then I generate a random UPC number and save as: RandomUPC91076
	Given I add the following into the UPC Fields
		| UPC Number              | Container Type    | Size | DPCI | Quantity |
		| saved as RandomUPC91076 | Plastic Container | 55   |      |          |
	Given I Check that in the UPC screen, under the Transportation Column to option IATA is checked
	Then I Check that in the UPC screen, under the Transportation Column to option Shipping with limited quantity is checked
	Given I click continue
	Then I should see a list style form error with text: UPC failing Transportation Rules. Review your Transport overrides.	
	#Then I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCaseXXXXX


	Scenario: [Mode4x5] Mode 4x5 - Scenario 25 UPC Transportation
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration'
	Given in the New Product page I click Continue
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Lead Acid (Non-Spillable) Battery
	Then I save the product information as: TestCase97484
	Given I call Shared Step 59927 (Primary Physical State > Solid only available – Without Water Solubility question)
	Given I should see the Product Information Page
	Given I call Shared Step 102767 (Product Information (Battery flow - not Lithium) - OSHA (No), DSV (No), PLP (No), GNFR (No))
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| water  | 100     | false               | false       |            |		
	Given I call Shared Step 57637 (Regulatory Information 1 - TSCA & CEPA shown, No to PROP 65 - Continue - Happy Path)
	And I should see the Transportation Details 1 Page	
	And I set the Product is Regulated for Transport field to: Yes
	And I set the Select all modes of transport that you've classified the product for field to: IATA
	And I select option: Shipping with consumer commodity under section: Select all modes of transport that you've classified the product for and subsection: IATA
	And I click continue
	And I set the UN Number field to: UN1579
	And I click continue	
	Given I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue) for
		| Retailer  |
		| Walgreens |
	Given I click the 'Add' button
	Then I generate a random UPC number and save as: RandomUPC91076
	Given I add the following into the UPC Fields
		| UPC Number              | Container Type    | Size | DPCI | Quantity |
		| saved as RandomUPC91076 | Plastic Container | 55   |      | 1        |
	Given I Check that in the UPC screen, under the Transportation Column to option IATA is checked
	Then I Check that in the UPC screen, under the Transportation Column to option Shipping with consumer commodity is checked
	Given I click continue
	Then I should see a list style form error with text: UPC failing Transportation Rules. Review your Transport overrides.	
	#Then I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCaseXXXXX

	
	Scenario: [Mode4x5] Mode 4x5 - Scenario 35 UPC Transportation
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration'
	Given in the New Product page I click Continue
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Lead Acid (Non-Spillable) Battery
	Then I save the product information as: TestCase97484
	Given I call Shared Step 102767 (Product Information (Battery flow - not Lithium) - OSHA (No), DSV (No), PLP (No), GNFR (No))
	Given I call Shared Step 59927 (Primary Physical State > Solid only available – Without Water Solubility question)
	Given I should see the Product Information Page
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Benzaldehyde  | 100     | false               | false       |            |		
	Given I call Shared Step 57637 (Regulatory Information 1 - TSCA & CEPA shown, No to PROP 65 - Continue - Happy Path)
	And I should see the Transportation Details 1 Page	
	And I set the Product is Regulated for Transport field to: Yes
	And I set the Select all modes of transport that you've classified the product for field to: IATA
	And I select option: Shipping with consumer commodity under section: Select all modes of transport that you've classified the product for and subsection: IATA
	And I click continue
	And I set the UN Number field to: UN1990
	And I click continue	
	Given I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue) for
		| Retailer  |
		| Walgreens |
	Given I click the 'Add' button
	Then I generate a random UPC number and save as: RandomUPC91076
	Given I add the following into the UPC Fields
		| UPC Number              | Container Type    | Size | DPCI | Quantity |
		| saved as RandomUPC91076 | Plastic Container | 55   |      | 1        |
	Given I Check that in the UPC screen, under the Transportation Column to option IATA is checked
	Then I Check that in the UPC screen, under the Transportation Column to option Shipping with consumer commodity is checked
	Given I click continue
	Then I should see a list style form error with text: UPC failing Transportation Rules. Review your Transport overrides.	
	#Then I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCaseXXXXX

		Then I add the following into the UPC Fields
		| Field         | Value             |
		| UPCNumber     | saved as UPC20034 |
		| ContainerType | Glass Container   |
		| Size          | 32                |
		And in the New Product page I click Continue
		Then I should see the following error text displayed in the UPC screen: 1
		Then I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase20034


#======================================================================== IATA ======================================================================


Scenario: [StagingRegressionFixes] CVS Artists supply to to new
	Given I log in with the account saved in TReVor as: NoProductsAccount
	Then In the Products Grid I delete All products	
	Then For CVS I create a product of type: Home Improvement (RUCC0394), save it as: CVSHomeProduct1 and leave it in New Status
	Then I navigate to the CVS retailer Page then check that it contains the expected data tiers and that Products in Scope downloads a file, save it as: CVSHomeExcelFile and check that is shows the expected product saved as: CVSHomeProduct1

Scenario: [StagingRecertUPCTransportation] Recertification and Transporation 1 changes leads to popup
#Issue here is that the product we are using in completed doe not have transporation details 1 in the flow. 
	Given I create a product with name: 8450713 and take to completed using Test Case 84109 and save as: TestCase845073
	#Given I take a product from completed to recertification using Test Case 84511 saved: TestCase845073
	#And I call Shared Step 80488 - SHA Manager > completed 3rd party > Add to recert 40 for product saved as: TestCase42196
	#And I call Shared Step 51349 - SHA Manager > Assigned Product - Add Recert reason 20 for product saved as: TestCase77857
	And I call Shared Step 43587 - SHA Manager > Completed Product - Add Recert reason 20 for product saved as: TestCase845073
	Given I navigate to the landing page
	And I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	And I filter for the product saved as: TestCase845073
	And I click Row Actions for the first product returned
	And I click on the Row Action: Update Required
	Given In the New Product page I click tab: Physical and Chemical Properties
	And I click the page heading: Ingredients

Scenario: [StagingRecertUPCTransportation] Using a non complete product
#may be worth either cutting some of the steps or making a shared step that creates the prouduct (shorten the specflow)
Given I log in with the account saved in TReVor as: ProductAccount
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration'
	Given in the New Product page I click Continue
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Fertilizer
	And I should see the Physical and Chemical Properties Page
	Then I save the product information as: TestCase65947
	And The following options should be displayed for section: Primary Physical State
		| Option |
		| Liquid |
		| Solid  |
	And I set the Primary Physical State option to: Liquid
	And I set the Secondary Physical State option to: Liquid
	And I set the Relative Density option to: 10
	And I set the pH option to: 10.5
	And I set the Boiling Point (in Celsius) option to: 120
	And I set the Flash Point (in Celsius) option to: 23
	And I set the Flash Point Testing Method Used option to: Closed cup method
	And I set the Select the best Water Solubility description option to: Insoluble
	And I click continue
	And I call Shared Step 74340 (Product Information - Pesticide= Not considered, SOLD=US, everything else = No - Continue)
	#And I call Shared Step 29181 (Ingredients - add any chemical) with name: Benzene
	Given I should see the Ingredients Page
	Then In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	| component name | Benzene       | 100     |                     |               |             |
	Then in the Ingredients page I click Continue

	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	And I should see the Transportation Details 1 Page
	And I set the Product is Regulated for Transport field to: Yes
	And I set the Select all modes of transport that you've classified the product for field to: DOT
	And I select option: Shipping fully regulated under section: Select all modes of transport that you've classified the product for and subsection: DOT
	And I click continue
	And I should see the U.S. Department of Transportation (DOT) Classification Page
	And I set the UN Number field to: UN2762
	And I set the Technical Name field to: Technical Name UN2762
	And I set the Packing Group (select) field to: II
	And I select the first option in section: Product has a boiling point of <=35⁰C  and flash point of >60⁰C. Packing Group selected is not consistent with this data.  Verify the data and transportation packing group.  If problem persists, please contact Support.
	And I click continue
	And I call Shared Step 77845 (Retailer - Select WM, Done, Select Vendor ID, Continue)
	Given I click the 'Add' button
	Then I generate a random UPC number and save as: RandomUPC91076
	Given I add the following into the UPC Fields
		| UPC Number              | Container Type    | Size | DPCI | Quantity |
		| saved as RandomUPC91076 | Plastic Container | 1    |      |          |
	Given I click continue
	#And I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
	Then in the Regulatory Documents to Provide page I click Continue

	And I should see the Additional Documents to Provide Page
	And I click continue
	And I should see the Optional Reports and Documents Available for Purchase Page
	And I click continue
	And I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
		| Gloves                        | 120                      | 4                       | 10.0      | Black      | Odorless | No data available | 1                     |
	#And I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Test Comment
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	And I call Shared Step 73956 (Go to Summary and verify data) with product type: Fertilizer
	#And I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given I should see the Data Acceptance Page
	Then In the Data Acceptance Section, check 'Agreed' checkbox
	Then In the Data Acceptance Section, click 'Accept' button

	And In the Purchase Summary screen I confirm the Purchase Summary header is displayed
	And In the Purchase Summary screen if Product Billing is displayed I click Confirm Order
	And I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase65947 and its status is: Submitted
	Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase65947)
	Then I call Shared Step 51349 - SHA Manager > Assigned Product - Add Recert reason 20 for product saved as: TestCase65947
	Given I navigate to the landing page
	And I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	And I filter for the product saved as: TestCase65947
	And I click Row Actions for the first product returned
	And I click on the Row Action: Update Required
	Given In the New Product page I click tab: Physical and Chemical Properties
	And I click the page heading: Transportation Details 1
	And I set the Select all modes of transport that you've classified the product for field to: DOT
	#First remove check form the full reg box
	And I unselect the option: Shipping fully regulated under section: Select all modes of transport that you've classified the product for and subsection: DOT
	And I select option: Shipping with limited quantity under section: Select all modes of transport that you've classified the product for and subsection: DOT
	And I click Save in The Product Page
	Then I Wait for a modal popup to appear
	Then I confirm the pop up shows the heading: UPC Transportation Warning
	Given in the modal dialog I click the "Ok" button
	Then I Wait for a modal popup to disappear
	Given In the New Product page I click tab: Review and Submit
	And I click the page heading: Data Acceptance
	#may need to update the below if inludes line breaks etc in the text
	Then Data Accpetance Screen shows error with message: Please fix all the errors in product data before you can continue with submission.
	And I click continue
	And I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page
	And I click continue
	#And I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given I should see the Data Acceptance Page
	Then In the Data Acceptance Section, check 'Agreed' checkbox
	Then In the Data Acceptance Section, click 'Accept' button

	And In the Purchase Summary screen I confirm the Purchase Summary header is displayed
	And In the Purchase Summary screen if Product Billing is displayed I click Confirm Order


	#clicking continue should cause popup to go to the upc screen?
	#Should get popup, then try to submit without going to the upc screen. That should fail, so then need to got to the upc screen then go back and try submit where it should now work. 


	Scenario: [ChromeWindowTest] Chrome Window Test
	Given I generate a random UPC number and save as: UPC86463

	Given I generate a random UPC number and save as: UPC864631	
	Given I navigate to the landing page


	Scenario: [cvs] CVSPharmTESTQS
	Given I log in with the account saved in TReVor as: NoProductsAccount
	Then In the Products Grid I delete All products
	Then For CVS I create a product of type: Pharmacy (RUCC0393), save it as: CVSPharmacyProduct1 and leave it in New Status
	Then I navigate to the CVS retailer Page then check that it contains the expected data tiers and that Products in Scope downloads a file, save it as: CVSPharmacyExcelFile and check that is shows the expected product saved as: CVSPharmacyProduct1


	Scenario: [DATATIERGETCHECK] Tier check test

	Given I log in with the account saved in TReVor as: NoProductsAccount
	Then In the Products Grid I delete All products
	Then For CVS I create a product of type: Health & Beauty (RUCC0392), save it as: CVSHBProduct1 and leave it in New Status
	Then I navigate to the CVS retailer Page then check that it contains the expected data tiers and that Products in Scope downloads a file, save it as: CVSHBExcelFile and check that is shows the expected product saved as: CVSHBProduct1

	Scenario: [KITPDFTEST] Debug scenario for kit pdf
	And I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Then I save the product ID: 1802471 to a context under type 'ProductInformation' as: TestCase73949
	Then I save the product ID: 1802381 to a context under type 'ProductInformation' as: TestCase73949PROD1
	Then I save the product ID: 1802431 to a context under type 'ProductInformation' as: TestCase73949PROD2
	And I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase73949)
	And In the SHA manager grid I see the WPS ID I have saved as product: TestCase73949 and its status is: Assigned
	And I call Shared Step 49743 - SHA Manager - Select Product - Actions - Document Management for saved as: TestCase73949
	And I Confirm you see the Document List pop up
	And In the Document List popup I Confirm the Filename column shows an entry for xxxxxxx.pdf - where xxxxxxx is the product id of product saved as: TestCase73949
	And In the Document List popup I Double click on the filename for product saved as: TestCase73949
	Then I confirm that a file is produced called GetDocument.pdf and save as savedas73949PDF
	#Then I should see a new tabbed document with the pdf containing product code saved as: TestCase73949 and NGHS / English twice
	#Then I should see a new tabbed document with the pdf containing product code saved as: TestCase73949 and NGHS / English twice for file: savedas73949PDF
	Then I Check that the file saved as: savedas73949PDF contains the text 'NGHS / English' twice as well as the product codes saved as: TestCase73949PROD1 and TestCase73949PROD2
	#Then I should see a new tabbed document whose URL contains DocumentID
	#Then I Delete the file with name: TempPDF.pdf from the downloads folde
	Then I delete the file saved as savedas73949PDF
	And I Click Cancel on the Document List window pop up

	Scenario: [KITPDFTESTFRANCIS] Debug scenario for kit Francis pdf
	And I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Then I save the product ID: 1802577 to a context under type 'ProductInformation' as: TestCase73949
	Then I save the product ID: 1802488 to a context under type 'ProductInformation' as: TestCase73949PROD1
	Then I save the product ID: 1802537 to a context under type 'ProductInformation' as: TestCase73949PROD2
	And I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase73949)
	And In the SHA manager grid I see the WPS ID I have saved as product: TestCase73949 and its status is: Assigned
	And I call Shared Step 49743 - SHA Manager - Select Product - Actions - Document Management for saved as: TestCase73949
	And I Confirm you see the Document List pop up
	And In the Document List popup I Confirm the Filename column shows an entry for xxxxxxx.pdf - where xxxxxxx is the product id of product saved as: TestCase73949
	And In the Document List popup I Double click on the filename for product saved as: TestCase73949
	Then I confirm that a file is produced called GetDocument.pdf and save as savedas73949PDF

	Then I Check that the file saved as: savedas73949PDF contains the product codes saved as: TestCase73949PROD1 and TestCase73949PROD2
	Then I Check that the file saved as: savedas73949PDF contains the text 'Canada / English' twice
	Then I Check that the file saved as: savedas73949PDF contains the text 'Canada / Français' twice

	Then I delete the file saved as savedas73949PDF
	And I Click Cancel on the Document List window pop up

	Scenario: [KITTESTENTRY] Kit Id select issue debug
	Given I log in with the account saved in TReVor as: ProductAccount
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration'
	Given in the New Product page I click Continue

	Then I save the product ID: 1827869 to a context under type 'ProductInformation' as: Kit1
	Then I save the product ID: 1827913 to a context under type 'ProductInformation' as: Kit2

	Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Hair Care kit
	Then I save the product information as: TestCase63521
	Given I call Shared Step 63460 (Product Information - SOLD = US, No(PL), No(GNFR) only shown (mainly kits) Happy Path)
	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	And I should see the Create the Kit Page
	Given In the Create the kit page I search for and select: saved as Kit1
	Given In the Create the kit page I search for and select: saved as Kit2
	Then in the Create the Kit page I click Continue
	And I should see the Transportation Details 1 Page


	Scenario: [UpdatePopupDebug] Update Popup Debug scenario

	
	Given I login into the WERCSmart Portal - Administrator Role
	Then I save the product ID: 1828816 to a context under type 'ProductInformation' as: TestCase84511
	
	Given I search for the product saved as: TestCase84511
	Given For product saved as: TestCase84511 the status is: Completed
	And I click Row Actions for the first product returned
	And I click on the Row Action: Update Data
	Then I wait for the Summary Screen to Load
	Then In the Summary screen, I click the Edit Product Button

	And I should see the Update Registration popup
	And In the Update Registration popup I click on button Continue	
	#And I If you are using a supplier registered for ULSC you will see the ULSC Service Data-Re-Import step, select the No, continue editing data radio button and click Save
	And I should see the The Product Page
	Then I click Save in The Product Page
	#Scenario: Test
	#Given I save to context name: TestCase84511 and value: 1524214
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase84511)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase84511 and its status is: Completed
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase84511 and its font is red indicating a recertification
	And I call Shared Step 51351 (SHA > Select Product > View Recertification History) for product saved as: TestCase84511
	And In the Product Recertification History popup I should see the following entry
		| Product ID             | Active | Recertification Reason                           |
		| saved as TestCase84511 | true   | Recertification of Product by WERCSmart Customer |
	And I Close the Product Recertification History pop up
	#Scenario: Test
	#Given I save to context name: TestCase84511 and value: 1524214
	Given I navigate to the landing page
	Given I login into the WERCSmart Portal - Administrator Role
	Given I search for the product saved as: TestCase84511
	Given For product saved as: TestCase84511 the status is: Needs Your Attention
	And I click Row Actions for the first product returned
	And I click on the Row Action: Update Required
	#And I If you are using a supplier registered for ULSC you will see the ULSC Service Data-Re-Import step, select the No, continue editing data radio button and click Save
	And I should see the The Product Page
	And In the New Product page I click tab: Physical and Chemical Properties
	And I click the page heading: Toxicity Characteristic Leaching Procedure (TCLP)
	And I set the Lead option to: Yes
	And I set the Mercury option to: Yes
	And I set the Silver option to: Yes
	Then I click Save in The Product Page
	And In the New Product page I click tab: Review and Submit
	And I click the page heading: Data Acceptance
	And In the Data Acceptance page I click on the Accept button
	Given If purchase details are showing click confirm order
	And I navigate to the home page
	And I search for the product saved as: TestCase84511
	Given For product saved as: TestCase84511 the status is: Assessment in Progress
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase84511)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase84511 and its status is: Recertification
	#And I Confirm your product is shown in the Recertification status without the red recertification font color
	And I call Shared Step 51351 (SHA > Select Product > View Recertification History) for product saved as: TestCase84511
	And In the Product Recertification History popup I should see the following entry
		| Product ID             | Active | Recertification Reason                           |
		| saved as TestCase84511 | false  | Recertification of Product by WERCSmart Customer |
	And I Close the Product Recertification History pop up




Scenario: [WEBRPS] Test 1
	
Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
Then Saving the product ID: 1836055 and Name: Carbon Monoxide Detectors Test Product to a context under type 'ProductInformation' as: TestCase146792
#Then I save the product ID: 1836055 to a context under type 'ProductInformation' as: TestCase146792
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Submitted Status for saved as: TestCase146792)

Given I call Shared Step 145300 (SHA - Submitted Status - Process BCP product - Close warning message) for product saved as: TestCase146792
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Submitted Status for saved as: TestCase146792)
# Confirm your product is still in the Submitted status
# So even though the product is in submitted status the import process rules will be running and the product will be shown in PD+ so we can process the publishing of the documents
Given I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase146792)
Given I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase146792)
Given I call Shared Step 75347 (WPS Studio - PD+ - set all data and publish using rule and Doc queue - CKLT, NGHS and SBCS) for product saved as: TestCase146792
Given I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase146792)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Submitted Status for saved as: TestCase146792)
# Confirm the product is still shown in SUBMITTED status - this is correct for this scenario - we will click process product data again now and the product will move to Assigned this time
Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase146792)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Assigned Status for saved as: TestCase146792)
# I confirm the product is shown in the Assigned status
# we now have to republish the product in WPS PD+ so that the product  moves out of assigned status
Given I call Shared Step 75347 (WPS Studio - PD+ - set all data and publish using rule and Doc queue - CKLT, NGHS and SBCS) for product saved as: TestCase146792
Given I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase146792)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Accepted Status for saved as: TestCase146792)
# Confirm the product is shown in Accepted status
Given I call Shared Step 49743 - SHA Manager - Select Product - Actions - Document Management for saved as: TestCase146792
# Confirm the Document list shows a type with the name set to published_by_wercs.rtf
# Click the "Merge Documents" button
# Confirm the Documents list is refreshed (may take a few seconds to do this)
# Confirm the Document list now shows a pdf type file with the name set to the WPS ID of your product For example 1617881.pdf
# Double click on the PDF Filename
# Confirm a new browser window opens with the PDF file shown
# Confirm the PDF file shows the SDS for your BCP product and the SDS for the Batteries you added to your BCP This will include Published NGHS for the BCP product AIS document for battery: Test Battery - TC 145403- Lithium Ion Battery with Uploaded AIS Uploaded SDS document for battery: Test Battery - For WVs TC 145485 - Lithium Ion Battery with Uploaded SDS Published NGHS for battery: Test Battery - TC 145354- Lithium Ion Battery with Authored SDS
# Close the new browser window
# Close the Document List pop up
Given I call Shared Step 51664 (SHA - Accepted Product - set Retailers to Completed for saved as: TestCase146792) for
| Retailer |
| <All>    |


#Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	#Then The home screen should load
	#Given I search for product by name: Kit Product 56829 and save the first grid item as: Kit_56829
	#And I create a Kit product and save details as: Kit_56829
	#And I navigate to the landing page
	#And I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	#And I should see an option for More Filters
	#Given I click More Filters in the products grid
	#Given I confirm the product exists with Product ID: Kit_56829_ID and Name: Kit Product 56829
	#Given I enter combinations of More Filters and should see the product ID: Kit_56829_ID only for the correct combinations
	#	| Filter              | Match               |
	#	| UPC                 | %Kit_56829_UPC%     |
	#	| Brand               | TestBrand           |
	#	| Retailer            | Wal-Mart/SAM'S CLUB |
	#	| Additional Programs | Kit Registrations   |
	#Given I enter combinations of Status and More Filters and should see the product ID: Kit_56829_ID only for the correct combinations
	#	| Filter              | Match                  |
	#	| Status              | Assessment in Progress |
	#	| Brand               | TestBrand              |
	#	| Retailer            | Wal-Mart/SAM'S CLUB    |
	#	| Additional Programs | Kit Registrations      |



	#Given I click More Filters in the products grid
	#Then the 'More Filters' options are not displayed
	#Given I click More Filters in the products grid
	#Then the 'More Filters' options are displayed
	#Given I click More Filters in the products grid
	#Then the 'More Filters' options are not displayed
