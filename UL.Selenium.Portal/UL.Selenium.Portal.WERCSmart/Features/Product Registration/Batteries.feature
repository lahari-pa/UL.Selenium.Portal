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
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Lithium battery vehicle
And I call Shared Step 26897 (Product Characteristics - Solid only available - continue)
And I call Shared Step 60935 (Additional Product Information - US - Direct Ship - Private Label Only)
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Given I call Shared Step 48367 (Product Includes Battery > any type)
	| Battery Type   | Manufacturer | Number of batteries per package | How many batteries required to run |
	| Lthium Primary | <any>        | 6                               | 6                                  |
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Lithium
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
And I call Shared Step 60096 (Lithium Battery Transportation)
And I click continue
And If the UPCs Warning popup is displayed I click OK
And I set the OSHA-compliant Safety Data Sheet, English field to: Request to author
And I click continue
And I call Shared Step 69422 (Additional Documents to Provide - Upload Product Photo)
And I click continue
And I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
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
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Lithium Primary/Metal Batteries
And I call Shared Step 26897 (Product Characteristics - Solid only available - continue)
And I call Shared Step 60310 (Additional Product Information - Without Child question)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Magnesium
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
And I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
And If the UPCs Warning popup is displayed I click OK
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

# Assigned to Amanda Coutant
# Created by Amanda Coutant
# Test case can be found at the following paths:
# NetProjects10\WercsSmart Portal\WERCSmart\Battery
Scenario: [97495] Stand alone Nickel-Cadmium Battery
Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Nickel-cadmium battery
And I call Shared Step 26897 (Product Characteristics - Solid only available - continue)
And I call Shared Step 60310 (Additional Product Information - Without Child question)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Nickel
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
And I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
And If the UPCs Warning popup is displayed I click OK
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
And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase97495

# Assigned to Amanda Coutant
# Created by Amanda Coutant
# Test case can be found at the following paths:
# NetProjects10\WercsSmart Portal\WERCSmart\Battery
Scenario: [97494] Stand alone Nickel Metal Hydride Battery
Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
#And I In the shared step below select nickel metal hydride as your product type
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Nickel Metal Hydride (NiMH) Battery
And I call Shared Step 26897 (Product Characteristics - Solid only available - continue)
And I call Shared Step 60310 (Additional Product Information - Without Child question)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Nickel
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
And I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
And If the UPCs Warning popup is displayed I click OK
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
And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase97494
