@Shared
@LandingPage
@run_EditUPCAccParStwd2
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
Feature: Edit UPC Account has partial Stewardship information 2

@ScenarioId:1477
Scenario: [86462] Edit UPC - Product SOLD = US & Canada, PL = No, Retailer = Canadian Tire - Package type required
	Given I generate a random UPC number and save as: UPC86462
	Given I log in with the account saved in TReVor as: CanadaHasPackandPartialStewardship
	Given I create a Crayon product and take to completed using Test Case 86455 and save as: TestCase86462
	Given I navigate to the landing page
	Given I log in with the account saved in TReVor as: CanadaHasPackandPartialStewardship
	Then the WERCSmart homepage should load
	Given I search for the product saved as: TestCase86462
	When I click Row Actions for the most recent product returned
	Then I click on the Row Action: Edit UPCs
	Given I call Shared Step 87337 (Edit UPC - data - Click Save) for UPC as: saved as UPC86462, container type: Cardboard and size: 2 and packaging type: Package Type
	And I Select a package type from the drop down list
	And I click Save in The Product Page
	Given In the Data Acceptance page I click on the Accept button
	And I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase86462)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase86462 and its status is: Recertification
	Given I call Shared Step 75309 (SHA > Select Product > UPC List) for product saved as: TestCase86462
	Then In the SHA list of UPCs I should see UPC: saved as UPC86462


@ScenarioId:1478
Scenario: [86463] Edit UPC - Product SOLD = US & Canada, PL = No, Retailer NOT CT - Package type not required
	Given I generate a random UPC number and save as: UPC86463
	Given I generate a random UPC number and save as: UPC864631
	Given I log in with the account saved in TReVor as: CanadaHasPackandPartialStewardship
	Given I create a Chalk product and take to completed using Test Case 86115 and save as: TestCase86463
	Given I navigate to the landing page
	Given I log in with the account saved in TReVor as: CanadaHasPackandPartialStewardship
	Then the WERCSmart homepage should load
	Given I search for the product saved as: TestCase86463
	When I click Row Actions for the most recent product returned
	Then I click on the Row Action: Edit UPCs
	Then I call Shared Step 86293 - UPC - Package type shown but not required - Enter UPC, Container and size, Continue for UPC: saved as UPC864631
	#Given I call Shared Step 87337 (Edit UPC - data - Click Save) for UPC as: saved as UPC86463, container type: Cardboard and size: 2 and packaging type: Package Type
	#And I Select a package type from the drop down list
	#And I click Save in The Product Page
	Given In the Data Acceptance page I click on the Accept button
	And I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase86463)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase86463 and its status is: Recertification
	Given I call Shared Step 75309 (SHA > Select Product > UPC List) for product saved as: TestCase86463
	Then In the SHA list of UPCs I should see UPC: saved as UPC864631


@ScenarioId:1476
Scenario: [86264] Edit UPC - Product SOLD = US & Canada, PL = No, Retailer Canadian Tire  - Package type required
	Given I generate a random UPC number and save as: UPC86264
	Given I log in with the account saved in TReVor as: CanadaHasAddressPackaging
	Given I create a Chalk product and take to completed using Test Case 86419 and save as: TestCase86264
	Given I navigate to the landing page
	Given I log in with the account saved in TReVor as: CanadaHasAddressPackaging
	Then the WERCSmart homepage should load
	Given I search for the product saved as: TestCase86264
	When I click Row Actions for the most recent product returned
	Then I click on the Row Action: Edit UPCs
	Given I call Shared Step 87337 (Edit UPC - data - Click Save) for UPC as: saved as UPC86264, container type: Cardboard and size: 2 and packaging type: Package Type
	And I Select a package type from the drop down list
	And I click Save in The Product Page
	Given In the Data Acceptance page I click on the Accept button
	And I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase86264)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase86264 and its status is: Recertification
	Given I call Shared Step 75309 (SHA > Select Product > UPC List) for product saved as: TestCase86264
	Then In the SHA list of UPCs I should see UPC: saved as UPC86264


@ScenarioId:1475
	Scenario: [86261] Edit UPC - Product SOLD = Canada only, PL = Yes, Retailer = Canadian Tire, Packing type is required
	Given I generate a random UPC number and save as: UPC86261
	Given I log in with the account saved in TReVor as: CanadaHasAddressPackaging
	Given I create a Crayon product and take to completed using Test Case 86116 and save as: TestCase86261 with upc: UPC86261
	Given I navigate to the landing page
	Given I log in with the account saved in TReVor as: CanadaHasAddressPackaging
	Then the WERCSmart homepage should load
	Given I search for the product saved as: TestCase86261
	When I click Row Actions for the most recent product returned
	Then I click on the Row Action: Edit UPCs
	Given I call Shared Step 87337 (Edit UPC - data - Click Save) for UPC as: saved as UPC86261, container type: Cardboard and size: 2 and packaging type: Package Type
	And I Select a package type from the drop down list
	And I click Save in The Product Page
	Given In the Data Acceptance page I click on the Accept button
	And I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase86261)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase86261 and its status is: Recertification
	Given I call Shared Step 75309 (SHA > Select Product > UPC List) for product saved as: TestCase86261
	Then In the SHA list of UPCs I should see UPC: saved as UPC86261
