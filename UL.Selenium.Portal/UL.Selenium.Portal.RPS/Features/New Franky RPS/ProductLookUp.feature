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


Feature: Product Lookup

Scenario Outline: [169335]Select Columns -  Re-order Columns
	Given I call Shared Step 104950 (RPS Login - Base Functionality) for TReVor account: <Retailer>
	Then I confirm the active tab is: <LandingTab>
	Then I click the main tab: Product Lookup
	Then In the product lookup Page, In the Products table I click the Select Columns Button
	Then I confirm the Column Selector popup is shown
	Then I click the Add Column button in the Column Selector popup
	Then I click on the new row at the bottom of the Column Selector popup
	Then I select the following available column in the dropdown selector in Column Selector popup: Packaging Type and save as: Packaging Type
	Then I save the order of the columns shown in the Column Selector Popup as: ColumnPopupOrder
	Given I click the Apply button in the Selector Column popup
	Then I confirm the Column Selector popup is not shown
	Then I confirm the Product Lookup page refreshes
	Then I save the order of the columns shown in the Product Table as: ProductTableColumnOrder
	Then I confirm columns shown in the Column Selector Popup: ColumnPopupOrder  match with columns shown in the Product Table: ProductTableColumnOrder
	Then In the product lookup Page, In the Products table I click the Select Columns Button
	Then I use mouse to select the hamburger icon for the column name: Packaging Type
	Then I use mouse to place the coluum: Packaging Type into a new position in the list
	Then I save the order of the columns shown in the Column Selector Popup as: ColumnPopupOrder1
	Given I click the Apply button in the Selector Column popup
	Then I confirm the Column Selector popup is not shown
	Then I confirm the Product Lookup page refreshes
	Then I save the order of the columns shown in the Product Table as: ProductTableColumnOrder1
	Then I confirm columns shown in the Column Selector Popup: ColumnPopupOrder1  match with columns shown in the Product Table: ProductTableColumnOrder1
	And I call Shared Step 106194 (RPS Sign out)
	
	Examples:
	| Scenario Name                                | Retailer | LandingTab               |
	| [#169335a]Select Columns -  Re-order Columns | RPS.LW   | LWLandingtab             |
	| [#169335b]Select Columns -  Re-order Columns | RPS.CV   | Program Health           |
#	| [#169335c]Select Columns -  Re-order Columns | RPS.HD   | Program Health           |
	| [#169335d]Select Columns -  Re-order Columns | RPS.SF   | Program Health           |
	| [#169335e]Select Columns -  Re-order Columns | RPS.TG   | Product Lookup           |
#	| [#169335f]Select Columns -  Re-order Columns | RPS.PX   | Program Health           |
#	| [#169335g]Select Columns -  Re-order Columns | RPS.WM   | Program Health           |
	| [#169335h]Select Columns -  Re-order Columns | RPS.CT   | Program Health           |
	
