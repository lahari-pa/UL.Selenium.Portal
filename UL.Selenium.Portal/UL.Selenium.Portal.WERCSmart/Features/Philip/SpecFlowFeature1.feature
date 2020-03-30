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

Feature: ChooseGoodGuide.com Scenarios

Scenario:[120873] Product List - CW Column "Y" or "N"
And I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given Confirm that there is a CW column between Last Pub Date and GHS columns
	Then In SHA Manager Page I select status: Assigned
	Then Find product that has a Y in the CW column
	Then I call Shared Step 65969 (Go to Power Designer Plus - Select your product & CKLT - Continue)
	Then I click vendor section
	Then I click a section
	Then check text
	Then I call Shared Step 59066 (Go to SHA Manager)
	Then I click a section
	Then check text
	Then Find product that has a N in the CW column
	Then I call Shared Step 65969 (Go to Power Designer Plus - Select your product & CKLT - Continue)
	Then I click vendor section
	Then I click a section
	Then check text



Scenario: [123123123] Actions - 3rd Party Access Code Window

Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Then I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
And I call Shared Step 82831 (The Product - Enter Product Name and Select Type of Product: Raw material)
Then I save the product information as: TestCase90002
Then I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
| CASNumber | ComponentName   | Percent | PublicallyDisclosed | PublicName | TradeSecret |
|           | Sodium chloride | 33.33   | false               |            | false       |
|           | Copper sulfate  | 11.67   | false               |            | false       |
|           | Nitric acid     | 55      | false               |            | false       |
Then I call Shared Step 48948 (Formulation > 3rd Party - Select all)
Then I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
Then I call Shared Step 60932 (Regulatory Information 2 - Microbeads - No)
Then I click continue
Then I click continue
Then I click continue
And I call Shared Step 58610 (Confirm Restrict Use - Restrict)
Then I should see the Sustainability Page
Given in the Sustainability page I click Continue
Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: User added Comments Text 58605. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
Given I click the Home navigation icon
Given I search for the product saved as: TestCase90002
When I click Row Actions for the most recent product returned
Then I click on the Row Action: Access Code
Then Check popup date productID: TestCase90002 productType:Raw material productAccessCode: 1234
And I close the window that opened


Scenario: [127575] Battery Registration - Regulatory Documents - Needs "I don't Need" Option

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
Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Walgreens
Given I call Shared Step 60826 (Enter Universal Product Code (UPC) - Battery - Confirm Quantity ) for UPC saved as: UPC59273 with container type: Metal Container size: 40.0 and quantity: 100
Given I should see the Regulatory Documents to Provide Page
Then I check if AIS is not uploaded
Then I should not see radio option: I don't need a WHMIS Compliant SDS
Then I should not see radio option: I don't need an OSHA-Compliant Safety Data Sheet (SDS) document for this product
And I click the browse button for label: I have an Article Information Sheet (AIS), Technical Data Sheet (TDS), Battery Data Sheet (BDS) to provide. and upload PDF: C:\Dependencies\WERCSmart\testdoc.pdf
Then I should see radio option: I don't need an OSHA - Compliant Safety Data Sheet (SDS) Document for this product
Then I should see radio option: I don't need a WHMIS Compliant SDS


Scenario: [127767] Register a Cleaning Supplies - Sanitizer (Non Aerosol) Product Type for a verification of the Products in Scope Report for Bed Bath and Beyondd Bath and Beyond

Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561a (The Product - Enter Product Name: Cleaning Supplies Product for BBB and select Type of Product): Sanitizer (Non-Aerosol)
Given I call Shared Step 57441 (Product Characteristics - Primary Physical Property - Liquid)
And I set the Which one best describes your product field to: Product is not considered a pesticide product
Given I call Shared Step 105379 Additional Product Information - US, Pesticide No, No OSHA, No DSV, No PL, No GNFR Without Child question
Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
| CASNumber | ComponentName | Percent | PublicallyDisclosed | PublicName | TradeSecret |
| 64-17-5   | Ethyl Alcohol | 100     |                     |            |             |
Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
Given I call Shared Step 34455 (U. S. Department of Transportation (DOT) Classification - Enter all valid data): UN Unmber: UN1170, Proper Shipping Name: Ethanol Solutions, Technical Name: Ethanol Solutions, Hazard Class: 3, Packing Group: III
Given I call Shared Step 57923 (Volatile Organic Compound (VOC) Step - enter OTC and CARB - Yes for state values)
| Amount of VOC by CARB | Amount of VOC by OTC Model | Product granted Alternative Control Plan | VOC for states |
| 0.1                   | 0.1                        |                                          |                |
When I click continue
Given I call Shared Step 57712 - ECOLOGO Readiness Assessment - Not at this time - Continue - Happy Path
Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Bed Bath and Beyond
Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC804879551225, container type: Plastic Container and size: 3.5
Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
Given I call Shared Step 78801 (Additional Documents to Provide - VOC and Product Label)
When I click continue
Given I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
| Appearance | Autoignition Temperature | Minimum Ignition Energy | Odor    | Odor Threshold    | Partition Coefficient | Personal Protection Equipment | Viscosity |
| Opaque     | 0                        | 0                       | Alcohol | No Data Available | No Data Available     | Goggles                       |           |
Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: «comments»
Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
Given I call Shared Step 57206 (Go to Retail Partners - Select Bed Bath and Beyond)
Given I click the Products in Scope button and confirm that a file is produced called BB_Report_DataUsageTier_Current_Month_Day_Year (1).xlsx and save as Products in Scope Report for BBB
# Confirm that the PRODUCT NAME: 'Cleaning Supplies Product for BBB' is listed in the Report
Given I delete the excel file saved as Products in Scope Report for BBB


Scenario: [127895] SHA Manager: Supplier Records: Verification of Data Tier Consent

Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
Then I Click 'Suppliers'
Then Search for 'The WERCS LTD' Vendor
Then Select the 'The WERCS LTD' - Staging
Then Select the 'Data Tier Consent' Tab
Then Confirm that 'Dollar General' shows Tier 1,Tier 2.1,Tier 2.2 marked with a 'Y'
Then Confirm that 'Costco' shows Tier 1,Tier 2.1,Tier 2.2 marked with a 'Y'
Then Confirm that 'Canadian Tire' shows Tier 1,Tier 2.1,Tier 2.2 marked with a 'Y'
Then Confirm that 'CVS' shows Tier 1,Tier 2.1,Tier 2.2,Tier 3 marked with a 'Y'
Then Confirm that 'Rite Aid' shows Tier 1,Tier 2.1,Tier 2.2,Tier 3 marked with a 'Y'
Then Confirm that 'Target' shows Tier 1,Tier 2.1,Tier 2.2,Tier 3,Tier 4.1 marked with a 'Y'
Then Confirm that 'Walgreens' shows Tier 1,Tier 2.1,Tier 2.2 marked with a 'Y'
Then Confirm that 'Family Dollar' shows Tier 1 marked with a 'Y'
Then Confirm that 'Wal-Mart' shows Tier 1,Tier 2.1,Tier 2.2 marked with a 'Y'
Then Confirm that 'Amazon' shows Tier 1 marked with a 'Y'
Then Confirm that 'Dollar Tree Stores, Inc. / Greenbrier International, Inc' shows Tier 1,Tier 2.1,Tier 2.2 marked with a 'Y'
Then Confirm that 'Bed Bath and Beyond (including Harmon, Buy Buy Baby, and Christmas Tree Shops)' shows Tier 1,Tier 2.1,Tier 2.2,Tier 4.1 marked with a 'Y'
Then I Close 'Supplier Manager'



Scenario: [127901] SHA - Actions - Advanced Reporting - Daily Report - Data Tier Consent

Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
Given I select the: Daily Report - Data Tier Consent report from Advanced Reporting in SHA
Given In the Advanced Reporting popup I click Submit
Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
Then I select the: Daily Report - Data Tier Consent report from Advanced Reporting in SHA
Then In the Advanced Reporting popup I click Submit
And I wait for the Advanced Reporting Preparing Report popup to disappear
Given I confirm that an excel file is produced called Daily Report - Data Tier Consent.xls and save as 115163
And I confirm the excel file saved as 115163 can be opened and contains data
Then I confirm that the excel file saved as: 115163 contains the following columns:
		| Column |
		| Client |	
Then I confirm that the excel file saved as: 115163 contains the following columnss:
| Retailer            |
| Dollar General      |
| Costco              |
| Canadian Tire       |
| CVS                 |
| Rite Aid            |
| Bed Bath and Beyond (including Harmon, Buy Buy Baby, and Christmas Tree Shops) |
| Target              |
| Walgreens           |
| Family Dollar       |
| Walmart             |
| Amazon              |
| Dollar Tree         |
Given I delete the Advanced Report file saved as 115163
Given I Click close in the Advanced Reporting Popup




Scenario: [127903] Supplier Reports - Retailer Chemicals of Concern Report - Need to Include the Column for Bed Bath and Beyond


#Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
#Given I click the Supplier Reports icon in the QuickLinks Pane
#Given Under the Supplier Reports menu I choose: Retailer Chemicals of Concern
#Given In the Supplier Reports screen I click on the Download button
#Given I confirm an excel file is downloaded then close the Report Download popup. I save the file as excel72586
#Then I confirm that the exported excel file saved as: excel72586 contains the following columns:
#		| Column             |
#		| Bed, Bath & Beyond |

Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Given I click the Supplier Reports icon in the QuickLinks Pane
Given Under the Supplier Reports menu I choose: Retailer Chemicals of Concern
Given In the Supplier Reports screen I click on the Download button
Given I confirm that a file is downloaded with file name: Retailer Chemicals of Concern Microsoft Excel Worksheet then close the Report Download popup. I save the file as Retailer Chemicals of Concern


# Click on the Bottom Tab to open the Excel Retailer Chemicals of Concern Report
# Confirm the Excel Reports opens
# Confirm a NEW COLUMN HEADER has been added for BED BATH AND BEYOND
# Only Chemicals of Concern to BED BATH AND BEYOND will appear marked with an 'X'
