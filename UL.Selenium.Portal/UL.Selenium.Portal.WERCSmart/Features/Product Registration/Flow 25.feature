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
@run_Flow25

Feature: Flow 25

@ScenarioId:708
Scenario: [60642] Engine Parts and Components with Battery Included - RU001430

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

Given I generate a random UPC number and save as: UPC60642

Given I delete all products with UPC Number: saved as UPC60642

Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))

Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Engine Parts and Components with Battery Included

Then I save the product information as: TestCase60642

Given I call Shared Step 60935 (Product Information - US - Direct Ship - Private Label Only)

Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)

Then I should see battery manufacturer message: Important: Prior to registering your battery-containing product, the battery manufacturer must first register the contained battery.

Given I call Shared Step 48367 (Product Includes Battery > any type)
| Battery Type | Manufacturer | Quantity of Batteries per Package | Quantity of Batteries to Operate Product |
| Alkaline     | <any>        | 6                               | 6                                  |

Given I click continue

Given I call Shared Step 48369 (Toxicity Characteristics Leaching Procedure (TCLP) - No to ALL With Copper)

Given I call Shared Step 71955 (Answer Electronic Equipment questions - Without Cathode Ray - No to all)

Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Genuine Parts

Then I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC60642, container type: Cardboard and size: 33

Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: User added Comments Text 60642. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)

Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Engine Parts and Components with Battery Included

Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase60642



@ScenarioId:709
Scenario: [60643] Cameras / Camcorders w/Battery - RU000932

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

Given I generate a random UPC number and save as: UPC60643

Given I delete all products with UPC Number: saved as UPC60643

Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))

Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Camera w/Battery

Then I save the product information as: TestCase60643

Given I call Shared Step 70393 (Product Information - With marketed for use by a Child - Direct Ship - Private Label questions only)

Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)

Given I call Shared Step 48367 (Product Includes Battery > any type)
| Battery Type | Manufacturer | Quantity of Batteries per Package | Quantity of Batteries to Operate Product |
| Alkaline     | <any>        | 6                               | 6                                  |

Given I call Shared Step 48369 (Toxicity Characteristics Leaching Procedure (TCLP) - No to ALL With Copper)

#Given I call Shared Step 71955 (Answer Electronic Equipment questions - Without Cathode Ray - No to all)

Given I call Shared Step 58189 (Answer Electronic Equipment questions - With Cathode Ray - No to all)

Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Amazon

Then I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC60643, container type: Cardboard and size: 33

Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: User added Comments Text 60643. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)

Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Camera w/Battery

Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase60643
