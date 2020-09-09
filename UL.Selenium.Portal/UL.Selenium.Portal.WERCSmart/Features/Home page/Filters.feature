@Shared
@wercsmart
@run_Filters
@Login
@UlSolutionCenter
@Homepage
@ProductGrid
@ForwardProductRegistration
@NewProduct
@RetailPartners
@MessageCenter
@MyAccount
@LandingPage
@DocumentAcceptance
@DeleteActiveProducts
@Solutions
@ReviewDocuments
@SHA
@SummaryPage
@PaymentMethods
@ProductSetUp
@CreateProducts

Feature: Filters

@ScenarioId:449
Scenario: [68388] More Filters - Brand
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I create a new product of type: Bleach, with a Product Line/ Brand added and select Type of Product: Bleach
	And I should see an option for More Filters
	Given I click More Filters in the products grid
	Given I select the More Filters - Brand saved as: Brand68388 by ID
	Given I click Row Actions for the first product returned
	And I click on the Row Action: Edit
	Given In the New Product page I click tab: Product Type
	And I click the page heading: The Product
	# step accepts '~saved as...' and will fetch the value from context
	Then Product Line or Brand (optional) should be showing the value: ~saved as BrandName68388
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase68388

@morefilters
@ScenarioId:5956
Scenario: [56829] More Filters
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I search for product by name: Kit Product 56829 and save the first grid item as: Kit_56829
	And I create a Kit product and save details as: Kit_56829
	And I navigate to the landing page
	And I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	And I should see an option for More Filters
	Given I click More Filters in the products grid
	Given I confirm the product exists with Product ID: Kit_56829_ID and Name: Kit Product 56829
	Given I enter combinations of More Filters and should see the product ID: Kit_56829_ID only for the correct combinations
		| Filter              | Match               |
		| UPC                 | %Kit_56829_UPC%     |
		| Brand               | TestBrand           |
		| Retailer            | Wal-Mart/SAM'S CLUB |
		| Additional Programs | Kit Registrations   |
	Given I enter combinations of Status and More Filters and should see the product ID: Kit_56829_ID only for the correct combinations
		| Filter              | Match                  |
		| Status              | Assessment in Progress |
		| Brand               | TestBrand              |
		| Retailer            | Wal-Mart/SAM'S CLUB    |
		| Additional Programs | Kit Registrations      |
	#Given I click More Filters in the products grid
	#Then the 'More Filters' options are not displayed
	#Given I click More Filters in the products grid
	#Then the 'More Filters' options are displayed
	#Given I click More Filters in the products grid
	#Then the 'More Filters' options are not displayed

# Assigned to Amanda Coutant
# Created by Amanda Coutant
@ScenarioId:451
Scenario: [68413] More Filters - Retailer
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I click More Filters in the products grid
	And I confirm the filter with label: "Retailer" is displayed and default option: "All Retailers"
	And I confirm retailers list based on environment
	And I select the Wal-Mart/SAM'S CLUB option in the Retailer More Filters drop down
	And I Select the check box next to Show Archived Retailers
	And I confirm all products in the grid contain either the the text "WM" or "All" under the 'Retailers' column



	#Philip-Feature
@ScenarioId:10277
Scenario: [144527] Medical Test Kit With Alcohol Swab - RU000955 - Flow 8S

Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Medical Test Kit With Alcohol Swab
Given I generate a random UPC number and save as: UPC144527
Given I call Shared Step 26897 (Product Characteristics - Solid only available - continue)
Given I call Shared Step 57401 (Additional Product Information - US only - No GHS, Not Direct Ship, Not PLP, Not GNFR > Continue - Happy Path)
Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
| CASNumber | ComponentName | Percent | PublicallyDisclosed | PublicName | TradeSecret |
|           | Alcohol       | 100     |                     |            |             |
Given I call Shared Step 132370 (Waste Classification Data - TSCA (Random) - Prop 65 (No) - Continue - Happy Path)
# In Transportation Details 1 section; for question: "Product is Regulated for Transport" select option: "No, due to an exemption or exception"# Confirm for question: "Please select DOT Exceptions if applicable?" option" 172.102(c) - Special Provision 47: Product contains 10 mL or less of a Class 3 liquid and is fully absorbed with no free liquid." displays# Confirm that the following DOT Exception does not display in the list: "173.159 (a) - Exemption for non-spillable lead-acid batteries"# Select option: 172.102(c) - Special Provision 47: Product contains 10 mL or less of a Class 3 liquid and is fully absorbed with no free liquid.# Click 'CONTINUE'Given I call Shared Step 62536 (Transportation Details 2 &gt; I do not ship internationally &gt; Continue - Happy Path)
And I call Shared Step 57506 (Transportation Details 1 - Regulated for Transport(No) - Exemption(Random) - Continue - Happy Path)
And I call Shared Step 62536 (Transportation Details 2 > I do not ship internationally > Continue - Happy Path)
Given I call Shared Step 75146 (Retailer - Select One or More Retailers that DO NOT REQUIRE Vendor ID or Additional UPC Information, Click Done, Click Continue)
Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC144527, container type: Plastic Container and size: 9
Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
Given I click continue
Given I click continue
# Click 'Continue' on Additional Documents to Provide section# Click 'Continue' on Optional Reports and Documents Available for Purchase section
Given I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
| Appearance        | Autoignition Temperature | Minimum Ignition Energy | Odor    | Odor Threshold | Partition Coefficient | Personal Protection Equipment | Viscosity |
| No data available |                          |                         | Neutral | Not applicable | 9                     |                               |           |
Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: Testing comment area
Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
Given I call Shared Step 54796 (Purchase Summary)
# From the  My Products grid - filter for the product you are working with
# Click the ... icon from the Actions column for the  product; Menu items are shown
# Click View; New window opens with Summary view for the product shown4
# Scroll down to option: "Please select DOT Exceptions if applicable?"
# Confirm you see option: "172.102(c) - Special Provision 47: Product contains 10 mL or less of a Class 3 liquid and is fully absorbed with no free liquid."
# Close Summary tab
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: product ID


@ScenarioId:10283
Scenario: [144468] Alcoholic Beverages - With DOT Exception

Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Alcoholic Beverages - Beer
Given I call Shared Step 62686 (Enter Physical Property - Liquid - Without Water Solubility)
# In "Additional Product Information" Page; For the "Select Countries the Product May Be Sold In" Question - By default the "United States" checkbox will be selected
#  Select "NO" for the "Product is a Retailer's Private Label or Brand" Question# Click 'CONTINUE'; Transitions to "Waste Classification Data" Page
Given I set the Product is a Retailer's Private Label or Brand option to exactly match: No
Given I click continue
And I should see the Waste Classification Data Page
Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
Given I call Shared Step 49818 (Beverage Regulatory Details)
And I call Shared Step 57506 (Transportation Details 1 - Regulated for Transport(No) - Exemption(Random) - Continue - Happy Path)
And I call Shared Step 62536 (Transportation Details 2 > I do not ship internationally > Continue - Happy Path)
# In "Transportation Details 1" section; for question: "Product is Regulated for Transport" Select "No, due to an exemption or exception"
# Confirm that in the list of DOT Exceptions the option: "173.159(a) - Exemption for non-spillable lead-acid batteries" does not display as an option
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: testcase



