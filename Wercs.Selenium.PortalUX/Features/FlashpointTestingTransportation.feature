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

# Assigned to Beverly Barrett
# Created by Beverly Barrett
Scenario: [74346] Flash Point > 60°C - Testing method shows all, Transportation shows all, Hazard class 3 must NOT be used
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bleach
And I call Shared Step 74339 (Product Characteristics - Select Liquid and enter only Secondary state, Specific gravity, pH)
Given I set the Boiling Point (in Celsius) field to: 50
Given I set the Flash Point (in Celsius) field to: 80
And The following options should be displayed for section: Flash Point Testing Method Used
| Option                   |
| Closed cup method        |
| Open cup method          |
| Not applicable/available |
And I set the Flash Point Testing Method Used field to: Open cup method
And I set the Select the best Water Solubility description field to: Insoluble
And I click continue
And I call Shared Step 74340 (Additional Product Information - Pesticide= Not considered, SOLD=US, everything else = No - Continue)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Hydrogen peroxide
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
And The following options should be displayed exclusively for section: Product is Regulated for Transport
| Option                               |
| Yes                                  |
| No, due to an exemption or exception |
And I set the Product is Regulated for Transport field to: Yes
And I set the Select all modes of transport that you've classified the product for field to: DOT
And I select option: Shipping fully regulated under section: Select all modes of transport that you've classified the product for and subsection: DOT
And I click continue
And I call Shared Step 81311 (UN Number - enter UN1206 - confirm pre-populated select radio button - Continue)
And section: UN Number is highlighed in red indicating an error
And UN Number should be showing the error messages: The UN-Number (DOT) is invalid with the selected Hazard Class and Flash Point value.|The Flash Point (80C - greater than or equal to 60C) must not be used with Hazard Class 3
And I call Shared Step 81310 (UN Number - enter UN1950 select Aerosol & Haz class, confirm Packing group - Continue)
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
And I call Shared Step 57883 (Comments - Happy Path) and enter the comment: Test Comment 74346
And I should see the Data Acceptance Page
Given I click the Summary button in the Data Acceptance window
Then I switch to the Data Summary page
And I close the window that opened
And I navigate to the home page
And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase74346

# Assigned to Beverly Barrett
# Created by Beverly Barrett

# Assigned to Beverly Barrett
# Created by Beverly Barrett
Scenario: [74364] Flash Point > 60°C - Testing method shows all, Transportation shows all, Hazard class 3 must NOT be used
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bleach
And I call Shared Step 74339 (Product Characteristics - Select Liquid and enter only Secondary state, Specific gravity, pH)
Given I set the Boiling Point (in Celsius) field to: 50
Given I set the Flash Point (in Celsius) field to: 80
And The following options should be displayed for section: Flash Point Testing Method Used
| Option                   |
| Closed cup method        |
| Open cup method          |
| Not applicable/available |
And I set the Flash Point Testing Method Used field to: Closed cup method
And I set the Select the best Water Solubility description field to: Insoluble
And I click continue
And I call Shared Step 74340 (Additional Product Information - Pesticide= Not considered, SOLD=US, everything else = No - Continue)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Hydrogen peroxide
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
And The following options should be displayed exclusively for section: Product is Regulated for Transport
| Option                               |
| Yes                                  |
| No, due to an exemption or exception |
And I set the Product is Regulated for Transport field to: Yes
And I set the Select all modes of transport that you've classified the product for field to: DOT
And I select option: Shipping fully regulated under section: Select all modes of transport that you've classified the product for and subsection: DOT
And I click continue
And I call Shared Step 81311 (UN Number - enter UN1206 - confirm pre-populated select radio button - Continue)
And section: UN Number is highlighed in red indicating an error
And UN Number should be showing the error messages: The UN-Number (DOT) is invalid with the selected Hazard Class and Flash Point value.|The Flash Point (80C - greater than or equal to 60C) must not be used with Hazard Class 3
And I call Shared Step 81310 (UN Number - enter UN1950 select Aerosol & Haz class, confirm Packing group - Continue)
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
And I call Shared Step 57883 (Comments - Happy Path) and enter the comment: Test Comment 74346
And I should see the Data Acceptance Page
Given I click the Summary button in the Data Acceptance window
Then I switch to the Data Summary page
And I close the window that opened
And I navigate to the home page
And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase74364

# Assigned to Beverly Barrett
# Created by Beverly Barrett
Scenario: [74365] Flash Point > 60°C - Testing method shows all, Transportation shows all, Hazard class 3 must NOT be used
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bleach
And I call Shared Step 74339 (Product Characteristics - Select Liquid and enter only Secondary state, Specific gravity, pH)
Given I set the Boiling Point (in Celsius) field to: 50
Given I set the Flash Point (in Celsius) field to: 80
And The following options should be displayed for section: Flash Point Testing Method Used
| Option                   |
| Closed cup method        |
| Open cup method          |
| Not applicable/available |
And I set the Flash Point Testing Method Used field to: Not applicable/available
And I set the Select the best Water Solubility description field to: Insoluble
And I click continue
And I call Shared Step 74340 (Additional Product Information - Pesticide= Not considered, SOLD=US, everything else = No - Continue)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Hydrogen peroxide
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
And The following options should be displayed exclusively for section: Product is Regulated for Transport
| Option                               |
| Yes                                  |
| No, due to an exemption or exception |
| Not Regulated                        |
And I set the Product is Regulated for Transport field to: Yes
And I set the Select all modes of transport that you've classified the product for field to: DOT
And I select option: Shipping fully regulated under section: Select all modes of transport that you've classified the product for and subsection: DOT
And I click continue
And I call Shared Step 81311 (UN Number - enter UN1206 - confirm pre-populated select radio button - Continue)
And section: UN Number is highlighed in red indicating an error
And UN Number should be showing the error messages: Flash Point is required with Hazard Class 3
And I call Shared Step 81310 (UN Number - enter UN1950 select Aerosol & Haz class, confirm Packing group - Continue)
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
And I call Shared Step 57883 (Comments - Happy Path) and enter the comment: Test Comment 74346
And I should see the Data Acceptance Page
Given I click the Summary button in the Data Acceptance window
Then I switch to the Data Summary page
And I close the window that opened
And I navigate to the home page
And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase74365

# Assigned to Beverly Barrett
# Created by Beverly Barrett

Scenario: [74366] Flash Point = 60°C - Testing method shows closed cup only, Transportation select No due to an exemption
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bleach
And I call Shared Step 74339 (Product Characteristics - Select Liquid and enter only Secondary state, Specific gravity, pH)
Given I set the Boiling Point (in Celsius) field to: 45
Given I set the Flash Point (in Celsius) field to: 60
And The following options should be displayed exclusively for section: Flash Point Testing Method Used
| Option            |
| Closed cup method |
And I set the Flash Point Testing Method Used field to: Closed cup method
And I set the Select the best Water Solubility description field to: Insoluble
And I click continue
And I call Shared Step 74340 (Additional Product Information - Pesticide= Not considered, SOLD=US, everything else = No - Continue)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Hydrogen peroxide
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
And I should not see any error messages
#And I You may see the Ecologo Readiness step depending on your subscription level - if the step is shown use the shared step below, if not skip to step 24
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
And I call Shared Step 57883 (Comments - Happy Path) and enter the comment: Test Comment 74366
And I should see the Data Acceptance Page
Given I click the Summary button in the Data Acceptance window
Then I switch to the Data Summary page
And I close the window that opened
And I navigate to the home page
And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase74366

# Assigned to Beverly Barrett
# Created by Beverly Barrett


# Assigned to Beverly Barrett
# Created by Beverly Barrett
Scenario: [74368] Flash Point Range < 23 - Testing method shows closed cup only, Transportation shows Yes and No due to an exemption, Hazard class 3 must be used
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
And I In the shared step below use Bleach as your product type
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): (.*)
And I call Shared Step 74339 (Product Characteristics - Select Liquid and enter only Secondary state, Specific gravity, pH)
And I In the Boiling Point (in Celsius) field enter a value which is &gt; 35
And I Select the "I do not have exact Flash Point data available to me" check box
And I Select the &lt;23C entry from the Flash Point (in Celsius) drop down
And I Confirm the Flash Point Testing Method Used question shows only the "Closed cup method" radio button available for selection
And I Select the Closed cup method radio button for the Flash Point Testing Method Used question
And I Select any entry from the Select the best Water Solubility description drop down list
And I Click Continue
And I call Shared Step 74340 (Additional Product Information - Pesticide= Not considered, SOLD=US, everything else = No - Continue)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: (.*)
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
And I The Transport Details 1 step is shown
And I Confirm the only options shown for the Product is Regulated for Transport are:YesNo, due to an exemption or exception
And I Select the Yes radio button
And I Select the DOT check box
And I Select the Shipping fully regulated check box below DOT
And I Click Continue
And I call Shared Step 81310 (UN Number - enter UN1950 select Aerosol & Haz class, confirm Packing group - Continue)
And I Confirm the UN Number is shown in red font indicating an error
And I Confirm the error shown below the UN number reads "The UN-Number (DOT) is invalid with the selected Hazard Class and Flash Point value.The Flash Point (22C - less than or equal to 60C) must be used with Hazard Class 3."This is because we selected &lt;23C in step 7 earlier
And I call Shared Step 81311 (UN Number - enter UN1206 - confirm pre-populated select radio button - Continue)
And I Confirm no errors are shown
And I You may see the Ecologo readiness step depending on your subscription.  If you see the Ecologo step use the shared step below.  If you do not see it skip to step 29
And [Shared Step 57712 - ECOLOGO Readiness Assessment - Not at this time - Continue - Happy Path]
And I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
And I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
And I The additional documents to provide step is shown - click continue
And I The Optional Reports and Documents Available for Purchase step is shown - click continue
And I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
| Requires Table |
| Parameters     |
And I call Shared Step 57883 (Comments - Happy Path) and enter the comment: (.*)
And I The Data Acceptance step is shown
And I Click the Summary button
And I Confirm that no errors are shown for the product
And I Close the Summary window
And I Click the Home icon in the left hand navigation list
And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: (.*)
