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
@run_SupplierReports2
Feature: Supplier Reports 2

@ignore
@TestCase:140261
Scenario: [140261] California Proposition 65 - CSV File
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Given I click the My Reports icon in the QuickLinks Pane
Given Under the Supplier Reports menu I choose: California Proposition 65 - Registrations Prior to August 30, 2018
Then I select CSV from the Select File Type
Then I Delete the file with name: California Proposition 65  Registrations Prior to August 30 2018.csv from the downloads folder
Then I select the Request Report button csv file is produced called California Proposition 65  Registrations Prior to August 30 2018.csv and save as California Proposition 65 - Registrations Prior to August 30, 2018
Given I confirm that an csv file is produced called California Proposition 65  Registrations Prior to August 30 2018.csv and save as California Proposition 65 - Registrations Prior to August 30, 2018
Given I click Close in the Report Download popup
And I confirm the csv file saved as California Proposition 65 - Registrations Prior to August 30, 2018 can be opened and contains data
Given I delete the excel file saved as California Proposition 65 - Registrations Prior to August 30, 2018
Then I confirm the most recent file has the following information Report Name: California Proposition 65 - Registrations Prior to August 30, 2018 File Type: CSV Requested By: WERCS Test_Automation_ProductsAccount
Then I confirm there is a Download button for the most recent report
Then I click the Download button for the most recent report with Report Name: California Proposition 65 - Registrations Prior to August 30, 2018 File Type: CSV Requested By: WERCS Test_Automation_ProductsAccount
And I confirm the csv file saved as California Proposition 65 - Registrations Prior to August 30, 2018 can be opened and contains data
Given I click Close in the Report Download popup
Then I Delete the file with name: California Proposition 65  Registrations Prior to August 30 2018.csv from the downloads folder

@ignore
@TestCase:140260
Scenario: [140260] Battery-Containing Products - CSV File
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Given I click the My Reports icon in the QuickLinks Pane
Given Under the Supplier Reports menu I choose: Battery-Containing Products
Then I select CSV from the Select File Type
Then I Delete the file with name: BatteryContaining Products.csv from the downloads folder
Then I select the Request Report button csv file is produced called BatteryContaining Products.csv and save as BatteryContaining Products
Given I confirm that an csv file is produced called BatteryContaining Products.csv and save as BatteryContaining Products
Given I click Close in the Report Download popup
And I confirm the csv file saved as BatteryContaining Products can be opened and contains data
Given I delete the excel file saved as BatteryContaining Products
Then I confirm the most recent file has the following information Report Name: Battery-Containing Products File Type: CSV Requested By: WERCS Test_Automation_ProductsAccount
Then I confirm there is a Download button for the most recent report
Then I click the Download button for the most recent report with Report Name: Battery-Containing Products File Type: CSV Requested By: WERCS Test_Automation_ProductsAccount
Given I confirm that an csv file is produced called Battery-Containing Products.csv and save as Battery-Containing Products
And I confirm the csv file saved as Battery-Containing Products can be opened and contains data
Given I click Close in the Report Download popup
Given I delete the excel file saved as BatteryContaining Products

@ignore
@TestCase:140273
Scenario: [140273] Eligible to Obsolete - CSV File
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Given I click the My Reports icon in the QuickLinks Pane
Given Under the Supplier Reports menu I choose: Eligible to Obsolete
Then I select CSV from the Select File Type
Then I Delete the file with name: Eligible to Obsolete.csv from the downloads folder
Then I select the Request Report button csv file is produced called Eligible to Obsolete.csv and save as Eligible to Obsolete
Given I confirm that an csv file is produced called Eligible to Obsolete.csv and save as Eligible to Obsolete
Given I click Close in the Report Download popup
And I confirm the csv file saved as Eligible to Obsolete can be opened and contains data
Given I delete the excel file saved as Eligible to Obsolete
Given Under the Supplier Reports menu I choose: Eligible to Obsolete
Then I confirm the most recent file has the following information Report Name: Eligible to Obsolete File Type: CSV Requested By: WERCS Test_Automation_ProductsAccount
Then I confirm there is a Download button for the most recent report
Then I click the Download button for the most recent report with Report Name: Eligible to Obsolete File Type: CSV Requested By: WERCS Test_Automation_ProductsAccount
Given I confirm that an csv file is produced called Eligible to Obsolete.csv and save as Eligible to Obsolete
And I confirm the csv file saved as Eligible to Obsolete can be opened and contains data
Given I click Close in the Report Download popup
Given I delete the excel file saved as Eligible to Obsolete

@ignore
@TestCase:140280
Scenario: [140280] Pesticide Registrations - CSV File
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Given I click the My Reports icon in the QuickLinks Pane
Given Under the Supplier Reports menu I choose: Pesticide Registrations
Then I select CSV from the Select File Type
Then I Delete the file with name: Pesticide Registrations.csv from the downloads folder
Then I select the Request Report button csv file is produced called Pesticide Registrations.csv and save as Pesticide Registrations
Given I confirm that an zip file is produced called Pesticide Registrations.csv and save as Pesticide Registrations
Given I click Close in the Report Download popup
And I confirm the csv file saved as Pesticide Registrations can be opened and contains data
Given I delete the excel file saved as Pesticide Registrations
Then I confirm the most recent file has the following information Report Name: Pesticide Registrations File Type: CSV Requested By: WERCS Test_Automation_ProductsAccount
Then I confirm there is a Download button for the most recent report
Then I click the Download button for the most recent report with Report Name: Pesticide Registrations File Type: CSV Requested By: WERCS Test_Automation_ProductsAccount
Given I confirm that an csv file is produced called Pesticide Registrations.csv and save as Pesticide Registrations
And I confirm the csv file saved as Pesticide Registrations can be opened and contains data
Given I click Close in the Report Download popup
Given I delete the excel file saved as Pesticide Registrations

@ignore
@TestCase:140289
Scenario: [140289] Registration Updates Not Submitted - CSV File
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Given I click the My Reports icon in the QuickLinks Pane
Given Under the Supplier Reports menu I choose: Registrations Revised - Not Yet Submitted
Then I select CSV from the Select File Type
Then I Delete the file with name: Registrations Revised  Not Yet Submitted.csv from the downloads folder
Then I select the Request Report button excel file is produced called Registrations Revised - Not Yet Submitted.csv and save as Registrations Revised - Not Yet Submitted
Given I confirm that an excel file is produced called Registrations Revised  Not Yet Submitted.csv and save as Registrations Revised - Not Yet Submitted
Given I click Close in the Report Download popup
And I confirm the csv file saved as Registrations Revised - Not Yet Submitted can be opened and contains data
Given I delete the excel file saved as Registrations Revised - Not Yet Submitted
Then I confirm the most recent file has the following information Report Name: Registrations Revised - Not Yet Submitted File Type: CSV Requested By: WERCS Test_Automation_ProductsAccount
Then I confirm there is a Download button for the most recent report
Then I click the Download button for the most recent report with Report Name: Registrations Revised - Not Yet Submitted File Type: CSV Requested By: WERCS Test_Automation_ProductsAccount
Given I confirm that an csv file is produced called Registrations Revised - Not Yet Submitted.csv and save as Registrations Revised - Not Yet Submitted
And I confirm the csv file saved as Registrations Revised - Not Yet Submitted can be opened and contains data
Given I click Close in the Report Download popup
Given I delete the excel file saved as Registrations Revised - Not Yet Submitted

@ignore
@TestCase:140290
Scenario: [140290] Subscription Product Types - CSV File
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Given I click the My Reports icon in the QuickLinks Pane
Given Under the Supplier Reports menu I choose: Subscription Product Types
Then I select CSV from the Select File Type
Then I Delete the file with name: Subscription Product Types.csv from the downloads folder
Then I select the Request Report button excel file is produced called Subscription Product Types.csv and save as Subscription Product Types
Given I confirm that an excel file is produced called Subscription Product Types.csv and save as Subscription Product Types
Given I click Close in the Report Download popup
And I confirm the csv file saved as Subscription Product Types can be opened and contains data
Given I delete the excel file saved as Subscription Product Types
Then I confirm the most recent file has the following information Report Name: Subscription Product Types File Type: CSV Requested By: WERCS Test_Automation_ProductsAccount
Then I confirm there is a Download button for the most recent report
Then I click the Download button for the most recent report with Report Name: Subscription Product Types File Type: CSV Requested By: WERCS Test_Automation_ProductsAccount
Given I confirm that an csv file is produced called Subscription Product Types.csv and save as Subscription Product Types
And I confirm the csv file saved as Subscription Product Types can be opened and contains data
Given I click Close in the Report Download popup
Given I delete the excel file saved as Subscription Product Types

@ignore
@TestCase:140291
Scenario: [140291] UPC Duplication - CSV File
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Given I click the My Reports icon in the QuickLinks Pane
Given Under the Supplier Reports menu I choose: UPCs Duplicated within Account
Then I select CSV from the Select File Type
Then I Delete the file with name: UPCs Duplicated within Account.csv from the downloads folder
Then I select the Request Report button excel file is produced called UPCs Duplicated within Account.csv and save as UPCs Duplicated within Account
Given I confirm that an excel file is produced called UPCs Duplicated within Account.csv and save as UPCs Duplicated within Account
Given I click Close in the Report Download popup
And I confirm the csv file saved as UPCs Duplicated within Account can be opened and contains data
Given I delete the excel file saved as UPCs Duplicated within Account
Then I confirm the most recent file has the following information Report Name: UPCs Duplicated within Account File Type: CSV Requested By: WERCS Test_Automation_ProductsAccount
Then I confirm there is a Download button for the most recent report
Then I click the Download button for the most recent report with Report Name: UPCs Duplicated within Account File Type: CSV Requested By: WERCS Test_Automation_ProductsAccount
Given I confirm that an csv file is produced called UPCs Duplicated within Account.csv and save as UPCs Duplicated within Account
And I confirm the csv file saved as UPCs Duplicated within Account can be opened and contains data
Given I click Close in the Report Download popup
Given I delete the excel file saved as UPCs Duplicated within Account

@ignore
@TestCase:140292
Scenario: [140292] Volatile Organic Compounds - CSV File
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Given I click the My Reports icon in the QuickLinks Pane
Given Under the Supplier Reports menu I choose: Volatile Organic Compounds
Then I select CSV from the Select File Type
Then I Delete the file with name: Volatile Organic Compounds.csv from the downloads folder
Then I select the Request Report button excel file is produced called Volatile Organic Compounds.csv and save as Volatile Organic Compounds
Given I confirm that an excel file is produced called Volatile Organic Compounds.csv and save as Volatile Organic Compounds
Given I click Close in the Report Download popup
And I confirm the csv file saved as Volatile Organic Compounds can be opened and contains data
Given I delete the excel file saved as Volatile Organic Compounds
Then I confirm the most recent file has the following information Report Name: Volatile Organic Compounds File Type: CSV Requested By: WERCS Test_Automation_ProductsAccount
Then I confirm there is a Download button for the most recent report
Then I click the Download button for the most recent report with Report Name: Volatile Organic Compounds File Type: CSV Requested By: WERCS Test_Automation_ProductsAccount
Given I confirm that an csv file is produced called Volatile Organic Compounds.csv and save as Volatile Organic Compounds
And I confirm the csv file saved as Volatile Organic Compounds can be opened and contains data
Given I click Close in the Report Download popup
Given I delete the excel file saved as Volatile Organic Compounds

@ignore
@TestCase:140293
Scenario: [140293] Waste Classification Summary - CSV File
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Given I click the My Reports icon in the QuickLinks Pane
Given Under the Supplier Reports menu I choose: Waste Classification Summary
Then I select CSV from the Select File Type
Then I Delete the file with name: Waste Classification Summary.csv from the downloads folder
Then I select the Request Report button excel file is produced called Waste Classification Summary.csv and save as Waste Classification Summary
Given I confirm that an excel file is produced called Waste Classification Summary.csv and save as Waste Classification Summary
Given I click Close in the Report Download popup
And I confirm the csv file saved as Waste Classification Summary can be opened and contains data
Given I delete the excel file saved as Waste Classification Summary
Then I confirm the most recent file has the following information Report Name: Waste Classification Summary File Type: CSV Requested By: WERCS Test_Automation_ProductsAccount
Then I confirm there is a Download button for the most recent report
Then I click the Download button for the most recent report with Report Name: Waste Classification Summary File Type: CSV Requested By: WERCS Test_Automation_ProductsAccount
Given I confirm that an csv file is produced called Waste Classification Summary.csv and save as Waste Classification Summary
And I confirm the csv file saved as Waste Classification Summary can be opened and contains data
Given I click Close in the Report Download popup
Given I delete the excel file saved as Waste Classification Summary

@tfs_design
@ignore
@TestCase:140309
Scenario: [140309] Chemicals of Concern - CSV File
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Given I click the My Reports icon in the QuickLinks Pane
Given Under the Supplier Reports menu I choose: Chemicals of Concern
Then I select CSV from the Select File Type
Then I Delete the file with name: Chemicals of Concern.csv from the downloads folder
Then I select the Request Report button excel file is produced called Chemicals of Concern.csv and save as Chemicals of Concern
Given I confirm that an excel file is produced called Chemicals of Concern.csv and save as Chemicals of Concern
Given I click Close in the Report Download popup
And I confirm the csv file saved as Chemicals of Concern can be opened and contains data
Given I delete the excel file saved as Chemicals of Concern
Then I confirm the most recent file has the following information Report Name: Chemicals of Concern File Type: CSV Requested By: WERCS Test_Automation_ProductsAccount
Then I confirm there is a Download button for the most recent report
Then I click the Download button for the most recent report with Report Name: Chemicals of Concern File Type: CSV Requested By: WERCS Test_Automation_ProductsAccount
Given I confirm that an csv file is produced called Chemicals of Concern.csv and save as Chemicals of Concern
And I confirm the zip csv file saved as Chemicals of Concern can be opened and contains data
Given I click Close in the Report Download popup
Given I delete the excel file saved as Chemicals of Concern


















































@TestCase:140997
Scenario: [140997] California Proposition 65 - CSV Zip File
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Given I click the My Reports icon in the QuickLinks Pane
Given Under the Supplier Reports menu I choose: California Proposition 65 - Registrations Prior to August 30, 2018
Then I select CSV from the Select File Type
Given I select the Zip Report Checkbox
Then I Delete the file with name: California Proposition 65  Registrations Prior to August 30 2018.zip from the downloads folder
Then I Delete the file with name: California Proposition 65  Registrations Prior to August 30 2018.csv from the downloads folder
Then I select the Request Report button zip file is produced called California Proposition 65  Registrations Prior to August 30 2018.zip and save as California Proposition 65  Registrations Prior to August 30 2018
Given I confirm that an zip file is produced called California Proposition 65  Registrations Prior to August 30 2018.zip and save as California Proposition 65  Registrations Prior to August 30 2018
Given I click Close in the Report Download popup
And I confirm the zip csv file saved as California Proposition 65  Registrations Prior to August 30 2018 can be opened and contains data
Given I delete the excel file saved as California Proposition 65  Registrations Prior to August 30 2018
Then I Delete the file with name: California Proposition 65  Registrations Prior to August 30 2018.zip from the downloads folder
Then I Delete the file with name: California Proposition 65  Registrations Prior to August 30 2018.csv from the downloads folder
Given Under the Supplier Reports menu I choose: California Proposition 65 - Registrations Prior to August 30, 2018
Then I confirm the most recent file has the following information Report Name: California Proposition 65 - Registrations Prior to August 30, 2018 File Type: CSV (Zip) Requested By: 0euotm7bf97k
Then I confirm there is a Download button for the most recent report
Then I click the Download button for the most recent report with Report Name: California Proposition 65 - Registrations Prior to August 30, 2018 File Type: CSV (Zip) Requested By: 0euotm7bf97k
Given I confirm that an zip file is produced called California Proposition 65  Registrations Prior to August 30 2018.zip and save as California Proposition 65  Registrations Prior to August 30 2018
And I confirm the zip csv file saved as California Proposition 65  Registrations Prior to August 30 2018 can be opened and contains data
Given I click Close in the Report Download popup
Given I delete the file saved as California Proposition 65  Registrations Prior to August 30 2018
Then I Delete the file with name: California Proposition 65  Registrations Prior to August 30 2018.zip from the downloads folder
Then I Delete the file with name: California Proposition 65  Registrations Prior to August 30 2018.csv from the downloads folder
Given I Delete the directory and its contents with name: ExtractFolder from the downloads folder

@TestCase:140683
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
Then I confirm the most recent file has the following information Report Name: Battery-Containing Products File Type: CSV (Zip) Requested By: 0euotm7bf97k
Then I confirm there is a Download button for the most recent report
Then I click the Download button for the most recent report with Report Name: Battery-Containing Products File Type: CSV (Zip) Requested By: 0euotm7bf97k
Given I confirm that an zip file is produced called Battery-Containing Products.zip and save as BatteryContaining Products
And I confirm the zip csv file saved as BatteryContaining Products can be opened and contains data
Given I click Close in the Report Download popup
Given I delete the file saved as BatteryContaining Products
Then I Delete the file with name: Battery-Containing Products.zip from the downloads folder
Then I Delete the file with name: BatteryContaining Products.csv from the downloads folder
Given I Delete the directory and its contents with name: ExtractFolder from the downloads folder

@TestCase:141005
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
Then I confirm the most recent file has the following information Report Name: Eligible to Obsolete File Type: CSV (Zip) Requested By: WERCS Test_Automation_ProductsAccount
Then I confirm there is a Download button for the most recent report
Then I click the Download button for the most recent report with Report Name: Eligible to Obsolete File Type: CSV (Zip) Requested By: WERCS Test_Automation_ProductsAccount
Given I confirm that an zip file is produced called Eligible to Obsolete.zip and save as Eligible to Obsolete
And I confirm the zip csv file saved as Eligible to Obsolete can be opened and contains data
Given I click Close in the Report Download popup
Given I delete the file saved as Eligible to Obsolete
Then I Delete the file with name: Eligible to Obsolete.zip from the downloads folder
Then I Delete the file with name: Eligible to Obsolete.csv from the downloads folder

@TestCase:141023
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
Then I confirm the most recent file has the following information Report Name: Pesticide Registrations File Type: CSV (Zip) Requested By: WERCS Test_Automation_ProductsAccount
Then I confirm there is a Download button for the most recent report
Then I click the Download button for the most recent report with Report Name: Pesticide Registrations File Type: CSV (Zip) Requested By: WERCS Test_Automation_ProductsAccount
Given I confirm that an zip file is produced called Pesticide Registrations.zip and save as Pesticide Registrations
And I confirm the zip csv file saved as Pesticide Registrations can be opened and contains data
Given I click Close in the Report Download popup
Given I delete the file saved as Pesticide Registrations
Then I Delete the file with name: Pesticide Registrations.zip from the downloads folder
Then I Delete the file with name: Pesticide Registrations.csv from the downloads folder
Given I Delete the directory and its contents with name: ExtractFolder from the downloads folder






@TestCase:141028
Scenario: [141028] Registration Updates Not Submitted - CSV Zip File
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Given I click the My Reports icon in the QuickLinks Pane
Given Under the Supplier Reports menu I choose: Registrations Revised - Not Yet Submitted
Then I select CSV from the Select File Type
Given I select the Zip Report Checkbox
Then I Delete the file with name: Registrations Revised  Not Yet Submitted.zip from the downloads folder
Then I Delete the file with name: Registrations Revised  Not Yet Submitted.csv from the downloads folder
Then I select the Request Report button zip file is produced called Registrations Revised  Not Yet Submitted.zip and save as Registrations Revised  Not Yet Submitted
Given I confirm that an zip file is produced called Registrations Revised  Not Yet Submitted.zip and save as Registrations Revised  Not Yet Submitted
Given I click Close in the Report Download popup
And I confirm the zip csv file saved as Registrations Revised  Not Yet Submitted can be opened and contains data
Given I delete the excel file saved as Registrations Revised  Not Yet Submitted
Then I Delete the file with name: Registrations Revised  Not Yet Submitted.zip from the downloads folder
Then I Delete the file with name: Registrations Revised  Not Yet Submitted.csv from the downloads folder
Given Under the Supplier Reports menu I choose: Registrations Revised - Not Yet Submitted
Then I confirm the most recent file has the following information Report Name: Registrations Revised - Not Yet Submitted File Type: CSV (Zip) Requested By: WERCS Test_Automation_ProductsAccount
Then I confirm there is a Download button for the most recent report
Then I click the Download button for the most recent report with Report Name: Registrations Revised - Not Yet Submitted File Type: CSV (Zip) Requested By: WERCS Test_Automation_ProductsAccount
Given I confirm that an zip file is produced called Registrations Revised - Not Yet Submitted.zip and save as Registrations Revised - Not Yet Submitted
And I confirm the zip csv file saved as Registrations Revised - Not Yet Submitted can be opened and contains data
Given I click Close in the Report Download popup
Given I delete the file saved as Registrations Revised - Not Yet Submitted
Then I Delete the file with name: Registrations Revised - Not Yet Submitted.zip from the downloads folder
Then I Delete the file with name: Registrations Revised - Not Yet Submitted.csv from the downloads folder
Given I Delete the directory and its contents with name: ExtractFolder from the downloads folder

@TestCase:141029
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
Then I click the Download button for the most recent report with Report Name: Subscription Product Types File Type: CSV (Zip) Requested By: WERCS Test_Automation_ProductsAccount
Given I confirm that an zip file is produced called Subscription Product Types.zip and save as Subscription Product Types
And I confirm the zip csv file saved as Subscription Product Types can be opened and contains data
Given I click Close in the Report Download popup
Given I delete the file saved as Subscription Product Types
Then I Delete the file with name: Subscription Product Types.zip from the downloads folder
Then I Delete the file with name: Subscription Product Types.csv from the downloads folder
Given I Delete the directory and its contents with name: ExtractFolder from the downloads folder

@TestCase:141034
Scenario: [141034] UPC Duplication - CSV Zip File
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Given I click the My Reports icon in the QuickLinks Pane
Given Under the Supplier Reports menu I choose: UPCs Duplicated within Account
Then I select CSV from the Select File Type
Given I select the Zip Report Checkbox
Then I Delete the file with name: UPCs Duplicated within Account.zip from the downloads folder
Then I Delete the file with name: UPCs Duplicated within Account.csv from the downloads folder
Then I select the Request Report button zip file is produced called UPCs Duplicated within Account.zip and save as UPCs Duplicated within Account
Given I confirm that an zip file is produced called UPCs Duplicated within Account.zip and save as UPCs Duplicated within Account
Given I click Close in the Report Download popup
And I confirm the zip csv file saved as UPCs Duplicated within Account can be opened and contains data
Given I delete the excel file saved as UPCs Duplicated within Account
Then I Delete the file with name: UPCs Duplicated within Account.zip from the downloads folder
Then I Delete the file with name: UPCs Duplicated within Account.csv from the downloads folder
Given Under the Supplier Reports menu I choose: UPCs Duplicated within Account
Then I confirm the most recent file has the following information Report Name: UPCs Duplicated within Account File Type: CSV (Zip) Requested By: WERCS Test_Automation_ProductsAccount
Then I confirm there is a Download button for the most recent report
Then I click the Download button for the most recent report with Report Name: UPCs Duplicated within Account File Type: CSV (Zip) Requested By: WERCS Test_Automation_ProductsAccount
Given I confirm that an zip file is produced called UPCs Duplicated within Account.zip and save as UPCs Duplicated within Account
And I confirm the zip csv file saved as UPCs Duplicated within Account can be opened and contains data
Given I click Close in the Report Download popup
Given I delete the file saved as UPCs Duplicated within Account
Then I Delete the file with name: UPCs Duplicated within Account.zip from the downloads folder
Then I Delete the file with name: UPCs Duplicated within Account.csv from the downloads folder
Given I Delete the directory and its contents with name: ExtractFolder from the downloads folder

@TestCase:141036
Scenario: [141036] Volatile Organic Compounds - CSV Zip File
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Given I click the My Reports icon in the QuickLinks Pane
Given Under the Supplier Reports menu I choose: VOC-related Compounds
Then I select CSV from the Select File Type
Given I select the Zip Report Checkbox
Then I Delete the file with name: VOC related Compounds.zip from the downloads folder
Then I Delete the file with name: VOC related Compounds.csv from the downloads folder
Then I select the Request Report button zip file is produced called VOC related Compounds.zip and save as VOC-related Compounds
Given I confirm that an zip file is produced called VOC related Compounds.zip and save as VOC-related Compounds
Given I click Close in the Report Download popup
And I confirm the zip csv file saved as VOC-related Compounds can be opened and contains data
Given I delete the excel file saved as VOC-related Compounds
Then I Delete the file with name: VOC related Compounds.zip from the downloads folder
Then I Delete the file with name: VOC related Compounds.csv from the downloads folder
Given Under the Supplier Reports menu I choose: VOC-related Compounds
Then I confirm the most recent file has the following information Report Name: VOC-related Compounds File Type: CSV (Zip) Requested By: WERCS Test_Automation_ProductsAccount
Then I confirm there is a Download button for the most recent report
Then I click the Download button for the most recent report with Report Name: VOC-related Compounds File Type: CSV (Zip) Requested By: WERCS Test_Automation_ProductsAccount
Given I confirm that an zip file is produced called VOC related Compounds.zip and save as VOC-related Compounds
And I confirm the zip csv file saved as VOC-related Compounds can be opened and contains data
Given I click Close in the Report Download popup
Given I delete the file saved as VOC-related Compounds
Then I Delete the file with name: VOC related Compounds.zip from the downloads folder
Then I Delete the file with name: VOC related Compounds.csv from the downloads folder
Given I Delete the directory and its contents with name: ExtractFolder from the downloads folder

@TestCase:141041
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
Then I click the Download button for the most recent report with Report Name: Waste Classification Summary File Type: CSV (Zip) Requested By: WERCS Test_Automation_ProductsAccount
Given I confirm that an zip file is produced called Waste Classification Summary.zip and save as Waste Classification Summary
And I confirm the zip csv file saved as Waste Classification Summary can be opened and contains data
Given I click Close in the Report Download popup
Given I delete the file saved as Waste Classification Summary
Then I Delete the file with name: Waste Classification Summary.zip from the downloads folder
Then I Delete the file with name: Waste Classification Summary.csv from the downloads folder
Given I Delete the directory and its contents with name: ExtractFolder from the downloads folder

@tfs_design
@ignore
@TestCase:141799
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
Then I click the Download button for the most recent report with Report Name: Chemicals of Concern File Type: CSV (Zip) Requested By: WERCS Test_Automation_ProductsAccount
Given I confirm that an zip file is produced called Chemicals of Concern.zip and save as Chemicals of Concern
And I confirm the zip csv file saved as Chemicals of Concern can be opened and contains data
Given I click Close in the Report Download popup
Given I delete the file saved as Chemicals of Concern
Then I Delete the file with name: Chemicals of Concern.zip from the downloads folder
Then I Delete the file with name: Chemicals of Concern.csv from the downloads folder
Given I Delete the directory and its contents with name: ExtractFolder from the downloads folder
