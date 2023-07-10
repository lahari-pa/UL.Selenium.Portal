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
Feature: Flow 29 - Beverage


@TReVorId:11622
@TestCase:60694
Scenario: [60694] Wine - RU001418
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC60694
	Given I delete all products with UPC Number: saved as UPC60694
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Alcoholic Beverages - Wine
	Then I save the product information as: TestCase60694
	Given I call Shared Step 59922 (Product Information - Private Label or Brand only)
	Given I call Shared Step 92950 (Physical and Chemical Properties - Physical Property - Liquid - For Wine Less than <70% Alcohol)
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I call Shared Step 92964 (Beverage Regulatory Details Less < 70%)
	Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	Given I call Shared Step 71618 (U. S. Department of Transportation (DOT) Classification - For Alcohol (Packaging III))
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	Given in the Additional Documents to Provide page I click Continue
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: User added Comments Text 60694. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
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
Scenario: [144468] Alcoholic Beverages - With DOT Exception

Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Alcoholic Beverages - Beer
Then I save the product information as: TestCase144468
Then I confirm that the the option: United States is checked for the following section: Select countries the product may be sold in
Given I set the Product is a Retailer's Private Label or Brand option to exactly match: No
Given I click continue
Given I call Shared Step 62686 (Enter Physical Property - Liquid - Without Water Solubility)
And I should see the Waste Classification Data Page
Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
Given I call Shared Step 49818 (Beverage Regulatory Details)
And I set the Product is Regulated for Transport option to: No, due to an exemption or exception
And The following checkboxes should not be displayed for section: Please select DOT Exceptions if applicable?
		| Checkbox                                                     |
		| 173.159(a) - Exemption for non-spillable lead-acid batteries |
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase144468



# Created by Saikiran Chittampally
# Test case can be found at the following paths:
# NetProjects10\WERCSmart UX Reboot\WERCSmart\Product Registration\Flow 29
@TestCase:105007
Scenario: [105007] Wine - RU001418 - Not Regulated Less than <=24% Alcohol
	
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC105007
	Given I delete all products with UPC Number: saved as UPC105007
	Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Wine
	Then I save the product information as: TestCase105007
	Given I call Shared Step 90477 - Product Information - US, (NO) Retailer's PL
	Given I call Shared Step 105009 (Physical and Chemical Properties - Wine Not Regulated <=24% Alcohol)
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I call Shared Step 105010 (Beverage Regulatory Details Less < 24%)
	Given I call Shared Step 57984 (Transportation Details - All options available - Select Not regulated - Continue - Happy Path)
	Given I call Shared Step 63219 (Retailer Association - Select No Retailer - Click continue)
	Given in the Additional Documents to Provide section page I click Continue
	Given in the optional comments page I click Continue
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Alcoholic Beverages - Wine
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase105007



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
 
