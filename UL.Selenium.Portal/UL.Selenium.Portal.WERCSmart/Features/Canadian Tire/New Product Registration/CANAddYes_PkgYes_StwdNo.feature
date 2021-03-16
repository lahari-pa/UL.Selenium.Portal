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
@run_CANAddYes_PkgYes_StwdNo

Feature: Account Canada Address(Yes) Package types (Yes) Stewardship (No)


@ScenarioId:1236
Scenario: [85325] Account has Canada address and packaging, SOLD US & Canada, PL = NO, packaging type is required
Given I log in with the account saved in TReVor as: CanadaHasAddressPackaging
And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bubble solution
Then I save the product information as: TestCase85325
And I call Shared Step 62678 (Product Information - US & Canada, No Child, No OSHA, NO Direct ship, No PL, No NGFR - Continue, Happy path)
And I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Chlorine
And I call Shared Step 57637 (Regulatory Information 1 - TSCA & CEPA shown, No to PROP 65 - Continue - Happy Path)
Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Canadian Tire
And I click continue
#And I should see the Universal Product Code (UPC) Page
And In the UPC page I should see Add new Packaging Type link
Given I generate a random UPC number and save as: UPC85325
And I click the 'Add UPC' button
And I enter UPC Number: saved as UPC85325
And I Select a container type from the drop down list
And I enter Size Value: 12
And I Confirm the Package Type drop down list shows a Packaging type available for selection - Do not select one
And I click continue
And I Confirm This is a required field. error message is shown below the Package Type field
And I Select a package type from the drop down list
Given in the Universal Product Code (UPC) page I click Continue
Then The alert message is not displayed with text: STOP! When selecting authoring of a Safety Data Sheet (SDS) for Canada, you need to provide your Canada address. Please go to the My Account area, and update this information in.
Given in the Regulatory Documents to Provide page I click Continue
And I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase85325


@ScenarioId:1237
Scenario: [85740] Account has Canada address and packaging, SOLD US & Canada, PL = YES, packaging type is required
Given I log in with the account saved in TReVor as: CanadaHasAddressPackaging
Given I generate a random UPC number and save as: UPC85740
And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bubble solution
Then I save the product information as: TestCase85740
And I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
And I call Shared Step 85284 - Additional Product Information - US & Canada, Child (No), OSHA (No), DSV (No), PLP (YES), GNFR (No), Continue
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Chlorine
And I call Shared Step 57637 (Regulatory Information 1 - TSCA & CEPA shown, No to PROP 65 - Continue - Happy Path)
And I call Shared Step  (Select Retailers Canadian Tire and enter additional requirements field - Indicate full name of product, as sold via this retailer)
And In the UPC page I should see Add new Packaging Type link
And I click the 'Add UPC' button
And I enter UPC Number: saved as UPC85740
And I Select a container type from the drop down list
And I enter Size Value: 12
And I Confirm the Package Type drop down list shows a Packaging type available for selection - Do not select one
And I click continue
And I Confirm This is a required field. error message is shown below the Package Type field
And I Select a package type from the drop down list
Given in the Universal Product Code (UPC) page I click Continue
Then The alert message is not displayed with text: STOP! When selecting authoring of a Safety Data Sheet (SDS) for Canada, you need to provide your Canada address. Please go to the My Account area, and update this information in.
Given in the Regulatory Documents to Provide page I click Continue
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase85740


@ScenarioId:1238
Scenario: [85742] Account has Canada address and packaging, SOLD Canada Only, PL = NO, packaging type is required
Given I log in with the account saved in TReVor as: CanadaHasAddressPackaging
Given I generate a random UPC number and save as: UPC85742
And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bubble solution
Then I save the product information as: TestCase85742
And I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
And I call Shared Step 78879 - Additional Product Information - Canada Only - Child (NO), GHS (NO), DSV (NO), PLP (NO), GNFR (NO), Continue
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Chlorine
And I call Shared Step 57911 (Regulatory Information 1 - CEPA only shown - Continue - Happy Path)
Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Canadian Tire
And In the UPC page I should see Add new Packaging Type link
And I click the 'Add UPC' button
And I enter UPC Number: saved as UPC85742
And I Select a container type from the drop down list
And I enter Size Value: 12
And I Confirm the Package Type drop down list shows a Packaging type available for selection - Do not select one
And I click continue
And I Confirm This is a required field. error message is shown below the Package Type field
And I Select a package type from the drop down list
Given in the Universal Product Code (UPC) page I click Continue
Then The alert message is not displayed with text: STOP! When selecting authoring of a Safety Data Sheet (SDS) for Canada, you need to provide your Canada address. Please go to the My Account area, and update this information in.
Given in the Regulatory Documents to Provide page I click Continue
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase85742


@ScenarioId:1239
Scenario: [85743] Account has Canada address and packaging, SOLD Canada Only, PL = YES, packaging type is required
Given I log in with the account saved in TReVor as: CanadaHasAddressPackaging
Given I generate a random UPC number and save as: UPC85743
And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bubble solution
Then I save the product information as: TestCase85743
And I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
And I call Shared Step 85730 - Additional Product Information - Canada Only - Child (NO), GHS (NO), DSV (NO), PLP(YES), GNFR (NO), Continue
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Chlorine
And I call Shared Step 57911 (Regulatory Information 1 - CEPA only shown - Continue - Happy Path)
And I call Shared Step  (Select Retailers Canadian Tire and enter additional requirements field - Indicate full name of product, as sold via this retailer)
And In the UPC page I should see Add new Packaging Type link
And I click the 'Add UPC' button
And I enter UPC Number: saved as UPC85743
And I Select a container type from the drop down list
And I enter Size Value: 12
And I Confirm the Package Type drop down list shows a Packaging type available for selection - Do not select one
And I click continue
And I Confirm This is a required field. error message is shown below the Package Type field
And I Select a package type from the drop down list
Given in the Universal Product Code (UPC) page I click Continue
Then The alert message is not displayed with text: STOP! When selecting authoring of a Safety Data Sheet (SDS) for Canada, you need to provide your Canada address. Please go to the My Account area, and update this information in.
Given in the Regulatory Documents to Provide page I click Continue
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase85743


@ScenarioId:1240
Scenario: [85744] Account has Canada address only - SOLD = US only, PL = YES, packaging type is NOT required
Given I log in with the account saved in TReVor as: CanadaHasAddressPackaging
Given I generate a random UPC number and save as: UPC85744
And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bubble solution
Then I save the product information as: TestCase85744
And I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
Given I call Shared Step 63860 (Additional Product Information - US, No(child), No(OSHA), No(DSV), Yes(PLP), No(GNFR))
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Chlorine
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
And I call Shared Step  (Select Retailers Walgreens and enter additional requirements field - Indicate full name of product, as sold via this retailer)
And I call Shared Step 85909 (UPC - Confirm Package type link and drop down not shown - Add UPC data - Continue) for UPC: saved as UPC85744, container type: Plastic Container and size: 12 click continue
Given in the Regulatory Documents to Provide page I click Continue
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase85744


@ScenarioId:1241
Scenario: [85745] Account has Canada address and packaging, SOLD US Only, PL = NO, packaging type is NOT required
Given I log in with the account saved in TReVor as: CanadaHasAddressPackaging
Given I generate a random UPC number and save as: UPC85745
And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bubble solution
Then I save the product information as: TestCase85745
And I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
Given I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Chlorine
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Walgreens
And I call Shared Step 85909 (UPC - Confirm Package type link and drop down not shown - Add UPC data - Continue) for UPC: saved as UPC85745, container type: Plastic Container and size: 12 click continue
Given in the Regulatory Documents to Provide page I click Continue
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase85745
