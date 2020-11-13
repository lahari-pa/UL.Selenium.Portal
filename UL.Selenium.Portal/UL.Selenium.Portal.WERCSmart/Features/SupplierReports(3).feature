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
@ViewUpcs
@DataSummarySheet
@SHA
@MyAccount
@NewProduct
@ProductSetUp
@UPC
@run_SupplierReports3
Feature: Supplier Reports 3

@ScenarioId:10307
Scenario: [141028] Registration Updates Not Submitted - CSV Zip File
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Given I click the My Reports icon in the QuickLinks Pane
Given Under the Supplier Reports menu I choose: Registration Updates Not Submitted
Then I select CSV from the Select File Type
Given I select the Zip Report Checkbox
Then I Delete the file with name: Registration Updates Not Submitted.zip from the downloads folder
Then I Delete the file with name: Registration Updates Not Submitted.csv from the downloads folder
Then I select the Request Report button zip file is produced called Registration Updates Not Submitted.zip and save as Registration Updates Not Submitted
Given I confirm that an zip file is produced called Registration Updates Not Submitted.zip and save as Registration Updates Not Submitted
Given I click Close in the Report Download popup
And I confirm the zip csv file saved as Registration Updates Not Submitted can be opened and contains data
Given I delete the excel file saved as Registration Updates Not Submitted
Then I Delete the file with name: Registration Updates Not Submitted.zip from the downloads folder
Then I Delete the file with name: Registration Updates Not Submitted.csv from the downloads folder
Given Under the Supplier Reports menu I choose: Registration Updates Not Submitted
Then I confirm the most recent file has the following information Report Name: Registration Updates Not Submitted File Type: CSV (Zip) Requested By: WERCS Test_Automation_ProductsAccount
Then I confirm there is a Download button for the most recent report
Then I click the Download button for the most recent report
Given I confirm that an zip file is produced called Registration Updates Not Submitted.zip and save as Registration Updates Not Submitted
And I confirm the zip csv file saved as Registration Updates Not Submitted can be opened and contains data
Given I click Close in the Report Download popup
Given I delete the file saved as Registration Updates Not Submitted
Then I Delete the file with name: Registration Updates Not Submitted.zip from the downloads folder
Then I Delete the file with name: Registration Updates Not Submitted.csv from the downloads folder
Given I Delete the directory and its contents with name: ExtractFolder from the downloads folder

@ScenarioId:10311
Scenario: [141029] Subscription Product Types - CSV Zip File
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Given I click the My Reports icon in the QuickLinks Pane
Given Under the Supplier Reports menu I choose: Subscription Product Types
Then I select CSV from the Select File Type
Given I select the Zip Report Checkbox
Then I Delete the file with name: Subscription Product Types.zip from the downloads folder
Then I Delete the file with name: Subscription Product Types.csv from the downloads folder
Then I select the Request Report button zip file is produced called Subscription Product Types.zip and save as Subscription Product Types
Given I confirm that an zip file is produced called Subscription Product Types.zip and save as Subscription Product Types
Given I click Close in the Report Download popup
And I confirm the zip csv file saved as Subscription Product Types can be opened and contains data
Given I delete the excel file saved as Subscription Product Types
Then I Delete the file with name: Subscription Product Types.zip from the downloads folder
Then I Delete the file with name: Subscription Product Types.csv from the downloads folder
Given Under the Supplier Reports menu I choose: Subscription Product Types
Then I confirm the most recent file has the following information Report Name: Subscription Product Types File Type: CSV (Zip) Requested By: WERCS Test_Automation_ProductsAccount
Then I confirm there is a Download button for the most recent report
Then I click the Download button for the most recent report
Given I confirm that an zip file is produced called Subscription Product Types.zip and save as Subscription Product Types
And I confirm the zip csv file saved as Subscription Product Types can be opened and contains data
Given I click Close in the Report Download popup
Given I delete the file saved as Subscription Product Types
Then I Delete the file with name: Subscription Product Types.zip from the downloads folder
Then I Delete the file with name: Subscription Product Types.csv from the downloads folder
Given I Delete the directory and its contents with name: ExtractFolder from the downloads folder

@ScenarioId:10312
Scenario: [141034] UPC Duplication - CSV Zip File
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Given I click the My Reports icon in the QuickLinks Pane
Given Under the Supplier Reports menu I choose: UPC Duplication
Then I select CSV from the Select File Type
Given I select the Zip Report Checkbox
Then I Delete the file with name: UPC Duplication.zip from the downloads folder
Then I Delete the file with name: UPC Duplication.csv from the downloads folder
Then I select the Request Report button zip file is produced called UPC Duplication.zip and save as UPC Duplication
Given I confirm that an zip file is produced called UPC Duplication.zip and save as UPC Duplication
Given I click Close in the Report Download popup
And I confirm the zip csv file saved as UPC Duplication can be opened and contains data
Given I delete the excel file saved as UPC Duplication
Then I Delete the file with name: UPC Duplication.zip from the downloads folder
Then I Delete the file with name: UPC Duplication.csv from the downloads folder
Given Under the Supplier Reports menu I choose: UPC Duplication
Then I confirm the most recent file has the following information Report Name: UPC Duplication File Type: CSV (Zip) Requested By: WERCS Test_Automation_ProductsAccount
Then I confirm there is a Download button for the most recent report
Then I click the Download button for the most recent report
Given I confirm that an zip file is produced called UPC Duplication.zip and save as UPC Duplication
And I confirm the zip csv file saved as UPC Duplication can be opened and contains data
Given I click Close in the Report Download popup
Given I delete the file saved as UPC Duplication
Then I Delete the file with name: UPC Duplication.zip from the downloads folder
Then I Delete the file with name: UPC Duplication.csv from the downloads folder
Given I Delete the directory and its contents with name: ExtractFolder from the downloads folder

@ScenarioId:10313
Scenario: [141036] Volatile Organic Compounds - CSV Zip File
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Given I click the My Reports icon in the QuickLinks Pane
Given Under the Supplier Reports menu I choose: Volatile Organic Compounds
Then I select CSV from the Select File Type
Given I select the Zip Report Checkbox
Then I Delete the file with name: Volatile Organic Compounds.zip from the downloads folder
Then I Delete the file with name: Volatile Organic Compounds.csv from the downloads folder
Then I select the Request Report button zip file is produced called Volatile Organic Compounds.zip and save as Volatile Organic Compounds
Given I confirm that an zip file is produced called Volatile Organic Compounds.zip and save as Volatile Organic Compounds
Given I click Close in the Report Download popup
And I confirm the zip csv file saved as Volatile Organic Compounds can be opened and contains data
Given I delete the excel file saved as Volatile Organic Compounds
Then I Delete the file with name: Volatile Organic Compounds.zip from the downloads folder
Then I Delete the file with name: Volatile Organic Compounds.csv from the downloads folder
Given Under the Supplier Reports menu I choose: Volatile Organic Compounds
Then I confirm the most recent file has the following information Report Name: Volatile Organic Compounds File Type: CSV (Zip) Requested By: WERCS Test_Automation_ProductsAccount
Then I confirm there is a Download button for the most recent report
Then I click the Download button for the most recent report
Given I confirm that an zip file is produced called Volatile Organic Compounds.zip and save as Volatile Organic Compounds
And I confirm the zip csv file saved as Volatile Organic Compounds can be opened and contains data
Given I click Close in the Report Download popup
Given I delete the file saved as Volatile Organic Compounds
Then I Delete the file with name: Volatile Organic Compounds.zip from the downloads folder
Then I Delete the file with name: Volatile Organic Compounds.csv from the downloads folder
Given I Delete the directory and its contents with name: ExtractFolder from the downloads folder

@ScenarioId:10314
Scenario: [141041] Waste Classification Summary - CSV Zip File
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Given I click the My Reports icon in the QuickLinks Pane
Given Under the Supplier Reports menu I choose: Waste Classification Summary
Then I select CSV from the Select File Type
Given I select the Zip Report Checkbox
Then I Delete the file with name: Waste Classification Summary.zip from the downloads folder
Then I Delete the file with name: Waste Classification Summary.csv from the downloads folder
Then I select the Request Report button zip file is produced called Waste Classification Summary.zip and save as Waste Classification Summary
Given I confirm that an zip file is produced called Waste Classification Summary.zip and save as Waste Classification Summary
Given I click Close in the Report Download popup
And I confirm the zip csv file saved as Waste Classification Summary can be opened and contains data
Given I delete the excel file saved as Waste Classification Summary
Then I Delete the file with name: Waste Classification Summary.zip from the downloads folder
Then I Delete the file with name: Waste Classification Summary.csv from the downloads folder
Given Under the Supplier Reports menu I choose: Waste Classification Summary
Then I confirm the most recent file has the following information Report Name: Waste Classification Summary File Type: CSV (Zip) Requested By: WERCS Test_Automation_ProductsAccount
Then I confirm there is a Download button for the most recent report
Then I click the Download button for the most recent report
Given I confirm that an zip file is produced called Waste Classification Summary.zip and save as Waste Classification Summary
And I confirm the zip csv file saved as Waste Classification Summary can be opened and contains data
Given I click Close in the Report Download popup
Given I delete the file saved as Waste Classification Summary
Then I Delete the file with name: Waste Classification Summary.zip from the downloads folder
Then I Delete the file with name: Waste Classification Summary.csv from the downloads folder
Given I Delete the directory and its contents with name: ExtractFolder from the downloads folder

@tfs_design
@ScenarioId:10318
Scenario: [141799] Chemicals of Concern - CSV Zip File
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Given I click the My Reports icon in the QuickLinks Pane
Given Under the Supplier Reports menu I choose: Chemicals of Concern
Then I select Excel from the Select File Type
Given I select the Zip Report Checkbox
Then I Delete the file with name: Chemicals of Concern.zip from the downloads folder
Then I Delete the file with name: Chemicals of Concern.csv from the downloads folder
Then I select the Request Report button zip file is produced called Chemicals of Concern.zip and save as Chemicals of Concern
Given I confirm that an zip file is produced called Chemicals of Concern.zip and save as Chemicals of Concern
Given I click Close in the Report Download popup
And I confirm the zip csv file saved as Chemicals of Concern can be opened and contains data
Given I delete the excel file saved as Chemicals of Concern
Then I Delete the file with name: Chemicals of Concern.zip from the downloads folder
Then I Delete the file with name: Chemicals of Concern.csv from the downloads folder
Given Under the Supplier Reports menu I choose: Chemicals of Concern
Then I confirm the most recent file has the following information Report Name: Chemicals of Concern File Type: CSV (Zip) Requested By: WERCS Test_Automation_ProductsAccount
Then I confirm there is a Download button for the most recent report
Then I click the Download button for the most recent report
Given I confirm that an zip file is produced called Chemicals of Concern.zip and save as Chemicals of Concern
And I confirm the zip csv file saved as Chemicals of Concern can be opened and contains data
Given I click Close in the Report Download popup
Given I delete the file saved as Chemicals of Concern
Then I Delete the file with name: Chemicals of Concern.zip from the downloads folder
Then I Delete the file with name: Chemicals of Concern.csv from the downloads folder
Given I Delete the directory and its contents with name: ExtractFolder from the downloads folder















@ScenarioId:10336
Scenario: [146145] UPCs to Retailer via Item Sync - Excel File 

Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Given I click the My Reports icon in the QuickLinks Pane
Given Under the Supplier Reports menu I choose: UPCs to Retailer via Item Sync
Given In the My Reports Screen I confirm the following description is displayed: Recipients of a Registration's assessment data have the ability to request a UPC from the WERCSmart database. This minimizes the impact on registrants with regard to forwarding registrations or updating UPCs in order to fulfill a retailer requirement. This report will provide you with information regarding UPCs active within your account that have been requested via Item Sync by a Recipient within the last 6 months from the date of request.
Then I select Excel from the Select File Type
Then I Delete the file with name: UPCs to Retailer via Item Sync.xlsx from the downloads folder
Then I select the Request Report button excel file is produced called UPCs to Retailer via Item Sync.xlsx and save as UPCs to Retailer via Item Sync
Given I confirm that an excel file is produced called UPCs to Retailer via Item Sync.xlsx and save as UPCs to Retailer via Item Sync
Given I click Close in the Report Download popup
Then I confirm that the excel file saved as: UPCs to Retailer via Item Sync contains the following columns:
		| Column            |
		| WPSID             |
		| Product Name      |
		| Supplier          |
		| UPC               |
		| Retailer          |
		| Date UPC Provided |
Given I delete the excel file saved as UPCs to Retailer via Item Sync
Given Under the Supplier Reports menu I choose: UPCs to Retailer via Item Sync
Then I confirm the most recent file has the following information Report Name: UPCs to Retailer via Item Sync File Type: XLSX Requested By: WERCS Test_Automation_ProductsAccount
Then I confirm there is a Download button for the most recent report
Then I click the Download button for the most recent report
Given I confirm that an excel file is produced called UPCs to Retailer via Item Sync.xlsx and save as UPCs to Retailer via Item Sync
And I confirm the Supplier Reports excel file saved as UPCs to Retailer via Item Sync can be opened and contains data
Given I click Close in the Report Download popup
Then I Delete the file with name: UPCs to Retailer via Item Sync.xlsx from the downloads folder

@ScenarioId:10349
Scenario: [146172] UPCs to Retailer via Item Sync - Excel Zip File

Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Given I click the My Reports icon in the QuickLinks Pane
Given Under the Supplier Reports menu I choose: UPCs to Retailer via Item Sync
Given In the My Reports Screen I confirm the following description is displayed: Recipients of a Registration's assessment data have the ability to request a UPC from the WERCSmart database. This minimizes the impact on registrants with regard to forwarding registrations or updating UPCs in order to fulfill a retailer requirement. This report will provide you with information regarding UPCs active within your account that have been requested via Item Sync by a Recipient within the last 6 months from the date of request.
Then I select Excel from the Select File Type
Given I select the Zip Report Checkbox
Then I Delete the file with name: UPCs to Retailer via Item Sync.zip from the downloads folder
Then I Delete the file with name: UPCs to Retailer via Item Sync.xlsx from the downloads folder
Then I select the Request Report button zip file is produced called UPCs to Retailer via Item Sync.zip and save as UPCs to Retailer via Item Sync
Given I click Close in the Report Download popup
Given I confirm that an zip file is produced called UPCs to Retailer via Item Sync.zip and save as UPCs to Retailer via Item Sync
And I confirm the zip excel file saved as UPCs to Retailer via Item Sync can be opened and contains data
Then I confirm that the excel file saved as: UPCs to Retailer via Item Sync contains the following columns:
		| Column            |
		| WPSID             |
		| Product Name      |
		| Supplier          |
		| UPC               |
		| Retailer          |
		| Date UPC Provided |
Then I Delete the file with name: UPCs to Retailer via Item Sync.zip from the downloads folder
Then I Delete the file with name: UPCs to Retailer via Item Sync.xlsx from the downloads folder
Given Under the Supplier Reports menu I choose: UPCs to Retailer via Item Sync
Then I confirm the most recent file has the following information Report Name: UPCs to Retailer via Item Sync File Type: XLSX (Zip) Requested By: WERCS Test_Automation_ProductsAccount
Then I confirm there is a Download button for the most recent report
Then I click the Download button for the most recent report
Given I confirm that an zip file is produced called UPCs to Retailer via Item Sync.zip and save as UPCs to Retailer via Item Sync
And I confirm the zip excel file saved as UPCs to Retailer via Item Sync can be opened and contains data
Given I click Close in the Report Download popup
Then I Delete the file with name: UPCs to Retailer via Item Sync.zip from the downloads folder
Then I Delete the file with name: UPCs to Retailer via Item Sync.xlsx from the downloads folder
Given I Delete the directory and its contents with name: ExtractFolder from the downloads folder


@ScenarioId:10337
Scenario: [146146] UPCs to Retailer via Item Sync - CSV File

Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Given I click the My Reports icon in the QuickLinks Pane
Given Under the Supplier Reports menu I choose: UPCs to Retailer via Item Sync
Given In the My Reports Screen I confirm the following description is displayed: Recipients of a Registration's assessment data have the ability to request a UPC from the WERCSmart database. This minimizes the impact on registrants with regard to forwarding registrations or updating UPCs in order to fulfill a retailer requirement. This report will provide you with information regarding UPCs active within your account that have been requested via Item Sync by a Recipient within the last 6 months from the date of request.
Then I select CSV from the Select File Type
Then I Delete the file with name: UPCs to Retailer via Item Sync.csv from the downloads folder
Then I select the Request Report button csv file is produced called UPCs to Retailer via Item Sync.csv and save as UPCs to Retailer via Item Sync
Given I confirm that an csv file is produced called UPCs to Retailer via Item Sync.csv and save as UPCs to Retailer via Item Sync
Given I click Close in the Report Download popup
And I confirm the csv file saved as UPCs to Retailer via Item Sync can be opened and contains data
Then I confirm that the CSV file saved as: UPCs to Retailer via Item Sync contains the following columns:
		| Column            |
		| WPSID             |
		| Product Name      |
		| Supplier          |
		| UPC               |
		| Retailer          |
		| Date UPC Provided |
Given I delete the excel file saved as UPCs to Retailer via Item Sync
Then I Delete the file with name: UPCs to Retailer via Item Sync.csv from the downloads folder
Given Under the Supplier Reports menu I choose: UPCs to Retailer via Item Sync
Then I confirm the most recent file has the following information Report Name: UPCs to Retailer via Item Sync File Type: CSV Requested By: WERCS Test_Automation_ProductsAccount
Then I confirm there is a Download button for the most recent report
Then I click the Download button for the most recent report
Given I confirm that an csv file is produced called UPCs to Retailer via Item Sync.csv and save as UPCs to Retailer via Item Sync
And I confirm the csv file saved as UPCs to Retailer via Item Sync can be opened and contains data
Given I click Close in the Report Download popup
Given I delete the file saved as UPCs to Retailer via Item Sync
Then I Delete the file with name: UPCs to Retailer via Item Sync.csv from the downloads folder


@ScenarioId:10345
Scenario: [146164] UPCs to Retailer via Item Sync - CSV Zip File

Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Given I click the My Reports icon in the QuickLinks Pane
Given Under the Supplier Reports menu I choose: UPCs to Retailer via Item Sync
Given In the My Reports Screen I confirm the following description is displayed: Recipients of a Registration's assessment data have the ability to request a UPC from the WERCSmart database. This minimizes the impact on registrants with regard to forwarding registrations or updating UPCs in order to fulfill a retailer requirement. This report will provide you with information regarding UPCs active within your account that have been requested via Item Sync by a Recipient within the last 6 months from the date of request.
Then I select CSV from the Select File Type
Given I select the Zip Report Checkbox
Then I Delete the file with name: UPCs to Retailer via Item Sync.zip from the downloads folder
Then I Delete the file with name: UPCs to Retailer via Item Sync.csv from the downloads folder
Then I select the Request Report button zip file is produced called UPCs to Retailer via Item Sync.zip and save as UPCs to Retailer via Item Sync
Given I confirm that an zip file is produced called UPCs to Retailer via Item Sync.zip and save as UPCs to Retailer via Item Sync
Given I click Close in the Report Download popup
And I confirm the zip csv file saved as UPCs to Retailer via Item Sync can be opened and contains data
Then I confirm that the CSV file saved as: UPCs to Retailer via Item Sync contains the following columns:
		| Column            |
		| WPSID             |
		| Product Name      |
		| Supplier          |
		| UPC               |
		| Retailer          |
		| Date UPC Provided |
Then I Delete the file with name: UPCs to Retailer via Item Sync.zip from the downloads folder
Then I Delete the file with name: UPCs to Retailer via Item Sync.csv from the downloads folder
Given Under the Supplier Reports menu I choose: UPCs to Retailer via Item Sync
Then I confirm the most recent file has the following information Report Name: UPCs to Retailer via Item Sync File Type: CSV (Zip) Requested By: WERCS Test_Automation_ProductsAccount
Then I confirm there is a Download button for the most recent report
Then I click the Download button for the most recent report
Given I confirm that an zip file is produced called UPCs to Retailer via Item Sync.zip and save as UPCs to Retailer via Item Sync
And I confirm the zip csv file saved as UPCs to Retailer via Item Sync can be opened and contains data
Given I click Close in the Report Download popup
Given I delete the file saved as UPCs to Retailer via Item Sync
Then I Delete the file with name: UPCs to Retailer via Item Sync.zip from the downloads folder
Then I Delete the file with name: UPCs to Retailer via Item Sync.csv from the downloads folder
Given I Delete the directory and its contents with name: ExtractFolder from the downloads folder

@tfsdesign
@ScenarioId:10343
Scenario: [144339] UPC and Retailer (All) - CSV Zip File

Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Given I click the My Reports icon in the QuickLinks Pane
Given Under the Supplier Reports menu I choose: UPC and Retailer (All)
Given In the My Reports Screen I confirm the following description is displayed: For all active registrations, a list of the UPCs and Retailers associated.
Then I select CSV from the Select File Type
Given I select the Zip Report Checkbox
Then I Delete the file with name: UPC and Retailer (All).zip from the downloads folder
Then I Delete the file with name: UPC and Retailer (All).csv from the downloads folder
Then I select the Request Report button zip file is produced called UPC and Retailer (All).zip and save as UPC and Retailer (All)
Given I confirm that an zip file is produced called UPC and Retailer (All).zip and save as UPC and Retailer (All)
Given I see a Report Download popup with the following text: The report has been scheduled. Once completed, you will see the report in your history and you will be notified of availability via email.
Given I click Close in the Report Download popup
And I confirm the zip csv file saved as UPC and Retailer (All) can be opened and contains data
Given I delete the excel file saved as UPC and Retailer (All)
Then I Delete the file with name: UPC and Retailer (All).zip from the downloads folder
Then I Delete the file with name: UPC and Retailer (All).csv from the downloads folder
Given Under the Supplier Reports menu I choose: UPC and Retailer (All)
Then I confirm the most recent file has the following information Report Name: UPC and Retailer (All) File Type: CSV (Zip) Requested By: WERCS Test_Automation_ProductsAccount
Then I confirm there is a Download button for the most recent report
Then I click the Download button for the most recent report
Given I confirm that an zip file is produced called UPC and Retailer (All).zip and save as UPC and Retailer (All)
And I confirm the zip csv file saved as UPC and Retailer (All) can be opened and contains data
Given I click Close in the Report Download popup
Given I delete the file saved as UPC and Retailer (All)
Then I Delete the file with name: UPC and Retailer (All).zip from the downloads folder
Then I Delete the file with name: UPC and Retailer (All).csv from the downloads folder
Given I Delete the directory and its contents with name: ExtractFolder from the downloads folder


@ScenarioId:10344
Scenario: [144263] UPC Errors for The Home Depot- CSV Zip File 

Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Given I click the My Reports icon in the QuickLinks Pane
Given Under the Supplier Reports menu I choose: UPC Errors for The Home Depot
Given In the My Reports Screen I confirm the following description is displayed: OMSID rejections that may require contacting the retailer to ensure the proper OMSID is associated to the UPC.
Then I select CSV from the Select File Type
Given I select the Zip Report Checkbox
Then I Delete the file with name: UPC Errors for The Home Depot.zip from the downloads folder
Then I Delete the file with name: UPC Errors for The Home Depot.csv from the downloads folder
Then I enter the following in the WPSID textfield in the My Reports page: 1
Then In the My Reports Screen I select the first result in the WPSID textfield search results
Then I select the Request Report button zip file is produced called UPC Errors for The Home Depot.zip and save as UPC Errors for The Home Depot
Given I confirm that an zip file is produced called UPC Errors for The Home Depot.zip and save as UPC Errors for The Home Depot
Given I click Close in the Report Download popup
And I confirm the zip csv file saved as UPC Errors for The Home Depot can be opened and contains data
Given I delete the excel file saved as UPC Errors for The Home Depot
Then I Delete the file with name: UPC Errors for The Home Depot.zip from the downloads folder
Then I Delete the file with name: UPC Errors for The Home Depot.csv from the downloads folder
Given Under the Supplier Reports menu I choose: UPC Errors for The Home Depot
Then I confirm the most recent file has the following information Report Name: UPC Errors for The Home Depot File Type: CSV (Zip) Requested By: WERCS Test_Automation_ProductsAccount
Then I confirm there is a Download button for the most recent report
Then I click the Download button for the most recent report
Given I confirm that an zip file is produced called UPC Errors for The Home Depot.zip and save as UPC Errors for The Home Depot
And I confirm the zip csv file saved as UPC Errors for The Home Depot can be opened and contains data
Given I click Close in the Report Download popup
Given I delete the file saved as UPC Errors for The Home Depot
Then I Delete the file with name: UPC Errors for The Home Depot.zip from the downloads folder
Then I Delete the file with name: UPC Errors for The Home Depot.csv from the downloads folder
Given I Delete the directory and its contents with name: ExtractFolder from the downloads folder



@ScenarioId:10367
Scenario: [144240] Kit Registrations - CSV Zip File

Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Given I click the My Reports icon in the QuickLinks Pane
Given Under the Supplier Reports menu I choose: Kit Registrations
Given In the My Reports Screen I confirm the following description is displayed: For a specific Kit registration, the report will include the individual WERCSmart IDs that are included in the Kit.
Then I select CSV from the Select File Type
Given I select the Zip Report Checkbox
Then I Delete the file with name: Kit Registrations.zip from the downloads folder
Then I Delete the file with name: Kit Registrations.csv from the downloads folder
Then I enter the following in the WPSID textfield in the My Reports page: 1
Then In the My Reports Screen I select the first result in the WPSID textfield search results
Then I select the Request Report button zip file is produced called Kit Registrations.zip and save as Kit Registrations
Given I confirm that an zip file is produced called Kit Registrations.zip and save as Kit Registrations
Given I click Close in the Report Download popup
And I confirm the zip csv file saved as Kit Registrations can be opened and contains data
Given I delete the excel file saved as Kit Registrations
Then I Delete the file with name: Kit Registrations.zip from the downloads folder
Then I Delete the file with name: Kit Registrations.csv from the downloads folder
Given Under the Supplier Reports menu I choose: Kit Registrations
Then I confirm the most recent file has the following information Report Name: Kit Registrations File Type: CSV (Zip) Requested By: WERCS Test_Automation_ProductsAccount
Then I confirm there is a Download button for the most recent report
Then I click the Download button for the most recent report
Given I confirm that an zip file is produced called Kit Registrations.zip and save as Kit Registrations
And I confirm the zip csv file saved as Kit Registrations can be opened and contains data
Given I click Close in the Report Download popup
Given I delete the file saved as Kit Registrations
Then I Delete the file with name: Kit Registrations.zip from the downloads folder
Then I Delete the file with name: Kit Registrations.csv from the downloads folder
Given I Delete the directory and its contents with name: ExtractFolder from the downloads folder


@ScenarioId:10368
Scenario: [144259] Kits Containing a Registration - CSV Zip File

Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Given I click the My Reports icon in the QuickLinks Pane
Given Under the Supplier Reports menu I choose: Kits Containing a Registration
Given In the My Reports Screen I confirm the following description is displayed: For a specific WERCSmart ID, the report will show the various Kit registrations that include the specific registration.
Then I select CSV from the Select File Type
Given I select the Zip Report Checkbox
Then I Delete the file with name: Kits Containing a Registration.zip from the downloads folder
Then I Delete the file with name: Kits Containing a Registration.csv from the downloads folder
Then I enter the following in the WPSID textfield in the My Reports page: 1
Then In the My Reports Screen I select the first result in the WPSID textfield search results
Then I select the Request Report button zip file is produced called Kits Containing a Registration.zip and save as Kits Containing a Registration
Given I confirm that an zip file is produced called Kits Containing a Registration.zip and save as Kits Containing a Registration
Given I click Close in the Report Download popup
And I confirm the zip csv file saved as Kits Containing a Registration can be opened and contains data
Given I delete the excel file saved as Kits Containing a Registration
Then I Delete the file with name: Kits Containing a Registration.zip from the downloads folder
Then I Delete the file with name: Kits Containing a Registration.csv from the downloads folder
Given Under the Supplier Reports menu I choose: Kits Containing a Registration
Then I confirm the most recent file has the following information Report Name: Kits Containing a Registration File Type: CSV (Zip) Requested By: WERCS Test_Automation_ProductsAccount
Then I confirm there is a Download button for the most recent report
Then I click the Download button for the most recent report
Given I confirm that an zip file is produced called Kits Containing a Registration.zip and save as Kits Containing a Registration
And I confirm the zip csv file saved as Kits Containing a Registration can be opened and contains data
Given I click Close in the Report Download popup
Given I delete the file saved as Kits Containing a Registration
Then I Delete the file with name: Kits Containing a Registration.zip from the downloads folder
Then I Delete the file with name: Kits Containing a Registration.csv from the downloads folder
Given I Delete the directory and its contents with name: ExtractFolder from the downloads folder




@ScenarioId:10365
Scenario: [144262] UPC and Retailer (Single Registration) - CSV Zip File

Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Given I click the My Reports icon in the QuickLinks Pane
Given Under the Supplier Reports menu I choose: UPC and Retailer (Single Registration)
Given In the My Reports Screen I confirm the following description is displayed: For a specific WERCSmart registration, the report outlines the retailers and UPCs associated to the registration.
Then I select CSV from the Select File Type
Given I select the Zip Report Checkbox
Then I Delete the file with name: UPC and Retailer (Single Registration).zip from the downloads folder
Then I Delete the file with name: UPC and Retailer (Single Registration).csv from the downloads folder
Then I enter the following in the WPSID textfield in the My Reports page: 1
Then In the My Reports Screen I select the first result in the WPSID textfield search results
Then I select the Request Report button csv file is produced called UPC and Retailer (Single Registration).zip and save as UPC and Retailer (Single Registration)
Given I confirm that an zip file is produced called UPC and Retailer (Single Registration).zip and save as UPC and Retailer (Single Registration)
Given I click Close in the Report Download popup
And I confirm the zip csv file saved as UPC and Retailer (Single Registration) can be opened and contains data
Given I delete the excel file saved as UPC and Retailer (Single Registration)
Then I Delete the file with name: UPC and Retailer (Single Registration).zip from the downloads folder
Then I Delete the file with name: UPC and Retailer (Single Registration).csv from the downloads folder
Given Under the Supplier Reports menu I choose: UPC and Retailer (Single Registration)
Then I confirm the most recent file has the following information Report Name: UPC and Retailer (Single Registration) File Type: CSV (Zip) Requested By: WERCS Test_Automation_ProductsAccount
Then I confirm there is a Download button for the most recent report
Then I click the Download button for the most recent report
Given I confirm that an zip file is produced called UPC and Retailer (Single Registration).zip and save as UPC and Retailer (Single Registration)
And I confirm the zip csv file saved as UPC and Retailer (Single Registration) can be opened and contains data
Given I click Close in the Report Download popup
Given I delete the file saved as UPC and Retailer (Single Registration)
Then I Delete the file with name: UPC and Retailer (Single Registration).zip from the downloads folder
Then I Delete the file with name: UPC and Retailer (Single Registration).csv from the downloads folder
Given I Delete the directory and its contents with name: ExtractFolder from the downloads folder
