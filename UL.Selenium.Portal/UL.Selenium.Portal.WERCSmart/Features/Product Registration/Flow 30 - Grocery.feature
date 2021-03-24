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
@run_Flow30_Grocery
Feature: [64735] Flow 30 - Grocery

@ScenarioId:714
Scenario: [60725] Baked Goods, Crackers - RU001449
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given If I see the retail partners page I set all data consent tiers to true for all retailers in the top section
	Then The home screen should load
	# ====== Test Setup - Generating + Saving UPC Number and ensuring no duplicates exist ====== #
	Given I generate a random UPC number and save as: UPC60725
	Given I delete all products with UPC Number: saved as UPC60725
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Baked Goods, Crackers
	Then I save the product information as: TestCase60725
	Given I call Shared Step 74123 (Product Information - Grocery - US - Random Country - No(PL))
	Given I call Shared Step 60741 (Select Primary Physical Property - Solid - With Ingredients)	
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Then I click 'Add Retailers' in the Retailers page
	Then In the 'Select retailers' window I should not see the following retailers:
		| Retailer  |
		| Auto Zone |
	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Walgreens
	Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC60725, container type: Aerosol Can and size: 20
	Given I call Shared Step 60567 (Upload Product Label only)
	# Additional Documents to Provide Page
	And I should see the Additional Documents to Provide Page
	Given I call Shared Step 60715 (Additional Documents to Provide - OSHA SDS - only) : C:\Dependencies\WERCSmart\testdoc.pdf
	# Optional Reports and Documents Available for Purchase Page
	And I should see the Optional Reports and Documents Available for Purchase Page
	Then in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: Comment Text
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Baked Goods, Crackers
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase60725

@ScenarioId:713
Scenario: [60724] Condiments, Sauces - RU001454
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given If I see the retail partners page I set all data consent tiers to true for all retailers in the top section
	Then The home screen should load
	# ====== Test Setup - Generating + Saving UPC Number and ensuring no duplicates exist ====== #
	Given I generate a random UPC number and save as: UPC60724
	Given I delete all products with UPC Number: saved as UPC60724
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Condiments, Sauces
	Then I save the product information as: TestCase60724
	Given I call Shared Step 69687 (Product Information - US, No(PL))
	Given I call Shared Step 60747 (Select Primary Physical Property - Liquid - With Ingredients)
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Walgreens
	Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC60724, container type: Aerosol Can and size: 20
	And I click continue
	Then Upload Full Product Label (required) (For private label products please upload a generic label that is not retailer-specific.) should be showing the error messages: Document is required: Product Label
	Given I call Shared Step 60567 (Upload Product Label only)
	And I should see the Additional Documents to Provide Page
	And I click continue	
	And I should see the Optional Reports and Documents Available for Purchase Page
	Then in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: Comment Text
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Condiments, Sauces
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase60724

@ScenarioId:712
Scenario: [60723] Jelly, Jam or Preserves - RU001456
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given If I see the retail partners page I set all data consent tiers to true for all retailers in the top section
	Then The home screen should load
	# ====== Test Setup - Generating + Saving UPC Number and ensuring no duplicates exist ====== #
	Given I generate a random UPC number and save as: UPC60723
	Given I delete all products with UPC Number: saved as UPC60723
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Jelly, Jam or Preserves
	Then I save the product information as: TestCase60723
	Given I call Shared Step 69687 (Product Information - US, No(PL))
	Given I call Shared Step 60741 (Select Primary Physical Property - Solid - With Ingredients)
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	#Confirm that "Auto Zone" is not listed as a retailer on the Select Retailers pop up
	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Walgreens
	Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC60723, container type: Aerosol Can and size: 20
	Given I call Shared Step 60567 (Upload Product Label only)
	# Additional Documents to Provide Page
	And I should see the Additional Documents to Provide Page
	Given I call Shared Step 60715 (Additional Documents to Provide - OSHA SDS - only) : C:\Dependencies\WERCSmart\testdoc.pdf
	# Optional Reports and Documents Available for Purchase Page
	And I should see the Optional Reports and Documents Available for Purchase Page
	Then in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: Comment Text
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Jelly, Jam or Preserves
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase60723

@tfs_design
Scenario: [60722] Nut Butters - RU001455
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given If I see the retail partners page I set all data consent tiers to true for all retailers in the top section
	Then The home screen should load
	# ====== Test Setup - Generating + Saving UPC Number and ensuring no duplicates exist ====== #
	Given I generate a random UPC number and save as: UPC60722
	Given I delete all products with UPC Number: saved as UPC60722
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Nut Butters
	Then I save the product information as: TestCase60722
	Given I call Shared Step 74123 (Product Information - Grocery - US - Random Country - No(PL))
	Given I call Shared Step 60741 (Select Primary Physical Property - Solid - With Ingredients)
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	#Confirm that "Auto Zone" is not listed as a retailer on the Select Retailers pop up
	Given I call Shared Step 69682 (Retailer Association - Add Private Label Information) and select the retailer: Walgreens and enter the name: Private Label Aspirin
	Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC60722, container type: Aerosol Can and size: 20
Given I call Shared Step 60567 (Upload Product Label only)
	# Additional Documents to Provide Page
	And I should see the Additional Documents to Provide Page
	Given I call Shared Step 60715 (Additional Documents to Provide - OSHA SDS - only) : C:\Dependencies\WERCSmart\testdoc.pdf
	# Optional Reports and Documents Available for Purchase Page
	And I should see the Optional Reports and Documents Available for Purchase Page
	Then in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: Comment Text
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Nut Butters
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase60722

@ScenarioId:715
Scenario: [73041] Cereals - RU001448 - Retailers associated Walgreens
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given If I see the retail partners page I set all data consent tiers to true for all retailers in the top section
	Then The home screen should load
	# ====== Test Setup - Generating + Saving UPC Number and ensuring no duplicates exist ====== #
	Given I generate a random UPC number and save as: UPC73041
	Given I delete all products with UPC Number: saved as UPC73041
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Cereals
	Then I save the product information as: TestCase73041
	Given I call Shared Step 74123 (Product Information - Grocery - US - Random Country - No(PL))
	Given I call Shared Step 60741 (Select Primary Physical Property - Solid - With Ingredients)
	And I call Shared Step 132370 (Waste Classification Data - TSCA (Random) - Prop 65 (No) - Continue - Happy Path)
	Then I click 'Add Retailers' in the Retailers page
	Then In the 'Select retailers' window I should see the following retailers:
		| Retailer                   |	
		| Walgreens                  |
	Given I click Done in the Select Retailers popup
	Given I navigate to the home page
	Then I delete the product: TestCase73041
