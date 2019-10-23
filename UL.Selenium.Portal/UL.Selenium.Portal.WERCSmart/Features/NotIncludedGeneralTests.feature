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
@SupplierReports
@CreateProducts
@admin
@ViewUpcs
@Solutions
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
	Then I should see the Universal Product Code (UPC) Page
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
	



Scenario: [NOTINCLUDEDGENERALTEST] Rejected Registration - Edit -  Message is displayed about Rejected Registrations and SDS Restrictions

	Given I Use Test case 75142 to create a NEW PRODUCT and get it to Submitted status in SHA
	And I call Shared Step 83242 (SHA - Submitted or Assigned product - Reject Submission - any subject - Save for the product saved as: TestCase75142)
	And I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase75142)
	And In the SHA manager grid I see the WPS ID I have saved as product: TestCase75142 and its status is: New
	Given I navigate to the landing page
	And I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Then I filter for the product saved as: TestCase75142
	And I edit the product saved as: TestCase75142
	Then I confirm the Rejected Registration popup displays the warning: Please be aware that rejected registrations will not permit any changes to the Safety Data Sheet (SDS) option. Upon rejection, if you want to change your Safety Data Sheet selection (i.e. Select Authoring instead of providing a Document, you will need to DELETE the rejected registration and create a new registration to submit, with your proper selection.
	Given in the modal dialog I click cancel
	Then I confirm the Rejected Registration popup has closed
	And I edit the product saved as: TestCase75142
	Then I confirm the Rejected Registration popup displays the warning: Please be aware that rejected registrations will not permit any changes to the Safety Data Sheet (SDS) option. Upon rejection, if you want to change your Safety Data Sheet selection (i.e. Select Authoring instead of providing a Document, you will need to DELETE the rejected registration and create a new registration to submit, with your proper selection.
	Given in the modal dialog I click Continue
	And I should see the The Product Page

Scenario: [NOTINCLUDEDGENERALTEST] Advanced Reporting - Registrations Published report -
	#For 92210 Ticket Should be 98534
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Then I select the Product Registrations Published report from Advanced Reporting in SHA
	Then I Check that the Description Text for the Report: Product Registrations Published is shown as: Assessed Registrations Published for Transfer and Completion to Retailers within a Date Range
	Then I enter start Date: 08-08-2019 and end Date: 11-14-2019 for the Product Registrations Published report then I click Submit
	And I wait for the Advanced Reporting Preparing Report popup to disappear
	#For below step need an actual file to get name etc
	Given I confirm that an excel file is produced called PM Monthly Status Report - Target.xlsx and save as 105329
	#For below step need an actual file for headers
	Then I confirm that the excel file saved as: 105329 contains the following columns:
		| Column              |
		| WPSID               |
		| Product Name        |
		| WMDRUM              |
		| WMCAD               |
		| WMBC                |
		| PYST                |
		| PYSTM               |
		| FPF                 |
		| PH                  |
		| RU                  |
		| EPAN                |
		| CAWC                |
		| WSWC                |
		| UNM                 |
		| HCM                 |
		| PSNDWM              |
		| HCDWM               |
		| DVID                |
		| PSNV                |
		| HCW                 |
		| UNIFFC              |
		| BATT                |
		| BATTT               |
		| CHEMICAL            |
		| KIT                 |
		| OTC                 |
		| TGWAST              |
		| MPIND               |
		| DOTPG               |
		| DERGN               |
		| INTFC               |
		| CASEC               |
		| CASECD              |
		| DOTBMP              |
		| IMDGBMP             |
		| CATEST              |
		| WATEST              |
		| CNTXT               |
		| Last Published Date |
		| Published By        |
		| Recert              |
		| Product_status      |
		| GHS                 |

Scenario: [NOTINCLUDEDGENERALTEST] UL Solutions: Navigator Logo has TradeMark Symbol

Given I Login into WERCSmart Portal - Admin Role - WERCs Visual Account
	Then the WERCSmart homepage should load
	Then I click the UL Solution Center icon in the Navigation Pane
	Then I confirm that the UL Solution Center page is loaded
	Then I confirm the following sections are displayed in the UL Solution Center page:
		| Sections  |
		| Navigator |
	#Then do Image Comparison here

Scenario: [NOTINCLUDEDGENERALTEST] product submit upc info entry
Given I generate a random UPC number and save as: UPC109503
Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
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


Scenario: [NOTINCLUDEDGENERALTEST] UL Solution Center - Shows Updated Navigator Logo
	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	Given I click the UL Solution Center icon in the QuickLinks Pane
	Then I confirm that the UL Solution Center page is loaded
	Then I Confirm the Navigator heading is displayed next to an icon
	#Check Icon is updated version
	And I Confirm the information statement for section: Navigator reads: Navigator highlights the main chemical regulatory requirements for over 50 countries around the world. These summaries compile the most important information all in one place, offering easy to understand explanations of complex topics, paired with links to laws and helpful resources. Summaries are authored and updated by our global regulatory specialists, whose primary responsibility is the monitoring and reporting of regulations in their given country.
	And I confirm the Learn More button is displayed for section: Navigator
	Given I click the Learn More button for section: Navigator
	Given I switch to the Navigator information tab
	Then I check that the current URL contains: https://msc.ul.com/en/products/navigator/

Scenario: [NOTINCLUDEDGENERALTEST] Pub to completed then run report
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I create a Chalk product which has a Case UPC and a regular UPC, process to completed and save the product as: (.*)

Scenario: [NOTINCLUDEDGENERALTEST] Completed product test 1

	Given I create a product and take to completed using Test Case 75335 and save as: ProductSetup64528
	Given I navigate to the landing page

Scenario: [NOTINCLUDEDGENERALTEST] UPCs and Registrations (Retailer Specific) Report correctly displays case pack individual UPC
#For Ticket 108160
#add product with indv upc and case pack upc to this and get both upc as saved as
	Given I Submit a new product which has a Case UPC and a regular UPC
	Given I navigate to the landing page
	And I call Shared Step (Login to WERCSmart - Premium Account)
	#Should be able to remove the wait but check first
	Then I wait for 30 seconds
	Given I click the Supplier Reports icon in the QuickLinks Pane
	Given Under the Supplier Reports menu I choose: UPCs and Registrations (Retailer Specific)
	Then In the Supplier Reports screen the current sub-page should be: UPCs and Registrations (Retailer Specific)
	Given In the Supplier Reports screen I click on the Download button
	Given I click on close in the Report Download dialog
	Given I confirm that an excel file is produced called UPCs and Registrations (Retailer Specific).xlsx and save as 73082
	Then I confirm that in the excel file saved as: 73082 for the UPC saved as: UPC876851 there is a 'Y' in the Case Pack column and an Individual UPC listed as: UPC87685
	And I delete the Supplier Report file saved as 73082

Scenario: [NOTINCLUDEDGENERALTEST] TESTCVS Revision to Data Tier Consent Requirements
Then I create a upc number for CVS
Given I create a new supplier products account: (.*) and create a new brand in that account

Scenario: [NOTINCLUDEDGENERALTEST] CVS Revision to Data Tier Consent Requirements

Given I create a new supplier products account: (.*) and create a new brand in that account


Scenario: [NOTINCLUDEDGENERALTEST] TOYNoProductsAcc - CVS Revision to Data Tier Consent Requirements - Toys Don't require Consent Tiers

Given I log in with the account saved in TReVor as: NoProductsAccount
Then In the Products Grid I delete All products
Then For CVS I create a product of type: Health & Beauty (RUCC0392), save it as: CVSHBProduct1 and leave it in New Status
Then I navigate to the Data Consent Tiers Page for CVS
And I Check that The expected data tiers for CVS are present in the Data Consent Tiers Section
Then I navigate to the Homepage and then In the Products Grid I delete All products


Scenario: [NOTINCLUDEDGENERALTEST] HBNoProductsAcc - CVS Revision to Data Tier Consent Requirements health and beauty

Given I log in with the account saved in TReVor as: NoProductsAccount
Then In the Products Grid I delete All products
Then For CVS I create a product of type: Health & Beauty (RUCC0392), save it as: CVSHBProduct1 and leave it in New Status
Then I navigate to the Data Consent Tiers Page for CVS
And I Check that The expected data tiers for CVS are the only ones present in the Data Consent Tiers Section
Then I navigate to the Homepage and then In the Products Grid I delete All products
Then For CVS I create a product of type: Toys (RUCC0388), save it as: CVSToyProduct1 and leave it in New Status 

#now create all other products

Scenario: [NOTINCLUDEDGENERALTEST] DebugNoProductsAcc - CVS Revision to Data Tier Consent Requirements health and beauty

Given I log in with the account saved in TReVor as: NoProductsAccount
Then In the Products Grid I delete All products
Then For CVS I create a product of type: Toys (RUCC0388), save it as: CVSToyProduct1 and leave it in New Status 


		              









