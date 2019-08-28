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
@SHA
@ForwardProductRegistration
@ProductSetUp
@run_UPC
Feature: UPC

@TReVorId:21457
Scenario: [87584] Physical State = Solid, UPC step - Size shows as Size (Weight Ounces)
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk
	Then I save the product information as: TestCase87584
	Given I call Shared Step 37857 (Enter Physical Property - Solid)
	Given I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
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
	Then I should not see the following UPC options:
		| Option              |
		| Size (Fluid Ounces) |
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase87584

@TReVorId:21458
Scenario: [87587] Physical State = Liquid, UPC step - Size shows as Size (Fluid Ounces)
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Bubble solution
	Then I save the product information as: TestCase87584
	Given I call Shared Step 57514 (Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path)
	Given I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
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
		| Size (Fluid Ounces)               |
	Then I should not see the following UPC options:
		| Option               |
		| Size (Weight Ounces) |
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase87587

@TReVorId:21459
Scenario: [87588] Physical State = Aerosol, UPC step - Size shows as Size (Fluid Ounces)
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Deodorant - Aerosol
	Then I save the product information as: TestCase87588
	Given I call Shared Step 57528 (Product Characteristics - Aerosol Only - add data - Continue - Happy Path)
	Given I call Shared Step 60310 (Additional Product Information - Without Child question)
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
	Then I should not see the following UPC options:
		| Option               |
		| Size (Weight Ounces) |
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase87588

@TReVorId:21460
Scenario: [87593] Physical State = GAS, UPC step - Size shows as Size (Fluid Ounces)
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Compressed gas
	Then I save the product information as: TestCase87593
	Given I call Shared Step 74981 (Product Characteristics - gas)
		| Secondary Physical State | Select the best Water Solubility description |
		| Compressed gas           | Very slight                                  |
	Given I call Shared Step 60310 (Additional Product Information - Without Child question)
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
	Then I should not see the following UPC options:
		| Option               |
		| Size (Weight Ounces) |
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase87593

@TReVorId:21461
Scenario: [87596] Create BCP (Camera with battery) -  UPC step - Size shows as Weight (Ounces)
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Camera w/Battery
	Then I save the product information as: TestCase87596
	Given I call Shared Step 70393 (Additional Product Information - With marketed for use by a Child - Direct Ship - Private Label questions only)
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
	Then I should not see the following UPC options:
		| Option              |
		| Size (Fluid Ounces) |
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase87596

@TReVorId:21462
Scenario: [87597] Create Electronic - UPC Step - Size shows as Size (Weight Ounces)
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Answering machine, No battery included
	Then I save the product information as: TestCase87597
	And I call Shared Step 69687 (Additional Product Information - US, No(PL))
	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	And I call Shared Step 48369 (Toxicity Characteristics Leaching Procedure (TCLP) - No to ALL With Copper)
	And I call Shared Step 71955 (Answer Electronic Equipment questions - Without Cathode Ray - No to all)
	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Amazon
	Given I click the 'Add Case UPC' button
	Then I should see the following UPC options:
		| Option                            |
		| UPC Number                        |
		| Quantity of Units within the Case |
		| Size (Weight Ounces)              |
	Then I should not see the following UPC options:
		| Option              |
		| Size (Fluid Ounces) |
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase87597

@TReVorId:21463
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
	Given I call Shared Step 60648 (Additional Product Information - US, No (Direct Ship), No (PL), No (GNFR))
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
	Then I should not see the following UPC options:
		| Option              |
		| Size (Fluid Ounces) |
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase87595
	  
@TReVorId:22366
Scenario: [87832] View Shows Case UPC Data
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I generate a random UPC number and save as: UPC87832
	Given I generate a random UPC number and save as: UPC878321
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
	Then I save the product information as: TestCase87832
	Given I call Shared Step 26897 (Product Characteristics - Solid only available - continue)
	Given I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
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

@TReVorId:22365
Scenario: [87825] Summary Shows Case UPC Data
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I generate a random UPC number and save as: UPC87825
	Given I generate a random UPC number and save as: UPC878251
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
	Then I save the product information as: TestCase87825
	Given I call Shared Step 26897 (Product Characteristics - Solid only available - continue)
	Given I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
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
