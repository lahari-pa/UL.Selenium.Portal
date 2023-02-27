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
@run_Flow18

Feature: Flow 18

@ignore
@tfsdesign
@TestCase:60116
Scenario: [60116] Anti-Static Product - Aerosol - RU000656

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

Given I generate a random UPC number and save as: UPC60116

Given I delete all products with UPC Number: saved as UPC60116

Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)

Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Anti-Static Product - Aerosol

Then I save the product information as: TestCase60116

Given I call Shared Step 60310 (Product Information - Without Child question)

Given I call Shared Step 57111 (Enter Product Data for Physical State - Aerosol only)


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

Then I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC60116, container type: Aerosol Can and size: 1

Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)

Given I call Shared Step 60567 (Upload Product Label only) for section: Volatile Organic Compounds

And in the Optional Reports and Documents Available for Purchase page I click Continue

Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient | Product's Dispensing Method |
| Mask                          | 150                      | 44                      | 10.7      | White      | Floral | No data available | 12                    | Aerosol                     |

Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: User added Comments Text 60116. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)

Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Anti-Static Product - Aerosol

Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase60116


# Created by Saikiran Chittampally
@TestCase:208099
Scenario: [208099] Fabric Softener - Single-Use Dryer Product Only (RU000808)
	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Fabric Softener - Single Use Dryer Product Only
	Then I save the product information as: TestCase208099
	Given I call Shared Step 208116 Product Information - FIFRA 25(b) Product Not a Pesticide, US (SOLD), NO (OSHA), NO (DSV), YES (CA RTK), NO (PL), NO (GNFR)
	Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I call Shared Step 193979 California Cleaning Product Disclosure - Final Domestic Distributor
	Given I add the following CA Cleaning ingredients:  
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName     | IngredientType | FunctionalPurpose             | Clean | Certified |
		| Water         | 100     | true               | false       | AQUA           | Fragrance      |  |   |       |
	Then I click continue
	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Then I should see the Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB) Page
	Then I see the following questions
		| Section                                                                                                                                        |
		| Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations. |
	Then The following options should be displayed for section: Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations.
		| Option |
		| Yes    |
		| No     |
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase208099
