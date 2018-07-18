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
@run_VOCFlow19

Feature: VOC - Flow 19 Dilution - validation of limits (Suite ID: 64747)

Scenario: [62730] VOC - Flow 19 - Dilution ration - Sold = 50, Used = 45 limit checking
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Floor Wax Stripper (Light or Medium Build-Up)
Then I save the product information as: TestCase62730
Given I call Shared Step 57514 (Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path)
Given I call Shared 57401 (Additional Product Information - US only - No GHS, Not Direct Ship, Not PLP, Not GNFR > Continue - Happy Path)
Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Given I call Shared 62710 (Confirm VOC OTC/CARB heading and select No to FIRST QUESTION ONLY - Happy Path)
Given I set the Product label specifies a dilution ratio which results in a final VOC concentration for the product during use field to: Yes
Given I set the Product's VOC content as sold field to: 50
Given I set the Product's VOC content as used field to: 45
Given in the VOC page I click Continue
Then I should see the Volatile Organic Compound Summary Page
Then in the VOC Summary page I should see the following noneditable statements
| Statement                                                                           |
| VOC percent as sold 50                                                              |
| VOC percent diluted for use 45                                                      |
| Based on the type of product, this must comply with the most restrictive VOC limit. |
| Exceeds the limits specified in the California Consumer Products Regulation         |
| Exceeds the limits specified by the Ozone Transport Commission                      |
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase62730


Scenario: [62728] VOC - Flow 19 - Dilution - Sold = 50, Used = 15 limit checking
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Floor Wax Stripper (Light or Medium Build-Up)
Then I save the product information as: TestCase62728
Given I call Shared Step 57514 (Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path)
Given I call Shared 57401 (Additional Product Information - US only - No GHS, Not Direct Ship, Not PLP, Not GNFR > Continue - Happy Path)
Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Given I call Shared 62710 (Confirm VOC OTC/CARB heading and select No to FIRST QUESTION ONLY - Happy Path)
Given I set the Product label specifies a dilution ratio which results in a final VOC concentration for the product during use field to: Yes
Given I set the Product's VOC content as sold field to: 50
Given I set the Product's VOC content as used field to: 15
Given in the VOC page I click Continue
Then I should see the Volatile Organic Compound Summary Page
Then in the VOC Summary page I should see the following noneditable statements
| Statement                                                                           |
| VOC percent as sold 50                                                              |
| VOC percent diluted for use 15                                                      |
| Based on the type of product, this must comply with the most restrictive VOC limit. |
| Exceeds the limits specified in the California Consumer Products Regulation         |
| Exceeds the limits specified by the Ozone Transport Commission                      |
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase62728

Scenario: [62724] VOC - Flow 19 - Dilution - Sold = 50 Used = 2 - limit checking
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Floor Wax Stripper (Light or Medium Build-Up)
Then I save the product information as: TestCase62724
Given I call Shared Step 57514 (Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path)
Given I call Shared 57401 (Additional Product Information - US only - No GHS, Not Direct Ship, Not PLP, Not GNFR > Continue - Happy Path)
Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Given I call Shared 62710 (Confirm VOC OTC/CARB heading and select No to FIRST QUESTION ONLY - Happy Path)
Given I set the Product label specifies a dilution ratio which results in a final VOC concentration for the product during use field to: Yes
Given I set the Product's VOC content as sold field to: 50
Given I set the Product's VOC content as used field to: 2
Given in the VOC page I click Continue
Then I should see the Volatile Organic Compound Summary Page
Then in the VOC Summary page I should see the following noneditable statements
| Statement                                                                           |
| VOC percent as sold 50                                                              |
| VOC percent diluted for use 2                                                       |
| Based on the type of product, this must comply with the most restrictive VOC limit. |
| Does not exceed the limits specified in the California Consumer Products Regulation |
| Does not exceed the limits specified by the Ozone Transport Commission              |
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase62724
