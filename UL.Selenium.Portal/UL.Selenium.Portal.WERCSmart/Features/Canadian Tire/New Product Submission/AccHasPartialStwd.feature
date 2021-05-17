@Shared
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
@Studio
@SHA
@UPC
@run_AccHasPartialStwd
Feature: Account has Partial Stewardship Data

@ScenarioId:1330
Scenario: [86114] Create a new simple product SOLD = US and Canada, PL = Yes, Retailer NOT Canadian Tire (Chalk) and submit thru to Completed status
	Given I log in with the account saved in TReVor as: CanadaHasPackandPartialStewardship
	Given I generate a random UPC number and save as: UPC86114
	#Given I delete all products with UPC Number: saved as UPC86114
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
	Then I save the product information as: TestCase86114
And I call Shared Step 85284 - Product Information - US & Canada, Child (No), OSHA (No), DSV (No), PLP (YES), GNFR (No), Continue
	And I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
	And I call Shared Step 57637 (Regulatory Information 1 - TSCA & CEPA shown, No to PROP 65 - Continue - Happy Path)
	And I call Shared Step  (Select Retailers Amazon and enter additional requirements field - Indicate full name of product, as sold via this retailer)
	And I call Shared Step 75702 - UPC - Add UPC, Container type, Size and Package type (no retailer data needed) - Continue for UPC: saved as UPC86114, container type: Metal Container and size: 40
	Given I call Shared Step 78868 - Regulatory Documents to Provide - US and Canada - Request authoring for both
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 64097 - Additional Documents -> Contact Information - Add any Name, address, phone and emergency phone - Happy Path
	Given I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
		| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
	Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: Test
	Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given If purchase details are showing click confirm order
	#Scenario: Test
	#Given I save to context name: TestCase86114 and value: 1559223
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase86114)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase86114 and its status is: Submitted
	Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase86114)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase86114)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase86114 and its status is: Assigned
	Given I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase86114)
	Given I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase86114)
	Given I call Shared Step 75347 (WPS Studio - PD+ - set all data and publish using rule and Doc queue - CKLT, NGHS and SBCS) for product saved as: TestCase86114
	Given I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase86114)
	Given I call Shared Step 59066 (Go to SHA Manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase86114)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase86114 and its status is: Accepted
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Accepted Status for saved as: TestCase86114)
	Given I call Shared Step 51664 (SHA - Accepted Product - set Retailers to Completed for saved as: TestCase86114) for
		| Retailer |
		| Amazon   |
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase86114)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase86114 and its status is: Completed

@ScenarioId:1331
Scenario: [86115] Create a new product SOLD = US and Canada, PL = No, Retailer NOT Canadian Tire (Chalk) and submit thru to Completed status
	Given I log in with the account saved in TReVor as: CanadaHasPackandPartialStewardship
	Given I generate a random UPC number and save as: UPC86115
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
	Then I save the product information as: TestCase86115
	And I call Shared Step 62678 (Product Information - US & Canada, No Child, No OSHA, NO Direct ship, No PL, No NGFR - Continue, Happy path)
	And I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
	And I call Shared Step 57637 (Regulatory Information 1 - TSCA & CEPA shown, No to PROP 65 - Continue - Happy Path)
	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Amazon
	And I call Shared Step 75702 - UPC - Add UPC, Container type, Size and Package type (no retailer data needed) - Continue for UPC: saved as UPC86115, container type: Metal Container and size: 40
	Given I call Shared Step 78868 - Regulatory Documents to Provide - US and Canada - Request authoring for both
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 64097 - Additional Documents -> Contact Information - Add any Name, address, phone and emergency phone - Happy Path
	Given I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
		| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
	Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: User added Comments Text 57863. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
	Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given If purchase details are showing click confirm order
	#Scenario: Test
	#Given I save to context name: TestCase86115 and value: 1559223
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase86115)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase86115 and its status is: Submitted
	Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase86115)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase86115)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase86115 and its status is: Assigned
	Given I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase86115)
	Given I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase86115)
	Given I call Shared Step 75347 (WPS Studio - PD+ - set all data and publish using rule and Doc queue - CKLT, NGHS and SBCS) for product saved as: TestCase86115
	Given I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase86115)
	Given I call Shared Step 59066 (Go to SHA Manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase86115)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase86115 and its status is: Accepted
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Accepted Status for saved as: TestCase86115)
	Given I call Shared Step 51664 (SHA - Accepted Product - set Retailers to Completed for saved as: TestCase86115) for
		| Retailer |
		| Amazon   |
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase86115)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase86115 and its status is: Completed

@ScenarioId:1334
Scenario: [86452] Create a new product SOLD = Canada, Private Label = Yes, NR product - Submission and process thru to completed
	Given I log in with the account saved in TReVor as: CanadaHasPackandPartialStewardship
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	And I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Crayon
	Then I save the product information as: TestCase86452
	And I call Shared Step 85730 - Product Information - Canada Only - Child (NO), GHS (NO), DSV (NO), PLP(YES), GNFR (NO), Continue
	And I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
	And I call Shared Step 57911 (Regulatory Information 1 - CEPA only shown - Continue - Happy Path)
	Given I call Shared Step 86163 - Retailer - Canada Only & PL, Select No Retailer, Add PL, Continue
	And I call Shared Step 78884 - Regulatory Documents to Provide - Canada only - request authoring, upload label - Continue
	Then in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	And I call Shared Step 64097 - Additional Documents -> Contact Information - Add any Name, address, phone and emergency phone - Happy Path
	And I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
		| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
	And I call Shared Step 57883 (Comments - Happy Path) and enter the comment: test
	Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given If purchase details are showing click confirm order
	#Scenario: Test
	#Given I save to context name: TestCase86452 and value: 1559223
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase86452)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase86452 and its status is: Submitted
	Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase86452)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase86452)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase86452 and its status is: Assigned
	Given I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase86452)
	Given I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase86452)
	Given I call Shared Step 75347 (WPS Studio - PD+ - set all data and publish using rule and Doc queue - CKLT, NGHS and SBCS) for product saved as: TestCase86452
	Given I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase86452)
	Given I call Shared Step 59066 (Go to SHA Manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase86452)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase86452 and its status is: Completed

@ScenarioId:1333
Scenario: [86117] Create a new product SOLD = Canada only , PL = No, NR product and submit thru to Completed status (HGHS only)
	Given I log in with the account saved in TReVor as: CanadaHasPackandPartialStewardship
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	And I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Crayon
	Then I save the product information as: TestCase86117
	And I call Shared Step 78879 - Product Information - Canada Only - Child (NO), GHS (NO), DSV (NO), PLP (NO), GNFR (NO), Continue
	And I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	And I call Shared Step 29181c (Ingredients - add any chemical - For Canada Only) with name: Sodium hydroxide
	And I call Shared Step 57911 (Regulatory Information 1 - CEPA only shown - Continue - Happy Path)
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	And I call Shared Step 78884 - Regulatory Documents to Provide - Canada only - request authoring, upload label - Continue
	Then in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	And I call Shared Step 64097 - Additional Documents -> Contact Information - Add any Name, address, phone and emergency phone - Happy Path
	And I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
		| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
	And I call Shared Step 57883 (Comments - Happy Path) and enter the comment: test
	Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given If purchase details are showing click confirm order
	#Scenario: Test
	#Given I save to context name: TestCase86124 and value: 1506402
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase86117)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase86117 and its status is: Submitted
	Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase86117)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase86117)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase86117 and its status is: Assigned
	Given I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase86117)
	Given I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase86117)
	Given I call Shared Step 75347 (WPS Studio - PD+ - set all data and publish using rule and Doc queue - CKLT, NGHS and SBCS) for product saved as: TestCase86117
	Given I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase86117)
	Given I call Shared Step 59066 (Go to SHA Manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase86117)
	#Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase86121 and its status is: Accepted
	#Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Accepted Status for saved as: TestCase86117)
	#Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase86117)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase86117 and its status is: Completed

@ScenarioId:1332
Scenario: [86116] Create a new product SOLD = Canada, Private Label = Yes, CT retailer product - Submission and process thru to completed
	Given I generate a random UPC number and save as: UPC86116
	Given I log in with the account saved in TReVor as: CanadaHasPackandPartialStewardship
	And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	And I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Crayon
	Then I save the product information as: TestCase86116
	And I call Shared Step 85730 - Product Information - Canada Only - Child (NO), GHS (NO), DSV (NO), PLP(YES), GNFR (NO), Continue
	And I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
	And I call Shared Step 57911 (Regulatory Information 1 - CEPA only shown - Continue - Happy Path)
	And I call Shared Step 85990 - Retailers - PLP - Select one or more retailer and add PL information - Continue
		| Retailer      |
		| Canadian Tire |
	And I call Shared Step 75702 - UPC - Add UPC, Container type, Size and Package type (no retailer data needed) - Continue for UPC: saved as UPC86116, container type: Metal Container and size: 40
	And I call Shared Step 78884 - Regulatory Documents to Provide - Canada only - request authoring, upload label - Continue
	Then in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	And I call Shared Step 64097 - Additional Documents -> Contact Information - Add any Name, address, phone and emergency phone - Happy Path
	And I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
		| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
	And I call Shared Step 57883 (Comments - Happy Path) and enter the comment: test
	Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given If purchase details are showing click confirm order
	And I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase86116)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase86116 and its status is: Submitted
	Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase86116)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase86116)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase86116 and its status is: Assigned
	Given I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase86116)
	Given I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase86116)
	Given I call Shared Step 75347 (WPS Studio - PD+ - set all data and publish using rule and Doc queue - CKLT, NGHS and SBCS) for product saved as: TestCase86116
	Given I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase86116)
	Given I call Shared Step 59066 (Go to SHA Manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase86116)
	#Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase86416 and its status is: Accepted
	#Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Accepted Status for saved as: TestCase86116)
	#Given I call Shared Step 51664 (SHA - Accepted Product - set Retailers to Completed for saved as: TestCase86116) for
	#| Retailer      |
	#| Canadian Tire |
	#Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase86116)
	#Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase86116 and its status is: Completed
	Then In the SHA manager I search for the Product saved as: TestCase86116 and if its Status is Accepted I set the retailers: to Completed and check the Products Grid
	| Retailer      |
	| Canadian Tire |

@ScenarioId:1335
Scenario: [86454] Create a new product SOLD = Canada only , PL = No, CT Retailer product - submit thru to Completed status (HGHS only)
	Given I generate a random UPC number and save as: UPC86454
	Given I log in with the account saved in TReVor as: CanadaHasPackandPartialStewardship
	And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	And I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Crayon
	Then I save the product information as: TestCase86454
	And I call Shared Step 78879 - Product Information - Canada Only - Child (NO), GHS (NO), DSV (NO), PLP (NO), GNFR (NO), Continue
	And I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
	#And I call Shared Step 57637 (Regulatory Information 1 - TSCA & CEPA shown, No to PROP 65 - Continue - Happy Path)
	And I call Shared Step 57911 (Regulatory Information 1 - CEPA only shown - Continue - Happy Path)
	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Canadian Tire
	And I call Shared Step 75702 - UPC - Add UPC, Container type, Size and Package type (no retailer data needed) - Continue for UPC: saved as UPC86454, container type: Metal Container and size: 40
	#And I call Shared Step 78868 - Regulatory Documents to Provide - US and Canada - Request authoring for both
	And I call Shared Step 78884 - Regulatory Documents to Provide - Canada only - request authoring, upload label - Continue
	Then in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	And I call Shared Step 64097 - Additional Documents -> Contact Information - Add any Name, address, phone and emergency phone - Happy Path
	And I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
		| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
	And I call Shared Step 57883 (Comments - Happy Path) and enter the comment: test
	Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given If purchase details are showing click confirm order
	And I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase86454)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase86454 and its status is: Submitted
	Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase86454)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase86454)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase86454 and its status is: Assigned
	Given I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase86454)
	Given I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase86454)
	Given I call Shared Step 75347 (WPS Studio - PD+ - set all data and publish using rule and Doc queue - CKLT, NGHS and SBCS) for product saved as: TestCase86454
	Given I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase86454)
	Given I call Shared Step 59066 (Go to SHA Manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase86454)
	#Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase86417 and its status is: Accepted
	#Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Accepted Status for saved as: TestCase86417)
	#Given I call Shared Step 51664 (SHA - Accepted Product - set Retailers to Completed for saved as: TestCase86417) for
	#| Retailer      |
	#| Canadian Tire |
	#Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase86417)
	#Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase86454 and its status is: Completed
	Then In the SHA manager I search for the Product saved as: TestCase86454 and if its Status is Accepted I set the retailers: to Completed and check the Products Grid
	| Retailer      |
	| Canadian Tire |

@ScenarioId:1336
Scenario: [86455] Create a new simple product SOLD = US and Canada, PL = Yes, Canadian Tire Retailer Product  - submit thru to Completed status
	Given I log in with the account saved in TReVor as: CanadaHasPackandPartialStewardship
	Given I generate a random UPC number and save as: UPC86455
	#Given I delete all products with UPC Number: saved as UPC86418
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
	Then I save the product information as: TestCase86455
And I call Shared Step 85284 - Product Information - US & Canada, Child (No), OSHA (No), DSV (No), PLP (YES), GNFR (No), Continue
	And I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
	And I call Shared Step 57637 (Regulatory Information 1 - TSCA & CEPA shown, No to PROP 65 - Continue - Happy Path)
	And I call Shared Step 85990 - Retailers - PLP - Select one or more retailer and add PL information - Continue
		| Retailer      |
		| Canadian Tire |
	And I call Shared Step 75702 - UPC - Add UPC, Container type, Size and Package type (no retailer data needed) - Continue for UPC: saved as UPC86455, container type: Metal Container and size: 40
	Given I call Shared Step 78868 - Regulatory Documents to Provide - US and Canada - Request authoring for both
	#Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 64097 - Additional Documents -> Contact Information - Add any Name, address, phone and emergency phone - Happy Path
	Given I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
		| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
	Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: awesome product
	Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given If purchase details are showing click confirm order
	#Scenario: Test
	#Given I save to context name: TestCase86121 and value: 1506402
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase86455)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase86455 and its status is: Submitted
	Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase86455)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase86455)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase86455 and its status is: Assigned
	Given I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase86455)
	Given I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase86455)
	Given I call Shared Step 75347 (WPS Studio - PD+ - set all data and publish using rule and Doc queue - CKLT, NGHS and SBCS) for product saved as: TestCase86455
	Given I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase86455)
	Given I call Shared Step 59066 (Go to SHA Manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase86455)
	#Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase86418 and its status is: Accepted
	#Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Accepted Status for saved as: TestCase86418)
	#Given I call Shared Step 51664 (SHA - Accepted Product - set Retailers to Completed for saved as: TestCase86418) for
	#| Retailer      |
	#| Canadian Tire |
	#Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase86418)
	#Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase86455 and its status is: Completed
	Then In the SHA manager I search for the Product saved as: TestCase86455 and if its Status is Accepted I set the retailers: to Completed and check the Products Grid
	| Retailer      |
	| Canadian Tire |

@ScenarioId:1337
Scenario: [86458] Create a new simple product SOLD = US and Canada, PL = No, Canadian Tire retailer product (Chalk) and submit thru to Completed status
	Given I generate a random UPC number and save as: UPC86458
	Given I log in with the account saved in TReVor as: CanadaHasPackandPartialStewardship
	And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	And I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Crayon
	Then I save the product information as: TestCase86458
	And I call Shared Step 62678 (Product Information - US & Canada, No Child, No OSHA, NO Direct ship, No PL, No NGFR - Continue, Happy path)
	And I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
	And I call Shared Step 57637 (Regulatory Information 1 - TSCA & CEPA shown, No to PROP 65 - Continue - Happy Path)
	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Canadian Tire
	And I call Shared Step 75702 - UPC - Add UPC, Container type, Size and Package type (no retailer data needed) - Continue for UPC: saved as UPC86458, container type: Metal Container and size: 40
	And I call Shared Step 78868 - Regulatory Documents to Provide - US and Canada - Request authoring for both
	Then in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	And I call Shared Step 64097 - Additional Documents -> Contact Information - Add any Name, address, phone and emergency phone - Happy Path
	And I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
		| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
	And I call Shared Step 57883 (Comments - Happy Path) and enter the comment: test
	Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given If purchase details are showing click confirm order
	And I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase86458)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase86458 and its status is: Submitted
	Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase86458)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase86458)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase86458 and its status is: Assigned
	Given I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase86458)
	Given I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase86458)
	Given I call Shared Step 75347 (WPS Studio - PD+ - set all data and publish using rule and Doc queue - CKLT, NGHS and SBCS) for product saved as: TestCase86458
	Given I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase86458)
	Given I call Shared Step 59066 (Go to SHA Manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase86458)
	#Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase86419 and its status is: Accepted
	#Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Accepted Status for saved as: TestCase86419)
	#Given I call Shared Step 51664 (SHA - Accepted Product - set Retailers to Completed for saved as: TestCase86419) for
	#| Retailer      |
	#| Canadian Tire |
	#Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase86419)
	#Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase86458 and its status is: Completed
	Then In the SHA manager I search for the Product saved as: TestCase86458 and if its Status is Accepted I set the retailers: to Completed and check the Products Grid
	| Retailer      |
	| Canadian Tire |
