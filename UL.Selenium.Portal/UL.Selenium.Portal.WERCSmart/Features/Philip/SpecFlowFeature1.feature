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
Given I «should» see the More Information hyperlink
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

Given I attempt to log in with email: wercsmartsub1@sharklasers.com and password: Thewercs1!
# Click on Prescription Pharmaceutical icon
# New Product screen: click Continue
Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): prescription pharmaceutical, solid
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
Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC«upc», container type: Plastic Container and size: 1
# Click Continue in the Regulatory Documents to Provide
# Confirm an error message shows: "Document is required: Product Label"
# Click Browse for the upload a "Product Label" file
# Find and select a PDF type document, click open; file uploads
# Click Continue; Additional Documents to Provide section shows
# Confirm that the option was renamed: "Safety Data Sheet (Optional)"
# Confirm that "Safety Data Sheet" is the only available option in Additional Documents to Provide
# Take note of your Product ID
# Click Continue, Data Acceptance sections appears
Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
# Purchase Summary page is shown with the following message: "Thank you for registering your product on WERCSmart for assessment. The retailers may receive your assessment in approximately two (2) business days, if no delays in processing the assessment, and should no data issues arise."
# Click Home button
Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Submitted Status for saved as: «savedAs»)
Given I call Shared Step 40657 (SHA Manager - Submitted - Select product &gt; process product data for product saved as: «savedAs»)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Assigned Status for saved as: «savedAs»)
Given I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: «savedAs»)
Given I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product &gt; Click Continue for product saved as: «savedAs»)
Given I call Shared Step 79500 (WPS Studio - PD+ - set all data and publish using rule and doc queue - CKLT and SBCS only) for product saved as: «savedAs»
Given I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: «savedAs»)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Accepted Status for saved as: «savedAs»)
Given I call Shared Step 51664 (SHA - Accepted Product - set Retailers to Completed for saved as: «savedAs») for
| Retailer            |
| Walt-Mart/SAMS CLUB |
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Completed Status for saved as: «savedAs»)
Given I call Shared Step 43587 - SHA Manager &gt; Completed Product - Add Recert reason 20 for product saved as: «savedAs»
Given I attempt to log in with email: wercsmartsub1@sharklasers.com and password: Thewercs1!
# Filter for your Product# Click the ... icon in the Actions column for your product# Click Update Required
# Confirm it transitions to the "Product Characteristics" Page# Make a change in one of the options in product characteristics section, click save
# Click Retailer Association Tab# Select Universal Product Code (UPC) section# Confirm no error is shown for the Tablet and Capsule Count field
# Click Save# Select Data Acceptance, click Accept
# Purchase Summary page is shown with the following message: "Thank you for registering your product on WERCSmart for assessment. The retailers may receive your assessment in approximately two (2) business days, if no delays in processing the assessment, and should no data issues arise."
# Click Home
# Confirm the product retailers appear in orange (Assessment in Progress status)
