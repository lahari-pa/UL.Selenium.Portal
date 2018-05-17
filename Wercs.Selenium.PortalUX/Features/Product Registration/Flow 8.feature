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
@run_FLow32_Grocery

Feature: Flow 8

Scenario: [57295] Absorbent solid - Automotive(RU000939) - 8-S - Validation

# Logging in as the correct user
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

# Just checks that the correct page loads
Given If I see the retail partners page I set all data consent tiers to true for all retailers in the top section
Then The home screen should load

# New Product Page
And I click the Register New Product icon in the Navigation Pane
And I should see the New Product Page
And I set the Select the type of product to create option to: Create a New Registration
And in the New Product page I click Continue

# The Product Page
And I should see the The Product Page
And I set the Product Name option to: Flow8 - Absorbent Solid
And In the Product Type tab of the New Product Page, I enter: Absorbent Solid in the Type of Product select field
And in the New Product page I click Continue

# Product Characteristics Page
And I should see the Product Characteristics Page
Then I save the product information as: TestCase57295
And I should only see the following options for Primary Physical State:
| State |
| Solid |
And in the New Product page I click Continue
Then Secondary Physical State should be showing the error messages: This is a required field.
Then When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5? should be showing the error messages: This is a required field.
Then Select the best Water Solubility description should be showing the error messages: This is a required field.
And I set the Secondary Physical State option to: Solid
Then Secondary Physical State should not be showing the error messages: This is a required field.
And I set the When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5? option to: No
Then When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5? should not be showing the error messages: This is a required field.
And I set the Select the best Water Solubility description option to: Very soluble
Then Select the best Water Solubility description should not be showing the error messages: This is a required field.
And in the New Product page I click Continue

# Additional Product Information page
And I should see the Additional Product Information Page
And In the Additional Information Page the check box for: United States should be: checked
And in the New Product page I click Continue
Then Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) should be showing the error messages: This is a required field.
Then Product is shipped directly by supplier to the consumer. should be showing the error messages: This is a required field.
And I set the Product has been classified using OSHA (US) option to: No
Then Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) should not be showing the error messages: This is a required field.
And I set the Product is shipped directly by supplier to the consumer option to: No
Then Product is shipped directly by supplier to the consumer. should not be showing the error messages: This is a required field.
#And in the New Product page I click Continue
#Then Product is a Retailer's Private Label or Brand should be showing the error messages: This is a required field.
#Then Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer should be showing the error messages: This is a required field.
And I set the Product is a Retailer's Private Label or Brand option to: No
#Then Product is a Retailer's Private Label or Brand should not be showing the error messages: This is a required field.
And I set the Product is sold to the Retailer solely for the Retailer's use option to: No
#Then Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer should not be showing the error messages: This is a required field.
And in the New Product page I click Continue

# Ingredient Page
And I should see the Ingredients Page
Then I add the following ingredients:
| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Butane  | 100     | false               | false       |            |
Given in the New Product page I click Continue

# Regulatory 1 Page Details
And I should see the Regulatory Information 1 Page
#Given in the New Product page I click Continue
#Then U.S. Toxic Substances Control Act (TSCA) status should be showing the error messages: This is a required field.
#Then Product, including container and/or packaging, contains a chemical on California's Prop 65 list should be showing the error messages: This is a required field.
And I set the U.S. Toxic Substances Control Act (TSCA) status option to: Compliant
#Then U.S. Toxic Substances Control Act (TSCA) status should not be showing the error messages: This is a required field.
And I set the Product, including container and/or packaging, contains a chemical on California's Prop 65 list option to: Yes
#Then Product, including container and/or packaging, contains a chemical on California's Prop 65 list should not be showing the error messages: This is a required field.
#Given in the New Product page I click Continue
#Then Prop 65 warning is required should be showing the error messages: This is a required field.
And I set the Prop 65 warning is required option to: Yes
#Then Prop 65 warning is required should not be showing the error messages: This is a required field.
#Given in the New Product page I click Continue
#Then Prop 65 warning is present on the product's label should be showing the error messages: This is a required field.
And I set the Prop 65 warning is present on the product's label option to: No
#Then Prop 65 warning is present on the product's label should not be showing the error messages: This is a required field.
Given in the New Product page I click Continue

# Transportation Details 1 Page
And I should see the Transportation Details 1 Page
Given in the New Product page I click Continue
Then Product is Regulated for Transport should be showing the error messages: This is a required field.
And I set the Product is Regulated for Transport option to: Yes
And I set the below options for field: Select all modes of transport that you've classified the product for
| Option           |
| DOT                              |
| Shipping with limited quantity   |
| Shipping with consumer commodity |
#And I set the below options for field: Select all modes of transport that you've classified the product for
#| Option           |
#| IMDG             |
#| Shipping with limited quantity   |
Given in the New Product page I click Continue

# DOT page
And I should see the U. S. Department of Transportation (DOT) Classification Page
Given in the New Product page I click Continue
Then UN Number should be showing the error messages: This is a required field.
And I set the UN Number option to: UN1950
Then UN Number should not be showing the error messages: This is a required field.
And I set the Proper Shipping Name option to: Aerosols
And I set the Technical Name (if applicable) option to: Testcase57295
And I set the Hazard Class (select) option to: 2.1
And I set the Packing Group (select) option to: None
Given in the New Product page I click Continue

# Retailers Page
Given the 'Select Retailers' window appears
Then In the 'Select Retailers' window I select the retailer: No Retailer/No UPC Product
And in the New Product page I click Continue

# Regulatory Documents to Provide Page
And I should see the Regulatory Documents to Provide Page
And in the Review and Submit tab of the New Product Page for OSHA compliant SDS I select: Request to author
And in the New Product page I click Continue

# Additional Documents to Provide Page
And I should see the Additional Documents to Provide Page
And in the New Product page I click Continue

# Optional Reports and Documents Available for Purchase Page
And I should see the Optional Reports and Documents Available for Purchase Page
And in the New Product page I click Continue

# Safety Data Sheet Authoring - Additional Data (Optional) Page
And I should see the Safety Data Sheet Authoring - Additional Data (Optional) Page
And I set the Appearance field to: Brown
And I set the Odor field to: Banana
And I set the Odor Threshold field to: Not applicable
And I set the Partition Coefficient field to: 5
And in the New Product page I click Continue

# Comments Page
And I should see the Comments Page
And in the New Product page I click Continue

# Data Acceptance and Summary
And I should see the Data Acceptance Page
Then The Data Acceptance page should appear
Given I click the Summary button in the Data Acceptance window
Then I switch to the Data Summary page
And Type of Product should be showing the following option: Absorbent Solid
Then I switch to Data Acceptance page
Given I navigate to the home page
Then I delete the product: TestCase57295
