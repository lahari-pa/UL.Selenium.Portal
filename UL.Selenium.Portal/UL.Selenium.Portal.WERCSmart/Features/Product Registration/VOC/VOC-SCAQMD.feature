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
@run_VOCSCAQMD

Feature: VOC - SCAQMD (Suite ID: 64748)

@TestCase:56479
Scenario: [56479] VOC SCAQMD -  SCAQMD Results - Low Solid = Yes - Exceeds area limit - exceeds SCAQMD Limits
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Stains, Interior
Then I save the product information as: TestCase56479
Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
Given I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Given I call Shared Step 57507 (Transportation Details 1- Not Regulated - Continue - Happy Path)
Given I call Shared Step 57794 (Confirm VOC (SCAQMD) step title, Confirm ACP question shown  - Select No - Happy Path)
Given I set the Product is a Low Solid option to: Yes
Given I set the VOC content of product in g/L, including water and exempt compounds. option to: 121
Given I set the Would you like to use the VOC data provided to be copied for all areas (e.g. country, state, local) for comparison? option to: No
Given in the Volatile Organic Compounds (VOC) for California Air District(s) and Canada page I click Continue
Given I set the Canada option to: 121
Given I set the Delaware option to: 121
Given I set the Maryland option to: 121
Given in the SCAQMD Data page I click Continue


Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase56479
