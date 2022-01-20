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
@SummaryPage
@ProductSetUp
@run_KitsFlow13
Feature: Kits - Flow 13


Background:
	Given I verify the following users exist and if not I create them using SHAUser
		| username    | FirstName | LastName   | Role         | EmailAddress                |
		| SHAQAAuto19 | QA        | Automation | QA Reviewers | qasha.kxxyxunf@mailosaur.io |

@ScenarioId:1095
Scenario: [58753] Hair Color Kit - RU000724

	Given I create a product for a Kit and force it to completed using Test Case 75335 Using SHA Account: SHAQAAuto19 and save as: 58753_KitProduct1
	Given I navigate to the landing page
	Given I create a product for a Kit and force it to completed using Test Case 75335 Using SHA Account: SHAQAAuto19 and save as: 58753_KitProduct2
	Given I navigate to the landing page
	Given I generate a random UPC number and save as: UPC58753
	And I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	#And I In the shared step below use any of the kit product types - these areCosmetic Products in a kit (RU000777)Hair Care kit (RU000723)Hair Color Kit (RU000724)Emergency Road kit (RU000718)Automotive Care Products (RU000124)Personal Care kit (RU001034)
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Hair Color Kit
	And I call Shared Step 60648 (Product Information - US, No (Direct Ship), No (PL), No (GNFR))
	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	And I call Shared Step 31427 (Create the Kit - Adding two products: product 1: 58753_KitProduct1 and product 2: 58753_KitProduct2)
	And I call Shared Step 57506 (Transportation Details 1 - Regulated for Transport(No) - Exemption(Random) - Continue - Happy Path)
	And I call Shared Step 62536 (Transportation Details 2 > I do not ship internationally > Continue - Happy Path)
	And I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: CVS
	And I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC58753, container type: Plastic Container and size: 100
	And I should see the Additional Documents to Provide Page
	And I click continue
	And I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Test Comment Kit 58753
	And I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
