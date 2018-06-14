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

Given I call Shared 60567 (Upload Product Label only) : C:\Dependencies\WERCSmart\testdoc.pdf

Given in the Optional Reports and Documents Available for Purchase page I click Continue

Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient |
| Gloves                        | 150                      | 25.0                    | 11.2      | White      | Floral | No data available | 10                    |

Given I call Shared 57883 (Comments - Happy Path) and enter the comment: User added Comments Text 58072. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)

# Data Acceptance and Summary verification
And I should see the Data Acceptance Page
Given I click the Summary button in the Data Acceptance window
Then I switch to the Data Summary page
And Type of Product should be showing the following option: Baby/infant/Adult Care/Cleansing Wipes
Then I switch to Data Acceptance page
Given I navigate to the home page
Then I delete the product: TestCase58072

Scenario: [58098] Ingredient Table - Selecting Publicly Disclosed/Label Name

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

Given I call Shared 57753 (Create a New Registration via Register New Product (expanded menu))

Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk

Then I save the product information as: TestCase58098

Given I call Shared Step 37857 (Enter Physical Property - Solid)

Given I call Shared Step 65511 (Additional Product Information - No Child, No Direct ship, No PL, Click Continue - Happy Path (use in a BCP))

Given I add the following ingredients:
| ComponentName    | Percent |
| Aqua             | 50      |
| Sodium hydroxide | 50      |

Given In the Ingredients Page I select the first Public Name dropdown option for ingredient: Aqua

Given In the Ingredients Page I select the Trade Secret checkbox for ingredient: Aqua

Given In the Ingredients Page I confirm the Public Name option is disabled for ingredient: Aqua

Given In the Ingredients Page I select the Trade Secret checkbox for ingredient: Aqua

Given In the Ingredients Page I select the Publicly Disclosed checkbox for ingredient: Aqua

Given In the Ingredients page I check there are 1 Publicly Disclosed ingredients in the Total section

Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase58098

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

Given I call Shared 60567 (Upload Product Label only) : C:\Dependencies\WERCSmart\testdoc.pdf

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

Given I call Shared 60567 (Upload Product Label only) : C:\Dependencies\WERCSmart\testdoc.pdf

Given in the Optional Reports and Documents Available for Purchase page I click Continue

Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient |
| Apron                         | 550                      | 63.625                  | 33.333    | Brown      | Banana | No data available | 30                    |

Given I call Shared 57883 (Comments - Happy Path) and enter the comment: User added Comments Text 58079. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)

# Data Acceptance and Summary verification
And I should see the Data Acceptance Page
Given I click the Summary button in the Data Acceptance window
Then I switch to the Data Summary page
And Type of Product should be showing the following option: Energy or Nutritional Powder/Mix
Then I switch to Data Acceptance page
Given I navigate to the home page
Then I delete the product: TestCase58079

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

Given I call Shared 60567 (Upload Product Label only) : C:\Dependencies\WERCSmart\testdoc.pdf

Given in the Optional Reports and Documents Available for Purchase page I click Continue

Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
| Gloves                        | 800                      | 99                      | 60        | Clear      | Odorless | No data available | 11.2                  |

Given I call Shared 57883 (Comments - Happy Path) and enter the comment: User added Comments Text 58073. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)

Given I call Shared 57885 (Data Acceptance - Click Accept - Happy Path)

Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase58073

Scenario: [63325] Herbal or Dietary Supplements - RU000712 Flow 9-LS (checking SDS step shows only product label and Additional documents to provide shows SDS as optional)

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)

Given I call Shared Step 57500 (The Product- Enter name, select product type: Herbal or Dietary Supplement - Continue - Happy Path)

Then I save the product information as: TestCase63325

Given I call Shared Step 57501 (Product Characteristics - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue)

Given I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)

Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Vitamin E

Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)

Given I call Shared 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path

Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)

Then I should see the Regulatory Documents to Provide Page

Then I see the following sections
| Section                                                                                                                        |
| Upload Full Product Label (required) (For private label products please upload a generic label that is not retailer-specific.) |

Given In the Regulatory Documents to Provide Page, the document type is: Product Label for section: Upload Full Product Label (required) (For private label products please upload a generic label that is not retailer-specific.)

Then I do not see the following sections
| Section                                   |
| OSHA-compliant Safety Data Sheet, English |

Given I call Shared Step 59042 (Browse for File > select > click Open - Happy Path) for document type: Product Label and file: C:\Dependencies\WERCSmart\testdoc.pdf

Given in the Regulatory Documents to Provide page I click Continue

Then I should see the Additional Documents to Provide Page

Then I see the following sections
| Section                                           |
| Upload Physical Data-related Documents (Optional) |

Given In the Additional Documents Page, the document type is: OSHA SDS for section: Upload Physical Data-related Documents (Optional)

Then I see the following sections
| Section                                           |
| Toxicity Characteristic Leaching Procedure (TCLP) |

Given I click Continue and should not see an error message

Then I should see the Optional Reports and Documents Available for Purchase Page

Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase63325

Scenario: [58091] Latex Gloves - RU000151

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

Given I generate a random UPC number and save as: UPC58091

Given I delete all products with UPC Number: saved as UPC58091

Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)

Given I call Shared Step 57500 (The Product- Enter name, select product type: Latex gloves - Continue - Happy Path)

Then I save the product information as: TestCase58091

Given I call Shared Step 37857 (Enter Physical Property - Solid)

Given I call Shared 57401 (Additional Product Information - US only - No GHS, Not Direct Ship, Not PLP, Not GNFR > Continue - Happy Path)

Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Polyisoprene  | 90      | false               | false       |            |
| Ethanol       | 10      | false               | false       |            |

Given I call Shared 57571 (Enter Regulatory Information - Not Prop 65)

Given I call Shared 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Walgreens

Given I call Shared 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC58091, container type: Plastic Container and size: 37

Given I call Shared 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)

Given I call Shared 60567 (Upload Product Label only) : C:\Dependencies\WERCSmart\testdoc.pdf

Given in the Optional Reports and Documents Available for Purchase page I click Continue

Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
| Mask                          | 400                      | 60                      | 2.2       | White      | Odorless | No data available | 1.5                   |

Given I call Shared 57883 (Comments - Happy Path) and enter the comment: User added Comments Text 58091. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)

Given I call Shared 57885 (Data Acceptance - Click Accept - Happy Path)

Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase58091

Scenario: [58075] Nutritional Supplement for Infants - Liquid - RU001365

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

Given I generate a random UPC number and save as: UPC58075

Given I delete all products with UPC Number: saved as UPC58075

Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)

Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Nutritional Supplement for Infants - Liquid

Given I call Shared 57441 (Product Characteristics - Primary Physical Property - Liquid)

Given I call Shared Step 65511 (Additional Product Information - No Child, No Direct ship, No PL, Click Continue - Happy Path (use in a BCP))

Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Aqua          | 65      | false               | false       |            |
| Vitamin A     | 5       | false               | false       |            |
| Citric acid   | 25      | false               | false       |            |
| Vitamin E     | 5       | false               | false       |            |

# Added in 57637 to make test run. Consult Aaron (WERCS)

#Given I call Shared Step 57637 (Regulatory Information 1 - TSCA & CEPA shown, No to PROP 65 - Continue - Happy Path)

Given I call Shared 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: CVS

Given I call Shared 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC58075, container type: Plastic Container and size: 100

Given I call Shared 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)

Given I call Shared Step 60533 (Additional Documents to Provide - Flash Point and Product Label only) : C:\Dependencies\WERCSmart\testdoc.pdf

Given in the Optional Reports and Documents Available for Purchase page I click Continue

Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance    | Odor  | Odor Threshold    | Partition Coefficient |
| Apron                         | 250                      | 11.11                   | 4.288     | Yellow-orange | Lemon | No data available | 3.354                 |

Given I call Shared 57883 (Comments - Happy Path) and enter the comment: User added Comments Text 58075. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)

Given I call Shared 57885 (Data Acceptance - Click Accept - Happy Path)

Scenario: [58089] Nutritional Supplements for Domesticated Animals - RU001239

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

Given I generate a random UPC number and save as: UPC58089

Given I delete all products with UPC Number: saved as UPC58089

Given I call Shared 57753 (Create a New Registration via Register New Product (expanded menu))

Given I call Shared Step 57500 (The Product- Enter name, select product type: Nutritional Supplements for Domesticated Animals - Continue - Happy Path)

Given I call Shared 57441 (Product Characteristics - Primary Physical Property - Liquid)

Given I call Shared 57401 (Additional Product Information - US only - No GHS, Not Direct Ship, Not PLP, Not GNFR > Continue - Happy Path)

Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Aqua          | 65      | false               | false       |            |
| Vitamin A     | 10      | false               | false       |            |
| Citric acid   | 25      | false               | false       |            |

# Added in 57637 to make test run. Ask Wercs testers

Given I call Shared Step 57637 (Regulatory Information 1 - TSCA & CEPA shown, No to PROP 65 - Continue - Happy Path)

Given I call Shared 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Petco

Given I call Shared 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC58089, container type: Plastic Container and size: 100

Given I call Shared 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)

Given I call Shared 60567 (Upload Product Label only) : C:\Dependencies\WERCSmart\testdoc.pdf

Given in the Optional Reports and Documents Available for Purchase page I click Continue

Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor  | Odor Threshold    | Partition Coefficient |
| Gloves                        | 510                      | 15                      | 30.5      | Yellow     | Lemon | No data available | 10.0                  |

Given I call Shared 57883 (Comments - Happy Path) and enter the comment: User added Comments Text 58089. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)

Given I call Shared 57885 (Data Acceptance - Click Accept - Happy Path)

Scenario: [58097] Ingredient Search in Registration

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

Given I call Shared 57753 (Create a New Registration via Register New Product (expanded menu))

Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Paint balls

Given I call Shared Step 32931 (Liquid Core Product - select  No - Happy Path)

Given I call Shared Step 37857 (Enter Physical Property - Solid)

Given I call Shared 57401 (Additional Product Information - US only - No GHS, Not Direct Ship, Not PLP, Not GNFR > Continue - Happy Path)

#enter CAS 18618-43-4, confirm match is top of filter list
Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
| CASNumber  | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| 18618-43-4 | 100     | false               | false       |            |

# Sign out of WERCSmart

Scenario: [58094] Suppository, Laxative, Stool-Softener - RU000944

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

Given I generate a random UPC number and save as: UPC58094

Given I delete all products with UPC Number: saved as UPC58094

Given I call Shared 57753 (Create a New Registration via Register New Product (expanded menu))

Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Suppository, Laxative, Stool-Softener

# Missing Physical Property step. Added in the following.

Given I call Shared 57441 (Product Characteristics - Primary Physical Property - Liquid)

Given I call Shared 57401 (Additional Product Information - US only - No GHS, Not Direct Ship, Not PLP, Not GNFR > Continue - Happy Path)

Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
| ComponentName       | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Magnesium citrate   | 15      | false               | false       |            |
| Magnesium hydroxide | 15      | false               | false       |            |
| Aqua                | 70      | false               | false       |            |

Given I call Shared 57571 (Enter Regulatory Information - Not Prop 65)

Given I call Shared Step 57507 (Transportation Details 1- Not Regulated - Continue - Happy Path)

Given I call Shared 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Walgreens

Given I call Shared 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC58094, container type: Plastic Container and size: 100

Given I call Shared 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)

Given I call Shared 60567 (Upload Product Label only) : C:\Dependencies\WERCSmart\testdoc.pdf

Given in the Optional Reports and Documents Available for Purchase page I click Continue

Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
| Gloves                        | 340                      | 12                      | 20.5      | Clear      | Odorless | No data available | 5.0                   |

Given I call Shared 57883 (Comments - Happy Path) and enter the comment: User added Comments Text 58094. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)

Given I call Shared 57885 (Data Acceptance - Click Accept - Happy Path)

Scenario: [58081] Nutritional Supplement - Solid - RU000619

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

Given I generate a random UPC number and save as: UPC58081

Given I delete all products with UPC Number: saved as UPC58081

Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)

Given I call Shared Step 57500 (The Product- Enter name, select product type: Nutritional Supplement - Solid - Continue - Happy Path)

Given I call Shared Step 37857 (Enter Physical Property - Solid)

Given I call Shared Step 62678 (Additional Product Information - US & Canada, No Child, No OSHA, NO Direct ship, No PL, No NGFR - Continue, Happy path)

Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Aqua          | 50      | false               | false       |            |
| Vitamin A     | 10      | false               | false       |            |
| Citric acid   | 30      | false               | false       |            |
| Vitamin E     | 10      | false               | false       |            |

Given I call Shared 57571 (Enter Regulatory Information - Not Prop 65)

Given I call Shared 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: CVS

Given I call Shared 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC58081, container type: Plastic Container and size: 5.2621

Given I call Shared 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)

Given I call Shared 60567 (Upload Product Label only) : C:\Dependencies\WERCSmart\testdoc.pdf

Given in the Optional Reports and Documents Available for Purchase page I click Continue

Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient |
| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | 41.3005               |

Given I call Shared 57883 (Comments - Happy Path) and enter the comment: User added Comments Text 58081. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)

Given I call Shared 57885 (Data Acceptance - Click Accept - Happy Path)
