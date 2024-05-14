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
@ProductSetUp
@ForwardProductRegistration
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:ProductInformation
@run_Walmart
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:ProductInformation
@PhysicalAndChemicalProp
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:RegulatoryDocumentsToProvide
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:OptionalComments

@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:InventoryStatusProp65
@StepsPrototype
Feature: Walmart


#Background:
#	Given I verify the following users exist and if not I create them using SHAUser
#		| username    | FirstName | LastName   | Role         | EmailAddress                |
#		| SHAQAAuto31 | QA        | Automation | QA Reviewers | qasha.kxxyxunf@mailosaur.io |

@tfs_design
@ignore
@TestCase:73917
Scenario: [73917] Walmart Affiliates When Registering Data for the First Time
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	#Test case calls shared 31053 but this is identical
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Candle and/or Wax
	Then I save the product information as: TestCase73917
	Given I call Shared Step 57401 (Product Information - US only - No GHS, Not Direct Ship, Not PLP, Not GNFR > Continue - Happy Path)
	#Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I should see the Physical and Chemical Properties Page
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' should be showing the option: Solid
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' confirm option is selected: Solid
	Then In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
	Then In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Then In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
	Then in the Physical and Chemical Properties page I click Continue

	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| 7647-14-5     | 100     | false               | false       |            |
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	# Not currently showing Reg 3 page - requires specific product type or ingredient present?
	Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
	Then the 'Select Retailers' window appears
	Given I select any Walmart Affiliate automatically selects all from that group, then 'Wal-Mart/SAM'S CLUB' is displayed on the retailers page
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase73917

@TestCase:73920
Scenario: [73920] Walmart Affiliates when Viewing My Retail Partners
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I click the Retail Partners icon in the Navigation Pane
	Then I should see the Retail Partners page
	Given I check that the following retailers are showing:
		| Retailer    | Code  |
		| BONOBOS     | WM-BO |
		| Walmart.com | WM-CO |
		| Hayneedle   | WM-HN |
		| Jet         | WM-JE |
		| MODCLOTH    | WM-MC |
		| Moosejaw    | WM-MJ |
		| Shoes.com   | WM-SC |
	Given I click each Wal-mart affiliate retailer and should be taken to the Wal-mart/SAM'S CLUB view
	And I navigate to the home page

@TestCase:74133
Scenario: [74133] Walmart Product Type Electronics
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	#Test case calls shared 31053 but this is identical
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Electronic Equipment with Circuit Board Only
	Then I save the product information as: TestCase74133
	#And I call Shared Step 60935 (Product Information - US - Direct Ship - Private Label Only)
	Given I should see the Product Information Page
	Given In the Product Information Section, set the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' to select: United States
	Given In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Given In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Given in the Product Information page I click Continue

#	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Then I should be on the Inventory Status, Prop 65 (US) Page
	And In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	And In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page, I click Continue

	Given I call Shared Step 48369 (Toxicity Characteristics Leaching Procedure (TCLP) - No to ALL With Copper)
	And I should see the Electronic Equipment Page
	And I set 'Contains Circuit Board' to: Yes
	And I set 'Has a LCD or Plasma Display' to: No
	And in the New Product page I click Continue
	Given the 'Select Retailers' window appears
	Given I check that Walmart and all of its affiliates are not available
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase74133

@tfs_design
@ignore
@TestCase:74017
Scenario: [74017] Walmart Affiliates when Adding a UPC
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC74017
	Given I delete all products with UPC Number: saved as UPC74017
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Soap (Bar, Liquid) for Body
	Then I save the product information as: TestCase74017
	#Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Given I should see the Product Information Page
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)' to: No
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue

	Given I call Shared Step 77711 (Product Characteristics - Primary (L/S), 2nd - any, Enter Gravity, pH, Boiling Point, Flash Point, Flash Point Test - any, Water - any)
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Glycerol      | 50      | false               | false       |            |
		| Palm oil      | 50      | false               | false       |            |
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
	Then the 'Select Retailers' window appears
	Given In the 'Select Retailers' window I select the retailer: Jet
	Given I click continue
	Given In the Retailers tab, I select Vendor id as: test
	And I click continue
	Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC74017, container type: Cardboard and size: 15

# Next test steps are not compatible...
# Click Add Retailer Link
# select Wal-mart/ SAMs CLUB
# confirm WM under Destination Retailers
@tfs_design
@ignore
@TestCase:73919
Scenario: [73919] Walmart Affiliates when Direct Ship Vendor is set to YES
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC73919
	Given I delete all products with UPC Number: saved as UPC73919
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Soap (Bar, Liquid) for Body
	Then I save the product information as: TestCase73919
	Given I call Shared Step 57501 (Physical and Chemical Properties - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue - HP)
	# Additional Product Info? As title suggests, needs set 'direct ship' to yes
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Glycerol      | 50      | false               | false       |            |
		| Palm oil      | 50      | false               | false       |            |
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
	Then the 'Select Retailers' window appears
	Given I select any Walmart Affiliate automatically selects all from that group, then 'Wal-Mart/SAM'S CLUB' is displayed on the retailers page
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase73919

@ignore
@TestCase:73918
Scenario: [73918] Walmart Affiliates when Forwarding to a New Retailer
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I create a product with name: Chalk and UPC: UPC73918 and take to completed using Test Case 75335 with no login step and save as: TestCase73918
	Given I create a product with name: Chalk and UPC: UPC73918 and take to completed using Test Case 75335and SHA account: SHAQAAuto31 with no login step and save as: TestCase73918
	Given I navigate to the landing page
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I click Bulk Actions in the Products Grid
	Then I should see a popup with header Bulk Actions
	Given I click Forward Product Registration in the Bulk Actions window
	Then I should see the header: Forward Product Registration on the Forward Product Registration window
	And I confirm the active Forward Product Registration tab is: Select Products
	Given I enter the text: saved as TestCase73918 in the 'Search by WPS ID or Product Name' field
	Given I select the first product under the Select Products tab
	Given I click continue on the Forward Product Registration page
	Then I confirm the active Forward Product Registration tab is: Select Retailers
	Given in the Select Retailers tab under Forward Product Registration I select the retailer: Wal-Mart/SAM'S CLUB
	Then I confirm that all Walmart affiliate retail parters are selected
	Given I click continue on the Forward Product Registration page
	Then I confirm the active Forward Product Registration tab is: Select UPCs
	# 'Private Label' dropdown is a required field for some products
	Given I select the first product under the Select UPCs tab
	Given I select the Vendor option: TestBrand for the first product displayed under the Select UPCs tab
	Given I select the first UPC in the grid under the Select UPCs tab
	Then I confirm that: WM is displayed in the Destination Retailers column under Select UPCs
	Given I click continue on the Forward Product Registration page
	Then I confirm the active Forward Product Registration tab is: Product Results
	And I confirm that: WM is displayed in the Destination Retailers column under Product Results
	Given I click the Home navigation icon and accept the alert popup

@ignore
@TestCase:63684
Scenario: [63684] Walmart Private label product
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given If I see the retail partners page I set all data consent tiers to true for all retailers in the top section
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC63684
	Given I delete all products with UPC Number: saved as UPC63684
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Pet shampoo
	Then I save the product information as: TestCase63684
    Given I call Shared Step 63804 (Product Information - US, No(OSHA), No(DSV), Yes (PLP), No(GNFR))
		| Classified using OSHA (US) Globally Harmonized Standards (GHS) | Shipped directly by supplier | Private Label or Brand | Good Not for resale |
		| No                                                             | No                           | Yes                    | No                  |
		Given I call Shared Step 73629 (Physical and Chemical Properties - Liquid - select any options(enter pH, boiling point, flash point))
		| Secondary Physical State | Relative Density | pH | Boiling Point (in Celsius) | Flash Point (in Celsius) | Flash Point Testing Method Used | Select the best Water Solubility description |
		| Liquid                   | 2                | 2  | 2                          | 66                       | Closed cup method               | Dispersible                                  |
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Cocoa butter  | 100     | false               | false       |            |
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
	Given I call Shared Step 65181 (Retailer Association - Add Private Label Information and Select Vendor ID) and select the retailer: Wal-Mart/SAM'S CLUB and enter the name: Holiday Time and select Vendor id: random
	Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC63684, container type: Plastic Container and size: 3.6
	#Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I should see the Regulatory Documents to Provide Page
	Then In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: Request to author
	Then in the Regulatory Documents to Provide page I click Continue

	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient |
		| Apron                         | 550                      | 63.625                  | 33.333    | Brown      | Banana | No data available | 30                    |
	#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: User added Comments Text 58079. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Pet shampoo
	Given I navigate to the home page
	Given I search for the product saved as: TestCase63684
	Then I confirm that the label: 'PL' is displayed next to the Product Name for the top result in the grid
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase63684

@ignore
@TestCase:96705
Scenario: [96705] Light Bulbs - No Walmart
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Light Bulbs - Light Emitting Diodes (LED)
	Then I save the product information as: TestCase96705
	Then I call Shared Step 90477 - Product Information - US, (NO) Retailer's PL
	And I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
    Given I call Shared Step 58189 (Answer Electronic Equipment questions - With Cathode Ray - No to all)
	Then In the 'Select retailers' window I should not see the following retailers:
		| Retailer            |
		| Wal-Mart/SAM'S CLUB |
	Given I click Close in the Select Retailers popup
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase96705
