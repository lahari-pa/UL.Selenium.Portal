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
@run_Sprint15.5.2


Feature: Sprint 15.5.2

Scenario: [Sprint15.5.2] Task 105970, Dupe UPC tool, Obsolete UPC Option only present on duplicate UPCs.
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then I create a product and save as: UPCTOOLTESTPRODUCT1 and name as: TestCond
And I call Shared Step 65080 (Login to Studio and Open SHA manager)
And I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: UPCTOOLTESTPRODUCT1)
Given I call Shared Step 75309 (SHA > Select Product > UPC List) for product saved as: UPCTOOLTESTPRODUCT1
Then I check that the UPC number saved as: UPC75335 and under the retailer: Wal-Mart/SAM'S CLUB, does not show the Obsolete UPC Option in the UPC details popup
Then I close the SHA Manager Product UPC details pop up
And I close the current window and switch to the main window
And I call Shared Step 65080 (Login to Studio and Open SHA manager)
Then I Search using for a product containing duplicate UPCs listed in the Spreadsheet 'UPCsDuplicatedwithinAccount.xlsx'
Given I call Shared Step 75309 (SHA > Select Product > UPC List) for product saved as: ProductID105970
Then I check that the UPC number saved as: DupeUPCNumber105970 and under the retailer: <ProductRetailer105970>, does show the Obsolete UPC Option in the UPC details popup
Then I close the SHA Manager Product UPC details pop up

Scenario: [Sprint15.5.2] Task 105970, UPC Details Verification Message for Registration with Multiple UPCs - Cancel or Continue
And I call Shared Step 65080 (Login to Studio and Open SHA manager)
Then I Search using for a product containing duplicate UPCs listed in the Spreadsheet 'UPCsDuplicatedwithinAccount.xlsx'
Given I call Shared Step 75309 (SHA > Select Product > UPC List) for product saved as: ProductID105970
Then I check that the UPC number saved as: DupeUPCNumber105970 and under the retailer: <ProductRetailer105970>, does show the Obsolete UPC Option in the UPC details popup
Then I Click the Obsolete Button and Check a Popup Appears with 'Cancel' and 'Continue' buttons and the following message: You have selected to remove the UPC from the registration. The Account's Administrator(s) will be notified via email of this action. Are you sure you want to proceed with this action? It cannot be reversed.
Then I click close in the Confirm Obsolete UPC popup, and the Confirm Obsolete UPC popup is closed and the UPC Details Popup remains on screen.
Then I Click the Obsolete Button and Check a Popup Appears with 'Cancel' and 'Continue' buttons and the following message: You have selected to remove the UPC from the registration. The Account's Administrator(s) will be notified via email of this action. Are you sure you want to proceed with this action? It cannot be reversed.
And I click Continue in the Confirm Obsolete UPC popup, and the Confirm the Manager Validation Require Popup appears.


