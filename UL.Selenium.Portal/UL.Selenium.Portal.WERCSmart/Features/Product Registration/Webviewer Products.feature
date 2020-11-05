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
@run_WebviewerProducts
@MyAccount
@Shared
@PaymentMethods

Feature: Webviewer Products



@ScenarioId:10454
Scenario: [146792] US Only, BCP - PLP = No, Authoring requested, Contains test Batteries (Lithium Ion) with all document types

# This test case is for loading WS products to be used in Webviewer testing.  As such it should not be included in any regression tests.



# Given I call shared step 144974 (Login to WS as supplier with feed to Web viewers)
Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
#In 57561a enter the name for final product run to be "Test Case 146792 - BCP, PLP No, Authoring requested, contains test batteries"
Then I call Shared Step 57561a (The Product - Enter Product Name: Carbon Monoxide Detectors Test Product and select Type of Product): Carbon monoxide detectors
Given I call Shared Step 57501 (Product Characteristics - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue - HP)
Given I call Shared Step 65511 (Additional Product Information - No Child, No Direct ship, No PL, Click Continue - Happy Path (use in a BCP))
Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Chalk
Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
# Given I call shared step 146794 (Product Includes a Battery > Add test Lithium Ion batteries for checking in Webviewers)
Given I call Shared Step 104083 Toxicity Characteristics Leaching Procedure TCLP - NO to ALL - NO COPPER LISTED
Given I call Shared Step 60096 (Lithium Battery Transportation)
# Given I call shared step 144968 (Retailers - Add Retailers for Web viewers)
# Given I call shared step 144969 (Universal Product Code (UPC) - Add UPC for Web viewer Retailers - Continue)
Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
# Given the Additional documents to Provide step is shown
Given I click continue
Given I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
| Appearance | Autoignition Temperature | Minimum Ignition Energy | Odor | Odor Threshold | Partition Coefficient | Personal Protection Equipment | Viscosity |
Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: test
Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
Given If purchase details are showing click confirm order
Given In the Thank You screen I click Home
Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
# here we have special processing for BCPs hence the new / weird shared steps
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Submitted Status for saved as: «savedAs»)
# Given I call shared step 145300 (SHA - Submitted Status - Process BCP product - Close warning message)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Submitted Status for saved as: «savedAs»)
# Confirm your product is still in the Submitted status
# So even though the product is in submitted status the import process rules will be running and the product will be shown in PD+ so we can process the publishing of the documents
Given I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: «savedAs»)
Given I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: «savedAs»)
Given I call Shared Step 75347 (WPS Studio - PD+ - set all data and publish using rule and Doc queue - CKLT, NGHS and SBCS) for product saved as: «savedAs»
Given I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: «savedAs»)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in «status» Status for saved as: «savedAs»)
# Confirm the product is still shown in SUBMITTED status - this is correct for this scenario - we will click process product data again now and the product will move to Assigned this time
Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: «savedAs»)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Assigned Status for saved as: «savedAs»)
# I confirm the product is shown in the Assigned status
# we now have to republish the product in WPS PD+ so that the product  moves out of assigned status
Given I call Shared Step 75347 (WPS Studio - PD+ - set all data and publish using rule and Doc queue - CKLT, NGHS and SBCS) for product saved as: «savedAs»
Given I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: «savedAs»)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Accepted Status for saved as: «savedAs»)
# Confirm the product is shown in Accepted status
Given I call Shared Step 49743 - SHA Manager - Select Product - Actions - Document Management for saved as: «savedAs»
# Confirm the Document list shows a type with the name set to published_by_wercs.rtf
# Click the "Merge Documents" button
# Confirm the Documents list is refreshed (may take a few seconds to do this)
# Confirm the Document list now shows a pdf type file with the name set to the WPS ID of your product For example 1617881.pdf
# Double click on the PDF Filename
# Confirm a new browser window opens with the PDF file shown
# Confirm the PDF file shows the SDS for your BCP product and the SDS for the Batteries you added to your BCP This will include Published NGHS for the BCP product AIS document for battery: Test Battery - TC 145403- Lithium Ion Battery with Uploaded AIS Uploaded SDS document for battery: Test Battery - For WVs TC 145485 - Lithium Ion Battery with Uploaded SDS Published NGHS for battery: Test Battery - TC 145354- Lithium Ion Battery with Authored SDS
# Close the new browser window
# Close the Document List pop up
Given I call Shared Step 51664 (SHA - Accepted Product - set Retailers to Completed for saved as: «savedAs») for
| Retailer |
