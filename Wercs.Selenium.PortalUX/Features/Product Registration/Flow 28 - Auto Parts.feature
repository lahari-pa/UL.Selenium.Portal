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
@run_FLow28_AutoParts

Feature: [64733] Flow 28 - Auto Parts


Scenario: [60673] Gasoline Container, Portable - RU001419

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Given If I see the retail partners page I set all data consent tiers to true for all retailers in the top section
Then The home screen should load

# ====== Test Setup - Generating + Saving UPC Number and ensuring no duplicates exist ====== #
Given I generate a random UPC number and save as: UPC60673
Given I delete all products with UPC Number: saved as UPC60673

Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)

Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Gasoline Container, Portable

Then I save the product information as: TestCase60673

Given I call shared step 60726 (Additional Product Information - Country and Private Label or Brand - Yes)

Given I call Shared 56808 Regulatory Information - Prop 65 - No - Continue

Given I call Shared 60685 Fuel Container Regulatory Details - Yes

Given I call Shared 69682 (Retailer Association - Add Private Label Information) and select the retailer: Weis and enter the name: Private Label Gasoline

Given I call Shared 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC60673, container type: Aerosol Can and size: 20

Given I call Shared 60567 (Upload Product Label only) : C:\Dependencies\WERCSmart\testdoc.pdf

Given I call Shared 57883 (Comments - Happy Path) and enter the comment: Comment Text

Given I call Shared 57885 (Data Acceptance - Click Accept - Happy Path)

Given I navigate to the home page
Then I delete the product: TestCase60673

