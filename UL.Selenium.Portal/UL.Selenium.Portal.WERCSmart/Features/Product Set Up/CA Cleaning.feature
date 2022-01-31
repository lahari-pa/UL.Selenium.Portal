@Shared
@LandingPage
@Login
@Homepage
@Signup
@wercsmart
@NewProduct
@ProductGrid
@SHA
@wercsmart
@RetailPartners
@CreateProducts
@PaymentMethods
@UPC
@Studio
@ProductSetUp
@CACleaning
@MyIngredients
@run_CACleaning
Feature:  California Cleaning Scenarios

@TestCase:139531
Scenario: [139531] CA Cleaning - Ingredient Type Missing

Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Bleach
Then I save the product information as: TestCase139531
Given I set the Which best describes your product, including when FIFRA 25(b) Exempt option to: Product is not considered a pesticide product
Then I set the value 'FIFRAPopupExpected' to be: true
Given In the Product Information Screen I answer the questions as follows - US only - No to GHS - No to shipped supplier - Yes to CA Cleaning - No to Private Label - No to Sold to retailer)
Given In the Claifornia Cleaning Product Disclosure I choose 'Manufacturer' and select 'No' for CBI, then enter Placeholder Details
Given I click continue
Given I call Shared Step 57501 (Physical and Chemical Properties - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue - HP)
Given I add the following CA Cleaning ingredients:  
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName | GenericName | IngredientType | FunctionalPurpose             | Clean | Certified |
		| Water         | 100     | false               | true        | AQUA       | AQUA        | Choose...      | Abrasive, Absorbent, Adhesive | true  | true      |
Given I click continue
Then I confirm I see the error message types in the popup with the following title: California Cleaning Right to Know
| Error                                   |
| Ingredient Type                         |
Then I click the close button for the CA Cleaning Ingredients Popup
Then I click the 'x' button for component number 1
Given I click: YES in the 'Remove Component from My Ingredients' pop up
Given I add the following CA Cleaning ingredients:  
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName     | GenericName | IngredientType      | FunctionalPurpose             | Clean | Certified |
		| Water         | 100     | false               | true       | AQUA           | AQUA1       | Intentionally Added | Abrasive, Absorbent, Adhesive | true  | true      |
Then I click continue
And I should see the Waste Classification Data Page
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase139531



@TestCase:139534
Scenario: [139534] CA Cleaning - Fragrance Component and Functional Purpose MisMatch

Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Bleach
Then I save the product information as: TestCase139534
Given I set the Which best describes your product, including when FIFRA 25(b) Exempt option to: Product is not considered a pesticide product
Then I set the value 'FIFRAPopupExpected' to be: true
Given In the Product Information Screen I answer the questions as follows - US only - No to GHS - No to shipped supplier - Yes to CA Cleaning - No to Private Label - No to Sold to retailer)
Given In the Claifornia Cleaning Product Disclosure I choose 'Manufacturer' and select 'No' for CBI, then enter Placeholder Details
Given I click continue
Given I call Shared Step 57501 (Physical and Chemical Properties - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue - HP)
Given I add the following CA Cleaning ingredients:  
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName | GenericName | IngredientType | FunctionalPurpose             | Clean | Certified |
		| Water         | 100     | false               | true        | AQUA       | AQUA        | Choose...      | Abrasive, Absorbent, Adhesive | true  | true      |
Given I click continue
Then I confirm I see the error message types in the popup with the following title: California Cleaning Right to Know
| Error                                   |
| Ingredient Type                         |
Then I click the close button for the CA Cleaning Ingredients Popup
Then I click the 'x' button for component number 1
Given I click: YES in the 'Remove Component from My Ingredients' pop up
Given I add the following CA Cleaning ingredients:  
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName     | IngredientType | FunctionalPurpose             | Clean | Certified |
		| Water         | 100     | false               | false       | AQUA           | Fragrance      | Abrasive, Absorbent, Adhesive | true  | true      |
Then I click continue
And I should see the Waste Classification Data Page
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase139534


@TestCase:139385
Scenario: [139385] CA Cleaning - Generic Ingredient Used

Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Bleach
Then I save the product information as: TestCase139385
Given I set the Which best describes your product, including when FIFRA 25(b) Exempt option to: Product is not considered a pesticide product
Then I set the value 'FIFRAPopupExpected' to be: true
Given In the Product Information Screen I answer the questions as follows - US only - No to GHS - No to shipped supplier - Yes to CA Cleaning - No to Private Label - No to Sold to retailer)
Given In the Claifornia Cleaning Product Disclosure I choose 'Manufacturer' and select 'No' for CBI, then enter Placeholder Details
Given I click continue
Given I call Shared Step 57501 (Physical and Chemical Properties - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue - HP)
Given I add the following CA Cleaning ingredients:  
		| CASNumber     | Percent | PublicallyDisclosed | TradeSecret | PublicName | GenericName | IngredientType      | FunctionalPurpose             | Clean | Certified |
		| RR-05150-3    | 100     | false               | true        | AQUA       | AQUA        | Intentionally Added | Abrasive, Absorbent, Adhesive | true  | true      |
Given I click continue
Then I confirm I see the error message types in the popup with the following title: California Cleaning Right to Know
| Error                                   |
| Generic                                 |
Then I click the close button for the CA Cleaning Ingredients Popup
Then I click the 'x' button for component number 1
Given I click: YES in the 'Remove Component from My Ingredients' pop up
Given I add the following CA Cleaning ingredients:  
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName     | IngredientType      | FunctionalPurpose             | Clean | Certified |
		| Water         | 100     | false               | false       | AQUA           | Intentionally Added | Abrasive, Absorbent, Adhesive | true  | true      |
Then I click continue
And I should see the Waste Classification Data Page
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase139385


@TestCase:139387
Scenario: [139387] CA Cleaning - 100% Formula Total (Minimum)

Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Bleach
Then I save the product information as: TestCase139387
Given I set the Which best describes your product, including when FIFRA 25(b) Exempt option to: Product is not considered a pesticide product
Then I set the value 'FIFRAPopupExpected' to be: true
Given In the Product Information Screen I answer the questions as follows - US only - No to GHS - No to shipped supplier - Yes to CA Cleaning - No to Private Label - No to Sold to retailer)
Given In the Claifornia Cleaning Product Disclosure I choose 'Manufacturer' and select 'No' for CBI, then enter Placeholder Details
Given I click continue
Given I call Shared Step 57501 (Physical and Chemical Properties - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue - HP)
Given I add the following CA Cleaning ingredients:  
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName | GenericName | IngredientType      | FunctionalPurpose             | Clean | Certified |
		| Water         | 10      | false               | false       | AQUA       | AQUA        | Intentionally Added | Abrasive, Absorbent, Adhesive | true  | true      |
Given I click continue
Then I confirm I see the error message types in the popup with the following title: California Cleaning Right to Know
| Error                                   |
| Percent                                 |
Then I click the close button for the CA Cleaning Ingredients Popup
Then I click the 'x' button for component number 1
Given I click: YES in the 'Remove Component from My Ingredients' pop up
Given I add the following CA Cleaning ingredients:  
		| ComponentName | Percent  | PublicallyDisclosed | TradeSecret | PublicName | IngredientType      | FunctionalPurpose             | Clean | Certified |
		| Water         | 100      | false               | false       | AQUA       | Intentionally Added | Abrasive, Absorbent, Adhesive | true  | true      |
Then I click continue
And I should see the Waste Classification Data Page
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase139387


@TestCase:139388
Scenario: [139388] CA Cleaning - Public Disclosure or Trade Secret Issue

Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Bleach
Then I save the product information as: TestCase139388
Given I set the Which best describes your product, including when FIFRA 25(b) Exempt option to: Product is not considered a pesticide product
Then I set the value 'FIFRAPopupExpected' to be: true
Given In the Product Information Screen I answer the questions as follows - US only - No to GHS - No to shipped supplier - Yes to CA Cleaning - No to Private Label - No to Sold to retailer)
Given In the Claifornia Cleaning Product Disclosure I choose 'Manufacturer' and select 'No' for CBI, then enter Placeholder Details
Given I click continue
Given I call Shared Step 57501 (Physical and Chemical Properties - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue - HP)
Given I add the following CA Cleaning ingredients:  
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName | IngredientType      | FunctionalPurpose             | Clean | Certified |
		| Water         | 0       | false               | false       | AQUA       | Intentionally Added | Abrasive, Absorbent, Adhesive | true  | true      |
Given I click continue
Then I confirm I see the error message types in the popup with the following title: California Cleaning Right to Know
| Error                                   |
| Percent                                 |
Then I click the close button for the CA Cleaning Ingredients Popup
Then I click the 'x' button for component number 1
Given I click: YES in the 'Remove Component from My Ingredients' pop up
Given I add the following CA Cleaning ingredients:  
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName     | IngredientType      | FunctionalPurpose             | Clean | Certified |
		| Water         | 100     | false               | false       | AQUA           | Intentionally Added | Abrasive, Absorbent, Adhesive | true  | true      |
Then I click continue
And I should see the Waste Classification Data Page
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase139388



@TestCase:139205
Scenario: [139205] CA Cleaning - Ingredient Validation Upon Continue or Save

Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Bleach
Then I save the product information as: TestCase139205
Given I set the Which best describes your product, including when FIFRA 25(b) Exempt option to: Product is not considered a pesticide product
Then I set the value 'FIFRAPopupExpected' to be: true
Given In the Product Information Screen I answer the questions as follows - US only - No to GHS - No to shipped supplier - Yes to CA Cleaning - No to Private Label - No to Sold to retailer)
Given In the Claifornia Cleaning Product Disclosure I choose 'Manufacturer' and select 'No' for CBI, then enter Placeholder Details
Given I click continue
Given I call Shared Step 57501 (Physical and Chemical Properties - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue - HP)
Given I add the following CA Cleaning ingredients:  
		| CASNumber  | Percent | PublicallyDisclosed | TradeSecret | PublicName | GenericName | IngredientType      | FunctionalPurpose             | Clean | Certified |
		| RR-05150-3 | 10      | false               | false       |            |             | Intentionally Added | Abrasive, Absorbent, Adhesive | true  | true      |
Given I click continue
Then I confirm I see the error message types in the popup with the following title: California Cleaning Right to Know
| Error                                   |
| Generic                                 |
| Percent                                 |
| Publicly Disclosed or Trade Secret      |
Then I click the close button for the CA Cleaning Ingredients Popup
Then I click the 'x' button for component number 1
Given I click: YES in the 'Remove Component from My Ingredients' pop up
Given I add the following CA Cleaning ingredients:  
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName | IngredientType      | FunctionalPurpose | Clean | Certified |
		| Water         | 100     | false               | false       | AQUA       | Intentionally Added | Abrasive, Absorbent, Adhesive | true  | true      |
Then I click continue
And I should see the Waste Classification Data Page
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase139205


@TestCase:139193
Scenario: [139193] CA Cleaning - Initial Message to Registrant for Ingredients

Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Bleach
Then I save the product information as: TestCase139193
Given I set the Which best describes your product, including when FIFRA 25(b) Exempt option to: Product is not a pesticide and does not make or imply a pesticidal claim on the labeling or in the product description (ex. kills, sterilizes, disinfects, sanitizes, antimicrobial)
Then I set the value 'FIFRAPopupExpected' to be: true
Given In the Product Information Screen I answer the questions as follows - US only - No to GHS - No to shipped supplier - Yes to CA Cleaning - No to Private Label - No to Sold to retailer)
Given I call Shared Step 57501 (Physical and Chemical Properties - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue - HP)
Given In the Claifornia Cleaning Product Disclosure I choose 'Manufacturer' and select 'No' for CBI, then enter Placeholder Details
Given I click continue
Given I confirm there is a message displayed at the top of the Ingredients page
Given I confirm there is a checkbox with the following text: Don't show this again in the message displayed at the top of the Ingredients page
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase139193



@TestCase:139445
Scenario: [139445] CA Cleaning - Ingredients Screen - Validation for INTENTIONALLY ADDED Ingredient Type and Multi-Select Functional Purpose

Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): General Purpose Cleaner - Non-aerosol
Then I save the product information as: TestCase139445
Given I set the Which best describes your product, including when FIFRA 25(b) Exempt option to: Product is not considered a pesticide product
Then I set the value 'FIFRAPopupExpected' to be: true
Given In the Product Information Screen I answer the questions as follows - US only - No to GHS - No to shipped supplier - Yes to CA Cleaning - No to Private Label - No to Sold to retailer)
Then I click continue
Given In the California Cleaning Product Disclosure tab, I enter: NONE in the Final Domestic Distributor
Given In the Claifornia Cleaning Product Disclosure I choose 'Manufacturer' and select 'No' for CBI, then enter Placeholder Details
Given In the California Cleaning Product Disclosure tab, I enter: 1-800-258-7412 in the Company's Toll-Free Phone Number
Given In the California Cleaning Product Disclosure tab, I enter: http://google.com in the Company Web Address
Given I set the Product's GTIN Brick Code to: [10000397] Cleaning Aids
Then I click continue
Given I call Shared Step 57501 (Physical and Chemical Properties - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue - HP)
Given I add the following CA Cleaning ingredients:  
		| ComponentName                                       | Percent | PublicallyDisclosed | TradeSecret | PublicName      | GenericName | IngredientType      | FunctionalPurpose | Clean | Certified |
		| D-Glucopyranose, oligomeric, decyl octyl glycosides | 100     | true                | false       | Decyl Glucoside |             | Intentionally Added |			          | true  | true      |
Given I click continue
Then in page Ingredients Page I should see error: Please select at least one Functional Purpose since Ingredient Type is indicated to be Intentionally Added.
Then I click the Choose... option for Functional Purpose in the Ingredients page
Then I confirm a dropdown menu displays in the Ingredients page
Then I select the following Functional Purpose: Brightening Agent
Then I confirm the following Functional Purpose is displayed: Brightening Agent
Then I select the following Functional Purpose: Deodorizing Agent
Then I confirm the following Functional Purpose is displayed: Deodorizing Agent
Then I select the following Functional Purpose: Processing Aid
Then I confirm the following Functional Purpose is displayed: Processing Aid
Then I click the close button in the Functional Purpose dropdown menu
Then I confirm a dropdown menu is not displayed in the Ingredients page
Then I confirm the following Functional Purpose is displayed: Brightening Agent
Then I confirm the following Functional Purpose is displayed: Deodorizing Agent
Then I confirm the following Functional Purpose is displayed: Processing Aid
Then I click continue
And I should see the Waste Classification Data Page
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase139445



@TestCase:158172
Scenario: [158172] CA Cleaning - Ingredients Screen - Trade Secret Validation - 

Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
And I save the product information as: TestCase158172
Given I call Shared Step 57561a (The Product - Enter Product Name: Trade Secret Validation Product and select Type of Product): General Purpose Cleaner - Non-aerosol
Given I call Shared Step 158144 (Product Information - Pesticide=Not Considered, SOLD=US, OSHA=NO, Shipped Directly=NO, CA Cleaning=YES, Private Label=YES, Sold to Retailer=NO - CONTINUE)
Given I call Shared Step 57501 (Physical and Chemical Properties - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue - HP)
Given I should see the California Cleaning Product Disclosure Page
Given I set the Who is publicly identified on the product label as responsible for the product? option to: Manufacturer
Given In the California Cleaning Product Disclosure tab, I enter: NONE in the Final Domestic Distributor
Given I set the Is your identity, as the Manufacturer of this product, Confidential Business Information (CBI)? option to: No
Given I set the Product's GTIN Brick Code to: [10000397] Cleaning Aids
Given I click continue
Given I add the following CA Cleaning ingredients:  
		| CASNumber  | Percent | PublicallyDisclosed | TradeSecret | PublicName | GenericName   | IngredientType            | FunctionalPurpose | Clean | Certified |
		| 68515-73-1 | 100     |                     | true        |            | TS Validation | Nonfunctional Constituent |                   | true  | true      |
Given for ingredient: D-Glucopyranose, oligomeric, decyl octyl glycosides the Publicly Disclosed field is disabled
Given for ingredient: D-Glucopyranose, oligomeric, decyl octyl glycosides the Public Name field is disabled
Given for ingredient: D-Glucopyranose, oligomeric, decyl octyl glycosides the Trade Secret field is enabled
Given for ingredient: D-Glucopyranose, oligomeric, decyl octyl glycosides the Generic Name field is displayed
Given for ingredient: D-Glucopyranose, oligomeric, decyl octyl glycosides the Ingredient Type drop-down is displayed
Then I confirm the following Functional Purpose is displayed: Non-Functional Ingredient
Given I click continue
Given I should see the Waste Classification Data Page
Given I click the Home navigation icon
Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase158172
