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
@PaymentMethods
@CreateProducts
@SubEnrollment
@WERCSmart_Signup
@MyAccount
@PackagingTypes
@Brands
@MyIngredients
@UPC
@SHA
@ForwardProductRegistration
@ProductSetUp
@ViewUpcs
@run_UPC
Feature: UPC

@ScenarioId:1191
Scenario: [87584] Physical State = Solid, UPC step - Size shows as Size (Weight Ounces)
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk
	Then I save the product information as: TestCase87584
	Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Given I call Shared Step 37857 (Enter Physical Property - Solid)
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Amazon
	Given I click the 'Add Case UPC' button
	Then I should see the following UPC options:
		| Option                            |
		| UPC Number                        |
		| Quantity of Units within the Case |
		| Size (Weight Ounces)              |

	#Philip - Change
	#Then I should not see the following UPC options:
	#	| Option               |
	#	| Size (Weight Ounces) |
	#

	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase87584

@ScenarioId:1192
Scenario: [87587] Physical State = Liquid, UPC step - Size shows as Size (Fluid Ounces)
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Bubble solution
	Then I save the product information as: TestCase87584
		Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)

	Given I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Amazon
	Given I click the 'Add Case UPC' button
	Then I should see the following UPC options:
		| Option                            |
		| UPC Number                        |
		| Quantity of Units within the Case |
		| Size (Fluid Ounces)

	#Philip - Change
	#Then I should not see the following UPC options:
	#	| Option               |
	#	| Size (Weight Ounces) |
	#

	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase87587

@ScenarioId:1193
Scenario: [87588] Physical State = Aerosol, UPC step - Size shows as Size (Fluid Ounces)
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Deodorant - Aerosol
	Then I save the product information as: TestCase87588
	Given I call Shared Step 60310 (Product Information - Without Child question)
	Given I call Shared Step 57528 (Physical and Chemical Properties - Aerosol Only - add data - Continue - Happy Path)
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
	Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)
	Given I call Shared Step 62710 (Confirm VOC OTC/CARB heading and select No to FIRST QUESTION ONLY - Happy Path)
	Given I call Shared Step 60631 (VOC - HVOC and MVOC - add values - Continue - Happy Path)
	Given in the Volatile Organic Compound Summary page I click Continue
	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Amazon
	Given I click the 'Add Case UPC' button
	Then I should see the following UPC options:
		| Option                            |
		| UPC Number                        |
		| Quantity of Units within the Case |
		| Size (Fluid Ounces)               |

		#Philip - Change
	#Then I should not see the following UPC options:
	#	| Option               |
	#	| Size (Weight Ounces) |
	#

	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase87588

@ScenarioId:1194
Scenario: [87593] Physical State = GAS, UPC step - Size shows as Size (Fluid Ounces)
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Compressed gas
	Then I save the product information as: TestCase87593
	Given I call Shared Step 60310 (Product Information - Without Child question)
	Given I call Shared Step 74981 (Physical and Chemical Properties - gas)
		| Secondary Physical State | Select the best Water Solubility description |
		| Compressed gas           | Very slight                                  |
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)
	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Amazon
	Given I click the 'Add Case UPC' button
	Then I should see the following UPC options:
		| Option                            |
		| UPC Number                        |
		| Quantity of Units within the Case |
		| Size (Fluid Ounces)               |

		#Philip - Change
	#Then I should not see the following UPC options:
	#	| Option               |
	#	| Size (Weight Ounces) |
	#

	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase87593

@ScenarioId:1195
Scenario: [87596] Create BCP (Camera with battery) -  UPC step - Size shows as Weight (Ounces)
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Camera w/Battery
	Then I save the product information as: TestCase87596
	Given I call Shared Step 70393 (Product Information - With marketed for use by a Child - Direct Ship - Private Label questions only)
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I call Shared Step 48367 (Product Includes Battery > any type)
		| Battery Type | Manufacturer | Number of batteries per package | How many batteries required to run |
		| Alkaline     | <any>        | 6                               | 6                                  |
	Given I call Shared Step 48369 (Toxicity Characteristics Leaching Procedure (TCLP) - No to ALL With Copper)
	Given I call Shared Step 58189 (Answer Electronic Equipment questions - With Cathode Ray - No to all)
	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Amazon
	Given I click the 'Add Case UPC' button
	Then I should see the following UPC options:
		| Option                            |
		| UPC Number                        |
		| Quantity of Units within the Case |
		| Size (Weight Ounces)              |

		#Philip - Change
	#Then I should not see the following UPC options:
	#	| Option               |
	#	| Size (Fluid Ounces) |
	#

	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase87596

@ScenarioId:1196
Scenario: [87597] Create Electronic - UPC Step - Size shows as Size (Weight Ounces)
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Answering machine, No battery included
	Then I save the product information as: TestCase87597
	Given I call Shared Step 57401 (Product Information - US only - No GHS, Not Direct Ship, Not PLP, Not GNFR > Continue - Happy Path)
	#And I call Shared Step 69687 (Product Information - US, No(PL))
	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	#And I call Shared Step 48369 (Toxicity Characteristics Leaching Procedure (TCLP) - No to ALL With Copper)
	#And I call Shared Step 71955 (Answer Electronic Equipment questions - Without Cathode Ray - No to all)
	#Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Amazon
	#Given I click the 'Add Case UPC' button
	#Then I should see the following UPC options:
	#	| Option                            |
	#	| UPC Number                        |
	#	| Quantity of Units within the Case |
	#	| Size (Weight Ounces)              |

		#Philip - Change
	#Then I should not see the following UPC options:
	#	| Option               |
	#	| Size (Fluid Ounces) |
	#

	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase87597

@ScenarioId:8260
Scenario: [87595] Kit - UPC Page - Size shows as Weight (Ounces)
	# Hardcoded values for Product ID. These do not exist in all environments.
	Given I save to context name: TestCase1 and value: 1525111
	Given I save to context name: TestCase2 and value: 1501057
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I filter the products by: Accepted by Retailers
	Given I save the list of Product IDs displayed on the page as: ProductInProgressList87595
	Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Hair Color Kit
	Then I save the product information as: TestCase87595
	Given I call Shared Step 60648 (Product Information - US, No (Direct Ship), No (PL), No (GNFR))
	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	And I call Shared Step 31427 (Create the Kit - Adding two products: product 1: TestCase1  and product 2: TestCase2)
	Given I call Shared Step 57506 (Transportation Details 1 - Regulated for Transport(No) - Exemption(Random) - Continue - Happy Path)
	Given I call Shared Step 62536 (Transportation Details 2 > I do not ship internationally > Continue - Happy Path)
	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Amazon
	Given I click the 'Add Case UPC' button
	Then I should see the following UPC options:
		| Option                            |
		| UPC Number                        |
		| Quantity of Units within the Case |
		| Size (Weight Ounces)              |

		#Philip - Change
	#Then I should not see the following UPC options:
	#	| Option               |
	#	| Size (Fluid Ounces) |
	#

	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase87595

@ScenarioId:1198
Scenario: [87832] View Shows Case UPC Data
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I generate a random UPC number and save as: UPC87832
	Given I generate a random UPC number and save as: UPC878321
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
	Then I save the product information as: TestCase87832
		Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)

	Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue) for
		| Retailer |
		| Amazon   |
	Given I call Shared Step 87647 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC87832, container type: Paper bag and size: 2 do not click continue
	Given I call Shared Step 87641 (Enter Universal Product Code - case information) for UPC: saved as UPC878321, container type: Paper bag and size: 2 and Quantity: 2 and Associated UPC: UPC87832 and Transportation option: 4A: steel box
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
		| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
	Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: test
	Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given If purchase details are showing click confirm order
	Given I navigate to the home page
	And I filter for the product saved as: TestCase87832
	And I click Row Actions for the first product returned
	And I click on the Row Action: View
	Then I switch to the Data Summary page
	And The Data Summary section Provide the product's UPC(s), including container type and size (ounces) should be showing the following UPC table:
		| UPC Number         | Associated UPC    | Container Type | Size (Ounces) | Quantity | Transport     | Retailers |
		| saved as UPC878321 | saved as UPC87832 | Paper bag      | 2             | 2        | 4A: steel box | AM        |
		| saved as UPC87832  |                   | Paper bag      | 2             |          |               | AM        |

@ScenarioId:1197
Scenario: [87825] Summary Shows Case UPC Data
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I generate a random UPC number and save as: UPC87825
	Given I generate a random UPC number and save as: UPC878251
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
	Then I save the product information as: TestCase87825
		Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)

	Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue) for
		| Retailer |
		| Amazon   |
	Given I call Shared Step 87647 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC87825, container type: Paper bag and size: 2 do not click continue
	Given I call Shared Step 87641 (Enter Universal Product Code - case information) for UPC: saved as UPC878251, container type: Paper bag and size: 2 and Quantity: 2 and Associated UPC: UPC87825 and Transportation option: 4A: steel box
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
		| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
	Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: test
	Given I click the Summary button in the Data Acceptance window
	Then I switch to the Data Summary page
	And The Data Summary section Provide the product's UPC(s), including container type and size (ounces) should be showing the following UPC table:
		| UPC Number         | Associated UPC    | Container Type | Size (Ounces) | Quantity | Transport     | Retailers |
		| saved as UPC878251 | saved as UPC87825 | Paper bag      | 2             | 2        | 4A: steel box | AM        |
		| saved as UPC87825  |                   | Paper bag      | 2             |          |               | AM        |
	And I close the window that opened
	And I navigate to the home page
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase87825

@ScenarioId:1200
Scenario: [96071] Archived UPC is permitted to be added to product - New Product registration
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I generate a random UPC number and save as: UPC96071_2
	And I filter the products by: Accepted by Retailers
	And I save the ProductID and Name of the first Product in the grid with a retailer as: TestCase96071
	And I click Row Actions for product saved as: TestCase96071
	Then I click on the Row Action: Edit UPCs
	And I save the first UPC in the list as: UPC96071
	And I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I click the following option in the bottom menu: Search
	And In SHA Manager ProductSearch page I run search:
		| Search Term | Search Value      |
		| Status      | All               |
		| UPC         | saved as UPC96071 |
	And In SHA Manager I confirm that there is one item in the grid
	And I navigate to the landing page
	And I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	And I filter for the product saved as: TestCase96071
	And I click Row Actions for product saved as: TestCase96071
	Then I click on the Row Action: Process UPC Update
	Then I delete UPC saved as: UPC96071
	And I click the 'Add UPC' button
	And I enter UPC Number: saved as UPC96071_2
	And I Select a container type from the drop down list
	And I enter Size Value: 12
	And In the Universal Product Code (UPC) page I click Save
	Given In the Data Acceptance page I click on the Accept button
	Given I navigate to the home page
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
	Then I save the product information as: TestCase96071_2
		Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)

	Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue) for
		| Retailer  |
		| Walgreens |
	And I click the 'Add UPC' button
	And I enter UPC Number: saved as UPC96071
	And I Select a container type from the drop down list
	And I enter Size Value: 12
	Given in the Universal Product Code (UPC) page I click Continue
	Given I should see the Regulatory Documents to Provide Page for the New Product
	Given I navigate to the home page
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase96071_2

@ScenarioId:1199
Scenario: [95988] Mass Upload UPCs Floating
	Then I generate: 20 random UPC numbers and save them starting with: RandomUPC
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	And I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Soap (Bar, Liquid) for Body
	Then I save the product information as: TestCase95988
	And I click continue
		And I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)

	And I call Shared Step 57501 (Physical and Chemical Properties - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue - HP)
	And I call Shared Step 29181 (Ingredients - add any chemical) with name: soap
	Then I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
	And I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Amazon
	And I click continue
	And I click Sample File link and verify the Upload UPC form and save it as test95988 with data:
		| UPC          | Name | Quantity | Size | Net Explosive Mass | US: Part Number | US: Item Number | GP: Part Number | SP: Part Number | TG: DPCI    | HD: OMSID | CT: Item Number   | Green Good Housekeeping | Green Seal | EPA Safer Choice | Cradle to Cradle | UL Ecologo | EWG Verified | Green Tick | Madesafe | NSF Sustainability Certified |
		| 823973000000 |      | 1        | 11   | 1.22               | 11AB45          | 1001            | 1111            | A0001           | 111-22-0001 | 100000001 | 123-1234,123-1230 | Yes                     |            |                  |                  |            | Yes          |            |          | Yes                          |
		| 71617198008  |      | 2        | 22   | 2.33               | 12AB56          | 1002            | 2222            | B0002           | 111-22-0002 | 100000002 | 123-1234,123-1231 |                         | Yes        |                  |                  |            |              | Yes        |          |                              |
		| 978959000000 |      | 3        | 33   | 3.44               | 12AC67          | 1003            | 3333            | C0003           | 111-22-0003 | 100000003 | 123-1234,123-1232 |                         |            | Yes              |                  |            |              |            |          |                              |
		| 688267000000 |      | 4        | 44   | 4.55               | 12AD89          | 1004            | 4444            | D0004           | 111-22-0004 | 100000004 | 123-1234,123-1233 |                         |            |                  | Yes              |            |              |            | Yes      |                              |
		| 854911000000 |      | 5        | 55   | 5.66               | 12AF00          | 1005            | 5555            | E0005           | 111-22-0005 | 100000005 | 123-1234,123-1234 |                         |            |                  |                  | Yes        |              |            |          |                              |
	And I edit the testdoc.xlsx, and save its filepath as: Bulktest95988 and verify it contains the UPC data in the table saved as: UPCTable95988, (Base Data Only: true)
		| UPC           | Name     | Quantity | Size | Net Explosive Mass | US: Part Number | US: Item Number | GP: Part Number | SP: Part Number | TG: DPCI    | HD: OMSID | CT: Item Number   | Green Good Housekeeping | Green Seal | EPA Safer Choice | Cradle to Cradle | UL Ecologo | EWG Verified | Green Tick | Madesafe | NSF Sustainability Certified |
		| <RandomUPC1>  | MySoap1  | 1        | 32   | 1.22               | 00AA01          | 2001            | 1111            | F0001           | 111-22-0001 | 100000001 | 123-1234,123-1230 |                         |            |                  |                  |            |              |            |          |                              |
		| <RandomUPC2>  | MySoap2  | 2        | 32   | 2.33               | 00BB02          | 2002            | 1112            | G0002           | 111-22-0002 | 100000002 | 123-1234,123-1231 |                         |            |                  |                  |            |              |            |          |                              |
		| <RandomUPC3>  | MySoap3  | 3        | 32   | 3.44               | 00CC03          | 2003            | 1113            | H0003           | 111-22-0003 | 100000003 | 123-1234,123-1232 |                         |            |                  |                  |            |              |            |          |                              |
		| <RandomUPC4>  | MySoap4  | 4        | 32   | 4.55               | 00DD04          | 2004            | 1114            | I0004           | 111-22-0004 | 100000004 | 123-1234,123-1233 |                         |            |                  |                  |            |              |            |          |                              |
		| <RandomUPC5>  | MySoap5  | 5        | 32   | 5.66               | 00EE05          | 2005            | 1115            | J0005           | 111-22-0005 | 100000005 | 123-1234,123-1234 |                         |            |                  |                  |            |              |            |          |                              |
		| <RandomUPC6>  | MySoap6  | 6        | 32   | 6.77               | 00FF06          | 2006            | 1116            | K0006           | 111-22-0006 | 100000006 | 123-1234,123-1235 |                         |            |                  |                  |            |              |            |          |                              |
		| <RandomUPC7>  | MySoap7  | 7        | 32   | 7.88               | 00GG07          | 2007            | 1117            | L0007           | 111-22-0007 | 100000007 | 123-1234,123-1236 |                         |            |                  |                  |            |              |            |          |                              |
		| <RandomUPC8>  | MySoap8  | 8        | 32   | 8.99               | 00HH08          | 2008            | 1118            | M0008           | 111-22-0008 | 100000008 | 123-1234,123-1237 |                         |            |                  |                  |            |              |            |          |                              |
		| <RandomUPC9>  | MySoap9  | 9        | 32   | 9.00               | 00II09          | 2009            | 1119            | N0009           | 111-22-0009 | 100000009 | 123-1234,123-1238 |                         |            |                  |                  |            |              |            |          |                              |
		| <RandomUPC10> | MySoap10 | 10       | 32   | 10.11              | 00JJ10          | 2010            | 1110            | O0010           | 111-22-0010 | 100000010 | 123-1234,123-1239 |                         |            |                  |                  |            |              |            |          |                              |
		| <RandomUPC11> | MySoap11 | 11       | 32   | 11.22              | 00KK11          | 2011            | 1111            | P0013           | 111-22-0011 | 100000011 | 123-1234,123-1240 |                         |            |                  |                  |            |              |            |          |                              |
		| <RandomUPC12> | MySoap12 | 12       | 32   | 12.33              | 00LL12          | 2012            | 1112            | Q0014           | 111-22-0012 | 100000012 | 123-1234,123-1241 |                         |            |                  |                  |            |              |            |          |                              |
		| <RandomUPC13> | MySoap13 | 13       | 32   | 13.44              | 00MM13          | 2013            | 1113            | R0015           | 111-22-0013 | 100000013 | 123-1234,123-1242 |                         |            |                  |                  |            |              |            |          |                              |
		| <RandomUPC14> | MySoap14 | 14       | 32   | 14.55              | 00NN14          | 2014            | 1114            | S0016           | 111-22-0014 | 100000014 | 123-1234,123-1243 |                         |            |                  |                  |            |              |            |          |                              |
		| <RandomUPC15> | MySoap15 | 15       | 32   | 15.66              | 00OO15          | 2015            | 1115            | T0015           | 111-22-0015 | 100000015 | 123-1234,123-1244 |                         |            |                  |                  |            |              |            |          |                              |
		| <RandomUPC16> | MySoap16 | 16       | 32   | 16.77              | 00PP16          | 2016            | 1116            | U0016           | 111-22-0016 | 100000016 | 123-1234,123-1245 |                         |            |                  |                  |            |              |            |          |                              |
		| <RandomUPC17> | MySoap17 | 17       | 32   | 17.88              | 00QQ17          | 2017            | 1117            | u0017           | 111-22-0017 | 100000017 | 123-1234,123-1246 |                         |            |                  |                  |            |              |            |          |                              |
		| <RandomUPC18> | MySoap18 | 18       | 32   | 18.99              | 00RR18          | 2018            | 1118            | v0018           | 111-22-0018 | 100000018 | 123-1234,123-1247 |                         |            |                  |                  |            |              |            |          |                              |
		| <RandomUPC19> | MySoap19 | 19       | 32   | 19.00              | 00SS19          | 2019            | 1119            | W0019           | 111-22-0019 | 100000019 | 123-1234,123-1248 |                         |            |                  |                  |            |              |            |          |                              |
		| <RandomUPC20> | MySoap20 | 20       | 32   | 20.11              | 00TT20          | 2020            | 1120            | X0020           | 111-22-0020 | 100000020 | 123-1234,123-1249 |                         |            |                  |                  |            |              |            |          |                              |
	Then I click the 'Upload UPCs' button and upload the file saved as: Bulktest95988
	Then I confirm that Add Multiple UPC popup appears and the values are the same as the UPC Upload document saved in the Table called: UPCTable95988
	Then In the Add Multiple dialog box I select all UPCs
	Then I Confirm All UPCs are: Selected
	Then In the Add Multiple dialog box I select the packaging type: <first>
	Then I Check that the type column becomes populated with option: <first>
	Given In the Add Multiple dialog box I click Next
	Then In the Add Multiple dialog box I select all Retailers
	Then I Check if all Retailers are: Selected
	Then In the Add Multiple dialog box I select all Retailers
	Then I Check if all Retailers are: Not Selected
	Then In the Add Multiple dialog box I select all Retailers
	Then I Check if all Retailers are: Selected
	Then In the Add Multiple dialog box I click Finish
	And I confirm that Add Multiple UPC popup disappears and the values on the new product screen are the same as the UPC Upload document saved in the Table called: UPCTable95988
	Then I Confirm that the Add/Upload UPC Buttons remain stay visible when scrolling up and down the page
	Then I click Continue and should not see an error message
	And I navigate to the home page
	And I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase95988

@ScenarioId:6375
Scenario: [109516] Archive Retailer should Archive UPC
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I generate a random UPC number and save as: UPC109516
	Given I generate a random UPC number and save as: UPC109516_2
	And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	And I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk
	Then I save the product information as: TestCase109516
		Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)

	Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue) for
		| Retailer  |
		| Amazon    |
		| Walgreens |
	Given I call Shared Step 87647 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC109516, container type: Paper bag and size: 2 do not click continue
	And I click the 'Add UPC' button
	And I enter UPC Number: saved as UPC109516_2
	And I Select a container type from the drop down list
	And I enter Size Value: 12
	And I delete retailer Amazon from the UPC
	And I click continue
	And I set the OSHA-compliant Safety Data Sheet, English option to: Yes, I certify that I have an OSHA-compliant SDS for this product and would like to upload it.
	And I click the browse button for label: OSHA SDS and upload PDF: C:\Dependencies\WERCSmart\testdoc.pdf
	And I check the checkbox with description: I confirm I am providing the most current Safety Data Sheet (SDS), Article Information Sheet (AIS) and/or Product Label for this registration. I understand I will need to provide a revised document should any changes be made to the registration data or documents in the future.
	And I click continue
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: test
	Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	And I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Submitted Status for saved as: TestCase109516)
	Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase109516)
	And I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase109516)
	And I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase109516)
	Given I call Shared Step 75347 (WPS Studio - PD+ - set all data and publish using rule and Doc queue - CKLT, NGHS and SBCS) for product saved as: TestCase109516
	And I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase109516)
	Given I call Shared Step 59066 (Go to SHA Manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase109516)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase109516 and its status is: Accepted or Completed
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase109516)
	Given I call Shared Step 51664 (SHA - Accepted Product - set Retailers to Completed for saved as: TestCase109516) for
		| Retailer  |
		| Amazon    |
		| Walgreens |
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase109516)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase109516 and its status is: Completed
	Given I navigate to the landing page
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	And I filter for the product saved as: TestCase109516
	And I click Row Actions for the first product returned
	And I click on the Row Action: Archive Retailers
	And In the Archive Retailers popup, I select the checkbox next to the retailer Walgreens
	And In the Archive Retailers popup click on: ARCHIVE
	And I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase109516)
	And I confirm that the retailer Walgreens is archived for product saved as: TestCase109516
	Given I call Shared Step 75309 (SHA > Select Product > UPC Retailer and Feed) for product saved as: TestCase109516
	And I confirm UPC number saved as: "UPC109516" is displayed in the SHA Manager Product UPC list
	And I confirm UPC number saved as: "UPC109516_2" is displayed in the SHA Manager Product UPC list
	And I confirm that UPC number saved as: UPC109516_2 shows a grey background for Archived in the SHA Manager Product UPC list

@ScenarioId:6236
Scenario: [101023] UPC Step - Add Part Number
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
	Then I save the product information as: TestCase105352
		And I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)

	And I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	And I call Shared Step 29181 (Ingredients - add any chemical) with name: water
	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given the 'Select Retailers' window appears
	Then In the 'Select Retailers' window I select the retailer: Staples
	And in the New Product page I click Continue
	Then I enter Container type: Metal Container, Size 40, Packaging type: NA and Part number: ABC123 then click continue in the UPC screen
	And I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Product's Dispensing Method | Partition Coefficient |
		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | Aerosol                     | 41.3005               |
	Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: test
	Then I should see the Data Acceptance Page
	Given I click the Summary button in the Data Acceptance window
	Given I switch to the Data Summary page
	Then I confirm that the Prouct UPC Table shows in the UPC Number column the value of PART NUMBER for the UPC with Name: Chalk
	Given I close the Data Summary tab
	And I navigate to the home page
	And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase105352


@tfs_design
#In Progress. This test was a false positive in the regression. Some minor reworking is still needed to make it pass consistently.  
@ScenarioId:6025
Scenario: [84510] Select Retailers in UPC screen
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Soap (Bar, Liquid) for Body
	Then I save the product information as: TestCase84510
	And I should see the Product Information Page
	And I should see following statement: Select countries the product may be sold in
	And I should see following statement: Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)
	And I should see following statement: Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)
	And I should see following statement: Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.
	Given I set all product information options to No
	Given in the Product Information page I click Continue
	Given I call Shared Step 57501 (Physical and Chemical Properties - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue - HP)
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
	And I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
	#Going to rewrite to select all retailers.
	#Wil add step that slects all vendors where drop down is found
	#Will save list of selected retailers to context.
	#And I select the following retailers in the 'Select Retailers' window
	#	| Retailer       |
	#	| Amazon         |
	#	| Autozone       |
	#	| Best Buy       |
	#	| CVS            |
	#	| Dollar General |
	#	| Family Dollar  |
	#	| Kohl's         |
	#	| McLane         |
	#if the select retailers window does not open then we need to clickt eh add retailers button (bug?) -> can only test after the Acc reset.
	Then the 'Select Retailers' window appears
	Given I click the Select all retailers option in the Select Retailers popup
	Then all retailers are selected in the Select Retailers window
	Given I click Done in the Select Retailers popup
	Given In the Retailers tab, I select the first Vendor option for retailer: O'Reilly
	Given In the Retailers tab, I select the first Vendor option for retailer: Sears/K-Mart
	Given In the Retailers tab, I select the first Vendor option for retailer: Wal-Mart/SAM'S CLUB
	And I click continue

	Given I click the 'Add UPC' button
	Given I fill in the UPC data; UPC:0786987894855, Product Type:Paper bag, Product Weight:5
	Given I remove randomly selected retailers

	#Below check that the realtaiers deleted are all seen in below window popup list.
	#Retailers in popup are in alphabeticcal order
	#Once restored check destination retailers list is in alpha order
	Given I click the 'Add Retailers' button
	Then The 'Add Retailers' popup contains all the retailers saved as: LatestRemovedRetailers
	Given I randomly select retailers to restore
	Given I click the 'Restore Selected' button
	Given I click the 'Add Retailers' button
	Then In the 'Add Retailers' popup does not contain the retailes saved as LastRestoredRetailers
	Given I click 'Select All' to add all removed retailers
	Then In the 'Add Retailers' popup I confirm that all retailers are currently selected
	Given I click the 'Restore Selected' button
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase84510

@ScenarioId:6058
Scenario: [87628] Universal Product Code (UPC) Step - Add Case UPC - Case UPC field validation
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Then the WERCSmart homepage should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk
	Then I save the product information as: TestCase87628
	And I should see the Product Information Page
	And I should see following statement: Select countries the product may be sold in
	And I should see following statement: Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)
	And I should see following statement: Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)
	And I should see following statement: Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.
	Given I set all product information options to No
	Given in the Product Information page I click Continue
	Given I call Shared Step 57501 (Physical and Chemical Properties - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue - HP)
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
	And I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	And I select the following retailers in the 'Select Retailers' window
		| Retailer |
		| Amazon   |
	Given I click the 'Add UPC' button
	Given I fill in the UPC data; UPC:ABCDEF, Product Type:Paper bag, Product Weight:5
	When I click continue
	Given I check for the appropriate alert: UPC must be between 12 and 14 characters long.
	Given I check for the appropriate alert: This field must be a number
	Given I fill in the UPC data; UPC:12345, Product Type:Paper bag, Product Weight:5
	When I click continue
	Given I check for the appropriate alert: UPC must be between 12 and 14 characters long.
	Given I fill in the UPC data; UPC:12345678910111213, Product Type:Paper bag, Product Weight:5
	When I click continue
	Given I check for the appropriate alert: UPC must be between 12 and 14 characters long.
	Given I fill in the UPC data; UPC:111111111111, Product Type:Paper bag, Product Weight:5
	When I click continue
	Then I check for the appropriate alert: Please ensure your UPC is 12 or 14 digits and contains leading zeroes and check digit
	Given I fill in the UPC data; UPC:0727506002788, Product Type:Paper bag, Product Weight:5
	When I click continue
	Then I check for the appropriate alert: No error
	Given in the Universal Product Code (UPC) page I click Continue
	Then I check if the Regulatory Documents page is shown
	Then I navigate to the home page
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase87628

@tfs_design
@ScenarioId:6054
Scenario: [87305] Retailer Selected but No UPC Associated: Remove Retailer when Continuing
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Soap (Bar, Liquid) for Body
	Then I save the product information as: TestCase87305
	And I should see the Product Information Page
	And I should see following statement: Select countries the product may be sold in
	And I should see following statement: Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)
	And I should see following statement: Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)
	And I should see following statement: Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.
	Given I set all product information options to No
	Given I click continue
	Given I call Shared Step 57501 (Physical and Chemical Properties - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue - HP)
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
	And I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
	And I select the following retailers in the 'Select Retailers' window
		| Retailer       |
		| Amazon         |
		| Autozone       |
		| Best Buy       |
		| CVS            |
		| Dollar General |
	Given I click the 'Add UPC' button
	Given I fill in the UPC data; UPC:0667539048202, Product Type:Paper bag, Product Weight:5
	Given I remove randomly selected retailers
	Given I click the 'Add Retailers' button
	Then I click continue
	Then I click NO for the UPCs Warning! popup TestCase87305
	Then I click continue
	Then I click YES for the UPCs Warning! popup TestCase87305
	Given I should see the Regulatory Documents to Provide Page
	Given I set the OSHA-compliant Safety Data Sheet, English field to: Request to author
	Then I click continue
	Then I click continue
	Then I click continue
	And I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
		|                               |                          |                         |           | Black      | Odorless | No data available | 10                    |
	And I call Shared Step 57883 (Comments - Happy Path) and enter the comment: test
	#Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	#Given If purchase details are showing click confirm order
	#And I navigate to the home page
	#Given I search for the product saved as: TestCase87305
	Then I confirm the retailers are removed TestCase87305
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase87305

@ScenarioId:6064
Scenario: [87598]- Universal Product Code (UPC) Step - Add Case UPC - fields required
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk
	Then I save the product information as: TestCase87598
	And I should see the Product Information Page
	And I should see following statement: Select countries the product may be sold in
	And I should see following statement: Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)
	And I should see following statement: Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)
	And I should see following statement: Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.
	Given I set all product information options to No
	Given in the Product Information page I click Continue
	Given I call Shared Step 57501 (Physical and Chemical Properties - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue - HP)
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
	And I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	And I select the following retailers in the 'Select Retailers' window
		| Retailer |
		| Amazon   |
		| CVS      |
	Given I click Add Case UPC
	Given in the Universal Product Code (UPC) page I click Continue
	Then I check if the textfields with the following placeholders display the error 'This is a required field.' bottom
		| Placeholder                       |
		| UPC Number                        |
		| Size (Weight Ounces)              |
		| Quantity of Units within the Case |
	Then I check if the dropdowns with the following default options display the error 'This is a required field.' bottom
		| Default Option         |
		| Container Type         |
		| Transportation Options |
	Then I confirm no error is shown below the Individual UPC contained in the Case Pack field
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase87598

@ScenarioId:6226
Scenario: [115334] Target - Add UPC - DPCI - is no longer required
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
	Then I save the product information as: TestCase115334
		Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)

	Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	And I call Shared Step 29181 (Ingredients - add any chemical) with name: Water
	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given I select the following retailers in the Select Retailers popup list view:
		| Retailer |
		| Target   |
	Then I click Done on Select Retailers window
	Then I click continue
	And I click the 'Add UPC' button
	Then I click continue
	Then I confirm that DPCI label text for retailer Target UPC item 1 matches: DPCI Number (must be formatted like xxx-xx-xxxx), if multiple separate by ',' with no spaces.
	Then I confirm that DPCI for retailer Target UPC should not be required
	Then I generate a random UPC number and save as: UPC#115334_1
	And I enter UPC Number: saved as UPC#115334_1
	And I Select a container type from the drop down list
	And I enter Size Value: 12
	Then I click Continue and should not see an error message
	And In the New Product page I should be on tab: Review and Submit
	Then I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase115334

#JWhitesell - holding off on finishing this one so I can work on sprint scenarios for sprint 17.
@tfs_design
@ScenarioId:6399
Scenario: [109596] Edit UPC and adding a Retailer to a UPC should create an order history record
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Then I generate a random UPC number and save as: UPC#109596_1
	Then I generate a random UPC number and save as: UPC#109596_2
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
	Then I save the product information as: TestCase109596
		Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)

	Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	And I call Shared Step 29181 (Ingredients - add any chemical) with name: Water
	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given I select the following retailers in the Select Retailers popup list view:
		| Retailer  |
		| CVS       |
		| Walgreens |
		| Amazon    |
	Then I click Done on Select Retailers window
	Then I click continue
	And I call Shared Step 87647 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC#109596_1, container type: Plastic Container and size: 32 do not click continue
	And I call Shared Step 87647 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC#109596_2, container type: Plastic Container and size: 32 do not click continue
	And I remove the following retailers
		| Retailer |
		| CV       |
		| AM       |
	And I click continue
	And I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Then in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	And I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
		| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
	And I call Shared Step 57883 (Comments - Happy Path) and enter the comment: test
	Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given If purchase details are showing click confirm order
	And I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase109596)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase109596 and its status is: Submitted
	And I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase109596)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Assigned Status for saved as: TestCase109596)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase109596 and its status is: Assigned
	And I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase109596)
	And I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase109596)
	And I call Shared Step 78877 - WPS Studio - PD+ - set all data and publish using rule and doc queue - CKLT, NGHS, HSGH (EN and CF) and SBCS for saved as: TestCase109596
	And I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase109596)
	Given I call Shared Step 59066 (Go to SHA Manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase109596)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase109596 and its status is: Accepted
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Accepted Status for saved as: TestCase109596)
	Given I call Shared Step 51664 (SHA - Accepted Product - set Retailers to Completed for saved as: TestCase109596) for
		| Retailer  |
		| Amazon    |
		| Walgreens |
		| CVS       |
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase109596)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase109596 and its status is: Completed
	Given I navigate to the landing page
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I search for the product saved as: TestCase109596
	When I click Row Actions for the most recent product returned
	Then I click on the Row Action: Edit UPCs
	Then I expand the chevron for UPC saved as UPC#109596_2
	Given I click the 'Add Retailers' button
	Given I select the following Retailers to restore
		| Retailer |
		| Amazon   |
	Given I click the 'Restore Selected' button
	And In the Universal Product Code (UPC) page I click Save
	Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	And I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase109596)

#Given I right click on product saved as TestCase109596 and select View Orders
#Given I click on the first entry in the View Orders popup
#And I confirm that the top entry has a status of Additional UPC submission
#And In the View Orders popup I click Back
#Given I click on the second entry in the View Orders popup
#And I confirm that for each retailer, the entry has a status of Chemical Assessment
@ScenarioId:6948
Scenario: [115330] Target - Bulk UPC - DPCI - is no longer required
	#Currently running into issues with file upload working full with dpci. Need to discuss. May need to remove BulkUploadFile
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk
	Then I save the product information as: TestCase115330
		Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)

	Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	And I call Shared Step 29181 (Ingredients - add any chemical) with name: Water
	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given I select the following retailers in the Select Retailers popup list view:
		| Retailer |
		| Target   |
	Then I click Done on Select Retailers window
	And I click continue
	Then I generate a random UPC number and save as: UPC#115330_1
	Then I generate a random UPC number and save as: UPC#115330_2
	Then I generate a random UPC number and save as: UPC#115330_3
	Then I generate a random UPC number and save as: UPC#115330_4
	Then I generate a random UPC number and save as: UPC#115330_5
	Then I generate a random UPC number and save as: UPC#115330_6
	Then I generate a random UPC number and save as: UPC#115330_7
	And I click Sample File link and verify the Upload UPC form and save it as test115330
		| UPC          | Name | Quantity | Size | Net Explosive Mass | US: Part Number | US: Item Number | GP: Part Number | SP: Part Number | TG: DPCI    | HD: OMSID | CT: Item Number   | Green Good Housekeeping | Green Seal | EPA Safer Choice | Cradle to Cradle | UL Ecologo | EWG Verified | Green Tick | Madesafe | NSF Sustainability Certified |
		| 823973000000 |      | 1        | 11   | 1.22               | 11AB45          | 1001            | 1111            | A0001           | 111-22-0001 | 100000001 | 123-1234,123-1230 | Yes                     |            |                  |                  |            | Yes          |            |          | Yes                          |
		| 71617198008  |      | 2        | 22   | 2.33               | 12AB56          | 1002            | 2222            | B0002           | 111-22-0002 | 100000002 | 123-1234,123-1231 |                         | Yes        |                  |                  |            |              | Yes        |          |                              |
		| 978959000000 |      | 3        | 33   | 3.44               | 12AC67          | 1003            | 3333            | C0003           | 111-22-0003 | 100000003 | 123-1234,123-1232 |                         |            | Yes              |                  |            |              |            |          |                              |
		| 688267000000 |      | 4        | 44   | 4.55               | 12AD89          | 1004            | 4444            | D0004           | 111-22-0004 | 100000004 | 123-1234,123-1233 |                         |            |                  | Yes              |            |              |            | Yes      |                              |
		| 854911000000 |      | 5        | 55   | 5.66               | 12AF00          | 1005            | 5555            | E0005           | 111-22-0005 | 100000005 | 123-1234,123-1234 |                         |            |                  |                  | Yes        |              |            |          |                              |
	And I edit the testdoc.xlsx, and save its filepath as: Bulktest115330 and verify it contains the UPC data in the table saved as: UPCTable115330, (Base Data Only: true)
		| UPC            | Name     | Quantity | Size | Net Explosive Mass | US: Part Number | US: Item Number | GP: Part Number | SP: Part Number | TG: DPCI | HD: OMSID | CT: Item Number   |
		| %UPC#115330_1% | MyChalk1 | 1        | 32   | 1.22               | 00AA01          | 2001            | 1111            | F0001           |          | 100000001 | 123-1234,123-1230 |
		| %UPC#115330_2% | MyChalk2 | 2        | 32   | 2.33               | 00BB02          | 2002            | 1112            | G0002           |          | 100000002 | 123-1234,123-1231 |
		| %UPC#115330_3% | MyChalk3 | 3        | 32   | 3.44               | 00CC03          | 2003            | 1113            | H0003           |          | 100000003 | 123-1234,123-1232 |
		| %UPC#115330_4% | MyChalk4 | 4        | 32   | 4.55               | 00DD04          | 2004            | 1114            | I0004           |          | 100000004 | 123-1234,123-1233 |
		| %UPC#115330_5% | MyChalk5 | 5        | 32   | 5.66               | 00EE05          | 2005            | 1115            | J0005           |          | 100000005 | 123-1234,123-1234 |
		| %UPC#115330_6% | MyChalk6 | 6        | 32   | 6.77               | 00FF06          | 2006            | 1116            | K0006           |          | 100000006 | 123-1234,123-1235 |
		| %UPC#115330_7% | MyChalk7 | 7        | 32   | 7.88               | 00GG07          | 2007            | 1117            | L0007           |          | 100000007 | 123-1234,123-1236 |
	Then I click the 'Upload UPCs' button and upload the file saved as: Bulktest115330
	Then I confirm that Add Multiple UPC popup appears and the values are the same as the UPC Upload document saved in the Table called: UPCTable115330
	Then In the Add Multiple dialog box I select all UPCs
	Then I Confirm All UPCs are: Selected
	Then In the Add Multiple dialog box I select the packaging type: <first>
	Then I Check that the type column becomes populated with option: <first>
	Given In the Add Multiple dialog box I click Next
	Then In the Add Multiple dialog box I select all Retailers
	Then I Check if all Retailers are: Selected
	Then In the Add Multiple dialog box I click Finish
	When In the Recipient and Product Details tab, I expand the first UPC
	Then I check that DPCI for retailer Target UPC item 1 should match the UPC Upload document saved in the Table called: UPCTable115330
	Then I click Continue and should not see an error message
	And In the New Product page I should be on tab: Review and Submit
	When In the New Product page I click tab: Recipient and UPC Details
	And I click the page heading: Universal Product Code (UPC)
	And In the Recipient and Product Details tab, I expand the first UPC
	Then I check that DPCI for retailer Target UPC item 1 should match the UPC Upload document saved in the Table called: UPCTable115330
	Then I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase115330

@ScenarioId:7042
Scenario:[120798] "U" for UPC Update for Suspended Status
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I generate a random UPC number and save as: UPC120798
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk
	Then I save the product information as: TestCase120798
		Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)

	Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	And I call Shared Step 29181 (Ingredients - add any chemical) with name: Water
	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	And In the 'Select Retailers' window I select the retailer: Walgreens
	And I click continue
	And I call Shared Step 85909 (UPC - Confirm Package type link and drop down not shown - Add UPC data - Continue) for UPC: saved as UPC120798, container type: Plastic Container and size: 12 click continue
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Then in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	And I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
		| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
	And I call Shared Step 57883 (Comments - Happy Path) and enter the comment: test
	Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given If purchase details are showing click confirm order
	And I navigate to the home page
	And I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase120798)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase120798 and its status is: Submitted
	Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase120798)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase120798)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase120798 and its status is: Assigned
	And I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase120798)
	And I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase120798)
	And I call Shared Step 78877 - WPS Studio - PD+ - set all data and publish using rule and doc queue - CKLT, NGHS, HSGH (EN and CF) and SBCS for saved as: TestCase120798
	And I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase120798)
	Given I call Shared Step 59066 (Go to SHA Manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase120798)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase120798 and its status is: Accepted
	Given I navigate to the landing page
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I search for the product saved as: TestCase120798
	When I click Row Actions for the most recent product returned
	Then I click on the Row Action: Edit UPCs
	Given I generate a random UPC number and save as: UPC120798
	And I enter information for Enter Universal Product Code (UPC) - UPC-Container Type - Size Only for UPC: for UPC: saved as UPC120798, container type: Plastic Container and size: 12 - do not click continue
	And I click Save in The Product Page
	And I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	And I navigate to the home page
	And I call Shared Step 65080 (Login to Studio and Open SHA manager)
	And I click the following option in the bottom menu: Search
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase120798)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase120798 and its status is: Recertification
	Then I confirm that there is a 'U' next to the following product saved as: TestCase120798
	And In SHA Manager I select the first product
	And I click the following option in the bottom menu: Suspended
	And In the Suspended dialog I Select the following clients: All
	And In the Suspended dialog in the Select Regulatory Specialist drop down I choose: Automated QASha
	And In the Suspended dialog in the Select Subject drop down I choose: Product Name is Unclear
	And In the Suspended dialog in the Supplier Message field I add the following text: supplier message input
	And In the Suspended dialog in the Internal Product Note field I add the following text: internal product note input
	And In the Suspended dialog I click Suspend
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase120798 and its status is: Suspended
	Then I confirm that there is a 'U' next to the following product saved as: TestCase120798

@ScenarioId:7043
Scenario:[120849] "U" for UPC Update No Fee Charge
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I generate a random UPC number and save as: UPC120798
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk
	Then I save the product information as: TestCase120798
		Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)

	Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	And I call Shared Step 29181 (Ingredients - add any chemical) with name: Water
	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	And In the 'Select Retailers' window I select the retailer: Walgreens
	And I click continue
	And I call Shared Step 85909 (UPC - Confirm Package type link and drop down not shown - Add UPC data - Continue) for UPC: saved as UPC120798, container type: Plastic Container and size: 12 click continue
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Then in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	And I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
		| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
	And I call Shared Step 57883 (Comments - Happy Path) and enter the comment: test
	Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given If purchase details are showing click confirm order
	And I navigate to the home page
	And I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase120798)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase120798 and its status is: Submitted
	Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase120798)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase120798)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase120798 and its status is: Assigned
	And I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase120798)
	And I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase120798)
	And I call Shared Step 78877 - WPS Studio - PD+ - set all data and publish using rule and doc queue - CKLT, NGHS, HSGH (EN and CF) and SBCS for saved as: TestCase120798
	And I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase120798)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase120798)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase120798 and its status is: Accepted
	Given I call Shared Step 51664 (SHA - Accepted Product - set Retailers to Completed for saved as: TestCase120798) for
		| Retailer  |
		| Walgreens |
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I search for the product saved as: TestCase120798
	When I click Row Actions for the most recent product returned
	Then I click on the Row Action: Edit UPCs
	Given I generate a random UPC number and save as: UPC120798
	And I call Shared Step 85909 (UPC - Confirm Package type link and drop down not shown - Add UPC data - Continue) for UPC: saved as UPC120798, container type: Plastic Container and size: 12 click continue
	And I click Save in The Product Page
	Given In the Data Acceptance page I click on the Accept button
	Then In the Thank You screen I confirm the following statement is shown: Thank you for registering your product on WERCSmart for assessment.
	And I navigate to the home page







@ScenarioId:10662
Scenario: [156789] UPC Screen - Internal SKU field - Check field parameters and ensure is optional

Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
Given I generate a random UPC number and save as: UPC156789
Then Generate a random SKU number (12 random digits) and save as: RandomSKU_1
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
Given I save the product information as: TestCase
Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)

Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Water
Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Given I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue) for
| Retailer  |
| Walgreens |
Given I call Shared Step 87647 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC156789, container type: Plastic Container and size: 2 do not click continue
Given I click continue
Then I should see the Regulatory Documents to Provide Page
Given In the New Product page I click tab: Recipient and UPC Details
Given I click the page heading: Universal Product Code (UPC)
Given I delete UPC: saved as UPC156789
Given I call Shared Step 158500 (Enter Universal Product Code (UPC) - Battery - Confirm SKU - Do Not Click Continue) for UPC saved as: UPC156789 with container type: Metal Container size: 40.0 and SKU: 12345!@#$%12
Given In the Universal Product Code (UPC) page I click Save
Then I check for the appropriate alert: Only 8 to 12 letters and/or numbers allowed
Given I delete UPC: saved as UPC156789
Given I call Shared Step 158500 (Enter Universal Product Code (UPC) - Battery - Confirm SKU - Do Not Click Continue) for UPC saved as: UPC156789 with container type: Metal Container size: 40.0 and SKU: 123456
Given In the Universal Product Code (UPC) page I click Save
Then I check for the appropriate alert: Only 8 to 12 letters and/or numbers allowed
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase
