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
@run_Flow18

Feature: Flow 18

@tfsdesign
Scenario: [60116] Anti-Static Product - Aerosol - RU000656

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

Given I generate a random UPC number and save as: UPC60116

Given I delete all products with UPC Number: saved as UPC60116

Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)

Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Anti-Static Product - Aerosol

Then I save the product information as: TestCase60116

Given I call Shared Step 57111 (Enter Product Data for Physical State - Aerosol only)

Given I call Shared Step 60310 (Additional Product Information - Without Child question)

Given I click continue

Then I should see an error message: ALERT! The ingredient table does not include a compressed gas (Bag-On-Valve) or a propellant. Please update your ingredients to include the propellant before proceeding.

Given I call Shared Step 69557 (Enter Ingredients for Aerosol Propellent)

Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)

Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)

Given I call Shared Step 65705 (Transportation - DOT UN step - Enter UN1950, select Aerosols,  2.1, None, add technical name, Click Continue)

Given I call Shared Step 62710 (Confirm VOC OTC/CARB heading and select No to FIRST QUESTION ONLY - Happy Path)

Given I call Shared Step 60468 (VOC - CARB only required - enter value - Continue - Happy Path)

Given I click continue

Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Staples

Then I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC60116, container type: Aerosol Can and size: 33

Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)

Given I call Shared Step 60567 (Upload Product Label only) for section: Volatile Organic Compounds

And in the Optional Reports and Documents Available for Purchase page I click Continue

Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient | Product's Dispensing Method |
| Mask                          | 150                      | 44                      | 10.7      | White      | Floral | No data available | 12                    | Aerosol                     |

Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: User added Comments Text 60116. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)

Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Anti-Static Product - Aerosol

Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase60116

