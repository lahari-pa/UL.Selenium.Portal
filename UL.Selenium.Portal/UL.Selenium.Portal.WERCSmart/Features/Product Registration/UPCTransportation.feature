@Shared
@NewProduct
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
@ProductSetUp
@SHA
@Studio
@ForwardProductRegistration
@ProductSetUp
@SupplierReports
@CreateProducts
@ViewUpcs
@Solutions
@run_UPCTransportation
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:RegulatoryDocumentsToProvide
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:OptionalComments
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:DataAcceptance
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:NewProduct
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:TheProduct
@Ingredients

@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:InventoryStatusProp65

Feature: UPCTransportation

@ignore
@TestCase:122305
Scenario: [122305] UPC Transportation options are present if product-level options are present
	#Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I log in with the account saved in TReVor as: ProductAccount
	Given I generate a random UPC number and save as: UPC112305
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Given in the New Product page I click Continue
	Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bleach
	Given I save the product information as: TestCase122305
	And I call Shared Step 74340 (Product Information - Pesticide= Not considered, SOLD=US, everything else = No - Continue)
	Given I call Shared Step 74760 (Physical and Chemical Properties - Select Liquid as primary physical state and enter all required data)
          | Boiling Point (in Celsius) | Flash Point (in Celsius) | Flash Point Testing Method Used | pH | Primary Physical State | Secondary Physical State | Select the best Water Solubility description | Relative Density |
          | 2                          | 66                       | Closed cup method               | 2  | Liquid                 | Liquid                   | Dispersible                                  | 2                |
	#Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Chlorine
	Given I should see the Ingredients Page
	Then In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	| component name | Chlorine       | 100     |                     |               |             |
	Then in the Ingredients page I click Continue

	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given I should see the Transportation Details 1 Page
	Given I set the Product is Regulated for Transport field to: Yes
	Given I call Shared Step 65698 (Transport - Select DOT & Limited Shipping - No Continue)
	Given I call Shared Step 65700 (Transportation Details 1 - Select IATA & Limited Shipping)
	Given I click continue
	Given I call Shared Step 65705 (Transportation - DOT UN step - Enter UN1950, select Aerosols,  2.1, None, add technical name, Click Continue)
	Given I should see the International Air Transport (IATA) Classification Page
	Given I check the checkbox with description: Copy information from my U.S. Department of Transportation data
	Given I click continue
	Given I select the following retailers in the Select Retailers popup list view:
		| Retailer  |
		| Walgreens |
	Then I click Done on Select Retailers window
	Then I click continue
	Given I call Shared Step 87647 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC112305, container type: Plastic Container and size: 2 do not click continue
	Given I ensure that there is a column in the Add UPC table called Transportation
	Given I ensure that DOT is listed as Shipping with limited quantity
	Given I ensure that IATA is listed as Shipping with limited quantity
	Given I ensure that I cannot select IATA at Shipping with consumer commodity
	Given I ensure that the IMDG checkbox is not present in the UPC Transportation column
	Given I ensure that the TDG checkbox is not present in the UPC Transportation column
	Given I navigate to the home page
	Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase122305

@ignore
@TestCase:122382
Scenario: [122382] UPC Transportation - UPC Reset Popup
	#Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I log in with the account saved in TReVor as: ProductAccount
	Given I generate a random UPC number and save as: UPC122382
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Given in the New Product page I click Continue
	Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bleach
	Given I save the product information as: TestCase122382
	And I call Shared Step 74340 (Product Information - Pesticide= Not considered, SOLD=US, everything else = No - Continue)
	Given I call Shared Step 74760 (Physical and Chemical Properties - Select Liquid as primary physical state and enter all required data)
		| Boiling Point (in Celsius) | Flash Point (in Celsius) | Flash Point Testing Method Used | pH | Primary Physical State | Secondary Physical State | Select the best Water Solubility description | Relative Density |
        | 2                          | 66                       | Closed cup method               | 2  | Liquid                 | Liquid                   | Dispersible                                  | 2                |
	#Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Chlorine
	Given I should see the Ingredients Page
	Then In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	| component name | Chlorine       | 100     |                     |               |             |
	Then in the Ingredients page I click Continue

	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given I should see the Transportation Details 1 Page
	Given I set the Product is Regulated for Transport field to: Yes
	Given I call Shared Step 65698 (Transport - Select DOT & Limited Shipping - No Continue)
	Given I call Shared Step 65700 (Transportation Details 1 - Select IATA & Limited Shipping)
	And I call Shared Step 65699 (Transport - Select IMDG & Limited Shipping - No Continue)
	And I call Shared Step 65701 (Transport - Select TDG & Limited Shipping - No Continue)
	Given I click continue

	Given I should see the International Air Transport (IATA) Classification Page
    And I call Shared Step 65705 (Transportation - DOT UN step - Enter UN1950, select Aerosols,  2.1, None, add technical name, Click Continue)
	Given I check the checkbox with description: Copy information from my U.S. Department of Transportation data

	Given I click continue
	Given I should see the International Marine (IMDG) Classification Page
	Given I check the checkbox with description: Copy information from my U.S. Department of Transportation data	

	Given I click continue
	Given I should see the Canada - Transportation of Dangerous Goods (TDG) Classification Page
	Given I check the checkbox with description: Copy information from my U.S. Department of Transportation data

	Given I click continue
	Given I select the following retailers in the Select Retailers popup list view:
		| Retailer  |
		| Walgreens |
	Then I click Done on Select Retailers window
	Then I click continue
	Given I call Shared Step 87647 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC122382, container type: Plastic Container and size: 2 do not click continue
	Given At the UPC level, I set DOT to Shipping fully regulated
	Given At the UPC level, I set IATA to Shipping fully regulated
	Given At the UPC level, I set IMDG to Shipping fully regulated
	Given At the UPC level, I set TDG to Shipping fully regulated
	Given I click continue
	Given In the New Product page I click tab: Product Characteristics
	And I click the page heading: Transportation Details 1
	Given In the Transportation Details 1 screen, I unselect all transportation options for DOT
	Given In the Transportation Details 1 screen, I unselect all transportation options for IATA
	
	And I select option: Shipping with consumer commodity under section: Select all modes of transport that you've classified the product for and subsection: DOT

	And I select option: Shipping with consumer commodity under section: Select all modes of transport that you've classified the product for and subsection: IATA
	Given I click Save in The Product Page
	Given I confirm that I see the following text in the modal window popup: You have updated the transportation classification for this product registration. This impacts the UPC-level data for Transportation and the defaults have been adjusted. Be sure to review the UPC-Level transportation settings and update as needed before submitting your registration.
	Given in the modal dialog I click the "OK" button
	Given In the New Product page I click tab: Recipient and UPC Details
	And I click the page heading: Universal Product Code (UPC)

	Given I ensure that DOT is listed as Shipping with consumer commodity
	Given I ensure that IATA is listed as Shipping with consumer commodity

	Given I ensure that IMDG is listed as Shipping with limited quantity
	Given I ensure that TDG is listed as Shipping with limited quantity
	Given I navigate to the home page
	Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase122382


@ignore
@TestCase:122428
Scenario: [122428] UPC Transportation - Forwarding
	#Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I log in with the account saved in TReVor as: ProductAccount
	Given I generate a random UPC number and save as: UPC122428
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Given in the New Product page I click Continue
	Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bleach
	Given I save the product information as: TestCase122428
	And I call Shared Step 74340 (Product Information - Pesticide= Not considered, SOLD=US, everything else = No - Continue)
	Given I call Shared Step 74760 (Physical and Chemical Properties - Select Liquid as primary physical state and enter all required data)
		| Boiling Point (in Celsius) | Flash Point (in Celsius) | Flash Point Testing Method Used | pH | Primary Physical State | Secondary Physical State | Select the best Water Solubility description | Relative Density |
		| 2                          | 55                       | Closed cup method               | 6  | Liquid                 | Liquid                   | Dispersible                                  | 2                |
	#Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Chlorine
	Given I should see the Ingredients Page
	Then In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	| component name | Chlorine       | 100     |                     |               |             |
	Then in the Ingredients page I click Continue

	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given I should see the Transportation Details 1 Page
	Given I set the Product is Regulated for Transport field to: Yes
	Given I call Shared Step 65698 (Transport - Select DOT & Limited Shipping - No Continue)
	Given I call Shared Step 65700 (Transportation Details 1 - Select IATA & Limited Shipping)
	And I call Shared Step 65699 (Transport - Select IMDG & Limited Shipping - No Continue)
	And I call Shared Step 65701 (Transport - Select TDG & Limited Shipping - No Continue)
    Given I click continue
    Given I enter UN1993 - Select data - Continue - Happy Path
    Given I should see the International Air Transport (IATA) Classification Page
    Given I check the checkbox with description: Copy information from my U.S. Department of Transportation data
    And I call Shared Step 65705 (Transportation - DOT UN step - Enter UN1950, select Aerosols,  2.1, None, add technical name, Click Continue)
   	Given I click continue

	Given I should see the International Marine (IMDG) Classification Page
	Given I check the checkbox with description: Copy information from my U.S. Department of Transportation data

	Given I click continue
	Given I should see the Canada - Transportation of Dangerous Goods (TDG) Classification Page
	Given I check the checkbox with description: Copy information from my U.S. Department of Transportation data
	
	Given I click continue
	Given I select the following retailers in the Select Retailers popup list view:
		| Retailer  |
		| Walgreens |
	Then I click Done on Select Retailers window
	Then I click continue
	And I call Shared Step 85909 (UPC - Confirm Package type link and drop down not shown - Add UPC data - Continue) for UPC: saved as UPC122428, container type: Plastic Container and size: 12 click continue
	#Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
	Then in the Regulatory Documents to Provide page I click Continue

	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Appearance | Autoignition Temperature | Minimum Ignition Energy | Odor     | Odor Threshold    | Partition Coefficient | Personal Protection Equipment | Viscosity |
		| Black      | 300                      | 1.005                   | Odorless | No data available | 10                    | Mask                          | 20        |
	#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	#Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given I should see the Data Acceptance Page
	Then In the Data Acceptance Section, check 'Agreed' checkbox
	Then In the Data Acceptance Section, click 'Accept' button

	Given If purchase details are showing click confirm order
	Given I wait for 5 seconds
	Given I navigate to the home page
	And I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Submitted Status for saved as: TestCase122428)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase122428 and its status is: Submitted
	Given I navigate to the landing page
	#Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I log in with the account saved in TReVor as: ProductAccount
	Given I search for the product saved as: TestCase122428
	Given I call Shared Step 75130 - Bulk Actions - Select Forward Product Registration
	Given I enter the text: saved as TestCase122428 in the 'Search by WPS ID or Product Name' field
	Given In the Foward Product Registration Screen I should see product: saved as TestCase122428
	Given In the Foward Product Registration Screen I Select the product: saved as TestCase122428
	Given I click continue on the Forward Product Registration page
	Given In the Forward Product Registration Screen I select the first retailer that does not require additional data and is not: Walgreens under Other Retailers and save it as: Retailer122428
	Given I click continue on the Forward Product Registration page
	Given I select the first product under the Select UPCs tab
	Given In Forward Product Registration, I ensure that the Select UPCs table has a Transportation column
	Given In Forward Product Registration, I ensure that DOT is listed as Shipping with limited quantity
	Given In Forward Product Registration, I ensure that IATA is listed as Shipping with limited quantity
	Given In Forward Product Registration, I ensure that IMDG is listed as Shipping with limited quantity
	Given In Forward Product Registration, I ensure that TDG is listed as Shipping with limited quantity
	Given I select Edit for the first UPC in Select UPCs tab
	Given I confirm that Transportation is shown
	And In the Forwarding Edit popup, I confirm that DOT is listed at Shipping with limited quantity
	And In the Forwarding Edit popup, I confirm that IATA is listed at Shipping with limited quantity
	And In the Forwarding Edit popup, I confirm that IMDG is listed at Shipping with limited quantity
	And In the Forwarding Edit popup, I confirm that TDG is listed at Shipping with limited quantity
	And In the Forwarding Edit popup, I confirm that I cannot downgrade DOT to Shipping with consumer commodity
	And In the Forwarding Edit popup, I confirm that I cannot downgrade IATA to Shipping with consumer commodity
	And In the Forwarding Edit popup, I upgrade DOT to Shipping fully regulated
	And In the Forwarding Edit popup, I upgrade IATA to Shipping fully regulated
	And I click Save in the Edit UPC popup in Forwarding
	Given In Forward Product Registration, I ensure that DOT is listed as Shipping fully regulated
	Given In Forward Product Registration, I ensure that IATA is listed as Shipping fully regulated
	Given In Forward Product Registration, I ensure that IMDG is listed as Shipping with limited quantity
	Given In Forward Product Registration, I ensure that TDG is listed as Shipping with limited quantity
	And I select the first UPC in the grid under the Select UPCs tab
	Given I click continue on the Forward Product Registration page
	Given I click continue on the Forward Product Registration page
	Given I select the true radio for the 'Are Statements True' question under the Review and Submit tab
	Given I click continue on the Forward Product Registration page
	Given In the Purchase Summary screen I confirm the Purchase Summary header is displayed

# Removed from regression: 2024/08
@ignore
@TestCase:122940
Scenario: [122940] UPC Transporation - Data Entry - Exceptions
	#Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I log in with the account saved in TReVor as: ProductAccount
	Given I generate a random UPC number and save as: UPC122940
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Given in the New Product page I click Continue
	Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bleach
	Given I save the product information as: TestCase122940
	And I call Shared Step 74340 (Product Information - Pesticide= Not considered, SOLD=US, everything else = No - Continue)
	Given I call Shared Step 74760 (Physical and Chemical Properties - Select Liquid as primary physical state and enter all required data)
		| Boiling Point (in Celsius) | Flash Point (in Celsius) | Flash Point Testing Method Used | pH | Primary Physical State | Secondary Physical State | Select the best Water Solubility description | Relative Density |
		| 66                         | 55                       | Closed cup method               | 6  | Liquid                 | Liquid                   | Dispersible                                  | 66               |
	#Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Chlorine
	Given I should see the Ingredients Page
	Then In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	| component name | Chlorine       | 100     |                     |               |             |
	Then in the Ingredients page I click Continue

#	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Then I should be on the Inventory Status, Prop 65 (US) Page
	And In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	And In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page, I click Continue

	Given I should see the Transportation Details 1 Page
	Given I set the Product is Regulated for Transport field to: Yes
	Given I call Shared Step 65698 (Transport - Select DOT & Limited Shipping - No Continue)
	Given I click continue
	Given I enter UN1993 - Select data - Continue - Happy Path
	Given I select the following retailers in the Select Retailers popup list view:
		| Retailer  |
		| Walgreens |
	Given I click Done on Select Retailers window
	Given I click continue
	Given I call Shared Step 87647 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC122940, container type: Plastic Container and size: 2 do not click continue
	Given I ensure that I can only select one exception in the UPC Transportation column
	Given I navigate to the home page
	Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase122940

@ignore
@TestCase:122971
Scenario: [122971] UPC Transportation - Data Entry - Upgrading to Fully Regulated at the UPC Level
	#Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I log in with the account saved in TReVor as: ProductAccount
	Given I generate a random UPC number and save as: UPC122971
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Given in the New Product page I click Continue
	Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bleach
	Given I save the product information as: TestCase122971
	And I call Shared Step 74340 (Product Information - Pesticide= Not considered, SOLD=US, everything else = No - Continue)
	Given I call Shared Step 74760 (Physical and Chemical Properties - Select Liquid as primary physical state and enter all required data)
		| Boiling Point (in Celsius) | Flash Point (in Celsius) | Flash Point Testing Method Used | pH | Primary Physical State | Secondary Physical State | Select the best Water Solubility description | Relative Density |
		| 66                         | 55                       | Closed cup method               | 6  | Liquid                 | Liquid                   | Dispersible                                  | 66               |
	#Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Chlorine
	Given I should see the Ingredients Page
	Then In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	| component name | Chlorine       | 100     |                     |               |             |
	Then in the Ingredients page I click Continue

	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given I should see the Transportation Details 1 Page
	Given I set the Product is Regulated for Transport field to: Yes
	Given I call Shared Step 65698 (Transport - Select DOT & Limited Shipping - No Continue)
	Given I call Shared Step 65700 (Transportation Details 1 - Select IATA & Limited Shipping)
	Given I click continue
	Given I enter UN1993 - Select data - Continue - Happy Path
	Given I should see the International Air Transport (IATA) Classification Page
	Given I check the checkbox with description: Copy information from my U.S. Department of Transportation data
	Given I click continue
	Given I select the following retailers in the Select Retailers popup list view:
		| Retailer  |
		| Walgreens |
	Given I click Done on Select Retailers window
	Given I click continue
	Given I call Shared Step 87647 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC122971, container type: Plastic Container and size: 2 do not click continue
	Given At the UPC level, I set DOT to Shipping fully regulated
	Given At the UPC level, I set IATA to Shipping fully regulated
	Given I click continue
	#Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
	Then in the Regulatory Documents to Provide page I click Continue

	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Appearance | Autoignition Temperature | Minimum Ignition Energy | Odor     | Odor Threshold    | Partition Coefficient | Personal Protection Equipment | Viscosity |
		| Black      | 300                      | 1.005                   | Odorless | No data available | 10                    | Mask                          | 20        |
	#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	Given I click the Summary button in the Data Acceptance window
	Given I switch to the Data Summary page
	Given In the section 'Select all modes of transport that you've classified the product for', I see DOT listed at Shipping with limited quantity
	Given In the section 'Select all modes of transport that you've classified the product for', I see IATA listed at Shipping with limited quantity
	Given I ensure that the UPC table displays a column called 'UPC Transportation'
	Given In the Summary screen UPC table, I ensure that DOT is listed as Shipping fully regulated
	Given In the Summary screen UPC table, I ensure that IATA is listed as Shipping fully regulated
	Given I close the window that opened
	Given I navigate to the home page
	Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase122971

@ignore
@TestCase:122984
Scenario: [122984] UPC Transportation - Forwarding - iRules - Edit UPC
	#Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I log in with the account saved in TReVor as: ProductAccount
	Given I generate a random UPC number and save as: UPC122984
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Given in the New Product page I click Continue
	Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bleach
	Given I save the product information as: TestCase122984
	And I call Shared Step 74340 (Product Information - Pesticide= Not considered, SOLD=US, everything else = No - Continue)
	Given I call Shared Step 74760 (Physical and Chemical Properties - Select Liquid as primary physical state and enter all required data)
		| Boiling Point (in Celsius) | Flash Point (in Celsius) | Flash Point Testing Method Used | pH | Primary Physical State | Secondary Physical State | Select the best Water Solubility description | Relative Density |
		| 66                         | 66                       | Closed cup method               | 6  | Liquid                 | Liquid                   | Dispersible                                  | 66               |
	#Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Chlorine
	Given I should see the Ingredients Page
	Then In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	| component name | Chlorine       | 100     |                     |               |             |
	Then in the Ingredients page I click Continue

	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given I should see the Transportation Details 1 Page
	Given I set the Product is Regulated for Transport field to: Yes
	Given I call Shared Step 65698 (Transport - Select DOT & Limited Shipping - No Continue)
	Given I click continue
	And I set the UN Number field to: UN2831
	And I click continue
	Given I select the following retailers in the Select Retailers popup list view:
		| Retailer  |
		| Walgreens |
	Given I click Done on Select Retailers window
	Given I click continue
	And I call Shared Step 85909 (UPC - Confirm Package type link and drop down not shown - Add UPC data - Continue) for UPC: saved as UPC122984, container type: Plastic Container and size: 12 click continue
	#Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
	Then in the Regulatory Documents to Provide page I click Continue

	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Appearance | Autoignition Temperature | Minimum Ignition Energy | Odor     | Odor Threshold    | Partition Coefficient | Personal Protection Equipment | Viscosity |
		| Black      | 300                      | 1.005                   | Odorless | No data available | 10                    | Mask                          | 20        |
	#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	#Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given I should see the Data Acceptance Page
	Then In the Data Acceptance Section, check 'Agreed' checkbox
	Then In the Data Acceptance Section, click 'Accept' button

	Given If purchase details are showing click confirm order
	Given I navigate to the home page
	And I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Submitted Status for saved as: TestCase122984)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase122984 and its status is: Submitted
	Given I navigate to the landing page
	#Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I log in with the account saved in TReVor as: ProductAccount
	Given I search for the product saved as: TestCase122984
	Given I call Shared Step 75130 - Bulk Actions - Select Forward Product Registration
	Given I enter the text: saved as TestCase122984 in the 'Search by WPS ID or Product Name' field
	Given In the Foward Product Registration Screen I should see product: saved as TestCase122984
	Given In the Foward Product Registration Screen I Select the product: saved as TestCase122984
	Given I click continue on the Forward Product Registration page
	Given In the Forward Product Registration Screen I select the first retailer that does not require additional data and is not: Walgreens under Other Retailers and save it as: Retailer
	Given I click continue on the Forward Product Registration page
	Given I select the first product under the Select UPCs tab
	Given I select Edit for the first UPC in Select UPCs tab
	And I wait for 5 seconds
	Given In the Forwarding Edit popup, I set the size (ounces) attribute to 170
	And I click Save in the Edit UPC popup in Forwarding
	And I wait for 5 seconds
	Then An alert is displayed with the message: UPC failing Transportation Rules. Review your Transport overrides.

@tfs_design
@ignore
@TestCase:123125
Scenario: [123125] UPC Transportation - Forwarding - iRules - Add UPC
	#Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I log in with the account saved in TReVor as: ProductAccount
	Given I generate a random UPC number and save as: UPC123125
	Given I generate a random UPC number and save as: UPC123125_2
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Given in the New Product page I click Continue
	Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bleach
	Given I save the product information as: TestCase123125
	And I call Shared Step 74340 (Product Information - Pesticide= Not considered, SOLD=US, everything else = No - Continue)
	Given I call Shared Step 74760 (Physical and Chemical Properties - Select Liquid as primary physical state and enter all required data)
		| Boiling Point (in Celsius) | Flash Point (in Celsius) | Flash Point Testing Method Used | pH | Primary Physical State | Secondary Physical State | Select the best Water Solubility description | Relative Density |
		| 66                         | 66                       | Closed cup method               | 6  | Liquid                 | Liquid                   | Dispersible                                  | 66               |
	#Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Chlorine
	Given I should see the Ingredients Page
	Then In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	| component name | Chlorine       | 100     |                     |               |             |
	Then in the Ingredients page I click Continue

	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given I should see the Transportation Details 1 Page
	Given I set the Product is Regulated for Transport field to: Yes
	Given I call Shared Step 65698 (Transport - Select DOT & Limited Shipping - No Continue)
	Given I click continue
	And I set the UN Number field to: UN2831
	And I click continue
	Given I select the following retailers in the Select Retailers popup list view:
		| Retailer  |
		| Walgreens |
	Given I click Done on Select Retailers window
	Given I click continue
	And I call Shared Step 85909 (UPC - Confirm Package type link and drop down not shown - Add UPC data - Continue) for UPC: saved as UPC123125, container type: Plastic Container and size: 12 click continue
	#Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
	Then in the Regulatory Documents to Provide page I click Continue

	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Appearance | Autoignition Temperature | Minimum Ignition Energy | Odor     | Odor Threshold    | Partition Coefficient | Personal Protection Equipment | Viscosity |
		| Black      | 300                      | 1.005                   | Odorless | No data available | 10                    | Mask                          | 20        |
	#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	#Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given I should see the Data Acceptance Page
	Then In the Data Acceptance Section, check 'Agreed' checkbox
	Then In the Data Acceptance Section, click 'Accept' button

	Given If purchase details are showing click confirm order
	Given I navigate to the home page
	And I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Submitted Status for saved as: TestCase123125)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase123125 and its status is: Submitted
	Given I navigate to the landing page
	#Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I log in with the account saved in TReVor as: ProductAccount
	Given I search for the product saved as: TestCase123125
	Given I call Shared Step 75130 - Bulk Actions - Select Forward Product Registration
	Given I enter the text: saved as TestCase123125 in the 'Search by WPS ID or Product Name' field
	Given In the Foward Product Registration Screen I should see product: saved as TestCase123125
	Given In the Foward Product Registration Screen I Select the product: saved as TestCase123125
	Given I click continue on the Forward Product Registration page
	Given In the Forward Product Registration Screen I select the first retailer that does not require additional data and is not: Walgreens under Other Retailers and save it as: Retailer
	Given I click continue on the Forward Product Registration page
	Given I select the first product under the Select UPCs tab

# Click the Add UPC button
# Enter a random UPC
# Enter a Type
# Enter 170 in the Size (ounces) field
# Click Save
# Ensure that you get a UPC Transportation error
@ignore
@TestCase:123436
Scenario: [123436] UPC Transportation - Recertification - Transportation Details 1 UPC popup
	#may be worth either cutting some of the steps or making a shared step that creates the prouduct (shorten the specflow)
	Given I log in with the account saved in TReVor as: ProductAccount
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Given in the New Product page I click Continue
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Fertilizer
	Then I call Shared Step 143418 (Product Information - Pesticide= Not considered, Fertilizer=NO, SOLD=US, everything else = No - Continue)
	And I should see the Physical and Chemical Properties Page
	Then I save the product information as: TestCase65947
	And The following options should be displayed for section: Primary Physical State
		| Option |
		| Liquid |
		| Solid  |
	And I set the Primary Physical State option to: Liquid
	And I set the Secondary Physical State option to: Liquid
	And I set the Relative Density option to: 10
	And I set the pH option to: 10.5
	And I set the Boiling Point (in Celsius) option to: 120
	And I set the Flash Point (in Celsius) option to: 23
	And I set the Flash Point Testing Method Used option to: Closed cup method
	And I set the Select the best Water Solubility description option to: Insoluble
	And I click continue
	#And I call Shared Step 29181 (Ingredients - add any chemical) with name: Benzene
	Given I should see the Ingredients Page
	Then In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	| component name | Benzene       | 100     |                     |               |             |
	Then in the Ingredients page I click Continue

	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	And I should see the Transportation Details 1 Page
	And I set the Product is Regulated for Transport field to: Yes
	And I set the Select all modes of transport that you've classified the product for field to: DOT
	And I select option: Shipping fully regulated under section: Select all modes of transport that you've classified the product for and subsection: DOT
	And I click continue
	And I should see the U.S. Department of Transportation (DOT) Classification Page
	And I set the UN Number field to: UN2762
	And I set the Technical Name field to: Technical Name UN2762
	And I set the Packing Group (select) field to: II
	And I select the first option in section: Product has a boiling point of <=35⁰C  and flash point of >60⁰C. Packing Group selected is not consistent with this data.  Verify the data and transportation packing group.  If problem persists, please contact Support.
	And I click continue
	And I call Shared Step 77845 (Retailer - Select WM, Done, Select Vendor ID, Continue)
	Given I click the 'Add' button
	Then I generate a random UPC number and save as: RandomUPC91076
	Given I add the following into the UPC Fields
		| UPC Number              | Container Type    | Size | DPCI | Quantity |
		| saved as RandomUPC91076 | Plastic Container | 1    |      |          |
	Given I click continue
	#And I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
	Then in the Regulatory Documents to Provide page I click Continue

	And I should see the Additional Documents to Provide Page
	And I click continue
	And I should see the Optional Reports and Documents Available for Purchase Page
	And I click continue
	And I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
		| Gloves                        | 120                      | 4                       | 10.0      | Black      | Odorless | No data available | 1                     |
	#And I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Test Comment
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	And I call Shared Step 73956 (Go to Summary and verify data) with product type: Fertilizer
	#And I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given I should see the Data Acceptance Page
	Then In the Data Acceptance Section, check 'Agreed' checkbox
	Then In the Data Acceptance Section, click 'Accept' button

	And In the Purchase Summary screen I confirm the Purchase Summary header is displayed
	And In the Purchase Summary screen if Product Billing is displayed I click Confirm Order
	And I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase65947 and its status is: Submitted
	Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase65947)
	Then I call Shared Step 51349 - SHA Manager > Assigned Product - Add Recert reason 20 for product saved as: TestCase65947
	Given I navigate to the landing page
	And I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	And I filter for the product saved as: TestCase65947
	And I click Row Actions for the first product returned
	And I click on the Row Action: Update Required
    Given In the New Product page I click tab: Product Characteristics
    And I click the page heading: Transportation Details 1
	And I set the Select all modes of transport that you've classified the product for field to: DOT
	#First remove check form the full reg box
	And I unselect the option: Shipping fully regulated under section: Select all modes of transport that you've classified the product for and subsection: DOT
	And I select option: Shipping with limited quantity under section: Select all modes of transport that you've classified the product for and subsection: DOT
	And I click Save in The Product Page
	Then I Wait for a modal popup to appear
	Then I confirm the pop up shows the heading: UPC Transportation Warning
	Given in the modal dialog I click the "Ok" button
	Then I Wait for a modal popup to disappear
	Given In the New Product page I click tab: Review and Submit
	And I click the page heading: Data Acceptance
	#may need to update the below if inludes line breaks etc in the text
	Then Data Accpetance Screen shows error with message: Please fix all the errors in product data before you can continue with submission.
	And I click continue
	And I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page
	And I click continue
	#And I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given I should see the Data Acceptance Page
	Then In the Data Acceptance Section, check 'Agreed' checkbox
	Then In the Data Acceptance Section, click 'Accept' button

	And In the Purchase Summary screen I confirm the Purchase Summary header is displayed
	And In the Purchase Summary screen if Product Billing is displayed I click Confirm Order

@ignore
@TestCase:125533
Scenario: [125533] UPC Transportation - Recertification - iRules
	Given I log in with the account saved in TReVor as: ProductAccount
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Given in the New Product page I click Continue
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Fertilizer
	Then I call Shared Step 143418 (Product Information - Pesticide= Not considered, Fertilizer=NO, SOLD=US, everything else = No - Continue)
	And I should see the Physical and Chemical Properties Page
	Then I save the product information as: TestCase65947
	And The following options should be displayed for section: Primary Physical State
		| Option |
		| Liquid |
		| Solid  |
	And I set the Primary Physical State option to: Liquid
	And I set the Secondary Physical State option to: Liquid
	And I set the Relative Density option to: 10
	And I set the pH option to: 10.5
	And I set the Boiling Point (in Celsius) option to: 120
	And I set the Flash Point (in Celsius) option to: 70
	And I set the Flash Point Testing Method Used option to: Closed cup method
	And I set the Select the best Water Solubility description option to: Insoluble
	And I click continue
	#And I call Shared Step 29181 (Ingredients - add any chemical) with name: Benzene
	Given I should see the Ingredients Page
	Then In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	| component name | Benzene       | 100     |                     |               |             |
	Then in the Ingredients page I click Continue

	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	And I should see the Transportation Details 1 Page
	And I set the Product is Regulated for Transport field to: Yes
	And I set the Select all modes of transport that you've classified the product for field to: DOT
	And I select option: Shipping with limited quantity under section: Select all modes of transport that you've classified the product for and subsection: DOT
	And I click continue
	And I should see the U.S. Department of Transportation (DOT) Classification Page
	And I set the UN Number field to: UN1702
	And I set the Packing Group (select) field to: II
	#And I select the first option in section: Product has a boiling point of <=35⁰C  and flash point of >60⁰C. Packing Group selected is not consistent with this data.  Verify the data and transportation packing group.  If problem persists, please contact Support.
	And I click continue
	And I call Shared Step 77845 (Retailer - Select WM, Done, Select Vendor ID, Continue)
	Given I click the 'Add' button
	Then I generate a random UPC number and save as: RandomUPC91076
	Given I add the following into the UPC Fields
		| UPC Number              | Container Type    | Size | DPCI | Quantity |
		| saved as RandomUPC91076 | Plastic Container | 1    |      |          |
	Given I click continue
	#And I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
	Then in the Regulatory Documents to Provide page I click Continue

	And I should see the Additional Documents to Provide Page
	And I click continue
	And I should see the Optional Reports and Documents Available for Purchase Page
	And I click continue
	And I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
		| Gloves                        | 120                      | 4                       | 10.0      | Black      | Odorless | No data available | 1                     |
	#And I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Test Comment
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	And I call Shared Step 73956 (Go to Summary and verify data) with product type: Fertilizer
	#And I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given I should see the Data Acceptance Page
	Then In the Data Acceptance Section, check 'Agreed' checkbox
	Then In the Data Acceptance Section, click 'Accept' button

	And In the Purchase Summary screen I confirm the Purchase Summary header is displayed
	And In the Purchase Summary screen if Product Billing is displayed I click Confirm Order
	And I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase65947 and its status is: Submitted
	Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase65947)
	Then I call Shared Step 51349 - SHA Manager > Assigned Product - Add Recert reason 20 for product saved as: TestCase65947
	Given I navigate to the landing page
	And I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	And I filter for the product saved as: TestCase65947
	And I click Row Actions for the first product returned
	And I click on the Row Action: Update Required
	Given In the New Product page I click tab: Recipient and UPC Details
	And I click the page heading: Universal Product Code (UPC)
	Given I add the following into the UPC Fields
		| UPC Number              | Container Type    | Size | DPCI | Quantity |
		| saved as RandomUPC91076 | Plastic Container | 200  |      |          |
	Given I click continue
	Then I should see a list style form error with text: UPC failing Transportation Rules. Review your Transport overrides.

@ignore
@TestCase:125536
Scenario: [125536] UPC transportation - Recertification - Upgrade and Downgrade - Limited Quantity
	Given I log in with the account saved in TReVor as: ProductAccount
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Given in the New Product page I click Continue
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Fertilizer
	Then I call Shared Step 143418 (Product Information - Pesticide= Not considered, Fertilizer=NO, SOLD=US, everything else = No - Continue)
	And I should see the Physical and Chemical Properties Page
	Then I save the product information as: TestCase65947
	And The following options should be displayed for section: Primary Physical State
		| Option |
		| Liquid |
		| Solid  |
	And I set the Primary Physical State option to: Liquid
	And I set the Secondary Physical State option to: Liquid
	And I set the Relative Density option to: 10
	And I set the pH option to: 10.5
	And I set the Boiling Point (in Celsius) option to: 120
	And I set the Flash Point (in Celsius) option to: 70
	And I set the Flash Point Testing Method Used option to: Closed cup method
	And I set the Select the best Water Solubility description option to: Insoluble
	And I click continue
	#And I call Shared Step 29181 (Ingredients - add any chemical) with name: Benzene
	Given I should see the Ingredients Page
	Then In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	| component name | Benzene       | 100     |                     |               |             |
	Then in the Ingredients page I click Continue

	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	And I should see the Transportation Details 1 Page
	And I set the Product is Regulated for Transport field to: Yes
	And I set the below options for field: Select all modes of transport that you've classified the product for
		| Option                           |	
		| DOT                              |
		| Shipping with limited quantity   |
	And I click continue
	# U.S. Department of Transportation (DOT) Classification Page
	Then I should see the U.S. Department of Transportation (DOT) Classification Page
	And I set the UN Number field to: UN1702
	And I set the Packing Group (select) field to: II
	Given in the New Product page I click Continue	
	And I call Shared Step 77845 (Retailer - Select WM, Done, Select Vendor ID, Continue)
	Given I click the 'Add' button
	Then I generate a random UPC number and save as: RandomUPC91076
	Given I add the following into the UPC Fields
		| UPC Number              | Container Type    | Size | DPCI | Quantity |
		| saved as RandomUPC91076 | Plastic Container | 1    |      |          |
	Given I click continue
	#And I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
	Then in the Regulatory Documents to Provide page I click Continue

	And I should see the Additional Documents to Provide Page
	And I click continue
	And I should see the Optional Reports and Documents Available for Purchase Page
	And I click continue
	And I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
		| Gloves                        | 120                      | 4                       | 10.0      | Black      | Odorless | No data available | 1                     |
	#And I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Test Comment
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	And I call Shared Step 73956 (Go to Summary and verify data) with product type: Fertilizer
	#And I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given I should see the Data Acceptance Page
	Then In the Data Acceptance Section, check 'Agreed' checkbox
	Then In the Data Acceptance Section, click 'Accept' button

	And In the Purchase Summary screen I confirm the Purchase Summary header is displayed
	And In the Purchase Summary screen if Product Billing is displayed I click Confirm Order
	And I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase65947 and its status is: Submitted
	Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase65947)
	Then I call Shared Step 51349 - SHA Manager > Assigned Product - Add Recert reason 20 for product saved as: TestCase65947
	Given I navigate to the landing page
	And I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	And I filter for the product saved as: TestCase65947
	And I click Row Actions for the first product returned
	And I click on the Row Action: Update Required
	Given In the New Product page I click tab: Recipient and UPC Details
	And I click the page heading: Universal Product Code (UPC)
	Given I ensure that DOT is listed as Shipping with limited quantity

#	Philip - Change
#	Given I ensure that I cannot select DOT at Shipping with consumer commodity
	

	Given I ensure that I can select DOT at Shipping fully regulated

@tfs_design
@ignore
@obsolete
@TestCase:125702
Scenario: [125702] UPC transportation - Recertification - Upgrade and Downgrade - Shipping with consumer commodity
	Given I log in with the account saved in TReVor as: ProductAccount
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Given in the New Product page I click Continue
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Fertilizer
		Then I call Shared Step 143418 (Product Information - Pesticide= Not considered, Fertilizer=NO, SOLD=US, everything else = No - Continue)
	And I should see the Physical and Chemical Properties Page
	Then I save the product information as: TestCase65947
	And The following options should be displayed for section: Primary Physical State
		| Option |
		| Liquid |
		| Solid  |
	And I set the Primary Physical State option to: Liquid
	And I set the Secondary Physical State option to: Liquid
	And I set the Relative Density option to: 10
	And I set the pH option to: 10.5
	And I set the Boiling Point (in Celsius) option to: 120
	And I set the Flash Point (in Celsius) option to: 70
	And I set the Flash Point Testing Method Used option to: Closed cup method
	And I set the Select the best Water Solubility description option to: Insoluble
	And I click continue
	#And I call Shared Step 29181 (Ingredients - add any chemical) with name: Benzene
	Given I should see the Ingredients Page
	Then In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	| component name | Benzene       | 100     |                     |               |             |
	Then in the Ingredients page I click Continue

	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	And I should see the Transportation Details 1 Page
	And I set the Product is Regulated for Transport field to: Yes
	And I set the below options for field: Select all modes of transport that you've classified the product for
		| Option                           |
		| DOT                              |
		| Shipping with limited quantity   |
		| Shipping with consumer commodity |
    And I click continue
	# U.S. Department of Transportation (DOT) Classification Page
	Then I should see the U.S. Department of Transportation (DOT) Classification Page
	And I set the UN Number field to: UN1702
	And I set the Packing Group (select) field to: II
	Given in the New Product page I click Continue	
	And I call Shared Step 77845 (Retailer - Select WM, Done, Select Vendor ID, Continue)
	Given I click the 'Add' button
	Then I generate a random UPC number and save as: RandomUPC91076
	Given I add the following into the UPC Fields
		| UPC Number              | Container Type    | Size | DPCI | Quantity |
		| saved as RandomUPC91076 | Plastic Container | 1    |      |          |
	Given I click continue
	#And I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
	Then in the Regulatory Documents to Provide page I click Continue

	And I should see the Additional Documents to Provide Page
	And I click continue
	And I should see the Optional Reports and Documents Available for Purchase Page
	And I click continue
	And I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
		| Gloves                        | 120                      | 4                       | 10.0      | Black      | Odorless | No data available | 1                     |
	#And I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Test Comment
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	And I call Shared Step 73956 (Go to Summary and verify data) with product type: Fertilizer
	#And I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given I should see the Data Acceptance Page
	Then In the Data Acceptance Section, check 'Agreed' checkbox
	Then In the Data Acceptance Section, click 'Accept' button

	And In the Purchase Summary screen I confirm the Purchase Summary header is displayed
	And In the Purchase Summary screen if Product Billing is displayed I click Confirm Order
	And I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase65947 and its status is: Submitted
	Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase65947)
	Then I call Shared Step 51349 - SHA Manager > Assigned Product - Add Recert reason 20 for product saved as: TestCase65947
	Given I navigate to the landing page
	And I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	And I filter for the product saved as: TestCase65947
	And I click Row Actions for the first product returned
	And I click on the Row Action: Update Required
	Given In the New Product page I click tab: Recipient and UPC Details
	And I click the page heading: Universal Product Code (UPC)
    Given I ensure that I can select DOT at Shipping with limited quantity
	Given I ensure that I can select DOT at Shipping fully regulated

@ignore
@TestCase:125703
Scenario: [125703] UPC transportation - Recertification - Upgrade and Downgrade - Shipping fully regulated
	Given I log in with the account saved in TReVor as: ProductAccount
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Given in the New Product page I click Continue
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Fertilizer
	Then I call Shared Step 143418 (Product Information - Pesticide= Not considered, Fertilizer=NO, SOLD=US, everything else = No - Continue)
	And I should see the Physical and Chemical Properties Page
	Then I save the product information as: TestCase65947
	And The following options should be displayed for section: Primary Physical State
		| Option |
		| Liquid |
		| Solid  |
	And I set the Primary Physical State option to: Liquid
	And I set the Secondary Physical State option to: Liquid
	And I set the Relative Density option to: 10
	And I set the pH option to: 10.5
	And I set the Boiling Point (in Celsius) option to: 120
	And I set the Flash Point (in Celsius) option to: 70
	And I set the Flash Point Testing Method Used option to: Closed cup method
	And I set the Select the best Water Solubility description option to: Insoluble
	And I click continue
	#And I call Shared Step 29181 (Ingredients - add any chemical) with name: Benzene
	Given I should see the Ingredients Page
	Then In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	| component name | Benzene       | 100     |                     |               |             |
	Then in the Ingredients page I click Continue

	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	And I should see the Transportation Details 1 Page
	And I set the Product is Regulated for Transport field to: Yes
	And I set the below options for field: Select all modes of transport that you've classified the product for
		| Option                   |
		| DOT                      |
		| Shipping fully regulated |
	And I click continue
	# U.S. Department of Transportation (DOT) Classification Page
	Then I should see the U.S. Department of Transportation (DOT) Classification Page
	And I set the UN Number field to: UN1702
	And I set the Packing Group (select) field to: II
	Given in the New Product page I click Continue	
	And I call Shared Step 77845 (Retailer - Select WM, Done, Select Vendor ID, Continue)
	Given I click the 'Add' button
	Then I generate a random UPC number and save as: RandomUPC91076
	Given I add the following into the UPC Fields
		| UPC Number              | Container Type    | Size | DPCI | Quantity |
		| saved as RandomUPC91076 | Plastic Container | 1    |      |          |
	Given I click continue
	#And I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
	Then in the Regulatory Documents to Provide page I click Continue

	And I should see the Additional Documents to Provide Page
	And I click continue
	And I should see the Optional Reports and Documents Available for Purchase Page
	And I click continue
	And I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
		| Gloves                        | 120                      | 4                       | 10.0      | Black      | Odorless | No data available | 1                     |
	#And I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Test Comment
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	And I call Shared Step 73956 (Go to Summary and verify data) with product type: Fertilizer
	#And I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given I should see the Data Acceptance Page
	Then In the Data Acceptance Section, check 'Agreed' checkbox
	Then In the Data Acceptance Section, click 'Accept' button

	And In the Purchase Summary screen I confirm the Purchase Summary header is displayed
	And In the Purchase Summary screen if Product Billing is displayed I click Confirm Order
	And I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase65947 and its status is: Submitted
	Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase65947)
	Then I call Shared Step 51349 - SHA Manager > Assigned Product - Add Recert reason 20 for product saved as: TestCase65947
	Given I navigate to the landing page
	And I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	And I filter for the product saved as: TestCase65947
	And I click Row Actions for the first product returned
	And I click on the Row Action: Update Required
	Given In the New Product page I click tab: Recipient and UPC Details
	And I click the page heading: Universal Product Code (UPC)
	Given I ensure that DOT is listed as Shipping fully regulated
	Given I ensure that I cannot select DOT at Shipping with limited quantity


	
	
