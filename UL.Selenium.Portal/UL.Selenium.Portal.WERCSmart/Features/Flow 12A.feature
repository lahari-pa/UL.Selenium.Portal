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
@UPC
@SHA
@run_Flow8

Feature: Flow 12A

# Created by Saikiran Chittampally
# Test case can be found at the following paths:
# NetProjects10\WERCSmart UX Reboot\WERCSmart\Product Registration\Flow 12
@TestCase:98077
Scenario: [98077] 3rd Party Exclusive Use Option
	
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC98077
	Given I delete all products with UPC Number: saved as UPC98077
	Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Mixture, Blend, Formula, Polymer or Solution from Third (3rd, 3d) Party
	Then I save the product information as: TestCase98077
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Ethanol       | 20      | false               | false       |            |
		| Paracetamol   | 5       | false               | false       |            |
		| Aqua          | 50      | false               | false       |            |
		| Guaifenesin   | 25      | false               | false       |            |
	Given I call Shared Step 48948 (Formulation > 3rd Party - Select all)
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I call Shared Step 60932 (Regulatory Information 2 - Microbeads - No)
	Given in the Additional Documents to Provide section page I click Continue
	Given in the Formulation Names section page I click Continue
	Given I call Shared Step 58610 (Confirm Restrict Use - Restrict)
	Given in the Sustainability section page I click Continue
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Mixture, Blend, Formula, Polymer or Solution from Third (3rd, 3d) Party
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase98077
	
# Created by Saikiran Chittampally
# Test case can be found at the following paths:
# NetProjects10\WERCSmart UX Reboot\WERCSmart\Product Registration\Flow 12
@TestCase:119476
Scenario: [119476] Mixture, Blend, Formulation, Solution Verifying Formula Name Updates- RU000722
	
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC119476
	Given I delete all products with UPC Number: saved as UPC119476
	Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Mixture, Blend, Formula, Polymer or Solution from Third (3rd, 3d) Party
	Then I save the product information as: TestCase119476
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Ethanol       | 20      | false               | false       |            |
		| Paracetamol   | 5       | false               | false       |            |
		| Aqua          | 50      | false               | false       |            |
		| Guaifenesin   | 25      | false               | false       |            |
	Given I call Shared Step 48948 (Formulation > 3rd Party - Select all)
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I call Shared Step 60932 (Regulatory Information 2 - Microbeads - No)
	Given in the Additional Documents to Provide section page I click Continue
	And I should see following statement: Provide the name(s) to be used to identify the formula
	Then I set the Formula Name for the WERCSmart Ingredient Directory field to: Aerosol
	And I should see following statement: Provide Public Name(s) of the formula you're registering. This will be available to the Supplier to select for your ingredient when the ingredient is indicated to be Publicly Available. Public Names are typically on a products label, website or other information available to the general public.
	And I should see following statement: Public Name 1
	And I should see following statement: Public Name 2
	And I should see following statement: Public Name 3
	Given in the Formulation Names section page I click Continue
	Given I call Shared Step 58610 (Confirm Restrict Use - Restrict)
	Given in the Sustainability section page I click Continue
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Mixture, Blend, Formula, Polymer or Solution from Third (3rd, 3d) Party
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase119476

# Created by Saikiran Chittampally

@TestCase:83844
Scenario: [83844] The Product - Product Name - Name = 449 Characters - Product Name displayed in flow and hover over
	
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC83844
	Given I delete all products with UPC Number: saved as UPC83844
	Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Given I call Shared Step 57561a (The Product - Enter Product Name: 1ProductNameShouldBe449CharactersLongToGenerateErrorMessage--dhjhsjhjhhjhsjhgjshjhdfdfsssssssssssssssshvhswgdwgyag(263526536572)ghasvdghxvsghvxghvsghdgghshhshdgsgdghgshgywgyugwuuydwdhuwhugusguhdgghshhghdghsgdghgshgywgyugwuuydwdhuwhugusgugghshhsghdghsgdghgshgywgyugwuuydwdhuwhugusguhdgghshhsghdghsgdghgshgywgyugwuuydwduhugusguhdgghshhsghdghsgdghgshgywgyugwuuyyxdshudsjyguhhnkjnsduygawuduhsyuyyyuyuuyuyudjfgvhjxgjjcghxhjhsgcjcxjghjxjdsguyugsdujjhycyyy and select Type of Product): bubble solution
	
	Then I save the product information as: TestCase83844
	
	Then I Confirm the Product name is shown at the top of the page
	Then I Confirm the Product name shows on 1 line only and shows (3-dots) ... at the end of the characters
	Then I Confirm the Product Name is shown in full in the hover over pop up
	Then I Confirm the WPS ID for the Product is shown at the end of the Product Name in brackets (parenthesis)
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase83844
