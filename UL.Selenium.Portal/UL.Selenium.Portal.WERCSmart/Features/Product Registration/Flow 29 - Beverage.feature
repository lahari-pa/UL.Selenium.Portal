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
@run_Flow29_Beverage
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:ProductInformation
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:NewProduct
@Steps_ProductPrototype
@StepsPrototype
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:TheProduct
@PhysicalAndChemicalProp
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:InventoryStatusProp65
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:BeverageRegulatoryDetails
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:TransportationDetails1
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:TransportationDetails2
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:Retailer
@GTINAndUPC
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:DataAcceptance
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:Summary
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:PurchaseSummary
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:USDepartamentOfTransportationDOT
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:InternationalAirTransportClassification
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:InternationalMarineClassification
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:AdditionalDocumentsToProvide
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:OptionalComments
@MyProductsPage
@HeaderNavbar
@SideMenu

Feature: Flow 29 - Beverage

@TReVorId:11622
@TestCase:60694
Scenario: [60694] Alcoholic Beverages - Wine - RU001418 - (More than 24% but Less than 70% of Alcohol Content) - DOT - Packaging Group III Should be Pre-Selected
	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC60694
	Given I delete all products with UPC Number: saved as UPC60694
	#Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	#I call Shared Step 234546 (WERCSmart Portal - Create a New Registration - Enter Product Name and Select Type of Product )(Step has not created yet)
	Then In the Side Menu, click Labeled Link with Add Product title
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration'
	Then in the New Product page, I click Continue
	#Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Wine
	Then In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Alcoholic Beverages - Wine_#60694
	Then In the Product Section, set the option in section: 'Type of Product (select)' to: Alcoholic Beverages - Wine
	Then in the The Product page, I click Continue
	Then I save the product information as: TestCase60694
	#Then I call Shared Step 216821 - Product Information - Product Information - Applicable Only to Alcoholic Beverages - Wine (RU001418)
	Then I should be on the Product Information Page
	Then In the Product Information Section, set the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' to select: United States
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page, I click Continue
	#Given I call Shared Step 92950 (Physical and Chemical Properties - Physical Property - Liquid - For Wine Less than <70% Alcohol)
	Then I should be on the Physical and Chemical Properties Page
	Then In the Physical and Chemical Properties Section, set the option in section: 'Primary Physical State' to: Liquid
	Then In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Liquid
	Then In the Physical and Chemical Properties Section, for section: 'Relative Density' enter text: 0.7844
	Then In the Physical and Chemical Properties Section, for section: 'pH' enter text: 7
	Then In the Physical and Chemical Properties Section, for section: 'Boiling Point (in Celsius)' enter text: 78
	Then In the Physical and Chemical Properties Section, for section: 'Flash Point (in Celsius)' enter text: 34
	Then In the Physical and Chemical Properties Section, set the option in section: 'Flash Point Testing Method Used' to: Closed cup method
	Then in the Physical and Chemical Properties page, I click Continue
	#Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	#I call Shared Step 239830 (Inventory Status, Prop 65 (US) - TSCA (EXEMPT) / Prop 65 (NO) - (General Shared-Step))(Step has not created yet)
	Then I should be on the Inventory Status, Prop 65 (US) Page
	Then In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is exempt from TSCA chemical Inventory listing requirements.
	Then In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page, I click Continue
	#Given I call Shared Step 92964 (Beverage Regulatory Details Less < 70%)
	Then I should be on the Beverage Regulatory Details Page
	Then I enter the text of Product's container or liner contains Bisphenol A (BPA) field to: No
	Then I enter the text of Percent of Alcohol in the Product (numeric entry only) field to: 27
	Then in the Beverage Regulatory Details page, I click Continue
	#Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path
	#I call Shared Step 234437 (Transportation Details 1 - Applicable Only to Alcoholic Beverages - Wine (RU001418) - (More than 24% but Less than 70% Alcohol Content))(Step has not created yet)
	Then I should be on the Transportation Details 1 Page
	Then In the Transportation Details 1 Section, set the option in section: 'Product is Regulated for Transport': to: Yes
	Then In the Transportation Details 1 Section, set the option in section: 'Select all modes of transport that you've classified the product for': to: DOT
	Then In the Transportation Details 1 Section, set the option for DOT mode of transport to: Shipping with limited quantity
	Then In the Transportation Details 1 Section, set the option in section: 'Select all modes of transport that you've classified the product for': to: IMDG
	Then In the Transportation Details 1 Section, set the option for IMDG mode of transport to: Shipping with limited quantity
	Then In the Transportation Details 1 Section, set the option in section: 'Select all modes of transport that you've classified the product for': to: IATA
	Then In the Transportation Details 1 Section, set the option for IATA mode of transport to: Shipping with limited quantity
	Then in the Transportation Details 1 page, I click Continue
	#Then I call Shared Step 71618 (U.S. Department of Transportation (DOT) Classification - For Alcohol (Packaging III))
	Then I should be on the U.S. Department of Transportation (DOT) Classification Page
	Then In the U.S. Department of Transportation (DOT) Classification Section, set the option in section: 'UN Number': to: UN3065
	Then In the U.S. Department of Transportation (DOT) Classification Section, verify section: 'Proper Shipping Name' contains value: Alcoholic beverages
	Then In the U.S. Department of Transportation (DOT) Classification Section, set the option in section: 'Hazard Class': to: 3
	Then In the U.S. Department of Transportation (DOT) Classification Section, set the option in section: 'Packing Group': to: III
	Then in the U.S. Department of Transportation (DOT) Classification page, I click Continue
	Then I should be on the International Air Transport (IATA) Classification Page
	Then In the International Air Transport (IATA) Classification Section, set the option in section: 'UN Number': to: UN3065
	Then In the International Air Transport (IATA) Classification Section, verify section: 'Proper Shipping Name' contains value: Alcoholic beverages
	Then In the International Air Transport (IATA) Classification Section, verify section: 'Hazard Class (select)' contains value: 3
	Then In the International Air Transport (IATA) Classification Section, set the option in section: 'Packing Group': to: III
	Then in the International Air Transport (IATA) Classification page, I click Continue
	Then I should be on the International Marine (IMDG) Classification Page
	Then In the International Marine (IMDG) Classification Section, I check checkbox 'Copy information from my U.S. Department of Transportation data'
	Then In the International Marine (IMDG) Classification Section, verify section: 'UN Number' contains value: UN3065
	Then In the International Marine (IMDG) Classification Section, verify section: 'Proper Shipping Name' contains value: Alcoholic beverages
	Then In the International Marine (IMDG) Classification Section, verify section: 'Hazard Class (select)' contains value: 3
	Then In the International Marine (IMDG) Classification Section, verify section: 'Packing Group (select)' contains value: III
	Then in the International Marine (IMDG) Classification page, I click Continue
	Then I should be on the Retailer Page
#	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase60694
   	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase60694

# Created by Saikiran Chittampally
# Test case can be found at the following paths:
# NetProjects10\WERCSmart UX Reboot\WERCSmart\Product Registration\Flow 29
# Removed from regression active bug ticket created - 03/10/2025
@ignore
@TestCase:105007
Scenario: [105007] Wine - RU001418 - Not Regulated Less than <=24% Alcohol

	#Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load

	Given I generate a random UPC number and save as: UPC105007
	Given I delete all products with UPC Number: saved as UPC105007

	#Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Then In the Side Menu, click Labeled Link with Add Product title
	Then I should be on the New Product Page
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration'
	Then in the New Product page, I click Continue

	#Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Wine
	Then In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Alcoholic Beverages - Wine_#105007
	Then In the Product Section, set the option in section: 'Type of Product (select)' to: Alcoholic Beverages - Wine
	Then in the The Product page, I click Continue

	Then I save the product information as: TestCase105007

	#Given I call Shared Step 90477 - Product Information - US, (NO) Retailer's PL
	Then I should be on the Product Information Page
	Then In the Product Information Section, set the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' to select: United States
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: Yes
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page, I click Continue

	#Given I call Shared Step 105009 (Physical and Chemical Properties - Wine Not Regulated <=24% Alcohol)
	Then I should be on the Physical and Chemical Properties Page
	Then In the Physical and Chemical Properties Section, set the option in section: 'Primary Physical State' to: Liquid
	Then In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Liquid
	Then In the Physical and Chemical Properties Section, for section: 'Relative Density' enter text: 0.789
	Then In the Physical and Chemical Properties Section, for section: 'pH' select the checkbox option: 'I do not have exact pH data available to me'
	Then In the Physical and Chemical Properties Section, set the option in section: 'pH' to: 7 (Neutral)
	Then In the Physical and Chemical Properties Section, for section: 'Boiling Point (in Celsius)' select the checkbox option: 'I do not have exact Boiling Point data available to me'
	Then In the Physical and Chemical Properties Section, set the option in section: 'Boiling Point (in Celsius)' to: Not tested/Unknown
	Then In the Physical and Chemical Properties Section, for section: 'Flash Point (in Celsius)' select the checkbox option: 'I do not have exact Flash Point data available to me'
	Then In the Physical and Chemical Properties Section, set the option in section: 'Flash Point (in Celsius)' to: Not Tested/Unknown
	Then in the Physical and Chemical Properties page, I click Continue

	#Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Then I should be on the Inventory Status, Prop 65 (US) Page
	Then In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is exempt from TSCA chemical Inventory listing requirements.
	Then In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page, I click Continue

	#Given I call Shared Step 105010 (Beverage Regulatory Details Less < 24%)
	Then I should be on the Beverage Regulatory Details Page
	Then I enter the text of Product's container or liner contains Bisphenol A (BPA) field to: No
	Then I enter the text of Percent of Alcohol in the Product (numeric entry only) field to: 23
	Then in the Beverage Regulatory Details page, I click Continue

	#Given I call Shared Step 57984 (Transportation Details - All options available - Select Not regulated - Continue - Happy Path)
	Then I should be on the Transportation Details 1 Page
	Then In the Transportation Details 1 Section, verify in 'Product is Regulated for Transport' section is option: Yes
	Then In the Transportation Details 1 Section, verify in 'Product is Regulated for Transport' section is option: No, due to an exemption or exception
	Then In the Transportation Details 1 Section, verify in 'Product is Regulated for Transport' section is option: Not Regulated
	Then In the Transportation Details 1 Section, set the option in section: 'Product is Regulated for Transport': to: No, due to an exemption or exception
	Then In the Transportation Details 1 page the 'Please select DOT Exceptions if applicable?' question is displayed
	Then In the Transportation Details 1 Section, verify in 'Please select DOT Exceptions if applicable?' section is option: 173.150(d)(1) - Exemption for alcoholic beverages (wine and distilled spirits), <=24% alcohol by volume, is contained in an inner packaging of 5L or less
	Then In the Transportation Details 1 Section, verify in 'Please select DOT Exceptions if applicable?' section is option: 173.150(e):  Aqueous solutions of alcohol with <= 24% alcohol by volume and no other hazardous material
	Then In the Transportation Details 1 Section, set the option in section: 'Product is Regulated for Transport': to: Not Regulated
	Then In the Transportation Details 1 page the 'Please select DOT Exceptions if applicable?' question is not displayed
	Then in the Transportation Details 1 page, I click Continue

	#Given I call Shared Step 63219 (Retailer Association - Select No Retailer - Click continue)
	Then I should be on the Retailer Page
	Then In the Retailer Section, click 'Add Retailers' button
	Then In the 'Select retailers' window I should only see the following retailers:
		| Retailer									|
		| Walgreens									|
		| No Retailer/No UPC Product				|
		| Publix								    |
	Then In the Select Retailers window, select retailer: Walgreens
	Then In the Select Retailers window, click 'Done' button
	Then In the Retailer Section, for retailer: Walgreens select 'Indicate full name of product, as sold, via this retailer' option: Walgreens
	Then in the Retailer page, I click Continue
	Then I should be on the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, I click the Add UPC Button
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, verify option 'Size (Fluid Ounces)' is present
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, for section: 'Provide the product's UPC(s)- including container type and size (ounces)' enter UPC Number: saved as UPC105007 enter Size: 12.3 and enter Container Type: Glass Container
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, verify retailer 'WG' is present under the 'Destination Retailers' column
	Then in the Global Trade Item Number (GTIN) / Universal Product Code (UPC) page, I click Continue

	#Given In the Additional Documents to Provide page I click Continue
	Then I should be on the Additional Documents to Provide Page
	Then in the Additional Documents to Provide page, I click Continue
	Then I should be on the Optional Comments Page
	Then in the Optional Comments page, I click Continue
	Then I should be on the Data Acceptance Page
	Then In the Data Acceptance Section, I confirm text 'Data Acceptance' text should be displayed
	Then In the Data Acceptance Section, click 'Summary' button

	#Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Alcoholic Beverages - Wine
	Then I switch to the tab with Data Summary page
	Then In the Summary Page, the 'Type of Product (select)' section should be showing the following value: Alcoholic Beverages - Wine
	Then In the Summary Page, the 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' section should be showing the following value: Yes
	Then In the Summary Page, the 'Percent of Alcohol in the Product (numeric entry only)' section should be showing the following value: 23
	Then In the Summary Page, the 'Product is Regulated for Transport' section should be showing the following value: Not Regulated
	Then In the Summary Page, verify table data in column Container Type showing the value: Glass Container
	Then In the Summary Page, verify table data in column Size (Ounces) showing the value: 12.3
	Then In the Summary Page, verify table data in column Retailers showing the value: WG
	Then I close the tab with Data Summary page
	Then I should be on the Data Acceptance Page
	Then In the Data Acceptance Section, check 'Agreed' checkbox
	Then In the Data Acceptance Section, click 'Accept' button
	Then The Purchase Summary Page is displayed
	Then In the Purchase Summary Page, click the 'Home' button
	Then The home screen should load
	Then I filter for the product saved as: TestCase105007
	Then I confirm that the label: 'PL' is displayed next to the Product Name for the top result in the grid

	


# Created by Saikiran Chittampally
# Test case can be found at the following paths:
# NetProjects10\WERCSmart UX Reboot\WERCSmart\Product Registration\Flow 29
@TestCase:92943
Scenario: [92943] Alcoholic Beverages - Spirits - RU001434 - (Greater > 70% of Alcohol Content) - DOT - Packaging Group II Should be Pre-Selected

	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC92943
	Given I delete all products with UPC Number: saved as UPC92943

	#Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	#I call Shared Step 242067 (WERCSmart Portal - Create a New Registration - Enter Product Name and Select Type of Product "Alcoholic Beverages - SPIRITS"  (RU001434))(Step has not created yet)
	Then In the Side Menu, click Labeled Link with Add Product title
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration'
	Then in the New Product page, I click Continue

	#Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Wine
	Then In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Alcoholic Beverages - Spirits_#92943
	Then In the Product Section, set the option in section: 'Type of Product (select)' to: Alcoholic Beverages - Spirits
	Then in the The Product page, I click Continue

	Then I save the product information as: TestCase92943

	#Given I call Shared Step 90477 - Product Information - US, (NO) Retailer's PL
	#Then I call Shared Step 242069 - Product Information  - Applicable Only to Alcoholic Beverages - SPIRITS (RU001434)
	Then I should be on the Product Information Page
	Then In the Product Information Section, set the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' to select: United States
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page, I click Continue

	#Then I call Shared Step 92979 (Physical and Chemical Properties - Physical Property - Liquid - For Spirits (RU001434) (Greater than 70% Alcohol))
	Then I should be on the Physical and Chemical Properties Page
	Then In the Physical and Chemical Properties Section, set the option in section: 'Primary Physical State' to: Liquid
	Then In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Liquid
	Then In the Physical and Chemical Properties Section, for section: 'Relative Density' enter text: 0.7934
	Then In the Physical and Chemical Properties Section, for section: 'pH' select the checkbox option: 'I do not have exact pH data available to me'
	Then In the Physical and Chemical Properties Section, set the option in section: 'pH' to: Not tested/Unknown
	Then In the Physical and Chemical Properties Section, for section: 'Boiling Point (in Celsius)' enter text: 78.5
	Then In the Physical and Chemical Properties Section, for section: 'Flash Point (in Celsius)' enter text: 13
	Then In the Physical and Chemical Properties Section, set the option in section: 'Flash Point Testing Method Used' to: Closed cup method
	Then in the Physical and Chemical Properties page, I click Continue

	#Then I call Shared Step 40650 (Regulatory Information 1 - TSCA shown, No to PROP 65 - Continue - Happy Path)
	Then I should be on the Inventory Status, Prop 65 (US) Page
	Then In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	Then In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page, I click Continue

	#Then I call Shared Step 92981 (Beverage Regulatory Details Greater > 70%)
	Then I should be on the Beverage Regulatory Details Page
	Then I enter the text of Product's container or liner contains Bisphenol A (BPA) field to: No
	Then I enter the text of Percent of Alcohol in the Product (numeric entry only) field to: 80
	Then in the Beverage Regulatory Details page, I click Continue

	#Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path
	#I call Shared Step 242081 (Transportation Details 1 - Applicable Only to Alcoholic Beverages - SPIRITS (RU001434) - (Greater than 70% Alcohol))(Step has not created yet)
	Then I should be on the Transportation Details 1 Page
	Then In the Transportation Details 1 Section, set the option in section: 'Product is Regulated for Transport': to: Yes
	Then In the Transportation Details 1 Section, set the option in section: 'Select all modes of transport that you've classified the product for': to: DOT
	Then In the Transportation Details 1 Section, set the option for DOT mode of transport to: Shipping with limited quantity
	Then in the Transportation Details 1 page, I click Continue

	#Then I call Shared Step 92982 (U.S. Department of Transportation (DOT) Classification - For Alcoholic Beverages - Spirits (RU001434) - Packaging Group should pre-select Packaging Group II)
	Then I should be on the U.S. Department of Transportation (DOT) Classification Page
	Then In the U.S. Department of Transportation (DOT) Classification Section, set the option in section: 'UN Number': to: UN3065
	Then In the U.S. Department of Transportation (DOT) Classification Section, verify section: 'Proper Shipping Name' contains value: Alcoholic beverages
	#Then In the U.S. Department of Transportation (DOT) Classification Section, verify section: 'Proper Shipping Name' contains value: Environmentally Hazardous Substance, liquid, n.o.s
	Then In the U.S. Department of Transportation (DOT) Classification Section, verify section: 'Hazard Class (select)' contains value: 3
	Then In the U.S. Department of Transportation (DOT) Classification Section, set the option in section: 'Packing Group': to: II
	Then in the U.S. Department of Transportation (DOT) Classification page, I click Continue

	#Given I call Shared Step 63219 (Retailer Association - Select No Retailer - Click continue)
	#I call Shared Step 242171 (Retailer - Add Retailers - Publix and Walgreens - Applicable Only to Alcoholic Beverages - SPIRITS (RU001434) - (Greater than 70% Alcohol))(Step has not created yet)
	Then I should be on the Retailer Page
	Then In the Retailer Section, click 'Add Retailers' button
#	Then In the 'Select retailers' window I should only see the following retailers:
#		| Retailer									|
#		| Walgreens									|
#		| No Retailer/No UPC Product				|
#		| Publix								    |
	Then In the Select Retailers window, select retailer: Walgreens
	Then In the Select Retailers window, select retailer: Publix
	Then In the Select Retailers window, click 'Done' button
	Then In the Retailer Section is selected retailer: Walgreens
	Then In the Retailer Section is selected retailer: Publix
	Then in the Retailer page, I click Continue

	#I call Shared Step 242192 (Add UPC - Applicable Only to Alcoholic Beverages - SPIRITS (RU001434) - (Greater than 70% Alcohol))(Step has not created yet)
	Then I should be on the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, I click the Add UPC Button
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, for section: 'Provide the product's UPC(s)- including container type and size (ounces)' enter UPC Number: saved as UPC92943 enter Size: 22.8 and enter Container Type: Glass Container
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, verify retailer 'WG' is present under the 'Destination Retailers' column
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, verify retailer 'PX' is present under the 'Destination Retailers' column
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, under Transportation column the checkbox 'DOT' is checked
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, under Transportation column the checkbox 'Shipping with limited quantity' is checked
	Then in the Global Trade Item Number (GTIN) / Universal Product Code (UPC) page, I click Continue

	# these steps need to be reviewed by manual testing - 03/26/25 
	#I call Shared Step 242197 (Additional Documents to Provide - Applicable Only to Alcoholic Beverages - SPIRITS (RU001434) - (Greater than 70% Alcohol))(Step has not created yet)
	Then I should be on the Additional Documents to Provide Page
	#Then The Generic Private Label (all sides) question is displayed
	Then In the Additional Documents to Provide, section 'Generic Private Label (all sides)' is displayed
	#Then The Upload SDS (Optional) question is displayed
	Then In the Additional Documents to Provide, section 'OSHA-compliant Safety Data Sheet (Optional)' is displayed
	#Then The Flash Point Testing Report question is displayed
	Then In the Additional Documents to Provide, section 'Flash Point Testing Report' is displayed
	#Then The Transportation Exemption Letter or Special Permit question is displayed
	Then In the Additional Documents to Provide, section 'Transportation Exemption Letter or Special Permit' is displayed
	Then In the Additional Documents to Provide, upload PDF document to 'OSHA-compliant Safety Data Sheet (Optional)' field
	#Then In the Additional Documents to Provide, for section OSHA SDS button View should exists
	Then In the Additional Documents to Provide, for section 'OSHA-compliant Safety Data Sheet (Optional)' the button 'View' should exists
	#Then In the Additional Documents to Provide, for section OSHA SDS button Remove should exists
	Then In the Additional Documents to Provide, for section 'OSHA-compliant Safety Data Sheet (Optional)' the button 'Remove' should exists
	#Then In the Additional Documents to Provide, for section OSHA SDS I click button 'View'
	Then In the Additional Documents to Provide, for the section 'OSHA-compliant Safety Data Sheet (Optional)', I click the 'View' button
	Then In the Additional Documents to Provide, after clicking 'View' button I confirm pdf file is downloaded
	Given in the Additional Documents to Provide page I click Continue

	#Then I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: [string]
	Then I should be on the Optional Comments Page
	Then The Provide any additional comments or information about the product that you want the Assessment Team to know. question is displayed
	Given in the Optional Comments page I click Continue
	Then I should be on the Data Acceptance Page
	Then In the Data Acceptance Section, click 'Summary' button

	#Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Alcoholic Beverages - Wine
	Then I switch to the tab with Data Summary page
	Then In the Summary Page, the 'Type of Product (select)' section should be showing the following value: Alcoholic Beverages - Spirits
	Then In the Summary Page, the 'Flash Point Testing Method Used' section should be showing the following value: The flash point value provided is per a Closed Cup test method
	Then In the Summary Page, the 'Product's container or liner contains Bisphenol A (BPA)' section should be showing the following value: No
	Then In the Summary Page, the 'Percent of Alcohol in the Product (numeric entry only)' section should be showing the following value: 80
	Then In the Summary Page, the 'Product is Regulated for Transport' section should be showing the following value: Yes
	Then In the Summary Page, the 'Select all modes of transport that you've classified the product for' section should be showing the following value: DOT
	Then In the Summary Page, the 'Select all modes of transport that you've classified the product for' section should be showing the following value: Shipping with limited quantity
	Then In the Summary Page, the 'Proper Shipping Name' section should be showing the following value: Alcoholic beverages
	Then In the Summary Page, the 'Hazard Class (select)' section should be showing the following value: 3
	Then In the Summary Page, the 'Packing Group (select)' section should be showing the following value: II
	Then In the Summary Page, verify table data in column UPC Transportation showing the value: DOT
	Then In the Summary Page, verify table data in column UPC Transportation showing the value: Shipping with limited quantity  
	Then In the Summary Page, verify table data in column Container Type showing the value: Glass Container
	Then In the Summary Page, verify table data in column Size (Ounces) showing the value: 22.8
	Then In the Summary Page, verify table data in column Retailers showing the value: PX, WG
	#steps needs to be reviewed by manual testing -- 3/26/2025 
	#Then In the Summary Page, the document section (.*) should be showing the following document: testdoc.pdf
	#Then In the Summary Page, click the View button for section: (.*)
	Then In the Summary Page, after clicking 'View' button I confirm pdf file is downloaded
	Then I close the tab with Data Summary page

	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase92943
 	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase92943

	@TestCase:216709
	Scenario: [216709] Container Types -Primary Physical State Liquid - Wine - RU001418

	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load

	Given I generate a random UPC number and save as: UPC216709
	Given In the Product Grid, delete all products with UPC Number: saved as UPC216709

	#Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Then In the Side Menu, click Labeled Link with Add Product title
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration'
	Then in the New Product page, I click Continue

	#Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Alcoholic Beverages - Wine
	Then In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Alcoholic Beverages - Wine
	Then In the Product Section, set the option in section: 'Type of Product (select)' to: Alcoholic Beverages - Wine
	Then in the The Product page, I click Continue

	Then I save the product information as: TestCase216709

	#Then I call Shared Step 216821 - Product Information - Product Information - Applicable Only to Alcoholic Beverages - Wine (RU001418)
	Then I should be on the Product Information Page
	Then In the Product Information Section, set the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' to select: United States
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page, I click Continue

	#Then I call Shared Step 216822 (Physical and Chemical Properties - Applicable Only to Alcoholic Beverages - Wine (RU001418))
	Then I should be on the Physical and Chemical Properties Page
	Then In the Physical and Chemical Properties Section, set the option in section: 'Primary Physical State' to: Liquid
	Then In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Liquid
	Then In the Physical and Chemical Properties Section, for section: 'Relative Density' enter text: 0.1
	Then In the Physical and Chemical Properties Section, for section: 'pH' enter text: 7
	Then In the Physical and Chemical Properties Section, for section: 'Boiling Point (in Celsius)' enter text: 78
	Then In the Physical and Chemical Properties Section, for section: 'Flash Point (in Celsius)' enter text: 34
	Then In the Physical and Chemical Properties Section, set the option in section: 'Flash Point Testing Method Used' to: Closed cup method
	Then in the Physical and Chemical Properties page, I click Continue

	#Then I call Shared Step 57503 (Inventory Status, Prop 65 (US) - TSCA(Any Option) - Prop 65 (NO) - Continue - Happy Path)
	Then I should be on the Inventory Status, Prop 65 (US) Page
	Then In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	Then In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page, I click Continue

	#Then I call Shared Step 216838 (Beverage Regulatory Details - Applicable Only to Alcoholic Beverages - Wine (RU001418)):
	#| BPA | Percent of Alcohol |
	#| No  | 8.3                |
	Then I should be on the Beverage Regulatory Details Page
	Then I enter the text of Product's container or liner contains Bisphenol A (BPA) field to: No
	Then The Percent of Alcohol in the Product (numeric entry only) question is displayed
	Then I enter the text of Percent of Alcohol in the Product (numeric entry only) field to: 7.3
	Then in the Beverage Regulatory Details page, I click Continue

	#Then I call Shared Step 216860 (Transportation Details 1 - Applicable Only to Alcoholic Beverages - Wine (RU001418))
	Then I should be on the Transportation Details 1 Page
	Then In the Transportation Details 1 Section, set the option in section: 'Product is Regulated for Transport': to: No, due to an exemption or exception
	Then In the Transportation Details 1 page the 'Please select DOT Exceptions if applicable?' question is displayed
	Then In the Transportation Details 1 Section, set the option in section: 'Please select DOT Exceptions if applicable?': to: 173.150(d)(1) - Exemption for alcoholic beverages (wine and distilled spirits), <=24% alcohol by volume, is contained in an inner packaging of 5L or less
	Then in the Transportation Details 1 page, I click Continue

	#Then I call Shared Step 216861 (Transportation Details 2 > Applicable Only to Alcoholic Beverages - Wine (RU001418))
	Then I should be on the Transportation Details 2 Page
	Then The International Shipping when DOT Exemption taken? question is displayed
	Then In the Transportation Details 2 Section, set the option in section: 'International Shipping when DOT Exemption taken?': to: I do not ship internationally and I do not know the classification
	Then in the Transportation Details 2 page, I click Continue

	#Then I call Shared Step 216862 (Retailer - Add Retailer - Applicable Only to Alcoholic Beverages - Wine (RU001418): Walgreens
	Then I should be on the Retailer Page
	Then In the Retailer Section, click 'Add Retailers' button
	Then In the Select Retailers window, select retailer: Walgreens
	Then In the Select Retailers window, click 'Done' button
	Then in the Retailer page, I click Continue

	#Then I call Shared Step 216863 (UPC Screen - Verify that the Updated Container Types Applicable to Alcoholic Beverages - Wine) Enter UPC: saved as UPC216709, container type: Plastic Liner/Corrugate and size: 12.8
	Then I should be on the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, I click the Add UPC Button
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, verify option 'Size (Fluid Ounces)' is present
	Then  I should see following container type from the drop down list
	|Container Type|
	| Glass Container                |
	| Metal Container                |
	| Metal Cylinder                 |
	| Plastic Container              |
	| Plastic Liner/Corrugate        |
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, for section: 'Provide the product's UPC(s)- including container type and size (ounces)' enter UPC Number: saved as UPC216709 enter Size: 12.8 and enter Container Type: Plastic Liner/Corrugate
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, verify retailer 'WG' is present under the 'Destination Retailers' column
	Then in the Global Trade Item Number (GTIN) / Universal Product Code (UPC) page, I click Continue
	Then I should be on the Additional Documents to Provide Page

	#Then I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase216709
	Then I navigate to the Home Page
	Then I delete the product: TestCase216709
