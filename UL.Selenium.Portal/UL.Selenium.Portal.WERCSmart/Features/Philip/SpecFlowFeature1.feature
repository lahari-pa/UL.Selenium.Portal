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
@ProductGrid
@Shared
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
@Portal_ULSC
@ULSC
@Shared
@run_Transportation

Feature: ChooseGoodGuide.com Scenarios



#Scenario:[87914] Create BCP (Camera with battery) -  with Case UPC - process to  Completed
#	Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
#	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
#	And I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Camera w/Battery
#	Then I generate a random UPC number and save as: UPC87914
#	Then I save the product information as: TestCase87914
#	Given I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
#	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
#	Given I call Shared Step 48367 (Product Includes Battery > any type)
#	Given I set the Indicate how battery is packaged option to: The battery is shipped with but not included in my product.
#	| Battery Type | Manufacturer | Number of batteries per package | How many batteries required to run |
#	| Alkaline     | <any>        | 4                               | 2                                  |
#	Given I call Shared Step 104083 Toxicity Characteristics Leaching Procedure TCLP - NO to ALL - NO COPPER LISTED
#	Given I call Shared Step 58189 (Answer Electronic Equipment questions - With Cathode Ray - No to all)
#	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Staples
#	Then I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC87914, container type: Plastic Container and size: 10.00
#	#Given in the Additional Documents to Provide page I click Continue
#	#Given in the Other Product Document Uploads page I click Continue
#	Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: User added Comments Text 58759. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
#	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Servers, Small-Scale
#	Given In the Data Acceptance page I click on the Accept button
#	Given I navigate to the home page
#	Given I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase87914
#	And I call Shared Step 65080 (Login to Studio and Open SHA manager)
#	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase87914)
#	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase87914 and its status is: Submitted
#	Given I call Shared Step 75309 (SHA > Select Product > UPC Retailer and Feed) for product saved as: TestCase87914
#	Then In the SHA list of UPCs I should see UPC: saved as UPC87914
#	And In the list of UPCs I should see case pack indicatior for UPC: saved as UPC87914
#	#Close UPC Popup
#	Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase85982)
#	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase87914)
#	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase87914 and its status is: Assigned
#	And I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase87914)
#	And I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase87914)
#	And I call Shared Step 78877 - WPS Studio - PD+ - set all data and publish using rule and doc queue - CKLT, NGHS, HSGH (EN and CF) and SBCS for saved as: TestCase86187
#	And I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase86187)
#	Given I call Shared Step 59066 (Go to SHA Manager)
#	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase86187)
#	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase86187 and its status is: Completed




	Scenario: [26827] Pesticide Data - EPA Expiration date validation (Massachusetts - June 30th no more than 1 year out)
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I generate a random UPC number and save as: UPC26827
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Chalk
	Then I save the product information as: TestCase26827
	Given I call Shared Step 26897 (Product Characteristics - Solid only available - continue)
	Given I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	And I call Shared Step 29181 (Ingredients - add any chemical) with name: Water
	And I call Shared Step 132370 (Waste Classification Data - TSCA (Random) - Prop 65 (No) - Continue - Happy Path)
	Given I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue) for
		| Retailer |
		| CVS      |
	Given I call Shared Step 87647 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC26827, container type: Plastic Container and size: 12 do not click continue
	And I click continue
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
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase26827)
	Then I call Shared Step 134404 (SHA > Select Product > UPC Assessment Details) for product saved as: TestCase26827
	Then I check for the following columns in UPC Retailer and Feed
	| Column Name |
	| UPC Number  |
	| Container   |
	| Size        |
	| WeightSize  |
	| Fluid Size  |
	| Added       |
	| Archived    |
	| My Pkg ID   |
	| CasePack    |
	| Qty In Case |
	| NEM         |
	Then I check that the following sections contain the corresponding titles: 
	| Column Name     | Section |
	| UN              | 12      |
	| HazClass        | 13      |
	| Pkg Group       | 14      |
	| Ltd Qty         | 15      |
	| DOT Pkging Code | 16      |
	| Exception       | 17      |
	| Sp Permit       | 18      |

Scenario: [87271] US & Canada - PL = Yes, Retailer is NOT Canadian Tire, no error re package type on forward
Given I create a Completed product using Test Case 86187 (SOLD = US and Canada, PL = Yes, Canadian Tire Retailer Product)
Given I navigate to the landing page
#Given I call Shared Step 85328 (Login to WERCSmart - Canada - Address (Yes), Packaging (Yes), Stewardship (Full))
Given I attempt to log in with email: CanadaHasPackandPartialStewardship.kxxyxunf@mailosaur.io and password: Thewercs1!1030
Given I filter the products by: Accepted by Retailers
Given I search for the product saved as: TestCase86187
And I Confirm the Products shown display the Green Colour Status - which is the Accepted by Retailers
And I call Shared Step 75130 - Bulk Actions - Select Forward Product Registration
And I enter the text: saved as TestCase86187 in the 'Search by WPS ID or Product Name' field
And In the Foward Product Registration Screen I should see product: saved as TestCase86187
And In the Foward Product Registration Screen I Select the product: saved as TestCase86187
And I click continue on the Forward Product Registration page
And In the Forward Product Registration Screen I select the first retailer that does not require additional data and is not: Canadian Tire under Other Retailers and save it as: retailer87217
And I click continue on the Forward Product Registration page
And If the Private Label textbox is showing in the Select UPCs screen, I enter the value: N/A
And I call Shared Step 86824 (Forwarding - Select Existing UPC, Click Continue, No error for Package type)
And I should see the subheading 3: Product Results on the Forward Product Registration window
And I click continue on the Forward Product Registration page
And I should see the subheading 3: Review & Submit on the Forward Product Registration window
And I select the true radio for the 'Are Statements True' question under the Review and Submit tab
And I click continue on the Forward Product Registration page
And In the Purchase Summary screen I confirm the Purchase Summary header is displayed
Then In the Thank You screen I confirm the following statement is shown: Thank you for registering your product on WERCSmart for assessment.
And I navigate to the home page


Scenario: [56086] US & Canada - PL = Yes, Retailer is NOT Canadian Tire, no error re package type on forward


Scenario: [philip123] The Product - Industrial Category not available for Selection

Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
And I should see the The Product Page
And I set the Product Name as it a appears on the Package Label field to: Chalk
And I set 'Type of Product' to: For Industrial use only
Then I confirm the product type field displaying the following results
| Results          |
| No results found |
And I set 'Type of Product' to: Laboratory use only
Then I confirm the product type field displaying the following results
| Results          |
| No results found |
And I set 'Type of Product' to: For Industrial use only
Then I confirm the product type field displaying the following results
| Results          |
| No results found |
And I set 'Type of Product' to: Pharmaceutical use only
Then I confirm the product type field displaying the following results
| Results          |
| No results found |
And I set 'Type of Product' to: Profession use only
Then I confirm the product type field displaying the following results
| Results          |
| No results found |
And I set 'Type of Product' to: Research and Development use only
Then I confirm the product type field displaying the following results
| Results          |
| No results found |


Scenario: Select Retailers - Removing Retailer(s) Selected

Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): chalk
Given I call Shared Step 26897 (Product Characteristics - Solid only available - continue)
Given I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
Given I add the following ingredients:
| ComponentName | Percent | PublicallyDisclosed | PublicName | TradeSecret |
| calcium       | 100     |                     |            |             |
And I call Shared Step 132370 (Waste Classification Data - TSCA (Random) - Prop 65 (No) - Continue - Happy Path)
Given I select the following retailers in the Select Retailers popup list view:
| Retailer              |
| cvs                   |
| dollar general        |
| Family Dollar         |
| Dick's Sporting Goods |
| Amazon                |
| Best Buy              |
Given I click Done in the Select Retailers popup
And The selected retailers on the Retailer page should be:
| Retailer              |
| cvs                   |
| dollar general        |
| Family Dollar         |
| Dick's Sporting Goods |
| Amazon                |
| Best Buy              |
Given I click continue then if the 'UPCs Warning' popup is displayed I click 'OK'
Given in the Regulatory Documents to Provide page I click Continue
Then I select the following retailers in the Retailer page
| Retailers      |
| CVS            |
| Dollar General |
Then I click the delete icon in the Retailer page
Given I click the 'Add Retailers' button
And The selected retailers on the Retailer page should be:
| Retailer              |
| Family Dollar         |
| Dick's Sporting Goods |
| Amazon                |
| Best Buy              |
Then The following retailers in the Select Retailers popup list view should be selected
| Retailers             |
| Family Dollar         |
| Dick's Sporting Goods |
| Amazon                |
| Best Buy              |
Given I click Done in the Select Retailers popup
Given I click continue
And I click the 'Add UPC' button
And I confirm that retailer "CV" is not present under the 'Destination Retailers' column in the UPC table
And I confirm that retailer "DG" is not present under the 'Destination Retailers' column in the UPC table
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase





Scenario: [133335] Formulation Screen FIFRA and LOLI Validation Message

Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561a (The Product - Enter Product Name: Pesticide Testing Product and select Type of Product): Insecticide - Fogger
Then I save the product information as: TestCase133335
	And I set the Primary Physical State option to: Aerosol
	And I set the Secondary Physical State option to: Liquid spray
	And I check the 'I do not have exact' checkbox for field: pH
	And I set the pH option to: 4 - 6.9 
	And I set the When the product has a flammable propellant, or contains ingredients with a flash point below 60⁰C then option to: This product is not classified as D001 or D003 Hazardous Waste under RCRA
	And in the New Product page I click Continue
	# Additional Product Information page
	And I should see the Additional Product Information Page
	Given I call Shared Step 105379 Additional Product Information - US, Pesticide No, No OSHA, No DSV, No PL, No GNFR Without Child question
	# Ingredient Page
	And I should see the Ingredients Page
	Then I add the following ingredients:
		| ComponentName			     	| Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Glutens, corn    | 50      | false               | false       |            |
		| Butane             | 0.1     | false               | false       |            |
		| Oils, cedarwood, Texan    | 49.9    | false               | false       |            |
	Given in the New Product page I click Continue
	Then I confirm there is a popup video titled: Product Contains Ingredients Typical of a Pesticide in the Ingredients page
	Then In the popup view with the following title: Product Contains Ingredients Typical of a Pesticide I confirm I see the following statement in the popup view: You've indicated the product is not a pesticide under the EPA's Federal Insecticide and Rodenticide Act (FIFRA). The product type is typically considered a pesticide, and there are ingredients present in the registration that are known to be used in Pesticide products.' expected 'You've indicated the product is not a pesticide under the EPA's Federal Insecticide and Rodenticide Act (FIFRA). The product type is typically considered a pesticide, and there are ingredients present in the registration that are known to be used in Pesticide products.
	Then I confirm the table in the popup view has the following column titles
	| Titles          |
	| CAS Number      |
	| Name            |
	| Active or Inert |
	Then I confirm the table in the popup view has following column data
	| CAS Number | Name                   | Active or Inert |
	| 66071-96-3 | Glutens, corn          | Active          |
	| 68990-83-0 | Oils, cedarwood, Texan | Active          |
    Then In the popup view with the following title: Product Contains Ingredients Typical of a Pesticide I confirm I see the following statement in the popup view: If you need to revise your selection for Pesticides, please use the Product Type tab and go to the Additional Product Information section to make your revisions. Or, revise your ingredient information, ensuring accuracy. Should all indications and ingredients be correct and the product is not a pesticide, please indicate below.
	Then I confirm I see a checkbox in the popup view with the following text: The Product Type, Pest Selection, and Ingredients listed are accurate.
	Then In the popup view with the following title: Product Contains Ingredients Typical of a Pesticide I confirm I see the following buttons in the popup view:
	| Button  |
	| Go back |
	| Confirm |

	## Regulatory 1 Page Details
	#And I should see the Regulatory Information 1 Page
	#And I set the U.S. Toxic Substances Control Act (TSCA) status option to: Compliant
	#And I set 'Prop65' to: No
	#Given in the New Product page I click Continue
	## Transportation Details 1 Page
	#And I should see the Transportation Details 1 Page
	#And I set the Product is Regulated for Transport option to: Yes
	#And I set the below options for field: Select all modes of transport that you've classified the product for
	#	| Option                           |
	#	| DOT                              |
	#	| Shipping with limited quantity   |
	#	| Shipping with consumer commodity |
	#Given in the New Product page I click Continue
	## U. S. Department of Transportation (DOT) Classification Page
	#Then I should see the U. S. Department of Transportation (DOT) Classification Page
	#And I set the UN Number field to: UN1950
	#And I set the Proper Shipping Name field to: Aerosols
	#And I set the Technical Name (if applicable) field to: Clear Coating - Aerosol
	#And I set the Hazard Class (select) field to: 2.1
	#And I set the Packing Group (select) field to: None
	#Given in the New Product page I click Continue
	## Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB) Page
	#And I should see the Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB) Page
	#Then I see the following questions
	#	| Section                                                                                                                                        |
	#	| Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations. |
	#	| VOC content in grams ozone per gram                                                                                                            |
	#And I set the Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations. option to: No
	#And in the New Product page I click Continue
	#Then VOC content in grams ozone per gram should be showing the error messages: This is a required field.
	#And I set the VOC content in grams ozone per gram field to: 0.5
	#And in the New Product page I click Continue
	## Volatile Organic Compound Summary page
	#And I should see the Volatile Organic Compound Summary Page
	#And I confirm that I see todays VOC Analysis Date
	#And I confirm that I see the bold VOC-OTC-CARB Compliance Limits statement: Based on your selection, you have verified your product contains VOC with intended uses as follows. The Aerosol Coatings by the CARB VOC compliance limit(s) for the intended use you identified is/are:
	#And I should see the following Voc Limits present:
	#	| Use                     | VOC Compliance Limit | Regulation                  |
	#	| Clear Coating - Aerosol | 0.85                 | Aerosol Coatings CARB limit |
	#And I confirm that I see the following VOC Grams Ozone value: 0.5
	#And I confirm statement: limits specified shows the text: Does not exceed the limits specified in the Aerosol Coatings by the CARB
	#And I confirm statement: Based on the type of product shows the text: Based on the type of product, this must comply with the most restrictive VOC limit.
	##change the VOC grams value
	#Then I click the page heading: Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB)
	#And I set the VOC content in grams ozone per gram field to: 1
	#And in the New Product page I click Continue
	#And I confirm statement: limits specified shows the text: Exceeds the limits specified in the Aerosol Coatings by the CARB
	#And in the New Product page I click Continue
	#Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	## Regulatory Documents to Provide Page
	#And I should see the Regulatory Documents to Provide Page
	#And in the Review and Submit tab of the New Product Page for OSHA compliant SDS I select: Request to author
	#And in the New Product page I click Continue
	## Additional Documents to Provide Page
	#And I should see the Additional Documents to Provide Page
	#And in the New Product page I click Continue
	#Then Volatile Organic Compounds should be showing the error messages: Document is required: Product Label
	#And I click the browse button for label: Product Label and upload PDF: C:\Dependencies\WERCSmart\testdoc.pdf
	#And in the New Product page I click Continue
	## Optional Reports and Documents Available for Purchase Page
	#And I should see the Optional Reports and Documents Available for Purchase Page
	#And in the New Product page I click Continue
	## Safety Data Sheet Authoring - Additional Data (Optional) Page
	#And I should see the Safety Data Sheet Authoring - Additional Data (Optional) Page
	#And I set the Appearance field to: Brown
	#And I set the Odor field to: Banana
	#And I set the Odor Threshold field to: Not applicable
	#And I set the Partition Coefficient field to: 5
	##And in the New Product page I click Continue
	##Then Product's Dispensing Method should be showing the error messages: This is a required field.
	#And I set the Product's Dispensing Method field to: Pump
	#And in the New Product page I click Continue
	## Comments Page
	#And I should see the Comments Page
	#And in the New Product page I click Continue
	## Data Acceptance Page and clean up
	#And I should see the Data Acceptance Page
	#Given I navigate to the home page
	#Then I delete the product: TestCase133335

# In the 'Additional Product Information Page'
# CONFIRM the 'Additional Product Information Page' displays the Question "Which one best describes your product"
# Select the Radio Button Option - "Product is not considered a pesticide product"
# CONFIRM that by default the "United States" checkbox is selected
# Select 'NO' for the rest of the questions listed in the 'Additional Product Information Page'
# Click 'CONTINUE'
# In the 'INGREDIENTS SCREEN' enter the following CAS Numbers
# 66071-96-3 - Glutens, corn @ 50%
# 106-97-8 - Butane @ 0.1%
# 68990-83-0 - Oils, Cedarwood, Texan @ 49.9%
# Click 'CONTINUE'
# CONFIRM that you are prompted with the 'PRODUCT CONTAINS INGREDIENTS TYPICAL OF A PESTICIDE' Message Box
# CONFIRM that the following statement displays on the top of the message box:  You've indicated the product is not a pesticide under the EPA's Federal Insecticide and Rodenticide Act (FIFRA). The product type is typically considered a pesticide, and there are ingredients present in the registration that are known to be used in Pesticide products.
# CONFIRM that the middle section of the message box contains the following Component Table Columns:  CAS NUMBER / NAME OF COMPONENT / and 'ACTIVE OR INERT'
# CONFIRM that the CAS Numbers of the Components you used, display in this message window.
# CONFIRM that the Name of the Components you used, display in this message window.
# CONFIRM that the each Component is marked as 'ACTIVE'
# CONFIRM that below the Component Table the following statement displays:  If you need to revise your selection for Pesticides, please use the Product Type tab and go to the Additional Product Information section to make your revisions. Or, revise your ingredient information, ensuring accuracy.  Should all indications and ingredients be correct and the product is not a pesticide, please indicate below
# CONFIRM that at the bottom of the message box - You see "The Product Type, Pest Selection, and Ingredients listed are accurate" CHECKBOX
# CONFIRM that at the bottom-right of the message box - The 'GO BACK' and 'CONFIRM' BUTTONS are available
# Click on the 'GO BACK BUTTON'
# CONFIRM that transitions back to the 'INGREDIENTS PAGE'
# CONFIRM that you see a message in RED FONT that states the following:  Exclamation Point! You must either confirm that your product is not a pesticide, change your product details to confirm that it is a pesticide, or change your ingredients to remove the pesticide ingredients.
# Do not make any changes to the Components - leave them as is
# Click 'CONTINUE'
# CONFIRM you are prompted with the 'Product Contains Ingredients Typical of a Pesticide' Message Box
# Place a check mark on the 'The Product Type, Pest Selection, and Ingredients listed are accurate' Checkbox
# Click on the CONFIRM BUTTON
# Transitions to the 'WASTE CLASSIFICATION DATA PAGE'
# Click again on the 'INGREDIENTS EDIT LINK'
# CONFIRM it transitions back to the INGREDIENTS PAGE
# Click 'CONTINUE'
# CONFIRM that you are not prompted again with the 'Product Contains Ingredients Typical of a Pesticide' Message Box
# Once the checkbox 'The Product Type, Pest Selection, and Ingredients listed are accurate' checkbox is checked the message box in the Ingredient Screen will no longer showGiven I click the Home navigation icon
Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: Pesticide Testing Product





Scenario: [133311] Retailer Private Label List Appear in Alphabetical Order

Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): chalk
Given I call Shared Step 74760 (Product Characteristics - Select Liquid as primary physical state and enter all required data)
| Primary Physical State | Secondary Physical State | Specific Gravity | pH | Boiling Point (in Celsius) | Flash Point (in Celsius) | Flash Point Testing Method Used | Select the best Water Solubility description |
|  Liquid                | Liquid                   | 20               | 2   | 2                           | 66                         |  Closed cup method         | Appreciable                                  |

Given I call Shared Step 63860 (Additional Product Information - US, No(child), No(OSHA), No(DSV), Yes(PLP), No(GNFR))
Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
| CASNumber | ComponentName | Percent | PublicallyDisclosed | PublicName | TradeSecret |
|           | calcium       | 100     |                     |            |             |
Given I call Shared Step 132370 (Waste Classification Data - TSCA (Random) - Prop 65 (No) - Continue - Happy Path)
Then In the 'Select Retailers' window I select the retailer: Albertsons Companies
Then In the 'Select Retailers' window I select the retailer: Wal-Mart/SAM'S CLUB
#Then I confirm that the product names from the drop down for: Indicate full name of product, as sold, via this retailer (e.g. Private Label Aspirin) for Albertsons Companies appear in alphabetical order
#Then I confirm that the product names from the drop down for: Indicate full name of product, as sold, via this retailer (e.g. Private Label Aspirin) for Wal-Mart/SAM'S CLUB appear in alphabetical order





Scenario: [127767]Register a Cleaning Supplies - Bleach Product Type for a verification of the Products in Scope Report for Bed Bath and Beyond
Then I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
Then I call Shared Step 57408 (Create a New Registration via Register New Product icon)
Given I generate a random UPC number and save as: UPC804879551225
Then I call Shared Step 57561a (The Product - Enter Product Name: Cleaning Supplies Product for BBB and select Type of Product): Bleach
Given I set the Primary Physical State option to: Liquid
And I check the 'I do not have exact' checkbox for field: Flash Point (in Celsius)
And I check the 'I do not have exact' checkbox for field: Boiling Point (in Celsius)
Given I set the Secondary Physical State option to: Liquid
Given I set the Specific Gravity option to: 0.1
Given I set the pH option to: 11.5
Given I set the Boiling Point (in Celsius) option to: Not tested/Unknown
Given I set the Flash Point (in Celsius) option to: None, No Flash Point
Given I set the Select the best Water Solubility description option to: Soluble in water
Given I click continue
Given I click continue
Then I call Shared Step 105379 Additional Product Information - US, Pesticide No, No OSHA, No DSV, No PL, No GNFR Without Child question
Then I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
      	| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Propane       | 100     | false               | false       |            |
Then I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
Then I call Shared Step 57507 (Transportation Details 1- Not Regulated - Continue - Happy Path)
Then In the 'Select Retailers' window I select the retailer: Bed Bath and Beyond (including Harmon, Buy Buy Baby, and Christmas Tree Shops)
Given I click continue
Then I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC804879551225, container type: Plastic Container and size: 3.5
Then I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
Given I click continue
Given I click continue
Given I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
		| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
Then I call Shared Step 57883 (Comments - Happy Path) and enter the comment: «comments»
Then I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
Then I call Shared Step 130558 (Go to Retail Partners - Select Bed Bath and Beyond)
Then I click the Products in Scope button and confirm that a file is produced called BB_Report_DataUsageTier_Current_Month_Day_Year.xlsx and save as Products in Scope Report for BBB
#Then I confirm the excel file saved as: Products in Scope Report for BBB contains the following data: Cleaning Supplies Product for BBB
Then I delete the excel file saved as Products in Scope Report for BBB
