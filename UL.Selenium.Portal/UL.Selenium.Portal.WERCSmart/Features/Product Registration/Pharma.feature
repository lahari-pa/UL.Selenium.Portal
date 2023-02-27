@PaymentMethods
@Shared
@Login
@Homepage
@ProductGrid
@ForwardProductRegistration
@NewProduct
@RetailPartners
@Pharma
@DocumentAcceptance
@UPC
@run_Pharma
Feature: Pharma

@TestCase:128085
Scenario: [128085] Pharma - Prescription Pharmaceutical - Aerosol Product

	Given I log in with the account saved in TReVor as: PharmaAccount
	Given I click the Prescription Pharmaceutical icon in the QuickLinks Pane
	Given I generate a random UPC number and save as: UPC128085
	Given I click continue
	Then I should see the Product Type Page
	Then I set 'Product Name' to: Prescription Pharmaceutical, Aerosol
	Then I set 'Type of Product' to: Prescription Pharmaceutical, Aerosol
	Then I click continue
	Given I enter the NDC number: 13630-0089-3
	Then I save the product information as: TestCase128085
	Then I click continue
	Then I click continue
	Given I fill all empty fields in the SPL Information screen
	Then I click continue
	And I set the Secondary Physical State to be: Aerosol
	And I set the pH field to: 5
	And I set the Select the best Water Solubility description to be: Dispersible
	And I set the When the product has a flammable propellant, or contains ingredients with a flash point below 60⁰C then field to: This product is classified as a D001 Hazardous Waste under RCRA (as per Section 13 or 15 of the SDS).
	Then I click continue
	Then I click continue
	Given I fill all empty fields in the Pharma Ingredients screen
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
	#Then I should not see the ingredient obsolete error message
	Given I set the Should this product be refrigerated for transport or storage? option to: No
	Then I click continue
	Given I set the Is the product regulated for transport (before exceptions or exemptions) option to exactly match: Yes, Agree
	And I set the Select applicable modes of transport for which you classify the product. field to: DOT
	And I select option: Yes, Shipped with Limited quantity under section: Select applicable modes of transport for which you classify the product. and subsection: DOT
	And I select option: Yes, Shipped with Consumer Commodity under section: Select applicable modes of transport for which you classify the product. and subsection: DOT
	Then I click continue
	And I set the UN Number field to: UN1950
	And I set the Proper Shipping Name option to: Aerosols, flammable, n.o.s.
	And I set the Select Hazard Class (if available) option to: 2.1
	Then I click continue
	Given In the Retailers tab, I select the first Vendor option for retailer: Wal-Mart/SAM'S CLUB
	Then I click continue
	Then I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC128085, container type: Aerosol Can – Plastic and size: 12
	When I click continue
	When I click continue
	Then Upload Full Product Label (required) (For private label products please upload a generic label that is not retailer-specific.) should be showing the error messages: Document is required: Product Label
	And I call Shared Step 60567 (Upload Product Label only) for section: Upload Full Product Label (required)
	When I click continue
	Given I call Shared Step 59042 (Browse for File > select > click Open - Happy Path) for document type: Upload Full Product Label (required) (For private label products please upload a generic label that is not retailer-specific.) and file: UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf
	When I click continue
#When I click continue
#Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
#And In the Purchase Summary screen I confirm the Purchase Summary header is displayed
#Then In the Thank You screen I confirm the following statement is shown: Thank you for registering your product on WERCSmart for assessment. The retailers may receive your assessment in approximately two (2) business days, if no delays in processing the assessment, and should no data issues arise.
#And I navigate to the home page
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase128085


@TestCase:127870
Scenario: [127870] Pharma - Tablet or Capsule Count Field is Available for Solid - Solid Gel Consistency

	Given I log in with the account saved in TReVor as: ProductAccount
	Given I click the Prescription Pharmaceutical icon in the QuickLinks Pane
	Given I generate a random UPC number and save as: UPC127870
	Given I click continue
	Then I should see the Product Type Page
	Then I set 'Product Name' to: prescription pharmaceutical, solid
	Then I set 'Type of Product' to: prescription pharmaceutical, solid
	Then I click continue
	Given I enter the NDC number: 10866-0885-2
	Then I save the product information as: TestCase127870
	Then I click continue
	Then I click continue
	Given I fill all empty fields in the SPL Information screen
	Then I click continue
	And I set the Secondary Physical State to be: Solid
	And I set the When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5? option to: No
	And I set the Select the best Water Solubility description to be: Dispersible
	Then I click continue
	Then I click continue
	Given I fill all empty fields in the Pharma Ingredients screen
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
	Given I set the Should this product be refrigerated for transport or storage? option to: No
	Then I click continue
	Given I set the Is the product regulated for transport (before exceptions or exemptions) option to exactly match: No, not regulated
	Then I click continue
	Given In the Retailers tab, I select the first Vendor option for retailer: Wal-Mart/SAM'S CLUB
	Then I click continue
	Then I call Shared Step 131303 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC127870, container type: Plastic Container, capsule count: 50 and size: 1
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase127870









@TestCase:127970
Scenario: [127970] Pharma - Regulatory Documents to Provide and Additional Documents to Provide
	Given I log in with the account saved in TReVor as: ProductAccount
	Given I click the Prescription Pharmaceutical icon in the QuickLinks Pane
	Given I generate a random UPC number and save as: UPC127970
	Given I click continue
	Then I should see the Product Type Page
	Then I set 'Product Name' to: Prescription Pharmaceutical, Solid
	Then I set 'Type of Product' to: Prescription Pharmaceutical, Solid
	Then I click continue
	Given I enter the NDC number: 10866-0885-2
	Then I save the product information as: TestCase127970
	Then I click continue
	Then I click continue
	Given I fill all empty fields in the SPL Information screen
	Then I click continue
	And I set the Secondary Physical State to be: Solid
	And I set the When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5? option to: No
	And I set the Select the best Water Solubility description to be: Dispersible
	Then I click continue
	Then I click continue
	Given I fill all empty fields in the Pharma Ingredients screen
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
	Given I set the Should this product be refrigerated for transport or storage? option to: No
	Then I click continue
	Given I set the Is the product regulated for transport (before exceptions or exemptions) option to exactly match: No, not regulated
	Then I click continue
	Given In the Retailers tab, I select the first Vendor option for retailer: Wal-Mart/SAM'S CLUB
	Then I click continue
	Then I call Shared Step 131303 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC127970, container type: Plastic Container, capsule count: 50 and size: 1
#When I click continue
#When I click continue
	Then in the Regulatory Documents to Provide page I click Continue
	Then Upload Full Product Label (required) (For private label products please upload a generic label that is not retailer-specific.) should be showing the error messages: Document is required: Product Label
	And I call Shared Step 60567 (Upload Product Label only) for section: Upload Full Product Label (required)
	Then I check for the following options in the Additonal Documents to Provide section
		| Option                       |
		| Safety Data Sheet (Optional) |
	Then in the Additional Documents to Provide page I click Continue
#When I click continue
#Given I call Shared Step 59042 (Browse for File > select > click Open - Happy Path) for document type: Upload Full Product Label (required) (For private label products please upload a generic label that is not retailer-specific.) and file: UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf
#When I click continue
#When I click continue
#Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase127970
	Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	And In the Purchase Summary screen I confirm the Purchase Summary header is displayed
	Then In the Thank You screen I confirm the following statement is shown: Thank you for registering your product on WERCSmart for assessment. The retailers may receive your assessment in approximately two (2) business days, if no delays in processing the assessment, and should no data issues arise.
	And I navigate to the home page









@TestCase:128018
Scenario: [128018] Pharma - Forwarding Not Allowed
	Given I log in with the account saved in TReVor as: ProductAccount
	Given I click the Prescription Pharmaceutical icon in the QuickLinks Pane
	Given I generate a random UPC number and save as: UPC128018
	Given I click continue
	Then I should see the Product Type Page
	Then I set 'Product Name' to: prescription pharmaceutical, solid
	Then I set 'Type of Product' to: prescription pharmaceutical, solid
	Then I click continue
	Given I enter the NDC number: 10866-0885-2
	Then I save the product information as: TestCase128018
	Then I click continue
	Then I click continue
	Given I fill all empty fields in the SPL Information screen
	Then I click continue
	And I set the Secondary Physical State to be: Solid
	And I set the When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5? option to: No
	And I set the Select the best Water Solubility description to be: Dispersible
	Then I click continue
	Then I click continue
	Given I fill all empty fields in the Pharma Ingredients screen
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
	Given I set the Should this product be refrigerated for transport or storage? option to: No
	Then I click continue
	Given I set the Is the product regulated for transport (before exceptions or exemptions) option to exactly match: No, not regulated
	Then I click continue
	Given In the Retailers tab, I select the first Vendor option for retailer: Wal-Mart/SAM'S CLUB
	Then I click continue
	Then I call Shared Step 131303 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC128018, container type: Plastic Container, capsule count: 50 and size: 1
	When I click continue
	When I click continue
	Then Upload Full Product Label (required) (For private label products please upload a generic label that is not retailer-specific.) should be showing the error messages: Document is required: Product Label
	And I call Shared Step 60567 (Upload Product Label only) for section: Upload Full Product Label (required)
	When I click continue
	Given I call Shared Step 59042 (Browse for File > select > click Open - Happy Path) for document type: Upload Full Product Label (required) (For private label products please upload a generic label that is not retailer-specific.) and file: UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf
	When I click continue
	When I click continue
	Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	And In the Purchase Summary screen I confirm the Purchase Summary header is displayed
	Then In the Thank You screen I confirm the following statement is shown: Thank you for registering your product on WERCSmart for assessment. The retailers may receive your assessment in approximately two (2) business days, if no delays in processing the assessment, and should no data issues arise.
	And I navigate to the home page
	Given I call Shared Step 75130 - Bulk Actions - Select Forward Product Registration
	And I enter the text: saved as TestCase128018 in the 'Search by WPS ID or Product Name' field
	And In the Foward Product Registration Screen I should not see product: saved as TestCase128018
	And I navigate to the home page








@TestCase:127847
Scenario: [127847] Pharma - Tablet or Capsule Count Field is Available for Solid - Solid
Given I log in with the account saved in TReVor as: ProductAccount
Given I click the Prescription Pharmaceutical icon in the QuickLinks Pane
Given I generate a random UPC number and save as: UPC127847
Given I click continue
Then I should see the Product Type Page
Then I set 'Product Name' to: prescription pharmaceutical, solid
Then I set 'Type of Product' to: prescription pharmaceutical, solid
Then I click continue
Given I enter the NDC number: 10866-0885-2
Then I save the product information as: TestCase127847
Then I click continue
Then I click continue
Given I fill all empty fields in the SPL Information screen
Then I click continue
And I set the Secondary Physical State to be: Solid
And I set the When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5? option to: No
And I set the Select the best Water Solubility description to be: Dispersible
Then I click continue
Then I click continue
Given I fill all empty fields in the Pharma Ingredients screen
Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
	| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
	| Propane       | 100     | false               | false       |            |
Given I set the Should this product be refrigerated for transport or storage? option to: No
Then I click continue
Given I set the Is the product regulated for transport (before exceptions or exemptions) option to exactly match: No, not regulated
Then I click continue
Given In the Retailers tab, I select the first Vendor option for retailer: Wal-Mart/SAM'S CLUB
Then I click continue
Given I click the 'Add' button
Then I Confirm that the Tablet or Capsule Count field is available
Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC127847, container type: Plastic Container and size: 1
#Then I call Shared Step 131303 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC127847, container type: Plastic Container, capsule count: 50 and size: 1
When I click continue
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase127847








@TestCase:127854
Scenario: [127854] Pharma - Tablet or Capsule Count Field is Available for Solid - Solid Containing Liquid
	Given I log in with the account saved in TReVor as: ProductAccount
	Given I click the Prescription Pharmaceutical icon in the QuickLinks Pane
	Given I generate a random UPC number and save as: UPC127854
	Given I click continue
	Then I should see the Product Type Page
	Then I set 'Product Name' to: prescription pharmaceutical, solid
	Then I set 'Type of Product' to: prescription pharmaceutical, solid
	Then I click continue
	Given I enter the NDC number: 10866-0885-2
	Then I save the product information as: TestCase127854
	Then I click continue
	Then I click continue
	Given I fill all empty fields in the SPL Information screen
	Then I click continue
	And I set the Secondary Physical State to be: Solid
	And I set the When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5? option to: No
	And I set the Select the best Water Solubility description to be: Dispersible
	Then I click continue
	Then I click continue
	Given I fill all empty fields in the Pharma Ingredients screen
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
	Given I set the Should this product be refrigerated for transport or storage? option to: No
	Then I click continue
	Given I set the Is the product regulated for transport (before exceptions or exemptions) option to exactly match: No, not regulated
	Then I click continue
	Given In the Retailers tab, I select the first Vendor option for retailer: Wal-Mart/SAM'S CLUB
	Then I click continue
	Then I call Shared Step 131303 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC127854, container type: Plastic Container, capsule count: 50 and size: 1
	When I click continue
	When I click continue
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase127854








@TestCase:127791
Scenario: [127791] Pharma - Retailer Default
	Given I log in with the account saved in TReVor as: PharmaAccount
	Given I click the Prescription Pharmaceutical icon in the QuickLinks Pane
	Given I generate a random UPC number and save as: UPC127791
	Given I click continue
	Then I should see the Product Type Page
	Then I set 'Product Name' to: Prescription Pharmaceutical, Solid
	Then I set 'Type of Product' to: Prescription Pharmaceutical, Solid
	Then I click continue
	Given I enter the NDC number: 10866-0885-2
	Then I save the product information as: TestCase127791
	Then I click continue
	Then I click continue
	Given I fill all empty fields in the SPL Information screen
	Then I click continue
	And I set the Secondary Physical State to be: Solid
	And I set the When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5? option to: No
	And I set the Select the best Water Solubility description to be: Dispersible
	Then I click continue
	Then I click continue
	Given I fill all empty fields in the Pharma Ingredients screen
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
	Given I set the Should this product be refrigerated for transport or storage? option to: No
	Then I click continue
	Given I set the Is the product regulated for transport (before exceptions or exemptions) option to exactly match: No, not regulated
	Then I click continue
	And The selected retailers on the Retailer page should be:
		| Retailer                   |
		| No Retailer/No UPC Product |
		| Wal-Mart/SAM'S CLUB        |
	Given In the Retailers tab, I select the first Vendor option for retailer: Wal-Mart/SAM'S CLUB
	Then I click continue
	Given I click the 'Add' button
	And I confirm that retailer "WM" is present under the 'Destination Retailers' column in the UPC table
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase127791





@TestCase:128671
Scenario: [128671] Pharma - Prescription Pharmaceutical - Liquid Core Product

	Given I log in with the account saved in TReVor as: ProductAccount
	Given I click the Prescription Pharmaceutical icon in the QuickLinks Pane
	Given I generate a random UPC number and save as: UPC127847
	Given I click continue
	Then I should see the Product Type Page
	Then I set 'Product Name' to: Prescription Pharmaceutical with Liquid Core
	Then I set 'Type of Product' to: Prescription Pharmaceutical with Liquid Core
	Then I click continue
	Given I enter the NDC number: 10866-0885-2
	Then I save the product information as: TestCase127847
	Then I click continue
	Then I click continue
	Given I fill all empty fields in the SPL Information screen
	Then I click continue
	Given I call Shared Step 32931 (Liquid Core Product - select  No - Happy Path)
	And I set the Secondary Physical State to be: Solid
	And I set the When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5? option to: No
	And I set the Select the best Water Solubility description to be: Dispersible
	Then I click continue
	Then I click continue
	Given I fill all empty fields in the Pharma Ingredients screen
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
	Given I set the Should this product be refrigerated for transport or storage? option to: No
	Then I click continue
	Given I set the Is the product regulated for transport (before exceptions or exemptions) option to exactly match: No, not regulated
	Then I click continue
	Given In the Retailers tab, I select the first Vendor option for retailer: Wal-Mart/SAM'S CLUB
	Then I click continue
	Then I call Shared Step 131303 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC127847, container type: Plastic Container, capsule count: 50 and size: 1
	When I click continue
	When I click continue
	Then Upload Full Product Label (required) (For private label products please upload a generic label that is not retailer-specific.) should be showing the error messages: Document is required: Product Label
	And I call Shared Step 60567 (Upload Product Label only) for section: Upload Full Product Label (required)
	Then I check for the following options in the Additonal Documents to Provide section
		| Option                       |
		| Safety Data Sheet (Optional) |
	When I click continue
	Given I call Shared Step 59042 (Browse for File > select > click Open - Happy Path) for document type: Upload Full Product Label (required) (For private label products please upload a generic label that is not retailer-specific.) and file: UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf
	When I click continue
	Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Then In the Thank You screen I confirm the following statement is shown: Thank you for registering your product on WERCSmart for assessment. The retailers may receive your assessment in approximately two (2) business days, if no delays in processing the assessment, and should no data issues arise.
	And I navigate to the home page





@TestCase:128677
Scenario: [128677] Pharma - Prescription Pharmaceutical - Liquid Product

	Given I call Shared Step (Login to WERCSmart - Pharma Account)
	Given I click the Prescription Pharmaceutical icon in the QuickLinks Pane
	Given I generate a random UPC number and save as: UPC128677
	Given I click continue
	Then I should see the Product Type Page
	Then I set 'Product Name' to: prescription pharmaceutical, solid
	Then I set 'Type of Product' to: prescription pharmaceutical, solid
	Then I click continue
	Given I enter the NDC number: 10866-0885-2
	Then I save the product information as: TestCase128677
	Then I click continue
	Then I click continue
	Given I fill all empty fields in the SPL Information screen
	Then I click continue
	Given I set the Secondary Physical State field to: Liquid
	And I set the When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5? option to: No
	Given I set the Select the best Water Solubility description field to: Dispersible
	Then I click continue
	Then I click continue
	Given I fill all empty fields in the Pharma Ingredients screen
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
	Given I set the Should this product be refrigerated for transport or storage? option to: No
	Then I click continue
	Given I set the Is the product regulated for transport (before exceptions or exemptions) option to: Yes, Agree
	Given I call Shared Step 130543 (Transport - Pharma Flow - Select DOT & Limited Shipping - No Continue)
	Then I click continue
	Given I call Shared Step 130542 (UN Number - Pharma Flow - enter UN1950 select Aerosol & Haz class, confirm Packing group - Continue)
	Given In the Retailers tab, I select the first Vendor option for retailer: Wal-Mart/SAM'S CLUB
	Then I click continue
	Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC128677, container type: Plastic Container and size: 1
	When I click continue
	When I click continue
	Then Upload Full Product Label (required) (For private label products please upload a generic label that is not retailer-specific.) should be showing the error messages: Document is required: Product Label
	And I call Shared Step 60567 (Upload Product Label only) for section: Upload Full Product Label (required)
	When I click continue
	Given I call Shared Step 59042 (Browse for File > select > click Open - Happy Path) for document type: Upload Full Product Label (required) (For private label products please upload a generic label that is not retailer-specific.) and file: UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf
	When I click continue
	Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Then In the Thank You screen I confirm the following statement is shown: Thank you for registering your product on WERCSmart for assessment. The retailers may receive your assessment in approximately two (2) business days, if no delays in processing the assessment, and should no data issues arise.
	And I navigate to the home page


@TestCase:128134
Scenario: [128134] Pharma -  Product in Recertification

	Given I call Shared Step (Login to WERCSmart - Pharma Account)
	Given I click the Prescription Pharmaceutical icon in the QuickLinks Pane
	Given I generate a random UPC number and save as: UPC128018
	Given I click continue
	Given I call Shared Step 57500a (Prescription Pharmaceutical - The Product- Enter name, select product type - Continue - Happy Path): prescription pharmaceutical, solid
	Given I enter the NDC number: 10866-0885-2
	Then I save the product information as: TestCase128018
	Then I click continue
	Then I click continue
	Given I fill all empty fields in the SPL Information screen
	Then I click continue
	And I set the Secondary Physical State to be: Solid
	And I set the When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5? option to: No
	And I set the Select the best Water Solubility description to be: Dispersible
	Then I click continue
	Then I click continue
	Given I fill all empty fields in the Pharma Ingredients screen
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
	Given I set the Should this product be refrigerated for transport or storage? option to: No
	Then I click continue
	Given I set the Is the product regulated for transport (before exceptions or exemptions) option to: No, not regulated
	Then I click continue
	Given in the Select Retailers tab under Forward Product Registration I select the retailer: Wal-Mart/SAM'S CLUB
	Given In the Retailers tab, I select the first Vendor option for retailer: Wal-Mart/SAM'S CLUB
	Then I click continue
	Then I call Shared Step 131303 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC128018, container type: Plastic Contains, capsule count: 50 and size: 1
	When I click continue
	When I click continue
	Then Upload Full Product Label (required) (For private label products please upload a generic label that is not retailer-specific.) should be showing the error messages: Document is required: Product Label
	And I call Shared Step 60567 (Upload Product Label only) for section: Upload Full Product Label (required)
	Then I check for the following options in the Additonal Documents to Provide section
		| Option                       |
		| Safety Data Sheet (Optional) |
	When I click continue
	Given I call Shared Step 59042 (Browse for File > select > click Open - Happy Path) for document type: Upload Full Product Label (required) (For private label products please upload a generic label that is not retailer-specific.) and file: UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf
	When I click continue
	When I click continue
	Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	And In the Purchase Summary screen I confirm the Purchase Summary header is displayed
	Then In the Thank You screen I confirm the following statement is shown: Thank you for registering your product on WERCSmart for assessment. The retailers may receive your assessment in approximately two (2) business days, if no delays in processing the assessment, and should no data issues arise.
	And I navigate to the home page

	Given I call Shared Step 75130 - Bulk Actions - Select Forward Product Registration
	And I enter the text: saved as TestCase128018 in the 'Search by WPS ID or Product Name' field
	And In the Foward Product Registration Screen I should not see product: saved as TestCase128018
	And I click the Home navigation icon and accept the alert popup


	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Submitted Status for saved as: TestCase128018)
	Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase128018)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Assigned Status for saved as: TestCase128018)
	Given I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase128018)
	And I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase128018)
	Given I call Shared Step 79500 (WPS Studio - PD+ - set all data and publish using rule and doc queue - CKLT and SBCS only) for product saved as: TestCase128018
	Given I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase128018)
	Given I call Shared Step 59066 (Go to SHA Manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Accepted Status for saved as: TestCase128018)
	Given I call Shared Step 51664 (SHA - Accepted Product - set Retailers to Completed for saved as: TestCase128018) for
		| Retailer |
		| CVS      |
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Completed Status for saved as: TestCase128018)
	And I call Shared Step 43587 - SHA Manager > Completed Product - Add Recert reason 20 for product saved as: TestCase128018


	Given I navigate to the landing page
	Given I call Shared Step (Login to WERCSmart - Pharma Account)
	And I filter for the product saved as: TestCase128018
	And I click Row Actions for the first product returned

	And I click on the Row Action: Update Required
	And I set the Secondary Physical State to be: Solid containing liquid
	And I click Save in The Product Page
	Given In the New Product page I click tab: Retailer Association
	And I click the page heading: Universal Product Code (UPC)
	And I click Save in The Product Page
	Then Tablet or Capsule Count should not be showing the error messages on upc screen: This is a required field.
	And I click Save in The Product Page
	Given I call Shared Step 59042 (Browse for File > select > click Open - Happy Path) for document type: Upload Full Product Label (required) (For private label products please upload a generic label that is not retailer-specific.) and file: UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf
	And I click Save in The Product Page
	Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	And In the Purchase Summary screen I confirm the Purchase Summary header is displayed
	Then In the Thank You screen I confirm the following statement is shown: Thank you for registering your product on WERCSmart for assessment. The retailers may receive your assessment in approximately two (2) business days, if no delays in processing the assessment, and should no data issues arise.
	And I navigate to the home page
