@Shared
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
@RegulatoryDocsToProvide
@ignore
@run_Flow17
@StepsPrototype
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:NewProduct
@PhysicalAndChemicalProp
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:OptionalComments
@SafetyDataSheetAuthoring
@AdditionalDocsContactInfo

Feature: Flow 17

@TestCase:60018
Scenario: [60018] Lithium Ion Battery - RU000345
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC60018
	Given I delete all products with UPC Number: saved as UPC60018
#	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration '
	Then in the New Product page, I click Continue

	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Lithium Ion Battery
	Then I save the product information as: TestCase60018
	Given I call Shared Step 65493 (Product Information - US only - Battery is packaged for Retail Sales - No to everything else - Continue)
	#Given I call Shared Step 59927 (Primary Physical State > Solid only available – Without Water Solubility question)
	Then I should be on the Physical and Chemical Properties Page
	And In the Physical and Chemical Properties Section, the section: 'Primary Physical State' should be showing the option: Solid
	And In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
	And In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Then in the Physical and Chemical Properties page, I click Continue

	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName      | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Lithium hydroxide  | 6.7     | false               | false       |            |
		| Graphite           | 33.2    | false               | false       |            |
		| Ethylene carbonate | 60.1    | false               | false       |            |
	Given I should see the Formulation > Batteries Page
	Then I set the Consent to Tier 2.1, 2.2, 4.2 Data Uses option to: Granted
	Given I click continue
	Given I call Shared Step 104276 (Enter Regulatory Information - TSCA, CEPA, Not Prop 65)
	Given I call Shared Step 54799 (Lithium Battery Characteristics - any data - Happy path)
	Given I call Shared Step 60096 (Lithium Battery Transportation)
	Then I should see the Retailer Page
	And The selected retailers on the Retailer page should be:
		| Retailer                   |
		| No Retailer/No UPC Product |
	Given I click continue
	Then If the UPCs Warning popup is displayed I click OK
	Given I call Shared Step 104662 - Regulatory Documents to Provide - Lithium Batteries - US and Canada - Request authoring for both
	Given I call Shared Step 69422 (Additional Documents to Provide - Upload Product Photo)
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
#	And I call Shared Step 64097 - Additional Documents -> Contact Information - Add any Name, address, phone and emergency phone - Happy Path
	Then I should be on the Additional Documents -> Contact Information Page
	And In the Additional Documents -> Contact Information section, for section: 'Manufacturer Name' enter text: Manufacturer
	And In the Additional Documents -> Contact Information section, for section: 'Address' enter text: Address
	And In the Additional Documents -> Contact Information section, for section: 'Phone' enter text: Phone
	And In the Additional Documents -> Contact Information section, for section: 'Emergency Phone' enter text: Emergency Phone
	Then in the Additional Documents -> Contact Information page, I click Continue

#	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
#		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient |
#		| Gloves                        | 650                      | 0.400                   | 1.005     | Black      | Acidic | No data available | 7.388                 |
	Then I should be on the Safety Data Sheet Authoring - Additional Data (Optional) Page
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Personal Protection Equipment Recommended (select)' to: Gloves
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Autoignition Temperature (°C)' enter text: 650
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Minimum Ignition Energy (mJ)' enter text: 0.400
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Viscosity' enter text: 1.005
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Appearance' to: Black
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor' to: Acidic
	And In the Safety Data Sheet Authoring - Additional Data (Optional), set the option in section: 'Odor Threshold' to: No data available
	And In the Safety Data Sheet Authoring - Additional Data (Optional), for the section: 'Partition Coefficient' enter text: 7.388
	Then in the Safety Data Sheet Authoring - Additional Data (Optional) page, I click Continue

	#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: User added Comments Text 60018. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Lithium Ion Battery
	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase60018
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase60018
@TestCase:104222
Scenario: [104222] Lithium Battery UN38.3 Regulatory Documents to Provide
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
#	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration '
	Then in the New Product page, I click Continue

	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Lithium Primary/Metal Batteries
	Then I save the product information as: TestCase104222
	Given I call Shared Step 65493 (Product Information - US only - Battery is packaged for Retail Sales - No to everything else - Continue)
	#Given I call Shared Step 59927 (Primary Physical State > Solid only available – Without Water Solubility question)
	Then I should be on the Physical and Chemical Properties Page
	And In the Physical and Chemical Properties Section, the section: 'Primary Physical State' should be showing the option: Solid
	And In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
	And In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Then in the Physical and Chemical Properties page, I click Continue

	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName      | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Lithium hydroxide  | 6.7     | false               | false       |            |
		| Graphite           | 33.2    | false               | false       |            |
		| Ethylene carbonate | 60.1    | false               | false       |            |
	Given I should see the Formulation > Batteries Page
	Then I set the Consent to Tier 2.1, 2.2, 4.2 Data Uses option to: Granted
	Given I click continue
	Given I call Shared Step 104276 (Enter Regulatory Information - TSCA, CEPA, Not Prop 65)
	Given I call Shared Step 73282 (Lithium Battery Characteristics - Weight in Grams)
	Given I call Shared Step 60096 (Lithium Battery Transportation)
	Then I should see the Retailer Page
	And The selected retailers on the Retailer page should be:
		| Retailer                   |
		| No Retailer/No UPC Product |
	Given I click continue then if the 'UPCs Warning' popup is displayed I click 'OK'
	Given in the Regulatory Documents to Provide page I click Continue
	Then In the Regulatory Documents to Provide Page I check that the input field with label: I have an Article Information Sheet (AIS), Technical Data Sheet (TDS), Battery Data Sheet (BDS) to provide. is shown as Red
	Then In the Regulatory Documents to Provide Page I check that the input field with label: Label in both French and English is shown as Red
	Then In the Regulatory Documents to Provide Page I check that the input field with label: Upload UN38.3 Test Document (Required) is shown as Red
	Then UN38.3 Testing Results should be showing the error messages with no special characters: The U.S.Department of Transportation, as of January 1, 2020, requires that lithium batteries have testing performed in relation to UN38.3.Please provide the testing document from the successful UN38.3 test performed on this battery.If you do not have a test document to provide, you are unable to submit this registration for assessment and your battery will not be available for selection by other suppliers. Should you have further questions regarding this requirement, please contact the WERCSmart Support team for assistance.Or you may refer to the Solution Center article outlining the regulatory requirement.
	And I click the browse button for label: I have an Article Information Sheet (AIS), Technical Data Sheet (TDS), Battery Data Sheet (BDS) to provide. and upload PDF: UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf
	And I click continue	
	Then Article Information Sheet (AIS) should not be showing the error messages: Document is required: I have an Article Information Sheet (AIS), Technical Data Sheet (TDS), Battery Data Sheet (BDS) to provide.
	#Then Batteries are considered Articles under Global Harmonized Standards. A Safety Data Sheet (SDS) is not required, but may be provided instead of an AIS.  When providing an SDS it must be both U.S. and Canada formats. should be showing the error messages: Select at least one of the options
	Given I set the radio option in section: Batteries are considered Articles under Global Harmonized Standards. A Safety Data Sheet (SDS) is not required, but may be provided instead of an AIS.  When providing an SDS it must be both U.S. and Canada formats. to: I don't need an OSHA-Compliant Safety Data Sheet (SDS) document for this product.
	Then Batteries are considered Articles under Global Harmonized Standards. A Safety Data Sheet (SDS) is not required, but may be provided instead of an AIS.  When providing an SDS it must be both U.S. and Canada formats. should not be showing the error messages: Select at least one of the options
	And I click the browse button for label: Upload UN38.3 Test Document (Required) and upload PDF: UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf
	And I click continue
	Then UN38.3 Testing Results should not be showing the error messages with no special characters: The U.S.Department of Transportation, as of January 1, 2020, requires that lithium batteries have testing performed in relation to UN38.3.Please provide the testing document from the successful UN38.3 test performed on this battery.If you do not have a test document to provide, you are unable to submit this registration for assessment and your battery will not be available for selection by other suppliers. Should you have further questions regarding this requirement, please contact the WERCSmart Support team for assistance.Or you may refer to the Solution Center article outlining the regulatory requirement.
	Then WHMIS-compliant Safety Data Sheet, English and French-Canadian should be showing the error messages: Select at least one of the options
	Given I set the radio option in section: WHMIS-compliant Safety Data Sheet, English and French-Canadian to: I don't need a WHMIS Compliant SDS
	Then WHMIS-compliant Safety Data Sheet, English and French-Canadian should not be showing the error messages: Select at least one of the options
	And I click the browse button for label: Label in both French and English and upload PDF: UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf
	Then In the Regulatory Documents to Provide Page I check that the input field with label: I have an Article Information Sheet (AIS), Technical Data Sheet (TDS), Battery Data Sheet (BDS) to provide. is shown as Green
	Then In the Regulatory Documents to Provide Page I check that the input field with label: Label in both French and English is shown as Green
	Then In the Regulatory Documents to Provide Page I check that the input field with label: Upload UN38.3 Test Document (Required) is shown as Green
	Given I click continue
	Given I should see the Additional Documents to Provide Page
	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase104222
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase104222

@TestCase:104227
Scenario: [104227] Lithium Battery UN38.3 Summary Page
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
#	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration '
	Then in the New Product page, I click Continue

	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Lithium Primary/Metal Batteries
	Then I save the product information as: TestCase104227
	Given I call Shared Step 65493 (Product Information - US only - Battery is packaged for Retail Sales - No to everything else - Continue)
#	Given I call Shared Step 59927 (Primary Physical State > Solid only available – Without Water Solubility question)
	Then I should be on the Physical and Chemical Properties Page
	And In the Physical and Chemical Properties Section, the section: 'Primary Physical State' should be showing the option: Solid
	And In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
	And In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Then in the Physical and Chemical Properties page, I click Continue	

	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName      | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Lithium hydroxide  | 6.7     | false               | false       |            |
		| Graphite           | 33.2    | false               | false       |            |
		| Ethylene carbonate | 60.1    | false               | false       |            |
	Given I should see the Formulation > Batteries Page
	Then I set the Consent to Tier 2.1, 2.2, 4.2 Data Uses option to: Granted
	Given I click continue
	Given I call Shared Step 104276 (Enter Regulatory Information - TSCA, CEPA, Not Prop 65)
	Given I call Shared Step 73282 (Lithium Battery Characteristics - Weight in Grams)
	Given I call Shared Step 60096 (Lithium Battery Transportation)
	Then I should see the Retailer Page
	And The selected retailers on the Retailer page should be:
		| Retailer                   |
		| No Retailer/No UPC Product |
	Given I click continue then if the 'UPCs Warning' popup is displayed I click 'OK'
	And I click the browse button for label: I have an Article Information Sheet (AIS), Technical Data Sheet (TDS), Battery Data Sheet (BDS) to provide. and upload PDF: UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf
	Given I set the radio option in section: Batteries are considered Articles under Global Harmonized Standards. A Safety Data Sheet (SDS) is not required, but may be provided instead of an AIS.  When providing an SDS it must be both U.S. and Canada formats. to: I don't need an OSHA-Compliant Safety Data Sheet (SDS) document for this product.
	And I click the browse button for label: Upload UN38.3 Test Document (Required) and upload PDF: UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf
	Given I set the radio option in section: WHMIS-compliant Safety Data Sheet, English and French-Canadian to: I don't need a WHMIS Compliant SDS
	And I click the browse button for label: Label in both French and English and upload PDF: UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf
	Given I click continue
	Given I should see the Additional Documents to Provide Page
	Given I click the browse button for label: Please upload a PDF of the product. and upload PDF: UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf
	Then in the Additional Documents to Provide page I click Continue
	Then in the Optional Reports and Documents Available for Purchase page I click Continue
	#And I call Shared Step 64097 - Additional Documents -> Contact Information - Add any Name, address, phone and emergency phone - Happy Path
	#Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		#| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient |
		#| Gloves                        | 650                      | 0.400                   | 1.005     | Black      | Acidic | No data available | 7.388                 |
	Then in the Comments page I click Continue
	Then I save the current window handle to context as: MainWindowHandle
	Given I click the Summary button in the Data Acceptance window
	And I switch to the Data Summary page
	Then Upload UN38.3 Test Document (Required) document section should be showing the following document: testdoc.pdf	
	Then I Delete the file with name: testdoc.pdf from the downloads folder
	Given I click the View button for section: Upload UN38.3 Test Document (Required)
	Then I confirm that a file is produced called testdoc.pdf and save as savedas56219PDF
	Then I Check that the pdf file saved as: savedas56219PDF contains the text: If your product contains any kind of chemical	
	Then I switch to the window with handle saved as: MainWindowHandle
	Then I delete the file saved as savedas56219PDF
	Then I close All the current windows except the Main Window
	#Then I confirm a new window opens displaying the document url: ProductDocument
	#Given I close the window that opened
	And I switch to Data Acceptance page
	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase104227
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase104227
