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


Scenario: [87596] Create BCP (Camera with battery) -  UPC step - Size shows as Weight (Ounces)

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))

Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Camera w/Battery

Then I save the product information as: TestCase87596

Given I call Shared Step 70393 (Additional Product Information - With marketed for use by a Child - Direct Ship - Private Label questions only)

Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)

Given I call Shared Step 48367 (Product Includes Battery > any type)
| Battery Type | Manufacturer                                                   | Number of batteries per package | How many batteries required to run |
| Alkaline     | Alkaline battery23A by Shenzhen AllKey Battery Co., Ltd.       | 6                               | 6                                  |

Given I click continue

Given I call Shared Step 48369 (Toxicity Characteristics Leaching Procedure (TCLP) - No to ALL With Copper)

Given I call Shared Step 58189 (Answer Electronic Equipment questions - With Cathode Ray - No to all)

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
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase87596



Scenario: [87597] Create Electronic - UPC Step - Size shows as Size (Weight Ounces)

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))

Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Answering machine, No battery included

Then I save the product information as: TestCase87597

And I call Shared Step 69687 (Additional Product Information - US, No(PL))

And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)

And I call Shared Step 48369 (Toxicity Characteristics Leaching Procedure (TCLP) - No to ALL With Copper)

And I call Shared Step 71955 (Answer Electronic Equipment questions - Without Cathode Ray - No to all)

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
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase87597



Scenario: [87595] Kit - UPC Page - Size shows as Weight (Ounces)

Given I save to context name: TestCase1 and value: 1525111

Given I save to context name: TestCase2 and value: 1501057

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

Given I filter the products by: Accepted by Retailers

Given I save the list of Product IDs displayed on the page as: ProductInProgressList87595

Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))

Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Hair Color Kit

Then I save the product information as: TestCase87595

Given I call Shared Step 60648 (Additional Product Information - US, No (Direct Ship), No (PL), No (GNFR))

And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)

And I call Shared Step 31427 (Create the Kit - Adding two products: product 1: TestCase1  and product 2: TestCase2)

Given I call Shared Step 57506 (Transportation Details 1 - Regulated for Transport(No) - Exemption(Random) - Continue - Happy Path)

Given I call Shared Step 62536 (Transportation Details 2 > I do not ship internationally > Continue - Happy Path)

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
