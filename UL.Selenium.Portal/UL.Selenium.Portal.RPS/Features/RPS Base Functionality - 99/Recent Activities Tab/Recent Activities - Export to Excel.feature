@RPS
@Login
@run_RecentActivites_ExportToExcel
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
@MoreFilters

Feature: Recent Activities - Export to Excel

@ScenarioId:9353
Scenario: [106867] Base Functionality - Recent Activities - Export to Excel - pop up layout
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: Franky TG User
#Then I confirm the Home tab has loaded
	Given I click the main tab: Recent Activities
	Then I confirm the Recent Activities tab has loaded
	Then In the recent activities Page, I click the Export To Excel Button
	Then In the recent activities Page, The Export to Excel Popup is showing
	Then In the recent activities Page, In the Export to Excel popup I Confirm the header text reads: Export
	Then In the recent activities Page, In the Export to Excel popup I Confirm the 'x' Close icon is shown
	And In the recent activities Page, In the Export to Excel popup I Confirm the main body text reads: This export may take some time to complete. Do you wish to proceed?
	And In the recent activities Page, In the Export to Excel popup I Confirm the Export to Excel Button shows
	Then In the recent activities Page, In the Export to Excel popup I Confirm the Export Button text reads: Export All Values
	And In the recent activities Page, In the Export to Excel popup footer I confirm there is only 1 button shown
	Then In the recent activities Page, In the Export to Excel popup footer I confirm the Close button is shown
	Then In the recent activities Page, In the Export to Excel popup I click away from the export pop up
	Then In the recent activities Page, The Export to Excel Popup is not showing
	Then In the recent activities Page, I click the Export To Excel Button
	Then In the recent activities Page, The Export to Excel Popup is showing
	And In the recent activities Page, In the Export to Excel popup footer I click Close
	Then In the recent activities Page, The Export to Excel Popup is not showing
	Then In the recent activities Page, I click the Export To Excel Button
	Then In the recent activities Page, The Export to Excel Popup is showing
	And In the recent activities Page, In the Export to Excel popup I click the 'x' Close icon
	Then In the recent activities Page, The Export to Excel Popup is not showing
	And I call Shared Step 106194 (RPS Sign out)

@ScenarioId:9358
Scenario: [70327] Base Functionality - Recent Activities - Export to Excel
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: Franky TG User
#Then I confirm the Home tab has loaded
	Given I click the main tab: Recent Activities
	Then I confirm the Recent Activities tab has loaded
	And In the recent activities Page, I click the More Filters Button
	And In the Product Lookup Page, The More Filters Popup is showing
	Then In the recent activities page, I select the option: Assigned from the status drop down menu
	Then In the recent activities Page More Filters Popup, I Click the the Apply Filter Button
	Then In the recent activities Page, The More Filters Popup is not showing
	Then I confirm the Recent Activities page refreshes
	Then In the recent activities Page, I save all the Results to context as: RecentProductsGridResults1
	Then In the recent activities Page, I click the Export To Excel Button
	Then In the recent activities Page, The Export to Excel Popup is showing
	Then In the recent activities Page, In the Export to Excel popup I click the Export All Values
	Then I save the download folder
#Then I confirm a new file has been downloaded with .csv format and save to context as: ExportCsv1
	Then I Check that there is a new csv file downloaded and save the file path as: ExportCsv1
	Then I check that the file saved as: ExportCsv1 contains the following column headings:
		| Heading                   |
		| Product Number            |
		| Product Name              |
		| UPC                       |
		| Status                    |
		| Contact Email             |
		| Most Recent Activity Date |
		| Supplier Name             |
		| Is Kit Product?           |
		| Is Archived?              |

#Step that checks the cvs file for data in products grid
	Then In the recent activities Page, I confirm the Products shown in the export file saved as: ExportCsv1  match the products saved as: RecentProductsGridResults1
	Then I delete the file saved as ExportCsv1
	And I call Shared Step 106194 (RPS Sign out)

