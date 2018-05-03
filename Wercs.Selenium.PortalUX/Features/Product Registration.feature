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

Scenario: [31343] New Product screen navigation
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Given If I see the retail partners page I set all data consent tiers to true for all retailers in the top section
Then The home screen should load
Then I click the Register New Product icon in the Navigation Pane
And I should see the header New Product
And I should see the following radio buttons:
| Button                             |
| Create a New Registration          |
| Copy from an Existing Registration |


#Old version of this test. Changed 6/2/2018
#| Yes, create a new product    |
#| No, copy an existing product |
#| No, copy from ULSC service   |

Scenario: [31344] New Product Screen validation
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Given If I see the retail partners page I set all data consent tiers to true for all retailers in the top section
Then The home screen should load
Given I click the Register New Product icon in the Navigation Pane
When I click continue
Then I should see an error message: This is a required field.

Scenario: Create a new product
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Given If I see the retail partners page I set all data consent tiers to true for all retailers in the top section
Then The home screen should load
Then I click the Register New Product icon in the Navigation Pane
And I should see the header New Product
Given I click the Register New Product icon in the Navigation Pane
When I click continue

Scenario: [63705] New Product - BCP
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Given If I see the retail partners page I set all data consent tiers to true for all retailers in the top section
Then The home screen should load
Given I delete all products with UPC Number: 012345678905
And I click the Register New Product icon in the Navigation Pane
And I should see the header New Product
And I Select the Create a New Registration radio button
And in the New Product page I click Continue
And In the Product Type tab of the New Product Page, I enter: Answering Machine, Battery Included in the Product Name text field
And In the Product Type tab of the New Product Page, I enter: Answering Machine, Battery Included in the Type of Product select field
And in the New Product page I click Continue
Then I save the product information as: TestCase63705
And I should see the Additional Product Information Page
And In the Additional Information Page the check box for: United States should be: checked
And In the Additional Information Page for Product is shipped directly I select: No
And In the Additional Information Page for Product is retailers private label or brand I select: No
And In the Additional Information Page for Product is solely for the Retailer's use I select: No
And in the New Product page I click Continue
And in the Product Characteristics tab of the New Product Page, for U.S. Toxic Substances Control Act (TSCA) status I select: Compliant
And in the Product Characteristics tab of the New Product Page for Prop65 I select: No
And in the New Product page I click Continue
And I should see the Product Includes Battery Page
And in the Product Characteristics tab of the New Product Page, for Indicate how battery is packaged I select: The battery is shipped with but not included in my product.
And in the Product Characteristics tab of the New Product Page I add the following batteries:
| Battery Type | Manufacturer | Number of batteries per package | How many batteries required to run |
| Alkaline     | L1028F       | 6                               | 6                                  |
| Lithium Ion  | 10400        | 4                               | 4                                  |
And in the New Product page I click Continue
And I should see the Toxicity Characteristic Leaching Procedure (TCLP) Page
And In the Toxicity Characteristics Leaching Procedure page for Product has had TCLP; Report is available I select: No
And I set all the metal presence value to: No
And in the New Product page I click Continue
And I should see the Electronic Equipment Page
And in the Product Characteristics tab of the New Product Page for Contains Circuit Board I select: No
And in the Product Characteristics tab of the New Product Page for Has a LCD or Plasma Display I select: No
And in the New Product page I click Continue

#################### Coralie 11/4/2018: Adding in Lithium Battery Transportation section to test
##Assume this screen is appearing because of selecting a Lithium type battery
And I should see the Lithium Battery Transportation Page
And in the Product Characteristics tab of the New Product Page for DOT I select: Fully-regulated dangerous goods: UN3481, Lithium ion batteries packed with equipment, 9
And in the Product Characteristics tab of the New Product Page for IMDG I select: None of the above/Not intended for shipment under IMDG
And in the Product Characteristics tab of the New Product Page for IATA I select: Section II
And in the Product Characteristics tab of the New Product Page for TDG I select: Meets the requirements of TDG special provision 34 to be transported as non-dangerous goods.
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
| BatteryType | Manufacturer                                                                                                                     | NumberPerPackage | RequiredToRun |
| Lithium Ion | TL-PB10400 by TP-LINK USA Corporation                                                                                            | 4                | 4             |
| Alkaline    | Alkaline Manganese Button Cell Mercury Free Battery L1028F\L828F\L1325F\L1345F\L1335F\L1315F\L10 by Chung Pak Battery Works Ltd. | 6                | 6             |
Then I close the Data Summary tab
Given I navigate to the home page
Then I delete the product: TestCase63705

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
And In the Product Type tab of the New Product Page, I enter: Nickel Metal Hydride (NiMH) Battery in the Product Name text field
And In the Product Type tab of the New Product Page, I enter: Nickel Metal Hydride (NiMH) Battery in the Type of Product select field
And in the New Product page I click Continue
Then I save the product information as: TestCase63724
# Setting Product Characteristics
And I should only see the following options for Primary Physical State:
| State |
| Solid |
And I set the Secondary Physical State to be: Granular
And I set the water mixture question to: Yes
Given in the New Product page I click Continue
# Setting Additional Prodiuct Information
And I should see the Additional Product Information Page
And In the Additional Information Page the check box for: United States should be: checked
And In the Additional Information Page for Product has been classified using OSHA I select: No
And In the Additional Information Page for Product is shipped directly I select: No
And In the Additional Information Page for Product is retailers private label or brand I select: No
And In the Additional Information Page for Product is solely for the Retailer's use I select: No
Given in the New Product page I click Continue
# Setting Ingredient Information
Then I add the following ingredients:
| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Formaldehyde  | 100     | false               | false       |            |
Given in the New Product page I click Continue
And in the Product Characteristics tab of the New Product Page, for U.S. Toxic Substances Control Act (TSCA) status I select: Compliant
And in the Product Characteristics tab of the New Product Page for Prop65 I select: No
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
And In the Product Type tab of the New Product Page, I enter: abrasive in the Product Name text field
And In the Product Type tab of the New Product Page, I enter: Abrasive in the Type of Product select field
And in the New Product page I click Continue
Then I save the product information as: TestCase65441
And I set the Primary Physical State to be: Solid
And I set the Secondary Physical State to be: Granular
And I set the water mixture question to: Yes
And I set the water solubility description to: Completely soluble
Given in the New Product page I click Continue
# Setting Additional Prodiuct Information
And I should see the Additional Product Information Page
And In the Additional Information Page the check box for: United States should be: checked
And In the Additional Information Page for Product has been classified using OSHA I select: No
And In the Additional Information Page for Product is shipped directly I select: No
And In the Additional Information Page for Product is retailers private label or brand I select: No
And In the Additional Information Page for Product is solely for the Retailer's use I select: No
Given in the New Product page I click Continue
#Enter ingredients
Then I add the following ingredients:
| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Formaldehyde  | 100     | false               | false       |            |
Given in the New Product page I click Continue
#Enter regulatory information - not prop 65
And in the Product Characteristics tab of the New Product Page, for U.S. Toxic Substances Control Act (TSCA) status I select: Compliant
And in the Product Characteristics tab of the New Product Page for Prop65 I select: No
And in the New Product page I click Continue

#Transportation details 1 - not regulated - continue - happy path
And I should see the Transportation Details 1 Page
And in the Product Characteristics tab of the New Product Page, for Product is Regulated for Transport I select: Not Regulated
#And in the Product Characteristics tab of the New Product Page, for DOT Exceptions I select: 173.120(a)(2), 173.120(a)(3)
#And in the Product Characteristics tab of the New Product Page, for Other DOT Exception I select: None
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
Given in the New Product page I click section: Universal Product Code
And I should see the Universal Product Code Page
And I delete UPC: saved as UPC65441
Then In the list of UPCs I should not see UPC: saved as UPC65441
#delete product
Given I navigate to the home page
Then I delete the product: TestCase65441



Scenario: [63684] Walmart Private label product
# UPC: 0728990015025
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Given If I see the retail partners page I set all data consent tiers to true for all retailers in the top section
Then The home screen should load
Given I delete all products with UPC Number: 0728990015025
And I click the Register New Product icon in the Navigation Pane
And I should see the header New Product
And I Select the Create a New Registration radio button
And in the New Product page I click Continue
And In the Product Type tab of the New Product Page, I enter: Pet shampoo in the Product Name text field
And In the Product Type tab of the New Product Page, I enter: Pet shampoo in the Type of Product select field
And in the New Product page I click Continue
#Then I save the product information as: TestCase63684

# Setting Product Characteristics
And I should only see the following options for Primary Physical State:
| State |
| Liquid |

And I set the Secondary Physical State to be: Liquid
And In the Product Characteristics tab, I enter: 2 in the Specific Gravity text field
And In the product Characteristics tab, I enter: 2 in the pH text field
And In the product Characteristics tab, I enter: 2 in the Boiling point (in Celsius) text field
And In the product Characteristics tab, I enter: 2 in the Flash point (in Celsius) text field
And in the Product Characteristics tab, for Flash Point Testing Method Used status I select: Closed cup method
And I set the Select the best Water Solubility description to be: Very soluble
And in the New Product page I click Continue
And I should see the Additional Product Information Page
And In the Additional Information Page the check box for: United States should be: checked
And In the Additional Information Page for Product has been classified using OSHA I select: No
And In the Additional Information Page for Product is shipped directly I select: No
And In the Additional Information Page for Product is retailers private label or brand I select: Yes
And In the Additional Information Page for Product is solely for the Retailer's use I select: No
And in the New Product page I click Continue
# Setting Ingredient Information
Then I add the following ingredients:
| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Formaldehyde  | 100     | false               | false       |            |
Given in the New Product page I click Continue
And in the Product Characteristics tab of the New Product Page, for U.S. Toxic Substances Control Act (TSCA) status I select: Compliant
And in the Product Characteristics tab of the New Product Page for Prop65 I select: No
And in the New Product page I click Continue
And In the Regulatory Inforamtion tab, I select Product Lable as: None of the Above
And in the New Product page I click Continue
Given the 'Select Retailers' window appears
Then In the 'Select Retailers' window I select the retailer: Wal-Mart/SAM'S CLUB
And In the Retailers tab, I select Private Label name as: Holiday Time
And In the Retailers tab, I select Vendor id as: test
And in the New Product page I click Continue
Given I click the 'Add UPC' button
Then I add the following into the UPC Fields
| Field         | Value        |
| UPCNumber     | 0728990015025 |
| ContainerType | Aerosol Can  |
| Size          | 20           |
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
Then The Data Acceptance page should appear
Given I click the Summary button in the Data Acceptance window
Then I switch to the Data Summary page
And I confirm that I see the following option for private label question: Yes
#Given I navigate to the home page


Scenario: [65392] Ecologo Readiness - Question wording and validation of response
Given I Login into WERCSmart Portal - Admin Role - WERCs Premium Subscription Account
Given If I see the retail partners page I set all data consent tiers to true for all retailers in the top section
Then The home screen should load
And I click the Register New Product icon in the Navigation Pane
And I should see the header New Product
And I Select the Create a New Registration radio button
And in the New Product page I click Continue
And In the Product Type tab of the New Product Page, I enter: Laundry, Detergent in the Product Name text field
And In the Product Type tab of the New Product Page, I enter: Laundry, Detergent in the Type of Product select field
And in the New Product page I click Continue
Then I save the product information as: TestCase65392
And I set the Primary Physical State to be: Liquid
And I set the Secondary Physical State to be: Liquid
And In the Product Characteristics tab, I enter: 2 in the Specific Gravity text field
And In the product Characteristics tab, I enter: 2 in the pH text field
And In the product Characteristics tab, I enter: 2 in the Boiling point (in Celsius) text field
And In the product Characteristics tab, I enter: 2 in the Flash point (in Celsius) text field
And in the Product Characteristics tab, for Flash Point Testing Method Used status I select: Closed cup method
And I set the Select the best Water Solubility description to be: Very soluble
And in the New Product page I click Continue
And I should see the Additional Product Information Page
And In the Additional Information Page the check box for: United States should be: checked
And In the Additional Information Page for Product has been classified using OSHA I select: No
And In the Additional Information Page for Product is shipped directly I select: No
And In the Additional Information Page for Product is retailers private label or brand I select: No
And In the Additional Information Page for Product is solely for the Retailer's use I select: No
And in the New Product page I click Continue
# Setting Ingredient Information
Then I add the following ingredients:
| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Formaldehyde  | 100     | false               | false       |            |
Given in the New Product page I click Continue
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
And I should see the ECOLOGO Readiness Page
And I confirm that I see the following Ecologo statement: Take advantage of Premium Subscription benefits by electing to receive a UL ECOLOGO Readiness Assessment. This report will indicate if the product is eligible to be awarded an ECOLOGO Certification, an established symbol of reduced environmental impact. Would you like to receive this assessment?
And I should see the following radio buttons:
| Button                             |
| Yes          |
| Not at this time |
And in the New Product page I click Continue
Then I should see an error message: This is a required field.
Given I navigate to the home page
Then I delete the product: TestCase65392

Scenario: [63663] Obsoleting/Deleting a Product (not submitted status)
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Given If I see the retail partners page I set all data consent tiers to true for all retailers in the top section
Then The home screen should load
Then I click the Register New Product icon in the Navigation Pane
And I Select the Create a New Registration radio button
And in the New Product page I click Continue
And In the Product Type tab of the New Product Page, I enter: Soap63663 in the Product Name text field
And In the Product Type tab of the New Product Page, I enter: Soap (Bar, Liquid) for Body in the Type of Product select field
And in the New Product page I click Continue
Then I save the product information as: TestCase63663
And I set the Primary Physical State to be: Solid
And I set the Secondary Physical State to be: Solid
And I set the When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5? option to: No
And I set the Select the best Water Solubility description to be: Very soluble
And in the New Product page I click Continue
Given I navigate to the home page
Then I delete the product: TestCase63663

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
And In the Review and Submit tab of the New Product Page for Volatile Organic Compounds I upload pdf file
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

Scenario: [56484] VOC - Aero checks
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Given If I see the retail partners page I set all data consent tiers to true for all retailers in the top section
Then The home screen should load
And I click the Register New Product icon in the Navigation Pane
And I should see the header New Product
And I Select the Create a New Registration radio button
And in the New Product page I click Continue
And In the Product Type tab of the New Product Page, I enter: Clear Coating - Aerosol in the Product Name text field
And In the Product Type tab of the New Product Page, I enter: Clear Coating - Aerosol in the Type of Product select field
And in the New Product page I click Continue
Then I save the product information as: TestCase56484
And I should only see the following options for Primary Physical State:
| State |
| Aerosol |
And I set the Secondary Physical State to be: Solid spray
And In the product Characteristics tab, I enter: 2 in the pH text field
And I set the Select the best Water Solubility description to be: Very soluble
And In the Product Characteristics tab of the New Product Page, for When the product has a flammable propellant I select: This product is not classified as D001 or D003 Hazardous Waste under RCRA
And in the New Product page I click Continue
And I should see the Additional Product Information Page
And In the Additional Information Page the check box for: United States should be: checked
And In the Additional Information Page for Product has been classified using OSHA I select: No
And In the Additional Information Page for Product is shipped directly I select: No
And In the Additional Information Page for Product is retailers private label or brand I select: No
And In the Additional Information Page for Product is solely for the Retailer's use I select: No
And in the New Product page I click Continue
# Setting Ingredient Information
Then I add the following ingredients:
| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Butane  | 100     | false               | false       |            |
Given in the New Product page I click Continue
And I should see the Regulatory Information 1 Page
And in the Product Characteristics tab of the New Product Page, for U.S. Toxic Substances Control Act (TSCA) status I select: Compliant
And in the Product Characteristics tab of the New Product Page for Prop65 I select: No
And in the New Product page I click Continue
And in the Product Characteristics tab of the New Product Page, for Product is Regulated for Transport I select: Yes
And in the Product Characteristics tab of the New Product Page, for Select all modes of transport I select: DOT
And in the Product Characteristics tab of the New Product Page, for Select all modes of transport I select: Shipping with limited quantity
And in the Product Characteristics tab of the New Product Page, for Select all modes of transport I select: Shipping with consumer commodity
And in the New Product page I click Continue
And I should see the U. S. Department of Transportation (DOT) Classification Page
And In the product Characteristics tab, I enter: UN1950 in the UN Number text field
And in the New Product page I click Continue
Then I should see an error message: This is a required field.
And In the product Characteristics tab, I set the Proper Shipping Name to be: Aerosols
And In the product Characteristics tab, I enter: test in the Technical Name text field
And In the product Characteristics tab, I set Hazard Class to be: 2.1
And In the product Characteristics tab, I set Packing Group to be: None
And in the New Product page I click Continue
And I should see the Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB) Page
And I confirm that I see the following VOC-OTC-CARB statement1: Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations.
And I confirm that I see the following VOC-OTC-CARB statement3: VOC content in grams ozone per gram
And In the VOC - OTC - CARB tab for Product has been granted an Alternative Control Plan I select: No
And in the New Product page I click Continue
And I confirm that I see the following error message for VOC content in grams ozone per gram: This is a required field.
And In the product Characteristics tab, I enter: 0.5 in the VOC content in grams ozone per gram text field
And in the New Product page I click Continue
And I should see the Volatile Organic Compound Summary Page







