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
@run_Flow7

Feature: Flow 7

Scenario: [57863] Flow 7 - ABS Welding (RU000868)

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

Given I generate a random UPC number and save as: UPC57863

Given I delete all products with UPC Number: saved as UPC57863

Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)

Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): ABS Welding

Then I save the product information as: TestCase57863

Given I call Shared Step 26897 (Product Characteristics - Solid only available - continue)

Given I call Shared Step 57865 (Additional Product Information - Pesticide shown, US only, select No for everything else - Happy Path)

Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Ketone

Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)

Given I call Shared Step 57590 (Enter Pesticide Data - United States (with EPA number))

Given I confirm that there is data populated in the Expiration Date Column for some States

And I confirm the 'Is Kelly Data' field is marked with a check for every State containing data in 'Expiration Date'

Given in the Pesticide Details - State Registration Details page I click Continue

Given I call Shared 57506 (Transportation Details 1 - Regulated for Transport(No) - Exemption(Random) - Continue - Happy Path)

Given I call Shared Step 57508 (VOC SCAQMD/Canada - Yes Low Solid, Yes apply to all States - Continue - Happy Path)

Given I call Shared Step 57801 (Confirm VOC Summary step shown, Confirm VOC analysis date is shown - Happy Path)

Then The VOC Summary page contains the statement with the text: Based on your previous selections, the product is an architectural coating with the following intended use. The SCAQMD VOC compliant limits for this intended use are:

Then in the VOC Limits table, the Use column should contain the value: ABS Welding

Then The VOC content in g/L message shows the value: 10.0

Then The VOC Summary page contains the statement with the text: Does not exceed the limits specified by the South Coast Air Quality Management District

Given in the Volatile Organic Compound Summary page I click Continue

Given I call Shared 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Costco

# Shared 42759 is a duplicate - using 57960
Given I call Shared 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC57863, container type: Metal Container and size: 40

Given I call Shared 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)

Given I call Shared 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |

Given I call Shared 57883 (Comments - Happy Path) and enter the comment: User added Comments Text 57863. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)

# Data Acceptance and Summary verification
And I should see the Data Acceptance Page
Given I click the Summary button in the Data Acceptance window
Then I switch to the Data Summary page
And Type of Product should be showing the following option: ABS Welding
Then I switch to Data Acceptance page
Given I navigate to the home page
Then I delete the product: TestCase57863

Scenario: [57905] Flow 7 - Automotive Coating - SCAQMD Any other coating type (RU001232)

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

Given I generate a random UPC number and save as: UPC57905

Given I delete all products with UPC Number: saved as UPC57905

Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)

Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Automotive Coating - SCAQMD any other coating type

Then I save the product information as: TestCase57905

Given I call Shared Step 57501 (Product Characteristics - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue)

Given I call Shared Step 57798 (Additional Product Information- Pesticide, Canada Only - No to everything else, Continue)

Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Polymethyl acrylate

# Wrong step. CEPA question is displayed because previous step set the countries sold in to only Canada
Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)

Given I call Shared Step 57590 (Enter Pesticide Data - United States (with EPA number))

Given I confirm that there is data populated in the Expiration Date Column for some States

And I confirm the 'Is Kelly Data' field is marked with a check for every State containing data in 'Expiration Date'

Given in the Pesticide Details - State Registration Details page I click Continue

Given I call Shared 57506 (Transportation Details 1 - Regulated for Transport(No) - Exemption(Random) - Continue - Happy Path)

# Needs Transportation Details 2 step because of DOT Exemption

Given I call Shared Step 57508 (VOC SCAQMD/Canada - Yes Low Solid, Yes apply to all States - Continue - Happy Path)

Given I call Shared Step 57801 (Confirm VOC Summary step shown, Confirm VOC analysis date is shown - Happy Path)

Then The VOC Summary page contains the statement with the text: Based on your previous selections, the product is an architectural coating with the following intended use. The SCAQMD VOC compliant limits for this intended use are:

Then in the VOC Limits table, the Use column should contain the value: Automotive Coating - SCAQMD any other coating type

Then The VOC content in g/L message shows the value: 10.0

Then The VOC Summary page contains the statement with the text: Does not exceed the limits specified by the South Coast Air Quality Management District

Given in the Volatile Organic Compound Summary page I click Continue

Given I call Shared 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Canadian Tire

# Shared 42759 is a duplicate - using 57960
#Canadian specific option 'packaging type'. Retailer specific option 'Item numbers' XXX-XXXX
Given I call Shared 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC57905, container type: Metal Container and size: 40

Given I call Shared 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)

Given I should see the Other product document Uploads Page

Given I call Shared Step 59042 (Browse for File > select > click Open - Happy Path) for document type: Product Label and file: C:\Dependencies\WERCSmart\testdoc.pdf

Given I click continue

Given I click continue

Given I call Shared 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance               | Odor  | Odor Threshold    | Partition Coefficient |
| Goggles                       | 66                       | 51.5                    | 10.92     | Clear to hazy, colorless | Berry | No data available | 2                     |

Given I call Shared 57883 (Comments - Happy Path) and enter the comment: User added Comments Text. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)

# Data Acceptance and Summary verification
And I should see the Data Acceptance Page
Given I click the Summary button in the Data Acceptance window
Then I switch to the Data Summary page
And Type of Product should be showing the following option: Automotive Coating - SCAQMD any other coating type
Then I switch to Data Acceptance page
Given I navigate to the home page
Then I delete the product: TestCase57905

Scenario: [63623] Flow 7 - Grout (RU001548) - has its own SCAQMD limit

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)

Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Grout

Then I save the product information as: TestCase63623

Given I call Shared Step 57501 (Product Characteristics - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue)

Given I call Shared 57401 (Additional Product Information - US only - No GHS, Not Direct Ship, Not PLP, Not GNFR > Continue - Happy Path)

Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Polymethyl acrylate

Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)

Given I call Shared Step 57507 (Transportation Details 1- Not Regulated - Continue - Happy Path)

Given I call Shared Step 57794 (Confirm VOC (SCAQMD) step title, Confirm ACP question shown  - Select No - Happy Path)

Given I set the Product is a Low Solid option to: Yes

Given I set the VOC content of product in g/L, including water and exempt compounds. option to: 1.00

Given I set the Would you like to use the VOC data provided to be copied for all areas (e.g. country, state, local) for comparison? option to: Yes

Given in the VOC SCAQMD/Canada page I click Continue

Given I should see the Volatile Organic Compound Summary Page

Then in the VOC Limits table, the Use column should contain the value: Grout

Then in the VOC Limits table, the VOC Compliance Limit column should contain the value: 120

Then in the VOC Limits table, the Regulation column should contain the value: (g/L) including water & exempts

Then in the New Product page I click section: Volatile Organic Compounds (VOC) for South Coast Air Quality Management District (SCAQMD) and Canada

And I should see the Volatile Organic Compounds (VOC) for South Coast Air Quality Management District (SCAQMD) and Canada Page

Given I set the Product is a Low Solid option to: No

Given I set the VOC content in g/L contained in this product option to: 2.00

Given in the VOC SCAQMD/Canada page I click Continue

Then in the VOC Limits table, the VOC Compliance Limit column should contain the value: 65

Given I navigate to the home page

Then I delete the product: TestCase63623
