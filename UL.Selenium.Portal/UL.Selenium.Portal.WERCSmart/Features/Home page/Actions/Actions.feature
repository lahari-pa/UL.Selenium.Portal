@Shared
@wercsmart
@run_Actions
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
@CreateProducts
@PaymentMethods
@SupplierReports
@ProductSetUp
@UPC
@ViewUpcs
@UPC
Feature: Actions

# Assigned to Amanda Coutant
# Created by Amanda Coutant
# Test case can be found at the following paths:
# NetProjects10\WercsSmart Portal\WERCSmart\Home Page\Actions\View UPCs
#actions/view upcs
@ScenarioId:1207
Scenario: [73424] View UPCs - Product with UPCs
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Then the WERCSmart homepage should load
	# search for product with name 'Product73424' in submitted status?
	And I create a product and save as: TestCase73424 and name as: Product73424
	Then I navigate to the home page
	Given I search for the product saved as: TestCase73424
	And I click Row Actions for the first product returned
	And I click on the Row Action: View UPCs
	And I switch to the tab with title: View UPCs
	And I save the UPCs associated to the product as: TestCase73424UPCs
	And I call Shared Step 65080 (Login to Studio and Open SHA manager)
	And I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase73424)
	And I call Shared Step 75309 (SHA > Select Product > UPC Retailer and Feed) for product saved as: TestCase73424
	And I confirm all UPC numbers in the list saved as: TestCase73424UPCs are displayed in the SHA Manager Product UPC list
	And I close the window that opened

#actions/delete
@ScenarioId:1206
Scenario: [63663] Obsoleting/Deleting a Product (not submitted status)
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given If I see the retail partners page I set all data consent tiers to true for all retailers in the top section
	Then The home screen should load
	Then I click the Register New Product icon in the Navigation Pane
	And I Select the Create a New Registration radio button
	And in the New Product page I click Continue
	And I set 'Product Name' to: Soap63663
	#And In the Product Type tab of the New Product Page, I enter: Soap (Bar, Liquid) for Body in the Type of Product select field
	And I set 'Type of Product' to: Soap (Bar, Liquid) for Body
	And in the New Product page I click Continue
	Then I save the product information as: TestCase63663
	Given I call Shared Step 65511 (Product Information - No Child, No Direct ship, No PL, Click Continue - Happy Path (use in a BCP))
	And I set the Primary Physical State to be: Solid
	And I set the Secondary Physical State to be: Solid
	And I set the When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5? option to: No
	And I set the Select the best Water Solubility description to be: Very soluble
	And in the New Product page I click Continue
	Given I navigate to the home page
	Then I delete the product: TestCase63663

#actions/delete
@ScenarioId:432
Scenario: [56216] My Products grid Actions - Delete Navigation
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then the WERCSmart homepage should load
	Then I click the Register New Product icon in the Navigation Pane
	And the Product Editor page should be loaded
	Then I create a shell product with name TestProduct saved as TestProduct
	Then I navigate to the home page
	Given I search for the product saved as: TestProduct
	When I click Row Actions for the most recent product returned
	Then I click on the Row Action: Delete
	And I cancel the Delete Dialog
	Then I should see products in the Product Grid
	#Given I save the number of items in the pie chart
	When I click Row Actions for the most recent product returned
	Then I click on the Row Action: Delete
	And I confirm the Delete Dialog
	Then I should not see products in the Product Grid

#actions/edit
@ScenarioId:430
Scenario: [56212] My Products grid Actions - Edit Navigation
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then the WERCSmart homepage should load
	When I filter the products by: Not Yet Submitted
	Given I save the ProductID and Name of the first Product in the grid as: FirstProduct
	When I click Row Actions for the most recent product returned
	Then I click on the Row Action: Edit
	Then the Product Editor page should be loaded
	And the product saved as: FirstProduct should be visible in editor

#actions/submit
@ScenarioId:431
Scenario: [56214] My Products grid Actions - Submit navigation
	Given I generate a random UPC number and save as: UPC56214
	And I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	And I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk
	Then I save the product information as: TestCase56214
	And I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	And I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	And I call Shared Step 29181 (Ingredients - add any chemical) with name: Chlorine
	And I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	#And I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	#And I call Shared Step 71618 (U. S. Department of Transportation (DOT) Classification - For Alcohol (Packaging III))
	#And I call Shared Step 63219 (Retailer Association - Select No Retailer - Click continue)
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	And I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
		| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
	Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: Test
	And I navigate to the home page
	And I filter the products by: Not Yet Submitted
	And I search for the product saved as: TestCase56214
	When I click Row Actions for the most recent product returned
	Then I click on the Row Action: Submit
	And I should see the Data Acceptance Page
	And I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)

#actions/view
@ScenarioId:433
Scenario: [56218] My Products grid Actions - View Navigation
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then the WERCSmart homepage should load
	When I filter the products by: Assessment in Progress
	And I click Row Actions for the most recent product returned
	Then I click on the Row Action: View
	Then A Summary page should open in a new browser tab
	Then I should not seen an Accept button
	Given I close the browser tab with the Summary page

#actions/documents
@ScenarioId:434
Scenario: [56219] My Products grid Actions - Documents navigation
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then the WERCSmart homepage should load
	Then I create a product with sds upload and name as: product1 then take to data acceptance and save as: TC56219
	Then I navigate to the home page
	Given I search for the product saved as: TC56219
	When I click Row Actions for the most recent product returned
	Then I click on the Row Action: Documents
	And I should see Review Documents
	Then I Delete the file with name: testdoc.pdf from the downloads folder
	Then In the Documents section I should see the following columns: Document Name, Subformat, Language, Actions
	Then I save the current window handle to context as: MainWindowHandle
	Given I click on the View link of the first document in Supplier Uploaded
	Then I confirm that a file is produced called testdoc.pdf and save as savedas56219PDF
	Then I Check that the pdf file saved as: savedas56219PDF contains the text: If your product contains any kind of chemical	
	Then I switch to the window with handle saved as: MainWindowHandle
	Then I delete the file saved as savedas56219PDF
	Then I close All the current windows except the Main Window
	


@ScenarioId:6114
Scenario: [112937] View UPCs - UPC name column exists in the Product UPCs table
	Given I Submit a new product which has a Case UPC and a regular UPC
	Given I navigate to the landing page
	And I call Shared Step (Login to WERCSmart - Premium Account)
	And I filter for the product saved as: TestCase87685
	And I click Row Actions for the first product returned
	Then I click on the Row Action: View UPCs
	Then I navigate to the View UPC tab and Check that the Product UPCs table contains the coloumn labeled 'UPC Name'
	Given I generate a random UPC number and save as: UPC109503
	And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	And I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk
	Then I save the product information as: TestCase109503
	Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue) for
		| Retailer  |
		| Walgreens |
	Given I call Shared Step 87647 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC109503, container type: Paper bag and size: 2 do not click continue
	Given I click continue
	And  I call Shared Step 78080 (Regulatory Documents to Provide - Upload OSHA SDS)
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: test
	Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Then If purchase details are showing click confirm order
	Given I navigate to the landing page
	And I call Shared Step (Login to WERCSmart - Premium Account)
	And I filter for the product saved as: TestCase109503
	And I click Row Actions for the first product returned
	Then I click on the Row Action: View UPCs
	Then I navigate to the View UPC tab and Check that the Product UPCs table contains the coloumn labeled 'UPC Name'

@ScenarioId:1591
Scenario: [112939] View - UPC name column exists in the Product UPCs table
	Given I Submit a new product which has a Case UPC and a regular UPC
	Given I navigate to the landing page
	And I call Shared Step (Login to WERCSmart - Premium Account)
	And I filter for the product saved as: TestCase87685
	And I click Row Actions for the first product returned
	Then I click on the Row Action: View
	Then I navigate to the View tab for product saved as: TestCase87685 and Check that the Product UPCs table contains the coloumn labeled 'UPC Name'
	Given I generate a random UPC number and save as: UPC109503
	And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	And I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk
	Then I save the product information as: TestCase109503
	Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue) for
		| Retailer  |
		| Walgreens |
	Given I call Shared Step 87647 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC109503, container type: Paper bag and size: 2 do not click continue
	Given I click continue
	And  I call Shared Step 78080 (Regulatory Documents to Provide - Upload OSHA SDS)
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: test
	Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Then If purchase details are showing click confirm order
	Given I navigate to the landing page
	And I call Shared Step (Login to WERCSmart - Premium Account)
	And I filter for the product saved as: TestCase109503
	And I click Row Actions for the first product returned
	Then I click on the Row Action: View
	Then I navigate to the View tab for product saved as: TestCase109503 and Check that the Product UPCs table contains the coloumn labeled 'UPC Name'

@tfs_design
@CACleaning
@ScenarioId:5984
Scenario: [114944] View/Summary - Ingredients table contains details (Functional Purpose and Ingredient Type)
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then the WERCSmart homepage should load
	#Then create a cleaning product with functional and ingredient types, step below needs checking in Sprint site once back up
	Then I create a CA Cleaning Compliant product, select ingredient type and functional purpose then save it as: TestCase114944 and progress it to submitted
	Given I navigate to the landing page
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	And I filter for the product saved as: TestCase114944
	And I click Row Actions for the first product returned
	Then I click on the Row Action: View
	Then I Switch to the View tab for product saved as: TestCase114944
	And I Check that the Summary page Ingredients table contains the coloumns labeled:
		| Heading            |
		| Ingredient Type    |
		| Functional Purpose |
	Then For the following ingredients I check that the Ingredients table on the summary page contains only the Ingredient Types and Functional Purposes listed:
		| Ingredient      | Ingredient Type            | Functional Purpose                    |
		| Formaldehyde    | Fragrance                  | FormaldehydeFunctionalPurposesList    |
		| Water           | Intentionally Added        | WaterFunctionalPurposesList           |
		| Sodium chloride | Non-functional Byproduct   | Sodium chlorideFunctionalPurposesList |
		| Butane          | Non-functional Contaminant | ButaneFunctionalPurposesList          |
	

@ScenarioId:6866
Scenario:[119578] My Products - More Filters - For Discontinued Registrations
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	And I should see an option for More Filters
	Given I click More Filters in the products grid
	Then I click the 'Show Only Discontinued Products' checkbox in the 'My Products' grid
	Then I confirm that only discontinued products appear in the 'My Products' grid
	Then I click the 'Show Only Discontinued Products' checkbox in the 'My Products' grid
	Then I confirm that all products appear in the 'My Products' grid


@ScenarioId:8177
Scenario: [125144] Actions - 3rd Party Access Code Window

Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Then I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
And I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Raw Material
Then I save the product information as: TestCase125144
Then I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
| CASNumber | ComponentName   | Percent | PublicallyDisclosed | PublicName | TradeSecret |
| 7647-14-5 | Sodium chloride | 33.33   | false               |            | false       |
|           | Copper sulfate  | 11.67   | false               |            | false       |
|           | Nitric acid     | 55      | false               |            | false       |
Then I call Shared Step 48948 (Formulation > 3rd Party - Select all)
And I call Shared Step 132370 (Waste Classification Data - TSCA (Random) - Prop 65 (No) - Continue - Happy Path)
Then I call Shared Step 60932 (Regulatory Information 2 - Microbeads - No)
Then I click continue
Then I click continue
And I call Shared Step 58610 (Confirm Restrict Use - Restrict)
Then I should see the Sustainability Page
Given in the Sustainability page I click Continue
Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: User added Comments Text 58605. !"�$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
Given I click the Home navigation icon
Given I search for the product saved as: TestCase125144
When I click Row Actions for the most recent product returned
Then I click on the Row Action: Access Code
Then Check popup date productID: TestCase125144 productType: Raw Material productAccessCode: 12345678
Given I click close on the Save Changes popup dialog



@ScenarioId:10646
Scenario: [152230] SHA Manager - UPC Retailer and Feed - UPC Details

Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
Given In SHA Manager I set the filter for status to : Assigned
Then In SHA products grid, I find the first product that contains a UPC and navigate to the UPC Retailers and Feed page.
Given I click the first UPC in the UPC Retailer and Feed page
Given In UPC Details popup in UPC Retailer and Feed page I select retailer: 99 Cents
Given In UPC Details popup in Retailer and UPC Feed page I see the following properties and values
| Property         | Value    |
| Weight Size (oz) | Any Data |
| Fluid Size (oz)  | Any Data |
| Gas Size (kg)    | Any Data |
| Gas Name         | Any Data |
Given I close UPC Details popup in Retailer and UPC Feed page
Given I close the current tab
