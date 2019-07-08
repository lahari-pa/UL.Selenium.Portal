@LandingPage
@Login
@Homepage
@Signup
@wercsmart
@NewProduct
@ProductGrid
@DataSummarySheet
@wercsmart
@DocumentAcceptance
@RetailPartners
@run_Flow17
Feature: Flow 17

@tfsdesign
@TReVorId:11596
Scenario: [60017] Lithium Primary/Metal Batteries - RU000612
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC60017
	Given I delete all products with UPC Number: saved as UPC60017
	Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Lithium Primary/Metal Batteries
	Then I save the product information as: TestCase60017
	Given I call Shared Step 59927 (Primary Physical State > Solid only available – Without Water Solubility question)
	Given I call Shared Step 60026 (Additional Product Information - US - Battery - No to all)
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName       | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Lithium perchlorate | 50      | false               | false       |            |
		| manganese dioxide   | 50      | false               | false       |            |
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I call Shared Step 73282 (Lithium Battery Characteristics - Weight in Grams)
	Given I call Shared Step 60096 (Lithium Battery Transportation)
	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Costco
	Given I call Shared Step 60826 (Enter Universal Product Code (UPC) - Battery - Confirm Quantity ) for UPC saved as: UPC60017 with container type: Plastic Container size: 50.0 and quantity: 1000
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I call Shared Step 69422 (Additional Documents to Provide - Upload Product Photo)
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient |
		| Gloves                        | 650                      | 0.400                   | 1.005     | Black      | Acidic | No data available | 7.388                 |
	Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: User added Comments Text 60017. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Lithium Primary/Metal Batteries
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase60017

@TReVorId:11597
Scenario: [60018] Lithium Ion Battery - RU000345
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC60018
	Given I delete all products with UPC Number: saved as UPC60018
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Lithium ion batteries
	Then I save the product information as: TestCase60018
	Given I call Shared Step 59927 (Primary Physical State > Solid only available – Without Water Solubility question)
	Given I call Shared Step 65493 (Additional Product Information - US only - Battery is packaged for Retail Sales - No to everything else - Continue)
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName      | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Lithium hydroxide  | 6.7     | false               | false       |            |
		| Graphite           | 33.2    | false               | false       |            |
		| Ethylene carbonate | 60.1    | false               | false       |            |
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I call Shared Step 54799 (Lithium Battery Characteristics - any data - Happy path)
	Given I call Shared Step 60096 (Lithium Battery Transportation)
	Then I should see the Retailer Page
	And The selected retailers on the Retailer page should be:
		| Retailer                   |
		| No Retailer/No UPC Product |
	Given I click continue
	Then If the UPCs Warning popup is displayed I click OK
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I call Shared Step 69422 (Additional Documents to Provide - Upload Product Photo)
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient |
		| Gloves                        | 650                      | 0.400                   | 1.005     | Black      | Acidic | No data available | 7.388                 |
	Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: User added Comments Text 60018. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: LITHIUM ION BATTERIES
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase60018

Scenario: [104222] Lithium Battery UN38.3 Regulatory Documents to Provide
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Lithium Primary/Metal Batteries
	Then I save the product information as: TestCase104222
	Given I call Shared Step 59927 (Primary Physical State > Solid only available – Without Water Solubility question)
	Given I call Shared Step 65493 (Additional Product Information - US only - Battery is packaged for Retail Sales - No to everything else - Continue)
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName      | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Lithium hydroxide  | 6.7     | false               | false       |            |
		| Graphite           | 33.2    | false               | false       |            |
		| Ethylene carbonate | 60.1    | false               | false       |            |
	Given I call Shared Step 104276 (Enter Regulatory Information - TSCA, CEPA, Not Prop 65)
	Given I call Shared Step 73282 (Lithium Battery Characteristics - Weight in Grams)
	Given I call Shared Step 60096 (Lithium Battery Transportation)
	Then I should see the Retailer Page
	And The selected retailers on the Retailer page should be:
		| Retailer                   |
		| No Retailer/No UPC Product |
	Given I click continue
	Then If the UPCs Warning popup is displayed I click OK
	Given in the Regulatory Documents to Provide page I click Continue
	Then UN38.3 Testing Results should be showing the error messages with no special characters: The U.S.Department of Transportation, as of January 1, 2020, requires that lithium batteries have testing performed in relation to UN38.3.Please provide the testing document from the successful UN38.3 test performed on this battery.If you do not have a test document to provide, you are unable to submit this registration for assessment and your battery will not be available for selection by other suppliers. Should you have further questions regarding this requirement, please contact the WERCSmart Support team for assistance.Or you may refer to the Solution Center article outlining the regulatory requirement.
	And I click the browse button for label: I have an Article Information Sheet (AIS), Technical Data Sheet (TDS), Battery Data Sheet (BDS) to provide. and upload PDF: C:\Dependencies\WERCSmart\testdoc.pdf
	And I click continue
	Then Article Information Sheet (AIS) should not be showing the error messages: Document is required: I have an Article Information Sheet (AIS), Technical Data Sheet (TDS), Battery Data Sheet (BDS) to provide.
	Then Batteries are considered Articles under Global Harmonized Standards. A Safety Data Sheet (SDS) is not required, but may be provided instead of an AIS.  When providing an SDS it must be both U.S. and Canada formats. should be showing the error messages: Select at least one of the options
	Given I set the radio option in section: Batteries are considered Articles under Global Harmonized Standards. A Safety Data Sheet (SDS) is not required, but may be provided instead of an AIS.  When providing an SDS it must be both U.S. and Canada formats. to: I don't need an OSHA-Compliant Safety Data Sheet (SDS) document for this product.
	Then Batteries are considered Articles under Global Harmonized Standards. A Safety Data Sheet (SDS) is not required, but may be provided instead of an AIS.  When providing an SDS it must be both U.S. and Canada formats. should not be showing the error messages: Select at least one of the options
	And I click the browse button for label: Upload UN38.3 Test Document (Required) and upload PDF: C:\Dependencies\WERCSmart\testdoc.pdf
	And I click continue
	Then UN38.3 Testing Results should not be showing the error messages with no special characters: The U.S.Department of Transportation, as of January 1, 2020, requires that lithium batteries have testing performed in relation to UN38.3.Please provide the testing document from the successful UN38.3 test performed on this battery.If you do not have a test document to provide, you are unable to submit this registration for assessment and your battery will not be available for selection by other suppliers. Should you have further questions regarding this requirement, please contact the WERCSmart Support team for assistance.Or you may refer to the Solution Center article outlining the regulatory requirement.
	Then WHMIS-compliant Safety Data Sheet, English and French-Canadian should be showing the error messages: Select at least one of the options
	Given I set the radio option in section: WHMIS-compliant Safety Data Sheet, English and French-Canadian to: I don't need a WHMIS-Compliant document for this product.
	Then WHMIS-compliant Safety Data Sheet, English and French-Canadian should not be showing the error messages: Select at least one of the options
	Given I click continue
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase104222

Scenario: [104227] Lithium Battery UN38.3 Summary Page
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Lithium Primary/Metal Batteries
	Then I save the product information as: TestCase104227
	Given I call Shared Step 59927 (Primary Physical State > Solid only available – Without Water Solubility question)
	Given I call Shared Step 65493 (Additional Product Information - US only - Battery is packaged for Retail Sales - No to everything else - Continue)
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName      | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Lithium hydroxide  | 6.7     | false               | false       |            |
		| Graphite           | 33.2    | false               | false       |            |
		| Ethylene carbonate | 60.1    | false               | false       |            |
	Given I call Shared Step 104276 (Enter Regulatory Information - TSCA, CEPA, Not Prop 65)
	Given I call Shared Step 73282 (Lithium Battery Characteristics - Weight in Grams)
	Given I call Shared Step 60096 (Lithium Battery Transportation)
	Then I should see the Retailer Page
	And The selected retailers on the Retailer page should be:
		| Retailer                   |
		| No Retailer/No UPC Product |
	Given I click continue
	Then If the UPCs Warning popup is displayed I click OK
	And I click the browse button for label: I have an Article Information Sheet (AIS), Technical Data Sheet (TDS), Battery Data Sheet (BDS) to provide. and upload PDF: C:\Dependencies\WERCSmart\testdoc.pdf
	Given I set the radio option in section: Batteries are considered Articles under Global Harmonized Standards. A Safety Data Sheet (SDS) is not required, but may be provided instead of an AIS.  When providing an SDS it must be both U.S. and Canada formats. to: I don't need an OSHA-Compliant Safety Data Sheet (SDS) document for this product.
	And I click the browse button for label: Upload UN38.3 Test Document (Required) and upload PDF: C:\Dependencies\WERCSmart\testdoc.pdf
	Given I set the radio option in section: WHMIS-compliant Safety Data Sheet, English and French-Canadian to: I don't need a WHMIS-Compliant document for this product.
	Given I click continue
	Given I click the browse button for label: Please upload a PDF of the product. and upload PDF: C:\Dependencies\WERCSmart\testdoc.pdf
	Then in the Additional Documents to Provide page I click Continue
	Then in the Optional Reports and Documents Available for Purchase page I click Continue
	Then in the Comments page I click Continue
	Given I click the Summary button in the Data Acceptance window
	And I switch to the Data Summary page
	Then Upload UN38.3 Test Document (Required) document section should be showing the following document: testdoc.pdf
	Given I click the View button for section: Upload UN38.3 Test Document (Required)
	Then I confirm a new window opens displaying the document url: ProductDocument
	Given I close the window that opened
	And I switch to the main window
	And I switch to the Data Summary page
	And I close the Data Summary tab
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase104227
