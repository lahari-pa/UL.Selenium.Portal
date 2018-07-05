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
@run_Walmart

Feature: Walmart

@tfs_design
Scenario: [73917] Walmart Affiliates When Registering Data for the First Time

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)

#Test case calls shared 31053 but this is identical
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)

Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Candle and/or Wax

Then I save the product information as: TestCase73917

Given I call Shared Step 26897 (Product Characteristics - Solid only available - continue)

Given I call Shared 57401 (Additional Product Information - US only - No GHS, Not Direct Ship, Not PLP, Not GNFR > Continue - Happy Path)

Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
| ComponentName   | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Sodium chloride | 100     | false               | false       |            |

Given I call Shared 57571 (Enter Regulatory Information - Not Prop 65)

# Not currently showing Reg 3 page - requires specific product type or ingredient present?

#Given I call Shared 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path

Then the 'Select Retailers' window appears

Given I select any Walmart Affiliate automatically selects all from that group, then 'Wal-Mart/SAM'S CLUB' is displayed on the retailers page

Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase73917


Scenario: [73920] Walmart Affiliates when Viewing My Retail Partners

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

Given I click the Retail Partners icon in the Navigation Pane

Then I should see the Retail Partners page

Given I check that the following retailers are showing:
| Retailer               | Code  |
| BONOBOS                | WM-BO |
| Walmart.com            | WM-CO |
| Hayneedle              | WM-HN |
| Jet                    | WM-JE |
| MODCLOTH               | WM-MC |
| Moosejaw               | WM-MJ |
| Shoes.com              | WM-SC |

Given I click each Wal-mart affiliate retailer and should be taken to the Wal-mart/SAM'S CLUB view

And I navigate to the home page


Scenario: [74133] Walmart Product Type Electronics

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

#Test case calls shared 31053 but this is identical
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)

Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Electronic Equipment with Circuit Board Only

Then I save the product information as: TestCase74133

Given I call shared step 69687 (Additional Product Information - US, No(PL))

Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)

Given I call Shared Step 48369 (Toxicity Characteristics Leaching Procedure (TCLP) - No to ALL With Copper)

And I should see the Electronic Equipment Page

And in the Product Characteristics tab of the New Product Page for Contains Circuit Board I select: Yes

And in the Product Characteristics tab of the New Product Page for Has a LCD or Plasma Display I select: No

And in the New Product page I click Continue

Given the 'Select Retailers' window appears

Given I check that Walmart and all of its affiliates are not available

Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase74133
