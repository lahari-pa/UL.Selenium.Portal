@Shared
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:NewProduct
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:TheProduct
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:DistributorRequestUPCSection
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:ProductInformation
@RegulatoryDocumentsToProvide
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:RegulatoryDocumentsToProvide
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:TransportationDetails1
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:InventoryStatusProp65
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:InternationalMarineClassification
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:Retailer
@SafetyDataSheetAuthoring
@Ingredients
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:VOC_OzoneTransportCommission
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:ToxicityCharacteristicLeachingProcedureTCLP
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:ElectronicEquipment
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:ProductIncludesBattery
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:DataAcceptance
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:AdditionalDocumentsToProvide
@RegulatoryDocumentsToProvide
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:Summary
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:VOC_Summary
@PhysicalAndChemicalProp
@GTINAndUPC
@LandingPage
@Login
@Homepage
@StepsPrototype
@Signup
@wercsmart
@NewProduct
@ProductGrid
@DataSummarySheet
@wercsmart
@RetailPartners
@run_Flow4
@UPC
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:OptionalComments

Feature: Flow 4

@TestCase:57950
Scenario: [57950] Conditioner - Leave In (RU001272) 4-L
	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load

    # ====== Given I call Shared Step 57408 (Create a New Registration via Register New Product icon) ====== #
    Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Given in the New Product page I click Continue

	# ====== And I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Conditioner - Leave In (Liquid, Non Aerosol) ====== #
    And I should see the The Product Page
    And I set 'Product Name' to: Conditioner - Leave In (Liquid, Non Aerosol)
    And I set 'Type of Product' to: Conditioner - Leave In (Liquid, Non Aerosol)
    And in the The Product page I click Continue
    Then I save the product information as: TestCase57950

	# ====== Given I call Shared Step 63804 (Product Information - US, No(OSHA), No(DSV), Yes (PLP), No(GNFR)) ====== #
	# ====== | Classified using OSHA (US) Globally Harmonized Standards (GHS) | Shipped directly by supplier | Private Label or Brand | Good Not for resale | ====== #
	# ====== | No                                                             | No                           | No                     | No                  | ====== #
	And I should see the Product Information Page
	And In the Product Information Section, set the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' to select: United States
	And In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	And In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	And In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	And In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	And in the Product Information page I click Continue

	#Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
	Then in the Regulatory Documents to Provide page I click Continue


	# ====== Given I call Shared Step 73629 (Physical and Chemical Properties - Liquid - select any options(enter pH, boiling point, flash point)) ====== #
	# ====== | Secondary Physical State | Relative Density | pH | Boiling Point (in Celsius) | Flash Point (in Celsius) | Flash Point Testing Method Used | Select the best Water Solubility description | ====== #
	# ====== | Liquid                   | 2                | 2  | 2                          | 66                       | Closed cup method               | Dispersible                                  | ====== #

	And I should see the Physical and Chemical Properties Page
    And In the Physical and Chemical Properties Section, set the option in section: 'Primary Physical State' to: Liquid
    And In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Liquid
	And In the Physical and Chemical Properties Section, for section: 'Relative Density' enter text: 2
    And In the Physical and Chemical Properties Section, for section: 'pH' enter text: 2
	And In the Physical and Chemical Properties Section, for section: 'Boiling Point (in Celsius)' enter text: 2
	And In the Physical and Chemical Properties Section, for section: 'Flash Point (in Celsius)' enter text: 66
	And In the Physical and Chemical Properties Section, set the option in section: 'Flash Point Testing Method Used' to: Closed cup method
    And In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Dispersible
    And in the Physical and Chemical Properties page I click Continue

    # ====== And I call Shared Step 57570 (Enter Ingredients) and add the following ingredients: ====== #
    # ======		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName | ====== #
    # ======		| Butane        | 100     | false               | false       |            | ====== #
    And I should see the Ingredients Page
    When in the Ingredients page I click Continue
    Then I should see the ingredients error message
    Then In the Ingredients section, add the following ingredients:
    		| SearchType     | SearchValue | SearchText | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
    		| component name | Butane      | Butane     | 100     | False                 | false         | false       |
    And in the Ingredients page I click Continue

    #Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I should see the Inventory Status, Prop 65 (US) Page
	Given In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	Given In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Given in the Inventory Status, Prop 65 (US) page I click Continue

    #Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
    Then I should see the Transportation Details 1 Page
    Given In the Transportation Details 1 Section, set the option in section: 'Product is Regulated for Transport': to: Yes
    Given In the Transportation Details 1 Section, set the option in section: 'Select all modes of transport that you've classified the product for': to: DOT
    Given In the Transportation Details 1 Section, set the option for DOT mode of transport to: Shipping with limited quantity
    Given in the Transportation Details 1 page I click Continue

	# ====== Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path) ====== #
    Then I should see the U. S. Department of Transportation (DOT) Classification Page
    And In the International Marine (IMDG) Classification Section, set the option in section: 'UN Number': to: UN1950
    And In the International Marine (IMDG) Classification Section, set the option in section: 'Proper Shipping Name': to: Aerosols
    And In the International Marine (IMDG) Classification Section, set the option in section: 'Technical Name (if applicable)': to: My Safe Product
    And In the International Marine (IMDG) Classification Section, set the option in section: 'Hazard Class (select)': to: 2.1
    And In the International Marine (IMDG) Classification Section, set the option in section: 'Packing Group': to: None
    Given in the U. S. Department of Transportation (DOT) Classification page I click Continue

	# ====== Given I call Shared Step 57923 (Volatile Organic Compound (VOC) Step - enter OTC and CARB - Yes for state values)  ====== #
	# ====== 		| Product granted Alternative Control Plan | Amount of VOC by CARB | Amount of VOC by OTC Model | VOC for states |  ====== #
	# ====== 		| No                                       | 2                     | 2                          | Yes           |  ====== #
	Given In the VOC - Ozone Transport Commission Section, set the option in section: 'Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations.': to: No
	Given In the VOC - Ozone Transport Commission Section, set the option in section: 'Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the CARB': to: 2
	Given In the VOC - Ozone Transport Commission Section, set the option in section: 'Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the OTC Model Rule': to: 2
	Given In the VOC - Ozone Transport Commission Section, set the option in section: 'Would you like to use the VOC percentages entered for all areas (e.g. country, state, local) for comparison?': to: Yes
	And I click continue

	Given In the Volatile Organic Compound Summary Section, for 'Your acknowledgement of this registration includes that your product..' set 'Yes, I Acknowledge'
	Given in the Volatile Organic Compound Summary page I click Continue

	# ====== Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path) ====== #
	Given in the Retailer page I click Continue

	# ====== Given I call Shared Step 60567 (Upload Product Label only) ====== #
	Given In the Regulatory Documents to Provide Section, upload file in section: 'Upload Full Product Label (required) (For private label products please upload a generic label that is not retailer-specific.)'
	Given in the New Product page I click Continue

	Given in the Optional Reports and Documents Available for Purchase page I click Continue

	# ====== Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional)) ====== #
	# ====== | Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Product's Dispensing Method | Partition Coefficient | ====== #
	# ====== | Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | Aerosol                     | 41.3005               | ====== #
	Given In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Personal Protection Equipment Recommended (select)' to: Gloves
	Given In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Minimum Ignition Energy (mJ)' enter text: 10.00001
	Given In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Viscosity' enter text: 10.28
	Given In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Appearance' to: Brown
	Given In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor' to: Orange
	Given In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor Threshold' to: No data available
	Given In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Partition Coefficient' enter text: 41.3005
	Then in the Safety Data Sheet Authoring - Additional Data (Optional) page I click Continue

    #And I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Comments Text
    And I should see the Optional Comments Page
    And I enter the following into the comments field: Comments Text
    Then in the Optional Comments page I click Continue

	# ====== Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Conditioner - Leave In (Liquid, Non Aerosol) ====== #
	Given I should see the Data Acceptance Page
	Given In the Data Acceptance Section, click 'Summary' button
	Given I switch to the tab with Data Summary page
	Given In the Summary Page, the 'Type of Product (select)' section should be showing the following value: Conditioner - Leave In (Liquid, Non Aerosol)
	Given I close the tab with Data Summary page
    Given I should see the Data Acceptance Page
	#Your acknowledgement of this registration includes tha
#	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase57950
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase57950
@ignore
@TestCase:57922
Scenario: [57922] Odor Remover/Eliminator - Aerosol (RU001086) - 4A
	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Odor Remover/Eliminator - Aerosol
	Then I save the product information as: TestCase57922
	Given I call Shared Step 118085 (Product Information - Pesticide= Not considered, SOLD=US, everything else = No California Cleaning = No - Continue)
	Given I call Shared Step 57528 (Physical and Chemical Properties - Aerosol Only - add data - Continue - Happy Path)
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
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
	Given I call Shared Step 57923 (Volatile Organic Compound (VOC) Step - enter OTC and CARB - Yes for state values)
		| Product granted Alternative Control Plan | Amount of VOC by CARB | Amount of VOC by OTC Model | VOC for states |
		| No                                       | 2                     | 2                          | Yes            |
	Given in the Volatile Organic Compound Summary page I click Continue
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	#Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
	Then in the Regulatory Documents to Provide page I click Continue

	Given I call Shared Step 59042 (Browse for File > select > click Open - Happy Path) for document type: Please upload a PDF of the product label (full label). and file: C:\Dependencies\WERCSmart\testdoc.pdf
	Given I call Shared Step 130960 (Additional Documents to Provide - VOC Product Label Upload)
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Product's Dispensing Method | Partition Coefficient |
		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | Aerosol                     | 41.3005               |
	#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Comment Text
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Odor Remover/Eliminator - Aerosol
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase57922

@ignore
@TestCase:57924
Scenario: [57924] Penetrants (RU000801) - Flow 4AL - 4A
	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Penetrants
	Then I save the product information as: TestCase57924
	Given I call Shared Step 63804 (Product Information - US, No(OSHA), No(DSV), Yes (PLP), No(GNFR))
		| Classified using OSHA (US) Globally Harmonized Standards (GHS) | Shipped directly by supplier | California's Cleaning Product Right to Know Act | Private Label or Brand | Good Not for resale |
		| No                                                             | No                           | No                                              | No                     | No                  |
	Given I call Shared Step 57539 (Physical and Chemical Properties - Aerosol & Liquid select Aerosol - Continue - Happy Path)
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
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
	Given I call Shared Step 57923 (Volatile Organic Compound (VOC) Step - enter OTC and CARB - Yes for state values)
		| Product granted Alternative Control Plan | Amount of VOC by CARB | Amount of VOC by OTC Model | VOC for states |
		| No                                       | 2                     | 2                          | Yes            |
	Given in the Volatile Organic Compound Summary page I click Continue
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	#Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
	Then in the Regulatory Documents to Provide page I click Continue

	Given I call Shared Step 60567 (Upload Product Label only)
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Product's Dispensing Method | Partition Coefficient |
		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | Aerosol                     | 41.3005               |
	#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Comment Text
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Penetrants
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase57924

@ignore
@TestCase:57925
Scenario: [57925] Floor Maintenance Product - Non-Aerosol (RU001433) 4-L
	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Floor Maintenance Product - Non-Aerosol
	Then I save the product information as: TestCase57925
	Given I call Shared Step 63804 (Product Information - US, No(OSHA), No(DSV), Yes (PLP), No(GNFR))
		| Classified using OSHA (US) Globally Harmonized Standards (GHS) | Shipped directly by supplier | California's Cleaning Product Right to Know Act | Private Label or Brand | Good Not for resale |
		| No                                                             | No                           | No                                              | No                     | No                  |
	Given I call Shared Step 73629 (Physical and Chemical Properties - Liquid - select any options(enter pH, boiling point, flash point))
		| Secondary Physical State | Relative Density | pH | Boiling Point (in Celsius) | Flash Point (in Celsius) | Flash Point Testing Method Used | Select the best Water Solubility description |
		| Liquid                   | 2                | 2  | 2                          | 66                       | Closed cup method               | Dispersible                                  |
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
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
	Given I call Shared Step 57923 (Volatile Organic Compound (VOC) Step - enter OTC and CARB - Yes for state values)
		| Product granted Alternative Control Plan | Amount of VOC by CARB | Amount of VOC by OTC Model | VOC for states |
		| No                                       | 2                     | 2                          | Yes            |
	Given in the Volatile Organic Compound Summary page I click Continue
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	#Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
	Then in the Regulatory Documents to Provide page I click Continue

	Given I call Shared Step 60567 (Upload Product Label only)
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Product's Dispensing Method | Partition Coefficient |
		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | Aerosol                     | 41.3005               |
	#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Comment Text
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Floor Maintenance Product - Non-Aerosol
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase57925

@TestCase:57927
Scenario: [57927] Floor Wax - Wood (RU000790) 4LS - 4S
	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Floor Wax - Wood
	Then I save the product information as: TestCase57927
	Given I call Shared Step 118085 (Product Information - Pesticide= Not considered, SOLD=US, everything else = No California Cleaning = No - Continue)
	Given I call Shared Step 57501 (Physical and Chemical Properties - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue)
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
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
	Given I call Shared Step 57923 (Volatile Organic Compound (VOC) Step - enter OTC and CARB - Yes for state values)
		| Product granted Alternative Control Plan | Amount of VOC by CARB | Amount of VOC by OTC Model | VOC for states |
		| No                                       | 2                     | 2                          | Yes            |
	Given in the Volatile Organic Compound Summary page I click Continue
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	#Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
	Then in the Regulatory Documents to Provide page I click Continue

	Given I call Shared Step 60567 (Upload Product Label only)
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Product's Dispensing Method | Partition Coefficient |
		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | Aerosol                     | 41.3005               |
	#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Comment Text
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Floor Wax - Wood
	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase57927
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase57927
@ignore
@TestCase:57931
Scenario: [57931] Hair Styling Product - Mousse (RU000669) - 4A
	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Hair Styling Product - Mousse
	Then I save the product information as: TestCase57931
	Given I call Shared Step 63804 (Product Information - US, No(OSHA), No(DSV), Yes (PLP), No(GNFR))
		| Classified using OSHA (US) Globally Harmonized Standards (GHS) | Shipped directly by supplier | Private Label or Brand | Good Not for resale |
		| No                                                             | No                           | No                     | No                  |
	Given I call Shared Step 57528 (Physical and Chemical Properties - Aerosol Only - add data - Continue - Happy Path)
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
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
	Given I call Shared Step 57923 (Volatile Organic Compound (VOC) Step - enter OTC and CARB - Yes for state values)
		| Product granted Alternative Control Plan | Amount of VOC by CARB | Amount of VOC by OTC Model | VOC for states |
		| No                                       | 2                     | 2                          | Yes            |
	Given in the Volatile Organic Compound Summary page I click Continue
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	#Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
	Then in the Regulatory Documents to Provide page I click Continue

	Given I call Shared Step 60567 (Upload Product Label only)
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Product's Dispensing Method | Partition Coefficient |
		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | Aerosol                     | 41.3005               |
	#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Comment Text
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Hair Styling Product - Mousse
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase57931

@ignore
@TestCase:57933
Scenario: [57933] Hair Styling Product - Aerosol and Pump Spray - Flow 4AL - 4A
	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Hair Styling Product - Aerosol and Pump Spray
	Then I save the product information as: TestCase57933
	Given I call Shared Step 63804 (Product Information - US, No(OSHA), No(DSV), Yes (PLP), No(GNFR))
		| Classified using OSHA (US) Globally Harmonized Standards (GHS) | Shipped directly by supplier | Private Label or Brand | Good Not for resale |
		| No                                                             | No                           | No                     | No                  |
	Given I call Shared Step 57539 (Physical and Chemical Properties - Aerosol & Liquid select Aerosol - Continue - Happy Path)
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
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
	Given I call Shared Step 57923 (Volatile Organic Compound (VOC) Step - enter OTC and CARB - Yes for state values)
		| Product granted Alternative Control Plan | Amount of VOC by CARB | Amount of VOC by OTC Model | VOC for states |
		| No                                       | 2                     | 2                          | Yes            |
	Given in the Volatile Organic Compound Summary page I click Continue
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	#Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
	Then in the Regulatory Documents to Provide page I click Continue

	Given I call Shared Step 60567 (Upload Product Label only)
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Product's Dispensing Method | Partition Coefficient |
		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | Aerosol                     | 41.3005               |
	#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Comment Text
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Hair Styling Product - Aerosol and Pump Spray
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase57933

@TestCase:57952
Scenario: [57952] Hair Styling Gel- (RU000749) 4LS - 4S
	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load

    # ====== Given I call Shared Step 57408 (Create a New Registration via Register New Product icon) ====== #
    Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Given in the New Product page I click Continue

	# ====== And I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Conditioner - Leave In (Liquid, Non Aerosol) ====== #
    And I should see the The Product Page
	And In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Hair Styling Gel
    And In the Product Section, set the option in section: 'Type of Product (select)' to: Hair Styling Gel
    And in the The Product page I click Continue
    Then I save the product information as: TestCase57952

	# ====== Given I call Shared Step 63804 (Product Information - US, No(OSHA), No(DSV), Yes (PLP), No(GNFR)) ====== #
	# ====== | Classified using OSHA (US) Globally Harmonized Standards (GHS) | Shipped directly by supplier | Private Label or Brand | Good Not for resale | ====== #
	# ====== | No                                                             | No                           | No                     | No                  | ====== #
	And I should see the Product Information Page
	And In the Product Information Section, set the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' to select: United States
	And In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	And In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	And In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	And In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	And in the Product Information page I click Continue

	#Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
	Then in the Regulatory Documents to Provide page I click Continue

	# ====== Given I call Shared Step 57501 (Physical and Chemical Properties - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue) ====== #
	And I should see the Physical and Chemical Properties Page
    And In the Physical and Chemical Properties Section, set the option in section: 'Primary Physical State' to: Solid
	And In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: Yes
    And In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
    And In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
    And in the Physical and Chemical Properties page I click Continue

    # ====== And I call Shared Step 57570 (Enter Ingredients) and add the following ingredients: ====== #
    # ======		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName | ====== #
    # ======		| Propane       | 100     | false               | false       |            | ====== #
    And I should see the Ingredients Page
    When in the Ingredients page I click Continue
    Then I should see the ingredients error message
    Then In the Ingredients section, add the following ingredients:
    		| SearchType     | SearchValue | SearchText | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
    		| component name | Propane     | Butane     | 100     | False               | false         | false       |
    And in the Ingredients page I click Continue

    #Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I should see the Inventory Status, Prop 65 (US) Page
	Given In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	Given In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Given in the Inventory Status, Prop 65 (US) page I click Continue

    #Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
    Then I should see the Transportation Details 1 Page
    Given In the Transportation Details 1 Section, set the option in section: 'Product is Regulated for Transport': to: Yes
    Given In the Transportation Details 1 Section, set the option in section: 'Select all modes of transport that you've classified the product for': to: DOT
    Given In the Transportation Details 1 Section, set the option for DOT mode of transport to: Shipping with limited quantity
    Given in the Transportation Details 1 page I click Continue

	# ====== Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path) ====== #
    Then I should see the U. S. Department of Transportation (DOT) Classification Page
    And In the International Marine (IMDG) Classification Section, set the option in section: 'UN Number': to: UN1950
    And In the International Marine (IMDG) Classification Section, set the option in section: 'Proper Shipping Name': to: Aerosols
    And In the International Marine (IMDG) Classification Section, set the option in section: 'Technical Name (if applicable)': to: My Safe Product
    And In the International Marine (IMDG) Classification Section, set the option in section: 'Hazard Class (select)': to: 2.1
    And In the International Marine (IMDG) Classification Section, set the option in section: 'Packing Group': to: None
    Given in the U. S. Department of Transportation (DOT) Classification page I click Continue

	# ====== Given I call Shared Step 57923 (Volatile Organic Compound (VOC) Step - enter OTC and CARB - Yes for state values)  ====== #
	# ====== 		| Product granted Alternative Control Plan | Amount of VOC by CARB | Amount of VOC by OTC Model | VOC for states |  ====== #
	# ====== 		| No                                       | 2                     | 2                          | Yes           |  ====== #
	Given In the VOC - Ozone Transport Commission Section, set the option in section: 'Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations.': to: No
	Given In the VOC - Ozone Transport Commission Section, set the option in section: 'Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the CARB': to: 2
	Given In the VOC - Ozone Transport Commission Section, set the option in section: 'Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the OTC Model Rule': to: 2
	Given In the VOC - Ozone Transport Commission Section, set the option in section: 'Would you like to use the VOC percentages entered for all areas (e.g. country, state, local) for comparison?': to: Yes
	And I click continue

    Given In the Volatile Organic Compound Summary Section, for 'Your acknowledgement of this registration includes that your product..' set 'Yes, I Acknowledge'
	Given in the Volatile Organic Compound Summary page I click Continue

	# ====== Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path) ====== #
	Given in the Retailer page I click Continue

	# ====== Given I call Shared Step 60567 (Upload Product Label only) ====== #
	Given In the Regulatory Documents to Provide Section, upload file in section: 'Upload Full Product Label (required) (For private label products please upload a generic label that is not retailer-specific.)'
	Given in the New Product page I click Continue

	Given in the Optional Reports and Documents Available for Purchase page I click Continue

	# ====== Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional)) ====== #
	# ====== | Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Product's Dispensing Method | Partition Coefficient | ====== #
	# ====== | Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | Aerosol                     | 41.3005               | ====== #
	Given In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Personal Protection Equipment Recommended (select)' to: Gloves
	Given In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Minimum Ignition Energy (mJ)' enter text: 10.00001
	Given In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Viscosity' enter text: 10.28
	Given In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Appearance' to: Brown
	Given In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor' to: Orange
	Given In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor Threshold' to: No data available
	Given In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Partition Coefficient' enter text: 41.3005
	Then in the Safety Data Sheet Authoring - Additional Data (Optional) page I click Continue

	 #And I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Comments Text
    And I should see the Optional Comments Page
    And I enter the following into the comments field: Comments Text
    Then in the Optional Comments page I click Continue

	# ====== Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Conditioner - Leave In (Liquid, Non Aerosol) ====== #
	Given I should see the Data Acceptance Page
	Given In the Data Acceptance Section, click 'Summary' button
	Given I switch to the tab with Data Summary page
	Given In the Summary Page, the 'Type of Product (select)' section should be showing the following value: Hair Styling Gel
	Given I close the tab with Data Summary page
    Given I should see the Data Acceptance Page
	#Your acknowledgement of this registration includes tha
	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase57952
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase57952
@TestCase:57958
Scenario: [57958] Adhesive - Aerosol Web Spray (RU000909) - 4A
	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Adhesive - Aerosol Web Spray
	Then I save the product information as: TestCase57958
	Given I call Shared Step 57401 (Product Information - US only - No GHS, Not Direct Ship, Not PLP, Not GNFR > Continue - Happy Path)
	Given I call Shared Step 57528 (Physical and Chemical Properties - Aerosol Only - add data - Continue - Happy Path)
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
	Given I call Shared Step 57932 (Regulatory - TSCA Only - Yes to All Prop 65 questions - Continue - Happy Path)
	#Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	Given I should see the Transportation Details 1 Page
	Then In the Transportation Details 1 Section, set the option in section: 'Product is Regulated for Transport': to: Yes
	Then In the Transportation Details 1 Section, set the option in section: 'Select all modes of transport that you've classified the product for': to: DOT
	Then In the Transportation Details 1 Section, set the option for DOT mode of transport to: Shipping with limited quantity
	Then in the Transportation Details 1 page I click Continue

	Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)
	Given I call Shared Step 57923 (Volatile Organic Compound (VOC) Step - enter OTC and CARB - Yes for state values)
		| Product granted Alternative Control Plan | Amount of VOC by CARB | Amount of VOC by OTC Model | VOC for states |
		| No                                       | 2                     | 2                          | Yes            |
	Given in the Volatile Organic Compound Summary page I click Continue
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	#Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
	Then in the Regulatory Documents to Provide page I click Continue

	Given I call Shared Step 60567 (Upload Product Label only)
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Product's Dispensing Method | Partition Coefficient |
		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | Aerosol                     | 41.3005               |
	#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Comment Text
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Adhesive - Aerosol Web Spray
	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase57958
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase57958
@ignore
@TestCase:57977
Scenario: [57977] Adhesive (Spray, Special Purpose): Polyolefin and Laminate Repair/Edgebanding(RU000912) - 4AL - 4A
	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Adhesive (Spray, Special Purpose): Polyolefin and Laminate Repair/Edgebanding
	Then I save the product information as: TestCase57977
	Given I call Shared Step 63804 (Product Information - US, No(OSHA), No(DSV), Yes (PLP), No(GNFR))
		| Classified using OSHA (US) Globally Harmonized Standards (GHS) | Shipped directly by supplier | Private Label or Brand | Good Not for resale |
		| No                                                             | No                           | No                     | No                  |
	Given I call Shared Step 57539 (Physical and Chemical Properties - Aerosol & Liquid select Aerosol - Continue - Happy Path)
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
	Given I call Shared Step 57932 (Regulatory - TSCA Only - Yes to All Prop 65 questions - Continue - Happy Path)
	#Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	Given I should see the Transportation Details 1 Page
	Then In the Transportation Details 1 Section, set the option in section: 'Product is Regulated for Transport': to: Yes
	Then In the Transportation Details 1 Section, set the option in section: 'Select all modes of transport that you've classified the product for': to: DOT
	Then In the Transportation Details 1 Section, set the option for DOT mode of transport to: Shipping with limited quantity
	Then in the Transportation Details 1 page I click Continue

	Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)
	Given I call Shared Step 57923 (Volatile Organic Compound (VOC) Step - enter OTC and CARB - Yes for state values)
		| Product granted Alternative Control Plan | Amount of VOC by CARB | Amount of VOC by OTC Model | VOC for states |
		| No                                       | 2                     | 2                          | Yes            |
	Given in the Volatile Organic Compound Summary page I click Continue
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	#Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
	Then in the Regulatory Documents to Provide page I click Continue

	Given I call Shared Step 60567 (Upload Product Label only)
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Product's Dispensing Method | Partition Coefficient |
		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | Aerosol                     | 41.3005               |
	#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Comment Text
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Adhesive (Spray, Special Purpose): Polyolefin and Laminate Repair/Edgebanding
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase57977

@TestCase:57982
Scenario: [57982] Bonding agent (RU000023) - 4All - 4G
	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load

	 # ====== Given I call Shared Step 57408 (Create a New Registration via Register New Product icon) ====== #
    Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Given in the New Product page I click Continue

	# ====== And I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Bonding agent ====== #
    And I should see the The Product Page
	And In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Bonding agent
    And In the Product Section, set the option in section: 'Type of Product (select)' to: Bonding agent
    And in the The Product page I click Continue
    Then I save the product information as: TestCase57982
	Then I generate a random UPC number and save as: UPC57982

	# ====== Given I call Shared Step 214643 (Product Information - Applicable Only to Bonding Agent (RU000023)) ====== #
	# ====== | Classified using OSHA (US) Globally Harmonized Standards (GHS) | Shipped directly by supplier | Private Label or Brand | Good Not for resale | ====== #
	# ====== | No                                                             | No                           | No                     | No                  | ====== #
	And I should see the Product Information Page
	And In the Product Information Section, set the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' to select: United States
	And In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	And In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	And In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	And In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	And in the Product Information page I click Continue

	#Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
	Then in the Regulatory Documents to Provide page I click Continue

	# ====== Then I call Shared Step 214644(Physical and Chemical Properties - Applicable Only to Bonding Agent (RU000023)) ====== #
	# ====== 	| Section                  | do not have exact data | Value                    | ====== #
	# ====== 	| Primary Physical State   |                        | Liquid                   | ====== #
	# ====== 	| Secondary Physical State |                        | Liquid                   | ====== #
	# ====== 	| pH                       |                        | 5                        | ====== #
	# ====== 	| Relative Density         |                        | 0.82                     | ====== #
	# ====== 	| Primary State Options    |                        | Aerosol Gas Liquid Solid | ====== #
	# ====== 	| Boiling Point (in Celsius) |                        | 100                    | ====== #
	# ====== 	| Flash Point (in Celsius) | Yes                    | None, No Flash Point     | ====== #
	# ====== 	| Water Solubility         |                        | Insoluble in water       | ====== #
	And I should see the Physical and Chemical Properties Page
    And In the Physical and Chemical Properties Section, set the option in section: 'Primary Physical State' to: Liquid
    And In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Liquid
	And In the Physical and Chemical Properties Section, for section: 'pH' enter text: 5
	And In the Physical and Chemical Properties Section, for section: 'Relative Density' enter text: 0.82
	And In the Physical and Chemical Properties Section, for section: 'Boiling Point (in Celsius)' enter text: 100
	And In the Physical and Chemical Properties Section, for section: 'Flash Point (in Celsius)' select the checkbox option: 'I do not have exact Flash Point data available to me'
	And In the Physical and Chemical Properties Section, set the option in section: 'Flash Point (in Celsius)' to: None, No Flash Point
    And In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Insoluble in water
    And in the Physical and Chemical Properties page I click Continue

	# ====== And I call Shared Step 57570 (Enter Ingredients) and add the following ingredients: ====== #
    # ======		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName | ====== #
    # ======		| Acetic Acid  | 100      | false               | false       |            | ====== #
    And I should see the Ingredients Page
    When in the Ingredients page I click Continue
    Then I should see the ingredients error message
	And The ingredients error message should be showing: Formulation must total or exceed 100%.
    Then In the Ingredients section, add the following ingredients:
    		| SearchType     | SearchValue | SearchText  | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
    		| component name | Acetic Acid | Acetic Acid | 100     | False               | false         | false       |
    And in the Ingredients page I click Continue

	# ====== And I call Shared Step 40650 (Regulatory Information 1 - TSCA shown, No to PROP 65 - Continue - Happy Path)
	Given I should see the Inventory Status, Prop 65 (US) Page
	Given In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	Given In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Given in the Inventory Status, Prop 65 (US) page I click Continue

	# ====== Given I call Shared Step 57507 (Transportation Details 1- Not Regulated - Continue - Happy Path) ====== #
    Then I should see the Transportation Details 1 Page
    Given In the Transportation Details 1 Section, set the option in section: 'Product is Regulated for Transport': to: Not Regulated
    Given in the Transportation Details 1 page I click Continue

	# ====== Given I call Shared Step 57923 (Volatile Organic Compound (VOC) Step - enter OTC and CARB - Yes for state values)  ====== #
	# ====== 		| Product granted Alternative Control Plan | Amount of VOC by CARB | Amount of VOC by OTC Model | VOC for states |  ====== #
	# ====== 		| No                                       | 10                    | 6                          | Yes            |  ====== #
	Given In the VOC - Ozone Transport Commission Section, set the option in section: 'Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations.': to: No
	Given In the VOC - Ozone Transport Commission Section, set the option in section: 'Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the CARB': to: 10
	Given In the VOC - Ozone Transport Commission Section, set the option in section: 'Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the OTC Model Rule': to: 6
	Given In the VOC - Ozone Transport Commission Section, set the option in section: 'Would you like to use the VOC percentages entered for all areas (e.g. country, state, local) for comparison?': to: Yes
	And I click continue

	Given In the Volatile Organic Compound Summary Section, for 'Your acknowledgement of this registration includes that your product..' set 'Yes, I Acknowledge'
	Given in the Volatile Organic Compound Summary page I click Continue

    #Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: The Home Depot
	Given I should see the Retailer Page
	Given In the Retailer Section, click 'Add Retailers' button
	Given In the Select Retailers window, select retailer: The Home Depot
	Given In the Select Retailers window, click 'Done' button
	Given in the Retailer page I click Continue

	Then I click continue

	# ====== I call Shared Step 57960a (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only - Do Not Click Continue) for UPC: saved as UPC57982, container type: Plastic Container and size: 12.5 ====== #
	And I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page
	Given In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, I click the Add UPC Button
	Then I add the following into the UPC Fields
	| Field         | Value               |
	| UPCNumber     | saved as UPC57982   |
	| ContainerType | Plastic Container   |
	| Size          | 12.5                |
    Given I should see following container type from the drop down list
	|Container Type|
	| Coated or Laminated Paperboard |
	| Full Syringe - Medical         |
	| Glass Container                |
	| Metal Container                |
	| Metal Cylinder                 |
	| Plastic Container              |
	| Vial - Medical                 |
	And I confirm that retailer "HD" is present under the 'Destination Retailers' column in the UPC table
	Then I click continue	

	# ====== Given I call Shared Step 60567 (Upload Product Label only) ====== #
	Given In the Regulatory Documents to Provide Section, upload file in section: 'Upload Full Product Label (required) (For private label products please upload a generic label that is not retailer-specific.)'
	Given in the New Product page I click Continue

	Given in the Optional Reports and Documents Available for Purchase page I click Continue

	# ====== Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional)) ====== #
	# ====== | Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Product's Dispensing Method | Partition Coefficient | ====== #
	# ====== | Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | Aerosol                     | 41.3005               | ====== #
	Given In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Personal Protection Equipment Recommended (select)' to: Gloves
	Given In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Minimum Ignition Energy (mJ)' enter text: 10.00001
	Given In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Viscosity' enter text: 10.28
	Given In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Appearance' to: Brown
	Given In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor' to: Orange
	Given In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor Threshold' to: No data available
	Given In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Partition Coefficient' enter text: 41.3005
	Then in the Safety Data Sheet Authoring - Additional Data (Optional) page I click Continue

	#And I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Comments Text
    And I should see the Optional Comments Page
    And I enter the following into the comments field: Comments Text
    Then in the Optional Comments page I click Continue

	# ====== Then I call Shared Step 214662 (Summary Tab - Data Verification - Applicable Only to Bonding Agent (RU000023)) ====== #
	# ====== | Section                                              | Value             | ====== #
	# ====== | Type of Product                                      | Bonding agent     | ====== #
	# ====== | Primary Physical State                               | Liquid            | ====== #
	# ====== | Secondary Physical State                             | Liquid            | ====== #
	# ====== | Product has been granted an Alternative Control Plan | No                | ====== #
	# ====== | CARB                                                 | 10                | ====== #
	# ====== | OTC Model Rule                                       | 6                 | ====== #
	# ====== | Container Type                                       | Plastic Container | ====== #
	# ====== | Size (Ounces)                                        | 12.5              | ====== #
	# ====== | Retailers                                            | HD                | ====== #
	Given I should see the Data Acceptance Page
	Given In the Data Acceptance Section, click 'Summary' button
	Given I switch to the tab with Data Summary page
	Given In the Summary Page, the 'Type of Product (select)' section should be showing the following value: Bonding agent
	Given In the Summary Page, the 'Primary Physical State' section should be showing the following value: Liquid
	Given In the Summary Page, the 'Secondary Physical State' section should be showing the following value: Liquid
	Given In the Summary Page, the 'CARB' section should be showing the following value: 10
	Given In the Summary Page, the 'OTC Model Rule' section should be showing the following value: 6
	Given I close the tab with Data Summary page
    Given I should see the Data Acceptance Page

	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase57982
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase57982
@TestCase:57983
Scenario: [57983] Lubricant, Multi-Purpose, Not for Personal Use (RU000674) 4L
	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Lubricant, Multi-Purpose, Not for Personal Use
	Then I save the product information as: TestCase57983
	Given I call Shared Step 63804 (Product Information - US, No(OSHA), No(DSV), Yes (PLP), No(GNFR))
		| Classified using OSHA (US) Globally Harmonized Standards (GHS) | Shipped directly by supplier | Private Label or Brand | Good Not for resale |
		| No                                                             | No                           | No                     | No                  |
	Given I call Shared Step 74760 (Physical and Chemical Properties - Select Liquid as primary physical state and enter all required data)
		| Primary Physical State | Secondary Physical State | Relative Density | pH | Boiling Point (in Celsius) | Flash Point (in Celsius) | Flash Point Testing Method Used | Select the best Water Solubility description |
		| Liquid                 | Liquid                   | 2                | 2  | 2                          | 66                       | Closed cup method               | Dispersible                                  |
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
	Given I call Shared Step 57932 (Regulatory - TSCA Only - Yes to All Prop 65 questions - Continue - Happy Path)
	#Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	Given I should see the Transportation Details 1 Page
	Then In the Transportation Details 1 Section, set the option in section: 'Product is Regulated for Transport': to: Yes
	Then In the Transportation Details 1 Section, set the option in section: 'Select all modes of transport that you've classified the product for': to: DOT
	Then In the Transportation Details 1 Section, set the option for DOT mode of transport to: Shipping with limited quantity
	Then in the Transportation Details 1 page I click Continue

	Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)
	Given I call Shared Step 57923 (Volatile Organic Compound (VOC) Step - enter OTC and CARB - Yes for state values)
		| Product granted Alternative Control Plan | Amount of VOC by CARB | Amount of VOC by OTC Model | VOC for states |
		| No                                       | 2                     | 2                          | Yes            |
	Given in the Volatile Organic Compound Summary page I click Continue
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	#Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
	Then in the Regulatory Documents to Provide page I click Continue

	Given I call Shared Step 60567 (Upload Product Label only)
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Product's Dispensing Method | Partition Coefficient |
		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | Aerosol                     | 41.3005               |
	#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Comment Text
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Lubricant, Multi-Purpose, Not for Personal Use
	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase57983
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase57983
@OnlyInStaging
@TestCase:57985
Scenario: [57985] Footwear or Leather Care Product - Aerosol (RU000744) - Testing New Flow Update
	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load

	 # ====== Given I call Shared Step 57408 (Create a New Registration via Register New Product icon) ====== #
    Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Given in the New Product page I click Continue

	# ====== And I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Footwear or Leather Care Product - Aerosol ====== #
    And I should see the The Product Page
    And In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Footwear or Leather Care Product - Aerosol
    And In the Product Section, set the option in section: 'Type of Product (select)' to: Footwear or Leather Care Product - Aerosol
    And in the The Product page I click Continue
    Then I save the product information as: TestCase57985
	Then I generate a random UPC number and save as: UPC57985

	# ====== Given I call Shared Step 74340 (Product Information - Pesticide= Not considered, SOLD=US, everything else = No - Continue) ====== #
	# ====== | Classified using OSHA (US) Globally Harmonized Standards (GHS) | Shipped directly by supplier | Private Label or Brand | Good Not for resale | ====== #
	# ====== | No                                                             | No                           | No                     | No                  | ====== #
	And I should see the Product Information Page
	And In the Product Information Section, set the option in section: 'Which best describes your product, including when FIFRA 25(b) Exempt' to: Product is not a pesticide and does not make or imply a pesticidal claim on the labeling or in the product description (ex. kills, sterilizes, disinfects, sanitizes, antimicrobial)
	And In the Product Information Section, set the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' to select: United States
	And In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	And In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	And In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	And In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	And in the Product Information page I click Continue

	#Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
	Then in the Regulatory Documents to Provide page I click Continue

    # ====== Then I call Shared Step 213391(Physical and Chemical Properties (Applicable Only to Flow 6-A Type of Products) - Primary Physical State (AEROSOL ONLY) / Secondary Physical State (ANY)): ====== #
	# ====== 	| Section                    | do not have exact data | Value                                                                                                 | ====== #
	# ====== 	| Primary Physical State     |                        | Aerosol                                                                                               | ====== #
	# ====== 	| Primary State Options      |                        | Aerosol                                                                                               | ====== #
	# ====== 	| Secondary Physical State   |                        | Solid spray                                                                                           | ====== #
	# ====== 	| pH                         |  Yes                   | Not tested/Unknown                                                                                    | ====== #
	# ====== 	| has a flammable propellant |                        | This product is classified as a D001 Hazardous Waste under RCRA (as per Section 13 or 15 of the SDS). | ====== #
	And I should see the Physical and Chemical Properties Page
    And In the Physical and Chemical Properties Section, set the option in section: 'Primary Physical State' to: Aerosol
    And In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid spray
	And In the Physical and Chemical Properties Section, for section: 'pH' select the checkbox option: 'I do not have exact pH data available to me'
	And In the Physical and Chemical Properties Section, set the option in section: 'pH' to: Not tested/Unknown
	And In the Physical and Chemical Properties Section, set the option in section: 'When the product has a flammable propellant, or contains ingredients with a flash point below 60⁰C then' to: This product is classified as a D001 Hazardous Waste under RCRA (as per Section 13 or 15 of the SDS).
	And in the Physical and Chemical Properties page I click Continue

	# ====== And I call Shared Step 57570 (Enter Ingredients) and add the following ingredients: ====== #
    # ======		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName | ====== #
    # ======		| Acetic Acid  | 100      | false               | false       |            | ====== #
    And I should see the Ingredients Page
    When in the Ingredients page I click Continue
    Then I should see the ingredients error message
    Then In the Ingredients section, add the following ingredients:
    		| SearchType | SearchValue | SearchText    | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
    		| CAS number | 1174921-73-3 | 1174921-73-3 | 37.5    | False               | false         | false       |
			| CAS number | 106-97-8     | 106-97-8     | 25.5    | False               | false         | false       |
			| CAS number | 74-98-6      | 74-98-6      | 25.5    | False               | false         | false       |
			| CAS number | 141-78-6     | 141-78-6     | 11.5    | False               | false         | false       |
    And in the Ingredients page I click Continue

	# ====== Then I call Shared Step 57571b (Enter Regulatory Information - Not Prop 65): ====== #
	# ====== 	| TSCA																		                  | Prop 65 | ====== #
	# ====== 	| This product is subject to and complies with TSCA chemical Inventory listing requirements.  | No      | ====== #
	Given I should see the Inventory Status, Prop 65 (US) Page
	Given In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	Given In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Given in the Inventory Status, Prop 65 (US) page I click Continue

	#Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
    Then I should see the Transportation Details 1 Page
    Given In the Transportation Details 1 Section, set the option in section: 'Product is Regulated for Transport': to: Yes
    Given In the Transportation Details 1 Section, set the option in section: 'Select all modes of transport that you've classified the product for': to: DOT
    Given In the Transportation Details 1 Section, set the option for DOT mode of transport to: Shipping with limited quantity
    Given in the Transportation Details 1 page I click Continue

	# ====== Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path) ====== #
    Then I should see the U. S. Department of Transportation (DOT) Classification Page
    And In the International Marine (IMDG) Classification Section, set the option in section: 'UN Number': to: UN1950
    And In the International Marine (IMDG) Classification Section, set the option in section: 'Proper Shipping Name': to: Aerosols
    And In the International Marine (IMDG) Classification Section, set the option in section: 'Technical Name (if applicable)': to: My Safe Product
    And In the International Marine (IMDG) Classification Section, set the option in section: 'Hazard Class (select)': to: 2.1
    And In the International Marine (IMDG) Classification Section, set the option in section: 'Packing Group': to: None
    Given in the U. S. Department of Transportation (DOT) Classification page I click Continue

	# ====== Given I call Shared Step 57923 (Volatile Organic Compound (VOC) Step - enter OTC and CARB - Yes for state values)  ====== #
	# ====== 		| Product granted Alternative Control Plan | Amount of VOC by CARB | Amount of VOC by OTC Model | VOC for states |  ====== #
	# ====== 		| No                                       | 2                     | 2                          | Yes           |  ====== #
	Given In the VOC - Ozone Transport Commission Section, set the option in section: 'Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations.': to: No
	Given In the VOC - Ozone Transport Commission Section, set the option in section: 'Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the CARB': to: 75
	Given In the VOC - Ozone Transport Commission Section, set the option in section: 'Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the OTC Model Rule': to: 15
	Given In the VOC - Ozone Transport Commission Section, set the option in section: 'Would you like to use the VOC percentages entered for all areas (e.g. country, state, local) for comparison?': to: Yes
	Given I click continue
	Then I confirm that I see the following CARB value: 75
	Then I confirm that I see the following OTC Model Rule value: 15
	And I confirm statement: Based on the type of product shows the text: Based on the type of product, this must comply with the most restrictive VOC limit.
	Then I should see data for States in the 'VOC Content as weight percentage of total formula' table
	And I should see the following Voc percent for each state:
		| State           | Regulation            | VOC Value | State VOC Threshold | Message                          |
		| New York        | State Allowable Limit | 15        | 75                  | Does not exceed the State Limits |
	Then I should see the following Voc Limits present:
	| Use									     | VOC Compliance Limit | Regulation           |
	| Footwear or Leather Care Product - Aerosol | 75                   | OTC Model rule limit |
	| Footwear or Leather Care Product - Aerosol | 75                   | CARB limit           |
	And The VOC Summary page contains the statement with the text: Does not exceed the limits specified in the California Consumer Products Regulation
	And The VOC Summary page contains the statement with the text: Does not exceed the limits specified by the Ozone Transport Commission

	Then I call Shared Step 57801 (Confirm VOC Summary step shown and VOC analysis date is shown - Happy Path)
	Given In the Volatile Organic Compound Summary Section, for 'Your acknowledgement of this registration includes that your product..' set 'Yes, I Acknowledge'
	Given in the Volatile Organic Compound Summary page I click Continue

	# ====== Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path) ====== #
	Given in the Retailer page I click Continue

	# ====== Given I call Shared Step 60567 (Upload Product Label only) ====== #
	Given In the Regulatory Documents to Provide Section, upload file in section: 'Upload Full Product Label (required) (For private label products please upload a generic label that is not retailer-specific.)'
	Given in the New Product page I click Continue

	Given in the Optional Reports and Documents Available for Purchase page I click Continue

	Given In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Personal Protection Equipment Recommended (select)' to: Gloves
	Given In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Minimum Ignition Energy (mJ)' enter text: 10.00001
	Given In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Viscosity' enter text: 10.28
	Given In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Appearance' to: Brown
	Given In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor' to: Orange
	Given In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor Threshold' to: No data available
	Given In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Product's Dispensing Method' select option: Aerosol
	Given In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Partition Coefficient' enter text: 41.3005
	Then in the Safety Data Sheet Authoring - Additional Data (Optional) page I click Continue

	#And I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Comments Text
    And I should see the Optional Comments Page
    And I enter the following into the comments field: Comments Text
    Then in the Optional Comments page I click Continue

	# ====== Given I call Shared Step 221015 (Summary Tab - Product's Data Verification When Request to Author is NOT Selected in the Regulatory Documents to Provide Page (Applies Only to Footwear or Leather Care Product Aerosol (RU000744)) ====== #
	# ====== | Section                                    | Value                                                                                                                                                                                | ====== #
	# ====== | Type of Product                            | Footwear or Leather Care Product - Aerosol                                                                                                                                           | ====== #
	# ====== | FIFRA 25(b) Exempt						  | Product is not a pesticide and does not make or imply a pesticidal claim on the labeling or in the product description (ex. kills, sterilizes, disinfects, sanitizes, antimicrobial) | ====== #
	# ====== | UN Number                                  | UN1950                                                                                                                                                                               | ====== #
	# ====== | Proper Shipping Name                       | Aerosols                                                                                                                                                                             | ====== #
	# ====== | Hazard Class                               | 2.1                                                                                                                                                                                  | ====== #
	# ====== | Packing Group                              | None                                                                                                                                                                                 | ====== #
	# ====== | CARB									      | 75                                                                                                                                                                                   | ====== #
	# ====== | OTC Model Rule							  | 15                                                                                                                                                                                   | ====== #
	Given I should see the Data Acceptance Page
	Given In the Data Acceptance Section, click 'Summary' button
	Given I switch to the tab with Data Summary page
	Given In the Summary Page, the 'Type of Product (select)' section should be showing the following value: Footwear or Leather Care Product - Aerosol
	Given In the Summary Page, the 'FIFRA 25(b) Exempt' section should be showing the following value: Product is not a pesticide and does not make or imply a pesticidal claim on the labeling or in the product description (ex. kills, sterilizes, disinfects, sanitizes, antimicrobial)
	Given In the Summary Page, the 'UN Number' section should be showing the following value: UN1950
	Given In the Summary Page, the 'Proper Shipping Name' section should be showing the following value: Aerosols
	Given In the Summary Page, the 'Hazard Class' section should be showing the following value: 2.1
	Given In the Summary Page, the 'Packing Group' section should be showing the following value: None
	Given In the Summary Page, the 'CARB' section should be showing the following value: 75
	Given In the Summary Page, the 'OTC Model Rule' section should be showing the following value: 15
	Given I close the tab with Data Summary page
    Given I should see the Data Acceptance Page

#	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase57985
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase57985
@TestCase:57988
Scenario: [57988] Anti-Static Product - Non-Aerosol (RU000667) 4-L
	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Anti-Static Product - Non-Aerosol
	Then I save the product information as: TestCase57988
	Given I call Shared Step 57401 (Product Information - US only - No GHS, Not Direct Ship, Not PLP, Not GNFR > Continue - Happy Path)
	And I call Shared Step 84554 (Physical and Chemical Properties - Liquid & Solid - Enter all data - Continue - Happy Path)
	#Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Water
	Given I should see the Ingredients Page
	Then In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	| component name | Water       | 100     |                     |               |             |
	Then in the Ingredients page I click Continue

	Given I call Shared Step 57932 (Regulatory - TSCA Only - Yes to All Prop 65 questions - Continue - Happy Path)
	Given I call Shared Step 57507 (Transportation Details 1- Not Regulated - Continue - Happy Path)
	Given I call Shared Step 57923 (Volatile Organic Compound (VOC) Step - enter OTC and CARB - Yes for state values)
		| Product granted Alternative Control Plan | Amount of VOC by CARB | Amount of VOC by OTC Model | VOC for states |
		| No                                       | 2                     | 2                          | Yes            |
	Given in the Volatile Organic Compound Summary page I click Continue
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	#Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
	Then in the Regulatory Documents to Provide page I click Continue

	Given I call Shared Step 60567 (Upload Product Label only)
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Product's Dispensing Method | Partition Coefficient |
		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | Aerosol                     | 41.3005               |
	#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Comment Text
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Anti-Static Product - Non-Aerosol
	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase57988
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase57988

@TestCase:57990
Scenario: [57990] Footwear or Leather Care Product - Solid (RU000745)
	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load

	 # ====== Given I call Shared Step 57408 (Create a New Registration via Register New Product icon) ====== #
    Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Given in the New Product page I click Continue

	# ====== And I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Footwear or Leather Care Product - Aerosol ====== #
    And I should see the The Product Page
    And In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Footwear or Leather Care Product - Solid
    And In the Product Section, set the option in section: 'Type of Product (select)' to: Footwear or Leather Care Product - Solid
    And in the The Product page I click Continue
    Then I save the product information as: TestCase57990
	Then I generate a random UPC number and save as: UPC57990

	# ====== Then I call Shared Step 57401 (Product Information - US only - No GHS, Not Direct Ship, Not PLP, Not GNFR > Continue - Happy Path) ====== #
	And I should see the Product Information Page
	And In the Product Information Section, set the option in section: 'Which best describes your product, including when FIFRA 25(b) Exempt' to: Product is not a pesticide and does not make or imply a pesticidal claim on the labeling or in the product description (ex. kills, sterilizes, disinfects, sanitizes, antimicrobial)
	And In the Product Information Section, set the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' to select: United States
	And In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	And In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	And In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	And In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	And in the Product Information page I click Continue

	#Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
	Then in the Regulatory Documents to Provide page I click Continue

	#Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I should see the Physical and Chemical Properties Page
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' should be showing the option: Solid
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' confirm option is selected: Solid
	Then In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
	Then In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Then In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
	Then in the Physical and Chemical Properties page I click Continue


	# ====== Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients: ====== #
	# ======	| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName | ====== #
	# ======	| Water         | 100     | false               | false       |            | ====== #
    And I should see the Ingredients Page
    When in the Ingredients page I click Continue
    Then I should see the ingredients error message
    Then In the Ingredients section, add the following ingredients:
    		| SearchType     | SearchValue | SearchText | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
    		| component name | Water       | Water      | 100     | False               | false         | false       |
    And in the Ingredients page I click Continue

	# ====== Then I call Shared Step 57571b (Enter Regulatory Information - Not Prop 65): ====== #
	# ====== 	| TSCA																		                  | Prop 65 | ====== #
	# ====== 	| This product is subject to and complies with TSCA chemical Inventory listing requirements.  | No      | ====== #
	Given I should see the Inventory Status, Prop 65 (US) Page
	Given In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	Given In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Given in the Inventory Status, Prop 65 (US) page I click Continue

	# ====== Given I call Shared Step 57507 (Transportation Details 1- Not Regulated - Continue - Happy Path) ====== #
    Then I should see the Transportation Details 1 Page
    Given In the Transportation Details 1 Section, set the option in section: 'Product is Regulated for Transport': to: Not Regulated
    Given in the Transportation Details 1 page I click Continue

	# ====== Given I call Shared Step 57923 (Volatile Organic Compound (VOC) Step - enter OTC and CARB - Yes for state values)  ====== #
	# ====== 		| Product granted Alternative Control Plan | Amount of VOC by CARB | Amount of VOC by OTC Model | VOC for states |  ====== #
	# ====== 		| Yes                                      | 5                     | 5                          | Yes            |  ====== #
	Given In the VOC - Ozone Transport Commission Section, set the option in section: 'Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations.': to: No
	Given In the VOC - Ozone Transport Commission Section, set the option in section: 'Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the CARB': to: 5
	Given In the VOC - Ozone Transport Commission Section, set the option in section: 'Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the OTC Model Rule': to: 5
	Given In the VOC - Ozone Transport Commission Section, set the option in section: 'Would you like to use the VOC percentages entered for all areas (e.g. country, state, local) for comparison?': to: Yes
	And I click continue

    Then I confirm that I see the following CARB value: 5
	Then I confirm that I see the following OTC Model Rule value: 5
	Then I should see data for States in the 'VOC Content as weight percentage of total formula' table
	Then I should see the following Voc Limits present:
	| Use									   | VOC Compliance Limit | Regulation           |
	| Footwear or Leather Care Product - Solid | 55                   | OTC Model rule limit |
	| Footwear or Leather Care Product - Solid | 55                   | CARB limit           |
	And The VOC Summary page contains the statement with the text: Does not exceed the limits specified in the California Consumer Products Regulation
	And The VOC Summary page contains the statement with the text: Does not exceed the limits specified by the Ozone Transport Commission

	 # ====== Then I call Shared Step 57801 (Confirm VOC Summary step shown and VOC analysis date is shown - Happy Path) ====== #
	Given In the Volatile Organic Compound Summary Section, for 'Your acknowledgement of this registration includes that your product..' set 'Yes, I Acknowledge'
	Given in the Volatile Organic Compound Summary page I click Continue

    # ====== Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path) ====== #
	Given in the Retailer page I click Continue

	# ====== Then I call Shared Step 78801 (Additional Documents to Provide - VOC and Product Label) ====== #
	Given In the Regulatory Documents to Provide Section, upload file in section: 'Upload Full Product Label (required) (For private label products please upload a generic label that is not retailer-specific.)'
	Given in the Additional Documents to Provide page I click Continue

	Given in the Optional Reports and Documents Available for Purchase page I click Continue

	# ====== Then I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following: ====== #
	# ====== 	| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient | ====== #
	# ====== 	| Mask                          | 300                      | 1.005                   | 20        | Chrome     | Magnolia | No data available | 1                     | ====== #
	Given In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Personal Protection Equipment Recommended (select)' to: Mask
	Given In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Minimum Ignition Energy (mJ)' enter text: 1.005
	Given In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Viscosity' enter text: 20
	Given In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Appearance' to: Chrome
	Given In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor' to: Magnolia
	Given In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor Threshold' to: No data available
	Given In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Partition Coefficient' enter text: 1
	Then in the Safety Data Sheet Authoring - Additional Data (Optional) page I click Continue

	#And I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Comments Text
    And I should see the Optional Comments Page
    And In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: Comments Text
    Then in the Optional Comments page I click Continue

	# ====== Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Footwear or Leather Care Product - Solid ====== #
	Given I should see the Data Acceptance Page
	Given In the Data Acceptance Section, click 'Summary' button
	Given I switch to the tab with Data Summary page
	Given In the Summary Page, the 'Type of Product (select)' section should be showing the following value: Footwear or Leather Care Product - Solid
	Given I close the tab with Data Summary page
    Given I should see the Data Acceptance Page
	#Your acknowledgement of this registration includes tha

	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase57990
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase57990
@TestCase:57991
Scenario: [57991] Glue sticks for glue guns- (RU000300) - 4S
	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load

	 # ====== Given I call Shared Step 57408 (Create a New Registration via Register New Product icon) ====== #
    Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Given in the New Product page I click Continue

	# ====== And I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Footwear or Leather Care Product - Aerosol ====== #
    And I should see the The Product Page
    And In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Glue sticks for glue guns
    And In the Product Section, set the option in section: 'Type of Product (select)' to: Glue sticks for glue guns
    And in the The Product page I click Continue
    Then I save the product information as: TestCase57991
	Then I generate a random UPC number and save as: UPC57991

	# ====== Given I call Shared Step 63804 (Product Information - US, No(OSHA), No(DSV), Yes (PLP), No(GNFR)) ====== #
	# ====== | Classified using OSHA (US) Globally Harmonized Standards (GHS) | Shipped directly by supplier | Private Label or Brand | Good Not for resale | ====== #
	# ====== | No                                                             | No                           | No                     | No                  | ====== #
	And I should see the Product Information Page
	And In the Product Information Section, set the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' to select: United States
	And In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	And In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	And In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	And In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	And in the Product Information page I click Continue

	#Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
	Then in the Regulatory Documents to Provide page I click Continue

	#Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I should see the Physical and Chemical Properties Page
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' should be showing the option: Solid
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' confirm option is selected: Solid
	Then In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
	Then In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Then In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
	Then in the Physical and Chemical Properties page I click Continue

	# ====== And I call Shared Step 57570 (Enter Ingredients) and add the following ingredients: ====== #
    # ======    | CASNumber        | Percent | PublicallyDisclosed | TradeSecret | PublicName | ====== #
	# ======	| 24937-78-8	   | 40      | false               | false       |            | ====== #
	# ======	| 68131-77-1	   | 45      | false               | false       |            | ====== #
	# ======	| 8002-74-2        | 15      | false               | false       |            | ====== #
    And I should see the Ingredients Page
    When in the Ingredients page I click Continue
    Then I should see the ingredients error message
    Then In the Ingredients section, add the following ingredients:
    		| SearchType | SearchValue | SearchText  | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
    		| CAS number | 24937-78-8  | 24937-78-8  | 40      | False               | false         | false       |
			| CAS number | 68131-77-1  | 168131-77-1 | 45      | False               | false         | false       |
			| CAS number | 8002-74-2   | 8002-74-2   | 15      | False               | false         | false       |
    And in the Ingredients page I click Continue

	#Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I should see the Inventory Status, Prop 65 (US) Page
	Given In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	Given In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Given in the Inventory Status, Prop 65 (US) page I click Continue

    #Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
    Then I should see the Transportation Details 1 Page
    Given In the Transportation Details 1 Section, set the option in section: 'Product is Regulated for Transport': to: Yes
    Given In the Transportation Details 1 Section, set the option in section: 'Select all modes of transport that you've classified the product for': to: DOT
    Given In the Transportation Details 1 Section, set the option for DOT mode of transport to: Shipping with limited quantity
    Given in the Transportation Details 1 page I click Continue

    # ====== Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path) ====== #
    Then I should see the U. S. Department of Transportation (DOT) Classification Page
    And In the International Marine (IMDG) Classification Section, set the option in section: 'UN Number': to: UN1950
    And In the International Marine (IMDG) Classification Section, set the option in section: 'Proper Shipping Name': to: Aerosols
    And In the International Marine (IMDG) Classification Section, set the option in section: 'Technical Name (if applicable)': to: My Safe Product
    And In the International Marine (IMDG) Classification Section, set the option in section: 'Hazard Class (select)': to: 2.1
    And In the International Marine (IMDG) Classification Section, set the option in section: 'Packing Group': to: None
    Given in the U. S. Department of Transportation (DOT) Classification page I click Continue

	# ====== Given I call Shared Step 57923 (Volatile Organic Compound (VOC) Step - enter OTC and CARB - Yes for state values)  ====== #
	# ====== 		| Product granted Alternative Control Plan | Amount of VOC by CARB | Amount of VOC by OTC Model | VOC for states |  ====== #
	# ====== 		| No                                       | 10                    | 10                         | Yes           |  ====== #
	Given In the VOC - Ozone Transport Commission Section, set the option in section: 'Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations.': to: No
	Given In the VOC - Ozone Transport Commission Section, set the option in section: 'Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the CARB': to: 10
	Given In the VOC - Ozone Transport Commission Section, set the option in section: 'Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the OTC Model Rule': to: 10
	Given I click continue

	Given In the Volatile Organic Compound Summary Section, for 'Your acknowledgement of this registration includes that your product..' set 'Yes, I Acknowledge'
	Given in the Volatile Organic Compound Summary page I click Continue

	#Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Walgreens
	Given I should see the Retailer Page
	Given In the Retailer Section, click 'Add Retailers' button
	Given In the Select Retailers window, select retailer: Walgreens
	Given In the Select Retailers window, click 'Done' button
	Given in the Retailer page I click Continue

	Then I click continue

	# ====== Given I call Shared Step 57960a (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only - Do Not Click Continue) for UPC: saved as UPC57991, container type: Plastic Container and size: 13.2 ====== #
	And I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page
	Given In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, I click the Add UPC Button
	Given In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, for section: 'Provide the product's UPC(s)- including container type and size (ounces)' enter UPC Number: saved as UPC57991 enter Size: 13.2 and enter Container Type: Plastic Container 
	Given I should see following container type from the drop down list
	|Container Type|
	|Cardboard|
	|Cardboard with Gas Cylinder|
	|Clay-Coated News Board|
	|Coated or Laminated Paperboard|
	|Empty Syringe - Medical|
	|Full Syringe - Medical|
	|Glass Container|
	|Metal Container|
	|Metal Cylinder|
	|Other |
	|Paper bag|
	|Plastic bag|
	|Plastic Container|
	|Plastic Liner/Corrugate|
	|Vial - Medical|
	|Wooden box|
	|Wooden crate|
	And I confirm that retailer "WG" is present under the 'Destination Retailers' column in the UPC table
	Then I click continue	

	# ====== Given I call Shared step 214825 (Additional Documents to Provide - Upload Product Label - Continue) ====== #
	And I should see the Additional Documents to Provide Page
	Given I upload PDF document to Generic Private Label (all sides) field
    Then in the Additional Documents to Provide page I click Continue

	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given in the Optional Comments page I click Continue

	# ====== Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Glue sticks for glue guns ====== #
	Given I should see the Data Acceptance Page
	Given In the Data Acceptance Section, click 'Summary' button
	Given I switch to the tab with Data Summary page
	Given In the Summary Page, the 'Type of Product (select)' section should be showing the following value: Glue sticks for glue guns
	Given I close the tab with Data Summary page
    Given I should see the Data Acceptance Page
	#Your acknowledgement of this registration includes tha
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase57991
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Glue sticks for glue guns
	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase57991
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase57991
