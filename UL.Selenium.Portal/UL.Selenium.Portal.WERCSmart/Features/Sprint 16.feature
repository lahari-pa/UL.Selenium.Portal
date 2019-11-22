@Shared
@LandingPage
@Login
@Homepage
@Signup
@wercsmart
@NewProduct
@ProductGrid
@DataSummarySheet
@RetailPartners
@SummaryPage
@PaymentMethods
@SubEnrollment
@WERCSmart_Signup
@MyAccount
@PackagingTypes
@Brands
@MyIngredients
@SupplierReports
@UPC
@SHA
@FileOps
@ForwardProductRegistration
@ProductSetUp
@MyMessages
@run_Sprint16
Feature: Sprint 16

@ScenarioId:1513
Scenario: [105329] PM Monthly Status Report - Target
	Given I generate a random UPC number and save as: UPC105329
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Shampoo (Liquid)
	Then I save the product information as: TestCase105329
	And I call Shared Step 57514 (Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path)
	And I call Shared Step 62678 (Additional Product Information - US & Canada, No Child, No OSHA, NO Direct ship, No PL, No NGFR - Continue, Happy path)
	And I call Shared Step 29181 (Ingredients - add any chemical) with name: Chlorine
	And I call Shared Step 57637 (Regulatory Information 1 - TSCA & CEPA shown, No to PROP 65 - Continue - Happy Path)
	Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
	And I call Shared Step 57506 (Transportation Details 1 - Regulated for Transport(No) - Exemption(Random) - Continue - Happy Path)
	And I call Shared Step 62536 (Transportation Details 2 > I do not ship internationally > Continue - Happy Path)
	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Target
	Given I call Shared Step 87647 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC105329, container type: Plastic Container and size: 2 do not click continue
	And In the Destination Retailers input field I input the value: 123-11-1234,125-22-1254,123-33-2589
	And I click continue
	And I call Shared Step 65080 (Login to Studio and Open SHA manager)
	And I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase105329)
	Given I call Shared Step 96169 - SHA Manager - Select Product - Actions - Advanced Reporting for saved as: TestCase105329
	Given In the Advanced Reporting popup I select report PM Monthly Status Report - Target
	And In the Advanced Reporting popup I click Submit
	And I wait for the Advanced Reporting Preparing Report popup to disappear
	Given I confirm that an excel file is produced called PM Monthly Status Report - Target.xlsx and save as 105329
	Then I confirm that the excel file saved as: 105329 contains the following columns:
		| Column                |
		| WPSID                 |
		| UPC                   |
		| DPCI                  |
		| Product Name          |
		| Supplier              |
		| Status                |
		| UPC Status            |
		| Product Activity Date |
	Given I search in the excel spreadsheet saved as: 105329 for product saved as: TestCase105329 and save its information as: ExcelInfo105329
	And I confirm that the following information is present in the excel info saved as: ExcelInfo105329:
		| WPSID          | UPC       | DPCI                                | Product Name   | Supplier                      | Status | UPC Status | Product Activity Date |
		| TestCase105329 | UPC105329 | 123-11-1234,125-22-1254,123-33-2589 | Shampoo Liquid | QA_Automation_ProductsAccount | New    | value      | today                 |

@ScenarioId:1530
Scenario:[96226] Daily Report - Registration Traffic
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	And In SHA Manager - Select Actions - Advanced Reporting
	Given In the Advanced Reporting popup I select report Daily Report - Registration Traffic
	Then I enter start date 08-01-2019 and end date 09-01-2019 for Advanced Reporting
	And I wait for the Advanced Reporting Preparing Report popup to disappear
	Given I confirm that an excel file is produced called Daily Report - Registration Traffic.xls and save as 96226
	Then I confirm that the excel file saved as: 96226 contains the following columns:
		| Column                         |
		| New                            |
		| Forward                        |
		| UPC Additions                  |
		| Pest Updates                   |
		| Recertified                    |
		| Updated                        |
		| Rejected                       |
		| Suspended                      |
		| Published (Auto or Manual)     |
		| SDS Authoring- NGHS            |
		| SDS Authoring - Other          |
		| SDS Authoring - Add'l Language |
		| UPCs Completed to Retail       |
		| Product IDs Complete to Retail |
	And I verify the file saved as: 96226 contains integers in all fields on the first data row

@ScenarioId:1548
Scenario:[96174] Daily Report - WERCSmart Additional Reports Published
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	And In SHA Manager - Select Actions - Advanced Reporting
	And In the Advanced Reporting popup I select report Daily Report - WERCSmart Additional Reports Published
	And Verify Daily Report - WERCSmart Additional Reports Published Advanced Report description reads: Internal Use Only.  The output will display the quantity of reports published by the system in relation to a WERCSmart User's request for added report.  Maximum date range is 30 days.
	Then I enter start date 08-01-2019 and end date 08-20-2019 for Advanced Reporting
	And I wait for the Advanced Reporting Preparing Report popup to disappear
	Then I confirm that an excel file is produced called Daily Report - Wercsmart Additional Reports Published.xls and save as 96174
	And I confirm that the excel file saved as: 96174 contains the following columns:
		| Column                  |
		| Subformat               |
		| Description             |
		| Fee                     |
		| Additional Language Fee |
		| Language                |
		| Reports Published       |
	And I verify the file saved as: 96174 against the specific requirements for Daily Report - WERCSmart Additional Reports Published

@ScenarioId:1568
Scenario:[112754] SHA Manager: Advanced Reports: Obsolete Report: Obsoleted Products
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	And In SHA Manager - Select Actions - Advanced Reporting
	And In the Advanced Reporting popup I verify I cannot select report Obsoleted Products
	And Verify no Advanced Report exists with description reading: List of Obsoleted Products, with Supplier Name and User

@ScenarioId:1575
Scenario:[112940] Product Registration: Vendor Comment Area Revise Limit from 200 to 500 Characters and Spaces.
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Suppository, Medicinal
	Then I save the product information as: TestCase58605
	Given I call Shared Step 57501 (Product Characteristics - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue)
	Given I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Glycerin      | 30      | false               | false       |            |
		| Glucose       | 30      | false               | false       |            |
		| Aqua          | 40      | false               | false       |            |
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
	#Given I call Shared Step 63219 (Retailer Association - Select No Retailer - Click continue)
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	Given I call Shared Step 60567 (Upload Product Label only)
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Then I should see the Comments Page for the New Product
	And The remaining characters counter displays: 500/500
	Given I append the following into the comments field: comments
	And The remaining characters counter displays: 492/500
	Then I append the following into the comments field: comments
	And The remaining characters counter displays: 484/500
	And I append the following into the comments field: comments
	And The remaining characters counter displays: 476/500
	And I append the following into the comments field: comments
	And The remaining characters counter displays: 468/500
	And I enter 500 characters into the comments field
	And The remaining characters counter displays: 0/500
	And I enter 502 characters into the comments field
	And The remaining characters counter displays: 0/500
	Then in the Comments page I click Continue
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Suppository, Medicinal
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase58605

#Scenario:[113004] UPC Data Expansion: Transportation and Name: My Reports: UPC Error Details
#	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
#	And I click the Supplier Reports link in the expanded navigation side menu
#	Then Under the Supplier Reports menu I choose: UPC Error Details
#Incomplete: waiting for bug 114335 to resolve to complete.
@tfs_design
@ScenarioId:5961
Scenario: [78452] Retailer Products in Recertification Report
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	And In SHA Manager - Select Actions - Advanced Reporting
	And In the Advanced Reporting popup I select report Retailer Products in Recertification
	And In the Advanced Reporting Retailer Products in Recertification report dropdown I select retailer: Wal-Mart/SAM'S CLUB
	And In the Advanced Reporting Retailer Products in Recertification report dropdown I click submit
	And I wait for the Advanced Reporting Preparing Report popup to disappear
	Then I confirm that an excel file is produced called Retailer Products in Recertification.xls and save as excel78452
	And I confirm that the excel file saved as: excel78452 contains the following columns:
		| Column               |
		| WPSID                |
		| Product Name         |
		| Supplier             |
		| Recertification Date |
	And I save the information for the first record in Retailer Product in Recert excel spreadsheet saved as: excel78452 as: TestCase78452 and ProdInfo78452
	And I close the Advanced Reporting popup
	And I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: ProdInfo78452)
	And I confirm that the list of retailers associated with product ProdInfo78452 includes retailer WM
	And I call Shared Step 51351 (SHA > Select Product > View Recertification History) for product saved as: ProdInfo78452

#Incomplete: waiting for bug 111856 to complete.
@tfs_design
@ScenarioId:5974
Scenario: [87182] 3rd Party Formula Use in Registrations
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk
	Given I call Shared Step 26897 (Product Characteristics - Solid only available - continue)
	Given I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	And I enter text: WPS in the component search box
	And I select the component search result with CAS matching text: WPS and save ingredient as: Ingredient87182
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	And In SHA Manager - Select Actions - Advanced Reporting
	And In the Advanced Reporting popup I select report 3rd Party Formula Use in Registrations
	And In the 3rd Party Formula Use in Registrations text box I enter the CAS Number without the WPS for ingredient: Ingredient87182
	And In the Advanced Reporting 3rd Party Formula Use in Registrations report I click submit
	Then I confirm that an excel file is produced called 3rd Party Formula Use in Registrations.xls and save as excel87182
	And I confirm that the excel file saved as: excel87182 contains the following columns:
		| Column              |
		| WPSID               |
		| Supplier Name       |
		| Contact Email       |
		| Last Order Date     |
		| Last Published Date |
		| Status              |
	And I save the information for the first record in 3rd Party Formula Use in Registrations excel spreadsheet saved as: excel87182 as: TestCase87182 and ProdInfo87182
	And I close the Advanced Reporting popup
	And I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: ProdInfo87182)

@ScenarioId:5975
Scenario: [71099] Advanced Reporting - Column Sorting
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	And In SHA Manager - Select Actions - Advanced Reporting
	And I confirm that the Report Names are listed in abc order
	And I click on the Report Name column
	And I confirm that the Report Names are listed in cba order
	And I confirm that the down arrow next to Report Name is active
	And I click on the Report Name column
	And I confirm that the Report Names are listed in abc order
	And I confirm that the up arrow next to Report Name is active
	And I click on the Report Description column
	And I confirm that the report descriptions are listed in cba order
	And I confirm that the up arrow next to Report Description is active
	And I close the Advanced Reporting popup

@ScenarioId:6006
Scenario: [26815] Advanced Report Options
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	And In SHA Manager - Select Actions - Advanced Reporting
	And In Advanced Reporting I confirm I see a table called Report List
	And In Advanced Reporting I confirm I see column header Report Name
	And In Advanced Reporting I confirm I see column header Report Description
	And I verify that the following options are available in the Report List table:
		| Report Name                                                          | Report Description                                                                                                                                                                                                                                                                                                                         |
		| 3rd Party Formula Use in Registrations                               | Providing a 3rd Party Formula ID, results will display registrations that contain the 3rd party ingredient.                                                                                                                                                                                                                                |
		| Assigned Product Report                                              | Assigned products that are not in recertification                                                                                                                                                                                                                                                                                          |
		| BPC Sustainability Survey Eligibility � H & B                        | BPC Sustainability Survey Eligibility � Health & Beauty                                                                                                                                                                                                                                                                                    |
		| CA Prop 65 by Retailer                                               | Query all Active/Completed UPC�s associated to the selected retailer under the selected upc date range where header data code P65ONE has: P65ONE01 Value = 1 (Yes), or P65ONE02 Value = 2 (No)                                                                                                                                             |
		| Canadian Tire Stewardship � My Account                               | Canadian Tire Stewardship � My Account                                                                                                                                                                                                                                                                                                     |
		| Completed Battery Product Without BATTREF                            | Completed Battery Products Without Battery Reference                                                                                                                                                                                                                                                                                       |
		| Completed Product, All Retailers with RTF                            | Completed Product, All Retailers with RTF as Primary                                                                                                                                                                                                                                                                                       |
		| Completed Product, NRTLR with RTF                                    | Completed Product, No Retailer with RTF                                                                                                                                                                                                                                                                                                    |
		| Current WERCSmart Customers                                          | List of current WERCSmart user, with roles, email and company information for Marketing and News                                                                                                                                                                                                                                           |
		| Daily Report - Archived and Cancelled Registrations, Retailers, UPCs | Internal Use Only.  The output will display the quantity of product IDs that have had UPCs or Retailers archived from a registration, or had the registration cancelled, or has been made obsolete by the WERCSmart User.  Maximum date range is 30 days.  Time frame is 12:00am on the Start Date and 11:59pm on the End Date.  TFS94714. |
		| Daily Report - Data Tier Consent                                     | Internal Use Only. The output will display the quantity of WERCSmart accounts that have products in scope for Data Tier Consent for a retailer program and have either granted, or revoked consent at the various levels.                                                                                                                  |
		| Daily Report - Item Sync                                             | Internal Use Only.  The output will display the quantity of product IDs and UPCs that had Item Sync utilized to transfer to a participating Retailer.  Maximum date range is 30 days.  Time frame is 12:00am on the Start Date and 11:59pm on the End Date.  TFS94663                                                                      |
		| Daily Report - Registration Traffic                                  | Internal Use Only.  The output will display the quantity of product IDs that came into SHA Manager via various routes and were processed by the Assessment team.  The report also includes authoring statistics.  Maximum date range is 30 days.  Time frame is 12:00am on the Start Date and 11:59pm on the End Date.                     |
		| Daily Report - WERCSmart Additional Reports Published                | Internal Use Only.  The output will display the quantity of reports generated by WERCSmart Users from within their My Report area within WERCSmart.  Maximum date range is 30 days.  Time frame is 12:00am on the Start Date and 11:59pm on the End Date.  TFS94705                                                                        |
		| Data Quality Review for Walmart                                      | Output consists of numerous datapoints that will allow internal users to manage the output for their immediate purpose and provide an overview of the Walmart-specific data provided to the retailer as a means of Quality Assurance. The report allow you to filter by product Last publish Date range and is limited to 500 records.     |
		| Expedite Products Published                                          | Count of Expedite Products Published                                                                                                                                                                                                                                                                                                       |
		| First Login Report                                                   | First Login Report for Portal Users                                                                                                                                                                                                                                                                                                        |
		| Item Sync Report - Walmart                                           | For Walmart Only - Indicate Date Range to view the UPCs requesting during the period by the Retailer.                                                                                                                                                                                                                                      |
		| Kits With All Items AGHS                                             | Kits With All Child Products Converted To AGHS                                                                                                                                                                                                                                                                                             |
		| Kits With Specific Product                                           | Kits With Specific Product                                                                                                                                                                                                                                                                                                                 |
		| Kits, Complete, Re-Assessment Needed                                 | Kits, Complete, Re-Assessment Needed                                                                                                                                                                                                                                                                                                       |
		| Last 30 Days, Random Product for Reviewer                            | 20 Random Products for a Reviewer in the Last 30 Days                                                                                                                                                                                                                                                                                      |
		| Obsoleted Products                                                   | List of Obsoleted Products, with Supplier Name and User                                                                                                                                                                                                                                                                                    |
		| PM Monthly Status Report - Target                                    | Target Monthly Status Report                                                                                                                                                                                                                                                                                                               |
		| PM Monthly Status Report - Target Multi DPCI                         | Target Monthly Multi DPCI Status Report                                                                                                                                                                                                                                                                                                    |
		| PM Monthy Data Integrity Audit - Walgreens                           | Walgreens Data Integrity Audit Monthly                                                                                                                                                                                                                                                                                                     |
		| PM Retailer Distinct Product and UPC Counts                          | (INTERNAL USE ONLY) Retailer Distinct Product and UPC Counts                                                                                                                                                                                                                                                                               |
		| PM Save Mart Weekly Item Sync Report                                 | Save Mart Weekly Item Sync Report                                                                                                                                                                                                                                                                                                          |
		| PM Walgreen Monthly Active Completed Report                          | Walgreen Monthly Active Completed Report                                                                                                                                                                                                                                                                                                   |
		| PM Walgreen Monthly Item Sync Report                                 | Walgreen Monthly Item Sync Report                                                                                                                                                                                                                                                                                                          |
		| PM Walgreen Weekly Item Sync Report                                  | Walgreen Weekly Item Sync Report                                                                                                                                                                                                                                                                                                           |
		| PM Walmart Monthly Supplier Contact Report                           | Walmart Monthly Supplier Contact Report                                                                                                                                                                                                                                                                                                    |
		| PM Walmart Monthly WMQC Report                                       | Walmart Monthly Published WMQC subformat Report                                                                                                                                                                                                                                                                                            |
		| PM Weekly Incomplete Products - Albertsons                           | Albertsons Incomplete Products Weekly                                                                                                                                                                                                                                                                                                      |
		| PM Weekly Product Report - Kohls                                     | Kohls Weekly Product Report                                                                                                                                                                                                                                                                                                                |
		| PM Weekly Status Report - Any Retailer                               | Retailer Weekly Status Report                                                                                                                                                                                                                                                                                                              |
		| PM Weekly Status Report - Auto Zone                                  | Auto Zone Weekly Status Report                                                                                                                                                                                                                                                                                                             |
		| PM Weekly Status Report - Canadian Tire                              | Canadian Tire Weekly Status Report                                                                                                                                                                                                                                                                                                         |
		| PM Weekly Status Report - Costco                                     | Costco Weekly Status Report                                                                                                                                                                                                                                                                                                                |
		| PM Weekly Status Report - CVS                                        | CVS Weekly Status Report                                                                                                                                                                                                                                                                                                                   |
		| PM Weekly Status Report - DSG                                        | DSG Weekly Status Report                                                                                                                                                                                                                                                                                                                   |
		| PM Weekly Status Report - Genuine Parts                              | Genuine Parts Weekly Status Report                                                                                                                                                                                                                                                                                                         |
		| PM Weekly Status Report - Kroger                                     | Kroger Weekly Status Report                                                                                                                                                                                                                                                                                                                |
		| PM Weekly Status Report - McLane                                     | McLane Weekly Status Report                                                                                                                                                                                                                                                                                                                |
		| PM Weekly Status Report - SaveMart Archive                           | SaveMart Weekly Archive Status Report                                                                                                                                                                                                                                                                                                      |
		| PM Weekly Status Report - Sears                                      | Sears Weekly Status Report                                                                                                                                                                                                                                                                                                                 |
		| PM Weekly Status Report - Sears Archive                              | Sears Weekly Archive Status Report                                                                                                                                                                                                                                                                                                         |
		| PM Weekly Status Report - Staples                                    | Staples Weekly Status Report                                                                                                                                                                                                                                                                                                               |
		| PM Weekly Status Report - Tractor Supply                             | Tractor Supply Weekly Status Report                                                                                                                                                                                                                                                                                                        |
		| PM Weekly Status Report - TS Archive                                 | Tractor Supply Weekly Archive Status Report                                                                                                                                                                                                                                                                                                |
		| PM WM Archived Products                                              | Walmart Archived Product                                                                                                                                                                                                                                                                                                                   |
		| PM WM Recertification Query                                          | Walmart Recertification Query                                                                                                                                                                                                                                                                                                              |
		| Product Registrations Published                                      | Assessed Registrations Published for Transfer and Completion to Retailers within a Date Range                                                                                                                                                                                                                                              |
		| Product Review by Type and Retailer                                  | Report will randomly pick assessed registrations that are published, for a selected retailer, and selected Product Type.                                                                                                                                                                                                                   |
		| Redeemed Code Report                                                 | Redeemed Code Report                                                                                                                                                                                                                                                                                                                       |
		| Retail Assessment Delivery                                           | Output, per Retailer, for quantity of UPCs and WERCSmart IDs provided to the retailer within a specified date range (start and End)                                                                                                                                                                                                        |
		| Retailer 50 Random Products in Last 30 Days                          | List of retailer's products currently in recertification                                                                                                                                                                                                                                                                                   |
		| Retailer Products in Recertification                                 | List of retailer's products currently in recertification                                                                                                                                                                                                                                                                                   |
		| Subscription Product Types                                           | Supplier Products Formulated Status                                                                                                                                                                                                                                                                                                        |
		| Supplier Invoice Report                                              | Supplier Invoice Report From Order ID                                                                                                                                                                                                                                                                                                      |
		| Supplier Products Waste Codes                                        | All Waste Codes for Supplier Products                                                                                                                                                                                                                                                                                                      |
		| TAT Progress Report                                                  | TAT With MTD and YTD                                                                                                                                                                                                                                                                                                                       |
		| UPC Details for Registration - Specific Retailer                     | Internal Use Only.  UPCs are listed for a chosen Retailer and include any additional UPC data such as Case Pack, Net Explosive Mass, and other details.                                                                                                                                                                                    |
		| UPCs Added Yesterday                                                 | UPCs Added Yesterday                                                                                                                                                                                                                                                                                                                       |
		| VOC Monthly Report - Sears                                           | Sears Monthly VOC Report                                                                                                                                                                                                                                                                                                                   |
		| VOC Monthly Report - Walmart                                         | Walmart Monthly VOC Report                                                                                                                                                                                                                                                                                                                 |
		| WalMart DSV Products Report                                          | WalMart DSV Products Report                                                                                                                                                                                                                                                                                                                |
		| Weekly WERCSmart Survey Query                                        | WERCSmart_Survey_Query                                                                                                                                                                                                                                                                                                                     |
		| WM Slotting Code Report                                              | WM Slotting Code Report                                                                                                                                                                                                                                                                                                                    |

@ScenarioId:5979
Scenario: [96172] Data Quality Review for Walmart
	Then I select the: Data Quality Review for Walmart report from Advanced Reporting in SHA
	Then I Check that the Description Text for the Report: Data Quality Review for Walmart is shown as: Output consists of numerous datapoints that will allow internal users to manage the output for their immediate purpose and provide an overview of the Walmart-specific data provided to the retailer as a means of Quality Assurance. The report allow you to filter by product Last publish Date range and is limited to 500 records.
	Then I enter start Date: 08-08-2019 and end Date: 11-14-2019 for the Advanced report then I click Submit
	And I wait for the Advanced Reporting Preparing Report popup to disappear
	Given I confirm that an excel file is produced called Data Quality Review for Walmart.xlsx and save as 96172
	Then I confirm that the excel file saved as: 96172 contains the following columns: and they are in the correct order.
		| Column                                       |
		| WPS ID                                       |
		| Product Name                                 |
		| SHA Status                                   |
		| Supplier Name                                |
		| Supplier Type (eg. Manufacturer/Distributor) |
		| Active or Inactive                           |
		| Last Published Date                          |
		| Last Activity Date                           |
		| CNTXT and ECOMM                              |
		| RU Code                                      |
		| RU Phrase                                    |
		| RUCC Code                                    |
		| RUCC Phrase                                  |
		| WMDRUM                                       |
		| WMBC                                         |
		| WMCAD                                        |
		| WMBCCA                                       |
		| WMBCWA                                       |
		| STSWM                                        |
		| CWWM                                         |
		| WAWN                                         |
		| RIWN                                         |
		| PYSTM                                        |
		| BATT                                         |
		| BATTT                                        |
		| CHEMICAL                                     |
		| KIT                                          |
		| PPHARMA                                      |
		| LBLTYP                                       |
		| DCQAPF                                       |
		| DCQAR                                        |
		| DCQAOR                                       |
		| RSQAPF                                       |
		| DPQAPF                                       |
		| DPQAOR                                       |
		| DPQAORR                                      |
		| PSNDWM                                       |
		| PSNCD                                        |
		| PSNPD                                        |
		| PSNH                                         |
		| PSNP                                         |
		| PSNV                                         |
		| PSNW                                         |
		| BATTWT                                       |
		| BATLIGM                                      |
		| BATCT                                        |
		| CELLNUM                                      |
		| WMPI                                         |
		| NUMB                                         |
		| EMS                                          |
		| UNIFFC                                       |
		| UPC                                          |
		| UPC Name                                     |
		| Slotting Code                                |
		| WMTQA                                        |
		| DOT UN                                       |
		| DOT HazClass                                 |
		| DOT Packing Group                            |
		| Ltd Qty (Y/N)                                |
		| IATA UN                                      |
		| IATA HazClass                                |
		| IATA Packing Group                           |
	Then I delete the Advanced Report file saved as 96172
	Then I Click close in the Advanced Reporting Popup

@ScenarioId:6017
Scenario: [96733] UPC Details for Registration - Specific Retailer
	Given I Use Test case 75142 to create a NEW PRODUCT and get it to Submitted status in SHA
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Then I select the: UPC Details for Registration - Specific Retailer report from Advanced Reporting in SHA
	Then I Check that the Description Text for the Report: UPC Details for Registration - Specific Retailer is shown as: Internal Use Only.  UPCs are listed for a chosen Retailer and include any additional UPC data such as Case Pack, Net Explosive Mass, and other details.
	Then In The advanced reporting screen I enter WPSID saved as: TestCase75142
	Then In The advanced reporting screen I choose retailer: CVS
	Then In the Advanced Reporting popup I click Submit
	And I wait for the Advanced Reporting Preparing Report popup to disappear
	Given I confirm that an excel file is produced called UPC Details for Registration - Specific Retailer.xlsx and save as 96733
	Then I confirm that the excel file saved as: 96733 contains the following columns: and they are in the correct order.
		| Column                         |
		| UPC                            |
		| WPSID                          |
		| Product Name                   |
		| UPC Name                       |
		| Product Status                 |
		| Retailer Name                  |
		| UPC to Retailer                |
		| UPC Status                     |
		| UPC Active Date                |
		| UPC Fed                        |
		| Net Explosive Mass             |
		| SDS Authoring - Container Type |
		| SDS Authoring - UPCASE         |
		| UPDGT                          |
		| PYSTM                          |
		| UPICC                          |
		| UPIQC                          |
		| UPDV                           |
		| UPFV                           |
		| UPDUM                          |
		| UPFUM                          |
		| DOT UN                         |
		| DOT HazClass                   |
		| DOT Packing Group              |
		| Ltd Qty (Y/N)                  |
		| IATA UN                        |
		| IATA HazClass                  |
		| IATA Packing Group             |
	Then I delete the Advanced Report file saved as 96733
	Then I Click close in the Advanced Reporting Popup

@ScenarioId:6016
Scenario: [114727] PM Walmart Monthly WMQC Report
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Then I select the: PM Walmart Monthly WMQC Report report from Advanced Reporting in SHA
	Then I Check that the Description Text for the Report: PM Walmart Monthly WMQC Report is shown as: Walmart Monthly Published WMQC subformat Report
	Then I enter start Date: 08-08-2019 and end Date: 11-14-2019 for the Advanced report then I click Submit
	And I wait for the Advanced Reporting Preparing Report popup to disappear
	#For below step need an actual file to get name etc
	Given I confirm that an excel file is produced called PM Monthly Status Report - Target.xlsx and save as 114727
	#Update Colum headings
	Then I confirm that the excel file saved as: 114727 contains the following columns:
		| Column   |
		| UPC Name |
	Then I delete the Advanced Report file saved as 114727

@ScenarioId:5980
Scenario: [114728] UPCs Added Yesterday
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Then I select the: UPCs Added Yesterday report from Advanced Reporting in SHA
	Then I Check that the Description Text for the Report: UPCs Added Yesterday is shown as: UPCs Added Yesterday
	Then In the Advanced Reporting popup I click Submit
	And I wait for the Advanced Reporting Preparing Report popup to disappear
	#Change to Correct File Name
	Given I confirm that an excel file is produced called UPCs Added Yesterday.xlsx and save as 114728
	#Update Column headings
	Then I confirm that the excel file saved as: 114728 contains the following columns: and they are in the correct order.
		| Column   |
		| UPC Name |
	Then I delete the Advanced Report file saved as 114728

@ScenarioId:5981
Scenario: [114729] VOC Monthly Report - Walmart
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Then I select the: VOC Monthly Report - Walmart report from Advanced Reporting in SHA
	Then I Check that the Description Text for the Report: VOC Monthly Report - Walmart is shown as: Walmart Monthly VOC Report
	Then I enter start Date: 08-08-2019 and end Date: 11-14-2019 for the Advanced report then I click Submit
	And I wait for the Advanced Reporting Preparing Report popup to disappear
	Given I confirm that an excel file is produced called VOC Monthly Report - Walmart.xlsx and save as 114729
	#Update Colum headings
	Then I confirm that the excel file saved as: 114729 contains the following columns:
		| Column   |
		| UPC Name |
	Then I delete the Advanced Report file saved as 114729

@ScenarioId:5982
Scenario: [114731] WalMart DSV Products Report
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Then I select the: WalMart DSV Products Report report from Advanced Reporting in SHA
	Then I Check that the Description Text for the Report: WalMart DSV Products Report is shown as: WalMart DSV Products Report
	Then In the Advanced Reporting popup I click Submit
	And I wait for the Advanced Reporting Preparing Report popup to disappear
	Given I confirm that an excel file is produced called WalMart DSV Products Reportxlsx and save as 114731
	#Update Column headings
	Then I confirm that the excel file saved as: 114731 contains the following columns: and they are in the correct order.
		| Column   |
		| UPC Name |
	Then I delete the Advanced Report file saved as 114731

@ScenarioId:5983
Scenario: [114732] WM Slotting Code Report
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Then I select the: WM Slotting Code Report report from Advanced Reporting in SHA
	Then I Check that the Description Text for the Report: WM Slotting Code Report is shown as: WM Slotting Code Report
	Then I enter start Date: 08-08-2019 and end Date: 11-14-2019 for the Advanced report then I click Submit
	And I wait for the Advanced Reporting Preparing Report popup to disappear
	Given I confirm that an excel file is produced called WM Slotting Code Report.xlsx and save as 114732
	#Update Colum headings
	Then I confirm that the excel file saved as: 114732 contains the following columns: and they are in the correct order.
		| Column   |
		| UPC Name |
	Then I delete the Advanced Report file saved as 114732

@ScenarioId:5973
Scenario: [114733] Advanced Reports - UPC-Level Certifications: Walmart SOW 15
	Then I create a NEW PRODUCT, select all certifications on the UPC screen and get it to Submitted status in SHA
	Then I select the: Data Quality Review for Walmart report from Advanced Reporting in SHA
	Then I Check that the Description Text for the Report: Data Quality Review for Walmart is shown as: Output consists of numerous datapoints that will allow internal users to manage the output for their immediate purpose and provide an overview of the Walmart-specific data provided to the retailer as a means of Quality Assurance. The report allow you to filter by product Last publish Date range and is limited to 500 records.
	Then I enter start Date: 08-08-2019 and end Date: 11-14-2019 for the Advanced report then I click Submit
	And I wait for the Advanced Reporting Preparing Report popup to disappear
	Given I confirm that an excel file is produced called Data Quality Review for Walmart.xlsx and save as 1147331
	#Update the column names below ( for checking Y only include the new headers)
	Then I confirm that the excel file saved as: 1147331 contains the following columns: and they are in the correct order.
		| Column   |
		| UPC Name |
	Then I confirm that the excel file saved as: 1147331 contains the WPSID saved as: TestCase75142 and has a 'Y' in the columns:
		| Column   |
		| UPC Name |
	Then I delete the Advanced Report file saved as 1147331
	Then I select the: UPC Details for Registration - Specific Retailer report from Advanced Reporting in SHA
	Then I Check that the Description Text for the Report: UPC Details for Registration - Specific Retailer is shown as: Internal Use Only.  UPCs are listed for a chosen Retailer and include any additional UPC data such as Case Pack, Net Explosive Mass, and other details.
	Then In The advanced reporting screen I enter WPSID saved as: TestCase75142
	Then In The advanced reporting screen I choose retailer: Wal-Mart/SAM'S CLUB
	Then In the Advanced Reporting popup I click Submit
	And I wait for the Advanced Reporting Preparing Report popup to disappear
	Given I confirm that an excel file is produced called UPC Details for Registration - Specific Retailer.xlsx and save as 1147332
	#Update Column headings
	Then I confirm that the excel file saved as: 1147332 contains the following columns: and they are in the correct order.
		| Column   |
		| UPC Name |
	Then I confirm that the excel file saved as: 1147332 contains the WPSID saved as: TestCase75142 and has a 'Y' in the columns:
		| Column   |
		| UPC Name |
	Then I delete the Advanced Report file saved as 1147332
	Then I select the: WalMart DSV Products Report report from Advanced Reporting in SHA
	Then I Check that the Description Text for the Report: WalMart DSV Products Report is shown as: WalMart DSV Products Report
	Then In the Advanced Reporting popup I click Submit
	And I wait for the Advanced Reporting Preparing Report popup to disappear
	Given I confirm that an excel file is produced called WalMart DSV Products Report.xlsx and save as 1147333
	#Update Column headings
	Then I confirm that the excel file saved as: 1147333 contains the following columns: and they are in the correct order.
		| Column   |
		| UPC Name |
	Then I confirm that the excel file saved as: 1147333 contains the WPSID saved as: TestCase75142 and has a 'Y' in the columns:
		| Column   |
		| UPC Name |
	Then I delete the Advanced Report file saved as 1147333
	Then I select the: WM Slotting Code Report report from Advanced Reporting in SHA
	Then I Check that the Description Text for the Report: WM Slotting Code Report is shown as: WM Slotting Code Report
	Then I enter start Date: 08-08-2019 and end Date: 11-14-2019 for the Advanced report then I click Submit
	And I wait for the Advanced Reporting Preparing Report popup to disappear
	Given I confirm that an excel file is produced called WM Slotting Code Report.xlsx and save as 1147334
	#Update Colum headings
	Then I confirm that the excel file saved as: 1147334 contains the following columns:
		| Column   |
		| UPC Name |
	Then I confirm that the excel file saved as: 1147334 contains the WPSID saved as: TestCase75142 and has a 'Y' in the columns:
		| Column   |
		| UPC Name |
	Then I delete the Advanced Report file saved as 1147334

@ScenarioId:6019
Scenario: [115163] Daily Report - Data Tier Consent - Includes Updated CVS Requirments
	Given I Use Test case 75142 to create a NEW PRODUCT and get it to Submitted status in SHA
	Then I select the: Daily Report - Data Tier Consent report from Advanced Reporting in SHA
	Then In the Advanced Reporting popup I click Submit
	And I wait for the Advanced Reporting Preparing Report popup to disappear
	Given I confirm that an excel file is produced called Daily Report - Data Tier Consent.xlsx and save as 115163
	#Update Column headings
	Then I confirm that the excel file saved as: 115163 contains the following columns:
		| Column   |
		| UPC Name |
	Then I confirm that the excel file saved as: 115163 contains CVS products with tiers 2.1, 2.2 and 4.1 granted
	Then I delete the Advanced Report file saved as 115163

@ScenarioId:5978
Scenario: [98534] Advanced Reporting - Registrations Published report -
	#Update 98534 in TFS
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Then I select the: Product Registrations Published report from Advanced Reporting in SHA
	Then I Check that the Description Text for the Report: Product Registrations Published is shown as: Assessed Registrations Published for Transfer and Completion to Retailers within a Date Range
	Then I enter start Date: 08-08-2019 and end Date: 11-14-2019 for the Advanced report then I click Submit
	And I wait for the Advanced Reporting Preparing Report popup to disappear
	Given I confirm that an excel file is produced called Product Registrations Published.xlsx and save as 98534
	Then I confirm that the excel file saved as: 98534 contains the following columns:
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
		| ALL                 |
		| BATYPE              |
		| LBAT                |
		| BATTPACK            |
		| BATTWT              |
		| BATTLIGM            |
		| BATCT               |
		| CELLNUM             |
		| BATTNUM             |
		| NUMB                |
	Then I delete the Advanced Report file saved as 98534

@ScenarioId:5947
Scenario:[113004] UPC Data Expansion: Transportation and Name: My Reports: UPC Error Details
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	And I click the Supplier Reports icon in the QuickLinks Pane
	Then Under the Supplier Reports menu I choose: UPC Error Details
	# Sprint 1 - 1506182, Sprint 2 - 1505712, QA - 1520299, Staging - 1593242, TReVor var request sent
	Then in UPC Error Details WPSID box I enter product ID for the UPC Error Details report
	Then In the Supplier Reports screen I click on the Download button
	Then I wait for 3 seconds
	Then I confirm that an excel file is produced called UPC Error Details.xlsx and save as 113004
	Then I confirm that sheet named Table in the exported excel file saved as: 113004 contains the following columns:
		| Column                       |
		| WPSID                        |
		| Product Name                 |
		| Individual UPC               |
		| Case-Pack UPC                |
		| UPC Name                     |
		| Not Completed OMSID's        |
		| Green Good Housekeeping      |
		| Green Seal                   |
		| EPA Safer Choice             |
		| Cradle To Cradle             |
		| UL EcoLogo                   |
		| EWG Verified                 |
		| Green Tick                   |
		| Made Safe                    |
		| NSF Sustainability Certified |
	Then I delete the excel file saved as 113004

@ScenarioId:5958
Scenario:[113706] UPC Data Expansion: UPC Name Required on new product registration
	Given I generate a random UPC number and save as: UPC113706
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I delete all products with UPC Number: saved as UPC113706
	Then I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
	Then I save the product information as: Product113706
	And I call Shared Step 26897 (Product Characteristics - Solid only available - continue)
	And I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	And I add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Chalk         | 80.5    | false               | false       |            |
		| Water         | 15      | false               | false       |            |
		| RED           | 5.0     | false               | false       |            |
		| Clothianidin  | 25.0    | false               | false       |            |
	Then in the Ingredients page I click Continue
	Then I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Then In the 'Select Retailers' window I select the retailer: Target
	Then in the Retailer page I click Continue
	And I should see the Universal Product Code (UPC) Page
	Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC113706, container type: Cardboard and size: 5
	And I enter 123-44-5555 in the DPCI field of the UPC page
	And in the UPC page I click Continue
	And I should see an error message on the Product Name on Label field which reads: Error
	And I should see the following error text displayed in the UPC screen: Please fix UPC errors
	Then I click the Home navigation icon
	Given I delete all products with UPC Number: saved as UPC113706

@ScenarioId:5971
Scenario:[114216] TR (Transparency Value) - Display as Percentage
	Given I generate a random UPC number and save as: UPC113706
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I delete all products with UPC Number: saved as UPC113706
	Then I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
	Then I save the product information as: Product113706
	And I call Shared Step 26897 (Product Characteristics - Solid only available - continue)
	And I call Shared Step 85284 - Additional Product Information - US & Canada, Child (No), OSHA (No), DSV (No), PLP (YES), GNFR (No), Continue
	And I add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Chalk         | 20      | false               | false       |            |
		| Water         | 15      | false               | false       |            |
		| RED           | 5.0     | false               | false       |            |
		| Clothianidin  | 25.0    | false               | false       |            |
	Then I click the Publicly Disclosed checkbox for ingredient: Chalk
	And I verify the Transparency Score displays 25%
	Then I click the Publicly Disclosed checkbox for ingredient: Water
	And I verify the Transparency Score displays 50%
	Then I click the Publicly Disclosed checkbox for ingredient: RED 4
	And I verify the Transparency Score displays 75%
	Then I click the Publicly Disclosed checkbox for ingredient: Clothianidin
	And I verify the Transparency Score displays 100%
	Then I add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| CLOTURIN      | 20      | false               | false       |            |
	And I verify the Transparency Score displays 80%
	Then I add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Dosulepin     | 20      | true                | false       | Dosulepin  |
	And I verify the Transparency Score displays 83.33%
	Then in the Ingredients page I click Continue
	And for ingredient: Chalk I should see an error below the public name column which reads: Please select Public Name since you agreed on Publicly Disclosed
	And for ingredient: Water I should see an error below the public name column which reads: Please select Public Name since you agreed on Publicly Disclosed
	And for ingredient: RED 4 I should see an error below the public name column which reads: Please select Public Name since you agreed on Publicly Disclosed
	And for ingredient: Clothianidin I should see an error below the public name column which reads: Please select Public Name since you agreed on Publicly Disclosed
	And I select the first Public Name dropdown option for ingredient: Chalk
	And I select the first Public Name dropdown option for ingredient: Water
	And I select the first Public Name dropdown option for ingredient: RED 4
	And I select the first Public Name dropdown option for ingredient: Clothianidin
	Then in the Ingredients page I click Continue
	Then I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: Product113706
