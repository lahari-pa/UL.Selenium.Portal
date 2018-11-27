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
@run_Flow12

Feature: Flow 12

Scenario: [58430] Mixture, Blend, Formulation, Solution - RU000722

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))

Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Mixture, Blend, Formula or Solution from 3rd Party

Then I save the product information as: TestCase58430

Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
| ComponentName   | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Sodium chloride | 33.33   | false               | false       |            |
| Copper sulfate  | 11.67   | false               | false       |            |
| Nitric acid     | 55      | false               | false       |            |

Given I call Shared Step 48948 (Formulation > 3rd Party - Select all)
Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)

Given I call Shared Step 60932 (Regulatory Information 2 - Microbeads - No)

Given I call Shared Step 60933 (Additional Documents to Provide - Product Label and OSHA SDS only)

Given in the Product's Aliases page I click Continue

Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: User added Comments Text 58430. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)

Given I call Shared Step 58610 (Confirm Restrict Use - Restrict)

Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Mixture, Blend, Formula or Solution from 3rd Party

Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase58430

Scenario: [58605] Suppository (no laxative) -  RU001151

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)

Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Suppository, Medicinal

Then I save the product information as: TestCase58605

#Given I call Shared Step 37857 (Enter Physical Property - Solid)

Given I call Shared Step 57501 (Product Characteristics - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue)

#Given I call Shared Step 65511 (Additional Product Information - No Child, No Direct ship, No PL, Click Continue - Happy Path (use in a BCP))

Given I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)

#Given I check the new page has loaded with no required field error. Navigating from: Additional Product Information to: Ingredients

Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Glycerin      | 30      | false               | false       |            |
| Glucose       | 30      | false               | false       |            |
| Aqua          | 40      | false               | false       |            |

Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)

Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path

#Given I call Shared Step 63219 (Retailer Association - Select No Retailer - Click continue)

Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)

Given I call Shared Step 60567 (Upload Product Label only) : C:\Dependencies\WERCSmart\testdoc.pdf

Given in the Additional Documents to Provide page I click Continue

Given in the Optional Reports and Documents Available for Purchase page I click Continue

Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: User added Comments Text 58605. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)

Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Suppository, Medicinal

Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase58605

@upctest
Scenario: [58604] Condom - RU000937

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

Given I generate a random UPC number and save as: UPC58604

Given I delete all products with UPC Number: saved as UPC58604

Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))

Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Condom with or without Spermicide

Then I save the product information as: TestCase58604

Given I call Shared Step 37857 (Enter Physical Property - Solid)

Given I call Shared Step 60310 (Additional Product Information - Without Child question)

Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Polyisoprene  | 90      | false               | false       |            |
| Glucose       | 5       | false               | false       |            |
| Aqua          | 5       | false               | false       |            |

Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)

Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path

Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: CVS

Then I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC58604, container type: Plastic Container and size: 6

Given I call Shared Step 60567 (Upload Product Label only) : C:\Dependencies\WERCSmart\testdoc.pdf

# Needed 'Additional Documents to Provide' Page step

Given in the Additional Documents to Provide page I click Continue

Given in the Optional Reports and Documents Available for Purchase page I click Continue

Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: User added Comments Text 58604. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)

Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Condom with or without Spermicide

Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase58604


Scenario: [58606] Medicinal Liquids - RU001188

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

Given I generate a random UPC number and save as: UPC58606

Given I delete all products with UPC Number: saved as UPC58606

Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))

Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Medicinal Liquids

Then I save the product information as: TestCase58606

Given I call Shared Step 70675 (Product Characteristics - Liquid Only - With Water Solubility - Enter all data - Continue)

#Given I call Shared Step 65511 (Additional Product Information - No Child, No Direct ship, No PL, Click Continue - Happy Path (use in a BCP))

Given I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)

#Given I check the new page has loaded with no required field error. Navigating from: Additional Product Information to: Ingredients

Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Ethanol       | 20      | false               | false       |            |
| Paracetamol   | 5       | false               | false       |            |
| Aqua          | 50      | false               | false       |            |
| Guaifenesin   | 25      | false               | false       |            |

Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)

#Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path

Given I call Shared Step 57506 (Transportation Details 1 - Regulated for Transport(No) - Exemption(Random) - Continue - Happy Path)

Given I call Shared Step 62536 (Transportation Details 2 > I do not ship internationally > Continue - Happy Path)

Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)

#Given I call Shared Step 63219 (Retailer Association - Select No Retailer - Click continue)

# Regulatory Documents to Provide page is showing

Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)

#Given I call Shared Step 60567 (Upload Product Label only) : C:\Dependencies\WERCSmart\testdoc.pdf

Given in the Additional Documents to Provide page I click Continue

Given in the Optional Reports and Documents Available for Purchase page I click Continue

Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient |
| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | 41.3005               |

Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: User added Comments Text 58606. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)

Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Medicinal Liquids (cough medicine, eye drops, ear drops, nasal spray and inhalers)

Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase58606
