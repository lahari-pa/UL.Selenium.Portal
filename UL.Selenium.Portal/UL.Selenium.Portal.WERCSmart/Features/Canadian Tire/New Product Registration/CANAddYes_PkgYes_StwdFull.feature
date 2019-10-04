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
@UPC
@SHA

@run_CANAddYes_PkgYes_StwdFull

Feature: Account Canada Address(Yes) Package types (Yes) Stewardship (FULL)

@ScenarioId:1230
Scenario: [85329] Account has all Canada data - ALL stewardship, SOLD = US & Canada, PL = NO, Packaging type IS NOT required
Given I login into the WERCSmart Portal - Canada has all data account
Given I generate a random UPC number and save as: UPC85329
And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bubble solution
Then I save the product information as: TestCase85742
And I call Shared Step 57514 (Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path)
And I call Shared Step 62678 (Additional Product Information - US & Canada, No Child, No OSHA, NO Direct ship, No PL, No NGFR - Continue, Happy path)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Chlorine
And I call Shared Step 57637 (Regulatory Information 1 - TSCA & CEPA shown, No to PROP 65 - Continue - Happy Path)
Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Canadian Tire
And In the UPC page I should see Add new Packaging Type link
And I click the 'Add UPC' button
And I enter UPC Number: saved as UPC85329
And I Select a container type from the drop down list
And I enter Size Value: 12
And I Confirm the Package Type drop down list shows a Packaging type available for selection - Do not select one
#And I click continue
#And I Confirm This is a required field. error message is shown below the Package Type field
Given in the Universal Product Code (UPC) page I click Continue
Then The alert message is not displayed with text: STOP! When selecting authoring of a Safety Data Sheet (SDS) for Canada, you need to provide your Canada address. Please go to the My Account area, and update this information in.
Given in the Regulatory Documents to Provide page I click Continue
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase85329

@ScenarioId:1231
Scenario: [85750] Account has all Canada data - ALL stewardship, SOLD = US & Canada, PL = YES, Packaging type IS required
Given I login into the WERCSmart Portal - Canada has all data account
Given I generate a random UPC number and save as: UPC85750
And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bubble solution
Then I save the product information as: TestCase85750
And I call Shared Step 57514 (Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path)
And I call Shared Step 85284 - Additional Product Information - US & Canada, Child (No), OSHA (No), DSV (No), PLP (YES), GNFR (No), Continue
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Chlorine
And I call Shared Step 57637 (Regulatory Information 1 - TSCA & CEPA shown, No to PROP 65 - Continue - Happy Path)
And I call Shared Step  (Select Retailers Canadian Tire and enter additional requirements field - Indicate full name of product, as sold via this retailer)
And In the UPC page I should see Add new Packaging Type link
And I click the 'Add UPC' button
And I enter UPC Number: saved as UPC85750
And I Select a container type from the drop down list
And I enter Size Value: 12
And I Confirm the Package Type drop down list shows a Packaging type available for selection - Do not select one
And I click continue
And I Confirm This is a required field. error message is shown below the Package Type field
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase85750

@ScenarioId:1232
Scenario: [85751] Account has all Canada data - ALL stewardship, SOLD = Canada Only, PL = NO, Packaging type IS NOT required
Given I login into the WERCSmart Portal - Canada has all data account
Given I generate a random UPC number and save as: UPC85750
And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bubble solution
Then I save the product information as: TestCase85750
And I call Shared Step 57514 (Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path)
And I call Shared Step 62678 (Additional Product Information - US & Canada, No Child, No OSHA, NO Direct ship, No PL, No NGFR - Continue, Happy path)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Chlorine
And I call Shared Step 57637 (Regulatory Information 1 - TSCA & CEPA shown, No to PROP 65 - Continue - Happy Path)
Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Canadian Tire
And In the UPC page I should see Add new Packaging Type link
And I click the 'Add UPC' button
And I enter UPC Number: saved as UPC85750
And I Select a container type from the drop down list
And I enter Size Value: 12
And I Confirm the Package Type drop down list shows a Packaging type available for selection - Do not select one
#And I click continue
#And I Confirm This is a required field. error message is shown below the Package Type field
Given in the Universal Product Code (UPC) page I click Continue
Then The alert message is not displayed with text: STOP! When selecting authoring of a Safety Data Sheet (SDS) for Canada, you need to provide your Canada address. Please go to the My Account area, and update this information in.
Given in the Regulatory Documents to Provide page I click Continue
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase85750

# Assigned to Barrett, Beverly
# NetProjects10\WercsSmart Portal\WERCSmart\Canadian Tire - Blue Box Program\New Product Registration\4. Account Canada address(Yes), Package type (Yes), Stewardship (FULL)
@ScenarioId:1233
Scenario: [85752] Account has all Canada data - ALL stewardship, SOLD = Canada Only, PL = YES, Packaging type IS required
	#Given [Shared Step 85328 - Login to WERCSmart - Canada - Address (Yes), Packaging (Yes), Stewardship (Full)]
	Given I login into the WERCSmart Portal - Canada has all data account
	And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	#And I In the shared step below use Bubble solution as your product type
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bubble solution
	And I call Shared Step 57514 (Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path)
	And I call Shared Step 85730 - Additional Product Information - Canada Only - Child (NO), GHS (NO), DSV (NO), PLP(YES), GNFR (NO), Continue
	And I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium Hydroxide
	And I call Shared Step 57911 (Regulatory Information 1 - CEPA only shown - Continue - Happy Path)
	And In the 'Select Retailers' window I select the retailer: Canadian Tire
	And For retailer: Canadian Tire I add additional requirements: Additional requirements: Canadian Tire
	And I click continue
	And I should see the Universal Product Code (UPC) Page
	And In the UPC page I should see Add new Packaging Type link
	Given I generate a random UPC number and save as: UPC85752
	And I click the 'Add UPC' button
	And I enter UPC Number: saved as UPC85752
	And I Select a container type from the drop down list
	And I enter Size Value: 12
	And I Confirm the Package Type drop down list shows a Packaging type available for selection - Do not select one
	And I click continue
	And I Confirm This is a required field. error message is shown below the Package Type field
	And I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase85752

@ScenarioId:1234
Scenario: [85753] Account has all Canada data - ALL stewardship, SOLD = US Only, PL = NO, Packaging type IS NOT required
Given I login into the WERCSmart Portal - Canada has all data account
Given I generate a random UPC number and save as: UPC85753
And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bubble solution
Then I save the product information as: TestCase85753
And I call Shared Step 57514 (Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path)
Given I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Chlorine
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Costco
And I call Shared Step 85909 (UPC - Confirm Package type link and drop down not shown - Add UPC data - Continue) for UPC: saved as UPC85753, container type: Plastic Container and size: 12 click continue
Given in the Regulatory Documents to Provide page I click Continue
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase85753

@ScenarioId:1235
Scenario: [85754] Account has all Canada data - ALL stewardship, SOLD = US Only, PL = YES, Packaging type IS NOT required
Given I login into the WERCSmart Portal - Canada has all data account
Given I generate a random UPC number and save as: UPC85754
And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bubble solution
Then I save the product information as: TestCase85754
And I call Shared Step 57514 (Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path)
Given I call Shared Step 63860 (Additional Product Information - US, No(child), No(OSHA), No(DSV), Yes(PLP), No(GNFR))
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Chlorine
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
And I call Shared Step  (Select Retailers Costco and enter additional requirements field - Indicate full name of product, as sold via this retailer)
And I call Shared Step 85909 (UPC - Confirm Package type link and drop down not shown - Add UPC data - Continue) for UPC: saved as UPC85754, container type: Plastic Container and size: 12 click continue
Given in the Regulatory Documents to Provide page I click Continue
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase85754
