@Shared
@LandingPage
@run_EditUPCAccParStwd
@Login
@Homepage
@Signup
@wercsmart
@NewProduct
@ProductGrid
@DataSummarySheet
@RetailPartners
@SummaryPage
@PaymentMethods
@SubEnrollment
@WERCSmart_Signup
@MyAccount
@PackagingTypes
@Brands
@MyIngredients
@UPC
@SHA
@ForwardProductRegistration
@ProductSetUp
Feature: Edit UPC Account has partial Stewardship information

@ScenarioId:1472
Scenario: [86257] Edit UPC - Product SOLD = Canada only, PL = Yes, Retailer = Canadian Tire, Packing type is required
	Given I generate a random UPC number and save as: UPC86257
	Given I log in with the account saved in TReVor as: CanadaHasPackandPartialStewardship
	Given I create a Crayon product and take to completed using Test Case 86116 and save as: TestCase86257 with upc: UPC86257
	Given I navigate to the landing page
	Given I log in with the account saved in TReVor as: CanadaHasPackandPartialStewardship
	Then the WERCSmart homepage should load
	Given I search for the product saved as: TestCase86257
	When I click Row Actions for the most recent product returned
	Then I click on the Row Action: Edit UPCs
	Given I call Shared Step 87337 (Edit UPC - data - Click Save) for UPC as: saved as UPC86257, container type: Cardboard and size: 2 and packaging type: Package Type
	And I Select a package type from the drop down list
	And I click Save in The Product Page
	Given In the Data Acceptance page I click on the Accept button
	And I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase86257)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase86257 and its status is: Recertification
	Given I call Shared Step 75309 (SHA > Select Product > UPC Retailer and Feed) for product saved as: TestCase86257
	Then In the SHA list of UPCs I should see UPC: saved as UPC86257

@ScenarioId:1473
Scenario: [86258] Edit UPC - Product SOLD = Canada only, PL = No, Retailer = Canadian Tire - Package type required
	Given I generate a random UPC number and save as: UPC86258
	Given I log in with the account saved in TReVor as: CanadaHasPackandPartialStewardship
	Given I create a Crayon product and take to completed using Test Case 86454 and save as: TestCase86258
	Given I navigate to the landing page
	Given I log in with the account saved in TReVor as: CanadaHasPackandPartialStewardship
	Then the WERCSmart homepage should load
	Given I search for the product saved as: TestCase86258
	When I click Row Actions for the most recent product returned
	Then I click on the Row Action: Edit UPCs
	Given I call Shared Step 87337 (Edit UPC - data - Click Save) for UPC as: saved as UPC86258, container type: Cardboard and size: 2 and packaging type: Package Type
	And I Select a package type from the drop down list
	And I click Save in The Product Page
	Given In the Data Acceptance page I click on the Accept button
	And I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase86258)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase86258 and its status is: Recertification
	Given I call Shared Step 75309 (SHA > Select Product > UPC Retailer and Feed) for product saved as: TestCase86258
	Then In the SHA list of UPCs I should see UPC: saved as UPC86258

@ScenarioId:6228
Scenario: [86259] Edit UPC - Product SOLD = US & Canada, PL = Yes, Retailer Not Canadian Tire, package type is not required
	Given I generate a random UPC number and save as: UPC86259
	Given I generate a random UPC number and save as: UPC862591
	Given I log in with the account saved in TReVor as: CanadaHasPackandPartialStewardship
	Given I create a Chalk product and take to completed using Test Case 86114 and save as: TestCase86259
	Given I navigate to the landing page
	Given I log in with the account saved in TReVor as: CanadaHasPackandPartialStewardship
	Then the WERCSmart homepage should load
	Given I search for the product saved as: TestCase86259
	When I click Row Actions for the most recent product returned
	Then I click on the Row Action: Edit UPCs
	Then I call Shared Step 86293 - UPC - Package type shown but not required - Enter UPC, Container and size, Continue for UPC: saved as UPC862591
	Given I call Shared Step 87337 (Edit UPC - data - Click Save) for UPC as: saved as UPC86259, container type: Cardboard and size: 2 and packaging type: Package Type
	##And I Select a package type from the drop down list
	#And I click Save in The Product Page
	Given In the Data Acceptance page I click on the Accept button
	And I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase86259)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase86259 and its status is: Recertification
	Given I call Shared Step 75309 (SHA > Select Product > UPC Retailer and Feed) for product saved as: TestCase86259
	Then In the SHA list of UPCs I should see UPC: saved as UPC862591

@ScenarioId:1474
Scenario: [86260] Edit UPC - Product SOLD = US & Canada, PL = No, Retailer = Canadian Tire - Package type required
	Given I generate a random UPC number and save as: UPC86260
	Given I log in with the account saved in TReVor as: CanadaHasPackandPartialStewardship
	Given I create a Crayon product and take to completed using Test Case 86458 and save as: TestCase86260
	Given I navigate to the landing page
	Given I log in with the account saved in TReVor as: CanadaHasPackandPartialStewardship
	Then the WERCSmart homepage should load
	Given I search for the product saved as: TestCase86260
	When I click Row Actions for the most recent product returned
	Then I click on the Row Action: Edit UPCs
	Given I call Shared Step 87337 (Edit UPC - data - Click Save) for UPC as: saved as UPC86260, container type: Cardboard and size: 2 and packaging type: Package Type
	And I Select a package type from the drop down list
	And I click Save in The Product Page
	Given In the Data Acceptance page I click on the Accept button
	And I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase86260)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase86260 and its status is: Recertification
	Given I call Shared Step 75309 (SHA > Select Product > UPC Retailer and Feed) for product saved as: TestCase86260
	Then In the SHA list of UPCs I should see UPC: saved as UPC86260


@ScenarioId:6787
Scenario:[120866] UPC Retailer and Feed
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I generate a random UPC number and save as: UPC120866
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk
	Then I save the product information as: TestCase120866
	Given I call Shared Step 26897 (Product Characteristics - Solid only available - continue)
	Given I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	And I call Shared Step 29181 (Ingredients - add any chemical) with name: Water
	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	And In the 'Select Retailers' window I select the retailer: Costco
	And I click continue
	And I call Shared Step 85909 (UPC - Confirm Package type link and drop down not shown - Add UPC data - Continue) for UPC: saved as UPC120866, container type: Plastic Container and size: 12 click continue
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Then in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	And I call Shared Step 64097 - Additional Documents -> Contact Information - Add any Name, address, phone and emergency phone - Happy Path
	And I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
	| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
	| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
	And I call Shared Step 57883 (Comments - Happy Path) and enter the comment: test
	Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given If purchase details are showing click confirm order
	And I navigate to the home page

	And I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase120866)
	Given I call Shared Step 75309 (SHA > Select Product > UPC Retailer and Feed) for product saved as: TestCase120866
	Then I check for the following columns in UPC Retailer and Feed
	| Column Name |
	| UPC Number  |
	| Pkg Type    |
	| Pkg Size    |
