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


Scenario: [87295] 3rd party Ingredients - Informational Message
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk
	Then I save the product information as: TestCase87295
	Given I call Shared Step 26897 (Product Characteristics - Solid only available - continue)
	Given I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	And I call Shared Step 29181 (Ingredients - add any chemical) with name: WPS
	Then I check for the following alert message in the warning popup in the 'Ingredients' Page: Your product registration contains a 3rd-Party Formula that needs to be updated for it to be included in chemical-policy or sustainability assessments conducted by retailers or in GoodGuide ratings. We have sent a notification to your 3rd-Party Formulator requesting that the ingredient's Data Use Tier consent, and the public disclosure status of its ingredients, be updated. Please continue with this product registration, but note that the chemical-policy or sustainability assessment results may change if, and when, your 3rd-Party Formulator authorizes its ingredient to be included in such programs.
	And I close the warning popup in the 'Ingredients' Page
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
