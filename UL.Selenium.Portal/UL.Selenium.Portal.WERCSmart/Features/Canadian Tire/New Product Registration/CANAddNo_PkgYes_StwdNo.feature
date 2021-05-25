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
@run_CANAddNo_PkgYes_StwdNo

Feature: Account Canada Address(No) Packagetype(Yes) Stewardship(No)


@ScenarioId:1275
Scenario: [85871] Account Packaging type Only, SOLD = US Only, PL = YES, Packaging type IS NOT required

Given I log in with the account saved in TReVor as: PackagingOnly
Given I generate a random UPC number and save as: UPC85871
And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bubble solution
Then I save the product information as: TestCase85871
Given I call Shared Step 63860 (Product Information - US, No(child), No(OSHA), No(DSV), Yes(PLP), No(GNFR))
And I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Chlorine
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
And I call Shared Step  (Select Retailers Walgreens and enter additional requirements field - Indicate full name of product, as sold via this retailer)
And I call Shared Step 85909 (UPC - Confirm Package type link and drop down not shown - Add UPC data - Continue) for UPC: saved as UPC85871, container type: Plastic Container and size: 12 click continue
Given in the Regulatory Documents to Provide page I click Continue
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase85871


@ScenarioId:1276
Scenario: [85872] Account Packaging type Only, SOLD = US Only, PL = NO, Packaging type IS NOT required

Given I log in with the account saved in TReVor as: PackagingOnly
Given I generate a random UPC number and save as: UPC85872
And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bubble solution
Then I save the product information as: TestCase85872
Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
And I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Chlorine
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Walgreens
And I call Shared Step 85909 (UPC - Confirm Package type link and drop down not shown - Add UPC data - Continue) for UPC: saved as UPC85872, container type: Plastic Container and size: 12 click continue
Given in the Regulatory Documents to Provide page I click Continue
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase85872


@ScenarioId:1277
Scenario: [85873] Account Packaging type Only, SOLD = Canada Only, PL = YES, Packaging type IS required

Given I log in with the account saved in TReVor as: PackagingOnly
Given I generate a random UPC number and save as: UPC85873
And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bubble solution
Then I save the product information as: TestCase85873
And I call Shared Step 85730 - Product Information - Canada Only - Child (NO), GHS (NO), DSV (NO), PLP(YES), GNFR (NO), Continue
And I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Chlorine
And I call Shared Step 57911 (Regulatory Information 1 - CEPA only shown - Continue - Happy Path)
And I call Shared Step  (Select Retailers Canadian Tire and enter additional requirements field - Indicate full name of product, as sold via this retailer)
And I call Shared Step 87647 (UPC - Confirm Package type Link and field shown and required ) for UPC: saved as UPC85873, container type: Plastic Container and size: 12 click continue
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase85873


@ScenarioId:1278
Scenario: [85874] Account Packaging type Only, SOLD = Canada Only, PL = NO, Packaging type IS required

Given I log in with the account saved in TReVor as: PackagingOnly
Given I generate a random UPC number and save as: UPC85874
And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bubble solution
Then I save the product information as: TestCase85874
	And I call Shared Step 78879 - Product Information - Canada Only - Child (NO), GHS (NO), DSV (NO), PLP (NO), GNFR (NO), Continue
And I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Chlorine
And I call Shared Step 57911 (Regulatory Information 1 - CEPA only shown - Continue - Happy Path)
Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Canadian Tire
And I call Shared Step 87647 (UPC - Confirm Package type Link and field shown and required ) for UPC: saved as UPC85874, container type: Plastic Container and size: 12 click continue
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase85874


@ScenarioId:1279
Scenario: [85875] Account Packaging type Only, SOLD = US & Canada, PL = YES, Packaging type IS required

Given I log in with the account saved in TReVor as: PackagingOnly
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


@ScenarioId:1280
Scenario: [85876] Account Packaging type Only, SOLD = US & Canada, PL = NO, Packaging type IS required

Given I log in with the account saved in TReVor as: PackagingOnly
Given I generate a random UPC number and save as: UPC85876
And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bubble solution
Then I save the product information as: TestCase85876
	And I call Shared Step 78879 - Product Information - Canada Only - Child (NO), GHS (NO), DSV (NO), PLP (NO), GNFR (NO), Continue
And I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Chlorine
And I call Shared Step 57911 (Regulatory Information 1 - CEPA only shown - Continue - Happy Path)
Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Canadian Tire
And I call Shared Step 87647 (UPC - Confirm Package type Link and field shown and required ) for UPC: saved as UPC85876, container type: Plastic Container and size: 12 click continue
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase85876
