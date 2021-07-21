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
@SHA
@PaymentMethods
@NewProduct
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
	Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
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
	And I call Shared Step 70393 (Product Information - With marketed for use by a Child - Direct Ship - Private Label questions only)
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




@ScenarioId:10618
Scenario: [149421] CBD - Registration with CBD Ingredient in Formulation

Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
Given I generate a random UPC number and save as: UPC149421
Then I save the product information as: TestCase149421
Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
| CASNumber | ComponentName | Percent | PublicallyDisclosed | PublicName | TradeSecret |
|           | Chalk         | 50      |                     |            |             |
| 1244582   |               | 50      |                     |            |             |
Given I confirm the CBD Registration Guidance popup appears in the Ingredients Page with the correct text
Given I click the link in the CBD Registration Guidance popup
Given I switch to the tab: https://www.fda.gov/news-events/public-health-focus/fda-regulation-cannabis-and-cannabis-derived-products-including-cannabidiol-cbd
Given I check that the current URL contains: https://www.fda.gov/news-events/public-health-focus/fda-regulation-cannabis-and-cannabis-derived-products-including-cannabidiol-cbd
Given I close the current tab
Given I close the CBD Registration Guidance popup in the Ingredients Page
Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Given I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue) for
| Retailer |
| CVS      |
Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC149421, container type: Plastic Container and size: 15.2
Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
Given in the Additional Documents to Provide page I click Continue
Given in the Optional Reports and Documents Available for Purchase page I click Continue
Given I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
| Appearance | Autoignition Temperature | Minimum Ignition Energy | Odor  | Odor Threshold           | Partition Coefficient | Personal Protection Equipment | Viscosity |
| Amber      |                          |                         | Apple | No information available | 4                     |                               |           |
Given I click continue
Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
And In the Purchase Summary screen I confirm the Purchase Summary header is displayed
And In the Purchase Summary screen if Product Billing is displayed I click Confirm Order
Given I call Shared Step 65080b (Login to Studio as user saved as: SHAQAAuto16 and Open SHA manager)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Submitted Status for saved as: TestCase149421)
Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase149421)
Given I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase149421)
Given I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase149421)
Given I call Shared Step 75347 (WPS Studio - PD+ - set all data and publish using rule and Doc queue - CKLT, NGHS and SBCS) for product saved as: TestCase149421
Given I call Shared Step 59066 (Go to SHA Manager)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Assigned Status for saved as: TestCase149421)
Given I call Shared Step 75347 (WPS Studio - PD+ - set all data and publish using rule and Doc queue - CKLT, NGHS and SBCS) for product saved as: TestCase149421
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Accepted Status for saved as: TestCase149421)
Given I call Shared Step 51664 (SHA - Accepted Product - set Retailers to Completed for saved as: TestCase149421) for
| Retailer |
| CVS      |


@tfs_design
@ScenarioId:10619
Scenario: [145400] Battery Containing Mercury - RU000729 - Uploaded Documents

Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Battery Containing Mercury
Given I generate a random UPC number and save as: UPC145400
Then I save the product information as: TestCase145400
	Given I call Shared Step 102767 (Product Information (Battery flow - not Lithium) - OSHA (No), DSV (No), PLP (No), GNFR (No))
Given I call Shared Step 59927 (Primary Physical State > Solid only available – Without Water Solubility question)
Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
| CASNumber | ComponentName | Percent | PublicallyDisclosed | PublicName | TradeSecret |
|           | mercury       | 100     |                     |            |             |
Given I call Shared Step 145355 Formulation > Batteries - Select Granted - Continue
Given I call Shared Step 104276 (Enter Regulatory Information - TSCA, CEPA, Not Prop 65)
Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Amazon
Given I call Shared Step 60826 (Enter Universal Product Code (UPC) - Battery - Confirm Quantity ) for UPC saved as: UPC145400 with container type: Metal Container size: 40.0 and quantity: 100
Given I call Shared Step 145129 Regulatory Documents to Provide - Upload AIS and CCCR
Given in the Additional Documents to Provide page I click Continue
Given in the Optional Reports and Documents Available for Purchase page I click Continue
Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: Testing the comments text box to make sure it is working properly.
Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
Given I call Shared Step 65080b (Login to Studio as user saved as: SHAQAAuto16 and Open SHA manager)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Submitted Status for saved as: TestCase145400)
And In SHA Manager I select the first product
And I click the following option in the bottom menu: Review



@tfs_design
Scenario: [120820] WERCSmart product - Submitted to SHA, Status = Cancelled

Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I generate a random UPC number and save as: UPC120820
Then I save the product information as: TestCase120820
Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
Given I generate a random UPC number and save as: UPC120820
Then I save the product information as: TestCase120820
Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Chalk
Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Given I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue) for
		| Retailer  |
		| Walgreens |
Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC120820, container type: Plastic Container and size: 15.2
Given I call Shared Step 78080 (Regulatory Documents to Provide - Upload OSHA SDS)
Given I click continue
Given I click continue
Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: test
Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
Given If purchase details are showing click confirm order
Given In the Thank You screen I click Home
Given I call Shared Step 65080b (Login to Studio as user saved as: SHAQAAuto16 and Open SHA manager)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Submitted Status for saved as: TestCase120820)
And I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase120820)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Assigned Status for saved as: TestCase120820)
Given I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase120820)
Given I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase120820)
Given I call Shared Step 75347 (WPS Studio - PD+ - set all data and publish using rule and Doc queue - CKLT, NGHS and SBCS) for product saved as: TestCase120820
And I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase120820)
Given I call Shared Step 59066 (Go to SHA Manager)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Accepted Status for saved as: TestCase120820)
Given I call Shared Step 155714 (SHA - Accepted Product - set Retailers to Cancelled for saved as: TestCase120820) for
| Retailer |
| Walgreens|
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Cancelled Status for saved as: TestCase120820)




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


@ScenarioId:10647
Scenario: [136058] The Product - Industrial Category not available for Selection
	
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I set the Product Name as it a appears on the Package Label, Container or Safety Data Sheet (SDS) field to: Product Name as it a appears on the Package Label, Container or Safety Data Sheet (SDS)
Given I set non-existent 'Type of Product': For Industrial use only
Given I confirm no results are returned
Given I clear 'Type of Product'
Given I set non-existent 'Type of Product': For Laboratory use only
Given I confirm no results are returned
Given I clear 'Type of Product'
Given I set non-existent 'Type of Product': For Pharmaceutical use only
Given I confirm no results are returned
Given I clear 'Type of Product'
Given I set non-existent 'Type of Product': For Profession use only
Given I confirm no results are returned
Given I clear 'Type of Product'
Given I set non-existent 'Type of Product': For Research and Development use only
Given I confirm no results are returned
Given I clear 'Type of Product'



@ScenarioId:10715
Scenario: [159942] Tire, Off-Road - Pneumatic & Tires Not Intended for Road Use RU001423

Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Tire, Off-Road - Pneumatic & Tires Not Intended for Road Use
Given I save the product information as: TestCase159942
Given I set the Select countries the product may be sold in option to: United States
Given I set the Select countries the product may be sold in option to: Canada
Given I set the Product is a Retailer's Private Label or Brand option to: No
Given I click continue
Given I call Shared Step 57637 (Regulatory Information 1 - TSCA & CEPA shown, No to PROP 65 - Continue - Happy Path)
Given in the Tire Regulatory Details page I click Continue
And Product is intended for agricultural use only should be showing the error messages: This is a required field.
And Weight in kilograms (single unit) should be showing the error messages: This is a required field.
And Height in inches (single unit) should be showing the error messages: This is a required field.
Given I set the Product is intended for agricultural use only option to: No
Given I set the Weight in kilograms (single unit) field to: abc
And Weight in kilograms (single unit) should be showing the error messages: Enter a valid number
Given I set the Weight in kilograms (single unit) field to: !@#
And Weight in kilograms (single unit) should be showing the error messages: Enter a valid number
Given I set the Weight in kilograms (single unit) field to: 12
Given I Select a height from the drop down list
Given I click continue
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase159942
