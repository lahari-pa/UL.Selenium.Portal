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
@UPC
@PaymentMethods

Feature: Webviewer Products

#Want to run feature using the config point that forces test end on first failure
#Last step of test will save successfull products and their unique IDs to TReVor (as Variable?)
#These Product names containing unique IDs give to Bev or add to devops ticket in some way?

@ScenarioId:10454
Scenario: [146792] US Only, BCP - PLP = No, Authoring requested, Contains test Batteries (Lithium Ion) with all document types

# This test case is for loading WS products to be used in Webviewer testing.  As such it should not be included in any regression tests.



Given I Login into WERCSmart Portal - WebViewers Account
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I generate a random UPC number and save as: UPC146792
#In 57561a enter the name for final product run to be "Test Case 146792 - BCP, PLP No, Authoring requested, contains test batteries"
Then I call Shared Step 57561a (The Product - Enter Product Name: Carbon Monoxide Detectors Test Product and select Type of Product): Carbon monoxide detectors
Then I save the product information as: TestCase146792
Given I call Shared Step 65511 (Product Information - No Child, No Direct ship, No PL, Click Continue - Happy Path (use in a BCP))
Given I call Shared Step 57501 (Physical and Chemical Properties - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue - HP)
Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Chalk
Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Given I call Shared Step 146794 (Product Includes a Battery > Add test Lithium Ion batteries for checking in Webviewers)
| Battery Type | Manufacturer | Number of batteries per package | How many batteries required to run |
| Lithium Ion  | <any>        | 6                               | 6                                  |
| Lithium Ion  | <any>        | 6                               | 6                                  |
| Lithium Ion  | <any>        | 6                               | 6                                  |

Given I call Shared Step 104083 Toxicity Characteristics Leaching Procedure TCLP - NO to ALL - NO COPPER LISTED
Given I call Shared Step 60096 (Lithium Battery Transportation)
Given I call Shared Step 144968b (Retailers - Add Retailers for Web viewers & RPS) for a non PL Product
Given I call Shared Step 144969 (Universal Product Code (UPC) - Add UPC for Web viewer Retailers - Continue) for UPC: saved as UPC146792, container type: Plastic Container and size: 50
Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
And I should see the Additional Documents to Provide Page
Given I click continue
And I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
		| Gloves                        | 120                      | 4                       | 10.0      | Black      | Odorless | No data available | 1                     |
And I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test
Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
Given If purchase details are showing click confirm order
Given In the Thank You screen I click Home
Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
# here we have special processing for BCPs hence the new / weird shared steps
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Submitted Status for saved as: TestCase146792)

# Given I call shared step 145300 (SHA - Submitted Status - Process BCP product - Close warning message)
Given I call Shared Step 145300 (SHA - Submitted Status - Process BCP product - Close warning message) for product saved as: TestCase146792

Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Submitted Status for saved as: TestCase146792)
# Confirm your product is still in the Submitted status
# So even though the product is in submitted status the import process rules will be running and the product will be shown in PD+ so we can process the publishing of the documents
Given I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase146792)
Given I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase146792)
Given I call Shared Step 75347 (WPS Studio - PD+ - set all data and publish using rule and Doc queue - CKLT, NGHS and SBCS) for product saved as: TestCase146792
Given I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase146792)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Submitted Status for saved as: TestCase146792)
# Confirm the product is still shown in SUBMITTED status - this is correct for this scenario - we will click process product data again now and the product will move to Assigned this time
Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase146792)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Assigned Status for saved as: TestCase146792)
# I confirm the product is shown in the Assigned status
# we now have to republish the product in WPS PD+ so that the product  moves out of assigned status
Given I call Shared Step 75347 (WPS Studio - PD+ - set all data and publish using rule and Doc queue - CKLT, NGHS and SBCS) for product saved as: TestCase146792
Given I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase146792)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Accepted Status for saved as: TestCase146792)
# Confirm the product is shown in Accepted status
Given I call Shared Step 49743 - SHA Manager - Select Product - Actions - Document Management for saved as: TestCase146792
# Confirm the Document list shows a type with the name set to published_by_wercs.rtf
# Click the "Merge Documents" button
# Confirm the Documents list is refreshed (may take a few seconds to do this)
# Confirm the Document list now shows a pdf type file with the name set to the WPS ID of your product For example 1617881.pdf
# Double click on the PDF Filename
# Confirm a new browser window opens with the PDF file shown
# Confirm the PDF file shows the SDS for your BCP product and the SDS for the Batteries you added to your BCP This will include Published NGHS for the BCP product AIS document for battery: Test Battery - TC 145403- Lithium Ion Battery with Uploaded AIS Uploaded SDS document for battery: Test Battery - For WVs TC 145485 - Lithium Ion Battery with Uploaded SDS Published NGHS for battery: Test Battery - TC 145354- Lithium Ion Battery with Authored SDS
# Close the new browser window
# Close the Document List pop up
Given I call Shared Step 51664 (SHA - Accepted Product - set Retailers to Completed for saved as: TestCase146792) for
| Retailer |
| <All>    |



@ScenarioId:10691
Scenario: [120814] WERCSmart product - Submitted to SHA, Status = Submitted

# This test case is for loading WS products to be used in RPS testing.  As such it should not be included in any regression tests.
Given I Login into WERCSmart Portal - WebViewers Account
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561b (The Product - Enter Product Name: TC 120814 - For RPS - Submitted status and select Type of Product): Chalk and add a Random Identifier
Given I generate a random UPC number and save as: UPC120814
Then I save the product information as: TestCase120814
Given I call Shared Step 26897 (Product Characteristics - Solid only available - continue)
Given I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Chalk
Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Given I call shared step 120812 (Retailer - Add retailers for RPS)
Given I call shared step 120813 (UPC - Add 2 UPCs - including one for CVS RCL and Add Home Depot OMSID for UPC: CVS, container type: Metal Container and size: 40)
Given I call shared step 51609 (CVS RCL - Yes I wish to continue with registration - Continue)
Given I call shared step 52131 (CVS RCL Information - add Other where available and all other data)
Given I call Shared Step 78080 (Regulatory Documents to Provide - Upload OSHA SDS)
Given in the Additional Documents to Provide page I click Continue
Given in the Optional Reports and Documents Available for Purchase page I click Continue
Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test
Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
Given If purchase details are showing click confirm order
Given I navigate to the home page
Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase120814)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase120814 and its status is: Submitted


@Missing_Steps
@Rename_Product
@ScenarioId:10637
Scenario: [144967] US Only, PLP = No, GenDoc = 1, Doc Accepted = Yes
#Need access to WebViewer Feed Account + Add to TReVor?


#Login to WS as supplier with feed to Web viewers
Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I generate a random UPC number and save as: UPC144967
#In 57561b enter the name for final product run to be "Test Case 144697 - US Only, PLP No, Gendoc 1, Doc Accepted Yes"
Then I call Shared Step 57561b (The Product - Enter Product Name: Chalk Test Product 144967 and select Type of Product): Chalk and add a Random Identifier
Then I save the product information as: TestCase144967
Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Given I call Shared Step 144968b (Retailers - Add Retailers for Web viewers & RPS) for a non PL Product
Given I call Shared Step 144969 (Universal Product Code (UPC) - Add UPC for Web viewer Retailers - Continue) for UPC: saved as UPC144967, container type: Plastic Container and size: 50
Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
And I should see the Additional Documents to Provide Page
Given I click continue
And I should see the Optional Reports and Documents Available for Purchase Page
And I click continue
And I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
		| Gloves                        | 120                      | 4                       | 10.0      | Black      | Odorless | No data available | 1                     |
And I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test
Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
Given If purchase details are showing click confirm order

#~~~~~~~~SHA~~~~~~~#

Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Submitted Status for saved as: TestCase144967)
Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase144967)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase144967)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase144967 and its status is: Assigned
Given I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase144967)
Given I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase144967)
Given I call Shared Step 75347 (WPS Studio - PD+ - set all data and publish using rule and Doc queue - CKLT, NGHS and SBCS) for product saved as: TestCase144967
Given I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase144967)
Given I call Shared Step 59066 (Go to SHA Manager)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase144967)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase144967 and its status is: Accepted

#~~~~~~~~WERCSmart~~~~~~~#

#Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
#Then the WERCSmart homepage should load
#Given I call Shared Step 144970 (Go To Bulk Actions - Accept Documents)
##Document Acceptance - Approve NGHS document -> Shared Step 144971

#~~~~~~~~SHA~~~~~~~#

#Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
#Given I call Shared Step 49743 - SHA Manager - Select Product - Actions - Document Management for saved as: TestCase144967
##SHA - Document Management - confirm Accepted SDS -> Shared Step 144972
#Given I call Shared Step 51664 (SHA - Accepted Product - set Retailers to Completed for saved as: TestCase144967) for
#| Retailer |
#| <All>    |
#Then I Update the TestUser: Webviewer Products to include the name of the product saved as: TestCase144967

@Missing_Steps
@Rename_Product
Scenario: [144975] US Only, PLP = No, GenDoc = 1, Doc Accepted = No (User rejects published SDS and uploads his own)
#Login to WS as supplier with feed to Web viewers
Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I generate a random UPC number and save as: UPC144975
#In 57561b enter the name for final product run to be "Test Case 144975 - US Only, PLP No, GenDoc 1, DocAccept - User uploads own SDS"
Then I call Shared Step 57561b (The Product - Enter Product Name: Chalk Test Product 144975 and select Type of Product): Chalk and add a Random Identifier
Then I save the product information as: TestCase144975
Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Given I call Shared Step 144968b (Retailers - Add Retailers for Web viewers & RPS) for a non PL Product
Given I call Shared Step 144969 (Universal Product Code (UPC) - Add UPC for Web viewer Retailers - Continue) for UPC: saved as UPC144975, container type: Plastic Container and size: 50
Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
And I should see the Additional Documents to Provide Page
Given I click continue
And I should see the Optional Reports and Documents Available for Purchase Page
And I click continue
And I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
		| Gloves                        | 120                      | 4                       | 10.0      | Black      | Odorless | No data available | 1                     |
And I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test
Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
Given If purchase details are showing click confirm order

#~~~~~~~~SHA~~~~~~~#

Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Submitted Status for saved as: TestCase144975)
Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase144975)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase144975)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase144975 and its status is: Assigned
Given I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase144975)
Given I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase144975)
Given I call Shared Step 75347 (WPS Studio - PD+ - set all data and publish using rule and Doc queue - CKLT, NGHS and SBCS) for product saved as: TestCase144975
Given I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase144975)
Given I call Shared Step 59066 (Go to SHA Manager)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase144975)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase144975 and its status is: Accepted

#~~~~~~~~WERCSmart~~~~~~~#

Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
Then the WERCSmart homepage should load
Given I call Shared Step 144970 (Go To Bulk Actions - Accept Documents)
#Document Acceptance - reject published and upload your own SDS -> Shared Step 144976

#~~~~~~~~SHA~~~~~~~#

Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
Given I call Shared Step 49743 - SHA Manager - Select Product - Actions - Document Management for saved as: TestCase144975
#SHA - Document Management - confirm rejected SDS - users own uploaded SDS is shown -> Shared Step 144978
Given I call Shared Step 51664 (SHA - Accepted Product - set Retailers to Completed for saved as: TestCase144975) for
| Retailer |
| <All>    |
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase144975)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase144975 and its status is: Completed
Then I Update the TestUser: Webviewer Products to include the name of the product saved as: TestCase144975









@Rename_Product
Scenario: [144979] US Only, PLP = No, GenDoc = 0, User uploads own SDS on submission

#Login to WS as supplier with feed to Web viewers
Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I generate a random UPC number and save as: UPC144979
#In 57561b enter the name for final product run to be "Test Case 144979 - US only, PLP No, GenDoc 0, User uploads own SDS"
Then I call Shared Step 57561b (The Product - Enter Product Name: Chalk Test Product 144979 and select Type of Product): Chalk and add a Random Identifier
Then I save the product information as: TestCase144979
Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Given I call Shared Step 144968b (Retailers - Add Retailers for Web viewers & RPS) for a non PL Product
Given I call Shared Step 144969 (Universal Product Code (UPC) - Add UPC for Web viewer Retailers - Continue) for UPC: saved as UPC144979, container type: Plastic Container and size: 50
And  I call Shared Step 78080 (Regulatory Documents to Provide - Upload OSHA SDS)
And I should see the Additional Documents to Provide Page
Given I click continue
And I should see the Optional Reports and Documents Available for Purchase Page
And I click continue
And I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test
Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
Given If purchase details are showing click confirm order

#~~~~~~~~SHA~~~~~~~#

Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Submitted Status for saved as: TestCase144979)
Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase144979)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase144979)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase144979 and its status is: Assigned
Given I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase144979)
Given I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase144979)
And I call Shared Step 79500 (WPS Studio - PD+ - set all data and publish using rule and doc queue - CKLT and SBCS only) for product saved as: TestCase144979	
Given I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase144979)
Given I call Shared Step 59066 (Go to SHA Manager)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase144979)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase144979 and its status is: Accepted
Given I call Shared Step 51664 (SHA - Accepted Product - set Retailers to Completed for saved as: TestCase144979) for
| Retailer |
| <All>    |
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase144979)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase144979 and its status is: Completed
Then I Update the TestUser: Webviewer Products to include the name of the product saved as: TestCase144979



@Missing_Steps
@Rename_Product
Scenario: [144981] US Only, PLP = Yes, PLP Upload allowed = Yes, GenDoc = 1, Alias published = Yes
#Login to WS as supplier with feed to Web viewers

Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I generate a random UPC number and save as: UPC144981
#In 57561b enter the name for final product run to be "For WVs TC 144981 - US Only, PLP Yes, PLP Upload allowed Yes, GenDoc 1, Alias published Yes"
Then I call Shared Step 57561b (The Product - Enter Product Name: Chalk Test Product 144981 and select Type of Product): Chalk and add a Random Identifier
Then I save the product information as: TestCase144981
Given I call Shared Step 63860 (Product Information - US, No(child), No(OSHA), No(DSV), Yes(PLP), No(GNFR))
Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
#144982 -> Retailers - Add Retailers for Web viewers & RPS - for PLP
Given I call Shared Step 144969 (Universal Product Code (UPC) - Add UPC for Web viewer Retailers - Continue) for UPC: saved as UPC144981, container type: Plastic Container and size: 50
Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
And I should see the Additional Documents to Provide Page
Given I click continue
And I should see the Optional Reports and Documents Available for Purchase Page
And I click continue
And I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
		| Gloves                        | 120                      | 4                       | 10.0      | Black      | Odorless | No data available | 1                     |
And I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test
Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
Given If purchase details are showing click confirm order

#~~~~~~~~SHA~~~~~~~#

Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Submitted Status for saved as: TestCase144981)
Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase144981)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase144981)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase144981 and its status is: Assigned
Given I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase144981)
Given I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase144981)
Given I call Shared Step 85983 - WPS Studio - PD\+ PLP with NGHS only - set all data and publish using rule and DOC queue for product saved as: TestCase144981
Given I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase144981)
Given I call Shared Step 59066 (Go to SHA Manager)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase144981)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase144981 and its status is: Accepted
Given I call Shared Step 51664 (SHA - Accepted Product - set Retailers to Completed for saved as: TestCase144981) for
| Retailer |
| <All>    |
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase144981)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase144981 and its status is: Completed
Then I Update the TestUser: Webviewer Products to include the name of the product saved as: TestCase144981



@Missing_Steps
@Rename_Product
Scenario: [144984] US Only, PLP = Yes, PLP Upload allowed = Yes, GenDoc = 1, Alias published = No
#Login to WS as supplier with feed to Web viewers
Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I generate a random UPC number and save as: UPC144984
#In 57561b enter the name for final product run to be "For WVs TC 144984 - US Only, PLP Yes, PLP Upload allowed Yes, GenDoc 1, Alias published No"
Then I call Shared Step 57561b (The Product - Enter Product Name: Chalk Test Product 144981 and select Type of Product): Chalk and add a Random Identifier
Then I save the product information as: TestCase144984
Given I call Shared Step 63860 (Product Information - US, No(child), No(OSHA), No(DSV), Yes(PLP), No(GNFR))
Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
#144982 -> Retailers - Add Retailers for Web viewers & RPS - for PLP
Given I call Shared Step 144969 (Universal Product Code (UPC) - Add UPC for Web viewer Retailers - Continue) for UPC: saved as UPC144984, container type: Plastic Container and size: 50
Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
And I should see the Additional Documents to Provide Page
Given I click continue
And I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
		| Gloves                        | 120                      | 4                       | 10.0      | Black      | Odorless | No data available | 1                     |
And I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test
Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
Given If purchase details are showing click confirm order
Given In the Thank You screen I click Home
Given I call Shared Step 65080 (Login to Studio and Open SHA manager)

#~~~~~~~~SHA~~~~~~~#

Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Submitted Status for saved as: TestCase144984)
Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase144984)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase144984)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase144984 and its status is: Assigned
Given I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase144984)
Given I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase144984)
#144991 -> WPS Studio - PD+ - PLP - Publish CKLT, NGHS and SBCS for main product only - Not the aliases
Given I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase144984)
Given I call Shared Step 59066 (Go to SHA Manager)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase144984)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase144984 and its status is: Accepted
Given I call Shared Step 51664 (SHA - Accepted Product - set Retailers to Completed for saved as: TestCase144984) for
| Retailer |
| <All>    |
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase144984)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase144984 and its status is: Completed
Then I Update the TestUser: Webviewer Products to include the name of the product saved as: TestCase144984



@Missing_Steps
@Rename_Product
Scenario: [144992] US Only, PLP = Yes, PLP Upload allowed = Yes, GenDoc = 0, Processed to Complete
#Login to WS as supplier with feed to Web viewers
Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I generate a random UPC number and save as: UPC144992
#In 57561b enter the name for final product run to be "For WVs TC 144992 - US Only, PLP Yes, PLP Upload allowed Yes, GenDoc 0, User Uploads own SDS on submission"
Then I call Shared Step 57561b (The Product - Enter Product Name: Chalk Test Product 144992 and select Type of Product): Chalk and add a Random Identifier
Then I save the product information as: TestCase144992
Given I call Shared Step 63860 (Product Information - US, No(child), No(OSHA), No(DSV), Yes(PLP), No(GNFR))
Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
#147920 -> Retailers - Add Retailers for Web viewers - for PLP - Not WM or Sears (for upload doc flows)
Given I call Shared Step 144969 (Universal Product Code (UPC) - Add UPC for Web viewer Retailers - Continue) for UPC: saved as UPC144992, container type: Plastic Container and size: 50
And  I call Shared Step 78080 (Regulatory Documents to Provide - Upload OSHA SDS)
And I should see the Additional Documents to Provide Page
Given I click continue
And I should see the Optional Reports and Documents Available for Purchase Page
And I click continue
And I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test
Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
Given If purchase details are showing click confirm order

#~~~~~~~~SHA~~~~~~~#

Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Submitted Status for saved as: TestCase144992)
Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase144992)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase144992)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase144992 and its status is: Assigned
Given I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase144992)
Given I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase144992)
#144993 -> WPS Studio - PD+ - Set all data and publish using rule and doc queue - CKLT and SBCS for PLP
Given I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase144992)
Given I call Shared Step 59066 (Go to SHA Manager)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase144992)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase144992 and its status is: Accepted
Given I call Shared Step 51664 (SHA - Accepted Product - set Retailers to Completed for saved as: TestCase144992) for
| Retailer |
| <All>    |
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase144992)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase144992 and its status is: Completed
Then I Update the TestUser: Webviewer Products to include the name of the product saved as: TestCase144992

Scenario: [145074] US Only, Label Only Product - Label Uploaded - process to Complete
#Login to WS as supplier with feed to Web viewers
Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I generate a random UPC number and save as: UPC145074
#In 57561b enter the name for final product run to be "For WVs TC 145074 - Us Only - Label product - Label uploaded "
Then I call Shared Step 57561b (The Product - Enter Product Name: Nutritional Supplement - Liquid Test Product 145074 and select Type of Product): Nutritional Supplement - Liquid and add a Random Identifier
Then I save the product information as: TestCase145074
Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
And I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
Given I call Shared Step 144968b (Retailers - Add Retailers for Web viewers & RPS) for a non PL Product
Given I call Shared Step 144969 (Universal Product Code (UPC) - Add UPC for Web viewer Retailers - Continue) for UPC: saved as UPC145074, container type: Plastic Container and size: 50
And I call Shared Step 60567 (Upload Product Label only) for section: Upload Full Product Label (required)
And I should see the Optional Reports and Documents Available for Purchase Page
And I click continue
Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
Given If purchase details are showing click confirm order

#~~~~~~~~SHA~~~~~~~#

Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Submitted Status for saved as: TestCase145074)
Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase145074)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase145074)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase145074 and its status is: Assigned
Given I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase145074)
Given I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase145074)
And I call Shared Step 79500 (WPS Studio - PD+ - set all data and publish using rule and doc queue - CKLT and SBCS only) for product saved as: TestCase145074	
Given I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase145074)
Given I call Shared Step 59066 (Go to SHA Manager)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase145074)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase145074 and its status is: Accepted
Given I call Shared Step 51664 (SHA - Accepted Product - set Retailers to Completed for saved as: TestCase145074) for
| Retailer |
| <All>    |
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase145074)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase145074 and its status is: Completed
Then I Update the TestUser: Webviewer Products to include the name of the product saved as: TestCase145074



Scenario: [145971] Canada Only, Non Authoring Product - No Label Uploaded, PLP = Yes, GENDOC = 0
# This test case is for loading WS products to be used in Webviewer testing.  As such it should not be included in any regression tests.
Given I login into the WERCSmart Portal - WebViewers Account
Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
Given I call Shared Step 57561b (The Product - Enter Product Name: For WVs TC 145971 - Canada Only, Non Authoring Product - No Label Uploaded, PLP Yes, GENDOC 0 and select Type of Product): Chalk and add a Random Identifier
Given I generate a random UPC number and save as: UPC145971
Given I save the product information as: TestCase145971
Given I call shared step 145969 (Additional Product Information > SOLD (Canada), PLP (YES), Continue)
Given I call Shared Step 57911 (Regulatory Information 1 - CEPA only shown - Continue - Happy Path)
Given I call Shared Step 104083 Toxicity Characteristics Leaching Procedure TCLP - NO to ALL - NO COPPER LISTED
Given I call Shared Step 58189 (Answer Electronic Equipment questions - With Cathode Ray - No to all)
Given I call shared step 86009 (Retailer - PLP, Canada Only, Select Canadian Tire add PLP data - Continue)
Given I call Shared Step 76738 (Universal Product Code (UPC) - Canada - Package Type) for UPC: saved as UPCUPC145971, container type: Metal Container, size: 4.0, package type: <First> and Item Number: 111-1111 then click continue
Given I click continue
Given I click continue
Given I click continue
Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
Given If purchase details are showing click confirm order
Given In the Thank You screen I click Home
Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Submitted Status for saved as: TestCase145971)
Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase145971)
Given I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase145971)
# Note: In Staging and Production - Electronic products are automatically published by the ImportProcessRules so if you are running in either of these sites you can skip to step 29
Given I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase145971)
Given I call shared step 144993 (WPS Studio - PD+ - Set all data and publish using rule and doc queue - CKLT and SBCS for PLP)
Given I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase145971)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Accepted Status for saved as: TestCase145971)
Given I call Shared Step 51664 (SHA - Accepted Product - set Retailers to Completed for saved as: TestCase145971) for
| Retailer		|
| Canadian Tire |


Scenario: [120815] WERCSmart product - Submitted to SHA, Status = Assigned

# This test case is for loading WS products to be used in RPS testing.  As such it should not be included in any regression tests.
Given I Login into WERCSmart Portal - WebViewers Account
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Then I call Shared Step 57561b (The Product - Enter Product Name: TC 120815 - for RPS - Assigned Status and select Type of Product): Chalk and add a Random Identifier
Given I generate a random UPC number and save as: UPC120815
Then I save the product information as: TestCase120815
Given I call Shared Step 26897 (Product Characteristics - Solid only available - continue)
Given I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Chalk
Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Given I call shared step 120812 (Retailer - Add retailers for RPS)
Given I call shared step 120813 (UPC - Add 2 UPCs - including one for CVS RCL and Add Home Depot OMSID for UPC: CVS, container type: Metal Container and size: 40)
Given I call shared step 51609 (CVS RCL - Yes I wish to continue with registration - Continue)
Given I call shared step 52131 (CVS RCL Information - add Other where available and all other data)
Given I call Shared Step 78080 (Regulatory Documents to Provide - Upload OSHA SDS)
Given in the Additional Documents to Provide page I click Continue
Given in the Optional Reports and Documents Available for Purchase page I click Continue
Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test
Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
Given If purchase details are showing click confirm order
Given I navigate to the home page
Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Submitted Status for saved as: TestCase120815)
Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase120815)
Given I call Shared Step 59066 (Go to SHA Manager)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Assigned Status for saved as: TestCase120815)



@ScenarioId:10758
Scenario: [145842] Canada Only, Non Authoring Product - No Label Uploaded, PLP = No, GENDOC = 0

# This test case is for loading WS products to be used in Webviewer testing.  As such it should not be included in any regression tests.
Given I login into the WERCSmart Portal - WebViewers Account
Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
# In the shared step below use "Halogen  lights"  as your product type  If running this test case for the first time in an environment after a database refresh and the product name is not present in the database please use the product name: For WVs 145842 - Canada Only, Non Authoring Product - No Label Uploaded, PLP No, GENDOC 0
Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Halogen lights
Given I generate a random UPC number and save as: UPC145842
Given I save the product information as: TestCase145842
Given I call shared step 145844 (Additional Product Information > SOLD (Canada), PLP (No), Continue)
Given I call Shared Step 57911 (Regulatory Information 1 - CEPA only shown - Continue - Happy Path)
Given I call Shared Step 104083 Toxicity Characteristics Leaching Procedure TCLP - NO to ALL - NO COPPER LISTED
Given I call Shared Step 58189 (Answer Electronic Equipment questions - With Cathode Ray - No to all)
Given I call shared step 72414 (Retailer - Canada Only > Select Canadian Tire > Continue - Happy Path)
Given I call Shared Step 76738 (Universal Product Code (UPC) - Canada - Package Type) for UPC: saved as UPC145842, container type: Metal Container, size: 4.0, package type: <First> and Item Number: 111-1111 then click continue
Given I click continue
Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test
Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
Given If purchase details are showing click confirm order
Given In the Thank You screen I click Home
Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Submitted Status for saved as: TestCase145842)
Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase145842)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Assigned Status for saved as: TestCase145842)
Given I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase145842)
# Note: In Staging and Production - Electronic products are automatically published by the ImportProcessRules so if you are running in either of these sites you can skip to step 31
Given I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase145842)
Given I call Shared Step 79500 (WPS Studio - PD+ - set all data and publish using rule and doc queue - CKLT and SBCS only) for product saved as: TestCase145842
Given I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase145842)
# IN SHA manager
Given I call Shared Step 59066 (Go to SHA Manager)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Accepted Status for saved as: TestCase145842)
Given I call Shared Step 51664 (SHA - Accepted Product - set Retailers to Completed for saved as: TestCase145842) for
| Retailer      |
| Canadian Tire |



@ScenarioId:10707
Scenario: [145793] Canada Only, PLP = Yes, PLP Upload allowed = Yes, GenDocCA = 0

# This test case is for loading WS products to be used in Webviewer testing.  As such it should not be included in any regression tests.
Given I login into the WERCSmart Portal - WebViewers Account
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
# In the shared step below select Chalk as your product type. If running this test case for the first time in an environment after a database refresh and the product name is not present in the database please use the product name:  For WVs Test case 145793 - Canada Only, PLP Yes, PLP Upload allowed Yes, Gen
Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
Given I generate a random UPC number and save as: UPC145793
Given I save the product information as: TestCase145793
Given I call Shared Step 26897 (Product Characteristics - Solid only available - continue)
Given I call Shared Step 85730 - Additional Product Information - Canada Only - Child (NO), GHS (NO), DSV (NO), PLP(YES), GNFR (NO), Continue
Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Chalk
Given I call Shared Step 57911 (Regulatory Information 1 - CEPA only shown - Continue - Happy Path)
Given I call shared step 86009 (Retailer - PLP, Canada Only, Select Canadian Tire add PLP data - Continue)
Given I call Shared Step 76738 (Universal Product Code (UPC) - Canada - Package Type) for UPC: saved as UPC145793, container type: Metal Container, size: 4.0, package type: <First> and Item Number: 111-1111 then click continue
Given I call Shared Step 100974 (Regulatory Documents to Provide - Canada only - Upload documents > Continue)
Given I click continue
Given I click continue
Given I click continue
Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test
Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
Given If purchase details are showing click confirm order
Given In the Thank You screen I click Home
Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Submitted Status for saved as: TestCase145793)
Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase145793)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Assigned Status for saved as: TestCase145793)
Given I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase145793)
Given I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase145793)
Given I call shared step 144993 (WPS Studio - PD+ - Set all data and publish using rule and doc queue - CKLT and SBCS for PLP for product saved as: TestCase145793)
Given I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase145793)
# IN SHA manager
Given I call Shared Step 59066 (Go to SHA Manager)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Accepted Status for saved as: TestCase145793)
Given I call Shared Step 51664 (SHA - Accepted Product - set Retailers to Completed for saved as: TestCase145793) for
| Retailer      |
| Canadian Tire |



@ScenarioId:10788
Scenario: [120811] WERCSmart product - Submitted to SHA, rejected, Status = New

# This test case is for loading WS products to be used in RPS testing.  As such it should not be included in any regression tests.
Given I Login into WERCSmart Portal - WebViewers Account
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Then I call Shared Step 57561b (The Product - Enter Product Name: TC 120811 - For RPS - Submitted to SHA and rejected, Status is New and select Type of Product): Chalk and add a Random Identifier
Given I generate a random UPC number and save as: UPC120811
Then I save the product information as: TestCase120811
Given I call Shared Step 26897 (Product Characteristics - Solid only available - continue)
Given I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Chalk
Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Given I call shared step 120812 (Retailer - Add retailers for RPS)
Given I call shared step 120813 (UPC - Add 2 UPCs - including one for CVS RCL and Add Home Depot OMSID for UPC: CVS, container type: Cardboard and size: 10.0)
Given I call shared step 51609 (CVS RCL - Yes I wish to continue with registration - Continue)
Given I call shared step 52131 (CVS RCL Information - add Other where available and all other data)
Given I call Shared Step 78080 (Regulatory Documents to Provide - Upload OSHA SDS)
Given in the Additional Documents to Provide page I click Continue
Given in the Optional Reports and Documents Available for Purchase page I click Continue
Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test
Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
Given If purchase details are showing click confirm order
Given In the Thank You screen I click Home
Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Submitted Status for saved as: TestCase120811)
Given In SHA Manager Page I select status: Submitted
Given I call Shared Step 83242 (SHA - Submitted or Assigned product - Reject Submission - any subject - Save for the product saved as: TestCase120811)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in New Status for saved as: TestCase120811)


Scenario: [145970] Canada Only, Non Authoring Product - No Label Uploaded, PLP = Yes, GENDOC = 0, User Uploads SDS on Additional Documents to Provide

# This test case is for loading WS products to be used in Webviewer testing.  As such it should not be included in any regression tests.
Given I login into the WERCSmart Portal - WebViewers Account
Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
# In the shared step below use "Halogen  lights"  as your product type. If running this test case for the first time in an environment after a database refresh and the product name is not present in the database please use the product name: For WVs TC 145970 - Canada Only, Non Authoring Product - No Label Uploaded, PLP Yes, GENDOC 0, User Uploads SDS on Additional Documents to Provide
Then I call Shared Step 57561b (The Product - Enter Product Name: For WVs TC 145970 - Canada Only, Non Authoring Product - No Label Uploaded, PLP Yes, GENDOC 0, User Uploads SDS on Additional Documents to Provide and select Type of Product): Halogen Lights and add a Random Identifier
Given I generate a random UPC number and save as: UPC145970
Then I save the product information as: TestCase145970
Given I call shared step 145969 (Additional Product Information > SOLD (Canada), PLP (YES), Continue)
Given I call Shared Step 57911 (Regulatory Information 1 - CEPA only shown - Continue - Happy Path)
Given I call Shared Step 104083 Toxicity Characteristics Leaching Procedure TCLP - NO to ALL - NO COPPER LISTED
Given I call Shared Step 58189 (Answer Electronic Equipment questions - With Cathode Ray - No to all)
Given I call shared step 86009 (Retailer - PLP, Canada Only, Select Canadian Tire add PLP data - Continue)
Then I call Shared Step 76738 (Universal Product Code (UPC) - Canada - Package Type) for UPC: saved as UPC145970, container type: Paper bag, size: 2, package type: <First> and Item Number: 111-1111 then click continue
Given I call Shared Step 60715 (Additional Documents to Provide - OSHA SDS - only) : UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf
Given I click continue
Given I click continue
Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
Given If purchase details are showing click confirm order
Given In the Thank You screen I click Home
Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Submitted Status for saved as: TestCase145970)
Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase145970)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Assigned Status for saved as: TestCase145970)
Given I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase145970)
# Note: In Staging and Production - Electronic products are automatically published by the ImportProcessRules so if you are running in either of these sites you can skip to step 29
Given I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase145970)
Given I call Shared Step 79500 (WPS Studio - PD+ - set all data and publish using rule and doc queue - CKLT and SBCS only) for product saved as: TestCase145970
Given I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase145970)
# IN SHA manager
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Accepted Status for saved as: TestCase145970)
Given I call Shared Step 51664 (SHA - Accepted Product - set Retailers to Completed for saved as: TestCase145970) for
| Retailer      |
| Canadian Tire |


@ScenarioId:10706
Scenario: [145852] Canada Only, Non Authoring Product - No Label Uploaded, PLP = No, GENDOC = 0, User Uploads SDS on Additional Documents to Provide

# This test case is for loading WS products to be used in Webviewer testing.  As such it should not be included in any regression tests.
Given I login into the WERCSmart Portal - WebViewers Account
Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
# In the shared step below use "Halogen  lights"  as your product type. If running this test case for the first time in an environment after a database refresh and the product name is not present in the database please use the product name: For WVs TC 145852 - Canada Only, Non Authoring Product - No Label Uploaded, PLP No, GENDOC 0, User Uploads SDS on Additional Documents to Provide
Given I call Shared Step 57561b (The Product - Enter Product Name: Halogen lights Test Product 145852 and select Type of Product): Halogen lights and add a Random Identifier
Given I generate a random UPC number and save as: UPC145852
Given I save the product information as: TestCase145852
Given I call shared step 145844 (Additional Product Information > SOLD (Canada), PLP (No), Continue)
Given I call Shared Step 57911 (Regulatory Information 1 - CEPA only shown - Continue - Happy Path)
Given I call Shared Step 104083 Toxicity Characteristics Leaching Procedure TCLP - NO to ALL - NO COPPER LISTED
Given I call Shared Step 58189 (Answer Electronic Equipment questions - With Cathode Ray - No to all)
Given I call shared step 72414 (Retailer - Canada Only > Select Canadian Tire > Continue - Happy Path)
Given I call Shared Step 76738 (Universal Product Code (UPC) - Canada - Package Type) for UPC: saved as UPC145852, container type: Metal Container, size: 4.0, package type: <First> and Item Number: 111-1111 then click continue
Given I call Shared Step 60715 (Additional Documents to Provide - OSHA SDS - only) : UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf
Given I click continue
Given I click continue
Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
Given If purchase details are showing click confirm order
Given In the Thank You screen I click Home
Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Submitted Status for saved as: TestCase145852)
Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase145852)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Assigned Status for saved as: TestCase145852)
Given I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase145852)
# Note: In Staging and Production - Electronic products are automatically published by the ImportProcessRules so if you are running in either of these sites you can skip to step 29
#Given I call Shared Step 65969 (Go to Power Designer Plus - Select your product & CKLT - Continue)
#Given I call Shared Step 79500 (WPS Studio - PD+ - set all data and publish using rule and doc queue - CKLT and SBCS only) for product saved as: TestCase145852
#Given I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase145852)
# IN SHA manager
Given I call Shared Step 59066 (Go to SHA Manager)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Accepted Status for saved as: TestCase145852)
Given I call Shared Step 51664 (SHA - Accepted Product - set Retailers to Completed for saved as: TestCase145852) for
| Retailer      |
| Canadian Tire |



@ScenarioId:10714
Scenario: [145743] Canada Only, PLP = Yes, PLP Upload allowed = Yes, GenDocCA = 1, Alias published = Yes

# This test case is for loading WS products to be used in Webviewer testing.  As such it should not be included in any regression tests.
Given I login into the WERCSmart Portal - WebViewers Account
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
# In the shared step below select Chalk as your product type. If running this test case for the first time in an environment after a database refresh and the product name is not present in the database please use the product name: For WVs Test case 145743 - Canada Only, PLP Yes, PLP Upload allowed Yes, GenDocCA 1, Alias published Yes
Given I call Shared Step 57561b (The Product - Enter Product Name: TC 145743 - For RPS - Submitted status and select Type of Product): Chalk and add a Random Identifier

Given I generate a random UPC number and save as: UPC145743
Given I save the product information as: TestCase145743
Given I call Shared Step 26897 (Product Characteristics - Solid only available - continue)
Given I call Shared Step 85730 - Additional Product Information - Canada Only - Child (NO), GHS (NO), DSV (NO), PLP(YES), GNFR (NO), Continue
Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Chalk
Given I call Shared Step 57911 (Regulatory Information 1 - CEPA only shown - Continue - Happy Path)
Given I call shared step 86009 (Retailer - PLP, Canada Only, Select Canadian Tire add PLP data - Continue)
Given I call Shared Step 76738 (Universal Product Code (UPC) - Canada - Package Type) for UPC: saved as UPC145743, container type: Metal Container, size: 4.0, package type: <First> and Item Number: 111-1111 then click continue
Given I call Shared Step 78884 - Regulatory Documents to Provide - Canada only - request authoring, upload label - Continue
Given I click continue
Given I click continue
Given I call Shared Step 64097 - Additional Documents -> Contact Information - Add any Name, address, phone and emergency phone - Happy Path
Given I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test
Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
Given If purchase details are showing click confirm order
Given In the Thank You screen I click Home
Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Submitted Status for saved as: TestCase145743)
Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase145743)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Assigned Status for saved as: TestCase145743)
Given I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase145743)
Given I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase145743)
Given I call Shared Step 78888 - WPS Studio - PD+ - set all data and publish using rule and doc queue - CKLT, HGHS (EN and CF) and SBCS for product saved as TestCase145743
Given I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase145743)
#Given I call Shared Step 49742 - WPS - Check In Product saved as: TestCase145743
#Given I call shared step 149691 (WPS Studio - PD+ - PLP product for Canada - publish alias HGHS documents for product saved as: TestCase145743)
#Given I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase145743)
# Because we are working with a PLP and we need the alias products to have published HGHS documents we need the following steps to so thi.
# In Power Designer.
# IN SHA manager
Given I call Shared Step 59066 (Go to SHA Manager)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Accepted Status for saved as: TestCase145743)
Given I call Shared Step 51664 (SHA - Accepted Product - set Retailers to Completed for saved as: TestCase145743) for
| Retailer      |
| Canadian Tire |



@ScenarioId:10705
Scenario: [145783] Canada Only, PLP = Yes, PLP Upload allowed = Yes, GenDocCA = 1, Alias published = No

# This test case is for loading WS products to be used in Webviewer testing.  As such it should not be included in any regression tests.
Given I login into the WERCSmart Portal - WebViewers Account
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
# In the shared step below select Chalk as your product type. If running this test case for the first time in an environment after a database refresh and the product name is not present in the database please use the product name: For WVs TC 145783 - Canada Only, PLP Yes, PLP Upload allowed Yes, GenDocCA 1, Alias published No
Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
Given I generate a random UPC number and save as: UPC145783
Given I save the product information as: TestCase145783
Given I call Shared Step 26897 (Product Characteristics - Solid only available - continue)
Given I call Shared Step 85730 - Additional Product Information - Canada Only - Child (NO), GHS (NO), DSV (NO), PLP(YES), GNFR (NO), Continue
Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Water
Given I call Shared Step 57911 (Regulatory Information 1 - CEPA only shown - Continue - Happy Path)
Given I call shared step 86009 (Retailer - PLP, Canada Only, Select Canadian Tire add PLP data - Continue)
Given I call Shared Step 76738 (Universal Product Code (UPC) - Canada - Package Type) for UPC: saved as UPC145783, container type: Metal Container, size: 4.0, package type: <First> and Item Number: 111-1111 then click continue
Given I call Shared Step 78884 - Regulatory Documents to Provide - Canada only - request authoring, upload label - Continue
Given I click continue
Given I click continue
Given I call Shared Step 64097 - Additional Documents -> Contact Information - Add any Name, address, phone and emergency phone - Happy Path
Given I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test
Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
Given If purchase details are showing click confirm order
Given In the Thank You screen I click Home
Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Submitted Status for saved as: TestCase145783)
Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase145783)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Assigned Status for saved as: TestCase145783)
Given I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase145783)
Given I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase145783)
Given I call shared step 145791 (WPS Studio - PD+ - PLP - Publish CKLT, HGHS and SBCS for main product only - not the aliases for product saved as: TestCase145783)
Given I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase145783)
# IN SHA manager
Given I call Shared Step 59066 (Go to SHA Manager)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Accepted Status for saved as: TestCase145783)
Given I call Shared Step 51664 (SHA - Accepted Product - set Retailers to Completed for saved as: TestCase145783) for
| Retailer      |
| Canadian Tire |





Scenario: [120816] WERCSmart product - Submitted to SHA, Status = Accepted

Given I Login into WERCSmart Portal - WebViewers Account
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Then I call Shared Step 57561b (The Product - Enter Product Name: TC 120816 - for RPS - Status Accepted and select Type of Product): Chalk and add a Random Identifier
Given I generate a random UPC number and save as: UPC120816
Then I save the product information as: TestCase120816
Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Chalk
Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Given I call shared step 120812 (Retailer - Add retailers for RPS)
Given I call shared step 120813 (UPC - Add 2 UPCs - including one for CVS RCL and Add Home Depot OMSID for UPC: CVS, container type: Metal Container and size: 40)
Given I call shared step 51609 (CVS RCL - Yes I wish to continue with registration - Continue)
Given I call shared step 52131 (CVS RCL Information - add Other where available and all other data)
Given I call Shared Step 78080 (Regulatory Documents to Provide - Upload OSHA SDS)
Given in the Additional Documents to Provide page I click Continue
Given in the Optional Reports and Documents Available for Purchase page I click Continue
Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test
Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
Given If purchase details are showing click confirm order
Given I navigate to the home page
Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Submitted Status for saved as: TestCase120816)
Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase120816)
Given I call Shared Step 59066 (Go to SHA Manager)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Assigned Status for saved as: TestCase120816)
Given I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase120816)
Given I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase120816)
And I call Shared Step 79500 (WPS Studio - PD+ - set all data and publish using rule and doc queue - CKLT and SBCS only) for product saved as: TestCase120816	
Given I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase120816)
Given I call Shared Step 59066 (Go to SHA Manager)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase120816)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase120816 and its status is: Accepted



Scenario: [120817] WERCSmart product - Submitted to SHA, Status = Completed
Given I Login into WERCSmart Portal - WebViewers Account
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Then I call Shared Step 57561b (The Product - Enter Product Name: TC 210817 - For RPS - Completed Status and select Type of Product): Chalk and add a Random Identifier
Given I generate a random UPC number and save as: UPC120815
Then I save the product information as: TestCase120817
Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Chalk
Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Given I call shared step 120812 (Retailer - Add retailers for RPS)
Given I call shared step 120813 (UPC - Add 2 UPCs - including one for CVS RCL and Add Home Depot OMSID for UPC: CVS, container type: Metal Container and size: 40)
Given I call shared step 51609 (CVS RCL - Yes I wish to continue with registration - Continue)
Given I call shared step 52131 (CVS RCL Information - add Other where available and all other data)
Given I call Shared Step 78080 (Regulatory Documents to Provide - Upload OSHA SDS)
Given in the Additional Documents to Provide page I click Continue
Given in the Optional Reports and Documents Available for Purchase page I click Continue
Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test
Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
Given If purchase details are showing click confirm order
Given I navigate to the home page
Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Submitted Status for saved as: TestCase120817)
Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase120817)
Given I call Shared Step 59066 (Go to SHA Manager)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Assigned Status for saved as: TestCase120817)
Given I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase120817)
Given I call Shared Step 107012 (WPS Studio - Open PD+ with MTR/RPS subformat for product saved as: TestCase120817)
Given I call Shared Step 107013 (WPS PD+ - select your product for product saved as: TestCase120817)
Given I call Shared Step 120826 (WPS Studio - PD+ - Add RPS specific data for product saved as: TestCase120817)
Given I call Shared Step 120845 (WPS Studio - PD+ - change to MTR/CKLT for product saved as: TestCase120817)
And I call Shared Step 79500 (WPS Studio - PD+ - set all data and publish using rule and doc queue - CKLT and SBCS only) for product saved as: TestCase120817	
Given I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase120817)
Given I call Shared Step 59066 (Go to SHA Manager)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase120817)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase120817 and its status is: Completed



Scenario: [120848] WERCSmart product - Submitted to SHA, Status = Suspended (Safety Data Sheet (SDS) or Label Mismatch due to 3rd-Party Formula)

	Given I Login into WERCSmart Portal - WebViewers Account
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Then I call Shared Step 57561b (The Product - Enter Product Name: TC 120848 - For RPS - Suspended Status - Formula - Document Issue and select Type of Product): Chalk and add a Random Identifier
	Then I save the product information as: TestCase120848
	Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	And I call Shared Step 29181 (Ingredients - add any chemical) with name: Water
	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given I call shared step 120812 (Retailer - Add retailers for RPS)
	Given I call shared step 120813 (UPC - Add 2 UPCs - including one for CVS RCL and Add Home Depot OMSID for UPC: CVS, container type: Metal Container and size: 40)
	Given I call shared step 51609 (CVS RCL - Yes I wish to continue with registration - Continue)
	Given I call shared step 52131 (CVS RCL Information - add Other where available and all other data)
	Given I call Shared Step 78080 (Regulatory Documents to Provide - Upload OSHA SDS)
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Testing the comments text box to make sure it is working properly.
	Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given I navigate to the home page
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase120848)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase120848 and its status is: Submitted
	Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase120848)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase144967)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase120848 and its status is: Assigned
	Given I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase120848)
	Given I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase120848)
	And I call Shared Step 79500 (WPS Studio - PD+ - set all data and publish using rule and doc queue - CKLT and SBCS only) for product saved as: TestCase120848	
	Given I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase120848)
	Given I call Shared Step 59066 (Go to SHA Manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase120848)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase120848 and its status is: Accepted
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase120848 and its status is: Completed
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase120848)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase120848 and its status is: Pending


Scenario: [120858] WERCSmart Product - from Completed status to Recertification
Given I Login into WERCSmart Portal - WebViewers Account
Given I search for the product saved as: TestCase120817
Given For product saved as: TestCase120817 the status is: Completed
Given I call Shared Step 92580 (Click ... in Actions > Update Data > Summary Page - Edit Product)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase120817)
Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase120817 and its status is: Completed
And I call Shared Step 51351 (SHA > Select Product > View Recertification History) for product saved as: ProdInfo120817
And In the Product Recertification History popup I should see the following entry
		| Product ID             | Active | Recertification Reason                           |
		| saved as TestCase84511 | true   | Recertification of Product by WERCSmart Customer |
And I Close the Product Recertification History pop up
Given In the New Product page I click tab: Product Type
And I click the page heading: Physical and Chemical Properties
And I click Save in The Product Page
Given In the New Product page I click tab: Review and Submit
Then I click the page heading: Data Acceptance
And In the Data Acceptance page I click on the Accept button
And In the Purchase Summary screen I confirm the Purchase Summary header is displayed
Given If purchase details are showing click confirm order
Given In the Thank You screen I click Home
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase120817)
And I call Shared Step 51351 (SHA > Select Product > View Recertification History) for product saved as: ProdInfo120817
And In the Product Recertification History popup I should see the following entry
		| Product ID             | Active | Recertification Reason                            |
		| saved as TestCase120817| false   | Recertification of Product by WERCSmart Customer |
And I Close the Product Recertification History pop up

Scenario: [120820] WERCSmart product - Submitted to SHA, Status = Cancelled

Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I generate a random UPC number and save as: UPC120820
Then I save the product information as: TestCase120820
Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
Given I generate a random UPC number and save as: UPC120820
Then I save the product information as: TestCase120820
Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Chalk
Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Given I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue) for
		| Retailer  |
		| Walgreens |
Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC120820, container type: Plastic Container and size: 15.2
Given I call Shared Step 78080 (Regulatory Documents to Provide - Upload OSHA SDS)
Given I click continue
Given I click continue
Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test
Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
Given If purchase details are showing click confirm order
Given In the Thank You screen I click Home
Given I call Shared Step 65080b (Login to Studio as user saved as: SHAQAAuto16 and Open SHA manager)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Submitted Status for saved as: TestCase120820)
And I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase120820)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Assigned Status for saved as: TestCase120820)
Given I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase120820)
Given I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase120820)
Given I call Shared Step 75347 (WPS Studio - PD+ - set all data and publish using rule and Doc queue - CKLT, NGHS and SBCS) for product saved as: TestCase120820
And I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase120820)
Given I call Shared Step 59066 (Go to SHA Manager)
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Accepted Status for saved as: TestCase120820)
Given I call Shared Step 155714 (SHA - Accepted Product - set Retailers to Cancelled for saved as: TestCase120820) for
| Retailer |
| Walgreens|
Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Cancelled Status for saved as: TestCase120820)

Scenario: [126691] WERCSmart product - Pesticide - processed from New to Suspended-Pesiticde
Given I Login into WERCSmart Portal - WebViewers Account
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Then I call Shared Step 57561b (The Product - Enter Product Name: TC 126691 - For RPS - Status is Suspended-Pesticide and select Type of Product): Chalk and add a Random Identifier
	Then I save the product information as: TestCase126691
	Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	And I call Shared Step 29181 (Ingredients - add any chemical) with name: Water
	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given I call shared step 120812 (Retailer - Add retailers for RPS)
	Given I call shared step 120813 (UPC - Add 2 UPCs - including one for CVS RCL and Add Home Depot OMSID for UPC: CVS, container type: Metal Container and size: 40)
	Given I call shared step 51609 (CVS RCL - Yes I wish to continue with registration - Continue)
	Given I call shared step 52131 (CVS RCL Information - add Other where available and all other data)
	Given I call Shared Step 78080 (Regulatory Documents to Provide - Upload OSHA SDS)
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Testing the comments text box to make sure it is working properly.
	Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given I navigate to the home page
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase126691)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase126691 and its status is: Submitted
	Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase126691)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase126691)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase144967 and its status is: Assigned
	Given I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase126691)
	Given I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase126691)
	And I call Shared Step 79500 (WPS Studio - PD+ - set all data and publish using rule and doc queue - CKLT and SBCS only) for product saved as: TestCase126691	
	Given I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase126691)
	Given I call Shared Step 59066 (Go to SHA Manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase126691)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase126691 and its status is: Accepted
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase126691 and its status is: Completed
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase126691)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase126691 and its status is: Pending
	
Scenario: [121986] WERCSmart product - Fails CVS Audit (Palm oil) from New thru to Status = Completed
Given I Login into WERCSmart Portal - WebViewers Account
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Then I call Shared Step 57561b (The Product - Enter Product Name: TC 121986 - for RPS - Fails CVS Audit Palm oil and select Type of Product): Chalk and add a Random Identifier
	Then I save the product information as: TestCase121986
	Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	And I call Shared Step 29181 (Ingredients - add any chemical) with name: Water
	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given I call shared step 120812 (Retailer - Add retailers for RPS)
	Given I call shared step 120813 (UPC - Add 2 UPCs - including one for CVS RCL and Add Home Depot OMSID for UPC: CVS, container type: Metal Container and size: 40)
	Given I call shared step 51609 (CVS RCL - Yes I wish to continue with registration - Continue)
	Given I call shared step 52131 (CVS RCL Information - add Other where available and all other data)
	Given I call Shared Step 78080 (Regulatory Documents to Provide - Upload OSHA SDS)
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Testing the comments text box to make sure it is working properly.
	Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given I navigate to the home page
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase121986)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase121986 and its status is: Submitted
	Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase121986)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase121986)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase121986 and its status is: Assigned
	Given I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase121986)
	Given I call Shared Step 107012 (WPS Studio - Open PD+ with MTR/RPS subformat for product saved as: TestCase121986)
	Given I call Shared Step 107013 (WPS PD+ - select your product for product saved as: TestCase121986)
	Given I call Shared Step 120845 (WPS Studio - PD+ - change to MTR/CKLT for product saved as: TestCase121986)
	And I call Shared Step 79500 (WPS Studio - PD+ - set all data and publish using rule and doc queue - CKLT and SBCS only) for product saved as: TestCase121986	
	Given I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase121986)
	Given I call Shared Step 59066 (Go to SHA Manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase121986)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase121986 and its status is: Accepted
	Given I call Shared Step 51664 (SHA - Accepted Product - set Retailers to Completed for saved as: TestCase121986) for
	| Retailer |
	| CVS      |
