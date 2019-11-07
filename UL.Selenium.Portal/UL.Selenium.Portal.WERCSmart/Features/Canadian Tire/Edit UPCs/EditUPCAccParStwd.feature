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
	Given I call Shared Step 75309 (SHA > Select Product > UPC List) for product saved as: TestCase86257
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
	Given I call Shared Step 75309 (SHA > Select Product > UPC List) for product saved as: TestCase86258
	Then In the SHA list of UPCs I should see UPC: saved as UPC86258


Scenario: [86259] Edit UPC - Product SOLD = US & Canada, PL = Yes, Retailer Not Canadian Tire, package type is not required
	Given I generate a random UPC number and save as: UPC86259
	Given I generate a random UPC number and save as: UPC_862591
	Given I log in with the account saved in TReVor as: CanadaHasPackandPartialStewardship
	Given I create a Chalk product and take to completed using Test Case 86114 and save as: TestCase86259
	Given I navigate to the landing page
	Given I log in with the account saved in TReVor as: CanadaHasPackandPartialStewardship
	Then the WERCSmart homepage should load
	Given I search for the product saved as: TestCase86259
	When I click Row Actions for the most recent product returned
	Then I click on the Row Action: Edit UPCs
	Then I call Shared Step 86293 - UPC - Package type shown but not required - Enter UPC, Container and size, Continue for UPC: saved as UPC_862591
	#Given I call Shared Step 87337 (Edit UPC - data - Click Save) for UPC as: saved as UPC86259, container type: Cardboard and size: 2 and packaging type: Package Type
	##And I Select a package type from the drop down list
	#And I click Save in The Product Page
	Given In the Data Acceptance page I click on the Accept button
	And I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase86259)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase86259 and its status is: Recertification
	Given I call Shared Step 75309 (SHA > Select Product > UPC List) for product saved as: TestCase86259
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
	Given I call Shared Step 75309 (SHA > Select Product > UPC List) for product saved as: TestCase86260
	Then In the SHA list of UPCs I should see UPC: saved as UPC86260



