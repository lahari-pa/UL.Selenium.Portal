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
@PaymentMethods
@SubEnrollment
@WERCSmart_Signup
@MyAccount
@PackagingTypes
@Brands
@MyIngredients
@UPC
@SHA
@ProductSetUp
@ForwardProductRegistration
@run_Timeout
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:ProductInformation
@PhysicalAndChemicalProp
@Ingredients
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:NewProduct
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:TheProduct
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:Retailer

Feature: Timeout

@Timeout1
Scenario: [Timeout Test] Mass Upload File Popup, Inactivity Popup can be interacted with
	Given I generate: 5 random UPC numbers and save them starting with: RandomUPC
	#Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I log in with the account saved in TReVor as: ProductAccount
	# ====== Given I call Shared Step 57408 (Create a New Registration via Register New Product icon) ====== #
	Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration '
	Given in the New Product page I click Continue
	Then I should see the The Product Page
	And I set 'Product Name' to:  Chalk
	And I set 'Type of Product' to: Chalk
	Then I save the product information as: TestCase82536
	And I click continue
	#Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Given I should see the Product Information Page
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)' to: No
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue

	#And I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I should see the Physical and Chemical Properties Page
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' should be showing the option: Solid
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' confirm option is selected: Solid
	Then In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
	Then In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Then In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
	Then in the Physical and Chemical Properties page I click Continue

	#And I call Shared Step 29181 (Ingredients - add any chemical) with name: Water
	Given I should see the Ingredients Page
	Then In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	| component name | Water       | 100     |                     |               |             |
	Then in the Ingredients page I click Continue

	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	#And I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Amazon
	Given I should see the Retailer Page
	Then In the Retailer Section, click 'Add Retailers' button
	Then In the Select Retailers window, select retailer: Amazon
	Then In the Select Retailers window, click 'Done' button
	Then in the Retailer page I click Continue

	And I click continue
	And I click Sample File link and verify the Upload UPC form and save it as test82536 with data:
		| UPC           | Name   | Quantity | Size | Internal SKU | US: Part Number | US: Item Number | GP: Part Number | SP: Part Number | TG: DPCI    | HD: OMSID | CT: Item Number   | Green Good Housekeeping | Green Seal | EPA Safer Choice | Cradle to Cradle | UL Ecologo | EWG Verified | Green Tick | Madesafe | NSF Sustainability Certified |
		| 823973000000  | Saco 1 | 1        | 100  | KS955AR      | 11AB45          | 1001            | 1111            | A0001           | 111-22-0001 | 100000001 | 123-1234,123-1230 | Yes                     |            |                  |                  |            | Yes          |            |          | Yes                          |
		| 0037600724210 | Saco 2 | 2        | 101  |              | 12AB56          | 1002            | 2222            | B0002           | 111-22-0002 | 100000002 | 123-1234,123-1231 |                         | Yes        |                  |                  |            |              | Yes        |          |                              |
		| 978959000000  | Saco 3 | 3        | 102  |              | 12AC67          | 1003            | 3333            | C0003           | 111-22-0003 | 100000003 | 123-1234,123-1232 |                         |            | Yes              |                  |            |              |            |          |                              |
		| 688267000000  | Saco 4 | 4        | 103  | KS956AG      | 12AD89          | 1004            | 4444            | D0004           | 111-22-0004 | 100000004 | 123-1234,123-1233 |                         |            |                  | Yes              |            |              |            | Yes      |                              |
		| 854911000000  | Saco 5 | 5        | 104  | KS957AT      | 12AF00          | 1005            | 5555            | E0005           | 111-22-0005 | 100000005 | 123-1234,123-1234 |                         |            |                  |                  | Yes        |              |            |          |                              |
	And I edit the testdoc.xlsx, and save its filepath as: Bulktest82536 and verify it contains the UPC data in the table saved as: UPCTable82536, (Base Data Only: true)
		| UPC          | Name   | Quantity | Size | Internal SKU | US: Part Number | US: Item Number | GP: Part Number | SP: Part Number | TG: DPCI    | HD: OMSID | CT: Item Number   |
		| 823973000000 | Saco 1 | 1        | 11   |              | 11AB45          | 1001            | 1111            | A0001           | 111-22-0001 | 100000001 | 123-1234,123-1230 |
		| 71617198008  | Saco 2 | 2        | 22   |              | 12AB56          | 1002            | 2222            | B0002           | 111-22-0002 | 100000002 | 123-1234,123-1231 |
		| 978959000000 | Saco 3 | 3        | 33   |              | 12AC67          | 1003            | 3333            | C0003           | 111-22-0003 | 100000003 | 123-1234,123-1232 |
		| 688267000000 | Saco 4 | 4        | 44   |              | 12AD89          | 1004            | 4444            | D0004           | 111-22-0004 | 100000004 | 123-1234,123-1233 |
		| 854911000000 | Saco 5 | 5        | 55   |              | 12AF00          | 1005            | 5555            | E0005           | 111-22-0005 | 100000005 | 123-1234,123-1234 |
	Then I click the 'Upload File' button and upload the file saved as: Bulktest82536
	Then I confirm that Add Multiple UPC popup appears and the values are the same as the UPC Upload document saved in the Table called: UPCTable82536
	Then In the Add Multiple dialog box I select all UPCs
	Given I confirm the Inactivity popup is displayed after waiting 15 minutes accurate to the nearest 2 minutes
	Then Click Yes on the inactivity popup
	Then I confirm the Inactivity pop is closed


@Timeout2
@ScenarioId:1438
Scenario: [Timeout Test] Mass Upload File Popup, TimeoutFeature Works Correctly
	Given I generate: 5 random UPC numbers and save them starting with: RandomUPC
	#Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I log in with the account saved in TReVor as: ProductAccount
	#Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I click the Add Product icon in the Navigation Pane
	Given In the New Product Section, set the radio option in section: 'Select the type of product to create': to: 'Create Formulated Registration '
	Given in the New Product page I click Continue
	Then I should see the The Product Page
	And I set 'Product Name' to:  Chalk
	And I set 'Type of Product' to: Chalk
	Then I save the product information as: TestCase82536
	And I click continue
	#Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Given I should see the Product Information Page
	Then In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in (select either or both)' is checked for: United States
	Then In the Product Information Section, set the option in section: 'Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)' to: No
	Then In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
	Then In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
	Then In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
	Then in the Product Information page I click Continue

	#And I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	Given I should see the Physical and Chemical Properties Page
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' should be showing the option: Solid
	Then In the Physical and Chemical Properties Section, the section: 'Primary Physical State' confirm option is selected: Solid
	Then In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Solid
	Then In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
	Then In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
	Then in the Physical and Chemical Properties page I click Continue

	#And I call Shared Step 29181 (Ingredients - add any chemical) with name: Water
	Given I should see the Ingredients Page
	Then In the Ingredients section, add the following ingredients:
	| SearchType     | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
	| component name | Water       | 100     |                     |               |             |
	Then in the Ingredients page I click Continue

	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	#And I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Amazon
	Given I should see the Retailer Page
	Then In the Retailer Section, click 'Add Retailers' button
	Then In the Select Retailers window, select retailer: Amazon
	Then In the Select Retailers window, click 'Done' button
	Then in the Retailer page I click Continue

	And I click continue
	And I click Sample File link and verify the Upload UPC form and save it as test82536 with data:
		| UPC           | Name   | Quantity | Size | Internal SKU | US: Part Number | US: Item Number | GP: Part Number | SP: Part Number | TG: DPCI    | HD: OMSID | CT: Item Number   | Green Good Housekeeping | Green Seal | EPA Safer Choice | Cradle to Cradle | UL Ecologo | EWG Verified | Green Tick | Madesafe | NSF Sustainability Certified |
		| 823973000000  | Saco 1 | 1        | 100  | KS955AR      | 11AB45          | 1001            | 1111            | A0001           | 111-22-0001 | 100000001 | 123-1234,123-1230 | Yes                     |            |                  |                  |            | Yes          |            |          | Yes                          |
		| 0037600724210 | Saco 2 | 2        | 101  |              | 12AB56          | 1002            | 2222            | B0002           | 111-22-0002 | 100000002 | 123-1234,123-1231 |                         | Yes        |                  |                  |            |              | Yes        |          |                              |
		| 978959000000  | Saco 3 | 3        | 102  |              | 12AC67          | 1003            | 3333            | C0003           | 111-22-0003 | 100000003 | 123-1234,123-1232 |                         |            | Yes              |                  |            |              |            |          |                              |
		| 688267000000  | Saco 4 | 4        | 103  | KS956AG      | 12AD89          | 1004            | 4444            | D0004           | 111-22-0004 | 100000004 | 123-1234,123-1233 |                         |            |                  | Yes              |            |              |            | Yes      |                              |
		| 854911000000  | Saco 5 | 5        | 104  | KS957AT      | 12AF00          | 1005            | 5555            | E0005           | 111-22-0005 | 100000005 | 123-1234,123-1234 |                         |            |                  |                  | Yes        |              |            |          |                              |
	And I edit the testdoc.xlsx, and save its filepath as: Bulktest82536 and verify it contains the UPC data in the table saved as: UPCTable82536, (Base Data Only: true)
		| UPC          | Name   | Quantity | Size | Internal SKU | US: Part Number | US: Item Number | GP: Part Number | SP: Part Number | TG: DPCI    | HD: OMSID | CT: Item Number   |
		| 823973000000 | Saco 1 | 1        | 11   |              | 11AB45          | 1001            | 1111            | A0001           | 111-22-0001 | 100000001 | 123-1234,123-1230 |
		| 71617198008  | Saco 2 | 2        | 22   |              | 12AB56          | 1002            | 2222            | B0002           | 111-22-0002 | 100000002 | 123-1234,123-1231 |
		| 978959000000 | Saco 3 | 3        | 33   |              | 12AC67          | 1003            | 3333            | C0003           | 111-22-0003 | 100000003 | 123-1234,123-1232 |
		| 688267000000 | Saco 4 | 4        | 44   |              | 12AD89          | 1004            | 4444            | D0004           | 111-22-0004 | 100000004 | 123-1234,123-1233 |
		| 854911000000 | Saco 5 | 5        | 55   |              | 12AF00          | 1005            | 5555            | E0005           | 111-22-0005 | 100000005 | 123-1234,123-1234 |
	Then I click the 'Upload File' button and upload the file saved as: Bulktest82536
	Then I confirm that Add Multiple UPC popup appears and the values are the same as the UPC Upload document saved in the Table called: UPCTable82536
	Then In the Add Multiple dialog box I select all UPCs
	Given I confirm the Inactivity popup is displayed after waiting 15 minutes accurate to the nearest 2 minutes
	Then I Look for the Landing Page for: 16 minutes
#Then I wait for 960 seconds
#And the landing page should load

	
