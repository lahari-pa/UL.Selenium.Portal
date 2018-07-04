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
