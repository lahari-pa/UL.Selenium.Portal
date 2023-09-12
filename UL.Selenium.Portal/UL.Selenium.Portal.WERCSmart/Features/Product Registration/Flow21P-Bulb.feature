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

Feature: Flow21P-Bulb

A short summary of the feature

@TestCase:209162
Scenario: [209162] WERCSmart Portal Test Flow for Type of Product:  Light Bulb - Germicidal Ultra Violet Bulb (RU000962)
Given I log in with the account saved in TReVor as: ProductAccount
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Light Bulbs - Germicidal Ultra Violet Bulb
Then I save the product information as: TestCase209162
Then I generate a random UPC number and save as: UPC209162
Then I call Shared Step 234311 (Product Information - Applicable Only to Light Bulbs - Germicidal Ultra Violet (RU000962))
Then I call Shared Step 57571b (Enter Regulatory Information - Not Prop 65):
| TSCA																		 | Prop 65 |
| This product is exempt from TSCA chemical Inventory listing requirements.  | No      |
Then I call Shared Step 71955 (Answer Electronic Equipment questions - Without Cathode Ray - No to all)
Then I should see the Pesticide Details - U.S. Page
Given I set the Product has an Environmental Protection Agency (EPA) Registration Number option to: No
Given I set the Product has a State Registration option to: No
And I set the Select the applicable exemption option to: Device based products - Exempt from EPA Registration
Then in the Pesticide Details - U.S. page I click Continue
Then I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: The Home Depot
Then I call Shared Step 57960a (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only - Do Not Click Continue) for UPC: saved as UPC209162, container type: Plastic Container and size: 18
Then I confirm that retailer "HD" is present under the 'Destination Retailers' column in the UPC table
Then in the Global Trade Item Number (GTIN) / Universal Product Code (UPC) page I click Continue
Then I call shared step 65961 (Additional Documents to Provide - Upload Full Product Label - Continue.
Then in the Optional Reports and Documents Available for Purchase page I click Continue
Then in the Optional Comments page I click Continue
Then I call Shared Step 214662 (Summary Tab - Data Verification - Applicable Only to Bonding Agent (RU000023))
	| Section                                              | Value             |
	| Type of Product                                      | Light Bulbs - Germicidal Ultra Violet Bulb     |
	| FIFRA 25(b) Exempt                                   | Product is intended for preventing, destroying, repelling, or mitigating pests (including insects, rodents, mold, virus, bacteria, and other micro-organisms)  |
	| Container Type                                       | Plastic Container |
	| Retailers                                            | HD                |
Then I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
Then In the Thank You screen I confirm the following statement is shown: Thank you for registering your product on WERCSmart for assessment. The retailers may receive your assessment in approximately two (2) business days, if no delays in processing the assessment, and should no data issues arise.
Then In the Thank You screen I click Home
Then For product saved as: TestCase209162 the status is: Assessment in Progress
And I filter for the product saved as: TestCase209162
And I click Row Actions for the first product returned
Then I click on the Row Action: Discontinue
Then I confirm Discontinue Product popup contains correct text with product Id saved as: TestCase209162
#Then I confirm that I see the following text in the modal window popup: Discontinuing your registration does not obsolete the registration. Discontinue means you are no longer maintaining the registration data or manufacturing this product. Retailers may have inventory of this product on hand and you may need the data for historical purposes. Discontinuing does not impact the ability to obsolete the registration, when time permits.
Then In the popup with the following title: Discontinue Product I click the Yes button

