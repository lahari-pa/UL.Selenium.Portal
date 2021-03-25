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
@PaymentMethods
@ProductSetUp
@UPC
@DeleteActiveProducts
@run_BulkActions
Feature: BulkActions

@ScenarioId:1086
Scenario: [56223] Bulk Actions - Forward Product Registration navigation
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then the WERCSmart homepage should load
	Given I click Bulk Actions in the Products Grid
	And I click Forward Product Registration in the Bulk Actions window
	Then I should see the header: Forward Product Registration on the Forward Product Registration window
	And I should see the subheading 3: Select Products & UPCs on the Forward Product Registration window

#This test cases uses the ULSC account
@ScenarioId:1087
Scenario: [56224] Bulk Actions - Sync Products to WERCSLink navigation
	Given I Login into WERCSmart Portal - Admin Role - WERCs ULSC Account
	Then the WERCSmart homepage should load
	Given I click Bulk Actions in the Products Grid
	And I click Sync Products in the Bulk Actions window
	And I should see the header: Sync Products to ULSC on the Sync Products to ULSC window
	Then I click on the cancel button on the ULSC Sync popup
	And I should see the Subheading Alerts in the main window

@ScenarioId:1088
Scenario: [56225] Bulk Actions - Accept Documents navigation
	Given I Login into WERCSmart Portal - Admin Role - WERCs Visual Account
	Then the WERCSmart homepage should load
	Given I click Bulk Actions in the Products Grid
	And I click Accept Documents in the Bulk Actions window
	And I should see the header: Document Acceptance on the Document Acceptance window

@ScenarioId:1089
Scenario: [56227] Bulk Actions  Delete Products navigation
	Given I Login into WERCSmart Portal - Admin Role - WERCs Visual Account
	Then the WERCSmart homepage should load
	Given I click Bulk Actions in the Products Grid
	And I click Delete Products in the Bulk Actions window
	And I should see the header: Delete Active Products on the Delete Active Product window

@ScenarioId:1090
Scenario: [74634] Forward Product Registration - Only can select product once
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I filter the products by: Sending to Retailers
	Given I save the list of Product IDs displayed on the page as: ProductInProgressList74634
	Given I click Bulk Actions in the Products Grid
	Then I should see a popup with header Bulk Actions
	Given I click Forward Product Registration in the Bulk Actions window
	And I should see the subheading 3: Select Products & UPCs on the Forward Product Registration window
	And I confirm the active Forward Product Registration tab is: Select Products
	Given I select the product with ID saved as: ProductInProgressList74634 under the Select Products tab
	#Given I click Bulk Actions in the Products Grid
	#Then I should see a popup with header Bulk Actions
	#Given I click Forward Product Registration in the Bulk Actions window
	#Then I should see the header: Forward Product Registration on the Forward Product Registration window
	#Given I enter the text: 1 in the 'Search by WPS ID or Product Name' field
	#Given I save first selectable Product ID as: SelectProductsID74634 under the Select Products tab
	#Given I select the product with ID saved as: SelectProductsID74634 under the Select Products tab and the checkbox is disabled while the page is working
	#Given I select the product with ID saved as: SelectProductsID74634 under the Select Products tab
	#Then I confirm that the product checkbox is disabled while the page is working
	And I confirm I am unable to select the product with ID saved as: ProductInProgressList74634 under the Select Products tab
	Given I click the Home navigation icon and accept the alert popup

@ScenarioId:1093
Scenario: [76314] Forward Product - NR should Not Require UPC
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I filter the products by: Assessment in Progress
	Given I save the list of Product IDs displayed on the page as: ProductInProgressList76314
	Given I click Bulk Actions in the Products Grid
	Then I should see a popup with header Bulk Actions
	Given I click Forward Product Registration in the Bulk Actions window
	Then I should see the header: Forward Product Registration on the Forward Product Registration window
	And I confirm the active Forward Product Registration tab is: Select Products
	#Given I select the product with ID saved as: ProductInProgressList76314 under the Select Products tab
	Then I select the first non Kit product from the list of IDs saved as: ProductInProgressList76314 under the Select Products tab
	Given I click continue on the Forward Product Registration page
	Then I confirm the active Forward Product Registration tab is: Select Retailers
	Given in the Select Retailers tab under Forward Product Registration I select the retailer: No Retailer/No UPC Product
	Given I click continue on the Forward Product Registration page
	Then I confirm the active Forward Product Registration tab is: Select UPCs
	Given I select the first product under the Select UPCs tab
	And If the Private Label textbox is showing in the Select UPCs screen, I enter the value: N/A
	Given I click the Add To No Retailer button under the Select UPCs tab
	And I select the UPC row: 'No UPC'/ 'No Retailer'
	Given I click continue on the Forward Product Registration page
	Then I confirm the active Forward Product Registration tab is: Product Results
	Given I click continue on the Forward Product Registration page
	Then I confirm the active Forward Product Registration tab is: Review & Submit
	Given I select the true radio for the 'Are Statements True' question under the Review and Submit tab
	Given I click continue on the Forward Product Registration page
	# Confirm product has been forward properly (Message: Thank you for registering your product on WERCSmart for assessment.)
	Given I navigate to the home page

@tfs_design
Scenario: [76056] Bulk Actions- Include Subformat Column for Document List
	Given I login as the administrator
	Then The home screen should load
	Given I click Bulk Actions in the Products Grid
	Then I should see a popup with header Bulk Actions
	Given I click Accept Documents in the Bulk Actions window
	Then I should see the header: Document Acceptance on the Document Acceptance window
	Then I confirm there are products listed under My Products on the Document Acceptance page and save as: DocumentAcceptanceProducts
	Given I select the first product from My Products saved as: DocumentAcceptanceProducts which contains a document
	Given I save the displayed Documents on the Document Acceptance page as: DocumentAcceptanceDocuments
	Then I confirm the Subformat column appears as part of the Documents Information
	Given I click on View under Actions for the first document from the list saved as: DocumentAcceptanceDocuments
	Then I confirm a new window opens displaying the document url: ViewWercsDocument
	# This is currently blocked - downloading pdf through chrome viewer is not reliable so need to fetch the file directly from the API
	Given I confirm the subformat type at the top of the document matches the vaulue in the Documents table for the first document I viewed
	Given I close the window that opened
	Given I navigate to the home page

@test75321
@ScenarioId:1092
Scenario: [75321] Forward Product - Completed Status (NO Recert)
	Given I create a product and take to completed using Test Case 75335 and save as: TestCase75321
	Given I navigate to the landing page
	And I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	And I filter the products by: Accepted by Retailers
	#And I Confirm the Products shown display the Green Colour Status - which is the Accepted by Retailers
	And I Confirm the Products shown display at least one retailer with the Green Colour Status - which is the Accepted by Retailers
	And I filter for the product saved as: TestCase75321
	And I call Shared Step 75130 - Bulk Actions - Select Forward Product Registration
	Then I should see the header: Forward Product Registration on the Forward Product Registration window
	And I enter the text: saved as TestCase75321 in the 'Search by WPS ID or Product Name' field
	And In the Foward Product Registration Screen I should see product: saved as TestCase75321
	And In the Foward Product Registration Screen I Select the product: saved as TestCase75321
	And I click continue on the Forward Product Registration page
	And In the Forward Product Registration Screen I select a retailer under Other Retailers and save as TestCase75321Retailer
	And I click continue on the Forward Product Registration page
	Then If there is the option to select a vendor for the product with ID: saved as TestCase75321, I select the first option
	And I call Shared Step 75140 - Forwarding - Select Products & UPCs step - Add Any missing data and select 1 UPC - Continue and save UPC as TestCase75321UPC
	Then I should see the subheading 3: Product Results on the Forward Product Registration window
	Then I confirm that for UPC Number saved as TestCase75321UPC the retailer is displayed as saved as TestCase75321Retailer
	And I confirm that there are NO Errors displayed for the Product
	And I click continue on the Forward Product Registration page
	Then I should see the subheading 3: Review & Submit on the Forward Product Registration window
	Then I select the true radio for the 'Are Statements True' question under the Review and Submit tab
	And I click continue on the Forward Product Registration page
	And In the Purchase Summary screen I confirm the Purchase Summary header is displayed
	Given If purchase details are showing click confirm order
	Then In the Thank You screen I confirm the following statement is shown: Thank you for registering your product on WERCSmart for assessment.
	And I call Shared Step 65080 (Login to Studio and Open SHA manager)
	And I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase75321)
	And I Confirm the Product shows status: Completed for retailer: saved as retailer
	And I Confirm the Product shows status: Submitted for retailer: saved as TestCase75321Retailer
	And I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase75321)
	And I call Shared Step 75309 (SHA > Select Product > UPC Retailer and Feed) for product saved as: TestCase75321
	And I confirm the Product UPC window has opened
	And I confirm that retailer saved as: TestCase75321Retailer appears for UPC saved as: TestCase75321UPC
	And I close the current window and switch to the main window in Studio
	And I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase75321)
	And I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase75321)
	And I Confirm the Product shows status: Completed for retailer: saved as retailer
	And I Confirm the Product shows status: Assigned for retailer: saved as TestCase75321Retailer
	And I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase75321)
	Then I call Shared Step 49742 - WPS - Check In Product saved as: TestCase75321
	And I call Shared Step 79500 (WPS Studio - PD+ - set all data and publish using rule and doc queue - CKLT and SBCS only) for product saved as: TestCase75321	
	And I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase75321)
	Given I call Shared Step 59066 (Go to SHA Manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase75321)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase75321 and its status is: Accepted	
	And I Confirm the Product shows status: Accepted for retailer: saved as TestCase75321Retailer
	Given I call Shared Step 51664 (SHA - Accepted Product - set Retailers to Completed for saved as: TestCase75321) for
		| Retailer                       |
		| saved as TestCase75321Retailer |
		| saved as retailer              |
	And I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase75321)
	And I Confirm the Product shows status: Completed for retailer: saved as retailer
	And I Confirm the Product shows status: Completed for retailer: saved as TestCase75321Retailer

# Assigned to Barrett, Beverly
# Created by Barrett, Beverly
# Test case can be found at the following paths:
# NetProjects10\WercsSmart Portal\Release Day Tests
@ScenarioId:1091
Scenario: [75129] Forward - Product in Submitted Status
	Given I Use Test case 75142 to create a NEW PRODUCT and get it to Submitted status in SHA
	Given I retrieve the email address for account: WERCs Product Account and save as: TestCase75129Email
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	And I call Shared Step 74654 - SHA manager - Suppliers - Search by email address: saved as TestCase75129Email and saved name as: TestCase75129Supplier
	And I call Shared Step 74655 SHA with email - Search by Supplier ID saved as TestCase75129Supplier for specific product status: Submitted and email: saved as TestCase75129Email
	And I save a product which blue and has retailers and at least 1 UCP as TestCase75129
	And I save the retailers associated with product TestCase75129 as TestCase75129Retailers
	Given I navigate to the landing page
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I filter the products by: Assessment in Progress
	And I filter for the product saved as: TestCase75129
	Given I call Shared Step 75130 - Bulk Actions - Select Forward Product Registration
	And I should see the subheading 3: Select Products & UPCs on the Forward Product Registration window
	And I enter the text: saved as TestCase75129 in the 'Search by WPS ID or Product Name' field
	And In the Foward Product Registration Screen I should see product: saved as TestCase75129
	And In the Foward Product Registration Screen I Select the product: saved as TestCase75129
	And I click continue on the Forward Product Registration page
	#And In the Forward Product Registration Screen I select a retailer not in the list of retailers saved as TestCase75129Retailers and save as TestCase75129Retailer
	Then I select one of the following retailers from the table: that is also not in the list saved as: TestCase75129Retailers and save the chosen retailer as: TestCase75129Retailer
		| Retailer                                                                       |
		| Bed Bath and Beyond (including Harmon, Buy Buy Baby, and Christmas Tree Shops) |
		| Dick's Sporting Goods                                                          |
		| Kroger                                                                         |
	And I click continue
	And If the Private Label textbox is showing in the Select UPCs screen, I enter the value: N/A
	And I call Shared Step 75140 - Forwarding - Select Products & UPCs step - Add Any missing data and select 1 UPC - Continue and save UPC as UPC75129
	And I should see the subheading 3: Product Results on the Forward Product Registration window
	And I click continue
	And I select the true radio for the 'Are Statements True' question under the Review and Submit tab
	And I click continue
	Given In the Purchase Summary screen I confirm the Purchase Summary header is displayed
	Given I navigate to the home page
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase75129)
	Then I Confirm the Product shows status: Submitted for retailer: saved as TestCase75129Retailer
	And I call Shared Step 75309 (SHA > Select Product > UPC Retailer and Feed) for product saved as: TestCase75129
	And I confirm UPC number saved as: "UPC75129" is displayed in the SHA Manager Product UPC list
	And I confirm that retailer saved as TestCase75129Retailer appears for UPC saved as UPC75129
	And I close the window that opened

# Created by Aaron Caton
# Test case can be found at the following paths:
# NetProjects10\WercsSmart Portal\WERCSmart\Home Page\Bulk Actions\Forward
@ScenarioId:1094
Scenario: [78048] Forwarding to Walmart - Without Authoring
	Given I generate a random UPC number and save as: UPC78048
	And I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	And I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Deodorant - Non-Aerosol
	Given I call Shared Step 60310 (Product Information - Without Child question)
	Given I call Shared Step 37857 (Enter Physical Property - Solid) with the following inputs:
		| Secondary Physical State | Water Solubility |
		| Flaked                   | Soluble in water |
	And I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Aqua          | 100     | false               | false       |            |
	And I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	And I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
	And I call Shared Step 57506 (Transportation Details 1 - Regulated for Transport(No) - Exemption(Random) - Continue - Happy Path)
	And I call Shared Step 62536 (Transportation Details 2 > I do not ship internationally > Continue - Happy Path)
	And I call Shared Step 62710 (Confirm VOC OTC/CARB heading and select No to FIRST QUESTION ONLY - Happy Path)
	And I call Shared Step 60631 (VOC - HVOC and MVOC - add values - Continue - Happy Path)
	And I click continue
	And I call Shared Step 77535 (Retailer Association - Walmart)
	And I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC78048, container type: Aerosol Can and size: 10
	And  I call Shared Step 78080 (Regulatory Documents to Provide - Upload OSHA SDS)
	And I call Shared Step 60567 (Upload Product Label only) for section: Volatile Organic Compounds
	And I click continue
	And I call Shared Step 57883 (Comments - Happy Path) and enter the comment: Test Comment
	And I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)

	And I navigate to the home page
	And I call Shared Step 75130 - Bulk Actions - Select Forward Product Registration
	And I enter the text: saved as TestCase78048 in the 'Search by WPS ID or Product Name' field
	And In the Foward Product Registration Screen I should see product: saved as TestCase78048
	And In the Foward Product Registration Screen I Select the product: saved as TestCase78048
	And I click continue on the Forward Product Registration page
	Given in the Select Retailers tab under Forward Product Registration I select the retailer: Wal-Mart/SAM'S CLUB
	And I click continue on the Forward Product Registration page
	Given I select the Vendor option: <first> for the first product displayed under the Select UPCs tab
	And I click the 'select all' UPCs checkbox
	And I click continue on the Forward Product Registration page
	And I click continue on the Forward Product Registration page
	Given I select the true radio for the 'Are Statements True' question under the Review and Submit tab
	And I click continue on the Forward Product Registration page
	#Then I click Home on the Forward Product Registration Purchase Summary page
	Then In the Thank You screen I confirm the following statement is shown: Thank you for registering your product on WERCSmart for assessment.
	And I navigate to the home page

	
@ScenarioId:9320
	Scenario:[93366] My Products - Bulk Actions Multiple Deletion of Registrations

	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	Given I generate a random UPC number and save as: UPC93366a
	Given I delete all products with UPC Number: saved as UPC93366a
	And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
	Then I save the product information as: TestCase93366a
	Given I call Shared Step 63860 (Product Information - US, No(child), No(OSHA), No(DSV), Yes(PLP), No(GNFR))
And I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	And I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	And I call Shared Step 85990 - Retailers - PLP - Select one or more retailer and add PL information - Continue
		| Retailer       |
		| CVS            |
		| Dollar General |
	Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC93366a, container type: Metal Container and size: 40
	And I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
		| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
	And I call Shared Step 57883 (Comments - Happy Path) and enter the comment: Test comment

	And I navigate to the home page
Given I generate a random UPC number and save as: UPC93366b
	Given I delete all products with UPC Number: saved as UPC93366b
	And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
	Then I save the product information as: TestCase93366b
	Given I call Shared Step 63860 (Product Information - US, No(child), No(OSHA), No(DSV), Yes(PLP), No(GNFR))
And I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	And I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	And I call Shared Step 85990 - Retailers - PLP - Select one or more retailer and add PL information - Continue
		| Retailer       |
		| CVS            |
		| Dollar General |
	Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC93366b, container type: Metal Container and size: 40
	And I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
		| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
	And I call Shared Step 57883 (Comments - Happy Path) and enter the comment: Test comment
	And I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)

		And I navigate to the home page
Given I generate a random UPC number and save as: UPC93366c
	Given I delete all products with UPC Number: saved as UPC93366c
	And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
	Then I save the product information as: TestCase93366c
	Given I call Shared Step 63860 (Product Information - US, No(child), No(OSHA), No(DSV), Yes(PLP), No(GNFR))
And I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	And I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	And I call Shared Step 85990 - Retailers - PLP - Select one or more retailer and add PL information - Continue
		| Retailer       |
		| CVS            |
		| Dollar General |
	Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC93366c, container type: Metal Container and size: 40
	And I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
		| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
	And I call Shared Step 57883 (Comments - Happy Path) and enter the comment: Test comment
	And I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)

		And I navigate to the home page
Given I generate a random UPC number and save as: UPC93366d
	Given I delete all products with UPC Number: saved as UPC93366d
	And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
	Then I save the product information as: TestCase93366d
	Given I call Shared Step 63860 (Product Information - US, No(child), No(OSHA), No(DSV), Yes(PLP), No(GNFR))
And I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	And I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	And I call Shared Step 85990 - Retailers - PLP - Select one or more retailer and add PL information - Continue
		| Retailer       |
		| CVS            |
		| Dollar General |
	Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC93366d, container type: Metal Container and size: 40
	And I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
		| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
	And I call Shared Step 57883 (Comments - Happy Path) and enter the comment: Test comment
	And I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)

		And I navigate to the home page
Given I generate a random UPC number and save as: UPC93366e
	Given I delete all products with UPC Number: saved as UPC93366e
	And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
	Then I save the product information as: TestCase93366e
	Given I call Shared Step 63860 (Product Information - US, No(child), No(OSHA), No(DSV), Yes(PLP), No(GNFR))
And I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	And I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	And I call Shared Step 85990 - Retailers - PLP - Select one or more retailer and add PL information - Continue
		| Retailer       |
		| CVS            |
		| Dollar General |
	Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC93366e, container type: Metal Container and size: 40
	And I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
		| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
	And I call Shared Step 57883 (Comments - Happy Path) and enter the comment: Test comment
	And I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)

	And I navigate to the home page
	Given I click Bulk Actions in the Products Grid
	And I click Delete Products in the Bulk Actions window
	And I should see the header: Delete Active Products on the Delete Active Product window
	Then I select the checkbox next to WPS ID in the Delete Active Products page
	Then I confirm all checkboxes are selected in the Delete Active Products page
	Then I deselect the checkbox next to WPS ID in the Delete Active Products page
	Then I confirm all checkboxes are deselected in the Delete Active Products page

	Then In the Delete Active Products page I search for WPS ID saved as: TestCase93366a
	Then In the Delete Active Products page I click the Filter button
	Then I make sure product saved as: TestCase93366a should not missing from the product list
	Then I select checkbox for product saved as: TestCase93366a

	Then I click on the Make Obsolete button
	Then I select the checkbox in the Make Obsolete popup
	Then In the Make Obsolete popup I click on the Cancel button
	Then I click on the Make Obsolete button
	Then I select the checkbox in the Make Obsolete popup
	Then In the Make Obsolete popup I click on the Accept button
	Then I make sure product saved as: TestCase93366a should missing from the product list

	Then In the Delete Active Products page I search for WPS ID saved as: TestCase93366b
	Then In the Delete Active Products page I click the Filter button
	Then I make sure product saved as: TestCase93366b should not missing from the product list
	Then I select checkbox for product saved as: TestCase93366b

	Then I click on the Make Obsolete button
	Then I select the checkbox in the Make Obsolete popup
	Then In the Make Obsolete popup I click on the Cancel button
	Then I click on the Make Obsolete button
	Then I select the checkbox in the Make Obsolete popup
	Then In the Make Obsolete popup I click on the Accept button
	Then I make sure product saved as: TestCase93366b should missing from the product list

	Then In the Delete Active Products page I search for WPS ID saved as: TestCase93366c
	Then In the Delete Active Products page I click the Filter button
	Then I make sure product saved as: TestCase93366c should not missing from the product list
	Then I select checkbox for product saved as: TestCase93366c

	Then I click on the Make Obsolete button
	Then I select the checkbox in the Make Obsolete popup
	Then In the Make Obsolete popup I click on the Cancel button
	Then I click on the Make Obsolete button
	Then I select the checkbox in the Make Obsolete popup
	Then In the Make Obsolete popup I click on the Accept button
	Then I make sure product saved as: TestCase93366c should missing from the product list

	
@ScenarioId:9321
	Scenario:[88826] Delete Products > Product Not yet submitted
    Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk
	Then I save the product information as: TestCase88826
	Then I generate a random UPC number and save as: UPC88826
	Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	And I call Shared Step 29181 (Ingredients - add any chemical) with name: Water
	And I call Shared Step 132370 (Waste Classification Data - TSCA (Random) - Prop 65 (No) - Continue - Happy Path)
	And In the 'Select Retailers' window I select the retailer: CVS
	And I click continue
	And I call Shared Step 85909 (UPC - Confirm Package type link and drop down not shown - Add UPC data - Continue) for UPC: saved as UPC88826, container type: Plastic Container and size: 12 click continue
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Then in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I navigate to the home page
	Given I click Bulk Actions in the Products Grid
	And I click Delete Products in the Bulk Actions window
	And I should see the header: Delete Active Products on the Delete Active Product window
	Then In the Delete Active Products page I search for WPS ID saved as: TestCase88826
	Then In the Delete Active Products page I click the Filter button
	Then I make sure product saved as: TestCase88826 should not missing from the product list
	Then I select checkbox for product saved as: TestCase88826  
	Then I click on the Make Obsolete button
	Then I select the checkbox in the Make Obsolete popup
	Then In the Make Obsolete popup I click on the Accept button
	Then In the Delete Active Products page I search for WPS ID saved as: TestCase88826
	Then In the Delete Active Products page I click the Filter button
	Then I make sure product saved as: TestCase88826 should missing from the product list
	Given I navigate to the home page
	Then I confirm the follow product doesn't exist in the product grid: TestCase88826
