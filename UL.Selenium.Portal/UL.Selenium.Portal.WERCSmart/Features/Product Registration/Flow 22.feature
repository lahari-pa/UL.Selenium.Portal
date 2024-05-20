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
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:TheProduct
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:ProductInformation
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:RegulatoryDocumentsToProvide
@PhysicalAndChemicalProp
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:InventoryStatusProp65
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:Retailer
@GTINAndUPC
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:AdditionalDocumentsToProvide
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:OptionalComments
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:FuelContainerRegulatoryDetails
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:Product
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:ProductInformation
@PhysicalAndChemicalProp
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:InventoryStatusProp65
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:Retailer
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:AdditionalDocumentsToProvide
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:OptionalComments
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:RegulatoryDocumentsToProvide
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:TheProduct
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:AdditionalDocumentsToProvide
@GTINAndUPC
@run_Flow22
@NewProduct
@StepsPrototype
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:TransportationDetails1

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
	#Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I should see the Inventory Status, Prop 65 (US) Page
	Then In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	Then In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page I click Continue

	#Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	Given I should see the Transportation Details 1 Page
	Then In the Transportation Details 1 Section, set the option in section: 'Product is Regulated for Transport': to: Yes
	Then In the Transportation Details 1 Section, set the option in section: 'Select all modes of transport that you've classified the product for': to: DOT
	Then In the Transportation Details 1 Section, set the option for DOT mode of transport to: Shipping with limited quantity
	Then in the Transportation Details 1 page I click Continue

	Given I call Shared Step 65705 (Transportation - DOT UN step - Enter UN1950, select Aerosols,  2.1, None, add technical name, Click Continue)
	Given I call Shared Step 62710 (Confirm VOC OTC/CARB heading and select No to FIRST QUESTION ONLY - Happy Path)
	Given I call Shared Step 60552 (VOC - AERO Question (ozone) enter value - Click Continue - Happy Path): 0.5
	Given I click continue
	#Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Staples
	Given I should see the Retailer Page
	Then In the Retailer Section, click 'Add Retailers' button
	Then In the Select Retailers window, select retailer: Staples
	Then In the Select Retailers window, click 'Done' button
	Then in the Retailer page I click Continue

	Then I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC60544, container type: Aerosol Can - Metal and size: 1
	#Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
	Then in the Regulatory Documents to Provide page I click Continue

	Given I call Shared Step 60567 (Upload Product Label only) for section: Volatile Organic Compounds
	And in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient | Product's Dispensing Method |
		| Mask                          | 150                      | 44                      | 10.7      | White      | Floral | No data available | 12                    | Aerosol                     |
	#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: User added Comments Text 60544. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Weld-Through Primer - Aerosol
	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase60544
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase60544


@TestCase:60545
Scenario: [60545] Photograph Coating - Aerosol - RU001067
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC60545
	Given I delete all products with UPC Number: saved as UPC60545
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Photograph Coating - Aerosol
	Then I save the product information as: TestCase60545
	#Given I call Shared Step 60756 (Product Information with Country and every option)
	Given I should see the Product Information Page
	Then In the Product Information Section, set the option in section: 'Which best describes your product, including when FIFRA 25(b) Exempt' to: Product is not a pesticide and does not make or imply a pesticidal claim on the labeling or in the product description (ex. kills, sterilizes, disinfects, sanitizes, antimicrobial)
	Then In the Product Information Section, set the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' to select: United States
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Given in the Product Information page I click Continue

	Given I call Shared Step 57111 (Enter Product Data for Physical State - Aerosol only)
	Given I click continue
	Then I should see an error message: ALERT! The ingredient table does not include a compressed gas (Bag-On-Valve) or a propellant. Please update your ingredients to include the propellant before proceeding.
	Given I call Shared Step 69557 (Enter Ingredients for Aerosol Propellent)
	#Then I should not see an error message: ALERT! The ingredient table does not include a compressed gas (Bag-On-Valve) or a propellant. Please update your ingredients to include the propellant before proceeding.
	#Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I should see the Inventory Status, Prop 65 (US) Page
	Then In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	Then In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page I click Continue

	Given I call Shared Step 57980 (Transportation Details - Yes only option - Select IMDG, Fully regulated - Continue - Happy Path)
	Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)
	And I call Shared Step 62710 (Confirm VOC OTC/CARB heading and select No to FIRST QUESTION ONLY - Happy Path)
	Given I call Shared Step 60552 (VOC - AERO Question (ozone) enter value - Click Continue - Happy Path): 0.5
	Given I click continue
	#Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Staples
	Given I should see the Retailer Page
	Then In the Retailer Section, click 'Add Retailers' button
	Then In the Select Retailers window, select retailer: Staples
	Then In the Select Retailers window, click 'Done' button
	Then in the Retailer page I click Continue

	Then I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC60545, container type: Aerosol Can and size: 33
	#Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
	Then in the Regulatory Documents to Provide page I click Continue

	Given I call Shared Step 60567 (Upload Product Label only) for section: Volatile Organic Compounds
	And in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient | Product's Dispensing Method |
		| Mask                          | 150                      | 44                      | 10.7      | White      | Floral | No data available | 12                    | Aerosol                     |
	#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: User added Comments Text 60545. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Photograph Coating - Aerosol
#	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase60545
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase60545
#Removed from regression 2024/03
@ignore
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
	#Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I should see the Inventory Status, Prop 65 (US) Page
	Then In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	Then In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page I click Continue

	#Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	Given I should see the Transportation Details 1 Page
	Then In the Transportation Details 1 Section, set the option in section: 'Product is Regulated for Transport': to: Yes
	Then In the Transportation Details 1 Section, set the option in section: 'Select all modes of transport that you've classified the product for': to: DOT
	Then In the Transportation Details 1 Section, set the option for DOT mode of transport to: Shipping with limited quantity
	Then in the Transportation Details 1 page I click Continue

	Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)
	Given I call Shared Step 62710 (Confirm VOC OTC/CARB heading and select No to FIRST QUESTION ONLY - Happy Path)
	Given I call Shared Step 60552 (VOC - AERO Question (ozone) enter value - Click Continue - Happy Path): 0.5
	Given I call Shared Step 57801 (Confirm VOC Summary step shown, Confirm VOC analysis date is shown - Happy Path)
	Given in the Volatile Organic Compound Summary page I click Continue
	#Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Dick's Sporting Goods
	Given I should see the Retailer Page
	Then In the Retailer Section, click 'Add Retailers' button
	Then In the Select Retailers window, select retailer: Dick's Sporting Goods
	Then In the Select Retailers window, click 'Done' button
	Then in the Retailer page I click Continue

	Then I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC60546, container type: Aerosol Can and size: 9.99
	#Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
	Then in the Regulatory Documents to Provide page I click Continue

	Given I call Shared Step 60567 (Upload Product Label only) for section: Volatile Organic Compounds
	And in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient | Product's Dispensing Method |
		| Mask                          | 150                      | 44                      | 10.7      | White      | Floral | No data available | 12                    | Aerosol                     |
	#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: User added Comments Text. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Glass Coating - Aerosol
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase60546

@TestCase:60547
Scenario: [60547] Corrosion Resistant Brass, Bronze or Copper Coating - Aerosol - RU001043
	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC60547
	Given I delete all products with UPC Number: saved as UPC60547

# ====== Following the steps from 'Shared Step' 57408 ====== #
	Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Given in the New Product page I click Continue

	# ====== Following the steps from 'Shared Step' 57561 ====== #
	Given I should see the The Product Page
	Given In the Product Section, set the option in section: 'Type of Product (select)' to: Corrosion Resistant Brass, Bronze or Copper Coating - Aerosol
	Given in the The Product page I click Continue
	Then I save the product information as: TestCase60547

	#Given I call Shared Step 60756 (Product Information with Country and every option)
	Given I should see the Product Information Page
	Then In the Product Information Section, set the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' to select: United States
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Given in the Product Information page I click Continue

	# ====== Following the steps from 'Shared Step' 57528 ====== #
	Given I should see the Physical and Chemical Properties Page
	Given I set the Primary Physical State option to: Solid spray
	Given I set the Secondary Physical State option to: Solid spray
	Given I set the Product is shipped directly by supplier to the consumer. option to: 12
	Given I set the Select the best Water Solubility description option to: No data available
	Given I set the When the product has a flammable propellant, or contains ingredients with a flash point below 60⁰C then option to: This product is classified as a D003 Hazardous Waste under RCRA.
	Given in the Physical and Chemical Properties page I click Continue

	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName			    | Percent	| PublicallyDisclosed | TradeSecret | PublicName |
		| Air					    | 90		| false               | false       |            |
		| Oxygen				    | 3.89      | false               | false       |            |
		| 1-Butene				    | 3.85      | false               | false       |            |
		| Hydrocarbon propellant    | 3.89		| false               | false       |            |

	# ====== Following the steps from 'Shared Step' 57571b ====== #
	Given I set the U.S. Toxic Substances Control Act (TSCA) status option to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	Given I set the Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)? option to: No
	Given in the Inventory Status, Prop 65 (US) page I click Continue

	# ====== Following the steps from 'Shared Step' 57980 ====== #
	Given I set the Product is Regulated for Transport option to: Yes
	Given I set the Select all modes of transport that you've classified the product for option to: IMDG
	Given I set the Select all modes of transport that you've classified the product for option to: Shipping fully regulated
	Given in the Transportation Details 1 page I click Continue

	Then I set the UN Number option to: UN1950
	Then in the International Marine (IMDG) Classification page I click Continue

	# ====== Following the steps from 'Shared Step' 62710 ====== #
	Then I set the Product has been granted an Alternative Control option to: No

	# ====== Following the steps from 'Shared Step' 60552 ====== #
	Then I set the VOC content in grams ozone per gram option to: 1
	Then in the Volatile Organic Compounds (VOC) page I click Continue
	Given I should see the Volatile Organic Compound Summary Page
	Then I set the Your acknowledgement of this registration includes that your product option to: Yes, I Acknowledge

	Then I set the Product has been granted an Alternative Control option to: No

	Then I confirm that I see the following VOC Grams Ozone value: 1
	And I confirm statement: Based on the type of product shows the text: Based on the type of product, this must comply with the most restrictive VOC limit.
	Then I should see the following Voc Limits present:
	| Use									                        | VOC Compliance Limit | Regulation                  |
	| Corrosion Resistant Brass, Bronze or Copper Coating - Aerosol | 1.8                  | Aerosol Coatings CARB limit |
	And The VOC Summary page contains the statement with the text: Based on the type of product, this must comply with the most restrictive VOC limit.
	And The VOC Summary page contains the statement with the text: Does not exceed the limits specified in the Aerosol Coatings by the CARB

	# ====== Following the steps from 'Shared Step' 57801 ====== #
	Given I should see the Volatile Organic Compound Summary Page
	Given I confirm that the VOC Analysis Date statement is showing
	Given I confirm that I see todays VOC Analysis Date
	Then in the Volatile Organic Compound Summary page I click Continue

	Then I call Shared Step 75146 (Retailer - Select One or More Retailers that DO NOT REQUIRE Vendor ID or Additional UPC Information, Click Done, Click Continue)
	Then I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC60547, container type: Aerosol Can - Metal and size: 33
	#Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
	Then in the Regulatory Documents to Provide page I click Continue

		# ====== Following the steps from 'Shared Step' 60567 ====== #
	Given I upload PDF document to Upload SDS (Optional) field
	Given I upload PDF document to Flash Point Testing Report field
	Then in the Additional Documents To Provide page I click Continue

	And in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient | Product's Dispensing Method |
		| Mask                          | 150                      | 44                      | 10.7      | White      | Floral | No data available | 12                    | Aerosol                     |

	#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Comment Text
	Then in the Optional Reports and Documents Available for Purchase page I click Continue
	Given In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: User added Comments Text 60547. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
	Then in the Optional Comments page I click Continue

	# ====== Following the steps from 'Shared Step' 73956 ====== #
    Given I should see the Data Acceptance Page
	Given I click the Summary button in the Data Acceptance window
	Given I switch to the Data Summary page
	Given Type of Product (select) should be showing the following option: Corrosion Resistant Brass, Bronze or Copper Coating - Aerosol
	Given I close the Data Summary Tab
    Given I should see the Data Acceptance Page

	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase60547
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase60547
