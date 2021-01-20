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


Scenario: [136058] The Product - Industrial Category not available for Selection
	
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I set the Product Name as it a appears on the Package Label, Container or Safety Data Sheet (SDS) field to: Product Name as it a appears on the Package Label, Container or Safety Data Sheet (SDS)
#Given I fill in the 'Type of Product' with: For Industrial use only
Given I set 'Type of Product' to: For Industrial use only
Given I confirm no results are returned
Given I set 'Type of Product' to: Laboratory use only
Given I confirm no results are returned
Given I set 'Type of Product' to: Pharmaceutical use only
Given I confirm no results are returned
Given I set 'Type of Product' to: Profession use only
Given I confirm no results are returned
Given I set 'Type of Product' to: Research and Development use only
Given I confirm no results are returned
