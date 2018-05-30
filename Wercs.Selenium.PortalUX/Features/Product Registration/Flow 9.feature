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
@run_Flow9
Feature: Flow 9

Scenario: [58072] Baby/Infant/Adult Care/Cleansing Wipes - RU000248

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

Given I generate a random UPC number and save as: UPC58072

Given I delete all products with UPC Number: saved as UPC58072

Given I call Shared 57753 (Create a New Registration via Register New Product (expanded menu))

Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Baby/Infant/Adult Care/Cleansing Wipes

Then I save the product information as: TestCase58072

Given I call Shared Step 32931 (Liquid Core Product - select  No - Happy Path)

Given I call Shared Step 37857 (Enter Physical Property - Solid)
