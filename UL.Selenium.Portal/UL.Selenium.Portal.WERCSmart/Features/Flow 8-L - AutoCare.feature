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
@StepsPrototype
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:TheProduct
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:ProductInformation
@PhysicalAndChemicalProp
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:InventoryStatusProp65
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:TransportationDetails1

Feature: AutoCare

A short summary of the feature

@TestCase:216819
Scenario: [216819] Container Types - Primary Physical State Liquid - Engine Motor Oil for Auto or Boat - RU000269
	Given I log in with the account saved in TReVor as: ProductAccount
	Given I generate a random UPC number and save as: UPC216819
	Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	#Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Engine (Motor) Oil for Auto or Boat
	Then I should see the The Product Page
	Then In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Engine (Motor) Oil for Auto or Boat
	Then I set 'Type of Product' to: Engine (Motor) Oil for Auto or Boat
	Then I save the product information as: TestCase216819
	Then in the The Product page, I click Continue
	#Then I call Shared Step 217667 (Product Information - Applicable Only to Engine Motor Oil for Auto or Boat (RU000269))
	Then I should see the Product Information Page
	When In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	When In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	When In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product ' to: No
	When In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page, I click Continue
	Then I should see the Regulatory Documents to Provide Page
	Then I set the OSHA-compliant Safety Data Sheet, English field to: Request to author	
	Then I click continue	
	#Then I call Shared Step 217668 (Physical and Chemical Properties - Applicable Only to Engine Motor Oil for Auto or Boat (RU000269))
	Then I should see the Physical and Chemical Properties Page
	Given In the Physical and Chemical Properties Section, set the option in section: 'Primary Physical State' to: Liquid
	Given In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Liquid
	Given In the Physical and Chemical Properties Section, for section: 'Relative Density' enter text: 0.8892
	Given In the Physical and Chemical Properties Section, for section: 'pH' enter text: 13
	When In the Physical and Chemical Properties Section, for section: 'Boiling Point (in Celsius)' select the checkbox option: I do not have exact Boiling Point data available to me
	Given In the Physical and Chemical Properties Section, for section: 'Boiling Point (in Celsius)' enter text: Not tested/Unknown
	Given In the Physical and Chemical Properties Section, for section: 'Flash Point (in Celsius)' enter text: 180
	Given In the Physical and Chemical Properties Section, set the option in section: 'Flash Point Testing Method Used' to: Not applicable/available
	Given In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Insoluble in water
	Then in the Physical and Chemical Properties page, I click Continue
	#Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
	#	| ComponentName                                           | Percent | PublicallyDisclosed | TradeSecret | PublicName |
	#	| Mineral Oil, petroleum residual oils, acid-treated      | 100     | false               | false       |            |
	Then I add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Mineral Oil, petroleum residual oils, acid-treated     | 100     | false               | false       |            |
	Given I click continue
	#Then I call Shared Step 57503 (Inventory Status, Prop 65 (US) - TSCA(Any Option) - Prop 65 (NO) - Continue - Happy Path)
	Then I should see the Inventory Status, Prop 65 (US) Page
	Given In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	Given In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page, I click Continue
	#Then I call Shared Step 26900 (Transportation Details 1 > Not Regulated)
	Then I should see the Transportation Details 1 Page
	Given In the Transportation Details 1 Section, set the option in section: 'Product is Regulated for Transport': to: Not Regulated
	Then in the Transportation Details 1 page, I click Continue
	Given I select the following retailers in the Select Retailers popup list view:
		| Retailer       |
		| The Home Depot |
		| Tractor Supply |
	Then I click Done on Select Retailers window
	Then I click continue
	Then I call Shared Step 216819 (UPC Screen - Verify that the Updated Container Types Applicable to Engine Motor Oil for Auto or Boat) Enter UPC: saved as UPC216819, container type: Plastic Liner/Corrugate and size: 16.9
	Then I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase216819
