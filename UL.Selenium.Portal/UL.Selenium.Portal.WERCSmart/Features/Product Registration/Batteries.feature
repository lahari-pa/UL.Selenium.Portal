@Shared
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
@ScenarioId:10167
Scenario: [97488] Stand alone Lithium Battery vehicle
Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Lithium battery vehicle
And I call Shared Step 60935 (Product Information - US - Direct Ship - Private Label Only)
And I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
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
@ScenarioId:1500
Scenario: [97489] Stand alone Magnesium Battery
Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
And I call Shared Step 57408 (Create a New Registration via Register New Product icon)


#Philip - Change - Checked
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Magnesium Battery
Given I call Shared Step 102767 (Product Information (Battery flow - not Lithium) - OSHA (No), DSV (No), PLP (No), GNFR (No))
#Given I call Shared Step 102767 (Product Information (Battery flow - not Lithium) - OSHA (No), DSV (No), PLP (No), GNFR (No))
#And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Magnesium Battery
#


And I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
#And I call Shared Step 29181 (Ingredients - add any chemical) with name: Magnesium
Then I add the following ingredients:
| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Magnesium     | 100     | false               | false       |            |
Given I click continue
Given I should see the Formulation > Batteries Page
Then I set the Consent to Tier 2.1, 2.2, 4.2 Data Uses option to: Granted
Given I click continue
And I call Shared Step 57637 (Regulatory Information 1 - TSCA & CEPA shown, No to PROP 65 - Continue - Happy Path)
And I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
And If the UPCs Warning popup is displayed I click OK
Given I should see the Regulatory Documents to Provide Page
Given I set the Batteries are considered Articles under Global Harmonized Standards option to: I need an OSHA-Compliant Safety Data Sheet (SDS) authored for this product.
Given I set the WHMIS-compliant Safety Data Sheet option to: I need a WHMIS-Compliant bilingual Safety Data Sheet (SDS) authored for this product.
Given I click the browse button for document type: Label in both French and English and for control label: Product Label in English and French-Canadian and upload a PDF
Then In the regulatory documents to provide screen if I see the question 'I confirm I am providing the most current Safety Data Sheet (SDS)' I tick confirm
Given I click continue
Given I call Shared Step 60567 (Upload Product Label only)
Given in the Optional Reports and Documents Available for Purchase page I click Continue
And I call Shared Step 64097 - Additional Documents -> Contact Information - Add any Name, address, phone and emergency phone - Happy Path
And I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
And I click continue
And I should see the Data Acceptance Page
#And I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
And I navigate to the home page
And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase97489

# Assigned to Amanda Coutant
# Created by Amanda Coutant
# Test case can be found at the following paths:
# NetProjects10\WercsSmart Portal\WERCSmart\Battery
@ScenarioId:1502
Scenario: [97495] Stand alone Nickel-Cadmium Battery
Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Nickel-cadmium battery
	Given I call Shared Step 102767 (Product Information (Battery flow - not Lithium) - OSHA (No), DSV (No), PLP (No), GNFR (No))
And I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
Then I add the following ingredients:
| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Nickel        | 100     | false               | false       |            |
Given I click continue
Given I should see the Formulation > Batteries Page
Then I set the Consent to Tier 2.1, 2.2, 4.2 Data Uses option to: Granted
Given I click continue
And I call Shared Step 57637 (Regulatory Information 1 - TSCA & CEPA shown, No to PROP 65 - Continue - Happy Path)
And I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
And If the UPCs Warning popup is displayed I click OK
#And I set the OSHA-compliant Safety Data Sheet, English field to: Request to author
#And I click continue
#And I click continue
#And I click continue
Given I should see the Regulatory Documents to Provide Page
Given I set the Batteries are considered Articles under Global Harmonized Standards option to: I need an OSHA-Compliant Safety Data Sheet (SDS) authored for this product.
Given I set the WHMIS-compliant Safety Data Sheet option to: I need a WHMIS-Compliant bilingual Safety Data Sheet (SDS) authored for this product.
Given I click the browse button for document type: Label in both French and English and for control label: Product Label in English and French-Canadian and upload a PDF
Then In the regulatory documents to provide screen if I see the question 'I confirm I am providing the most current Safety Data Sheet (SDS)' I tick confirm
Given I click continue
Given I call Shared Step 60567 (Upload Product Label only)
Given in the Optional Reports and Documents Available for Purchase page I click Continue
And I call Shared Step 64097 - Additional Documents -> Contact Information - Add any Name, address, phone and emergency phone - Happy Path
And I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
And I click continue
And I should see the Data Acceptance Page
#And I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
And I navigate to the home page
And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase97495

# Assigned to Amanda Coutant
# Created by Amanda Coutant
# Test case can be found at the following paths:
# NetProjects10\WercsSmart Portal\WERCSmart\Battery
@ScenarioId:1501
Scenario: [97494] Stand alone Nickel Metal Hydride Battery
Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
And I call Shared Step 57408 (Create a New Registration via Register New Product icon)



#Philip - Change - Checked
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Nickel Metal Hydride (NiMH) Battery
Given I call Shared Step 102767 (Product Information (Battery flow - not Lithium) - OSHA (No), DSV (No), PLP (No), GNFR (No))
#Given I call Shared Step 102767 (Product Information (Battery flow - not Lithium) - OSHA (No), DSV (No), PLP (No), GNFR (No))
#And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Nickel Metal Hydride (NiMH) Battery
#



#And I In the shared step below select nickel metal hydride as your product type
And I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
Then I add the following ingredients:
| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Nickel        | 100     | false               | false       |            |
Given I click continue
Given I should see the Formulation > Batteries Page
Then I set the Consent to Tier 2.1, 2.2, 4.2 Data Uses option to: Granted
Given I click continue
And I call Shared Step 57637 (Regulatory Information 1 - TSCA & CEPA shown, No to PROP 65 - Continue - Happy Path)
And I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
And If the UPCs Warning popup is displayed I click OK
#And I set the OSHA-compliant Safety Data Sheet, English field to: Request to author
#And I click continue
#And I click continue
#And I click continue
Given I should see the Regulatory Documents to Provide Page
Given I set the Batteries are considered Articles under Global Harmonized Standards option to: I need an OSHA-Compliant Safety Data Sheet (SDS) authored for this product.
Given I set the WHMIS-compliant Safety Data Sheet option to: I need a WHMIS-Compliant bilingual Safety Data Sheet (SDS) authored for this product.
Given I click the browse button for document type: Label in both French and English and for control label: Product Label in English and French-Canadian and upload a PDF
Then In the regulatory documents to provide screen if I see the question 'I confirm I am providing the most current Safety Data Sheet (SDS)' I tick confirm
Given I click continue
Given I call Shared Step 60567 (Upload Product Label only)
Given in the Optional Reports and Documents Available for Purchase page I click Continue
And I call Shared Step 64097 - Additional Documents -> Contact Information - Add any Name, address, phone and emergency phone - Happy Path
And I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
And I click continue
And I should see the Data Acceptance Page
#And I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
And I navigate to the home page
And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase97494
