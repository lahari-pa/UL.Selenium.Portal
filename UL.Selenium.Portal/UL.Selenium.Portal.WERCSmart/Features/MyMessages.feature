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
@ProductSetUp
@UPC
@ReviewDocuments
@SHA
@CreateProducts
@MyMessages
@run_MyMessages
Feature: MyMessages

@ScenarioId:1038
Scenario: [72582] Active Export Report
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I click the My Messages icon in the QuickLinks Pane
	Given I save the messages in Message Center as messages72582
	Given I click the Export button
	Given I confirm an excel file is downloaded then close the Report Download popup. I save the file as excel72582
	Then I confirm that the exported excel file saved as: excel72582 contains the following columns:
		| Column        |
		| WPSID         |
		| Product Name  |
		| Type of Alert |
		| Alert Date    |
		| Subject       |
		| Details       |
		| Status        |
	Then I confirm that the text: Active is displayed exclusively under the Status column for file saved as excel72582
	And I confirm the number of rows in the file saved as excel72582 matches the number of messages in My Messages saved as messages72582
	And I delete the excel file saved as excel72582

# Need to check how to archive messages - there are none archived in the products account
@tfs_design
@ignore
@ScenarioId:9410
Scenario: [72586] Archive Export Report
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I click the My Messages icon in the QuickLinks Pane
	Given I save the messages in Message Center as messages72586
	Given I click the 'Show Archived' checkbox
	Given I click Filter
	Then I confirm that additional messages were displayed since they were saved as messages72586
	Given I click the Export button
	Given I confirm an excel file is downloaded then close the Report Download popup. I save the file as excel72586
	Then I confirm that the exported excel file saved as: excel72586 contains the following columns:
		| Column        |
		| WPSID         |
		| Product Name  |
		| Type of Alert |
		| Alert Date    |
		| Subject       |
		| Details       |
		| Status        |
	Then I confirm that the text: Archived is displayed under the Status column for file saved as excel72586
	And I delete the excel file saved as excel72586

@tfs_design
@ignore
@ScenarioId:1541
Scenario: [109503] Message Center - Suspended message stays in Message Center for entirety of processing product - Formula - Document Issue
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I generate a random UPC number and save as: UPC109503
	Then The home screen should load
	And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	And I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk
	Then I save the product information as: TestCase109503
	Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue) for
		| Retailer  |
		| Walgreens |
	Given I call Shared Step 87647 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC109503, container type: Paper bag and size: 2 do not click continue
	Given I click continue
	And  I call Shared Step 78080 (Regulatory Documents to Provide - Upload OSHA SDS)
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test
	Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	And I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Submitted Status for saved as: TestCase109503)
	Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase109503)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Assigned Status for saved as: TestCase109503)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase109503 and its status is: Assigned
	And In SHA Manager I select the first product
	And I click the following option in the bottom menu: Suspended
	And In the Suspended dialog I Select the following clients: All
	And In the Suspended dialog in the Select Regulatory Specialist drop down I choose: Automated QASha
	And In the Suspended dialog in the Select Subject drop down I choose: Formula � Document Issue
	And In the Suspended dialog in the Supplier Message field I add the following text: supplier message input
	And In the Suspended dialog in the Internal Product Note field I add the following text: internal product note input
	And In the Suspended dialog I click Save
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase109503)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase109503 and its status is: Suspended
	Given In the SHA Manager grid I click Message Center
	And In the Message Center I go to the last page of messages

