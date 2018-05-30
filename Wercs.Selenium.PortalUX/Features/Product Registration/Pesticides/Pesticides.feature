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
@run_Pesticides

Feature: Pesticides

#release day
Scenario: [71051] Pesticide Details - EPA Registration number if edited is NOT refresh from Kelly when the Update WERCSmart data link is used

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load
# ***** Shared step 57753 ***** #
Then I click the Register New Product icon in the Navigation Pane
And I should see the New Product Page
And I set the Select the type of product to create option to: Create a New Registration
And in the New Product page I click Continue

# ***** Shared step 57561 The Product - Enter Product Name and select Type of Product ***** #
# ***** Specified conditions - use 'Pet Shampoo with Pest Control' as the product type ***** #
And I should see the The Product Page
And I set the Product Name as it a appears on the Package Label field to: Product - Pet Shampoo with Pest Control
And In the Product Type tab of the New Product Page, I enter: Pet Shampoo with Pest Control in the Type of Product select field
And in the The Product page I click Continue
Then I save the product information as: TestCase71051

# ***** Shared step 57514 Product characteristics - Liquid Only available - Enter all data - Continue ***** #
And I should see the Product Characteristics Page
And Primary Physical State should be showing the value: Liquid
And I set the Secondary Physical State option to: Liquid
And I set the Specific Gravity field to: 1
And I set the pH field to: 7
And I set the Boiling Point (in Celsius) field to: 100
And I set the Flash Point (in Celsius) field to: 80
And in the Product Characteristics tab, for Flash Point Testing Method Used status I select: Not applicable/available
And in the New Product page I click Continue

# ***** Shared step 57865 Additional Product Information - Pesticide shown, US only, select No for everything else ***** #
And I should see the Additional Product Information Page
And I set the Which one best describes your product field to: Prevents, Destroys Repels Pests (Pests are Mold, Mildew, Fungus, Rodents, Insects, and/or Spiders)
And I set the Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada) field to: No
And I set the Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns. field to: No
And I set the Product is a Retailer's Private Label or Brand field to: No
And I set the Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale) field to: No
And in the New Product page I click Continue

# ***** Shared step 29181 Ingredients - add any chemical ***** #
Then I add the following ingredients:
| ComponentName    |  Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Sodium hydroxide |  100     | false               | false       |            |
And in the Ingredients page I click Continue
And I should see the Regulatory Information 1 Page

# **** Shared step 57503 Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue ***** #
Given I only see the following sections
| Section                                                                                         |
| U.S. Toxic Substances Control Act (TSCA) status                                                 |
| Product, including container and/or packaging, contains a chemical on California's Prop 65 list |
And I set the U.S. Toxic Substances Control Act (TSCA) status option to: Compliant
And I set the Product, including container and/or packaging, contains a chemical on California's Prop 65 list option to: No
Then in the Regulatory Information 1 page I click Continue

# ***** Shared step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue ***** #
And I set the below options for field: Refer to your Product Label
| Option            |
| None of the Above |
Given in the New Product page I click Continue

And I should see the Pesticide Details - U.S. Page

And I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: Yes

Given in the New Product page I click Continue

Given I add the EPA registration number: 72315-6

Given in the New Product page I click Continue
And I should see the Pesticide Details - State Registration Details Page

Given I edit each State Pesticide Registration Number with an edited suffix

Given in the New Product page I click Continue
And I should see the Transportation Details 1 Page

Then in the New Product page I click section: Pesticide Details - State Registration Details
And I should see the Pesticide Details - State Registration Details Page

Then I check each State Pesticide Registration Number contains the edited suffix

Given I click the Update Wercs Smart data with EPA data through Kelly Services link

Then I check each State Pesticide Registration Number contains the edited suffix

Given I navigate to the home page

Then I delete the product: TestCase71051

#release day
Scenario: [62848] Pesticide Details - EPA Expiration Date is refresh from Kelly when the Update WERCSmart data link is used

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load
# ***** Shared step 57753 ***** #
Then I click the Register New Product icon in the Navigation Pane
And I should see the New Product Page
And I set the Select the type of product to create option to: Create a New Registration
And in the New Product page I click Continue

# ***** Shared step 57561 The Product - Enter Product Name and select Type of Product ***** #
# ***** Specified conditions - use 'Pet Shampoo with Pest Control' as the product type ***** #
And I should see the The Product Page
And I set the Product Name as it a appears on the Package Label field to: Product - Pet Shampoo with Pest Control
And In the Product Type tab of the New Product Page, I enter: Pet Shampoo with Pest Control in the Type of Product select field
And in the The Product page I click Continue
Then I save the product information as: TestCase62848

# ***** Shared step 57514 Product characteristics - Liquid Only available - Enter all data - Continue ***** #
And I should see the Product Characteristics Page
And Primary Physical State should be showing the value: Liquid
And I set the Secondary Physical State option to: Liquid
And I set the Specific Gravity field to: 2
And I set the pH field to: 5
And I set the Boiling Point (in Celsius) field to: 110
And I set the Flash Point (in Celsius) field to: 85
And in the Product Characteristics tab, for Flash Point Testing Method Used status I select: Not applicable/available
And in the New Product page I click Continue

# ***** Shared step 57865 Additional Product Information - Pesticide shown, US only, select No for everything else ***** #
And I should see the Additional Product Information Page
And I set the Which one best describes your product field to: Prevents, Destroys Repels Pests (Pests are Mold, Mildew, Fungus, Rodents, Insects, and/or Spiders)
And I set the Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada) field to: No
And I set the Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns. field to: No
And I set the Product is a Retailer's Private Label or Brand field to: No
And I set the Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale) field to: No
And in the New Product page I click Continue

# ***** Shared step 29181 Ingredients - add any chemical ***** #
Then I add the following ingredients:
| ComponentName    |  Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Sodium hydroxide |  100     | false               | false       |            |
And in the Ingredients page I click Continue
And I should see the Regulatory Information 1 Page

# **** Shared step 57503 Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue ***** #
Given I only see the following sections
| Section                                                                                         |
| U.S. Toxic Substances Control Act (TSCA) status                                                 |
| Product, including container and/or packaging, contains a chemical on California's Prop 65 list |
And I set the U.S. Toxic Substances Control Act (TSCA) status option to: Compliant
And I set the Product, including container and/or packaging, contains a chemical on California's Prop 65 list option to: No
Then in the Regulatory Information 1 page I click Continue

# ***** Shared step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue ***** #
And I set the below options for field: Refer to your Product Label
| Option            |
| None of the Above |
Given in the New Product page I click Continue

And I should see the Pesticide Details - U.S. Page

And I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: Yes

Given in the New Product page I click Continue

Given I add the EPA registration number: 56228-10

Given in the New Product page I click Continue

And I should see the Pesticide Details - State Registration Details Page

Given I confirm that there is data populated in the Expiration Date Column for some States

And I confirm the 'Is Kelly Data' field is marked with a check for every State containing data in 'Expiration Date'

Then I edit the Expiration Date to: 2019-12-31 for the State: AZ on the Pesticide State Registration Details page

Given in the New Product page I click Continue

Then in the New Product page I click section: Pesticide Details - U.S.
And I should see the Pesticide Details - U.S. Page

Given in the New Product page I click Continue

And I should see the Pesticide Details - State Registration Details Page

Then I confirm the 'Is Kelly Data' field for State: AZ is not checked

Given I click the Update Wercs Smart data with EPA data through Kelly Services link

Then I confirm the Expiration Date matches the value provided by Kelly on the State Registration Details Page

Then I confirm the 'Is Kelly Data' field for State: AZ is checked

Given I navigate to the home page

Then I delete the product: TestCase62848

Scenario: [62775] Pesticides - Validation of Which one best describes your product question - Prevents, Destroys etc
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load
# Shared step 57753
Then I click the Register New Product icon in the Navigation Pane
And I should see the New Product Page
And I set the Select the type of product to create option to: Create a New Registration
And in the New Product page I click Continue

# Shared step 57561 The Product - Enter Product Name and select Type of Product
# Specified conditions - use 'Pet Shampoo with Pest Control' as the product type
And I should see the The Product Page
And I set the Product Name as it a appears on the Package Label field to: Product - Pet Shampoo with Pest Control 62775
And In the Product Type tab of the New Product Page, I enter: Pet Shampoo with Pest Control in the Type of Product select field
And in the The Product page I click Continue
Then I save the product information as: TestCase62775

# Shared step 57514 Product characteristics - Liquid Only available - Enter all data - Continue
And I should see the Product Characteristics Page
And Primary Physical State should be showing the value: Liquid
And I set the Secondary Physical State option to: Liquid
And I set the Specific Gravity field to: 5
And I set the pH field to: 9
And I set the Boiling Point (in Celsius) field to: 80
And I set the Flash Point (in Celsius) field to: 71
And in the Product Characteristics tab, for Flash Point Testing Method Used status I select: Not applicable/available
And in the New Product page I click Continue

And I should see the Additional Product Information Page

Given I see the following sections
| Section                               |
| Which one best describes your product |

Given I should see a total of 3 radio buttons for the section: Which one best describes your product

Then I should see the following radio buttons:
| Button                                                                                                                  |
| Prevents, Destroys Repels Pests (Pests are Mold, Mildew, Fungus, Rodents, Insects, and/or Spiders)                      |
| Regulates Plant Growth, Defoliates (removes leaves) Plants and controls growth, Dehydrates plants for control of growth |
| Product is not considered a pesticide product                                                                           |

And in the New Product page I click Continue

Then I should see an error message: This is a required field.

And I set the Which one best describes your product field to: Prevents, Destroys Repels Pests (Pests are Mold, Mildew, Fungus, Rodents, Insects, and/or Spiders)

Then Which one best describes your product should not be showing the error messages: This is a required field.

And in the New Product page I click Continue

Then Which one best describes your product should not be showing the error messages: This is a required field.

Given I navigate to the home page

Then I delete the product: TestCase62775

Scenario: [62776] Pesticides - Validation of Which one best describes your product - Regulates Plant Growth
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load
# Shared step 57753
Then I click the Register New Product icon in the Navigation Pane
And I should see the New Product Page
And I set the Select the type of product to create option to: Create a New Registration
And in the New Product page I click Continue

# Shared step 57561 The Product - Enter Product Name and select Type of Product
# Specified conditions - use 'Pet Shampoo with Pest Control' as the product type
And I should see the The Product Page
And I set the Product Name as it a appears on the Package Label field to: Product - Pet Shampoo with Pest Control 62775
And In the Product Type tab of the New Product Page, I enter: Pet Shampoo with Pest Control in the Type of Product select field
And in the The Product page I click Continue
Then I save the product information as: TestCase62776

# Shared step 57514 Product characteristics - Liquid Only available - Enter all data - Continue
And I should see the Product Characteristics Page
And Primary Physical State should be showing the value: Liquid
And I set the Secondary Physical State option to: Liquid
And I set the Specific Gravity field to: 5
And I set the pH field to: 9
And I set the Boiling Point (in Celsius) field to: 80
And I set the Flash Point (in Celsius) field to: 71
And in the Product Characteristics tab, for Flash Point Testing Method Used status I select: Not applicable/available
And in the New Product page I click Continue

And I should see the Additional Product Information Page

Given I see the following sections
| Section                               |
| Which one best describes your product |

Given I should see a total of 3 radio buttons for the section: Which one best describes your product

Then I should see the following radio buttons:
| Button                                                                                                                  |
| Prevents, Destroys Repels Pests (Pests are Mold, Mildew, Fungus, Rodents, Insects, and/or Spiders)                      |
| Regulates Plant Growth, Defoliates (removes leaves) Plants and controls growth, Dehydrates plants for control of growth |
| Product is not considered a pesticide product                                                                           |

And in the New Product page I click Continue

Then I should see an error message: This is a required field.

And I set the Which one best describes your product field to: Regulates Plant Growth, Defoliates (removes leaves) Plants and controls growth, Dehydrates plants for control of growth

Then Which one best describes your product should not be showing the error messages: This is a required field.

And in the New Product page I click Continue

Then Which one best describes your product should not be showing the error messages: This is a required field.

Given I navigate to the home page

Then I delete the product: TestCase62776
