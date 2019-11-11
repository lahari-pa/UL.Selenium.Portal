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
@UPC
@SHA
@FileOps
@ForwardProductRegistration
@ProductSetUp
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
	Given I enter the following into the comments field: comments
	And The remaining characters counter displays: 492/500
	Then I enter the following into the comments field: comments
	And The remaining characters counter displays: 486/500
	And I enter the following into the comments field: comments
	And The remaining characters counter displays: 478/500
	And I enter the following into the comments field: comments
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
		| BPC Sustainability Survey Eligibility – H & B                        | BPC Sustainability Survey Eligibility – Health & Beauty                                                                                                                                                                                                                                                                                    |
		| CA Prop 65 by Retailer                                               | Query all Active/Completed UPC’s associated to the selected retailer under the selected upc date range where header data code P65ONE has: P65ONE01 Value = 1 (Yes), or P65ONE02 Value = 2 (No)                                                                                                                                             |
		| Canadian Tire Stewardship – My Account                               | Canadian Tire Stewardship – My Account                                                                                                                                                                                                                                                                                                     |
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
