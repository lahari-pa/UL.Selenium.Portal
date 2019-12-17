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
@run_SoldAndPLPTests
Feature: Sold and PLP Tests

Scenario: [87957] Create Solid (Chalk) - with Case UPC - Process to Completed
	Given I log in with the account saved in TReVor as: ProductAccount
	Given I generate a random UPC number and save as: UPC87957
	Given I generate a random UPC number and save as: UPC879571
	And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Chalk
	Then I save the product information as: TestCase87957
	Given I call Shared Step 26897 (Product Characteristics - Solid only available - continue)
	#And I call Shared Step 57514 (Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path)
	Given I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	And I call Shared Step 29181 (Ingredients - add any chemical) with name: Chlorine
	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Amazon
	Given I call Shared Step 87647 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC87957, container type: Paper bag and size: 2 do not click continue
	Given I call Shared Step 87641(Enter Universal Product Code - case information) for UPC: saved as UPC879571, container type: <first> and size: 2 and Quantity: 4 and Transportation option: <first>
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
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase87957)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase87957 and its status is: Submitted
	Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase87957)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase87957)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase87957 and its status is: Assigned
	Given I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase87957)
	Given I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase87957)
	Given I call Shared Step 75347 (WPS Studio - PD+ - set all data and publish using rule and Doc queue - CKLT, NGHS and SBCS) for product saved as: TestCase87957
	Given I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase87957)
	Given I call Shared Step 59066 (Go to SHA Manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase87957)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase87957 and its status is: Accepted
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Accepted Status for saved as: TestCase87957)
	Given I call Shared Step 51664 (SHA - Accepted Product - set Retailers to Completed for saved as: TestCase87957) for
		| Retailer |
		| Amazon   |
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase87957)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase87957 and its status is: Completed

@ScenarioId:6259
Scenario: [87959] SOLD = US only, PL Yes, Create Liquid (Bubble Solution) with Case UPC - Process to Completed
	Given I log in with the account saved in TReVor as: ProductAccount
	Given I generate a random UPC number and save as: UPC87959
	And I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	And I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Bubble solution
	Then I save the product information as: TestCase87959
	And I call Shared Step 57514 (Product Characteristics - Liquid Only available - Enter all data - Continue - Happy Path)
	Given I call Shared Step 63860 (Additional Product Information - US, No(child), No(OSHA), No(DSV), Yes(PLP), No(GNFR))
	Given I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	And I call Shared Step 29181 (Ingredients - add any chemical) with name: Chlorine
	Given I call Shared Step 57637 (Regulatory Information 1 - TSCA & CEPA shown, No to PROP 65 - Continue - Happy Path)
	Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)
	#And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	#Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Amazon
	And I call Shared Step 85990 - Retailers - PLP - Select one or more retailer and add PL information - Continue
		| Retailer |
		| Amazon   |
	Given I call Shared Step 87641(Enter Universal Product Code - case information) for UPC: saved as UPC87959, container type: <first> and size: 2 and Quantity: 4 and Transportation option: <first>
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	#Given I call Shared Step 104662 - Regulatory Documents to Provide - Lithium Batteries - US and Canada - Request authoring for both
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	#Given I call Shared Step 64097 - Additional Documents -> Contact Information - Add any Name, address, phone and emergency phone - Happy Path
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient |
		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | 41.3005               |
	Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: test data
	Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given If purchase details are showing click confirm order
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase87959)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase87959 and its status is: Submitted
	Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase87959)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase87959)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase87959 and its status is: Assigned
	Given I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase87959)
	Given I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase87959)
	Given I call Shared Step 75347 (WPS Studio - PD+ - set all data and publish using rule and Doc queue - CKLT, NGHS and SBCS) for product saved as: TestCase87959
	Given I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase87959)
	Given I call Shared Step 59066 (Go to SHA Manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase87959)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase87959 and its status is: Accepted
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Accepted Status for saved as: TestCase87959)
	Given I call Shared Step 51664 (SHA - Accepted Product - set Retailers to Completed for saved as: TestCase87959) for
		| Retailer |
		| Amazon   |
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase87959)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase87959 and its status is: Completed

Scenario: [87969] SOLD US & Canada, PL = Yes, Gas (Compressed Gas) - With Case UPC - Process to Completed
	Given I log in with the account saved in TReVor as: ProductAccount
	Given I generate a random UPC number and save as: UPC87969
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Compressed gas
	Then I save the product information as: TestCase87969
	#And I call Shared Step 69687 (Additional Product Information - US, No(PL))
	Given I call Shared Step 74981 (Product Characteristics - gas)
		| Secondary Physical State | Select the best Water Solubility description |
		| Compressed gas           | Low                                          |
	#Given I call Shared Step 63860 (Additional Product Information - US, No(child), No(OSHA), No(DSV), Yes(PLP), No(GNFR))
	Given I call Shared Step 89286 - Additional Product Information - US and Canada - Child (NO), GHS (NO), DSV (NO), PLP(YES), GNFR (NO), Continue
	#Given I call Shared Step 63804 (Additional Product Information - enter options)
	#| Classified using OSHA (US) Globally Harmonized Standards (GHS) | Shipped directly by supplier  | Private Label or Brand | Good Not for resale |
	#| No                                                             | No                            | No                         | No              |
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Cocoa butter  | 100     | false               | false       |            |
	Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I call Shared Step 57727 (Transportation Details 1 - Yes option - Select DOT, Limited Quantity - Continue - Happy Path)
	Given I call Shared Step 57728 (U.S. Department of Transportation (DOT) Classification - Enter UN1950 (Aerosol) - Select data - Continue - Happy Path)
	#Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Amazon
	And I call Shared Step 85990 - Retailers - PLP - Select one or more retailer and add PL information - Continue
		| Retailer |
		| Amazon   |
	Given I call Shared Step 87641(Enter Universal Product Code - case information) for UPC: saved as UPC87969, container type: <first> and size: 2 and Quantity: 4 and Transportation option: <first>
	Given I call Shared Step 104662 - Regulatory Documents to Provide - Lithium Batteries - US and Canada - Request authoring for both
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 64097 - Additional Documents -> Contact Information - Add any Name, address, phone and emergency phone - Happy Path
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient |
		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | 41.3005               |
	Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: test data
	Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given If purchase details are showing click confirm order
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase87969)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase87969 and its status is: Submitted
	Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase87969)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase87969)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase87969 and its status is: Assigned
	Given I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase87969)
	Given I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase87969)
	Given I call Shared Step 75347 (WPS Studio - PD+ - set all data and publish using rule and Doc queue - CKLT, NGHS and SBCS) for product saved as: TestCase87969
	Given I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase87969)
	Given I call Shared Step 59066 (Go to SHA Manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase87969)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase87969 and its status is: Accepted
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Accepted Status for saved as: TestCase87969)
	Given I call Shared Step 51664 (SHA - Accepted Product - set Retailers to Completed for saved as: TestCase87969) for
		| Retailer |
		| Amazon   |
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase87969)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase87969 and its status is: Completed

Scenario: [88198] SOLD = Canada Only, PL = Yes, Create Electronic (Answering machine, no battery included) - With Case UPC process to Completed
	Given I log in with the account saved in TReVor as: ProductAccount
	Given I generate a random UPC number and save as: UPC88198
	Given I generate a random UPC number and save as: UPC881981
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Answering machine, No battery included
	Then I save the product information as: TestCase88198
	#And I call Shared Step 69687 (Additional Product Information - US, No(PL))
	#Given I call Shared Step 63860 (Additional Product Information - US, No(child), No(OSHA), No(DSV), Yes(PLP), No(GNFR))
	Given I call Shared Step 85730 - Additional Product Information - Canada Only - Child (NO), GHS (NO), DSV (NO), PLP(YES), GNFR (NO), Continue
	And I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	And I call Shared Step 48369 (Toxicity Characteristics Leaching Procedure (TCLP) - No to ALL With Copper)
	And I call Shared Step 71955 (Answer Electronic Equipment questions - Without Cathode Ray - No to all)
	#Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Amazon
	And I call Shared Step 85990 - Retailers - PLP - Select one or more retailer and add PL information - Continue
		| Retailer      |
		| Canadian Tire |
	Given I call Shared Step 87647 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC87957, container type: Paper bag and size: 2 do not click continue
	Given I call Shared Step 87641(Enter Universal Product Code - case information) for UPC: saved as UPC879571, container type: <first> and size: 2 and Quantity: 4 and Transportation option: <first>
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: test data
	Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given If purchase details are showing click confirm order
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase88198)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase88198 and its status is: Submitted
	Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase88198)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase88198)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase88198 and its status is: Assigned
	Given I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase88198)
	Given I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase88198)
	Given I call Shared Step 75347 (WPS Studio - PD+ - set all data and publish using rule and Doc queue - CKLT, NGHS and SBCS) for product saved as: TestCase88198
	Given I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase88198)
	Given I call Shared Step 59066 (Go to SHA Manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase88198)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase88198 and its status is: Accepted or Completed

#Given I call Shared Step 75309 (SHA > Select Product > UPC Retailer and Feed) for product saved as: TestCase87913
#And In the list of UPCs I should see case pack indicatior for UPC: saved as UPC87640
Scenario: [88199] SOLD = Canada, PL No, Create BCP (Camera with battery) -  with Case UPC - process to  Completed
	Given I log in with the account saved in TReVor as: ProductAccount
	Given I generate a random UPC number and save as: UPC88199
	Given I generate a random UPC number and save as: UPC881991
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Camera w/Battery
	Then I save the product information as: TestCase88199
	Given I call Shared Step - Additional Product Information - canada only - With marketed for use by a Child - Direct Ship - Private Label questions only
	#Given I call Shared Step 70393 (Additional Product Information - With marketed for use by a Child - Direct Ship - Private Label questions only)
	#Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Given I call Shared Step 57911 (Regulatory Information 1 - CEPA only shown - Continue - Happy Path)
	Given I call Shared Step 48367 (Product Includes Battery > any type)
		| Battery Type | Manufacturer | Number of batteries per package | How many batteries required to run |
		| Alkaline     | <any>        | 6                               | 6                                  |
	Given I call Shared Step 48369 (Toxicity Characteristics Leaching Procedure (TCLP) - No to ALL With Copper)
	#Given I call Shared Step 71955 (Answer Electronic Equipment questions - Without Cathode Ray - No to all)
	Given I call Shared Step 58189 (Answer Electronic Equipment questions - With Cathode Ray - No to all)
	Given I call Shared Step 57510 (Retailer Association - Select A Retailer - Continue - Happy Path) and select the retailer: Canadian Tire
	Given I call Shared Step 87647 (Enter Universal Product Code (UPC) - UPC-Container Type - Size Only) for UPC: saved as UPC88199, container type: Paper bag and size: 2 do not click continue
	Given I call Shared Step 87641(Enter Universal Product Code - case information) for UPC: saved as UPC881991, container type: <first> and size: 2 and Quantity: 4 and Transportation option: <first>
	Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: test data
	Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given If purchase details are showing click confirm order
	Given I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase88199)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase88199 and its status is: Submitted
	Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: TestCase88199)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase88199)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase88199 and its status is: Assigned
	Given I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: TestCase88199)
	Given I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: TestCase88199)
	Given I call Shared Step 75347 (WPS Studio - PD+ - set all data and publish using rule and Doc queue - CKLT, NGHS and SBCS) for product saved as: TestCase88199
	Given I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: TestCase88199)
	Given I call Shared Step 59066 (Go to SHA Manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: TestCase88199)
	Given In the SHA manager grid I see the WPS ID I have saved as product: TestCase88199 and its status is: Accepted or Completed
