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
@run_voc

Feature: VOC


Scenario: [56475] VOC checks for Fabric Softener - single Use dryer product (RU000808)
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Given If I see the retail partners page I set all data consent tiers to true for all retailers in the top section
Then The home screen should load
And I click the Register New Product icon in the Navigation Pane
And I should see the header New Product
And I Select the Create a New Registration radio button
And in the New Product page I click Continue
And In the Product Type tab of the New Product Page, I enter: Fabric Softener - Single Use Dryer Product Only in the Product Name text field
And In the Product Type tab of the New Product Page, I enter: Fabric Softener - Single Use Dryer Product Only in the Type of Product select field
And in the New Product page I click Continue
Then I save the product information as: TestCase56475
And I should only see the following options for Primary Physical State:
| State |
| Solid |

And I set the Secondary Physical State to be: Granular
And I set the water mixture question to: Yes
And I set the Select the best Water Solubility description to be: Very soluble
And in the New Product page I click Continue
And I should see the Additional Product Information Page
And In the Additional Information Page the check box for: United States should be: checked

# Adapted to use the generic method
And I set the Product has been classified using OSHA (US) option to: No
And I set the Product is shipped directly by supplier to the consumer. option to: No
And I set the Product is a Retailer's Private Label or Brand option to: No
And I set the Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale) option to: No
And in the New Product page I click Continue

# Setting Ingredient Information
Then I add the following ingredients:
| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Formaldehyde  | 100     | false               | false       |            |
And in the New Product page I click Continue
And I should see the Regulatory Information 1 Page
And in the Product Characteristics tab of the New Product Page, for U.S. Toxic Substances Control Act (TSCA) status I select: Compliant
And in the Product Characteristics tab of the New Product Page for Prop65 I select: No
And in the New Product page I click Continue
And I should see the Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB) Page
And I confirm that I see the following VOC-OTC-CARB statement1: Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations.
And I confirm that I see the following VOC-OTC-CARB statement2: Product does not contain more than 0.05 grams of VOC per use, as defined in the California Consumer Products Regulation, Title 17, CCR Division 3, Chapter 1.
And in the New Product page I click Continue
Then I should see an error message: This is a required field.
# Moved these to the new 'generic' format for easier editing down the road!
And I set the Product has been granted an Alternative Control Plan option to: No
And I set the Product does not contain more than 0.05 grams of VOC per use option to: Disagree
#And In the Product Characteristics tab of the New Product Page, for Product does not contain more than grams of VOC per use I select: Disagree
And in the New Product page I click Continue
Given the 'Select Retailers' window appears
Then In the 'Select Retailers' window I select the retailer: No Retailer/No UPC Product
And in the New Product page I click Continue
And I should see the Regulatory Documents to Provide Page
And in the Review and Submit tab of the New Product Page for OSHA compliant SDS I select: Request to author
And in the New Product page I click Continue
And I should see the Additional Documents to Provide Page
And in the New Product page I click Continue
Then I should see an error message: Document is required: Product Label
#And In the Review and Submit tab of the New Product Page for Volatile Organic Compounds I upload pdf file
And I click the browse button for label: Product Label and upload PDF: C:\Dependencies\WERCSmart\testdoc.pdf
And in the New Product page I click Continue
And I should see the Optional Reports and Documents Available for Purchase Page
And in the New Product page I click Continue
And I should see the Safety Data Sheet Authoring - Additional Data (Optional) Page
And in the Review and Submit tab of the New Product Page for Appearance I select: Buff
And in the Review and Submit tab of the New Product Page for Odor I select: Roasted soy
And in the Review and Submit tab of the New Product Page for Odor Threshold I select: No data available
And in the Review and Submit tab of the New Product Page for Partition Coefficient I enter: 5.5
And in the New Product page I click Continue
And I should see the Comments Page
And in the New Product page I click Continue
And I should see the Data Acceptance Page
Then The Data Acceptance page should appear
Given I click the Summary button in the Data Acceptance window
Then I switch to the Data Summary page
And I confirm that I see the following option for Product has been granted an Alternative Control Plan question: No
And I confirm that I see the following option for Product does not contain more than grams of VOC per use question: Disagree
Then I switch to Data Acceptance page
Given I navigate to the home page
Then I delete the product: TestCase56475


Scenario: [56476] VOC checks for Personal Fragrance product
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
And I set the Product Name option to: Personal Fragrance Product
And In the Product Type tab of the New Product Page, I enter: Personal Fragrance Product (more than 20% fragrance) in the Type of Product select field
And in the New Product page I click Continue

# Product Characteristics Page
And I should see the Product Characteristics Page
Then I save the product information as: TestCase56476
And I should only see the following options for Primary Physical State:
| State |
| Liquid |

And I set the Secondary Physical State option to: Liquid
And I set the Specific Gravity option to: 2
And I set the pH option to: 2
And I set the Boiling Point (in Celsius) option to: 2
And I set the Flash Point (in Celsius) option to: 2
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
And in the Product Characteristics tab of the New Product Page for Prop65 I select: No
Given in the New Product page I click Continue

# Transportation Details 1 Page
And I should see the Transportation Details 1 Page
And in the Product Characteristics tab of the New Product Page, for Product is Regulated for Transport I select: No, due to an exemption or exception
And in the Product Characteristics tab of the New Product Page, for DOT Exceptions I select: 173.120(b)(3): Combustible liquid that does not sustain combustion
#And I set the Please select DOT Exceptions if applicable option to: 173.120(a)(3): FP > 35 °C (95 °F), but does not sustain combustion
Given in the New Product page I click Continue

# Transportation Details 2 Page
And I should see the Transportation Details 2 Page
And I set the International Shipping when DOT Exemption taken? option to: I do not ship internationally and I do not know the classification
Given in the New Product page I click Continue

# Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB) Page
And I should see the Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB) Page
And I set the Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations. option to: No
And I confirm that I do not see the following VOC Content as defined by OTC Model Rule statement
And in the New Product page I click Continue
Then Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the CARB should be showing the error messages: This is a required field.
And I set the Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the CARB field to: 1
Then Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the CARB should not be showing the error messages: This is a required field.
And in the New Product page I click Continue

# Volatile Organic Compound Summary page
And I should see the Volatile Organic Compound Summary Page
And I confirm that I see todays VOC Analysis Date
And I confirm that I see the following VOC content as weight percentage for each state statement: VOC content as weight percentage of total formula, minus exempt compounds, for each of the following states.
And I should see the following Voc Limits present:
| Use                                                      | VOC Compliance Limit         | Regulation       |
| Personal Fragrance Product (more than 20% fragrance)     | 65                           | CARB limit       |
And I should see the following Voc percent for each state:
| State  | Regulation          | VOC Value        |  State VOC Threshold   | Message   |
And I confirm that I see the following CARB value: 1
And I confirm statement: Based on the type of product shows the text: Based on the type of product, this must comply with the most restrictive VOC limit.
And I confirm statement: limits specified shows the text: Does not exceed the limits specified in the California Consumer Products Regulation

# Change the CARB value
Then in the New Product page I click section: Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB)
And I set the Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the CARB field to: 70
And in the New Product page I click Continue
And I confirm statement: limits specified shows the text: Exceeds the limits specified in the California Consumer Products Regulation
And in the New Product page I click Continue

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
Then Volatile Organic Compounds should be showing the error messages: Document is required: Product Label
And I click the browse button for label: Product Label and upload PDF: C:\Dependencies\WERCSmart\testdoc.pdf
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

# Data Acceptance Page and clean up
And I should see the Data Acceptance Page
Given I navigate to the home page
Then I delete the product: TestCase56476


Scenario: [56477] VOC checks for Charcoal lighter material (RU000743)
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
And I set the Product Name option to: Charcoal Lighter Material
And In the Product Type tab of the New Product Page, I enter: Charcoal Lighter Material in the Type of Product select field
And in the New Product page I click Continue

# Product Characteristics Page
And I should see the Product Characteristics Page
Then I save the product information as: TestCase56477
And I should only see the following options for Primary Physical State:
| State |
| Liquid |

And I set the Secondary Physical State option to: Liquid
And I set the Specific Gravity option to: 2
And I set the pH option to: 2
And I set the Boiling Point (in Celsius) option to: 2
And I set the Flash Point (in Celsius) option to: 2
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
And in the Product Characteristics tab of the New Product Page for Prop65 I select: No
Given in the New Product page I click Continue

# Transportation Details 1 Page
And I should see the Transportation Details 1 Page
And in the Product Characteristics tab of the New Product Page, for Product is Regulated for Transport I select: No, due to an exemption or exception
And in the Product Characteristics tab of the New Product Page, for DOT Exceptions I select: 173.120(b)(3): Combustible liquid that does not sustain combustion
Given in the New Product page I click Continue

# Transportation Details 2 Page
And I should see the Transportation Details 2 Page
And I set the International Shipping when DOT Exemption taken? option to: I do not ship internationally and I do not know the classification
Given in the New Product page I click Continue

# Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB) Page
And I should see the Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB) Page
And I set the Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations. option to: No
And I confirm that I see the following VOC Content below threshold CARB statement: Verify VOC content is below the threshold of 0.02lb/start of CARB
And I confirm that I see the following VOC Content below threshold OTC statement: Verify VOC content is below the threshold of 0.02lb/start of OTC
Given in the New Product page I click Continue
Then Verify VOC content is below the threshold of 0.02lb/start of CARB should be showing the error messages: This is a required field.
Then Verify VOC content is below the threshold of 0.02lb/start of OTC should be showing the error messages: This is a required field.
And I set the Verify VOC content is below the threshold of 0.02lb/start of CARB option to: No
Then Verify VOC content is below the threshold of 0.02lb/start of CARB should not be showing the error messages: This is a required field.
And I set the Verify VOC content is below the threshold of 0.02lb/start of OTC option to: No
Then Verify VOC content is below the threshold of 0.02lb/start of OTC should not be showing the error messages: This is a required field.
Given in the New Product page I click Continue

# Volatile Organic Compound Summary page
And I should see the Volatile Organic Compound Summary Page
And I confirm that I see todays VOC Analysis Date
And I should see the following Voc Limits with units  present:
| Use                       | VOC Compliance Limit | Units      | Regulation           |
| Charcoal Lighter Material | 0.02                 | lb / start | OTC Model rule limit |
| Charcoal Lighter Material | 0.02                 | lb / start | CARB limit           |
And I confirm statement: Based on the type of product shows the text: Based on the type of product, this must comply with the most restrictive VOC limit.
And I confirm statement: limits specified by CARB shows the text: Exceeds the limits specified by CARB
And I confirm statement: limits specified by OTC shows the text: Exceeds the limits specified by OTC Model Rule

# Change the CARB  and OTC threshold options
Then in the New Product page I click section: Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB)
And I set the Verify VOC content is below the threshold of 0.02lb/start of CARB option to: Yes
And I set the Verify VOC content is below the threshold of 0.02lb/start of OTC option to: Yes
And in the New Product page I click Continue
And I confirm statement: limits specified by CARB shows the text: Does not exceed the limits specified by CARB
And I confirm statement: limits specified by OTC shows the text: Does not exceed the limits specified by OTC Model Rule
And in the New Product page I click Continue

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
Then Volatile Organic Compounds should be showing the error messages: Document is required: Product Label
And I click the browse button for label: Product Label and upload PDF: C:\Dependencies\WERCSmart\testdoc.pdf
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

# Data Acceptance Page and clean up
And I should see the Data Acceptance Page
Given I navigate to the home page
Then I delete the product: TestCase56477


Scenario: [56481] VOC checks for Oven Cleaner - pump sprays (RU000798) - CARB and OTC
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
And I set the Product Name option to: Oven Cleaner - Pump Sprays
And In the Product Type tab of the New Product Page, I enter: Oven Cleaner - Pump Sprays in the Type of Product select field
And in the New Product page I click Continue

# Product Characteristics Page
And I should see the Product Characteristics Page
Then I save the product information as: TestCase56481
And I should only see the following options for Primary Physical State:
| State |
| Liquid |

And I set the Secondary Physical State option to: Liquid
And I set the Specific Gravity option to: 2
And I set the pH option to: 2
And I set the Boiling Point (in Celsius) option to: 2
And I set the Flash Point (in Celsius) option to: 2
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
And in the Product Characteristics tab of the New Product Page for Prop65 I select: No
Given in the New Product page I click Continue

# Transportation Details 1 Page
And I should see the Transportation Details 1 Page
And in the Product Characteristics tab of the New Product Page, for Product is Regulated for Transport I select: No, due to an exemption or exception
And in the Product Characteristics tab of the New Product Page, for DOT Exceptions I select: 173.120(b)(3): Combustible liquid that does not sustain combustion
Given in the New Product page I click Continue

# Transportation Details 2 Page
And I should see the Transportation Details 2 Page
And I set the International Shipping when DOT Exemption taken? option to: I do not ship internationally and I do not know the classification
Given in the New Product page I click Continue

# Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB) Page
And I should see the Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB) Page
And I set the Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations. option to: No
And I confirm that I see the following VOC Content as defined by CARB statement: Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the CARB
And I confirm that I see the following VOC Content as defined by OTC Model Rule statement: Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the OTC Model Rule
And I confirm that I see the following VOC percentages entered for all areas statement: Would you like to use the VOC percentages entered for all areas (e.g. country, state, local) for comparison?
And I should see the following radio buttons:
| Button                                                       |
| Yes                                                          |
| No, I would like to manually enter VOC value for each area.  |
And in the New Product page I click Continue
Then Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the CARB should be showing the error messages: This is a required field.
Then Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the OTC Model Rule should be showing the error messages: This is a required field.
Then Would you like to use the VOC percentages entered for all areas (e.g. country, state, local) for comparison? should be showing the error messages: This is a required field.
And I set the Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the CARB field to: 1
Then Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the CARB should not be showing the error messages: This is a required field.
And I set the Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the OTC Model Rule field to: 1
Then Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the OTC Model Rule should not be showing the error messages: This is a required field.
And I set the Would you like to use the VOC percentages entered for all areas (e.g. country, state, local) for comparison? field to: Yes
Then Would you like to use the VOC percentages entered for all areas (e.g. country, state, local) for comparison? should not be showing the error messages: This is a required field.
And in the New Product page I click Continue

# Volatile Organic Compound Summary page
And I should see the Volatile Organic Compound Summary Page
And I confirm that I see todays VOC Analysis Date
And I confirm that I see the following VOC content as weight percentage for each state statement: VOC content as weight percentage of total formula, minus exempt compounds, for each of the following states.
And I should see the following Voc Limits present:
| Use                            | VOC Compliance Limit        | Regulation                 |
| Oven Cleaner - Pump Sprays     | 4                           | OTC Model rule limit       |
| Oven Cleaner - Pump Sprays     | 4                           | CARB limit                 |
And I should see the following Voc percent for each state:
| State           | Regulation            | VOC Value | State VOC Threshold | Message                             |
| Connecticut     | State Allowable Limit | 1         | 5                   | Does not exceed the State Limits    |
| Washington D.C. | State Allowable Limit | 1         | 5                   | Does not exceed the State Limits    |
| Delaware        | State Allowable Limit | 1         | 5                   | Does not exceed the State Limits    |
| Illinois        | State Allowable Limit | 1         | 5                   | Does not exceed the State Limits    |
| Indiana         | State Allowable Limit | 1         | 5                   | Does not exceed the State Limits    |
| Massachusetts   | State Allowable Limit | 1         | 5                   | Does not exceed the State Limits    |
| Maryland        | State Allowable Limit | 1         | 5                   | Does not exceed the State Limits    |
| Maine           | State Allowable Limit | 1         | 5                   | Does not exceed the State Limits    |
| Michigan        | State Allowable Limit | 1         | 5                   | Does not exceed the State Limits    |
| New Hampshire   | State Allowable Limit | 1         | 5                   | Does not exceed the State Limits    |
| New Jersey      | State Allowable Limit | 1         | 5                   | Does not exceed the State Limits    |
| New York        | State Allowable Limit | 1         | 5                   | Does not exceed the State Limits    |
| Ohio            | State Allowable Limit | 1         | 5                   | Does not exceed the State Limits    |
| Pennsylvania    | State Allowable Limit | 1         | 5                   | Does not exceed the State Limits    |
| Rhode Island    | State Allowable Limit | 1         | 5                   | Does not exceed the State Limits    |
| Utah            | State Allowable Limit | 1         | 4                   | Does not exceed the State Limits    |
| Virginia        | State Allowable Limit | 1         | 5                   | Does not exceed the State Limits    |
| Vermont         | State Allowable Limit | 1         | 5                   | Does not exceed the State Limits    |
And I confirm that I see the following CARB value: 1
And I confirm statement: Based on the type of product shows the text: Based on the type of product, this must comply with the most restrictive VOC limit.
And I confirm statement: limits specified in the California Consumer Products Regulation shows the text: Does not exceed the limits specified in the California Consumer Products Regulation
And I confirm statement: limits specified by the Ozone Transport Commission shows the text: Does not exceed the limits specified by the Ozone Transport Commission

# Change the CARB  and OTC Model Rule value
Then in the New Product page I click section: Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB)
And I set the Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the CARB field to: 5
And I set the Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the OTC Model Rule field to: 5
And in the New Product page I click Continue
And I confirm statement: limits specified in the California Consumer Products Regulation shows the text: Exceeds the limits specified in the California Consumer Products Regulation
And I confirm statement: limits specified by the Ozone Transport Commission shows the text: Exceeds the limits specified by the Ozone Transport Commission
And in the New Product page I click Continue

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
Then Volatile Organic Compounds should be showing the error messages: Document is required: Product Label
And I click the browse button for label: Product Label and upload PDF: C:\Dependencies\WERCSmart\testdoc.pdf
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

# Data Acceptance Page and clean up
And I should see the Data Acceptance Page
Given I navigate to the home page
Then I delete the product: TestCase56481


Scenario: [56483] VOC - Antiperspirant and Deodorant checks
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
And I set the Product Name option to: Antiperspirants - Non-aerosol
And In the Product Type tab of the New Product Page, I enter: Antiperspirants - Non-aerosol in the Type of Product select field
And in the New Product page I click Continue

# Product Characteristics Page
And I should see the Product Characteristics Page
Then I save the product information as: TestCase56483
And I should only see the following options for Primary Physical State:
| State |
| Liquid |
| Solid |
And I set the Primary Physical State option to: Solid
And I set the Secondary Physical State option to: Solid
And I set the When mixed with an equal amount of water option to: No
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
And in the Product Characteristics tab of the New Product Page for Prop65 I select: No
Given in the New Product page I click Continue

# Regulatory 3 Page Details
And I should see the Regulatory Information 3 Page
And I set the below options for field: Refer to your Product Label
| Option            |
| None of the Above |
Given in the New Product page I click Continue

# Transportation Details 1 Page
And I should see the Transportation Details 1 Page
And I set the Product is Regulated for Transport option to: Not Regulated
Given in the New Product page I click Continue

# Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB) Page
And I should see the Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB) Page
And I set the Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations. option to: No
And in the New Product page I click Continue
Then HVOC (high volatile organic compound) content as weight percent of the total formulation should be showing the error messages: This is a required field.
Then MVOC (microbial volatile organic compound) content as weight percentage of the total formulation should be showing the error messages: This is a required field.
And I set the HVOC (high volatile organic compound) content as weight percent of the total formulation field to: 1
And I set the MVOC (microbial volatile organic compound) content as weight percentage of the total formulation field to: 1
And in the New Product page I click Continue

# Volatile Organic Compound Summary page
And I should see the Volatile Organic Compound Summary Page
And I confirm that I see todays VOC Analysis Date
And I should see the following Voc Limits present:
| Use                               | VOC Compliance Limit         | Regulation                                                    |
| Antiperspirants - Non-aerosol     | 0                         | HVOC CARB and OTC Model Rule limit                               |
| Antiperspirants - Non-aerosol     | 0                         | MVOC CARB and OTC Model Rule limit                               |
And I confirm that I see the following HVOC value: 1
And I confirm that I see the following MVOC value: 1
And I confirm statement: Based on the type of product shows the text: Based on the type of product, this must comply with the most restrictive VOC limit.
And I confirm statement: limits specified shows the text: Exceeds the limits specified by CARB and OTC Model Rule

#change the HVOC and MVOC value
Then in the New Product page I click section: Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB)
And I set the HVOC (high volatile organic compound) content as weight percent of the total formulation field to: 0
And I set the MVOC (microbial volatile organic compound) content as weight percentage of the total formulation field to: 0
And in the New Product page I click Continue
And I confirm statement: limits specified shows the text: Does not exceed the limits specified by CARB and OTC Model Rule

And in the New Product page I click Continue

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
Then Volatile Organic Compounds should be showing the error messages: Document is required: Product Label
And I click the browse button for label: Product Label and upload PDF: C:\Dependencies\WERCSmart\testdoc.pdf
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

# Data Acceptance Page and clean up
And I should see the Data Acceptance Page
Given I navigate to the home page
Then I delete the product: TestCase56483


Scenario: [56484] VOC - Aero checks
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
And I set the Product Name option to: Clear Coating - Aerosol
And In the Product Type tab of the New Product Page, I enter: Clear Coating - Aerosol in the Type of Product select field
And in the New Product page I click Continue

# Product Characteristics Page
And I should see the Product Characteristics Page
Then I save the product information as: TestCase56484
And I should only see the following options for Primary Physical State:
| State |
| Aerosol |
And I set the Secondary Physical State option to: Solid spray
And I set the pH option to: 2
And I set the Select the best Water Solubility description option to: Very soluble
And I set the When the product has a flammable propellant, or contains ingredients with a flash point below 60⁰C then option to: This product is not classified as D001 or D003 Hazardous Waste under RCRA
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
And in the Product Characteristics tab of the New Product Page for Prop65 I select: No
Given in the New Product page I click Continue

# Transportation Details 1 Page
And I should see the Transportation Details 1 Page
And I set the Product is Regulated for Transport option to: Yes
And I set the below options for field: Select all modes of transport that you've classified the product for
| Option                           |
| DOT                              |
| Shipping with limited quantity   |
| Shipping with consumer commodity |
Given in the New Product page I click Continue

# U. S. Department of Transportation (DOT) Classification Page
Then I should see the U. S. Department of Transportation (DOT) Classification Page
And I set the UN Number field to: UN1950
And I set the Proper Shipping Name field to: Aerosols
And I set the Technical Name (if applicable) field to: Clear Coating - Aerosol
And I set the Hazard Class (select) field to: 2.1
And I set the Packing Group (select) field to: None
Given in the New Product page I click Continue

# Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB) Page
And I should see the Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB) Page
And I confirm that I see the following VOC-OTC-CARB statement1: Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations.
And I confirm that I see the following VOC-OTC-CARB statement3: VOC content in grams ozone per gram
And I set the Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations. option to: No
And in the New Product page I click Continue
Then VOC content in grams ozone per gram should be showing the error messages: This is a required field.
And I set the VOC content in grams ozone per gram field to: 0.5
And in the New Product page I click Continue

# Volatile Organic Compound Summary page
And I should see the Volatile Organic Compound Summary Page
And I confirm that I see todays VOC Analysis Date
And I confirm that I see the following VOC-OTC-CARB statement4: Based on your selection, you have verified your product contains VOC with intended uses as follows. The Aerosol Coatings by the CARB VOC compliance limit(s) for the intended use you identified is/are:
And I should see the following Voc Limits present:
| Use                         | VOC Compliance Limit         | Regulation                                                |
| Clear Coating - Aerosol     | 0.85                         | Aerosol Coatings CARB limit                               |
And I confirm that I see the following VOC Grams Ozone value: 0.5
And I confirm statement: limits specified shows the text: Does not exceed the limits specified in the Aerosol Coatings by the CARB
And I confirm statement: Based on the type of product shows the text: Based on the type of product, this must comply with the most restrictive VOC limit.

#change the VOC grams value
Then in the New Product page I click section: Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB)
And I set the VOC content in grams ozone per gram field to: 1
And in the New Product page I click Continue
And I confirm statement: limits specified shows the text: Exceeds the limits specified in the Aerosol Coatings by the CARB
And in the New Product page I click Continue

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
Then Volatile Organic Compounds should be showing the error messages: Document is required: Product Label
And I click the browse button for label: Product Label and upload PDF: C:\Dependencies\WERCSmart\testdoc.pdf
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
#And in the New Product page I click Continue
#Then Product's Dispensing Method should be showing the error messages: This is a required field.
And I set the Product's Dispensing Method field to: Pump
And in the New Product page I click Continue

# Comments Page
And I should see the Comments Page
And in the New Product page I click Continue

# Data Acceptance Page and clean up
And I should see the Data Acceptance Page
Given I navigate to the home page
Then I delete the product: TestCase56484

@test74626
Scenario: [74626] VOC - Show state collection when state table has a value

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Given I call Shared 57753 (Create a New Registration via Register New Product (expanded menu))

Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Insecticide - Fogger

Then I save the product information as: TestCase74626

Then I call Shared Step 57454 (Product Characteristics - Aerosol & Gas available - Select Aerosol - Continue - Happy Path)

Given I call Shared Step 57865 (Additional Product Information - Pesticide shown, US only, select No for everything else - Happy Path)

Given I call Shared Step 69557 (Enter Ingredients for Aerosol Propellent)

Given I call Shared 57571 (Enter Regulatory Information - Not Prop 65)

Given I call Shared Step 57589 (Enter Pesticide Data - United States (without EPA number))

Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)

Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)

Given I call Shared Step 57923 (Volatile Organic Compound (VOC) Step - enter OTC and CARB - Yes for state values)
| Product granted Alternative Control Plan | Amount of VOC by CARB | Amount of VOC by OTC Model | VOC for states |
| No                                       | 0                     | 0                          | Yes            |

And I should see the following Voc percent for each state:
| State           | Regulation            | VOC Value | State VOC Threshold | Message                          |
| Connecticut     | State Allowable Limit | 0         | 45                  | Does not exceed the State Limits |
| Washington D.C. | State Allowable Limit | 0         | 45                  | Does not exceed the State Limits |
| Delaware        | State Allowable Limit | 0         | 45                  | Does not exceed the State Limits |
| Illinois        | State Allowable Limit | 0         | 45                  | Does not exceed the State Limits |
| Indiana         | State Allowable Limit | 0         | 45                  | Does not exceed the State Limits |
| Massachusetts   | State Allowable Limit | 0         | 45                  | Does not exceed the State Limits |
| Maryland        | State Allowable Limit | 0         | 45                  | Does not exceed the State Limits |
| Maine           | State Allowable Limit | 0         | 45                  | Does not exceed the State Limits |
| Michigan        | State Allowable Limit | 0         | 45                  | Does not exceed the State Limits |
| New Hampshire   | State Allowable Limit | 0         | 45                  | Does not exceed the State Limits |
| New Jersey      | State Allowable Limit | 0         | 45                  | Does not exceed the State Limits |
| New York        | State Allowable Limit | 0         | 45                  | Does not exceed the State Limits |
| Ohio            | State Allowable Limit | 0         | 45                  | Does not exceed the State Limits |
| Pennsylvania    | State Allowable Limit | 0         | 45                  | Does not exceed the State Limits |
| Rhode Island    | State Allowable Limit | 0         | 45                  | Does not exceed the State Limits |
| Utah            | State Allowable Limit | 0         | 45                  | Does not exceed the State Limits |
| Virginia        | State Allowable Limit | 0         | 45                  | Does not exceed the State Limits |
| Vermont         | State Allowable Limit | 0         | 45                  | Does not exceed the State Limits |

Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase74626
