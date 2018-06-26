@LandingPage
@Login
@Homepage
@ForgottenPassword
@SupplierReports
@RetailPartners
@wercsmart
@Signup
@run_SupplierReports

Feature: Supplier Reports

Background:
Given I go to the WERCSmart Log in


@RetailPartners
Scenario: [68422] Battery-containing products report
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Given If a modal dialog opens I close it
Given I click the Supplier Reports icon in the QuickLinks Pane
Given Under the Supplier Reports menu I choose: Battery-containing products report
Then In the Supplier Reports screen the current page should be: Battery-containing products report
Given In the Supplier Reports screen I click on the Download button
Given I click on close in the Report Download dialog
Given I confirm that an excel file is produced called Battery-containing products report.xlsx and save as 68422
Then I confirm that the excel file saved as: 68422 contains the following columns:

| Column        |
| Supplier Name |
| WPSID         |
| Product Name  |
| Battery Type  |
| Battery Mfg   |




