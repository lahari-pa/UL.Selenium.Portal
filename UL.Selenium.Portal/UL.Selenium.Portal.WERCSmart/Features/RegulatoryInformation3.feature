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
@run_RegulatoryInformation3
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:InventoryStatusProp65

Feature: Regulatory Information 3

#Removed from regression 2024/03
@ignore
@TestCase:88022
Scenario: [88022] Regulatory Information 3 - navigation
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Deodorant - Non-aerosol
Then I save the product information as: TestCase88022
	Given I call Shared Step 60310 (Product Information - Without Child question)
Given I call Shared Step 74760 (Physical and Chemical Properties - Select Liquid as primary physical state and enter all required data)
| Primary Physical State | Secondary Physical State | Relative Density | pH | Boiling Point (in Celsius) | Flash Point (in Celsius) | Flash Point Testing Method Used | Select the best Water Solubility description |
|  Liquid                | Liquid                   | 2                 | 2   | 2                           | 66                         |  Closed cup method         | Dispersible                                  |
Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Water         | 100     | false               | false       |            |
#Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
Given I should see the Inventory Status, Prop 65 (US) Page
	Then In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	Then In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page I click Continue

And I should see the Regulatory Information 3 Page
And I should see following statement: Refer to your Product Label. From the options, select those that appear on the Label.
And I should see the following checkbox:
| Checkbox         |
| Drug Facts Panel |
| Supplement Facts Panel |
| Nutrition Facts Panel |
| None of the Above |
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase88022

#| Active Ingredient Panel |
#| An Active Ingredient is listed on the Panel |


@TestCase:88644
Scenario: [88644] Regulatory Information 3 - validation
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Deodorant - Non-aerosol
Then I save the product information as: TestCase88644
Given I call Shared Step 60310 (Product Information - Without Child question)
Given I call Shared Step 74760 (Physical and Chemical Properties - Select Liquid as primary physical state and enter all required data)
| Primary Physical State | Secondary Physical State | Relative Density | pH | Boiling Point (in Celsius) | Flash Point (in Celsius) | Flash Point Testing Method Used | Select the best Water Solubility description |
|  Liquid                | Liquid                   | 2                 | 2   | 2                           | 66                         |  Closed cup method         | Dispersible                                  |
Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Water       | 100     | false               | false       |            |
#Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
Given I should see the Inventory Status, Prop 65 (US) Page
	Then In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	Then In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page I click Continue

When I click continue
And Refer to your Product Label. should be showing the error messages: Please select at least one option from above.
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase88644
