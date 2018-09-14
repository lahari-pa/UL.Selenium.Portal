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
@SummaryPage
@run_ULSolutionCenter

Feature: UL Solution Center

Scenario: [59654] UL Solution Center shows when expanded menu item is clicked

Given I login as the administrator

Then The home screen should load

Given I expand the Navigation Menu

Then the Navigation Menu should be expanded

Given I click the UL Solution Center link in the expanded navigation side menu

Then I confirm that the UL Solution Center page is loaded

Scenario: [59655] UL Solution Center shows correct entries

Given I login as the administrator

Then The home screen should load

Given I click the UL Solution Center icon in the QuickLinks Pane

Then I confirm the following sections are displayed in the UL Solution Center page:
| Sections                 |
| ECOLOGO                  |
| Prospector               |
| GoodGuide for Consumers  |
| GoodGuide for Suppliers  |
| UL Secure Connect (ULSC) |
| ULGHS                    |
