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
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:ProductInformation
@run_Flow25
@StepsPrototype
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:NewProduct
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:OptionalComments
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:InventoryStatusProp65
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:Retailer
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:ElectronicEquipment


Feature: Flow 25

@TestCase:60642
Scenario: [60642] Engine Parts and Components with Battery Included - RU001430

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

Given I generate a random UPC number and save as: UPC60642

Given I delete all products with UPC Number: saved as UPC60642

#Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
Then I click the Add Product icon in the Navigation Pane
Then In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration'
Then in the New Product page, I click Continue

Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Engine Parts and Components with Battery Included

Then I save the product information as: TestCase60642

#Given I call Shared Step 60935 (Product Information - US - Direct Ship - Private Label Only)
	Given I should see the Product Information Page
	Given In the Product Information Section, set the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' to select: United States
	Given In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Given In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Given in the Product Information page I click Continue

#Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
Given I should see the Inventory Status, Prop 65 (US) Page
	Then In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	Then In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page I click Continue

Then I should see battery manufacturer message: Important: Prior to registering your battery-containing product, the battery manufacturer must first register the contained battery.

Given I call Shared Step 48367 (Product Includes Battery > any type)
| Battery Type | Manufacturer | Quantity of Batteries per Package | Quantity of Batteries to Operate Product |
| Alkaline     | <any>        | 6                               | 6                                  |

Given I click continue

Given I call Shared Step 48369 (Toxicity Characteristics Leaching Procedure (TCLP) - No to ALL With Copper)

	#And I call Shared Step 71955 (Answer Electronic Equipment questions - Without Cathode Ray - No to all)
	And I should see the Electronic Equipment Page
	And In the Electronic Equipment Section, set the option in section: 'Contains Circuit Board' to: No
	And In the Electronic Equipment Section, set the option in section: 'Has a LCD or Plasma Display' to: No
	And in the Electronic Equipment page I click Continue
#Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Genuine Parts
	Then I should be on the Retailer Page
	And In the Retailer Section, click 'Add Retailers' button
	And In the Select Retailers window, select retailer: Genuine Parts
	And In the Select Retailers window, click 'Done' button
	Then in the Retailer page, I click Continue


Then I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC60642, container type: Cardboard and size: 33

#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: User added Comments Text 60642. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Engine Parts and Components with Battery Included

#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase60642
	Then I navigate to the Home Page
	Then In the Product Grid, delete the product saved as: TestCase60642
