@Shared
@wercsmart
@run_Actions
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
Feature: Actions

# Assigned to Amanda Coutant
# Created by Amanda Coutant
# Test case can be found at the following paths:
# NetProjects10\WercsSmart Portal\WERCSmart\Home Page\Actions\View UPCs
@ScenarioId:1207
Scenario: [73424] View UPCs - Product with UPCs
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Then the WERCSmart homepage should load
	# search for product with name 'Product73424' in submitted status?
	And I create a product and save as: TestCase73424 and name as: Product73424
	Then I navigate to the home page
	Given I search for the product saved as: TestCase73424
	And I click Row Actions for the first product returned
	And I click on the Row Action: View UPCs
	And I switch to the tab with title: View UPCs
	And I save the UPCs associated to the product as: TestCase73424UPCs
	And I call Shared Step 65080 (Login to Studio and Open SHA manager)
	And I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase73424)
	And I call Shared Step 75309 (SHA > Select Product > UPC List) for product saved as: TestCase73424
	And I confirm all UPC numbers in the list saved as: TestCase73424UPCs are displayed in the SHA Manager Product UPC list
	And I close the window that opened

@ScenarioId:1206
Scenario: [63663] Obsoleting/Deleting a Product (not submitted status)
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given If I see the retail partners page I set all data consent tiers to true for all retailers in the top section
	Then The home screen should load
	Then I click the Register New Product icon in the Navigation Pane
	And I Select the Create a New Registration radio button
	And in the New Product page I click Continue
	And I set 'Product Name' to: Soap63663
	#And In the Product Type tab of the New Product Page, I enter: Soap (Bar, Liquid) for Body in the Type of Product select field
	And I set 'Type of Product' to: Soap (Bar, Liquid) for Body
	And in the New Product page I click Continue
	Then I save the product information as: TestCase63663
	And I set the Primary Physical State to be: Solid
	And I set the Secondary Physical State to be: Solid
	And I set the When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5? option to: No
	And I set the Select the best Water Solubility description to be: Very soluble
	And in the New Product page I click Continue
	Given I navigate to the home page
	Then I delete the product: TestCase63663

#pass - staging 4.10
@ScenarioId:430
Scenario: [56212] My Products grid Actions - Edit Navigation
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then the WERCSmart homepage should load
	When I filter the products by: Not Yet Submitted
	Given I save the ProductID and Name of the first Product in the grid as: FirstProduct
	When I click Row Actions for the most recent product returned
	Then I click on the Row Action: Edit
	Then the Product Editor page should be loaded
	And the product saved as: FirstProduct should be visible in editor

@ScenarioId:431
Scenario: [56214] My Products grid Actions - Submit navigation
	Given I generate a random UPC number and save as: UPC56214
	And I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	And I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk
	Then I save the product information as: TestCase56214
	And I call Shared Step 26897 (Product Characteristics - Solid only available - continue)
	And I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	And I call Shared Step 29181 (Ingredients - add any chemical) with name: Chlorine
	And I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	#And I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	#And I call Shared Step 71618 (U. S. Department of Transportation (DOT) Classification - For Alcohol (Packaging III))
	#And I call Shared Step 63219 (Retailer Association - Select No Retailer - Click continue)
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	And I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
		| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
	Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: Test
	And I navigate to the home page
	And I filter the products by: Not Yet Submitted
	And I search for the product saved as: TestCase56214
	When I click Row Actions for the most recent product returned
	Then I click on the Row Action: Submit
	And I should see the Data Acceptance Page
	And I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)

@ScenarioId:432
Scenario: [56216] My Products grid Actions - Delete Navigation
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then the WERCSmart homepage should load
	Then I click the Register New Product icon in the Navigation Pane
	And the Product Editor page should be loaded
	Then I create a shell product with name TestProduct saved as TestProduct
	Then I navigate to the home page
	Given I search for the product saved as: TestProduct
	When I click Row Actions for the most recent product returned
	Then I click on the Row Action: Delete
	And I cancel the Delete Dialog
	Then I should see products in the Product Grid
	#Given I save the number of items in the pie chart
	When I click Row Actions for the most recent product returned
	Then I click on the Row Action: Delete
	And I confirm the Delete Dialog
	Then I should not see products in the Product Grid

# Removing this step as multiple tests are creating products simultaneously - can't guarantee the count =-1 since deleting the product and refreshing
#Then the number of items in the pie chart should be one less than the figure I saved
@ScenarioId:433
Scenario: [56218] My Products grid Actions - View Navigation
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then the WERCSmart homepage should load
	When I filter the products by: Assessment in Progress
	And I click Row Actions for the most recent product returned
	Then I click on the Row Action: View
	Then A Summary page should open in a new browser tab
	Then I should not seen an Accept button
	Given I close the browser tab with the Summary page

@ScenarioId:434
Scenario: [56219] My Products grid Actions - Documents navigation
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then the WERCSmart homepage should load
	Then I create a product with sds upload and name as: product1 then take to data acceptance and save as: TC56219
	Then I navigate to the home page
	Given I search for the product saved as: TC56219
	When I click Row Actions for the most recent product returned
	Then I click on the Row Action: Documents
	And I should see Review Documents
	Then In the Documents section I should see the following columns: Document Name, Subformat, Language, Actions
	Given I click on the View link of the first document in Supplier Uploaded
	Then a document should open
	Given I close the document

@tfs_design
Scenario: [56220] My Products grid Actions - Edit UPCs
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then the WERCSmart homepage should load
	When I filter the products by: Sending to Retailers
	Given I save the ProductID and Name of the first Product in the grid as: FirstProduct
	And I click Row Actions for the most recent product returned
	Then I click on the Row Action: UPC Update
	And UNDER DEVELOPMENT

#And I click the first instance of Actions - Edit UPC in the products grid
#Then I should see the Universal Product Code (UPC) Page
#And I confirm that retailer "WM" is present under the 'Destination Retailers' column in the UPC table
# HomePage/ Actions/ Edit UPCs
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

# Assigned to Barrett, Beverly
# Created by Barrett, Beverly
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

# Assigned to Barrett, Beverly
# Created by Barrett, Beverly
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
