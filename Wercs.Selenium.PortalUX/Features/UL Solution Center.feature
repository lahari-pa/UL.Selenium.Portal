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

Then I confirm that the UL Solution Center page is loaded

Then I confirm the following sections are displayed in the UL Solution Center page:
| Sections                 |
| ECOLOGO                  |
| Prospector               |
| GoodGuide for Consumers  |
| GoodGuide for Suppliers  |
| UL Secure Connect (ULSC) |
| ULGHS                    |

Scenario: [81288] UL Solution Center shows correct entries - ECOLOGO section

Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)

Given I click the UL Solution Center icon in the QuickLinks Pane

Then I confirm that the UL Solution Center page is loaded

Then I Confirm the ECOLOGO heading is displayed next to an icon

And I Confirm the information statement for section: ECOLOGO reads: ECOLOGO Certified products, services and packaging are certified for reduced environmental impact. ECOLOGO Certifications are voluntary, multi-attribute, lifecycle based environmental certifications that indicate a product has undergone rigorous scientific testing, exhaustive auditing, or both, to prove its compliance with stringent, third-party, environmental performance standards.

And I confirm the Learn More button is displayed for section: ECOLOGO

Given I click the Learn More button for section: ECOLOGO

Given I switch to the tab: https://industries.ul.com/environment/certificationvalidation-marks/ecologo-product-certification

And I close the window that opened

Then I confirm that the UL Solution Center page is loaded
