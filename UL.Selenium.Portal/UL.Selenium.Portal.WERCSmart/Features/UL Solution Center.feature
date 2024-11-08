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
@ReviewDocuments
@SHA
@SummaryPage
@run_ULSolutionCenter
Feature: UL Solution Center


@ignore
@TestCase:59655
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
		| Navigator                |

@ignore
@TestCase:59658
Scenario: [59658] UL Solution Center shows correct entries - GOODGUIDE for CONSUMERS section
	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	Given I click the UL Solution Center icon in the QuickLinks Pane
	Then I confirm that the UL Solution Center page is loaded
	Then I Confirm the GoodGuide for Consumers heading is displayed next to an icon
	And I Confirm the information statement for section: GoodGuide for Consumers reads: GoodGuide is a product rating system designed to provide consumers with the information they need to make better shopping decisions. For the past 10 years, GoodGuide scientists have rated thousands of products and guided millions of people to healthier choices.
	And I confirm the Learn More button is displayed for section: GoodGuide for Consumers
	Given I click the Learn More button for section: GoodGuide for Consumers
	Given I switch to the GoodGuide for Consumers information tab
	And I close the window that opened
	Then I confirm that the UL Solution Center page is loaded

@ignore
@TestCase:59659
Scenario: [59659] UL Solution Center shows correct entries - GOODGUIDE FOR SUPPLIERS section
	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	Given I click the UL Solution Center icon in the QuickLinks Pane
	Then I confirm that the UL Solution Center page is loaded
	Then I Confirm the GoodGuide for Suppliers heading is displayed next to an icon
	And I Confirm the information statement for section: GoodGuide for Suppliers reads: GoodGuide is a product rating system designed to provide consumers with the information they need to make better shopping decisions. Upload product information, preview the GoodGuide Rating, publish, and reach thousands of consumers every month.
	And I confirm the Learn More button is displayed for section: GoodGuide for Suppliers
	Given I click the Learn More button for section: GoodGuide for Suppliers
	Given I switch to the GoodGuide for Suppliers information tab
	Then I check that the current URL contains: https://choosegoodguide.com/

#And I close the window that opened
#Then I confirm that the UL Solution Center page is loaded

#And I close the window that opened
#Then I confirm that the UL Solution Center page is loaded
