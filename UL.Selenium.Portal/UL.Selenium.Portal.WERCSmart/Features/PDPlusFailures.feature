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
@run_PDPlusFailures
Feature: PDPlusFailures

#This feature is used to hold copies of scenarios that fail / often fail in PD+. If a scenario found in this feature and has been passing consistently, feel free to remove it from the feature file.

Scenario: [PDPlusFailure] 86452 | Account has Partial Stewardship Data
	Given I log in with the account saved in TReVor as: CanadaHasPackandPartialStewardship
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	And I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Crayon
	Then I save the product information as: TestCase86452
	And I call Shared Step 26897 (Product Characteristics - Solid only available - continue)
	And I call Shared Step 85730 - Additional Product Information - Canada Only - Child (NO), GHS (NO), DSV (NO), PLP(YES), GNFR (NO), Continue
	Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
	And I call Shared Step 57911 (Regulatory Information 1 - CEPA only shown - Continue - Happy Path)
	Given I call Shared Step 86163 - Retailer - Canada Only & PL, Select No Retailer, Add PL, Continue
	And I call Shared Step 78884 - Regulatory Documents to Provide - Canada only - request authoring, upload label - Continue
	Then in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	And I call Shared Step 64097 - Additional Documents -> Contact Information - Add any Name, address, phone and emergency phone - Happy Path
	And I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
		| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
	And I call Shared Step 57883 (Comments - Happy Path) and enter the comment: test
	Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given If purchase details are showing click confirm order	
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase86452)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase86452 and its status is: Submitted
	Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase86452)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase86452)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase86452 and its status is: Assigned
	Given I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase86452)
	Given I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase86452)

	Given I call Shared Step 75347 (WPS Studio - PD+ - set all data and publish using rule and Doc queue - CKLT, NGHS and SBCS) for product saved as: TestCase86452
	#^For the Step "I click Apply", failure was seen because "Spinner is still showing". I have adding much longer waits/timeouts in the method to try fix the issue.
	#If the issue is a failure for the spinner to never go or because an Alert is open and its is failing to click "accept" etc, then we will try a differnt approach. 

	Given I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase86452)
	Given I call Shared Step 59066 (Go to SHA Manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase86452)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase86452 and its status is: Completed

	


Scenario: [PDPlusFailure] 42196 | Flow 12
	
	Given I call Shared Step 67038 (Login into WERCSmart Portal - ULSC Role)

	And I create a product with name: TEST CASE 42196 - 3rd party Recertification while logged in as Portal - ULSC Role and take to completed using Test Case 79428 and save as: TestCase42196
	#^Failing in the Step GivenIClickOnHomeToNavigateBackToEditingSpecificProductSavedAs
	#Increased the wait times

	And I call Shared Step 65080 (Login to Studio and Open SHA manager)
	And I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase42196)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase42196 and its status is: Completed
	And I call Shared Step 80488 - SHA Manager > completed 3rd party > Add to recert 40 for product saved as: TestCase42196
	And In the SHA manager grid I see the WPS ID I have saved as product: TestCase42196 and its font is red indicating a recertification
	Given I navigate to the landing page
	Given I call Shared Step 67038 (Login into WERCSmart Portal - ULSC Role)
	Given I search for the product saved as: TestCase42196
	Given For product saved as: TestCase42196 the status is: Needs Your Attention
	And I click Row Actions for the first product returned
	And I click on the Row Action: Update Required
	And I call Shared Step 55460 - Recertification - ULSC registered > Re-Import data from ULSC service - No - Save for product saved as: TestCase42196
	And I should see the The Product Page
	Then I click Save in The Product Page
	And I should see the Ingredients Page
	And I confirm that you cannot add a new component to the formulation
	And I confirm that you cannot edit the Percentage value for any component shown
	And I confirm that you cannot edit the Is this a trade secret entry for any component shown
	And I confirm the 'Delete' button is not available in the Ingredients table
	And I confirm that you can edit the Publicly Disclosed entry for any component shown
	And I edit the first component to show Yes for Publicly disclosed
	And I edit the first component to select: Choose... from the Public Name drop down and save choice as firstpublicName
	And I edit the first component to show Yes for Publicly disclosed
	And I click Save in The Product Page
	And I confirm that for the first component an error is shown below the Public Name drop down which reads: Please select Public Name since you agreed on Publicly Disclosed
	And I edit the first component to select: Undisclosed Ingredient from the Public Name drop down and save choice as firstnewpublicName
	And I click Save in The Product Page
	And I should see the Formulation Page
	And I click the page heading: Ingredients
	And I edit the first component to show No for Publicly disclosed
	And I click Save in The Product Page
	And I should see the Formulation Page
	And I click the page heading: Ingredients
	And I edit the second component to show Yes for Publicly disclosed
	And I edit the second component to select: <random> from the Public Name drop down and save choice as publicName
	And I click Save in The Product Page
	And I should see the Formulation Page
	And I click Save in The Product Page
	And I click the page heading: Data Acceptance
	And I should see the Data Acceptance Page
	And I click the Summary button in the Data Acceptance window
	And I switch to the Data Summary page
	And In the Data Summary window the second component should have Public Name: saved as publicName and Publicly Disclosed: Yes
	And I close the Data Summary tab
	And I should see the Data Acceptance Page
	And I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given If purchase details are showing click confirm order
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase42196)
	And In the SHA manager grid I see the WPS ID I have saved as product: TestCase42196 and its status is: Recertification
	And I call Shared Step 44240 - SHA - Recertification > process recertification to Assigned status for product saved as TestCase42196
	And I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase42196)
	And I call Shared Step 49742 - WPS - Check In Product saved as: TestCase42196
	And I call Shared Step 79500 (WPS Studio - PD+ - set all data and publish using rule and doc queue - CKLT and SBCS only) for product saved as: TestCase42196
	And I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase42196)
	And I call Shared Step 59066 (Go to SHA Manager)
	And I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase42196)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase42196 and its status is: Completed
	And I navigate to the landing page
	Given I call Shared Step 67038 (Login into WERCSmart Portal - ULSC Role)
	And I search for the product saved as: TestCase42196
	Given For product saved as: TestCase42196 the status is: Completed


@ScenarioId:10361
Scenario: [PDPlusFailures] 118139 | Product Create and Process to Completed

	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I generate a random UPC number and save as: UPC118139
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Floor Wax - Wood
	Then I save the product information as: TestCase118139
	Given I call Shared Step 57501 (Product Characteristics - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue - HP)
	Given In the Additional Product Information Screen I answer the questions as follows - US only - No to GHS - No to shipped supplier - Yes to CA Cleaning - No to Private Label - No to Sold to retailer)
	Given In the Claifornia Cleaning Product Disclosure I choose 'Manufacturer' and select 'No' for CBI, then enter Placeholder Details
	Given I click continue	
	Given I add the following CA Cleaning ingredients:  
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName | GenericName | IngredientType      | FunctionalPurpose             | Clean | Certified |
		| Water         | 100     | false               | true        | AQUA       | AQUA        | Intentionally Added | Abrasive, Absorbent, Adhesive | true  | true      |
	And in the Ingredients page I click Continue
	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given I call Shared Step 57507 (Transportation Details 1- Not Regulated - Continue - Happy Path)
	Given I call Shared Step 57923 (Volatile Organic Compound (VOC) Step - enter OTC and CARB - Yes for state values)
		| Amount of VOC by CARB | Amount of VOC by OTC Model | Product granted Alternative Control Plan | VOC for states |
		| 2                     | 2                          | No                                       | Yes            |
	Given I call Shared Step 57801 (Confirm VOC Summary step shown and VOC analysis date is shown - Happy Path)
	Given I click continue
	Given I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue) for
		| Retailer  |
		| Walgreens |
	Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC118139, container type: Metal Container and size: 32
	Given I set the OSHA-compliant Safety Data Sheet, English option to: Yes
	Given I click the browse button for label: OSHA SDS and upload PDF: UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf
	And I check the checkbox with description: I confirm I am providing the most current Safety Data Sheet (SDS), Article Information Sheet (AIS) and/or Product Label for this registration. I understand I will need to provide a revised document should any changes be made to the registration data or documents in the future.
	Given I click continue
	Given I click the browse button for label: Product Label and upload PDF: UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf
	Given in the Additional Documents to Provide page I click Continue
	Given I click continue
	Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: test
	Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given I call Shared Step 54796 (Purchase Summary)
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase118139)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase118139 and its status is: Submitted

	Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase118139)
	#^Failing on this step, but because of an error on the Process products popup. Possible bug

	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase118139)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase118139 and its status is: Assigned
	Given I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase118139)
	Given I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase118139)
	Given I call Shared Step 75347 (WPS Studio - PD+ - set all data and publish using rule and Doc queue - CKLT, NGHS and SBCS) for product saved as: TestCase118139
	Given I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase118139)
	Given I call Shared Step 59066 (Go to SHA Manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase118139)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase118139 and its status is: Accepted
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Accepted Status for saved as: TestCase118139)
	Given I call Shared Step 51664 (SHA - Accepted Product - set Retailers to Completed for saved as: TestCase118139) for
		| Retailer  |
		| Walgreens |
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase118139)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase118139 and its status is: Completed

Scenario: [PDPlusFailure] 87914 | Product Create and Process to Completed
	Given I log in with the account saved in TReVor as: ProductAccount
	Given I generate a random UPC number and save as: UPC87914
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Camera w/Battery
	Then I save the product information as: TestCase87914
	Given I call Shared Step 70393 (Additional Product Information - With marketed for use by a Child - Direct Ship - Private Label questions only)
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I call Shared Step 48367 (Product Includes Battery > any type)
		| Battery Type | Manufacturer | Number of batteries per package | How many batteries required to run |
		| Alkaline     | <any>        | 6                               | 6                                  |
	Given I call Shared Step 48369 (Toxicity Characteristics Leaching Procedure (TCLP) - No to ALL With Copper)
	Given I call Shared Step 58189 (Answer Electronic Equipment questions - With Cathode Ray - No to all)
	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Amazon
	Given I call Shared Step 87641(Enter Universal Product Code - case information) for UPC: saved as UPC87914, container type: Paper bag and size: 2 and Quantity: 4 and Transportation option: random
	Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: test data
	Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given If purchase details are showing click confirm order
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase87914)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase87914 and its status is: Submitted

	Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase87914)
	#^Appears that the test is porcessing the product data and it ends in accepted not assigned.
	
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase87914)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase87914 and its status is: Assigned
	Given I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase87914)
	Given I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase87914)
	Given I call Shared Step 75347 (WPS Studio - PD+ - set all data and publish using rule and Doc queue - CKLT, NGHS and SBCS) for product saved as: TestCase87914
	Given I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase87914)
	Given I call Shared Step 59066 (Go to SHA Manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase87914)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase87914 and its status is: Accepted
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Accepted Status for saved as: TestCase87914)
	Given I call Shared Step 51664 (SHA - Accepted Product - set Retailers to Completed for saved as: TestCase87914) for
		| Retailer |
		| Amazon   |
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase87914)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase87914 and its status is: Completed



@ScenarioId:10493
Scenario: [75335c] Create a new simple product (Chalk) and submit thru to Completed status (NGHS only)	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account) (Removed Steps Updated)
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I generate a random UPC number and save as: UPC75335
	Given I delete all products with UPC Number: saved as UPC75335
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
	Then I save the product information as: TestCase75335
	Given I call Shared Step 26897 (Product Characteristics - Solid only available - continue)
	Given I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Sodium hydroxide
	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given I call Shared Step 75146 (Retailer - Select one or more retailers that do not require vendor ID or additional UPC information, Click Done, Click Continue) for
		| Retailer |
		| CVS      |
	Given I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC75335, container type: Metal Container and size: 40
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
		| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
	Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: User added Comments Text 57863. !"�$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
	Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given If purchase details are showing click confirm order
	
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	#Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase75335)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase75335 and its status is: Submitted
	Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase75335)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase75335)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase75335 and its status is: Assigned
	Given I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase75335)
	Given I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase75335)
	Given I call Shared Step 75347 (WPS Studio - PD+ - set all data and publish using rule and Doc queue - CKLT, NGHS and SBCS) for product saved as: TestCase75335
	Given I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase75335)
	Given I call Shared Step 59066 (Go to SHA Manager)
	#Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase75335)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase75335 and its status is: Accepted
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Accepted Status for saved as: TestCase75335)
	Given I call Shared Step 51664 (SHA - Accepted Product - set Retailers to Completed for saved as: TestCase75335) for
		| Retailer |
		| CVS      |
	#Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase75335)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase75335 and its status is: Completed


