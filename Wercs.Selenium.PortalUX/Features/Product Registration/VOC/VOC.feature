@Login
@Homepage
@Signup
@wercsmart
@NewProduct
@ProductGrid
@DataSummarySheet
@wercsmart
@RetailPartners
@run_voc

Feature: VOC


@test74626
Scenario: [74626] VOC - Show state collection when state table has a value

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))

Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Insecticide - Fogger

Then I save the product information as: TestCase74626

Then I call Shared Step 57454 (Product Characteristics - Aerosol & Gas available - Select Aerosol - Continue - Happy Path)

Given I call Shared Step 57865 (Additional Product Information - Pesticide shown, US only, select No for everything else - Happy Path)

Given I call Shared Step 69557 (Enter Ingredients for Aerosol Propellent)

Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)

Given I call Shared Step 57589 (Enter Pesticide Data - United States (without EPA number))

Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)

Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)

Given I call Shared Step 57923 (Volatile Organic Compound (VOC) Step - enter OTC and CARB - Yes for state values)
| Product granted Alternative Control Plan | Amount of VOC by CARB | Amount of VOC by OTC Model | VOC for states |
| No                                       | 0                     | 0                          | Yes            |

And I should see the following Voc percent for each state:
| State           | Regulation            | VOC Value | State VOC Threshold | Message                          |
| Connecticut     | State Allowable Limit | 0         | 45                  | Does not exceed the State Limits |
| Washington D.C. | State Allowable Limit | 0         | 45                  | Does not exceed the State Limits |
| Delaware        | State Allowable Limit | 0         | 45                  | Does not exceed the State Limits |
| Illinois        | State Allowable Limit | 0         | 45                  | Does not exceed the State Limits |
| Indiana         | State Allowable Limit | 0         | 45                  | Does not exceed the State Limits |
| Massachusetts   | State Allowable Limit | 0         | 45                  | Does not exceed the State Limits |
| Maryland        | State Allowable Limit | 0         | 45                  | Does not exceed the State Limits |
| Maine           | State Allowable Limit | 0         | 45                  | Does not exceed the State Limits |
| Michigan        | State Allowable Limit | 0         | 45                  | Does not exceed the State Limits |
| New Hampshire   | State Allowable Limit | 0         | 45                  | Does not exceed the State Limits |
| New Jersey      | State Allowable Limit | 0         | 45                  | Does not exceed the State Limits |
| New York        | State Allowable Limit | 0         | 45                  | Does not exceed the State Limits |
| Ohio            | State Allowable Limit | 0         | 45                  | Does not exceed the State Limits |
| Pennsylvania    | State Allowable Limit | 0         | 45                  | Does not exceed the State Limits |
| Rhode Island    | State Allowable Limit | 0         | 45                  | Does not exceed the State Limits |
| Utah            | State Allowable Limit | 0         | 45                  | Does not exceed the State Limits |
| Virginia        | State Allowable Limit | 0         | 45                  | Does not exceed the State Limits |
| Vermont         | State Allowable Limit | 0         | 45                  | Does not exceed the State Limits |

Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase74626
