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
@run_Flow8

Feature: Flow 8

Scenario: [57295] Absorbent solid - Automotive(RU000939) - 8-S

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
And I set the Secondary Physical State option to: Solid
And I set the When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5? option to: No
And I set the Select the best Water Solubility description option to: Very soluble
And in the New Product page I click Continue

# Additional Product Information page
And I should see the Additional Product Information Page
And In the Additional Information Page the check box for: United States should be: checked
And I set the Product has been classified using OSHA (US) option to: No
And I set the Product is shipped directly by supplier to the consumer option to: No
And I set the Product is a Retailer's Private Label or Brand option to: No
And I set the Product is sold to the Retailer solely for the Retailer's use option to: No
And in the New Product page I click Continue

# Ingredient Page
And I should see the Ingredients Page
Then I add the following ingredients:
| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Butane  | 100     | false               | false       |            |
Given in the New Product page I click Continue

# Regulatory 1 Page Details
And I should see the Regulatory Information 1 Page
And I set the U.S. Toxic Substances Control Act (TSCA) status option to: Compliant
And I set the Product, including container and/or packaging, contains a chemical on California's Prop 65 list option to: Yes
And I set the Prop 65 warning is required option to: Yes
And I set the Prop 65 warning is present on the product's label option to: No
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
Given in the New Product page I click Continue

# DOT page
And I should see the U. S. Department of Transportation (DOT) Classification Page
And I set the UN Number option to: UN1950
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

Scenario: [57332] Automotive Accessories containing Gel (Seat Cushions, etc) - 8-S

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
And I set the Product Name option to: Flow8 - Automotive Accessories containing Gel (Seat Cushions, etc.)
And In the Product Type tab of the New Product Page, I enter: Automotive Accessories containing Gel (Seat Cushions, etc.) in the Type of Product select field
And in the New Product page I click Continue

# Product Characteristics Page
And I should see the Product Characteristics Page
Then I save the product information as: TestCase57332
And I should only see the following options for Primary Physical State:
| State |
| Solid |
And I set the Secondary Physical State option to: Solid
And I set the When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5? option to: No
And I set the Select the best Water Solubility description option to: Soluble in water
And in the New Product page I click Continue

# Additional Product Information page
And I should see the Additional Product Information Page
And In the Additional Information Page the check box for: United States should be: checked
And I set the Product has been classified using OSHA (US) option to: No
And I set the Product is shipped directly by supplier to the consumer option to: No
And I set the Product is a Retailer's Private Label or Brand option to: No
And I set the Product is sold to the Retailer solely for the Retailer's use option to: No
And in the New Product page I click Continue

# Ingredient Page
And I should see the Ingredients Page
Then I add the following ingredients:
| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Butane  | 100     | false               | false       |            |
Given in the New Product page I click Continue

# Regulatory 1 Page Details
And I should see the Regulatory Information 1 Page
And I set the U.S. Toxic Substances Control Act (TSCA) status option to: Compliant
And I set the Product, including container and/or packaging, contains a chemical on California's Prop 65 list option to: Yes
And I set the Prop 65 warning is required option to: Yes
And I set the Prop 65 warning is present on the product's label option to: Yes
Given in the New Product page I click Continue

# Transportation Details 1 Page
And I should see the Transportation Details 1 Page
Given in the New Product page I click Continue
Then Product is Regulated for Transport should be showing the error messages: This is a required field.
And I set the Product is Regulated for Transport option to: Yes
And I set the below options for field: Select all modes of transport that you've classified the product for
| Option                          |
| IMDG                            |
| Shipping with limited quantity  |

Given in the New Product page I click Continue

# IMDG page
And I should see the International Marine (IMDG) Classification Page
And I set the UN Number option to: UN1950
And I set the Proper Shipping Name option to: Aerosols
And I set the Technical Name (if applicable) option to: Testcase57295
And I set the Hazard Class (select) option to: 2
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
And Type of Product should be showing the following option: Automotive Accessories containing Gel (Seat Cushions, etc.)
Then I switch to Data Acceptance page
Given I navigate to the home page
Then I delete the product: TestCase57332

Scenario: [58184] Craft kits containing clays or plasters(RU000299) - 8-S

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
And I set the Product Name option to: Flow8 - Craft kits containing clays or plasters
And In the Product Type tab of the New Product Page, I enter: Craft kits containing clays or plasters in the Type of Product select field
And in the New Product page I click Continue

# Product Characteristics Page
And I should see the Product Characteristics Page
Then I save the product information as: TestCase58184
And I should only see the following options for Primary Physical State:
| State |
| Solid |
And I set the Secondary Physical State option to: Solid
And I set the When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5? option to: No
And I set the Select the best Water Solubility description option to: Soluble in water
And in the New Product page I click Continue

# Additional Product Information page
And I should see the Additional Product Information Page
And In the Additional Information Page the check box for: United States should be: checked
And I set the Product is marketed for use by, or on, a child option to: No
And I set the Product has been classified using OSHA (US) option to: No
And I set the Product is shipped directly by supplier to the consumer option to: No
And I set the Product is a Retailer's Private Label or Brand option to: No
And I set the Product is sold to the Retailer solely for the Retailer's use option to: No
And in the New Product page I click Continue

# Ingredient Page
And I should see the Ingredients Page
Then I add the following ingredients:
| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Butane  | 100     | false               | false       |            |
Given in the New Product page I click Continue

# Regulatory 1 Page Details
And I should see the Regulatory Information 1 Page
And I set the U.S. Toxic Substances Control Act (TSCA) status option to: Compliant
And I set the Product, including container and/or packaging, contains a chemical on California's Prop 65 list option to: Yes
And I set the Prop 65 warning is required option to: Yes
And I set the Prop 65 warning is present on the product's label option to: Yes
Given in the New Product page I click Continue

# Transportation Details 1 Page
And I should see the Transportation Details 1 Page
Given in the New Product page I click Continue
Then Product is Regulated for Transport should be showing the error messages: This is a required field.
And I set the Product is Regulated for Transport option to: Yes
And I set the below options for field: Select all modes of transport that you've classified the product for
| Option                          |
| IMDG                            |
| Shipping with limited quantity  |

Given in the New Product page I click Continue

# IMDG page
And I should see the International Marine (IMDG) Classification Page
And I set the UN Number option to: UN1950
And I set the Proper Shipping Name option to: Aerosols
And I set the Technical Name (if applicable) option to: Testcase58184
And I set the Hazard Class (select) option to: 2
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
And Type of Product should be showing the following option: Craft kits containing clays or plasters
Then I switch to Data Acceptance page
Given I navigate to the home page
Then I delete the product: TestCase58184

Scenario: [58187] Matches (RU000317) - 8-S

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
And I set the Product Name option to: Flow8 - Matches
And In the Product Type tab of the New Product Page, I enter: Matches in the Type of Product select field
And in the New Product page I click Continue

# Product Characteristics Page
And I should see the Product Characteristics Page
Then I save the product information as: TestCase58187
And I should only see the following options for Primary Physical State:
| State |
| Solid |
And I set the Secondary Physical State option to: Solid
And I set the When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5? option to: No
And I set the Select the best Water Solubility description option to: Soluble in water
And in the New Product page I click Continue

# Additional Product Information page
And I should see the Additional Product Information Page
And In the Additional Information Page the check box for: United States should be: checked
And I set the Product has been classified using OSHA (US) option to: No
And I set the Product is shipped directly by supplier to the consumer option to: No
And I set the Product is a Retailer's Private Label or Brand option to: No
And I set the Product is sold to the Retailer solely for the Retailer's use option to: No
And in the New Product page I click Continue

# Ingredient Page
And I should see the Ingredients Page
Then I add the following ingredients:
| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Butane  | 100     | false               | false       |            |
Given in the New Product page I click Continue

# Regulatory 1 Page Details
And I should see the Regulatory Information 1 Page
And I set the U.S. Toxic Substances Control Act (TSCA) status option to: Compliant
And I set the Product, including container and/or packaging, contains a chemical on California's Prop 65 list option to: Yes
And I set the Prop 65 warning is required option to: Yes
And I set the Prop 65 warning is present on the product's label option to: Yes
Given in the New Product page I click Continue

# Transportation Details 1 Page
And I should see the Transportation Details 1 Page
And I set the Product is Regulated for Transport option to: Yes
And I set the below options for field: Select all modes of transport that you've classified the product for
| Option                            |
| IATA                              |
| Shipping with limited quantity    |
| Shipping with consumer commodity  |

Given in the New Product page I click Continue

# IATA page
And I should see the International Air Transport (IATA) Classification Page
And I set the UN Number option to: UN1950
And I set the Proper Shipping Name option to: Aerosols, non-flammable
And I set the Technical Name (if applicable) option to: Testcase58187
And I set the Hazard Class (select) option to: 2.2
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
And Type of Product should be showing the following option: Matches
Then I switch to Data Acceptance page
Given I navigate to the home page
Then I delete the product: TestCase58187

Scenario: [58293] Engines for Model Rockets(RU000338) - 8-S

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
And I set the Product Name option to: Flow8 - Engines for Model Rockets
And In the Product Type tab of the New Product Page, I enter: Engines for Model Rockets in the Type of Product select field
And in the New Product page I click Continue

# Product Characteristics Page
And I should see the Product Characteristics Page
Then I save the product information as: TestCase58293
And I should only see the following options for Primary Physical State:
| State |
| Solid |
And I set the Secondary Physical State option to: Solid
And I set the When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5? option to: No
And I set the Select the best Water Solubility description option to: Soluble in water
And in the New Product page I click Continue

# Additional Product Information page
And I should see the Additional Product Information Page
And In the Additional Information Page the check box for: United States should be: checked
And I set the Product is marketed for use by, or on, a child option to: No
And I set the Product has been classified using OSHA (US) option to: No
And I set the Product is shipped directly by supplier to the consumer option to: No
And I set the Product is a Retailer's Private Label or Brand option to: No
And I set the Product is sold to the Retailer solely for the Retailer's use option to: No
And in the New Product page I click Continue

# Ingredient Page
And I should see the Ingredients Page
Then I add the following ingredients:
| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Butane  | 100     | false               | false       |            |
Given in the New Product page I click Continue

# Regulatory 1 Page Details
And I should see the Regulatory Information 1 Page
And I set the U.S. Toxic Substances Control Act (TSCA) status option to: Compliant
And I set the Product, including container and/or packaging, contains a chemical on California's Prop 65 list option to: Yes
And I set the Prop 65 warning is required option to: Yes
And I set the Prop 65 warning is present on the product's label option to: Yes
Given in the New Product page I click Continue

# Transportation Details 1 Page
And I should see the Transportation Details 1 Page
Given in the New Product page I click Continue
Then Product is Regulated for Transport should be showing the error messages: This is a required field.
And I set the Product is Regulated for Transport option to: Yes
And I set the below options for field: Select all modes of transport that you've classified the product for
| Option                          |
| IMDG                            |
| Shipping with limited quantity  |

Given in the New Product page I click Continue

# IMDG page
And I should see the International Marine (IMDG) Classification Page
And I set the UN Number option to: UN1950
And I set the Proper Shipping Name option to: Aerosols
And I set the Technical Name (if applicable) option to: Testcase58293
And I set the Hazard Class (select) option to: 2
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
And Type of Product should be showing the following option: Engines for Model Rockets
Then I switch to Data Acceptance page
Given I navigate to the home page
Then I delete the product: TestCase58293

Scenario: [58297] Fireworks (RU000330) - 8-S

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
And I set the Product Name option to: Flow8 - Fireworks
And In the Product Type tab of the New Product Page, I enter: Fireworks in the Type of Product select field
And in the New Product page I click Continue

# Product Characteristics Page
And I should see the Product Characteristics Page
Then I save the product information as: TestCase58297
And I should only see the following options for Primary Physical State:
| State |
| Solid |
And I set the Secondary Physical State option to: Solid
And I set the When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5? option to: No
And I set the Select the best Water Solubility description option to: Soluble in water
And in the New Product page I click Continue

# Additional Product Information page
And I should see the Additional Product Information Page
And In the Additional Information Page the check box for: United States should be: checked
And I set the Product has been classified using OSHA (US) option to: No
And I set the Product is shipped directly by supplier to the consumer option to: No
And I set the Product is a Retailer's Private Label or Brand option to: No
And I set the Product is sold to the Retailer solely for the Retailer's use option to: No
And in the New Product page I click Continue

# Ingredient Page
And I should see the Ingredients Page
Then I add the following ingredients:
| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Butane  | 100     | false               | false       |            |
Given in the New Product page I click Continue

# Regulatory 1 Page Details
And I should see the Regulatory Information 1 Page
And I set the U.S. Toxic Substances Control Act (TSCA) status option to: Compliant
And I set the Product, including container and/or packaging, contains a chemical on California's Prop 65 list option to: Yes
And I set the Prop 65 warning is required option to: Yes
And I set the Prop 65 warning is present on the product's label option to: Yes
Given in the New Product page I click Continue

# Transportation Details 1 Page
And I should see the Transportation Details 1 Page
And I set the Product is Regulated for Transport option to: Yes
And I set the below options for field: Select all modes of transport that you've classified the product for
| Option                            |
| IATA                              |
| Shipping with limited quantity    |
| Shipping with consumer commodity  |

Given in the New Product page I click Continue

# IATA page
And I should see the International Air Transport (IATA) Classification Page
And I set the UN Number option to: UN1950
And I set the Proper Shipping Name option to: Aerosols, non-flammable
And I set the Technical Name (if applicable) option to: Testcase58297
And I set the Hazard Class (select) option to: 2.2
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
And Type of Product should be showing the following option: Fireworks
Then I switch to Data Acceptance page
Given I navigate to the home page
Then I delete the product: TestCase58297

Scenario: [57088] Engine (motor) oil for Auto or Boat
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

# Checking that the test will run correctly by handling extra screens
Given If I see the retail partners page I set all data consent tiers to true for all retailers in the top section
Then The home screen should load

# New Product Page
And I click the Register New Product icon in the Navigation Pane
And I should see the New Product Page
And I set the Select the type of product to create option to: Create a New Registration
And in the New Product page I click Continue

# The Product Page
And I should see the The Product Page
And I set the Product Name option to: Flow8 - Engine (motor) oil for Auto or Boat
And In the Product Type tab of the New Product Page, I enter: Engine (motor) oil for Auto or Boat in the Type of Product select field
And in the New Product page I click Continue

# Product Characteristics Page
And I should see the Product Characteristics Page
Then I save the product information as: TestCase57088
And I should only see the following options for Primary Physical State:
| State |
| Liquid |

And I set the Secondary Physical State option to: Liquid
And I set the Specific Gravity option to: 2
And I set the pH option to: 2
And I set the Boiling Point (in Celsius) option to: 2
And I set the Flash Point (in Celsius) option to: 61
And I set the Flash Point Testing Method Used option to: Closed cup method
And I set the Select the best Water Solubility description option to: Very soluble
And in the New Product page I click Continue

# Additional Product Information page
And I should see the Additional Product Information Page
And In the Additional Information Page the check box for: United States should be: checked
And I set the Product has been classified using OSHA (US) option to: No
And I set the Product is shipped directly by supplier to the consumer option to: No
And I set the Product is a Retailer's Private Label or Brand option to: No
And I set the Product is sold to the Retailer solely for the Retailer's use option to: No
And in the New Product page I click Continue

# Ingredient Page
And I should see the Ingredients Page
Then I add the following ingredients:
| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Butane  | 100     | false               | false       |            |
Given in the New Product page I click Continue

# Regulatory 1 Page Details
And I should see the Regulatory Information 1 Page
And I set the U.S. Toxic Substances Control Act (TSCA) status option to: Compliant
And I set the Product, including container and/or packaging, contains a chemical on California's Prop 65 list option to: No
Given in the New Product page I click Continue

# Transportation Details 1 Page
And I should see the Transportation Details 1 Page
And I set the Product is Regulated for Transport option to: Yes
And I set the below options for field: Select all modes of transport that you've classified the product for
| Option                            |
| IATA                              |
| Shipping with limited quantity    |
| Shipping with consumer commodity  |

Given in the New Product page I click Continue

# IATA page
And I should see the International Air Transport (IATA) Classification Page
And I set the UN Number option to: UN1950
And I set the Proper Shipping Name option to: Aerosols, non-flammable
And I set the Technical Name (if applicable) option to: Testcase57088
And I set the Hazard Class (select) option to: 2.2
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
And Type of Product should be showing the following option: Engine (motor) oil for Auto or Boat
Then I switch to Data Acceptance page
Given I navigate to the home page
Then I delete the product: TestCase57088

Scenario: [58104] Fabric Dye - Liquid or Solid - 8-L
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

# Checking that the test will run correctly by handling extra screens
Given If I see the retail partners page I set all data consent tiers to true for all retailers in the top section
Then The home screen should load

# New Product Page
And I click the Register New Product icon in the Navigation Pane
And I should see the New Product Page
And I set the Select the type of product to create option to: Create a New Registration
And in the New Product page I click Continue

# The Product Page
And I should see the The Product Page
And I set the Product Name option to: Flow8 - Fabric Dye - Liquid or Solid
And In the Product Type tab of the New Product Page, I enter: Fabric Dye - Liquid or Solid in the Type of Product select field
And in the New Product page I click Continue

# Product Characteristics Page
And I should see the Product Characteristics Page
Then I save the product information as: TestCase58104
And I should only see the following options for Primary Physical State:
| State |
| Liquid  |
| Solid   |

And I set the Primary Physical State option to: Liquid
And I set the Secondary Physical State option to: Liquid
And I set the Specific Gravity option to: 2
And I set the pH option to: 2
And I set the Boiling Point (in Celsius) option to: 2
And I set the Flash Point (in Celsius) option to: 61
And I set the Flash Point Testing Method Used option to: Closed cup method
And I set the Select the best Water Solubility description option to: Very soluble
And in the New Product page I click Continue

# Additional Product Information page
And I should see the Additional Product Information Page
And In the Additional Information Page the check box for: United States should be: checked
And I set the Product is marketed for use by, or on, a child option to: No
And I set the Product has been classified using OSHA (US) option to: No
And I set the Product is shipped directly by supplier to the consumer option to: No
And I set the Product is a Retailer's Private Label or Brand option to: No
And I set the Product is sold to the Retailer solely for the Retailer's use option to: No
And in the New Product page I click Continue

# Ingredient Page
And I should see the Ingredients Page
Then I add the following ingredients:
| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Butane  | 100     | false               | false       |            |
Given in the New Product page I click Continue

# Regulatory 1 Page Details
And I should see the Regulatory Information 1 Page
And I set the U.S. Toxic Substances Control Act (TSCA) status option to: Compliant
And I set the Product, including container and/or packaging, contains a chemical on California's Prop 65 list option to: No
Given in the New Product page I click Continue

# Transportation Details 1 Page
And I should see the Transportation Details 1 Page
And I set the Product is Regulated for Transport option to: Yes
And I set the below options for field: Select all modes of transport that you've classified the product for
| Option                            |
| IATA                              |
| Shipping with limited quantity    |
| Shipping with consumer commodity  |

Given in the New Product page I click Continue

# IATA page
And I should see the International Air Transport (IATA) Classification Page
And I set the UN Number option to: UN1950
And I set the Proper Shipping Name option to: Aerosols, non-flammable
And I set the Technical Name (if applicable) option to: Testcase58104
And I set the Hazard Class (select) option to: 2.2
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
And Type of Product should be showing the following option: Fabric Dye - Liquid or Solid
Then I switch to Data Acceptance page
Given I navigate to the home page
Then I delete the product: TestCase58104

Scenario: [57344] Artists Solvent-Thinner - 8-L
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

# Checking that the test will run correctly by handling extra screens
Given If I see the retail partners page I set all data consent tiers to true for all retailers in the top section
Then The home screen should load

# New Product Page
And I click the Register New Product icon in the Navigation Pane
And I should see the New Product Page
And I set the Select the type of product to create option to: Create a New Registration
And in the New Product page I click Continue

# The Product Page
And I should see the The Product Page
And I set the Product Name option to: Flow8 - Artists Solvent-Thinner
And In the Product Type tab of the New Product Page, I enter: Artist's Solvent/Thinner in the Type of Product select field
And in the New Product page I click Continue

# Product Characteristics Page
And I should see the Product Characteristics Page
Then I save the product information as: TestCase57344
And I should only see the following options for Primary Physical State:
| State |
| Liquid  |

And I set the Primary Physical State option to: Liquid
And I set the Secondary Physical State option to: Liquid
And I set the Specific Gravity option to: 2
And I set the pH option to: 2
And I set the Boiling Point (in Celsius) option to: 2
And I set the Flash Point (in Celsius) option to: 61
And I set the Flash Point Testing Method Used option to: Closed cup method
And I set the Select the best Water Solubility description option to: Very soluble
And in the New Product page I click Continue

# Additional Product Information page
And I should see the Additional Product Information Page
And In the Additional Information Page the check box for: United States should be: checked
And I set the Product has been classified using OSHA (US) option to: No
And I set the Product is shipped directly by supplier to the consumer option to: No
And I set the Product is a Retailer's Private Label or Brand option to: No
And I set the Product is sold to the Retailer solely for the Retailer's use option to: No
And in the New Product page I click Continue

# Ingredient Page
And I should see the Ingredients Page
Then I add the following ingredients:
| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Butane  | 100     | false               | false       |            |
Given in the New Product page I click Continue

# Regulatory 1 Page Details
And I should see the Regulatory Information 1 Page
And I set the U.S. Toxic Substances Control Act (TSCA) status option to: Compliant
And I set the Product, including container and/or packaging, contains a chemical on California's Prop 65 list option to: No
Given in the New Product page I click Continue

# Transportation Details 1 Page
And I should see the Transportation Details 1 Page
And I set the Product is Regulated for Transport option to: Yes
And I set the below options for field: Select all modes of transport that you've classified the product for
| Option                            |
| DOT                              |
| Shipping with limited quantity    |
| Shipping with consumer commodity  |

Given in the New Product page I click Continue

# DOT page
And I should see the U. S. Department of Transportation (DOT) Classification Page
And I set the UN Number option to: UN1950
And I set the Proper Shipping Name option to: Aerosols
And I set the Technical Name (if applicable) option to: Testcase57344
And I set the Hazard Class (select) option to: 2.2
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
#And Type of Product should be showing the following option: Artist's
Then I switch to Data Acceptance page
Given I navigate to the home page
Then I delete the product: TestCase57344

Scenario: [58210] Antibiotic, Liquid or Cream, Non-Aerosol - 8-L
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

# Checking that the test will run correctly by handling extra screens
Given If I see the retail partners page I set all data consent tiers to true for all retailers in the top section
Then The home screen should load

# New Product Page
And I click the Register New Product icon in the Navigation Pane
And I should see the New Product Page
And I set the Select the type of product to create option to: Create a New Registration
And in the New Product page I click Continue

# The Product Page
And I should see the The Product Page
And I set the Product Name option to: Flow8 - Antibiotic, Liquid or Cream, Non-Aerosol
And In the Product Type tab of the New Product Page, I enter: Antibiotic, Liquid or Cream, Non-Aerosol in the Type of Product select field
And in the New Product page I click Continue

# Product Characteristics Page
And I should see the Product Characteristics Page
Then I save the product information as: TestCase58210
And I should only see the following options for Primary Physical State:
| State |
| Liquid  |

And I set the Primary Physical State option to: Liquid
And I set the Secondary Physical State option to: Liquid
And I set the Specific Gravity option to: 2
And I set the pH option to: 2
And I set the Boiling Point (in Celsius) option to: 2
And I set the Flash Point (in Celsius) option to: 61
And I set the Flash Point Testing Method Used option to: Closed cup method
And I set the Select the best Water Solubility description option to: Very soluble
And in the New Product page I click Continue

# Additional Product Information page
And I should see the Additional Product Information Page
And In the Additional Information Page the check box for: United States should be: checked
And I set the Product is marketed for use by, or on, a child option to: No
And I set the Product has been classified using OSHA (US) option to: No
And I set the Product is shipped directly by supplier to the consumer option to: No
And I set the Product is a Retailer's Private Label or Brand option to: No
And I set the Product is sold to the Retailer solely for the Retailer's use option to: No
And in the New Product page I click Continue

# Ingredient Page
And I should see the Ingredients Page
Then I add the following ingredients:
| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Butane  | 100     | false               | false       |            |
Given in the New Product page I click Continue

# Regulatory 1 Page Details
And I should see the Regulatory Information 1 Page
And I set the U.S. Toxic Substances Control Act (TSCA) status option to: Compliant
And I set the Product, including container and/or packaging, contains a chemical on California's Prop 65 list option to: No
Given in the New Product page I click Continue

# Regulatory 3 Page Details
And I should see the Regulatory Information 3 Page
And I set the below options for field: Refer to your Product Label
| Option            |
| None of the Above |
Given in the New Product page I click Continue

# Transportation Details 1 Page
And I should see the Transportation Details 1 Page
And I set the Product is Regulated for Transport option to: Yes
And I set the below options for field: Select all modes of transport that you've classified the product for
| Option                            |
| DOT                              |
| Shipping with limited quantity    |
| Shipping with consumer commodity  |

Given in the New Product page I click Continue

# DOT page
And I should see the U. S. Department of Transportation (DOT) Classification Page
And I set the UN Number option to: UN1923
And I set the Proper Shipping Name option to: Calcium dithionite
And I set the Technical Name (if applicable) option to: Testcase58210
And I set the Hazard Class (select) option to: 4.2
And I set the Packing Group (select) option to: II
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
And Type of Product should be showing the following option: Antibiotic, Liquid or Cream, Non-Aerosol
Then I switch to Data Acceptance page
Given I navigate to the home page
Then I delete the product: TestCase58210


Scenario: [58282] Dental Whitening Gel - 8-L
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

# Checking that the test will run correctly by handling extra screens
Given If I see the retail partners page I set all data consent tiers to true for all retailers in the top section
Then The home screen should load

# New Product Page
And I click the Register New Product icon in the Navigation Pane
And I should see the New Product Page
And I set the Select the type of product to create option to: Create a New Registration
And in the New Product page I click Continue

# The Product Page
And I should see the The Product Page
And I set the Product Name option to: Flow8 - Dental whitening gel
And In the Product Type tab of the New Product Page, I enter: Dental whitening gel in the Type of Product select field
And in the New Product page I click Continue

# Product Characteristics Page
And I should see the Product Characteristics Page
Then I save the product information as: TestCase58282
And I should only see the following options for Primary Physical State:
| State |
| Liquid  |

And I set the Primary Physical State option to: Liquid
And I set the Secondary Physical State option to: Liquid
And I set the Specific Gravity option to: 2
And I set the pH option to: 2
And I set the Boiling Point (in Celsius) option to: 2
And I set the Flash Point (in Celsius) option to: 61
And I set the Flash Point Testing Method Used option to: Closed cup method
And I set the Select the best Water Solubility description option to: Very soluble
And in the New Product page I click Continue

# Additional Product Information page
And I should see the Additional Product Information Page
And In the Additional Information Page the check box for: United States should be: checked
And I set the Product has been classified using OSHA (US) option to: No
And I set the Product is shipped directly by supplier to the consumer option to: No
And I set the Product is a Retailer's Private Label or Brand option to: No
And I set the Product is sold to the Retailer solely for the Retailer's use option to: No
And in the New Product page I click Continue

# Ingredient Page
And I should see the Ingredients Page
Then I add the following ingredients:
| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Butane  | 100     | false               | false       |            |
Given in the New Product page I click Continue

# Regulatory 1 Page Details
And I should see the Regulatory Information 1 Page
And I set the U.S. Toxic Substances Control Act (TSCA) status option to: Compliant
And I set the Product, including container and/or packaging, contains a chemical on California's Prop 65 list option to: No
Given in the New Product page I click Continue

# Regulatory 3 Page Details
And I should see the Regulatory Information 3 Page
And I set the below options for field: Refer to your Product Label
| Option            |
| None of the Above |
Given in the New Product page I click Continue

# Transportation Details 1 Page
And I should see the Transportation Details 1 Page
And I set the Product is Regulated for Transport option to: Yes
And I set the below options for field: Select all modes of transport that you've classified the product for
| Option                            |
| DOT                              |
| Shipping with limited quantity    |
| Shipping with consumer commodity  |

Given in the New Product page I click Continue

# DOT page
And I should see the U. S. Department of Transportation (DOT) Classification Page
And I set the UN Number option to: UN1950
And I set the Proper Shipping Name option to: Aerosols
And I set the Technical Name (if applicable) option to: Testcase58282
And I set the Hazard Class (select) option to: 2.2
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
And Type of Product should be showing the following option: Dental whitening gel
Then I switch to Data Acceptance page
Given I navigate to the home page
Then I delete the product: TestCase58282

Scenario: [58285] Toothpaste - Whitening (RU001359) - 8-L
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

# Checking that the test will run correctly by handling extra screens
Given If I see the retail partners page I set all data consent tiers to true for all retailers in the top section
Then The home screen should load

# New Product Page
And I click the Register New Product icon in the Navigation Pane
And I should see the New Product Page
And I set the Select the type of product to create option to: Create a New Registration
And in the New Product page I click Continue

# The Product Page
And I should see the The Product Page
And I set the Product Name option to: Flow8 - Toothpaste - Whitening
And In the Product Type tab of the New Product Page, I enter: Toothpaste - Whitening in the Type of Product select field
And in the New Product page I click Continue

# Product Characteristics Page
And I should see the Product Characteristics Page
Then I save the product information as: TestCase58285
And I should only see the following options for Primary Physical State:
| State |
| Liquid  |
| Solid   |

And I set the Primary Physical State option to: Liquid
And I set the Secondary Physical State option to: Liquid
And I set the Specific Gravity option to: 2
And I set the pH option to: 2
And I set the Boiling Point (in Celsius) option to: 2
And I set the Flash Point (in Celsius) option to: 61
And I set the Flash Point Testing Method Used option to: Closed cup method
And I set the Select the best Water Solubility description option to: Very soluble
And in the New Product page I click Continue

# Additional Product Information page
And I should see the Additional Product Information Page
And In the Additional Information Page the check box for: United States should be: checked
And I set the Product has been classified using OSHA (US) option to: No
And I set the Product is shipped directly by supplier to the consumer option to: No
And I set the Product is a Retailer's Private Label or Brand option to: No
And I set the Product is sold to the Retailer solely for the Retailer's use option to: No
And in the New Product page I click Continue

# Ingredient Page
And I should see the Ingredients Page
Then I add the following ingredients:
| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Water  | 100     | false               | false       |            |
Given in the New Product page I click Continue

# Regulatory 1 Page Details
And I should see the Regulatory Information 1 Page
And I set the U.S. Toxic Substances Control Act (TSCA) status option to: Compliant
And I set the Product, including container and/or packaging, contains a chemical on California's Prop 65 list option to: No
Given in the New Product page I click Continue

# Transportation Details 1 Page
And I should see the Transportation Details 1 Page
And I set the Product is Regulated for Transport option to: Yes
And I set the below options for field: Select all modes of transport that you've classified the product for
| Option                            |
| DOT                              |
| Shipping with limited quantity    |
| Shipping with consumer commodity  |

Given in the New Product page I click Continue

# DOT page
And I should see the U. S. Department of Transportation (DOT) Classification Page
And I set the UN Number option to: UN1950
And I set the Proper Shipping Name option to: Aerosols
And I set the Technical Name (if applicable) option to: Testcase58285
And I set the Hazard Class (select) option to: 2.2
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

# Data Acceptance and Summary verification
And I should see the Data Acceptance Page
Given I click the Summary button in the Data Acceptance window
Then I switch to the Data Summary page
And Type of Product should be showing the following option: Toothpaste - Whitening
Then I switch to Data Acceptance page
Given I navigate to the home page
Then I delete the product: TestCase58285

Scenario: [58390] Paint,Model - RU000333

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)

Given I call Shared Step 57500 (The Product- Enter name, select product type: Paint, Model - Continue - Happy Path)

Then I save the product information as: TestCase58390

Given I call Shared Step 73629 (Product Characteristics - Liquid - select any options(enter pH, boiling point, flash point))
| Secondary Physical State | Specific Gravity | pH      | Boiling Point (in Celsius) | Flash Point (in Celsius) | Flash Point Testing Method Used     | Select the best Water Solubility description |
| Liquid                   | 2                | 2       | 2                          | 66                       | Closed cup method                   | Appreciable                                  |

Given I call Shared Step 73748 (Additional Product Information - US only - No to GHS - No to shipped supplier - No to Private Label - No to Sold to retailer)

Then I add the following ingredients:
| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Water  | 100     | false               | false       |            |
Given in the New Product page I click Continue

Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)

Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)

Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)

Given I call Shared 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: No Retailer/No UPC Product

Given I call Shared 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)

Given in the Additional Documents to Provide page I click Continue

Given in the Optional Reports and Documents Available for Purchase page I click Continue

Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient |
| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | 41.3005               |

Given I call Shared 57883 (Comments - Happy Path) and enter the comment: test data

# Data Acceptance and Summary verification
And I should see the Data Acceptance Page
Given I click the Summary button in the Data Acceptance window
Then I switch to the Data Summary page
And Type of Product should be showing the following option: Paint, Model
Then I switch to Data Acceptance page
Given I navigate to the home page
Then I delete the product: TestCase58390
