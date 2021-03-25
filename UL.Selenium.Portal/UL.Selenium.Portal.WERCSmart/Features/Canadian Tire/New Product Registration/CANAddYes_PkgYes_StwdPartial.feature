@Shared
@LandingPage
@Login
@Homepage
@Signup
@wercsmart
@NewProduct
@ProductGrid
@DataSummarySheet
@wercsmart
@RetailPartners
@SHA
@UPC
@run_CANAddYes_PkgYes_StwdPartial
Feature: Account Canada Address(Yes) Package types(Yes) Stewardship(Partial)

@ScenarioId:1242
Scenario: [85762] Account all Canada data - Partial stewardship, SOLD = US Only, PL = YES, Packaging type IS NOT required
	Given I log in with the account saved in TReVor as: CanadaHasPackandPartialStewardship
	Given I generate a random UPC number and save as: UPC85762
	And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bubble solution
	Then I save the product information as: TestCase85754
Given I call Shared Step 63860 (Product Information - US, No(child), No(OSHA), No(DSV), Yes(PLP), No(GNFR))
	And I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
	And I call Shared Step 29181 (Ingredients - add any chemical) with name: Chlorine
	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	And I call Shared Step  (Select Retailers Walgreens and enter additional requirements field - Indicate full name of product, as sold via this retailer)
	And I call Shared Step 85909 (UPC - Confirm Package type link and drop down not shown - Add UPC data - Continue) for UPC: saved as UPC85762, container type: Plastic Container and size: 12 click continue
	Given in the Regulatory Documents to Provide page I click Continue
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase85762

@ScenarioId:1243
Scenario: [85763] Account all Canada data - Partial stewardship, SOLD = US Only, PL = NO, Packaging type IS NOT required
	Given I log in with the account saved in TReVor as: CanadaHasPackandPartialStewardship
	Given I generate a random UPC number and save as: UPC85763
	And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bubble solution
	Then I save the product information as: TestCase85763
	Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	And I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
	And I call Shared Step 29181 (Ingredients - add any chemical) with name: Chlorine
	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Walgreens
	And I call Shared Step 85909 (UPC - Confirm Package type link and drop down not shown - Add UPC data - Continue) for UPC: saved as UPC85763, container type: Plastic Container and size: 12 click continue
	Given in the Regulatory Documents to Provide page I click Continue
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase85763

@ScenarioId:1244
Scenario: [85764] Account all Canada data - Partial stewardship, SOLD = Canada Only, PL = YES, Packaging type IS required
	Given I log in with the account saved in TReVor as: CanadaHasPackandPartialStewardship
	Given I generate a random UPC number and save as: UPC85764
	And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bubble solution
	Then I save the product information as: TestCase85764
	And I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
	And I call Shared Step 85730 - Additional Product Information - Canada Only - Child (NO), GHS (NO), DSV (NO), PLP(YES), GNFR (NO), Continue
	And I call Shared Step 29181 (Ingredients - add any chemical) with name: Chlorine
	And I call Shared Step 57911 (Regulatory Information 1 - CEPA only shown - Continue - Happy Path)
	And I call Shared Step  (Select Retailers Canadian Tire and enter additional requirements field - Indicate full name of product, as sold via this retailer)
	And In the UPC page I should see Add new Packaging Type link
	And I click the 'Add UPC' button
	And I enter UPC Number: saved as UPC85764
	And I Select a container type from the drop down list
	And I enter Size Value: 12
	And I Confirm the Package Type drop down list shows a Packaging type available for selection - Do not select one
	And I click continue
	And I Confirm This is a required field. error message is shown below the Package Type field
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase85764

@ScenarioId:1245
Scenario: [85765] Account all Canada data - Partial stewardship, SOLD = Canada Only, PL = NO, Packaging type IS required
	Given I log in with the account saved in TReVor as: CanadaHasPackandPartialStewardship
	Given I generate a random UPC number and save as: UPC85765
	And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bubble solution
	Then I save the product information as: TestCase85765
	And I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
	And I call Shared Step 78879 - Additional Product Information - Canada Only - Child (NO), GHS (NO), DSV (NO), PLP (NO), GNFR (NO), Continue
	And I call Shared Step 29181 (Ingredients - add any chemical) with name: Chlorine
	And I call Shared Step 57911 (Regulatory Information 1 - CEPA only shown - Continue - Happy Path)
	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Canadian Tire
	And In the UPC page I should see Add new Packaging Type link
	And I click the 'Add UPC' button
	And I enter UPC Number: saved as UPC85765
	And I Select a container type from the drop down list
	And I enter Size Value: 12
	And I Confirm the Package Type drop down list shows a Packaging type available for selection - Do not select one
	And I click continue
	And I Confirm This is a required field. error message is shown below the Package Type field
	And I Select a package type from the drop down list
	Given in the Universal Product Code (UPC) page I click Continue
	Then The alert message is not displayed with text: STOP! When selecting authoring of a Safety Data Sheet (SDS) for Canada, you need to provide your Canada address. Please go to the My Account area, and update this information in.
	Given in the Regulatory Documents to Provide page I click Continue
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase85765

@ScenarioId:1246
Scenario: [85766] Account all Canada data - Partial stewardship, SOLD = US & Canada, PL = YES, Packaging type IS required
	Given I log in with the account saved in TReVor as: CanadaHasPackandPartialStewardship
	Given I generate a random UPC number and save as: UPC85766
	And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bubble solution
	Then I save the product information as: TestCase85766
	And I call Shared Step 85284 - Product Information - US & Canada, Child (No), OSHA (No), DSV (No), PLP (YES), GNFR (No), Continue
And I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
	And I call Shared Step 29181 (Ingredients - add any chemical) with name: Chlorine dioxide
	And I call Shared Step 57637 (Regulatory Information 1 - TSCA & CEPA shown, No to PROP 65 - Continue - Happy Path)
	And I call Shared Step  (Select Retailers Canadian Tire and enter additional requirements field - Indicate full name of product, as sold via this retailer)
	And In the UPC page I should see Add new Packaging Type link
	And I click the 'Add UPC' button
	And I enter UPC Number: saved as UPC85766
	And I Select a container type from the drop down list
	And I enter Size Value: 12
	And I Confirm the Package Type drop down list shows a Packaging type available for selection - Do not select one
	And I click continue
	And I Confirm This is a required field. error message is shown below the Package Type field
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase85766

@ScenarioId:1247
Scenario: [85767] Account has Canada address and packaging, SOLD US & Canada, PL = NO, packaging type is required
	Given I log in with the account saved in TReVor as: CanadaHasPackandPartialStewardship
	And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bubble solution
	Then I save the product information as: TestCase85767
	And I call Shared Step 62678 (Product Information - US & Canada, No Child, No OSHA, NO Direct ship, No PL, No NGFR - Continue, Happy path)
	And I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
	And I call Shared Step 29181 (Ingredients - add any chemical) with name: Chlorine
	And I call Shared Step 57637 (Regulatory Information 1 - TSCA & CEPA shown, No to PROP 65 - Continue - Happy Path)
	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Canadian Tire
	And I click continue
	And In the UPC page I should see Add new Packaging Type link
	Given I generate a random UPC number and save as: UPC85767
	And I click the 'Add UPC' button
	And I enter UPC Number: saved as UPC85767
	And I Select a container type from the drop down list
	And I enter Size Value: 12
	And I Confirm the Package Type drop down list shows a Packaging type available for selection - Do not select one
	And I click continue
	And I Confirm This is a required field. error message is shown below the Package Type field
	And I Select a package type from the drop down list
	Given in the Universal Product Code (UPC) page I click Continue
	Then The alert message is not displayed with text: STOP! When selecting authoring of a Safety Data Sheet (SDS) for Canada, you need to provide your Canada address. Please go to the My Account area, and update this information in.
	Given in the Regulatory Documents to Provide page I click Continue
	And I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase85767
