@Shared
@NewProduct
@ProductGrid
@RetailPartners
@NewProduct
@UPC
@Homepage
@run_Battery

Feature: Battery

@ignore
@TestCase:127575
Scenario: [127575] Battery Registration - Regulatory Documents - Needs "I don't Need" Option
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC59273
	Given I delete all products with UPC Number: saved as UPC59273
	Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Alkaline battery
	Then I save the product information as: TestCase59273
	Given I should see the Product Information Page
	Given I call Shared Step 102767 (Product Information (Battery flow - not Lithium) - OSHA (No), DSV (No), PLP (No), GNFR (No))
	Given I call Shared Step 59927 (Primary Physical State > Solid only available – Without Water Solubility question)
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| CASNumber | ComponentName       | Percent | PublicallyDisclosed | PublicName | TradeSecret |
		|           | Potassium hydroxide | 20.5    | false               |            | false       |
		|           | Zinc chloride       | 9.5     | false               |            | false       |
		|           | Aqua                | 70      | false               |            | false       |
	Given I call Shared Step 145355 Formulation > Batteries - Select Granted - Continue
	Given I call Shared Step 132375 (Waste Classification Data - TSCA & CEPA shown, No to PROP 65 - Continue - Happy Path)
	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Walgreens
	Given I call Shared Step 60826 (Enter Universal Product Code (UPC) - Battery - Confirm Quantity ) for UPC saved as: UPC59273 with container type: Metal Container size: 40.0 and quantity: 100
	Given I should see the Regulatory Documents to Provide Page
	Then I check if AIS is not uploaded
	Then I should not see radio option: I don't need a WHMIS Compliant SDS
	Then I should not see radio option: I don't need an OSHA-Compliant Safety Data Sheet (SDS) document for this product
	And I click the browse button for label: I have an Article Information Sheet (AIS), Technical Data Sheet (TDS), Battery Data Sheet (BDS) to provide. and upload PDF: UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf
	Then I should see radio option: need an OSHA-Compliant Safety Data Sheet (SDS) document for this product.
	Then I should see radio option: need a WHMIS Compliant SDS


@ignore
@TestCase:142371
Scenario: [142371] Battery - Data Consents
	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Alkaline battery
	Given I generate a random UPC number and save as: UPC142371
	Then I save the product information as: ThisProduct
	Given I call Shared Step 102767 (Product Information (Battery flow - not Lithium) - OSHA (No), DSV (No), PLP (No), GNFR (No))
	Given I call Shared Step 59927 (Primary Physical State > Solid only available – Without Water Solubility question)
	And I add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Water         | 100     | false               | false       |            |
	Then in the Ingredients page I click Continue
	And I should see the Formulation > Batteries Page
	Given I confirm the Formulation > Batteries displays the correct text
	Given I set the Consent to Tier 2.1, 2.2, 4.2 Data Uses field to: Declined
	Given I set the Consent to Tier 2.1, 2.2, 4.2 Data Uses field to: Granted
	Given I click continue
	Given I call Shared Step 132375 (Waste Classification Data - TSCA & CEPA shown, No to PROP 65 - Continue - Happy Path)
	Given I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue) for
		| Retailer  |
		| Walgreens |
	Given I call Shared Step 87658 (Enter Universal Product Code (UPC)) for UPC saved as: UPC142371 with container type: Plastic Container size: 2 and quantity: 2 do not click continue
	Given I click continue
	Given I click the browse button for label: I have an Article Information Sheet (AIS), Technical Data Sheet (TDS), Battery Data Sheet (BDS) to provide. and upload PDF: UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf
	Given I set the Batteries are considered Articles under Global Harmonized Standards option to: I need an OSHA-Compliant Safety Data Sheet (SDS) authored for this product.
	Given I set the WHMIS-compliant Safety Data Sheet, English and French-Canadian field to: I need a WHMIS-Compliant bilingual Safety Data Sheet (SDS) authored for this product.
	Given I click the browse button for label: Label in both French and English and upload PDF: UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf
	#And I check the checkbox with description: I confirm I am providing the most current Safety Data Sheet (SDS), Article Information Sheet (AIS) and/or Product Label for this registration. I understand I will need to provide a revised document should any changes be made to the registration data or documents in the future.
	Given I click continue
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	And I call Shared Step 64097 - Additional Documents -> Contact Information - Add any Name, address, phone and emergency phone - Happy Path
	Given I click continue
	Given I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Personal Protection Equipment | Appearance | Autoignition Temperature | Minimum Ignition Energy | Odor   | Odor Threshold | Partition Coefficient  | Viscosity |
		| Mask                          | Brown      | 2                        | 2                       | Banana | Not applicable | 2                      | 2         |
	Given I append the following into the comments field: test
	Given I click continue
	Given I call Shared Step 69358 (Data Acceptance - Click Summary Button)
	Given A Summary page should open in a new browser tab
	Given I confirm the Consent to Tier 2.1, 2.2, 4.2 Data shows the answer: Accept
	Given I close the browser tab with the Summary page
	Given I click the Home navigation icon
	Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: ThisProduct
