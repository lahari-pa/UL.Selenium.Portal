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
@ReviewDocuments
@SHA
@MyMessages
@run_MyMessages
Feature: MyMessages

@TReVorId:18977
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
