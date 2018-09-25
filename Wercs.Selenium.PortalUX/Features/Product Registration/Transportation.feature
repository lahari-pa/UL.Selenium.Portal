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
@run_Transportation

Feature: Transportation

# Assigned to Beverly Barrett
# Created by Beverly Barrett
Scenario: [65702] Transportation - Confirm Copy information from my U.S. Department of Transportation data check box shows for IATA and is NOT a required field
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bleach
And I call Shared Step 74760 (Product Characteristics - Select Liquid as primary physical state and enter all required data)
| Primary Physical State | Secondary Physical State | Specific Gravity | pH | Boiling Point (in Celsius) | Flash Point (in Celsius) | Flash Point Testing Method Used | Select the best Water Solubility description |
| Liquid                 | Liquid                   | 2                | 2  | 2                          | 66                       | Closed cup method               | Appreciable                                  |
And I call Shared Step 74340 (Additional Product Information - Pesticide= Not considered, SOLD=US, everything else = No - Continue)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Chlorine
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
And I should see the Transportation Details 1 Page
And I set the Product is Regulated for Transport field to: Yes
And I call Shared Step 65698 (Transport - Select DOT & Limited Shipping - No Continue)
And I call Shared Step 65700 (Transportation Details 1 - Select IATA & Limited Shipping)
And I click continue
And I call Shared Step 65705 (Transportation - DOT UN step - Enter UN1950, select Aerosols,  2.1, None, add technical name, Click Continue)
And I should see the International Air Transport (IATA) Classification Page
And I confirm the checkbox with description: Copy information from my U.S. Department of Transportation data is displayed
And I click continue
And Copy information from my U.S. Department of Transportation data should not be showing any error messages
And Technical Name (if applicable) should not be showing any error messages
And UN Number should be showing the error messages: This is a required field.
And Proper Shipping Name should be showing the error messages: This is a required field.
And Hazard Class (select) should be showing the error messages: This is a required field.
And Packing Group (select) should be showing the error messages: This is a required field.
And I navigate to the home page
And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase65702

# Assigned to Beverly Barrett
# Created by Beverly Barrett
Scenario: [65703] Transportation - Transportation - Confirm Copy information from my U.S. Department of Transportation data check box shows for IMDG and is NOT a required field
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bleach
And I call Shared Step 57514 (Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path)
And I call Shared Step 74340 (Additional Product Information - Pesticide= Not considered, SOLD=US, everything else = No - Continue)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Chlorine
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
And I should see the Transportation Details 1 Page
And I set the Product is Regulated for Transport field to: Yes
And I call Shared Step 65698 (Transport - Select DOT & Limited Shipping - No Continue)
And I call Shared Step 65699 (Transport - Select IMDG & Limited Shipping - No Continue)
And I click continue
And I call Shared Step 65705 (Transportation - DOT UN step - Enter UN1950, select Aerosols,  2.1, None, add technical name, Click Continue)
And I should see the International Marine (IMDG) Classification Page
And I confirm the checkbox with description: Copy information from my U.S. Department of Transportation data is displayed
And I click continue
And Copy information from my U.S. Department of Transportation data should not be showing any error messages
And Technical Name (if applicable) should not be showing any error messages
And UN Number should be showing the error messages: This is a required field.
And Proper Shipping Name should be showing the error messages: This is a required field.
And Hazard Class (select) should be showing the error messages: This is a required field.
And Packing Group (select) should be showing the error messages: This is a required field.
And I navigate to the home page
And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase65703

# Assigned to Beverly Barrett
# Created by Beverly Barrett
Scenario: [65706] Transportation - Confirm Copy information from my U.S. Department of Transportation data check box shows for TDG and is NOT a required field
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bleach
And I call Shared Step 57514 (Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path)
And I call Shared Step 74340 (Additional Product Information - Pesticide= Not considered, SOLD=US, everything else = No - Continue)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Chlorine
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
And I should see the Transportation Details 1 Page
And I set the Product is Regulated for Transport field to: Yes
And I call Shared Step 65698 (Transport - Select DOT & Limited Shipping - No Continue)
And I call Shared Step 65701 (Transport - Select TDG & Limited Shipping - No Continue)
And I click continue
And I call Shared Step 65705 (Transportation - DOT UN step - Enter UN1950, select Aerosols,  2.1, None, add technical name, Click Continue)
And I should see the Canada - Transportation of Dangerous Goods (TDG) Classification Page
And I confirm the checkbox with description: Copy information from my U.S. Department of Transportation data is displayed
And I click continue
And Copy information from my U.S. Department of Transportation data should not be showing any error messages
And Technical Name (if applicable) should not be showing any error messages
And UN Number should be showing the error messages: This is a required field.
And Proper Shipping Name should be showing the error messages: This is a required field.
And Hazard Class (select) should be showing the error messages: This is a required field.
And Packing Group (select) should be showing the error messages: This is a required field.
And I navigate to the home page
And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase65706
