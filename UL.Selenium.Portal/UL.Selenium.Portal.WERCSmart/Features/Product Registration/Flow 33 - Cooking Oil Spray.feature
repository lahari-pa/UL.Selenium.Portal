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
@@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:ProductInformation
@run_Flow33_CookingOilSpray

Feature: Flow 33 - Cooking Oil Spray

# Created by Aaron Caton
@TestCase:69577
Scenario: [69577] Cooking Oil Spray - Aerosol
	Given I generate a random UPC number and save as: UPC69577
	And I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	And I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Cooking Oil Spray - Aerosol
	#Given I call Shared Step 60756 (Product Information with Country and every option)
	Given I should see the Product Information Page
	Then In the Product Information Section, set the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' to select: United States
	Then In the Product Information Section, set the option in section: 'Select the product's Country of Origin' to: United States of America
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Given in the Product Information page I click Continue

	And I call Shared Step 60778 (Primary Physical Property - Packaged in gas cylinder)
	Given I click continue
	Then I should see an error message: ALERT! The ingredient table does not include a compressed gas (Bag-On-Valve) or a propellant. Please update your ingredients to include the propellant before proceeding.
	And I call Shared Step 69557 (Enter Ingredients for Aerosol Propellent)
	Then I should not see an error message: ALERT! The ingredient table does not include a compressed gas (Bag-On-Valve) or a propellant. Please update your ingredients to include the propellant before proceeding.
	And I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	And I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	And I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)
	And I call Shared Step 57923 (Volatile Organic Compound (VOC) Step - enter OTC and CARB - Yes for state values)
		| Product granted Alternative Control Plan | Amount of VOC by CARB | Amount of VOC by OTC Model | VOC for states |
		| No                                       | 2                     | 2                          | Yes            |
	And I click continue
	And I call Shared Step 63219 (Retailer Association - Select No Retailer - Click continue)
	And I call Shared Step 78080 (Regulatory Documents to Provide - Upload OSHA SDS)
	And I call Shared Step 60567 (Upload Product Label only) for section: Volatile Organic Compounds
	And I click continue
	And I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Comment Test 69577
	And I call Shared Step 73956 (Go to Summary and verify data) with product type: Cooking Oil Spray - Aerosol
	And I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase69577
