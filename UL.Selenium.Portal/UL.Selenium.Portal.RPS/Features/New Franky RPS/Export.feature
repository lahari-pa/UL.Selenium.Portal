@RPS
@Login
@run_HomeTab
@LandingPage
@Home
@Shared
@Navigation
@Dashboard
@ProductLookUP
@RecentActivities


Feature: Export

Scenario Outline: [169340] Product Lookup - Export
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the Home tab has loaded
	Then I click the main tab: Product Lookup
	Then I confirm the Product Lookup tab has loaded
    Then In the Product Lookup Page, I click the Export Button
    Then I save the download folder
    Then I confirm a new file has been downloaded with .csv format and save to context as: output
    Then I Check that there is a new csv file downloaded and save the file path as: output
    Then I check that the file saved as: output contains the following column headings:
| Heading                              |
| Product Name                         |
| UPC Number                           |
| Product Number                       |
| Supplier Name                        |
| Recommended Usage Category Code      |
| Recommended Use                      |

#Step that checks the file for data in products grid
And In the Product Lookup Page, I save all the Results to context as: ProductsGridResults1
Then In the product lookup Page, I confirm the Products shown in the export file saved as: output  match the products saved as: ProductsGridResults1
Then I delete the file saved as output
And I call Shared Step 106194 (RPS Sign out)

	Examples:
	| Scenario Name                                 | Retailer |
#   | [#169340a] Product Lookup - Export            | RPS.TG   |
	| [#169340b] Product Lookup - Export            | RPS.CV   |
#   | [#169340c] Product Lookup - Export            | RPS.HD   |
	| [#1169340d] Product Lookup - Export           | RPS.CT   |

Scenario Outline: [169169] Export - special characters in Product Name
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the Home tab has loaded
	Then I click the tab: <Page> with parameter IsWebViewer: <IsWebviewer>
	Then I confirm that the <Page> tab is active with WebViewer param: <IsWebviewer>
	Then I Enter WPS ID : 1804011 in Search field
    Then In the Product Lookup Page, I click the Export Button
    Then I save the download folder
    Then I confirm a new file has been downloaded with .csv format and save to context as: output
    Then I Check that there is a new csv file downloaded and save the file path as: output
	#Step that checks the file for data in products grid
	And In the Product Lookup Page, I save all the Results to context as: ProductsGridResults1
    Then In the product lookup Page, I confirm the Products shown in the export file saved as: output  match the products saved as: ProductsGridResults1
    Then I delete the file saved as output
    And I call Shared Step 106194 (RPS Sign out)

	Examples:
		| Scenario Name                                          | Retailer        | Page                      | IsWebviewer |
#		| [#169169a] Export - special characters in Product Name | RPS.TG          | Product Lookup            | No          |
#		| [#169169b] Export - special characters in Product Name |RPS.TG           | Recent Activities         | No          |
		| [#169169c] Export - special characters in Product Name | RPS.CV          | Product Lookup            | No          |
		| [#169169d] Export - special characters in Product Name | RPS.CV          | Recent Activities         | No          |
		| [#169169e] Export - special characters in Product Name | RPS.LW          | Product Lookup            | No          |
		| [#169169f] Export - special characters in Product Name | RPS.LW          | Recent Activities         | No          |
#		| [#169169g] Export - special characters in Product Name | RPS.SF          | Product Lookup            | No          |
#		| [#169169h] Export - special characters in Product Name | RPS.SF          | Recent Activities         | No          |
#		| [#169169i] Export - special characters in Product Name | RPS.LW          | Demo Viewer (RPS)         | No          |
#		| [#169169j] Export - special characters in Product Name | RPS.TG          | Store Viewer (RPS)        | No          |
#		| [#169169k] Export - special characters in Product Name | RPS.TG          | Status Viewer (RPS)       | No          |
#		| [#169169l] Export - special characters in Product Name | RPS.TG          | HQ Viewer (RPS)           | No          |
#		| [#169169m] Export - special characters in Product Name | RPS.SF          | Store Viewer              | No          |
#		| [#169169n] Export - special characters in Product Name | RPS.LW          | Drum Log                  | No          |	
#		| [#169169o] Export - special characters in Product Name | RPS.LW          | Classification History    | No          |	
	
