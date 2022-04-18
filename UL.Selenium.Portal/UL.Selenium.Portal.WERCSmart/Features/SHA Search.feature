@Shared
@SHA
@LandingPage
@Login
@Homepage
@Signup
@RetailPartners
@wercsmart
@DocumentAcceptance
@run_SHASearch
@Shared
@wercsmart
@Login
@Homepage
@ProductGrid
@NewProduct
@MyAccount
@LandingPage@SHA
@SummaryPage
@PaymentMethods
@ProductSetUp
@UPC
@DeleteActiveProducts

Feature: SHA Search
	Limited to functions which only search SHA Manager

@SHASearch
# QA Test needs UPC 5000171007186, Sprint 2 needs UPC 0046442718103. To access, use TestVariables.GetVariableSavedAs("Archived UPC")
@TestCase:110399
Scenario: [110399] SHA Manager - Search UPC for Archived Registration - Verify Popup
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Then SHA Search for Archived UPC. This uses environment variable for know archived product
	Given I verify the popup message displays with the title "Archived Product / Archived UPC"
	Then I close the Archived Product popup
	Then SHA Search for Archived UPC. This uses environment variable for know archived product


@ignore
@TestCase:160937
Scenario: [160937] SHA Manager - Search - Product Search - SEARCH PATTERN - Primary UPC Field Test
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account	
	Given I generate a random UPC number and save as: UPC160937A
	Given I generate a random UPC number and save as: UPC160937B
	And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
	Then I save the product information as: TestCase160937
	Given I call Shared Step 63860 (Product Information - US, No(child), No(OSHA), No(DSV), Yes(PLP), No(GNFR))
	And I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	And I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	And I call Shared Step 85990 - Retailers - PLP - Select one or more retailer and add PL information - Continue
		| Retailer  |
		| Walgreens |		
	Given I call Shared Step 87647 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC160937A, container type: Paper bag and size: 2 do not click continue
	Given I call Shared Step 87647 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC160937B, container type: Paper bag and size: 2 do not click continue
	Given I click continue
	And I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
		| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
	And I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Test comment
	And I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given If purchase details are showing click confirm order

	And I navigate to the home page
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Then I Get the first 5 Digits of the UPC Number Saved as: UPC160937A, and save them as: UPCFirst5Digits
	Then I Get the middle 5 Digits of the UPC Number Saved as: UPC160937A, and save them as: UPCMiddle5Digits
	Then I Get the last 5 Digits of the UPC Number Saved as: UPC160937A, and save them as: UPCLast5Digits
	Given I call Shared Step (SHA - Search for ...Contains... UPC savedAsUPCMiddle5Digits in Submitted Status and Check the product saved as: TestCase160937 is found)
	Given I call Shared Step (SHA - Search for Starts With... UPC savedAsUPCFirst5Digits in Submitted Status and Check the product saved as: TestCase160937 is found)
	Given I call Shared Step (SHA - Search for ...Ends With UPC savedAsUPCLast5Digits in Submitted Status and Check the product saved as: TestCase160937 is found)
	Given I call Shared Step (SHA - Search for Exact UPC savedAsUPC160937A in Submitted Status and Check the product saved as: TestCase160937 is found)
	Then I call Shared Step 134404 (SHA > Select Product > UPC Assessment Details) for product saved as: TestCase160937
	And I confirm the Product UPC window has opened
	Given In the UPC Assessment Details Screen, I Confirm that I see the Product ID saved as: TestCase160937
	Then In the SHA UPC list I should see UPC: saved as UPC160937A in Any Row of the UPC table
	And I close the current window and switch to the main window in Studio
	Then In The SHA Products Grid, I open the product search popup, click cancel and confirm the product search popup closes
	Then I Get the first 5 Digits of the UPC Number Saved as: UPC160937B, and save them as: UPCFirst5DigitsB
	Then I Get the middle 5 Digits of the UPC Number Saved as: UPC160937B, and save them as: UPCMiddle5DigitsB
	Then I Get the last 5 Digits of the UPC Number Saved as: UPC160937B, and save them as: UPCLast5DigitsB
		Given I call Shared Step (SHA - Search for ...Contains... UPC savedAsUPCMiddle5DigitsB in Submitted Status and Check the product saved as: TestCase160937 is found)
	Given I call Shared Step (SHA - Search for Starts With... UPC savedAsUPCFirst5DigitsB in Submitted Status and Check the product saved as: TestCase160937 is found)
	Given I call Shared Step (SHA - Search for ...Ends With UPC savedAsUPCLast5DigitsB in Submitted Status and Check the product saved as: TestCase160937 is found)
	Given I call Shared Step (SHA - Search for Exact UPC savedAsUPC160937B in Submitted Status and Check the product saved as: TestCase160937 is found)
	Then I call Shared Step 134404 (SHA > Select Product > UPC Assessment Details) for product saved as: TestCase160937
	And I confirm the Product UPC window has opened
	Given In the UPC Assessment Details Screen, I Confirm that I see the Product ID saved as: TestCase160937
	Then In the SHA UPC list I should see UPC: saved as UPC160937B in Any Row of the UPC table
	And I close the current window and switch to the main window in Studio
	Then In The SHA Products Grid, I open the product search popup, click cancel and confirm the product search popup closes

@ignore
@TestCase:160940
	Scenario: [160940] SHA Manager - Search - Product Search - SEARCH PATTERN - CASE UPC Field Test

	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I generate a random UPC number and save as: UPC160940
	And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
	Then I save the product information as: TestCase160940
	Given I call Shared Step 63860 (Product Information - US, No(child), No(OSHA), No(DSV), Yes(PLP), No(GNFR))
	And I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	And I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	And I call Shared Step 85990 - Retailers - PLP - Select one or more retailer and add PL information - Continue
		| Retailer  |
		| Walgreens |
	Given I call Shared Step 87641(Enter Universal Product Code - case information) for UPC: saved as UPC160940, container type: Paper bag and size: 2 and Quantity: 4 and Transportation option: random
	And I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
		| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
	And I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: Test comment
	And I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given If purchase details are showing click confirm order
	And I navigate to the home page
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Then I Get the first 5 Digits of the UPC Number Saved as: UPC160940, and save them as: UPCFirst5Digits
	Then I Get the middle 5 Digits of the UPC Number Saved as: UPC160940, and save them as: UPCMiddle5Digits
	Then I Get the last 5 Digits of the UPC Number Saved as: UPC160940, and save them as: UPCLast5Digits
	Given I call Shared Step (SHA - Search by ...Contains... Case Pack UPC savedAsUPCMiddle5Digits in Submitted Status and Check the product saved as: TestCase160940 is found)
	Given I call Shared Step (SHA - Search by Starts With... Case Pack UPC savedAsUPCFirst5Digits in Submitted Status and Check the product saved as: TestCase160940 is found)
	Given I call Shared Step (SHA - Search by ...Ends With Case Pack UPC savedAsUPCLast5Digits in Submitted Status and Check the product saved as: TestCase160940 is found)
	Given I call Shared Step (SHA - Search by Exact Case Pack UPC savedAsUPC160940 in Submitted Status and Check the product saved as: TestCase160940 is found)
	Then I call Shared Step 134404 (SHA > Select Product > UPC Assessment Details) for product saved as: TestCase160940
	And I confirm the Product UPC window has opened
	Given In the UPC Assessment Details Screen, I Confirm that I see the Product ID saved as: TestCase160940
	Then In the SHA UPC list I should see the case pack asterisk for the UPC: saved as UPC160940
	And I close the current window and switch to the main window in Studio
	Then In The SHA Products Grid, I open the product search popup, click cancel and confirm the product search popup closes
