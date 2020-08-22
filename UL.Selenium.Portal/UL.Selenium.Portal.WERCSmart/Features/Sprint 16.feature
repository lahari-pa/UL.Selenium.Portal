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
@run_Sprint16
Feature: Sprint 16


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
@ScenarioId:5947
Scenario:[113004] UPC Data Expansion: Transportation and Name: My Reports: UPC Error Details
	Given I log in with the account saved in TReVor as: Error Report User
	And I click the My Reports icon in the QuickLinks Pane
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
