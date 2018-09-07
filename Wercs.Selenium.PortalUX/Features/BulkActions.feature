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
@run_BulkActions

Feature: BulkActions

Scenario: [56223] Bulk Actions - Forward Product Registration navigation

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then the WERCSmart homepage should load

Given I click Bulk Actions in the Products Grid

And I click Forward Product Registration in the Bulk Actions window

Then I should see the header: Forward Product Registration on the Forward Product Registration window

And I should see the subheading 3: Select Products & UPCs on the Forward Product Registration window

#This test cases uses the ULSC account
Scenario: [56224] Bulk Actions - Sync Products to WERCSLink navigation

Given I Login into WERCSmart Portal - Admin Role - WERCs ULSC Account

Then the WERCSmart homepage should load

Given I click Bulk Actions in the Products Grid

And I click Sync Products in the Bulk Actions window

And I should see the header: Sync Products to ULSC on the Sync Products to ULSC window

Then I click on the cancel button on the ULSC Sync popup

And I should see the Subheading Alerts in the main window

Scenario: [56225] Bulk Actions - Accept Documents navigation

Given I Login into WERCSmart Portal - Admin Role - WERCs Visual Account

Then the WERCSmart homepage should load

Given I click Bulk Actions in the Products Grid

And I click Accept Documents in the Bulk Actions window

And I should see the header: Document Acceptance on the Document Acceptance window

Scenario: [56227] Bulk Actions  Delete Products navigation

Given I Login into WERCSmart Portal - Admin Role - WERCs Visual Account

Then the WERCSmart homepage should load

Given I click Bulk Actions in the Products Grid

And I click Delete Products in the Bulk Actions window

And I should see the header: Delete Active Products on the Delete Active Product window

Scenario: [74634] Forward Product Registration - Only can select product once

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

Given I click Bulk Actions in the Products Grid

Then I should see a popup with header Bulk Actions

Given I click Forward Product Registration in the Bulk Actions window

Then I should see the header: Forward Product Registration on the Forward Product Registration window

Given I enter the text: 1 in the 'Search by WPS ID or Product Name' field

Given I save first selectable Product ID as: SelectProductsID74634 under the Select Products tab

Given I select the product with ID saved as: SelectProductsID74634 under the Select Products tab and the checkbox is disabled while the page is working

#Given I select the product with ID saved as: SelectProductsID74634 under the Select Products tab

#Then I confirm that the product checkbox is disabled while the page is working

And I confirm I am unable to select the product with ID saved as: SelectProductsID74634 under the Select Products tab

Given I click the Home navigation icon and accept the alert popup

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

Then I confirm a new window opens displaying the document

# This is currently blocked - downloading pdf through chrome viewer is not reliable so need to fetch the file directly from the API
Given I confirm the subformat type at the top of the document matches the vaulue in the Documents table for the first document I viewed

Given I close the window that opened

Given I navigate to the home page
