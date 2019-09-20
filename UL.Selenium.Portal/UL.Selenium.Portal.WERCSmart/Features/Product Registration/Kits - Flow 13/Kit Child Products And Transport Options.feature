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
@SummaryPage
@ProductSetUp
@run_KitsFlow13ChildProductsAndTransport

Feature: Kit Child Products And Transport Options

#And I The Purchase summary step is shown with the success message
#Call create product to COMPLETED steps (one is regulated for transport, one is not regulated for transport)
@TReVorId:20254
Scenario: [63521] Kit Product - One or more inputs is regulated for transport - Transportation step does NOT shows Not regulated option
	Given I login into the WERCSmart Portal - Administrator Role
	Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Bleach
	Then I save the product information as: Kit1
	Given I call Shared Step 74339 (Product Characteristics - Select Liquid and enter only Secondary state, Specific gravity, pH)
	Given I set the Boiling Point (in Celsius) field to: 86
	Given I set the Flash Point (in Celsius) field to: 92
	Given I set the Flash Point Testing Method Used field to: Closed cup
	Given I set the Select the best Water Solubility description field to: Decomposes
	Then in the Product Characteristics page I click Continue
	Given I call Shared Step 74340 (Additional Product Information - Pesticide= Not considered, SOLD=US, everything else = No - Continue)
	Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Ketone
	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	And I should see the Transportation Details 1 Page
	Given I set the Product is Regulated for Transport field to: Not Regulated
	#Given I set the Select all modes of transport field to: DOT
	#Given I set the Select all modes of transport field to: Shipping fully regulated
	Then in the Transport Details 1 page I click Continue
	#And I should see the U. S. Department of Transportation (DOT) Classification Page
	#Given I set the UN Number field to: UN1950
	#Given I set the Proper Shipping Name field to: Aerosols
	#Given I set the Hazard Class field to: 2.1	#Given I set the Packing Group field to: None
	#Then in the U. S. Department of Transportation (DOT) Classification page I click Continue
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Then I should see the Additional Documents to Provide Page
	Then in the Additional Documents to Provide page I click Continue
	Then I should see the Optional Reports and Documents Available for Purchase Page
	Then in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
		| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
	Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: User added Comments Text 57863. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Bleach
	Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given If purchase details are showing click confirm order
	And I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Submitted Status for saved as: Kit1)
	Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: Kit1)
	And I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: Kit1)
	And I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: Kit1)
	Given I call Shared Step 75347 (WPS Studio - PD+ - set all data and publish using rule and Doc queue - CKLT, NGHS and SBCS) for product saved as: Kit1
	And I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: Kit1)
	Given I call Shared Step 59066 (Go to SHA Manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: Kit1)
	Given In the SHA manager grid I see the WPS ID I have saved as product: Kit1 and its status is: Completed
	And I navigate to the landing page
	Given I login into the WERCSmart Portal - Administrator Role
	Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Bleach
	Then I save the product information as: Kit2
	Given I call Shared Step 74339 (Product Characteristics - Select Liquid and enter only Secondary state, Specific gravity, pH)
	Given I set the Boiling Point (in Celsius) field to: 86
	Given I set the Flash Point (in Celsius) field to: 92
	Given I set the Flash Point Testing Method Used field to: Closed cup
	Given I set the Select the best Water Solubility description field to: Decomposes
	Then in the Product Characteristics page I click Continue
	Given I call Shared Step 74340 (Additional Product Information - Pesticide= Not considered, SOLD=US, everything else = No - Continue)
	Given I call Shared Step 29181 (Ingredients - add any chemical) with name: Ketone
	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	And I should see the Transportation Details 1 Page
	Given I set the Product is Regulated for Transport field to: Yes
	Given I set the Select all modes of transport field to: DOT
	Given I set the Select all modes of transport field to: Shipping fully regulated
	Then in the Transport Details 1 page I click Continue
	And I should see the U. S. Department of Transportation (DOT) Classification Page
	Given I set the UN Number field to: UN1950
	Given I set the Proper Shipping Name field to: Aerosols
	Given I set the Hazard Class field to: 2.1
	Given I set the Packing Group field to: None
	Then in the U. S. Department of Transportation (DOT) Classification page I click Continue
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	Then I should see the Additional Documents to Provide Page
	Then in the Additional Documents to Provide page I click Continue
	Then I should see the Optional Reports and Documents Available for Purchase Page
	Then in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 57884 (Safety Data Sheet Authoring - Additional Data (Optional) step - add any random data for all fields - Happy path) and enter the following:
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor     | Odor Threshold    | Partition Coefficient |
		| Mask                          | 300                      | 1.005                   | 20        | Black      | Odorless | No data available | 10                    |
	Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: User added Comments Text 57863. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Bleach
	Given I call Shared Step 57885 (Data Acceptance - Click Accept - Happy Path)
	Given If purchase details are showing click confirm order
	And I call Shared Step 65080 (Login to Studio and Open SHA manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in Submitted Status for saved as: Kit2)
	Given I call Shared Step 40657 (SHA Manager - Submitted - Select product > process product data for product saved as: Kit2)
	And I call Shared Step 55662 (WPS Studio - Job Queue - wait for ImportProcessRules job to complete for product saved as: Kit2)
	And I call Shared Step 68969 (WPS Studio - Open PD+, edit existing with specific product > Click Continue for product saved as: Kit2)
	Given I call Shared Step 75347 (WPS Studio - PD+ - set all data and publish using rule and Doc queue - CKLT, NGHS and SBCS) for product saved as: Kit2
	And I call Shared Step 55663 (WPS Studio - Go to Job Queue - wait for Publish Multiple to complete for product saved as: Kit2)
	Given I call Shared Step 59066 (Go to SHA Manager)
	Given I call Shared Step 49841 (SHA - Search for exact WPS ID in All Status for saved as: Kit2)
	Given In the SHA manager grid I see the WPS ID I have saved as product: Kit2 and its status is: Completed
	And I navigate to the landing page
	Given I login into the WERCSmart Portal - Administrator Role
	#The previous steps just create the kit items
	#Scenario: Test
	#Given I login into the WERCSmart Portal - Administrator Role
	#Given I save to context name: Kit1 and value: 1502868
	#Given I save to context name: Kit2 and value: 1502793
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57500 (The Product- Enter name, select product type - Continue - Happy Path): Hair Care kit
	Then I save the product information as: TestCase63521
	Given I call Shared Step 63460 (Additional Product Information - SOLD = US, No(PL), No(GNFR) only shown (mainly kits) Happy Path)
	Given I call Shared Step 57503 (Regulatory Information 1- TSCA(Random) - Prop 65(No) - Continue - Happy Path)
	And I should see the Create the Kit Page
	Given In the Create the kit page I search for and select: saved as Kit1
	Given In the Create the kit page I search for and select: saved as Kit2
	Then in the Create the Kit page I click Continue
	And I should see the Transportation Details 1 Page
	Then in the Transportation Details 1 page I should see the Product is Regulated for Transport question
	Then The following radio buttons should be displayed for section: Product is Regulated for Transport
		| Button                               |
		| Yes                                  |
		| No, due to an exemption or exception |
	#Then in the Transport Details 1 page I should not see the Not regulated option
	Then The following radio buttons should not be displayed for section: Product is Regulated for Transport
		| Button        |
		| Not Regulated |
	# Below is equvilent because Not Regulated is not displayed if the last step passes and the count is = 2
	And I should see a total of 2 radio buttons for the section: Product is Regulated for Transport
	Then in the Transportation Details 1 page I click Continue
	Then I should see an error message: This is a required field.
	Given I set the Product is Regulated for Transport field to: No, due to an exemption or exception
	Then I should not see an error message: This is a required field.
	Given I set the Please select DOT Exceptions if applicable? field to: 173.159 (a) – Exemption for non-spillable lead-acid batteries
	Then in the Transportation Details 1 page I click Continue
	And I call Shared Step 62536 (Transportation Details 2 > I do not ship internationally > Continue - Happy Path)
	And I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	And I should see the Additional Documents to Provide Page
	Then in the Additional Documents to Provide page I click Continue
	And I call Shared Step 57883 (Comments - Happy Path) and enter the comment: test
	And I should see the Data Acceptance Page
	And I click the Summary button in the Data Acceptance window
	And I switch to the Data Summary page
	And In the Data Summary page I confirm that the following items are included in the kit:
		| Kit items     |
		| saved as Kit1 |
		| saved as Kit2 |
	And In the Data Summary page I confirm the following questions and answers
		| Question                           | Answer        | True or False |
		| Product is Regulated for Transport | Not Regulated | False         |
	And In the Data Summary page I confirm that I do not see any errors
	And I close the Data Summary tab
	And I navigate to the home page
	And I call Shared Step 43758 (Product Grid- Filter for Product- Select Product - Delete) for product: TestCase63521

