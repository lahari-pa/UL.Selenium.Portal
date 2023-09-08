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
@run_Flow16
@UPC

Feature: Flow21P-Bulb

A short summary of the feature

@TestCase:209162
Scenario: [209162] WERCSmart Portal Test Flow for Type of Product:  Light Bulb - Germicidal Ultra Violet Bulb (RU000962)
Given I log in with the account saved in TReVor as: ProductAccount
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Light Bulbs - Germicidal Ultra Violet Bulb
Then I save the product information as: TestCase209162
Then I call Shared Step 69687 (Product Information - US, No(PL))
Then I call Shared Step 57571b (Enter Regulatory Information - Not Prop 65):
| TSCA																		 | Prop 65 |
| This product is EXEMPT from TSCA chemical Inventory listing requirements.  | No      |
Then I call Shared Step 71955 (Answer Electronic Equipment questions - Without Cathode Ray - No to all)
