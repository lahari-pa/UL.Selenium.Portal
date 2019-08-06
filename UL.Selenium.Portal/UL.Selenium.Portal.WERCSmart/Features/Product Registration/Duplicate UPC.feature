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
@PaymentMethods
@SubEnrollment
@WERCSmart_Signup
@MyAccount
@PackagingTypes
@Brands
@MyIngredients
@SHA
@run_DuplicateUPC

Feature: Duplicate UPC


# Assigned to Abbie Zullo
# Created by Abbie Zullo

# Test case can be found at the following paths:
# NetProjects10\WercsSmart Portal\WERCSmart\Product Registration\UPC

Scenario: [91076] Duplicate UPC is not permitted within account - New Product registration - single UPC
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
Then I save the product information as: TestCase91076
And I call Shared Step 26897 (Product Characteristics - Solid only available - continue)
And I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
And I call Shared Step 75146 (Retailer - Select One or More Retailers that DO NOT REQUIRE Vendor ID or Additional UPC Information, Click Done, Click Continue)
And I call Shared Step 65080 (Login to Studio and Open SHA manager)
Given I click the following option in the bottom menu: Search
Given I save the username for TReVor test user: ProductAccount to context as: AccountUsername
Given In SHA Manager ProductSearch page I run search:
| Search Term | Search Value                  |
| Status      | Completed                     |
| Supplier    | QA_Automation_ProductsAccount |
| User        | saved as AccountUsername      |
Given I save a UPC number for any product in the grid to context as: ExistingUPC
Given I navigate to the landing page
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Given I search for the product saved as: TestCase91076
Given I edit the first product in results
Then I should see the Universal Product Code (UPC) Page
Given I click the 'Add UPC' button
Given I add the following into the UPC Fields
| UPC Number           | Container Type    | Size | DPCI | Quantity |
| saved as ExistingUPC | Plastic Container | 1    |      |         |
Given I click 'Select all' under Destination Retailers in the UPC page
Given I click continue
And I should see a list style form error with text: There are UPCs that already exists within the WERCSmart database. Please review the UPCs associated within your account, or request to forward a manufacturer's UPCs by creating a new registration as a request from a Distributor. For UPCs that exist within your WERCSmart account, you may use the Report feature to generate a report for your review. UPCs:
And I navigate to the home page
And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase91076

