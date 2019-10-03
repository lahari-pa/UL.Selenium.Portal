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

@ScenarioId:1097
Scenario: [59654] UL Solution Center shows when expanded menu item is clicked
	Given I login as the administrator
	Then The home screen should load
	Given I expand the Navigation Menu
	Then the Navigation Menu should be expanded
	Given I click the UL Solution Center link in the expanded navigation side menu
	Then I confirm that the UL Solution Center page is loaded

@ScenarioId:1098
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

@ScenarioId:1104
Scenario: [81288] UL Solution Center shows correct entries - ECOLOGO section
	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	Given I click the UL Solution Center icon in the QuickLinks Pane
	Then I confirm that the UL Solution Center page is loaded
	Then I Confirm the ECOLOGO heading is displayed next to an icon
	And I Confirm the information statement for section: ECOLOGO reads: ECOLOGO Certified products, services and packaging are certified for reduced environmental impact. ECOLOGO Certifications are voluntary, multi-attribute, lifecycle based environmental certifications that indicate a product has undergone rigorous scientific testing, exhaustive auditing, or both, to prove its compliance with stringent, third-party, environmental performance standards.
	And I confirm the Learn More button is displayed for section: ECOLOGO
	Given I click the Learn More button for section: ECOLOGO
	#Given I switch to the tab: (.*)
	Given I switch to the ECOLOGO information tab
	And I close the window that opened
	Then I confirm that the UL Solution Center page is loaded

@ScenarioId:1099
Scenario: [59657] UL Solution Center shows correct entries - Prospector section
	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	Given I click the UL Solution Center icon in the QuickLinks Pane
	Then I confirm that the UL Solution Center page is loaded
	Then I Confirm the Prospector heading is displayed next to an icon
	And I Confirm the information statement for section: Prospector reads: Spanning 10 industries, UL's Prospector offers accurate, reliable technical information for hundreds of thousands of products from suppliers around the world.
	And I confirm the Learn More button is displayed for section: Prospector
	Given I click the Learn More button for section: Prospector
	# NB this is region sensitive "/eu" in Europe. "/na" in U.S.
	Given I switch to the Prospector information tab
	And I close the window that opened
	Then I confirm that the UL Solution Center page is loaded

@ScenarioId:1100
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

@ScenarioId:1101
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
@ScenarioId:1102
Scenario: [59660] UL Solution Center shows correct entries - UL Secure Connect section
	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	Given I click the UL Solution Center icon in the QuickLinks Pane
	Then I confirm that the UL Solution Center page is loaded
	Then I Confirm the UL Secure Connect (ULSC) heading is displayed next to an icon
	And I Confirm the information statement for section: UL Secure Connect (ULSC) reads: Get additional insights from your data with UL Secure Connect, a data generation tool. ULSC allows you to generate additional valuable data, and receive that data in an editable format which you can analyze and import into your internal systems.
	And I confirm the Learn More button is displayed for section: UL Secure Connect (ULSC)
	Given I click the Learn More button for section: UL Secure Connect (ULSC)
	Given I switch to the UL Secure Connect (ULSC) information tab
	And I close the window that opened
	Then I confirm that the UL Solution Center page is loaded

@ScenarioId:1103
Scenario: [59661] UL Solution Center shows correct entries - ULGHS section
	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	Given I click the UL Solution Center icon in the QuickLinks Pane
	Then I confirm that the UL Solution Center page is loaded
	Then I Confirm the ULGHS heading is displayed next to an icon
	And I Confirm the information statement for section: ULGHS reads: ULGHS is a right-sized SDS authoring tool for small to mid-sized companies that produce products that contain chemicals. Powered by UL WERCSmart, ULGHS – SDS Authoring Tool is a first of its kind, automated GHS-compliant SDS authoring solution.
	And I confirm the Learn More button is displayed for section: ULGHS
	Given I click the Learn More button for section: ULGHS
	Given I switch to the ULGHS information tab
	Then I check that the current URL contains: https://msc.ul.com/en/products/ulghs

#And I close the window that opened
#Then I confirm that the UL Solution Center page is loaded
@ScenarioId:1096
Scenario: [102411] UL Solution Center shows correct entries - Navigator section
	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	Given I click the UL Solution Center icon in the QuickLinks Pane
	Then I confirm that the UL Solution Center page is loaded
	Then I Confirm the Navigator heading is displayed next to an icon
	And I Confirm the information statement for section: Navigator reads: Navigator highlights the main chemical regulatory requirements for over 50 countries around the world. These summaries compile the most important information all in one place, offering easy to understand explanations of complex topics, paired with links to laws and helpful resources. Summaries are authored and updated by our global regulatory specialists, whose primary responsibility is the monitoring and reporting of regulations in their given country.
	And I confirm the Learn More button is displayed for section: Navigator
	Given I click the Learn More button for section: Navigator
	Given I switch to the Navigator information tab
	Then I check that the current URL contains: https://msc.ul.com/en/products/navigator/
