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
@RetailPartners
@run_Flow16
@UPC
@PaymentMethods
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:DataAcceptance
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:Retailer
@StepsPrototype
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:NewProduct
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:ProductInformation
@PhysicalAndChemicalProp
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:RegulatoryDocumentsToProvide
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:OptionalComments
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:DataAcceptance
@Ingredients
@LiquidCoreProduct
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:InventoryStatusProp65
@SafetyDataSheetAuthoring
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:Product
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:TheProduct
@RegulatoryInformation3
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:InventoryStatusProp65
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:TransportationDetails1
@GTINAndUPC
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:AdditionalDocumentsToProvide
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:Summary
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:ElectronicEquipment
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:PesticideDetailsUS
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:PurchaseSummary

Feature: Flow21P-Bulb

A short summary of the feature

@TestCase:209162
Scenario: [209162] WERCSmart Portal Test Flow for Type of Product:  Light Bulb - Germicidal Ultra Violet Bulb (RU000962)
	Given I log in with the account saved in TReVor as: ProductAccount
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Then I click the Add Product icon in the Navigation Pane
	Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
	Then in the New Product page, I click Continue
	#Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Herbal or Dietary Supplement
	Given I should see the The Product Page
	Given In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Light Bulbs - Germicidal Ultra Violet Bulb
	Given In the Product Section, set the option in section: 'Type of Product (select)' to: Light Bulbs - Germicidal Ultra Violet Bulb
 	Given in the The Product page I click Continue
	Then I save the product information as: TestCase209162
	Then I generate a random UPC number and save as: UPC209162
	#Then I call Shared Step 234311 (Product Information - Applicable Only to Light Bulbs - Germicidal Ultra Violet (RU000962))
	Given I should see the Product Information Page
	Then In the Product Information Section, confirm section: 'Which best describes your product, including when FIFRA 25(b) Exempt' is displayed
	Then In the Product Information Section, set the option in section: 'Which best describes your product, including when FIFRA 25(b) Exempt' to: Product is intended for preventing, destroying, repelling, or mitigating pests (including insects, rodents, mold, virus, bacteria, and other micro-organisms)
	Then In the Product Information Section, set the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' to select: United States
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then in the Product Information page I click Continue
	#234312 Inventory Status, Prop 65 (US) - Applicable Only to Light Bulbs - Germicidal Ultra Violet (RU000962)
	Given I should see the Inventory Status, Prop 65 (US) Page
	Then In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is exempt from TSCA chemical Inventory listing requirements.
	Then In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page I click Continue
	#Then I call Shared Step 71955 (Answer Electronic Equipment questions - Without Cathode Ray - No to all)
	#234313 Electronic Equipment - Applicable Only to Light Bulbs - Germicidal Ultra Violet (RU000962)
	Given I should see the Electronic Equipment Page
	Then In the Electronic Equipment Section, set the option in section: 'Contains Circuit Board' to: No
	Then In the Electronic Equipment Section, set the option in section: 'Has a LCD or Plasma Display' to: No
	Then in the Electronic Equipment page I click Continue
	#234314 Pesticide Details - U.S. - Applicable Only to Light Bulbs - Germicidal Ultra Violet (RU000962)
	Then I should see the Pesticide Details - U.S. Page
	Then In the Pesticide Details - U.S. Section, in 'Product has an Environmental Protection Agency (EPA) Registration Number' enter No
	Then In the Pesticide Details - U.S. Section, in 'Product has a State Registration' enter No
	Then In the Pesticide Details - U.S. Section, in 'Select the applicable exemption' enter Device based products - Exempt from EPA Registration
	Then in the Pesticide Details - U.S. page I click Continue
	#Then I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: The Home Depot
	Given I should see the Retailer Page
	Then In the Retailer Section, click 'Add Retailers' button
	Then In the Select Retailers window, select retailer: The Home Depot
	Then In the Select Retailers window, click 'Done' button
	Then in the Retailer page I click Continue
	#Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC209162, container type: Plastic Container and size: 3.6
	Given I should see the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Page
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, I click the Add UPC Button
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, for section: 'Provide the product's UPC(s)- including container type and size (ounces)' enter UPC Number: saved as UPC209162 enter Size: 18 and enter Container Type: Plastic Container
	Then In the Global Trade Item Number (GTIN) / Universal Product Code (UPC) Section, verify retailer 'HD' is present under the 'Destination Retailers' column
	Then in the Global Trade Item Number (GTIN) / Universal Product Code (UPC) page I click Continue
	#234317 Additional Documents to Provide - Applicable Only to Light Bulbs - Germicidal Ultra Violet (RU000962)
	Given I should see the Additional Documents to Provide Page
	Then in the Additional Documents to Provide page I click Continue
	Then In the Additional Documents to Provide Section: 'Provide Full Product Label (required)' error message should display: Document is required: Please upload a PDF of the product label (full label).
	Then I save the current window handle to context as: MainWindowHandle
	Then I upload PDF document to Provide Full Product Label (required) field
	Then In the Additional Documents to Provide Section, for section Please upload a PDF of the product label (full label). button Remove should exists
	Then In the Additional Documents to Provide Section, for section Please upload a PDF of the product label (full label). button View should exists
	Then In the Additional Documents to Provide Section, for section Please upload a PDF of the product label (full label). I click button 'View'
	Then In the Additional Documents to Provide Section, after clicking 'View' button I confirm pdf file is downloaded
	Then in the Additional Documents to Provide page I click Continue
	Then I close All the current windows except the Main Window
	#And I call Shared Step 214559 (Optional Reports and Documents Available for Purchase - No Document Purchase is Required - Click Continue (General Shared-Step))
	Given I should see the Optional Reports and Documents Available for Purchase Page
	Then The statement: • Additional documents are not subject to standard two day turnaround. is displayed
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: User added Comments Text 58078. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' is availiable
	Then in the Optional Comments page I click Continue
	#234319 Summary Tab - Data Verification - Applicable Only to Light Bulbs - Germicidal Ultra Violet (RU000962)
	Given I should see the Data Acceptance Page
	Then In the Data Acceptance Section, click 'Summary' button
	Given I switch to the tab with Data Summary page
	Given In the Summary Page, the 'Type of Product (select)' section should be showing the following value: Light Bulbs - Germicidal Ultra Violet Bulb
	Given In the Summary Page, the 'Which best describes your product, including when FIFRA 25(b) Exempt' section should be showing the following value: Product is intended for preventing, destroying, repelling, or mitigating pests (including insects, rodents, mold, virus, bacteria, and other micro-organisms)
	Given In the Summary Page, the 'Select the applicable exemption' section should be showing the following value: Device based products - Exempt from EPA Registration
	Then In the Summary Page, verify table data in column Container Type showing the value: Plastic Container
	Then In the Summary Page, verify table data in column Retailers showing the value: HD
	Then In the Summary Page, the document section Please upload a PDF of the product label (full label). should be showing the following document: testdoc.pdf
	Then In the Summary Page, click the View button for section: Please upload a PDF of the product label (full label).
	Then In the Summary Page, after clicking 'View' button I confirm pdf file is downloaded
	Given I close the tab with Data Summary page
	#Then I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given I should see the Data Acceptance Page
	Then In the Data Acceptance Section, check 'Agreed' checkbox
	Then In the Data Acceptance Section, click 'Accept' button
	#157174 Purchase Summary - Thank You for Registering Message - Click Home to Continue
	Given The Purchase Summary Page is displayed
	Then In the Purchase Summary page message is displayed with text: Thank you for registering your product on WERCSmart for assessment. The retailers may receive your assessment in approximately two (2) business days, if no delays in processing the assessment, and should no data issues arise.
	Then In the Purchase Summary Page, click the 'Home' button
	Then For product saved as: TestCase209162 the status is: Assessment in Progress
	And I filter for the product saved as: TestCase209162
	And I click Row Actions for the first product returned
	Then I click on the Row Action: Discontinue
	Then I confirm Discontinue Product popup contains correct text with product Id saved as: TestCase209162
	Then In the popup with the following title: Discontinue Product I click the Yes button
	Then I confirm Date Discontinued contains today's date for product saved as: TestCase209162


