@PaymentMethods
@Shared
@Login
@Homepage
@ProductGrid
@ForwardProductRegistration
@NewProduct
@RetailPartners
@Pharma

Feature: Pharma


#MUST EDIT EXCEL FILE NAME, NAME IS BASED ON CURRENT DATE. SCROLL DOWN FOR INSTRUCTIONS
Scenario: [127767] Register a Cleaning Supplies - Sanitizer (Non Aerosol) Product Type for a verification of the Products in Scope Report for Bed Bath and Beyondd Bath and Beyond

Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I generate a random UPC number and save as: UPC127767
Given I call Shared Step 57561a (The Product - Enter Product Name: Cleaning Supplies Product for BBB and select Type of Product): Sanitizer (Non-Aerosol)
Given I call Shared Step 57441 (Product Characteristics - Primary Physical Property - Liquid)
And I set the Which one best describes your product field to: Product is not considered a pesticide product
Given I call Shared Step 105379 Additional Product Information - US, Pesticide No, No OSHA, No DSV, No PL, No GNFR Without Child question
Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Ethyl Alcohol | 100     | false               | false       |            |
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
Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC127767, container type: Plastic Container and size: 3.5
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
#Replace file name with BB_Report_DataUsageTier_CurrentMonth_CurrentDay_CurrentYear.xlsx
Given I click the Products in Scope button and confirm that a file is produced called BB_Report_DataUsageTier_4_20_2020.xlsx and save as Products in Scope Report for BBB
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
Given I generate a random UPC number and save as: UPC127970
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
Then I call Shared Step 57961 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC127970, container type: Plastic Container, capsule count: 50 and size: 1
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









Scenario: [128018] Pharma - Forwarding Not Allowed
Given I attempt to log in with email: wercsmartsub1@sharklasers.com and password: Thewercs1!
Given I click the Prescription Pharmaceutical icon in the QuickLinks Pane
Given I generate a random UPC number and save as: UPC128018
Given I click continue
Given I call Shared Step 57500a (Prescription Pharmaceutical - The Product- Enter name, select product type - Continue - Happy Path): prescription pharmaceutical, solid
Given I enter the NDC number: 10866-0885-2
Then I save the product information as: TestCase128018
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
Then I call Shared Step 57961 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC128018, container type: Plastic Container, capsule count: 50 and size: 1
When I click continue
When I click continue
Then Upload Full Product Label (required) (For private label products please upload a generic label that is not retailer-specific.) should be showing the error messages: Document is required: Product Label
And I call Shared Step 60567 (Upload Product Label only) for section: Upload Full Product Label (required)
Then I check for the following options in the Additonal Documents to Provide section
| Option                       |
| Safety Data Sheet (Optional) |
When I click continue
Given I call Shared Step 59042 (Browse for File > select > click Open - Happy Path) for document type: Upload Full Product Label (required) (For private label products please upload a generic label that is not retailer-specific.) and file: C:\Dependencies\WERCSmart\testdoc.pdf
When I click continue
When I click continue
Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
And In the Purchase Summary screen I confirm the Purchase Summary header is displayed
Then In the Thank You screen I confirm the following statement is shown: Thank you for registering your product on WERCSmart for assessment. The retailers may receive your assessment in approximately two (2) business days, if no delays in processing the assessment, and should no data issues arise.
And I navigate to the home page
Given I call Shared Step 75130 - Bulk Actions - Select Forward Product Registration
And I enter the text: saved as TestCase128018 in the 'Search by WPS ID or Product Name' field
And In the Foward Product Registration Screen I should not see product: saved as TestCase128018
And I navigate to the home page








Scenario: [127847] Pharma - Tablet or Capsule Count Field is Available for Solid - Solid
Given I attempt to log in with email: wercsmartsub1@sharklasers.com and password: Thewercs1!
Given I click the Prescription Pharmaceutical icon in the QuickLinks Pane
Given I generate a random UPC number and save as: UPC127847
Given I click continue
Given I call Shared Step 57500a (Prescription Pharmaceutical - The Product- Enter name, select product type - Continue - Happy Path): prescription pharmaceutical, solid
Given I enter the NDC number: 10866-0885-2
Then I save the product information as: TestCase127847
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
Then I call Shared Step 57961 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC127847, container type: Plastic Container, capsule count: 50 and size: 1
When I click continue
When I click continue
Then Upload Full Product Label (required) (For private label products please upload a generic label that is not retailer-specific.) should be showing the error messages: Document is required: Product Label
And I call Shared Step 60567 (Upload Product Label only) for section: Upload Full Product Label (required)
Then I check for the following options in the Additonal Documents to Provide section
| Option                       |
| Safety Data Sheet (Optional) |
When I click continue
Given I call Shared Step 59042 (Browse for File > select > click Open - Happy Path) for document type: Upload Full Product Label (required) (For private label products please upload a generic label that is not retailer-specific.) and file: C:\Dependencies\WERCSmart\testdoc.pdf
When I click continue
When I click continue
Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
And In the Purchase Summary screen I confirm the Purchase Summary header is displayed
Then In the Thank You screen I confirm the following statement is shown: Thank you for registering your product on WERCSmart for assessment. The retailers may receive your assessment in approximately two (2) business days, if no delays in processing the assessment, and should no data issues arise.
And I navigate to the home page
Given I call Shared Step 75130 - Bulk Actions - Select Forward Product Registration
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase127847








Scenario: [127854] Pharma - Tablet or Capsule Count Field is Available for Solid - Solid Containing Liquid
Given I attempt to log in with email: wercsmartsub1@sharklasers.com and password: Thewercs1!
Given I click the Prescription Pharmaceutical icon in the QuickLinks Pane
Given I generate a random UPC number and save as: UPC127854
Given I click continue
Given I call Shared Step 57500a (Prescription Pharmaceutical - The Product- Enter name, select product type - Continue - Happy Path): prescription pharmaceutical, solid
Given I enter the NDC number: 10866-0885-2
Then I save the product information as: TestCase127854
Then I click continue
Given I fill all empty fields in the SPL Information screen
Then I click continue
And I set the Secondary Physical State to be: Solid containing liquid
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
Then I call Shared Step 57961 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC127854, container type: Plastic Container, capsule count: 50 and size: 1
When I click continue
When I click continue
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase127854








Scenario: [127791] Pharma - Retailer Default
Given I attempt to log in with email: wercsmartsub1@sharklasers.com and password: Thewercs1!
Given I click the Prescription Pharmaceutical icon in the QuickLinks Pane
Given I generate a random UPC number and save as: UPC127791
Given I click continue
Given I call Shared Step 57500a (Prescription Pharmaceutical - The Product- Enter name, select product type - Continue - Happy Path): prescription pharmaceutical, solid
Given I enter the NDC number: 10866-0885-2
Then I save the product information as: TestCase127791
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
And The selected retailers on the Retailer page should be:
		| Retailer                   |
		| No Retailer/No UPC Product |
		| Wal-Mart/SAM'S CLUB        | 
Given In the Retailers tab, I select the first Vendor option for retailer: Wal-Mart/SAM'S CLUB
Then I click continue
Given I click the 'Add UPC' button
And I confirm that retailer "WM" is present under the 'Destination Retailers' column in the UPC table
Then I call Shared Step 57961 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC127791, container type: Plastic Container, capsule count: 50 and size: 1
When I click continue
When I click continue
Then Upload Full Product Label (required) (For private label products please upload a generic label that is not retailer-specific.) should be showing the error messages: Document is required: Product Label
And I call Shared Step 60567 (Upload Product Label only) for section: Upload Full Product Label (required)
Then I check for the following options in the Additonal Documents to Provide section
| Option                       |
| Safety Data Sheet (Optional) |
When I click continue
Given I call Shared Step 59042 (Browse for File > select > click Open - Happy Path) for document type: Upload Full Product Label (required) (For private label products please upload a generic label that is not retailer-specific.) and file: C:\Dependencies\WERCSmart\testdoc.pdf
When I click continue
When I click continue
Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
And In the Purchase Summary screen I confirm the Purchase Summary header is displayed
Then In the Thank You screen I confirm the following statement is shown: Thank you for registering your product on WERCSmart for assessment. The retailers may receive your assessment in approximately two (2) business days, if no delays in processing the assessment, and should no data issues arise.
And I navigate to the home page
Given I call Shared Step 75130 - Bulk Actions - Select Forward Product Registration
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase127791





Scenario: [128671] Pharma - Prescription Pharmaceutical - Liquid Core Product

Given I attempt to log in with email: wercsmartsub1@sharklasers.com and password: Thewercs1!
Given I click the Prescription Pharmaceutical icon in the QuickLinks Pane
Given I generate a random UPC number and save as: UPC127847
Given I click continue
Given I call Shared Step 57500a (Prescription Pharmaceutical - The Product- Enter name, select product type - Continue - Happy Path): Prescription Pharmaceutical with Liquid Core
Given I enter the NDC number: 10866-0885-2
Then I save the product information as: TestCase127847
Then I click continue
Given I fill all empty fields in the SPL Information screen
Then I click continue
Given I call Shared Step 32931 (Liquid Core Product - select  No - Happy Path)
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
Then I call Shared Step 57961 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC127847, container type: Plastic Container, capsule count: 50 and size: 1
When I click continue
When I click continue
Then Upload Full Product Label (required) (For private label products please upload a generic label that is not retailer-specific.) should be showing the error messages: Document is required: Product Label
And I call Shared Step 60567 (Upload Product Label only) for section: Upload Full Product Label (required)
Then I check for the following options in the Additonal Documents to Provide section
| Option                       |
| Safety Data Sheet (Optional) |
When I click continue
Given I call Shared Step 59042 (Browse for File > select > click Open - Happy Path) for document type: Upload Full Product Label (required) (For private label products please upload a generic label that is not retailer-specific.) and file: C:\Dependencies\WERCSmart\testdoc.pdf
When I click continue
Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
Then In the Thank You screen I confirm the following statement is shown: Thank you for registering your product on WERCSmart for assessment. The retailers may receive your assessment in approximately two (2) business days, if no delays in processing the assessment, and should no data issues arise.
And I navigate to the home page





Scenario: [128677] Pharma - Prescription Pharmaceutical - Liquid Product

Given I attempt to log in with email: wercsmartsub1@sharklasers.com and password: Thewercs1!
Given I click the Prescription Pharmaceutical icon in the QuickLinks Pane
Given I generate a random UPC number and save as: UPC128677
Given I click continue
Given I call Shared Step 57500a (Prescription Pharmaceutical - The Product- Enter name, select product type - Continue - Happy Path): prescription pharmaceutical, solid
Given I enter the NDC number: 10866-0885-2
Then I save the product information as: TestCase128677
Then I click continue
Given I fill all empty fields in the SPL Information screen
Then I click continue
And I set the Secondary Physical State to be: Solid
And I set the When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5? option to: No
And I set the Select the best Water Solubility description to be: Very soluble
Given I call Shared Step 74760 (Product Characteristics - Select Liquid as primary physical state and enter all required data)
| Primary Physical State | Secondary Physical State | Specific Gravity | pH | Boiling Point (in Celsius) | Flash Point (in Celsius) | Flash Point Testing Method Used | Select the best Water Solubility description |
|  Liquid                | Liquid                   | 2                | 2  | 2                          | 66                       |  Closed cup method              | Appreciable                                  |
And in the New Product page I click Continue
Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
	| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
	| Propane       | 100     | false               | false       |            |
Given I set the Should this product be refrigerated for transport or storage? option to: No
Then I click continue
Given I set the Is the product regulated for transport (before exceptions or exemptions) option to: Yes, Agree
Given I call Shared Step 65698 (Transport - Select DOT & Limited Shipping - No Continue)
Then I click continue
Given I call Shared Step 81310 (UN Number - enter UN1950 select Aerosol & Haz class, confirm Packing group - Continue) 
Given in the Select Retailers tab under Forward Product Registration I select the retailer: Wal-Mart/SAM'S CLUB
Given In the Retailers tab, I select the first Vendor option for retailer: Wal-Mart/SAM'S CLUB
Then I click continue
Then I call Shared Step 57961 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC128677, container type: Plastic Container, capsule count: 50 and size: 1
When I click continue
When I click continue
Then Upload Full Product Label (required) (For private label products please upload a generic label that is not retailer-specific.) should be showing the error messages: Document is required: Product Label
And I call Shared Step 60567 (Upload Product Label only) for section: Upload Full Product Label (required)
When I click continue
Given I call Shared Step 59042 (Browse for File > select > click Open - Happy Path) for document type: Upload Full Product Label (required) (For private label products please upload a generic label that is not retailer-specific.) and file: C:\Dependencies\WERCSmart\testdoc.pdf
When I click continue
Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
Then In the Thank You screen I confirm the following statement is shown: Thank you for registering your product on WERCSmart for assessment. The retailers may receive your assessment in approximately two (2) business days, if no delays in processing the assessment, and should no data issues arise.
And I navigate to the home page

