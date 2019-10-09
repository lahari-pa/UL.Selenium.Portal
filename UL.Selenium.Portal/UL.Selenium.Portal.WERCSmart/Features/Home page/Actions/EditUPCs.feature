@Shared
@wercsmart
@run_ActionsEditUPCs
@Login
@UlSolutionCenter
@Homepage
@ProductGrid
@ForwardProductRegistration
@NewProduct
@RetailPartners
@MessageCenter
@MyAccount
@LandingPage
@DocumentAcceptance
@DeleteActiveProducts
@Solutions
@ReviewDocuments
@SHA
@SummaryPage
@PaymentMethods
@ProductSetUp
@ViewUpcs

Feature: EditUPCs

@tfs_design
Scenario: [56220] My Products grid Actions - Edit UPCs
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then the WERCSmart homepage should load
	When I filter the products by: Sending to Retailers
	Given I save the ProductID and Name of the first Product in the grid as: FirstProduct
	And I click Row Actions for the most recent product returned
	Then I click on the Row Action: UPC Update
	And UNDER DEVELOPMENT

@ScenarioId:438
Scenario: [64528] Edit UPCs - Click Link check status in SHA
	Given I create a product and take to completed using Test Case 75335 and save as: ProductSetup64528
	Given I navigate to the landing page
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	And I search for the product saved as: ProductSetup64528
	And I click Row Actions for the first product returned
	Then I click on the Row Action: Edit UPCs
	And I should see the Universal Product Code (UPC) Page
	And I confirm that retailer "CV" is present under the 'Destination Retailers' column in the UPC table
	And I call Shared Step 65080 (Login to Studio and Open SHA manager)
	And I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: ProductSetup64528)
	And In the SHA manager grid I see the WPS ID I have saved as product: ProductSetup64528 and its font is red indicating a recertification
	And I call Shared Step 51351 (SHA > Select Product > View Recertification History) for product saved as: ProductSetup64528
	Given In the Product Recertification History popup I should see the following entry
		| Product ID                 | Recertification Reason | Active |
		| saved as ProductSetup64528 | 2.0 UPC Update         | true   |
	Given I Close the Product Recertification History pop up
	Given I navigate to the landing page
	And I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)

@ScenarioId:439
Scenario: [64529] Edit UPCs - Home - Actions links should show Process UPC Update and Remove UPC Update
	Given I create a product and take to completed using Test Case 75335 and save as: ProductSetup64529
	Given I navigate to the landing page
	And I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	And I search for the product saved as: ProductSetup64529
	And I click Row Actions for the first product returned
	Then I click on the Row Action: Edit UPCs
	And I should see the Universal Product Code (UPC) Page
	And I confirm that retailer "CV" is present under the 'Destination Retailers' column in the UPC table
	And I call Shared Step 65080 (Login to Studio and Open SHA manager)
	And I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: ProductSetup64529)
	And In the SHA manager grid I see the WPS ID I have saved as product: ProductSetup64529 and its font is red indicating a recertification
	And I call Shared Step 51351 (SHA > Select Product > View Recertification History) for product saved as: ProductSetup64529
	Given In the Product Recertification History popup I should see the following entry
		| Product ID                 | Recertification Reason | Active |
		| saved as ProductSetup64529 | 2.0 UPC Update         | true   |
	Given I Close the Product Recertification History pop up
	Given I navigate to the landing page
	And I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	And I search for the product saved as: ProductSetup64529
	And I click Row Actions for the first product returned
	And I should see the following Actions options
		| Option             |
		| Discontinue        |
		| View               |
		| View UPCs          |
		| Process UPC Update |
		| Remove UPC Update  |
		| Monitor Progress   |

@ScenarioId:440
Scenario: [64530] Process UPC Update
	Given I create a product and take to completed using Test Case 75335 and save as: ProductSetup64530
	Given I generate a random UPC number and save as: UPC64530
	Given I navigate to the landing page
	#And I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I log in with the account saved in TReVor as: ProductAccount
	And I search for the product saved as: ProductSetup64530
	And I click Row Actions for the first product returned
	Then I click on the Row Action: Edit UPCs
	And I should see the Universal Product Code (UPC) Page
	And I confirm that retailer "CV" is present under the 'Destination Retailers' column in the UPC table
	And I navigate to the home page
	And I search for the product saved as: ProductSetup64530
	And I click Row Actions for the first product returned
	Then I click on the Row Action: Process UPC Update
	And I should see the Universal Product Code (UPC) Page
	And I call Shared Step 75307 (Edit UPC - Add UPC and all data - Click Save) for UPC Number saved as: "UPC64530", container type: "Plastic Container", size: "10"
	And I should see the Data Acceptance Page
	Then In the Data Acceptance page I select Yes, Agreed
	And In the Data Acceptance page I click on the Accept button
	And the Purchase Summary should load
	And I navigate to the home page
	And I call Shared Step 65080 (Login to Studio and Open SHA manager)
	#And I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: ProductSetup64530)
	Given In the SHA Manager Grid I run a search for product saved as: ProductSetup64530 and its status is: Recertification
	And I call Shared Step 75309 (SHA > Select Product > UPC List) for product saved as: ProductSetup64530
	And I confirm UPC number saved as: "UPC64530" is displayed in the SHA Manager Product UPC list
	And I close the window that opened

@ScenarioId:441
Scenario: [64531] Remove UPC Update - Cancel
	Given I create a product and take to completed using Test Case 75335 and save as: ProductSetup64531
	Given I navigate to the landing page
	And I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	And I search for the product saved as: ProductSetup64531
	And I click Row Actions for the first product returned
	Then I click on the Row Action: Edit UPCs
	And I should see the Universal Product Code (UPC) Page
	And I confirm that retailer "CV" is present under the 'Destination Retailers' column in the UPC table
	And I navigate to the home page
	And I call Shared Step 65080 (Login to Studio and Open SHA manager)
	And I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: ProductSetup64531)
	And In the SHA manager grid I see the WPS ID I have saved as product: ProductSetup64531 and its font is red indicating a recertification
	And I call Shared Step 51351 (SHA > Select Product > View Recertification History) for product saved as: ProductSetup64531
	Given In the Product Recertification History popup I should see the following entry
		| Product ID                 | Recertification Reason | Active |
		| saved as ProductSetup64531 | 2.0 UPC Update         | true   |
	Given I Close the Product Recertification History pop up
	Given I navigate to the landing page
	And I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	And I search for the product saved as: ProductSetup64531
	And I click Row Actions for the first product returned
	Then I click on the Row Action: Remove UPC Update
	And I confirm the Remove UPC Update popup displays the warning: Are you sure you want to restore the following Product ?
	And I confirm the Remove UPC Update popup displays the name and ID for product saved as: ProductSetup64531
	Given in the modal dialog I click cancel
	And I confirm the Remove UPC Update popup has closed
	And I click Row Actions for the first product returned
	And I should see the following Actions options
		| Option             |
		| Discontinue        |
		| View               |
		| View UPCs          |
		| Process UPC Update |
		| Remove UPC Update  |
		| Monitor Progress   |

@ScenarioId:442
Scenario: [64532] Remove UPC Update - Remove
	Given I create a product and take to completed using Test Case 75335 and save as: ProductSetup64532
	Given I navigate to the landing page
	And I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	And I search for the product saved as: ProductSetup64532
	And I click Row Actions for the first product returned
	Then I click on the Row Action: Edit UPCs
	And I should see the Universal Product Code (UPC) Page
	And I confirm that retailer "CV" is present under the 'Destination Retailers' column in the UPC table
	And I navigate to the home page
	And I call Shared Step 65080 (Login to Studio and Open SHA manager)
	And I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: ProductSetup64532)
	And In the SHA manager grid I see the WPS ID I have saved as product: ProductSetup64532 and its font is red indicating a recertification
	And I call Shared Step 51351 (SHA > Select Product > View Recertification History) for product saved as: ProductSetup64532
	#20/03/2019 CLF Changed recertification from 2.0 Specific UPC Update to 2.0 UPC Update
	Given In the Product Recertification History popup I should see the following entry
		| Product ID                 | Recertification Reason | Active |
		| saved as ProductSetup64532 | 2.0 UPC Update         | true   |
	Given I Close the Product Recertification History pop up
	Given I navigate to the landing page
	And I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	And I search for the product saved as: ProductSetup64532
	And I click Row Actions for the first product returned
	Then I click on the Row Action: Remove UPC Update
	And in the modal dialog I click the "REMOVE" button
	And I confirm the Remove UPC Update popup has closed
	And I should not see the following Actions options
		| Option             |
		| Process UPC Update |
		| Remove UPC Update  |
	And I call Shared Step 65080 (Login to Studio and Open SHA manager)
	And I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: ProductSetup64532)
	And In the SHA manager grid I see the WPS ID I have saved as product: ProductSetup64532 and its font is not red indicating a recertification
	And I call Shared Step 51351 (SHA > Select Product > View Recertification History) for product saved as: ProductSetup64532
	And I confirm there is no product entry listed with Recertification Reason: 2.0 Specific UPC Update
	Given I Close the Product Recertification History pop up
