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
Feature: Flow 29 - Beverage

@tfs_design
@TReVorId:11622
Scenario: [60694] Wine - RU001418
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC60694
	Given I delete all products with UPC Number: saved as UPC60694
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Alcoholic Beverages - Wine
	Then I save the product information as: TestCase60694
	Given I call Shared Step 62686 (Enter Physical Property - Liquid - Without Water Solubility)
	Given I call Shared Step 59922 (Additional Product Information - Private Label or Brand only)
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I call Shared Step 49818 (Beverage Regulatory Details)
	Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	Given I call Shared Step 71618 (U. S. Department of Transportation (DOT) Classification - For Alcohol (Packaging III))
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	Given in the Additional Documents to Provide page I click Continue
	Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: User added Comments Text 60694. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Alcoholic Beverages - Wine
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase60694

# no product characteristics step has been added to the test case!
#Retailers section needs to be confirmed!
@TReVorId:22293
Scenario: [60695] Juice and Juice Drinks - RU001413
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC60695
	Given I delete all products with UPC Number: saved as UPC60695
	Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Juice and Juice Drinks
	Then I save the product information as: TestCase60695
	And I call Shared Step 57514 (Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path)
	Given I call Shared Step 69687 (Additional Product Information - US, No(PL))
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I call Shared Step 49818 (Beverage Regulatory Details)
	Then In the 'Select retailers' window I should not see the following retailers:
		| Retailer |
		| Autozone |
	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Walgreens
	Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC60695, container type: Plastic Container and size: 3.5
	Then I should see the Additional Documents to Provide Page
	Given in the Additional Documents to Provide page I click Continue
	Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: User added Comments Text 60694. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Juice and Juice Drinks
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase60695

@tfs_design
#Retailers section needs to be confirmed!
Scenario: [73085] Wine - RU001418 - Walgreens and No Retailer only for Retailers
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Alcoholic Beverages - Wine
	Then I save the product information as: TestCase73085
	Given I call Shared Step 62686 (Enter Physical Property - Liquid - Without Water Solubility)
	Given I call Shared Step 59922 (Additional Product Information - Private Label or Brand only)
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I call Shared Step 49818 (Beverage Regulatory Details)
	Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	Given I call Shared Step 71618 (U. S. Department of Transportation (DOT) Classification - For Alcohol (Packaging III))
	Then the 'Select Retailers' window appears
	Then In the 'Select retailers' window I should only see the following retailers:
		| Retailer                   |
		| Walgreens                  |
		| No Retailer/No UPC Product |
		| Publix                     |
		| Optoro                     |
	Given I click Close in the Select Retailers popup
	#Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Nut Butters
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase73085
