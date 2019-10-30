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

Scenario: [98534] Advanced Reporting - Registrations Published report -
	#Update 98534 in TFS
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Then I select the: Product Registrations Published report from Advanced Reporting in SHA
	Then I Check that the Description Text for the Report: Product Registrations Published is shown as: Assessed Registrations Published for Transfer and Completion to Retailers within a Date Range
	Then I enter start Date: 08-08-2019 and end Date: 11-14-2019 for the Advanced report then I click Submit
	And I wait for the Advanced Reporting Preparing Report popup to disappear
	#For below step need an actual file to get name etc
	Given I confirm that an excel file is produced called PM Monthly Status Report - Target.xlsx and save as 98534
	#For below step need an actual file for headers
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

Scenario: [96172] Data Quality Review for Walmart
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Then I select the: Data Quality Review for Walmart report from Advanced Reporting in SHA
	Then I Check that the Description Text for the Report: Data Quality Review for Walmart is shown as: Output consists of numerous datapoints that will allow internal users to manage the output for their immediate purpose and provide an overview of the Walmart-specific data provided to the retailer as a means of Quality Assurance. The report allow you to filter by product Last publish Date range and is limited to 500 records.
	Then I enter start Date: 08-08-2019 and end Date: 11-14-2019 for the Advanced report then I click Submit
	And I wait for the Advanced Reporting Preparing Report popup to disappear
	#Change to Correct File Name
	Given I confirm that an excel file is produced called PM Monthly Status Report - Target.xlsx and save as 96172
	#Update Column headings
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

Scenario: [96733] UPC Details for Registration - Specific Retailer
	Given I Use Test case 75142 to create a NEW PRODUCT and get it to Submitted status in SHA
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Then I select the: UPC Details for Registration - Specific Retailer report from Advanced Reporting in SHA
	Then I Check that the Description Text for the Report: UPC Details for Registration - Specific Retailer is shown as: Internal Use Only.  UPCs are listed for a chosen Retailer and include any additional UPC data such as Case Pack, Net Explosive Mass, and other details.
	Then In The advanced reporting screen I enter WPSID saved as: TestCase75142
	Then In The advanced reporting screen I choose retailer: CVS
	Then In the Advanced Reporting popup I click Submit
	And I wait for the Advanced Reporting Preparing Report popup to disappear
	#Change to Correct File Name
	Given I confirm that an excel file is produced called PM Monthly Status Report - Target.xlsx and save as 96733
	#Update Column headings
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
		| Column              |
		| UPC Name            |
	Then I delete the Advanced Report file saved as 114727

Scenario: [114728] UPCs Added Yesterday
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Then I select the: UPCs Added Yesterday report from Advanced Reporting in SHA
	Then I Check that the Description Text for the Report: UPCs Added Yesterday is shown as: UPCs Added Yesterday
	Then In the Advanced Reporting popup I click Submit
	And I wait for the Advanced Reporting Preparing Report popup to disappear
	#Change to Correct File Name
	Given I confirm that an excel file is produced called PM Monthly Status Report - Target.xlsx and save as 114728
	#Update Column headings
	Then I confirm that the excel file saved as: 114728 contains the following columns: and they are in the correct order.
		| Column              |
		| UPC Name            |
	Then I delete the Advanced Report file saved as 114728

Scenario: [114729] VOC Monthly Report - Walmart
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Then I select the: VOC Monthly Report - Walmart report from Advanced Reporting in SHA
	Then I Check that the Description Text for the Report: VOC Monthly Report - Walmart is shown as: Walmart Monthly VOC Report
	Then I enter start Date: 08-08-2019 and end Date: 11-14-2019 for the Advanced report then I click Submit
	And I wait for the Advanced Reporting Preparing Report popup to disappear
	#For below step need an actual file to get name etc
	Given I confirm that an excel file is produced called PM Monthly Status Report - Target.xlsx and save as 114729	
	#Update Colum headings
	Then I confirm that the excel file saved as: 114729 contains the following columns:
		| Column              |
		| UPC Name            |
	Then I delete the Advanced Report file saved as 114729
