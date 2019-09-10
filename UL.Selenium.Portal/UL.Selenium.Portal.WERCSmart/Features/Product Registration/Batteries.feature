@NewProduct
@Homepage
@wercsmart
@run_Batteries

Feature: Batteries

# Assigned to Amanda Coutant
# Created by Amanda Coutant
# Test case can be found at the following paths:
# NetProjects10\WercsSmart Portal\WERCSmart\Battery
@tfs_design
Scenario: [97488] Stand alone Lithium Battery vehicle
Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
#And I In the shared step below select Lithium battery vehicle as your product type
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Lithium battery vehicle
And I call Shared Step 26897 (Product Characteristics - Solid only available - continue)
And I call Shared Step 60935 (Additional Product Information - US - Direct Ship - Private Label Only)
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Given I call Shared Step 48367 (Product Includes Battery > any type)
	| Battery Type   | Manufacturer | Number of batteries per package | How many batteries required to run |
	| Lthium Primary | <any>        | 6                               | 6                                  |
#And I Use Lithium in the shared step below
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Lithium
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
And I call Shared Step 60096 (Lithium Battery Transportation)
#And I On the Retailer screen please select Continue, as No Retailer is auto selected for battery
And I click continue
And If the UPCs Warning popup is displayed I click OK
#And I Click Ok
#And I On the Regulatory Documents to Provide screen select Request to Author
And I set the OSHA-compliant Safety Data Sheet, English field to: Request to author
#And I Select Continue
And I click continue
And I call Shared Step 69422 (Additional Documents to Provide - Upload Product Photo)
#And I Select Continue on the Optional Reports and Documents Available for Purchase
And I click continue
And I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
#And I Select Continue on Comments section
And I click continue
And I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
And I navigate to the home page
And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase97488

# Assigned to Amanda Coutant
# Created by Amanda Coutant
# Test case can be found at the following paths:
# NetProjects10\WercsSmart Portal\WERCSmart\Battery
Scenario: [97489] Stand alone Magnesium Battery
Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
#And I In the shared step below select Lithium Primary/Metal Batteries as your product type
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Lithium Primary/Metal Batteries
And I call Shared Step 26897 (Product Characteristics - Solid only available - continue)
And I call Shared Step 60310 (Additional Product Information - Without Child question)
#And I Use magnesium in the shared step below
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Magnesium
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
#And I On the Select Retailers screen select No Retailers
#And I Select Done
#And I On the Retailer screen please select Continue
And I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
#And I Click Ok
And If the UPCs Warning popup is displayed I click OK
#And I On the Regulatory Documents to Provide screen select Request to Author
And I set the OSHA-compliant Safety Data Sheet, English field to: Request to author
And I click continue
And I click continue
And I click continue
And I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
And I click continue
And I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
And I navigate to the home page
And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase97489
