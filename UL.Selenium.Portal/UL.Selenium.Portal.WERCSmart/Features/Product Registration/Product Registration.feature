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
@run_ProductRegistration

Feature: Product Registration

#Background:
#Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
#Given If I see the retail partners page I set all data consent tiers to true for all retailers in the top section
#Then The home screen should load

@TReVorId:22077
Scenario: Create a new product
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Given If I see the retail partners page I set all data consent tiers to true for all retailers in the top section
Then The home screen should load
Then I click the Register New Product icon in the Navigation Pane
And I should see the header New Product
Given I click the Register New Product icon in the Navigation Pane
When I click continue

@TReVorId:22124
Scenario: [63705] New Product - BCP
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Given If I see the retail partners page I set all data consent tiers to true for all retailers in the top section
Then The home screen should load
Given I delete all products with UPC Number: 630509667031
And I click the Register New Product icon in the Navigation Pane
And I should see the header New Product
And I Select the Create a New Registration radio button
And in the New Product page I click Continue
And I set 'Product Name' to: Answering Machine, Battery Included
#And In the Product Type tab of the New Product Page, I enter: Answering Machine, Battery Included in the Type of Product select field
And I set 'Type of Product' to: Answering Machine, Battery Included
And in the New Product page I click Continue
Then I save the product information as: TestCase63705
# Shared step 63704
And I should see the Additional Product Information Page
And In the Additional Information Page the check box for: United States should be: checked
And I set 'Product is shipped directly' to: No
And I set 'Product is a Retailers Private Label or Brand' to: No
And I set 'Product is solely for the Retailer's use' to: No
And in the New Product page I click Continue
And For 'U.S. Toxic Substances Control Act (TSCA) status' I select: Compliant
And I set 'Prop65' to: No
And in the New Product page I click Continue
And I should see the Product Includes Battery Page
And For 'Indicate how battery is packaged' I select: The battery is shipped with but not included in my product.
And I add the following batteries:
| Battery Type | Manufacturer | Number of batteries per package | How many batteries required to run | Saved As |
| Lithium Ion  | <any>          | 4                               | 4                                  | battery1 |
| Alkaline     | <any>          | 6                               | 6                                  | battery2 |
And in the New Product page I click Continue
And I should see the Toxicity Characteristic Leaching Procedure (TCLP) Page
And I set 'Product has had TCLP; Report is available' to: No
And I set all the metal presence value to: No
And in the New Product page I click Continue
And I should see the Electronic Equipment Page
And I set 'Contains Circuit Board' to: No
And I set 'Has a LCD or Plasma Display' to: No
And in the New Product page I click Continue

#################### Coralie 11/4/2018: Adding in Lithium Battery Transportation section to test
##Assume this screen is appearing because of selecting a Lithium type battery
And I should see the Lithium Battery Transportation Page
And I set 'DOT' to: Fully-regulated dangerous goods: UN3481, Lithium ion batteries packed with equipment, 9
And I set 'IMDG' to: None of the above/Not intended for shipment under IMDG
And I set 'IATA' to: Section II
And I set 'TDG' to: Meets the requirements of TDG special provision 34 to be transported as non-dangerous goods.
And in the New Product page I click Continue


#################### Coralie 11/4/2018: Clicking add a retailer step no longer necessary because it automatically opens on clicking continue
#Select any retailer except for O'Reilly, Sears/K-Mart or Wal-Mart/SAM's CLUB because choosing any of these retailers will cause the Select Vendor drop down to display
Given the 'Select Retailers' window appears
Then In the 'Select Retailers' window I select the retailer: Target
And in the New Product page I click Continue
Given I click the 'Add UPC' button
Then I add the following into the UPC Fields
| Field         | Value        |
| UPCNumber     | 630509667031 |
| ContainerType | Aerosol Can  |
| Size          | 20           |
| DPCI          | 087-16-0238  |
| Quantity      |              |
Given in the New Product page I click Continue

Then the comments field should appear
And I enter the following into the comments field: Comments Field Text
Given in the New Product page I click Continue
Then The Data Acceptance page should appear
Given I click the Summary button in the Data Acceptance window
Then I switch to the Data Summary page
And I should see the following batteries present:
| BatteryType | Manufacturer | NumberPerPackage | RequiredToRun | Saved As |
| Lithium Ion | saved as     | 4                | 4             | battery1 |
| Alkaline    | saved as     | 6                | 6             | battery2 |
Then I close the Data Summary tab
Given I navigate to the home page
Then I delete the product: TestCase63705

@TReVorId:22125
Scenario: [63724] Add New product - Single Battery Product
# UPC: 630509616084
# DPCI: 087-06-680
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Given If I see the retail partners page I set all data consent tiers to true for all retailers in the top section
Then The home screen should load
Given I delete all products with UPC Number: 012345678905
And I click the Register New Product icon in the Navigation Pane
And I should see the header New Product
And I Select the Create a New Registration radio button
And in the New Product page I click Continue
And I set 'Product Name' to: Nickel Metal Hydride (NiMH) Battery
#And In the Product Type tab of the New Product Page, I enter: Nickel Metal Hydride (NiMH) Battery in the Type of Product select field
And I set 'Type of Product' to: Nickel Metal Hydride (NiMH) Battery
And in the New Product page I click Continue
Then I save the product information as: TestCase63724
# Setting Product Characteristics
And I should only see the following options for Primary Physical State:
| State |
| Solid |
And I set the Secondary Physical State to be: Granular
And I set the water mixture question to: Yes
Given in the New Product page I click Continue
# Setting Additional Product Information
And I should see the Additional Product Information Page
And In the Additional Information Page the check box for: United States should be: checked
And I set 'Product has been classified using OSHA' to: No
And I set 'Product is shipped directly' to: No
And I set 'Product is a Retailers Private Label or Brand' to: No
And I set 'Product is solely for the Retailer's use' to: No
Given in the New Product page I click Continue
# Setting Ingredient Information
Then I add the following ingredients:
| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Formaldehyde  | 100     | false               | false       |            |
Given in the New Product page I click Continue
And For 'U.S. Toxic Substances Control Act (TSCA) status' I select: Compliant
And I set 'Prop65' to: No
And in the New Product page I click Continue
Given the 'Select Retailers' window appears
Then In the 'Select Retailers' window I select the retailer: Target
And in the New Product page I click Continue
Given I click the 'Add UPC' button
Then I add the following into the UPC Fields
| Field         | Value        |
| UPCNumber     | 012345678905 |
| ContainerType | Aerosol Can  |
| Size          | 20           |
| DPCI          | 087-16-0238  |
| Quantity      | 12           |
#Regulatory Documents to Provide - US only _ request authoring - Happy Path
Given in the New Product page I click Continue
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
Given I navigate to the home page
Then I delete the product: TestCase63724

@TReVorId:11276
Scenario: [65441] Delete a UPC from the UPC Grid
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Given If I see the retail partners page I set all data consent tiers to true for all retailers in the top section
Then The home screen should load
Given I generate a random UPC number and save as: UPC65441
Given I delete all products with UPC Number: saved as UPC65441
And I click the Register New Product icon in the Navigation Pane
And I should see the header New Product
And I Select the Create a New Registration radio button
And in the New Product page I click Continue
And I set 'Product Name' to: abrasive
#And In the Product Type tab of the New Product Page, I enter: Abrasive in the Type of Product select field
And I set 'Type of Product' to: Abrasive
And in the New Product page I click Continue
Then I save the product information as: TestCase65441
And I set the Primary Physical State to be: Solid
And I set the Secondary Physical State to be: Granular
And I set the water mixture question to: Yes
And I set the water solubility description to: Completely soluble
Given in the New Product page I click Continue
# Setting Additional Product Information
And I should see the Additional Product Information Page
And In the Additional Information Page the check box for: United States should be: checked
And I set 'Product has been classified using OSHA' to: No
And I set 'Product is shipped directly' to: No
And I set 'Product is a Retailers Private Label or Brand' to: No
And I set 'Product is solely for the Retailer's use' to: No
Given in the New Product page I click Continue
#Enter ingredients
Then I add the following ingredients:
| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Formaldehyde  | 100     | false               | false       |            |
Given in the New Product page I click Continue
#Enter regulatory information - not prop 65
And For 'U.S. Toxic Substances Control Act (TSCA) status' I select: Compliant
And I set 'Prop65' to: No
And in the New Product page I click Continue

#Transportation details 1 - not regulated - continue - happy path
And I should see the Transportation Details 1 Page
And in the Product Characteristics tab of the New Product Page, for Product is Regulated for Transport I select: Not Regulated
#And in the Product Characteristics tab of the New Product Page, for DOT Exceptions I select: 173.120(a)(2), 173.120(a)(3)
#And I set the Other DOT Exception field to: None
And in the New Product page I click Continue

#Retailer association - select a retailer - continue-happy path
Given the 'Select Retailers' window appears
Then In the 'Select Retailers' window I select the retailer: Target
And in the New Product page I click Continue

#Enter UPC
Given I click the 'Add UPC' button
Then I add the following into the UPC Fields
| Field         | Value             |
| UPCNumber     | saved as UPC65441 |
| ContainerType | Aerosol Can       |
| Size          | 20                |
| DPCI          | 087-16-0238       |
And in the New Product page I click Continue

#Navigate back to UPC screen by click the reipient and upc details tab in the header
Given In the New Product page I click tab: Recipient and UPC Details
Given I click the page heading: Universal Product Code (UPC)
And I should see the Universal Product Code Page
And I delete UPC: saved as UPC65441
Then In the list of UPCs I should not see UPC: saved as UPC65441
#delete product
Given I navigate to the home page
Then I delete the product: TestCase65441

@TReVorId:11378
Scenario: [65392] Ecologo Readiness - Question wording and validation of response
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Given If I see the retail partners page I set all data consent tiers to true for all retailers in the top section
Then The home screen should load
And I click the Register New Product icon in the Navigation Pane
And I should see the header New Product
And I Select the Create a New Registration radio button
And in the New Product page I click Continue
And I set 'Product Name' to: Floor wax stripper
And I set 'Type of Product' to: Floor Wax Stripper (Light or Medium Build-Up)
And in the New Product page I click Continue
Then I save the product information as: TestCase65392
And I call Shared Step 57514 (Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path)
Given I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
Then I add the following ingredients:
| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Formaldehyde  | 100     | false               | false       |            |
Given in the New Product page I click Continue
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Given I call Shared Step 62710 (Confirm VOC OTC/CARB heading and select No to FIRST QUESTION ONLY - Happy Path)
Given I set the Does the product label specify a dilution ratio option to: Yes
Given I set the Enter the product's VOC content as sold option to: 1
Given I set the Enter the "as used" VOC content option to: 1
Given I click continue
Given I click continue
And I should see the ECOLOGO Readiness Page
And I confirm that I see the following Ecologo statement: Take advantage of Premium Subscription benefits by electing to receive a UL ECOLOGO Readiness Assessment. This report will indicate if the product is eligible to be awarded an ECOLOGO Certification, an established symbol of reduced environmental impact. Would you like to receive this assessment?
And I should see the following radio buttons:
| Button                             |
| Yes          |
| Not at this time |
And in the New Product page I click Continue
Then I should see an error message: This is a required field.
# select Yes
#click continue
#no error
# retailer page 29206
Given I navigate to the home page
Then I delete the product: TestCase65392

@tfs_design
Scenario: [67661] Verify Canada SDS on the Optional Reports and Documents Available for Purchase screen
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

# Checking that the test will run correctly by handling extra screens / removing existing products
Given If I see the retail partners page I set all data consent tiers to true for all retailers in the top section
Then The home screen should load
Given I generate a random UPC number and save as: UPC67661
Given I delete all products with UPC Number: saved as UPC67661

# New Product Page
And I click the Register New Product icon in the Navigation Pane
And I should see the New Product Page
And I set the Select the type of product to create option to: Create a New Registration
And in the New Product page I click Continue

# The Product Page
And I should see the The Product Page
And I set the Product Name option to: Deodorant - Non-aerosol
#And In the Product Type tab of the New Product Page, I enter: Deodorant - Non-aerosol in the Type of Product select field
And I set 'Type of Product' to: Deodorant - Non-aerosol
And in the New Product page I click Continue
# Product Characteristics Page
And I should see the Product Characteristics Page
Then I save the product information as: TestCase67661
And in the New Product page I click Continue
And Primary Physical State should be showing the error messages: This is a required field.
And I set the Primary Physical State option to: Solid
And I set the Secondary Physical State option to: Solid
And I set the When mixed with an equal amount of water option to: No
And I set the Select the best Water Solubility description option to: Very soluble
And in the New Product page I click Continue

# Additional Product Information Page
And In the Additional Information Page the check box for: United States should be: checked
And I set the Product has been classified using OSHA (US) option to: No
And I set the Product is shipped directly by supplier to the consumer option to: No
And I set the Product is a Retailer's Private Label or Brand option to: No
And I set the Product is sold to the Retailer solely for the Retailer's use option to: No
And in the New Product page I click Continue

# Ingredients Page
And I should see the Ingredients Page
Then I add the following ingredients:
| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Formaldehyde  | 100     | false               | false       |            |
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
| Option                         |
| DOT                            |
| Shipping with limited quantity |
Given in the New Product page I click Continue

# U. S. Department of Transportation (DOT) Classification Page
Then I should see the U. S. Department of Transportation (DOT) Classification Page
And I set the UN Number field to: UN1944
And I set the Proper Shipping Name field to: Matches, safety
And I set the Technical Name (if applicable) field to: My Safe Product
And I set the Hazard Class (select) field to: 4.1
And I set the Packing Group (select) field to: III
Given in the New Product page I click Continue

# Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB) Page
Then I should see the Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB) Page
And I set the Product has been granted an Alternative Control Plan option to: No
And I set the HVOC (high volatile organic compound) content field to: 200
And I set the MVOC (microbial volatile organic compound) content field to: 200
Given in the New Product page I click Continue

# Volatile Organic Compound Summary Page
Then I should see the Volatile Organic Compound Summary Page
Given in the New Product page I click Continue

# Retailers Page
Then In the 'Select Retailers' window I select the retailer: Walgreens
And I should see the Retailer Page
Given in the New Product page I click Continue

# Universal Product Code (UPC) Page
And I should see the Universal Product Code (UPC) Page
Given I click the 'Add UPC' button
Then I add the following into the UPC Fields
| Field         | Value             |
| UPCNumber     | saved as UPC67661 |
| ContainerType | Glass Container   |
| Size          | 20                |
And in the New Product page I click Continue

# Regulatory Documents to Provide
And I should see the Regulatory Documents to Provide Page
And I set the OSHA-compliant Safety Data Sheet, English field to: Request to author
Then in the New Product page I click Continue

# Additional Documents to Provide Page
And I should see the Additional Documents to Provide Page
And I click the browse button for label: Product Label and upload PDF: C:\Dependencies\WERCSmart\testdoc.pdf
Then in the New Product page I click Continue

# Optional Reports and Documents Available for Purchase Page
And I should see the Optional Reports and Documents Available for Purchase Page
And I purchase the following additional documents:
| Document Name  | Language      |
| Canada GHS SDS | English (U.S) |
Then in the New Product page I click Continue

# Additional Documents -> Contact Information Page
And I should see the Additional Documents -> Contact Information Page
And I set the Manufacturer Name field to: Manufacturer
And I set the Address field to: Address
And I set the Phone field to: Phone
And I set the Emergency Phone field to: EmergencyPhone
Then in the New Product page I click Continue

# Safety Data Sheet Authoring - Additional Data (Optional) Page
And I should see the Safety Data Sheet Authoring - Additional Data (Optional) Page
And I set the below options for field: Personal Protection Equipment Recommended
| Option                         |
| Mask                           |
And I set the Autoignition Temperature (°C) field to: 20
And I set the Minimum Ignition Energy (mJ) field to: 20
And I set the Viscosity field to: 20
And I set the Appearance field to: Brown
And I set the Odor field to: Banana
And I set the Odor Threshold field to: Not applicable
And I set the Partition Coefficient field to: 20
Then in the New Product page I click Continue

# Optional Reports and Documents Available for Purchase Page
Then I click the page heading: Optional Reports and Documents Available for Purchase
And the following additional documents should be showing as selected:
| Document Name  | Language      |
| Canada GHS SDS | English (U.S) |

# Delete the prodiuct created to cleanup
Given I navigate to the home page
Then I delete the product: TestCase67661
