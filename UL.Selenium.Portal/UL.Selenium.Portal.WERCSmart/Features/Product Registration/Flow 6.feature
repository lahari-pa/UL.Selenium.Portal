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
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:RegulatoryDocumentsToProvide
@PhysicalAndChemicalProp
@Ingredients
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:InventoryStatusProp65
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:TransportationDetails1
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:VOC_OzoneTransportCommission
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:VOC_Summary
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:AdditionalDocumentsToProvide
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:OptionalComments
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:DataAcceptance
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:Summary
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:ProductInformation
@run_Flow6
@StepsPrototype
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:Retailer
@SafetyDataSheetAuthoring
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:PesticideDetailsUS
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:USDepartamentOfTransportationDOT
@RegulatoryInformation3
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:ProductInformation
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:AdditionalDocumentsToProvide


Feature: Flow 6

@TestCase:78731
Scenario: [78731] Insecticide - Crawling Bug - Aerosol (RU001005) - 6A

#Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Given I log in with the account saved in TReVor as: ProductAccount

Then The home screen should load

Given I generate a random UPC number and save as: UPC78731

Given I delete all products with UPC Number: saved as UPC78731

#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration '
	Then in the New Product page, I click Continue

Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Insecticide - Crawling Bug - Aerosol

Then I save the product information as: TestCase78731

Given I call Shared Step 57502 (Product Information - Preventing, Destroying, Repelling, Mitigating Pests, US only, NO to everything else - Continue - Happy Path)

Given I call Shared Step 57111 (Enter Product Data for Physical State - Aerosol only)

Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Propane       | 100     | false               | false       |            |

#Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
Given I should see the Inventory Status, Prop 65 (US) Page
	Then In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	Then In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page I click Continue

#Given I call Shared Step 57589 (Enter Pesticide Data - United States (without EPA number))Given I should see the Pesticide Details - U.S. Page
	Then In the Pesticide Details - U.S. Section, in 'Product has an Environmental Protection Agency (EPA) Registration Number' enter No
	Then In the Pesticide Details - U.S. Section, in 'Product has a State Registration' enter No
	Then In the Pesticide Details - U.S. Section, in 'Select the applicable exemption' enter Food Based Pesticides - Exempt from EPA Registration
	Then in the Pesticide Details - U.S. page I click Continue


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

#	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Amazon
	Then I should be on the Retailer Page
	And In the Retailer Section, click 'Add Retailers' button
	And In the Select Retailers window, select retailer: Amazon
	And In the Select Retailers window, click 'Done' button
	Then in the Retailer page, I click Continue

Then I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC78731, container type: Aerosol Can and size: 1

#Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
	Then in the Regulatory Documents to Provide page I click Continue

Given I call shared step 65961 (Additional Documents to Provide - Upload Full Product Label - Continue.

Given in the Optional Reports and Documents Available for Purchase page I click Continue

#Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
#| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Product's Dispensing Method | Partition Coefficient |
#| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | Aerosol                     | 41.3005               |
	Then I should be on the Safety Data Sheet Authoring - Additional Data (Optional) Page
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Personal Protection Equipment Recommended (select)' to: Gloves
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Autoignition Temperature (°C)' enter text: 501.827328
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Minimum Ignition Energy (mJ)' enter text: 10.00001
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Viscosity' enter text: 10.28
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Appearance' to: Brown
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor' to: Orange
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor Threshold' to: No data available
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Partition Coefficient' enter text: 41.3005
	Then in the Safety Data Sheet Authoring - Additional Data (Optional) page, I click Continue

#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Comment Text
Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Insecticide - Crawling Bug - Aerosol

#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase78731

Then I navigate to the Home Page
Then In the Product Grid, delete the product saved as: TestCase78731
@ignore
@TestCase:57711
Scenario: [57711] Antifungal - Aerosol (RU000050) - 6A

#Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Given I log in with the account saved in TReVor as: ProductAccount

Then The home screen should load

Given I generate a random UPC number and save as: UPC57711

Given I delete all products with UPC Number: saved as UPC57711

	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration '
	Given in the New Product page I click Continue
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Antifungal - Aerosol

Then I save the product information as: TestCase57711

#Given I call Shared Step 57865 (Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
Given I should see the Product Information Page
	Then In the Product Information Section, set the option in section: 'Which best describes your product, including when FIFRA 25(b) Exempt' to: Product is intended for preventing, destroying, repelling, or mitigating pests (including insects, rodents, mold, virus, bacteria, and other micro-organisms)
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue

Given I call Shared Step 57111 (Enter Product Data for Physical State - Aerosol only)

Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Propane       | 100     | false               | false       |            |


Given I set 'Prop65' to: No
Given in the Waste Classification Data page I click Continue


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

#Given I call Shared Step 57589 (Enter Pesticide Data - United States (without EPA number))
Given I should see the Pesticide Details - U.S. Page
	Then In the Pesticide Details - U.S. Section, in 'Product has an Environmental Protection Agency (EPA) Registration Number' enter No
	Then In the Pesticide Details - U.S. Section, in 'Product has a State Registration' enter No
	Then In the Pesticide Details - U.S. Section, in 'Select the applicable exemption' enter Food Based Pesticides - Exempt from EPA Registration
	Then in the Pesticide Details - U.S. page I click Continue

#Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)

Given I call Shared Step 57980 (Transportation Details - Yes only option - Select IMDG, Fully regulated - Continue - Happy Path)

Given I call Shared Step 57981 (Transportation Details - UN Number Water (IMDG) - Enter UN Number and select other data - Continue - Happy Path) : 1954

#Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)

Given I call Shared Step 57923 (Volatile Organic Compound (VOC) Step - enter OTC and CARB - Yes for state values)
| Product granted Alternative Control Plan | Amount of VOC by CARB | Amount of VOC by OTC Model | VOC for states |
| No                                       | 2                     | 2                          | Yes            |

Given in the Volatile Organic Compound Summary page I click Continue

#Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Amazon

#Then I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC57711, container type: Aerosol Can and size: 33

#Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	Then I should be on the Retailer Page
	Then in the Retailer page, I click Continue

#Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
	Then in the Regulatory Documents to Provide page I click Continue

#Given I call Shared Step 78801 (Additional Documents to Provide - VOC and Product Label)

Given In the Additional Documents to Provide screen I upload label for section 'Provide Full Product Label (required)'

Given in the Optional Reports and Documents Available for Purchase page I click Continue

#Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
#| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Product's Dispensing Method | Partition Coefficient |
#| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | Aerosol                     | 41.3005               |
Then I should be on the Safety Data Sheet Authoring - Additional Data (Optional) Page
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Personal Protection Equipment Recommended (select)' to: Gloves
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Autoignition Temperature (°C)' enter text: 800
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Minimum Ignition Energy (mJ)' enter text: 99
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Viscosity' enter text: 60
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Appearance' to: Clear
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor' to: Odorless
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor Threshold' to: No data available
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Partition Coefficient' enter text: 10
	Then in the Safety Data Sheet Authoring - Additional Data (Optional) page, I click Continue
	Given in the Optional Comments page I click Continue
#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Comment Text
Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

Then In the Data Acceptance page I select Agreed

Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Antifungal - Aerosol

Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase57711


@TestCase:57647
Scenario: [57647] Insecticide-Flying Bug-Moth Proofing Product containing <98% Para-Dichlorobenzene - (RU001000) - 2S
    Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration '
	Then in the New Product page, I click Continue

	And I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Insecticide-Flying Bug-Moth Proofing Product containing >98% Para-Dichlorobenzene
	Then I generate a random UPC number and save as: UPC87914
	Then I save the product information as: TestCase87914
	#Given I call Shared Step 57865 (Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
	Given I should see the Product Information Page
	Then In the Product Information Section, set the option in section: 'Which best describes your product, including when FIFRA 25(b) Exempt' to: Product is intended for preventing, destroying, repelling, or mitigating pests (including insects, rodents, mold, virus, bacteria, and other micro-organisms)
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue

	And I set the Primary Physical State to be: Solid
	And I set the Secondary Physical State to be: Solid
	And I set the When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5? option to: No
	Given I click continue
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
	| CASNumber | ComponentName       | Percent | PublicallyDisclosed | PublicName | TradeSecret |
	|           | Potassium hydroxide | 100     | false               |            | false       |
	#And I call Shared Step 132370 (Waste Classification Data - TSCA (Random) - Prop 65 (No) - Continue - Happy Path)
	Given I should see the Inventory Status, Prop 65 (US) Page
	Then In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	Then In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page I click Continue

	#Given I call Shared Step 57589 (Enter Pesticide Data - United States (without EPA number))
	Given I should see the Pesticide Details - U.S. Page
	Then In the Pesticide Details - U.S. Section, in 'Product has an Environmental Protection Agency (EPA) Registration Number' enter No
	Then In the Pesticide Details - U.S. Section, in 'Product has a State Registration' enter No
	Then In the Pesticide Details - U.S. Section, in 'Select the applicable exemption' enter Food Based Pesticides - Exempt from EPA Registration
	Then in the Pesticide Details - U.S. page I click Continue

	#Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	Given I should see the Transportation Details 1 Page
	Then In the Transportation Details 1 Section, set the option in section: 'Product is Regulated for Transport': to: Yes
	Then In the Transportation Details 1 Section, set the option in section: 'Select all modes of transport that you've classified the product for': to: DOT
	Then In the Transportation Details 1 Section, set the option for DOT mode of transport to: Shipping with limited quantity
	Then in the Transportation Details 1 page I click Continue

	#Given I call Shared Step 34455 (U.S. Department of Transportation (DOT) Classification - Enter all valid data)
	Given I should see the U.S. Department of Transportation (DOT) Classification Page
	Then In the U.S. Department of Transportation (DOT) Classification Section, set the option in section: 'UN Number': to: UN3159
	Then In the U.S. Department of Transportation (DOT) Classification Section, set the option in section: 'Proper Shipping Name': to: 1,1,1,2-Tetrafluoroethane
	Then In the U.S. Department of Transportation (DOT) Classification Section, set the option in section: 'Technical Name (if applicable)': to: Technical Test Name
	Then In the U.S. Department of Transportation (DOT) Classification Section, set the option in section: 'Hazard Class': to: 2.2
	Then In the U.S. Department of Transportation (DOT) Classification Section, set the option in section: 'Packing Group': to: None
	Then in the U.S. Department of Transportation (DOT) Classification page I click Continue

	#Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Staples
	Given I should see the Retailer Page
	Then In the Retailer Section, click 'Add Retailers' button
	Then In the Select Retailers window, select retailer: Staples
	Then In the Select Retailers window, click 'Done' button
	Then in the Retailer page I click Continue

	Then I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC87914, container type: Cardboard and size: 33
	#Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
	Then in the Regulatory Documents to Provide page I click Continue

	#Given I call Shared Step 60931 (Additional Documents to Provide - Exemption - Special Permit - Product Label)
	Given I should see the Additional Documents to Provide Page
	Then I upload PDF document to Upload Transportation Exemption Letter or Special Permit field
	Then I upload PDF document to Provide Full Product Label (required) field
	Then in the Additional Documents to Provide page I click Continue

	And in the Optional Reports and Documents Available for Purchase page I click Continue
#	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
#		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient | Product's Dispensing Method |
#		| Mask                          | 150                      | 44                      | 10.7      | White      | Floral | No data available | 12                    | Aerosol                     |
	Then I should be on the Safety Data Sheet Authoring - Additional Data (Optional) Page
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Personal Protection Equipment Recommended (select)' to: Mask
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Autoignition Temperature (°C)' enter text: 150
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Minimum Ignition Energy (mJ)' enter text: 44
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Viscosity' enter text: 10.7
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Appearance' to: White
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor' to: Floral
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor Threshold' to: No data available
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Partition Coefficient' enter text: 12
	Then in the Safety Data Sheet Authoring - Additional Data (Optional) page, I click Continue


	#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: User added Comments Text 58736. !"�$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	And I call Shared Step 73956 (Go to Summary and verify data) with product type: Insecticide-Flying Bug-Moth Proofing Product containing >98% Para-Dichlorobenzene
	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase87914
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase87914

# Created by Saikiran Chittampally
@TestCase:57986
Scenario: [57986] Footwear or Leather Care Product - All other forms - (RU000746) - 4All - 4G
	#Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
    Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration '
	Given in the New Product page I click Continue
	#And I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Footwear or Leather Care Product - All other forms
	And I should see the The Product Page
    And In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Footwear or Leather Care Product - All other forms
    And In the Product Section, set the option in section: 'Type of Product (select)' to: Footwear or Leather Care Product - All other forms
	And in the The Product page I click Continue
	Then I save the product information as: TestCase57986
	#228838  Product Information - Applicable Only to Footwear or Leather Care Product - All Other Forms (RU000746)                                             
	And I should see the Product Information Page
	Then In the Product Information Section, confirm following options should be exclusively displayed for section: 'Which best describes your product, including when FIFRA 25(b) Exempt'
		| Option                                                                                                                                                                               |
		| Product is intended for preventing, destroying, repelling, or mitigating pests (including insects, rodents, mold, virus, bacteria, and other micro-organisms)                        |
		| Product is intended for use as a plant regulator (controls growth), defoliant (removes leaves), or desiccant (dehydrates plants to control growth)                                   |
		| Product is not a pesticide and does not make or imply a pesticidal claim on the labeling or in the product description (ex. kills, sterilizes, disinfects, sanitizes, antimicrobial) |
	Then In the Product Information Section, set the option in section: 'Which best describes your product, including when FIFRA 25(b) Exempt' to: Product is not a pesticide and does not make or imply a pesticidal claim on the labeling or in the product description (ex. kills, sterilizes, disinfects, sanitizes, antimicrobial)
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue
	#Given I call Shared Step 228844 (Physical and Chemical Properties - Aerosol, solid, liquid & Gas available - Select Solid - Continue - Happy Path)
	And I should see the Physical and Chemical Properties Page
	Then In the Physical and Chemical Properties Section, for section: 'Primary Physical State': the following options should be displayed exclusively:
	| Option  |
	| Aerosol |
	| Gas     |
	| Liquid  |
	| Solid   |
	And In the Physical and Chemical Properties Section, set the option in section: 'Primary Physical State' to: Aerosol
	Then In the Physical and Chemical Properties Section, the confirm section: 'Secondary Physical State' is displayed
	And In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Liquid spray
	Then In the Physical and Chemical Properties Section, the confirm section: 'pH' is displayed
	Then In the Physical and Chemical Properties Section, for section: 'When the product has a flammable propellant, or contains ingredients with a flash point below 60⁰C then': the following options should be displayed exclusively:
	| Option                                                                                                |
	| This product is classified as a D001 Hazardous Waste under RCRA (as per Section 13 or 15 of the SDS). |
	| This product is classified as a D003 Hazardous Waste under RCRA.                                      |
	| This product is not classified as D001 or D003 Hazardous Waste under RCRA                             |
	And In the Physical and Chemical Properties Section, set the option in section: 'Primary Physical State' to: Gas
	And In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Gas
	And In the Physical and Chemical Properties Section, set the option in section: 'Primary Physical State' to: Liquid
	Then In the Physical and Chemical Properties Section, the confirm section: 'Secondary Physical State' is displayed
	Then In the Physical and Chemical Properties Section, the confirm section: 'pH' is displayed
	Then In the Physical and Chemical Properties Section, the confirm section: 'Relative Density' is displayed
	Then In the Physical and Chemical Properties Section, the confirm section: 'Boiling Point (in Celsius)' is displayed
	Then In the Physical and Chemical Properties Section, the confirm section: 'Flash Point (in Celsius)' is displayed
	Then In the Physical and Chemical Properties Section, the confirm section: 'Flash Point Testing Method Used' is displayed
	And In the Physical and Chemical Properties Section, set the option in section: 'Primary Physical State' to: Solid
	And In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	And In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid Gel Consistency
	And in the Physical and Chemical Properties page I click Continue
	And I should see the Ingredients Page
	Then In the Ingredients section, add component with component name: Paraffin
	Then In the Ingredients Table row with component name: Paraffin, in Percent column text input enter: 25
	Then In the Ingredients section, add component with component name: Isostearic Acid
	Then In the Ingredients Table row with component name: Isostearic Acid, in Percent column text input enter: 10
	Then In the Ingredients section, add component with component name: Toluene
	Then In the Ingredients Table row with component name: Toluene, in Percent column text input enter: 23
	Then In the Ingredients section, add component with component name: Water
	Then In the Ingredients Table row with component name: Water, in Percent column text input enter: 42
	And in the Ingredients page I click Continue
	#I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given I should see the Inventory Status, Prop 65 (US) Page
	Given In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	Given In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Given in the Inventory Status, Prop 65 (US) page I click Continue
	#Given I call Shared Step 57984 (Transportation Details - All options available - Select Not regulated - Continue - Happy Path)
	And I should see the Transportation Details 1 Page
	Given In the Transportation Details 1 Section, set the option in section: 'Product is Regulated for Transport': to: Not Regulated
	And in the Transportation Details 1 page I click Continue
	#Given I call Shared Step 57923 (Volatile Organic Compound (VOC) Step - enter OTC and CARB - Yes for state values)
	#		| Product granted Alternative Control Plan | Amount of VOC by CARB | Amount of VOC by OTC Model | VOC for states | 
	#		| No                                       | 15                     | 15                         | Yes           | 
	Given In the VOC - Ozone Transport Commission Section, set the option in section: 'Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations.': to: No
	Given In the VOC - Ozone Transport Commission Section, set the option in section: 'Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the CARB': to: 15
	Given In the VOC - Ozone Transport Commission Section, set the option in section: 'Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the OTC Model Rule': to: 15
	Given In the VOC - Ozone Transport Commission Section, set the option in section: 'Would you like to use the VOC percentages entered for all areas (e.g. country, state, local) for comparison?': to: Yes
	And I click continue
	#Given I call Shared Step 57801 (Confirm VOC Summary step shown and VOC analysis date is shown - Happy Path)
	Given I should see the Volatile Organic Compound Summary Page
	Given In the Volatile Organic Compound Summary Section, confirm that I see todays 'VOC Analysis Date'
	Given In the Volatile Organic Compound Summary Section, for 'Your acknowledgement of this registration includes that your product..' set 'Yes, I Acknowledge'
	Given in the Volatile Organic Compound Summary page I click Continue
	#Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	Given I should see the Retailer Page
	Given in the Retailer page I click Continue
	#Then I call Shared Step 78080 (Regulatory Documents to Provide - Upload OSHA SDS)
	And I should see the Regulatory Documents to Provide Page
	Given In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Yes, I certify that I have an OSHA-compliant SDS for this product and would like to upload it.
	Given In the Regulatory Documents to Provide Section, upload file in section: 'OSHA SDS'
	And in the Regulatory Documents to Provide page I click Continue
	#Given I call Shared Step 60567 (Upload Product Label only)
	Given I should see the Additional Documents to Provide Page
	Given in the Additional Documents to Provide page I click Continue
	Then In the Additional Documents to Provide, section 'Volatile Organic Compounds' error message should display: Document is required: Product Label
	Then In the Additional Documents to Provide, upload PDF document for section: Volatile Organic Compounds - Product Label
	Given in the Regulatory Documents to Provide page I click Continue
	# Optional Reports and Documents Available for Purchase Page
	And I should see the Optional Reports and Documents Available for Purchase Page
	Then in the Optional Reports and Documents Available for Purchase page I click Continue
	#And I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Comments Field Text
	And I should see the Optional Comments Page
	Then In the Optional Comments Section, section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' is available
	Then in the Optional Comments page I click Continue
	#Given I call Shared Step 73956 (Go to Summary and verify data) with product type:  Footwear or Leather Care Product - All other forms
	Given I should see the Data Acceptance Page
	Given In the Data Acceptance Section, click 'Summary' button
	Given I switch to the tab with Data Summary page
	Given In the Summary Page, the 'Type of Product (select)' section should be showing the following value: Footwear or Leather Care Product - All other forms
	Given I close the tab with Data Summary page
    Given I should see the Data Acceptance Page
	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase57986
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase57986
