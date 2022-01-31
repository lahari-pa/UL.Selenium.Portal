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
@run_CANAddNo_PkgNo_StwdPartial

Feature: Account Canada Address(No), Package Type (No), Stewardship (Partial)


@TestCase:85855
Scenario: [85855] Account Partial stewardship Only, SOLD = US Only, PL = YES, Packaging type IS NOT required
Given I log in with the account saved in TReVor as: PartialStewardshipOnly
Given I generate a random UPC number and save as: UPC85855
And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bubble solution
Then I save the product information as: TestCase85855
Given I call Shared Step 63860 (Product Information - US, No(child), No(OSHA), No(DSV), Yes(PLP), No(GNFR))
And I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Chlorine
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
And I call Shared Step  (Select Retailers Walgreens and enter additional requirements field - Indicate full name of product, as sold via this retailer)
And I call Shared Step 85909 (UPC - Confirm Package type link and drop down not shown - Add UPC data - Continue) for UPC: saved as UPC85855, container type: Plastic Container and size: 12 click continue
Given in the Regulatory Documents to Provide page I click Continue
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase85855


@TestCase:85856
Scenario: [85856] Account Partial stewardship Only, SOLD = US Only, PL = NO, Packaging type IS NOT required
Given I log in with the account saved in TReVor as: PartialStewardshipOnly
Given I generate a random UPC number and save as: UPC85856
And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bubble solution
Then I save the product information as: TestCase85856
Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
And I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Chlorine
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Walgreens
And I call Shared Step 85909 (UPC - Confirm Package type link and drop down not shown - Add UPC data - Continue) for UPC: saved as UPC85856, container type: Plastic Container and size: 12 click continue
Given in the Regulatory Documents to Provide page I click Continue
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase85856


@TestCase:85857
Scenario: [85857] Account Partial stewardship Only, SOLD = Canada Only, PL = YES, Packaging type IS required
Given I log in with the account saved in TReVor as: PartialStewardshipOnly
Given I generate a random UPC number and save as: UPC85857
And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bubble solution
Then I save the product information as: TestCase85857
And I call Shared Step 85284 - Product Information - US & Canada, Child (No), OSHA (No), DSV (No), PLP (YES), GNFR (No), Continue
And I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Chlorine
And I call Shared Step 57637 (Regulatory Information 1 - TSCA & CEPA shown, No to PROP 65 - Continue - Happy Path)
And I call Shared Step  (Select Retailers Canadian Tire and enter additional requirements field - Indicate full name of product, as sold via this retailer)
And In the UPC page I should see Add new Packaging Type link
And I click the 'Add' button
And I enter UPC Number: saved as UPC85857
And I Select a container type from the drop down list
And I enter Size Value: 12
And I Confirm the Package Type drop down list shows a Packaging type available for selection - Do not select one
And I click continue
And I Confirm This is a required field. error message is shown below the Package Type field
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase85857


@TestCase:85858
Scenario: [85858] Account Partial stewardship Only, SOLD = Canada Only, PL = NO, Packaging type IS required
Given I log in with the account saved in TReVor as: PartialStewardshipOnly
Given I generate a random UPC number and save as: UPC85858
And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bubble solution
Then I save the product information as: TestCase85858
And I call Shared Step 78879 - Product Information - Canada Only - Child (NO), GHS (NO), DSV (NO), PLP (NO), GNFR (NO), Continue
And I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
And I call Shared Step 29181c (Ingredients - add any chemical - For Canada Only) with name: Chlorine
And I call Shared Step 57911 (Regulatory Information 1 - CEPA only shown - Continue - Happy Path)
Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Canadian Tire
And I click continue
And In the UPC page I should see Add new Packaging Type link
Given I generate a random UPC number and save as: UPC85858
And I click the 'Add' button
And I enter UPC Number: saved as UPC85858
And I Select a container type from the drop down list
And I enter Size Value: 12
And I click continue
And I Confirm This is a required field. error message is shown below the Package Type field
#Given in the Universal Product Code (UPC) page I click Continue
#Then The alert message is displayed with text: STOP! When selecting authoring of a Safety Data Sheet (SDS) for Canada, you need to provide your Canada address. Please go to the My Account area, and update this information in My Company. You can then resume your registration set up.
#Given in the Regulatory Documents to Provide page I click Continue
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase85858



@TestCase:85859
Scenario: [85859] Account Partial stewardship Only, SOLD = US & Canada, PL = YES, Packaging type IS required
Given I log in with the account saved in TReVor as: PartialStewardshipOnly
Given I generate a random UPC number and save as: UPC85859
And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bubble solution
Then I save the product information as: TestCase85859
And I call Shared Step 85284 - Product Information - US & Canada, Child (No), OSHA (No), DSV (No), PLP (YES), GNFR (No), Continue
And I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Chlorine
And I call Shared Step 57637 (Regulatory Information 1 - TSCA & CEPA shown, No to PROP 65 - Continue - Happy Path)
And I call Shared Step  (Select Retailers Canadian Tire and enter additional requirements field - Indicate full name of product, as sold via this retailer)
And In the UPC page I should see Add new Packaging Type link
And I click the 'Add' button
And I enter UPC Number: saved as UPC85859
And I Select a container type from the drop down list
And I enter Size Value: 12
And I Confirm the Package Type drop down list shows a Packaging type available for selection - Do not select one
And I click continue
And I Confirm This is a required field. error message is shown below the Package Type field
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase85859


@TestCase:85860
Scenario: [85860] Account Partial stewardship Only, SOLD = US & Canada, PL = NO, Packaging type IS required
Given I log in with the account saved in TReVor as: PartialStewardshipOnly
And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bubble solution
Then I save the product information as: TestCase85860
And I call Shared Step 62678 (Product Information - US & Canada, No Child, No OSHA, NO Direct ship, No PL, No NGFR - Continue, Happy path)
And I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Chlorine
And I call Shared Step 57637 (Regulatory Information 1 - TSCA & CEPA shown, No to PROP 65 - Continue - Happy Path)
Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Canadian Tire
And I click continue
And In the UPC page I should see Add new Packaging Type link
Given I generate a random UPC number and save as: UPC85860
And I click the 'Add' button
And I enter UPC Number: saved as UPC85860
And I Select a container type from the drop down list
And I enter Size Value: 12
And I click continue
And I Confirm This is a required field. error message is shown below the Package Type field
And I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase85860
