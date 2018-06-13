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
@SubEnrollment
@run_Flow26_Electronic

Feature: [64732] Flow 26 - Electronic


Scenario: [60671] Computer (Combination of Monitor + Desktop) - RU001177

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Given If I see the retail partners page I set all data consent tiers to true for all retailers in the top section
Then The home screen should load

# ====== Test Setup - Generating + Saving UPC Number and ensuring no duplicates exist ====== #
Given I generate a random UPC number and save as: UPC60671
Given I delete all products with UPC Number: saved as UPC60671

Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)

Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Computer (Combination of Monitor

Then I save the product information as: TestCase60671

Given I call Shared Step 60935 Additional Product Information - US - Direct Ship - Private Label Only

Given I call Shared 57571 (Enter Regulatory Information - Not Prop 65)

#In the step below, confirm that the following text is visible on the TCLP screen, "Please answer the following question with regards to your product, not the battery contained in your product." on the TCLP screen.

Given I call Shared 48367 Product Includes Battery > any type

Given I call Shared 61449 Toxicity Characteristic Leaching Procedure (TCLP) - select No to all - Click Continue - Happy Path

Given I call Shared 58189 Answer Electronic Equipment questions - With Cathode Ray - No to all

Given I call Shared 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Walgreens

Given I call Shared Step 60826 (Enter Universal Product Code (UPC) - Battery - Confirm Quantity ) for UPC saved as: UPC60671 with container type: Aerosol Can size: 20 and quantity: 6

Given I call Shared 57883 (Comments - Happy Path) and enter the comment: Comment Text

Given I navigate to the home page
Then I delete the product: TestCase60671

