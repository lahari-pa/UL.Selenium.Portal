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
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:ProductInformation
@PhysicalAndChemicalProp
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:RegulatoryDocumentsToProvide
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:OptionalComments
@Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:DataAcceptance
@Ingredients
@Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:CaliforniaCleaningProductDisclosure
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:InventoryStatusProp65
@Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:Retailer


Feature: PDPlusFailures

#This feature is used to hold copies of scenarios that fail / often fail in PD+. If a scenario found in this feature and has been passing consistently, feel free to remove it from the feature file.

@ScenarioId:10361
Scenario: [PDPlusFailures] 118139 | Product Create and Process to Completed

	#Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I log in with the account saved in TReVor as: ProductAccount
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I generate a random UPC number and save as: UPC118139
    And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Floor Wax - Wood
	Then I save the product information as: TestCase118139
#Given In the Product Information Screen I answer the questions as follows - US only - No to GHS - No to shipped supplier - Yes to CA Cleaning - No to Private Label - No to Sold to retailer)
Given I should see the Product Information Page
Given In the Product Information Section, set the option in section: 'Which best describes your product, including when FIFRA 25(b) Exempt' to: Product is intended for preventing, destroying, repelling, or mitigating pests (including insects, rodents, mold, virus, bacteria, and other micro-organisms)
Given In the Product Information Section, set the option in section: 'Retailers will be selling my product at their store locations' to: United States
Given In the Product Information Section, set the option in section: 'Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)' to: No
Given In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: No
Given In the Product Information Section, set the option in section: 'Cleaning products must comply with California's Cleaning Product Right to Know Act. I would like to provide the additional information needed for this program during registration.' to: Yes
Given In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product' to: No
Given In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)' to: No
Given I click continue
#Given In the Claifornia Cleaning Product Disclosure I choose 'Manufacturer' and select 'No' for CBI, then enter Placeholder Details
Given In the California Cleaning Product Disclosure Section, set the radio option in section: 'Who is publicly identified on the product label as responsible for the product?': to: Manufacturer
Given In the California Cleaning Product Disclosure Section, set the option in section: 'Who is the Final Domestic Distributor (if any) of the product?' to: Company Name
Given In the California Cleaning Product Disclosure Section, set the option in section: 'Is your identity, as the Manufacturer of this product, Confidential Business Information (CBI)?' to: Yes
Given In the California Cleaning Product Disclosure Section, set the option in section: 'Company's Toll-Free Phone Number' to: 11111111111
Given In the California Cleaning Product Disclosure Section, set the option in section: 'Company Web Address' to: http://TestWebsitePlaceholderName.com
Given In the California Cleaning Product Disclosure Section, set the option in section: 'Select the product's GTIN Brick Code' to: [10000424] Laundry Detergents
Given I click continue
#Given I call Shared Step 57501 (Physical and Chemical Properties - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue - HP)
Given In the Physical and Chemical Properties Section, set the option in section: 'Primary Physical State' to: Solid
Given In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: Bonded, fibrous glass web
Given In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: No
Given In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: Soluble in water
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
	#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	#Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given I should see the Data Acceptance Page
	Then In the Data Acceptance Section, check 'Agreed' checkbox
	Then In the Data Acceptance Section, click 'Accept' button

	Given I call Shared Step 54796 (Purchase Summary)
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
#	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase118139)
#	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase118139 and its status is: Submitted
#
#	Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase118139)
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
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Camera w/Battery
	Then I save the product information as: TestCase87914
	Given I call Shared Step 70393 (Product Information - With marketed for use by a Child - Direct Ship - Private Label questions only)
	#Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I should see the Inventory Status, Prop 65 (US) Page
	Then In the Inventory Status, Prop 65 (US) Section, set the radio option in section: 'U.S. Toxic Substances Control Act (TSCA) status' to: This product is subject to and complies with TSCA chemical Inventory listing requirements.
	Then In the Inventory Status, Prop 65 (US) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?' to: No
	Then in the Inventory Status, Prop 65 (US) page I click Continue

	Given I call Shared Step 48367 (Product Includes Battery > any type)
		| Battery Type | Manufacturer | Quantity of Batteries per Package | Quantity of Batteries to Operate Product |
		| Alkaline     | <any>        | 6                               | 6                                  |
	Given I call Shared Step 48369 (Toxicity Characteristics Leaching Procedure (TCLP) - No to ALL With Copper)
	Given I call Shared Step 58189 (Answer Electronic Equipment questions - With Cathode Ray - No to all)
	#Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Amazon
	Given I should see the Retailer Page
	Then In the Retailer Section, click 'Add Retailers' button
	Then In the Select Retailers window, select retailer: Amazon
	Then In the Select Retailers window, click 'Done' button
	Then in the Retailer page I click Continue

	Given I call Shared Step 87641(Enter Universal Product Code - case information) for UPC: saved as UPC87914, container type: Paper bag and size: 2 and Quantity: 4 and Transportation option: random
	#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test data
	Given I should see the Optional Comments Page
	Then In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: test
	Then in the Optional Comments page I click Continue

	#Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given I should see the Data Acceptance Page
	Then In the Data Acceptance Section, check 'Agreed' checkbox
	Then In the Data Acceptance Section, click 'Accept' button

	Given If purchase details are showing click confirm order
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
#	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase87914)
#	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase87914 and its status is: Submitted
#
#	Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase87914)
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
