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

# There are no messages in the automation products account Message Centre. We need a way to control/ add messages in order to test it
Scenario: [72582] Active Export Report

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

Given I click the My Messages icon in the QuickLinks Pane

Given I click the Export button

Given I confirm an excel file is downloaded then close the Report Download popup. I save the file as excel72582

Then I confirm that the excel file saved as: excel72582 contains the following columns:
| Column        |
| WPSID         |
| Product Name  |
| Type of Alert |
| Alert Date    |
| Subject       |
| Details       |
| Status        |

# Confirm that in the Status Column you see the word Active

# Confirm that the number of rows in the report (not including header) match the number of messages in the my messages icon

#Close the excel spreadsheet.
