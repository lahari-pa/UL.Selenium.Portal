@Shared
@NewProduct
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
@PaymentMethods
@SubEnrollment
@WERCSmart_Signup
@MyAccount
@PackagingTypes
@Brands
@MyIngredients
@UPC
@ProductSetUp
@SHA
@Studio
@ForwardProductRegistration
@ProductSetUp
@SupplierReports
@CreateProducts
@ViewUpcs
@Solutions
@run_UPCTransporationRules

Feature: UPCTransporationRules

@ScenarioId:6425
Scenario: Mode 7 - Scenario 4 UPC Trasnportation

	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bleach
	And I call Shared Step 74339 (Product Characteristics - Select Liquid and enter only Secondary state, Specific gravity, pH)
	And I set the Boiling Point (in Celsius) field to: 1
	And I set the Flash Point (in Celsius) field to: 1
	And The following options should be displayed exclusively for section: Flash Point Testing Method Used
	| Option            |
	| Closed cup method |
	And I set the Flash Point Testing Method Used field to: Closed cup method
	And I set the Select the best Water Solubility description field to: Insoluble
	And I click continue
	Given I call Shared Step 74340 (Additional Product Information - Pesticide= Not considered, SOLD=US, everything else = No - Continue)
	And I call Shared Step 29181 (Ingredients - add any chemical) with name: 2-Methyl-1-butene
	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	And I should see the Transportation Details 1 Page
	And The following options should be displayed exclusively for section: Product is Regulated for Transport
	| Option                               |
	| Yes                                  |
	| No, due to an exemption or exception |
	And I set the Product is Regulated for Transport field to: Yes
	And I set the Select all modes of transport that you've classified the product for field to: IMDG
	And I select option: Shipping with limited quantity under section: Select all modes of transport that you've classified the product for and subsection: IMDG
	And I click continue
	And I set the UN Number field to: UN2459
	And I click continue
	Given I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue) for
		| Retailer  |
		| Walgreens |
	Given I click the 'Add UPC' button
	Then I generate a random UPC number and save as: RandomUPC91076
	Given I add the following into the UPC Fields
		| UPC Number              | Container Type    | Size | DPCI | Quantity |
		| saved as RandomUPC91076 | Plastic Container | 55   |      |          |
	Given I Check that in the UPC screen, under the Transportation Column to option IMDG is checked
	Then I Check that in the UPC screen, under the Transportation Column to option Shipping with limited quantity is checked
	Given I click continue
	Then I should see a list style form error with text: UPC failing Transportation Rules. Review your Transport overrides.	
	#Then I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCaseXXXXX

@ScenarioId:6424
	Scenario: Mode 7 - Scenario 23 UPC Transportation
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Lead Acid (Non-Spillable) Battery
	Then I save the product information as: TestCase97484
	Given I call Shared Step 59927 (Primary Physical State > Solid only available – Without Water Solubility question)
	Given I should see the Additional Product Information Page
	Given I call Shared Step 102767 (Additional Product Information (Battery flow - not Lithium) - OSHA (No), DSV (No), PLP (No), GNFR (No))
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Water         | 100     | false               | false       |            |		
	Given I call Shared Step 57637 (Regulatory Information 1 - TSCA & CEPA shown, No to PROP 65 - Continue - Happy Path)
	And I should see the Transportation Details 1 Page	
	And I set the Product is Regulated for Transport field to: Yes
	And I set the Select all modes of transport that you've classified the product for field to: IMDG
	And I select option: Shipping with limited quantity under section: Select all modes of transport that you've classified the product for and subsection: IMDG
	And I click continue
	And I set the UN Number field to: UN2650
	And I click continue	
	Given I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue) for
		| Retailer  |
		| Walgreens |
	Given I click the 'Add UPC' button
	Then I generate a random UPC number and save as: RandomUPC91076
	Given I add the following into the UPC Fields
		| UPC Number              | Container Type    | Size | DPCI | Quantity |
		| saved as RandomUPC91076 | Plastic Container | 55   |      | 1        |
	Given I Check that in the UPC screen, under the Transportation Column to option IMDG is checked
	Then I Check that in the UPC screen, under the Transportation Column to option Shipping with limited quantity is checked
	Given I click continue
	Then I should see a list style form error with text: UPC failing Transportation Rules. Review your Transport overrides.	
	#Then I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCaseXXXXX
	

@ScenarioId:6422
	Scenario: Mode 6 - Scenario 3 UPC Transportation

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
	#Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	#Given I call Shared Step 65705 (Transportation - DOT UN step - Enter UN1950, select Aerosols,  2.1, None, add technical name, Click Continue)
	And I should see the Transportation Details 1 Page	
	And I set the Product is Regulated for Transport field to: Yes
	And I set the Select all modes of transport that you've classified the product for field to: DOT
	And I select option: Shipping with limited quantity under section: Select all modes of transport that you've classified the product for and subsection: DOT
	And I set the Provide Special Permit numbers (if applicable) field to: 14188 	
	And I click continue
	And I set the UN Number field to: UN3159 
	And I click continue
	Given I call Shared Step 62710 (Confirm VOC OTC/CARB heading and select No to FIRST QUESTION ONLY - Happy Path)
	Given I call Shared Step 60468 (VOC - CARB only required - enter value - Continue - Happy Path)
	Given I click continue
	Given I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue) for
		| Retailer  |
		| Walgreens |
	Given I click the 'Add UPC' button
	Then I generate a random UPC number and save as: RandomUPC91076
	Given I add the following into the UPC Fields
		| UPC Number              | Container Type | Size | DPCI | Quantity |
		| saved as RandomUPC91076 | Aerosol Can    | 55   |      |          |
	Given I Check that in the UPC screen, under the Transportation Column to option DOT is checked
	Then I Check that in the UPC screen, under the Transportation Column to option Shipping with limited quantity is checked
	Given I click continue
	Then I should see a list style form error with text: UPC failing Transportation Rules. Review your Transport overrides.	
	#Then I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCaseXXXXX

@ScenarioId:6421
	Scenario: Mode 6 - Scenario 28 UPC Trasnportation

	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bleach
	And I call Shared Step 74339 (Product Characteristics - Select Liquid and enter only Secondary state, Specific gravity, pH)
	And I set the Boiling Point (in Celsius) field to: 1
	And I set the Flash Point (in Celsius) field to: 65
	And I set the Flash Point Testing Method Used field to: Closed cup method
	And I set the Select the best Water Solubility description field to: Insoluble
	And I click continue
	#And I call Shared Step 118085 (Additional Product Information - Pesticide= Not considered, SOLD=US, everything else = No California Cleaning = No - Continue)
	Given I call Shared Step 74340 (Additional Product Information - Pesticide= Not considered, SOLD=US, everything else = No - Continue)
	And I call Shared Step 29181 (Ingredients - add any chemical) with name: water
	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	And I should see the Transportation Details 1 Page
	And I set the Product is Regulated for Transport field to: Yes
	And I set the Select all modes of transport that you've classified the product for field to: DOT
	And I select option: Shipping with limited quantity under section: Select all modes of transport that you've classified the product for and subsection: DOT
	And I click continue
	And I set the UN Number field to: UN2258
	And I click continue
	Given I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue) for
		| Retailer  |
		| Walgreens |
	Given I click the 'Add UPC' button
	Then I generate a random UPC number and save as: RandomUPC91076
	Given I add the following into the UPC Fields
		| UPC Number              | Container Type    | Size | DPCI | Quantity |
		| saved as RandomUPC91076 | Plastic Container | 55   |      |          |
	Given I Check that in the UPC screen, under the Transportation Column to option DOT is checked
	Then I Check that in the UPC screen, under the Transportation Column to option Shipping with limited quantity is checked
	Given I click continue
	Then I should see a list style form error with text: UPC failing Transportation Rules. Review your Transport overrides.	
	#Then I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCaseXXXXX

@ScenarioId:6420
	Scenario: Mode 6 - Scenario 15 UPC Transportation
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Lead Acid (Non-Spillable) Battery
	Then I save the product information as: TestCase97484
	Given I call Shared Step 59927 (Primary Physical State > Solid only available – Without Water Solubility question)
	Given I should see the Additional Product Information Page
	Given I call Shared Step 102767 (Additional Product Information (Battery flow - not Lithium) - OSHA (No), DSV (No), PLP (No), GNFR (No))
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName       | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Ammonium dichromate | 100     | false               | false       |            |		
	Given I call Shared Step 57637 (Regulatory Information 1 - TSCA & CEPA shown, No to PROP 65 - Continue - Happy Path)
	And I should see the Transportation Details 1 Page	
	And I set the Product is Regulated for Transport field to: Yes
	And I set the Select all modes of transport that you've classified the product for field to: DOT
	And I select option: Shipping with limited quantity under section: Select all modes of transport that you've classified the product for and subsection: DOT
	And I click continue
	And I set the UN Number field to: UN1439
	And I click continue	
	Given I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue) for
		| Retailer  |
		| Walgreens |
	Given I click the 'Add UPC' button
	Then I generate a random UPC number and save as: RandomUPC91076
	Given I add the following into the UPC Fields
		| UPC Number              | Container Type    | Size | DPCI | Quantity |
		| saved as RandomUPC91076 | Plastic Container | 55   |      | 1        |
	Given I Check that in the UPC screen, under the Transportation Column to option DOT is checked
	Then I Check that in the UPC screen, under the Transportation Column to option Shipping with limited quantity is checked
	Given I click continue
	Then I should see a list style form error with text: UPC failing Transportation Rules. Review your Transport overrides.	
	#Then I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCaseXXXXX


@ScenarioId:6419
	Scenario: Mode 4x5 - Scenario 4 UPC Transportation

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
	#Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	#Given I call Shared Step 65705 (Transportation - DOT UN step - Enter UN1950, select Aerosols,  2.1, None, add technical name, Click Continue)
	And I should see the Transportation Details 1 Page	
	And I set the Product is Regulated for Transport field to: Yes
	And I set the Select all modes of transport that you've classified the product for field to: IATA
	And I select option: Shipping with consumer commodity under section: Select all modes of transport that you've classified the product for and subsection: IATA
	And I click continue
	And I set the UN Number field to: UN1950
	And I set the Proper Shipping Name field to: Aerosols, flammable
	And I set the Hazard Class (select) field to: 2.1	
	And I click continue
	Given I call Shared Step 62710 (Confirm VOC OTC/CARB heading and select No to FIRST QUESTION ONLY - Happy Path)
	Given I call Shared Step 60468 (VOC - CARB only required - enter value - Continue - Happy Path)
	Given I click continue
	Given I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue) for
		| Retailer  |
		| Walgreens |
	Given I click the 'Add UPC' button
	Then I generate a random UPC number and save as: RandomUPC91076
	Given I add the following into the UPC Fields
		| UPC Number              | Container Type | Size | DPCI | Quantity |
		| saved as RandomUPC91076 | Aerosol Can    | 55   |      |          |
	Given I Check that in the UPC screen, under the Transportation Column to option IATA is checked
	Then I Check that in the UPC screen, under the Transportation Column to option Shipping with consumer commodity is checked
	Given I click continue
	Then I should see a list style form error with text: UPC failing Transportation Rules. Review your Transport overrides.	
	#Then I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCaseXXXXX

@ScenarioId:6415
	Scenario: Mode 4x5 - Scenario 15 UPC Trasnportation

	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bleach
	And I call Shared Step 74339 (Product Characteristics - Select Liquid and enter only Secondary state, Specific gravity, pH)
	And I set the Boiling Point (in Celsius) field to: 1
	And I set the Flash Point (in Celsius) field to: 65	
	And I set the Flash Point Testing Method Used field to: Closed cup method
	And I set the Select the best Water Solubility description field to: Insoluble
	And I click continue
	Given I call Shared Step 74340 (Additional Product Information - Pesticide= Not considered, SOLD=US, everything else = No - Continue)
	And I call Shared Step 29181 (Ingredients - add any chemical) with name: water
	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	And I should see the Transportation Details 1 Page
	And I set the Product is Regulated for Transport field to: Yes
	And I set the Select all modes of transport that you've classified the product for field to: IATA
	And I select option: Shipping with consumer commodity under section: Select all modes of transport that you've classified the product for and subsection: IATA
	And I click continue
	And I set the UN Number field to: UN3175
	And I click continue
	Given I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue) for
		| Retailer  |
		| Walgreens |
	Given I click the 'Add UPC' button
	Then I generate a random UPC number and save as: RandomUPC91076
	Given I add the following into the UPC Fields
		| UPC Number              | Container Type    | Size | DPCI | Quantity |
		| saved as RandomUPC91076 | Plastic Container | 55   |      |          |
	Given I Check that in the UPC screen, under the Transportation Column to option IATA is checked
	Then I Check that in the UPC screen, under the Transportation Column to option Shipping with consumer commodity is checked
	Given I click continue
	Then I should see a list style form error with text: UPC failing Transportation Rules. Review your Transport overrides.	
	#Then I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCaseXXXXX


@ScenarioId:6416
	Scenario: Mode 4x5 - Scenario 20 UPC Trasnportation

	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bleach
	And I call Shared Step 74339 (Product Characteristics - Select Liquid and enter only Secondary state, Specific gravity, pH)
	And I set the Boiling Point (in Celsius) field to: 1
	And I set the Flash Point (in Celsius) field to: 65	
	And I set the Flash Point Testing Method Used field to: Closed cup method
	And I set the Select the best Water Solubility description field to: Insoluble
	And I click continue
	Given I call Shared Step 74340 (Additional Product Information - Pesticide= Not considered, SOLD=US, everything else = No - Continue)
	And I call Shared Step 29181 (Ingredients - add any chemical) with name: water
	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	And I should see the Transportation Details 1 Page
	And I set the Product is Regulated for Transport field to: Yes
	And I set the Select all modes of transport that you've classified the product for field to: IATA
	And I select option: Shipping with limited quantity under section: Select all modes of transport that you've classified the product for and subsection: IATA
	And I click continue
	And I set the UN Number field to: UN2307
	And I click continue
	Given I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue) for
		| Retailer  |
		| Walgreens |
	Given I click the 'Add UPC' button
	Then I generate a random UPC number and save as: RandomUPC91076
	Given I add the following into the UPC Fields
		| UPC Number              | Container Type    | Size | DPCI | Quantity |
		| saved as RandomUPC91076 | Plastic Container | 55   |      |          |
	Given I Check that in the UPC screen, under the Transportation Column to option IATA is checked
	Then I Check that in the UPC screen, under the Transportation Column to option Shipping with limited quantity is checked
	Given I click continue
	Then I should see a list style form error with text: UPC failing Transportation Rules. Review your Transport overrides.	
	#Then I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCaseXXXXX


@ScenarioId:6417
	Scenario: Mode 4x5 - Scenario 25 UPC Transportation
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Lead Acid (Non-Spillable) Battery
	Then I save the product information as: TestCase97484
	Given I call Shared Step 59927 (Primary Physical State > Solid only available – Without Water Solubility question)
	Given I should see the Additional Product Information Page
	Given I call Shared Step 102767 (Additional Product Information (Battery flow - not Lithium) - OSHA (No), DSV (No), PLP (No), GNFR (No))
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| water  | 100     | false               | false       |            |		
	Given I call Shared Step 57637 (Regulatory Information 1 - TSCA & CEPA shown, No to PROP 65 - Continue - Happy Path)
	And I should see the Transportation Details 1 Page	
	And I set the Product is Regulated for Transport field to: Yes
	And I set the Select all modes of transport that you've classified the product for field to: IATA
	And I select option: Shipping with consumer commodity under section: Select all modes of transport that you've classified the product for and subsection: IATA
	And I click continue
	And I set the UN Number field to: UN1579
	And I click continue	
	Given I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue) for
		| Retailer  |
		| Walgreens |
	Given I click the 'Add UPC' button
	Then I generate a random UPC number and save as: RandomUPC91076
	Given I add the following into the UPC Fields
		| UPC Number              | Container Type    | Size | DPCI | Quantity |
		| saved as RandomUPC91076 | Plastic Container | 55   |      | 1        |
	Given I Check that in the UPC screen, under the Transportation Column to option IATA is checked
	Then I Check that in the UPC screen, under the Transportation Column to option Shipping with consumer commodity is checked
	Given I click continue
	Then I should see a list style form error with text: UPC failing Transportation Rules. Review your Transport overrides.	
	#Then I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCaseXXXXX

	
@ScenarioId:6418
	Scenario: Mode 4x5 - Scenario 35 UPC Transportation
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Lead Acid (Non-Spillable) Battery
	Then I save the product information as: TestCase97484
	Given I call Shared Step 59927 (Primary Physical State > Solid only available – Without Water Solubility question)
	Given I should see the Additional Product Information Page
	Given I call Shared Step 102767 (Additional Product Information (Battery flow - not Lithium) - OSHA (No), DSV (No), PLP (No), GNFR (No))
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Benzaldehyde  | 100     | false               | false       |            |		
	Given I call Shared Step 57637 (Regulatory Information 1 - TSCA & CEPA shown, No to PROP 65 - Continue - Happy Path)
	And I should see the Transportation Details 1 Page	
	And I set the Product is Regulated for Transport field to: Yes
	And I set the Select all modes of transport that you've classified the product for field to: IATA
	And I select option: Shipping with consumer commodity under section: Select all modes of transport that you've classified the product for and subsection: IATA
	And I click continue
	And I set the UN Number field to: UN1990
	And I click continue	
	Given I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue) for
		| Retailer  |
		| Walgreens |
	Given I click the 'Add UPC' button
	Then I generate a random UPC number and save as: RandomUPC91076
	Given I add the following into the UPC Fields
		| UPC Number              | Container Type    | Size | DPCI | Quantity |
		| saved as RandomUPC91076 | Plastic Container | 55   |      | 1        |
	Given I Check that in the UPC screen, under the Transportation Column to option IATA is checked
	Then I Check that in the UPC screen, under the Transportation Column to option Shipping with consumer commodity is checked
	Given I click continue
	Then I should see a list style form error with text: UPC failing Transportation Rules. Review your Transport overrides.	
	#Then I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCaseXXXXX






