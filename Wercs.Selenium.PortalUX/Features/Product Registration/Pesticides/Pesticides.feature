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

Scenario: [71051] Pesticide Details - EPA Registration number if edited is NOT refresh from Kelly when the Update WERCSmart data link is used

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

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
