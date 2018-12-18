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
@SummaryPage
@PaymentMethods
@SubEnrollment
@WERCSmart_Signup
@MyAccount
@PackagingTypes
@Brands
@MyIngredients
@UPC
@run_UPC

Feature: UPC

Scenario: [87584] Physical State = Solid, UPC step - Size shows as Size (Weight Ounces)

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

Given I generate a random UPC number and save as: UPC87584

Given I delete all products with UPC Number: saved as UPC87584

Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))

Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk

Then I save the product information as: TestCase87584

Given I call Shared Step 37857 (Enter Physical Property - Solid)

Given I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)

Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Propane       | 100     | false               | false       |            |

Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)

Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Amazon

Given I click the 'Add Case UPC' button

Then I should see the following UPC options:
| Option                          |
| UPC Number                                 |
| Quantity of Units within the Case                |
| Size (Weight Ounces)                            |

Then I should not see the following UPC options:
| Option                          |
| Size (Fluid Ounces)                             |
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase87584


Scenario: [87587] Physical State = Liquid, UPC step - Size shows as Size (Fluid Ounces)

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

Given I generate a random UPC number and save as: UPC87587

Given I delete all products with UPC Number: saved as UPC87587

Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))

Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Bubble solution

Then I save the product information as: TestCase87584

Given I call Shared Step 57514 (Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path)

Given I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)

Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Propane       | 100     | false               | false       |            |

Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)

Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Amazon

Given I click the 'Add Case UPC' button

Then I should see the following UPC options:
| Option                          |
| UPC Number                                 |
| Quantity of Units within the Case                |
| Size (Fluid Ounces)                            |

Then I should not see the following UPC options:
| Option                          |
| Size (Weight Ounces)                             |
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase87587



Scenario: [87588] Physical State = Aerosol, UPC step - Size shows as Size (Fluid Ounces)

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

Given I generate a random UPC number and save as: UPC87588

Given I delete all products with UPC Number: saved as UPC87588

Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))

Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Deodorant - Aerosol

Then I save the product information as: TestCase87588

Given I call Shared Step 57528 (Product Characteristics - Aerosol Only - add data - Continue - Happy Path)

Given I call Shared Step 60310 (Additional Product Information - Without Child question)

Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Propane       | 100     | false               | false       |            |

Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)

Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path

Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)

Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)

Given I call Shared Step 62710 (Confirm VOC OTC/CARB heading and select No to FIRST QUESTION ONLY - Happy Path)

Given I call Shared Step 60631 (VOC - HVOC and MVOC - add values - Continue - Happy Path)

Given in the Volatile Organic Compound Summary page I click Continue

Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Amazon

Given I click the 'Add Case UPC' button

Then I should see the following UPC options:
| Option                          |
| UPC Number                                 |
| Quantity of Units within the Case                |
| Size (Fluid Ounces)                            |

Then I should not see the following UPC options:
| Option                          |
| Size (Weight Ounces)                             |
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase87588



Scenario: [87593] Physical State = GAS, UPC step - Size shows as Size (Fluid Ounces)

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

Given I generate a random UPC number and save as: UPC87593

Given I delete all products with UPC Number: saved as UPC87593

Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))

Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Compressed gas

Then I save the product information as: TestCase87593

Given I call Shared Step 74981 (Product Characteristics - gas)
| Secondary Physical State   | Select the best Water Solubility description |
| Compressed gas             | Very slight                                 |

Given I call Shared Step 60310 (Additional Product Information - Without Child question)

Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Propane       | 100     | false               | false       |            |

Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)

Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)

Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)

Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Amazon

Given I click the 'Add Case UPC' button

Then I should see the following UPC options:
| Option                          |
| UPC Number                                 |
| Quantity of Units within the Case                |
| Size (Fluid Ounces)                            |

Then I should not see the following UPC options:
| Option                          |
| Size (Weight Ounces)                             |
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase87593



Scenario: [87595] Kit - UPC Page - Size shows as Weight (Ounces)

Given I save to context name: TestCase1 and value: 1525111

Given I save to context name: TestCase2 and value: 1501057

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

Given I filter the products by: Accepted by Retailers

Given I save the list of Product IDs displayed on the page as: ProductInProgressList87595



#Given I generate a random UPC number and save as: UPC87595
#
#Given I delete all products with UPC Number: saved as UPC87595

Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))

Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Hair Color Kit

Then I save the product information as: TestCase87595

#Given I call Shared Step 74981 (Product Characteristics - gas)
#| Secondary Physical State   | Select the best Water Solubility description |
#| Compressed gas             | Very slight                                 |

#And I call Shared Step 77883 (Additional Product Information - Kit flow - US only, Direct Ship (No), Continue)

Given I call Shared Step 60648 (Additional Product Information - US, No (Direct Ship), No (PL), No (GNFR))

#Given I call Shared Step 60310 (Additional Product Information - Without Child question)

#Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
#| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
#| Propane       | 100     | false               | false       |            |

And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)

#Given I select the product with ID saved as: ProductInProgressList76314 under the Select Products tab



#Given I save first selectable Product ID as: SelectProductsID74634 under the Select Products tab

#Given I select the product with ID saved as: SelectProductsID74634 under the Select Products tab and the checkbox is disabled while the page is working

#Given I select the product with ID saved as: SelectProductsID74634 under the Select Products tab

#Then I confirm that the product checkbox is disabled while the page is working

And I call Shared Step 31427 (Create the Kit - Adding two products: product 1: TestCase1  and product 2: TestCase2)

#Given In the Create the kit page I search for and select: 1521827
#
#Given In the Create the kit page I search for and select: 1527139
#
#Given in the Create the Kit page I click Continue

#Given I enter the text:  1521827 kit in the 'Select Existing Registrations to include in the Kit' field
#
#Given I save first selectable Product ID as: SelectProductsID87595 under the Select Products tab
#
#Given I select the product with ID saved as: SelectProductsID87595 under the Select Products tab
#
#And I call Shared Step 31427 (Create the Kit - Adding two products: product 1: ProductInProgressList87595 and product 2: ProductInProgressList87595)

Given I call Shared Step 57506 (Transportation Details 1 - Regulated for Transport(No) - Exemption(Random) - Continue - Happy Path)

Given I call Shared Step 62536 (Transportation Details 2 > I do not ship internationally > Continue - Happy Path)

#Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
#
#Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
#
#Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)

Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Amazon

Given I click the 'Add Case UPC' button

Then I should see the following UPC options:
| Option                          |
| UPC Number                                 |
| Quantity of Units within the Case                |
| Size (Weight Ounces)                           |

Then I should not see the following UPC options:
| Option                          |
| Size (Fluid Ounces)             |
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase87595
