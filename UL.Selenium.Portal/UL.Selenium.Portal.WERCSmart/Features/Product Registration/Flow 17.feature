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
@run_Flow17
Feature: Flow 17

@tfsdesign
@ScenarioId:701
Scenario: [60017] Lithium Primary/Metal Batteries - RU000612
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC60017
	Given I delete all products with UPC Number: saved as UPC60017
	Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Lithium Primary/Metal Batteries
	Then I save the product information as: TestCase60017
	Given I call Shared Step 59927 (Primary Physical State > Solid only available – Without Water Solubility question)
	Given I call Shared Step 65493 (Additional Product Information - US only - Battery is packaged for Retail Sales - No to everything else - Continue)
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName       | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Lithium perchlorate | 50      | false               | false       |            |
		| manganese dioxide   | 50      | false               | false       |            |
	Given I should see the Formulation > Batteries Page
	Then I set the Consent to Tier 2.1, 2.2, 4.2 Data Uses option to: Granted
	Given I click continue
	Given I call Shared Step 104276 (Enter Regulatory Information - TSCA, CEPA, Not Prop 65)
	Given I call Shared Step 73282 (Lithium Battery Characteristics - Weight in Grams)
	Given I call Shared Step 60096 (Lithium Battery Transportation)
	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Walgreens
	Given I call Shared Step 60826 (Enter Universal Product Code (UPC) - Battery - Confirm Quantity ) for UPC saved as: UPC60017 with container type: Plastic Container size: 50.0 and quantity: 1000
	Given I set the radio option in section: Batteries are considered Articles under Global Harmonized Standards. A Safety Data Sheet (SDS) is not required, but may be provided instead of an AIS.  When providing an SDS it must be both U.S. and Canada formats. to: I need an OSHA-Compliant Safety Data Sheet (SDS) authored for this product.
	Given I click the browse button for label: Upload UN38.3 Test Document (Required) and upload PDF: C:\Dependencies\WERCSmart\testdoc.pdf
	Given I set the radio option in section: WHMIS-compliant Safety Data Sheet, English and French-Canadian to: I need a WHMIS-Compliant bilingual Safety Data Sheet (SDS) authored for this product.
	Given I click the browse button for label: Label in both French and English and upload PDF: C:\Dependencies\WERCSmart\testdoc.pdf
	Then In the regulatory documents to provide screen if I see the question 'I confirm I am providing the most current Safety Data Sheet (SDS)' I tick confirm
	Given I click continue
	Given I call Shared Step 69422 (Additional Documents to Provide - Upload Product Photo)
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	And I call Shared Step 64097 - Additional Documents -> Contact Information - Add any Name, address, phone and emergency phone - Happy Path
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient |
		| Gloves                        | 650                      | 0.400                   | 1.005     | Black      | Acidic | No data available | 7.388                 |
	Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: User added Comments Text 60017. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Lithium Primary/Metal Batteries
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase60017

@ScenarioId:702
Scenario: [60018] Lithium Ion Battery - RU000345
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC60018
	Given I delete all products with UPC Number: saved as UPC60018
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Lithium Ion Battery
	Then I save the product information as: TestCase60018
	Given I call Shared Step 59927 (Primary Physical State > Solid only available – Without Water Solubility question)
	Given I call Shared Step 65493 (Additional Product Information - US only - Battery is packaged for Retail Sales - No to everything else - Continue)
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
	And I call Shared Step 64097 - Additional Documents -> Contact Information - Add any Name, address, phone and emergency phone - Happy Path
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient |
		| Gloves                        | 650                      | 0.400                   | 1.005     | Black      | Acidic | No data available | 7.388                 |
	Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: User added Comments Text 60018. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Lithium Ion Batteries
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase60018

@ScenarioId:699
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
	Given I set the radio option in section: WHMIS-compliant Safety Data Sheet, English and French-Canadian to: I don't need a WHMIS Compliant SDS
	Then WHMIS-compliant Safety Data Sheet, English and French-Canadian should not be showing the error messages: Select at least one of the options
	Then In the Regulatory Documents to Provide Page I check that the input field with label: I have an Article Information Sheet (AIS), Technical Data Sheet (TDS), Battery Data Sheet (BDS) to provide. is shown as Green
	Then In the Regulatory Documents to Provide Page I check that the input field with label: Label in both French and English is shown as Green
	Then In the Regulatory Documents to Provide Page I check that the input field with label: Upload UN38.3 Test Document (Required) is shown as Green
	Then In the regulatory documents to provide screen if I see the question 'I confirm I am providing the most current Safety Data Sheet (SDS)' I tick confirm
	Given I click continue
	Given I should see the Additional Documents to Provide Page
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase104222

@ScenarioId:700
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
	And I click the browse button for label: I have an Article Information Sheet (AIS), Technical Data Sheet (TDS), Battery Data Sheet (BDS) to provide. and upload PDF: C:\Dependencies\WERCSmart\testdoc.pdf
	Given I set the radio option in section: Batteries are considered Articles under Global Harmonized Standards. A Safety Data Sheet (SDS) is not required, but may be provided instead of an AIS.  When providing an SDS it must be both U.S. and Canada formats. to: I don't need an OSHA-Compliant Safety Data Sheet (SDS) document for this product.
	And I click the browse button for label: Upload UN38.3 Test Document (Required) and upload PDF: C:\Dependencies\WERCSmart\testdoc.pdf
	Given I set the radio option in section: WHMIS-compliant Safety Data Sheet, English and French-Canadian to: I don't need a WHMIS Compliant SDS
	Then In the regulatory documents to provide screen if I see the question 'I confirm I am providing the most current Safety Data Sheet (SDS)' I tick confirm
	Given I click continue
	Given I should see the Additional Documents to Provide Page
	Given I click the browse button for label: Please upload a PDF of the product. and upload PDF: C:\Dependencies\WERCSmart\testdoc.pdf
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
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase104227

@tfs_design
# Test case can be found at the following path:
# NetProjects10\WercsSmart Portal\WERCSmart\Product Registration\Flow 17 - Lith bat
Scenario: [103572] Lithium Battery UN 38.3 Auto-Recertification - Update Data
	Given I generate a random UPC number and save as: UPC103572
	And I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	And I save the product information as: TestCase103572
	# In the shared step below select Lithium Primary/Metal Batteries as your product type
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Lithium Primary/Metal Batteries
	And I call Shared Step 26897 (Product Characteristics - Solid only available - continue)
	And I call Shared Step 65493 (Additional Product Information - US only - Battery is packaged for Retail Sales - No to everything else - Continue)
	# Use Lithium in the shared step below
	And I call Shared Step 29181 (Ingredients - add any chemical) with name: Lithium
	And I call Shared Step 104276 (Enter Regulatory Information - TSCA, CEPA, Not Prop 65)
	And I call Shared Step 103412 - Lithium Primary/Metal Battery Characteristics - any data - Happy path
	And I call Shared Step 60096 (Lithium Battery Transportation)
	And in the Retailer page I click Continue
	And I choose ok in the UPCs Warning modal window
	And I click the browse button for label: I have an Article Information Sheet and upload PDF: C:\Dependencies\WERCSmart\testdoc.pdf
	#I On the Regulatory Documents to Provide screen, upload a document into the Article Information Sheet (AIS) section.
	And in Regulatory Documents to Provide I select: I don't need an OSHA-Compliant Safety Data Sheet for the: Batteries are considered Articles under Global Harmonized Standards question
	And I click the browse button for label: Upload UN38.3 Test Document and upload PDF: C:\Dependencies\WERCSmart\testdoc.pdf
	And in Regulatory Documents to Provide I select: Request to author for the: WHMIS-compliant Safety Data Sheet, English and French-Canadian question
	And I click the browse button for label: Label in both French and English and upload PDF: C:\Dependencies\WERCSmart\testdoc.pdf
	And in the Regulatory Documents page I click Continue
	And I call Shared Step 69422 (Additional Documents to Provide - Upload Product Photo)
	And in the Optional Reports and Documents Available for Purchase page I click Continue
	And I call Shared Step 64097 - Additional Documents -> Contact Information - Add any Name, address, phone and emergency phone - Happy Path
	And I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient |
		| Gloves                        | 650                      | 0.400                   | 1.005     | Black      | Acidic | No data available | 7.388                 |
	And in the Comments page I click Continue
	And I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	And I click the Home navigation icon
	And [Shared Step 103255 - Login to SHA with your known user account and password]
	And I Use the shared step below to search for your battery product
	And I call Shared Step 49841 (SHA - Search for exact WPS ID in (.*) Status for saved as: TestCase103572)
	And I Confirm your product is shown in the Submitted status
	And I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase103572)
	And I call Shared Step 49841 (SHA - Search for exact WPS ID in (.*) Status for saved as: TestCase103572)
	And I Confirm your product is in the Assigned status.
	And I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase103572)
	And I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase103572)
	And [Shared Step 79500 - WPS Studio - PD+ - set all data and publish using rule and doc queue - CKLT and SBCS only]
	And I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase103572)
	And I call Shared Step 49841 (SHA - Search for exact WPS ID in (.*) Status for saved as: TestCase103572)
	And I Confirm the product is in the completed status
	And [Shared Step 103591 - SHA - Add Battery to BATTREF table]
	And I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	# And I Enter "Camera w/Battery" in Type of Product smart search field
	And I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Camera w/Battery
	And I call Shared Step 70393 (Additional Product Information - With marketed for use by a Child - Direct Ship - Private Label questions only)
	And I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	And I In the below step, choose the battery you added to the BATTREF table in the Manufacturer drop down.
	And [Shared Step 103977 - Product Includes Battery > Lithium]
	And I call Shared Step 48369 (Toxicity Characteristics Leaching Procedure (TCLP) - No to ALL With Copper)
	And I call Shared Step 58189 (Answer Electronic Equipment questions - With Cathode Ray - No to all)
	And I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: (.*)
	And I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC103572, container type: (.*) and size: (.*)
	And I call Shared Step 57883 (Comments - Happy Path) and enter the comment: (.*)
	And I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	And I Click Home
	And [Shared Step 103255 - Login to SHA with your known user account and password]
	And I Use the shared step below to search for your BCP that you just created
	And I call Shared Step 49841 (SHA - Search for exact WPS ID in (.*) Status for saved as: TestCase103572)
	And I Confirm your product is shown in the Submitted Status
	And I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase103572)
	And I call Shared Step 49841 (SHA - Search for exact WPS ID in (.*) Status for saved as: TestCase103572)
	And I Confirm your product is in the Assigned status.
	And I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase103572)
	And I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase103572)
	And [Shared Step 79500 - WPS Studio - PD+ - set all data and publish using rule and doc queue - CKLT and SBCS only]
	And I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase103572)
	And I call Shared Step 49841 (SHA - Search for exact WPS ID in (.*) Status for saved as: TestCase103572)
	And I Confirm the product is in the completed status
	And [Shared Step 103592 - SHA - Remove Battery from BATTREF table]
	And I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	And I Filter for your BCP Product
	And I Confirm the product is shown in the Completed status
	And I Click the ... icon in the Actions column for your product
	And I Click the Update Data link
	And I Select Yes
	And I Confirm you see the The Product page with your product shown
	And I Confirm the Error Report button is shown on the left hand side of the screen below the Additional Product Information step link
	And I Click the Error Report Button
	And I Confirm that you get the auto-recertification popup with the correct text for UN 38.3: UN38.3 Testing ResultsLithium Battery included in Registration requires UN38.3 Testing DocumentThe battery-containing product registration contains a lithium battery type. As of January 1, 2020, under U.S. Department of Transportation regulations, it is required that lithium batteries undergo UN38.3 testing. The battery associated with your registration does not have the proper UN38.3 test document associated with the registration. Please contact your battery manufacturer and be sure they update their WERCSmart registration to include the required UN38.3 test document. Once this is resolved by your battery supplier, you may then proceed with your registration. Until then, you are unable to process any further updates.If your battery provider has given you an alternative battery registration to use, where a UN38.3 Test document is present, please update your registration with the revised battery and proceed with your submission.
	And I Click on the Home button
	And I Filter for your BCP Product
	And I Confirm that your product is in Needs Your Attention status
	Then I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase103572

