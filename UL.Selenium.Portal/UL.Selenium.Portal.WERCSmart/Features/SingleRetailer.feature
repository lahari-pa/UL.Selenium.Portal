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

Feature: SingleRetailer

	# Created by Saikiran Chittampally
@TestCase:182705
Scenario: [182705] Single Retailer Checkbox - Not Visible in Battery Flow 
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Alkaline Battery
Then I save the product information as: TestCase182705
Given I call Shared Step 102767 (Product Information (Battery flow - not Lithium) - OSHA (No), DSV (No), PLP (No), GNFR (No))
Given I call Shared Step 59927 (Primary Physical State > Solid only available – Without Water Solubility question)
Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Water      | 100     | false               | false       |            |
Given I call Shared Step 145355 Formulation > Batteries - Select Granted - Continue
Given I call Shared Step 104276 (Enter Regulatory Information - TSCA, CEPA, Not Prop 65)
Then I should see the Retailer Page
Given I confirm the checkbox Registration is for a Single Retail Recipient (No Retailer +1) and will use Single-Retail Subscription program is not present for stand alone batteries in Retailer page 
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase182705
