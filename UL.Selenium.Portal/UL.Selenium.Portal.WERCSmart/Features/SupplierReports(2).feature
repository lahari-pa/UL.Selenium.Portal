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
@run_SupplierReports(2)
Feature: Supplier Reports (2)

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
Then I Delete the file with name: California Proposition 65.csv from the downloads folder
Then I select the Request Report button excel file is produced called California Proposition 65 (1).csv and save as California Proposition 65
Given I confirm that an excel file is produced called California Proposition 65 (1).csv and save as California Proposition 65
Given I click Close in the Report Download popup
And I confirm the csv file saved as California Proposition 65 can be opened and contains data
Given I delete the excel file saved as California Proposition 65
Then I confirm the most recent file has the following information Report Name: California Proposition 65 File Type: CSV Requested By: Richard Smith
Then I confirm there is a Download button for the most recent report
Then I click the Download button for the most recent report
And I confirm the csv file saved as California Proposition 65 can be opened and contains data
Given I click Close in the Report Download popup

@ScenarioId:10294
Scenario: [140260] Battery-Containing Products - CSV File
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Given I click the My Reports icon in the QuickLinks Pane
Given Under the Supplier Reports menu I choose: Battery-Containing Products
Then I select CSV from the Select File Type
Then I Delete the file with name: BatteryContaining Products (1).csv from the downloads folder
Then I select the Request Report button excel file is produced called BatteryContaining Products (1).csv and save as BatteryContaining Products
Given I confirm that an excel file is produced called BatteryContaining Products (1).csv and save as BatteryContaining Products
Given I click Close in the Report Download popup
And I confirm the csv file saved as BatteryContaining Products can be opened and contains data
Given I delete the excel file saved as BatteryContaining Products
Then I confirm the most recent file has the following information Report Name: Battery-Containing Products File Type: CSV Requested By: Richard Smith
Then I confirm there is a Download button for the most recent report
Then I click the Download button for the most recent report
Given I confirm that an excel file is produced called Battery-Containing Products (1).csv and save as BatteryContaining Products
And I confirm the csv file saved as BatteryContaining Products can be opened and contains data
Given I click Close in the Report Download popup

@ScenarioId:10309
Scenario: [140273] Eligible to Obsolete - CSV File
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Given I click the My Reports icon in the QuickLinks Pane
Given Under the Supplier Reports menu I choose: Eligible to Obsolete
Then I select CSV from the Select File Type
Then I Delete the file with name: Eligible to Obsolete (1).csv from the downloads folder
Then I select the Request Report button excel file is produced called Eligible to Obsolete (1).csv and save as Eligible to Obsolete
Given I confirm that an excel file is produced called Eligible to Obsolete (1).csv and save as Eligible to Obsolete
Given I click Close in the Report Download popup
And I confirm the csv file saved as Eligible to Obsolete can be opened and contains data
Given I delete the excel file saved as Eligible to Obsolete
Then I confirm the most recent file has the following information Report Name: Eligible to Obsolete File Type: CSV Requested By: Richard Smith
Then I confirm there is a Download button for the most recent report
Then I click the Download button for the most recent report
And I confirm the csv file saved as Eligible to Obsolete can be opened and contains data
Given I click Close in the Report Download popup

@ScenarioId:10310
Scenario: [140280] Pesticide Registrations - CSV File
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Given I click the My Reports icon in the QuickLinks Pane
Given Under the Supplier Reports menu I choose: Pesticide Registrations
Then I select CSV from the Select File Type
Then I Delete the file with name: Pesticide Registrations (1).csv from the downloads folder
Then I select the Request Report button csv file is produced called Pesticide Registrations (1).csv and save as Pesticide Registrations
Given I confirm that an zip file is produced called Pesticide Registrations (1).csv and save as Pesticide Registrations
Given I click Close in the Report Download popup
And I confirm the csv file saved as Pesticide Registrations can be opened and contains data
Given I delete the excel file saved as Pesticide Registrations
Then I confirm the most recent file has the following information Report Name: Pesticide Registrations File Type: CSV Requested By: Richard Smith
Then I confirm there is a Download button for the most recent report
Then I click the Download button for the most recent report
And I confirm the csv file saved as Pesticide Registrations can be opened and contains data
Given I click Close in the Report Download popup


@ScenarioId:10307
Scenario: [140289] Registration Updates Not Submitted - CSV File
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Given I click the My Reports icon in the QuickLinks Pane
Given Under the Supplier Reports menu I choose: Registration Updates Not Submitted
Then I select CSV from the Select File Type
Then I Delete the file with name: Registration Updates Not Submitted (1).csv from the downloads folder
Then I select the Request Report button excel file is produced called Registration Updates Not Submitted (1).csv and save as Registration Updates Not Submitted
Given I confirm that an excel file is produced called Registration Updates Not Submitted (1).csv and save as Registration Updates Not Submitted
Given I click Close in the Report Download popup
And I confirm the csv file saved as Registration Updates Not Submitted can be opened and contains data
Given I delete the excel file saved as Registration Updates Not Submitted
Then I confirm the most recent file has the following information Report Name: Registration Updates Not Submitted File Type: CSV Requested By: Richard Smith
Then I confirm there is a Download button for the most recent report
Then I click the Download button for the most recent report
And I confirm the csv file saved as Registration Updates Not Submitted can be opened and contains data
Given I click Close in the Report Download popup


@ScenarioId:10311
Scenario: [140290] Subscription Product Types - CSV File
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Given I click the My Reports icon in the QuickLinks Pane
Given Under the Supplier Reports menu I choose: Subscription Product Types
Then I select CSV from the Select File Type
Then I Delete the file with name: Subscription Product Types (1).csv from the downloads folder
Then I select the Request Report button excel file is produced called Subscription Product Types (1).csv and save as Subscription Product Types
Given I confirm that an excel file is produced called Subscription Product Types (1).csv and save as Subscription Product Types
Given I click Close in the Report Download popup
And I confirm the csv file saved as Subscription Product Types can be opened and contains data
Given I delete the excel file saved as Subscription Product Types
Then I confirm the most recent file has the following information Report Name: Subscription Product Types File Type: CSV Requested By: Richard Smith
Then I confirm there is a Download button for the most recent report
Then I click the Download button for the most recent report
And I confirm the csv file saved as Subscription Product Types can be opened and contains data
Given I click Close in the Report Download popup

@ScenarioId:10312
Scenario: [140291] UPC Duplication - CSV File
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Given I click the My Reports icon in the QuickLinks Pane
Given Under the Supplier Reports menu I choose: UPC Duplication
Then I select CSV from the Select File Type
Then I Delete the file with name: UPC Duplication (1).csv from the downloads folder
Then I select the Request Report button excel file is produced called UPC Duplication (1).csv and save as UPC Duplication
Given I confirm that an excel file is produced called UPC Duplication (1).csv and save as UPC Duplication
Given I click Close in the Report Download popup
And I confirm the csv file saved as UPC Duplication can be opened and contains data
Given I delete the excel file saved as UPC Duplication
Then I confirm the most recent file has the following information Report Name: UPC Duplication File Type: CSV Requested By: Richard Smith
Then I confirm there is a Download button for the most recent report
Then I click the Download button for the most recent report
And I confirm the csv file saved as UPC Duplication can be opened and contains data
Given I click Close in the Report Download popup

@ScenarioId:10313
Scenario: [140292] Volatile Organic Compounds - CSV File
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Given I click the My Reports icon in the QuickLinks Pane
Given Under the Supplier Reports menu I choose: Volatile Organic Compounds
Then I select CSV from the Select File Type
Then I Delete the file with name: Volatile Organic Compounds (1).csv from the downloads folder
Then I select the Request Report button excel file is produced called Volatile Organic Compounds (1).csv and save as Volatile Organic Compounds
Given I confirm that an excel file is produced called Volatile Organic Compounds (1).csv and save as Volatile Organic Compounds
Given I click Close in the Report Download popup
And I confirm the csv file saved as Volatile Organic Compounds can be opened and contains data
Given I delete the excel file saved as Volatile Organic Compounds
Then I confirm the most recent file has the following information Report Name: Volatile Organic Compounds File Type: CSV Requested By: Richard Smith
Then I confirm there is a Download button for the most recent report
Then I click the Download button for the most recent report
And I confirm the csv file saved as Volatile Organic Compounds can be opened and contains data
Given I click Close in the Report Download popup

@ScenarioId:10314
Scenario: [140293] Waste Classification Summary - CSV File
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Given I click the My Reports icon in the QuickLinks Pane
Given Under the Supplier Reports menu I choose: Waste Classification Summary
Then I select CSV from the Select File Type
Then I Delete the file with name: Waste Classification Summary (1).csv from the downloads folder
Then I select the Request Report button excel file is produced called Waste Classification Summary (1).csv and save as Waste Classification Summary
Given I confirm that an excel file is produced called Waste Classification Summary (1).csv and save as Waste Classification Summary
Given I click Close in the Report Download popup
And I confirm the csv file saved as Waste Classification Summary can be opened and contains data
Given I delete the excel file saved as Waste Classification Summary
Then I confirm the most recent file has the following information Report Name: Waste Classification Summary File Type: CSV Requested By: Richard Smith
Then I confirm there is a Download button for the most recent report
Then I click the Download button for the most recent report
And I confirm the csv file saved as Waste Classification Summary can be opened and contains data
Given I click Close in the Report Download popup


@tfs_design
@ScenarioId:10259
Scenario: [140309] Chemicals of Concern - CSV File
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Given I click the My Reports icon in the QuickLinks Pane
Given Under the Supplier Reports menu I choose: Chemicals of Concern
Then I select CSV from the Select File Type
Then I Delete the file with name: Chemicals of Concern (1).csv from the downloads folder
Then I select the Request Report button excel file is produced called Chemicals of Concern (1).csv and save as Chemicals of Concern
Given I confirm that an excel file is produced called Chemicals of Concern (1).csv and save as Chemicals of Concern
Given I click Close in the Report Download popup
And I confirm the csv file saved as Chemicals of Concern can be opened and contains data
Given I delete the excel file saved as Chemicals of Concern
Then I confirm the most recent file has the following information Report Name: Chemicals of Concern File Type: CSV Requested By: Richard Smith
Then I confirm there is a Download button for the most recent report
Then I click the Download button for the most recent report
And I confirm the zip csv file saved as Chemicals of Concern can be opened and contains data
Given I click Close in the Report Download popup



















































@ScenarioId:10293
Scenario: [140997] California Proposition 65 - CSV Zip File
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Given I click the My Reports icon in the QuickLinks Pane
Given Under the Supplier Reports menu I choose: California Proposition 65
Then I select CSV from the Select File Type
Given I select the Zip Report Checkbox
Then I Delete the file with name: California Proposition 65.zip from the downloads folder
Then I Delete the file with name: California Proposition 65.csv from the downloads folder
Then I select the Request Report button zip file is produced called California Proposition 65.zip and save as California Proposition 65
Given I confirm that an zip file is produced called California Proposition 65.zip and save as California Proposition 65
Given I click Close in the Report Download popup
And I confirm the zip csv file saved as California Proposition 65 can be opened and contains data
Given I delete the excel file saved as California Proposition 65
Then I Delete the file with name: California Proposition 65.zip from the downloads folder
Then I Delete the file with name: California Proposition 65.csv from the downloads folder
Given Under the Supplier Reports menu I choose: California Proposition 65
Then I confirm the most recent file has the following information Report Name: California Proposition 65 File Type: CSV (Zip) Requested By: Richard Smith
Then I confirm there is a Download button for the most recent report
Then I click the Download button for the most recent report
Given I confirm that an zip file is produced called California Proposition 65.zip and save as California Proposition 65
And I confirm the zip csv file saved as California Proposition 65 can be opened and contains data
Given I click Close in the Report Download popup
Given I delete the file saved as California Proposition 65
Then I Delete the file with name: California Proposition 65.zip from the downloads folder
Then I Delete the file with name: California Proposition 65.csv from the downloads folder
Given I Delete the directory and its contents with name: ExtractFolder from the downloads folder

@ScenarioId:10294
Scenario: [140683] Battery-Containing Products - CSV Zip File
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Given I click the My Reports icon in the QuickLinks Pane
Given Under the Supplier Reports menu I choose: Battery-Containing Products
Then I select CSV from the Select File Type
Given I select the Zip Report Checkbox
Then I Delete the file with name: BatteryContaining Products.zip from the downloads folder
Then I Delete the file with name: BatteryContaining Products.csv from the downloads folder
Then I select the Request Report button zip file is produced called BatteryContaining Products.zip and save as BatteryContaining Products
Given I confirm that an zip file is produced called BatteryContaining Products.zip and save as BatteryContaining Products
Given I click Close in the Report Download popup
And I confirm the zip csv file saved as BatteryContaining Products can be opened and contains data
Given I delete the excel file saved as BatteryContaining Products
Then I Delete the file with name: BatteryContaining Products.zip from the downloads folder
Then I Delete the file with name: BatteryContaining Products.csv from the downloads folder
Given Under the Supplier Reports menu I choose: Battery-Containing Products
Then I confirm the most recent file has the following information Report Name: Battery-Containing Products File Type: CSV (Zip) Requested By: Richard Smith
Then I confirm there is a Download button for the most recent report
Then I click the Download button for the most recent report
Given I confirm that an zip file is produced called BatteryContaining Products.zip and save as BatteryContaining Products
And I confirm the zip csv file saved as BatteryContaining Products can be opened and contains data
Given I click Close in the Report Download popup
Given I delete the file saved as BatteryContaining Products
Then I Delete the file with name: BatteryContaining Products.zip from the downloads folder
Then I Delete the file with name: BatteryContaining Products.csv from the downloads folder
Given I Delete the directory and its contents with name: ExtractFolder from the downloads folder

@ScenarioId:10309
Scenario: [141005] Eligible to Obsolete - CSV Zip File
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Given I click the My Reports icon in the QuickLinks Pane
Given Under the Supplier Reports menu I choose: Eligible to Obsolete
Then I select CSV from the Select File Type
Given I select the Zip Report Checkbox
Then I Delete the file with name: Eligible to Obsolete.zip from the downloads folder
Then I Delete the file with name: Eligible to Obsolete.csv from the downloads folder
Then I select the Request Report button zip file is produced called Eligible to Obsolete.zip and save as Eligible to Obsolete
Given I confirm that an zip file is produced called Eligible to Obsolete.zip and save as Eligible to Obsolete
Given I click Close in the Report Download popup
And I confirm the zip csv file saved as Eligible to Obsolete can be opened and contains data
Given I delete the excel file saved as Eligible to Obsolete
Then I Delete the file with name: Eligible to Obsolete.zip from the downloads folder
Then I Delete the file with name: Eligible to Obsolete.csv from the downloads folder
Given Under the Supplier Reports menu I choose: Eligible to Obsolete
Then I confirm the most recent file has the following information Report Name: Eligible to Obsolete File Type: CSV (Zip) Requested By: Richard Smith
Then I confirm there is a Download button for the most recent report
Then I click the Download button for the most recent report
Given I confirm that an zip file is produced called Eligible to Obsolete.zip and save as Eligible to Obsolete
And I confirm the zip csv file saved as Eligible to Obsolete can be opened and contains data
Given I click Close in the Report Download popup
Given I delete the file saved as Eligible to Obsolete
Then I Delete the file with name: Eligible to Obsolete.zip from the downloads folder
Then I Delete the file with name: Eligible to Obsolete.csv from the downloads folder

@ScenarioId:10310
Scenario: [141023] Pesticide Registrations - CSV Zip File
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Given I click the My Reports icon in the QuickLinks Pane
Given Under the Supplier Reports menu I choose: Pesticide Registrations
Then I select CSV from the Select File Type
Given I select the Zip Report Checkbox
Then I Delete the file with name: Pesticide Registrations.zip from the downloads folder
Then I Delete the file with name: Pesticide Registrations.csv from the downloads folder
Then I select the Request Report button zip file is produced called Pesticide Registrations.zip and save as Pesticide Registrations
Given I confirm that an zip file is produced called Pesticide Registrations.zip and save as Pesticide Registrations
Given I click Close in the Report Download popup
And I confirm the zip csv file saved as Pesticide Registrations can be opened and contains data
Given I delete the excel file saved as Pesticide Registrations
Then I Delete the file with name: Pesticide Registrations.zip from the downloads folder
Then I Delete the file with name: Pesticide Registrations.csv from the downloads folder
Given Under the Supplier Reports menu I choose: Pesticide Registrations
Then I confirm the most recent file has the following information Report Name: Pesticide Registrations File Type: CSV (Zip) Requested By: Richard Smith
Then I confirm there is a Download button for the most recent report
Then I click the Download button for the most recent report
Given I confirm that an zip file is produced called Pesticide Registrations.zip and save as Pesticide Registrations
And I confirm the zip csv file saved as Pesticide Registrations can be opened and contains data
Given I click Close in the Report Download popup
Given I delete the file saved as Pesticide Registrations
Then I Delete the file with name: Pesticide Registrations.zip from the downloads folder
Then I Delete the file with name: Pesticide Registrations.csv from the downloads folder
Given I Delete the directory and its contents with name: ExtractFolder from the downloads folder


