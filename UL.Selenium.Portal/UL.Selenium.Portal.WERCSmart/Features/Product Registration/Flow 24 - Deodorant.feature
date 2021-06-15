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
@run_Flow24_Deodorant
Feature: Flow 24 - Deodorant

@ScenarioId:667
Scenario: [60617] Deodorant - Non-Aerosol - RU000760(Liquid)
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC60617
	Given I delete all products with UPC Number: saved as UPC60617
	Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Deodorant - Non-aerosol
	Then I save the product information as: TestCase60617
	Given I call Shared Step 57401 (Product Information - US only - No GHS, Not Direct Ship, Not PLP, Not GNFR > Continue - Happy Path)
	And I call Shared Step 57441 (Physical and Chemical Properties - Primary Physical Property - Liquid)
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName    | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Triclosan        | 24.94   | false               | false       |            |
		| Hydrogen         | 30.2    | false               | false       |            |
		| Propylene Glycol | 19.8    | false               | false       |            |
		| Butane           | 25.06   | false               | false       |            |
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Then I confirm the Label Information section on the Regulatory Information 3 page contains a link for: Nutritional and Supplement Labels
	Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
	And I call Shared Step 57507 (Transportation Details 1- Not Regulated - Continue - Happy Path)
	Given I call Shared Step 62710 (Confirm VOC OTC/CARB heading and select No to FIRST QUESTION ONLY - Happy Path)
	Given I see the following sections
		| Section                                                                                          |
		| HVOC (high volatile organic compound) content as weight percent of the total formulation         |
		| MVOC (microbial volatile organic compound) content as weight percentage of the total formulation |
	Given in the New Product page I click Continue
	Then HVOC (high volatile organic compound) content as weight percent of the total formulation should be showing the error messages: This is a required field.
	Then MVOC (microbial volatile organic compound) content as weight percentage of the total formulation should be showing the error messages: This is a required field.
	Given I call Shared Step 60631 (VOC - HVOC and MVOC - add values - Continue - Happy Path)
	Then HVOC (high volatile organic compound) content as weight percent of the total formulation should not be showing the error messages: This is a required field.
	Then MVOC (microbial volatile organic compound) content as weight percentage of the total formulation should not be showing the error messages: This is a required field.
	Then I should see the Volatile Organic Compound Summary Page
	And in the New Product page I click Continue
	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Staples
	Then I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC60617, container type: Cardboard and size: 14
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I call Shared Step 60567 (Upload Product Label only) for section: Volatile Organic Compounds
	And in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance               | Odor  | Odor Threshold    | Partition Coefficient |
		| Goggles                       | 66                       | 51.5                    | 10.92     | Clear to hazy, colorless | Berry | No data available | 2                     |
	Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: test
	And I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	And I call Shared Step 54796 (Purchase Summary)

@tfs_design
Scenario: [60637] Summary View - Hyperlink for Document Uploads
	Given I generate a random UPC number and save as: UPC60637
	And I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	# And I Enter "Deodorant - Non-Aerosol" in Type of Product smart search field
	And I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Deodorant - Non-Aerosol
	Given I call Shared Step 60310 (Product Information - Without Child question)
	And I call Shared Step 37857 (Enter Physical Property - Solid) with the following inputs:
		| Water Solubility     | Secondary Physical State |
		| Soluble in hot water | Solid                    |
	And I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName    | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Sodium hydroxide | 80      | false               | false       |            |
		| Propylene Glycol | 5       | false               | false       |            |
		| Water            | 15      | false               | false       |            |
	And I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	And I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
	And I call Shared Step 57506 (Transportation Details 1 - Regulated for Transport(No) - Exemption(Random) - Continue - Happy Path)
	And I call Shared Step 62710 (Confirm VOC OTC/CARB heading and select No to FIRST QUESTION ONLY - Happy Path)
	And I call Shared Step 60631 (VOC - HVOC and MVOC - add values - Continue - Happy Path)
	And I call Shared Step 57801 (Confirm VOC Summary step shown, Confirm VOC analysis date is shown - Happy Path)
	And I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: (.*)
	And I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC60637, container type: (.*) and size: (.*)
	And I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	And I call Shared Step 60567 (Upload Product Label only) for section: Volatile Organic Compounds
	And in the Optional Reports and Documents Available for Purchase page I click Continue
	And I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor  | Odor Threshold    | Partition Coefficient |
		| Mask                          | 120                      | 70.5                    | 5         | Cloudy     | Fresh | No data available | 10                    |
	And I call Shared Step 57883 (Comments - Happy Path) and enter the comment: Test Comment
	#And I Click the Summary button the the Data Acceptance screen
	#And I Click the View button on the Summary screen to view the uploaded document
	#And I Confirm the link opens the document that was uploaded in Step 17
	#And I Click the "X" to close the document popup
	#And I Click the hyperlink for uploaded documents on the Summary screen
	#And I Confirm the link opens the document that was uploaded in Step 17
	#And I Click the "X" to close the documentpopup
	#And I Click the "X" to close the Summary screen
	And I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase60637

@tfs_design
Scenario: [60619] Deodorant - Aerosol - RU000758
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	# Test Setup - Generating + Saving UPC Number and ensuring no duplicates exist
	Given I generate a random UPC number and save as: UPC60619
	#Given I delete all products with UPC Number: saved as UPC60619
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Deodorant - Aerosol
	Then I save the product information as: TestCase60619
	Given I call Shared Step 60310 (Product Information - Without Child question)
	Given I call Shared Step 57528 (Physical and Chemical Properties - Aerosol Only - add data - Continue - Happy Path)	
	Given I click continue
	Then I should see an error message: ALERT! The ingredient table does not include a compressed gas (Bag-On-Valve) or a propellant. Please update your ingredients to include the propellant before proceeding.
	Given I call Shared Step 69557 (Enter Ingredients for Aerosol Propellent)
	#Then I should not see an error message: ALERT! The ingredient table does not include a compressed gas (Bag-On-Valve) or a propellant. Please update your ingredients to include the propellant before proceeding.
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
	Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)
	#Given I call Shared Step 49621 (Volatile Organic Compounds (VOC) for OTC and CARB - No)
	Given I call Shared Step 62710 (Confirm VOC OTC/CARB heading and select No to FIRST QUESTION ONLY - Happy Path)
	Given I call Shared Step 60631 (VOC - HVOC and MVOC - add values - Continue - Happy Path)
	Given I click continue
	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Staples
	Then I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC60619, container type: Aerosol Can and size: 33
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I call Shared Step 60567 (Upload Product Label only) for section: Volatile Organic Compounds
	And in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient | Product's Dispensing Method |
		| Mask                          | 150                      | 44                      | 10.7      | White      | Floral | No data available | 12                    | Aerosol                     |
	Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: User added Comments Text 60619. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Deodorant - Aerosol
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase60619



	@ScenarioId:10716
Scenario: [159880] Antiperspirant for Women (Non-Aerosol) RU001256

Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Antiperspirant for Women (Non-Aerosol)
Given I save the product information as: TestProduct
Given in the Product Characteristics page I click Continue
And Primary Physical State should be showing the error messages: This is a required field.
Given I set the Primary Physical State option to: Solid
Given I set the Secondary Physical State option to: Solid
Given I set the When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5? option to: No
Given I set the Select the best Water Solubility description option to: Decomposes
Given I click continue
Given I call Shared Step 57401 (Additional Product Information - US only - No GHS, Not Direct Ship, Not PLP, Not GNFR > Continue - Happy Path)
Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Water
Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Given I call Shared Step 57507 (Transportation Details 1- Not Regulated - Continue - Happy Path)
Given in the Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB) page I click Continue
Given I set the Product has been granted an Alternative Control Plan option to: No
And HVOC (high volatile organic compound) content as weight percent of the total formulation should be showing the error messages: This is a required field.
And MVOC (microbial volatile organic compound) content as weight percentage of the total formulation should be showing the error messages: This is a required field.
Given I set the HVOC (high volatile organic compound) content as weight percent of the total formulation field to: abc
And HVOC (high volatile organic compound) content as weight percent of the total formulation should be showing the error messages: Enter a valid number
And HVOC (high volatile organic compound) content as weight percent of the total formulation should be showing the error messages: Invalid number. 2 decimal places allowed
Given I set the HVOC (high volatile organic compound) content as weight percent of the total formulation field to: !@
And HVOC (high volatile organic compound) content as weight percent of the total formulation should be showing the error messages: Enter a valid number
And HVOC (high volatile organic compound) content as weight percent of the total formulation should be showing the error messages: Invalid number. 2 decimal places allowed
Given I set the HVOC (high volatile organic compound) content as weight percent of the total formulation field to: 123.456
And HVOC (high volatile organic compound) content as weight percent of the total formulation should be showing the error messages: Invalid number. 2 decimal places allowed
Given I set the HVOC (high volatile organic compound) content as weight percent of the total formulation field to: 12.34
Given I set the MVOC (microbial volatile organic compound) content as weight percentage of the total formulation field to: abc
And MVOC (microbial volatile organic compound) content as weight percentage of the total formulation should be showing the error messages: Enter a valid number
And MVOC (microbial volatile organic compound) content as weight percentage of the total formulation should be showing the error messages: Invalid number. 2 decimal places allowed
Given I set the MVOC (microbial volatile organic compound) content as weight percentage of the total formulation field to: !@
And MVOC (microbial volatile organic compound) content as weight percentage of the total formulation should be showing the error messages: Enter a valid number
And MVOC (microbial volatile organic compound) content as weight percentage of the total formulation should be showing the error messages: Invalid number. 2 decimal places allowed
Given I set the MVOC (microbial volatile organic compound) content as weight percentage of the total formulation field to: 123.456
And MVOC (microbial volatile organic compound) content as weight percentage of the total formulation should be showing the error messages: Invalid number. 2 decimal places allowed
Given I set the MVOC (microbial volatile organic compound) content as weight percentage of the total formulation field to: 12.34
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestProduct
