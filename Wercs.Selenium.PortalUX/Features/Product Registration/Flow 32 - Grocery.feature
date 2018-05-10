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

Feature: Flow 32 - Grocery

Scenario: [60774] Food Item Dispensed by Compressed Gas - Dairy Topping - RU001244

# ====== Logging in as the correct user ====== #
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

# ====== Just checks that the correct page loads ====== #
Given If I see the retail partners page I set all data consent tiers to true for all retailers in the top section
Then The home screen should load

# ====== Test Setup - Generating + Saving UPC Number and ensuring no duplicates exist ====== #
Given I generate a random UPC number and save as: UPC60774
Given I delete all products with UPC Number: saved as UPC60774

# ====== Following the steps from 'Shared Step' 57753 ====== #
Then I click the Register New Product icon in the Navigation Pane
And I should see the New Product Page
And I set the Select the type of product to create option to: Create a New Registration
And in the New Product page I click Continue

# ====== Following the steps from 'Shared Step' 57561 ====== #
And I should see the The Product Page
And I set the Product Name as it a appears on the Package Label field to: Food Item Dispensed by Compressed Gas - Dairy Topping
And In the Product Type tab of the New Product Page, I enter: Food Item Dispensed by Compressed Gas - Dairy Topping in the Type of Product select field
And in the The Product page I click Continue
Then I save the product information as: TestCase60774

# ====== Following the steps from 'Shared Step' 60778 ====== #
And I should see the Product Characteristics Page
And Primary Physical State should be showing the value: Product is packaged in a gas cylinder (e.g., whip cream)
And I set the Secondary Physical State option to: Liquid
And I set the pH field to: 7
And I set the Select the best Water Solubility description field to: Decomposes
And I set the When the product has a flammable propellant field to: This product is not classified as D001 or D003 Hazardous Waste under RCRA
And I set the Select all ingredients included in this product field to: Dairy
And I set the Product is manufactured in a facility that processes, or contains field to: Dairy or products containing dairy or milk
And I set the Product is verified and sold as field to: None of the Above
And I set the Product contains the following sweeteners field to: None of the Above
And I set the Product contains the following artificial dye(s) option to: None of the Above
And in the Product Characteristics page I click Continue

# ====== Following the steps from 'Shared Step' 60756 ====== #
And I should see the Additional Product Information Page
And Select countries the product may be sold in should be showing the value: United States
And I set the Select the product's Country of Origin field to: United Kingdom
And I set the Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) field to: No
And I set the Product is shipped directly by supplier to the consumer. field to: No
And I set the Product is a Retailer's Private Label or Brand field to: No
And I set the Product is sold to the Retailer solely for the Retailer's use field to: No
And in the Additional Product Information page I click Continue

# ====== Following the steps from 'Shared Step' 57570 ====== #
And I should see the Ingredients Page
When in the Ingredients page I click Continue
Then I should see the ingredients error message
And The ingredients error message should be showing: ALERT! The ingredient table does not include a compressed gas (Bag-On-Valve) or a propellant. Please update your ingredients to include the propellant before proceeding.
Then I add the following ingredients:
| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Butane        | 100     | false               | false       |            |
And in the Ingredients page I click Continue

# Regulatory Information 1 Page
And I should see the Regulatory Information 1 Page
And I set the U.S. Toxic Substances Control Act (TSCA) status option to: Compliant
And I set the Product, including container and/or packaging, contains a chemical on California's Prop 65 list option to: No
Then in the Regulatory Information 1 page I click Continue

# ====== Following the steps from 'Shared Step' 57506 ====== #
And I should see the Transportation Details 1 Page
And I set the Product is Regulated for Transport option to: Yes
And I set the below options for field: Select all modes of transport that you've classified the product for
| Option                   |
| IMDG                     |
| Shipping fully regulated |
And in the Transportation Details 1 page I click Continue

# ====== Following the steps from 'Shared Step' 57728 ====== #
Then I should see the International Marine (IMDG) Classification Page
And I set the UN Number field to: UN1950
And I set the Proper Shipping Name field to: Aerosols
And I set the Technical Name (if applicable) field to: My Safe Product
And I set the Hazard Class (select) field to: 2
And I set the Packing Group (select) field to: None
Given in the U. S. Department of Transportation (DOT) Classification page I click Continue

# ====== Following the steps from 'Shared Step' 57510 ====== #
Then In the 'Select Retailers' window I select the retailer: Walgreens
And I should see the Retailer Page
And in the Retailer page I click Continue

# ====== Following the steps from 'Shared Step' 57960 ====== #
And I should see the Universal Product Code (UPC) Page
Given I click the 'Add UPC' button
Then I add the following into the UPC Fields
| Field         | Value             |
| UPCNumber     | saved as UPC60774 |
| ContainerType | Aerosol Can       |
| Size          | 20                |
And in the Universal Product Code (UPC) page I click Continue

# Regulatory Documents to Provide Page
And I should see the Regulatory Documents to Provide Page
And I click the browse button for label: Product Label and upload PDF: C:\Dependencies\WERCSmart\testdoc.pdf
Then in the Regulatory Documents to Provide page I click Continue

# Additional Documents to Provide Page
And I should see the Additional Documents to Provide Page
Then in the Additional Documents to Provide page I click Continue

# Optional Reports and Documents Available for Purchase Page
And I should see the Optional Reports and Documents Available for Purchase Page
Then in the Optional Reports and Documents Available for Purchase page I click Continue

# ====== Following the steps from 'Shared Step' 57883 ====== #
And I should see the Comments Page
And I enter the following into the comments field: Comments Field Text
Given in the Comments page I click Continue

# ====== Following the steps from 'Shared Step' 42214 ====== #
Given I navigate to the home page
Then I delete the product: TestCase60774
