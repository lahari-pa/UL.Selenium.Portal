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
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

# This just double checks that the account has been set up correctly - chances are this step won't be actioned
Given If I see the retail partners page I set all data consent tiers to true for all retailers in the top section
Then The home screen should load
Given I generate a random UPC number and save as: UPC60774
Given I delete all products with UPC Number: saved as UPC60774
Then I click the Register New Product icon in the Navigation Pane
And I Select the Create a New Registration radio button
And in the New Product page I click Continue
And In the Product Type tab of the New Product Page, I enter: Food Item Dispensed by Compressed Gas - Dairy Topping in the Product Name text field
And In the Product Type tab of the New Product Page, I enter: Food Item Dispensed by Compressed Gas - Dairy Topping in the Type of Product select field
And in the New Product page I click Continue
Then I save the product information as: TestCase60774

# Product Characteristics Page
And I should see the Product Characteristics Page
And Primary Physical State should be showing the value: Product is packaged in a gas cylinder (e.g., whip cream)
And I set the Secondary Physical State option to: Liquid
And I set the Specific Gravity field to: 20
And I set the pH field to: 7 (Neutral)
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
Then I add the following ingredients:
| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Nitrogen      | 100     | false               | false       |            | 
And in the Ingredients page I click Continue

# Regulatory Information 1 Page
And I should see the Regulatory Information 1 Page
And I set the U.S. Toxic Substances Control Act (TSCA) status option to: Compliant
And I set the Product, including container and/or packaging, contains a chemical on California's Prop 65 list option to: No
Then in the Regulatory Information 1 page I click Continue

# ====== NB: The below does not currently show - awaiting confirmation! ====== #

# Regulatory Information 3 Page
And I should see the Regulatory Information 3 Page
And I set the Refer to your Product Label. From the options, select those that appear on the Label. option to: None of the Above
Then in the Regulatory Information 3 page I click Continue

# ====== Following the steps from 'Shared Step' 57506 ====== #
And I should see the Transportation Details 1 Page
And I set the Product is Regulated for Transport option to: No, due to an exemption or exception
And I set the below options for field: Please select DOT Exceptions if applicable?
| Option         |
| 173.120(a)(2): |
| 173.120(a)(3): |
And in the New Product page I click Continue

# ====== Following the steps from 'Shared Step' 57510 ====== #
Then In the 'Select Retailers' window I select the retailer: Walgreens
And I should see the Retailer Page
And in the Retailer page I click Continue

# ====== Following the steps from 'Shared Step' 57960 ====== #
And I should see the Universal Product Code (UPC) Page
Given I click the 'Add UPC' button
Then I add the following into the UPC Fields
| Field         | Value             |
| UPCNumber     | saved as UPC60694 |
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
