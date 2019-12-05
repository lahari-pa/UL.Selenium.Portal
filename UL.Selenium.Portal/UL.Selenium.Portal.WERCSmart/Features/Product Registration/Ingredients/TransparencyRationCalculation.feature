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
@ProductSetUp
@run_TransparencyRationCalculation
Feature: Transparency Ration Calculation

@ScenarioId:6047
Scenario: [80854] Ingredients - Transparency Ratio - Formulated product with 3rd party product included in formulation
	#For this test case you will need to have a specific 3rd party formulation product to add to your formulated products ingredients list.
	#Use test case 80821 to create this third party product and get it to completed status.
	#You will need to know the WPSxxxxxxx ID associated to the 3rd party product
	Given I call Shared Step 80821 - Create a 3rd party product - with Tier 2 approval Specific components for Transparency ratio testing and save as: TestCase80854Component
	#Given I create a product with name: 80854 and take to completed using Test Case 80821 and save as: TestCase80854Component
	And I navigate to the landing page
	And I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	#Use the shared step below to confirm the Transparency ratio for the third party product you are working with
	And I call Shared Step 80780 - My Products - Filter for product - View - Note transparency ratio - close summary for product saved as: TestCase80854Component
	And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	#In the shared step below use Chalk as your product type
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
	Then I save the product information as: TestCase80854
	And I call Shared Step 26897 (Product Characteristics - Solid only available - continue)
	And I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	#The Ingredients step is shown - Confirm the Transparency ratio (the numbers below the Publicly Disclosed column) shows in red background and shows 0/0
	#And In the Ingredients page I confirm the Publicly Disclosed Transparency Score has numerator: 0 and denominator: 0
	And I verify the Transparency Score displays 0.00%
	And In the Ingredients page I confirm the Publicly Disclosed Transparency score is flagged as a danger
	And In the Access Code Validation popup I enter WPS value for product TestCase80854Component
	And I call Shared Step 80822 - Ingredients - Add non-generic - specific component - set publicly disclosed and add public name and save ingredient as: Ing808212
		| CASNumber                          | Percentage | Publicly Disclosed | Public Name            |
		| WPS SavedAs TestCase80854Component | 15         | Yes                | Undisclosed Ingredient |
	#And In the Ingredients page I confirm the Publicly Disclosed Transparency Score has numerator: 0.375 and denominator: 1
	And I verify the Transparency Score displays 37.50%
	And In the Ingredients page I confirm the Publicly Disclosed Transparency score is flagged as a warning
	#Use the shared step below to add 84696-51-5 Extract, Spearmint to your formulationwith Publicly Disclosed set to Yes
	And call Shared Step 80090 - Ingredients - Add non-generic chemical, set to publicly Disclosed, select public name and save ingredient as: TestCase80854Component2
		| CASNumber  | ComponentName      | Percentage | Publicly Disclosed | Public Name        |
		| 84696-51-5 | Extract, spearmint | 4          | Yes                | Extract, spearmint |
	#And In the Ingredients page I confirm the Publicly Disclosed Transparency Score has numerator: 1.375 and denominator: 2
	And I verify the Transparency Score displays 68.75%
	And In the Ingredients page I confirm the Publicly Disclosed Transparency score is flagged as a info
	#Use the shared step below to add FLAVOR 072 Springmint to your formulation with Publicly Disclosed set to No
	And I call Shared Step 80824 - Ingredients - Add FLAVOR component, not Publicly Disclosed and save as TestCase80854Component3
		| CASNumber | ComponentName  | Percentage | Publicly Disclosed | Public Name            |
		| FLAVOR    | 072 Springmint | 4          | No                 | Undisclosed Ingredient |
	#And In the Ingredients page I confirm the Publicly Disclosed Transparency Score has numerator: 1.375 and denominator: 3
	And I verify the Transparency Score displays 45.83%
	And In the Ingredients page I confirm the Publicly Disclosed Transparency score is flagged as a warning
	And call Shared Step 80090 - Ingredients - Add non-generic chemical, set to publicly Disclosed, select public name and save ingredient as: TestCase80854Component4
		| CASNumber | ComponentName | Percentage | Publicly Disclosed | Public Name |
		| 7732-18-5 | Water         | 4          | Yes                | Water       |
	#And In the Ingredients page I confirm the Publicly Disclosed Transparency Score has numerator: 2.375 and denominator: 4
	And I verify the Transparency Score displays 59.38%
	And In the Ingredients page I confirm the Publicly Disclosed Transparency score is flagged as a info
	#Use the shared step below to add 144-55-8 Sodium Bicarbonate to your ingredients list with publicly disclosed set to No
	And I call Shared Step 80824 - Ingredients - Add FLAVOR component, not Publicly Disclosed and save as TestCase80854Component5
		| CASNumber | ComponentName      | Percentage | Publicly Disclosed | Public Name |
		| 144-55-8  | Sodium Bicarbonate | 4          | No                 | Baking Soda |
	#And In the Ingredients page I confirm the Publicly Disclosed Transparency Score has numerator: 2.375 and denominator: 5
	And I verify the Transparency Score displays 47.50%
	And In the Ingredients page I confirm the Publicly Disclosed Transparency score is flagged as a warning
	And call Shared Step 80090 - Ingredients - Add non-generic chemical, set to publicly Disclosed, select public name and save ingredient as: TestCase80854Component6
		| CASNumber | ComponentName     | Percentage | Publicly Disclosed | Public Name       |
		| NA751     | Menthol flavoring | 4          | Yes                | Menthol flavoring |
	And In the Ingredients page I confirm the Publicly Disclosed Transparency Score has numerator: 3.375 and denominator: 6
	And I verify the Transparency Score displays 56.25%
	And In the Ingredients page I confirm the Publicly Disclosed Transparency score is flagged as a info
	#I Confirm the Transparency Ratio is shown as 3.375/7 in orange backgroundThis is because the Fragrance component you added is a generic so it does not add 1 to the numerator but it does add 1 to the denominator
	And call Shared Step 80090 - Ingredients - Add non-generic chemical, set to publicly Disclosed, select public name and save ingredient as: TestCase80854Component7
		| CASNumber  | ComponentName        | Percentage | Publicly Disclosed | Public Name          |
		| RR-38254-7 | FRAGRANCE - CUCUMBER | 4          | Yes                | FRAGRANCE - CUCUMBER |
	#And In the Ingredients page I confirm the Publicly Disclosed Transparency Score has numerator: 3.375 and denominator: 7
	And I verify the Transparency Score displays 48.21%
	And In the Ingredients page I confirm the Publicly Disclosed Transparency score is flagged as a warning
	#I Confirm the Transparency Ratio is shown as 3.375/8 in orange backgroundThis is because the component is not publicly disclosed so it does not add 1 to the numerator but it does add 1 to the denominator
	And I call Shared Step 80824 - Ingredients - Add FLAVOR component, not Publicly Disclosed and save as TestCase80854Component8
		| CASNumber | ComponentName  | Percentage | Publicly Disclosed | Public Name    |
		| 111-42-2  | Diethanolamine | 4          | No                 | Diethanolamine |
	#And In the Ingredients page I confirm the Publicly Disclosed Transparency Score has numerator: 3.375 and denominator: 8
	And I verify the Transparency Score displays 42.19%
	And In the Ingredients page I confirm the Publicly Disclosed Transparency score is flagged as a warning
	And call Shared Step 80090 - Ingredients - Add non-generic chemical, set to publicly Disclosed, select public name and save ingredient as: TestCase80854Component9
		| CASNumber  | ComponentName | Percentage | Publicly Disclosed | Public Name |
		| 26675-46-7 | Isoflurane    | 57         | Yes                | Isoflurane  |
	#And In the Ingredients page I confirm the Publicly Disclosed Transparency Score has numerator: 4.375 and denominator: 9
	And I verify the Transparency Score displays 48.61%
	And In the Ingredients page I confirm the Publicly Disclosed Transparency score is flagged as a warning
	Then in the Ingredients page I click Continue
	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	And I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	And I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	And I should see the Additional Documents to Provide Page
	And I call Shared Step 59042 (Browse for File > select > click Open - Happy Path) for document type: IFRA Certificate (Perfumery Products) and file: C:\Dependencies\WERCSmart\testdoc.pdf
	And I call Shared Step 59042 (Browse for File > select > click Open - Happy Path) for document type: GRAS Certificate (Flavor Products) and file: C:\Dependencies\WERCSmart\testdoc.pdf
	Then in the Additional documents page I click Continue
	Then in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
		| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
	And I call Shared Step 57883 (Comments - Happy Path) and enter the comment: test
	And I should see the Data Acceptance Page
	And I click the Summary button in the Data Acceptance window
	And I switch to the Data Summary page
	And I take a screenshot of the ingredients
	And Confirm that transparency ratio is 4.375 / 9
	And I close the Data Summary tab
#And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase80854
