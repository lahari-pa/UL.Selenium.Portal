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
@SummaryPage
@run_NewProduct

Feature: New Product

@ScenarioId:1113
Scenario: [31343] New Product screen navigation
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Given If I see the retail partners page I set all data consent tiers to true for all retailers in the top section
Then The home screen should load
Then I click the Register New Product icon in the Navigation Pane
And I should see the header New Product
And I should see the following radio buttons:
| Button                             |
| Create a New Registration          |
| Copy from an Existing Registration |

#TODO: create another test case for ULSC options in New product screen


@ScenarioId:1114
Scenario: [31344] New Product Screen validation
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Given If I see the retail partners page I set all data consent tiers to true for all retailers in the top section
Then The home screen should load
Given I click the Register New Product icon in the Navigation Pane
When I click continue
Then I should see an error message: This is a required field.


@ScenarioId:1115
Scenario: [82750] Copy from an Existing Registration validation
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Given If I see the retail partners page I set all data consent tiers to true for all retailers in the top section
Then The home screen should load
Given I click the Register New Product icon in the Navigation Pane
And I set the Select the type of product to create: option to: Copy from an Existing Registration
When I click continue
Then I should see an error message: This is a required field.


@ScenarioId:6336
Scenario: [87295] 3rd party Ingredients - Informational Message
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk
	Then I save the product information as: TestCase87295
	Given I call Shared Step 26897 (Product Characteristics - Solid only available - continue)
	Given I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	#And I call Shared Step 29181 (Ingredients - add any chemical) with name: WPS
	Given I call Shared Step 65447 Ingredients - Add any chemical - DO Not click Continue
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| WPS           | 100     |                     |             |            |
	Given I click continue
	Then a Warning popup dialog should appear with the message: Your product contains a 3rd-Party Formula that may need Data Tier Consent, or if Consent has been accepted by the Formulator, has no ingredients that are indicated to be Public. A notification has been provided to the Formulator to revisit their registration and resubmit if necessary. You may continue with your registration. Should the 3rd-Party Formula be revised, your registration will be updated accordingly and revised scoring will occur. No action is required from you.
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase87295



@ScenarioId:6335
Scenario: [74944] BCP - Contains Lithium Primary packaged with the product - Lithium Battery Transportation step - question validations
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	And I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Camera w/Battery
	Then I save the product information as: TestCase74944
	And I call Shared Step 70393 (Additional Product Information - With marketed for use by a Child - Direct Ship - Private Label questions only)
	And I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Then I should see the Product Includes Battery Page
	Given I set the Indicate how battery is packaged option to: The battery is shipped with but not included in my product.
	Given I add the following batteries:
		| Battery Type     | Manufacturer | Number of batteries per package | How many batteries required to run | Saved As       |
		| Lithium Primary  | <any>        | 4                               | 4                                  | lithiumbattery |
	Given I click continue
	And I call Shared Step 48369 (Toxicity Characteristics Leaching Procedure (TCLP) - No to ALL With Copper)
	And I call Shared Step 58189 (Answer Electronic Equipment questions - With Cathode Ray - No to all)
	Given I click continue
	Given I check for an error in the following fields in the 'Lithium Battery Transportation' Section
	| Field                                                                              |
	| For U.S. Department of Transportation (DOT), indicate the transport classification |
	| For Marine transport (IMDG), indicate the classification                           |
	| For Air transport (IATA), indicate the classification                              |
	| For Canada's Transportation of Dangerous Goods (TDG), indicate the classification  |
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase74944


@ScenarioId:10108
Scenario: [128694] DSV Option Available for Electronic - Peripherals - RU001162

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Peripherals (Keyboard, Mouse, Trackball) without Battery
Then I save the product information as: TestCase128694
Then I confirm that the the option: United States is checked for the following section: Select countries the product may be sold in
And The following options should be displayed exclusively for section: Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns.
| Option |
| Yes    |
| No	 |
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase128694



@ScenarioId:10107
Scenario: [128721] DSV Option Available for Appliance - Hot Water Tank (Standard, no electronic components) - RU001206

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Appliance - Hot Water Tank (Standard, no electronic components)
Then I save the product information as: TestCase128721
Then I confirm that the the option: United States is checked for the following section: Select countries the product may be sold in
And The following options should be displayed exclusively for section: Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns.
| Option |
| Yes    |
| No	 |
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase128721



@ScenarioId:10147
Scenario: [128703] DSV Option Available for Auto Parts - Engine Parts and Components with Electrical Parts -  RU001428

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Engine Parts and Components with Electrical Parts
Then I save the product information as: TestCase128703
Then I confirm that the the option: United States is checked for the following section: Select countries the product may be sold in
And The following options should be displayed exclusively for section: Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns.
| Option |
| Yes    |
| No	 |
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase128703



@ScenarioId:10277
Scenario: [144527] Medical Test Kit With Alcohol Swab - RU000955 - Flow 8S

Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Medical Test Kit With Alcohol Swab
Given I generate a random UPC number and save as: UPC144527
Then I save the product information as: TestCase144527
Given I call Shared Step 26897 (Product Characteristics - Solid only available - continue)
Given I call Shared Step 57401 (Additional Product Information - US only - No GHS, Not Direct Ship, Not PLP, Not GNFR > Continue - Happy Path)
Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
| CASNumber | ComponentName | Percent | PublicallyDisclosed | PublicName | TradeSecret |
|           | Alcohol       | 100     |                     |            |             |
Given I call Shared Step 132370 (Waste Classification Data - TSCA (Random) - Prop 65 (No) - Continue - Happy Path)
And I set the Product is Regulated for Transport option to: No, due to an exemption or exception
And The following checkboxes should be displayed for section: Please select DOT Exceptions if applicable?
		| Checkbox																		                                                    |
		|  172.102(c) - Special Provision 47: Product contains 10 mL or less of a Class 3 liquid and is fully absorbed with no free liquid. |
		And The following checkboxes should not be displayed for section: Please select DOT Exceptions if applicable?
		| Checkbox														|
		| 173.159 (a) - Exemption for non-spillable lead-acid batteries |
And I set the Please select DOT Exceptions if applicable? field to: 172.102(c) - Special Provision 47: Product contains 10 mL or less of a Class 3 liquid and is fully absorbed with no free liquid.
And I click continue
And I call Shared Step 62536 (Transportation Details 2 > I do not ship internationally > Continue - Happy Path)
Given I call Shared Step 75146 (Retailer - Select One or More Retailers that DO NOT REQUIRE Vendor ID or Additional UPC Information, Click Done, Click Continue)
Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC144527, container type: Plastic Container and size: 9
Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
Given I click continue
Given I click continue
Given I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
| Appearance        | Autoignition Temperature | Minimum Ignition Energy | Odor    | Odor Threshold | Partition Coefficient | Personal Protection Equipment | Viscosity |
| No data available |                          |                         | Neutral | Not applicable | 9                     |                               |           |
Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: Testing comment area
Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
Given I call Shared Step 54796 (Purchase Summary)
Given I navigate to the home page
And I search for the product saved as: TestCase144527
When I click Row Actions for the most recent product returned
Then I click on the Row Action: View
Then A Summary page should open in a new browser tab
Then I confirm the following section: Please select DOT Exceptions if applicable? has the following value: 172.102(c) - Special Provision 47: Product contains 10 mL or less of a Class 3 liquid and is fully absorbed with no free liquid. in the Summary Page
Given I close the browser tab with the Summary page


@ScenarioId:10283
Scenario: [144468] Alcoholic Beverages - With DOT Exception

Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Alcoholic Beverages - Beer
Then I save the product information as: TestCase144468
Given I call Shared Step 62686 (Enter Physical Property - Liquid - Without Water Solubility)
Then I confirm that the the option: United States is checked for the following section: Select countries the product may be sold in
Given I set the Product is a Retailer's Private Label or Brand option to exactly match: No
Given I click continue
And I should see the Waste Classification Data Page
Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
Given I call Shared Step 49818 (Beverage Regulatory Details)
And I set the Product is Regulated for Transport option to: No, due to an exemption or exception
And The following checkboxes should not be displayed for section: Please select DOT Exceptions if applicable?
		| Checkbox                                                     |
		| 173.159(a) - Exemption for non-spillable lead-acid batteries |
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase144468
