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
@run_Flow9
@UPC
Feature: Flow 9

@TestCase:58072
Scenario: [58072] Baby/Infant/Adult Care/Cleansing Wipes - RU000248
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC58072
	Given I delete all products with UPC Number: saved as UPC58072
	Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Baby/infant/Adult Care/Cleansing Wipes
	Then I save the product information as: TestCase58072
	Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Given I call Shared Step 32931 (Liquid Core Product - select  No - Happy Path)
	Given I call Shared Step 37857 (Enter Physical Property - Solid)
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName    | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Aqua             | 10      | false               | false       |            |
		| Benzoic acid     | 4.5     | false               | false       |            |
		| Citric acid      | 25      | false               | false       |            |
		| Cetearyl alcohol | 40.4    | false               | false       |            |
		| Glycerin         | 20.1    | false               | false       |            |
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
	Given I call Shared Step 57507 (Transportation Details 1- Not Regulated - Continue - Happy Path)
	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Walgreens
	Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC58072, container type: Plastic Container and size: 10.0
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient |
		| Gloves                        | 150                      | 25.0                    | 11.2      | White      | Floral | No data available | 10                    |
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: User added Comments Text 58072. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Baby/infant/Adult Care/Cleansing Wipes
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase58072

@newproductstepstest
@TestCase:58098
Scenario: [58098] Ingredient Table - Selecting Publicly Disclosed/Label Name
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk
	Then I save the product information as: TestCase58098
	Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Given I call Shared Step 37857 (Enter Physical Property - Solid)
	Given I add the following ingredients:
		| ComponentName    | Percent |
		| Aqua             | 50      |
		| Sodium hydroxide | 50      |
	#Given I select the first Public Name dropdown option for ingredient: Aqua
	Given I click the Trade Secret checkbox for ingredient: Aqua
	Given for ingredient: Aqua the Publicly Disclosed field is disabled
	Given I click the Trade Secret checkbox for ingredient: Aqua
	Given I click the Publicly Disclosed checkbox for ingredient: Aqua
	Given I confirm there are 1 Publicly Disclosed ingredients in the Total section
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase58098
	
@TestCase:58078
Scenario: [58078] Energy or Nutritional Bars - RU000618
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC58078
	Given I delete all products with UPC Number: saved as UPC58078
	Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Energy or Nutritional Bars
	Then I save the product information as: TestCase58078
	Given I call Shared Step 57401 (Product Information - US only - No GHS, Not Direct Ship, Not PLP, Not GNFR > Continue - Happy Path)
	Given I call Shared Step 37857 (Enter Physical Property - Solid) with the following inputs:
		| Secondary Physical State | Water Solubility |
		| Granular                 | Dispersible      |
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Water         | 100     | false               | false       |            |
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I set the Refer to your Product Label option to: None of the Above
	Given I click continue
	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: CVS
	Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC58078, container type: Plastic Container and size: 3.6
	Given I call Shared Step 132601 (Additional Documents to Provide - Nutritional Flow)
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: User added Comments Text 58078. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Energy or Nutritional Bars
	Given I navigate to the home page
	Then I delete the product: TestCase58078

@TestCase:58079
Scenario: [58079] Energy or Nutritional Powder/Mix - RU000706
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC58079
	Given I delete all products with UPC Number: saved as UPC58079
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Energy or Nutritional Powder/Mix
	Then I save the product information as: TestCase58079
	Given I call Shared Step 57401 (Product Information - US only - No GHS, Not Direct Ship, Not PLP, Not GNFR > Continue - Happy Path)
	Given I call Shared Step 37857 (Enter Physical Property - Solid) with the following inputs:
		| Secondary Physical State | Water Solubility |
		| Flaked                   | Soluble in water |
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Water         | 100     | false               | false       |            |
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I set the Refer to your Product Label option to: None of the Above
	Given I click continue
	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Save Mart Supermarkets
	Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC58079, container type: Plastic bag and size: 8
	Given I call Shared Step 60567 (Upload Product Label only)
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: User added Comments Text 58079. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Energy or Nutritional Powder/Mix
	#Replace shared 42214
	Given I navigate to the home page
	Then I delete the product: TestCase58079

@TestCase:58073
Scenario: [58073] Footwear - Gel Insert - RU000854
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC58073
	Given I delete all products with UPC Number: saved as UPC58073
	Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Footwear - Gel Insert
	Then I save the product information as: TestCase58073
	Given I call Shared Step 57401 (Product Information - US only - No GHS, Not Direct Ship, Not PLP, Not GNFR > Continue - Happy Path)
	Given I call Shared Step 37857 (Enter Physical Property - Solid) with the following inputs:
		| Secondary Physical State | Water Solubility |
		| Solid                    | Dispersible      |
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Water         | 100     | false               | false       |            |
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: CVS
	Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC58073, container type: Plastic bag and size: 8
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I call Shared Step 60567 (Upload Product Label only)
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
		| Gloves                        | 800                      | 99                      | 60        | Clear      | Odorless | No data available | 11.2                  |
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: User added Comments Text 58073. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Footwear - Gel Insert
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase58073

@TestCase:63325
Scenario: [63325] Herbal or Dietary Supplements - RU000712 Flow 9-LS (checking SDS step shows only product label and Additional documents to provide shows SDS as optional)
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Herbal or Dietary Supplement
	Then I save the product information as: TestCase63325
	Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Given I call Shared Step 57501 (Physical and Chemical Properties - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue)
	Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Water
	Then I call Shared Step 132427 (Waste Classification Data- For OTC Products)
	Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
	Given I call Shared Step 26900 (Transportation Details 1 > Not Regulated)
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	Then I should see the Regulatory Documents to Provide Page
	Then I see the following sections
		| Section                                                                                                                        |
		| Upload Full Product Label (required) (For private label products please upload a generic label that is not retailer-specific.) |
	Given I confirm the document type is: Product Label for section: Upload Full Product Label (required)
	Then I do not see the following sections
		| Section                                   |
		| OSHA-compliant Safety Data Sheet, English |
	Given I call Shared Step 59042 (Browse for File > select > click Open - Happy Path) for document type: Product Label and file: UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf
	Given in the Regulatory Documents to Provide page I click Continue
	Then I should see the Additional Documents to Provide Page
	Then I see the following sections
		| Section                                           |
		| Upload SDS (Optional)                             |
		| Toxicity Characteristic Leaching Procedure (TCLP) |
	Given I click Continue and should not see an error message
	Then I should see the Optional Reports and Documents Available for Purchase Page
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase63325

@TestCase:58091
Scenario: [58091] Latex Gloves - RU000151
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC58091
	Given I delete all products with UPC Number: saved as UPC58091
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Latex gloves
	Then I save the product information as: TestCase58091
	Given I call Shared Step 57401 (Product Information - US only - No GHS, Not Direct Ship, Not PLP, Not GNFR > Continue - Happy Path)
	Given I call Shared Step 37857 (Enter Physical Property - Solid)
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Water         | 100     | false               | false       |            |
	Then I call Shared Step 132427 (Waste Classification Data- For OTC Products)
	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Walgreens
	Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC58091, container type: Plastic Container and size: 37
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I call Shared Step 60567 (Upload Product Label only)
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
		| Mask                          | 400                      | 60                      | 2.2       | White      | Odorless | No data available | 1.5                   |
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: User added Comments Text 58091. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Latex gloves
	#Replace shared 42214
	Given I navigate to the home page
	Then I delete the product: TestCase58091

@TestCase:58075
Scenario: [58075] Nutritional Supplement for Infants - Liquid - RU001365
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC58075
	Given I delete all products with UPC Number: saved as UPC58075
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Nutritional Supplement for Infants - Liquid
	Then I save the product information as: TestCase58075
	Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Then I call Shared Step 57441 (Physical and Chemical Properties - Primary Physical Property - Liquid)
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Aqua          | 65      | false               | false       |            |
		| Vitamin A     | 5       | false               | false       |            |
		| Citric acid   | 25      | false               | false       |            |
		| Vitamin E     | 5       | false               | false       |            |
	# Added in 57637 to make test run. Consult Aaron (WERCS)
	#Given I call Shared Step 57637 (Regulatory Information 1 - TSCA & CEPA shown, No to PROP 65 - Continue - Happy Path)
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Then I call Shared Step 132473 (Regulatory Information 3 - Nutritional Category)
	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: CVS
	Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC58075, container type: Plastic Container and size: 100
	Then I see the following sections
		| Section                    |
		| Flash Point Testing Report |
	#Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Then I call Shared Step 132601 (Additional Documents to Provide - Nutritional Flow)
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: User added Comments Text 58075. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
	Given I navigate to the home page
	Then I delete the product: TestCase58075

@TestCase:58089
Scenario: [58089] Nutritional Supplements for Domesticated Animals - RU001239
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC58089
	Given I delete all products with UPC Number: saved as UPC58089
	Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Nutritional Supplements for Domesticated Animals
	Then I save the product information as: TestCase58089
	Given I call Shared Step 57401 (Product Information - US only - No GHS, Not Direct Ship, Not PLP, Not GNFR > Continue - Happy Path)
	Then I call Shared Step 57441 (Physical and Chemical Properties - Primary Physical Property - Liquid)
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Aqua          | 65      | false               | false       |            |
		| Vitamin A     | 10      | false               | false       |            |
		| Citric acid   | 25      | false               | false       |            |
	# Added in 57637 to make test run. Ask Wercs testers
	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given I call Shared Step 132473 (Regulatory Information 3 - Nutritional Category)
	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Petco
	Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC58089, container type: Plastic Container and size: 100
	Then I see the following sections
		| Section                    |
		| Flash Point Testing Report |
	Given I call Shared Step 132601 (Additional Documents to Provide - Nutritional Flow)
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: User added Comments Text 58089. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
	Given I navigate to the home page
	Then I delete the product: TestCase58089

@TestCase:58097
Scenario: [58097] Ingredient Search in Registration
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Paint balls
	Then I save the product information as: TestCase58097
	Given I call Shared Step 57401 (Product Information - US only - No GHS, Not Direct Ship, Not PLP, Not GNFR > Continue - Happy Path)
	Given I call Shared Step 32931 (Liquid Core Product - select  No - Happy Path)
	#Given I call Shared Step 37857 (Enter Physical Property - Solid)
	Given I call Shared Step 73223 (Enter Physical Property - Solid - Without Secondary Physical State)
	Given I enter text: 7732-18-5 in the component search box
	Given I confirm the top result in the searchfields dropdown list has the following CAS number: 7732-18-5
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| CASNumber | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| 7732-18-5 | 100     | false               | false       |            |
	Given I navigate to the home page
	Then I delete the product: TestCase58097

@tfs_design
@ignore
@TestCase:58094
Scenario: [58094] Suppository, Laxative, Stool-Softener - RU000944
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC58094
	Given I delete all products with UPC Number: saved as UPC58094
	Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Suppository, Laxative, Stool-Softener
	Then I save the product information as: TestCase58094
	# Missing from TFS test case
	#Given I call Shared Step 57441 (Physical and Chemical Properties - Primary Physical Property - Liquid)
	Given I call Shared Step 57401 (Product Information - US only - No GHS, Not Direct Ship, Not PLP, Not GNFR > Continue - Happy Path)
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName       | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Magnesium citrate   | 15      | false               | false       |            |
		| Magnesium hydroxide | 15      | false               | false       |            |
		| Aqua                | 70      | false               | false       |            |
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I call Shared Step 57507 (Transportation Details 1- Not Regulated - Continue - Happy Path)
	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Walgreens
	Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC58094, container type: Plastic Container and size: 100
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I call Shared Step 60567 (Upload Product Label only)
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
		| Gloves                        | 340                      | 12                      | 20.5      | Clear      | Odorless | No data available | 5.0                   |
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: User added Comments Text 58094. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
	Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	And I call Shared Step 54796 (Purchase Summary)
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase58094

@tfs_design
@ignore
@TestCase:58081
Scenario: [58081] Nutritional Supplement - Solid - RU000619
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC58081
	Given I delete all products with UPC Number: saved as UPC58081
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Nutritional Supplement - Solid
	Given I call Shared Step 62678 (Product Information - US & Canada, No Child, No OSHA, NO Direct ship, No PL, No NGFR - Continue, Happy path)
	Given I call Shared Step 37857 (Enter Physical Property - Solid)
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Aqua          | 50      | false               | false       |            |
		| Vitamin A     | 10      | false               | false       |            |
		| Citric acid   | 30      | false               | false       |            |
		| Vitamin E     | 10      | false               | false       |            |
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: CVS
	Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC58081, container type: Plastic Container and size: 5.2621
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I call Shared Step 60567 (Upload Product Label only)
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient |
		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | 41.3005               |
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: User added Comments Text 58081. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
	Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)

@upctest
@TestCase:58604
Scenario: [58604] Condom - RU000937
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC58604
	Given I delete all products with UPC Number: saved as UPC58604
	Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Condom with or without Spermicide
	Then I save the product information as: TestCase58604
	Given I call Shared Step 60310 (Product Information - Without Child question)
	Given I call Shared Step 37857 (Enter Physical Property - Solid)
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Polyisoprene  | 90      | false               | false       |            |
		| Glucose       | 5       | false               | false       |            |
		| Aqua          | 5       | false               | false       |            |
	#Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Then I call Shared Step 132427 (Waste Classification Data- For OTC Products)
	Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: CVS
	Then I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC58604, container type: Plastic Container and size: 6
	Given I call Shared Step 60567 (Upload Product Label only)
	# Needed 'Additional Documents to Provide' Page step
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: User added Comments Text 58604. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Condom with or without Spermicide
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase58604

# Ignore execution in QA-Integration Environment as SHA Automation is set to OFF
# Created by Saikiran Chittampally
@TestCase:213910
Scenario: [213910] WERCSmart Portal and SHA Manager Test Flow for Product Type:  Grass Seed (RU000470)
	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC213910
	Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Grass Seed
	Then I save the product information as: TestCase213910
	Given I should see the Product Information Page
	Given I call Shared Step 214000 (Product Information - Pesticide= Not considered, Fertilizer=YES, SOLD=US, everything else = No - Continue)
	Then a Warning popup dialog should appear with the message: The ratio of Slow-Release Agent to Nitrogen will prohibit sale and use of this product during Pinellas County regional watershed (June 1 through September 30). This is informational only and will not restrict your registration to the Retailer.	
	And I see the following sections
		| Section                       |
		| Phosphates /Phosphorous (“P”) |
		| Nitrogen /Nitrates (“N”)      |
		| Potassium(“K”)                |
		| Slow-Release Agent            |
	Then I set the Phosphates /Phosphorous (“P”) field to: 22
	Then I set the Nitrogen /Nitrates (“N”) field to: 21
	Then I set the Potassium(“K”) field to: 4
	Then I set the Slow-Release Agent field to: 10.50
	Then I click continue
	Then a Warning popup dialog should appear with the message: The ratio of Slow-Release Agent to Nitrogen will prohibit sale and use of this product during Pinellas County regional watershed (June 1 through September 30). This is informational only and will not restrict your registration to the Retailer.
	Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Then I add the following ingredients:
		| ComponentName     | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Grass Seed        | 45      | false               | false       |            |
		| Calcium Carbonate | 50      | false               | false       |            |
		| Quartz            | 5       | false               | false       |            |
	Given I click continue
	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	And I call Shared Step 57507 (Transportation Details 1- Not Regulated - Continue - Happy Path)
	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Wal-Mart/SAM'S CLUB	
	Given In the Retailers tab, I select the first Vendor option for retailer: Wal-Mart/SAM'S CLUB
	Then I click continue
	Given I call Shared Step 87647 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC213910, container type: Plastic bag and size: 20 do not click continue
	And I confirm that retailer "WM" is present under the 'Destination Retailers' column in the UPC table
	Then I click continue
	And  I call Shared Step 78080 (Regulatory Documents to Provide - Upload OSHA SDS)
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Test
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Grass seed
	Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Then If purchase details are showing click confirm order
	Given I navigate to the landing page
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase213910)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Assigned Status for saved as: TestCase213910)
	Given I call Shared Step 120845 (WPS Studio - PD+ - change to MTR/CKLT for product saved as: TestCase213910)
	Given I call Shared Step 209526 (WPS Studio - PD+ - set all data and publish using rule and doc queue - CKLT and MTR only) for product saved as: TestCase213910
	Given I call Shared Step 231412 I add the UsageType: PVAL: Product Value with Datacode FERTK with data: Nitrogen / Nitrates (“N”) to the Section - Applicable Only to Type of Product: GRASS SEED
	Given I confirm data code: Nitrogen / Nitrates (“N”) with value: 4 added
	Given I remove the Datacode: Nitrogen / Nitrates (“N”) to the Section - Applicable Only to Type of Product:  GRASS SEED
	Given I confirm data code: Nitrogen / Nitrates (“N”) with value: 4 removed
