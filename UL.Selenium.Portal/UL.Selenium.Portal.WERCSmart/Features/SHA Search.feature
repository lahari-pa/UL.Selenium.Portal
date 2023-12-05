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

	#Created by Sai Chittampally
@TestCase:48610
	Scenario: [48610] Document Request- third column appears as 'Published'
	Given I log in with the account saved in TReVor as: ProductAccount
	Given I generate a random UPC number and save as: UPC48610
	And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
	Then I save the product information as: TestCase48610
	Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	And I call Shared Step 29181c (Ingredients - add any chemical - For Canada Only) with name: Chlorine
	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Amazon
	Given I call Shared Step 87641(Enter Universal Product Code - case information) for UPC: saved as UPC48610, container type: Paper bag and size: 2 and Quantity: 4 and Transportation option: 4A: steel box
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient |
		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | 41.3005               |
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test data
	Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given If purchase details are showing click confirm order
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase48610)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase48610 and its status is: Submitted
	Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase48610)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase48610)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase48610 and its status is: Assigned
	Given I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase48610)
	Given I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase48610)
	Given I call Shared Step 75347 (WPS Studio - PD+ - set all data and publish using rule and Doc queue - CKLT, NGHS and SBCS) for product saved as: TestCase48610
	Given I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase48610)
	Given I call Shared Step 59066 (Go to SHA Manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Accepted Status for saved as: TestCase48610)	
	When In SHA Manager I right click on the selected product:TestCase48610 with option:Document Request
	Then I confirm Published column header is displayed

	@TestCase:142905
	Scenario: [142905] SHA Manager - Review - Product Data - Verify Visibility of Product ID and Product Name
	
	Given I log in with the account saved in TReVor as: ProductAccount
	Given I generate a random UPC number and save as: UPC142905
	And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
	Then I save the product information as: TestCase142905
	Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	And I call Shared Step 29181c (Ingredients - add any chemical - For Canada Only) with name: Chlorine
	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Amazon
	Given I call Shared Step 87641(Enter Universal Product Code - case information) for UPC: saved as UPC142905, container type: Paper bag and size: 2 and Quantity: 4 and Transportation option: 4A: steel box
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient |
		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | 41.3005               |
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test data
	Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given If purchase details are showing click confirm order
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase142905)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase142905 and its status is: Submitted
	Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase142905)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase142905 and its status is: Assigned
	Given I call Shared Step 59066 (Go to SHA Manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Assigned Status for saved as: TestCase142905)
	Given In SHA Manager I select the first product saved as: TestCase142905
	When I click the following option in the bottom menu: Review
	When I Confirm that productID: TestCase142905 and name matches with the Product selected in the SHA Manager Product List

	@TestCase:193958
Scenario: [193958] CA Cleaning Right-to-Know - SB 258 Target Phase 2 - Create and Add a 3rd Party Product Containing a 3rd Party Component with PVGEN Ingredients
	Given I log in with the account saved in TReVor as: ProductAccount
	And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Mixture, Blend, Formula, Polymer or Solution from Third (3rd, 3d) Party
	Then I save the product information as: TestCase193958
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Water       | 100      | false               | false       |            |
	Given I call Shared Step 79507 (Formulation > 3rd Party - Accept formulation - Grant Tier 2 - Continue)
	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given I call Shared Step 60932 (Regulatory Information 2 - Microbeads - No)
	Then I should see the Additional Documents to Provide Page
	Given I call Shared Step 59042 (Browse for File > select > click Open - Happy Path) for document type: Please upload a PDF of the product label (full label). and file: UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf
	Given in the Additional Documents to Provide page I click Continue
	Given in the Formulation Names section page I click Continue
	Given In the Restict Use page I select Do Not Restrict
	Given in the Sustainability section page I click Continue
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Mixture, Blend, Formula, Polymer or Solution from Third (3rd, 3d) Party
	Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	And In the Purchase Summary screen I confirm the Purchase Summary header is displayed
	Then In the Thank You screen I confirm the following statement is shown: Thank you for registering your product on WERCSmart for assessment. The retailers may receive your assessment in approximately two (2) business days, if no delays in processing the assessment, and should no data issues arise.
	Then In the Thank You screen I click Home	
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Submitted Status for saved as: TestCase193958)
	Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase193958)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Assigned Status for saved as: TestCase193958)
	Then I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase193958)
	
	Given I call shared step add 3rd Party Component in Studio: TestCase193958 MIXTURE Water  
	Then I call Shared Step 209552 Power Designer Plus - APPLY RULES To Product
	Then I call Sared Step 214627 Power Designer Plus - PUBLISH Product (Applicable Only to Battery Products ): TestCase193958
	Given I call Shared Step 59066 (Go to SHA Manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Completed Status for saved as: TestCase193958)
	
	Given I log in with the account saved in TReVor as: ProductAccount
	And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bleach
	Then I save the product information as: TestCaseTwo193958
	Given I call Shared Step 57401 (Product Information - US only - No GHS, Not Direct Ship, Not PLP, Not GNFR > Continue - Happy Path)
	#Given I call Shared Step 57501 (Physical and Chemical Properties - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue - HP)	
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Water       | 100      | false               | false       |            |
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCaseTwo193958

