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
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:ProductInformation
@PhysicalAndChemicalProp

Feature: Sprint 16

@ignore
@TestCase:112940
Scenario:[112940] Product Registration: Vendor Comment Area Revise Limit from 200 to 500 Characters and Spaces.
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Suppository, Medicinal
	Then I save the product information as: TestCase58605
	#Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Given I should see the Product Information Page
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)' to: No
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue

	Given I call Shared Step 57501 (Physical and Chemical Properties - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue)
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Glycerin      | 30      | false               | false       |            |
		| Glucose       | 30      | false               | false       |            |
		| Aqua          | 40      | false               | false       |            |
	Then I call Shared Step 132427 (Waste Classification Data- For OTC Products)
	Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	Given I call Shared Step 60567 (Upload Product Label only)
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Then I should see the Optional Comments Page for the New Product
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
@ignore
@TestCase:113004
Scenario:[113004] UPC Data Expansion: Transportation and Name: My Reports: UPC Error Details
	Given I log in with the account saved in TReVor as: ProductAccount
	And I click the My Reports icon in the QuickLinks Pane
	Then Under the Supplier Reports menu I choose: UPC Errors for The Home Depot
	# Sprint 1 - 1506182, Sprint 2 - 1505712, QA - 1520299, Staging - 1593242, TReVor var request sent
	Then in UPC Error Details WPSID box I enter product ID for the UPC Error Details report
	Then In the Supplier Reports screen I click on the Download button
	Then I wait for 3 seconds
	Then I confirm that an excel file is produced called UPC Errors for The Home Depot.xlsx and save as 113004
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
