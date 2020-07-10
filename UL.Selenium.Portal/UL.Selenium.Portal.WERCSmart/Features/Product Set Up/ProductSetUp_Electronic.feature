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
@run_ProductSetUpElectronic

Feature: ProductSetUp_Electronic

@ScenarioId:1413
Scenario: [84109] Create Electronic - process to Completed (Answering machine, no battery included)
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Answering machine, No battery included
	Then I save the product information as: TestCase84109
	#And I call Shared Step 69687 (Additional Product Information - US, No(PL))
	Then I call Shared Step 60935 Additional Product Information - US - Direct Ship - Private Label Only
	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	And I call Shared Step 48369 (Toxicity Characteristics Leaching Procedure (TCLP) - No to ALL With Copper)
	And I call Shared Step 71955 (Answer Electronic Equipment questions - Without Cathode Ray - No to all)
	And I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	And I should see the Additional Documents to Provide Page
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	And I call Shared Step 57883 (Comments - Happy Path) and enter the comment: test
	And I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given If purchase details are showing click confirm order
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase84109)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase84109 and its status is: Submitted
	Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase84109)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase84109)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase84109 and its status is: Assigned
	And I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase84109)
	#Note: In Staging and Production - Electronic products are automatically published by the ImportProcessRules so if you are running in either of these sites you can skip to step 28
	And I check whether the current environment is Staging or Production and if it is I skip the next three steps
	And I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase84109)
	And I call Shared Step 79500 (WPS Studio - PD+ - set all data and publish using rule and doc queue - CKLT and SBCS only) for product saved as: TestCase84109
	And I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase84109)
	Given I call Shared Step 59066 (Go to SHA Manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase84109)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase84109 and its status is: Completed

@ScenarioId:5970
Scenario: [84511] Electronic Product from Completed status to Recertification
	#If you are using this test case you already have a product you are working with and it is in a Completed status for 1 or more retailers.
	Given I create an electronic product and save it as: TestCase84511
	Given I navigate to the landing page
	Given I login into the WERCSmart Portal - Administrator Role
	Given I search for the product saved as: TestCase84511
	Given For product saved as: TestCase84511 the status is: Completed
	And I click Row Actions for the first product returned
	And I click on the Row Action: Update Data
	And I should see the Update Registration popup
	And In the Update Registration popup I click on button Yes	
	#And I If you are using a supplier registered for ULSC you will see the ULSC Service Data-Re-Import step, select the No, continue editing data radio button and click Save
	And I should see the The Product Page
	Then I click Save in The Product Page
	#Scenario: Test
	#Given I save to context name: TestCase84511 and value: 1524214
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase84511)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase84511 and its status is: Completed
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase84511 and its font is red indicating a recertification
	And I call Shared Step 51351 (SHA > Select Product > View Recertification History) for product saved as: TestCase84511
	And In the Product Recertification History popup I should see the following entry
		| Product ID             | Active | Recertification Reason                           |
		| saved as TestCase84511 | true   | Recertification of Product by WERCSmart Customer |
	And I Close the Product Recertification History pop up
	#Scenario: Test
	#Given I save to context name: TestCase84511 and value: 1524214
	Given I navigate to the landing page
	Given I login into the WERCSmart Portal - Administrator Role
	Given I search for the product saved as: TestCase84511
	Given For product saved as: TestCase84511 the status is: Needs Your Attention
	And I click Row Actions for the first product returned
	And I click on the Row Action: Update Required
	#And I If you are using a supplier registered for ULSC you will see the ULSC Service Data-Re-Import step, select the No, continue editing data radio button and click Save
	And I should see the The Product Page
	And In the New Product page I click tab: Product Characteristics
	And I click the page heading: Toxicity Characteristic Leaching Procedure (TCLP)
	And I set the Lead option to: Yes
	And I set the Mercury option to: Yes
	And I set the Silver option to: Yes
	Then I click Save in The Product Page
	And In the New Product page I click tab: Review and Submit
	And I click the page heading: Data Acceptance
	And In the Data Acceptance page I click on the Accept button
	Given If purchase details are showing click confirm order
	And I navigate to the home page
	And I search for the product saved as: TestCase84511
	Given For product saved as: TestCase84511 the status is: Assessment in Progress
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase84511)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase84511 and its status is: Recertification
	#And I Confirm your product is shown in the Recertification status without the red recertification font color
	And I call Shared Step 51351 (SHA > Select Product > View Recertification History) for product saved as: TestCase84511
	And In the Product Recertification History popup I should see the following entry
		| Product ID             | Active | Recertification Reason                           |
		| saved as TestCase84511 | false  | Recertification of Product by WERCSmart Customer |
	And I Close the Product Recertification History pop up
