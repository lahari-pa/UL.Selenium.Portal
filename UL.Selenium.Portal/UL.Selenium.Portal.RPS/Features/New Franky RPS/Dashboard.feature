@RPS
@Login
@run_HomeTab
@LandingPage
@Home
@Shared
@TopBar
@Navigation
@ProductInformation
@ProductLookUP
@Dashboard
@RecentActivities
@HelpAndSupport
@Cards
Feature: Dashboard

Scenario Outline: [169080] Dashboard page - layout
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Given I click the main tab: Program Health
	Then I confirm the Home tab has loaded
	Given I click the main tab: Dashboard
	And I confirm the active tab is: Dashboard
	Then I confirm the Dashboard tab has loaded
	Given I confirm the top menu bar is displayed with the logged in username
	And I confirm the navigation menu bar is displayed below the top bar
	And I confirm there are a total of <nWidgets> widgets displayed in a 2 x <nRows> grid
	Then I confirm the following listed Widgets are displayed: <ListedWidgets>
	Then I confirm there is no page footer shown

	Examples:
		| Scenario Name                      | Retailer | nWidgets | nRows | ListedWidgets                                                                                                                                                                                                |
		| [#169080a] Dashboard page - layout | RPS.SF   | 8        | 4     | RU Category by Supplier, RU Category by RU, Product Recertification Status, Product Status, Product Hold Status, Supplier Subscription Status, EPA/RCRA Waste Code Waste Code by RU Category, Bucket Code by RU|
#		| [#169080b] Dashboard page - layout | RPS.TG   | 9        | 5     | Generic Bucket Code by RU, EPA/RCRA Waste Code by RU Category, RU Category by Supplier, RU Category by RU, Product Recertification Status, Product Status, Product Hold Status, Supplier Subscription Status |

Scenario Outline: [169081] Dashboard - Supplier Subscription Status Chart
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the active tab is: <LandingTab>
	Given I click the main tab: Dashboard
	Then I confirm the Dashboard tab has loaded
	Then I confirm the following Widgets are displayed:
		| Widget                       |
		| Supplier Subscription Status |
	Then I Confirm that the Graph for the widget: Supplier Subscription Status is a: Pie Chart
	Then In the Supplier Subscription Status widget, I confirm that a legend is not shown
	Then I call Shared Step 70474 (Verify Chart functionality) for widget: Supplier Subscription Status
	Then I call Shared Step 70484 (Chart Drill-down Export) for widget: Supplier Subscription Status
	And I call Shared Step 106194 (RPS Sign out)

	Examples:
		| Scenario Name                                             | Retailer | LandingTab           |
		| [#169081a] Dashboard - Supplier Subscription Status Chart | RPS.LW   | LWLandingtab         |
		| [#169081b] Dashboard - Supplier Subscription Status Chart | RPS.CV   | Program Health       |
#		| [#169081c] Dashboard - Supplier Subscription Status Chart | RPS.WM   | Program Health       |
#		| [#169081d] Dashboard - Supplier Subscription Status Chart | RPS.HD   | Program Health       |
		| [#169081e] Dashboard - Supplier Subscription Status Chart | RPS.SF   | Program Health       |
#		| [#169081f] Dashboard - Supplier Subscription Status Chart | RPS.PX   | Program Health       |
		| [#169081g] Dashboard - Supplier Subscription Status Chart | RPS.TG   | Product Lookup       |
		| [#169081h] Dashboard - Supplier Subscription Status Chart | RPS.CT   | Program Health       |

Scenario Outline: [169331] Product Lookup - Breadcrumbs - multiple selection and reset
	# Only run this test in RPS - Franky
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the active tab is: <LandingTab>
	Given I click the main tab: Product Lookup
	Then I confirm the Product Lookup tab has loaded
	Given In the product lookup page, I click the More Filters Button
#	Given In the product lookup page, I select the option: Recommended Usage Category Code from the status drop down menu
#	Given In the product lookup page, I select the option: Stationery from the parameters drop down menu
#	Given In the product lookup page, I select the option: Health and Beauty from the parameters drop down menu
	Given In the product lookup page, I select the option: Packaging Type from the status drop down menu
	Given In the product lookup page, I select the option: Plastic Container from the parameters drop down menu
	Given In the product lookup page, I select the option: Glass Container from the parameters drop down menu
	Given In the product lookup page More Filters Popup, I Click the the Apply Filter Button
	Then I confirm that the Lookup Page bread crumb area contains the label: Packaging Type: Plastic Container
	Then I confirm that the Lookup Page bread crumb area contains the label: Packaging Type: Glass Container
#	Then I confirm that the Lookup Page bread crumb area contains the label: Recommended Usage Category Code: Stationery
#	Then I confirm that the Lookup Page bread crumb area contains the label: Recommended Usage Category Code: Health and Beauty
	Then In the product lookup Page, In the Products table I click the Reset Button
	Given In the product lookup page, I click the More Filters Button
	Given In the product lookup page, I select the option: Packaging Type from the status drop down menu
	Given In the product lookup page, I select the option: Plastic Container from the parameters drop down menu
	Given In the product lookup page, I select the option: Glass Container from the parameters drop down menu
	Given In the product lookup page, I select the option: Metal Container from the parameters drop down menu
	Given In the product lookup page More Filters Popup, I Click the the Apply Filter Button
	And In the product lookup Page, In the Products table I click the Reset Button
	And I call Shared Step 106194 (RPS Sign out)

	Examples:
		| Scenario Name                                                          | Retailer | LandingTab               |
		| [#169331a] Product Lookup - Breadcrumbs - multiple selection and reset | RPS.LW   | LWLandingtab             |
		| [#169331b] Product Lookup - Breadcrumbs - multiple selection and reset | RPS.CV   | Program Health           |
#		| [#169331c] Product Lookup - Breadcrumbs - multiple selection and reset | RPS.WM   | Program Health           |
#		| [#169331d] Product Lookup - Breadcrumbs - multiple selection and reset | RPS.HD   | Program Health           |
		| [#169331e] Product Lookup - Breadcrumbs - multiple selection and reset | RPS.SF   | Program Health           |
#		| [#169331f] Product Lookup - Breadcrumbs - multiple selection and reset | RPS.PX   | Program Health           |
		| [#169331g] Product Lookup - Breadcrumbs - multiple selection and reset | RPS.TG   | Product Lookup           |
		| [#169331h] Product Lookup - Breadcrumbs - multiple selection and reset | RPS.CT   | Program Health           |

Scenario Outline: [169082] Dashboard - Supplier Subscription Status Chart data
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the active tab is: <LandingTab>
	Given I click the main tab: Dashboard
	Then I confirm the Dashboard tab has loaded
	Then I confirm the following Widgets are displayed:
		| Widget                       |
		| Supplier Subscription Status |
	Then For the Supplier Subscription Status widget, I save the current titles as: SupplierSubscriptionStatusTitles1 and check that when I click on the section: Subscribed Suppliers that the supplier list view is seen.
	Then I Check that for the widget Supplier Subscription Status, the Supplier List shows the Following headings:
		| Headers  |
		| Supplier |
		| Contact  |
		| E-Mail   |
	#Below step could be useful how to have a seperate color in the report.
	Then END OF AUTOMATION: TEST CASE NEEDS MANUAL COMPLETION
	Given I call Shared Step 106194 (RPS Sign out)

	Examples:
		| Scenario Name                                                  | Retailer | LandingTab               |
		| [#169082a] Dashboard - Supplier Subscription Status Chart data | RPS.LW   | LWLandingtab             |
		| [#169082b] Dashboard - Supplier Subscription Status Chart data | RPS.CV   | Program Health           |
#		| [#169082c] Dashboard - Supplier Subscription Status Chart data | RPS.WM   | Program Health           |
#		| [#169082d] Dashboard - Supplier Subscription Status Chart data | RPS.HD   | Program Health           |
		| [#169082e] Dashboard - Supplier Subscription Status Chart data | RPS.SF   | Program Health           |
#		| [#169082f] Dashboard - Supplier Subscription Status Chart data | RPS.PX   | Program Health           |
		| [#169082g] Dashboard - Supplier Subscription Status Chart data | RPS.TG   | Product Lookup           |
		| [#169082h] Dashboard - Supplier Subscription Status Chart data | RPS.CT   | Program Health           |

Scenario: [169341] Product Lookup - UPC based - View Data does show for products in NEW Status
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the active tab is: <LandingTab>
	Given I click the main tab: Product Lookup
	Then I confirm the Product Lookup tab has loaded
	Then I call Shared Step 163728 (More Filters - Select Status - Apply - Confirm Actions column does show View Data) on page: Product Lookup for status: New
	And I call Shared Step 106194 (RPS Sign out)

	Examples:
		| Scenario Name                                                                          | Retailer | LandingTab               |
		| [#169341a] Product Lookup - UPC based - View Data does show for products in NEW Status | RPS.LW   | LWLandingtab             |
		| [#169341b] Product Lookup - UPC based - View Data does show for products in NEW Status | RPS.CV   | Program Health           |
#		| [#169341c] Product Lookup - UPC based - View Data does show for products in NEW Status | RPS.WM   | Program Health           |
#		| [#169341d] Product Lookup - UPC based - View Data does show for products in NEW Status | RPS.HD   | Program Health           |
		| [#169341e] Product Lookup - UPC based - View Data does show for products in NEW Status | RPS.SF   | Program Health           |
#		| [#169341f] Product Lookup - UPC based - View Data does show for products in NEW Status | RPS.PX   | Program Health           |
		| [#169341g] Product Lookup - UPC based - View Data does show for products in NEW Status | RPS.TG   | Product Lookup           |
		| [#169341h] Product Lookup - UPC based - View Data does show for products in NEW Status | RPS.CT   | Program Health           |

Scenario Outline: [169083] Dashboard - Print functionality works with one chart
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the active tab is: <LandingTab>
	Given I click the main tab: Dashboard
	Then I confirm the Dashboard tab has loaded
	Then I click Accept all Cookies
	Then I save the current list of widgets to context as default
	Then I save the first widget containing a Bar Graph to context
	Then I call Shared Step 106605 (Dashboard - Remove Widget) for all widgets except the saved widget
	#Issue with automating the print dialogue
	#then Print Check: Last chart click the hamburger icon and click print chart. **Confirom print dialogue is open then close.**
	Then I Click the hamburger menu for the saved widget and select the option: Print chart
	Then I click the back button in the browser
	Then I click the back button in the browser
	Given I click the main tab: Dashboard
	Then I confirm the Dashboard tab has loaded
	Then I call Shared Step 54484 (Dashboard - Gauge - Reset Dashboard - confrim page refreshes)
	Then In the Dashboard page, I confirm all widgets are shown correctly in their order saved as default
	Given I call Shared Step 106194 (RPS Sign out)

	Examples:
		| Scenario Name                                                   | Retailer | LandingTab               |
		| [#169083a] Dashboard - Print functionality works with one chart | RPS.LW   | LWLandingtab             |
		| [#169083b] Dashboard - Print functionality works with one chart | RPS.CV   | Program Health           |
#		| [#169083c] Dashboard - Print functionality works with one chart | RPS.WM   | Program Health           |
#		| [#169083d] Dashboard - Print functionality works with one chart | RPS.HD   | Program Health           |
		| [#169083e] Dashboard - Print functionality works with one chart | RPS.SF   | Program Health           |
#		| [#169083f] Dashboard - Print functionality works with one chart | RPS.PX   | Program Health           |
		| [#169083g] Dashboard - Print functionality works with one chart | RPS.TG   | Product Lookup           |
		| [#169083h] Dashboard - Print functionality works with one chart | RPS.CT   | Program Health           |

Scenario Outline: [169084] Dashboard - Print functionality works on resized chart
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Given I click the main tab: Program Health
	Then I confirm the active tab is: Program Health
	Given I click the main tab: Dashboard
	Then I confirm the Dashboard tab has loaded
	Then I click Accept all Cookies
	Then I save the first widget containing a graph to context
	Then I use double arrow to resize the saved widget
	Then I Click the hamburger menu for the saved widget and select the option: Print chart
	Then I click the back button in the browser
	Then I confirm the active tab is: Program Health
	Given I click the main tab: Dashboard
	Then I confirm the Dashboard tab has loaded
	Then I call Shared Step 54484 (Dashboard - Gauge - Reset Dashboard - confrim page refreshes)
	Given I call Shared Step 106194 (RPS Sign out)

	Examples:
		| Scenario Name                                                     | Retailer |
		| [#169084a] Dashboard - Print functionality works on resized chart | RPS.LW   |
#		| [#169084b] Dashboard - Print functionality works on resized chart | RPS.CV   |
#		| [#169084c] Dashboard - Print functionality works on resized chart | RPS.WM   |
#		| [#169084d] Dashboard - Print functionality works on resized chart | RPS.HD   |
		| [#169084e] Dashboard - Print functionality works on resized chart | RPS.SF   |
#		| [#169084f] Dashboard - Print functionality works on resized chart | RPS.PX   |
		| [#169084g] Dashboard - Print functionality works on resized chart | RPS.TG   |
		| [#169084h] Dashboard - Print functionality works on resized chart | RPS.CT   |

Scenario Outline: [169085] Dashboard - Able to resize chart when there is only one
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the active tab is: <LandingTab>
	Given I click the main tab: Dashboard
	Then I confirm the Dashboard tab has loaded
	Then I click Accept all Cookies
	Then I save the first widget containing a Bar Graph to context
	Then I call Shared Step 106605 (Dashboard - Remove Widget) for all widgets except the saved widget
	Then I use double arrow to resize the saved widget
	Then I Click the hamburger menu for the saved widget and select the option: Print chart
	Then I click the back button in the browser
	Then I click the back button in the browser
	Then I confirm the active tab is: <LandingTab>
	Given I click the main tab: Dashboard
	Then I confirm the Dashboard tab has loaded
	Then I call Shared Step 54484 (Dashboard - Gauge - Reset Dashboard - confrim page refreshes)
	Given I call Shared Step 106194 (RPS Sign out)

	Examples:
		| Scenario Name                                                      | Retailer | LandingTab               |
		| [#169085a] Dashboard - Able to resize chart when there is only one | RPS.LW   | LWLandingtab             |
		| [#169085b] Dashboard - Able to resize chart when there is only one | RPS.CV   | Program Health           |
#		| [#169085c] Dashboard - Able to resize chart when there is only one | RPS.WM   | Program Health           |
#		| [#169085d] Dashboard - Able to resize chart when there is only one | RPS.HD   | Program Health           |
		| [#169085e] Dashboard - Able to resize chart when there is only one | RPS.SF   | Program Health           |
#		| [#169085f] Dashboard - Able to resize chart when there is only one | RPS.PX   | Program Health           |
		| [#169085g] Dashboard - Able to resize chart when there is only one | RPS.TG   | Product Lookup           |
		| [#169085h] Dashboard - Able to resize chart when there is only one | RPS.CT   | Program Health           |

Scenario Outline: [169086] Dashboard - Chart displays no information
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the active tab is: <LandingTab>
	Given I click the main tab: Dashboard
	Then I confirm the Dashboard tab has loaded
	Then I verify each widget diplays a chart of some type
	Given I call Shared Step 106194 (RPS Sign out)

	Examples:
		| Scenario Name                                        | Retailer | LandingTab               |
		| [#169086a] Dashboard - Chart displays no information | RPS.LW   | LWLandingtab             |
		| [#169086b] Dashboard - Chart displays no information | RPS.CV   | Program Health           |
#		| [#169086c] Dashboard - Chart displays no information | RPS.WM   | Program Health           |
#		| [#169086d] Dashboard - Chart displays no information | RPS.HD   | Program Health           |
		| [#169086e] Dashboard - Chart displays no information | RPS.SF   | Program Health           |
#		| [#169086f] Dashboard - Chart displays no information | RPS.PX   | Program Health           |
		| [#169086g] Dashboard - Chart displays no information | RPS.TG   | Product Lookup           |
		| [#169086h] Dashboard - Chart displays no information | RPS.CT   | Program Health           |

Scenario Outline: [169087] Dashboard - Changing Dashboard saves
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the active tab is: <LandingTab>
	Given I click the main tab: Dashboard
	Then I click Accept all Cookies
	Then I confirm the Dashboard tab has loaded
	Then I save the first widget containing a Bar Graph to context
	Then I call Shared Step 106605 (Dashboard - Remove Widget) for all widgets except the saved widget
	Then I use double arrow to resize the saved widget
	Then I save the current list of widgets to context as default
	Given I click the main tab: Product Lookup
	Then I confirm the Product Lookup tab has loaded
	Given I click the main tab: Dashboard
	Then I confirm the Dashboard tab has loaded
	Given I call Shared Step 106194 (RPS Sign out)
	Then I close the browser, all instances
	Then I open a new browser window
	Then I navigate to the RPS landing page
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Given I click the main tab: Dashboard
	Then I confirm the Dashboard tab has loaded
	Then In the Dashboard page, I confirm all widgets are shown correctly in their order saved as default
	Then I call Shared Step 54484 (Dashboard - Gauge - Reset Dashboard - confrim page refreshes)
	Given I call Shared Step 106194 (RPS Sign out)

	Examples:
		| Scenario Name                                   | Retailer | LandingTab               |
		| [#169087a] Dashboard - Changing Dashboard saves | RPS.LW   | LWLandingtab             |
		| [#169087b] Dashboard - Changing Dashboard saves | RPS.CV   | Program Health           |
#		| [#169087c] Dashboard - Changing Dashboard saves | RPS.WM   | Program Health           |
#		| [#169087d] Dashboard - Changing Dashboard saves | RPS.HD   | Program Health           |
		| [#169087e] Dashboard - Changing Dashboard saves | RPS.SF   | Program Health           |
#		| [#169087f] Dashboard - Changing Dashboard saves | RPS.PX   | Program Health           |
		| [#169087g] Dashboard - Changing Dashboard saves | RPS.TG   | Product Lookup           |
		| [#169087h] Dashboard - Changing Dashboard saves | RPS.CT   | Program Health           |

Scenario Outline: [169088] Dashboard - Export - Shows data for chart/graph shown
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the active tab is: <LandingTab>
	Given I click the main tab: Dashboard
	Then I confirm the Dashboard tab has loaded
	Then I save the first widget containing a graph to context
	Then I call Shared Step 70484 (Chart Drill-down Export) for the saved widget

	Examples:
		| Scenario Name                                                    | Retailer | LandingTab               |
		| [#169088a] Dashboard - Export - Shows data for chart/graph shown | RPS.LW   | LWLandingtab             |
		| [#169088b] Dashboard - Export - Shows data for chart/graph shown | RPS.CV   | Program Health           |
#		| [#169088c] Dashboard - Export - Shows data for chart/graph shown | RPS.WM   | Program Health           |
#		| [#169088d] Dashboard - Export - Shows data for chart/graph shown | RPS.HD   | Program Health           |
		| [#169088e] Dashboard - Export - Shows data for chart/graph shown | RPS.SF   | Program Health           |
#		| [#169088f] Dashboard - Export - Shows data for chart/graph shown | RPS.PX   | Program Health           |
		| [#169088g] Dashboard - Export - Shows data for chart/graph shown | RPS.TG   | Product Lookup           |
		| [#169088h] Dashboard - Export - Shows data for chart/graph shown | RPS.CT   | Program Health           |

Scenario Outline: [169089] Dashboard - URL does not show #
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the active tab is: <LandingTab>
	Given I click the main tab: Dashboard
	Then I confirm the Dashboard tab has loaded
	Then I save the first widget containing a graph to context
	Then For the widget saved to context, I save the current titles as: GenericBucketCodebyRU1 and check that when I click on the section: <first> that the titles change
	And For the saved widget I select the section with title: <first>
	Then I wait for the all widgets to finish loading
	Then I confirm Product content is displayed for the saved widget
	And For the saved widget, I click the back button in the Products List and confirm a graph is displayed
	Then In the URL area of the browser page, I confirm that the URL does not contain a #
	Given I call Shared Step 106194 (RPS Sign out)

	Examples:
		| Scenario Name                              | Retailer | LandingTab               |
		| [#169089a] Dashboard - URL does not show # | RPS.LW   | LWLandingtab             |
		| [#169089b] Dashboard - URL does not show # | RPS.CV   | Program Health           |
#		| [#169089c] Dashboard - URL does not show # | RPS.WM   | Program Health           |
#		| [#169089d] Dashboard - URL does not show # | RPS.HD   | Program Health           |
		| [#169089e] Dashboard - URL does not show # | RPS.SF   | Program Health           |
#		| [#169089f] Dashboard - URL does not show # | RPS.PX   | Program Health           |
		| [#169089g] Dashboard - URL does not show # | RPS.TG   | Product Lookup           |
		| [#169089h] Dashboard - URL does not show # | RPS.CT   | Program Health           |

Scenario Outline: [169090] Dashboard - Removing Widgets from the Dashboard and re-adding
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the active tab is: <LandingTab>
	Given I click the main tab: Dashboard
	Then I confirm the Dashboard tab has loaded
	Then I click Accept all Cookies
	Then I confirm the following Widgets are displayed:
		| Widget                                        |
		| Bucket Code by RU                             |
		| EPA/RCRA Waste Code Waste Code by RU Category |
		| RU Category by Supplier                       |
		| RU Category by RU                             |
		| Product Recertification Status                |
		| Product Status                                |
		| Product Hold Status                           |
		| Supplier Subscription Status                  |
	Then I call Shared Step 106605 (Dashboard - Remove Widget) for widget: Bucket Code by RU
	Then I call Shared Step 106623 (Dashboard - Gauge - Re-add removed widget) for widget: Bucket Code by RU
	Then I call Shared Step 106605 (Dashboard - Remove Widget) for widget: EPA/RCRA Waste Code Waste Code by RU Category
	Then I call Shared Step 106623 (Dashboard - Gauge - Re-add removed widget) for widget: EPA/RCRA Waste Code Waste Code by RU Category
	Then I call Shared Step 106605 (Dashboard - Remove Widget) for widget: RU Category by Supplier
	Then I call Shared Step 106623 (Dashboard - Gauge - Re-add removed widget) for widget: RU Category by Supplier
	Then I call Shared Step 106605 (Dashboard - Remove Widget) for widget: RU Category by RU
	Then I call Shared Step 106623 (Dashboard - Gauge - Re-add removed widget) for widget: RU Category by RU
	Then I call Shared Step 106605 (Dashboard - Remove Widget) for widget: Product Recertification Status
	Then I call Shared Step 106623 (Dashboard - Gauge - Re-add removed widget) for widget: Product Recertification Status
	Then I call Shared Step 106605 (Dashboard - Remove Widget) for widget: Product Status
	Then I call Shared Step 106623 (Dashboard - Gauge - Re-add removed widget) for widget: Product Status
	Then I call Shared Step 106605 (Dashboard - Remove Widget) for widget: Product Hold Status
	Then I call Shared Step 106623 (Dashboard - Gauge - Re-add removed widget) for widget: Product Hold Status
	Then I call Shared Step 106605 (Dashboard - Remove Widget) for widget: Supplier Subscription Status
	Then I call Shared Step 106623 (Dashboard - Gauge - Re-add removed widget) for widget: Supplier Subscription Status
	Then I call Shared Step 54484 (Dashboard - Gauge - Reset Dashboard - confrim page refreshes)
	Given I call Shared Step 106194 (RPS Sign out)

	Examples:
		| Scenario Name                                                            | Retailer | LandingTab     |
		| [#169090a] Dashboard - Removing Widgets from the Dashboard and re-adding | RPS.SF   | Program Health |
#		| [#169090b] Dashboard - Removing Widgets from the Dashboard and re-adding | RPS.TG   | Product Lookup |

Scenario Outline: [169091] Resetting the Dashboard
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the active tab is: <LandingTab>
	Given I click the main tab: Dashboard
	Then I confirm the Dashboard tab has loaded
	Then I click Accept all Cookies
	Then I confirm the following Widgets are displayed:
		| Widget                                        |
		| Bucket Code by RU                             |
		| EPA/RCRA Waste Code Waste Code by RU Category |
		| RU Category by Supplier                       |
		| RU Category by RU                             |
		| Product Recertification Status                |
		| Product Status                                |
		| Product Hold Status                           |
		| Supplier Subscription Status                  |
	Then In the Dashboard page, I confirm all widgets are shown correctly in their original order:
		| Widget                                        |
		| Bucket Code by RU                             |
		| EPA/RCRA Waste Code Waste Code by RU Category |
		| RU Category by Supplier                       |
		| RU Category by RU                             |
		| Product Recertification Status                |
		| Product Status                                |
		| Product Hold Status                           |
		| Supplier Subscription Status                  |
	Then I call Shared Step 106605 (Dashboard - Remove Widget) for widget: RU Category by Supplier
	Then I call Shared Step 106605 (Dashboard - Remove Widget) for widget: RU Category by RU
	Then I click the Gauge button in the navigation bar
	Then I confirm that the the options below the gauge icon are as follows:
		| Options                                  |
		| RU Category by Supplier                  |
		| RU Category by RU                        |             
		| Reset Dashboard                          |
		| Refresh All Widgets                      |
	Then I click the Gauge button in the navigation bar
	Then I call Shared Step 54484 (Dashboard - Gauge - Reset Dashboard - confrim page refreshes)
	Then In the Dashboard page, I confirm all widgets are shown correctly in their original order:
		| Widget                                        |
		| Bucket Code by RU                             |
		| EPA/RCRA Waste Code Waste Code by RU Category |
		| RU Category by Supplier                       |
		| RU Category by RU                             |
		| Product Recertification Status                |
		| Product Status                                |
		| Product Hold Status                           |
		| Supplier Subscription Status                  |
	Given I call Shared Step 106194 (RPS Sign out)

	Examples:
		| Scenario Name                      | Retailer | LandingTab     |
		| [#169091a] Resetting the Dashboard | RPS.SF   | Program Health           |
#		| [#169091b] Resetting the Dashboard | RPS.TG   | Product Lookup |

Scenario Outline: [169092] Dashboard - Product Recertification Status Chart
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the active tab is: <LandingTab>
	Given I click the main tab: Dashboard
	Then I confirm the Dashboard tab has loaded
	Then I confirm the following Widgets are displayed:
		| Widget                         |
		| Product Recertification Status |
	Then I Confirm that the Graph for the widget: Product Recertification Status is a: Pie Chart
#	Then In the Product Recertification Status widget, I confirm that a legend is shown
	Then I call Shared Step 54484 (Dashboard - Gauge - Reset Dashboard - confrim page refreshes)
	Then I call Shared Step 70474 (Verify Chart functionality) for widget: Product Recertification Status
	Then I call Shared Step 70484 (Chart Drill-down Export) for widget: Product Recertification Status
	Then I call Shared Step 108597 (Widget data view - Contact Supplier - email verification) for widget: Product Recertification Status
	And I call Shared Step 106194 (RPS Sign out)

	Examples:
		| Scenario Name                                               | Retailer | LandingTab               |
		| [#169092a] Dashboard - Product Recertification Status Chart | RPS.LW   | LWLandingtab             |
		| [#169092b] Dashboard - Product Recertification Status Chart | RPS.CV   | Program Health           |
#		| [#169092c] Dashboard - Product Recertification Status Chart | RPS.WM   | Program Health           |
#		| [#169092d] Dashboard - Product Recertification Status Chart | RPS.HD   | Program Health           |
		| [#169092e] Dashboard - Product Recertification Status Chart | RPS.SF   | Program Health           |
#		| [#169092f] Dashboard - Product Recertification Status Chart | RPS.PX   | Program Health           |
		| [#169092g] Dashboard - Product Recertification Status Chart | RPS.TG   | Product Lookup           |
		| [#169092h] Dashboard - Product Recertification Status Chart | RPS.CT   | Program Health           |

Scenario Outline: [169094] Dashboard- Product Recertification Status Chart - Drilled down - Contact Supplier
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the active tab is: <LandingTab>
	Given I click the main tab: Dashboard
	Then I confirm the Dashboard tab has loaded
	Then I confirm the following Widgets are displayed:
		| Widget                         |
		| Product Recertification Status |
	Then For the Product Recertification Status widget, I save the current titles as: ProductRecertificationStatusTitles1 and check that when I click on the section: <first> that the titles change
	And For the Widget: Product Recertification Status I select the section with title: <first>
	Then I wait for the all widgets to finish loading
	Then I confirm Product content is displayed for the widget: Product Recertification Status
	Then I Confirm that the Products List for the widget: Product Recertification Status contains the column headings:
		| Headings       |
		| Product Number |
		| Name           |
		| UPCs           |
	Then I Confirm that the Products list for the widget: Product Recertification Status contains 'Contact Supplier' in all rows
	#Then For the widget (.*) In the Products list, I click on the Contact Supplier Link for the Product <first>
	Then END OF AUTOMATION: TEST CASE NEEDS MANUAL COMPLETION. Message: Shared Step 109186 Cannot be automated, needs to be manually reviewed.
	Given I call Shared Step 106194 (RPS Sign out)

	Examples:
		| Scenario Name                                                                                | Retailer | LandingTab               |
		| [#169094a] Dashboard- Product Recertification Status Chart - Drilled down - Contact Supplier | RPS.LW   | LWLandingtab             |
		| [#169094b] Dashboard- Product Recertification Status Chart - Drilled down - Contact Supplier | RPS.CV   | Program Health           |
#		| [#169094c] Dashboard- Product Recertification Status Chart - Drilled down - Contact Supplier | RPS.HD   | Program Health           |
#		| [#169094d] Dashboard- Product Recertification Status Chart - Drilled down - Contact Supplier | RPS.TG   | Product Lookup           |

Scenario: [169342] Product Lookup - UPC based - View Data displays all non-new status products
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the active tab is: <LandingTab>
	Given I click the main tab: Product Lookup
	Then I confirm the Product Lookup tab has loaded
	Then I call Shared Step 163728 (More Filters - Select Status - Apply - Confirm Actions column does show View Data) on page: Product Lookup for status: Assigned
	Then I call Shared Step 163728 (More Filters - Select Status - Apply - Confirm Actions column does show View Data) on page: Product Lookup for status: Cancelled
	Then I call Shared Step 163728 (More Filters - Select Status - Apply - Confirm Actions column does show View Data) on page: Product Lookup for status: Pending
#	Then I call Shared Step 163728 (More Filters - Select Status - Apply - Confirm Actions column does show View Data) on page: Product Lookup for status: Recertification
#	Then I call Shared Step 163728 (More Filters - Select Status - Apply - Confirm Actions column does show View Data) on page: Product Lookup for status: Release for distribution
	And I call Shared Step 106194 (RPS Sign out)

	Examples:
		| Scenario Name                                                                          | Retailer | LandingTab               |
		| [#169342a] Product Lookup - UPC based - View Data displays all non-new status products | RPS.LW   | LWLandingtab             |
		| [#169342b] Product Lookup - UPC based - View Data displays all non-new status products | RPS.CV   | Program Health           |
#		| [#169342c] Product Lookup - UPC based - View Data displays all non-new status products | RPS.WM   | Program Health           |
#		| [#169342d] Product Lookup - UPC based - View Data displays all non-new status products | RPS.HD   | Program Health           |
		| [#169342e] Product Lookup - UPC based - View Data displays all non-new status products | RPS.SF   | Program Health           |
#		| [#169342f] Product Lookup - UPC based - View Data displays all non-new status products | RPS.PX   | Program Health           |
		| [#169342g] Product Lookup - UPC based - View Data displays all non-new status products | RPS.TG   | Product Lookup           |
		| [#169342h] Product Lookup - UPC based - View Data displays all non-new status products | RPS.CT   | Program Health           |

@ignore
# Unignore when Accepted status is reintroduced to Product Lookup Page
Scenario: [200568] Product Lookup - UPC based - View Data displays all Accepted  status products
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the active tab is: <LandingTab>
	Given I click the main tab: Product Lookup
	Then I confirm the Product Lookup tab has loaded
	Then I call Shared Step 163728 (More Filters - Select Status - Apply - Confirm Actions column does show View Data) on page: Product Lookup for status: Accepted
	And I call Shared Step 106194 (RPS Sign out)

	Examples:
		| Scenario Name                                                                            | Retailer | LandingTab               |
		| [#200568a] Product Lookup - UPC based - View Data displays all Accepted  status products | RPS.LW   | LWLandingtab             |
		| [#200568b] Product Lookup - UPC based - View Data displays all Accepted  status products | RPS.CV   | Program Health           |
#		| [#200568c] Product Lookup - UPC based - View Data displays all Accepted  status products | RPS.WM   | Program Health           |
#		| [#200568d] Product Lookup - UPC based - View Data displays all Accepted  status products | RPS.HD   | Program Health           |
		| [#200568e] Product Lookup - UPC based - View Data displays all Accepted  status products | RPS.SF   | Program Health           |
#		| [#200568f] Product Lookup - UPC based - View Data displays all Accepted  status products | RPS.PX   | Program Health           |
		| [#200568g] Product Lookup - UPC based - View Data displays all Accepted  status products | RPS.TG   | Product Lookup           |
		| [#200568h] Product Lookup - UPC based - View Data displays all Accepted  status products | RPS.CT   | Program Health           |

Scenario: [169389] Base Functionality - Product Lookup - UI - Product Grid
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the active tab is: <LandingTab>
	Given I click the main tab: Product Lookup
	And I confirm the active tab is: Product Lookup
	Then I confirm the Product Lookup tab has loaded
	Given In the product grid I confirm I see the following columns:
		| Column                          |
		| Product Info                    |
		| Recommended Usage Category Code |
		| Recommended Use                 |
		| Actions                         |
	Given In the Product Grid Product Info Column I see the following information:
		| Info          |
		| Product Name  |
		| UPC           |
		| WPS ID        |
		| Supplier Name |
	Given In the Product Grid the following field: Product Name has the following font color: black and the following font weight: bold
	Given In the Product Grid the following field: UPC has the following font color: black and the following font weight: bold
	Given In the Product Grid the following field: WPS ID has the following font color: black and the following font weight: normal
	Given In the Product Grid the following field: Supplier Name has the following font color: black and the following font weight: normal
	Given In the Product Grid the following field: Actions has the following font color: black and the following font weight: normal
	And I call Shared Step 106194 (RPS Sign out)

	Examples:
		| Scenario Name                                                      | Retailer | LandingTab               |
		| [#169389a] Base Functionality - Product Lookup - UI - Product Grid | RPS.CV   | Program Health           |

Scenario Outline: [169095] Dashboard - Supplier Subscription Status chart - Drilled down - Contact
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the active tab is: <LandingTab>
	Given I click the main tab: Dashboard
	Then I confirm the Dashboard tab has loaded
	Then I confirm the following Widgets are displayed:
		| Widget                       |
		| Supplier Subscription Status |
	Then For the Supplier Subscription Status widget, I save the current titles as: SupplierSubscriptionStatusTitles1 and check that when I click on the section: Subscribed Suppliers that the supplier list view is seen.
	Then I Check that for the widget Supplier Subscription Status, the Supplier List shows the Following headings:
		| Headers  |
		| Supplier |
		| Contact  |
		| E-Mail   |
	#Then For the widget (.*) In the Suppliers list, I click on the Contact Supplier Link for the Product <first>
	Then END OF AUTOMATION: TEST CASE NEEDS MANUAL COMPLETION. Message: Shared Step 109186 Cannot be automated, needs to be manually reviewed.

	Examples:
		| Scenario Name                                                                      | Retailer | LandingTab               |
		| [#169095a] Dashboard - Supplier Subscription Status chart - Drilled down - Contact | RPS.LW   | LWLandingtab             |
		| [#169095b] Dashboard - Supplier Subscription Status chart - Drilled down - Contact | RPS.CV   | Program Health           |
#		| [#169095c] Dashboard - Supplier Subscription Status chart - Drilled down - Contact | RPS.WM   | Program Health           |
#		| [#169095d] Dashboard - Supplier Subscription Status chart - Drilled down - Contact | RPS.HD   | Program Health           |
		| [#169095e] Dashboard - Supplier Subscription Status chart - Drilled down - Contact | RPS.SF   | Program Health           |
#		| [#169095f] Dashboard - Supplier Subscription Status chart - Drilled down - Contact | RPS.PX   | Program Health           |
		| [#169095g] Dashboard - Supplier Subscription Status chart - Drilled down - Contact | RPS.TG   | Product Lookup           |
		| [#169095h] Dashboard - Supplier Subscription Status chart - Drilled down - Contact | RPS.CT   | Program Health           |

@ignore
Scenario: [169621] Status Webviewer - UI - Page Layout
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: RPS.TG
	Given I call Shared Step 146631 (RPS - Go to Status Web Viewer)
	Given I confirm the following tabs are displayed:
		| Link              |
		| Program Health    |
		| Dashboard         |
		| Recent Activities |
		| Web Viewers       |
		| Product Lookup    |
		| Help & Support    |
	Given I call Shared Step 146363 (Status Webviewer - Page formatting)
	And I call Shared Step 106194 (RPS Sign out)

Scenario Outline: [169355] Dashboard - Supplier Subscription Status chart - Drilled down - Contact
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the active tab is: <LandingTab>
	Given I click the main tab: Dashboard
	Then I confirm the Dashboard tab has loaded
	Then I confirm the following Widgets are displayed:
		| Widget              |
		| Product Hold Status |
	And For the Widget: Product Hold Status I select the section with title: <first>
	And For the Widget: Product Hold Status I select the section with title: <first>
	Then I Check that for the widget Product Hold Status, the Product List shows the Following headings:
		| Headers        |
		| Product Number |
		| Name           |
		| UPCs           |
	Then I Confirm that the Products list for the widget: Product Hold Status contains 'Contact Supplier' in all rows
	Then END OF AUTOMATION: TEST CASE NEEDS MANUAL COMPLETION. Message: Shared Step 109186 Cannot be automated, needs to be manually reviewed.

	Examples:
		| Scenario Name                                                                       | Retailer | LandingTab               |
		| [#169355a] Dashboard - Product Hold Status  chart - Drilled down - Contact Supplier | RPS.LW   | LWLandingtab             |
		| [#169355b] Dashboard - Product Hold Status  chart - Drilled down - Contact Supplier | RPS.CV   | Program Health           |
#		| [#169355c] Dashboard - Product Hold Status  chart - Drilled down - Contact Supplier | RPS.WM   | Program Health           |
#		| [#169355d] Dashboard - Product Hold Status  chart - Drilled down - Contact Supplier | RPS.HD   | Program Health           |
		| [#169355e] Dashboard - Product Hold Status  chart - Drilled down - Contact Supplier | RPS.SF   | Program Health           |
#		| [#169355f] Dashboard - Product Hold Status  chart - Drilled down - Contact Supplier | RPS.PX   | Program Health           |
		| [#169355g] Dashboard - Product Hold Status  chart - Drilled down - Contact Supplier | RPS.TG   | Product Lookup           |
		| [#169355h] Dashboard - Product Hold Status  chart - Drilled down - Contact Supplier | RPS.CT   | Program Health           |

Scenario: [169519] Logistics Webviewer - UI - Page Layout
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer> 
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Given  I confirm the following tabs are displayed:
		| Link              |
		| Program Health    |
		| Dashboard         |
		| Recent Activities |
		| Web Viewers       |
		| Product Lookup    |
		| Help & Support    |
	Given I call Shared Step 153955 (Logistics Webviewer - Page formatting)
	And I call Shared Step 106194 (RPS Sign out)

		Examples:
		| Scenario Name                                     | Retailer | Page             | IsWebviewer |
		| [#169519a] Logistics Webviewer - UI - Page Layout | RPS.TG   | Target_store     | Yes         |
		| [#169519b] Logistics Webviewer - UI - Page Layout | RPS.TG   | Target_status    | Yes         |
		| [#169519c] Logistics Webviewer - UI - Page Layout | RPS.TG   | Target_HQ        | Yes         |
#		| [#169519d] Logistics Webviewer - UI - Page Layout | RPS.SF   | SmartFinal_Store | Yes         |
		| [#169519e] Logistics Webviewer - UI - Page Layout | RPS.LW   | Lowes_store      | Yes         |
 

@tfs_design
Scenario: [169569] Logistics Web Viewer - View Data  - Transportation - confirm fields shown (1 table format)
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: RPS.TG
	Given I call Shared Step 153163 (RPS - Go to Logistics/Store Web Viewer): Target_store
	Given  I confirm the following tabs are displayed:
		| Link              |
		| Program Health    |
		| Dashboard         |
		| Recent Activities |
		| Web Viewers       |
		| Product Lookup    |
		| Help & Support    |
	Then I Click the Row actions: View Data for the first product in the Products Grid
	Then I wait for the Product Information Popup to load
	Then I Confirm that Product Information pop up is shown
	Then I Close the Product Information Popup
	And I call Shared Step 106194 (RPS Sign out)

Scenario Outline: [169398] Dashboard - RCRA by RU Category Chart
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the active tab is: <LandingTab>
	Given I click the main tab: Dashboard
	Then I confirm the Dashboard tab has loaded
	Then I confirm the following Widgets are displayed:
		| Widget                              |
		| RCRA(EPA) Waste Code by RU Category |
	Then I Confirm that the Graph for the widget: RCRA(EPA) Waste Code by RU Category is a: Bar Graph
	Then In the RCRA(EPA) Waste Code by RU Category widget, I confirm that a legend is not shown
	Given I call Shared Step 106194 (RPS Sign out)

	Examples:
		| Scenario Name                                    | Retailer | LandingTab          |
		| [#169398a] Dashboard - RCRA by RU Category Chart | RPS.LW   | LWLandingtab        |
#		| [#169398b] Dashboard - RCRA by RU Category Chart | RPS.WM   | Program Health      |

Scenario Outline: [169399] Dashboard - RCRA by RU Category Chart - Drilled down - PRODUCT INFORMATION
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the active tab is: <LandingTab>
	Given I click the main tab: Dashboard
	Then I confirm the Dashboard tab has loaded
	Then I confirm the following Widgets are displayed:
		| Widget              |
		| EPA/RCRA Waste Code by RU Category |
	Then For the EPA/RCRA Waste Code by RU Category widget, I save the current titles as: RCRAByRUCategoryTitles1 and check that when I click on the section: <first> that the titles change
	Then For the EPA/RCRA Waste Code by RU Category widget, I save the current titles as: RCRAByRUCategoryTitles2 and check that when I click on the section: <first> that the products data view is seen.
	Then I open the Product Information popup for products in the Product list of widget: EPA/RCRA Waste Code by RU Category until one has enough data
	Then I call Shared Step 109167 (Product Information pop up - layout verification)
	Then I call Shared Step 109168 (Product Information pop up - Expand Product Details - confirm rows)
	Then I call Shared Step 109169 (Product Information pop up - Expand Transportation - confirm rows)
	Then I call Shared Step 109170 (Product Information pop up - Expand Storage - confirm rows)
	Then I call Shared Step 109171 (Product Information pop up - Expand Battery - confirm rows)
	Then I call Shared Step 109172 (Product information pop up - Only 1 section expands at a time)

	Examples:
		| Scenario Name                                                                         | Retailer | LandingTab |
		| [#169399a] Dashboard - RCRA by RU Category Chart - Drilled down - PRODUCT INFORMATION | RPS.LW   | LWLandingtab        |
#		| [#169399b] Dashboard - RCRA by RU Category Chart - Drilled down - PRODUCT INFORMATION | RPS.WM   | Program Health      |

Scenario Outline: [169107] Recent Activities - Confirm Most Recent Order
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the active tab is: <LandingTab>
	Given I click the main tab: Recent Activities
	And I confirm the active tab is: Recent Activities
	Then I confirm the Recent Activities tab has loaded
	Given In the Recent Activity Product table  - I confirm the Most Recent Activity column displays in date order, newest first
	And I call Shared Step 106194 (RPS Sign out)

	Examples:
		| Scenario Name                                            | Retailer | LandingTab               |
		| [#169107a] Recent Activities - Confirm Most Recent Order | RPS.LW   | LWLandingtab             |
		| [#169107b] Recent Activities - Confirm Most Recent Order | RPS.CV   | Program Health           |
#		| [#169107c] Recent Activities - Confirm Most Recent Order | RPS.WM   | Program Health           |
#		| [#169107d] Recent Activities - Confirm Most Recent Order | RPS.HD   | Program Health           |
		| [#169107e] Recent Activities - Confirm Most Recent Order | RPS.SF   | Program Health           |
#		| [#169107f] Recent Activities - Confirm Most Recent Order | RPS.PX   | Program Health           |
		| [#169107g] Recent Activities - Confirm Most Recent Order | RPS.TG   | Product Lookup           |
		| [#169107h] Recent Activities - Confirm Most Recent Order | RPS.CT   | Program Health           |

Scenario Outline: [169228] Recent Activities - UPC based - View Data does not show for products in NEW Status
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the active tab is: <LandingTab>
	Given I click the main tab: Recent Activities
	Then I confirm the Recent Activities tab has loaded
	Then I call Shared Step 106901 (More Filters - Select Status - Apply - Confirm Actions column does NOT show View Data) for status: New
	And I call Shared Step 106194 (RPS Sign out)

	Examples:
		| Scenario Name                                                                                 | Retailer | LandingTab               |
		| [#169228a] Recent Activities - UPC based - View Data does not show for products in NEW Status | RPS.LW   | LWLandingtab             |
		| [#169228b] Recent Activities - UPC based - View Data does not show for products in NEW Status | RPS.CV   | Program Health           |
#		| [#169228c] Recent Activities - UPC based - View Data does not show for products in NEW Status | RPS.WM   | Program Health           |
#		| [#169228d] Recent Activities - UPC based - View Data does not show for products in NEW Status | RPS.HD   | Program Health           |
#		| [#169228f] Recent Activities - UPC based - View Data does not show for products in NEW Status | RPS.PX   | Program Health           |
		| [#169228g] Recent Activities - UPC based - View Data does not show for products in NEW Status | RPS.TG   | Product Lookup           |
		| [#169228h] Recent Activities - UPC based - View Data does not show for products in NEW Status | RPS.CT   | Program Health           |

Scenario Outline: [169229] Recent Activities - UPC based - View Data displays all non-new status products
#	Commented lines are for statuses currently not represented but may be re-represented
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the active tab is: <LandingTab>
	Given I click the main tab: Recent Activities
	Then I confirm the Recent Activities tab has loaded
	Then I call Shared Step 163728 (More Filters - Select Status - Apply - Confirm Actions column does show View Data) on page: Recent Activities for status: Accepted
	Then I call Shared Step 163728 (More Filters - Select Status - Apply - Confirm Actions column does show View Data) on page: Recent Activities for status: Assigned
	Then I call Shared Step 163728 (More Filters - Select Status - Apply - Confirm Actions column does show View Data) on page: Recent Activities for status: Cancelled
#   Then I call Shared Step 163728 (More Filters - Select Status - Apply - Confirm Actions column does show View Data) on page: Recent Activities for status: Hold
#	Then I call Shared Step 163728 (More Filters - Select Status - Apply - Confirm Actions column does show View Data) on page: Recent Activities for status: Recertification
	Then I call Shared Step 163728 (More Filters - Select Status - Apply - Confirm Actions column does show View Data) on page: Recent Activities for status: Release for distribution
#	Then I call Shared Step 163728 (More Filters - Select Status - Apply - Confirm Actions column does show View Data) on page: Recent Activities for status: Submitted
	And I call Shared Step 106194 (RPS Sign out)

	Examples:
		| Scenario Name                                                                             | Retailer | LandingTab               |
		| [#169229a] Recent Activities - UPC based - View Data displays all non-new status products | RPS.LW   | LWLandingtab             |
		| [#169229b] Recent Activities - UPC based - View Data displays all non-new status products | RPS.CV   | Program Health           |
#		| [#169229c] Recent Activities - UPC based - View Data displays all non-new status products | RPS.WM   | Program Health           |
#		| [#169229d] Recent Activities - UPC based - View Data displays all non-new status products | RPS.HD   | Program Health           |
		| [#169229e] Recent Activities - UPC based - View Data displays all non-new status products | RPS.SF   | Program Health           |
#		| [#169229f] Recent Activities - UPC based - View Data displays all non-new status products | RPS.PX   | Program Health           |
		| [#169229g] Recent Activities - UPC based - View Data displays all non-new status products | RPS.TG   | Product Lookup           |
#		| [#169229h] Recent Activities - UPC based - View Data displays all non-new status products | RPS.CT   | Program Health           |

Scenario Outline: [169334] Select Columns -  Add Column
	#Do not run in Azure environment
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the active tab is: <LandingTab>
	Given I click the main tab: Product Lookup
	Then I confirm the Product Lookup tab has loaded
	Then I call Shared Step 151361 (Product Lookup - Select Columns - Add new Column to pop up - Click Apply) category: General Filters, filter: UPC Number
	Then I confirm the Product Lookup page refreshes
    Then I confirm the column name I selected and saved as: UPC Number is displayed next to the Actions column
	And I call Shared Step 106194 (RPS Sign out)

	Examples:
		| Scenario Name                           | Retailer | LandingTab               |
		| [#169334a] Select Columns -  Add Column | RPS.LW   | LWLandingtab             |
		| [#169334b] Select Columns -  Add Column | RPS.CV   | Program Health           |
#		| [#169334c] Select Columns -  Add Column | RPS.WM   | Program Health           |
#		| [#169334d] Select Columns -  Add Column | RPS.HD   | Program Health           |
		| [#169334e] Select Columns -  Add Column | RPS.SF   | Program Health           |
#		| [#169334f] Select Columns -  Add Column | RPS.PX   | Program Health           |
#		| [#169334g] Select Columns -  Add Column | RPS.TG   | Product Lookup           |
#		| [#169334h] Select Columns -  Add Column | RPS.CT   | Program Health           |

Scenario Outline: [169333] Select Columns -  Pop up layout
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the active tab is: <LandingTab>
	Given I click the main tab: Product Lookup
	Then I confirm the Product Lookup tab has loaded
	Then I confirm there is a table graphic next to the Select Columns button
	Then In the product lookup Page, In the Products table I click the Select Columns Button
	Then I confirm the Column Selector popup is shown
	Then I confirm the Column Selector popup displays the following title: Column Editor
	Then I confirm the Column Selector popup displays an x icon in the top right corner
	Then I confirm the Column Selector popup displays a column selector list
	Then I confirm the Column Selector popup displays 1 or more entries
	Then I confirm the Column Selector popup displays a hamburger icon next to each entry
	Then I confirm the Column Selector popup displays an x icon next to each entry
	Then I confirm the Column Selector popup displays the following buttons:
		| Button |
		| Close  |
		| Apply  |
	Then In the Column Selector popup I click close
	And I call Shared Step 106194 (RPS Sign out)

	Examples:
		| Scenario Name                              | Retailer | LandingTab               |
		| [#169333a] Select Columns -  Pop up layout | RPS.LW   | LWLandingtab             |
		| [#169333b] Select Columns -  Pop up layout | RPS.CV   | Program Health           |
#		| [#169333c] Select Columns -  Pop up layout | RPS.WM   | Program Health           |
#		| [#169333d] Select Columns -  Pop up layout | RPS.HD   | Program Health           |
		| [#169333e] Select Columns -  Pop up layout | RPS.SF   | Program Health           |
#		| [#169333f] Select Columns -  Pop up layout | RPS.PX   | Program Health           |
		| [#169333g] Select Columns -  Pop up layout | RPS.TG   | Product Lookup           |
		| [#169333h] Select Columns -  Pop up layout | RPS.CT   | Program Health           |

Scenario Outline: [169108] Recent Activities - Most Recent Activity Column shows date only (not time)
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the active tab is: <LandingTab>
	Given I click the main tab: Recent Activities
	Then I confirm the Recent Activities tab has loaded
	Then I confirm in the Recent Activities page the product grid Most Recent Activity column displays the following format: yyyy-mm-dd

	Examples:
		| Scenario Name                                                                         | Retailer | LandingTab               |
		| [#169108a] Recent Activities - Most Recent Activity Column shows date only (not time) | RPS.LW   | LWLandingtab             |
		| [#169108b] Recent Activities - Most Recent Activity Column shows date only (not time) | RPS.CV   | Program Health           |
#		| [#169108c] Recent Activities - Most Recent Activity Column shows date only (not time) | RPS.WM   | Program Health           |
#		| [#169108d] Recent Activities - Most Recent Activity Column shows date only (not time) | RPS.HD   | Program Health           |
		| [#169108e] Recent Activities - Most Recent Activity Column shows date only (not time) | RPS.SF   | Program Health           |
#		| [#169108f] Recent Activities - Most Recent Activity Column shows date only (not time) | RPS.PX   | Program Health           |
		| [#169108g] Recent Activities - Most Recent Activity Column shows date only (not time) | RPS.TG   | Product Lookup           |
		| [#169108h] Recent Activities - Most Recent Activity Column shows date only (not time) | RPS.CT   | Program Health           |

Scenario Outline: [169336] Select Columns -  Add Column - smart search
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the active tab is: <LandingTab>
	Given I click the main tab: Product Lookup
	Then I confirm the Product Lookup tab has loaded
	Then In the product lookup Page, In the Products table I click the Select Columns Button
	Then I confirm the Column Selector popup is shown
	Then I click the Add Column button in the Column Selector popup
	Then I confirm I see a new row at the bottom of the Column Selector popup
	Then I click on the new row at the bottom of the Column Selector popup
	Then I confirm I see a list of available columns in the dropdown selector in Column Selector popup
	Then I type the following into a textfield for the new row at the bottom of the Column Selector popup: Pac
	Then I confirm I see a list of available columns in the dropdown selector in Column Selector popup that contain the following text: Pac
	Then I select the following available column in the dropdown selector in Column Selector popup: Packaging Type and save as: columnName169339
	Given I click the Apply button in the Selector Column popup
	Then I confirm the column name I selected and saved as: columnName169339 is displayed next to the Actions column
	And I call Shared Step 106194 (RPS Sign out)

	Examples:
		| Scenario Name                                          | Retailer | LandingTab               |
		| [#169336a] Select Columns -  Add Column - smart search | RPS.LW   | LWLandingtab             |
		| [#169336b] Select Columns -  Add Column - smart search | RPS.CV   | Program Health           |
#		| [#169336c] Select Columns -  Add Column - smart search | RPS.WM   | Program Health           |
#		| [#169336d] Select Columns -  Add Column - smart search | RPS.HD   | Program Health           |
		| [#169336e] Select Columns -  Add Column - smart search | RPS.SF   | Program Health           |
#		| [#169336f] Select Columns -  Add Column - smart search | RPS.PX   | Program Health           |
		| [#169336g] Select Columns -  Add Column - smart search | RPS.TG   | Product Lookup           |
		| [#169336h] Select Columns -  Add Column - smart search | RPS.CT   | Program Health           |

Scenario Outline: [169337] Select Columns -  Make changes, Close (not Apply)
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the active tab is: <LandingTab>
	Given I click the main tab: Product Lookup
	Then I confirm the Product Lookup tab has loaded
	Then I call Shared Step 148760 (Product Lookup - Select Columns - Add new Column to pop up - Do not click Apply) category: General Filters, filter: UPC Number
	Given I click the Close button in the Selector Column popup
	Then I confirm the Column Selector popup is not shown
	Then I confirm the column name I selected and saved as: UPC Number is not displayed
	And I call Shared Step 106194 (RPS Sign out)

	Examples:
		| Scenario Name                                                | Retailer | LandingTab               |
		| [#169337a] Select Columns -  Make changes, Close (not Apply) | RPS.LW   | LWLandingtab             |
		| [#169337b] Select Columns -  Make changes, Close (not Apply) | RPS.CV   | Program Health           |
#		| [#169337c] Select Columns -  Make changes, Close (not Apply) | RPS.WM   | Program Health           |
#		| [#169337d] Select Columns -  Make changes, Close (not Apply) | RPS.HD   | Program Health           |
		| [#169337e] Select Columns -  Make changes, Close (not Apply) | RPS.SF   | Program Health           |
#		| [#169337f] Select Columns -  Make changes, Close (not Apply) | RPS.PX   | Program Health           |
		| [#169337g] Select Columns -  Make changes, Close (not Apply) | RPS.TG   | Product Lookup           |
		| [#169337h] Select Columns -  Make changes, Close (not Apply) | RPS.CT   | Program Health           |

@ignore
Scenario Outline: [169567] Logistics Web Viewer - Breadcrumbs - multiple selection and reset
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the active tab is: <LandingTab>
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Given In the recent activities page, I take note of the number of products in the footer area and save as: TestCase169567
	Given I call Shared Step 153326 (RPS & WV > More Filters > Select Multiple (RUCC and RU))
	Given In the Recent Activites page, I confirm I see the breadcrumbs area under the search field
	Then In the recent activities Page, In the Products table I click the Reset Button
	Given In the Recent Activites page, I confirm I do not see the breadcrumbs area under the search field
	Given I call Shared Step 153337 (RPS & WV > More Filters > Packaging type - select multiple)
	Given In the Recent Activites page, I confirm I see the breadcrumbs area under the search field
	Then I confirm that the Lookup Page bread crumb area contains the label: Packaging Type: Clay-Coated News Board
	Then I confirm that the Lookup Page bread crumb area contains the label: Packaging Type: Metal Container
	Then I confirm that the Lookup Page bread crumb area contains the label: Packaging Type: Glass Container
	Then In the recent activities Page, In the Products table I click the Reset Button
	Given In the Recent Activites page, I confirm I do not see the breadcrumbs area under the search field
	Given In the recent activites page, I check if the number of products in the footer area matches amount saved as: TestCase169567

	Examples:
		| Scenario Name                                     | Retailer | Page             | IsWebviewer | LandingTab              |
		| [#169567a] Products Card - Any Page - Total Shown | RPS.TG   | Target_store     | Yes         | Product Lookup          |
		| [#169567b] Products Card - Any Page - Total Shown | RPS.TG   | Target_HQ        | Yes         | Product Lookup          |
		| [#169567c] Products Card - Any Page - Total Shown | RPS.SF   | SmartFinal_Store | Yes         | Program Health          |
		| [#169567d] Products Card - Any Page - Total Shown | RPS.LW   | Demo_Store       | Yes         | LWLandingtab            |

@ignore
Scenario: [178298] More Filters - Supplier Name - WFS accounts not shown if retailer is not Walmart
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: Franky TG User
	Given I call Shared Step 153163 (RPS - Go to Logistics/Store Web Viewer): Target_store
	Given In the recent activities page, I take note of the number of products in the footer area and save as: TestCase169567
	Given In the recent activities Page, I click the More Filters Button
	Given In the recent activities page, I select the option: Supplier Name from the status drop down menu
	Given In the More Filters popup I enter the following into the Supplier search field: WPS
	Given In the More Filters popup I do not see the following in the Supplier dropdown: UL - Walmart WFS
	Given In the More Filters popup I do not see the following in the Supplier dropdown: Squad 2 QA for WFS testing
	Given In the More Filters popup I click close
	Given I confirm the More Filters popup is no longer shown
	And I call Shared Step 106194 (RPS Sign out)

@ignore
Scenario: [169143] More Filters - pop up - breadcrumbs
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: Franky TG User
	Given I call Shared Step 146631 (RPS - Go to Status Web Viewer)
	Given I call Shared Step 153318 (RPS & WV > More Filters > Breadcrumbs)
	And I call Shared Step 106194 (RPS Sign out)

Scenario Outline: [169400] Recent Activities page - layout (includes TAT)
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the active tab is: <LandingTab>
	Given I click the main tab: Recent Activities
	Then I confirm the Recent Activities tab has loaded
	Then I confirm the top menu bar is displayed with the logged in username
	Then I Check that the Recent Activities Products Table is showing
	Then I confirm the Recent Activities background color is: grey
	Then I confirm the Recent Activities Text color is: darker grey
	And I confirm the Recent Activities search box is shown
	Then I confirm that the recent activities search box place holder text reads: UPC / Product Name / Supplier / WPSID
	Then I confirm that the recent activities page buttons to the right of the search box are as follows:
		| Buttons                                |
		| More Filters                           |
		| Reset                                  |
		| Export to Excel                        |
		| Export TAT Report to Excel             |
	Given In the Product Lookup page I confirm to the right of the buttons I see three trends
		| Trend     |
		| UPCs      |
		| PRODUCTS  |
		| SUPPLIERS |
	Then I confirm that the recent activities page headings row has a grey background color
	Given In the product grid I confirm I see the following columns:
		| Column                          |
		| Product Info                    |
		| Most Recent Activity            |
		| Reason                          |
		| Packaging Type                  |
		| Turnaround Time                 |
		| Packaging Size                  |
		| Actions                         |
	And In the Recent Activities page, I confirm that the main table shows data rows

	Examples:
		| Scenario Name                                             | Retailer | LandingTab               |
#		| [#169400a] Recent Activities page - layout (includes TAT) | RPS.TG   | Product Lookup           |
		| [#169400b] Recent Activities page - layout (includes TAT) | RPS.CV   | Program Health           |
#		| [#169400c] Recent Activities page - layout (includes TAT) | RPS.HD   | Program Health           |
		| [#169400d] Recent Activities page - layout (includes TAT) | RPS.CT   | Program Health           |

@ignore
Scenario Outline: [169339] Select Columns - Select Columns - Remove Column
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the active tab is: <LandingTab>
	Given I click the main tab: Product Lookup
	Then I confirm the Product Lookup tab has loaded
	Then In the product lookup Page, In the Products table I click the Select Columns Button
	Then I confirm the Column Selector popup is shown
	Then I call Shared Step 148760 (Product Lookup - Select Columns - Add new Column to pop up - Do not click Apply) column name saved as: columnName169339 and save column list order as: columnNameList169339
	Given I click the Apply button in the Selector Column popup
	Then I confirm the Column Selector popup is not shown
	Then I confirm the column name I selected and saved as: columnName169339 is displayed next to the Actions column
	Then In the product lookup Page, In the Products table I click the Select Columns Button
	Then I confirm the Column Selector popup is shown
	Then I select the x icon next the column I selected saved as: columnName169339
	Given I click the Apply button in the Selector Column popup
	Then I confirm the Column Selector popup is not shown
	Then I confirm the column name I selected and saved as: columnName169339 is not displayed
	And I call Shared Step 106194 (RPS Sign out)

	Examples:
		| Scenario Name                                              | Retailer | LandingTab               |
		| [#169339a] Select Columns - Select Columns - Remove Column | RPS.LW   | LWLandingtab             |
		| [#169339b] Select Columns - Select Columns - Remove Column | RPS.CV   | Program Health           |
#		| [#169339c] Select Columns - Select Columns - Remove Column | RPS.WM   | Program Health           |
#		| [#169339d] Select Columns - Select Columns - Remove Column | RPS.HD   | Program Health           |
		| [#169339e] Select Columns - Select Columns - Remove Column | RPS.SF   | Program Health           |
#		| [#169339f] Select Columns - Select Columns - Remove Column | RPS.PX   | Program Health           |
#		| [#169339g] Select Columns - Select Columns - Remove Column | RPS.TG   | Product Lookup           |
		| [#169339h] Select Columns - Select Columns - Remove Column | RPS.CT   | Program Health           |

@ignore
Scenario: [169142] More Filters pop up - Initial display & Close options
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: Franky TG User
	Given I click the main tab: Product Lookup
	Then I confirm the Product Lookup tab has loaded
	Given In the product lookup page, I click the More Filters Button
	Given In the product lookup page, I confirm the More Filters body is between the top and bottom of the page
	Given In the product lookup page, I confirm the More Filters header contains the following title: More Filters
	Given In the product lookup page, I click the x icon in the More Filters popup
	Given In the product lookup page, I confirm the More Filters popup is not displayed
	Given In the product lookup page, I click the More Filters Button
	Given In the product lookup page, I confirm the More Filters header contains the following title: More Filters
	Given In the product lookup page, I confirm I see a dropdown field selector
	Given In the product lookup page, I confirm I see the footer area
	Given In the product lookup page, I confirm I see the following buttons in the footer:
		| Button		 |
		| Close			 |
		| Apply filters  |
	Given In the product lookup page More Filters Popup, I Click the Close button
	And I call Shared Step 106194 (RPS Sign out)

@ignore
Scenario: [169145] More Filters - pop up - Remove all filters
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: Franky TG User
	Given I click the main tab: Recent Activities
	Then I confirm the Recent Activities tab has loaded
	Given In the recent activities page, I take note of the number of products in the footer area and save as: TestCase169145
	Given I call Shared Step 153320 (RPS & WV > More Filters > Remove all filters)
	Given In the recent activites page, I check if the number of products in the footer area matches amount saved as: TestCase169145
	And I call Shared Step 106194 (RPS Sign out)
	And I call Shared Step 106194 (RPS Sign out)

@ignore
Scenario: [169159] More Filters - Supplier Name - reloads on Remove All filters
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: Franky TG User
	Given I call Shared Step 153163 (RPS - Go to Logistics/Store Web Viewer): Target_store
	Given I call Shared Step 167119 (RPS & WV > More Filters > Supplier Name, Packaging Type and Packaging Size > Apply filter)
	Given In the recent activities Page, I click the More Filters Button
	Given In the More Filters popup I see the Selected Filters area
	Given In the More Filters popup I click Reset filters
	Given In the More Filters popup I do not see the Selected Filters area
	Given In the recent activities page, I select the option: Supplier Name from the status drop down menu
	Given In the product lookup page More Filters Popup, I Click the the Apply Filter Button

@ignore
Scenario: [169622] Status  Web Viewer - Breadcrumbs - multiple selection and reset
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: Franky TG User
	Given I call Shared Step 146631 (RPS - Go to Status Web Viewer)
	Given In the recent activities page, I take note of the number of products in the footer area and save as: TestCase169622
	Given I call Shared Step 146428 (RPS & WV > More Filters > Select Multiple (for Status viewer & Recent Activities)
	Given In the Recent Activites page, I confirm I see the breadcrumbs area under the search field
	Then In the recent activities Page, In the Products table I click the Reset Button
	Given In the Recent Activites page, I confirm I do not see the breadcrumbs area under the search field
	Given In the recent activites page, I check if the number of products in the footer area is greater than amount saved as: TestCase169622
	Given I call Shared Step 146595 (RPS & WV > More Filters > Status - select multiple)
	Given In the Recent Activites page, I confirm I see the breadcrumbs area under the search field
	Then In the recent activities Page, In the Products table I click the Reset Button
	Given In the Recent Activites page, I confirm I do not see the breadcrumbs area under the search field
	Given In the recent activites page, I check if the number of products in the footer area matches amount saved as: TestCase169622
	And I call Shared Step 106194 (RPS Sign out)

@ignore
Scenario: [169152] More Filters - Apply Filter, Remove breadcrumb, More Filters pop up shows correctly
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: Franky TG User
	Given I click the main tab: Recent Activities
	Then I confirm the Recent Activities tab has loaded
	Given In the product lookup page, I click the More Filters Button
	Given In the recent activities page, I select the option: Supplier Name from the status drop down menu
	Given In the product lookup page, I select the Supplier Name option: The WERCS LTD from the parameters drop down menu
	Given In the recent activities Page More Filters Popup, I Click the the Apply Filter Button
	Given In the product lookup page, I confirm the More Filters popup is not displayed
	Given In the recent activities page, I confirm the products shown have the supplier name chosen: The WERCS LTD
	Then I confirm that the recent activities page bread crumb area does not contain the label: Supplier Name: The WERCS LTD
	Then In the recent activities Page, I click the x icon for the bread crumb: Supplier Name: The WERCS LTD
	Then I confirm that the recent activities page bread crumb area does contain the label: Supplier Name: The WERCS LTD
	And I call Shared Step 106194 (RPS Sign out)
	Given In the product lookup page More Filters Popup, I Click the the Apply Filter Button
	And I call Shared Step 106194 (RPS Sign out)

@ignore
Scenario: [169151] More Filters pop up - Remove individual filters
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: Franky TG User
	Given I click the main tab: Recent Activities
	Then I confirm the Recent Activities tab has loaded
	#Given I call Shared Step 146428 (RPS & WV > More Filters > Select Multiple (for Status viewer & Recent Activities)
	#Given In the recent activities page, I take note of the number of products in the footer area and save as: TestCase169157
	#Given I call Shared Step 152061 (Generic - remove breadcrumb - confirm total is updated)
	Given In the recent activities Page, I click the More Filters Button
	Given In the recent activities page, I select the option: Packaging Type from the status drop down menu
	Given In the recent activities page, I select the option: Plastic Container from the parameters drop down menu
	Given In the recent activities page, I select the option: Cardboard from the parameters drop down menu
	Given In the recent activities Page More Filters Popup, I Click the the Apply Filter Button
	Given In the recent activities Page, I click the More Filters Button
	Given In the More Filters popup I select the x icon for the bread crumb: Packaging Type: Plastic Container
	Given In the recent activities Page More Filters Popup, I Click the the Apply Filter Button
	Then I confirm that the Lookup Page bread crumb area does not contain the label: Packaging Type: Plastic Container
	#Given In the recent activites page, I check if the number of products in the footer area does not match amount saved as: TestCase169567
	And I call Shared Step 106194 (RPS Sign out)

@ignore
Scenario: [169146] More Filters - pop up layout when filter applied
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: Franky TG User
	Given I click the main tab: Recent Activities
	Then I confirm the Recent Activities tab has loaded
	Given I call Shared Step 180343 (RPS & WV > More Filters > Select Field from parameters)
	Given I call Shared Step 180343 (RPS & WV > More Filters > Select Field from parameters)
	Given In the product lookup page More Filters Popup, I Click the the Apply Filter Button

@ignore
Scenario: [169148] More Filters - Supplier Name - exact match
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: Franky TG User
	Given I click the main tab: Recent Activities
	Then I confirm the Recent Activities tab has loaded
	Given In the product lookup page, I click the More Filters Button
	Given In the recent activities page, I select the option: Supplier Name from the status drop down menu
	Given In the product lookup page, I select the Supplier Name option: The WERCS LTD from the parameters drop down menu
	Given In the recent activities Page More Filters Popup, I Click the the Apply Filter Button
	Given In the product lookup page, I confirm the More Filters popup is not displayed
	Given In the recent activities page, I confirm the products shown have the supplier name chosen: The WERCS LTD
	Then I confirm that the recent activities page bread crumb area does not contain the label: Supplier Name: The WERCS LTD
	Then In the recent activities Page, I click the x icon for the bread crumb: Supplier Name: The WERCS LTD
	Then I confirm that the recent activities page bread crumb area does contain the label: Supplier Name: The WERCS LTD
	And I call Shared Step 106194 (RPS Sign out)

@ignore
Scenario: [169153] More Filters - pop up - Close does not apply filter changes 
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: Franky TG User
	Given I call Shared Step 153163 (RPS - Go to Logistics/Store Web Viewer)
	Given In the recent activities page, I take note of the number of products in the footer area and save as: TestCase169153
	Given I call Shared Step 153321 (RPS & WV > More Filters > Select Supplier)
	Given In the recent activites page, I check if the number of products in the footer area matches amount saved as: TestCase169153
	And I call Shared Step 106194 (RPS Sign out)

@ignore
Scenario: [169159] - More Filters - Supplier Name - reloads on Remove All filters
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: Franky TG User
	Given I click the main tab: Recent Activities
	Then I confirm the Recent Activities tab has loaded
	Given In the product lookup page, I click the More Filters Button
	Given In the recent activities page, I select the option: UPC Number from the status drop down menu
	Given In the More Filters Filter in the Filter By field I see the following text: UPC Number
	Given In the More Filters Filter underneath the Filter By field I see the following text: Note a maximum of 10 unique filter rules can be selected
	Given In the product lookup page More Filters Popup, I Click the Close button
	And I call Shared Step 106194 (RPS Sign out)

Scenario: [137123] Smart & Final - Menu Links Banner - options
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: RPS.SF
	Given I confirm the following tabs are displayed:
	    | Link              |
		| Program Health    |
		| Dashboard         |
		| Recent Activities |
		| Web Viewers       |
		| ItemSync          |
		| Product Lookup    |
		| Help & Support    |


Scenario: [168413] Smart & Final - RPS - Recent Activities page - layout 
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: RPS.SF
	Given I click the main tab: Recent Activities
	And I confirm the active tab is: Recent Activities
	Then I confirm the top menu bar is displayed with the logged in username
	Then I confirm the menu links banner is displayed
	Given I confirm the following tabs are displayed:
	    | Link              |
		| Program Health    |
		| Dashboard         |
		| Recent Activities |
		| Web Viewers       |
		| ItemSync          |
		| Product Lookup    |
		| Help & Support    |
    Then I confirm the Recent Activities tab has loaded
	Then I confirm the Recent Activities background color is: grey
	Then I confirm the Recent Activities Text color is: darker grey
	And I confirm the Recent Activities search box is shown
	Then I confirm that the recent activities search box place holder text reads: UPC / Product Name / Supplier / WPSID
	Then I confirm that the recent activities page buttons to the right of the search box are as follows:
		| Buttons                      |
		| More Filters                 |
		| Reset                        |
		| Export to Excel              |
		| Export TAT Report to Excel   |
	Given In the Recent Activities page I confirm to the right of the buttons I do not see three trends
		| Trend     |
		| UPCs      |
		| PRODUCTS  |
		| SUPPLIERS |
    Given In the Recent Activites page, I confirm I do not see the breadcrumbs area under the search field
	Then  I Check that the Recent Activities Products Table is showing
	Then I confirm that the recent activities page headings row has a grey background color
	Given In the product grid I confirm I see the following columns:
		| Column                          |
		| Product Info                    |
		| Status                          |
		| Most Recent Activity            |
		| Actions                         |
	And In the Recent Activities page, I confirm that the main table shows data rows
	Then In the Recent Activities page, below the Most Recent Activity table I confirm: page footer is shown



Scenario: [165066] RPS/WV - Smart & Final RA or PL - Does not show any products which are not associated to S&F
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: RPS.SF
	Then I confirm the Home tab has loaded
	Given I click the main tab: Product Lookup
	And I confirm the active tab is: Product Lookup
	Then I Enter WPS ID : 1804040 in Search field
	Then I confirm the Product Lookup page refreshes
	And In the Product Lookup page, I confirm that the main table does not show data rows
	Then I Enter WPS ID : 1804041 in Search field
	Then I confirm the Product Lookup page refreshes
	And In the Product Lookup page, I confirm that the main table does not show data rows


		
Scenario: [168468] Smart & Final - Product Lookup - UI - Page Layout (No Trend Graphics)
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: RPS.SF
	Given I click the main tab: Product Lookup
	And I confirm the active tab is: Product Lookup
	Then I confirm the top menu bar is displayed with the logged in username
	Then I confirm the menu links banner is displayed
	Then I confirm below the menu links banner I see the Product Lookup main page body
	Given I confirm the following tabs are displayed:
	    | Link              |
		| Program Health    |
		| Dashboard         |
		| Recent Activities |
		| Web Viewers       |
		| ItemSync          |
		| Product Lookup    |
		| Help & Support    |
    Then I confirm the Product Lookup tab has loaded
	Then I confirm the Product Lookup background color is: grey
	Then I confirm the Product Lookup Text color is: darker grey
	And I confirm the Product Lookup search box is shown
	Then I confirm that the Product Lookup search box place holder text reads: Product Name / UPC Number / Supplier Name / WPS ID
	Then I confirm that the Product Lookup page buttons to the right of the search box are as follows:
		| Buttons        |
		| More Filters   |
		| Reset          |
		| Select Columns |
		| Export         |
		| Open Report    |
	
	Given In the Product Lookup page I confirm to the right of the buttons I do not see three trends
		| Trend     |
		| UPCs      |
		| PRODUCTS  |
		| SUPPLIERS |
    Given I confirm I do not see the bredcrumbs area under the search field
	Then  I Check that the Product Lookup Products Table is showing
	Then I confirm that the  Product Lookup page headings row has a grey background color
	And In the Product Lookup page, I confirm that the main table shows data rows
	Then In the Product Lookup page, below the Product Lookup table I confirm: page footer is shown


Scenario: [169630] Products Card - Any Page - Total Shown
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the active tab is: <LandingTab>
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I confirm that I see the three cards to the right of the Search field and buttons
	Then I confirm that I see card with label: PRODUCTS
	Then I confirm that the PRODUCTS card contains a numeric value
	Then I confirm that the PRODUCTS card contains a graphic
	Then I confirm that the PRODUCTS card does not show a percentage value
	Then I confirm that the hover text for the PRODUCTS card is: Count of Completed Products.

Examples:
		| Scenario Name                                     | Retailer | Page              | IsWebviewer | LandingTab               |
		| [#169630a] Products Card - Any Page - Total Shown | RPS.TG   | Recent Activities | No          | Product Lookup           |
		| [#169630b] Products Card - Any Page - Total Shown | RPS.TG   | Product Lookup    | No          | Product Lookup           |
		| [#169630c] Products Card - Any Page - Total Shown | RPS.TG   | Target_status     | Yes         | Product Lookup           |
		| [#169630d] Products Card - Any Page - Total Shown | RPS.TG   | Target_store      | Yes         | Product Lookup           |
		| [#169630e] Products Card - Any Page - Total Shown | RPS.TG   | Target_HQ         | Yes         | Product Lookup           |
		| [#169630f] Products Card - Any Page - Total Shown | RPS.LW   | Recent Activities | No          | LWLandingtab             |
		| [#169630g] Products Card - Any Page - Total Shown | RPS.LW   | Product Lookup    | No          | LWLandingtab             |
		| [#169630h] Products Card - Any Page - Total Shown | RPS.LW   | Lowes_store       | Yes         | LWLandingtab             |
		| [#169630i] Products Card - Any Page - Total Shown | RPS.CV   | Recent Activities | No          | Program Health           |
		| [#169630j] Products Card - Any Page - Total Shown | RPS.CV   | Product Lookup    | No          | Program Health           |
		| [#169630k] Products Card - Any Page - Total Shown | RPS.CT   | Recent Activities | No          | Program Health           |
		| [#169630l] Products Card - Any Page - Total Shown | RPS.CT   | Product Lookup    | No          | Program Health           |