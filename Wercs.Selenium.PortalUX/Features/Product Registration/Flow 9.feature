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

Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Baby/infant/Adult Care/Cleansing Wipes

Then I save the product information as: TestCase58072

Given I call Shared Step 32931 (Liquid Core Product - select  No - Happy Path)

Given I call Shared Step 37857 (Enter Physical Property - Solid)

Given I call Shared Step 57502 (Additional Product Information - Pesticide & Child shown, US only, No to everything else - Continue - Happy Path)

Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
| ComponentName    | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Aqua             | 10      | false               | false       |            |
| Benzoic acid     | 4.5     | false               | false       |            |
| Citric acid      | 25      | false               | false       |            |
| Cetearyl alcohol | 40.4    | false               | false       |            |
| Glycerin         | 20.1    | false               | false       |            |

Given I call Shared 57571 (Enter Regulatory Information - Not Prop 65)

Given I call Shared 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path

Given I call Shared Step 57507 (Transportation Details 1- Not Regulated - Continue - Happy Path)

Given I call Shared 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Walgreens

Given I call Shared 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC58072, container type: Plastic Container and size: 10.0

Given I call Shared 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)

Given I call Shared 60567 (Upload Product Label only)

Given in the Optional Reports and Documents Available for Purchase page I click Continue

Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient |
| Gloves                        | 150                      | 25.0                    | 11.2      | White      | Floral | No data available | 10                    |

Given I call Shared 57883 (Comments - Happy Path) and enter the comment: User added Comments Text 58072. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)

Given I call Shared 57885 (Data Acceptance - Click Accept - Happy Path)

Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase58072

Scenario: [58098] Ingredient Table - Selecting Publicly Disclosed/Label Name

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

Given I call Shared 57753 (Create a New Registration via Register New Product (expanded menu))

Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk

Given I call Shared Step 37857 (Enter Physical Property - Solid)

Given I call Shared Step 57502 (Additional Product Information - Pesticide & Child shown, US only, No to everything else - Continue - Happy Path)

#Custom shared

Given I add the following ingredients:
| ComponentName |
| Aqua          |

#Type component name (eg water)

#Select search result

# 100 % input

# Select a name in Public Name dropdown

#Confirm public name is populated in dropdown

# Click checkbox for Trade Secret

# Confirm public name is no longer visible in the dropdown

# Deselect Trade Secret checkbox

#Click the checkbox for Publically Disclosed

#Confirm the number to the right pf Total Percent changes to match the number of checkboxes that are selected for Publicly Disclosed? You should see 1/3

#Click the WERCSmart logo

# Shared 43758

Scenario: [58078] Energy or Nutritional Bars - RU000618

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

Given I generate a random UPC number and save as: UPC58078

Given I delete all products with UPC Number: saved as UPC58078

Given I call Shared 57753 (Create a New Registration via Register New Product (expanded menu))

Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Energy or Nutritional Bars

Then I save the product information as: TestCase58078

Given I call Shared Step 37857 (Enter Physical Property - Solid) with the following inputs:
| Secondary Physical State | Water Solubility     |
| Grainy                   | Soluble in hot water |

Given I call Shared 57401 (Additional Product Information - US only - No GHS, Not Direct Ship, Not PLP, Not GNFR > Continue - Happy Path)

Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Cocoa butter  | 100     | false               | false       |            |

Given I call Shared 57571 (Enter Regulatory Information - Not Prop 65)

Given I call Shared 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: CVS

Given I call Shared 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC58078, container type: Plastic Container and size: 3.6

Given I call Shared 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)

Given I call Shared 60567 (Upload Product Label only)

Given in the Optional Reports and Documents Available for Purchase page I click Continue

Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance  | Odor      | Odor Threshold    | Partition Coefficient |
| Apron                         | 190                      | 40.0                    | 20.20001  | Light brown | Chocolate | No data available | 13.335                |

Given I call Shared 57883 (Comments - Happy Path) and enter the comment: User added Comments Text 58078. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)

Given I call Shared 57885 (Data Acceptance - Click Accept - Happy Path)

Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase58078

Scenario: [58079] Energy or Nutritional Powder/Mix - RU000706

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

Given I generate a random UPC number and save as: UPC58079

Given I delete all products with UPC Number: saved as UPC58079

Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)

Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Energy or Nutritional Powder/Mix

Then I save the product information as: TestCase58079

Given I call Shared Step 37857 (Enter Physical Property - Solid) with the following inputs:
| Secondary Physical State | Water Solubility |
| Flaked                   | Soluble in water |

Given I call Shared 57401 (Additional Product Information - US only - No GHS, Not Direct Ship, Not PLP, Not GNFR > Continue - Happy Path)

Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
| ComponentName       | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Cocoa Powder        | 15.629  | true                | false       | Cocoa      |
| Banana powder       | 20.3    | false               | true        |            |
| Oat flour (Oatmeal) | 64.071  | false               | false       |            |

Given I call Shared 57571 (Enter Regulatory Information - Not Prop 65)

Given I call Shared 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Save Mart Supermarkets

Given I call Shared 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC58079, container type: Plastic bag and size: 8

Given I call Shared 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)

Given I call Shared 60567 (Upload Product Label only)

Given in the Optional Reports and Documents Available for Purchase page I click Continue

Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient |
| Apron                         | 550                      | 63.625                  | 33.333    | Brown      | Banana | No data available | 30                    |

Given I call Shared 57883 (Comments - Happy Path) and enter the comment: User added Comments Text 58079. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)

Given I call Shared 57885 (Data Acceptance - Click Accept - Happy Path)

Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase58079

Scenario: [58073] Footwear - Gel Insert - RU000854

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

Given I generate a random UPC number and save as: UPC58073

Given I delete all products with UPC Number: saved as UPC58073

Given I call Shared 57753 (Create a New Registration via Register New Product (expanded menu))

Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Footwear - Gel Insert

Then I save the product information as: TestCase58073

Given I call Shared Step 37857 (Enter Physical Property - Solid) with the following inputs:
| Secondary Physical State | Water Solubility |
| Solid Gel Consistency    | Emulsifies       |

Given I call Shared 57401 (Additional Product Information - US only - No GHS, Not Direct Ship, Not PLP, Not GNFR > Continue - Happy Path)

Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Glycerol      | 20      | false               | false       |            |
| Isohexadecane | 30      | false               | false       |            |
| POLOXAMER 181 | 10      | false               | false       |            |
| Aqua          | 40      | false               | false       |            |

Given I call Shared 57571 (Enter Regulatory Information - Not Prop 65)

Given I call Shared 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: CVS

Given I call Shared 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC58073, container type: Plastic bag and size: 8

Given I call Shared 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)

Given I call Shared 60567 (Upload Product Label only)

Given in the Optional Reports and Documents Available for Purchase page I click Continue

Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
| Gloves                        | 800                      | 99                      | 60        | Clear      | Odorless | No data available | 11.2                  |

Given I call Shared 57883 (Comments - Happy Path) and enter the comment: User added Comments Text 58073. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)

Given I call Shared 57885 (Data Acceptance - Click Accept - Happy Path)

Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase58073

