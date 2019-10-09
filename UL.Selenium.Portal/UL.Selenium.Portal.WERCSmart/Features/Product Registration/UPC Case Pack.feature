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

Given I Use Test case 87685 to create a product which has a Case UPC and a regular UPC, processed to completedstatus
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
| <UPC87835-2> | Plastic Container | 1           | AM       | <UPC87835>     | 1        | 4A: steel box |

And I verify the Regular UPC data is correct in the View UPCs window:
| UPC Number | Container Type | Size Ounces | Retailer |
| <UPC87835> | Paper bag      | 2           | AM       |

#And I Confirm you see the UPC Number you selected as the Individual UPC contained in the Case Pack shown under the Associated UPC column for the Case UPC
#And I Confirm you see the Container Type shown for the Case UPC
#And I Confirm that you see a value in the Size column for the Case UPC
#And I Confirm that you see a value in theQuantity column for the Case UPC
#And I Confirm that you see the entry you selected for the Transportation Options shown in the Transport column for the Case UPC
#And I Confirm that the Retailer column shows the retailer you selected for the Case UPC
#
#And I Confirm that the regular UPC Number is shownin the UPC Number column
#And I Confirm that the regular UPC row does not show the truck icon next to the regular UPC number
#And I Confirm that the UPC number shown in the UPC Number column for the regular UPC matches the UPC number shown in the Associated UPC column for the Case UPC
#And I Confirm that the Associated column for the regular UPC is blank
#And I Confirm that the Container Type shown for the regular UPC shows the option you selected on the UPC step
#And I Confirm that you see a value in the Size column for the regular UPC
#And I Confirm that the Quantity and Transport columns for the regular UPC are blank
#And I Confirm that the Retailer column shows the retailer you selected for the regular UPC

And I close the window that opened
And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase87835
