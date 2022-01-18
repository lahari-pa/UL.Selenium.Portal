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
@CreateProducts
@ForwardProductRegistration
@ProductSetUp
@run_ProductCreateAndComplete
Feature: Product Create and Process to Completed


Background:
	Given I verify the following users exist and if not I create them using SHAUser
		| username    | FirstName | LastName   | Role         | EmailAddress                |
		| SHAQAAuto18 | QA        | Automation | QA Reviewers | qasha.kxxyxunf@mailosaur.io |


@ScenarioId:1503
Scenario: [87913] Create Electronic (Answering machine, no battery included) - With Case UPC process to Completed
	Given I log in with the account saved in TReVor as: ProductAccount
	Given I generate a random UPC number and save as: UPC87913
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Answering machine, No battery included
	Then I save the product information as: TestCase87913
	Then I call Shared Step 60935 Product Information - US - Direct Ship - Private Label Only
	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	And I call Shared Step 48369 (Toxicity Characteristics Leaching Procedure (TCLP) - No to ALL With Copper)
	And I call Shared Step 71955 (Answer Electronic Equipment questions - Without Cathode Ray - No to all)
	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Amazon
	Given I call Shared Step 87641(Enter Universal Product Code - case information) for UPC: saved as UPC87913, container type: Paper bag and size: 2 and Quantity: 4 and Transportation option: random
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test data
	Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given If purchase details are showing click confirm order
	Given I call Shared Step 65080b (Login to Studio as user saved as: SHAQAAuto18 and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase87913)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase87913 and its status is: Submitted
	Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase87913)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase87913)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase87913 and its status is: Assigned
	Given I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase87913)
	Given I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase87913)
	Given I call Shared Step 75347 (WPS Studio - PD+ - set all data and publish using rule and Doc queue - CKLT, NGHS and SBCS) for product saved as: TestCase87913
	Given I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase87913)
	Given I call Shared Step 59066 (Go to SHA Manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase87913)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase87913 and its status is: Accepted
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Accepted Status for saved as: TestCase87913)
	Given I call Shared Step 51664 (SHA - Accepted Product - set Retailers to Completed for saved as: TestCase87913) for
		| Retailer |
		| Amazon   |
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase87913)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase87913 and its status is: Completed

#Given I call Shared Step 75309 (SHA > Select Product > UPC Retailer and Feed) for product saved as: TestCase87913
#And In the list of UPCs I should see case pack indicatior for UPC: saved as UPC87640
@ScenarioId:1504
Scenario: [87914] Create BCP (Camera with battery) -  with Case UPC - process to  Completed
	Given I log in with the account saved in TReVor as: ProductAccount
	Given I generate a random UPC number and save as: UPC87914
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Camera w/Battery
	Then I save the product information as: TestCase87914
	Given I call Shared Step 70393 (Product Information - With marketed for use by a Child - Direct Ship - Private Label questions only)
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I call Shared Step 48367 (Product Includes Battery > any type)
		| Battery Type | Manufacturer | Number of batteries per package | How many batteries required to run |
		| Alkaline     | <any>        | 6                               | 6                                  |
	Given I call Shared Step 48369 (Toxicity Characteristics Leaching Procedure (TCLP) - No to ALL With Copper)
	#Given I call Shared Step 71955 (Answer Electronic Equipment questions - Without Cathode Ray - No to all)
	Given I call Shared Step 58189 (Answer Electronic Equipment questions - With Cathode Ray - No to all)
	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Amazon
	Given I call Shared Step 87641(Enter Universal Product Code - case information) for UPC: saved as UPC87914, container type: Paper bag and size: 2 and Quantity: 4 and Transportation option: random
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test data
	Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given If purchase details are showing click confirm order
	Given I call Shared Step 65080b (Login to Studio as user saved as: SHAQAAuto18 and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase87914)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase87914 and its status is: Submitted
	Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase87914)
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

@tfs_design
@ignore
@ScenarioId:9406
Scenario: [87915] Create kit (Hair Care Kit) - with Case UPC -  process to completed
	Given I log in with the account saved in TReVor as: ProductAccount
	Then the WERCSmart homepage should load
	Given I generate a random UPC number and save as: UPC87915
	Given I create a Chalk product which has a Case UPC and a regular UPC, process to completed using SHA Account: SHAQAAuto18 and save the product as: Product1
	Given I navigate to the landing page
	Given I log in with the account saved in TReVor as: ProductAccount
	Given I create a Chalk product which has a Case UPC and a regular UPC, process to completed using SHA Account: SHAQAAuto18 and save the product as: Product2
	Given I navigate to the landing page	
	Given I log in with the account saved in TReVor as: ProductAccount
	Then the WERCSmart homepage should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Hair Color Kit
	Then I save the product information as: TestCase87915
	And I call Shared Step 60648 (Product Information - US, No (Direct Ship), No (PL), No (GNFR))
	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	And I call Shared Step 31427 (Create the Kit - Adding two products: product 1: Product1 and product 2: Product2)
	#And I call Shared Step 57506 (Transportation Details 1 - Regulated for Transport(No) - Exemption(Random) - Continue - Happy Path)
	#And I call Shared Step 62536 (Transportation Details 2 > I do not ship internationally > Continue - Happy Path)
	And I call Shared Step 57507 (Transportation Details 1- Not Regulated - Continue - Happy Path)
	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Amazon
	Given I call Shared Step 87641(Enter Universal Product Code - case information) for UPC: saved as UPC87915, container type: Paper bag and size: 2 and Quantity: 4 and Transportation option: <First>
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test data
	Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given If purchase details are showing click confirm order
	Given I call Shared Step 65080b (Login to Studio as user saved as: SHAQAAuto18 and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase87915)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase87915 and its status is: Submitted
	Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase87915)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase87915)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase87915 and its status is: Assigned
	Given I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase87915)
	Given I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase87915)
	Given I call Shared Step 75347 (WPS Studio - PD+ - set all data and publish using rule and Doc queue - CKLT, NGHS and SBCS) for product saved as: TestCase87915
	Given I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase87915)
	Given I call Shared Step 59066 (Go to SHA Manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase87915)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase87915 and its status is: Accepted
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Accepted Status for saved as: TestCase87915)
	Given I call Shared Step 51664 (SHA - Accepted Product - set Retailers to Completed for saved as: TestCase87915) for
		| Retailer |
		| Amazon   |
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase87915)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase87915 and its status is: Completed

@ScenarioId:1505
Scenario: [87916] Create Gas (Compressed Gas) - With Case UPC - Process to Completed
	Given I log in with the account saved in TReVor as: ProductAccount
	Given I generate a random UPC number and save as: UPC87916
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Compressed gas
	Then I save the product information as: TestCase87916
	Given I call Shared Step 63804 (Product Information - US, No(OSHA), No(DSV), Yes (PLP), No(GNFR))
		| Classified using OSHA (US) Globally Harmonized Standards (GHS) | Shipped directly by supplier | Private Label or Brand | Good Not for resale |
		| No                                                             | No                           | No                     | No                  |
		Given I call Shared Step 74981 (Physical and Chemical Properties - gas)		
		| Secondary Physical State | Select the best Water Solubility description |
		| Compressed gas           | Low                                          |
Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Cocoa butter  | 100     | false               | false       |            |
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)
	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Amazon
	Given I call Shared Step 87641(Enter Universal Product Code - case information) for UPC: saved as UPC87916, container type: <first> and size: 2 and Quantity: 4 and Transportation option: <first>
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient |
		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | 41.3005               |
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test data
	Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given If purchase details are showing click confirm order
	Given I call Shared Step 65080b (Login to Studio as user saved as: SHAQAAuto18 and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase87916)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase87916 and its status is: Submitted
	Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase87916)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase87916)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase87916 and its status is: Assigned
	Given I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase87916)
	Given I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase87916)
	Given I call Shared Step 75347 (WPS Studio - PD+ - set all data and publish using rule and Doc queue - CKLT, NGHS and SBCS) for product saved as: TestCase87916
	Given I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase87916)
	Given I call Shared Step 59066 (Go to SHA Manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase87916)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase87916 and its status is: Accepted
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Accepted Status for saved as: TestCase87916)
	Given I call Shared Step 51664 (SHA - Accepted Product - set Retailers to Completed for saved as: TestCase87916) for
		| Retailer |
		| Amazon   |
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase87916)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase87916 and its status is: Completed

#Given I call Shared Step 75309 (SHA > Select Product > UPC Retailer and Feed) for product saved as: TestCase87913
#And In the list of UPCs I should see case pack indicatior for UPC: saved as UPC87640
@ScenarioId:6263
Scenario: [87917] Create Aerosol (Deodorant - Aerosol) - with Case UPC - process to Completed
	Given I log in with the account saved in TReVor as: ProductAccount
	Given I generate a random UPC number and save as: UPC87917
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Deodorant - Aerosol
	Then I save the product information as: TestCase87917
	Given I call Shared Step 63804 (Product Information - US, No(OSHA), No(DSV), Yes (PLP), No(GNFR))
		| Classified using OSHA (US) Globally Harmonized Standards (GHS) | Shipped directly by supplier | Private Label or Brand | Good Not for resale |
		| No                                                             | No                           | No                     | No                  |
	Given I call Shared Step 57528 (Physical and Chemical Properties - Aerosol Only - add data - Continue - Happy Path)
	#Given I call Shared Step 74981 (Physical and Chemical Properties - gas)
	#| Secondary Physical State      | Select the best Water Solubility description         |
	#| Compressed gas                | Low                                                  |
#Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
	#| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
	#| Cocoa butter  | 100     | false               | false       |            |
	#Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	#Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	#Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)
	#Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Amazon
	#Given I call Shared Step 87641(Enter Universal Product Code - case information) for UPC: saved as UPC87916, container type: <first> and size: 2 and Quantity: 4 and Transportation option: <first>
	#Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	#Given in the Additional Documents to Provide page I click Continue
	#Given in the Optional Reports and Documents Available for Purchase page I click Continue
	#Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
	#| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient |
	#| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | 41.3005               |
	#Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test data
	Given I call Shared Step 69557 (Enter Ingredients for Aerosol Propellent)
	#Then I should not see an error message: ALERT! The ingredient table does not include a compressed gas (Bag-On-Valve) or a propellant. Please update your ingredients to include the propellant before proceeding.
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
	Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)
	#Given I call Shared Step 49621 (Volatile Organic Compounds (VOC) for OTC and CARB - No)
	Given I call Shared Step 62710 (Confirm VOC OTC/CARB heading and select No to FIRST QUESTION ONLY - Happy Path)
	Given I call Shared Step 60631 (VOC - HVOC and MVOC - add values - Continue - Happy Path)
	Given I click continue
	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Amazon
	Given I call Shared Step 87641(Enter Universal Product Code - case information) for UPC: saved as UPC87917, container type: Aerosol Can and size: 2 and Quantity: 4 and Transportation option: 4A: steel box
	#Then I call Shared Step 57960 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC87917, container type: Aerosol Can and size: 33
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given I call Shared Step 60567 (Upload Product Label only) for section: Volatile Organic Compounds
	And in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient | Product's Dispensing Method |
		| Mask                          | 150                      | 44                      | 10.7      | White      | Floral | No data available | 12                    | Aerosol                     |
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: User added Comments Text 60619. !"�$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Deodorant - Aerosol
	Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given If purchase details are showing click confirm order
	Given I call Shared Step 65080b (Login to Studio as user saved as: SHAQAAuto18 and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase87917)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase87917 and its status is: Submitted
	Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase87917)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase87917)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase87917 and its status is: Assigned
	Given I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase87917)
	Given I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase87917)
	Given I call Shared Step 75347 (WPS Studio - PD+ - set all data and publish using rule and Doc queue - CKLT, NGHS and SBCS) for product saved as: TestCase87917
	Given I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase87917)
	Given I call Shared Step 59066 (Go to SHA Manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase87917)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase87917 and its status is: Accepted
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Accepted Status for saved as: TestCase87917)
	Given I call Shared Step 51664 (SHA - Accepted Product - set Retailers to Completed for saved as: TestCase87917) for
		| Retailer |
		| Amazon   |
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase87917)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase87917 and its status is: Completed

#Given I call Shared Step 75309 (SHA > Select Product > UPC Retailer and Feed) for product saved as: TestCase87913
#And In the list of UPCs I should see case pack indicatior for UPC: saved as UPC87640
@ScenarioId:9761
Scenario: [87922] Create Liquid (Bubble Solution) with Case UPC - Process to Completed
	Given I log in with the account saved in TReVor as: ProductAccount
	Given I generate a random UPC number and save as: UPC87922
	And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bubble solution
	Then I save the product information as: TestCase87922
		Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	And I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
	And I call Shared Step 29181 (Ingredients - add any chemical) with name: Chlorine
	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Amazon
    Given I call Shared Step 87641(Enter Universal Product Code - case information) for UPC: saved as UPC87922, container type: Cardboard and size: 2 and Quantity: 4 and Transportation option: 4A: steel box
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient |
		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | 41.3005               |
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test data
	Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given If purchase details are showing click confirm order
	Given I call Shared Step 65080b (Login to Studio as user saved as: SHAQAAuto18 and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase87922)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase87922 and its status is: Submitted
	Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase87922)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase87922)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase87922 and its status is: Assigned
	Given I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase87922)
	Given I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase87922)
	Given I call Shared Step 75347 (WPS Studio - PD+ - set all data and publish using rule and Doc queue - CKLT, NGHS and SBCS) for product saved as: TestCase87922
	Given I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase87922)
	Given I call Shared Step 59066 (Go to SHA Manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase87922)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase87922 and its status is: Accepted
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Accepted Status for saved as: TestCase87922)
	Given I call Shared Step 51664 (SHA - Accepted Product - set Retailers to Completed for saved as: TestCase87922) for
		| Retailer |
		| Amazon   |
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase87922)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase87922 and its status is: Completed

#Given I call Shared Step 75309 (SHA > Select Product > UPC Retailer and Feed) for product saved as: TestCase87913
#And In the list of UPCs I should see case pack indicatior for UPC: saved as UPC87640
@ScenarioId:6073
Scenario: [87923] Create Solid (Chalk) - with Case UPC - Process to Completed
	Given I log in with the account saved in TReVor as: ProductAccount
	Given I generate a random UPC number and save as: UPC87923
	And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
	Then I save the product information as: TestCase87923
		Given I call Shared Step 59680 (Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
Given I call Shared Step 26897 (Physical and Chemical Properties - Solid only available - continue)
	#And I call Shared Step 57514 (Physical and Chemical Properties - Liquid Only available - Enter all data - Continue - Happy Path)
	And I call Shared Step 29181 (Ingredients - add any chemical) with name: Chlorine
	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Amazon
	Given I call Shared Step 87641(Enter Universal Product Code - case information) for UPC: saved as UPC87923, container type: Paper bag and size: 2 and Quantity: 4 and Transportation option: 4A: steel box
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient |
		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | 41.3005               |
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test data
	Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given If purchase details are showing click confirm order
	Given I call Shared Step 65080b (Login to Studio as user saved as: SHAQAAuto18 and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase87923)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase87923 and its status is: Submitted
	Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase87923)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase87923)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase87923 and its status is: Assigned
	Given I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase87923)
	Given I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase87923)
	Given I call Shared Step 75347 (WPS Studio - PD+ - set all data and publish using rule and Doc queue - CKLT, NGHS and SBCS) for product saved as: TestCase87923
	Given I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase87923)
	Given I call Shared Step 59066 (Go to SHA Manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase87923)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase87923 and its status is: Accepted
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Accepted Status for saved as: TestCase87923)
	Given I call Shared Step 51664 (SHA - Accepted Product - set Retailers to Completed for saved as: TestCase87923) for
		| Retailer |
		| Amazon   |
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase87923)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase87923 and its status is: Completed

#And In the list of UPCs I should see case pack indicatior for UPC: saved as UPC87640

@ScenarioId:6151
Scenario: [118139] CA Cleaning - Process Product to Completed
	Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I generate a random UPC number and save as: UPC118139
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Floor Wax - Wood
	Then I save the product information as: TestCase118139
	Given In the Product Information Screen I answer the questions as follows - US only - No to GHS - No to shipped supplier - Yes to CA Cleaning - No to Private Label - No to Sold to retailer)
	Given I call Shared Step 57501 (Physical and Chemical Properties - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue - HP)
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
	Given I call Shared Step 57883 (Optional Comments - Happy Path) and enter the comment: test
	Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given I call Shared Step 54796 (Purchase Summary)
	Given I call Shared Step 65080b (Login to Studio as user saved as: SHAQAAuto18 and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase118139)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase118139 and its status is: Submitted
	Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase118139)
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
