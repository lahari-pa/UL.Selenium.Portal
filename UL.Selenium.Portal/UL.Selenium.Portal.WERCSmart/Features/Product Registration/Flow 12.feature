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
@run_Flow12
@MyAccount

Feature: Flow 12


#Scenario: [58430] Mixture, Blend, Formulation, Solution - RU000722
#
## Created by Aaron Caton
#
## Test case can be found at the following paths:
## NetProjects10\WERCSmart UX Reboot\WERCSmart\Product Registration\Flow 12
## NetProjects10\WercsSmart Portal\WERCSmart\Product Registration\Flow 12 - 3rd Party
@ScenarioId:793
Scenario: [58430] Mixture, Blend, Formulation, Solution - RU000722
Given I call Shared Step 67823 (Login to WERCSmart - Products Automation Account)
Given I click on My Account
Then I create a new email address
Then I create a new user with the following information and set the password from the admin account: ProductAccount
| User Name | Title | Role | Phone Number | Email Address | Confirm Email | Country Code | Country        |
| User      | Mr    | User | 123-456-7889 | Saved         | Saved         | empty        | United Kingdom |    
Then I logout
Then I log in as the user saved as: NewUser
Then If terms of use page appears I accept
And I enter the following into the Security Questions window for user saved as: NewUser
And I enter the pin for user saved as: NewUser
When In the new user form I click on Next
Then In the new user form I click on Success
And I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
And I call Shared Step 82831 (The Product - Enter Product Name and Select Type of Product: Mixture, Blend, Formula, Polymer or Solution from Third (3rd, 3d) Party)
Then I save the product information as: TestCase58430
And I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
| ComponentName   | Percent | PublicallyDisclosed | TradeSecret | PublicName |
| Sodium chloride | 33.33   | false               | false       |            |
| Copper sulfate  | 11.67   | false               | false       |            |
| Nitric acid     | 55      | false               | false       |            |
And I call Shared Step 48948 (Formulation > 3rd Party - Select all)
And I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
And I call Shared Step 60932 (Regulatory Information 2 - Microbeads - No)
And I click continue
#Then I check that the input field with label: Formula Name for the WERCSmart Ingredient Directory has the following text: Raw material
And I should see following statement: Provide the name(s) to be used to identify the formula
Then I set the Formula Name for the WERCSmart Ingredient Directory field to: -
Then I set the Formula Name for the WERCSmart Ingredient Directory field to: Mixture, Blend, Formula, Polymer or Solution from Third (3rd, 3d) Party

And I should see following statement: Provide Public Name(s) of the formula you're registering. This will be available to the Supplier to select for your ingredient when the ingredient is indicated to be Publicly Available. Public Names are typically on a products label, website or other information available to the general public.
And I should see following statement: Public Name 1
And I should see following statement: Public Name 2
And I should see following statement: Public Name 3
And I should see following statement: For ingredients used in cleaning products its Business-to-Consumer name must comply with the requirements of the California Cleaning Product Right to Know Act. Manufacturer must use a name that is only as generic as necessary to protect the confidential identity of the ingredient. In developing the generic name, the manufacturer must use the generic name framework provided by the Federal Environmental Protection Agency (EPA) guidance for the Toxic Substances Control Act (TSCA) Confidential Inventory.
And I should see following statement: Business to Consumer Name
Then I check that the input field with label: Business to Consumer Name has the following placeholder: Business-to-Consumer Name (Generic Ingredient Name)
Then I set the Business to Consumer Name field to: = ; ^ * ¿? !¡ \ ~ [] <> | {} + )
Then I click continue 
And Business to Consumer Name should be showing the error messages:  Enter valid information (The following characters are not allowed: = ; ^ * ¿? !¡ \ ~ [] <> | {} + )
Then I set the Business to Consumer Name field to: Test
And Business to Consumer Name should not be showing the error messages:  Enter valid information (The following characters are not allowed: = ; ^ * ¿? !¡ \ ~ [] <> | {} + )
And I click continue
And I call Shared Step 58610 (Confirm Restrict Use - Restrict)
And I should see the Sustainability Page
Given in the Sustainability page I click Continue
Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: User added Comments Text 58605. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
And I call Shared Step 73956 (Go to Summary and verify data) with product type: Mixture, Blend, Formula, Polymer or Solution from Third (3rd, 3d) Party
And I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase58430

@ScenarioId:794
Scenario: [58605] Suppository (no laxative) -  RU001151
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I call Shared Step 57408 (Create a New Registration via Register New Product icon)
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Suppository, Medicinal
	Then I save the product information as: TestCase58605
	#Given I call Shared Step 37857 (Enter Physical Property - Solid)
	Given I call Shared Step 57501 (Product Characteristics - More than one state - select Solid - State&Subcat - Mixed&Water -random - Continue)
	#Given I call Shared Step 65511 (Additional Product Information - No Child, No Direct ship, No PL, Click Continue - Happy Path (use in a BCP))
	Given I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	#Given I check the new page has loaded with no required field error. Navigating from: Additional Product Information to: Ingredients
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Glycerin      | 30      | false               | false       |            |
		| Glucose       | 30      | false               | false       |            |
		| Aqua          | 40      | false               | false       |            |
	#Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65
	Then I call Shared Step 132427 (Waste Classification Data- For OTC Products)
	Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
	#Given I call Shared Step 63219 (Retailer Association - Select No Retailer - Click continue)
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	Given I call Shared Step 60567 (Upload Product Label only)
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: User added Comments Text 58605. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Suppository, Medicinal
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase58605

@ScenarioId:795
Scenario: [58606] Medicinal Liquids - RU001188
	Given I Login into WERCSmart Portal - Admin Role - WERCs Product Account
	Then The home screen should load
	Given I generate a random UPC number and save as: UPC58606
	Given I delete all products with UPC Number: saved as UPC58606
	Given I call Shared Step 57753 (Create a New Registration via Register New Product (expanded menu))
	Given I call Shared Step 57561 (The Product - Enter Product Name and select Type of Product): Medicinal Liquids (cough medicine, eye drops, ear drops, nasal spray and inhalers)
	Then I save the product information as: TestCase58606
	Given I call Shared Step 70675 (Product Characteristics - Liquid Only - With Water Solubility - Enter all data - Continue)
	#Given I call Shared Step 65511 (Additional Product Information - No Child, No Direct ship, No PL, Click Continue - Happy Path (use in a BCP))
	Given I call Shared Step 59680 (Additional Product Information - US only, No Child, No GHS, No Direct Ship, No PLP, No GNFR - Continue - Happy Path)
	#Given I check the new page has loaded with no required field error. Navigating from: Additional Product Information to: Ingredients
	Given I call Shared Step 57570 (Enter Ingredients) and add the following ingredients:
		| ComponentName | Percent | PublicallyDisclosed | TradeSecret | PublicName |
		| Ethanol       | 20      | false               | false       |            |
		| Paracetamol   | 5       | false               | false       |            |
		| Aqua          | 50      | false               | false       |            |
		| Guaifenesin   | 25      | false               | false       |            |
	#Given I call Shared Step 57571 (Enter Regulatory Information - Not Prop 65)
	Then I call Shared Step 132427 (Waste Classification Data- For OTC Products)
	#Given I call Shared Step 57713 Regulatory Information 3 - Drug Facts Panel - None of the above - Continue - Happy Path
	Given I call Shared Step 57506 (Transportation Details 1 - Regulated for Transport(No) - Exemption(Random) - Continue - Happy Path)
	Given I call Shared Step 62536 (Transportation Details 2 > I do not ship internationally > Continue - Happy Path)
	Given I call Shared Step 29206 (Retailer - Select No Retailer - Click Done - Click Continue - Happy Path)
	#Given I call Shared Step 63219 (Retailer Association - Select No Retailer - Click continue)
	# Regulatory Documents to Provide page is showing
	Given I call Shared Step 57881 (Regulatory Documents to Provide - US only - request authoring - Happy Path)
	#Given I call Shared Step 60567 (Upload Product Label only) : C:\Dependencies\WERCSmart\testdoc.pdf
	Given in the Additional Documents to Provide page I click Continue
	Given in the Optional Reports and Documents Available for Purchase page I click Continue
	Given I call Shared Step 59663 (Safety Data Sheet Authoring - Additional Data (Optional))
		| Personal Protection Equipment | Autoignition Temperature | Minimum Ignition Energy | Viscosity | Appearance | Odor   | Odor Threshold    | Partition Coefficient |
		| Gloves                        | 501.827328               | 10.00001                | 10.28     | Brown      | Orange | No data available | 41.3005               |
	Given I call Shared Step 57883 (Comments - Happy Path) and enter the comment: User added Comments Text 58606. !"£$%^&*() 1234567890 (Provide any additional comments or information about the product that you want the Assessment Team to know.)
	Given I call Shared Step 73956 (Go to Summary and verify data) with product type: Medicinal Liquids (cough medicine, eye drops, ear drops, nasal spray and inhalers)
	Given I call Shared Step 42214 (Delete a Product from the Product grid) to delete product: TestCase58606

# Assigned to Beverly Barrett
# Created by Beverly Barrett
# Test case can be found at the following paths:
# NetProjects10\WercsSmart Portal\Obsolete
# NetProjects10\WercsSmart Portal\WERCSmart\Product Registration\Flow 12 - 3rd Party
@ProductSetUp
@42196
@ScenarioId:796
Scenario: [42196] 3rd party > Recertification - with check for editing of Public disclosure setting and other Ingredients page validation
	#Given I call Shared Step 23195 (Login into WERCSmart Portal - Administrator Role)
	Given I call Shared Step 67038 (Login into WERCSmart Portal - ULSC Role)
	And I create a product with name: TEST CASE 42196 - 3rd party Recertification while logged in as Portal - ULSC Role and take to completed using Test Case 79428 and save as: TestCase42196
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
	#And I Confirm you cannot remove any component from the formulation
	And I confirm the 'Delete' button is not available in the Ingredients table
	#And I confirm that you CAN alter the "Publicly Disclosed" check box from selected to Un-selected
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
	#And I confirm that for the first component shows no error below the Public Name drop down
	And I should see the Formulation Page
	And I click the page heading: Ingredients
	And I edit the second component to show Yes for Publicly disclosed
	And I edit the second component to select: <random> from the Public Name drop down and save choice as publicName
	And I click Save in The Product Page
	#And I confirm that for the first component shows no error below the Public Name drop down
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
	#Scenario: test
	#Given I save to context name: TestCase42196 and value: 1548654
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
#And I Confirm the product is shown in Completed status for NR so that it can be used again the next time the test case is run
