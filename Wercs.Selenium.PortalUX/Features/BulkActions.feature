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
