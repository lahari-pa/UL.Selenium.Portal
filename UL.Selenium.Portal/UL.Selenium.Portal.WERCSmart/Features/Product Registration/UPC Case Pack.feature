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
@ForwardProductRegistration
@ProductSetUp
@ViewUpcs
@run_UPCCasePack
Feature: UPC Case Pack

@ScenarioId:1455
Scenario: [87640] UPC - Case Pack Only Present in product
	#Given I login into the WERCSmart Portal - Administrator Role
	Given I log in with the account saved in TReVor as: ProductAccount
	Given I generate a random UPC number and save as: UPC87640
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
	Then I save the product information as: TestCase87640
	Given I call Shared Step 26897 (Product Characteristics - Solid only available - continue)
	Given I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue) for
		| Retailer |
		| Amazon   |
	Given I call Shared Step 87641(Enter Universal Product Code - case information) for UPC: saved as UPC87640, container type: Paper bag and size: 2 and Quantity: 4 and Transportation option: random
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient |
		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | 41.3005               |
	Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: test data
	Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given If purchase details are showing click confirm order
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase87640)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase87640 and its status is: Submitted
	Given I call Shared Step 75309 (SHA > Select Product > UPC List) for product saved as: TestCase87640
	And In the list of UPCs I should see case pack indicatior for UPC: saved as UPC87640

@ScenarioId:1454
Scenario: [87643] UPC - Case Pack & regular UPC present in product
	#Given I login into the WERCSmart Portal - Administrator Role
	Given I log in with the account saved in TReVor as: ProductAccount
	Given I generate a random UPC number and save as: UPC87643
	Given I generate a random UPC number and save as: UPC876431
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
	Then I save the product information as: TestCase87643
	Given I call Shared Step 26897 (Product Characteristics - Solid only available - continue)
	Given I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue) for
		| Retailer |
		| Amazon   |
	Given I call Shared Step 87647 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC876431, container type: Paper bag and size: 2 do not click continue
	Given I call Shared Step 87641(Enter Universal Product Code - case information) for UPC: saved as UPC87643, container type: Paper bag and size: 2 and Quantity: 4 and Transportation option: 4A: steel box
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient |
		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | 41.3005               |
	Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: test data
	Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given If purchase details are showing click confirm order
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase87643)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase87643 and its status is: Submitted
	Given I call Shared Step 75309 (SHA > Select Product > UPC List) for product saved as: TestCase87643
	And In the list of UPCs I should see case pack indicatior for UPC: saved as UPC87643
	And In the list of UPCs I should not see case pack indicatior for UPC: saved as UPC876431

@ScenarioId:1456
Scenario: [87650] Battery Product - limit of 5 UPCs for Lithium ion battery- Case UPC counts towards the 5 limit
	#Given I login into the WERCSmart Portal - Administrator Role
	Given I log in with the account saved in TReVor as: ProductAccount
	Given I generate a random UPC number and save as: UPC87650
	Given I generate a random UPC number and save as: UPC876501
	Given I generate a random UPC number and save as: UPC876502
	Given I generate a random UPC number and save as: UPC876503
	Given I generate a random UPC number and save as: UPC876504
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): LITHIUM ION BATTERIES
	Then I save the product information as: TestCase87650
	Given I call Shared Step 59927 (Primary Physical State > Solid only available – Without Water Solubility question)
	Given I call Shared Step 65493 (Additional Product Information - US only - Battery is packaged for Retail Sales - No to everything else - Continue)
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName      | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Lithium hydroxide  | 6.7     | false               | false       |            |
		| Graphite           | 33.2    | false               | false       |            |
		| Ethylene carbonate | 60.1    | false               | false       |            |
	Given I call Shared Step 57637 (Regulatory Information 1 - TSCA & CEPA shown, No to PROP 65 - Continue - Happy Path)
	Given I call Shared Step 54799 (Lithium Battery Characteristics - any data - Happy path)
	Given I call Shared Step 60096 (Lithium Battery Transportation)
	Then I should see the following retailers:
		| Retailers                  |
		| No Retailer/No UPC Product |
	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Costco
	Then I should see lithium battery message: Lithium battery registrations have a maximum of five (5) UPCs per registration. If you have additional UPCs, please create a new registration.
	Given I call Shared Step 87658 (Enter Universal Product Code (UPC)) for UPC saved as: UPC87650 with container type: Plastic Container size: 25 and quantity: 50 do not click continue
	Given I call Shared Step 87658 (Enter Universal Product Code (UPC)) for UPC saved as: UPC876501 with container type: Plastic Container size: 25 and quantity: 50 do not click continue
	Given I call Shared Step 87658 (Enter Universal Product Code (UPC)) for UPC saved as: UPC876502 with container type: Plastic Container size: 25 and quantity: 50 do not click continue
	Given I call Shared Step 87658 (Enter Universal Product Code (UPC)) for UPC saved as: UPC876503 with container type: Plastic Container size: 25 and quantity: 50 do not click continue
	Given I call Shared Step(Enter Universal Product Code - case information) for UPC: saved as UPC876504, container type: Paper bag and size: 2 and Quantity: 4 and Transportation option: 4A: steel box do not click continue
	Then I should see maximum upc limit message: This product registration has reached the maximum limit of active UPC entries. You may remove UPC entries that are no longer valid, if possible. Also, be sure the UPC entries are for the specific registration being made. If you need an exception to the UPC limit for this registration, please contact support and advise the total quantity of UPCs needed to accommodate this registration.
	And I should not see the following UPC buttons:
		| Option       |
		| Add UPC      |
		| Add Case UPC |
	Given in the Universal Product Code (UPC) page I click Continue
	Given I call Shared Step 104662 - Regulatory Documents to Provide - Lithium Batteries - US and Canada - Request authoring for both
	Given I call Shared Step 69422 (Additional Documents to Provide - Upload Product Photo)
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	And I call Shared Step 64097 - Additional Documents -> Contact Information - Add any Name, address, phone and emergency phone - Happy Path
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient |
		| Gloves                        | 650                      | 0.400                   | 1.005     | Black      | Acidic | No data available | 7.388                 |
	Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: test data
	Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given If purchase details are showing click confirm order
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase87650)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase87650 and its status is: Submitted
	Given I call Shared Step 75309 (SHA > Select Product > UPC List) for product saved as: TestCase87650
	And In the list of UPCs I should see case pack indicatior for UPC: saved as UPC876504
	And In the list of UPCs I should not see case pack indicatior for UPC: saved as UPC87650
	And In the list of UPCs I should not see case pack indicatior for UPC: saved as UPC876501
	And In the list of UPCs I should not see case pack indicatior for UPC: saved as UPC876502
	And In the list of UPCs I should not see case pack indicatior for UPC: saved as UPC876503

@ScenarioId:1457
Scenario: [87676] UPC - Case Pack can be removed from new product
	#Given I login into the WERCSmart Portal - Administrator Role
	Given I log in with the account saved in TReVor as: ProductAccount
	Given I generate a random UPC number and save as: UPC87676
	Given I generate a random UPC number and save as: UPC876761
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
	Then I save the product information as: TestCase87676
	Given I call Shared Step 26897 (Product Characteristics - Solid only available - continue)
	Given I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue) for
		| Retailer |
		| Amazon   |
	Given I call Shared Step 87641(Enter Universal Product Code - case information) for UPC: saved as UPC87676, container type: Paper bag and size: 2 and Quantity: 4 and Transportation option: 4A: steel box
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient |
		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | 41.3005               |
	Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: test data
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase87676)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase87676 and its status is: New
	Given I call Shared Step 75309 (SHA > Select Product > UPC List) for product saved as: TestCase87676
	And In the list of UPCs I should see case pack indicatior for UPC: saved as UPC87676
	And I close the window that opened
	Given I navigate to the landing page
	Given I log in with the account saved in TReVor as: ProductAccount
	And I search for the product saved as: TestCase87676
	And I click Row Actions for the first product returned
	Then I click on the Row Action: Edit
	Given In the New Product page I click tab: Recipient and UPC Details
	Given I click the page heading: Universal Product Code (UPC)
	And I delete UPC: saved as UPC87676
	Then In the list of UPCs I should not see UPC: saved as UPC87676
	Given I enter information for Enter Universal Product Code (UPC) - UPC-Container Type - Size Only for UPC: for UPC: saved as UPC876761, container type: Plastic Container and size: 25 - do not click continue
	And I click the 'Add Case UPC' button
	#And I switch to tab: UL Wercs Studio
	#Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase87676)
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase87676)
	Given I call Shared Step 75309 (SHA > Select Product > UPC List) for product saved as: TestCase87676
	Then In the SHA list of UPCs I should not see UPC: saved as UPC87676
	And In the list of UPCs I should not see case pack indicatior for UPC: saved as UPC876761
	Given I navigate to the landing page
	Given I log in with the account saved in TReVor as: ProductAccount
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase87676

@ScenarioId:1458
Scenario: [87685] UPC - Case Pack & Regular UPC present in Product - Process to Complete
	#Given I login into the WERCSmart Portal - Administrator Role
	Given I log in with the account saved in TReVor as: ProductAccount
	Given I generate a random UPC number and save as: UPC87685
	Given I generate a random UPC number and save as: UPC876851
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
	Then I save the product information as: TestCase87685
	Given I call Shared Step 26897 (Product Characteristics - Solid only available - continue)
	Given I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue) for
		| Retailer |
		| Amazon   |
	Given I call Shared Step 87647 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC87685, container type: Paper bag and size: 2 do not click continue
	Given I call Shared Step 87641(Enter Universal Product Code - case information) for UPC: saved as UPC876851, container type: Paper bag and size: 2 and Quantity: 4 and Transportation option: 4A: steel box
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
		| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
	Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: User added Comments Text 57863. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
	Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given If purchase details are showing click confirm order
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase87685)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase87685 and its status is: Submitted
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase87685)
	Given I call Shared Step 75309 (SHA > Select Product > UPC List) for product saved as: TestCase87685
	And In the list of UPCs I should not see case pack indicatior for UPC: saved as UPC87685
	And In the list of UPCs I should see case pack indicatior for UPC: saved as UPC876851
	And I close the window saved as: SHAManagerProductUPC
	Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase87685)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase87685)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase87685 and its status is: Assigned
	Given I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase87685)
	Given I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase87685)
	Given I call Shared Step 75347 (WPS Studio - PD+ - set all data and publish using rule and Doc queue - CKLT, NGHS and SBCS) for product saved as: TestCase87685
	Given I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase87685)
	Given I call Shared Step 59066 (Go to SHA Manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase87685)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase87685 and its status is: Accepted
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Accepted Status for saved as: TestCase87685)
	Given I call Shared Step 51664 (SHA - Accepted Product - set Retailers to Completed for saved as: TestCase87685) for
		| Retailer |
		| Amazon   |
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase87685)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase87685 and its status is: Completed

@ScenarioId:1459
Scenario: [87686] UPC - Case Pack Only Present in Product - Process to Complete
	#Given I login into the WERCSmart Portal - Administrator Role
	Given I log in with the account saved in TReVor as: ProductAccount
	Given I generate a random UPC number and save as: UPC87686
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
	Then I save the product information as: TestCase87686
	Given I call Shared Step 26897 (Product Characteristics - Solid only available - continue)
	Given I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue) for
		| Retailer |
		| Amazon   |
	Given I call Shared Step 87641(Enter Universal Product Code - case information) for UPC: saved as UPC87686, container type: Paper bag and size: 2 and Quantity: 4 and Transportation option: 4A: steel box
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
		| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
	Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: test
	Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given If purchase details are showing click confirm order
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase87686)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase87686 and its status is: Submitted
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase87686)
	Given I call Shared Step 75309 (SHA > Select Product > UPC List) for product saved as: TestCase87686
	And In the list of UPCs I should see case pack indicatior for UPC: saved as UPC87686
	Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase87686)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase87686)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase87686 and its status is: Assigned
	Given I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase87686)
	Given I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase87686)
	Given I call Shared Step 75347 (WPS Studio - PD+ - set all data and publish using rule and Doc queue - CKLT, NGHS and SBCS) for product saved as: TestCase87686
	Given I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase87686)
	Given I call Shared Step 59066 (Go to SHA Manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase87686)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase87686 and its status is: Accepted
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Accepted Status for saved as: TestCase87686)
	Given I call Shared Step 51664 (SHA - Accepted Product - set Retailers to Completed for saved as: TestCase87686) for
		| Retailer |
		| Amazon   |
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase87686)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase87686 and its status is: Completed
	
@singlerun
Scenario: [87894] Forwarding - Edit existing Case UPC 

Given I Use Test case 87685 to create a product which has a Case UPC and a regular UPC, processed to completed status
Given I navigate to the landing page
And I call Shared Step (Login to WERCSmart - Premium Account)
Then I filter the products by: Accepted by Retailers
And I filter for the product saved as: TestCase87894
And I Confirm the Products shown display the Green Colour Status - which is the Accepted by Retailers
And I call Shared Step 75130 - Bulk Actions - Select Forward Product Registration
And I should see the subheading 3: Select Products & UPCs on the Forward Product Registration window
#Then I select the product with ID saved as: TestCase87894 under the Select Products tab
Then I get the product ID for the product saved as: TestCase87685 then I use this ID in the select Products & UPCs page
Given I click continue on the Forward Product Registration page
Then I confirm the active Forward Product Registration tab is: Select Retailers
#And I Select a retailer which is not already present on the product you are working with, make sure to select a retailer that does not require additional data (such as BB, DI, KG)
#Then In the Forward Product Registration Screen I select the first retailer that does not require additional data and is not: Amazon under Other Retailers and save it as: ChosenRetailer87894
Then I select one of the following retailers: and saved the chosen retailer as: ChosenRetailer87894
| Retailer                                                                       |
| Bed Bath and Beyond (including Harmon, Buy Buy Baby, and Christmas Tree Shops) |
| Dick's Sporting Goods                                                          |
| Kroger                                                                         |
Given I click continue on the Forward Product Registration page
Then I select the first product under the Select UPCs tab
#Then I confirm that: WM is displayed in the Destination Retailers column under Select UPCs
#<-- use as example for accessing this right side table on select UPCs page
Then I confirm that UPC information is displayed in the Select UPCs Table
Then I Check that the Truck Icon is not present next to the UPC saved as: UPC87685
Then I Check that the Truck Icon is present next to the UPC saved as: UPC876851
And I call Shared Step 87897 (Forwarding - Edit Existing Case UPC: UPC876851 - confirm data shown correctly, change all data, Save, Continue) and save the table as: EditCaseUPCTable87894
| Container type | Size | Quantity | Individual UPC contained in the Case Pack | Transportation Options              |
| Paper bag      | 2    | 4        | <UPC87685>                                | 4A:  steel box                      |
| Aerosol Can    | 4    | 8        | Individual UPC contained in the Case Pack | 1A1:  non-removable head steel drum |
Then I confirm the active Forward Product Registration tab is: Product Results
And I confirm that there are NO Errors displayed for the Product
And I click continue on the Forward Product Registration page
Then I confirm the active Forward Product Registration tab is: Review & Submit
Then I select the true radio for the 'Are Statements True' question under the Review and Submit tab
And I click continue on the Forward Product Registration page
And In the Purchase Summary screen I confirm the Purchase Summary header is displayed
Then In the Thank You screen I confirm the following statement is shown: Thank you for registering your product on WERCSmart for assessment.
Then In the Thank You screen I click Home
And I call Shared Step 65080 (Login to Studio and Open SHA manager)
And I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase87894)
Then I Check that the product under the retailer: Amazon is under the status: Accepted
Then I Check that the product under the retailer: <ChosenRetailer87894> is under the status: Submitted
Given I call Shared Step 75309 (SHA > Select Product > UPC List) for product saved as: TestCase87894
Then I call Shared Step 88419 (SHA > UPC - Confirm Case UPC fields (No internal UPC) > Close window) for UPC saved as: UPC876851 for the retailer: Amazon using details saved in the table: EditCaseUPCTable87894

@ScenarioId:1535
Scenario: [87835] View UPCs shows Case UPC Data
Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
Given I generate a random UPC number and save as: UPC87835
Given I generate a random UPC number and save as: UPC87835-2
And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
And I call Shared Step 26897 (Product Characteristics - Solid only available - continue)
And I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
And I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium Hydroxide
And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Given I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue) for
| Retailer |
| Amazon   |
Given I call Shared Step 87647 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC87835, container type: Paper bag and size: 2 do not click continue
And I call Shared Step 87829 (UPC - Add Case UPC - All Data > Continue) for UPC: saved as UPC87835-2, container type: Plastic Container and size: 1 and Quantity: 1 and Individual Upc Case Pack saved As: UPC87835 and Transportation option: 4A: steel box
And I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
And I should see the Additional Documents to Provide Page
And I click continue
And I should see the Optional Reports and Documents Available for Purchase Page
And I click continue
And I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
And I call Shared Step 57883 (Comments - Happy Path) and enter the comment: Test Comment
And I navigate to the home page
And I search for the product saved as: TestCase87835
And I click Row Actions for the first product returned
And I click on the Row Action: View UPCs
And I switch to the tab with title: View UPCs
And I verify the Case UPC data is correct in the View UPCs window:
| UPC Number   | Container Type    | Size Ounces | Retailer | Associated UPC | Quantity | Transport     |
| %UPC87835-2% | Plastic Container | 1           | AM       | %UPC87835%     | 1        | 4A: steel box |
And I verify the Regular UPC data is correct in the View UPCs window:
| UPC Number | Container Type | Size Ounces | Retailer |
| %UPC87835% | Paper bag      | 2           | AM       |
And I close the window that opened
And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase87835

@ScenarioId:5997
Scenario: [87687] UPC - Case Pack, recertification by WERCSmart user - remove Case pack add regular UPC
# I Use Test case 87686 to create a product which has a Case pack UPC for 1 or more retailers and which is in Completed status.
Given I create a product with name: Chalk using Test Case 87686 which has a Case pack UPC for 1 or more retailers and which is in Completed status and save as: TestCase87687
Given I navigate to the landing page
And I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
# I Filter for the product you are using
Then I filter for the product saved as: TestCase87687
# I Confirm the product is shown in Completed status - green color on the retailer icons
Then For product saved as: TestCase87687 the status is: Completed
# I Click the ... icon in the Actions column for your product
# I Click Update Data
And I click Row Actions for the first product returned
And I click on the Row Action: Update Data
And I An Update Registration window will pop-up  - Click on the 'YES' Button
And I If you are using a supplier registered for ULSC you will see the ULSC Service Data-Re-Import step
And I Select the "No, Continue editing data" Radio Button and click 'SAVE'
And I The "The Product" step will be shown
And I Click the 'Recipient and UPC Details Tab Heading'
And I Click the Universal Product Code (UPC) Step heading
And [Shared Step 87689 - UPC - Select UPC, Delete]
And I call Shared Step 42759 (Portal - UPC Page - add 1 UPC)
And I Click the 'Data Acceptance Step Heading'
And I Click 'ACCEPT'
And I You will see the Purchase Summary page - depending on your subscription you will either see the Thank You message or you will see you product details and the Confirm order button.  If the confirm order button is shown Click it.
Then I navigate to the home page
# I Filter for your product and confirm the retailers shown are shown in the orange Assessment in progress color
Then For product saved as: TestCase87687 the status is: Assessment
And I call Shared Step 65080 (Login to Studio and Open SHA manager)
# I Use the shared step below to search for your product ID
And I call Shared Step 49841 (SHA - Search for exact WPS ID in (.*) Status for saved as: (.*))
And I Confirm your product is shown in the Recertification status without the red recertification font color
And [Shared Step 75309 - SHA > Select Product > UPC List]
And I Confirm the Case Pack UPC is shown with the grey background indicating the UPC has been archived
And I Confirm the new regular UPC is shown with a white background indicating the UPC is active
And I Confirm the case pack indicator (an * next to the UPC number) is not shown for the regular UPC
And I Close the UPC pop up


@ScenarioId:6008
Scenario: [87691] UPC - Case Pack, Recertification by WERCSmart User - Remove Case Pack Leaving Only Regular UPC
Given I Use Test case 87685 to create a product which has a Case UPC and a regular UPC, processed to completed status
# TestCase87685
Given I navigate to the landing page
#
And I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
# I Filter for the Product you are using
Then I filter for the product saved as: TestCase87685
# I Confirm the Product is shown in Completed status - green color on the Retailer Icons
Then For product saved as: TestCase87685 the status is: Completed
# I Click the ... icon in the Actions column for your product
Then I click Row Actions for the first product returned
# I Click 'Update Data'
Then I click on the Row Action: Update Data
# I The 'Update Registration' pop-up launches stating the following:  "Update allows you to edit and resubmit your changes to the registration.  Did you want to update the registration and resubmit for a revised Assessment? "Product Name and Product ID"
Then I should see the Update Registration popup
Then I should see an error message: Update allows you to edit and resubmit your changes to the registration.  Did you want to update the registration and resubmit for a revised Assessment? "Product Name and Product ID

And I Click 'YES'
And I Transitions to the 'Product Type Tab Heading'
And I If you are using a supplier registered for ULSC you will see the ULSC Service Data-Re-Import step - Select the "No, continue editing data" Radio Button
And I Click 'SAVE'
And I The "The Product" step will be shown
And I Click the 'Recipient and UPC Details' Tab Heading
And I Click the 'Universal Product Code (UPC)' Step Heading
And I Confirm both the "Case UPC" and the 'Regular UPC" are shown
And I In the shared step below select the Case UPC for deletion
And [Shared Step 87689 - UPC - Select UPC, Delete]
And I Confirm the 'CASE UPC' IS NO LONGER shown
And I Confirm the 'Regular UPC' is still shown
And I Click 'SAVE'
And I Click the 'Data Acceptance' step heading
And I Click on the 'ACCEPT BUTTON'
And I You will see the Purchase Summary Page - depending on your subscription you will either see the Thank You message or you will see you product details and the Confirm order button.
And I If the 'CONFIRM ORDER BUTTON' - Click on it
And I On the left-navigation - Click on the 'Home Icon'
And I Filter for your Product and CONFIRM the Retailers shown are shown in the 'Orange Assessment in Progress' color
And I call Shared Step 65080 (Login to Studio and Open SHA manager)
And I Use the shared step below to search for your product ID
And I call Shared Step 49841 (SHA - Search for exact WPS ID in (.*) Status for saved as: (.*))
And I Confirm your Product is shown in the 'Recertification Status' without the red recertification font color
And [Shared Step 75309 - SHA > Select Product > UPC List]
And I Confirm the 'Case Pack UPC' is shown with the row highlighted in grey - this shows the UPC has been archived/removed
And I Confirm the 'Regular UPC' is shown and has a white background
And I Confirm the 'Case Pack Indicator (*) -  IS NOT SHOWN for the Regular UPC
And I Close the UPC pop up
And I Your Product continues to display under the Product List grid
And I Confirm the 'Clients Column' shows the Retailers associated with your Product
And I Confirm that the Clients listed DO NOT HAVE '2 Asterisks (*)'  shown next to them

Scenario: [87895] Forwarding - Add new Case Pack UPC
NetProjects10\WercsSmart Portal\WERCSmart\UPC Case Pack\Forwarding
Given I Use Test case 87685 to create a product which has a Case UPC and a regular UPC,  processed to completedstatus
And I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
And I Click the Accepted by Retailers Filter heading
And I Enter the Product ID for the Product you are working with and press enter
And I Confirm the Retailer icon is shown in the green Accepted by Retailers color
And [Shared Step 75130 - Bulk Actions - Select Forward Product Registration]
And I In the Search by WPS ID or Product name start typing the WPS ID or product name of the product you are working with
And I Confirm the Product is shown for selection
And I Select the Product by clicking on it
And I Click 'CONTINUE'
And I Select a Retailer other than Canadian Tire, make sure to select a Retailer that does not require additional data (such as BB, DI, KG)
And I Click 'CONTINUE'
And I Select the Product in the left hand table by clicking on the Product information
And [Shared Step 89156 - Forwarding > Add Case UPC > Add all data (including individual UPC)  > Save]
And I Confirm the Case UPC you added is shown in the right hand side table
And I Select the new Case UPC by checking the check box next to the UPC information in the right hand side table
And I Click 'CONTINUE'
And I Confirm 'The Product Results' step is shown
And I Confirm NO ERRORS are shown for your Product
And I Confirm that for the 'Destination Retailers Column'  - you see the recently selected Retailer (Step # 11)
And I Click 'CONTINUE'
And I The 'Review and Submit' step is shown
And I Select the "All of the above statements are true" Radio Button
And I Click 'CONTINUE'
And I Confirm the Purchase Summary page is shown with the success message shown" Thank you for registering your product on WERCSmart for assessment. The retailers may receive your assessment in approximately two (2) business days, if no delays in processing the assessment, and should no data issues arise.  "
And I Click 'HOME'
And I call Shared Step 65080 (Login to Studio and Open SHA manager)
And I call Shared Step 49841 (SHA - Search for exact WPS ID in (.*) Status for saved as: (.*))
And I Confirm your Product is shown in Completed Status for the original retailer(s)
And I Confirm your Product is shown in Submitted status for the new retailer
And [Shared Step 75309 - SHA > Select Product > UPC List]
And [Shared Step 88419 - SHA > UPC - Confirm Case UPC fields (No internal UPC) > Close window]

