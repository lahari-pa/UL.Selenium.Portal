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
@PaymentMethods
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
@run_Transportation

Feature: Temp
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag

Scenario: [133610] Formulation Screen:  Attestation Reset on Data Change

Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Baby/Infant/Adult Care/Cleansing Wipes
	Then I save the product information as: TestCase74992
	And I set the Is there a free liquid in the Product's container that is 10ml or greater? option to: No
	Given I click continue
	And I set the Primary Physical State to be: Solid
	And I set the Secondary Physical State to be: Solid
	And I set the When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5? option to: No
	And I set the Select the best Water Solubility description to be: Very soluble
	And in the New Product page I click Continue
	Given I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Glutens, corn
	#Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	#Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
	#Given I call Shared Step 57507 (Transportation Details 1- Not Regulated - Continue - Happy Path)
	#Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	#Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	#Then I should see the Additional Documents to Provide Page
	#Given in the Additional Documents to Provide page I click Continue
	#Given in the Optional Reports and Documents Available for Purchase page I click Continue
	#Given I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
	#	| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
	#	| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
	#Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: User added Comments Text 74992. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
	#And I should see the Data Acceptance Page
	#Then The Data Acceptance page should appear
	#Then I should see an error message: Select at least one of the options
	#Then In the Data Acceptance page I select Yes, Agreed
	#Given I click the Summary button in the Data Acceptance window

	#When In the New Product page I click tab: Recipient and UPC Details

# In the Product Characteristics Page - By default SOLID is selected as the Primary Physical State
# Select SOLID for Secondary Physical State
# For the question 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?  - Select 'NO'
# Click 'CONTINUE'
# In the 'Additional Product Information Page'
# CONFIRM the 'Additional Product Information Page' displays the Question "Which one best describes your product"
# Select the Radio Button Option - "Product is not considered a pesticide product"
# CONFIRM that by default the "United States" checkbox is selected
# Select 'NO' for the rest of the questions listed in the 'Additional Product Information Page'
# Click 'CONTINUE'
# In the 'INGREDIENTS SCREEN' enter the following CAS Numbers
# 66071-96-3 - Glutens, corn @ 100%
# Click 'CONTINUE'
# CONFIRM that you are prompted with the 'PRODUCT CONTAINS INGREDIENTS TYPICAL OF A PESTICIDE' Message Box
# CONFIRM that the Component is marked as 'ACTIVE'
# Click on the 'GO BACK BUTTON'
# CONFIRM that transitions back to the 'INGREDIENTS PAGE'
# Do not make any changes to the Components - leave them as is
# Click on the 'PRODUCT TYPE' Tab
# Click on 'THE PRODUCT' Edit Pencil Icon
# CONFIRM it transitions back to 'THE PRODUCT' PAGE
# Edit the Product Name to 'RESET PRODUCT'
# Change the 'TYPE OF PRODUCT' TO:  Chalk
# Click 'CONTINUE'
# In the Product Characteristics Page -  By default 'SOLID' is selected as a Primary Physical State
# Select SOLID for Secondary Physical State
# For the question 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?  - Select 'NO'
# Click on the 'Water Solubility description' drop-down and select Soluble in Water
# Click 'CONTINUE'
# CONFIRM that it transitions to the 'Additional Product Information Page'
# CONFIRM that the Pesticide Section in the Additional Product Information Page shows
# CONFIRM that the first question is the 'Select countries the product may be sold in'
# Select 'NO' for the rest of the questions in the Page
# Click 'CONTINUE'
# Transitions to the 'INGREDIENTS Page'
# Click 'CONTINUE' on the 'INGREDIENTS' Page
# CONFIRM that you are NOT prompted with the window message 'Product Contains Ingredients Typical of a Pesticide'
# By changing the Product Type - the flow should reset and no longer show the Pesticide Information
# Continues onto the 'Waste Classification Data' PageGiven I click the Home navigation icon
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: Pesticide Testing Product
