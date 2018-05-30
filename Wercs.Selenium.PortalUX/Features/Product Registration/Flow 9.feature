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
