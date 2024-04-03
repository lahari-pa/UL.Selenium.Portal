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
@StepsPrototype
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:NewProduct
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:TheProduct
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:ProductInformation
@PhysicalAndChemicalProp
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:CaliforniaCleaningProductDisclosure

Feature:  California Cleaning Scenarios


#@ignore
@TestCase:139531
Scenario: [139531] CA Cleaning - Ingredient Type Missing

Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Bleach
Then I save the product information as: TestCase139531
Given I set the Which best describes your product, including when FIFRA 25(b) Exempt option to: Product is intended for preventing, destroying, repelling, or mitigating pests (including insects, rodents, mold, virus, bacteria, and other micro-organisms)
Then I set the value 'FIFRAPopupExpected' to be: true
Given In the Product Information Screen I answer the questions as follows - US only - No to GHS - No to shipped supplier - Yes to CA Cleaning - No to Private Label - No to Sold to retailer)
Given I call Shared Step 57501 (Physical and Chemical Properties - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue - HP)
Given In the Claifornia Cleaning Product Disclosure I choose 'Manufacturer' and select 'No' for CBI, then enter Placeholder Details
Given I click continue
Given I add the following CA Cleaning ingredients:  
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName | GenericName | IngredientType | FunctionalPurpose             | Clean | Certified |
		| Water         | 100      | false               | true        | AQUA       | AQUA        | Choose...      | Abrasive, Absorbent, Adhesive | true  | true      |
Given I click continue
Then I should see an error message: Your product registration qualifies for the California SB 258 Cleaning Right-to-Know regulation based on the type of product being registered, as well as chemicals included with the registration.
Then I should see an error message: Ingredients require Functional Purpose or Ingredient Type selections for one or more listed ingredients.
And I confirm the 'Select all' checkbox in the Ingredients table is unchecked
	And I click 'Select all' in the Ingredients table
	And I confirm that all ingredients in the table are selected
	And I click the 'Delete' button in the Ingredients table
	And I confirm the 'Remove selected components' popup is displayed with message: Are you sure you want to remove all selected components?
	And in the modal dialog I click the "YES" button
	And I confirm there are a total of: 0 ingredients in the table

Given I add the following CA Cleaning ingredients:  
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName     | GenericName | IngredientType      | FunctionalPurpose             | Clean | Certified |
		| Water         | 100     | false               | true        | AQUA           | AQUA1       | Fragrance           | Fragrance Component           | true  | true      |
Then I click continue
And I should see the Waste Classification Data Page
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase139531




#@ignore
@TestCase:139534
Scenario: [139534] CA Cleaning - Fragrance Component and Functional Purpose MisMatch 

Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Bleach
Then I save the product information as: TestCase139534
Given I set the Which best describes your product, including when FIFRA 25(b) Exempt option to: Product is intended for preventing, destroying, repelling, or mitigating pests (including insects, rodents, mold, virus, bacteria, and other micro-organisms)
Then I set the value 'FIFRAPopupExpected' to be: true
Given In the Product Information Screen I answer the questions as follows - US only - No to GHS - No to shipped supplier - Yes to CA Cleaning - No to Private Label - No to Sold to retailer)
Given I call Shared Step 57501 (Physical and Chemical Properties - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue - HP)
Given In the Claifornia Cleaning Product Disclosure I choose 'Manufacturer' and select 'No' for CBI, then enter Placeholder Details
Given I click continue
Given I add the following CA Cleaning ingredients:  
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName     | IngredientType | FunctionalPurpose             | Clean | Certified |
		| Water         | 100     | false               | false       | AQUA           | Fragrance      | Abrasive, Absorbent, Adhesive | true  | true      |
Given I click continue
Then I confirm I see the error message types in the popup with the following title: California Cleaning Right to Know
| Error                                   |
| Functional Purpose                      |
Then I click the close button for the CA Cleaning Ingredients Popup
Then I click the 'x' button for component number 1
Given I click: YES in the 'Remove Component from My Ingredients' pop up
Given I add the following CA Cleaning ingredients:  
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName     | IngredientType | FunctionalPurpose             | Clean | Certified |
		| Water         | 100     | false               | false       | AQUA           | Fragrance      |  | true  | true      |
Then I click continue
And I should see the Waste Classification Data Page
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase139534


@ignore
@TestCase:139385
Scenario: [139385] CA Cleaning - Generic Ingredient Used

Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Bleach
Then I save the product information as: TestCase139385
Given I set the Which best describes your product, including when FIFRA 25(b) Exempt option to: Product is not a pesticide and does not make or imply a pesticidal claim on the labeling or in the product description (ex. kills, sterilizes, disinfects, sanitizes, antimicrobial)
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


#@ignore
@TestCase:139387
Scenario: [139387] CA Cleaning - 100% Formula Total (Minimum)

Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Bleach
Then I save the product information as: TestCase139387
Given I set the Which best describes your product, including when FIFRA 25(b) Exempt option to: Product is intended for preventing, destroying, repelling, or mitigating pests (including insects, rodents, mold, virus, bacteria, and other micro-organisms)
Then I set the value 'FIFRAPopupExpected' to be: true
Given In the Product Information Screen I answer the questions as follows - US only - No to GHS - No to shipped supplier - Yes to CA Cleaning - No to Private Label - No to Sold to retailer)
Given I call Shared Step 57501 (Physical and Chemical Properties - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue - HP)
Given In the Claifornia Cleaning Product Disclosure I choose 'Manufacturer' and select 'No' for CBI, then enter Placeholder Details
Given I click continue
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


#@ignore
@TestCase:139388
Scenario: [139388] CA Cleaning - Public Disclosure or Trade Secret Issue

Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Bleach
Then I save the product information as: TestCase139388
Given I set the Which best describes your product, including when FIFRA 25(b) Exempt option to: Product is intended for preventing, destroying, repelling, or mitigating pests (including insects, rodents, mold, virus, bacteria, and other micro-organisms)
Then I set the value 'FIFRAPopupExpected' to be: true
Given In the Product Information Screen I answer the questions as follows - US only - No to GHS - No to shipped supplier - Yes to CA Cleaning - No to Private Label - No to Sold to retailer)
Given I call Shared Step 57501 (Physical and Chemical Properties - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue - HP)
Given In the Claifornia Cleaning Product Disclosure I choose 'Manufacturer' and select 'No' for CBI, then enter Placeholder Details
Given I click continue
Given I add the following CA Cleaning ingredients:  
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName | IngredientType      | FunctionalPurpose             | Clean | Certified |
		| Water         | 10       | false               | false       | AQUA       | Intentionally Added | Abrasive, Absorbent, Adhesive | true  | true      |
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
	Given I set the Which best describes your product, including when FIFRA 25(b) Exempt option to: Product is not a pesticide and does not make or imply a pesticidal claim on the labeling or in the product description (ex. kills, sterilizes, disinfects, sanitizes, antimicrobial)
	Then I set the value 'FIFRAPopupExpected' to be: true
	Given In the Product Information Screen I answer the questions as follows - US only - No to GHS - No to shipped supplier - Yes to CA Cleaning - No to Private Label - No to Sold to retailer)
	Given I call Shared Step 57501 (Physical and Chemical Properties - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue - HP)
	Given In the Claifornia Cleaning Product Disclosure I choose 'Manufacturer' and select 'No' for CBI, then enter Placeholder Details
	Given I click continue
	Given I call Shared Step 65447 Ingredients - Add any chemical - DO Not click Continue
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| RR-39229-0    | 10      | false               | false       |            |
	Given I click continue
	Then I should see an error message: Your product registration qualifies for the California SB 258 Cleaning Right-to-Know regulation based on the type of product being registered, as well as chemicals included with the registration.
	Then I should see an error message: Your product's ingredients contain a Generic Ingredient, meaning the CAS number is not valid (Starts with an alphabetic identifier). Please select an appropriate ingredient or utilize a 3rd-Party Ingredient.
	Then I should see an error message: Ingredients require Functional Purpose or Ingredient Type selections for one or more listed ingredients.

	#Then I confirm I see the error message with text: and of type: Generic in the popup with the following title: California Cleaning Right to Know
	#| ErrorSections                                                                                                                                                                                                                                     |
	#| Generic ingredients are not permitted as they cannot be screened for Chemicals of Concern. Each ingredient must use any of the following:                                                                                                         |
	#| Valid Chemical Abstract Service identifier (CAS number); or                                                                                                                                                                                       |
	#| Valid 3rd-Party Formula registration (CAS begins with "WPS"); or                                                                                                                                                                                  |
	#| Valid CAS Addition (CAS begins with NA)                                                                                                                                                                                                           |
	#| Please note that use of an ingredient with a CAS beginning with NA may result in a suspension of the registration requiring more information or details. You should always use a valid CAS number or 3rd-Party Formula before using an NA option. |
	#
	#Then I confirm I see the error message with text: and of type: Percent in the popup with the following title: California Cleaning Right to Know
	#| ErrorSections                                                                       |
	#| Percentages must total a minimum of 100%. Please check your ingredient percentages. |
	#
	#Then I confirm I see the error message with text: and of type: Publicly Disclosed or Trade Secret in the popup with the following title: California Cleaning Right to Know
	#| ErrorSections                                                                                                                                                                                                                                                                                                                                                                      |
	#| Participation in the California Cleaning Right to Know requires that all ingredients either be Publicly Disclosed or be a valid Trade Secret ingredient. Some information on claiming a trade secret is available on the U.S. Food and Drug Administration (FDA) website. Even when indicating a Trade Secret, you must provide a generic name for the ingredient where indicated. |
	#| Publicly Disclosed ingredients must have a selection made under the Public Name options for the listed name of the ingredient as it appears on the product label.                                                                                                                                                                                                                  |
	#| Ingredients present on the California Chemicals of Concern list under this regulation require public disclosure of the ingredient and you are unable to adjust this setting within the registration. See our Terms of Service for more information regarding disclosure of ingredients per regulatory requirement.                                                                 |
	#| Please update the information as needed to proceed.                                                                                                                                                                                                                                                                                                                                |
	#
	#Then I confirm I see the error message with text: and of type: Ingredient Type in the popup with the following title: California Cleaning Right to Know
	#| ErrorSections                                                                                                                                                                                                                                       |
	#| Participation in the California Cleaning Right to Know requires that each ingredient have an indication of the type of ingredient it is within the product. Please include, for each ingredient, the Ingredient Type from the selections available. |
	#
	#Then I confirm that the number of errors found in the Ingredients Popup matches the expectation of: 4
	#Then I click the close button for the CA Cleaning Ingredients Popup
	#And The ingredients error message should be showing: Please fix all errors related to California Cleaning Right to Know before proceeding.
	Given I click the Home navigation icon
	Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase139205




@TestCase:139193
Scenario: [139193] CA Cleaning - Initial Message to Registrant for Ingredients

Given I log in with the account saved in TReVor as: ProductAccount
#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I click the Add Product icon in the Navigation Pane
Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: Create a New Registration
Given in the New Product page I click Continue
#Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Bleach
Then I should see the The Product Page
Then In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)' to: Bleach
Then I set 'Type of Product' to: Bleach
Then I click continue
Then I save the product information as: TestCase139193
#Given In the Product Information Screen I answer the questions as follows - US only - No to GHS - No to shipped supplier - Yes to CA Cleaning - No to Private Label - No to Sold to retailer)
#Given I set the Which best describes your product, including when FIFRA 25(b) Exempt option to: Product is not a pesticide and does not make or imply a pesticidal claim on the labeling or in the product description (ex. kills, sterilizes, disinfects, sanitizes, antimicrobial)
#Then I set the value 'FIFRAPopupExpected' to be: true
Then I should see the Product Information Page
When In the Product Information Section, set the option in section: 'Which best describes your product, including when FIFRA 25(b) Exempt' to: Product is not a pesticide and does not make or imply a pesticidal claim on the labeling or in the product description (ex. kills, sterilizes, disinfects, sanitizes, antimicrobial)
When In the Product Information Section, set the option in section: 'Cleaning products must comply with California's Cleaning Product Right to Know Act. I would like to provide the additional information needed for this program during registration.' to: No
When In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
When In the Product Information Section, set the option in section: 'Cleaning products must comply with California's Cleaning Product Right to Know Act. I would like to provide the additional information needed for this program during registration.' to: Yes
When In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
When In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
When In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
Then in the Product Information page, I click Continue
Then I should see the Regulatory Documents to Provide Page
Then I set the OSHA-compliant Safety Data Sheet, English field to: Request to author	
Then I click continue
#Given I call Shared Step 57501 (Physical and Chemical Properties - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue - HP)
Then I should see the Physical and Chemical Properties Page
Given In the Physical and Chemical Properties Section, set the option in section: 'Primary Physical State' to: Solid
Given In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
Given In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
Given In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
Then in the Physical and Chemical Properties page, I click Continue
Then I should see the California Cleaning Product Disclosure Page
#Given In the Claifornia Cleaning Product Disclosure I choose 'Manufacturer' and select 'No' for CBI, then enter Placeholder Details
Given In the California Cleaning Product Disclosure Section, set the radio option in section: 'Who is publicly identified on the product label as responsible for the product?': to: Manufacturer
Given In the California Cleaning Product Disclosure Section, set the option in section: 'Who is the Final Domestic Distributor (if any) of the product?' to: Company Name
Given In the California Cleaning Product Disclosure Section, set the option in section: 'Is your identity, as the Manufacturer of this product, Confidential Business Information (CBI)?' to: No
Given In the California Cleaning Product Disclosure Section, set the option in section: 'Select the product's GTIN Brick Code' to: [10000424] Laundry Detergents
Then in the California Cleaning Product Disclosure page, I click Continue
Given I confirm there is a message displayed at the top of the Ingredients page
Given I confirm there is a checkbox with the following text: Don't show this again in the message displayed at the top of the Ingredients page
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase139193



@ignore
@TestCase:139445
Scenario: [139445] CA Cleaning - Ingredients Screen - Validation for INTENTIONALLY ADDED Ingredient Type and Multi-Select Functional Purpose

Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): General Purpose Cleaner - Non-aerosol
Then I save the product information as: TestCase139445
Given I set the Which best describes your product, including when FIFRA 25(b) Exempt option to: Product is intended for preventing, destroying, repelling, or mitigating pests (including insects, rodents, mold, virus, bacteria, and other micro-organisms)
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



@ignore
@TestCase:158172
Scenario: [158172] CA Cleaning - Ingredients Screen - Trade Secret Validation - 

Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
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
