@PaymentMethods
@Shared
@Login
@Homepage
@ProductGrid
@ForwardProductRegistration
@NewProduct
@RetailPartners
@Pharma
@run_Pharma
Feature: Pharma

Scenario: [127870] Pharma - Tablet or Capsule Count Field is Available for Solid - Solid Gel Consistency

Given I attempt to log in with email: pharma.kxxyxunf@mailosaur.io and password: Welcome1!
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
And I set the Select the best Water Solubility description to be: Very soluble
And in the New Product page I click Continue
Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
	| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
	| Propane       | 100     | false               | false       |            |
Given I set the Should this product be refrigerated for transport or storage? option to: No
Then I click continue
Given I set the Is the product regulated for transport (before exceptions or exemptions) option to: No, not regulated
Then I click continue
Given In the Retailers tab, I select the first Vendor option for retailer: Wal-Mart/SAM'S CLUB
Then I click continue
Then I call Shared Step 131303 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC127870, container type: Plastic Container, capsule count: 50 and size: 1
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase127870









Scenario: [127970] Pharma - Regulatory Documents to Provide and Additional Documents to Provide 
Given I attempt to log in with email: pharma.kxxyxunf@mailosaur.io and password: Welcome1!
Given I click the Prescription Pharmaceutical icon in the QuickLinks Pane
Given I generate a random UPC number and save as: UPC127970
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
And I set the Select the best Water Solubility description to be: Very soluble
And in the New Product page I click Continue
Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
	| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
	| Propane       | 100     | false               | false       |            |
Given I set the Should this product be refrigerated for transport or storage? option to: No
Then I click continue
Given I set the Is the product regulated for transport (before exceptions or exemptions) option to: No, not regulated
Then I click continue
Given In the Retailers tab, I select the first Vendor option for retailer: Wal-Mart/SAM'S CLUB
Then I click continue
Then I call Shared Step 131303 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC127970, container type: Plastic Container, capsule count: 50 and size: 1
When I click continue
When I click continue
Then Upload Full Product Label (required) (For private label products please upload a generic label that is not retailer-specific.) should be showing the error messages: Document is required: Product Label
And I call Shared Step 60567 (Upload Product Label only) for section: Upload Full Product Label (required)
When I click continue
Given I call Shared Step 59042 (Browse for File > select > click Open - Happy Path) for document type: Upload Full Product Label (required) (For private label products please upload a generic label that is not retailer-specific.) and file: C:\Dependencies\WERCSmart\testdoc.pdf
When I click continue
When I click continue
Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
And In the Purchase Summary screen I confirm the Purchase Summary header is displayed
Then In the Thank You screen I confirm the following statement is shown: Thank you for registering your product on WERCSmart for assessment. The retailers may receive your assessment in approximately two (2) business days, if no delays in processing the assessment, and should no data issues arise.
And I navigate to the home page









Scenario: [128018] Pharma - Forwarding Not Allowed
Given I attempt to log in with email: pharma.kxxyxunf@mailosaur.io and password: Welcome1!
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
And I set the Select the best Water Solubility description to be: Very soluble
And in the New Product page I click Continue
Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
	| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
	| Propane       | 100     | false               | false       |            |
Given I set the Should this product be refrigerated for transport or storage? option to: No
Then I click continue
Given I set the Is the product regulated for transport (before exceptions or exemptions) option to: No, not regulated
Then I click continue
Given In the Retailers tab, I select the first Vendor option for retailer: Wal-Mart/SAM'S CLUB
Then I click continue
Then I call Shared Step 131303 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC128018, container type: Plastic Container, capsule count: 50 and size: 1
When I click continue
When I click continue
Then Upload Full Product Label (required) (For private label products please upload a generic label that is not retailer-specific.) should be showing the error messages: Document is required: Product Label
And I call Shared Step 60567 (Upload Product Label only) for section: Upload Full Product Label (required)
Then I check for the following options in the Additonal Documents to Provide section
| Option                       |
| Safety Data Sheet (Optional) |
When I click continue
Given I call Shared Step 59042 (Browse for File > select > click Open - Happy Path) for document type: Upload Full Product Label (required) (For private label products please upload a generic label that is not retailer-specific.) and file: C:\Dependencies\WERCSmart\testdoc.pdf
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








Scenario: [127847] Pharma - Tablet or Capsule Count Field is Available for Solid - Solid
Given I attempt to log in with email: pharma.kxxyxunf@mailosaur.io and password: Welcome1!
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
And I set the Select the best Water Solubility description to be: Very soluble
And in the New Product page I click Continue
Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
	| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
	| Propane       | 100     | false               | false       |            |
Given I set the Should this product be refrigerated for transport or storage? option to: No
Then I click continue
Given I set the Is the product regulated for transport (before exceptions or exemptions) option to: No, not regulated
Then I click continue
Given In the Retailers tab, I select the first Vendor option for retailer: Wal-Mart/SAM'S CLUB
Then I click continue
Then I call Shared Step 131303 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC127847, container type: Plastic Container, capsule count: 50 and size: 1
When I click continue
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase127847








Scenario: [127854] Pharma - Tablet or Capsule Count Field is Available for Solid - Solid Containing Liquid
Given I attempt to log in with email: pharma.kxxyxunf@mailosaur.io and password: Welcome1!
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
And I set the Secondary Physical State to be: Solid containing liquid
And I set the When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5? option to: No
And I set the Select the best Water Solubility description to be: Very soluble
And in the New Product page I click Continue
Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
	| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
	| Propane       | 100     | false               | false       |            |
Given I set the Should this product be refrigerated for transport or storage? option to: No
Then I click continue
Given I set the Is the product regulated for transport (before exceptions or exemptions) option to: No, not regulated
Then I click continue
Given In the Retailers tab, I select the first Vendor option for retailer: Wal-Mart/SAM'S CLUB
Then I click continue
Then I call Shared Step 131303 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC127854, container type: Plastic Container, capsule count: 50 and size: 1
When I click continue
When I click continue
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase127854








Scenario: [127791] Pharma - Retailer Default
Given I attempt to log in with email: pharma.kxxyxunf@mailosaur.io and password: Welcome1!
Given I click the Prescription Pharmaceutical icon in the QuickLinks Pane
Given I generate a random UPC number and save as: UPC127791
Given I click continue
Then I should see the Product Type Page
Then I set 'Product Name' to: prescription pharmaceutical, solid
Then I set 'Type of Product' to: prescription pharmaceutical, solid
Then I click continue
Given I enter the NDC number: 10866-0885-2
Then I save the product information as: TestCase127791
Then I click continue
Then I click continue
Given I fill all empty fields in the SPL Information screen
Then I click continue
And I set the Secondary Physical State to be: Solid
And I set the When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5? option to: No
And I set the Select the best Water Solubility description to be: Very soluble
And in the New Product page I click Continue
Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
	| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
	| Propane       | 100     | false               | false       |            |
Given I set the Should this product be refrigerated for transport or storage? option to: No
Then I click continue
Given I set the Is the product regulated for transport (before exceptions or exemptions) option to: No, not regulated
Then I click continue
And The selected retailers on the Retailer page should be:
		| Retailer                   |
		| No Retailer/No UPC Product |
		| Wal-Mart/SAM'S CLUB        | 
Given In the Retailers tab, I select the first Vendor option for retailer: Wal-Mart/SAM'S CLUB
Then I click continue
Given I click the 'Add UPC' button
And I confirm that retailer "WM" is present under the 'Destination Retailers' column in the UPC table
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase127791





Scenario: [128671] Pharma - Prescription Pharmaceutical - Liquid Core Product

Given I attempt to log in with email: pharma.kxxyxunf@mailosaur.io and password: Welcome1!
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
And I set the Select the best Water Solubility description to be: Very soluble
And in the New Product page I click Continue
Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
	| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
	| Propane       | 100     | false               | false       |            |
Given I set the Should this product be refrigerated for transport or storage? option to: No
Then I click continue
Given I set the Is the product regulated for transport (before exceptions or exemptions) option to: No, not regulated
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
Given I call Shared Step 59042 (Browse for File > select > click Open - Happy Path) for document type: Upload Full Product Label (required) (For private label products please upload a generic label that is not retailer-specific.) and file: C:\Dependencies\WERCSmart\testdoc.pdf
When I click continue
Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
Then In the Thank You screen I confirm the following statement is shown: Thank you for registering your product on WERCSmart for assessment. The retailers may receive your assessment in approximately two (2) business days, if no delays in processing the assessment, and should no data issues arise.
And I navigate to the home page





Scenario: [128677] Pharma - Prescription Pharmaceutical - Liquid Product

Given I attempt to log in with email: pharma.kxxyxunf@mailosaur.io and password: Welcome1!
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
Given I set the Select the best Water Solubility description field to: Appreciable
And in the New Product page I click Continue
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
Given I call Shared Step 59042 (Browse for File > select > click Open - Happy Path) for document type: Upload Full Product Label (required) (For private label products please upload a generic label that is not retailer-specific.) and file: C:\Dependencies\WERCSmart\testdoc.pdf
When I click continue
Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
Then In the Thank You screen I confirm the following statement is shown: Thank you for registering your product on WERCSmart for assessment. The retailers may receive your assessment in approximately two (2) business days, if no delays in processing the assessment, and should no data issues arise.
And I navigate to the home page




Scenario: [128141] Verification that 'Bed Bath and Beyond' Displays under 'My Retailers' and its Data Consent Tiers

Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Then I click the Retail Partners icon in the Navigation Pane
	When I select the retailer: Bed Bath and Beyond (Including Harmon, Buy buy Baby, and Christmas Tree Shops)
	And I confirm that: Bed Bath and Beyond (including Harmon, Buy Buy Baby, and Christmas Tree Shops) requires suppliers of formulated products in the following categories to grant Tier 2.1, Tier 2.2 and Tier 4.1 permissions: Cleaning Supplies, Grocery, Health & Beauty, Nutritional Supplements, OTC - Over the Counter, and Pharmacy is showing under the Data Consent Tiers heading
	When I click the More Information hyperlink
	Then I check that the current URL contains: https://bedbathandbeyond.gcs-web.com/static-files/551ad447-b204-4204-90c8-a5064079c2f5/
	And I close the window that opened

	And I click the "What are the Data Usage Tiers?" information button in the Retail Partners Details screen

	And I click the "Tier 1: Regulatory Compliance" tab in Data Tier Details
	And I confirm the Data Tier Details subheading reads: What does Regulatory Support mean?
	And I click download PDF for "What does Regulatory Support mean?"
	Then I confirm a new window opens displaying the document url: https://staging.thewercs.com/Wercs.SHA.MVCWebV1/RetailPartners/Retailer/Index/ec6b4522-b4f7-4567-acd2-8101450b6a07

	And I click the "Tier 2: Chemical Program Support" tab in Data Tier Details
	And I confirm the Data Tier Details subheading reads: What does Chemical Program Support mean?
	And I click download PDF for "What does Chemical Program Support mean?"
	Then I confirm a new window opens displaying the document url: https://staging.thewercs.com/Wercs.SHA.MVCWebV1/RetailPartners/Retailer/Index/ec6b4522-b4f7-4567-acd2-8101450b6a07

	And I click the "Tier 3: Supplemental Reports" tab in Data Tier Details
	And I confirm the Data Tier Details subheading reads: What does Supplemental Reports for Internal Business Use Only mean?
	And I click download PDF for "What does Supplemental Reports for Internal Business Use Only mean?"
	Then I confirm a new window opens displaying the document url: https://staging.thewercs.com/Wercs.SHA.MVCWebV1/RetailPartners/Retailer/Index/ec6b4522-b4f7-4567-acd2-8101450b6a07

	And I click the "Tier 4: Public Disclosure Options" tab in Data Tier Details
	And I confirm the Data Tier Details subheading reads: What are my Public Disclosure Options?
	And I click download PDF for "What are my Public Disclosure Options?"
	Then I confirm a new window opens displaying the document url: https://staging.thewercs.com/Wercs.SHA.MVCWebV1/RetailPartners/Retailer/Index/ec6b4522-b4f7-4567-acd2-8101450b6a07

	And The Data Tier Details popup shows the following tabs:
		| Tab                               |
		| Tier 1: Regulatory Compliance     |
		| Tier 2: Chemical Program Support  |
		| Tier 3: Supplemental Reports      |
		| Tier 4: Public Disclosure Options |
	And I close the Data Tier Details popup

	Then I confirm that there is a section labeled: Data Consent Tiers
	Given I ensure the Data Consent Tier Sliders exist for the following tiers:
		| Tier |
		| 1    |
		| 2.1  |
		| 2.2  |
		| 4.1  |

	Given I click the Save Changes button
	Then The success message in the Save Changes popup dialog should contain the following:
		| Message                                                                                       |
		| The information was saved correctly and the notification Email was sent to all Administrators |
	Given I click close on the Save Changes popup dialog
	And I confirm the NOTE message below the Data Consent Tiers Heading is NOT shown
	Given I click the back arrow on the Retail Partners Details page
	Then I should see the Retail Partners page
	And I navigate to the home page






Scenario: [128134] Pharma -  Product in Recertification

Given I attempt to log in with email: wercsmartsub1@sharklasers.com and password: Thewercs1!
Given I click the Prescription Pharmaceutical icon in the QuickLinks Pane
Given I generate a random UPC number and save as: UPC128018
Given I click continue
Given I call Shared Step 57500a (Prescription Pharmaceutical - The Product- Enter name, select product type - Continue - Happy Path): prescription pharmaceutical, solid
Given I enter the NDC number: 10866-0885-2
Then I save the product information as: TestCase128018
Then I click continue
Given I fill all empty fields in the SPL Information screen
Then I click continue
And I set the Secondary Physical State to be: Solid
And I set the When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5? option to: No
And I set the Select the best Water Solubility description to be: Very soluble
And in the New Product page I click Continue
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
Then I call Shared Step 57961 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC128018, container type: Plastic Container, capsule count: 50 and size: 1
When I click continue
When I click continue
Then Upload Full Product Label (required) (For private label products please upload a generic label that is not retailer-specific.) should be showing the error messages: Document is required: Product Label
And I call Shared Step 60567 (Upload Product Label only) for section: Upload Full Product Label (required)
Then I check for the following options in the Additonal Documents to Provide section
| Option                       |
| Safety Data Sheet (Optional) |
When I click continue
Given I call Shared Step 59042 (Browse for File > select > click Open - Happy Path) for document type: Upload Full Product Label (required) (For private label products please upload a generic label that is not retailer-specific.) and file: C:\Dependencies\WERCSmart\testdoc.pdf
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
Given I attempt to log in with email: wercsmartsub1@sharklasers.com and password: Thewercs1!
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
Given I call Shared Step 59042 (Browse for File > select > click Open - Happy Path) for document type: Upload Full Product Label (required) (For private label products please upload a generic label that is not retailer-specific.) and file: C:\Dependencies\WERCSmart\testdoc.pdf
And I click Save in The Product Page
Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
And In the Purchase Summary screen I confirm the Purchase Summary header is displayed
Then In the Thank You screen I confirm the following statement is shown: Thank you for registering your product on WERCSmart for assessment. The retailers may receive your assessment in approximately two (2) business days, if no delays in processing the assessment, and should no data issues arise.
And I navigate to the home page
