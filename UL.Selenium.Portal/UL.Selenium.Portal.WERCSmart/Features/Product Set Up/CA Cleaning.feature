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
@run_CA Cleaning
Feature:  California Cleaning Scenarios

@ScenarioId:9832
Scenario: [139531] CA Cleaning - Ingredient Type Missing

Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Bleach
Then I save the product information as: TestCase139531
Given I call Shared Step 57501 (Product Characteristics - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue - HP)
Given I set the Which one best describes your product option to: Product is not considered a pesticide product
Given In the Additional Product Information Screen I answer the questions as follows - US only - No to GHS - No to shipped supplier - Yes to CA Cleaning - No to Private Label - No to Sold to retailer)
Given In the Claifornia Cleaning Product Disclosure I choose 'Manufacturer' and select 'No' for CBI, then enter Placeholder Details
Given I click continue
Given I add the following CA Cleaning ingredients:  
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName | GenericName | IngredientType | FunctionalPurpose | Clean | Certified |
		| Water         | 100     | false               | true       | AQUA       | AQUA1       | Choose...      | Abrasive, Absorbent, Adhesive | true  | true      |
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



Scenario: [139534] CA Cleaning - Fragrance Component and Functional Purpose MisMatch

Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Bleach
Then I save the product information as: TestCase139534
Given I call Shared Step 57501 (Product Characteristics - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue - HP)
Given I set the Which one best describes your product option to: Product is not considered a pesticide product
Given In the Additional Product Information Screen I answer the questions as follows - US only - No to GHS - No to shipped supplier - Yes to CA Cleaning - No to Private Label - No to Sold to retailer)
Given In the Claifornia Cleaning Product Disclosure I choose 'Manufacturer' and select 'No' for CBI, then enter Placeholder Details
Given I click continue
Given I add the following CA Cleaning ingredients:  
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName | IngredientType           | FunctionalPurpose             | Clean | Certified |
		| Water         | 100     | false               | false       | AQUA       | Intentionally Added      | Abrasive, Absorbent, Adhesive | true  | true      |
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


Scenario: [139385] CA Cleaning - Generic Ingredient Used

Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Bleach
Then I save the product information as: TestCase139385
Given I call Shared Step 57501 (Product Characteristics - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue - HP)
Given I set the Which one best describes your product option to: Product is not considered a pesticide product
Given In the Additional Product Information Screen I answer the questions as follows - US only - No to GHS - No to shipped supplier - Yes to CA Cleaning - No to Private Label - No to Sold to retailer)
Given In the Claifornia Cleaning Product Disclosure I choose 'Manufacturer' and select 'No' for CBI, then enter Placeholder Details
Given I click continue
Given I add the following CA Cleaning ingredients:  
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName | IngredientType      | FunctionalPurpose             | Clean | Certified |
		| RR-05150-3    | 100     | false               | false       | AQUA       | Intentionally Added | Abrasive, Absorbent, Adhesive | true  | true      |
Given I click continue
Then I confirm I see the error message types in the popup with the following title: California Cleaning Right to Know
| Error                                   |
| Generic                                 |
| Publicly Disclosed or Trade Secret      |
| Ingredient Type                         |
Then I click the close button for the CA Cleaning Ingredients Popup
Then I click the 'x' button for component number 1
Given I click: YES in the 'Remove Component from My Ingredients' pop up
Given I add the following CA Cleaning ingredients:  
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName     | IngredientType      | FunctionalPurpose             | Clean | Certified |
		| Water         | 100     | false               | false       | AQUA           | Intentionally Added | Abrasive, Absorbent, Adhesive | true  | true      |
Then I click continue
And I should see the Waste Classification Data Page
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase139385


Scenario: [139387] CA Cleaning - 100% Formula Total (Minimum)

Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Bleach
Then I save the product information as: TestCase139387
Given I call Shared Step 57501 (Product Characteristics - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue - HP)
Given I set the Which one best describes your product option to: Product is not considered a pesticide product
Given In the Additional Product Information Screen I answer the questions as follows - US only - No to GHS - No to shipped supplier - Yes to CA Cleaning - No to Private Label - No to Sold to retailer)
Given In the Claifornia Cleaning Product Disclosure I choose 'Manufacturer' and select 'No' for CBI, then enter Placeholder Details
Given I click continue
Given I add the following CA Cleaning ingredients:  
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName | IngredientType      | FunctionalPurpose             | Clean | Certified |
		| Water         | 10      | false               | false       | AQUA       | Intentionally Added | Abrasive, Absorbent, Adhesive | true  | true      |
Given I click continue
Then I confirm I see the error message types in the popup with the following title: California Cleaning Right to Know
| Error                                   |
| Percent                                 |
Then I click the close button for the CA Cleaning Ingredients Popup
Then I click the 'x' button for component number 1
Given I click: YES in the 'Remove Component from My Ingredients' pop up
Given I add the following CA Cleaning ingredients:  
		| ComponentName | Percent  | PublicallyDisclosed | TradeSecret | PublicName     | IngredientType      | FunctionalPurpose             | Clean | Certified |
		| Water         | 100      | false               | false       | AQUA       | Intentionally Added | Abrasive, Absorbent, Adhesive | true  | true      |
Then I click continue
And I should see the Waste Classification Data Page
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase139387


Scenario: [139388] CA Cleaning - Public Disclosure or Trade Secret Issue

Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Bleach
Then I save the product information as: TestCase139388
Given I call Shared Step 57501 (Product Characteristics - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue - HP)
Given I set the Which one best describes your product option to: Product is not considered a pesticide product
Given In the Additional Product Information Screen I answer the questions as follows - US only - No to GHS - No to shipped supplier - Yes to CA Cleaning - No to Private Label - No to Sold to retailer)
Given In the Claifornia Cleaning Product Disclosure I choose 'Manufacturer' and select 'No' for CBI, then enter Placeholder Details
Given I click continue
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



Scenario: [139205] CA Cleaning - Ingredient Validation Upon Continue or Save

Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Bleach
Then I save the product information as: TestCase139205
Given I call Shared Step 57501 (Product Characteristics - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue - HP)
Given I set the Which one best describes your product option to: Product is not considered a pesticide product
Given In the Additional Product Information Screen I answer the questions as follows - US only - No to GHS - No to shipped supplier - Yes to CA Cleaning - No to Private Label - No to Sold to retailer)
Given In the Claifornia Cleaning Product Disclosure I choose 'Manufacturer' and select 'No' for CBI, then enter Placeholder Details
Given I click continue
Given I add the following CA Cleaning ingredients:  
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName | IngredientType      | FunctionalPurpose             | Clean | Certified |
		| RR-05150-3    | 10      | false               | true        | AQUA       | Intentionally Added | Abrasive, Absorbent, Adhesive | true  | true      |
Given I click continue
Then I confirm I see the error message types in the popup with the following title: California Cleaning Right to Know
| Error                                   |
| Generic                                 |
| Percent                                 |
| Publicly Disclosed or Trade Secret      |
| Ingredient Type                         |
Then I click the close button for the CA Cleaning Ingredients Popup
Then I click the 'x' button for component number 1
Given I click: YES in the 'Remove Component from My Ingredients' pop up
Given I add the following CA Cleaning ingredients:  
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName | IngredientType      | FunctionalPurpose | Clean | Certified |
		| Water         | 100     | false               | false       | AQUA       | Intentionally Added | Abrasive, Absorbent, Adhesive | true  | true      |
Then I click continue
And I should see the Waste Classification Data Page
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase139205


Scenario: [139193] CA Cleaning - Initial Message to Registrant for Ingredients

Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Bleach
Then I save the product information as: TestCase139193
Given I call Shared Step 57501 (Product Characteristics - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue - HP)
Given I set the Which one best describes your product option to: Product is not considered a pesticide product
Given In the Additional Product Information Screen I answer the questions as follows - US only - No to GHS - No to shipped supplier - Yes to CA Cleaning - No to Private Label - No to Sold to retailer)
Given In the Claifornia Cleaning Product Disclosure I choose 'Manufacturer' and select 'No' for CBI, then enter Placeholder Details
Given I click continue
Given I confirm there is a message displayed at the top of the Ingredients page
Given I confirm there is a checkbox with the following text: Don't show this again in the message displayed at the top of the Ingredients page
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase139193
