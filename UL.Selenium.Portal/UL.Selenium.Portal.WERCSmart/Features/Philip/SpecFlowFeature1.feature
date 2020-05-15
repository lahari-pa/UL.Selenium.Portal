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
@ProductSetUp
@SHA
@Studio
@ForwardProductRegistration
@ProductSetUp
@SupplierReports
@CreateProducts
@ViewUpcs
@Solutions
@run_NotIncludedGeneralTests
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
@ProductSetUp
@SHA
@Studio
@ForwardProductRegistration
@ProductSetUp
@SupplierReports
@CreateProducts
@ViewUpcs
@Solutions
@run_NotIncludedGeneralTests
@Shared
@NewProduct
@Homepage
@Shared
@wercsmart
@Login
@UlSolutionCenter
@Homepage
@ProductGrid
@ForwardProductRegistration
@NewProduct
@RetailPartners
@MessageCenter
@MyAccount
@LandingPage
@DocumentAcceptance
@DeleteActiveProducts
@Solutions
@UPC
@ReviewDocuments
@SHA
@MyMessages
@run_MyMessages
@Shared
@wercsmart
@Login
@UlSolutionCenter
@Homepage
@ProductGrid
@ForwardProductRegistration
@NewProduct
@RetailPartners
@MessageCenter
@MyAccount
@LandingPage
@DocumentAcceptance
@DeleteActiveProducts
@Solutions
@UPC
@ReviewDocuments
@SHA
@MyMessages
@run_MyMessages
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
@PaymentMethods
@SHA
@CreateProducts
@Studio
@ProductSetUp
@run_Transportation

Feature: ChooseGoodGuide.com Scenarios



Scenario:[87914] Create BCP (Camera with battery) -  with Case UPC - process to  Completed
	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	And I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Camera w/Battery
	Then I generate a random UPC number and save as: UPC87914
	Then I save the product information as: TestCase87914
	Given I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given I call Shared Step 48367 (Product Includes Battery > any type)
	Given I set the Indicate how battery is packaged option to: The battery is shipped with but not included in my product.
	| Battery Type | Manufacturer | Number of batteries per package | How many batteries required to run |
	| Alkaline     | <any>        | 4                               | 2                                  |
	Given I call Shared Step 104083 Toxicity Characteristics Leaching Procedure TCLP - NO to ALL - NO COPPER LISTED
	Given I call Shared Step 58189 (Answer Electronic Equipment questions - With Cathode Ray - No to all)
	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Staples
	Then I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC87914, container type: Plastic Container and size: 10.00
	#Given in the Additional Documents to Provide page I click Continue
	#Given in the Other Product Document Uploads page I click Continue
	Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: User added Comments Text 58759. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Servers, Small-Scale
	Given In the Data Acceptance page I click on the Accept button
	Given I navigate to the home page
	Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase87914
	And I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase87914)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase87914 and its status is: Submitted
	Given I call Shared Step 75309 (SHA > Select Product > UPC Retailer and Feed) for product saved as: TestCase87914
	Then In the SHA list of UPCs I should see UPC: saved as UPC87914
	And In the list of UPCs I should see case pack indicatior for UPC: saved as UPC87914
	#Close UPC Popup
	Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase85982)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase87914)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase87914 and its status is: Assigned
	And I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase87914)
	And I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase87914)
	And I call Shared Step 78877 - WPS Studio - PD+ - set all data and publish using rule and doc queue - CKLT, NGHS, HSGH (EN and CF) and SBCS for saved as: TestCase86187
	And I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase86187)
	Given I call Shared Step 59066 (Go to SHA Manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase86187)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase86187 and its status is: Completed

Scenario:[93366] My Products - Bulk Actions Multiple Deletion of Registrations
Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Given I click Bulk Actions in the Products Grid
	And I click Delete Products in the Bulk Actions window
	And I should see the header: Delete Active Products on the Delete Active Product window
	Then I select the checkbox next to WPS ID in the Delete Active Products page
	Then I confirm all checkboxes are selected in the Delete Active Products page
	Then I deselect the checkbox next to WPS ID in the Delete Active Products page
	Then I confirm all checkboxes are deselected in the Delete Active Products page
	Then I select random products checkbox and save as: selectedProducts
	Then I click on the Make Obsolete button
	Then I select the checkbox in the Make Obsolete popup
	Then In the Make Obsolete popup I click on the Cancel button
	Then I click on the Make Obsolete button
	Then I select the checkbox in the Make Obsolete popup
	Then In the Make Obsolete popup I click on the Accept button
	Then I make sure products saved as: selectedProducts are missing from the product list


Scenario:[88826] My Products - Bulk Actions Multiple Deletion of Registrations
Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk
	Then I save the product information as: TestCase88826
	Then I generate a random UPC number and save as: UPC88826
	Given I call Shared Step 26897 (Product Characteristics - Solid only available - continue)
	Given I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
	| CASNumber | ComponentName       | Percent | PublicallyDisclosed | PublicName | TradeSecret |
	|           | Water               | 100     | false               |            | false       |
	And I call Shared Step 132370(Waste Classification Data - TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	And In the 'Select Retailers' window I select the retailer: CVS
	And I click continue
	And I call Shared Step 85909 (UPC - Confirm Package type link and drop down not shown - Add UPC data - Continue) for UPC: saved as UPC88826, container type: Plastic Container and size: 12 click continue
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Then in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I navigate to the home page
	Given I click Bulk Actions in the Products Grid
	And I click Delete Products in the Bulk Actions window
	And I should see the header: Delete Active Products on the Delete Active Product window
	Then In the Delete Active Products page I search for WPS ID saved as: TestCase88826
	Then In the Delete Active Products page I click the Filter button
	Then I make sure product saved as: TestCase88826 should not missing from the product list
	Then I select checkbox for product saved as: TestCase88826  
	Then I click on the Make Obsolete button
	Then I select the checkbox in the Make Obsolete popup
	Then In the Make Obsolete popup I click on the Accept button
	Then In the Delete Active Products page I search for WPS ID saved as: TestCase88826
	Then In the Delete Active Products page I click the Filter button
	Then I make sure product saved as: TestCase88826 should missing from the product list
	Given I navigate to the home page
	#Given I search for the product saved as: TestCase88826
	#Confirm product not shown


Scenario: [132756] Canadian Province Pesticide Options

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Given I generate a random UPC number and save as: RandomUPC
Given I delete all products with UPC Number: RandomUPC
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Bleach
Given I save the product information as: TestCase
Given I call Shared Step 74760 (Product Characteristics - Select Liquid as primary physical state and enter all required data)
| Boiling Point (in Celsius) | Flash Point (in Celsius) | Flash Point Testing Method Used | pH | Primary Physical State | Secondary Physical State | Select the best Water Solubility description | Specific Gravity |
| 2                          | 66                       | Closed cup method               | 2  | Liquid                 | Liquid                   | Appreciable                                  | 2                |
Given I call Shared Step 1234 (Additional Product Information - YES to pesticide - Canada only, No OSHA, No Direct Ship, - Continue - Happy Path)
Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
| CASNumber | ComponentName | Percent | PublicallyDisclosed | PublicName | TradeSecret |
| 74-98-6   | Propane       | 100     | false               |            | false       |
Given I call Shared Step 133277(Waste Classification Data - CEPA(Random) - Prop 65(No) - Continue - Happy Path)
Then I should see the Pesticide Details - Canada Page
Then I check the options in the dropdown menus for the following sections
| Section                    | Options                                                                                                                                                                                                                              |
| Alberta                    | None,Schedule 1,Schedule 2,Schedule 3,Schedule 4                                                                                                                                                                                 |
| British Columbia           | None,Permit Restricted,Restricted,Commercial,Domestic,Excluded                                                                                                                                                                  |
| Manitoba                   | None,Commercial,Controlled Purchase,Not Regulated,Restricted,Self-Select                                                                                                                                                        |
| New Brunswick              | None,Banned,Domestic / Self-Select,Non-Domestic                                                                                                                                                                                   |
| New Foundland and Labrador | None,Banned,Domestic,Commerical,Restricted                                                                                                                                                                                       |
| Nova Scotia                | None,Allowed / Self-Select,Banned,Commercial,Controlled Purchase,Restricted,Not Regulated                                                                                                                                      |
| Ontario                    | None,Class A: Manufacturing Products,Class B: Restricted,Class C: Commercial,Class D: Domestic with License,Class D: Domestic without License,Class D: Domestic Controlled Purchase Requiring a License,Class E: Treated Seed |
| Prince Edward Island       | Banned,Controlled Purchase,Exempt: Schedule 2,Exempt: Schedule 7,Non-Domestic,None,Self-Select: Schedule 8                                                                                                                     |
| Quebec                     | None,Class 1,Class 2,Class 3,Class 3A,Class 4,Class 5,Banned                                                                                                                                                                 |
| Saskatchewan               | None,Commercial,Restricted                                                                                                                                                                                                         |
| Northwest Territory        | Not Applicable                                                                                                                                                                                       |
| Yukon Territory            | None,Commercial,Domestic,Restricted                                                                                                                                                                                               |


Scenario: [133161] Fertilizer - P, N, or K question

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Fertilizer
Given I call Shared Step 74760 (Product Characteristics - Select Liquid as primary physical state and enter all required data)
| Boiling Point (in Celsius) | Flash Point (in Celsius) | Flash Point Testing Method Used | pH | Primary Physical State | Secondary Physical State | Select the best Water Solubility description | Specific Gravity |
| 2                          | 66                       | Closed cup method               | 2  | Liquid                 | Liquid                   | Appreciable                                  | 2                |
Given I should see the Additional Product Information Page
Given I set the Does the product contain fertilizer (P, N or K)? option to: No
#Ensure not options
Given I set the Does the product contain fertilizer (P, N or K)? option to: Yes
Then I should see the PNK section title in the Additional Product Information with the following text: Provide the amount (Percent) of each of the following within the product
Then I check if input field for the following section exists: Phosphates /Phosphorous (“P”)
Then I check if input field for the following section exists: Nitrogen /Nitrates (“N”)
Then I check if input field for the following section exists: Potassium(“K”)
Then I enter the following text: 1000000 for the input field in the following section: Phosphates /Phosphorous (“P”)
Then I enter the following text: 10.1232123 for the input field in the following section: Nitrogen /Nitrates (“N”)
Then I enter the following text: 100 for the input field in the following section: Potassium(“K”)
Then I click continue
And Phosphates /Phosphorous (“P”) should be showing the error messages: Invalid number. 3 total spaces maximum and 2 decimal place
And Nitrogen /Nitrates (“N”) should be showing the error messages: Invalid number. 3 total spaces maximum and 2 decimal place
And Potassium(“K”) should not be showing the error messages: Invalid number. 3 total spaces maximum and 2 decimal place
Then I enter the following text: 35.24 for the input field in the following section: Phosphates /Phosphorous (“P”)
Then I enter the following text: .05 for the input field in the following section: Nitrogen /Nitrates (“N”)
And Phosphates /Phosphorous (“P”) should not be showing the error messages: Invalid number. 3 total spaces maximum and 2 decimal place
And Nitrogen /Nitrates (“N”) should not be showing the error messages: Invalid number. 3 total spaces maximum and 2 decimal place
And Potassium(“K”) should not be showing the error messages: Invalid number. 3 total spaces maximum and 2 decimal place


Scenario: [100980] Regulatory Documents to Provide - US and Canada - upload all documents > Continue
    Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Given I generate a random UPC number and save as: UPC120866
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk
	Then I save the product information as: TestCase120866
	Given I call Shared Step 26897 (Product Characteristics - Solid only available - continue)
	Given I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	And I call Shared Step 29181 (Ingredients - add any chemical) with name: Water
	And I call Shared Step 132370(Waste Classification Data - TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given I call Shared Step 74201 (Select Retailers - CVS)
	And I click continue
	And I call Shared Step 85909 (UPC - Confirm Package type link and drop down not shown - Add UPC data - Continue) for UPC: saved as UPC120866, container type: Plastic Container and size: 12 click continue
	And I set the OSHA-compliant Safety Data Sheet, English field to: Request to author


Scenario: [130389] Demo Scenario
Then I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
Then I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Then I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
Then I save product Product to context as TestCase

Scenario: [128754] BCP Product - Family Dollar and Dollar Tree Retailers Available for selection

Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
Then The home screen should load
Given I generate a random UPC number and save as: UPC60643
Given I delete all products with UPC Number: saved as UPC60643
Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Camera w/Battery
Then I save the product information as: TestCase60643
Given I call Shared Step 70393 (Additional Product Information - With marketed for use by a Child - Direct Ship - Private Label questions only)
And I call Shared Step 132370(Waste Classification Data - TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Given I call Shared Step 48367 (Product Includes Battery > any type)
| Battery Type | How many batteries required to run | Manufacturer | Number of batteries per package |
| Alkaline     | 6                                  | <any>        | 6                               |
Given I call Shared Step 48369 (Toxicity Characteristics Leaching Procedure (TCLP) - No to ALL With Copper)
And I call Shared Step 58189 (Answer Electronic Equipment questions - With Cathode Ray - No to all)
Given I select the following retailers in the Select Retailers popup list view:
| Retailer												   |
| Dollar Tree Stores, Inc. / Greenbrier International, Inc |
| Family Dollar                                            |
Then I click Done on Select Retailers window
Then I confirm the following retailers are showing in the Retailer page
| Retailer												   |
| Dollar Tree Stores, Inc. / Greenbrier International, Inc |
| Family Dollar                                            |
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase60643

