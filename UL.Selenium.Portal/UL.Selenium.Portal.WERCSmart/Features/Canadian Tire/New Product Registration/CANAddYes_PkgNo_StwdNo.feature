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
@run_CANAddYes_PkgNo_StwdNo

Feature: Account Canada Address(Yes) Packagetype(No) Stewardship(No)

@ignore
@TestCase:85315
Scenario: [85315] Account has Canada address only - SOLD = US and Canada, PL = No, packaging type is required

Given I log in with the account saved in TReVor as: ProductAccount
Given I generate a random UPC number and save as: UPC85315
And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bubble solution
Then I save the product information as: TestCase85315
And I call Shared Step 62678 (Product Information - US & Canada, No Child, No OSHA, NO Direct ship, No PL, No NGFR - Continue, Happy path)
And I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Chlorine
And I call Shared Step 57637 (Regulatory Information 1 - TSCA & CEPA shown, No to PROP 65 - Continue - Happy Path)
Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Canadian Tire
And I call Shared Step 87647 (UPC - Confirm Package type Link and field shown and required ) for UPC: saved as UPC85315, container type: Plastic Container and size: 12 click continue
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase85315


@TestCase:85735
Scenario: [85735] Account has Canada address only - SOLD = US and Canada, PL = YES, packaging type is required

Given I log in with the account saved in TReVor as: ProductAccount
Given I generate a random UPC number and save as: UPC85735
And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bubble solution
Then I save the product information as: TestCase85735
And I call Shared Step 85284 - Product Information - US & Canada, Child (No), OSHA (No), DSV (No), PLP (YES), GNFR (No), Continue
And I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Chlorine
And I call Shared Step 57637 (Regulatory Information 1 - TSCA & CEPA shown, No to PROP 65 - Continue - Happy Path)
And I call Shared Step  (Select Retailers Canadian Tire and enter additional requirements field - Indicate full name of product, as sold via this retailer)
And I call Shared Step 87647 (UPC - Confirm Package type Link and field shown and required ) for UPC: saved as UPC85735, container type: Plastic Container and size: 12 click continue
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase85735

@ignore
@TestCase:85736
Scenario: [85736] Account has Canada address only - SOLD = Canada only, PL = No, packaging type is required

Given I log in with the account saved in TReVor as: ProductAccount
Given I generate a random UPC number and save as: UPC85736
And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bubble solution
Then I save the product information as: TestCase85736
	And I call Shared Step 78879 - Product Information - Canada Only - Child (NO), GHS (NO), DSV (NO), PLP (NO), GNFR (NO), Continue
And I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
And I call Shared Step 29181c (Ingredients - add any chemical - For Canada Only) with name: Chlorine
And I call Shared Step 57911 (Regulatory Information 1 - CEPA only shown - Continue - Happy Path)
Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Canadian Tire
And I call Shared Step 87647 (UPC - Confirm Package type Link and field shown and required ) for UPC: saved as UPC85736, container type: Plastic Container and size: 12 click continue
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase85736


@TestCase:85737
Scenario: [85737] Account has Canada address only - SOLD = Canada only, PL = YES, packaging type is required

Given I log in with the account saved in TReVor as: ProductAccount
Given I generate a random UPC number and save as: UPC85737
And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bubble solution
Then I save the product information as: TestCase85737
And I call Shared Step 85730 - Product Information - Canada Only - Child (NO), GHS (NO), DSV (NO), PLP(YES), GNFR (NO), Continue
And I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
And I call Shared Step 29181c (Ingredients - add any chemical - For Canada Only) with name: Chlorine
And I call Shared Step 57911 (Regulatory Information 1 - CEPA only shown - Continue - Happy Path)
And I call Shared Step  (Select Retailers Canadian Tire and enter additional requirements field - Indicate full name of product, as sold via this retailer)
And I call Shared Step 87647 (UPC - Confirm Package type Link and field shown and required ) for UPC: saved as UPC85737, container type: Plastic Container and size: 12 click continue
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase85737


@TestCase:85738
Scenario: [85738] Account has Canada address only - SOLD = US only, PL = No, packaging type is NOT required

Given I log in with the account saved in TReVor as: ProductAccount
Given I generate a random UPC number and save as: UPC85738
And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bubble solution
Then I save the product information as: TestCase85738
Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
And I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Chlorine
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Walgreens
And I call Shared Step 85909 (UPC - Confirm Package type link and drop down not shown - Add UPC data - Continue) for UPC: saved as UPC85738, container type: Plastic Container and size: 12 click continue
Given in the Regulatory Documents to Provide page I click Continue
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase85738


@TestCase:85739
Scenario: [85739] Account has Canada address only - SOLD = US only, PL = YES, packaging type is NOT required

Given I log in with the account saved in TReVor as: ProductAccount
Given I generate a random UPC number and save as: UPC85739
And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bubble solution
Then I save the product information as: TestCase85739
Given I call Shared Step 63860 (Product Information - US, No(child), No(OSHA), No(DSV), Yes(PLP), No(GNFR))
And I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Chlorine
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
And I call Shared Step  (Select Retailers Walgreens and enter additional requirements field - Indicate full name of product, as sold via this retailer)
And I call Shared Step 85909 (UPC - Confirm Package type link and drop down not shown - Add UPC data - Continue) for UPC: saved as UPC85739, container type: Plastic Container and size: 12 click continue
Given in the Regulatory Documents to Provide page I click Continue
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase85739
