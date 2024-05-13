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
@SubEnrollment
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:NewProduct
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:Product
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:ProductInformation
@PhysicalAndChemicalProp
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:InventoryStatusProp65
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:Retailer
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:AdditionalDocumentsToProvide
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:OptionalComments
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:RegulatoryDocumentsToProvide
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:TheProduct
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:ToxicityCharacteristicLeachingProcedureTCLP
@StepsPrototype
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:ElectronicEquipment
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:ProductIncludesBattery
@GTINAndUPC
@ProductTemplateLogin
@ProductTemplateSideNavBar
@run_Flow26_Electronic

Feature: [64732] Flow 26 - Electronic

@TestCase:60671
Scenario: [60671] Computer (Combination of Monitor & Desktop) - RU001177

#	Then I navigate to the URL saved in TReVor as: Product Template URL
#	Then In the Product Template Login page, log in with account saved in TReVor as: SHAUser
#	Then In the Side Navigation Bar, click the 'Create Products From Templates' link

	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given If I see the retail partners page I set all data consent tiers to true for all retailers in the top section
	Then The home screen should load
	# ======= Test Setup - Generating + Saving UPC Number and ensuring no duplicates exist ====== #
	#Given I generate a random UPC number and save as: UPC60671
	#Given I delete all products with UPC Number: saved as UPC60671
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Computer (Combination of Monitor & Desktop)
	Then I save the product information as: TestCase60671
	Given I call Shared Step 60935 Product Information - US - Direct Ship - Private Label Only
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	#In the step below, confirm that the following text is visible on the TCLP screen, "Please answer the following question with regards to your product, not the battery contained in your product." on the TCLP screen.
	#Given I call Shared 48367 Product Includes Battery > any type
	Given I call Shared Step 48367 (Product Includes Battery > any type)
	| Battery Type | Manufacturer | Quantity of Batteries per Package | Quantity of Batteries to Operate Product |
	| Alkaline     | <any>        | 6                               | 6                                  |
	Given I call Shared Step 61449 Toxicity Characteristic Leaching Procedure (TCLP) - select No to all - Click Continue - Happy Path
	Given I call Shared Step 58189 Answer Electronic Equipment questions - With Cathode Ray - No to all
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Comment Text
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Computer (Combination of Monitor & Desktop)
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase60671

	#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase60671
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase60671
