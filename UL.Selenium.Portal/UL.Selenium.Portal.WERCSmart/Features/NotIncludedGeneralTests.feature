@Shared
@NewProduct
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
@Studio
@ForwardProductRegistration
@ProductSetUp
@admin
@ViewUpcs
@run_NotIncludedGeneralTests

Feature: NotIncludedGeneralTests

##This is a feature that is used to debug tests that you don't want included in trevor. 

Scenario: [NOTINCLUDEDGENERALTEST] UPC View: Continue button is hidden occasionally from the user-- test 1
	Then I generate: 5 random UPC numbers and save them starting with: RandomUPC
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



	Scenario: [NOTINCLUDEDGENERALTEST] UPC View: Continue button is hidden occasionally from the user-- test 2
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


Scenario: [NOTINCLUDEDGENERALTEST] Forwarding - Edit existing Case UPC 

Given I navigate to the landing page
Then I save the randomly generated UPC: 333446962121 as: UPC87685
Then I save the randomly generated UPC: 795866162008 as: UPC876851
Then I save the randomly generated UPC: 1513537 as: TestCase87894
And I call Shared Step (Login to WERCSmart - Premium Account)
Then I filter the products by: Accepted by Retailers
And I filter for the product saved as: TestCase87894
And I Confirm the Products shown display the Green Colour Status - which is the Accepted by Retailers
And I call Shared Step 75130 - Bulk Actions - Select Forward Product Registration
And I should see the subheading 3: Select Products & UPCs on the Forward Product Registration window
Then I select the product with ID saved as: TestCase87894 under the Select Products tab
Given I click continue on the Forward Product Registration page
Then I confirm the active Forward Product Registration tab is: Select Retailers
#And I Select a retailer which is not already present on the product you are working with, make sure to select a retailer that does not require additional data (such as BB, DI, KG)
Then In the Forward Product Registration Screen I select the first retailer that does not require additional data and is not: Amazon under Other Retailers and save it as: ChosenRetailer87894
Given I click continue on the Forward Product Registration page
Then I select the first product under the Select UPCs tab
#Then I confirm that: WM is displayed in the Destination Retailers column under Select UPCs
#<-- use as example for accessing this right side table on select UPCs page
Then I confirm that UPC information is displayed in the Destination Retailers column under the Select UPCs Table
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
#
#
Given I call Shared Step 75309 (SHA > Select Product > UPC List) for product saved as: TestCase87894


Scenario: [NOTINCLUDEDGENERALTEST] Forwarding - Edit existing Case UPC second half
Given I navigate to the landing page
Then I save the randomly generated UPC: 333446962121 as: UPC87685
Then I save the randomly generated UPC: 795866162008 as: UPC876851
Then I save the randomly generated UPC: 1513537 as: TestCase87894
And I call Shared Step 65080 (Login to Studio and Open SHA manager)
And I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase87894)
Then I Check that the product under the retailer: AM is under the status: Accepted

Scenario: [NOTINCLUDEDGENERALTEST] Forwarding - Edit existing Case UPC -ID search testing
Given I log in with the account saved in TReVor as: PremiumSubscriptionAccount
Given I generate a random UPC number and save as: UPC87685
Given I generate a random UPC number and save as: UPC876851
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
Then I save the product information as: TestCase87685
Given I navigate to the home page
Then I filter the products by: Accepted by Retailers
And I call Shared Step 75130 - Bulk Actions - Select Forward Product Registration
And I should see the subheading 3: Select Products & UPCs on the Forward Product Registration window
Then I get the product ID for the product saved as: TestCase87685 then I use this ID in the select Products & UPCs page
Given I click continue on the Forward Product Registration page

Scenario: [NOTINCLUDEDGENERALTEST] Alert '0' now is Alert '--' : Check

Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
And I should see the Subheading Alerts in the main window
And the Alerts dialog should be visible
Then I see notifications in the Alerts Panel
Then I Check the Alert with text: You have Products Awaiting Update! has the ID: --


Scenario: [NOTINCLUDEDGENERALTEST] Dupe UPC tool, Creating product with one dupe upc and one non dupe upc

	Given I find an existing UPC number in trevor account saved as: ProductAccount using feature context: ExistingUPC_ProductAccount_1
	Given I navigate to the landing page
	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
	Then I save the product information as: TestCase91076
	And I call Shared Step 26897 (Product Characteristics - Solid only available - continue)
	And I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	And I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	And I call Shared Step 75146 (Retailer - Select One or More Retailers that DO NOT REQUIRE Vendor ID or Additional UPC Information, Click Done, Click Continue)
	Then in the UPC Window, I should see the Universal Product Code (UPC) Page
	Given I click the 'Add UPC' button
	Given I add the following into the UPC Fields
		| UPC Number                            | Container Type    | Size | DPCI | Quantity |
		| saved as ExistingUPC_ProductAccount_1 | Plastic Container | 1    |      |          |
	Given I click the 'Add UPC' button
	Then I generate a random UPC number and save as: RandomUPC91076
	Given I add the following into the UPC Fields
		| UPC Number              | Container Type    | Size | DPCI | Quantity |
		| saved as RandomUPC91076 | Plastic Container | 1    |      |          |
Given I click 'Select all' under Destination Retailers in the UPC page
	Given I click continue
	And I should see a list style form error with text: There are UPCs that already exists within the WERCSmart database. Please review the UPCs associated within your account, or request to forward a manufacturer's UPCs by creating a new registration as a request from a Distributor. For UPCs that exist within your WERCSmart account, you may use the Report feature to generate a report for your review. UPCs:
	And I navigate to the home page

Scenario: [NOTINCLUDEDGENERALTEST] ADAPTED VERSION OF Lithium Battery UN38.3 Regulatory Documents to Provide FOR ADDING COLOUR OF INPUT FIELDS CHECK
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Lithium Primary/Metal Batteries
	Then I save the product information as: TestCase104222
	Given I call Shared Step 59927 (Primary Physical State > Solid only available – Without Water Solubility question)
	Given I call Shared Step 65493 (Additional Product Information - US only - Battery is packaged for Retail Sales - No to everything else - Continue)
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName      | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Lithium hydroxide  | 6.7     | false               | false       |            |
		| Graphite           | 33.2    | false               | false       |            |
		| Ethylene carbonate | 60.1    | false               | false       |            |
	Given I call Shared Step 104276 (Enter Regulatory Information - TSCA, CEPA, Not Prop 65)
	Given I call Shared Step 73282 (Lithium Battery Characteristics - Weight in Grams)
	Given I call Shared Step 60096 (Lithium Battery Transportation)
	Then I should see the Retailer Page Page for the New Product
	And The selected retailers on the Retailer page should be:
		| Retailer                   |
		| No Retailer/No UPC Product |
	Given I click continue then if the 'UPCs Warning' popup is displayed I click 'OK'
	Given in the Regulatory Documents to Provide page I click Continue

Scenario: [NOTINCLUDEDGENERALTEST] Lithium Battery Product-no regularotry documents provided 
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC60018
	Given I delete all products with UPC Number: saved as UPC60018
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Lithium ion batteries
	Then I save the product information as: TestCase60018
	Given I call Shared Step 59927 (Primary Physical State > Solid only available – Without Water Solubility question)
	Given I call Shared Step 65493 (Additional Product Information - US only - Battery is packaged for Retail Sales - No to everything else - Continue)
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName      | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Lithium hydroxide  | 6.7     | false               | false       |            |
		| Graphite           | 33.2    | false               | false       |            |
		| Ethylene carbonate | 60.1    | false               | false       |            |
	Given I call Shared Step 104276 (Enter Regulatory Information - TSCA, CEPA, Not Prop 65)
	Given I call Shared Step 54799 (Lithium Battery Characteristics - any data - Happy path)
	Given I call Shared Step 60096 (Lithium Battery Transportation)
	Then I should see the Retailer Page Page for the New Product
	And The selected retailers on the Retailer page should be:
		| Retailer                   |
		| No Retailer/No UPC Product |
	Given I click continue
	Then If the UPCs Warning popup is displayed I click OK
	Given in the Regulatory Documents to Provide page I click Continue
	Then In the Regulatory Documents to Provide Page I check that the input field with label: I have an Article Information Sheet (AIS), Technical Data Sheet (TDS), Battery Data Sheet (BDS) to provide. is shown as Red
	And I click the browse button for label: I have an Article Information Sheet (AIS), Technical Data Sheet (TDS), Battery Data Sheet (BDS) to provide. and upload PDF: C:\Dependencies\WERCSmart\testdoc.pdf
	Then In the Regulatory Documents to Provide Page I check that the input field with label: I have an Article Information Sheet (AIS), Technical Data Sheet (TDS), Battery Data Sheet (BDS) to provide. is shown as Green

Scenario: [NOTINCLUDEDGENERALTEST] SHA LOGIN CHECKER
	And I call Shared Step 65080 (Login to Studio and Open SHA manager)

Scenario: [NOTINCLUDEDGENERALTEST] Registration Suspension: Email Notification Message Does not contain blurb
	#This is the scenario for Ticket 102604 (move to correct location and add TFS ID)
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I Save the email for the TReVor: ProductAccount Test user as: ProductAccountEmail
	Given I save the current emails in the inbox for address saved as: ProductAccountEmail
	Given I generate a random UPC number and save as: UPC109503
	Then The home screen should load
	And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	And I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk
	Then I save the product information as: TestCase109503
	Given I call Shared Step 26897 (Product Characteristics - Solid only available - continue)
	Given I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue) for
		| Retailer  |
		| Walgreens |
	Given I call Shared Step 87647 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC109503, container type: Paper bag and size: 2 do not click continue
	Given I click continue
	And  I call Shared Step 78080 (Regulatory Documents to Provide - Upload OSHA SDS)
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: test
	Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	And I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Submitted Status for saved as: TestCase109503)
	Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase109503)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Assigned Status for saved as: TestCase109503)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase109503 and its status is: Assigned
	And In SHA Manager I select the first product
	And I click the following option in the bottom menu: Suspended
	And In the Suspended dialog I Select the following clients: All
	And In the Suspended dialog in the Select Regulatory Specialist drop down I choose: Automated QASha
	And In the Suspended dialog in the Select Subject drop down I choose: Formula – Document Issue
	And In the Suspended dialog I click Save
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase109503)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase109503 and its status is: Suspended
	Then I Check there should be a new suspension notification email for user: ProductAccountEmail for the Product saved as: TestCase109503 with the suspension subject of: Formula – Document Issue and check it does not contain text from the table:
	| SearchText                                                                                                                                                                                                                                                      |
	| Use the “Recertification” link available on the registration to correct the issue; or                                                                                                                                                                           |
	| Contact the Help Desk Hub via a ticket.  If you registered the product, a ticket is already created in your My Ticket area of the Hub (post a reply to the existing ticket).                                                                                    |
	| If you recertify the data, accept the revisions allowing data transfer.  The assessment will proceed.                                                                                                                                                           |
	| Be aware:  If no response within ten (10) days will result in registration cancellation and the assessment will not proceed to the retailer.  You may contact the Help Desk for reinstatement of the assessment as needed, but the hold remains until resolved. |                                                                                                                                               

#This test will not work as the email will not be sent to products account (selecting product from differnt user)
Scenario: [NOTINCLUDEDGENERALTEST] Suspend a Product - Formula - Document Issue - Check Email does not contain Blurb

	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I Save the email for the TReVor: ProductAccount Test user as: ProductAccountEmail
	Given I save the current emails in the inbox for address saved as: ProductAccountEmail
	Then In SHA Manager I set the filter for status to : Assigned
	And In SHA Manager I select the first product
	And I click the following option in the bottom menu: Suspended
	And In the Suspended dialog I Select the following clients: All
	And In the Suspended dialog in the Select Regulatory Specialist drop down I choose: Automated QASha
	And In the Suspended dialog in the Select Subject drop down I choose: Formula – Document Issue
	And In the Suspended dialog in the Supplier Message field I should see: The composition data provided does not match information listed on the document. You may either provide a corrected document, or correct the composition data to resolve this issue.
	And In the Suspended dialog in the Supplier Message field I add the following text: supplier message input
	And In the Suspended dialog in the Internal Product Note field I should see: The composition data provided does not match information listed on the document. You may either provide a corrected document, or correct the composition data to resolve this issue.
	And In the Suspended dialog in the Internal Product Note field I add the following text: internal product note input
	And In the Suspended dialog I click Save
	And I close alert
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Suspended Status for saved as: ID)
	Then I Check there should be a new suspension notification email for user: ProductAccountEmail for the Product saved as: ID with the suspension subject of: Formula – Document Issue and check it does not contain text from the table:
	| SearchText                                                                                                                                                                                                                                                      |
	| Use the “Recertification” link available on the registration to correct the issue; or                                                                                                                                                                           |
	| Contact the Help Desk Hub via a ticket.  If you registered the product, a ticket is already created in your My Ticket area of the Hub (post a reply to the existing ticket).                                                                                    |
	| If you recertify the data, accept the revisions allowing data transfer.  The assessment will proceed.                                                                                                                                                           |
	| Be aware:  If no response within ten (10) days will result in registration cancellation and the assessment will not proceed to the retailer.  You may contact the Help Desk for reinstatement of the assessment as needed, but the hold remains until resolved. |                                                                                                                                               



	#For 106877 Sprint ticket
Scenario: [NOTINCLUDEDGENERALTEST] View UPCs- Check that UPC name coloumn exists

	Given I Use Test case 87685 to create a product which has a Case UPC and a regular UPC, processed to completedstatus
	Given I navigate to the landing page
	And I call Shared Step (Login to WERCSmart - Premium Account)
	Then I filter the products by: Accepted by Retailers
	And I filter for the product saved as: TestCase87685
	And I click Row Actions for the first product returned
	And I should see the following Actions options
		| Option    |
		| Submit    |
		| Edit      |
		| Delete    |
		| View UPCs |
	Then I click on the Row Action: View UPCs
	Then I navigate the the View UPC tab and Check that the Produt UPCs table contains the coloumn labeled 'UPC Name'
	Given I navigate to the landing page
	
	And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	And I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk
	Then I save the product information as: TestCase109503
	Given I call Shared Step 26897 (Product Characteristics - Solid only available - continue)
	Given I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue) for
		| Retailer  |
		| Walgreens |
	Given I call Shared Step 87647 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC109503, container type: Paper bag and size: 2 do not click continue
	Given I click continue
	And  I call Shared Step 78080 (Regulatory Documents to Provide - Upload OSHA SDS)
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: test
	Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given I navigate to the landing page

	Then I filter the products by: Accepted by Retailers
	And I filter for the product saved as: TestCase109503
	And I click Row Actions for the first product returned
	And I should see the following Actions options
		| Option    |
		| Submit    |
		| Edit      |
		| Delete    |
		| View UPCs |
	Then I click on the Row Action: View UPCs
	Then I navigate the the View UPC tab and Check that the Produt UPCs table contains the coloumn labeled 'UPC Name'
















