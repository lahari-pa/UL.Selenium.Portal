@LandingPage
@Login
@Homepage
@ForgottenPassword
@SupplierReports
@NewProduct
@RetailPartners
@wercsmart
@Signup
@run_SupplierReports

Feature: Flash Point, testing method and Transportation (Suite ID: 74116)

Background:
Given I go to the WERCSmart Log in

@tfs_design
Scenario: [74364] Flash Point > 60°C - Testing method select Closed Cup, Transportation Select Yes, Hazard class 3 must NOT be used
Given I login into the WERCSmart Portal - Administrator Role
Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Bleach
Then I save the product information as: TestCase74364
Given I call Shared Step 74339 (Product Characteristics - Select Liquid and enter only Secondary state, Specific gravity, pH)
Given I set the Boiling Point (in Celsius) field to: 86
Given I set the Flash Point (in Celsius) field to: 92
Given I set the Flash Point Testing Method Used field to: Closed cup
Given I set the Select the best Water Solubility description field to: Decomposes
Then in the Product Characteristics page I click Continue
Given I call Shared Step 74340 (Additional Product Information - Pesticide= Not considered, SOLD=US, everything else = No - Continue)
Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Ketone
Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
And I should see the Transportation Details 1 Page
Given I set the Product is Regulated for Transport field to: Yes
Given I set the Select all modes of transport field to: DOT
Given I set the Select all modes of transport field to: Shipping fully regulated
Then in the Transport Details 1 page I click Continue
And I should see the U. S. Department of Transportation (DOT) Classification Page
Given I set the UN Number field to: UN1206
Given I set the Proper Shipping Name field to: Heptanes
Given I set the Hazard Class field to: 3
Given I set the Packing Group field to: II
Then in the U. S. Department of Transportation (DOT) Classification page I click Continue
#Then I should seen an error relating to field: UN Number which includes: The UN-Number (DOT) is invalid with the selected Hazard Class and Flash Point value.
#Then I should seen an error relating to field: UN Number which includes:The Flash Point (92C - greater than 60C) must not be used with Hazard Class 3.
Given I set the UN Number field to: UN1950
Given I set the Proper Shipping Name field to: Aerosols
Given I set the Hazard Class field to: 2.1
Given I set the Packing Group field to: None
Then in the U. S. Department of Transportation (DOT) Classification page I click Continue
Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
Then I should see the Additional Documents to Provide Page
Then in the Additional Documents to Provide page I click Continue
Then I should see the Optional Reports and Documents Available for Purchase Page
Then in the Optional Reports and Documents Available for Purchase page I click Continue
Given I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: User added Comments Text 57863. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Bleach
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase74364

# Assigned to Beverly Barrett
# Created by Beverly Barrett
Scenario: [74337] Flash Point < 60°C - Testing method shows closed cup only, Transportation shows Yes and No due to an exemption, Hazard class 3 must be used
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bleach
And I call Shared Step 74339 (Product Characteristics - Select Liquid and enter only Secondary state, Specific gravity, pH)
And I set the Boiling Point (in Celsius) field to: 40
And I set the Flash Point (in Celsius) field to: 50
And The following options should be displayed exclusively for section: Flash Point Testing Method Used
| Option            |
| Closed cup method |
And I set the Flash Point Testing Method Used field to: Closed cup method
And I set the Select the best Water Solubility description field to: Insoluble
And I click continue
And I call Shared Step 74340 (Additional Product Information - Pesticide= Not considered, SOLD=US, everything else = No - Continue)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Chlorine
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
And I should see the Transportation Details 1 Page
And The following options should be displayed exclusively for section: Product is Regulated for Transport
| Option                               |
| Yes                                  |
| No, due to an exemption or exception |
And I set the Product is Regulated for Transport field to: Yes
And I set the Select all modes of transport that you've classified the product for field to: DOT
And I select option: Shipping fully regulated under section: Select all modes of transport that you've classified the product for and subsection: DOT
And I click continue
And I call Shared Step 81310 (UN Number - enter UN1950 select Aerosol & Haz class, confirm Packing group - Continue)
And section: UN Number is highlighed in red indicating an error
And UN Number should be showing the error messages: The UN-Number (DOT) is invalid with the selected Hazard Class and Flash Point value.|The Flash Point (50C - less than or equal to 60C) must only be used with Hazard Class 3
And I call Shared Step 81311 (UN Number - enter UN1206 - confirm pre-populated select radio button - Continue)
And I should not see any error messages
#And I You may see the Ecologo Readiness step depending on your subscription level - if the step is shown use the shared step below, if not skip to step 28
#And [Shared Step 57712 - ECOLOGO Readiness Assessment - Not at this time - Continue - Happy Path]
And I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
And I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
And I should see the Additional Documents to Provide Page
And I click continue
And I should see the Optional Reports and Documents Available for Purchase Page
And I click continue
And I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
| Gloves                        | 500                      | 9                       | 12.0      | Black      | Odorless | No data available | 1                     |
And I call Shared Step 57883 (Comments - Happy Path) and enter the comment: Test Comment
And I should see the Data Acceptance Page
Given I click the Summary button in the Data Acceptance window
Then I switch to the Data Summary page
And I close the window that opened
And I navigate to the home page
And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase74337

# Assigned to Beverly Barrett
# Created by Beverly Barrett
Scenario: [74349] Flash Point = 60°C - Testing method shows closed cup only, Transportation shows Yes and No due to an exemption, Hazard class 3 must be used
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bleach
And I call Shared Step 74339 (Product Characteristics - Select Liquid and enter only Secondary state, Specific gravity, pH)
And I set the Boiling Point (in Celsius) field to: 38
And I set the Flash Point (in Celsius) field to: 60
And The following options should be displayed exclusively for section: Flash Point Testing Method Used
| Option            |
| Closed cup method |
And I set the Flash Point Testing Method Used field to: Closed cup method
And I set the Select the best Water Solubility description field to: Insoluble
And I click continue
And I call Shared Step 74340 (Additional Product Information - Pesticide= Not considered, SOLD=US, everything else = No - Continue)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Ethanol
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
And I should see the Transportation Details 1 Page
And The following options should be displayed exclusively for section: Product is Regulated for Transport
| Option                               |
| Yes                                  |
| No, due to an exemption or exception |
And I set the Product is Regulated for Transport field to: Yes
And I set the Select all modes of transport that you've classified the product for field to: DOT
And I select option: Shipping fully regulated under section: Select all modes of transport that you've classified the product for and subsection: DOT
And I click continue
And I call Shared Step 81310 (UN Number - enter UN1950 select Aerosol & Haz class, confirm Packing group - Continue)
And section: UN Number is highlighed in red indicating an error
And UN Number should be showing the error messages: The UN-Number (DOT) is invalid with the selected Hazard Class and Flash Point value.|The Flash Point (60C - less than or equal to 60C) must only be used with Hazard Class 3
And I call Shared Step 81311 (UN Number - enter UN1206 - confirm pre-populated select radio button - Continue)
And I should not see any error messages
#And I You may see the Ecologo Readiness step depending on your subscription level - if the step is shown use the shared step below, if not skip to step 28
#And [Shared Step 57712 - ECOLOGO Readiness Assessment - Not at this time - Continue - Happy Path]
And I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
And I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
And I should see the Additional Documents to Provide Page
And I click continue
And I should see the Optional Reports and Documents Available for Purchase Page
And I click continue
And I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
| Gloves                        | 500                      | 9                       | 12.0      | Black      | Odorless | No data available | 1                     |
And I call Shared Step 57883 (Comments - Happy Path) and enter the comment: Test Comment
And I should see the Data Acceptance Page
Given I click the Summary button in the Data Acceptance window
Then I switch to the Data Summary page
And I close the window that opened
And I navigate to the home page
And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase74349

# Assigned to Beverly Barrett
# Created by Beverly Barrett

# Assigned to Beverly Barrett
# Created by Beverly Barrett
Scenario: [74357] Flash Point < 60°C - Testing method shows closed cup only, Transportation select No due to an exemption
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bleach
And I call Shared Step 74339 (Product Characteristics - Select Liquid and enter only Secondary state, Specific gravity, pH)
And I set the Boiling Point (in Celsius) field to: 40
And I set the Flash Point (in Celsius) field to: 50
And The following options should be displayed exclusively for section: Flash Point Testing Method Used
| Option            |
| Closed cup method |
And I set the Flash Point Testing Method Used field to: Closed cup method
And I set the Select the best Water Solubility description field to: Insoluble
And I click continue
And I call Shared Step 74340 (Additional Product Information - Pesticide= Not considered, SOLD=US, everything else = No - Continue)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Chlorine
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
And I should see the Transportation Details 1 Page
And The following options should be displayed exclusively for section: Product is Regulated for Transport
| Option                               |
| Yes                                  |
| No, due to an exemption or exception |
And I set the Product is Regulated for Transport field to: No, due to an exemption or exception
And I set the Please select DOT Exceptions if applicable? field to: 173.120(a)(2)
And I click continue
And I call Shared Step 62536 (Transportation Details 2 > I do not ship internationally > Continue - Happy Path)
#And I You may see the Ecologo Readiness step depending on your subscription level - if the step is shown use the shared step below, if not skip to step 23
#And [Shared Step 57712 - ECOLOGO Readiness Assessment - Not at this time - Continue - Happy Path]
And I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
And I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
And I should see the Additional Documents to Provide Page
And I click continue
And I should see the Optional Reports and Documents Available for Purchase Page
And I click continue
And I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
| Gloves                        | 800                      | 25                       | 11.0      | Black      | Odorless | No data available | 1                     |
And I call Shared Step 57883 (Comments - Happy Path) and enter the comment: Test Comment
And I should see the Data Acceptance Page
Given I click the Summary button in the Data Acceptance window
Then I switch to the Data Summary page
And I close the window that opened
And I navigate to the home page
And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase74357
