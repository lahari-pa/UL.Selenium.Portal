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
@run_UPC
Feature: UPC

@TReVorId:21457
Scenario: [87584] Physical State = Solid, UPC step - Size shows as Size (Weight Ounces)
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk
	Then I save the product information as: TestCase87584
	Given I call Shared Step 37857 (Enter Physical Property - Solid)
	Given I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Amazon
	Given I click the 'Add Case UPC' button
	Then I should see the following UPC options:
		| Option                            |
		| UPC Number                        |
		| Quantity of Units within the Case |
		| Size (Weight Ounces)              |
	Then I should not see the following UPC options:
		| Option              |
		| Size (Fluid Ounces) |
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase87584

@TReVorId:21458
Scenario: [87587] Physical State = Liquid, UPC step - Size shows as Size (Fluid Ounces)
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Bubble solution
	Then I save the product information as: TestCase87584
	Given I call Shared Step 57514 (Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path)
	Given I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Amazon
	Given I click the 'Add Case UPC' button
	Then I should see the following UPC options:
		| Option                            |
		| UPC Number                        |
		| Quantity of Units within the Case |
		| Size (Fluid Ounces)               |
	Then I should not see the following UPC options:
		| Option               |
		| Size (Weight Ounces) |
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase87587

@TReVorId:21459
Scenario: [87588] Physical State = Aerosol, UPC step - Size shows as Size (Fluid Ounces)
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Deodorant - Aerosol
	Then I save the product information as: TestCase87588
	Given I call Shared Step 57528 (Product Characteristics - Aerosol Only - add data - Continue - Happy Path)
	Given I call Shared Step 60310 (Additional Product Information - Without Child question)
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
	Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)
	Given I call Shared Step 62710 (Confirm VOC OTC/CARB heading and select No to FIRST QUESTION ONLY - Happy Path)
	Given I call Shared Step 60631 (VOC - HVOC and MVOC - add values - Continue - Happy Path)
	Given in the Volatile Organic Compound Summary page I click Continue
	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Amazon
	Given I click the 'Add Case UPC' button
	Then I should see the following UPC options:
		| Option                            |
		| UPC Number                        |
		| Quantity of Units within the Case |
		| Size (Fluid Ounces)               |
	Then I should not see the following UPC options:
		| Option               |
		| Size (Weight Ounces) |
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase87588

@TReVorId:21460
Scenario: [87593] Physical State = GAS, UPC step - Size shows as Size (Fluid Ounces)
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Compressed gas
	Then I save the product information as: TestCase87593
	Given I call Shared Step 74981 (Product Characteristics - gas)
		| Secondary Physical State | Select the best Water Solubility description |
		| Compressed gas           | Very slight                                  |
	Given I call Shared Step 60310 (Additional Product Information - Without Child question)
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)
	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Amazon
	Given I click the 'Add Case UPC' button
	Then I should see the following UPC options:
		| Option                            |
		| UPC Number                        |
		| Quantity of Units within the Case |
		| Size (Fluid Ounces)               |
	Then I should not see the following UPC options:
		| Option               |
		| Size (Weight Ounces) |
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase87593

@TReVorId:21461
Scenario: [87596] Create BCP (Camera with battery) -  UPC step - Size shows as Weight (Ounces)
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Camera w/Battery
	Then I save the product information as: TestCase87596
	Given I call Shared Step 70393 (Additional Product Information - With marketed for use by a Child - Direct Ship - Private Label questions only)
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I call Shared Step 48367 (Product Includes Battery > any type)
		| Battery Type | Manufacturer | Number of batteries per package | How many batteries required to run |
		| Alkaline     | <any>        | 6                               | 6                                  |
	Given I call Shared Step 48369 (Toxicity Characteristics Leaching Procedure (TCLP) - No to ALL With Copper)
	Given I call Shared Step 58189 (Answer Electronic Equipment questions - With Cathode Ray - No to all)
	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Amazon
	Given I click the 'Add Case UPC' button
	Then I should see the following UPC options:
		| Option                            |
		| UPC Number                        |
		| Quantity of Units within the Case |
		| Size (Weight Ounces)              |
	Then I should not see the following UPC options:
		| Option              |
		| Size (Fluid Ounces) |
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase87596

@TReVorId:21462
Scenario: [87597] Create Electronic - UPC Step - Size shows as Size (Weight Ounces)
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Answering machine, No battery included
	Then I save the product information as: TestCase87597
	And I call Shared Step 69687 (Additional Product Information - US, No(PL))
	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	And I call Shared Step 48369 (Toxicity Characteristics Leaching Procedure (TCLP) - No to ALL With Copper)
	And I call Shared Step 71955 (Answer Electronic Equipment questions - Without Cathode Ray - No to all)
	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Amazon
	Given I click the 'Add Case UPC' button
	Then I should see the following UPC options:
		| Option                            |
		| UPC Number                        |
		| Quantity of Units within the Case |
		| Size (Weight Ounces)              |
	Then I should not see the following UPC options:
		| Option              |
		| Size (Fluid Ounces) |
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase87597

@TReVorId:21463
Scenario: [87595] Kit - UPC Page - Size shows as Weight (Ounces)
	# Hardcoded values for Product ID. These do not exist in all environments.
	Given I save to context name: TestCase1 and value: 1525111
	Given I save to context name: TestCase2 and value: 1501057
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I filter the products by: Accepted by Retailers
	Given I save the list of Product IDs displayed on the page as: ProductInProgressList87595
	Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Hair Color Kit
	Then I save the product information as: TestCase87595
	Given I call Shared Step 60648 (Additional Product Information - US, No (Direct Ship), No (PL), No (GNFR))
	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	And I call Shared Step 31427 (Create the Kit - Adding two products: product 1: TestCase1  and product 2: TestCase2)
	Given I call Shared Step 57506 (Transportation Details 1 - Regulated for Transport(No) - Exemption(Random) - Continue - Happy Path)
	Given I call Shared Step 62536 (Transportation Details 2 > I do not ship internationally > Continue - Happy Path)
	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Amazon
	Given I click the 'Add Case UPC' button
	Then I should see the following UPC options:
		| Option                            |
		| UPC Number                        |
		| Quantity of Units within the Case |
		| Size (Weight Ounces)              |
	Then I should not see the following UPC options:
		| Option              |
		| Size (Fluid Ounces) |
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase87595

@TReVorId:21795
Scenario: [87640] UPC - Case Pack Only Present in product
	#Given I login into the WERCSmart Portal - Administrator Role
	Given I log in with the account saved in TReVor as: PremiumSubscriptionAccount
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

@TReVorId:21796
Scenario: [87643] UPC - Case Pack & regular UPC present in product
	#Given I login into the WERCSmart Portal - Administrator Role
	Given I log in with the account saved in TReVor as: PremiumSubscriptionAccount
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

@TReVorId:21840
Scenario: [87650] Battery Product - limit of 5 UPCs for Lithium ion battery- Case UPC counts towards the 5 limit
	#Given I login into the WERCSmart Portal - Administrator Role
	Given I log in with the account saved in TReVor as: PremiumSubscriptionAccount
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

@TReVorId:21841
Scenario: [87676] UPC - Case Pack can be removed from new product
	#Given I login into the WERCSmart Portal - Administrator Role
	Given I log in with the account saved in TReVor as: PremiumSubscriptionAccount
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
	Given I log in with the account saved in TReVor as: PremiumSubscriptionAccount
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
	Given I log in with the account saved in TReVor as: PremiumSubscriptionAccount
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase87676

@TReVorId:21886
Scenario: [87685] UPC - Case Pack & Regular UPC present in Product - Process to Complete
	#Given I login into the WERCSmart Portal - Administrator Role
	Given I log in with the account saved in TReVor as: PremiumSubscriptionAccount
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

@TReVorId:21887
Scenario: [87686] UPC - Case Pack Only Present in Product - Process to Complete
	#Given I login into the WERCSmart Portal - Administrator Role
	Given I log in with the account saved in TReVor as: PremiumSubscriptionAccount
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

@TReVorId:22366
Scenario: [87832] View Shows Case UPC Data
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I generate a random UPC number and save as: UPC87832
	Given I generate a random UPC number and save as: UPC878321
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
	Then I save the product information as: TestCase87832
	Given I call Shared Step 26897 (Product Characteristics - Solid only available - continue)
	Given I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue) for
		| Retailer |
		| Amazon   |
	Given I call Shared Step 87647 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC87832, container type: Paper bag and size: 2 do not click continue
	Given I call Shared Step 87641 (Enter Universal Product Code - case information) for UPC: saved as UPC878321, container type: Paper bag and size: 2 and Quantity: 2 and Associated UPC: UPC87832 and Transportation option: 4A: steel box
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
		| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
	Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: test
	Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given If purchase details are showing click confirm order
	Given I navigate to the home page
	And I filter for the product saved as: TestCase87832
	And I click Row Actions for the first product returned
	And I click on the Row Action: View
	Then I switch to the Data Summary page
	And The Data Summary section Provide the product's UPC(s), including container type and size (ounces) should be showing the following UPC table:
		| UPC Number         | Associated UPC    | Container Type | Size (Ounces) | Quantity | Transport     | Retailers |
		| saved as UPC878321 | saved as UPC87832 | Paper bag      | 2             | 2        | 4A: steel box | AM        |
		| saved as UPC87832  |                   | Paper bag      | 2             |          |               | AM        |

@TReVorId:22365
Scenario: [87825] Summary Shows Case UPC Data
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I generate a random UPC number and save as: UPC87825
	Given I generate a random UPC number and save as: UPC878251
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
	Then I save the product information as: TestCase87825
	Given I call Shared Step 26897 (Product Characteristics - Solid only available - continue)
	Given I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue) for
		| Retailer |
		| Amazon   |
	Given I call Shared Step 87647 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC87825, container type: Paper bag and size: 2 do not click continue
	Given I call Shared Step 87641 (Enter Universal Product Code - case information) for UPC: saved as UPC878251, container type: Paper bag and size: 2 and Quantity: 2 and Associated UPC: UPC87825 and Transportation option: 4A: steel box
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
		| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
	Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: test
	Given I click the Summary button in the Data Acceptance window
	Then I switch to the Data Summary page
	And The Data Summary section Provide the product's UPC(s), including container type and size (ounces) should be showing the following UPC table:
		| UPC Number         | Associated UPC    | Container Type | Size (Ounces) | Quantity | Transport     | Retailers |
		| saved as UPC878251 | saved as UPC87825 | Paper bag      | 2             | 2        | 4A: steel box | AM        |
		| saved as UPC87825  |                   | Paper bag      | 2             |          |               | AM        |
	And I close the window that opened
	And I navigate to the home page
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase87825

	@singlerun
@TReVorId:23416
	Scenario: [95988] Mass Upload UPCs Floating
	Then I generate: 20 random UPC numbers and save them starting with: RandomUPC
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	And I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Soap (Bar, Liquid) for Body
	Then I save the product information as: TestCase95988
	And I click continue
	And I call Shared Step 57501 (Product Characteristics - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue - HP)
	And I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	And I call Shared Step 29181 (Ingredients - add any chemical) with name: soap
	Then I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
	And I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Amazon
	And I click continue
	And I click Sample File link and verify the Upload UPC form and save it as test95988 with data:
		| UPC          | Quantity | Size | Net Explosive Mass | US: Part Number | US: Item Number | GP: Part Number | SP: Part Number | TG: DPCI    | HD: OMSID | CT: Item Number   |
		| 823973000000 | 1        | 11   | 1.22               | 11AB45          | 1001            | 1111            | A0001           | 111-22-0001 | 100000001 | 123-1234,123-1230 |
		| 71617198008  | 2        | 22   | 2.33               | 12AB56          | 1002            | 2222            | B0002           | 111-22-0002 | 100000002 | 123-1234,123-1231 |
		| 978959000000 | 3        | 33   | 3.44               | 12AC67          | 1003            | 3333            | C0003           | 111-22-0003 | 100000003 | 123-1234,123-1232 |
		| 688267000000 | 4        | 44   | 4.55               | 12AD89          | 1004            | 4444            | D0004           | 111-22-0004 | 100000004 | 123-1234,123-1233 |
		| 854911000000 | 5        | 55   | 5.66               | 12AF00          | 1005            | 5555            | E0005           | 111-22-0005 | 100000005 | 123-1234,123-1234 |
	And I edit the testdoc.xlsx, and save its filepath as: Bulktest95988 and verify it contains the UPC data in the table saved as: UPCTable95988
		| UPC           | Quantity | Size | Net Explosive Mass | US: Part Number | US: Item Number | GP: Part Number | SP: Part Number | TG: DPCI    | HD: OMSID | CT: Item Number   |
		| <RandomUPC1>  | 1        | 32   | 1.22               | 00AA01          | 2001            | 1111            | F0001           | 111-22-0001 | 100000001 | 123-1234,123-1230 |
		| <RandomUPC2>  | 2        | 32   | 2.33               | 00BB02          | 2002            | 1112            | G0002           | 111-22-0002 | 100000002 | 123-1234,123-1231 |
		| <RandomUPC3>  | 3        | 32   | 3.44               | 00CC03          | 2003            | 1113            | H0003           | 111-22-0003 | 100000003 | 123-1234,123-1232 |
		| <RandomUPC4>  | 4        | 32   | 4.55               | 00DD04          | 2004            | 1114            | I0004           | 111-22-0004 | 100000004 | 123-1234,123-1233 |
		| <RandomUPC5>  | 5        | 32   | 5.66               | 00EE05          | 2005            | 1115            | J0005           | 111-22-0005 | 100000005 | 123-1234,123-1234 |
		| <RandomUPC6>  | 6        | 32   | 6.77               | 00FF06          | 2006            | 1116            | K0006           | 111-22-0006 | 100000006 | 123-1234,123-1235 |
		| <RandomUPC7>  | 7        | 32   | 7.88               | 00GG07          | 2007            | 1117            | L0007           | 111-22-0007 | 100000007 | 123-1234,123-1236 |
		| <RandomUPC8>  | 8        | 32   | 8.99               | 00HH08          | 2008            | 1118            | M0008           | 111-22-0008 | 100000008 | 123-1234,123-1237 |
		| <RandomUPC9>  | 9        | 32   | 9.00               | 00II09          | 2009            | 1119            | N0009           | 111-22-0009 | 100000009 | 123-1234,123-1238 |
		| <RandomUPC10> | 10       | 32   | 10.11              | 00JJ10          | 2010            | 1110            | O0010           | 111-22-0010 | 100000010 | 123-1234,123-1239 |
		| <RandomUPC11> | 11       | 32   | 11.22              | 00KK11          | 2011            | 1111            | P0013           | 111-22-0011 | 100000011 | 123-1234,123-1240 |
		| <RandomUPC12> | 12       | 32   | 12.33              | 00LL12          | 2012            | 1112            | Q0014           | 111-22-0012 | 100000012 | 123-1234,123-1241 |
		| <RandomUPC13> | 13       | 32   | 13.44              | 00MM13          | 2013            | 1113            | R0015           | 111-22-0013 | 100000013 | 123-1234,123-1242 |
		| <RandomUPC14> | 14       | 32   | 14.55              | 00NN14          | 2014            | 1114            | S0016           | 111-22-0014 | 100000014 | 123-1234,123-1243 |
		| <RandomUPC15> | 15       | 32   | 15.66              | 00OO15          | 2015            | 1115            | T0015           | 111-22-0015 | 100000015 | 123-1234,123-1244 |
		| <RandomUPC16> | 16       | 32   | 16.77              | 00PP16          | 2016            | 1116            | U0016           | 111-22-0016 | 100000016 | 123-1234,123-1245 |
		| <RandomUPC17> | 17       | 32   | 17.88              | 00QQ17          | 2017            | 1117            | u0017           | 111-22-0017 | 100000017 | 123-1234,123-1246 |
		| <RandomUPC18> | 18       | 32   | 18.99              | 00RR18          | 2018            | 1118            | v0018           | 111-22-0018 | 100000018 | 123-1234,123-1247 |
		| <RandomUPC19> | 19       | 32   | 19.00              | 00SS19          | 2019            | 1119            | W0019           | 111-22-0019 | 100000019 | 123-1234,123-1248 |
		| <RandomUPC20> | 20       | 32   | 20.11              | 00TT20          | 2020            | 1120            | X0020           | 111-22-0020 | 100000020 | 123-1234,123-1249 |
	Then I click the 'Upload UPCs' button and upload the file saved as: Bulktest95988
	Then I confirm that Add Multiple UPC popup appears and the values are the same as the UPC Upload document saved in the Table called: UPCTable95988	
	Then In the Add Multiple dialog box I select all UPCs
	Then I Confirm All UPCs are: Selected
	Then In the Add Multiple dialog box I select the packaging type: <first>
	Then I Check that the type coloumn becomes populated with option: <first>
	Given In the Add Multiple dialog box I click Next
	Then In the Add Multiple dialog box I select all Retailers
	Then I Check if all Retailers are: Selected
	Then In the Add Multiple dialog box I select all Retailers
	Then I Check if all Retailers are: Not Selected
	Then In the Add Multiple dialog box I select all Retailers
	Then I Check if all Retailers are: Selected
	Then In the Add Multiple dialog box I click Finish
	And I confirm that Add Multiple UPC popup disappears and the values on the new product screen are the same as the UPC Upload document saved in the Table called: UPCTable95988
	Then I Confirm that the Add/Upload UPC Buttons remain stay visible when scrolling up and down the page
	Then I click Continue and should not see an error message
	And I navigate to the home page
	And I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase95988
