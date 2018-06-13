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
@run_Flow13

Feature: Flow 13


Scenario: [58753] Hair Color Kit - RU000724
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

# This just double checks that the account has been set up correctly - chances are this step won't be actioned
Given If I see the retail partners page I set all data consent tiers to true for all retailers in the top section
Then The home screen should load

#Create two products to go into the kit
Given I generate a random UPC number and save as: UPC58753Kit1
Given I delete all products with UPC Number: saved as UPC58753Kit1
Given I navigate to the home page
Given I generate a random UPC number and save as: UPC58753Kit2
Given I delete all products with UPC Number: saved as UPC58753Kit2

#####Kit item 1
Then I click the Register New Product icon in the Navigation Pane
And I Select the Create a New Registration radio button
And in the New Product page I click Continue
And In the Product Type tab of the New Product Page, I enter: KitItem1 in the Product Name text field
And In the Product Type tab of the New Product Page, I enter: Hair Color Remover in the Type of Product select field
And in the New Product page I click Continue
Then I save the product information as: TestCase58753Kit1

And I set the Primary Physical State to be: Liquid
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

# Setting Ingredient Information
Then I add the following ingredients:
| ComponentName     | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Hydrogen Peroxide | 100     | false               | false       |            |
Given in the New Product page I click Continue

#Regulatory Information 1
And in the Product Characteristics tab of the New Product Page, for U.S. Toxic Substances Control Act (TSCA) status I select: Compliant
And in the Product Characteristics tab of the New Product Page for Prop65 I select: No
And in the New Product page I click Continue
And I should see the Transportation Details 1 Page
And in the Product Characteristics tab of the New Product Page, for Product is Regulated for Transport I select: No, due to an exemption or exception
And in the Product Characteristics tab of the New Product Page, for DOT Exceptions I select: 173.120(b)(3): Combustible liquid that does not sustain combustion
Given in the New Product page I click Continue
And I should see the Transportation Details 2 Page
And In the Product Characteristics tab of the New Product Page, for International Shipping when DOT Exemption taken I select: I do not ship internationally and I do not know the classification
And in the New Product page I click Continue
Given the 'Select Retailers' window appears
Then In the 'Select Retailers' window I select the retailer: Target
And In the Retailers tab, I enter Private Label name as: Kit1
And in the New Product page I click Continue

#Enter UPC
Given I click the 'Add UPC' button
Then I add the following into the UPC Fields
| Field         | Value                 |
| UPCNumber     | saved as UPC58753Kit1 |
| ContainerType | Aerosol Can           |
| Size          | 20                    |
| DPCI          | 087-16-0238           |
And in the New Product page I click Continue
And I should see the Regulatory Documents to Provide Page
And in the Review and Submit tab of the New Product Page for OSHA compliant SDS I select: Request to author

Given in the New Product page I click Continue
Given in the New Product page I click Continue
Given in the New Product page I click Continue

#SaDS authoring - additional data
And I should see the Safety Data Sheet Authoring - Additional Data (Optional) Page
And in the Review and Submit tab of the New Product Page for Personal Protection Equipment Recommended I select: Gloves
And in the Review and Submit tab of the New Product Page for Autoignition I enter: 55
And in the Review and Submit tab of the New Product Page for Minimum Ignition Energy I enter: 55
And in the Review and Submit tab of the New Product Page for Viscosity I enter: 4.5
And in the Review and Submit tab of the New Product Page for Appearance I select: Buff
And in the Review and Submit tab of the New Product Page for Odor I select: Roasted soy
And in the Review and Submit tab of the New Product Page for Odor Threshold I select: No data available
And in the Review and Submit tab of the New Product Page for Partition Coefficient I enter: 5.5
Given in the New Product page I click Continue
Then the comments field should appear
And I enter the following into the comments field: Comments Field Text
Given in the New Product page I click Continue
Then The Data Acceptance page should appear
Given In the Data Acceptance page I select Yes, Agreed
Given In the Data Acceptance page I click on the Accept button
Then the Subscription Enrollment page should load
######## Kit item 2
Then I click the Register New Product icon in the Navigation Pane
And I Select the Create a New Registration radio button
And in the New Product page I click Continue
And In the Product Type tab of the New Product Page, I enter: KitItem2 in the Product Name text field
And In the Product Type tab of the New Product Page, I enter: Hair Color Remover in the Type of Product select field
And in the New Product page I click Continue
Then I save the product information as: TestCase58753Kit1

And I set the Primary Physical State to be: Liquid
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

# Setting Ingredient Information
Then I add the following ingredients:
| ComponentName     | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Hydrogen Peroxide | 100     | false               | false       |            |
Given in the New Product page I click Continue

#Regulatory Information 1
And in the Product Characteristics tab of the New Product Page, for U.S. Toxic Substances Control Act (TSCA) status I select: Compliant
And in the Product Characteristics tab of the New Product Page for Prop65 I select: No
And in the New Product page I click Continue
And I should see the Transportation Details 1 Page
And in the Product Characteristics tab of the New Product Page, for Product is Regulated for Transport I select: No, due to an exemption or exception
And in the Product Characteristics tab of the New Product Page, for DOT Exceptions I select: 173.120(b)(3): Combustible liquid that does not sustain combustion
Given in the New Product page I click Continue
And I should see the Transportation Details 2 Page
And In the Product Characteristics tab of the New Product Page, for International Shipping when DOT Exemption taken I select: I do not ship internationally and I do not know the classification
And in the New Product page I click Continue
Given the 'Select Retailers' window appears
Then In the 'Select Retailers' window I select the retailer: Target
And In the Retailers tab, I enter Private Label name as: Kit2
And in the New Product page I click Continue
#Enter UPC
Given I click the 'Add UPC' button
Then I add the following into the UPC Fields
| Field         | Value                 |
| UPCNumber     | saved as UPC58753Kit2 |
| ContainerType | Aerosol Can           |
| Size          | 20                    |
| DPCI          | 087-16-0238           |
And in the New Product page I click Continue
And I should see the Regulatory Documents to Provide Page
And in the Review and Submit tab of the New Product Page for OSHA compliant SDS I select: Request to author

Given in the New Product page I click Continue
Given in the New Product page I click Continue
Given in the New Product page I click Continue

#SaDS authoring - additional data
And I should see the Safety Data Sheet Authoring - Additional Data (Optional) Page
And in the Review and Submit tab of the New Product Page for Personal Protection Equipment Recommended I select: Gloves
And in the Review and Submit tab of the New Product Page for Autoignition I enter: 55
And in the Review and Submit tab of the New Product Page for Minimum Ignition Energy I enter: 55
And in the Review and Submit tab of the New Product Page for Viscosity I enter: 4.5
And in the Review and Submit tab of the New Product Page for Appearance I select: Buff
And in the Review and Submit tab of the New Product Page for Odor I select: Roasted soy
And in the Review and Submit tab of the New Product Page for Odor Threshold I select: No data available
And in the Review and Submit tab of the New Product Page for Partition Coefficient I enter: 5.5
Given in the New Product page I click Continue
Then the comments field should appear
And I enter the following into the comments field: Comments Field Text
Given in the New Product page I click Continue
Then The Data Acceptance page should appear
Given In the Data Acceptance page I select Yes, Agreed
Given In the Data Acceptance page I click on the Accept button
Then the Subscription Enrollment page should load
###### Creating the Kit
Then I click the Register New Product icon in the Navigation Pane
And I Select the Create a New Registration radio button
And in the New Product page I click Continue
And In the Product Type tab of the New Product Page, I enter: Hair Color Kit in the Product Name text field
And In the Product Type tab of the New Product Page, I enter: Hair Color Kit in the Type of Product select field
And in the New Product page I click Continue
Then I save the product information as: TestCase58753
And I should see the Additional Product Information Page
And In the Additional Information Page the check box for: United States should be: checked
And In the Additional Information Page for Product is retailers private label or brand I select: Yes
And In the Additional Information Page for Product is solely for the Retailer's use I select: Yes
And in the New Product page I click Continue
And in the Product Characteristics tab of the New Product Page, for U.S. Toxic Substances Control Act (TSCA) status I select: Compliant
And in the Product Characteristics tab of the New Product Page for Prop65 I select: No
And in the New Product page I click Continue
And I should see the Create the Kit Page
Given In the Create the Kit page I check the Product checkbox: true
Given In the Create the Kit page I select the following products
| Product                    |
| saved as TestCase58753Kit1 |
| saved as TestCase58753Kit2 |
