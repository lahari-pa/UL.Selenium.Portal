
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

Feature: Philip
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@ScenarioId:6700

#Passing
Scenario:[120790] "U" for UPC Update for Submitted Status
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I generate a random UPC number and save as: UPC85885
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk
	Then I save the product information as: TestCase85982
	Given I call Shared Step 26897 (Product Characteristics - Solid only available - continue)
	Given I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	And I call Shared Step 29181 (Ingredients - add any chemical) with name: Water
	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	And In the 'Select Retailers' window I select the retailer: Costco
	And I click continue
	And I call Shared Step 85909 (UPC - Confirm Package type link and drop down not shown - Add UPC data - Continue) for UPC: saved as UPC85885, container type: Plastic Container and size: 12 click continue
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Then in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	And I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
	| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
	| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
	And I call Shared Step 57883 (Comments - Happy Path) and enter the comment: test
	Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given If purchase details are showing click confirm order
	And I navigate to the home page

And I call Shared Step 65080 (Login to Studio and Open SHA manager)
    Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Submitted Status for saved as: TestCase85982)
    Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase85982 and its status is: Submitted
    Given I navigate to the landing page
    Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)


	Given I search for the product saved as: TestCase85982
	When I click Row Actions for the most recent product returned
	Then I click on the Row Action: Edit UPCs
	Given I click the page heading: Universal Product Code (UPC)
	And I delete UPC: saved as UPC85885
	Then In the list of UPCs I should not see UPC: saved as UPC85885

	#Passed
	Scenario:[121120] Pesticide - New Radio Icon Option
    Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I generate a random UPC number and save as: UPC85885
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Pet Shampoo with pest control
	Then I save the product information as: TestCase85982
	And I call Shared Step 57514 (Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path)
	Given I call Shared Step 105379 Additional Product Information - US, Pesticide No, No OSHA, No DSV, No PL, No GNFR Without Child question
	And I call Shared Step 29181 (Ingredients - add any chemical) with name: Water
	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
	And I should see the Transportation Details 1 Page
    And The following options should be displayed exclusively for section: Product is Regulated for Transport
    | Option                               |
    | Yes                                  |
    | No, due to an exemption or exception |
    | Not Regulated                        |
    And I set the Product is Regulated for Transport field to: Not Regulated
    And I click continue
	And In the 'Select Retailers' window I select the retailer: Costco
	And I click continue
	And I call Shared Step 85909 (UPC - Confirm Package type link and drop down not shown - Add UPC data - Continue) for UPC: saved as UPC85885, container type: Plastic Container and size: 12 click continue
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Then in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	And I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
	| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
	| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
	And I call Shared Step 57883 (Comments - Happy Path) and enter the comment: test
	Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given If purchase details are showing click confirm order
	And I navigate to the home page


	#Passed
	 Scenario:[122366] Battery Containing Product (BCP) (Transportation override at UPC level- New Feature)
	 Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	 Given I generate a random UPC number and save as: UPC85885
	 Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	 Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Battery-Containing Product
	 Then I save the product information as: TestCase120798
	 Given I call Shared Step 60756 (Additional Product Information with Country and every option)
	 And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	 Then I should see the Product Includes Battery Page
	 Given I set the Indicate how battery is packaged option to: The battery is shipped with but not included in my product.
	 Given I add the following batteries:
		 | Battery Type     | Manufacturer | Number of batteries per package | How many batteries required to run | Saved As       |
		 | Lithium Primary  | <any>        | 4                               | 4                                  | lithiumbattery |
	 Given I click continue
	 And I set 'Product has had TCLP; Report is available' to: No
	 And I set the Lead option to: No
	 And I set the Mercury option to: No
	 And I set the Silver option to: No
	 And I set the Cadmium option to: No
	 And I set the Chromium option to: No
	 And I set the Barium option to: No
	 And I set the Arsenic option to: No
	 And I set the Selenium option to: No
	 Given I click continue
	 Then I should see the Electronic Equipment Page
	 And I set 'Contains Circuit Board' to: No
	 And I set 'Has a LCD or Plasma Display' to: No
	 Given I click continue
	Given I call Shared Step 60096 (Lithium Battery Transportation)
	And In the 'Select Retailers' window I select the retailer: Costco
	And I click continue
	And I call Shared Step 85909 (UPC - Confirm Package type link and drop down not shown - Add UPC data - Continue) for UPC: saved as UPC85885, container type: Plastic Container and size: 12 click continue
	And I call Shared Step 57883 (Comments - Happy Path) and enter the comment: test
	Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given If purchase details are showing click confirm order
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase120798
































	Scenario:[120798] "U" for UPC Update for Suspended Status
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I generate a random UPC number and save as: UPC85885
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk
	Then I save the product information as: TestCase120798
	Given I call Shared Step 26897 (Product Characteristics - Solid only available - continue)
	Given I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	And I call Shared Step 29181 (Ingredients - add any chemical) with name: Water
	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	And In the 'Select Retailers' window I select the retailer: Costco
	And I click continue
	And I call Shared Step 85909 (UPC - Confirm Package type link and drop down not shown - Add UPC data - Continue) for UPC: saved as UPC85885, container type: Plastic Container and size: 12 click continue
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Then in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	And I call Shared Step 64097 - Additional Documents -> Contact Information - Add any Name, address, phone and emergency phone - Happy Path
	And I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
	| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
	| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
	And I call Shared Step 57883 (Comments - Happy Path) and enter the comment: test
	Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given If purchase details are showing click confirm order
	And I navigate to the home page
	Given I search for the product saved as: TestCase120798
	When I click Row Actions for the most recent product returned
	Then I click on the Row Action: Edit UPCs

	Given In the New Product page I click tab: Recipient and UPC Details
	Given I click the page heading: Universal Product Code (UPC)
	And I delete UPC: saved as UPC85885
	Then In the list of UPCs I should not see UPC: saved as UPC85885

	And I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase120798)
    Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase120798 and its status is: Submitted
	Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase120798)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase120798)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase120798 and its status is: Assigned
    And I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase120798)
	#And I call Shared Step 20375 - Go to Product Attributes via Authoring Tab in PDP/PAP (Maxed Out)
	And I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase120798)
	And I call Shared Step 78877 - WPS Studio - PD+ - set all data and publish using rule and doc queue - CKLT, NGHS, HSGH (EN and CF) and SBCS for saved as: TestCase86187
	And I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase86187)
	Given I call Shared Step 59066 (Go to SHA Manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase86187)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase86187 and its status is: Accepted or Completed
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I search for the product saved as: TestCase120798
	When I click Row Actions for the most recent product returned
	Then I click on the Row Action: Edit UPCs
	Given I generate a random UPC number and save as: UPC85885
	And I call Shared Step 85909 (UPC - Confirm Package type link and drop down not shown - Add UPC data - Continue) for UPC: saved as UPC85885, container type: Plastic Container and size: 12 click continue
	And I navigate to the home page



























	Scenario:[120849] "U" for UPC Update No Fee Charge
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I generate a random UPC number and save as: UPC85885
	Given I generate a random UPC number and save as: UPC858851
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk
	Then I save the product information as: TestCase120798
	Given I call Shared Step 26897 (Product Characteristics - Solid only available - continue)
	Given I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	And I call Shared Step 29181 (Ingredients - add any chemical) with name: Water
	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	And In the 'Select Retailers' window I select the retailer: Costco
	And I click continue
	And I call Shared Step 85909 (UPC - Confirm Package type link and drop down not shown - Add UPC data - Continue) for UPC: saved as UPC85885, container type: Plastic Container and size: 12 click continue
	And I call Shared Step 85909 (UPC - Confirm Package type link and drop down not shown - Add UPC data - Continue) for UPC: saved as UPC858851, container type: Plastic Container and size: 12 click continue
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Then in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	And I call Shared Step 64097 - Additional Documents -> Contact Information - Add any Name, address, phone and emergency phone - Happy Path
	And I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
	| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
	| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
	And I call Shared Step 57883 (Comments - Happy Path) and enter the comment: test
	Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given If purchase details are showing click confirm order
	And I navigate to the home page

	And I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase120798)
    Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase120798 and its status is: Submitted
	Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase120798)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase120798)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase120798 and its status is: Assigned
    And I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase120798)
    And I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase120798)
	And I call Shared Step 78877 - WPS Studio - PD+ - set all data and publish using rule and doc queue - CKLT, NGHS, HSGH (EN and CF) and SBCS for saved as: TestCase86187
	And I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase86187)
	Given I call Shared Step 59066 (Go to SHA Manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase86187)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase86187 and its status is: Accepted or Completed

	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I search for the product saved as: TestCase120798
	When I click Row Actions for the most recent product returned
	Then I click on the Row Action: Edit UPCs
	Given I generate a random UPC number and save as: UPC85885
	And I call Shared Step 85909 (UPC - Confirm Package type link and drop down not shown - Add UPC data - Continue) for UPC: saved as UPC85885, container type: Plastic Container and size: 12 click continue
	And I click Save in The Product Page
	Given In the Data Acceptance page I click on the Accept button
	Then In the Thank You screen I confirm the following statement is shown: Thank you for registering your product on WERCSmart for assessment.
	And I navigate to the home page







	Scenario:[120866] UPC Retailer and Feed

	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I generate a random UPC number and save as: UPC85885
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk
	Then I save the product information as: TestCase85982
	Given I call Shared Step 26897 (Product Characteristics - Solid only available - continue)
	Given I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	And I call Shared Step 29181 (Ingredients - add any chemical) with name: Water
	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	And In the 'Select Retailers' window I select the retailer: Costco
	And I click continue
	And I call Shared Step 85909 (UPC - Confirm Package type link and drop down not shown - Add UPC data - Continue) for UPC: saved as UPC85885, container type: Plastic Container and size: 12 click continue
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Then in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	And I call Shared Step 64097 - Additional Documents -> Contact Information - Add any Name, address, phone and emergency phone - Happy Path
	And I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
	| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
	| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
	And I call Shared Step 57883 (Comments - Happy Path) and enter the comment: test
	Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given If purchase details are showing click confirm order
	And I navigate to the home page

	And I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase85982)
	Given I call Shared Step 75309 (SHA > Select Product > UPC Retailer and Feed) for product saved as: TestCase85982
	Then I check for the following columns
	| Column Name |
	| UPC Number  |
	| Pkg Type    |
	| Pkg Size    |



	Scenario:[120873] Product List - CW Column "Y" or "N"


     Scenario:[119578] My Products - More Filters - For Discontinued Registrations
	 Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	 Then The home screen should load
	 And I should see an option for More Filters
	 Given I click More Filters in the products grid
	 Then I click the checkbox labeled: Show Archived Retailers
	 #Confirm that only discontinued products appear
	 Then I click the checkbox labeled: Show Archived Retailers



	 Scenario:[122413] After deselecting canada under product type, Data not wipe out it just hides it
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I generate a random UPC number and save as: UPC85885
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk
	Then I save the product information as: TestCase85982
	Given I call Shared Step 26897 (Product Characteristics - Solid only available - continue)
	Given I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	And I call Shared Step 29181 (Ingredients - add any chemical) with name: Water
	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	And In the 'Select Retailers' window I select the retailer: Costco
	And I click continue
	And I call Shared Step 85909 (UPC - Confirm Package type link and drop down not shown - Add UPC data - Continue) for UPC: saved as UPC85885, container type: Plastic Container and size: 12 click continue
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Then in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	And I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
	| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
	| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
	And I call Shared Step 57883 (Comments - Happy Path) and enter the comment: test
	Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	And in the Purchase Summary Screen I should see the following:
		| Item Description                                            |
		| Chemical assessment                                         |
		| Additional document Canada GHS SDS ENGLISH (USA)            |
		| Additional document language Canada GHS SDS FRENCH (CANADA) |
		Given In the Purchase Summary screen I click Remove for product saved as TestCase63323
		 Given in the modal dialog I click the "REMOVE" button
       Then The home screen should load
       And I search for the product saved as: TestCase63323
       And I click Row Actions for the first product returned
       And I should see the following Actions options
             | Option    |
             | Submit    |
             | Edit      |
             | Delete    |
             | View UPCs |
Then I click on the Row Action: Edit
       Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase63323

	Given If purchase details are showing click confirm order
	And I navigate to the home page
