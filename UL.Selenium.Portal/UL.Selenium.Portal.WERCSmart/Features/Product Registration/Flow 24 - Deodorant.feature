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
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:NewProduct
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:Product
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:ProductInformation
@PhysicalAndChemicalProp
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:InventoryStatusProp65
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:Retailer
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:AdditionalDocumentsToProvide
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:OptionalComments
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:RegulatoryDocumentsToProvide
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:TheProduct
@GTINAndUPC
@Ingredients
@RegulatoryInformation3
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:TransportationDetails1
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:VOC_OzoneTransportCommission
@run_Flow24_Deodorant
@StepsPrototype
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:DataAcceptance

Feature: Flow 24 - Deodorant

@ignore
@TestCase:60617
Scenario: [60617] Deodorant - Non-Aerosol - RU000760(Liquid)
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC60617
	Given I delete all products with UPC Number: saved as UPC60617
	#Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Then in the New Product page, I click Continue

	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Deodorant - Non-aerosol
	Then I save the product information as: TestCase60617
	#Given I call Shared Step 57401 (Product Information - US only - No GHS, Not Direct Ship, Not PLP, Not GNFR > Continue - Happy Path)
	Given I should see the Product Information Page
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue
	And I call Shared Step 57441 (Physical and Chemical Properties - Primary Physical Property - Liquid)
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName    | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Triclosan        | 24.94   | false               | false       |            |
		| Hydrogen         | 30.2    | false               | false       |            |
		| Propylene Glycol | 19.8    | false               | false       |            |
		| Butane           | 25.06   | false               | false       |            |
	#Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I should see the Inventory Status, Prop 65 (US) Page
	Then In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	Then In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page I click Continue

	Then I confirm the Label Information section on the Regulatory Information 3 page contains a link for: Nutritional and Supplement Labels
	#Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
	Given I should see the Regulatory Information 3 Page
	Then In the Regulatory Information 3 Section, the statement 'Based on the product's recommended use and formulation, this is a possible pharmaceutical waste for California.  Please complete the additional question below to ensure proper classification of this product for the retailer(s).' is displayed
	Then In the Regulatory Information 3 Section, in section: 'Refer to your Product Label.  From the options, select those that appear on the Label.' displayed options are:
	| Option                 |
	| Drug Facts Panel       |
	| Supplement Facts Panel |
	| Nutrition Facts Panel  |
	| None of the Above      |
	Then In the Regulatory Information 3 Section, in section: 'Refer to your Product Label.  From the options, select those that appear on the Label.' click the checkbox option: None of the Above 
	Then In the Regulatory Information 3 Section, the following link: Nutritional and Supplement Labels should be displayed
	Then In the Regulatory Information 3 Section, the following link: Dietary Supplements Label should be displayed
	Then In the Regulatory Information 3 Section, the following link: OTC Drug Facts Label (may include Active Ingredient) should be displayed
	Then in the Regulatory Information 3 page I click Continue
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
#	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Staples
	Then I should be on the Retailer Page
	And In the Retailer Section, click 'Add Retailers' button
	And In the Select Retailers window, select retailer: Staples
	And In the Select Retailers window, click 'Done' button
	Then in the Retailer page, I click Continue

	Then I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC60617, container type: Cardboard and size: 14
	#Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
	Then in the Regulatory Documents to Provide page I click Continue

	Given I call Shared Step 60567 (Upload Product Label only) for section: Volatile Organic Compounds
	And in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance               | Odor  | Odor Threshold    | Partition Coefficient |
		| Goggles                       | 66                       | 51.5                    | 10.92     | Clear to hazy, colorless | Berry | No data available | 2                     |
	#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	#And I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given I should see the Data Acceptance Page
	Then In the Data Acceptance Section, check 'Agreed' checkbox
	Then In the Data Acceptance Section, click 'Accept' button

	And I call Shared Step 54796 (Purchase Summary)

@tfs_design
@ignore
@TestCase:60637
Scenario: [60637] Summary View - Hyperlink for Document Uploads
	Given I generate a random UPC number and save as: UPC60637
	And I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	# And I Enter "Deodorant - Non-Aerosol" in Type of Product smart search field
	And I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Deodorant - Non-Aerosol
	#Given I call Shared Step 60310 (Product Information - Without Child question)
	Given I should see the Product Information Page
	Then In the Product Information Section, set the option in section: 'Which best describes your product, including when FIFRA 25(b) Exempt' to: Product is not a pesticide and does not make or imply a pesticidal claim on the labeling or in the product description (ex. kills, sterilizes, disinfects, sanitizes, antimicrobial)
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Given in the Product Information page I click Continue

	And I call Shared Step 37857 (Enter Physical Property - Solid) with the following inputs:
		| Water Solubility     | Secondary Physical State |
		| Dispersible | Solid                    |
	And I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName    | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Sodium hydroxide | 80      | false               | false       |            |
		| Propylene Glycol | 5       | false               | false       |            |
		| Water            | 15      | false               | false       |            |
	#And I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I should see the Inventory Status, Prop 65 (US) Page
	Then In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	Then In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page I click Continue

	#Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
	Given I should see the Regulatory Information 3 Page
	Then In the Regulatory Information 3 Section, the statement 'Based on the product's recommended use and formulation, this is a possible pharmaceutical waste for California.  Please complete the additional question below to ensure proper classification of this product for the retailer(s).' is displayed
	Then In the Regulatory Information 3 Section, in section: 'Refer to your Product Label.  From the options, select those that appear on the Label.' displayed options are:
	| Option                 |
	| Drug Facts Panel       |
	| Supplement Facts Panel |
	| Nutrition Facts Panel  |
	| None of the Above      |
	Then In the Regulatory Information 3 Section, in section: 'Refer to your Product Label.  From the options, select those that appear on the Label.' click the checkbox option: None of the Above 
	Then In the Regulatory Information 3 Section, the following link: Nutritional and Supplement Labels should be displayed
	Then In the Regulatory Information 3 Section, the following link: Dietary Supplements Label should be displayed
	Then In the Regulatory Information 3 Section, the following link: OTC Drug Facts Label (may include Active Ingredient) should be displayed
	Then in the Regulatory Information 3 page I click Continue
	And I call Shared Step 57506 (Transportation Details 1 - Regulated for Transport(No) - Exemption(Random) - Continue - Happy Path)
	#See Transport 2 page
	And I call Shared Step 62710 (Confirm VOC OTC/CARB heading and select No to FIRST QUESTION ONLY - Happy Path)
	And I call Shared Step 60631 (VOC - HVOC and MVOC - add values - Continue - Happy Path)
	And I call Shared Step 57801 (Confirm VOC Summary step shown, Confirm VOC analysis date is shown - Happy Path)
	#Need to click continue here
	#And I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: (.*)
	Given I should see the Retailer Page
	Then In the Retailer Section, click 'Add Retailers' button
	Then In the Select Retailers window, select retailer: Amazon
	Then In the Select Retailers window, click 'Done' button
	Then in the Retailer page I click Continue

	And I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC60637, container type: (.*) and size: (.*)
	#And I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
	Then in the Regulatory Documents to Provide page I click Continue

	And I call Shared Step 60567 (Upload Product Label only) for section: Volatile Organic Compounds
	And in the Optional Reports and Documents Available for Purchase page I click Continue
	And I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor  | Odor Threshold    | Partition Coefficient |
		| Mask                          | 120                      | 70.5                    | 5         | Cloudy     | Fresh | No data available | 10                    |
	#And I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Test Comment
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	#And I Click the Summary button the the Data Acceptance screen
	#And I Click the View button on the Summary screen to view the uploaded document
	#And I Confirm the link opens the document that was uploaded in Step 17
	#And I Click the "X" to close the document popup
	#And I Click the hyperlink for uploaded documents on the Summary screen
	#And I Confirm the link opens the document that was uploaded in Step 17
	#And I Click the "X" to close the documentpopup
	#And I Click the "X" to close the Summary screen
	And I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase60637

@ignore
#Removed from regression 2023/11
@TestCase:60619
Scenario: [60619] Deodorant - Aerosol - RU000758
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	# Test Setup - Generating + Saving UPC Number and ensuring no duplicates exist
	Given I generate a random UPC number and save as: UPC60619
	#Given I delete all products with UPC Number: saved as UPC60619
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Deodorant - Aerosol
	Then I save the product information as: TestCase60619
	#Given I call Shared Step 60310 (Product Information - Without Child question)
	Given I should see the Product Information Page
	Then In the Product Information Section, set the option in section: 'Which best describes your product, including when FIFRA 25(b) Exempt' to: Product is not a pesticide and does not make or imply a pesticidal claim on the labeling or in the product description (ex. kills, sterilizes, disinfects, sanitizes, antimicrobial)
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Given in the Product Information page I click Continue

	Given I call Shared Step 57528 (Physical and Chemical Properties - Aerosol Only - add data - Continue - Happy Path)	
	Given I click continue
	Then I should see an error message: ALERT! The ingredient table does not include a compressed gas (Bag-On-Valve) or a propellant. Please update your ingredients to include the propellant before proceeding.
	Given I call Shared Step 69557 (Enter Ingredients for Aerosol Propellent)
	#Then I should not see an error message: ALERT! The ingredient table does not include a compressed gas (Bag-On-Valve) or a propellant. Please update your ingredients to include the propellant before proceeding.
	#Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I should see the Inventory Status, Prop 65 (US) Page
	Then In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	Then In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page I click Continue

	#Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
	Given I should see the Regulatory Information 3 Page
	Then In the Regulatory Information 3 Section, the statement 'Based on the product's recommended use and formulation, this is a possible pharmaceutical waste for California.  Please complete the additional question below to ensure proper classification of this product for the retailer(s).' is displayed
	Then In the Regulatory Information 3 Section, in section: 'Refer to your Product Label.  From the options, select those that appear on the Label.' displayed options are:
	| Option                 |
	| Drug Facts Panel       |
	| Supplement Facts Panel |
	| Nutrition Facts Panel  |
	| None of the Above      |
	Then In the Regulatory Information 3 Section, in section: 'Refer to your Product Label.  From the options, select those that appear on the Label.' click the checkbox option: None of the Above 
	Then In the Regulatory Information 3 Section, the following link: Nutritional and Supplement Labels should be displayed
	Then In the Regulatory Information 3 Section, the following link: Dietary Supplements Label should be displayed
	Then In the Regulatory Information 3 Section, the following link: OTC Drug Facts Label (may include Active Ingredient) should be displayed
	Then in the Regulatory Information 3 page I click Continue
	#Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	Given I should see the Transportation Details 1 Page
	Then In the Transportation Details 1 Section, set the option in section: 'Product is Regulated for Transport': to: Yes
	Then In the Transportation Details 1 Section, set the option in section: 'Select all modes of transport that you've classified the product for': to: DOT
	Then In the Transportation Details 1 Section, set the option for DOT mode of transport to: Shipping with limited quantity
	Then in the Transportation Details 1 page I click Continue

	Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)
	#Given I call Shared Step 49621 (Volatile Organic Compounds (VOC) for OTC and CARB - No)
	Given I call Shared Step 62710 (Confirm VOC OTC/CARB heading and select No to FIRST QUESTION ONLY - Happy Path)
	Given I call Shared Step 60631 (VOC - HVOC and MVOC - add values - Continue - Happy Path)
	Given I click continue
#	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Staples
	Then I should be on the Retailer Page
	And In the Retailer Section, click 'Add Retailers' button
	And In the Select Retailers window, select retailer: Staples
	And In the Select Retailers window, click 'Done' button
	Then in the Retailer page, I click Continue

	Then I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC60619, container type: Aerosol Can and size: 33
	#Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
	Then in the Regulatory Documents to Provide page I click Continue

	Given I call Shared Step 60567 (Upload Product Label only) for section: Volatile Organic Compounds
	And in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient | Product's Dispensing Method |
		| Mask                          | 150                      | 44                      | 10.7      | White      | Floral | No data available | 12                    | Aerosol                     |
	#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: User added Comments Text 60619. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Deodorant - Aerosol
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase60619



@TestCase:159880
Scenario: [159880] Antiperspirant for Women (Non-Aerosol) RU001256

Given I log in with the account saved in TReVor as: ProductAccount

    # ====== Given I call Shared Step 57408 (Create a New Registration via Register New Product icon) ====== #
    Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Given in the New Product page I click Continue

	# ====== Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Antiperspirant for Women (Non-Aerosol) ====== #
	Given I should see the The Product Page
	Given In the Product Section, set the option in section: 'Type of Product (select)' to: Antiperspirants - Non-aerosol
	Given in the The Product page I click Continue
	Then I save the product information as: TestCase159880

    # ======Given I call Shared Step 57401 (Product Information - US only - No GHS, Not Direct Ship, Not PLP, Not GNFR > Continue - Happy Path) ====== #
    Given I should see the Product Information Page
	Given In the Product Information Section, set the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' to select: United States
	Given In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Given In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Given In the Product Information Section, set the option in section: 'Product is a Retailer's Private Label or Brand' to: No
	Given In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Given in the Product Information page I click Continue

	Given In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
	Given in the Regulatory Documents To Provide page I click Continue

	Given I save the product information as: TestProduct
	Given in the Product Characteristics page I click Continue
	And Primary Physical State should be showing the error messages: This is a required field.
	Given In the Physical and Chemical Properties Section, set the option in section: 'Primary Physical State' to: Solid
	Given In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
	Given In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Given In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Dispersible
	Given I click continue

	#Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Water
	And I should see the Ingredients Page
	Then In the Ingredients section, add the following ingredients:
		| SearchType     | SearchText | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
		| component name | Water      |  100    | false                | false        |   Water    |
	And in the Ingredients page I click Continue

	# ====== Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path) ====== #
	Given I should see the Inventory Status, Prop 65 (US) Page
	Given In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	Given In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
    Given in the Inventory Status, Prop 65 (US) page I click Continue

	Given I should see the Regulatory Information 3 Page
	Given In the Regulatory Information 3 Section, in section: 'Refer to your Product Label.  From the options, select those that appear on the Label.' click the checkbox option: None of the Above
	Given in the Regulatory Information 3 page I click Continue

	# ====== Given I call Shared Step 57507 (Transportation Details 1- Not Regulated - Continue - Happy Path) ====== #
	Given I should see the Transportation Details 1 Page
	Given In the Transportation Details 1 Section, set the option in section: 'Product is Regulated for Transport': to: Not Regulated
	Given in the Transportation Details 1 page I click Continue

Given in the Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB) page I click Continue
Given In the VOC - Ozone Transport Commission Section, set the option in section: 'Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations.': to: No
And In the VOC - Ozone Transport Commission Section, set the option in section: HVOC (high volatile organic compound) content as weight percent of the total formulation should be showing the error message: This is a required field.
And In the VOC - Ozone Transport Commission Section, set the option in section: MVOC (medium volatile organic compound) content as weight percentage of the total formulation should be showing the error message: This is a required field.
Given In the VOC - Ozone Transport Commission Section, set the option in section: 'HVOC (high volatile organic compound) content as weight percent of the total formulation': to: abc
And In the VOC - Ozone Transport Commission Section, set the option in section: HVOC (high volatile organic compound) content as weight percent of the total formulation should be showing the error message: Enter a valid number
And In the VOC - Ozone Transport Commission Section, set the option in section: HVOC (high volatile organic compound) content as weight percent of the total formulation should be showing the error message: Invalid number. 2 decimal places allowed
Given In the VOC - Ozone Transport Commission Section, set the option in section: 'HVOC (high volatile organic compound) content as weight percent of the total formulation': to: !@
And In the VOC - Ozone Transport Commission Section, set the option in section: HVOC (high volatile organic compound) content as weight percent of the total formulation should be showing the error message: Enter a valid number
And In the VOC - Ozone Transport Commission Section, set the option in section: HVOC (high volatile organic compound) content as weight percent of the total formulation should be showing the error message: Invalid number. 2 decimal places allowed
Given In the VOC - Ozone Transport Commission Section, set the option in section: 'HVOC (high volatile organic compound) content as weight percent of the total formulation': to: 123.456
And In the VOC - Ozone Transport Commission Section, set the option in section: HVOC (high volatile organic compound) content as weight percent of the total formulation should be showing the error message: Invalid number. 2 decimal places allowed
Given In the VOC - Ozone Transport Commission Section, set the option in section: 'HVOC (high volatile organic compound) content as weight percent of the total formulation': to: 12.34
Given In the VOC - Ozone Transport Commission Section, set the option in section: 'MVOC (medium volatile organic compound) content as weight percentage of the total formulation': to: abc
And In the VOC - Ozone Transport Commission Section, set the option in section: MVOC (medium volatile organic compound) content as weight percentage of the total formulation should be showing the error message: Enter a valid number
And In the VOC - Ozone Transport Commission Section, set the option in section: MVOC (medium volatile organic compound) content as weight percentage of the total formulation should be showing the error message: Invalid number. 2 decimal places allowed
Given In the VOC - Ozone Transport Commission Section, set the option in section: 'MVOC (medium volatile organic compound) content as weight percentage of the total formulation': to: !@
And In the VOC - Ozone Transport Commission Section, set the option in section: MVOC (medium volatile organic compound) content as weight percentage of the total formulation should be showing the error message: Enter a valid number
And In the VOC - Ozone Transport Commission Section, set the option in section: MVOC (medium volatile organic compound) content as weight percentage of the total formulation should be showing the error message: Invalid number. 2 decimal places allowed
Given In the VOC - Ozone Transport Commission Section, set the option in section: 'MVOC (medium volatile organic compound) content as weight percentage of the total formulation': to: 123.456
And In the VOC - Ozone Transport Commission Section, set the option in section: MVOC (medium volatile organic compound) content as weight percentage of the total formulation should be showing the error message: Invalid number. 2 decimal places allowed
Given In the VOC - Ozone Transport Commission Section, set the option in section: 'MVOC (medium volatile organic compound) content as weight percentage of the total formulation': to: 12.34

#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestProduct
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestProduct
