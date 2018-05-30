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
@run_Flow31_Seasonings

Feature: [64739] Flow 31 - Seasonings
@mytag
Scenario: Scenario: [60738] Seasonings, Spices or Flavoring for Food - Salts (Liquid)- RU001246
	# ====== Logging in as the correct user ====== #
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

# ====== Just checks that the correct page loads ====== #
Given If I see the retail partners page I set all data consent tiers to true for all retailers in the top section
Then The home screen should load

# ====== Test Setup - Generating + Saving UPC Number and ensuring no duplicates exist ====== #
Given I generate a random UPC number and save as: UPC60738
Given I delete all products with UPC Number: saved as UPC60738

Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)

#Enter "Seasonings, Spices or Flavoring for Food - Salts" in Type of Product smart search field 

Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product)

Then I save the product information as: TestCase60738

Given I call Shared Step 60747 (Select Primary Physical Property - Liquid - With Ingredients)
