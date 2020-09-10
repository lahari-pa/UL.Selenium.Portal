@Shared
@LandingPage
@Login
@Homepage
@ForgottenPassword
@SupplierReports
@RetailPartners
@wercsmart
@Signup
@ProductGrid
@run_SupplierReports
@ViewUpcs
@DataSummarySheet
@SHA
@MyAccount
@NewProduct
@ProductSetUp
@UPC
Feature: Supplier Reports

@ScenarioId:978
Scenario: [68420] List of Supplier Reports
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I click the My Reports icon in the QuickLinks Pane
	And In the Supplier Reports screen the page title should be: Available Reports
	Given under the supplier Reports menu I should see the following options
		| Reports                                |
		| Battery-Containing Products            |
		| California Proposition 65              |
		| Chemicals of Concern                   |
		| Eligible to Obsolete                   |
		| Kit Registrations                      |
		| Kits Containing a Registration         |
		| Pesticide Registrations                |
		| Product Types Registered               |
		| Registration Updates Not Submitted     |
		| Subscription Product Types             |
		| UPC and Retailer (All)                 |
		| UPC and Retailer (Single Registration) |
		| UPC Duplication                        |
		| UPC Errors for The Home Depot          |
		| Volatile Organic Compounds             |
		| Waste Classification Summary           |
		#| Kit Registration Details                                           |
		#| Kits Containing a Specific Registration                            |
		#| Pesticide Certificate Report                                       |
		#| Pesticide Report                                                   |
		#| Product Types Registered                                           |
		#| Registrations Revised - Not Yet Submitted                          |
		#| Registrations with Retailer Chemicals of Concern                   |
		#| Retailer Chemicals of Concern                                      |
		#| Subscription Renewal (Formulated, Enhanced, Articles)              |
		#| Subscription Renewal (Registrations Eligible for Deletion)         |
		#| Sustainability Survey Eligibility - Health & Beauty                |
		#| UPC and Retailer (Product Specific)                                |
		#| UPC Error Details                                                  |
		#| UPCs (Active) for all Registrations                                |
		#| UPCs and Registrations (Retailer Specific)                         |
		#| UPCs Duplicated within Account                                     |
		#| VOC-related Registrations                                          |
		#| Waste Classification Summary for All Registrations                 |

@tfs_design
@Obsolete
@ScenarioId:979
Scenario: [68421] Active UPCs for Products Report
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I click the My Reports icon in the QuickLinks Pane
	And In the Supplier Reports screen the page title should be: Available Reports
	Given Under the Supplier Reports menu I choose: UPCs (Active) for all Registrations
	Then In the Supplier Reports screen the current sub-page should be: UPCs (Active) for all Registrations
	Given In the Supplier Reports screen I click on the Download button
	Given I confirm that an excel file is produced called UPCs (Active) for all Registrations.xlsx and save as 68421
	Then I confirm that the excel file saved as: 68421 contains the following columns:
		| Column          |
		| WPSID           |
		| Product Name    |
		| Brand           |
		| Recommended Use |
		| Individual UPC  |
		| Case UPC        |
	Given I click on close in the Report Download dialog
	#data validation
	Then I save the first product in the excel spreadsheet saved as: 68421 as TestCase68421
	Then I save the value with the header Individual UPC on the first product in the excel spreadsheet saved as: 68421 as TestCase68421UPCs
	Then I save the value with the header Case UPC on the first product in the excel spreadsheet saved as: 68421 as TestCase68421CaseUPCs
	Given I navigate to the home page
	Given I search for the product saved as: TestCase68421
	And I confirm that the product returned has the same name as the product saved as: TestCase68421
	Given I click Row Actions for the first product returned
	And I click on the Row Action: View UPCs
	And I switch to the tab with title: View UPCs
	And I confirm that the number of normal UPCs equals the number saved as: TestCase68421UPCs
	And I confirm that the number of Case UPCs equal the number saved as: TestCase68421CaseUPCs
	And I delete the Supplier Report file saved as 68421

@ScenarioId:980
Scenario: [68422] Battery-containing products report
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I click the My Reports icon in the QuickLinks Pane
	Given Under the Supplier Reports menu I choose: Battery-Containing Products
	Then In the Supplier Reports screen the current sub-page should be: Battery-Containing Products
	Then In the Supplier Reports screen the current page description should be: For Battery-containing product registrations, the report includes details on the battery selected within the registration, including manufacturer of the battery.
	Then I Delete the file with name: BatteryContaining Products.xlsx from the downloads folder
	Then I Delete the file with name: Battery-Containing Products.xlsx from the downloads folder
	Given In the Supplier Reports screen I click on the Download button	
	Given I confirm that an excel file is produced called BatteryContaining Products.xlsx and save as 68422
	Then I confirm that the excel file saved as: 68422 contains the following columns:
		| Column        |
		| Supplier Name |
		| WPSID         |
		| Product Name  |
		| Battery Type  |
		| Battery Mfg   |
	Given I click on close in the Report Download dialog
	And I delete the Supplier Report file saved as 68422
	Then I confirm that the latest report in the Report history table matches the following data:
	| Column         | Value                       |
	| Report Name    | Battery-Containing Products |
	| File Type      | XLSX                        |
	| Date Requested | <TodaysDate>                |
	| Requested By   | <CurrentUser>               |
	And I confirm that the latest report in the Report history table has a: Download button in the Actions Column
	Then I click the: Download button for the latest report in the Report history table
	Given I confirm that an excel file is produced called Battery-Containing Products.xlsx and save as 68422b
	And I confirm the excel file saved as 68422b can be opened and contains data
	Then I confirm that the excel file saved as: 68422b contains the following columns:
		| Column        |
		| Supplier Name |
		| WPSID         |
		| Product Name  |
		| Battery Type  |
		| Battery Mfg   |
	And I delete the Supplier Report file saved as 68422b
	Given I click on close in the Report Download dialog
	#Confirm latest report has download button in actions row
	#Then I save the value with the header WPSID on the first product in the excel spreadsheet saved as: 68422 as TestCase68422Id
	#Then I save the value with the header Product Name on the first product in the excel spreadsheet saved as: 68422 as TestCase68422Name
	#Given I save the product with name: TestCase68422Name and id: TestCase68422Id as: TestCase68422
	#Given I navigate to the home page
	#Given I search for the product saved as: TestCase68422
	#And I confirm that the product returned has the same name as the product saved as: TestCase68422
	#And I delete the Supplier Report file saved as 68422

@ScenarioId:981
Scenario: [68423] Formulated vs Articles Report
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I click the My Reports icon in the QuickLinks Pane
	Given Under the Supplier Reports menu I choose: Subscription Product Types
	Then In the Supplier Reports screen the current sub-page should be: Subscription Product Types
	Given In the Supplier Reports screen I click on the Download button
	Given I click on close in the Report Download dialog
	Given I confirm that an excel file is produced called Subscription Product Types.xlsx and save as 68423
	Then I confirm that the excel file saved as: 68423 contains the following columns:
		| Column              |
		| WPSID               |
		| Product Name        |
		| Formulated          |
		| Articles            |
		| Enhanced Articles   |
		| 3rd Party Formula   |
		| ULGHS Document Only |
	#data validation
	Then I save the value with the header WPSID on the first product in the excel spreadsheet saved as: 68423 as TestCase68423Id
	Then I save the value with the header Product Name on the first product in the excel spreadsheet saved as: 68423 as TestCase68423Name
	Given I save the product with name: TestCase68423Name and id: TestCase68423Id as: TestCase68423
	Given I navigate to the home page
	Given I search for the product saved as: TestCase68423
	And I confirm that the product returned has the same name as the product saved as: TestCase68423
	And I delete the Supplier Report file saved as 68423

@ScenarioId:982
Scenario: [73082] UPC Report for All Products with Retailer
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I click the My Reports icon in the QuickLinks Pane
	Given Under the Supplier Reports menu I choose: UPCs and Registrations (Retailer Specific)
	Then In the Supplier Reports screen the current sub-page should be: UPCs and Registrations (Retailer Specific)
	Given In the Supplier Reports screen I click on the Download button
	Given I click on close in the Report Download dialog
	Given I confirm that an excel file is produced called UPCs and Registrations (Retailer Specific).xlsx and save as 73082
	Then I confirm that the excel file saved as: 73082 contains the following columns:
		| Column                    |
		| WERCSmart ID              |
		| Product Name              |
		| Brand                     |
		| UPC                       |
		| UPC Name                  |
		| Retailer                  |
		| Status                    |
		| Ounces                    |
		| Unique Product Identifier |
		| Container Type            |
		| Package Type              |
		| Net Explosive Mass        |
		| Case Pack                 |
		| Case Pack Individual UPC  |
		| Private Label             |
		| Direct Ship Vendor        |
		| Goods Not For Resale      |
		| Registration Type         |
		| Subscription Type         |
	#data validation
	Then I confirm that the excel file saved as: 73082 in column: Container Type there are no numbers
	Then I save the value with the header WERCSmart ID on the first product in the excel spreadsheet saved as: 73082 as TestCase73082Id
	Then I save the value with the header Product Name on the first product in the excel spreadsheet saved as: 73082 as TestCase73082Name
	Given I save the product with name: TestCase73082Name and id: TestCase73082Id as: TestCase73082
	Then I save the value with the header UPC on the first product in the excel spreadsheet saved as: 73082 as TestCase73082UPC
	Then I save the value with the header Private Label on the first product in the excel spreadsheet saved as: 73082 as TestCase73082PrivateLabel
	Then I save the value with the header Retailer on the first product in the excel spreadsheet saved as: 73082 as TestCase73082Retailer
	Then I save the value with the header Ounces on the first product in the excel spreadsheet saved as: 73082 as TestCase73082Ounces
	Then I save the value with the header Container Type on the first product in the excel spreadsheet saved as: 73082 as TestCase73082Container
	Then I save the value with the header Status on the first product in the excel spreadsheet saved as: 73082 as TestCase73082Status
	Given I navigate to the home page
	Given I search for the product saved as: TestCase73082
	And I confirm that the product returned has the same name as the product saved as: TestCase73082
	Then If the product is Private Label, I ensure that product saved as: TestCase73082 shows as Private Label: TestCase73082PrivateLabel
	Given I click Row Actions for the first product returned
	And I click on the Row Action: View UPCs
	And I switch to the tab with title: View UPCs
	And I confirm that UPC: TestCase73082UPC shows in the list of UPCs
	And I close the window that opened
	And I confirm that the retailer listed for product saved as: TestCase73082 appears as: TestCase73082Retailer
	Given I click Row Actions for the first product returned
	And I click on the Row Action: View
	Then I switch to the Data Summary page
	Then I confirm that the Data Summary section Provide the product's UPC(s), including container type and size (ounces) shows the value for Container Type saved as: TestCase73082Container for UPC saved as: TestCase73082UPC
	Then I confirm that the Data Summary section Provide the product's UPC(s), including container type and size (ounces) shows the value for Size (Ounces) saved as: TestCase73082Ounces for UPC saved as: TestCase73082UPC
	And I close the window that opened
	And I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase73082)
	And I confirm that the status of the product saved as: TestCase73082 is: TestCase73082Status
	And I delete the Supplier Report file saved as 73082

@ScenarioId:977
Scenario: [108254] UPC Report for All Products with Retailer - Create new products and verify in report
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	#Create a formulated product - Chalk
	Given I generate a random UPC number and save as: UPC108254Chalk
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk
	Then I save the product information as: TestCase108254Chalk
	Given I call Shared Step 26897 (Product Characteristics - Solid only available - continue)
	Given I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	And I call Shared Step 29181 (Ingredients - add any chemical) with name: Chlorine
	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	And In the 'Select Retailers' window I select the retailer: Walgreens
	And I click continue
	And I call Shared Step 85909 (UPC - Confirm Package type link and drop down not shown - Add UPC data - Continue) for UPC: saved as UPC108254Chalk, container type: Plastic Container and size: 12 click continue
	And I set the OSHA-compliant Safety Data Sheet, English field to: Request to author
	Then in the Regulatory Documents to Provide page I click Continue
	Then in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	And I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
		| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
	And I call Shared Step 57883 (Comments - Happy Path) and enter the comment: test
	Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given If purchase details are showing click confirm order
	#Create an article product - lightbulb
	Given I navigate to the home page
	Given I generate a random UPC number and save as: UPC108254Lightbulb
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Light Bulbs - Incandescent Bulbs
	Then I save the product information as: TestCase108254Lightbulb
	And I call Shared Step 69687 (Additional Product Information - US, No(PL))
	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given I call Shared Step 71955 (Answer Electronic Equipment questions - Without Cathode Ray - No to all)
	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Walgreens
	And I call Shared Step 85909 (UPC - Confirm Package type link and drop down not shown - Add UPC data - Continue) for UPC: saved as UPC108254Lightbulb, container type: Plastic Container and size: 12 click continue
	Then in the Additional Documents to Provide page I click Continue
	Then in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: test
	Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given If purchase details are showing click confirm order
	#Create an enhanced article product - Lithium BCP (Camera w/ Battery)
	Given I navigate to the home page
	Given I generate a random UPC number and save as: UPC108254BCP
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	And I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Camera w/Battery
	Then I save the product information as: TestCase108254BCP
	And I call Shared Step 70393 (Additional Product Information - With marketed for use by a Child - Direct Ship - Private Label questions only)
	And I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I set the Indicate how battery is packaged option to: The battery is shipped with but not included in my product
	Given I add the following batteries:
		| Battery Type | Manufacturer | Number of batteries per package | How many batteries required to run | Saved As       |
		| Lithium Ion  | <any>        | 4                               | 4                                  | lithiumbattery |
	Given I click continue
	And I call Shared Step 48369 (Toxicity Characteristics Leaching Procedure (TCLP) - No to ALL With Copper)
	And I call Shared Step 58189 (Answer Electronic Equipment questions - With Cathode Ray - No to all)
	Given I call Shared Step 60096 (Lithium Battery Transportation)
	And I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Walgreens
	And I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC108254BCP, container type: Plastic Container and size: 32
	And I call Shared Step 57883 (Comments - Happy Path) and enter the comment: test
	And I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given If purchase details are showing click confirm order
	#Begin steps to get report and verify data
	Given I navigate to the home page
	Given I click the My Reports icon in the QuickLinks Pane
	Given Under the Supplier Reports menu I choose: UPCs and Registrations (Retailer Specific)
	Then In the Supplier Reports screen the current sub-page should be: UPCs and Registrations (Retailer Specific)
	Given In the Supplier Reports screen I click on the Download button
	Given I click on close in the Report Download dialog
	Given I confirm that an excel file is produced called UPCs and Registrations (Retailer Specific).xlsx and save as 108254
	And I confirm that for product saved as: TestCase108254Chalk the value in each of the columns of spreadsheet 108254 is as follows:
		| Product Name | UPC            | Retailer  | Status    | Ounces | Container Type    | Registration Type | Subscription Type |
		| Chalk        | UPC108254Chalk | Walgreens | Submitted | 12     | Plastic Container | Stationery        | FORMULATED        |
	And I confirm that for product saved as: TestCase108254Lightbulb the value in each of the columns of spreadsheet 108254 is as follows:
		| Product Name                     | UPC                | Retailer  | Status    | Ounces | Container Type    | Registration Type | Subscription Type |
		| Light Bulbs - Incandescent Bulbs | UPC108254Lightbulb | Walgreens | Submitted | 12     | Plastic Container | Home Improvement  | ARTICLES          |
	And I confirm that for product saved as: TestCase108254BCP the value in each of the columns of spreadsheet 108254 is as follows:
		| Product Name    | UPC          | Retailer  | Status    | Ounces | Container Type    | Registration Type          | Subscription Type |
		| Camera wBattery | UPC108254BCP | Walgreens | Submitted | 32     | Plastic Container | Battery-Containing Product | ENHANCED ARTICLES |
	And I delete the Supplier Report file saved as 108254

@ScenarioId:6270
Scenario: [73225] Kits that Contain a specific Product
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I click the My Reports icon in the QuickLinks Pane
	Given Under the Supplier Reports menu I choose: Kits Containing a Specific Registration
	Then In the Supplier Reports screen the current sub-page should be: Kits Containing a Specific Registration
	Given In the Supplier Reports screen the current page description should be: For a specific WERCSmart ID, the report will show the various Kit registrations that include the specific registration.
	Given I select a random product from the drop down
	Given In the Supplier Reports screen I click on the Download button
	Given I click on close in the Report Download dialog
	Given I confirm that an excel file is produced called Kits Containing a Specific Registration.xlsx and save as 73225
	Then I confirm that the excel file saved as: 73225 contains the following columns:
		| Column              |
		| Product in Kit      |
		| Product in Kit Name |
		| Kit WPSID           |
		| Kit Name            |
	And I delete the Supplier Report file saved as 73225

@ScenarioId:6349
Scenario: [73228] Products that are Associated with a specific Kit
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I click the My Reports icon in the QuickLinks Pane
	Given Under the Supplier Reports menu I choose: Kit Registrations
	Then In the Supplier Reports screen the current sub-page should be: Kit Registrations
	Given In the Supplier Reports screen the current page description should be: For a specific Kit registration, the report will include the individual WERCSmart IDs that are included in the Kit.
	Given I select a random product from the drop down
	Given In the Supplier Reports screen I click on the Download button
	Given I click on close in the Report Download dialog
	Given I confirm that an excel file is produced called Kit Registrations.xlsx and save as 73228
	Then I confirm that the excel file saved as: 73228 contains the following columns:
		| Column              |
		| Product in Kit      |
		| Product in Kit Name |
		| Kit WPSID           |
		| Kit Name            |
	And I delete the Supplier Report file saved as 73228

@ScenarioId:6262
Scenario: [73226] Pesticide Certificate Report
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I click the My Reports icon in the QuickLinks Pane
	Given Under the Supplier Reports menu I choose: Pesticide Certificate Report
	Then In the Supplier Reports screen the current sub-page should be: Pesticide Certificate Report
	Given In the Supplier Reports screen I click on the Download button
	Given I click on close in the Report Download dialog
	Given I confirm that an excel file is produced called Pesticide Certificate Report.xlsx and save as excel73226
	Then I confirm that the excel file saved as: excel73226 contains the following columns:
		| Column                                            |
		| Supplier                                          |
		| WPSID                                             |
		| Product Name                                      |
		| Pesticide Certificates Currently Expired Count    |
		| Pesticide Certificates Expire in 1-30 Days Count  |
		| Pesticide Certificates Expire in 31-60 Days Count |
		| Pesticide Certificates Expire in 61-90 Days Count |
		| In Recertification                                |
	Then I save the value with the header WPSID on the first product in the excel spreadsheet saved as: excel73226 as TestCase73226Id
	Then I save the value with the header Product Name on the first product in the excel spreadsheet saved as: excel73226 as TestCase73226Name
	Given I save the product with name: TestCase73226Name and id: TestCase73226Id as: TestCase73226
	And I delete the excel file saved as excel73226

@ScenarioId:984
Scenario: [73229] Products with VOCs
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I click the My Reports icon in the QuickLinks Pane
	Given Under the Supplier Reports menu I choose: Volatile Organic Compounds
	Then In the Supplier Reports screen the current sub-page should be: Volatile Organic Compounds
	Given In the Supplier Reports screen the current page description should be: Registrations within the Account that have VOC data. Report includes the VOC information and other data for each registration.
	Given In the Supplier Reports screen I click on the Download button
	Given I click on close in the Report Download dialog
	Given I confirm that an excel file is produced called Volatile Organic Compounds.xlsx and save as 73229
	Then I confirm that the excel file saved as: 73229 contains the following columns:
		| Column       |
		| Supplier     |
		| WPSID        |
		| Product Name |
		| CN           |
		| CT           |
		| DC           |
		| DE           |
		| IL           |
		| IN           |
		| MA           |
		| MD           |
		| ME           |
		| MI           |
		| NH           |
		| NJ           |
		| NY           |
		| OH           |
		| PA           |
		| RI           |
		| TX           |
		| UT           |
		| VA           |
		| VT           |
	And I delete the excel file saved as 73229

@ScenarioId:983
Scenario: [73227] Products and Recommended Use Report
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I click the My Reports icon in the QuickLinks Pane
	Given Under the Supplier Reports menu I choose: Product Types Registered
	Then In the Supplier Reports screen the current sub-page should be: Product Types Registered
	Given In the Supplier Reports screen the current page description should be: A list of the Products registered in the account with the corresponding Product Type per registration.
	Given In the Supplier Reports screen I click on the Download button
	Given I click on close in the Report Download dialog
	Given I confirm that an excel file is produced called Product Types Registered.xlsx and save as 73227
	Then I confirm that the excel file saved as: 73227 contains the following columns:
		| Column         |
		| Supplier       |
		| RU Description |
		| RU Category    |
		| WPSID          |
		| Product Name   |
	And I delete the excel file saved as 73227

@ScenarioId:985
Scenario: [73230] UPC Report for Specific Product with Retailer
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I click the My Reports icon in the QuickLinks Pane
	Given Under the Supplier Reports menu I choose: UPC and Retailer (Single Registration)
	Then In the Supplier Reports screen the current sub-page should be: UPC and Retailer (Single Registration)
	Given In the Supplier Reports screen the current page description should be: For a specific WERCSmart registration, the report outlines the retailers and UPCs associated to the registration.
	Given I select a random product from the drop down
	Given In the Supplier Reports screen I click on the Download button
	Given I click on close in the Report Download dialog
	Given I confirm that an excel file is produced called UPC and Retailer (Single Registration).xlsx and save as 73230
	Then I confirm that the excel file saved as: 73230 contains the following columns:
		| Column          |
		| WPSID           |
		| Product Name    |
		| Brand           |
		| Recommended Use |
		| Individual UPC  |
		| Case UPC        |
		| Retailer        |
		| Status          |
	And I delete the excel file saved as 73230

Scenario: [75391] Sustainability Survey Eligibility – Health & Beauty
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I click the My Reports icon in the QuickLinks Pane
	Given Under the Supplier Reports menu I choose: Sustainability Survey Eligibility - Health & Beauty
	Then In the Supplier Reports screen the current sub-page should be: Sustainability Survey Eligibility - Health & Beauty
	Given In the Supplier Report page in the select Retailer dropdown I select: Target
	Given In the Supplier Reports screen I click on the Download button
	Given I click on close in the Report Download dialog
	Given I confirm that an excel file is produced called Sustainability Survey Eligibility  Health & Beauty.xlsx and save as 75391
	Then I confirm that the excel file saved as: 75391 contains the following columns:
		| Column                                              |
		| WERCSmart ID                                        |
		| Product Name                                        |
		| Quantity of Active UPCs                             |
		| Transparency Indicator Ratio                        |
		| 3rd Party Formula Use Indicator                     |
		| Last Submission Date                                |
		| Current Subscription Level                          |
		| Current Data Tier Consent for the Selected Retailer |
	Then I save the first product in the excel spreadsheet saved as: 75391 as TestCase75391
	Then I save the value with the header Quantity of Active UPCs on the first product in the excel spreadsheet saved as: 75391 as TestCase75391UPCs
	Then I save the value with the header Transparency Indicator Ratio on the first product in the excel spreadsheet saved as: 75391 as TestCase75391TransRatio
	Then I save the value with the header Last Submission Date on the first product in the excel spreadsheet saved as: 75391 as TestCase75391Date
	Then I save the value with the header Current Subscription Level on the first product in the excel spreadsheet saved as: 75391 as TestCase75391Subscription
	Then I save the value with the header Current Data Tier Consent for the Selected Retailer on the first product in the excel spreadsheet saved as: 75391 as TestCase75391DataTier
	Given I navigate to the home page
	Given I search for the product saved as: TestCase75391
	And I confirm that the product returned has the same name as the product saved as: TestCase75391
	And I confirm that the product returned has the retailer: TG
	Given I click Row Actions for the first product returned
	And I click on the Row Action: View UPCs
	And I switch to the tab with title: View UPCs
	And I confirm that the number of UPCs equals the number saved as: TestCase75391UPCs
	And I close the window that opened
	Given I click Row Actions for the first product returned
	And I click on the Row Action: View
	Then I switch to the Data Summary page
	And I confirm that the Transparency Ratio underneath Ingredients equals: TestCase75391TransRatio
	And I close the window that opened
	And I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase75391)
	Given I confirm that the Current Submission date in SHA Manager matches the date saved as: TestCase75391Date
	Given I navigate to the WERCSmart site
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I click on My Account
	And In the My Account page I confirm that the subscription level is: TestCase75391Subscription
	Then I click the Retail Partners icon in the Navigation Pane
	And I select the retailer: Target
	And I confirm that the Data Consent Tiers information matches the information saved as: TestCase75391DataTier
	And I delete the Supplier Report file saved as 75391

#fails because of a bug 106613
@ScenarioId:986
Scenario: [76551] California Proposition 65 - Registrations Prior to August 30, 2018
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I click the My Reports icon in the QuickLinks Pane
	Given Under the Supplier Reports menu I choose: California Proposition 65
	Then In the Supplier Reports screen the current sub-page should be: California Proposition 65
	And In the Supplier Report page I should see the report description should be showing with text: For items submitted prior to August 30, 2018. The report will list registrations that are active and not updated with the current Prop 65 data. Regulation was revised in mid-2018.
	Given In the Supplier Reports screen I click on the Download button
	Given I confirm that a file is downloaded with file name: California Proposition 65.xlsx then close the Report Download popup. I save the file as excel76551
	Then I confirm that the excel file saved as: excel76551 contains the following columns:
		| Column                    |
		| WERCSmart ID              |
		| WERCSmart Product Name    |
		| Contains Chemical on List |
		| Prop 65 Warning Required  |
		| Prop 65 Warning on Label  |
		| Exposure Warning          |
		| Warning Trigger           |
		| Warning Transmitted       |
		| Last Order Date           |
		| Last Revision Date        |
	And I delete the Supplier Report file saved as excel76551

#TODO - this scenario is incomplete because the possibility of automating the rest of the test case needs review.
@ScenarioId:978
Scenario: [76759] Waste Classification Summary Report
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I click the My Reports icon in the QuickLinks Pane
	Given Under the Supplier Reports menu I choose: Waste Classification Summary
	Then In the Supplier Reports screen the current sub-page should be: Waste Classification Summary
	And In the Supplier Report page I should see the report description should be showing with text: For each active registration, details of the classification made during assessment for the United States Federal and State regulations. For specific information about how the waste was classified, you may request an Additional Document (no charge) from the My Products area for the specific registration.
	Given In the Supplier Reports screen I click on the Download button
	Given I confirm that a file is downloaded with file name: Waste Classification Summary.xlsx then close the Report Download popup. I save the file as SupplierReport76759
	Then I confirm that the excel file saved as: SupplierReport76759 contains the following columns:
		| Column         |
		| WERCSmart ID   |
		| Product Name   |
		| Federal Waste  |
		| EPA Type       |
		| EPA Code       |
		| WA Hazard      |
		| CA Hazard      |
		| CT Hazard      |
		| MI Hazard      |
		| Alabama        |
		| Alaska         |
		| Arizona        |
		| Arkansas       |
		| California     |
		| Colorado       |
		| Connecticut    |
		| Delaware       |
		| Florida        |
		| Georgia        |
		| Hawaii         |
		| Idaho          |
		| Illinois       |
		| Indiana        |
		| Iowa           |
		| Kansas         |
		| Kentucky       |
		| Louisiana      |
		| Maine          |
		| Maryland       |
		| Massachusetts  |
		| Michigan       |
		| Minnesota      |
		| Mississippi    |
		| Missouri       |
		| Montana        |
		| Nebraska       |
		| Nevada         |
		| New Hampshire  |
		| New Jersey     |
		| New Mexico     |
		| New York       |
		| North Carolina |
		| North Dakota   |
		| Ohio           |
		| Oklahoma       |
		| Oregon         |
		| Pennsylvania   |
		| Rhode Island   |
		| South Carolina |
		| South Dakota   |
		| Tennessee      |
		| Texas          |
		| Utah           |
		| Vermont        |
		| Virginia       |
		| Washington     |
		| West Virginia  |
		| Wisconsin      |
		| Wyoming        |
	Then I get the excel row data file saved as: SupplierReport76759 and save the data to context
	And I delete the Supplier Report file saved as SupplierReport76759
	And I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Then In the Authoring menu I select Power Designer Plus
	Then I filter subformat SWST and open checklist [SECT0150] Waste Checklist
	Then I check if the excel data matches the checklist data
	Then I close the window that opened

#Unable to run because the report requires a 1 year old product that is in completed status
@tfs_design
@ScenarioId:6619
Scenario: [79635] Subscription Renewal (Registrations Eligible for Deletion) report
	#Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I click the My Reports icon in the QuickLinks Pane
	Given Under the Supplier Reports menu I choose: Subscription Renewal (Registrations Eligible for Deletion)
	Then In the Supplier Reports screen the current sub-page should be: Subscription Renewal (Registrations Eligible for Deletion)
	Then I Check that the Description text on the supplier report page matches: The report will provide you with the information for current, submitted registrations, regardless of current registration status (Net Yet Submitted, In Progress, Sending, Accepted, Needs Attention), that are eligible for deletion from your account. The quantity of submitted registrations directly impacts your subscription levels for Formulated, Enhanced Articles and Articles. Eligible for deletion criteria is based on order history dates.
	Given In the Supplier Reports screen I click on the Download button
	Given I click on close in the Report Download dialog
	Given I confirm that an excel file is produced called Subscription Renewal (Registrations Eligible for Deletion).xlsx and save as 79635
	Then I confirm that the excel file saved as: 79635 contains the following columns:
		| Column                 |
		| WERCSmart ID           |
		| Product Name           |
		| Eligible for Deletion  |
		| Last Submission Date   |
		| Original Creation Date |
		| Retailers associated   |
		| Number of Active UPCs  |
	Then I Check that in the excel file saved as: 79635 the Eligible for deletion Dates are exactly 1 year from the Last Submission dates.
	Then I get a value for WERCSmart ID from the excel file saved as: 79635 and save it to context as: WERCSmartProduct79635
	And I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: WERCSmartProduct79635)
	Then I Check that for the product: WERCSmartProduct79635 the Details in SHA Manager Match the details found in the file: 79635
	And I delete the Supplier Report file saved as 79635

#Needs Finishing (Currently Download only gets a hltml file and not a spreadsheet)
@ScenarioId:976
Scenario: [110480] Subscription Renewal (Registrations Eligible for Deletion)- Check for correct description text
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I click the My Reports icon in the QuickLinks Pane
	Given Under the Supplier Reports menu I choose: Subscription Renewal (Registrations Eligible for Deletion)
	Then In the Supplier Reports screen the current sub-page should be: Subscription Renewal (Registrations Eligible for Deletion)
	Then I Check that the Description text on the supplier report page matches: The report will provide you with the information for current, submitted registrations, regardless of current registration status (Net Yet Submitted, In Progress, Sending, Accepted, Needs Attention), that are eligible for deletion from your account. The quantity of submitted registrations directly impacts your subscription levels for Formulated, Enhanced Articles and Articles. Eligible for deletion criteria is based on order history dates.



@ScenarioId:5976
Scenario: [114764] UPCs and Registrations (Retailer Specific) - Report correctly displays case pack individual UPC
#For Ticket 108160
	Given I Submit a new product which has a Case UPC and a regular UPC
	Given I navigate to the landing page
	And I call Shared Step (Login to WERCSmart - Premium Account)
	#Then I wait for 30 seconds
	Given I click the My Reports icon in the QuickLinks Pane
	Given Under the Supplier Reports menu I choose: UPCs and Registrations (Retailer Specific)
	Then In the Supplier Reports screen the current sub-page should be: UPCs and Registrations (Retailer Specific)
	Given In the Supplier Reports screen I click on the Download button
	Given I click on close in the Report Download dialog
	Given I confirm that an excel file is produced called UPCs and Registrations (Retailer Specific).xlsx and save as 73082
	Then I confirm that in the excel file saved as: 73082 for the UPC saved as: UPC876851 there is a 'Y' in the Case Pack column and an Individual UPC listed as: UPC87685
	And I delete the Supplier Report file saved as 73082


@ScenarioId:10293
Scenario: [140261] California Proposition 65 - CSV File
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Given I click the My Reports icon in the QuickLinks Pane
Given Under the Supplier Reports menu I choose: California Proposition 65
Then I select CSV from the Select File Type
Then I select the Request Report button excel file is produced called California Proposition 65.csv and save as California Proposition 65
Given I see a Report Download popup with the following text: Report download complete!
Given I click Close in the Report Download popup
Then I confirm the most recent file has the following information Report Name: California Proposition 65 File Type: CSV Date Requested: LastReportDownloadTime Requested By: WERCS Test_Automation_ProductsAccount
Then I confirm there is a Download button for the most recent report
Then I click the Download button for the most recent report
Given I click the Products in Scope button and confirm that an excel file is produced called California Proposition 65.csv and save as California Proposition 65
Given I delete the excel file saved as California Proposition 65

@ScenarioId:10294
Scenario: [140260] Battery-Containing Products - CSV File
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Given I click the My Reports icon in the QuickLinks Pane
Given Under the Supplier Reports menu I choose: Battery-Containing Products
Then I select CSV from the Select File Type
Then I select the Request Report button excel file is produced called Battery-Containing Products.csv and save as Battery-Containing Products
Given I see a Report Download popup with the following text: The report has been scheduled. Once completed, you will see the report in your history and you will be notified of availability via email.
Given I click Close in the Report Download popup
Then I confirm the most recent file has the following information Report Name: Battery-Containing Products File Type: CSV Date Requested: LastReportDownloadTime Requested By: WERCS Test_Automation_ProductsAccount
Then I click the Download button for the most recent report
Given I click the Products in Scope button and confirm that an excel file is produced called Battery-Containing Products.csv and save as Battery-Containing Products
Given I delete the excel file saved as Battery-Containing Products

Scenario: [140273] Eligible to Obsolete - CSV File
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Given I click the My Reports icon in the QuickLinks Pane
Given Under the Supplier Reports menu I choose: Eligible to Obsolete
Then I select CSV from the Select File Type
Then I select the Request Report button excel file is produced called Eligible to Obsolete.csv and save as Eligible to Obsolete
Given I see a Report Download popup with the following text: The report has been scheduled. Once completed, you will see the report in your history and you will be notified of availability via email.
Given I click Close in the Report Download popup
Then I confirm the most recent file has the following information Report Name: Eligible to Obsolete File Type: CSV Date Requested: LastReportDownloadTime Requested By: WERCS Test_Automation_ProductsAccount
Then I click the Download button for the most recent report
Given I click the Products in Scope button and confirm that an excel file is produced called Eligible to Obsolete.csv and save as Eligible to Obsolete
Given I delete the excel file saved as Eligible to Obsolete

Scenario: [140280] Pesticide Registrations - CSV File
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Given I click the My Reports icon in the QuickLinks Pane
Given Under the Supplier Reports menu I choose: Pesticide Registrations
Then I select CSV from the Select File Type
Then I select the Request Report button excel file is produced called Pesticide Registrations.csv and save as Pesticide Registrations
Given I see a Report Download popup with the following text: The report has been scheduled. Once completed, you will see the report in your history and you will be notified of availability via email.
Given I click Close in the Report Download popup
Then I confirm the most recent file has the following information Report Name: Pesticide Registrations File Type: CSV Date Requested: LastReportDownloadTime Requested By: WERCS Test_Automation_ProductsAccount
Then I click the Download button for the most recent report
Given I click the Products in Scope button and confirm that an excel file is produced called Pesticide Registrations.csv and save as Pesticide Registrations
Given I delete the excel file saved as Pesticide Registrations

Scenario: [140289] UPC Duplication - CSV File

Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Given I click the My Reports icon in the QuickLinks Pane
Given Under the Supplier Reports menu I choose: UPC Duplication
Then I select CSV from the Select File Type
Then I select the Request Report button excel file is produced called UPC Duplication.csv and save as UPC Duplication
Given I see a Report Download popup with the following text: The report has been scheduled. Once completed, you will see the report in your history and you will be notified of availability via email.
Given I click Close in the Report Download popup
Then I confirm the most recent file has the following information Report Name: UPC Duplication File Type: CSV Date Requested: LastReportDownloadTime Requested By: WERCS Test_Automation_ProductsAccount
Then I click the Download button for the most recent report
Given I click the Products in Scope button and confirm that an excel file is produced called UPC Duplication.csv and save as UPC Duplication
Given I delete the excel file saved as UPC Duplication

Scenario: [140290] Subscription Product Types - CSV File

Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Given I click the My Reports icon in the QuickLinks Pane
Given Under the Supplier Reports menu I choose: Subscription Product Types
Then I select CSV from the Select File Type
Then I select the Request Report button excel file is produced called Subscription Product Types.csv and save as Subscription Product Types
Given I see a Report Download popup with the following text: The report has been scheduled. Once completed, you will see the report in your history and you will be notified of availability via email.
Given I click Close in the Report Download popup
Then I confirm the most recent file has the following information Report Name: Subscription Product Types File Type: CSV Date Requested: LastReportDownloadTime Requested By: WERCS Test_Automation_ProductsAccount
Then I click the Download button for the most recent report
Given I click the Products in Scope button and confirm that an excel file is produced called Subscription Product Types.csv and save as Subscription Product Types
Given I delete the excel file saved as Subscription Product Types


Scenario: [140291] UPC Duplication - CSV File

Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Given I click the My Reports icon in the QuickLinks Pane
Given Under the Supplier Reports menu I choose: UPC Duplication
Then I select CSV from the Select File Type
Then I select the Request Report button excel file is produced called UPC Duplication.csv and save as UPC Duplication
Given I see a Report Download popup with the following text: The report has been scheduled. Once completed, you will see the report in your history and you will be notified of availability via email.
Given I click Close in the Report Download popup
Then I confirm the most recent file has the following information Report Name: UPC Duplication File Type: CSV Date Requested: LastReportDownloadTime Requested By: WERCS Test_Automation_ProductsAccount
Then I click the Download button for the most recent report
Given I click the Products in Scope button and confirm that an excel file is produced called UPC Duplication.csv and save as UPC Duplication
Given I delete the excel file saved as UPC Duplication


Scenario: [140292] Volatile Organic Compounds - CSV File

Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Given I click the My Reports icon in the QuickLinks Pane
Given Under the Supplier Reports menu I choose: Volatile Organic Compounds
Then I select CSV from the Select File Type
Then I select the Request Report button excel file is produced called Volatile Organic Compounds.csv and save as Volatile Organic Compounds
Given I see a Report Download popup with the following text: The report has been scheduled. Once completed, you will see the report in your history and you will be notified of availability via email.
Given I click Close in the Report Download popup
Then I confirm the most recent file has the following information Report Name: Volatile Organic Compounds File Type: CSV Date Requested: LastReportDownloadTime Requested By: WERCS Test_Automation_ProductsAccount
Then I click the Download button for the most recent report
Given I click the Products in Scope button and confirm that an excel file is produced called Volatile Organic Compounds.csv and save as Volatile Organic Compounds
Given I delete the excel file saved as Volatile Organic Compounds


Scenario: [140293] Waste Classification Summary - CSV File

Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Given I click the My Reports icon in the QuickLinks Pane
Given Under the Supplier Reports menu I choose: Waste Classification Summary
Then I select CSV from the Select File Type
Then I select the Request Report button excel file is produced called Waste Classification Summary.csv and save as Waste Classification Summary
Given I see a Report Download popup with the following text: The report has been scheduled. Once completed, you will see the report in your history and you will be notified of availability via email.
Given I click Close in the Report Download popup
Then I confirm the most recent file has the following information Report Name: Waste Classification Summary File Type: CSV Date Requested: LastReportDownloadTime Requested By: WERCS Test_Automation_ProductsAccount
Then I click the Download button for the most recent report
Given I click the Products in Scope button and confirm that an excel file is produced called Waste Classification Summary.csv and save as Waste Classification Summary
Given I delete the excel file saved as Waste Classification Summary



@ScenarioId:10259
Scenario: [140309] Chemicals of Concern - CSV File

Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Given I click the My Reports icon in the QuickLinks Pane
Given Under the Supplier Reports menu I choose: Chemicals of Concern
Then I select CSV from the Select File Type
Then I select the Request Report button excel file is produced called Chemicals of Concern.csv and save as Chemicals of Concern
Given I see a Report Download popup with the following text: The report has been scheduled. Once completed, you will see the report in your history and you will be notified of availability via email.
Given I click Close in the Report Download popup
Then I confirm the most recent file has the following information Report Name: Chemicals of Concern File Type: CSV Date Requested: LastReportDownloadTime Requested By: WERCS Test_Automation_ProductsAccount
Then I click the Download button for the most recent report
Given I click the Products in Scope button and confirm that an excel file is produced called Chemicals of Concern.csv and save as Chemicals of Concern
Given I delete the excel file saved as Chemicals of Concern


@tfs_design
@ScenarioId:10258
Scenario: [141799] Chemicals of Concern- CSV Zip File

Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Given I click the My Reports icon in the QuickLinks Pane
Given Under the Supplier Reports menu I choose: Chemicals of Concern
Then I select CSV from the Select File Type
Given I select the Zip Report Checkbox
Then I select the Request Report button excel file is produced called Chemicals of Concern.zip and save as Chemicals of Concern
Given I see a Report Download popup with the following text: The report has been scheduled. Once completed, you will see the report in your history and you will be notified of availability via email.
Given I click Close in the Report Download popup
Then I confirm the most recent file has the following information Report Name: Chemicals of Concern File Type: CSV (Zip) Date Requested: LastReportDownloadTime Requested By: WERCS Test_Automation_ProductsAccount
Then I click the Download button for the most recent report
Given I click Close in the Report Download popup
Given I click the Products in Scope button and confirm that an excel file is produced called Chemicals of Concern.zip and save as Chemicals of Concern
Given I delete the excel file saved as Chemicals of Concern
