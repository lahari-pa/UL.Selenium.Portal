@Shared
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
@CreateProducts
@Studio
@ProductSetUp
@run_ProductSetUpChalk

Feature: ProductSetUp_Chalk

Background:
	Given I verify the following users exist and if not I create them using SHAUser
		| username    | FirstName | LastName   | Role         | EmailAddress                |
		| SHAQAAuto21 | QA        | Automation | QA Reviewers | qasha.kxxyxunf@mailosaur.io |

#Removed from regression 2024/03
@ignore
@TestCase:75335
Scenario: [75335] Create a new simple product (Chalk) and submit thru to Completed status (NGHS only)
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I generate a random UPC number and save as: UPC75335
	Given I delete all products with UPC Number: saved as UPC75335
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
	Then I save the product information as: TestCase75335
		Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue) for
		| Retailer |
		| CVS      |
	Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC75335, container type: Metal Container and size: 40
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
		| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: User added Comments Text 57863. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
	Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given If purchase details are showing click confirm order
	#Scenario: Test
	#Given I save to context name: TestCase75335 and value: 1523039
	Given I call Shared Step 65080b (Login to Studio as user saved as: SHAQAAuto21 and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase75335)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase75335 and its status is: Submitted
	Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase75335)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase75335)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase75335 and its status is: Assigned
	Given I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase75335)
	Given I call Shared Step (SHA - Assgined Product - set Retailers to Completed for saved as: TestCase75335) for	
		| Retailer                   |
		| No Retailer/No UPC Product |
		| CVS                        |
	#Given I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase75335)
	#Given I call Shared Step 75347 (WPS Studio - PD+ - set all data and publish using rule and Doc queue - CKLT, NGHS and SBCS) for product saved as: TestCase75335
	#Given I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase75335)
	#Given I call Shared Step 59066 (Go to SHA Manager)
	#Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase75335)
	#Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase75335 and its status is: Accepted
	#Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Accepted Status for saved as: TestCase75335)
	#Given I call Shared Step 51664 (SHA - Accepted Product - set Retailers to Completed for saved as: TestCase75335) for
	#	| Retailer |
	#	| CVS      |
	#Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase75335)
	#Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase75335 and its status is: Completed

@ignore
@TestCase:75142
Scenario: [75142] Create a new simple product (Chalk) and submit thru to SHA - Status = Submitted
	Given I login into the WERCSmart Portal - Administrator Role
	Given I generate a random UPC number and save as: UPC75142
	Given I delete all products with UPC Number: saved as UPC75142
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
	Then I save the product information as: TestCase75142
	Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue) for
		| Retailer |
		| CVS      |
	Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC75142, container type: Metal Container and size: 40
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
		| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: User added Comments Text 57863. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
	Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given If purchase details are showing click confirm order
	Given I call Shared Step 65080b (Login to Studio as user saved as: SHAQAAuto21 and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase75142)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase75142 and its status is: Submitted

@ignore
@TestCase:75651
Scenario: [75651] Create a new simple product (Chalk) and submit thru to SHA  - Process to Assigned
	Given I Login into WERCSmart Portal - Admin Role - WERCs Premium Subscription Account
	#Given I login into the WERCSmart Portal - Administrator Role
	Given I generate a random UPC number and save as: UPC75651
	Given I delete all products with UPC Number: saved as UPC75651
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
	Then I save the product information as: TestCase75651
	Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue) for
		| Retailer |
		| CVS      |
	Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC75651, container type: Metal Container and size: 40
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
		| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: User added Comments Text 57863. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
	Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given If purchase details are showing click confirm order
	Given I call Shared Step 65080b (Login to Studio as user saved as: SHAQAAuto21 and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase75651)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase75651 and its status is: Submitted
	And I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase75651)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Assigned Status for saved as: TestCase75651)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase75651 and its status is: Assigned

@ignore
@TestCase:85965
Scenario: [85965] Create a new simple product (Chalk) with SOLD = US Only, PL = Yes and submit thru to Completed status (NGHS only)
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I generate a random UPC number and save as: UPC85965
	Given I delete all products with UPC Number: saved as UPC85965
	And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
	Then I save the product information as: TestCase85965
Given I call Shared Step 63860 (Product Information - US, No(child), No(OSHA), No(DSV), Yes(PLP), No(GNFR))
	And I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	And I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	And I call Shared Step 85990 - Retailers - PLP - Select one or more retailer and add PL information - Continue
		| Retailer       |
		| CVS            |
		| Dollar General |
	Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC85965, container type: Metal Container and size: 40
	And I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
		| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
	And I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Test comment
	And I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	#Depending on your subscription you will either see the Purchase summary success message or you will see the Purchase summary with you product details save to contextshown.  If the product details are shown click Confirm order
	Given If purchase details are showing click confirm order
	Given I call Shared Step 65080b (Login to Studio as user saved as: SHAQAAuto21 and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase85965)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase85965 and its status is: Submitted
	Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase85965)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase85965)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase85965 and its status is: Assigned
	And I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase85965)	
	Given I call Shared Step (SHA - Assgined Product - set Retailers to Completed for saved as: TestCase85965) for	
		| Retailer                   |
		| No Retailer/No UPC Product |
		| CVS                        |
		| Dollar General             |
	#And I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase85965)
	#Given I call Shared Step 85983 - WPS Studio - PD\+ PLP with NGHS only - set all data and publish using rule and DOC queue for product saved as: TestCase85965
	#And I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase85965)
	#Given I call Shared Step 59066 (Go to SHA Manager)
	#Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase85965)
	##Note: If the retailer you selected does not have a feed then the retailer will be shown in Completed status
	#Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase85965 and its status is: Accepted
	#Given I call Shared Step 51664 (SHA - Accepted Product - set Retailers to Completed for saved as: TestCase85965) for
	#	| Retailer       |
	#	| CVS            |
	#	| Dollar General |
	#Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase85965)
	#Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase85965 and its status is: Completed

