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
@SubEnrollment
@run_Flow31_Seasonings
Feature: [64739] Flow 31 - Seasonings

@TestCase:60737
Scenario: [60737] Seasonings, Spices or Flavoring for Food - Salts (Solid)- RU001246
	# ====== Logging in as the correct user ====== #
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	# ====== Just checks that the correct page loads ====== #
	#Given If I see the retail partners page I set all data consent tiers to true for all retailers in the top section
	Then The home screen should load
	# ====== Test Setup - Generating + Saving UPC Number and ensuring no duplicates exist ====== #
	#Given I generate a random UPC number and save as: UPC60737
	#Given I delete all products with UPC Number: saved as UPC60737
	Given I generate a unique UPC number and save as: UPC60737
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Seasonings, Spices or Flavoring for Food - Salts - Solid
	Then I save the product information as: TestCase60737
	Given I call Shared Step 60756 (Product Information with Country and every option)
	Given I call Shared Step 60741 (Select Primary Physical Property - Solid - With Ingredients)
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Butane        | 100     | false               | false       |            |
	#Given I Confirm the following error message is not visible " ALERT! The ingredient table does not include a compressed gas (Bag-On-Valve) or a propellant. Please update your ingredients to include the propellant before proceeding."
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Walgreens
    Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC60737, container type: Cardboard and size: 20
    Given I call Shared Step 60567 (Upload Product Label only)
	# Additional Documents to Provide Page
	#And I should see the Additional Documents to Provide Page
	Then in the Additional Documents to Provide page I click Continue
	# Optional Reports and Documents Available for Purchase Page
	#And I should see the Optional Reports and Documents Available for Purchase Page
	Then in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Comment Text
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Seasonings, Spices or Flavoring for Food - Salts - Solid
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase60737

@TestCase:60738
Scenario: [60738] Seasonings, Spices or Flavoring for Food - Salts (Liquid)- RU001246
	# ====== Logging in as the correct user ====== #
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	# ====== Just checks that the correct page loads ====== #
	#Given If I see the retail partners page I set all data consent tiers to true for all retailers in the top section
	Then The home screen should load
	# ====== Test Setup - Generating + Saving UPC Number and ensuring no duplicates exist ====== #
	Given I generate a random UPC number and save as: UPC60738
	Given I delete all products with UPC Number: saved as UPC60738
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Seasonings, Spices or Flavoring for Food - Salts (Liquid)
	Then I save the product information as: TestCase60738
	Given I call Shared Step 60756 (Product Information with Country and every option)
	Given I call Shared Step 60747 (Select Primary Physical Property - Liquid - With Ingredients)
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Butane        | 100     | false               | false       |            |
	#Given I Confirm the following error message is not visible " ALERT! The ingredient table does not include a compressed gas (Bag-On-Valve) or a propellant. Please update your ingredients to include the propellant before proceeding."
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I call Shared Step 57506 (Transportation Details 1 - Regulated for Transport(No) - Exemption(Random) - Continue - Happy Path)
	Given I call Shared Step 62536 (Transportation Details 2 > I do not ship internationally > Continue - Happy Path)
	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Walgreens
    Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC60738, container type: Cardboard and size: 20
    Given I call Shared Step 60567 (Upload Product Label only)
	# Additional Documents to Provide Page
	And I should see the Additional Documents to Provide Page
	Then in the Additional Documents to Provide page I click Continue
	# Optional Reports and Documents Available for Purchase Page
	And I should see the Optional Reports and Documents Available for Purchase Page
	Then in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Comment Text
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Seasonings, Spices or Flavoring for Food - Salts (Liquid)
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase60738
