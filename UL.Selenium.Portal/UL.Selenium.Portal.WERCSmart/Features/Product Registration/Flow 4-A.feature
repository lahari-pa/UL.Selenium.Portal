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
@run_Flow4A


Feature: Flow 4-A

Scenario: [74825] Flow 4-A - Air Freshener-Dual Purpose/Disinfectant-Aerosol - RU001539
Given I generate a random UPC number and save as: UPC74825
And I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
# And I Enter "Air Freshener-Dual Purpose/Disinfectant-Aerosol" in Type of Product smart search field
And I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Air Freshener-Dual Purpose/Disinfectant-Aerosol
And I call Shared Step 57528 (Product Characteristics - Aerosol Only - add data - Continue - Happy Path)
And I call Shared Step 57401 (Additional Product Information - US only - No GHS, Not Direct Ship, Not PLP, Not GNFR > Continue - Happy Path)
And I click continue
Then I should see an error message: ALERT! The ingredient table does not include a compressed gas (Bag-On-Valve) or a propellant. Please update your ingredients to include the propellant before proceeding.
And I call Shared Step 69557 (Enter Ingredients for Aerosol Propellent)
Then I should not see an error message: ALERT! The ingredient table does not include a compressed gas (Bag-On-Valve) or a propellant. Please update your ingredients to include the propellant before proceeding.
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
And I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
And I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)
And I call Shared Step 57923 (Volatile Organic Compound (VOC) Step - enter OTC and CARB - Yes for state values)
| Product granted Alternative Control Plan | Amount of VOC by CARB | Amount of VOC by OTC Model | VOC for states |
| No                                       | 2                     | 2                          | Yes            |
And I should see the Volatile Organic Compound Summary Page
And I click continue
And I call Shared Step 63219 (Retailer Association - Select No Retailer - Click continue)
And I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
And I call Shared Step 60567 (Upload Product Label only) for section: Volatile Organic Compounds
And I click continue
And I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
| Gloves                        | 340                      | 12                      | 20.5      | Clear      | Odorless | No data available | 5.0                   |
And I call Shared Step 57883 (Comments - Happy Path) and enter the comment: Test Comment
Then In the Data Acceptance page I select Yes, Agreed
Then I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase74825
