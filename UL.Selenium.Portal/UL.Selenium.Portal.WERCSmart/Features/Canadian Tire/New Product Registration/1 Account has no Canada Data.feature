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
@run_1AccountHasNoCanadaData

Feature: Account has no Canada Data


@ScenarioId:1215
Scenario: [85312] No Canada data - SOLD = US and Canada, PL = No, Packaging Type is required

Given I log in with the account saved in TReVor as: NoCanadaData
Given I generate a random UPC number and save as: UPC85312
And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bubble solution
Then I save the product information as: TestCase85312
And I call Shared Step 62678 (Product Information - US & Canada, No Child, No OSHA, NO Direct ship, No PL, No NGFR - Continue, Happy path)
And I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Chlorine
And I call Shared Step 57637 (Regulatory Information 1 - TSCA & CEPA shown, No to PROP 65 - Continue - Happy Path)
#And I call Shared Step  (Select Retailers Canadian Tire and enter additional requirements field - Indicate full name of product, as sold via this retailer)
Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Canadian Tire
And I call Shared Step 87647 (UPC - Confirm Package type Link and field shown and required ) for UPC: saved as UPC85312, container type: Plastic Container and size: 12 click continue
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase85312


@ScenarioId:1216
Scenario: [85726] No Canada data - SOLD = US and Canada, PL = Yes, Packaging Type is required

Given I log in with the account saved in TReVor as: NoCanadaData
Given I generate a random UPC number and save as: UPC85726
And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bubble solution
Then I save the product information as: TestCase85726
And I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
And I call Shared Step 85284 - Additional Product Information - US & Canada, Child (No), OSHA (No), DSV (No), PLP (YES), GNFR (No), Continue
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Chlorine
And I call Shared Step 57637 (Regulatory Information 1 - TSCA & CEPA shown, No to PROP 65 - Continue - Happy Path)
And I call Shared Step  (Select Retailers Canadian Tire and enter additional requirements field - Indicate full name of product, as sold via this retailer)
And I call Shared Step 87647 (UPC - Confirm Package type Link and field shown and required ) for UPC: saved as UPC85726, container type: Plastic Container and size: 12 click continue
#And I confirm that UPC page contains link for: Add new Packaging Type
#Given I click the 'Add UPC' button
#Then I should see the following UPC options:
#| Option                          |
#| UPC Number                                 |
#| Size (Fluid Ounces)                            |
#| Package Type                            |
#| Please enter comma separated Item Number(s) (XXX-XXXX,XXX-XXXX,...)   |
#And in the Universal Product Code (UPC) page I click Continue
#Then Package Type should be showing the error messages on upc screen: This is a required field.
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase85726


@ScenarioId:1217
Scenario: [85727] No Canada data - SOLD = Canada only, PL = No, Packaging Type is required

Given I log in with the account saved in TReVor as: NoCanadaData
Given I generate a random UPC number and save as: UPC85727
And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bubble solution
Then I save the product information as: TestCase85727
And I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
And I call Shared Step 78879 - Additional Product Information - Canada Only - Child (NO), GHS (NO), DSV (NO), PLP (NO), GNFR (NO), Continue
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Chlorine
And I call Shared Step 57911 (Regulatory Information 1 - CEPA only shown - Continue - Happy Path)
Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Canadian Tire
And I call Shared Step 87647 (UPC - Confirm Package type Link and field shown and required ) for UPC: saved as UPC85727, container type: Plastic Container and size: 12 click continue
#And I confirm that UPC page contains link for: Add new Packaging Type
#Given I click the 'Add UPC' button
#Then I should see the following UPC options:
#| Option                          |
#| UPC Number                                 |
#| Size (Fluid Ounces)                            |
#| Package Type                            |
#| Please enter comma separated Item Number(s) (XXX-XXXX,XXX-XXXX,...)   |
#And in the Universal Product Code (UPC) page I click Continue
#Then Package Type should be showing the error messages on upc screen: This is a required field.
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase85727


@ScenarioId:1218
Scenario: [85728] No Canada data - SOLD = Canada only, PL = YES, Packaging Type is required

Given I log in with the account saved in TReVor as: NoCanadaData
Given I generate a random UPC number and save as: UPC85728
And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bubble solution
Then I save the product information as: TestCase85728
And I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
And I call Shared Step 85730 - Additional Product Information - Canada Only - Child (NO), GHS (NO), DSV (NO), PLP(YES), GNFR (NO), Continue
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Chlorine
And I call Shared Step 57911 (Regulatory Information 1 - CEPA only shown - Continue - Happy Path)
And I call Shared Step  (Select Retailers Canadian Tire and enter additional requirements field - Indicate full name of product, as sold via this retailer)
And I call Shared Step 87647 (UPC - Confirm Package type Link and field shown and required ) for UPC: saved as UPC85728, container type: Plastic Container and size: 12 click continue
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase85728


@ScenarioId:1219
Scenario: [85733] No Canada data - SOLD = US Only, PL = No, Packaging Type is NOT required

Given I log in with the account saved in TReVor as: NoCanadaData
Given I generate a random UPC number and save as: UPC85733
And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bubble solution
Then I save the product information as: TestCase85733
Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
And I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Chlorine
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Walgreens
And I call Shared Step 85909 (UPC - Confirm Package type link and drop down not shown - Add UPC data - Continue) for UPC: saved as UPC85733, container type: Plastic Container and size: 12 click continue
Given in the Regulatory Documents to Provide page I click Continue
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase85733


@ScenarioId:1220
Scenario: [85734] No Canada data - SOLD = US Only, PL = YES, Packaging Type is NOT required

Given I log in with the account saved in TReVor as: NoCanadaData
Given I generate a random UPC number and save as: UPC85734
And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bubble solution
Then I save the product information as: TestCase85734
And I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
Given I call Shared Step 63860 (Additional Product Information - US, No(child), No(OSHA), No(DSV), Yes(PLP), No(GNFR))
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Chlorine
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
And I call Shared Step  (Select Retailers Walgreens and enter additional requirements field - Indicate full name of product, as sold via this retailer)
And I call Shared Step 85909 (UPC - Confirm Package type link and drop down not shown - Add UPC data - Continue) for UPC: saved as UPC85734, container type: Plastic Container and size: 12 click continue
Then I should see the Regulatory Documents to Provide Page
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase85734
