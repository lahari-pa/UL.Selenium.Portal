@LandingPage
@Login
@Homepage
@Signup
@wercsmart
@NewProduct
@ProductGrid
@DataSummarySheet
@wercsmart
@run_ProductRegistration

Feature: Product Registration

Background:
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Scenario: [31343] New Product screen navigation
Then I click the Register New Product icon in the Navigation Pane
And I should see the header New Product
And I should see the following radio buttons:
| Button                             |
| Create a New Registration          |
| Copy from an Existing Registration |
| Request a UPC from a Manufacturer  |

#Old version of this test. Changed 6/2/2018
#| Yes, create a new product    |
#| No, copy an existing product |
#| No, copy from ULSC service   |

Scenario: [31344] New Product Screen validation
Given I click the Register New Product icon in the Navigation Pane
When I click continue
Then I should see an error message: This is a required field.

Scenario: Create a new product
Then I click the Register New Product icon in the Navigation Pane
And I should see the header New Product
Given I click the Register New Product icon in the Navigation Pane
When I click continue

Scenario: [63705] New Product - BCP
Given I delete all products with UPC Number: 630509667031
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
Then I select the retailer: Target in the 'Select Retailers' window
And in the New Product page I click Continue
Given I click the 'Add UPC' button
Then I add the following into the UPC Fields
| Field         | Value        |
| UPCNumber     | 630509667031 |
| ContainerType | Aerosol Can  |
| Size          | 20           |
| DPCI          | 087-16-0238  |
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
Given I delete all products with UPC Number: 630509616084
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

#And in the New Product page I click Continue
#And in the Product Characteristics tab of the New Product Page, for U.S. Toxic Substances Control Act (TSCA) status I select: Compliant
#And in the Product Characteristics tab of the New Product Page for Prop65 I select: No
#And in the New Product page I click Continue
#And I should see the Product Includes Battery Page
#And in the Product Characteristics tab of the New Product Page, for Indicate how battery is packaged I select: The battery is shipped with but not included in my product.
#And in the Product Characteristics tab of the New Product Page I add the following batteries:
#| Battery Type | Manufacturer | Number of batteries per package | How many batteries required to run |
#| Alkaline     | L1028F       | 6                               | 6                                  |
#| Lithium Ion  | 10400        | 4                               | 4                                  |
#And in the New Product page I click Continue
#And I should see the Toxicity Characteristic Leaching Procedure (TCLP) Page
#And In the Toxicity Characteristics Leaching Procedure page for Product has had TCLP; Report is available I select: No
#And I set all the metal presence value to: No
#And in the New Product page I click Continue
#And I should see the Electronic Equipment Page
#And in the Product Characteristics tab of the New Product Page for Contains Circuit Board I select: No
#And in the Product Characteristics tab of the New Product Page for Has a LCD or Plasma Display I select: No
#And in the New Product page I click Continue
#
##################### Coralie 11/4/2018: Adding in Lithium Battery Transportation section to test
###Assume this screen is appearing because of selecting a Lithium type battery
#And I should see the Lithium Battery Transportation Page
#And in the Product Characteristics tab of the New Product Page for DOT I select: Fully-regulated dangerous goods: UN3481, Lithium ion batteries packed with equipment, 9
#And in the Product Characteristics tab of the New Product Page for IMDG I select: None of the above/Not intended for shipment under IMDG
#And in the Product Characteristics tab of the New Product Page for IATA I select: Section II
#And in the Product Characteristics tab of the New Product Page for TDG I select: Meets the requirements of TDG special provision 34 to be transported as non-dangerous goods.
#And in the New Product page I click Continue
#
#
##################### Coralie 11/4/2018: Clicking add a retailer step no longer necessary because it automatically opens on clicking continue
##Select any retailer except for O'Reilly, Sears/K-Mart or Wal-Mart/SAM's CLUB because choosing any of these retailers will cause the Select Vendor drop down to display
#Given the 'Select Retailers' window appears
#Then I select the retailer: Target in the 'Select Retailers' window
#And in the New Product page I click Continue
#Given I click the 'Add UPC' button
#Then I add the following into the UPC Fields
#| Field         | Value        |
#| UPCNumber     | 630509667031 |
#| ContainerType | Aerosol Can  |
#| Size          | 20           |
#| DPCI          | 087-16-0238  |
#Given in the New Product page I click Continue
#Then the comments field should appear
#And I enter the following into the comments field: Comments Field Text
#Given in the New Product page I click Continue
#Then The Data Acceptance page should appear
#Given I click the Summary button in the Data Acceptance window
#Then I switch to the Data Summary page
#And I should see the following batteries present:
#| BatteryType | Manufacturer                                                                                                                     | NumberPerPackage | RequiredToRun |
#| Lithium Ion | TL-PB10400 by TP-LINK USA Corporation                                                                                            | 4                | 4             |
#| Alkaline    | Alkaline Manganese Button Cell Mercury Free Battery L1028F\L828F\L1325F\L1345F\L1335F\L1315F\L10 by Chung Pak Battery Works Ltd. | 6                | 6             |
#Then I close the Data Summary tab
#Given I navigate to the home page
#Then I delete the product: TestCase63705
