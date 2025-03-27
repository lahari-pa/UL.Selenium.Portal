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
@SHA
@PaymentMethods
@NewProduct
@StepsPrototype
@run_NewProduct
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:ProductInformation
@PhysicalAndChemicalProp
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:RegulatoryDocumentsToProvide
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:OptionalComments
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:DataAcceptance
@Ingredients
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:InventoryStatusProp65
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:Retailer
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:NewProduct
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:TheProduct
@Steps_ProductPrototype
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:ProductInformation
Feature: New Product

@TestCase:82750
Scenario: [82750] Copy from an Existing Registration validation
	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Copy from an Existing Registration
	Then in the New Product page, I click Continue
	Then In the New Product Section, confirm for section: 'Please select the source product' error is displayed: This is a required field.


@TestCase:87295
Scenario: [87295] 3rd party Ingredients - Informational Message
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration '
	Then in the New Product page, I click Continue

	#Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk
	Then I should be on the The Product Page
	And In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Chalk_#87295
	And In the Product Section, set the option in section: 'Type of Product (select)' to: Chalk
	Then in the The Product page, I click Continue

	Then I save the product information as: TestCase87295
	#Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Given I should see the Product Information Page
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)' to: No
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue

	#Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I should see the Physical and Chemical Properties Page
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' should be showing the option: Solid
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' confirm option is selected: Solid
	Then In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
	Then In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Then In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
	Then in the Physical and Chemical Properties page I click Continue

	Given I call Shared Step 65447 Ingredients - Add any chemical - DO Not click Continue
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| WPS           | 100     |                     |             |            |
	Given I click continue
	Then a Warning popup dialog should appear with the message: Your product contains a 3rd-Party Formula that may need Data Tier Consent, or if Consent has been accepted by the Formulator, has no ingredients that are indicated to be Public. A notification has been provided to the Formulator to revisit their registration and resubmit if necessary. You may continue with your registration. Should the 3rd-Party Formula be revised, your registration will be updated accordingly and revised scoring will occur. No action is required from you.
	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase87295
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase87295
@ignore
@TestCase:74944
Scenario: [74944] BCP - Contains Lithium Primary packaged with the product - Lithium Battery Transportation step - question validations
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	And I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Camera w/Battery
	Then I save the product information as: TestCase74944
	And I call Shared Step 70393 (Product Information - With marketed for use by a Child - Direct Ship - Private Label questions only)
	#And I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I should see the Inventory Status, Prop 65 (US) Page
	Then In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	Then In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page I click Continue

	Then I should see the Product Includes Battery Page
	Given I set the Indicate how battery is packaged option to: The battery is shipped with but not included in my product.
	Given I add the following batteries:
		| Battery Type     | Manufacturer                                                  | Quantity of Batteries per Package | Quantity of Batteries to Operate Product | Saved As       |
		| Lithium Primary  | Pau Lithium Primary Battery by The WERCS LTD (WPS ID 1549664) | 4                               | 4                                  | lithiumbattery |
	Given I click continue
	And I call Shared Step 48369 (Toxicity Characteristics Leaching Procedure (TCLP) - No to ALL With Copper)
	And I call Shared Step 58189 (Answer Electronic Equipment questions - With Cathode Ray - No to all)
	Given I click continue
	Given I check for an error in the following fields in the 'Lithium Battery Transportation' Section
		| Field                                                                              |
		| For U.S. Department of Transportation (DOT), indicate the transport classification |
		| For Marine transport (IMDG), indicate the classification                           |
		| For Air transport (IATA), indicate the classification                              |
		| For Canada's Transportation of Dangerous Goods (TDG), indicate the classification  |
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase74944

@ignore
#CBD Registration Guidance popup can be tested only in staging
@TestCase:149421
Scenario: [149421] CBD - Registration with CBD Ingredient in Formulation
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
	Given I generate a random UPC number and save as: UPC149421
	Then I save the product information as: TestCase149421
	#Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Given I should see the Product Information Page
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)' to: No
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue

	#Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I should see the Physical and Chemical Properties Page
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' should be showing the option: Solid
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' confirm option is selected: Solid
	Then In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
	Then In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Then In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
	Then in the Physical and Chemical Properties page I click Continue

	#Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	#Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| CASNumber | ComponentName | Percent | PublicallyDisclosed | PublicName | TradeSecret |
		| 1244-58-2 |               | 50      |                     |            |             |
		|           | Chalk         | 50      |                     |            |             |
	Given I confirm the CBD Registration Guidance popup appears in the Ingredients Page with the correct text
	Given I click the link in the CBD Registration Guidance popup
	Given I switch to the tab: https://www.fda.gov/news-events/public-health-focus/fda-regulation-cannabis-and-cannabis-derived-products-including-cannabidiol-cbd
	Given I check that the current URL contains: https://www.fda.gov/news-events/public-health-focus/fda-regulation-cannabis-and-cannabis-derived-products-including-cannabidiol-cbd
	Given I close the current tab
	Given I close the CBD Registration Guidance popup in the Ingredients Page
	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	#Given I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue) for
	#| Retailer |
	#| CVS      |
	#Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC149421, container type: Plastic Container and size: 15.2
	#Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	#Given in the Additional Documents to Provide page I click Continue
	#Given in the Optional Reports and Documents Available for Purchase page I click Continue
	#Given I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
	#| Appearance | Autoignition Temperature | Minimum Ignition Energy | Odor  | Odor Threshold           | Partition Coefficient | Personal Protection Equipment | Viscosity |
	#| Amber      |                          |                         | Apple | No information available | 4                     |                               |           |
	#Given I click continue
	#Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	#And In the Purchase Summary screen I confirm the Purchase Summary header is displayed
	#And In the Purchase Summary screen if Product Billing is displayed I click Confirm Order
	#Given I call Shared Step 65080b (Login to Studio as user saved as: SHAQAAuto16 and Open SHA manager)
	#Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Submitted Status for saved as: TestCase149421)
	#Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase149421)
	#Given I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase149421)
	#Given I call Shared Step 75347 (WPS Studio - PD+ - set all data and publish using rule and Doc queue - CKLT, NGHS and SBCS) for product saved as: TestCase149421
	#Given I call Shared Step 59066 (Go to SHA Manager)
	#Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Assigned Status for saved as: TestCase149421)
	#Given I call Shared Step 75347 (WPS Studio - PD+ - set all data and publish using rule and Doc queue - CKLT, NGHS and SBCS) for product saved as: TestCase149421
	#Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Accepted Status for saved as: TestCase149421)
	#Given I call Shared Step 51664 (SHA - Accepted Product - set Retailers to Completed for saved as: TestCase149421) for
	#| Retailer |
	#| CVS      |

@tfs_design
@ignore
@TestCase:145400
Scenario: [145400] Battery Containing Mercury - RU000729 - Uploaded Documents
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Battery Containing Mercury
	Given I generate a random UPC number and save as: UPC145400
	Then I save the product information as: TestCase145400
	Given I call Shared Step 102767 (Product Information (Battery flow - not Lithium) - OSHA (No), DSV (No), PLP (No), GNFR (No))
	Given I call Shared Step 59927 (Primary Physical State > Solid only available – Without Water Solubility question)
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| CASNumber | ComponentName | Percent | PublicallyDisclosed | PublicName | TradeSecret |
		|           | mercury       | 100     |                     |            |             |
	Given I call Shared Step 145355 Formulation > Batteries - Select Granted - Continue
	Given I call Shared Step 104276 (Enter Regulatory Information - TSCA, CEPA, Not Prop 65)
	#Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Amazon
	Given I should see the Retailer Page
	Then In the Retailer Section, click 'Add Retailers' button
	Then In the Select Retailers window, select retailer: Amazon
	Then In the Select Retailers window, click 'Done' button
	Then in the Retailer page I click Continue

	Given I call Shared Step 60826 (Enter Universal Product Code (UPC) - Battery - Confirm Quantity ) for UPC saved as: UPC145400 with container type: Metal Container size: 40.0 and quantity: 100
	Given I call Shared Step 145129 Regulatory Documents to Provide - Upload AIS and CCCR
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Testing the comments text box to make sure it is working properly.
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	#Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given I should see the Data Acceptance Page
	Then In the Data Acceptance Section, check 'Agreed' checkbox
	Then In the Data Acceptance Section, click 'Accept' button

	Given I call Shared Step 65080b (Login to Studio as user saved as: SHAQAAuto16 and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Submitted Status for saved as: TestCase145400)
	And In SHA Manager I select the first product
	And I click the following option in the bottom menu: Review

@ignore
@TestCase:120820
Scenario: [120820] WERCSmart product - Submitted to SHA, Status = Cancelled
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I generate a random UPC number and save as: UPC120820
	Then I save the product information as: TestCase120820
	Then I call Shared Step 57561b (The Product - Enter Product Name: TC 120820 - For RPS - Cancelled Status and select Type of Product): Chalk and add a Random Identifier
	Given I generate a random UPC number and save as: UPC120820
	Then I save the product information as: TestCase120820
	#Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Given I should see the Product Information Page
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)' to: No
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue

	#Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I should see the Physical and Chemical Properties Page
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' should be showing the option: Solid
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' confirm option is selected: Solid
	Then In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
	Then In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Then In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
	Then in the Physical and Chemical Properties page I click Continue

	#Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Chalk
	Given I should see the Ingredients Page
	Then In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	| component name | Chalk       | 100     |                     |               |             |
	Then in the Ingredients page I click Continue

	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given I call shared step 120812 (Retailer - Add retailers for RPS)
	Given I call shared step 120813 (UPC - Add 2 UPCs - including one for CVS RCL and Add Home Depot OMSID for UPC: CVS, container type: Metal Container and size: 40)
	Given I call shared step 51609 (CVS RCL - Yes I wish to continue with registration - Continue)
	Given I call shared step 52131 (CVS RCL Information - add Other where available and all other data)
	Given I call Shared Step 78080 (Regulatory Documents to Provide - Upload OSHA SDS)
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	#Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given I should see the Data Acceptance Page
	Then In the Data Acceptance Section, check 'Agreed' checkbox
	Then In the Data Acceptance Section, click 'Accept' button

	Given If purchase details are showing click confirm order
	Given In the Thank You screen I click Home
	Given I call Shared Step 65080b (Login to Studio as user saved as: SHAQAAuto16 and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase120820)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase120820 and its status is: Submitted
	And I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase120820)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase120820)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase120820 and its status is: Assigned
	Given I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase120820)
	Given I call Shared Step 59066 (Go to SHA Manager)
	Given I call Shared Step 75669 (SHA - Assigned Status - Set to Cancelled for product saved as: TestCase120820)
		| Retailer  |
		| Walgreens |
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase120820)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase120820 and its status is: Cancelled

@TestCase:128694
Scenario: [128694] DSV Option Available for Electronic - Peripherals - RU001162

	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load

#	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration '
	Then in the New Product page, I click Continue

	#Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Peripherals (Keyboard, Mouse, Trackball) without Battery
	And In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Peripherals (Keyboard, Mouse, Trackball) without Battery_#128694
	And In the Product Section, set the option in section: 'Type of Product (select)' to: Peripherals (Keyboard, Mouse, Trackball) without Battery
	Then in the The Product page, I click Continue

	Then I save the product information as: TestCase128694

	And In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, for section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer...': the following options should be displayed:
	| Option |
	| Yes    |
	| No	 |

	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase128694
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase128694

@TestCase:128721
Scenario: [128721] DSV Option Available for Appliance - Hot Water Tank (Standard, no electronic components) - RU001206

	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load

	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration '
	Then in the New Product page, I click Continue
	 
	#Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Appliance - Hot Water Tank (Standard, no electronic components)
	Then I should be on the The Product Page
	And In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Appliance - Hot Water Tank (Standard, no electronic components)_#128721
	And In the Product Section, set the option in section: 'Type of Product (select)' to: Appliance - Hot Water Tank (Standard, no electronic components)
	Then in the The Product page, I click Continue

	Then I save the product information as: TestCase128721

	And In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, for section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer...': the following options should be displayed:
	| Option |
	| Yes    |
	| No	 |

	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase128721
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase128721

@TestCase:128703
Scenario: [128703] DSV Option Available for Auto Parts - Engine Parts and Components with Electrical Parts -  RU001428

	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load

	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration '
	Then in the New Product page, I click Continue

	#Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Engine Parts and Components with Electrical Parts
	Then I should be on the The Product Page
	And In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Engine Parts and Components with Electrical Parts_#128703
	And In the Product Section, set the option in section: 'Type of Product (select)' to: Engine Parts and Components with Electrical Parts
	Then in the The Product page, I click Continue

	Then I save the product information as: TestCase128703

	And In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, for section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer...': the following options should be displayed:
	| Option |
	| Yes    |
	| No	 |

	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase128703
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase128703

@TestCase:136058
Scenario: [136058] The Product - Industrial Category not available for Selection	
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration '
	Then in the New Product page, I click Continue

	And In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Product Name 

	And In section: Type of Product (select), click search text box
	And In the Product Section, for section 'Type of Product (select)' enter text: For Industrial use only
	Then In the Product Section, for section 'Type of Product (select)' confirm no results are returned
	Then In the Product Section, for section 'Type of Product (select)' clear the search box

	And In the Product Section, for section 'Type of Product (select)' enter text: For Laboratory use only
	Then In the Product Section, for section 'Type of Product (select)' confirm no results are returned
	Then In the Product Section, for section 'Type of Product (select)' clear the search box

	And In the Product Section, for section 'Type of Product (select)' enter text: For Pharmaceutical use only
	Then In the Product Section, for section 'Type of Product (select)' confirm no results are returned
	Then In the Product Section, for section 'Type of Product (select)' clear the search box

	And In the Product Section, for section 'Type of Product (select)' enter text: For Profession use only
	Then In the Product Section, for section 'Type of Product (select)' confirm no results are returned
	Then In the Product Section, for section 'Type of Product (select)' clear the search box

	And In the Product Section, for section 'Type of Product (select)' enter text: For Research and Development use only
	Then In the Product Section, for section 'Type of Product (select)' confirm no results are returned
	Then In the Product Section, for section 'Type of Product (select)' clear the search box



@TestCase:159942
Scenario: [159942] Tire, Off-Road - Pneumatic & Tires Not Intended for Road Use RU001423
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration '
	Then in the New Product page, I click Continue

	Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Tire, Off-Road - Pneumatic & Tires Not Intended for Road Use
	Given I save the product information as: TestCase159942
	Given I set the Select countries the product may be sold in option to: United States
	Given I set the Select countries the product may be sold in option to: Canada
	Given I set the Product is a Retailer's Private Label or Brand option to: No
	Given I click continue
	#Given I call Shared Step 57637 (Regulatory Information 1 - TSCA & CEPA shown, No to PROP 65 - Continue - Happy Path)
	Then I should be on the Inventory Status, Prop 65 (US) Page
	And In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is exempt from TSCA chemical Inventory listing requirements.
	And In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'Canadian Environmental Protection Act (CEPA) status' to: Compliant with Domestic Substances List (DSL)
	And In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No 
	Then in the Inventory Status, Prop 65 (US) page, I click Continue

	Given in the Tire Regulatory Details page I click Continue
	And Product is intended for agricultural use only should be showing the error messages: This is a required field.
	And Weight in kilograms (single unit) should be showing the error messages: This is a required field.
	And Height in inches (single unit) should be showing the error messages: This is a required field.
	Given I set the Product is intended for agricultural use only option to: No
	Given I set the Weight in kilograms (single unit) field to: abc
	And Weight in kilograms (single unit) should be showing the error messages: Enter a valid number
	Given I set the Weight in kilograms (single unit) field to: !@#
	And Weight in kilograms (single unit) should be showing the error messages: Enter a valid number
	Given I set the Weight in kilograms (single unit) field to: 12
	Given I Select a height from the drop down list
	Given I click continue
	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase159942
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase159942
