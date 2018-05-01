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


Scenario: [60694] Wine - RU001418
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

# This just double checks that the account has been set up correctly - chances are this step won't be actioned
Given If I see the retail partners page I set all data consent tiers to true for all retailers in the top section
Then The home screen should load
Given I generate a random UPC number and save as: UPC60694
Given I delete all products with UPC Number: saved as UPC60694
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
And in the New Product page I click Continue

# Following the steps from 'Shared Step' 69687
And I should see the Additional Product Information Page
And In the Additional Information Page the check box for: United States should be: checked
And In the Additional Information Page for Product is retailers private label or brand I select: Yes
And in the New Product page I click Continue

# Following the steps from 'Shared Step' 57571
And in the Product Characteristics tab of the New Product Page, for U.S. Toxic Substances Control Act (TSCA) status I select: Compliant
And in the Product Characteristics tab of the New Product Page for Prop65 I select: No
And in the New Product page I click Continue

# Following the steps from 'Shared Step' 49818
And I should see the Beverage Regulatory Details Page
And I set the Product's container or liner contains Bisphenol A (BPA) option to: Yes
And I set the Does your product contain a Prop 65 chemical? option to: Yes
And I set the Percent of Alcohol in the Product (numeric entry only) option to: 20
And in the New Product page I click Continue

# Following the steps from 'Shared Step' 57506
And I should see the Transportation Details 1 Page
And I set the Product is Regulated for Transport option to: No, due to an exemption or exception
And I set the below options for field: Please select DOT Exceptions if applicable?
| Option         |
| 173.120(a)(2): |
| 173.120(a)(3): |
And in the New Product page I click Continue

# The below will currently fail (Ticket 65023)
And In the 'Select retailers' window I should not see the following retailers:
| Retailer             |
| Autozone             |
| Harbor Freight Tools |

# Entering retailer information
Then In the 'Select Retailers' window I select the retailer: Walgreens
And I should see the Retailer Page
And In the Retailers tab, I set the full product name to be: Wine Product Full Name for retailer: Walgreens
And in the New Product page I click Continue

# Entering UPC Information
Given I click the 'Add UPC' button
Then I add the following into the UPC Fields
| Field         | Value             |
| UPCNumber     | saved as UPC60694 |
| ContainerType | Glass Container   |
| Size          | 20                |
And in the New Product page I click Continue

# Additional Documents screen loads
And I should see the Additional Documents to Provide Page
And in the New Product page I click Continue

# 'Optional Reports and Documents Available for Purchase' screen loads
And I should see the Optional Reports and Documents Available for Purchase Page
And in the New Product page I click Continue

# Following the steps from 'Shared Step' 57883
Then the comments field should appear
And I enter the following into the comments field: Comments Field Text
Given in the New Product page I click Continue

# Following the steps from 'Shared Step' 42214
Given I navigate to the home page
Then I delete the product: TestCase60694
