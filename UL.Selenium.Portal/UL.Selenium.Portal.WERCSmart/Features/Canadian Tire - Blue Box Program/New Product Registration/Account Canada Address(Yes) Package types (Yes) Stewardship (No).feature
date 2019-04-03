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
@SHA
@UPC
@run_AccountCanadaAddress(Yes)Packagetypes(Yes)Stewardship(No)


Feature: Account Canada Address(Yes) Package types (Yes) Stewardship (No) (Suite ID 85309)

Scenario: [85325] Account has all Canada data ALL stewardship SOLD = Canada Only PL = YES Packaging type IS required
Given I login into the WERCSmart Portal - Canada has all data account
And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bubble solution
Then I save the product information as: TestCase85325
And I call Shared Step 57514 (Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path)
And I call Shared Step 85730 - Additional Product Information - Canada Only - Child (NO), GHS (NO), DSV (NO), PLP(YES), GNFR (NO), Continue
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium Hydroxide
And I call Shared Step 57911 (Regulatory Information 1 - CEPA only shown - Continue - Happy Path)
And In the 'Select Retailers' window I select the retailer: Canadian Tire
And For retailer: Canadian Tire I add additional requirements: Additional requirements: Canadian Tire
And I click continue
#And I should see the Universal Product Code (UPC) Page
And In the UPC page I should see Add new Packaging Type link
Given I generate a random UPC number and save as: UPC85325
And I click the 'Add UPC' button
And I enter UPC Number: saved as UPC85325
And I Select a container type from the drop down list
And I enter Size Value: 12
And I Confirm the Package Type drop down list shows a Packaging type available for selection - Do not select one
And I click continue
And I Confirm This is a required field. error message is shown below the Package Type field
And I Select a package type from the drop down list
#And I click continue
Given in the Universal Product Code (UPC) page I click Continue
Given in the Regulatory Documents to Provide page I click Continue
And I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase85325
