@Shared
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
@SHA
@UPC
@run_AdditionalProductInformation
@Shared
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
@SHA
@CreateProducts
@ForwardProductRegistration
@PaymentMethods
@ProductSetUp
@run_AccountHasStewardshipInfo
@Shared
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
@Studio
@SHA
@UPC
@run_StwdInWpsStudiofeature
@Philip
@Shared
@NewProduct
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
@ProductSetUp
@SHA
@Studio
@ForwardProductRegistration
@ProductSetUp
@SupplierReports
@CreateProducts
@ViewUpcs
@Solutions
@run_NotIncludedGeneralTests
@Shared
@NewProduct
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
@ProductSetUp
@SHA
@Studio
@ForwardProductRegistration
@ProductSetUp
@SupplierReports
@CreateProducts
@ViewUpcs
@Solutions
@run_NotIncludedGeneralTests
@Shared
@NewProduct
@Homepage
@Shared
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
@UPC
@ReviewDocuments
@SHA
@MyMessages
@run_MyMessages
@Shared
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
@UPC
@ReviewDocuments
@SHA
@MyMessages
@run_MyMessages
@Shared
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
@PaymentMethodsSelect Waste Classification Summary
@SHA
@CreateProducts
@Studio
@ProductSetUp
@ProductGrid
@Shared
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
@Portal_ULSC
@ULSC
@Shared
@Pharma
@CreateProducts
@NewProduct
@ProductGrid
@ProductSetUp
@Homepage
@NewDistributor
@MyAccount
@NewProduct
@Shared
@PaymentMethods
@SHA
@CACleaning
@MyIngredients
@NewProduct
@Shared
@LandingPage
@Login
@Homepage
@ForgottenPassword
@SupplierReports
@RetailPartners
@wercsmart
@Signup
@ProductGrid
@run_SupplierReports
@ViewUpcs
@DataSummarySheet
@SHA
@MyAccount
@NewProduct
@ProductSetUp
@UPC
@SupplierReports
@NewProduct
@run_SpecFlowFeature1

Feature: SpecFlowFeature1
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers
Scenario: [145936] Nickel Metal Hydride (NiMH) Battery- RU000373 - Uploaded Documents

Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Nickel Metal Hydride (NiMH) Battery
Given I call Shared Step 59927 (Primary Physical State > Solid only available – Without Water Solubility question)
Given I call Shared Step 102767 (Additional Product Information (Battery flow - not Lithium) - OSHA (No), DSV (No), PLP (No), GNFR (No))
Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
| CASNumber | ComponentName | Percent | PublicallyDisclosed | PublicName | TradeSecret |
|           | Nickel        | 100     |                     |            |             |
# Shared step 145355 should be added here
Given I call Shared Step 104276 (Enter Regulatory Information - TSCA, CEPA, Not Prop 65)
Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Best Buy
# NOTE: shared step 60826 was updated in TFS; step 7 was added to: "Select the desired Package Type from the Package Type drop down"
Given I call Shared Step 60826 (Enter Universal Product Code (UPC) - Battery - Confirm Quantity ) for UPC saved as: UPC«upc» with container type: Cardboard size: 8 and quantity: 4
# shared step 145129 should be added here# Click 'CONTINUE' on the Additional Documents to Provide screen
# Click 'CONTINUE' on the Optional Reports and Documents Available for Purchase screenGiven I call Shared Step 57883 (Comments - Happy Path) and enter the comment: Testing the comments text box to make sure it is working properly.
# Take Note of the Product ID
Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
# Click Home buttonGiven I call Shared Step 65080 (Login to Studio and Open SHA manager)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Submitted Status for saved as: product ID)
# Select the product
# Click the Review option at the bottom menu; New tab opens
# Verify that the drop down for Document Purpose type Shows: AIS
# Verify that the Uploaded document shows properly
# From the Document Purpose Type drop down select: Label
# Verify that the Uploaded Document shows properly# Close the Review Tab
