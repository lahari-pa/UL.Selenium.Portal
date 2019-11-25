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

@ScenarioId:5947
Scenario:[113004] UPC Data Expansion: Transportation and Name: My Reports: UPC Error Details
	Given I log in with the account saved in TReVor as: Error Report User
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
	Then I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
	Then I save the product information as: Product114216
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
	Then I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: Product114216
