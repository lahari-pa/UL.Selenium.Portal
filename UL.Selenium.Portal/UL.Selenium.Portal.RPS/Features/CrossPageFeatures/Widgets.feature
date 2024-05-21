@RPS
@Login
@run_ItemSync_Manual_Entry
@LandingPage
@Home
@Shared
@TopBar
@Navigation
@ProductInformation
@ProductLookUP
@Dashboard
@RecentActivities
@RPSSHA
@ItemSync
@Cards
@SuperTable
Feature: Widgets

Scenario Outline: [169345] Hamburger icon - options and general test
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I save the first widget containing a graph to context as: %ThisWidget%
	Then I click the graph hamburger menu for widget: <Graph>
	Then I Check that the Hamburger menu dropdown for widget: <Graph> is displayed
	Then I Check that the Options displayed in the Hamburger menu for widget: <Graph> are as follows:
		| Options                   |
		| Print chart               |
		| Download PNG image        |
		| Download JPEG image       |
		| Download PDF document     |
		| Download SVG vector image |
	#Dont do the print steps here (selenium limitation?)
	Then I click on the home page background
	Then I Click the hamburger menu for the widget: <Graph> and select the option: Download PDF document
	Then I confirm that a file is produced called chart.pdf and save as savedasPDF106490
	Then I open the file saved as: savedasPDF106490 should see a new tabbed document with the pdf at it contains the text: <Graph>
	Then I close the window that was opened
	Then I Click the hamburger menu for the widget: <Graph> and select the option: Download PNG image
	Then I confirm that a file is produced called chart.png and save as savedasPNG106490
	Then I open the file saved as: savedasPNG106490 and take a screenshot
	Then I close the window that was opened
	Then I Click the hamburger menu for the widget: <Graph> and select the option: Download JPEG image
	Then I confirm that a file is produced called chart.jpeg and save as savedasjpeg106490
	Then I open the file saved as: savedasjpeg106490 and take a screenshot
	Then I close the window that was opened
	Then I Click the hamburger menu for the widget: <Graph> and select the option: Download SVG vector image
	Then I confirm that a file is produced called chart.svg and save as savedassvg106490
	Then I open the file saved as: savedassvg106490 and take a screenshot
	Then I close the window that was opened
	Then I delete the file saved as savedasPNG106490
	Then I delete the file saved as savedasPDF106490
	Then I delete the file saved as savedasjpeg106490
	Then I delete the file saved as savedassvg106490
	Then I call Shared Step 106194 (RPS Sign out)

	Examples:
		| Scenario Name                                        | Retailer     | Page                | IsWebviewer | Graph                        |
		| [#169345a] Hamburger icon - options and general test | RPS.TG       | Program Health      | No          | RU Categories by Supplier    |
		| [#169345b] Hamburger icon - options and general test | RPS.TG       | Dashboard           | No          | RU Category by Supplier      |
		| [#169345c] Hamburger icon - options and general test | RPS.CV       | Program Health      | No          | RU Categories by Supplier    |
		| [#169345d] Hamburger icon - options and general test | RPS.CV       | Dashboard           | No          | RU Category by Supplier      |
		| [#169345e] Hamburger icon - options and general test | RPS.LW       | Program Health      | No          | RU Categories by Supplier    |
		| [#169345f] Hamburger icon - options and general test | RPS.LW       | Dashboard           | No          | RU Category by Supplier      |
		| [#169345g] Hamburger icon - options and general test | RPS.SF       | Program Health      | No          | RU Categories by Supplier    |
		| [#169345h] Hamburger icon - options and general test | RPS.SF       | Dashboard           | No          | RU Category by Supplier      |
		| [#169345i] Hamburger icon - options and general test | RPS.WM       | Program Health      | No          | RU Categories by Supplier    |
		| [#169345j] Hamburger icon - options and general test | RPS.WM       | Dashboard           | No          | RU Category by Supplier      |
#		| [#169345k] Hamburger icon - options and general test | RPS.HD       | Program Health      | No          | RU Categories by Supplier    |
#		| [#169345l] Hamburger icon - options and general test | RPS.HD       | Dashboard           | No          | RU Category by Supplier      |
#		| [#169345m] Hamburger icon - options and general test | RPS.PX       | Program Health      | No          | RU Categories by Supplier    |
#		| [#169345n] Hamburger icon - options and general test | RPS.PX       | Dashboard           | No          | RU Category by Supplier      |
