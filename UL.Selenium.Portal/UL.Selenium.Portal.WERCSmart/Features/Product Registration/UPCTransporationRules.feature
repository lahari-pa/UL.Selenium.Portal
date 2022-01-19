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
Scenario: [122304] UPC Transportation Error - Mode 7 - Scenario 4

	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bleach
	Then I save the product information as: Mode7S4
	And I call Shared Step 74340 (Product Information - Pesticide= Not considered, SOLD=US, everything else = No - Continue)
	And I call Shared Step 74339 (Physical and Chemical Properties - Select Liquid and enter only Secondary state, Relative Density, pH)
	And I set the Boiling Point (in Celsius) field to: 1
	And I set the Flash Point (in Celsius) field to: 1
	And The following options should be displayed exclusively for section: Flash Point Testing Method Used
	| Option            |
	| Closed cup method |
	And I set the Flash Point Testing Method Used field to: Closed cup method
	And I set the Select the best Water Solubility description field to: Insoluble
	And I click continue
	And I call Shared Step 29181 (Ingredients - add any chemical) with name: water
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
	Given I click the 'Add' button
	Then I generate a random UPC number and save as: RandomUPC91076
	Given I add the following into the UPC Fields
		| UPC Number              | Container Type    | Size | DPCI | Quantity |
		| saved as RandomUPC91076 | Plastic Container | 55   |      |          |
	Then I Check that in the UPC screen, under the Transportation Column the Catagory IMDG is checked
	Then I Check that in the UPC screen, under the Transportation Column for Catagory IMDG the option Shipping with limited quantity is checked	
	Given I click continue
	Then I should see a list style form error with text: UPC failing Transportation Rules. Review your Transport overrides.	
	Then I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: Mode7S4

@ScenarioId:6424
	Scenario: [122303] UPC Transportation Error - Mode 7 - Scenario 23 	

	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
		And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
		And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Fertilizer 
		Then I save the product information as: Mode1S21
		Then I call Shared Step 143418 (Product Information - Pesticide= Not considered, Fertilizer=NO, SOLD=US, everything else = No - Continue)
		And I call Shared Step 57501 (Physical and Chemical Properties - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue - HP)


		And I call Shared Step 29181 (Ingredients - add any chemical) with name: Dimethoxyethane
		And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)

		#Transportation Details Page
		And I should see the Transportation Details 1 Page
		And The following options should be displayed exclusively for section: Product is Regulated for Transport
		| Option                               |
		| Yes                                  |
		| No, due to an exemption or exception |
		| Not Regulated                        |
		And I set the Product is Regulated for Transport field to: Yes
		And I set the below options for field: Select all modes of transport that you've classified the product for
		| Option                           |
		| IMDG                             |
		| Shipping with limited quantity |
		And I click continue

		Then I should see the International Marine (IMDG) Classification Page
		And I set the UN Number field to: UN2650	
		And I set the Hazard Class (select) field to: 6.1
		And I set the Packing Group (select) field to: II
		Given in the New Product page I click Continue

		# Retailers Page
		Then In the 'Select Retailers' window I select the retailer: Walgreens
		And I should see the Retailer Page
		Given in the New Product page I click Continue

		# Universal Product Code (UPC) Page
		And I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page
		Then I generate a random UPC number and save as: UPC10021
		Given I click the 'Add' button

		#Andrews step to check transportation column is generated correctly

		Then I add the following into the UPC Fields
		| Field         | Value             |
		| UPCNumber     | saved as UPC10021 |
		| ContainerType | Glass Container   |
		| Size          | 55                 |
		Then I Check that in the UPC screen, under the Transportation Column the Catagory IMDG is checked
		Then I Check that in the UPC screen, under the Transportation Column for Catagory IMDG the option Shipping with limited quantity is checked	
		And in the New Product page I click Continue
		Then I should see a list style form error with text: UPC failing Transportation Rules. Review your Transport overrides.
		Then I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: Mode1S21






	

@ScenarioId:6422
	Scenario: [122302] UPC Transportation Error - Mode 6 - Scenario 3

	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC60116
	Given I delete all products with UPC Number: saved as UPC60116
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Anti-Static Product - Aerosol
	Then I save the product information as: Mode6S3
	Then I save the product information as: TestCase60116
	Given I call Shared Step 60310 (Product Information - Without Child question)
	Given I call Shared Step 57111 (Enter Product Data for Physical State - Aerosol only)
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
	Given I click the 'Add' button
	Then I generate a random UPC number and save as: RandomUPC91076
	Given I add the following into the UPC Fields
		| UPC Number              | Container Type | Size | DPCI | Quantity |
		| saved as RandomUPC91076 | Aerosol Can    | 55   |      |          |	
	Then I Check that in the UPC screen, under the Transportation Column the Catagory DOT is checked
	Then I Check that in the UPC screen, under the Transportation Column for Catagory DOT the option Shipping with limited quantity is checked	
	Given I click continue
	Then I should see a list style form error with text: UPC failing Transportation Rules. Review your Transport overrides.	
	Then I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: Mode6S3

@ScenarioId:6421
	Scenario:	[122301] UPC Transportation Error - Mode 6 - Scenario 28

	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bleach
	Then I save the product information as: Mode6S28
	And I call Shared Step 74340 (Product Information - Pesticide= Not considered, SOLD=US, everything else = No - Continue)
	And I call Shared Step 74339 (Physical and Chemical Properties - Select Liquid and enter only Secondary state, Relative Density, pH)
	And I set the Boiling Point (in Celsius) field to: 1
	And I set the Flash Point (in Celsius) field to: 65
	And I set the Flash Point Testing Method Used field to: Closed cup method
	And I set the Select the best Water Solubility description field to: Insoluble
	And I click continue
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
	Given I click the 'Add' button
	Then I generate a random UPC number and save as: RandomUPC91076
	Given I add the following into the UPC Fields
		| UPC Number              | Container Type    | Size | DPCI | Quantity |
		| saved as RandomUPC91076 | Plastic Container | 55   |      |          |
	Then I Check that in the UPC screen, under the Transportation Column the Catagory DOT is checked
	Then I Check that in the UPC screen, under the Transportation Column for Catagory DOT the option Shipping with limited quantity is checked	
	Given I click continue
	Then I should see a list style form error with text: UPC failing Transportation Rules. Review your Transport overrides.	
	Then I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: Mode6S28

@ScenarioId:6420
	Scenario: [122300] UPC Transportation Error - Mode 6 - Scenario 15	

	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
		And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
		And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Fertilizer 
		Then I save the product information as: Mode1S21
		Then I call Shared Step 143418 (Product Information - Pesticide= Not considered, Fertilizer=NO, SOLD=US, everything else = No - Continue)
		And I call Shared Step 57501 (Physical and Chemical Properties - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue - HP)
		And I call Shared Step 29181 (Ingredients - add any chemical) with name: Dimethoxyethane
		And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)

		#Transportation Details Page
		And I should see the Transportation Details 1 Page
		And The following options should be displayed exclusively for section: Product is Regulated for Transport
		| Option                               |
		| Yes                                  |
		| No, due to an exemption or exception |
		| Not Regulated                        |
		And I set the Product is Regulated for Transport field to: Yes
		And I set the below options for field: Select all modes of transport that you've classified the product for
		| Option                         |
		| DOT                            |
		| Shipping with limited quantity |
		And I click continue

		Then I should see the U. S. Department of Transportation (DOT) Classification Page
		And I set the UN Number field to: UN1439
		
		And I set the Hazard Class (select) field to: 5.1
		And I set the Packing Group (select) field to: II
		Given in the New Product page I click Continue

		# Retailers Page
		Then In the 'Select Retailers' window I select the retailer: Walgreens
		And I should see the Retailer Page
		Given in the New Product page I click Continue

		# Universal Product Code (UPC) Page
		And I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page
		Then I generate a random UPC number and save as: UPC10021
		Given I click the 'Add' button

		#Andrews step to check transportation column is generated correctly

		Then I add the following into the UPC Fields
		| Field         | Value             |
		| UPCNumber     | saved as UPC10021 |
		| ContainerType | Glass Container   |
		| Size          | 55                 |
		Then I Check that in the UPC screen, under the Transportation Column the Catagory DOT is checked
		Then I Check that in the UPC screen, under the Transportation Column for Catagory DOT the option Shipping with limited quantity is checked	
		And in the New Product page I click Continue
		Then I should see a list style form error with text: UPC failing Transportation Rules. Review your Transport overrides.
		Then I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: Mode1S21





@ScenarioId:6419
	Scenario: [122299] UPC Transportation Error - Mode 4x5 - Scenario 4

	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC60116
	Given I delete all products with UPC Number: saved as UPC60116
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Anti-Static Product - Aerosol
	Then I save the product information as: Mode45S4	
	Given I call Shared Step 60310 (Product Information - Without Child question)
	Given I call Shared Step 57111 (Enter Product Data for Physical State - Aerosol only)
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
	Given I click the 'Add' button
	Then I generate a random UPC number and save as: RandomUPC91076
	Given I add the following into the UPC Fields
		| UPC Number              | Container Type | Size | DPCI | Quantity |
		| saved as RandomUPC91076 | Aerosol Can    | 55   |      |          |
	Then I Check that in the UPC screen, under the Transportation Column the Catagory IATA is checked
	Then I Check that in the UPC screen, under the Transportation Column for Catagory IATA the option Shipping with consumer commodity is checked	
	Given I click continue
	Then I should see a list style form error with text: UPC failing Transportation Rules. Review your Transport overrides.	
	Then I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: Mode45S4

@ScenarioId:6415
	Scenario: [122295] UPC Transportation Error - Mode 4x5 - Scenario 15

	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bleach
	Then I save the product information as: Mode45S15
	And I call Shared Step 74340 (Product Information - Pesticide= Not considered, SOLD=US, everything else = No - Continue)
	And I call Shared Step 74339 (Physical and Chemical Properties - Select Liquid and enter only Secondary state, Relative Density, pH)
	And I set the Boiling Point (in Celsius) field to: 1
	And I set the Flash Point (in Celsius) field to: 65	
	And I set the Flash Point Testing Method Used field to: Closed cup method
	And I set the Select the best Water Solubility description field to: Insoluble
	And I click continue
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
	Given I click the 'Add' button
	Then I generate a random UPC number and save as: RandomUPC91076
	Given I add the following into the UPC Fields
		| UPC Number              | Container Type    | Size | DPCI | Quantity |
		| saved as RandomUPC91076 | Plastic Container | 55   |      |          |
	Then I Check that in the UPC screen, under the Transportation Column the Catagory IATA is checked
	Then I Check that in the UPC screen, under the Transportation Column for Catagory IATA the option Shipping with consumer commodity is checked	
	Given I click continue
	Then I should see a list style form error with text: UPC failing Transportation Rules. Review your Transport overrides.	
	Then I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: Mode45S15


@ScenarioId:6416
	Scenario: [122296] UPC Transportation Error - Mode 4x5 - Scenario 20

	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bleach
	Then I save the product information as: Mode45S20
	And I call Shared Step 74340 (Product Information - Pesticide= Not considered, SOLD=US, everything else = No - Continue)
	And I call Shared Step 74339 (Physical and Chemical Properties - Select Liquid and enter only Secondary state, Relative Density, pH)
	And I set the Boiling Point (in Celsius) field to: 1
	And I set the Flash Point (in Celsius) field to: 65	
	And I set the Flash Point Testing Method Used field to: Closed cup method
	And I set the Select the best Water Solubility description field to: Insoluble
	And I click continue
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
	Given I click the 'Add' button
	Then I generate a random UPC number and save as: RandomUPC91076
	Given I add the following into the UPC Fields
		| UPC Number              | Container Type    | Size | DPCI | Quantity |
		| saved as RandomUPC91076 | Plastic Container | 55   |      |          |
	Then I Check that in the UPC screen, under the Transportation Column the Catagory IATA is checked
	Then I Check that in the UPC screen, under the Transportation Column for Catagory IATA the option Shipping with limited quantity is checked	
	Given I click continue
	Then I should see a list style form error with text: UPC failing Transportation Rules. Review your Transport overrides.	
	Then I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: Mode45S20


@ScenarioId:6417
	Scenario: [122297] UPC Transportation Error - Mode 4x5 - Scenario 25 
	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
		And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
		And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Fertilizer 
		Then I save the product information as: Mode1S21
			Then I call Shared Step 143418 (Product Information - Pesticide= Not considered, Fertilizer=NO, SOLD=US, everything else = No - Continue)
	And I call Shared Step 57501 (Physical and Chemical Properties - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue - HP)


		And I call Shared Step 29181 (Ingredients - add any chemical) with name: Dimethoxyethane
		And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)

		#Transportation Details Page
		And I should see the Transportation Details 1 Page
		And The following options should be displayed exclusively for section: Product is Regulated for Transport
		| Option                               |
		| Yes                                  |
		| No, due to an exemption or exception |
		| Not Regulated                        |
		And I set the Product is Regulated for Transport field to: Yes
		And I set the below options for field: Select all modes of transport that you've classified the product for
		| Option                           |
		| IATA                             |
		| Shipping with consumer commodity |
		And I click continue

		Then I should see the International Air Transport (IATA) Classification Page
		And I set the UN Number field to: UN2716	
		And I set the Hazard Class (select) field to: 6.1
		And I set the Packing Group (select) field to: III
		Given in the New Product page I click Continue

		# Retailers Page
		Then In the 'Select Retailers' window I select the retailer: Walgreens
		And I should see the Retailer Page
		Given in the New Product page I click Continue

		# Universal Product Code (UPC) Page
		And I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page
		Then I generate a random UPC number and save as: UPC10021
		Given I click the 'Add' button

		#Andrews step to check transportation column is generated correctly

		Then I add the following into the UPC Fields
		| Field         | Value             |
		| UPCNumber     | saved as UPC10021 |
		| ContainerType | Glass Container   |
		| Size          | 55                 |
		Then I Check that in the UPC screen, under the Transportation Column the Catagory IATA is checked
		Then I Check that in the UPC screen, under the Transportation Column for Catagory IATA the option Shipping with consumer commodity is checked	
		And in the New Product page I click Continue
		Then I should see a list style form error with text: UPC failing Transportation Rules. Review your Transport overrides.
		Then I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: Mode1S21














	
@ScenarioId:6418
	Scenario: [122298] UPC Transportation Error - Mode 4x5 - Scenario 35 
		Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
		And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
		And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Fertilizer 
		Then I save the product information as: Mode1S21
		Then I call Shared Step 143418 (Product Information - Pesticide= Not considered, Fertilizer=NO, SOLD=US, everything else = No - Continue)
		And I call Shared Step 57501 (Physical and Chemical Properties - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue - HP)


		And I call Shared Step 29181 (Ingredients - add any chemical) with name: Dimethoxyethane
		And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)

		#Transportation Details Page
		And I should see the Transportation Details 1 Page
		And The following options should be displayed exclusively for section: Product is Regulated for Transport
		| Option                               |
		| Yes                                  |
		| No, due to an exemption or exception |
		| Not Regulated                        |
		And I set the Product is Regulated for Transport field to: Yes
		And I set the below options for field: Select all modes of transport that you've classified the product for
		| Option                           |
		| IATA                             |
		| Shipping with consumer commodity |
		And I click continue

		Then I should see the International Air Transport (IATA) Classification Page
		And I set the UN Number field to: UN1990	
		And I set the Hazard Class (select) field to: 9		
		Given in the New Product page I click Continue

		# Retailers Page
		Then In the 'Select Retailers' window I select the retailer: Walgreens
		And I should see the Retailer Page
		Given in the New Product page I click Continue

		# Universal Product Code (UPC) Page
		And I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page
		Then I generate a random UPC number and save as: UPC10021
		Given I click the 'Add' button

		#Andrews step to check transportation column is generated correctly

		Then I add the following into the UPC Fields
		| Field         | Value             |
		| UPCNumber     | saved as UPC10021 |
		| ContainerType | Glass Container   |
		| Size          | 55                 |
		Then I Check that in the UPC screen, under the Transportation Column the Catagory IATA is checked
		Then I Check that in the UPC screen, under the Transportation Column for Catagory IATA the option Shipping with consumer commodity is checked	
		And in the New Product page I click Continue
		Then I should see a list style form error with text: UPC failing Transportation Rules. Review your Transport overrides.
		Then I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: Mode1S21










@ScenarioId:10800
	Scenario:[122288] UPC Transportation Error - Mode 1 - 6
		# If DOT Hazard Class is 3 and Packing group is I and UPC > 16.907 oz and DOT Consumer Commodity and/or Limited Quantity at the UPC level then populate UPCTERR with “1”
		Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
		And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
		And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bleach
		Then I save the product information as: Mode1S6
		And I call Shared Step 74340 (Product Information - Pesticide= Not considered, SOLD=US, everything else = No - Continue)
		And I call Shared Step 74339 (Physical and Chemical Properties - Select Liquid and enter only Secondary state, Relative Density, pH)
		And I set the Boiling Point (in Celsius) field to: 100
		And I set the Flash Point (in Celsius) field to: 50
		And The following options should be displayed exclusively for section: Flash Point Testing Method Used
		| Option            |
		| Closed cup method |
		And I set the Flash Point Testing Method Used field to: Closed cup method
		And I set the Select the best Water Solubility description field to: Insoluble
		And I click continue
		And I call Shared Step 29181 (Ingredients - add any chemical) with name: 1-Pentene
		And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
		And I should see the Transportation Details 1 Page
		And The following options should be displayed exclusively for section: Product is Regulated for Transport
		| Option                               |
		| Yes                                  |
		| No, due to an exemption or exception |
		And I set the Product is Regulated for Transport field to: Yes
		And I set the below options for field: Select all modes of transport that you've classified the product for
		| Option                           |
		| DOT                              |
		| Shipping with limited quantity   |
		And I click continue

		# U. S. Department of Transportation (DOT) Classification Page
		Then I should see the U. S. Department of Transportation (DOT) Classification Page
		And I set the UN Number field to: UN1108
		And I set the Technical Name (if applicable) field to: My Safe Product
		And I set the Hazard Class (select) field to: 3
		And I set the Packing Group (select) field to: I
		And I set the Product has a boiling point of option to: The UN# classification assigned to this product has a specific Packaging Group required.
		Given in the New Product page I click Continue

		# Retailers Page
		Then In the 'Select Retailers' window I select the retailer: Walgreens
		And I should see the Retailer Page
		Given in the New Product page I click Continue

		# Universal Product Code (UPC) Page
		And I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page
		Then I generate a random UPC number and save as: UPC10006
		Given I click the 'Add' button

		#Andrews step to check transportation column is generated correctly

		Then I add the following into the UPC Fields
		| Field         | Value             |
		| UPCNumber     | saved as UPC10006 |
		| ContainerType | Glass Container   |
		| Size          | 66                |
		Then I Check that in the UPC screen, under the Transportation Column the Catagory DOT is checked
		Then I Check that in the UPC screen, under the Transportation Column for Catagory DOT the option Shipping with limited quantity is checked
		And in the New Product page I click Continue
		Then I should see a list style form error with text: UPC failing Transportation Rules. Review your Transport overrides.	
		Then I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: Mode1S6


@ScenarioId:10883
	Scenario:  [122287] UPC Transportation Error - Mode 1 - 3 
		#If physical state is Aerosol and DOT UN is 3159 and UPC Size is > 33.814 oz and DOT Consumer Commodity and/or Limited Quantity at the UPC level and DOT Special Permit is “14188” or 20464” then populate UPCTERR with “1”
		Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
		And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
		And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Animal deterrent - Aerosol
		Then I save the product information as: Mode1S3
	And I call Shared Step 74340 (Product Information - Pesticide= Not considered, SOLD=US, everything else = No - Continue)
		And I call Shared Step 57111 (Enter Product Data for Physical State - Aerosol only)
		And I call Shared Step 69557 (Enter Ingredients for Aerosol Propellent)

		And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
		And I should see the Transportation Details 1 Page
		And The following options should be displayed exclusively for section: Product is Regulated for Transport
		| Option                               |
		| Yes                                  |
		| No, due to an exemption or exception |
		And I set the Product is Regulated for Transport field to: Yes
		And I set the below options for field: Select all modes of transport that you've classified the product for
		| Option                           |
		| DOT                              |
		| Shipping with limited quantity   |


		#And in the Product Characteristics tab of the New Product Page, I enter: 14188 in the Provide Special Permit numbers text field
		And I set the Provide Special Permit numbers (if applicable) field to: 14188
		# 20464 || 14188 
		And I click continue

		# U. S. Department of Transportation (DOT) Classification Page
		Then I should see the U. S. Department of Transportation (DOT) Classification Page
		And I set the UN Number field to: UN3159
		And I set the Technical Name (if applicable) field to: My Safe Product
		And I set the Hazard Class (select) field to: 2.2
		Given in the New Product page I click Continue

		# Retailers Page
		Then In the 'Select Retailers' window I select the retailer: Walgreens
		And I should see the Retailer Page
		Given in the New Product page I click Continue

		# Universal Product Code (UPC) Page
		And I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page
		Then I generate a random UPC number and save as: UPC10003
		Given I click the 'Add' button

		#Andrews step to check transportation column is generated correctly

		Then I add the following into the UPC Fields
		| Field         | Value             |
		| UPCNumber     | saved as UPC10003 |
		| ContainerType | Aerosol Can       |
		| Size          | 55                |
		Then I Check that in the UPC screen, under the Transportation Column the Catagory DOT is checked
		Then I Check that in the UPC screen, under the Transportation Column for Catagory DOT the option Shipping with limited quantity is checked
		And in the New Product page I click Continue
		Then I should see a list style form error with text: UPC failing Transportation Rules. Review your Transport overrides.	
		Then I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: Mode1S3

@ScenarioId:10292
	Scenario: [122286] UPC Transportation Error - Mode 1 - 21
		#If DOT Hazard Class is 5.2 and physical state is Solid and UPC > 3.381 oz and DOT Consumer Commodity and/or Limited Quantity at the UPC level and Proper Shipping name is Type B or C then populate UPCTERR with “1”
		Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
		And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
		And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Fertilizer 
		Then I save the product information as: Mode1S21
		Then I call Shared Step 143418 (Product Information - Pesticide= Not considered, Fertilizer=NO, SOLD=US, everything else = No - Continue)
		And I call Shared Step 57501 (Physical and Chemical Properties - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue - HP)


		And I call Shared Step 29181 (Ingredients - add any chemical) with name: Dimethoxyethane
		And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)

		#Transportation Details Page
		And I should see the Transportation Details 1 Page
		And The following options should be displayed exclusively for section: Product is Regulated for Transport
		| Option                               |
		| Yes                                  |
		| No, due to an exemption or exception |
		| Not Regulated                        |
		And I set the Product is Regulated for Transport field to: Yes
		And I set the below options for field: Select all modes of transport that you've classified the product for
		| Option                           |
		| DOT                              |
		| Shipping with limited quantity   |
		#| Shipping with consumer commodity |



		And I click continue

		# U. S. Department of Transportation (DOT) Classification Page
		Then I should see the U. S. Department of Transportation (DOT) Classification Page
		And I set the UN Number field to: UN3102
		And I set the Proper Shipping Name field to: Organic peroxide type B, solid
		And I set the Technical Name (if applicable) field to: My Safe Product
		And I set the Hazard Class (select) field to: 5.2
		Given in the New Product page I click Continue

		# Retailers Page
		Then In the 'Select Retailers' window I select the retailer: Walgreens
		And I should see the Retailer Page
		Given in the New Product page I click Continue

		# Universal Product Code (UPC) Page
		And I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page
		Then I generate a random UPC number and save as: UPC10021
		Given I click the 'Add' button

		#Andrews step to check transportation column is generated correctly

		Then I add the following into the UPC Fields
		| Field         | Value             |
		| UPCNumber     | saved as UPC10021 |
		| ContainerType | Glass Container   |
		| Size          | 7                 |
		Then I Check that in the UPC screen, under the Transportation Column the Catagory DOT is checked
		Then I Check that in the UPC screen, under the Transportation Column for Catagory DOT the option Shipping with limited quantity is checked
		#Then I Check that in the UPC screen, under the Transportation Column for Catagory DOT the option Shipping with consumer commodity is checked
		And in the New Product page I click Continue
		Then I should see a list style form error with text: UPC failing Transportation Rules. Review your Transport overrides.
		Then I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: Mode1S21



	Scenario:  [122290] UPC Transportation Error - Mode 2/3 - 2
		#If IATA Hazard Class is 2.1 or 2.2 and IATA UN is 1950 and IATA Subsidiary Hazard is 6.1 and UPC Size > 4.058 oz and DOT is Limited Quantity at the UPC level then populate UPCTERR with “1”
		Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
		And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
		And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Animal deterrent - Aerosol
		Then I save the product information as: Mode23S2
	And I call Shared Step 74340 (Product Information - Pesticide= Not considered, SOLD=US, everything else = No - Continue)
		And I call Shared Step 57111 (Enter Product Data for Physical State - Aerosol only)
		And I call Shared Step 69557 (Enter Ingredients for Aerosol Propellent)

		And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
		And I should see the Transportation Details 1 Page
		And The following options should be displayed exclusively for section: Product is Regulated for Transport
		| Option                               |
		| Yes                                  |
		| No, due to an exemption or exception |
		And I set the Product is Regulated for Transport field to: Yes
		And I set the below options for field: Select all modes of transport that you've classified the product for
		| Option                           |
		| IATA                             |
		| Shipping with limited quantity   |
		| Shipping with consumer commodity |
		| DOT                              |
		| Shipping with limited quantity   |

		And I click continue

		# U. S. Department of Transportation (DOT) Classification Page
		Then I should see the U. S. Department of Transportation (DOT) Classification Page
		And I set the UN Number field to: UN1950
		And I set the Proper Shipping Name field to: Aerosols
		And I set the Technical Name (if applicable) field to: My Safe Product
		And I set the Hazard Class (select) field to: 2.2
		And I set the Packing Group (select) field to: None
		Given in the New Product page I click Continue

		# International Air Transport (IATA) Classification Page
		Then I should see the International Air Transport (IATA) Classification Page
		And I set the UN Number field to: UN1950
		And I set the Proper Shipping Name field to: Aerosols, flammable, containing substances in Division 6.1, Packing Group III
		And I set the Technical Name (if applicable) field to: My Safe Product
		And I set the Hazard Class (select) field to: 2.1
		And I set the Packing Group (select) field to: None
		Given in the New Product page I click Continue

		# Retailers Page
		Then In the 'Select Retailers' window I select the retailer: Walgreens
		And I should see the Retailer Page
		Given in the New Product page I click Continue

		# Universal Product Code (UPC) Page
		And I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page
		Then I generate a random UPC number and save as: UPC20002
		Given I click the 'Add' button

		

		Then I add the following into the UPC Fields
		| Field         | Value             |
		| UPCNumber     | saved as UPC20002 |
		| ContainerType | Aerosol Can       |
		| Size          | 9                 |
		Then I Check that in the UPC screen, under the Transportation Column the Catagory DOT is checked
		Then I Check that in the UPC screen, under the Transportation Column for Catagory DOT the option Shipping with limited quantity is checked
		Then I Check that in the UPC screen, under the Transportation Column the Catagory IATA is checked
		Then I Check that in the UPC screen, under the Transportation Column for Catagory IATA the option Shipping with limited quantity is checked
		Then I Check that in the UPC screen, under the Transportation Column for Catagory IATA the option Shipping with consumer commodity is checked
		
		#Need to update test/step to handle IATA and DOT with options checked.

		And in the New Product page I click Continue
		Then I should see a list style form error with text: UPC failing Transportation Rules. Review your Transport overrides.	
		Then I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: Mode23S2


@ScenarioId:10815
	Scenario:  [122289] UPC Transportation Error - Mode 2/3 - 16
		#If IATA Hazard Class is 5.1 and Packing group is II and physical state is liquid and UPC Size > 3.381 oz and DOT is Limited Quantity at the UPC level then populate UPCTERR with “1”
		Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
		And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
		And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bleach
		Then I save the product information as: Mode23S16
	And I call Shared Step 74340 (Product Information - Pesticide= Not considered, SOLD=US, everything else = No - Continue)
		And I call Shared Step 74339 (Physical and Chemical Properties - Select Liquid and enter only Secondary state, Relative Density, pH)
		And I set the Boiling Point (in Celsius) field to: 200
		And I set the Flash Point (in Celsius) field to: 100
		And The following options should be displayed exclusively for section: Flash Point Testing Method Used
		| Option                   |
		| Closed cup method        |
		| Open cup method          |
		| Not applicable/available |
		And I set the Flash Point Testing Method Used field to: Closed cup method
		And I set the Select the best Water Solubility description field to: Insoluble
		And I click continue
		And I call Shared Step 29181 (Ingredients - add any chemical) with name: water
		And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
		And I should see the Transportation Details 1 Page
		And The following options should be displayed exclusively for section: Product is Regulated for Transport
		| Option                               |
		| Yes                                  |
		| No, due to an exemption or exception |
		| Not Regulated                        |
		And I set the Product is Regulated for Transport field to: Yes
		And I set the below options for field: Select all modes of transport that you've classified the product for
		| Option                           |
		| IATA                             |
		| Shipping with limited quantity   |
		| DOT                              |
		| Shipping with limited quantity   |



		
		And I click continue

		## U. S. Department of Transportation (DOT) Classification Page
		Then I should see the U. S. Department of Transportation (DOT) Classification Page
		And I set the UN Number field to: UN1439
		And I set the Proper Shipping Name field to: Ammonium dichromate
		And I set the Technical Name (if applicable) field to: My Safe Product
		And I set the Hazard Class (select) field to: 5.1
		And I set the Packing Group (select) field to: II
		Given in the New Product page I click Continue

		# International Air Transport (IATA) Classification Page
		Then I should see the International Air Transport (IATA) Classification Page
		And I set the UN Number field to: UN1439
		And I set the Proper Shipping Name field to: Ammonium dichromate
		And I set the Technical Name (if applicable) field to: My Safe Product
		And I set the Hazard Class (select) field to: 5.1
		And I set the Packing Group (select) field to: II
		Given in the New Product page I click Continue

		# Retailers Page
		Then In the 'Select Retailers' window I select the retailer: Walgreens
		And I should see the Retailer Page
		Given in the New Product page I click Continue

		# Universal Product Code (UPC) Page
		And I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page
		Then I generate a random UPC number and save as: UPC20016
		Given I click the 'Add' button

		#Andrews step to check transportation column is generated correctly

		Then I add the following into the UPC Fields
		| Field         | Value             |
		| UPCNumber     | saved as UPC20016 |
		| ContainerType | Glass Container   |
		| Size          | 7                 |

		Then I Check that in the UPC screen, under the Transportation Column the Catagory DOT is checked
		Then I Check that in the UPC screen, under the Transportation Column for Catagory DOT the option Shipping with limited quantity is checked


		Then I Check that in the UPC screen, under the Transportation Column the Catagory IATA is checked
		Then I Check that in the UPC screen, under the Transportation Column for Catagory IATA the option Shipping with limited quantity is checked
		
		And in the New Product page I click Continue
		Then I should see a list style form error with text: UPC failing Transportation Rules. Review your Transport overrides.
		Then I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: Mode23S16

@ScenarioId:10816
	Scenario:  [122291] UPC Transportation Error - Mode 2/3 - 34
		#If IATA Hazard Class is 9 and Packing Group is II or III and physical state is liquid and UPC Size > 16.907 oz and DOT is Consumer Commodity at the UPC level then populate UPCTERR with “1”
		Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
		And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
		And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bleach
		Then I save the product information as: Mode23S34
	And I call Shared Step 74340 (Product Information - Pesticide= Not considered, SOLD=US, everything else = No - Continue)
		And I call Shared Step 74339 (Physical and Chemical Properties - Select Liquid and enter only Secondary state, Relative Density, pH)
		And I set the Boiling Point (in Celsius) field to: 200
		And I set the Flash Point (in Celsius) field to: 100
		And The following options should be displayed exclusively for section: Flash Point Testing Method Used
		| Option                   |
		| Closed cup method        |
		| Open cup method          |
		| Not applicable/available |
		And I set the Flash Point Testing Method Used field to: Closed cup method
		And I set the Select the best Water Solubility description field to: Insoluble
		And I click continue
		And I call Shared Step 29181 (Ingredients - add any chemical) with name: Benzaldehyde
		And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
		And I should see the Transportation Details 1 Page
		And The following options should be displayed exclusively for section: Product is Regulated for Transport
		| Option                               |
		| Yes                                  |
		| No, due to an exemption or exception |
		| Not Regulated                        |
		And I set the Product is Regulated for Transport field to: Yes
		And I set the below options for field: Select all modes of transport that you've classified the product for
		| Option                           |
		| IATA                             |
		| Shipping with consumer commodity |

			
		And I click continue

		## U. S. Department of Transportation (DOT) Classification Page
		Then I should see the U. S. Department of Transportation (DOT) Classification Page
		And I set the UN Number field to: UN1990		
		And I set the Technical Name (if applicable) field to: My Safe Product
		And I set the Hazard Class (select) field to: 9
		And I set the Packing Group (select) field to: III
		Given in the New Product page I click Continue

		# International Air Transport (IATA) Classification Page
		Then I should see the International Air Transport (IATA) Classification Page
		And I set the UN Number field to: UN1990
		And I set the Proper Shipping Name field to: Benzaldehyde
		And I set the Technical Name (if applicable) field to: My Safe Product
		And I set the Hazard Class (select) field to: 9
		And I set the Packing Group (select) field to: III
		Given in the New Product page I click Continue

		# Retailers Page
		Then In the 'Select Retailers' window I select the retailer: Walgreens
		And I should see the Retailer Page
		Given in the New Product page I click Continue
		# Universal Product Code (UPC) Page
		And I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page
		Then I generate a random UPC number and save as: UPC20034
		Given I click the 'Add' button
		Then I add the following into the UPC Fields
		| Field         | Value             |
		| UPCNumber     | saved as UPC20034 |
		| ContainerType | Glass Container   |
		| Size          | 32                |
		And in the New Product page I click Continue
		Then I should see a list style form error with text: UPC failing Transportation Rules. Review your Transport overrides.
		Then I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: Mode23S34


Scenario:  [122294] UPC Transportation Error - Mode 4/5 - 5
		#If IATA Hazard Class is 2.2 and IATA UN is 1950 and UPC Size > 27.728 oz and IATA is Consumer Commodity at the UPC level then populate UPCTERR with “1”
		Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
		And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
		And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Animal deterrent - Aerosol
		Then I save the product information as: Mode45S5
	And I call Shared Step 74340 (Product Information - Pesticide= Not considered, SOLD=US, everything else = No - Continue)
		And I call Shared Step 57111 (Enter Product Data for Physical State - Aerosol only)
		And I call Shared Step 69557 (Enter Ingredients for Aerosol Propellent)

		And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
		And I should see the Transportation Details 1 Page
		And The following options should be displayed exclusively for section: Product is Regulated for Transport
		| Option                               |
		| Yes                                  |
		| No, due to an exemption or exception |
		And I set the Product is Regulated for Transport field to: Yes
		And I set the below options for field: Select all modes of transport that you've classified the product for
		| Option                           |
		| IATA                             |
		| Shipping with consumer commodity |
	
		And I click continue

		# International Air Transport (IATA) Classification Page
		Then I should see the International Air Transport (IATA) Classification Page
		And I set the UN Number field to: UN1950
		And I set the Proper Shipping Name field to: Aerosols, non-flammable
		And I set the Technical Name (if applicable) field to: My Safe Product
		And I set the Hazard Class (select) field to: 2.2
		#And I set the Packing Group (select) field to: None
		#And I set the Product has a boiling point of option to: The UN# classification assigned to this product has a specific Packaging Group required.
		Given in the New Product page I click Continue

		# Retailers Page
		Then In the 'Select Retailers' window I select the retailer: Walgreens
		And I should see the Retailer Page
		Given in the New Product page I click Continue
		# Universal Product Code (UPC) Page
		And I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page
		Then I generate a random UPC number and save as: UPC40005
		Given I click the 'Add' button

		#Andrews step to check transportation column is generated correctly

		Then I add the following into the UPC Fields
		| Field         | Value             |
		| UPCNumber     | saved as UPC40005 |
		| ContainerType | Aerosol Can       |
		| Size          | 55                 |
		
		Then I Check that in the UPC screen, under the Transportation Column the Catagory IATA is checked
		Then I Check that in the UPC screen, under the Transportation Column for Catagory IATA the option Shipping with consumer commodity is checked		
		And in the New Product page I click Continue
		Then I should see a list style form error with text: UPC failing Transportation Rules. Review your Transport overrides.
		Then I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: Mode45S5


Scenario: [122292] UPC Transportation Error - Mode 4/5 - 21
		#If IATA Hazard Class is 6.1 and Packing group is III and physical state is liquid and UPC Size > 16.907 oz and IATA is Limited Quantity at the UPC level then populate UPCTERR with “1”
		Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
		And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
		And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bleach
		Then I save the product information as: Mode45S21
	And I call Shared Step 74340 (Product Information - Pesticide= Not considered, SOLD=US, everything else = No - Continue)
		And I call Shared Step 74339 (Physical and Chemical Properties - Select Liquid and enter only Secondary state, Relative Density, pH)
		And I set the Boiling Point (in Celsius) field to: 200
		And I set the Flash Point (in Celsius) field to: 100
		And The following options should be displayed exclusively for section: Flash Point Testing Method Used
		| Option                   |
		| Closed cup method        |
		| Open cup method          |
		| Not applicable/available |
		And I set the Flash Point Testing Method Used field to: Closed cup method
		And I set the Select the best Water Solubility description field to: Insoluble
		And I click continue
		And I call Shared Step 29181 (Ingredients - add any chemical) with name: Acridine
		And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
		And I should see the Transportation Details 1 Page
		And The following options should be displayed exclusively for section: Product is Regulated for Transport
		| Option                               |
		| Yes                                  |
		| No, due to an exemption or exception |
		| Not Regulated                        |
		And I set the Product is Regulated for Transport field to: Yes
		And I set the below options for field: Select all modes of transport that you've classified the product for
		| Option                           |
		| IATA                             |
		| Shipping with limited quantity   |
		And I click continue

		# International Air Transport (IATA) Classification Page
		Then I should see the International Air Transport (IATA) Classification Page
		And I set the UN Number field to: UN2713		
		And I set the Technical Name (if applicable) field to: My Safe Product
		And I set the Hazard Class (select) field to: 6.1
		And I set the Packing Group (select) field to: III
		Given in the New Product page I click Continue

		# Retailers Page
		Then In the 'Select Retailers' window I select the retailer: Walgreens
		And I should see the Retailer Page
		Given in the New Product page I click Continue
		# Universal Product Code (UPC) Page
		And I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page
		Then I generate a random UPC number and save as: UPC40021
		Given I click the 'Add' button

		#Andrews step to check transportation column is generated correctly

		Then I add the following into the UPC Fields
		| Field         | Value             |
		| UPCNumber     | saved as UPC40021 |
		| ContainerType | Glass Container   |
		| Size          | 32                |
		Then I Check that in the UPC screen, under the Transportation Column the Catagory IATA is checked
		Then I Check that in the UPC screen, under the Transportation Column for Catagory IATA the option Shipping with limited quantity is checked		
		And in the New Product page I click Continue
		Then I should see a list style form error with text: UPC failing Transportation Rules. Review your Transport overrides.
		Then I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: Mode45S21


Scenario: [122293] UPC Transportation Error - Mode 4/5 - 34
		#If IATA Hazard Class is 9 and Packing Group is II or III and physical state is liquid and UPC Size > 16.907 oz and IATA is Consumer Commodity at the UPC level then populate UPCTERR with “1”
		Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
		And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
		And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bleach
		Then I save the product information as: Mode45S34
	And I call Shared Step 74340 (Product Information - Pesticide= Not considered, SOLD=US, everything else = No - Continue)
		And I call Shared Step 74339 (Physical and Chemical Properties - Select Liquid and enter only Secondary state, Relative Density, pH)
		And I set the Boiling Point (in Celsius) field to: 200
		And I set the Flash Point (in Celsius) field to: 100
		And The following options should be displayed exclusively for section: Flash Point Testing Method Used
		| Option                   |
		| Closed cup method        |
		| Open cup method          |
		| Not applicable/available |
		And I set the Flash Point Testing Method Used field to: Closed cup method
		And I set the Select the best Water Solubility description field to: Insoluble
		And I click continue
		And I call Shared Step 29181 (Ingredients - add any chemical) with name: Benzaldehyde
		And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
		And I should see the Transportation Details 1 Page
		And The following options should be displayed exclusively for section: Product is Regulated for Transport
		| Option                               |
		| Yes                                  |
		| No, due to an exemption or exception |
		| Not Regulated                        |
		And I set the Product is Regulated for Transport field to: Yes
		And I set the below options for field: Select all modes of transport that you've classified the product for
		| Option                           |
		| IATA                             |
		| Shipping with consumer commodity |
		And I click continue

		# International Air Transport (IATA) Classification Page
		Then I should see the International Air Transport (IATA) Classification Page
		And I set the UN Number field to: UN1990		
		And I set the Technical Name (if applicable) field to: My Safe Product
		And I set the Hazard Class (select) field to: 9
		And I set the Packing Group (select) field to: III
		Given in the New Product page I click Continue

		# Retailers Page
		Then In the 'Select Retailers' window I select the retailer: Walgreens
		And I should see the Retailer Page
		Given in the New Product page I click Continue
		# Universal Product Code (UPC) Page
		And I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page
		Then I generate a random UPC number and save as: UPC40021
		Given I click the 'Add' button

		#Andrews step to check transportation column is generated correctly

		Then I add the following into the UPC Fields
		| Field         | Value             |
		| UPCNumber     | saved as UPC40021 |
		| ContainerType | Glass Container   |
		| Size          | 32                |
		Then I Check that in the UPC screen, under the Transportation Column the Catagory IATA is checked
		Then I Check that in the UPC screen, under the Transportation Column for Catagory IATA the option Shipping with consumer commodity is checked		
		And in the New Product page I click Continue
		Then I should see a list style form error with text: UPC failing Transportation Rules. Review your Transport overrides.
		Then I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: Mode45S34






