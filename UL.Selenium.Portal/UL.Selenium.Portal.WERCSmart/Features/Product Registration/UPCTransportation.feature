@Shared
@ProductGrid
@NewProduct
@Homepage
@run_UPCTransportation
Feature: UPCTransportation

@tfs_design
Scenario: [122305] UPC Transportation options are present if product-level options are present
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I generate a random UPC number and save as: RandomUPC
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bleach
	Given I save the product information as: TestCase122305
	Given I call Shared Step 74760 (Product Characteristics - Select Liquid as primary physical state and enter all required data)
		| Boiling Point (in Celsius) | Flash Point (in Celsius) | Flash Point Testing Method Used | pH | Primary Physical State | Secondary Physical State | Select the best Water Solubility description | Specific Gravity |
		| 2                          | 66                       | Closed cup method               | 2  | Liquid                 | Liquid                   | Appreciable                                  | 2                |
	Given I call Shared Step 74340 (Additional Product Information - Pesticide= Not considered, SOLD=US, everything else = No - Continue)
	Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Chlorine
	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given I should see the Transportation Details 1 Page
	Given I set the Product is Regulated for Transport field to: Yes
	Given I call Shared Step 65698 (Transport - Select DOT & Limited Shipping - No Continue)
	Given I call Shared Step 65700 (Transportation Details 1 - Select IATA & Limited Shipping)
	Given I click continue
	Given I call Shared Step 65705 (Transportation - DOT UN step - Enter UN1950, select Aerosols, 2.1, None, add technical name, Click Continue)
	Given I should see the International Air Transport (IATA) Classification Page
	Given I check the checkbox with description: Copy information from my U.S. Department of Transportation data
	Given I click continue
	Given I select the following retailers in the Select Retailers popup list view:
		| Retailer  |
		| Walgreens |
	# Check for UPC Transport column
	# Ensure that IATA and DOT are selected at Limited Quantity
	# Ensure that you cannot downgrade DOT to Consumer Commodity
	# Ensure that you cannot downgrade IATA to Consumer Commodity
	# Ensure that you can select only one exception in the UPC Transportation column
	# Ensure that IMDG and TDG options are not present
	# Upgrade DOT to Fully Regulated
	# Upgrade IATA to Fully Regulated
	Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPCRandomUPC, container type: Plastic Container and size: 2
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Appearance | Autoignition Temperature | Minimum Ignition Energy | Odor     | Odor Threshold    | Partition Coefficient | Personal Protection Equipment | Viscosity |
		| Black      | 300                      | 1.005                   | Odorless | No data available | 10                    | Mask                          | 20        |
	Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: test
	Given I click the Summary button in the Data Acceptance window
	Given I switch to the Data Summary page
	# Ensure that at the product-level, DOT and IATA are set to Limited Quantity
	# Ensure that in the UPC table, you see a Transportation column
	# Ensure that in the Transportation column in the UPC table, you see DOT and IATA listed as Fully Regulated
	Given I close the window that opened
	Given I navigate to the home page
	Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase122305
