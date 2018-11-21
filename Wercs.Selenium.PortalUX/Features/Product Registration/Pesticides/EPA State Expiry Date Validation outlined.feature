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
@run_EPAStateOutlined

Feature: EPA State Expiry Date Validation outlined

Scenario Outline: Pesticide Data - EPA Expiration date validation (STATE - Dec 31st for current calendar year until Oct 1st,  then Dec 31st for this or next year)
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Pet Shampoo with Pest Control
And I call Shared Step 57514 (Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path)
And I call Shared Step 57865 (Additional Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
And I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
And I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: Yes
And I add the EPA registration number: TEST-1234
And I click continue
And I call Shared Step 55819 (EPA expiration date - enter current year - NOT Dec 31st) for state: <state>
Then in page Pesticide Details - State Registration Details I should see error: State <state>: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
And I call Shared Step 55820 (EPA expiration date - enter next year - NOT Dec 31st) for state: <state>
Then in page Pesticide Details - State Registration Details I should see error: State <state>: Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.
And I call Shared Step 55821 (EPA expiration date - enter Dec 31st of Next year) for state: <state>
Then I should see the appropriate response depending on today's date for state: <state>
And I call Shared Step 55822 (EPA expiration date - enter Dec 31st of Current year) for state: <state>
And I should see the Transportation Details 1 Page
And I navigate to the home page
And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase<scenario>


Examples:
| state | scenario |
|       |          |
