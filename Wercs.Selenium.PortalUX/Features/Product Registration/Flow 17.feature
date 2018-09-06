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
@run_Flow17

Feature: Flow 17

@tfs_design
Scenario: [60017] Lithium Primary/Metal Batteries - RU000612

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

Given I generate a random UPC number and save as: UPC60017

Given I delete all products with UPC Number: saved as UPC60017

Given I call Shared 57753 (Create a New Registration via Register New Product (expanded menu))

Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Lithium Primary/Metal Batteries

Then I save the product information as: TestCase60017

Given I call Shared Step 59927 (Primary Physical State > Solid only available – Without Water Solubility question)

Given I call Shared Step 60026 (Additional Product Information - US - Battery - No to all)

Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
| ComponentName       | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Lithium perchlorate | 50      | false               | false       |            |
| manganese dioxide   | 50      | false               | false       |            |

Given I call Shared 57571 (Enter Regulatory Information - Not Prop 65)

Given I call Shared Step 73282 (Lithium Battery Characteristics - Weight in Grams)

Given I call Shared Step 60096 (Lithium Battery Transportation)

Given I call Shared 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Costco

Given I call Shared Step 60826 (Enter Universal Product Code (UPC) - Battery - Confirm Quantity ) for UPC saved as: UPC60017 with container type: Plastic Container size: 50.0 and quantity: 1000

Given I call Shared 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)

Given I call Shared Step 69422 (Additional Documents to Provide - Upload Product Photo)

Given in the Optional Reports and Documents Available for Purchase page I click Continue

Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient |
| Gloves                        | 650                      | 0.400                   | 1.005     | Black      | Acidic | No data available | 7.388                 |

Given I call Shared 57883 (Comments - Happy Path) and enter the comment: User added Comments Text 60017. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)

Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Lithium Primary/Metal Batteries

Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase60017


@tfs_design
Scenario: [60018] Lithium Ion Battery - RU000345

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

Given I generate a random UPC number and save as: UPC60018

Given I delete all products with UPC Number: saved as UPC60018

Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)

Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Lithium ion batteries

Then I save the product information as: TestCase60018

Given I call Shared Step 59927 (Primary Physical State > Solid only available – Without Water Solubility question)

Given I call Shared Step 65493 (Additional Product Information - US only - Battery is packaged for Retail Sales - No to everything else - Continue)

Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
| ComponentName      | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Lithium hydroxide  | 6.7     | false               | false       |            |
| Graphite           | 33.2    | false               | false       |            |
| Ethylene carbonate | 60.1    | false               | false       |            |

Given I call Shared 57571 (Enter Regulatory Information - Not Prop 65)

Given I call Shared Step 54799 (Lithium Battery Characteristics - any data - Happy path)

Given I call Shared Step 60096 (Lithium Battery Transportation)

Given I call Shared 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Costco

Given I call Shared Step 60826 (Enter Universal Product Code (UPC) - Battery - Confirm Quantity ) for UPC saved as: UPC60018 with container type: Plastic Container size: 50.0 and quantity: 1000

Given I call Shared 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)

Given I call Shared Step 69422 (Additional Documents to Provide - Upload Product Photo)

Given in the Optional Reports and Documents Available for Purchase page I click Continue

Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient |
| Gloves                        | 650                      | 0.400                   | 1.005     | Black      | Acidic | No data available | 7.388                 |

Given I call Shared 57883 (Comments - Happy Path) and enter the comment: User added Comments Text 60018. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)

Given I call Shared Step 73956 (Go to Summary and verify data) with product type: LITHIUM ION BATTERIES

Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase60018
