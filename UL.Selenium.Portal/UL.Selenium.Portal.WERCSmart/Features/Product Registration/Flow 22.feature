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
@run_Flow22
@NewProduct
Feature: Flow 22

@tfsdesign
@TestCase:60544
Scenario: [60544] Weld-Through Primer - Aerosol - RU001050
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC60544
	Given I delete all products with UPC Number: saved as UPC60544
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Weld-Through Primer - Aerosol
	Then I save the product information as: TestCase60544
	#Given I call Shared Step 57528 (Physical and Chemical Properties - Aerosol Only - add data - Continue - Happy Path)
	Given I call Shared Step 60310 (Product Information - Without Child question)
	Given I call Shared Step 57111 (Enter Product Data for Physical State - Aerosol only)
	Given I call Shared Step 69557 (Enter Ingredients for Aerosol Propellent)
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	Given I call Shared Step 65705 (Transportation - DOT UN step - Enter UN1950, select Aerosols,  2.1, None, add technical name, Click Continue)
	Given I call Shared Step 62710 (Confirm VOC OTC/CARB heading and select No to FIRST QUESTION ONLY - Happy Path)
	Given I call Shared Step 60552 (VOC - AERO Question (ozone) enter value - Click Continue - Happy Path): 0.5
	Given I click continue
	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Staples
	Then I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC60544, container type: Aerosol Can - Metal and size: 1
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I call Shared Step 60567 (Upload Product Label only) for section: Volatile Organic Compounds
	And in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient | Product's Dispensing Method |
		| Mask                          | 150                      | 44                      | 10.7      | White      | Floral | No data available | 12                    | Aerosol                     |
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: User added Comments Text 60544. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Weld-Through Primer - Aerosol
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase60544


@TestCase:60545
Scenario: [60545] Photograph Coating - Aerosol - RU001067
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC60545
	Given I delete all products with UPC Number: saved as UPC60545
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Photograph Coating - Aerosol
	Then I save the product information as: TestCase60545
	Given I call Shared Step 60756 (Product Information with Country and every option)
	Given I call Shared Step 57111 (Enter Product Data for Physical State - Aerosol only)
	Given I click continue
	Then I should see an error message: ALERT! The ingredient table does not include a compressed gas (Bag-On-Valve) or a propellant. Please update your ingredients to include the propellant before proceeding.
	Given I call Shared Step 69557 (Enter Ingredients for Aerosol Propellent)
	#Then I should not see an error message: ALERT! The ingredient table does not include a compressed gas (Bag-On-Valve) or a propellant. Please update your ingredients to include the propellant before proceeding.
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I call Shared Step 57980 (Transportation Details - Yes only option - Select IMDG, Fully regulated - Continue - Happy Path)
	Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)
	And I call Shared Step 62710 (Confirm VOC OTC/CARB heading and select No to FIRST QUESTION ONLY - Happy Path)
	Given I call Shared Step 60552 (VOC - AERO Question (ozone) enter value - Click Continue - Happy Path): 0.5
	Given I click continue
	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Staples
	Then I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC60545, container type: Aerosol Can and size: 33
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I call Shared Step 60567 (Upload Product Label only) for section: Volatile Organic Compounds
	And in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient | Product's Dispensing Method |
		| Mask                          | 150                      | 44                      | 10.7      | White      | Floral | No data available | 12                    | Aerosol                     |
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: User added Comments Text 60545. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Photograph Coating - Aerosol
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase60545


@TestCase:60546
Scenario: [60546] Glass Coating - Aerosol - RU001037
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC60546
	Given I delete all products with UPC Number: saved as UPC60546
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Glass Coating - Aerosol
	Then I save the product information as: TestCase60546
	Given I call Shared Step 60310 (Product Information - Without Child question)
	Given I call Shared Step 57111 (Enter Product Data for Physical State - Aerosol only)
	Given I click continue
	Then I should see an error message: ALERT! The ingredient table does not include a compressed gas (Bag-On-Valve) or a propellant. Please update your ingredients to include the propellant before proceeding.
	Given I call Shared Step 69557 (Enter Ingredients for Aerosol Propellent)
	#Then I should not see an error message: ALERT! The ingredient table does not include a compressed gas (Bag-On-Valve) or a propellant. Please update your ingredients to include the propellant before proceeding.
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)
	Given I call Shared Step 62710 (Confirm VOC OTC/CARB heading and select No to FIRST QUESTION ONLY - Happy Path)
	Given I call Shared Step 60552 (VOC - AERO Question (ozone) enter value - Click Continue - Happy Path): 0.5
	Given I call Shared Step 57801 (Confirm VOC Summary step shown, Confirm VOC analysis date is shown - Happy Path)
	Given in the Volatile Organic Compound Summary page I click Continue
	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Dick's Sporting Goods
	Then I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC60546, container type: Aerosol Can and size: 9.99
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I call Shared Step 60567 (Upload Product Label only) for section: Volatile Organic Compounds
	And in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient | Product's Dispensing Method |
		| Mask                          | 150                      | 44                      | 10.7      | White      | Floral | No data available | 12                    | Aerosol                     |
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: User added Comments Text. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Glass Coating - Aerosol
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase60546

@TestCase:60547
Scenario: [60547] Corrosion Resistant Brass, Bronze or Copper Coating - Aerosol - RU001043
	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC60547
	Given I delete all products with UPC Number: saved as UPC60547
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Corrosion Resistant Brass, Bronze or Copper Coating - Aerosol
	Then I save the product information as: TestCase60547
	#Given I call Shared Step 57528 (Physical and Chemical Properties - Aerosol Only - add data - Continue - Happy Path)
	Given I call Shared Step 60756 (Product Information with Country and every option)
	Then I call Shared Step 213391(Physical and Chemical Properties (Applicable Only to Flow 6-A Type of Products) - Primary Physical State (AEROSOL ONLY) / Secondary Physical State (ANY)):
		| Section                    | do not have exact data | Value                                                            |
		| Primary Physical State     |                        | Aerosol                                                          |
		| Secondary Physical State   |                        | Solid spray                                                      |
		| pH                         |                        | 12                                                               |
		| has a flammable propellant |                        | This product is classified as a D003 Hazardous Waste under RCRA. |
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName			    | Percent	| PublicallyDisclosed | TradeSecret | PublicName |
		| Air					    | 90		| false               | false       |            |
		| Oxygen				    | 3.89      | false               | false       |            |
		| 1-Butene				    | 3.85      | false               | false       |            |
		| Hydrocarbon, propellant   | 3.89		| false               | false       |            |
	Then I call Shared Step 57571b (Enter Regulatory Information - Not Prop 65):
		| TSCA																		                  | Prop 65 |
		| This product is subject to and complies with TSCA chemical Inventory listing requirements.  | No      |
	Then I call Shared Step 57528 (Physical and Chemical Properties - Aerosol Only - add data - Continue - Happy Path)
	#Given I call Shared Step 57111 (Enter Product Data for Physical State - Aerosol only)
	#Given I click continue
	#Then I should see an error message: ALERT! The ingredient table does not include a compressed gas (Bag-On-Valve) or a propellant. Please update your ingredients to include the propellant before proceeding.
	#Given I call Shared Step 69557 (Enter Ingredients for Aerosol Propellent)
	#Then I should not see an error message: ALERT! The ingredient table does not include a compressed gas (Bag-On-Valve) or a propellant. Please update your ingredients to include the propellant before proceeding.
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName									  | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Air											  | 90      | false               | false       |            |
		| Oxygen									      | 3.89    | false               | false       |            |
		| 1-Butane									      | 3.85    | false               | false       |            |
		| Hydrocarbons, C3-4-rich, petroleum distillates  | 3.89    | false               | false       |            |
	Then I call Shared Step 57637 (Regulatory Information 1 - TSCA & CEPA shown, No to PROP 65 - Continue - Happy Path)
	#Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I call Shared Step 57980 (Transportation Details - Yes only option - Select IMDG, Fully regulated - Continue - Happy Path)
	Then I set the UN Number option to: UN1950
	Then in the International Marine (IMDG) Classification page I click Continue
	#Given I call Shared Step 57981 (Transportation Details - UN Number Water (IMDG) - Enter UN Number and select other data - Continue - Happy Path) : 1950
	Given I call Shared Step 62710 (Confirm VOC OTC/CARB heading and select No to FIRST QUESTION ONLY - Happy Path)
	Given I call Shared Step 60552 (VOC - AERO Question (ozone) enter value - Click Continue - Happy Path): 1
	Given I click continue
	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Staples
	Then I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC60547, container type: Aerosol Can - Metal and size: 33
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I call Shared Step 60567 (Upload Product Label only) for section: Volatile Organic Compounds
	And in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient | Product's Dispensing Method |
		| Mask                          | 150                      | 44                      | 10.7      | White      | Floral | No data available | 12                    | Aerosol                     |
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: User added Comments Text 60547. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Corrosion Resistant Brass, Bronze or Copper Coating - Aerosol
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase60547
