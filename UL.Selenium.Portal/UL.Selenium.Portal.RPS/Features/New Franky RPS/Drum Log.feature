@RPS
@Login
@run_DrumgLogFunctionalityGeneral
@LandingPage
@Home
@Shared
@TopBar
@Navigation
@ProductInformation
@ProductLookUP
@Dashboard
@DrumLog
@HelpAndSupport
@run_DrumgLogLayout
@RecentActivities
@MoreFilters

Feature: Drum Log

Scenario: [105079] Drum Log - Tab heading shows as active when selected
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: RPS.CT
	#Then I confirm the Home tab has loaded
	Given I click the main tab: Drum Log
	Then I confirm the Drum Log tab has loaded
	Then I confirm the active tab is: Drum Log
	And I Confirm that the tab: Drum Log shows in a bolded underline under text indicating it is active
	Then I Confirm that all tabs not labeled: Drum Log are not highlighted in grey
	Given I click the main tab: Recent Activities
	Then I confirm the Recent Activities tab has loaded
	Then I confirm the active tab is: Recent Activities
	Then I Confirm that the tab: Drum Log does not show in a bolded underline under text indicating it is inactive
	And I Confirm that the tab: Recent Activities shows in a bolded underline under text indicating it is active
	Given I click the main tab: Drum Log
	Then I confirm the Drum Log tab has loaded
	Then I confirm the active tab is: Drum Log
	And I Confirm that the tab: Drum Log shows in a bolded underline under text indicating it is active

Scenario: [180727] Drum Log - Drum details -  Date format in Expanded grid (all date fields)
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: RPS.CT
	#Then I confirm the Home tab has loaded
	Given I click the main tab: Drum Log
	Then I confirm the Drum Log tab has loaded
	Then I confirm the active tab is: Drum Log
	And In the Drum Log page, I expand the first row of the products table
	Then In the Drum Log page, I check that there are additional rows below the expanded version of the first row in the products table.
	Then In the Drum Log page, I check that the 'Scan Date' Column For the first row shows in the format yyyy-mm-dd
	Then In the Drum Log page, I check that the 'Date In Drum' Column For the first row shows in the format yyyy-mm-dd
	And In the Drum Log page, I Look for an expanded Row that contains Date Removed data and save it to context as: expandedRow105096
	Then In the Drum Log page, I check that the Date Removed Column For the row saved as: expandedRow105096 shows in the format yyyy-mm-dd

Scenario: [105117] Drum Log - Entries shown are not repeated
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: RPS.CT
	#Then I confirm the Home tab has loaded
	Given I click the main tab: Drum Log
	Then I confirm the Drum Log tab has loaded
	Then I confirm the active tab is: Drum Log
	And In the Drum Log page, I check that the data shown is not repeated

Scenario: [108105] Drum Log page - layout
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: RPS.CT
	#Then I confirm the Home tab has loaded
	Given I click the main tab: Drum Log
	Then I confirm the Drum Log tab has loaded
	Then I confirm the active tab is: Drum Log
	Then I confirm the page heading banner shows the WERCSmart Product Suite logo and it reads : WERCSmart Product Suite
	Then I confirm the UL Logo is displayed in the top bar
	And I confirm the user displayed in the top bar matches the active logged in user
	Then I confirm the menu links banner is displayed
	And I confirm the Drum Log Page background color is: grey
	Then I confirm the Drum Log Page Text color is: black
	Then I Check that the current page title is 'Drum Log'
	Then I confirm the Drum Log search box is shown
	Then I confirm that the Drum Log search box place holder text reads: Drum Name / Drum Type / Drum Status / Store Name / Region Name / Location
	Then In the Drum Log Page More Filters button is displayed
	Then I confirm that the Drum Log Page buttons to the right of the search box are as follows:
		| Buttons         |
		| More Filters    |
		| Reset           |
		| Export to Excel |
 
	Then I confirm that the Drum Log page does not show the bread crumb area
	Then I confirm that the Drum Log page shows the headings row in the table
	# JW 04/30/21 - This line has been commented out. Checking for a specific color in automation is not necessary as visual checks for that are performed nearly every day in normal testing.
	#Then I confirm that the Drum Log page headings row has a grey background color
	Then In the Drum Log page, I confirm the column labels show a colon (:) icon as the column resize anchor
	Then In the Drum Log page, I confirm that the main table has the following columns:
		| Headings      |
		| Drum Name     |
		| Drum Category |
		| Drum Type     |
		| Drum Status   |
		| Store Name    |
		| Region Name   |
		| Location      |
		| Date Opened   |
		| Date Closed   |
		| Date Hauled   |
	Then I call Shared Step 111155 (Table Heading or sub heading - confirm column resize anchor - resize column) On the: Drum Log page, for the column: Drum Name
	Then I call Shared Step 111155 (Table Heading or sub heading - confirm column resize anchor - resize column) On the: Drum Log page, for the column: Drum Type
	Then I call Shared Step 111155 (Table Heading or sub heading - confirm column resize anchor - resize column) On the: Drum Log page, for the column: Drum Status
	Then I call Shared Step 111155 (Table Heading or sub heading - confirm column resize anchor - resize column) On the: Drum Log page, for the column: Store Name
	Then I call Shared Step 111155 (Table Heading or sub heading - confirm column resize anchor - resize column) On the: Drum Log page, for the column: Region Name
	Then I call Shared Step 111155 (Table Heading or sub heading - confirm column resize anchor - resize column) On the: Drum Log page, for the column: Location
	Then I call Shared Step 111155 (Table Heading or sub heading - confirm column resize anchor - resize column) On the: Drum Log page, for the column: Date Opened
	Then I call Shared Step 111155 (Table Heading or sub heading - confirm column resize anchor - resize column) On the: Drum Log page, for the column: Date Closed
	Then I call Shared Step 111155 (Table Heading or sub heading - confirm column resize anchor - resize column) On the: Drum Log page, for the column: Date Hauled
	Then In the Drum Logg page, I confirm that the main table shows data rows
	Then In the Drum Log page, I confirm that In the data row to the far left I confirm I see a right facing arrow (Expand arrow)
	Then In the Drum Log page, I confirm that to the right of the expand arrow I see the Drum Name
	Then ~~MANUAL CHECK~~ In the Drum Log page, I confirm that each column of data is aligned to the left of the column
	# JW 04/30/21 - This line has been commented out. Checking for a specific color in automation is not necessary as visual checks for that are performed nearly every day in normal testing.
	#Then In the Drum Log page, I confirm that the table shows alternating background color (grey to white)
	Then ~~MANUAL CHECK~~ In the Drum Log page, I confirm a slider bar is shown to the right of the table
	Then In the Drum Log page, below the Most Recent Activity table I confirm: page footer is shown


Scenario: [111156] Drum Log page - Resize columns
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: RPS.CT
	#Then I confirm the Home tab has loaded
	Given I click the main tab: Drum Log
	Then I confirm the Drum Log tab has loaded
	Then I confirm the active tab is: Drum Log
	Then I call Shared Step 111155 (Table Heading or sub heading - confirm column resize anchor - resize column) On the: Drum Log page, for the column: Drum Name
	And In the Drum Log page, I expand the first row of the products table
	And I call Shared Step 111155 (Table Heading or sub heading - confirm column resize anchor - resize column) On the: Drum Log page, for the column: Scan Date

Scenario: [108106] Drum Log page - Expand arrow
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: RPS.CT
	#Then I confirm the Home tab has loaded
	Given I click the main tab: Drum Log
	Then I confirm the Drum Log tab has loaded
	Then I confirm the active tab is: Drum Log
	And In the Drum Log page, I expand the first row of the products table
	Then In the Drum Log page, I check that there are additional rows below the expanded version of the first row in the products table.
	Then In the Drum Log page, I confirm that the expanded first row has following columns in the sub table:
		| Headings        |
		| Scan Date       |
		| Date In Drum    |
		| Date Removed    |
		| Found/Not Found |
		| Manufacturer    |
		| Name            |
		| Product         |
		| UPC             |
		| Quantity        |
		| Volume          |
		| Actions         |
	Then In the Drum Log page, I confirm that the expanded first row column headings show the ':' resize anchor
	Then I confirm the Drum Log tab has loaded
	Then In the Drum Log page, I confirm data is shown in the column:Volume
	Then In the Drum Log page, I confirm that in the expanded first row I see the expanded menu icon to the left
 
Scenario: [98475] Drum Log - Page options - change page number
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: RPS.CT
	#Then I confirm the Home tab has loaded
	Given I click the main tab: Drum Log
	Then I confirm the Drum Log tab has loaded
	Then I confirm the active tab is: Drum Log
	Then In the Drum Log Page, In the Products table footer I enter the page number value of: 3

Scenario: [101314] Drum Log - Export to Excel - Export All Drums
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: RPS.CT
	#Then I confirm the Home tab has loaded
	Given I click the main tab: Drum Log
	Then I confirm the Drum Log tab has loaded
	Then I confirm the active tab is: Drum Log
	Then In the Drum Log Page, I save all the Results to context as: savedFile
	Then I call Shared Step 108297 (Drum Log - Export to Excel - Export All Drums - open file)
	Then I check that the file saved as: drumlogfile contains the following column headings:
		| Heading       |
		| Drum Name     |
		| Drum Category |
		| Drum Type     |
		| Drum Status   |
		| Store Name    |
		| Region Name   |
		| Location      |
		| Date Opened   |
		| Date Closed   |
		| Date Hauled   |
   #Step that checks the cvs file for data in products grid
	Then In the Drum log Page, I confirm the Products shown in the export file saved as: drumlogfile  match the products saved as: savedFile
	Then I delete the file saved as drumlogfile
	And I call Shared Step 106194 (RPS Sign out)


Scenario: [105012] Drum Log - Export Filtered Drum List - Store Name
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: RPS.CT
	#Then I confirm the Home tab has loaded
	Given I click the main tab: Drum Log
	Then I confirm the Drum Log tab has loaded
	Then I confirm the active tab is: Drum Log
	Then In the Drum Log Page, I click the More Filters Button
	And In the Drum Log Page, The More Filters Popup is showing
	Then In the Drum Log Page More Filters Popup, I check that the: Store Name field is a drop down field
	And In the Drum Log page, I select the option: Bolton from the: Store Name drop down menu
	Then In the Drum Log Page More Filters Popup, I Click the the Apply Filter Button
	Then I confirm the Drum Log tab has loaded
	Then In the Drum Log Page, I save all the Results to context as: savedFile
	Then I call Shared Step 108297 (Drum Log - Export to Excel - Export All Drums - open file)
	Then I check that the file saved as: drumlogfile contains the following column headings:
		| Heading       |
		| Drum Name     |
		| Drum Category |
		| Drum Type     |
		| Drum Status   |
		| Store Name    |
		| Region Name   |
		| Location      |
		| Date Opened   |
		| Date Closed   |
		| Date Hauled   |
   #Step that checks the cvs file for data in products grid
	Then In the Drum log Page, I confirm the Products shown in the export file saved as: drumlogfile  match the products saved as: savedFile
	Then I delete the file saved as drumlogfile
	And I call Shared Step 106194 (RPS Sign out)

Scenario: [105013] Drum Log - Export to Excel - Export All Drums with UPCs
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: RPS.CT
	#Then I confirm the Home tab has loaded
	Given I click the main tab: Drum Log
	Then I confirm the Drum Log tab has loaded
	Then I confirm the active tab is: Drum Log
	Then In the Drum Log Page, I save all the Results to context as: savedFile
	Then I call Shared Step 108298 (Drum Log - Export to Excel - Export all Drums with UPCs - open file)
	Then I check that the file saved as: drumlogfile contains the following column headings:
		| Heading              |
		| Drum Name            |
		| Drum Category        |
		| Drum Type            |
		| Drum Status          |
		| Store Name           |
		| Region Name          |
		| Location             |
		| Date Opened          |
		| Date Closed          |
		| Date Hauled          |

		| Scan Date            |
		| Date in Drum         |
		| Date Removed         |
		| Found/Not Found      |
		| Manufacturer         |
		| Product Name         |
		| ProductID            |
		| UPC                  |
		| Quantity             |
		| Volume               |
		| Orginal Drum Type    |
		| Selected Drum Type   |
		| Reason for Change    |
		| Flagged Product Name |
		| Flagged Product UPC  |
		| Contested Category   |
		| Contested Type       |
		| Contesting User      |
		| Contested Date UTC   |

   #Step that checks the cvs file for data in products grid
	Then In the Drum log Page, I confirm the Products shown in the export file saved as: drumlogfile  match the products saved as: savedFile
	Then I delete the file saved as drumlogfile
	And I call Shared Step 106194 (RPS Sign out)

Scenario: [108295] Drum Log - Export to Excel - pop up layout
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: RPS.CT
	#Then I confirm the Home tab has loaded
	Given I click the main tab: Drum Log
	Then I confirm the Drum Log tab has loaded
	Then I confirm the active tab is: Drum Log
	Then In the Drum Log page, I click the Export To Excel Button
	Then In the recent activities Page, The Export to Excel Popup is showing
	Then In the Drum Log Page, In the Export to Excel popup I Confirm the header text reads: Export
	Then In the Drum Log page, In the Export to Excel popup I Confirm the 'x' Close icon is shown
	And In the recent activities Page, In the Export to Excel popup I Confirm the main body text reads: This export may take some time to complete. Do you wish to proceed?
	And In the Drum Log Page, In the Export to Excel popup main body I confirm there are 2 buttons displayed
	Then In the Drum Log page, In the Export to Excel popup I Confirm the Export All Drums button is shown
	Then In the Drum Log page, In the Export to Excel popup I Confirm the Export All Drums with UPCs button is shown
	And In the recent activities Page, In the Export to Excel popup footer I confirm there is only 1 button shown
	Then In the recent activities Page, In the Export to Excel popup footer I confirm the Close button is shown
	Then In the recent activities Page, In the Export to Excel popup I click away from the export pop up
	Then In the recent activities Page, The Export to Excel Popup is not showing
	Then In the Drum Log page, I click the Export To Excel Button
	Then In the recent activities Page, The Export to Excel Popup is showing
	And In the recent activities Page, In the Export to Excel popup footer I click Close
	Then In the recent activities Page, The Export to Excel Popup is not showing
	Then In the Drum Log page, I click the Export To Excel Button
	Then In the recent activities Page, The Export to Excel Popup is showing
	And In the Drum Log page, In the Export to Excel popup I click the 'x' Close icon
	Then In the recent activities Page, The Export to Excel Popup is not showing
	And I call Shared Step 106194 (RPS Sign out)

Scenario: [178702] Drum Log - Export to Excel - Export All Drums with UPCs - With Filtered list - UPC Scan Status = Found
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: RPS.CT
	#Then I confirm the Home tab has loaded
	Given I click the main tab: Drum Log
	Then I confirm the Drum Log tab has loaded
	Then I confirm the active tab is: Drum Log
	Then In the Drum Log Page, I click the More Filters Button
	And In the Drum Log Page, The More Filters Popup is showing
	And In the Drum Log page, I select the option: Found from the: UPC Scan Status drop down menu
	Then In the Drum Log Page More Filters Popup, I Click the the Apply Filter Button
	Then I confirm the Drum Log tab has loaded
	Then In the Drum Log Page, I save all the Results to context as: savedFile
	Then I call Shared Step 108298 (Drum Log - Export to Excel - Export all Drums with UPCs - open file)
	Then I check that the file saved as: drumlogfile contains the following column headings:
		| Heading              |
		| Drum Name            |
		| Drum Category        |
		| Drum Type            |
		| Drum Status          |
		| Store Name           |
		| Region Name          |
		| Location             |
		| Date Opened          |
		| Date Closed          |
		| Date Hauled          |

		| Scan Date            |
		| Date in Drum         |
		| Date Removed         |
		| Found/Not Found      |
		| Manufacturer         |
		| Product Name         |
		| ProductID            |
		| UPC                  |
		| Quantity             |
		| Volume               |
		| Orginal Drum Type    |
		| Selected Drum Type   |
		| Reason for Change    |
		| Flagged Product Name |
		| Flagged Product UPC  |
		| Contested Category   |
		| Contested Type       |
		| Contesting User      |
		| Contested Date UTC   |

   #Step that checks the cvs file for data in products grid
	Then In the Drum log Page, I confirm the Products shown in the export file saved as: drumlogfile  match the products saved as: savedFile
	Then I delete the file saved as drumlogfile
	And I call Shared Step 106194 (RPS Sign out)


Scenario: [178703] Drum Log - Export to Excel - Export All Drums with UPCs - With Filtered list - UPC Scan Status = Not Found
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: RPS.CT
	#Then I confirm the Home tab has loaded
	Given I click the main tab: Drum Log
	Then I confirm the Drum Log tab has loaded
	Then I confirm the active tab is: Drum Log
	Then In the Drum Log Page, I click the More Filters Button
	And In the Drum Log Page, The More Filters Popup is showing
	And In the Drum Log page, I select the option: Not Found from the: UPC Scan Status drop down menu
	Then In the Drum Log Page More Filters Popup, I Click the the Apply Filter Button
	Then I confirm the Drum Log tab has loaded
	Then In the Drum Log Page, I save all the Results to context as: savedFile
	Then I call Shared Step 108298 (Drum Log - Export to Excel - Export all Drums with UPCs - open file)
	Then I check that the file saved as: drumlogfile contains the following column headings:
		| Heading              |
		| Drum Name            |
		| Drum Category        |
		| Drum Type            |
		| Drum Status          |
		| Store Name           |
		| Region Name          |
		| Location             |
		| Date Opened          |
		| Date Closed          |
		| Date Hauled          |

		| Scan Date            |
		| Date in Drum         |
		| Date Removed         |
		| Found/Not Found      |
		| Manufacturer         |
		| Product Name         |
		| ProductID            |
		| UPC                  |
		| Quantity             |
		| Volume               |
		| Orginal Drum Type    |
		| Selected Drum Type   |
		| Reason for Change    |
		| Flagged Product Name |
		| Flagged Product UPC  |
		| Contested Category   |
		| Contested Type       |
		| Contesting User      |
		| Contested Date UTC   |

   #Step that checks the cvs file for data in products grid
	Then In the Drum log Page, I confirm the Products shown in the export file saved as: drumlogfile  match the products saved as: savedFile
	Then I delete the file saved as drumlogfile
	And I call Shared Step 106194 (RPS Sign out)

Scenario: [178699] Drum Log - Export Filtered Drum List - UPC Scan Status = Found
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: RPS.CT
	#Then I confirm the Home tab has loaded
	Given I click the main tab: Drum Log
	Then I confirm the Drum Log tab has loaded
	Then I confirm the active tab is: Drum Log
	Then In the Drum Log Page, I click the More Filters Button
	And In the Drum Log Page, The More Filters Popup is showing
	And In the Drum Log page, I select the option: Found from the: UPC Scan Status drop down menu
	Then In the Drum Log Page More Filters Popup, I Click the the Apply Filter Button
	Then I confirm the Drum Log tab has loaded
	Then In the Drum Log Page, I save all the Results to context as: savedFile
	Then I call Shared Step 108297 (Drum Log - Export to Excel - Export All Drums - open file)
	Then I check that the file saved as: drumlogfile contains the following column headings:
		| Heading       |
		| Drum Name     |
		| Drum Category |
		| Drum Type     |
		| Drum Status   |
		| Store Name    |
		| Region Name   |
		| Location      |
		| Date Opened   |
		| Date Closed   |
		| Date Hauled   |
   #Step that checks the cvs file for data in products grid
	Then In the Drum log Page, I confirm the Products shown in the export file saved as: drumlogfile  match the products saved as: savedFile
	Then I delete the file saved as drumlogfile
	And I call Shared Step 106194 (RPS Sign out)

Scenario: [105020] Drum Log - Breadcrumbs
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: RPS.CT
	#Then I confirm the Home tab has loaded
	Given I click the main tab: Drum Log
	Then I confirm the Drum Log tab has loaded
	Then I confirm the active tab is: Drum Log
	Then In the Drum Log Page, I click the More Filters Button
	And In the Drum Log Page, The More Filters Popup is showing
	Then In the Drum Log Page More Filters Popup, I check that the: Store Name field is a drop down field
	And In the Drum Log page, I select the option: Bolton from the: Store Name drop down menu
	Then In the Drum Log page, I select the option: 146.01 Lightbulbs from the: Drum Type drop down menu
	Then In the Drum Log Page More Filters Popup, I Click the the Apply Filter Button
	Then I confirm that the Drum Log page bread crumb area contains the label: Bolton
	Then I confirm that the Drum Log page bread crumb area contains the label: 146.01 Lightbulbs
	Then In the Drum Log Page, In the Products table I click the Reset Button
	Then I confirm the Drum Log tab has loaded
	Then I confirm that the Drum Log page does not show the bread crumb area
	Then I confirm that the Drum Log page bread crumb area does not contain the label: Bolton
	Then I confirm that the Drum Log page bread crumb area does not contain the label: 146.01 Lightbulbs

Scenario: [108301] Drum Log - View Data  - Transportation Data - confirm fields shown
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: RPS.CT
	#Then I confirm the Home tab has loaded
	Given I click the main tab: Drum Log
	Then I confirm the Drum Log tab has loaded
	Then I confirm the active tab is: Drum Log
	Then I call Shared Step 108305 (Drum Log - Select Row and Expand > Actions - View Data)
	Then I wait for the Product Information Popup to load
	Then I Confirm that Product Information pop up is shown
	Then I call Shared Step 149247 (Canadian Tire - Product Information pop up - Expand Transportation Data - Confirm rows)
	Then I Close the Product Information Popup

Scenario: [108300] Drum Log - View Data  - Product Data codes - confirm fields shown
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: RPS.CT
	#Then I confirm the Home tab has loaded
	Given I click the main tab: Drum Log
	Then I confirm the Drum Log tab has loaded
	Then I confirm the active tab is: Drum Log
	Then I call Shared Step 108305 (Drum Log - Select Row and Expand > Actions - View Data)
	Then I wait for the Product Information Popup to load
	Then I Confirm that Product Information pop up is shown
	Then I call Shared Step 149021 (Canadian Tire - Product Information pop up - Expand Product Data - Confirm rows)
	Then I Close the Product Information Popup


Scenario: [108303] Drum Log - View Data  - Battery Data - confirm fields shown
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: RPS.CT
	#Then I confirm the Home tab has loaded
	Given I click the main tab: Drum Log
	Then I confirm the Drum Log tab has loaded
	Then I confirm the active tab is: Drum Log
	Then I call Shared Step 108305 (Drum Log - Select Row and Expand > Actions - View Data)
	Then I wait for the Product Information Popup to load
	Then I Confirm that Product Information pop up is shown
	Then I call Shared Step 163151 (Product Information pop up - New version - Battery Data - confirm rows)
	Then I Close the Product Information Popup