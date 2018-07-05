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
@run_Ingredients

Feature: Ingredients
(Suite ID: 64740)

Scenario: [71985] Sorting Cas Number/ Chemical Name Ingredient page
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Mulch with Pesticide
Then I save the product information as: TestCase71985
And I set the Secondary Physical State option to: Pellets
And I set the When mixed with an equal amount of water field to: No
And I set the Select the best Water Solubility description field to: Appreciable
Then in the Product Characteristics page I click Continue
Given I call Shared Step 57865 (Additional Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
Given I add the following ingredients:
| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Wood dust     | 50.0    | false               | false       |            |
| RED 4         | 23.0    | false               | false       |            |
| Clothianidin  | 27.0    | false               | false       |            |
When In the ingredients table I click Chemical Name to order
Then In the ingredients table the ingredients should be in the following order
| Name         |
| Clothianidin |
| RED 4        |
| Wood dust    |
When In the ingredients table I click Chemical Name to order
Then In the ingredients table the ingredients should be in the following order
| Name         |
| Wood dust    |
| RED 4        |
| Clothianidin |
When In the ingredients table I click CAS Number to order
Then In the ingredients table the ingredients should be in the following order
| Name         |
| RED 4        |
| Clothianidin |
| Wood dust    |
When In the ingredients table I click CAS Number to order
Then In the ingredients table the ingredients should be in the following order
| Name         |
| Wood dust    |
| Clothianidin |
| RED 4        |

Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase71985

Scenario: [71987] Sorting Percent on Ingredient page
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Mulch with Pesticide
Then I save the product information as: TestCase71987
And I set the Secondary Physical State option to: Pellets
And I set the When mixed with an equal amount of water field to: No
And I set the Select the best Water Solubility description field to: Appreciable
Then in the Product Characteristics page I click Continue
Given I call Shared Step 57865 (Additional Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
Given I add the following ingredients:
| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Wood dust     | 70.0    | false               | false       |            |
| RED 4         | 5.0     | false               | false       |            |
| Clothianidin  | 25.0    | false               | false       |            |
When In the ingredients table I click Percent to order
Then In the ingredients table the ingredients should be in the following order
| Name         |
| RED 4        |
| Clothianidin |
| Wood dust    |
When In the ingredients table I click Percent to order
Then In the ingredients table the ingredients should be in the following order
| Name         |
| Wood dust    |
| Clothianidin |
| RED 4        |
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase71987

Scenario: [65469] Ingredients - Select Publicly Disclosed check box - un-check Publicly Disclosed check box- Trade secret is active
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Bubble Solution
Then I save the product information as: TestCase65469
Given I call Shared Step 57514 (Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path)
Given I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
  Given I call Shared Step 65447 Ingredients - Add any chemical - DO Not click Continue
| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Butane        | 100     | true                | false       |            |
Then for ingredient: Butane the Trade Secret checkbox is disabled
Given for ingredient: Butane I set Public Disclosure checkbox to checked: false
Then for ingredient: Butane the Trade Secret checkbox is enabled
Then in the Ingredients page I click Continue
And I should see the Regulatory Information 1 Page
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase65469

Scenario: [65470] Ingredients - Select Trade Secret check box - Un-check Trade Secret check box - Publicly Disclosed & Public Name are active
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Bubble Solution
Then I save the product information as: TestCase65470
Given I call Shared Step 57514 (Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path)
Given I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
  Given I call Shared Step 65447 Ingredients - Add any chemical - DO Not click Continue
| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Butane        | 100     | false                | true       |            |
Then for ingredient: Butane the Publicly Disclosed checkbox is disabled
Then for ingredient: Butane the Public Name selectbox is disabled
Given for ingredient: Butane I set Trade Secret checkbox to checked: false
Then for ingredient: Butane the Publicly Disclosed checkbox is enabled
Then for ingredient: Butane the Public Name selectbox is enabled
Then for ingredient: Butane the Public Name selectbox shows names
Then in the Ingredients page I click Continue
And I should see the Regulatory Information 1 Page
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase65470
