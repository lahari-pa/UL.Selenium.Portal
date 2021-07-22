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
@run_AccHasFullStwdData
@UPC


Feature: AccHasFullStwdData

Background:
	Given I verify the following users exist and if not I create them using SHAUser
		| username    | FirstName | LastName   | Role         | EmailAddress                |
		| SHAQAAuto1  | QA        | Automation | QA Reviewers | qasha.kxxyxunf@mailosaur.io |

		

# Assigned to Barrett, Beverly
# NetProjects10\WercsSmart Portal\WERCSmart\Canadian Tire - Blue Box Program\New Product Submission\Submit and process to Completed\Account has Full Stewardship Data
@ScenarioId:1424
Scenario: [86187] Create a new simple product SOLD = US and Canada, PL = Yes, Canadian Tire Retailer Product  - submit thru to Completed status
	#Given [Shared Step 85328 - Login to WERCSmart - Canada - Address (Yes), Packaging (Yes), Stewardship (Full)]
	Given I login into the WERCSmart Portal - Canada has all data account
	Given I generate a random UPC number and save as: UPC86187
	Given I delete all products with UPC Number: saved as UPC86187
	And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	#And I In the shared step below select Chalk as your product type
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
	Then I save the product information as: TestCase86187
	#And I Make a note of the WPS ID shown at the top of the screen
	And I call Shared Step 85284 - Product Information - US & Canada, Child (No), OSHA (No), DSV (No), PLP (YES), GNFR (No), Continue
And I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
	And I call Shared Step 57637 (Regulatory Information 1 - TSCA & CEPA shown, No to PROP 65 - Continue - Happy Path)
	#And I In the shared step below  be sure to select Canadian Tire as the retailer
	And I call Shared Step 85990 - Retailers - PLP - Select one or more retailer and add PL information - Continue
		| Retailer      |
		| Canadian Tire |
	And I call Shared Step 75702 - UPC - Add UPC, Container type, Size and Package type (no retailer data needed) - Continue for UPC: saved as UPC86187, container type: Metal Container and size: 40
	And I call Shared Step 78868 - Regulatory Documents to Provide - US and Canada - Request authoring for both
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	And I call Shared Step 64097 - Additional Documents -> Contact Information - Add any Name, address, phone and emergency phone - Happy Path
	Given I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
		| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
	And I call Shared Step 57883 (Comments - Happy Path) and enter the comment: test comment
	And I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	#Depending on your subscription you will either see the Purchase summary success message or you will see the Purchase summary with you product details shown.  If the product details are shown click Confirm order
	Given If purchase details are showing click confirm order


	#And I call Shared Step 65080 (Login to Studio and Open SHA manager)

	And I call Shared Step 65080b (Login to Studio as user saved as: SHAQAAuto1 and Open SHA manager)

	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase86187)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase86187 and its status is: Submitted
	And I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase86187)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Assigned Status for saved as: TestCase86187)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase86187 and its status is: Assigned
	And I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase86187)
	And I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase86187)
	And I call Shared Step 78877 - WPS Studio - PD+ - set all data and publish using rule and doc queue - CKLT, NGHS, HSGH (EN and CF) and SBCS for saved as: TestCase86187
	And I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase86187)
	Given I call Shared Step 59066 (Go to SHA Manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase86187)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase86187 and its status is: Accepted or Completed
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase86187)
	Given I call Shared Step 51664 (SHA - Accepted Product - set Retailers to Completed for saved as: TestCase86187) for
		| Retailer |
		| CVS      |
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase86187)
	Then In the SHA manager I search for the Product saved as: TestCase86187 and if its Status is Accepted I set the retailers: to Completed and check the Products Grid
	| Retailer      |
	| Canadian Tire |
	

# Assigned to Barrett, Beverly
# NetProjects10\WercsSmart Portal\WERCSmart\Product set up and process to specific statuses
# NetProjects10\WercsSmart Portal\WERCSmart\Canadian Tire - Blue Box Program\New Product Submission\Submit and process to Completed\Account has Full Stewardship Data
@ScenarioId:1421
@philtag1
Scenario: [78864] Create a new simple product SOLD = US and Canada, PL = No, (Chalk) and submit thru to Completed status
	#Given I call Shared Step 85328 - Login to WERCSmart - Canada - Address (Yes), Packaging (Yes), Stewardship (Full)
	Given I login into the WERCSmart Portal - Canada has all data account
	Given I generate a random UPC number and save as: UPC78864
	Given I delete all products with UPC Number: saved as UPC78864
	And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
	Then I save the product information as: TestCase78864
	And I call Shared Step 62678 (Product Information - US & Canada, No Child, No OSHA, NO Direct ship, No PL, No NGFR - Continue, Happy path)
	And I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	And I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
	And I call Shared Step 132375 (Waste Classification Data - TSCA & CEPA shown, No to PROP 65 - Continue - Happy Path)
	#In the shared step below DO NOT select Canadian Tire as your retailer
	Given I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue) for
		| Retailer |
		| CVS      |
	And I call Shared Step 86293 - UPC - Package type shown but not required - Enter UPC, Container and size, Continue for UPC: saved as UPC78864
	And I call Shared Step 78868 - Regulatory Documents to Provide - US and Canada - Request authoring for both
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	And I call Shared Step 64097 - Additional Documents -> Contact Information - Add any Name, address, phone and emergency phone - Happy Path
	And I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
		| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
	And I call Shared Step 57883 (Comments - Happy Path) and enter the comment: Some test comment
	And I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given If purchase details are showing click confirm order
	#And I call Shared Step 65080 (Login to Studio and Open SHA manager)
	And I call Shared Step 65080b (Login to Studio as user saved as: SHAQAAuto1 and Open SHA manager)

	And I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase78864)
	And In the SHA manager grid I see the WPS ID I have saved as product: TestCase78864 and its status is: Submitted
	And I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase78864)
	And I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase78864)
	And In the SHA manager grid I see the WPS ID I have saved as product: TestCase78864 and its status is: Assigned
	And I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase78864)
	And I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase78864)
	And I call Shared Step 78877 - WPS Studio - PD+ - set all data and publish using rule and doc queue - CKLT, NGHS, HSGH (EN and CF) and SBCS for saved as: TestCase78864
	And I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase78864)
	And I call Shared Step 59066 (Go to SHA Manager)
	And I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase78864)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase78864 and its status is: Accepted
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase78864)
	Given I call Shared Step 51664 (SHA - Accepted Product - set Retailers to Completed for saved as: TestCase78864) for
		| Retailer |
		| CVS      |	
	And In the SHA manager grid I see the WPS ID I have saved as product: TestCase78864 and its status is: Completed

@ScenarioId:1423
Scenario: [85286] Create a new product SOLD = Canada, Private Label = Yes, NR product - Submission and process thru to completed
	#Given I call Shared Step 85328 - Login to WERCSmart - Canada - Address (Yes), Packaging (Yes), Stewardship (Full)]
	Given I login into the WERCSmart Portal - Canada has all data account
	And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	#And I In the shared step below use Crayon as your product type
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Crayon
	Then I save the product information as: TestCase85286
	And I call Shared Step 85730 - Product Information - Canada Only - Child (NO), GHS (NO), DSV (NO), PLP(YES), GNFR (NO), Continue
	And I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	And I call Shared Step 29181c (Ingredients - add any chemical - For Canada Only) with name: Sodium Hydroxide
	And I call Shared Step 57911 (Regulatory Information 1 - CEPA only shown - Continue - Happy Path)
	And I call Shared Step 86163 - Retailer - Canada Only & PL, Select No Retailer, Add PL, Continue
	And I call Shared Step 78884 - Regulatory Documents to Provide - Canada only - request authoring, upload label - Continue
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	And I call Shared Step 64097 - Additional Documents -> Contact Information - Add any Name, address, phone and emergency phone - Happy Path
	Given I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
		| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
	And I call Shared Step 57883 (Comments - Happy Path) and enter the comment: test
	And I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given If purchase details are showing click confirm order
	#And I call Shared Step 65080 (Login to Studio and Open SHA manager)
	And I call Shared Step 65080b (Login to Studio as user saved as: SHAQAAuto1 and Open SHA manager)

	And I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase85286)
	And I call Shared Step 49841 (SHA - Search for exact WPS ID in Submitted Status for saved as: TestCase85286)
	#And I Confirm your product is shown in the Submitted status.Note this may take a few minutes for the Zuora process to process your product, if it is not shown in Submitted wait a minute or two and re-search for your product
	And I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase85286)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase85286)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase85286 and its status is: Assigned
	And I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase85286)
	And I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase85286)
	And I call Shared Step 78888 - WPS Studio - PD+ - set all data and publish using rule and doc queue - CKLT, HGHS (EN and CF) and SBCS for product saved as TestCase85286
	And I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase85286)
	Given I call Shared Step 59066 (Go to SHA Manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase85286)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase85286 and its status is: Completed

# Assigned to Barrett, Beverly
# NetProjects10\WercsSmart Portal\WERCSmart\Product set up and process to specific statuses
# NetProjects10\WercsSmart Portal\WERCSmart\Canadian Tire - Blue Box Program\New Product Submission\Submit and process to Completed\Account has Full Stewardship Data
@ScenarioId:1422
Scenario: [78865] Create a new product SOLD = Canada only , PL = No, NR product - submit thru to Completed status (HGHS only)
	Given I login into the WERCSmart Portal - Canada has all data account
	Given I generate a random UPC number and save as: UPC78865
	Given I delete all products with UPC Number: saved as UPC78865
	And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
	Then I save the product information as: TestCase78865
	And I call Shared Step 78879 - Product Information - Canada Only - Child (NO), GHS (NO), DSV (NO), PLP (NO), GNFR (NO), Continue
	And I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	And I call Shared Step 29181c (Ingredients - add any chemical - For Canada Only) with name: Sodium hydroxide	
	And I call Shared Step 57911 (Regulatory Information 1 - CEPA only shown - Continue - Happy Path)
	And I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	And I call Shared Step 78884 - Regulatory Documents to Provide - Canada only - request authoring, upload label - Continue
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	And I call Shared Step 64097 - Additional Documents -> Contact Information - Add any Name, address, phone and emergency phone - Happy Path
	And I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
		| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
	And I call Shared Step 57883 (Comments - Happy Path) and enter the comment: Some test comment
	And I should see the Data Acceptance Page
	And I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	And in the Purchase Summary Screen I should see the following:
		| Item Description                                            |
		| Chemical assessment                                         |
		| Additional document Canada GHS SDS ENGLISH (USA)            |
		| Additional document language Canada GHS SDS FRENCH (CANADA) |
	Given If purchase details are showing click confirm order
	#And I call Shared Step 65080 (Login to Studio and Open SHA manager)
	And I call Shared Step 65080b (Login to Studio as user saved as: SHAQAAuto1 and Open SHA manager)

	And I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase78865)

	And In the SHA manager grid I see the WPS ID I have saved as product: TestCase78865 and its status is: Submitted
	And I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase78865)

	And I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase78865)
	And In the SHA manager grid I see the WPS ID I have saved as product: TestCase78865 and its status is: Assigned
	And I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase78865)
	And I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase78865)
	And I call Shared Step 78888 - WPS Studio - PD+ - set all data and publish using rule and doc queue - CKLT, HGHS (EN and CF) and SBCS for product saved as TestCase78865
	And I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase78865)
	Given I call Shared Step 59066 (Go to SHA Manager)
	And I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase78865)
	And In the SHA manager grid I see the WPS ID I have saved as product: TestCase78865 and its status is: Completed


# NetProjects10\WercsSmart Portal\WERCSmart\Product set up and process to specific statuses
# NetProjects10\WercsSmart Portal\WERCSmart\Canadian Tire - Blue Box Program\New Product Submission\Submit and process to Completed\Account has Full Stewardship Data
@ScenarioId:1576
Scenario: [86067] Create a new simple product SOLD = US and Canada, PL = Yes, (Chalk) and submit thru to Completed status
	Given I log in with the account saved in TReVor as: CanadaHasAddressPackaging
	Given I generate a random UPC number and save as: UPC86067
	Given I delete all products with UPC Number: saved as UPC86067
	And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
	Then I save the product information as: TestCase86067
And I call Shared Step 85284 - Product Information - US & Canada, Child (No), OSHA (No), DSV (No), PLP (YES), GNFR (No), Continue
	And I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
	And I call Shared Step 57637 (Regulatory Information 1 - TSCA & CEPA shown, No to PROP 65 - Continue - Happy Path)
	And I call Shared Step 85990 - Retailers - PLP - Select one or more retailer and add PL information - Continue
		| Retailer      |
		| Amazon        |
	And I call Shared Step 75702 - UPC - Add UPC, Container type, Size and Package type (no retailer data needed) - Continue for UPC: saved as UPC86067, container type: Metal Container and size: 40
	And I call Shared Step 78868 - Regulatory Documents to Provide - US and Canada - Request authoring for both
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	And I call Shared Step 64097 - Additional Documents -> Contact Information - Add any Name, address, phone and emergency phone - Happy Path
	Given I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
		| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
	And I call Shared Step 57883 (Comments - Happy Path) and enter the comment: test comment
	And I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given If purchase details are showing click confirm order
	#And I call Shared Step 65080 (Login to Studio and Open SHA manager)
	And I call Shared Step 65080b (Login to Studio as user saved as: SHAQAAuto1 and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase86067)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase86067 and its status is: Submitted
	And I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase86067)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Assigned Status for saved as: TestCase86067)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase86067 and its status is: Assigned
	And I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase86067)
	And I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase86067)
	And I call Shared Step 78877 - WPS Studio - PD+ - set all data and publish using rule and doc queue - CKLT, NGHS, HSGH (EN and CF) and SBCS for saved as: TestCase86067
	And I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase86067)
	Given I call Shared Step 59066 (Go to SHA Manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase86067)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase86067 and its status is: Accepted
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Accepted Status for saved as: TestCase86067)
	Given I call Shared Step 51664 (SHA - Accepted Product - set Retailers to Completed for saved as: TestCase86067) for
		| Retailer |
		| Amazon   |
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase86067)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase86067 and its status is: Completed


@ScenarioId:1577
Scenario: [86171] Create a new product SOLD = Canada only , PL = No, CT Retailer product - submit thru to Completed status (HGHS only)
	Given I generate a random UPC number and save as: UPC86171
	Given I log in with the account saved in TReVor as: CanadaHasAddressPackaging
	And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	And I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk
	Then I save the product information as: TestCase86171
	And I call Shared Step 62678 (Product Information - US & Canada, No Child, No OSHA, NO Direct ship, No PL, No NGFR - Continue, Happy path)
	And I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
	And I call Shared Step 57637 (Regulatory Information 1 - TSCA & CEPA shown, No to PROP 65 - Continue - Happy Path)
	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Canadian Tire
	And I call Shared Step 75702 - UPC - Add UPC, Container type, Size and Package type (no retailer data needed) - Continue for UPC: saved as UPC86171, container type: Metal Container and size: 40
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
	#And I call Shared Step 65080 (Login to Studio and Open SHA manager)
	And I call Shared Step 65080b (Login to Studio as user saved as: SHAQAAuto1 and Open SHA manager)

	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase86171)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase86171 and its status is: Submitted
	Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase86171)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase86171)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase86171 and its status is: Assigned
	Given I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase86171)
	Given I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase86171)
	Given I call Shared Step 75347 (WPS Studio - PD+ - set all data and publish using rule and Doc queue - CKLT, NGHS and SBCS) for product saved as: TestCase86171
	Given I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase86171)
	Given I call Shared Step 59066 (Go to SHA Manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase86171)
	Then In the SHA manager I search for the Product saved as: TestCase86171 and if its Status is Accepted I set the retailers: to Completed and check the Products Grid
	| Retailer      |
	| Canadian Tire |
	


@ScenarioId:6556
Scenario: [86170] Create a new product SOLD = Canada, Private Label = Yes, CT retailer product - Submission and process thru to completed
	Given I generate a random UPC number and save as: UPC86170
	Given I login into the WERCSmart Portal - Canada has all data account
	And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	And I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Crayon
	Then I save the product information as: TestCase86170
	And I call Shared Step 85730 - Product Information - Canada Only - Child (NO), GHS (NO), DSV (NO), PLP(YES), GNFR (NO), Continue
	And I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	And I call Shared Step 29181c (Ingredients - add any chemical - For Canada Only) with name: Sodium hydroxide
	And I call Shared Step 57911 (Regulatory Information 1 - CEPA only shown - Continue - Happy Path)
	And I call Shared Step 85990 - Retailers - PLP - Select one or more retailer and add PL information - Continue
		| Retailer      |
		| Canadian Tire |
	And I call Shared Step 75702 - UPC - Add UPC, Container type, Size and Package type (no retailer data needed) - Continue for UPC: saved as UPC86170, container type: Metal Container and size: 40
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
	#And I call Shared Step 65080 (Login to Studio and Open SHA manager)
	And I call Shared Step 65080b (Login to Studio as user saved as: SHAQAAuto1 and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase86170)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase86170 and its status is: Submitted
	Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase86170)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase86170)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase86170 and its status is: Assigned
	Given I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase86170)
	Given I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase86170)
	Given I call Shared Step 75347 (WPS Studio - PD+ - set all data and publish using rule and Doc queue - CKLT, NGHS and SBCS) for product saved as: TestCase86170
	Given I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase86170)
	Given I call Shared Step 59066 (Go to SHA Manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase86170)	
	Then In the SHA manager I search for the Product saved as: TestCase86170 and if its Status is Accepted I set the retailers: to Completed and check the Products Grid
	| Retailer      |
	| Canadian Tire |


@ScenarioId:1578
Scenario: [86395] Create a new simple product SOLD = US and Canada, PL = No, Canadian Tire retailer product (Chalk) and submit thru to Completed status
	Given I generate a random UPC number and save as: UPC86395
	Given I login into the WERCSmart Portal - Canada has all data account
	And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	And I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk
	Then I save the product information as: TestCase86395
	And I call Shared Step 62678 (Product Information - US & Canada, No Child, No OSHA, NO Direct ship, No PL, No NGFR - Continue, Happy path)
	And I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
	And I call Shared Step 57637 (Regulatory Information 1 - TSCA & CEPA shown, No to PROP 65 - Continue - Happy Path)
	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Canadian Tire
	And I call Shared Step 75702 - UPC - Add UPC, Container type, Size and Package type (no retailer data needed) - Continue for UPC: saved as UPC86395, container type: Metal Container and size: 40
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
	#And I call Shared Step 65080 (Login to Studio and Open SHA manager)
	And I call Shared Step 65080b (Login to Studio as user saved as: SHAQAAuto1 and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase86395)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase86395 and its status is: Submitted
	Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase86395)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase86395)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase86395 and its status is: Assigned
	Given I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase86395)
	Given I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase86395)
	Given I call Shared Step 75347 (WPS Studio - PD+ - set all data and publish using rule and Doc queue - CKLT, NGHS and SBCS) for product saved as: TestCase86395
	Given I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase86395)
	Given I call Shared Step 59066 (Go to SHA Manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase86395)	
	Then In the SHA manager I search for the Product saved as: TestCase86395 and if its Status is Accepted I set the retailers: to Completed and check the Products Grid
	| Retailer      |
	| Canadian Tire |


   @ScenarioId:6787
Scenario:[120866] UPC Retailer and Feed
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I generate a random UPC number and save as: UPC120866
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk
	Then I save the product information as: TestCase120866
	Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	And I call Shared Step 29181 (Ingredients - add any chemical) with name: Water
	And I call Shared Step 132370 (Waste Classification Data - TSCA (Random) - Prop 65 (No) - Continue - Happy Path)
	And In the 'Select Retailers' window I select the retailer: CVS
	And In the 'Select Retailers' window I select the retailer: Best Buy
	And I click continue
	And I call Shared Step 85909 (UPC - Confirm Package type link and drop down not shown - Add UPC data - Continue) for UPC: saved as UPC120866, container type: Plastic Container and size: 12 click continue
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Then in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	And I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
	| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
	| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
	And I call Shared Step 57883 (Comments - Happy Path) and enter the comment: test
	Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given If purchase details are showing click confirm order
	And I navigate to the home page

	#And I call Shared Step 65080 (Login to Studio and Open SHA manager)
	And I call Shared Step 65080b (Login to Studio as user saved as: SHAQAAuto1 and Open SHA manager)

	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase120866)
	Then I save all clients for product saved as: TestCase120866
	Given I call Shared Step 75309 (SHA > Select Product > UPC Retailer and Feed) for product saved as: TestCase120866
	And I confirm the Product UPC window has opened
	Then I check for the following columns in UPC Retailer and Feed
	| Column Name |
	| UPC Number  |
	| Pkg Type    |
	| Pkg Size    |
	Then I check that all clients for product saved as: TestCase120866 have data
