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
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:ProductInformation
@PhysicalAndChemicalProp
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:OptionalComments
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:DataAcceptance

Feature: MyMessages

@ignore
@TestCase:72582
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
@TestCase:72586
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
@TestCase:109503
Scenario: [109503] Message Center - Suspended message stays in Message Center for entirety of processing product - Formula - Document Issue
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I generate a random UPC number and save as: UPC109503
	Then The home screen should load
	And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	And I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk
	Then I save the product information as: TestCase109503
	#Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Given I should see the Product Information Page
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)' to: No
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue

	#Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I should see the Physical and Chemical Properties Page
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' should be showing the option: Solid
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' confirm option is selected: Solid
	Then In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
	Then In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Then In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
	Then in the Physical and Chemical Properties page I click Continue

	#Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
	Given I should see the Ingredients Page
	Then In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	| component name | Sodium hydroxide       | 100     |                     |               |             |
	Then in the Ingredients page I click Continue

	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue) for
		| Retailer  |
		| Walgreens |
	Given I call Shared Step 87647 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC109503, container type: Paper bag and size: 2 do not click continue
	Given I click continue
	And  I call Shared Step 78080 (Regulatory Documents to Provide - Upload OSHA SDS)
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	#Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given I should see the Data Acceptance Page
	Then In the Data Acceptance Section, check 'Agreed' checkbox
	Then In the Data Acceptance Section, click 'Accept' button

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

