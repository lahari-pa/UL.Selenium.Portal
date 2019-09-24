@LandingPage
@Login
@Homepage
@Signup
@wercsmart
@NewProduct
@ProductGrid
@DataSummarySheet
@UPC
@SHA
@wercsmart
@RetailPartners
@MyIngredients
@run_Ingredients
Feature: Ingredients
(Suite ID: 64740)

@ScenarioId:911
Scenario: [71985] Sorting Cas Number/ Chemical Name Ingredient page
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Mulch with Pesticide
	Then I save the product information as: TestCase71985
	And I set the Secondary Physical State option to: Pellets
	And I set the When mixed with an equal amount of water field to: No
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

@ScenarioId:912
Scenario: [71987] Sorting Percent on Ingredient page
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Mulch with Pesticide
	Then I save the product information as: TestCase71987
	And I set the Secondary Physical State option to: Pellets
	And I set the When mixed with an equal amount of water field to: No
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

@ScenarioId:907
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
	Then for ingredient: Butane the Trade Secret field is disabled
	Given for ingredient: Butane I set Public Disclosure checkbox to checked: false
	Then for ingredient: Butane the Trade Secret field is enabled
	Then in the Ingredients page I click Continue
	And I should see the Regulatory Information 1 Page
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase65469

@ScenarioId:908
Scenario: [65470] Ingredients - Select Trade Secret check box - Un-check Trade Secret check box - Publicly Disclosed & Public Name are active
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Bubble Solution
	Then I save the product information as: TestCase65470
	Given I call Shared Step 57514 (Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path)
	Given I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Given I call Shared Step 65447 Ingredients - Add any chemical - DO Not click Continue
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Butane        | 100     | false               | true        |            |
	Then for ingredient: Butane the Publicly Disclosed field is disabled
	Then for ingredient: Butane the Public Name field is disabled
	Given for ingredient: Butane I set Trade Secret checkbox to checked: false
	Then for ingredient: Butane the Publicly Disclosed field is enabled
	Then for ingredient: Butane the Public Name field is enabled
	Then for ingredient: Butane I confirm the Public Name selectbox contains names for selection
	Then in the Ingredients page I click Continue
	And I should see the Regulatory Information 1 Page
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase65470

#CLF - this is basically the same as 65470
@ScenarioId:906
Scenario: [65459] Ingredients - Select Trade Secret check box - Publicly Disclosed & Public Name are not active
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Bubble Solution
	Then I save the product information as: TestCase65459
	Given I call Shared Step 57514 (Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path)
	Given I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Given I call Shared Step 65447 Ingredients - Add any chemical - DO Not click Continue
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Butane        | 100     | false               | true        |            |
	Then for ingredient: Butane the Publicly Disclosed field is disabled
	Then for ingredient: Butane the Public Name field is disabled
	Then in the Ingredients page I click Continue
	And I should see the Regulatory Information 1 Page
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase65459

@ScenarioId:905
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
	Then for ingredient: Butane the Trade Secret field is disabled
	Then in the Ingredients page I click Continue
	Then for ingredient: Butane I should see an error below the public name column which reads: Please select Public Name since you agreed on Publicly Disclosed
	Then for ingredient: Butane I select Public Name: Butane
	Then in the Ingredients page I click Continue
	And I should see the Regulatory Information 1 Page
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase65451

@ScenarioId:904
Scenario: [65448] Ingredients - Publicly Disclosed, Trade secret and Public Name are not required fields
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Bubble Solution
	Then I save the product information as: TestCase65448
	Given I call Shared Step 57514 (Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path)
	Given I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Given I call Shared Step 65447 Ingredients - Add any chemical - DO Not click Continue
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Butane        | 100     | false               | true        |            |
	Given I confirm the following column titles and inputs are displayed in the ingredients table
		| Column              | Input    |
		| Percent             | textbox  |
		| Publicly Disclosed? | checkbox |
		| Trade Secret?       | checkbox |
		| Public Name         | select   |
	Then in the Ingredients page I click Continue
	And I should see the Regulatory Information 1 Page
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase65448

@ScenarioId:903
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
		| WPS1434087    | 50      | false               | true        |            |
		| Butane        | 50      | false               | true        |            |
	Then in the Ingredients page I click Continue
	Then a Warning popup dialog should appear with the message: Your product registration contains a 3rd-Party Formula that needs to be updated for it to be included in chemical-policy or sustainability assessments conducted by retailers or in GoodGuide ratings. We have sent a notification to your 3rd-Party Formulator requesting that the ingredient's Data Use Tier consent, and the public disclosure status of its ingredients, be updated. Please continue with this product registration, but note that the chemical-policy or sustainability assessment results may change if, and when, your 3rd-Party Formulator authorizes its ingredient to be included in such programs.
	And I should see the Regulatory Information 1 Page
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase63321

@ScenarioId:910
Scenario: [71291] Product Ingredients contains a third party component that requires updating for public disclosure
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Mulch with Pesticide
	Then I save the product information as: TestCase71291
	And I set the Secondary Physical State option to: Pellets
	And I set the When mixed with an equal amount of water field to: No
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

@ScenarioId:913
Scenario: [74142] Pop up that Informs the regulations the components are associated
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Mascara - Washable
	Then I save the product information as: TestCase74142
	Given I call Shared Step 57501 (Product Characteristics - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue - HP)
	Given I call Shared Step 57401 (Additional Product Information - US only - No GHS, Not Direct Ship, Not PLP, Not GNFR > Continue - Happy Path)
	Given I add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Chlorine      | 100     | false               | false       |            |
	Given I click the Regulated button for ingredient: Chlorine in the Ingredients table
	Then the 'Regulatory List' window opens
	Given I confirm that a list of regulations associated with the component is displayed
	Given I close the Regulatory List window
	Given I navigate to the home page
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase74142

@ScenarioId:909
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
	Given I call Shared Step 57401 (Additional Product Information - US only - No GHS, Not Direct Ship, Not PLP, Not GNFR > Continue - Happy Path)
	Given I click continue
	Then I should see an error message: Formulation must total or exceed 100%.
	Given I add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Water         | 80      | false               | false       |            |
	Given I click continue
	Then I should see an error message: Formulation must total or exceed 100%.
	Given I change the percent field to 100
	Given in the Ingredients page I click Continue
	Then I should see the Regulatory Information 1 Page
	Given In the New Product page I click tab: Product Characteristics
	And I click the page heading: Ingredients
	Then I should not see an error message: Formulation must total or exceed 100%.
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase69796

@ScenarioId:915
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
	And In the Ingredients page I confirm the Publicly Disclosed Transparency score is flagged as a danger
	And I call Shared Step 79436 (Ingredients - Add FRAGRANCE component, Publicly Disclosed = Yes,  Select Public Name) and save ingredient as: shared79436
		| CASNumber | ComponentName                                                                  | Percentage |
		| FRAGRANCE | Fragrance - Awapuhi - Skin sens 1, Repro 2, Aquatic acute 2, Aquatic chronic 2 | 100        |
	Then In the Ingredients page I confirm the Publicly Disclosed Transparency Score has numerator: 0 and denominator: 1
	And In the Ingredients page I confirm the Publicly Disclosed Transparency score is flagged as a danger
	Then I click the Publicly Disclosed checkbox for ingredient saved as: shared79436
	And In the Ingredients page I confirm the Publicly Disclosed Transparency Score has numerator: 0 and denominator: 1
	Given I navigate to the home page
	And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase80728

@ScenarioId:914
Scenario: [80720] Ingredients - Transparency Ratio - FLAVOR component - included in Denominator, not included in Numerator
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk
	Then I save the product information as: TestCase80720
	Then I should see the Product Characteristics Page
	Given I call Shared Step 26897 (Product Characteristics - Solid only available - continue)
	Given I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Then I should see the Ingredients Page
	And In the Ingredients page I confirm the Publicly Disclosed Transparency Score has numerator: 0 and denominator: 0
	And In the Ingredients page I confirm the Publicly Disclosed Transparency score is flagged as a danger
	Given I call Shared Step 79431 (Ingredients - Add FLAVOR component, Publicly Disclosed = Yes, Select Public Name) and save ingredients as: shared79431
		| CASNumber | ComponentName | Percentage |
		| FLAVOR    | FLAVOR        | 100        |
	Then In the Ingredients page I confirm the Publicly Disclosed Transparency Score has numerator: 0 and denominator: 1
	And In the Ingredients page I confirm the Publicly Disclosed Transparency score is flagged as a danger
	Given I click the Publicly Disclosed checkbox for ingredient saved as: shared79431
	Then In the Ingredients page I confirm the Publicly Disclosed Transparency Score has numerator: 0 and denominator: 1
	Given I navigate to the home page
	And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase80720

# Assigned to Paulina Mata
# Created by Paulina Mata
# Test case can be found at the following paths:
# NetProjects10\WercsSmart Portal\WERCSmart\Product Registration\Ingredients
@ScenarioId:919
Scenario: [87301] Ingredients - Selecting a Public Label Name Automatically Initiates Publicly Disclosed Indicator
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
	And I call Shared Step 26897 (Product Characteristics - Solid only available - continue)
	And I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Given I call Shared Step 65447 Ingredients - Add any chemical - DO Not click Continue
		| ComponentName    | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Sodium hydroxide | 33      | false               | false       |            |
	And I select the first Public Name dropdown option for ingredient: Sodium hydroxide
	And I confirm the Publicly Disclosed checkbox is: checked for ingredient: Sodium hydroxide
	Given I call Shared Step 65447 Ingredients - Add any chemical - DO Not click Continue
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Water         | 33      | false               | false       |            |
	And I click the Trade Secret checkbox for ingredient: Water
	Then for ingredient: Water the Public Name field is disabled
	Then for ingredient: Water the Publicly Disclosed field is disabled
	Given I call Shared Step 65447 Ingredients - Add any chemical - DO Not click Continue
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Boric acid    | 34      | false               | false       |            |
	And I select the first Public Name dropdown option for ingredient: Boric acid
	Then for ingredient: Boric acid the Trade Secret field is disabled
	And for ingredient: Boric acid I select Public Name: Choose...
	And I click the Trade Secret checkbox for ingredient: Boric acid
	Then for ingredient: Boric acid the Public Name field is disabled
	Then for ingredient: Boric acid the Publicly Disclosed field is disabled
	And I navigate to the home page
	And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase87301

# Assigned to Paulina Mata
# Created by Paulina Mata
# Test case can be found at the following paths:
# NetProjects10\WercsSmart Portal\WERCSmart\Product Registration\Ingredients
@jamesnew
@ScenarioId:918
Scenario: [84528] Ingredients - Allow to delete multiple ingredients in formulation
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Soap (Bar, Liquid) for Body
	And I call Shared Step 57501 (Product Characteristics - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue - HP)
	And I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	#And I Start typing in the component box
	#And I Add as many random ingredients as possible
	Given I call Shared Step 65447 Ingredients - Add any chemical - DO Not click Continue
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Boric acid    | 10      | false               | false       |            |
	Given I call Shared Step 65447 Ingredients - Add any chemical - DO Not click Continue
		| ComponentName    | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Sodium hydroxide | 10      | false               | false       |            |
	Given I call Shared Step 65447 Ingredients - Add any chemical - DO Not click Continue
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Dye X         | 10      | false               | false       |            |
	Given I call Shared Step 65447 Ingredients - Add any chemical - DO Not click Continue
		| ComponentName   | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Sodium chloride | 10      | false               | false       |            |
	Given I call Shared Step 65447 Ingredients - Add any chemical - DO Not click Continue
		| ComponentName     | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Potassium sulfate | 10      | false               | false       |            |
	Given I call Shared Step 65447 Ingredients - Add any chemical - DO Not click Continue
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Water         | 50      | false               | false       |            |
	And I click 'Select all' in the Ingredients table
	And I confirm that all ingredients in the table are selected
	And I confirm the 'Delete' button is available in the Ingredients table
	And I deselect the following ingredients:
		| Name            |
		| Water           |
		| Sodium chloride |
		| Boric acid      |
	And I confirm the following ingredients are unselected:
		| Name            |
		| Water           |
		| Sodium chloride |
		| Boric acid      |
	And I confirm the 'Select all' checkbox in the Ingredients table is unchecked
	And I click 'Select all' in the Ingredients table
	And I confirm that all ingredients in the table are selected
	And I click the 'Delete' button in the Ingredients table
	And I confirm the 'Remove selected components' popup is displayed with message: Are you sure you want to remove all selected components?
	And in the modal dialog I click the "YES" button
	And I confirm there are a total of: 0 ingredients in the table
	And I navigate to the home page
	And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase84528

# Assigned to Paulina Mata
# Created by Paulina Mata
# Test case can be found at the following paths:
# NetProjects10\WercsSmart Portal\WERCSmart\Product Registration\Ingredients
@ScenarioId:917
Scenario: [81711] Ingredients - Informational Message for Fragrance and Flavor Ingredients
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	# Temporarily using this product type instead of 'Soap (Bar, Liquid)' because of bug #88838
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Medicated Lotion or Soap
	And I call Shared Step 57501 (Product Characteristics - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue - HP)
	And I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	And I enter text: FRAGRANCE in the component search box
	And I select the component search result with CAS matching text: FRAGRANCE and save ingredient as: FragranceIngredient81711
	And I confirm that a 'Sustainability Hint' button is displayed under ingredient saved as: FragranceIngredient81711 with hover over text: You have included a generic ingredient in your product. Be aware that this may impact chemical policy or sustainability assessments conducted by retailers or your GoodGuide ratings, if you participate in any of these programs. Such assessments are more accurate if they are derived from full formulations that list the specific components within a generic ingredient. It is an emerging transparency best-practice to avoid the use of generic ingredients and either (i) add these directly to your product's ingredients, or (ii) request that the third-party supplier providing your generic ingredient register it as a 3rd-Party Formula in WERCSmart and add the 3rd-Party ingredient to your registration. Using the 3rd-Party Formula registration process allows your third-party formulator to control whether its ingredient can be included in assessments of your product and to determine which ingredients, if any, can be publicly disclosed.
	And I enter text: FRAGRANCE in the component search box
	And I select the component search result with CAS matching text: RR and save ingredient as: FragranceRRIngredient81711
	And I confirm that a 'Sustainability Hint' button is displayed under ingredient saved as: FragranceRRIngredient81711 with hover over text: You have included a generic ingredient in your product. Be aware that this may impact chemical policy or sustainability assessments conducted by retailers or your GoodGuide ratings, if you participate in any of these programs. Such assessments are more accurate if they are derived from full formulations that list the specific components within a generic ingredient. It is an emerging transparency best-practice to avoid the use of generic ingredients and either (i) add these directly to your product's ingredients, or (ii) request that the third-party supplier providing your generic ingredient register it as a 3rd-Party Formula in WERCSmart and add the 3rd-Party ingredient to your registration. Using the 3rd-Party Formula registration process allows your third-party formulator to control whether its ingredient can be included in assessments of your product and to determine which ingredients, if any, can be publicly disclosed.
	And I enter text: Flavor in the component search box
	And I select the component search result with CAS matching text: FLAVOR and save ingredient as: FlavorIngredient81711
	And I confirm that a 'Sustainability Hint' button is displayed under ingredient saved as: FlavorIngredient81711 with hover over text: You have included a generic ingredient in your product. Be aware that this may impact chemical policy or sustainability assessments conducted by retailers or your GoodGuide ratings, if you participate in any of these programs. Such assessments are more accurate if they are derived from full formulations that list the specific components within a generic ingredient. It is an emerging transparency best-practice to avoid the use of generic ingredients and either (i) add these directly to your product's ingredients, or (ii) request that the third-party supplier providing your generic ingredient register it as a 3rd-Party Formula in WERCSmart and add the 3rd-Party ingredient to your registration. Using the 3rd-Party Formula registration process allows your third-party formulator to control whether its ingredient can be included in assessments of your product and to determine which ingredients, if any, can be publicly disclosed.
	And I enter text: Flavor in the component search box
	And I select the component search result with CAS matching text: RR and save ingredient as: FlavorRRIngredient81711
	And I confirm that a 'Sustainability Hint' button is displayed under ingredient saved as: FlavorRRIngredient81711 with hover over text: You have included a generic ingredient in your product. Be aware that this may impact chemical policy or sustainability assessments conducted by retailers or your GoodGuide ratings, if you participate in any of these programs. Such assessments are more accurate if they are derived from full formulations that list the specific components within a generic ingredient. It is an emerging transparency best-practice to avoid the use of generic ingredients and either (i) add these directly to your product's ingredients, or (ii) request that the third-party supplier providing your generic ingredient register it as a 3rd-Party Formula in WERCSmart and add the 3rd-Party ingredient to your registration. Using the 3rd-Party Formula registration process allows your third-party formulator to control whether its ingredient can be included in assessments of your product and to determine which ingredients, if any, can be publicly disclosed.
	And I enter text: N/A in the component search box
	And I select the component search result with CAS matching text: N/A and save ingredient as: NAIngredient81711
	And I confirm that the 'Sustainability Hint' button is not displayed under ingredient saved as: NAIngredient81711
	And I click on the Sustainability Hint button under ingredient saved as: FragranceIngredient81711
	And I confirm a 'Sustainability Hint' popover element is open under ingredient saved as: FragranceIngredient81711
	And I move the mouse pointer by an offset of 100 in x and 100 in y
	And I confirm a 'Sustainability Hint' popover element is open under ingredient saved as: FragranceIngredient81711
	And I navigate to the home page
	And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase81711

@ScenarioId:916
Scenario: [80800] Ingredients - Transparency Ratio - Regular component
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
	Then I save the product information as: TestCase80800
	And I call Shared Step 26897 (Product Characteristics - Solid only available - continue)
	And I call Shared Step 85284 - Additional Product Information - US & Canada, Child (No), OSHA (No), DSV (No), PLP (YES), GNFR (No), Continue
	And In the Ingredients page I confirm the Publicly Disclosed Transparency Score has numerator: 0 and denominator: 0
	And In the Ingredients page I confirm the Publicly Disclosed Transparency score is flagged as a danger
	And call Shared Step 80090 - Ingredients - Add non-generic chemical, set to publicly Disclosed, select public name and save ingredient as: TestCase80800Component
		| CASNumber | ComponentName | Percentage | Publicly Disclosed | Public Name |
		| 108-95-2  | Phenol        | 57         | Yes                | Phenol      |
	And In the Ingredients page I confirm the Publicly Disclosed Transparency Score has numerator: 1 and denominator: 1
	And In the Ingredients page I confirm the Publicly Disclosed Transparency score is flagged as a success
	And I edit the first component to show No for Publicly disclosed
	And In the Ingredients page I confirm the Publicly Disclosed Transparency Score has numerator: 0 and denominator: 1
	And In the Ingredients page I confirm the Publicly Disclosed Transparency score is flagged as a danger
	And I navigate to the home page
	And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase80800

@ScenarioId:902
Scenario: [109230] Ingredients - Proper ingredients and percentages are showing in Summary and Ingredients Table
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I generate a random UPC number and save as: UPC109230
	And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
	Then I save the product information as: TestCase109230
	And I call Shared Step 26897 (Product Characteristics - Solid only available - continue)
	Given I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Given I call Shared Step 65447 Ingredients - Add any chemical - DO Not click Continue
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName        |
		| Water         | 100     | true                | false       | Aqua (Water, Eau) |
	Given I call Shared Step 65447 Ingredients - Add any chemical - DO Not click Continue
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Chlorine      | 100     | false               | true        |            |
	Given I call Shared Step 65447 Ingredients - Add any chemical - DO Not click Continue
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Formaldehyde  | 100     | false               | false       |            |
	Given I call Shared Step 65447 Ingredients - Add any chemical - DO Not click Continue
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName             |
		| Sodium        | 100     | true                | false       | Undisclosed Ingredient |
	And I click continue
	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue) for
		| Retailer  |
		| Walgreens |
	Given I call Shared Step 87647 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC109230, container type: Paper bag and size: 2 do not click continue
	And I click continue
	And I call Shared Step 78080 (Regulatory Documents to Provide - Upload OSHA SDS)
	And in the Additional Documents to Provide page I click Continue
	And in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: test
	Given I click the Summary button in the Data Acceptance window
	Then I switch to the Data Summary page
	And In the Data Summary page, I confirm that the Ingredients table matches the following:
		| CAS Number/ChemicalName | Percent | Publicly Disclosed? | Trade Secret? | INCI Name              |
		| Water                   | 100     | Yes                 | No            | Aqua (Water, Eau)      |
		| Chlorine                | 100     | No                  | Yes           | Trade Secret           |
		| Formaldehyde            | 100     | No                  | No            |                        |
		| Sodium                  | 100     | Yes                 | No            | Undisclosed Ingredient |
	And I close the window that opened
	Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	And I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Submitted Status for saved as: TestCase109230)
	Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase109230)
	And I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase109230)
	And I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase109230)
	Given I call Shared Step 75347 (WPS Studio - PD+ - set all data and publish using rule and Doc queue - CKLT, NGHS and SBCS) for product saved as: TestCase109230
	And I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase109230)
	Given I call Shared Step 59066 (Go to SHA Manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase109230)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase109230 and its status is: Accepted or Completed
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase109230)
	Given I call Shared Step 51664 (SHA - Accepted Product - set Retailers to Completed for saved as: TestCase109230) for
		| Retailer  |
		| Walgreens |
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase109230)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase109230 and its status is: Completed
	And I call Shared Step 43587 - SHA Manager > Completed Product - Add Recert reason 20 for product saved as: TestCase109230
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase109230)
	And In the SHA manager grid I see the WPS ID I have saved as product: TestCase109230 and its font is red indicating a recertification
	Given I navigate to the landing page
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	And I filter for the product saved as: TestCase109230
	And I click Row Actions for the first product returned
	And I click on the Row Action: View
	Then I switch to the Data Summary page
	And In the Data Summary page, I confirm that the Ingredients table matches the following:
		| CAS Number/ChemicalName | Percent | Publicly Disclosed? | Trade Secret? | INCI Name              |
		| Water                   | 100     | Yes                 | No            | Aqua (Water, Eau)      |
		| Chlorine                | 100     | No                  | Yes           | Trade Secret           |
		| Formaldehyde            | 100     | No                  | No            |                        |
		| Sodium                  | 100     | Yes                 | No            | Undisclosed Ingredient |
	And I close the window that opened
	And I filter for the product saved as: TestCase109230
	And I click Row Actions for the first product returned
	And I click on the Row Action: Update Required
	Given In the New Product page I click tab: Product Characteristics
	And I click the page heading: Ingredients
	And I confirm that the ingredients table looks as follows:
		| CAS Number/ChemicalName | Percent | Publicly Disclosed? | Trade Secret? | INCI Name              |
		| Water                   | 100     | Yes                 | No            | Aqua (Water, Eau)      |
		| Chlorine                | 100     | No                  | Yes           | Choose...              |
		| Formaldehyde            | 100     | No                  | No            | Choose...              |
		| Sodium                  | 100     | Yes                 | No            | Undisclosed Ingredient |
	And I navigate to the home page

Scenario: [110368] Ingredients- Filtered Ingredient Appears on Top of Filter Option

And I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
And I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk
Then I save the product information as: TestCase110368
Given I call Shared Step 26897 (Product Characteristics - Solid only available - continue)
Given I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
Then I enter: Formaldehyde as my ingredient in the Ingredients page, and check that the top option on the filter matches my ingredient		
And I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase110368


