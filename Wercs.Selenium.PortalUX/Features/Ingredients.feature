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

#CLF - this is basically the same as 65470
Scenario: [65459] Ingredients - Select Trade Secret check box - Publicly Disclosed & Public Name are not active
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Bubble Solution
Then I save the product information as: TestCase65459
Given I call Shared Step 57514 (Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path)
Given I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
  Given I call Shared Step 65447 Ingredients - Add any chemical - DO Not click Continue
| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Butane        | 100     | false                | true       |            |
Then for ingredient: Butane the Publicly Disclosed checkbox is disabled
Then for ingredient: Butane the Public Name selectbox is disabled
Then in the Ingredients page I click Continue
And I should see the Regulatory Information 1 Page
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase65459

Scenario: [65451] Ingredients - Select Publicly Disclosed check box - Public Name is required, trade secret is not required
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Bubble Solution
Then I save the product information as: TestCase65451
Given I call Shared Step 57514 (Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path)
Given I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
Given I call Shared Step 65447 Ingredients - Add any chemical - DO Not click Continue
| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Butane        | 100     | true                | false       |            |
Then for ingredient: Butane the Trade Secret checkbox is disabled
Then in the Ingredients page I click Continue
Then for ingredient: Butane I should see an error below the public name column which reads: Please select Public Name since you agreed on Publicly Disclosed
Then for ingredient: Butane I select Public Name: n-Butane
Then in the Ingredients page I click Continue
And I should see the Regulatory Information 1 Page
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase65451

Scenario: [65448] Ingredients - Publicly Disclosed, Trade secret and Public Name are not required fields
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Bubble Solution
Then I save the product information as: TestCase65448
Given I call Shared Step 57514 (Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path)
Given I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
Given I call Shared Step 65447 Ingredients - Add any chemical - DO Not click Continue
| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Butane        | 100     | false                | true       |            |
Given In the ingredients table the following column titles and inputs are showing
| Column                   | Input    |
| Percent                  | textbox  |
| Publicly Disclosed?      | checkbox |
| Trade Secret?            | checkbox |
| Public Name              | select   |
Then in the Ingredients page I click Continue
And I should see the Regulatory Information 1 Page
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase65448

Scenario: [63321] Product Ingredients contains a third party component that requires updating for public disclosure
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Bubble Solution
Then I save the product information as: TestCase63321
Given I call Shared Step 57514 (Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path)
Given I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
And I should see the Ingredients Page
Given I call Shared Step 65447 Ingredients - Add any chemical - DO Not click Continue
| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| WPS1437542    | 50      | false               | true        |            |
| Butane        | 50      | false               | true        |            |
Then in the Ingredients page I click Continue
Then a Warning popup dialog should appear with the message: Please be aware that your product contains a 3rd Party component that requires updating. We have sent a notification to your 3rd Party component supplier requesting that it update its component information relating to public disclosure of ingredients.
And I should see the Regulatory Information 1 Page
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase63321

Scenario: [71291] Product Ingredients contains a third party component that requires updating for public disclosure
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Mulch with Pesticide
Then I save the product information as: TestCase71291
And I set the Secondary Physical State option to: Pellets
And I set the When mixed with an equal amount of water field to: No
And I set the Select the best Water Solubility description field to: Appreciable
Then in the Product Characteristics page I click Continue
Given I call Shared Step 57865 (Additional Product Information - Pesticide shown, US only, select No for everything else - Happy Path)
Given I add the following ingredients:
| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Wood dust     | 75.0    | false               | false       |            |
| RED 4         | 20.0    | false               | false       |            |
| Clothianidin  | 5.0     | false               | false       |            |
Then in the Ingredients page I click Continue
And I should see the Neonicotinoid Warning Page
Then I should see an alert with title: Danger & Warning subtitle: This product contains a neonicotinoid pesticide which may adversely affect pollinating bee populations. Text: Presence of this ingredient may limit the sale of this product through a Retailer. Please refer to the EPA website for more information.
Then on the Neonicotinoid Warning Page I should see a link with text: EPA website which links to page: https://www.epa.gov/pollinator-protection/epa-actions-protect-pollinators
Then in the Neonicotinoid Warning page I click Continue
And I should see the Regulatory Information 1 Page
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase71291

Scenario: [74142] Pop up that Informs the regulations the components are associated

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)

Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Mascara - Washable

Then I save the product information as: TestCase74142

Given I call Shared Step 57501 (Product Characteristics - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue - HP)

Given I call Shared 57401 (Additional Product Information - US only - No GHS, Not Direct Ship, Not PLP, Not GNFR > Continue - Happy Path)

Given I add the following ingredients:
| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Chlorine      | 100     | false               | false       |            |

Given I click the Regulated button for ingredient: Chlorine in the Ingredients section

Then the 'Regulatory List' window opens

Given I confirm that a list of regulations associated with the component is displayed

Given I close the Regulatory List window

Given I navigate to the home page

Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase74142

Scenario: [69796] Aerosol Warning Message on Ingredient page

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)

Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Hair Styling Product - Aerosol and Pump Spray

Then I save the product information as: TestCase69796

Then I should see the Product Characteristics Page

Given I set the Primary Physical State option to: Aerosol

Given I set the Secondary Physical State option to: Bag-on-valve (BOV)

Given I set the pH option to: 5

Given I set the Select the best Water Solubility option to: Appreciable

Given I select the first option in section: When the product has a flammable propellant, or contains ingredients with a flash point below 60⁰C then

Given I click continue

Given I call Shared 57401 (Additional Product Information - US only - No GHS, Not Direct Ship, Not PLP, Not GNFR > Continue - Happy Path)

Given I click continue

Then I should see an error message: ALERT! The ingredient table does not include a compressed gas (Bag-On-Valve) or a propellant. Please update your ingredients to include the propellant before proceeding.

Given I add the following ingredients:
| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Water         | 80      | false               | false       |            |

Given I click continue

Then I should see an error message: ALERT! The ingredient table does not include a compressed gas (Bag-On-Valve) or a propellant. Please update your ingredients to include the propellant before proceeding.

Given I add the following ingredients:
| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Pentane       | 19      | false               | false       |            |

Given I click continue

Then I should see an error message: Formulation must total or exceed 100%.

Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase69796

Scenario: [80728] Ingredients - Transparency Ratio - FRAGRANCE component - included in Denominator, not included in Numerator

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)

Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk

Then I save the product information as: TestCase80728

Then I should see the Product Characteristics Page

Given I call Shared Step 26897 (Product Characteristics - Solid only available - continue)

Given I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)

Then I should see the Ingredients Page

And In the Ingredients page I confirm the Publicly Disclosed Transparency Score has numerator: 0 and denominator: 0

And In the Ingredients page I confirm the Publicly Disclosed Transparency score is flagged as a warning

Given I call Shared 79436 (Ingredients - Add FRAGRANCE component, Publicly Disclosed = Yes,  Select Public Name) and save ingredient as: shared79436

Then In the Ingredients page I confirm the Publicly Disclosed Transparency Score has numerator: 0 and denominator: 1

And In the Ingredients page I confirm the Publicly Disclosed Transparency score is flagged as a warning

Then In the Ingredients Page I select the Publicly Disclosed checkbox for ingredient saved as: shared79436

And In the Ingredients page I confirm the Publicly Disclosed Transparency Score has numerator: 0 and denominator: 1

Given I navigate to the home page

And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase80728

Scenario: [80720] Ingredients - Transparency Ratio - FLAVOR component - included in Denominator, not included in Numerator

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account

Then The home screen should load

Given I call Shared 57753 (Create a New Registration via Register New Product (expanded menu))

Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk

Then I save the product information as: TestCase80720

Then I should see the Product Characteristics Page

Given I call Shared Step 26897 (Product Characteristics - Solid only available - continue)

Given I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)

Then I should see the Ingredients Page

And In the Ingredients page I confirm the Publicly Disclosed Transparency Score has numerator: 0 and denominator: 0

And In the Ingredients page I confirm the Publicly Disclosed Transparency score is flagged as a warning

Given I call Shared 79431 (Ingredients - Add FLAVOR component, Publicly Disclosed = Yes, Select Public Name) and save ingredients as: shared79431
| CASNumber | ComponentName |
| FLAVOR    | FLAVOR        |

Then In the Ingredients page I confirm the Publicly Disclosed Transparency Score has numerator: 0 and denominator: 1

And In the Ingredients page I confirm the Publicly Disclosed Transparency score is flagged as a warning

Given In the Ingredients Page I select the Publicly Disclosed checkbox for ingredient saved as: shared79431

Then In the Ingredients page I confirm the Publicly Disclosed Transparency Score has numerator: 0 and denominator: 1

Given I navigate to the home page

And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase80720
