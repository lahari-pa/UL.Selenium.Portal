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
@run_Transportation
@Pharma
@wercsmart
@run_ChooseGoodGuide
@ConflictMinerals
@ProductGrid
@Portal_ChooseGoodGuide
@WERCSmart_ChooseGoodGuide

Feature: ChooseGoodGuide.com Scenarios




Scenario: [128141] Verification that 'Bed Bath and Beyond' Displays under 'My Retailers' and its Data Consent Tiers

Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
# The "Data Consent Requests" pop-up window should display when you log in
# Click on the 'Go to My Retailers' Button
# Confirm it transitions to the 'Retail Partners' My Data & Recipients Page
# Confirm that you see the BED BATH & BEYOND Retailer
# Select the 'Box Icon' for BED BATH & BEYOND
# Confirm it transitions to the BED BATH & BEYOND (Including Harmon, Buy Buy Baby, and Christmas Tree Shops) Data Consent Tiers
# Confirm that the Data Consent Tiers Reads the following statement:  Bed Bath and Beyond (Including Harmon, Buy buy Baby, and Christmas Tree Shops) requires suppliers of formulated products in the following categories to grant Tier 2.1, Tier 2.2 and Tier 4.1 Permissions:  Cleaning Supplies, Grocery, Health & Beauty, Nutritional Supplements, OTC - Over the Counter and Pharmacy
Given I should see the More Information hyperlink
Given I click the More Information hyperlink
# Confirm a NEW TAB opens
# Confirm the new tab opens the following page:  https://www.bedbathandbeyond.com/store/static/CorporateResponsibilityReport
# Close the New Tab
# Returns to the Data Tiers Screen for BBB
# Confirm that you see the 'What are the Data Usae Tiers? BUTTON
# Click on the 'What are the Data Usage Tiers? BUTTON
# Confirm the 'What are the Data Usage Tiers? pop-up window opens
# On the left side Tab - Click on 'Tier 1: Regulatory Compliance'
# Confirm that on the right side - Information for 'What does Regulatory Support Mean? displays
Given I click download PDF for "Tier 1: Regulatory Compliance"
# On the left side Tab - Click on 'Tier 2: Chemical Program Support'
# Confirm that on the right side - Information for 'What Does Chemical Program Support Mean? displays
Given I click download PDF for "Tier 2: Chemical Program Support"
# On the left side Tab - Click on 'Tier 3: Supplemental Reports'
# Confirm that on the right side - Information for 'What does Supplemental Reports for Internal Business Use Only Mean? displays
Given I click download PDF for "Tier 3: Supplemental Reports"
# On the left side Tab - Click on 'Tier 4: Public Disclosure Options'
# Confirm that on the right side - Information for 'What are my Public Disclosure Options?' displays
Given I click download PDF for "Tier 4: Public Disclosure Options"
# Close the 'What are the Data Usage Tiers? Window
# Confirm that under the 'Data Consent Tiers' you see the Tier 1, Tier 2.1, Tier 2.2 and Tier 4.1
# Confirm that on the right side of each Tier you see the 'ON' and 'OFF' Toggle Buttons






Scenario: [128134] Pharma -  Product in Recertification

#Given I attempt to log in with email: wercsmartsub1@sharklasers.com and password: Thewercs1!
# Click on Prescription Pharmaceutical icon
# New Product screen: click Continue
#Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): prescription pharmaceutical, solid
# In Product Information screen, copy and paste 0360-0089-01 and select it from the list, click Continue
# In SPL Information screen - Confirm the fields are automatically populated, if a field is not populate (for example the Distributor field, fill it in) - click continue
# In Product Characteristics for secondary state drop down select- solid
# For question: "When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?" select No
# Select the best Water Solubility description from the drop down
# Click Continue
# The Ingredients get populated automatically, fill in the percentages for each ingredient - click Continue
# Select No for question: "Should this product be refrigerated for transport or storage?"
# For question: "Is the product regulated for transport (before exceptions or exemptions)" select No, not regulated
# Click Continue
# In Retailer Association section select a Vendor from the drop down for  Wal-Mart/SAM'S CLUB
# Click Continue
# In the Universal Product Code (UPC) section click +Add UPC button
# In the Shared step below type in a number for the tablet or capsule count field
#Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC«upc», container type: Plastic Container and size: 1
# Click Continue in the Regulatory Documents to Provide
# Confirm an error message shows: "Document is required: Product Label"
# Click Browse for the upload a "Product Label" file
# Find and select a PDF type document, click open; file uploads
# Click Continue; Additional Documents to Provide section shows
# Confirm that the option was renamed: "Safety Data Sheet (Optional)"
# Confirm that "Safety Data Sheet" is the only available option in Additional Documents to Provide
# Take note of your Product ID
# Click Continue, Data Acceptance sections appears
#Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
# Purchase Summary page is shown with the following message: "Thank you for registering your product on WERCSmart for assessment. The retailers may receive your assessment in approximately two (2) business days, if no delays in processing the assessment, and should no data issues arise."
# Click Home button






Given I attempt to log in with email: wercsmartsub1@sharklasers.com and password: Thewercs1!
Given I click the Prescription Pharmaceutical icon in the QuickLinks Pane
Given I generate a random UPC number and save as: UPC128018
Given I click continue
Given I call Shared Step 57500a (Prescription Pharmaceutical - The Product- Enter name, select product type - Continue - Happy Path): prescription pharmaceutical, solid
Given I enter the NDC number: 10866-0885-2
Then I save the product information as: TestCase128018
Then I click continue
Given I fill all empty fields in the SPL Information screen
Then I click continue
And I set the Secondary Physical State to be: Solid
And I set the When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5? option to: No
And I set the Select the best Water Solubility description to be: Very soluble
And in the New Product page I click Continue
Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
	| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
	| Propane       | 100     | false               | false       |            |
Given I set the Should this product be refrigerated for transport or storage? option to: No
Then I click continue
Given I set the Is the product regulated for transport (before exceptions or exemptions) option to: No, not regulated
Then I click continue
Given in the Select Retailers tab under Forward Product Registration I select the retailer: Wal-Mart/SAM'S CLUB
Given In the Retailers tab, I select the first Vendor option for retailer: Wal-Mart/SAM'S CLUB
Then I click continue
Then I call Shared Step 57961 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC128018, container type: Plastic Container, capsule count: 50 and size: 1
When I click continue
When I click continue
Then Upload Full Product Label (required) (For private label products please upload a generic label that is not retailer-specific.) should be showing the error messages: Document is required: Product Label
And I call Shared Step 60567 (Upload Product Label only) for section: Upload Full Product Label (required)
Then I check for the following options in the Additonal Documents to Provide section
| Option                       |
| Safety Data Sheet (Optional) |
When I click continue
Given I call Shared Step 59042 (Browse for File > select > click Open - Happy Path) for document type: Upload Full Product Label (required) (For private label products please upload a generic label that is not retailer-specific.) and file: C:\Dependencies\WERCSmart\testdoc.pdf
When I click continue
When I click continue
Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
And In the Purchase Summary screen I confirm the Purchase Summary header is displayed
Then In the Thank You screen I confirm the following statement is shown: Thank you for registering your product on WERCSmart for assessment. The retailers may receive your assessment in approximately two (2) business days, if no delays in processing the assessment, and should no data issues arise.
And I navigate to the home page
#Given I call Shared Step 75130 - Bulk Actions - Select Forward Product Registration
#And I enter the text: saved as TestCase128018 in the 'Search by WPS ID or Product Name' field
#And In the Foward Product Registration Screen I should not see product: saved as TestCase128018
#And I navigate to the home page







Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Submitted Status for saved as: TestCase128018)
Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase128018)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Assigned Status for saved as: TestCase128018)
Given I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase128018)
And I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase128018)
Given I call Shared Step 79500 (WPS Studio - PD+ - set all data and publish using rule and doc queue - CKLT and SBCS only) for product saved as: TestCase128018
Given I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase128018)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Accepted Status for saved as: TestCase128018)
Given I call Shared Step 51664 (SHA - Accepted Product - set Retailers to Completed for saved as: TestCase128018) for
		| Retailer |
		| CVS      |
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Completed Status for saved as: TestCase128018)
And I call Shared Step 43587 - SHA Manager > Completed Product - Add Recert reason 20 for product saved as: TestCase128018






Given I navigate to the landing page
Given I attempt to log in with email: wercsmartsub1@sharklasers.com and password: Thewercs1!
And I filter for the product saved as: TestCase128018
And I click Row Actions for the first product returned

And I click on the Row Action: Update Required
Given In the New Product page I click tab: Product Type
And I click the page heading: Product Type
And I set the Secondary Physical State to be: Solid containing liquid
And I click Save in The Product Page
Given In the New Product page I click tab: Recipient and UPC Details
Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Canadian Tire
Given I generate a random UPC number and save as: UPC1280188
Then I call Shared Step 57961 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC1280188, container type: Plastic Container, capsule count: 50 and size: 1
When I click continue
And I call Shared Step 60567 (Upload Product Label only) for section: Upload Full Product Label (required)
Then I check for the following options in the Additonal Documents to Provide section
| Option                       |
| Safety Data Sheet (Optional) |
When I click continue
Given I call Shared Step 59042 (Browse for File > select > click Open - Happy Path) for document type: Upload Full Product Label (required) (For private label products please upload a generic label that is not retailer-specific.) and file: C:\Dependencies\WERCSmart\testdoc.pdf
When I click continue
When I click continue
Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
And In the Purchase Summary screen I confirm the Purchase Summary header is displayed
Then In the Thank You screen I confirm the following statement is shown: Thank you for registering your product on WERCSmart for assessment. The retailers may receive your assessment in approximately two (2) business days, if no delays in processing the assessment, and should no data issues arise.
And I navigate to the home page
# Select Universal Product Code (UPC) section
# Confirm no error is shown for the Tablet and Capsule Count field
# Click Save
# Select Data Acceptance, click Accept
# Purchase Summary page is shown with the following message: "Thank you for registering your product on WERCSmart for assessment. The retailers may receive your assessment in approximately two (2) business days, if no delays in processing the assessment, and should no data issues arise."
# Click Home
  
# Confirm the product retailers appear in orange (Assessment in Progress status)
