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
# Setting Additional Product Information
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
# Setting Additional Product Information
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
Given in the New Product page I click section: Universal Product Code (UPC)
And I should see the Universal Product Code Page
And I delete UPC: saved as UPC65441
Then In the list of UPCs I should not see UPC: saved as UPC65441
#delete product
Given I navigate to the home page
Then I delete the product: TestCase65441



Scenario: [63684] Walmart Private label product
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Given If I see the retail partners page I set all data consent tiers to true for all retailers in the top section
Then The home screen should load

# ====== Test Setup - Generating + Saving UPC Number and ensuring no duplicates exist ====== #
Given I generate a random UPC number and save as: UPC63684
Given I delete all products with UPC Number: saved as UPC63684

Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)

Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Pet shampoo

Then I save the product information as: TestCase63684

Given I call Shared Step 73629 (Product Characteristics - Liquid - select any options(enter pH, boiling point, flash point))
| Secondary Physical State | Specific Gravity | pH      | Boiling Point (in Celsius) | Flash Point (in Celsius) | Flash Point Testing Method Used     | Select the best Water Solubility description |
| Liquid                   | 2                | 2       | 2                          | 66                       | Closed cup method                   | Appreciable                                  |


Given I call Shared Step 63804 (Additional Product Information with Yes to Private Label )
| Classified using OSHA (US) Globally Harmonized Standards (GHS) | Shipped directly by supplier | Private Label or Brand | Good Not for resale |
| No                                                             | No                            | Yes                         | No                         |

Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Cocoa butter  | 100     | false               | false       |            |

Given I call Shared 57571 (Enter Regulatory Information - Not Prop 65)

Given I call Shared 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path

Given I call Shared 65181 (Retailer Association - Add Private Label Information and Select Vendor ID) and select the retailer: Wal-Mart/SAM'S CLUB and enter the name: Holiday Time and select Vendor id: test

Given I call Shared 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC63684, container type: Plastic Container and size: 3.6

Given I call Shared 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)

Given in the Additional Documents to Provide page I click Continue

Given in the Optional Reports and Documents Available for Purchase page I click Continue

Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient |
| Apron                         | 550                      | 63.625                  | 33.333    | Brown      | Banana | No data available | 30                    |

Given I call Shared 57883 (Comments - Happy Path) and enter the comment: User added Comments Text 58079. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)

Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Pet shampoo

Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase63684


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
And I set the Product, including container and/or packaging, contains a chemical on California's Prop 65 list option to: No
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
And I confirm that I see the following VOC Grams Ozone Grams Product: 0.5
And I confirm that I see the following limits statement: Does not exceed the limits specified in the Aerosol Coatings by the CARB
And I confirm that I see the following comply with restrictive VOC statement: Based on the type of product, this must comply with the most restrictive VOC limit.

#change the VOC grams value
Then in the New Product page I click section: Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB)
And I set the VOC content in grams ozone per gram field to: 1
And in the New Product page I click Continue
And I confirm that I see the following limits statement: Exceeds the limits specified in the Aerosol Coatings by the CARB
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



Scenario: [67661] Verify Canada SDS on the Optional Reports and Documents Available for Purchase screen
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

# Checking that the test will run correctly by handling extra screens / removing existing products
Given If I see the retail partners page I set all data consent tiers to true for all retailers in the top section
Then The home screen should load
Given I generate a random UPC number and save as: UPC56484
Given I delete all products with UPC Number: saved as UPC56484

# New Product Page
And I click the Register New Product icon in the Navigation Pane
And I should see the New Product Page
And I set the Select the type of product to create option to: Create a New Registration
And in the New Product page I click Continue

# The Product Page
And I should see the The Product Page
And I set the Product Name option to: Deodorant - Non-aerosol
And In the Product Type tab of the New Product Page, I enter: Deodorant - Non-aerosol in the Type of Product select field
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
| UPCNumber     | saved as UPC56484 |
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
Then in the New Product page I click section: Optional Reports and Documents Available for Purchase
And the following additional documents should be showing as selected:
| Document Name  | Language      |
| Canada GHS SDS | English (U.S) |

# Delete the prodiuct created to cleanup
Given I navigate to the home page
Then I delete the product: TestCase67661

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
And I confirm that I see the following HVOC: 1
And I confirm that I see the following MVOC: 1
And I confirm that I see the following comply with restrictive VOC statement: Based on the type of product, this must comply with the most restrictive VOC limit.
And I confirm that I see the following limits statement: Exceeds the limits specified by CARB and OTC Model Rule

#change the HVOC and MVOC value
Then in the New Product page I click section: Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB)
And I set the HVOC (high volatile organic compound) content as weight percent of the total formulation field to: 0
And I set the MVOC (microbial volatile organic compound) content as weight percentage of the total formulation field to: 0
And in the New Product page I click Continue
And I confirm that I see the following limits statement: Does not exceed the limits specified by CARB and OTC Model Rule
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
And I set the Product, including container and/or packaging, contains a chemical on California's Prop 65 list option to: No
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
And I confirm that I see the following comply with restrictive VOC statement: Based on the type of product, this must comply with the most restrictive VOC limit.
And I confirm that I see the following limits statement: Does not exceed the limits specified in the California Consumer Products Regulation

# Change the CARB value
Then in the New Product page I click section: Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB)
And I set the Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the CARB field to: 70
And in the New Product page I click Continue
And I confirm that I see the following limits statement: Exceeds the limits specified in the California Consumer Products Regulation
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
And I set the Product, including container and/or packaging, contains a chemical on California's Prop 65 list option to: No
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
And I confirm that I see the following comply with restrictive VOC statement: Based on the type of product, this must comply with the most restrictive VOC limit.
And I confirm that I see the following limits specified in the California Consumer Products Regulation statement: Does not exceed the limits specified in the California Consumer Products Regulation
And I confirm that I see the following limits specified by the Ozone Transport Commission statement: Does not exceed the limits specified by the Ozone Transport Commission

# Change the CARB  and OTC Model Rule value
Then in the New Product page I click section: Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB)
And I set the Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the CARB field to: 5
And I set the Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the OTC Model Rule field to: 5
And in the New Product page I click Continue
And I confirm that I see the following limits specified in the California Consumer Products Regulation statement: Exceeds the limits specified in the California Consumer Products Regulation
And I confirm that I see the following limits specified by the Ozone Transport Commission statement: Exceeds the limits specified by the Ozone Transport Commission
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
And I set the Product, including container and/or packaging, contains a chemical on California's Prop 65 list option to: No
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
And I confirm that I see the following comply with restrictive VOC statement: Based on the type of product, this must comply with the most restrictive VOC limit.
And I confirm that I see the following limits specified by CARB statement: Exceeds the limits specified by CARB
And I confirm that I see the following limits specified by OTC statement: Exceeds the limits specified by OTC Model Rule

# Change the CARB  and OTC threshold options
Then in the New Product page I click section: Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB)
And I set the Verify VOC content is below the threshold of 0.02lb/start of CARB option to: Yes
And I set the Verify VOC content is below the threshold of 0.02lb/start of OTC option to: Yes
And in the New Product page I click Continue
And I confirm that I see the following limits specified by CARB statement: Does not exceed the limits specified by CARB
And I confirm that I see the following limits specified by OTC statement: Does not exceed the limits specified by OTC Model Rule
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
