@LandingPage
@Login
@Homepage
@Signup
@wercsmart
@NewProduct
@ProductGrid
@SHA
@wercsmart
@RetailPartners
@Studio
@run_ProductSetUp

Feature:  Product set up and process to specific statuses (Suite ID: 75359)

Scenario: [75335] Create a new simple product (Chalk) and submit thru to Completed status (NGHS only)
Given I login into the WERCSmart Portal - Administrator Role
Given I generate a random UPC number and save as: UPC75335
Given I delete all products with UPC Number: saved as UPC75335
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
Then I save the product information as: TestCase75335
Given I call Shared Step 26897 (Product Characteristics - Solid only available - continue)
Given I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Given I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue)
Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC75335, container type: Metal Container and size: 40
Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
Given in the Additional Documents to Provide page I click Continue
Given in the Optional Reports and Documents Available for Purchase page I click Continue
Given I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: User added Comments Text 57863. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
Given If purchase details are showing click confirm order


#Scenario: Test
Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
#Given I save the context product information as: TestCase75335 where id is: 1521642 and product name is: test
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase75335)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase75335 and its status is: Submitted
Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase75335)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase75335)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase75335 and its status is: Assigned
Given I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase75335)
Given I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase75335)
Given I call Shared Step 75347 (WPS Studio - PD+ - set all data and publish using rule and Doc queue - CKLT, NGHS and SBCS) for product saved as: TestCase75335

#Scenario: Test
#Given I save the context product information as: TestCase75335 where id is: 1383967 and product name is: test
#Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
Given I navigate to power designer plus
#Commented out the below step because it always fails due to the job already being completed
Given I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase75335)
Given I call Shared Step 59066 (Go to SHA Manager)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase75335)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase75335 and its status is: Accepted
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Accepted Status for saved as: TestCase75335)
Given I call Shared Step 51664 (SHA - Accepted Product - set Retailers to Completed for saved as: TestCase75335)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase75335)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase75335 and its status is: Completed


#Scenario: [80089] Create product with Publicly Disclosed Ingredients (bleach) - process to completed
