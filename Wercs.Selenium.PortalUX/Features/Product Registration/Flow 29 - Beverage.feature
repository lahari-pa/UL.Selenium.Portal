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
@run_FLow29_Beverage

Feature: Flow 29 - Beverage
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers


Scenario: [60694] Wine - RU001418
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

# This just double checks that the account has been set up correctly - chances are this step won't be actioned
Given If I see the retail partners page I set all data consent tiers to true for all retailers in the top section
Then The home screen should load
Then I click the Register New Product icon in the Navigation Pane
And I Select the Create a New Registration radio button
And in the New Product page I click Continue
And In the Product Type tab of the New Product Page, I enter: Wine in the Product Name text field
And In the Product Type tab of the New Product Page, I enter: Wine in the Type of Product select field
And in the New Product page I click Continue
Then I save the product information as: TestCase60694
And I set the Primary Physical State to be: Liquid

# Following the steps from 'Shared Step' 57441
And I set the Secondary Physical State to be: Liquid
And In the Product Characteristics tab, I enter: 2 in the Specific Gravity text field
And In the product Characteristics tab, I enter: 2 in the pH text field
And In the product Characteristics tab, I enter: 2 in the Boiling point (in Celsius) text field
And In the product Characteristics tab, I enter: 2 in the Flash point (in Celsius) text field
And in the Product Characteristics tab, for Flash Point Testing Method Used status I select: Closed cup method
And I set the Select the best Water Solubility description to be: Very soluble
And in the New Product page I click Continue

# Following the steps from 'Shared Step' 69687
And I should see the Additional Product Information Page
And In the Additional Information Page the check box for: United States should be: checked
And In the Additional Information Page for Product has been classified using OSHA I select: No
And In the Additional Information Page for Product is shipped directly I select: No
And In the Additional Information Page for Product is retailers private label or brand I select: Yes
And In the Additional Information Page for Product is solely for the Retailer's use I select: No
And in the New Product page I click Continue

# Following the steps from 'Shared Step' 57571
And in the Product Characteristics tab of the New Product Page, for U.S. Toxic Substances Control Act (TSCA) status I select: Compliant
And in the Product Characteristics tab of the New Product Page for Prop65 I select: No
And in the New Product page I click Continue





