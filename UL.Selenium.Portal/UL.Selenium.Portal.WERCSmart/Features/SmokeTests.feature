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
@PaymentMethods
@SHA
@CreateProducts
@Studio
@StepsPrototype
@ProductSetUp
@run_Transportation
@PhysicalAndChemicalProp
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:RegulatoryDocumentsToProvide
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:OptionalComments
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:DataAcceptance
@Ingredients@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:NewProduct
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:TheProduct
@Ingredients
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:InventoryStatusProp65
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:USDepartamentOfTransportationDOT
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:TransportationDetails1
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:ProductInformation
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:TransportationClassification
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:InternationalAirTransportClassification
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:InternationalMarineClassification
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:CanadaTransportationOfDangerousGoodsClassification
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:VOC_OzoneTransportCommission
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:VOC_Summary
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:Retailer
@SideMenu
@Steps_ProductPrototype
@RegulatoryInformation3
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:Summary
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:AdditionalDocumentsToProvide

Feature: Smoke Tests


@TestCase:283496
Scenario: [283496] WERCSmart Portal - Flow Test for Hair Styling Product - Mousse (Liquid) (RU003202)
	 #Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	 Given I log in with the account saved in TReVor as: ProductAccount
	 Then The home screen should load
	 #283497 WERCSmart Portal - Create New Registration - Enter Product Name and Select Type of Product: Hair Styling Product - Mousse (Liquid) (RU003202)
	 Then In the Side Menu, click Labeled Link with Add Product title
	 Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration'
	 Then in the New Product page, I click Continue
	 Then I should be on the The Product Page
	 And In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: ProductTest
	 And In the Product Section, set the option in section: 'Type of Product (select)' to: Hair Styling Product - Mousse (Liquid)
	 Then in the The Product page, I click Continue
     Given I generate a random UPC number and save as: UPC283496
	 Then I save the product information as: TestCase283496
	 #283498 Product Information - Applicable only to Product Type: Hair Styling Product - Mousse (Liquid) (RU003202)
	 Then I should be on the Product Information Page
	 Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	 Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	 Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	 Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	 Then in the Product Information page, I click Continue
	 #283499 Physical and Chemical Properties - Applicable Only to Product Type: Hair Styling Product - Mousse (Liquid) (RU003202)
	 And I should be on the Physical and Chemical Properties Page
	 Then In the Physical and Chemical Properties Section, set the option in section: 'Primary Physical State' to: Liquid
	 Then In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Foam
	 Then In the Physical and Chemical Properties Section, for section: 'Relative Density' enter text: 2
	 Then In the Physical and Chemical Properties Section, for section: 'pH' enter text: 1
	 Then In the Physical and Chemical Properties Section, for section: 'Boiling Point (in Celsius)' enter text: 100
	 Then In the Physical and Chemical Properties Section, for section: 'Flash Point (in Celsius)' enter text: 50
	 Then In the Physical and Chemical Properties Section, set the option in section: 'Flash Point Testing Method Used' to: Closed cup method
	 Then In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
	 Then in the Physical and Chemical Properties page, I click Continue
	 #283502 Ingredients - Applicable Only to Product Type: Hair Styling Product - Mousse (Liquid) (RU003202)
	 Given I should be on the Ingredients Page
	 Then In the Ingredients section, add component with component name: Ethyl ester of pvm/ma copolymer
	 Then In the Ingredients Table row with component name: Ethyl ester of pvm/ma copolymer, in Percent column text input enter: 30
	 Then In the Ingredients section, add component with component name: Panthenol
	 Then In the Ingredients Table row with component name: Panthenol, in Percent column text input enter: 30
	 Then In the Ingredients section, add component with component name: Methylparaben
	 Then In the Ingredients Table row with component name: Methylparaben, in Percent column text input enter: 20
	 Then In the Ingredients section, add component with component name: Water
	 Then In the Ingredients Table row with component name: Water, in Percent column text input enter: 20
	 Then in the Ingredients page I click Continue
	 #283503 Inventory Status, Prop 65 (US) - Applicable Only to Type of Product - Hair Styling Product - Mousse (Liquid) (RU003202)
	 Given I should be on the Inventory Status, Prop 65 (US) Page
	 Then In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is exempt from TSCA chemical Inventory listing requirements.
	 Then In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	 Then in the Inventory Status, Prop 65 (US) page, I click Continue
	 # 283504 Product Labeling - Applicable Only to Type of Product: Hair Styling Product - Mousse (Liquid) (RU003202)
	 Given I should see the Product Labeling Page
	 Then In the Product Labeling Section, in section: 'Refer to your Product Label.  From the options, select those that appear on the Label.' click the checkbox option: None of the Above
	 Given I click continue
	 #283506 Transportation Details 1 - Applicable Only to Type of Product: Hair Styling Product - Mousse (Liquid) (RU003202)
	 And I should be on the Transportation Details 1 Page
	 And In the Transportation Details 1 Section, set the option in section: 'Product is Regulated for Transport': to: Yes
	 Then In the Transportation Details 1 Section, set the option in section: 'Select all modes of transport that you've classified the product for': to: DOT
	 Then In the Transportation Details 1 Section, set the option for DOT mode of transport to: Shipping fully regulated
	 Then in the Transportation Details 1 page, I click Continue
	 And I should be on the U.S. Department of Transportation (DOT) Classification Page
	 #283507 Shared Steps 283507: U.S. Department of Transportation (DOT) Classification - Applicable Only to Type of Product: Hair Styling Product - Mousse (Liquid) (RU003202) - Enter UN1987
	 And In the U.S. Department of Transportation (DOT) Classification Section, set the option in section: 'UN Number': to: UN1987
	 And In the U.S. Department of Transportation (DOT) Classification Section, verify section: 'Proper Shipping Name' contains value: Alcohols, n.o.s.
	 And In the U.S. Department of Transportation (DOT) Classification Section, set the option in section: 'Hazard Class': to: 3
	 And In the U.S. Department of Transportation (DOT) Classification Section, set the option in section: 'Packing Group': to: III
	 Then in the U.S. Department of Transportation (DOT) Classification page, I click Continue
	 #283508 VOC - OTC - and/or CARB - Applicable only to Type of Product: Hair Styling Product - Mousse (Liquid) (RU003202)
	 And I should see the Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB) Page
	 Then In the VOC - Ozone Transport Commission Section, set the option in section: 'Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations.': to: No
	 Then In the VOC - Ozone Transport Commission Section, set the option in section: 'Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the CARB': to: 1
	 Then In the VOC - Ozone Transport Commission Section, set the option in section: 'Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the OTC Model Rule': to: 1
	 Then In the VOC - Ozone Transport Commission Section, set the option in section: 'Would you like to use the VOC percentages entered for all areas (e.g. country, state, local) for comparison?': to: Yes
	 Then in the Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB) page, I click Continue	
	 And I should see the Volatile Organic Compound Summary Page
	 Then In the Volatile Organic Compound Summary Section, for 'Your acknowledgement of this registration includes that your product..' set 'Yes, I Acknowledge'
	 And I click continue
	 #150905 Retailer - NR selected by default
	 Then I should be on the Retailer Page
	 Then in the Retailer page, I click Continue
	 #And I call Shared Step 78080 (Regulatory Documents to Provide - Upload OSHA SDS)
	Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Yes, I certify that I have an OSHA-compliant SDS for this product and would like to upload it.
	Then In the Regulatory Documents to Provide Section, upload file in section: 'OSHA SDS'
	Then In the Regulatory Documents to Provide Section, for section OSHA SDS button View should exists
	Then In the Regulatory Documents to Provide Section, for section OSHA SDS button Remove should exists
	Then in the Regulatory Documents to Provide page I click Continue
	#283511 Additional Documents to Provide - Applicable Only to Type of Product: Hair Styling Product - Mousse (Liquid) (RU003202)
	Given I should see the Additional Documents to Provide Page
	Then In the Additional Documents to Provide, upload PDF document for section: Volatile Organic Compounds - Product Label
	And in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Then I should be on the Optional Comments Page
    Then in the Optional Comments page, I click Continue
	#284143 Summary tab - Data Verification - Applicable Only to Hair Styling Product - Mousse (Liquid) (RU003202)
	And I should see the Data Acceptance Page
    Given I click the Summary button in the Data Acceptance window
	Then I switch to the Data Summary page
	Given In the Summary Page, the 'Type of Product (select)' section should be showing the following value: Hair Styling Product - Mousse (Liquid)
	Then In the Summary Page, the 'Primary Physical State' section should be showing the following value: Liquid
	Then In the Summary Page, the 'Secondary Physical State' section should be showing the following value: Foam
	Then In the Summary Page, the 'Relative Density' section should be showing the following value: 2
	Then In the Summary Page, the 'pH' section should be showing the following value: 1
	Then In the Summary Page, the 'Boiling Point (in Celsius)' section should be showing the following value: 100
	Then In the Summary Page, the 'Flash Point (in Celsius)' section should be showing the following value: 50
	Then In the Summary Page, the 'Flash Point Testing Method Used' section should be showing the following value: The flash point value provided is per a Closed Cup test method
	Then In the Summary Page, the 'Select the best Water Solubility description' section should be showing the following value: Soluble in water
	Then In the Summary page, I confirm the Ingredients table matches the following:
	| CAS Number/ChemicalName               | Percent | Publicly Disclosed? | Trade Secret? | INCI Name  |
	| Ethyl ester of pvm/ma copolymer       | 30      | No                  | No            |            |
	| Panthenol                             | 30      | No                  | No		    |            |
	| Methylparaben                         | 20	  | No                  |No             |            |
	| Water                                 | 20      | No                  | No            |            |
	Then In the Summary Page, the 'UN Number' section should be showing the following value: UN1987
	Then In the Summary Page, the 'Proper Shipping Name' section should be showing the following value: Alcohols, n.o.s.
	Then In the Summary Page, the 'Hazard Class (select)' section should be showing the following value: 3
	Then In the Summary Page, the 'Packing Group (select)' section should be showing the following value: III
	Then In the Summary Page, the 'Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the CARB' section should be showing the following value: 1
	Then In the Summary Page, the 'Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the OTC Model Rule' section should be showing the following value: 1
	Then In the Summary Page, click the View button for section: Product Label
	Then In the Summary Page, after clicking 'View' button I confirm pdf file is downloaded
	Given I close the tab with Data Summary page
	Then In the Side Menu, click Labeled Link with My Products title
	#Then In the Product Grid, delete the product saved as: TestCase283496




@TestCase:287238
Scenario: [287238] WERCSmart Portal - Flow Test for Hair Styling Product - Mousse (Aerosol) (RU000669) - Includes Negative Steps
	 #Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	 Given I log in with the account saved in TReVor as: ProductAccount
	 Then The home screen should load
	 	 #WERCSmart Portal - Create New Registration - Negative Steps - Enter Product Name and Select Type of Product: Hair Styling Product - Mousse (Aerosol) (RU000669)
	 Then In the Side Menu, click Labeled Link with Add Product title
	 Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration'
	 Then in the New Product page, I click Continue
	 Then I should be on the The Product Page
	 Then in the The Product page, I click Continue
	 And In the Product section, for field 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' error message 'This is a required field.' is displayed
	 And In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: ProductTest
	 Then in the The Product page, I click Continue
	 Then In the Product section, for field 'Type of Product' error message 'This is a required field.' is displayed
	 And In the Product Section, set the option in section: 'Type of Product (select)' to: Hair Styling Product - Mousse (Liquid)
	 Then in the The Product page, I click Continue
     Given I generate a random UPC number and save as: UPC283496
	 Then I save the product information as: TestCase283496
	 # Shared Steps 287277: Product Information - Negative Steps - Applicable only to Product Type: Hair Styling Product - Mousse (Aerosol) (RU000669)
	 Then I should be on the Product Information Page
	 Then in the Product Information page, I click Continue
	 Then In the Product Information section, for field 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' error message 'This is a required field.' is displayed
	 Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	 Then in the Product Information page, I click Continue
	 Then In the Product Information section, for field 'Product is shipped directly by supplier to the consumer' error message 'This is a required field.' is displayed
	 Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	 Then in the Product Information page, I click Continue
	 Then In the Product Information section, for field 'Product is sold as a' error message 'This is a required field.' is displayed
	 Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	 Then in the Product Information page, I click Continue
	 Then In the Product Information section, for field 'Product is sold to the Retailer solely for the' error message 'This is a required field.' is displayed
	 Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	 Then in the Product Information page, I click Continue
	 #287387 Shared Steps 287387: Physical and Chemical Properties - Negative Steps - Applicable Only to Product Type: Hair Styling Product - Mousse (Aerosol) (RU000669)
	 And I should be on the Physical and Chemical Properties Page
	 Then in the Physical and Chemical Properties page, I click Continue
	 Then In the Physical and Chemical Properties section, for field 'Secondary Physical State' error message 'This is a required field.' is displayed
	  Then In the Physical and Chemical Properties Section, set the option in section: 'Primary Physical State' to: Liquid
	 Then In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Liquid
	 Then in the Physical and Chemical Properties page, I click Continue
	 Then In the Physical and Chemical Properties section, for field 'Relative Density' error message 'This is a required field.' is displayed
	 Then In the Physical and Chemical Properties Section, for section: 'Relative Density' enter text: 2
	 Then in the Physical and Chemical Properties page, I click Continue
	 Then In the Physical and Chemical Properties section, for field 'pH' error message 'This is a required field.' is displayed
	 Then In the Physical and Chemical Properties Section, for section: 'pH' enter text: 16
	 Then In the Physical and Chemical Properties section, for field 'pH' error message 'pH must be between 1-14 (1 decimal place allowed)' is displayed
	 Then In the Physical and Chemical Properties Section, for section: 'pH' enter text: 13.13
	 Then In the Physical and Chemical Properties section, for field 'pH' error message 'pH must be between 1-14 (1 decimal place allowed).' is displayed
	 Then In the Physical and Chemical Properties Section, for section: 'pH' enter text: 13.1
	 Then In the Physical and Chemical Properties section, for field 'Select the best Water Solubility description' error message 'This is a required field.' is displayed
	 Then In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
	 Then In the Physical and Chemical Properties section, for field 'Boiling Point (in Celsius)' error message 'This is a required field.' is displayed
	 Then In the Physical and Chemical Properties section, for field 'Flash Point (in Celsius)' error message 'This is a required field.' is displayed
	 Then In the Physical and Chemical Properties Section, for section: 'Boiling Point (in Celsius)' enter text: 100
	 Then In the Physical and Chemical Properties Section, for section: 'Flash Point (in Celsius)' enter text: 65
	 Then In the Physical and Chemical Properties Section, set the option in section: 'Flash Point Testing Method Used' to: Closed cup method
	 Then in the Physical and Chemical Properties page, I click Continue
	 #287391 Ingredients - Negative Steps - Applicable Only to Product Type: Hair Styling Product - Mousse (Aerosol) (RU000669)
	 Given I should be on the Ingredients Page
	 Then in the Ingredients page, I click Continue
	 Then In the Ingredients Section, for field 'Table' error message 'Formulation must total or exceed 100%.' is displayed
	 Then In the Ingredients section, add component with component name: Butane
	 Then in the Ingredients page, I click Continue
	 Then In the Ingredients Section, for field 'percentage' error message 'For all components entered percentage should be greater than 0. Formulation must total or exceed 100%.' is displayed
	 Then In the Ingredients Table row with component name: Butane, in Percent column text input enter: 10
	 Then in the Ingredients page, I click Continue
	 Then In the Ingredients Section, for field 'Table' error message 'Please fix row errors' is displayed
	 Then In the Ingredients section, add component with component name: Water
	 Then In the Ingredients Table row with component name: Water, in Percent column text input enter: 50
	 Then In the Ingredients Table row with component name: Water, in Publicly Disclosed column set checkbox to checked
	 Then in the Ingredients page, I click Continue
	 Then In the Ingredients Section, for field 'Public Name' error message 'Please select Public Name since you agreed on Publicly Disclosed' is displayed
	 Then In the Ingredients Section, for field 'Table' error message 'Please fix row errors.' is displayed
	 Then In the Ingredients Table row with component name: Water, in Public Name column select option Water
	 Then In the Ingredients section, add component with component name: Hydrogenated jojoba oil
	 Then In the Ingredients Table row with component name: Hydrogenated jojoba oil, in Percent column text input enter: 40
	 Then In the Ingredients Table row with component name: Hydrogenated jojoba oil, in Trade Secret column set checkbox to checked
	 Then in the Ingredients page I click Continue
	 #287407 Inventory Status, Prop 65 (US) - Negative Steps - Applicable Only to Product Type: Hair Styling Product - Mousse (Aerosol) (RU000669)
	 Given I should be on the Inventory Status, Prop 65 (US) Page
	 Given I click continue
	 Then In the Inventory Status section, for field 'U.S. Toxic Substances Control Act (TSCA) status' error message 'This is a required field.' is displayed
	 Then In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	 Then In the Inventory Status section, for field 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' error message 'This is a required field.' is displayed
	 Then In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: Yes
	 Then in the Inventory Status, Prop 65 (US) page, I click Continue
	 Then In the Inventory Status section, for field 'Is the need to warn triggered by' error message 'This is a required field.' is displayed
	 Then In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'Is the need to warn triggered by' to: A chemical or chemicals in the product, or chemicals formed during the use of the product.
	 Then In the Inventory Status, Prop 65 (US) Section, for field 'How is the exposure warning transmitted? For more information, see Notice of Adoption Article' error message 'Select at least one of the options' is displayed
	 Then In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'How is the exposure warning transmitted?' to: Other (Please specify)
	 Then in the Inventory Status, Prop 65 (US) page, I click Continue
	 Then In the Inventory Status section, for field 'Other' error message 'This is a required field.' is displayed
	 Then In the Inventory Status, Prop 65 (US) Section, enter value in 'Other' field for section: 'How is the exposure warning transmitted?': This is an exposure warning
	 Then In the Inventory Status section, for field 'Is your exposure warning compliant with Proposition 65 regulations applicable to products manufactured' error message 'This is a required field.' is displayed
	 Then In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'Is your exposure warning compliant with Proposition 65 regulations applicable to products manufactured' to: Both, because instances of this product manufactured before, on and after August 30, 2018 are on the market.
	 Then In the Inventory Status section, for field 'If the product carries a safe-harbor short-form warning, indicate which of the following is provided' error message 'This is a required field.' is displayed
	 Then In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'If the product carries a safe-harbor short-form warning- indicate which of the following is provided:': to: Does not apply
	 Then In the Inventory Status section, for field 'If the product carries a safe-harbor long-form warning, indicate which of the following is used and enter the names of the Proposition 65 chemicals included in the warning' error message 'This is a required field.' is displayed
	 Then In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'If the product carries a safe-harbor long-form warning- indicate which of the following is used and enter the names of the Proposition 65 chemicals included in the warning:': to: This product can expose you to chemicals including [name of one or more chemicals], which is [are] known to the State of California to cause cancer. For more information go to
	 Then in the Inventory Status, Prop 65 (US) page, I click Continue
	 Then In the Inventory Status section, for field 'Enter the names of one or more listed carcinogens which are the subject of this warning' error message 'This is a required field.' is displayed
	 Then In the Inventory Status, Prop 65 (US) Section, enter value in 'Enter the names of one or more listed carcinogens which are the subject of this warning' section: Names of listed carcinogens
	 Then In the Inventory Status section, for field 'If the product carries a custom warning, please provide the exact text that is being used' error message 'This is a required field.' is displayed
	 Then In the Inventory Status, Prop 65 (US) Section, enter value in 'If the product carries a custom warning, please provide the exact text that is being used:' section: Custom warning exact text
     Then in the Inventory Status, Prop 65 (US) page, I click Continue
	 # 287472 Shared Steps 287472: Product Labeling - Negative Steps - Applicable Only to Type of Product: Hair Styling Product - Mousse (Aerosol) (RU000669)
	 Given I should see the Product Labeling Page
	 Then In the Product Labeling Section, in section: 'Refer to your Product Label.  From the options, select those that appear on the Label.' click the checkbox option: None of the Above
	 Given I click continue
	 #283506 Transportation Details 1 - Applicable Only to Type of Product: Hair Styling Product - Mousse (Liquid) (RU003202)
	 And I should be on the Transportation Details 1 Page
	 And In the Transportation Details 1 Section, set the option in section: 'Product is Regulated for Transport': to: Yes
	 Then In the Transportation Details 1 Section, set the option in section: 'Select all modes of transport that you've classified the product for': to: DOT
	 Then In the Transportation Details 1 Section, set the option for DOT mode of transport to: Shipping fully regulated
	 Then In the Transportation Details 1 Section, set the option in section: 'Select all modes of transport that you've classified the product for': to: IMDG
	 Then In the Transportation Details 1 Section, set the option for IMDG mode of transport to: Shipping fully regulated
	 Then In the Transportation Details 1 Section, set the option in section: 'Select all modes of transport that you've classified the product for': to: IATA
	 Then In the Transportation Details 1 Section, set the option for IATA mode of transport to: Shipping fully regulated
	 Then In the Transportation Details 1 Section, set the option in section: 'Select all modes of transport that you've classified the product for': to: TDG
	 Then In the Transportation Details 1 Section, set the option for TDG mode of transport to: Shipping fully regulated
	 Then In the Transportation Details 1 Section, set the option in section: 'Provide Special Permit numbers (if applicable)': to: 1234567890
	 Then in the Transportation Details 1 page, I click Continue
	 And I should be on the U.S. Department of Transportation (DOT) Classification Page
	 #287479 Shared Steps 287479: U.S. Department of Transportation (DOT) Classification - Negative Steps - Applicable only to Type of Product: Hair Styling Product - Mousse (Aerosol) (RU000669)
	 Then in the U.S. Department of Transportation (DOT) Classification page, I click Continue
	 Then In the U.S. Department of Transportation (DOT) Classification section, for field 'UN Number' error message 'This is a required field.' is displayed
	 And In the U.S. Department of Transportation (DOT) Classification Section, set the option in section: 'UN Number': to: UN1950
	 Then In the U.S. Department of Transportation (DOT) Classification section, for field 'Proper Shipping Name' error message 'This is a required field.' is displayed
	 And In the U.S. Department of Transportation (DOT) Classification Section, set the option in section: 'Proper Shipping Name': to: Aerosols
	 Then In the U.S. Department of Transportation (DOT) Classification section, for field 'Hazard Class' error message 'This is a required field.' is displayed
	 And In the U.S. Department of Transportation (DOT) Classification Section, set the option in section: 'Hazard Class': to: 2.1
	 And In the U.S. Department of Transportation (DOT) Classification Section, set the option in section: 'Packing Group': to: None
	 Then in the U.S. Department of Transportation (DOT) Classification page, I click Continue
	 #287706 Shared Steps 287706: International Air Transport (IATA) Classification - Negative Steps - Applicable only to Type of Product: Hair Styling Product - Mousse (Aerosol) (RU000669)
	 Given I should see the International Air Transport (IATA) Classification Page
	 Then in the International Air Transport (IATA) Classification page I click Continue
	 Then In the International Air Transport (IATA) Classification section, for field 'UN Number' error message 'This is a required field.' is displayed
	Then In the International Air Transport (IATA) Classification section, for field 'Hazard Class (select)' error message 'This is a required field.' is displayed
	Then In the International Air Transport (IATA) Classification section, for field 'Packing Group' error message 'This is a required field.' is displayed
	Then In the International Air Transport (IATA) Classification section, for field 'Proper Shipping Name' error message 'This is a required field.' is displayed
	Then In the International Air Transport (IATA) Classification Section, I check checkbox 'Copy information from my U.S. Department of Transportation data'
    Then In the International Air Transport (IATA) Classification Section, verify section: 'UN Number' contains value: UN1950
	Then In the International Air Transport (IATA) Classification Section, verify section: 'Hazard Class (select)' contains value: 2.1
	Then In the International Air Transport (IATA) Classification Section, verify section: 'Packing Group (select)' contains value: None
	Then In the International Air Transport (IATA) Classification section, for field 'Proper Shipping Name' error message 'This is a required field.' is displayed
	Then In the International Air Transport (IATA) Classification Section, set the option in section: 'Proper Shipping Name': to: Aerosols, flammable
	Then in the International Air Transport (IATA) Classification page I click Continue
	Given I should see the International Marine (IMDG) Classification Page
	Then in the International Marine (IMDG) Classification page I click Continue
	Then In the International Marine (IMDG) Classification section, for field 'UN Number' error message 'This is a required field.' is displayed
	Then In the International Marine (IMDG) Classification section, for field 'Hazard Class (select)' error message 'This is a required field.' is displayed
	Then In the International Marine (IMDG) Classification section, for field 'Packing Group' error message 'This is a required field.' is displayed
	Then In the International Marine (IMDG) Classification section, for field 'Proper Shipping Name' error message 'This is a required field.' is displayed
	Then In the International Marine (IMDG) Classification Section, I check checkbox 'Copy information from my U.S. Department of Transportation data'
	Then In the International Marine (IMDG) Classification Section, verify section: 'UN Number' contains value: UN1950
	Then In the International Marine (IMDG) Classification Section, verify section: 'Proper Shipping Name' contains value: Aerosols
	Then In the International Marine (IMDG) Classification Section, verify section: 'Hazard Class (select)' contains value: 2
	Then In the International Marine (IMDG) Classification Section, verify section: 'Packing Group (select)' contains value: None
	Then in the International Marine (IMDG) Classification page I click Continue
	#287708 Shared Steps 287708: Canada - Transportation of Dangerous Goods (TDG) Classification - Negative Steps - Applicable only to Type of Product: Hair Styling Product - Mousse (Aerosol) (RU000669)
	And I should be on the Canada - Transportation of Dangerous Goods (TDG) Classification Page
	Then in the Canada - Transportation of Dangerous Goods (TDG) Classification page I click Continue
	Then In the Canada - Transportation of Dangerous Goods (TDG) Classification section, for field 'UN Number' error message 'This is a required field.' is displayed
	Then In the Canada - Transportation of Dangerous Goods (TDG) Classification section, for field 'Hazard Class (select)' error message 'This is a required field.' is displayed
	Then In the Canada - Transportation of Dangerous Goods (TDG) Classification section, for field 'Packing Group' error message 'This is a required field.' is displayed
	Then In the Canada - Transportation of Dangerous Goods (TDG) Classification section, for field 'Proper Shipping Name' error message 'This is a required field.' is displayed
	Then In the Canada - Transportation of Dangerous Goods (TDG) Classification Section, I check checkbox 'Copy information from my U.S. Department of Transportation data'
	Then In the Canada - Transportation of Dangerous Goods (TDG) Classification Section, verify section: 'UN Number' contains value: UN1950
	Then In the Canada - Transportation of Dangerous Goods (TDG) Classification Section, verify section: 'Proper Shipping Name' contains value: Aerosols
	Then In the Canada - Transportation of Dangerous Goods (TDG) Classification Section, verify section: 'Hazard Class (select)' contains value: 2.1
	Then In the Canada - Transportation of Dangerous Goods (TDG) Classification Section, verify section: 'Packing Group (select)' contains value: None
	Then in the Canada - Transportation of Dangerous Goods (TDG) Classification page I click Continue

	#287608 Shared Steps 287608: Volatile Organic Compounds (VOC) - Negative Steps - Applicable only to Type of Product: Hair Styling Product - Mousse (Aerosol) (RU000669)
	Given I should see the Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB) Page
	Then in the Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB) page I click Continue
	Then In the Volatile Organic Compounds (VOC) section, for field 'Product has been granted' error message 'This is a required field.' is displayed
	Then In the VOC - Ozone Transport Commission Section, set the option in section: 'Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations.': to: Yes
	Then In the Volatile Organic Compounds (VOC) section, for field 'Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the CARB' error message 'This is a required field.' is displayed
	Then In the VOC - Ozone Transport Commission Section, set the option in section: 'Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the CARB': to: 2
	Then In the Volatile Organic Compounds (VOC) section, for field 'Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the OTC Model Rule' error message 'This is a required field.' is displayed
	Then In the VOC - Ozone Transport Commission Section, set the option in section: 'Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the OTC Model Rule': to: 3
	Then In the Volatile Organic Compounds (VOC) section, for field 'Would you like to use the VOC percentages entered for all areas' error message 'This is a required field.' is displayed
	Then In the VOC - Ozone Transport Commission Section, set the option in section: 'Would you like to use the VOC percentages entered for all areas (e.g. country, state, local) for comparison?': to: Yes
	Then in the Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB) page I click Continue




