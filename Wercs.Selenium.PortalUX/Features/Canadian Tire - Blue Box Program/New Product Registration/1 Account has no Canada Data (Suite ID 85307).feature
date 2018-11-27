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
@run_1AccountHasNoCanadaData

Feature: 1 Account has no Canada Data (Suite ID 85307)

# uses a 'manual account'. suspend feature until this is sorted (Jan 2018)
@tfsdesign
Scenario: [85312] No Canada data - SOLD = US and Canada, PL = No, Packaging Type is required

Given I log in with the account saved in TReVor as: NoCanadaData

And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bubble solution
And I call Shared Step 57514 (Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path)
And I call Shared Step 62678 (Additional Product Information - US & Canada, No Child, No OSHA, NO Direct ship, No PL, No NGFR - Continue, Happy path)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Chlorine
And I call Shared Step 57637 (Regulatory Information 1 - TSCA & CEPA shown, No to PROP 65 - Continue - Happy Path)
And In the 'Select Retailers' window I select the retailer: Canadian Tire
And In the select retailers window I click Done
And I click continue
And [Shared Step 85917 - UPC - Confirm Package type Link and field shown and required]
And I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase85312
