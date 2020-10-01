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

Scenario: [144185] Suspended - Invalid Retailer Supplier ID Associated with Registration

#Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
#	Given I Save the email for the TReVor: ProductAccount Test user as: ProductAccountEmail
#	Given I save the current emails in the inbox for address saved as: ProductAccountEmail
#	Given I generate a random UPC number and save as: UPC144185
#	Then The home screen should load
#	And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
#	And I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk
#	Then I save the product information as: TestCase144185
#	Given I call Shared Step 26897 (Product Characteristics - Solid only available - continue)
#	Given I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
#	Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
#	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
#	Given I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue) for
#		| Retailer  |
#		| Walgreens |
#	Given I call Shared Step 87647 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC144185, container type: Paper bag and size: 2 do not click continue
#	Given I click continue
#	And  I call Shared Step 78080 (Regulatory Documents to Provide - Upload OSHA SDS)
#	Given in the Additional Documents to Provide page I click Continue
#	Given in the Optional Reports and Documents Available for Purchase page I click Continue
#	Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: test
#	Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)


Given I call Shared Step 65080 (Login to Studio and Open SHA manager)

#Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Submitted Status for saved as: TestCase144185)
#	Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase144185)
#	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Assigned Status for saved as: TestCase144185)
#	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase144185 and its status is: Assigned


And In SHA Manager I click on bottom menu item: Search
And In SHA Manager ProductSearch page I run search:
| SearchTerm     | SearchValue                     |
| Status	     | Assigned                        |
#| User           | ProductAccountEmail |

Then In SHA Manager I select the first product
And In SHA Manager I click on bottom menu item: Suspended
And In the Suspended dialog I Select the following clients: All
And In the Suspended dialog in the Select Regulatory Specialist drop down I choose: Automated QASha
And In the Suspended dialog in the Select Subject drop down I choose: Invalid Retailer Supplier ID Associated with Registration
And In the Suspended dialog in the Supplier Message field I should see: You're registration's assessment is not finalizing to a Recipient due to their Supplier ID requirement matching the on-boarding system for the Retailer. To manage your Retailer Supplier IDs within WERCSmart use the My Retail Partner menu option, select the Retailer, and ensure the Supplier ID is accurately listed in the Retailer's table and that the Supplier ID is Active.
And In the Suspended dialog below the Supplier Message field I see the following text in red: These comments may be viewed by the Supplier in the portal, so be careful.
And In the Suspended dialog in the Internal Product Note field I should see: You're registration's assessment is not finalizing to a Recipient due to their Supplier ID requirement matching the on-boarding system for the Retailer. To manage your Retailer Supplier IDs within WERCSmart use the My Retail Partner menu option, select the Retailer, and ensure the Supplier ID is accurately listed in the Retailer's table and that the Supplier ID is Active.
# Click Suspend; Message appears: "Product Successfully updated. The product (ID) has been place into recertification Product Message for product (ID) has been created successfully"
And In the Suspended dialog I click Suspend
And I check that the alert displayed contains text: Product Successfully updated. The product (ID) has been place into recertification Product Message for product (ID) has been created successfully
# Click OK; Message pop up closes and screen refreshes
And I close alert
# Confirm the body of the email contains the following information: Your product assessment has been Suspended. (new line) You're registration's assessment is not finalizing to a Recipient due to their Supplier ID requirement matching the on-boarding system for the Retailer.
# (new line) To manage your Retailer Supplier IDs within WERCSmart use the My Retail Partner menu option, select the Retailer, and ensure the Supplier ID is accurately listed in the Retailer's table and that the Supplier ID is Active.
# (new line) To revise the Supplier ID within a registration, edit or update the registration from the My Product table on the Home Page, and on the Retailer selection area, be sure the proper Supplier ID is associated for the Retailer. Once the registration is revised, you may accept the updates which will transfer the registration back to the Assessment team for processing.
# (new line) Please be aware that if you do not update and resubmit the registration data within ten (10) days this may result in your registration being cancelled and the assessment will not proceed to your Retailer(s). If you have any questions, please contact WERCSmart Customer Support via email (WERCSmartCustomer@UL.com, chat, or call 877-642-6753. Thank you for your prompt attention to this matter. (new line) The WERCSmart Assessment Team
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase144185)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase144185 and its status is: Suspended
	Then I Check there should be a new suspension notification email for user: ProductAccountEmail for the Product saved as: TestCase144185 with the suspension subject of: Invalid Retailer Supplier ID Associated with Registration and check it does not contain text from the table:
	| SearchText |
	Then the text of the email should show: Your product assessment has been Suspended. (new line) You're registration's assessment is not finalizing to a Recipient due to their Supplier ID requirement matching the on-boarding system for the Retailer. To manage your Retailer Supplier IDs within WERCSmart use the My Retail Partner menu option, select the Retailer, and ensure the Supplier ID is accurately listed in the Retailer's table and that the Supplier ID is Active. To revise the Supplier ID within a registration, edit or update the registration from the My Product table on the Home Page, and on the Retailer selection area, be sure the proper Supplier ID is associated for the Retailer. Once the registration is revised, you may accept the updates which will transfer the registration back to the Assessment team for processing. Please be aware that if you do not update and resubmit the registration data within ten (10) days this may result in your registration being cancelled and the assessment will not proceed to your Retailer(s). If you have any questions, please contact WERCSmart Customer Support via email (WERCSmartCustomer@UL.com, chat, or call 877-642-6753. Thank you for your prompt attention to this matter. (new line) The WERCSmart Assessment Team


Scenario: [144178] Suspended - Document Issue - RCRA (Federal Waste)

Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
And In SHA Manager I click on bottom menu item: Search
And In SHA Manager ProductSearch page I run search:
| SearchTerm     | SearchValue                     |
| Status	     | Assigned                        |
Then In SHA Manager I select the first product
And In SHA Manager I click on bottom menu item: Suspended
And In the Suspended dialog I Select the following clients: All
And In the Suspended dialog in the Select Regulatory Specialist drop down I choose: Automated QASha
And In the Suspended dialog in the Select Subject drop down I choose: Document Issue - RCRA (Federal Waste)
And In the Suspended dialog in the Supplier Message field I should see: During our assessment and data creation for your product, we found conflicting information and may impact the handling and storage of the product.   In Section 13 of the Safety Data Sheet (SDS), the document states this product is a RCRA waste, however based on the flash point, corrosivity, or toxicity indicated by the product data, this product does not appear to be classified as a Federal Waste (RCRA). Please clarify for proper waste data to be generated for the retailers or provide an updated Safety Data Sheet (SDS).
And In the Suspended dialog below the Supplier Message field I see the following text in red: These comments may be viewed by the Supplier in the portal, so be careful.
And In the Suspended dialog in the Internal Product Note field I should see: During our assessment and data creation for your product, we found conflicting information and may impact the handling and storage of the product. In Section 13 of the Safety Data Sheet (SDS), the document states this product is a RCRA waste, however based on the flash point, corrosivity, or toxicity indicated by the product data, this product does not appear to be classified as a Federal Waste (RCRA). Please clarify for proper waste data to be generated for the retailers or provide an updated Safety Data Sheet (SDS).
And In the Suspended dialog I click Suspend
And I check that the alert displayed contains text: Product Successfully updated. The product (ID) has been place into recertification Product Message for product (ID) has been created successfully
And I close alert
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase144185)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase144185 and its status is: Suspended
Then I Check there should be a new suspension notification email for user: ProductAccountEmail for the Product saved as: TestCase144185 with the suspension subject of: Document Issue - RCRA (Federal Waste) and check it does not contain text from the table:
| SearchText |
Then the text of the email should show: Your product assessment has been Suspended. During our assessment and data creation for your product, we found conflicting information and may impact the handling and storage of the product. In Section 13 of the Safety Data Sheet (SDS), the document states this product is a RCRA waste, however based on the flash point, corrosivity, or toxicity indicated by the product data, this product does not appear to be classified as a Federal Waste (RCRA).  (new line) Please clarify for proper waste data to be generated for the retailers or provide an updated Safety Data Sheet (SDS). To resolve this issue, please log into WERCSmart. Using either the RESOLVE option in the ALERT area on the Home Page, or using the RESOLVE option available for the registration in My Messages, update the necessary data or documentation. Once the registration is revised, you may accept the updates which will transfer the registration back to the Assessment team for processing. Please be aware that if you do not update and resubmit the registration data within ten (10) days this may result in your registration being cancelled and the assessment will not proceed to your Retailer(s). If you have any questions, please contact WERCSmart Customer Support via email (WERCSmartCustomer@UL.com, chat, or call 877-642-6753. Thank you for your prompt attention to this matter. (new line) The WERCSmart Assessment Team


Scenario: [144173] Suspended - Document Issue - Non-RCRA (Federal Waste)

Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
And In SHA Manager I click on bottom menu item: Search
And In SHA Manager ProductSearch page I run search:
| SearchTerm     | SearchValue                     |
| Status	     | Assigned                        |
Then In SHA Manager I select the first product
And In SHA Manager I click on bottom menu item: Suspended
And In the Suspended dialog I Select the following clients: All
And In the Suspended dialog in the Select Regulatory Specialist drop down I choose: Automated QASha
And In the Suspended dialog in the Select Subject drop down I choose: Document Issue - Non-RCRA (Federal Waste)
And In the Suspended dialog in the Supplier Message field I should see: During our assessment and data creation for your product, we found conflicting information and may impact the handling and storage of the product.   In Section 13 of the Safety Data Sheet (SDS), the document states this product is a RCRA waste, however based on the flash point, corrosivity, or toxicity indicated by the product data, this product does not appear to be classified as a Federal Waste (RCRA). Please clarify for proper waste data to be generated for the retailers or provide an updated Safety Data Sheet (SDS).
And In the Suspended dialog below the Supplier Message field I see the following text in red: These comments may be viewed by the Supplier in the portal, so be careful.
And In the Suspended dialog in the Internal Product Note field I should see: During our assessment and data creation for your product, we found conflicting information and may impact the handling and storage of the product. In Section 13 of the Safety Data Sheet (SDS), the document states this product is a RCRA waste, however based on the flash point, corrosivity, or toxicity indicated by the product data, this product does not appear to be classified as a Federal Waste (RCRA). Please clarify for proper waste data to be generated for the retailers or provide an updated Safety Data Sheet (SDS).
And In the Suspended dialog I click Suspend
And I check that the alert displayed contains text: Product Successfully updated. The product (ID) has been place into recertification Product Message for product (ID) has been created successfully
And I close alert
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase144185)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase144185 and its status is: Suspended
Then I Check there should be a new suspension notification email for user: ProductAccountEmail for the Product saved as: TestCase144185 with the suspension subject of: Document Issue - RCRA (Federal Waste) and check it does not contain text from the table:
| SearchText |
Then the text of the email should show: Your product assessment has been Suspended. During our assessment and data creation for your product, we found conflicting information and may impact the handling and storage of the product. In Section 13 of the Safety Data Sheet (SDS), the document states this product is a RCRA waste, however based on the flash point, corrosivity, or toxicity indicated by the product data, this product does not appear to be classified as a Federal Waste (RCRA). Please clarify for proper waste data to be generated for the retailers or provide an updated Safety Data Sheet (SDS). To resolve this issue, please log into WERCSmart. Using either the RESOLVE option in the ALERT area on the Home Page, or using the RESOLVE option available for the registration in My Messages, update the necessary data or documentation. Once the registration is revised, you may accept the updates which will transfer the registration back to the Assessment team for processing. Please be aware that if you do not update and resubmit the registration data within ten (10) days this may result in your registration being cancelled and the assessment will not proceed to your Retailer(s). If you have any questions, please contact WERCSmart Customer Support via email (WERCSmartCustomer@UL.com, chat, or call 877-642-6753. Thank you for your prompt attention to this matter. The WERCSmart Assessment Team


Scenario: [144127] Suspended - Volatile Organic Compound (VOC) Issue within Registration

Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
And In SHA Manager I click on bottom menu item: Search
And In SHA Manager ProductSearch page I run search:
| SearchTerm     | SearchValue                     |
| Status	     | Assigned                        |
Then In SHA Manager I select the first product
And In SHA Manager I click on bottom menu item: Suspended
And In the Suspended dialog I Select the following clients: All
And In the Suspended dialog in the Select Regulatory Specialist drop down I choose: Automated QASha
And In the Suspended dialog in the Select Subject drop down I choose: Volatile Organic Compound (VOC) Issue within Registration
And In the Suspended dialog in the Supplier Message field I should see: During our assessment and data creation for your product, we found conflicting information and may impact the handling and storage of the product.   In Section 13 of the Safety Data Sheet (SDS), the document states this product is a RCRA waste, however based on the flash point, corrosivity, or toxicity indicated by the product data, this product does not appear to be classified as a Federal Waste (RCRA). Please clarify for proper waste data to be generated for the retailers or provide an updated Safety Data Sheet (SDS).
And In the Suspended dialog below the Supplier Message field I see the following text in red: These comments may be viewed by the Supplier in the portal, so be careful.
And In the Suspended dialog in the Internal Product Note field I should see: During our assessment and data creation for your product, we found conflicting information and may impact the handling and storage of the product. In Section 13 of the Safety Data Sheet (SDS), the document states this product is a RCRA waste, however based on the flash point, corrosivity, or toxicity indicated by the product data, this product does not appear to be classified as a Federal Waste (RCRA). Please clarify for proper waste data to be generated for the retailers or provide an updated Safety Data Sheet (SDS).
And In the Suspended dialog I click Suspend
And I check that the alert displayed contains text: Product Successfully updated. The product (ID) has been place into recertification Product Message for product (ID) has been created successfully
And I close alert
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase144185)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase144185 and its status is: Suspended
Then I Check there should be a new suspension notification email for user: ProductAccountEmail for the Product saved as: TestCase144185 with the suspension subject of: Document Issue - RCRA (Federal Waste) and check it does not contain text from the table:
| SearchText |
Then the text of the email should show: Your product assessment has been Suspended. During our assessment and data creation for your product, we found conflicting information and may impact the handling and storage of the product. In Section 13 of the Safety Data Sheet (SDS), the document states this product is a RCRA waste, however based on the flash point, corrosivity, or toxicity indicated by the product data, this product does not appear to be classified as a Federal Waste (RCRA). Please clarify for proper waste data to be generated for the retailers or provide an updated Safety Data Sheet (SDS). To resolve this issue, please log into WERCSmart. Using either the RESOLVE option in the ALERT area on the Home Page, or using the RESOLVE option available for the registration in My Messages, update the necessary data or documentation. Once the registration is revised, you may accept the updates which will transfer the registration back to the Assessment team for processing. Please be aware that if you do not update and resubmit the registration data within ten (10) days this may result in your registration being cancelled and the assessment will not proceed to your Retailer(s). If you have any questions, please contact WERCSmart Customer Support via email (WERCSmartCustomer@UL.com, chat, or call 877-642-6753. Thank you for your prompt attention to this matter. The WERCSmart Assessment Team



Scenario: [144122] Suspended - Retailer Program Scope - Product Type

Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
And In SHA Manager I click on bottom menu item: Search
And In SHA Manager ProductSearch page I run search:
| SearchTerm     | SearchValue                     |
| Status	     | Assigned                        |
Then In SHA Manager I select the first product
And In SHA Manager I click on bottom menu item: Suspended
And In the Suspended dialog I Select the following clients: All
And In the Suspended dialog in the Select Regulatory Specialist drop down I choose: Automated QASha
And In the Suspended dialog in the Select Subject drop down I choose: Retailer Program Scope - Product Type
And In the Suspended dialog in the Supplier Message field I should see: During our assessment and data creation for your product, we found conflicting information and may impact the handling and storage of the product.   In Section 13 of the Safety Data Sheet (SDS), the document states this product is a RCRA waste, however based on the flash point, corrosivity, or toxicity indicated by the product data, this product does not appear to be classified as a Federal Waste (RCRA). Please clarify for proper waste data to be generated for the retailers or provide an updated Safety Data Sheet (SDS).
And In the Suspended dialog below the Supplier Message field I see the following text in red: These comments may be viewed by the Supplier in the portal, so be careful.
And In the Suspended dialog in the Internal Product Note field I should see: During our assessment and data creation for your product, we found conflicting information and may impact the handling and storage of the product. In Section 13 of the Safety Data Sheet (SDS), the document states this product is a RCRA waste, however based on the flash point, corrosivity, or toxicity indicated by the product data, this product does not appear to be classified as a Federal Waste (RCRA). Please clarify for proper waste data to be generated for the retailers or provide an updated Safety Data Sheet (SDS).
And In the Suspended dialog I click Suspend
And I check that the alert displayed contains text: Product Successfully updated. The product (ID) has been place into recertification Product Message for product (ID) has been created successfully
And I close alert
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase144185)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase144185 and its status is: Suspended
Then I Check there should be a new suspension notification email for user: ProductAccountEmail for the Product saved as: TestCase144185 with the suspension subject of: Document Issue - RCRA (Federal Waste) and check it does not contain text from the table:
| SearchText |
Then the text of the email should show: Your product assessment has been Suspended. During our assessment and data creation for your product, we found conflicting information and may impact the handling and storage of the product. In Section 13 of the Safety Data Sheet (SDS), the document states this product is a RCRA waste, however based on the flash point, corrosivity, or toxicity indicated by the product data, this product does not appear to be classified as a Federal Waste (RCRA). Please clarify for proper waste data to be generated for the retailers or provide an updated Safety Data Sheet (SDS). To resolve this issue, please log into WERCSmart. Using either the RESOLVE option in the ALERT area on the Home Page, or using the RESOLVE option available for the registration in My Messages, update the necessary data or documentation. Once the registration is revised, you may accept the updates which will transfer the registration back to the Assessment team for processing. Please be aware that if you do not update and resubmit the registration data within ten (10) days this may result in your registration being cancelled and the assessment will not proceed to your Retailer(s). If you have any questions, please contact WERCSmart Customer Support via email (WERCSmartCustomer@UL.com, chat, or call 877-642-6753. Thank you for your prompt attention to this matter. The WERCSmart Assessment Team



Scenario: [144121] Suspended - Product Type (Recommended Use) Differs on Label or Safety Data Sheet

Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
And In SHA Manager I click on bottom menu item: Search
And In SHA Manager ProductSearch page I run search:
| SearchTerm     | SearchValue                     |
| Status	     | Assigned                        |
Then In SHA Manager I select the first product
And In SHA Manager I click on bottom menu item: Suspended
And In the Suspended dialog I Select the following clients: All
And In the Suspended dialog in the Select Regulatory Specialist drop down I choose: Automated QASha
And In the Suspended dialog in the Select Subject drop down I choose: Product Type (Recommended Use) Differs on Label or Safety Data Sheet
And In the Suspended dialog in the Supplier Message field I should see: During our assessment and data creation for your product, we found conflicting information and may impact the handling and storage of the product.   In Section 13 of the Safety Data Sheet (SDS), the document states this product is a RCRA waste, however based on the flash point, corrosivity, or toxicity indicated by the product data, this product does not appear to be classified as a Federal Waste (RCRA). Please clarify for proper waste data to be generated for the retailers or provide an updated Safety Data Sheet (SDS).
And In the Suspended dialog below the Supplier Message field I see the following text in red: These comments may be viewed by the Supplier in the portal, so be careful.
And In the Suspended dialog in the Internal Product Note field I should see: During our assessment and data creation for your product, we found conflicting information and may impact the handling and storage of the product. In Section 13 of the Safety Data Sheet (SDS), the document states this product is a RCRA waste, however based on the flash point, corrosivity, or toxicity indicated by the product data, this product does not appear to be classified as a Federal Waste (RCRA). Please clarify for proper waste data to be generated for the retailers or provide an updated Safety Data Sheet (SDS).
And In the Suspended dialog I click Suspend
And I check that the alert displayed contains text: Product Successfully updated. The product (ID) has been place into recertification Product Message for product (ID) has been created successfully
And I close alert
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase144185)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase144185 and its status is: Suspended
Then I Check there should be a new suspension notification email for user: ProductAccountEmail for the Product saved as: TestCase144185 with the suspension subject of: Document Issue - RCRA (Federal Waste) and check it does not contain text from the table:
| SearchText |
Then the text of the email should show: Your product assessment has been Suspended. During our assessment and data creation for your product, we found conflicting information and may impact the handling and storage of the product. In Section 13 of the Safety Data Sheet (SDS), the document states this product is a RCRA waste, however based on the flash point, corrosivity, or toxicity indicated by the product data, this product does not appear to be classified as a Federal Waste (RCRA). Please clarify for proper waste data to be generated for the retailers or provide an updated Safety Data Sheet (SDS). To resolve this issue, please log into WERCSmart. Using either the RESOLVE option in the ALERT area on the Home Page, or using the RESOLVE option available for the registration in My Messages, update the necessary data or documentation. Once the registration is revised, you may accept the updates which will transfer the registration back to the Assessment team for processing. Please be aware that if you do not update and resubmit the registration data within ten (10) days this may result in your registration being cancelled and the assessment will not proceed to your Retailer(s). If you have any questions, please contact WERCSmart Customer Support via email (WERCSmartCustomer@UL.com, chat, or call 877-642-6753. Thank you for your prompt attention to this matter. The WERCSmart Assessment Team



Scenario: [144120] Suspended - Physical Properties

Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
And In SHA Manager I click on bottom menu item: Search
And In SHA Manager ProductSearch page I run search:
| SearchTerm     | SearchValue                     |
| Status	     | Assigned                        |
Then In SHA Manager I select the first product
And In SHA Manager I click on bottom menu item: Suspended
And In the Suspended dialog I Select the following clients: All
And In the Suspended dialog in the Select Regulatory Specialist drop down I choose: Automated QASha
And In the Suspended dialog in the Select Subject drop down I choose: Physical Properties
And In the Suspended dialog in the Supplier Message field I should see: During our assessment and data creation for your product, we found conflicting information and may impact the handling and storage of the product.   In Section 13 of the Safety Data Sheet (SDS), the document states this product is a RCRA waste, however based on the flash point, corrosivity, or toxicity indicated by the product data, this product does not appear to be classified as a Federal Waste (RCRA). Please clarify for proper waste data to be generated for the retailers or provide an updated Safety Data Sheet (SDS).
And In the Suspended dialog below the Supplier Message field I see the following text in red: These comments may be viewed by the Supplier in the portal, so be careful.
And In the Suspended dialog in the Internal Product Note field I should see: During our assessment and data creation for your product, we found conflicting information and may impact the handling and storage of the product. In Section 13 of the Safety Data Sheet (SDS), the document states this product is a RCRA waste, however based on the flash point, corrosivity, or toxicity indicated by the product data, this product does not appear to be classified as a Federal Waste (RCRA). Please clarify for proper waste data to be generated for the retailers or provide an updated Safety Data Sheet (SDS).
And In the Suspended dialog I click Suspend
And I check that the alert displayed contains text: Product Successfully updated. The product (ID) has been place into recertification Product Message for product (ID) has been created successfully
And I close alert
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase144185)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase144185 and its status is: Suspended
Then I Check there should be a new suspension notification email for user: ProductAccountEmail for the Product saved as: TestCase144185 with the suspension subject of: Document Issue - RCRA (Federal Waste) and check it does not contain text from the table:
| SearchText |
Then the text of the email should show: Your product assessment has been Suspended. During our assessment and data creation for your product, we found conflicting information and may impact the handling and storage of the product. In Section 13 of the Safety Data Sheet (SDS), the document states this product is a RCRA waste, however based on the flash point, corrosivity, or toxicity indicated by the product data, this product does not appear to be classified as a Federal Waste (RCRA). Please clarify for proper waste data to be generated for the retailers or provide an updated Safety Data Sheet (SDS). To resolve this issue, please log into WERCSmart. Using either the RESOLVE option in the ALERT area on the Home Page, or using the RESOLVE option available for the registration in My Messages, update the necessary data or documentation. Once the registration is revised, you may accept the updates which will transfer the registration back to the Assessment team for processing. Please be aware that if you do not update and resubmit the registration data within ten (10) days this may result in your registration being cancelled and the assessment will not proceed to your Retailer(s). If you have any questions, please contact WERCSmart Customer Support via email (WERCSmartCustomer@UL.com, chat, or call 877-642-6753. Thank you for your prompt attention to this matter. The WERCSmart Assessment Team



Scenario: [144113] Suspended - Battery - Possible Transportation Exception Missed

Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
And In SHA Manager I click on bottom menu item: Search
And In SHA Manager ProductSearch page I run search:
| SearchTerm     | SearchValue                     |
| Status	     | Assigned                        |
Then In SHA Manager I select the first product
And In SHA Manager I click on bottom menu item: Suspended
And In the Suspended dialog I Select the following clients: All
And In the Suspended dialog in the Select Regulatory Specialist drop down I choose: Automated QASha
And In the Suspended dialog in the Select Subject drop down I choose: Battery - Possible Transportation Exception Missed
And In the Suspended dialog in the Supplier Message field I should see: During our assessment and data creation for your product, we found conflicting information and may impact the handling and storage of the product.   In Section 13 of the Safety Data Sheet (SDS), the document states this product is a RCRA waste, however based on the flash point, corrosivity, or toxicity indicated by the product data, this product does not appear to be classified as a Federal Waste (RCRA). Please clarify for proper waste data to be generated for the retailers or provide an updated Safety Data Sheet (SDS).
And In the Suspended dialog below the Supplier Message field I see the following text in red: These comments may be viewed by the Supplier in the portal, so be careful.
And In the Suspended dialog in the Internal Product Note field I should see: During our assessment and data creation for your product, we found conflicting information and may impact the handling and storage of the product. In Section 13 of the Safety Data Sheet (SDS), the document states this product is a RCRA waste, however based on the flash point, corrosivity, or toxicity indicated by the product data, this product does not appear to be classified as a Federal Waste (RCRA). Please clarify for proper waste data to be generated for the retailers or provide an updated Safety Data Sheet (SDS).
And In the Suspended dialog I click Suspend
And I check that the alert displayed contains text: Product Successfully updated. The product (ID) has been place into recertification Product Message for product (ID) has been created successfully
And I close alert
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase144185)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase144185 and its status is: Suspended
Then I Check there should be a new suspension notification email for user: ProductAccountEmail for the Product saved as: TestCase144185 with the suspension subject of: Document Issue - RCRA (Federal Waste) and check it does not contain text from the table:
| SearchText |
Then the text of the email should show: Your product assessment has been Suspended. During our assessment and data creation for your product, we found conflicting information and may impact the handling and storage of the product. In Section 13 of the Safety Data Sheet (SDS), the document states this product is a RCRA waste, however based on the flash point, corrosivity, or toxicity indicated by the product data, this product does not appear to be classified as a Federal Waste (RCRA). Please clarify for proper waste data to be generated for the retailers or provide an updated Safety Data Sheet (SDS). To resolve this issue, please log into WERCSmart. Using either the RESOLVE option in the ALERT area on the Home Page, or using the RESOLVE option available for the registration in My Messages, update the necessary data or documentation. Once the registration is revised, you may accept the updates which will transfer the registration back to the Assessment team for processing. Please be aware that if you do not update and resubmit the registration data within ten (10) days this may result in your registration being cancelled and the assessment will not proceed to your Retailer(s). If you have any questions, please contact WERCSmart Customer Support via email (WERCSmartCustomer@UL.com, chat, or call 877-642-6753. Thank you for your prompt attention to this matter. The WERCSmart Assessment Team



Scenario: [144112] Suspended - Kit - Missing Retailers on Registrations Contained in the Kit

Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
And In SHA Manager I click on bottom menu item: Search
And In SHA Manager ProductSearch page I run search:
| SearchTerm     | SearchValue                     |
| Status	     | Assigned                        |
Then In SHA Manager I select the first product
And In SHA Manager I click on bottom menu item: Suspended
And In the Suspended dialog I Select the following clients: All
And In the Suspended dialog in the Select Regulatory Specialist drop down I choose: Automated QASha
And In the Suspended dialog in the Select Subject drop down I choose: Kit - Missing Retailers on Registrations Contained in the Kit
And In the Suspended dialog in the Supplier Message field I should see: During our assessment and data creation for your product, we found conflicting information and may impact the handling and storage of the product.   In Section 13 of the Safety Data Sheet (SDS), the document states this product is a RCRA waste, however based on the flash point, corrosivity, or toxicity indicated by the product data, this product does not appear to be classified as a Federal Waste (RCRA). Please clarify for proper waste data to be generated for the retailers or provide an updated Safety Data Sheet (SDS).
And In the Suspended dialog below the Supplier Message field I see the following text in red: These comments may be viewed by the Supplier in the portal, so be careful.
And In the Suspended dialog in the Internal Product Note field I should see: During our assessment and data creation for your product, we found conflicting information and may impact the handling and storage of the product. In Section 13 of the Safety Data Sheet (SDS), the document states this product is a RCRA waste, however based on the flash point, corrosivity, or toxicity indicated by the product data, this product does not appear to be classified as a Federal Waste (RCRA). Please clarify for proper waste data to be generated for the retailers or provide an updated Safety Data Sheet (SDS).
And In the Suspended dialog I click Suspend
And I check that the alert displayed contains text: Product Successfully updated. The product (ID) has been place into recertification Product Message for product (ID) has been created successfully
And I close alert
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase144185)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase144185 and its status is: Suspended
Then I Check there should be a new suspension notification email for user: ProductAccountEmail for the Product saved as: TestCase144185 with the suspension subject of: Document Issue - RCRA (Federal Waste) and check it does not contain text from the table:
| SearchText |
Then the text of the email should show: Your product assessment has been Suspended. During our assessment and data creation for your product, we found conflicting information and may impact the handling and storage of the product. In Section 13 of the Safety Data Sheet (SDS), the document states this product is a RCRA waste, however based on the flash point, corrosivity, or toxicity indicated by the product data, this product does not appear to be classified as a Federal Waste (RCRA). Please clarify for proper waste data to be generated for the retailers or provide an updated Safety Data Sheet (SDS). To resolve this issue, please log into WERCSmart. Using either the RESOLVE option in the ALERT area on the Home Page, or using the RESOLVE option available for the registration in My Messages, update the necessary data or documentation. Once the registration is revised, you may accept the updates which will transfer the registration back to the Assessment team for processing. Please be aware that if you do not update and resubmit the registration data within ten (10) days this may result in your registration being cancelled and the assessment will not proceed to your Retailer(s). If you have any questions, please contact WERCSmart Customer Support via email (WERCSmartCustomer@UL.com, chat, or call 877-642-6753. Thank you for your prompt attention to this matter. The WERCSmart Assessment Team



Scenario: [144099] Suspended - Ingredient Issue - Document and Ingredients Do Not Match

Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
And In SHA Manager I click on bottom menu item: Search
And In SHA Manager ProductSearch page I run search:
| SearchTerm     | SearchValue                     |
| Status	     | Assigned                        |
Then In SHA Manager I select the first product
And In SHA Manager I click on bottom menu item: Suspended
And In the Suspended dialog I Select the following clients: All
And In the Suspended dialog in the Select Regulatory Specialist drop down I choose: Automated QASha
And In the Suspended dialog in the Select Subject drop down I choose: Ingredient Issue - Document and Ingredients Do Not Match
And In the Suspended dialog in the Supplier Message field I should see: During our assessment and data creation for your product, we found conflicting information and may impact the handling and storage of the product.   In Section 13 of the Safety Data Sheet (SDS), the document states this product is a RCRA waste, however based on the flash point, corrosivity, or toxicity indicated by the product data, this product does not appear to be classified as a Federal Waste (RCRA). Please clarify for proper waste data to be generated for the retailers or provide an updated Safety Data Sheet (SDS).
And In the Suspended dialog below the Supplier Message field I see the following text in red: These comments may be viewed by the Supplier in the portal, so be careful.
And In the Suspended dialog in the Internal Product Note field I should see: During our assessment and data creation for your product, we found conflicting information and may impact the handling and storage of the product. In Section 13 of the Safety Data Sheet (SDS), the document states this product is a RCRA waste, however based on the flash point, corrosivity, or toxicity indicated by the product data, this product does not appear to be classified as a Federal Waste (RCRA). Please clarify for proper waste data to be generated for the retailers or provide an updated Safety Data Sheet (SDS).
And In the Suspended dialog I click Suspend
And I check that the alert displayed contains text: Product Successfully updated. The product (ID) has been place into recertification Product Message for product (ID) has been created successfully
And I close alert
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase144185)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase144185 and its status is: Suspended
Then I Check there should be a new suspension notification email for user: ProductAccountEmail for the Product saved as: TestCase144185 with the suspension subject of: Document Issue - RCRA (Federal Waste) and check it does not contain text from the table:
| SearchText |
Then the text of the email should show: Your product assessment has been Suspended. During our assessment and data creation for your product, we found conflicting information and may impact the handling and storage of the product. In Section 13 of the Safety Data Sheet (SDS), the document states this product is a RCRA waste, however based on the flash point, corrosivity, or toxicity indicated by the product data, this product does not appear to be classified as a Federal Waste (RCRA). Please clarify for proper waste data to be generated for the retailers or provide an updated Safety Data Sheet (SDS). To resolve this issue, please log into WERCSmart. Using either the RESOLVE option in the ALERT area on the Home Page, or using the RESOLVE option available for the registration in My Messages, update the necessary data or documentation. Once the registration is revised, you may accept the updates which will transfer the registration back to the Assessment team for processing. Please be aware that if you do not update and resubmit the registration data within ten (10) days this may result in your registration being cancelled and the assessment will not proceed to your Retailer(s). If you have any questions, please contact WERCSmart Customer Support via email (WERCSmartCustomer@UL.com, chat, or call 877-642-6753. Thank you for your prompt attention to this matter. The WERCSmart Assessment Team



Scenario: [143993] Suspended - Ingredient Issue - Fragrance Component and Label or SDS

Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
And In SHA Manager I click on bottom menu item: Search
And In SHA Manager ProductSearch page I run search:
| SearchTerm     | SearchValue                     |
| Status	     | Assigned                        |
Then In SHA Manager I select the first product
And In SHA Manager I click on bottom menu item: Suspended
And In the Suspended dialog I Select the following clients: All
And In the Suspended dialog in the Select Regulatory Specialist drop down I choose: Automated QASha
And In the Suspended dialog in the Select Subject drop down I choose: Ingredient Issue - Fragrance Component and Label or SDS
And In the Suspended dialog in the Supplier Message field I should see: During our assessment and data creation for your product, we found conflicting information and may impact the handling and storage of the product.   In Section 13 of the Safety Data Sheet (SDS), the document states this product is a RCRA waste, however based on the flash point, corrosivity, or toxicity indicated by the product data, this product does not appear to be classified as a Federal Waste (RCRA). Please clarify for proper waste data to be generated for the retailers or provide an updated Safety Data Sheet (SDS).
And In the Suspended dialog below the Supplier Message field I see the following text in red: These comments may be viewed by the Supplier in the portal, so be careful.
And In the Suspended dialog in the Internal Product Note field I should see: During our assessment and data creation for your product, we found conflicting information and may impact the handling and storage of the product. In Section 13 of the Safety Data Sheet (SDS), the document states this product is a RCRA waste, however based on the flash point, corrosivity, or toxicity indicated by the product data, this product does not appear to be classified as a Federal Waste (RCRA). Please clarify for proper waste data to be generated for the retailers or provide an updated Safety Data Sheet (SDS).
And In the Suspended dialog I click Suspend
And I check that the alert displayed contains text: Product Successfully updated. The product (ID) has been place into recertification Product Message for product (ID) has been created successfully
And I close alert
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase144185)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase144185 and its status is: Suspended
Then I Check there should be a new suspension notification email for user: ProductAccountEmail for the Product saved as: TestCase144185 with the suspension subject of: Document Issue - RCRA (Federal Waste) and check it does not contain text from the table:
| SearchText |
Then the text of the email should show: Your product assessment has been Suspended. During our assessment and data creation for your product, we found conflicting information and may impact the handling and storage of the product. In Section 13 of the Safety Data Sheet (SDS), the document states this product is a RCRA waste, however based on the flash point, corrosivity, or toxicity indicated by the product data, this product does not appear to be classified as a Federal Waste (RCRA). Please clarify for proper waste data to be generated for the retailers or provide an updated Safety Data Sheet (SDS). To resolve this issue, please log into WERCSmart. Using either the RESOLVE option in the ALERT area on the Home Page, or using the RESOLVE option available for the registration in My Messages, update the necessary data or documentation. Once the registration is revised, you may accept the updates which will transfer the registration back to the Assessment team for processing. Please be aware that if you do not update and resubmit the registration data within ten (10) days this may result in your registration being cancelled and the assessment will not proceed to your Retailer(s). If you have any questions, please contact WERCSmart Customer Support via email (WERCSmartCustomer@UL.com, chat, or call 877-642-6753. Thank you for your prompt attention to this matter. The WERCSmart Assessment Team



Scenario: [143989] Suspended - Ingredients - Flavor - Generic Used without GRAS Provided

Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
And In SHA Manager I click on bottom menu item: Search
And In SHA Manager ProductSearch page I run search:
| SearchTerm     | SearchValue                     |
| Status	     | Assigned                        |
Then In SHA Manager I select the first product
And In SHA Manager I click on bottom menu item: Suspended
And In the Suspended dialog I Select the following clients: All
And In the Suspended dialog in the Select Regulatory Specialist drop down I choose: Automated QASha
And In the Suspended dialog in the Select Subject drop down I choose: Ingredients - Flavor - Generic Used without GRAS Provided
And In the Suspended dialog in the Supplier Message field I should see: During our assessment and data creation for your product, we found conflicting information and may impact the handling and storage of the product.   In Section 13 of the Safety Data Sheet (SDS), the document states this product is a RCRA waste, however based on the flash point, corrosivity, or toxicity indicated by the product data, this product does not appear to be classified as a Federal Waste (RCRA). Please clarify for proper waste data to be generated for the retailers or provide an updated Safety Data Sheet (SDS).
And In the Suspended dialog below the Supplier Message field I see the following text in red: These comments may be viewed by the Supplier in the portal, so be careful.
And In the Suspended dialog in the Internal Product Note field I should see: During our assessment and data creation for your product, we found conflicting information and may impact the handling and storage of the product. In Section 13 of the Safety Data Sheet (SDS), the document states this product is a RCRA waste, however based on the flash point, corrosivity, or toxicity indicated by the product data, this product does not appear to be classified as a Federal Waste (RCRA). Please clarify for proper waste data to be generated for the retailers or provide an updated Safety Data Sheet (SDS).
And In the Suspended dialog I click Suspend
And I check that the alert displayed contains text: Product Successfully updated. The product (ID) has been place into recertification Product Message for product (ID) has been created successfully
And I close alert
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase144185)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase144185 and its status is: Suspended
Then I Check there should be a new suspension notification email for user: ProductAccountEmail for the Product saved as: TestCase144185 with the suspension subject of: Document Issue - RCRA (Federal Waste) and check it does not contain text from the table:
| SearchText |
Then the text of the email should show: Your product assessment has been Suspended. During our assessment and data creation for your product, we found conflicting information and may impact the handling and storage of the product. In Section 13 of the Safety Data Sheet (SDS), the document states this product is a RCRA waste, however based on the flash point, corrosivity, or toxicity indicated by the product data, this product does not appear to be classified as a Federal Waste (RCRA). Please clarify for proper waste data to be generated for the retailers or provide an updated Safety Data Sheet (SDS). To resolve this issue, please log into WERCSmart. Using either the RESOLVE option in the ALERT area on the Home Page, or using the RESOLVE option available for the registration in My Messages, update the necessary data or documentation. Once the registration is revised, you may accept the updates which will transfer the registration back to the Assessment team for processing. Please be aware that if you do not update and resubmit the registration data within ten (10) days this may result in your registration being cancelled and the assessment will not proceed to your Retailer(s). If you have any questions, please contact WERCSmart Customer Support via email (WERCSmartCustomer@UL.com, chat, or call 877-642-6753. Thank you for your prompt attention to this matter. The WERCSmart Assessment Team



Scenario: [143864] Suspended - Ingredients - Flavor Component and Label or Safety Data Sheet (SDS)

Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
And In SHA Manager I click on bottom menu item: Search
And In SHA Manager ProductSearch page I run search:
| SearchTerm     | SearchValue                     |
| Status	     | Assigned                        |
Then In SHA Manager I select the first product
And In SHA Manager I click on bottom menu item: Suspended
And In the Suspended dialog I Select the following clients: All
And In the Suspended dialog in the Select Regulatory Specialist drop down I choose: Automated QASha
And In the Suspended dialog in the Select Subject drop down I choose: Ingredients - Flavor Component and Label or Safety Data Sheet (SDS)
And In the Suspended dialog in the Supplier Message field I should see: During our assessment and data creation for your product, we found conflicting information and may impact the handling and storage of the product.   In Section 13 of the Safety Data Sheet (SDS), the document states this product is a RCRA waste, however based on the flash point, corrosivity, or toxicity indicated by the product data, this product does not appear to be classified as a Federal Waste (RCRA). Please clarify for proper waste data to be generated for the retailers or provide an updated Safety Data Sheet (SDS).
And In the Suspended dialog below the Supplier Message field I see the following text in red: These comments may be viewed by the Supplier in the portal, so be careful.
And In the Suspended dialog in the Internal Product Note field I should see: During our assessment and data creation for your product, we found conflicting information and may impact the handling and storage of the product. In Section 13 of the Safety Data Sheet (SDS), the document states this product is a RCRA waste, however based on the flash point, corrosivity, or toxicity indicated by the product data, this product does not appear to be classified as a Federal Waste (RCRA). Please clarify for proper waste data to be generated for the retailers or provide an updated Safety Data Sheet (SDS).
And In the Suspended dialog I click Suspend
And I check that the alert displayed contains text: Product Successfully updated. The product (ID) has been place into recertification Product Message for product (ID) has been created successfully
And I close alert
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase144185)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase144185 and its status is: Suspended
Then I Check there should be a new suspension notification email for user: ProductAccountEmail for the Product saved as: TestCase144185 with the suspension subject of: Document Issue - RCRA (Federal Waste) and check it does not contain text from the table:
| SearchText |
Then the text of the email should show: Your product assessment has been Suspended. During our assessment and data creation for your product, we found conflicting information and may impact the handling and storage of the product. In Section 13 of the Safety Data Sheet (SDS), the document states this product is a RCRA waste, however based on the flash point, corrosivity, or toxicity indicated by the product data, this product does not appear to be classified as a Federal Waste (RCRA). Please clarify for proper waste data to be generated for the retailers or provide an updated Safety Data Sheet (SDS). To resolve this issue, please log into WERCSmart. Using either the RESOLVE option in the ALERT area on the Home Page, or using the RESOLVE option available for the registration in My Messages, update the necessary data or documentation. Once the registration is revised, you may accept the updates which will transfer the registration back to the Assessment team for processing. Please be aware that if you do not update and resubmit the registration data within ten (10) days this may result in your registration being cancelled and the assessment will not proceed to your Retailer(s). If you have any questions, please contact WERCSmart Customer Support via email (WERCSmartCustomer@UL.com, chat, or call 877-642-6753. Thank you for your prompt attention to this matter. The WERCSmart Assessment Team



Scenario: [143861] Suspended - 3rd-Party Formula Public Disclosure and Data Tier Consent Required - Urgent

Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
And In SHA Manager I click on bottom menu item: Search
And In SHA Manager ProductSearch page I run search:
| SearchTerm     | SearchValue                     |
| Status	     | Assigned                        |
Then In SHA Manager I select the first product
And In SHA Manager I click on bottom menu item: Suspended
And In the Suspended dialog I Select the following clients: All
And In the Suspended dialog in the Select Regulatory Specialist drop down I choose: Automated QASha
And In the Suspended dialog in the Select Subject drop down I choose: 3rd-Party Formula Public Disclosure and Data Tier Consent Required - Urgent
And In the Suspended dialog in the Supplier Message field I should see: During our assessment and data creation for your product, we found conflicting information and may impact the handling and storage of the product.   In Section 13 of the Safety Data Sheet (SDS), the document states this product is a RCRA waste, however based on the flash point, corrosivity, or toxicity indicated by the product data, this product does not appear to be classified as a Federal Waste (RCRA). Please clarify for proper waste data to be generated for the retailers or provide an updated Safety Data Sheet (SDS).
And In the Suspended dialog below the Supplier Message field I see the following text in red: These comments may be viewed by the Supplier in the portal, so be careful.
And In the Suspended dialog in the Internal Product Note field I should see: During our assessment and data creation for your product, we found conflicting information and may impact the handling and storage of the product. In Section 13 of the Safety Data Sheet (SDS), the document states this product is a RCRA waste, however based on the flash point, corrosivity, or toxicity indicated by the product data, this product does not appear to be classified as a Federal Waste (RCRA). Please clarify for proper waste data to be generated for the retailers or provide an updated Safety Data Sheet (SDS).
And In the Suspended dialog I click Suspend
And I check that the alert displayed contains text: Product Successfully updated. The product (ID) has been place into recertification Product Message for product (ID) has been created successfully
And I close alert
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase144185)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase144185 and its status is: Suspended
Then I Check there should be a new suspension notification email for user: ProductAccountEmail for the Product saved as: TestCase144185 with the suspension subject of: Document Issue - RCRA (Federal Waste) and check it does not contain text from the table:
| SearchText |
Then the text of the email should show: Your product assessment has been Suspended. During our assessment and data creation for your product, we found conflicting information and may impact the handling and storage of the product. In Section 13 of the Safety Data Sheet (SDS), the document states this product is a RCRA waste, however based on the flash point, corrosivity, or toxicity indicated by the product data, this product does not appear to be classified as a Federal Waste (RCRA). Please clarify for proper waste data to be generated for the retailers or provide an updated Safety Data Sheet (SDS). To resolve this issue, please log into WERCSmart. Using either the RESOLVE option in the ALERT area on the Home Page, or using the RESOLVE option available for the registration in My Messages, update the necessary data or documentation. Once the registration is revised, you may accept the updates which will transfer the registration back to the Assessment team for processing. Please be aware that if you do not update and resubmit the registration data within ten (10) days this may result in your registration being cancelled and the assessment will not proceed to your Retailer(s). If you have any questions, please contact WERCSmart Customer Support via email (WERCSmartCustomer@UL.com, chat, or call 877-642-6753. Thank you for your prompt attention to this matter. The WERCSmart Assessment Team



Scenario: [143849] Suspended - Flash Point - Safety Data Sheet (SDS) or Article Information Sheet (AIS) Discrepancy

Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
And In SHA Manager I click on bottom menu item: Search
And In SHA Manager ProductSearch page I run search:
| SearchTerm     | SearchValue                     |
| Status	     | Assigned                        |
Then In SHA Manager I select the first product
And In SHA Manager I click on bottom menu item: Suspended
And In the Suspended dialog I Select the following clients: All
And In the Suspended dialog in the Select Regulatory Specialist drop down I choose: Automated QASha
And In the Suspended dialog in the Select Subject drop down I choose: Flash Point - Safety Data Sheet (SDS) or Article Information Sheet (AIS) Discrepancy
And In the Suspended dialog in the Supplier Message field I should see: During our assessment and data creation for your product, we found conflicting information and may impact the handling and storage of the product.   In Section 13 of the Safety Data Sheet (SDS), the document states this product is a RCRA waste, however based on the flash point, corrosivity, or toxicity indicated by the product data, this product does not appear to be classified as a Federal Waste (RCRA). Please clarify for proper waste data to be generated for the retailers or provide an updated Safety Data Sheet (SDS).
And In the Suspended dialog below the Supplier Message field I see the following text in red: These comments may be viewed by the Supplier in the portal, so be careful.
And In the Suspended dialog in the Internal Product Note field I should see: During our assessment and data creation for your product, we found conflicting information and may impact the handling and storage of the product. In Section 13 of the Safety Data Sheet (SDS), the document states this product is a RCRA waste, however based on the flash point, corrosivity, or toxicity indicated by the product data, this product does not appear to be classified as a Federal Waste (RCRA). Please clarify for proper waste data to be generated for the retailers or provide an updated Safety Data Sheet (SDS).
And In the Suspended dialog I click Suspend
And I check that the alert displayed contains text: Product Successfully updated. The product (ID) has been place into recertification Product Message for product (ID) has been created successfully
And I close alert
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase144185)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase144185 and its status is: Suspended
Then I Check there should be a new suspension notification email for user: ProductAccountEmail for the Product saved as: TestCase144185 with the suspension subject of: Document Issue - RCRA (Federal Waste) and check it does not contain text from the table:
| SearchText |
Then the text of the email should show: Your product assessment has been Suspended. During our assessment and data creation for your product, we found conflicting information and may impact the handling and storage of the product. In Section 13 of the Safety Data Sheet (SDS), the document states this product is a RCRA waste, however based on the flash point, corrosivity, or toxicity indicated by the product data, this product does not appear to be classified as a Federal Waste (RCRA). Please clarify for proper waste data to be generated for the retailers or provide an updated Safety Data Sheet (SDS). To resolve this issue, please log into WERCSmart. Using either the RESOLVE option in the ALERT area on the Home Page, or using the RESOLVE option available for the registration in My Messages, update the necessary data or documentation. Once the registration is revised, you may accept the updates which will transfer the registration back to the Assessment team for processing. Please be aware that if you do not update and resubmit the registration data within ten (10) days this may result in your registration being cancelled and the assessment will not proceed to your Retailer(s). If you have any questions, please contact WERCSmart Customer Support via email (WERCSmartCustomer@UL.com, chat, or call 877-642-6753. Thank you for your prompt attention to this matter. The WERCSmart Assessment Team


Scenario: [143846] Suspended - WERCSmart Data and Assessment Maintenance - Data Quality (DQ)

Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
And In SHA Manager I click on bottom menu item: Search
And In SHA Manager ProductSearch page I run search:
| SearchTerm     | SearchValue                     |
| Status	     | Assigned                        |
Then In SHA Manager I select the first product
And In SHA Manager I click on bottom menu item: Suspended
And In the Suspended dialog I Select the following clients: All
And In the Suspended dialog in the Select Regulatory Specialist drop down I choose: Automated QASha
And In the Suspended dialog in the Select Subject drop down I choose: WERCSmart Data and Assessment Maintenance - Data Quality (DQ)
And In the Suspended dialog in the Supplier Message field I should see: During our assessment and data creation for your product, we found conflicting information and may impact the handling and storage of the product.   In Section 13 of the Safety Data Sheet (SDS), the document states this product is a RCRA waste, however based on the flash point, corrosivity, or toxicity indicated by the product data, this product does not appear to be classified as a Federal Waste (RCRA). Please clarify for proper waste data to be generated for the retailers or provide an updated Safety Data Sheet (SDS).
And In the Suspended dialog below the Supplier Message field I see the following text in red: These comments may be viewed by the Supplier in the portal, so be careful.
And In the Suspended dialog in the Internal Product Note field I should see: During our assessment and data creation for your product, we found conflicting information and may impact the handling and storage of the product. In Section 13 of the Safety Data Sheet (SDS), the document states this product is a RCRA waste, however based on the flash point, corrosivity, or toxicity indicated by the product data, this product does not appear to be classified as a Federal Waste (RCRA). Please clarify for proper waste data to be generated for the retailers or provide an updated Safety Data Sheet (SDS).
And In the Suspended dialog I click Suspend
And I check that the alert displayed contains text: Product Successfully updated. The product (ID) has been place into recertification Product Message for product (ID) has been created successfully
And I close alert
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase144185)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase144185 and its status is: Suspended
Then I Check there should be a new suspension notification email for user: ProductAccountEmail for the Product saved as: TestCase144185 with the suspension subject of: Document Issue - RCRA (Federal Waste) and check it does not contain text from the table:
| SearchText |
Then the text of the email should show: Your product assessment has been Suspended. During our assessment and data creation for your product, we found conflicting information and may impact the handling and storage of the product. In Section 13 of the Safety Data Sheet (SDS), the document states this product is a RCRA waste, however based on the flash point, corrosivity, or toxicity indicated by the product data, this product does not appear to be classified as a Federal Waste (RCRA). Please clarify for proper waste data to be generated for the retailers or provide an updated Safety Data Sheet (SDS). To resolve this issue, please log into WERCSmart. Using either the RESOLVE option in the ALERT area on the Home Page, or using the RESOLVE option available for the registration in My Messages, update the necessary data or documentation. Once the registration is revised, you may accept the updates which will transfer the registration back to the Assessment team for processing. Please be aware that if you do not update and resubmit the registration data within ten (10) days this may result in your registration being cancelled and the assessment will not proceed to your Retailer(s). If you have any questions, please contact WERCSmart Customer Support via email (WERCSmartCustomer@UL.com, chat, or call 877-642-6753. Thank you for your prompt attention to this matter. The WERCSmart Assessment Team



Scenario: [143836] Suspended - Registration Includes Invalid Battery Selection

Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
And In SHA Manager I click on bottom menu item: Search
And In SHA Manager ProductSearch page I run search:
| SearchTerm     | SearchValue                     |
| Status	     | Assigned                        |
Then In SHA Manager I select the first product
And In SHA Manager I click on bottom menu item: Suspended
And In the Suspended dialog I Select the following clients: All
And In the Suspended dialog in the Select Regulatory Specialist drop down I choose: Automated QASha
And In the Suspended dialog in the Select Subject drop down I choose: Registration Includes Invalid Battery Selection
And In the Suspended dialog in the Supplier Message field I should see: During our assessment and data creation for your product, we found conflicting information and may impact the handling and storage of the product.   In Section 13 of the Safety Data Sheet (SDS), the document states this product is a RCRA waste, however based on the flash point, corrosivity, or toxicity indicated by the product data, this product does not appear to be classified as a Federal Waste (RCRA). Please clarify for proper waste data to be generated for the retailers or provide an updated Safety Data Sheet (SDS).
And In the Suspended dialog below the Supplier Message field I see the following text in red: These comments may be viewed by the Supplier in the portal, so be careful.
And In the Suspended dialog in the Internal Product Note field I should see: During our assessment and data creation for your product, we found conflicting information and may impact the handling and storage of the product. In Section 13 of the Safety Data Sheet (SDS), the document states this product is a RCRA waste, however based on the flash point, corrosivity, or toxicity indicated by the product data, this product does not appear to be classified as a Federal Waste (RCRA). Please clarify for proper waste data to be generated for the retailers or provide an updated Safety Data Sheet (SDS).
And In the Suspended dialog I click Suspend
And I check that the alert displayed contains text: Product Successfully updated. The product (ID) has been place into recertification Product Message for product (ID) has been created successfully
And I close alert
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase144185)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase144185 and its status is: Suspended
Then I Check there should be a new suspension notification email for user: ProductAccountEmail for the Product saved as: TestCase144185 with the suspension subject of: Document Issue - RCRA (Federal Waste) and check it does not contain text from the table:
| SearchText |
Then the text of the email should show: Your product assessment has been Suspended. During our assessment and data creation for your product, we found conflicting information and may impact the handling and storage of the product. In Section 13 of the Safety Data Sheet (SDS), the document states this product is a RCRA waste, however based on the flash point, corrosivity, or toxicity indicated by the product data, this product does not appear to be classified as a Federal Waste (RCRA). Please clarify for proper waste data to be generated for the retailers or provide an updated Safety Data Sheet (SDS). To resolve this issue, please log into WERCSmart. Using either the RESOLVE option in the ALERT area on the Home Page, or using the RESOLVE option available for the registration in My Messages, update the necessary data or documentation. Once the registration is revised, you may accept the updates which will transfer the registration back to the Assessment team for processing. Please be aware that if you do not update and resubmit the registration data within ten (10) days this may result in your registration being cancelled and the assessment will not proceed to your Retailer(s). If you have any questions, please contact WERCSmart Customer Support via email (WERCSmartCustomer@UL.com, chat, or call 877-642-6753. Thank you for your prompt attention to this matter. The WERCSmart Assessment Team



Scenario: [143812] Suspended - Battery Transportation - Watt Hours

Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
And In SHA Manager I click on bottom menu item: Search
And In SHA Manager ProductSearch page I run search:
| SearchTerm     | SearchValue                     |
| Status	     | Assigned                        |
Then In SHA Manager I select the first product
And In SHA Manager I click on bottom menu item: Suspended
And In the Suspended dialog I Select the following clients: All
And In the Suspended dialog in the Select Regulatory Specialist drop down I choose: Automated QASha
And In the Suspended dialog in the Select Subject drop down I choose: Battery Transportation - Watt Hours
And In the Suspended dialog in the Supplier Message field I should see: During our assessment and data creation for your product, we found conflicting information and may impact the handling and storage of the product.   In Section 13 of the Safety Data Sheet (SDS), the document states this product is a RCRA waste, however based on the flash point, corrosivity, or toxicity indicated by the product data, this product does not appear to be classified as a Federal Waste (RCRA). Please clarify for proper waste data to be generated for the retailers or provide an updated Safety Data Sheet (SDS).
And In the Suspended dialog below the Supplier Message field I see the following text in red: These comments may be viewed by the Supplier in the portal, so be careful.
And In the Suspended dialog in the Internal Product Note field I should see: During our assessment and data creation for your product, we found conflicting information and may impact the handling and storage of the product. In Section 13 of the Safety Data Sheet (SDS), the document states this product is a RCRA waste, however based on the flash point, corrosivity, or toxicity indicated by the product data, this product does not appear to be classified as a Federal Waste (RCRA). Please clarify for proper waste data to be generated for the retailers or provide an updated Safety Data Sheet (SDS).
And In the Suspended dialog I click Suspend
And I check that the alert displayed contains text: Product Successfully updated. The product (ID) has been place into recertification Product Message for product (ID) has been created successfully
And I close alert
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase144185)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase144185 and its status is: Suspended
Then I Check there should be a new suspension notification email for user: ProductAccountEmail for the Product saved as: TestCase144185 with the suspension subject of: Document Issue - RCRA (Federal Waste) and check it does not contain text from the table:
| SearchText |
Then the text of the email should show: Your product assessment has been Suspended. During our assessment and data creation for your product, we found conflicting information and may impact the handling and storage of the product. In Section 13 of the Safety Data Sheet (SDS), the document states this product is a RCRA waste, however based on the flash point, corrosivity, or toxicity indicated by the product data, this product does not appear to be classified as a Federal Waste (RCRA). Please clarify for proper waste data to be generated for the retailers or provide an updated Safety Data Sheet (SDS). To resolve this issue, please log into WERCSmart. Using either the RESOLVE option in the ALERT area on the Home Page, or using the RESOLVE option available for the registration in My Messages, update the necessary data or documentation. Once the registration is revised, you may accept the updates which will transfer the registration back to the Assessment team for processing. Please be aware that if you do not update and resubmit the registration data within ten (10) days this may result in your registration being cancelled and the assessment will not proceed to your Retailer(s). If you have any questions, please contact WERCSmart Customer Support via email (WERCSmartCustomer@UL.com, chat, or call 877-642-6753. Thank you for your prompt attention to this matter. The WERCSmart Assessment Team



Scenario: [143811] Suspended - Battery Formulation or Ingredients

Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
And In SHA Manager I click on bottom menu item: Search
And In SHA Manager ProductSearch page I run search:
| SearchTerm     | SearchValue                     |
| Status	     | Assigned                        |
Then In SHA Manager I select the first product
And In SHA Manager I click on bottom menu item: Suspended
And In the Suspended dialog I Select the following clients: All
And In the Suspended dialog in the Select Regulatory Specialist drop down I choose: Automated QASha
And In the Suspended dialog in the Select Subject drop down I choose: Battery Formulation or Ingredients
And In the Suspended dialog in the Supplier Message field I should see: During our assessment and data creation for your product, we found conflicting information and may impact the handling and storage of the product.   In Section 13 of the Safety Data Sheet (SDS), the document states this product is a RCRA waste, however based on the flash point, corrosivity, or toxicity indicated by the product data, this product does not appear to be classified as a Federal Waste (RCRA). Please clarify for proper waste data to be generated for the retailers or provide an updated Safety Data Sheet (SDS).
And In the Suspended dialog below the Supplier Message field I see the following text in red: These comments may be viewed by the Supplier in the portal, so be careful.
And In the Suspended dialog in the Internal Product Note field I should see: During our assessment and data creation for your product, we found conflicting information and may impact the handling and storage of the product. In Section 13 of the Safety Data Sheet (SDS), the document states this product is a RCRA waste, however based on the flash point, corrosivity, or toxicity indicated by the product data, this product does not appear to be classified as a Federal Waste (RCRA). Please clarify for proper waste data to be generated for the retailers or provide an updated Safety Data Sheet (SDS).
And In the Suspended dialog I click Suspend
And I check that the alert displayed contains text: Product Successfully updated. The product (ID) has been place into recertification Product Message for product (ID) has been created successfully
And I close alert
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase144185)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase144185 and its status is: Suspended
Then I Check there should be a new suspension notification email for user: ProductAccountEmail for the Product saved as: TestCase144185 with the suspension subject of: Document Issue - RCRA (Federal Waste) and check it does not contain text from the table:
| SearchText |
Then the text of the email should show: Your product assessment has been Suspended. During our assessment and data creation for your product, we found conflicting information and may impact the handling and storage of the product. In Section 13 of the Safety Data Sheet (SDS), the document states this product is a RCRA waste, however based on the flash point, corrosivity, or toxicity indicated by the product data, this product does not appear to be classified as a Federal Waste (RCRA). Please clarify for proper waste data to be generated for the retailers or provide an updated Safety Data Sheet (SDS). To resolve this issue, please log into WERCSmart. Using either the RESOLVE option in the ALERT area on the Home Page, or using the RESOLVE option available for the registration in My Messages, update the necessary data or documentation. Once the registration is revised, you may accept the updates which will transfer the registration back to the Assessment team for processing. Please be aware that if you do not update and resubmit the registration data within ten (10) days this may result in your registration being cancelled and the assessment will not proceed to your Retailer(s). If you have any questions, please contact WERCSmart Customer Support via email (WERCSmartCustomer@UL.com, chat, or call 877-642-6753. Thank you for your prompt attention to this matter. The WERCSmart Assessment Team



Scenario: [143668] Suspended - Safety Data Sheet (SDS) or Label Mismatch due to 3rd-Party Formula

Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
And In SHA Manager I click on bottom menu item: Search
And In SHA Manager ProductSearch page I run search:
| SearchTerm     | SearchValue                     |
| Status	     | Assigned                        |
Then In SHA Manager I select the first product
And In SHA Manager I click on bottom menu item: Suspended
And In the Suspended dialog I Select the following clients: All
And In the Suspended dialog in the Select Regulatory Specialist drop down I choose: Automated QASha
And In the Suspended dialog in the Select Subject drop down I choose: Safety Data Sheet (SDS) or Label Mismatch due to 3rd-Party Formula
And In the Suspended dialog in the Supplier Message field I should see: During our assessment and data creation for your product, we found conflicting information and may impact the handling and storage of the product.   In Section 13 of the Safety Data Sheet (SDS), the document states this product is a RCRA waste, however based on the flash point, corrosivity, or toxicity indicated by the product data, this product does not appear to be classified as a Federal Waste (RCRA). Please clarify for proper waste data to be generated for the retailers or provide an updated Safety Data Sheet (SDS).
And In the Suspended dialog below the Supplier Message field I see the following text in red: These comments may be viewed by the Supplier in the portal, so be careful.
And In the Suspended dialog in the Internal Product Note field I should see: During our assessment and data creation for your product, we found conflicting information and may impact the handling and storage of the product. In Section 13 of the Safety Data Sheet (SDS), the document states this product is a RCRA waste, however based on the flash point, corrosivity, or toxicity indicated by the product data, this product does not appear to be classified as a Federal Waste (RCRA). Please clarify for proper waste data to be generated for the retailers or provide an updated Safety Data Sheet (SDS).
And In the Suspended dialog I click Suspend
And I check that the alert displayed contains text: Product Successfully updated. The product (ID) has been place into recertification Product Message for product (ID) has been created successfully
And I close alert
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase144185)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase144185 and its status is: Suspended
Then I Check there should be a new suspension notification email for user: ProductAccountEmail for the Product saved as: TestCase144185 with the suspension subject of: Document Issue - RCRA (Federal Waste) and check it does not contain text from the table:
| SearchText |
Then the text of the email should show: Your product assessment has been Suspended. During our assessment and data creation for your product, we found conflicting information and may impact the handling and storage of the product. In Section 13 of the Safety Data Sheet (SDS), the document states this product is a RCRA waste, however based on the flash point, corrosivity, or toxicity indicated by the product data, this product does not appear to be classified as a Federal Waste (RCRA). Please clarify for proper waste data to be generated for the retailers or provide an updated Safety Data Sheet (SDS). To resolve this issue, please log into WERCSmart. Using either the RESOLVE option in the ALERT area on the Home Page, or using the RESOLVE option available for the registration in My Messages, update the necessary data or documentation. Once the registration is revised, you may accept the updates which will transfer the registration back to the Assessment team for processing. Please be aware that if you do not update and resubmit the registration data within ten (10) days this may result in your registration being cancelled and the assessment will not proceed to your Retailer(s). If you have any questions, please contact WERCSmart Customer Support via email (WERCSmartCustomer@UL.com, chat, or call 877-642-6753. Thank you for your prompt attention to this matter. The WERCSmart Assessment Team




Scenario: [143638] Reject Submission - Product Name is Unclear

Given I call Shared Step 65080 (Login to Studio and Open SHA manager)

# Click on the Srch option at the bottom menu; Product Search Window opens
And In SHA Manager I click on bottom menu item: Search
# From the status drop down select: SUBMITTED
# In the User field put in an email that you have access to, for later to check emails
And In SHA Manager ProductSearch page I run search:
| SearchTerm     | SearchValue                     |
| Status	     | Submitted                        |
# Click Find; Window closes, Screen Refreshes
# Select the checkbox of a product
Then In SHA Manager I select the first product
# Select Reject Submission from the bottom menu;  Product Submission Rejection popup appears
And In SHA Manager I click on bottom menu item: Reject Submission
# Select: Product Name is Unclear
# Confirm that the Subject input field populates with: Product Name is Unclear
And In the Reject Submission dialog I Select Subject: Product Name is Unclear
# Confirm that the Supplier Message is: During our assessment and data creation the product name may generate delays and confusion to your retail clients. Retailers have indicated that Product Names that are not appropriate are to be suspended and the vendor is to correct the information. Product names are important when the packaging may be unavailable to the retail employee,
And In the Reject Submission dialog in the Supplier Message field I should see: During our assessment and data creation for your product, we found conflicting information a
# the next comment starts a new line still in the "Supplier Message"
# Please login to WERCSmart and update the product name. For guidance:
# this also in the Supplier Message it just in a new line: the name should be specific enough so that an employee may find the product in their systems when no UPC or other identifier is available. the Product Name in the WERCSmart system should closely match the product's registered UPCs with the Retailer's on-boarding system. you may include Model Numbers or other identifying information, as long the Product Name is not solely the product's model number, nor should it be overly generic in nature.
# Click Save; Pop up appears with Message: Product Message for product (ID) has been created successfully
# Click OK; pop up closes
# Confirm you get an email with a subject: Notification - Product (ID) - Product Name is Unclear
# Confirm the body of the email stars with: Your product assessment is on hold - (product ID)
# During our assessment and data creation the product name may generate delays and confusion to your retail clients. Retailers have indicated that Product Names that are not appropriate are to be suspended and the vendor is to correct the information. Product names are important when the packaging may be unavailable to the retail employee,
# next part of the body of the email starts in a new line and its: Please login to WERCSmart and update the product name. For guidance:
# Next part of the body of the email starts in a new line and its: the name should be specific enough so that an employee may find the product in their systems when no UPC or other identifier is available.
# then the next part of the body of the email starts in a new line and its: the Product Name in the WERCSmart system should closely match the product's registered UPCs with the Retailer's on-boarding system.
# the next part of the body of the email starts in a new line and its: you may include Model Numbers or other identifying information, as long the Product Name is not solely the product's model number, nor should it be overly generic in nature.
# the next part of the body of the email starts in a new line and its: If you have any questions, please contact WERCSmart Customer Support via email (WERCSmartCustomer@UL.com), chat, or call 877-642-6753.
