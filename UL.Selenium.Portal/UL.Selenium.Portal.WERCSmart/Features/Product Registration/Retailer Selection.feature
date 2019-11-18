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
@run_RetailerSelection
@UPC

Feature: Retailer Selection

@ScenarioId:1075
Scenario: [78933] Select Retailers - Show List View

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)

Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Soap (Bar, Liquid) for Body

Then I save the product information as: TestCase78933

Given I call Shared Step 57501 (Product Characteristics - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue)

# Failing on 'child' question
#Given I call Shared Step 57401 (Additional Product Information - US only - No GHS, Not Direct Ship, Not PLP, Not GNFR > Continue - Happy Path)

Given I call Shared Step 63860 (Additional Product Information - US, No(child), No(OSHA), No(DSV), Yes(PLP), No(GNFR))

Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Chlorine      | 100     | false               | false       |            |

Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)

Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path

Then the 'Select Retailers' window appears

Given I click the List view retailers option in the Select Retailers popup

Then I confirm that retailers are displayed in list view with checkboxes next to each

Given I select the following retailers in the Select Retailers popup list view:
| Retailer |
| CVS      |
| Staples  |

Given I click Done in the Select Retailers popup

Then The selected retailers on the Retailer page should be:
| Retailer |
| CVS      |
| Staples  |

Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase78933


@ScenarioId:1076
Scenario: [78936] Select Retailers - Show Logo Tile View

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)

Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Soap (Bar, Liquid) for Body

Then I save the product information as: TestCase78936

Given I call Shared Step 57501 (Product Characteristics - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue)

# Failing on 'child' question
#Given I call Shared Step 57401 (Additional Product Information - US only - No GHS, Not Direct Ship, Not PLP, Not GNFR > Continue - Happy Path)

Given I call Shared Step 63860 (Additional Product Information - US, No(child), No(OSHA), No(DSV), Yes(PLP), No(GNFR))

Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Chlorine      | 100     | false               | false       |            |

Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)

Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path

Then the 'Select Retailers' window appears

Given I click the Logo tile view retailers option in the Select Retailers popup

Then I confirm that retailers are displayed in tile view with checkboxes next to each

Given In the 'Select Retailers' window I select the retailer: Petco

Then The selected retailers on the Retailer page should be:
| Retailer     |
| Petco        |

Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase78936


@ScenarioId:1077
Scenario: [78937] Select Retailers - Select All

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)

Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk

Then I save the product information as: TestCase78937

Given I call Shared Step 26897 (Product Characteristics - Solid only available - continue)

Given I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)

Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Chlorine      | 100     | false               | false       |            |

Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)

Then the 'Select Retailers' window appears

Given I click the Select all retailers option in the Select Retailers popup

Then all retailers are selected in the Select Retailers window

Given I save all retailers in the Select Retailers window in alphabetical order as: AllSelectRetailers78937

Given I click Done in the Select Retailers popup

Then the selected retailers on the Retailer page should match the retailer list saved as AllSelectRetailers78937

Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase78937


@ScenarioId:6055
Scenario: [85276] Select Retailers - Errors highlighted
Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)

Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Soap (Bar, Liquid) for Body

Given I call Shared Step 57501 (Product Characteristics - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue - HP)

And I should see the Additional Product Information Page
And I should see following statement: Select countries the product may be sold in
And I should see following statement: Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)
And I should see following statement: Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)
And I should see following statement: Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.
Given I set all additional product information options to No
Given I click continue in the Additional Product Information page

Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Propane       | 100     | false               | false       |            |

And I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path

Given I click the Select all retailers option in the Select Retailers popup
Then all retailers are selected in the Select Retailers window
Given I click Done in the Select Retailers popup
Given I click continue in the Retailer page
Then I confirm I see error messages for the following retailers
| Retailer            |
| O'Reilly            |
| Sears/K-Mart        |
| Wal-Mart/SAM'S CLUB |
