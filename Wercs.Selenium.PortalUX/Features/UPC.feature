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
