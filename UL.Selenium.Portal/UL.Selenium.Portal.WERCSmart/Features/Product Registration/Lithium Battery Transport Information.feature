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
@run_LithiumBatteryTransportInformation
Feature: Lithium Battery Transport Information



Background:
	Given I verify the following users exist and if not I create them using SHAUser
		| username    | FirstName | LastName   | Role         | EmailAddress                |
		| SHAQAAuto16 | QA        | Automation | QA Reviewers | qasha.kxxyxunf@mailosaur.io |

@ScenarioId:1069
Scenario: [65512] BCP - Contains Lithium Ion installed in product - Lithium Battery Transportation step - question wording and validation
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Camera w/Battery
	Then I save the product information as: TestCase65512

	#Andrew - 65511 should be swapped for 159304
	Given I call Shared Step 159304 (Product Information - US, No(Child), No (DSV), No (PLP))

	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Then I should see the Product Includes Battery Page
	Given I set the Indicate how battery is packaged option to: Installed in the product
	Given I add the following batteries:
		| Battery Type | Manufacturer | Number of batteries per package | How many batteries required to run | Saved As       |
		| Lithium Ion  | <any>        | 4                               | 4                                  | lithiumbattery |
	Given I continue to the next screen in the product registration
	Given I call Shared Step 61449 Toxicity Characteristic Leaching Procedure (TCLP) - select No to all - Click Continue - Happy Path
	Given I call Shared Step 58189 (Answer Electronic Equipment questions - With Cathode Ray - No to all)
	Then I should see the Lithium Battery Transportation Page
	And I see the following sections
		| Section                                                                            |
		| For U.S. Department of Transportation (DOT), indicate the transport classification |
	And I should see a total of 3 radio buttons for the section: For U.S. Department of Transportation (DOT), indicate the transport classification
	And The following radio buttons should be displayed for section: For U.S. Department of Transportation (DOT), indicate the transport classification
		| Button                                                                                                                |
		| Meets the requirements of 49CFR173.185(c)(iv) to be transported as non-dangerous goods for road and rail              |
		| Meets the requirements of 49CFR173.185(c)(i) to be transported as non-dangerous goods for road, rail, air, and vessel |
		| Fully-regulated dangerous goods: UN3481, Lithium ion batteries contained in equipment, 9                              |
	And The alert message is displayed with text: Need help? Regulatory services are included in Premium Subscription. Upgrade now!
	And I see the following sections
		| Section                                                  |
		| For Marine transport (IMDG), indicate the classification |
	And I should see a total of 3 radio buttons for the section: For Marine transport (IMDG), indicate the classification
	And The following radio buttons should be displayed for section: For Marine transport (IMDG), indicate the classification
		| Button                                                                                    |
		| Meets requirements of IMDG Special Provision 188 to be transported as non-dangerous goods |
		| Fully-regulated dangerous goods: UN3481, Lithium ion batteries contained in equipment, 9  |
		| None of the above/Not intended for shipment under IMDG                                    |
	And I see the following sections
		| Section                                               |
		| For Air transport (IATA), indicate the classification |
	And I should see a total of 3 radio buttons for the section: For Air transport (IATA), indicate the classification
	And The following radio buttons should be displayed for section: For Air transport (IATA), indicate the classification
		| Button                                                 |
		| Section I                                              |
		| Section II                                             |
		| None of the above/Not intended for shipment under IATA |
	And I see the following sections
		| Section                                                                           |
		| For Canada's Transportation of Dangerous Goods (TDG), indicate the classification |
	And I should see a total of 3 radio buttons for the section: For Canada's Transportation of Dangerous Goods (TDG), indicate the classification
	And The following radio buttons should be displayed for section: For Canada's Transportation of Dangerous Goods (TDG), indicate the classification
		| Button                                                                                       |
		| Meets the requirements of TDG special provision 34 to be transported as non-dangerous goods. |
		| Fully-regulated dangerous goods: UN3481, Lithium ion batteries contained in equipment, 9     |
		| None of the above/Not intended for shipment in Canada                                        |
	Given I click continue
	Then For U.S. Department of Transportation (DOT), indicate the transport classification should be showing the error messages: This is a required field.
	Then For Marine transport (IMDG), indicate the classification should be showing the error messages: This is a required field.
	Then For Air transport (IATA), indicate the classification should be showing the error messages: This is a required field.
	Then For Canada's Transportation of Dangerous Goods (TDG), indicate the classification should be showing the error messages: This is a required field.
	Given I navigate to the home page
	Then The home screen should load
	And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase65512

@ScenarioId:1070
Scenario: [65516] BCP - Contains Lithium Ion packaged with product - Lithium Battery Transportation step - question wording and validation
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Camera w/Battery
	Then I save the product information as: TestCase65516	
	Given I call Shared Step 159304 (Product Information - US, No(Child), No (DSV), No (PLP))
	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Then I should see the Product Includes Battery Page
	Given I set the Indicate how battery is packaged option to: The battery is shipped with but not included in my product
	Given I add the following batteries:
		| Battery Type | Manufacturer | Number of batteries per package | How many batteries required to run | Saved As       |
		| Lithium Ion  | <any>        | 4                               | 4                                  | lithiumbattery |
	Given I continue to the next screen in the product registration
	Given I call Shared Step 61449 Toxicity Characteristic Leaching Procedure (TCLP) - select No to all - Click Continue - Happy Path
	Given I call Shared Step 58189 (Answer Electronic Equipment questions - With Cathode Ray - No to all)
	Then I should see the Lithium Battery Transportation Page
	And I see the following sections
		| Section                                                                            |
		| For U.S. Department of Transportation (DOT), indicate the transport classification |
	And I should see a total of 3 radio buttons for the section: For U.S. Department of Transportation (DOT), indicate the transport classification
	And The following radio buttons should be displayed for section: For U.S. Department of Transportation (DOT), indicate the transport classification
		| Button                                                                                                                |
		| Meets the requirements of 49CFR173.185(c)(iv) to be transported as non-dangerous goods for road and rail              |
		| Meets the requirements of 49CFR173.185(c)(i) to be transported as non-dangerous goods for road, rail, air, and vessel |
		| Fully-regulated dangerous goods: UN3481, Lithium ion batteries packed with equipment, 9                               |
	And The alert message is displayed with text: Need help? Regulatory services are included in Premium Subscription. Upgrade now!
	And I see the following sections
		| Section                                                  |
		| For Marine transport (IMDG), indicate the classification |
	And I should see a total of 3 radio buttons for the section: For Marine transport (IMDG), indicate the classification
	And The following radio buttons should be displayed for section: For Marine transport (IMDG), indicate the classification
		| Button                                                                                    |
		| Meets requirements of IMDG Special Provision 188 to be transported as non-dangerous goods |
		| Fully-regulated dangerous goods: UN3481, Lithium ion batteries packed with equipment, 9   |
		| None of the above/Not intended for shipment under IMDG                                    |
	And I see the following sections
		| Section                                               |
		| For Air transport (IATA), indicate the classification |
	And I should see a total of 3 radio buttons for the section: For Air transport (IATA), indicate the classification
	And The following radio buttons should be displayed for section: For Air transport (IATA), indicate the classification
		| Button                                                 |
		| Section I                                              |
		| Section II                                             |
		| None of the above/Not intended for shipment under IATA |
	And I see the following sections
		| Section                                                                           |
		| For Canada's Transportation of Dangerous Goods (TDG), indicate the classification |
	And I should see a total of 3 radio buttons for the section: For Canada's Transportation of Dangerous Goods (TDG), indicate the classification
	And The following radio buttons should be displayed for section: For Canada's Transportation of Dangerous Goods (TDG), indicate the classification
		| Button                                                                                       |
		| Meets the requirements of TDG special provision 34 to be transported as non-dangerous goods. |
		| Fully-regulated dangerous goods: UN3481, Lithium ion batteries packed with equipment, 9      |
		| None of the above/Not intended for shipment in Canada                                        |
	Given I click continue
	Then For U.S. Department of Transportation (DOT), indicate the transport classification should be showing the error messages: This is a required field.
	Then For Marine transport (IMDG), indicate the classification should be showing the error messages: This is a required field.
	Then For Air transport (IATA), indicate the classification should be showing the error messages: This is a required field.
	Then For Canada's Transportation of Dangerous Goods (TDG), indicate the classification should be showing the error messages: This is a required field.
	Given I navigate to the home page
	Then The home screen should load
	And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase65516

@ScenarioId:1071
Scenario: [65520] BCP - Contains Lithium Primary installed in product - Lithium Battery Transportation step - question wording and validation
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Camera w/Battery
	Then I save the product information as: TestCase65520	
	Given I call Shared Step 159304 (Product Information - US, No(Child), No (DSV), No (PLP))
	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Then I should see the Product Includes Battery Page
	Given I set the Indicate how battery is packaged option to: Installed in the product
	Given I add the following batteries:
		| Battery Type    | Manufacturer                                                 | Number of batteries per package | How many batteries required to run | Saved As |
		| Lithium Primary |Pau Lithium Primary Battery by The WERCS LTD (WPS ID 1549664) | 4                               | 4                                  | lithium  |
	Given I continue to the next screen in the product registration
	Given I call Shared Step 61449 Toxicity Characteristic Leaching Procedure (TCLP) - select No to all - Click Continue - Happy Path
	Given I call Shared Step 58189 (Answer Electronic Equipment questions - With Cathode Ray - No to all)
	Then I should see the Lithium Battery Transportation Page
	And I see the following sections
		| Section                                                                            |
		| For U.S. Department of Transportation (DOT), indicate the transport classification |
	And I should see a total of 3 radio buttons for the section: For U.S. Department of Transportation (DOT), indicate the transport classification
	And The following radio buttons should be displayed for section: For U.S. Department of Transportation (DOT), indicate the transport classification
		| Button                                                                                                                |
		| Meets the requirements of 49CFR173.185(c)(iv) to be transported as non-dangerous goods for road and rail              |
		| Meets the requirements of 49CFR173.185(c)(i) to be transported as non-dangerous goods for road, rail, air, and vessel |
		| Fully-regulated dangerous goods: UN3091, Lithium metal batteries contained in equipment, 9                            |
	And The alert message is displayed with text: Need help? Regulatory services are included in Premium Subscription. Upgrade now!
	And I see the following sections
		| Section                                                  |
		| For Marine transport (IMDG), indicate the classification |
	And I should see a total of 3 radio buttons for the section: For Marine transport (IMDG), indicate the classification
	And The following radio buttons should be displayed for section: For Marine transport (IMDG), indicate the classification
		| Button                                                                                     |
		| Meets requirements of IMDG Special Provision 188 to be transported as non-dangerous goods  |
		| Fully-regulated dangerous goods: UN3091, Lithium metal batteries contained in equipment, 9 |
		| None of the above/Not intended for shipment under IMDG                                     |
	And I see the following sections
		| Section                                               |
		| For Air transport (IATA), indicate the classification |
	And I should see a total of 3 radio buttons for the section: For Air transport (IATA), indicate the classification
	And The following radio buttons should be displayed for section: For Air transport (IATA), indicate the classification
		| Button                                                 |
		| Section I                                              |
		| Section II                                             |
		| None of the above/Not intended for shipment under IATA |
	And I see the following sections
		| Section                                                                           |
		| For Canada's Transportation of Dangerous Goods (TDG), indicate the classification |
	And I should see a total of 3 radio buttons for the section: For Canada's Transportation of Dangerous Goods (TDG), indicate the classification
	And The following radio buttons should be displayed for section: For Canada's Transportation of Dangerous Goods (TDG), indicate the classification
		| Button                                                                                       |
		| Fully-regulated dangerous goods: UN3091, Lithium metal batteries contained in equipment, 9   |
		| Meets the requirements of TDG special provision 34 to be transported as non-dangerous goods. |
		| None of the above/Not intended for shipment in Canada                                        |
	Given I click continue
	Then For U.S. Department of Transportation (DOT), indicate the transport classification should be showing the error messages: This is a required field.
	Then For Marine transport (IMDG), indicate the classification should be showing the error messages: This is a required field.
	Then For Air transport (IATA), indicate the classification should be showing the error messages: This is a required field.
	Then For Canada's Transportation of Dangerous Goods (TDG), indicate the classification should be showing the error messages: This is a required field.
	Given I navigate to the home page
	Then The home screen should load
	And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase65520

@ScenarioId:1072
Scenario: [65523] BCP - Contains Lithium Primary packaged with the product - Lithium Battery Transportation step - question wording and validation
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Camera w/Battery
	Then I save the product information as: TestCase65523	
	Given I call Shared Step 159304 (Product Information - US, No(Child), No (DSV), No (PLP))
	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Then I should see the Product Includes Battery Page
	Given I set the Indicate how battery is packaged option to: The battery is shipped with but not included in my product
	Given I add the following batteries:
		| Battery Type    | Manufacturer                                                  | Number of batteries per package | How many batteries required to run | Saved As |
		| Lithium Primary | Pau Lithium Primary Battery by The WERCS LTD (WPS ID 1549664) | 4                               | 4                                  | lithium  |
	Given I continue to the next screen in the product registration
	Given I call Shared Step 61449 Toxicity Characteristic Leaching Procedure (TCLP) - select No to all - Click Continue - Happy Path
	Given I call Shared Step 58189 (Answer Electronic Equipment questions - With Cathode Ray - No to all)
	Then I should see the Lithium Battery Transportation Page
	And I see the following sections
		| Section                                                                            |
		| For U.S. Department of Transportation (DOT), indicate the transport classification |
	And I should see a total of 3 radio buttons for the section: For U.S. Department of Transportation (DOT), indicate the transport classification
	And The following radio buttons should be displayed for section: For U.S. Department of Transportation (DOT), indicate the transport classification
		| Button                                                                                                                |
		| Fully-regulated dangerous goods: UN3091, Lithium metal batteries packed with equipment, 9                             |
		| Meets the requirements of 49CFR173.185(c)(iv) to be transported as non-dangerous goods for road and rail              |
		| Meets the requirements of 49CFR173.185(c)(i) to be transported as non-dangerous goods for road, rail, air, and vessel |
	And The alert message is displayed with text: Need help? Regulatory services are included in Premium Subscription. Upgrade now!
	And I see the following sections
		| Section                                                  |
		| For Marine transport (IMDG), indicate the classification |
	And I should see a total of 3 radio buttons for the section: For Marine transport (IMDG), indicate the classification
	And The following radio buttons should be displayed for section: For Marine transport (IMDG), indicate the classification
		| Button                                                                                    |
		| Meets requirements of IMDG Special Provision 188 to be transported as non-dangerous goods |
		| Fully-regulated dangerous goods: UN3091, Lithium metal batteries packed with equipment, 9 |
		| None of the above/Not intended for shipment under IMDG                                    |
	And I see the following sections
		| Section                                               |
		| For Air transport (IATA), indicate the classification |
	And I should see a total of 3 radio buttons for the section: For Air transport (IATA), indicate the classification
	And The following radio buttons should be displayed for section: For Air transport (IATA), indicate the classification
		| Button                                                 |
		| Section I                                              |
		| Section II                                             |
		| None of the above/Not intended for shipment under IATA |
	And I see the following sections
		| Section                                                                           |
		| For Canada's Transportation of Dangerous Goods (TDG), indicate the classification |
	And I should see a total of 3 radio buttons for the section: For Canada's Transportation of Dangerous Goods (TDG), indicate the classification
	And The following radio buttons should be displayed for section: For Canada's Transportation of Dangerous Goods (TDG), indicate the classification
		| Button                                                                                       |
		| Fully-regulated dangerous goods: UN3091, Lithium metal batteries packed with equipment, 9    |
		| Meets the requirements of TDG special provision 34 to be transported as non-dangerous goods. |
		| None of the above/Not intended for shipment in Canada                                        |
	Given I click continue
	Then For U.S. Department of Transportation (DOT), indicate the transport classification should be showing the error messages: This is a required field.
	Then For Marine transport (IMDG), indicate the classification should be showing the error messages: This is a required field.
	Then For Air transport (IATA), indicate the classification should be showing the error messages: This is a required field.
	Then For Canada's Transportation of Dangerous Goods (TDG), indicate the classification should be showing the error messages: This is a required field.
	Given I navigate to the home page
	Then The home screen should load
	And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase65523


