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
@ForwardProductRegistration
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

Given I call Shared Step 57401 (Additional Product Information - US only - No GHS, Not Direct Ship, Not PLP, Not GNFR > Continue - Happy Path)

Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
| ComponentName   | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Sodium chloride | 100     | false               | false       |            |

Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)

# Not currently showing Reg 3 page - requires specific product type or ingredient present?

Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path

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

Given I call Shared Step 69687 (Additional Product Information - US, No(PL))

Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)

Given I call Shared Step 48369 (Toxicity Characteristics Leaching Procedure (TCLP) - No to ALL With Copper)

And I should see the Electronic Equipment Page

And in the Product Characteristics tab of the New Product Page for Contains Circuit Board I select: Yes

And in the Product Characteristics tab of the New Product Page for Has a LCD or Plasma Display I select: No

And in the New Product page I click Continue

Given the 'Select Retailers' window appears

Given I check that Walmart and all of its affiliates are not available

Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase74133


@tfs_design
Scenario: [74017] Walmart Affiliates when Adding a UPC

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

Given I generate a random UPC number and save as: UPC74017

Given I delete all products with UPC Number: saved as UPC74017

Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)

Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Soap (Bar, Liquid) for Body

Then I save the product information as: TestCase74017

Given I call Shared Step 77711 (Product Characteristics - Primary (L/S), 2nd - any, Enter Gravity, pH, Boiling Point, Flash Point, Flash Point Test - any, Water - any)

Given I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)

Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Glycerol      | 50      | false               | false       |            |
| Palm oil      | 50      | false               | false       |            |

Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)

Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path

Then the 'Select Retailers' window appears

Given In the 'Select Retailers' window I select the retailer: Jet

Given I click continue

Given In the Retailers tab, I select Vendor id as: test

And I click continue

Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC74017, container type: Cardboard and size: 15

# Next test steps are not compatible...
# Click Add Retailer Link
# select Wal-mart/ SAMs CLUB
# confirm WM under Destination Retailers


@tfs_design
Scenario: [73919] Walmart Affiliates when Direct Ship Vendor is set to YES

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

Given I generate a random UPC number and save as: UPC73919

Given I delete all products with UPC Number: saved as UPC73919

Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)

Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Soap (Bar, Liquid) for Body

Then I save the product information as: TestCase73919

Given I call Shared Step 57501 (Product Characteristics - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue - HP)

# Additional Product Info? As title suggests, needs set 'direct ship' to yes

Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Glycerol      | 50      | false               | false       |            |
| Palm oil      | 50      | false               | false       |            |

Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)

Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path

Then the 'Select Retailers' window appears

Given I select any Walmart Affiliate automatically selects all from that group, then 'Wal-Mart/SAM'S CLUB' is displayed on the retailers page

Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase73919

Scenario: [73918] Walmart Affiliates when Forwarding to a New Retailer

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

Given I click Bulk Actions in the Products Grid

Then I should see a popup with header Bulk Actions

Given I click Forward Product Registration in the Bulk Actions window

Then I should see the header: Forward Product Registration on the Forward Product Registration window

And I confirm the active Forward Product Registration tab is: Select Products

Given I enter the text: 1 in the 'Search by WPS ID or Product Name' field

Given I select the first product under the Select Products tab

Given I click continue on the Forward Product Registration page

Then I confirm the active Forward Product Registration tab is: Select Retailers

Given in the Select Retailers tab under Forward Product Registration I select the retailer: Wal-Mart/SAM'S CLUB

Then I confirm that all Walmart affiliate retail parters are selected

Given I click continue on the Forward Product Registration page

Then I confirm the active Forward Product Registration tab is: Select UPCs

# 'Private Label' dropdown is a required field for some products

Given I select the first product under the Select UPCs tab

Given I select the Vendor option: test for the first product displayed under the Select UPCs tab

Given I select the first UPC in the grid under the Select UPCs tab

Then I confirm that: WM is displayed in the Destination Retailers column under Select UPCs

Given I click continue on the Forward Product Registration page

Then I confirm the active Forward Product Registration tab is: Product Results

And I confirm that: WM is displayed in the Destination Retailers column under Product Results

Given I click the Home navigation icon and accept the alert popup


Scenario: [63684] Walmart Private label product

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Given If I see the retail partners page I set all data consent tiers to true for all retailers in the top section

Then The home screen should load

Given I generate a random UPC number and save as: UPC63684

Given I delete all products with UPC Number: saved as UPC63684

Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)

Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Pet shampoo

Then I save the product information as: TestCase63684

Given I call Shared Step 73629 (Product Characteristics - Liquid - select any options(enter pH, boiling point, flash point))
| Secondary Physical State | Specific Gravity | pH      | Boiling Point (in Celsius) | Flash Point (in Celsius) | Flash Point Testing Method Used     | Select the best Water Solubility description |
| Liquid                   | 2                | 2       | 2                          | 66                       | Closed cup method                   | Appreciable                                  |


Given I call Shared Step 63804 (Additional Product Information - enter options)
| Classified using OSHA (US) Globally Harmonized Standards (GHS) | Shipped directly by supplier | Private Label or Brand | Good Not for resale |
| No                                                             | No                            | Yes                         | No                         |

Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Cocoa butter  | 100     | false               | false       |            |

Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)

Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path

Given I call Shared Step 65181 (Retailer Association - Add Private Label Information and Select Vendor ID) and select the retailer: Wal-Mart/SAM'S CLUB and enter the name: Holiday Time and select Vendor id: random

Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC63684, container type: Plastic Container and size: 3.6

Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)

Given in the Additional Documents to Provide page I click Continue

Given in the Optional Reports and Documents Available for Purchase page I click Continue

Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient |
| Apron                         | 550                      | 63.625                  | 33.333    | Brown      | Banana | No data available | 30                    |

Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: User added Comments Text 58079. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)

Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Pet shampoo

Given I navigate to the home page

Given I search for the product saved as: TestCase63684

Then I confirm that the label: 'PL' is displayed next to the Product Name for the top result in the grid

Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase63684

