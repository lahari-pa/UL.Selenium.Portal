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
@Philip
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
@Homepage

Feature: ChooseGoodGuide.com Scenarios

Scenario:[120873] Product List - CW Column "Y" or "N"
And I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given Confirm that there is a CW column between Last Pub Date and GHS columns
	Then In SHA Manager Page I select status: Assigned
	Then Find product that has a Y in the CW column
	Then I call Shared Step 65969 (Go to Power Designer Plus - Select your product & CKLT - Continue)
	Then I click vendor section
	Then I click a section
	Then check text
	Then I call Shared Step 59066 (Go to SHA Manager)
	Then I click a section
	Then check text
	Then Find product that has a N in the CW column
	Then I call Shared Step 65969 (Go to Power Designer Plus - Select your product & CKLT - Continue)
	Then I click vendor section
	Then I click a section
	Then check text



Scenario: [123123123] Actions - 3rd Party Access Code Window

Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Then I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
And I call Shared Step 82831 (The Product - Enter Product Name and Select Type of Product: Raw material)
Then I save the product information as: TestCase90002
Then I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
| CASNumber | ComponentName   | Percent | PublicallyDisclosed | PublicName | TradeSecret |
|           | Sodium chloride | 33.33   | false               |            | false       |
|           | Copper sulfate  | 11.67   | false               |            | false       |
|           | Nitric acid     | 55      | false               |            | false       |
Then I call Shared Step 48948 (Formulation > 3rd Party - Select all)
Then I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
Then I call Shared Step 60932 (Regulatory Information 2 - Microbeads - No)
Then I click continue
Then I click continue
Then I click continue
And I call Shared Step 58610 (Confirm Restrict Use - Restrict)
Then I should see the Sustainability Page
Given in the Sustainability page I click Continue
Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: User added Comments Text 58605. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
Given I click the Home navigation icon
Given I search for the product saved as: TestCase90002
When I click Row Actions for the most recent product returned
Then I click on the Row Action: Access Code
Then Check popup date productID: TestCase90002 productType:Raw material productAccessCode: 1234
And I close the window that opened
