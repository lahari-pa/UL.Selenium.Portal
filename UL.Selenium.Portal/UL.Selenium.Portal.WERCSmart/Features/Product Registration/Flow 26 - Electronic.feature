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
@SubEnrollment
@run_Flow26_Electronic

Feature: [64732] Flow 26 - Electronic


@ScenarioId:710
Scenario: [60671] Computer (Combination of Monitor & Desktop) - RU001177

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Given If I see the retail partners page I set all data consent tiers to true for all retailers in the top section
Then The home screen should load

# ======= Test Setup - Generating + Saving UPC Number and ensuring no duplicates exist ====== #
#Given I generate a random UPC number and save as: UPC60671
#Given I delete all products with UPC Number: saved as UPC60671

Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)

Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Computer (Combination of Monitor & Desktop)

Then I save the product information as: TestCase60671

Given I call Shared Step 60935 Product Information - US - Direct Ship - Private Label Only

Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)

#In the step below, confirm that the following text is visible on the TCLP screen, "Please answer the following question with regards to your product, not the battery contained in your product." on the TCLP screen.

#Given I call Shared 48367 Product Includes Battery > any type

Given I call Shared Step 48367 (Product Includes Battery > any type)
| Battery Type | Manufacturer | Quantity of Batteries per Package | Quantity of Batteries to Operate Product |
| Alkaline     | <any>        | 6                               | 6                                  |

Given I call Shared Step 61449 Toxicity Characteristic Leaching Procedure (TCLP) - select No to all - Click Continue - Happy Path

Given I call Shared Step 58189 Answer Electronic Equipment questions - With Cathode Ray - No to all

Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)

Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: Comment Text

Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Computer (Combination of Monitor & Desktop)

Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase60671

