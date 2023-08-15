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

Feature: AutoCare

A short summary of the feature

@TestCase:216819
Scenario: [216819] Container Types - Primary Physical State Liquid - Engine Motor Oil for Auto or Boat - RU000269
	Given I log in with the account saved in TReVor as: ProductAccount
	Given I generate a random UPC number and save as: UPC216819
	Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Engine (Motor) Oil for Auto or Boat
	Then I save the product information as: TestCase216819
	Then I call Shared Step 217667 (Product Information - Applicable Only to Engine Motor Oil for Auto or Boat (RU000269))
	Then I call Shared Step 217668 (Physical and Chemical Properties - Applicable Only to Engine Motor Oil for Auto or Boat (RU000269))
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName                                           | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Mineral Oil, petroleum residual oils, acid-treated      | 100     | false               | false       |            |
	Then I call Shared Step 57503 (Inventory Status, Prop 65 (US) - TSCA(Any Option) - Prop 65 (NO) - Continue - Happy Path)
	Then I call Shared Step 26900 (Transportation Details 1 > Not Regulated)
	Given I select the following retailers in the Select Retailers popup list view:
		| Retailer       |
		| The Home Depot |
		| Tractor Supply |
	Then I click Done on Select Retailers window
	Then I click continue
	Then I call Shared Step 216819 (UPC Screen - Verify that the Updated Container Types Applicable to Engine Motor Oil for Auto or Boat) Enter UPC: saved as UPC216819, container type: Plastic Liner/Corrugate and size: 16.9
	Then I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase216819
