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

Feature: Flow 29 - Beverage


@TReVorId:11622
@TestCase:60694
Scenario: [60694] Alcoholic Beverages - Wine - RU001418 - (More than 24% but Less than 70% of Alcohol Content) - DOT - Packaging Group III Should be Pre-Selected
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC60694
	Given I delete all products with UPC Number: saved as UPC60694
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Wine
	Then I save the product information as: TestCase60694
	Given I call Shared Step 59922 (Product Information - Private Label or Brand only)
	Given I call Shared Step 92950 (Physical and Chemical Properties - Physical Property - Liquid - For Wine Less than <70% Alcohol)
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I call Shared Step 92964 (Beverage Regulatory Details Less < 70%)
	Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	Given I call Shared Step 71618 (U. S. Department of Transportation (DOT) Classification - For Alcohol (Packaging III))
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	Given in the Additional Documents to Provide page I click Continue
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: User added Comments Text 60694.
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Alcoholic Beverages - Wine
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase60694

#Retailers section needs to be confirmed!
@TReVorId:22293
@TestCase:60695
Scenario: [60695] Juice and Juice Drinks - RU001413
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC60695
	Given I delete all products with UPC Number: saved as UPC60695
	Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Juice and Juice Drinks
	Then I save the product information as: TestCase60695
	Given I call Shared Step 69687 (Product Information - US, No(PL))
	And I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I call Shared Step 49818 (Beverage Regulatory Details)
	Then I click 'Add Retailers' in the Retailers page
	Then In the 'Select retailers' window I should not see the following retailers:
		| Retailer |
		| Autozone |
	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Walgreens
	Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC60695, container type: Plastic Container and size: 3.5
	Then I should see the Additional Documents to Provide Page
	Given in the Additional Documents to Provide page I click Continue
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: User added Comments Text 60694. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Juice and Juice Drinks
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase60695


#Remove from regression: 2023/04
@ignore
@TestCase:73085
Scenario: [73085] Wine - RU001418 - Walgreens and No Retailer only for Retailers
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Alcoholic Beverages - Wine
	Then I save the product information as: TestCase73085
	Given I call Shared Step 59922 (Product Information - Private Label or Brand only)
	Given I call Shared Step 92950 (Physical and Chemical Properties - Physical Property - Liquid - For Wine Less than <70% Alcohol)
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I call Shared Step 49818 (Beverage Regulatory Details)
	Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	Given I call Shared Step 71618 (U. S. Department of Transportation (DOT) Classification - For Alcohol (Packaging III))
	Then the 'Select Retailers' window appears
	Then In the 'Select retailers' window I should only see the following retailers:
		| Retailer									|
		| Walgreens									|
		| No Retailer/No UPC Product				|
		| Publix								    |
		| Optoro								    |
		| Office Depot							    |
		| Onboarding test for ItemScan Subscription |
	Given I click Close in the Select Retailers popup
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase73085



@TestCase:144468
Scenario: [144468] Alcoholic Beverages - Beer - RU001417 - Complete Flow Check, With DOT Exception

Given I log in with the account saved in TReVor as: ProductAccount
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Alcoholic Beverages - Beer
Then I save the product information as: TestCase144468
Then I confirm that the the option: United States is checked for the following section: Select countries the product may be sold in
Given I set the Product is a Retailer's Private Label or Brand option to exactly match: No
Given I click continue
Given I call Shared Step 62686 (Enter Physical Property - Liquid - Without Water Solubility)
Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
Given I call Shared Step 92981a (Beverage Regulatory Details):
	| BPA | Percent of Alcohol |
	| No  | 10                |
And I set the Product is Regulated for Transport option to: No, due to an exemption or exception
And The following checkboxes should not be displayed for section: Please select DOT Exceptions if applicable?
	| Checkbox                                                     |
	| 173.159(a) - Exemption for non-spillable lead-acid batteries |
And I set the Please select DOT Exceptions if applicable? option to exactly match: 173.150(d)(1) - Exemption for alcoholic beverages (wine and distilled spirits), <=24% alcohol by volume, is contained in an inner packaging of 5L or less
And I click continue
Then I call Shared Step 62536 (Transportation Details 2 > I do not ship internationally > Continue - Happy Path)
And in the Ratailer page I click Continue
And in the Additional Documents to Provide page I click Continue
And in the Optional Comments page I click Continue
And In the Data Acceptance page I select Agreed
Then I call Shared Step 73956 (Go to Summary and verify data) with product type: Alcoholic Beverages - Beer
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase144468


# Created by Saikiran Chittampally
# Test case can be found at the following paths:
# NetProjects10\WERCSmart UX Reboot\WERCSmart\Product Registration\Flow 29
@TestCase:105007
Scenario: [105007] Wine - RU001418 - Not Regulated Less than <=24% Alcohol

	#Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC105007
	Given I delete all products with UPC Number: saved as UPC105007
	#Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Then in the New Product page, I click Continue
	#Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Wine
	Then In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Alcoholic Beverages - Wine
	Then In the Product Section, set the option in section: 'Type of Product (select)' to: Alcoholic Beverages - Wine
	Then in the The Product page, I click Continue
	Then I save the product information as: TestCase105007
	#Given I call Shared Step 90477 - Product Information - US, (NO) Retailer's PL
	Then I should be on the Product Information Page
	Then In the Product Information Section, set the option in section: 'Retailers will be selling my product at their store locations in (select either or both) ' to select: United States
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product ' to: Yes
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
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, for section: 'Provide the product's UPC(s)- including container type and size (ounces)' enter UPC Number: saved as UPC105007 enter Size: 12.3 and enter Container Type: Glass Container
	Then in the Global Trade Item Number (GTIN) / Universal Product Code (UPC) page, I click Continue
	#Given in the Additional Documents to Provide section page I click Continue
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
	Then I search for the product saved as: TestCase105007
	Then I confirm that the label: 'PL' is displayed next to the Product Name for the top result in the grid

	


# Created by Saikiran Chittampally
# Test case can be found at the following paths:
# NetProjects10\WERCSmart UX Reboot\WERCSmart\Product Registration\Flow 29
@TestCase:92943
Scenario: [92943] Alcoholic Beverages - Spirits - RU001434 - (Greater > 70% of Alcohol Content) - DOT - Packaging Group II Should be Pre-Selected
	
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC92943
	Given I delete all products with UPC Number: saved as UPC92943
	Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Spirits
	Then I save the product information as: TestCase92943
	Given I call Shared Step 90477 - Product Information - US, (NO) Retailer's PL
	Given I call Shared Step 92979 (Physical and Chemical Properties - Physical Property - Liquid - For Spirits (RU001434) (Greater than 70% Alcohol))
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I call Shared Step 92981a (Beverage Regulatory Details):
	| BPA | Percent of Alcohol |
	| No  | 100                |
	Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	Given I call Shared Step 92982 (U. S. Department of Transportation (DOT) Classification - For Alcoholic Beverages - Spirits (RU001434) - Packaging Group should pre-select Packaging Group II)
	Given I call Shared Step 63219 (Retailer Association - Select No Retailer - Click continue)
	Given in the Additional Documents to Provide section page I click Continue
	Given in the optional comments page I click Continue
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Alcoholic Beverages - Spirits
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase92943

	@TestCase:216709

	Scenario: [216709] Container Types -Primary Physical State Liquid - Wine - RU001418

	Given I log in with the account saved in TReVor as: ProductAccount
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC216709
	Given I delete all products with UPC Number: saved as UPC216709
	#Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Then in the New Product page, I click Continue
	#Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Alcoholic Beverages - Wine
	Then In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Alcoholic Beverages - Wine
	Then In the Product Section, set the option in section: 'Type of Product (select)' to: Alcoholic Beverages - Wine
	Then in the The Product page, I click Continue
	Then I save the product information as: TestCase216709
	#Then I call Shared Step 216821 - Product Information - Product Information - Applicable Only to Alcoholic Beverages - Wine (RU001418)
	Then I should be on the Product Information Page
	Then In the Product Information Section, set the option in section: 'Retailers will be selling my product at their store locations in (select either or both) ' to select: United States
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product ' to: No
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
	Then I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase216709

@ignore
#Removed from regression 2023/11
	@TestCase:161374

	Scenario: [161374] Enhanced Water Beverage (RUU001411)

	Given I log in with the account saved in TReVor as: ProductAccount
	Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Enhanced Water Beverage
	Then I save the product information as: TestCase161374
	Then I call Shared Step 90477 - Product Information - US, (NO) Retailer's PL
	Then I call Shared Step 57441 (Physical and Chemical Properties - Primary Physical Property - Liquid)
	Then I call Shared Step 57503 (Inventory Status, Prop 65 (US) - TSCA(Any Option) - Prop 65 (NO) - Continue - Happy Path)
	Given I call Shared Step 178053 (Beverage Regulatory Details - BPA - Prop65):
	| BPA | Percent of Alcohol | Prop 65 |
	| No  | 100                | No      |
	And in the Retailer page I click Continue
	And in the Additional Documents to Provide page I click Continue
	And in the Optional Comments page I click Continue
	And In the Data Acceptance page I select Agreed
	Then I call Shared Step 73956 (Go to Summary and verify data) with product type: Enhanced Water Beverage
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase161374
