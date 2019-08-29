@wercsmart
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
@run_BulkActions
Feature: BulkActions

@TReVorId:18968
Scenario: [56223] Bulk Actions - Forward Product Registration navigation
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then the WERCSmart homepage should load
	Given I click Bulk Actions in the Products Grid
	And I click Forward Product Registration in the Bulk Actions window
	Then I should see the header: Forward Product Registration on the Forward Product Registration window
	And I should see the subheading 3: Select Products & UPCs on the Forward Product Registration window

#This test cases uses the ULSC account
@TReVorId:18970
Scenario: [56224] Bulk Actions - Sync Products to WERCSLink navigation
	Given I Login into WERCSmart Portal - Admin Role - WERCs ULSC Account
	Then the WERCSmart homepage should load
	Given I click Bulk Actions in the Products Grid
	And I click Sync Products in the Bulk Actions window
	And I should see the header: Sync Products to ULSC on the Sync Products to ULSC window
	Then I click on the cancel button on the ULSC Sync popup
	And I should see the Subheading Alerts in the main window

@TReVorId:18972
Scenario: [56225] Bulk Actions - Accept Documents navigation
	Given I Login into WERCSmart Portal - Admin Role - WERCs Visual Account
	Then the WERCSmart homepage should load
	Given I click Bulk Actions in the Products Grid
	And I click Accept Documents in the Bulk Actions window
	And I should see the header: Document Acceptance on the Document Acceptance window

@TReVorId:18973
Scenario: [56227] Bulk Actions  Delete Products navigation
	Given I Login into WERCSmart Portal - Admin Role - WERCs Visual Account
	Then the WERCSmart homepage should load
	Given I click Bulk Actions in the Products Grid
	And I click Delete Products in the Bulk Actions window
	And I should see the header: Delete Active Products on the Delete Active Product window

@TReVorId:18399
Scenario: [74634] Forward Product Registration - Only can select product once
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I filter the products by: Sending to Retailers
	Given I save the list of Product IDs displayed on the page as: ProductInProgressList74634
	Given I click Bulk Actions in the Products Grid
	Then I should see a popup with header Bulk Actions
	Given I click Forward Product Registration in the Bulk Actions window
	Then I should see the header: Forward Product Registration on the Forward Product Registration window
	And I confirm the active Forward Product Registration tab is: Select Products
	Given I select the product with ID saved as: ProductInProgressList74634 under the Select Products tab
	#Given I click Bulk Actions in the Products Grid
	#Then I should see a popup with header Bulk Actions
	#Given I click Forward Product Registration in the Bulk Actions window
	#Then I should see the header: Forward Product Registration on the Forward Product Registration window
	#Given I enter the text: 1 in the 'Search by WPS ID or Product Name' field
	#Given I save first selectable Product ID as: SelectProductsID74634 under the Select Products tab
	#Given I select the product with ID saved as: SelectProductsID74634 under the Select Products tab and the checkbox is disabled while the page is working
	#Given I select the product with ID saved as: SelectProductsID74634 under the Select Products tab
	#Then I confirm that the product checkbox is disabled while the page is working
	And I confirm I am unable to select the product with ID saved as: ProductInProgressList74634 under the Select Products tab
	Given I click the Home navigation icon and accept the alert popup

@TReVorId:18974
Scenario: [76314] Forward Product - NR should Not Require UPC
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I filter the products by: Assessment in Progress
	Given I save the list of Product IDs displayed on the page as: ProductInProgressList76314
	Given I click Bulk Actions in the Products Grid
	Then I should see a popup with header Bulk Actions
	Given I click Forward Product Registration in the Bulk Actions window
	Then I should see the header: Forward Product Registration on the Forward Product Registration window
	And I confirm the active Forward Product Registration tab is: Select Products
	Given I select the product with ID saved as: ProductInProgressList76314 under the Select Products tab
	Given I click continue on the Forward Product Registration page
	Then I confirm the active Forward Product Registration tab is: Select Retailers
	Given in the Select Retailers tab under Forward Product Registration I select the retailer: No Retailer/No UPC Product
	Given I click continue on the Forward Product Registration page
	Then I confirm the active Forward Product Registration tab is: Select UPCs
	Given I select the first product under the Select UPCs tab
	Given I click the Add To No Retailer button under the Select UPCs tab
	And I select the UPC row: 'No UPC'/ 'No Retailer'
	Given I click continue on the Forward Product Registration page
	Then I confirm the active Forward Product Registration tab is: Product Results
	Given I click continue on the Forward Product Registration page
	Then I confirm the active Forward Product Registration tab is: Review & Submit
	Given I select the true radio for the 'Are Statements True' question under the Review and Submit tab
	Given I click continue on the Forward Product Registration page
	# Confirm product has been forward properly (Message: Thank you for registering your product on WERCSmart for assessment.)
	Given I navigate to the home page

@tfs_design
@TReVorId:22232
Scenario: [76056] Bulk Actions- Include Subformat Column for Document List
	Given I login as the administrator
	Then The home screen should load
	Given I click Bulk Actions in the Products Grid
	Then I should see a popup with header Bulk Actions
	Given I click Accept Documents in the Bulk Actions window
	Then I should see the header: Document Acceptance on the Document Acceptance window
	Then I confirm there are products listed under My Products on the Document Acceptance page and save as: DocumentAcceptanceProducts
	Given I select the first product from My Products saved as: DocumentAcceptanceProducts which contains a document
	Given I save the displayed Documents on the Document Acceptance page as: DocumentAcceptanceDocuments
	Then I confirm the Subformat column appears as part of the Documents Information
	Given I click on View under Actions for the first document from the list saved as: DocumentAcceptanceDocuments
	Then I confirm a new window opens displaying the document url: ViewWercsDocument
	# This is currently blocked - downloading pdf through chrome viewer is not reliable so need to fetch the file directly from the API
	Given I confirm the subformat type at the top of the document matches the vaulue in the Documents table for the first document I viewed
	Given I close the window that opened
	Given I navigate to the home page

@ForwardProductRegistration
@TReVorId:22386
Scenario: [75321] Forward Product - Completed Status (NO Recert)
	Given I create a product and take to completed using Test Case 75335 and save as: TestCase75321
	Given I navigate to the landing page
	And I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	And I filter the products by: Accepted by Retailers
	And I Confirm the Products shown display the Green Colour Status - which is the Accepted by Retailers
	And I filter for the product saved as: TestCase75321
	And I call Shared Step 75130 - Bulk Actions - Select Forward Product Registration
	Then I should see the header: Forward Product Registration on the Forward Product Registration window
	And I enter the text: saved as TestCase75321 in the 'Search by WPS ID or Product Name' field
	And In the Foward Product Registration Screen I should see product: saved as TestCase75321
	And In the Foward Product Registration Screen I Select the product: saved as TestCase75321
	And I click continue on the Forward Product Registration page
	#And I Select a "NEW" Retailer which you know is not already associated to the product (should not be present on the note you made earlier)
	And In the Forward Product Registration Screen I select a retailer under Other Retailers and save as TestCase75321Retailer
	And I Click 'CONTINUE'
	And [Shared Step 75140 - Forwarding - Select Products & UPCs step - Add Any missing data and select 1 UPC - Continue]
	And I The 'Product Results Tab' is selected
	And I Confirm that the UPC Number displays the recently selected "Retailer"(Step 17)
	And I Confirm that NO Errors display for the Product
	And I Click 'CONTINUE'
	And I The 'Review and Submit' step is shown
	And I Select the "All of the above statements are true" Radio Button
	And I Click 'CONTINUE'
	And I Confirm the Purchase Summary page is shown with the success message shown" Thank you for registering your product on WERCSmart for assessment. The retailers may receive your assessment in approximately two (2) business days, if no delays in processing the assessment, and should no data issues arise.  "
	And I Click on the 'HOME BUTTON'
	And I In SHA Manager
	And I In the shared step below search for your product using the WPS ID you noted earlier
	And I call Shared Step 49841 (SHA - Search for exact WPS ID in (.*) Status for saved as: (.*))
	And I Confirm the Product shows a "Completed Status" for the Original Retailer(see Clients column)
	And I Confirm the Productshows a "Submitted Status" for the recently selected Retailer (see clients column)
	And [Shared Step 75309 - SHA > Select Product > UPC List]
	And I With the SHA Manager Product UPC window open - Click on the 'maximize' icon to expand the view of the window
	And I Confirm the recently added Retailer(s)is (are) shown against the UPC you selected
	And I Close the SHA Manager Product UPC window
	And I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: (.*))
	And I In the shared step below search for the Product you are working with
	And I call Shared Step 49841 (SHA - Search for exact WPS ID in (.*) Status for saved as: (.*))
	And I Confirm the Product shows the ORIGINAL RETAILER(s) with a "Completed Status" (see the Clients column)
	And I Confirm the Product shows theNEW RETAILER(s) with an "Accepted Status" (see the Clients column)Note: if you selected a retailer that does not have a feed associated to it you will see the product in Completed status for this retailer)
	And I In the Shared Step below - Select the Product with the "Accepted Status"
	And I call Shared Step 51664 (SHA - Accepted Product - set Retailers to Completed for saved as: (.*))
	And I Confirm the Product now shows a "Completed" Status in Completed for ALL associated Retailers

Scenario: [75129] Forward - Product in Submitted Status
	Given I retrieve the email address for account: WERCs Product Account and save as: TestCase75129Email
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	And I call Shared Step 74654 - SHA manager - Suppliers - Search by email address: saved as TestCase75129Email and saved name as: TestCase75129Supplier
	And I call Shared Step 74655 SHA with email - Search by Supplier ID saved as TestCase75129Supplier for specific product status: Submitted and email: saved as TestCase75129Email
	And I save a product which blue and has retailers as TestCase75129
	And I save the retailers associated with product TestCase75129 as TestCase75129Retailers
	Given I navigate to the landing page
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I filter the products by: Assessment in Progress
	And I filter for the product saved as: TestCase75129
	Given I call Shared Step 75130 - Bulk Actions - Select Forward Product Registration
	Then I should see the header: Select Products & UPCs on the Forward Product Registration window
	And I enter the text: saved as TestCase75129 in the 'Search by WPS ID or Product Name' field
	And In the Foward Product Registration Screen I should see product: saved as TestCase75129
	And In the Foward Product Registration Screen I Select the product: saved as TestCase75129
	And I click continue on the Forward Product Registration page
	And In the Forward Product Registration Screen I select a retailer not in the list of retailers saved as TestCase75129Retailers and save as TestCase75129Retailer
	And I click continue
	And If the Private Label textbox is showing in the Select UPCs screen, I enter the value: N/A
	And I call Shared Step 75140 - Forwarding - Select Products & UPCs step - Add Any missing data and select 1 UPC - Continue and save UPC as UPC75129
	Then I should see the header: Product Results on the Forward Product Registration window
	And I click continue
	And I select the true radio for the 'Are Statements True' question under the Review and Submit tab
	And I click continue
	Given In the Purchase Summary screen I confirm the Purchase Summary header is displayed
	Given I navigate to the home page
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase75129)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase75129 and its status is: Submitted
	And I confirm that retailer saved as TestCase75129Retailer appears in the list of retailers for product TestCase75129
	And I call Shared Step 75309 (SHA > Select Product > UPC List) for product saved as: TestCase75129
	And I confirm UPC number saved as: "UPC75129" is displayed in the SHA Manager Product UPC list
	And I confirm that retailer saved as TestCase75129Retailer appears for UPC saved as UPC75129
	And I close the window that opened
