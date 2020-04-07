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

Feature: ChooseGoodGuide.com Scenarios

Scenario:[120873] Product List - CW Column "Y" or "N"
And I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given Confirm that there is a middle column called: CW between left column called: Last Pub Date and right column called: GHS
	Then In SHA Manager Page I select status: Assigned
	Then Find productID that has the letter: Y in the CW column and save it as: productID120873
	Then I open Power Designer Plus
	#Then I search for productID saved as : productID120873 in SHA
	#Then I click the refresh button in SHA
	Then I click the Vendor Report section
	Then I click section called: TXALL in the Vendor Report section
	Then I check that the following text: There is no (or limited) data available for any components and waste code has been assigned as a conservative approach due to lack of significant data showing non-hazardous should exist
	Then I call Shared Step 59066 (Go to SHA Manager)
	#Then In SHA Manager Page I select status: Assigned
	#Then Find product that has the letter: N in the CW column
	#Then In the Authoring menu I select Power Designer Plus
	#Then I click the Vendor Report section
	#Then I click section called: TXALL in the Vendor Report section
	#Then I check that the following text: There is no (or limited) data available for any components and waste code has been assigned as a conservative approach due to lack of significant data showing non-hazardous should not exist
	#

	Scenario: [127903] Supplier Reports - Retailer Chemicals of Concern Report - Need to Include the Column for Bed Bath and Beyond


Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Given I click the Supplier Reports icon in the QuickLinks Pane
Given Under the Supplier Reports menu I choose: Retailer Chemicals of Concern
Given In the Supplier Reports screen I click on the Download button
Given I confirm an excel file is downloaded then close the Report Download popup. I save the file as excel72586
Then I confirm that the exported excel file saved as: excel72586 contains the following columns:
		| Column             |
		| Bed, Bath & Beyond |

# Click on the Bottom Tab to open the Excel Retailer Chemicals of Concern Report
# Confirm the Excel Reports opens
# Confirm a NEW COLUMN HEADER has been added for BED BATH AND BEYOND
# Only Chemicals of Concern to BED BATH AND BEYOND will appear marked with an 'X'

Scenario: [127767] Register a Cleaning Supplies - Sanitizer (Non Aerosol) Product Type for a verification of the Products in Scope Report for Bed Bath and Beyondd Bath and Beyond

Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I generate a random UPC number and save as: UPC804879551225
Given I call Shared Step 57561a (The Product - Enter Product Name: Cleaning Supplies Product for BBB and select Type of Product): Sanitizer (Non-Aerosol)
Given I call Shared Step 57441 (Product Characteristics - Primary Physical Property - Liquid)
And I set the Which one best describes your product field to: Product is not considered a pesticide product
Given I call Shared Step 105379 Additional Product Information - US, Pesticide No, No OSHA, No DSV, No PL, No GNFR Without Child question
Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
| CASNumber | ComponentName | Percent | PublicallyDisclosed | PublicName | TradeSecret |
| 64-17-5   | Ethyl Alcohol | 100     |                     |            |             |
Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
Given I call Shared Step 34455 (U. S. Department of Transportation (DOT) Classification - Enter all valid data): UN Unmber: UN1791, Proper Shipping Name: Ethanol Solutions, Technical Name: Ethanol Solutions, Hazard Class: 3, Packing Group: III
And I set the Product has been granted an Alternative Control Plan option to: Yes
	Given I set the Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the CARB option to: 40
	Given I set the Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the OTC Model Rule option to: 5
	Given I set the Would you like to use the VOC percentages option to: Yes
When I click continue
When I click continue
Given I call Shared Step 57712 - ECOLOGO Readiness Assessment - Not at this time - Continue - Happy Path
Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Bed Bath and Beyond (including Harmon, Buy Buy Baby, and Christmas Tree Shops)
Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC804879551225, container type: Plastic Container and size: 3.5
Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
Given I call Shared Step 59042 (Browse for File > select > click Open - Happy Path) for document type: VOC Exemption Letter and file: C:\Dependencies\WERCSmart\testdoc.pdf
Given I call Shared Step 78801 (Additional Documents to Provide - VOC and Product Label)
When I click continue
When I click continue
Given I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
| Appearance | Autoignition Temperature | Minimum Ignition Energy | Odor    | Odor Threshold    | Partition Coefficient | Personal Protection Equipment | Viscosity |
| Opaque     | 0                        | 0                       | Alcohol | No data available | No Data Available     | Goggles                       |           |
Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: «comments»
Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
Given I call Shared Step 57206 (Go to Retail Partners - Select Bed Bath and Beyond)
Given I click the Products in Scope button and confirm that a file is produced called BB_Report_DataUsageTier_4_1_2020.xlsx and save as Products in Scope Report for BBB
Then I confirm that the excel file saved as: Products in Scope Report for BBB contains the following product name: 'Cleaning Supplies Product for BBB'
Given I delete the excel file saved as Products in Scope Report for BBB


Scenario: [127870] Pharma - Tablet or Capsule Count Field is Available for Solid - Solid Gel Consistency

Given I attempt to log in with email: wercsmartsub1@sharklasers.com and password: Thewercs1!
Given I click the Prescription Pharmaceutical icon in the QuickLinks Pane
Given I generate a random UPC number and save as: UPC127870
Given I click continue
Given I call Shared Step 57500a (Prescription Pharmaceutical - The Product- Enter name, select product type - Continue - Happy Path): prescription pharmaceutical, solid
Given I enter the NDC number: 10866-0885-2
Then I save the product information as: TestCase127870
Then I click continue
Given I fill all empty fields in the SPL Information screen
Then I click continue
	And I set the Secondary Physical State to be: Solid
	And I set the When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5? option to: No
	And I set the Select the best Water Solubility description to be: Very soluble
	And in the New Product page I click Continue
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
	Given I set the Should this product be refrigerated for transport or storage? option to: No
	Then I click continue
	Given I set the Is the product regulated for transport (before exceptions or exemptions) option to: No, not regulated
	Then I click continue
	Given in the Select Retailers tab under Forward Product Registration I select the retailer: Wal-Mart/SAM'S CLUB
	Given In the Retailers tab, I select the first Vendor option for retailer: Wal-Mart/SAM'S CLUB
	Then I click continue
	Then I call Shared Step 57961 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC127870, container type: Plastic Container, capsule count: 50  and size: 1
    Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase127870


Scenario: [127970] Pharma - Regulatory Documents to Provide and Additional Documents to Provide 
 Given I attempt to log in with email: wercsmartsub1@sharklasers.com and password: Thewercs1!
Given I click the Prescription Pharmaceutical icon in the QuickLinks Pane
Given I click continue
Given I call Shared Step 57500a (Prescription Pharmaceutical - The Product- Enter name, select product type - Continue - Happy Path): prescription pharmaceutical, solid
Given I enter the NDC number: 0360-0089-01
Then I save the product information as: TestCase127870
Then I click continue
Given I fill all empty fields in the SPL Information screen
Then I click continue
	And I set the Secondary Physical State to be: Solid
	And I set the When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5? option to: No
	And I set the Select the best Water Solubility description to be: Very soluble
	And in the New Product page I click Continue
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
	Given I set the Should this product be refrigerated for transport or storage? option to: No
	Then I click continue
	Given I set the Is the product regulated for transport (before exceptions or exemptions) option to: No, not regulated
	Then I click continue
	Given in the Select Retailers tab under Forward Product Registration I select the retailer: Wal-Mart/SAM'S CLUB
	Given In the Retailers tab, I select the first Vendor option for retailer: Wal-Mart/SAM'S CLUB
	Then I click continue
	Then I call Shared Step 57961 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC127870, container type: Plastic Container, capsule count: 50 and size: 1
Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
When I click continue
Then Volatile Organic Compounds should be showing the error messages: Document is required: Product Label
Given I call Shared Step 59042 (Browse for File > select > click Open - Happy Path) for document type: VOC Exemption Letter and file: C:\Dependencies\WERCSmart\testdoc.pdf
Given I call Shared Step 78801 (Additional Documents to Provide - VOC and Product Label)
When I click continue
When I click continue

Given I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
| Appearance | Autoignition Temperature | Minimum Ignition Energy | Odor    | Odor Threshold    | Partition Coefficient | Personal Protection Equipment | Viscosity |
| Opaque     | 0                        | 0                       | Alcohol | No data available | No Data Available     | Goggles                       |           |
Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: «comments»
Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
And In the Purchase Summary screen I confirm the Purchase Summary header is displayed
Then In the Thank You screen I confirm the following statement is shown: Thank you for registering your product on WERCSmart for assessment. The retailers may receive your assessment in approximately two (2) business days, if no delays in processing the assessment, and should no data issues arise.
And I navigate to the home page

# Click on Prescription Pharmaceutical icon
# New Product screen: click Continue
Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): prescription pharmaceutical, solid
# In Product Information screen, copy and paste 0360-0089-01 and select it from the list, click Continue
# In SPL Information screen - Confirm the fields are automatically populated, if a field is not populate (for example the Distributor field, fill it in) - click continue
# In Product Characteristics for secondary state drop down select- solid
# For question: "When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?" select No
# Select the best Water Solubility description from the drop down
# Click Continue
# The Ingredients get populated automatically, fill in the percentages for each ingredient - click Continue
# Select No for question: "Should this product be refrigerated for transport or storage?"
# For question: "Is the product regulated for transport (before exceptions or exemptions)" select No, not regulated
# Click Continue
# In Retailer Association section select a Vendor from the drop down for  Wal-Mart/SAM'S CLUB
# Click Continue
# In the Universal Product Code (UPC) section click +Add UPC button
# In the Shared step below type in a number for the tablet or capsule count field
Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC«upc», container type: Plastic Container and size: 1
# Click Continue in the Regulatory Documents to Provide
# Confirm an error message shows: "Document is required: Product Label"
# Click Browse for the upload a "Product Label" file
# Find and select a PDF type document, click open; file uploads
# Click Continue; Additional Documents to Provide section shows
# Confirm that the option was renamed: "Safety Data Sheet (Optional)"
# Confirm that "Safety Data Sheet" is the only available option in Additional Documents to Provide
# Click Continue, Data Acceptance sections appears
Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
# Purchase Summary page is shown with the following message: "Thank you for registering your product on WERCSmart for assessment. The retailers may receive your assessment in approximately two (2) business days, if no delays in processing the assessment, and should no data issues arise."
# Click Home button

Scenario: [128018] Pharma - Forwarding Not Allowed

Given I attempt to log in with email: wercsmartsub1@sharklasers.com and password: Thewercs1!
# Click on Prescription Pharmaceutical icon
# New Product screen: click Continue
Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): prescription pharmaceutical, solid
# In Product Information screen, copy and paste 0360-0089-01 and select it from the list, click Continue
# In SPL Information screen - Confirm the fields are automatically populated, if a field is not populate (for example the Distributor field, fill it in) - click continue
# In Product Characteristics for secondary state drop down select- solid
# For question: "When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?" select No
# Select the best Water Solubility description from the drop down
# Click Continue# The Ingredients get populated automatically, fill in the percentages for each ingredient - click Continue
# Select No for question: "Should this product be refrigerated for transport or storage?"
# For question: "Is the product regulated for transport (before exceptions or exemptions)" select No, not regulated
# Click Continue# In Retailer Association section select a Vendor from the drop down for  Wal-Mart/SAM'S CLUB
# Click Continue# In the Universal Product Code (UPC) section click +Add UPC button# In the Shared step below type in a number for the tablet or capsule count field
Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC«upc», container type: Plastic Container and size: 1
# Click Continue in the Regulatory Documents to Provide
# Confirm an error message shows: "Document is required: Product Label"
# Click Browse for the upload a "Product Label" file
# Find and select a PDF type document, click open; file uploads
# Click Continue; Additional Documents to Provide section shows
# Confirm that the option was renamed: "Safety Data Sheet (Optional)"
# Confirm that "Safety Data Sheet" is the only available option in Additional Documents to Provide# Click Continue, Data Acceptance sections appears
# Take note of the Product ID
Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
# Purchase Summary page is shown with the following message: "Thank you for registering your product on WERCSmart for assessment. The retailers may receive your assessment in approximately two (2) business days, if no delays in processing the assessment, and should no data issues arise."
# Click Home buttonGiven I call Shared Step 75130 - Bulk Actions - Select Forward Product Registration
# In the Select Products & UPCs screen, type in the product ID you took note of earlier
# Confirm that the product does not appear available for selection
# Click Home icon, click Leave
