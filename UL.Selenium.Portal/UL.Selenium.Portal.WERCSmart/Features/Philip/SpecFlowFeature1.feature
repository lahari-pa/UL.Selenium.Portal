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
@SummaryPage
@SHA
@UPC
@run_AdditionalProductInformation
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
@SHA
@CreateProducts
@ForwardProductRegistration
@PaymentMethods
@ProductSetUp
@run_AccountHasStewardshipInfo
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
@Studio
@SHA
@UPC
@run_StwdInWpsStudiofeature
@Philip
@Shared
@NewProduct
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
@SummaryPage
@PaymentMethods
@SubEnrollment
@WERCSmart_Signup
@MyAccount
@PackagingTypes
@Brands
@MyIngredients
@UPC
@ProductSetUp
@SHA
@Studio
@ForwardProductRegistration
@ProductSetUp
@SupplierReports
@CreateProducts
@ViewUpcs
@Solutions
@run_NotIncludedGeneralTests
@Shared
@NewProduct
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
@SummaryPage
@PaymentMethods
@SubEnrollment
@WERCSmart_Signup
@MyAccount
@PackagingTypes
@Brands
@MyIngredients
@UPC
@ProductSetUp
@SHA
@Studio
@ForwardProductRegistration
@ProductSetUp
@SupplierReports
@CreateProducts
@ViewUpcs
@Solutions
@run_NotIncludedGeneralTests
@Shared
@NewProduct
@Homepage
@Shared
@wercsmart
@Login
@UlSolutionCenter
@Homepage
@ProductGrid
@ForwardProductRegistration
@NewProduct
@RetailPartners
@MessageCenter
@MyAccount
@LandingPage
@DocumentAcceptance
@DeleteActiveProducts
@Solutions
@UPC
@ReviewDocuments
@SHA
@MyMessages
@run_MyMessages
@Shared
@wercsmart
@Login
@UlSolutionCenter
@Homepage
@ProductGrid
@ForwardProductRegistration
@NewProduct
@RetailPartners
@MessageCenter
@MyAccount
@LandingPage
@DocumentAcceptance
@DeleteActiveProducts
@Solutions
@UPC
@ReviewDocuments
@SHA
@MyMessages
@run_MyMessages
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
@PaymentMethods
@SHA
@CreateProducts
@Studio
@ProductSetUp
@ProductGrid
@Shared
@Login
@UlSolutionCenter
@Homepage
@ProductGrid
@ForwardProductRegistration
@NewProduct
@RetailPartners
@MessageCenter
@MyAccount
@LandingPage
@DocumentAcceptance
@DeleteActiveProducts
@Portal_ULSC
@ULSC
@Shared
@Pharma
@CreateProducts
@run_Transportation

Feature: ChooseGoodGuide.com Scenarios


Scenario: [87275] US & Canada - PL = Yes, Retailer is NOT Canadian Tire, no error re package type on forward
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Given I filter the products by: Accepted by Retailers
Given I search for the product saved as: TestCase86187
And I Confirm the Products shown display the Green Colour Status - which is the Accepted by Retailers
And I call Shared Step 75130 - Bulk Actions - Select Forward Product Registration
And I enter the text: saved as TestCase86187 in the 'Search by WPS ID or Product Name' field
And In the Foward Product Registration Screen I should see product: saved as TestCase86187
And In the Foward Product Registration Screen I Select the product: saved as TestCase86187
And I click continue on the Forward Product Registration page
And In the Forward Product Registration Screen I select the first retailer that does not require additional data and is not: Canadian Tire under Other Retailers and save it as: retailer87217
And I click continue on the Forward Product Registration page
And I call Shared Step 86002 (Forwarding - PLP - Select Product: saved as TestCase86187 & UPCs step - Edit existing UPC Confirm)

And If the Private Label textbox is showing in the Select UPCs screen, I enter the value: N/A
And I call Shared Step 86824 (Forwarding - Select Existing UPC, Click Continue, No error for Package type)

And I should see the subheading 3: Product Results on the Forward Product Registration window
And I click continue on the Forward Product Registration page
And I should see the subheading 3: Review & Submit on the Forward Product Registration window
And I select the true radio for the 'Are Statements True' question under the Review and Submit tab
And I click continue on the Forward Product Registration page
And In the Purchase Summary screen I confirm the Purchase Summary header is displayed
Then In the Thank You screen I confirm the following statement is shown: Thank you for registering your product on WERCSmart for assessment.



Scenario: [85963] Forward Product - US Only - PL = Yes, Packaging type not required/shown
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Given I filter the products by: Accepted by Retailers
Given I search for the product saved as: TestCase86187
And I Confirm the Products shown display the Green Colour Status - which is the Accepted by Retailers
And I call Shared Step 75130 - Bulk Actions - Select Forward Product Registration
And I enter the text: saved as TestCase86187 in the 'Search by WPS ID or Product Name' field
And In the Foward Product Registration Screen I should see product: saved as TestCase86187
And In the Foward Product Registration Screen I Select the product: saved as TestCase86187
And I click continue on the Forward Product Registration page
And In the Forward Product Registration Screen I select the first retailer that does not require additional data and is not: Canadian Tire under Other Retailers and save it as: retailer87217
And I click continue on the Forward Product Registration page
And I call Shared Step 86002 (Forwarding - PLP - Select Product: saved as TestCase86187 & UPCs step - Edit existing UPC Confirm)

#And If the Private Label textbox is showing in the Select UPCs screen, I enter the value: N/A
#And I call Shared Step 86824 (Forwarding - Select Existing UPC, Click Continue, No error for Package type)

And I should see the subheading 3: Product Results on the Forward Product Registration window
And I click continue on the Forward Product Registration page
And I should see the subheading 3: Review & Submit on the Forward Product Registration window
And I select the true radio for the 'Are Statements True' question under the Review and Submit tab
And I click continue on the Forward Product Registration page
And In the Purchase Summary screen I confirm the Purchase Summary header is displayed
Then In the Thank You screen I confirm the following statement is shown: Thank you for registering your product on WERCSmart for assessment.


Scenario: [87922] Universal Product Code (UPC) Step - Add Case UPC - Size (Weight Ounces) field validation
Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Bleach
Given I generate a random UPC number and save as: UPC87633
Then I save the product information as: TestCase87633
Given I call Shared Step 57501 (Product Characteristics - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue - HP)
Given I set the Which one best describes your product option to: Product is not considered a pesticide product
Given I call Shared Step 118064 (Additional Product Information - US only - No GHS, Not Direct Ship, Not CA Cleaning ,Not PLP, Not GNFR > Continue - Happy Path)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Chlorine
Then I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
Then I call Shared Step 126160 (U.S. Department of Transportation (DOT) Classification - Enter UN1057 - Lighter Fluid)
Given I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue) for
| Retailer  |
| Walgreens |
And I should see the Universal Product Code Page
And I call Shared Step 87647 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC87633, container type: Plastic Container and size: abc do not click continue
Given I check for the appropriate alert: This field must be a number
Given I fill in the UPC data; UPC:UPC87633, Product Type:Plastic Container, Product Weight: +6
Then I click continue
Given I check for the appropriate alert: This field must be a number
Given I fill in the UPC data; UPC:UPC87633, Product Type:Plastic Container, Product Weight: 6
Then I check for the appropriate alert: No error
Then I click continue
And I should see the Regulatory Documents to Provide Page
Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase87633



Scenario: [87631] Universal Product Code (UPC) Step - Add Case UPC - Size (Weight Ounces) field validation
Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Bleach
Given I generate a random UPC number and save as: UPC87633
Then I save the product information as: TestCase87633
Given I call Shared Step 57501 (Product Characteristics - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue - HP)
Given I set the Which one best describes your product option to: Product is not considered a pesticide product
Given I call Shared Step 118064 (Additional Product Information - US only - No GHS, Not Direct Ship, Not CA Cleaning ,Not PLP, Not GNFR > Continue - Happy Path)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Chlorine
Then I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
Then I call Shared Step 126160 (U.S. Department of Transportation (DOT) Classification - Enter UN1057 - Lighter Fluid)
Given I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue) for
| Retailer  |
| Walgreens |
And I should see the Universal Product Code Page
And I call Shared Step 87647 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC87633, container type: Plastic Container and size: abc do not click continue
Given I check for the appropriate alert: This field must be a number
Given I fill in the UPC data; UPC:UPC87633, Product Type:Plastic Container, Product Weight: +6
Then I click continue
Given I check for the appropriate alert: This field must be a number
Given I fill in the UPC data; UPC:UPC87633, Product Type:Plastic Container, Product Weight: 6
Then I check for the appropriate alert: No error
Then I click continue
And I should see the Regulatory Documents to Provide Page
Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase87633



Scenario: [87633] Universal Product Code (UPC) Step - Add Case UPC - Size (Weight Ounces) field validation
Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Bleach
Given I generate a random UPC number and save as: UPC87633
Then I save the product information as: TestCase87633
Given I call Shared Step 57501 (Product Characteristics - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue - HP)
Given I set the Which one best describes your product option to: Product is not considered a pesticide product
Given I call Shared Step 118064 (Additional Product Information - US only - No GHS, Not Direct Ship, Not CA Cleaning ,Not PLP, Not GNFR > Continue - Happy Path)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Chlorine
Then I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
Then I call Shared Step 126160 (U.S. Department of Transportation (DOT) Classification - Enter UN1057 - Lighter Fluid)
Given I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue) for
| Retailer  |
| Walgreens |
And I should see the Universal Product Code Page
And I call Shared Step 87647 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC87633, container type: Plastic Container and size: abc do not click continue
Given I check for the appropriate alert: This field must be a number
Given I fill in the UPC data; UPC:UPC87633, Product Type:Plastic Container, Product Weight: +6
Then I click continue
Given I check for the appropriate alert: This field must be a number
Given I fill in the UPC data; UPC:UPC87633, Product Type:Plastic Container, Product Weight: 6
Then I check for the appropriate alert: No error
Then I click continue
And I should see the Regulatory Documents to Provide Page
Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase87633




Scenario: [139531] CA Cleaning - Ingredient Type Missing

Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Bleach
Given I call Shared Step 57501 (Product Characteristics - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue - HP)
Given In the Additional Product Information Screen I answer the questions as follows - US only - No to GHS - No to shipped supplier - Yes to CA Cleaning - No to Private Label - No to Sold to retailer)
Given In the Claifornia Cleaning Product Disclosure I choose 'Manufacturer' and select 'No' for CBI, then enter Placeholder Details
Given I add the following ingredients:
| ComponentName | Percent | PublicallyDisclosed | PublicName | TradeSecret |
| Water         | 10      | No                  |            | Yes         |
Given I click continue
# Ensure that you see an 
Then I confirm I see the error message types in the popup with the following title: California Cleaning Right to Know
| Error                                                  |
| GenericInUse                                           |
| LessThan100Percent                                     |
| PublicDisclosureOrTradeSecretIssue                     |
| IngredientTypeMissing                                  |
| FragranceComponentFunctionalPurposeMismatch            |
| NonFunctionalIngredientDisclosureIssue                 |
| CAHCPPublicDisclosureIssues                            |
| NonFunctionalIngredientTypeOrFunctionalPurposeMismatch |
| PVBOTThirdPartyError                                   |
Then I click the close button for the popup with the following title: California Cleaning Right to Know
Then I add the following ingredients:
	| ComponentName	| Percent | PublicallyDisclosed | TradeSecret | PublicName |
	| Water         | 100     | false               | true        | Aqua       |
Then I click continue
And I should see the Waste Classification Data Page
Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TheProduct




#Scenario: [139531] CA Cleaning - Ingredient Type Missing
#
#Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
#Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Bleach
#Given I call Shared Step 57501 (Product Characteristics - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue - HP)
#Given In the Additional Product Information Screen I answer the questions as follows - US only - No to GHS - No to shipped supplier - Yes to CA Cleaning - No to Private Label - No to Sold to retailer)
#Given In the Claifornia Cleaning Product Disclosure I choose 'Manufacturer' and select 'No' for CBI, then enter Placeholder Details
#Given I add the following ingredients:
#| ComponentName | Percent | PublicallyDisclosed | PublicName | TradeSecret |
#| Water         | 10      | No                  |            | Yes         |
#Given I click continue
## Ensure that you see an error popup
## Ensure that the error in the popup matches the error in the screenshot attached to this TFS test case
## Exit the error popup
## Add an Ingredient Type for your Water ingredient
#Then I confirm I see the error message types in the popup with the following title: California Cleaning Right to Know
#| Error                                                  |
#| GenericInUse                                           |
#| LessThan100Percent                                     |
#| PublicDisclosureOrTradeSecretIssue                     |
#| IngredientTypeMissing                                  |
#| FragranceComponentFunctionalPurposeMismatch            |
#| NonFunctionalIngredientDisclosureIssue                 |
#| CAHCPPublicDisclosureIssues                            |
#| NonFunctionalIngredientTypeOrFunctionalPurposeMismatch |
#| PVBOTThirdPartyError                                   |
#Then I click the close button for the popup with the following title: California Cleaning Right to Know
#Then I add the following ingredients:
#	| ComponentName	| Percent | PublicallyDisclosed | TradeSecret | PublicName |
#	| Water         | 100     | false               | true        | Aqua       |
#Then I click continue
#And I should see the Waste Classification Data Page
#Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TheProduct



Scenario: [139534] CA Cleaning - Fragrance Component and Functional Purpose MisMatch

Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Bleach
Given I call Shared Step 57501 (Product Characteristics - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue - HP)
Given I set the Which one best describes your product option to: Product is not considered a pesticide product
Given In the Additional Product Information Screen I answer the questions as follows - US only - No to GHS - No to shipped supplier - Yes to CA Cleaning - No to Private Label - No to Sold to retailer)
Given In the Claifornia Cleaning Product Disclosure I choose 'Manufacturer' and select 'No' for CBI, then enter Placeholder Details
Given I add the following ingredients:
| ComponentName | Percent | PublicallyDisclosed | PublicName | TradeSecret |
| Water         | 100     | No                  |            | Yes         |
# In the ingredient screen, add water at 100%. Select Trade Secret and add a Generic Name. Select Fragrance as Ingredient Type.
# If the Functional Purpose auto-populates to Fragrance, change it to something else. If it hasn't auto populated, simply put any functional purpose that isn't Fragrance.
Given I click continue
# Ensure that the error in the popup matches the error in the screenshot attached to this TFS test case
Then I click the close button for the popup with the following title: California Cleaning Right to Know
# Change the Functional Purpose to Fragrance
Given I click continue
And I should see the Waste Classification Data Page
Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TheProduct





Scenario: [128140] Data Tier Expansion for BBB - Products in Scope Report - Nutritional Supplement - Nutritional Supplement - Solid

Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561a (The Product - Enter Product Name: Nutritional (Solid) Supplement Product for BBB and select Type of Product): Nutritional Supplement - Solid
Given I generate a random UPC number and save as: UPC128140
Given I call Shared Step 37857 (Enter Physical Property - Solid)
And I call Shared Step 62678 (Additional Product Information - US & Canada, No Child, No OSHA, NO Direct ship, No PL, No NGFR - Continue, Happy path)
Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
| CASNumber | ComponentName | Percent | PublicallyDisclosed | PublicName | TradeSecret |
| 56-85-9   | L-Glutamine   | 100     |                     |            |             |
And I call Shared Step 57637 (Regulatory Information 1 - TSCA & CEPA shown, No to PROP 65 - Continue - Happy Path)
#Given I set the Refer to your Product Label. From the options, select those that appear on the Label. option to: None of the Above
Given I call Shared Step 132473 (Regulatory Information 3 - Nutritional Category)
#Given I click continue
Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Bed Bath and Beyond (including Harmon, Buy Buy Baby, and Christmas Tree Shops)
Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC128140, container type: Plastic Container and size: 6.2
Given I call Shared Step 60567 (Upload Product Label only)
Given in the Optional Reports and Documents Available for Purchase page I click Continue
Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: «comments»
Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
Given I call Shared Step 130558 (Go to Retail Partners - Select Bed Bath and Beyond)
Given I click the Products in Scope button and confirm that an excel file is produced called BB_Report_DataUsageTier_Current_Month_Day_Year.xlsx and save as Products in Scope Report for BBB
Then I confirm the excel file saved as: Products in Scope Report for BBB contains the following data: Nutritional (Solid) Supplement Product for BBB Product for BBB
#Given I delete the excel file saved as Products in Scope Report for BBB


Scenario: [139385] CA Cleaning - Generic Ingredient Used

Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Bleach
Given I call Shared Step 57501 (Product Characteristics - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue - HP)
Given In the Additional Product Information Screen I answer the questions as follows - US only - No to GHS - No to shipped supplier - Yes to CA Cleaning - No to Private Label - No to Sold to retailer)
Given In the Claifornia Cleaning Product Disclosure I choose 'Manufacturer' and select 'No' for CBI, then enter Placeholder Details
Given I add the following ingredients:
| ComponentName | Percent | PublicallyDisclosed | PublicName | TradeSecret |
| RR-05150-3    | 100     | No                  | Aqua       | Yes         |
# Enter CAS number RR-05150-3 as your first ingredient. Set its percentage to 100%. Select Trade Secret and add a Generic Name. Add a functional purpose and ingredient type.
Given I click continue
# Ensure that you see an error popup on the screen
# Ensure that there is an error present that matches the screenshot attached to this TFS test case
Then I click the close button for the popup with the following title: California Cleaning Right to Know
# Delete ingredient RR-05150-3 from the formulation
# Add ingredient Water at 100%
# select Trade secret for your Water ingredient and add a Generic Name
# Add a Ingredient Type and Functional Purpose for your Water ingredient
Given I click continue
And I should see the Waste Classification Data Page
Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TheProduct


Scenario: [139387] CA Cleaning - 100% Formula Total (Minimum)

Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Bleach
Given I call Shared Step 57501 (Product Characteristics - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue - HP)
Given In the Additional Product Information Screen I answer the questions as follows - US only - No to GHS - No to shipped supplier - Yes to CA Cleaning - No to Private Label - No to Sold to retailer)
Given In the Claifornia Cleaning Product Disclosure I choose 'Manufacturer' and select 'No' for CBI, then enter Placeholder Details
Given I add the following ingredients:
| ComponentName | Percent | PublicallyDisclosed | PublicName | TradeSecret |
| Water         | 10      | No                  |            | Yes         |
Given I click continue
# Ensure that you see an error popup
# Ensure that the error popup contains the error in the screenshot attached to this TFS test case
Then I click the close button for the popup with the following title: California Cleaning Right to Know
# Set Water ingredient percentage to 100%
Given I click continue
And I should see the Waste Classification Data Page
Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TheProduct


Scenario: [139388] CA Cleaning - Public Disclosure or Trade Secret Issue

Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Bleach
Given I call Shared Step 57501 (Product Characteristics - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue - HP)
Given I set the Which one best describes your product option to: Product is not considered a pesticide product
Given In the Additional Product Information Screen I answer the questions as follows - US only - No to GHS - No to shipped supplier - Yes to CA Cleaning - No to Private Label - No to Sold to retailer)
Given In the Claifornia Cleaning Product Disclosure I choose 'Manufacturer' and select 'No' for CBI, then enter Placeholder Details
Given I click continue
Then I add the following ingredients:
	| ComponentName	| Percent | PublicallyDisclosed | TradeSecret | PublicName |
	| Water         | 100     | false               | false       |            |
Then I click continue
Then I confirm I see the error message types in the popup with the following title: California Cleaning Right to Know
| Error                                                  |
| GenericInUse                                           |
| LessThan100Percent                                     |
| PublicDisclosureOrTradeSecretIssue                     |
| IngredientTypeMissing                                  |
| FragranceComponentFunctionalPurposeMismatch            |
| NonFunctionalIngredientDisclosureIssue                 |
| CAHCPPublicDisclosureIssues                            |
| NonFunctionalIngredientTypeOrFunctionalPurposeMismatch |
| PVBOTThirdPartyError                                   |
Then I click the close button for the popup with the following title: California Cleaning Right to Know
Then I add the following ingredients:
	| ComponentName	| Percent | PublicallyDisclosed | TradeSecret | PublicName |
	| Water         | 100     | false               | true        | Aqua       |
Then I click continue
And I should see the Waste Classification Data Page
Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TheProduct




Scenario: [139205] CA Cleaning - Ingredient Validation Upon Continue or Save

Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Bleach
Given I call Shared Step 57501 (Product Characteristics - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue - HP)
Given I set the Which one best describes your product option to: Product is not considered a pesticide product
Given In the Additional Product Information Screen I answer the questions as follows - US only - No to GHS - No to shipped supplier - Yes to CA Cleaning - No to Private Label - No to Sold to retailer)
Given In the Claifornia Cleaning Product Disclosure I choose 'Manufacturer' and select 'No' for CBI, then enter Placeholder Details
Then I click continue
And I should see the Ingredients Page
Then I add the following ingredients:
	| ComponentName	| Percent | PublicallyDisclosed | TradeSecret | PublicName |
	| RR-05150-3    | 10      | false               | false       |            |
Then I click continue
Then I confirm I see the four error messages in the popup with the following title: California Cleaning Right to Know
# Enter CAS number RR-05150-3 as your first ingredient. Set its percentage to 10%. Click continue
# Ensure that four (4) error messages appear in a popup on the screen
# Ensure that the error text matches the errors listed in the screenshot attached to ticket 126697
# Exit the popup
Then in page Ingredients page I should see error: Please fix all errors related to California Cleaning Right to Know before proceeding.
Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: ThisProduct



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
# Ensure that you see a message in blue at the top of the screen
# Ensure that the message matches the screenshot attached to ticket 126693
# Ensure that you see a checkbox in the message with the text "Don't show this again"
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase139193

Scenario: [87691] UPC - Case Pack, Recertification by WERCSmart User - Remove Case Pack Leaving Only Regular UPC
Given I Use Test case 87685 to create a product which has a Case UPC and a regular UPC, processed to completed status
Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
And I filter for the product saved as: TestCase87685
	And I Confirm the Products shown display the Green Colour Status - which is the Accepted by Retailers
	Given I click Bulk Actions in the Products Grid
	Then I should see a popup with header Bulk Actions
	And I click on the Row Action: Update Data
	And I should see the Update Registration popup
	And In the Update Registration popup I click on button Yes
	#And I If you are using a supplier registered for ULSC you will see the ULSC Service Data-Re-Import step, select the No, continue editing data radio button and click Save
	And I should see the The Product Page
	Then I click Save in The Product Page
	When In the New Product page I click tab: Recipient and UPC Details
	And I click the page heading: Universal Product Code (UPC)
	Then I confirm the case dropdown with the following UPC: saved as UPC87685 should be available for selection
    Then I Click Delete Rows
	Then I confirm the case dropdown with the following UPC: saved as UPC87685 should not be available for selection
    Then I click Continue and should not see an error message
	When In the New Product page I click tab: Review and Submit
	And I click the page heading: Additional Documents to Provide
	And I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	And In the Purchase Summary screen I confirm the Purchase Summary header is displayed
	And In the Purchase Summary screen if Product Billing is displayed I click Confirm Order

Scenario: [128144] Login Behavior for Products NOT in Scope for Bed Bath and Beyond

Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561a (The Product - Enter Product Name: Product NOT in Scope for BBB and select Type of Product): Pet Shampoo
Given I generate a random UPC number and save as: UPC128144
Given I call Shared Step 57441 (Product Characteristics - Primary Physical Property - Liquid)
And I call Shared Step 62678 (Additional Product Information - US & Canada, No Child, No OSHA, NO Direct ship, No PL, No NGFR - Continue, Happy path)
Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
| CASNumber  | ComponentName                   | Percent | PublicallyDisclosed | PublicName | TradeSecret |
| 61789-31-9 | Fatty Acids, coco, sodium salts | 100     |                     |            |             |
And I call Shared Step 57637 (Regulatory Information 1 - TSCA & CEPA shown, No to PROP 65 - Continue - Happy Path)
Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Bed Bath and Beyond (including Harmon, Buy Buy Baby, and Christmas Tree Shops)
And I call Shared Step 87647 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC128144, container type: Plastic Container and size: 6.2 do not click continue
Then I click continue
Given I call Shared Step 78868 - Regulatory Documents to Provide - US and Canada - Request authoring for both
Given I call Shared Step 60567 (Upload Product Label only)
Then I click continue
And I call Shared Step 64097 - Additional Documents -> Contact Information - Add any Name, address, phone and emergency phone - Happy Path
Given I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
		| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
	Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: «comments»
Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
Given I click the Products in Scope button and confirm that an excel file is produced called BB_Report_DataUsageTier_Current_Month_Day_Year.xlsx and save as PRODUCTS NOT IN SCOPE REPORT FOR BBB
# Confirm that the PRODUCT NAME: 'Product NOT in Scope for BBB' is NOT listed in the Report
Given I delete the excel file saved as PRODUCTS NOT IN SCOPE REPORT FOR BBB
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
# Confirm that the 'Data Consent Tier' Pop-Up Window Does Not Show



Scenario: [126286] Transportation Details DOT - UN1057 Prompts the 'For the Lighter, Provide the DOT Approval Number' Field

Given I call Shared Step 67284 (Login into WERCSmart Portal - Visual Automation Account)
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): LIGHTER FLUID
Given I generate a random UPC number and save as: UPC126286
Then I save the product information as: TestCase126286
Given I call Shared Step 57441 (Product Characteristics - Primary Physical Property - Liquid)
Then I confirm that the the option: United States is checked for the following section: Select countries the product may be sold in
Given I set the Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada) option to: No
Given I set the Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns. option to: No
Given I set the Product is a Retailer's Private Label or Brand option to: No
Given I set the Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale) option to: No
Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
| CASNumber  | ComponentName                                                               | Percent | PublicallyDisclosed | PublicName | TradeSecret |
| 68410-97-9 | Distillates, petroleum, light distillate hydrotreating process, low-boiling | 70      |                     |            |             |
| 64742-49-0 | Naphtha, petroleum, hydrotreated light                                      | 30      |                     |            |             |
Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
Then I call Shared Step 126160 (U.S. Department of Transportation (DOT) Classification - Enter UN1057 - Lighter Fluid)
Then in page U. S. Department of Transportation (DOT) Classification I should see no errors
And I click the page heading: U. S. Department of Transportation (DOT) Classification
And For the lighter, provide the DOT Approval Number (LAA) should be showing the value: 123
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase126286


Scenario: [87706] Universal Product Code (UPC) Step - Delete Case Pack row
Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Bubble solution
Given I generate a random UPC number and save as: UPC87706
Then I save the product information as: TestCase87706
And I call Shared Step 57514 (Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path)
And I should see the Additional Product Information Page
And I call Shared Step 85730 - Additional Product Information - Canada Only - Child (NO), GHS (NO), DSV (NO), PLP(YES), GNFR (NO), Continue
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Chlorine
And I call Shared Step 57911 (Regulatory Information 1 - CEPA only shown - Continue - Happy Path)
Then I call Shared Step  (Select Retailers Canadian Tire and enter additional requirements field - Indicate full name of product, as sold via this retailer)
Then I click continue
And I call Shared Step 87647 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC87706, container type: Plastic Container and size: 32 do not click continue
And I Select a package type from the drop down list
Then I select the case UPC dropdown arrow to collapse the UPC saved as: UPC87706
Then I confirm the case dropdown with the following UPC: saved as UPC87706 should be available for selection
Then I Click Delete Rows
Then I Check the Delete Rows Warning Popup: appears
Then I Check the Delete Rows Warning Popup contains the following text, Line One: You are about to delete 1 UPC's., Line Two: Do you want to proceed?
Then I Click Ok in the Delete Rows Warning Popup
Then I Check the Delete Rows Warning Popup: disappears
Then I confirm the case dropdown with the following UPC: saved as UPC87706 should not be available for selection
Then I click Continue and should not see an error message
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase87706


Scenario: [87718] Universal Product Code (UPC) Step - Collapsed View of Case UPC
Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Bubble solution
Given I generate a random UPC number and save as: UPC87718
Then I save the product information as: TestCase87718
And I call Shared Step 57514 (Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path)
And I should see the Additional Product Information Page
And I call Shared Step 85730 - Additional Product Information - Canada Only - Child (NO), GHS (NO), DSV (NO), PLP(YES), GNFR (NO), Continue
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Chlorine
And I call Shared Step 57911 (Regulatory Information 1 - CEPA only shown - Continue - Happy Path)
Then I call Shared Step  (Select Retailers Canadian Tire and enter additional requirements field - Indicate full name of product, as sold via this retailer)
Then I click continue
And I call Shared Step 87647 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC87718, container type: Plastic Container and size: 32 do not click continue
And I Select a package type from the drop down list
Then I select the case UPC dropdown arrow to collapse the UPC saved as: UPC87718
Then I confirm the case dropdown with the following UPC: saved as UPC87718 should be available for selection
Then I check if the case UPC details are collapsed for UPC: saved as UPC87718
Then I confirm a case dropdown contains the following UPC: saved as UPC87718
Then I confirm that the truck icon is displaying next to the case UPC: saved as UPC87718
Then I select the case UPC dropdown arrow to expand the UPC saved as: UPC87718
Then I confirm the Container Type field is below the UPC Number field

Then I confirm the correct UPC: saved as UPC87718 is displayed in the UPC Number textfield
Then I click continue
Given I should see the Regulatory Documents Page
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase87718






Scenario: [87818] UPC - Case UPC - Individual UPC contained in the Case Pack drop down - none available for selection
Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk
Given I generate a random UPC number and save as: UPC87818
Then I save the product information as: TestCase87818
Given I call Shared Step 26897 (Product Characteristics - Solid only available - continue)
And I should see the Additional Product Information Page
And I call Shared Step 85730 - Additional Product Information - Canada Only - Child (NO), GHS (NO), DSV (NO), PLP(YES), GNFR (NO), Continue
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Chlorine
And I call Shared Step 57911 (Regulatory Information 1 - CEPA only shown - Continue - Happy Path)
Then I call Shared Step  (Select Retailers Canadian Tire and enter additional requirements field - Indicate full name of product, as sold via this retailer)
Then I click continue
And I call Shared Step 87647 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC87818, container type: Plastic Container and size: 32 do not click continue
Then I select the case UPC dropdown arrow to collapse the UPC saved as: UPC87818
Then I confirm the case dropdown with the following UPC: saved as UPC87818 should be available for selection
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase87818





Scenario: [87821] UPC - Case UPC - Individual UPC contained in the Case Pack drop down - with UPC available for selection
Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk
Given I generate a random UPC number and save as: UPC87821
Then I save the product information as: TestCase87821
Given I call Shared Step 26897 (Product Characteristics - Solid only available - continue)
And I should see the Additional Product Information Page
And I call Shared Step 85730 - Additional Product Information - Canada Only - Child (NO), GHS (NO), DSV (NO), PLP(YES), GNFR (NO), Continue
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Chlorine
And I call Shared Step 57911 (Regulatory Information 1 - CEPA only shown - Continue - Happy Path)
Then I call Shared Step  (Select Retailers Canadian Tire and enter additional requirements field - Indicate full name of product, as sold via this retailer)
Then I click continue
And I call Shared Step 87647 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC87821, container type: Plastic Container and size: 32 do not click continue
And I Select a package type from the drop down list
Then I select the case UPC dropdown arrow to collapse the UPC saved as: UPC87821
Then I confirm a case dropdown contains the following UPC: saved as UPC87821
Then I confirm the case dropdown with the following UPC: saved as UPC87821 should be available for selection
Then I click continue
Given I should see the Regulatory Documents Page
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase87821























Scenario: [125130] Canadian Tire Available for Selection for Articles

Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Candy, Chewing Gum
Then I save the product information as: TestCase125130
And I set the Select countries the product may be sold in field to: Canada
Given I set the Product is a Retailer's Private Label or Brand option to exactly match: No
Then I click continue
Given I call Shared Step 104276 (Enter Regulatory Information - TSCA, CEPA, Not Prop 65)
Given I call Shared Step 69682 (Retailer Association - Add Private Label Information) and select the retailer: Canadian Tire and enter the name: Test
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase125130



Scenario: [undefined] my new scenario

Given I call Shared Step (Login to WERCSmart - Premium Account)
Given I collapse the Navigation Menu
# i need a step that clicks the new gotobutton and then checks that a popup entitled goto appears


Scenario: Create a new simple product (Chalk) and process from NEW to Accepted

Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
Then I save the product information as: TestCaseCreate
Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Chlorine
Given I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue) for
| Retailer  |
| Walgreens |
| Amazon    |
Given I call Shared Step 60533 (Additional Documents to Provide - Flash Point and Product Label only) : documentPathNeeded
# Document path needed in above step



#Philip - Get back to 58430

Scenario: [128085] Pharma - Prescription Pharmaceutical - Aerosol Product

Given I call Shared Step (Login to WERCSmart - Pharma Account)
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
And I set the Select the best Water Solubility description to be: Very soluble
And I set the When the product has a flammable propellant, or contains ingredients with a flash point below 60⁰C then field to: This product is classified as a D001 Hazardous Waste under RCRA (as per Section 13 or 15 of the SDS).
Then I click continue
Then I click continue
Given I fill all empty fields in the Pharma Ingredients screen
Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
	| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
	| Propane       | 100     | false               | false       |            |
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
Then I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC128085, container type: Aerosol Can and size: 1
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


Scenario: [129793] Advanced Reporting - Last 30 Days, Random Product for Reviewer

Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
Then I select the: Last 30 Days, Random Product for Reviewer report from Advanced Reporting in SHA
Then I Check that the Description Text for the Report: Last 30 Days, Random Product for Reviewer is shown as: 20 Random Products for a Reviewer in the Last 30 Days
Then I wait for the Advanced Reporting Preparing Report popup to disappear
Given I confirm that an excel file is produced called Last 30 Days, Random Product for Reviewer.xls and save as 125585
Then I confirm that the excel file saved as: 125585 contains the following columns:
| Column              |
| ID                  |
| Product Name        |
| Reviewer            |
| Last Published Date |
Then I delete the Advanced Report file saved as 125585
# Need to add a shared step for Populating the reviewer input field. Input with the automation account (might need to use amandac) and click submit



Scenario: [128920] Electronics - Dollar Tree/Family Dollar Retailers Available for Selection

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Stereo Equipment / Radio, Not Portable, No Battery Included
Then I save the product information as: TestCase128920
Given I call Shared Step 60935 Additional Product Information - US - Direct Ship - Private Label Only
Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
Given I call Shared Step 61449 Toxicity Characteristic Leaching Procedure (TCLP) - select No to all - Click Continue - Happy Path
Given I set the Contains Circuit Board option to: No
Given I set the Has a LCD or Plasma Display option to: No
Then I click continue
Given I select the following retailers in the Select Retailers popup list view:
		| Retailer                                                 |
		| Dollar Tree Stores, Inc. / Greenbrier International, Inc |
		| Family Dollar                                            |
Then I click Done on Select Retailers window
Then I confirm the following retailers are showing in the Retailer page
		| Retailer												   |
		| Dollar Tree Stores, Inc. / Greenbrier International, Inc |
		| Family Dollar                                            |
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase128920


Scenario: [128769] Battery Product - Dollar Tree/ Family Dollar Retailers Available for Selection

Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
Then The home screen should load
Given I generate a random UPC number and save as: UPC59273
Given I delete all products with UPC Number: saved as UPC59273
Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Alkaline battery
Then I save the product information as: TestCase59273
Given I call Shared Step 59927 (Primary Physical State > Solid only available – Without Water Solubility question)
Given I should see the Additional Product Information Page
Given I call Shared Step 102767 (Additional Product Information (Battery flow - not Lithium) - OSHA (No), DSV (No), PLP (No), GNFR (No))
Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
| CASNumber | ComponentName       | Percent | PublicallyDisclosed | PublicName | TradeSecret |
|           | Potassium hydroxide | 20.5    | false               |            | false       |
|           | Zinc chloride       | 9.5     | false               |            | false       |
|           | Aqua                | 70      | false               |            | false       |
Given I call Shared Step 57637 (Regulatory Information 1 - TSCA & CEPA shown, No to PROP 65 - Continue - Happy Path)
Given I select the following retailers in the Select Retailers popup list view:
		| Retailer                                                 |
		| Dollar Tree Stores, Inc. / Greenbrier International, Inc |
		| Family Dollar                                            |
Then I click Done on Select Retailers window
Then I confirm the following retailers are showing in the Retailer page
		| Retailer												   |
		| Dollar Tree Stores, Inc. / Greenbrier International, Inc |
		| Family Dollar                                            |
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase59273


Scenario: [128694] DSV Option Available for Electronic - Peripherals - RU001162

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Peripherals (Keyboard, Mouse, Trackball) without Battery
Then I save the product information as: TestCase128694
Then I confirm that the the option: United States is checked for the following section: Select countries the product may be sold in
And The following options should be displayed exclusively for section: Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns.
| Option |
| Yes    |
| No	 |
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase128694


Scenario: [128721] DSV Option Available for Appliance - Hot Water Tank (Standard, no electronic components) - RU001206

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Appliance - Hot Water Tank (Standard, no electronic components)
Then I save the product information as: TestCase128721
Then I confirm that the the option: United States is checked for the following section: Select countries the product may be sold in
And The following options should be displayed exclusively for section: Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns.
| Option |
| Yes    |
| No	 |
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase128721


Scenario: [128703] DSV Option Available for Auto Parts - Engine Parts and Components with Electrical Parts -  RU001428

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Engine Parts and Components with Electrical Parts
Then I save the product information as: TestCase128703
Then I confirm that the the option: United States is checked for the following section: Select countries the product may be sold in
And The following options should be displayed exclusively for section: Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns.
| Option |
| Yes    |
| No	 |
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase128703


Scenario: [133610] Formulation Screen:  Attestation Reset on Data Change

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561a (The Product - Enter Product Name: TRAP AND/OR BAIT STATION TEST PRODUCT and select Type of Product): Trap and/or Bait Station
Then I save the product information as: TestCase133610
Given I set the Primary Physical State option to: Solid
Given I set the Secondary Physical State option to: Solid
Given I set the When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5? option to: No
Then I click continue
And I see the following sections
| Section                               |
| Which one best describes your product |
Given I set the Which one best describes your product option to: Product is not considered a pesticide product
Then I confirm that the the option: United States is checked for the following section: Select countries the product may be sold in
Given I set the Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada) option to: No
Given I set the Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns. option to: No
Given I set the Product is a Retailer's Private Label or Brand option to: No
Given I set the Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale) option to: No
Then I click continue
Then I add the following ingredients:
| ComponentName	| Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Glutens, corn       | 100     | false               | false       |            |
Then I click continue
Then I confirm there is a popup view titled: Product Contains Ingredients Typical of a Pesticide in the Ingredients page
Then In the popup view with the following title: Product Contains Ingredients Typical of a Pesticide I confirm I see the following statement in the popup view: You've indicated the product is not a pesticide under the EPA's Federal Insecticide and Rodenticide Act (FIFRA).
Then I confirm the table in the popup view has following column data
| CAS Number | Name                   | Active or Inert |
| 66071-96-3 | Glutens, corn          | Active          |
Then In the popup view with the following title: Product Contains Ingredients Typical of a Pesticide I click the Go back button
And I should see the Ingredients Page
When In the New Product page I click tab: Product Type
And I click the page heading: The Product
And I should see the The Product Page
Given I call Shared Step 57561a (The Product - Enter Product Name: RESET PRODUCT and select Type of Product): Chalk
Then I click continue
Given I set the Primary Physical State option to: Solid
Given I set the Secondary Physical State option to: Solid
Given I set the When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5? option to: No
Given I set the Select the best Water Solubility description option to: Soluble in water
Then I click continue
And I should see the Additional Product Information Page
And I see the following sections
| Section                               |
| Which one best describes your product |
Given I set the Which one best describes your product option to: Product is not considered a pesticide product
Given I set the Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada) option to: No
Given I set the Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns. option to: No
Given I set the Product is a Retailer's Private Label or Brand option to: No
Given I set the Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale) option to: No
Then I click continue
And I should see the Ingredients Page
Then I click continue
Then I confirm there is not a popup view titled: Product Contains Ingredients Typical of a Pesticide in the Ingredients page
And I should see the Waste Classification Data Page
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase133610

Then I click close for the warning popup titled: California Cleaning Right to Know
