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
@SummaryPage
@Studio
@ProductSetUp
@run_ProductSetUpElectronic
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:NewProduct
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:TheProduct
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:ProductInformation
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:InventoryStatusProp65
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:ToxicityCharacteristicLeachingProcedureTCLP
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:ElectronicEquipment
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:OptionalComments
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:DataAcceptance
@SideMenu
@Steps_ProductPrototype

Feature: ProductSetUp_Electronic

#Background:
#	Given I verify the following users exist and if not I create them using SHAUser
#		| username    | FirstName | LastName   | Role         | EmailAddress                |
#		| SHAQAAuto22 | QA        | Automation | QA Reviewers | qasha.kxxyxunf@mailosaur.io |

#@ignore
@TestCase:84109
Scenario: [84109] Create Electronic - process to Completed (Answering machine, no battery included)
	#Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I log in with the account saved in TReVor as: ProductAccount
	#And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	And the WERCSmart homepage should load
	And In the Side Menu, click Labeled Link with Add Product title
	And I should see the New Product Page
	And In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration'
	And in the New Product page I click Continue
	#And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Answering machine, No battery included
	And I should see the The Product Page
	#And In section: Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS), enter text: Test
	And In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: TestCase84109
	#And In the Product Section, set the option in section: 'Type of Product (select)' to: Answering machine, No battery included
	And In section: Type of Product (select), click search text box
	And In the search input pop-up, search and select: Answering machine, No battery included
	And in the The Product page I click Continue
	Then I save the product information as: TestCase84109
	#Then I call Shared Step 60935 Product Information - US - Direct Ship - Private Label Only
	And I should see the Product Information Page
	And In the Product Information Section, set the option in section: 'Select countries the product may be sold in' to: United States
	And In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	And In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	And in the Product Information page I click Continue
	#And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	And I should see the Inventory Status, Prop 65 (US) Page
	And In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	And In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	And in the Inventory Status, Prop 65 (US) page I click Continue
	#And I call Shared Step 48369 (Toxicity Characteristics Leaching Procedure (TCLP) - No to ALL With Copper)
	And I should see the Toxicity Characteristic Leaching Procedure (TCLP) Page
	And In the Toxicity Characteristic Leaching Procedure (TCLP) Section, set the option in section: 'Product has had TCLP testing; Report is available' to: No
	And In the Toxicity Characteristic Leaching Procedure (TCLP) Section, set the radio option in section: 'Lead': to: No
	And In the Toxicity Characteristic Leaching Procedure (TCLP) Section, set the radio option in section: 'Mercury': to: No
	And In the Toxicity Characteristic Leaching Procedure (TCLP) Section, set the radio option in section: 'Silver': to: No
	And In the Toxicity Characteristic Leaching Procedure (TCLP) Section, set the radio option in section: 'Cadmium': to: No
	And In the Toxicity Characteristic Leaching Procedure (TCLP) Section, set the radio option in section: 'Chromium': to: No
	And In the Toxicity Characteristic Leaching Procedure (TCLP) Section, set the radio option in section: 'Barium': to: No
	And In the Toxicity Characteristic Leaching Procedure (TCLP) Section, set the radio option in section: 'Arsenic': to: No
	And In the Toxicity Characteristic Leaching Procedure (TCLP) Section, set the radio option in section: 'Selenium': to: No
	And In the Toxicity Characteristic Leaching Procedure (TCLP) Section, set the radio option in section: 'Copper': to: No
	And in the Toxicity Characteristic Leaching Procedure (TCLP) page I click Continue
	#And I call Shared Step 71955 (Answer Electronic Equipment questions - Without Cathode Ray - No to all)
	And I should see the Electronic Equipment Page
	And In the Electronic Equipment Section, set the option in section: 'Contains Circuit Board' to: No
	And In the Electronic Equipment Section, set the option in section: 'Has a LCD or Plasma Display' to: No
	And in the Electronic Equipment page I click Continue
	#And I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	And I should see the Retailer Page
	And in the Retailer page I click Continue
	And I should see the Additional Documents to Provide Page
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	#And I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test
	And I should see the Optional Comments Page
	And In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Given in the Optional Comments page I click Continue

	#And I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	#Given If purchase details are showing click confirm order
	#Given I call Shared Step 65080b (Login to Studio as user saved as: SHAQAAuto22 and Open SHA manager)
	#Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase84109)
	#Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase84109 and its status is: Submitted
	#Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase84109)
	#Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase84109)
	#Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase84109 and its status is: Assigned
	#nd I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase84109)

	#Given I call Shared Step (SHA - Assgined Product - set Retailers to Completed for saved as: TestCase84109) for	
	#	| Retailer                   |		
	#	| No Retailer/No UPC Product |
	#Note: In Staging and Production - Electronic products are automatically published by the ImportProcessRules so if you are running in either of these sites you can skip to step 28
	#And I check whether the current environment is Staging or Production and if it is I skip the next three steps
	#And I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase84109)
	#And I call Shared Step 79500 (WPS Studio - PD+ - set all data and publish using rule and doc queue - CKLT and SBCS only) for product saved as: TestCase84109
	#And I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase84109)
	#Given I call Shared Step 59066 (Go to SHA Manager)
	#Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase84109)
	#Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase84109 and its status is: Completed

@ignore
@TestCase:84511
Scenario: [84511] Electronic Product from Completed status to Recertification
	#If you are using this test case you already have a product you are working with and it is in a Completed status for 1 or more retailers.
	#Given I create an electronic product and save it as: TestCase84511
	Given I create a Forced to Completed electronic product and save it as: TestCase84511
	Given I navigate to the landing page
	Given I login into the WERCSmart Portal - Administrator Role
	Given I search for the product saved as: TestCase84511
	Given For product saved as: TestCase84511 the status is: Completed
	And I click Row Actions for the first product returned
	And I click on the Row Action: Update Data
	Then I wait for the Summary Screen to Load
	Then In the Summary screen, I click the Edit Product Button
	And I should see the Update Registration popup
	And In the Update Registration popup I click on button Continue	
	#And I If you are using a supplier registered for ULSC you will see the ULSC Service Data-Re-Import step, select the No, continue editing data radio button and click Save
	And I should see the The Product Page
	Then I click Save in The Product Page
	#Scenario: Test
	#Given I save to context name: TestCase84511 and value: 1524214
	Given I call Shared Step 65080b (Login to Studio as user saved as: SHAQAAuto22 and Open SHA manager)
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
	And In the New Product page I click tab: Physical and Chemical Properties
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
	Given I call Shared Step 65080b (Login to Studio as user saved as: SHAQAAuto22 and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase84511)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase84511 and its status is: Recertification
	#And I Confirm your product is shown in the Recertification status without the red recertification font color
	And I call Shared Step 51351 (SHA > Select Product > View Recertification History) for product saved as: TestCase84511
	And In the Product Recertification History popup I should see the following entry
		| Product ID             | Active | Recertification Reason                           |
		| saved as TestCase84511 | false  | Recertification of Product by WERCSmart Customer |
	And I Close the Product Recertification History pop up
