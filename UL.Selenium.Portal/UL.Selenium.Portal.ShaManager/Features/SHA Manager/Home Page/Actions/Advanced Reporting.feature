@Shared
@LandingPage
@Login
@SHA
@Homepage
@Signup
@wercsmart
@NewProduct
@ProductGrid
@DataSummarySheet
@RetailPartners
@SummaryPage
@SupplierReports
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
@Portal_ShaManager
@run_Advanced_Reporting
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:NewProduct
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:TheProduct
@StepsPrototype
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:Retailer
@RegulatoryInformation3

Feature: Advanced Reporting

@ScenarioId:1513
Scenario: [105329] PM Monthly Status Report - Target
	Given I generate a random UPC number and save as: UPC105329
	#Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I log in with the account saved in TReVor as: ProductAccount
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Given in the New Product page I click Continue


	#Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Shampoo (Liquid)
	Then I should be on the The Product Page
	And In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Shampoo (Liquid)_#105329
	And In the Product Section, set the option in section: 'Type of Product (select)' to: Shampoo (Liquid)
	Then in the The Product page, I click Continue

	Then I save the product information as: TestCase105329
	And I call Shared Step 62678 (Product Information - US & Canada, No Child, No OSHA, NO Direct ship, No PL, No NGFR - Continue, Happy path)
	And I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
	And I call Shared Step 29181 (Ingredients - add any chemical) with name: Chlorine
	And I call Shared Step 57637 (Regulatory Information 1 - TSCA & CEPA shown, No to PROP 65 - Continue - Happy Path)
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
	And I call Shared Step 57506 (Transportation Details 1 - Regulated for Transport(No) - Exemption(Random) - Continue - Happy Path)
	And I call Shared Step 62536 (Transportation Details 2 > I do not ship internationally > Continue - Happy Path)
#	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Target
	Then I should be on the Retailer Page
	And In the Retailer Section, click 'Add Retailers' button
	And In the Select Retailers window, select retailer: Target
	And In the Select Retailers window, click 'Done' button
	Then in the Retailer page, I click Continue

	Given I call Shared Step 87647 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC105329, container type: Plastic Container and size: 2 do not click continue
	And In the Destination Retailers input field I input the value: 123-11-1234,125-22-1254,123-33-2589
	And I click continue
	And I call Shared Step 65080 (Login to Studio and Open SHA manager)
	And I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase105329)
	Given I call Shared Step 96169 - SHA Manager - Select Product - Actions - Advanced Reporting for saved as: TestCase105329
	Given In the Advanced Reporting popup I select report PM Monthly Status Report - Target
	And In the Advanced Reporting popup I click Submit
	And I wait for the Advanced Reporting Preparing Report popup to disappear
	Given I confirm that an excel file is produced called PM Monthly Status Report - Target.xls and save as 105329
	Then I confirm that the excel file saved as: 105329 contains the following columns:
		| Column                |
		| WPSID                 |
		| UPC                   |
		| DPCI                  |
		| Product Name          |
		| UPC Name              |
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
	Then I delete the excel file saved as 96226

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
	Then I delete the excel file saved as 96174

@ignore
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
@ignore
@tfs_design
@ScenarioId:5974
Scenario: [87182] 3rd Party Formula Use in Registrations
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Given in the New Product page I click Continue
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk
	Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
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

@ScenarioId:5979
Scenario: [96172] Data Quality Review for Walmart
	#Given I create a Walmart product and take to completed using Test Case 75335 (SOLD set to US only with Walmart as retailer) and save as: 77862_KitProduct2
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Then I select the: Data Quality Review for Walmart report from Advanced Reporting in SHA
	Then I Check that the Description Text for the Report: Data Quality Review for Walmart is shown as: Output consists of numerous datapoints that will allow internal users to manage the output for their immediate purpose and provide an overview of the Walmart-specific data provided to the retailer as a means of Quality Assurance. The report allow you to filter by product Last publish Date range and is limited to 500 records.
	Then I enter start Date: 11-01-2019 and end Date: 11-14-2019 for the Advanced report then I click Submit
	And I wait for the Advanced Reporting Preparing Report popup to disappear
	Given I confirm that an excel file is produced called Data Quality Review for Walmart.xls and save as 96172
	Then I confirm that the excel file saved as: 96172 contains the following columns: and they are in the correct order.
		| Column                                       |
		| WPS ID                                       |
		| Product Name                                 |
		| SHA Status                                   |
		| Supplier Name                                |
		| Supplier Type (eg. Manufacturer/Distributor) |
		| Subscription                                 |
		| Last Published Date                          |
		| Last Activity Date                           |
		| RECERT Status                                |
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
		| EPWM                                         |
		| ARSOL                                        |
		| NFPAH                                        |
		| NFPAF                                        |
		| NFPAI                                        |
		| NFPAP                                        |
		| NFPAG                                        |
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
		| Green Good Housekeeping                      |
		| Green Seal                                   |
		| EPA Safer Choice                             |
		| Cradle To Cradle                             |
		| UL EcoLogo                                   |
		| EWG Verified                                 |
		| Green Tick                                   |
		| Made Safe                                    |
		| NSF Sustainability Certified                 |
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
	Given I confirm that an excel file is produced called UPC Details for Registration - Specific Retailer.xls and save as 96733
	Then I confirm that the excel file saved as: 96733 contains the following columns:
		| Column                       |
		| UPC                          |
		| WPSID                        |
		| Product Name                 |
		| UPC Name                     |
		| Product Status               |
		| Retailer Name                |
		| UPC to Retailer              |
		| UPC Status                   |
		| UPC Active Date              |
		| UPC Fed                      |
		| Net Explosive Mass           |
		| Container Type               |
		| UPCASE                       |
		| UPDGC                        |
		| UPDGT                        |
		| PYSTM                        |
		| UPICC                        |
		| UPIQC                        |
		| UPDV                         |
		| UPFV                         |
		| UPDUM                        |
		| UPFUM                        |
		| Green Good Housekeeping      |
		| Green Seal                   |
		| EPA Safer Choice             |
		| Cradle To Cradle             |
		| UL EcoLogo                   |
		| EWG Verified                 |
		| Green Tick                   |
		| Made Safe                    |
		| NSF Sustainability Certified |
		| DOT UN                       |
		| DOT HazClass                 |
		| DOT Packing Group            |
		| Ltd Qty (Y/N)                |
		| IATA UN                      |
		| IATA HazClass                |
		| IATA Packing Group           |
	Then I delete the Advanced Report file saved as 96733
	Then I Click close in the Advanced Reporting Popup

@ScenarioId:6016
Scenario: [114727] PM Walmart Monthly WMQC Report
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Then I select the: PM Walmart Monthly WMQC Report report from Advanced Reporting in SHA
	Then I Check that the Description Text for the Report: PM Walmart Monthly WMQC Report is shown as: Walmart Monthly Published WMQC subformat Report
	Then I enter start Date: 01-01-2019 and end Date: Future for the Advanced report then I click Submit
	And I wait for the Advanced Reporting Preparing Report popup to disappear
	Given I confirm that an excel file is produced called PM Walmart Monthly WMQC Report.xls and save as 114727
	#Update Colum headings
	Then I confirm that the excel file saved as: 114727 contains the following columns:
		| Column          |
		| WPS_ID          |
		| UPC             |
		| Product Name    |
		| UPC Name        |
		| Status          |
		| Supplier Name   |
		| Retailer        |
		| Recommended Use |
		| WMQC2           |
		| WMQC3           |
		| WMQC5           |
		| WMQC7           |
		| WMQC8D          |
		| WMQC9D          |
		| WMQC4           |
		| WMQC6           |
		| WMQC8           |
		| WMQC9           |
		| WMQC13          |
		| WMCK            |
		| WMQC10          |
		| WMQC11          |
		| WMQC14          |
		| INITSUB         |
	Then I delete the Advanced Report file saved as 114727

@ScenarioId:5980
Scenario: [114728] UPCs Added Yesterday
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Then I select the: UPCs Added Yesterday report from Advanced Reporting in SHA
	Then I Check that the Description Text for the Report: UPCs Added Yesterday is shown as: UPCs Added Yesterday
	Then In the Advanced Reporting popup I click Submit
	And I wait for the Advanced Reporting Preparing Report popup to disappear
	Given I confirm that an excel file is produced called UPCs Added Yesterday.xls and save as 114728
	Then I confirm that the excel file saved as: 114728 contains the following columns: and they are in the correct order.
		| Column              |
		| WPSID               |
		| UPC                 |
		| UPC Name            |
		| Packaging Type      |
		| Packaging Size      |
		| Product Name        |
		| Supplier            |
		| Status              |
		| Last Date Published |
		| Published By        |
		| DOTUN               |
		| DOTPG               |
		| IATAUN              |
		| IATAPG              |
		| IATAQ               |
		| UNM                 |
		| PGM                 |
		| MODELQ              |
		| MODECC              |
	Then I delete the Advanced Report file saved as 114728

@ScenarioId:5981
Scenario: [114729] VOC Monthly Report - Walmart
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Then I select the: VOC Monthly Report - Walmart report from Advanced Reporting in SHA
	Then I Check that the Description Text for the Report: VOC Monthly Report - Walmart is shown as: Walmart Monthly VOC Report
	Then I enter start Date: 09-01-2019 and end Date: NA for the Advanced report then I click Submit
	And I wait for the Advanced Reporting Preparing Report popup to disappear
	Given I confirm that an excel file is produced called VOC Monthly Report - Walmart.xls and save as 114729
	#Then I confirm that the excel file saved as: 114729 includes the column: UPC Name between: Product Name and UPC
	Then I confirm that the excel file saved as: 114729 contains the following columns: and they are in the correct order.
		| Column       |
		| WPS ID       |
		| Product Name |
		| UPC Name     |
		| UPC          |
		| Supplier     |
		| Email        |
		| Package Size |
		| Package Type |
		| RU           |
		| SCAQWM       |
		| F_SCAQMSG    |
		| CARBWM       |
		| F_CARBMSG    |
		| OTCWM        |
		| F_OTCMSG     |
		| F_AEROWM     |
		| F_AEROMSG    |
		| F_VOCLN      |
		| F_VOCIN      |
		| F_VOCOTC     |
		| F_VOCCARB    |
		| F_VOCAERO    |
		| VCNWM        |
		| VADEWM       |
		| VAMDWM       |
		| VAZMCWM      |
		| VCTWM        |
		| VDCWM        |
		| VDEWM        |
		| VILWM        |
		| VINWM        |
		| VMAWM        |
		| VMDWM        |
		| VMEWM        |
		| VMIWM        |
		| VNHWM        |
		| VNJWM        |
		| VNYWM        |
		| VOHWM        |
		| VPAWM        |
		| VRIWM        |
		| VTXWM        |
		| VUTWM        |
		| VVAWM        |
		| VVTWN        |
	Then I delete the Advanced Report file saved as 114729

@ScenarioId:5982
Scenario: [114731] WalMart DSV Products Report
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Then I select the: WalMart DSV Products Report report from Advanced Reporting in SHA
	Then I Check that the Description Text for the Report: WalMart DSV Products Report is shown as: WalMart DSV Products Report
	Then In the Advanced Reporting popup I click Submit
	And I wait for the Advanced Reporting Preparing Report popup to disappear
	Given I confirm that an excel file is produced called WalMart DSV Products Report.xls and save as 114731
	Then I confirm that the excel file saved as: 114731 contains the following columns:
		| Column                       |
		| WPSID                        |
		| UPC                          |
		| Product Name                 |
		| UPC Name                     |
		| Supplier                     |
		| Contact Name                 |
		| Contact E-Mail               |
		| Contact Phone                |
		| City                         |
		| State                        |
		| Country                      |
		| Formulated                   |
		| Retailer Status              |
		| Last Activity Date           |
		| Last Published Date          |
		| Last Submitted Date          |
		| Green Good Housekeeping      |
		| Green Seal                   |
		| EPA Safer Choice             |
		| Cradle To Cradle             |
		| UL EcoLogo                   |
		| EWG Verified                 |
		| Green Tick                   |
		| Made Safe                    |
		| NSF Sustainability Certified |
	Then I delete the Advanced Report file saved as 114731

@ScenarioId:5983
Scenario: [114732] WM Slotting Code Report
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Then I select the: WM Slotting Code Report report from Advanced Reporting in SHA
	Then I Check that the Description Text for the Report: WM Slotting Code Report is shown as: WM Slotting Code Report
	Then I enter start Date: 09-01-2019 and end Date: NA for the Advanced report then I click Submit
	And I wait for the Advanced Reporting Preparing Report popup to disappear
	Given I confirm that an excel file is produced called WM Slotting Code Report.xls and save as 114732
	Then I confirm that the excel file saved as: 114732 contains the following columns: and they are in the correct order.
		| Column                       |
		| F_PRODUCT                    |
		| F_NAME                       |
		| F_UPC                        |
		| UPC Name                     |
		| Supplier                     |
		| Vendor ID                    |
		| Packaging Size               |
		| Packaging Type               |
		| UNIFFC                       |
		| Slotting Code                |
		| FPF                          |
		| Total Alcohol Content        |
		| SGB                          |
		| Total Water Content          |
		| WS                           |
		| RU Name                      |
		| RUCC Name                    |
		| Green Good Housekeeping      |
		| Green Seal                   |
		| EPA Safer Choice             |
		| Cradle To Cradle             |
		| UL EcoLogo                   |
		| EWG Verified                 |
		| Green Tick                   |
		| Made Safe                    |
		| NSF Sustainability Certified |
	Then I delete the Advanced Report file saved as 114732

@ScenarioId:5973
Scenario: [114733] Advanced Reports - UPC-Level Certifications: Walmart SOW 15
	Then I create a NEW PRODUCT, select all certifications on the UPC screen and get it to Submitted status in SHA
	#Then I create a NEW PRODUCT, select all certifications on the UPC screen and get it to Completed status in SHA
	Then I select the: Data Quality Review for Walmart report from Advanced Reporting in SHA
	Then I Check that the Description Text for the Report: Data Quality Review for Walmart is shown as: Output consists of numerous datapoints that will allow internal users to manage the output for their immediate purpose and provide an overview of the Walmart-specific data provided to the retailer as a means of Quality Assurance. The report allow you to filter by product Last publish Date range and is limited to 500 records.
	Then I enter start Date: 08-08-2019 and end Date: 11-14-2019 for the Advanced report then I click Submit
	And I wait for the Advanced Reporting Preparing Report popup to disappear
	Given I confirm that an excel file is produced called Data Quality Review for Walmart.xls and save as 1147331
	Then I confirm that the excel file saved as: 1147331 includes the following columns:
		| Column                       |
		| Cradle To Cradle             |
		| UL EcoLogo                   |
		| EWG Verified                 |
		| Green Tick                   |
		| Green Seal                   |
		| Green Good Housekeeping      |
		| EPA Safer Choice             |
		| Made Safe                    |
		| NSF Sustainability Certified |
	Then I confirm that the excel file saved as: 1147331 contains the WPSID saved as: TestCase75142 and has a 'Y' in the columns:
		| Column                       |
		| Cradle To Cradle             |
		| UL EcoLogo                   |
		| EWG Verified                 |
		| Green Tick                   |
		| Green Seal                   |
		| Green Good Housekeeping      |
		| EPA Safer Choice             |
		| Made Safe                    |
		| NSF Sustainability Certified |
	Then I delete the Advanced Report file saved as 1147331
	Then I select the: UPC Details for Registration - Specific Retailer report from Advanced Reporting in SHA
	Then I Check that the Description Text for the Report: UPC Details for Registration - Specific Retailer is shown as: Internal Use Only.  UPCs are listed for a chosen Retailer and include any additional UPC data such as Case Pack, Net Explosive Mass, and other details.
	Then In The advanced reporting screen I enter WPSID saved as: TestCase75142
	Then In The advanced reporting screen I choose retailer: Wal-Mart/SAM'S CLUB
	Then In the Advanced Reporting popup I click Submit
	And I wait for the Advanced Reporting Preparing Report popup to disappear
	Given I confirm that an excel file is produced called UPC Details for Registration - Specific Retailer.xlsx and save as 1147332
	Then I confirm that the excel file saved as: 1147332 includes the following columns:
		| Column                       |
		| Cradle To Cradle             |
		| UL EcoLogo                   |
		| EWG Verified                 |
		| Green Tick                   |
		| Green Seal                   |
		| Green Good Housekeeping      |
		| EPA Safer Choice             |
		| Made Safe                    |
		| NSF Sustainability Certified |
	Then I confirm that the excel file saved as: 1147332 contains the WPSID saved as: TestCase75142 and has a 'Y' in the columns:
		| Column                       |
		| Cradle To Cradle             |
		| UL EcoLogo                   |
		| EWG Verified                 |
		| Green Tick                   |
		| Green Seal                   |
		| Green Good Housekeeping      |
		| EPA Safer Choice             |
		| Made Safe                    |
		| NSF Sustainability Certified |
	Then I delete the Advanced Report file saved as 1147332
	Then I move the product saved as 1147332 from Submitted to Completed Status
	Then I select the: WalMart DSV Products Report report from Advanced Reporting in SHA
	Then I Check that the Description Text for the Report: WalMart DSV Products Report is shown as: WalMart DSV Products Report
	Then In the Advanced Reporting popup I click Submit
	And I wait for the Advanced Reporting Preparing Report popup to disappear
	Given I confirm that an excel file is produced called WalMart DSV Products Report.xlsx and save as 1147333
	Then I confirm that the excel file saved as: 1147333 includes the following columns:
		| Column                       |
		| Cradle To Cradle             |
		| UL EcoLogo                   |
		| EWG Verified                 |
		| Green Tick                   |
		| Green Seal                   |
		| Green Good Housekeeping      |
		| EPA Safer Choice             |
		| Made Safe                    |
		| NSF Sustainability Certified |
	Then I confirm that the excel file saved as: 1147333 contains the WPSID saved as: TestCase75142 and has a 'Y' in the columns:
		| Column                       |
		| Cradle To Cradle             |
		| UL EcoLogo                   |
		| EWG Verified                 |
		| Green Tick                   |
		| Green Seal                   |
		| Green Good Housekeeping      |
		| EPA Safer Choice             |
		| Made Safe                    |
		| NSF Sustainability Certified |
	Then I delete the Advanced Report file saved as 1147333
	Then I select the: WM Slotting Code Report report from Advanced Reporting in SHA
	Then I Check that the Description Text for the Report: WM Slotting Code Report is shown as: WM Slotting Code Report
	Then I enter start Date: 08-08-2019 and end Date: 11-14-2019 for the Advanced report then I click Submit
	And I wait for the Advanced Reporting Preparing Report popup to disappear
	Given I confirm that an excel file is produced called WM Slotting Code Report.xlsx and save as 1147334
	Then I confirm that the excel file saved as: 1147334 includes the following columns:
		| Column                       |
		| Cradle To Cradle             |
		| UL EcoLogo                   |
		| EWG Verified                 |
		| Green Tick                   |
		| Green Seal                   |
		| Green Good Housekeeping      |
		| EPA Safer Choice             |
		| Made Safe                    |
		| NSF Sustainability Certified |
	Then I confirm that the excel file saved as: 1147334 contains the WPSID saved as: TestCase75142 and has a 'Y' in the columns:
		| Column                       |
		| Cradle To Cradle             |
		| UL EcoLogo                   |
		| EWG Verified                 |
		| Green Tick                   |
		| Green Seal                   |
		| Green Good Housekeeping      |
		| EPA Safer Choice             |
		| Made Safe                    |
		| NSF Sustainability Certified |
	Then I delete the Advanced Report file saved as 1147334

@ScenarioId:6019
Scenario: [115163] Daily Report - Data Tier Consent - Includes Updated CVS Requirments
	Given I Use Test case 75142 to create a NEW PRODUCT and get it to Submitted status in SHA
	Then I select the: Daily Report - Data Tier Consent report from Advanced Reporting in SHA
	Then In the Advanced Reporting popup I click Submit
	And I wait for the Advanced Reporting Preparing Report popup to disappear
	Given I confirm that an excel file is produced called Daily Report - Data Tier Consent.xls and save as 115163
	Then I confirm that the excel file saved as: 115163 contains the following columns:
		| Column            |
		| Client            |
		| Eligible Accounts |
		| 1 Granted         |
		| 2.1 Granted       |
		| 2.2 Granted       |
		| 3 Granted         |
		| 4.1 Granted       |
		| 4.2 Granted       |
		| Revoked           |
		| No Action         |
	Then I confirm that the excel file saved as: 115163 contains CVS products with tiers 2.1, 2.2, 3 and 4.1 granted
	Then I delete the Advanced Report file saved as 115163

@ScenarioId:5978
Scenario: [98534] Advanced Reporting - Registrations Published report -
	#Update 98534 in TFS
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Then I select the: Product Registrations Published report from Advanced Reporting in SHA
	Then I Check that the Description Text for the Report: Product Registrations Published is shown as: Assessed Registrations Published for Transfer and Completion to Retailers within a Date Range
	Then I enter start Date: 11-01-2019 and end Date: NA for the Advanced report then I click Submit
	And I wait for the Advanced Reporting Preparing Report popup to disappear
	Given I confirm that an excel file is produced called Product Registrations Published.xls and save as 98534
	Then I confirm that the excel file saved as: 98534 contains the following columns:
		| Column                |
		| WPSID                 |
		| Product Name          |
		| WMDRUM                |
		| WMCAD                 |
		| WMBC                  |
		| PYST                  |
		| PYSTM                 |
		| FPF                   |
		| PH                    |
		| RU                    |
		| EPAN                  |
		| CAWC                  |
		| WSWC                  |
		| UNM                   |
		| HCM                   |
		| PSNDWM                |
		| HCDWM                 |
		| DVID                  |
		| PSNV                  |
		| HCW                   |
		| UNIFFC                |
		| BATT                  |
		| BATTT                 |
		| CHEMICAL              |
		| KIT                   |
		| OTC                   |
		| TGWAST                |
		| MPIND                 |
		| DOTPG                 |
		| DERGN                 |
		| INTFC                 |
		| CASEC                 |
		| CASECD                |
		| DOTBMP                |
		| IMDGBMP               |
		| CATEST                |
		| WATEST                |
		| CNTXT                 |
		| Last Published Date   |
		| Published By          |
		| Total Water Content   |
		| Total Alcohol Content |
		| RCRA                  |
		| RCRAEX                |
		| Max UPC Size          |
		| Recert                |
		| Product_status        |
		| GHS                   |
		| ALL                   |
		| BATYPE                |
		| LBAT                  |
		| BATTPACK              |
		| BATTWT                |
		| BATTLIGM              |
		| BATCT                 |
		| CELLNUM               |
		| BATTNUM               |
		| NUMB                  |
	Then I delete the Advanced Report file saved as 98534

@ScenarioId:6039
Scenario: [115446] Products Fed to Retailers
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Then I select the: Products Fed to Retailers report from Advanced Reporting in SHA
	Then I Check that the Description Text for the Report: Products Fed to Retailers is shown as: Internal Use Only.  Products that successfully transferred registration assessment information to Retailers with an outline of the data provided.  Users can select specific retailers and a date range to generate the report.  Further filtering of data output can be done via UPC sizes, percentage of water and/or alcohol.
	Then In The advanced reporting screen I choose WERCSmart Retail Recipient Code: WM
	Then I enter start Date: 07-01-2019 and end Date: NA for the Advanced report then I click Submit
	And I wait for the Advanced Reporting Preparing Report popup to disappear
	Given I confirm that an excel file is produced called Products Fed to Retailers.xls and save as 115446
	Then I confirm that the excel file saved as: 115446 contains the following columns:
		| Column              |
		| WPSID               |
		| Product Name        |
		| F_UPC               |
		| UPC Size            |
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
		| ALL                 |
		| BATYPE              |
		| LBAT                |
		| BATTPACK            |
		| BATTLIGM            |
		| BATCT               |
		| CELLNUM             |
		| BATTNUM             |
		| NUMB                |
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
		| CT 2.1              |
		| CT 2.2              |
		| CO 2.1              |
		| CO 2.2              |
		| CV 2.1              |
		| CV 2.2              |
		| CV 3                |
		| DT 2.1              |
		| DT 2.2              |
		| RA 2.1              |
		| RA 2.2              |
		| RA 3                |
		| TG 2.1              |
		| TG 2.2              |
		| TG 3                |
		| TG 4.1              |
		| WM 2.1              |
		| WM 2.2              |
		| WM 4.2              |
		| Water %             |
		| Alcohol %           |
	Then I delete the Advanced Report file saved as 115446

@ScenarioId:6048
Scenario: [116340] Products Fed to Retailers - Filters
	#will need to create a product first? May have issues in automation, ask Ammanda
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Then I select the: Products Fed to Retailers report from Advanced Reporting in SHA
	Then I Check that the Description Text for the Report: Products Fed to Retailers is shown as: Internal Use Only.  Products that successfully transferred registration assessment information to Retailers with an outline of the data provided.  Users can select specific retailers and a date range to generate the report.  Further filtering of data output can be done via UPC sizes, percentage of water and/or alcohol.
	Then In The advanced reporting screen I Click Option: Includes Water
	Then In The advanced reporting screen I choose WERCSmart Retail Recipient Code: WM
	Then I enter start Date: 07-01-2019 and end Date: NA for the Advanced report then I click Submit
	And I wait for the Advanced Reporting Preparing Report popup to disappear
	Given I confirm that an excel file is produced called Products Fed to Retailers.xls and save as 116340
	Then For the excel file saved as: 116340 I check that the column with heading name: Water % does not contains: 0 in any rows.
	Then I delete the Advanced Report file saved as 116340
	Then I select the: Products Fed to Retailers report from Advanced Reporting in SHA
	Then In The advanced reporting screen I Click Option: Contains Alcohol
	Then In The advanced reporting screen I choose WERCSmart Retail Recipient Code: WM
	Then I enter start Date: 07-01-2019 and end Date: NA for the Advanced report then I click Submit
	And I wait for the Advanced Reporting Preparing Report popup to disappear
	Given I confirm that an excel file is produced called Products Fed to Retailers.xls and save as 116340
	Then For the excel file saved as: 116340 I check that the column with heading name: Alcohol % does not contains: 0 in any rows.
	Then I delete the Advanced Report file saved as 116340
	Then I select the: Products Fed to Retailers report from Advanced Reporting in SHA
	Then I enter UPC Size: 1 in the advanced reporting popup
	Then In The advanced reporting screen I choose WERCSmart Retail Recipient Code: WM
	Then I enter start Date: 07-01-2019 and end Date: NA for the Advanced report then I click Submit
	And I wait for the Advanced Reporting Preparing Report popup to disappear
	Given I confirm that an excel file is produced called Products Fed to Retailers.xls and save as 116340
	Then For the excel file saved as: 116340 I check that the column with heading name: UPC Size only contains: 1 in all rows.
	Then I delete the Advanced Report file saved as 116340
	Then I select the: Products Fed to Retailers report from Advanced Reporting in SHA
	Then In The advanced reporting screen I Click Option: Includes Water
	Then In The advanced reporting screen I Click Option: Contains Alcohol
	Then I enter UPC Size: 1 in the advanced reporting popup
	Then In The advanced reporting screen I choose WERCSmart Retail Recipient Code: WM
	Then I enter start Date: 07-01-2019 and end Date: NA for the Advanced report then I click Submit
	And I wait for the Advanced Reporting Preparing Report popup to disappear
	Then For the excel file saved as: 116340 I check that the column with heading name: Water % does not contains: 0 in any rows.
	Then For the excel file saved as: 116340 I check that the column with heading name: Alcohol % does not contains: 0 in any rows.
	Then For the excel file saved as: 116340 I check that the column with heading name: UPC Size only contains: 1 in all rows.
	Then I delete the Advanced Report file saved as 116340

@ScenarioId:5958
Scenario:[113706] UPC Data Expansion: UPC Name Required on new product registration
	Given I generate a random UPC number and save as: UPC113706
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I delete all products with UPC Number: saved as UPC113706
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Given in the New Product page I click Continue
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
	Then I save the product information as: Product113706
	And I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	And I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
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
	And I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page
	Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC113706, container type: Cardboard and size: 5
	And In the New Product page I click tab: Recipient and UPC Details
	And I click the page heading: Universal Product Code (UPC)
	And I expand UPC details for UPC saved as UPC113706
	And I delete the value in the Product Name on Label field
	#And I enter 123-44-5555 in the DPCI field of the UPC page
	And In the Universal Product Code (UPC) page I click Save
	And I should see an error message on the Product Name on Label field which reads: This is a required field.
	And I should see the following error text displayed in the UPC screen: Please fix UPC errors
	Then I click the Home navigation icon
	Given I delete all products with UPC Number: saved as UPC113706

@ScenarioId:5971
Scenario:[114216] TR (Transparency Value) - Display as Percentage
	Given I generate a random UPC number and save as: UPC114216
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I delete all products with UPC Number: saved as UPC114216
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Given in the New Product page I click Continue
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
	Then I save the product information as: Product114216
	And I call Shared Step 85284 - Product Information - US & Canada, Child (No), OSHA (No), DSV (No), PLP (YES), GNFR (No), Continue
	And I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
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
	Then I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: Product114216

Scenario: [118221] UPC Details for Registration - Specific Retailer - DOT Packing Group Data
	Given I log in with the account saved in TReVor as: ProductAccount
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Given in the New Product page I click Continue
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Fertilizer
	And I call Shared Step 74340 (Product Information - Pesticide= Not considered, SOLD=US, everything else = No - Continue)
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
	And I set the Select the best Water Solubility description option to: Soluble in water
	And I click continue
	And I call Shared Step 29181 (Ingredients - add any chemical) with name: Benzene
	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	And I should see the Transportation Details 1 Page
	And I set the Product is Regulated for Transport field to: Yes
	And I set the Select all modes of transport that you've classified the product for field to: DOT
	And I select option: Shipping fully regulated under section: Select all modes of transport that you've classified the product for and subsection: DOT
	And I set the Select all modes of transport that you've classified the product for field to: DOT
	And I select option: Shipping fully regulated under section: Select all modes of transport that you've classified the product for and subsection: DOT
	And I set the Select all modes of transport that you've classified the product for field to: IMDG
	And I select option: Shipping fully regulated under section: Select all modes of transport that you've classified the product for and subsection: IMDG
	And I set the Select all modes of transport that you've classified the product for field to: IATA
	And I select option: Shipping fully regulated under section: Select all modes of transport that you've classified the product for and subsection: IATA
	And I set the Select all modes of transport that you've classified the product for field to: TDG
	And I select option: Shipping fully regulated under section: Select all modes of transport that you've classified the product for and subsection: TDG
	And I click continue
	And I should see the U. S. Department of Transportation (DOT) Classification Page
	And I set the UN Number field to: UN2762
	And I set the Technical Name field to: Technical Name UN2762
	And I set the Packing Group (select) field to: II
	And I select the first option in section: Product has a boiling point of <=35⁰C  and flash point of >60⁰C. Packing Group selected is not consistent with this data.  Verify the data and transportation packing group.  If problem persists, please contact Support.
	And I click continue
	And I should see the International Air Transport (IATA) Classification Page
	And I check the checkbox with description: Copy information from my U.S. Department of Transportation data
	And I select the first option in section: Product has a boiling point of <=35⁰C and flash point of >60⁰C. Packing Group selected is not consistent with this data.  Verify the data and transportation packing group.  If problem persists, please contact Support.
	And I click continue
	And I should see the International Marine (IMDG) Classification Page
	And I check the checkbox with description: Copy information from my U.S. Department of Transportation data
	And I select the first option in section: Product has a boiling point of <=35⁰C and flash point of >60⁰C. Packing Group selected is not consistent with this data.  Verify the data and transportation packing group.  If problem persists, please contact Support.
	And I click continue
	And I should see the Canada - Transportation of Dangerous Goods (TDG) Classification Page
	And I check the checkbox with description: Copy information from my U.S. Department of Transportation data
	And I click continue
	And I call Shared Step 77845 (Retailer - Select WM, Done, Select Vendor ID, Continue)
	Given I click the 'Add' button
	Then I generate a random UPC number and save as: RandomUPC91076
	Given I add the following into the UPC Fields
		| UPC Number              | Container Type    | Size | DPCI | Quantity |
		| saved as RandomUPC91076 | Plastic Container | 1    |      |          |
	Given I click continue
	#And I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	And I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	And I should see the Additional Documents to Provide Page
	And I click continue
	And I should see the Optional Reports and Documents Available for Purchase Page
	And I click continue
	And I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
		| Gloves                        | 120                      | 4                       | 10.0      | Black      | Odorless | No data available | 1                     |
	And I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Test Comment
	And I call Shared Step 73956 (Go to Summary and verify data) with product type: Fertilizer
	And I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	And In the Purchase Summary screen I confirm the Purchase Summary header is displayed
	And In the Purchase Summary screen if Product Billing is displayed I click Confirm Order
	And I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase65947 and its status is: Submitted
	Then I select the: UPC Details for Registration - Specific Retailer report from Advanced Reporting in SHA
	Then I Check that the Description Text for the Report: UPC Details for Registration - Specific Retailer is shown as: Internal Use Only.  UPCs are listed for a chosen Retailer and include any additional UPC data such as Case Pack, Net Explosive Mass, and other details.
	Then In The advanced reporting screen I enter WPSID saved as: TestCase65947
	Then In The advanced reporting screen I choose retailer: Walmart
	Then In the Advanced Reporting popup I click Submit
	And I wait for the Advanced Reporting Preparing Report popup to disappear
	Given I confirm that an excel file is produced called UPC Details for Registration - Specific Retailer.xls and save as 96733
	Then I confirm that the excel file saved as: 96733 contains the WPSID saved as: TestCase65947 and has: II in the column: DOT Packing Group
	Then I delete the Advanced Report file saved as 96733
	Then I Click close in the Advanced Reporting Popup

Scenario: [122472] Subscription by Account and Product Type
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given In SHA Manager - Select Actions - Advanced Reporting
	Given In the Advanced Reporting popup I select report Subscription by Account and Product Type
	Given In the Advanced Reporting popup I click Submit
	Given I wait for the Advanced Reporting Preparing Report popup to disappear
	Given I confirm that an excel file is produced called Subscription by Account and Product Type.xls and save as excel122472
	Given I confirm that the excel file saved as: excel122472 contains the following columns:
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
		| Subscription Date (most recent)              |
		| Active Subscription                          |
		| Past Due Balance                             |
	Given I delete the excel file saved as excel122472

Scenario: [124993] Subscription by Account and Product Type
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Then I select the: Subscription by Account and Product Type report from Advanced Reporting in SHA
	Then I Check that the Description Text for the Report: Subscription by Account and Product Type is shown as: Subscription information for submitted registrations, including overall quantity of IDs and UPCs for the accounts.  All products and all accounts. Indicator of Past Due balance and Active subscriptions. Quantity of registrations per status, including cancelled, excluding new.  Internal Use Only.
	Given In the Advanced Reporting popup I click Submit
	And I wait for the Advanced Reporting Preparing Report popup to disappear
	Given I confirm that an excel file is produced called Subscription by Account and Product Type.xls and save as 124993
	Then I confirm that the excel file saved as: 124993 contains the following columns: and they are in the correct order.
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
		| Subscription Date (most recent)              |
		| Active Subscription                          |
		| Past Due Balance                             |		
	Then For the excel file saved as: 124993 I check that the column with heading name: Cancelled does not contain: 0 / 0 in at least 1 row.
	Then I delete the Advanced Report file saved as 124993

Scenario: [124994] PM Walgreen Monthly Item Sync Report - UPC Requested Columns Contain Data
Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Then I select the: PM Walgreen Monthly Item Sync Report report from Advanced Reporting in SHA
	Then I Check that the Description Text for the Report: PM Walgreen Monthly Item Sync Report is shown as: Walgreen Monthly Item Sync Report
	Then I enter start Date: 10-10-2019 and end Date: NA for the Advanced report then I click Submit
	And I wait for the Advanced Reporting Preparing Report popup to disappear
	Given I confirm that an excel file is produced called PM Walgreen Monthly Item Sync Report.xls and save as 124994
	Then I confirm that the excel file saved as: 124994 contains the following columns: and they are in the correct order.
		| Column                                |
		| WPSID                                 |
		| Product Status                        |
		| Retailer Archived                     |
		| UPC                                   |
		| UPC Archived                          |
		| Product Name                          |
		| UPC Name                              |
		| Supplier                              |
		| PLP                                   |
		| Item Type                             |
		| RU                                    |
		| RU Name                               |
		| RUCC                                  |
		| RUCC Name                             |
		| # Times UPC Requested                 |
		| Date API Ping                         |
		| UPC Last Requested                    |
		| UPC Requested Response                |
		| Walgreen Product Completion Date      |
		| Suppliers Submission Date             |
		| Recertification Reason                |
		| Other Walgreen Non Completion Reasons |
	Then For the excel file saved as: 124994 I check that the columns with heading names found in the Table: contain data in all rows.
		| Headers                   |
		| UPC Last Requested <date> |
		| UPC Requested Response    |
	Then I delete the Advanced Report file saved as 124994

@ScenarioId:1568
Scenario:[112754] SHA Manager: Advanced Reports: Obsolete Report: Obsoleted Products
Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
And In SHA Manager - Select Actions - Advanced Reporting
And In the Advanced Reporting popup I verify I cannot select report Obsoleted Products
And Verify no Advanced Report exists with description reading: List of Obsoleted Products, with Supplier Name and User


Scenario: [127901] SHA - Actions - Advanced Reporting - Daily Report - Data Tier Consent

Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
Given I select the: Daily Report - Data Tier Consent report from Advanced Reporting in SHA
Given In the Advanced Reporting popup I click Submit
Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
Then I select the: Daily Report - Data Tier Consent report from Advanced Reporting in SHA
Then In the Advanced Reporting popup I click Submit
And I wait for the Advanced Reporting Preparing Report popup to disappear
Given I confirm that an excel file is produced called Daily Report - Data Tier Consent.xls and save as 127901
And I confirm the excel file saved as 127901 can be opened and contains data
Then I confirm that the excel file saved as: 127901 includes the following columns:
		| Column |
		| Client |	
Then I confirm that the excel file saved as: 127901 contains the following retailers:
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
Given I delete the Advanced Report file saved as 127901
Given I Click close in the Advanced Reporting Popup