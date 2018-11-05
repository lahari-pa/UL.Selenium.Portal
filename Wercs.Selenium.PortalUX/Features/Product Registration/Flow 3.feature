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
@run_Flow3

Feature: Flow 3

Scenario: [74992] RU Baby/Infant/Adult Care/Cleansing Wipes

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

Given I generate a random UPC number and save as: UPC74992

Given I delete all products with UPC Number: saved as UPC74992

Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)

Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Baby/Infant/Adult Care/Cleansing Wipes

Then I save the product information as: TestCase74992

Given I call Shared Step 74995 (Liquid Core product - Select Yes - Continue)

Given I call Shared Step 57514 (Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path)

Given I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)

Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide

Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)

Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path

Given I call Shared Step 57507 (Transportation Details 1- Not Regulated - Continue - Happy Path)

Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)

Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)

Then I should see the Additional Documents to Provide Page

Given in the Additional Documents to Provide page I click Continue

Given in the Optional Reports and Documents Available for Purchase page I click Continue

Given I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |

Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: User added Comments Text 74992. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)

And I should see the Data Acceptance Page

Then The Data Acceptance page should appear

Then I confirm error message is displayed: Select at least one of the options

Then In the Data Acceptance page I select Yes, Agreed

Given I click the Summary button in the Data Acceptance window

Then I switch to the Data Summary page

And Type of Product should be showing the following option: Baby/infant/Adult Care/Cleansing Wipes

Then I switch to Data Acceptance page

Given I navigate to the home page

Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase74992

Scenario: [75081] RU Wipes, Cleaning (With Chemical) RU000725 - Flow 3-VOCOTC

Given I login as the administrator

Then The home screen should load

Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))

Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Wipes, Cleaning (with Chemical)

Then I save the product information as: TestCase75081

Given I call Shared Step 32931 (Liquid Core Product - select  No - Happy Path)

Given I call Shared Step 26897 (Product Characteristics - Solid only available - continue)

Given I call Shared Step 60310 (Additional Product Information - Without Child question)

Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Glycerin

Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)

Given I call Shared Step 57507 (Transportation Details 1- Not Regulated - Continue - Happy Path)

Given I call Shared Step 57923 (Volatile Organic Compound (VOC) Step - enter OTC and CARB - Yes for state values)
| Product granted Alternative Control Plan | Amount of VOC by CARB | Amount of VOC by OTC Model | VOC for states |
| No                                       | 2                     | 2                          | Yes            |

Given I call Shared Step 57801 (Confirm VOC Summary step shown and VOC analysis date is shown - Happy Path)

Given I call Shared Step 57817 (VOC Results - Confirm VOC Limits table shows correct values (OTC & CARB) - Happy Path): Wipes, Cleaning (with Chemical)

Then I confirm that I see the following CARB value: 2

Then I confirm that I see the following OTC Model Rule value: 2

And I confirm statement: Based on the type of product shows the text: Based on the type of product, this must comply with the most restrictive VOC limit.

And I confirm the Exceeds/Does not exceed statement is shown and is correct based on inputted CARB value: 2

And I confirm the Exceeds/Does not exceed statement is shown and is correct based on inputted OTC value: 2

Given I click continue

Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)

Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)

Then I should see the Additional Documents to Provide Page

Then I click continue

Then Volatile Organic Compounds should be showing the error messages: Document is required: Product Label

Given I call Shared Step 59042 (Browse for File > select > click Open - Happy Path) for document type: Product Label and file: C:\Dependencies\WERCSmart\testdoc.pdf

Given I click continue

Then I should see the Optional Reports and Documents Available for Purchase Page

Given I click continue

Given I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
| Gloves                        | 120                      | 4                       | 10.0      | Black      | Odorless | No data available | 1                     |

Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: User added Comments Text 74992. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)

And I should see the Data Acceptance Page

Then The Data Acceptance page should appear

Then I confirm error message is displayed: Select at least one of the options

Then In the Data Acceptance page I select Yes, Agreed

Given I click the Summary button in the Data Acceptance window

Then I switch to the Data Summary page

And Type of Product should be showing the following option: Wipes, Cleaning (with Chemical)

Then I switch to Data Acceptance page

Given I navigate to the home page

Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase75081
