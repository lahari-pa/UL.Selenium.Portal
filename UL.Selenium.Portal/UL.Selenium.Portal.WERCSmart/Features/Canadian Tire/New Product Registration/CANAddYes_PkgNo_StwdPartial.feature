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
@run_CANAddYes_PkgNo_StwdPartial

Feature: Account Canada Address(Yes) Package types(No) Stewardship(Partial)


@ScenarioId:1254
Scenario: [85784] Account all Canada data - Partial stewardship, SOLD = US Only, PL = YES, Packaging type IS NOT required
Given I log in with the account saved in TReVor as: CanadaNoPkgStwdPartial
Given I generate a random UPC number and save as: UPC85784
And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bubble solution
Then I save the product information as: TestCase85784
And I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
Given I call Shared Step 63860 (Additional Product Information - US, No(child), No(OSHA), No(DSV), Yes(PLP), No(GNFR))
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Chlorine
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
And I call Shared Step  (Select Retailers Walgreens and enter additional requirements field - Indicate full name of product, as sold via this retailer)
And I call Shared Step 85909 (UPC - Confirm Package type link and drop down not shown - Add UPC data - Continue) for UPC: saved as UPC85784, container type: Plastic Container and size: 12 click continue
Given in the Regulatory Documents to Provide page I click Continue
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase85784


@ScenarioId:1255
Scenario: [85785] Account Canada Address and Partial stewardship, SOLD = US Only, PL = NO, Packaging type IS NOT required
Given I log in with the account saved in TReVor as: CanadaNoPkgStwdPartial
Given I generate a random UPC number and save as: UPC85785
And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bubble solution
Then I save the product information as: TestCase85785
And I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
Given I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Chlorine
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Walgreens
And I call Shared Step 85909 (UPC - Confirm Package type link and drop down not shown - Add UPC data - Continue) for UPC: saved as UPC85785, container type: Plastic Container and size: 12 click continue
Given in the Regulatory Documents to Provide page I click Continue
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase85785


@ScenarioId:1256
Scenario: [85786] Account Canada address and Partial stewardship, SOLD = Canada Only, PL = YES, Packaging type IS required
Given I log in with the account saved in TReVor as: CanadaNoPkgStwdPartial
Given I generate a random UPC number and save as: UPC85786
And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bubble solution
Then I save the product information as: TestCase85786
And I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
And I call Shared Step 85284 - Additional Product Information - US & Canada, Child (No), OSHA (No), DSV (No), PLP (YES), GNFR (No), Continue
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Chlorine
And I call Shared Step 57637 (Regulatory Information 1 - TSCA & CEPA shown, No to PROP 65 - Continue - Happy Path)
And I call Shared Step  (Select Retailers Canadian Tire and enter additional requirements field - Indicate full name of product, as sold via this retailer)
And In the UPC page I should see Add new Packaging Type link
And I click the 'Add UPC' button
And I enter UPC Number: saved as UPC85786
And I Select a container type from the drop down list
And I enter Size Value: 12
And I click continue
And I Confirm This is a required field. error message is shown below the Package Type field
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase85786


@ScenarioId:1257
Scenario: [85787] Account Canada address and - Partial stewardship, SOLD = Canada Only, PL = NO, Packaging type IS required
Given I log in with the account saved in TReVor as: CanadaNoPkgStwdPartial
And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bubble solution
Then I save the product information as: TestCase85787
And I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
And I call Shared Step 62678 (Additional Product Information - US & Canada, No Child, No OSHA, NO Direct ship, No PL, No NGFR - Continue, Happy path)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Chlorine
And I call Shared Step 57637 (Regulatory Information 1 - TSCA & CEPA shown, No to PROP 65 - Continue - Happy Path)
Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Canadian Tire
And I click continue
And In the UPC page I should see Add new Packaging Type link
Given I generate a random UPC number and save as: UPC85787
And I click the 'Add UPC' button
And I enter UPC Number: saved as UPC85787
And I Select a container type from the drop down list
And I enter Size Value: 12
And I click continue
And I Confirm This is a required field. error message is shown below the Package Type field
And I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase85787


@ScenarioId:1258
Scenario: [85788] Account all Canada address and Partial stewardship, SOLD = US & Canada, PL = YES, Packaging type IS required
Given I log in with the account saved in TReVor as: CanadaNoPkgStwdPartial
Given I generate a random UPC number and save as: UPC85788
And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bubble solution
Then I save the product information as: TestCase85788
And I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
And I call Shared Step 85284 - Additional Product Information - US & Canada, Child (No), OSHA (No), DSV (No), PLP (YES), GNFR (No), Continue
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Chlorine
And I call Shared Step 57637 (Regulatory Information 1 - TSCA & CEPA shown, No to PROP 65 - Continue - Happy Path)
And I call Shared Step  (Select Retailers Canadian Tire and enter additional requirements field - Indicate full name of product, as sold via this retailer)
And In the UPC page I should see Add new Packaging Type link
And I click the 'Add UPC' button
And I enter UPC Number: saved as UPC85788
And I Select a container type from the drop down list
And I enter Size Value: 12
And I click continue
And I Confirm This is a required field. error message is shown below the Package Type field
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase85788


@ScenarioId:1259
Scenario: [85789] Account Canada address and Partial stewardship, SOLD = US & Canada, PL = NO, Packaging type IS required
Given I log in with the account saved in TReVor as: CanadaNoPkgStwdPartial
And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bubble solution
Then I save the product information as: TestCase85789
And I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
And I call Shared Step 62678 (Additional Product Information - US & Canada, No Child, No OSHA, NO Direct ship, No PL, No NGFR - Continue, Happy path)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Chlorine
And I call Shared Step 57637 (Regulatory Information 1 - TSCA & CEPA shown, No to PROP 65 - Continue - Happy Path)
Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Canadian Tire
And I click continue
And In the UPC page I should see Add new Packaging Type link
Given I generate a random UPC number and save as: UPC85789
And I click the 'Add UPC' button
And I enter UPC Number: saved as UPC85789
And I Select a container type from the drop down list
And I enter Size Value: 12
And I click continue
And I Confirm This is a required field. error message is shown below the Package Type field
And I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase85789
