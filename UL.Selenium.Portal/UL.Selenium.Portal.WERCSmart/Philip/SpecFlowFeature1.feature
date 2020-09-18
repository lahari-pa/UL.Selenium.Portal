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
@run_SpecFlowFeature1

Feature: ChooseGoodGuide.com Scenarios

@ScenarioId:10291
Scenario: [138836] My Account - Correct Message Displays when Date is Expired
Given I Login into WERCSmart Portal - Admin Role - WERCs Visual Account
Given I navigate to My Account
Given In the My Account page I navigate to the Company Information page
Given In Stewardship table click edit
Given I add following stewardship information
| Province         | Stewardship |
| British Columbia | BC-1-1      |
| Saskatchewan     | SA-1-1      |
# For the Issue Date type in today's date for British Columbia and Saskatchewan
# For the Expire Date type in tomorrow's date for British Columbia and Saskatchewan
# Click Save
Then I save Stewardship Numbers information
Then I click on the 'Edit' button in Company information in the Stewardship Numbers section
Then I fill in Stweardship Numbers information
| Stewardship | Issue Date | Expire Date |
| BC-1-1      | 2020-09-17 | Tomorrow    |
| SA-1-1      | 2020-09-17 | Tomorrow    |
Then I save Stewardship Numbers information
Given I call Shared Step 62676 (Go To My Account)
# Select Sign Out
# Next day login using the step below#
Given I Login into WERCSmart Portal - Admin Role - WERCs Visual Account
Given I navigate to My Account
Given In the My Account page I navigate to the Company Information page
