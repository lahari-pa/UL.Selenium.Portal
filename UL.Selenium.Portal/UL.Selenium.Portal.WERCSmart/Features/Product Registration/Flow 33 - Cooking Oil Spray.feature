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
@run_Flow33_CookingOilSpray

Feature: Flow 33 - Cooking Oil Spray

# Created by Aaron Caton
@ScenarioId:1161
Scenario: [69577] Cooking Oil Spray - Aerosol
Given I generate a random UPC number and save as: UPC69577
And I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
And I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Cooking Oil Spray - Aerosol
Given I call Shared Step 60756 (Product Information with Country and every option)
And I call Shared Step 60778 (Primary Physical Property - Packaged in gas cylinder)
Given I click continue
Then I should see an error message: ALERT! The ingredient table does not include a compressed gas (Bag-On-Valve) or a propellant. Please update your ingredients to include the propellant before proceeding.
And I call Shared Step 69557 (Enter Ingredients for Aerosol Propellent)
Then I should not see an error message: ALERT! The ingredient table does not include a compressed gas (Bag-On-Valve) or a propellant. Please update your ingredients to include the propellant before proceeding.
And I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
And I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
And I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
And I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)
And I call Shared Step 57923 (Volatile Organic Compound (VOC) Step - enter OTC and CARB - Yes for state values)
| Product granted Alternative Control Plan | Amount of VOC by CARB | Amount of VOC by OTC Model | VOC for states |
| No                                       | 2                     | 2                          | Yes            |
And I click continue
And I call Shared Step 63219 (Retailer Association - Select No Retailer - Click continue)
And I call Shared Step 60567 (Upload Product Label only) for section: Upload Full Product Label (required)
And I check the checkbox with description: I confirm I am providing the most current Safety Data Sheet (SDS), Article Information Sheet (AIS) and/or Product Label for this registration. I understand I will need to provide a revised document should any changes be made to the registration data or documents in the future.
And I click continue
And I call Shared Step 60567 (Upload Product Label only) for section: Volatile Organic Compounds
And I click continue
And I call Shared Step 57883 (Comments - Happy Path) and enter the comment: Comment Test 69577
And I call Shared Step 73956 (Go to Summary and verify data) with product type: Cooking Oil Spray - Aerosol
And I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase69577
