@LandingPage
@Login
@Homepage
@ForgottenPassword
@SupplierReports
@NewProduct
@RetailPartners
@wercsmart
@Signup
@run_Kits

Feature: Kits

Background:
Given I go to the WERCSmart Log in


#NOT COMPLETED
@tfs_design
Scenario: [63521] Kit Product - One or more inputs is regulated for transport - Transportation step does NOT shows Not regulated option
Given I login into the WERCSmart Portal - Administrator Role
Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Bleach
Then I save the product information as: Kit1
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

Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Bleach
Then I save the product information as: Kit2
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

Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Hair Care kit
Then I save the product information as: TestCase63521
Given I call Shared Step 63460 (Additional Product Information - SOLD = US, No(PL), No(GNFR) only shown (mainly kits) Happy Path)
Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
And I should see the Create the Kit Page
Given In the Create the kit page I search for and select: saved as Kit1
Given In the Create the kit page I search for and select: 1
Then in the Create the Kit page I click Continue
And I should see the Transportation Details 1 Page
Then in the Transport Details 1 page I should see the Product is Regulated for Transport question
Then in the Transport Details 1 page under the Product is Regulated for Transport question I should see the Radio button: Yes
Then in the Transport Details 1 page under the Product is Regulated for Transport question I should see the Radio button: No, due to an exemption
Then in the Transport Details 1 page I should not see the Not regulated option
Then in the Transportation Details 1 page I click Continue
Then in the Transport Details 1 page I should see the error: This is a required field
Given I set the Product is Regulated for Transport field to: No, due to an exemption
Then in the Transport Details 1 page I should not see the error: This is a required field



