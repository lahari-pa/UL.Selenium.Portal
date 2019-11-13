@Shared
@LandingPage
@Login
@Homepage
@Signup
@wercsmart
@NewProduct
@ProductGrid
@SHA
@wercsmart
@RetailPartners
@CreateProducts
@Studio
@ProductSetUp
@run_ProductSetUp
Feature:  Product set up and process to specific statuses (Suite ID: 75359)

@ScenarioId:1074
Scenario: [80089] Create product with Publicly Disclosed Ingredients (bleach) - process to completed
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bleach
	Then I save the product information as: TestCase80089
	And I call Shared Step 57501 (Product Characteristics - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue - HP)
	And I call Shared Step 74340 (Additional Product Information - Pesticide= Not considered, SOLD=US, everything else = No - Continue)
	And call Shared Step 80090 - Ingredients - Add non-generic chemical, set to publicly Disclosed, select public name and save ingredient as: Ing800891
		| CASNumber | ComponentName | Percentage |
		| 100-41-4  | Ethylbenzene  | 35         |
	Given I call Shared Step 79431 (Ingredients - Add FLAVOR component, Publicly Disclosed = Yes, Select Public Name) and save ingredients as: Ing800892
		| CASNumber  | ComponentName | Percentage |
		| RR-38669-6 | FLAVORS       | 35         |
	And call Shared Step 80091 - Ingredients - Add Non-generic component - set percentage - not publicly disclosed and save ingredient as: Ing800893
		| CASNumber | ComponentName | Percentage |
		| 108-95-2  | Phenol        | 30         |
	Then in the Ingredients page I click Continue
	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	And I call Shared Step 57507 (Transportation Details 1- Not Regulated - Continue - Happy Path)
	And I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	And I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	And I should see the Additional Documents to Provide Page
	And I call Shared Step 59042 (Browse for File > select > click Open - Happy Path) for document type: IFRA Certificate (Perfumery Products) and file: C:\Dependencies\WERCSmart\testdoc.pdf
	And I call Shared Step 59042 (Browse for File > select > click Open - Happy Path) for document type: GRAS Certificate (Flavor Products) and file: C:\Dependencies\WERCSmart\testdoc.pdf
	Then in the Additional documents page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
		| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
	And I call Shared Step 57883 (Comments - Happy Path) and enter the comment: test
	And I call Shared Step 73956 (Go to Summary and verify data) with product type: Bleach
	Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given If purchase details are showing click confirm order
	#************************** Switching to SHA Manager **********************
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase80089)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase80089 and its status is: Submitted
	Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase80089)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase80089)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase80089 and its status is: Assigned
	And I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase80089)
	And I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase80089)
	And I call Shared Step 75347 (WPS Studio - PD+ - set all data and publish using rule and Doc queue - CKLT, NGHS and SBCS) for product saved as: TestCase80089
	And I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase80089)
	Given I call Shared Step 59066 (Go to SHA Manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase80089)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase80089 and its status is: Completed

@ScenarioId:1073
Scenario: [75410] Product from Completed status to Recertification
	Given I create a product and take to completed using Test Case 75335 and save as: TestCase75410
	#Scenario: Test
	#Given I save to context name: TestCase75410 and value: 1549822
	#Given I call test stuff for saved as: TestCase75410
	Given I navigate to the landing page
	Given I login into the WERCSmart Portal - Administrator Role
	Given I search for the product saved as: TestCase75410
	Given For product saved as: TestCase75410 the status is: Completed
	And I click Row Actions for the first product returned
	And I click on the Row Action: Update Data
	And I should see the Update Registration popup
	And In the Update Registration popup I click on button Yes
	#And I If you are using a supplier registered for ULSC you will see the ULSC Service Data-Re-Import step, select the No, continue editing data radio button and click Save
	And I should see the The Product Page
	Then I click Save in The Product Page
	#Scenario: Test
	#Given I save to context name: TestCase75410 and value: 1524479
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase75410)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase75410 and its status is: Completed
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase75410 and its font is red indicating a recertification
	And I call Shared Step 51351 (SHA > Select Product > View Recertification History) for product saved as: TestCase75410
	And In the Product Recertification History popup I should see the following entry
		| Product ID             | Active | Recertification Reason                           |
		| saved as TestCase75410 | true   | Recertification of Product by WERCSmart Customer |
	Given I navigate to the landing page
	Given I login into the WERCSmart Portal - Administrator Role
	Given I search for the product saved as: TestCase75410
	Given For product saved as: TestCase75410 the status is: Needs Your Attention
	And I click Row Actions for the first product returned
	And I click on the Row Action: Update Required
	#And I If you are using a supplier registered for ULSC you will see the ULSC Service Data-Re-Import step, select the No, continue editing data radio button and click Save
	And I should see the The Product Page
	And I click the page heading: Product Characteristics
	And I Change the Secondary Physical State drop down from its current selection to a new selection
	Then I click Save in The Product Page
	And In the New Product page I click tab: Review and Submit
	And I click the page heading: Data Acceptance
	And In the Data Acceptance page I click on the Accept button
	Given If purchase details are showing click confirm order
	And I navigate to the home page
	And I search for the product saved as: TestCase75410
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase75410 and its status is: Recertification
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase75410 and its font is not red indicating a recertification
	And I call Shared Step 51351 (SHA > Select Product > View Recertification History) for product saved as: TestCase75410
	And In the Product Recertification History popup I should see the following entry
		| Product ID             | Active | Recertification Reason                           |
		| saved as TestCase75410 | false  | Recertification of Product by WERCSmart Customer |
	And I Close the Product Recertification History pop up

Scenario: [84507] Recertification > Process recertification > Process multiple products
	Given I create a product with name: 8450712 and take to completed using Test Case 84108 and save as: TestCase845072
	Given I take a product from completed to recertification using Test Case 75410 saved: TestCase845072
	Given I create a product with name: 8450711 and take to completed using Test Case 75335 and save as: TestCase845071
	Given I take a product from completed to recertification using Test Case 75410 saved: TestCase845071
	Given I create a product with name: 8450713 and take to completed using Test Case 84109 and save as: TestCase845073
	Given I take a product from completed to recertification using Test Case 84511 saved: TestCase845073
	#Scenario: Test
	#And I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Recertification Status for saved as: TestCase84511)
	Given In SHA Manager ProductSearch page I run search:
		| Status          | SearchPattern | ProductName |
		| Recertification | Contains      | 845071      |
	Given In SHA Manager I select the following products:
		| ProductID               |
		| saved as TestCase845071 |
		| saved as TestCase845072 |
		| saved as TestCase845073 |
	And I Click the Process Recertification button
	And I Confirm the Recertification pop up is shown
	And I Uncheck the Auto Assign Regulatory Specialist to Product check box
	And I Select AutomatedQASha  from the drop down list for Select Regulatory Specialist
	And In the Recertification popup I click Continue
	And In the Recertification popup the Continue button will no longer be shown
	#And I After a short interval the Progress bar will show as grey hatching indicating processing of the first product has finished
	#And I After each product is processed the progress bar will move along until it it shown in complete grey color
	And in the Recertification popup I wait for all processing to be completed
	And in the Recertification popup I should see the following products as successfully assigned
		| ProductID               |
		| saved as TestCase845071 |
		| saved as TestCase845072 |
		| saved as TestCase845073 |
	And In the Recertification popup I click Continue
	And I Confirm the Recertification pop up is closed
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase845072)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase845071 and its status is: Assigned
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase845072)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase845072 and its status is: Assigned
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase845072)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase845073 and its status is: Assigned


Scenario: [96663] Forward NR Product - Completed Status to two retailers
NetProjects10\WercsSmart Portal\WERCSmart\Product set up and process to specific statuses
Given I If you are using this test case then you already have a product you are working with which you made using test case 96661
And I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
And [Shared Step 75130 - Bulk Actions - Select Forward Product Registration]
And I With the 'Selected Products Tab' selected by default
And I In the "Search by WPS ID or Product Name" start typing the WPS ID or Product Name of the Product you are working with
And I Confirm the Product is shown for selection
And I Select the product by clicking on it
And I Click 'CONTINUE'
And I Select two Retailers
And I Click 'CONTINUE'
And [Shared Step 84195 - Forwarding - Add a new UPC - Save - Select UPC and Continue]
And I The 'Product Results Tab' is selected
And I Confirm that the UPC Number displays the recently selected "Retailer"(Step 17)
And I Confirm that NO Errors display for the Product
And I Click 'CONTINUE'
And I The 'Review and Submit' step is shown
And I Select the "All of the above statements are true" Radio Button
And I Click 'CONTINUE'
And I Confirm the Purchase Summary page is shown with the success message shown" Thank you for registering your product on WERCSmart for assessment. The retailers may receive your assessment in approximately two (2) business days, if no delays in processing the assessment, and should no data issues arise.  "
And I Click on the 'HOME BUTTON'
And I In SHA Manager
And I In the shared step below search for your product using the WPS ID you noted earlier
And I call Shared Step 49841 (SHA - Search for exact WPS ID in (.*) Status for saved as: (.*))
And I Confirm the Product shows a "Completed Status" for the Original Retailer(see Clients column) - should show NR
And I Confirm the Productshows a "Submitted Status" for the recently selected Retailer (see clients column)The Retailers you selected in step 8
And [Shared Step 75309 - SHA > Select Product > UPC List]
And I With the SHA Manager Product UPC window open - Click on the 'maximize' icon to expand the view of the window
And I Confirm the recently added Retailer(s)is (are) shown against the UPC you selected
And I Confirm the UPC status shown is 2
And I Close the SHA Manager Product UPC window
And I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: (.*))
And I In the shared step below search for the Product you are working with
And I call Shared Step 49841 (SHA - Search for exact WPS ID in (.*) Status for saved as: (.*))
And I Confirm the Product shows the ORIGINAL RETAILER(s) with a "Completed Status" (see the Clients column)
And I Confirm the Product shows theNEW RETAILER(s) with an "Accepted Status" (see the Clients column)Note: if you selected a retailer that does not have a feed associated to it you will see the product in Completed status for this retailer)
And I In the Shared Step below - Select the Product with the "Accepted Status"
And I call Shared Step 51664 (SHA - Accepted Product - set Retailers to Completed for saved as: (.*))
And I Confirm the Product now shows a "Completed" Status in Completed forALL associated Retailers
